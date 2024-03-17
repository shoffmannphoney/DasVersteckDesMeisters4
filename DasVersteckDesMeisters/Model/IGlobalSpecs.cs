using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoney_MAUI.Core;
using GameCore;

namespace Phoney_MAUI.Model;

public interface ILayoutDescription
{
    public IGlobalData.screenMode ScreenMode { get; set; }

    public bool LU_Order { get; set; }
    public bool LU_ItemLoc { get; set; }
    public bool LU_ItemInv { get; set; }

    public bool LD_Order { get; set; }
    public bool LD_ItemLoc { get; set; }
    public bool LD_ItemInv { get; set; }

    public bool RU_Order { get; set; }
    public bool RU_ItemLoc { get; set; }
    public bool RU_ItemInv { get; set; }

    public bool RD_Order { get; set; }
    public bool RD_ItemLoc { get; set; }
    public bool RD_ItemInv { get; set; }

    public double ColumLeftWidth { get; set; }
    public double ColumRightWidth { get; set; }

    public double RowLeftUpHeight { get; set; }
    public double RowRightUpHeight { get; set; }

    public double PortraitColumnsHeight { get; set; }

    public double PortraitColumn1Width { get; set; }
    public double PortraitColumn2Width { get; set; }
    public enum ParagraphClusters { none, latest, all }

    public enum PortraitColumn { none, order, itemloc, iteminv }

    public ParagraphClusters ParagraphClusterMode { get; set; }
    public List<PortraitColumn> PortraitColumns { get; set; }
    public bool SetLeftColumnWidth( double val);
    public bool SetRightColumnWidth(double val);
    public enum selectedOutput { input, mc, more };
    public enum selectedPosition { off, leftUp, leftDown, rightUp, rightDown };
    public enum selectedPositionPT { off, first, second, third };

    public selectedPosition OrderListPos { get; set; }
    public selectedPosition ItemsLocListPos { get; set; }
    public selectedPosition ItemsInvListPos { get; set; }
    public ILayoutDescription.selectedPositionPT OrderListPosPT { get; set; }
    public ILayoutDescription.selectedPositionPT ItemsLocListPosPT { get; set; }
    public ILayoutDescription.selectedPositionPT ItemsInvListPosPT { get; set; }

    public double WinWidth { get; set; }
    public double WinHeight { get; set; }
    public double WinX { get; set; }
    public double WinY { get; set; }
    public List<int> PTOrder { get; set; }

    public enum eClickMargin { very_low, low, medium, high, very_high }

    public eClickMargin ClickMargin { get; set; }
}

public interface IGlobalData
{
    public double[] DebugVal { get; set; }

    public enum picMode { off, small, medium, big };
    public enum localMenu { none, home, game, settings, replay, credits, end }
    public enum globalMenu { closed, open, closing, opening }
    public enum screenMode { unclear, portrait, landscape }
    public enum microMode { off, once, continuous }
    public delegate void _callbackResize(double width, double height);
    public delegate void _callbackChangeOrientation(screenMode sm);
    public delegate void _setGlobalMenuState(globalMenu gms);
    public delegate void _setLocalMenuState(localMenu lm);
    public DelBoolInt? ProvideMCGrid { get; set; }
    public DelBoolInt? ProvideMoreGrid { get; set; }
    public void SetDelProvideMCGrid( DelBoolInt DoProvideMCGrid);
    public void SetDelProvideMoreGrid(DelBoolInt DoProvideMCGrid);
    public void SetCallbackResize(_callbackResize callbackResize);
    public void SetCallbackChangeOrientation(_callbackChangeOrientation callbackChangeOrientation);
    public void DoResize(double width, double height);
    public IGlobalData.microMode STTMicroState { get; set; }

    public DelSelectedOutput? SelectOutput { get; set; }
    public picMode PicMode { get; set; }

    public void SetDelSelectOutput(DelSelectedOutput DoSelectOutput);
    public ILayoutDescription LayoutDescription { get; set; }

