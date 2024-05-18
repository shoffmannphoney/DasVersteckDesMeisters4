using Phoney_MAUI.Game.General;
using Phoney_MAUI.Core;
using Phoney_MAUI.Model;
using CommunityToolkit.Maui.Core.Platform;

using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using Phoney_MAUI;
using Microsoft.Maui.Platform;
using GameCore;

namespace Phoney_MAUI.Menu;

/*
public static class ScreenCoords
{
    /// <summary>
    /// A view's default X- and Y-coordinates are LOCAL with respect to the boundaries of its parent,
    /// and NOT with respect to the screen. This method calculates the SCREEN coordinates of a view.
    /// The coordinates returned refer to the top left corner of the view.
    /// </summary>
    public static Point GetScreenCoords(this VisualElement view)
    {
        var result = new Point(view.X, view.Y);

        double Height = view.Height;

        while (view.Parent is VisualElement parent)
        {
            if (view.GetType() == typeof(ScrollView))
            {
                ScrollView sv = view as ScrollView;
                result.X -= sv.ScrollX;
                result.Y -= sv.ScrollY;
            }
            result = result.Offset(parent.X, parent.Y);
            view = parent;
        }

        return result;
    }
}
*/

public static class StringExtensions
{
    public static bool Contains(this string source, string toCheck, StringComparison comp)
    {
        return source?.IndexOf(toCheck, comp) >= 0;
    }
}
public partial class ReplayPage : ContentPage, IMenuExtension
{
    private readonly MainViewModel _viewModelMain;
    private readonly GeneralViewModel _viewModelGeneral;
    private readonly MenuExtension _menuExtension;
    private TreeView? _treeViewRoot;
    private int _currentNo;
    private int _latestDestPos;
    public ObservableCollection<ReplayInfo>? ReplayList { get; set; }

    public ICommand SearchCommand { get; }

    public int LatestDestPos
    {
        get => _latestDestPos;
        set => _latestDestPos = value;
    }

    public int CurrentNo 
    {
        get => _currentNo;
        set
        {
            _currentNo = value;
            if( _treeViewRoot != null )
                _treeViewRoot.OTNo = value;
        }
    }

    public void FullSetup()
    {
        ReplayList = _viewModelMain.ReplayList;

        /*

        _treeViewRoot = new();
        _treeViewRoot.SetupTreeView();
        _treeViewRoot.OrderListTable = new();
        ReplayTable.Add(_treeViewRoot);

        OrderListTable ott = new("Erste Ebene");
        ott.OLT = new();
        _treeViewRoot.OrderListTable.Add(ott);

        OrderListTable ott1 = new("Gehen von 'Burghof' bis 'Folterkellerie' (leer)");
        ott1.OT = new();
        ott.OLT.Add(ott1);


          OrderListTable ott2 = new("Gehen von 'Folterkeller' bis 'Thronsaal");
          ott2.OT = new();
          ott.OLT.Add(ott2);

          ObservableCollection<OrderTable> otList = new();
          OrderTable ot1 = new(orderType.orderText, "öffne Truhe", 0, GlobalData.language.german, "Mit leisem Knarren schwingt die Tür auf.");
          otList.Add(ot1);
          OrderTable ot2 = new(orderType.orderText, "schließe Truhe", 0, GlobalData.language.german, "Mit leisem Knarren schwingt die Truhe zu.");
          otList.Add(ot2);
          OrderTable ot4 = new(orderType.orderText, "verhaue Phoney", 0, GlobalData.language.german, "Ich stürzte mich auf Phoney, prügelte ihn windelweich und betrachtete stolz mein Werk.\nHm, nein, er stand noch. Das war verbesserungswürdig.\nIch verprügelte ihn gleich nochmal.");
          otList.Add(ot4);
          ott2.OT = otList;


          OrderListTable ott3 = new("Gehen von 'Thronsaal' bis 'Kram' (leer)");
          ott.OLT.Add(ott3);


          OrderListTable ott4 = new("Gehen von 'Folterkeller' bis 'Thronsaal'");
          ott.OLT.Add(ott4);

          otList = new();
          OrderTable ot3 = new(orderType.orderText, "töte Phoney", 0, GlobalData.language.german, "Ich stürzte mich auf Phoney, schlug ihm einfach mal richtig fett aufs Maul, und dann holte ich mit dem riesigen Säbel aus und schlug ihm den Kopf ab. Danach ging es mir irgendwie besser. ");
          otList.Add(ot3);
          ott4.OT = otList;

          OrderListTable ott5 = new("Und hier kommt der Müll");
          ott5.OLT = new();
          ott.OLT.Add(ott5);



          double val1 = DateTime.Now.Millisecond;

          for (int ix2 = 0; ix2 < 50; ix2++)
          {
              OrderListTable ott30 = new("Abschnitt " + (ix2 + 1) + ":");
              ott30.OLT = new();
              ott5.OLT.Add(ott30);

              for (int ix = 0; ix < 50; ix++)
              {
                  OrderListTable ott40 = new("Gehen von 'Burghof' bis 'Folterkeller' und zurück");
                  ott40.OT = new();
                  ott30.OLT.Add(ott40);

                  OrderTable ot11 = new(orderType.orderText, "öffne Truhe", 0, GlobalData.language.german, "Mit leisem Knarren schwingt die Tür auf.");
                  ott40.OT.Add(ot11);
                  OrderTable ot12 = new(orderType.orderText, "schließe Truhe", 0, GlobalData.language.german, "Mit leisem Knarren schwingt die Truhe zu.");
                  ott40.OT.Add(ot12);
                  OrderTable ot14 = new(orderType.orderText, "verhaue Phoney", 0, GlobalData.language.german, "Ich stürzte mich auf Phoney, prügelte ihn windelweich und betrachtete stolz mein Werk.\nHm, nein, er stand noch. Das war verbesserungswürdig.\nIch verprügelte ihn gleich nochmal.");
                  ott40.OT.Add(ot14);
                  OrderTable ot15 = new(orderType.mcChoice, "Ich würde dich gerne abmurksen, du dummes Schwein.", 0, GlobalData.language.german, "Phoney: Och nö.", 43);
                  ott40.OT.Add(ot15);
                  OrderTable ot16 = new(orderType.comment, "Warum kann man dieses Stück Scheiße eigentlich nicht töten?", 0, GlobalData.language.german, "Ja, warum eigentlich nicht?");
                  ott40.OT.Add(ot16);
              }
          }
          double val2 = DateTime.Now.Millisecond - val1;
  
        // _treeViewRoot.CurrentTreeState = TreeViewItem.TreeState.open;
        _treeViewRoot.OTCallback = OnClickedReplay;
        (TreeView.GetRootTree(_treeViewRoot) as TreeView)?.CalcToggles();

        */
    }


    public ReplayPage(MainViewModel viewModelMain, GeneralViewModel viewModelGeneral, MenuExtension menuExtension, IUIServices iuis)
    {
        InitializeComponent();
        BindingContext = _viewModelMain = viewModelMain;
        _viewModelGeneral = viewModelGeneral;
        _viewModelGeneral.SetCallbackChangeOrientation((IGlobalData._callbackChangeOrientation)ChangeOrientation);
        _menuExtension = menuExtension;

        _menuExtension!.SetMenuExtension(GetMenuGridLeft, GetMenuGridTotal, GetMenuGridMenu, WebView_Grid, Page_Grid, GetMenuButton, null, GetAbsoluteLayout, GetMenuTitle, nameof(ReplayPage));

        SearchCommand = new Command(async () => Search());

        // GD!.OrderList!.CurrentViewOrderListIx = 2;
        GD!.MenuExtension = (MenuExtension) _menuExtension;
        MenuButton.SetCursorHand();
        SearchBackwardPT.SetCursorHand();
        SearchForwardPT.SetCursorHand();
        SearchBackward.SetCursorHand();
        SearchForward.SetCursorHand();

#if WINDOWS
        Grid_Search.ColumnDefinitions[0].Width = new GridLength(0);
#endif


        // UIS = iuis;
        // FullSetup();
    }

