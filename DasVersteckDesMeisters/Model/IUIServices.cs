using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Phoney_MAUI.Model;

public delegate bool DelString(string s);
public delegate bool DelIntString(int val, string s);
public delegate bool DelSelection(int Selection);
public delegate bool DelAdvObject(int ID);
public delegate bool DelDouble(double d);
public delegate bool DelVoid();
public delegate bool Del4Double( double a, double b, double c, double d);
public delegate void DelVoidSenderObject( object? o, EventArgs ea );
public delegate void DelVoidTapped( object o, Microsoft.Maui.Controls.TappedEventArgs ea );

public delegate bool DelInt(int val);
public delegate bool DelOrderList(OrderList ol);
public delegate void DelCreateOrderPath(System.Collections.ObjectModel.ObservableCollection<OrderTable> otl, int ix);
public delegate void DelVoidObject(object o);
public delegate bool DelParseLineList(ParseLineList ptlSignatures);
public delegate bool Del(Person PersonID, ParseTokenList PTL);
public delegate bool DelPerson(Person PersonID);
public delegate bool DelMCMenuEntry(List<MCMenuEntry> MCMEntry);
public delegate bool DelMCMenuEntryBool(List<MCMenuEntry> MCMEntry, bool doRecord);
public delegate bool DelMCMSelection(MCMenu MCM, int Selection);
public delegate void DelDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower);
public delegate Grid DelBoolInt(bool Activate, int Height);
public delegate void DelSelectedOutput(ILayoutDescription.selectedOutput selectedOutput);

public delegate void DelListeningMode(Phoney_MAUI.Model.IUIServices.sttListeningMode sttListeningMode);

public struct MCMVEventArgs
{
    bool IsVisible { get; set; }
}
public delegate void MCMVEventHandler(object? sender, MCMVEventArgs e);

public interface IUIServices
{
    public int RestartSlot { get; set; }
    public void SetScoreEpisode(string s);
    public void SetInputline(string s);
    public Phoney_MAUI.Core.MCMenuView? MCMenuViewObj { get; set; }

    public MCMenu? MCM { get; set; }
    public Color NewMikeColor { get; set; }

    public bool BrowserRefreshOngoing { get; set; }

    public bool MCMVVisible
    {
        get; 
        set;
    }

    public Phoney_MAUI.Core.MCMenuView? MCMV { get; set; }

    public Phoney_MAUI.Core.JSBoundObject JSBoundObject { get; set; }
    public bool MCCanBeInterrupted { get; set; }

    public enum sttListeningMode { off, on, continuous }
    public enum onBrowserContentLoaded { nothing, PageDown, ScrollToEnd, SetToEnd, unchanged }
    public onBrowserContentLoaded OnBrowserContentLoaded { get; set; }
    public sttListeningMode STTListeningOn { get; set; }
    public void STTTestRunning();
    public IGlobalData GD { get;  }

    public Phoney_MAUI.Core.FeedbackText FeedbackTextObj { get; set; }
    public int UpdateBrowserCallsPerCycle { get; set; }
    public bool UpdateBrowserBlocked { get; set; }
    public Label? HeadlineLabel { get; set; }

    public bool DoUIUpdate();

    public void HeadlineOutput(string s);

    public void ExecuteRestart(bool newList = false);

    public double GetWindowsScaling();

    public bool QuitApplication();
    public bool DoStatusSave();

    public int FlushSize();

    public int TextOutput(string? s, bool ignoreLimit = false);

    public void FlushTextOutputBuffer(int max = 10);
    public void StartTestWindow();

    public void SetTextInput();

    public void RefreshOrderList();

    public void SaveUIConfig();

    public void RefreshShowOrderList();
    public bool SetFullUIText();

    public void SetDelTextSelect(DelString Func);
    public void SetLocalUIUpdate(DelVoid Func);

    public void SetSimpleMC();
    public void SetComplexMC();
    public bool FlushText { get; set; }

    public void ResetStoryText();
    public void ResetFeedbackText();

