using static System.Net.Mime.MediaTypeNames;
using System.Windows.Input;

using Phoney_MAUI.Game.General;
using Phoney_MAUI.Core;
using Phoney_MAUI.Model;
using GameCore;

namespace Phoney_MAUI.Menu;

public partial class CreditsPage : ContentPage, IMenuExtension
{
    private readonly MainViewModel _viewModelMain;
    private readonly GeneralViewModel _viewModelGeneral;
    private readonly MenuExtension _menuExtension;
    private IUIServices UIS { get; set; }

    public CreditsPage(MainViewModel viewModelMain, GeneralViewModel viewModelGeneral, MenuExtension menuExtension, IUIServices iuis)
    {
        InitializeComponent();
        BindingContext = _viewModelMain = viewModelMain;
        _viewModelGeneral = viewModelGeneral;
        _viewModelGeneral.SetCallbackChangeOrientation((IGlobalData._callbackChangeOrientation)ChangeOrientation);
        _menuExtension = menuExtension;
        UIS = iuis;

        _menuExtension!.SetMenuExtension(GetMenuGridLeft, GetMenuGridTotal, GetMenuGridMenu, WebView_Grid, Page_Grid, GetMenuButton, GetUIServices, GetAbsoluteLayout, GetMenuTitle, nameof(CreditsPage));

        MenuButton.SetCursorHand();
    }

    protected override void OnSizeAllocated(double width, double height)
    {
         _viewModelGeneral.CheckSize(width, height).Wait();

        base.OnSizeAllocated(width, height);

    }

    public void ChangeOrientation(IGlobalData.screenMode sm)
    {
    }
    private void SetLanguage()
    {
        WindowTitle.Text = loca.MAUI_UI_Credits_WindowTitle;
        _menuExtension!.SetLanguage();

        Adv AdvGame = GlobalData.CurrentGlobalData!.Adventure!;

        string s = String.Format(loca.Order_GameInfo_1949a, AdvGame!.GD!.Version.Version1, AdvGame!.GD!.Version.Version2, AdvGame!.GD!.Version.Version3, AdvGame!.GD!.Version.VersionDate.Day, AdvGame!.GD!.Version.VersionDate.Month, AdvGame!.GD!.Version.VersionDate.Year);

        // CreditsText.Text = loca.Order_Credits_plain_1935 + loca.Order_Credits_plain_1936 + s + loca.MAUI_Phoney_Generell + loca.MAUI_Phoney_Translation + loca.MAUI_Phoney_Grafik + loca.Order_Credits_plain_1937 + loca.MAUI_Phoney_Licence;
        CreditsText.Text = loca.Order_Credits_plain_1935 + loca.Order_Credits_plain_1936 + s + loca.General_Info + loca.Order_Credits_plain_1937 + loca.MAUI_Phoney_Grafik + loca.MAUI_Phoney_Licence;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        _viewModelGeneral.SetCallbackChangeOrientation((IGlobalData._callbackChangeOrientation)ChangeOrientation);
        base.OnNavigatedTo(args);

        await _viewModelMain.Initialize();

        _viewModelGeneral.InitResize(this.Width, this.Height);

        SetLanguage();
        _menuExtension!.QuitMethod = PressEndLocal;
    }
    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        _menuExtension!.QuitMethod = null;
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
    public Button GetMenuButton()
    {
        return MenuButton;
    }
    public Grid? WebView_Grid()
    {
        return null;
    }
    public Grid Page_Grid()
    {
        return PageGri;
    }
      public Label GetMenuTitle()
    {
        return WindowTitle;
    }
    public IUIServices GetUIServices()
    {
        return UIS;
    }
    public AbsoluteLayout GetAbsoluteLayout()
    {
        return AbsoluteLayer;
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
            // int a = 5;
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

        _menuExtension!.OpenShowMenu(true, pd, false, Text);


        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            SetQuitMenu(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView!);
        }
        // BlueBox.IsVisible = true;
        // AbsoluteLayout.SetLayoutBounds(BlueBox, new Rect(p3.X, p3.Y, 400, 200));
    }
    public void SetQuitMenu(Grid contextGrid)
    {
        contextGrid.Children.Clear();

        RowDefinitionCollection rdc = new();
        RowDefinition rd1 = new();
        rd1.Height = new GridLength(1, GridUnitType.Star);

        RowDefinition rd2 = new();
        rd2.Height = new GridLength(40);
        rdc.Add(rd1);
        rdc.Add(rd2);

        Grid TextGrid = new();
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
    }
    public void DoCancel(object? o, EventArgs ea)
    {
        _menuExtension!.CloseContextMenu();
    }
    public void DoQuit(object? o, EventArgs ea)
    {
        UIS.QuitApplication();
        // App.ThisApplication!.Quit();
        _menuExtension!.CloseContextMenu();
    }
}