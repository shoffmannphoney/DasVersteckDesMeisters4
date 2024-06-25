using System;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Text.Json;
using Phoney_MAUI.Model;
using Phoney_MAUI.Platform;
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Maui.Media;
using CommunityToolkit.Maui.Behaviors;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using GameCore;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO.Compression;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
// using Microsoft.UI.Xaml.Controls;

namespace Phoney_MAUI.Core;

public static class Dingens
{
    public static byte[] ReadAllBytes(this BinaryReader reader)
    {
        const int bufferSize = 4096;
        using (var ms = new MemoryStream())
        {
            byte[] buffer = new byte[bufferSize];
            int count;
            while ((count = reader.Read(buffer, 0, buffer.Length)) != 0)
                ms.Write(buffer, 0, count);
            return ms.ToArray();
        }

    }

}


[Serializable]
public class UIServices : IUIServices
{
    GlobalData? _gd;
    GlobalSpecs? _gs;
    public int RestartSlot { get; set; }
    public object? Inputline { get; }
    public object? ScoreEpisode { get; }

    // public MCMenu? MCM { get; set; }
    private DelVoid? LocalUIUpdate;
    private DelVoid? _setScoreEpisodeMethod;
    private DelVoid? _setMCFocusMethod;
    private Del4Double? _setScoreMethod;
    private Phoney_MAUI.Core.MCMenuView? _mcmv;
    public string? _MCCallbackName { get; set; }
    public Phoney_MAUI.Core.MCMenuView? MCMV 
    {
        get => _mcmv; 
        set
        {
            _mcmv = value;
        }
    }
    public Phoney_MAUI.Core.MCMenuView? MCMenuViewObj { get; set; }
    public DelListeningMode? STTListenigModeChangeCB { get; set; }
    public bool MCCanBeInterrupted { get; set; }
    public Phoney_MAUI.Core.StoryText? StoryTextObj { get; set; }
    public Scroller Scr { get; set; }
    public object? MW { get; }
    public Label? HeadlineLabel { get; set; }
    public IUIServices.onBrowserContentLoaded OnBrowserContentLoaded { get; set; } 

    private MCMenu? mcmX;
    public MCMenu? MCM
    {
        get => mcmX;
        set
        {
            mcmX = value;

        }
    }

    public IGlobalData GD 
    { 
        get => (IGlobalData) _gd!;
        set => _gd = (GlobalData)value!;
    }
    public IGlobalSpecs GS
    {
        get => (IGlobalSpecs)_gs!;
        set => _gs = (GlobalSpecs)value!;
    }
    public MCMenuView? MCMS { get; set; }

    public DelVoid? MCMVVisibleCallback;

    private bool _browserRefreshOngoing = false;
    public bool BrowserRefreshOngoing
    {
        get => _browserRefreshOngoing;
        set => _browserRefreshOngoing = value;
    }
    private bool _mcmvVisible;
    public bool MCMVVisible
    {
        get => _mcmvVisible;
        set
        {
            _mcmvVisible = value;
            if( MCMVVisibleCallback != null )
            {
                MCMVVisibleCallback();
            }
        }
    }

    public void SetMCMVVisibleCallback( DelVoid? cb )
    {
        MCMVVisibleCallback = cb;
    }
    public FeedbackText FeedbackTextObj { get; set; }
    public WebViewInterop.BridgedWebView? ExternalGameOut { get; set; }

    public JSBoundObject JSBoundObject { get; set; }

    public int UpdateBrowserCallsPerCycle { get; set; }
    public UIServices( )
    {
        try
        {
            GD = GlobalData.CurrentGlobalData!;
            GS = GlobalSpecs.CurrentGlobalSpecs!;

            NewMikeColor = Colors.Brown;
            RecordedText = "";

            this.FeedbackTextObj = new();
            this.FeedbackTextObj.FeedbackModeMC = false;
            this.Scr = new(this);
            this.StoryTextObj = new StoryText(this);
            this.JSBoundObject = new();
            this.JSBoundObject.UIS = this;

            if (GD != null)
                loca.GD!.AddLanguageCallback(SetLanguage);
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("UIServices Constructor: " + ex.Message, IGlobalData.protMode.crisp);
        }

    }

    private DelVoid? _setLanguage;

    public bool SetLanguage()
    {
        try
        {
            if (_setLanguage != null)
                _setLanguage();
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("SetLanguage: " + ex.Message, IGlobalData.protMode.crisp);
        }
        return true;
    }

    public void SetScoreEpisodeMethod( DelVoid method )
    {
        _setScoreEpisodeMethod = method;
    }
    public void SetSetLanguage(DelVoid SetLanguage)
    {
        this._setLanguage = SetLanguage;
    }
    public void SetMCFocusMethod( DelVoid method )
    {
        _setMCFocusMethod = method;
    }


    private DelVoid? _uiCallback;
    private DelVoid? _reqUICallback;
    private int _uiCount = 0;
    public void SetUICallback(DelVoid UICallback, DelVoid ReqUICallback)
    {
        this._uiCallback = UICallback;
        this._reqUICallback = ReqUICallback;
    }

    public void AddUICycle()
    {
        _uiCount++;
    }

    public void FlushUICycle()
    {
        try
        {
            if (_uiCount > 0 && _reqUICallback != null)
            {
                _uiCount = 0;
                _reqUICallback();
            }
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("FlushUICycle: " + ex.Message, IGlobalData.protMode.crisp);
        }

    }

    public void ResetUICycle()
    {
        _uiCount = 0;
    }

    public bool DoUpdateBrowser { get; set; }
    public void SetInputline( string s )
    {

        // Eingabezeile auf "" setzen
    }
    public void SetScoreEpisode(string s)
    {
        try
        {
            if (_setScoreEpisodeMethod != null)
            {
                _setScoreEpisodeMethod();
            }
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("SetScoreEpisode: " + ex.Message, IGlobalData.protMode.crisp);
        }

        // Eingabezeile auf "" setzen
    }

    public void SetLocalUIUpdate(DelVoid Func)
    {
        LocalUIUpdate = Func;
    }
    public void RecalcPictures( bool calcOnly = false )
    {
        try
        {
            if (ExternalGameOut == null)
                return;
            int endLine = StoryTextObj!.Slines!.Count - 100;
            if (endLine < 0)
                endLine = 0;

            for (int Line = StoryTextObj.Slines!.Count - 1; Line >= endLine; Line--)
            {
                string searchString = "<center><img src=\"";
                if (StoryTextObj.Slines?[Line]?.Contains(searchString) == true)
                {
                    int pos;
                    int posEnd;
                    string fName;

                    posEnd = (int)StoryTextObj.Slines?[Line]?.IndexOf("\"", searchString.Length, StoryTextObj.Slines[Line]!.Length - searchString.Length)!;
                    fName = StoryTextObj.Slines?[Line]!.Substring(searchString.Length, posEnd - searchString.Length)!;

                    pos = (int)StoryTextObj.Slines?[Line]?.IndexOf("width=", 0, StoryTextObj.Slines[Line]!.Length)! + 7;
                    posEnd = pos + 1;
                    if (pos >= 0)
                    {
                        posEnd = ((int)StoryTextObj.Slines?[Line]?.IndexOf("\"", pos, 10)!)!;
                    }
                    int pWidth = Int32.Parse(StoryTextObj.Slines?[Line]?.Substring(pos, posEnd - pos)!);

                    pos = (int)StoryTextObj.Slines?[Line]?.IndexOf("height=", 0, StoryTextObj.Slines[Line]!.Length)! + 8;
                    if (pos >= 0)
                    {
                        posEnd = ((int)StoryTextObj.Slines?[Line]?.IndexOf("\"", pos, 10)!);
                    }
                    int pHeight = Int32.Parse(StoryTextObj.Slines?[Line]?.Substring(pos, posEnd - pos)!);

                    int perCent = 20;
                    if (GD.LayoutDescription.PicMode == IGlobalData.picMode.medium) perCent = 40;
                    if (GD.LayoutDescription.PicMode == IGlobalData.picMode.big) perCent = 60;


                    int pWidthNew = (int)((ExternalGameOut.Width * perCent) / 100);
                    int pHeightNew = (int)((pWidthNew * 9) / 16);
                    string sResult = String.Format("<center><img src=\"{0}\" width=\"{1}\" height=\"{2}\"  align=\"middle\"/> </center>", fName, pWidthNew, pHeightNew);

                    StoryTextObj.Slines![Line] = sResult;
                }

            }

            if (!calcOnly)
            {
                StoryTextObj.RecalcLatest(false);
                GD.CurrentContent = StoryTextObj.LatestStory!.ToString();
                // InitBrowserUpdate();
                FinishBrowserUpdate();
            }
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("RecalcPictures: " + ex.Message, IGlobalData.protMode.crisp);
        }

    }
    public void LoadPicToHtml(string? picName)
    {
        try
        {
            if (GD.LayoutDescription.PicMode != IGlobalData.picMode.off && picName != null)
            {
                int pHeight, pWidth;
                if (ExternalGameOut != null)
                {
                    pWidth = (int)((ExternalGameOut.Width* 20) / 100);
                    pHeight = (int)((ExternalGameOut.Width * 9) / 16);
                    if (GD.LayoutDescription.PicMode == IGlobalData.picMode.medium)
                    {
                        // size = "400";
                        pWidth = (int)((ExternalGameOut.Width * 40) / 100);
                        pHeight = (int)((pWidth * 9) / 16);
                    }
                    if (GD.LayoutDescription.PicMode == IGlobalData.picMode.big)
                    {
                        // size = "800";
                        pWidth = (int)((ExternalGameOut.Width * 60) / 100);
                        pHeight = (int)((pWidth * 9) / 16);
                    }
                }
                else
                {
                    double pWidth2 = GlobalSpecs.CurrentGlobalSpecs.GetScreenWidth();
                    double pHeight2 = GlobalSpecs.CurrentGlobalSpecs.GetScreenHeight();
                    pWidth = (int)((pWidth2 * 20) / 100);
                    pHeight = (int)((pWidth * 9) / 16);


                    if (GD.LayoutDescription.PicMode == IGlobalData.picMode.medium)
                    {
                        // size = "400";
                        pWidth = (int)((pWidth2 * 40) / 100);
                        pHeight = (int)((pWidth * 9) / 16);
                    }
                    if (GD.LayoutDescription.PicMode == IGlobalData.picMode.big)
                    {
                        // size = "800";
                        pWidth = (int)((pWidth2 * 60) / 100);
                        pHeight = (int)((pWidth * 9) / 16);
                    }
                }
                // string size = "100";

                string s1 = picName; //  this.Find(locationID)!.LocPicture!;


                    // string s = string.Format( "<center><img src=\"localfolder:./{0}\" width=\"{1}\" align=\"middle\" /> </center>", this.Find( locationID ).LocPicture, size );
                    // GD.Adventure!.StoryOutput("<img src=\"http://localhost:8000/l015.jpg\" width=\"50%\" height=\"50%\"/img");

#if WINDOWS
                // string s = string.Format("<center><img src=\"ms-appx-web:///Resources/Images/{0}\" width=\"{1}\" height=\"{1}\" align=\"middle\" /img></center>", s1, size);
                string s = string.Format("<center><img src=\"http://localhost:8000/{0}\" width=\"{1}\" height=\"{2}\"  align=\"middle\" /> </center>", s1, pWidth, pHeight);
                // string s = string.Format("<center><img src=\"http://localhost:8000/{0}\" width=\"{1}\" height=\"{1}\" align=\"middle\" /> </center>", s1, size);
#elif ANDROID
                    //         CurrentContent += "<img src=\"l012.jpg\" width=\"50%\" height=\"50%\"/img>";

                    // string s = string.Format("<center><img src='drawable/{0}' width=\"{1}\" height=\"{2}\" align=\"middle\" /img></center>", s1, pWidth, pHeight);

                    string s = string.Format("<center><img src='file:///" + Phoney_MAUI.Platform.DeviceData._deviceData!.GetSavePath() + "/{0}' width=\"{1}\" height=\"{2}\" align=\"middle\" /img></center>", s1, pWidth, pHeight);
#else

            string s = "Fick dich";
#endif
                    // <img src=\"l012.jpg\" width=\"50%\" height=\"50%\"/img>
                    GD!.Adventure!.StoryOutput(s);

                /*
                else
                {
                    int pHeight, pWidth;
#if ANDROID
                    string size = "20%";
#endif
                    pWidth = (int)((100 * 20) / 100);
                    pHeight = (int)((pWidth * 9) / 16);
                    if (GD.LayoutDescription.PicMode == IGlobalData.picMode.medium)
                    {
#if ANDROID
                        size = "40%";
#endif
                        pWidth = (int)((100 * 40) / 100);
                        pHeight = (int)((pWidth * 9) / 16);
                    }
                    if (GD.LayoutDescription.PicMode == IGlobalData.picMode.big)
                    {
#if ANDROID
                        size = "60%";
#endif
                        pWidth = (int)((100 * 60) / 100);
                        pHeight = (int)((pWidth * 9) / 16);
                    }

                    string s1 = picName; //  this.Find(locationID)!.LocPicture!;


                    // string s = string.Format( "<center><img src=\"localfolder:./{0}\" width=\"{1}\" align=\"middle\" /> </center>", this.Find( locationID ).LocPicture, size );
                    // GD.Adventure!.StoryOutput("<img src=\"http://localhost:8000/l015.jpg\" width=\"50%\" height=\"50%\"/img");

#if WINDOWS
                string s = string.Format("<center><img src=\"http://localhost:8000/{0}\" width=\"{1}\" height=\"{2}\"  align=\"middle\" /> </center>", s1, pWidth, pHeight);
                // string s = string.Format("<center><img src=\"http://localhost:8000/{0}\" width=\"{1}\" height=\"{1}\" align=\"middle\" /> </center>", s1, size);
#elif ANDROID
                    //         CurrentContent += "<img src=\"l012.jpg\" width=\"50%\" height=\"50%\"/img>";

                    string s = string.Format("<center><img src=\"{0}\" width=\"{1}\" height=\"{1}\" align=\"middle\" /img></center>", s1, size);
#else
            string s = "Fick dich";
#endif
                    // <img src=\"l012.jpg\" width=\"50%\" height=\"50%\"/img>
                    GD!.Adventure!.StoryOutput(s);

                }
                */
            }
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("LoadPicToHtml: " + ex.Message, IGlobalData.protMode.crisp);
        }


    }

    public bool CacheResources(List<string> resources)
    {
        try
        {
            var assembly = Assembly.GetExecutingAssembly();

            bool loaded = true;

            foreach (string rscName in resources)
            {
                using var stream = assembly.GetManifestResourceStream("DasVersteckDesMeisters.Resources.Raw." + rscName);
                var filePath = Path.Combine(Phoney_MAUI.Platform.DeviceData._deviceData!.GetSavePath(), rscName);
                if (File.Exists(filePath) == true)
                    return false;

                using var fileStream = File.Create(filePath);
                stream!.CopyTo(fileStream);
                stream!.Close();
                fileStream.Close();

            }
            return loaded;
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("CacheResources: " + ex.Message, IGlobalData.protMode.crisp);
            return false;
        }

    }

    public bool DoUIUpdate()
    {
        try
        {
            if (LocalUIUpdate != null)
            {


                LocalUIUpdate();
            }
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("DoUIUpdate: " + ex.Message, IGlobalData.protMode.crisp);
        }

        return true;
    }

    public void HeadlineOutput(string s)
    {
        if( HeadlineLabel != null )
        {
            HeadlineLabel.Text = s;
        }
    }

    public void DoMCRestart(bool newList = false)
    {
        try
        {
            StoryTextObj = new StoryText(this);
            FeedbackTextObj.FeedbackWindowTextMC = new List<string>();
            FeedbackTextObj.FeedbackWindowText = new List<string>();

            GC.Collect();

            {
                if (GD.Adventure != null)
                    Adv.CleanupAdv(GD.Adventure);
                GD.Adventure = null!;
                GD.Adventure = new Adv(true, false);
                GD.AskForPlayLevel = true;
                GD.AskForPlayLevelCount = 1;
                GD.Adventure!.Orders!.ReadSlotDescription();
            }
            GC.Collect();

            if (newList == true)
            {
                GD.OrderList!.AddOrderList(loca.CustomRequestHandler_DoMCRestart_16295);
                GD.OrderList!.CurrentOrderListIx = GD!.OrderList!.OTL!.Count - 1;
            }

            StoryTextObj.RecalcLatest();
            StoryTextObj.AdvTextRefresh();
            StoryTextObj.TextReFreshman();
            InitBrowserUpdate();
            FinishBrowserUpdate(IUIServices.onBrowserContentLoaded.PageDown);
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("DoMCRestart: " + ex.Message, IGlobalData.protMode.crisp);
        }

    }

    public void ExecuteRestart(bool newList = false)
    {
        DoMCRestart(newList);

    }



    public double GetWindowsScaling()
    {
        return 0;
    }



    public int FlushSize()
    {
        return 0;
    }


    public int TextOutput(string? s, bool ignoreLimit = false)
    {
        try
        {
            int lines = 0;

            // Noloca: 002
            if (s != null)
                s = s.Replace("<br>", "</p><p class=\"para\" style=\"margin-bottom:2px;margin-top:0px\" >");
            if (StoryTextObj != null)
            {
                // Logik für More-Buffer wurde entfernt = nicht benötigt

                // Experimental: Wert habe ich hier eingetragen, weil MeasureString() sich ohne Skalierung einen ganz schönen Mist zusammenrechnet.
                double xScale = GS.ScaleFactor; //  GetWindowsScaling();
                StoryTextObj!.Slines!.Add(Helper.FirstUpper(s));
                if (StoryTextObj.WholeStory != null)
                {
                    StoryTextObj!.AddSlineWholeStory(StoryTextObj!.Slines[StoryTextObj!.Slines!.Count - 1]!, StoryTextObj!.Slines.Count - 1);
                }
                if (StoryTextObj!.LatestStory != null && GD.SilentMode == false)
                {
                    StoryTextObj!.AddSline(StoryTextObj!.Slines[StoryTextObj!.Slines.Count - 1], StoryTextObj!.Slines.Count - 1);
                }

                if (GD.SilentMode == false)
                    StoryTextObj!.TextReFreshman();
            }
            return lines;
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("TextOutput: " + ex.Message, IGlobalData.protMode.crisp);
            return 0;
        }

    }

    public void FlushTextOutputBuffer(int max = 10)
    {
    }

    public void StartTestWindow()
    {
    }


