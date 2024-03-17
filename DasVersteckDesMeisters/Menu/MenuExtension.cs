
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Phoney_MAUI.Game.General;
using Phoney_MAUI.Model;
using Phoney_MAUI.Core;
using GameCore;

namespace Phoney_MAUI.Menu;

public delegate Grid? ReturnGrid();
public delegate Button? ReturnButton();
public delegate void CallWhenMenuClosed();
public delegate AbsoluteLayout? ReturnAbsoluteLayout();
public delegate IUIServices ReturnIUIServices();
public delegate Label ReturnMenuTitle();
public delegate void EndFunc(object o, EventArgs ea);

/*
public class PosDim
{
    public double XPos;
    public double YPos;
    public double Width;
    public double Height;
}
*/

public class ListCall
{
    public DelVoid Call;
    public int Count = 0;

    public ListCall(DelVoid call, int count )
    {
        Call = call;
        Count = count;
    }
}

public class MEMenu
{
    private Grid? _ClickGrid;
    private Button? _scaleXY;
    private Grid? _View;
    private bool _Visible;
    private Rect _PosDim;
    private bool _GoVisible;
    private bool _GoInvisible;
    private Label? _HeaderLabel;
    private double _PanXOff;
    private double _PanYOff;
    private double _PanWidth;
    private double _PanHeight;
    private Grid? _InnerView;
    private DelVoidObject? _switchMethod;
    private object? _switchParameter;
    private bool _HeadlineVisible;
    private string? _Headline;
    private object? _userDefinedData;
    private bool _scalable;

    public TapGestureRecognizer? tgrIntern;
    public double MinWidth { get; set; }
    public double MinHeight { get; set; }
    public double MaxWidth { get; set; }
    public double MaxHeight { get; set; }
    public double PanXOff
    {
        get => _PanXOff;
        set
        {
            _PanXOff = value;
        }
    }
    public double PanYOff
    {
        get => _PanYOff;
        set
        {
            _PanYOff = value;
        }
    }
    public double PanWidth
    {
        get => _PanWidth;
        set
        {
            _PanWidth = value;
        }
    }
    public double PanHeight
    {
        get => _PanHeight;
        set
        {
            _PanHeight = value;
        }
    }
    public Rect PosDim
    {
        get => _PosDim;
        set
        {
            _PosDim = value;
        }
    }
    public Label? HeaderLabel
    {
        get => _HeaderLabel;
        set
        {
            _HeaderLabel = value;
        }
    }
    public object? UserDefinedData
    {
        get => _userDefinedData;
        set
        {
            _userDefinedData = value;
        }
    }
    public bool GoVisible
    {
        get => _GoVisible;
        set
        {
            _GoVisible = value;
        }
    }
    public bool GoInvisible
    {
        get => _GoInvisible;
        set
        {
            _GoInvisible = value;
        }
    }
    public bool Visible
    {
        get => _Visible;
        set
        {
            _Visible = value;
        }
    }


    public bool Scalable
    {
        get => _scalable;
        set
        {
            if( value == true && _scalable == false )
            {
                Grid g = new();
                this.View!.Add(g!);
                g.WidthRequest = 15;
                g.HeightRequest = 15;
                g.VerticalOptions = LayoutOptions.End;
                g.HorizontalOptions = LayoutOptions.End;
                List<string> GridStyle = new();
                GridStyle.Add("Grid_BGBG");
                g.StyleClass = GridStyle;
                Thickness m = new(2, 2, 2, 2);
                g.Margin = m;

                /*
                Button sc = new();
                Thickness m = new(2, 2, 2, 2);
                sc.Text = "\uf424";
                sc.FontFamily = "Fa-Solid";
                sc.Margin = m;
                sc.BorderWidth = 0;
                sc.RotateTo(90);
                ScaleXY = sc;
                sc.VerticalOptions = LayoutOptions.End;
                sc.HorizontalOptions  = LayoutOptions.End;
                List<string> ButtonStyle = new();
                ButtonStyle.Add("Button_BGBG");
                sc.StyleClass = ButtonStyle;
                g.Add(sc);
                */
                PanGestureRecognizer pgr = new();
                pgr!.PanUpdated += MenuServices!.OnScaleUpdated!;
                g.GestureRecognizers.Add(pgr);
            }
            else if ( value == false && _scalable == true )
            {
                this.View!.Remove(ScaleXY);
            }
            _scalable = value;
        }
    }
    public Button? ScaleXY
    {
        get => _scaleXY;
        set
        {
            _scaleXY = value;
        }
    }
    public DelVoidObject? SwitchMethod
    {
        get => _switchMethod;
        set
        {
            _switchMethod = value;
        }
    }
    public object? SwitchParameter
    {
        get => _switchParameter;
        set
        {
            _switchParameter = value;
        }
    }
    public Grid? InnerView
    {
        get => _InnerView;
        set
        {
            _InnerView = value;
        }
    }
    public Grid? ClickGrid
    {
        get => _ClickGrid;
        set
        {
            _ClickGrid = value;
        }
    }
    public MenuExtension? MenuServices { get; set; }
    public Grid? View
    {
        get => _View;
        set
        {
            _View = value;
        }
    }
    public bool ContextMenuGoInvisible
    {
        get => _GoInvisible;
        set
        {
            _GoInvisible = value;
        }
    }
    public string? Headline
    {
        get => _Headline;
        set
        {
            _Headline = value;
        }
    }
    public bool HeadlineVisible
    {
        get => _HeadlineVisible;
        set
        {
            _HeadlineVisible = value;
        }
    }
}
public class MenuExtension
{ 
    public List<ListCall> ListCalls;

    public List<MEMenu> MEMenus;

    public string? CurrentMenuName { get; set; }
    public Button? B_ME1 { get; set; }
    public Button? B_ME2 { get; set; }
    public Button? B_ME3 { get; set; }
    public Button? B_ME4 { get; set; }
    public Button? B_ME5 { get; set; }
    public Button? B_ME6 { get; set; }
    private DelVoidSenderObject? _quitMethod;
    public DelVoidSenderObject? QuitMethod
    {
        get => _quitMethod;
        set
        {
            _quitMethod = value;
        }
    }
    private List<DelVoid>? _localMethods;
    private List<DelVoid>? LocalMethods
    {
        get => _localMethods;
        set
        {
            _localMethods = value;
        }
    }


