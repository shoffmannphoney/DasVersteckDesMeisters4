using Phoney_MAUI.Game;
using Phoney_MAUI.Menu;
using Phoney_MAUI.Core;
using System.Collections.ObjectModel;
using Phoney_MAUI.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Phoney_MAUI.Game.General;
using Phoney_MAUI.Platform;
using Microsoft.Maui.Controls;
using GameCore;
using System.Reflection;
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Maui.Media;
using CommunityToolkit.Maui.Behaviors;

namespace Phoney_MAUI;

public static class ViewHelpers
{
    public static Rect GetAbsoluteBounds(this Microsoft.Maui.Controls.View element)
    {
        Element looper = element;

        var absoluteX = element.X + element.Margin.Top;
        var absoluteY = element.Y + element.Margin.Left;

        // Add logic to handle titles, headers, or other non-view bars

        while (looper.Parent != null)
        {
            looper = looper.Parent;
            if (looper is Microsoft.Maui.Controls.View v)
            {
                absoluteX += v.X + v.Margin.Top;
                absoluteY += v.Y + v.Margin.Left;
            }
        }

        return new Rect(absoluteX, absoluteY, element.Width, element.Height);
    }
#if WINDOWS
    public static void ChangeCursor(this Microsoft.UI.Xaml.UIElement uiElement, Microsoft.UI.Input.InputCursor cursor)
    {
        Type type = typeof(Microsoft.UI.Xaml.UIElement);
        type.InvokeMember("ProtectedCursor",
        BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance,
        null,
        uiElement,
        new object[] { cursor });

        // Microsoft.UI.Input.InputSystemCursorShape
    }

    public static Microsoft.UI.Xaml.UIElement? GetNativeElement(this IViewHandler handler)
    {
        Type type = handler.GetType();

        var property = type.GetProperty("Microsoft.Maui.ILayoutHandler.PlatformView", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (property != null)
        {
            return (Microsoft.UI.Xaml.UIElement?)property!.GetValue(handler);
        }
        else if (type.Name == "ButtonHandler")
        {
            var property2 = type.GetProperty("Microsoft.Maui.Handlers.IButtonHandler.PlatformView", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (Microsoft.UI.Xaml.UIElement?)property2!.GetValue(handler);
        }
        else if (type.Name == "LabelHandler")
        {
            var property2 = type.GetProperty("Microsoft.Maui.Handlers.ILabelHandler.PlatformView", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (Microsoft.UI.Xaml.UIElement?)property2!.GetValue(handler);
        }
        else if (type.Name == "EntryHandler")
        {
            var property2 = type.GetProperty("Microsoft.Maui.Handlers.IEntryHandler.PlatformView", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (Microsoft.UI.Xaml.UIElement?)property2!.GetValue(handler);
        }
        /*
         else if (type.Name == "CollectionViewHandler")
         {
             var property2 = type.GetProperty("Microsoft.Maui.Controls.ReorderableItemsView", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
             return (Microsoft.UI.Xaml.UIElement?)property2.GetValue(handler);
         }
         */
        else
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (Microsoft.UI.Xaml.UIElement)properties[0]!.GetValue(handler)!;


        }
    }
#endif

    static void OnEnterCross(object? sender, Microsoft.Maui.Controls.PointerEventArgs pea)
    {
#if WINDOWS
        var nativeElement = (sender as View)!.Handler!.GetNativeElement();
        (nativeElement as Microsoft.UI.Xaml.UIElement)!.ChangeCursor(Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.Cross));
#endif
    }
    static void OnEnterHand(object? sender, Microsoft.Maui.Controls.PointerEventArgs pea)
    {
#if WINDOWS
        var nativeElement = (sender as View)!.Handler!.GetNativeElement();
        (nativeElement as Microsoft.UI.Xaml.UIElement)!.ChangeCursor(Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.Hand));
#endif
    }
    static void OnEnterHelp(object? sender, Microsoft.Maui.Controls.PointerEventArgs pea)
    {
#if WINDOWS
        var nativeElement = (sender as View)!.Handler!.GetNativeElement();
        (nativeElement as Microsoft.UI.Xaml.UIElement)!.ChangeCursor(Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.Help));
#endif
    }
    static void OnExit(object? sender, Microsoft.Maui.Controls.PointerEventArgs pea)
    {
#if WINDOWS
        var nativeElement = (sender as View)!.Handler!.GetNativeElement();
        (nativeElement as Microsoft.UI.Xaml.UIElement)!.ChangeCursor(Microsoft.UI.Input.InputSystemCursor.Create(Microsoft.UI.Input.InputSystemCursorShape.Arrow));
#endif
    }
    public static void SetCursorHand(this View v)
    {
#if WINDOWS
        PointerGestureRecognizer pgr = new();
        pgr.PointerEntered += OnEnterHand;
        pgr.PointerExited += OnExit;
        v.GestureRecognizers.Add(pgr);
#endif
    }
    public static void SetCursorCross(this View v)
    {
#if WINDOWS
        PointerGestureRecognizer pgr = new();
        pgr.PointerEntered += OnEnterCross;
        pgr.PointerExited += OnExit;
        v.GestureRecognizers.Add(pgr);
#endif
    }
    public static void SetCursorHelp(this View v)
    {
#if WINDOWS
        PointerGestureRecognizer pgr = new();
        pgr.PointerEntered += OnEnterHelp;
        pgr.PointerExited += OnExit;
        v.GestureRecognizers.Add(pgr);
#endif
    }

}

public struct noprapere_tag { };

public static class ScreenCoords
{
    /// <summary>
    /// A view's default X- and Y-coordinates are LOCAL with respect to the boundaries of its parent,
    /// and NOT with respect to the screen. This method calculates the SCREEN coordinates of a view.
    /// The coordinates returned refer to the top left corner of the view.
    /// </summary>
    public static Point GetScreenCoords(this VisualElement? view)
    {
        var result = new Point(view!.X, view!.Y);

        double Height = view.Height;

        while (view.Parent is VisualElement parent)
        {
            if (view.GetType() == typeof(ScrollView))
            {
                ScrollView? sv = view as ScrollView;
                result.X -= sv!.ScrollX;
                result.Y -= sv!.ScrollY;
            }
            result = result.Offset(parent.X, parent.Y);
            view = parent;
        }

        return result;
    }
}

public class Position
{
    public double XPos;
    public double YPos;
}

public class IDLabel: Label
{
    public int ID;
}

public class IDButton : Button
{
    public int ID;
}

public class ObjButton : Button
{
    public object? Object;
}

public class PIMenuFlyoutItem : MenuFlyoutItem
{
   
    public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(PIMenuFlyoutItem), null);
    public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create("BackgroundColor", typeof(Color), typeof(PIMenuFlyoutItem), null); 
    public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create("FontFamily", typeof(string), typeof(PIMenuFlyoutItem), null); 


    public Color TextColor
    {
        get { return (Color)GetValue(TextColorProperty); }
        set { SetValue(TextColorProperty, value); }
    }
    public Color BackgroundColor
    {
        get { return (Color)GetValue(BackgroundColorProperty); }
        set { SetValue(BackgroundColorProperty, value); }
    }
    public string FontFamily
    {
        get { return (string)GetValue(FontFamilyProperty); }
        set { SetValue(FontFamilyProperty, value); }
    }
}


public static class UIElement
{
    public static List<Grid> listGrid= new();
    public static List<TreeViewItem> listTreeViewItem= new ();
    public static List<TreeView> listTreeView = new ();
    public static List<IDButton> listIDButton = new();
    public static List<IDLabel> listIDLabel = new();
    public static List<Button> listButton = new();
    public static List<Label> listLabel = new();


    public static void StoreGrid(Grid g)
    {
        if (listGrid.Count > 1000)
        {
        }

        g.ClearValue(Grid.BackgroundColorProperty);
        g.ClearValue(Grid.BackgroundProperty);
        // g.ClearValue(Grid.BehaviorsProperty);
        g.ClearValue(Grid.BindingContextProperty);
        g.ClearValue(Grid.ColumnDefinitionsProperty);
        // g.ClearValue(Grid.HeightProperty);
        g.ClearValue(Grid.HeightRequestProperty);
        g.ClearValue(Grid.IsVisibleProperty);
        // g.ClearValue(Grid.IsFocusedProperty);
        g.ClearValue(Grid.MarginProperty);
        g.ClearValue(Grid.OpacityProperty);
        g.ClearValue(Grid.PaddingProperty);
        g.ClearValue(Grid.RowDefinitionsProperty);
        g.ClearValue(Grid.StyleProperty);
        // g.ClearValue(Grid.WidthProperty);
        g.ClearValue(Grid.WidthRequestProperty);

        listGrid.Add(g);
    }
    public static void StoreTreeViewItem(TreeViewItem tvi )
    {
        if( tvi == null )
        {

        }

        tvi.ClearValue(TreeViewItem.BackgroundColorProperty);
        tvi.ClearValue(TreeViewItem.BackgroundProperty);
        // g.ClearValue(Grid.BehaviorsProperty);
        tvi.ClearValue(TreeViewItem.BindingContextProperty);
        tvi.ClearValue(TreeViewItem.ColumnDefinitionsProperty);
        // g.ClearValue(Grid.HeightProperty);
        tvi.ClearValue(TreeViewItem.HeightRequestProperty);
        tvi.ClearValue(TreeViewItem.IsVisibleProperty);
        // g.ClearValue(Grid.IsFocusedProperty);
        tvi.ClearValue(TreeViewItem.MarginProperty);
        tvi.ClearValue(TreeViewItem.OpacityProperty);
        tvi.ClearValue(TreeViewItem.PaddingProperty);
        tvi.ClearValue(TreeViewItem.RowDefinitionsProperty);
        tvi.ClearValue(TreeViewItem.StyleProperty);
        // g.ClearValue(Grid.WidthProperty);
        tvi.ClearValue(TreeViewItem.WidthRequestProperty);

        listTreeViewItem.Add(tvi);
    }
    public static void StoreTreeView(TreeView tv)
    {
        tv.ClearValue(TreeView.BackgroundColorProperty);
        tv.ClearValue(TreeView.BackgroundProperty);
        // g.ClearValue(Grid.BehaviorsProperty);
        tv.ClearValue(TreeView.BindingContextProperty);
        tv.ClearValue(TreeView.ColumnDefinitionsProperty);
        // g.ClearValue(Grid.HeightProperty);
        tv.ClearValue(TreeView.HeightRequestProperty);
        tv.ClearValue(TreeView.IsVisibleProperty);
        // g.ClearValue(Grid.IsFocusedProperty);
        tv.ClearValue(TreeView.MarginProperty);
        tv.ClearValue(TreeView.OpacityProperty);
        tv.ClearValue(TreeView.PaddingProperty);
        tv.ClearValue(TreeView.RowDefinitionsProperty);
        tv.ClearValue(TreeView.StyleProperty);
        // g.ClearValue(Grid.WidthProperty);
        tv.ClearValue(TreeView.WidthRequestProperty);
        listTreeView.Add(tv);
    }
    public static void StoreIDButton(IDButton b)
    {
        b.ClearValue(IDButton.BackgroundColorProperty);
        b.ClearValue(IDButton.BackgroundProperty);
        // g.ClearValue(Grid.BehaviorsProperty);
        b.ClearValue(IDButton.BindingContextProperty);
        // g.ClearValue(Grid.HeightProperty);
        b.ClearValue(IDButton.HeightRequestProperty);
        b.ClearValue(IDButton.IsVisibleProperty);
        // g.ClearValue(Grid.IsFocusedProperty);
        b.ClearValue(IDButton.MarginProperty);
        b.ClearValue(IDButton.OpacityProperty);
        b.ClearValue(IDButton.PaddingProperty);
        b.ClearValue(IDButton.StyleProperty);
        // g.ClearValue(Grid.WidthProperty);
        b.ClearValue(IDButton.WidthRequestProperty);
        b.ClearValue(IDButton.TextColorProperty);

        listIDButton.Add(b);
    }
    public static void StoreIDLabel(IDLabel l)
    {
        l.ClearValue(IDLabel.BackgroundColorProperty);
        l.ClearValue(IDLabel.BackgroundProperty);
        // g.ClearValue(Grid.BehaviorsProperty);
        l.ClearValue(IDLabel.BindingContextProperty);
        // g.ClearValue(Grid.HeightProperty);
        l.ClearValue(IDLabel.HeightRequestProperty);
        l.ClearValue(IDLabel.IsVisibleProperty);
        // g.ClearValue(Grid.IsFocusedProperty);
        l.ClearValue(IDLabel.MarginProperty);
        l.ClearValue(IDLabel.OpacityProperty);
        l.ClearValue(IDLabel.PaddingProperty);
        l.ClearValue(IDLabel.StyleProperty);
        // g.ClearValue(Grid.WidthProperty);
        l.ClearValue(IDLabel.WidthRequestProperty);
        l.ClearValue(IDLabel.TextColorProperty);

        listIDLabel.Add(l);
    }
    public static void StoreButton(Button b)
    {
        b.ClearValue(Button.BackgroundColorProperty);
        b.ClearValue(Button.BackgroundProperty);
        // g.ClearValue(Grid.BehaviorsProperty);
        b.ClearValue(Button.BindingContextProperty);
        // g.ClearValue(Grid.HeightProperty);
        b.ClearValue(Button.HeightRequestProperty);
        b.ClearValue(Button.IsVisibleProperty);
        // g.ClearValue(Grid.IsFocusedProperty);
        b.ClearValue(Button.MarginProperty);
        b.ClearValue(Button.OpacityProperty);
        b.ClearValue(Button.PaddingProperty);
        b.ClearValue(Button.StyleProperty);
        // g.ClearValue(Grid.WidthProperty);
        b.ClearValue(Button.WidthRequestProperty);
        b.ClearValue(Button.TextColorProperty);

        listButton.Add(b);
    }
    public static void StoreLabel(Label l)
    {
        l.ClearValue(Label.BackgroundColorProperty);
        l.ClearValue(Label.BackgroundProperty);
        // g.ClearValue(Grid.BehaviorsProperty);
        l.ClearValue(Label.BindingContextProperty);
        // g.ClearValue(Grid.HeightProperty);
        l.ClearValue(Label.HeightRequestProperty);
        l.ClearValue(Label.IsVisibleProperty);
        // g.ClearValue(Grid.IsFocusedProperty);
        l.ClearValue(Label.MarginProperty);
        l.ClearValue(Label.OpacityProperty);
        l.ClearValue(Label.PaddingProperty);
        l.ClearValue(Label.StyleProperty);
        // g.ClearValue(Grid.WidthProperty);
        l.ClearValue(Label.WidthRequestProperty);
        l.ClearValue(Label.TextColorProperty);


        listLabel.Add(l);
    }
    public static Grid NewGrid()
    {
        if (listGrid.Count  > 1000)
        {
        }

        if ( listGrid.Count > 0)
        {
            Grid g2 = listGrid[0];
            listGrid.RemoveAt(0);
            g2.IsVisible = true;
            g2.WidthRequest = -1;
            return g2;
        }
        Grid g = new();
        return g;
    }
    public static TreeView NewTreeView()
    {
        if( listTreeView.Count > 0)
        {
            TreeView tv2 = listTreeView[0];
            listTreeView.RemoveAt(0);
            tv2.IsVisible = true;
            return tv2;
        }
        TreeView tv = new();
        return tv;
    }
    public static TreeViewItem NewTreeViewItem()
    {
        if( listTreeViewItem.Count > 0)
        {
            TreeViewItem tvi2 = listTreeViewItem[0];
            listTreeViewItem.RemoveAt(0);
            tvi2.IsVisible = true;
            return tvi2;
        }
        TreeViewItem tvi = new();
        return tvi;
    }
    public static IDButton NewIDButton()
    {
        if( listIDButton.Count > 0)
        {
            IDButton b2 = listIDButton[0];
            if (b2 == null)
            {

            }
            listIDButton.RemoveAt(0);
            b2.IsVisible = true;
            b2.Opacity = 1;

            return b2;
        }
        IDButton b = new();
        return b;
    }
    public static Button NewButton()
    {
        if (listButton.Count > 0)
        {
            Button b2 = listButton[0];
            if (b2 == null)
            {

            }
            listButton.RemoveAt(0);
            b2.IsVisible = true;
            b2.Opacity = 1;
            b2.BackgroundColor = Colors.Transparent;

            // (b2.Background as Microsoft.Maui.Controls.ImmutableBrush).Color = null;
            b2.TextColor = Colors.White;
            b2.StyleClass = null;
            return b2;
        }
        Button b = new();
        return b;
    }
    public static IDLabel NewIDLabel()
    {
        if( listIDLabel.Count > 0)
        {
            IDLabel l2 = listIDLabel[0];
            listIDLabel.RemoveAt(0);
            l2.IsVisible = true;
            l2.Opacity = 1;
            return l2;
        }
        IDLabel l = new();
        return l;
    }
    public static Label NewLabel()
    {
        if (listLabel.Count > 0)
        {
            Label l2 = listLabel[0];
            listLabel.RemoveAt(0);
            l2.IsVisible = true;
            l2.Opacity = 1;
            return l2;
        }
        Label l = new();
        return l;
    }