    public void SetTextInput()
    {
        try
        {
            GD!.LayoutDescription.OrderListPos = ILayoutDescription.selectedPosition.off;
            GD!.LayoutDescription.ItemsInvListPos = ILayoutDescription.selectedPosition.off;
            GD!.LayoutDescription.ItemsLocListPos = ILayoutDescription.selectedPosition.off;

            GD.LayoutDescription.OrderListPosPT = ILayoutDescription.selectedPositionPT.off;
            GD.LayoutDescription.ItemsInvListPosPT = ILayoutDescription.selectedPositionPT.off;
            GD.LayoutDescription.ItemsLocListPosPT = ILayoutDescription.selectedPositionPT.off;

            LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription;
            ld.LU_Order = false;
            ld.LU_ItemLoc = false;
            ld.LU_ItemInv = false;
            ld.LD_Order = false;
            ld.LD_ItemLoc = false;
            ld.LD_ItemInv = false;
            ld.RU_Order = false;
            ld.RU_ItemLoc = false;
            ld.RU_ItemInv = false;
            ld.RD_Order = false;
            ld.RD_ItemLoc = false;
            ld.RD_ItemInv = false;

            DoUIUpdate();
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("SetTextInput: " + ex.Message, IGlobalData.protMode.crisp);
        }

    }


    public void RefreshOrderList()
    {
        try
        {
            if (GD!.OrderList!.OTL![GD!.OrderList!.CurrentOLIndex].Zipped)
            {
                GD.OrderList.ReadZipOrderTable(GD!.OrderList!.CurrentOLIndex, GD!.OrderList!.OTL![GD!.OrderList!.CurrentOLIndex].Name!);

            }
            ObservableCollection<OrderTable>? ot = GD!.OrderList!.OTL[GD!.OrderList!.CurrentOLIndex].OT;

            for (int ix = 0; ix < ot!.Count; ix++)
            {
                ot[ix].No = ix + 1;
            }
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("RefreshOrderList" + ex.Message, IGlobalData.protMode.crisp);
        }


    }


    public void SaveUIConfig()
    {
    }


    public void RefreshShowOrderList()
    {
    }

    public bool SetFullUIText()
    {
        return true;
    }


    public void SetDelTextSelect(DelString Func)
    {
    }


    public void SetSimpleMC()
    {
        try
        {
            GD.LayoutDescription.SimpleMC = true;

            GD!.LayoutDescription.OrderListPos = ILayoutDescription.selectedPosition.rightUp;
            GD!.LayoutDescription.ItemsInvListPos = ILayoutDescription.selectedPosition.rightUp;
            GD!.LayoutDescription.ItemsLocListPos = ILayoutDescription.selectedPosition.rightUp;

            GD.LayoutDescription.OrderListPosPT = ILayoutDescription.selectedPositionPT.first;
            GD.LayoutDescription.ItemsInvListPosPT = ILayoutDescription.selectedPositionPT.first;
            GD.LayoutDescription.ItemsLocListPosPT = ILayoutDescription.selectedPositionPT.first;

            LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription;
            ld.LU_Order = false;
            ld.LU_ItemLoc = false;
            ld.LU_ItemInv = false;
            ld.LD_Order = false;
            ld.LD_ItemLoc = false;
            ld.LD_ItemInv = false;
            ld.RU_Order = true;
            ld.RU_ItemLoc = false;
            ld.RU_ItemInv = true;
            ld.RD_Order = false;
            ld.RD_ItemLoc = true;
            ld.RD_ItemInv = false;

            DoUIUpdate();
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("SetSimpleMC: " + ex.Message, IGlobalData.protMode.crisp);
        }

    }

    public void SetComplexMC()
    {
        try
        {
            GD.LayoutDescription.SimpleMC = false;

            // Hier noch die Menüs aktualisieren
            GD!.LayoutDescription.OrderListPos = ILayoutDescription.selectedPosition.rightUp;
            GD!.LayoutDescription.ItemsInvListPos = ILayoutDescription.selectedPosition.rightUp;
            GD!.LayoutDescription.ItemsLocListPos = ILayoutDescription.selectedPosition.rightUp;

            GD.LayoutDescription.OrderListPosPT = ILayoutDescription.selectedPositionPT.first;
            GD.LayoutDescription.ItemsInvListPosPT = ILayoutDescription.selectedPositionPT.first;
            GD.LayoutDescription.ItemsLocListPosPT = ILayoutDescription.selectedPositionPT.first;

            LayoutDescription ld = (LayoutDescription)GlobalData.CurrentGlobalData!.LayoutDescription;
            ld.LU_Order = false;
            ld.LU_ItemLoc = false;
            ld.LU_ItemInv = false;
            ld.LD_Order = false;
            ld.LD_ItemLoc = false;
            ld.LD_ItemInv = false;
            ld.RU_Order = true;
            ld.RU_ItemLoc = false;
            ld.RU_ItemInv = true;
            ld.RD_Order = false;
            ld.RD_ItemLoc = true;
            ld.RD_ItemInv = false;

            DoUIUpdate();
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("SetComplexMC: " + ex.Message, IGlobalData.protMode.crisp);
        }

    }

    public bool FlushText { get; set; }

    public void ResetStoryText()
    {
    }

    public void ResetFeedbackText()
    {
    }


    public void Close()
    {
        QuitApplication();
    }