    private class MenuCallbacks
    {
        public string? MenuName;
        public ReturnGrid? _menuGridLeft;
        public ReturnGrid? _menuGridTotal;
        public ReturnGrid? _menuGridMenu;
        public ReturnGrid? _webView_Grid;
        public ReturnGrid? _Page_Grid;
        public ReturnButton? _menuButton;
        public ReturnAbsoluteLayout? _menuAbsoluteLayout;
        public ReturnIUIServices? _menuUIS;
        public ReturnMenuTitle? _menuTitle;
    }

    private CallWhenMenuClosed? _callWhenMenuClosed;
    private ReturnGrid? _menuGridLeft;
    private ReturnGrid? _menuGridTotal;
    private ReturnGrid? _menuGridMenu;
    private ReturnGrid? _webView_Grid;
    private ReturnGrid? _Page_Grid;
    private ReturnButton? _menuButton;
    private ReturnAbsoluteLayout? _menuAbsoluteLayout;
    private readonly MainViewModel _viewModelMain;
    private readonly GeneralViewModel _viewModelGeneral;
    private readonly IGlobalData? _globalData;
    private ReturnIUIServices? _menuUIS;
    private ReturnMenuTitle? _menuTitle;

    private List<MenuCallbacks> _menuCallbacks;

    private double _speedX = 0f;

    public string? CallAdventure { get; set; }

    public void RemoveListCall( DelVoid call )
    {
        foreach( ListCall lc in ListCalls)
        {
            if( lc.Call == call )
            {
                ListCalls.Remove(lc);
                break;
            }
        }
    }
    public void SetLocalMethod( DelVoid method )
    {
        bool alreadyListed = false;

        if (LocalMethods == null)
            LocalMethods = new();

        foreach( DelVoid d in LocalMethods)
        {
            if( d == method)
            {
                alreadyListed = true;
                break;
            }
        }
        if( !alreadyListed)
        {
            LocalMethods.Add(method);
        }
    }
    public void RemoveLocalMethod(DelVoid? method)
    {
        try
        {
            LocalMethods!.Remove(method!);
        }
        catch // ( Exception e )
        {
            // int a = 5;
        }
    }
    public Rect CalcBounds( Rect r )
    {
        if (r.Left < 0)
            r.Left = 0;
        if (r.Top < 0)
            r.Top = 0;
        if (r.Left + r.Width >= _Page_Grid!()!.Width)
            r.Left = _Page_Grid()!.Width - 1 - r.Width;
        if (r.Top + r.Height >= _Page_Grid()!.Height)
            r.Top = _Page_Grid()!.Height - 1 - r.Height;

        return r;
    }

    class coor
    {
        public double x;
        public double y;

        public coor( double x, double y)
        {
            this.x = x;
            this.y = y;
        }

    }
    List<coor>? Koor;
    bool running = false;
    // double xFlicker = 0;
    // double yFlicker = 0;
    void OnPanUpdated(object? sender, PanUpdatedEventArgs? e)
    {
        if( Koor == null )
        {
            Koor = new();
        }

        Rect lb;
        double xActual;
        double yActual;

        double xSet = e!.TotalX; //  - xFlicker;
        double ySet = e!.TotalY; //  - yFlicker;

        // double xSet = e.TotalX - xFlicker;
        // double ySet = e.TotalY - yFlicker;
        if( running == true && e.StatusType == GestureStatus.Running)
        {

            running = false;
            return;
        }


        running = true;
        switch (e!.StatusType)
        {
            case GestureStatus.Started:
                lb = _menuAbsoluteLayout!()!.GetLayoutBounds(MEMenus![(MEMenus!.Count - 1)!]!.View!)!;
                MEMenus[MEMenus.Count - 1].PanXOff = lb.X;
                MEMenus[MEMenus.Count - 1].PanYOff = lb.Y;
                break;
            case GestureStatus.Running:

                xActual = MEMenus[MEMenus.Count - 1].PanXOff + xSet;
                yActual = MEMenus[MEMenus.Count - 1].PanYOff + ySet;

                if( xSet < 10 )
                {

                }

                lb = _menuAbsoluteLayout!()!.GetLayoutBounds(MEMenus![MEMenus.Count - 1]!.View!)!;

                // xFlicker = e.TotalX;
                // yFlicker = e.TotalY;

                lb.X = xActual;
                lb.Y = yActual;
                lb = CalcBounds(lb);

                _menuAbsoluteLayout!()!.SetLayoutBounds(MEMenus[MEMenus.Count - 1]!.View, lb);


                Koor.Add(new coor(lb.X, lb.Y));
                break;

            case GestureStatus.Completed:
                // Store the translation applied during the pan
                // xActual = MEMenus[MEMenus.Count - 1].PanXOff + xSet;
                // yActual = MEMenus[MEMenus.Count - 1].PanYOff + ySet;

                // lb = _menuAbsoluteLayout!()!.GetLayoutBounds(MEMenus![(MEMenus.Count - 1)!]!.View!)!;
                // lb.X = xActual;
                // lb.Y = yActual;
                // lb.X = xActual;
                // lb.Y = yActual;
                // lb = CalcBounds(lb);

                // _menuAbsoluteLayout!()!.SetLayoutBounds(MEMenus[MEMenus.Count - 1].View, lb);
                break;
        }
        // Handle the pan
    }
    public void OnScaleUpdated(object? sender, PanUpdatedEventArgs? e)
    {
        Rect lb;
        double width;
        double height;

        switch (e!.StatusType)
        {
            case GestureStatus.Started:
                lb = _menuAbsoluteLayout!()!.GetLayoutBounds(MEMenus[(MEMenus.Count - 1)!]!.View);
                MEMenus[MEMenus.Count - 1].PanWidth = lb.Width;  
                MEMenus[MEMenus.Count - 1].PanHeight = lb.Height;
                break;
            case GestureStatus.Running:

                width = MEMenus[MEMenus.Count - 1].PanWidth + e.TotalX;
                height = MEMenus[MEMenus.Count - 1].PanHeight + e.TotalY;

                if (MEMenus[MEMenus.Count - 1].MinWidth != -1 && width < MEMenus[MEMenus.Count - 1].MinWidth)
                    width = MEMenus[MEMenus.Count - 1].MinWidth;
                if (MEMenus[MEMenus.Count - 1].MaxWidth != -1 && width > MEMenus[MEMenus.Count - 1].MaxWidth)
                    width = MEMenus[MEMenus.Count - 1].MaxWidth;

                if (MEMenus[MEMenus.Count - 1].MinHeight!= -1 && height < MEMenus[MEMenus.Count - 1].MinHeight)
                    height = MEMenus[MEMenus.Count - 1].MinHeight;
                if (MEMenus[MEMenus.Count - 1].MaxHeight != -1 && height > MEMenus[MEMenus.Count - 1].MaxHeight)
                    height = MEMenus[MEMenus.Count - 1].MaxHeight;

                lb = _menuAbsoluteLayout!()!.GetLayoutBounds(MEMenus[MEMenus.Count - 1]!.View!);
                lb.Width = width;
                lb.Height = height;

                lb = CalcBounds(lb);

                _menuAbsoluteLayout!()!.SetLayoutBounds(MEMenus[MEMenus.Count - 1]!.View, lb);

                break;

            case GestureStatus.Completed:
                // Store the translation applied during the pan
                width = MEMenus[MEMenus.Count - 1].PanWidth + e.TotalX;
                height = MEMenus[MEMenus.Count - 1].PanHeight + e.TotalY;

                lb = _menuAbsoluteLayout!()!.GetLayoutBounds(MEMenus[MEMenus.Count - 1]!.View);
                // lb.X = xActual;
                // lb.Y = yActual;
                lb = CalcBounds(lb);

                _menuAbsoluteLayout!()!.SetLayoutBounds(MEMenus[MEMenus.Count - 1]!.View, lb);
                break;
        }

        // Handle the pan
    }
    public bool LatestMenuVisible
    {
        get => MEMenus[MEMenus.Count - 1].Visible;
        set
        {
            if (value == true)
            {
                MEMenus[MEMenus.Count - 1]!.View!.IsVisible = true;
                MEMenus[MEMenus.Count - 1]!.GoVisible = true;
                MEMenus[MEMenus.Count - 1]!.GoInvisible = false;
                MEMenus[MEMenus.Count - 1]!.View!.Opacity = 0;
            }
            else if (value == false)
            {
                if (_menuAbsoluteLayout != null)
                {
                    MEMenus[MEMenus.Count - 1].GoInvisible = true;
                    if(MEMenus[MEMenus.Count - 1].GoVisible == true)
                    {
                        MEMenus[MEMenus.Count - 1].GoVisible = false;
                    }
                }
            }
            MEMenus[ MEMenus.Count - 1].Visible = value;
        }
    }

