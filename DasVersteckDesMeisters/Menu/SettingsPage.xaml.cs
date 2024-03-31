using System.Collections.ObjectModel;
using Phoney_MAUI.Game.General;
using Phoney_MAUI.Core;
using Phoney_MAUI.Model;
using GameCore;

namespace Phoney_MAUI.Menu;

public partial class SettingsPage : ContentPage, IMenuExtension
{
    private readonly MainViewModel _viewModelMain;
    private readonly GeneralViewModel _viewModelGeneral;
    private readonly MenuExtension _menuExtension;

    private GlobalData GD;
    private IUIServices UIS { get; set; }
    public ObservableCollection<ThemeInfo> Themes { get; set; }

    public SettingsPage(MainViewModel viewModelMain, GeneralViewModel viewModelGeneral, MenuExtension menuExtension, IUIServices iuis)
    {
        InitializeComponent();
        BindingContext = _viewModelMain = viewModelMain;
        _viewModelGeneral = viewModelGeneral;
        _menuExtension = menuExtension;

        GD = GlobalData.CurrentGlobalData!;
        UIS = iuis;

        _menuExtension!.SetMenuExtension(GetMenuGridLeft, GetMenuGridTotal, GetMenuGridMenu, WebView_Grid, Page_Grid, GetMenuButton, GetUIServices, GetAbsoluteLayout, GetMenuTitle, nameof(SettingsPage));

        Collection<int> p = new() { 0, 1, 2, 3 };

        Themes = _viewModelMain.Themes;

        ResourceDictionary rd3 = ((Collection<ResourceDictionary>)App.Current!.MainPage!.Resources.MergedDictionaries)[1];

#if WINDOWS
        // Custom-Mauszeiger einstellen
        LanguageButton_Deutsch.SetCursorHand();
        LanguageButton_English.SetCursorHand();

        IllustrationButton_Off.SetCursorHand();
        IllustrationButton_Small.SetCursorHand();
        IllustrationButton_Medium.SetCursorHand();
        IllustrationButton_Big.SetCursorHand();

        SimpleMCButton_On.SetCursorHand();
        SimpleMCButton_Off.SetCursorHand();

        TextAttributes_On.SetCursorHand();
        TextAttributes_Off.SetCursorHand();

        OrderListPosButton_Off.SetCursorHand();
        OrderListPosButton_LU.SetCursorHand();
        OrderListPosButton_LD.SetCursorHand();
        OrderListPosButton_RU.SetCursorHand();
        OrderListPosButton_RD.SetCursorHand();

        ItemsLocListPosButton_Off.SetCursorHand();
        ItemsLocListPosButton_LU.SetCursorHand();
        ItemsLocListPosButton_LD.SetCursorHand();
        ItemsLocListPosButton_RU.SetCursorHand();
        ItemsLocListPosButton_RD.SetCursorHand();

        ItemsInvListPosButton_Off.SetCursorHand();
        ItemsInvListPosButton_LU.SetCursorHand();
        ItemsInvListPosButton_LD.SetCursorHand();
        ItemsInvListPosButton_RU.SetCursorHand();
        ItemsInvListPosButton_RD.SetCursorHand();

        OrderListPosButtonPT_Off.SetCursorHand();
        OrderListPosButtonPT_1st.SetCursorHand();
        OrderListPosButtonPT_2nd.SetCursorHand();
        OrderListPosButtonPT_3rd.SetCursorHand();

        ItemsLocListPosButtonPT_Off.SetCursorHand();
        ItemsLocListPosButtonPT_1st.SetCursorHand();
        ItemsLocListPosButtonPT_2nd.SetCursorHand();
        ItemsLocListPosButtonPT_3rd.SetCursorHand();

        ItemsInvListPosButtonPT_Off.SetCursorHand();
        ItemsInvListPosButtonPT_1st.SetCursorHand();
        ItemsInvListPosButtonPT_2nd.SetCursorHand();
        ItemsInvListPosButtonPT_3rd.SetCursorHand();

        ThemesElement.SetCursorHand();
        FontsElement.SetCursorHand();
        FontSizeElement.SetCursorHand();
        MenuButton.SetCursorHand();
#endif

        // Delegate d = _menuExtension!.B_ME1.Clicked.GetInvocationList[0];
        /*
                            var rd1 = App.Current.MainPage.Resources.MergedDictionaries.First( );
                            var rd2 = App.Current.MainPage.Resources["Phoney_MAUI.Resources.Styles.ThemeC"];


                            foreach ( var rdx in App.Current.MainPage.Resources.MergedDictionaries )
                            {
                                int B = 5;
                            }
                            // s => s.Keys == "Phoney_MAUI.Resources.Styles.ThemeC"
                            var rd = App.Current.Resources.MergedDictionaries.First();

                            try
                            {
                                Color BG = (Color)rd["BG"];
                            }
                            catch
                            {
                                int b = 7;
                            }

                            int a = 5;
                            */
    }
    void OnCollectionViewSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
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
    protected override void OnSizeAllocated(double width, double height)
    {
        GridLength gl = new GridLength(1, GridUnitType.Star);
        GetMenuGridTotal().ColumnDefinitions[1].Width = gl;


        _viewModelGeneral!.CheckSize(width, height).Wait();

        base.OnSizeAllocated(width, height);

    }
    public IUIServices GetUIServices()
    {
        return UIS;
    }

    public Label GetMenuTitle()
    {
        return WindowTitle;
    }
    public void ChangeOrientation(IGlobalData.screenMode sm)
    {
#if ANDROID
        OnSizeAllocated( GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth(), GlobalSpecs.CurrentGlobalSpecs.GetScreenHeight());
#endif
    }