    private static List<string> Button_NoBackground_NoBorder = null;
    private static List<string> Label_Normal = null;
    private static List<string> Label_Normal_Inactive = null;

    public static List<string> Get_Button_NoBackground_NoBorder()
    {
        if (Button_NoBackground_NoBorder == null)
        {
            List<string> s1 = new();
            s1.Add("Button_NoBackground_NoBorder");
            Button_NoBackground_NoBorder = s1; 
        }
        return Button_NoBackground_NoBorder;
    }
    public static List<string> Get_Label_Normal()
    {
        if (Label_Normal == null)
        {
            List<string> s1 = new();
            s1.Add("Label_Normal");
            Label_Normal = s1;
        }
        return Label_Normal;
    }
    public static List<string> Get_Label_Normal_Inactive()
    {
        if (Label_Normal_Inactive == null)
        {
            List<string> s1 = new();
            s1.Add("Label_Normal_Inactive");
            Label_Normal_Inactive = s1;
        }
        return Label_Normal_Inactive;
    }
}
public class TreeView : TreeViewItem
{
    public OrderTableCallback? OTCallback { get; set; }
    public int OTNo { get; set; }
    public TreeCallback? OTClick { get; set; }
    public OrderTableCallback? OrderTableCallback { get; set; }

    public TreeView() : base()
    {
    }

    static int destroyed = 0;

    public void ResetTreeViewItem()
    {
        OTCallback = null;
        OTClick = null;
        OrderTableCallback = null;

        base.ResetTreeViewItem();
    }


    public static void EmptyTreeViewItem(  Microsoft.Maui.IView tv)
    {
        // return;

#if ANDROID
        int grefCount = (int) Java.Lang.Runtime.GetRuntime()!.TotalMemory();
#endif
        try
        {
            if (tv is TreeViewItem || tv is Grid || tv is TreeView )
            {
                Grid? tv2 = tv as Grid;

                foreach (IView iv in tv2!.Children)
                {
                    if (iv is TreeViewItem)
                    {
                        IView? tvi = iv as IView;
                        (iv as TreeViewItem)!.DisableToggleButton();

                        EmptyTreeViewItem(tvi);

                        (iv as TreeViewItem)!.Children.Clear();
                        (iv as TreeViewItem)!.Parent = null;
                        (iv as TreeViewItem)!.Handler = null;

                        if ((iv as TreeViewItem)!.StyleClass != null)
                            (iv as TreeViewItem)!.StyleClass.Clear();

                        (iv as TreeViewItem).Clear();
                    }
                    else if (iv is Grid)
                    {
                        Grid tvi = iv as Grid;

                        EmptyTreeViewItem(tvi);

                        tvi.Children.Clear();
                        tvi.Parent = null;
                        tvi.Handler = null;

                        if ((iv as Grid).StyleClass != null)
                            (iv as Grid)!.StyleClass.Clear();

                        (iv as Grid).Clear();
                    }
                    else if ( iv is Label )
                    {
                        Label l1 = (Label)iv;

                        while( l1.Behaviors.Count > 0 )
                        {
                            l1.Behaviors.RemoveAt(0);
                            destroyed++;

                        }
                        l1.Behaviors.Clear();

                        while (l1.GestureRecognizers.Count > 0)
                        {
                            if (l1.GestureRecognizers[0] is TapGestureRecognizer)
                            {
                                (l1.GestureRecognizers[0] as TapGestureRecognizer).Command = null;
                            }
                            else if (l1.GestureRecognizers[0] is PointerGestureRecognizer)
                            {
                                /*
                                foreach (var handler in (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerEntered)
                                {
                                }
                                */
                                // (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerEntered.Clear();
                                // (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerExited.Clear();
                            }
                            else
                                destroyed += 0;
                            l1.GestureRecognizers.RemoveAt(0);
                            destroyed++;

                        }
                        l1.Text = null;
                        l1.GestureRecognizers.Clear();
                        l1.Parent = null;
                        if (l1.StyleClass != null)
                            l1.StyleClass.Clear();

                        // l1.Clear();

                        UIElement.StoreLabel(l1 as Label);
                    }
                    else if (iv is Button )
                    {
                        Button l1 = (Button)iv;

                        while (l1.Behaviors.Count > 0)
                        {
                            l1.Behaviors.RemoveAt(0);
                            destroyed++;

                        }
                        l1.Behaviors.Clear();
                        while (l1.GestureRecognizers.Count > 0)
                        {
                            if (l1.GestureRecognizers[0] is TapGestureRecognizer)
                            {
                                (l1.GestureRecognizers[0] as TapGestureRecognizer).Command = null;
                            }
                            else if (l1.GestureRecognizers[0] is PointerGestureRecognizer)
                            {
                                /*
                                foreach (var handler in (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerEntered)
                                {
                                }
                                */
                                // (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerEntered.Clear();
                                // (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerExited.Clear();
                            }
                            else
                                destroyed += 0;

                            l1.GestureRecognizers.RemoveAt(0);
                            destroyed++;

                        }
                        l1.GestureRecognizers.Clear();
                        l1.Text = null;
                        l1.Parent = null;
                        if (l1.StyleClass != null)
                            l1.StyleClass.Clear();

                        // l1.Clear();
                        UIElement.StoreButton(l1 as Button);
                    }
                    else
                    {
                        GlobalData.AddLog("Nicht ausgewertet: " + iv.GetType().ToString(), IGlobalData.protMode.crisp);

                    }
                }
                tv2.Children.Clear();
                while (tv2.Behaviors.Count > 0)
                {
                    GlobalData.AddLog("Ausgewertet: " + tv2.GetType().ToString(), IGlobalData.protMode.crisp);
                    tv2.Behaviors.RemoveAt(0);
                    destroyed++;

                }
                tv2.Behaviors.Clear();
                while (tv2.GestureRecognizers.Count > 0)
                {
                    if (tv2.GestureRecognizers[0] is TapGestureRecognizer)
                    {
                        (tv2.GestureRecognizers[0] as TapGestureRecognizer).Command = null;
                    }
                    else if (tv2.GestureRecognizers[0] is PointerGestureRecognizer)
                    {
                        /*
                        foreach (var handler in (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerEntered)
                        {
                        }
                        */
                        // (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerEntered.Clear();
                        // (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerExited.Clear();
                    }
                    else
                        destroyed += 0;

                    tv2.GestureRecognizers.RemoveAt(0);
                    destroyed++;

                }
                tv2.GestureRecognizers.Clear();
                if (tv2.StyleClass != null)
                    tv2.StyleClass.Clear();

                if (tv is TreeView)
                {
                    TreeView? tv3 = tv as TreeView;
                    try
                    {
                        tv3.DisableToggleButton();
                        tv3.OrderListTable = null;
                        tv3.OrderTable = null;
                        tv3.CurrentOrderListTable = null;
                        tv3.UserDefinedObject = null;
                        tv3.Text = null;
                        tv3.Parent = null;
                        tv3.ResetTreeViewItem();
                        tv3.ColumnDefinitions.Clear();
                        tv3.RowDefinitions.Clear();
                        tv3.ClickedEventCommand = null;
                        tv3.TextButton = null;
                        tv3.TextLabel = null;
                        tv3.Handler = null;
                        if (tv3.StyleClass != null)
                            tv3.StyleClass.Clear();


                        tv3.OTCallback = null;
                        tv3.OTClick = null;
                        tv3.OrderTableCallback = null;

                        tv3.Clear();
                        UIElement.StoreTreeView(tv3);
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message;
                        GlobalData.AddLog("EmptyTreeViewItem: " + s, IGlobalData.protMode.crisp);
                    }
                }
                else if (tv is TreeViewItem)
                {
                    TreeViewItem tv3 = tv as TreeViewItem;
                    try
                    {
                        tv3.DisableToggleButton();
                        tv3.OrderListTable = null;
                        tv3.OrderTable = null;
                        tv3.CurrentOrderListTable = null;
                        tv3.UserDefinedObject = null;
                        tv3.Text = null;
                        tv3.Parent = null;
                        tv3.ResetTreeViewItem();
                        tv3.ColumnDefinitions.Clear();
                        tv3.RowDefinitions.Clear();
                        tv3.TextButton = null;
                        tv3.TextLabel = null;
                        tv3.Handler = null;
                        if (tv3.StyleClass != null)
                            tv3.StyleClass.Clear();

                        tv3.Clear();
                        UIElement.StoreTreeViewItem(tv3);
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message;
                        GlobalData.AddLog("EmptyTreeViewItem: " + s, IGlobalData.protMode.crisp);
                    }
                }
                else if (tv is Grid)
                {
                    Grid g3 = tv as Grid;
                    g3.ColumnDefinitions.Clear();
                    g3.RowDefinitions.Clear();
                    g3.Parent = null;
                    g3.Handler = null;
                    if (g3.StyleClass != null)
                        g3.StyleClass.Clear();

                    g3.Clear();
                    UIElement.StoreGrid(g3);
                }
                else
                {
                    GlobalData.AddLog("Nicht ausgewertet: " + tv.GetType().ToString(), IGlobalData.protMode.crisp);

                }


            }
            else if (tv is Label)
            {
                Label l1 = (Label)tv;

                while (l1.Behaviors.Count > 0)
                {
                    l1.Behaviors.RemoveAt(0);

                    destroyed++;
                }
                l1.Behaviors.Clear();

                while (l1.GestureRecognizers.Count > 0)
                {
                    if (l1.GestureRecognizers[0] is TapGestureRecognizer)
                    {
                        (l1.GestureRecognizers[0] as TapGestureRecognizer).Command = null;
                    }
                    else if (l1.GestureRecognizers[0] is PointerGestureRecognizer)
                    {
                        /*
                        foreach (var handler in (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerEntered)
                        {
                        }
                        */
                        // (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerEntered.Clear();
                        // (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerExited.Clear();
                    }
                    else
                        destroyed += 0;

                    l1.GestureRecognizers.RemoveAt(0);
                    destroyed++;

                }
                if( l1.StyleClass != null)
                    l1.StyleClass.Clear();
                l1.GestureRecognizers.Clear();
                l1.Parent = null;
                l1.Text = null;
                // l1.Clear();
            }
            else
            {
                GlobalData.AddLog( "Nicht ausgewertet: " + tv.GetType().ToString(), IGlobalData.protMode.crisp);
            }
         }
        catch (Exception ex)
        {
            string s = ex.Message;
            GlobalData.AddLog("EmptyTreeViewItem: " + s, IGlobalData.protMode.crisp);


        }

#if ANDROID
        grefCount -= (int)  Java.Lang.Runtime.GetRuntime().TotalMemory();

        if( grefCount > 0 )
            GlobalData.AddLog("EmptyTreeViewItem freed: " + grefCount.ToString() + " von " + grefCount.ToString(), IGlobalData.protMode.crisp);
#endif
    }
    public void CloseTreeViewItem(TreeViewItem tvi)
    {
        if (tvi.SubTree != null)
        {
            if (tvi.SubTree!.Children.Count > 0)
            {
                foreach (object  ovi2 in tvi.SubTree!.Children )
                {
                    if (ovi2.GetType() == typeof(TreeViewItem))
                    {

                        TreeViewItem? tvi2 = ovi2 as TreeViewItem;
                        CloseTreeViewItem(tvi2!);
                    }
                }
            }
        }
        tvi.CurrentTreeState = TreeState.closed;
    }