    private void SetupVisibleCoreMenu( bool fixedMenu = false)
    {
        if (_menuAbsoluteLayout != null && MEMenus.Count > 0 )
        {
            // _menuAbsoluteLayout!().Clear();

            MEMenus[MEMenus.Count - 1]!.ClickGrid = new Grid();
            MEMenus[MEMenus.Count - 1]!.ClickGrid!.IsVisible = true;
            MEMenus[MEMenus.Count - 1]!.ClickGrid!.BackgroundColor = Colors.IndianRed;
            MEMenus[MEMenus.Count - 1]!.ClickGrid!.Opacity = 0;
            MEMenus[MEMenus.Count - 1]!.ClickGrid!.VerticalOptions = LayoutOptions.FillAndExpand;
            MEMenus[MEMenus.Count - 1]!.ClickGrid!.HorizontalOptions = LayoutOptions.FillAndExpand;
            MEMenus[MEMenus.Count - 1]!.ClickGrid!.WidthRequest = _Page_Grid!()!.Width!;
            MEMenus[MEMenus.Count - 1]!.ClickGrid!.HeightRequest = _Page_Grid!()!.Height!;
            MEMenus[MEMenus.Count - 1]!.MenuServices = this;

            _menuAbsoluteLayout!()!.Add(MEMenus[MEMenus.Count - 1].ClickGrid);

            _menuAbsoluteLayout!()!.SetLayoutBounds(MEMenus[MEMenus.Count - 1].ClickGrid, new Rect(0, 0, GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth(), GlobalSpecs.CurrentGlobalSpecs.GetScreenHeight()));

            // if (_contextMenuView == null)
            {
                MEMenus[MEMenus.Count - 1].View = new Grid();
                MEMenus[MEMenus.Count - 1].View!.IsVisible = false;
                _menuAbsoluteLayout!()!.Add(MEMenus[MEMenus.Count - 1].View);
                List<string> GridBGBGStyle = new();
                GridBGBGStyle.Add("Grid_BGBG");
                MEMenus[MEMenus.Count - 1].View!.StyleClass = GridBGBGStyle;

                List<string> GridBGStyle = new();
                GridBGStyle.Add("Grid_Normal");

                Border bo = new Border();
                List<string> BorderStyles = new();
                BorderStyles.Add("Border_FG");
                bo.StyleClass = BorderStyles;
                MEMenus[MEMenus.Count - 1]!.View!.Children.Add(bo);

                Grid g = new Grid();
                g.StyleClass = GridBGBGStyle;
                bo.Content = g;

                RowDefinitionCollection rdc = new();
                RowDefinition rd1 = new();
                rd1.Height = new GridLength(1, GridUnitType.Auto );
                rdc.Add(rd1);
                RowDefinition rd2 = new();
                rd2.Height = new GridLength(1, GridUnitType.Star);
                rdc.Add(rd2);
                g.RowDefinitions = rdc;

                Grid g2 = new Grid();
                g2.StyleClass = GridBGStyle;
                g.SetRow(g2, 0);
                g.Add(g2);
                Thickness m = new(8, 8, 8, 0);
                g2.Margin = m;
                g2.MinimumHeightRequest = 50;
                PanGestureRecognizer pgr = new();
                pgr.PanUpdated += OnPanUpdated;
                g2.GestureRecognizers.Add(pgr);
                g2.InputTransparent = false;

                Label l1 = new Label();
                l1.Text = MEMenus[MEMenus.Count - 1].Headline;
                l1.HorizontalOptions = LayoutOptions.Center;
                l1.VerticalOptions = LayoutOptions.Center;
                g2.Children.Add(l1);
                Thickness m2 = new(4, 4, 4, 4);
                l1.Padding= m2;
                MEMenus[MEMenus.Count - 1].HeaderLabel = l1;
                List<string> LabelStyleFG = new();
                LabelStyleFG.Add("Label_Normal");
                l1.StyleClass = LabelStyleFG;

                Grid g3 = new Grid();
                g3.StyleClass = GridBGStyle;
                g.SetRow(g3, 1);
                g.Add(g3);
                m = new(8, 8, 8, 8);
                g3.Margin = m;

                MEMenus[MEMenus.Count - 1].InnerView = g3;

            }
            _menuAbsoluteLayout!()!.SetLayoutBounds(MEMenus[MEMenus.Count - 1].View, new Rect(MEMenus[MEMenus.Count - 1].PosDim.X, MEMenus[MEMenus.Count - 1].PosDim.Y, MEMenus[MEMenus.Count - 1].PosDim.Width, MEMenus[MEMenus.Count - 1].PosDim.Height));
            _menuAbsoluteLayout!()!.InputTransparent = false;

            if (fixedMenu == false)
            {
                TapGestureRecognizer tgr = new();

                tgr.Tapped += CloseTap;
                MEMenus[MEMenus.Count - 1]!.tgrIntern = tgr;
                MEMenus[MEMenus.Count - 1]!.ClickGrid!.GestureRecognizers.Add(tgr);
                MEMenus[MEMenus.Count - 1]!.ClickGrid!.InputTransparent = false;
            }
            else
            {
                for( int i = MEMenus.Count - 1; i >= 0; i --)
                {
                    MEMenus[ i ]!.ClickGrid!.GestureRecognizers.Clear();
                    MEMenus[ i ]!.ClickGrid!.InputTransparent = false;

                }

            }
        }
    }
    public bool OpenShowMenu( bool HeadlineVisible, Rect Dimension, bool FixedMenu, string? Headline = null )
    {
        MEMenu mem = new();
        mem.HeadlineVisible = HeadlineVisible;
        mem.Headline = Headline;
        mem.PosDim = Dimension;
        MEMenus.Add(mem);
        SetupVisibleCoreMenu( FixedMenu );
        LatestMenuVisible = true;
        return true;
    }
    public void CloseTap( object? sender, EventArgs? ea)
    {
        if (MEMenus.Count > 0)
        {
            MEMenus[MEMenus.Count - 1].Visible = false;
            MEMenus[MEMenus.Count - 1].GoInvisible = true;
            MEMenus[MEMenus.Count - 1].ClickGrid!.GestureRecognizers.Clear();
            _menuAbsoluteLayout!()!.Remove(MEMenus[MEMenus.Count - 1]!.ClickGrid);
            if (MEMenus.Count <= 1)
            {
                _menuAbsoluteLayout!()!.InputTransparent = true;
            }
        }
    }
    public void CloseContextMenu()
    {
        CloseTap(null, null);
        MEMenus[MEMenus.Count - 1].GoInvisible = true;
    }
    public void SwitchContextMenu( DelVoidObject? SwitchContextMenuMethod, object? o )
    {
        MEMenus[MEMenus.Count - 1].GoInvisible = true;
        this.MEMenus[MEMenus.Count - 1].SwitchMethod = SwitchContextMenuMethod;
        this.MEMenus[MEMenus.Count - 1].SwitchParameter = o;
    }
    public void ResetLayout()
    {
        if( _menuAbsoluteLayout != null )
        {
            _menuAbsoluteLayout!()!.Clear();
        }
        while (MEMenus.Count > 0)
        {
            MEMenus[MEMenus.Count - 1].ClickGrid = null;
            MEMenus[MEMenus.Count - 1].View = null;
            MEMenus.Remove(MEMenus[MEMenus.Count - 1]);
        }
    }
    public MenuExtension( MainViewModel mainViewModel,  GeneralViewModel generalViewModel)
    {
        _viewModelMain = mainViewModel;
        _viewModelGeneral = generalViewModel;
        _globalData = GlobalData.CurrentGlobalData;
        ListCalls = new();

        MEMenus = new();

        _menuCallbacks = new List<MenuCallbacks>();

        _callWhenMenuClosed = null;

        var timer = Application.Current!.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(10);
        timer.IsRepeating = true;

        // Fügen Sie eine Ereignishandler-Methode hinzu, die etwas tut, wenn der Timer tickt
        timer.Tick += (s,e) =>
        {
            MainThread.BeginInvokeOnMainThread(MenuRescaler);
            if( GlobalSpecs.CurrentGlobalSpecs!.AppRunning == IGlobalSpecs.appRunning.quit)
            {
                timer.IsRepeating = false;
            }
        };
        timer.Start();
        /*
         // Starten Sie den Timer


         Device.StartTimer(new TimeSpan(0, 0, 0, 0, 10 ), () =>
         {
             Device.BeginInvokeOnMainThread(MenuRescaler);
             return true;
         });
         */
    }

