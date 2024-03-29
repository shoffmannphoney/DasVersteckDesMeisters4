﻿using System;
using Phoney_MAUI;
using Phoney_MAUI.Game.General;
using Phoney_MAUI.Core;
using Phoney_MAUI.Model;
using System.Diagnostics;
using System.Windows.Input;
using GameCore;

namespace Phoney_MAUI.Menu;

public partial class HomePage : ContentPage, IMenuExtension
{
    private readonly MainViewModel _viewModelMain;
    private readonly GeneralViewModel _viewModelGeneral;
    private readonly MenuExtension _menuExtension;
    public GlobalData GD { get; set; }

    private IUIServices UIS { get; set; }

    public HomePage(MainViewModel viewModelMain, GeneralViewModel viewModelGeneral, MenuExtension menuExtension, IUIServices iuis)
	{
      
		InitializeComponent();
        BindingContext = _viewModelMain = viewModelMain;
        _viewModelGeneral = viewModelGeneral;
        _viewModelGeneral.SetCallbackChangeOrientation( (IGlobalData._callbackChangeOrientation) ChangeOrientation);
        _menuExtension = menuExtension;


        _menuExtension!.SetMenuExtension(GetMenuGridLeft, GetMenuGridTotal, GetMenuGridMenu, WebView_Grid, Page_Grid, GetMenuButton, null, GetAbsoluteLayout, GetMenuTitle, nameof(HomePage));

        if( GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() < 800 && GlobalSpecs.CurrentGlobalSpecs.GetScreenHeight() < GlobalSpecs.CurrentGlobalSpecs.GetScreenWidth())
        {
            double y = (530 * GlobalSpecs.CurrentGlobalSpecs.GetScreenHeight()) / 800;
            double x = ( 224 * GlobalSpecs.CurrentGlobalSpecs.GetScreenHeight()) / 800;

            vlinks.WidthRequest = x;
            vrechts.WidthRequest = x;

            vlinks.HeightRequest = y;
            vrechts.HeightRequest = y;


            y = (510 * GlobalSpecs.CurrentGlobalSpecs.GetScreenHeight()) / 800;
            x = (222 * GlobalSpecs.CurrentGlobalSpecs.GetScreenHeight()) / 800;
            vlinkspic.WidthRequest = x;
            vrechtspic.WidthRequest = x;

            vlinkspic.HeightRequest = y;
            vrechtspic.HeightRequest = y;

        }
        else if (GlobalSpecs.CurrentGlobalSpecs.GetScreenWidth() < 800 && GlobalSpecs.CurrentGlobalSpecs.GetScreenWidth() < GlobalSpecs.CurrentGlobalSpecs.GetScreenHeight())
        {
            double y = (569 * GlobalSpecs.CurrentGlobalSpecs.GetScreenWidth()) / 800;
            double x = (224 * GlobalSpecs.CurrentGlobalSpecs.GetScreenWidth()) / 800;

            vlinks.WidthRequest = x;
            vrechts.WidthRequest = x;

            vlinks.HeightRequest = y;
            vrechts.HeightRequest = y;

            y = (567 * GlobalSpecs.CurrentGlobalSpecs.GetScreenWidth()) / 800;
            x = (223 * GlobalSpecs.CurrentGlobalSpecs.GetScreenWidth()) / 800;
            vlinkspic.WidthRequest = x;
            vrechtspic.WidthRequest = x;

            vlinkspic.HeightRequest = y;
            vrechtspic.HeightRequest = y;
        }
        // B_Continue.SetCursorHand();
#if WINDOWS
        B_Credits.SetCursorHand();
        B_End.SetCursorHand();
        B_Game.SetCursorHand();
        B_Replay.SetCursorHand();
        B_Settings.SetCursorHand();

        MenuButton.SetCursorHand();
#endif
        GD = GlobalData.CurrentGlobalData!;
        UIS = iuis;
#if WINDOWS
        _viewModelGeneral.InitZerogame();
#else
        _viewModelGeneral.InitZerogame();

#endif
        Stopwatch? stopwatch;
        stopwatch = new Stopwatch();
        stopwatch.Start();

        GD.OrderList!.DisableTempOrderList();
        for (int x = 0; x < 1; x++)
        {
            if( GD.Adventure != null )
                Adv.CleanupAdv(GD.Adventure);

            GD.Adventure = null;
            GD.Adventure = new Adv(true, true);
        }
        GlobalData.CurrentGlobalData!.DebugVal[0] = stopwatch.ElapsedMilliseconds;
        GD.Adventure!.Orders!.ReadSlotDescription();

        // DebugLabel.Text = GlobalData.CurrentGlobalData.DebugVal[0].ToString() + " ms";
    }
    protected override void OnSizeAllocated(double width, double height)
    {
        _viewModelGeneral.CheckSize(width, height).Wait();

        base.OnSizeAllocated(width, height);

    }

