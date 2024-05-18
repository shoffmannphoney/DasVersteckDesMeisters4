using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Phoney_MAUI.Core;
using Phoney_MAUI.Menu;
using Phoney_MAUI.Game;
using Phoney_MAUI.Model;

namespace Phoney_MAUI.Game.General;

public class MainViewModel : BaseViewModel
{
    private readonly IGlobalSpecs? _globalSpecs;
    private readonly IGlobalData? _globalData;
    private readonly INavigationService? _navigationService;

    public ICommand LoadDataCommand { get; }
    public ICommand SelectThemeCommand { get; }
    public ICommand SelectFontCommand { get; }
    public ICommand SelectFontSizeCommand { get; }
    public ICommand SelectReplayCommand { get; }
    public ICommand SelectGlobalMenuCommand{ get; }

    public MainViewModel(IGlobalSpecs globalSpecs)
    {
        _globalSpecs = globalSpecs;
        _globalData = globalSpecs.GetGlobalData();
        _navigationService = new NavigationService();

        LoadDataCommand = new Command(async () => await LoadData());
        Title = "Start";
        SelectThemeCommand = new Command<ThemeInfo>(SelectTheme);
        SelectFontCommand = new Command<FontInfo>(SelectFont);
        SelectFontSizeCommand = new Command<FontSizeInfo>(SelectFontSize);
        SelectReplayCommand = new Command<ReplayInfo>(SelectReplay);
        SelectGlobalMenuCommand = new Command(SelectGlobalMenu);

        SelectedTheme = (ResourceDictionary) new Resources.Styles.ThemeI();
        SelectedReplay = _globalSpecs.GetCurrentReplayInfo();

        GlobalSpecs.CurrentGlobalSpecs!.AppRunning = IGlobalSpecs.appRunning.running;
    }

    public ReplayInfo? SelectedReplay { get; set; }
    public ResourceDictionary? SelectedTheme { get; set; } 
    public ObservableCollection<ThemeInfo> Themes { get; } = new ObservableCollection<ThemeInfo>();
    public ObservableCollection<FontInfo> Fonts { get; } = new ObservableCollection<FontInfo>();
    public ObservableCollection<FontSizeInfo> FontSizes { get; } = new ObservableCollection<FontSizeInfo>();
    public ObservableCollection<ReplayInfo> ReplayList { get; } = new ObservableCollection<ReplayInfo>();

    public void SelectTheme(ThemeInfo ti)
    {
        ResourceDictionary rd = new Resources.Styles.ThemeA();

        if ( ti.Id == 1)
            rd = new Resources.Styles.ThemeA();
        else if (ti.Id == 2)
            rd = new Resources.Styles.ThemeB();
        else if (ti.Id == 3)
            rd = new Resources.Styles.ThemeC();
        else if (ti.Id == 4)
            rd = new Resources.Styles.ThemeD();
        else if (ti.Id == 5)
            rd = new Resources.Styles.ThemeE();
        else if (ti.Id == 6)
            rd = new Resources.Styles.ThemeF();
        else if (ti.Id == 7)
            rd = new Resources.Styles.ThemeG();
        else if (ti.Id == 8)
            rd = new Resources.Styles.ThemeH();
        else if (ti.Id == 9)
            rd = new Resources.Styles.ThemeI();


        AppShell._mainAppShell!.ChangeTheme(rd);

        SelectedTheme = rd;
         _globalSpecs!.SetCurrentTheme(ti);

    }


    public void SelectFont(FontInfo fi)
    {
        ResourceDictionary rd = new Resources.Styles.FontOpenSans();

        if (fi.Id == 1)
            rd = new Resources.Styles.FontOpenSans();
        else if (fi.Id == 2)
            rd = new Resources.Styles.FontVerdana();
        else if (fi.Id == 3)
            rd = new Resources.Styles.FontRaleway();
        else if (fi.Id == 4)
            rd = new Resources.Styles.FontTimesNewRoman();
        // else if (fi.Id == 5)
        //     rd = new Resources.Styles.FontItalianno();
        else if (fi.Id == 5)
            rd = new Resources.Styles.FontBrushScript();
        else if (fi.Id == 6)
            rd = new Resources.Styles.FontCourier();

        AppShell._mainAppShell!.ChangeFont(rd);

        _globalSpecs!.SetCurrentFont(fi);

    }
    public void SelectFontSize(FontSizeInfo fsi)
    {
        ResourceDictionary rd = new Resources.Styles.FontSizeVerySmall();
 
        if (fsi.Id == 1)
            rd = new Resources.Styles.FontSizeVerySmall();
        else if (fsi.Id == 2)
            rd = new Resources.Styles.FontSizeSmall();
        else if (fsi.Id == 3)
            rd = new Resources.Styles.FontSizeMedium();
        else if (fsi.Id == 4)
            rd = new Resources.Styles.FontSizeBig();
        else if (fsi.Id == 5)
            rd = new Resources.Styles.FontSizeVeryBig();

        AppShell._mainAppShell!.ChangeFontSize(rd);

        _globalSpecs!.SetCurrentFontSize(fsi);

    }

    public void SelectReplay(ReplayInfo ri)
    {
        // _globalSpecs.GetCurrentReplayInfo().RefreshBeforeSelectionChange();
        _globalSpecs!.SetCurrentReplayInfo(ri);
        // _globalSpecs.GetCurrentReplayInfo().RefreshAfterSelectionChange();

        ri.Val++;
        // await LoadReplay();

    }

    public async void SelectGlobalMenu( )
    {
        IGlobalData.globalMenu state = IGlobalData.globalMenu.open;

        if (_globalData!.GlobalMenu == IGlobalData.globalMenu.open)
            state = IGlobalData.globalMenu.closed;

        _globalData.GlobalMenu = state;
    }

    private async Task LoadFontSize()
    {
        try
        {
            FontSizes.Clear();
            ObservableCollection<FontSizeInfo>? fsis = _globalSpecs!.GetFontSizeInfo();

            foreach (var fsi in fsis!)
            {
                FontSizes.Add(fsi);
            }

        }
        finally
        {
        }
    }

    private async Task LoadReplay()
    {
        try
        {
            ReplayList.Clear();
            ObservableCollection<ReplayInfo>? ri = _globalSpecs!.GetReplayList();

            foreach (var ri2 in ri!)
            {
                ri2.Val++;
                ReplayList.Add(ri2);
            }
        }
        finally
        {

        }
    }

    private async Task LoadData()
    {
        try
        {
            IsBusy = true;
            Themes.Clear();

            ObservableCollection<ThemeInfo>? tis = (ObservableCollection<ThemeInfo>) _globalSpecs!.GetThemeInfo()!;

            foreach (var ti in tis!)
            {
                Themes.Add(ti);
            }

            Fonts.Clear();
            ObservableCollection<FontInfo>? fis = _globalSpecs.GetFontInfo();

            foreach (var fi in fis!)
            {
                Fonts.Add(fi);
            }

            await LoadFontSize();


            await LoadReplay();
        }
        finally
        {
            IsBusy = false;
        }
    }

    public void NavigateTo( string s )
    {
        // await AnimatedContainer.FadeTo(0, 100); await _navigationService.GoToAsync(s, false);

        Task t = _navigationService!.GoToAsync( "//"+s, false);
    }

    bool initialized = false;

    public override async Task Initialize()
    {
        if (initialized == false)
        {
            await LoadData();
            await base.Initialize();

            initialized = true;
        }
    }
}