    private void RegisterMenu ( string? MenuName, ReturnGrid? MenuGridLeft, ReturnGrid? MenuGridTotal, ReturnGrid? MenuGridMenu, ReturnGrid? WebView_Grid, ReturnGrid? Page_Grid, ReturnButton? MenuButton, ReturnIUIServices? UIS, ReturnAbsoluteLayout? MenuAbsoluteLayout, ReturnMenuTitle? MenuTitle )
    {
        bool updated = false;

        foreach( MenuCallbacks mc in _menuCallbacks )
        {
            if( mc.MenuName == MenuName )
            {
                mc._menuGridLeft = MenuGridLeft;
                mc._menuGridTotal = MenuGridTotal;
                mc._menuGridMenu = MenuGridMenu;
                mc._webView_Grid = WebView_Grid;
                mc._Page_Grid = Page_Grid;
                mc._menuButton = MenuButton;
                mc._menuAbsoluteLayout = MenuAbsoluteLayout;
                mc._menuUIS = UIS;
                mc._menuTitle = MenuTitle;
                updated = true;
                break;
            }
        }
        if( !updated )
        {
            MenuCallbacks mc = new();
            mc.MenuName = MenuName;
            mc._menuGridLeft = MenuGridLeft;
            mc._menuGridTotal = MenuGridTotal;
            mc._menuGridMenu = MenuGridMenu;
            mc._webView_Grid = WebView_Grid;
            mc._Page_Grid = Page_Grid;
            mc._menuButton = MenuButton;
            mc._menuAbsoluteLayout = MenuAbsoluteLayout;
            mc._menuUIS = UIS;
            mc._menuTitle = MenuTitle;
            _menuCallbacks.Add(mc);
        }
    }
    private void UnregisterMenu(string MenuName)
    {

        foreach (MenuCallbacks mc in _menuCallbacks)
        {
            if (mc.MenuName == MenuName)
            {
                _menuCallbacks.Remove(mc);
                break;
            }
        }
    }
    private void CheckRegistration(string MenuName)
    {

        foreach (MenuCallbacks mc in _menuCallbacks)
        {
            if (mc.MenuName == MenuName)
            {
                _menuGridLeft = mc._menuGridLeft;
                _menuGridTotal = mc._menuGridTotal;
                _menuGridMenu= mc._menuGridMenu;
                _webView_Grid = mc._webView_Grid;
                _Page_Grid = mc._Page_Grid;
                _menuButton = mc._menuButton;
                _menuAbsoluteLayout = mc._menuAbsoluteLayout;
                _menuUIS = mc._menuUIS!;
                _menuTitle = mc._menuTitle;
                double w = 300;
                Thickness p = _menuGridTotal!()!.Padding!;
                p.Left = -300 + w;
                p.Right = 0 - w;

 
                double opacity = 1 - (1 * (w / 300));
                _menuGridTotal()!.Padding = p;
                _menuGridMenu!()!.Opacity = opacity;

                break;
            }
        }
    }