    public IGlobalData? GD
    {
        get => GlobalData.CurrentGlobalData!;
    }
    public IUIServices UIS 
    {
        get => GlobalData.CurrentGlobalData!.UIS!;
    }
    void OnCollectionViewSelectionChangedReplay(object? sender, SelectionChangedEventArgs e)
    {

    }
    public void ChangeOrientation(IGlobalData.screenMode sm)
    {
        if (GD!.DebugMode == true)
        {
            if (sm == IGlobalData.screenMode.portrait)
            {
                ReplayGridPT.IsVisible = true;
                ReplayGridLS.IsVisible = false;
                ReplayGridRowPT.RowDefinitions[2].Height = new GridLength(150, GridUnitType.Absolute);
                ReplayGridColumnLS.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);
                ReplayListLabel.IsVisible = true;
            }
            else if (sm == IGlobalData.screenMode.landscape)
            {
                ReplayGridPT.IsVisible = false;
                ReplayGridLS.IsVisible = true;
                ReplayGridRowPT.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Absolute);
                ReplayGridColumnLS.ColumnDefinitions[1].Width = new GridLength(1, GridUnitType.Star);
                ReplayListLabel.IsVisible = true;

            }
        }
        else
        {
            if (sm == IGlobalData.screenMode.portrait)
            {
                ReplayGridPT.IsVisible = true;
                ReplayGridLS.IsVisible = false;
                ReplayGridRowPT.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Absolute);
                ReplayGridColumnLS.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);
                ReplayListLabel.IsVisible = false;
            }
            else if (sm == IGlobalData.screenMode.landscape)
            {
                ReplayGridPT.IsVisible = false;
                ReplayGridLS.IsVisible = true;
                ReplayGridRowPT.RowDefinitions[2].Height = new GridLength(0, GridUnitType.Absolute);
                ReplayGridColumnLS.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Absolute);
                ReplayListLabel.IsVisible = false;

            }

        }
    }
    public Grid? GetMenuGridLeft()
    {
        return MenuGridLeft;
    }
    public Grid? GetMenuGridTotal()
    {
        return MenuGridTotal;
    }
    public Grid? GetMenuGridMenu()
    {
        return MenuGridMenu;
    }
    public Grid? WebView_Grid()
    {
        return null;
    }
    public Grid? Page_Grid()
    {
        return PageGrid;
    }
    public Button? GetMenuButton()
    {
        return MenuButton;
    }
    public AbsoluteLayout? GetAbsoluteLayout()
    {
        return AbsoluteLayer;
    }
    private void OnClickedReplay(object? sender, OrderTableEventArgs e)
    {
        if (e.No > 0)
        {
            int a = e.No;
        }
    }

    public void RefreshReplayLists()
    {
        RowDefinitionCollection Rows = new();

        if( GD!.DebugMode == true )
            ReplayTitle.Text = loca.MAUI_UI_ReplayHeadline + GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].Name!;
        else
            ReplayTitle.Text = loca.MAUI_UI_B_Replay ;

        ReplayLists.Children.Clear();
        ReplayLists.RowDefinitions = Rows;

        int ix;

        List<string> s1 = new();
        s1.Add("IDButton_NoBackground_NoBorder");

        List<string> s2 = new();
        s2.Add("IDButton_Invers");

        for (ix = 1; ix < GD!.OrderList!.OTL!.Count; ix++)
        {
            RowDefinition rd1 = new();
            rd1.Height = GridLength.Auto;
            Rows.Add(rd1);

            IDButton b1 = new();
            if (ix == GD!.OrderList!.CurrentViewOrderListIx)
                b1.StyleClass = s2;
            else
            {
                b1.StyleClass = s1;
            }

            b1.Text = GD!.OrderList!.OTL![ix].Name;
            b1.Clicked += SelectReplayList;
            ReplayLists.Children.Add(b1);
            ReplayLists.SetRow(b1, ix - 1);
            Thickness m = new Thickness(4, 2, 4, 2);
            b1.Margin = m;
            b1.ID = ix;
            b1.SetCursorHand();
        }

        Rows = new();
        ReplayListsPT.Children.Clear();
        ReplayListsPT.RowDefinitions = Rows;


        for (ix = 1; ix < GD!.OrderList!.OTL!.Count; ix++)
        {
            RowDefinition rd1 = new();
            rd1.Height = GridLength.Auto;
            Rows.Add(rd1);

            IDButton b1 = new();
            if (ix == GD!.OrderList!.CurrentViewOrderListIx)
                b1.StyleClass = s2;
            else
            {
                b1.StyleClass = s1;
            }

            b1.Text = GD!.OrderList!.OTL![ix].Name;
            b1.Clicked += SelectReplayList;
            ReplayListsPT.Children.Add(b1);
            ReplayListsPT.SetRow(b1, ix - 1);
            Thickness m = new Thickness(4, 2, 4, 2);
            b1.Margin = m;
            b1.ID = ix;

        }
    }
    public void LoadCurrentOrderlist()
    {
        // if(GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT != null )
        //     CurrentNo = GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT![GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT.Count - 1].No;

        RefreshReplayLists();
        RefreshHierarchie( -1);


    }
    public void RefreshHierarchie( int DestPos )
    {
        int ix = GD!.OrderList!.CurrentViewOrderListIx; // FindOrderList("Stefan complete");


        foreach ( IView iv in ReplayTable.Children )
        {
            TreeView.EmptyTreeViewItem( iv );

        }
        ReplayTable.Children.Clear();

        OrderListTable ot = GD!.OrderList!.InitHierarchy(ix);


        ReplayList = _viewModelMain.ReplayList;

        _treeViewRoot = UIElement.NewTreeView();
        _treeViewRoot.SetupTreeView();
        _treeViewRoot.OrderListTable = new();
        _treeViewRoot.OTClick = DoClickReplay;
        _treeViewRoot.OrderTableCallback = DoClickReplayGrid;

        ReplayTable.Add(_treeViewRoot);

        _treeViewRoot.OrderListTable = ot!.OLT!;

        _treeViewRoot.CurrentTreeState = TreeViewItem.TreeState.open;
        _treeViewRoot.OTCallback = OnClickedReplay;
        (TreeView.GetRootTree(_treeViewRoot) as TreeView)?.CalcToggles();
        if (_treeViewRoot != null)
        {
            if( DestPos == -1 && GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx!]!.OT!.Count > 0 )
                DestPos = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx]!.OT![GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx]!.OT!.Count - 1]!.No;
            else if (DestPos == -1)
                DestPos = 0;

            _treeViewRoot.CloseAllOpenEntry(DestPos );
            LatestDestPos = DestPos;
            // DoCenter();
            _menuExtension!.ListCalls.Add(new ListCall(DoCenter, 2));
        }

    }

    public void DoClickReplay( object? sender, EventArgs ea )
    {
        if (GD!.DebugMode == false)
            return;

        // bool doCont = true;
        Label? b;
        Point p3 = new( );

        if (sender!.GetType() == typeof(OrderListView))
        {
            b = (sender as OrderListView)!.TextButton;
            p3 = ScreenCoords.GetScreenCoords(b);
        }
        else
        {
            b = new();
           // int a = 5;
        }


        p3.Y += b!.Height + 3;

        Rect pd = new();
        pd.X = p3.X;
        pd.Y = p3.Y;
        pd.Width = 250;
        pd.Height = 260;


        pd = _menuExtension!.CalcBounds(pd);

        int val;

        if (ea.GetType() == typeof(TreeViewEventArgs))

            val = (int)((ea as TreeViewEventArgs)!.UserDefinedObject)!;
        else if (ea.GetType() == typeof(OrderTableEventArgs))
            val = (int)((ea as OrderTableEventArgs)!.UserDefinedObject)!;
        else
            val = 1;

        string Text = val + ": " + GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx!]!.OT![val-1]!.OrderText!;

        /*
        _menuExtension!.ContextMenuHeadlineVisible = true;
        _menuExtension!.ContextMenuHeadline = Text;
        _menuExtension!.ContextMenuPosDim = pd;
        _menuExtension!.ContextMenuVisible = true;
        */

        _menuExtension!.OpenShowMenu(true, pd, false, Text);


        if( _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            SetContextMenuOrderList(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView!, val);
        }
        // BlueBox.IsVisible = true;
        // AbsoluteLayout.SetLayoutBounds(BlueBox, new Rect(p3.X, p3.Y, 400, 200));
    }

    public void SetContextMenuOrderList( Grid contextGrid, int val )
    {
        contextGrid.Children.Clear();

        RowDefinitionCollection rdc = new();
        RowDefinition rd1 = new();
        rd1.Height = GridLength.Auto;
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);

        contextGrid.RowDefinitions = rdc;

        CreateButtonOrderList(contextGrid, loca.MAUI_B_PlayTo, 0, val, DoButtonPlayTo); // Bis hierher spielen
        CreateButtonOrderList(contextGrid, loca.MAUI_B_Edit, 1, val, DoButtonOTEdit); // Editieren
        CreateButtonOrderList(contextGrid, loca.MAUI_B_Delete, 2, val, DoButtonOTDelete); // Löschen
        CreateButtonOrderList(contextGrid, loca.MAUI_B_Insert, 3, val, DoButtonOTInsert); // Neuer Eintrag danach
        CreateButtonOrderList(contextGrid, loca.MAUI_B_Insert_Before, 4, val, DoButtonOTInsertBefore); // Neuer Eintrag davor
    }

    public void CreateButtonOrderList( Grid g, string text, int off, int val, EventHandler ev )
    {
        IDButton b = new();
        b.ID = val;
        b.Text = text;
        g.Add(b);
        g.SetRow(b, off);
        List<string> ButtonStyle = new();
        ButtonStyle.Add("IDButton_Invers");
        b.StyleClass = ButtonStyle;
        Thickness m = new(6,6,6,0 );
        b.Margin = m;
        b.Clicked += ev;
        b.SetCursorHand();
    }
    public IDButton CreateButtonMaxWidth(Grid g, string text, int off, int val, int Width, EventHandler? ev, bool selected = true)
    {
        IDButton b = new();
        b.ID = val;
        b.Text = text;
        g.Add(b);
        g.SetRow(b, off);


        List<string> ButtonStyle = new();
        if( selected == true )
            ButtonStyle.Add("IDButton_Invers");
        else
            ButtonStyle.Add("IDButton");

        b.StyleClass = ButtonStyle;
        Thickness m = new(6, 6, 6, 0);
        b.Margin = m;
        b.Clicked += ev;
        b.MaximumWidthRequest = Width;
        b.VerticalOptions = LayoutOptions.Center;
        b.SetCursorHand();

        return b;
    }

    public void CreateButtonXY(Grid g, string text, int xoff, int yoff, OrderTable ot, EventHandler? ev)
    {
        ObjButton b = new();
        b.Object = ot;
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
        b.SetCursorHand();
    }
    public void CreateButtonXYString(Grid g, string text, int xoff, int yoff, string? EditText, EventHandler? ev)
    {
        ObjButton b = new();
        b.Object = EditText;
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
        b.SetCursorHand();
    }

    public void SelectOrderType(object? sender, EventArgs ea)
    {
        Label? b = (sender as Label);

        Point p3 = ScreenCoords.GetScreenCoords(b);

        p3.Y += b!.Height + 3;

        Rect pd = new();
        pd.X = p3.X;
        pd.Y = p3.Y;
        pd.Width = 300;
        pd.Height = 220;
        pd = _menuExtension!.CalcBounds(pd);


        string Text = loca.MAUI_UI_SOT_Eingabetyp; //  "Eingabetyp:";
        _menuExtension!.OpenShowMenu(true, pd, false, Text);

 
        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            // OrderTable ot1 = GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT![b.ID - 1];
            // OrderTable ot2 = GD!.OrderList!.CloneOT(ot1);
            // _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData = ot2;

            SetCMOrderType(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1]!.InnerView!, _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 2]!.UserDefinedData!);
        }
    }
    public void SelectOrderActive(object? sender, EventArgs ea)
    {
        Label? b = (sender as Label);

        Point p3 = ScreenCoords.GetScreenCoords(b);

        p3.Y += b!.Height + 3;

        Rect pd = new();
        pd.X = p3.X;
        pd.Y = p3.Y;
        pd.Width = 150;
        pd.Height = 150;
        pd = _menuExtension!.CalcBounds(pd);


        string Text = loca.MAUI_UI_SOA_Status; // "Status:";
        _menuExtension!.OpenShowMenu(true, pd, false, Text);


        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            // OrderTable ot1 = GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT![b.ID - 1];
            // OrderTable ot2 = GD!.OrderList!.CloneOT(ot1);
            // _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData = ot2;

            SetCMOrderActive(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1]!.InnerView!, _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 2]!.UserDefinedData!);
        }
    }

    public void CMEditChoiceFocused(object? o, EventArgs ea)
    {
        Entry? e = o as Entry;
        OrderTable? ot = _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1]!.UserDefinedData as OrderTable;
        e!.Text = ot!.OrderChoice!.ToString();
    }
    public void CMEditChoiceUnfocused(object? o, EventArgs ea)
    {
        Entry? e = o as Entry;

        int val = 0;
        try
        {
            val = Int32.Parse( e!.Text);
        }
        catch 
        { 
        }

        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData != null)
        {
            OrderTable? ot = _menuExtension!.MEMenus![_menuExtension!.MEMenus!.Count - 1]!.UserDefinedData as OrderTable;
            ot!.OrderChoice = val;
        }
        e!.Text = val.ToString();
    }
    public void CMEditTextUnfocused(object? o, EventArgs ea)
    {
        Entry? e = (o as Entry)!;

        string text = e!.Text;

        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData != null)
        {
            OrderTable? ot = _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1]!.UserDefinedData as OrderTable;
            ot!.OrderText = text; 
        }
    }

    public void SetCMEdit(Grid? contextGrid, OrderTable? ot )
    {
        contextGrid!.Children!.Clear();

        RowDefinitionCollection rdac = new();
        RowDefinition rda1 = new();
        rda1.Height = new GridLength(1, GridUnitType.Star);
        rdac.Add(rda1);
        RowDefinition rda2 = new();
        rda2.Height = new GridLength(45);
        rdac.Add(rda2);
        contextGrid.RowDefinitions = rdac;


        Grid ActionGrid = new();

        RowDefinitionCollection rdc = new();
        RowDefinition rd1 = new();
        rd1.Height = new GridLength(1, GridUnitType.Auto);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);
        ActionGrid.RowDefinitions = rdc;
        contextGrid.Add(ActionGrid);

        ColumnDefinitionCollection cdc2 = new();
        ColumnDefinition cdx1 = new();
        cdx1.Width = new GridLength(2, GridUnitType.Star);
        ColumnDefinition cdx2 = new();
        cdx2.Width = new GridLength(4, GridUnitType.Star);
        cdc2.Add(cdx1);
        cdc2.Add(cdx2);
        ActionGrid.ColumnDefinitions = cdc2;


        List<string> LabelStyle = new();
        LabelStyle.Add("Label_Normal");

        Thickness m = new Thickness(0, 3, 5, 3);

        Label l1 = new();
        l1.Text = loca.MAUI_UI_CME_No; //  "Nr.:";
        l1.StyleClass = LabelStyle;
        l1.HorizontalOptions = LayoutOptions.End;
        l1.VerticalOptions = LayoutOptions.Center;
        l1.Margin = m;
        ActionGrid.SetColumn(l1, 0);
        ActionGrid.SetRow(l1, 0);
        ActionGrid.Add(l1);

        Label l2 = new();
        l2.Text = loca.MAUI_UI_CME_Type; //  "Typ: ";
        l2.StyleClass = LabelStyle;
        l2.HorizontalOptions = LayoutOptions.End;
        l2.VerticalOptions = LayoutOptions.Center;
        l2.Margin = m;
        ActionGrid.SetColumn(l2, 0);
        ActionGrid.SetRow(l2, 1);
        ActionGrid.Add(l2);

        if (ot!.OrderType == orderType.orderText)
        {
            Label l3 = new();
            l3.Text = loca.MAUI_UI_CME_Text; //  "Text: ";
            l3.StyleClass = LabelStyle;
            l3.HorizontalOptions = LayoutOptions.End;
            l3.VerticalOptions = LayoutOptions.Center;
            l3.Margin = m;
            ActionGrid.SetColumn(l3, 0);
            ActionGrid.SetRow(l3, 2);
            ActionGrid.Add(l3);
        }
        else if (ot.OrderType == orderType.mcChoice)
        {
            Label l3 = new();
            l3.Text = loca.MAUI_UI_CME_Choice; //  "Choice: ";
            l3.StyleClass = LabelStyle;
            l3.HorizontalOptions = LayoutOptions.End;
            l3.VerticalOptions = LayoutOptions.Center;
            l3.Margin = m;
            ActionGrid.SetColumn(l3, 0);
            ActionGrid.SetRow(l3, 2);
            ActionGrid.Add(l3);
        }
        else if (ot.OrderType == orderType.noText)
        {
            Label l3 = new();
            l3.Text = loca.MAUI_UI_CME_WrongInput; //  "Falsche Eingabe: ";
            l3.StyleClass = LabelStyle;
            l3.HorizontalOptions = LayoutOptions.End;
            l3.VerticalOptions = LayoutOptions.Center;
            l3.Margin = m;
            ActionGrid.SetColumn(l3, 0);
            ActionGrid.SetRow(l3, 2);
            ActionGrid.Add(l3);
        }
        else if (ot.OrderType == orderType.comment )
        {
            Label l3 = new();
            l3.Text = loca.MAUI_UI_CME_Comment; //  "Kommentar: ";
            l3.StyleClass = LabelStyle;
            l3.HorizontalOptions = LayoutOptions.End;
            l3.VerticalOptions = LayoutOptions.Center;
            l3.Margin = m;
            ActionGrid.SetColumn(l3, 0);
            ActionGrid.SetRow(l3, 2);
            ActionGrid.Add(l3);
        }


        Label l4 = new();
        l4.Text = loca.MAUI_UI_CME_Status; //  "Status: ";
        l4.StyleClass = LabelStyle;
        l4.HorizontalOptions = LayoutOptions.End;
        l4.VerticalOptions = LayoutOptions.Center;
        l4.Margin = m;
        ActionGrid.SetColumn(l4, 0);
        ActionGrid.SetRow(l4, 3);
        ActionGrid.Add(l4);

        Label l5 = new();
        l5.Text = loca.MAUI_UI_CME_Result; //  "Resultat: ";
        l5.StyleClass = LabelStyle;
        l5.HorizontalOptions = LayoutOptions.End;
        l5.VerticalOptions = LayoutOptions.Center;
        l5.Margin = m;
        ActionGrid.SetColumn(l5, 0);
        ActionGrid.SetRow(l5, 4);
        ActionGrid.Add(l5);

        // contextGrid.ColumnDefinitions = cdc;


        List<string> EntryStyle = new();
        EntryStyle.Add("Entry_BGBG");

        List<string> LabelStyle1 = new();
        LabelStyle1.Add("Label_BGBG_FG");

        List<string> LabelStyle2 = new();
        LabelStyle2.Add("Label_BGBG_FGInactive");

        List<string> GridStyle1 = new();
        GridStyle1.Add("Grid_BGBG");

        Thickness lm = new Thickness(10, 4, 4, 4);


        Label e1 = new();
        e1.Text = ot.No.ToString();
        e1.StyleClass = LabelStyle2;
        e1.Margin = m;
        e1.Padding = lm;
        ActionGrid.SetColumn(e1, 1);
        ActionGrid.SetRow(e1, 0);
        ActionGrid.Add(e1);

        Label e2 = new();
        e2.Text = ot.OrderTypeText;
        e2.StyleClass = LabelStyle1;
        e2.Margin = m;
        e2.Padding = lm;
        ActionGrid.SetColumn(e2, 1);
        ActionGrid.SetRow(e2, 1);
        ActionGrid.Add(e2);
        TapGestureRecognizer tgr = new();
        tgr.Tapped += SelectOrderType;
        e2.GestureRecognizers.Add(tgr);
        e2.SetCursorHand();


        if ( ot.OrderType == orderType.mcChoice)
        {
            Entry e3 = new();
            if (ot!.OrderText != null && ot!.OrderText!.Length >= 8)
                e3.Text = ot.OrderChoice.ToString() + ": " + ot.OrderText!.Substring(8);
            else
                e3.Text = ot.OrderChoice.ToString() + ": 0";
            e3.StyleClass = EntryStyle;
            e3.Margin = m;
            ActionGrid.SetColumn(e3, 1);
            ActionGrid.SetRow(e3, 2);
            ActionGrid.Add(e3);
            e3.Focused += CMEditChoiceFocused;
            e3.Unfocused += CMEditChoiceUnfocused;
        }
        else
        { 
             Entry e3 = new();
            e3.Text = ot.OrderText;
            e3.StyleClass = EntryStyle;
            e3.Margin = m;
            ActionGrid.SetColumn(e3, 1);
            ActionGrid.SetRow(e3, 2);
            ActionGrid.Add(e3);
            e3.Unfocused += CMEditTextUnfocused;
        }
        Label e4 = new();
        e4.Text = ot.OrderActive.ToString();
        e4.StyleClass = LabelStyle1;
        e4.Margin = m;
        e4.Padding = lm;
        e4.SetCursorHand();
        ActionGrid.SetColumn(e4, 1);
        ActionGrid.SetRow(e4, 3);
        ActionGrid.Add(e4);
        if (ot.OrderActive == true)
            e4.Text = loca.MAUI_UI_CME_Active; //  "Aktiv";
        else
            e4.Text = loca.MAUI_UI_CME_Inactive; //  "Inaktiv";
        TapGestureRecognizer tgr2 = new();
        tgr2.Tapped += SelectOrderActive;
        e4.GestureRecognizers.Add(tgr2);

        ScrollView sv = new();
        sv.Margin = m;
        ActionGrid.SetColumn(sv, 1);
        ActionGrid.SetRow(sv, 4);
        ActionGrid.Add(sv);
        sv.HeightRequest = 100;


        Label e5 = new();
        e5.Text = ot.OrderResult + ot.OrderFeedback;
        e5.StyleClass = LabelStyle2;
         e5.LineBreakMode = LineBreakMode.WordWrap;
        e5.VerticalOptions = LayoutOptions.Center;
        e5.HorizontalOptions = LayoutOptions.Center;
        e5.Padding = lm;

        sv.Content = e5;

        Grid ButtonGrid = new();
        contextGrid.SetRow(ButtonGrid, 1);
        contextGrid.Add(ButtonGrid);
        ColumnDefinitionCollection cdc = new();
        ColumnDefinition cd1 = new();
        cd1.Width = new GridLength(1, GridUnitType.Star);
        ColumnDefinition cd2 = new();
        cd2.Width = new GridLength(2, GridUnitType.Star);
        cdc.Add(cd1);
        cdc.Add(cd2);
        cdc.Add(cd1);
        cdc.Add(cd2);
        cdc.Add(cd1);
        ButtonGrid.ColumnDefinitions = cdc;


        CreateButtonXY(ButtonGrid, loca.MAUI_UI_CME_Ok, 1, 0, ot, DoConfirmCMEdit);
        CreateButtonXY(ButtonGrid, loca.MAUI_UI_CME_Cancel, 3, 0, ot, DoCancelCMEdit);
    }

    public void SetCMOrderType(Grid contextGrid, object? o )
    {
        OrderTable? ot = (o as OrderTable)!;

        contextGrid.Children.Clear();

        RowDefinitionCollection rdc = new();
        RowDefinition rd1 = new();
        rd1.Height = new GridLength(1, GridUnitType.Auto);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);

        RowDefinition rd2 = new();
        rd2.Height = new GridLength(40);
        rdc.Add(rd2);

        contextGrid.RowDefinitions = rdc;

        CreateButtonMaxWidth(contextGrid, loca.MAUI_UI_CMOT_Text, 0, ot!.No, 200, DoSetToText, ot.OrderType == orderType.orderText ? true : false );
        CreateButtonMaxWidth(contextGrid, loca.MAUI_UI_CMOT_Choice, 1, ot!.No, 200, DoSetToChoice, ot.OrderType == orderType.mcChoice ? true : false);
        CreateButtonMaxWidth(contextGrid, loca.MAUI_UI_CMOT_Comment, 2, ot!.No, 200, DoSetToComment, ot.OrderType == orderType.comment? true : false);
        CreateButtonMaxWidth(contextGrid, loca.MAUI_UI_CMOT_WrongInput, 3, ot!.No, 200, DoSetToFalseInput, ot.OrderType == orderType.noText? true : false);

    }
    public void SetCMOrderActive(Grid contextGrid, object o)
    {
        OrderTable? ot = o as OrderTable;

        contextGrid.Children.Clear();

        RowDefinitionCollection rdc = new();
        RowDefinition rd1 = new();
        rd1.Height = new GridLength(1, GridUnitType.Auto);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);

        RowDefinition rd2 = new();
        rd2.Height = new GridLength(40);
        rdc.Add(rd2);

        contextGrid.RowDefinitions = rdc;

        CreateButtonMaxWidth(contextGrid, loca.MAUI_UI_CME_Active, 0, ot!.No!, 120, DoSetActive, ot.OrderActive );
        CreateButtonMaxWidth(contextGrid, loca.MAUI_UI_CME_Inactive, 1, ot!.No!, 120, DoSetInactive, ot.OrderActive);

    }

    public void SetDeleteMenu(Grid contextGrid, object o)
    {
        OrderTable? ot = o as OrderTable;

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
        l1.Text = loca.MAUI_UI_Really_Delete; // "Wirklich löschen?";
        l1.VerticalOptions = LayoutOptions.Center;
        l1.HorizontalOptions = LayoutOptions.Center;
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


        CreateButtonXY(ButtonGrid, loca.MAUI_UI_CME_Ok, 1, 1, ot!, DoDelete );
        CreateButtonXY(ButtonGrid, loca.MAUI_UI_CME_Cancel, 3, 1, ot!, DoCancel );

    }


    ProgressBar? GameProgressBar { get; set; }
    double GameProgressState { get; set; }
    Label? GameProgressInfo { get; set; }
    public void SetCMReplay(Grid contextGrid, object o )
    {
        OrderTable? ot = (o as OrderTable);

        contextGrid.Children.Clear();

        RowDefinitionCollection rdc = new();
        RowDefinition rd1 = new();
        rd1.Height = new GridLength( 1, GridUnitType.Star );
        rdc.Add(rd1);
        RowDefinition rd2 = new();
        rd2.Height = new GridLength(50);
        rdc.Add(rd1);
        rdc.Add(rd2);

        contextGrid.RowDefinitions = rdc;

        ProgressBar progressBar = new ProgressBar
        {
            // Progress = ((double) ot!.No + 1) / GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT.Count,
            Progress = 0.001,
            ProgressColor = Colors.Orange
        };
        progressBar.HeightRequest = 20;
        GameProgressBar = progressBar;
        GameProgressState = 0;
        Thickness m = new(20, 0, 20, 0);
        progressBar.Margin = m;
        contextGrid.Add(progressBar);

        List<string> LabelStyle = new();
        LabelStyle.Add("Label_Normal");

        GameProgressInfo = new Label();
        GameProgressInfo.Text = loca.MAUI_UI_Init; 
        GameProgressInfo.HorizontalOptions = LayoutOptions.Center;
        GameProgressInfo.VerticalOptions = LayoutOptions.Center;
        GameProgressInfo.StyleClass = LabelStyle;
        contextGrid.Add(GameProgressInfo);
        contextGrid.SetRow(GameProgressInfo, 1);


        currentReplayButton = CreateButtonMaxWidth(contextGrid, loca.MAUI_UI_CME_Cancel, 2, ot!.No, 200, DoStopReplay);
        _menuExtension!.ListCalls.Add(new ListCall(StartReplay, 1));
    }

    public void HandleOrderTableDialog( object? sender, int ID, string? Headline)
    { 
        IDButton? b = (sender as IDButton)!;

        Point p3 = ScreenCoords.GetScreenCoords(b);

        p3.Y += b!.Height + 3;

        Rect pd = new();
        pd.X = p3.X;
        pd.Y = p3.Y;
        pd.Width = 600;
        pd.Height = 400;


        pd = _menuExtension!.CalcBounds(pd);


        string? Text = Headline; 
        _menuExtension!.OpenShowMenu(true, pd, false, Text);


        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            OrderTable ot1 = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx!]!.OT![ID - 1]!;
            OrderTable ot2 = GD!.OrderList!.CloneOT(ot1);
            _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData = ot2;

            SetCMEdit(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView!, ot2);
        }

    }

    public void EditOrderTableDialog( object? sender )
    {
        IDButton? b = (sender as IDButton);

        _menuExtension!.DestroyMEMenus();
            
        // MEMenus[_menuExtension!.MEMenus.Count - 1].Rdfdsfds

        HandleOrderTableDialog(sender, b!.ID, loca.MAUI_UI_Edit_Of + b!.ID + ") " + GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx]!.OT![b!.ID - 1]!.OrderText);
    }
    public void InsertOrderTableDialog(object? sender)
    {
        IDButton? b = (sender as IDButton)!;

        _menuExtension.DestroyMEMenus();


        OrderTable ot = new();
        ot.oAc = true;
        ot.oTy = orderType.orderText;

        GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT!.Insert(b!.ID, ot);



        for ( int ix = 0; ix < GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx]!.OT!.Count; ix++)
        {
            GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ix].No = ix + 1;
            if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ix].OrderPath == null)
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ix].OrderPath = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ix - 1].OrderPath;

        }
        RefreshHierarchie(LatestDestPos);

        HandleOrderTableDialog(sender!, b.ID + 1, loca.MAUI_UI_New_Entry + (b.ID+1) + ") " + ot );

    }

    public void EditReplayListNameInnerView(Grid contextGrid, int o)
    {
        int id = o;
        // OrderListTable olt = o as OrderListTable;

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


        string? newName = "";
        newName = GD!.OrderList!.OTL![id].Name;
        _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData = id;

        List<string> LabelStyle = new();
        LabelStyle.Add("Entry_BGBG");
        Entry l1 = new();
        l1.Text = newName; //  _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData as string;
        l1.VerticalOptions = LayoutOptions.Center;
        l1.HorizontalOptions = LayoutOptions.Center;
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


        CreateButtonXYString(ButtonGrid, loca.MAUI_UI_CME_Ok, 1, 1, newName, DoEditReplayListName );
        CreateButtonXYString(ButtonGrid, loca.MAUI_UI_CME_Cancel, 3, 1, newName, DoCancel);

    }

    public void DeleteReplayListInnerView(Grid contextGrid, int o)
    {
        int id = o;
        // OrderListTable olt = o as OrderListTable;

        contextGrid.Children.Clear();

        RowDefinitionCollection rdc = new();
        RowDefinition rd1 = new();
        rd1.Height = new GridLength(1, GridUnitType.Star);

        RowDefinition rd2 = new();
        rd2.Height = new GridLength(40);
        rdc.Add(rd1);
        rdc.Add(rd2);
        contextGrid.RowDefinitions = rdc;

        Grid TextGrid = new();
        contextGrid.Add(TextGrid);
        contextGrid.SetRow(TextGrid, 0);

        string newName = "";
        newName = loca.MAUI_UI_DRLIV_Really_Delete1 + string.Copy(GD!.OrderList!.OTL![id].Name!) + loca.MAUI_UI_DRLIV_Really_Delete2; //  "' wirklich löschen?";
        _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData = id;

        List<string> LabelStyle = new();
        LabelStyle.Add("Label_Normal");
        Label l1 = new();
        l1.Text = newName; //  _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData as string;
        l1.VerticalOptions = LayoutOptions.Center;
        l1.HorizontalOptions = LayoutOptions.Center;
        TextGrid.Add(l1);
        l1.StyleClass = LabelStyle;




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


        CreateButtonXYString(ButtonGrid, loca.MAUI_UI_CME_Ok, 1, 1, newName, DoDeleteReplayList);
        CreateButtonXYString(ButtonGrid, loca.MAUI_UI_CME_Cancel, 3, 1, newName, DoCancel);

    }

    public void NewReplayDialogInnerView(Grid? contextGrid, int no)
    {
        int id = no;

        contextGrid!.Children!.Clear();

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
        LabelStyle.Add("Entry_BGBG");

        string newName = loca.MAUI_UI_New; //  "Neu";
        // newName = string.Copy(GD!.OrderList!.OTL![id].Name);
        _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData = id;

        Entry l1 = new();
        l1.Text = newName; //  _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData as string;
        l1.VerticalOptions = LayoutOptions.Center;
        l1.HorizontalOptions = LayoutOptions.Center;
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


        CreateButtonXYString(ButtonGrid, loca.MAUI_UI_CME_Ok, 1, 1, newName, DoNewReplayButton);
        CreateButtonXYString(ButtonGrid, loca.MAUI_UI_CME_Cancel, 3, 1, newName, DoCancel);

    }

    public void NewReplayDialog(object? sender)
    {
        if( _menuExtension.MEMenus.Count > 0 )
            _menuExtension.DestroyMEMenus();

        IDButton? b = (sender as IDButton)!;

        Point p3 = ScreenCoords.GetScreenCoords(b);

        p3.Y += b!.Height + 3;

        Rect pd = new();
        pd.X = p3.X;
        pd.Y = p3.Y;
        pd.Width = 600;
        pd.Height = 200;


        pd = _menuExtension!.CalcBounds(pd);


        string Text = loca.MAUI_UI_New_Replay; //  "Neuer Replay:";
        _menuExtension!.OpenShowMenu(true, pd, false, Text);

        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            NewReplayDialogInnerView(_menuExtension!.MEMenus![_menuExtension!.MEMenus!.Count - 1]!.InnerView, b.ID );
        }
    }

    public void EditReplayListName (object? sender )
    {
        IDButton? b = (sender as IDButton)!;

        Point p3 = ScreenCoords.GetScreenCoords(b);

        p3.Y += b!.Height + 3;

        Rect pd = new();
        pd.X = p3.X;
        pd.Y = p3.Y;
        pd.Width = 600;
        pd.Height = 200;


        pd = _menuExtension!.CalcBounds(pd);


        string Text = loca.MAUI_UI_Change_Name + GD!.OrderList!.OTL![b.ID].Name;
        _menuExtension!.OpenShowMenu(true, pd, false, Text);

        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {

            OrderListTable olt1 = GD!.OrderList!.OTL![b.ID];
            EditReplayListNameInnerView(_menuExtension!.MEMenus![_menuExtension!.MEMenus!.Count - 1]!.InnerView!, b!.ID);
        }
    }
    public void DeleteReplayList(object? sender)
    {
        IDButton? b = (sender as IDButton)!;

        Point p3 = ScreenCoords.GetScreenCoords(b);

        p3.Y += b.Height + 3;

        Rect pd = new();
        pd.X = p3.X;
        pd.Y = p3.Y;
        pd.Width = 400;
        pd.Height = 200;


        pd = _menuExtension!.CalcBounds(pd);


        string Text = loca.MAUI_UI_Replay_Delete + GD!.OrderList!.OTL![b!.ID].Name;
        _menuExtension!.OpenShowMenu(true, pd, false, Text);

        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {

            OrderListTable olt1 = GD!.OrderList!.OTL![b.ID];
            DeleteReplayListInnerView(_menuExtension!.MEMenus![_menuExtension!.MEMenus!.Count - 1]!.InnerView!, b.ID);
        }
    }
    public void InsertOrderTableDialogBefore(object? sender)
    {
        _menuExtension.DestroyMEMenus();

        IDButton? b = (sender as IDButton)!;

        OrderTable ot = new();
        ot.oAc = true;
        ot.oTy = orderType.orderText;

        GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT!.Insert(b!.ID-1, ot);



        for (int ix = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT!.Count -1; ix >= 0; ix--)
        {
            GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ix].No = ix + 1;
            if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ix].OrderPath == null)
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ix].OrderPath = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ix + 1].OrderPath;

        }
        RefreshHierarchie(LatestDestPos);

        HandleOrderTableDialog(sender, b.ID, loca.MAUI_UI_New_Entry + (b!.ID ) + ") " + ot);

    }

    public void ReplayDialog( int id, Point p3 )
    {
        if (_menuExtension.MEMenus.Count > 0)
            _menuExtension.DestroyMEMenus();

        Rect pd = new();
        pd.X = p3.X;
        pd.Y = p3.Y;
        pd.Width = 600;
        pd.Height = 200;


        pd = _menuExtension!.CalcBounds(pd);


        string Text = loca.MAUI_UI_Replay_Of + GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx]!.Name;
        _menuExtension!.OpenShowMenu(true, pd, true, Text);

        /*
        _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].HeadlineVisible = true;
        _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].Headline = Text;
        _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].PosDim = pd;
        _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].Visible = true;
        */

        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            OrderTable ot1 = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ id - 1];
            OrderTable ot2 = GD!.OrderList!.CloneOT(ot1);
            SetCMReplay(_menuExtension!.MEMenus![_menuExtension!.MEMenus!.Count - 1]!.InnerView!, ot2);
        }

        // BlueBox.IsVisible = true;
        // AbsoluteLayout.SetLayoutBounds(BlueBox, new Rect(p3.X, p3.Y, 400, 200));
    }

    public void ReplayDialogFromCMOrderTable( object? sender )
    {
        IDButton? b = (sender as IDButton)!;

        Point p3 = ScreenCoords.GetScreenCoords(b);

        p3.Y += b.Height + 3;


        ReplayDialog(b.ID, p3);

        /*
        Rect pd = new();
        pd.X = p3.X;
        pd.Y = p3.Y;
        pd.Width = 600;
        pd.Height = 200;


        pd = _menuExtension!.CalcBounds(pd);


        string Text = "Replay von: " + GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].Name;
        _menuExtension!.OpenShowMenu(true, pd, Text);


        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            OrderTable ot1 = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![b.ID - 1];
            OrderTable ot2 = GD!.OrderList!.CloneOT(ot1);
            SetCMReplay(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView, ot2);
        }
        // BlueBox.IsVisible = true;
        // AbsoluteLayout.SetLayoutBounds(BlueBox, new Rect(p3.X, p3.Y, 400, 200));
*/
    }
    public void ReplayDialogFromReplayTable(object? sender)
    {
        IDButton? b = (sender as IDButton);

        Point p3 = ScreenCoords.GetScreenCoords(b!);

        p3.Y += b!.Height + 3;

        ReplayDialog(GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx]!.OT!.Count-1, p3);

        /*
        Rect pd = new();
        pd.X = p3.X;
        pd.Y = p3.Y;
        pd.Width = 600;
        pd.Height = 200;


        pd = _menuExtension!.CalcBounds(pd);


        string Text = "Replay von: " + GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].Name;
        _menuExtension!.OpenShowMenu(true, pd, Text);


        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            OrderTable ot1 = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![b.ID - 1];
            OrderTable ot2 = GD!.OrderList!.CloneOT(ot1);
            SetCMReplay(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView, ot2);
        }
        // BlueBox.IsVisible = true;
        // AbsoluteLayout.SetLayoutBounds(BlueBox, new Rect(p3.X, p3.Y, 400, 200));
*/
    }

    public void DeleteOrderTableDialog(object? sender)
    {
        IDButton? b = (sender as IDButton);

        Point p3 = ScreenCoords.GetScreenCoords(b);

        p3.Y += b!.Height + 3;

        Rect pd = new();
        pd.X = p3.X;
        pd.Y = p3.Y;
        pd.Width = 300;
        pd.Height = 200;


        pd = _menuExtension!.CalcBounds(pd);


        string Text = loca.MAUI_UI_Deletion_Of + GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ b.ID -1].OrderText;
        _menuExtension!.OpenShowMenu(true, pd, false, Text);

        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            OrderTable ot1 = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![b.ID - 1];
            _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData = ot1;
            SetDeleteMenu(_menuExtension!.MEMenus![_menuExtension!.MEMenus!.Count - 1]!.InnerView!, ot1);
        }
        // BlueBox.IsVisible = true;
        // AbsoluteLayout.SetLayoutBounds(BlueBox, new Rect(p3.X, p3.Y, 400, 200));
    }
    public void DoDelete(object? o, EventArgs ea)
    {
        int no; 
        _menuExtension!.CloseContextMenu();
        OrderTable ot = (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData as OrderTable)!;
        no = ot!.no;
        GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx!].OT!.Remove(ot);
        for (int ix = 0; ix < GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx!].OT!.Count; ix++)
        {
            GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx!].OT![ix]!.No = ix + 1;

        }
        RefreshHierarchie(no);
    }
    public void DoRename(object? o, EventArgs ea)
    {
        // int no;
        _menuExtension!.CloseContextMenu();
        int id = (int) _menuExtension!.MEMenus[_menuExtension!.MEMenus!.Count - 1]!.UserDefinedData!;

        Entry e = (((((o as View)!.Parent as View)!.Parent as Grid)!.Children![0] as Grid)!.Children[0] as Entry)!;
        string? NewName = e!.Text!;

        GD!.OrderList!.OTL![ id ]!.Name = NewName!;

        RefreshReplayLists();
        // RefreshHierarchie(no);
    }
    public void DoDeleteReplayList(object? o, EventArgs ea)
    {
        // int no;
        _menuExtension!.CloseContextMenu();
        int id = (int)_menuExtension!.MEMenus[_menuExtension!.MEMenus!.Count - 1]!.UserDefinedData!;

        // Entry e = ((((o as View).Parent as View).Parent as Grid).Children[0] as Grid).Children[0] as Entry;
        // string NewName = e.Text;

        // GD!.OrderList!.OTL![id].Name = NewName;

        OrderListTable olt = GD!.OrderList!.OTL![id];

        GD!.OrderList!.OTL.Remove(olt);

        RefreshReplayLists();
        if( id == GD!.OrderList!.CurrentOrderListIx )
            RefreshHierarchie(-1);
    }
    public void DoEditReplayListName(object? o, EventArgs ea)
    {
       // int no;
        _menuExtension!.CloseContextMenu();
        int id = (int)_menuExtension!.MEMenus[_menuExtension!.MEMenus!.Count - 1]!.UserDefinedData!;

        Entry? e = (((((o as View)!.Parent as View)!.Parent as Grid)!.Children[0] as Grid)!.Children[0] as Entry )!;
        string NewName = e.Text;

        GD!.OrderList!.OTL![id].Name = NewName;

        // OrderListTable olt = GD!.OrderList!.OTL![id];

        // GD!.OrderList!.OTL.Remove(olt);

        RefreshReplayLists();
        if (id == GD!.OrderList!.CurrentOrderListIx)
            RefreshHierarchie(-1);
    }
    public void DoNewReplayButton(object? o, EventArgs ea)
    {
        // int no;
        _menuExtension!.CloseContextMenu();
        int id = (int)_menuExtension!.MEMenus[_menuExtension!.MEMenus!.Count - 1]!.UserDefinedData!;

        Entry? e = ((((o as View)!.Parent as View)!.Parent as Grid)!.Children![0] as Grid)!.Children[0] as Entry;
        string NewName = e!.Text;

        GD!.OrderList!.OTL!.Add(new OrderListTable());
        int ix = GD!.OrderList!.OTL!.Count - 1;
        GD!.OrderList!.OTL![ix].OT = new();

        GD!.OrderList!.OTL![ix].Name = NewName;

        RefreshReplayLists();
        // RefreshHierarchie(no);
    }

    public void DoStopReplay(object? o, EventArgs ea)
    {
        replayRunning = false;
        _menuExtension!.CloseContextMenu();
    }
    public void DoCancelCMEdit(object? o, EventArgs ea)
    {
        _menuExtension!.CloseContextMenu();
    }
    public void DoCancel(object? o, EventArgs ea)
    {
        _menuExtension!.CloseContextMenu();
    }
    public void DoConfirmCMEdit(object? o, EventArgs ea)
    {
        _menuExtension!.CloseContextMenu();
        OrderTable? ot = (_menuExtension!.MEMenus[_menuExtension!.MEMenus!.Count - 1]!.UserDefinedData as OrderTable);
        GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ot!.No - 1] = ot;
        RefreshHierarchie( ot.No  );
    }
    public void DoSetActive(object? o, EventArgs ea)
    {
        _menuExtension!.CloseContextMenu();
        (_menuExtension!.MEMenus[_menuExtension!.MEMenus!.Count - 2]!.UserDefinedData as OrderTable)!.OrderActive = true;
        SetCMEdit(_menuExtension!.MEMenus![_menuExtension!.MEMenus!.Count - 2]!.InnerView, _menuExtension!.MEMenus![_menuExtension!.MEMenus!.Count - 2]!.UserDefinedData as OrderTable);


    }
    public void DoSetInactive(object? o, EventArgs ea)
    {
        _menuExtension!.CloseContextMenu();
        (_menuExtension!.MEMenus[_menuExtension!.MEMenus!.Count - 2]!.UserDefinedData as OrderTable)!.OrderActive = false;
        SetCMEdit(_menuExtension!.MEMenus[_menuExtension!.MEMenus!.Count - 2]!.InnerView, _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 2]!.UserDefinedData as OrderTable);
    }
    public void DoSetToText( object? o, EventArgs ea )
    {
        _menuExtension!.CloseContextMenu();
        (_menuExtension!.MEMenus[_menuExtension!.MEMenus!.Count - 2]!.UserDefinedData as OrderTable)!.OrderType = orderType.orderText;
        SetCMEdit(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 2].InnerView, _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 2].UserDefinedData as OrderTable);
    }
    public void DoSetToChoice(object? o, EventArgs ea)
    {
        _menuExtension!.CloseContextMenu();
        (_menuExtension!.MEMenus[_menuExtension!.MEMenus!.Count - 2]!.UserDefinedData as OrderTable)!.OrderType = orderType.mcChoice;
        SetCMEdit(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 2].InnerView, _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 2].UserDefinedData as OrderTable);
    }
    public void DoSetToComment(object? o, EventArgs ea)
    {
        _menuExtension!.CloseContextMenu();
        (_menuExtension!.MEMenus[_menuExtension!.MEMenus!.Count - 2]!.UserDefinedData as OrderTable)!.OrderType = orderType.comment;
        SetCMEdit(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 2].InnerView, _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 2].UserDefinedData as OrderTable);
    }
    public void DoSetToFalseInput(object? o, EventArgs ea)
    {
        _menuExtension!.CloseContextMenu();
        (_menuExtension!.MEMenus[_menuExtension!.MEMenus!.Count - 2]!.UserDefinedData as OrderTable)!.OrderType = orderType.noText;
        SetCMEdit(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 2].InnerView, _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 2].UserDefinedData as OrderTable);
    }

    public int TargetNo;

    public bool StartReplay()
    {
        if (GD!.Adventure == null)
        {
            GD!.Adventure = new GameCore.Adv(true, false);
            GD!.Adventure!.Orders!.ReadSlotDescription();
        }
        GD!.ValidRun = true;

        OrderListPlayToStart(TargetNo, GD!.OrderList!.CurrentViewOrderListIx);
        // OrderListPlayTo(TargetNo, GD!.OrderList!.CurrentViewOrderListIx);

        return true;
    }

    public void DoButtonPlayTo(object? o, EventArgs ea)
    {
        TargetNo = (o as IDButton)!.ID;

        /*
        GD!.Adventure = new GameCore.Adv(GD, GD!.UIS, false);
        GD!.ValidRun = true;

        OrderListPlayTo(TargetNo, GD!.OrderList!.CurrentViewOrderListIx);
        */

        _menuExtension!.SwitchContextMenu(ReplayDialogFromCMOrderTable, o);
        // int a = 5;
    }
    public void DoButtonOTEdit(object? o, EventArgs ea)
    {
        _menuExtension!.SwitchContextMenu(EditOrderTableDialog, o);
    }
    public void DoButtonOTDelete(object? o, EventArgs ea)
    {
        _menuExtension!.SwitchContextMenu(DeleteOrderTableDialog, o);

    }
    public void DoButtonOTInsert(object? o, EventArgs ea)
    {
        _menuExtension!.SwitchContextMenu(InsertOrderTableDialog, o);

    }
    public void DoButtonOTInsertBefore(object? o, EventArgs ea)
    {
        _menuExtension!.SwitchContextMenu(InsertOrderTableDialogBefore, o);

    }

    public void DoClickReplayGrid(object? sender, EventArgs ea)
    {
        if( GD!.DebugMode == true )
            DoClickReplay(sender, ea);
        /*
        int a = 5;

        bool doCont = true;

        Button b = (sender as OrderListView).TextButton;

        Point p3 = ScreenCoords.GetScreenCoords(b);

        p3.Y += b.Height + 3;

        PosDim pd = new();
        pd.XPos = p3.X;
        pd.YPos = p3.Y;
        pd.Width = 400;
        pd.Height = 250;


        _menuExtension!.ContextMenuPosDim = pd;
        _menuExtension!.ContextMenuVisible = true;
        // BlueBox.IsVisible = true;
        // AbsoluteLayout.SetLayoutBounds(BlueBox, new Rect(p3.X, p3.Y, 400, 200));
        */
    }

    private void SetLanguage()
    {
        WindowTitle.Text = loca.MAUI_UI_Replay_WindowTitle;
        ReplayListLabel.Text = loca.MAUI_UI_ReplayLists;
        SearchInfoPT.Text = loca.MAUI_Search_Info;
        SearchInfo.Text = loca.MAUI_Search_Info;

        _menuExtension!.SetLanguage();
    }

    IGlobalData.screenMode lastSM = IGlobalData.screenMode.unclear;

    public void DoResize(double width, double height)
    {
        if( width > height && lastSM != IGlobalData.screenMode.landscape )
        {
            lastSM = IGlobalData.screenMode.landscape;
            ChangeOrientation(lastSM);
        }
        else if ( height > width && lastSM != IGlobalData.screenMode.portrait )
        {
            lastSM = IGlobalData.screenMode.portrait;
            ChangeOrientation(lastSM);
        }

    }
    private async void Clicked_Keyboard(object? sender, EventArgs e)
    {
        if (SearchText.IsSoftKeyboardShowing() == false)
        {
            await SearchText.ShowKeyboardAsync(CancellationToken.None);
            // ForceInputFocus();
        }
        else
            await SearchText.HideKeyboardAsync(CancellationToken.None);
    }

    private async void Clicked_Microphone(object? sender, EventArgs e)
    {
        if (UIS.STTListeningOn == IUIServices.sttListeningMode.off)
        {
            if (GD!.STTMicroState == IGlobalData.microMode.continuous)
            {
                // Mike.Background = Colors.Red;
                await UIS.STTStartListening(IUIServices.sttListeningMode.continuous);
            }
            else if( GD!.STTMicroState == IGlobalData.microMode.once )
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


    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        if(GD!.OrderList!.CurrentViewOrderListIx <= 0)
            GD!.OrderList!.CurrentViewOrderListIx = GD!.OrderList!.OTL!.Count-1;

        GlobalData.CurrentGlobalData!.UIS = UIS;

        if( GD.DebugMode == false)
            GD!.OrderList!.CurrentViewOrderListIx = GD!.OrderList!.CurrentOrderListIx;

        _viewModelGeneral.SetCallbackChangeOrientation((IGlobalData._callbackChangeOrientation)ChangeOrientation);
        _viewModelGeneral.SetCallbackResize((IGlobalData._callbackResize)DoResize);

        ChangeOrientation(GD!.LayoutDescription.ScreenMode);
        base.OnNavigatedTo(args);

        await _viewModelMain.Initialize();

        _viewModelGeneral.InitResize(this.Width, this.Height);

        _menuExtension!.ResetLayout();

        LoadCurrentOrderlist();

        SetLanguage();

        UIS.STTListenigModeChangeCB = SetMicrophone;

        _menuExtension!.QuitMethod = PressEndLocal;
        _menuExtension.ListCalls.Add(new(DoSpeech, -1));

        if (GD.STTMicroState == IGlobalData.microMode.off)
        {
            Grid_Search.ColumnDefinitions[1].Width = new GridLength(0);
            Mike.IsVisible = false;
         }
        else
        {
            Grid_Search.ColumnDefinitions[1].Width = new GridLength(40);
            Mike.IsVisible = true;
         }
    }
    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        _menuExtension!.RemoveListCall(DoSpeech);
        UIS.STTStopListening();
        if (SearchText.IsSoftKeyboardShowing() == true)
            SearchText.HideKeyboardAsync(CancellationToken.None);
        if (SearchTextPT.IsSoftKeyboardShowing() == true)
            SearchTextPT.HideKeyboardAsync(CancellationToken.None);

        _menuExtension!.QuitMethod = null;
    }
    public void SetMicrophone(Phoney_MAUI.Model.IUIServices.sttListeningMode mode)
    {
        if (mode == IUIServices.sttListeningMode.off)
        {
            UIS.NewMikeColor = Colors.White;
        }
        else if (mode == IUIServices.sttListeningMode.on)
        {
            UIS.NewMikeColor = Colors.LightGreen;

        }
        else if (mode == IUIServices.sttListeningMode.continuous)
        {
            UIS.NewMikeColor = Colors.Red;
        }
    }

    public bool DoSpeech()
    {
        if (UIS.RecordedText != null)
        {
            if (UIS.RecordedText.Length > 0)
            {

            }
        }
        if (UIS.NewMikeColor != Colors.Brown)
        {
            Mike.TextColor = UIS.NewMikeColor;
             UIS.NewMikeColor = Colors.Brown;
        }
        // if (DeviceDisplay.MainDisplayInfo == null) return true;
        if (GlobalData.CurrentGlobalData!.UIS!.RecordedText == null)
        {

        }
        else if (GlobalData.CurrentGlobalData.UIS.RecordedText.Length > 0 /* && UIS.STTListeningOn != IUIServices.sttListeningMode.off */ )
        {
            SearchText.Text = UIS.RecordedText;
            UIS.RecordedText = "";
            UIS.STTStopListening(false);
        }
        return true;
    }

    public void Search()
    {
        string x = SearchText.Text;
    }
    public void SearcHandler(object? sender, EventArgs e)
    {
        string x = SearchText.Text;

    }

    public int SearchCurrentTableForNo( int no)
    {
        int ix = 0;

        ObservableCollection<OrderTable>? ot = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx!]!.OT;

        for( ix = 0; ix < ot!.Count; ix ++)
        {
            if (ot[ix].No == no)
            {
                break;
            }
        }

        if (ix < ot.Count)
            return ix;
        else
            return -1;
    }

    public View? FindViewFromNo( int no)
    {
        View? v = null;
        TreeView? tv = _treeViewRoot;

        foreach( Grid tvi in tv!.Children)
        {
            if( tvi.Children.Count > 0 )
            {
                v = FindViewFromTVINo(tvi, no);
            }
        }
        return v;
    }
    public View? FindViewFromTVINo(View tvi, int no)
    {
        View? v = null;

        if (tvi.GetType() == typeof(Grid) || tvi.GetType() == typeof(TreeViewItem) || tvi.GetType() == typeof(OrderListView))
        {
            Grid? gvi = tvi as Grid;

            if (gvi!.Children.Count > 0)
            {
                foreach (View tvi2 in gvi!.Children)
                {
                    if (tvi2.GetType() == typeof(Grid) || tvi2.GetType() == typeof(TreeViewItem) || tvi2.GetType() == typeof(OrderListView))
                    {
                        Grid? gvi2 = tvi2 as Grid;
                        if (gvi2!.Children!.Count > 0)
                        {
                            v = FindViewFromTVINo(gvi2, no);
                        }
                    }

                    if (tvi2.GetType() == typeof(OrderListView))
                    {
                        OrderListView? olv = tvi2 as OrderListView;

                        if (olv!.StepNo == no)
                        {
                            v = tvi2;
                            break;
                        }
                    }
                }
            }
        }
        return v;
    }

    public bool DoCenter(  )
    {
        double x = ReplayScroll.Height;

        View? v = FindViewFromNo(LatestDestPos);

        if( v != null )
            _treeViewRoot!.CenterTable(ReplayScroll, v );
        return true;
    }
    private void SearchBackwardHandler(object? sender, EventArgs e)
    {
        string searchString = SearchText.Text;

        if (searchString == null || searchString == "")
        {
            CurrentNo--;
            int ix = SearchCurrentTableForNo(CurrentNo);
            if (ix == -1)
                ix = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].Point - 1].No;

            // Obacht: Dieser Hack geht davon aus, das No immer eins größer ist als der Index
            CurrentNo = ix + 1;

            if (_treeViewRoot != null)
            { 
                _treeViewRoot.CloseAllOpenEntry(CurrentNo);
                LatestDestPos = CurrentNo;
                // DoCenter();
                _menuExtension!.ListCalls.Add(new ListCall(DoCenter, 2));
            }
        }
        else
        {
            int tempNo = SearchCurrentTableForNo(CurrentNo);
            int StartIndex = tempNo;
            if (tempNo == -1)
                tempNo = StartIndex = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx!]!.OT!.Count-1;

            bool found = false;

            do
            {
                tempNo--;
                if (tempNo < 0)
                    tempNo = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx]!.OT!.Count - 1;


                if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![tempNo].OrderText!.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                {
                    found = true;
                    break;
                }
            }
            while (!found && tempNo != StartIndex);

            if (found)
            {
                SearchInfo.Text = loca.MAUI_Search_Found;
                CurrentNo = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![tempNo].No;
                if (_treeViewRoot != null)
                {
                    _treeViewRoot.CloseAllOpenEntry(CurrentNo);
                    LatestDestPos = CurrentNo;
                    // DoCenter();
                    _menuExtension!.ListCalls.Add(new ListCall(DoCenter, 2));
                }
            }
            else
                SearchInfo.Text = loca.MAUI_Search_Not_Found;

        }

    }
    private void SearchForwardHandler(object? sender, EventArgs e)
    {
        string searchString = SearchText.Text;


        if( searchString == null || searchString == "")
        {
            CurrentNo++;
            int ix = SearchCurrentTableForNo(CurrentNo);
            if (ix == -1)
                ix = 1;
            if(GD!.OrderList!.CurrentViewOrderListIx <= GD!.OrderList!.OTL!.Count )
            {
                if( ix <= GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT!.Count )
                {
                    if (_treeViewRoot != null)
                    {
                        _treeViewRoot.CloseAllOpenEntry(CurrentNo);
                        LatestDestPos = CurrentNo;
                        // DoCenter();
                        _menuExtension!.ListCalls.Add(new ListCall(DoCenter, 2));
                    }

                }
            }
            CurrentNo = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ix].No;
        }
        else
        {
            int tempNo = SearchCurrentTableForNo( CurrentNo );
            int StartIndex = tempNo;
            tempNo++;
            if (tempNo == 0)
            {
                tempNo = 0;
                StartIndex = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT!.Count - 1;
            }
            bool found = false;

            while( !found && tempNo != StartIndex )
            {
                if (tempNo >= GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT!.Count)
                    tempNo = 0;


                if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![tempNo].OrderText!.Contains( searchString, StringComparison.OrdinalIgnoreCase) == true )
                {
                    found = true;
                    break;
                }
                tempNo++;
            }
            if( found )
            {
                SearchInfo.Text = loca.MAUI_Search_Found;
                CurrentNo = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![tempNo].No;
                if (_treeViewRoot != null)
                {
                    _treeViewRoot.CloseAllOpenEntry(CurrentNo);
                    LatestDestPos = CurrentNo;
                    // DoCenter();
                    _menuExtension!.ListCalls.Add(new ListCall(DoCenter, 2));
                }
            }
            else
                SearchInfo.Text = loca.MAUI_Search_Not_Found;

        }
    }
    private void SearchBackwardHandlerPT(object? sender, EventArgs e)
    {
        string searchString = SearchTextPT.Text;

        if (searchString == null || searchString == "")
        {
            CurrentNo--;
            int ix = SearchCurrentTableForNo(CurrentNo);
            if (ix == -1)
                ix = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].Point - 1].No;

            // Obacht: Dieser Hack geht davon aus, das No immer eins größer ist als der Index
            CurrentNo = ix + 1;

            if (_treeViewRoot != null)
            {
                _treeViewRoot.CloseAllOpenEntry(CurrentNo);
                LatestDestPos = CurrentNo;
                // DoCenter();
                _menuExtension!.ListCalls.Add(new ListCall(DoCenter, 2));
            }
        }
        else
        {
            int tempNo = SearchCurrentTableForNo(CurrentNo);
            int StartIndex = tempNo;
            if (tempNo == -1)
            {
                tempNo = StartIndex = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx]!.OT!.Count-1;
            }
            bool found = false;

            do
            {
                tempNo--;
                if (tempNo < 0)
                    tempNo = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT!.Count - 1;


                if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![tempNo].OrderText!.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                {
                    found = true;
                    break;
                }
            }
            while (!found && tempNo != StartIndex);

            if (found)
            {
                SearchInfoPT.Text = loca.MAUI_Search_Found;

                CurrentNo = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![tempNo].No;
                if (_treeViewRoot != null)
                {
                    _treeViewRoot.CloseAllOpenEntry(CurrentNo);
                    LatestDestPos = CurrentNo;
                    // DoCenter();
                    _menuExtension!.ListCalls.Add(new ListCall(DoCenter, 2));
                }
            }
            else
                SearchInfoPT.Text = loca.MAUI_Search_Not_Found;

        }

    }
    private void SearchForwardHandlerPT(object? sender, EventArgs e)
    {
        string searchString = SearchTextPT.Text;


        if (searchString == null || searchString == "")
        {
            CurrentNo++;
            int ix = SearchCurrentTableForNo(CurrentNo);
            if (ix == -1)
                ix = 1;

            CurrentNo = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ix].No;
            if (_treeViewRoot != null)
            {
                _treeViewRoot.CloseAllOpenEntry(CurrentNo);
                LatestDestPos = CurrentNo;
                // DoCenter();
                _menuExtension!.ListCalls.Add(new ListCall(DoCenter, 2));
            }
        }
        else
        {
            int tempNo = SearchCurrentTableForNo(CurrentNo);
            int StartIndex = tempNo;
            tempNo++;
            if (tempNo == 0)
            {
                tempNo = 0;
                StartIndex = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT!.Count - 1;
            }

            bool found = false;

            while (!found && tempNo != StartIndex)
            {
                if (tempNo >= GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT!.Count)
                    tempNo = 0;


                if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![tempNo].OrderText!.Contains(searchString, StringComparison.OrdinalIgnoreCase) == true)
                {
                    found = true;
                    break;
                }
                tempNo++;
            }
            if (found)
            {
                SearchInfoPT.Text = loca.MAUI_Search_Found;

                CurrentNo = GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![tempNo].No;
                if (_treeViewRoot != null)
                {
                    _treeViewRoot.CloseAllOpenEntry(CurrentNo);
                    LatestDestPos = CurrentNo;
                    // DoCenter();
                    _menuExtension!.ListCalls.Add(new ListCall(DoCenter, 2));
                }
            }
            else
                SearchInfoPT.Text = loca.MAUI_Search_Not_Found;

        }
    }
    public void SetContextMenuReplayList(Grid contextGrid, int val)
    {
        contextGrid.Children.Clear();

        RowDefinitionCollection rdc = new();
        RowDefinition rd1 = new();
        rd1.Height = GridLength.Auto;
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);

        contextGrid.RowDefinitions = rdc;

        CreateButtonOrderList(contextGrid, loca.MAUI_UI_View_Replay, 0, val, DoViewReplay);
        CreateButtonOrderList(contextGrid, loca.MAUI_UI_Play_Replay, 1, val, DoPlayReplay);
        CreateButtonOrderList(contextGrid, loca.MAUI_UI_Name_Edit, 2, val, DoEditReplayName);
        CreateButtonOrderList(contextGrid, loca.MAUI_UI_New_Replay2, 3, val, DoNewReplay);
        CreateButtonOrderList(contextGrid, loca.MAUI_UI_Delete_Replay, 4, val, DoDeleteReplay);
    }
    public void DoPlayReplay(object? sender, EventArgs ea)
    {
        IDButton? b1 = sender as IDButton;
        GD!.OrderList!.CurrentViewOrderListIx = b1!.ID;

        TargetNo = GD!.OrderList!.OTL![ b1!.ID ].OT!.Count;

        // TargetNo = (o as IDButton).ID;
        IDButton? b = sender as IDButton;
        GD!.OrderList!.CurrentViewOrderListIx = b!.ID;
        LoadCurrentOrderlist();
        _menuExtension!.SwitchContextMenu(ReplayDialogFromReplayTable, sender);
    }
    public void DoNewReplay(object? sender, EventArgs ea)
    {
        _menuExtension!.SwitchContextMenu(NewReplayDialog, sender);
    }
    public void DoDeleteReplay(object? sender, EventArgs ea)
    {
        _menuExtension!.SwitchContextMenu(DeleteReplayList, sender);
    }
    public void DoEditReplayName(object? sender, EventArgs ea)
    {
        _menuExtension!.SwitchContextMenu(EditReplayListName, sender);

    }

    public void DoEditReplay(object? sender, EventArgs ea)
    {
        // int a = 5;

        // bool doCont = true;

        IDButton? b = sender as IDButton;

        Point p3 = ScreenCoords.GetScreenCoords(b);

        p3.Y += b!.Height + 3;

        Rect pd = new();
        pd.X = p3.X;
        pd.Y = p3.Y;
        pd.Width = 250;
        pd.Height = 260;


        pd = _menuExtension!.CalcBounds(pd);

        int val = b.ID ;

    
        string? Text = GD!.OrderList!.OTL![val].Name;

        /*
        _menuExtension!.ContextMenuHeadlineVisible = true;
        _menuExtension!.ContextMenuHeadline = Text;
        _menuExtension!.ContextMenuPosDim = pd;
        _menuExtension!.ContextMenuVisible = true;
        */

        _menuExtension!.OpenShowMenu(true, pd, false, Text);


        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            _menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].UserDefinedData = val;
            SetContextMenuReplayList(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView!, val);
        }
        // BlueBox.IsVisible = true;
        // AbsoluteLayout.SetLayoutBounds(BlueBox, new Rect(p3.X, p3.Y, 400, 200));
    }
    private void SelectReplayList(object? sender, EventArgs e)
    {
        DoEditReplay(sender, e);
    }

    private void DoViewReplay( object? sender, EventArgs e)
    { 

        IDButton? b1 = (sender as IDButton)!;

        GD!.OrderList!.CurrentViewOrderListIx = b1.ID;

        LoadCurrentOrderlist();
        _menuExtension!.CloseContextMenu();
    }
    public IUIServices? GetUIServices()
    {
        return null;
    }

    public Label GetMenuTitle()
    {
        return WindowTitle;
    }
    protected override void OnSizeAllocated(double width, double height)
    {
        _viewModelGeneral!.CheckSize(width, height).Wait();

        base.OnSizeAllocated(width, height);

    }

    public void OrderListPlayTo(int index, int orderListIndex, bool recursive = false)
    {
        if (GD!.UIS?.MCM?.MCS?.Visible == true)
        {
            GD!.UIS.MCM.MCS.Close();
        }
        GD!.SilentMode = true;
        // OrderList olTemp = OrderList!.Clone();

        // DoMCRestart(false);

        // OrderList = olTemp;
        // Inputline.Text = "";
        int listeNr = orderListIndex;
        GD!.OrderList!.CurrentOrderListIx = orderListIndex;
        GD!.OrderList!.ResetTempOrderList();
        GD!.OrderList!.ResetTempOrderListCurrentRun();


        // Besonderheit: Ein Klick auf die erste Liste kopiert diese Liste ans Ende der Orderliste und ermöglicht somit, im aktuell erreichten hin und her zu springen
        if (listeNr == 0)
        {
            GD!.OrderList!.AddOrderList("Kopie von 'Aktuelles Spiel'");
            GD!.OrderList!.CurrentOrderListIx = GD!.OrderList!.OTL!.Count - 1;
            foreach (OrderTable ot in GD!.OrderList!.OTL![0].OT!)
            {
                int val = 0;
                GD!.OrderList!.AddOrder(ot.OrderType, ot.OrderText, ot.OrderChoice, ot.oLG, null, null, ref val, true);
            }
            listeNr = GD!.OrderList!.CurrentOrderListIx;
            GD!.OrderList!.SyncOrderList();
            GD!.OrderList!.SaveOrderTable();

        }

        GD!.OrderList!.CurrentOrderListIx = listeNr;

        int ix = 0;
        // int ixPreDialog = 0;

        GD!.OrderList!.ResetCurrentRun();


        GD!.ValidRun = true;
        GD!.OrderList!.ReleaseColletion();

        GD!.InterruptedDialog = false;

        GD!.OrderListFinalIx = index;

        foreach (OrderTable otParse in GD!.OrderList!.OTL![listeNr]!.OT!)
        {
            otParse.OrderPath = null;
        }

        foreach (OrderTable otParse in GD!.OrderList!.OTL![listeNr]!.OT!)
        {
            if( recursive == false)
            {
                GameProgressBar!.Progress = ((double)ix + 1) / ((double)index);
                GameProgressInfo!.Text = (ix + 1).ToString() + ". " + GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ix].OrderText;
            }

            if ( ix + 1 == 27 )
            {
                // int a = 5;
            }

            if (GD!.ValidRun == false)
            {
                if (recursive == false)
                {
                    GameProgressInfo!.Text = String.Format(loca.CustomRequestHandler_OrderListPlayTo_16306, ix);
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = ix - 1;
                    OrderListPlayTo(ix - 1, orderListIndex, true);
                    GD!.ValidRun = false;
                }
                break;
            }

            if (otParse.OrderActive == false)
            {
                if (otParse.OrderType != orderType.mcChoice)
                {
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT![currentIndex].No = currentIndex + 1;

                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint++;
                }
                    // ix++;
                GD!.OrderList!.AddOrderCurrentRun(otParse.OrderType, otParse.OrderText, null, loca.GD!.Language, null, null);

            }
            else if (otParse.OrderType == orderType.orderText || otParse.OrderType == orderType.noText)
            {

                string? s = otParse.OrderText;


                // if ( s.StartsWith( "öffne zerfledderten Brief" ) == true )
                // {
                // s = s;
                // }
                if (otParse.OrderActive == false)
                {
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT![currentIndex].No = currentIndex + 1;
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint++;
                    GD!.OrderList!.AddOrderCurrentRun(otParse.OrderType, otParse.OrderText, null, loca.GD!.Language, null, null);

                }
                else if (s != null)
                {

                    if (GD!.OrderList!.OTL![listeNr].OT![ix]!.OrderType == orderType.mcChoice)
                    {
                        // Dieser Fall darf eigentlich gar nicht auftauchen
                    }
                    else
                    {
                        // Wir holen die nächste TempOrdertable ab, aber für die GameLoop-Aufrufe brauchen wir sie nicht
                        OrderTable ot = GD!.OrderList!.GetNextOrderTable();
                        // NOTEXTUMBAU
                        // if(otParse.orderType != orderType.noText)
                        GD!.OrderList!.AddOrderCurrentRun(otParse.OrderType, s, null, loca.GD!.Language, null, null);
                        GD!.LastCommandSucceeded = false;

  
                        GD!.Adventure!.DoGameLoop(s);

                        if (GD!.AskForPlayLevel)
                        {
                            GD!.Adventure!.Orders!.GenericDialog(null, GD!.Adventure!.Orders!.SetupDialog);
                            GD!.AskForPlayLevel = false;
                        }

                        if (GD!.LastCommandSucceeded == true && ot.OrderType == orderType.noText)
                            ot.OrderType = orderType.orderText;
                        if (GD!.LastCommandSucceeded == false && ot.OrderType == orderType.orderText)
                            ot.OrderType = orderType.noText;

                        // Obsolet
                        /*
                        if (Adventure!.Parser!.latestPTL != null)
                        {
                            ot.PTL = Adventure!.Parser.latestPTL;
                            ot.PTLSignatures = Adventure!.Parser!.latestPTLSignatures!;
                        }
                        */
                    }
                }

            }
            else if (otParse.OrderType == orderType.mcChoice)
            {
                if (otParse.OrderActive == false)
                {
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT![currentIndex].No = currentIndex + 1;
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint++;

                }
                else
                {
                    // int a = 5;

                }
                // int a = 5;
            }
            else if (otParse.OrderType == orderType.comment)
            {
                GD!.OrderList!.DoCreateOrderPath(GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT!, GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint);
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT![currentIndex].No = currentIndex + 1;
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint++;
                GD!.OrderList!.AddOrderCurrentRun(otParse.OrderType, otParse.OrderText, null, loca.GD!.Language, null, null);
                GD!.OrderList!.OTL![0].OT![currentIndex].No = currentIndex + 1;
                GD!.OrderList!.OTL![0].TempPoint++;
            }

            if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint - 1 >= index)
            {
                int ix2 = ix + 1;
                OrderTable ot1 = GD!.OrderList!.GetOrderTable(ix2);
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = index;

                break;
            }

            // Legacy seit 16.3.2023
            else if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint - 1 == index)
            {

                int ix2 = ix + 1;
                OrderTable ot1 = GD!.OrderList!.GetOrderTable(ix2);

                /* ORDERLISTDIALOG
                while (ot1 != null && ot1.OrderType == orderType.mcChoice)
                {
                    ix2++;
                    ot1 = GD!.OrderList!.GetOrderTable(ix2);
                }
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = ix2 - 1;
                */
                // ORDERLISTDIALOG
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = index;

                break;
            }
            else if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint - 1 > index)
            {
                int ix2 = ix + 1;
                OrderTable ot1 = GD!.OrderList!.GetOrderTable(ix2);

                /* ORDERLISTDIALOG
                while (ot1 != null && ot1.OrderType == orderType.mcChoice)
                {
                    ix2++;
                    ot1 = GD!.OrderList!.GetOrderTable(ix2);
                }
                  GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = ix2 - 1;
              */
                // ORDERLISTDIALOG
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = index;

                break;
            }


            ix++;

            if (ix!= GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint)
            {
                // int a = 5;
            }
        }
        if (GD!.InterruptedDialog)
        {
            GD!.SilentMode = false;
            // if (UIS.MCM == null)
            //     UIS.MCM = new();
            MCMenu x = GD!.InterruptedDialogMCM!;
            GD!.UIS!.MCM = x;
            GD!.UIS!.MCM.MCS = new Phoney_MAUI.Core.MCMenuView();
            GD!.Adventure!.Orders!.persistentMCMenu = x!;
            GD!.Adventure!.Orders!.temporaryMCMenu = null;

            GD!.UIS!.MCM.Set(GD!.InteruptedDialogID);
            GD!.UIS!.MCM.MCS.MCOutput(x, GD!.InterruptedDialogMCMSelection!, GD!.InterruptedDialogCanBeInterruped);


        }
        else if (GD!.UIS!.MCM != null)
        {
            while (GD!.UIS!.MCM!.MCS!.Visible)
            {
                GD!.UIS!.MCM!.MCS.Close();
            }

        }
        if (GD!.OrderList!.Collector != null)
        {
            GD!.OrderList!.FlushCollection();
        }
        GD!.OrderList!.DisableTempOrderList();

        if (GD!.ValidRun && !recursive)
            GD!.LastRunResult = String.Format(loca.CustomRequestHandler_OrderListPlayTo_16307, (GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point + 1));
        GD!.ValidRun = true;
        GD!.SilentMode = false;

        GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].RefreshCurrent();

        GD!.OrderList!.OTL![listeNr].Point = GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point;

        GD!.UIS.StoryTextObj!.FullRefresh = true;

