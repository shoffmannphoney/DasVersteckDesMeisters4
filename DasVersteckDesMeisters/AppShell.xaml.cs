using CommunityToolkit.Maui.Behaviors;
using GameCore;
using Phoney_MAUI.Core;
using Phoney_MAUI.Menu;
using Phoney_MAUI.Model;
using Phoney_MAUI.Platform;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Phoney_MAUI;

public class MyTouchBehavior : TouchBehavior
{
    public void OnDetachingFrom(View bindable)
    {
        // Beispiel: Abmelden von einem Ereignis
        // bindable.PropertyChanged -= OnBindablePropertyChanged;
        base.OnDetachingFrom(bindable);
    }

    public void Dispose()
    {

    }
}

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

    public static void ResetCursors( this View v)
    {
        foreach( GestureRecognizer gr in v.GestureRecognizers)
        {
            if( gr is PointerGestureRecognizer)
            {
                PointerGestureRecognizer pgr = (gr as PointerGestureRecognizer)!;
                pgr.PointerEntered -= OnEnterHand;
                pgr.PointerEntered -= OnEnterCross;
                pgr.PointerEntered -= OnEnterHelp;
                pgr.PointerEntered -= OnExit;
                // v.GestureRecognizers.Remove(gr);
            }
        }
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

public class IDLabel : Label
{
    public int ID;
    public class GestureMethods
    {
        public TapGestureRecognizer tgr;

        public EventHandler<TappedEventArgs> gvso;

        public GestureMethods( TapGestureRecognizer tgr, EventHandler<TappedEventArgs> gvso)
        {
            this.tgr = tgr;
            this.gvso = gvso;
        }
    }

    public List<GestureMethods> GMethods { get; set; } = new();

    public void Reset()
    {
        foreach (GestureMethods gm in GMethods)
        {
            TapGestureRecognizer tgr = gm.tgr;
            tgr.Tapped -= gm.gvso;
        }
        GMethods.Clear();
    }
    public void Dispose()
    {
       Reset();
    }
 }


public class IDButton : Button
{
    public int ID;

    public class GestureMethods
    {
        public TapGestureRecognizer tgr;

        public EventHandler<TappedEventArgs> gvso;

        public GestureMethods(TapGestureRecognizer tgr, EventHandler<TappedEventArgs> gvso)
        {
            this.tgr = tgr;
            this.gvso = gvso;
        }
    }

    public List<GestureMethods> GMethods { get; set; } = new();

    public void Reset()
    {
        foreach (GestureMethods gm in GMethods)
        {
            TapGestureRecognizer tgr = gm.tgr;
            tgr.Tapped -= gm.gvso;
        }
        GMethods.Clear();
    }
    public void Dispose()
    {
        Reset();
    }
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
    public static List<Grid> listGrid = new();
    public static List<VerticalStackLayout> listVerticalStackLayout = new();
    public static List<TreeViewItem> listTreeViewItem = new();
    public static List<TreeView> listTreeView = new();
    public static List<IDButton> listIDButton = new();
    public static List<IDLabel> listIDLabel = new();
    public static List<Button> listButton = new();
    public static List<Label> listLabel = new();
    public static List<ScrollView> listScrollView = new();
    public static List<OrderListView> listOrderListView = new();

    public static bool StoreMode { get; set; } = true;

    public static void RemoveEventHandler( TapGestureRecognizer tgr, EventHandler eh)
    {
        // tgr.Tapped -= eh;
        /*
            foreach (var handler in tgr.Tapped.GetInvocationList())
            {
                // handler ist ein Delegate, das eine der Methoden repräsentiert, die an das Ereignis angehängt sind.
                // Sie können es als EventHandler aufrufen, wenn Sie möchten:
                var eventHandler2 = (EventHandler)handler;
                // eventHandler2(tgr, EventArgs.Empty);
            }
        */
    }

    public static void StoreGrid(Grid g, bool Pooling = true)
    {
        
        try
        {
            foreach (Grid gx in listGrid)
            {
                if (gx == g)
                {
                    return;
                }
            }

            while (g.ColumnDefinitions.Count > 0)
            {
                g.ColumnDefinitions[0].Width = GridLength.Star;
                g.ColumnDefinitions.RemoveAt(0);
            }
            while (g.RowDefinitions.Count > 0)
            {
                g.RowDefinitions[0].Height = GridLength.Star;
                g.RowDefinitions.RemoveAt(0);
            }

            g.ColumnDefinitions.Clear();
            g.RowDefinitions.Clear();

            g.ClearValue(Grid.ColumnProperty);
            g.ClearValue(Grid.RowProperty);
            g.ClearValue(Grid.BackgroundColorProperty);
            g.ClearValue(Grid.BackgroundProperty);
            g.ClearValue(Grid.BindingContextProperty);
            g.ClearValue(Grid.HeightRequestProperty);
            g.ClearValue(Grid.IsVisibleProperty);

            g.ClearValue(Grid.MarginProperty);
            g.ClearValue(Grid.OpacityProperty);
            g.ClearValue(Grid.PaddingProperty);
            g.ClearValue(Grid.ColumnDefinitionsProperty);
            g.ClearValue(Grid.RowDefinitionsProperty);
            g.ClearValue(Grid.StyleProperty);
            g.ClearValue(Grid.WidthRequestProperty);

            g.ClearValue(Grid.VerticalOptionsProperty);
            g.ClearValue(Grid.HorizontalOptionsProperty);
            g.ClearValue(Grid.MinimumHeightRequestProperty);
            g.ClearValue(Grid.MinimumWidthRequestProperty);
            g.ClearValue(Grid.MaximumHeightRequestProperty);
            g.ClearValue(Grid.MaximumWidthRequestProperty);
            g.ClearValue(Grid.MarginProperty);
            g.ClearValue(Grid.PaddingProperty);
            g.ClearValue(Grid.ClassIdProperty);

            g.ClearValue(Grid.HeightRequestProperty);
            g.ClearValue(Grid.InputTransparentProperty);
            g.ClearValue(Grid.InputTransparentProperty);
            g.ClearValue(Grid.IsEnabledProperty);
            g.ClearValue(Grid.RotationProperty);
            g.ClearValue(Grid.RotationXProperty);
            g.ClearValue(Grid.RotationYProperty);
            g.ClearValue(Grid.ScaleProperty);
            g.ClearValue(Grid.ScaleXProperty);
            // g.Handler = null;

            g.ClearLogicalChildren();
            g.Parent = null;
            g.Children.Clear();
            g.StyleClass = null;
            g.Margin = Thickness.Zero;
            /*
                   */

            if (Pooling == true && listGrid.Count < 100 && StoreMode == true )
                listGrid.Add(g);
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("StoreGrid: " + ex.Message, IGlobalData.protMode.crisp);
        }
    }
    public static void StoreVerticalStackLayout(VerticalStackLayout g, bool Pooling = true)
    {
        try
        { 
        foreach (VerticalStackLayout gx in listVerticalStackLayout)
        {
            if (gx == g)
            {
                return;
            }
        }


            g.ClearValue(Grid.ColumnProperty);
            g.ClearValue(Grid.RowProperty);
            g.ClearValue(VerticalStackLayout.BackgroundColorProperty);
        g.ClearValue(VerticalStackLayout.BackgroundProperty);
        g.ClearValue(VerticalStackLayout.BindingContextProperty);
        g.ClearValue(VerticalStackLayout.HeightRequestProperty);
        g.ClearValue(VerticalStackLayout.IsVisibleProperty);
        g.ClearValue(VerticalStackLayout.MarginProperty);
        g.ClearValue(VerticalStackLayout.OpacityProperty);
        g.ClearValue(VerticalStackLayout.PaddingProperty);
        g.ClearValue(VerticalStackLayout.StyleProperty);
        g.ClearValue(VerticalStackLayout.WidthRequestProperty);

        g.ClearValue(VerticalStackLayout.VerticalOptionsProperty);
        g.ClearValue(VerticalStackLayout.HorizontalOptionsProperty);
        g.ClearValue(VerticalStackLayout.MinimumHeightRequestProperty);
        g.ClearValue(VerticalStackLayout.MinimumWidthRequestProperty);
        g.ClearValue(VerticalStackLayout.MaximumHeightRequestProperty);
        g.ClearValue(VerticalStackLayout.MaximumWidthRequestProperty);
        g.ClearValue(VerticalStackLayout.MarginProperty);
        g.ClearValue(VerticalStackLayout.PaddingProperty);
        g.ClearValue(VerticalStackLayout.ClassIdProperty);

        g.ClearValue(Grid.HeightRequestProperty);
        g.ClearValue(Grid.InputTransparentProperty);
        g.ClearValue(Grid.InputTransparentProperty);
        g.ClearValue(Grid.IsEnabledProperty);
        g.ClearValue(Grid.RotationProperty);
        g.ClearValue(Grid.RotationXProperty);
        g.ClearValue(Grid.RotationYProperty);
        g.ClearValue(Grid.ScaleProperty);
        g.ClearValue(Grid.ScaleXProperty);
        g.ClearValue(Grid.ScaleYProperty);

        g.Parent = null;
        g.ClearLogicalChildren();
        g.Children.Clear();
            g.StyleClass = null;
            g.Margin = Thickness.Zero;

            if (Pooling == true && listVerticalStackLayout.Count < 100 && StoreMode == true)
                listVerticalStackLayout.Add(g);
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("StoreVerticalStackLayout: " + ex.Message, IGlobalData.protMode.crisp);
        }

    }
    public static void StoreTreeViewItem(TreeViewItem tvi, bool Pooling = true)
    {
        try
        {
            foreach (TreeViewItem tvix in listTreeViewItem)
            {
                if (tvix == tvi)
                {
                    return;
                }
            }

            tvi.ResetTreeViewItem();

            while (tvi.ColumnDefinitions.Count > 0)
           {
                tvi.ColumnDefinitions[0].Width = GridLength.Star;
                tvi.ColumnDefinitions.RemoveAt(0);
           }
           while (tvi.RowDefinitions.Count > 0)
           {
                tvi.RowDefinitions[0].Height = GridLength.Star;
                tvi.RowDefinitions.RemoveAt(0);
           }


           tvi.ColumnDefinitions.Clear();
           tvi.RowDefinitions.Clear();

            tvi.UserDefinedObject = null;
            tvi.ClearValue(TreeViewItem.ColumnProperty);
            tvi.ClearValue(TreeViewItem.RowProperty);
            tvi.ClearValue(TreeViewItem.ColumnDefinitionsProperty);
         tvi.ClearValue(TreeViewItem.RowDefinitionsProperty);

         tvi.ClearValue(TreeViewItem.BackgroundColorProperty);
         tvi.ClearValue(TreeViewItem.BackgroundProperty);
         tvi.ClearValue(TreeViewItem.BindingContextProperty);
         tvi.ClearValue(TreeViewItem.HeightRequestProperty);
         tvi.ClearValue(TreeViewItem.IsVisibleProperty);
         tvi.ClearValue(TreeViewItem.MarginProperty);
         tvi.ClearValue(TreeViewItem.OpacityProperty);
         tvi.ClearValue(TreeViewItem.PaddingProperty);
         tvi.ClearValue(TreeViewItem.StyleProperty);
         tvi.ClearValue(TreeViewItem.WidthRequestProperty);

          tvi.ClearValue(TreeViewItem.VerticalOptionsProperty);
          tvi.ClearValue(TreeViewItem.HorizontalOptionsProperty);
          tvi.ClearValue(TreeViewItem.MinimumHeightRequestProperty);
          tvi.ClearValue(TreeViewItem.MinimumWidthRequestProperty);
          tvi.ClearValue(TreeViewItem.MaximumHeightRequestProperty);
          tvi.ClearValue(TreeViewItem.MaximumWidthRequestProperty);
          tvi.ClearValue(TreeViewItem.MarginProperty);
          tvi.ClearValue(TreeViewItem.PaddingProperty);
          tvi.ClearValue(TreeViewItem.ClassIdProperty);

       tvi.ClearValue(TreeViewItem.HeightRequestProperty);
        tvi.ClearValue(TreeViewItem.InputTransparentProperty);
        tvi.ClearValue(TreeViewItem.InputTransparentProperty);
        tvi.ClearValue(TreeViewItem.IsEnabledProperty);
        tvi.ClearValue(TreeViewItem.RotationProperty);
        tvi.ClearValue(TreeViewItem.RotationXProperty);
        tvi.ClearValue(TreeViewItem.RotationYProperty);
        tvi.ClearValue(TreeViewItem.ScaleProperty);
        tvi.ClearValue(TreeViewItem.ScaleXProperty);
        tvi.ClearValue(TreeViewItem.ScaleYProperty);

            tvi.Parent = null;
            tvi.ClearLogicalChildren();
            tvi.Children.Clear();
               tvi.SubTree = null;
            tvi.ParentSubTree = null;
            tvi.IsVisible = true;
            tvi.StyleClass = null;
            tvi.Margin = Thickness.Zero;
            // tvi.ClickedEventCommand = null;
            /*



                                */

            if (Pooling == true && listTreeViewItem.Count < 100 && StoreMode == true)
                listTreeViewItem.Add(tvi);
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("StoreTreeViewItem: " + ex.Message, IGlobalData.protMode.crisp);
        }
    }
    public static void StoreTreeView(TreeView tv, bool Pooling = true)
    {
        try
        { 
        foreach (TreeView tvx in listTreeView)
        {
            if (tvx == tv)
            {
                return;
            }
        }


        while (tv.ColumnDefinitions.Count > 0)
        {
                tv.ColumnDefinitions[0].Width = GridLength.Star;
                tv.ColumnDefinitions.RemoveAt(0);
        }
        while (tv.RowDefinitions.Count > 0)
        {
                tv.RowDefinitions[0].Height = GridLength.Star;
                tv.RowDefinitions.RemoveAt(0);
        }


        tv.ColumnDefinitions.Clear();
        tv.RowDefinitions.Clear();


            tv.UserDefinedObject = null;
            tv.ClearValue(TreeViewItem.ColumnProperty);
            tv.ClearValue(TreeViewItem.RowProperty);
            tv.ClearValue(TreeView.BackgroundColorProperty);
        tv.ClearValue(TreeView.BackgroundProperty);
        tv.ClearValue(TreeView.BindingContextProperty);
        tv.ClearValue(TreeView.ColumnDefinitionsProperty);
        tv.ClearValue(TreeView.HeightRequestProperty);
        tv.ClearValue(TreeView.IsVisibleProperty);
        tv.ClearValue(TreeView.MarginProperty);
        tv.ClearValue(TreeView.OpacityProperty);
        tv.ClearValue(TreeView.PaddingProperty);
        tv.ClearValue(TreeView.RowDefinitionsProperty);
        tv.ClearValue(TreeView.StyleProperty);
        tv.ClearValue(TreeView.WidthRequestProperty);

        tv.ClearValue(TreeView.VerticalOptionsProperty);
        tv.ClearValue(TreeView.HorizontalOptionsProperty);
        tv.ClearValue(TreeView.MinimumHeightRequestProperty);
        tv.ClearValue(TreeView.MinimumWidthRequestProperty);
        tv.ClearValue(TreeView.MaximumHeightRequestProperty);
        tv.ClearValue(TreeView.MaximumWidthRequestProperty);
        tv.ClearValue(TreeView.MarginProperty);
        tv.ClearValue(TreeView.PaddingProperty);
        tv.ClearValue(TreeView.ClassIdProperty);

        tv.ClearValue(TreeView.HeightRequestProperty);
        tv.ClearValue(TreeView.InputTransparentProperty);
        tv.ClearValue(TreeView.InputTransparentProperty);
        tv.ClearValue(TreeView.IsEnabledProperty);
        tv.ClearValue(TreeView.RotationProperty);
        tv.ClearValue(TreeView.RotationXProperty);
        tv.ClearValue(TreeView.RotationYProperty);
        tv.ClearValue(TreeView.ScaleProperty);
        tv.ClearValue(TreeView.ScaleXProperty);
        tv.ClearValue(TreeView.ScaleYProperty);

        tv.Parent = null;
        tv.SubTree = null;
        tv.ParentSubTree = null;
            tv.StyleClass = null;
            tv.Margin = Thickness.Zero;
            // tv.ClickedEventCommand = null;


            if (Pooling == true && listTreeView.Count < 100 && StoreMode == true)
           listTreeView.Add(tv);
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("StoreTreeView: " + ex.Message, IGlobalData.protMode.crisp);
        }
    }
    public static void StoreOrderListView(OrderListView olv, bool Pooling = true)
    {
        try
        { 
        foreach (OrderListView olvx in listOrderListView)
        {
            if (olvx == olv)
            {
                return;
            }
        }

        while (olv.ColumnDefinitions.Count > 0)
        {
                olv.ColumnDefinitions[0].Width = GridLength.Star;
                olv.ColumnDefinitions.RemoveAt(0);
        }
        while (olv.RowDefinitions.Count > 0)
        {
                olv.RowDefinitions[0].Height = GridLength.Star;
                olv.RowDefinitions.RemoveAt(0);
        }


        olv.ColumnDefinitions.Clear();
        olv.RowDefinitions.Clear();

            olv.ClearValue(OrderListView.ColumnProperty);
            olv.ClearValue(OrderListView.RowProperty);
            olv.ClearValue(OrderListView.BackgroundColorProperty);
        olv.ClearValue(OrderListView.BackgroundProperty);
        olv.ClearValue(OrderListView.BindingContextProperty);
        olv.ClearValue(OrderListView.ColumnDefinitionsProperty);
        olv.ClearValue(OrderListView.HeightRequestProperty);
        olv.ClearValue(OrderListView.IsVisibleProperty);
        olv.ClearValue(OrderListView.MarginProperty);
        olv.ClearValue(OrderListView.OpacityProperty);
        olv.ClearValue(OrderListView.PaddingProperty);
        olv.ClearValue(OrderListView.RowDefinitionsProperty);
        olv.ClearValue(OrderListView.StyleProperty);
        olv.ClearValue(OrderListView.WidthRequestProperty);

        olv.Parent = null;

        olv.ClearValue(OrderListView.VerticalOptionsProperty);
        olv.ClearValue(OrderListView.HorizontalOptionsProperty);
        olv.ClearValue(OrderListView.MinimumHeightRequestProperty);
        olv.ClearValue(OrderListView.MinimumWidthRequestProperty);
        olv.ClearValue(OrderListView.MaximumHeightRequestProperty);
        olv.ClearValue(OrderListView.MaximumWidthRequestProperty);
        olv.ClearValue(OrderListView.MarginProperty);
        olv.ClearValue(OrderListView.PaddingProperty);
        olv.ClearValue(OrderListView.ClassIdProperty);

        olv.ClearValue(OrderListView.HeightRequestProperty);
        olv.ClearValue(OrderListView.InputTransparentProperty);
        olv.ClearValue(OrderListView.InputTransparentProperty);
        olv.ClearValue(OrderListView.IsEnabledProperty);
        olv.ClearValue(OrderListView.RotationProperty);
        olv.ClearValue(OrderListView.RotationXProperty);
        olv.ClearValue(OrderListView.RotationYProperty);
        olv.ClearValue(OrderListView.ScaleProperty);
        olv.ClearValue(OrderListView.ScaleXProperty);
        olv.ClearValue(OrderListView.ScaleYProperty);
            olv.StyleClass = null;
            olv.Margin = Thickness.Zero;
            // olv.ClickedEventCommand = null;

            if (Pooling == true && listOrderListView.Count < 100 && StoreMode == true)
                listOrderListView.Add(olv);
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("StoreOrderListView: " + ex.Message, IGlobalData.protMode.crisp);
        }
    }
    public static void StoreScrollView(ScrollView sv, bool Pooling = true)
    {
        try
        {
            foreach (ScrollView svx in listScrollView)
            {
                if (svx == sv)
                {
                    return;
                }
            }

            sv.ClearValue(Grid.ColumnProperty);
            sv.ClearValue(Grid.RowProperty);
            sv.ClearValue(ScrollView.BackgroundColorProperty);
            sv.ClearValue(ScrollView.BackgroundProperty);
            sv.ClearValue(ScrollView.BindingContextProperty);
            sv.ClearValue(ScrollView.HeightRequestProperty);
            sv.ClearValue(ScrollView.IsVisibleProperty);
            sv.ClearValue(ScrollView.MarginProperty);
            sv.ClearValue(ScrollView.OpacityProperty);
            sv.ClearValue(ScrollView.PaddingProperty);
            sv.ClearValue(ScrollView.StyleProperty);
            sv.ClearValue(ScrollView.WidthRequestProperty);

            sv.ClearValue(ScrollView.VerticalOptionsProperty);
            sv.ClearValue(ScrollView.HorizontalOptionsProperty);
            sv.ClearValue(ScrollView.MinimumHeightRequestProperty);
            sv.ClearValue(ScrollView.MinimumWidthRequestProperty);
            sv.ClearValue(ScrollView.MaximumHeightRequestProperty);
            sv.ClearValue(ScrollView.MaximumWidthRequestProperty);
            sv.ClearValue(ScrollView.MarginProperty);
            sv.ClearValue(ScrollView.PaddingProperty);
            sv.ClearValue(ScrollView.ClassIdProperty);

            sv.ClearValue(ScrollView.HeightRequestProperty);
            sv.ClearValue(ScrollView.InputTransparentProperty);
            sv.ClearValue(ScrollView.InputTransparentProperty);
            sv.ClearValue(ScrollView.IsEnabledProperty);
            sv.ClearValue(ScrollView.RotationProperty);
            sv.ClearValue(ScrollView.RotationXProperty);
            sv.ClearValue(ScrollView.RotationYProperty);
            sv.ClearValue(ScrollView.ScaleProperty);
            sv.ClearValue(ScrollView.ScaleXProperty);
            sv.ClearValue(ScrollView.ScaleYProperty);

            sv.Content = null;
            sv.Parent = null;
            sv.StyleClass = null;
            sv.Margin = Thickness.Zero;


            if (Pooling == true && listScrollView.Count < 100 && StoreMode == true)
                listScrollView.Add(sv);
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("StoreScrollView: " + ex.Message, IGlobalData.protMode.crisp);
        }
    }
    public static void StoreIDButton(IDButton b, bool Pooling = true)
    {
        try
        {
            foreach (IDButton bx in listIDButton)
            {
                if (bx == b)
                {
                    return;
                }
            }

            b.ClearValue(Grid.ColumnProperty);
            b.ClearValue(Grid.RowProperty);
            b.ClearValue(IDButton.BackgroundColorProperty);
            b.ClearValue(IDButton.BackgroundProperty);
            b.ClearValue(IDButton.BindingContextProperty);
            b.ClearValue(IDButton.HeightRequestProperty);
            b.ClearValue(IDButton.IsVisibleProperty);
            b.ClearValue(IDButton.MarginProperty);
            b.ClearValue(IDButton.OpacityProperty);
            b.ClearValue(IDButton.PaddingProperty);
            b.ClearValue(IDButton.StyleProperty);
            b.ClearValue(IDButton.WidthRequestProperty);
            b.ClearValue(IDButton.TextColorProperty);

            b.FontFamily = null;
            b.ClearValue(IDButton.FontFamilyProperty);
            b.ClearValue(IDButton.VerticalOptionsProperty);
            b.ClearValue(IDButton.HorizontalOptionsProperty);
            b.ClearValue(IDButton.MinimumHeightRequestProperty);
            b.ClearValue(IDButton.MinimumWidthRequestProperty);
            b.ClearValue(IDButton.MaximumHeightRequestProperty);
            b.ClearValue(IDButton.MaximumWidthRequestProperty);
            b.ClearValue(IDButton.MarginProperty);
            b.ClearValue(IDButton.PaddingProperty);
            b.ClearValue(IDButton.FontSizeProperty);
            b.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(IDButton));
            b.ClearValue(IDButton.ClassIdProperty);

            b.Parent = null;

            b.ClearValue(IDButton.BorderColorProperty);
            b.ClearValue(IDButton.BorderWidthProperty);
            b.ClearValue(IDButton.CommandParameterProperty);
            b.ClearValue(IDButton.CommandProperty);
            b.ClearValue(IDButton.ContentLayoutProperty);
            b.ClearValue(IDButton.CornerRadiusProperty);
            b.ClearValue(IDButton.FontAttributesProperty);
            b.ClearValue(IDButton.HeightRequestProperty);
            b.ClearValue(IDButton.InputTransparentProperty);
            b.ClearValue(IDButton.InputTransparentProperty);
            b.ClearValue(IDButton.IsEnabledProperty);
            b.ClearValue(IDButton.RotationProperty);
            b.ClearValue(IDButton.RotationXProperty);
            b.ClearValue(IDButton.RotationYProperty);
            b.ClearValue(IDButton.ScaleProperty);
            b.ClearValue(IDButton.ScaleXProperty);
            b.ClearValue(IDButton.ScaleYProperty);
            b.ClearValue(IDButton.TextProperty);
            b.StyleClass = null;
            b.Margin = Thickness.Zero;
            b.Text = null;
            b.ClearValue(IDButton.LineBreakModeProperty);
            b.Padding = Thickness.Zero;




            if (Pooling == true && listIDButton.Count < 100 && StoreMode == true)
                listIDButton.Add(b);
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("StoreIDButton: " + ex.Message, IGlobalData.protMode.crisp);
        }
    }
    public static void StoreIDLabel(IDLabel l, bool Pooling = true)
    {
        try
        { 
            foreach (IDLabel lx in listIDLabel)
            {
                if (lx == l)
                {
                    return;
                }
            }

            l.ClearValue(Grid.ColumnProperty);
            l.ClearValue(Grid.RowProperty);
            l.ClearValue(IDLabel.BackgroundColorProperty);
        l.ClearValue(IDLabel.BackgroundProperty);
        l.ClearValue(IDLabel.BindingContextProperty);
        l.ClearValue(IDLabel.HeightRequestProperty);
        l.ClearValue(IDLabel.IsVisibleProperty);
        l.ClearValue(IDLabel.MarginProperty);
        l.ClearValue(IDLabel.OpacityProperty);
        l.ClearValue(IDLabel.PaddingProperty);
        l.ClearValue(IDLabel.StyleProperty);
        l.ClearValue(IDLabel.WidthRequestProperty);
        l.ClearValue(IDLabel.TextColorProperty);

        l.FontFamily = null;
        l.ClearValue(IDLabel.FontFamilyProperty);
        l.ClearValue(IDLabel.VerticalOptionsProperty);
        l.ClearValue(IDLabel.HorizontalOptionsProperty);
        l.ClearValue(IDLabel.MinimumHeightRequestProperty);
        l.ClearValue(IDLabel.MinimumWidthRequestProperty);
        l.ClearValue(IDLabel.MaximumHeightRequestProperty);
        l.ClearValue(IDLabel.MaximumWidthRequestProperty);
        l.ClearValue(IDLabel.MarginProperty);
        l.ClearValue(IDLabel.PaddingProperty);
        l.ClearValue(IDLabel.FontSizeProperty);
        l.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(IDLabel));
        l.ClearValue(IDLabel.ClassIdProperty);

        l.ClearValue(IDLabel.FontAttributesProperty);
        l.ClearValue(IDLabel.HeightRequestProperty);
        l.ClearValue(IDLabel.InputTransparentProperty);
        l.ClearValue(IDLabel.InputTransparentProperty);
        l.ClearValue(IDLabel.IsEnabledProperty);
        l.ClearValue(IDLabel.RotationProperty);
        l.ClearValue(IDLabel.RotationXProperty);
        l.ClearValue(IDLabel.RotationYProperty);
        l.ClearValue(IDLabel.ScaleProperty);
        l.ClearValue(IDLabel.ScaleXProperty);
        l.ClearValue(IDLabel.ScaleYProperty);
        l.ClearValue(IDLabel.TextProperty);
            l.ClearValue(IDLabel.LineBreakModeProperty);
            l.ClearValue(IDLabel.FormattedTextProperty);
            l.ClearValue(IDLabel.HorizontalTextAlignmentProperty);
            l.ClearValue(IDLabel.VerticalTextAlignmentProperty);
            l.ClearValue(IDLabel.HeightProperty);
            l.ClearValue(IDLabel.WidthProperty);

            l.Parent = null;
            l.StyleClass = null;
            l.Margin = Thickness.Zero;
            l.Text = null;
            l.Padding = Thickness.Zero;
            l.LineBreakMode = LineBreakMode.TailTruncation;


            if (Pooling == true && listIDLabel.Count < 100 && StoreMode == true)
                listIDLabel.Add(l);
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("StoreIDLabel: " + ex.Message, IGlobalData.protMode.crisp);
        }
    }
    public static void StoreButton(Button b, bool Pooling = true)
    {
        try
        { 
        foreach (Button bx in listButton)
        {
            if (bx == b)
            {
                return;
            }
        }
            b.ClearValue(Grid.ColumnProperty);
            b.ClearValue(Grid.RowProperty);
            b.ClearValue(Button.BackgroundColorProperty);
        b.ClearValue(Button.BackgroundProperty);
        b.ClearValue(Button.BindingContextProperty);
        b.ClearValue(Button.HeightRequestProperty);
        b.ClearValue(Button.IsVisibleProperty);
        b.ClearValue(Button.MarginProperty);
        b.ClearValue(Button.OpacityProperty);
        b.ClearValue(Button.PaddingProperty);
        b.ClearValue(Button.StyleProperty);
        b.ClearValue(Button.WidthRequestProperty);
        b.ClearValue(Button.TextColorProperty);

        b.FontFamily = null;
        b.ClearValue(Button.FontFamilyProperty);
        b.ClearValue(Button.VerticalOptionsProperty);
        b.ClearValue(Button.HorizontalOptionsProperty);
        b.ClearValue(Button.MinimumHeightRequestProperty);
        b.ClearValue(Button.MinimumWidthRequestProperty);
        b.ClearValue(Button.MaximumHeightRequestProperty);
        b.ClearValue(Button.MaximumWidthRequestProperty);
        b.ClearValue(Button.MarginProperty);
        b.ClearValue(Button.PaddingProperty);
        b.ClearValue(Button.FontSizeProperty);
        b.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button));
        b.ClearValue(Label.ClassIdProperty);
        b.Parent = null;

        b.ClearValue(Button.BorderColorProperty);
        b.ClearValue(Button.BorderWidthProperty);
        b.ClearValue(Button.CommandParameterProperty);
        b.ClearValue(Button.CommandProperty);
        b.ClearValue(Button.ContentLayoutProperty);
        b.ClearValue(Button.CornerRadiusProperty);
        b.ClearValue(Button.FontAttributesProperty);
        b.ClearValue(Button.HeightRequestProperty);
        b.ClearValue(Button.InputTransparentProperty);
        b.ClearValue(Button.InputTransparentProperty);
        b.ClearValue(Button.IsEnabledProperty);
        b.ClearValue(Button.RotationProperty);
        b.ClearValue(Button.RotationXProperty);
        b.ClearValue(Button.RotationYProperty);
        b.ClearValue(Button.ScaleProperty);
        b.ClearValue(Button.ScaleXProperty);
        b.ClearValue(Button.ScaleYProperty);
        b.ClearValue(Button.TextProperty);
            b.ClearValue(Button.LineBreakModeProperty);
            b.Padding = Thickness.Zero;

            b.StyleClass = null;
            b.Margin = Thickness.Zero;
            b.Text = null;

            if (Pooling == true && listButton.Count < 100 && StoreMode == true)
                listButton.Add(b);
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("StoreButton: " + ex.Message, IGlobalData.protMode.crisp);
        }
    }
    public static void StoreLabel(Label l, bool Pooling = true )
    {
        try
        {
            foreach (Label lx in listLabel)
            {
                if (lx == l)
                {
                    return;
                }
            }


            if (l.FontSize != 14)
            {
            }
            else if (l.Height != 17.5)
            {
            }

            l.ClearValue(Grid.ColumnProperty);
            l.ClearValue(Grid.RowProperty);
            l.ClearValue(Label.BackgroundColorProperty);
            l.ClearValue(Label.BackgroundProperty);
            l.ClearValue(Label.BindingContextProperty);
            l.ClearValue(Label.HeightRequestProperty);
            l.ClearValue(Label.IsVisibleProperty);
            l.ClearValue(Label.MarginProperty);
            l.ClearValue(Label.OpacityProperty);
            l.ClearValue(Label.PaddingProperty);
            l.ClearValue(Label.StyleProperty);
            l.ClearValue(Label.WidthRequestProperty);
            l.ClearValue(Label.TextColorProperty);

            l.FontFamily = null;
            l.ClearValue(Label.FontFamilyProperty);
            l.ClearValue(Label.VerticalOptionsProperty);
            l.ClearValue(Label.HorizontalOptionsProperty);
            l.ClearValue(Label.MinimumHeightRequestProperty);
            l.ClearValue(Label.MinimumWidthRequestProperty);
            l.ClearValue(Label.MaximumHeightRequestProperty);
            l.ClearValue(Label.MaximumWidthRequestProperty);
            l.ClearValue(Label.MarginProperty);
            l.ClearValue(Label.PaddingProperty);
            l.ClearValue(Label.FontSizeProperty);
            l.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label));
            l.ClearValue(Label.ClassIdProperty);
            l.Parent = null;

            l.ClearValue(Label.FontAttributesProperty);
            l.ClearValue(Label.HeightRequestProperty);
            l.ClearValue(Label.HeightProperty);
            l.ClearValue(Label.InputTransparentProperty);
            l.ClearValue(Label.InputTransparentProperty);
            l.ClearValue(Label.IsEnabledProperty);
            l.ClearValue(Label.RotationProperty);
            l.ClearValue(Label.RotationXProperty);
            l.ClearValue(Label.RotationYProperty);
            l.ClearValue(Label.ScaleProperty);
            l.ClearValue(Label.ScaleXProperty);
            l.ClearValue(Label.ScaleYProperty);
            l.ClearValue(Label.TextProperty);
            l.ClearValue(Label.LineBreakModeProperty);
            l.ClearValue(Label.FormattedTextProperty);
            l.ClearValue(Label.HorizontalTextAlignmentProperty);
            l.ClearValue(Label.VerticalTextAlignmentProperty);
            l.ClearValue(Label.HeightProperty);
            l.ClearValue(Label.WidthProperty);
            l.Padding = Thickness.Zero;


            l.WidthRequest = -1;
            l.HeightRequest = -1;
            l.StyleClass = null;
            l.Margin = Thickness.Zero;

            l.Text = null;


            if (Pooling == true && listLabel.Count < 100 && StoreMode == true)
                listLabel.Add(l);


         }
        catch (Exception ex)
        {
            GlobalData.AddLog("StoreLabel: " + ex.Message, IGlobalData.protMode.crisp);
        }
    }
    public static Grid NewGrid()
    {
 
        if (listGrid.Count  > 2000)
        {
        }

        if ( listGrid.Count > 0)
        {
            Grid g2 = listGrid[0];
            listGrid.RemoveAt(0);
            g2.IsVisible = true;
            g2.WidthRequest = -1;

            g2.ColumnDefinitions.Clear();
            g2.RowDefinitions.Clear();
            g2.ClearValue(Grid.ColumnDefinitionsProperty);
            g2.ClearValue(Grid.RowDefinitionsProperty );

            g2.ClearValue(TreeView.BackgroundColorProperty);
            g2.BackgroundColor = Colors.Transparent;
            g2.ClearValue(TreeView.BackgroundProperty);
            g2.Background = Colors.Transparent;
            LayoutOptions lo = LayoutOptions.Fill;
            g2.VerticalOptions = lo;
            g2.ClearValue(Grid.VerticalOptionsProperty);
            g2.HorizontalOptions = lo;
            g2.ClearValue(Grid.HorizontalOptionsProperty);
            g2.HeightRequest = -1;
            g2.WidthRequest = -1;
            g2.ClearValue(Grid.WidthRequestProperty);
            g2.ClearValue(Grid.HeightRequestProperty);
            g2.Parent = null;

            g2.Clear();

            return g2;
        }
        Grid g = new();
        return g;
    }
    public static ScrollView NewScrollView()
    {
        if (listScrollView.Count > 2000)
        {
        }

        if (listScrollView.Count > 0)
        {
            ScrollView sv2 = listScrollView[0];
            listScrollView.RemoveAt(0);
            sv2.IsVisible = true;
            sv2.WidthRequest = -1;

            sv2.ClearValue(Grid.ColumnDefinitionsProperty);
            sv2.ClearValue(Grid.RowDefinitionsProperty);

            sv2.ClearValue(TreeView.BackgroundColorProperty);
            sv2.BackgroundColor = Colors.Transparent;
            sv2.ClearValue(TreeView.BackgroundProperty);
            sv2.Background = Colors.Transparent;
            LayoutOptions lo = LayoutOptions.Fill;
            sv2.VerticalOptions = lo;
            sv2.ClearValue(Grid.VerticalOptionsProperty);
            sv2.HorizontalOptions = lo;
            sv2.ClearValue(Grid.HorizontalOptionsProperty);
            sv2.HeightRequest = -1;
            sv2.WidthRequest = -1;
            sv2.ClearValue(Grid.WidthRequestProperty);
            sv2.ClearValue(Grid.HeightRequestProperty);
            sv2.Parent = null;

            return sv2;
        }
        ScrollView sv = new();
        return sv;
    }
    public static VerticalStackLayout NewVerticalStackLayout()
    {
        if (listVerticalStackLayout.Count > 2000)
        {
        }

        if (listVerticalStackLayout.Count > 0)
        {
            VerticalStackLayout vsl2 = listVerticalStackLayout[0];
            listVerticalStackLayout.RemoveAt(0);
            vsl2.IsVisible = true;
            vsl2.WidthRequest = -1;

            vsl2.ClearValue(Grid.ColumnDefinitionsProperty);
            vsl2.ClearValue(Grid.RowDefinitionsProperty);

            vsl2.ClearValue(TreeView.BackgroundColorProperty);
            vsl2.BackgroundColor = Colors.Transparent;
            vsl2.ClearValue(TreeView.BackgroundProperty);
            vsl2.Background = Colors.Transparent;
            LayoutOptions lo = LayoutOptions.Fill;
            vsl2.VerticalOptions = lo;
            vsl2.ClearValue(Grid.VerticalOptionsProperty);
            vsl2.HorizontalOptions = lo;
            vsl2.ClearValue(Grid.HorizontalOptionsProperty);
            vsl2.HeightRequest = -1;
            vsl2.WidthRequest = -1;
            vsl2.ClearValue(Grid.WidthRequestProperty);
            vsl2.ClearValue(Grid.HeightRequestProperty);
            vsl2.Parent = null;

            vsl2.Clear();

            return vsl2;
        }
        VerticalStackLayout vsl = new();
        return vsl;
    }
    public static TreeView NewTreeView()
    {
        // return new TreeView();
        if ( listTreeView.Count > 0)
        {
            TreeView tv2 = listTreeView[0];
            listTreeView.RemoveAt(0);
            tv2.IsVisible = true;
            tv2.IsEnabled = true;
            tv2._currentTreeState = TreeViewItem.TreeState.closed;

            tv2.ClearValue(TreeView.BackgroundColorProperty);
            tv2.BackgroundColor = Colors.Transparent;
            tv2.ClearValue(TreeView.BackgroundProperty);
            tv2.Background = Colors.Transparent;
            tv2.ColumnDefinitions.Clear();
            tv2.RowDefinitions.Clear();
            tv2.ClearValue(Grid.ColumnDefinitionsProperty);
            tv2.ClearValue(Grid.RowDefinitionsProperty);

            LayoutOptions lo = LayoutOptions.Fill;
            tv2.VerticalOptions = lo;
            tv2.ClearValue(Grid.VerticalOptionsProperty);
            tv2.HorizontalOptions = lo;
            tv2.ClearValue(Grid.HorizontalOptionsProperty);

            tv2.HeightRequest = -1;
            tv2.WidthRequest = -1;
            tv2.ClearValue(Grid.WidthRequestProperty);
            tv2.ClearValue(Grid.HeightRequestProperty);
            tv2.Parent = null;

            tv2.Clear();
            return tv2;
        }
        TreeView tv = new();
        return tv;
    }
    public static TreeViewItem NewTreeViewItem()
    {
        // return new TreeViewItem();

        if ( listTreeViewItem.Count > 0)
        {
            TreeViewItem tvi2 = listTreeViewItem[0];
            listTreeViewItem.RemoveAt(0);
            tvi2.IsVisible = true;
            tvi2.IsEnabled = true;
            tvi2._currentTreeState = TreeViewItem.TreeState.closed;

            tvi2.ClearValue(TreeView.BackgroundColorProperty);
            tvi2.BackgroundColor = Colors.Transparent;
            tvi2.ClearValue(TreeView.BackgroundProperty);
            tvi2.Background = Colors.Transparent;
            tvi2.ColumnDefinitions.Clear();
            tvi2.RowDefinitions.Clear();
            tvi2.ClearValue(Grid.ColumnDefinitionsProperty);
            tvi2.ClearValue(Grid.RowDefinitionsProperty);

            LayoutOptions lo = LayoutOptions.Fill;
            tvi2.VerticalOptions = lo;
            tvi2.ClearValue(Grid.VerticalOptionsProperty);
            tvi2.HorizontalOptions = lo;
            tvi2.ClearValue(Grid.HorizontalOptionsProperty);

            tvi2.HeightRequest = -1;
            tvi2.WidthRequest = -1;
            tvi2.ClearValue(Grid.WidthRequestProperty);
            tvi2.ClearValue(Grid.HeightRequestProperty);
            tvi2.Parent = null;

            tvi2.Clear();

            return tvi2;
        }
        TreeViewItem tvi = new();
        return tvi;
    }
    public static IDButton NewIDButton()
    {
        if( listIDButton.Count > 0)
        {
            IDButton? b2 = listIDButton[0];
            if (b2 == null)
            {

            }
            listIDButton.RemoveAt(0);
            b2!.IsVisible = true;
            b2!.Opacity = 1;
            b2!.ClearValue( Button.OpacityProperty);
            b2!.ClearValue(Button.BackgroundColorProperty);
            // b2.BackgroundColor = Colors.Transparent;
            b2!.ClearValue(Button.BackgroundProperty);
            b2.Background = Colors.Transparent;
            b2!.FontFamily = null;
            b2!.ClearValue( Button.FontFamilyProperty);

            LayoutOptions lo = LayoutOptions.Fill;
            b2!.VerticalOptions = lo;
            b2!.ClearValue(Grid.VerticalOptionsProperty);
            b2!.HorizontalOptions = lo;
            b2!.ClearValue(Grid.HorizontalOptionsProperty);
            b2!.ClearValue(Label.MaximumWidthRequestProperty);

            b2!.ClearValue(Label.MarginProperty);
            b2!.ClearValue(Label.PaddingProperty);
            b2!.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button));
            b2!.ClearValue(Label.FontSizeProperty);
            b2!.ClearValue(Label.StyleProperty);
            b2!.ClearValue(Label.ClassIdProperty);

            b2!.HeightRequest = -1;
            b2!.WidthRequest = -1;
            b2!.ClearValue(Grid.WidthRequestProperty);
            b2!.ClearValue(Grid.HeightRequestProperty);
            b2!.Parent = null;

            return b2;
        }
        IDButton b = new();
        return b;
    }
    public static Button NewButton()
    {
        if (listButton.Count > 0)
        {
            Button? b2 = listButton[0];
            if (b2 == null)
            {

            }
            listButton.RemoveAt(0);
            b2!.IsVisible = true;
            b2!.Opacity = 1;
            b2!.ClearValue( Button.BackgroundColorProperty);
            b2!.ClearValue(Button.BackgroundProperty);
            b2!.Background = Colors.Transparent;
            b2!.FontFamily = null;
            b2!.ClearValue(Button.FontFamilyProperty);

            LayoutOptions lo = LayoutOptions.Fill;
            b2!.VerticalOptions = lo;
            b2!.ClearValue(Grid.VerticalOptionsProperty);
            b2!.HorizontalOptions = lo;
            b2!.ClearValue(Grid.HorizontalOptionsProperty);
            b2!.ClearValue(Label.MaximumWidthRequestProperty );

            b2!.ClearValue(Label.MarginProperty);
            b2!.ClearValue(Label.PaddingProperty);
            b2!.ClearValue(Label.FontSizeProperty);
            b2!.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Button));
            b2!.ClearValue(Label.StyleProperty);
            b2!.ClearValue(Label.ClassIdProperty);

            b2!.HeightRequest = -1;
            b2!.WidthRequest = -1;
            b2!.ClearValue(Grid.WidthRequestProperty);
            b2!.ClearValue(Grid.HeightRequestProperty);
            b2!.Parent = null;

            // (b2.Background as Microsoft.Maui.Controls.ImmutableBrush).Color = null;
            b2!.TextColor = Colors.White;
            b2!.StyleClass = null;
            // b2.BackgroundColor = Colors.Transparent;
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

            l2.ClearValue(Label.BackgroundColorProperty);
            // l2.BackgroundColor = Colors.Transparent;
            l2.ClearValue(Label.BackgroundProperty);
            // l2.Background = Colors.Transparent;
            l2.FontFamily = null;
            l2.ClearValue(Label.FontFamilyProperty);

            LayoutOptions lo = LayoutOptions.Fill;
            l2.VerticalOptions = lo;
            l2.ClearValue(Grid.VerticalOptionsProperty);
            l2.HorizontalOptions = lo;
            l2.ClearValue(Grid.HorizontalOptionsProperty);
            l2.ClearValue(Label.MaximumWidthRequestProperty);

            l2.ClearValue(Label.MarginProperty);
            l2.ClearValue(Label.PaddingProperty);
            l2.ClearValue(Label.FontSizeProperty);
            l2.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label));
            l2.ClearValue(Label.StyleProperty);
            l2.ClearValue(Label.ClassIdProperty);

            l2.HeightRequest = -1;
            l2.WidthRequest = -1;
            l2.ClearValue(Grid.WidthRequestProperty);
            l2.ClearValue(Grid.HeightRequestProperty);
            l2.Parent = null;

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

            l2.ClearValue(Label.BackgroundColorProperty);
            // l2.BackgroundColor = Colors.Transparent;
            l2.ClearValue(Label.BackgroundProperty);
            // l2.Background = Colors.Transparent;
            l2.FontFamily = null;
            l2.ClearValue(Label.FontFamilyProperty);

            LayoutOptions lo = LayoutOptions.Fill;
            l2.VerticalOptions = lo;
            l2.ClearValue(Grid.VerticalOptionsProperty);
            l2.HorizontalOptions = lo;
            l2.ClearValue(Grid.HorizontalOptionsProperty);

            l2.ClearValue(Label.MaximumWidthRequestProperty);

            l2.ClearValue(Label.MarginProperty);
            l2.ClearValue(Label.PaddingProperty);
            l2.ClearValue(Label.FontSizeProperty);
            l2.FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label));
            l2.ClearValue(Label.StyleProperty);
            l2.ClearValue(Label.ClassIdProperty);

            l2.HeightRequest = -1;
            l2.WidthRequest = -1;
            l2.ClearValue(Grid.WidthRequestProperty);
            l2.ClearValue(Grid.HeightRequestProperty);
            l2.Parent = null;

            return l2;
        }
        Label l = new();
        return l;
    }

    private static List<string>? Button_NoBackground_NoBorder = null;
    private static List<string>? Label_Normal = null;
    private static List<string>? Label_Normal_Inactive = null;

    public static List<string> Get_Button_NoBackground_NoBorder()
    {
        if (Button_NoBackground_NoBorder == null || Button_NoBackground_NoBorder.Count == 0 )
        {
            List<string> s1 = new();
            s1.Add("Button_NoBackground_NoBorder");
            Button_NoBackground_NoBorder = s1; 
        }
        return Button_NoBackground_NoBorder;
    }
    public static List<string> Get_Label_Normal()
    {
        if (Label_Normal == null || Label_Normal.Count == 0)
        {
            List<string> s1 = new();
            s1.Add("Label_Normal");
            Label_Normal = s1;
        }
        return Label_Normal;
    }
    public static List<string> Get_Label_Normal_Inactive()
    {
        if (Label_Normal_Inactive == null || Label_Normal_Inactive.Count == 0)
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

    public new void ResetTreeViewItem()
    {
        OTCallback = null;
        OTClick = null;
        OrderTableCallback = null;

        base.ResetTreeViewItem();
    }


    public static void EmptyTreeViewItem(  Microsoft.Maui.IView? tv, bool Pooling = true, bool DeleteInitialElement = true, bool InitialCall = false )
    {
        if( tv == null )
          return;

#if ANDROID
        int grefCountStart = Java.Interop.JniRuntime.CurrentRuntime.GlobalReferenceCount;
        int wgrefCountStart = Java.Interop.JniRuntime.CurrentRuntime.WeakGlobalReferenceCount;
#endif
        try
        {
            if (tv is TreeViewItem || tv is Grid || tv is TreeView || tv is OrderListView  )
            {
                Grid? tv2 = tv as Grid;

                foreach (IView iv in tv2!.Children)
                {
                    if (iv is OrderListView)
                    {
                        IView? tvi = iv as IView;
                        (iv as OrderListView)!.DisableToggleButton();

                        EmptyTreeViewItem(tvi);
                        (iv as OrderListView)!.ResetCursors();
                        (iv as OrderListView)!.Children.Clear();
                        (iv as OrderListView)!.Parent = null;
                        // (iv as OrderListView)!.Handler = null;
                        (iv as OrderListView)!.OrderListTable = null;

                        if ((iv as OrderListView)!.StyleClass != null)
                            (iv as OrderListView)!.StyleClass.Clear();

                        (iv as OrderListView)!.Clear();

                        // UIElement.StoreOrderListView(tvi as OrderListView, Pooling);
                    }
                    else if (iv is TreeViewItem)
                    {
                        IView? tvi = iv as IView;
                        (iv as TreeViewItem)!.DisableToggleButton();

                        EmptyTreeViewItem(tvi);

                        (iv as TreeViewItem)!.ResetCursors();
                        (iv as TreeViewItem)!.Children.Clear();
                        (iv as TreeViewItem)!.Parent = null;
                        // (iv as TreeViewItem)!.Handler = null;
                        (iv as TreeViewItem)!.OrderListTable = null;

                        if ((iv as TreeViewItem)!.StyleClass != null)
                            (iv as TreeViewItem)!.StyleClass.Clear();

                        (iv as TreeViewItem)!.Clear();

                        // UIElement.StoreTreeViewItem(tvi as TreeViewItem, Pooling);

                    }
                    else if (iv is Grid)
                    {
                        Grid? tvi = iv as Grid;

                        EmptyTreeViewItem(tvi!);

                        tvi!.ResetCursors();
                        tvi!.Children.Clear();
                        tvi!.Parent = null;
                        // tvi!.Handler = null;

                        if ((iv as Grid)!.StyleClass != null)
                            (iv as Grid)!.StyleClass.Clear();

                        (iv as Grid)!.Clear();
                        // UIElement.StoreGrid(tvi as Grid, Pooling);
                    }
                    else if (iv is ScrollView)
                    {
                        ScrollView? sv = iv as ScrollView;

                        EmptyTreeViewItem(sv!.Content);

                        sv.ResetCursors();
                        sv.Content = null;
                        sv.Parent = null;
                        // sv.Handler = null;

                        if ((iv as ScrollView)!.StyleClass != null)
                            (iv as ScrollView)!.StyleClass.Clear();

                        // (iv as ScrollView).Clear();
                        // UIElement.StoreScrollView(sv as ScrollView, Pooling);
                    }
                    else if (iv is VerticalStackLayout)
                    {
                        VerticalStackLayout? vsl = iv as VerticalStackLayout;

                        EmptyTreeViewItem(vsl!);
                        vsl!.ResetCursors();

                        vsl!.Parent = null;
                        // vsl!.Handler = null;

                        if ((iv as VerticalStackLayout)!.StyleClass != null)
                            (iv as VerticalStackLayout)!.StyleClass.Clear();

                        (iv as VerticalStackLayout)!.Clear();

                        // UIElement.StoreVerticalStackLayout(vsl as VerticalStackLayout, Pooling);
                    }
                     else if (iv is Label)
                    {
                        Label l1 = (Label)iv;

                        while (l1.Behaviors.Count > 0)
                        {
                            if(l1.Behaviors[0].GetType() == typeof( TouchBehavior) )
                            {
                                TouchBehavior tb = (l1.Behaviors[0] as TouchBehavior);
                                tb.ClearValue(TouchBehavior.HoveredOpacityProperty);
                                tb.ClearValue(TouchBehavior.PressedOpacityProperty);

                            }
                            l1.Behaviors[0].ClearValue(Behavior.BindingContextProperty);
                            l1.Behaviors[0].BindingContext = null;
                            l1.Behaviors.RemoveAt(0);
                            destroyed++;

                        }

                        Behavior toRemove = l1.Behaviors.FirstOrDefault(b => b is MyTouchBehavior);
                        if (toRemove != null)
                        {
                            l1.Behaviors.Remove(toRemove);
                        }

                        if ( l1.Behaviors.Count > 0 )
                        {
                            l1.Behaviors.RemoveAt(0);
                        }

                        l1.Behaviors.Clear();

                        l1.ResetCursors();

                        while (l1.GestureRecognizers.Count > 0)
                        {
                            // bool removeEntry = true;
                            if (l1.GestureRecognizers[0] is TapGestureRecognizer)
                            {
                                if( iv.GetType().Name == "IDLabel")
                                {
                                    (iv as IDLabel)!.Reset();
                                    // removeEntry = false;

                                }
                                else if ( ( iv as IDLabel ) != null )
                                {
                                    (iv as IDLabel)!.Reset();
                                    // removeEntry = false;
                                }

                                // UIElement.RemoveEventHandler((l1.GestureRecognizers[0] as TapGestureRecognizer), (l1.GestureRecognizers[0] as TapGestureRecognizer).Tapped);
                                (l1.GestureRecognizers[0] as TapGestureRecognizer)!.Command = null;
                                (l1.GestureRecognizers[0] as TapGestureRecognizer)!.Parent = null;
                                (l1.GestureRecognizers[0] as TapGestureRecognizer)!.ClearValue(TapGestureRecognizer.CommandProperty);
                            }
                            else if (l1.GestureRecognizers[0] is PointerGestureRecognizer)
                            {
                                (l1.GestureRecognizers[0] as PointerGestureRecognizer)!.Parent = null;

                                /*
                                foreach (var handler in (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerEntered)
                                {
                                }
                                */
                                
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

                        UIElement.StoreLabel(l1 as Label, Pooling);
                    }
                    else if (iv is Button)
                    {
                        Button l1 = (Button)iv;

                        while (l1.Behaviors.Count > 0)
                        {
                            if (l1.Behaviors[0].GetType() == typeof(MyTouchBehavior))
                            {
                                MyTouchBehavior tb = (l1.Behaviors[0] as MyTouchBehavior);
                                tb.ClearValue(MyTouchBehavior.HoveredOpacityProperty);
                                tb.ClearValue(MyTouchBehavior.PressedOpacityProperty);

                            }

                            l1.Behaviors[0].ClearValue(MyTouchBehavior.BindingContextProperty);
                            l1.Behaviors[0].BindingContext = null;
                            l1.Behaviors.RemoveAt(0);
                            destroyed++;

                        }
                        l1.Behaviors.Clear();
                        l1.ResetCursors();
                        while (l1.GestureRecognizers.Count > 0)
                        {
                            if (l1.GestureRecognizers[0] is TapGestureRecognizer)
                            {
                                (l1.GestureRecognizers[0] as TapGestureRecognizer)!.Command = null;
                                (l1.GestureRecognizers[0] as TapGestureRecognizer)!.Parent = null;
                                (l1.GestureRecognizers[0] as TapGestureRecognizer)!.ClearValue(TapGestureRecognizer.CommandProperty);
                            }
                            else if (l1.GestureRecognizers[0] is PointerGestureRecognizer)
                            {
                                (l1.GestureRecognizers[0] as PointerGestureRecognizer)!.Parent = null;
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
                        UIElement.StoreButton(l1 as Button, Pooling);
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

                    if (tv2.Behaviors[0].GetType() == typeof(MyTouchBehavior))
                    {
                        MyTouchBehavior tb = (tv2.Behaviors[0] as MyTouchBehavior);
                        tb.ClearValue(MyTouchBehavior.HoveredOpacityProperty);
                        tb.ClearValue(MyTouchBehavior.PressedOpacityProperty);

                    }

                    tv2.Behaviors[0].ClearValue(Behavior.BindingContextProperty);
                    tv2.Behaviors[0].BindingContext = null;
                    tv2.Behaviors.RemoveAt(0);
                    destroyed++;

                }
                tv2.Behaviors.Clear();
                while (tv2.GestureRecognizers.Count > 0)
                {
                    if (tv2.GestureRecognizers[0] is TapGestureRecognizer)
                    {
                        (tv2.GestureRecognizers[0] as TapGestureRecognizer)!.Command = null;
                        (tv2.GestureRecognizers[0] as TapGestureRecognizer)!.Parent = null;
                        (tv2.GestureRecognizers[0] as TapGestureRecognizer)!.ClearValue(TapGestureRecognizer.CommandProperty);
                    }
                    else if (tv2.GestureRecognizers[0] is PointerGestureRecognizer)
                    {
                        (tv2.GestureRecognizers[0] as PointerGestureRecognizer)!.Parent = null;
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

                if( DeleteInitialElement == false )
                {

                }
                else if( tv is OrderListView)
                {
                    OrderListView? tv3 = tv as OrderListView;
                    try
                    {
                        tv3!.ResetOrderListView();
                        tv3!.DisableToggleButton();
                        tv3!.OrderListTable = null;
                        tv3!.OrderTable = null;
                        tv3!.CurrentOrderListTable = null;
                        tv3!.UserDefinedObject = null;
                        tv3!.Text = null;
                        tv3!.Parent = null;
                        tv3!.ResetTreeViewItem();
                        tv3!.ColumnDefinitions.Clear();
                        tv3!.RowDefinitions.Clear();
                        // tv3!.ClickedEventCommand = null;
                        tv3!.TextButton = null;
                        tv3!.TextLabel = null;
                        // tv3!.Handler = null;
                        if (tv3!.StyleClass != null)
                            tv3!.StyleClass.Clear();

                        tv3!.Clear();
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message;
                        GlobalData.AddLog("EmptyTreeViewItem: " + s, IGlobalData.protMode.crisp);
                    }

                }
                else if (tv is TreeView)
                {
                    TreeView? tv3 = tv as TreeView;
                    try
                    {
                        tv3!.DisableToggleButton();
                        tv3!.OrderListTable = null;
                        tv3!.OrderTable = null;
                        tv3!.CurrentOrderListTable = null;
                        tv3!.UserDefinedObject = null;
                        tv3!.Text = null;
                        tv3!.Parent = null;
                        tv3!.ResetTreeViewItem();
                        tv3!.ColumnDefinitions.Clear();
                        tv3!.RowDefinitions.Clear();
                        // tv3!.ClickedEventCommand = null;
                        tv3!.TextButton = null;
                        tv3!.TextLabel = null;
                        // tv3!.Handler = null;
                        if (tv3!.StyleClass != null)
                            tv3!.StyleClass.Clear();


                        tv3!.OTCallback = null;
                        tv3!.OTClick = null;
                        tv3!.OrderTableCallback = null;

                        tv3!.Clear();
                        UIElement.StoreTreeView(tv3, Pooling);
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message;
                        GlobalData.AddLog("EmptyTreeViewItem: " + s, IGlobalData.protMode.crisp);
                    }
                }
                else if (tv is TreeViewItem)
                {
                    TreeViewItem? tv3 = tv as TreeViewItem;
                    try
                    {
                        tv3!.DisableToggleButton();
                        tv3!.OrderListTable = null;
                        tv3!.OrderTable = null;
                        tv3!.CurrentOrderListTable = null;
                        tv3!.UserDefinedObject = null;
                        tv3!.Text = null;
                        tv3!.Parent = null;
                        tv3!.ResetTreeViewItem();
                        tv3!.ColumnDefinitions.Clear();
                        tv3!.RowDefinitions.Clear();
                        tv3!.TextButton = null;
                        tv3!.TextLabel = null;
                        // tv3!.Handler = null;
                        if (tv3!.StyleClass != null)
                            tv3!.StyleClass.Clear();

                        tv3!.ResetCursors();
                        tv3!.Clear();
                        UIElement.StoreTreeViewItem(tv3, Pooling);
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message;
                        GlobalData.AddLog("EmptyTreeViewItem: " + s, IGlobalData.protMode.crisp);
                    }
                }
                else if (tv is Grid)
                {
                    Grid g3 = (tv as Grid)!;
                    g3.ColumnDefinitions.Clear();
                    g3.RowDefinitions.Clear();
                    g3.Parent = null;
                    // g3.Handler = null;
                    if (g3.StyleClass != null)
                        g3.StyleClass.Clear();

                                        g3.ResetCursors();

                    g3.Clear();

                    UIElement.StoreGrid(g3, Pooling);
                }
                else
                {
                    GlobalData.AddLog("Nicht ausgewertet: " + tv.GetType().ToString(), IGlobalData.protMode.crisp);

                }


            }
            else if ( tv is VerticalStackLayout )
            {
                VerticalStackLayout? tv2 = tv as VerticalStackLayout;

                foreach (IView iv in tv2!.Children)
                {
                    IView? vsl = iv as IView;

                    EmptyTreeViewItem(vsl);

                    // vsl.Parent = null;
                    // vsl.Handler = null;

 
                        // UIElement.StoreVerticalStackLayout(vsl as VerticalStackLayout, Pooling);
                }
                tv2.Children.Clear();
                while (tv2.Behaviors.Count > 0)
                {
                    GlobalData.AddLog("Ausgewertet: " + tv2.GetType().ToString(), IGlobalData.protMode.crisp);
                    if (tv2.Behaviors[0].GetType() == typeof(MyTouchBehavior))
                    {
                        MyTouchBehavior tb = (tv2.Behaviors[0] as MyTouchBehavior);
                        tb.ClearValue(MyTouchBehavior.HoveredOpacityProperty);
                        tb.ClearValue(MyTouchBehavior.PressedOpacityProperty);

                    }
                    tv2.Behaviors[0].ClearValue(Behavior.BindingContextProperty);
                    tv2.Behaviors[0].BindingContext = null;
                    tv2.Behaviors.RemoveAt(0);
                    destroyed++;

                }
                tv2.Behaviors.Clear();
                tv2.ResetCursors();
                while (tv2.GestureRecognizers.Count > 0)
                {
                    if (tv2.GestureRecognizers[0] is TapGestureRecognizer)
                    {
                        (tv2.GestureRecognizers[0] as TapGestureRecognizer)!.Command = null;
                        (tv2.GestureRecognizers[0] as TapGestureRecognizer)!.Parent = null;
                        (tv2.GestureRecognizers[0] as TapGestureRecognizer)!.ClearValue(TapGestureRecognizer.CommandProperty);
                    }
                    else if (tv2.GestureRecognizers[0] is PointerGestureRecognizer)
                    {
                        (tv2.GestureRecognizers[0] as PointerGestureRecognizer)!.Parent = null;

                        /*
                        foreach (var handler in (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerEntered)
                        {
                        }
                        */
                    }
                    else
                        destroyed += 0;

                    tv2.GestureRecognizers.RemoveAt(0);
                    destroyed++;

                }
                tv2.GestureRecognizers.Clear();
                if (tv2.StyleClass != null)
                    tv2.StyleClass.Clear();

                if (DeleteInitialElement == false)
                {

                }

            }
            else if ( tv is ScrollView )
            {
                ScrollView? tv2 = tv as ScrollView;


                EmptyTreeViewItem(tv2!.Content);

                tv2!.Parent = null;
                // tv2!.Handler = null;

                if (tv2!.StyleClass != null)
                    tv2!.StyleClass.Clear();

                    // UIElement.StoreVerticalStackLayout(vsl as VerticalStackLayout, Pooling);
                while (tv2!.Behaviors.Count > 0)
                {
                    GlobalData.AddLog("Ausgewertet: " + tv2!.GetType().ToString(), IGlobalData.protMode.crisp);
                    if (tv2.Behaviors[0].GetType() == typeof(MyTouchBehavior))
                    {
                        MyTouchBehavior tb = (tv2.Behaviors[0] as MyTouchBehavior);
                        tb.ClearValue(MyTouchBehavior.HoveredOpacityProperty);
                        tb.ClearValue(MyTouchBehavior.PressedOpacityProperty);

                    }
                    tv2.Behaviors[0].BindingContext = null;
                    tv2.Behaviors.RemoveAt(0);
                    destroyed++;

                }
                tv2!.Behaviors.Clear();
                tv2!.ResetCursors();
                while (tv2!.GestureRecognizers.Count > 0)
                {
                    if (tv2!.GestureRecognizers[0] is TapGestureRecognizer)
                    {
                        (tv2!.GestureRecognizers[0] as TapGestureRecognizer)!.Command = null;
                        (tv2!.GestureRecognizers[0] as TapGestureRecognizer)!.Parent = null;
                        (tv2!.GestureRecognizers[0] as TapGestureRecognizer)!.ClearValue(TapGestureRecognizer.CommandProperty);
                    }
                    else if (tv2!.GestureRecognizers[0] is PointerGestureRecognizer)
                    {
                        (tv2.GestureRecognizers[0] as PointerGestureRecognizer)!.Parent = null;
                        /*
                           foreach (var handler in (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerEntered)
                           {
                           }
                           */
                    }
                    else
                        destroyed += 0;

                    tv2.GestureRecognizers.RemoveAt(0);
                    destroyed++;

                }
                tv2.GestureRecognizers.Clear();
                if (tv2.StyleClass != null)
                    tv2.StyleClass.Clear();

                if (DeleteInitialElement == false)
                {

                }

            }
            else if (tv is Label)
            {
                Label l1 = (Label)tv;

                while (l1.Behaviors.Count > 0)
                {
                    if (l1.Behaviors[0].GetType() == typeof(MyTouchBehavior))
                    {
                        MyTouchBehavior tb = (l1.Behaviors[0] as MyTouchBehavior);
                        tb.ClearValue(MyTouchBehavior.HoveredOpacityProperty);
                        tb.ClearValue(MyTouchBehavior.PressedOpacityProperty);

                    }

                    l1.Behaviors[0].BindingContext = null;
                    l1.Behaviors.RemoveAt(0);

                    destroyed++;
                }
                l1.Behaviors.Clear();
                l1.ResetCursors();

                while (l1.GestureRecognizers.Count > 0)
                {
                    if (l1.GestureRecognizers[0] is TapGestureRecognizer)
                    {
                        (l1!.GestureRecognizers[0] as TapGestureRecognizer)!.Command = null;
                        (l1!.GestureRecognizers[0] as TapGestureRecognizer)!.Parent = null;
                        (l1!.GestureRecognizers[0] as TapGestureRecognizer)!.ClearValue(TapGestureRecognizer.CommandProperty);
                    }
                    else if (l1.GestureRecognizers[0] is PointerGestureRecognizer)
                    {
                        (l1!.GestureRecognizers[0] as PointerGestureRecognizer)!.Parent = null;
                        /*
                         foreach (var handler in (l1.GestureRecognizers[0] as PointerGestureRecognizer).PointerEntered)
                         {
                         }
                         */
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
        /*
        int grefCountEnd= Java.Interop.JniRuntime.CurrentRuntime.GlobalReferenceCount;
        int wgrefCountEnd = Java.Interop.JniRuntime.CurrentRuntime.WeakGlobalReferenceCount;

        if ( grefCountEnd >= grefCountStart)
        {
            // GC.Collect();
            grefCountEnd = Java.Interop.JniRuntime.CurrentRuntime.GlobalReferenceCount;
            wgrefCountEnd = Java.Interop.JniRuntime.CurrentRuntime.WeakGlobalReferenceCount;
        }

        if (grefCountStart > 0 && InitialCall == true)
        {
            GlobalData.AddLog("EmptyTreeViewItem freed: Gref " + ( grefCountStart - grefCountEnd).ToString() + " von " + grefCountStart.ToString(), IGlobalData.protMode.crisp);
            GlobalData.AddLog("EmptyTreeViewItem freed: WGref " + (wgrefCountStart - wgrefCountEnd).ToString() + " von " + wgrefCountStart.ToString(), IGlobalData.protMode.crisp);
        }
        */
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
            g3.SetValue(Label.BackgroundColorProperty, Colors.Blue);

            Grid g4 = UIElement.NewGrid();
            g1.Add(g4);
            g1.SetColumn(g4, 1);
            g4.SetValue(Label.BackgroundColorProperty, Colors.Yellow);

            Button b1 = UIElement.NewButton();
           
            // b1.BackgroundColor = Colors.Green;
            b1.StyleClass = UIElement.Get_Button_NoBackground_NoBorder();  
            // b1.BackgroundColor = Colors.Red;
            b1.Text = FaSolid.CaretRight;
            b1.FontFamily = "Fa-Solid";
            b1.Clicked += ToggleTreeView;
            b1.WidthRequest = 20;
            ToggleButton = b1;
            g3.Add(b1);
            b1.SetCursorHand();
            b1.SetValue( Button.OpacityProperty, 1.0f);
            b1.Opacity = 1;
            b1.BorderWidth = 0;
            // b1.Background = Colors.Transparent;
            b1.HeightRequest = -1;
            b1.ClearValue(Button.HeightRequestProperty);
            b1.TextColor = Colors.Cyan;
            b1.SetValue(Label.BackgroundColorProperty, Colors.Green);
            // b1.FontSize = 20;
            b1.FontAttributes = FontAttributes.None;

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
            l1.HeightRequest = -1;
            l1.WidthRequest = -1;
            g4.Add(l1);
            TextLabel = l1;
            TapGestureRecognizer tgr = new();
            tgr.Command = ClickedEventCommand;
            l1.GestureRecognizers.Add(tgr);
            l1.Opacity = 1;
            l1.SetValue(Label.OpacityProperty, 1.0f);
            l1.TextColor = GlobalSpecs.CurrentGlobalSpecs.GetCurrentTheme()!.Col_FG;
            // l1.FontSize = 20;
            l1.FontAttributes = FontAttributes.None;

            // Debug
            // l1.BackgroundColor = Colors.Red;
            // l1.Background = Colors.Red;

            // l1.SetValue( Label.BackgroundColorProperty, Colors.Red);


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
            // g5.SetValue(Label.BackgroundColorProperty, Colors.Cyan);
            // g5.BackgroundColor = Colors.Cyan;

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
        { 
            if( TextLabel != null )
                TextLabel!.Text = CurrentOrderListTable.Name;
        }
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
    public TreeCallback? TreeCallback { get; set; }

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

    public ICommand? ClickedEventCommand { get; set; }
    private Object? _userDefinedObject;
    private ObservableCollection<OrderTable>? _orderTable;
    public Label? TextButton;
    public void ResetTreeViewItem()
    {
        OrderListTable = null;
        CurrentOrderListTable = null;

        TextLabel = null;
        ToggleButton = null;
        ParentSubTree = null;
        SubTree = null;
        PropertyChanged = null;
        TextButton = null;
        _orderTable = null;
        _userDefinedObject = null;
        UserDefinedObject = null;
        ClickedEvent = null;
        ClickedData = null;
        Clicked -= TreeCallback;

        TreeCallback = null;
        Clicked = null;
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
                    if(ParentSubTree != null)
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
        get
        {
            if( TextLabel != null )
                return TextLabel!.Text;
            else
            {
                return "";
            }
        }
        set
        {
            if (TextLabel != null)
            {
                TextLabel!.Text = value;
            }
            else
            {

            }
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
        ToggleButton!.Clicked -= ToggleTreeView;
        Clicked -= TreeCallback;
    }

    public void AddCallback( )
    {
        // OnClickedTree
    }

    // static TreeViewItem? lastNorth = null;

    public static bool CompareObjects(object obj1, object obj2)
    {
        try
        {
            if (obj1 == null || obj2 == null)
                return obj1 == obj2;

            Type type1 = obj1.GetType();
            Type type2 = obj2.GetType();

            if (type1 != type2)
                return false;

            PropertyInfo[] properties = type1.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object value1 = property.GetValue(obj1)!;
                object value2 = property.GetValue(obj2)!;

                if (value1 == null || value2 == null)
                {
                }
                else if (property.Name == "ClickedEventCommand")
                {

                }
                else if (property.Name == "ColumnDefinitions")
                {

                }
                else if (property.Name == "RowDefinitions")
                {

                }
                else if (property.Name == "Children")
                {

                }
                /*
                   else if (property.Name == "Command`1")
                   {

                   }
                   */

                else if (!object.Equals(value1, value2))
                    return false;
            }
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("CompareObjects: " + ex.Message, IGlobalData.protMode.crisp);
        }
        return true;
    }

    public void CalcToggles()
    {
        try
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
                                /*
                                tv1.TextLabel.ClearValue(Label.FontSizeProperty);

                                if (tv1.TextLabel.Text == "Gehe nach Norden")
                                {
                                    if (lastNorth != null)
                                    {
                                        CompareObjects(lastNorth, tv1);
                                    }
                                    lastNorth = tv1;

                                }
                                // tv1.Scale = 0;
                                // tv1.ScaleTo( 1 );
                                if (tv1.TextLabel.FontSize != 14)
                                {
                                }
                                */

                                tv1!.ToggleButton!.Rotation = 0;
                                tv1!.ToggleButton!.Opacity = 1;

                                if (tv1!.SubTree!.Children.Count > 0 || tv1!.OrderTable != null || tv1!.OrderListTable != null)
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
                        else
                        {
                        }

                        ix++;
                    }

                }
                else if (this.OrderTable != null || this.OrderListTable != null)
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
        catch (Exception ex)
        {
            GlobalData.AddLog("CalcToggles: " + ex.Message, IGlobalData.protMode.crisp);

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

    public static MyTouchBehavior? touchBehaviorB1 = null;
    public void SetupTreeViewItem()
    {
        RowDefinitionCollection Rows = new();
        RowDefinition rd1 = new();
        rd1.Height = GridLength.Auto;
        Rows.Add(rd1);
        RowDefinition rd2 = new();
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
        Columns.Add(cd1);
        ColumnDefinition cd2 = new();
        cd2.Width = new GridLength(5, GridUnitType.Star);
        Columns.Add(cd2);
        g1.ColumnDefinitions = Columns;

        Button b1 = UIElement.NewButton();
        b1.TextColor = GlobalSpecs.CurrentGlobalSpecs!.GetCurrentTheme()!.Col_FG;
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
        b1.SetValue(Button.OpacityProperty, 1.0f);
        b1.Background = Colors.Transparent;
        b1.HeightRequest = -1;
        b1.ClearValue(Button.HeightRequestProperty);
        // b1.FontSize = 24;
        b1.FontAttributes = FontAttributes.None;

        Label l1 = UIElement.NewLabel();
        l1.Text = "Labeltext";
        l1.StyleClass = UIElement.Get_Label_Normal();
        l1.VerticalOptions = LayoutOptions.Start;
        l1.HorizontalOptions = LayoutOptions.Start;
        l1.HorizontalTextAlignment = TextAlignment.Start;
        l1.LineBreakMode = LineBreakMode.TailTruncation;
        // l1.FontSize = 24;
        g1.SetColumn(l1, 1);
        g1.Add(l1);
        TextLabel = l1;
        l1.FontAttributes = FontAttributes.None;

        Thickness margin = new Thickness(0, GlobalSpecs.CurrentGlobalSpecs!.GetClickMarginPixel(), 0, GlobalSpecs.CurrentGlobalSpecs.GetClickMarginPixel());
        l1.Margin = margin;
        Thickness padding = new Thickness(5);
        l1.Padding = padding;


        l1.Opacity = 1;
        l1.SetValue(Label.OpacityProperty, 1.0f);
        l1.TextColor = GlobalSpecs.CurrentGlobalSpecs.GetCurrentTheme()!.Col_FG;
        l1.HeightRequest = -1;
        l1.WidthRequest = -1;
        // l1.DesiredSize = new Size(-1, -1);
        l1.ClearValue(IDLabel.HeightProperty);
        l1.ClearValue(IDLabel.WidthProperty);

#if WINDOWS
        MyTouchBehavior mtb = new MyTouchBehavior
        {
            HoveredOpacity = 0.7,
            PressedOpacity = 0.7

        };
        
        l1.Behaviors.Add(mtb);
#elif ANDROID
        int grefCount = Java.Interop.JniRuntime.CurrentRuntime.GlobalReferenceCount;
        if (grefCount < 10000)
        {
            TouchBehavior tb1 = new MyTouchBehavior
            {
                HoveredOpacity = 0.5,
                PressedOpacity = 0.5

            };
            l1.Behaviors.Add(tb1);
        }
#endif

        TapGestureRecognizer tgr = new();
        tgr.Command = ClickedEventCommand;
        l1.GestureRecognizers.Add(tgr);
        l1.SetCursorHand();


        ColumnDefinitionCollection Columns2 = new();
        ColumnDefinition cd3 = new();
        cd3.Width = new GridLength(20, GridUnitType.Absolute);
        Columns2.Add(cd3);

        ColumnDefinition cd4 = new();
        cd4.Width = new GridLength(5, GridUnitType.Star);
        Columns2.Add(cd4);
        g2.ColumnDefinitions = Columns2;

        Grid g5 = UIElement.NewGrid();
        g2.Add(g5);
        g2.SetColumn(g5, 1);

        SubTree = g5;
        ParentSubTree = g2;

        l1.HeightRequest = -1;
        l1.WidthRequest = -1;
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

        Grid g1 = UIElement.NewGrid();
        this.Add(g1);
        this.SetRow(g1, 0);

        Grid g2 = UIElement.NewGrid();
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
        b1.SetValue(Label.OpacityProperty, 1.0f);
        b1.BorderWidth = 0;
        b1.Background = Colors.Transparent;
        b1.HeightRequest = -1;
        b1.ClearValue(Button.HeightRequestProperty);
        b1.ClearValue(Button.TextColorProperty);
        b1.TextColor = GlobalSpecs.CurrentGlobalSpecs!.GetCurrentTheme()!.Col_FG; //  Colors.White;
        b1.Style = null;

        Label l1 = UIElement.NewLabel();
        l1.Text = ott.Name;
        l1.TextColor = GlobalSpecs.CurrentGlobalSpecs!.GetCurrentTheme()!.Col_FG;
        l1.StyleClass = UIElement.Get_Label_Normal();
        l1.VerticalOptions = LayoutOptions.Start;
        l1.HorizontalOptions = LayoutOptions.Start;
        l1.HorizontalTextAlignment = TextAlignment.Start;
        l1.LineBreakMode = LineBreakMode.NoWrap;
        l1.Opacity = 1;
        l1.SetValue(Label.OpacityProperty, 1.0f);
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

        Grid g5 = UIElement.NewGrid();
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

    public void ResetOrderListView()
    {
        if (GestureRecognizers.Count > 0)
        {
            foreach( var gr in GestureRecognizers)
            {
                if (gr.GetType() == typeof(TapGestureRecognizer))
                {
                    TapGestureRecognizer tgr = (gr as TapGestureRecognizer)!;
                    tgr.Tapped -= GridTapGesture;
                }
            }
        }
        _response = null;
        _orderTable = null;
        ClickedOrderTable = null;
        ClickedTree = null;
        JumpButton = null;
        StepLabel = null;
        StepType = null;
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
        ResponseLabel!.Text = _orderTable!.OrderResult + _orderTable!.OrderFeedback;
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
            if (ParentSubTree != null)
            {
                if ((GetRootTree(ParentSubTree!) as TreeView)!.OTCallback != null)
                {

                    OrderTableEventArgs otva = new();
                    otva.No = this.CurrentOrderTable!.No!;

                    (GetRootTree(ParentSubTree!) as TreeView)!.OTCallback!(this, otva);
                }
            }
            else
            {
                GlobalData.AddLog("ClickedTableEntryCommand ohne ParentSubTree", IGlobalData.protMode.crisp );

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
        if( this.ParentSubTree == null )
            return;

        try
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
        catch( Exception ex )
        {
            string s = ex.Message;
            GlobalData.AddLog("ToggleOrderlistView: " + s, IGlobalData.protMode.crisp);

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
       

        Grid g2 = UIElement.NewGrid();
        Add(g2);
        this.SetRow(g2, Children.Count);
        // g2.BackgroundColor = Colors.Red;
        g2.ClearValue(Grid.BackgroundColorProperty);
        g2.ClearValue(Grid.BackgroundProperty);
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
        l2.MaximumWidthRequest = 80;
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
        b1.Background = Colors.Transparent;
        // b1.TextColor = Colors.Cyan;
        b1.HeightRequest = -1;
        b1.ClearValue(Button.HeightRequestProperty);

        Grid gx = UIElement.NewGrid();
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
        // tgr.Command = GridTapGesture;
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
        b2.VerticalOptions = LayoutOptions.Center;

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

        string? s100 = ot.OrderResult;
        if( ot.OrderFeedback != null && ot.OrderFeedback != "" )
        {
            s100 = s100 + ot.OrderFeedback;
        }
        Label l3 = new();
        l3.StyleClass = s2;
        l3.LineBreakMode = LineBreakMode.WordWrap;
        l3.Text = s100;
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

        Grid g1 = UIElement.NewGrid();
        this.Add(g1);
        this.SetRow(g1, 0);
        List<string> s3 = new();
        s3.Add("Grid_BGBG");
        g1.StyleClass = s3;
        g1.Padding = new Thickness(5, 5, 5, 5);
        g1.Margin= new Thickness(5, 5, 5, 5);

        Grid g2 = UIElement.NewGrid();
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
        // b2.BackgroundColor = Colors.AliceBlue; 
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
        // this.BackgroundColor = Colors.Yellow;

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
        try
        {

            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
            Routing.RegisterRoute(nameof(ReplayPage), typeof(ReplayPage));
            Routing.RegisterRoute(nameof(SettingsPage), typeof(SettingsPage));
            Routing.RegisterRoute(nameof(CreditsPage), typeof(CreditsPage));
            Routing.RegisterRoute(nameof(EndPage), typeof(EndPage));

            _mainAppShell = this;

        }
        catch ( Exception ex )
        {
            GlobalData.AddLog("AppShell: " + ex.Message, IGlobalData.protMode.crisp);
        }
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
            catch (Exception e)
            {
                GlobalData.AddLog("ChangeTheme: " + e.Message, IGlobalData.protMode.crisp);

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
            catch ( Exception e )
            {
                GlobalData.AddLog("ChangeFont: " + e.Message, IGlobalData.protMode.crisp);

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
            catch (Exception e)
            {
                GlobalData.AddLog("ChangeFontSize: " + e.Message, IGlobalData.protMode.crisp);

            }
        }
        // Resources.MergedDictionaries.Remove(Resources.MergedDictionaries.Last());
        Resources.MergedDictionaries.Add(theme);
    }

}