    public void SetLanguage()
    {
        B_ME1!.Text = loca.MAUI_UI_B1;
        B_ME2!.Text = loca.MAUI_UI_B2;
        B_ME3!.Text = loca.MAUI_UI_B3;
        B_ME4!.Text = loca.MAUI_UI_B4;
        B_ME5!.Text = loca.MAUI_UI_B5;
        B_ME6!.Text = loca.MAUI_UI_B6;
    }
    public void SetMenuExtension(ReturnGrid? MenuGridLeft, ReturnGrid? MenuGridTotal, ReturnGrid? MenuGridMenu, ReturnGrid? WebView_Grid, ReturnGrid? Page_Grid, ReturnButton? MenuButton, ReturnIUIServices? UIS, ReturnAbsoluteLayout? MenuAbsoluteLayout, ReturnMenuTitle? MenuTitle, [CallerMemberName] string? name = null)
    {
        CurrentMenuName = name;

        RegisterMenu(name, MenuGridLeft, MenuGridTotal, MenuGridMenu, WebView_Grid, Page_Grid, MenuButton, UIS, MenuAbsoluteLayout, MenuTitle);

        _menuGridLeft = MenuGridLeft;
        _menuGridTotal = MenuGridTotal;
        _menuGridMenu = MenuGridMenu;
        _webView_Grid = WebView_Grid;
        _Page_Grid = Page_Grid;
        _menuButton = MenuButton;
        _menuAbsoluteLayout = MenuAbsoluteLayout;
        _menuUIS = UIS!;
        _menuTitle = MenuTitle;

        if( UIS != null ) 
            UIS()!.HeadlineLabel = MenuTitle!()!;
        // Ich weiß, hier mache ich MVVM Schande, aber das ist mir echt wurscht

        _globalData!.SetSetGlobalMenuState( SetGlobalMenu);
        _viewModelGeneral.SetCallbackChangeOrientation((IGlobalData._callbackChangeOrientation)ChangeOrientation);

        _menuGridLeft!()!.Padding = new Thickness(0,0,0,0);

        Grid g1 = new Grid();

        List<string> sc = new();
        sc.Add( "Grid_Normal");
        g1.StyleClass = sc;


        g1.RowDefinitions.Add(new RowDefinition(new GridLength(20, GridUnitType.Absolute )));
        g1.RowDefinitions.Add(new RowDefinition(new GridLength(1, GridUnitType.Star)));
        g1.RowDefinitions.Add(new RowDefinition(new GridLength(1, GridUnitType.Star)));
        g1.RowDefinitions.Add(new RowDefinition(new GridLength(1, GridUnitType.Star)));
        g1.RowDefinitions.Add(new RowDefinition(new GridLength(1, GridUnitType.Star)));
        g1.RowDefinitions.Add(new RowDefinition(new GridLength(1, GridUnitType.Star)));
        g1.RowDefinitions.Add(new RowDefinition(new GridLength(1, GridUnitType.Star)));
        g1.RowDefinitions.Add(new RowDefinition(new GridLength(1, GridUnitType.Star)));

         Label l1 = new Label();
        List<string> lc = new();
        lc.Add("Label_Title");
        l1.StyleClass = lc;
        l1.Text = "Phoney Island";
        l1.HorizontalOptions = LayoutOptions.Center;
        l1.VerticalOptions= LayoutOptions.Center;
        l1.IsVisible = false;
        g1.SetRow(l1,0);
        g1.Children.Add(l1);
  
        Button b1 = new Button();
        List<string> bc = new();
        bc.Add("Button_BGBG_Large");
        b1.StyleClass = bc;
        b1.Text = "Home";
         b1.Margin = new Thickness(20, 10, 20, 10);
        g1.SetRow(b1, 1);
        g1.Children.Add(b1);
        b1.Clicked += PressHome;
        b1.SetCursorHand();
        B_ME1 = b1;

        // Command = "{Binding Source={RelativeSource AncestorType={x:Type genx:MainViewModel}}, 
        //        Path = SelectGlobalMenuCommand}" 

        Button b2 = new Button();
        b2.StyleClass = bc;
        b2.Text = "Spiel";
        b2.Margin = new Thickness(20, 10, 20, 10);
        g1.SetRow(b2, 2);
        g1.Children.Add(b2);
        b2.Clicked += PressGame;
        b2.SetCursorHand();
        B_ME2 = b2;

        Button b3 = new Button();
        b3.StyleClass = bc;
        b3.Text = "Settings";
        b3.Margin = new Thickness(20, 10, 20, 10);
        g1.SetRow(b3, 3);
        g1.Children.Add(b3);
        b3.Clicked += PressSettings;
        b3.SetCursorHand();
        B_ME3 = b3;

        Button b4 = new Button();
        b4.StyleClass = bc;
        b4.Text = "Log";
        b4.Margin = new Thickness(20, 10, 20, 10);
        g1.SetRow(b4, 4);
        g1.Children.Add(b4);
        b4.Clicked += PressReplay;
        b4.SetCursorHand();
        B_ME4 = b4;

        Button b5 = new Button();
        b5.StyleClass = bc;
        b5.Text = "Credits";
        b5.Margin = new Thickness(20, 10, 20, 10);
        g1.SetRow(b5, 5);
        g1.Children.Add(b5);
        b5.Clicked += PressCredits;
        b5.SetCursorHand();
        B_ME5 = b5;

        Button b6 = new Button();
        b6.StyleClass = bc;
        b6.Text = "Ende";
        b6.Margin = new Thickness(20, 10, 20, 10);
        g1.SetRow(b6, 6);
        g1.Children.Add(b6);
        b6.Clicked += PressEnd;

        b6.SetCursorHand();
        B_ME6 = b6;

        _menuGridLeft()!.Children.Add(g1);

        CalcButtons();

        SetLanguage();
    }

    void SelectButton( Button b)
    {
        List<string> bc = new();
        bc.Add("Button_Normal_Large");

        b.StyleClass = bc;
    }
    void UnselectButton(Button b)
    {
        List<string> bc = new();
        bc.Add("Button_BGBG_Large");

        b.StyleClass = bc;

    }

