using Phoney_MAUI.Viewmodel;
using Phoney_MAUI;
using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Core.Platform;
using System.Windows.Input;
using Microsoft.Maui.Handlers;
#if WINDOWS
    using Microsoft.UI.Xaml.Input;
#endif
using Phoney_MAUI.Game.General;  
using Phoney_MAUI.Core;
using Phoney_MAUI.Model;
using GameCore;

using static System.Net.Mime.MediaTypeNames;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using CommunityToolkit.Maui.Media;
using System.Globalization;

namespace Phoney_MAUI.Menu;


public partial class GamePage : ContentPage, IMenuExtension
{
    
    private const double _mcGridHeight = 200;
    private const double _inputGridHeight = 60;
    private const double _headlineHeight = 50;
    private const double _paddingWidth = 20;

    private readonly GameViewModel? _viewModelGame;
    private readonly MainViewModel? _viewModelMain;
    private readonly GeneralViewModel? _viewModelGeneral;
    private readonly MenuExtension? _menuExtension;
    public ICommand? UpdateMessageCommand { get; set; }


    TabItem? TILeftUp { get; set; }
    TabItem? TILeftDown { get; set; }
    TabItem? TIRightUp { get; set; }
    TabItem? TIRightDown { get; set; }
    TabItem? TICol1_0 { get; set; }
    TabItem? TICol2_0 { get; set; }
    TabItem? TICol3_0 { get; set; }
     public GlobalData GD { get; set; }
    private IUIServices UIS { get; set; }
    private IGlobalData.screenMode lastSM;

    // private string? RecognitionText;

    // public GamePage()
    public GamePage(GameViewModel viewModelGame, MainViewModel viewModelMain, GeneralViewModel viewModelGeneral, MenuExtension menuExtension, IUIServices iuis)
    {
        try
        {
            GD = GlobalData.CurrentGlobalData!;
            GD.InitProcess = true;


            GlobalSpecs.CurrentGlobalSpecs!.InitRunning = IGlobalSpecs.initRunning.started;
            InitializeComponent();

            BindingContext = _viewModelMain = viewModelMain;
            _viewModelGeneral = viewModelGeneral;
            _viewModelGeneral.SetCallbackChangeOrientation((IGlobalData._callbackChangeOrientation)viewModelGame.ChangeOrientation);
            _viewModelGame = viewModelGame;
            _menuExtension = menuExtension;

            UIS = iuis;
            // UIS.GD = GD;
            UIS.UpdateBrowserBlocked = true;

#if WINDOWS
            SendButton.SetCursorCross();
            Button_More_Inner.SetCursorHand();
            MenuButton.SetCursorHand();

            // PB1.SetCursorHelp();
            // PB2.SetCursorHelp();
#endif

            // GD!.LayoutDescription.OrderListPos = ILayoutDescription.selectedPosition.leftUp;
            // GD!.LayoutDescription.ItemsLocListPos = ILayoutDescription.selectedPosition.leftDown;
            // GD!.LayoutDescription.ItemsInvListPos = ILayoutDescription.selectedPosition.leftUp;
#if WINDOWS
            Grid_Input_Sub.ColumnDefinitions[0].Width = new GridLength(0);
            // Grid_Input_Sub.ColumnDefinitions[1].Width = new GridLength(0);
#endif
            SetStarToAbsolute();
            // SetGamePageLayout();


            UIS.SetSetLanguage(SetLanguage);
            UIS!.SetScoreMethod(SetScore);

            _menuExtension!.SetMenuExtension(GetMenuGridLeft, GetMenuGridTotal, GetMenuGridMenu, WebView_Grid, Page_Grid, GetMenuButton, GetUIServices, GetAbsoluteLayout, GetMenuTitle, nameof(GamePage));
            UIS.ExternalGameOut = GameOut;
            // UIS.ExternalGameOut.Navigating += UIS.WebView1_Navigating;
            // UIS.ExternalGameOut.Navigated += UIS.WebView1_Navigated;

            App.CurrentPage = this;

            GD.MenuExtension = (MenuExtension)_menuExtension;

            UIS.ExternalGameOut = GameOut;
            UIS.ExternalGameOut.Navigating += UIS.WebView1_Navigating;

            WebView n = new();
            n.Navigating += UIS.WebView1_Navigating;

            GD.Adventure!.SetScoreOutput();

            // UIS.UpdateBrowser();


            // GameOutput.Source = new HtmlWebViewSource
            // {
            // Html = GlobalData._CurrentGlobalData!.WebViewContent
            // };

            // GameOutput.Source = "https://www.gmx.net/";

            UIS.UpdateBrowserBlocked = false;
            GlobalSpecs.CurrentGlobalSpecs.InitRunning = IGlobalSpecs.initRunning.finished;
        }
        catch (Exception e)
        {
        }
    }

#if WINDOWS

    bool keyUpRequest = false;
    public void GamePage_KeyUp(object? sender, KeyRoutedEventArgs ea)
    {
        keyUpRequest = false;
    }
    public  void GamePage_KeyDown(object? sender, KeyRoutedEventArgs ea )
    {
        if (keyUpRequest == true)
            return;

        if( Grid_More.IsVisible == true )
        {
            GlobalData.AddLog("PageDown by Keyboard", IGlobalData.protMode.crisp);

            UIS.Scr.PageDown();

            ea.Handled = true;
        }
        else if ( UIS.MCMVVisible == true )
        {
            int code = 48;

            switch (ea.Key)
            {
                case Windows.System.VirtualKey.Number1:
                    {
                        code = 49;
                        break;
                    }
                case Windows.System.VirtualKey.Number2:
                    {
                        code = 50;
                        break;
                    }
                case Windows.System.VirtualKey.Number3:
                    {
                        code = 51;
                        break;
                    }
                case Windows.System.VirtualKey.Number4:
                    {
                        code = 52;
                        break;
                    }
                case Windows.System.VirtualKey.Number5:
                    {
                        code = 53;
                        break;
                    }
                case Windows.System.VirtualKey.Number6:
                    {
                        code = 54;
                        break;
                    }
                case Windows.System.VirtualKey.Number7:
                    {
                        code = 55;
                        break;
                    }
                case Windows.System.VirtualKey.Number8:
                    {
                        code = 56;
                        break;
                    }
                case Windows.System.VirtualKey.Number9:
                    {
                        code = 57;
                        break;
                    }
                case Windows.System.VirtualKey.Number0:
                    {
                        code = 48;
                        break;
                    }
                case Windows.System.VirtualKey.A:
                    {
                        code = 97;
                        break;
                    }
                case Windows.System.VirtualKey.B:
                    {
                        code = 98;
                        break;
                    }
                case Windows.System.VirtualKey.C:
                    {
                        code = 99;
                        break;
                    }
                case Windows.System.VirtualKey.D:
                    {
                        code = 100;
                        break;
                    }
                case Windows.System.VirtualKey.E:
                    {
                        code = 101;
                        break;
                    }
                case Windows.System.VirtualKey.F:
                    {
                        code = 102;
                        break;
                    }
                case Windows.System.VirtualKey.G:
                    {
                        code = 103;
                        break;
                    }
                case Windows.System.VirtualKey.H:
                    {
                        code = 104;
                        break;
                    }
                case Windows.System.VirtualKey.I:
                    {
                        code = 105;
                        break;
                    }
                case Windows.System.VirtualKey.J:
                    {
                        code = 106;
                        break;
                    }
                case Windows.System.VirtualKey.K:
                    {
                        code = 107;
                        break;
                    }
                case Windows.System.VirtualKey.L:
                    {
                        code = 108;
                        break;
                    }
                case Windows.System.VirtualKey.M:
                    {
                        code = 109;
                        break;
                    }
                case Windows.System.VirtualKey.N:
                    {
                        code = 110;
                        break;
                    }
                case Windows.System.VirtualKey.O:
                    {
                        code = 111;
                        break;
                    }
                case Windows.System.VirtualKey.P:
                    {
                        code = 112;
                        break;
                    }
                case Windows.System.VirtualKey.Q:
                    {
                        code = 113;
                        break;
                    }
                case Windows.System.VirtualKey.R:
                    {
                        code = 114;
                        break;
                    }
                case Windows.System.VirtualKey.S:
                    {
                        code = 115;
                        break;
                    }
                case Windows.System.VirtualKey.T:
                    {
                        code = 116;
                        break;
                    }
                case Windows.System.VirtualKey.U:
                    {
                        code = 117;
                        break;
                    }
                case Windows.System.VirtualKey.V:
                    {
                        code = 118;
                        break;
                    }
                case Windows.System.VirtualKey.W:
                    {
                        code = 119;
                        break;
                    }
                case Windows.System.VirtualKey.X:
                    {
                        code = 120;
                        break;
                    }
                case Windows.System.VirtualKey.Y:
                    {
                        code = 121;
                        break;
                    }
                case Windows.System.VirtualKey.Z:
                    {
                        code = 122;
                        break;
                    }
            }

            int ix = 0;
            bool found = false;
            for( ix = 0; ix < UIS.MCM!.Current!.Count; ix++)
            {
                if(UIS.MCM.Current[ix] > 0)
                {
                    MCMenuEntry? me = UIS.MCM.FindID(UIS.MCM.Current[ix]);
                    if (me!.Keys!.Count > 0)
                    {
                        if (me.Keys[0] == (int)code && me.Hidden == MCMenuEntry.HiddenType.visible)
                        {
                            UIS.MCMV!.CallBackMCMenuView(me.ID);
                            found = true;
                        }
                    }

                }
                if( found )
                    break;
            }

            /*
            foreach (MCMenuEntry me in UIS.MCM!List)
            {
                if (me.Keys.Count > 0)
                {
                    if (me.Keys[0] == (int)code && me.Hidden == MCMenuEntry.HiddenType.visible )
                    {
                        UIS.MCMV!.CallBackMCMenuView(me.ID);
                        break;
                    }
                }
            }
            */
            ea.Handled = true;
        }
        else
        {
            if (ea.Key == Windows.System.VirtualKey.Up)
            {
                if (GD!.Adventure!.LatestInputPt > 0)
                {
                    if (GD!.Adventure!.LatestInputPt > GD!.Adventure!.LI.Count)
                        GD!.Adventure!.LatestInputPt = GD!.Adventure!.LI.Count;

                    if (GD!.Adventure!.LatestInputPt == GD!.Adventure!.LI.Count)
                    {
                        GD!.Adventure!.tLastParseString = Inputline.Text;
                    }
                    else
                    {
                        GD!.Adventure!.LI[GD!.Adventure!.LatestInputPt].Text = Inputline.Text;
                    }

                        GD!.Adventure!.LatestInputPt--;
                    Inputline.Text = GD!.Adventure!.LI[GD!.Adventure!.LatestInputPt].Text;
                     // Inputline.Select(Inputline.Text.Length, 0);
                }
                else
                {
                    GD!.Adventure!.LatestInputPt = GD!.Adventure!.LI.Count;
                    Inputline.Text = GD!.Adventure!.tLastParseString;
                }
            }
            if (ea.Key == Windows.System.VirtualKey.Down)
            {
                // UIS.Scr.PageDown();
                if(GD!.Adventure!.LatestInputPt <= 0 )
                {

                }
                else if (GD!.Adventure!.LatestInputPt < GD!.Adventure!.LI.Count)
                {
                    GD!.Adventure!.LI[GD!.Adventure!.LatestInputPt].Text = Inputline.Text;
                    GD!.Adventure!.LatestInputPt++;


                    if (GD!.Adventure!.LatestInputPt == GD!.Adventure!.LI.Count)
                    {
                        Inputline.Text = GD!.Adventure!.tLastParseString;
                    }
                    else
                    {
                        Inputline.Text = GD!.Adventure!.LI[GD!.Adventure!.LatestInputPt].Text;
                    }
                    // Inputline.Select(Inputline.Text.Length, 0);
                }
                else
                {
                    GD!.Adventure!.LatestInputPt = 0;
                    Inputline.Text = GD!.Adventure!.LI[GD!.Adventure!.LatestInputPt].Text;

                }
            }
            Inputline.Focus();
        }
        keyUpRequest = true;
    }

    public void ResetKeyboardHandler()
    {
        var handler = CurrentPage.Handler;
        handler = PageGrid.Handler;
        Microsoft.UI.Xaml.UIElement? nativeView;
        nativeView = handler?.PlatformView as Microsoft.UI.Xaml.UIElement;
        if (nativeView != null)
        {
            nativeView.KeyUp -= this.GamePage_KeyUp;
            nativeView.KeyDown -= this.GamePage_KeyDown;
        }

    }
    public void SetupKeyboardHandler()
    {
        var handler = this.Handler;
        Microsoft.UI.Xaml.UIElement? nativeView;
        /*
          Microsoft.UI.Xaml.UIElement? nativeView = handler?.PlatformView as Microsoft.UI.Xaml.UIElement;
          if (nativeView != null)
          {
              nativeView.KeyDown += this.GamePage_KeyDown;
              // nativeView.KeyUp += this.PlatformView_KeyUp;
              // nativeView.PreviewKeyDown += this.PlatformView_PreviewKeyDown;
          }


          handler = GameOut.Handler;
          // Microsoft.UI.Xaml.UIElement? 
          nativeView = handler?.PlatformView as Microsoft.UI.Xaml.UIElement;
          if (nativeView != null)
          {
              nativeView.KeyDown += this.GamePage_KeyDown;
              // nativeView.KeyUp += this.PlatformView_KeyUp;
              // nativeView.PreviewKeyDown += this.PlatformView_PreviewKeyDown;
          }
          */


        handler = this.Handler;
        // Microsoft.UI.Xaml.UIElement? 
        nativeView = handler?.PlatformView as Microsoft.UI.Xaml.UIElement;
        if (nativeView != null)
        {
            nativeView.KeyDown += this.GamePage_KeyDown;
            nativeView.KeyUp += this.GamePage_KeyUp;
            // nativeView.KeyUp += this.PlatformView_KeyUp;
            // nativeView.PreviewKeyDown += this.PlatformView_PreviewKeyDown;
        }
        /*
        handler = ToplineGrid.Handler;
        if (nativeView != null)
        {
            nativeView.KeyDown += this.GamePage_KeyDown;
            // nativeView.KeyUp += this.PlatformView_KeyUp;
            // nativeView.PreviewKeyDown += this.PlatformView_PreviewKeyDown;
        }

        handler = Grid_More.Handler;
        if (nativeView != null)
        {
            nativeView.KeyDown += this.GamePage_KeyDown;
            // nativeView.KeyUp += this.PlatformView_KeyUp;
            // nativeView.PreviewKeyDown += this.PlatformView_PreviewKeyDown;
        }
        */
    }
#endif

    public bool SetInputFocus()
    {
#if WINDOWS
        Inputline.Focus();
#endif
        return true;
    }
    public bool SetMoreFocus()
    {
#if WINDOWS
        Inputline.Focus();
#endif
        return true;
    }
    public void ForceInputFocus()
    {
        Inputline.Focus();
    }

    public void AdaptGridHeights()
    {
        // Mike.FontSize = 25;
        // Mike.FontSize = 25;

        RowDefinitionCollection rdc = Grid_Output.RowDefinitions;
        GridWebView.HeightRequest = rdc[0].Height.Value;
        Grid_Inter.HeightRequest = rdc[2].Height.Value;
        GameOut.HeightRequest = rdc[0].Height.Value;

        GridWebView.RowDefinitions[0].Height = rdc[0].Height;

        double gesHeightOutIn = rdc[0].Height.Value + rdc[1].Height.Value + rdc[2].Height.Value;
        double gesHeightOutInMC = gesHeightOutIn;

        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;

        if (GlobalData.CurrentGlobalData!.LayoutDescription.ScreenMode == IGlobalData.screenMode.portrait && IsPortraitColVisible(0))
            gesHeightOutInMC += ld.PortraitColumnsHeight;


        Grid_Output.HeightRequest = gesHeightOutIn;

        MenuGridMenuVertical.HeightRequest = gesHeightOutInMC;  // PageGrid.Height - 40;
        MenuGridMenuVertical.RowDefinitions[0].Height = new GridLength(gesHeightOutIn);
        MenuGridMenu.HeightRequest = gesHeightOutInMC;
        MenuGridMenu.RowDefinitions[0].Height = new GridLength(gesHeightOutInMC);
        // MenuGridMenuBackground.HeightRequest = gesHeightOutIn + Grid_Inter.HeightRequest;
        // MenuGridMenuBackground.RowDefinitions[1].Height = new GridLength(gesHeightOutIn + Grid_Inter.HeightRequest);
        MenuGridMenuBackground.HeightRequest = gesHeightOutInMC;
        MenuGridMenuBackground.RowDefinitions[1].Height = new GridLength(gesHeightOutInMC);


        MGM0.HeightRequest = PageGrid.Height - 40;
        MenuGridMenuInner.HeightRequest = gesHeightOutIn;
        /*
        if ( UIS != null && UIS.Scr != null )
        {
            UIS.Scr.HTMLViewHeight = rdc[2].Height.Value;
        }
        */
    }
    public bool SetMCOnHeight()
    {
        RowDefinitionCollection rdc = Grid_Output.RowDefinitions;
        double ylen = _mcGridHeight - rdc[2].Height.Value;

        // _mcGridHeight = new GridLength( 300 );

        /*
        rdc[0].Height = new GridLength(Grid_Output.Height - _mcGridHeight);
        rdc[2].Height = new GridLength(_mcGridHeight);
        */
        rdc[0].Height = new GridLength(rdc[0].Height.Value - ylen);
        rdc[2].Height = new GridLength(rdc[2].Height.Value + ylen);

        AdaptGridHeights();

        _menuExtension!.RemoveListCall(SetMCOnHeight);
        /*
          bool stopExpansion = false;

          RowDefinitionCollection rdc = Grid_Output.RowDefinitions;

          double ylen = 10;

          if(rdc[2].Height.Value + ylen > _mcGridHeight)
          {
              ylen = _mcGridHeight - rdc[2].Height.Value;
              stopExpansion = true;
          }
          rdc[0].Height = new GridLength(rdc[0].Height.Value - ylen);
          rdc[2].Height = new GridLength(rdc[2].Height.Value + ylen);

          if( stopExpansion)
          {
              _menuExtension.RemoveListCall(SetMCOnHeight);
          }
          */
        /*
        Device.BeginInvokeOnMainThread(SetMCOnHeightMT);
        */
        return true;
    }
    public bool SetMCOffHeight()
    {
        RowDefinitionCollection rdc = Grid_Output.RowDefinitions;
        double ylen = _inputGridHeight - rdc[2].Height.Value;

        // rdc[0].Height = new GridLength(Grid_Output.Height - _inputGridHeight);
        // rdc[2].Height = new GridLength(_inputGridHeight);

        rdc[0].Height = new GridLength(rdc[0].Height.Value - ylen);
        rdc[2].Height = new GridLength(rdc[2].Height.Value + ylen);
        AdaptGridHeights();
        // UIS!.FinishBrowserUpdate();
        return true;
    }
    public Grid? ProvideMCGrid( bool Activate, int Height )
    {
        Grid? mcMenuGrid = null;
        if( Activate == true )
        {
            Grid_Input.IsVisible = false;
            Grid_More.IsVisible = false;
            Grid_MC.IsVisible = true;
            RowDefinitionCollection rdc = Grid_Output.RowDefinitions;

            if (rdc[0].Height.IsAbsolute)
            {

                _menuExtension!.ListCalls.Add( new ListCall( SetMCOnHeight, -1 ) );
                // Test: Grid

                // double xlen = 200 - rdc[2].Height.Value;
                // rdc[0].Height = new GridLength(rdc[0].Height.Value - xlen);
                // rdc[2].Height = new GridLength(rdc[2].Height.Value + xlen);
            }
            mcMenuGrid = Grid_MC_Inner;
        }
        else
        {
            Grid_Input.IsVisible = true;
            Grid_More.IsVisible = false;
            Grid_MC.IsVisible = false;
            RowDefinitionCollection rdc = Grid_Output.RowDefinitions;

            if (rdc[0].Height.IsAbsolute)
            {
                _menuExtension!.ListCalls.Add(new ListCall(SetMCOffHeight, 0) );
                // Test: Grid

            }
            SetInputFocus();

        }
        return mcMenuGrid;
    }
    public Grid ProvideMoreGrid(bool Activate, int Height)
    {
        return Grid_More;
    }

    public void SelectOutput(ILayoutDescription.selectedOutput output )
    {
        if( output == ILayoutDescription.selectedOutput.input && Grid_Input.IsVisible == false )
        {
            Grid_Input.IsVisible = true;
            Grid_More.IsVisible = false;
            Grid_MC.IsVisible = false;
            RowDefinitionCollection rdc = Grid_Output.RowDefinitions;

            if (rdc[0].Height.IsAbsolute)
            {
                double xlen = 50 - rdc[2].Height.Value;
                rdc[0].Height = new GridLength(rdc[0].Height.Value - xlen);
                rdc[2].Height = new GridLength(rdc[2].Height.Value + xlen);
                AdaptGridHeights();
            }
            // rdc[2].Height = 50;

        }
        else if ( output == ILayoutDescription.selectedOutput.mc && Grid_MC.IsVisible == false )
        {
            Grid_Input.IsVisible = false;
            Grid_More.IsVisible = false;
            Grid_MC.IsVisible = true;
            RowDefinitionCollection rdc = Grid_Output.RowDefinitions;

            if (rdc[0].Height.IsAbsolute)
            {

                double xlen = 200 - rdc[2].Height.Value;
                rdc[0].Height = new GridLength(rdc[0].Height.Value - xlen);
                rdc[2].Height = new GridLength(rdc[2].Height.Value + xlen);
                AdaptGridHeights();
            }
            // rdc[2].Height = 200;

        }
        else if ( output == ILayoutDescription.selectedOutput.more && Grid_More.IsVisible == false)
        {
            Grid_Input.IsVisible = false;
            Grid_More.IsVisible = true;
            Grid_MC.IsVisible = false;
            RowDefinitionCollection rdc = Grid_Output.RowDefinitions;

            if (rdc[0].Height.IsAbsolute)
            {
                double xlen = 50 - rdc[2].Height.Value;
                rdc[0].Height = new GridLength(rdc[0].Height.Value - xlen);
                rdc[2].Height = new GridLength(rdc[2].Height.Value + xlen);
                AdaptGridHeights();
            }
            // rdc[2].Height = 50;
            Grid_More.Focus();
        }
    }


     protected override void OnSizeAllocated(double width, double height)
     {
        _viewModelGeneral!.CheckSize(width, height).Wait();

        if (AbsoluteLayer.InputTransparent == false)
         {
             int ix = 0;
             for (ix = 0; ix < AbsoluteLayer.Children.Count; ix++)
             {
                 View v = (View) AbsoluteLayer.Children[ix];
                 if (v != BlueBox)
                 {
                     AbsoluteLayer.Remove(v);
                     ix--;
                 }
             }

            // AbsoluteLayer.Remove(gridx);
             // AbsoluteLayer.Remove(f);
             AbsoluteLayer.InputTransparent = true;
         }

         LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
         if (ld.PortraitColumn1Width > 0)
         {
             int ctColumns = 0;
             if (ld.PortraitColumns[0,0] != ILayoutDescription.PortraitColumn.none || ld.PortraitColumns[0, 1] != ILayoutDescription.PortraitColumn.none || ld.PortraitColumns[0, 2] != ILayoutDescription.PortraitColumn.none)
                ctColumns++;
             if (ld.PortraitColumns[1,0] != ILayoutDescription.PortraitColumn.none || ld.PortraitColumns[1, 1] != ILayoutDescription.PortraitColumn.none || ld.PortraitColumns[1, 2] != ILayoutDescription.PortraitColumn.none)
                ctColumns++;
             if (ld.PortraitColumns[2,0] != ILayoutDescription.PortraitColumn.none || ld.PortraitColumns[2, 1] != ILayoutDescription.PortraitColumn.none || ld.PortraitColumns[2, 2] != ILayoutDescription.PortraitColumn.none)
                ctColumns++;


             if (ctColumns == 3)
             {
                 double totalWidth = ld.PortraitColumn1Width + ld.PortraitColumn2Width + ld.PortraitColumn3Width + _paddingWidth;
                 if (totalWidth != width)
                 {
                     double scale = width/ totalWidth;
                     ld.PortraitColumn1Width *= scale;
                     ld.PortraitColumn2Width *= scale;
                     ld.PortraitColumn3Width *= scale;
                 }
             }
             else if (ctColumns == 2)
             {
                 double totalWidth = ld.PortraitColumn1Width + ld.PortraitColumn2Width;
                 if (totalWidth != width)
                 {
                     double scale = width / totalWidth;
                     ld.PortraitColumn1Width *= scale;
                     ld.PortraitColumn2Width *= scale;
                 }

            }
             else if (ctColumns == 1)
             {
                 double totalWidth = ld.PortraitColumn1Width ;
                 if (totalWidth != width)
                 {
                     ld.PortraitColumn1Width = width;
                 }

             }
        }


        if (width > height && GlobalData.CurrentGlobalData!.LayoutDescription.ScreenMode != IGlobalData.screenMode.landscape)
        {
             GlobalData.CurrentGlobalData!.LayoutDescription.ScreenMode = IGlobalData.screenMode.landscape;
            ChangeOrientation(IGlobalData.screenMode.landscape );
         }
         else if (width < height && GlobalData.CurrentGlobalData!.LayoutDescription.ScreenMode != IGlobalData.screenMode.portrait)
         {
            GlobalData.CurrentGlobalData!.LayoutDescription.ScreenMode = IGlobalData.screenMode.portrait;
             ChangeOrientation(IGlobalData.screenMode.portrait);

         }
         else
         {
             SetGamePageLayout();

        }

        base.OnSizeAllocated(width, height);
        /*
        if (MenuGridMenuInner.ColumnDefinitions[0].Width.IsAbsolute == false && Grid_MC_Left.Width > 0)
        {
            SetStarToAbsolute();
        }

        if (Grid_MC_Left.Width > 0)
        {
            double widthOld = MenuGridMenuInner.ColumnDefinitions[0].Width.Value + MenuGridMenuInner.ColumnDefinitions[2].Width.Value + MenuGridMenuInner.ColumnDefinitions[4].Width.Value;

            double widthNew = width - MenuGridMenuInner.ColumnDefinitions[1].Width.Value - MenuGridMenuInner.ColumnDefinitions[3].Width.Value;

            double x1 = Math.Round((MenuGridMenuInner.ColumnDefinitions[0].Width.Value * widthNew) / widthOld);
            double x3 = Math.Round((MenuGridMenuInner.ColumnDefinitions[2].Width.Value * widthNew) / widthOld);
            double x5 = Math.Round((MenuGridMenuInner.ColumnDefinitions[4].Width.Value * widthNew) / widthOld);

            try
            {
                MenuGridMenuInner.ColumnDefinitions[0].Width = new GridLength(x1);
                MenuGridMenuInner.ColumnDefinitions[2].Width = new GridLength(x3);
                MenuGridMenuInner.ColumnDefinitions[4].Width = new GridLength(x5);
            }
            catch( Exception e)
            {
                int a = 5;
            }
        }
        */

    }