    IGlobalData.screenMode lastSM = IGlobalData.screenMode.unclear;

    public void ChangeOrientation(IGlobalData.screenMode sm )
    {
        vlinks.IsVisible = false;
        vrechts.IsVisible = false;
        Test1.Text = loca.MAUI_UI_Portrait;

        /*
        if (sm == IGlobalData.screenMode.portrait || GD.PicMode == IGlobalData.picMode.off )
        {
            vlinks.IsVisible = false;
            vrechts.IsVisible = false;
            Test1.Text = loca.MAUI_UI_Portrait;
        }
        else if (sm == IGlobalData.screenMode.landscape)
        {
            vlinks.IsVisible = true;
            vrechts.IsVisible = true;
            Test1.Text = loca.MAUI_UI_Landscape;
        }
        */
        if (sm == lastSM) return;

        lastSM = sm;
    }

    private void SetLanguage()
    {
        WindowTitle.Text = loca.MAUI_UI_Home_WindowTitle;

        // B_Continue.Text = loca.MAUI_UI_B_Continue;
        if( GD.Adventure == null )
            B_Game.Text = loca.MAUI_UI_B_Game;
        else if( GD.AskForPlayLevel == true )
            B_Game.Text = loca.MAUI_UI_B_Game;
        else
            B_Game.Text = loca.MAUI_UI_B_Continue;

        B_Settings.Text = loca.MAUI_UI_B_Settings;
        B_Replay.Text = loca.MAUI_UI_B_Replay;
        B_Credits.Text = loca.MAUI_UI_Credits;
        B_End.Text = loca.MAUI_UI_End;
        _menuExtension!.SetLanguage();
    }
    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        _viewModelGeneral.SetCallbackChangeOrientation((IGlobalData._callbackChangeOrientation) ChangeOrientation);
        base.OnNavigatedTo(args);

        await _viewModelMain.Initialize();

        _viewModelGeneral.InitResize(this.Width, this.Height);

        SetLanguage();
        _menuExtension!.QuitMethod = PressEndLocal;

        // B_Continue.Clicked += _menuExtension!.PressGame;
        B_Game.Clicked += _menuExtension!.PressGame;
        B_Settings.Clicked += _menuExtension!.PressSettings;
        B_Replay.Clicked += _menuExtension!.PressReplay;
        B_Credits.Clicked += _menuExtension!.PressCredits;
        B_End.Clicked += PressEndLocal;