    public void CloseAllOpenEntry( int no )
    {
        OrderTable? otRetour = null;
        int highestNo = 0;

        foreach ( object ovi in SubTree!.Children )
        {
            TreeViewItem? tvi = ovi as TreeViewItem;
            if( tvi!.SubTree != null )
            {
                if ( tvi.SubTree!.Children.Count > 0 )
                {
                    CloseTreeViewItem(tvi);
                }
            }

            tvi.CurrentTreeState = TreeState.closed;

        }

        // Wenn keine No angegeben wurde, dann suchen wir den höchsten Eintrag
        if( no == -1 )
        {

            foreach (object ovi in SubTree!.Children)
            {
                TreeViewItem? tvi = ovi as TreeViewItem;
                if (tvi!.OrderListTable != null)
                {
                   SearchHighestOrderTableTree(tvi.OrderListTable, ref highestNo, ref otRetour!);
                }
            }

            no = highestNo;
        }
        else
        {
            foreach (object ovi in SubTree!.Children)
            {
                TreeViewItem? tvi = ovi as TreeViewItem;
                if (tvi!.OrderListTable != null)
                {
                    SearchNoOrderTableTree(tvi.OrderListTable, no, ref otRetour!);
                }
            }


        }

        if ( no > 0 && otRetour != null )
        {
            OpenOrderTableTree(otRetour);
        }
       
    }

    public void CenterTable( ScrollView sv, View v)
    {
        double Height = 0;

        TreeView? tv0 = (GetRootTree(this.ParentSubTree!) as TreeView)!;
        // bool cont = true;

        Point p = ScreenCoords.GetScreenCoords(v);
        // Height = CalcHeight(tv0, ref cont, no);
        // Height -= sv.Height / 2;

        Height = p.Y;
        if (Height < 0)
            Height = 0;
        sv.ScrollToAsync( 0, Height, false );
        
        /*
        foreach( object o in tv0.Children)
        {
            if (o.GetType() == typeof(Grid))
            {
                Grid g1= o as Grid;
                Height += CalcHeight(g1);
            }
            else if ( o.GetType() == typeof( TreeViewItem ))
            {
                TreeViewItem tvi0 = o as TreeViewItem;
                Height += tvi0.Height;
            }
        }
        */
    }

    double CalcHeight(Grid? g1, ref bool doCont, int breakNo = -1)
    {
        double Height = 0;

        if( g1!.Children != null)
        {
            foreach( object o in g1!.Children)
            {
                if (o!.GetType() == typeof(Grid))
                {
                    Grid? g2 = o as Grid;
                    Height += CalcHeight(g2!, ref doCont, breakNo);
                    // if (g2!.Margin != null)
                    {
                        Height += g2!.Margin.Top + g2!.Margin.Bottom;
                    }
                }
                else if (o!.GetType() == typeof(Button))
                {
                    Button? b2 = o as Button;
                    if (b2!.Height > 0 && b2!.Text.Length > 1)
                    {                     
                        Height += b2!.Height;
                        // if( b2!.Margin != null )
                        {
                            Height += b2!.Margin.Top + b2!.Margin.Bottom;
                        }
                    }
                }
                else if (o!.GetType() == typeof(TreeViewItem))
                {
                    TreeViewItem? t3 = o as TreeViewItem;
                    Height += CalcHeight(t3!, ref doCont, breakNo);
                }
                else if (o!.GetType() == typeof(OrderListView))
                {
                    OrderListView? olv = o as OrderListView;
                    if (olv!.Height > 0)
                    {
                        Height += olv!.Height;
                        // if (olv!.Margin != null)
                        {
                            Height += olv!.Margin.Top + olv!.Margin.Bottom;
                        }
                    }

                    if ( breakNo != -1 && breakNo == olv!.StepNo)
                    {
                        doCont = false;

                    }
                }
                else
                {
                    Height += 1;
                }

                if( doCont == false)
                {
                    break;
                }
            }
        }
        return Height;
    }
    public Position CalcPos(Grid? g1, ref bool doCont, int breakNo = -1)
    {
        Button? b1 = new();
        Point p2 = DeviceData._deviceData!.GetAbsolutePosition( b1!);

        Position Pos = new();
        Pos.XPos = 0;
        Pos.YPos = 0;

        if (g1!.Children != null)
        {
            foreach (object o in g1.Children)
            {
                if (o.GetType() == typeof(Grid))
                {
                    Grid? g2 = o as Grid;
                    Position p = CalcPos(g2!, ref doCont, breakNo);
                    Pos.XPos += p.XPos;
                    Pos.YPos += p.YPos;

                    // if (g2.Margin != null)
                    {
                        Pos.XPos += g2!.Margin.Left + g2!.Margin.Right;
                        Pos.YPos += g2!.Margin.Top + g2!.Margin.Bottom;
                    }
                }
                else if (o.GetType() == typeof(Button) || o.GetType() == typeof(IDButton))
                {
                    Button? b2 = o as Button;
                    if (b2!.Height > 0 && b2!.Text.Length > 1)
                    {
                        Pos.XPos += b2!.Width;
                        Pos.YPos += b2!.Height;
                        // if (b2!.Margin != null)
                        {
                            Pos.XPos += b2!.Margin.Left + b2!.Margin.Right;
                            Pos.YPos += b2!.Margin.Top + b2!.Margin.Bottom;
                        }
                    }
                }
                else if (o.GetType() == typeof(Label))
                {
                    Label? l2 = o as Label;
                    if (l2!.Height > 0 && l2!.Text.Length > 1)
                    {
                        Pos.XPos += l2!.Width;
                        Pos.YPos += l2!.Height;
                        // if (l2!.Margin != null)
                        {
                            Pos.XPos += l2!.Margin.Left + l2!.Margin.Right;
                            Pos.YPos += l2!.Margin.Top + l2!.Margin.Bottom;
                        }
                    }
                }
                else if (o.GetType() == typeof(Entry))
                {
                }
                else if (o.GetType() == typeof(Switch))
                {
                }
                else if (o.GetType() == typeof(ScrollView))
                {
                    ScrollView? sv = o as ScrollView;
                    Pos.XPos -= sv!.ScrollX;
                    Pos.YPos -= sv!.ScrollY;

                    Position p = CalcPos(sv!.Content as Grid, ref doCont, breakNo);
                    Pos.XPos += p.XPos;
                    Pos.YPos += p.YPos;
                }
                else if (o.GetType() == typeof(TreeViewItem))
                {
                    TreeViewItem? t3 = o as TreeViewItem;

                    Position p = CalcPos(t3!, ref doCont, breakNo);
                    Pos.XPos += p.XPos;
                    Pos.YPos += p.YPos;
                }
                else if (o.GetType() == typeof(TreeView))
                {
                    TreeView? t3 = o as TreeView;

                    Position p = CalcPos(t3!, ref doCont, breakNo);
                    Pos.XPos += p.XPos;
                    Pos.YPos += p.YPos;
                }
                else if (o.GetType() == typeof(OrderListView))
                {
                    OrderListView? olv = o as OrderListView;
                    if (olv!.Height > 0)
                    {
                        Pos.XPos += olv!.Width;
                        Pos.YPos += olv!.Height;
                        // if (olv!.Margin != null)
                        {
                            Pos.XPos += olv!.Margin.Left + olv!.Margin.Right;
                            Pos.YPos += olv!.Margin.Top + olv!.Margin.Bottom;
                        }
                    }

                    if (breakNo != -1 && breakNo == olv.StepNo)
                    {
                        doCont = false;

                    }
                }
                else
                {
                    Pos.XPos += 1;
                    Pos.YPos += 1;
                }

                if (doCont == false)
                {
                    break;
                }
            }
        }
        return Pos;
    }