    public bool GetLeftColumnActive()
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription;
        return ld.LU_Order || ld.LU_ItemLoc || ld.LU_ItemInv || ld.LD_Order || ld.LD_ItemLoc || ld.LD_ItemInv;
    }
    public bool GetLUActive()
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription;
        return ld.LU_Order || ld.LU_ItemLoc || ld.LU_ItemInv ;
    }
    public bool GetLDActive()
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription;
        return ld.LD_Order || ld.LD_ItemLoc || ld.LD_ItemInv;
    }
    public bool GetRightColumnActive()
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription;
        return ld.RU_Order || ld.RU_ItemLoc || ld.RU_ItemInv || ld.RD_Order || ld.RD_ItemLoc || ld.RD_ItemInv;
    }
    public bool GetRUActive()
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription;
        return ld.RU_Order || ld.RU_ItemLoc || ld.RU_ItemInv;
    }
    public bool GetRDActive()
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription;
        return ld.RD_Order || ld.RD_ItemLoc || ld.RD_ItemInv;
    }

    private EmptyTreeView? EmptyTreeOrderOld { get; set; }
    private EmptyTreeView? EmptyTreeOrderNew { get; set; }
    private EmptyTreeView? EmptyTreeItemInvOld { get; set; }
    private EmptyTreeView? EmptyTreeItemInvNew { get; set; }
    private EmptyTreeView? EmptyTreeItemLocOld { get; set; }
    private EmptyTreeView? EmptyTreeItemLocNew { get; set; }

    bool CompareEmptyTreeViews(EmptyTreeViewItem tv1, EmptyTreeViewItem tv2)
    {
        bool identical = true;

        if (tv1.ID != tv2.ID)
        {
            identical = false;
        }
        else
        {
            int ix;
            if (tv1.Children.Count > 0)
            {
                for (ix = 0; ix < tv1.Children.Count; ix++)
                {
                    if (tv1.Children.Count != tv2.Children.Count)
                    {
                        identical = false;
                        break;
                    }
                    else if (CompareEmptyTreeViews(tv1.Children[ix], tv2.Children[ix]) == false)
                    {
                        identical = false;
                        break;
                    }
                }
            }
            else if (tv2.Children.Count > 0)
            {
                identical = false;

            }
        }
        return identical;
    }
    // int count = 0;

    bool OrderTreeHasInitialized = false;
    bool ItemInvTreeHasInitialized = false;
    bool ItemLocTreeHasInitialized = false;

    public bool IsPortraitVisible()
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription;
        bool visible = false;

        for(int ix = 0; ix < 3; ix++)
        {
            for(int ix2 = 0; ix2 < 3; ix2++)
            {
                if (ld.PortraitColumns[ix, ix2] != ILayoutDescription.PortraitColumn.none)
                {
                    visible = true;
                    break;
                }
            }
        }
        return visible;
    }
    public bool IsPortraitColVisible( int col )
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription;
        bool visible = false;

        for (int ix2 = 0; ix2 < 3; ix2++)
        {
            if (ld.PortraitColumns[col, ix2] != ILayoutDescription.PortraitColumn.none)
            {
                visible = true;
                break;
            }
        }
        return visible;
    }

    public void SetPortraitGridDimensions()
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription;
        MenuGridMenuInner.ColumnDefinitions[0].Width = new GridLength(0);
        MenuGridMenuInner.ColumnDefinitions[1].Width = new GridLength(0);

        double x = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth;
        
        // RotateProblem
        MenuGridMenuInner.ColumnDefinitions[2].Width = new GridLength(x);
        /*
        MenuGridMenu.ColumnDefinitions[1].Width = new GridLength(x );
        Grid_Output.WidthRequest = x;
        GameOut.WidthRequest = x;
        MenuGridMenuInner.WidthRequest = x;
        MenuGridMenu.WidthRequest = x;
        MenuGridTotal.ColumnDefinitions[1].Width = new GridLength(x);
        */

        MenuGridMenuInner.ColumnDefinitions[3].Width = new GridLength(0);
        MenuGridMenuInner.ColumnDefinitions[4].Width = new GridLength(0);

        if ( IsPortraitVisible() )
        {
            MenuGridMenuVertical.RowDefinitions[0].Height = new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - ld.PortraitColumnsHeight - PageGrid.RowDefinitions[0].Height.Value - 10);
            MenuGridMenuVertical.RowDefinitions[1].Height = new GridLength(10);
            MenuGridMenuVertical.RowDefinitions[2].Height = new GridLength(ld.PortraitColumnsHeight);
            PageGrid.RowDefinitions[2].Height = new GridLength(MenuGridMenuVertical.RowDefinitions[0].Height.Value + MenuGridMenuVertical.RowDefinitions[2].Height.Value);
            Grid_Output.RowDefinitions[0].Height = new GridLength(MenuGridMenuVertical.RowDefinitions[0].Height.Value - Grid_Output.RowDefinitions[2].Height.Value);
            AdaptGridHeights();
            // Grid_Output.RowDefinitions[2].Height = new GridLength( 50 ) ;


            double xLen = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth;

            // Nur 1 Spalte?
            if (!IsPortraitColVisible(1) ) 
            {
                OrderItemGrid.ColumnDefinitions[0].Width = new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth);
                OrderItemGrid.ColumnDefinitions[1].Width = 0;
                OrderItemGrid.ColumnDefinitions[2].Width = 0;
                OrderItemGrid.ColumnDefinitions[3].Width = 0;
                OrderItemGrid.ColumnDefinitions[4].Width = 0;
            }
            else if (!IsPortraitColVisible(2))
            {
                if (ld.PortraitColumn1Width + 10 > xLen)
                {
                    ld.PortraitColumn1Width = (xLen - 10) / 2;

                }


                OrderItemGrid.ColumnDefinitions[0].Width = new GridLength(ld.PortraitColumn1Width);
                xLen -= ld.PortraitColumn1Width;
                OrderItemGrid.ColumnDefinitions[1].Width = 10;
                xLen -= 10;
                OrderItemGrid.ColumnDefinitions[2].Width = new GridLength(xLen);
                OrderItemGrid.ColumnDefinitions[3].Width = 0;
                OrderItemGrid.ColumnDefinitions[4].Width = 0;

            }
            else
            {
                if (ld.PortraitColumn1Width + ld.PortraitColumn2Width + 20 > xLen)
                {
                    ld.PortraitColumn1Width = (xLen - 20) / 3;
                    ld.PortraitColumn2Width = (xLen - 20) / 3;

                }

                OrderItemGrid.ColumnDefinitions[0].Width = new GridLength(ld.PortraitColumn1Width);
                xLen -= ld.PortraitColumn1Width;
                OrderItemGrid.ColumnDefinitions[1].Width = 10;
                xLen -= 10;
                OrderItemGrid.ColumnDefinitions[2].Width = new GridLength(ld.PortraitColumn2Width);
                xLen -= ld.PortraitColumn2Width;
                OrderItemGrid.ColumnDefinitions[3].Width = 10;
                xLen -= 10;
                OrderItemGrid.ColumnDefinitions[4].Width = new GridLength(xLen);

            }
        }
        else
        {
            MenuGridMenuVertical.RowDefinitions[0].Height = new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - PageGrid.RowDefinitions[0].Height.Value - 10);
            MenuGridMenuVertical.RowDefinitions[2].Height = new GridLength(0);
            PageGrid.RowDefinitions[2].Height = new GridLength(MenuGridMenuVertical.RowDefinitions[0].Height.Value + MenuGridMenuVertical.RowDefinitions[2].Height.Value);

            Grid_Output.RowDefinitions[0].Height = new GridLength(MenuGridMenuVertical.RowDefinitions[0].Height.Value - Grid_Output.RowDefinitions[2].Height.Value);
            AdaptGridHeights();

        }

    }

    public bool SetGamePageLayout()
    {
        if (GlobalSpecs.CurrentGlobalSpecs!.InitRunning == IGlobalSpecs.initRunning.started)
            return false;

        UIS.AddUICycle();
        return true;
    }

    bool gplUpdate = false;

    public bool ExecuteGamePageLayout()
    {
        if (gplUpdate == true)
        {
            return false;
        }

        if( MainThread.IsMainThread == false )
        {
            return false;
        }

        gplUpdate = true;

        if (GlobalSpecs.CurrentGlobalSpecs!.InitRunning == IGlobalSpecs.initRunning.started)
        {
            gplUpdate = false;
            return false;
        }

        try
        {

            GlobalSpecs.CurrentGlobalSpecs.CheckSize(GlobalSpecs.CurrentGlobalSpecs.GetScreenWidth(), GlobalSpecs.CurrentGlobalSpecs.GetScreenHeight());
            // count++;
            // if (count > 3)
            // return true;


            /* Wird das wom�glich doch gebraucht? Soweit ich das sehe, frisst es einfach nur Rechenzeit auf 
            if (GD != null && GD.Adventure != null)
            {
                GD.Adventure!.SetScoreOutput();
            }
            */

            // Initialisierung der Flaglogik, welche Men�s alles aktiv sein m�ssten
            LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription;

            int LDCount = -1;
            int LUCount = -1;
            int RDCount = -1;
            int RUCount = -1;

            int LDPos = -1;
            int LUPos = -1;
            int RDPos = -1;
            int RUPos = -1;

            // Einmalig f�r Horizontal. Wenn die 4 Grids noch nicht mit den TabItems best�ck sind, dann werden diese hier angelegt.
            if (GridLU.Children.Count == 0)
            {
                TILeftUp = new TabItem();
                TILeftUp.AddTabButtonStyleSelected("IDButton_Edge");
                TILeftUp.AddTabButtonStyleUnselected("IDButton_Invers_Edge");
                TILeftUp.AddHeadlineStyle("Grid_BGBG");
                TILeftUp.AddMainPanelStyle("Grid_BGBG");

                TabItem.TabPanel tp = TILeftUp.AddTabPanel(FaSolid.Wrench, 1);
                tp.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp.SelectButton);

                TabItem.TabPanel tp2 = TILeftUp.AddTabPanel(FaSolid.MapMarkerAlt, 2);
                tp2.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp2.SelectButton);

                TabItem.TabPanel tp3 = TILeftUp.AddTabPanel(FaSolid.Suitcase, 3);
                tp3.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp3.SelectButton);

                LUPos = 0;
                GridLU.Add(TILeftUp);
                TILeftUp.SelectedTabPanel = LUPos;
                TILeftUp.SyncTabStyles();
            }

            if (GridLD.Children.Count == 0)
            {
                TILeftDown = new TabItem();
                TILeftDown.AddTabButtonStyleSelected("IDButton");
                TILeftDown.AddTabButtonStyleUnselected("IDButton_Invers");
                TILeftDown.AddHeadlineStyle("Grid_BGBG");
                TILeftDown.AddMainPanelStyle("Grid_BGBG");

                TabItem.TabPanel tp = TILeftDown.AddTabPanel(FaSolid.Wrench, 1);
                tp.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp.SelectButton);

                TabItem.TabPanel tp2 = TILeftDown.AddTabPanel(FaSolid.MapMarkerAlt, 2);
                tp2.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp2.SelectButton);

                TabItem.TabPanel tp3 = TILeftDown.AddTabPanel(FaSolid.Suitcase, 3);
                tp3.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp3.SelectButton);

                LDPos = 0;
                GridLD.Add(TILeftDown);
                TILeftDown.SelectedTabPanel = LDPos;
                TILeftDown.SyncTabStyles();
            }

            if (GridRU.Children.Count == 0)
            {
                TIRightUp = new TabItem();
                TIRightUp.AddTabButtonStyleSelected("IDButton");
                TIRightUp.AddTabButtonStyleUnselected("IDButton_Invers");
                TIRightUp.AddHeadlineStyle("Grid_BGBG");
                TIRightUp.AddMainPanelStyle("Grid_BGBG");

                TabItem.TabPanel tp = TIRightUp.AddTabPanel(FaSolid.Wrench, 1);
                tp.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp.SelectButton);

                TabItem.TabPanel tp2 = TIRightUp.AddTabPanel(FaSolid.MapMarkerAlt, 2);
                tp2.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp2.SelectButton);

                TabItem.TabPanel tp3 = TIRightUp.AddTabPanel(FaSolid.Suitcase, 3);
                tp3.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp3.SelectButton);

                RUPos = 0;
                GridRU.Add(TIRightUp);
                TIRightUp.SelectedTabPanel = RUPos;
                TIRightUp.SyncTabStyles();
            }
            if (GridRD.Children.Count == 0)
            {
                TIRightDown = new TabItem();
                TIRightDown.AddTabButtonStyleSelected("IDButton");
                TIRightDown.AddTabButtonStyleUnselected("IDButton_Invers");
                TIRightDown.AddHeadlineStyle("Grid_BGBG");
                TIRightDown.AddMainPanelStyle("Grid_BGBG");

                TabItem.TabPanel tp = TIRightDown.AddTabPanel(FaSolid.Wrench, 1);
                tp.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp.SelectButton);

                TabItem.TabPanel tp2 = TIRightDown.AddTabPanel(FaSolid.MapMarkerAlt, 2);
                tp2.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp2.SelectButton);

                TabItem.TabPanel tp3 = TIRightDown.AddTabPanel(FaSolid.Suitcase, 3);
                tp3.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp3.SelectButton);

                RDPos = 0;
                GridRD.Add(TIRightDown);
                TIRightDown.SelectedTabPanel = RDPos;
                TIRightDown.SyncTabStyles();
            }

            // Einmalig f�r Vertical. Wenn die 3 Grids noch nicht mit den TabItems best�ck sind, dann werden diese hier angelegt.
            if (PortraitCol1.Children.Count == 0)
            {
                TICol1_0 = new TabItem();
                TICol1_0.AddTabButtonStyleSelected("IDButton");
                TICol1_0.AddTabButtonStyleUnselected("IDButton_Invers");
                TICol1_0.AddHeadlineStyle("Grid_BGBG");
                TICol1_0.AddMainPanelStyle("Grid_Normal");

                TabItem.TabPanel tp = TICol1_0.AddTabPanel(FaSolid.Wrench, 1);
                tp.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp.SelectButton);

                TabItem.TabPanel tp1 = TICol1_0.AddTabPanel(FaSolid.MapMarkedAlt, 2);
                tp1.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp1.SelectButton);

                TabItem.TabPanel tp2 = TICol1_0.AddTabPanel(FaSolid.Suitcase, 3);
                tp2.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp2.SelectButton);

                PortraitCol1.Add(TICol1_0);
                TICol1_0.SelectedTabPanel = 0;
                TICol1_0.SyncTabStyles();
            }

            if (PortraitCol2.Children.Count == 0)
            {
                TICol2_0 = new TabItem();
                TICol2_0.AddTabButtonStyleSelected("IDButton");
                TICol2_0.AddTabButtonStyleUnselected("IDButton_Invers");
                TICol2_0.AddHeadlineStyle("Grid_BGBG");
                TICol2_0.AddMainPanelStyle("Grid_Normal");

                TabItem.TabPanel tp = TICol2_0.AddTabPanel(FaSolid.Wrench, 1);
                tp.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp.SelectButton);

                TabItem.TabPanel tp1 = TICol2_0.AddTabPanel(FaSolid.MapMarkedAlt, 1);
                tp1.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp1.SelectButton);

                TabItem.TabPanel tp2 = TICol2_0.AddTabPanel(FaSolid.Suitcase, 1);
                tp2.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp2.SelectButton);

                PortraitCol2.Children.Add(TICol2_0);
                TICol2_0.SelectedTabPanel = 0;
                TICol2_0.SyncTabStyles();
            }
            if (PortraitCol3.Children.Count == 0)
            {
                TICol3_0 = new TabItem();
                TICol3_0.AddTabButtonStyleSelected("IDButton");
                TICol3_0.AddTabButtonStyleUnselected("IDButton_Invers");
                TICol3_0.AddHeadlineStyle("Grid_BGBG");
                TICol3_0.AddMainPanelStyle("Grid_Normal");

                TabItem.TabPanel tp = TICol3_0.AddTabPanel(FaSolid.Wrench, 1);
                tp.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp.SelectButton);

                TabItem.TabPanel tp1 = TICol3_0.AddTabPanel(FaSolid.MapMarkedAlt, 1);
                tp1.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp1.SelectButton);

                TabItem.TabPanel tp2 = TICol3_0.AddTabPanel(FaSolid.Suitcase, 1);
                tp2.SelectButton!.FontFamily = "Fa-Solid";
                SetButtonCursorHand(tp2.SelectButton);

                PortraitCol3.Children.Add(TICol3_0);
                TICol3_0.SelectedTabPanel = 0;
                TICol3_0.SyncTabStyles();
            }

            if (GridLU.Children.Count > 0)
            {
                TabItem? ti = (GridLU.Children[0] as TabItem)!;
                ti.CalcTabPanel();
                LUPos = ti!.SelectedTabPanel;
                LUCount = ti.Count;
            }
            if (GridLD.Children.Count > 0)
            {
                TabItem? ti = (GridLD.Children[0] as TabItem)!;
                ti.CalcTabPanel();
                LDPos = ti!.SelectedTabPanel;
                LDCount = ti.Count;
            }
            if (GridRU.Children.Count > 0)
            {
                TabItem? ti = (GridRU.Children[0] as TabItem)!;
                ti.CalcTabPanel();
                RUPos = ti!.SelectedTabPanel;
                RUCount = ti.Count;
            }
            if (GridRD.Children.Count > 0)
            {
                TabItem? ti = (GridRD.Children[0] as TabItem)!;
                ti.CalcTabPanel();
                RDPos = ti!.SelectedTabPanel;
                RDCount = ti.Count;
            }


            // Flaglogik f�rs Layout wird erstmal grundlegend resettet.
            ld.LU_Order = false;
            ld.LD_Order = false;
            ld.RU_Order = false;
            ld.RD_Order = false;

            ld.LU_ItemLoc = false;
            ld.LD_ItemLoc = false;
            ld.RU_ItemLoc = false;
            ld.RD_ItemLoc = false;

            ld.LU_ItemInv = false;
            ld.LD_ItemInv = false;
            ld.RU_ItemInv = false;
            ld.RD_ItemInv = false;

            ld.PortraitColumns[0, 0] = ILayoutDescription.PortraitColumn.none;
            ld.PortraitColumns[1, 0] = ILayoutDescription.PortraitColumn.none;
            ld.PortraitColumns[2, 0] = ILayoutDescription.PortraitColumn.none;
            ld.PortraitColumns[0, 1] = ILayoutDescription.PortraitColumn.none;
            ld.PortraitColumns[1, 1] = ILayoutDescription.PortraitColumn.none;
            ld.PortraitColumns[2, 1] = ILayoutDescription.PortraitColumn.none;
            ld.PortraitColumns[0, 2] = ILayoutDescription.PortraitColumn.none;
            ld.PortraitColumns[1, 2] = ILayoutDescription.PortraitColumn.none;
            ld.PortraitColumns[2, 2] = ILayoutDescription.PortraitColumn.none;


            // ... und dann komplett neu gesetzt
            if (GD!.LayoutDescription.OrderListPos == ILayoutDescription.selectedPosition.leftUp)
            {
                ld.LU_Order = true;
            }
            else if (GD.LayoutDescription.OrderListPos == ILayoutDescription.selectedPosition.leftDown)
            {
                ld.LD_Order = true;
            }
            else if (GD.LayoutDescription.OrderListPos == ILayoutDescription.selectedPosition.rightUp)
            {
                ld.RU_Order = true;
            }
            else if (GD.LayoutDescription.OrderListPos == ILayoutDescription.selectedPosition.rightDown)
            {
                ld.RD_Order = true;
            }

            if (GD.LayoutDescription.ItemsLocListPos == ILayoutDescription.selectedPosition.leftUp)
            {
                ld.LU_ItemLoc = true;
            }
            else if (GD.LayoutDescription.ItemsLocListPos == ILayoutDescription.selectedPosition.leftDown)
            {
                ld.LD_ItemLoc = true;
            }
            else if (GD.LayoutDescription.ItemsLocListPos == ILayoutDescription.selectedPosition.rightUp)
            {
                ld.RU_ItemLoc = true;
            }
            else if (GD.LayoutDescription.ItemsLocListPos == ILayoutDescription.selectedPosition.rightDown)
            {
                ld.RD_ItemLoc = true;
            }

            if (GD.LayoutDescription.ItemsInvListPos == ILayoutDescription.selectedPosition.leftUp)
            {
                ld.LU_ItemInv = true;
            }
            else if (GD.LayoutDescription.ItemsInvListPos == ILayoutDescription.selectedPosition.leftDown)
            {
                ld.LD_ItemInv = true;
            }
            else if (GD.LayoutDescription.ItemsInvListPos == ILayoutDescription.selectedPosition.rightUp)
            {
                ld.RU_ItemInv = true;
            }
            else if (GD.LayoutDescription.ItemsInvListPos == ILayoutDescription.selectedPosition.rightDown)
            {
                ld.RD_ItemInv = true;
            }

            if (GD.LayoutDescription.OrderListPosPT == ILayoutDescription.selectedPositionPT.first)
                ld.PortraitColumns[0, 0] = ILayoutDescription.PortraitColumn.order;
            else if (GD.LayoutDescription.OrderListPosPT == ILayoutDescription.selectedPositionPT.second)
                ld.PortraitColumns[1, 0] = ILayoutDescription.PortraitColumn.order;
            else if (GD.LayoutDescription.OrderListPosPT == ILayoutDescription.selectedPositionPT.third)
                ld.PortraitColumns[2, 0] = ILayoutDescription.PortraitColumn.order;

            if (GD.LayoutDescription.ItemsLocListPosPT == ILayoutDescription.selectedPositionPT.first)
                ld.PortraitColumns[0, 1] = ILayoutDescription.PortraitColumn.itemloc;
            else if (GD.LayoutDescription.ItemsLocListPosPT == ILayoutDescription.selectedPositionPT.second)
                ld.PortraitColumns[1, 1] = ILayoutDescription.PortraitColumn.itemloc;
            else if (GD.LayoutDescription.ItemsLocListPosPT == ILayoutDescription.selectedPositionPT.third)
                ld.PortraitColumns[2, 1] = ILayoutDescription.PortraitColumn.itemloc;

            if (GD.LayoutDescription.ItemsInvListPosPT == ILayoutDescription.selectedPositionPT.first)
                ld.PortraitColumns[0, 2] = ILayoutDescription.PortraitColumn.iteminv;
            else if (GD.LayoutDescription.ItemsInvListPosPT == ILayoutDescription.selectedPositionPT.second)
                ld.PortraitColumns[1, 2] = ILayoutDescription.PortraitColumn.iteminv;
            else if (GD.LayoutDescription.ItemsInvListPosPT == ILayoutDescription.selectedPositionPT.third)
                ld.PortraitColumns[2, 2] = ILayoutDescription.PortraitColumn.iteminv;


            // Wenn eine Column noch nie initialisiert war, dann wird das hier festgestellt und es werden Defaultwerte eingetragen
            if (ld.PortraitColumnsHeight <= 0 && IsPortraitVisible())
            {
                ld.PortraitColumnsHeight = 300;
            }
            if (ld.ColumLeftWidth <= 0 && (ld.LU_Order || ld.LU_ItemLoc || ld.LU_ItemInv || ld.LD_Order || ld.LD_ItemLoc || ld.LD_ItemInv))
            {
                ld.ColumLeftWidth = 200;

            }
            if (ld.ColumRightWidth <= 0 && (ld.RU_Order || ld.RU_ItemLoc || ld.RU_ItemInv || ld.RD_Order || ld.RD_ItemLoc || ld.RD_ItemInv))
            {
                ld.ColumRightWidth = 200;
            }

            if (ld.RowLeftUpHeight <= 0)
            {
                ld.RowLeftUpHeight = (GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - 40) / 2;
            }
            if (ld.RowRightUpHeight <= 0)
            {
                ld.RowRightUpHeight = (GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - 40) / 2;
            }

            if (ld.PortraitColumn1Width <= 0)
            {
                int divisor = 0;
                if (IsPortraitColVisible(0))
                    divisor++;
                if (IsPortraitColVisible(1))
                    divisor++;
                if (IsPortraitColVisible(2))
                    divisor++;

                if (divisor > 0)
                {
                    ld.PortraitColumn1Width = (GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth) / divisor;
                    ld.PortraitColumn2Width = (GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth) / divisor;
                    ld.PortraitColumn3Width = (GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth) / divisor;

                }
            }


            SetGridDimensions();

            if (ld.ScreenMode == IGlobalData.screenMode.portrait)
            {
                SetPortraitGridDimensions();

            }
            else if (ld.ScreenMode == IGlobalData.screenMode.landscape)
            {
                AdaptGridHeights();

                double xlen = 0;

                if (GetLeftColumnActive())
                {
                    MenuGridMenuInner.ColumnDefinitions[0].Width = new GridLength(ld.ColumLeftWidth);
                    MenuGridMenuInner.ColumnDefinitions[1].Width = new GridLength(10);
                    xlen += 10 + ld.ColumLeftWidth;
                    // Grid_MC_Left.IsVisible = true;

                    double height = MenuGridMenuVertical.RowDefinitions[0].Height.Value;

                    if (GetLUActive() == true && GetLDActive() == true)
                    {
                        if (ld.RowLeftUpHeight > height - 15)
                        {
                            ld.RowLeftUpHeight = height - 15;
                        }

                        Grid_MC_Left.RowDefinitions[0].Height = new GridLength(ld.RowLeftUpHeight);
                        Grid_MC_Left.RowDefinitions[1].Height = new GridLength(10);
                        Grid_MC_Left.RowDefinitions[2].Height = new GridLength(height - 10 - ld.RowLeftUpHeight);

                    }
                    else
                    {
                        if (GetLUActive() == false)
                        {
                            Grid_MC_Left.RowDefinitions[0].Height = new GridLength(0);
                            Grid_MC_Left.RowDefinitions[1].Height = new GridLength(0);
                        }
                        else
                        {
                            Grid_MC_Left.RowDefinitions[0].Height = new GridLength(height);
                            Grid_MC_Left.RowDefinitions[1].Height = new GridLength(0);

                        }
                        if (GetLDActive() == false)
                        {
                            Grid_MC_Left.RowDefinitions[2].Height = new GridLength(0);
                            Grid_MC_Left.RowDefinitions[1].Height = new GridLength(0);
                        }
                        else
                        {
                            Grid_MC_Left.RowDefinitions[2].Height = new GridLength(height);
                            Grid_MC_Left.RowDefinitions[1].Height = new GridLength(0);

                        }
                    }
                }
                else
                {
                    MenuGridMenuInner.ColumnDefinitions[0].Width = new GridLength(0);
                    MenuGridMenuInner.ColumnDefinitions[1].Width = new GridLength(0);

                }
                if (GetRightColumnActive())
                {
                    MenuGridMenuInner.ColumnDefinitions[4].Width = new GridLength(ld.ColumRightWidth);
                    MenuGridMenuInner.ColumnDefinitions[3].Width = new GridLength(10);
                    xlen += 10 + ld.ColumRightWidth;
                    // Grid_MC_Right.IsVisible = true;
                    double height = MenuGridMenuVertical.RowDefinitions[0].Height.Value;

                    if (GetRUActive() == true && GetRDActive() == true)
                    {
                        if (ld.RowRightUpHeight > height - 15)
                        {
                            ld.RowRightUpHeight = height - 15;
                        }

                        Grid_MC_Right.RowDefinitions[0].Height = new GridLength(ld.RowRightUpHeight);
                        Grid_MC_Right.RowDefinitions[1].Height = new GridLength(10);
                        Grid_MC_Right.RowDefinitions[2].Height = new GridLength(height - 10 - ld.RowRightUpHeight);

                    }
                    else
                    {
                        if (GetRUActive() == false)
                        {
                            Grid_MC_Right.RowDefinitions[0].Height = new GridLength(0);
                            Grid_MC_Right.RowDefinitions[1].Height = new GridLength(0);
                        }
                        else
                        {
                            Grid_MC_Right.RowDefinitions[0].Height = new GridLength(height);
                            Grid_MC_Right.RowDefinitions[1].Height = new GridLength(0);

                        }
                        if (GetRDActive() == false)
                        {
                            Grid_MC_Right.RowDefinitions[2].Height = new GridLength(0);
                            Grid_MC_Right.RowDefinitions[1].Height = new GridLength(0);
                        }
                        else
                        {
                            Grid_MC_Right.RowDefinitions[2].Height = new GridLength(height);
                            Grid_MC_Right.RowDefinitions[1].Height = new GridLength(0);

                        }
                    }
                }
                else
                {
                    MenuGridMenuInner.ColumnDefinitions[4].Width = new GridLength(0);
                    MenuGridMenuInner.ColumnDefinitions[3].Width = new GridLength(0);

                }
                double x = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth;

                // RotateProblem

                // GameOut.WidthRequest = x - xlen;
                // Grid_Output.WidthRequest = x - xlen;
                // MenuGridTotal.ColumnDefinitions[1].Width = x;
                // MenuGridMenuBackground.WidthRequest = x ;
                /*
              if(GridWebView.ColumnDefinitions.Count > 0 )
                 GridWebView.ColumnDefinitions[0].Width = new GridLength(x - xlen);
             */
                // if (Page_Grid().Width > 0)
                MenuGridMenuInner.ColumnDefinitions[2].Width = new GridLength(x - xlen);
                /*
                MenuGridMenuInner.WidthRequest = x ;
                MenuGridMenu.ColumnDefinitions[1].Width = new GridLength(x );
                MenuGridMenu.WidthRequest = x ;
                MenuGridMenuBackground.WidthRequest = x;
                MenuGridTotal.ColumnDefinitions[1].Width = new GridLength(x);
                MenuGridTotal.WidthRequest = x;
                */
                // MenuGridMenuBackground.ColumnDefinitions[1].Width = new GridLength(x);

                // MenuGridMenuInner.ColumnDefinitions[3].Width = new GridLength(10);
                // MenuGridMenuInner.ColumnDefinitions[4].Width = new GridLength(150);

                MenuGridMenuVertical.RowDefinitions[2].Height = new GridLength(0);
            }
            // SetGridHeights();

            bool OrderTreeHasChanged = false;
            bool ItemInvTreeHasChanged = false;
            bool ItemLocTreeHasChanged = false;

            if (OrderTreeHasInitialized == false)
                OrderTreeHasChanged = true;
            if (ItemInvTreeHasInitialized == false)
                ItemInvTreeHasChanged = true;
            if (ItemLocTreeHasInitialized == false)
                ItemLocTreeHasChanged = true;


            if (UIS.UpdateBrowserBlocked == false)
            {

                EmptyTreeOrderNew = CreateOrderTreeEmpty();
                EmptyTreeItemInvNew = CreateItemInvTree_Empty();
                EmptyTreeItemLocNew = CreateItemLocTree_Empty();
                if (EmptyTreeOrderOld != null && EmptyTreeOrderNew != null)
                {
                    if (CompareEmptyTreeViews(EmptyTreeOrderNew, EmptyTreeOrderOld) == false)
                    {
                        OrderTreeHasChanged = true;
                        // GD.Adventure!.StoryOutput("Befehle haben sich ge�ndert.");
                    }
                }
                else
                {
                    OrderTreeHasChanged = true;
                }

                if (EmptyTreeItemInvOld != null && EmptyTreeItemInvNew != null)
                {
                    if (CompareEmptyTreeViews(EmptyTreeItemInvNew, EmptyTreeItemInvOld) == false)
                    {
                        ItemInvTreeHasChanged = true;
                        // GD.Adventure!.StoryOutput("Items im Inventar haben sich ge�ndert.");
                    }
                }
                else
                {
                    ItemInvTreeHasChanged = true;
                }

                if (EmptyTreeItemLocOld != null && EmptyTreeItemLocNew != null)
                {
                    if (CompareEmptyTreeViews(EmptyTreeItemLocNew, EmptyTreeItemLocOld) == false)
                    {
                        ItemLocTreeHasChanged = true;
                        // GD.Adventure!.StoryOutput("Items vor Ort haben sich ge�ndert.");
                    }
                }
                else
                {
                    ItemLocTreeHasChanged = true;

                }

                EmptyEmptyTreeViewItem(EmptyTreeOrderOld );
                EmptyEmptyTreeViewItem(EmptyTreeItemInvOld);
                EmptyEmptyTreeViewItem(EmptyTreeItemLocOld);
                EmptyTreeOrderOld = EmptyTreeOrderNew;
                EmptyTreeItemInvOld = EmptyTreeItemInvNew;
                EmptyTreeItemLocOld = EmptyTreeItemLocNew;
            }
            else
            {
                OrderTreeHasChanged = true;
                ItemInvTreeHasChanged = true;
                ItemLocTreeHasChanged = true;
            }
            OrderTreeHasChanged = true;
            ItemInvTreeHasChanged = true;
            ItemLocTreeHasChanged = true;


            if (GetLUActive())
            {
                TILeftUp!.IsVisible = true;

                if (ld.LU_Order == true)
                {
                    TabItem.TabPanel tp = TILeftUp.TabPanels[0];

                    tp.SelectButton!.IsVisible = true;
                }
                else
                {
                    TabItem.TabPanel tp = TILeftUp.TabPanels[0];
                    tp.SelectButton!.IsVisible = false;
                }
                if (ld.LU_ItemLoc == true)
                {
                    TabItem.TabPanel tp = TILeftUp.TabPanels[1];
                    tp.SelectButton!.IsVisible = true;
                }
                else
                {
                    TabItem.TabPanel tp = TILeftUp.TabPanels[1];

                    tp.SelectButton!.IsVisible = false;
                }
                if (ld.LU_ItemInv == true)
                {
                    TabItem.TabPanel tp = TILeftUp.TabPanels[2];

                    tp.SelectButton!.IsVisible = true;
                }
                else
                {
                    TabItem.TabPanel tp = TILeftUp.TabPanels[2];

                    tp.SelectButton!.IsVisible = false;
                }

                TILeftUp.SelectedTabPanel = LUPos;
                TILeftUp.SyncTabStyles();
            }
            else
            {
                TILeftUp!.IsVisible = false;

            }
            if (GetLDActive())
            {
                TILeftDown!.IsVisible = true;

                if (ld.LD_Order == true)
                {
                    TabItem.TabPanel tp = TILeftDown!.TabPanels[0];

                    tp.SelectButton!.IsVisible = true;
                }
                else
                {
                    TabItem.TabPanel tp = TILeftDown!.TabPanels[0];
                    tp.SelectButton!.IsVisible = false;
                }
                if (ld.LD_ItemLoc == true)
                {
                    TabItem.TabPanel tp = TILeftDown!.TabPanels[1];

                    tp.SelectButton!.IsVisible = true;
                }
                else
                {
                    TabItem.TabPanel tp = TILeftDown!.TabPanels[1];

                    tp.SelectButton!.IsVisible = false;
                }
                if (ld.LD_ItemInv == true)
                {
                    TabItem.TabPanel tp = TILeftDown!.TabPanels[2];

                    tp.SelectButton!.IsVisible = true;
                }
                else
                {
                    TabItem.TabPanel tp = TILeftDown!.TabPanels[2];

                    tp.SelectButton!.IsVisible = false;
                }

                TILeftDown!.SelectedTabPanel = LDPos;
                TILeftDown!.SyncTabStyles();
            }
            else
            {
                TILeftDown!.IsVisible = false;

            }
            if (GetRUActive())
            {
                TIRightUp!.IsVisible = true;

                if (ld.RU_Order == true)
                {
                    TabItem.TabPanel tp = TIRightUp!.TabPanels[0];

                    tp.SelectButton!.IsVisible = true;
                }
                else
                {
                    TabItem.TabPanel tp = TIRightUp!.TabPanels[0];
                    tp.SelectButton!.IsVisible = false;
                }
                if (ld.RU_ItemLoc == true)
                {
                    TabItem.TabPanel tp = TIRightUp!.TabPanels[1];
                    tp.SelectButton!.IsVisible = true;
                }
                else
                {
                    TabItem.TabPanel tp = TIRightUp!.TabPanels[1];
                    tp.SelectButton!.IsVisible = false;
                }
                if (ld.RU_ItemInv == true)
                {
                    TabItem.TabPanel tp = TIRightUp!.TabPanels[2];
                    tp.SelectButton!.IsVisible = true;
                }
                else
                {
                    TabItem.TabPanel tp = TIRightUp!.TabPanels[2];
                    tp.SelectButton!.IsVisible = false;
                }

                TIRightUp!.SelectedTabPanel = RUPos;
                TIRightUp!.SyncTabStyles();
            }
            else
            {
                TIRightUp!.IsVisible = false;

            }
            if (GetRDActive())
            {
                TIRightDown!.IsVisible = true;

                if (ld.RD_Order == true)
                {
                    TabItem.TabPanel tp = TIRightDown!.TabPanels[0];
                    tp.SelectButton!.IsVisible = true;
                    tp.TabPanelSV!.IsVisible = true;
                }
                else
                {
                    TabItem.TabPanel tp = TIRightDown!.TabPanels[0];
                    tp.SelectButton!.IsVisible = false;
                    tp.TabPanelSV!.IsVisible = false;
                }
                if (ld.RD_ItemLoc == true)
                {
                    TabItem.TabPanel tp = TIRightDown!.TabPanels[1];
                    tp.SelectButton!.IsVisible = true;
                    tp.TabPanelSV!.IsVisible = true;
                }
                else
                {
                    TabItem.TabPanel tp = TIRightDown!.TabPanels[1];

                    tp.SelectButton!.IsVisible = false;
                    tp.TabPanelSV!.IsVisible = false;

                }
                if (ld.RD_ItemInv == true)
                {
                    TabItem.TabPanel tp = TIRightDown!.TabPanels[2];
                    tp.SelectButton!.IsVisible = true;
                    tp.TabPanelSV!.IsVisible = true;
                }
                else
                {
                    TabItem.TabPanel tp = TIRightDown!.TabPanels[2];

                    tp.SelectButton!.IsVisible = false;
                    tp.TabPanelSV!.IsVisible = false;
                }

                TIRightDown!.SelectedTabPanel = RDPos;
                TIRightDown!.SyncTabStyles();
            }
            else
            {
                TIRightDown!.IsVisible = false;

            }


            TreeView? tvOrder = null;
            if (TILeftUp!.IsVisible == true)
            {
                TabItem.TabPanel tp0 = TILeftUp!.TabPanels[0];
                TabItem.TabPanel tp1 = TILeftUp!.TabPanels[1];
                TabItem.TabPanel tp2 = TILeftUp!.TabPanels[2];
                foreach (TabItem.TabPanel tp in TILeftUp!.TabPanels)
                {

                    if (tp.TypeID == 1 && tp0.SelectButton!.IsVisible == true && OrderTreeHasChanged == true)
                    {
                        tvOrder = CreateOrderTree();
                        TreeView.EmptyTreeViewItem(tp0.TabPanelGrid!.Children[0]);
                        tp0.TabPanelGrid!.Children[0] = tvOrder;
                        tvOrder.CalcToggles();
                        OrderTreeHasInitialized = true;
                        // GD!.Adventure!.StoryOutput("Befehle aktualisiert");
                    }
                    else if (tp.TypeID == 2 && tp1.SelectButton!.IsVisible == true && ItemLocTreeHasChanged == true)
                    {
                        tvOrder = CreateItemLocTree();
                        TreeView.EmptyTreeViewItem(tp1.TabPanelGrid!.Children[0]);

                        tp1.TabPanelGrid!.Children[0] = tvOrder;
                        tvOrder.CalcToggles();
                        ItemLocTreeHasInitialized = true;
                        // GD.Adventure!.StoryOutput("Item Loc aktualisiert");
                    }
                    else if (tp.TypeID == 3 && tp2.SelectButton!.IsVisible == true && ItemInvTreeHasChanged == true)
                    {
                        tvOrder = CreateItemInvTree();
                        TreeView.EmptyTreeViewItem( tp2.TabPanelGrid!.Children[0]);
                        tp2.TabPanelGrid!.Children[0] = tvOrder;
                        tvOrder.CalcToggles();
                        ItemInvTreeHasInitialized = true;
                        // GD.Adventure!.StoryOutput("Item Inv aktualisiert");

                    }
                }
            }

            if (TILeftDown!.IsVisible == true)
            {
                TabItem.TabPanel tp0 = TILeftDown!.TabPanels[0];
                TabItem.TabPanel tp1 = TILeftDown!.TabPanels[1];
                TabItem.TabPanel tp2 = TILeftDown!.TabPanels[2];
                foreach (TabItem.TabPanel tp in TILeftDown!.TabPanels)
                {

                    if (tp.TypeID == 1 && tp0.SelectButton!.IsVisible == true && OrderTreeHasChanged == true)
                    {
                        tvOrder = CreateOrderTree();
                        TreeView.EmptyTreeViewItem( tp0.TabPanelGrid!.Children[0]);
                        tp0.TabPanelGrid!.Children[0] = tvOrder;
                        tvOrder.CalcToggles();
                        OrderTreeHasInitialized = true;
                        // GD.Adventure!.StoryOutput("Befehle aktualisiert");

                    }
                    else if (tp.TypeID == 2 && tp1.SelectButton!.IsVisible == true && ItemLocTreeHasChanged == true)
                    {
                        tvOrder = CreateItemLocTree();
                        TreeView.EmptyTreeViewItem(tp1.TabPanelGrid!.Children[0]);
                        tp1.TabPanelGrid!.Children[0] = tvOrder;
                        tvOrder.CalcToggles();
                        ItemLocTreeHasInitialized = true;
                        // GD.Adventure!.StoryOutput("Item Loc aktualisiert");
                    }
                    else if (tp.TypeID == 3 && tp2.SelectButton!.IsVisible == true && ItemInvTreeHasChanged == true)
                    {
                        tvOrder = CreateItemInvTree();
                        TreeView.EmptyTreeViewItem( tp2.TabPanelGrid!.Children[0]);
                        tp2.TabPanelGrid!.Children[0] = tvOrder;
                        tvOrder.CalcToggles();
                        ItemInvTreeHasInitialized = true;
                        // GD.Adventure!.StoryOutput("Item Inv aktualisiert");
                    }
                }
            }
            if (TIRightUp.IsVisible == true)
            {
                TabItem.TabPanel tp0 = TIRightUp.TabPanels[0];
                TabItem.TabPanel tp1 = TIRightUp.TabPanels[1];
                TabItem.TabPanel tp2 = TIRightUp.TabPanels[2];
                foreach (TabItem.TabPanel tp in TIRightUp.TabPanels)
                {

                    if (tp.TypeID == 1 && tp0.SelectButton!.IsVisible == true && OrderTreeHasChanged == true)
                    {
                        tvOrder = CreateOrderTree();
                        if (tvOrder != null && tp0.TabPanelGrid!.Children.Count > 0)
                        {
                            TreeView.EmptyTreeViewItem(tp0.TabPanelGrid!.Children[0]);
                            tp0.TabPanelGrid!.Children[0] = tvOrder;
                            tvOrder.CalcToggles();
                        }
                        else
                        {

                        }
                        OrderTreeHasInitialized = true;
                        // GD.Adventure!.StoryOutput("Befehle aktualisiert RU");
                    }
                    else if (tp.TypeID == 2 && tp1.SelectButton!.IsVisible == true && ItemLocTreeHasChanged == true)
                    {
                        tvOrder = CreateItemLocTree();
                        if (tvOrder != null && tp1.TabPanelGrid!.Children.Count > 0 )
                        {
                            // tp1.TabPanelGrid!.Children[0] = null;
                            TreeView.EmptyTreeViewItem( tp1.TabPanelGrid!.Children[0]);
                            tp1.TabPanelGrid!.Children[0] = tvOrder;
                            tvOrder.CalcToggles();
                        }
                        else
                        {

                        }
                        ItemLocTreeHasInitialized = true;
                        // GD.Adventure!.StoryOutput("Item Loc aktualisiert RU");
                    }
                    else if (tp.TypeID == 3 && tp2.SelectButton!.IsVisible == true && ItemInvTreeHasChanged == true)
                    {
                        tvOrder = CreateItemInvTree();
                        if (tvOrder != null && tp2.TabPanelGrid!.Children.Count > 0)
                        {
                            TreeView.EmptyTreeViewItem( tp2.TabPanelGrid!.Children[0]);
                            tp2.TabPanelGrid!.Children[0] = tvOrder;
                            tvOrder.CalcToggles();
                        }
                        else
                        {

                        }
                        ItemInvTreeHasInitialized = true;
                        // GD.Adventure!.StoryOutput("Item Inv aktualisiert RU");
                    }
                }
            }

            if (TIRightDown.IsVisible == true)
            {
                TabItem.TabPanel tp0 = TIRightDown.TabPanels[0];
                TabItem.TabPanel tp1 = TIRightDown.TabPanels[1];
                TabItem.TabPanel tp2 = TIRightDown.TabPanels[2];

                foreach (TabItem.TabPanel tp in TIRightDown.TabPanels)
                {
                    if (tp.TypeID == 1 && tp0.SelectButton!.IsVisible == true && OrderTreeHasChanged == true)
                    {
                        tvOrder = CreateOrderTree();
                        if (tvOrder != null)
                        {
                            TreeView.EmptyTreeViewItem( tp0.TabPanelGrid!.Children[0]);
                            tp0.TabPanelGrid!.Children[0] = tvOrder;
                            tvOrder.CalcToggles();
                        }
                        else
                        {

                        }
                        OrderTreeHasInitialized = true;
                        // GD.Adventure!.StoryOutput("Befehle aktualisiert RD");
                    }
                    else if (tp.TypeID == 2 && tp1.SelectButton!.IsVisible == true && ItemLocTreeHasChanged == true)
                    {
                        tvOrder = CreateItemLocTree();
                        if (tvOrder != null)
                        {
                            TreeView.EmptyTreeViewItem( tp1.TabPanelGrid!.Children[0]);

                            tp1.TabPanelGrid!.Children[0] = tvOrder;
                            tvOrder.CalcToggles();
                        }
                        else
                        {

                        }
                        ItemLocTreeHasInitialized = true;
                        // GD.Adventure!.StoryOutput("Item Loc aktualisiert RD");
                    }
                    else if (tp.TypeID == 3 && tp2.SelectButton!.IsVisible == true && ItemInvTreeHasChanged == true)
                    {
                        tvOrder = CreateItemInvTree();
                        if (tvOrder != null)
                        {
                            TreeView.EmptyTreeViewItem( tp2.TabPanelGrid!.Children[0]);
                            tp2.TabPanelGrid!.Children[0] = tvOrder;
                            tvOrder.CalcToggles();
                        }
                        else
                        {

                        }
                        ItemInvTreeHasInitialized = true;
                        // GD.Adventure!.StoryOutput("Item Inv aktualisiert RD");

                    }
                }
            }

            if (GD.LayoutDescription.ScreenMode == IGlobalData.screenMode.portrait)
            {

                // Column 1
                if (IsPortraitColVisible(0))
                {
                    // TICol1_0!.MainPanel = new();

                    if (ld.PortraitColumns[0, 0] == ILayoutDescription.PortraitColumn.order)
                    {
                        tvOrder = CreateOrderTree();

                        if (tvOrder != null)
                        {
                            // TICol1_0!.AddTabPanel(FaSolid.Wrench, 1);
                            // TICol1_0!.TabPanels[ix].TabPanelGrid.Clear();
                            TreeView.EmptyTreeViewItem( TICol1_0!.TabPanels[0].TabPanelGrid!.Children[0]);
                            TICol1_0!.TabPanels[0].TabPanelGrid!.Children[0] = tvOrder;
                            TICol1_0!.TabPanels[0].SelectButton!.IsVisible = true;
                            TICol1_0!.TabPanels[0].SelectButton!.Text = FaSolid.Wrench;
                            TICol1_0!.TabPanels[0].SelectButton!.FontFamily = "Fa-Solid";
                            OrderTreeHasInitialized = true;
                            tvOrder.CalcToggles();
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        TICol1_0!.TabPanels[0].SelectButton!.IsVisible = false;

                    }
                    if (ld.PortraitColumns[0, 1] == ILayoutDescription.PortraitColumn.itemloc)
                    {
                        tvOrder = CreateItemLocTree();
                        if (tvOrder != null)
                        {
                            // TICol1_0!.AddTabPanel(FaSolid.MapMarkerAlt, 2);
                            // TICol1_0!.TabPanels[ix].TabPanelGrid.Clear();
                            TreeView.EmptyTreeViewItem( TICol1_0!.TabPanels[1].TabPanelGrid!.Children[0]);
                            TICol1_0!.TabPanels[1].TabPanelGrid!.Children[0] = tvOrder;
                            TICol1_0!.TabPanels[1].SelectButton!.IsVisible = true;
                            TICol1_0!.TabPanels[1].SelectButton!.Text = FaSolid.MapMarkerAlt;
                            TICol1_0!.TabPanels[1].SelectButton!.FontFamily = "Fa-Solid";
                            ItemLocTreeHasInitialized = true;
                            tvOrder.CalcToggles();
                        }
                        else
                        {
                        }
                    }
                    else
                    {
                        TICol1_0!.TabPanels[1].SelectButton!.IsVisible = false;

                    }
                    if (ld.PortraitColumns[0, 2] == ILayoutDescription.PortraitColumn.iteminv)
                    {
                        tvOrder = CreateItemInvTree();
                        if (tvOrder != null)
                        {
                            // TICol1_0!.TabPanels[ix].TabPanelGrid.Clear();
                            // TICol1_0!.AddTabPanel(FaSolid.Suitcase, 3);
                            TreeView.EmptyTreeViewItem( TICol1_0!.TabPanels[2].TabPanelGrid!.Children[0]);
                            TICol1_0!.TabPanels[2].TabPanelGrid!.Children[0] = tvOrder;
                            TICol1_0!.TabPanels[2].SelectButton!.IsVisible = true;
                            TICol1_0!.TabPanels[2].SelectButton!.Text = FaSolid.Suitcase;
                            TICol1_0!.TabPanels[2].SelectButton!.FontFamily = "Fa-Solid";
                        }
                        else
                        {

                        }
                        ItemInvTreeHasInitialized = true;
                        tvOrder.CalcToggles();

                    }
                    else
                    {
                        TICol1_0!.TabPanels[2].SelectButton!.IsVisible = false;

                    }
                    TICol1_0.SyncTabStyles();

                }
                if (IsPortraitColVisible(1))
                {
                    // Column 2
                    if (ld.PortraitColumns[1, 0] == ILayoutDescription.PortraitColumn.order)
                    {
                        tvOrder = CreateOrderTree();
                        if (tvOrder != null)
                        {

                            // TICol2_0!.TabPanels[0].TabPanelGrid.Clear();
                            // TICol2_0!.TabPanels![0].TabPanelGrid!.Clear();
                            TreeView.EmptyTreeViewItem( TICol2_0!.TabPanels[0].TabPanelGrid!.Children[0]);
                            TICol2_0!.TabPanels![0].TabPanelGrid!.Children[0] = tvOrder;
                            TICol2_0!.TabPanels![0].SelectButton!.IsVisible = true;
                            TICol2_0!.TabPanels![0].SelectButton!.Text = FaSolid.Wrench;
                            tvOrder.CalcToggles();
                        }
                        else
                        {

                        }
                        OrderTreeHasInitialized = true;

                    }
                    else
                    {
                        TICol2_0!.TabPanels[0].SelectButton!.IsVisible = false;

                    }
                    if (ld.PortraitColumns[1, 1] == ILayoutDescription.PortraitColumn.itemloc)
                    {
                        tvOrder = CreateItemLocTree();
                        // TICol2_1!.TabPanels[0].TabPanelGrid.Clear();
                        // TICol2_1!.TabPanels[0].TabPanelGrid!.Clear();
                        if (tvOrder != null)
                        {
                            TreeView.EmptyTreeViewItem( TICol2_0!.TabPanels[1].TabPanelGrid!.Children[0]);
                            TICol2_0!.TabPanels[1].TabPanelGrid!.Children[0] = tvOrder;
                            TICol2_0!.TabPanels[1].SelectButton!.IsVisible = true;
                            TICol2_0!.TabPanels[1].SelectButton!.Text = FaSolid.MapMarkerAlt;
                            tvOrder.CalcToggles();
                        }
                        else
                        {
                        }
                        ItemLocTreeHasInitialized = true;

                    }
                    else
                    {
                        TICol2_0!.TabPanels[1].SelectButton!.IsVisible = false;

                    }
                    if (ld.PortraitColumns[1, 2] == ILayoutDescription.PortraitColumn.iteminv)
                    {
                        tvOrder = CreateItemInvTree();
                        if (tvOrder != null)
                        {
                            // TICol2_2!.TabPanels[0].TabPanelGrid.Clear();
                            // TICol2_2!.TabPanels[0].TabPanelGrid!.Clear();
                            TreeView.EmptyTreeViewItem( TICol2_0!.TabPanels[2].TabPanelGrid!.Children[0]);
                            TICol2_0!.TabPanels[2].TabPanelGrid.Children[0] = tvOrder;
                            TICol2_0!.TabPanels[2].SelectButton!.IsVisible = true;
                            TICol2_0!.TabPanels[2].SelectButton!.Text = FaSolid.Suitcase;
                            tvOrder.CalcToggles();
                        }
                        else
                        {
                        }
                        ItemInvTreeHasInitialized = true;

                    }
                    else
                    {
                        TICol2_0!.TabPanels[2].SelectButton!.IsVisible = false;

                    }
                    TICol2_0.SyncTabStyles();

                }
                // Column 3
                if (IsPortraitColVisible(2))
                {
                    if (ld.PortraitColumns[2, 0] == ILayoutDescription.PortraitColumn.order)
                    {
                        tvOrder = CreateOrderTree();
                        if (tvOrder != null)
                        {
                            // TICol3_0!.TabPanels[0].TabPanelGrid.Clear();
                            // TICol3_0!.TabPanels[0].TabPanelGrid!.Clear();
                            TreeView.EmptyTreeViewItem( TICol3_0!.TabPanels[0].TabPanelGrid!.Children[0]);
                            TICol3_0!.TabPanels[0].TabPanelGrid.Children[0] = tvOrder;
                            TICol3_0!.TabPanels[0].SelectButton!.IsVisible = true;
                            TICol3_0!.TabPanels[0].SelectButton!.Text = FaSolid.Wrench;
                            tvOrder.CalcToggles();
                        }
                        else
                        {
                        }
                        OrderTreeHasInitialized = true;

                    }
                    else
                    {
                        TICol3_0!.TabPanels[0].SelectButton!.IsVisible = false;

                    }

                    if (ld.PortraitColumns[2, 1] == ILayoutDescription.PortraitColumn.itemloc)
                    {
                        tvOrder = CreateItemLocTree();
                        if (tvOrder != null)
                        {
                            // TICol3_1!.TabPanels[0].TabPanelGrid.Clear();
                            // TICol3_1!.TabPanels[0].TabPanelGrid!.Clear();
                            TreeView.EmptyTreeViewItem( TICol3_0!.TabPanels[1].TabPanelGrid!.Children[0]);
                            TICol3_0!.TabPanels[1].TabPanelGrid!.Children[0] = tvOrder;
                            TICol3_0!.TabPanels[1].SelectButton!.IsVisible = true;
                            TICol3_0!.TabPanels[1].SelectButton!.Text = FaSolid.MapMarkerAlt;
                            tvOrder.CalcToggles();
                        }
                        else
                        {

                        }
                        ItemLocTreeHasInitialized = true;

                    }
                    else
                    {
                        TICol3_0!.TabPanels[1].SelectButton!.IsVisible = false;

                    }
                    if (ld.PortraitColumns[2, 2] == ILayoutDescription.PortraitColumn.iteminv)
                    {
                        tvOrder = CreateItemInvTree();
                        // TICol3_2!.TabPanels[0].TabPanelGrid.Clear();
                        // TICol3_2!.TabPanels[0].TabPanelGrid!.Clear();
                        TreeView.EmptyTreeViewItem( TICol3_0!.TabPanels[2].TabPanelGrid!.Children[0]);
                        TICol3_0!.TabPanels[2].TabPanelGrid!.Children[0] = tvOrder;
                        TICol3_0!.TabPanels[2].SelectButton!.IsVisible = true;
                        TICol3_0!.TabPanels[2].SelectButton!.Text = FaSolid.Suitcase;
                        tvOrder.CalcToggles();
                        ItemInvTreeHasInitialized = true;

                    }
                    else
                    {
                        TICol3_0!.TabPanels[2].SelectButton!.IsVisible = false;

                    }
                    TICol3_0.SyncTabStyles();

                }
            }

            /*
            if (TIRightUp != null)
            {
                foreach (TabItem.TabPanel tp in TIRightUp.TabPanels)
                {
                    if (tp.TypeID == 1)
                    {
                        tvOrder = CreateOrderTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 2)
                    {
                        tvOrder = CreateItemLocTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 3)
                    {
                        tvOrder = CreateItemInvTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                }
            }
            if (TILeftDown != null )
            {
                foreach (TabItem.TabPanel tp in TILeftDown.TabPanels)
                {
                    if (tp.TypeID == 1)
                    {
                        tvOrder = CreateOrderTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 2)
                    {
                        tvOrder = CreateItemLocTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 3)
                    {
                        tvOrder = CreateItemInvTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                }
            }
            if (TIRightDown != null)
            {
                foreach (TabItem.TabPanel tp in TIRightDown.TabPanels)
                {
                    if (tp.TypeID == 1)
                    {
                        tvOrder = CreateOrderTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 2)
                    {
                        tvOrder = CreateItemLocTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 3)
                    {
                        tvOrder = CreateItemInvTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                }
            }
            */

            /*
            GridLU.Children.Clear();
            if( GetLUActive())
            {
                TILeftUp = new TabItem();
                TILeftUp.AddTabButtonStyleSelected("IDButton");
                TILeftUp.AddTabButtonStyleUnselected("IDButton_Invers");
                TILeftUp.AddHeadlineStyle("Grid_BGBG");
                TILeftUp.AddMainPanelStyle("Grid_Normal");

                if (ld.LU_Order == true)
                {
                    TabItem.TabPanel tp = TILeftUp.AddTabPanel(FaSolid.Wrench, 1);
                    tp.SelectButton!.FontFamily = "Fa-Solid";
                    SetButtonCursorHand(tp.SelectButton);
                }
                if (ld.LU_ItemLoc == true)
                {
                    TabItem.TabPanel tp = TILeftUp.AddTabPanel(FaSolid.MapMarkerAlt,2 );
                    tp.SelectButton!.FontFamily = "Fa-Solid";
                    SetButtonCursorHand(tp.SelectButton);
                }
                if (ld.LU_ItemInv == true)
                {
                    TabItem.TabPanel tp = TILeftUp.AddTabPanel(FaSolid.Suitcase, 3);
                    tp.SelectButton!.FontFamily = "Fa-Solid";
                    SetButtonCursorHand(tp.SelectButton);
                }
                GridLU.Add(TILeftUp);

                if (TILeftUp.Count == LUCount)
                {
                    TILeftUp.SelectedTabPanel = LUPos;
                    TILeftUp.SyncTabStyles();
                }
            }

            GridLD.Children.Clear();
            if (GetLDActive())
            {
                TILeftDown = new TabItem();
                TILeftDown.AddTabButtonStyleSelected("IDButton");
                TILeftDown.AddTabButtonStyleUnselected("IDButton_Invers");
                TILeftDown.AddHeadlineStyle("Grid_BGBG");
                TILeftDown.AddMainPanelStyle("Grid_Normal");

                if (ld.LD_Order == true)
                {
                    TabItem.TabPanel tp = TILeftDown.AddTabPanel(FaSolid.Wrench, 1);
                    tp.SelectButton!.FontFamily = "Fa-Solid";
                    SetButtonCursorHand(tp.SelectButton);
                }
                if (ld.LD_ItemLoc == true)
                {
                    TabItem.TabPanel tp = TILeftDown.AddTabPanel(FaSolid.MapMarkerAlt, 2);
                    tp.SelectButton!.FontFamily = "Fa-Solid";
                    SetButtonCursorHand(tp.SelectButton);
                }
                if (ld.LD_ItemInv == true)
                {
                    TabItem.TabPanel tp = TILeftDown.AddTabPanel(FaSolid.Suitcase, 3);
                    tp.SelectButton!.FontFamily = "Fa-Solid";
                    SetButtonCursorHand(tp.SelectButton);
                }
                GridLD.Add(TILeftDown);

                if (TILeftDown.Count == LDCount)
                {
                    TILeftDown.SelectedTabPanel = LDPos;
                    TILeftDown.SyncTabStyles();
                }
            }

            GridRU.Children.Clear();
            if (GetRUActive())
            {
                TIRightUp = new TabItem();
                TIRightUp.AddTabButtonStyleSelected("IDButton");
                TIRightUp.AddTabButtonStyleUnselected("IDButton_Invers");
                TIRightUp.AddHeadlineStyle("Grid_BGBG");
                TIRightUp.AddMainPanelStyle("Grid_Normal");

                if (ld.RU_Order == true)
                {
                    TabItem.TabPanel tp = TIRightUp.AddTabPanel(FaSolid.Wrench, 1);
                    tp.SelectButton!.FontFamily = "Fa-Solid";
                    SetButtonCursorHand(tp.SelectButton);
                }
                if (ld.RU_ItemLoc == true)
                {
                    TabItem.TabPanel tp = TIRightUp.AddTabPanel(FaSolid.MapMarkerAlt, 2);
                    tp.SelectButton!.FontFamily = "Fa-Solid";
                    SetButtonCursorHand(tp.SelectButton);
                }
                if (ld.RU_ItemInv == true)
                {
                    TabItem.TabPanel tp = TIRightUp.AddTabPanel(FaSolid.Suitcase, 3);
                    tp.SelectButton!.FontFamily = "Fa-Solid";
                    SetButtonCursorHand(tp.SelectButton);
                }
                GridRU.Add(TIRightUp);

                if (TIRightUp.Count == RUCount)
                {
                    TIRightUp.SelectedTabPanel = RUPos;
                    TIRightUp.SyncTabStyles();
                }
            }

            GridRD.Children.Clear();
            if (GetRDActive())
            {
                TIRightDown = new TabItem();
                TIRightDown.AddTabButtonStyleSelected("IDButton");
                TIRightDown.AddTabButtonStyleUnselected("IDButton_Invers");
                TIRightDown.AddHeadlineStyle("Grid_BGBG");
                TIRightDown.AddMainPanelStyle("Grid_Normal");

                if (ld.RD_Order == true)
                {
                    TabItem.TabPanel tp = TIRightDown.AddTabPanel(FaSolid.Wrench, 1);
                    tp.SelectButton!.FontFamily = "Fa-Solid";
                    SetButtonCursorHand(tp.SelectButton);
                }
                if (ld.RD_ItemLoc == true)
                {
                    TabItem.TabPanel tp = TIRightDown.AddTabPanel(FaSolid.MapMarkerAlt, 2);
                    tp.SelectButton!.FontFamily = "Fa-Solid";
                    SetButtonCursorHand(tp.SelectButton);
                }
                if (ld.RD_ItemInv == true)
                {
                    TabItem.TabPanel tp = TIRightDown.AddTabPanel(FaSolid.Suitcase, 3);
                    tp.SelectButton!.FontFamily = "Fa-Solid";
                    SetButtonCursorHand(tp.SelectButton);
                }
                GridRD.Add(TIRightDown);

                if (TIRightDown.Count == RDCount)
                {
                    TIRightDown.SelectedTabPanel = RDPos;
                    TIRightDown.SyncTabStyles();
                }
            }

            TreeView? tvOrder = null;
            // TreeView? tvItemLoc = null;
            // TreeView? tvItemInv = null;

            // Hier werden die Inhalte aller Panels im UI zur�ckgesetzt
            if (TILeftUp != null )
            {
                foreach (TabItem.TabPanel tp in TILeftUp.TabPanels)
                {
                    tp.TabPanelGrid.Clear();
                }
            }
            if (TILeftDown != null)
            {
                foreach (TabItem.TabPanel tp in TILeftDown.TabPanels)
                {
                    tp.TabPanelGrid.Clear();
                }
            }
            if (TIRightUp != null)
            {
                foreach (TabItem.TabPanel tp in TIRightUp.TabPanels)
                {
                    tp.TabPanelGrid.Clear();
                }
            }
            if (TIRightDown != null)
            {
                foreach (TabItem.TabPanel tp in TIRightDown.TabPanels)
                {
                    tp.TabPanelGrid.Clear();
                }
            }

            // Und hier werden sie generiert:
            // Order == 1
            // Items in Loc == 2
            // Items in Inv == 3
            if (TILeftUp != null)
            {
                foreach (TabItem.TabPanel tp in TILeftUp.TabPanels)
                {
                    if (tp.TypeID == 1)
                    {
                        tvOrder = CreateOrderTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 2)
                    {
                        tvOrder = CreateItemLocTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 3)
                    {
                        tvOrder = CreateItemInvTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                }
            }
            if (TIRightUp != null)
            {
                foreach (TabItem.TabPanel tp in TIRightUp.TabPanels)
                {
                    if (tp.TypeID == 1)
                    {
                        tvOrder = CreateOrderTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 2)
                    {
                        tvOrder = CreateItemLocTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 3)
                    {
                        tvOrder = CreateItemInvTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                }
            }
            if (TILeftDown != null )
            {
                foreach (TabItem.TabPanel tp in TILeftDown.TabPanels)
                {
                    if (tp.TypeID == 1)
                    {
                        tvOrder = CreateOrderTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 2)
                    {
                        tvOrder = CreateItemLocTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 3)
                    {
                        tvOrder = CreateItemInvTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                }
            }
            if (TIRightDown != null)
            {
                foreach (TabItem.TabPanel tp in TIRightDown.TabPanels)
                {
                    if (tp.TypeID == 1)
                    {
                        tvOrder = CreateOrderTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 2)
                    {
                        tvOrder = CreateItemLocTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                    else if (tp.TypeID == 3)
                    {
                        tvOrder = CreateItemInvTree();
                        tp.TabPanelGrid.Add(tvOrder);
                        tvOrder.CalcToggles();
                    }
                }
            }
            */


            if (UIS.MCMVVisible == true)
            {
                DoToggleMCMV();
            }
        }
        catch (Exception e)
        {
        }
        gplUpdate = false;
        return true;
    }


    public static void EmptyEmptyTreeViewItem(EmptyTreeViewItem tv)
    {
        try
        {
            if (tv is EmptyTreeViewItem )
            {
                EmptyTreeViewItem tv2 = tv as EmptyTreeViewItem;

                foreach (EmptyTreeViewItem iv in tv2.Children)
                {
                    if (iv is EmptyTreeViewItem)
                    {
                        EmptyTreeViewItem tvi = iv as EmptyTreeViewItem;

                        EmptyEmptyTreeViewItem(tvi);

                        (iv as EmptyTreeViewItem).Children.Clear();
                    }
                    else
                    {
                        GlobalData.AddLog("Nicht ausgewertet: " + iv.GetType().ToString(), IGlobalData.protMode.crisp);

                    }
                }
                tv2.Children.Clear();
                if (tv is EmptyTreeView)
                {
                    EmptyTreeView tv3 = tv as EmptyTreeView;
                }
                else if (tv is EmptyTreeViewItem)
                {
                    EmptyTreeViewItem tv3 = tv as EmptyTreeViewItem;
                }

            }
            else
            {
                GlobalData.AddLog("EETVI Nicht ausgewertet: " + tv.GetType().ToString(), IGlobalData.protMode.crisp);
            }
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            GlobalData.AddLog("EmptyEmptyTreeViewItem: " + s, IGlobalData.protMode.crisp);


        }
    }

    TreeViewItem AddTreeViewItem( TreeViewItem tv, string? Name, string? CallString )
    {
        TreeViewItem tv1 = new();
        tv1.SetupTreeViewItem();
        tv1.UserDefinedObject = CallString!;
        tv1.Text = Name!;
        tv.Add(tv1);
        tv1.SetCursorHand();
        tv1.SetClicked(SelectTreeViewItem);
        tv1.HorizontalOptions = LayoutOptions.Start;
        tv1.CascadeInputTransparent = false;
        tv1.InputTransparent = false;
        // tv1.Background = Colors.Blue;

        /*
        var tap = new TapGestureRecognizer();
        tap.Tapped += SelectTreeViewItem; 
        tv1.GestureRecognizers.Add(tap);
        */
        // tv1.CurrentTreeState = TreeViewItem.TreeState.open;
        return tv1;
    }
    EmptyTreeViewItem AddTreeViewItemEmpty( EmptyTreeViewItem tv)
    {
        EmptyTreeViewItem tv1 = new();
        tv.Children.Add(tv1);
        return tv1;
    }

    public class EmptyTreeViewItem
    {
        public List<EmptyTreeViewItem> Children { get; set; }
        public int ID { get; set; }
        public EmptyTreeViewItem()
        {
            this.Children = new List<EmptyTreeViewItem> ();
        }

    }
    private class EmptyTreeView : EmptyTreeViewItem
    {
    }
  
    TreeView CreateItemLocTree()
    {
        TreeView tv = new();
        tv.SetupTreeView();
        tv.CurrentTreeState = TreeViewItem.TreeState.open;

        if (GD.Adventure == null)
            return tv;

        location l = GD.Adventure!.locations!.Find(GD.Adventure!.A!.ActLoc!)!;


        foreach (Item item in GD.Adventure!.Items!.List!.Values)
        {
            if ((item.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Loc, GD.Adventure!.A!.ActLoc)) && (item.IsHidden == false) && (item.Active == true))
            {
                if (item.IsMentionable == true && (!item.IsLessImportant || GD.SimpleMC == false))
                {
                    TreeViewItem newChild = AddTreeViewItem(tv, item.FullName(Case: Co.CASE_AKK, ShowAppendix: true), item.FullName(Case: Co.CASE_AKK));
                    AddSiblings(newChild, item);

                }
            }
        }
        foreach (Person person in GD.Adventure!.Persons!.List!.Values!)
        {
            if ((person.ID != GD.Adventure!.CA!.Person_I!.ID) && (person.ID != GD.Adventure!.CA!.Person_You!.ID))
            {
                if ((person.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Loc, GD.Adventure!.A!.ActLoc)) && (person.Active == true) && (person.IsHidden == false))
                {
                    TreeViewItem newChild = AddTreeViewItem(tv, person.FullName(Co.CASE_AKK, ShowAppendix: true), person.FullName(Case: Co.CASE_AKK));
                    AddSiblings(newChild, person);
  
                }
            }
        }

        
        // Die Background-Items werden alle nachgelagert addiert
        TreeViewItem BackgroundChild = new TreeViewItem();
        BackgroundChild.SetupTreeViewItem();

        foreach (Item item in GD.Adventure!.Items!.List.Values)
        {
            if ((item.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Loc, GD.Adventure!.A!.ActLoc)) && (item.IsHidden == false) && (item.Active == true))
            {
                if (item.IsMentionable == false && (!item.IsLessImportant || GD.SimpleMC == false))
                {
                    TreeViewItem newChild = AddTreeViewItem(BackgroundChild, item.FullName(Case: Co.CASE_AKK, ShowAppendix: true), item.FullName(Case: Co.CASE_AKK));
                    AddSiblings(newChild, item);

                }
            }
        }
        if ((BackgroundChild.Children.Count > 0) && (GD.Adventure!.A.Difficulty == GD.Adventure!.A.Difficulty_Easy))
        {
            tv.Add(BackgroundChild);
        }

        return tv;
    }
    EmptyTreeView CreateItemLocTree_Empty()
    {
        EmptyTreeView tv = new();
        tv.Children = new();

        if (GD.Adventure == null)
            return tv;

        location l = GD.Adventure!.locations!.Find(GD.Adventure!.A!.ActLoc!)!;


        foreach (Item item in GD.Adventure!.Items!.List!.Values)
        {
            if ((item.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Loc, GD.Adventure!.A!.ActLoc)) && (item.IsHidden == false) && (item.Active == true))
            {
                if (item.IsMentionable == true && (!item.IsLessImportant || GD.SimpleMC == false))
                {
                    EmptyTreeViewItem newChild = new();
                    tv.Children.Add(newChild);
                    newChild.ID = item.ID; 
                    AddSiblingsEmpty(newChild, item);

                }
            }
        }
        foreach (Person person in GD.Adventure!.Persons!.List!.Values!)
        {
            if ((person.ID != GD.Adventure!.CA!.Person_I!.ID) && (person.ID != GD.Adventure!.CA!.Person_You!.ID))
            {
                if ((person.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Loc, GD.Adventure!.A!.ActLoc)) && (person.Active == true) && (person.IsHidden == false))
                {
                    EmptyTreeViewItem newChild = new(); 
                    tv.Children.Add(newChild);
                    AddSiblingsEmpty(newChild, person);

                }
            }
        }
        
        // Die Background-Items werden alle nachgelagert addiert
        EmptyTreeViewItem BackgroundChild = new EmptyTreeViewItem();
 
        foreach (Item item in GD.Adventure!.Items!.List.Values)
        {
            if ((item.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Loc, GD.Adventure!.A!.ActLoc)) && (item.IsHidden == false) && (item.Active == true))
            {
                if (item.IsMentionable == false && (!item.IsLessImportant || GD.SimpleMC == false))
                {
                    EmptyTreeViewItem newChild = new();
                    BackgroundChild.Children.Add(newChild);
                    newChild.ID = item.ID; 
                    AddSiblingsEmpty(newChild, item);

                }
            }
        }
        if ((BackgroundChild.Children.Count > 0) && (GD.Adventure!.A.Difficulty == GD.Adventure!.A.Difficulty_Easy))
        {
            tv.Children.Add(BackgroundChild);
        }

        return tv;
    }

    TreeView CreateItemInvTree()
    {
        TreeView tv = new();
        tv.SetupTreeView();
        tv.CurrentTreeState = TreeViewItem.TreeState.open;

        if (GD.Adventure == null)
            return tv;

        location l = GD.Adventure!.locations!.Find(GD.Adventure!.A!.ActLoc!)!;


        foreach (Item item in GD.Adventure!.Items!.List!.Values)
        {
            if ((item.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Person, GD.Adventure!.A!.ActPerson)) && (item.IsHidden == false) && (item.Active == true))
            {
                TreeViewItem newChild = AddTreeViewItem(tv, item!.FullName(Case: Co.CASE_AKK, ShowAppendix: true), item.FullName(Case: Co.CASE_AKK));
                AddSiblings(newChild, item);
            }
        }
        foreach (Person person in GD.Adventure!.Persons!.List!.Values!)
        {
            if ((person.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Person, GD.Adventure!.A!.ActPerson)) && (person.Active == true) && (person.IsHidden == false))
            {
                TreeViewItem newChild = AddTreeViewItem(tv, person.FullName(Co.CASE_AKK, ShowAppendix: true), person.FullName(Case: Co.CASE_AKK));
                AddSiblings(newChild, person);
            }
        }
        return tv;
    }
    EmptyTreeView CreateItemInvTree_Empty()
    {
        EmptyTreeView tv = new();

        if (GD.Adventure == null)
            return tv;

        location l = GD.Adventure!.locations!.Find(GD.Adventure!.A!.ActLoc!)!;


        foreach (Item item in GD.Adventure!.Items!.List!.Values)
        {
            if ((item.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Person, GD.Adventure!.A!.ActPerson)) &&
                (item.IsHidden == false) && (item.Active == true))
            {
                EmptyTreeViewItem newChild = AddTreeViewItemEmpty(tv);
                newChild.ID = item.ID;
                AddSiblingsEmpty(newChild, item);
            }
        }
        foreach (Person person in GD.Adventure!.Persons!.List!.Values!)
        {
            if ((person.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Person, GD.Adventure!.A!.ActPerson)) && (person.Active == true) && (person.IsHidden == false))
            {
                EmptyTreeViewItem newChild = AddTreeViewItemEmpty(tv); 
                AddSiblingsEmpty(newChild, person);
            }
        }
        return tv;
    }

    void AddSiblings(TreeViewItem currentChild, Item item)
    {
        if (item != null)
        {
            if ((item.CanPutIn || item.ListInsideItems) && ((item.CanBeClosed == false) || (item.IsClosed == false)) && (item.IsHidden == false) && (item.Active == true) && (item.InvisibleIn == false))
            {
                TreeViewItem PutInChild = new TreeViewItem();
                PutInChild.SetupTreeViewItem();
                int sysChildren = PutInChild.Children.Count;

                foreach (Item item2 in GD.Adventure!.Items!.List!.Values)
                {
                    if ((item2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_In_Item, item.ID)) && (item2.IsHidden == false) && (item2.Active == true))
                    {
                        TreeViewItem newChild = AddTreeViewItem(PutInChild, item2.FullName(Case: Co.CASE_AKK, ShowAppendix: true), item2.FullName(Case: Co.CASE_AKK));
                        if (item2.InvisibleIn == false)
                            AddSiblings(newChild, item2);
                    }
                }
                foreach (Person person2 in GD.Adventure!.Persons!.List!.Values!)
                {
                    if ((person2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_In_Item, item.ID)) && (person2.Active == true) && (person2.IsHidden == false))
                    {
                        TreeViewItem newChild = AddTreeViewItem(PutInChild, person2.FullName(Co.CASE_AKK, ShowAppendix: true), person2.FullName(Case: Co.CASE_AKK));
                        AddSiblings(newChild, person2);

                     }
                }

                if (PutInChild!.SubTree!.Count > 0)
                {
                    PutInChild.Text = String.Format(loca.CustomRequestHandler_DoUIUpdate_Person_You_16300, item.FullName(Co.CASE_DAT, ShowAppendix: true));
                    currentChild.Add(PutInChild);
                }
            }
            if ((item.CanPutOn) && (item.InvisibleOn == false))
            {
                TreeViewItem PutInChild = new TreeViewItem();
                PutInChild.SetupTreeViewItem();
                int sysChildren = PutInChild.Children.Count;

                foreach (Item item2 in GD.Adventure!.Items!.List!.Values)
                {
                    if ((item2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_On_Item, item.ID)) && (item2.IsHidden == false) && (item2.Active == true))
                    {
                        TreeViewItem newChild = AddTreeViewItem(PutInChild, item2.FullName(Case: Co.CASE_AKK, ShowAppendix: true), item2.FullName(Case: Co.CASE_AKK));
                        if (item2.InvisibleIn == false)
                            AddSiblings(newChild, item2);
                    }
                }
                foreach (Person person2 in GD.Adventure!.Persons!.List!.Values)
                {
                    if ((person2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_On_Item, item.ID)) && (person2.Active == true) && (person2.IsHidden == false))
                    {
                        TreeViewItem newChild = AddTreeViewItem(PutInChild, person2.FullName(Co.CASE_AKK, ShowAppendix: true), person2.FullName(Case: Co.CASE_AKK));
                        AddSiblings(newChild, person2);
                    }
                }

                if (PutInChild.SubTree!.Count > 0)
                {

                    PutInChild.Text = String.Format(loca.CustomRequestHandler_DoUIUpdate_Person_You_16301, item.FullName(Co.CASE_DAT, ShowAppendix: true));
                    currentChild.Add(PutInChild);
                }
           }
            if ((item.CanPutBehind) && (item.InvisibleBehind == false))
            {
                TreeViewItem PutInChild = new TreeViewItem();
                PutInChild.SetupTreeViewItem();
                int sysChildren = PutInChild.Children.Count;

                foreach (Item item2 in GD.Adventure!.Items!.List!.Values)
                {
                    if ((item2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Behind_Item, item.ID)) && (item2.IsHidden == false) && (item2.Active == true))
                    {
                        TreeViewItem newChild = AddTreeViewItem(PutInChild, item2.FullName(Case: Co.CASE_AKK, ShowAppendix: true), item2.FullName(Case: Co.CASE_AKK));
                        if (item2.InvisibleIn == false)
                            AddSiblings(newChild, item2);
                    }
                }
                foreach (Person person2 in GD.Adventure!.Persons!.List!.Values)
                {
                    if ((person2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Behind_Item, item.ID)) && (person2.Active == true) && (person2.IsHidden == false))
                    {
                        TreeViewItem newChild = AddTreeViewItem(PutInChild, person2.FullName(Co.CASE_AKK, ShowAppendix: true), person2.FullName(Case: Co.CASE_AKK));
                        AddSiblings(newChild, person2);
                    }
                }

                if (PutInChild.SubTree!.Count > 0)
                {
                    PutInChild.Text = String.Format(loca.CustomRequestHandler_DoUIUpdate_Person_You_16302, item.FullName(Co.CASE_DAT, ShowAppendix: true));
                    currentChild.Add(PutInChild);
                }
            }
            if ((item.CanPutBelow) && (item.InvisibleBelow == false))
            {
                TreeViewItem PutInChild = new TreeViewItem();
                PutInChild.SetupTreeViewItem();
                int sysChildren = PutInChild.Children.Count;

                foreach (Item item2 in GD.Adventure!.Items!.List!.Values)
                {
                    if ((item2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Below_Item, item.ID)) && (item2.IsHidden == false) && (item2.Active == true))
                    {
                        TreeViewItem newChild = AddTreeViewItem(PutInChild, item2.FullName(Case: Co.CASE_AKK, ShowAppendix: true), item2.FullName(Case: Co.CASE_AKK));
                        if (item2.InvisibleIn == false)
                            AddSiblings(newChild, item2);
                    }
                }
                foreach (Person person2 in GD.Adventure!.Persons!.List!.Values!)
                {
                    if ((person2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Below_Item, item.ID)) && (person2.Active == true) && (person2.IsHidden == false))
                    {
                        TreeViewItem newChild = AddTreeViewItem(PutInChild, person2.FullName(Co.CASE_AKK, ShowAppendix: true), person2.FullName(Case: Co.CASE_AKK));
                        AddSiblings(newChild, person2);
                    }
                }


                if ( PutInChild.SubTree!.Count > 0)
                {
                    PutInChild.Text = String.Format(loca.CustomRequestHandler_DoUIUpdate_Person_You_16303, item.FullName(Co.CASE_DAT, ShowAppendix: true));
                    currentChild.Add(PutInChild);
                    // currentChild.CurrentTreeState = TreeViewItem.TreeState.open;
                    // PutInChild.CurrentTreeState = TreeViewItem.TreeState.open;
                }
            }
        }
        if ((item!.CanPutBeside) && (item!.InvisibleBeside == false))
        {
            TreeViewItem PutInChild = new TreeViewItem();
            PutInChild.SetupTreeViewItem();
            int sysChildren = PutInChild.Children.Count;

            foreach (Item item2 in GD.Adventure!.Items!.List!.Values)
            {
                if ((item2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Beside_Item, item.ID)) && (item2.IsHidden == false) && (item2.Active == true))
                {
                    TreeViewItem newChild = AddTreeViewItem(PutInChild, item2.FullName(Case: Co.CASE_AKK, ShowAppendix: true), item2.FullName(Case: Co.CASE_AKK));
                    if (item2.InvisibleIn == false)
                        AddSiblings(newChild, item2);
                }
            }
            foreach (Person person2 in GD.Adventure!.Persons!.List!.Values!)
            {
                if ((person2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Beside_Item, item.ID)) && (person2.Active == true) && (person2.IsHidden == false))
                {
                    TreeViewItem newChild = AddTreeViewItem(PutInChild, person2.FullName(Co.CASE_AKK, ShowAppendix: true), person2.FullName(Case: Co.CASE_AKK));
                    AddSiblings(newChild, person2);
                }
            }


            if (PutInChild.SubTree!.Count > sysChildren)
            {
                PutInChild.Text = String.Format(loca.CustomRequestHandler_DoUIUpdate_Person_You_16305, item.FullName(Co.CASE_DAT, ShowAppendix: true));
                currentChild.Add(PutInChild);
            }
        }
    }
    void AddSiblings(TreeViewItem currentChild, Person person)
    {
        if (person != null)
        {
            if ((person.CanPutIn) && ((person.CanBeClosed == false) || (person.IsClosed == false)) && (person.Active == true))
            {
                TreeViewItem PutInChild = new TreeViewItem();
                PutInChild.SetupTreeViewItem();

                foreach (Item item2 in GD.Adventure!.Items!.List!.Values)
                {
                    if ((item2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_In_Item, person.ID)) && (item2.IsHidden == false) && (item2.Active == true))
                    {
                        TreeViewItem newChild = AddTreeViewItem(PutInChild, item2.FullName(Case: Co.CASE_AKK, ShowAppendix: true)!, item2.FullName(Case: Co.CASE_AKK)!);
                        if (item2.InvisibleIn == false)
                            AddSiblings(newChild, item2);
                    }
                }
                foreach (Person person2 in GD.Adventure!.Persons!.List!.Values!)
                {
                    if ((person2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_In_Item, person.ID)) && (person2.Active == true) && (person2.IsHidden == false))
                    {
                        TreeViewItem newChild = AddTreeViewItem(PutInChild, person2.FullName(Co.CASE_AKK, ShowAppendix: true)!, person2.FullName(Case: Co.CASE_AKK)!);
                        AddSiblings(newChild, person2);
                    }
                }

                if (PutInChild.Children.Count > 0)
                {
                    PutInChild.Text = String.Format(loca.CustomRequestHandler_OrderListPlayTo_16306, person.FullName(Co.CASE_DAT, ShowAppendix: true));
                    currentChild.Add(PutInChild);
                }
            }
        }
    }

    void AddSiblingsEmpty(EmptyTreeViewItem currentChild, Item item)
    {
        if (item != null)
        {
            if ((item.CanPutIn || item.ListInsideItems) && ((item.CanBeClosed == false) || (item.IsClosed == false)) && (item.IsHidden == false) && (item.Active == true) && (item.InvisibleIn == false))
            {
                EmptyTreeViewItem PutInChild = new EmptyTreeViewItem();
                PutInChild.ID = item.ID;

                foreach (Item item2 in GD.Adventure!.Items!.List!.Values)
                {
                    if ((item2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_In_Item, item.ID)) && (item2.IsHidden == false) && (item2.Active == true))
                    {
                        EmptyTreeViewItem newChild = AddTreeViewItemEmpty( PutInChild);
                        newChild.ID = item2.ID;
                        if (item2.InvisibleIn == false)
                            AddSiblingsEmpty(newChild, item2);
                    }
                }
                foreach (Person person2 in GD.Adventure!.Persons!.List!.Values!)
                {
                    if ((person2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_In_Item, item.ID)) && (person2.Active == true) && (person2.IsHidden == false))
                    {
                        EmptyTreeViewItem newChild = AddTreeViewItemEmpty(PutInChild);
                        newChild.ID = person2.ID;
                        AddSiblingsEmpty(newChild, person2);

                     }
                }

                if (PutInChild!.Children!.Count > 0)
                {
                    currentChild.Children.Add(PutInChild);
                }
            }
            if ((item.CanPutOn) && (item.InvisibleOn == false))
            {
                EmptyTreeViewItem PutInChild = new EmptyTreeViewItem();
                PutInChild.ID = item.ID;

                foreach (Item item2 in GD.Adventure!.Items!.List!.Values)
                {
                    if ((item2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_On_Item, item.ID)) && (item2.IsHidden == false) && (item2.Active == true))
                    {
                        EmptyTreeViewItem newChild = AddTreeViewItemEmpty(PutInChild);
                        if (item2.InvisibleIn == false)
                            AddSiblingsEmpty(newChild, item2);
                    }
                }
                foreach (Person person2 in GD.Adventure!.Persons!.List!.Values)
                {
                    if ((person2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_On_Item, item.ID)) && (person2.Active == true) && (person2.IsHidden == false))
                    {
                        EmptyTreeViewItem newChild = AddTreeViewItemEmpty(PutInChild);
                        AddSiblingsEmpty(newChild, person2);
                    }
                }

                if (PutInChild.Children!.Count > 0)
                {
                    currentChild.Children.Add(PutInChild);
                }
           }
            if ((item.CanPutBehind) && (item.InvisibleBehind == false))
            {
                EmptyTreeViewItem PutInChild = new EmptyTreeViewItem();
                PutInChild.ID = item.ID;

                foreach (Item item2 in GD.Adventure!.Items!.List!.Values)
                {
                    if ((item2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Behind_Item, item.ID)) && (item2.IsHidden == false) && (item2.Active == true))
                    {
                        EmptyTreeViewItem newChild = AddTreeViewItemEmpty(PutInChild); 
                        if (item2.InvisibleIn == false)
                            AddSiblingsEmpty(newChild, item2);
                    }
                }
                foreach (Person person2 in GD.Adventure!.Persons!.List!.Values)
                {
                    if ((person2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Behind_Item, item.ID)) && (person2.Active == true) && (person2.IsHidden == false))
                    {
                        EmptyTreeViewItem newChild = AddTreeViewItemEmpty(PutInChild ); 
                        AddSiblingsEmpty(newChild, person2);
                    }
                }

                if (PutInChild.Children!.Count > 0)
                {
                    currentChild.Children.Add(PutInChild);
                }
            }
            if ((item.CanPutBelow) && (item.InvisibleBelow == false))
            {
                EmptyTreeViewItem PutInChild = new EmptyTreeViewItem();
                PutInChild.ID = item.ID;

                foreach (Item item2 in GD.Adventure!.Items!.List!.Values)
                {
                    if ((item2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Below_Item, item.ID)) && (item2.IsHidden == false) && (item2.Active == true))
                    {
                        EmptyTreeViewItem newChild = AddTreeViewItemEmpty(PutInChild); // 
                        if (item2.InvisibleIn == false)
                            AddSiblingsEmpty(newChild, item2);
                    }
                }
                foreach (Person person2 in GD.Adventure!.Persons!.List!.Values!)
                {
                    if ((person2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Below_Item, item.ID)) && (person2.Active == true) && (person2.IsHidden == false))
                    {
                        EmptyTreeViewItem newChild = AddTreeViewItemEmpty(PutInChild); 
                        AddSiblingsEmpty(newChild, person2);
                    }
                }


                if ( PutInChild.Children!.Count > 0)
                {
                    currentChild.Children.Add(PutInChild);
                }
            }
        }
        if ((item!.CanPutBeside) && (item!.InvisibleBeside == false))
        {
            EmptyTreeViewItem PutInChild = new EmptyTreeViewItem();
            PutInChild.ID = item.ID;

            foreach (Item item2 in GD.Adventure!.Items!.List!.Values)
            {
                if ((item2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Beside_Item, item.ID)) && (item2.IsHidden == false) && (item2.Active == true))
                {
                    EmptyTreeViewItem newChild = AddTreeViewItemEmpty(PutInChild); 
                    if (item2.InvisibleIn == false)
                        AddSiblingsEmpty(newChild, item2);
                }
            }
            foreach (Person person2 in GD.Adventure!.Persons!.List!.Values!)
            {
                if ((person2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_Beside_Item, item.ID)) && (person2.Active == true) && (person2.IsHidden == false))
                {
                    EmptyTreeViewItem newChild = AddTreeViewItemEmpty(PutInChild); 
                    AddSiblingsEmpty(newChild, person2);
                }
            }


            if (PutInChild.Children!.Count > 0 )
            {
                currentChild.Children.Add(PutInChild);
            }
        }
    }
    void AddSiblingsEmpty(EmptyTreeViewItem currentChild, Person person)
    {
        if (person != null)
        {
            if ((person.CanPutIn) && ((person.CanBeClosed == false) || (person.IsClosed == false)) && (person.Active == true))
            {
                EmptyTreeViewItem PutInChild = new EmptyTreeViewItem();
                PutInChild.ID = person.ID;

                foreach (Item item2 in GD.Adventure!.Items!.List!.Values)
                {
                    if ((item2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_In_Item, person.ID)) && (item2.IsHidden == false) && (item2.Active == true))
                    {
                        EmptyTreeViewItem newChild = AddTreeViewItemEmpty(PutInChild); 
                        if (item2.InvisibleIn == false)
                            AddSiblingsEmpty(newChild, item2);
                    }
                }
                foreach (Person person2 in GD.Adventure!.Persons!.List!.Values!)
                {
                    if ((person2.GetLoc() == Co.GenerateLoc(GD.Adventure!.CB!.LocType_In_Item, person.ID)) && (person2.Active == true) && (person2.IsHidden == false))
                    {
                        EmptyTreeViewItem newChild = AddTreeViewItemEmpty(PutInChild ); 
                        AddSiblingsEmpty(newChild, person2);
                    }
                }

                if (PutInChild.Children.Count > 0)
                {
                    currentChild.Children.Add(PutInChild);
                }
            }
        }
    }

    TreeView CreateOrderTree()
    {
        TreeView tv = new();
        tv.SetupTreeView();
        tv.CurrentTreeState = TreeViewItem.TreeState.open;

        if (GD.Adventure == null)
            return tv;
        
        

        location l = GD.Adventure!.locations!.Find(GD.Adventure!.A!.ActLoc!)!;
        if (l == null)
            return tv;

        // Wir ermitteln, welche Befehle �berhaupt angezeigt werden
        bool climbable = false;
        bool climbupable = false;
        bool climbdownable = false;
        bool enterable = false;
        bool gothroughable = false;
        bool gotoable = false;

        if (GD.SimpleMC == false)
        {
            foreach (Item i in GD.Adventure!.Items!.List!.Values)
            {
                if (GD.Adventure!.Items!.IsItemHere(i, Co.Range_Here))
                {
                    if (i.Categories!.Find(GD.Adventure!.A.Cat_GoToable) != null)
                        gotoable = true;
                    if (i.Categories!.Find(GD.Adventure!.A.Cat_GoThroughable) != null)
                        gothroughable = true;
                    if (i.Categories!.Find(GD.Adventure!.A.Cat_Climbable) != null)
                        climbable = true;
                    if (i.Categories!.Find(GD.Adventure!.A.Cat_Climbupable) != null)
                        climbupable = true;
                    if (i.Categories!.Find(GD.Adventure!.A.Cat_Climbdownable) != null)
                        climbdownable = true;
                    if (i.Categories!.Find(GD.Adventure!.A.Cat_Enterable) != null)
                        enterable = true;
                }
            }
        }



        TreeViewItem tv1 = AddTreeViewItem(tv, loca.MAUI_UI_Menu_Manual, null);
        tv1.CurrentTreeState = TreeViewItem.TreeState.open;
        AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Info, loca.MAUI_UI_Menu_Order_Info);
        AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Manual, loca.MAUI_UI_Menu_Order_Manual);
        AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Help, loca.MAUI_UI_Menu_Order_Help);
        AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Score, loca.MAUI_UI_Menu_Order_Score);
        // AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Info, loca.MAUI_UI_Menu_Order_Info);

        tv1 = AddTreeViewItem(tv, loca.MAUI_UI_Menu_General, null);
        tv1.CurrentTreeState = TreeViewItem.TreeState.open;
        AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Load, loca.MAUI_UI_Menu_Order_Load);
        AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Save, loca.MAUI_UI_Menu_Order_Save);
        AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Inv, loca.MAUI_UI_Menu_Order_Inv);
        AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Loc, loca.MAUI_UI_Menu_Order_Loc);
        AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Wait, loca.MAUI_UI_Menu_Order_Wait);

        tv1 = AddTreeViewItem(tv, loca.MAUI_UI_Menu_Movement, null);
        tv1.CurrentTreeState = TreeViewItem.TreeState.open;
        // AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Go, loca.MAUI_UI_Menu_Order_Go);
        if (l!.LocExit[1] > 0)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_GoN, loca.MAUI_UI_Menu_Order_GoN);
        if (l!.LocExit[2] > 0)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_GoNE, loca.MAUI_UI_Menu_Order_GoNE);
        if (l!.LocExit[3] > 0)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_GoE, loca.MAUI_UI_Menu_Order_GoE);
        if (l!.LocExit[4] > 0)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_GoSE, loca.MAUI_UI_Menu_Order_GoSE);
        if (l!.LocExit[5] > 0)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_GoS, loca.MAUI_UI_Menu_Order_GoS);
        if (l!.LocExit[6] > 0)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_GoSW, loca.MAUI_UI_Menu_Order_GoSW);
        if (l!.LocExit[7] > 0)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_GoW, loca.MAUI_UI_Menu_Order_GoW);
        if (l!.LocExit[8] > 0)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_GoNW, loca.MAUI_UI_Menu_Order_GoNW);
        if (l!.LocExit[9] > 0)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_GoUp, loca.MAUI_UI_Menu_Order_GoUp);
        if (l!.LocExit[10] > 0)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_GoDown, loca.MAUI_UI_Menu_Order_GoDown);

        if (climbable)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Climb, loca.MAUI_UI_Menu_Order_Climb);
        if (climbupable)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_ClimbUp, loca.MAUI_UI_Menu_Order_ClimbUp);
        if (climbdownable)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_ClimbDown, loca.MAUI_UI_Menu_Order_ClimbDown);
        if (enterable)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_Enter, loca.MAUI_UI_Menu_Order_Enter);
        if (gothroughable)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_GoThrough, loca.MAUI_UI_Menu_Order_GoThrough);
        if (gotoable)
            AddTreeViewItem(tv1, loca.MAUI_UI_Menu_GoTo, loca.MAUI_UI_Menu_Order_GoTo);

        // (TreeView.GetRootTree(tv) as TreeView)?.CalcToggles();

        // tv.CalcToggles();
        return tv;

    }
    EmptyTreeView CreateOrderTreeEmpty()
    {
        EmptyTreeView tv = new();

        try
        {
            if (GD.Adventure == null)
                return tv;

            location l = GD.Adventure!.locations!.Find(GD.Adventure!.A!.ActLoc!)!;
            if (l == null)
                return tv;

            // Wir ermitteln, welche Befehle �berhaupt angezeigt werden
            bool climbable = false;
            bool climbupable = false;
            bool climbdownable = false;
            bool enterable = false;
            bool gothroughable = false;
            bool gotoable = false;

            if (GD.SimpleMC == false)
            {
                foreach (Item i in GD.Adventure!.Items!.List!.Values)
                {
                    if (GD.Adventure!.Items!.IsItemHere(i, Co.Range_Here))
                    {
                        if (i.Categories!.Find(GD.Adventure!.A.Cat_GoToable) != null)
                            gotoable = true;
                        if (i.Categories!.Find(GD.Adventure!.A.Cat_GoThroughable) != null)
                            gothroughable = true;
                        if (i.Categories!.Find(GD.Adventure!.A.Cat_Climbable) != null)
                            climbable = true;
                        if (i.Categories!.Find(GD.Adventure!.A.Cat_Climbupable) != null)
                            climbupable = true;
                        if (i.Categories!.Find(GD.Adventure!.A.Cat_Climbdownable) != null)
                            climbdownable = true;
                        if (i.Categories!.Find(GD.Adventure!.A.Cat_Enterable) != null)
                            enterable = true;
                    }
                }
            }


            EmptyTreeViewItem tv2;
            EmptyTreeViewItem tv1 = AddTreeViewItemEmpty(tv);
            tv2 = AddTreeViewItemEmpty(tv1);
            tv2.ID = loca.MAUI_UI_Menu_Info.GetHashCode();
            tv2 = AddTreeViewItemEmpty(tv1);
            tv2.ID = loca.MAUI_UI_Menu_Manual.GetHashCode();
            tv2 = AddTreeViewItemEmpty(tv1);
            tv2.ID = loca.MAUI_UI_Menu_Help.GetHashCode();
            tv2 = AddTreeViewItemEmpty(tv1);
            tv2.ID = loca.MAUI_UI_Menu_Info.GetHashCode();

            tv1 = AddTreeViewItemEmpty(tv);
            tv2 = AddTreeViewItemEmpty(tv1);
            tv2.ID = loca.MAUI_UI_Menu_Load.GetHashCode();
            tv2 = AddTreeViewItemEmpty(tv1);
            tv2.ID = loca.MAUI_UI_Menu_Save.GetHashCode();
            tv2 = AddTreeViewItemEmpty(tv1);
            tv2.ID = loca.MAUI_UI_Menu_Inv.GetHashCode();
            tv2 = AddTreeViewItemEmpty(tv1);
            tv2.ID = loca.MAUI_UI_Menu_Loc.GetHashCode();
            tv2 = AddTreeViewItemEmpty(tv1);
            tv2.ID = loca.MAUI_UI_Menu_Wait.GetHashCode();

            tv1 = AddTreeViewItemEmpty(tv);
            tv1.ID = loca.MAUI_UI_Menu_Movement.GetHashCode();

            // tv2 = AddTreeViewItemEmpty(tv1);
            // tv2.ID = loca.MAUI_UI_Menu_Go.GetHashCode();
            if (l!.LocExit[1] > 0)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_GoN.GetHashCode();
            }

            if (l!.LocExit[2] > 0)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_GoNE.GetHashCode();
            }

            if (l!.LocExit[3] > 0)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_GoE.GetHashCode();

            }

            if (l!.LocExit[4] > 0)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_GoSE.GetHashCode();

            }

            if (l!.LocExit[5] > 0)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_GoS.GetHashCode();

            }

            if (l!.LocExit[6] > 0)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_GoSW.GetHashCode();
            }

            if (l!.LocExit[7] > 0)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_GoW.GetHashCode();

            }

            if (l!.LocExit[8] > 0)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_GoNW.GetHashCode();

            }

            if (l!.LocExit[9] > 0)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_GoUp.GetHashCode();

            }

            if (l!.LocExit[10] > 0)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_GoDown.GetHashCode();

            }

            if (climbable)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_Climb.GetHashCode();

            }

            if (climbupable)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_ClimbUp.GetHashCode();

            }

            if (climbdownable)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_ClimbDown.GetHashCode();

            }

            if (enterable)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_Enter.GetHashCode();

            }

            if (gothroughable)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_GoThrough.GetHashCode();

            }

            if (gotoable)
            {
                tv2 = AddTreeViewItemEmpty(tv1);
                tv2.ID = loca.MAUI_UI_Menu_GoTo.GetHashCode();

            }


        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        // (TreeView.GetRootTree(tv) as TreeView)?.CalcToggles();

        // tv.CalcToggles();
        return tv;

    }
    void SelectTreeViewItem(object? sender, EventArgs e)
    {
        if (GlobalData.CurrentGlobalData!.Adventure!.UIS!.MCMVVisible == true)
            return;
        // if (FeedbackTextObj.FeedbackModeMC == true || FlushText == true) return;

        TreeViewItem? tvi = (TreeViewItem)sender!;
        string? ParseText = (tvi!.UserDefinedObject as string)!;

        UIS.UpdateBrowserCallsPerCycle = 0;

        GD.OrderList!.DisableTempOrderList();
        GD.Adventure!.SetStoryLine = false;
        GD.Adventure!.DoGameLoop(ParseText!);
        UIS!.StoryTextObj!.AdvTextRefresh();
#if !NEWSCROLL

        UIS!.Scr.SetScrollerToEnd();
#endif
        SetInputFocus();
    }

    private static GridLength lastMenuGridMenuVerticalRow0Height =  GridLength.Star;
    private static GridLength lastMenuGridMenuVerticalRow1Height=  GridLength.Star;
    private static GridLength lastMenuGridMenuBackgroundRow1Height=  GridLength.Star;

    private static GridLength lastGrid_OutputRowHeight2=  GridLength.Star;
    private static GridLength lastGrid_OutputRowHeight0=  GridLength.Star;
    private static GridLength lastPageGridRowHeight2=  GridLength.Star;
        
    public void SetGridDimensions()
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription;
        double totalHeight = GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight();

        // Die Headline wird hier gleich abgezogen, weil sie hier auch nicht verarbeitet wird
        totalHeight -= _headlineHeight;

        // Wird im Portrait-Modus gespielt? Dann schauen, ob unten eines der Panel aktiviert ist. In dem Fall
        // dessen H�he ber�cksichtigen
        if (ld.ScreenMode == IGlobalData.screenMode.portrait)
        {
            if (IsPortraitVisible() == true )
            {
                GridLength gl1 = new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - ld.PortraitColumnsHeight - _headlineHeight  );
                if (lastMenuGridMenuVerticalRow0Height.Value != gl1.Value)
                {
                    MenuGridMenuVertical.RowDefinitions[0].Height = gl1; // new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - ld.PortraitColumnsHeight - _headlineHeight);
                    lastMenuGridMenuVerticalRow0Height = gl1;
                }
                GridLength gl2 = new GridLength(ld.PortraitColumnsHeight);
                if (lastMenuGridMenuVerticalRow1Height.Value != gl2.Value)
                {
                    MenuGridMenuVertical.RowDefinitions[2].Height = gl2; // new GridLength(ld.PortraitColumnsHeight);
                    lastMenuGridMenuVerticalRow1Height = gl2;
                }

                GridLength gl3 = new GridLength( MenuGridMenuVertical.RowDefinitions[0].Height.Value + MenuGridMenuVertical.RowDefinitions[2].Height.Value + 10);
                if( lastMenuGridMenuBackgroundRow1Height.Value != gl3.Value )
                {
                    MenuGridMenuBackground.RowDefinitions[1].Height = gl3; // new GridLength( MenuGridMenuVertical.RowDefinitions[0].Height.Value + MenuGridMenuVertical.RowDefinitions[1].Height.Value );
                    lastMenuGridMenuBackgroundRow1Height = gl3;

                    MenuGridMenu.HeightRequest = gl3.Value;
                    MenuGridMenuInner.HeightRequest = gl3.Value;
                    MenuGridMenuVertical.HeightRequest = gl3.Value;
                    MenuGridMenuVertical.RowDefinitions[0].Height = gl3;
                    Grid_Output.HeightRequest = gl3.Value;


                }
                // PageGrid.RowDefinitions[2].Height = new GridLength(MenuGridMenuVertical.RowDefinitions[0].Height.Value + MenuGridMenuVertical.RowDefinitions[1].Height.Value);
                // Grid_Output.RowDefinitions[0].Height = new GridLength(MenuGridMenuVertical.RowDefinitions[0].Height.Value - Grid_Output.RowDefinitions[2].Height.Value);
                totalHeight -= ld.PortraitColumnsHeight;
            }
            else
            {
                 GridLength gl1 = new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - _headlineHeight);
                if (lastMenuGridMenuVerticalRow0Height.Value != gl1.Value)
                {
                    MenuGridMenuVertical.RowDefinitions[0].Height = gl1; // new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - ld.PortraitColumnsHeight - _headlineHeight);
                    lastMenuGridMenuVerticalRow0Height = gl1;
                }
                GridLength gl2 = new GridLength(0);
                if (lastMenuGridMenuVerticalRow1Height.Value != gl2.Value)
                {
                    MenuGridMenuVertical.RowDefinitions[2].Height = gl2; // new GridLength(ld.PortraitColumnsHeight);
                    lastMenuGridMenuVerticalRow1Height = gl2;

                }

                GridLength gl3 = new GridLength( MenuGridMenuVertical.RowDefinitions[0].Height.Value + 10 );
                 if( lastMenuGridMenuBackgroundRow1Height.Value != gl3.Value )
                {
                    MenuGridMenuBackground.RowDefinitions[1].Height = gl3; // new GridLength( MenuGridMenuVertical.RowDefinitions[0].Height.Value + MenuGridMenuVertical.RowDefinitions[1].Height.Value );
                    lastMenuGridMenuBackgroundRow1Height = gl3;

                    MenuGridMenu.HeightRequest = gl3.Value;
                    MenuGridMenuInner.HeightRequest = gl3.Value;
                    MenuGridMenuVertical.HeightRequest = gl3.Value;
                    MenuGridMenuVertical.RowDefinitions[0].Height = gl3;
                    Grid_Output.HeightRequest = gl3.Value;
                }
                /*
                MenuGridMenuVertical.RowDefinitions[0].Height = new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - _headlineHeight);
                MenuGridMenuVertical.RowDefinitions[1].Height = new GridLength(0);
                MenuGridMenuBackground.RowDefinitions[1].Height = MenuGridMenuVertical.RowDefinitions[0].Height;
                */
            }
        }
        else
        {
            GridLength gl1 = new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() );
            if (lastMenuGridMenuVerticalRow0Height.Value != gl1.Value)
            {
                MenuGridMenuVertical.RowDefinitions[0].Height = gl1; 
                lastMenuGridMenuVerticalRow0Height = gl1;
            }
            GridLength gl2 = new GridLength(0);
            if (lastMenuGridMenuVerticalRow1Height.Value != gl2.Value)
            {
                MenuGridMenuVertical.RowDefinitions[2].Height = gl2; 
                lastMenuGridMenuVerticalRow1Height = gl2;
            }

            GridLength gl3 = MenuGridMenuVertical.RowDefinitions[0].Height;
            if( lastMenuGridMenuBackgroundRow1Height.Value != gl3.Value )
            {
                MenuGridMenuBackground.RowDefinitions[1].Height = gl3; 
                lastMenuGridMenuBackgroundRow1Height = gl3;

                MenuGridMenu.HeightRequest = gl3.Value;
                MenuGridMenuInner.HeightRequest = gl3.Value;
                MenuGridMenuVertical.HeightRequest = gl3.Value;
                MenuGridMenuVertical.RowDefinitions[0].Height = gl3;
                Grid_Output.HeightRequest = gl3.Value;
            }
            /*
                        MenuGridMenuVertical.RowDefinitions[0].Height = new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - _headlineHeight);
                        MenuGridMenuVertical.RowDefinitions[1].Height = new GridLength(0);
                        MenuGridMenuBackground.RowDefinitions[1].Height = MenuGridMenuVertical.RowDefinitions[0].Height;
            */
        }

        if (UIS.MCMVVisible)
        {
            GridLength gl1 = new GridLength(_mcGridHeight);
            if( lastGrid_OutputRowHeight2.Equals( gl1 ) == false )
            // if (lastGrid_OutputRowHeight2 != gl1)
            {
                Grid_Output.RowDefinitions[2].Height = gl1;
                lastGrid_OutputRowHeight2 = gl1;
                AdaptGridHeights();
            }

            GridLength gl2 = new GridLength( totalHeight - _mcGridHeight );
            if (lastGrid_OutputRowHeight0.Equals(gl2) == false ) 
            // if (lastGrid_OutputRowHeight0 != gl2)
            {
                Grid_Output.RowDefinitions[0].Height = gl2;
                lastGrid_OutputRowHeight0 = gl2;
                AdaptGridHeights();
            }


        }
        else
        {
            GridLength gl1 = new GridLength(_inputGridHeight);
            // if (lastGrid_OutputRowHeight2 != gl1)
            if (lastGrid_OutputRowHeight2.Equals(gl1) == false )
            {
                Grid_Output.RowDefinitions[2].Height = gl1;
                lastGrid_OutputRowHeight2 = gl1;
                AdaptGridHeights();
            }

            GridLength gl2 = new GridLength(totalHeight - _inputGridHeight);
            if (lastGrid_OutputRowHeight0.Equals( gl2 ) == false ) 
                // if (lastGrid_OutputRowHeight0 != gl2)
            {
                Grid_Output.RowDefinitions[0].Height = gl2;
                lastGrid_OutputRowHeight0 = gl2;
                AdaptGridHeights();
            }

            /*
            Grid_Output.RowDefinitions[2].Height = new GridLength(_inputGridHeight);
            Grid_Output.RowDefinitions[0].Height = new GridLength(totalHeight - _inputGridHeight);
            */
        }

        GridLength glPD = new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - _headlineHeight);

        // if (lastPageGridRowHeight2 != glPD)
        if (lastPageGridRowHeight2.Equals( glPD ) == false )
        {
            PageGrid.RowDefinitions[2].Height = glPD;
            lastPageGridRowHeight2 = glPD;
        }
    }

    public int rotateWait = 0;
    public void ChangeOrientation(IGlobalData.screenMode sm)
    {
        /*
        if( sm == IGlobalData.screenMode.landscape)
            DebugText.Text = "Landscape";
        else
            DebugText.Text = "Portrait";
        */
        if (sm == lastSM) return;

        PageGrid.IsEnabled = false;
        PageGrid.IsVisible = false;
        // Shell.Current.IsVisible = false;
        rotateWait = 5;

        // MenuGridMenuInner.MeasureInvalidated = true;

#if ANDROID
        Thickness p = MenuGridTotal.Padding;
        p.Left = p.Left - 1;

        MenuGridTotal.Padding = p;
        p.Left = p.Left + 1;
        MenuGridTotal.Padding = p;

        OnSizeAllocated(GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth(), GlobalSpecs.CurrentGlobalSpecs.GetScreenHeight());
#endif

        // GlobalData.CurrentGlobalData!.LayoutDescription.ScreenMode = sm;
        SetGamePageLayout();
        AdaptGridHeights();

        UIS.Scr.SetToEnd();  

        lastSM = sm;
    }
    public void DoResize( double width, double height)
    {
        UIS.Scr.SetRescale();
 
        SetGamePageLayout();
        AdaptGridHeights();
    }

    public bool SetLanguage()
    {
        WindowTitle.Text = loca.MAUI_UI_Game;
        LabelEpisode.Text = loca.MAUI_UI_Episode;
        LabelGesamt.Text = loca.MAUI_UI_Gesamt;
        Button_More_Inner.Text = loca.MAUI_UI_More;
        SendButton.Text = loca.MAUI_UI_Send;

        _menuExtension!.SetLanguage();

        SetScoreEpisode();

        return true;
    }

    public bool SetScoreEpisode()
    {
        if (GD != null)
        {
            if (GD!.Adventure != null)
            {
                // string s = string.Format(loca.AdvBase_SetScoreOutput_16090, GD!.Adventure!.CA!.Status_Episode!.Val);
                // GD.Adventure!.UIS.SetScoreEpisode(s);
                // LabelEpisode.Text = s;
            }
        }
        return true;
    }

   
    public bool SetScore(double cscore, double ctotalscore, double score, double totalscore)
    { 
        if (GD != null)
        {
            if (GD.Adventure != null)
            {
                /*
                double val1 = cscore / 100;
                if (val1 < 0.1)
                    val1 = 0.1;
                double val2 = (ctotalscore - cscore) / 100;
                if (val2 < 0.1)
                    val2 = 0.1;

                if ( val1 == 0)
                    PB1.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Absolute);
                else
                    PB1.ColumnDefinitions[0].Width = new GridLength( 0, GridUnitType.Absolute);

                PB1.ColumnDefinitions[1].Width = new GridLength( 0, GridUnitType.Absolute);
                */
                double val1;
                double val2;

                val1 = score / 100;
                if (val1 < 0.1)
                    val1 = 0.1;
                val2 = (totalscore - score) / 100;
                if (val2 < 0.1)
                    val2 = 0.1;

                if (val1 == 0)
                    PB2.ColumnDefinitions[0].Width = new GridLength(0, GridUnitType.Absolute);
                else
                    PB2.ColumnDefinitions[0].Width = new GridLength(val1, GridUnitType.Star);
                PB2.ColumnDefinitions[1].Width = new GridLength(val2, GridUnitType.Star);

                // ToolTipProperties.SetText(PB1, cscore + "/" + ctotalscore);
                // ToolTipProperties.SetText(PB2, score + "/" + totalscore);

                // PB2.ColumnDefinitions[0].Width = new GridLength(20, GridUnitType.Star);
                // PB2.ColumnDefinitions[1].Width = new GridLength(50.22, GridUnitType.Star);

                // _mw.PB1.Value = (double)((cscore * 100) / ctotalscore);
                //     _mw.PB2.Value = (double)((score * 100) / totalscore);
                // _mw.PB1.ToolTip = string.Format(loca.AdvBase_SetScoreOutput_16088, val, (double)((cscore * 100) / ctotalscore));
                // _mw.PB2.ToolTip = string.Format(loca.AdvBase_SetScoreOutput_16089, (double)((score * 100) / totalscore));
                return true;
            }
        }
        return false;
    }

    static int val = 0;

    public bool DoGamePageMenu()
    {

        return true;
    }

    private void SetGridActive(Grid g, bool active)
    {
        /*
        if (g == null)
        {
            
        }
        else
        {
            if (active == true)
            {
                g.IsVisible = true;
            }
            else
            {

                g.IsVisible = false;
            }
            
        }
        */
        if ( active == true )
        {
            List<string> GridActive = new();
            GridActive.Add("Grid_Normal");

            List<string> ButtonActive = new();
            ButtonActive.Add("IDButton");

            List<string> ButtonActiveActive = new();
            ButtonActiveActive.Add("IDButton_Invers");

            if (g.Children.Count > 0)
            {
                TabItem? ti = (g.Children[0] as TabItem)!;

                int ctPanels = ti!.TabPanels.Count;

                ti.AddTabButtonStyleSelected("IDButton");
                ti.AddTabButtonStyleUnselected("IDButton_Invers");

                int ix = 0;
                foreach (TabItem.TabPanel tp in ti.TabPanels)
                {
                    tp.TabPanelGrid!.StyleClass = GridActive;

                    if (ix == ti.SelectedTabPanel)
                        tp.SelectButton!.StyleClass = ButtonActive;
                    else
                        tp.SelectButton!.StyleClass = ButtonActiveActive;

                    if (tp.TabPanelGrid.Children[0] != null)
                    {
                        Object o = tp.TabPanelGrid.Children[0];

                        if (o.GetType() == typeof(TreeView))
                        {
                            TreeView? tv = o as TreeView;
                            tv!.CallbackAll(DoSetTextActive);
                        }
                        ix++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

        }
        else
        {


            List<string> GridInactive = new();
            GridInactive.Add("Grid_Normal_Inactive");

            List<string> ButtonInactive = new();
            ButtonInactive.Add("IDButton_Normal_Inactive");

            List<string> ButtonInactiveInactive = new();
            ButtonInactiveInactive.Add("IDButton_BGBG_Inactive");



            if (g.Children.Count > 0)
            {
                TabItem? ti = (g.Children[0] as TabItem)!;

                int ctPanels = ti.TabPanels.Count;

                ti.AddTabButtonStyleSelected("IDButton_Normal_Inactive");
                ti.AddTabButtonStyleUnselected("IDButton_BGBG_Inactive");

                int ix = 0;
                foreach (TabItem.TabPanel tp in ti.TabPanels)
                {
                    tp.TabPanelGrid!.StyleClass = GridInactive;

                    if (ix == ti.SelectedTabPanel)
                        tp.SelectButton!.StyleClass = ButtonInactive;
                    else
                        tp.SelectButton!.StyleClass = ButtonInactiveInactive;

                    Object o = tp.TabPanelGrid.Children[0];

                    if (o.GetType() == typeof(TreeView))
                    {
                        TreeView? tv = o as TreeView;
                        tv!.CallbackAll(DoSetTextInactive);
                    }
                    ix++;
                }
            }
        }
    }


    private bool DoToggleMCMV()
    {
        // Pr�fen: Ist diese Umschaltung informant?
        // Aktuell wird sie deutlich zu oft aufgerufen und k�nnte optimiert werden
        if (UIS.MCMVVisible == false)
        {
            SetGridActive(GridLU, true);
            SetGridActive(GridLD, true);
            SetGridActive(GridRU, true);
            SetGridActive(GridRD, true);
        }
        else
        {
            SetGridActive(GridLU, false);
            SetGridActive(GridLD, false);
            SetGridActive(GridRU, false);
            SetGridActive(GridRD, false);

        }
         /* OLD
        if (UIS.MCMVVisible == false)
        {
            List<string> GridActive = new();
            GridActive.Add("Grid_Normal");

            List<string> ButtonActive = new();
            ButtonActive.Add("IDButton");

            List<string> ButtonActiveActive = new();
            ButtonActiveActive.Add("IDButton_Invers");

            if (GridLU.Children.Count > 0)
            {
                TabItem ti = (GridLU.Children[0] as TabItem);

                int ctPanels = ti.TabPanels.Count;

                ti.AddTabButtonStyleSelected("IDButton");
                ti.AddTabButtonStyleUnselected("IDButton_Invers");

                int ix = 0;
                foreach (TabItem.TabPanel tp in ti.TabPanels)
                {
                    tp.TabPanelGrid.StyleClass = GridActive;

                    if (ix == ti.SelectedTabPanel)
                        tp.SelectButton!.StyleClass = ButtonActive;
                    else
                        tp.SelectButton!.StyleClass = ButtonActiveActive;

                    Object o = tp.TabPanelGrid.Children[0];

                    TreeView tv = o as TreeView;
                    tv.CallbackAll(DoSetTextActive);

                    ix++;
                }
            }

        }
        else
        {


            List<string> GridInactive = new();
            GridInactive.Add("Grid_Normal_Inactive");

            List<string> ButtonInactive = new();
            ButtonInactive.Add("IDButton_Normal_Inactive");

            List<string> ButtonInactiveInactive = new();
            ButtonInactiveInactive.Add("IDButton_BGBG_Inactive");



            if (GridLU.Children.Count > 0)
            {
                TabItem ti = (GridLU.Children[0] as TabItem);

                int ctPanels = ti.TabPanels.Count;

                ti.AddTabButtonStyleSelected("IDButton_Normal_Inactive");
                ti.AddTabButtonStyleUnselected("IDButton_BGBG_Inactive");

                int ix = 0;
                foreach (TabItem.TabPanel tp in ti.TabPanels)
                {
                    tp.TabPanelGrid.StyleClass = GridInactive;

                    if (ix == ti.SelectedTabPanel)
                        tp.SelectButton!.StyleClass = ButtonInactive;
                    else
                        tp.SelectButton!.StyleClass = ButtonInactiveInactive;

                    Object o = tp.TabPanelGrid.Children[0];

                    TreeView tv = o as TreeView;
                    tv.CallbackAll(DoSetTextInactive);

                    ix++;
                }
            }
        }
*/
        return true;
    }

    public void DoSetTextInactive( object? o)
    {
        TreeViewItem? tvi = o as TreeViewItem;
        Label? l1 = tvi!.TextLabel;

        List<string> LabelClass = new();
        LabelClass.Add("Label_Normal_Inactive");
        l1!.StyleClass = LabelClass;
   }

    public void DoSetTextActive(object? o)
    {
         TreeViewItem? tvi = (o as TreeViewItem)!;
        Label? l1 = tvi!.TextLabel;

        List<string> LabelClass = new();
        LabelClass.Add("Label_Normal");
        l1!.StyleClass = LabelClass;
    }



    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {

        try
        {
#if WINDOWS
            var nativeView = Inputline.Handler;
            var pv = nativeView!.PlatformView;
            (pv as Microsoft.Maui.Platform.MauiPasswordTextBox)!.BorderThickness = new Microsoft.UI.Xaml.Thickness(0);
            (pv as Microsoft.Maui.Platform.MauiPasswordTextBox)!.FocusVisualPrimaryThickness = new Microsoft.UI.Xaml.Thickness(0);
            (pv as Microsoft.Maui.Platform.MauiPasswordTextBox)!.FocusVisualSecondaryThickness = new Microsoft.UI.Xaml.Thickness(0);
            // (pv as Microsoft.Maui.Platform.MauiPasswordTextBox).SelectionHighlightColor = Microsoft.UI.Xaml.Media.SolidColorBrush.ColorProperty("Red;

#endif


            if (GD.STTMicroState == IGlobalData.microMode.off)
            {
                Grid_Input_Sub.ColumnDefinitions[1].Width = new GridLength(0);
                Grid_MC.ColumnDefinitions[1].Width = new GridLength(0);
                Grid_More.ColumnDefinitions[1].Width = new GridLength(0);
                Mike.IsVisible = false;
                Mike2.IsVisible = false;
                Mike3.IsVisible = false;
            }
            else
            {
                Grid_Input_Sub.ColumnDefinitions[1].Width = new GridLength(30);
                Grid_MC.ColumnDefinitions[1].Width = new GridLength(30);
                Grid_More.ColumnDefinitions[1].Width = new GridLength(30);
                Mike.IsVisible = true;
                Mike2.IsVisible = true;
                Mike3.IsVisible = true;
            }


            GlobalSpecs.CurrentGlobalSpecs!.InitRunning = IGlobalSpecs.initRunning.started;

            UIS.UpdateBrowserBlocked = true;

            GlobalSpecs.CurrentGlobalSpecs!.SetCurrentPage(CurrentPage);
            GD.MenuExtension = (MenuExtension)_menuExtension!;

            GD.SetDelProvideMCGrid(ProvideMCGrid!);
            UIS.SetLocalUIUpdate(SetGamePageLayout);

            GlobalData.CurrentGlobalData!.UIS = UIS;

            _viewModelGeneral!.SetCallbackChangeOrientation((IGlobalData._callbackChangeOrientation)ChangeOrientation);
            _viewModelGeneral!.SetCallbackResize((IGlobalData._callbackResize)DoResize);
            base.OnNavigatedTo(args);

            await _viewModelMain!.Initialize();

            double w = this.Width;
            double h = this.Height;

#if ANDROID
        w = DeviceDisplay.MainDisplayInfo.Width;
        h = DeviceDisplay.MainDisplayInfo.Height;
#endif

            _viewModelGeneral.InitResize(w, h);

            Inputline.BindingContext = _viewModelGame;

            GlobalData.CurrentGlobalData!.Inputline = Inputline;
            GlobalData.CurrentGlobalData!.FocusMethod = SetInputFocus;

            val++;
            GlobalData.CurrentGlobalData!.SetHtmlFromTheme();
            UIS!.ExternalGameOut = GameOut;
            ChangeOrientation(GD.LayoutDescription.ScreenMode);
            /*
            try
            {
                UIS!.ExternalGameOut!.Navigating! -= UIS!.WebView1_Navigating!;
                UIS!.ExternalGameOut!.Navigated -= UIS!.WebView1_Navigating2!;

            }
            catch 
            {
            }
            */


            UIS.ExternalGameOut.Navigating += UIS.WebView1_Navigating;
            UIS.ExternalGameOut.Navigated += UIS.WebView1_Navigating2;

            // UIS.ExternalGameOut.Loaded += UIS.WebView1_Navigating3;

            if (val >= 1)
            {
                // HtmlWebViewSource.
                // GameOutput.Source = new HtmlWebViewSource
                // {
                // 
                // Html = GlobalData.CurrentGlobalData!.WebViewContent,
                // };
            }

            SetLanguage();
            UIS!.SetSetLanguage(SetLanguage);
            UIS!.SetScoreEpisodeMethod(SetScoreEpisode);
            UIS!.SetScoreMethod(SetScore);
            UIS!.SetMCMVVisibleCallback(DoToggleMCMV);
            _menuExtension!.SetLocalMethod(DoGamePageMenu);
            _menuExtension!.CurrentMenuName = nameof(GamePage);

            _menuExtension!.QuitMethod = PressEndLocal;

            GD.SetDelProvideMCGrid(ProvideMCGrid!);
            GD.SetDelProvideMoreGrid(ProvideMoreGrid);
            GD.SetDelSelectOutput(SelectOutput);


#if WINDOWS
            SetupKeyboardHandler();

#endif
            UIS.UpdateBrowserBlocked = true;
            UIS.STTListenigModeChangeCB = SetMicrophone;
            UIS.HeadlineLabel = WindowTitle;

            GD.OrderList!.DisableTempOrderList();

            if (GD.Adventure == null)
            {
                GD.AskForPlayLevel = true;
                GD.Adventure = new GameCore.Adv(true, true);
                GD.Adventure!.Orders!.ReadSlotDescription();

                GD.ValidRun = true;
                GD!.Adventure!.SetScoreOutput();
                // UIS!.StoryTextObj!.RecalcLatest();
                // UIS!.StoryTextObj!.TextReFreshman();
                if (GD.Adventure != null && GD.AskForPlayLevel)
                {
                    GD!.Adventure!.Orders!.GenericDialog(null, GD.Adventure!.Orders!.SetupDialog);
                    GD!.AskForPlayLevel = false;

                    // UIS.StoryTextObj.AdvTextOut();
                }
                // UIS.StoryTextObj.AdvTextRefresh(true);
            }
            else
            {
                // UIS!.StoryTextObj!.RecalcLatest();
                // UIS!.StoryTextObj!.TextReFreshman();

                if (GD.AskForPlayLevel)
                {
                    GD!.Adventure!.Orders!.GenericDialog(null, GD.Adventure!.Orders!.SetupDialog);
                    GD!.AskForPlayLevel = false;
                    // UIS.StoryTextObj.AdvTextOut();
                }
                // UIS.StoryTextObj.AdvTextRefresh(true);
            }

            UIS!.StoryTextObj!.RecalcLatest();
            UIS!.StoryTextObj!.TextReFreshman();
            UIS!.StoryTextObj!.AdvTextRefresh(true);
            GlobalSpecs.CurrentGlobalSpecs.InitRunning = IGlobalSpecs.initRunning.finished;


            if (UIS.MCMVVisible == true)
            {
                if (UIS.MCM != null)
                {
                    // RestoreGeneratedDialog( , string FuncName)

                    Phoney_MAUI.Model.DelMCMSelection? sel = UIS.MCM.MCS != null ? UIS.MCM.MCS.GetCallbackSelection() : null;

                    UIS.MCM.MCS = UIS.MCM.MenuShow();
                    if (GD.LatestGameDefinition != null)
                    {
                        GD.Adventure!.Orders!.MCCallbackName = GD.LatestGameDefinition.MCCallbackName;
                        if (sel == null)
                        {
                            if (GD.Adventure.Orders.MCCallbackName == "MCSelection" || GD.Adventure.Orders.MCCallbackName == null)
                            {
                                sel = UIS.MCM.MCSelection;
                            }
                            else
                            {

                            }
                        }
                    }

                    if (sel != null)
                        UIS.MCM.MCS.SetCallbackSelection(sel);
                    GD.Adventure!.Orders!.temporaryMCMenu = UIS.MCM;
                    GD.Adventure!.Orders!.persistentMCMenu = null;

                    bool continued = UIS.MCM.Set(GD.Adventure.Orders.MCID);

                    Person? p = GD.Adventure.Persons!.Find(GD.Adventure.Orders.MCPersonID);

                    if (continued)
                        UIS.MCM.MCS.MCOutput(UIS.MCM, UIS.MCM.MCS.GetCallbackSelection(), false);


                    UIS.Scr.PageToEnd();
                }
            }
            GD.UIS!.RecalcPictures(true);

            SetGamePageLayout();

            // UIS!.Scr.JumpToEndInstantly();
            // UIS!.InitBrowserUpdate();

            UIS.UpdateBrowserBlocked = false;
            UIS!.InitBrowserUpdate();
            _menuExtension.ListCalls.Add(new(DoSpeech, -1));

            UIS!.Scr.YPosMode = Scroller.YPosModes.startwebview;


            UIS.SetUICallback(SetGamePageLayout, ExecuteGamePageLayout);
            GameOut.SetCBFullyLoaded(GD.UIS!.Scr.ResetWait);
            GameOut.SetProtocol(GlobalData.InitLog, (WebViewInterop.DelVoidStringProtMode) GlobalData.AddLog);
            UIS!.FinishBrowserUpdate(IUIServices.onBrowserContentLoaded.SetToEnd);
            GD.InitProcess = false;
        }
        catch (Exception ex)
        {

        }
        // Thread.Sleep(100);
    }

    public void SetMicrophone(Phoney_MAUI.Model.IUIServices.sttListeningMode mode )
    {
        if( mode == IUIServices.sttListeningMode.off)
        {
            UIS.NewMikeColor = Colors.White;
        }
        else if ( mode == IUIServices.sttListeningMode.on)
        {
            UIS.NewMikeColor = Colors.LightGreen;

        }
        else if ( mode == IUIServices.sttListeningMode.continuous)
        {
            UIS.NewMikeColor = Colors.Red;
        }
    }


    int CountDebugLoops = 0;
    public bool DoSpeech()
    {
        try
        {
            if (GameOut.InqCBFullyLoaded() == false)
            {

                GameOut.SetProtocol(GlobalData.InitLog, GlobalData.AddLog);
                GameOut.SetCBFullyLoaded(GD.UIS!.Scr.ResetWait);
            }

            DebugLabel.Text = String.Format("{0} - {1} - {2} - {3} - {4} - {5}", UIS.Scr.HTMLViewYRef, UIS.Scr.HTMLViewYPos, UIS.Scr.HTMLViewMaxYPos, UIS.Scr.HTMLLastSet, UIS.Scr.HTMLLastSet2, UIS.Scr.HTMLLastSet3);

            /*
            if(Grid_Input.IsVisible == false )
            {
                if( PageGrid.IsFocused == false )
                   PageGrid.Focus();
            }
            else
            {
                if( Inputline.IsFocused == false )
                   Inputline.Focus();
            }
            */

            if (GD.SavegameFailed == true)
            {
                GD.SavegameFailed = false;

                ShowDialog(loca.MAUI_Infodialog_Savegame_Failed);

            }


            if (UIS.RecordedText != null)
            {
                if (UIS.RecordedText.Length > 0)
                {

                }
            }
            if (UIS.NewMikeColor != Colors.Brown)
            {
                Mike.TextColor = UIS.NewMikeColor;
                Mike2.TextColor = UIS.NewMikeColor;
                Mike3.TextColor = UIS.NewMikeColor;
                UIS.NewMikeColor = Colors.Brown;
            }

            if (PageGrid.IsVisible == false)
            {
                if (rotateWait > 0)
                {
                    rotateWait--;
                }
                else
                {
                    PageGrid.IsVisible = true;
                    PageGrid.IsEnabled = true;
                }
            }

            UIS.STTTestRunning();

            // if (DeviceDisplay.MainDisplayInfo == null) return true;
            if (GlobalData.CurrentGlobalData!.Adventure != null && GlobalData.CurrentGlobalData.InitProcess == false)
            {
                if (GlobalData.CurrentGlobalData!.UIS!.RecordedText == null)
                {

                }
                else if (GlobalData.CurrentGlobalData.UIS.RecordedText.Length > 0 /* && UIS.STTListeningOn != IUIServices.sttListeningMode.off */ )
                {
                    if (UIS.MCMVVisible == true)
                    {
                        int key = 0;

                        if ((String.Compare(UIS.RecordedText, "eins", StringComparison.OrdinalIgnoreCase) == 0)
                            || (String.Compare(UIS.RecordedText, "1", StringComparison.OrdinalIgnoreCase) == 0)
                            || (String.Compare(UIS.RecordedText, "one", StringComparison.OrdinalIgnoreCase) == 0)
                            || (String.Compare(UIS.RecordedText, "erstens", StringComparison.OrdinalIgnoreCase) == 0)
                            || (String.Compare(UIS.RecordedText, "uno", StringComparison.OrdinalIgnoreCase) == 0)
                            || (String.Compare(UIS.RecordedText, "oans", StringComparison.OrdinalIgnoreCase) == 0)
                            )
                        {
                            key = '1';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "zwei", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "2", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "two", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "zweitens", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "zwotens", StringComparison.OrdinalIgnoreCase) == 0)
                       || (String.Compare(UIS.RecordedText, "dos", StringComparison.OrdinalIgnoreCase) == 0)
                       )
                        {
                            key = '2';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "drei", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "3", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "three", StringComparison.OrdinalIgnoreCase) == 0)
                       || (String.Compare(UIS.RecordedText, "tres", StringComparison.OrdinalIgnoreCase) == 0)
                       || (String.Compare(UIS.RecordedText, "drittens", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = '3';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "vier", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "4", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "four", StringComparison.OrdinalIgnoreCase) == 0)
                       || (String.Compare(UIS.RecordedText, "viertens", StringComparison.OrdinalIgnoreCase) == 0)
                       || (String.Compare(UIS.RecordedText, "quatro", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = '4';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "fünf", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "5", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "five", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "fünftens", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "cinco", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = '5';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "sechs", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "6", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "six", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "sex", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "seis", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "sechstens", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = '6';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "sieben", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "7", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "seven", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "siete", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "siebtens", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = '7';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "acht", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "8", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "eight", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "ocho", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "achtens", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = '8';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "neun", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "9", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "nine", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "nueve", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "neuntens", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = '9';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "null", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "0", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "zero", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "nulltens", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = '0';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "a", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "ah", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe a", StringComparison.OrdinalIgnoreCase) == 0)
                          || (String.Compare(UIS.RecordedText, "Aachen", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Anton", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Alfa", StringComparison.OrdinalIgnoreCase) == 0)
                         || (String.Compare(UIS.RecordedText, "Alpha", StringComparison.OrdinalIgnoreCase) == 0)
                         || (String.Compare(UIS.RecordedText, "Albert", StringComparison.OrdinalIgnoreCase) == 0)
                         || (String.Compare(UIS.RecordedText, "Augsburg", StringComparison.OrdinalIgnoreCase) == 0)
                     )
                        {
                            key = 'a';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "b", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "be", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe b", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Berlin", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Berta", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Bravo", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Bernhard", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Bruno", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'b';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "c", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "ce", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe c", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Chemnitz", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Cäsar", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Caesar", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Charlie", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Cottbus", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'c';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "d", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "de", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe d", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Düsseldorf", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Dora", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Delta", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "David", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Dortmund", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'd';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "e", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "e", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe e", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Essen", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Emil", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Echo", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'e';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "f", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "ef", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe f", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Frankfurt", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Friedrich", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Foxtrott", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Fritz", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'f';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "g", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "g", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe g", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Goslar", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Gustav", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Golf", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Görlitz", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'g';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "h", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "ha", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe h", StringComparison.OrdinalIgnoreCase) == 0)
                          || (String.Compare(UIS.RecordedText, "Hamburg", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Heinrich", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Hotel", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Heinz", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Hannover", StringComparison.OrdinalIgnoreCase) == 0)
                      )
                        {
                            key = 'h';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "i", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "i", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe i", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Ingelheim", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Ida", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "India", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Isidor", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Iserlohn", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'i';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "j", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "jot", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe j", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Jena", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Julius", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Juliett", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Juliette", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Jacob", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'j';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "k", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "ka", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe k", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Köln", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Kaufmann", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Kilo", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Karl", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Katharina", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Kurfürst", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Konrad", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'k';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "l", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "el", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe l", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Leipzig", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Ludwig", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Lima", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'l';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "m", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "em", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe m", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "München", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Martha", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Mike", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Marie", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'm';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "n", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "en", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe n", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Nürnberg", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Nordpol", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "November", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Nathan", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Norbert", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'n';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "o", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "o", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe o", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Offenbach", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Otto", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Oscar", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Oldenburg", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'o';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "p", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "pe", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe p", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Potsdam", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Paula", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Papa", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Paul", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'p';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "q", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "kuh", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe q", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Quickborn", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Quelle", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Quebec", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'q';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "r", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "er", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe r", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Rostock", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Richard", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Romeo", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Regensburg", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'r';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "s", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "es", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe s", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Salzwedel", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Samuel", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Sierra", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Siegfried", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Stuttgart", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 's';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "t", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "te", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe te", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Tübingen", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Theodor", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Tango", StringComparison.OrdinalIgnoreCase) == 0)
                         || (String.Compare(UIS.RecordedText, "Toni", StringComparison.OrdinalIgnoreCase) == 0)
                      )
                        {
                            key = 't';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "u", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "u", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe u", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Unna", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Ulrich", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Uniform", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'u';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "v", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "vau", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe v", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Völklingen", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Viktor", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Victor", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'v';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "w", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "weh", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe w", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Wuppertal", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Wilhelm", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Whiskey", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'w';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "x", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "ix", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe x", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Xanten", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Xanthippe", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "X-Ray", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'x';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "y", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "ypsilon", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe y", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Ypsilon", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Yankee", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Ypern", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'y';
                        }
                        else
                        if ((String.Compare(UIS.RecordedText, "z", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "zett", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Buchstabe z", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Zwickau", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Zacharias", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Zulu", StringComparison.OrdinalIgnoreCase) == 0)
                        || (String.Compare(UIS.RecordedText, "Zeppelin", StringComparison.OrdinalIgnoreCase) == 0)
                        )
                        {
                            key = 'z';
                        }
                        else
                        {

                        }

                        if (key > 0)
                        {
                            int ix = 0;
                            bool found = false;
                            for (ix = 0; ix < UIS.MCM!.Current!.Count; ix++)
                            {
                                if (UIS.MCM.Current[ix] > 0)
                                {
                                    MCMenuEntry? me = UIS.MCM.FindID(UIS.MCM.Current[ix]);
                                    if (me!.Keys!.Count > 0)
                                    {
                                        if (me.Keys[0] == key && me.Hidden == MCMenuEntry.HiddenType.visible)
                                        {
                                            UIS.MCMV!.CallBackMCMenuView(me.ID);
                                            found = true;
                                        }
                                    }

                                }
                                if (found)
                                    break;
                            }
                        }
                        UIS.RecordedText = "";
                    }
                    else if (Grid_More.IsVisible == true)
                    {
                        GlobalData.AddLog("PageDown by Voice", IGlobalData.protMode.crisp);
                        UIS.Scr.PageDown();
                        UIS.RecordedText = "";
                    }
                    else
                    {
                        UIS.UpdateBrowserCallsPerCycle = 0;

                        GD.OrderList!.DisableTempOrderList();
                        GD.Adventure!.SetStoryLine = false;
                        GD.Adventure!.DoGameLoop(UIS.RecordedText!);
                        UIS!.StoryTextObj!.AdvTextRefresh();
#if !NEWSCROLL

                    UIS!.Scr.SetScrollerToEnd();
#endif
                        SetInputFocus();
                        UIS.RecordedText = "";
                    }

                    // 
                    if (UIS.STTListeningOn == IUIServices.sttListeningMode.continuous)
                    {
                        UIS.STTStopListening(false);
                        UIS.STTStartListening(IUIServices.sttListeningMode.continuous);
                    }
                    else
                    {
                        UIS.STTStopListening(false);
                        // UIS.STTStartListening(IUIServices.sttListeningMode.on);
                    }
                }

            }


            if (CountDebugLoops < 250)
            {
                CountDebugLoops++;
                // if (CountDebugLoops % 10 == 0)
                {
                    TabItem.TabPanel tp0 = TIRightUp!.TabPanels[0];
                    TabItem.TabPanel tp1 = TIRightUp!.TabPanels[1];
                    TabItem.TabPanel tp2 = TIRightUp!.TabPanels[2];


                    TreeView? tvOrder = null;

                    tvOrder = CreateOrderTree();
                    TreeView.EmptyTreeViewItem(tp0.TabPanelGrid!.Children[0]);
                    tp0.TabPanelGrid!.Children[0] = tvOrder;

                    tvOrder = CreateItemLocTree();
                    TreeView.EmptyTreeViewItem(tp1.TabPanelGrid!.Children[0]);
                    tp1.TabPanelGrid!.Children[0] = tvOrder;

                    tvOrder = CreateItemInvTree();
                    TreeView.EmptyTreeViewItem(tp2.TabPanelGrid!.Children[0]);
                    tp2.TabPanelGrid!.Children[0] = tvOrder;

                }
            }
            else if (CountDebugLoops == 250)
            {
                TabItem.TabPanel tp0 = TIRightUp!.TabPanels[0];
                TabItem.TabPanel tp1 = TIRightUp!.TabPanels[1];
                TabItem.TabPanel tp2 = TIRightUp!.TabPanels[2];
                TreeView? tvOrder = null;

                TreeView.EmptyTreeViewItem(tp0.TabPanelGrid!.Children[0]);
                TreeView.EmptyTreeViewItem(tp1.TabPanelGrid!.Children[0]);
                TreeView.EmptyTreeViewItem(tp2.TabPanelGrid!.Children[0]);

                GC.Collect();
            }
        }
        catch( Exception ex)
        {

        }
        return true;
    }

    protected  override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {

#if WINDOWS
        ResetKeyboardHandler();
#endif
        _menuExtension!.RemoveListCall(DoSpeech);

        UIS.STTStopListening();
        if (Inputline.IsSoftKeyboardShowing() == true)
            Inputline.HideKeyboardAsync(CancellationToken.None);

        GD.SetDelProvideMCGrid(null!);
        GD.SetDelProvideMoreGrid(null);
        GD.SetDelSelectOutput(null);

        UIS!.SetMCMVVisibleCallback(null!);
        UIS!.SetScoreMethod(null!);
        UIS!.SetScoreEpisode(null!);
        UIS!.SetLocalUIUpdate(null!);
        UIS.STTListenigModeChangeCB = null;

        GlobalSpecs.CurrentGlobalSpecs!.SetCurrentPage(null!);
        GlobalData.CurrentGlobalData!.FocusMethod = null;
        _menuExtension!.RemoveLocalMethod(DoGamePageMenu);
    }
