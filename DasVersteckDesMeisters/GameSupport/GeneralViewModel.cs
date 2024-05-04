
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using Phoney_MAUI;
using Phoney_MAUI.Core;
using Phoney_MAUI.Menu;
using Phoney_MAUI.Game;
using Phoney_MAUI.Model;
using GameCore;
using Newtonsoft.Json;


namespace Phoney_MAUI.Game.General;

public class GeneralViewModel : BaseViewModel, INotifyPropertyChanged
{
    private readonly GlobalSpecs _globalSpecs;
    private readonly UIServices _uiServices;
    private double _width, _height; 

    public ICommand? LoadDataCommand { get; }
    public ICommand? NavigateToGameCommand { get; }

    [JsonIgnore]
    public GlobalData? GD
    {
        get => (GlobalData) GlobalData.CurrentGlobalData!;
    }
    [JsonIgnore]
    public UIServices? UIS
    {
        get => (UIServices) GlobalData.CurrentGlobalData!.UIS!;

    }

    public GeneralViewModel(IGlobalSpecs globalSpecs, IDataService dataService, IDeviceData deviceData, IUIServices uiservices )
    {
        if (GlobalData.CurrentGlobalData!.UIS == null)
        {
            GlobalData.CurrentGlobalData!.UIS = uiservices;
        }
        _globalSpecs = (GlobalSpecs) globalSpecs;
        _uiServices = (UIServices)uiservices;
        LoadDataCommand = new Command(async () => await LoadData());
        Title = "Start";

        GlobalSpecs.CurrentOrderList = new OrderList( );
        GlobalSpecs.CurrentOrderList = dataService.ReadOrderTable();
        TrimOrderLists(10);

    }
    public void SetCallbackResize( IGlobalData._callbackResize callbackResize)
    {
        _globalSpecs.GetGlobalData()!.SetCallbackResize(callbackResize);
        // CallbackResize = callbackResize;
    }
    public void SetCallbackChangeOrientation(IGlobalData._callbackChangeOrientation callbackChangeOrientation)
    {
        _globalSpecs.GetGlobalData()!.SetCallbackChangeOrientation(callbackChangeOrientation);
        // CallbackResize = callbackResize;
    }

    public int TrimOrderLists(int keep)
    {
        int deleted = 0;
        // SetOrderListInfo.jsonIndex
        // Ignores: 001
        string? pathName = GlobalData.CurrentPath();
        string? pathfileName = pathName;

        string[] fileEntries = Directory.GetFiles(pathfileName!);

        foreach (string fName in fileEntries)
        {
            string fName2 = System.IO.Path.GetFileName(fName);
            if (fName2.StartsWith(loca.OrderList_TrimOrderLists_16194))
            {
                int no;

                if (Int32.TryParse(fName2.Substring(10, 4), out no) == true)
                {
                    if (no <= (GD!.OrderList!.SetOrderListInfo!.jsonIndex - keep))
                    {
                        File.Delete(fName);
                        deleted++;
                    }

                }

            }
        }
        return deleted;
    }

    private async Task LoadData()
    {
        try
        {
            IsBusy = true;
        }
        finally
        {
            IsBusy = false;
        }
    }


    public override async Task Initialize()
    {
        await LoadData();
        await base.Initialize();
    }

    public async Task CheckSize(double width, double height)
    {
        GlobalData? gd = (GlobalData) _globalSpecs.GetGlobalData()!;

        if ( width != _width || height != _height )
        {
            if( width > height && gd!.LayoutDescription.ScreenMode != IGlobalData.screenMode.landscape)
            {
                // Event für Umschaltung auf 
                gd.LayoutDescription.ScreenMode = IGlobalData.screenMode.landscape;
            }
            else if ( height > width && gd!.LayoutDescription.ScreenMode != IGlobalData.screenMode.portrait)
            {
                // Event für Umschaltung auf 

                gd.LayoutDescription.ScreenMode = IGlobalData.screenMode.portrait;
            }

            gd!.DoResize(width, height);
        }
        _width = width;
        _height = height;
    }

    public async void InitResize( double width, double height )
    {
        // double width = DeviceDisplay.Current.MainDisplayInfo.Width;
        // double height = DeviceDisplay.Current.MainDisplayInfo.Height;

        _width = 0;
        _height = 0;

        GlobalData? gd = (GlobalData)_globalSpecs.GetGlobalData()!;
        // gd!.LayoutDescription.ScreenMode = IGlobalData.screenMode.unclear;
        if (width > height)
            gd!.LayoutDescription.ScreenMode = IGlobalData.screenMode.landscape;
        else if( width < height)
            gd!.LayoutDescription.ScreenMode = IGlobalData.screenMode.portrait;

        await CheckSize(width, height);
    }

    public void ChangeTheme(ResourceDictionary theme)
    {
        AppShell._mainAppShell!.ChangeTheme(theme);
    }