    public bool FoundOrderTableTree( ObservableCollection<OrderListTable>? ott, OrderTable otRetour )
    {
        bool found = false;

        int ix;
        for (ix = 0; ix < ott!.Count; ix++)
        {
            if (ott[ix].OLT != null )
            {
                found = FoundOrderTableTree(ott[ix].OLT!, otRetour);
                if (found == true)
                    break;
            }
            if (ott[ix].OT != null)
            {
                for (int ix2 = 0; ix2 < ott[ix].OT!.Count; ix2++)
                {
                    if (ott[ix].OT![ix2].No == otRetour.No)
                        found = true;
                }
            }
        }
        return found;
    }
    public void OpenTreeViewItemOrderTableTree(TreeViewItem tvi, OrderTable otRetour)
    {
        bool found = false;
        if (tvi.OrderListTable != null)
        {
            if (FoundOrderTableTree(tvi.OrderListTable, otRetour) == true)
                found = true;
        }
        if (tvi.OrderTable != null)
        {
            for (int ix = 0; ix < tvi.OrderTable.Count; ix++)
            {
                if (tvi.OrderTable[ix].No == otRetour.No)
                    found = true;
            }
        }
        if( found )
        {
            tvi.CurrentTreeState = TreeState.open;

            if( tvi.SubTree!.Children != null )
            {
                foreach( object ovi in tvi.SubTree!.Children )
                {
                    if( ovi.GetType() == typeof( TreeViewItem))
                    {
                        TreeViewItem? tvi2 = ovi as TreeViewItem;

                        OpenTreeViewItemOrderTableTree(tvi2!, otRetour);
                    }
                }
            }
        }
    }
    public void OpenOrderTableTree( OrderTable otRetour )
    {
        foreach( object ovi in this.SubTree!.Children)
        {
            if (ovi.GetType() == typeof(TreeViewItem))
            {
                TreeViewItem? tvi2 = ovi as TreeViewItem;

                OpenTreeViewItemOrderTableTree(tvi2!, otRetour);
            }

        }
    }
    public void SearchHighestOrderTableTree( ObservableCollection<OrderListTable> ott, ref int highestNo, ref OrderTable otRetour )
    {
        foreach (OrderListTable ott2 in ott )
        {
            if (ott2.OLT != null)
            {
                SearchHighestOrderTableTree(ott2.OLT, ref highestNo, ref otRetour);
            }
            if (ott2.OT != null)
            {
                for (int ix = 0; ix < ott2.OT.Count; ix++)
                {
                    if (ott2.OT![ix].No > highestNo)
                    {
                        highestNo = ott2.OT![ix].No;
                        otRetour = ott2.OT![ix];
                    }
                }
            }
            /*
             TreeViewItem tvi2 = ovi as TreeViewItem;
             if (tvi2.SubTree != null)
             {
                 if (tvi2.SubTree!.Children.Count > 0)
                 {
                     SearchHighestTreeViewItem(tvi2, ref highestNo, ref otRetour);
                 }
             }
             if( tvi.OrderTableTrees != null )
             {
                 foreach( OrderTableTree ott in tvi.OrderTableTrees )
                 {
                     for( int ix = 0; ix < ott.OrderTables.Count; ix++)
                     {
                         if (ott.OrderTables[ix].No > highestNo )
                         {
                             highestNo = ott.OrderTables[ix].No;
                             otRetour = ott.OrderTables[ix];
                         }

                     }
                 }
             }
             */
        }

    }
    public void SearchNoOrderTableTree(ObservableCollection<OrderListTable> ott, int No, ref OrderTable otRetour)
    {
        foreach (OrderListTable ott2 in ott)
        {
            if (ott2.OLT != null)
            {
                SearchNoOrderTableTree(ott2.OLT, No, ref otRetour);
            }
            if (ott2.OT!= null)
            {
                for (int ix = 0; ix < ott2.OT.Count; ix++)
                {
                    if (ott2.OT![ix].No == No)
                    {
                        otRetour = ott2.OT![ix];
                    }
                }
            }
        }

    }

    /*
    public void DisableToggleButton()
    {
        ToggleButton.Clicked -= ToggleTreeView;

    }
    */
    public void SetupTreeView() 
    {
        try
        {
            RowDefinitionCollection Rows = new();
            RowDefinition rd1 = new();
            // rd1.Height = new GridLength(TreeHeight, GridUnitType.Absolute);
            rd1.Height = GridLength.Auto;
            Rows.Add(rd1);
            RowDefinition rd2 = new();
            // rd2.Height = new GridLength(200, GridUnitType.Absolute);
            rd2.Height = GridLength.Auto;
            Rows.Add(rd2);
            this.RowDefinitions = Rows;

            Grid g1 = UIElement.NewGrid();
            this.Add(g1);
            this.SetRow(g1, 0);
            g1.IsVisible = false;

            Grid g2 = UIElement.NewGrid();
            this.Add(g2);
            this.SetRow(g2, 1);

            ColumnDefinitionCollection Columns = new();

            ColumnDefinition cd1 = new();
            cd1.Width = new GridLength(0, GridUnitType.Absolute);
            Columns.Add(cd1);
            ColumnDefinition cd2 = new();
            cd2.Width = GridLength.Auto;
            Columns.Add(cd2);
            g1.ColumnDefinitions = Columns;
            g1.VerticalOptions = LayoutOptions.Start;

            Grid g3 = UIElement.NewGrid();
            g3.WidthRequest = 20;
            g1.Add(g3);
            g1.SetColumn(g3, 0);

            Grid g4 = UIElement.NewGrid();
            g1.Add(g4);
            g1.SetColumn(g4, 1);

            Button b1 = UIElement.NewButton();
            b1.BackgroundColor = Colors.Green;
            b1.StyleClass = UIElement.Get_Button_NoBackground_NoBorder();  
            b1.BackgroundColor = Colors.Red;
            b1.Text = FaSolid.CaretRight;
            b1.FontFamily = "Fa-Solid";
            b1.Clicked += ToggleTreeView;
            b1.WidthRequest = 20;
            ToggleButton = b1;
            g3.Add(b1);
            b1.SetCursorHand();
            b1.Opacity = 1;
            b1.BorderWidth = 0;
            /*

            var touchBehaviorb1 = new TouchBehavior
            {
                DefaultAnimationDuration = 250,
                DefaultAnimationEasing = Easing.CubicInOut,
                PressedOpacity = 0.6,
                PressedScale = 0.8
            };
            b1.Behaviors.Add(touchBehaviorb1);
            */
            Label l1 = UIElement.NewLabel();
            l1.Text = "Labeltext";
            l1.StyleClass = UIElement.Get_Label_Normal(); 
            l1.VerticalOptions = LayoutOptions.Start;
            l1.HorizontalOptions = LayoutOptions.Start;
            l1.HorizontalTextAlignment = TextAlignment.Start;
            l1.LineBreakMode = LineBreakMode.NoWrap;
            // l1.Command = ClickedEventCommand;
            l1.SetCursorHand();
            Thickness m = new(0, GlobalSpecs.CurrentGlobalSpecs!.GetClickMarginPixel(), 0, GlobalSpecs.CurrentGlobalSpecs.GetClickMarginPixel());
            l1.Margin = m;
            g4.Add(l1);
            TextLabel = l1;
            TapGestureRecognizer tgr = new();
            tgr.Command = ClickedEventCommand;
            l1.GestureRecognizers.Add(tgr);
            l1.Opacity = 1;
            l1.SetValue(Label.OpacityProperty, 1.0f);
            l1.TextColor = GlobalSpecs.CurrentGlobalSpecs.GetCurrentTheme().Col_FG;

            /*
            var touchBehavior = new TouchBehavior
            {
                DefaultAnimationDuration = 250,
                DefaultAnimationEasing = Easing.CubicInOut,
                PressedOpacity = 0.6,
                PressedScale = 0.8
            };
            l1.Behaviors.Add( touchBehavior);
            */
            // CommunityToolkit.Maui.Behaviors.

            Columns.Clear();
            ColumnDefinition cd3 = new();
            cd3.Width = new GridLength(20, GridUnitType.Absolute);
            Columns.Add(cd3);

            ColumnDefinition cd4 = new();
            cd4.Width = new GridLength(5, GridUnitType.Star);
            Columns.Add(cd4);
            g2.ColumnDefinitions = Columns;

            Grid g5 = UIElement.NewGrid();
            g2.Add(g5);
            g2.SetColumn(g5, 1);

            // CalcToggles();

            ParentSubTree = g2;
            SubTree = g5;
        }
        catch (Exception ex)
        {
            string s = ex.Message;
            GlobalData.AddLog("SetupTreeView: " + s, IGlobalData.protMode.crisp);
        }
        /*
        // RowDefinitions[0].Height = 0f;
        // RowDefinitions[1].Height = GridLength.Auto;

        // Grid g6 = this.Children[1] as Grid;
        // g6.ColumnDefinitions[0].Width = 0f;
        // g6.ColumnDefinitions[1].Width = GridLength.Auto;
        // g6.VerticalOptions = LayoutOptions.Start;

        // Grid g7 = this.Children[0] as Grid;
        // g7.IsVisible = false;
        */
    }

    public TreeView(noprapere_tag x) 
    {

    }
}
public delegate void TreeCallback(object? sender, TreeViewEventArgs e);
public delegate void OrderTableCallback(object? sender, OrderTableEventArgs e);

public class TreeViewEventArgs : EventArgs
{
    public Object? UserDefinedObject { get; set; }
    public Label? MainButton { get; set; }
}

public class OrderTableEventArgs: EventArgs
{
    public Object? UserDefinedObject { get; set; }
    public int No { get; set; }
}

public class TreeViewItem : Grid, INotifyPropertyChanged, IDisposable
{
    new public event PropertyChangedEventHandler? PropertyChanged;
    new public void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        if (CurrentOrderListTable != null )
            TextLabel!.Text = CurrentOrderListTable.Name;
        /*
        else 
            TextLabel.Text = "Bla bla bla";
        */
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public enum TreeState { closed, open }

    public Label? TextLabel;
    public Button? ToggleButton;
    // double TreeHeight = 25;
    public Grid? ParentSubTree = null;
    public Grid? SubTree = null;
    public event TreeCallback? Clicked;
    public TreeCallback TreeCallback { get; set; }

    public ICommand? ClickedEvent { get; private set; }
    public ICommand? ClickedData { get; private set; }


    public TreeState? _currentTreeState = TreeState.closed;
    bool _disposed = false;


    public ObservableCollection<OrderListTable>? OrderListTable
    {
        get;
        set;
    }
    public OrderListTable? CurrentOrderListTable
    {
        get;
        set;
    }

    public ICommand? ClickedEventCommand { get; protected set; }
    private Object? _userDefinedObject;
    private ObservableCollection<OrderTable>? _orderTable;
    public Label? TextButton;
    public void ResetTreeViewItem()
    {
        TextLabel = null;
        ToggleButton = null;
        ParentSubTree = null;
        SubTree = null;
    }


    public Object? UserDefinedObject
    {
        get
        {
            return _userDefinedObject;
        }
        set
        {
            _userDefinedObject = value;
            OnPropertyChanged();
            if(ClickedEventCommand != null )
                ( ClickedEventCommand as Command)!.ChangeCanExecute();
        }
    }
    public ObservableCollection<OrderTable>? OrderTable
    {
        get => _orderTable;
        set 
        {
            _orderTable = value;
            OnPropertyChanged();
        }
    }
    public void Dispose()
    {
        // Dispose of unmanaged resources.
        Dispose( true );
        // Suppress finalization.
        // GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposed = true;
    }
    public TreeState? CurrentTreeState
    {
        get => _currentTreeState;
        set
        {
            if ( _currentTreeState != value)
            {

                if (value == TreeState.open)
                {
                    ParentSubTree!.IsVisible = true;
                    if (OrderTable != null)
                    {
                        CreateOrderListView(this);

                    }
                    else if (OrderListTable != null)
                    {
                        CreateTreeViewItem(this);

                    }
                }
                else if (value == TreeState.closed)
                {
                    ParentSubTree!.IsVisible = false;
                    if (OrderTable != null)
                    {
                        DeleteOrderListView(SubTree!);
                    }
                    if (OrderListTable != null)
                    {
                        // ToDo: 
                        // Hier werden die gespeicherten Daten gesammelt
                        DeleteTreeViewItem(SubTree!);

                    }
                }
                _currentTreeState = value;

                (GetRootTree(ParentSubTree!) as TreeView)!.CalcToggles();

                OnPropertyChanged();
            }
        }
    } 

    public string? Text
    {
        get => TextLabel!.Text;
        set
        {
            TextLabel!.Text = value;
        }
    }
    /*
    public double ViewAreaHeight
    {
        get => RowDefinitions[1].Height.Value;
        set => RowDefinitions[1].Height = value;
    }
    */

    double CalcFontSize( double FontSize )
    {
        return FontSize * 1.4;
    }

    public void DisableToggleButton()
    {
        ToggleButton.Clicked -= ToggleTreeView;
        Clicked -= TreeCallback;
    }

    public void AddCallback( )
    {
        // OnClickedTree
    }
    public void CalcToggles()
    {
        if (SubTree != null)
        {
            if (SubTree!.Children.Count > 0)
            {
                ToggleButton!.IsVisible = true;


                int ix = 0;
                foreach (var iv in SubTree!.Children)
                {
                    if (iv.GetType() == typeof(TreeViewItem))
                    {
                        TreeViewItem? tv1 = (iv as TreeViewItem);
                        if (tv1?.CurrentTreeState == TreeState.open)
                        {
                            tv1!.ToggleButton!.Rotation = 45;
                            tv1!.ToggleButton!.Opacity = 0.3;
                            tv1!.CalcToggles();
                        }
                        else
                        {
                            tv1!.ToggleButton!.Rotation = 0;
                            tv1!.ToggleButton!.Opacity = 1;

                            if( tv1!.SubTree!.Children.Count > 0 || tv1!.OrderTable != null || tv1!.OrderListTable != null)
                            {
                                tv1!.ToggleButton!.IsVisible = true;
                            }
                            else
                            {
                                tv1!.ToggleButton!.IsVisible = false;

                            }

                        }
                    }
                    else if (iv.GetType() == typeof(Grid))
                    {

                    }

                    ix++;
                }

            }
            else if( this.OrderTable != null || this.OrderListTable != null )
            {
                ToggleButton!.IsVisible = true;
                this.ToggleButton!.Rotation = 0;
                this.ToggleButton!.Opacity = 1;
            }
            else
            {
                ToggleButton!.IsVisible = false;
            }

        }
      }