    public bool DoStatusSave()
    {
        try
        {
            GD.LayoutDescription.WinWidth = App.MainWindow!.Width;
            GD.LayoutDescription.WinHeight = App.MainWindow!.Height;
            GD.LayoutDescription.WinX = App.MainWindow!.X;
            GD.LayoutDescription.WinY = App.MainWindow!.Y;

            string? pathfileName = DeviceData._deviceData!.GetSavePath()! + "/" + loca.MAUI_Win_Config;


            string? jsonDest = JsonConvert.SerializeObject(GD.LayoutDescription, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(pathfileName, jsonDest);

            if (GlobalSpecs.CurrentGlobalSpecs!.InitRunning == IGlobalSpecs.initRunning.started || GlobalSpecs.CurrentGlobalSpecs!.InitRunning == IGlobalSpecs.initRunning.finished)
            {
                GD!.OrderList!.SaveOrderTable();
                GD!.Adventure!.Autosave(true);

            }

            return true;
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("DoStatusSave: " + ex.Message, IGlobalData.protMode.crisp);
            return false;
        }

    }
    public bool QuitApplication()
    {
        try
        {
            DoStatusSave();
            App.ThisApplication!.Quit();
            GlobalSpecs.CurrentGlobalSpecs!.AppRunning = IGlobalSpecs.appRunning.quit;

            return true;
        }
        catch (Exception ex)
        {
            Phoney_MAUI.Core.GlobalData.AddLog("QuitApplication: " + ex.Message, IGlobalData.protMode.crisp);
            return false;
        }

    }

    public static LayoutDescription? ReadConfig()
    {
        LayoutDescription? ld = null;

        try
        {
            string? pathfileName = DeviceData.GetSavePathStatic()! + "/config.inf";
            if (File.Exists(pathfileName))
            {
                string? jsonSource = File.ReadAllText(pathfileName);


                ld = JsonConvert.DeserializeObject<LayoutDescription>(jsonSource);
            }
        }
        catch( Exception e)
        {
            GlobalData.AddLog("ReadConfig: " + e.Message, IGlobalData.protMode.crisp);
        }

        return ld;
    }

    public void SetScoreMethod( Del4Double method )
    {
        _setScoreMethod = method;
    }
    public void SetScore(double cscore, double ctotalscore, double score, double totalscore, double val)
    {
        try
        {
            if (_setScoreMethod != null)
            {
                _setScoreMethod(cscore, ctotalscore, score, totalscore);
            }
        }
        catch (Exception e)
        {
            GlobalData.AddLog("SetScore: " + e.Message, IGlobalData.protMode.crisp);
        }
    }



    public void SaveToZip( string fileName, List<IUIServices.ZipObject>  objects )
    {
        try
        {
            var outStream = new MemoryStream();
            ZipArchive archive;

            string pathfileName = GlobalData.CurrentPath() + "/" + fileName;

            if (File.Exists(pathfileName))
            {
                archive = ZipFile.Open(pathfileName, ZipArchiveMode.Update);
            }
            else
            {
                archive = new ZipArchive(outStream, ZipArchiveMode.Update, true);
            }

            foreach (IUIServices.ZipObject zo in objects)
            {
                string? nameInZip = zo.Name;

                var fileInArchive = archive.GetEntry(nameInZip!);
                if (fileInArchive != null)
                {
                    fileInArchive.Delete();
                }
                fileInArchive = archive.CreateEntry(nameInZip!, CompressionLevel.Optimal);

                byte[] jsonBytes = Encoding.UTF8.GetBytes(zo.Data!);

                using (var entryStream = fileInArchive.Open())
                using (var fileToCompressStream = new MemoryStream(jsonBytes))
                {
                    fileToCompressStream.CopyTo(entryStream);
                }

            }

            archive.Dispose();

            using (var fileStream = new FileStream(pathfileName, FileMode.OpenOrCreate))
            {
                outStream.Position = 0;
                outStream.WriteTo(fileStream);
                outStream.Flush();
            }
            outStream.Close();
            outStream.Dispose();
        }
        catch (Exception e)
        {
            GlobalData.AddLog("SaveToZip: " + e.Message, IGlobalData.protMode.crisp);
        }

    }

    public string GetRealAssemblyName( string name )
    {
        try
        {
            string? newName = "";

            int ix;
            for (ix = 0; ix < name.Length; ix++)
            {
                if (name[ix] == ' ')
                    newName += '_';
                else
                    newName += name[ix];
            }

            return newName;
        }
        catch (Exception e)
        {
            GlobalData.AddLog("GetRealAssemblyName: " + e.Message, IGlobalData.protMode.crisp);
            return "";
        }

    }

    public  Stream GetResourceFile(string rscName)
    {
        try
        {
            // Erhalten Sie den Assembly-Namen
            string? assemblyName = GetRealAssemblyName(Assembly.GetExecutingAssembly().GetName().Name!);

            // Erstellen Sie den vollständigen Ressourcennamen
            string? resourceName = $"{assemblyName}.{rscName}";
            string? resourceName2 = $"{assemblyName}.Resources.Raw.{rscName}";

            // var x = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            // var y = Assembly.GetEntryAssembly()!.GetManifestResourceNames();

            // Öffnen Sie die Ressource als Stream
            Stream currentStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)!;
            if (currentStream == null)
                currentStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName2)!;

            // Geben Sie den Stream zurück
            return currentStream;
        }
        catch (Exception e)
        {
            GlobalData.AddLog("GetResourceFile: " + e.Message, IGlobalData.protMode.crisp);
            return null;
        }

    }

    public List<IUIServices.ZipObject> LoadFromZip(string fileName)
    {
        try
        {
            Stream str = GetResourceFile(fileName);

            // bool error = false;
            List<IUIServices.ZipObject> objects = new();

            ZipArchive archive = new ZipArchive(str);

            byte[] bufBytes;

            foreach (ZipArchiveEntry zae in archive.Entries)
            {
                IUIServices.ZipObject zo = new();

                string nameInZip = zae.Name;

                zo.Name = zae.Name;

                var fileInArchive = archive.GetEntry(nameInZip);
                if (fileInArchive != null)
                {
                    Stream s = fileInArchive.Open();
                    StreamReader sr = new StreamReader(s);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        sr.BaseStream.CopyTo(ms);
                        bufBytes = ms.ToArray();

                    }
                    if (bufBytes != null)
                    {
                        // jsonBytes = sr.ReadToEnd();
                        zo.Data = Encoding.UTF8.GetString(bufBytes);
                        // zo.Data = (string)ByteArrayToObject(bufBytes);

                    }
                    else
                    {
                        // int a = 3;
                    }
                    s.Close();
                    s.Dispose();
                    sr.Close();
                    sr.Dispose();
                }
                objects.Add(zo);
            }
            archive.Dispose();
            str.Close();
            str.Dispose();

            return (objects);
        }
        catch (Exception e)
        {
            GlobalData.AddLog("LoadFromZip: " + e.Message, IGlobalData.protMode.crisp);
            return null;
        }

    }
    public string? LoadStringFromRSC(string fileName)
    {
        try
        {
            Stream str = GetResourceFile(fileName);
            string? txt = null;

            using (var reader = new StreamReader(str))
            {
                txt = reader.ReadToEnd();
            }
            str.Close();
            str.Dispose();

            return txt;
        }
        catch (Exception e)
        {
            GlobalData.AddLog("LoadStringFromRSC: " + e.Message, IGlobalData.protMode.crisp);
            return null;
        }


    }

    public void CoreSaveToFile(string diffSavegame, string fileName)
    {
        try
        {
            var outStream = new MemoryStream();
            ZipArchive archive;

            string pathfileName = GlobalData.CurrentPath() + "/" + fileName;

            if (File.Exists(pathfileName))
            {
                archive = ZipFile.Open(pathfileName, ZipArchiveMode.Update);
            }
            else
            {
                archive = new ZipArchive(outStream, ZipArchiveMode.Update, true);
            }

            string nameInZip = "uncompressed";

            var fileInArchive = archive.GetEntry(nameInZip);
            if (fileInArchive != null)
            {
                fileInArchive.Delete();
            }
            fileInArchive = archive.CreateEntry(nameInZip, CompressionLevel.Optimal);

            byte[] jsonBytes = Encoding.UTF8.GetBytes(diffSavegame);

            using (var entryStream = fileInArchive.Open())
            using (var fileToCompressStream = new MemoryStream(jsonBytes))
            {
                fileToCompressStream.CopyTo(entryStream);
            }

            archive.Dispose();

            using (var fileStream = new FileStream(pathfileName, FileMode.OpenOrCreate))
            {
                outStream.Position = 0;
                outStream.WriteTo(fileStream);
                outStream.Flush();
            }
            outStream.Close();
            outStream.Dispose();
        }
        catch (Exception e)
        {
            GlobalData.AddLog("CoreSaveToFile: " + e.Message, IGlobalData.protMode.crisp);
        }

    }

    public void CoreSaveToFile(SaveObj SO, string fileName)
    {
        try
        {
            var outStream = new MemoryStream();
            ZipArchive archive;

            string pathfileName = GlobalData.CurrentPath() + "\\" + fileName;

            if (File.Exists(pathfileName))
            {
                archive = ZipFile.Open(pathfileName, ZipArchiveMode.Update);
            }
            else
            {
                archive = new ZipArchive(outStream, ZipArchiveMode.Update, true);
            }

            string nameInZip = "uncompressed";

            var fileInArchive = archive.GetEntry(nameInZip);
            if (fileInArchive != null)
            {
                fileInArchive.Delete();
            }
            fileInArchive = archive.CreateEntry(nameInZip, CompressionLevel.Optimal);

            byte[] jsonBytes = ObjectToByteArray(SO); //  Encoding.UTF8.GetBytes(SO);

            using (var entryStream = fileInArchive.Open())
            using (var fileToCompressStream = new MemoryStream(jsonBytes))
            {
                fileToCompressStream.CopyTo(entryStream);
            }

            archive.Dispose();

            using (var fileStream = new FileStream(pathfileName, FileMode.OpenOrCreate))
            {
                outStream.Position = 0;
                outStream.WriteTo(fileStream);
                outStream.Flush();
            }
            outStream.Close();
            outStream.Dispose();
        }
        catch (Exception e)
        {
            GlobalData.AddLog("CoreSaveToFile: " + e.Message, IGlobalData.protMode.crisp);
        }

    }

    public SaveObj? CoreLoadFromFile(string fileName)
    {
        try
        {
            SaveObj? SO = null;
            string pathfileName = GlobalData.CurrentPath() + "\\" + fileName;

            byte[] bufBytes;

            if (File.Exists(pathfileName))
            {
                ZipArchive archive = ZipFile.Open(pathfileName, ZipArchiveMode.Update);
                string nameInZip = "uncompressed";

                var fileInArchive = archive.GetEntry(nameInZip);
                if (fileInArchive != null)
                {
                    Stream s = fileInArchive.Open();
                    StreamReader sr = new StreamReader(s);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        sr.BaseStream.CopyTo(ms);
                        bufBytes = ms.ToArray();

                    }
                    if (bufBytes != null)
                    {
                        // jsonBytes = sr.ReadToEnd();
                        SO = (SaveObj)ByteArrayToObject(bufBytes);

                    }
                    else
                    {
                        // int a = 3;
                    }
                    sr.Close();
                    sr.Dispose();
                    s.Close();
                    s.Dispose();
                }
                archive.Dispose();


            }

            return (SO);
        }
        catch (Exception e)
        {
            GlobalData.AddLog("CoreLoadFromFile: " + e.Message, IGlobalData.protMode.crisp);
            return null;
        }

    }


    public string? LoadString(string fileName)
    {
        try
        {
            string? sSlash = "/";
            string? s = null;

            if (fileName.StartsWith("/"))
            {
                sSlash = "";
            }
            string pathfileName = GlobalData.CurrentPath() + sSlash + fileName;
            if (File.Exists(pathfileName))
            {
                s = File.ReadAllText(pathfileName);
            }

            return s;
        }
        catch (Exception e)
        {
            GlobalData.AddLog("LoadString: " + e.Message, IGlobalData.protMode.crisp);
            return null;
        }

    }
    public bool SaveString(string fileName, string WriteString)
    {
        try
        {
            string? pathName = GlobalData.CurrentPath();
            string? pathfileName = pathName + "/" + fileName; //  loca.OrderList_WriteJsonIndex_16209;

            File.WriteAllText(pathfileName, WriteString);

            return true;
        }
        catch (Exception e)
        {
            GlobalData.AddLog("SaveString: " + e.Message, IGlobalData.protMode.crisp);
            return false;
        }

    }
    public string? CoreLoadStringFromFile(string fileName)
    {
        string? gameString = null;
        // string pathfileName = GlobalData.CurrentPathPlusFilename(fileName);
        string pathfileName = GlobalData.CurrentPath() + "/" + fileName;

        string? bufString;
        byte[] bufBytes;


        if (File.Exists(pathfileName))
        {
            try
            {
                ZipArchive archive = ZipFile.Open(pathfileName, ZipArchiveMode.Update);
                string nameInZip = "uncompressed";

                var fileInArchive = archive.GetEntry(nameInZip);
                if (fileInArchive != null)
                {
                    Stream s = fileInArchive.Open();
                    StreamReader sr = new StreamReader(s);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        sr.BaseStream.CopyTo(ms);
                        bufBytes = ms.ToArray();

                    }
                    if (bufBytes != null)
                    {
                        // jsonBytes = sr.ReadToEnd();
                        bufString = Encoding.UTF8.GetString(bufBytes);

                        gameString = bufString;
                    }
                    else
                    {
                        // int a = 3;
                    }
                    s.Close();
                    s.Dispose();
                    sr.Close();
                    sr.Dispose();
                }
                archive.Dispose();
            }
            catch ( Exception e)
            {
                GlobalData.AddLog("CoreLoadStringFromFile: " + e.Message, IGlobalData.protMode.crisp);

            }

        }

        return (gameString);
    }

    public bool ExistFile(string fileName)
    {
        try
        {
            string slash = "/";

            if (fileName.StartsWith("/"))
                slash = "";

            string pathFileName = GlobalData.CurrentPath() + slash + fileName;

            return (File.Exists(pathFileName));
        }
        catch (Exception e)
        {
            GlobalData.AddLog("ExistFile: " + e.Message, IGlobalData.protMode.crisp);
            return false;
        }

    }

    public string CurrentPathPlusFilename( string fileName )
    {
        string slash = "/";

        if (fileName.StartsWith("/"))
            slash = "";

        string pathFileName = GlobalData.CurrentPath() + slash + fileName;

        return pathFileName;
    }
    public bool WriteStory()
    {
        try
        {
            string pathfileName = CurrentPathPlusFilename("Versteck_Meister_Story_Recording.html");

            try
            {
                File.WriteAllTextAsync(pathfileName, GD.HTMLPage!.Replace("[Body]", StoryTextObj!.WholeStory!.ToString()));

            }
            catch (Exception e)
            {
                GlobalData.AddLog("WriteStory: " + e.Message, IGlobalData.protMode.crisp);

                return false;
            }

            return true;
        }
        catch (Exception e)
        {
            GlobalData.AddLog("WriteStory: " + e.Message, IGlobalData.protMode.crisp);
            return false;
        }

    }

    public void InitPath()
    {

    }
    public static class ObjectCopier
    {
        /// <summary>
        /// Perform a deep copy of the object via serialization.
        /// </summary>
        /// <typeparam name="T">The type of object being copied.</typeparam>
        /// <param name="source">The object instance to copy.</param>
        /// <returns>A deep copy of the object.</returns>
        public static T? Clone<T>(T source)
        {

            try
            {
                /*
                if (!typeof(T).IsSerializable)
                {
                    throw new ArgumentException("The type must be serializable.", nameof(source));
                }
                */

                // Don't serialize a null object, simply return the default for that object
                if (ReferenceEquals(source, null)) return default;

                Stream stream = new MemoryStream();
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                stream.Close();
                stream.Dispose();
                return (T)formatter.Deserialize(stream);
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("ObjectCopier: " + ex.Message, IGlobalData.protMode.crisp);
                return default(T);
            }
        }

    }

    public void BackupOrdertable()
    {

    }

    public MCMenu? LastMCMenu { get; set; }


    public static byte[] ObjectToByteArray(Object obj)
    {

        /*
        byte[] buf;

        using (var ms = new MemoryStream())
        {
            using (var writer = new BsonWriter(ms))
            {
                var serializer = new Newtonsoft.Json.JsonSerializer();
                serializer.Serialize(writer, new { value = obj });
                buf = ms.ToArray();
            }
        }
        return buf;
        */
        /*
        string s1 = JsonConvert.SerializeObject(obj);
        byte[] buf = Encoding.UTF8.GetBytes(s1);
        return buf;
        */
        BinaryFormatter bf = new BinaryFormatter();
        using (var ms = new MemoryStream())
        {
            try
            {
                bf.Serialize(ms, obj);
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("ObjectToByteArray: " + ex.Message, IGlobalData.protMode.crisp);
            }

            finally
            {
                // int a = 5;
            }
            return ms.ToArray();
        }
    }
    public static Object? ByteArrayToObject(byte[] arrBytes)
    {
        /*
        Object? o = null;

        using (var ms = new MemoryStream())
        {
            using (var reader = new BsonReader(ms))
            {
                var serializer = new Newtonsoft.Json.JsonSerializer();
                o = serializer.Deserialize(reader);
            }
        }
        return o;
        */
        /*
        string s1 = Encoding.Default.GetString(arrBytes);
        Object? o = JsonConvert.DeserializeObject(s1);
        return o;
        */
        /*
        byte[] buf = System.Text.Json.JsonSerializer.Deserialize().SerializeToUtf8Bytes(obj);
        return buf;
        */
        try
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
        catch (Exception e)
        {
            GlobalData.AddLog("ByteArrayToObject: " + e.Message, IGlobalData.protMode.crisp);
            return null;
        }
    }

    List<string>? LatestNaviStrings = null;
    // int lnsPt = 0;

    public async void WaitWebsiteReady()
    {
        try
        {
            // Definiere eine JavaScript-Funktion, die die document.readyState-Eigenschaft zurückgibt
            string jsFunction = "function getDocumentReadyState() { return document.readyState; }";

            // Füge die JavaScript-Funktion der Webseite hinzu
            await ExternalGameOut!.EvaluateJavaScriptAsync(jsFunction);


            // Warte, bis die neue Webseite geladen ist
            string? result = await ExternalGameOut.EvaluateJavaScriptAsync("new Promise((resolve, reject) => { var interval = setInterval(() => { var state = getDocumentReadyState(); if (state == 'complete') { clearInterval(interval); resolve(state); } }, 100); });");

            // Prüfe, ob die Webseite vollständig geladen ist
            if (result == "complete")
            {
                // Setze die Source-Eigenschaft auf die neue URL, um die Aktualisierung der Website durchzuführen
                // Bridge
                // ExternalGameOut.Source = ExternalGameOut.Source;
                ExternalGameOut.NavigateToString(ExternalGameOut.LatestString!);
            }

            string? result2 = await ExternalGameOut.EvaluateJavaScriptAsync("Promise.resolve('gna')");
        }
        // Wenn das Warten auf Fertigstellung nicht klappt: Tja, dann flackerts halt
        catch (Exception e)
        {
            GlobalData.AddLog("WaitWebsiteReady: " + e.Message, IGlobalData.protMode.crisp);

        }
    }
    public void WebView1_Navigating2(object? sender, WebNavigatedEventArgs e)
    {

        // GD.UIS.TextOutput("bla bla bla");
        if (Scr.ScrollStep == IScroller.scrollStep.settingSource && Scr._scrollMode != IScroller.scrollMode.delayJump )
        {
            // GD.UIS.TextOutput("bla bla bla");
            // Scr.DelaySet();
            // Scr.SetToPos((int) Scr.HTMLViewYRef);
            // Scr.ScrollEnd((int) Scr.HTMLViewYRef);

            Scr.ScrollStep = IScroller.scrollStep.none;
        }
        /*
        if (LatestNaviStrings == null)
            LatestNaviStrings = new();

        LatestNaviStrings.Add( e.Url);

        if (e.Url != "about:blank")
        {

        }
        */
    }

    public void WebView1_Navigating(object? sender, WebNavigatingEventArgs e)
    {
        try
        {
            // if(((Microsoft.Maui.Controls.HtmlWebViewSource)ExternalGameOut.Source).Html.Length != e.Url)
            // LatestNaviStrings.Add( e.Url);

            if (e.Url.Substring(0, 5) != "data:")
            {

            }
            var urlParts = e.Url.Split(".");
            if (urlParts[0].ToLower().Equals("https://runcsharp"))
            {
                var funcToCall = urlParts[1].Split("?");
                var methodName = funcToCall[0];
                var funcParams = funcToCall[1];
                // Debug.WriteLine("Calling " + methodName);

                if (methodName == "gethtmlypos/")
                {
                    JSBoundObject.GetHtmlYPos(Int32.Parse(funcParams));
                }
                else if (methodName == "gethtmlheight/")
                {
                    JSBoundObject.GetHtmlHeight(Int32.Parse(funcParams));
                }
                /*
                else if (methodName == "gethtmlheight/")
                {
                    JSBoundObject.GetHtmlHeight(Int32.Parse(funcParams));
                }
                */
                else if (methodName == "gethtmlmaxypos/")
                {
                    JSBoundObject.GetHtmlMaxYPos(Int32.Parse(funcParams));
                }
                else if (methodName == "gethtmlmaxyposoffset/")
                {
                    JSBoundObject.GetHtmlMaxYPosOffset(Int32.Parse(funcParams));
                }
                else if (methodName == "startscrolling/")
                {
                    JSBoundObject.StartScrolling(Int32.Parse(funcParams));
                }
                else if (methodName == "startscrolling2/")
                {
                    JSBoundObject.GetHtmlYPos(Int32.Parse(funcParams));
                }
                else if (methodName == "loadedfully/")
                {
                    JSBoundObject.HmtlLoaded(Int32.Parse(funcParams));
                }
                else
                {
                    JSBoundObject.GetHtmlYPos(Int32.Parse(funcParams));
                }

                // 
                // prevent the navigation to complete
                e.Cancel = true;

                // TODO smart parsing and type casting of parameters and then some reflection magic
            }
            else if (urlParts[0].ToLower().Equals("https://defineobject"))
            {
                // Wenn e.Cancel schon gesetzt, dann wurde der Link schon verarbeitet
                if (e.Cancel == false)
                {
                    bool skip = false;

                    LatestNaviStrings = new();
                    LatestNaviStrings.Add(urlParts[0]);
                    // lnsPt = 1;

                    // Dieser Mechanismus ist darauf ausgelegt, dass auf einen Klick insgesamt 3 Messages folgen, von denen 2 tunlichst 
                    // verschluckt werden sollten. Das ist aus irgendeinem Grund nun nicht mehr nötig, bzw. dadurch ist es halt jetzt falsch

                    /*
                    bool skip = true;

                    if( LatestNaviStrings == null )
                    {
                        LatestNaviStrings = new();
                        LatestNaviStrings.Add(urlParts[0]);
                        lnsPt = 1;
                        skip = false;
                    }
                    else if (urlParts[0] == LatestNaviStrings[ lnsPt - 1])
                    {
                        LatestNaviStrings.Add(urlParts[0]);
                        lnsPt++;
                        if( lnsPt >= 3)
                        {
                            LatestNaviStrings = null;
                        }
                    }
                    */

                    if (!skip)
                    {
                        string? s = null;

                        var funcToCall = urlParts[1].Split("/");

                        if (funcToCall[0] == "item")
                        {
                            s = "Item: " + funcToCall[1];
                        }
                        else if (funcToCall[0] == "dir")
                        {
                            s = "Dir: " + funcToCall[1];
                        }
                        else if (funcToCall[0] == "loc")
                        {
                            s = "Loc: " + funcToCall[1];
                        }
                        else if (funcToCall[0] == "actloc")
                        {
                            s = "ActLoc";
                        }
                        else if (funcToCall[0] == "actperson")
                        {
                            s = "ActPerson";
                        }
                        else if (funcToCall[0] == "person")
                        {
                            s = "Person: " + funcToCall[1];
                        }

                        if (s != null)
                        {
                            InitBrowserUpdate();
                            // UpdateBrowserCallsPerCycle = 0;
                            GlobalData.CurrentGlobalData!.Adventure!.LinkCallback(s);
                            DoUIUpdate();
                            StoryTextObj!.AdvTextRefresh(true);
                            FinishBrowserUpdate(IUIServices.onBrowserContentLoaded.PageDown);
                            if (_setMCFocusMethod != null)
                            {
                                _setMCFocusMethod();
                            }
#if !NEWSCROLL
                    Scr!.ScrollPageFinal();
                    Scr!.SetNext = true;
#endif
                        }
                    }
                    e.Cancel = true;
                }
            }
            else
            {
                // int a = 5;
                e.Cancel = false;
            }
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("WebView1_Navigating: " + ex.Message, IGlobalData.protMode.crisp);
        }
    }

    public void InitBrowserUpdate()
    {
        UpdateBrowserCallsPerCycle = 0;
    }

    public void FinishBrowserUpdate( IUIServices.onBrowserContentLoaded doAfterLoad = IUIServices.onBrowserContentLoaded.unchanged )
    {
        UpdateBrowserAllowed = true;
        UpdateBrowser( doAfterLoad );
        UpdateBrowserAllowed = false;
    }

    public bool UpdateBrowserAllowed { get; set; } = false;
    public bool UpdateBrowserBlocked { get; set; } = false;

    private string? lastString; 

    public void UpdateBrowser(IUIServices.onBrowserContentLoaded doAfterLoad = IUIServices.onBrowserContentLoaded.unchanged)
    {
        if (MainThread.IsMainThread == false )
        {
            return;
        }

        if (UpdateBrowserBlocked == false && UpdateBrowserAllowed == true )
        {
            if (UpdateBrowserCallsPerCycle == 0)
            {
                // Action<string> action;
                double yPos = Scr.HTMLViewYPos;

                try
                {
                    lock (ExternalGameOut!)
                    {
                        // if (Scr.ScrollStep == IScroller.scrollStep.none)
                        {
                            Scr.HTMLViewYRef = Scr.HTMLViewYPos + 30; // Scr.HTMLViewMaxYPos - Scr.HTMLViewHeight + 15;
                            if (Scr.HTMLViewYRef < 0)
                            {
                                Scr.HTMLViewYRef = 0;
                            }
                            if (Scr.ScrollStep == IScroller.scrollStep.none)
                                Scr.ScrollStep = IScroller.scrollStep.settingSource;
                        }
                        string s = GlobalData.CurrentGlobalData!.WebViewContent; //   + "window.scrollTo({ top: document.body.scrollHeight });";
                        // string s = GlobalData.CurrentGlobalData!.WebViewContent + "  window.scrollTo({ top: " + Scr.YPos + "});";
                        // ExternalGameOut.Navigating += WebView1_Navigating;


                        Scr._screenRefreshed = false;

                        bool insertedFine;
                        int ct = 0;
                        do
                        {
                            if (doAfterLoad != IUIServices.onBrowserContentLoaded.unchanged)
                            {
                                OnBrowserContentLoaded = doAfterLoad;
                            }

                            

                            insertedFine = true;
                            // Bridge
                            _browserRefreshOngoing = true;
                            ExternalGameOut.NavigateToString(s);

                            // Bridge
                            /*
                            ExternalGameOut.Source = new HtmlWebViewSource
                            {
                                Html = s
                            };
                            */
                            // WaitWebsiteReady();
                            // ExternalGameOut.Reload();

                            // Bridge
                            /*
                            HtmlWebViewSource s1 = (HtmlWebViewSource)ExternalGameOut.Source;
                            if (s1.Html != s)
                            {
                                insertedFine = false;
                            }
                            else
                            {
                                
                                var s2 = "function SetFullyLoadedDoc() { window.location.href = 'https://runcsharp.LoadedFully?' + document.body.scrollHeight; } document.addEventListener( 'DOMContentLoaded'', SetFullyLoadedDoc);";

                                var res = ExternalGameOut.EvaluateJavaScriptAsync(s2);
                                var value = res.GetAwaiter().GetResult();

                            }
                            */
                            ct++;
                        } while (insertedFine == false && ct < 20);

                        GD.UIS!.FlushUICycle();
                        
                        // Scr.SetToPos((int)Scr.HTMLViewYRef);

                        lastString = s;
#if ANDROID
            // Scr.ScrollEnd(Scr.HTMLViewYRef);

            // Scr.ScrollStep = IScroller.scrollStep.none;
#endif
                    }
#if !NEWSCROLL


                    Scr.JumpToEnd();
#else
                    // Scr.ScrollEnd( yPos );
#endif
                }
                catch (Exception e)
                {
                    GlobalData.AddLog("UpdateBrowser: " + e.Message, IGlobalData.protMode.crisp);

                    // int a = 5;
                }
            }
            else
            {
                // int a = 5;
            }
            UpdateBrowserCallsPerCycle++;
        }
    }

    IUIServices.sttListeningMode _sttListeningOn = IUIServices.sttListeningMode.off;
    public Phoney_MAUI.Model.IUIServices.sttListeningMode STTListeningOn 
    { 
        get => _sttListeningOn;
        set
        {
            _sttListeningOn = value;
            if (STTListenigModeChangeCB != null)
                STTListenigModeChangeCB(value);
        } 
    }
    public string RecordedText { get; set; }
    private bool asyncSpeechListening = false;
    private bool asyncSpeechRunning = false;
    public Color NewMikeColor { get; set; }

    private CancellationToken? _ct = null;
    // private int stopCount = 0;

    private Stopwatch? STTStartTime { get; set; } = null;
    public void STTTestRunning()
    {
#if ANDROID
     try
     {
        if (asyncSpeechRunning == true && STTStartTime != null)
        {
            if(STTStartTime.ElapsedMilliseconds > 5000)
            {
                STTStopListening(false).GetAwaiter();
            }
        }
        }
        catch (Exception e)
        {
            GlobalData.AddLog("STTTestRunning: " + e.Message, IGlobalData.protMode.crisp);

        }
#endif
    }

    public bool STTInqSpeechSync()
    {
        var result = Task.Run(async () => await STTInqSpeech()).Result;
        return result;
    }
    public async Task<bool> STTInqSpeech()
    {
        if( MainThread.IsMainThread == false )
        {
            return false;
        }

        try
        {
            var isGranted = await SpeechToText.RequestPermissions(CancellationToken.None);
            if (isGranted)
            {
                // return false;
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception e)
        {
            GlobalData.AddLog("STTInqSpeech: " + e.Message, IGlobalData.protMode.crisp);

        }

        return false;

    }
    public async Task STTStartListening(IUIServices.sttListeningMode newMode, [CallerMemberName] string callerName = "")
    {
        //  int i = 0;
        try
        {
            if (callerName == null)
            {

            }
            if ( /* STTListeningOn != IUIServices.sttListeningMode.off && */ asyncSpeechRunning == true)
            {
                // stopCount = 1;
                await STTStopListening(false);
                asyncSpeechRunning = false;

                if(STTStartTime != null )
                    STTStartTime!.Stop();
                STTStartTime = null;
            }
            // i = 1;
            if (_ct == null)
            {
                _ct = new CancellationToken();
            }
            // CancellationToken cancellationToken = CancellationToken.None;

            // i = 2;
            var isGranted = await SpeechToText.RequestPermissions((CancellationToken)_ct);
            if (!isGranted)
            {
                // await Toast.Make("Permission not granted").Show(CancellationToken.None);
                return;
            }
            

            RecordedText = "";

            // i = 3;

            // Delegate[] delegates = SpeechToText.Default.RecognitionResultCompleted.GetInvocationList();

            if (asyncSpeechListening == false)
            {
                // i = 41;
                SpeechToText.Default.RecognitionResultUpdated += OnRecognitionTextUpdated;
                SpeechToText.Default.RecognitionResultCompleted += OnRecognitionTextCompleted;
                SpeechToText.Default.StateChanged += OnStateChanged;
                asyncSpeechListening = true;
                // i = 4;
            }
            else
            {

            }
            if (GD.Language == IGlobalData.language.german)
            {
                // i = 51;
                await SpeechToText.StartListenAsync(CultureInfo.GetCultureInfo("de-de"), (CancellationToken)_ct);
                // i = 52;
                asyncSpeechRunning = true;
                STTStartTime = new Stopwatch();
                STTStartTime.Start();
                // i = 53;
                STTListeningOn = newMode;
                // i = 5;
            }
            else
            {
                await SpeechToText.StartListenAsync(CultureInfo.GetCultureInfo("en-en"), (CancellationToken)_ct);
                asyncSpeechRunning = true;
                STTStartTime = new Stopwatch();
                STTStartTime.Start();
                STTListeningOn = newMode;
                // i = 6;
            }
            // i = 7;
        }
        catch (Exception e)
        {
            GlobalData.AddLog("STTStartListening: " + e.Message, IGlobalData.protMode.crisp);

            GD.LayoutDescription.STTMicroState = IGlobalData.microMode.off;
        }
    }

    public async Task STTStopListening( bool restartMode = false )
    {
        // int i = 0;

        try
        {
            // i = 1;
            if (STTListeningOn != IUIServices.sttListeningMode.off)
            {
                // i = 2;
                if (asyncSpeechRunning == true)
                {
                    await SpeechToText.StopListenAsync((CancellationToken) _ct!);
                    asyncSpeechRunning = false;
                    if(STTStartTime != null )
                        STTStartTime!.Stop();
                    STTStartTime = null;
                }
                // CancellationToken cancellationToken = CancellationToken.None;
                // Upd 16.12.2023
                // RecognitionResultUpdated und -completed bleiben gesetzt bis Programmende
                /*
                if (asyncSpeechListening == true)
                {
                    i = 3;
                    i = 4;
                    SpeechToText.Default.RecognitionResultUpdated -= OnRecognitionTextUpdated;
                    i = 5;
                    SpeechToText.Default.RecognitionResultCompleted -= OnRecognitionTextCompleted;
                    i = 6;

                    asyncSpeechOn = false;
                    i = 7;
                }
                */
                if (STTListeningOn == IUIServices.sttListeningMode.on)
                {
                    // i = 8;
                    STTListeningOn = IUIServices.sttListeningMode.off;
                    // i = 9;
                }
                else if (STTListeningOn == IUIServices.sttListeningMode.continuous)
                {
                    // i = 10;

                    if (restartMode == true)
                    {
                        await STTStartListening(STTListeningOn);
                        // asyncSpeechRunning = true;
                        // stopCount = 3;
                    }
                    else
                    {
                        STTListeningOn = IUIServices.sttListeningMode.off;
                        // stopCount = 2;
                    }
                    // i = 11;
                }
            }
            else
            {
                // i = 12;
                // Upd 16.12.2023
                // RecognitionResultUpdated und -completed bleiben gesetzt bis Programmende
                /*
                if (asyncSpeechOn == true)
                {
                    i = 13;

                    SpeechToText.Default.RecognitionResultUpdated -= OnRecognitionTextUpdated;
                    i = 14;
                    SpeechToText.Default.RecognitionResultCompleted -= OnRecognitionTextCompleted;
                    i = 15;

                    asyncSpeechOn = false;
                    i = 16;
                }
                */
            }
        }
        catch (Exception e)
        {
            GlobalData.AddLog("STTStopListening: " + e.Message, IGlobalData.protMode.crisp);

        }
    }

    void OnStateChanged( object? sender, SpeechToTextStateChangedEventArgs ea )
    {
        try
        {
            if (ea.State == SpeechToTextState.Stopped)
            {
                if (STTListeningOn == IUIServices.sttListeningMode.on)
                {
                    STTListeningOn = IUIServices.sttListeningMode.off;
                }
                else if (STTListeningOn == IUIServices.sttListeningMode.continuous)
                {
                    if (App.AppState == App.appState.closing)
                    {
                    }
                    else
                    {
                        STTStartListening(STTListeningOn).Wait();
                    }

                }
            }
            else if (ea.State == SpeechToTextState.Listening)
            {

            }
        }
        catch (Exception e)
        {
            GlobalData.AddLog("OnStateChanged: " + e.Message, IGlobalData.protMode.crisp);

        }
    }
    string recordingBuffer = "";
    void OnRecognitionTextUpdated(object? sender, SpeechToTextRecognitionResultUpdatedEventArgs args)
    {
        try
        {
#if WINDOWS
            string s = args.RecognitionResult;
            STTStopListening(true)!.Wait();
            RecordedText += s;
            recordingBuffer = args.RecognitionResult;

            /*
            if( s.Length > 0 && recordingBuffer.Length > 0 )
            {
                if( s.IndexOf( recordingBuffer ) == 0 )
                {
                    s = s.Substring(recordingBuffer.Length);
                }
                else
                {
                    recordingBuffer = "";
                }
            }
            */
            // args.RecognitionResult = "";
#endif
        }
        catch (Exception e)
        {
            GlobalData.AddLog("OnRecognitionTextUpdated: " + e.Message, IGlobalData.protMode.crisp);

        }
    }

    void OnRecognitionTextCompleted(object? sender, SpeechToTextRecognitionResultCompletedEventArgs args)
    {
        try
        {
#if WINDOWS
            STTListeningOn = IUIServices.sttListeningMode.off;
#elif ANDROID
            string s = args.RecognitionResult;
            STTStopListening(true)!.Wait();
            RecordedText += s;
            recordingBuffer = args.RecognitionResult;
#endif
            /*
            // RecordedText = args.RecognitionResult;
            STTStartListening(IUIServices.sttListeningMode.continuous )!.Wait();
            recordingBuffer = "";
            */
        }
        catch (Exception e)
        {
            GlobalData.AddLog("OnRecognitionTextCompleted: " + e.Message, IGlobalData.protMode.crisp);

        }
    }

}
[Serializable]
public class MCMenuView
{
    [JsonIgnore]
    public GlobalData? GD
    {
        get => GlobalData.CurrentGlobalData;
        // set => GlobalData.CurrentGlobalData = value;
    }
    public Phoney_MAUI.Model.IUIServices? UIS
    {
        get => GlobalData.CurrentGlobalData!.UIS;
        set => GlobalData.CurrentGlobalData!.UIS = value;
    }
    // private MCMenuView? mcmwObj = null;
    public int instances = 0;
    public bool visible = false;
    // private IGlobalData GD { get; set; }
    // private IUIServices UIS { get; set; }
    // VerticalStackLayout? tapvsl= null;
    Microsoft.Maui.Controls.Grid? _mcGrid = null;