#if WINDOWS
    private static readonly System.Lazy<bool> _isPackagedAppLazy = new System.Lazy<bool>(() =>
    {
        try
        {
            if (Windows.ApplicationModel.Package.Current != null)
                return true;
        }
        catch
        {
            // no-op
        }

        return false;
    });

    private static bool IsPackagedApp => _isPackagedAppLazy.Value;

    // Allow for packaged/unpackaged app support
    string ApplicationPath => IsPackagedApp
        ? Windows.ApplicationModel.Package.Current.InstalledLocation.Path
        : System.AppContext.BaseDirectory;
#endif
    private void UpdateMessage(object? sender, EventArgs e)
    {
         if (Inputline.Text != null && Inputline.Text != "" )
        {
            try
            {
                GD.OrderList!.DisableTempOrderList();
                if( GD.LayoutDescription.ParagraphClusterMode != ILayoutDescription.ParagraphClusters.none)
                    UIS!.StoryTextObj!.DividingLine();
                else
                    UIS!.StoryTextObj!.NotDividingLine();

                UIS!.UpdateBrowserCallsPerCycle = 0;
                GlobalData.CurrentGlobalData!.Adventure!.DoGameLoop(Inputline.Text!);
                // UIS!.Scr.PageDown();
            }
            catch // ( Exception ex)
            {
                // int a = 5;
            }
  
            // GlobalData.CurrentGlobalData!.Adventure!.UIS.Scr.ScrollPageFinal();
            // GlobalData.CurrentGlobalData!.Adventure!.UIS.UpdateBrowser();

            if( GlobalData.CurrentGlobalData!.FocusMethod != null )
                GlobalData.CurrentGlobalData!.FocusMethod();
            Inputline.Text = "";
        }
    }
    private bool CanUpdateMessage()
    {
        return true;
    }
    private void OnClickedTree(object? sender, TreeViewEventArgs e)
    {
        if (e.UserDefinedObject != null)
        {
            // int a = 5;
        }
    }



    public WebViewInterop.BridgedWebView ExternalGameOut()
    {
        return GameOut;
    }

    private async void WebView_HandlerChanged(object? sender, EventArgs e)
    {
        try
        {
#if WINDOWS
            await ((sender as WebView)!.Handler!.PlatformView as Microsoft.Maui.Platform.MauiWebView)!.EnsureCoreWebView2Async();
            ((sender as WebView)!.Handler!.PlatformView as Microsoft.Maui.Platform.MauiWebView)!.CoreWebView2!.SetVirtualHostNameToFolderMapping(
                    "localhost",
                    ApplicationPath,
                    Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow);
            ((sender as WebView)!.Handler!.PlatformView as Microsoft.Maui.Platform.MauiWebView)!.LoadUrl($"https://localhost/empty.html");
#endif
        }
        catch (Exception ex)
        {
        }
    }
    async void OnLoadHtmlFileClicked(object? sender, EventArgs e)
    {
        try
        { 
            await LoadMauiAsset();
        }
        catch (Exception ex)
        {
        }
    }

    async Task LoadMauiAsset()
    {
        /*
         using var stream = await FileSystem.OpenAppPackageFileAsync(input.Text.Trim());
        using var reader = new StreamReader(stream);

        var html = reader.ReadToEnd();
        FileWebView.Source = new HtmlWebViewSource { Html = html };
        */
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
    public Grid WebView_Grid()
    {
        return GridWebView;
     }
    public Grid Page_Grid()
    {
        return PageGrid;
    }
    public Button GetMenuButton()
    {
        return MenuButton;
     }

    private void WebViewNavigation(object? sender, WebNavigatingEventArgs e)
    {
        // int a = 5;
    }
    private void ButtonMoreClicked(object? sender, EventArgs e)
    {
        GlobalData.AddLog("PageDown by More", IGlobalData.protMode.crisp);

        UIS.Scr.PageDown();
         // int a = 5;
    }
    private async void Clicked_Keyboard( object? sender, EventArgs e)
    {
        try
        {
            if (Inputline.IsSoftKeyboardShowing() == false)
            {
                await Inputline.ShowKeyboardAsync(CancellationToken.None);
                ForceInputFocus();
            }
            else
                await Inputline.HideKeyboardAsync(CancellationToken.None);
        }
        catch (Exception ex)
        {
        }
    }

    private async void Clicked_Microphone(object? sender, EventArgs e)
    {
        try
        {
            if (UIS.STTListeningOn == IUIServices.sttListeningMode.off)
            {
                if (GD.STTMicroState == IGlobalData.microMode.continuous)
                {
                    // Mike.Background = Colors.Red;
                    await UIS.STTStartListening(IUIServices.sttListeningMode.continuous);
                }
                else if (GD.STTMicroState == IGlobalData.microMode.once)
                {
                    // Mike.Background = Colors.Yellow;
                    await UIS.STTStartListening(IUIServices.sttListeningMode.on);

                }
                // doListening = true;
            }
            else
            {
                await UIS.STTStopListening();
                UIS.STTListeningOn = IUIServices.sttListeningMode.off;
                // Mike.Background = Colors.Transparent;
            }
        }
        catch (Exception ex)
        {
        }

    }
    private async void Clicked_Microphone2(object? sender, EventArgs e)
    {
        try
        {
            if (UIS.STTListeningOn == IUIServices.sttListeningMode.off)
            {
                if (GD.STTMicroState == IGlobalData.microMode.continuous)
                {
                    // Mike.Background = Colors.Red;
                    await UIS.STTStartListening(IUIServices.sttListeningMode.continuous);
                }
                else if (GD.STTMicroState == IGlobalData.microMode.once)
                {
                    // Mike.Background = Colors.Yellow;
                    await UIS.STTStartListening(IUIServices.sttListeningMode.on);

                }
                // doListening = true;
            }
            else
            {
                await UIS.STTStopListening();
                UIS.STTListeningOn = IUIServices.sttListeningMode.off;
                // Mike.Background = Colors.Transparent;
            }
        }
        catch (Exception ex)
        {
        }

    }
    private async void Clicked_Microphone3(object? sender, EventArgs e)
    {
        try
        {
            if (UIS.STTListeningOn == IUIServices.sttListeningMode.off)
            {
                if (GD.STTMicroState == IGlobalData.microMode.continuous)
                {
                    // Mike.Background = Colors.Red;
                    await UIS.STTStartListening(IUIServices.sttListeningMode.continuous);
                }
                else if (GD.STTMicroState == IGlobalData.microMode.once)
                {
                    // Mike.Background = Colors.Yellow;
                    await UIS.STTStartListening(IUIServices.sttListeningMode.on);

                }
                // doListening = true;
            }
            else
            {
                await UIS.STTStopListening();
                UIS.STTListeningOn = IUIServices.sttListeningMode.off;
                // Mike.Background = Colors.Transparent;
            }
        }
        catch (Exception ex)
        {
        }

    }
    /*
    string recordedText = "";
    async Task StartListening(CancellationToken cancellationToken)
    {
        try
        {
            var isGranted = await SpeechToText.RequestPermissions(cancellationToken);
            if (!isGranted)
            {
                await Toast.Make("Permission not granted").Show(CancellationToken.None);
                return;
            }

            recordedText = "";

            SpeechToText.Default.RecognitionResultUpdated += OnRecognitionTextUpdated;
            SpeechToText.Default.RecognitionResultCompleted += OnRecognitionTextCompleted;

            if (GD.Language == IGlobalData.language.german)
            {
                await SpeechToText.StartListenAsync(CultureInfo.GetCultureInfo("de-de"), CancellationToken.None);

            }
            else
            {
                 await SpeechToText.StartListenAsync(CultureInfo.GetCultureInfo("en-en"), CancellationToken.None);


            }
        }
        catch ( Exception e )
        {

        }
    }

    async Task StopListening(CancellationToken cancellationToken)
    {
        try
        {

            await SpeechToText.StopListenAsync(CancellationToken.None);
            SpeechToText.Default.RecognitionResultUpdated -= OnRecognitionTextUpdated;
            SpeechToText.Default.RecognitionResultCompleted -= OnRecognitionTextCompleted;
            Inputline.Text += recordedText;
            recordedText = "";
            Mike.Background = Colors.Green;


        }
        catch (Exception e)
        {

        }
    }

    void OnRecognitionTextUpdated(object? sender, SpeechToTextRecognitionResultUpdatedEventArgs args)
    {
        try
        {
            recordedText += args.RecognitionResult;
            // args.RecognitionResult = "";
            if (Inputline.Text == null) 
                Inputline.Text = "";
        }
        catch( Exception e )
        {

        }
    }

    void OnRecognitionTextCompleted(object? sender, SpeechToTextRecognitionResultCompletedEventArgs args)
    {
        try
        {
            recordedText += args.RecognitionResult;
            if (Inputline.Text == null) Inputline.Text = "";
            Inputline.Text += recordedText;
            recordedText = "";
            StopListening(CancellationToken.None).Wait();
            doListening = false;
            EventArgs ea = new();
            UpdateMessage(null, ea);
        }
        catch( Exception e)
        {

        }
    }
    */
    public IUIServices GetUIServices()
    {
        return UIS;
    }
    public AbsoluteLayout GetAbsoluteLayout()
    {
        return AbsoluteLayer;
    }
    public Label GetMenuTitle()
    {
        return WindowTitle;
    }

    void SetStarToAbsolute()
    {
        if( GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() > GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() )
        {
            GlobalData.CurrentGlobalData!.LayoutDescription.ScreenMode = (IGlobalData.screenMode) IGlobalData.screenMode.landscape;
        }
        else
        {
            GlobalData.CurrentGlobalData!.LayoutDescription.ScreenMode = (IGlobalData.screenMode)IGlobalData.screenMode.portrait;

        }
        if (GlobalSpecs.CurrentGlobalSpecs.GetScreenMode() == IGlobalData.screenMode.landscape)
        {
            ColumnDefinitionCollection cdc = MenuGridMenuInner.ColumnDefinitions;
            if (cdc[2].Width.IsAbsolute == true)
                return;


            double x1 = 200;
            double x2 = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth - 400;
            double x3 = 200;

            cdc[0].Width = new GridLength(x1, GridUnitType.Absolute);
            cdc[2].Width = new GridLength(x2, GridUnitType.Absolute);
            cdc[4].Width = new GridLength(x3, GridUnitType.Absolute);

            RowDefinitionCollection rdc = PageGrid.RowDefinitions;
            rdc[2].Height = new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - _headlineHeight);

            rdc = MenuGridMenuBackground.RowDefinitions;
            rdc[1].Height = new GridLength(PageGrid.RowDefinitions[2].Height.Value);

            rdc = MenuGridMenuVertical.RowDefinitions;
            rdc[1].Height = new GridLength(PageGrid.RowDefinitions[2].Height.Value);

            rdc = Grid_Output.RowDefinitions;
            rdc[0].Height = new GridLength(PageGrid.RowDefinitions[2].Height.Value - _inputGridHeight);
            AdaptGridHeights();
        }
        else
        {
            return;
            /*
            ColumnDefinitionCollection cdc = MenuGridMenuInner.ColumnDefinitions;
            if (cdc[2].Width.IsAbsolute == true)
                return;


            double x1 = 200;
            double x2 = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth - 400;
            double x3 = 200;

            cdc[0].Width = new GridLength(x1, GridUnitType.Absolute);
            cdc[2].Width = new GridLength(x2, GridUnitType.Absolute);
            cdc[4].Width = new GridLength(x3, GridUnitType.Absolute);

            RowDefinitionCollection rdc = PageGrid.RowDefinitions;
            rdc[2].Height = new GridLength(GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - _headlineHeight);

            rdc = MenuGridMenuBackground.RowDefinitions;
            rdc[1].Height = new GridLength(PageGrid.RowDefinitions[2].Height.Value);

            rdc = MenuGridMenuVertical.RowDefinitions;
            rdc[1].Height = new GridLength(PageGrid.RowDefinitions[2].Height.Value);

            rdc = Grid_Output.RowDefinitions;
            rdc[0].Height = new GridLength(PageGrid.RowDefinitions[2].Height.Value - _inputGridHeight);
            */
        }
    }


    void OnTappedGridLeft( object? sender, TappedEventArgs tea )
    {
        Grid g = new();
        OnTappedGridHorizontal(sender, tea, onPanGridSplitterButtonLeft!);
    }
    void OnTappedGridRight(object? sender, TappedEventArgs tea)
    {
        OnTappedGridHorizontal(sender, tea, onPanGridSplitterButtonRight!);
    }
    void OnTappedGridVLeft(object? sender, TappedEventArgs tea)
    {
        OnTappedGridVertical(sender, tea, onPanVGridSplitterButtonLeft!);
    }

    void OnEnterGrid( object? sender, Microsoft.Maui.Controls.PointerEventArgs pea)
    {
#if WINDOWS
        var nativeElement = (sender as Grid)!.Handler!.GetNativeElement();
        (nativeElement as Microsoft.UI.Xaml.UIElement)!.ChangeCursor(Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.SizeNorthSouth));