    public void CallbackAll(DelVoidObject dvo)
    {
        dvo(this);

        if (SubTree != null)
        {
            if (SubTree!.Children.Count > 0)
            {
                int ix = 0;
                foreach (var iv in SubTree!.Children)
                {
                    if (iv.GetType() == typeof(TreeViewItem))
                    {
                        TreeViewItem? tv1 = (iv as TreeViewItem);
                        tv1!.CallbackAll(dvo);
                    }
                    ix++;
                }

            }
        }

    }
    public static object? GetRootTree( object o1)
    {
        object o = o1;

        while (o.GetType() != typeof(TreeView))
        {
            if( o.GetType() == typeof( OrderListView))
            {
                o = (o as OrderListView)!.Parent;
            }
            else if (o.GetType() == typeof(TreeViewItem))
            {
                o = (o as TreeViewItem )!.Parent;
            }
            else
            {
            o = (o as Grid)!.Parent;

            }

            if (o == null)
                break;
        }

        return o;
    }
    /*
    public double SetTreeHeight( bool parentStart = false)
    {
        // double OwnHeight = CalcFontSize( TextLabel.FontSize );
        // double Height = 0.0f;

        if ( this.GetType() == typeof( TreeView ))
        {
            // OwnHeight = 0;
        }

        if (parentStart == true)
        {
            // OwnHeight = 0;
            }
        else
        {
            if (SubTree != null)
            {
                if (SubTree!.Children.Count > 0)
                {
                    ToggleButton.IsVisible = true;


                    // Height = (SubTree!.Children.Count * TreeHeight);
                    int ix = 0;
                    foreach (var iv in SubTree!.Children)
                    {
                        if (iv.GetType() == typeof(TreeViewItem))
                        {
                            TreeViewItem tv1 = (iv as TreeViewItem);
                            if (tv1.CurrentTreeState == TreeState.open)
                            {
                                tv1.ToggleButton.Rotation = 45;
                                tv1.ToggleButton.Opacity = 0.3;

                                double val = tv1.SetTreeHeight();
                                // Height += val;
                                // tv1.HeightRequest = val;
                                // SubTree!.RowDefinitions[ix].Height = val;
                                // SubTree!.RowDefinitions[ix].Height = GridLength.Auto;
                            }
                            else
                            {
                                tv1.ToggleButton.Rotation = 0;
                                tv1.ToggleButton.Opacity = 1;

                                double val = CalcFontSize(TextLabel.FontSize);
                                // Height += val;
                                // tv1.HeightRequest = val;
                                // SubTree!.RowDefinitions[ix].Height = val;
                                //  SubTree!.RowDefinitions[ix].Height = GridLength.Auto;

                            }
                        }
                        else if (iv.GetType() == typeof(Grid))
                        {

                        }

                        ix++;
                    }

                }
                else
                {
                    ToggleButton.IsVisible = false;
                }

                // ParentSubTree!.HeightRequest = GridLength.Auto;
                // SubTree!.HeightRequest = GridLength.Auto;

                // ParentSubTree!.HeightRequest = Height;
                // SubTree!.HeightRequest = Height;
            }

            // this.HeightRequest = GridLength.Auto;
            int a = 5;


            this.RowDefinitions[0].Height = GridLength.Auto;
            this.RowDefinitions[1].Height = GridLength.Auto;

            // this.HeightRequest = OwnHeight + Height;
            // this.RowDefinitions[0].Height = OwnHeight;
            // this.RowDefinitions[1].Height = Height;
        }
        return 0; // OwnHeight + Height;
    }
    */
    /*
   public double InqChildHeight()
   {
       double Height = 0.0f;

       if( SubTree != null )
       {
           if(SubTree!.Children.Count > 0 )
           { 
               Height = (SubTree!.Children.Count * TreeHeight);
               foreach (var iv in SubTree!.Children)
               {
                   if( iv.GetType() == typeof(TreeViewItem) )
                   {
                       TreeViewItem tv1 = (iv as TreeViewItem);
                       if( tv1.CurrentTreeState == TreeState.open )
                           Height += tv1.InqChildHeight();
                   }
                   else if ( iv.GetType() == typeof( Grid ) )
                   {

                   }

              }
           }
       }

       return Height;
   }
*/

    public TreeViewItem()
    {
 
        ClickedEventCommand = new Command<EventArgs>((e) =>
        {
            if (UserDefinedObject != null)
            {
                if (Clicked != null)
                {
                    TreeViewEventArgs tva = new();
                    tva.UserDefinedObject = UserDefinedObject;

                    Clicked(this, tva);
                }
            }
        });

    }


    public void SetClicked(TreeCallback eh)
    {
        this.Clicked += eh;
        this.TreeCallback = eh;
    }
    public void SetupTreeViewItem()
    { 
        // ClickedDataCommand = new Command( OnClickedData );

        RowDefinitionCollection Rows = new();
        RowDefinition rd1 = new();
        // rd1.Height = new GridLength(TreeHeight, GridUnitType.Absolute);
        rd1.Height = GridLength.Auto; 
        Rows.Add(rd1);
        RowDefinition rd2 = new();
        // rd2.Height = new GridLength(200, GridUnitType.Absolute);
        rd2.Height = GridLength.Auto; 
        Rows.Add(rd2);
        this.RowDefinitions = Rows;

        Grid g1 = UIElement.NewGrid();
        this.Add(g1);
        this.SetRow(g1, 0);

        Grid g2 = UIElement.NewGrid();
        this.Add(g2);
        this.SetRow(g2, 1);

        ColumnDefinitionCollection Columns = new();

        ColumnDefinition cd1 = new();
        cd1.Width = new GridLength(20, GridUnitType.Absolute);
        Columns.Add( cd1 );
        ColumnDefinition cd2 = new();
        cd2.Width = new GridLength(5, GridUnitType.Star);
        Columns.Add( cd2 );
        g1.ColumnDefinitions = Columns;

        /*
        Grid g3 = new();
        g3.WidthRequest = 20;
        g1.Add(g3);
        g1.SetColumn(g3, 0);

        Grid g4 = new();
        g1.Add(g4);
        g1.SetColumn(g4, 1);
        */

        Button b1 = UIElement.NewButton();
        b1.StyleClass = UIElement.Get_Button_NoBackground_NoBorder(); 
        b1.Text = FaSolid.CaretRight;
        b1.FontFamily = "Fa-Solid";
        b1.Clicked += ToggleTreeView;
        b1.WidthRequest = 20;
        b1.SetCursorHand();
        ToggleButton = b1;
        g1.SetColumn(b1, 0);
        g1.Add(b1);
        b1.Opacity = 1;
        b1.BorderWidth = 0;



        /*
        Button l1 = new();
        l1.Text = "Labeltext";
        List<string> styleClasses = new();
        styleClasses.Add("Button_Label_Normal");
        l1.StyleClass = styleClasses;
        l1.VerticalOptions = LayoutOptions.Start;
        l1.HorizontalOptions = LayoutOptions.Start;
        l1.Command = ClickedEventCommand;
        g1.SetColumn(l1, 1);
        g1.Add(l1);
        TextLabel = l1;
        */
        Label l1 = UIElement.NewLabel();
        l1.Text = "Labeltext";
        l1.StyleClass = UIElement.Get_Label_Normal();
        l1.VerticalOptions = LayoutOptions.Start;
        l1.HorizontalOptions = LayoutOptions.Start;
        l1.HorizontalTextAlignment = TextAlignment.Start;
        l1.LineBreakMode = LineBreakMode.TailTruncation;
        // l1.Command = ClickedEventCommand;
        g1.SetColumn(l1, 1);
        g1.Add(l1);
        TextLabel = l1;
        TapGestureRecognizer tgr = new();
        tgr.Command = ClickedEventCommand;
        l1.GestureRecognizers.Add(tgr);
        l1.SetCursorHand();
        Thickness margin = new Thickness(0, GlobalSpecs.CurrentGlobalSpecs!.GetClickMarginPixel(), 0, GlobalSpecs.CurrentGlobalSpecs.GetClickMarginPixel());
        l1.Margin = margin;
        l1.Opacity = 1;
        l1.SetValue( Label.OpacityProperty, 1.0f );
        l1.TextColor = GlobalSpecs.CurrentGlobalSpecs.GetCurrentTheme().Col_FG;

        var touchBehaviorB1 = new TouchBehavior
        {
            HoveredOpacity = 0.7,
            PressedOpacity = 0.7

        };
        l1.Behaviors.Add(touchBehaviorB1);
        
        Columns.Clear();
        ColumnDefinition cd3 = new();
        cd3.Width = new GridLength(20, GridUnitType.Absolute);
        Columns.Add(cd3);

        ColumnDefinition cd4 = new();
        cd4.Width = new GridLength(5, GridUnitType.Star);
        Columns.Add(cd4);
        g2.ColumnDefinitions = Columns;

        Grid g5 = UIElement.NewGrid();
        g2.Add(g5);
        g2.SetColumn(g5, 1);

        // CalcToggles();

        ParentSubTree = g2;
        SubTree = g5;


    }

    public void Add(TreeViewItem tvi )
    {
        if( SubTree == null )
        {
            // int a = 5;
        }

        RowDefinitionCollection rd = SubTree!.RowDefinitions;

        RowDefinition rd1 = new();
        rd1.Height = GridLength.Auto; 
        // rd1.Height = new GridLength(TreeHeight, GridUnitType.Absolute);
        rd.Add(rd1);
        SubTree!.RowDefinitions = rd;


        SubTree!.SetRow(tvi, SubTree!.Children.Count);
        SubTree!.Add(tvi);

        // g1.Add(tvi);

        // CalcToggles();

    }

    public void ToggleTreeView(object? sender, EventArgs e)
    {
        if( CurrentTreeState == TreeState.open)
        {
            CurrentTreeState = TreeState.closed;
            (GetRootTree(ParentSubTree!) as TreeView)!.CalcToggles();
        }
        else
        {
            CurrentTreeState = TreeState.open;
            ( GetRootTree(ParentSubTree!) as TreeView )!.CalcToggles();

        }
    }