    /*
     public void SetMCMenuViewObj(MCMenuView mcmwObj)
    {
        this.mcmwObj = mcmwObj;
    }
    */

    private Phoney_MAUI.Model.DelMCMSelection? __callbackSelection;
    Phoney_MAUI.Model.DelMCMSelection? _callbackSelection
    {
        get => __callbackSelection;
        set
        {
            __callbackSelection = value;
        }
    }

    /*
    private int Instances
    {
        get { return mcmwObj!.instances; }
        set
        {
            mcmwObj!.instances = value;
        }
    }
    */
    private int Instances
    {
        get { return instances; }
        set
        {
            instances = value;
        }
    }

    public bool Visible
    {
        get { return visible; }
        set { visible = value; }
    }

    public void CreateButton(Microsoft.Maui.Controls.Grid g, string text, int off, int val, EventHandler? ev)
    {
        try
        {
            IDButton b = new();
            b.ID = val;
            b.Text = text;
            g.Add(b);
            g.SetRow(b, off);
            List<string> ButtonStyle = new();
            ButtonStyle.Add("IDButton_Invers");
            b.StyleClass = ButtonStyle;
            Thickness m = new(6, 6, 6, 0);
            b.Margin = m;
            b.Clicked += ev;
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("CreateButton: " + ex.Message, IGlobalData.protMode.crisp);
        }

    }

    /*
    public void SetMC(Microsoft.Maui.Controls.Grid? contextGrid, int val)
    {
        contextGrid!.Children.Clear();

        RowDefinitionCollection rdc = new();
        RowDefinition rd1 = new();
        rd1.Height = GridLength.Auto;
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);
        rdc.Add(rd1);

        contextGrid.RowDefinitions = rdc;

        CreateButton(contextGrid, "Bis hierher spielen", 0, val, null);
        CreateButton(contextGrid, "Editieren", 1, val, null);
        CreateButton(contextGrid, "Löschen", 2, val, null);
        CreateButton(contextGrid, "Neuer Eintrag danach", 3, val, null);
        CreateButton(contextGrid, "Neuer Eintrag davor", 4, val, null);
    }
    */

    public void SetCallbackSelection(Phoney_MAUI.Model.DelMCMSelection? CallbackSelection)
    {
        _callbackSelection = CallbackSelection;
    }
    public Phoney_MAUI.Model.DelMCMSelection? GetCallbackSelection()
    {
        return _callbackSelection;
    }

    public MCMenuView()
    {
        try
        {
            // mcmwObj = this;

            // this.UIS = UIS;
            // this.GD = gd;
            UIS!.MCMV = this;
            UIS!.MCMVVisible = true;
            UIS.Scr.YPosMode = Scroller.YPosModes.startmc;
            UIS.Scr.SetFastScrollingArea();

            if (GD!.MCAsContextmenu == true)
            {
                string Text = "Huhu";


                // int val = 5;

                double x1 = GlobalSpecs.CurrentGlobalSpecs!.GetScreenWidth();
                double y1 = GlobalSpecs.CurrentGlobalSpecs!.GetScreenHeight();

                Rect pd = new();
                pd.Width = 300;
                pd.Height = 400;
                pd.X = (x1 / 2) - (pd.Width / 2);
                pd.Y = (y1 / 2) - (pd.Height / 2);

                GD.MenuExtension!.OpenShowMenu(true, pd, true, Text);
                GD.MenuExtension!.MEMenus[GD.MenuExtension.MEMenus.Count - 1].Scalable = true;
                GD.MenuExtension!.MEMenus[GD.MenuExtension.MEMenus.Count - 1].MinWidth = 200;
                GD.MenuExtension!.MEMenus[GD.MenuExtension.MEMenus.Count - 1].MaxWidth = 600;
                GD.MenuExtension!.MEMenus[GD.MenuExtension.MEMenus.Count - 1].MinHeight = 200;
                GD.MenuExtension!.MEMenus[GD.MenuExtension.MEMenus.Count - 1].MaxHeight = 600;
                /*
                if (GD.MenuExtension.MEMenus[GD.MenuExtension.MEMenus.Count - 1].InnerView != null)
                {
                    SetMC(GD.MenuExtension.MEMenus[GD.MenuExtension.MEMenus.Count - 1].InnerView, val);
                }
                */

                this.UIS!.MCMenuViewObj = this;
                /*
                MW.TextinputTemp = MW.Inputline.Text;
                MW.textinputarea1.Visibility = Visibility.Hidden;
                MW.textinputarea2.Visibility = Visibility.Hidden;
                MW.textoutputarea.Visibility = Visibility.Visible;

                if (MW.WCFG!.CurrentScheme != null)
                    MW.textoutputarea.Background = MW.WCFG.CurrentScheme.BGMC; //  Brushes.LightCyan;
                                                                               // MW.InputGrid.Color= MW.CurrentScheme.BGMC;
                                                                               // MW.ReturnButton.Visibility = Visibility.Hidden;
                if (MW.FeedbackTextObj.FeedbackModeMC == false && MW.FlushText == false)
                    Instances = 1;
                else
                    Instances++;

                if (MW.FeedbackTextObj.FeedbackModeMC == false && MW.FlushText == false)
                {
                    MW.FeedbackTextObj.FeedbackOffMC = 0;
                    MW.FeedbackTextObj.FeedbackModeMC = true;
                    if (GD.SilentMode == false)
                        MW.SetScheme(true);
                }

                // UIS!.Scr.JumpToEnd();
                MW.FeedbackTextObj.FeedbackWindowInitText();

                MW.AdjustTextPanel();
                */
                // MW.FeedbackTextObj.FeedbackModeMC = true;
#if !NEWSCROLL
            UIS!.Scr!.CompactToEnd();
            UIS!.Scr!.SetScrollerToEnd();
#endif
            }
            else
            {
                DelBoolInt? dbi = GD.ProvideMCGrid;

                if (dbi != null)
                {
                    Grid g1 = dbi(true, 200);

                    this.UIS!.MCMenuViewObj = this;
#if !NEWSCROLL
                UIS!.Scr!.CompactToEnd();
                UIS!.Scr!.SetScrollerToEnd();
#endif
                    _mcGrid = g1;
                }
            }
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("MCMenuView: " + ex.Message, IGlobalData.protMode.crisp);
        }

        // UIS!.Scr.InqScrollingAreaAsync().Wait();
    }

    public void Close()
    {
        try
        {
            if (GD!.MCAsContextmenu == true)
            {
                // GlobalData.CurrentGlobalData!.Adventure.UIS!.StoryTextObj.AdvTextOut(); //  RecalcLatest();
                // GlobalData.CurrentGlobalData!.Adventure.UIS!.UpdateBrowser();
                GD.MenuExtension!.DestroyMEMenus();
                // UIS!.DoUpdateBrowser = true;
                // mcmwObj.Close();
            }
            else
            {
                DelBoolInt dbi = GD.ProvideMCGrid!;

                if (dbi != null)
                {
                    dbi(false, 0);
                }
                // Behaviors löschen

                VerticalStackLayout? vsl = (_mcGrid!.Children[0] as ScrollView)!.Content as VerticalStackLayout;

                TreeView.EmptyTreeViewItem(vsl, false, false, true);

                /*
                foreach (IView iv in vsl.Children)
                {
                    if (iv.GetType() == typeof(Grid))
                    {

                        Label l1 = ( (iv as Grid)!.Children[0] as Label ) !;

                        while (l1!.Behaviors.Count > 0)
                        {
                            l1.Behaviors.RemoveAt(0);
                        }

                        if ((iv as Grid)!.Children.Count > 1)
                        {
                            Label? l2 = (iv as Grid)!.Children[1] as Label;

                            while (l2.Behaviors.Count > 0)
                            {
                                l2.Behaviors.RemoveAt(0);
                            }
                        }
                    }

                }
                */

            }
            UIS!.Scr.CompactToEnd();
            UIS.StoryTextObj!.AdvTextRefresh();
            UIS.StoryTextObj!.TextReFreshman();

            // UIS.Scr.JumpToEndInstantly();

            UIS!.MCMVVisible = false;
            UIS.Scr.YPosMode = Scroller.YPosModes.backfrommc;
            UIS.Scr.SetFastScrollingArea();
            UIS.FinishBrowserUpdate(IUIServices.onBrowserContentLoaded.ScrollToEnd);
            // UIS!.Scr.InqScrollingAreaAsync().Wait();
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("Close: " + ex.Message, IGlobalData.protMode.crisp);
        }


    }



    public void MCOutput()
    {
        // mcmwObj.MCOutput();
    }

    public void DoTapEntry(object? sender, TappedEventArgs e)
    {
        try
        {
            if (UIS!.UpdateBrowserCallsPerCycle > 0)
                return;


            (sender as Phoney_MAUI.IDLabel).TextColor = Colors.AliceBlue;
            /*
            if( tapvsl!= null )
            {
                foreach( Object o in tapvsl.Children)
                {
                    if( o.GetType() == typeof( Grid ))
                    {
                        Grid g2 = o as Grid;

                        foreach (object o2 in g2.Children)
                        {

                            IDLabel i = o2 as IDLabel;

                            while (i.GestureRecognizers.Count > 0)
                            {
                                i.GestureRecognizers.RemoveAt(0);
                            }
                        }
                    }

                }
            }
            */
            // GD.MenuExtension.DestroyMEMenus();
            if (_callbackSelection == null)
            {

            }

            if (_callbackSelection != null)
            {
                // UIS!.StoryTextObj!.DividingLine();
                UIS!.InitBrowserUpdate();
                UIS!.UpdateBrowserCallsPerCycle = 0;
                _callbackSelection(UIS!.MCM!, (sender as IDLabel)!.ID);
                UIS!.StoryTextObj!.AdvTextRefresh();
                UIS!.FinishBrowserUpdate(IUIServices.onBrowserContentLoaded.PageDown);
#if !NEWSCROLL
    UIS!.Scr.SetScrollerToEnd();
#endif
            }
            // UIS!.StoryTextObj.AdvTextOut();
            // UIS!.UpdateBrowser();
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("DoTapEntry: " + ex.Message, IGlobalData.protMode.crisp);
        }



    }

    public void CallBackMCMenuView(int id)
    {
        try
        {
            if (_callbackSelection != null)
            {
                // UIS!.StoryTextObj!.DividingLine();
                UIS!.InitBrowserUpdate();
                // UIS!.UpdateBrowserCallsPerCycle = 0;
                _callbackSelection(UIS!.MCM!, id);
                UIS!.StoryTextObj!.AdvTextRefresh();
                UIS!.FinishBrowserUpdate(IUIServices.onBrowserContentLoaded.PageDown);
#if !NEWSCROLL
            UIS!.Scr.SetScrollerToEnd();
#endif
            }
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("CallBackMCMenuView: " + ex.Message, IGlobalData.protMode.crisp);
        }


    }

    int lvl = 0;

    public bool OpenMCMV { get; set; }
    public MCMenu? NewMCM { get; set; }

    Phoney_MAUI.Model.DelMCMSelection? _mcmvcallbackselection;
    public Phoney_MAUI.Model.DelMCMSelection? MCMVcallbackSelection
    {
        get => _mcmvcallbackselection;
        set
        {
            if (value == null)
            {
                // int a = 5;
            }
            _mcmvcallbackselection = value;
        }
    }
    public bool MCMVCanBeInterrupted { get; set; }
    public int MCMVWait { get; set; }