    public void InitZerogame()
    {
        try
        {
            // bool foundZero = UIS!.ExistFile("zerogame.sav");

            // Prüfen: Kann das Zerogame bleiben und wird es überhaupt noch gebraucht?
            bool foundZero = false;


            if (!foundZero)
            {
                SerialNumberGenerator.Instance.Count = 1000;

                GameCore.Adv? adventure;
                // Nuggu();
                adventure = new Adv(true, false, true); // Adv.CreateAdventure());
                GD!.Adventure!.Orders!.ReadSlotDescription();

                UIS!.StoryTextObj!.Slines = new List<string?>();
                for (int i = 0; i < 20; i++)
                {
                    UIS.StoryTextObj.Slines.Add("<br/>");
                }
                UIS.StoryTextObj.Slines.Add(" ");


                GD!.StartStatus = new();
                GD!.StartStatus.jsonOrderListTable = adventure!.GD!.OrderList!.OTL![adventure!.GD!.OrderList!.CurrentOrderListIx];
                GD!.StartStatus.jsonVersion = adventure!.GD!.Version;
                GD!.StartStatus.jsonItems = adventure!.Items;
                GD!.StartStatus.jsonPersons = adventure!.Persons;
                GD!.StartStatus.jsonlocations = adventure!.locations;
                GD!.StartStatus.jsonStats = adventure!.Stats;
                GD!.StartStatus.jsonScores = adventure!.Scores;
                GD!.StartStatus.jsonLanguage = adventure!.GD!.Language;
                GD!.StartStatus.jsonLI = adventure!.LI;
                GD!.StartStatus.jsonTopics = adventure!.Topics;
                GD!.StartStatus.jsonItemQueue = adventure!.ItemQueue;
                GD!.StartStatus.jsonStoryText = adventure!.STE;
                GD!.StartStatus.jsonFeedbackText = adventure!.FBE;
                GD!.StartStatus.jsonA = adventure!.A;
                GD!.StartStatus.jsonPV = adventure!.PV;

                // Nicht betroffen von Savegames
                GD!.StartStatus.jsonAdjs = adventure!.Adjs;
                GD!.StartStatus.jsonNouns = adventure!.Nouns;
                GD!.StartStatus.jsonPreps = adventure!.Preps;
                GD!.StartStatus.jsonPronouns = adventure!.Pronouns;
                GD!.StartStatus.jsonFills = adventure!.Fills;
                GD!.StartStatus.jsonVerbTenses = adventure!.VerbTenses;
                GD!.StartStatus.jsonCA = adventure!.CA;
                GD!.StartStatus.jsonCB = adventure!.CB;
                // GD.StartStatus.jsonParser = Adventure!.Parser;
                GD!.StartStatus.jsonVerbs = adventure!.Verbs;
                GD!.StartStatus.JsonGameDefinitions = adventure!.Orders!.GenerateGameDefinitions(false);

                GD!.Adventure = adventure;

                // Helper.ConfigInsert(adventure.Persons, adventure.Items, adventure.locations, adventure.Topics, adventure.CB, adventure.A, adventure );

                GD!.Language = IGlobalData.language.english;
                GD!.Language = IGlobalData.language.german;

                // adventure!.UIS!.CoreSaveToFile(GD!.StartStatus, "zerogame.sav");
                /*
                MemoryStream stream = new MemoryStream();
                var writer = new BinaryWriter(stream, Encoding.UTF8, false);

                byte[] buf = UIServices.ObjectToByteArray(GD.StartStatus);
                writer.Write(buf);
                writer.Close();
                GD.StartStatusSerialized = stream.GetBuffer();
                */
                /*
                using (var stream = File.Open(fileName, FileMode.Create))
                {
                    using (var writer = new BinaryWriter(stream, Encoding.UTF8, false))
                    {
                        writer.Write(1.250F);
                        writer.Write(@"c:\Temp");
                        writer.Write(10);
                        writer.Write(true);
                    }
                }
                */

                /* TEST: Wird ersetzt durch neuen Lademechanismus
                MemoryStream stream = new MemoryStream();
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, GD.StartStatus);
                GD.StartStatusSerialized = stream.GetBuffer();
                SerialNumberGenerator.Instance.Count = 1000;
                */

                // GD.Adventure.GenerateInitData();
            }
            else
            {


                GD!.StartStatus = UIS!.CoreLoadFromFile("zerogame.sav");
                /*
                MemoryStream stream = new MemoryStream();
                var writer = new BinaryWriter(stream, Encoding.UTF8, false);
                byte[] buf = UIServices.ObjectToByteArray(GD.StartStatus);
                writer.Write(buf);
                writer.Close();
                GD.StartStatusSerialized = stream.GetBuffer();
                */
                /* TEST: Wird ersetzt durch neuen Lademechanismus
                IFormatter formatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();
                try
                { 
                    formatter.Serialize(stream, GD.StartStatus);
                }
                catch( Exception e)
                {
                    int a;
                }
                GD.StartStatusSerialized = stream.GetBuffer();
                */
            }

        }
        catch (Exception e)
        {
            // int a;
        }
    }
}