    public void CreateTreeViewEntry( OrderListTable ott )
    {
        RowDefinitionCollection Rows = new();
        RowDefinition rd1 = new();
        rd1.Height = GridLength.Auto;
        Rows.Add(rd1);
        RowDefinition rd2 = new();
        rd2.Height = GridLength.Auto;
        Rows.Add(rd2);
        this.RowDefinitions = Rows;

        Grid g1 = new();
        this.Add(g1);
        this.SetRow(g1, 0);

        Grid g2 = new();
        this.Add(g2);
        this.SetRow(g2, 1);

        ColumnDefinitionCollection Columns = new();

        ColumnDefinition cd1 = new();
        cd1.Width = new GridLength(20, GridUnitType.Absolute);
        Columns.Add(cd1);
        ColumnDefinition cd2 = new();
        cd2.Width = new GridLength(5, GridUnitType.Star);
        Columns.Add(cd2);
        g1.ColumnDefinitions = Columns;

        Button b1 = new();
        b1.StyleClass = UIElement.Get_Button_NoBackground_NoBorder();
        b1.Text = FaSolid.CaretRight;
        b1.FontFamily = "Fa-Solid";
        b1.Clicked += ToggleTreeView;
        b1.WidthRequest = 20;
        b1.SetCursorHand();
        ToggleButton = b1;
        g1.SetColumn(b1, 0);
        g1.Add(b1);

        Label l1 = new();
        l1.Text = ott.Name;
        l1.StyleClass = UIElement.Get_Label_Normal();
        l1.VerticalOptions = LayoutOptions.Start;
        l1.HorizontalOptions = LayoutOptions.Start;
        l1.HorizontalTextAlignment = TextAlignment.Start;
        l1.LineBreakMode = LineBreakMode.NoWrap;
        // l1.Command = ClickedEventCommand;
        g1.SetColumn(l1, 1);
        g1.Add(l1);
        TextLabel = l1;
        TapGestureRecognizer tgr = new();
        tgr.Command = ClickedEventCommand;
        l1.GestureRecognizers.Add(tgr);

        Columns.Clear();
        ColumnDefinition cd3 = new();
        cd3.Width = new GridLength(20, GridUnitType.Absolute);
        Columns.Add(cd3);

        ColumnDefinition cd4 = new();
        cd4.Width = new GridLength(5, GridUnitType.Star);
        Columns.Add(cd4);
        g2.ColumnDefinitions = Columns;

        Grid g5 = new();
        g2.Add(g5);
        g2.SetColumn(g5, 1);

        this.CurrentOrderListTable = ott;
        if (ott.OLT != null)
        {
            if (ott.OLT.Count > 0)
                this.OrderListTable = ott.OLT;
        }
        else
            this.OrderListTable = null;

        this.OrderTable = ott.OT!;

        ParentSubTree = g2;
        SubTree = g5;

    }
    public void CreateOrderListView(TreeViewItem tvi)
    {
        if (tvi.OrderTable != null)
        {
            tvi.SubTree!.Clear();
            foreach (OrderTable ot in tvi.OrderTable)
            {
                OrderListView olv = new();
                TreeView? tv = (GetRootTree(tvi!) as TreeView);
                olv.CreateOrderListEntry( ot, tv!, tv!.OTClick, tv!.OrderTableCallback, ot.No);
                tvi.Add(olv);
                // CreateOrderListEntry(tvi, ot);
            }
        }
    }
    public void CreateTreeViewItem(TreeViewItem tvi)
    {
        if( tvi.OrderListTable != null )
        {
            foreach (OrderListTable ott in tvi.OrderListTable)
            {
                if (ott.Name == null || ott.Name == "Mon dieu")
                {
                    OrderTable ot = ott.OT![0];
                    OrderListView olv = new();
                    TreeView? tv = (GetRootTree(tvi!) as TreeView);
                    olv.CreateOrderListEntry(ot, tv!, null, tv!.OrderTableCallback, ot.No );
                    tvi.Add(olv);
                        // CreateOrderListEntry(tvi, ot);

                }
                else
                {

                    TreeViewItem tvi2 = new();
                    tvi2.CreateTreeViewEntry(ott);
                    tvi.Add(tvi2);
                }
            }
        }
        else if (tvi.OrderTable != null)
        {
            tvi.SubTree!.Clear();
            foreach (OrderTable ot in tvi.OrderTable)
            {
                OrderListView olv = new();
                TreeView? tv = (GetRootTree(tvi!) as TreeView);
                olv.CreateOrderListEntry( ot,tv!, null, null, ot.No);
                tvi.Add(olv);
                // CreateOrderListEntry(tvi, ot);
            }
        }
    }
    public void DeleteOrderListView(Grid FromHere)
    {
        FromHere.Children.Clear();
    }
    public void DeleteTreeViewItem(Grid FromHere)
    {
        FromHere.Children.Clear();
    }
    public Position CalcPosition(View? viewO)
    {
        Position P = new();
        P.XPos = viewO!.Width / 2;
        P.YPos = viewO!.Height / 2;

        do
        {
            View? view1 = viewO;
            viewO = viewO!.Parent as View;

         
            if (viewO!.GetType() == typeof(ScrollView))
            {
                ScrollView? sv = viewO as ScrollView;

                P.XPos -= sv!.ScrollX;
                P.YPos -= sv!.ScrollY;
            }
            P.XPos += viewO!.Width;
            P.YPos += viewO!.Height;
        }
        while (viewO!.GetType() != typeof(ContentPage) && viewO!.Parent != null && viewO!.Parent.GetType() != typeof( ReplayPage) );
        return P;
    }
}

public class OrderListView : TreeViewItem, INotifyPropertyChanged
{

    private Label? _response;
    // private int _stepNo;
    private OrderTable? _orderTable;

    public event OrderTableCallback? ClickedOrderTable;
    public event TreeCallback? ClickedTree;
    public Button?   JumpButton;
    public Label?    StepLabel;
    public Label?    StepType;

    public ICommand ClickedTableEntryCommand { get; protected set; }


    public orderType? OrderType 
    {
        get => _orderTable!.OrderType;
        set
        {
            _orderTable!.OrderType = value!;
            OnPropertyChanged();
        }

    }


    new public string? Text
    {
        get => _orderTable!.OrderText;
        set
        {
            _orderTable!.OrderText = value!;
            OnPropertyChanged();
        }
    }

    public int StepNo
    {
        get => _orderTable!.no;
        set
        { 
            _orderTable!.no = value;
            OnPropertyChanged();
        }
    }

    public string? Response
    {
        get => _orderTable!.OrderResult;
        set
        {
            _orderTable!.OrderResult = value;
            OnPropertyChanged();
        }
    }
    public Label? ResponseLabel
    {
        get => _response;
        set
        {
            _response = value;
        }
    }
    new public event PropertyChangedEventHandler? PropertyChanged;
    new public void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        TextLabel!.Text = _orderTable!.OrderText;
        if(TextLabel!.Text == loca.OrderList_AddOrderList_16220 )
        {
            TextLabel!.Text = loca.OrderList_AddOrderList_16220a;
        }
        StepLabel!.Text = _orderTable!.No + ":";
        ResponseLabel!.Text = _orderTable!.OrderResult;
        SetStepType();
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public OrderTable? CurrentOrderTable
    {
        get;
        set;
    }

    public OrderListView()
    {
        ClickedTableEntryCommand= new Command<EventArgs>((e) =>
        {
            if ((GetRootTree(ParentSubTree!) as TreeView)!.OTCallback != null)
            {

                OrderTableEventArgs otva = new();
                otva.No = this.CurrentOrderTable!.No!;

                (GetRootTree(ParentSubTree!) as TreeView)!.OTCallback!(this, otva);
            }
        });
        ClickedEventCommand = new Command<EventArgs>((e) =>
        {


            if (UserDefinedObject != null)
            {
                if (ClickedTree != null)
                {
                    TreeViewEventArgs tva = new();
                    tva.UserDefinedObject = UserDefinedObject;
                    tva.MainButton = TextButton;

                    ClickedTree(this, tva);
                }
            }
        });
    }


 
    public void SetStepType()
    {
        if (OrderType == orderType.noText)
            StepType!.Text = "False Input:";
        else if (OrderType == orderType.orderText)
            StepType!.Text = "Input: "   ;
        else if (OrderType == orderType.mcChoice)
            StepType!.Text = "Choice: ";
        else if (OrderType == orderType.comment)
            StepType!.Text = "Comment: ";
    }

    public void SetOrderTable( OrderTable ot )
    {
        _orderTable = ot;
    }

 
    public void ToggleOrderlistView(object? sender, EventArgs e)
    {
        if (CurrentTreeState == TreeState.open)
        {
            this.RowDefinitions[1].Height = new GridLength(0);
            CurrentTreeState = TreeState.closed;
            ToggleButton!.Text = "+";
            ParentSubTree!.IsVisible = false;
            (GetRootTree(ParentSubTree) as TreeView)!.CalcToggles();
        }
        else
        {
            this.RowDefinitions[1].Height = GridLength.Auto;
            CurrentTreeState = TreeState.open;
            ToggleButton!.Text = "-";
            ParentSubTree!.IsVisible = true;
            (GetRootTree(ParentSubTree) as TreeView)!.CalcToggles();
        }
    }
    public void Switch_OnToggled(object? sender, TappedEventArgs e)
    {
        if (CurrentOrderTable == null) return;

        if( CurrentOrderTable.OrderActive == true )
        {
            CurrentOrderTable.OrderActive = false;
            (sender as Label)!.Text = FaSolid.Times;
        }
        else
        {
            CurrentOrderTable.OrderActive = true;
            (sender as Label)!.Text = FaSolid.Check;
        }
        /*
        if( e.Value == true )
        {
            CurrentOrderTable.OrderActive = true;
        }
        else if ( e.Value == false )
        {
            CurrentOrderTable.OrderActive = false;

        }
        */
    }
    new public void CreateOrderListView(TreeViewItem tvi)
    {
        if (tvi.OrderTable != null)
        {
            tvi!.SubTree!.Clear();
            foreach (OrderTable ot in tvi.OrderTable)
            {
                OrderListView olv = new();
                TreeView tv = (GetRootTree(tvi) as TreeView)!;
                olv.CreateOrderListEntry(ot,tv!, null, null, ot.No);
                tvi.Add(olv);
                // CreateOrderListEntry(tvi, ot);
            }
        }
    }

   //  public delegate void OrderTableCallback(object sender, OrderTableEventArgs e);