    /*
    public void MCOutput(MCMenu MCM, Phoney_MAUI.Model.DelMCMSelection callbackSelection, bool CanBeInterrupted)
    {
        if(GD.MenuExtension.MEMenus.Count == 0 )
        {

        }
        OpenMCMV = true;
        NewMCM = MCM;
        MCMVcallbackSelection = callbackSelection;
        MCMVCanBeInterrupted = CanBeInterrupted;
        GD.MenuExtension.MEMenus[GD.MenuExtension.MEMenus.Count - 1].InnerView.Clear();
        MCMVWait = 5;
        UIS!.DoUpdateBrowser = true;
    }

    public void MCOutputExecute()
    {
        OpenMCMV = false;
        MCMenu MCM = NewMCM;
        Phoney_MAUI.Model.DelMCMSelection callbackSelection = MCMVcallbackSelection;
        bool CanBeInterrupted = MCMVCanBeInterrupted;
        lvl++;

        if (GD.MenuExtension.MEMenus.Count < 1) return;

        if( GD.MenuExtension.MEMenus[GD.MenuExtension.MEMenus.Count - 1].InnerView != null )
        {
            UIS!.MCM = MCM;
            _callbackSelection = callbackSelection;

            GD.MenuExtension.MEMenus[GD.MenuExtension.MEMenus.Count - 1].InnerView.Clear();
            int startVal = 0;

            if( MCM.GetCurrent(0).Speaker == null && MCM.Current.Count > 0 )
            {
                GD.MenuExtension.MEMenus[GD.MenuExtension.MEMenus.Count - 1].HeaderLabel.Text = MCM.GetCurrent(0)!.Text;
                startVal++;
            }

            int Limit = MCM.Current.Count;

            ScrollView sv = new();
            GD.MenuExtension.MEMenus[GD.MenuExtension.MEMenus.Count - 1].InnerView.Add(sv);

            
            VerticalStackLayout vsl = new();
            sv.Content = vsl;
            tapvsl = vsl;
            vsl.GestureRecognizers.Clear();

            try
            {
                for (int i = startVal; i < Limit; i++)
                {
                    Grid g = new();
                    ColumnDefinitionCollection rdc = new();
                    ColumnDefinition rd1 = new ColumnDefinition(new GridLength(40));
                    rdc.Add(rd1);
                    ColumnDefinition rd2 = new ColumnDefinition(new GridLength(1, GridUnitType.Star));
                    rdc.Add(rd2);
                    g.ColumnDefinitions = rdc;
                    g.GestureRecognizers.Clear();
                    vsl.Add(g);

                    Thickness margin = new Thickness(6, 6, 6, 6);

                    List<string> LS1 = new();
                    LS1.Add("IDLabel_BG_FG_Small");

      
                   
                    IDLabel l = new();

               
                    g.Add(l);
                    g.SetColumn(l, 1);
                    l.Text = MCM.GetCurrent(i)!.Text;
                    l.LineBreakMode = LineBreakMode.WordWrap;
                    l.Margin = margin;
                    l.ID = MCM.GetCurrent(i)!.ID;
                    l.StyleClass = LS1;
                    l.GestureRecognizers.Clear();
                    TapGestureRecognizer tgr = new();
                    tgr.Tapped += DoTapEntry;
                    l.GestureRecognizers.Add(tgr);
                    // }

                    string s = null;

                    if (MCM.GetCurrent(i)!.Keys.Count > 0)
                        if (MCM.GetCurrent(i)!.Keys[0] > 0)
                            // Noloca: 001
                            s = char.ToString((char)(MCM.GetCurrent(i)!.Keys[0])) + ". ";


                    if (s != null)
                    {
                        IDLabel l2 = new();
                        l2.Text = s;
                        l2.Margin = margin;
                        l2.StyleClass = LS1;
                        g.Add(l2);
                        g.SetColumn(l2, 0);

                    }
                }
            }
            catch( Exception e)
            {
                int a = 5;
            }

        }
        //  mcmwObj.MCOutput(MCM, callbackSelection, CanBeInterrupted);
    }
        */

    /*
    public void MCOutput(MCMenu MCM, Phoney_MAUI.Model.DelMCMSelection callbackSelection, bool CanBeInterrupted)
    {
        if (GD.MenuExtension.MEMenus.Count == 0)
        {

        }
        OpenMCMV = true;
        NewMCM = MCM;
        MCMVcallbackSelection = callbackSelection;
        MCMVCanBeInterrupted = CanBeInterrupted;
        GD.MenuExtension.MEMenus[GD.MenuExtension.MEMenus.Count - 1].InnerView.Clear();
        MCMVWait = 5;
        UIS!.DoUpdateBrowser = true;
    }
    */
    public static MyTouchBehavior? touchBehaviorB1 = null;
    public void MCOutput(MCMenu MCM_par, Phoney_MAUI.Model.DelMCMSelection? callbackSelection_par, bool CanBeInterrupted_par)
    {
        try
        {
            if (callbackSelection_par != null)
                GD!.Adventure!.Orders!.MCCallbackName = callbackSelection_par.Method.Name;
            else
            {
                GD!.Adventure!.Orders!.MCCallbackName = null;

            }
            if (GD.MCAsContextmenu == true)
            {
                MCMenu MCM = MCM_par;
                Phoney_MAUI.Model.DelMCMSelection? callbackSelection = callbackSelection_par;
                bool CanBeInterrupted = CanBeInterrupted_par;
                lvl++;

                if (GD.MenuExtension!.MEMenus.Count < 1) return;

                if (GD.MenuExtension.MEMenus[GD.MenuExtension.MEMenus.Count - 1].InnerView != null)
                {
                    UIS!.MCM = MCM;

                    if (callbackSelection != null)
                        _callbackSelection = callbackSelection;

                    GD!.MenuExtension!.MEMenus[GD!.MenuExtension!.MEMenus.Count - 1]!.InnerView!.Clear();
                    int startVal = 0;

                    if (MCM!.GetCurrent(0)!.Speaker == 0 && MCM.Current!.Count > 0)
                    {
                        GD!.MenuExtension!.MEMenus![GD!.MenuExtension!.MEMenus.Count - 1]!.HeaderLabel!.Text = MCM.GetCurrent(0)!.Text;
                        startVal++;
                    }

                    int Limit = MCM.Current!.Count;

                    ScrollView sv = UIElement.NewScrollView();
                    GD!.MenuExtension!.MEMenus[GD!.MenuExtension!.MEMenus.Count - 1]!.InnerView!.Add(sv);


                    VerticalStackLayout vsl = UIElement.NewVerticalStackLayout();
                    sv.Content = vsl;
                    // tapvsl = vsl;
                    vsl.GestureRecognizers.Clear();

                    for (int i = startVal; i < Limit; i++)
                    {
                        Grid g = UIElement.NewGrid();
                        ColumnDefinitionCollection rdc = new();
                        ColumnDefinition rd1 = new ColumnDefinition(new GridLength(40));
                        rdc.Add(rd1);
                        ColumnDefinition rd2 = new ColumnDefinition(new GridLength(1, GridUnitType.Star));
                        rdc.Add(rd2);
                        g.ColumnDefinitions = rdc;
                        g.GestureRecognizers.Clear();
                        g.SetCursorHand();
                        vsl.Add(g);

                        Thickness margin = new Thickness(6, 6, 6, 6);

                        List<string> LS1 = new();
                        LS1.Add("IDLabel_BG_FG_Small");



                        IDLabel l = UIElement.NewIDLabel();


                        g.Add(l);
                        g.SetColumn(l, 1);
                        l.Text = MCM.GetCurrent(i)!.Text;
                        l.LineBreakMode = LineBreakMode.WordWrap;
                        l.Margin = margin;
                        l.ID = MCM.GetCurrent(i)!.ID;
                        l.StyleClass = LS1;
                        l.GestureRecognizers.Clear();
                        TapGestureRecognizer tgr = new();
                        tgr.Tapped += DoTapEntry;
                        l.GMethods.Add(new IDLabel.GestureMethods(tgr, DoTapEntry));
                        l.GestureRecognizers.Add(tgr);
                        l.SetCursorHand();
                        // }

                        string? s = null;

                        if (MCM.GetCurrent(i)!.Keys!.Count > 0)
                            if (MCM.GetCurrent(i)!.Keys![0] > 0)
                                // Noloca: 001
                                s = char.ToString((char)(MCM.GetCurrent(i)!.Keys![0])) + ". ";


                        if (s != null)
                        {
                            IDLabel l2 = UIElement.NewIDLabel();
                            l2.Text = s;
                            l2.Margin = margin;
                            l2.StyleClass = LS1;
                            l2.SetCursorHand();
                            g.Add(l2);
                            g.SetColumn(l2, 0);

                        }
                    }

                }
            }
            else
            {
                MCMenu MCM = MCM_par;
                Phoney_MAUI.Model.DelMCMSelection? callbackSelection = callbackSelection_par;
                bool CanBeInterrupted = CanBeInterrupted_par;
                lvl++;
                if (callbackSelection != null)
                    _callbackSelection = callbackSelection;


                if (_mcGrid != null)
                {
                    App.CurrentPage!.Focus();
                    UIS!.MCM = MCM;

                    TreeView.EmptyTreeViewItem(_mcGrid!, false, false, true );

                    _mcGrid.Clear();
                    int startVal = 0;

                    /*
                    if (MCM.GetCurrent(0).Speaker == null && MCM.Current.Count > 0)
                    {
                        GD.MenuExtension.MEMenus[GD.MenuExtension.MEMenus.Count - 1].HeaderLabel.Text = MCM.GetCurrent(0)!.Text;
                        startVal++;
                    }
                    */

                    int Limit = MCM.Current!.Count;

                    ScrollView sv = UIElement.NewScrollView();
                    _mcGrid.Add(sv);


                    VerticalStackLayout vsl = UIElement.NewVerticalStackLayout();
                    sv.Content = vsl;
                    // tapvsl = vsl;
                    vsl.GestureRecognizers.Clear();

                    for (int i = startVal; i < Limit; i++)
                    {
                        if (MCM!.GetCurrent(i)!.Speaker == 0 && i == 0)
                        {
                            Grid g = UIElement.NewGrid();
                            ColumnDefinitionCollection rdc = new();
                            ColumnDefinition rd1 = new ColumnDefinition(new GridLength(0));
                            rdc.Add(rd1);
                            ColumnDefinition rd2 = new ColumnDefinition(new GridLength(1, GridUnitType.Star));
                            rdc.Add(rd2);
                            g.ColumnDefinitions = rdc;
                            g.GestureRecognizers.Clear();
                            vsl.Add(g);

                            Thickness margin = new Thickness(6, 2 + GlobalSpecs.CurrentGlobalSpecs!.GetClickMarginPixel(), 6, 2 + GlobalSpecs.CurrentGlobalSpecs.GetClickMarginPixel());

                            // Thickness m = new(0, GlobalSpecs.CurrentGlobalSpecs.GetClickMarginPixel(), 0, GlobalSpecs.CurrentGlobalSpecs.GetClickMarginPixel());
                            // l1.Margin = m;

                            List<string> LS1 = new();
                            LS1.Add("IDLabel_Normal");
                            IDLabel l = UIElement.NewIDLabel();
                            g.Add(l);
                            g.SetColumn(l, 1);
                            l.Text = MCM.GetCurrent(i)!.Text;
                            l.LineBreakMode = LineBreakMode.WordWrap;
                            l.Margin = margin;
                            l.ID = MCM.GetCurrent(i)!.ID;
                            l.StyleClass = LS1;
                            l.GestureRecognizers.Clear();
                            TapGestureRecognizer tgr = new();
                            tgr.Tapped += DoTapEntry;
                            l.GMethods.Add(new IDLabel.GestureMethods(tgr, DoTapEntry));

                            l.GestureRecognizers.Add(tgr);
                            l.SetCursorHand();

#if WINDOWS
                            var touchBehaviorL = new TouchBehavior
                            {
                                // HoveredBackgroundColor = Colors.AliceBlue,
                                HoveredOpacity = 1.0

                            };
                            l.Behaviors.Add(touchBehaviorL);
#elif ANDROID
                            int grefCount = Java.Interop.JniRuntime.CurrentRuntime.GlobalReferenceCount;
                            if (grefCount < 10000)
                            {
                                TouchBehavior tb1 = new MyTouchBehavior
                                {
                                    HoveredOpacity = 0.5,
                                    PressedOpacity = 0.5

                                };
                                l.Behaviors.Add(tb1);
                            }

#endif
                        }
                        else
                        {
                            Grid g = UIElement.NewGrid();
                            ColumnDefinitionCollection rdc = new();
                            ColumnDefinition rd1 = new ColumnDefinition(new GridLength(40));
                            rdc.Add(rd1);
                            ColumnDefinition rd2 = new ColumnDefinition(new GridLength(1, GridUnitType.Star));
                            rdc.Add(rd2);
                            g.ColumnDefinitions = rdc;
                            g.GestureRecognizers.Clear();
                            vsl.Add(g);

                            // Thickness margin = new Thickness(6, 2, 6, 2);
                            Thickness margin = new Thickness(6, 2 + GlobalSpecs.CurrentGlobalSpecs!.GetClickMarginPixel(), 6, 2 + GlobalSpecs.CurrentGlobalSpecs.GetClickMarginPixel());

                            List<string> LS1 = new();
                            LS1.Add("IDLabel_Normal");
                            IDLabel l = UIElement.NewIDLabel();
                            g.Add(l);
                            g.SetColumn(l, 1);
                            l.Text = MCM.GetCurrent(i)!.Text;
                            l.LineBreakMode = LineBreakMode.WordWrap;
                            l.Margin = margin;
                            l.ID = MCM.GetCurrent(i)!.ID;
                            l.StyleClass = LS1;
                            l.GestureRecognizers.Clear();
                            TapGestureRecognizer tgr = new();
                            tgr.Tapped += DoTapEntry;
                            l.GMethods.Add( new IDLabel.GestureMethods( tgr, DoTapEntry));
                            l.GestureRecognizers.Add(tgr);
                            l.SetCursorHand();

#if WINDOWS
                            var touchBehaviorL = new TouchBehavior
                            {
                                // HoveredBackgroundColor = Colors.AliceBlue,
                                HoveredOpacity = 0.7,
                                PressedOpacity = 0.7


                            };
                            l.Behaviors.Add(touchBehaviorL);
#elif ANDROID
                            int grefCount = Java.Interop.JniRuntime.CurrentRuntime.GlobalReferenceCount;
                            if (grefCount < 10000)
                            {
                                TouchBehavior tb1 = new MyTouchBehavior
                                {
                                    HoveredOpacity = 0.5,
                                    PressedOpacity = 0.5

                                };
                                l.Behaviors.Add(tb1);
                            }

#endif
                            string? s = null;

                            if (MCM.GetCurrent(i)!.Keys!.Count > 0)
                                if (MCM.GetCurrent(i)!.Keys![0] > 0)
                                    // Noloca: 001
                                    s = char.ToString((char)(MCM.GetCurrent(i)!.Keys![0])) + ". ";


                            if (s != null)
                            {
                                IDLabel l2 = UIElement.NewIDLabel();
                                l2.Text = s;
                                l2.Margin = margin;
                                l2.StyleClass = LS1;
                                l2.SetCursorHand();
                                g.Add(l2);
                                g.SetColumn(l2, 0);

                            }
                        }
                    }

                }

            }
        }

        catch (Exception e)
        {

            GlobalData.AddLog("MCOutput: " + e.Message, IGlobalData.protMode.crisp);

        }
    }
}

public class GameDefinitions : IGameDefinitions
{
    public IGameDefinitions.mcvMode MCVisible { get; set; }
    public int MCVLastSpeaker { get; set; }
    public string? MCVFuncName { get; set; }
    public int MCID { get; set; }
    public int MCPersonID { get; set; }
    public IGlobalData.picMode PicMode { get; set; }
    public MCMenu? MCMenuTemp { get; set; }
    public string? MCCallbackName { get; set; }
    public bool STTContinuous { get; set; }

    public string? CurrentEventName { get; set; }
    // public ObservableCollection<OrderTable>? OtlCurrent { get; set; }
    public int IxCurrent { get; set; }
    public int ActLocEvent { get; set; }
    public int ActLocEventSeqStart { get; set; }
    public int ActLocEventStartPoint { get; set; }
    public int LastLocEventStartPoint { get; set; }
    public bool ActLocCollecting { get; set; }
    public int LastLoc { get; set; }
    public int ActLoc { get; set; }
}

[Serializable]
public class FeedbackText
{

    public int FeedbackOffMC { get; set; }
    public static int FeedbackSizeMC { get; set; }
    public int FeedbackCountMC { get; set; }
    public bool FeedbackModeMC { get; set; }

    public List<string>? FeedbackWindowText { get; set; }
    public List<string>? FeedbackWindowTextMC { get; set; }


    public void FeedbackTextOutput(string s, string? relatedText = null)
    {

    }


    public void FeedbackWindowInitText()
    {

    }

    public void FeedbackTextReFreshman()
    {
    }
}

/*
Der neue Scroller weist folgende Eigenschaften auf:
- DoScroll wird wie gewohnt 100x pro Sekunde aufgerufen...
- ... und die HTML-Werte werden 5x pro Sekunde vermerkt
- Das Fenster kennt zwei Darstellungsmodi
-- More: Dann ist HTMLViewYPos nicht auf der Maximum-Position. Unten ist der MORE-Button zu sehen. Ein Tastendruck
   scroll um eine Page nach unten
-- End: Dann ist HTMLViewYPos am Maximum
- Welche Positionsdaten sind relevant?
-- HTMLViewYPos: Die aktuelle Y-Position im Fenster
-- Startposition Y für jeden Turn
-- Gesamthöhe des physikalischen Sichtbereichs des Fensters
-- Gesamthöhe des logischen HTML-Fensters
- Wie wird gescrollt
-- Ermittlung Y-Position via HTML
-- Ermittlung Ziel-Y-Position durch logische Fensterhöhe (begrenzt durch aktuelle Y-Position + physikalische Fensterhöhe)
-- Über HTML-Softscrolling wird zur Zielposition gescrollt (es wird absolut NICHTS mehr hard gecodet hier)
- Welche Steuerfunktionalität wird benötigt
-- Mit jedem Turn wird die Startposition Y gesetzt, das ist HTMLViewPos
-- Gescrollt werden darf bis maximal Startposition Y + Fensterhöhe - Abstand
-- Bis dann wird dann von DoScroll auch soft gescrollt
- Jede Öffnung eines MC Menüs löst folgendes aus 
-- Die Texthistory wird drastisch reduziert auf maximal 100 Zeilen
-- Es wird ans komplette Ende des scrollbaren Bereichs gesprungen
Und das wars auch schon, was an Logik gebraucht wird. 90% derselben landet auf dem Müll
 */

public class Scroller : IScroller
{

    public IScroller.scrollStep ScrollStep { get; set; } = IScroller.scrollStep.none;

    private IScroller.scrollMode __scrollMode = 0;
    public  IScroller.scrollMode _scrollMode
    {
        get => __scrollMode;
        set
        {
            __scrollMode = value;
        }
    }
    private IScroller.rescalerMode __rescalerMode = 0;
    public IScroller.rescalerMode _rescalerMode
    {
        get => __rescalerMode;
        set
        {
            __rescalerMode = value;
        }
    }
    private double _htmlViewYPos = 0;
    private double _htmlViewMaxYPos = 0;
    private double _htmlViewHeight = 0;
    private int _scrollModeCountDown = 0;
    private int _rescalerModeCountDown = 0;
    public bool _screenRefreshed = false;
    public int _jumpToEndWait = 0;