    public void Close();
    public void RecalcPictures(bool calcOnly = false);
    public void SetScore(double cscore, double ctotalscore, double score, double totalscore, double val);

    public void CoreSaveToFile(string diffSavegame, string fileName);

    public string? LoadString(string fileName);
    public bool SaveString(string fileName, string WriteString);
    public string? CoreLoadStringFromFile(string fileName);

    public bool ExistFile(string fileName);
    public bool WriteStory();

    public void InitPath();

    public void BackupOrdertable();

    public WebViewInterop.BridgedWebView? ExternalGameOut { get; set; }
    public Phoney_MAUI.Core.StoryText? StoryTextObj { get; set; }
    public Phoney_MAUI.Core.Scroller Scr { get; set; }
    public object? MW { get; }
    public object? Inputline { get; }
    public object? ScoreEpisode { get; }

    public void CoreSaveToFile(SaveObj SO, string fileName);
    public Phoney_MAUI.Core.MCMenuView? MCMS { get; set; }
    public SaveObj? CoreLoadFromFile(string fileName);
    public MCMenu? LastMCMenu { get; set; }
    public string? _MCCallbackName { get; set; }

    public void UpdateBrowser(IUIServices.onBrowserContentLoaded doAfterLoad = IUIServices.onBrowserContentLoaded.nothing );
     void WebView1_Navigating(object? sender, WebNavigatingEventArgs e);
     void WebView1_Navigating2(object? sender, WebNavigatedEventArgs e);
   public bool DoUpdateBrowser { get; set; }

    public bool SetLanguage();
    public void SetSetLanguage(DelVoid SetLanguage);
    public void SetScoreEpisodeMethod(DelVoid method);
    public void SetScoreMethod(Del4Double method);
    public void SetMCFocusMethod(DelVoid method);
    public void InitBrowserUpdate();

    public void SetUICallback(DelVoid UICallback, DelVoid ReqUICallback);
    public void AddUICycle();
    public void FlushUICycle();
    public void ResetUICycle();
    public void FinishBrowserUpdate(IUIServices.onBrowserContentLoaded doAfterLoad = IUIServices.onBrowserContentLoaded.nothing );
    public void SetMCMVVisibleCallback(DelVoid? cb);

    public void LoadPicToHtml( string? picName );
    public string? LoadStringFromRSC(string fileName);

    public class ZipObject
    {
        public string? Data { get; set; }
        public string? Name { get; set; }
    }
    public void SaveToZip(string fileName, List<ZipObject> objects);
    public List<IUIServices.ZipObject> LoadFromZip(string fileName);
    public string RecordedText { get; set; }

    public  Task<bool> STTInqSpeech();
    public bool STTInqSpeechSync();
    public Task STTStartListening(sttListeningMode slm, string callerName = "" );
    public Task STTStopListening(bool restartMode = false);
    public DelListeningMode? STTListenigModeChangeCB { get; set; }
    public bool CacheResources(List<string> resources);
    public interface MCMenuView
    {

        public int Instances { get; set; }

        public bool Visible { get; set; }

        public void Close();

        public void MCOutput();

        // ToDo: Noch umzubauen
        public void MCOutput(MCMenu MCM, DelMCMSelection callbackSelection, bool CanBeInterrupted);
        public void MCOutputExecute();
        // public void SetMCMenuViewObj(Phoney_MAUI.Core.MCMenuView mcmwObj);
        public void CallBackMCMenuView(int id);
    }
    public interface FeedbackText
    {

        public int FeedbackOffMC { get; set; }
        public static int FeedbackSizeMC { get; set; }
        public int FeedbackCountMC { get; set; }
        public bool FeedbackModeMC { get; set; }

        public List<string> FeedbackWindowText { get; set; }
        public List<string> FeedbackWindowTextMC { get; set; }


        public void FeedbackTextOutput(string s, string? relatedText = null);


        public void FeedbackWindowInitText();

        public void FeedbackTextReFreshman();
        public void SetMainWindow(object MW);
    }
    // Muss umgebaut werden:

}