    public void GridTapGesture( object? sender, TappedEventArgs tea )
    {
        if (UserDefinedObject != null)
        {
            if (ClickedOrderTable != null)
            {
                TreeViewEventArgs tva = new();
                tva.UserDefinedObject = UserDefinedObject;

                OrderTableEventArgs otea = new();
                otea.UserDefinedObject = UserDefinedObject;
                // otea.

                ClickedOrderTable(this, otea);
            }
        }
    }
    public void CreateOrderListEntry( OrderTable ot, TreeView tv0, TreeCallback? clickedTree = null, OrderTableCallback? clickedOrderTable = null, object? obj = null)
    {
        Grid g1;
        _orderTable = ot;

        UserDefinedObject = obj!;
        ClickedTree = clickedTree!;
        ClickedOrderTable = clickedOrderTable!;
        /*
        if( clickedOrderTable )
            ClickedOrderTable = 
        */

        RowDefinitionCollection Rows = new();


        RowDefinition rd1 = new();
        rd1.Height = GridLength.Auto; // new GridLength(TreeHeight, GridUnitType.Absolute);
        Rows.Add(rd1);
        RowDefinition rd2 = new();
        rd2.Height = GridLength.Auto;
        Rows.Add(rd2);
        RowDefinitions = Rows;

        List<string> s45 = new();
        s45.Add("Border_FG");

        List<string> s7 = new();
        s7.Add("Grid_BGBG");

        if (ot.No == tv0.OTNo)
        {
            Border bo1 = new();
            bo1.StrokeThickness = 1;
            List<string> s4 = new();
            s4.Add("Border_FG");
            bo1.StyleClass = s4;
            Add(bo1);


            g1 = new();
            bo1.Content = g1;
            g1.StyleClass = s7;
            g1.Padding = new Thickness(5, 2, 5, 2);
            g1.Margin = new Thickness(5, 2, 5, 2);
        }
        else
        {
            g1 = new();
            Add(g1);
            this.SetRow(g1, 0);
            g1.StyleClass = s7;
            g1.Padding = new Thickness(5, 2, 5, 2);
            g1.Margin = new Thickness(5, 2, 5, 2);
        }
       

        Grid g2 = new();
        Add(g2);
        this.SetRow(g2, Children.Count);
        g2.StyleClass = s7;
        g2.Padding = new Thickness(10, 0, 10, 0);
        g2.Margin = new Thickness(50, 2, 5, 2);
        ColumnDefinitionCollection Columns2 = new();
        ColumnDefinition cd2_0 = new();
        cd2_0.Width = new GridLength(1, GridUnitType.Star);
        Columns2.Add(cd2_0);
        g2.ColumnDefinitions = Columns2;
        g2.IsVisible = false;

        ColumnDefinitionCollection Columns = new();

        // Toggle
        ColumnDefinition cd0 = new();
        cd0.Width = new GridLength(20, GridUnitType.Absolute);
        Columns.Add(cd0);

        // StepNr.
        ColumnDefinition cd1 = new();
        cd1.Width = new GridLength(50, GridUnitType.Absolute);
        Columns.Add(cd1);

        // Type
        ColumnDefinition cd2 = new();
        cd2.Width = new GridLength(100, GridUnitType.Absolute);
        Columns.Add(cd2);

        // Inputtext
        ColumnDefinition cd3 = new();
        cd3.Width = new GridLength(1, GridUnitType.Star);
        Columns.Add(cd3);

        // Choice
        ColumnDefinition cd4 = new();
        cd4.Width = new GridLength(0, GridUnitType.Absolute);
        Columns.Add(cd4);

        if( GlobalData.CurrentGlobalData!.DebugMode == true )
        {
            // Switch
            ColumnDefinition cd6 = new();
            cd6.Width = new GridLength(40, GridUnitType.Absolute);
            Columns.Add(cd6);

            // Jump
            ColumnDefinition cd5 = new();
            cd5.Width = new GridLength(20, GridUnitType.Absolute);
            Columns.Add(cd5);

        }
        else
        {
            // Switch
            ColumnDefinition cd6 = new();
            cd6.Width = new GridLength(0, GridUnitType.Absolute);
            Columns.Add(cd6);

            // Jump
            ColumnDefinition cd5 = new();
            cd5.Width = new GridLength(0, GridUnitType.Absolute);
            Columns.Add(cd5);

        }

        g1.ColumnDefinitions = Columns;

        Label l1 = new();
        List<string> s2 = new();
        s2.Add("Label_Normal");
        l1.StyleClass = s2;
        l1.Text = ot.No + ":";
        l1.VerticalOptions = LayoutOptions.Center;
        l1.MinimumWidthRequest = 60;
        l1.MaximumWidthRequest = 80;
        l1.FontAutoScalingEnabled = true;
        l1.LineBreakMode = LineBreakMode.NoWrap;
        g1.Add(l1);
        g1.SetColumn(l1, 1);
        StepLabel = l1;


        Label l2 = new();
        l2.StyleClass = s2;
        l2.VerticalOptions = LayoutOptions.Center;
        l2.Text = "";
        g1.Add(l2);
        g1.SetColumn(l2, 2);
        StepType = l2;
 
        Button b1 = new();
        List<string> s1 = new();
        s1.Add("Button_NoBackground_NoBorder");
        b1.StyleClass = s1;
        b1.Text = "+";
        b1.Clicked += ToggleOrderlistView;
        b1.WidthRequest = 20;
        ToggleButton = b1;
        g1.Add(b1);
        g1.SetColumn(b1, 0);
        b1.SetCursorHand();

        Grid gx = new Grid();
        g1.SetColumn(gx, 3);
        g1.Add(gx);
        List<string> styleGridBGBG = new();
        styleGridBGBG.Add("Grid_BGBG");
        gx.StyleClass = styleGridBGBG;
        ColumnDefinitionCollection cds = new();
        ColumnDefinition cd7 = new();
        cd7.Width = new GridLength(1, GridUnitType.Star);
        cds.Add(cd7);
        gx.ColumnDefinitions = cds;
        TapGestureRecognizer tgr = new();
        tgr.Tapped += GridTapGesture;

        gx.GestureRecognizers.Add(tgr);

        Label b2 = new();
        b2.Text = "Töte die Kröte mit der Flöte";
        List<string> styleClasses = new();
        styleClasses.Add("Label_Normal");
        b2.StyleClass = styleClasses;
        // b2.VerticalOptions = LayoutOptions.FillAndExpand;
        // b2.HorizontalOptions = LayoutOptions.Start;
        // b2.Command = ClickedEventCommand;
        // b2.Background = Colors.DarkCyan;
        // b2.BackgroundColor = Colors.DarkBlue;
        // g1.SetColumn(b2, 3);
        gx.Add(b2);
        TextLabel = b2;
        b2.Text = ot.OrderText;
        b2.LineBreakMode = LineBreakMode.WordWrap;
        TextButton = b2;
        TapGestureRecognizer tgr2 = new();
        tgr2.Command = ClickedEventCommand;
        gx.GestureRecognizers.Add(tgr2);
        b2.SetCursorHand();
        if (b2.Text == loca.OrderList_AddOrderList_16220)
        {
            b2.Text = loca.OrderList_AddOrderList_16220a;
        }

        Label lsw1 = new();
        lsw1.StyleClass = styleClasses;
        g1.SetColumn(lsw1, 5);
        g1.Add(lsw1);
        lsw1.FontFamily = "Fa-Solid";
        lsw1.Text = FaSolid.Check;
        lsw1.VerticalOptions = LayoutOptions.Center;
        if( ot.OrderActive == false )
        {
            lsw1.Text = FaSolid.Times;
        }
        TapGestureRecognizer tgr3 = new();
        tgr3.Tapped += Switch_OnToggled;
        lsw1.GestureRecognizers.Add(tgr3);
        lsw1.SetCursorHand();


        /*
        Switch sw1 = new();
        List<string> styleClassesSwitch = new();
        styleClassesSwitch.Add("Switch_Normal");
        sw1.StyleClass = styleClassesSwitch;
        // sw1.OnColor = Colors.Blue;
        // sw1.ThumbColor= Colors.Yellow;
        // sw1.BackgroundColor = Colors.Green;
        sw1.Toggled += Switch_OnToggled;
        sw1.IsToggled = ot.OrderActive;
        sw1.HeightRequest = 12;
        sw1.WidthRequest = 20;
        Thickness th = new Thickness(0, 0, 0, 0);
        sw1.Margin = th;
        g1.SetColumn(sw1, 5);
        g1.Add(sw1);
        */


        Button b3 = new();
        b3.StyleClass = s1;
        b3.Text = FaSolid.CaretRight;
        b3.FontFamily = "Fa-Solid";
        // b1.Clicked += ToggleTreeView;
        JumpButton = b3;
        g1.SetColumn(b3, 6);
        g1.Add(b3);
        b3.Command = ClickedTableEntryCommand;
        b3.SetCursorHand();

        Label l3 = new();
        l3.StyleClass = s2;
        l3.LineBreakMode = LineBreakMode.WordWrap;
        l3.Text = ot.OrderResult;
        g2.Add(l3);
        g2.SetColumn(g2, 0);
        _response = l3;

        ParentSubTree = g2;
        SubTree = g2;

        OrderType = ot.OrderType;
        SetStepType();

        CurrentOrderTable = ot;

        // Grid FromHere = tvi.SubTree;

        CurrentTreeState = TreeState.closed;

    }

    public void CreateOrderListView(Grid FromHere)
    {
        return;

/*
        RowDefinitionCollection Rows = new();
        RowDefinition rd1 = new();
        rd1.Height = GridLength.Auto; // new GridLength(TreeHeight, GridUnitType.Absolute);
        Rows.Add(rd1);
        RowDefinition rd2 = new();
        rd2.Height = GridLength.Auto;
        Rows.Add(rd2);
        FromHere.RowDefinitions = Rows;

        Grid g1 = new();
        FromHere.Add(g1);
        this.SetRow(g1, 0);
        List<string> s3 = new();
        s3.Add("Grid_BGBG");
        g1.StyleClass = s3;
        g1.Padding = new Thickness(5, 5, 5, 5);
        g1.Margin = new Thickness(5, 5, 5, 5);

        Grid g2 = new();
        FromHere.Add(g2);
        FromHere.SetRow(g2, FromHere.Children.Count);
        g2.StyleClass = s3;
        g2.Padding = new Thickness(10, 10, 10, 10);
        g2.Margin = new Thickness(50, 5, 5, 5);
        ColumnDefinitionCollection Columns2 = new();
        ColumnDefinition cd2_0 = new();
        cd2_0.Width = new GridLength(1, GridUnitType.Star);
        Columns2.Add(cd2_0);
        g2.ColumnDefinitions = Columns2;
        g2.IsVisible = false;

        ColumnDefinitionCollection Columns = new();

        // Toggle
        ColumnDefinition cd0 = new();
        cd0.Width = new GridLength(20, GridUnitType.Star);
        Columns.Add(cd0);

        // StepNr.
        ColumnDefinition cd1 = new();
        cd1.Width = new GridLength(40, GridUnitType.Star);
        Columns.Add(cd1);

        // Type
        ColumnDefinition cd2 = new();
        cd2.Width = new GridLength(40, GridUnitType.Star);
        Columns.Add(cd2);

        // Inputtext
        ColumnDefinition cd3 = new();
        cd3.Width = new GridLength(400, GridUnitType.Star);
        Columns.Add(cd3);

        // Choice
        ColumnDefinition cd4 = new();
        cd4.Width = new GridLength(40, GridUnitType.Star);
        Columns.Add(cd4);

        // Jump
        ColumnDefinition cd5 = new();
        cd5.Width = new GridLength(20, GridUnitType.Star);
        Columns.Add(cd5);

        g1.ColumnDefinitions = Columns;

        Label l1 = new();
        List<string> s2 = new();
        s2.Add("Label_Normal");
        l1.StyleClass = s2;
        l1.Text = StepNo + ":";
        l1.VerticalOptions = LayoutOptions.Center;
        g1.Add(l1);
        g1.SetColumn(l1, 1);
        StepLabel = l1;


        Label l2 = new();
        l2.StyleClass = s2;
        l2.VerticalOptions = LayoutOptions.Center;
        g1.Add(l2);
        g1.SetColumn(l2, 2);
        StepType = l2;
        SetStepType();

        Button b1 = new();
        List<string> s1 = new();
        s1.Add("Button_NoBackground_NoBorder");
        b1.StyleClass = s1;
        b1.Text = "+";
        b1.Clicked += ToggleOrderlistView;
        b1.WidthRequest = 20;
        ToggleButton = b1;
        g1.Add(b1);
        g1.SetColumn(b1, 0);

        Label b2 = new();
        b2.Text = "Töte die Kröte mit der Flöte";
        List<string> styleClasses = new();
        styleClasses.Add("Label_Normal");
        b2.StyleClass = styleClasses;
        b2.VerticalOptions = LayoutOptions.Center;
        b2.HorizontalOptions = LayoutOptions.Start;
        // b2.Command = ClickedEventCommand;
        g1.SetColumn(b2, 3);
        g1.Add(b2);
        TextLabel = b2;
        TapGestureRecognizer tgr = new();
        tgr.Command = ClickedEventCommand;
        b2.GestureRecognizers.Add(tgr);



        Button b3 = new();
        b3.StyleClass = s1;
        b3.Text = FaSolid.CaretRight;
        b3.FontFamily = "Fa-Solid";
        // b1.Clicked += ToggleTreeView;
        b3.WidthRequest = 20;
        JumpButton = b3;
        g1.SetColumn(b3, 5);
        g1.Add(b3);

        Label l3 = new();
        l3.StyleClass = s2;
        l3.LineBreakMode = LineBreakMode.WordWrap;
        g2.Add(l3);
        g2.SetColumn(g2, 0);
        _response = l3;

        ParentSubTree = g2;
        SubTree = g2;
        CurrentTreeState = TreeState.closed;
*/
    }