    public GlobalData? GD
    {
        get => GlobalData.CurrentGlobalData;
        set
        {
            GlobalData.CurrentGlobalData = value;
        }
    }

    public Phoney_MAUI.Model.IUIServices? UIS
    {
        get => GlobalData.CurrentGlobalData!.UIS;
        set => GlobalData.CurrentGlobalData!.UIS = value;
    }

    public IScroller.scrollMode ScrollMode
    {
        get => _scrollMode;
        set => _scrollMode = value;

    }

    public int ScrollModeCountDown
    {
        get => _scrollModeCountDown;
        set => _scrollModeCountDown = value;
    }

    public Scroller()
    {

    }
    public Scroller(IUIServices uis)
    {
    }

    public void DoOnBrowserContentLoad()
    {
        try
        {
            GlobalData.AddLog("DoOnBrowserContentLoad in", IGlobalData.protMode.extensive);
            if (UIS!.OnBrowserContentLoaded == IUIServices.onBrowserContentLoaded.nothing)
            {
                GlobalData.AddLog("DoOnBrowserContentLoad nothing", IGlobalData.protMode.extensive);
                return;
            }
             if (HTMLViewMaxYPos > 0)
            {
                if (UIS!.OnBrowserContentLoaded == IUIServices.onBrowserContentLoaded.PageDown)
                {
                    GlobalData.AddLog("PageDown by OnBrowserContentLoad", IGlobalData.protMode.extensive);
                    PageDown();
                }
                else if (UIS.OnBrowserContentLoaded == IUIServices.onBrowserContentLoaded.ScrollToEnd)
                {
                    ScrollToEnd();
                }
                else if (UIS.OnBrowserContentLoaded == IUIServices.onBrowserContentLoaded.SetToEnd)
                {
                    SetToEnd();
                }

                UIS.OnBrowserContentLoaded = IUIServices.onBrowserContentLoaded.nothing;
            }
            GlobalData.AddLog("DoOnBrowserContentLoad out", IGlobalData.protMode.extensive);
        }
        catch( Exception e)
        {
            GlobalData.AddLog("DoOnBrowserContentLoad: " + e.Message, IGlobalData.protMode.crisp);
        }
    }

    // int CountFlushes = 0;
    public bool ResetWait()
    {
        try
        {
            // CountFlushes = 0;
            UIS!.BrowserRefreshOngoing = false;
            FlushJavaScript();
            InqScrollingAreaAsync().GetAwaiter();

            // Wenn der Scrollbereich noch keine Höhe hat, dann scrollt er auch nicht.
            // Wenn dieser Aufruf hier übersprungen wird, dann ruft ihn InqScrollingAreaAsync() auf
            if (HTMLViewMaxYPos > 0)
                DoOnBrowserContentLoad();
            else
            {

            }
            _scrollModeCountDown = 15;
            HTMLViewWait = 0;
            ctInqScrollArea = 20;
            // PageDown();
            return true;
        }
        catch (Exception e)
        {
            GlobalData.AddLog("ResetWait: " + e.Message, IGlobalData.protMode.crisp);
            return false;
        }

    }

    public void SetToPos(int yPos)
    {
        try
        {
            if (Math.Abs(yPos - HTMLViewYPos) > 100)
            {

            }
            if (yPos > (int)HTMLViewMaxYPos)
            {
                yPos = (int)HTMLViewMaxYPos;
            }
            HTMLLastSet3 = HTMLLastSet2;
            HTMLLastSet2 = HTMLLastSet;
            HTMLLastSet = yPos;

            // yPos = Double.Round(yPos, MidpointRounding.ToEven );
            string s1 = "window.scrollTo({ top: " + yPos + " });";

            // Action<string> a = delegate(string s1) { StartScrollOrder(s1); };
            StartScrollOrder(s1).GetAwaiter();
            /*
            Task task = Task.Run(() => StartScrollOrder(s1));
            task.Wait();
            */
        }
        catch (Exception e)
        {
            GlobalData.AddLog("SetToPos: " + e.Message, IGlobalData.protMode.crisp);
        }


    }

    public async Task StartScrollOrder(string scrollOrder)
    {
        try
        {
            if (UIS!.BrowserRefreshOngoing)
            {
                jsCallbacks!.Add(scrollOrder);
            }
            else
            {
                try
                {
                    // scrollOrder += " console.log( window.pageYOffset );";
                    // scrollOrder += " console.log( \"" + scrollOrder + "\" );";
                    var response2 = await UIS!.ExternalGameOut!.EvaluateJavaScriptAsync(scrollOrder);
                    if (response2 == null)
                    {

                    }
                }
                catch (Exception e)
                {
                    Phoney_MAUI.Core.GlobalData.AddLog("StartScrollOrder: " + e.Message, IGlobalData.protMode.crisp);
                }
            }
        }
        catch (Exception e)
        {
            GlobalData.AddLog("StartScrollOrder: " + e.Message, IGlobalData.protMode.crisp);
        }

    }

    public void DelaySet( )
    {
        _scrollMode = IScroller.scrollMode.delaySet;
        _scrollModeCountDown = 0;

    }
    public void ScrollEnd( double From )
    {
        // SetToPos( (int) From );
        _scrollMode = IScroller.scrollMode.delayScroll;
        _scrollModeCountDown = 30;
    }
    public void ScrollEnd()
    {
        // SetToPos( (int) From );
        _scrollMode = IScroller.scrollMode.delayScroll;
        _scrollModeCountDown = 30;
    }
    public void ScrollEndWait( int wait)
    {
        // SetToPos( (int) From );
        _scrollMode = IScroller.scrollMode.delayScroll;
        _scrollModeCountDown = wait;
    }

    public void ScrollToEnd()
    {
        try
        {
            int yPos = (int)HTMLViewMaxYPos;

            GlobalData.AddLog("Endscroller: " + "window.scrollTo({ top: " + yPos + ", behavior: 'smooth' }", IGlobalData.protMode.medium);

            string s1 = "window.scrollTo({ top: " + yPos + ", behavior: 'smooth' });";

            StartScrollOrder(s1).GetAwaiter();
        }
        catch (Exception e)
        {
            GlobalData.AddLog("ScrollToEnd: " + e.Message, IGlobalData.protMode.crisp);
        }

    }
    public void SetToEnd()
    {
        try
        {
            int yPos = (int)HTMLViewMaxYPos;

            GlobalData.AddLog("Endjumper: " + "window.scrollTo({ top: " + yPos + ", behavior: 'smooth' }", IGlobalData.protMode.medium);

            string s1 = "window.scrollTo({ top: " + yPos + " });";

            StartScrollOrder(s1).GetAwaiter();
        }
        catch (Exception e)
        {
            GlobalData.AddLog("SetToEnd: " + e.Message, IGlobalData.protMode.crisp);
        }

    }

    public void SetRescale()
    {
        _rescalerMode = IScroller.rescalerMode.delayRescale;
        _rescalerModeCountDown = 30;
    }

    public void PageToEnd()
    {
        _scrollMode = IScroller.scrollMode.delayJump;
        _scrollModeCountDown = 30;

    }
    public void RefreshJumpToEnd()
    {
        _scrollMode = IScroller.scrollMode.delayRefreshJump;
        _scrollModeCountDown = 30;


    }

    public void PageDown()
    {
        try
        {
            double y = HTMLViewYPos + HTMLViewHeight - 30;

            y = Double.Round(y, MidpointRounding.ToEven);

            if (y < 1000)
            {

            }
            GlobalData.AddLog("PageDowner: " + "window.scrollTo({ top: " + y + ", behavior: 'smooth' }", IGlobalData.protMode.medium);
            string s1 = "window.scrollTo({ top: " + y + ", behavior: 'smooth' });";

            StartScrollOrder(s1).GetAwaiter();

            /*
            Task task = Task.Run(() => StartScrollOrder(s1));
            task.Wait();
            */
        }
        catch (Exception e)
        {
            GlobalData.AddLog("PageDown: " + e.Message, IGlobalData.protMode.crisp);
        }

    }

    public void ScrollPage()
    {

    }

    public enum YPosModes { none, backfrommc, backfrommc2, startmc, startmc2, startwebview }

    public YPosModes YPosMode { get; set; } = YPosModes.none;
    public double HTMLViewYRef
    {
        get;
        set;
    }
    public double HTMLViewYPos
    {
        get => _htmlViewYPos;
        set 
        { 
            double valD = Double.Round( value, MidpointRounding.ToEven);

            if( valD <= 0)
            {

            }

            _htmlViewYPos = valD; 
        }
    }
    public double HTMLViewMaxYPos
    {
        get => _htmlViewMaxYPos;
        set 
        {
            if( value == 0 )
            {

            }
            if (_htmlViewMaxYPos != value)
            {
                _htmlViewMaxYPos = value;
            }
        }
    }
    public double HTMLViewWait { get; set; }
    public double HTMLViewTotal { get; set; }
    public double HTMLLastSet { get; set; }
    public double HTMLLastSet2 { get; set; }
    public double HTMLLastSet3 { get; set; }
    public double HTMLViewHeight
    {
        get => _htmlViewHeight;
        set
        {
            if (value < _htmlViewHeight)
            {

            }
            if( value == 637 )
            {

            }
            else if ( value == 780)
            {

            }

            _htmlViewHeight = value;
        }
    }

    int ctInqScrollArea = 0;
    // Task<bool>? txx;

    // Dieser Mechanismus sorgt dafür, dass die aktuelle Scrollposition im HTML-Fenster nur ca. 5x pro Sekunde abgefragt wird 
    // (was mehr als reicht)
    public void SetFastScrollingArea()
    {
        ctInqScrollArea = 19;
    }

    int FlushJS = 0;
    public void FlushJavaScript()
    {
        if( FlushJS > 0)
        // if (MainThread.IsMainThread == false)
        {
            return;
        }

        FlushJS++;


        try
        {
            if (UIS!.BrowserRefreshOngoing == false)
            {
                if (jsCallbacks!.Count > 1)
                {
                }

                while (jsCallbacks.Count > 0)
                {
                    int len = 100;
                    if (jsCallbacks[0].Length < 100)
                        len = jsCallbacks[0].Length;

                    GlobalData.AddLog("Flushed: " + jsCallbacks[0].Substring(0, len), IGlobalData.protMode.crisp);

                    string s1 = (string) jsCallbacks[0].Clone();
                    var task = Task.Run(async () => await UIS!.ExternalGameOut!.EvaluateJavaScriptAsync(s1!));
                    // task.Wait();
                    // UIS!.ExternalGameOut!.EvaluateJavaScriptAsync(jsCallbacks[0]!);
                    GlobalData.AddLog("Remove JS On", IGlobalData.protMode.crisp);
                    jsCallbacks.RemoveAt(0);
                    GlobalData.AddLog("Remove JS Off", IGlobalData.protMode.crisp);
                }
            }
        }
        catch (Exception e)
        {
            GlobalData.AddLog("FlushJavaScript: " + e.Message, IGlobalData.protMode.crisp);
        }
        FlushJS--;
    }

    List<string>? jsCallbacks = null;
    public void DoScroll()
    {
        try
        {
            if (jsCallbacks == null)
            {
                jsCallbacks = new();
            }

            FlushJavaScript();
            /*
            try
            {
                var result = UIS!.ExternalGameOut.EvaluateJavaScriptAsync("Jehova").Result; // get the value of someVariable from JavaScript
            }
            catch (Exception e)
            {

            }
            */

            UIS!.UpdateBrowserCallsPerCycle = 0;

            ctInqScrollArea++;
            if (ctInqScrollArea >= 20)
            {
                InqScrollingAreaAsync().GetAwaiter();
                ctInqScrollArea = 0;
            }
            /*
            if (ct >= 20 && (txx == null || txx.IsCompleted == true || txx.IsCanceled == true ||
                             txx.IsCompletedSuccessfully == true || txx.IsFaulted == true))
            {
                TaskAwaiter tai = InqScrollingAreaAsync().GetAwaiter();



                txx = (System.Threading.Tasks.Task<bool>) InqScrollingAreaAsync().GetAwaiter().GetResult();
                ct = 0;
            }
            */

            // Der Bildrescaler muss aufgerufen werden?
            if (_rescalerMode == IScroller.rescalerMode.delayRescale)
            {
                _rescalerModeCountDown--;
                if (_rescalerModeCountDown <= 0)
                {
                    UIS!.RecalcPictures();
                    _rescalerMode = IScroller.rescalerMode.none;
                }
            }


            // None: Hier tun wir nüschte
            if (_scrollMode == IScroller.scrollMode.none)
            {

            }
            else if (_scrollMode == IScroller.scrollMode.delaySet)
            {
                _scrollModeCountDown--;
                if (_scrollModeCountDown <= 0)
                {
                    SetToPos((int)HTMLViewYRef);
                    _scrollModeCountDown = 15;
                    _scrollMode = IScroller.scrollMode.delayScroll;
                }
            }
            else if (_scrollMode == IScroller.scrollMode.delayScroll)
            {
                _scrollModeCountDown--;
                if (_scrollModeCountDown <= 0)
                {
                    _screenRefreshed = false;
                    _scrollMode = IScroller.scrollMode.scrollToEnd;
                }
            }
            else if (_scrollMode == IScroller.scrollMode.delayJump)
            {
                _scrollModeCountDown--;
                if (_scrollModeCountDown <= 0)
                {
                    double y = HTMLViewMaxYPos;

                    y = Double.Round(y, MidpointRounding.ToEven);
                    string s1 = "window.scrollTo({ top: " + y + "});";

                    StartScrollOrder(s1).GetAwaiter();
                    /*
                    Task task = Task.Run(() => StartScrollOrder(s1));
                    task.Wait();
                    */

                    _scrollMode = IScroller.scrollMode.none;
                }
            }
            else if (_scrollMode == IScroller.scrollMode.delayRefreshJump)
            {
                _scrollModeCountDown--;
                if (_scrollModeCountDown <= 0)
                {
                    UIS!.FinishBrowserUpdate();
                    _scrollMode = IScroller.scrollMode.delayJump;
                    _scrollModeCountDown = 30;
                }
            }



            else if (_scrollMode == IScroller.scrollMode.scrollToEnd)
            {
                if (UIS.OnBrowserContentLoaded == IUIServices.onBrowserContentLoaded.nothing && HTMLViewMaxYPos > 0)
                {
                    double yDest = HTMLViewMaxYPos;

                    // if( HTMLViewYPos == 0)
                    // {
                    // InqScrollingAreaAsync().GetAwaiter();
                    // }

                    // string s3 = UIS.ExternalGameOut. ($"window.pageYOffset").GetAwaiter().GetResult();
                    // HTMLViewYPos = Double.Parse(s3);

                    /*
                    if (yDest > HTMLViewYPos + HTMLViewHeight - 30)
                    {
                        yDest = HTMLViewYPos + HTMLViewHeight - 30;
                    }
                    */
                    yDest = Double.Round(yDest, MidpointRounding.ToEven);

                    GlobalData.AddLog("scrollToEnd Call from DoScroll: " + HTMLViewYPos.ToString() + " " + HTMLViewHeight.ToString() + " " + HTMLViewMaxYPos.ToString(), IGlobalData.protMode.crisp);


                    string s1 = "window.scrollTo({ top: " + yDest + ", behavior: 'smooth' });";

                    StartScrollOrder(s1).GetAwaiter();
                    /*
                    Task task = Task.Run(() => StartScrollOrder(s1));
                    task.Wait();
                    */

                    _scrollMode = IScroller.scrollMode.none;
                    // HTMTLViewYPos = HTMLViewMaxYPos;
                }
            }

            if (GD!.ProvideMoreGrid != null)
            {
                // ToDo: Ein/Ausblenden des More-Feldes
                if ((HTMLViewYPos + HTMLViewHeight) < (HTMLViewMaxYPos - 5) &&
                    GD.ProvideMoreGrid(true, 1).IsVisible == false && UIS!.MCMVVisible == false)
                {
                    HTMLViewWait++;
                    if (HTMLViewWait > 70)
                    {
                        if (GD.SelectOutput != null)
                            GD.SelectOutput(ILayoutDescription.selectedOutput.more);
                    }
                }
                else if ((HTMLViewYPos + HTMLViewHeight) >= (HTMLViewMaxYPos - 5) &&
                         GD.ProvideMoreGrid(true, 1).IsVisible == true && UIS!.MCMVVisible == false)
                {
                    if (GD.SelectOutput != null)
                        GD.SelectOutput(ILayoutDescription.selectedOutput.input);

                    if (GlobalData.CurrentGlobalData!.FocusMethod != null)
                        GlobalData.CurrentGlobalData!.FocusMethod();
                    HTMLViewWait = 0;
                    // _w.Inputline.Focus();
                    // ScrollToEnd = false;
                }
            }
        }
        catch (Exception e)
        {
            GlobalData.AddLog("DoScroll: " + e.Message, IGlobalData.protMode.crisp);
        }

    }

    public void Gedoens()
    {
        // In der .NET MAUI-App
        WebView webView = new WebView();
        webView.Source = "https://example.com"; // Die URL der Webseite, die angezeigt werden soll
        webView.Navigating += OnWebViewNavigating; // Der Ereignishandler für das Navigating-Ereignis

        async void OnWebViewNavigating(object? sender, WebNavigatingEventArgs e)
        {
            try
            {
                // Prüfe, ob die Navigation zu einer anderen URL erfolgt
                if (e.Url != webView.Source.ToString())
                {
                    // Unterdrücke die Navigation, indem du die Source-Eigenschaft auf die aktuelle URL setzt
                    webView.Source = webView.Source;

                    // Definiere eine JavaScript-Funktion, die die document.readyState-Eigenschaft zurückgibt
                    string jsFunction = "function getDocumentReadyState() { return document.readyState; }";

                    // Füge die JavaScript-Funktion der Webseite hinzu
                    await webView.EvaluateJavaScriptAsync(jsFunction);

                    // Warte, bis die neue Webseite geladen ist
                    string result = await webView.EvaluateJavaScriptAsync("new Promise((resolve, reject) => { var interval = setInterval(() => { var state = getDocumentReadyState(); if (state == 'complete') { clearInterval(interval); resolve(state); } }, 100); });");

                    // Prüfe, ob die Webseite vollständig geladen ist
                    if (result == "complete")
                    {
                        // Setze die Source-Eigenschaft auf die neue URL, um die Aktualisierung der Website durchzuführen
                        webView.Source = e.Url;
                    }
                }
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("Gedoens: " + ex.Message, IGlobalData.protMode.crisp);
            }
        }
}