        // vlinks.IsVisible = false;
        // vrechts.IsVisible = false;
        ChangeOrientation( GlobalData.CurrentGlobalData!.LayoutDescription.ScreenMode);

    }
    protected  override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        // B_Continue.Clicked += _menuExtension!.PressGame;
        B_Game.Clicked -= _menuExtension!.PressGame;
        B_Settings.Clicked -= _menuExtension!.PressSettings;
        B_Replay.Clicked -= _menuExtension!.PressReplay;
        B_Credits.Clicked -= _menuExtension!.PressCredits;
        B_End.Clicked -= PressEndLocal;


        _menuExtension!.QuitMethod = null;
    }
    public AbsoluteLayout GetAbsoluteLayout()
    {
        return AbsoluteLayer;
    }
    public Grid GetMenuGridLeft()
    {
        return MenuGridLeft;
    }
    public Grid GetMenuGridTotal()
    {
        return MenuGridTotal;
    }
    public Grid GetMenuGridMenu()
    {
        return MenuGridMenu;
    }
    public Grid? WebView_Grid()
    {
        return null;
    }
    public Grid Page_Grid()
    {
        return PageGrid;
    }
    public Button GetMenuButton()
    {
        return MenuButton;
    }
    public IUIServices? GetUIServices()
    {
        return null;
    }
    public Label GetMenuTitle()
    {
        return WindowTitle;
    }
    public void PressEndLocal(object? sender, EventArgs ea)
    {
        // bool doCont = true;
        Button? b;
        Point p3 = new();

        if (sender!.GetType() == typeof(Button))
        {
            b = (sender as Button);
            p3 = ScreenCoords.GetScreenCoords(b);
        }
        else
        {
            b = new();
        }


        p3.Y += b!.Height + 3;

        Rect pd = new();
        pd.X = (GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() / 2) - 200;
        pd.Y = (GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() / 2) - 100;
        pd.Width = 400;
        pd.Height = 200;


        pd = _menuExtension!.CalcBounds(pd);

        int val;

        if (ea.GetType() == typeof(TreeViewEventArgs))

            val = (int)((ea as TreeViewEventArgs)!.UserDefinedObject)!;
        else if (ea.GetType() == typeof(OrderTableEventArgs))
            val = (int)((ea as OrderTableEventArgs)!.UserDefinedObject)!;
        else
            val = 1;

        string Text = loca.OrderFeedback_Quit_Person_Self_13991a;

        _menuExtension!.OpenShowMenu(true, pd, true, Text);


        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            SetQuitMenu(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView);
        }
        // BlueBox.IsVisible = true;
        // AbsoluteLayout.SetLayoutBounds(BlueBox, new Rect(p3.X, p3.Y, 400, 200));
    }
    public void SetQuitMenu(Grid? contextGrid )
    {
        contextGrid!.Children.Clear();

        RowDefinitionCollection rdc = new();
        RowDefinition rd1 = new();
        rd1.Height = new GridLength(1, GridUnitType.Star);

        RowDefinition rd2 = new();
        rd2.Height = new GridLength(40);
        rdc.Add(rd1);
        rdc.Add(rd2);

        Grid? TextGrid = new();
        contextGrid.Add(TextGrid);

        List<string> LabelStyle = new();
        LabelStyle.Add("Label_Normal");

        Label l1 = new();
        l1.Text = loca.OrderFeedback_Quit_Person_Self_13991; // "Wirklich löschen?";
        l1.VerticalOptions = LayoutOptions.Center;
        l1.HorizontalOptions = LayoutOptions.Center;
        l1.HorizontalTextAlignment = TextAlignment.Center;
        TextGrid.Add(l1);
        l1.StyleClass = LabelStyle;

        contextGrid.RowDefinitions = rdc;

        Grid ButtonGrid = new();
        contextGrid.SetRow(ButtonGrid, 1);
        contextGrid.Add(ButtonGrid);
        ColumnDefinitionCollection cdc = new();
        ColumnDefinition cd1 = new();
        cd1.Width = new GridLength(1, GridUnitType.Star);
        ColumnDefinition cd2 = new();
        cd2.Width = new GridLength(4, GridUnitType.Star);
        cdc.Add(cd1);
        cdc.Add(cd2);
        cdc.Add(cd1);
        cdc.Add(cd2);
        cdc.Add(cd1);
        ButtonGrid.ColumnDefinitions = cdc;


        CreateButtonXY(ButtonGrid, loca.OrderFeedback_Quit_Person_Self_13992, 1, 1, DoQuit);
        CreateButtonXY(ButtonGrid, loca.OrderFeedback_Quit_Person_Self_13993, 3, 1, DoCancel);

    }
    public void CreateButtonXY(Grid g, string text, int xoff, int yoff, EventHandler ev)
    {
        ObjButton b = new();
        b.Text = text;
        g.Add(b);
        g.SetRow(b, yoff);
        g.SetColumn(b, xoff);
        List<string> ButtonStyle = new();
        ButtonStyle.Add("ObjButton_Invers");
        b.StyleClass = ButtonStyle;
        Thickness m = new(6, 6, 6, 0);
        b.Margin = m;
        b.Clicked += ev;
        b.VerticalOptions = LayoutOptions.Center;
        b.InputTransparent = false;

    }
    public void DoCancel(object? o, EventArgs ea)
    {
        _menuExtension!.CloseContextMenu();
    }
    public void DoQuit(object? o, EventArgs ea)
    {
        _menuExtension!.CloseContextMenu();
        UIS.QuitApplication();
        // App.ThisApplication!.Quit();
    }
}