    private void SetLanguage()
    {
        WindowTitle.Text = loca.MAUI_UI_Settings_WindowTitle;

        GlobalSpecs? gs = GlobalSpecs.CurrentGlobalSpecs;

        _viewModelMain.Themes[0].Name = loca.MAUI_UI_Theme_A;
        _viewModelMain.Themes[1].Name = loca.MAUI_UI_Theme_B;
        _viewModelMain.Themes[2].Name = loca.MAUI_UI_Theme_C;
        _viewModelMain.Themes[3].Name = loca.MAUI_UI_Theme_D;
        _viewModelMain.Themes[4].Name = loca.MAUI_UI_Theme_E;
        _viewModelMain.Themes[5].Name = loca.MAUI_UI_Theme_F;
        _viewModelMain.Themes[6].Name = loca.MAUI_UI_Theme_G;
        _viewModelMain.Themes[7].Name = loca.MAUI_UI_Theme_H;

        _viewModelMain.Themes[0].RefreshAfterSelectionChange();
        _viewModelMain.Themes[1].RefreshAfterSelectionChange();
        _viewModelMain.Themes[2].RefreshAfterSelectionChange();
        _viewModelMain.Themes[3].RefreshAfterSelectionChange();
        _viewModelMain.Themes[4].RefreshAfterSelectionChange();
        _viewModelMain.Themes[5].RefreshAfterSelectionChange();
        _viewModelMain.Themes[6].RefreshAfterSelectionChange();
        _viewModelMain.Themes[7].RefreshAfterSelectionChange();

        _viewModelMain.Fonts[0].Name = loca.MAUI_UI_Font_A;
        _viewModelMain.Fonts[1].Name = loca.MAUI_UI_Font_B;
        _viewModelMain.Fonts[2].Name = loca.MAUI_UI_Font_C;
        _viewModelMain.Fonts[3].Name = loca.MAUI_UI_Font_D;
        _viewModelMain.Fonts[4].Name = loca.MAUI_UI_Font_E;
        _viewModelMain.Fonts[5].Name = loca.MAUI_UI_Font_F;

        _viewModelMain.Fonts[0].RefreshAfterSelectionChange();
        _viewModelMain.Fonts[1].RefreshAfterSelectionChange();
        _viewModelMain.Fonts[2].RefreshAfterSelectionChange();
        _viewModelMain.Fonts[3].RefreshAfterSelectionChange();
        _viewModelMain.Fonts[4].RefreshAfterSelectionChange();
        _viewModelMain.Fonts[5].RefreshAfterSelectionChange();

        _viewModelMain.FontSizes[0].Name = loca.MAUI_UI_Fontsize_A;
        _viewModelMain.FontSizes[1].Name = loca.MAUI_UI_Fontsize_B;
        _viewModelMain.FontSizes[2].Name = loca.MAUI_UI_Fontsize_C;
        _viewModelMain.FontSizes[3].Name = loca.MAUI_UI_Fontsize_D;
        _viewModelMain.FontSizes[4].Name = loca.MAUI_UI_Fontsize_E;

        _viewModelMain.FontSizes[0].RefreshAfterSelectionChange();
        _viewModelMain.FontSizes[1].RefreshAfterSelectionChange();
        _viewModelMain.FontSizes[2].RefreshAfterSelectionChange();
        _viewModelMain.FontSizes[3].RefreshAfterSelectionChange();
        _viewModelMain.FontSizes[4].RefreshAfterSelectionChange();

        ThemesLabel.Text = loca.MAUI_UI_ThemesLabel;
        FontsLabel.Text = loca.MAUI_UI_FontsLabel;
        FontSizeLabel.Text = loca.MAUI_UI_FontSizeLabel;

        LanguageLabel.Text = loca.MAUI_UI_LanguageLabel;
        IllustrationLabel.Text = loca.MAUI_UI_IllustrationLabel;
        TextAttributesLabel.Text = loca.MAUI_UI_TextattributesLabel;
        SimpleMCLabel.Text = loca.MAUI_UI_SimpleMCLabel;
        OrderColumnLabel.Text = loca.MAUI_UI_OrderColumnLabel;
        ItemsLocLabel.Text = loca.MAUI_UI_ItemsLocLabel;
        ItemsInvLabel.Text = loca.MAUI_UI_ItemsInvLabel;
        OrderColumnLabelPortrait.Text = loca.MAUI_UI_OrderColumnLabelPortrait;
        ItemsLocLabelPortrait.Text = loca.MAUI_UI_ItemsLocLabelPortrait;
        ItemsInvLabelPortrait.Text = loca.MAUI_UI_ItemsInvLabelPortrait;
        RowMargin.Text = loca.MAUI_Listrow_Height;
        STTMode.Text = loca.MAUI_STT;
            ParagraphMode.Text = loca.MAUI_Paragraphmode;

        SetButtonStates();
        _menuExtension!.SetLanguage();
    }