    void CalcButtons()
    {
        Grid? g = _menuGridLeft!()!.Children!.Last() as Grid;
        Button? b;

        b = g?.Children[1] as Button;
        if (_globalData!.LocalMenu == IGlobalData.localMenu.home)
            SelectButton(b!);
        else
            UnselectButton(b!);

        b = g?.Children[2] as Button;
        if (_globalData.LocalMenu == IGlobalData.localMenu.game)
            SelectButton(b!);
        else
            UnselectButton(b!);

        b = g?.Children[3] as Button;
        if (_globalData.LocalMenu == IGlobalData.localMenu.settings)
            SelectButton(b!);
        else
            UnselectButton(b!);

        b = g?.Children[4] as Button;
        if (_globalData.LocalMenu == IGlobalData.localMenu.replay)
            SelectButton(b!);
        else
            UnselectButton(b!);

        b = g?.Children[5] as Button;
        if (_globalData.LocalMenu == IGlobalData.localMenu.credits)
            SelectButton(b!);
        else
            UnselectButton(b!);

        b = g?.Children[6] as Button;
        if (_globalData.LocalMenu == IGlobalData.localMenu.end)
            SelectButton(b!);
        else
            UnselectButton(b!);


    }

    void GoHome()
    {
        _globalData!.LocalMenu = IGlobalData.localMenu.home;
        _viewModelMain.NavigateTo($"{nameof(HomePage)}");
        CheckRegistration("HomePage");
    }
    public void PressHome(object? sender, EventArgs e)
    {
        if (_globalData!.LocalMenu != IGlobalData.localMenu.home)
        {
            _globalData!.GlobalMenu = IGlobalData.globalMenu.closing;
            SetCallWhenMenuClosed(GoHome);

        }
        else
        {
            _globalData!.GlobalMenu = IGlobalData.globalMenu.closed;

        }
        // Do something
    }
    void GoGame()
    {
        _globalData!.LocalMenu = IGlobalData.localMenu.game;
        _viewModelMain.NavigateTo($"{nameof(GamePage)}");
        CheckRegistration("GamePage");
    }
    public void PressGame(object? sender, EventArgs e)
    {
        if (_globalData!.LocalMenu != IGlobalData.localMenu.game)
        {
            _globalData.GlobalMenu = IGlobalData.globalMenu.closing;
            SetCallWhenMenuClosed(GoGame);
        }
        else
        {
            _globalData.GlobalMenu = IGlobalData.globalMenu.closed;

        }
        // Do something
    }

    void SetCallWhenMenuClosed( CallWhenMenuClosed delMenuClosed )
    {
        _callWhenMenuClosed = delMenuClosed;
    }
    void GoSettings()
    {
        _globalData!.LocalMenu = IGlobalData.localMenu.settings;
        _viewModelMain.NavigateTo("SettingsPage");
        CheckRegistration("SettingsPage");
    }
    public void PressSettings(object? sender, EventArgs e)
    {
        if (_globalData!.LocalMenu != IGlobalData.localMenu.settings)
        {
            _globalData.GlobalMenu = IGlobalData.globalMenu.closing;
            SetCallWhenMenuClosed(GoSettings);
        }
        else
        {
            _globalData.GlobalMenu = IGlobalData.globalMenu.closed;

        }
        // Do something
    }
    void GoReplay()
    {
        _globalData!.LocalMenu = IGlobalData.localMenu.replay;
        _viewModelMain.NavigateTo("ReplayPage");
        CheckRegistration("ReplayPage");
    }
    public void PressReplay(object? sender, EventArgs e)
    {
        if (_globalData!.LocalMenu != IGlobalData.localMenu.replay)
        {
            _globalData.GlobalMenu = IGlobalData.globalMenu.closing;
            SetCallWhenMenuClosed(GoReplay);
        }
        else
        {
            _globalData.GlobalMenu = IGlobalData.globalMenu.closed;

        }

        // Do something
    }
    void GoCredits()
    {
        _globalData!.LocalMenu = IGlobalData.localMenu.credits;
        _viewModelMain.NavigateTo("CreditsPage");
        CheckRegistration("CreditsPage");
    }
    public void PressCredits(object? sender, EventArgs e)
    {
        if (_globalData!.LocalMenu != IGlobalData.localMenu.credits)
        {
            _globalData.GlobalMenu = IGlobalData.globalMenu.closing;
            SetCallWhenMenuClosed(GoCredits);
        }
        else
        {
            _globalData.GlobalMenu = IGlobalData.globalMenu.closed;

        }

        // Do something
    }
    void GoEnd()
    {
        if( QuitMethod != null )
        {
            EventArgs ea = new(); 

            QuitMethod(B_ME6, ea );
        }
        /*
        _globalData.LocalMenu = IGlobalData.localMenu.end;
        _viewModelMain.NavigateTo("EndPage");
        CheckRegistration("EndPage");
        */
    }
    public void PressEnd(object? sender, EventArgs e)
    {
        if (_globalData!.LocalMenu != IGlobalData.localMenu.end)
        {
            _globalData.GlobalMenu = IGlobalData.globalMenu.closing;
            SetCallWhenMenuClosed(GoEnd);
        }
        else
        {
            _globalData.GlobalMenu = IGlobalData.globalMenu.closed;

        }

        // Do something
    }
 
    public void SetMenuExtension()
    {

    }

    public void SetGlobalMenu( IGlobalData.globalMenu gm )
    {
        /*
        if (_globalData.ScreenMode == IGlobalData.screenMode.landscape)
        {
            if (gm == IGlobalData.globalMenu.open)
            {
                (_menuGridLeft().Parent as Grid).ColumnDefinitions[0].Width = 300;
                
            }
            else
            {
                (_menuGridLeft().Parent as Grid).ColumnDefinitions[0].Width = 0;
            }
        }
        else
        {
            if (gm == IGlobalData.globalMenu.open)
            {
                (_menuGridTop().Parent as Grid).RowDefinitions[0].Height = 120;
            }
            else
            {
                (_menuGridTop().Parent as Grid).RowDefinitions[0].Height = 0;
            }


        }
        */
    }
    public void ChangeOrientation(IGlobalData.screenMode sm)
    {
        /*
        if (sm == IGlobalData.screenMode.portrait)
        {
            if (_globalData.GlobalMenu == IGlobalData.globalMenu.open)
            {
                (_menuGridLeft().Parent as Grid).ColumnDefinitions[0].Width = 0;
                (_menuGridTop().Parent as Grid).RowDefinitions[0].Height = 120;

            }
            else
            {
                (_menuGridLeft().Parent as Grid).ColumnDefinitions[0].Width = 0;
                (_menuGridTop().Parent as Grid).RowDefinitions[0].Height = 0;

            }
        }
        else if (sm == IGlobalData.screenMode.landscape)
        {
            if (_globalData.GlobalMenu == IGlobalData.globalMenu.open)
            {
                (_menuGridLeft().Parent as Grid).ColumnDefinitions[0].Width = 300;
                (_menuGridTop().Parent as Grid).RowDefinitions[0].Height = 0;

            }
            else
            {
                (_menuGridLeft().Parent as Grid).ColumnDefinitions[0].Width = 0;
                (_menuGridTop().Parent as Grid).RowDefinitions[0].Height = 0;

            }

        }
        */
    }