#endif
    }
    void OnEnterGridVertical(object? sender, Microsoft.Maui.Controls.PointerEventArgs pea)
    {
#if WINDOWS
        var nativeElement = (sender as Grid)!.Handler!.GetNativeElement();
        (nativeElement as Microsoft.UI.Xaml.UIElement)!.ChangeCursor(Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.SizeNorthSouth));
#endif
    }
    void OnEnterGridHorizontal(object? sender, Microsoft.Maui.Controls.PointerEventArgs pea)
    {
#if WINDOWS
        var nativeElement = (sender as Grid)!.Handler!.GetNativeElement();
        (nativeElement as Microsoft.UI.Xaml.UIElement)!.ChangeCursor(Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.SizeWestEast));
#endif
    }
    void OnExitGrid(object? sender, Microsoft.Maui.Controls.PointerEventArgs pea)
    {
#if WINDOWS
        var nativeElement = (sender as Grid)!.Handler!.GetNativeElement();
        (nativeElement as Microsoft.UI.Xaml.UIElement)!.ChangeCursor(Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.Arrow));
#endif
    }
    void OnEnterButtonCross(object? sender, Microsoft.Maui.Controls.PointerEventArgs pea)
    {
#if WINDOWS
        var nativeElement = (sender as Button)!.Handler!.GetNativeElement();
        (nativeElement as Microsoft.UI.Xaml.UIElement)!.ChangeCursor(Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.Cross));