    private void SetButtonStates()
    {
        if (GD.Language == IGlobalData.language.german)
            LanguageButton_Deutsch.Text = "--- " + loca.MAUI_UI_Language_Deutsch + " ---";
        else
            LanguageButton_Deutsch.Text = loca.MAUI_UI_Language_Deutsch;

        if (GD.Language == IGlobalData.language.english)
            LanguageButton_English.Text = "--- " + loca.MAUI_UI_Language_English + " ---";
        else
            LanguageButton_English.Text = loca.MAUI_UI_Language_English;


        if (GD.PicMode == IGlobalData.picMode.off)
            IllustrationButton_Off.Text = "--- " + loca.MAUI_UI_Buttonstate_Off + " ---";
        else
            IllustrationButton_Off.Text = loca.MAUI_UI_Buttonstate_Off;

        if (GD.PicMode == IGlobalData.picMode.small)
            IllustrationButton_Small.Text = "--- " + loca.MAUI_UI_Buttonstate_Small + " ---";
        else
            IllustrationButton_Small.Text = loca.MAUI_UI_Buttonstate_Small;

        if (GD.PicMode == IGlobalData.picMode.medium)
            IllustrationButton_Medium.Text = "--- " + loca.MAUI_UI_Buttonstate_Medium + " ---";
        else
            IllustrationButton_Medium.Text = loca.MAUI_UI_Buttonstate_Medium;

        if (GD.PicMode == IGlobalData.picMode.big)
            IllustrationButton_Big.Text = "--- " + loca.MAUI_UI_Buttonstate_Big + " ---";
        else
            IllustrationButton_Big.Text = loca.MAUI_UI_Buttonstate_Big;


        if (GD.SimpleMC == true)
            SimpleMCButton_On.Text = "--- " + loca.MAUI_UI_Buttonstate_On + " ---";
        else
            SimpleMCButton_On.Text = loca.MAUI_UI_Buttonstate_On;

        if (GD.SimpleMC == false)
            SimpleMCButton_Off.Text = "--- " + loca.MAUI_UI_Buttonstate_Off + " ---";
        else
            SimpleMCButton_Off.Text = loca.MAUI_UI_Buttonstate_Off;


        if (GD.Highlighting == true)
            TextAttributes_On.Text = "--- " + loca.MAUI_UI_Buttonstate_On + " ---";
        else
            TextAttributes_On.Text = loca.MAUI_UI_Buttonstate_On;

        if (GD.Highlighting == false)
            TextAttributes_Off.Text = "--- " + loca.MAUI_UI_Buttonstate_Off + " ---";
        else
            TextAttributes_Off.Text = loca.MAUI_UI_Buttonstate_Off;


        if (GD.LayoutDescription.OrderListPos == ILayoutDescription.selectedPosition.off)
            OrderListPosButton_Off.Text = "--- " + loca.MAUI_UI_Buttonstate_Off + " ---";
        else
            OrderListPosButton_Off.Text = loca.MAUI_UI_Buttonstate_Off;

        if (GD.LayoutDescription.OrderListPos == ILayoutDescription.selectedPosition.leftUp)
            OrderListPosButton_LU.Text = "--- " + loca.MAUI_UI_Buttonstate_LU + " ---";
        else
            OrderListPosButton_LU.Text = loca.MAUI_UI_Buttonstate_LU;

        if (GD.LayoutDescription.OrderListPos == ILayoutDescription.selectedPosition.leftDown)
            OrderListPosButton_LD.Text = "--- " + loca.MAUI_UI_Buttonstate_LD + " ---";
        else
            OrderListPosButton_LD.Text = loca.MAUI_UI_Buttonstate_LD;

        if (GD.LayoutDescription.OrderListPos == ILayoutDescription.selectedPosition.rightUp)
            OrderListPosButton_RU.Text = "--- " + loca.MAUI_UI_Buttonstate_RU + " ---";
        else
            OrderListPosButton_RU.Text = loca.MAUI_UI_Buttonstate_RU;

        if (GD.LayoutDescription.OrderListPos == ILayoutDescription.selectedPosition.rightDown)
            OrderListPosButton_RD.Text = "--- " + loca.MAUI_UI_Buttonstate_RD + " ---";
        else
            OrderListPosButton_RD.Text = loca.MAUI_UI_Buttonstate_RD;

        // Items Loc
        if (GD.LayoutDescription.ItemsLocListPos == ILayoutDescription.selectedPosition.off)
            ItemsLocListPosButton_Off.Text = "--- " + loca.MAUI_UI_Buttonstate_Off + " ---";
        else
            ItemsLocListPosButton_Off.Text = loca.MAUI_UI_Buttonstate_Off;

        if (GD.LayoutDescription.ItemsLocListPos == ILayoutDescription.selectedPosition.leftUp)
            ItemsLocListPosButton_LU.Text = "--- " + loca.MAUI_UI_Buttonstate_LU + " ---";
        else
            ItemsLocListPosButton_LU.Text = loca.MAUI_UI_Buttonstate_LU;

        if (GD.LayoutDescription.ItemsLocListPos == ILayoutDescription.selectedPosition.leftDown)
            ItemsLocListPosButton_LD.Text = "--- " + loca.MAUI_UI_Buttonstate_LD + " ---";
        else
            ItemsLocListPosButton_LD.Text = loca.MAUI_UI_Buttonstate_LD;

        if (GD.LayoutDescription.ItemsLocListPos == ILayoutDescription.selectedPosition.rightUp)
            ItemsLocListPosButton_RU.Text = "--- " + loca.MAUI_UI_Buttonstate_RU + " ---";
        else
            ItemsLocListPosButton_RU.Text = loca.MAUI_UI_Buttonstate_RU;

        if (GD.LayoutDescription.ItemsLocListPos == ILayoutDescription.selectedPosition.rightDown)
            ItemsLocListPosButton_RD.Text = "--- " + loca.MAUI_UI_Buttonstate_RD + " ---";
        else
            ItemsLocListPosButton_RD.Text = loca.MAUI_UI_Buttonstate_RD;

        // Items Inv
        if (GD.LayoutDescription.ItemsInvListPos == ILayoutDescription.selectedPosition.off)
            ItemsInvListPosButton_Off.Text = "--- " + loca.MAUI_UI_Buttonstate_Off + " ---";
        else
            ItemsInvListPosButton_Off.Text = loca.MAUI_UI_Buttonstate_Off;

        if (GD.LayoutDescription.ItemsInvListPos == ILayoutDescription.selectedPosition.leftUp)
            ItemsInvListPosButton_LU.Text = "--- " + loca.MAUI_UI_Buttonstate_LU + " ---";
        else
            ItemsInvListPosButton_LU.Text = loca.MAUI_UI_Buttonstate_LU;

        if (GD.LayoutDescription.ItemsInvListPos == ILayoutDescription.selectedPosition.leftDown)
            ItemsInvListPosButton_LD.Text = "--- " + loca.MAUI_UI_Buttonstate_LD + " ---";
        else
            ItemsInvListPosButton_LD.Text = loca.MAUI_UI_Buttonstate_LD;

        if (GD.LayoutDescription.ItemsInvListPos == ILayoutDescription.selectedPosition.rightUp)
            ItemsInvListPosButton_RU.Text = "--- " + loca.MAUI_UI_Buttonstate_RU + " ---";
        else
            ItemsInvListPosButton_RU.Text = loca.MAUI_UI_Buttonstate_RU;

        if (GD.LayoutDescription.ItemsInvListPos == ILayoutDescription.selectedPosition.rightDown)
            ItemsInvListPosButton_RD.Text = "--- " + loca.MAUI_UI_Buttonstate_RD + " ---";
        else
            ItemsInvListPosButton_RD.Text = loca.MAUI_UI_Buttonstate_RD;

        int columns = 0;
        if (GD.LayoutDescription.OrderListPosPT != ILayoutDescription.selectedPositionPT.off)
            columns++;
        if (GD.LayoutDescription.ItemsLocListPosPT != ILayoutDescription.selectedPositionPT.off)
            columns++;
        if (GD.LayoutDescription.ItemsInvListPosPT != ILayoutDescription.selectedPositionPT.off)
            columns++;

        // OrderList PT
        if (GD.LayoutDescription.OrderListPosPT == ILayoutDescription.selectedPositionPT.off)
            OrderListPosButtonPT_Off.Text = "--- " + loca.MAUI_UI_Buttonstate_Off + " ---";
        else
            OrderListPosButtonPT_Off.Text = loca.MAUI_UI_Buttonstate_Off;

        if (GD.LayoutDescription.OrderListPosPT == ILayoutDescription.selectedPositionPT.first)
            OrderListPosButtonPT_1st.Text = "--- " + loca.MAUI_UI_Buttonstate_First + " ---";
        else
            OrderListPosButtonPT_1st.Text = loca.MAUI_UI_Buttonstate_First;

        if (GD.LayoutDescription.OrderListPosPT == ILayoutDescription.selectedPositionPT.second)
            OrderListPosButtonPT_2nd.Text = "--- " + loca.MAUI_UI_Buttonstate_Second + " ---";
        else
            OrderListPosButtonPT_2nd.Text = loca.MAUI_UI_Buttonstate_Second;

        if (GD.LayoutDescription.OrderListPosPT == ILayoutDescription.selectedPositionPT.third)
            OrderListPosButtonPT_3rd.Text = "--- " + loca.MAUI_UI_Buttonstate_Third + " ---";
        else
            OrderListPosButtonPT_3rd.Text = loca.MAUI_UI_Buttonstate_Third;


        // Itemlist Loc PT
        if (GD.LayoutDescription.ItemsLocListPosPT == ILayoutDescription.selectedPositionPT.off)
            ItemsLocListPosButtonPT_Off.Text = "--- " + loca.MAUI_UI_Buttonstate_Off + " ---";
        else
            ItemsLocListPosButtonPT_Off.Text = loca.MAUI_UI_Buttonstate_Off;

        if (GD.LayoutDescription.ItemsLocListPosPT == ILayoutDescription.selectedPositionPT.first)
            ItemsLocListPosButtonPT_1st.Text = "--- " + loca.MAUI_UI_Buttonstate_First + " ---";
        else
            ItemsLocListPosButtonPT_1st.Text = loca.MAUI_UI_Buttonstate_First;

        if (GD.LayoutDescription.ItemsLocListPosPT == ILayoutDescription.selectedPositionPT.second)
            ItemsLocListPosButtonPT_2nd.Text = "--- " + loca.MAUI_UI_Buttonstate_Second + " ---";
        else
            ItemsLocListPosButtonPT_2nd.Text = loca.MAUI_UI_Buttonstate_Second;

        if (GD.LayoutDescription.ItemsLocListPosPT == ILayoutDescription.selectedPositionPT.third)
            ItemsLocListPosButtonPT_3rd.Text = "--- " + loca.MAUI_UI_Buttonstate_Third + " ---";
        else
            ItemsLocListPosButtonPT_3rd.Text = loca.MAUI_UI_Buttonstate_Third;

        // Itemlist Inv PT
        if (GD.LayoutDescription.ItemsInvListPosPT == ILayoutDescription.selectedPositionPT.off)
            ItemsInvListPosButtonPT_Off.Text = "--- " + loca.MAUI_UI_Buttonstate_Off + " ---";
        else
            ItemsInvListPosButtonPT_Off.Text = loca.MAUI_UI_Buttonstate_Off;

        if (GD.LayoutDescription.ItemsInvListPosPT == ILayoutDescription.selectedPositionPT.first)
            ItemsInvListPosButtonPT_1st.Text = "--- " + loca.MAUI_UI_Buttonstate_First + " ---";
        else
            ItemsInvListPosButtonPT_1st.Text = loca.MAUI_UI_Buttonstate_First;

        if (GD.LayoutDescription.ItemsInvListPosPT == ILayoutDescription.selectedPositionPT.second)
            ItemsInvListPosButtonPT_2nd.Text = "--- " + loca.MAUI_UI_Buttonstate_Second + " ---";
        else
            ItemsInvListPosButtonPT_2nd.Text = loca.MAUI_UI_Buttonstate_Second;

        if (GD.LayoutDescription.ItemsInvListPosPT == ILayoutDescription.selectedPositionPT.third)
            ItemsInvListPosButtonPT_3rd.Text = "--- " + loca.MAUI_UI_Buttonstate_Third + " ---";
        else
            ItemsInvListPosButtonPT_3rd.Text = loca.MAUI_UI_Buttonstate_Third;

        if (GD.LayoutDescription.ClickMargin == ILayoutDescription.eClickMargin.very_low)
            RowMargin_VeryLow.Text = "--- " + loca.MAUI_Listrow_Very_Low + " ---";
        else
            RowMargin_VeryLow.Text = loca.MAUI_Listrow_Very_Low;

        if (GD.LayoutDescription.ClickMargin == ILayoutDescription.eClickMargin.low)
            RowMargin_Low.Text = "--- " + loca.MAUI_Listrow_Low + " ---";
        else
            RowMargin_Low.Text = loca.MAUI_Listrow_Low;

        if (GD.LayoutDescription.ClickMargin == ILayoutDescription.eClickMargin.medium)
            RowMargin_Medium.Text = "--- " + loca.MAUI_Listrow_Medium + " ---";
        else
            RowMargin_Medium.Text = loca.MAUI_Listrow_Medium;

        if (GD.LayoutDescription.ClickMargin == ILayoutDescription.eClickMargin.high)
            RowMargin_High.Text = "--- " + loca.MAUI_Listrow_High + " ---";
        else
            RowMargin_High.Text = loca.MAUI_Listrow_High;

        if (GD.LayoutDescription.ClickMargin == ILayoutDescription.eClickMargin.very_high)
            RowMargin_VeryHigh.Text = "--- " + loca.MAUI_Listrow_Very_High + " ---";
        else
            RowMargin_VeryHigh.Text = loca.MAUI_Listrow_Very_High;

        if (GD.STTMicroState == IGlobalData.microMode.off)
            STTMode_Off.Text = "--- " + loca.MAUI_STT_Off + " ---";
        else 
            STTMode_Off.Text = loca.MAUI_STT_Off;

        if (GD.STTMicroState == IGlobalData.microMode.once)
            STTMode_Manuell.Text = "--- " + loca.MAUI_STT_Manual + " ---";
        else
            STTMode_Manuell.Text = loca.MAUI_STT_Manual;

        var tres = UIS.STTInqSpeech();
        
        tres.Wait();

        if ( tres.Result == false)
        {
            STTMode_Manuell.FontAttributes = FontAttributes.Italic;
        }
        else
        {
            STTMode_Manuell.FontAttributes = FontAttributes.None;

        }

        if (GD.STTMicroState == IGlobalData.microMode.continuous)
            STTMode_Continuous.Text = "--- " + loca.MAUI_STT_Continuous + " ---";
        else
            STTMode_Continuous.Text = loca.MAUI_STT_Continuous;

        if (UIS.STTInqSpeech().Result == false)
        {
            STTMode_Continuous.FontAttributes = FontAttributes.Italic;
        }
        else
        {
            STTMode_Continuous.FontAttributes = FontAttributes.None;

        }

        if (GD.LayoutDescription.ParagraphClusterMode == ILayoutDescription.ParagraphClusters.none)
            ParagraphMode_Off.Text = "--- " + loca.MAUI_Paragraphmode_Off + " ---";
        else
            ParagraphMode_Off.Text = loca.MAUI_Paragraphmode_Off;

        if (GD.LayoutDescription.ParagraphClusterMode == ILayoutDescription.ParagraphClusters.latest)
            ParagraphMode_Last.Text = "--- " + loca.MAUI_Paragraphmode_Latest + " ---";
        else
            ParagraphMode_Last.Text = loca.MAUI_Paragraphmode_Latest;

        if (GD.LayoutDescription.ParagraphClusterMode == ILayoutDescription.ParagraphClusters.all)
            ParagraphMode_Full.Text = "--- " + loca.MAUI_Paragraphmode_Full + " ---";
        else
            ParagraphMode_Full.Text = loca.MAUI_Paragraphmode_Full;

        /*
        if( columns < 1 )
        {
            OrderListPosButtonPT_3rd.IsVisible= false;
            ItemsLocListPosButtonPT_3rd.IsVisible = false;
            ItemsInvListPosButtonPT_3rd.IsVisible = false;

            OrderListPosButtonPT_2nd.IsVisible = false;
            ItemsLocListPosButtonPT_2nd.IsVisible = false;
            ItemsInvListPosButtonPT_2nd.IsVisible = false;


            MGMInner.RowDefinitions[15].Height = new GridLength(120);
            MGMInner.RowDefinitions[17].Height = new GridLength(120);
            MGMInner.RowDefinitions[19].Height = new GridLength(120);
        }
        else if ( columns < 2 )
        {
            OrderListPosButtonPT_3rd.IsVisible = false;
            ItemsLocListPosButtonPT_3rd.IsVisible = false;
            ItemsInvListPosButtonPT_3rd.IsVisible = false;

            OrderListPosButtonPT_2nd.IsVisible = true;
            ItemsLocListPosButtonPT_2nd.IsVisible = true;
            ItemsInvListPosButtonPT_2nd.IsVisible = true;

            MGMInner.RowDefinitions[15].Height = new GridLength(180);
            MGMInner.RowDefinitions[17].Height = new GridLength(180);
            MGMInner.RowDefinitions[19].Height = new GridLength(180);
        }
        else
        {
            OrderListPosButtonPT_3rd.IsVisible = true;
            ItemsLocListPosButtonPT_3rd.IsVisible = true;
            ItemsInvListPosButtonPT_3rd.IsVisible = true;

            OrderListPosButtonPT_2nd.IsVisible = true;
            ItemsLocListPosButtonPT_2nd.IsVisible = true;
            ItemsInvListPosButtonPT_2nd.IsVisible = true;

            MGMInner.RowDefinitions[15].Height = new GridLength(240);
            MGMInner.RowDefinitions[17].Height = new GridLength(240);
            MGMInner.RowDefinitions[19].Height = new GridLength(240);

        }
        */

        // OrderList
        if (columns < 1 || (columns == 1 && GD.LayoutDescription.OrderListPosPT == ILayoutDescription.selectedPositionPT.first))
        {
            OrderListPosButtonPT_3rd.IsVisible = false;
            OrderListPosButtonPT_2nd.IsVisible = false;
            MGMInner.RowDefinitions[15].Height = new GridLength(120);
        }
        else if (columns < 2 || (columns == 2 && (GD.LayoutDescription.OrderListPosPT == ILayoutDescription.selectedPositionPT.second || GD.LayoutDescription.OrderListPosPT == ILayoutDescription.selectedPositionPT.first)))
        {
            OrderListPosButtonPT_3rd.IsVisible = false;
            OrderListPosButtonPT_2nd.IsVisible = true;
            MGMInner.RowDefinitions[15].Height = new GridLength(180);
        }
        else
        {
            OrderListPosButtonPT_3rd.IsVisible = true;
            OrderListPosButtonPT_2nd.IsVisible = true;
            MGMInner.RowDefinitions[15].Height = new GridLength(240);
        }

        // Items Loc
        if (columns < 1 || (columns == 1 && GD.LayoutDescription.ItemsLocListPosPT == ILayoutDescription.selectedPositionPT.first))
        {
            ItemsLocListPosButtonPT_3rd.IsVisible = false;
            ItemsLocListPosButtonPT_2nd.IsVisible = false;
            MGMInner.RowDefinitions[17].Height = new GridLength(120);
        }
        else if (columns < 2 || (columns == 2 && (GD.LayoutDescription.ItemsLocListPosPT == ILayoutDescription.selectedPositionPT.second || GD.LayoutDescription.ItemsLocListPosPT == ILayoutDescription.selectedPositionPT.first)))
        {
            ItemsLocListPosButtonPT_3rd.IsVisible = false;
            ItemsLocListPosButtonPT_2nd.IsVisible = true;
            MGMInner.RowDefinitions[17].Height = new GridLength(180);
        }
        else
        {
            ItemsLocListPosButtonPT_3rd.IsVisible = true;
            ItemsLocListPosButtonPT_2nd.IsVisible = true;
            MGMInner.RowDefinitions[17].Height = new GridLength(240);
        }


        // Items Inv
        if (columns < 1 || (columns == 1 && GD.LayoutDescription.ItemsInvListPosPT == ILayoutDescription.selectedPositionPT.first))
        {
            ItemsInvListPosButtonPT_3rd.IsVisible = false;
            ItemsInvListPosButtonPT_2nd.IsVisible = false;
            MGMInner.RowDefinitions[19].Height = new GridLength(120);
        }
        else if (columns < 2 || (columns == 2 && (GD.LayoutDescription.ItemsInvListPosPT == ILayoutDescription.selectedPositionPT.second || GD.LayoutDescription.ItemsInvListPosPT == ILayoutDescription.selectedPositionPT.first)))
        {
            ItemsInvListPosButtonPT_3rd.IsVisible = false;
            ItemsInvListPosButtonPT_2nd.IsVisible = true;
            MGMInner.RowDefinitions[19].Height = new GridLength(180);
        }
        else
        {
            ItemsInvListPosButtonPT_3rd.IsVisible = true;
            ItemsInvListPosButtonPT_2nd.IsVisible = true;
            MGMInner.RowDefinitions[19].Height = new GridLength(240);

        }

    }