    public void SetupOrderListView()
    { 
        /*
        ClickedEventCommant = new Command<EventArgs>((e) =>
        {
            if (UserDefinedObject != null)
            {
                if (Clicked != null)
                {
                    TreeViewEventArgs tva = new();
                    tva.UserDefinedObject = UserDefinedObject;

                    Clicked(this, tva);
                }
            }
        });
        */
        // ClickedDataCommand = new Command( OnClickedData );

        _orderTable = new();

        RowDefinitionCollection Rows = new();
        RowDefinition rd1 = new();
        rd1.Height = GridLength.Auto; // new GridLength(TreeHeight, GridUnitType.Absolute);
        Rows.Add(rd1);
        RowDefinition rd2 = new();
        rd2.Height = GridLength.Auto; 
        Rows.Add(rd2);
        this.RowDefinitions = Rows;

        Grid g1 = new();
        this.Add(g1);
        this.SetRow(g1, 0);
        List<string> s3 = new();
        s3.Add("Grid_BGBG");
        g1.StyleClass = s3;
        g1.Padding = new Thickness(5, 5, 5, 5);
        g1.Margin= new Thickness(5, 5, 5, 5);

        Grid g2 = new();
        this.Add(g2);
        this.SetRow(g2, 1);
        g2.StyleClass = s3;
        g2.Padding = new Thickness(10, 10, 10, 10);
        g2.Margin = new Thickness(50, 5, 5, 5);
        ColumnDefinitionCollection Columns2 = new();
        ColumnDefinition cd2_0 = new();
        cd2_0.Width = new GridLength(1, GridUnitType.Star);
        Columns2.Add(cd2_0);
        g2.ColumnDefinitions = Columns2;
        g2.IsVisible = false;

        ColumnDefinitionCollection Columns = new();

        // Toggle
        ColumnDefinition cd0 = new();
        cd0.Width = new GridLength(20, GridUnitType.Star);
        Columns.Add(cd0);

        // StepNr.
        ColumnDefinition cd1 = new();
        cd1.Width = new GridLength(40, GridUnitType.Star);
        Columns.Add(cd1);

        // Type
        ColumnDefinition cd2 = new();
        cd2.Width = new GridLength(40, GridUnitType.Star);
        Columns.Add(cd2);

        // Inputtext
        ColumnDefinition cd3 = new();
        cd3.Width = new GridLength(400, GridUnitType.Star);
        Columns.Add(cd3);

        // Choice
        ColumnDefinition cd4 = new();
        cd4.Width = new GridLength(40, GridUnitType.Star);
        Columns.Add(cd4);

        // Jump
        ColumnDefinition cd5 = new();
        cd5.Width = new GridLength(20, GridUnitType.Star);
        Columns.Add(cd5);

        g1.ColumnDefinitions = Columns;

        Label l1 = new();
        List<string> s2 = new();
        s2.Add("Label_Normal");
        l1.StyleClass = s2;
        l1.Text = StepNo +":";
        l1.VerticalOptions = LayoutOptions.Center;
        g1.Add(l1);
        g1.SetColumn(l1, 1);
        StepLabel = l1;


        Label l2 = new();
        l2.StyleClass = s2;
        l2.VerticalOptions = LayoutOptions.Center;
        g1.Add(l2);
        g1.SetColumn(l2, 2);
        StepType = l2;
        SetStepType();

        Button b1 = new();
        List<string> s1 = new();
        s1.Add("Button_NoBackground_NoBorder");
        b1.StyleClass = s1;
        b1.Text = "+";
        b1.Clicked += ToggleOrderlistView;
        b1.WidthRequest = 20;
        ToggleButton = b1;
        g1.Add(b1);
        g1.SetColumn(b1, 0);

        /*
        List<string> s4 = new();
        s4.Add("Button_BGBG_NoBorder");
        */
        Label b2 = new();
        b2.Text = "Töte die Kröte mit der Flöte";
        List<string> styleClasses = new();
        styleClasses.Add("Button_Normal_Large");
        b2.StyleClass = styleClasses;
        b2.BackgroundColor = Colors.AliceBlue; 
        b2.VerticalOptions = LayoutOptions.Center;
        b2.HorizontalOptions = LayoutOptions.Start;
        b2.HorizontalTextAlignment = TextAlignment.Start;
        // b2.Command = ClickedEventCommand;
        g1.SetColumn(b2, 3);
        g1.Add(b2);
        TextLabel = b2;
        TapGestureRecognizer tgr = new();
        tgr.Command = ClickedEventCommand;
        b2.GestureRecognizers.Add(tgr);

        Button b3 = new();
        b3.StyleClass = s1;
        b3.Text = FaSolid.CaretRight;
        b3.FontFamily = "Fa-Solid";
        // b1.Clicked += ToggleTreeView;
        b3.WidthRequest = 20;
        JumpButton = b3;
        g1.SetColumn(b3, 5);
        g1.Add(b3);

        Label l3 = new();
        l3.StyleClass = s2;
        l3.LineBreakMode = LineBreakMode.WordWrap;
        g2.Add(l3);
        g2.SetColumn(g2, 0);
        _response = l3;

        ParentSubTree = g2;
        SubTree = g2;
        CurrentTreeState = TreeState.closed;
    }

}


public class TabItem: Grid, INotifyPropertyChanged
{
    public class TabPanel 
    {
        public int OrderNo { get; set; }
        public IDButton? SelectButton { get; set; }
        public ScrollView? TabPanelSV { get; set; }
        public Grid? TabPanelGrid { get; set; }
        public int TypeID { get; set; }
    }

    new public event PropertyChangedEventHandler? PropertyChanged;
    new public void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
    public int SelectedTabPanel { get; set; }
    public ObservableCollection<TabPanel> TabPanels;
    public Grid Headline { get; set; }
    public ScrollView HeadlineSV { get; set; }
    public Grid MainPanel { get; set; }

    public List<string> TabButtonStyleSelected { get; set; }
    public List<string> TabButtonStyleUnselected { get; set; }
    public List<string> HeadlineStyle { get; set; }
    public List<string> MainPanelStyle { get; set; }
    public TabItem() : base()
    {
        TabPanels = new();

        RowDefinitionCollection rdc = new();
        rdc.Add(new RowDefinition(new GridLength(1, GridUnitType.Auto)));
        rdc.Add(new RowDefinition(new GridLength(1, GridUnitType.Star )));

        this.RowDefinitions = rdc;

        HeadlineSV = new();
        HeadlineSV.Orientation = ScrollOrientation.Horizontal;
        this.Add(HeadlineSV);
        this.BackgroundColor = Colors.Yellow;

        Headline = new();
        // Headline.Background = Colors.Red;
        HeadlineSV.Content = Headline;
        List<string> svClass = new();
        svClass.Add("ScrollView_BGBG");
        HeadlineSV.StyleClass = svClass;

        MainPanel = new();
        // MainPanel.Background = Colors.Green;
        this.Add(MainPanel);
        List<string> tiClass = new();
        tiClass.Add("TabItem_BG");
        MainPanel.StyleClass = tiClass;
        Thickness m = new Thickness(0, 5, 0, 5);
        MainPanel.Padding = m;

        this.SetRow(MainPanel, 1);

        TabButtonStyleSelected = new();
        TabButtonStyleUnselected = new();
        HeadlineStyle = new();
        MainPanelStyle = new();
    }

    public void AddTabButtonStyleSelected( string style )
    {
        TabButtonStyleSelected.Clear();
        TabButtonStyleSelected.Add(style);
    }
    public void AddTabButtonStyleUnselected(string style)
    {
        TabButtonStyleUnselected.Clear();
        TabButtonStyleUnselected.Add(style);
    }
    public void AddHeadlineStyle(string style)
    {
        HeadlineStyle.Add(style);
        Headline.StyleClass = HeadlineStyle;
    }
    public void AddMainPanelStyle(string style)
    {
        MainPanelStyle.Add(style);
        MainPanel.StyleClass = MainPanelStyle;
    }

    public void SyncTabStyles()
    {
        bool searchFirst = false;
        foreach (object o in Headline.Children)
        {
            if (o.GetType() == typeof(IDButton))
            {
                IDButton? b = o as IDButton;
                if (b!.ID == SelectedTabPanel)
                {
                    if (b.IsVisible == false)
                        searchFirst = true;
                }
            }
        }

        if (searchFirst)
        {
            foreach (object o in Headline.Children)
            {
                if (o.GetType() == typeof(IDButton))
                {
                    IDButton? b = o as IDButton;
                    if (b!.IsVisible)
                    {
                        SelectedTabPanel = b.ID;
                        break;
                    }
                }
            }
        }

        foreach ( object o in Headline.Children )
        {
            if( o.GetType() == typeof( IDButton))
            {
                IDButton? b = o as IDButton;
                if( b!.ID == SelectedTabPanel )
                {
                    b!.StyleClass = TabButtonStyleSelected;
                }
                else
                {
                    b!.StyleClass = TabButtonStyleUnselected;

                }
            }
        }

        int ix = 0;

        for( ix = 0; ix < MainPanel.Children.Count; ix++)
        {
            if (ix == SelectedTabPanel)
                ( MainPanel.Children[ix] as ScrollView)!.IsVisible = true;
            else
                (MainPanel.Children[ix] as ScrollView)!.IsVisible = false;

        }
    }

    public  void SelectTabItem( object? sender, EventArgs cea )
    {
        IDButton? b = (sender as IDButton)!;

        SelectedTabPanel = b!.ID;

        SyncTabStyles();
    }

    public void CalcTabPanel( )
    {
        int ix;
        // Step 1: Die ID in TabPanels finden
        for ( ix = 0; ix < this.TabPanels.Count; ix++)
        {
            if (this.TabPanels[ix].SelectButton!.ID == SelectedTabPanel)
            {
                 break;
            }
        }

        // Step 2: Das erste Panel, das aktiv ist, wird als aktives Panel gesetzt
        for (; ix < this.TabPanels.Count; ix++)
        {
            if (this.TabPanels[ix].SelectButton!.IsVisible == true)
            {
                SelectedTabPanel = this.TabPanels[ix].SelectButton!.ID;
                break;

            }
        }
    }
    public TabPanel AddTabPanel( string? Text, int typeID = 0 )
    {
        TabPanel t = new();
        Thickness m = new(5, 0, 5, 0);
        t.SelectButton = new IDButton();
        t.SelectButton.Text = Text;
        t.SelectButton.Margin = m;
        t.SelectButton.ID = TabPanels.Count;
        t.SelectButton.CornerRadius = 1;
        t.SelectButton.Clicked += SelectTabItem;
        // t.SelectButton.Background = Colors.Red;
        t.TypeID = typeID;
        /*
        var touchBehaviorT = new TouchBehavior
        {
            // HoveredBackgroundColor = "{StaticResource Gray900}",
            HoveredScale = 1.2

        };
        t.SelectButton.Behaviors.Add(touchBehaviorT);
        */
        TabPanels.Add(t);

        Headline.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));
        Headline.Add(t.SelectButton);
        Headline.SetColumn(t.SelectButton, Headline.Children.Count-1);

        t.TabPanelSV = new();
        MainPanel.Children.Add(t.TabPanelSV);


        t.TabPanelGrid = new();
        // t.TabPanelGrid.Background = Colors.Green;
        t.TabPanelGrid.VerticalOptions = LayoutOptions.FillAndExpand;
        t.TabPanelSV.Content =  t.TabPanelGrid;
        // t.TabPanelSV.Background = Colors.Yellow;
        t.TabPanelSV.VerticalOptions = LayoutOptions.FillAndExpand;
        List<string> grStyles = new();
        grStyles.Add("Grid_Normal");
        t.TabPanelGrid.StyleClass = grStyles;

        Label l1 = new();
        l1.Text = TabPanels.Count + ". Panelinjni";
        l1.TextColor = Colors.White;
        // l1.Background = Colors.Blue;
        t.TabPanelGrid.Add(l1);

        SyncTabStyles();
        return t;

    }
}
public partial class AppShell : Shell
{
    public static AppShell? _mainAppShell { get; set; }

    public Color xBGBG
    {
        get
        {
            ResourceDictionary? rd3 = ((Collection<ResourceDictionary>)App.Current!.MainPage!.Resources.MergedDictionaries)[1];
            Color c = (Color) rd3["BGBG"];
            return c;  
        }
    }


    public static double Maedium
    {
        get
        {
            ResourceDictionary? rd3 = ((Collection<ResourceDictionary>)App.Current!.MainPage!.Resources.MergedDictionaries)[3];
            double m = (double)rd3["Medium"];
            m *= 3;
            return m;
        }
    }
    public Color xBG
    {
        get
        {
            ResourceDictionary? rd3 = ((Collection<ResourceDictionary>)App.Current!.MainPage!.Resources.MergedDictionaries)[1];
            Color c = (Color)rd3["BG"];
            return c;
        }
    }
    public Color xFG
    {
        get
        {
            ResourceDictionary rd3 = ((Collection<ResourceDictionary>)App.Current!.MainPage!.Resources.MergedDictionaries)[1];
            Color c = (Color)rd3["FG"];
            return c;
        }
    }
    public Color BG
    {
        get => Colors.Green;
    }
    public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
        Routing.RegisterRoute(nameof(ReplayPage), typeof(ReplayPage));
        Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
        Routing.RegisterRoute(nameof(CreditsPage), typeof(CreditsPage));
        Routing.RegisterRoute(nameof(EndPage), typeof(EndPage));

        _mainAppShell = this;


        //  _mainAppShell.Resources.
    }

    public void ChangeTheme(ResourceDictionary theme)
    {
        foreach (var rd in Resources.MergedDictionaries)
        {
            try
            {
                if (rd["Type"].ToString() == "Theme")
                {
                    Resources.MergedDictionaries.Remove(rd);
                    break;
               }
            }
            catch
            {

            }
        }
        // Resources.MergedDictionaries.Remove(Resources.MergedDictionaries.Last());
        Resources.MergedDictionaries.Add(theme);
    }
    public void ChangeFont(ResourceDictionary theme)
    {
        foreach (var rd in Resources.MergedDictionaries)
        {
            try
            {
                if (rd["Type"].ToString() == "Font")
                {
                    Resources.MergedDictionaries.Remove(rd);
                    break;
                }
            }
            catch
            {

            }
        }
        // Resources.MergedDictionaries.Remove(Resources.MergedDictionaries.Last());
        Resources.MergedDictionaries.Add(theme);
    }
    public void ChangeFontSize(ResourceDictionary theme)
    {
        foreach (var rd in Resources.MergedDictionaries)
        {
            try
            {
                if (rd["Type"].ToString() == "FontSize")
                {
                    Resources.MergedDictionaries.Remove(rd);
                    break;
                }
            }
            catch
            {

            }
        }
        // Resources.MergedDictionaries.Remove(Resources.MergedDictionaries.Last());
        Resources.MergedDictionaries.Add(theme);
    }

}