    public async Task<bool> InqScrollingAreaAsync()
    {
        if (UIS!.BrowserRefreshOngoing)
            return false;

        if (UIS!.ExternalGameOut == null)
            return false;

        if (GlobalSpecs.CurrentGlobalSpecs!.AppRunning == IGlobalSpecs.appRunning.quit || GlobalSpecs.CurrentGlobalSpecs!.AppRunning == IGlobalSpecs.appRunning.start)
            return false;

        string? s;

        try
        {
            IFormatProvider ifp = CultureInfo.CreateSpecificCulture("en-EN");
            string? s2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync($"window.pageYOffset");

            while (s2 == null)
            {
                Thread.Sleep(100);
                s2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync($"window.pageYOffset");
            }
            if (s2 == null)
            {

            }
            double ypos;
            if (Double.TryParse(s2, ifp, out ypos) == true)
            {
                UIS!.Scr.HTMLViewYPos = ypos;
            }
            else
            {
                if (s2 == null) s2 = "(leer)";
                GlobalData.AddLog("Nicht parsebar: " + s2, IGlobalData.protMode.crisp);

            }
            //  ypos = Double.Parse(s2, ifp);
            // if (        UIS.Scr.ScrollStep != IScroller.scrollStep.
            //          ||  UIS.Scr.ScrollStep == IScroller.scrollStep.settingSource 
            //    )
            s = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync($"window.innerHeight");
            if (s != null)
            {
                while (s == null)
                {
                    Thread.Sleep(100);
                    s = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync($"window.innerHeight");
                }
                if (s == null)
                {

                }

                double viewHeight;
                if (Double.TryParse(s, ifp, out viewHeight) == true)
                {
                    UIS!.Scr.HTMLViewHeight = viewHeight;
                }
                else
                {
                    if (s == null)
                    {
                        s = "(leer)";
                    }
                    GlobalData.AddLog("Nicht parsebare HTMLViewHeight: " + viewHeight.ToString(), IGlobalData.protMode.crisp);

                }

            }
            else
            {

            }

            s = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync($"document.body.scrollHeight");
            while (s == null)
            {
                Thread.Sleep(100);
                s = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync($"document.body.scrollHeight");
            }
            if (s != null)
            {
                if (s == null)
                {

                }


                double maxYPos;
                if (Double.TryParse(s, ifp, out maxYPos) == true)
                {
                    UIS!.Scr.HTMLViewMaxYPos = maxYPos;
                }
                else
                {
                    if (s == null) s = "(leer)";
                    GlobalData.AddLog("Nicht parsebare HTMLViewMaxYPos: " + maxYPos.ToString(), IGlobalData.protMode.crisp);

                }


                if (maxYPos < UIS!.Scr.HTMLViewMaxYPos)
                {

                }
                if (maxYPos > 0)
                {

                }

                UIS!.Scr.HTMLViewMaxYPos = maxYPos;
            }
            else
            {

            }
            if (UIS!.Scr.HTMLViewYPos > UIS!.Scr.HTMLViewMaxYPos)
            {

            }
            DoOnBrowserContentLoad();
        }
        catch (Exception e)
        {
            GlobalData.AddLog("InqScrollingAreaAsync: " + e.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
        }

        return true;
    }
    public void JumpToEndInstantly()
    {
        PageToEnd();
    }
    public void CompactToEnd()
    {
        UIS!.StoryTextObj!.RecalcLatest();
        // InqScrollingArea();

    }
}

/*
[Serializable]
public class ScrollerOld : IScroller
{
    public enum renderState { idle, newHeight, hmtlSet, heightGet };
    public IScroller.scrollStep ScrollStep { get; set; }

    private double _yPos = 0;

    private static double currentY = -1;
    private static double targetY = -1;
    private static int framesWithoutMovement = 0;

    private bool _pagingRunning = false;
    private bool _targetAttached = false;

    private double _yMaxPosTargeted = 0;
    public int _jumpToEndWait = 0;

    public enum _scrollphase
    {
        none,
        one,
        two,
        three,
        four
    }

    public bool SetNext { get; set; } = false;

    public double YPos 
    {
        get => _yPos;
        set
        {
            if( value == 0 )
            {
                // int a = 5;
            }
            _yPos = value;
            currentY = value;
        }
    }

    public double HTMLViewYPos { get; set; }
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

    public int ScrollModeCountDown { get; set; }
    public GlobalData GD{get;set; }
    public IUIServices UIS { get; set; }

    public bool ResetWait()
    {
        return true;
    }
    public void PageToEnd()
    {

    }
    public void SetRescale()
    {

    }

    public void RefreshJumpToEnd()
    {

    }
    public ScrollerOld()
    {
        UIS = GlobalData.CurrentGlobalData!.Adventure!.UIS!;
        GD = GlobalData.CurrentGlobalData;
    }
    public ScrollerOld( IUIServices uis )
    {
        UIS = uis;
        GD = GlobalData.CurrentGlobalData!;
    }
    public void PageUp()
    {
        targetY = YPos - WinHeight + 30;
        if (targetY < 0)
            targetY = 0;
        // speedY = 0;

        _pagingRunning = true;

    }
    public void PageDown()
    {
        targetY = YPos + WinHeight - 30;
        if (targetY > YMaxPos + 100)
            targetY = YMaxPos + 100;
        // speedY = 0;

        _pagingRunning = true;
    }

    int ct = 0;
    Task<bool>? txx;

    // Scrollroutine wird aktuell 100x pro Sekunde aufgerufen, was wirklich und eindeutig viel zuviel ist
    public void DoScroll()
    {
        try
        {
            var result = UIS!.ExternalGameOut!.EvaluateJavaScriptAsync("Jehova").Result; // get the value of someVariable from JavaScript
        }
        catch (Exception e)
        {
            GlobalData.AddLog("DoScroll: " + e.Message, IGlobalData.protMode.crisp);

        }

        ct++;
        if (ct >= 20 && ( txx == null || txx.IsCompleted == true || txx.IsCanceled == true || txx.IsCompletedSuccessfully == true || txx.IsFaulted == true) )
        {
            txx = InqScrollingAreaAsync();

            ct = 0;
        }


        if (_targetAttached && YMaxPos != _yMaxPosTargeted)
        {
            targetY = YMaxPos - WinHeight + 30;
            _yMaxPosTargeted = YMaxPos;
        }
        else if (targetY == -1)
        {
            _targetAttached = false;
        }

        if (SetToEnd && YMaxPos > 0)
        {
            ScrollToEnd = false;
            if (_jumpToEndWait > 0)
            {
                _jumpToEndWait--;
            }
            if (_jumpToEndWait <= 0)
            {
                currentY = YMaxPos - WinHeight + 30;
                SetToPos((int)(currentY));

                SetToEnd = false;
            }
        }
        else if (ScrollToEnd && RenderState == renderState.heightGet && _pagingRunning == false)
        {
            if (ScrollToEndWait > 0)
            {
                ScrollToEndWait--;
            }
            if (ScrollToEndWait == 0)
            {
                if ((YPos + WinHeight - 30) < (YMaxPos - WinHeight + 30))
                {
                    PageDown();
                    ScrollToEnd = false;
                    RenderState = renderState.idle;
                    // _targetAttached = true;
                    _yMaxPosTargeted = YMaxPos;
                }
                else
                {
                    targetY = YMaxPos - WinHeight + 30;
                    ScrollToEnd = false;
                    RenderState = renderState.idle;
                    _targetAttached = true;
                    _yMaxPosTargeted = YMaxPos;
                }

            }
        }

        if (GD.ProvideMoreGrid == null)
            return;
    
        if ((YPos + WinHeight) < (YMaxPos-2) && GD.ProvideMoreGrid(true, 1).IsVisible == false && UIS!.MCMVVisible == false)
        {
            if( GD.SelectOutput != null )
                GD.SelectOutput( ILayoutDescription.selectedOutput.more);
            framesWithoutMovement = 0;
        }
        else if ((YPos + WinHeight) >= (YMaxPos - 2) && GD.ProvideMoreGrid(true, 1).IsVisible == true && UIS!.MCMVVisible == false )
        {
            if (GD.SelectOutput != null)
                GD.SelectOutput(ILayoutDescription.selectedOutput.input);
            ScrollToEnd = false;
            framesWithoutMovement = 0;
            if(GlobalData.CurrentGlobalData!.FocusMethod != null )
                GlobalData.CurrentGlobalData!.FocusMethod();
        }
        else if (YPos + WinHeight >= YMaxPos && framesWithoutMovement > 10)
        {
            ScrollToEnd = false;
            framesWithoutMovement = 0;

        }
 
        if (targetY != -1)
        {
            if (Math.Abs(targetY - YPos) > 1.0d)
                SetToPos((int)(targetY));

       }
        else if (ScrollToEnd == false )
        {
            framesWithoutMovement++;
            if (framesWithoutMovement > 5 && (YPos + WinHeight) < (YMaxPos - 2) && GD.ProvideMoreGrid(true, 1).IsVisible == false && UIS!.MCMVVisible == false ) 
            {
                if (GD.SelectOutput != null)
                    GD.SelectOutput(ILayoutDescription.selectedOutput.more);
            }
        }
    }

    List<string> scrollOrders = new();

    public async void StartScrollOrder(string scrollOrder)
    {
        scrollOrders.Add(scrollOrder);
   
        try
        {
            var response2 = await UIS!.ExternalGameOut!.EvaluateJavaScriptAsync(scrollOrder);

          }
        catch  ( Exception E )
        {
            GlobalData.AddLog("StartScrollOrder: " + E.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
        }

    }


    public void SetScrollerToEnd(double? yPosPre = null )
    {
        ScrollToEnd = true;
        RenderState = renderState.hmtlSet;

    }


    public void JumpToEnd()
    {
        ScrollToEnd = true;

    }


    public void JumpToEndInstantly()
    {
        SetToEnd = true;
        _jumpToEndWait = 3;

    }


    public bool InqScrollingNeeded()
    {
        return false;
    }


    public bool InqScrollingArea()
    {
        MainThread.BeginInvokeOnMainThread(InqScrollingAreaAsyncNoReturn);
        return true;
    }


    public async Task<bool> InqScrollingAreaAsync()
    {
        if (UIS!.ExternalGameOut == null)
            return false;


        try
        {
#if CHROMIUM
            string scr = System.Web.HttpUtility.HtmlEncode("boundAsync.GetHtmlYPos(window.pageYOffset);");
            response2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr);

            scr = System.Web.HttpUtility.HtmlEncode("boundAsync.GetHtmlHeight(window.innerHeight);");
            response2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr);

            scr = System.Web.HttpUtility.HtmlEncode("boundAsync.GetHtmlMaxYPosClient(document.body.clientHeight);");
            response2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr);

            scr = System.Web.HttpUtility.HtmlEncode("boundAsync.GetHtmlMaxYPos(document.body.scrollHeight);");
            response2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr);

            scr = System.Web.HttpUtility.HtmlEncode("boundAsync.GetHtmlMaxYPosOffset(document.body.offsetHeight);");
            response2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr);

            string scr2 = System.Web.HttpUtility.HtmlEncode("boundAsync.Hello(\"Huhu!\");");
            string response3 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr);
#elif MAUI
    
            {

                string scr = "function callGetHtmlYPos() { window.location.href = 'https://runcsharp.GetHTMLYPos?' + window.pageYOffset; } callGetHtmlYPos(); ";
                scr += "function callGetHtmlHeight() { window.location.href = 'https://runcsharp.GetHtmlHeight?' + window.innerHeight; } callGetHtmlHeight(); ";
                scr += "function callGetHtmlMaxYPosClient() { window.location.href = 'https://runcsharp.GetHtmlMaxYPosClient?' + document.body.clientHeight; } callGetHtmlMaxYPosClient(); ";
                scr += "function callGetHtmlMaxYPos() { window.location.href = 'https://runcsharp.GetHtmlMaxYPos?' + document.body.scrollHeight; } callGetHtmlMaxYPos(); ";
                scr += "function callGetHtmlMaxYPosOffset() { window.location.href = 'https://runcsharp.GetHtmlMaxYPosOffset?' + document.body.offsetHeight; } callGetHtmlMaxYPosOffset(); ";
                try
                {
 

                    string? s = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr).ConfigureAwait(false);

                    if (s == null)
                    {

                    }
                }
                catch ( Exception e)
                {
                    GlobalData.AddLog("InqScrollingAreaAsync: " + e.Message, IGlobalData.protMode.crisp);

                    UIS!.JSBoundObject.ctCalls-=5;
                }
                UIS!.JSBoundObject.ctCalls+=5;
            }
#endif
        }
        catch (Exception e)
        {
            GlobalData.AddLog("InqScrollingAreaAsyncNoReturn: " + e.Message, IGlobalData.protMode.crisp);
        }

        return true;
    }

    public async void InqScrollingAreaAsyncNoReturn()
    {
        if (UIS!.ExternalGameOut == null)
            return ;


        try
        {
#if CHROMIUM
            string scr = System.Web.HttpUtility.HtmlEncode("boundAsync.GetHtmlYPos(window.pageYOffset);");
            response2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr);

            scr = System.Web.HttpUtility.HtmlEncode("boundAsync.GetHtmlHeight(window.innerHeight);");
            response2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr);

            scr = System.Web.HttpUtility.HtmlEncode("boundAsync.GetHtmlMaxYPosClient(document.body.clientHeight);");
            response2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr);

            scr = System.Web.HttpUtility.HtmlEncode("boundAsync.GetHtmlMaxYPos(document.body.scrollHeight);");
            response2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr);

            scr = System.Web.HttpUtility.HtmlEncode("boundAsync.GetHtmlMaxYPosOffset(document.body.offsetHeight);");
            response2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr);

            string scr2 = System.Web.HttpUtility.HtmlEncode("boundAsync.Hello(\"Huhu!\");");
            string response3 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr);
#elif MAUI


            string scr = "function callGetHtmlYPos() { window.location.href = 'https://runcsharp.GetHTMLYPos?' + window.pageYOffset; } callGetHtmlYPos(); ";
            scr += "function callGetHtmlHeight() { window.location.href = 'https://runcsharp.GetHtmlHeight?' + window.innerHeight; } callGetHtmlHeight(); ";
            scr += "function callGetHtmlMaxYPosClient() { window.location.href = 'https://runcsharp.GetHtmlMaxYPosClient?' + document.body.clientHeight; } callGetHtmlMaxYPosClient(); ";
            scr += "function callGetHtmlMaxYPos() { window.location.href = 'https://runcsharp.GetHtmlMaxYPos?' + document.body.scrollHeight; } callGetHtmlMaxYPos(); ";
            scr += "function callGetHtmlMaxYPosOffset() { window.location.href = 'https://runcsharp.GetHtmlMaxYPosOffset?' + document.body.offsetHeight; } callGetHtmlMaxYPosOffset(); ";
            try
            {

                string? s = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(scr).ConfigureAwait(false);

            }
            catch ( Exception e)
            {
                GlobalData.AddLog("InqScrollingAreaAsync: " + e.Message, IGlobalData.protMode.crisp);

                // int a = 5;
                UIS!.JSBoundObject.ctCalls -= 5;
            }
            UIS!.JSBoundObject.ctCalls += 5;

#endif
        }
        catch (Exception e)
        {
            GlobalData.AddLog("InqScrollingAreaAsyncNoReturn: " + e.Message, IGlobalData.protMode.crisp);
        }

        return ;
    }


    public void ScrollPage()
    {
        PageDown();

    }



    public void SetToPos(int yPos)
    {
        // yPosse.Add(yPos);
        if (Math.Abs(yPos - YPos) > 30)
        {
            // int a = 5;
        }
        string s1 = "window.scrollTo({ top: " + yPos + " });";
        StartScrollOrder(s1);

    }

    public void ResetYPos()
    {
        string s1 = "window.scrollBy({ top: 1 });";
        StartScrollOrder(s1);

    }

    public void SetToStart()
    {
        string s1 = "window.scrollTo({ top: 0 });";
        StartScrollOrder(s1);

    }

    public void ScrollPageFinal()
    {
 
        ScrollToEnd = true;
        ScrollToEndWait = 5;
        RenderState = renderState.hmtlSet;
    }


    public void CompactToEnd()
    {
         UIS!.StoryTextObj!.RecalcLatest();
        InqScrollingArea();

    }

}
*/
[Serializable]
public class StoryText : IStoryText
{
    public bool FullRefresh { get; set; }

    public bool HTMLLoaded { get; set; }

    public string? BufferedInput { get; set; }

    [JsonIgnore]
    [NonSerialized]
    private UIServices UIS; 
    [JsonIgnore]
    [NonSerialized]
    public IGlobalData GD;
    public StoryText( UIServices uis )
    {
        UIS = uis;
        GD = GlobalData.CurrentGlobalData!;

        Slines = new();
    }
    public string? OldDividingLine { get; set; }
    public string? OldMoreLine { get; set; }
    public List<string?>? Slines { get; set; }
    public List<string?>? SlinesBuffer { get; set; }
    public string? ConvHtmlWithoutTags(string s)
    {
        return null;
    }

    string? latestHtmlOutput = null;

    int lastEndLine = -1;

    public IStoryText? Clone()
    {
        try
        {
            StoryText sto = new(this.UIS);

            int ix = 0;

            for (ix = 0; ix < Slines!.Count; ix++)
            {
                sto.Slines!.Add(Slines![ix]);
            }

            return sto;
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("IStoryText.Clone: " + ex.Message, IGlobalData.protMode.crisp);
            return null;
        }

    }