    bool rescalerRunning = false;

    private async void MenuRescaler()
    {
        if (!rescalerRunning)
        {
            rescalerRunning = true;
            MenuRescalerMT();
            rescalerRunning = false;
        }
        else
        {

        }
    }

    private bool MenuRescalerMT()
    {
        // Callback-Service im Menü-Thread
        int ix; 
        for(  ix = 0; ix < ListCalls.Count; ix++)
        {
            if (ListCalls[ ix ].Count > 0)
            {
                ListCalls[ix].Count--;
            }
            else if (ListCalls[ix].Count == -1 )
            {
                ListCalls[ix].Call();
            }
            else
            {
                ListCalls[ix].Call();
                ListCalls.RemoveAt(ix);
                ix--;
            }
        }
        
        if (LocalMethods != null)
        {
            try
            {
                foreach (DelVoid d in LocalMethods)
                {

                    d();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

         // Game-Restarter
        if (GlobalData.CurrentGlobalData!.Adventure != null && CurrentMenuName == "GamePage" && GlobalData.CurrentGlobalData.InitProcess == false && GlobalData.CurrentGlobalData.AskForPlayLevel )
        {
            if (GlobalData.CurrentGlobalData!.AskForPlayLevelCount > 0)
            {
                GlobalData.CurrentGlobalData!.AskForPlayLevelCount--;
            }
            else
            {
                GlobalData.CurrentGlobalData!.UIS!.InitBrowserUpdate();
                GlobalData.CurrentGlobalData!.Adventure!.Orders!.GenericDialog(null, GlobalData.CurrentGlobalData.Adventure!.Orders!.SetupDialog);
                GlobalData.CurrentGlobalData!.OrderList!.FlushCollection();
                /*
                GlobalData.CurrentGlobalData.UIS.StoryTextObj.RecalcLatest();
                GlobalData.CurrentGlobalData!.UIS.FinishBrowserUpdate();
                GlobalData.CurrentGlobalData!.UIS.Scr.RefreshJumpToEnd();
                 */
                GlobalData.CurrentGlobalData!.AskForPlayLevel = false;
                // UIS.StoryTextObj.AdvTextOut();
            }
        }

 
        double w = 300 + (_menuGridLeft!()!.Parent as Grid)!.Padding!.Left;

        if (_globalData!.GlobalMenu == IGlobalData.globalMenu.open)
        {


            if (w < 300)
            {
                w += _speedX;

                double dist = Math.Abs(300 - w);
                if (dist > 50)
                {
                    _speedX += 10f;
                }
                else
                {
                    _speedX = dist / 2;
                    if (_speedX < 1)
                        _speedX = 1;
                }


            }


        }
        else if (_globalData.GlobalMenu == IGlobalData.globalMenu.closed || _globalData.GlobalMenu == IGlobalData.globalMenu.closing)
        {


            if (w > 0)
            {
                w -= _speedX;

                double dist = Math.Abs(0 - w);

                if (dist > 50)
                {
                    _speedX += 10f;
                }
                else
                {
                    _speedX = dist / 2;
                    if (_speedX < 1)
                        _speedX = 1;
                }

            }


        }
        if (w > 300)
            w = 300;
        if (w < 0)
            w = 0;



        Thickness p = _menuGridTotal!()!.Padding!;
        p.Left = -300 + w;
        p.Right = 0 - w;


        _menuGridTotal()!.Padding = p;

        if (_globalData.GlobalMenu == IGlobalData.globalMenu.closing)
        {
            bool v = false;

            double opacity = _menuGridMenu!()!.Opacity!;

            if (w == 0)
                opacity -= 0.05f;
            else
                opacity -= 0.01f;

            if (opacity < 0)
            {
                opacity = 0;
                _globalData.GlobalMenu = IGlobalData.globalMenu.closed;
            }
            _menuGridMenu()!.Opacity = opacity;
            if (_webView_Grid!() != null)
            {

                _webView_Grid!()!.IsVisible = v;

            }
            // _webView_Grid().Opacity = 0.95; // 1 - opacity;
            //     _webView_Grid().Opacity = 1; //  (1 - opacity);
        }
        else if (_globalData.GlobalMenu == IGlobalData.globalMenu.opening)
        {
            bool v = false;
            double opacity = _menuGridMenu!()!.Opacity;

            opacity += 0.05f;

            if (opacity > 1.0f)
            {
                _globalData.GlobalMenu = IGlobalData.globalMenu.closed;
                opacity = 1.0f;
                v = true;
            }
            _menuGridMenu!()!.Opacity = opacity;
            if (_webView_Grid!() != null)
            {
                _webView_Grid()!.IsVisible = v;
                // _webView_Grid().Opacity = 0.95; // 1 - opacity;
            }
        }
        else
        {
            bool v = false;
            double opacity = 1 - (0.8f * (w / 300));
            _menuGridMenu!()!.Opacity = opacity;
            // _menuGridMenu!()!.Opacity = 1.0f;



            if (_webView_Grid!() != null)
            {
                if (opacity >= 1)
                    v = true;

                _webView_Grid()!.IsVisible = v;

            }
            // _webView_Grid().Opacity = 0.95; // 1 - opacity;
            // _webView_Grid().Opacity = (1 - opacity);

        }
        _menuButton!()!.Rotation = (w * 90) / 300;

        if (_globalData.GlobalMenu == IGlobalData.globalMenu.closed && w == 0 && _callWhenMenuClosed != null)
        {
            Thickness n = (_menuGridLeft()!.Parent as Grid)!.Padding;

            _callWhenMenuClosed();

            (_menuGridLeft()!.Parent as Grid)!.Padding = n;
            _callWhenMenuClosed = null;
            _globalData.GlobalMenu = IGlobalData.globalMenu.opening;

            _speedX = 0;
        }

        if (_globalData.GlobalMenu != IGlobalData.globalMenu.open && _globalData.GlobalMenu != IGlobalData.globalMenu.opening && _globalData.GlobalMenu != IGlobalData.globalMenu.closing && MEMenus.Count > 0)
        {
            // Ein/ausfaden des Kontextmenüs
            if (MEMenus[MEMenus.Count - 1].GoVisible == true)
            {
                MEMenus[MEMenus.Count - 1].View!.Opacity += 0.1f;
                if (MEMenus[MEMenus.Count - 1].View!.Opacity >= 1.0f)
                {
                    MEMenus[MEMenus.Count - 1].View!.Opacity = 1.0f;
                    MEMenus[MEMenus.Count - 1].GoVisible = false;
                }
                double opacity = 0.5 + ((1 - MEMenus[MEMenus.Count - 1].View!.Opacity) * 0.5);
                _menuGridMenu()!.Opacity = opacity;


            }
            else if (MEMenus[MEMenus.Count - 1].GoInvisible == true)
            {
                MEMenus[MEMenus.Count - 1].View!.Opacity -= 0.1f;
                if (MEMenus[MEMenus.Count - 1].View!.Opacity <= 0f)
                {
                    DestroyMEMenus();

                }

                if (MEMenus.Count > 0)
                {
                    double opacity = 0.5 + ((1 - MEMenus[MEMenus.Count - 1].View!.Opacity) * 0.5);
                    _menuGridMenu()!.Opacity = opacity;
                }
                else
                {
                    double opacity = 1;
                    _menuGridMenu()!.Opacity = opacity;

                }

            }
            else if (LatestMenuVisible)
            {
                double opacity = 0.5;
                _menuGridMenu()!.Opacity = opacity;

            }
        }
        /*
        if (GlobalData.CurrentGlobalData!.Adventure != null)
        {
            if (GlobalData.CurrentGlobalData!.Adventure.UIS.MCMV != null)
            {
                if (GlobalData.CurrentGlobalData!.Adventure.UIS.MCMV.OpenMCMV == true)
                {
                    if (GlobalData.CurrentGlobalData!.Adventure.UIS.MCMV.MCMVWait > 0)
                        GlobalData.CurrentGlobalData!.Adventure.UIS.MCMV.MCMVWait--;
                    else
                        GlobalData.CurrentGlobalData!.Adventure.UIS.MCMV.MCOutputExecute();
                }
            }
        }
        */
        /*
        if (CallAdventure != null)
        {
            // GlobalData.CurrentGlobalData!.Adventure.UIS.TextOutput("Jehova Jehova Jehova!");
            GlobalData.CurrentGlobalData!.Adventure.DoGameLoop(CallAdventure);

            CallAdventure = null;
            // GlobalData.CurrentGlobalData!.Adventure.UIS.TextOutput("<img src=\"http://localhost:8000/l015.jpg\" width=\"50%\" height=\"50%\"/img>");

            try
            {
                GlobalData.CurrentGlobalData!.Adventure.UIS.StoryTextObj.AdvTextOut(); //  RecalcLatest();

            }
            catch (Exception e)
            {
                int a = 5;
            }

            GlobalData.CurrentGlobalData!.Adventure.UIS.Scr.ScrollPageFinal();

            GlobalData.CurrentGlobalData!.Inputline.Focus();
            // GlobalData.CurrentGlobalData!.Adventure.UIS.StoryTextObj.TextReFreshman();
        }
        else if (GlobalData.CurrentGlobalData!.Adventure != null && GlobalData.CurrentGlobalData!.Adventure.UIS.DoUpdateBrowser)
        {
            GlobalData.CurrentGlobalData!.Adventure.UIS.StoryTextObj.AdvTextOut();
            GlobalData.CurrentGlobalData!.Adventure.UIS.UpdateBrowser();
            GlobalData.CurrentGlobalData!.Adventure.UIS.DoUpdateBrowser = false;
        }
        */

        if (GlobalData.CurrentGlobalData!.LocalMenu == IGlobalData.localMenu.game)
        {
            GlobalData.CurrentGlobalData!.Adventure!.UIS!.Scr!.DoScroll();


        }
        return true;
    }
    public void DestroyMEMenus()
    {
        if( MEMenus.Count < 1 )
        {
            return;
        }
        MEMenus[MEMenus.Count - 1].View!.Opacity = 0f;
        MEMenus[MEMenus.Count - 1].View!.IsVisible = false;
        MEMenus[MEMenus.Count - 1].GoInvisible = false;
        MEMenus[MEMenus.Count - 1].InnerView!.Clear();
        LatestMenuVisible = false;
        if (MEMenus[MEMenus.Count - 1].SwitchMethod != null)
        {
            DelVoidObject? svo = MEMenus[MEMenus!.Count - 1]!.SwitchMethod;
            object? o = MEMenus![MEMenus!.Count - 1]!.SwitchParameter;

            /*
            if (_menuAbsoluteLayout != null)
            {

                while (MEMenus[MEMenus.Count - 1].ClickGrid.GestureRecognizers.Count > 0)
                {
                    CloseTap(null, null);
                    MEMenus[MEMenus.Count - 1].ClickGrid.GestureRecognizers.Remove(MEMenus[MEMenus.Count - 1].tgrIntern);
                }
                _menuAbsoluteLayout!().Remove(MEMenus[MEMenus.Count - 1].ClickGrid);
            }
            
            MEMenus.Remove(MEMenus[MEMenus.Count - 1]);
            */
            MEMenus[MEMenus.Count - 1].SwitchMethod = null;
            svo!(o!);
        }
        else
        {

            if (MEMenus.Count > 0)
            {
                AbsoluteLayout? al = _menuAbsoluteLayout!()!;

                if (al != null && al.Children.Count > 0)
                {

                    while (MEMenus![MEMenus!.Count - 1]!.ClickGrid!.GestureRecognizers!.Count > 0)
                    {
                        // CloseTap(null, null);
                        MEMenus[MEMenus!.Count - 1]!.ClickGrid!.GestureRecognizers.Remove(MEMenus[MEMenus.Count - 1]!.tgrIntern);
                    }
                    _menuAbsoluteLayout!()!.Remove(MEMenus[MEMenus!.Count - 1]!.ClickGrid);
                }


                MEMenus.Remove(MEMenus[MEMenus.Count - 1]);
            }
        }
    }
}