#if !NEWSCROLL
        GD!.UIS.Scr.CompactToEnd();
#endif
        // UIS.StoryTextObj.RecalcLatest();
        // UIS.StoryTextObj.AdvTextRefresh();

        GD!.UIS.DoUIUpdate();
        GD!.UIS.StoryTextObj!.TextReFreshman();
        GD!.UIS.StoryTextObj!.AdvTextRefresh();
#if !NEWSCROLL
        GD!.UIS.Scr.JumpToEndInstantly();
#endif
        // DoUIUpdate();
        // UIS.Scr.CompactToEnd();
        // UpdateOrderList(OrderList);
    }


    bool replayRunning = false;
    int endIndex;
    int currentIndex;
    int currentOrderIndex;
    int currentListe;
    int nextTargetIndex;
    IDButton? currentReplayButton; 
    public void CalcNextTargetIndex()
    {
        nextTargetIndex = currentIndex + 10;

        if (nextTargetIndex >= endIndex )
            nextTargetIndex = endIndex;
    }

    public void OrderListPlayToStart(int index, int orderListIndex)
    {
        if (replayRunning == true) return;

        replayRunning = true;
        endIndex = index;
        currentOrderIndex = orderListIndex;

        if (GD!.UIS?.MCM?.MCS?.Visible == true)
        {
            GD!.UIS.MCM.MCS.Close();
        }
        GD!.SilentMode = true;

        currentListe = orderListIndex;
        GD!.OrderList!.CurrentOrderListIx = currentOrderIndex;
        GD!.OrderList!.ResetTempOrderList();
        GD!.OrderList!.ResetTempOrderListCurrentRun();


        // Besonderheit: Ein Klick auf die erste Liste kopiert diese Liste ans Ende der Orderliste und ermöglicht somit, im aktuell erreichten hin und her zu springen
        // Ist das überhaupt noch relevant?
        if (currentListe == 0)
        {
            GD!.OrderList!.AddOrderList("Kopie von 'Aktuelles Spiel'");
            GD!.OrderList!.CurrentOrderListIx = GD!.OrderList!.OTL!.Count - 1;
            foreach (OrderTable ot in GD!.OrderList!.OTL![0].OT!)
            {
                int val = 0;
                GD!.OrderList!.AddOrder(ot.OrderType, ot.OrderText, ot.OrderChoice, ot.oLG, null, null, ref val, true);
            }
            currentListe = GD!.OrderList!.CurrentOrderListIx;
            GD!.OrderList!.SyncOrderList();
            GD!.OrderList!.SaveOrderTable();

        }

        GD!.OrderList!.CurrentOrderListIx = currentListe;

        // int ix = 0;
        // int ixPreDialog = 0;

        GD!.OrderList!.ResetCurrentRun();


        GD!.ValidRun = true;
        GD!.OrderList!.ReleaseColletion();

        GD!.InterruptedDialog = false;

        GD!.OrderListFinalIx = endIndex;

        int ix = 0;
        foreach (OrderTable otParse in GD!.OrderList!.OTL![currentListe]!.OT!)
        {
            if( ix < endIndex)
                otParse.OrderPath = null;

            ix++;
        }

        currentIndex = 0;
        GD.OrderList.DisableTempOrderList();

        CalcNextTargetIndex();
        _menuExtension!.ListCalls.Add(new ListCall(OrderListPlayToDo, 10));

        GD.OrderList.OTL![GD.OrderList.CurrentOrderListIx].TempPoint = 0;
    }

    public bool OrderListPlayToDo()
    {
        // abggebrochen? Dann wech damit
        if (replayRunning == false)
            return true;

        // for(; currentIndex < nextTargetIndex; currentIndex++)
        while( currentIndex < nextTargetIndex )
        {
            OrderTable otParse = GD!.OrderList!.OTL![currentListe]!.OT![currentIndex];

            if (GD!.ValidRun == true)
            {
                if( currentIndex == 107 )
                {
                    // if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint - 1 >= endIndex)
                    //    int a = 5;
                   
                }
                GameProgressBar!.Progress = ((double)currentIndex + 1) / ((double)endIndex);
                string? s2 = otParse.OrderText; //  GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![currentIndex].OrderText;
                if (s2!.Length > 50)
                    s2 = s2!.Substring(0, 50) + "...";
                GameProgressInfo!.Text = (currentIndex + 1).ToString() + ". " + s2;
            }
            /*
            if (recursive == false)
            {
                GameProgressBar.Progress = ((double)ix + 1) / ((double)index);
                GameProgressInfo.Text = (ix + 1).ToString() + ". " + GD!.OrderList!.OTL![GD!.OrderList!.CurrentViewOrderListIx].OT![ix].OrderText;
            }
            */

            if (currentIndex + 1 == 27)
            {
                // int a = 5;
            }

            if (GD!.ValidRun == false)
            {
                GameProgressInfo!.Text = String.Format(loca.CustomRequestHandler_OrderListPlayTo_16306, currentIndex);
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = currentIndex - 1;
                OrderListPlayTo(currentIndex - 1, currentOrderIndex, true);
                GD!.ValidRun = false;
                /*
                if (recursive == false)
                {
                    GameProgressInfo.Text = String.Format(loca.CustomRequestHandler_OrderListPlayTo_16306, ix);
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = ix - 1;
                    OrderListPlayTo(ix - 1, orderListIndex, true);
                    GD!.ValidRun = false;
                }
                */
                break;
            }

            if (otParse.OrderActive == false)
            {
                if (otParse.OrderType != orderType.mcChoice)
                {
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT![currentIndex].No = currentIndex + 1;
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint++;
                }
                // ix++;
                GD!.OrderList!.AddOrderCurrentRun(otParse.OrderType, otParse.OrderText, null, loca.GD!.Language, null, null);

            }
            else if (otParse.OrderType == orderType.orderText || otParse.OrderType == orderType.noText)
            {

                string? s = otParse.OrderText;


                // if ( s.StartsWith( "öffne zerfledderten Brief" ) == true )
                // {
                // s = s;
                // }
                if (otParse.OrderActive == false)
                {
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT![currentIndex].No = currentIndex + 1;
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint++;
                    GD!.OrderList!.AddOrderCurrentRun(otParse.OrderType, otParse.OrderText, null, loca.GD!.Language, null, null);

                }
                else if (s != null)
                {

                    if (GD!.OrderList!.OTL![currentListe].OT![currentIndex]!.OrderType == orderType.mcChoice)
                    {
                        // Dieser Fall darf eigentlich gar nicht auftauchen
                    }
                    else
                    {
                        // Wir holen die nächste TempOrdertable ab, aber für die GameLoop-Aufrufe brauchen wir sie nicht
                        OrderTable ot = GD!.OrderList!.GetNextOrderTable();
                        // NOTEXTUMBAU
                        // if(otParse.orderType != orderType.noText)
                        GD!.OrderList!.AddOrderCurrentRun(otParse.OrderType, s, null, loca.GD!.Language, null, null);
                        GD!.LastCommandSucceeded = false;

                        if (currentIndex == 26)
                        {
                            // int a = 5;
                        }

                        GD!.Adventure!.DoGameLoop(s);

                        if (GD!.AskForPlayLevel)
                        {
                            GD!.Adventure!.Orders!.GenericDialog(null, GD!.Adventure!.Orders!.SetupDialog);
                            GD!.AskForPlayLevel = false;
                        }

                        if (GD!.LastCommandSucceeded == true && ot.OrderType == orderType.noText)
                            ot.OrderType = orderType.orderText;
                        if (GD!.LastCommandSucceeded == false && ot.OrderType == orderType.orderText)
                            ot.OrderType = orderType.noText;

                        // Obsolet
                        /*
                        if (Adventure!.Parser!.latestPTL != null)
                        {
                            ot.PTL = Adventure!.Parser.latestPTL;
                            ot.PTLSignatures = Adventure!.Parser!.latestPTLSignatures!;
                        }
                        */
                    }
                }

            }
            else if (otParse.OrderType == orderType.mcChoice)
            {
                if (otParse.OrderActive == false)
                {
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT![currentIndex].No = currentIndex + 1;
                    GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint++;

                }
                else
                {
                    // int a = 5;

                }
                // int a = 5;
            }
            else if (otParse.OrderType == orderType.comment)
            {
                GD!.OrderList!.DoCreateOrderPath(GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT!, GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint);
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT![currentIndex].No = currentIndex + 1;
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint++;
                GD!.OrderList!.AddOrderCurrentRun(otParse.OrderType, otParse.OrderText, null, loca.GD!.Language, null, null);
                GD!.OrderList!.OTL![0].OT![currentIndex].No = currentIndex + 1;
                GD!.OrderList!.OTL![0].TempPoint++;
            }

            if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint - 1 >= endIndex)
            {
                int ix2 = currentIndex + 1;
                OrderTable ot1 = GD!.OrderList!.GetOrderTable(ix2);
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = endIndex;

                break;
            }

            // Legacy seit 16.3.2023
            else if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint - 1 == endIndex)
            {

                int ix2 = currentIndex + 1;
                OrderTable ot1 = GD!.OrderList!.GetOrderTable(ix2);

                /* ORDERLISTDIALOG
                while (ot1 != null && ot1.OrderType == orderType.mcChoice)
                {
                    ix2++;
                    ot1 = GD!.OrderList!.GetOrderTable(ix2);
                }
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = ix2 - 1;
                */
                // ORDERLISTDIALOG
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = endIndex;

                break;
            }
            else if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].TempPoint - 1 > endIndex)
            {
                int ix2 = currentIndex + 1;
                OrderTable ot1 = GD!.OrderList!.GetOrderTable(ix2);

                /* ORDERLISTDIALOG
                while (ot1 != null && ot1.OrderType == orderType.mcChoice)
                {
                    ix2++;
                    ot1 = GD!.OrderList!.GetOrderTable(ix2);
                }
                  GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = ix2 - 1;
              */
                // ORDERLISTDIALOG
                GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = endIndex;

                break;
            }


            currentIndex++;

            if( currentIndex != GD!.OrderList!.OTL![currentListe].TempPoint  )
            {
                // int a = 5;
            }
        }
        if (currentIndex != GD!.OrderList!.OTL![currentListe].TempPoint )
        {
           //  int a = 5;
        }
        if (GD!.ValidRun == false || currentIndex >= endIndex)
        {

            if (GD!.InterruptedDialog)
            {
                GD!.SilentMode = false;
                // if (UIS.MCM == null)
                //     UIS.MCM = new();
                MCMenu x = GD!.InterruptedDialogMCM!;
                GD!.UIS!.MCM = x;
                GD!.UIS!.MCM.MCS = new Phoney_MAUI.Core.MCMenuView();
                GD!.Adventure!.Orders!.persistentMCMenu = x!;
                GD!.Adventure!.Orders!.temporaryMCMenu = null;

                GD!.UIS!.MCM.Set(GD!.InteruptedDialogID);
                GD!.UIS!.MCM.MCS.MCOutput(x, GD!.InterruptedDialogMCMSelection!, GD!.InterruptedDialogCanBeInterruped);


            }
            else if (GD!.UIS!.MCM != null)
            {
                while (GD!.UIS!.MCM!.MCS!.Visible)
                {
                    GD!.UIS!.MCM!.MCS.Close();
                }

            }
            if (GD!.OrderList!.Collector != null)
            {
                GD!.OrderList!.FlushCollection();
            }
            GD!.OrderList!.DisableTempOrderList();

            if (GD!.ValidRun)
                GD!.LastRunResult = String.Format(loca.CustomRequestHandler_OrderListPlayTo_16307, (GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point + 1));

            // if (GD!.ValidRun && !recursive)
            //     GD!.LastRunResult = String.Format(loca.CustomRequestHandler_OrderListPlayTo_16307, (GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point + 1));
            GD!.ValidRun = true;
            GD!.SilentMode = false;

            GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].RefreshCurrent();

            GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point = GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].OT!.Count;

            GD!.OrderList!.OTL![currentListe].Point = GD!.OrderList!.OTL![GD!.OrderList!.CurrentOrderListIx].Point;

            GD!.UIS.StoryTextObj!.FullRefresh = true;