    public void RecalcLatest( bool doCompact = true )
    {
        try
        {
            int endLine = 0;
            if (Slines!.Count - 100 > 0)
                endLine = Slines!.Count - 100;
            LatestStory = new StringBuilder(); // .Clear();

            // _lfMarker = "</div><div class=\"sansserif\" style=\"color:";

            // doCompact == false: Modus für RecalcPictures. Hier geht es nicht darum, die LatestStory zusammen zu kürzen,
            // sondern darum, die Größenänderungen anzuzeigen
            if (doCompact == false && lastEndLine != -1)
                endLine = lastEndLine;

            for (int Line = Slines!.Count - 1; Line >= endLine; Line--)
            {
                // if (Slines?[Line] == MainWindow.HtmlheadDivide)
                //     LatestStory.Insert(0, Slines?[Line]);

                /*
                if (Slines?[Line].StartsWith(LFMarker) == true)
                    LatestStory.Insert(0, GD.HTMLPageDivide);
                else */
                if (Slines[Line]!.StartsWith('>'))
                    // Noloca: 006
                    // Ignores: 001
                    LatestStory.Insert(0, "<p class=\"para\" style=\"margin-bottom:2px;margin-top:12px;\" >" + Slines[Line] + "</p>");
                else if (Line == Slines.Count - 1)
                    // Ignores: 001
                    LatestStory.Append("<p class=\"para\" style=\"margin-bottom:2px;margin-top:0px;\" >" + Slines[Line] + "</p>");
                else
                    // Ignores: 001
                    LatestStory.Insert(0, "<p class=\"para\" style=\"margin-bottom:2px;margin-top:0px;\" >" + Slines[Line] + "</p>");

            }

            lastEndLine = endLine;
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("RecalcLatest.Clone: " + ex.Message, IGlobalData.protMode.crisp);
        }

    }
    public void ParagraphsToSmall()
    {
        try
        {
            int Line;
            if (Slines == null) return;

            for (Line = Slines!.Count - 1; Line >= 0; Line--)
            {
                if (Slines[Line] == GD.HTMLPageDivide)
                {
                    Slines[Line] = GD.HTMLPageNotDivide;
                    // Slines.RemoveAt(Line);
                    // break;
                }
            }
            RecalcLatest(false);
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("ParagraphsToSmall: " + ex.Message, IGlobalData.protMode.crisp);
        }

    }
    public void ParagraphsToLarge()
    {
        try
        {
            int Line;
            if (Slines == null) return;

            for (Line = Slines!.Count - 1; Line >= 0; Line--)
            {
                if (Slines[Line] == GD.HTMLPageNotDivide)
                {
                    Slines[Line] = GD.HTMLPageDivide;
                    // Slines.RemoveAt(Line);
                    // break;
                }
            }
            RecalcLatest(false);
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("ParagraphsToLarge: " + ex.Message, IGlobalData.protMode.crisp);
        }

    }

    public int CurrentLinesPerTurn { get; set; }

    public StringBuilder? WholeStory { get; set; }

    public StringBuilder? LatestStory { get; set; }

    public StringBuilder? StoryBuffer { get; set; }

    // public IStoryText(advtest.MainWindow MW, UIServices uis);

    public void RemoveEmptyDividingLine()
    {

    }

    public int TextStrip(string strip)
    {
        return 0;
    }


    public void TextReplace(string? stripSource, string? stripDest)
    {

    }

    public void TextStripMore(string s)
    {

    }


    public void DividingLine()
    {
        string? line = GD.HTMLPageDivide;
        UIS!.TextOutput(line, true);

    }
    public void NotDividingLine()
    {
        string? line = GD.HTMLPageNotDivide;
        UIS!.TextOutput(line, true);

    }


    public void ReplaceDividingLine()
    {

    }


    public void RemoveDividingLine()
    {

    }


    public void ShowMore()
    {

    }


    public async Task ExchangeAdvBrowserContent(string s, bool scrollToEnd = false)
    {
        try
        {
            if (UIS!.ExternalGameOut!.IsLoaded == false)
                return;

            string s3 = System.Web.HttpUtility.HtmlEncode("<a style='cursor:pointer' onclick='boundAsync.JSCallback(&quot;ActLoc&quot;);'><b>Eingangshalle</b></a>");
            string script = "val4=document.body.scrollHeight; boundAsync.GetHtmlMaxYPosClientReady2(document.body.clientHeight); val1 = window.pageYOffset; document.getElementById('newbody').innerHTML = `" + GD.HTMLStyle + GD.HTMLPageShort + s + "</div>`; boundAsync.GetHtmlMaxYPosClientReady(document.body.clientHeight);val2 = window.pageYOffset; val3 = window.pageYOffset + val2 - val1; boundAsync.CalcHeight(val1, val2, val3); boundAsync.GetHtmlMaxYPos(document.body.scrollHeight);";
            if (scrollToEnd)
            {
#if !NEWSCROLL
            UIS!.Scr.ResizeRunning = true;
#endif
                script = "boundAsync.GetHtmlMaxYPosClientReady2(document.body.clientHeight); val1 = document.body.scrollHeight; document.getElementById('newbody').innerHTML = `" + GD.HTMLStyle + GD.HTMLPageShort + s + "</div>`; boundAsync.GetHtmlMaxYPosClientReady(document.body.clientHeight);val2 = document.body.scrollHeight; val3 = window.pageYOffset + val2 - val1; boundAsync.CalcHeight(val1, val2, val3); boundAsync.GetHtmlMaxYPos(document.body.scrollHeight);";
                script += "function updateMessage(){ boundAsync.DoResize(window.pageYOffset, window.innerHeight, document.body.scrollHeight); aaa window.scrollTo(0, document.body.scrollHeight);} window.addEventListener(\"load\", updateMessage); window.addEventListener(\"resize\", updateMessage);";
            }
            else
            {
#if !NEWSCROLL
            UIS!.Scr.ResizeRunning = true;
#endif
                script += "function updateMessage2(){ boundAsync.DoResize2(window.pageYOffset, window.innerHeight, document.body.scrollHeight, val4);} document.body.onresize=updateMessage2;";

            }
            latestHtmlOutput = script;
            var response2 = await UIS!.ExternalGameOut.EvaluateJavaScriptAsync(script);


        }
        catch (Exception ex)
        {
            GlobalData.AddLog("ExchangeAdvBrowserContent: " + ex.Message, IGlobalData.protMode.crisp);
            // int a = 5;
        }

    }

    public void ResyncBound()
    {

    }


    public void AdvTextOut(bool scrollToEnd = false)
    {
        if (LatestStory == null) LatestStory = new StringBuilder("");
        // Noloca: 001
        // string s2 = (GlobalData.CurrentGlobalData!.HTMLPage.Replace("[Body]", LatestStory.ToString())).Replace("[YPOS]", UIS!.Scr.YPos.ToString());
        // UIS!.StoryTextObj!.RecalcLatest();
        // Evtl. invoken?
#if !NEWSCROLL
        if (scrollToEnd)
        {
            string s3 = "window.scrollTo(0, document.body.scrollHeight);";
            UIS!.Scr.StartScrollOrder(s3);
    }
#endif
    HTMLLoaded = true;

    }


    public void AdvTextRefresh(bool scrollToEnd = false)
    {
        AdvTextOut(scrollToEnd);
        /*
        if (FullRefresh || !HTMLLoaded)
        {
            AdvTextOut(scrollToEnd);
            FullRefresh = false;
        }
        else
        {
            ExchangeAdvBrowserContent(LatestStory!.ToString(), scrollToEnd);
        }
        */
    }


    public void AddSlineWholeStory(string sline, int line)
    {
        try
        {
            if (sline.Contains("<center><img src="))
                return;

            if (Slines![line]!.StartsWith(LFMarker) == true)
            {
                if (GD.LayoutDescription.ParagraphClusterMode != ILayoutDescription.ParagraphClusters.none)
                    LatestStory!.Insert(0, UIS!.GD!.HTMLPageDivide);
                else
                    LatestStory!.Insert(0, UIS!.GD!.HTMLPageNotDivide);

            }
            else if (Slines![line]!.StartsWith('>'))
                WholeStory!.Append("<p class=\"para\" style=\"margin-bottom:2px;margin-top:12px;\" >" + Slines![line] + "</p>");
            else if (line == Slines!.Count - 1)
                WholeStory!.Append("<p class=\"para\" style=\"margin-bottom:2px;margin-top:0px;\" >" + Slines![line] + "</p>");
            else
                WholeStory!.Append("<p class=\"para\" style=\"margin-bottom:2px;margin-top:0px;\" >" + Slines![line] + "</p>");
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("AddSlineWholeStory: " + ex.Message, IGlobalData.protMode.crisp);
            // int a = 5;
        }

    }

    public void AddSline(string? sline, int line = -1)
    {
        try
        {
            if (line == -1) line = sline!.Length - 1;

            if (sline!.StartsWith('>'))
                LatestStory!.Append("<p class=\"para\" style=\"margin-bottom:2px;margin-top:12px;\" >" + sline + "</p>");
            else if (line == Slines!.Count - 1)
                LatestStory!.Append("<p class=\"para\" style=\"margin-bottom:2px;margin-top:0px;\" >" + sline + "</p>");
            else
                LatestStory!.Append("<p class=\"para\" style=\"margin-bottom:2px;margin-top:0px;\" >" + sline + "</p>");
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("AddSline: " + ex.Message, IGlobalData.protMode.crisp);
            // int a = 5;
        }

    }

    public string HTMLEnd = "</p></body>";

    public void TextReFreshman()
    {
        try
        {
            string s;

            // WholeStory enthält die ganze Geschichte. Diese wird zwar gespeichert, aber nicht im HTMTL-Fenster angezeigt, weil das viel zu lahm geht
            if (WholeStory == null)
            {
                int endLine = 0;
                WholeStory = new StringBuilder(); // .Clear();
                for (int Line = Slines!.Count - 1; Line >= endLine; Line--)
                {
                    // Noloca: 006
                    if (Slines?[Line]?.Contains("<center><img src=") == true)
                    {

                    }
                    else if (Slines?[Line]!.StartsWith(LFMarker) == true)
                        WholeStory.Insert(0, GD.HTMLPageDivide);
                    // else if (Slines?[Line] == MainWindow.HtmlheadDivide)
                    //     WholeStory.Insert(0, Slines?[Line]);
                    else if (Slines![Line]!.StartsWith('>'))
                        // Ignores: 002
                        WholeStory.Insert(0, "<p class=\"para\" style=\"margin-bottom:2px;margin-top:12px;\" >" + Slines![Line] + "</p>");
                    else if (Line == Slines!.Count - 1)
                        // Ignores: 002
                        WholeStory.Append("<p class=\"para\" style=\"margin-bottom:2px;margin-top:0px;\" >" + Slines![Line] + "</p>");
                    else
                        // Ignores: 002
                        WholeStory.Insert(0, "<p class=\"para\" style=\"margin-bottom:2px;margin-top:0px;\" >" + Slines![Line] + "</p>");
                    // WholeStory.Append( "<p class=\"para\" style=\"margin-bottom:2px;margin-top:0px;\" >" + Slines![Line] + "</p>");
                }

            }


            s = "Noch ist nix da";
            if (LatestStory != null)
                s = LatestStory.ToString();

            // s enthält jetzt den Text, der im Browser sichtbar sein soll
            // GD.CurrentContent = GD.HTMLPage.Replace("[Body]", s); // s;

            GD.CurrentContent = s;

            /*
            UIS!.ExternalGameOut.Source = new HtmlWebViewSource
            {
                Html = GlobalData.CurrentGlobalData!.WebViewContent
            };
            */
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("TextReFreshman: " + ex.Message, IGlobalData.protMode.crisp);
            // int a = 5;
        }

    }
    public void SetMainWindow(object MW, IUIServices uis)
    {

    }
    private string _lfMarker = "</div><div class=\"sansserif\" style=\"color:";

    private string LFMarker
    {
        get
        {
            return _lfMarker;
        }
        set
        {
            if (value == null)
            {
                value = "null";
            }
            _lfMarker = value;
        }
    }
    public class FeedbackText
    {
        private FeedbackText? fbObj = null;

        public int FeedbackOffMC { get; set; }
        /*
        {
            get => fbObj.FeedbackOffMC;
            set => fbObj.FeedbackOffMC = value;

        }
        */
        public static int FeedbackSizeMC { get; set; }
        /*
        {
            get => advtest.FeedbackText.FeedbackSizeMC;
            set => advtest.FeedbackText.FeedbackSizeMC = value;

        }
        */
        public int FeedbackCountMC { get; set; }
/*
        {
            get => fbObj.FeedbackCountMC;
            set => fbObj.FeedbackCountMC = value;

        }
*/
        public bool FeedbackModeMC { get; set; }
        /*
        {
            get => fbObj.FeedbackModeMC;
            set => fbObj.FeedbackModeMC = value;

        }
        */
        public List<string>? FeedbackWindowText { get; set; }
        /*
        {
            get => fbObj.FeedbackWindowText;
            set => fbObj.FeedbackWindowText = value;

        }
        */
        public List<string>? FeedbackWindowTextMC { get; set; }
        /*
        {
            get => fbObj.FeedbackWindowTextMC;
            set => fbObj.FeedbackWindowTextMC = value;

        }
        */


        /*
           public int FeedbackOffMC = 0;

           public static int FeedbackSizeMC = 15;         // Maximalanzahl MultipleChoice-Texte

           public int FeedbackCountMC = 15;         // Maximalanzahl MultipleChoice-Texte

           // true: Multiple Choice Modus ist eingeschaltet.

           public bool FeedbackModeMC = false;


           public List<string> FeedbackWindowText;

           public List<string> FeedbackWindowTextMC;

           [JsonIgnore][NonSerialized] private MainWindow MW;
           */

        public FeedbackText(object MW)
        {
            fbObj = new FeedbackText(MW);
        }


        public void FeedbackTextOutput(string s, string? relatedText = null)
        {
            fbObj!.FeedbackTextOutput(s, relatedText);
        }


        public void FeedbackWindowInitText()
        {
            fbObj!.FeedbackWindowInitText();
        }

        public void FeedbackTextReFreshman()
        {
            fbObj!.FeedbackTextReFreshman();
        }

        public void SetMainWindow(object MW)
        {
            // fbObj.SetMainWindow((MainWindow)MW);
        }
    }

}

public class JSBoundObject
{
   public IUIServices? UIS { get; set; }
 
    public void JSCallback(string s)
    {
        /*
        if (_mw != null)
        {
            _mw.JSCallback(s);

        }
        */
    }

    public void SaveLatestHtml(string s)
    {
        /*
        if (_mw != null)
        {
            _mw.SaveLatestHtml(s);

        }
        */
    }

    public int ctCalls = 0;

    private List<double>? yposse = null;

    public void GetHtmlYPos(double ypos)
    {
        try
        {
            if (ypos == -33)
            {

            }
            lock (UIS!.Scr)
            {
                ctCalls--;
#if !NEWSCROLL
            if (UIS!.Scr.ResizeRunning)
            {
                // int a = 5;
            }

            if (UIS!.Scr.SetNext)
            {

                UIS!.Scr.SetNext = false;
            }
            else
            {
                UIS!.Scr.YPos = ypos;

            }
#else
                if (yposse == null)
                {
                    yposse = new();
                    yposse.Add(0);
                }

                if (ypos != yposse[yposse.Count - 1])
                {
                    yposse.Add(ypos);
                }


                if (UIS.Scr.ScrollStep == IScroller.scrollStep.none)
                {
                    UIS!.Scr.HTMLViewYPos = ypos;

                }
                else
                {


                }


#endif
            }
        }
        catch (Exception ex)
        {
            GlobalData.AddLog("GetHtmlYPos: " + ex.Message, IGlobalData.protMode.crisp);
            // int a = 5;
        }
    }
    public void CalcHeight(double val1, double val2, double val3)
    {
        double x = val1;
        double y = val2;
        double z = val3;

        if (val1 != val2)
        {
            // int a = 5;
        }
    }

    public void GetHtmlMaxYPos(double maxYPos)
    {
        lock (UIS!.Scr)
        {
            ctCalls--;
#if !NEWSCROLL
            if (UIS!.Scr.ResizeRunning && UIS!.Scr.YMaxPos > maxYPos)
            {
                UIS!.Scr.YPos += maxYPos - UIS!.Scr.YMaxPos;
                if (UIS!.Scr.YPos < 0)
                {
                    UIS!.Scr.YPos = 0;
                }
                UIS!.Scr.SetToPos((int)(UIS!.Scr.YPos));
                // int a = 5;
            }
#else
            UIS!.Scr.HTMLViewMaxYPos = maxYPos;

#endif

#if !NEWSCROLL

            if (UIS!.Scr.RenderState == IScroller.renderState.hmtlSet)
            {
                UIS!.Scr.RenderState = IScroller.renderState.heightGet;

            }
            UIS!.Scr.YMaxPos = maxYPos;
#endif
        }
    }
    public void GetHtmlHeight(double maxYPos)
    {
        lock (UIS!.Scr)
        {
            ctCalls--;
#if !NEWSCROLL
            UIS!.Scr.YMaxPosClient = maxYPos;
#else
            UIS!.Scr.HTMLViewHeight = maxYPos;

#endif
        }
    }
    public void DoResize(double y1, double y2, double y3)
    {
        lock (UIS!.Scr)
        {
#if !NEWSCROLL
            UIS!.Scr.YPos = y1;
            UIS!.Scr.WinHeight = y2;
            UIS!.Scr.YMaxPos = y3;
            UIS!.Scr.ResizeRunning = false;
#endif
        }
        // double y = x;
    }
    public void DoResize2(double y1, double y2, double y3, double y4)
    {
        lock (UIS!.Scr)
        {
#if !NEWSCROLL
            UIS!.Scr.YPos = y1;
            UIS!.Scr.WinHeight = y2;
            UIS!.Scr.YMaxPos = y3;
            UIS!.Scr.ResizeRunning = false;
#endif
        }
    }
    public void GetHtmlMaxYPosClientReady2(double maxYPos)
    {
        lock (UIS!.Scr)
        {
#if !NEWSCROLL
            UIS!.Scr.YMaxPosClient = maxYPos;
            UIS!.Scr.RenderState = IScroller.renderState.hmtlSet;
#endif
        }
    }
    public void GetHtmlMaxYPosClientReady(double maxYPos)
    {
        lock (UIS!.Scr)
        {
#if !NEWSCROLL
            UIS!.Scr.YMaxPosClient = maxYPos;
            UIS!.Scr.RenderState = IScroller.renderState.hmtlSet;
#endif
        }
    }
    public void GetHtmlMaxYPosOffset(double maxYPos)
    {
        lock (UIS!.Scr)
        {
            ctCalls--;
#if !NEWSCROLL
            UIS!.Scr.YMaxPosOffset = maxYPos;
#endif
        }
    }

    public void StartScrolling(double yPos)
    {
        UIS!.Scr.ScrollMode = IScroller.scrollMode.scrollToEnd;
        UIS!.Scr.ScrollModeCountDown = 1;
    }
    /*
    public void GetHtmlHeight(double height)
    {
        lock (UIS!.Scr)
        {
            ctCalls--;
#if !NEWSCROLL
            UIS!.Scr.WinHeight = height;

            UIS!.Scr.WinHeight = UIS!.ExternalGameOut!.Height;
#endif
        }
    }
    */
    public void HmtlLoaded( int val)
    {
#if !NEWSCROLL
        UIS!.Scr.RenderState = IScroller.renderState.newHeight;
#else
        UIS!.Scr.HTMLViewTotal = val;
        if( val > 0 )
        {
            UIS!.Scr._screenRefreshed = true;
        }
#endif
    }
}