#endif
    }
    void OnEnterButtonHand(object? sender, Microsoft.Maui.Controls.PointerEventArgs pea)
    {
#if WINDOWS
        var nativeElement = (sender as Button)!.Handler!.GetNativeElement();
        (nativeElement as Microsoft.UI.Xaml.UIElement)!.ChangeCursor(Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.Hand));
#endif
    }
    void OnExitButton(object? sender, Microsoft.Maui.Controls.PointerEventArgs pea)
    {
#if WINDOWS
        var nativeElement = (sender as Button)!.Handler!.GetNativeElement();
        (nativeElement as Microsoft.UI.Xaml.UIElement)!.ChangeCursor(Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.Arrow));
#endif
    }

    void SetButtonCursorHand(Button b)
    {
#if WINDOWS
        PointerGestureRecognizer pgr = new();
        pgr.PointerEntered += OnEnterButtonHand;
        pgr.PointerExited += OnExitButton;
        b.GestureRecognizers.Add(pgr);
#endif
    }
    void SetButtonCursorCross(Button b)
    {
#if WINDOWS
        PointerGestureRecognizer pgr = new();
        pgr.PointerEntered += OnEnterButtonCross;
        pgr.PointerExited += OnExitButton;
        b.GestureRecognizers.Add(pgr);
#endif
    }
    void OnTappedGridPortrait(object? sender, TappedEventArgs tea)
    {
        OnTappedGridVertical(sender, tea, onGridSplitterButtonPortrait);
    }
     void OnTappedGridVRight(object? sender, TappedEventArgs tea)
     {
       OnTappedGridVertical(sender, tea, onPanVGridSplitterButtonRight);
    }
     void OnTappedGridCol12(object? sender, TappedEventArgs tea)
     {
         OnTappedGridHorizontal(sender, tea, onPanCol12GridSplitterButtonRight);
     }
     void OnTappedGridCol23(object? sender, TappedEventArgs tea)
     {
        OnTappedGridHorizontal(sender, tea, onPanCol23GridSplitterButtonRight);
     }

    void OnTappedGridVertical(object? sender, TappedEventArgs tea, EventHandler<PanUpdatedEventArgs> pueh)
    {
        Point? p = tea.GetPosition(sender as Element);
        Rect? r = (sender as Grid)!.GetAbsoluteBounds();

        if (p.HasValue && r.HasValue)
        {
            List<string> styleLabel = new();
            styleLabel.Add("Label_Big");

            Label l1 = new();
            l1.StyleClass = styleLabel;
            l1.Text = FaSolid.ArrowsAltV;
            l1.TextColor = Colors.White;
            l1.FontFamily = "Fa-Solid";
            l1.VerticalOptions = LayoutOptions.Center;
            l1.HorizontalOptions = LayoutOptions.Center;
            l1.FontSize = 17;

            Frame f = new();
            List<string> style = new();
            style.Add("Frame_BGBG_FG");

            Thickness m = new();
            m.Bottom = 0;
            m.Top = 0;
            m.Left = 0;
            m.Right = 0;
            l1.Margin = m;
            l1.Padding = m;

            f.StyleClass = style;
            f.CornerRadius = 90;
            f.Content = l1;
            f.ZIndex = 300;
            f.VerticalOptions = LayoutOptions.FillAndExpand;
            f.HorizontalOptions = LayoutOptions.FillAndExpand;

            Rect lb = new();
            lb.Left = p.Value.X + r.Value.Left - 30;
            lb.Right = p.Value.X + r.Value.Left + 30;
            lb.Top = p.Value.Y + r.Value.Top - 30;
            lb.Bottom = p.Value.Y + r.Value.Top + 30;


            Grid gridx = new Grid();
            gridx.IsVisible = true;
            gridx.BackgroundColor = Colors.Black;
            gridx.Opacity = 0.3;
            gridx.VerticalOptions = LayoutOptions.FillAndExpand;
            gridx.HorizontalOptions = LayoutOptions.FillAndExpand;
            gridx.WidthRequest = PageGrid.Width;
            gridx.HeightRequest = PageGrid.Height;
            gridx.ZIndex = 200;


            TapGestureRecognizer tgr = new();
            tgr.NumberOfTapsRequired = 1;
            tgr.Tapped += (s, e) =>
            {
                AbsoluteLayer.Remove(gridx);
                AbsoluteLayer.Remove(f);
                AbsoluteLayer.InputTransparent = true;


                // Handle the tap
            };
            gridx.GestureRecognizers.Add(tgr);
            TapGestureRecognizer tgr2 = new();
            tgr2.NumberOfTapsRequired = 1;
            tgr2.Tapped += (s, e) =>
            {
                AbsoluteLayer.Remove(gridx);
                AbsoluteLayer.Remove(f);
                AbsoluteLayer.InputTransparent = true;


                // Handle the tap
            };
            f.GestureRecognizers.Add(tgr2);

            AbsoluteLayer.Add(gridx);

            AbsoluteLayer.Add(f);
            AbsoluteLayer.SetLayoutBounds(f, lb);
            AbsoluteLayer.InputTransparent = false;

            PanGestureRecognizer pgr = new();
            pgr.PanUpdated += pueh;
            f.GestureRecognizers.Add(pgr);
        }
    }

    void OnTappedGridHorizontal(object? sender, TappedEventArgs tea, EventHandler<PanUpdatedEventArgs>? pueh)
    {

        Point? p = tea.GetPosition(sender as Element);
        Rect? r = (sender as Grid)!.GetAbsoluteBounds();

        if (p.HasValue && r.HasValue)
        {
            List<string> styleLabel = new();
            styleLabel.Add("Label_Big");

            Label l1 = new();
            l1.StyleClass = styleLabel;
            l1.Text = FaSolid.ArrowsAltH;
            l1.TextColor = Colors.White;
            l1.FontFamily = "Fa-Solid";
            l1.VerticalOptions = LayoutOptions.Center;
            l1.HorizontalOptions = LayoutOptions.Center;
            l1.FontSize = 17;

            Frame f = new();
            List<string> style = new();
            style.Add("Frame_BGBG_FG");

            Thickness m = new();
            m.Bottom = 0;
            m.Top = 0;
            m.Left = 0;
            m.Right = 0;
            l1.Margin = m;
            l1.Padding = m;

            f.StyleClass = style;
            f.CornerRadius = 50;
            f.Content = l1;
            f.ZIndex = 300;
            f.VerticalOptions = LayoutOptions.FillAndExpand;
            f.HorizontalOptions = LayoutOptions.FillAndExpand;
            f.InputTransparent = false;

            Rect lb = new();
            lb.Left = p.Value.X + r.Value.Left - 30;
            lb.Right = p.Value.X + r.Value.Left + 30;
            lb.Top = p.Value.Y + r.Value.Top - 30;
            lb.Bottom = p.Value.Y + r.Value.Top + 30;


            Grid gridx = new Grid();
            gridx.IsVisible = true;
            gridx.InputTransparent = false;
            gridx.BackgroundColor = Colors.Black;
            gridx.Opacity = 0.3;
            gridx.VerticalOptions = LayoutOptions.FillAndExpand;
            gridx.HorizontalOptions = LayoutOptions.FillAndExpand;
            gridx.WidthRequest = PageGrid.Width;
            gridx.HeightRequest = PageGrid.Height;
            gridx.ZIndex = 200;


            TapGestureRecognizer tgr = new();
            tgr.NumberOfTapsRequired = 1;
            tgr.Tapped += (s, e) =>
            {
                AbsoluteLayer.Remove(gridx);
                AbsoluteLayer.Remove(f);
                AbsoluteLayer.InputTransparent = true;


                // Handle the tap
            };
            gridx.GestureRecognizers.Add(tgr);
            TapGestureRecognizer tgr2 = new();
            tgr2.NumberOfTapsRequired = 1;
            tgr2.Tapped += (s, e) =>
            {
                AbsoluteLayer.Remove(gridx);
                AbsoluteLayer.Remove(f);
                AbsoluteLayer.InputTransparent = true;


                // Handle the tap
            };
            f.GestureRecognizers.Add(tgr2);

            AbsoluteLayer.Add(gridx);

            AbsoluteLayer.Add(f);
            AbsoluteLayer.SetLayoutBounds(f, lb);
            AbsoluteLayer.InputTransparent = false;

            PanGestureRecognizer pgr = new();
            pgr.PanUpdated += pueh;
            f.GestureRecognizers.Add(pgr);
        }
    }

    double xSplitter = 0;
    double ySplitter = 0;
    double xSplitterStart = 0;
    double ySplitterStart = 0;
    double GridMainShare;
    double GridSplitShare;

    // List<double> XValues3 = new();
    // List<double> XValues5 = new();
    // List<double> XValuesTotal = new();
    // List<double> XValuesMove = new();

    void onPanGridSplitterButtonLeft(object? sender, PanUpdatedEventArgs puea)
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
        DoHorizontalSplitterButton(sender, puea, MenuGridMenuInner, 2, 0, ld.SetLeftColumnWidth);
    }
    void onPanGridSplitterButtonRight(object? sender, PanUpdatedEventArgs puea)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription!;
        DoHorizontalSplitterButton(sender, puea, MenuGridMenuInner, 2, 4, ld.SetRightColumnWidth);
    }

    
    void DoHorizontalSplitterButton(object? sender, PanUpdatedEventArgs puea, Grid SplitRow, int colMain, int colSplit, DelDouble SetWidth)
    {
        // Rect lb;
        ColumnDefinitionCollection cdc;
        double xMove;
        double x;
        double widthStar;
        double xShare;
        double xTotal;
        GridLength xMainNew;
        GridLength xSplitNew;
        // Thickness m;

        switch (puea.StatusType)
        {
            case GestureStatus.Started:

                SetStarToAbsolute();

                Rect? r = (sender as View)!.GetAbsoluteBounds();

                if (r.HasValue)
                {
                    xSplitter = r.Value.Left;
                    ySplitter = r.Value.Top;

                    xSplitterStart = r.Value.Left;
                    ySplitterStart = r.Value.Top;
                }
                // cdc = MenuGridMenuInner.ColumnDefinitions;
                cdc = SplitRow.ColumnDefinitions;
                GridMainShare = cdc[colMain].Width.Value;
                GridSplitShare = cdc[colSplit].Width.Value;
                break;
            case GestureStatus.Running:
                {
#if WINDOWS
                    Rect r2 = AbsoluteLayer.GetLayoutBounds(sender as View);

                    r2.X = xSplitter + puea.TotalX;
                    r2.Y = ySplitter + puea.TotalY;
                    AbsoluteLayer.SetLayoutBounds(sender as View, r2);
                    try
                    {
                        xMove = puea.TotalX;

                        if (colMain > colSplit)
                        {
                            xMove *= -1;
                        }

                        // cdc = MenuGridMenuInner.ColumnDefinitions;
                        cdc = SplitRow.ColumnDefinitions;

                        x = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth - 30;

                        widthStar = cdc[0].Width.Value + cdc[colMain].Width.Value + cdc[colSplit].Width.Value;

                        xShare = (xMove / x) * widthStar;

                        xMainNew = new GridLength(GridMainShare + xShare, GridUnitType.Absolute);
                        xSplitNew = new GridLength(GridSplitShare - xShare, GridUnitType.Absolute);

                        xTotal = xMainNew.Value + xSplitNew.Value;

                        if (xMainNew.Value < 500)
                        {
                            xMainNew = new GridLength(500, GridUnitType.Absolute);
                            xSplitNew = new GridLength(xTotal - xMainNew.Value, GridUnitType.Absolute);
                        }
                        if (xSplitNew.Value < 100)
                        {
                            xSplitNew = new GridLength(100, GridUnitType.Absolute);
                            xMainNew = new GridLength(xTotal - xSplitNew.Value, GridUnitType.Absolute);
                        }


                        // XValues3.Add(xMainNew.Value);
                        // XValues5.Add(xSplitNew.Value);
                        // XValuesTotal.Add(xTotal);
                        // XValuesMove.Add(xMove);

                        cdc[colMain].Width = xMainNew;
                        cdc[colSplit].Width = xSplitNew;

                        SetWidth(xSplitNew.Value);
                    }
                    catch // (Exception e)
                    {
                        // int a = 5;
                    }

#elif ANDROID
                    // Positionierung Button
                    r = (sender as View)!.GetAbsoluteBounds();

                    if (r.HasValue)
                    {
                        xSplitter = r.Value.Left;
                        ySplitter = r.Value.Top;
                    }
                    Rect r2 = AbsoluteLayer.GetLayoutBounds(sender as View);

                    r2.X = xSplitter + puea.TotalX;
                    r2.Y = ySplitter + puea.TotalY;
                    AbsoluteLayer.SetLayoutBounds(sender as View, r2);

                    // Positionierung Grid
                    try
                    {
                        xMove = r2.X - xSplitterStart; // puea.TotalX;

                        if (colMain > colSplit)
                        {
                            xMove *= -1;
                        }

                        cdc = MenuGridMenuInner.ColumnDefinitions;

                        x = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth - 10;

                        widthStar = cdc[0].Width.Value + cdc[2].Width.Value + cdc[4].Width.Value;

                        xShare = (xMove / x) * widthStar;

                        xMainNew = new GridLength(GridMainShare + xShare, GridUnitType.Absolute);
                        xSplitNew = new GridLength(GridSplitShare - xShare, GridUnitType.Absolute);

                        xTotal = xMainNew.Value + xSplitNew.Value;

                        if (xMainNew.Value < 500)
                        {
                            xMainNew = new GridLength(500, GridUnitType.Absolute);
                            xSplitNew = new GridLength(xTotal - xMainNew.Value, GridUnitType.Absolute);
                        }
                        if (xSplitNew.Value < 100)
                        {
                            xSplitNew = new GridLength(100, GridUnitType.Absolute);
                            xMainNew = new GridLength(xTotal - xSplitNew.Value, GridUnitType.Absolute);
                        }


                        // XValues3.Add(xMainNew.Value);
                        // XValues5.Add(xSplitNew.Value);
                        // XValuesTotal.Add(xTotal);
                        // XValuesMove.Add(xMove);

                        cdc[colMain].Width = xMainNew;
                        cdc[colSplit].Width = xSplitNew;
                        SetWidth(xSplitNew.Value);
                    }
                    catch // (Exception e)
                    {
                        // int a = 5;
                    }
#endif

                }
                break;
            case GestureStatus.Completed:
                {

                }
                break;
        }

        // Handle the pan
    }

    
    void DoColumnSplitterButton(object? sender, PanUpdatedEventArgs puea, Grid SplitRow, int colMain, int colSplit, DelDouble SetWidth)
    {
        // Rect lb;
        ColumnDefinitionCollection cdc;
        double xMove;
        double x;
        double widthStar;
        double xShare;
        double xTotal;
        GridLength xMainNew;
        GridLength xSplitNew;
        // Thickness m;

        switch (puea.StatusType)
        {
            case GestureStatus.Started:

                SetStarToAbsolute();

                Rect? r = (sender as View)!.GetAbsoluteBounds();

                if (r.HasValue)
                {
                    xSplitter = r.Value.Left;
                    ySplitter = r.Value.Top;

                    xSplitterStart = r.Value.Left;
                    ySplitterStart = r.Value.Top;
                }
                // cdc = MenuGridMenuInner.ColumnDefinitions;
                cdc = SplitRow.ColumnDefinitions;
                GridMainShare = cdc[colMain].Width.Value;
                GridSplitShare = cdc[colSplit].Width.Value;
                break;
            case GestureStatus.Running:
                {
#if WINDOWS
                    Rect r2 = AbsoluteLayer.GetLayoutBounds(sender as View);

                    r2.X = xSplitter + puea.TotalX;
                    r2.Y = ySplitter + puea.TotalY;
                    AbsoluteLayer.SetLayoutBounds(sender as View, r2);
                    try
                    {
                        xMove = puea.TotalX;

                        if (colMain > colSplit)
                        {
                            xMove *= -1;
                        }

                        // cdc = MenuGridMenuInner.ColumnDefinitions;
                        cdc = SplitRow.ColumnDefinitions;

                        x = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth - 30;

                        widthStar = cdc[0].Width.Value + cdc[colMain].Width.Value + cdc[colSplit].Width.Value;

                        xShare = (xMove / x) * widthStar;

                        xMainNew = new GridLength(GridMainShare + xShare, GridUnitType.Absolute);
                        xSplitNew = new GridLength(GridSplitShare - xShare, GridUnitType.Absolute);

                        xTotal = xMainNew.Value + xSplitNew.Value;

                        if (xMainNew.Value < 100)
                        {
                            xMainNew = new GridLength(100, GridUnitType.Absolute);
                            xSplitNew = new GridLength(xTotal - xMainNew.Value, GridUnitType.Absolute);
                        }
                        if (xSplitNew.Value < 100)
                        {
                            xSplitNew = new GridLength(100, GridUnitType.Absolute);
                            xMainNew = new GridLength(xTotal - xSplitNew.Value, GridUnitType.Absolute);
                        }


                        // XValues3.Add(xMainNew.Value);
                        // XValues5.Add(xSplitNew.Value);
                        // XValuesTotal.Add(xTotal);
                        // XValuesMove.Add(xMove);

                        cdc[colMain].Width = xMainNew;
                        cdc[colSplit].Width = xSplitNew;

                        if( colMain == 2 && colSplit == 0 )
                        {
                            LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
                            ld.PortraitColumn1Width = xSplitNew.Value;
                            ld.PortraitColumn2Width = xMainNew.Value;

                        }
                        else if (colMain == 2 && colSplit == 4)
                        {
                            LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
                            ld.PortraitColumn3Width = xSplitNew.Value;
                            ld.PortraitColumn2Width = xMainNew.Value;

                        }

                        SetWidth(xSplitNew.Value);
                    }
                    catch // (Exception e)
                    {
                        // int a = 5;
                    }

#elif ANDROID
                    // Positionierung Button
                    r = (sender as View)!.GetAbsoluteBounds();

                    if (r.HasValue)
                    {
                        xSplitter = r.Value.Left;
                        ySplitter = r.Value.Top;
                    }
                    Rect r2 = AbsoluteLayer.GetLayoutBounds(sender as View);

                    r2.X = xSplitter + puea.TotalX;
                    r2.Y = ySplitter + puea.TotalY;
                    AbsoluteLayer.SetLayoutBounds(sender as View, r2);

                    // Positionierung Grid
                    try
                    {
                        xMove = r2.X - xSplitterStart; // puea.TotalX;

                        if (colMain > colSplit)
                        {
                            xMove *= -1;
                        }

                        cdc = MenuGridMenuInner.ColumnDefinitions;

                        x = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth - 10;

                        widthStar = cdc[0].Width.Value + cdc[2].Width.Value + cdc[4].Width.Value;

                        xShare = (xMove / x) * widthStar;

                        xMainNew = new GridLength(GridMainShare + xShare, GridUnitType.Absolute);
                        xSplitNew = new GridLength(GridSplitShare - xShare, GridUnitType.Absolute);

                        xTotal = xMainNew.Value + xSplitNew.Value;

                        if (xMainNew.Value < 500)
                        {
                            xMainNew = new GridLength(500, GridUnitType.Absolute);
                            xSplitNew = new GridLength(xTotal - xMainNew.Value, GridUnitType.Absolute);
                        }
                        if (xSplitNew.Value < 100)
                        {
                            xSplitNew = new GridLength(100, GridUnitType.Absolute);
                            xMainNew = new GridLength(xTotal - xSplitNew.Value, GridUnitType.Absolute);
                        }


                        // XValues3.Add(xMainNew.Value);
                        // XValues5.Add(xSplitNew.Value);
                        // XValuesTotal.Add(xTotal);
                        // XValuesMove.Add(xMove);

                        cdc[colMain].Width = xMainNew;
                        cdc[colSplit].Width = xSplitNew;

                                                if( colMain == 2 && colSplit == 0 )
                        {
                            LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
                            ld.PortraitColumn1Width = xSplitNew.Value;
                            ld.PortraitColumn2Width = xMainNew.Value;

                        }
                        else if (colMain == 2 && colSplit == 4)
                        {
                            LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
                            ld.PortraitColumn3Width = xSplitNew.Value;
                            ld.PortraitColumn2Width = xMainNew.Value;

                        }

                        SetWidth(xSplitNew.Value);
                    }
                    catch // (Exception e)
                    {
                        // int a = 5;
                    }
#endif

                }
                break;
            case GestureStatus.Completed:
                {

                }
                break;
        }

        // Handle the pan
    }
    

    void onGridSplitterButtonPortrait(object? sender, PanUpdatedEventArgs puea)
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
        DoPortraitSplitterButton(sender, puea, MenuGridMenuVertical, 2, 0, ld.SetPortraitHeight);
    }
    void onPanVGridSplitterButtonLeft(object? sender, PanUpdatedEventArgs puea)
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
        DoVerticalSplitterButton(sender, puea, Grid_MC_Left, 2, 0, ld.SetLeftRowHeight);
    }
    void onPanVGridSplitterButtonRight(object? sender, PanUpdatedEventArgs puea)
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
        DoVerticalSplitterButton(sender, puea, Grid_MC_Right, 2, 0, ld.SetRightRowHeight);
    }
    void onPanCol12GridSplitterButtonRight(object? sender, PanUpdatedEventArgs puea)
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
        DoColumnSplitterButton(sender, puea, OrderItemGrid, 2, 0, ld.SetCol1Width);
    }
    void onPanCol23GridSplitterButtonRight(object? sender, PanUpdatedEventArgs puea)
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
        DoColumnSplitterButton(sender, puea, OrderItemGrid, 2, 4, ld.SetCol3Width);
    }

    void DoVerticalSplitterButton(object? sender, PanUpdatedEventArgs puea, Grid SplitColumn, int rowMain, int rowSplit, DelDouble SetHeight)
    {
        // Rect lb;
        RowDefinitionCollection rdc;
        double yMove;
        double y;
        double heightStar;
        double yShare;
        double yTotal;
        GridLength yMainNew;
        GridLength ySplitNew;
        // Thickness m;

        switch (puea.StatusType)
        {
            case GestureStatus.Started:

                SetStarToAbsolute();

                Rect? r = (sender as View)!.GetAbsoluteBounds();

                if (r.HasValue)
                {
                    xSplitter = r.Value.Left;
                    ySplitter = r.Value.Top;

                    xSplitterStart = r.Value.Left;
                    ySplitterStart = r.Value.Top;
                }
                rdc = SplitColumn.RowDefinitions;
                GridMainShare = rdc[rowMain].Height.Value;
                GridSplitShare = rdc[rowSplit].Height.Value;
                break;
            case GestureStatus.Running:
                {
#if WINDOWS
                    Rect r2 = AbsoluteLayer.GetLayoutBounds(sender as View);

                    r2.X = xSplitter + puea.TotalX;
                    r2.Y = ySplitter + puea.TotalY;
                    AbsoluteLayer.SetLayoutBounds(sender as View, r2);
                    try
                    {
                        yMove = puea.TotalY;

                        if (rowMain > rowSplit)
                        {
                            yMove *= -1;
                        }

                        rdc = SplitColumn.RowDefinitions;

                        y = GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - _headlineHeight - 10;

                        heightStar = rdc[rowMain].Height.Value + rdc[rowSplit].Height.Value;

                        yShare = (yMove / y) * heightStar;

                        yMainNew = new GridLength(GridMainShare + yShare, GridUnitType.Absolute);
                        ySplitNew = new GridLength(GridSplitShare - yShare, GridUnitType.Absolute);

                        yTotal = yMainNew.Value + ySplitNew.Value;

                         if (yMainNew.Value < 150)
                        {
                            yMainNew = new GridLength(150, GridUnitType.Absolute);
                            ySplitNew = new GridLength(yTotal - yMainNew.Value, GridUnitType.Absolute);
                        }
                        if (ySplitNew.Value < 150)
                        {
                            ySplitNew = new GridLength(150, GridUnitType.Absolute);
                            yMainNew = new GridLength(yTotal - ySplitNew.Value, GridUnitType.Absolute);
                        }


                        rdc[rowMain].Height = yMainNew;
                        rdc[rowSplit].Height = ySplitNew;

                        SetHeight(ySplitNew.Value);
                    }
                    catch // (Exception e)
                    {
                        // int a = 5;
                    }

#elif ANDROID
                    // Positionierung Button
                    r = (sender as View)!.GetAbsoluteBounds();

                    if (r.HasValue)
                    {
                        xSplitter = r.Value.Left;
                        ySplitter = r.Value.Top;
                    }
                    Rect r2 = AbsoluteLayer.GetLayoutBounds(sender as View);

                    r2.X = xSplitter + puea.TotalX;
                    r2.Y = ySplitter + puea.TotalY;
                    AbsoluteLayer.SetLayoutBounds(sender as View, r2);

                    // Positionierung Grid
                    try
                    {
                        yMove = r2.Y - ySplitterStart; // puea.TotalX;

                        if (rowMain > rowSplit)
                        {
                            yMove *= -1;
                        }

                        rdc = SplitColumn.RowDefinitions;

                        y = GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - _headlineHeight - 10;

                        heightStar = rdc[rowMain].Height.Value + rdc[rowSplit].Height.Value;

                        yShare = (yMove / y) * heightStar;

                        yMainNew = new GridLength(GridMainShare + yShare, GridUnitType.Absolute);
                        ySplitNew = new GridLength(GridSplitShare - yShare, GridUnitType.Absolute);

                        yTotal = yMainNew.Value + ySplitNew.Value;

                        if (yMainNew.Value < 150)
                        {
                            yMainNew = new GridLength(150, GridUnitType.Absolute);
                            ySplitNew = new GridLength(yTotal - yMainNew.Value, GridUnitType.Absolute);
                        }
                        if (ySplitNew.Value < 150)
                        {
                            ySplitNew = new GridLength(150, GridUnitType.Absolute);
                            yMainNew = new GridLength(yTotal - ySplitNew.Value, GridUnitType.Absolute);
                        }


                        rdc[rowMain].Height = yMainNew;
                        rdc[rowSplit].Height = ySplitNew;
                        SetHeight(ySplitNew.Value);
                    }
                    catch // (Exception e)
                    {
                        // int a = 5;
                    }
#endif

                }
                break;
            case GestureStatus.Completed:
                {

                }
                break;
        }
        // Handle the pan
    }

    void DoPortraitSplitterButton(object? sender, PanUpdatedEventArgs puea, Grid SplitColumn, int rowMain, int rowSplit, DelDouble SetHeight)
    {
        // Rect lb;
        RowDefinitionCollection rdc;
        double yMove;
        double y;
        double heightStar;
        double yShare;
        double yTotal;
        GridLength yMainNew;
        GridLength ySplitNew;
        // Thickness m;

        switch (puea.StatusType)
        {
            case GestureStatus.Started:

                SetStarToAbsolute();

                Rect? r = (sender as View)!.GetAbsoluteBounds();

                if (r.HasValue)
                {
                    xSplitter = r.Value.Left;
                    ySplitter = r.Value.Top;

                    xSplitterStart = r.Value.Left;
                    ySplitterStart = r.Value.Top;
                }
                rdc = SplitColumn.RowDefinitions;
                GridMainShare = rdc[rowMain].Height.Value;
                GridSplitShare = rdc[rowSplit].Height.Value;
                break;
            case GestureStatus.Running:
                {
#if WINDOWS
                    Rect r2 = AbsoluteLayer.GetLayoutBounds(sender as View);

                    r2.X = xSplitter + puea.TotalX;
                    r2.Y = ySplitter + puea.TotalY;
                    AbsoluteLayer.SetLayoutBounds(sender as View, r2);
                    try
                    {
                        yMove = puea.TotalY;

                        if (rowMain > rowSplit)
                        {
                            yMove *= -1;
                        }

                        rdc = SplitColumn.RowDefinitions;

                        y = GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - _headlineHeight - 10;

                        heightStar = rdc[rowMain].Height.Value + rdc[rowSplit].Height.Value;

                        yShare = (yMove / y) * heightStar;

                        yMainNew = new GridLength(GridMainShare + yShare, GridUnitType.Absolute);
                        ySplitNew = new GridLength(GridSplitShare - yShare, GridUnitType.Absolute);

                        yTotal = yMainNew.Value + ySplitNew.Value;

                        if (yMainNew.Value < 150)
                        {
                            yMainNew = new GridLength(150, GridUnitType.Absolute);
                            ySplitNew = new GridLength(yTotal - yMainNew.Value, GridUnitType.Absolute);
                        }
                        if (ySplitNew.Value < 150)
                        {
                            ySplitNew = new GridLength(150, GridUnitType.Absolute);
                            yMainNew = new GridLength(yTotal - ySplitNew.Value, GridUnitType.Absolute);
                        }


                        rdc[rowMain].Height = yMainNew;
                        rdc[rowSplit].Height = ySplitNew;
 
                        SetHeight(yMainNew.Value);
                        SetGridDimensions();
                        SetPortraitGridDimensions();
                    }
                    catch // (Exception e)
                    {
                        // int a = 5;
                    }

#elif ANDROID
                    // Positionierung Button
                    r = (sender as View)!.GetAbsoluteBounds();

                    if (r.HasValue)
                    {
                        xSplitter = r.Value.Left;
                        ySplitter = r.Value.Top;
                    }
                    Rect r2 = AbsoluteLayer.GetLayoutBounds(sender as View);

                    r2.X = xSplitter + puea.TotalX;
                    r2.Y = ySplitter + puea.TotalY;
                    AbsoluteLayer.SetLayoutBounds(sender as View, r2);

                    // Positionierung Grid
                    try
                    {
                        yMove = r2.Y - ySplitterStart; // puea.TotalX;

                        if (rowMain > rowSplit)
                        {
                            yMove *= -1;
                        }

                        rdc = SplitColumn.RowDefinitions;

                        y = GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() - _headlineHeight - 10;

                        heightStar = rdc[rowMain].Height.Value + rdc[rowSplit].Height.Value;

                        yShare = (yMove / y) * heightStar;

                        yMainNew = new GridLength(GridMainShare + yShare, GridUnitType.Absolute);
                        ySplitNew = new GridLength(GridSplitShare - yShare, GridUnitType.Absolute);

                        yTotal = yMainNew.Value + ySplitNew.Value;

                        if (yMainNew.Value < 150)
                        {
                            yMainNew = new GridLength(150, GridUnitType.Absolute);
                            ySplitNew = new GridLength(yTotal - yMainNew.Value, GridUnitType.Absolute);
                        }
                        if (ySplitNew.Value < 150)
                        {
                            ySplitNew = new GridLength(150, GridUnitType.Absolute);
                            yMainNew = new GridLength(yTotal - ySplitNew.Value, GridUnitType.Absolute);
                        }


                        rdc[rowMain].Height = yMainNew;
                        rdc[rowSplit].Height = ySplitNew;
                        SetHeight(yMainNew.Value);
                        SetGridDimensions();
                        SetPortraitGridDimensions();
                    }
                    catch // (Exception e)
                    {
                        // int a = 5;
                    }
#endif

                }
                break;
            case GestureStatus.Completed:
                {

                }
                break;
        }
        // Handle the pan
    }

    void GridSplitter_R_Entered(object? sender, Microsoft.Maui.Controls.PointerEventArgs pea)
    {
        if (lastSM == IGlobalData.screenMode.portrait) return;

        SetStarToAbsolute();

        /* OLD
        Thickness m = new Thickness(-40, 0, -40, 0);
        GridSplitter_R_Box.Margin = m;
        */
        /* OLD
        ColumnDefinitionCollection cdc = MenuGridMenuInner.ColumnDefinitions;
        cdc[2].Width = new GridLength(cdc[2].Width.Value - 10, GridUnitType.Absolute);
        cdc[3].Width = new GridLength(30);
        cdc[4].Width = new GridLength(cdc[4].Width.Value - 10, GridUnitType.Absolute);
        */
    }
    void GridSplitter_R_Exited(object? sender, PointerEventArgs pea)
    {
        if (lastSM == IGlobalData.screenMode.portrait) return;

        Thickness m = new Thickness(0, 0, 0, 0);
        // Xamarin-Test
        // GridSplitter_R_Box.Margin = m;
        /* OLD
        ColumnDefinitionCollection cdc = MenuGridMenuInner.ColumnDefinitions;
        cdc[2].Width = new GridLength(cdc[2].Width.Value + 10, GridUnitType.Absolute);
        cdc[3].Width = new GridLength(10);
        cdc[4].Width = new GridLength(cdc[4].Width.Value + 10, GridUnitType.Absolute);
        */
    }


    // int panOverflow = 0;
    void GridSplitter_R_Pan(object? sender, PanUpdatedEventArgs puea)
    {
        // Rect lb;
        ColumnDefinitionCollection cdc;
        double xMove;
        double x;
        double widthStar;
        double xShare;
        double xTotal;
        GridLength x3New;
        GridLength x5New;
        Thickness m;

       

        switch (puea.StatusType)
        {
            case GestureStatus.Started:

                SetStarToAbsolute();

                // GridSplitter_R_Entered(sender, null);
                cdc = MenuGridMenuInner.ColumnDefinitions;
                GridMainShare = cdc[2].Width.Value;
                GridSplitShare = cdc[4].Width.Value;
                // Xamarin-Test
                // GridSplitter_R_Box.Color = Colors.Red;

#if WINDOWS
                try
                {
                    m = new Thickness(-20, 0, -20, 0);
                    // Xamarin-Test
                    // GridSplitter_R_Box.Margin = m;
                }
                catch // ( Exception e)
                {
                    // int a = 5;
                }
#endif
                // _xStartPan = puea.TotalX;
                // _yStartPan = puea.TotalY;
                break;
            case GestureStatus.Running:
                {
                    // Xamarin-Test
                    // GridSplitter_R_Box.Color = Colors.Yellow;

                    try
                    {
                        xMove = puea.TotalX;

                        cdc = MenuGridMenuInner.ColumnDefinitions;

                        x = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth - 30;

                        widthStar = cdc[0].Width.Value + cdc[2].Width.Value + cdc[4].Width.Value;

                        xShare = (xMove / x) * widthStar;

                        x3New = new GridLength(GridMainShare + xShare, GridUnitType.Absolute);
                        x5New = new GridLength(GridSplitShare - xShare, GridUnitType.Absolute);

                        xTotal = x3New.Value + x5New.Value;

                        if (x3New.Value < 500)
                        {
                            x3New = new GridLength(500, GridUnitType.Absolute);
                            x5New = new GridLength(xTotal - x3New.Value, GridUnitType.Absolute);
                        }
                        if (x5New.Value < 100)
                        {
                            x5New = new GridLength(100, GridUnitType.Absolute);
                            x3New = new GridLength(xTotal - x5New.Value, GridUnitType.Absolute);
                        }


                        // XValues3.Add(x3New.Value);
                        // XValues5.Add(x5New.Value);
                        // XValuesTotal.Add(xTotal);
                        // XValuesMove.Add(xMove);

                        cdc[2].Width = x3New;
                        cdc[4].Width = x5New;
                    }
                    catch // ( Exception e)
                    {
                        // int a = 5;
                    }
                    break;
                }
            case GestureStatus.Completed:
                {
#if ANDROID
                   
                      
#endif
                    try
                    {
                        // Xamarin-Test
                        // GridSplitter_R_Box.Color = Colors.Black;
                        xMove = puea.TotalX;

                        cdc = MenuGridMenuInner.ColumnDefinitions;

                        x = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() - _paddingWidth - 30;

                        widthStar = cdc[0].Width.Value + cdc[2].Width.Value + cdc[4].Width.Value;
                        xShare = (xMove / x) * widthStar;

                        x3New = new GridLength(cdc[2].Width.Value + xShare, GridUnitType.Absolute);
                        x5New = new GridLength(cdc[4].Width.Value - xShare, GridUnitType.Absolute);

                        xTotal = x3New.Value + x5New.Value;

                        if (x3New.Value < 500)
                        {
                            x3New = new GridLength(500, GridUnitType.Absolute);
                            x5New = new GridLength(xTotal - x3New.Value, GridUnitType.Absolute);
                        }
                        if (x5New.Value < 100)
                        {
                            x5New = new GridLength(100, GridUnitType.Absolute);
                            x3New = new GridLength(xTotal - x5New.Value, GridUnitType.Absolute);
                        }

                        cdc[2].Width = x3New;
                        cdc[4].Width = x5New;
                        // GridSplitter_R_Exited(sender, null);
                        m = new Thickness(0, 0, 0, 0);
                        // Xamarin-Test
                        // GridSplitter_R_Box.Margin = m;
                    }
                    catch // (Exception e)
                    {
                        // int a = 5;
                    }

                    break;
                }
        }
        // Handle the pan
    }


    /*
    void GridSplitter_R_Pan( object? sender, PanUpdatedEventArgs puea )
    {

        Rect lb;
        ColumnDefinitionCollection cdc;
        double xMove;
        double x;
        double widthStar;
        double xShare;
        GridLength x3New;
        GridLength x5New;

        switch (puea.StatusType)
        {
            case GestureStatus.Started:
                cdc = MenuGridMenu.ColumnDefinitions;
                Grid3Share = cdc[3].Width.Value;
                Grid5Share = cdc[5].Width.Value;
                // _xStartPan = puea.TotalX;
                // _yStartPan = puea.TotalY;
                break;
            case GestureStatus.Running:
                xMove = puea.TotalX;

                cdc = MenuGridMenu.ColumnDefinitions;

                x = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth()  - _paddingWidth- 30;

                widthStar = 0;

                foreach (ColumnDefinition c in cdc)
                {
                    if (c.Width.GridUnitType == GridUnitType.Star)
                        widthStar += c.Width.Value;
                }
                xShare = (xMove / x) * widthStar;

                x3New = new GridLength(Grid3Share + xShare, GridUnitType.Star);
                x5New = new GridLength(Grid5Share - xShare, GridUnitType.Star);

         
                if ( x3New.Value < 3 )
                {
                    x3New = new GridLength(3, GridUnitType.Star );
                    x5New = new GridLength(6 - x3New.Value, GridUnitType.Star);
                }
                if (x5New.Value < 0.5)
                {
                    x5New = new GridLength(0.5, GridUnitType.Star);
                    x3New = new GridLength(6 - x5New.Value, GridUnitType.Star);
                }

                cdc[3].Width = x3New;
                cdc[5].Width = x5New;


                break;

            case GestureStatus.Completed:
                xMove = puea.TotalX;

                cdc = MenuGridMenu.ColumnDefinitions;

                x = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth()  - _paddingWidth- 30;

                widthStar = 0;
                foreach (ColumnDefinition c in cdc)
                {
                    if (c.Width.GridUnitType == GridUnitType.Star)
                        widthStar += c.Width.Value;
                }
                xShare = ( xMove / x) * widthStar;

                x3New = new GridLength(cdc[3].Width.Value + xShare, GridUnitType.Star);
                x5New = new GridLength(cdc[5].Width.Value - xShare, GridUnitType.Star);

                if (x3New.Value < 3)
                {
                    x3New = new GridLength(3, GridUnitType.Star);
                    x5New = new GridLength(6 - x3New.Value, GridUnitType.Star);
                }
                if (x5New.Value < 0.5)
                {
                    x5New = new GridLength(0.5, GridUnitType.Star);
                    x3New = new GridLength(6 - x5New.Value, GridUnitType.Star);
                }

                cdc[3].Width = x3New;
                cdc[5].Width = x5New;

                break;
        }

        // Handle the pan
    }
    */

    /*
    void OnDragGridRight(object sender, DragStartingEventArgs e)
    {
        int a = 5;
        // Shape shape = (sender as Element).Parent as Shape;
    }
    void OnDragDropGridRight(object sender, DragEventArgs e)
    {
       
        // Shape shape = (sender as Element).Parent as Shape;
    }
    void OnDropGridRight(object sender, DropEventArgs e)
    {
        // Shape shape = (sender as Element).Parent as Shape;
    }
    */
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
        l1.Text = loca.OrderFeedback_Quit_Person_Self_13991; // "Wirklich l�schen?";
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

    public void ShowDialog(string ShowText)
    {
        // bool doCont = true;
        Button? b;
        Point p3 = new();

        b = new();


        p3.Y += b!.Height + 3;

        Rect pd = new();
        pd.X = (GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() / 2) - 200;
        pd.Y = (GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() / 2) - 100;
        pd.Width = 400;
        pd.Height = 200;


        pd = _menuExtension!.CalcBounds(pd);

        int val;

        string Text = loca.MAUI_Infodialog_Info;

        _menuExtension!.OpenShowMenu(true, pd, true, Text);


        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            SetInfoMenu(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView, ShowText);
        }
        // BlueBox.IsVisible = true;
        // AbsoluteLayout.SetLayoutBounds(BlueBox, new Rect(p3.X, p3.Y, 400, 200));
    }
    public void SetInfoMenu(Grid? contextGrid, string Text)
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
        l1.Text = Text;
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
        ButtonGrid.ColumnDefinitions = cdc;


        CreateButtonXY(ButtonGrid, loca.MAUI_Infodialog_Ok, 1, 1, DoCancel);

    }

}