#if !NEWSCROLL
            GD!.UIS.Scr.CompactToEnd();
#endif
            // UIS.StoryTextObj.RecalcLatest();
            // UIS.StoryTextObj.AdvTextRefresh();

            GD!.UIS.DoUIUpdate();
            GD!.UIS.StoryTextObj!.TextReFreshman();
            GD!.UIS.StoryTextObj!.AdvTextRefresh();
#if !NEWSCROLL
            GD!.UIS.Scr.JumpToEndInstantly();
#endif
            // DoUIUpdate();
            // UIS.Scr.CompactToEnd();
            // UpdateOrderList(OrderList);
            replayRunning = false;
            GameProgressInfo!.Text = GameProgressInfo!.Text;
            currentReplayButton!.Text = loca.MAUI_UI_CME_Ok;

            LoadCurrentOrderlist();
        }
        else
        {
            CalcNextTargetIndex();
            _menuExtension!.ListCalls.Add(new ListCall(OrderListPlayToDo, 1));

        }
        return true;
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

            val = (int)((ea! as TreeViewEventArgs)!.UserDefinedObject)!;
        else if (ea.GetType() == typeof(OrderTableEventArgs))
            val = (int)((ea! as OrderTableEventArgs)!.UserDefinedObject)!;
        else
            val = 1;

        string Text = loca.OrderFeedback_Quit_Person_Self_13991a;

        _menuExtension!.OpenShowMenu(true, pd, false, Text);


        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            SetQuitMenu(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1]!.InnerView!);
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
    public void CreateButtonXY(Grid g, string text, int xoff, int yoff, EventHandler? ev)
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
    public void DoQuit(object? o, EventArgs ea)
    {
        UIS.QuitApplication();
        // App.ThisApplication!.Quit();
        _menuExtension!.CloseContextMenu();
    }
}