    public void DoResize(double width, double height)
    {
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        // Diese Menüpunkte werden für "Das Versteck des Meisters" zunächst nicht angeboten
        MGMInner.RowDefinitions[0].Height = new GridLength(0);
        MGMInner.RowDefinitions[1].Height = new GridLength(0);
        MGMInner.RowDefinitions[2].Height = new GridLength(0);
        MGMInner.RowDefinitions[3].Height = new GridLength(0);


        _viewModelGeneral.SetCallbackChangeOrientation((IGlobalData._callbackChangeOrientation)ChangeOrientation);
        _viewModelGeneral!.SetCallbackResize((IGlobalData._callbackResize)DoResize);
        base.OnNavigatedTo(args);

        await _viewModelMain.Initialize();

        _viewModelGeneral.InitResize(this.Width, this.Height);

        _menuExtension!.ResetLayout();

        SetLanguage();
        _menuExtension!.QuitMethod = PressEndLocal;
        IllustrationButton_Small.Clicked += OnClickIlluSmall;
    }

    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        IllustrationButton_Small.Clicked -= OnClickIlluSmall;
        _menuExtension!.QuitMethod = null;
    }
    void OnClickGerman(object? sender, EventArgs e)
    {
        GD.Language = IGlobalData.language.german;

        SetLanguage();
    }
    void OnClickEnglish(object? sender, EventArgs e)
    {
        GD.Language = IGlobalData.language.english;
        SetLanguage();
    }
    void OnClickIlluOff(object? sender, EventArgs e)
    {
        GD.PicMode = IGlobalData.picMode.off;
        SetButtonStates();
    }
    void OnClickIlluSmall(object? sender, EventArgs e)
    {
        GD.PicMode = IGlobalData.picMode.small;
        SetButtonStates();
    }
    void OnClickIlluMedium(object? sender, EventArgs e)
    {
        GD.PicMode = IGlobalData.picMode.medium;

        SetButtonStates();
    }
    void OnClickIlluBig(object? sender, EventArgs e)
    {
        GD.PicMode = IGlobalData.picMode.big;

        SetButtonStates();
    }
    void OnClickSimpleMCOn(object? sender, EventArgs e)
    {
        GD.DebugCount++;

        if( GD.DebugCount > 7 && GD. DebugMode == false )
        {
            GD.DebugMode = true;
            DebugMenuOpen();
        }
        GD.SimpleMC = true;
        SetButtonStates();
    }
    void OnClickSimpleMCOff(object? sender, EventArgs e)
    {
        GD.DebugCount = 0;

        GD.SimpleMC = false;
        SetButtonStates();
    }
    void OnClickTextAttribOn(object? sender, EventArgs e)
    {
        GD.Highlighting = true;
        SetButtonStates();
    }
    void OnClickTextAttribOff(object? sender, EventArgs e)
    {
        GD.Highlighting = false;
        SetButtonStates();
    }

    void OnClickOrderListPosLS_Off(object? sender, EventArgs e)
    {
        GD.LayoutDescription.OrderListPos = ILayoutDescription.selectedPosition.off;
        SetButtonStates();
    }
    void OnClickOrderListPosLS_LU(object? sender, EventArgs e)
    {
        GD.LayoutDescription.OrderListPos = ILayoutDescription.selectedPosition.leftUp;
        SetButtonStates();
    }
    void OnClickOrderListPosLS_LD(object? sender, EventArgs e)
    {
        GD.LayoutDescription.OrderListPos = ILayoutDescription.selectedPosition.leftDown;
        SetButtonStates();
    }
    void OnClickOrderListPosLS_RU(object? sender, EventArgs e)
    {
        GD.LayoutDescription.OrderListPos = ILayoutDescription.selectedPosition.rightUp;
        SetButtonStates();
    }
    void OnClickOrderListPosLS_RD(object? sender, EventArgs e)
    {
        GD.LayoutDescription.OrderListPos = ILayoutDescription.selectedPosition.rightDown;
        SetButtonStates();
    }

    void OnClickItemsLocListPosLS_Off(object? sender, EventArgs e)
    {
        GD.LayoutDescription.ItemsLocListPos = ILayoutDescription.selectedPosition.off;
        SetButtonStates();
    }
    void OnClickItemsLocListPosLS_LU(object? sender, EventArgs e)
    {
        GD.LayoutDescription.ItemsLocListPos = ILayoutDescription.selectedPosition.leftUp;
        SetButtonStates();
    }
    void OnClickItemsLocListPosLS_LD(object? sender, EventArgs e)
    {
        GD.LayoutDescription.ItemsLocListPos = ILayoutDescription.selectedPosition.leftDown;
        SetButtonStates();
    }
    void OnClickItemsLocListPosLS_RU(object? sender, EventArgs e)
    {
        GD.LayoutDescription.ItemsLocListPos = ILayoutDescription.selectedPosition.rightUp;
        SetButtonStates();
    }
    void OnClickItemsLocListPosLS_RD(object? sender, EventArgs e)
    {
        GD.LayoutDescription.ItemsLocListPos = ILayoutDescription.selectedPosition.rightDown;
        SetButtonStates();
    }

    void OnClickItemsInvListPosLS_Off(object? sender, EventArgs e)
    {
        GD.LayoutDescription.ItemsInvListPos = ILayoutDescription.selectedPosition.off;
        SetButtonStates();
    }
    void OnClickItemsInvListPosLS_LU(object? sender, EventArgs e)
    {
        GD.LayoutDescription.ItemsInvListPos = ILayoutDescription.selectedPosition.leftUp;
        SetButtonStates();
    }
    void OnClickItemsInvListPosLS_LD(object? sender, EventArgs e)
    {
        GD.LayoutDescription.ItemsInvListPos = ILayoutDescription.selectedPosition.leftDown;
        SetButtonStates();
    }
    void OnClickItemsInvListPosLS_RU(object? sender, EventArgs e)
    {
        GD.LayoutDescription.ItemsInvListPos = ILayoutDescription.selectedPosition.rightUp;
        SetButtonStates();
    }
    void OnClickItemsInvListPosLS_RD(object? sender, EventArgs e)
    {
        GD.LayoutDescription.ItemsInvListPos = ILayoutDescription.selectedPosition.rightDown;
        SetButtonStates();
    }
    void OnClickOrderListPosPT_Off(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription;
        ld.PortraitColumn1Width = 0;
        ld.PortraitColumn2Width = 0;
        ld.PortraitColumn3Width = 0;
        SetPTOrder(1, -1);
        // GD.OrderListPosPT = IGlobalData.selectedPositionPT.off;
        SetButtonStates();
    }
    void OnClickOrderListPosPT_1st(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription;
        ld.PortraitColumn1Width = 0;
        ld.PortraitColumn2Width = 0;
        ld.PortraitColumn3Width = 0;
        SetPTOrder(1, 0);
        // GD.OrderListPosPT = IGlobalData.selectedPositionPT.first;
        SetButtonStates();
    }
    void OnClickOrderListPosPT_2nd(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.PortraitColumn1Width = 0;
        ld.PortraitColumn2Width = 0;
        ld.PortraitColumn3Width = 0;
        SetPTOrder(1, 1);
        // GD.OrderListPosPT = IGlobalData.selectedPositionPT.second;
        SetButtonStates();
    }
    void OnClickOrderListPosPT_3rd(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.PortraitColumn1Width = 0;
        ld.PortraitColumn2Width = 0;
        ld.PortraitColumn3Width = 0;
        SetPTOrder(1, 2);
        // GD.OrderListPosPT = IGlobalData.selectedPositionPT.third;
        SetButtonStates();
    }


    void OnClickItemsLocListPosPT_Off(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.PortraitColumn1Width = 0;
        ld.PortraitColumn2Width = 0;
        ld.PortraitColumn3Width = 0;
        SetPTOrder(2, -1);
        // GD.ItemsLocListPosPT = IGlobalData.selectedPositionPT.off;
        SetButtonStates();
    }
    void OnClickItemsLocListPosPT_1st(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.PortraitColumn1Width = 0;
        ld.PortraitColumn2Width = 0;
        ld.PortraitColumn3Width = 0;
        SetPTOrder(2, 0);
        // GD.ItemsLocListPosPT = IGlobalData.selectedPositionPT.first;
        SetButtonStates();
    }
    void OnClickItemsLocListPosPT_2nd(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.PortraitColumn1Width = 0;
        ld.PortraitColumn2Width = 0;
        ld.PortraitColumn3Width = 0;
        SetPTOrder(2, 1);
        // GD.ItemsLocListPosPT = IGlobalData.selectedPositionPT.second;
        SetButtonStates();
    }
    void OnClickItemsLocListPosPT_3rd(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.PortraitColumn1Width = 0;
        ld.PortraitColumn2Width = 0;
        ld.PortraitColumn3Width = 0;
        SetPTOrder(2, 2);
        // GD.ItemsLocListPosPT = IGlobalData.selectedPositionPT.third;
        SetButtonStates();
    }

    void OnClickItemsInvListPosPT_Off(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.PortraitColumn1Width = 0;
        ld.PortraitColumn2Width = 0;
        ld.PortraitColumn3Width = 0;
        SetPTOrder(3, -1);
        // GD.ItemsInvListPosPT = IGlobalData.selectedPositionPT.off;
        SetButtonStates();
    }
    void OnClickItemsInvListPosPT_1st(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.PortraitColumn1Width = 0;
        ld.PortraitColumn2Width = 0;
        ld.PortraitColumn3Width = 0;
        SetPTOrder(3, 0);
        // GD.ItemsInvListPosPT = IGlobalData.selectedPositionPT.first;
        SetButtonStates();
    }
    void OnClickItemsInvListPosPT_2nd(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.PortraitColumn1Width = 0;
        ld.PortraitColumn2Width = 0;
        ld.PortraitColumn3Width = 0;
        SetPTOrder(3, 1);

        // GD.ItemsInvListPosPT = IGlobalData.selectedPositionPT.second;
        SetButtonStates();
    }
    void OnClickItemsInvListPosPT_3rd(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription) GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.PortraitColumn1Width = 0;
        ld.PortraitColumn2Width = 0;
        ld.PortraitColumn3Width = 0;
        SetPTOrder(3, 2);
        // GD.ItemsInvListPosPT = IGlobalData.selectedPositionPT.third;
        SetButtonStates();
    }

    void OnClickRowMargin_VeryLow(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.ClickMargin = ILayoutDescription.eClickMargin.very_low;
        // GD.ItemsInvListPosPT = IGlobalData.selectedPositionPT.third;
        SetButtonStates();
    }
    void OnClickRowMargin_Low(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.ClickMargin = ILayoutDescription.eClickMargin.low;
        // GD.ItemsInvListPosPT = IGlobalData.selectedPositionPT.third;
        SetButtonStates();
    }
    void OnClickRowMargin_Medium(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.ClickMargin = ILayoutDescription.eClickMargin.medium;
        // GD.ItemsInvListPosPT = IGlobalData.selectedPositionPT.third;
        SetButtonStates();
    }
    void OnClickRowMargin_High(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.ClickMargin = ILayoutDescription.eClickMargin.high;
        // GD.ItemsInvListPosPT = IGlobalData.selectedPositionPT.third;
        SetButtonStates();
    }
    void OnClickRowMargin_VeryHigh(object? sender, EventArgs e)
    {
        LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription!;
        ld.ClickMargin = ILayoutDescription.eClickMargin.very_high;
        // GD.ItemsInvListPosPT = IGlobalData.selectedPositionPT.third;
        SetButtonStates();
    }
    private void OnParagraphMode_None(object? sender, EventArgs e)
    {
        UIS.StoryTextObj!.ParagraphsToSmall();
        // GD.STTContinuous = false;
        GD.LayoutDescription.ParagraphClusterMode = ILayoutDescription.ParagraphClusters.none;
        SetButtonStates();
    }
    private void OnParagraphMode_Latest(object? sender, EventArgs e)
    {
        UIS.StoryTextObj!.ParagraphsToSmall();
        // GD.STTContinuous = false;
        GD.LayoutDescription.ParagraphClusterMode = ILayoutDescription.ParagraphClusters.latest;
        SetButtonStates();
    }
    private void OnParagraphMode_Full(object? sender, EventArgs e)
    {
        UIS.StoryTextObj!.ParagraphsToLarge();
        // GD.STTContinuous = false;
        GD.LayoutDescription.ParagraphClusterMode = ILayoutDescription.ParagraphClusters.all;
        SetButtonStates();
    }

    private void OnClickSTTMode_Off(object? sender, EventArgs e)
    {
        // GD.STTContinuous = false;
        GD.STTMicroState = IGlobalData.microMode.off;
        SetButtonStates();
    }
    private void OnClickSTTMode_Manuell(object? sender, EventArgs e)
    {
        bool state =  UIS.STTInqSpeech().Result;

        if ( state == true )
            GD.STTMicroState = IGlobalData.microMode.once;
        else
            GD.STTMicroState = IGlobalData.microMode.off;

        SetButtonStates();
    }
    private void OnClickSTTMode_Continuous(object? sender, EventArgs e)
    {
        bool state = UIS.STTInqSpeech().Result;

        if (state == true)
            GD.STTMicroState = IGlobalData.microMode.continuous;
        else
            GD.STTMicroState = IGlobalData.microMode.off;

        SetButtonStates();
    }

    public void SetPTOrder(int ID, int Ix)
    {
        try
        {

            GD.LayoutDescription.PTOrder.Remove(ID);
        }
        catch // (Exception e)
        {
            // int a = 5;
        }

        try
        {
            if (Ix != -1)
                GD.LayoutDescription.PTOrder.Insert(Ix, ID);
        }
        catch // (Exception e)
        {
            // int a = 5;
        }

        GD.LayoutDescription.OrderListPosPT = ILayoutDescription.selectedPositionPT.off;
        GD.LayoutDescription.ItemsLocListPosPT = ILayoutDescription.selectedPositionPT.off;
        GD.LayoutDescription.ItemsInvListPosPT = ILayoutDescription.selectedPositionPT.off;

        if (GD.LayoutDescription.PTOrder.Count > 0)
        {
            if (GD.LayoutDescription.PTOrder[0] == 1)
            {
                GD.LayoutDescription.OrderListPosPT = ILayoutDescription.selectedPositionPT.first;
            }
            else if (GD.LayoutDescription.PTOrder[0] == 2)
            {
                GD.LayoutDescription.ItemsLocListPosPT = ILayoutDescription.selectedPositionPT.first;
            }
            else if (GD.LayoutDescription.PTOrder[0] == 3)
            {
                GD.LayoutDescription.ItemsInvListPosPT = ILayoutDescription.selectedPositionPT.first;
            }
        }
        if (GD.LayoutDescription.PTOrder.Count > 1)
        {
            if (GD.LayoutDescription.PTOrder[1] == 1)
            {
                GD.LayoutDescription.OrderListPosPT = ILayoutDescription.selectedPositionPT.second;
            }
            else if (GD.LayoutDescription.PTOrder[1] == 2)
            {
                GD.LayoutDescription.ItemsLocListPosPT = ILayoutDescription.selectedPositionPT.second;
            }
            else if (GD.LayoutDescription.PTOrder[1] == 3)
            {
                GD.LayoutDescription.ItemsInvListPosPT = ILayoutDescription.selectedPositionPT.second;
            }
        }
        if (GD.LayoutDescription.PTOrder.Count > 2)
        {
            if (GD.LayoutDescription.PTOrder[2] == 1)
            {
                GD.LayoutDescription.OrderListPosPT = ILayoutDescription.selectedPositionPT.third;
            }
            else if (GD.LayoutDescription.PTOrder[2] == 2)
            {
                GD.LayoutDescription.ItemsLocListPosPT = ILayoutDescription.selectedPositionPT.third;
            }
            else if (GD.LayoutDescription.PTOrder[2] == 3)
            {
                GD.LayoutDescription.ItemsInvListPosPT = ILayoutDescription.selectedPositionPT.third;
            }
        }
    }
    public AbsoluteLayout GetAbsoluteLayout()
    {
        return AbsoluteLayer;
    }
    public void DebugMenuOpen()
    {
        Rect pd = new();
        pd.X = (GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() / 2) - 200;
        pd.Y = (GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() / 2) - 100;
        pd.Width = 400;
        pd.Height = 200;

        pd = _menuExtension!.CalcBounds(pd);


        string Text = loca.MAUI_UI_DEBUG_ON_INFO;

        _menuExtension!.OpenShowMenu(true, pd, false, Text);


        if (_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView != null)
        {
            SetDebugMenu(_menuExtension!.MEMenus[_menuExtension!.MEMenus.Count - 1].InnerView!);
        }
        // BlueBox.IsVisible = true;
        // AbsoluteLayout.SetLayoutBounds(BlueBox, new Rect(p3.X, p3.Y, 400, 200));
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
        pd.X = ( GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth() / 2 ) - 200;
        pd.Y = ( GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight() / 2) - 100 ;
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
    public void SetDebugMenu(Grid contextGrid)
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
        l1.Text = loca.MAUI_UI_DEBUG_ON; // "Wirklich löschen?";
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


        CreateButtonXY(ButtonGrid, loca.MAUI_UI_CME_Ok, 1, 1, DoCancel);

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