    public void SetSetGlobalMenuState(IGlobalData._setGlobalMenuState setGlobalMenuState);
    public IGlobalData.globalMenu GlobalMenu { get; set; }
    public IGlobalData.localMenu LocalMenu { get; set; }
    public string? CurrentContent { get; set; }
    public bool MCAsContextmenu { get; }
    public bool InitProcess { get; set; }
    public Task<bool> LoadData();
    public Entry? Inputline { get; set; }
    public GameCore.OrderList? OrderList 
    {
        get => (GameCore.OrderList?) GlobalSpecs.CurrentOrderList;
    }
    public bool SilentMode { get; set; }

    public language Language { get; set; }
    public enum language { german, english }

    public SaveObj? StartStatus { get; set; }
    public byte[]? StartStatusSerialized { get; set; }
    public int OrderListFinalIx { get; set; }
    public bool UseMoreBuffer { get; set; }
    public bool SimpleMC { get; set; }
    public bool Highlighting { get; set; }
    public bool DebugMode { get; set; }
    public int DebugCount { get; set; }

    public bool Brief { get; set; }

    public bool LastCommandSucceeded { get; set; }

    public bool ValidRun { get; set; }

    public bool InterruptedDialog { get; set; }

    public bool FeedbackWindow { get; set; }

    public int InteruptedDialogID { get; set; }

    public bool InterruptedDialogCanBeInterruped { get; set; }

    public string? HTMLStyle { get; set; }
    public string? HTMLPageShort { get; set; }
    public string? HTMLPageLoc { get; set; }
    public string? HTMLPage { get; set; }
    public string? HTMLMoreEng { get; set; }
    public string? HTMLMore { get; set; }
    public string? HTMLPageDivide { get; set; }

    public string? HTMLPageNotDivide { get; set; }

    public bool UISuppressed { get; set; }

    public void InitRandom(int num);

    public int RandomNumber(int min, int max);

    public void ResetLanguageCallbacks();
    public void AddLanguageCallback(DelVoid method);

    public string? LastRunResult { get; set; }
    public bool AskForPlayLevel { get; set; }
    public int AskForPlayLevelCount { get; set; }
    public bool RenameZipOrderTableEntry(string oldName, string newName);
    public string? JSSelectionText { get; set; }
    public Phoney_MAUI.Core.Version Version { get; set; }
    public Phoney_MAUI.Core.SlotDescription SlotDescriptions { get; set; }


    public Phoney_MAUI.Model.DelMCMSelection? InterruptedDialogMCMSelection { get; set; } 

    public MCMenu? InterruptedDialogMCM { get; set; }
    public Adv? Adventure { get; set; }
    public IUIServices? UIS { get; set; }
    public Phoney_MAUI.Menu.MenuExtension? MenuExtension { get; set; }
    public List<Phoney_MAUI.Model.DelVoid>? _languageCallbacks { get; set; }

}
public interface IGlobalSpecs
{
    // enum screenMode { unclear, portrait, landscape}
    enum initRunning { initialstate, started, finished }

    public initRunning InitRunning { get; set; }
    public void CheckSize(double width, double height);
    
    public enum appRunning { start, running, quit }
    public appRunning AppRunning { get; set; }

    public IGlobalData? GetGlobalData();
    public ObservableCollection<ThemeInfo>? GetThemeInfo();
    public ObservableCollection<FontInfo>? GetFontInfo();
    public ObservableCollection<FontSizeInfo>? GetFontSizeInfo();
    public ObservableCollection<ReplayInfo>? GetReplayList();
    public ILayoutDescription.eClickMargin GetClickMargin();
    public double GetClickMarginPixel();
    public double GetScreenWidth();
    public double GetScreenHeight();

    public IGlobalData.screenMode GetScreenMode();
    public ThemeInfo? GetCurrentTheme();
    public void SetCurrentTheme(ThemeInfo ti);
    public void SetCurrentFont(FontInfo fi);
    public void SetCurrentFontSize(FontSizeInfo fsi);
    public void SetCurrentReplayInfo(ReplayInfo ri);
    public ReplayInfo? GetCurrentReplayInfo();

    public static IOrderList? CurrentOrderList { get; }

    public double ScaleFactor { get; }
    public void SetCurrentPage(ContentPage cp);
 }


public interface ISlotDescription
{

    public List<string>? SlotDescriptions { get; set; }

    public void Init();

}