public interface IScroller
{
#if MAUI
    public bool ResetWait();
    public double HTMLViewYPos { get; set; }
    public enum scrollStep { none, settingSource, startingScript }

    public enum rescalerMode { none, delayRescale }
    public enum scrollMode { none, delaySet, delayScroll, scrollToEnd, delayJump, delayRefreshJump }
    public scrollStep ScrollStep { get; set; }
    public void SetRescale();

    public int ScrollModeCountDown { get; set; }
#else
     public renderState RenderState { get; set; }
    public double YPos { get; set; }
    public bool SetNext { get; set; }
    public bool DidCompaction { get; set; }
    public double YMaxPos { get; set; }
    public double YMaxPosClient { get; set; }
    public double YMaxPosOffset { get; set; }
    public double WinHeight { get; set; }
    public int CountWaitForScroll { get; set; }
    public bool HeightRefresh { get; set; }
    public bool ResizeRunning { get; set; }
    public bool AdaptYPos { get; set; }
    public int ScrollToEndWait { get; set; }
    public bool ScrollToEnd { get; set; }
    public bool SetToEnd { get; set; }
    public void PageUp();
    public void StartScrollOrder(string scrollOrder);
    public void SetScrollerToEnd(double? yPosPre = null);
    public void JumpToEnd();

    public void JumpToEndInstantly();
   public bool InqScrollingNeeded();
   public  bool InqScrollingArea();
   public void SetToPos(int yPos);
    public void ResetYPos();
    public void SetToStart();
    public void ScrollPageFinal();

    public void CompactToEnd();
   public void ResetWait();
#endif
    public enum _scrollphase
    {
        none,
        one,
        two,
        three,
        four
    }

   

    public void PageDown();

    public void DoScroll();


    public void ScrollPage();

    public void PageToEnd();
    public void RefreshJumpToEnd();
    public void JumpToEndInstantly();
    public void CompactToEnd();
}

public interface IStoryText
{
    public IStoryText Clone();


    public bool FullRefresh { get; set; }

    public bool HTMLLoaded { get; set; }

    public string? BufferedInput { get; set; }

    public void RecalcLatest(bool doCompact = true);

    public int CurrentLinesPerTurn { get; set; }

    public StringBuilder? WholeStory { get; set; }

    public StringBuilder? LatestStory { get; set; }

    public StringBuilder? StoryBuffer { get; set; }


    public void RemoveEmptyDividingLine();

    public int TextStrip(string strip);

    public void TextReplace(string? stripSource, string? stripDest);
    public void TextStripMore(string s);

    public void DividingLine();
    public void NotDividingLine();
    public void ParagraphsToSmall();
    public void ParagraphsToLarge();

    public void ReplaceDividingLine();

    public void RemoveDividingLine();

    public void ShowMore();

    public string? OldDividingLine { get; set; }
    public string? OldMoreLine { get; set; }
    public List<string?>? Slines { get; set; }
    public List<string?>? SlinesBuffer { get; set; }
    public string? ConvHtmlWithoutTags(string s);


    public Task ExchangeAdvBrowserContent(string s, bool scrollToEnd = false);
    public void ResyncBound();

    public void AdvTextOut(bool scrollToEnd = false);

    public void AdvTextRefresh(bool scrollToEnd = false);

    public void AddSlineWholeStory(string sline, int line);
    public void AddSline(string sline, int line = -1);
    public void TextReFreshman();

    public void SetMainWindow(object MW, IUIServices uis);

 }

public interface IGameDefinitions
{
    public enum mcvMode { none, persistent, temporary };
    public mcvMode MCVisible { get; set; }
    public IGlobalData.picMode PicMode { get; set; }
    public bool STTContinuous { get; set; }


    public string? CurrentEventName { get; set; }
    public int IxCurrent { get; set; }
    public int ActLocEvent { get; set; }
    public int ActLocEventSeqStart { get; set; }
    public int ActLocEventStartPoint { get; set; }
    public int LastLocEventStartPoint { get; set; }
    public bool ActLocCollecting { get; set; }
    public int LastLoc { get; set; }
    public int ActLoc { get; set; }

}
