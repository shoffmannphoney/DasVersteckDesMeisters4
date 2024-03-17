using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using advtest;
using CefSharp;
using GameCore;
using Phoney_MAUI.Core;
using System.Windows;
using System.Windows.Controls;

namespace Phoney_MAUI.Model;

public delegate bool Del(Person PersonID, ParseTokenList PTL);

public delegate bool DelString(string s);

public delegate bool DelIntString(int val, string s);

public delegate bool DelMCMenuEntry(List<MCMenuEntry> MCMEntry);

public delegate bool DelMCMenuEntryBool(List<MCMenuEntry> MCMEntry, bool doRecord);

public delegate bool DelSelection(int Selection);

public delegate bool DelMCMSelection(MCMenu MCM, int Selection);

public delegate bool DelPerson(Person PersonID);

public delegate bool DelAdvObject(int ID);

public delegate bool DelVoid();

public delegate bool DelParseLineList(ParseLineList ptlSignatures);

public delegate bool DelInt(int val);

public delegate void DelDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower);

public delegate bool DelOrderList(OrderList ol);

public delegate void DelCreateOrderPath( System.Collections.ObjectModel.ObservableCollection<OrderTable> otl, int ix);

public interface IUIServices
{
    public void SetInputline(string s);
    public void SetScoreEpisode(string s);  

    public int RestartSlot { get; set; }

    public MCMenu? MCM { get; set; }

    public object MW { get; }

    public Scroller Scr { get; set; }
    public bool MCCanBeInterrupted { get; set; }

    public IGlobalData GD { get; }

    // public IUIServices(advtest.MainWindow mw, IGlobalData gd);

    public bool DoUIUpdate();

    public void HeadlineOutput(string s);

    public void ExecuteRestart(bool newList = false);

    public double GetWindowsScaling();


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

    public object Inputline { get; }
    public void SetSimpleMC();
    public void SetComplexMC();
    public bool FlushText { get; set; }
    public Phoney_MAUI.Core.FeedbackText FeedbackTextObj { get; set; }

    public void ResetStoryText();
    public void ResetFeedbackText();
    public Phoney_MAUI.Core.StoryText? StoryTextObj { get; set; }

    public advtest.MCMenuView? MCMS { get; set; }
    public MCMenu? LastMCMenu { get; set; }
    public void Close();
    public void SetScore(double cscore, double ctotalscore, double score, double totalscore, double val);

    public object ScoreEpisode { get; }

    // public static byte[] ObjectToByteArray(Object obj);
    // public static Object ByteArrayToObject(byte[] arrBytes);
    public void CoreSaveToFile(SaveObj SO, string fileName);
    public void CoreSaveToFile(string diffSavegame, string fileName);
    public SaveObj CoreLoadFromFile(string fileName);

    public string LoadString(string fileName);
    public bool SaveString(string fileName, string WriteString);
    public string CoreLoadStringFromFile(string fileName);
    // public static SaveObj CoreLoadFromFileStatic(string fileName);

    public bool ExistFile(string fileName);
    public bool WriteStory();

    public void InitPath();

    public void BackupOrdertable();
    public void LoadPicToHtml(string? picName);


    public class ZipObject
    {
        public string? Data { get; set; }
        public string? Name { get; set; }
    }


    public interface MCMenuView
    {
        public void SetMCMenuViewObj(advtest.MCMenuView mcmwObj);

        public int Instances { get; set; }

        public bool Visible { get; set; }

        public void Close();

        public void MCOutput();

        public void MCOutput(MCMenu MCM, DelMCMSelection callbackSelection, bool CanBeInterrupted);
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

        public void SetMainWindow(advtest.MainWindow MW);
    }
}

public interface IScroller
{
    public enum renderState { idle, newHeight, hmtlSet, heightGet };
    public enum _scrollphase
    {
        none,
        one,
        two,
        three,
        four
    }

    // public Scroller(advtest.MainWindow w);
    public double YPos { get; set; }
    public renderState RenderState { get; set; }
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
    public void PageDown();

    public void DoScroll();

    public void StartScrollOrder(string scrollOrder);

    public void SetScrollerToEnd(double? yPosPre);

    public void JumpToEnd();

    public void JumpToEndInstantly();

    public bool InqScrollingNeeded();

    public void InqScrollingArea();

    public void ScrollPage();


    public void SetToPos(int yPos);
    public void ResetYPos();
    public void SetToStart();
    public void ScrollPageFinal();

    public void CompactToEnd();
}

public interface IStoryText
{

    public bool FullRefresh { get; set; } 

    public bool HTMLLoaded { get; set; } 

    public string? BufferedInput { get; set; } 

    public void RecalcLatest();

    public int CurrentLinesPerTurn { get; set; } 

    public StringBuilder? WholeStory { get; set; }

    public StringBuilder? LatestStory { get; set; }

    public StringBuilder? StoryBuffer { get; set; }

    // public IStoryText(advtest.MainWindow MW, UIServices uis);

    public void RemoveEmptyDividingLine();

    public int TextStrip(string strip);

    public void TextReplace(string? stripSource, string? stripDest);
    public void TextStripMore(string s);

    public void DividingLine();

    public void ReplaceDividingLine();

    public void RemoveDividingLine();

    public void ShowMore();

    public string OldDividingLine { get; set; }
    public string OldMoreLine { get; set; }
    public List<string?>? Slines { get; set; }
    public List<string?>? SlinesBuffer { get; set; }
    public string ConvHtmlWithoutTags(string s);


    public void ExchangeAdvBrowserContent(string s, bool scrollToEnd = false);
    public void ResyncBound();

    public void AdvTextOut(bool scrollToEnd = false);

    public void AdvTextRefresh(bool scrollToEnd = false);

    public void AddSlineWholeStory(string sline, int line);
    public void AddSline(string sline, int line = -1);
    public void TextReFreshman();

    public void SetMainWindow(object MW, UIServices uis);
}
