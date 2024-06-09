using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;
// using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

using Phoney_MAUI.Model;

namespace GameCore
{
    [Serializable]

    public enum EPV { pv0, pv1, pv2 }
    [Serializable]

    public class PVLoc
    {

        public int locationID;

        public int PVSubLevel;

        public bool replacement;
    }
    [Serializable]

    public class PVList
    {

        public List<PVLoc> PVLoc { get; set; } = new();
    }

    [Serializable]

    public class PhoneyVision
    {

        public List<PVList>? PVList;


        public PVLoc? Find(int locationID)
        {
            PVLoc? pv = null;
            if (PVList == null) return pv;

            foreach (PVList? pvli in PVList!)
            {
                foreach (PVLoc p in pvli.PVLoc!)
                {
                    if (p.locationID == locationID)
                    {
                        pv = p;
                        break;
                    }
                }
                if (pv != null) break;
            }
            return (pv);
        }

        public PVLoc? FindUpper(int locationID)
        {
            PVLoc? pv = null;

            int pvliix = 0;
            foreach (PVList? pvli in this!.PVList!)
            {
                int pix = 0;
                foreach (PVLoc p in pvli!.PVLoc)
                {
                    if (p.locationID == locationID)
                    {
                        if (pvliix < 2)
                            pv = this!.PVList[pvliix + 1].PVLoc[pix];

                        break;
                    }
                    pix++;
                }
                if (pv != null) break;
                pvliix++;
            }
            return (pv);
        }

        public PVLoc? FindLower(int locationID)
        {
            PVLoc? pv = null;

            int pvliix = 0;
            foreach (PVList pvli in this!.PVList!)
            {
                int pix = 0;
                foreach (PVLoc p in pvli.PVLoc)
                {
                    if (p.locationID == locationID)
                    {
                        if (pvliix >= 1)
                            pv = this.PVList[pvliix - 1].PVLoc[pix];

                        break;
                    }
                    pix++;
                }
                if (pv != null) break;
                pvliix++;
            }
            return (pv);
        }

        public bool SetReplaced(int locationID)
        {
            bool didReplacement = false;
            foreach (PVLoc p in this!.PVList![1].PVLoc! )
            {
                if (p.locationID == locationID)
                {
                    p.replacement = true;
                    didReplacement = true;
                    break;
                }
            }
            return didReplacement;
        }
        // gibt die aktuell gültige location zurück, die dieser location zugeordnet ist
        // wurde die location noch nicht umgewandelt, wird die PV1-location zurückgegeben
        // wurde die location umgewandelt, wird die PV2-location zurückgegeben

        public int GetCurrentLoc( int locationID)
        {
            return locationID;
            /*
            int loc = -1;

            int pvliix = 0;
            foreach (PVList pvli in this.PVList! )
            {
                int pix = 0;
                foreach (PVLoc p in pvli.PVLoc)
                {
                    if (p.locationID == locationID)
                    {
                        if (pvliix >= 1)
                        { 
                            if(this.PVList[1].PVLoc[pix].replacement)
                                loc = this.PVList[2].PVLoc[pix].locationID;
                            else
                                loc = this.PVList[1].PVLoc[pix].locationID;
                        }
                        break;
                    }
                    pix++;
                }
                if ( loc != -1 ) break;
                pvliix++;
            }
            return (loc );
            */

        }
    }

    [Serializable]

    public partial class Adv: AdvBase
    {
        // int a = 5;
        // [JsonIgnore] [NonSerialized]  public MainWindow MWx;

        public CoAdv? CA { get; set; }


        // public List<PVLoc> PVLoc { get; set; }

        public PhoneyVision PV { get; set; } = new();


        public Person? LastSpeaker { get; set; } = null;


        public List<GenericTipp>? GenericTipps {get;set; } = null;


        public Phoney_MAUI.Core.StoryText STE
        {
            get { return UIS!.StoryTextObj!; }
            set { UIS!.StoryTextObj = value; }
        }

        public Phoney_MAUI.Core.FeedbackText FBE
        {
            get { return UIS!.FeedbackTextObj; }
            set { UIS!.FeedbackTextObj = value; }
        }


        public bool RestoreLocationName()
        {
            this.UIS!.HeadlineOutput(locations!.Find(A!.ActLoc!)!.LocName!);
            return true;
        }

        new public void SetScoreToken(Score? score) 
        {
            if (score!.Active == false)
            {
                if (score.LocaEventName != null)
                    CurrentEventName = score.LocaEventName;
            }
            base.SetScoreToken(score);
        }


        public void LinkInitData()
        {
            List<CAAdjs>? lcaa = LoadAdjLinks();
            List<CANouns>? lcan = LoadNounLinks();
            List<CAVerbs>? lcav = LoadVerbLinks();
            List<CAVerbs>? lcavcb = LoadVerbLinksCB();
            List<CAItems>? lcai = LoadItemLinks();
            List<CAPersons>? lcap = LoadPersonLinks();
            List<CAInts>? lcaint = LoadCAInts();
            List<CAInts>? lcaintp = LoadCAIntProps();
            List<CAPreps>? lcbpr = LoadCBPreps();

            foreach (CAAdjs caa in lcaa!)
            {
                // bool found = false;
                FieldInfo[] fis = CA!.GetType().GetFields();

                foreach (FieldInfo fi in fis)
                {
                    if (fi.Name == caa.Name)
                    {
                        // Adj a = (Adj) fi.GetValue(CA)!;

                        fi.SetValue(CA, Adjs!.Find(caa.AdjID));
                        // found = true;
                        break;
                    }
                }
            }

            foreach (CANouns can in lcan!)
            {
                // bool found = false;
                FieldInfo[] fis = CA!.GetType().GetFields();

                foreach (FieldInfo fi in fis)
                {
                    if (fi.Name == can.Name)
                    {
                        // Noun n = (Noun)fi.GetValue(CA)!;

                        fi.SetValue(CA, Nouns!.Find(can.NounID));
                        // found = true;
                        break;
                    }
                }
            }
            foreach (CAVerbs cav in lcav!)
            {
                // bool found = false;
                FieldInfo[]? fis = CA!.GetType().GetFields();

                foreach (FieldInfo fi in fis)
                {
                    if (fi.Name == cav.Name)
                    {
                        // Verb?  v = (Verb)fi.GetValue(CA);

                        fi.SetValue(CA, Verbs!.Find(cav.VerbID));
                        // found = true;
                        break;
                    }
                }
            }
            foreach (CAVerbs cav in lcavcb!)
            {
                // bool found = false;
                FieldInfo[]? fis = CB!.GetType().GetFields();

                foreach (FieldInfo fi in fis)
                {
                    if (fi.Name == cav.Name)
                    {
                        // Verb? v= (Verb)fi.GetValue(CB);

                        fi.SetValue(CB, Verbs!.Find(cav.VerbID));
                        // found = true;
                        break;
                    }
                }
            }
            foreach (CAItems cai in lcai!)
            {
                // bool found = false;
                PropertyInfo[]? pis = CA!.GetType().GetProperties();

                foreach (PropertyInfo pi in pis!)
                {
                    if (pi.Name == cai.Name)
                    {
                        // Item? i = (Item)pi.GetValue(CA);

                        pi.SetValue(CA, Items!.Find(cai.ItemID));
                        // found = true;
                        break;
                    }
                }
            }
            foreach (CAPersons cap in lcap!)
            {
                // bool found = false;
                FieldInfo[]? fis = CA!.GetType().GetFields();

                foreach (FieldInfo fi in fis)
                {
                    if (fi.Name == cap.Name)
                    {
                        // Person? p  = (Person)fi.GetValue(CA);

                        fi.SetValue(CA, Persons!.Find(cap.PersonID));
                        // found = true;
                        break;
                    }
                }
            }
            foreach (CAInts caint in lcaint!)
            {
                // bool found = false;
                FieldInfo[]? fis = CA!.GetType().GetFields();

                foreach (FieldInfo fi in fis)
                {
                    if (fi.Name == caint.Name)
                    {
                        // int i = (int)fi.GetValue(CA);

                        fi.SetValue(CA, caint.Val);
                        // found = true;
                        break;
                    }
                }
            }
            foreach (CAInts caintp in lcaintp!)
            {
                // bool found = false;
                PropertyInfo[]? pis = CA!.GetType().GetProperties();

                foreach (PropertyInfo pi in pis)
                {
                    if (pi.Name == caintp.Name)
                    {
                        // int i = (int)pi.GetValue(CA);

                        pi.SetValue(CA, caintp.Val);
                        // found = true;
                        break;
                    }
                }
            }
            foreach (CAPreps cbpr in lcbpr! )
            {
                // bool found = false;
                FieldInfo[] fis = CB!.GetType().GetFields();

                foreach (FieldInfo fi in fis)
                {
                    if (fi.Name == cbpr.Name)
                    {
                        // int i = (int)pi.GetValue(CA);
                        // Prep pr = (Prep)fi.GetValue(CB);
                        fi.SetValue(CB, Preps!.Find( cbpr.PrepID));
                        // found = true;
                        break;
                    }
                }
            }
            AdvGame!.A.ActPerson = CA!.Person_I!.ID;

        }
        public void GenerateInitData()
        {
            List<IUIServices.ZipObject> zio = new();

            IUIServices.ZipObject zoN = new();
            zoN.Data = SaveNouns();
            zoN.Name = "nouns";
            zio.Add(zoN);

            IUIServices.ZipObject zoA = new();
            zoA.Data = SaveAdjs();
            zoA.Name = "adjs";
            zio.Add(zoA);

            IUIServices.ZipObject zoV = new();
            zoV.Data = SaveVerbs();
            zoV.Name = "verbs";
            zio.Add(zoV);

            IUIServices.ZipObject zoPLL = new();
            zoPLL.Data = SavePLL();
            zoPLL.Name = "pll";
            zio.Add(zoPLL);

            IUIServices.ZipObject zoPLLEng = new();
            zoPLLEng.Data = SavePLLEng();
            zoPLLEng.Name = "plleng";
            zio.Add(zoPLLEng);

            IUIServices.ZipObject zoI = new();
            zoI.Data = SaveItems();
            zoI.Name = "items";
            zio.Add(zoI);

            IUIServices.ZipObject zoP = new();
            zoP.Data = SavePersons();
            zoP.Name = "persons";
            zio.Add(zoP);
 
            IUIServices.ZipObject zoL = new();
            zoL.Data = SaveLocations();
            zoL.Name = "locations";
            zio.Add(zoL);

            IUIServices.ZipObject zoPr = new();
            zoPr.Data = SavePreps();
            zoPr.Name = "preps";
            zio.Add(zoPr);

            SaveCACB( zio );

            UIS!.SaveToZip("initdata", zio);
        }

        public void SaveCACB(List<IUIServices.ZipObject> zio)
        {
            List<CAVerbs> caVerbs = new();
            List<CANouns> caNouns = new();
            List<CAAdjs> caAdjs = new();
            List<CAItems> caItems= new();
            List<CAPersons> caPersons = new();
            List<CAVerbs> cbVerbs = new();
            List<CAInts> caInts = new();
            List<CAInts> caIntProps = new();
            List<CAPreps> cbPreps = new();



            FieldInfo[]? fis = CA!.GetType().GetFields();
            PropertyInfo[]? pis = CA.GetType().GetProperties();

            foreach (FieldInfo fi in fis)
            {
                object? o = fi.GetValue(CA);

                if (o == null)
                {

                }
                else if (o.GetType() == typeof( Verb)) 
                {
                    CAVerbs cav = new();
                    cav.VerbID = (o as Verb)!.ID;
                    cav.Name = fi.Name;
                    caVerbs.Add(cav);
                }
                else if (o.GetType() == typeof( Noun)) 
                {
                    CANouns can = new();
                    can.NounID = (o as Noun)!.ID;
                    can.Name = fi.Name;
                    caNouns.Add(can);
                }
                else if (o.GetType() == typeof( Adj))
                {
                    CAAdjs caa = new();
                    caa.AdjID = (o as Adj)!.ID;
                    caa.Name = fi.Name;
                    caAdjs.Add(caa);

                }
                else if (o.GetType() == typeof( Person)) 
                {
                    CAPersons cap = new();
                    cap.PersonID = (o as Person)!.ID;
                    cap.Name = fi.Name;
                    caPersons.Add(cap);

                }
                else if (o.GetType() == typeof(int))
                {
                    CAInts cai = new();
                    cai.Val = (int)(o);
                    cai.Name = fi.Name;
                    caInts.Add(cai);

                }
                else
                {

                }
            }

            foreach (PropertyInfo pi in pis)
            {
                object? o = pi.GetValue(CA);

                if (o == null)
                {

                }
                else if (o.GetType() == typeof( Item))
                {
                    CAItems cai = new();
                    cai.ItemID = (o as Item)!.ID;
                    cai.Name = pi.Name;
                    caItems.Add(cai);

                }
                else if (o.GetType() == typeof(int))
                {
                    CAInts caint = new();
                    caint.Val = (int)(o);
                    caint.Name = pi.Name;
                    caIntProps.Add(caint);

                }
            }

            fis = CB!.GetType().GetFields();

            foreach (FieldInfo fi in fis)
            {
                object? o = fi.GetValue(CB);

                if (o == null)
                {

                }
                else if (o.GetType() == typeof( Verb))
                {
                    CAVerbs cav = new();
                    cav.VerbID = (o as Verb)!.ID;
                    cav.Name = fi.Name;
                    cbVerbs.Add(cav);

                }
                else if (o.GetType() == typeof(Prep))
                {
                    CAPreps capr = new();
                    capr.PrepID = (o as Prep)!.ID;
                    capr.Name = fi.Name;
                    cbPreps.Add(capr);

                }
            }

            IUIServices.ZipObject zoN = new();
            zoN.Data = SaveObj(caNouns);
            zoN.Name = "nounlinks";
            zio.Add(zoN);

            IUIServices.ZipObject zoV = new();
            zoV.Data = SaveObj(caVerbs);
            zoV.Name = "verblinks";
            zio.Add(zoV);

            IUIServices.ZipObject zoA = new();
            zoA.Data = SaveObj(caAdjs);
            zoA.Name = "adjlinks";
            zio.Add(zoA);

            IUIServices.ZipObject zoI = new();
            zoI.Data = SaveObj(caItems);
            zoI.Name = "itemlinks";
            zio.Add(zoI);

            IUIServices.ZipObject zoP = new();
            zoP.Data = SaveObj(caPersons);
            zoP.Name = "personlinks";
            zio.Add(zoP);

            IUIServices.ZipObject zoVCB = new();
            zoVCB.Data = SaveObj(cbVerbs);
            zoVCB.Name = "verblinkscb";
            zio.Add(zoVCB);

            IUIServices.ZipObject zoInt = new();
            zoInt.Data = SaveObj(caInts);
            zoInt.Name = "caints";
            zio.Add(zoInt);

            IUIServices.ZipObject zoIntP = new();
            zoIntP.Data = SaveObj(caIntProps);
            zoIntP.Name = "caintprops";
            zio.Add(zoIntP);

            IUIServices.ZipObject zoPreps = new();
            zoPreps.Data = SaveObj(cbPreps);
            zoPreps.Name = "prepscb";
            zio.Add(zoPreps);

        }

        public ItemList? LoadItems()
        {
            string? istring = SearchInitData("items");

            List<Item>? li = JsonConvert.DeserializeObject<List<Item>>(istring!);
            ItemList? il = new ItemList();
            il.List = li!.ToDictionary(e => e.ID);

            // ItemList? il = JsonConvert.DeserializeObject<ItemList>(istring);
            GD!.AddLanguageCallback(il.RestoreItems);


            // JObject ob = JO

            // il.A = A;
            // il.Persons = Persons;
            // il.SetAdvGame( this );
            return il;
        }

        public PersonList? LoadPersons()
        {
            string? pstring = SearchInitData("persons");
            PersonList? pl = JsonConvert.DeserializeObject<PersonList>(pstring!);
            pl!.SetAdv( this );
            // pl.A = A;
            // Items.Persons = pl;
            return pl;
        }
        public locationList? LoadLocations()
        {
            string? istring = SearchInitData("locations");
            locationList? ll = JsonConvert.DeserializeObject<locationList>(istring!);
            return ll;
        }

        public void SetAdv( Adv adv )
        {
            base.AdvGame = adv;
        }

        public long refTimer;
        public long timeFinishedGeneral;
        public long timeFinished;
        public long timeFinishedPost;
        public long timeFiGedoens;
        public long timeFiCategories;
        public long timeFiVerbs;
        public long timeFiAdjectives;
        public long timeFiNouns;
        public long timeFiPLL;
        public long timeFiPersons;
        public long timeFiItems;
        public long timeFiLocations;
        public long timeFiStatus;
        public long timeFiScores;
        public long timeFiParserReset;
        public long timeFiPreLink;
        public Stopwatch? stopwatch;

        public static Adv? DoSomething()
        {
            return null;
        }

        public static void CleanupAdv( Adv adv)
        {
            if( adv.locations != null )
            {
                foreach( location loc in adv.locations.List.Values)
                {
                    loc.SetController(null!);
                }
            }
            if (adv.PLL != null)
            {
                foreach (ParseLine pl in adv.PLL.List!)
                {
                    foreach( ParseToken pt in pl.PTL!.PList! )
                    {
                        pt.O = null;
                    }
                    pl.PTL.PList.Clear();
                }
                adv.PLL.List.Clear();
                adv.PLL = null;

            }
            if (adv.PLLEng != null)
            {
                foreach (ParseLine pl in adv.PLLEng.List!)
                {
                    pl.PTL!.PList!.Clear();
                    foreach (ParseToken pt in pl.PTL.PList)
                    {
                        pt.O = null;
                    }

                }
                adv.PLLEng.List.Clear();

                adv.PLLEng = null;
            }
            /*
            if( adv.Items != null )
            {
                if (adv.Items.ListD != null)
                {
                    foreach (Item i in adv.Items.ListD.Values)
                    {
                        i!.SetController(null);
                        i!.Names.Clear();
                        i!.SynNames.Clear();
                        if (i.NamesEng != null)
                            i.NamesEng.Clear();
                        if (i.SynNamesEng != null)
                            i.SynNamesEng.Clear();
                    }
                    adv.Items.ListD.Clear();
                }
                if (adv.Items.ListE != null)
                {
                    foreach (Item i in adv.Items.ListE.Values)
                    {
                        i!.SetController(null);
                        i!.Names.Clear();
                        i!.SynNames.Clear();
                        if (i!.NamesEng != null)
                            i!.NamesEng.Clear();
                        if (i!.SynNamesEng != null)
                            i!.SynNamesEng.Clear();
                    }
                    adv.Items.ListE.Clear();
                }
                adv.Items.List.Clear();
                adv.Items = null;
            }
            if (adv.Persons != null)
            {
                if( adv.Persons.ListD != null )
                {
                    foreach (Person p in adv.Persons.ListD.Values)
                    {
                        p!.SetController(null);
                        p.Names!.Clear();
                        p.SynNames.Clear();
                        if (p.NamesEng != null)
                            p.NamesEng.Clear();
                        if (p.SynNamesEng != null)
                            p.SynNamesEng.Clear();
                    }
                    adv.Persons.ListD.Clear();

                }
                if (adv.Persons.ListE != null)
                {
                    foreach (Person p in adv.Persons.ListE.Values)
                    {
                        p!.SetController(null);
                        p!.Names.Clear();
                        p!.SynNames.Clear();
                        if (p!.NamesEng != null)
                            p!.NamesEng.Clear();
                        if (p!.SynNamesEng != null)
                            p!.SynNamesEng.Clear();
                    }

                    adv.Persons.ListE.Clear();
                }
                adv.Persons.List.Clear();
                adv.Persons = null;
            }
            */

            adv.CA = null;
            adv.GD!.OrderList!.CBCreateOrderPath = null;
            adv.GD!.ResetLanguageCallbacks();
            adv.GD!.AddLanguageCallback(adv.UIS!.SetFullUIText!);
        }

        public void InitAdvWithoutAutosave( bool LoadAutoSave, bool ZeroLoad )
        {
            SerialNumberGenerator.Instance.Count = 1000;
            LoadedInitData = null;
#if WINDOWS
                // LoadInitData();
#endif
            stopwatch = new Stopwatch();
            stopwatch.Start();

            InitializeGeneralGameData(this);
            timeFinishedGeneral = stopwatch.ElapsedMilliseconds;
            InitializeGame();

            // Abschließende Verlinkung aller Teile
            timeFiPreLink = stopwatch.ElapsedMilliseconds;
            if (LoadedInitData != null)
                LinkInitData();
            timeFinished = stopwatch.ElapsedMilliseconds;

            Grammar.Init(A, VerbTenses, Items, Persons);

            A.StartLoc = A.ActLoc = CA!.L01_Dark_Forest; // CA!.LX_01_Hausflur;
                                                        // Persons.Items = Items;

            foreach (var ele in locations!.List.Values)
            {
                location l = (location)ele;
                /*
                if (l.LocDescRaw != null)
                {
                    string s = loca.GetLoca(l.LocDescRaw);
                }
                */
                if (l._locDescRawHandle != null)
                    l.LocDescription = Helper.Insert(l._locDescRawHandle);
            }

            ResetParser();

            foreach (ParseLine pl in PLL!.List!)
            {
                pl.PTL!.SetParseTokenList(Verbs, Preps, Pronouns, Nouns, Adjs, Fills, ItemQueue);
            }

            if (LoadedInitData != null)
            {
            }

            timeFinishedPost = stopwatch.ElapsedMilliseconds;

            UIS!.SetDelTextSelect(LinkCallback);
            UIS!.HeadlineOutput(locations!.Find(A!.ActLoc)!.LocName!);

            UIS!.DoUIUpdate();


            if (LoadAutoSave == true)
                GD!.OrderList!.AddOrderList(loca.Adv_Adv_2231);

            GD!.AskForPlayLevel = true;

            if (UIS!.RestartSlot == 0)
            {
                SetStoryLine = true;

                UIS!.StoryTextObj!.Slines!.Clear();
                UIS!.StoryTextObj.RecalcLatest();
                UIS!.StoryTextObj!.RemoveEmptyDividingLine();

                if (ZeroLoad == false)
                {
                    StoryOutput(loca.Adv_Intro0);
                    UIS.LoadPicToHtml("ver_title.jpg");
                    StoryOutput(String.Format(loca.Adv_Intro1, GD!.Version.GetVersion(), GD!.Version.GetVersionDate()));
                }

                SetScoreOutput();
            }

        }
        public Adv( bool SetAsActiveGame, bool LoadAutoSave, bool ZeroLoad = false ) 
        {
            GC.Collect();


            Adv? advStore1;
#if MAUI
            Phoney_MAUI.App.ThisApplication!.SetDestroyCallback( UIS!.QuitApplication );
            Phoney_MAUI.App.ThisApplication!.SetStoppedCallback(UIS!.DoStatusSave);
#endif
            // CA = new();
            // MWx = Ausgabeklasse;
            // this.GD = gd;
            // this.UIS = uis;

            CB = new();
            LI = new();
            A = new();

            SerialNumberGenerator.Instance.Count = 1000;

            if (SetAsActiveGame == true)
            {
                advStore1 = GD!.Adventure!;
                GD!.Adventure = this;
            }
            else
            {
                advStore1 = GD!.Adventure!;
                GD!.Adventure = this;
            }
            GD!.InitRandom(43);
            GD!.OrderList!.CBCreateOrderPath = CreateOrderPath;
#if ANDROID
            {
                List<string> s = new();
                s.Add("ver_title.jpg");
                s.Add("ver_l01.jpg");
                s.Add("ver_l02.jpg");
                s.Add("ver_l03.jpg");

                s.Add("ver_l04.jpg");
                s.Add("ver_l05.jpg");
                s.Add("ver_l06.jpg");
                s.Add("ver_l07.jpg");
                s.Add("ver_l08.jpg");

                s.Add("ver_l09.jpg");
                s.Add("ver_l10.jpg");
                s.Add("ver_l11.jpg");
                s.Add("ver_l12.jpg");
                s.Add("ver_l13.jpg");
                s.Add("ver_l14.jpg");
                s.Add("ver_l15.jpg");

                GD!.UIS!.CacheResources(s);
            }
#endif


            loca.GD?.AddLanguageCallback(RestoreLocationName);
            /*
            MW.Version.Version1 = 0;
            MW.Version.Version2 = 10;
            MW.Version.Version3 = 4;
            MW.Version.VersionDate = new DateTime(2022, 04, 03);
            */

#if (DEBUG)
            GameTestMode = true;       
#endif

            if ((!UIS!.ExistFile("autosave.sav") ) || (LoadAutoSave == false))
            {
                InitAdvWithoutAutosave(LoadAutoSave, ZeroLoad);

            }
            else
            {
                GD!.AskForPlayLevel = false;

                ResetParser();
                Categories = new CategoryRelList(true);
                InitCategories();

                this.Orders = new Order();
                // this.Orders = new Order(AdvGame, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null );
                // InitializeGeneralGameData();
                // InitializeGame();
                Orders!.CoreLoad( loca.Adv_Adv_Person_I_2240, this );

                if (GD.AutoloadFailed == true || GD.SavegameFailed == true || GD.Adventure.Items == null )
                {
                    GD.GreetingText = loca.Autosave_Outdated;
                    InitAdvWithoutAutosave(LoadAutoSave, ZeroLoad);

                }
                else
                {
                    if (UIS.FeedbackTextObj != null)
                        UIS.FeedbackTextObj.FeedbackModeMC = false;
                    // Persons!.TransferPerson(Persons!.Find(CA!.Person_I), CB!.LocType_Loc, A!.ActLoc);
                    UIS!.SetDelTextSelect(LinkCallback);

                    if (locations != null)
                    {
                        UIS!.HeadlineOutput(locations!.Find(AdvGame!.A!.ActLoc)!.LocName!);

                        AdvGame!.SetScoreOutput();
                    }
                    UIS!.DoUIUpdate();
#if !NEWSCROLL
                UIS.Scr.CompactToEnd();
                UIS.Scr.JumpToEndInstantly();
#endif
                    UIS.RefreshShowOrderList();
                    // MW.UpdateOrderList(GD!.OrderList);
                }
            }
            if (SetAsActiveGame == false)
            {
                GD!.Adventure = advStore1;
            }

            GD!.AddLanguageCallback(ResetParser);

            // locations.ShowlocationFull(A!.ActLoc);

        }

        void InitCategories()
        {
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Eatable, -1, "Adv_InitializeGame_Person_I_2241", null, "Adv_InitializeGame_Person_I_2242", "Adv_InitializeGame_Person_I_2243"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Tasteable, -1, "Adv_InitializeGame_Person_I_2244", null, "Adv_InitializeGame_Person_I_2245", "Adv_InitializeGame_Person_I_2246"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Smellable, -1, "Adv_InitializeGame_Person_I_2247", null, "Adv_InitializeGame_Person_I_2248", "Adv_InitializeGame_Person_I_2249"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Readable, -1, "Adv_InitializeGame_Person_I_2250", null, "Adv_InitializeGame_Person_I_2251", "Adv_InitializeGame_Person_I_2252"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Fillable, A.CounterCat_Fill, "Adv_InitializeGame_Person_I_2253", "Adv_InitializeGame_Person_I_2254", "Adv_InitializeGame_Person_I_2255", "Adv_InitializeGame_Person_I_2256"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_GoThroughable, -1, "Adv_InitializeGame_Person_I_2257", null, "Adv_InitializeGame_Person_I_2258", "Adv_InitializeGame_Person_I_2259"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_GoToable, -1, "Adv_InitializeGame_Person_I_2260", null, "Adv_InitializeGame_Person_I_2261", "Adv_InitializeGame_Person_I_2262"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Climbable, -1, "Adv_InitializeGame_Person_I_2263", null, "Adv_InitializeGame_Person_I_2264", "Adv_InitializeGame_Person_I_2265"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Climbupable, -1, "Adv_InitializeGame_Person_I_2266", null, "Adv_InitializeGame_Person_I_2267", "Adv_InitializeGame_Person_I_2268"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Climbdownable, -1, "Adv_InitializeGame_Person_I_2269", null, "Adv_InitializeGame_Person_I_2270", "Adv_InitializeGame_Person_I_2271"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Usable, -1, "Adv_InitializeGame_Person_I_2272", null, "Adv_InitializeGame_Person_I_2273", "Adv_InitializeGame_Person_I_2274"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Takeable, -1, "Adv_InitializeGame_Person_I_2275", null, "Adv_InitializeGame_Person_I_2276", "Adv_InitializeGame_Person_I_2277"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_UsableWith, A.CounterCat_UsableWith, "Adv_InitializeGame_Person_I_2278", "Adv_InitializeGame_Person_I_2279", "Adv_InitializeGame_Person_I_2280", "Adv_InitializeGame_Person_I_2281"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Throwable, A.CounterCat_ThrowTarget, "Adv_InitializeGame_Person_I_2282", "Adv_InitializeGame_Person_I_2283", "Adv_InitializeGame_Person_I_2284", "Adv_InitializeGame_Person_I_2285"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Pullable, -1, "Adv_InitializeGame_Person_I_2286", null, "Adv_InitializeGame_Person_I_2287", "Adv_InitializeGame_Person_I_2288"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Pushable, -1, "Adv_InitializeGame_Person_I_2289", null, "Adv_InitializeGame_Person_I_2290", "Adv_InitializeGame_Person_I_2291"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_PushableTo, A.CounterCat_PushTarget, "Adv_InitializeGame_Person_I_2292", "Adv_InitializeGame_Person_I_2293", "Adv_InitializeGame_Person_I_2294", "Adv_InitializeGame_Person_I_2295"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Waste, -1, "Adv_InitializeGame_Person_I_2296", null, "Adv_InitializeGame_Person_I_2297", "Adv_InitializeGame_Person_I_2298"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Giveable, A.CounterCat_GiveTarget, "Adv_InitializeGame_Person_I_2299", "Adv_InitializeGame_Person_I_2300", "Adv_InitializeGame_Person_I_2301", "Adv_InitializeGame_Person_I_2302"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Showable, A.CounterCat_ShowTarget, "Adv_InitializeGame_Person_I_2303", "Adv_InitializeGame_Person_I_2304", "Adv_InitializeGame_Person_I_2305", "Adv_InitializeGame_Person_I_2306"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Questionable, A.CounterCat_QuestionTarget, "Adv_InitializeGame_Person_I_2307", "Adv_InitializeGame_Person_I_2308", "Adv_InitializeGame_Person_I_2309", "Adv_InitializeGame_Person_I_2310"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Untightenable, -1, "Adv_InitializeGame_Person_I_2311", null, "Adv_InitializeGame_Person_I_2312", "Adv_InitializeGame_Person_I_2313"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Breakable, -1, "Adv_InitializeGame_Person_I_2314", null, "Adv_InitializeGame_Person_I_2315", "Adv_InitializeGame_Person_I_2316"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Cutable, A.CounterCat_Knife, "Adv_InitializeGame_Person_I_2317", "Adv_InitializeGame_Person_I_2318", "Adv_InitializeGame_Person_I_2319", "Adv_InitializeGame_Person_I_2320"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Tieable, A.CounterCat_TieTarget, "Adv_InitializeGame_Person_I_2321", "Adv_InitializeGame_Person_I_2322", "Adv_InitializeGame_Person_I_2323", "Adv_InitializeGame_Person_I_2324"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Fishable, A.CounterCat_FishingRod, "Adv_InitializeGame_Person_I_2325", "Adv_InitializeGame_Person_I_2326", "Adv_InitializeGame_Person_I_2327", "Adv_InitializeGame_Person_I_2328"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Enlightable, A.CounterCat_Lighter, "Adv_InitializeGame_Person_I_2329", "Adv_InitializeGame_Person_I_2330", "Adv_InitializeGame_Person_I_2331", "Adv_InitializeGame_Person_I_2332"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Illuminated, A.CounterCat_Lighter, "Illuminate1", "Illuminate2", "Illuminate3", "Illuminate4"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Extinguishable, -1, "Adv_InitializeGame_Person_I_2333", null, "Adv_InitializeGame_Person_I_2334", "Adv_InitializeGame_Person_I_2335"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Grabable, A.CounterCat_Grabber, "Adv_InitializeGame_Person_I_2336", "Adv_InitializeGame_Person_I_2337", "Adv_InitializeGame_Person_I_2338", "Adv_InitializeGame_Person_I_2339"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Grabintoable, -1, "Grabinto1", "Grabinto2", "Grabinto3", "Grabinto4"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Sellable, A.CounterCat_SellTarget, "Adv_InitializeGame_Person_I_2340", "Adv_InitializeGame_Person_I_2341", "Adv_InitializeGame_Person_I_2342", "Adv_InitializeGame_Person_I_2343"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Pickable, A.CounterCat_PickTarget, "Adv_InitializeGame_Person_I_2344", "Adv_InitializeGame_Person_I_2345", "Adv_InitializeGame_Person_I_2346", "Adv_InitializeGame_Person_I_2347"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Catcheable, -1, "Adv_InitializeGame_Person_I_2348", null, "Adv_InitializeGame_Person_I_2349", "Adv_InitializeGame_Person_I_2350"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Unlockable, A.CounterCat_Key, "Adv_InitializeGame_Person_I_2351", "Adv_InitializeGame_Person_I_2352", "Adv_InitializeGame_Person_I_2353", "Adv_InitializeGame_Person_I_2354"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Lockable, A.CounterCat_Key, "Adv_InitializeGame_Person_I_2355", "Adv_InitializeGame_Person_I_2356", "Adv_InitializeGame_Person_I_2357", "Adv_InitializeGame_Person_I_2358"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Knockable, -1, "Adv_InitializeGame_Person_I_2359", "Adv_InitializeGame_Person_I_2360", "Adv_InitializeGame_Person_I_2361", "Adv_InitializeGame_Person_I_2362"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Enterable, -1, "Adv_InitializeGame_Person_I_2363", null, "Adv_InitializeGame_Person_I_2364", "Adv_InitializeGame_Person_I_2365"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Turnable, -1, "Adv_InitializeGame_Person_I_2366", null, "Adv_InitializeGame_Person_I_2367", "Adv_InitializeGame_Person_I_2368"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_TakeFromable, A.CounterCat_TakeFromable, "Adv_InitializeGame_Person_I_2369", "Adv_InitializeGame_Person_I_2370", "Adv_InitializeGame_Person_I_2371", "Adv_InitializeGame_Person_I_2372"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_TakeOutable, A.CounterCat_TakeOutable, "Adv_InitializeGame_Person_I_2373", "Adv_InitializeGame_Person_I_2374", "Adv_InitializeGame_Person_I_2375", "Adv_InitializeGame_Person_I_2376"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_TakeFromBehindable, A.CounterCat_TakeFromBehindable, "Adv_InitializeGame_Person_I_2377", "Adv_InitializeGame_Person_I_2378", "Adv_InitializeGame_Person_I_2379", "Adv_InitializeGame_Person_I_2380"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_TakeFromBesideable, A.CounterCat_TakeFromBesideable, "Adv_InitializeGame_Person_I_2381", "Adv_InitializeGame_Person_I_2382", "Adv_InitializeGame_Person_I_2383", "Adv_InitializeGame_Person_I_2384"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_TakeFromBelowable, A.CounterCat_TakeFromBelowable, "Adv_InitializeGame_Person_I_2385", "Adv_InitializeGame_Person_I_2386", "Adv_InitializeGame_Person_I_2387", "Adv_InitializeGame_Person_I_2388"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_PutOnable, A.CounterCat_PutOnable, "Adv_InitializeGame_Person_I_2389", "Adv_InitializeGame_Person_I_2390", "Adv_InitializeGame_Person_I_2391", "Adv_InitializeGame_Person_I_2392"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_PutInable, A.CounterCat_PutInable, "Adv_InitializeGame_Person_I_2393", "Adv_InitializeGame_Person_I_2394", "Adv_InitializeGame_Person_I_2395", "Adv_InitializeGame_Person_I_2396"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_PutBehindable, A.CounterCat_PutBehindable, "Adv_InitializeGame_Person_I_2397", "Adv_InitializeGame_Person_I_2398", "Adv_InitializeGame_Person_I_2399", "Adv_InitializeGame_Person_I_2400"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_PutBesideable, A.CounterCat_PutBesideable, "Adv_InitializeGame_Person_I_2401", "Adv_InitializeGame_Person_I_2402", "Adv_InitializeGame_Person_I_2403", "Adv_InitializeGame_Person_I_2404"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_PutBelowable, A.CounterCat_PutBelowable, "Adv_InitializeGame_Person_I_2405", "Adv_InitializeGame_Person_I_2406", "Adv_InitializeGame_Person_I_2407", "Adv_InitializeGame_Person_I_2408"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Talkable, -1, "Adv_InitializeGame_Person_I_2409", "Adv_InitializeGame_Person_I_2410", "Adv_InitializeGame_Person_I_2411", "Adv_InitializeGame_Person_I_2412"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Pleaable, A.CounterCat_GiveTarget, "Adv_InitializeGame_Person_I_2413", "Adv_InitializeGame_Person_I_2414", "Adv_InitializeGame_Person_I_2415", "Adv_InitializeGame_Person_I_2416"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Demandable, A.CounterCat_GiveTarget, "Adv_InitializeGame_Person_I_2417", "Adv_InitializeGame_Person_I_2418", "Adv_InitializeGame_Person_I_2419", "Adv_InitializeGame_Person_I_2420"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Drinkable, -1, "Adv_InitializeGame_Person_I_2421", "Adv_InitializeGame_Person_I_2422", "Adv_InitializeGame_Person_I_2423", "Adv_InitializeGame_Person_I_2424"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Touchable, -1, "Adv_InitializeGame_Person_I_2425", "Adv_InitializeGame_Person_I_2426", "Adv_InitializeGame_Person_I_2427", "Adv_InitializeGame_Person_I_2428"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Listenable, -1, "Adv_InitializeGame_Person_I_2429", "Adv_InitializeGame_Person_I_2430", "Adv_InitializeGame_Person_I_2431", "Adv_InitializeGame_Person_I_2432"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Arrestable, -1, "Adv_InitializeGame_Person_I_2433", null, "Adv_InitializeGame_Person_I_2434", "Adv_InitializeGame_Person_I_2435"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Pressable, -1, "Adv_InitializeGame_Person_I_2436", null, "Adv_InitializeGame_Person_I_2437", "Adv_InitializeGame_Person_I_2438"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_ArrestableWith, A.CounterCat_ArrestTarget, "Adv_InitializeGame_Person_I_2439", "Adv_InitializeGame_Person_I_2440", "Adv_InitializeGame_Person_I_2441", "Adv_InitializeGame_Person_I_2442"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Followable, -1, "Adv_InitializeGame_Person_I_2443", null, "Adv_InitializeGame_Person_I_2444", "Adv_InitializeGame_Person_I_2445"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Fotographable, A.CounterCat_FotoTool, "Adv_InitializeGame_Person_I_2446", "Adv_InitializeGame_Person_I_2447", "Adv_InitializeGame_Person_I_2448", "Adv_InitializeGame_Person_I_2449"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Wrapable, A.CounterCat_WrapTarget, "Adv_InitializeGame_Person_I_2450", "Adv_InitializeGame_Person_I_2451", "Adv_InitializeGame_Person_I_2452", "Adv_InitializeGame_Person_I_2453"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Paintable, A.CounterCat_PaintTool, "Adv_InitializeGame_Person_I_2454", "Adv_InitializeGame_Person_I_2455", "Adv_InitializeGame_Person_I_2456", "Adv_InitializeGame_Person_I_2457"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Smearable, A.CounterCat_SmearTarget, "Adv_InitializeGame_Person_I_2458", "Adv_InitializeGame_Person_I_2459", "Adv_InitializeGame_Person_I_2460", "Adv_InitializeGame_Person_I_2461"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Cleanable, -1, "Adv_InitializeGame_Person_I_2462", null, "Adv_InitializeGame_Person_I_2463", "Adv_InitializeGame_Person_I_2464"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Polishable, -1, "Adv_InitializeGame_Person_I_2465", null, "Adv_InitializeGame_Person_I_2466", "Adv_InitializeGame_Person_I_2467"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Repairable, -1, "Adv_InitializeGame_Person_I_2468", null, "Adv_InitializeGame_Person_I_2469", "Adv_InitializeGame_Person_I_2470"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Feedable, A.CounterCat_FeedTarget, "Adv_InitializeGame_Person_I_2471", "Adv_InitializeGame_Person_I_2472", "Adv_InitializeGame_Person_I_2473", "Adv_InitializeGame_Person_I_2474"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Sitable, -1, "Adv_InitializeGame_Person_I_2475", null, "Adv_InitializeGame_Person_I_2476", "Adv_InitializeGame_Person_I_2477"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Sleepable, -1, "Adv_InitializeGame_Person_I_2478", null, "Adv_InitializeGame_Person_I_2479", "Adv_InitializeGame_Person_I_2480"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Sortable, -1, "Adv_InitializeGame_Person_I_2481", null, "Adv_InitializeGame_Person_I_2482", "Adv_InitializeGame_Person_I_2483"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Spittable, -1, "Adv_InitializeGame_Person_I_2484", null, "Adv_InitializeGame_Person_I_2485", "Adv_InitializeGame_Person_I_2486"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Swimable, -1, "Adv_InitializeGame_Person_I_2487", null, "Adv_InitializeGame_Person_I_2488", "Adv_InitializeGame_Person_I_2489"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Tipable, A.CounterCat_TipTarget, "Adv_InitializeGame_Person_I_2490", "Adv_InitializeGame_Person_I_2491", "Adv_InitializeGame_Person_I_2492", "Adv_InitializeGame_Person_I_2493"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_TipInable, A.CounterCat_TipTarget, "Adv_InitializeGame_Person_I_2494", "Adv_InitializeGame_Person_I_2495", "Adv_InitializeGame_Person_I_2496", "Adv_InitializeGame_Person_I_2497"), relTypes.r_low));
            // Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_TipInable, A.CounterCat_TipTarget, "Adv_InitializeGame_Person_I_2498", "Adv_InitializeGame_Person_I_2499", "Adv_InitializeGame_Person_I_2500", "Adv_InitializeGame_Person_I_2501"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Mountable, A.CounterCat_MountTool, "Adv_InitializeGame_Person_I_2502", "Adv_InitializeGame_Person_I_2503", "Adv_InitializeGame_Person_I_2504", "Adv_InitializeGame_Person_I_2505"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_CleanableWith, A.CounterCat_CleanTool, "Adv_InitializeGame_Person_I_2506", "Adv_InitializeGame_Person_I_2507", "Adv_InitializeGame_Person_I_2508", "Adv_InitializeGame_Person_I_2509"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Digable, -1, "Adv_InitializeGame_Person_I_2510", null, "Adv_InitializeGame_Person_I_2511", "Adv_InitializeGame_Person_I_2512"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Searchable, -1, "Adv_InitializeGame_Person_I_2513", null, "Adv_InitializeGame_Person_I_2514", "Adv_InitializeGame_Person_I_2515"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Buyable, -1, "Adv_InitializeGame_Person_I_2516", null, "Adv_InitializeGame_Person_I_2517", "Adv_InitializeGame_Person_I_2518"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Dressable, -1, "Adv_InitializeGame_Person_I_2519", null, "Adv_InitializeGame_Person_I_2520", "Adv_InitializeGame_Person_I_2521"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Undressable, -1, "Adv_InitializeGame_Person_I_2522", null, "Adv_InitializeGame_Person_I_2523", "Adv_InitializeGame_Person_I_2524"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_ExamineBehindable, -1, "Adv_InitializeGame_Person_I_2525", null, "Adv_InitializeGame_Person_I_2526", "Adv_InitializeGame_Person_I_2527"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_ExamineInable, -1, "Adv_InitializeGame_Person_I_2528", null, "Adv_InitializeGame_Person_I_2529", "Adv_InitializeGame_Person_I_2530"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_ExamineBelowable, -1, "Adv_InitializeGame_Person_I_2531", null, "Adv_InitializeGame_Person_I_2532", "Adv_InitializeGame_Person_I_2533"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_ExamineOnable, -1, "Adv_InitializeGame_Person_I_2534", null, "Adv_InitializeGame_Person_I_2535", "Adv_InitializeGame_Person_I_2536"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_ExamineBesideable, -1, "Adv_InitializeGame_Person_I_2537", null, "Adv_InitializeGame_Person_I_2538", "Adv_InitializeGame_Person_I_2539"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Pokeable, A.CounterCat_PokeTarget, "Adv_InitializeGame_Person_I_2540", "Adv_InitializeGame_Person_I_2541", "Adv_InitializeGame_Person_I_2542", "Adv_InitializeGame_Person_I_2543"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Attachable, A.CounterCat_AttachTarget, "Adv_InitializeGame_Person_I_2544", "Adv_InitializeGame_Person_I_2545", "Adv_InitializeGame_Person_I_2546", "Adv_InitializeGame_Person_I_2547"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Punctureable, A.CounterCat_PunctureTool, "Adv_InitializeGame_Person_I_2548", "Adv_InitializeGame_Person_I_2549", "Adv_InitializeGame_Person_I_2550", "Adv_InitializeGame_Person_I_2551"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Dipable, A.CounterCat_DipTool, "Adv_InitializeGame_Person_I_2552", "Adv_InitializeGame_Person_I_2553", "Adv_InitializeGame_Person_I_2554", "Adv_InitializeGame_Person_I_2555"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Meditateable, -1, "Adv_InitializeGame_Person_I_2556", null, "Adv_InitializeGame_Person_I_2557", "Adv_InitializeGame_Person_I_2558"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Wearable, -1, "Adv_InitializeGame_Person_I_2559", null, "Adv_InitializeGame_Person_I_2560", "Adv_InitializeGame_Person_I_2561"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Unwearable, -1, "Adv_InitializeGame_Person_I_2562", null, "Adv_InitializeGame_Person_I_2563", "Adv_InitializeGame_Person_I_2564"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Waterable, A.CounterCat_WaterTool, "Adv_InitializeGame_Person_I_2565", "Adv_InitializeGame_Person_I_2566", "Adv_InitializeGame_Person_I_2567", "Adv_InitializeGame_Person_I_2568"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Mixable, A.CounterCat_MixTarget, "Adv_InitializeGame_Person_I_2569", "Adv_InitializeGame_Person_I_2570", "Adv_InitializeGame_Person_I_2571", "Adv_InitializeGame_Person_I_2572"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Sawable, A.CounterCat_SawTool, "Adv_InitializeGame_Person_I_2573", "Adv_InitializeGame_Person_I_2574", "Adv_InitializeGame_Person_I_2575", "Adv_InitializeGame_Person_I_2576"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Suckable, -1, "Adv_InitializeGame_Person_I_2577", "Adv_InitializeGame_Person_I_2578", "Adv_InitializeGame_Person_I_2579", "Adv_InitializeGame_Person_I_2580"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_FillableWith, A.CounterCat_FillTool, "Adv_InitializeGame_Person_I_2581", "Adv_InitializeGame_Person_I_2582", "Adv_InitializeGame_Person_I_2583", "Adv_InitializeGame_Person_I_2584"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_CuttableWith, A.CounterCat_CutTool, "Adv_InitializeGame_Person_I_2585", "Adv_InitializeGame_Person_I_2586", "Adv_InitializeGame_Person_I_2587", "Adv_InitializeGame_Person_I_2588"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_TakeWith, A.CounterCat_TakeWith_Tool, "Takewith1", "Takewith2", "Takewith3", "Takewith4"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Wraparoundable, A.CounterCat_Wraparound_Tool, "WrapAround1", "WrapAround2", "WrapAround3", "WrapAround4"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Touchwithable, A.CounterCat_TouchWith_Tool, "TouchWith1", "TouchWith2", "TouchWith3", "TouchWith4"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Readwithable, A.CounterCat_Read_Tool, "ReadWith1", "ReadWith2", "ReadWith3", "ReadWith4"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Heatable, A.CounterCat_Heater, "Heatable1", "Heatable2", "Heatable3", "Heatable4"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Pulverizable, A.CounterCat_Pulverizer, "Pulverize1", "Pulverize2", "Pulverize3", "Pulverize4"), relTypes.r_essential));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Crackable, -1, "Adv_InitializeGame_Person_I_2589", "Adv_InitializeGame_Person_I_2590", "Adv_InitializeGame_Person_I_2591", "Adv_InitializeGame_Person_I_2592"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Breathable, -1, "Adv_InitializeGame_Person_I_2593", "Adv_InitializeGame_Person_I_2594", "Adv_InitializeGame_Person_I_2595", "Adv_InitializeGame_Person_I_2596"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Smokeable, -1, "Adv_InitializeGame_Person_I_2597", "Adv_InitializeGame_Person_I_2598", "Adv_InitializeGame_Person_I_2599", "Adv_InitializeGame_Person_I_2600"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Leaveable, -1, "Adv_InitializeGame_Person_I_2601", "Adv_InitializeGame_Person_I_2602", "Adv_InitializeGame_Person_I_2603", "Adv_InitializeGame_Person_I_2604"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Stealable, -1, "Adv_InitializeGame_Person_I_2605", "Adv_InitializeGame_Person_I_2606", "Adv_InitializeGame_Person_I_2607", "Adv_InitializeGame_Person_I_2608"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Countable, -1, "Adv_InitializeGame_Person_I_2609", "Adv_InitializeGame_Person_I_2610", "Adv_InitializeGame_Person_I_2611", "Adv_InitializeGame_Person_I_2612"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Playable, -1, "Adv_InitializeGame_Person_I_2613", "Adv_InitializeGame_Person_I_2614", "Adv_InitializeGame_Person_I_2615", "Adv_InitializeGame_Person_I_2616"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Typeable, -1, "Adv_InitializeGame_Person_I_2617", "Adv_InitializeGame_Person_I_2618", "Adv_InitializeGame_Person_I_2619", "Adv_InitializeGame_Person_I_2620"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Tearable, -1, "Adv_InitializeGame_Person_I_2621", "Adv_InitializeGame_Person_I_2622", "Adv_InitializeGame_Person_I_2623", "Adv_InitializeGame_Person_I_2624"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Parkable, -1, "Adv_InitializeGame_Person_I_2625", "Adv_InitializeGame_Person_I_2626", "Adv_InitializeGame_Person_I_2627", "Adv_InitializeGame_Person_I_2628"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_DrawOffable, -1, "Adv_InitializeGame_Person_I_2629", "Adv_InitializeGame_Person_I_2630", "Adv_InitializeGame_Person_I_2631", "Adv_InitializeGame_Person_I_2632"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_ClimbInable, -1, "Adv_InitializeGame_Person_I_2633", "Adv_InitializeGame_Person_I_2634", "Adv_InitializeGame_Person_I_2635", "Adv_InitializeGame_Person_I_2636"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Freeable, -1, "Adv_InitializeGame_Person_I_2637", "Adv_InitializeGame_Person_I_2638", "Adv_InitializeGame_Person_I_2639", "Adv_InitializeGame_Person_I_2640"), relTypes.r_low));
            Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_Lightable, -1, "Light1", "Light2", "Light3", "Light4"), relTypes.r_essential));
            // Categories!.Add(new CategoryRel(Category.CategoryLoca(A.Cat_UseKamerable, -1, $"<nameNom>", $"<nameNom>", $"<nameNom> mit der Kamera fotografieren", $"fotografiere <nameNom> mit der Kamera"), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_UsableWith), relTypes.r_essential));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_Fill), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_ThrowTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_PushTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_GiveTarget), relTypes.r_essential));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_ShowTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_QuestionTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_Knife), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_TieTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_FishingRod), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_Lighter), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_Grabber), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_SellTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_PickTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_ArrestTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_Key), relTypes.r_essential));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_FotoTool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_WrapTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_PaintTool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_SmearTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_FeedTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_TipTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_CleanTool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_PokeTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_AttachTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_PunctureTool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_DipTool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_WaterTool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_FillTool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_CutTool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_SawTool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_MixTarget), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_MountTool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_PutInable), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_PutOnable), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_PutBehindable), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_PutBesideable), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_PutBelowable), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_TakeWith_Tool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_Wraparound_Tool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_TouchWith_Tool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_Read_Tool), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_Heater), relTypes.r_low));
            Categories!.Add(new CategoryRel(new Category(A.CounterCat_Pulverizer), relTypes.r_low));

        }


        void InitAdjectives( int size = -1)
        {
            if (size != -1)
            {
                Adjs!.TList = new Dictionary<string, Adj>(size, StringComparer.CurrentCultureIgnoreCase);

            }

            // Neue Adj
            CA!.Adj_ausgestopft = Adjs!.Add(Adj.AdjLoca("Adj_ausgestopft"));
            CA!.Adj_beschrieben = Adjs!.Add(Adj.AdjLoca("Adj_beschrieben"));
            CA!.Adj_besonders = Adjs!.Add(Adj.AdjLoca("Adj_besonders"));
            CA!.Adj_gekuehlt = Adjs!.Add(Adj.AdjLoca("Adj_gekuehlt"));
            CA!.Adj_hasserfuellt = Adjs!.Add(Adj.AdjLoca("Adj_hasserfuellt"));
            CA!.Adj_instabil = Adjs!.Add(Adj.AdjLoca("Adj_instabil"));
            CA!.Adj_lichtlos = Adjs!.Add(Adj.AdjLoca("Adj_lichtlos"));
            CA!.Adj_magisch = Adjs!.Add(Adj.AdjLoca("Adj_magisch"));
            CA!.Adj_mueffelnd = Adjs!.Add(Adj.AdjLoca("Adj_mueffelnd"));
            CA!.Adj_neblig = Adjs!.Add(Adj.AdjLoca("Adj_neblig"));
            CA!.Adj_peinlich = Adjs!.Add(Adj.AdjLoca("Adj_peinlich"));
            CA!.Adj_schimmernd = Adjs!.Add(Adj.AdjLoca("Adj_schimmernd"));
            CA!.Adj_sinister = Adjs!.Add(Adj.AdjLoca("Adj_sinister"));
            CA!.Adj_stattlich = Adjs!.Add(Adj.AdjLoca("Adj_stattlich"));
            CA!.Adj_verrueckt = Adjs!.Add(Adj.AdjLoca("Adj_verrueckt"));
            CA!.Adj_vertrocknet = Adjs!.Add(Adj.AdjLoca("Adj_vertrocknet"));

            CA!.Adj_stark = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2641"));
            CA!.Adj_reissfest = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2642"));
            CA!.Adj_gruen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2643"));
            CA!.Adj_gross = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2644"));
            CA!.Adj_rot = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2645"));
            CA!.Adj_klein = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2646"));
            CA!.Adj_mittel = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2647"));
            CA!.Adj_allwissend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2648"));
            CA!.Adj_rostig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2649"));
            CA!.Adj_gigantisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2650"));
            CA!.Adj_heftig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2651"));
            CA!.Adj_atemberaubend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2652"));
            CA!.Adj_veraltet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2653"));

            CA!.Adj_vergammelt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2654"));
            CA!.Adj_gewoehnlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2655"));
            CA!.Adj_vergilbt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2656"));
            CA!.Adj_zerrissen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2657"));
            CA!.Adj_kaputt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2658"));
            CA!.Adj_dreckig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2659"));
            CA!.Adj_verschlossen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2660"));
            CA!.Adj_breit = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2661"));
            CA!.Adj_marode = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2662"));
            CA!.Adj_klapprig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2663"));
            CA!.Adj_fein = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2664"));
            CA!.Adj_ausgeblichen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2665"));
            CA!.Adj_wahnsinnig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2666"));
            CA!.Adj_bekloppt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2667"));
            CA!.Adj_irre = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2668"));
            CA!.Adj_dicht = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2669"));
            CA!.Adj_graviert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2670"));
            CA!.Adj_hoch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2671"));
            CA!.Adj_kurz = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2672"));
            CA!.Adj_weit = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2673"));
            CA!.Adj_formschoen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2674"));
            CA!.Adj_biegsam = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2675"));
            CA!.Adj_einfach = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2676"));
            CA!.Adj_prachtvoll = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2677"));
            CA!.Adj_tief = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2678"));
            CA!.Adj_stumpf = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2679"));
            CA!.Adj_bunt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2680"));
            CA!.Adj_lang = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2681"));
            CA!.Adj_stabil = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2682"));
            CA!.Adj_schaebig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2683"));
            CA!.Adj_schuechtern = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2684"));
            CA!.Adj_knurrig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2685"));
            CA!.Adj_heruntergekommen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2686"));
            CA!.Adj_grimmig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2687"));
            CA!.Adj_braun = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2688"));
            CA!.Adj_alt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2689"));
            CA!.Adj_offen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2690"));
            CA!.Adj_gefaehrlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2691"));
            CA!.Adj_primitiv = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2692"));
            CA!.Adj_schmuddelig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2693"));
            CA!.Adj_wackelig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2694"));
            CA!.Adj_modrig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2695"));
            CA!.Adj_niedrig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2696"));
            CA!.Adj_schmal = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2697"));
            CA!.Adj_herumliegend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2698"));
            CA!.Adj_lecker = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2699"));
            CA!.Adj_zerbrochen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2700"));
            CA!.Adj_robust = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2701"));
            CA!.Adj_wabernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2702"));
            CA!.Adj_herumstehend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2703"));
            CA!.Adj_schwach = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2704"));
            CA!.Adj_gepflueckt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2705"));
            CA!.Adj_betrunken = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2706"));
            CA!.Adj_fesch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2707"));
            CA!.Adj_unfesch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2708"));
            CA!.Adj_steif = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2709"));
            CA!.Adj_verwittert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2710"));
            CA!.Adj_eifrig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2711"));
            CA!.Adj_druckfrisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2712"));
            CA!.Adj_schwer = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2713"));
            CA!.Adj_uneben = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2714"));
            // CA!.Adj_finster = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2715"));
            CA!.Adj_stolz = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2716"));
            CA!.Adj_spitz = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2717"));
            CA!.Adj_gescheckt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2718"));
            CA!.Adj_unscheinbar = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2719"));
            CA!.Adj_windig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2720"));
            CA!.Adj_oelverschmiert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2721"));
            CA!.Adj_glaenzend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2722"));
            CA!.Adj_rustikal = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2723"));
            CA!.Adj_solide = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2724"));
            CA!.Adj_schlaefrig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2725"));
            CA!.Adj_feurig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2726"));
            CA!.Adj_albern = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2727"));
            CA!.Adj_ausgebleicht = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2728"));
            CA!.Adj_blutig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2729"));
            CA!.Adj_dunkel = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2730"));
            CA!.Adj_farbig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2731"));
            CA!.Adj_frisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2732"));
            CA!.Adj_gebacken = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2733"));
            CA!.Adj_getunkt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2734"));
            CA!.Adj_gezinkt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2735"));
            CA!.Adj_glaslos = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2736"));
            CA!.Adj_haesslich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2737"));
            CA!.Adj_leer = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2738"));
            CA!.Adj_plump = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2739"));
            CA!.Adj_reisserisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2740"));
            CA!.Adj_schief = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2741"));
            CA!.Adj_schmutzig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2742"));
            CA!.Adj_unterbelichtet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2743"));
            CA!.Adj_ueberbelichtet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2744"));
            CA!.Adj_ueppig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2745"));
            CA!.Adj_unscharf = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2746"));
            CA!.Adj_vergiftet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2747"));
            CA!.Adj_verschmiert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2748"));
            CA!.Adj_verwackelt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2749"));
            CA!.Adj_verziert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2750"));
            CA!.Adj_zerknittert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2751"));
            CA!.Adj_zierlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2752"));
            CA!.Adj_blau = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2753"));
            CA!.Adj_episch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2754"));
            CA!.Adj_erlogen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2755"));
            CA!.Adj_heimtueckisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2756"));
            CA!.Adj_herrenlos = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2757"));
            CA!.Adj_lachhaft = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2758"));
            CA!.Adj_loechrig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2759"));
            CA!.Adj_niedertraechtig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2760"));
            CA!.Adj_zerfleddert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2761"));
            CA!.Adj_oval = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2762"));
            CA!.Adj_schaendlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2763"));
            CA!.Adj_scharfkantig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2764"));
            CA!.Adj_subversiv = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2765"));
            CA!.Adj_suspekt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2766"));
            CA!.Adj_verbloedet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2767"));
            CA!.Adj_verbogen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2768"));
            CA!.Adj_zerkratzt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2769"));
            CA!.Adj_verraeterisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2770"));
            CA!.Adj_wuselnd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2771"));
            CA!.Adj_zerknickt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2772"));
            CA!.Adj_durchsichtig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2773"));
            CA!.Adj_edel = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2774"));
            CA!.Adj_fettig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2775"));
            CA!.Adj_gebraten = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2776"));
            CA!.Adj_gefuellt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2777"));
            CA!.Adj_geifernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2778"));
            CA!.Adj_handlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2779"));
            CA!.Adj_hoffnungsfroh = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2780"));
            CA!.Adj_klebrig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2781"));
            CA!.Adj_lebhaft = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2782"));
            CA!.Adj_lesbar = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2783"));
            CA!.Adj_maechtig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2784"));
            CA!.Adj_modisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2785"));
            CA!.Adj_roh = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2786"));
            CA!.Adj_tot = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2787"));
            CA!.Adj_unbedruckt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2788"));
            CA!.Adj_verdammungswuerdig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2789"));
            CA!.Adj_verlogen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2790"));
            CA!.Adj_verschlammt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2791"));
            CA!.Adj_versifft = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2792"));

            CA!.Adj_aufgeblasen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2793"));
            CA!.Adj_bewusstlos = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2794"));
            CA!.Adj_esoterisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2795"));
            CA!.Adj_extragross = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2796"));
            CA!.Adj_falsch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2797"));
            CA!.Adj_gekritzelt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2798"));
            CA!.Adj_gerieben = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2799"));
            CA!.Adj_gluehend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2800"));
            CA!.Adj_offiziell = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2801"));
            CA!.Adj_schmierig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2802"));
            CA!.Adj_stachlig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2803"));
            Adj.AdjLoca(CA!.Adj_stachlig!.ID, "Adv_InitializeGame_Person_I_2804");
            CA!.Adj_verwesend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2805"));
            CA!.Adj_wuchtig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2806"));
            CA!.Adj_fragwuerdig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2807"));
            CA!.Adj_leichenblass = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2808"));
            CA!.Adj_schimmlig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2809"));
            CA!.Adj_abgeranzt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2810"));
            CA!.Adj_baufaellig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2811"));
            CA!.Adj_steinern = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2812"));
            CA!.Adj_verrusst = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2813"));
            CA!.Adj_grob = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2814"));
            CA!.Adj_dick = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2815"));
            CA!.Adj_stinkend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2816"));
            CA!.Adj_hoelzern = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2817"));
            CA!.Adj_weitlaeufig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2818"));
            CA!.Adj_trueb = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2819"));
            CA!.Adj_abgewetzt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2820"));
            CA!.Adj_antiquiert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2821"));
            CA!.Adj_eklig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2822"));
            CA!.Adj_feucht = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2823"));
            CA!.Adj_getrocknet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2824"));
            CA!.Adj_nutzlos = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2825"));
            CA!.Adj_ausgedehnt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2826"));
            CA!.Adj_wundervoll = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2827"));
            CA!.Adj_paradiesisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2828"));
            CA!.Adj_ausladend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2829"));
            CA!.Adj_kitschig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2830"));
            CA!.Adj_klobig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2831"));
            CA!.Adj_opulent = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2832"));
            CA!.Adj_verdaechtig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2833"));
            CA!.Adj_winzig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2834"));
            CA!.Adj_klotzig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2835"));
            CA!.Adj_fett = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2836"));
            CA!.Adj_steil = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2837"));
            CA!.Adj_adrett = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2838"));
            CA!.Adj_gekalkt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2839"));
            CA!.Adj_golden = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2840"));
            CA!.Adj_abscheulich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2841"));
            CA!.Adj_zerschlissen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2842"));
            CA!.Adj_plueschig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2843"));
            CA!.Adj_duenn = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2844"));
            CA!.Adj_religioes = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2845"));
            CA!.Adj_zahlreich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2846"));
            CA!.Adj_morsch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2847"));
            CA!.Adj_gesplittert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2848"));
            CA!.Adj_glatt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2849"));
            CA!.Adj_superglatt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2850"));
            CA!.Adj_fleckig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2851"));
            CA!.Adj_ehrwuerdig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2852"));
            CA!.Adj_links = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2853"));
            CA!.Adj_rechts = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2854"));
            CA!.Adj_feudal = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2855"));
            CA!.Adj_ledern = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2856"));
            CA!.Adj_riesig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2857"));
            CA!.Adj_glitzernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2858"));
            CA!.Adj_metallen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2859"));
            CA!.Adj_poliert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2860"));
            CA!.Adj_modern = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2861"));
            CA!.Adj_malerisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2862"));
            CA!.Adj_imposant = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2863"));
            CA!.Adj_hochaufragend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2864"));
            CA!.Adj_knorrig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2865"));
            CA!.Adj_verfallen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2866"));
            CA!.Adj_windschief = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2867"));
            CA!.Adj_wuchernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2868"));
            CA!.Adj_flimmernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2869"));
            CA!.Adj_mobil = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2870"));
            CA!.Adj_monstroes = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2871"));
            CA!.Adj_schwarz = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2872"));
            CA!.Adj_herausgeputzt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2873"));
            CA!.Adj_staubig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2874"));
            CA!.Adj_uebel = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2875"));
            CA!.Adj_duftend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2876"));
            CA!.Adj_juwelenbesetzt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2877"));
            Adj.AdjLoca(CA!.Adj_juwelenbesetzt!.ID, "loca.Adv_InitializeGame_Person_I_2877a");
            Adj.AdjLoca(CA!.Adj_juwelenbesetzt!.ID, "loca.Adv_InitializeGame_Person_I_2877b");
            Adj.AdjLoca(CA!.Adj_juwelenbesetzt!.ID, "loca.Adv_InitializeGame_Person_I_2877c");


            CA!.Adj_emsig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2878"));
            CA!.Adj_weiss = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2879"));
            CA!.Adj_laenglich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2880"));
            CA!.Adj_teuer = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2881"));
            CA!.Adj_dunstig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2882"));
            CA!.Adj_rund = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2883"));
            CA!.Adj_versoffen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2884"));
            CA!.Adj_wacklig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2885"));
            CA!.Adj_geschmackvoll = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2886"));
            CA!.Adj_langgezogen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2887"));
            CA!.Adj_hoffnungslos = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2888"));
            CA!.Adj_unbefestigt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2889"));
            CA!.Adj_altbacken = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2890"));
            CA!.Adj_angezeichnet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2891"));
            CA!.Adj_jaemmerlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2892"));
            CA!.Adj_farbenfroh = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2893"));
            CA!.Adj_seltsam = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2894"));
            CA!.Adj_auffaellig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2895"));
            CA!.Adj_ungewoehnlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2896"));
            CA!.Adj_ueberdimensioniert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2897"));
            CA!.Adj_befestigt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2898"));
            CA!.Adj_abgegrast = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2899"));
            CA!.Adj_ausgemergelt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2900"));
            CA!.Adj_guelden = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2901"));
            CA!.Adj_hochkaraetig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2902"));
            CA!.Adj_unheimlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2903"));
            CA!.Adj_bescheiden = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2904"));
            CA!.Adj_trunksuechtig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2905"));
            CA!.Adj_festgetrampelt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2906"));
            CA!.Adj_tanzend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2907"));
            CA!.Adj_exotisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2908"));
            CA!.Adj_erstaunlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2909"));
            CA!.Adj_funkelnd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2910"));
            CA!.Adj_zahllos = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2911"));
            CA!.Adj_obskur = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2912"));
            CA!.Adj_geflochten = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2913"));
            CA!.Adj_vierspurig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2914"));
            CA!.Adj_monumental = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2915"));
            CA!.Adj_schneebedeckt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2916"));
            CA!.Adj_voll = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2917"));
            CA!.Adj_verwildert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2918"));
            CA!.Adj_gemauert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2919"));
            CA!.Adj_ueberschaubar = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2920"));
            CA!.Adj_kaufwuetig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2921"));
            CA!.Adj_strahlend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2922"));
            CA!.Adj_gleissend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2923"));
            CA!.Adj_mondaen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2924"));
            CA!.Adj_verhaermt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2925"));
            CA!.Adj_knoecheltief = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2926"));
            CA!.Adj_sumpfig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2927"));
            CA!.Adj_unstet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2928"));
            CA!.Adj_heruntergewirtschaftet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2929"));
            CA!.Adj_matschig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2930"));
            CA!.Adj_vertikal = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2931"));
            CA!.Adj_jung = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2932"));
            CA!.Adj_geschwaetzig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2933"));
            CA!.Adj_idyllisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2934"));
            CA!.Adj_reif = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2935"));
            CA!.Adj_ueberwuchert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2936"));
            CA!.Adj_hochgewachsen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2937"));
            CA!.Adj_altmodisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2938"));
            CA!.Adj_verkalkt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2939"));
            CA!.Adj_schmucklos = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2940"));
            CA!.Adj_fromm = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2941"));
            CA!.Adj_eng = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2942"));
            CA!.Adj_langweilig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2943"));
            CA!.Adj_karg = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2944"));
            CA!.Adj_ueberfluessig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2945"));
            CA!.Adj_hell = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2946"));
            CA!.Adj_kaerglich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2947"));
            CA!.Adj_gepflegt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2948"));
            CA!.Adj_alkoholisiert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2949"));
            CA!.Adj_gluecklich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2950"));
            CA!.Adj_saftig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2951"));
            CA!.Adj_majestaetisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2952"));
            CA!.Adj_unertraeglich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2953"));
            CA!.Adj_gruselig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2954"));
            CA!.Adj_tonnenschwer = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2955"));
            CA!.Adj_futuristisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2956"));
            CA!.Adj_beleuchtet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2957"));
            CA!.Adj_verfuehrerisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2958"));
            CA!.Adj_guenstig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2959"));
            CA!.Adj_gekachelt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2960"));
            CA!.Adj_glattpoliert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2961"));
            CA!.Adj_hinterlistig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2962"));
            CA!.Adj_hoffnungsvoll = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2963"));
            CA!.Adj_leicht = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2964"));
            CA!.Adj_massiv = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2965"));
            CA!.Adj_luftig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2966"));
            CA!.Adj_knietief = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2967"));
            CA!.Adj_protzig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2968"));
            CA!.Adj_wohlhabend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2969"));
            CA!.Adj_nagelneu = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2970"));
            CA!.Adj_angrenzend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2971"));
            CA!.Adj_grossflaechig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2972"));
            CA!.Adj_drehbar = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2973"));
            CA!.Adj_hochmodern = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2974"));
            CA!.Adj_begehbar = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2975"));
            CA!.Adj_halbfertig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2976"));
            CA!.Adj_geraeumig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2977"));
            CA!.Adj_lose = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2978"));
            CA!.Adj_brennend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2979"));
            CA!.Adj_geschunden = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2980"));
            CA!.Adj_bruechig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2981"));
            CA!.Adj_elektrisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2982"));
            CA!.Adj_zuckend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2983"));
            CA!.Adj_satanisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2984"));
            CA!.Adj_duester = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2985"));
            CA!.Adj_rabenschwarz = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2986"));
            CA!.Adj_verderbt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2987"));
            CA!.Adj_wichtig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2988"));
            CA!.Adj_massenhaft = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2989"));
            CA!.Adj_schwimmend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2990"));
            CA!.Adj_verkohlt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2991"));
            CA!.Adj_teuflisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2992"));
            CA!.Adj_knochenbesetzt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2993"));
            CA!.Adj_lodernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2994"));
            CA!.Adj_schwebend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2995"));
            CA!.Adj_knallrot = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2996"));
            CA!.Adj_kohlrabenschwarz = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2997"));
            CA!.Adj_glaesern = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2998"));
            CA!.Adj_beschmiert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_2999"));
            CA!.Adj_dampfend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3000"));
            CA!.Adj_schimmelnd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3001"));
            CA!.Adj_verwerflich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3002"));
            CA!.Adj_daemonisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3003"));
            CA!.Adj_herabhaengend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3004"));
            CA!.Adj_ueberquellend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3005"));
            CA!.Adj_obszoen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3006"));
            CA!.Adj_ansehnlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3007"));
            CA!.Adj_trostlos = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3008"));
            CA!.Adj_knochenfarben = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3009"));
            CA!.Adj_okkult = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3010"));
            CA!.Adj_angekokelt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3011"));
            CA!.Adj_steinig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3012"));
            CA!.Adj_verrucht = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3013"));
            CA!.Adj_bleich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3014"));
            CA!.Adj_suendig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3015"));
            CA!.Adj_gelb = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3016"));
            CA!.Adj_lila = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3017"));
            CA!.Adj_weinrot = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3018"));
            CA!.Adj_prall = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3019"));
            CA!.Adj_erlesen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3020"));
            CA!.Adj_zertrampelt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3021"));
            CA!.Adj_traumatisiert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3022"));
            CA!.Adj_locker = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3023"));
            CA!.Adj_baumelnd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3024"));
            CA!.Adj_wild = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3025"));
            CA!.Adj_feiernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3026"));
            CA!.Adj_unreif = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3027"));
            CA!.Adj_orange = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3028"));
            CA!.Adj_extrastark = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3029"));
            CA!.Adj_angekettet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3030"));
            CA!.Adj_glimmend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3031"));
            CA!.Adj_froehlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3032"));
            CA!.Adj_geladen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3033"));
            CA!.Adj_verrottet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3034"));
            CA!.Adj_kuemmerlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3035"));
            CA!.Adj_blutrot = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3036"));
            CA!.Adj_knoechern = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3037"));
            CA!.Adj_guetig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3038"));
            CA!.Adj_anerkennend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3039"));
            CA!.Adj_beilaeufig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3040"));
            CA!.Adj_empoert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3041"));
            CA!.Adj_ergriffen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3042"));
            CA!.Adj_hinterhaeltig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3043"));
            CA!.Adj_lauernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3044"));
            CA!.Adj_mitleidig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3045"));
            CA!.Adj_sabbernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3046"));
            CA!.Adj_suesslich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3047"));
            CA!.Adj_ungluecklich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3048"));
            CA!.Adj_misstrauisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3049"));
            CA!.Adj_verzweifelt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3050"));
            CA!.Adj_vorsichtig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3051"));
            CA!.Adj_geoeffnet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3052"));
            CA!.Adj_spriessend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3053"));
            CA!.Adj_eifernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3054"));
            CA!.Adj_entschlossen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3055"));
            CA!.Adj_entsetzt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3056"));
            CA!.Adj_enttaeuscht = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3057"));
            CA!.Adj_entzueckt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3058"));
            CA!.Adj_erregt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3059"));
            CA!.Adj_fassungslos = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3060"));
            CA!.Adj_genervt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3061"));
            CA!.Adj_geruehrt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3062"));
            CA!.Adj_grossmuetig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3063"));
            CA!.Adj_grossspurig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3064"));
            CA!.Adj_kleinlaut = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3065"));
            CA!.Adj_nachdenklich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3066"));
            CA!.Adj_triumphierend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3067"));
            CA!.Adj_vorwurfsvoll = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3068"));

            CA!.Adj_aufgebracht = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3069"));
            CA!.Adj_bedeutungsschwer = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3070"));
            CA!.Adj_zerknirscht = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3071"));
            CA!.Adj_entnervt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3072"));
            CA!.Adj_erschrocken = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3073"));
            CA!.Adj_gelassen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3074"));
            CA!.Adj_gierig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3075"));
            CA!.Adj_gleichgueltig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3076"));
            CA!.Adj_hungrig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3077"));
            CA!.Adj_resigniert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3078"));
            CA!.Adj_ueberrascht = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3079"));
            CA!.Adj_verstaendnisvoll = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3080"));
            CA!.Adj_gewagt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3081"));
            CA!.Adj_verstoerend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3082"));
            CA!.Adj_verwegen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3083"));
            CA!.Adj_bizarr = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3084"));
            CA!.Adj_bedauernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3085"));
            CA!.Adj_beunruhigt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3086"));
            CA!.Adj_gelangweilt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3087"));
            CA!.Adj_herablassend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3088"));
            CA!.Adj_irritiert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3089"));
            CA!.Adj_listig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3090"));
            CA!.Adj_nachdruecklich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3091"));
            CA!.Adj_spoettisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3092"));
            CA!.Adj_stur = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3093"));
            CA!.Adj_verunsichert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3094"));
            CA!.Adj_divin = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3095"));
            CA!.Adj_niedlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3096"));
            CA!.Adj_abgedreht = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3097"));
            CA!.Adj_aufgeregt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3098"));
            CA!.Adj_erstaunt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3099"));
            CA!.Adj_hilfsbereit = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3100"));
            CA!.Adj_leichthin = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3101"));
            CA!.Adj_neugierig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3102"));
            CA!.Adj_sueffisant = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3103"));
            CA!.Adj_ungehalten = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3104"));
            CA!.Adj_verbittert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3105"));
            CA!.Adj_weinerlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3106"));
            CA!.Adj_bedrohlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3107"));
            CA!.Adj_belehrend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3108"));
            CA!.Adj_bewundernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3109"));
            CA!.Adj_erfreut = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3110"));
            CA!.Adj_grinsend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3111"));
            CA!.Adj_gruebelnd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3112"));
            CA!.Adj_hypnotisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3113"));
            CA!.Adj_weihevoll = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3114"));
            CA!.Adj_aechzend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3115"));
            CA!.Adj_beglueckt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3116"));
            CA!.Adj_blechern = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3117"));
            CA!.Adj_verwundert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3118"));

            CA!.Adj_angewidert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3119"));
            CA!.Adj_anklagend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3120"));
            CA!.Adj_betroffen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3121"));
            CA!.Adj_diplomatisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3122"));
            CA!.Adj_ehrlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3123"));
            CA!.Adj_feierlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3124"));
            CA!.Adj_giftig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3125"));
            CA!.Adj_hastig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3126"));
            CA!.Adj_schnaubend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3127"));
            CA!.Adj_selbstgefaellig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3128"));
            CA!.Adj_seufzend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3129"));
            CA!.Adj_superschlau = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3130"));
            CA!.Adj_verwirrt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3131"));
            CA!.Adj_zerstreut = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3132"));
            CA!.Adj_hoellisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3133"));
            CA!.Adj_toedlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3134"));
            CA!.Adj_begeistert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3135"));
            CA!.Adj_besorgt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3136"));
            CA!.Adj_betruebt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3137"));
            CA!.Adj_enthusiastisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3138"));
            CA!.Adj_skeptisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3139"));
            CA!.Adj_zweifelnd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3140"));
            CA!.Adj_leise = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3141"));
            CA!.Adj_klappernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3142"));
            CA!.Adj_boesartig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3143"));
            CA!.Adj_ablehnend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3144"));
            CA!.Adj_deprimiert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3145"));
            CA!.Adj_erschuettert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3146"));
            CA!.Adj_gaehnend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3147"));
            CA!.Adj_geheimnisvoll = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3148"));
            CA!.Adj_sinnierend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3149"));
            CA!.Adj_stoehnend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3150"));
            CA!.Adj_streng = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3151"));
            CA!.Adj_ueberschaeumend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3152"));
            CA!.Adj_verbluefft = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3153"));
            CA!.Adj_zusammenfassend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3154"));
            CA!.Adj_zuversichtlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3155"));

            CA!.Adj_abwehrend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3156"));
            CA!.Adj_beschwichtigend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3157"));
            CA!.Adj_energisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3158"));
            CA!.Adj_gequaelt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3159"));
            CA!.Adj_gestresst = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3160"));
            CA!.Adj_harsch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3161"));
            CA!.Adj_missbilligend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3162"));
            CA!.Adj_tapfer = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3163"));
            CA!.Adj_traurig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3164"));
            CA!.Adj_ungeduldig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3165"));
            CA!.Adj_verstaendnislos = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3166"));
            CA!.Adj_zwinkernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3167"));

            CA!.Adj_flehend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3168"));
            CA!.Adj_gebrochen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3169"));
            CA!.Adj_leidend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3170"));
            CA!.Adj_zuvorkommend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3171"));
            CA!.Adj_euphorisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3172"));
            CA!.Adj_reserviert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3173"));
            CA!.Adj_verschlagen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3174"));
            CA!.Adj_mitfuehlend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3175"));
            CA!.Adj_selbstmitleidig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3176"));
            CA!.Adj_unbehaglich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3177"));
            CA!.Adj_entruestet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3178"));

            CA!.Adj_erschoepft = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3179"));
            CA!.Adj_grosszuegig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3180"));
            CA!.Adj_sehnsuchtsvoll = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3181"));
            CA!.Adj_selbstbewusst = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3182"));
            CA!.Adj_grummelnd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3183"));
            CA!.Adj_hektisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3184"));
            CA!.Adj_hoehnisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3185"));
            CA!.Adj_schaeumend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3186"));
            CA!.Adj_schnittig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3187"));
            CA!.Adj_untertaenig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3188"));

            CA!.Adj_blasiert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3189"));
            CA!.Adj_ehrfuerchtig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3190"));
            CA!.Adj_eitel = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3191"));
            CA!.Adj_nervoes = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3192"));
            CA!.Adj_schmunzelnd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3193"));
            CA!.Adj_schweissabwischend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3194"));
            CA!.Adj_veraergert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3195"));
            CA!.Adj_verzueckt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3196"));
            CA!.Adj_gertenschlank = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3197"));
            CA!.Adj_saeuselnd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3198"));
            CA!.Adj_ueberschnappend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3199"));
            CA!.Adj_wuetend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3200"));

            CA!.Adj_arglos = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3201"));
            CA!.Adj_argwoehnisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3202"));
            CA!.Adj_atemlos = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3203"));
            CA!.Adj_aufmunternd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3204"));
            CA!.Adj_entspannt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3205"));
            CA!.Adj_geschaeftig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3206"));
            CA!.Adj_herausfordernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3207"));
            CA!.Adj_hypnotisiert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3208"));
            CA!.Adj_hysterisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3209"));
            CA!.Adj_sauer = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3210"));
            CA!.Adj_scheinheilig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3211"));
            CA!.Adj_ueberzeugt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3212"));
            CA!.Adj_unglaeubig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3213"));
            CA!.Adj_versonnen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3214"));
            CA!.Adj_stachlig2 = Adjs!.Add(Adj.AdjLoca("Adj_stachlig2"));

            CA!.Adj_alarmiert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3215"));
            CA!.Adj_beaengstigt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3216"));
            CA!.Adj_bestuerzt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3217"));
            CA!.Adj_erbost = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3218"));
            CA!.Adj_heiser = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3219"));
            CA!.Adj_schnappatmend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3220"));
            CA!.Adj_seelenruhig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3221"));
            CA!.Adj_schnaufend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3222"));
            CA!.Adj_tadelnd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3223"));

            CA!.Adj_brutal = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3224"));
            CA!.Adj_ermunternd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3225"));
            CA!.Adj_freudig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3226"));
            CA!.Adj_gackernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3227"));
            CA!.Adj_geschlagen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3228"));
            CA!.Adj_ruhig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3229"));
            CA!.Adj_unbeeindruckt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3230"));
            CA!.Adj_unsicher = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3231"));
            CA!.Adj_verlegen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3232"));
            CA!.Adj_verschaemt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3233"));
            CA!.Adj_gehaessig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3234"));

            CA!.Adj_abwesend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3235"));
            CA!.Adj_luftschnappend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3236"));
            CA!.Adj_panisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3237"));
            CA!.Adj_verdriesslich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3238"));

            CA!.Adj_augenzwinkernd = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3239"));
            CA!.Adj_befremdet = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3240"));
            CA!.Adj_jovial = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3241"));
            CA!.Adj_schluchzend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3242"));
            CA!.Adj_schwaermerisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3243"));
            CA!.Adj_zoegerlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3244"));

            CA!.Adj_eisig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3245"));
            CA!.Adj_gereizt = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3246"));

            CA!.Adj_erroetend = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3247"));
            CA!.Adj_verschnupft = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3248"));

            CA!.Adj_stoned = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3249"));
            CA!.Adj_zackig = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3250"));
            CA!.Adj_westlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3251"));
            CA!.Adj_oestlich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3252"));
            CA!.Adj_heruntergelassen = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3253"));
            CA!.Adj_elegant = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3254"));
            CA!.Adj_pathetisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3255"));
            CA!.Adj_samten = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3256"));

            CA!.Adj_notorisch = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3257"));
            CA!.Adj_fern = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3258"));
            CA!.Adj_erhaben = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3259"));

            CA!.Adj_blaesslich = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3260"));
            CA!.Adj_gewienert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3261"));
            CA!.Adj_gesaeubert = Adjs!.Add(Adj.AdjLoca("Adv_InitializeGame_Person_I_3262"));
            CA!.Adj_eisern = Adjs!.Add(Adj.AdjLoca("Adj_eisern"));

            CA!.Adj_bio = Adjs!.Add(Adj.AdjLoca("Adj_bio"));
            CA!.Adj_super = Adjs!.Add(Adj.AdjLoca("Adj_super"));
            CA!.Adj_bedeutungslos = Adjs!.Add(Adj.AdjLoca("Adj_bedeutungslos"));
            CA!.Adj_panoramisch = Adjs!.Add(Adj.AdjLoca("Adj_panoramisch"));
            CA!.Adj_neu = Adjs!.Add(Adj.AdjLoca("Adj_neu"));

            CA!.Adj_extra = Adjs!.Add(Adj.AdjLoca("Adj_extra"));
            CA!.Adj_registriert = Adjs!.Add(Adj.AdjLoca("Adj_registriert"));
            CA!.Adj_ruiniert = Adjs!.Add(Adj.AdjLoca("Adj_ruiniert"));
            CA!.Adj_magic = Adjs!.Add(Adj.AdjLoca("Adj_magic"));
            CA!.Adj_organic = Adjs!.Add(Adj.AdjLoca("Adj_organic"));

        }

        void InitAdjectivesFast(int size = -1)
        {
            if (size != -1)
            {
                Adjs!.TList = new Dictionary<string, Adj>(size, StringComparer.CurrentCultureIgnoreCase);

            }
            var Adjlist = new List<KeyValuePair<string, Adj>>(900);

            Adjs!.SetupAdjBuffer(900);

            // Neue Adj
            CA!.Adj_ausgestopft = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_ausgestopft, "Adj_ausgestopft"));
            CA!.Adj_beschrieben = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_beschrieben, "Adj_beschrieben"));
            CA!.Adj_besonders = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_besonders, "Adj_besonders"));
            CA!.Adj_gekuehlt = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_gekuehlt, "Adj_gekuehlt"));
            CA!.Adj_hasserfuellt = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_hasserfuellt, "Adj_hasserfuellt"));
            CA!.Adj_instabil = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_instabil, "Adj_instabil"));
            CA!.Adj_lichtlos = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_lichtlos, "Adj_lichtlos"));
            CA!.Adj_magisch = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_magisch, "Adj_magisch"));
            CA!.Adj_mueffelnd = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_mueffelnd, "Adj_mueffelnd"));
            CA!.Adj_neblig = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_neblig, "Adj_neblig"));
            CA!.Adj_peinlich = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_peinlich, "Adj_peinlich"));
            CA!.Adj_schimmernd = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_schimmernd, "Adj_schimmernd"));
            CA!.Adj_sinister = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_sinister, "Adj_sinister"));
            CA!.Adj_stattlich = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_stattlich, "Adj_stattlich"));
            CA!.Adj_verrueckt = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_verrueckt, "Adj_verrueckt"));
            CA!.Adj_vertrocknet = Adjs!.Add(Adj.AdjLocaLoca(loca.Adj_vertrocknet, "Adj_vertrocknet"));


            CA!.Adj_stark = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2641, "Adv_InitializeGame_Person_I_2641"));
            CA!.Adj_reissfest = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2642, "Adv_InitializeGame_Person_I_2642"));
            CA!.Adj_gruen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2643, "Adv_InitializeGame_Person_I_2643"));
            CA!.Adj_gross = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2644, "Adv_InitializeGame_Person_I_2644"));
            CA!.Adj_rot = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2645, "Adv_InitializeGame_Person_I_2645"));
            CA!.Adj_klein = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2646, "Adv_InitializeGame_Person_I_2646"));
            CA!.Adj_mittel = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2647, "Adv_InitializeGame_Person_I_2647"));
            CA!.Adj_allwissend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2648, "Adv_InitializeGame_Person_I_2648"));
            CA!.Adj_rostig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2649, "Adv_InitializeGame_Person_I_2649"));
            CA!.Adj_gigantisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2650, "Adv_InitializeGame_Person_I_2650"));
            CA!.Adj_heftig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2651, "Adv_InitializeGame_Person_I_2651"));
            CA!.Adj_atemberaubend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2652, "Adv_InitializeGame_Person_I_2652"));
            CA!.Adj_veraltet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2653, "Adv_InitializeGame_Person_I_2653"));

            CA!.Adj_vergammelt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2654, "Adv_InitializeGame_Person_I_2654"));
            CA!.Adj_gewoehnlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2655, "Adv_InitializeGame_Person_I_2655"));
            CA!.Adj_vergilbt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2656, "Adv_InitializeGame_Person_I_2656"));
            CA!.Adj_zerrissen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2657, "Adv_InitializeGame_Person_I_2657"));
            CA!.Adj_kaputt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2658, "Adv_InitializeGame_Person_I_2658"));
            CA!.Adj_dreckig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2659, "Adv_InitializeGame_Person_I_2659"));
            CA!.Adj_verschlossen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2660, "Adv_InitializeGame_Person_I_2660"));
            CA!.Adj_breit = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2661, "Adv_InitializeGame_Person_I_2661"));
            CA!.Adj_marode = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2662, "Adv_InitializeGame_Person_I_2662"));
            CA!.Adj_klapprig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2663, "Adv_InitializeGame_Person_I_2663"));
            CA!.Adj_fein = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2664, "Adv_InitializeGame_Person_I_2664"));
            CA!.Adj_ausgeblichen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2665, "Adv_InitializeGame_Person_I_2665"));
            CA!.Adj_wahnsinnig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2666, "Adv_InitializeGame_Person_I_2666"));
            CA!.Adj_bekloppt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2667, "Adv_InitializeGame_Person_I_2667"));
            CA!.Adj_irre = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2668, "Adv_InitializeGame_Person_I_2668"));
            CA!.Adj_dicht = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2669, "Adv_InitializeGame_Person_I_2669"));
            CA!.Adj_graviert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2670, "Adv_InitializeGame_Person_I_2670"));
            CA!.Adj_hoch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2671, "Adv_InitializeGame_Person_I_2671"));
            CA!.Adj_kurz = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2672, "Adv_InitializeGame_Person_I_2672"));
            CA!.Adj_weit = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2673, "Adv_InitializeGame_Person_I_2673"));
            CA!.Adj_formschoen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2674, "Adv_InitializeGame_Person_I_2674"));
            CA!.Adj_biegsam = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2675, "Adv_InitializeGame_Person_I_2675"));
            CA!.Adj_einfach = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2676, "Adv_InitializeGame_Person_I_2676"));
            CA!.Adj_prachtvoll = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2677, "Adv_InitializeGame_Person_I_2677"));
            CA!.Adj_tief = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2678, "Adv_InitializeGame_Person_I_2678"));
            CA!.Adj_stumpf = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2679, "Adv_InitializeGame_Person_I_2679"));
            CA!.Adj_bunt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2680, "Adv_InitializeGame_Person_I_2680"));
            CA!.Adj_lang = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2681, "Adv_InitializeGame_Person_I_2681"));
            CA!.Adj_stabil = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2682, "Adv_InitializeGame_Person_I_2682"));
            CA!.Adj_schaebig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2683, "Adv_InitializeGame_Person_I_2683"));
            CA!.Adj_schuechtern = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2684, "Adv_InitializeGame_Person_I_2684"));
            CA!.Adj_knurrig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2685, "Adv_InitializeGame_Person_I_2685"));
            CA!.Adj_heruntergekommen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2686, "Adv_InitializeGame_Person_I_2686"));
            CA!.Adj_grimmig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2687, "Adv_InitializeGame_Person_I_2687"));
            CA!.Adj_braun = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2688, "Adv_InitializeGame_Person_I_2688"));
            CA!.Adj_alt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2689, "Adv_InitializeGame_Person_I_2689"));
            CA!.Adj_offen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2690, "Adv_InitializeGame_Person_I_2690"));
            CA!.Adj_gefaehrlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2691, "Adv_InitializeGame_Person_I_2691"));
            CA!.Adj_primitiv = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2692, "Adv_InitializeGame_Person_I_2692"));
            CA!.Adj_schmuddelig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2693, "Adv_InitializeGame_Person_I_2693"));
            CA!.Adj_wackelig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2694, "Adv_InitializeGame_Person_I_2694"));
            CA!.Adj_modrig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2695, "Adv_InitializeGame_Person_I_2695"));
            CA!.Adj_niedrig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2696, "Adv_InitializeGame_Person_I_2696"));
            CA!.Adj_schmal = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2697, "Adv_InitializeGame_Person_I_2697"));
            CA!.Adj_herumliegend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2698, "Adv_InitializeGame_Person_I_2698"));
            CA!.Adj_lecker = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2699, "Adv_InitializeGame_Person_I_2699"));
            CA!.Adj_zerbrochen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2700, "Adv_InitializeGame_Person_I_2700"));
            CA!.Adj_robust = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2701, "Adv_InitializeGame_Person_I_2701"));
            CA!.Adj_wabernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2702, "Adv_InitializeGame_Person_I_2702"));
            CA!.Adj_herumstehend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2703, "Adv_InitializeGame_Person_I_2703"));
            CA!.Adj_schwach = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2704, "Adv_InitializeGame_Person_I_2704"));
            CA!.Adj_gepflueckt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2705, "Adv_InitializeGame_Person_I_2705"));
            CA!.Adj_betrunken = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2706, "Adv_InitializeGame_Person_I_2706"));
            CA!.Adj_fesch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2707, "Adv_InitializeGame_Person_I_2707"));
            CA!.Adj_unfesch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2708, "Adv_InitializeGame_Person_I_2708"));
            CA!.Adj_steif = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2709, "Adv_InitializeGame_Person_I_2709"));
            CA!.Adj_verwittert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2710, "Adv_InitializeGame_Person_I_2710"));
            CA!.Adj_eifrig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2711, "Adv_InitializeGame_Person_I_2711"));
            CA!.Adj_druckfrisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2712, "Adv_InitializeGame_Person_I_2712"));
            CA!.Adj_schwer = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2713, "Adv_InitializeGame_Person_I_2713"));
            CA!.Adj_uneben = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2714, "Adv_InitializeGame_Person_I_2714"));
            // CA!.Adj_finster = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2715, "Adv_InitializeGame_Person_I_2715"));
            CA!.Adj_stolz = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2716, "Adv_InitializeGame_Person_I_2716"));
            CA!.Adj_spitz = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2717, "Adv_InitializeGame_Person_I_2717"));
            CA!.Adj_gescheckt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2718, "Adv_InitializeGame_Person_I_2718"));
            CA!.Adj_unscheinbar = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2719, "Adv_InitializeGame_Person_I_2719"));
            CA!.Adj_windig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2720, "Adv_InitializeGame_Person_I_2720"));
            CA!.Adj_oelverschmiert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2721, "Adv_InitializeGame_Person_I_2721"));
            CA!.Adj_glaenzend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2722, "Adv_InitializeGame_Person_I_2722"));
            CA!.Adj_rustikal = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2723, "Adv_InitializeGame_Person_I_2723"));
            CA!.Adj_solide = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2724, "Adv_InitializeGame_Person_I_2724"));
            CA!.Adj_schlaefrig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2725, "Adv_InitializeGame_Person_I_2725"));
            CA!.Adj_feurig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2726, "Adv_InitializeGame_Person_I_2726"));
            CA!.Adj_albern = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2727, "Adv_InitializeGame_Person_I_2727"));
            CA!.Adj_ausgebleicht = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2728, "Adv_InitializeGame_Person_I_2728"));
            CA!.Adj_blutig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2729, "Adv_InitializeGame_Person_I_2729"));
            CA!.Adj_dunkel = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2730, "Adv_InitializeGame_Person_I_2730"));
            CA!.Adj_farbig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2731, "Adv_InitializeGame_Person_I_2731"));
            CA!.Adj_frisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2732, "Adv_InitializeGame_Person_I_2732"));
            CA!.Adj_gebacken = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2733, "Adv_InitializeGame_Person_I_2733"));
            CA!.Adj_getunkt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2734, "Adv_InitializeGame_Person_I_2734"));
            CA!.Adj_gezinkt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2735, "Adv_InitializeGame_Person_I_2735"));
            CA!.Adj_glaslos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2736, "Adv_InitializeGame_Person_I_2736"));
            CA!.Adj_haesslich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2737, "Adv_InitializeGame_Person_I_2737"));
            CA!.Adj_leer = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2738, "Adv_InitializeGame_Person_I_2738"));
            CA!.Adj_plump = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2739, "Adv_InitializeGame_Person_I_2739"));
            CA!.Adj_reisserisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2740, "Adv_InitializeGame_Person_I_2740"));
            CA!.Adj_schief = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2741, "Adv_InitializeGame_Person_I_2741"));
            CA!.Adj_schmutzig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2742, "Adv_InitializeGame_Person_I_2742"));
            CA!.Adj_unterbelichtet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2743, "Adv_InitializeGame_Person_I_2743"));
            CA!.Adj_ueberbelichtet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2744, "Adv_InitializeGame_Person_I_2744"));
            CA!.Adj_ueppig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2745, "Adv_InitializeGame_Person_I_2745"));
            CA!.Adj_unscharf = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2746, "Adv_InitializeGame_Person_I_2746"));
            CA!.Adj_vergiftet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2747, "Adv_InitializeGame_Person_I_2747"));
            CA!.Adj_verschmiert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2748, "Adv_InitializeGame_Person_I_2748"));
            CA!.Adj_verwackelt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2749, "Adv_InitializeGame_Person_I_2749"));
            CA!.Adj_verziert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2750, "Adv_InitializeGame_Person_I_2750"));
            CA!.Adj_zerknittert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2751, "Adv_InitializeGame_Person_I_2751"));
            CA!.Adj_zierlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2752, "Adv_InitializeGame_Person_I_2752"));
            CA!.Adj_blau = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2753, "Adv_InitializeGame_Person_I_2753"));
            CA!.Adj_episch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2754, "Adv_InitializeGame_Person_I_2754"));
            CA!.Adj_erlogen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2755, "Adv_InitializeGame_Person_I_2755"));
            CA!.Adj_heimtueckisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2756, "Adv_InitializeGame_Person_I_2756"));
            CA!.Adj_herrenlos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2757, "Adv_InitializeGame_Person_I_2757"));
            CA!.Adj_lachhaft = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2758, "Adv_InitializeGame_Person_I_2758"));
            CA!.Adj_loechrig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2759, "Adv_InitializeGame_Person_I_2759"));
            CA!.Adj_niedertraechtig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2760, "Adv_InitializeGame_Person_I_2760"));
            CA!.Adj_zerfleddert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2761, "Adv_InitializeGame_Person_I_2761"));
            CA!.Adj_oval = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2762, "Adv_InitializeGame_Person_I_2762"));
            CA!.Adj_schaendlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2763, "Adv_InitializeGame_Person_I_2763"));
            CA!.Adj_scharfkantig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2764, "Adv_InitializeGame_Person_I_2764"));
            CA!.Adj_subversiv = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2765, "Adv_InitializeGame_Person_I_2765"));
            CA!.Adj_suspekt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2766, "Adv_InitializeGame_Person_I_2766"));
            CA!.Adj_verbloedet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2767, "Adv_InitializeGame_Person_I_2767"));
            CA!.Adj_verbogen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2768, "Adv_InitializeGame_Person_I_2768"));
            CA!.Adj_zerkratzt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2769, "Adv_InitializeGame_Person_I_2769"));
            CA!.Adj_verraeterisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2770, "Adv_InitializeGame_Person_I_2770"));
            CA!.Adj_wuselnd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2771, "Adv_InitializeGame_Person_I_2771"));
            CA!.Adj_zerknickt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2772, "Adv_InitializeGame_Person_I_2772"));
            CA!.Adj_durchsichtig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2773, "Adv_InitializeGame_Person_I_2773"));
            CA!.Adj_edel = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2774, "Adv_InitializeGame_Person_I_2774"));
            CA!.Adj_fettig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2775, "Adv_InitializeGame_Person_I_2775"));
            CA!.Adj_gebraten = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2776, "Adv_InitializeGame_Person_I_2776"));
            CA!.Adj_gefuellt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2777, "Adv_InitializeGame_Person_I_2777"));
            CA!.Adj_geifernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2778, "Adv_InitializeGame_Person_I_2778"));
            CA!.Adj_handlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2779, "Adv_InitializeGame_Person_I_2779"));
            CA!.Adj_hoffnungsfroh = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2780, "Adv_InitializeGame_Person_I_2780"));
            CA!.Adj_klebrig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2781, "Adv_InitializeGame_Person_I_2781"));
            CA!.Adj_lebhaft = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2782, "Adv_InitializeGame_Person_I_2782"));
            CA!.Adj_lesbar = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2783, "Adv_InitializeGame_Person_I_2783"));
            CA!.Adj_maechtig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2784, "Adv_InitializeGame_Person_I_2784"));
            CA!.Adj_modisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2785, "Adv_InitializeGame_Person_I_2785"));
            CA!.Adj_roh = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2786, "Adv_InitializeGame_Person_I_2786"));
            CA!.Adj_tot = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2787, "Adv_InitializeGame_Person_I_2787"));
            CA!.Adj_unbedruckt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2788, "Adv_InitializeGame_Person_I_2788"));
            CA!.Adj_verdammungswuerdig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2789, "Adv_InitializeGame_Person_I_2789"));
            CA!.Adj_verlogen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2790, "Adv_InitializeGame_Person_I_2790"));
            CA!.Adj_verschlammt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2791, "Adv_InitializeGame_Person_I_2791"));
            CA!.Adj_versifft = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2792, "Adv_InitializeGame_Person_I_2792"));

            CA!.Adj_aufgeblasen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2793, "Adv_InitializeGame_Person_I_2793"));
            CA!.Adj_bewusstlos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2794, "Adv_InitializeGame_Person_I_2794"));
            CA!.Adj_esoterisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2795, "Adv_InitializeGame_Person_I_2795"));
            CA!.Adj_extragross = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2796, "Adv_InitializeGame_Person_I_2796"));
            CA!.Adj_falsch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2797, "Adv_InitializeGame_Person_I_2797"));
            CA!.Adj_gekritzelt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2798, "Adv_InitializeGame_Person_I_2798"));
            CA!.Adj_gerieben = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2799, "Adv_InitializeGame_Person_I_2799"));
            CA!.Adj_gluehend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2800, "Adv_InitializeGame_Person_I_2800"));
            CA!.Adj_offiziell = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2801, "Adv_InitializeGame_Person_I_2801"));
            CA!.Adj_schmierig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2802, "Adv_InitializeGame_Person_I_2802"));
            CA!.Adj_stachlig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2803, "Adv_InitializeGame_Person_I_2803"));
            Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2804, CA!.Adj_stachlig!.ID, "Adv_InitializeGame_Person_I_2804");
            CA!.Adj_verwesend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2805, "Adv_InitializeGame_Person_I_2805"));
            CA!.Adj_wuchtig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2806, "Adv_InitializeGame_Person_I_2806"));
            CA!.Adj_fragwuerdig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2807, "Adv_InitializeGame_Person_I_2807"));
            CA!.Adj_leichenblass = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2808, "Adv_InitializeGame_Person_I_2808"));
            CA!.Adj_schimmlig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2809, "Adv_InitializeGame_Person_I_2809"));
            CA!.Adj_abgeranzt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2810, "Adv_InitializeGame_Person_I_2810"));
            CA!.Adj_baufaellig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2811, "Adv_InitializeGame_Person_I_2811"));
            CA!.Adj_steinern = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2812, "Adv_InitializeGame_Person_I_2812"));
            CA!.Adj_verrusst = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2813, "Adv_InitializeGame_Person_I_2813"));
            CA!.Adj_grob = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2814, "Adv_InitializeGame_Person_I_2814"));
            CA!.Adj_dick = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2815, "Adv_InitializeGame_Person_I_2815"));
            CA!.Adj_stinkend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2816, "Adv_InitializeGame_Person_I_2816"));
            CA!.Adj_hoelzern = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2817, "Adv_InitializeGame_Person_I_2817"));
            CA!.Adj_weitlaeufig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2818, "Adv_InitializeGame_Person_I_2818"));
            CA!.Adj_trueb = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2819, "Adv_InitializeGame_Person_I_2819"));
            CA!.Adj_abgewetzt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2820, "Adv_InitializeGame_Person_I_2820"));
            CA!.Adj_antiquiert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2821, "Adv_InitializeGame_Person_I_2821"));
            CA!.Adj_eklig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2822, "Adv_InitializeGame_Person_I_2822"));
            CA!.Adj_feucht = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2823, "Adv_InitializeGame_Person_I_2823"));
            CA!.Adj_getrocknet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2824, "Adv_InitializeGame_Person_I_2824"));
            CA!.Adj_nutzlos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2825, "Adv_InitializeGame_Person_I_2825"));
            CA!.Adj_ausgedehnt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2826, "Adv_InitializeGame_Person_I_2826"));
            CA!.Adj_wundervoll = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2827, "Adv_InitializeGame_Person_I_2827"));
            CA!.Adj_paradiesisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2828, "Adv_InitializeGame_Person_I_2828"));
            CA!.Adj_ausladend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2829, "Adv_InitializeGame_Person_I_2829"));
            CA!.Adj_kitschig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2830, "Adv_InitializeGame_Person_I_2830"));
            CA!.Adj_klobig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2831, "Adv_InitializeGame_Person_I_2831"));
            CA!.Adj_opulent = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2832, "Adv_InitializeGame_Person_I_2832"));
            CA!.Adj_verdaechtig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2833, "Adv_InitializeGame_Person_I_2833"));
            CA!.Adj_winzig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2834, "Adv_InitializeGame_Person_I_2834"));
            CA!.Adj_klotzig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2835, "Adv_InitializeGame_Person_I_2835"));
            CA!.Adj_fett = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2836, "Adv_InitializeGame_Person_I_2836"));
            CA!.Adj_steil = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2837, "Adv_InitializeGame_Person_I_2837"));
            CA!.Adj_adrett = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2838, "Adv_InitializeGame_Person_I_2838"));
            CA!.Adj_gekalkt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2839, "Adv_InitializeGame_Person_I_2839"));
            CA!.Adj_golden = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2840, "Adv_InitializeGame_Person_I_2840"));
            CA!.Adj_abscheulich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2841, "Adv_InitializeGame_Person_I_2841"));
            CA!.Adj_zerschlissen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2842, "Adv_InitializeGame_Person_I_2842"));
            CA!.Adj_plueschig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2843, "Adv_InitializeGame_Person_I_2843"));
            CA!.Adj_duenn = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2844, "Adv_InitializeGame_Person_I_2844"));
            CA!.Adj_religioes = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2845, "Adv_InitializeGame_Person_I_2845"));
            CA!.Adj_zahlreich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2846, "Adv_InitializeGame_Person_I_2846"));
            CA!.Adj_morsch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2847, "Adv_InitializeGame_Person_I_2847"));
            CA!.Adj_gesplittert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2848, "Adv_InitializeGame_Person_I_2848"));
            CA!.Adj_glatt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2849, "Adv_InitializeGame_Person_I_2849"));
            CA!.Adj_superglatt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2850, "Adv_InitializeGame_Person_I_2850"));
            CA!.Adj_fleckig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2851, "Adv_InitializeGame_Person_I_2851"));
            CA!.Adj_ehrwuerdig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2852, "Adv_InitializeGame_Person_I_2852"));
            CA!.Adj_links = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2853, "Adv_InitializeGame_Person_I_2853"));
            CA!.Adj_rechts = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2854, "Adv_InitializeGame_Person_I_2854"));
            CA!.Adj_feudal = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2855, "Adv_InitializeGame_Person_I_2855"));
            CA!.Adj_ledern = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2856, "Adv_InitializeGame_Person_I_2856"));
            CA!.Adj_riesig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2857, "Adv_InitializeGame_Person_I_2857"));
            CA!.Adj_glitzernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2858, "Adv_InitializeGame_Person_I_2858"));
            CA!.Adj_metallen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2859, "Adv_InitializeGame_Person_I_2859"));
            CA!.Adj_poliert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2860, "Adv_InitializeGame_Person_I_2860"));
            CA!.Adj_modern = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2861, "Adv_InitializeGame_Person_I_2861"));
            CA!.Adj_malerisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2862, "Adv_InitializeGame_Person_I_2862"));
            CA!.Adj_imposant = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2863, "Adv_InitializeGame_Person_I_2863"));
            CA!.Adj_hochaufragend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2864, "Adv_InitializeGame_Person_I_2864"));
            CA!.Adj_knorrig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2865, "Adv_InitializeGame_Person_I_2865"));
            CA!.Adj_verfallen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2866, "Adv_InitializeGame_Person_I_2866"));
            CA!.Adj_windschief = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2867, "Adv_InitializeGame_Person_I_2867"));
            CA!.Adj_wuchernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2868, "Adv_InitializeGame_Person_I_2868"));
            CA!.Adj_flimmernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2869, "Adv_InitializeGame_Person_I_2869"));
            CA!.Adj_mobil = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2870, "Adv_InitializeGame_Person_I_2870"));
            CA!.Adj_monstroes = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2871, "Adv_InitializeGame_Person_I_2871"));
            CA!.Adj_schwarz = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2872, "Adv_InitializeGame_Person_I_2872"));
            CA!.Adj_herausgeputzt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2873, "Adv_InitializeGame_Person_I_2873"));
            CA!.Adj_staubig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2874, "Adv_InitializeGame_Person_I_2874"));
            CA!.Adj_uebel = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2875, "Adv_InitializeGame_Person_I_2875"));
            CA!.Adj_duftend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2876, "Adv_InitializeGame_Person_I_2876"));
            CA!.Adj_juwelenbesetzt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2877, "Adv_InitializeGame_Person_I_2877"));
            Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2877a, CA!.Adj_juwelenbesetzt!.ID, "Adv_InitializeGame_Person_I_2877a");
            Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2877b, CA!.Adj_juwelenbesetzt!.ID, "Adv_InitializeGame_Person_I_2877b");
            Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2877c, CA!.Adj_juwelenbesetzt!.ID, "Adv_InitializeGame_Person_I_2877c");


            CA!.Adj_emsig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2878, "Adv_InitializeGame_Person_I_2878"));
            CA!.Adj_weiss = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2879, "Adv_InitializeGame_Person_I_2879"));
            CA!.Adj_laenglich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2880, "Adv_InitializeGame_Person_I_2880"));
            CA!.Adj_teuer = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2881, "Adv_InitializeGame_Person_I_2881"));
            CA!.Adj_dunstig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2882, "Adv_InitializeGame_Person_I_2882"));
            CA!.Adj_rund = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2883, "Adv_InitializeGame_Person_I_2883"));
            CA!.Adj_versoffen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2884, "Adv_InitializeGame_Person_I_2884"));
            CA!.Adj_wacklig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2885, "Adv_InitializeGame_Person_I_2885"));
            CA!.Adj_geschmackvoll = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2886, "Adv_InitializeGame_Person_I_2886"));
            CA!.Adj_langgezogen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2887, "Adv_InitializeGame_Person_I_2887"));
            CA!.Adj_hoffnungslos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2888, "Adv_InitializeGame_Person_I_2888"));
            CA!.Adj_unbefestigt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2889, "Adv_InitializeGame_Person_I_2889"));
            CA!.Adj_altbacken = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2890, "Adv_InitializeGame_Person_I_2890"));
            CA!.Adj_angezeichnet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2891, "Adv_InitializeGame_Person_I_2891"));
            CA!.Adj_jaemmerlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2892, "Adv_InitializeGame_Person_I_2892"));
            CA!.Adj_farbenfroh = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2893, "Adv_InitializeGame_Person_I_2893"));
            CA!.Adj_seltsam = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2894, "Adv_InitializeGame_Person_I_2894"));
            CA!.Adj_auffaellig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2895, "Adv_InitializeGame_Person_I_2895"));
            CA!.Adj_ungewoehnlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2896, "Adv_InitializeGame_Person_I_2896"));
            CA!.Adj_ueberdimensioniert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2897, "Adv_InitializeGame_Person_I_2897"));
            CA!.Adj_befestigt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2898, "Adv_InitializeGame_Person_I_2898"));
            CA!.Adj_abgegrast = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2899, "Adv_InitializeGame_Person_I_2899"));
            CA!.Adj_ausgemergelt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2900, "Adv_InitializeGame_Person_I_2900"));
            CA!.Adj_guelden = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2901, "Adv_InitializeGame_Person_I_2901"));
            CA!.Adj_hochkaraetig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2902, "Adv_InitializeGame_Person_I_2902"));
            CA!.Adj_unheimlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2903, "Adv_InitializeGame_Person_I_2903"));
            CA!.Adj_bescheiden = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2904, "Adv_InitializeGame_Person_I_2904"));
            CA!.Adj_trunksuechtig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2905, "Adv_InitializeGame_Person_I_2905"));
            CA!.Adj_festgetrampelt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2906, "Adv_InitializeGame_Person_I_2906"));
            CA!.Adj_tanzend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2907, "Adv_InitializeGame_Person_I_2907"));
            CA!.Adj_exotisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2908, "Adv_InitializeGame_Person_I_2908"));
            CA!.Adj_erstaunlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2909, "Adv_InitializeGame_Person_I_2909"));
            CA!.Adj_funkelnd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2910, "Adv_InitializeGame_Person_I_2910"));
            CA!.Adj_zahllos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2911, "Adv_InitializeGame_Person_I_2911"));
            CA!.Adj_obskur = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2912, "Adv_InitializeGame_Person_I_2912"));
            CA!.Adj_geflochten = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2913, "Adv_InitializeGame_Person_I_2913"));
            CA!.Adj_vierspurig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2914, "Adv_InitializeGame_Person_I_2914"));
            CA!.Adj_monumental = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2915, "Adv_InitializeGame_Person_I_2915"));
            CA!.Adj_schneebedeckt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2916, "Adv_InitializeGame_Person_I_2916"));
            CA!.Adj_voll = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2917, "Adv_InitializeGame_Person_I_2917"));
            CA!.Adj_verwildert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2918, "Adv_InitializeGame_Person_I_2918"));
            CA!.Adj_gemauert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2919, "Adv_InitializeGame_Person_I_2919"));
            CA!.Adj_ueberschaubar = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2920, "Adv_InitializeGame_Person_I_2920"));
            CA!.Adj_kaufwuetig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2921, "Adv_InitializeGame_Person_I_2921"));
            CA!.Adj_strahlend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2922, "Adv_InitializeGame_Person_I_2922"));
            CA!.Adj_gleissend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2923, "Adv_InitializeGame_Person_I_2923"));
            CA!.Adj_mondaen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2924, "Adv_InitializeGame_Person_I_2924"));
            CA!.Adj_verhaermt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2925, "Adv_InitializeGame_Person_I_2925"));
            CA!.Adj_knoecheltief = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2926, "Adv_InitializeGame_Person_I_2926"));
            CA!.Adj_sumpfig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2927, "Adv_InitializeGame_Person_I_2927"));
            CA!.Adj_unstet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2928, "Adv_InitializeGame_Person_I_2928"));
            CA!.Adj_heruntergewirtschaftet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2929, "Adv_InitializeGame_Person_I_2929"));
            CA!.Adj_matschig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2930, "Adv_InitializeGame_Person_I_2930"));
            CA!.Adj_vertikal = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2931, "Adv_InitializeGame_Person_I_2931"));
            CA!.Adj_jung = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2932, "Adv_InitializeGame_Person_I_2932"));
            CA!.Adj_geschwaetzig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2933, "Adv_InitializeGame_Person_I_2933"));
            CA!.Adj_idyllisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2934, "Adv_InitializeGame_Person_I_2934"));
            CA!.Adj_reif = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2935, "Adv_InitializeGame_Person_I_2935"));
            CA!.Adj_ueberwuchert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2936, "Adv_InitializeGame_Person_I_2936"));
            CA!.Adj_hochgewachsen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2937, "Adv_InitializeGame_Person_I_2937"));
            CA!.Adj_altmodisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2938, "Adv_InitializeGame_Person_I_2938"));
            CA!.Adj_verkalkt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2939, "Adv_InitializeGame_Person_I_2939"));
            CA!.Adj_schmucklos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2940, "Adv_InitializeGame_Person_I_2940"));
            CA!.Adj_fromm = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2941, "Adv_InitializeGame_Person_I_2941"));
            CA!.Adj_eng = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2942, "Adv_InitializeGame_Person_I_2942"));
            CA!.Adj_langweilig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2943, "Adv_InitializeGame_Person_I_2943"));
            CA!.Adj_karg = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2944, "Adv_InitializeGame_Person_I_2944"));
            CA!.Adj_ueberfluessig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2945, "Adv_InitializeGame_Person_I_2945"));
            CA!.Adj_hell = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2946, "Adv_InitializeGame_Person_I_2946"));
            CA!.Adj_kaerglich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2947, "Adv_InitializeGame_Person_I_2947"));
            CA!.Adj_gepflegt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2948, "Adv_InitializeGame_Person_I_2948"));
            CA!.Adj_alkoholisiert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2949, "Adv_InitializeGame_Person_I_2949"));
            CA!.Adj_gluecklich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2950, "Adv_InitializeGame_Person_I_2950"));
            CA!.Adj_saftig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2951, "Adv_InitializeGame_Person_I_2951"));
            CA!.Adj_majestaetisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2952, "Adv_InitializeGame_Person_I_2952"));
            CA!.Adj_unertraeglich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2953, "Adv_InitializeGame_Person_I_2953"));
            CA!.Adj_gruselig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2954, "Adv_InitializeGame_Person_I_2954"));
            CA!.Adj_tonnenschwer = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2955, "Adv_InitializeGame_Person_I_2955"));
            CA!.Adj_futuristisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2956, "Adv_InitializeGame_Person_I_2956"));
            CA!.Adj_beleuchtet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2957, "Adv_InitializeGame_Person_I_2957"));
            CA!.Adj_verfuehrerisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2958, "Adv_InitializeGame_Person_I_2958"));
            CA!.Adj_guenstig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2959, "Adv_InitializeGame_Person_I_2959"));
            CA!.Adj_gekachelt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2960, "Adv_InitializeGame_Person_I_2960"));
            CA!.Adj_glattpoliert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2961, "Adv_InitializeGame_Person_I_2961"));
            CA!.Adj_hinterlistig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2962, "Adv_InitializeGame_Person_I_2962"));
            CA!.Adj_hoffnungsvoll = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2963, "Adv_InitializeGame_Person_I_2963"));
            CA!.Adj_leicht = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2964, "Adv_InitializeGame_Person_I_2964"));
            CA!.Adj_massiv = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2965, "Adv_InitializeGame_Person_I_2965"));
            CA!.Adj_luftig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2966, "Adv_InitializeGame_Person_I_2966"));
            CA!.Adj_knietief = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2967, "Adv_InitializeGame_Person_I_2967"));
            CA!.Adj_protzig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2968, "Adv_InitializeGame_Person_I_2968"));
            CA!.Adj_wohlhabend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2969, "Adv_InitializeGame_Person_I_2969"));
            CA!.Adj_nagelneu = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2970, "Adv_InitializeGame_Person_I_2970"));
            CA!.Adj_angrenzend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2971, "Adv_InitializeGame_Person_I_2971"));
            CA!.Adj_grossflaechig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2972, "Adv_InitializeGame_Person_I_2972"));
            CA!.Adj_drehbar = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2973, "Adv_InitializeGame_Person_I_2973"));
            CA!.Adj_hochmodern = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2974, "Adv_InitializeGame_Person_I_2974"));
            CA!.Adj_begehbar = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2975, "Adv_InitializeGame_Person_I_2975"));
            CA!.Adj_halbfertig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2976, "Adv_InitializeGame_Person_I_2976"));
            CA!.Adj_geraeumig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2977, "Adv_InitializeGame_Person_I_2977"));
            CA!.Adj_lose = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2978, "Adv_InitializeGame_Person_I_2978"));
            CA!.Adj_brennend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2979, "Adv_InitializeGame_Person_I_2979"));
            CA!.Adj_geschunden = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2980, "Adv_InitializeGame_Person_I_2980"));
            CA!.Adj_bruechig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2981, "Adv_InitializeGame_Person_I_2981"));
            CA!.Adj_elektrisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2982, "Adv_InitializeGame_Person_I_2982"));
            CA!.Adj_zuckend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2983, "Adv_InitializeGame_Person_I_2983"));
            CA!.Adj_satanisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2984, "Adv_InitializeGame_Person_I_2984"));
            CA!.Adj_duester = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2985, "Adv_InitializeGame_Person_I_2985"));
            CA!.Adj_rabenschwarz = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2986, "Adv_InitializeGame_Person_I_2986"));
            CA!.Adj_verderbt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2987, "Adv_InitializeGame_Person_I_2987"));
            CA!.Adj_wichtig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2988, "Adv_InitializeGame_Person_I_2988"));
            CA!.Adj_massenhaft = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2989, "Adv_InitializeGame_Person_I_2989"));
            CA!.Adj_schwimmend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2990, "Adv_InitializeGame_Person_I_2990"));
            CA!.Adj_verkohlt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2991, "Adv_InitializeGame_Person_I_2991"));
            CA!.Adj_teuflisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2992, "Adv_InitializeGame_Person_I_2992"));
            CA!.Adj_knochenbesetzt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2993, "Adv_InitializeGame_Person_I_2993"));
            CA!.Adj_lodernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2994, "Adv_InitializeGame_Person_I_2994"));
            CA!.Adj_schwebend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2995, "Adv_InitializeGame_Person_I_2995"));
            CA!.Adj_knallrot = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2996, "Adv_InitializeGame_Person_I_2996"));
            CA!.Adj_kohlrabenschwarz = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2997, "Adv_InitializeGame_Person_I_2997"));
            CA!.Adj_glaesern = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2998, "Adv_InitializeGame_Person_I_2998"));
            CA!.Adj_beschmiert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_2999, "Adv_InitializeGame_Person_I_2999"));
            CA!.Adj_dampfend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3000, "Adv_InitializeGame_Person_I_3000"));
            CA!.Adj_schimmelnd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3001, "Adv_InitializeGame_Person_I_3001"));
            CA!.Adj_verwerflich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3002, "Adv_InitializeGame_Person_I_3002"));
            CA!.Adj_daemonisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3003, "Adv_InitializeGame_Person_I_3003"));
            CA!.Adj_herabhaengend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3004, "Adv_InitializeGame_Person_I_3004"));
            CA!.Adj_ueberquellend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3005, "Adv_InitializeGame_Person_I_3005"));
            CA!.Adj_obszoen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3006, "Adv_InitializeGame_Person_I_3006"));
            CA!.Adj_ansehnlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3007, "Adv_InitializeGame_Person_I_3007"));
            CA!.Adj_trostlos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3008, "Adv_InitializeGame_Person_I_3008"));
            CA!.Adj_knochenfarben = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3009, "Adv_InitializeGame_Person_I_3009"));
            CA!.Adj_okkult = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3010, "Adv_InitializeGame_Person_I_3010"));
            CA!.Adj_angekokelt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3011, "Adv_InitializeGame_Person_I_3011"));
            CA!.Adj_steinig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3012, "Adv_InitializeGame_Person_I_3012"));
            CA!.Adj_verrucht = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3013, "Adv_InitializeGame_Person_I_3013"));
            CA!.Adj_bleich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3014, "Adv_InitializeGame_Person_I_3014"));
            CA!.Adj_suendig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3015, "Adv_InitializeGame_Person_I_3015"));
            CA!.Adj_gelb = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3016, "Adv_InitializeGame_Person_I_3016"));
            CA!.Adj_lila = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3017, "Adv_InitializeGame_Person_I_3017"));
            CA!.Adj_weinrot = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3018, "Adv_InitializeGame_Person_I_3018"));
            CA!.Adj_prall = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3019, "Adv_InitializeGame_Person_I_3019"));
            CA!.Adj_erlesen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3020, "Adv_InitializeGame_Person_I_3020"));
            CA!.Adj_zertrampelt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3021, "Adv_InitializeGame_Person_I_3021"));
            CA!.Adj_traumatisiert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3022, "Adv_InitializeGame_Person_I_3022"));
            CA!.Adj_locker = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3023, "Adv_InitializeGame_Person_I_3023"));
            CA!.Adj_baumelnd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3024, "Adv_InitializeGame_Person_I_3024"));
            CA!.Adj_wild = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3025, "Adv_InitializeGame_Person_I_3025"));
            CA!.Adj_feiernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3026, "Adv_InitializeGame_Person_I_3026"));
            CA!.Adj_unreif = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3027, "Adv_InitializeGame_Person_I_3027"));
            CA!.Adj_orange = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3028, "Adv_InitializeGame_Person_I_3028"));
            CA!.Adj_extrastark = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3029, "Adv_InitializeGame_Person_I_3029"));
            CA!.Adj_angekettet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3030, "Adv_InitializeGame_Person_I_3030"));
            CA!.Adj_glimmend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3031, "Adv_InitializeGame_Person_I_3031"));
            CA!.Adj_froehlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3032, "Adv_InitializeGame_Person_I_3032"));
            CA!.Adj_geladen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3033, "Adv_InitializeGame_Person_I_3033"));
            CA!.Adj_verrottet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3034, "Adv_InitializeGame_Person_I_3034"));
            CA!.Adj_kuemmerlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3035, "Adv_InitializeGame_Person_I_3035"));
            CA!.Adj_blutrot = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3036, "Adv_InitializeGame_Person_I_3036"));
            CA!.Adj_knoechern = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3037, "Adv_InitializeGame_Person_I_3037"));
            CA!.Adj_guetig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3038, "Adv_InitializeGame_Person_I_3038"));
            CA!.Adj_anerkennend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3039, "Adv_InitializeGame_Person_I_3039"));
            CA!.Adj_beilaeufig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3040, "Adv_InitializeGame_Person_I_3040"));
            CA!.Adj_empoert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3041, "Adv_InitializeGame_Person_I_3041"));
            CA!.Adj_ergriffen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3042, "Adv_InitializeGame_Person_I_3042"));
            CA!.Adj_hinterhaeltig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3043, "Adv_InitializeGame_Person_I_3043"));
            CA!.Adj_lauernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3044, "Adv_InitializeGame_Person_I_3044"));
            CA!.Adj_mitleidig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3045, "Adv_InitializeGame_Person_I_3045"));
            CA!.Adj_sabbernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3046, "Adv_InitializeGame_Person_I_3046"));
            CA!.Adj_suesslich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3047, "Adv_InitializeGame_Person_I_3047"));
            CA!.Adj_ungluecklich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3048, "Adv_InitializeGame_Person_I_3048"));
            CA!.Adj_misstrauisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3049, "Adv_InitializeGame_Person_I_3049"));
            CA!.Adj_verzweifelt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3050, "Adv_InitializeGame_Person_I_3050"));
            CA!.Adj_vorsichtig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3051, "Adv_InitializeGame_Person_I_3051"));
            CA!.Adj_geoeffnet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3052, "Adv_InitializeGame_Person_I_3052"));
            CA!.Adj_spriessend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3053, "Adv_InitializeGame_Person_I_3053"));
            CA!.Adj_eifernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3054, "Adv_InitializeGame_Person_I_3054"));
            CA!.Adj_entschlossen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3055, "Adv_InitializeGame_Person_I_3055"));
            CA!.Adj_entsetzt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3056, "Adv_InitializeGame_Person_I_3056"));
            CA!.Adj_enttaeuscht = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3057, "Adv_InitializeGame_Person_I_3057"));
            CA!.Adj_entzueckt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3058, "Adv_InitializeGame_Person_I_3058"));
            CA!.Adj_erregt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3059, "Adv_InitializeGame_Person_I_3059"));
            CA!.Adj_fassungslos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3060, "Adv_InitializeGame_Person_I_3060"));
            CA!.Adj_genervt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3061, "Adv_InitializeGame_Person_I_3061"));
            CA!.Adj_geruehrt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3062, "Adv_InitializeGame_Person_I_3062"));
            CA!.Adj_grossmuetig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3063, "Adv_InitializeGame_Person_I_3063"));
            CA!.Adj_grossspurig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3064, "Adv_InitializeGame_Person_I_3064"));
            CA!.Adj_kleinlaut = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3065, "Adv_InitializeGame_Person_I_3065"));
            CA!.Adj_nachdenklich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3066, "Adv_InitializeGame_Person_I_3066"));
            CA!.Adj_triumphierend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3067, "Adv_InitializeGame_Person_I_3067"));
            CA!.Adj_vorwurfsvoll = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3068, "Adv_InitializeGame_Person_I_3068"));

            CA!.Adj_aufgebracht = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3069, "Adv_InitializeGame_Person_I_3069"));
            CA!.Adj_bedeutungsschwer = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3070, "Adv_InitializeGame_Person_I_3070"));
            CA!.Adj_zerknirscht = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3071, "Adv_InitializeGame_Person_I_3071"));
            CA!.Adj_entnervt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3072, "Adv_InitializeGame_Person_I_3072"));
            CA!.Adj_erschrocken = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3073, "Adv_InitializeGame_Person_I_3073"));
            CA!.Adj_gelassen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3074, "Adv_InitializeGame_Person_I_3074"));
            CA!.Adj_gierig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3075, "Adv_InitializeGame_Person_I_3075"));
            CA!.Adj_gleichgueltig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3076, "Adv_InitializeGame_Person_I_3076"));
            CA!.Adj_hungrig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3077, "Adv_InitializeGame_Person_I_3077"));
            CA!.Adj_resigniert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3078, "Adv_InitializeGame_Person_I_3078"));
            CA!.Adj_ueberrascht = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3079, "Adv_InitializeGame_Person_I_3079"));
            CA!.Adj_verstaendnisvoll = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3080, "Adv_InitializeGame_Person_I_3080"));
            CA!.Adj_gewagt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3081, "Adv_InitializeGame_Person_I_3081"));
            CA!.Adj_verstoerend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3082, "Adv_InitializeGame_Person_I_3082"));
            CA!.Adj_verwegen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3083, "Adv_InitializeGame_Person_I_3083"));
            CA!.Adj_bizarr = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3084, "Adv_InitializeGame_Person_I_3084"));
            CA!.Adj_bedauernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3085, "Adv_InitializeGame_Person_I_3085"));
            CA!.Adj_beunruhigt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3086, "Adv_InitializeGame_Person_I_3086"));
            CA!.Adj_gelangweilt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3087, "Adv_InitializeGame_Person_I_3087"));
            CA!.Adj_herablassend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3088, "Adv_InitializeGame_Person_I_3088"));
            CA!.Adj_irritiert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3089, "Adv_InitializeGame_Person_I_3089"));
            CA!.Adj_listig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3090, "Adv_InitializeGame_Person_I_3090"));
            CA!.Adj_nachdruecklich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3091, "Adv_InitializeGame_Person_I_3091"));
            CA!.Adj_spoettisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3092, "Adv_InitializeGame_Person_I_3092"));
            CA!.Adj_stur = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3093, "Adv_InitializeGame_Person_I_3093"));
            CA!.Adj_verunsichert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3094, "Adv_InitializeGame_Person_I_3094"));
            CA!.Adj_divin = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3095, "Adv_InitializeGame_Person_I_3095"));
            CA!.Adj_niedlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3096, "Adv_InitializeGame_Person_I_3096"));
            CA!.Adj_abgedreht = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3097, "Adv_InitializeGame_Person_I_3097"));
            CA!.Adj_aufgeregt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3098, "Adv_InitializeGame_Person_I_3098"));
            CA!.Adj_erstaunt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3099, "Adv_InitializeGame_Person_I_3099"));
            CA!.Adj_hilfsbereit = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3100, "Adv_InitializeGame_Person_I_3100"));
            CA!.Adj_leichthin = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3101, "Adv_InitializeGame_Person_I_3101"));
            CA!.Adj_neugierig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3102, "Adv_InitializeGame_Person_I_3102"));
            CA!.Adj_sueffisant = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3103, "Adv_InitializeGame_Person_I_3103"));
            CA!.Adj_ungehalten = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3104, "Adv_InitializeGame_Person_I_3104"));
            CA!.Adj_verbittert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3105, "Adv_InitializeGame_Person_I_3105"));
            CA!.Adj_weinerlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3106, "Adv_InitializeGame_Person_I_3106"));
            CA!.Adj_bedrohlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3107, "Adv_InitializeGame_Person_I_3107"));
            CA!.Adj_belehrend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3108, "Adv_InitializeGame_Person_I_3108"));
            CA!.Adj_bewundernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3109, "Adv_InitializeGame_Person_I_3109"));
            CA!.Adj_erfreut = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3110, "Adv_InitializeGame_Person_I_3110"));
            CA!.Adj_grinsend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3111, "Adv_InitializeGame_Person_I_3111"));
            CA!.Adj_gruebelnd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3112, "Adv_InitializeGame_Person_I_3112"));
            CA!.Adj_hypnotisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3113, "Adv_InitializeGame_Person_I_3113"));
            CA!.Adj_weihevoll = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3114, "Adv_InitializeGame_Person_I_3114"));
            CA!.Adj_aechzend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3115, "Adv_InitializeGame_Person_I_3115"));
            CA!.Adj_beglueckt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3116, "Adv_InitializeGame_Person_I_3116"));
            CA!.Adj_blechern = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3117, "Adv_InitializeGame_Person_I_3117"));
            CA!.Adj_verwundert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3118, "Adv_InitializeGame_Person_I_3118"));

            CA!.Adj_angewidert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3119, "Adv_InitializeGame_Person_I_3119"));
            CA!.Adj_anklagend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3120, "Adv_InitializeGame_Person_I_3120"));
            CA!.Adj_betroffen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3121, "Adv_InitializeGame_Person_I_3121"));
            CA!.Adj_diplomatisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3122, "Adv_InitializeGame_Person_I_3122"));
            CA!.Adj_ehrlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3123, "Adv_InitializeGame_Person_I_3123"));
            CA!.Adj_feierlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3124, "Adv_InitializeGame_Person_I_3124"));
            CA!.Adj_giftig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3125, "Adv_InitializeGame_Person_I_3125"));
            CA!.Adj_hastig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3126, "Adv_InitializeGame_Person_I_3126"));
            CA!.Adj_schnaubend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3127, "Adv_InitializeGame_Person_I_3127"));
            CA!.Adj_selbstgefaellig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3128, "Adv_InitializeGame_Person_I_3128"));
            CA!.Adj_seufzend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3129, "Adv_InitializeGame_Person_I_3129"));
            CA!.Adj_superschlau = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3130, "Adv_InitializeGame_Person_I_3130"));
            CA!.Adj_verwirrt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3131, "Adv_InitializeGame_Person_I_3131"));
            CA!.Adj_zerstreut = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3132, "Adv_InitializeGame_Person_I_3132"));
            CA!.Adj_hoellisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3133, "Adv_InitializeGame_Person_I_3133"));
            CA!.Adj_toedlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3134, "Adv_InitializeGame_Person_I_3134"));
            CA!.Adj_begeistert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3135, "Adv_InitializeGame_Person_I_3135"));
            CA!.Adj_besorgt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3136, "Adv_InitializeGame_Person_I_3136"));
            CA!.Adj_betruebt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3137, "Adv_InitializeGame_Person_I_3137"));
            CA!.Adj_enthusiastisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3138, "Adv_InitializeGame_Person_I_3138"));
            CA!.Adj_skeptisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3139, "Adv_InitializeGame_Person_I_3139"));
            CA!.Adj_zweifelnd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3140, "Adv_InitializeGame_Person_I_3140"));
            CA!.Adj_leise = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3141, "Adv_InitializeGame_Person_I_3141"));
            CA!.Adj_klappernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3142, "Adv_InitializeGame_Person_I_3142"));
            CA!.Adj_boesartig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3143, "Adv_InitializeGame_Person_I_3143"));
            CA!.Adj_ablehnend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3144, "Adv_InitializeGame_Person_I_3144"));
            CA!.Adj_deprimiert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3145, "Adv_InitializeGame_Person_I_3145"));
            CA!.Adj_erschuettert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3146, "Adv_InitializeGame_Person_I_3146"));
            CA!.Adj_gaehnend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3147, "Adv_InitializeGame_Person_I_3147"));
            CA!.Adj_geheimnisvoll = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3148, "Adv_InitializeGame_Person_I_3148"));
            CA!.Adj_sinnierend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3149, "Adv_InitializeGame_Person_I_3149"));
            CA!.Adj_stoehnend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3150, "Adv_InitializeGame_Person_I_3150"));
            CA!.Adj_streng = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3151, "Adv_InitializeGame_Person_I_3151"));
            CA!.Adj_ueberschaeumend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3152, "Adv_InitializeGame_Person_I_3152"));
            CA!.Adj_verbluefft = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3153, "Adv_InitializeGame_Person_I_3153"));
            CA!.Adj_zusammenfassend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3154, "Adv_InitializeGame_Person_I_3154"));
            CA!.Adj_zuversichtlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3155, "Adv_InitializeGame_Person_I_3155"));

            CA!.Adj_abwehrend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3156, "Adv_InitializeGame_Person_I_3156"));
            CA!.Adj_beschwichtigend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3157, "Adv_InitializeGame_Person_I_3157"));
            CA!.Adj_energisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3158, "Adv_InitializeGame_Person_I_3158"));
            CA!.Adj_gequaelt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3159, "Adv_InitializeGame_Person_I_3159"));
            CA!.Adj_gestresst = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3160, "Adv_InitializeGame_Person_I_3160"));
            CA!.Adj_harsch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3161, "Adv_InitializeGame_Person_I_3161"));
            CA!.Adj_missbilligend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3162, "Adv_InitializeGame_Person_I_3162"));
            CA!.Adj_tapfer = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3163, "Adv_InitializeGame_Person_I_3163"));
            CA!.Adj_traurig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3164, "Adv_InitializeGame_Person_I_3164"));
            CA!.Adj_ungeduldig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3165, "Adv_InitializeGame_Person_I_3165"));
            CA!.Adj_verstaendnislos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3166, "Adv_InitializeGame_Person_I_3166"));
            CA!.Adj_zwinkernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3167, "Adv_InitializeGame_Person_I_3167"));

            CA!.Adj_flehend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3168, "Adv_InitializeGame_Person_I_3168"));
            CA!.Adj_gebrochen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3169, "Adv_InitializeGame_Person_I_3169"));
            CA!.Adj_leidend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3170, "Adv_InitializeGame_Person_I_3170"));
            CA!.Adj_zuvorkommend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3171, "Adv_InitializeGame_Person_I_3171"));
            CA!.Adj_euphorisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3172, "Adv_InitializeGame_Person_I_3172"));
            CA!.Adj_reserviert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3173, "Adv_InitializeGame_Person_I_3173"));
            CA!.Adj_verschlagen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3174, "Adv_InitializeGame_Person_I_3174"));
            CA!.Adj_mitfuehlend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3175, "Adv_InitializeGame_Person_I_3175"));
            CA!.Adj_selbstmitleidig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3176, "Adv_InitializeGame_Person_I_3176"));
            CA!.Adj_unbehaglich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3177, "Adv_InitializeGame_Person_I_3177"));
            CA!.Adj_entruestet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3178, "Adv_InitializeGame_Person_I_3178"));

            CA!.Adj_erschoepft = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3179, "Adv_InitializeGame_Person_I_3179"));
            CA!.Adj_grosszuegig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3180, "Adv_InitializeGame_Person_I_3180"));
            CA!.Adj_sehnsuchtsvoll = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3181, "Adv_InitializeGame_Person_I_3181"));
            CA!.Adj_selbstbewusst = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3182, "Adv_InitializeGame_Person_I_3182"));
            CA!.Adj_grummelnd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3183, "Adv_InitializeGame_Person_I_3183"));
            CA!.Adj_hektisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3184, "Adv_InitializeGame_Person_I_3184"));
            CA!.Adj_hoehnisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3185, "Adv_InitializeGame_Person_I_3185"));
            CA!.Adj_schaeumend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3186, "Adv_InitializeGame_Person_I_3186"));
            CA!.Adj_schnittig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3187, "Adv_InitializeGame_Person_I_3187"));
            CA!.Adj_untertaenig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3188, "Adv_InitializeGame_Person_I_3188"));

            CA!.Adj_blasiert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3189, "Adv_InitializeGame_Person_I_3189"));
            CA!.Adj_ehrfuerchtig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3190, "Adv_InitializeGame_Person_I_3190"));
            CA!.Adj_eitel = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3191, "Adv_InitializeGame_Person_I_3191"));
            CA!.Adj_nervoes = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3192, "Adv_InitializeGame_Person_I_3192"));
            CA!.Adj_schmunzelnd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3193, "Adv_InitializeGame_Person_I_3193"));
            CA!.Adj_schweissabwischend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3194, "Adv_InitializeGame_Person_I_3194"));
            CA!.Adj_veraergert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3195, "Adv_InitializeGame_Person_I_3195"));
            CA!.Adj_verzueckt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3196, "Adv_InitializeGame_Person_I_3196"));
            CA!.Adj_gertenschlank = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3197, "Adv_InitializeGame_Person_I_3197"));
            CA!.Adj_saeuselnd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3198, "Adv_InitializeGame_Person_I_3198"));
            CA!.Adj_ueberschnappend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3199, "Adv_InitializeGame_Person_I_3199"));
            CA!.Adj_wuetend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3200, "Adv_InitializeGame_Person_I_3200"));

            CA!.Adj_arglos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3201, "Adv_InitializeGame_Person_I_3201"));
            CA!.Adj_argwoehnisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3202, "Adv_InitializeGame_Person_I_3202"));
            CA!.Adj_atemlos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3203, "Adv_InitializeGame_Person_I_3203"));
            CA!.Adj_aufmunternd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3204, "Adv_InitializeGame_Person_I_3204"));
            CA!.Adj_entspannt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3205, "Adv_InitializeGame_Person_I_3205"));
            CA!.Adj_geschaeftig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3206, "Adv_InitializeGame_Person_I_3206"));
            CA!.Adj_herausfordernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3207, "Adv_InitializeGame_Person_I_3207"));
            CA!.Adj_hypnotisiert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3208, "Adv_InitializeGame_Person_I_3208"));
            CA!.Adj_hysterisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3209, "Adv_InitializeGame_Person_I_3209"));
            CA!.Adj_sauer = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3210, "Adv_InitializeGame_Person_I_3210"));
            CA!.Adj_scheinheilig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3211, "Adv_InitializeGame_Person_I_3211"));
            CA!.Adj_ueberzeugt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3212, "Adv_InitializeGame_Person_I_3212"));
            CA!.Adj_unglaeubig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3213, "Adv_InitializeGame_Person_I_3213"));
            CA!.Adj_versonnen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3214, "Adv_InitializeGame_Person_I_3214"));
            CA!.Adj_stachlig2 = Adjs!.Add(Adj.AdjLocaLoca( loca.Adj_stachlig2, "Adj_stachlig2"));

            CA!.Adj_alarmiert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3215, "Adv_InitializeGame_Person_I_3215"));
            CA!.Adj_beaengstigt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3216, "Adv_InitializeGame_Person_I_3216"));
            CA!.Adj_bestuerzt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3217, "Adv_InitializeGame_Person_I_3217"));
            CA!.Adj_erbost = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3218, "Adv_InitializeGame_Person_I_3218"));
            CA!.Adj_heiser = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3219, "Adv_InitializeGame_Person_I_3219"));
            CA!.Adj_schnappatmend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3220, "Adv_InitializeGame_Person_I_3220"));
            CA!.Adj_seelenruhig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3221, "Adv_InitializeGame_Person_I_3221"));
            CA!.Adj_schnaufend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3222, "Adv_InitializeGame_Person_I_3222"));
            CA!.Adj_tadelnd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3223, "Adv_InitializeGame_Person_I_3223"));

            CA!.Adj_brutal = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3224, "Adv_InitializeGame_Person_I_3224"));
            CA!.Adj_ermunternd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3225, "Adv_InitializeGame_Person_I_3225"));
            CA!.Adj_freudig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3226, "Adv_InitializeGame_Person_I_3226"));
            CA!.Adj_gackernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3227, "Adv_InitializeGame_Person_I_3227"));
            CA!.Adj_geschlagen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3228, "Adv_InitializeGame_Person_I_3228"));
            CA!.Adj_ruhig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3229, "Adv_InitializeGame_Person_I_3229"));
            CA!.Adj_unbeeindruckt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3230, "Adv_InitializeGame_Person_I_3230"));
            CA!.Adj_unsicher = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3231, "Adv_InitializeGame_Person_I_3231"));
            CA!.Adj_verlegen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3232, "Adv_InitializeGame_Person_I_3232"));
            CA!.Adj_verschaemt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3233, "Adv_InitializeGame_Person_I_3233"));
            CA!.Adj_gehaessig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3234, "Adv_InitializeGame_Person_I_3234"));

            CA!.Adj_abwesend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3235, "Adv_InitializeGame_Person_I_3235"));
            CA!.Adj_luftschnappend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3236, "Adv_InitializeGame_Person_I_3236"));
            CA!.Adj_panisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3237, "Adv_InitializeGame_Person_I_3237"));
            CA!.Adj_verdriesslich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3238, "Adv_InitializeGame_Person_I_3238"));

            CA!.Adj_augenzwinkernd = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3239, "Adv_InitializeGame_Person_I_3239"));
            CA!.Adj_befremdet = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3240, "Adv_InitializeGame_Person_I_3240"));
            CA!.Adj_jovial = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3241, "Adv_InitializeGame_Person_I_3241"));
            CA!.Adj_schluchzend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3242, "Adv_InitializeGame_Person_I_3242"));
            CA!.Adj_schwaermerisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3243, "Adv_InitializeGame_Person_I_3243"));
            CA!.Adj_zoegerlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3244, "Adv_InitializeGame_Person_I_3244"));

            CA!.Adj_eisig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3245, "Adv_InitializeGame_Person_I_3245"));
            CA!.Adj_gereizt = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3246, "Adv_InitializeGame_Person_I_3246"));

            CA!.Adj_erroetend = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3247, "Adv_InitializeGame_Person_I_3247"));
            CA!.Adj_verschnupft = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3248, "Adv_InitializeGame_Person_I_3248"));

            CA!.Adj_stoned = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3249, "Adv_InitializeGame_Person_I_3249"));
            CA!.Adj_zackig = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3250, "Adv_InitializeGame_Person_I_3250"));
            CA!.Adj_westlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3251, "Adv_InitializeGame_Person_I_3251"));
            CA!.Adj_oestlich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3252, "Adv_InitializeGame_Person_I_3252"));
            CA!.Adj_heruntergelassen = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3253, "Adv_InitializeGame_Person_I_3253"));
            CA!.Adj_elegant = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3254, "Adv_InitializeGame_Person_I_3254"));
            CA!.Adj_pathetisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3255, "Adv_InitializeGame_Person_I_3255"));
            CA!.Adj_samten = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3256, "Adv_InitializeGame_Person_I_3256"));

            CA!.Adj_notorisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3257, "Adv_InitializeGame_Person_I_3257"));
            CA!.Adj_fern = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3258, "Adv_InitializeGame_Person_I_3258"));
            CA!.Adj_erhaben = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3259, "Adv_InitializeGame_Person_I_3259"));

            CA!.Adj_blaesslich = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3260, "Adv_InitializeGame_Person_I_3260"));
            CA!.Adj_gewienert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3261, "Adv_InitializeGame_Person_I_3261"));
            CA!.Adj_gesaeubert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adv_InitializeGame_Person_I_3262, "Adv_InitializeGame_Person_I_3262"));
            CA!.Adj_eisern = Adjs!.Add(Adj.AdjLocaLoca( loca.Adj_eisern, "Adj_eisern"));

            CA!.Adj_bio = Adjs!.Add(Adj.AdjLocaLoca( loca.Adj_bio, "Adj_bio"));
            CA!.Adj_super = Adjs!.Add(Adj.AdjLocaLoca( loca.Adj_super, "Adj_super"));
            CA!.Adj_bedeutungslos = Adjs!.Add(Adj.AdjLocaLoca( loca.Adj_bedeutungslos, "Adj_bedeutungslos"));
            CA!.Adj_panoramisch = Adjs!.Add(Adj.AdjLocaLoca( loca.Adj_panoramisch, "Adj_panoramisch"));
            CA!.Adj_neu = Adjs!.Add(Adj.AdjLocaLoca( loca.Adj_neu, "Adj_neu"));

            CA!.Adj_extra = Adjs!.Add(Adj.AdjLocaLoca( loca.Adj_extra, "Adj_extra"));
            CA!.Adj_registriert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adj_registriert, "Adj_registriert"));
            CA!.Adj_ruiniert = Adjs!.Add(Adj.AdjLocaLoca( loca.Adj_ruiniert, "Adj_ruiniert"));
            CA!.Adj_magic = Adjs!.Add(Adj.AdjLocaLoca( loca.Adj_magic, "Adj_magic"));
            CA!.Adj_organic = Adjs!.Add(Adj.AdjLocaLoca( loca.Adj_organic, "Adj_organic"));

            Adjs!.TList = new Dictionary<string, Adj>(Adjs.GetAdjBuffer()!, StringComparer.CurrentCultureIgnoreCase);

        }

        void InitNouns( int size = -1)
        {
            if (size != -1)
            {
                Nouns!.TList = new Dictionary<string, Noun>(size, StringComparer.CurrentCultureIgnoreCase);

            }

            // Neue Nouns
            CA!.Noun_Krempel = Nouns!.Add(Noun.NounLoca("Noun_Krempel"));

            CA!.Noun_Spuren = Nouns!.Add(Noun.NounLoca("Noun_Spuren"));
            CA!.Noun_Abdeckung = Nouns!.Add(Noun.NounLoca("Noun_Abdeckung"));
            CA!.Noun_Deckel = Nouns!.Add(Noun.NounLoca("Noun_Deckel"));
            CA!.Noun_Verbandskasten = Nouns!.Add(Noun.NounLoca("Noun_Verbandskasten"));
            CA!.Noun_Plastik = Nouns!.Add(Noun.NounLoca("Noun_Plastik"));
            CA!.Noun_Pilz = Nouns!.Add(Noun.NounLoca("Noun_Pilz"));
            CA!.Noun_Funghi = Nouns!.Add(Noun.NounLoca("Noun_Funghi"));
            CA!.Noun_Sporen = Nouns!.Add(Noun.NounLoca("Noun_Sporen"));
            CA!.Noun_Schwamm = Nouns!.Add(Noun.NounLoca("Noun_Schwamm"));

            CA!.Noun_Ritterruestung = Nouns!.Add(Noun.NounLoca("Noun_Ritterruestung"));
            CA!.Noun_Ritter = Nouns!.Add(Noun.NounLoca("Noun_Ritter"));
            CA!.Noun_Ruestung = Nouns!.Add(Noun.NounLoca("Noun_Ruestung"));
            CA!.Noun_Eule = Nouns!.Add(Noun.NounLoca("Noun_Eule"));
            CA!.Noun_Skelett = Nouns!.Add(Noun.NounLoca("Noun_Skelett"));
            CA!.Noun_Fish = Nouns!.Add(Noun.NounLoca("Noun_Fish"));
            CA!.Noun_Schlange = Nouns!.Add(Noun.NounLoca("Noun_Schlange"));
            CA!.Noun_Elster = Nouns!.Add(Noun.NounLoca("Noun_Elster"));
            CA!.Noun_Beutelchen = Nouns!.Add(Noun.NounLoca("Noun_Beutelchen"));
            CA!.Noun_Pulver = Nouns!.Add(Noun.NounLoca("Noun_Pulver"));
            CA!.Noun_Kerzenhalter = Nouns!.Add(Noun.NounLoca("Noun_Kerzenhalter"));
            CA!.Noun_Klaue = Nouns!.Add(Noun.NounLoca("Noun_Klaue"));
            CA!.Noun_Zuckerzange = Nouns!.Add(Noun.NounLoca("Noun_Zuckerzange"));
            CA!.Noun_Rollpflaster = Nouns!.Add(Noun.NounLoca("Noun_Rollpfaster"));
            CA!.Noun_Klauenzange = Nouns!.Add(Noun.NounLoca("Noun_Klauenzange"));

            CA!.Noun_Lupe = Nouns!.Add(Noun.NounLoca("Noun_Lupe"));
            CA!.Noun_Quietscheentchen = Nouns!.Add(Noun.NounLoca("Noun_Quietscheentchen"));
            CA!.Noun_Kaese = Nouns!.Add(Noun.NounLoca("Noun_Kaese"));
            CA!.Noun_Mondstein = Nouns!.Add(Noun.NounLoca("Noun_Mondstein"));
            CA!.Noun_Mond = Nouns!.Add(Noun.NounLoca("Noun_Mond"));
            CA!.Noun_Plastikbeutel = Nouns!.Add(Noun.NounLoca("Noun_Plastikbeutel"));
            CA!.Noun_Plastiktuete = Nouns!.Add(Noun.NounLoca("Noun_Plastiktuete"));
            CA!.Noun_Wunderwarzenschwamm = Nouns!.Add(Noun.NounLoca("Noun_Wunderwarzenschwamm"));
            CA!.Noun_Schlacke = Nouns!.Add(Noun.NounLoca("Noun_Schlacke"));
            CA!.Noun_Muenze = Nouns!.Add(Noun.NounLoca("Noun_Muenze"));
            CA!.Noun_Nebel = Nouns!.Add(Noun.NounLoca("Noun_Nebel"));
            CA!.Noun_Pentagramm = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Fussmatte = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Oeffnung = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Siegel = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Waescheleine = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Unterhose = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Unterwaesche = Nouns!.Add(Noun.NounLoca("Noun_Unterwaesche"));
            CA!.Noun_Holzabdeckung = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Waschmaschine = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Waescheaufhaengmaschine = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Waeschekorb = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Karton = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Labortisch = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Kaefige = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Erstehilfekasten = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Metallschale = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Halterung = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Dunkelheitsmaschine = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Holzabdeckung = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Vogelstaender = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Matratze = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Kuehlschrank = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Gefrierfach = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Kachel = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Badewanne = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Spuelung = Nouns!.Add(Noun.NounLoca("Noun_Pentagramm"));
            CA!.Noun_Kerze = Nouns!.Add(Noun.NounLoca("Noun_Kerze"));
            CA!.Noun_Matte= Nouns!.Add(Noun.NounLoca("Noun_Matte"));
            CA!.Noun_Halter = Nouns!.Add(Noun.NounLoca("Noun_Halter"));
            CA!.Noun_Beutel = Nouns!.Add(Noun.NounLoca("Noun_Beutel"));
            CA!.Noun_Buchstaben = Nouns!.Add(Noun.NounLoca("Noun_Buchstaben"));
            CA!.Noun_Rolle = Nouns!.Add(Noun.NounLoca("Noun_Rolle"));

            CA!.Noun_Rune = Nouns.Add(Noun.NounLoca("Noun_Rune"));
            CA!.Noun_Warnschild = Nouns.Add(Noun.NounLoca("Noun_Warnschild"));
            CA!.Noun_Wasch = Nouns.Add(Noun.NounLoca("Noun_Wasch"));
            CA!.Noun_Gefrier = Nouns.Add(Noun.NounLoca("Noun_Gefrier"));
            CA!.Noun_Froster = Nouns.Add(Noun.NounLoca("Noun_Froster"));
            CA!.Noun_Ente = Nouns.Add(Noun.NounLoca("Noun_Ente"));
            CA!.Noun_Entchen = Nouns.Add(Noun.NounLoca("Noun_Entchen"));
            CA!.Noun_Gummiente = Nouns.Add(Noun.NounLoca("Noun_Gummiente"));
            CA!.Noun_Flamme = Nouns.Add(Noun.NounLoca("Noun_Flamme"));
            CA!.Noun_Juwel = Nouns!.Add(Noun.NounLoca("Noun_Juwel"));
            CA!.Noun_Edelstein = Nouns!.Add(Noun.NounLoca("Noun_Edelstein"));
            CA!.Noun_Versteck = Nouns!.Add(Noun.NounLoca("Noun_Versteck"));
            CA!.Noun_Fliese = Nouns!.Add(Noun.NounLoca( "Noun_Fliese"));
            CA!.Noun_Fliesen = Nouns!.Add(Noun.NounLoca( "Noun_Fliesen"));



            CA!.Noun_Seil = Nouns!.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3263"));
            CA!.Noun_Revolver = Nouns!.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3264"));
            Nouns.AddLoca(CA!.Noun_Revolver!.ID, "Adv_InitializeGame_Person_I_3265");
            Nouns.AddLoca(CA!.Noun_Revolver!.ID, "Adv_InitializeGame_Person_I_3266");
            Nouns.AddLoca(CA!.Noun_Revolver!.ID, "Adv_InitializeGame_Person_I_3267");
            Nouns.AddLoca(CA!.Noun_Revolver!.ID, "Adv_InitializeGame_Person_I_3268");
            CA!.Noun_Kram = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3269"));
            CA!.Noun_Kissen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3270"));
            CA!.Noun_Sonderangebote = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3271"));
            CA!.Noun_Sonderangebot = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3272"));
            CA!.Noun_Angebot = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3273"));
            CA!.Noun_Kiste = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3274"));
            CA!.Noun_Schluessel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3275"));
            CA!.Noun_Schachtel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3276"));
            CA!.Noun_Baumstumpf = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3277"));
            CA!.Noun_Helfie = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3278"));
            CA!.Noun_Helfer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3279"));
            CA!.Noun_Robi = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3280"));
            CA!.Noun_Robot = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3281"));
            CA!.Noun_Truhe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3282"));
            CA!.Noun_Schatztruhe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3283"));
            CA!.Noun_Weltfrieden = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3284"));
            CA!.Noun_Krieg = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3285"));
            CA!.Noun_Tasche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3286"));
            CA!.Noun_Dome = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Dome"));

            


            CA!.Noun_Pocket = Nouns.Add(Noun.NounLoca("Noun_Pocket"));
            CA!.Noun_Dealer = Nouns.Add(Noun.NounLoca("Noun_Dealer"));
            CA!.Noun_Trader = Nouns.Add(Noun.NounLoca("Noun_Trader"));
            CA!.Noun_Hamberder = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3287"));
            CA!.Noun_Hamburger = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3288"));
            CA!.Noun_Burger = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3289"));
            CA!.Noun_Golfball = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3290"));
            CA!.Noun_Buch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3291"));
            CA!.Noun_Zeitungsausschnitt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3292"));
            CA!.Noun_Basecap = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3293"));
            Nouns!.AddLoca(CA!.Noun_Basecap!.ID, "Adv_InitializeGame_Person_I_3294");
            Nouns!.AddLoca(CA!.Noun_Basecap!.ID, "Adv_InitializeGame_Person_I_3295");
            Nouns!.AddLoca(CA!.Noun_Basecap!.ID, "Adv_InitializeGame_Person_I_3296");
            CA!.Noun_Vorhaenge = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3297"));
            CA!.Noun_Vorhang = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3298"));
            CA!.Noun_Moebel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3299"));
            CA!.Noun_Porzellan = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3300"));
            CA!.Noun_Fenster = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3301"));
            CA!.Noun_Eingangstuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3302"));
            CA!.Noun_Treppe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3303"));
            CA!.Noun_Kellertreppe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3304"));
            CA!.Noun_Gelaender = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3305"));
            CA!.Noun_Spiegel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3306"));
            CA!.Noun_Zauberspiegel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3307"));
            CA!.Noun_Zeitung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3308"));
            CA!.Noun_Papier = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3309"));
            CA!.Noun_Ausschnitt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3310"));
            CA!.Noun_Regal = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3311"));
            CA!.Noun_Manual = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3312"));
            Nouns.AddLoca(CA!.Noun_Manual!.ID, "Adv_InitializeGame_Person_I_3313");
            CA!.Noun_Sand = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3314"));
            CA!.Noun_Muscheln = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3315"));
            CA!.Noun_Tuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3316"));
            CA!.Noun_Sandkoerner = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3317"));
            CA!.Noun_Sven = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3318"));
            CA!.Noun_Irrer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3319"));
            CA!.Noun_Draht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3320"));
            CA!.Noun_Meer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3321"));
            CA!.Noun_Fahrstuhl = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3322"));
            CA!.Noun_Palme = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3323"));
            CA!.Noun_Schild = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3324"));
            CA!.Noun_Wald = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3325"));
            CA!.Noun_Muscheln = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3326"));
            CA!.Noun_Kieselstrand = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3327"));
            CA!.Noun_Kiesel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3328"));
            CA!.Noun_Strand = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3329"));
            CA!.Noun_Busch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3330"));
            CA!.Noun_Decke = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3331"));
            CA!.Noun_Wand = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3332"));
            CA!.Noun_Kaninchenhoehle = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3333"));
            CA!.Noun_Kaninchenhoehle = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3334"));
            CA!.Noun_Kaninchenhoehle = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3335"));
            CA!.Noun_Waldgras = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3336"));
            CA!.Noun_Zweige = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3337"));
            CA!.Noun_Zweig = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3338"));
            CA!.Noun_Messer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3339"));
            CA!.Noun_Gebuesch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3340"));
            CA!.Noun_Papagei = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3341"));
            CA!.Noun_Stock = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3342"));
            CA!.Noun_Erdhuegel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3343"));
            CA!.Noun_Ast = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3344"));
            CA!.Noun_Ameisenhaufen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3345"));
            CA!.Noun_Brombeerstraeucher = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3346"));
            CA!.Noun_Brombeerstraeucher = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3347"));
            CA!.Noun_Straeucher = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3348"));
            CA!.Noun_Strauch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3349"));
            CA!.Noun_Verschlag = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3350"));
            CA!.Noun_Huette = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3351"));
            CA!.Noun_Eremit = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3352"));
            CA!.Noun_Eimerchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3353"));
            CA!.Noun_Keller = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3354"));
            CA!.Noun_Seildraht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3355"));
            CA!.Noun_Kobra = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3356"));
            CA!.Noun_Haselstrauch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3357"));
            CA!.Noun_Gras = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3358"));
            CA!.Noun_Astseil = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3359"));
            CA!.Noun_Fishing = Nouns.Add(Noun.NounLoca("Noun_Fishing"));
            CA!.Noun_Angel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3360"));
            CA!.Noun_Gewandtasche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3361"));
            CA!.Noun_Boden = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3362"));
            CA!.Noun_Bodendielen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3363"));
            CA!.Noun_Cracker = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3364"));
            CA!.Noun_Crackers = Nouns.Add(Noun.NounLoca("Noun_Crackers"));
            CA!.Noun_Crackerschachtel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3365"));
            CA!.Noun_Dielen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3366"));
            CA!.Noun_Grillzange = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3367"));
            CA!.Noun_Herd = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3368"));
            CA!.Noun_Kaefig = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3369"));
            CA!.Noun_Keks = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3370"));
            CA!.Noun_Lampe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3371"));
            CA!.Noun_Laterne = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3372"));
            CA!.Noun_Ritz = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3373"));
            CA!.Noun_Schachtel_mit_Crackern = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3374"));
            CA!.Noun_Akten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3375"));
            CA!.Noun_Schrank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3376"));
            CA!.Noun_Kuechenschrank = Nouns.Add(Noun.NounLoca("Noun_Kuechenschrank"));
            CA!.Noun_Zelle = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3377"));
            CA!.Noun_Streichholzbriefchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3378"));
            CA!.Noun_Streichhoelzer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3379"));
            CA!.Noun_Vogelbauer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3380"));
            CA!.Noun_Cage = Nouns.Add(Noun.NounLoca("Noun_Cage"));
            CA!.Noun_Zange = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3381"));
            CA!.Noun_Vogelkaefig = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3382"));
            CA!.Noun_Astgabel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3383"));
            CA!.Noun_Eiche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3384"));
            CA!.Noun_Fluestertuete = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3385"));
            CA!.Noun_Megafon = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3386"));
            CA!.Noun_Bett = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3387"));
            CA!.Noun_Himmelbett = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3388"));
            CA!.Noun_Sitzgarnitur = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3389"));
            CA!.Noun_Schatzkiste = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3390"));
            CA!.Noun_Geruempel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3391"));
            Nouns.AddLoca(CA!.Noun_Geruempel!.ID, "Adv_InitializeGame_Person_I_3392");
            CA!.Noun_Tisch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3393"));
            CA!.Noun_Stuhl = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3394"));
            CA!.Noun_Baeume = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3395"));
            CA!.Noun_Baum = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3396"));
            CA!.Noun_Bucht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3397"));
            CA!.Noun_Felsen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3398"));
            CA!.Noun_Fels = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3399"));
            CA!.Noun_Frank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3400"));
            CA!.Noun_Cannon = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3401"));
            CA!.Noun_Brombeeren = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3402"));
            CA!.Noun_Truemmer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3403"));
            CA!.Noun_Rad = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3404"));
            CA!.Noun_Kutsche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3405"));
            CA!.Noun_Korn = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3406"));
            CA!.Noun_Achse = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3407"));
            CA!.Noun_Eimer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3408"));
            CA!.Noun_Pfad = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3409"));
            CA!.Noun_Buschwerk = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3410"));
            CA!.Noun_Oberflaeche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3411"));
            CA!.Noun_Kokosnuesse = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3412"));
            CA!.Noun_Kokosnuss = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3413"));
            CA!.Noun_Nuesse = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3414"));
            CA!.Noun_Nuss = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3415"));
            CA!.Noun_Licht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3416"));
            CA!.Noun_Schimmer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3417"));
            CA!.Noun_Lichtschimmer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3418"));
            CA!.Noun_Stufe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3419"));
            CA!.Noun_Stufen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3420"));
            CA!.Noun_Ameise = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3421"));
            CA!.Noun_Ameisen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3422"));
            CA!.Noun_Waldameise = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3423"));
            CA!.Noun_Waldameisen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3424"));
            CA!.Noun_Senke = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3425"));
            CA!.Noun_Lagerverwalter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3426"));
            CA!.Noun_Verwalter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3427"));
            CA!.Noun_Lagerist = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3428"));
            CA!.Noun_Kapitaen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3429"));
            CA!.Noun_Ahab = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3430"));
            CA!.Noun_Schankwirtin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3431"));
            CA!.Noun_Wirtin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3432"));
            CA!.Noun_Kneipenwirtin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3433"));
            CA!.Noun_Luegian = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3434"));
            CA!.Noun_Speichelt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3435"));
            CA!.Noun_Marineoffizier = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3436"));
            CA!.Noun_Offizier = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3437"));
            CA!.Noun_Redakteur = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3438"));
            CA!.Noun_Luegner = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3439"));
            CA!.Noun_Verleumder = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3440"));
            CA!.Noun_Pit = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3441"));
            CA!.Noun_Paula = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3442"));
            CA!.Noun_Paracelsus = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3443"));
            CA!.Noun_Arzt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3444"));
            CA!.Noun_Aerztin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3445"));
            CA!.Noun_Harpune = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3446"));
            CA!.Noun_Pflaster = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3447"));
            CA!.Noun_Pflasterstein = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3448"));
            CA!.Noun_Tor = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3449"));
            CA!.Noun_Bar = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3450"));
            CA!.Noun_Hafenbar = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3451"));
            CA!.Noun_Hafenkaschemme = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3452"));
            CA!.Noun_Hafenkneipe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3453"));
            CA!.Noun_Hafenpinte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3454"));
            CA!.Noun_Kaschemme = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3455"));
            CA!.Noun_Klohaeuschen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3456"));
            CA!.Noun_Klopapier = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3457"));
            CA!.Noun_Presseausweis = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3458"));
            CA!.Noun_Kneipe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3459"));
            CA!.Noun_Lagerhaus = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3460"));
            CA!.Noun_Lagerhaus_e = Nouns.Add(Noun.NounLoca("Noun_Lagerhaus_e"));
            CA!.Noun_Lagerhouse = Nouns.Add(Noun.NounLoca("Noun_Lagerhouse"));
            CA!.Noun_Pinte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3461"));
            CA!.Noun_Schiff = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3462"));
            CA!.Noun_Verlag = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3463"));
            CA!.Noun_Haken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3464"));
            CA!.Noun_Prospekt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3465"));
            CA!.Noun_Badge = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3466"));
            CA!.Noun_Dennis = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3467"));
            CA!.Noun_Handelsvertreter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3468"));
            CA!.Noun_Kuh = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3469"));
            CA!.Noun_Mechaniker = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3470"));
            CA!.Noun_Schraubenschluessel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3471"));
            CA!.Noun_Waltraud = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3472"));
            CA!.Noun_Woods = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3473"));
            CA!.Noun_Bank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3474"));
            CA!.Noun_Barhocker = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3475"));
            CA!.Noun_Druckmaschine = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3476"));
            CA!.Noun_Fensterbank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3477"));
            CA!.Noun_Hahn = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3478"));
            CA!.Noun_Hocker = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3479"));
            CA!.Noun_Manuskript = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3480"));
            CA!.Noun_Papierausgabe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3481"));
            CA!.Noun_Tresen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3482"));
            CA!.Noun_Wagenheber = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3483"));
            CA!.Noun_Zapfhahn = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3484"));
            CA!.Noun_Du = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3485"));
            Nouns.AddLoca(CA!.Noun_Du!.ID, "Adv_InitializeGame_Person_I_3486");
            CA!.Noun_Ich = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3487"));
            Nouns.AddLoca(CA!.Noun_Ich!.ID, "Adv_InitializeGame_Person_I_3488");
            CA!.Noun_Handschellen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3489"));
            CA!.Noun_Beamter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3490"));
            CA!.Noun_Postbeamter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3491"));
            CA!.Noun_Radfuehrung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3492"));
            CA!.Noun_Radaufhaengung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3493"));
            CA!.Noun_Pferd = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3494"));
            CA!.Noun_Formulare = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3495"));
            CA!.Noun_Formular = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3496"));
            CA!.Noun_Ross = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3497"));
            CA!.Noun_Schalter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3498"));
            CA!.Noun_Blumenkohl = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3499"));
            CA!.Noun_Blumenkohlgehirn = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3500"));
            CA!.Noun_Kohl = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3501"));
            CA!.Noun_Bogen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3502"));
            CA!.Noun_Brief = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3503"));
            CA!.Noun_Briefumschlag = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3504"));
            CA!.Noun_Brille = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3505"));
            CA!.Noun_Frame = Nouns.Add(Noun.NounLoca("Noun_Frame"));
            CA!.Noun_Cocktailglas = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3506"));
            CA!.Noun_Dose = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3507"));
            CA!.Noun_Dosen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3508"));
            CA!.Noun_Konserven = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3509"));
            CA!.Noun_Konserve = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3510"));
            CA!.Noun_Dosenoeffner = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3511"));
            CA!.Noun_Fleisch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3512"));
            CA!.Noun_Hack = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3513"));
            CA!.Noun_Foto = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3514"));
            CA!.Noun_Gebiss = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3515"));
            Nouns.AddLoca(CA!.Noun_Gebiss!.ID, "Adv_InitializeGame_Person_I_3515a");
            Nouns.AddLoca(CA!.Noun_Gebiss!.ID, "Adv_InitializeGame_Person_I_3515b");
            CA!.Noun_Vampirgebiss = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3516"));
            CA!.Noun_Gehirn = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3517"));
            CA!.Noun_Giesskanne = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3518"));
            CA!.Noun_Drink = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3519"));
            CA!.Noun_Giftflakon = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3520"));
            CA!.Noun_Kamera = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3521"));
            CA!.Noun_Kaleidoskop = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3522"));
            CA!.Noun_Schatz = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3523"));
            CA!.Noun_Pracht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Pracht"));
            CA!.Noun_Schlaftabletten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3524"));
            Nouns.AddLoca(CA!.Noun_Schlaftabletten!.ID, "Adv_InitializeGame_Person_I_3525");
            CA!.Noun_Spielgeld = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3526"));
            Nouns.AddLoca(CA!.Noun_Spielgeld!.ID, "Adv_InitializeGame_Person_I_3527");
            CA!.Noun_Spielgeldbogen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3528"));
            CA!.Noun_Stapel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3529"));
            CA!.Noun_Ziegel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3530"));
            CA!.Noun_Ziegelstein = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3531"));
            CA!.Noun_Schluesselbund = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3532"));
            CA!.Noun_Alfonsius_Statuette = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3533"));
            CA!.Noun_Briefe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3534"));
            CA!.Noun_Cocktail = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3535"));
            CA!.Noun_Corona = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Corona"));
            CA!.Noun_Dartscheibe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3536"));
            Nouns.AddLoca(CA!.Noun_Dartscheibe!.ID, "Adv_InitializeGame_Person_I_3537");
            CA!.Noun_Fass = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3538"));
            CA!.Noun_Fensterglas = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3539"));
            Nouns.AddLoca(CA!.Noun_Fensterglas!.ID, "Adv_InitializeGame_Person_I_3540");
            CA!.Noun_Fleischwanne = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3541"));
            CA!.Noun_Flugblaetter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3542"));
            CA!.Noun_Getraenk = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3543"));
            CA!.Noun_Gutachten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3544"));
            CA!.Noun_Hackfleisch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3545"));
            CA!.Noun_Hose = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3546"));
            CA!.Noun_Karren = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3547"));
            CA!.Noun_Kelle = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3548"));
            CA!.Noun_Laubsaege = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3549"));
            CA!.Noun_Lieferschein = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3550"));
            CA!.Noun_Abholschein = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3551"));
            CA!.Noun_Postkarte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3552"));
            CA!.Noun_Karte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3553"));
            CA!.Noun_Regenwuermer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3554"));
            CA!.Noun_Scherbe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3555"));
            CA!.Noun_Senffaesschen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3556"));
            CA!.Noun_Sinnspruch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3557"));
            CA!.Noun_Statuette = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3558"));
            CA!.Noun_Taucheranzughose = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3559"));
            CA!.Noun_Umruehrstab = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3560"));
            Nouns.AddLoca(CA!.Noun_Umruehrstab!.ID, "Adv_InitializeGame_Umruehrstab");
            CA!.Noun_stirring = Nouns.Add(Noun.NounLoca("Noun_stirring"));
            CA!.Noun_Zuckerpaeckchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3561"));
            CA!.Noun_Baconstreifen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3562"));
            CA!.Noun_Bettbezug = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3563"));
            CA!.Noun_Felsbrocken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3564"));
            CA!.Noun_Feudel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3565"));
            CA!.Noun_Rag = Nouns.Add(Noun.NounLoca("Adv_Rag"));
            CA!.Noun_Cloth = Nouns.Add(Noun.NounLoca("Noun_Cloth"));
            CA!.Noun_Feuerzeug = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3566"));
            CA!.Noun_Frischhaltefolie = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3567"));
            CA!.Noun_Gefaess = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3568"));
            CA!.Noun_Spachtelmasse = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3569"));
            CA!.Noun_Spachtel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3570"));
            CA!.Noun_Masse = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3571"));
            CA!.Noun_Glas = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3572"));
            Nouns.AddLoca(CA!.Noun_Glas!.ID, "Adv_InitializeGame_Person_I_3573");
            CA!.Noun_Brillenglas = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3574"));
            CA!.Noun_Hanfseil = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3575"));
            CA!.Noun_Hightech_Fessel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3576"));
            CA!.Noun_Hightech = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3577"));
            CA!.Noun_Fessel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3578"));
            CA!.Noun_Holzstueck = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3579"));
            CA!.Noun_Kanister = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3580"));
            CA!.Noun_Verduennung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Verduennung"));
            CA!.Noun_Oel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3581"));
            CA!.Noun_Lotterielos = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3582"));
            CA!.Noun_Lotterie = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3583"));
            CA!.Noun_Megaphon = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3584"));
            CA!.Noun_Metallstueck = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3585"));
            CA!.Noun_Papierboegen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3586"));
            CA!.Noun_Patties = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3587"));
            CA!.Noun_Stimme = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3588"));
            CA!.Noun_Pattie = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3589"));
            CA!.Noun_Permanentmarker = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3590"));
            Nouns.AddLoca(CA!.Noun_Permanentmarker!.ID, "Adv_InitializeGame_Person_I_3591");
            CA!.Noun_Peruecke = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3592"));
            CA!.Noun_Phoney_Island_Gin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3593"));
            CA!.Noun_Ratte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3594"));
            CA!.Noun_Schaufelchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3595"));
            Nouns.AddLoca(CA!.Noun_Schaufelchen!.ID, "Adv_InitializeGame_Person_I_3596");
            CA!.Noun_Schaukelpferd = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3597"));
            CA!.Noun_Schlauch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3598"));
            CA!.Noun_Schuerze = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3599"));
            CA!.Noun_Sprengsatz = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3600"));
            CA!.Noun_Bombe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3601"));
            CA!.Noun_Stein = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3602"));
            CA!.Noun_Steinschleuder = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3603"));
            CA!.Noun_Visitenkarte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3604"));
            CA!.Noun_Zustellkarte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3605"));
            CA!.Noun_Bart = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3606"));
            CA!.Noun_Berder_Kadaver = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3607"));
            CA!.Noun_Bescheinigung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3608"));
            CA!.Noun_Blasebalg = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3609"));
            CA!.Noun_Botanikbuch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3610"));
            CA!.Noun_Botanikbuecher = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3611"));
            CA!.Noun_Buessergewand = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3612"));
            CA!.Noun_Einschreiben = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3613"));
            CA!.Noun_Eisenstange = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3614"));
            CA!.Noun_Kartoffelsack = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3615"));
            CA!.Noun_Kette = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3616"));
            CA!.Noun_Kneifzange = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3617"));
            CA!.Noun_Knurznurznuss = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3618"));
            CA!.Noun_Kondome = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3619"));
            CA!.Noun_Kondom = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3620"));
            CA!.Noun_Praeser = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3621"));
            CA!.Noun_Luemmeltuete = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3622"));
            CA!.Noun_Luemmeltueten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3623"));
            CA!.Noun_Leiche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3624"));
            CA!.Noun_Lippenstift_Nachricht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3625"));
            CA!.Noun_Mitteilung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3626"));
            CA!.Noun_Peitschen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3627"));
            CA!.Noun_Raupe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3628"));
            CA!.Noun_Sack = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3629"));
            CA!.Noun_Schaufel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3630"));
            CA!.Noun_Schlafmohn = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3631"));
            CA!.Noun_Schlommi = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3632"));
            CA!.Noun_Schloss = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3633"));
            CA!.Noun_Vorhaengeschloss = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3634"));
            CA!.Noun_Schraubenzieher = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3635"));
            CA!.Noun_Umschlag = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3636"));
            CA!.Noun_Zellenschluessel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3637"));
            CA!.Noun_Nullbehaelter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3638"));
            CA!.Noun_Francesco = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3639"));
            CA!.Noun_Ghoul = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3640"));
            Nouns.AddLoca(CA!.Noun_Ghoul!.ID, "Adv_InitializeGame_Person_I_3641");
            CA!.Noun_Phoney = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3642"));
            Nouns.AddLoca(CA!.Noun_Phoney!.ID, "Adv_InitializeGame_Person_I_3643");
            CA!.Noun_Scaramango = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3644"));
            CA!.Noun_Messias = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3645"));
            CA!.Noun_Stroh = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3646"));
            CA!.Noun_Lager = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3647"));
            CA!.Noun_Schlaflager = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3648"));
            CA!.Noun_Zellentuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3649"));
            CA!.Noun_Dolly = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3650"));
            CA!.Noun_Something = Nouns.Add(Noun.NounLoca("Noun_Something"));
            CA!.Noun_Gemaelde = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3651"));
            CA!.Noun_Kamin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3652"));
            CA!.Noun_Leuchter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3653"));
            CA!.Noun_Podest = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3654"));
            CA!.Noun_Sitzbank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3655"));
            CA!.Noun_Stealthy = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3656"));
            CA!.Noun_Steven = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3657"));
            CA!.Noun_Gestalt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3658"));
            CA!.Noun_Schemen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3659"));
            CA!.Noun_Teppich = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3660"));
            CA!.Noun_Rug = Nouns.Add(Noun.NounLoca("Noun_Rug"));
            CA!.Noun_Thron = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3661"));
            CA!.Noun_Zepter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3662"));
            CA!.Noun_Wache = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3663"));
            Nouns.AddLoca(CA!.Noun_Wache!.ID, "Adv_InitializeGame_Person_I_3664");
            CA!.Noun_Brueckenwache = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3665"));
            Nouns.AddLoca(CA!.Noun_Brueckenwache!.ID, "Adv_InitializeGame_Person_I_3666");
            CA!.Noun_Mauern = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3667"));
            CA!.Noun_Eisentuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3668"));
            CA!.Noun_Muelltonne = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3669"));
            CA!.Noun_Bettchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3670"));
            CA!.Noun_Steinbank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3671"));
            CA!.Noun_Felsbalkon = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3672"));
            CA!.Noun_Talkessel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3673"));
            CA!.Noun_Stadt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3674"));
            CA!.Noun_Versammlungsplatz = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3675"));
            CA!.Noun_Ketten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3676"));
            CA!.Noun_Krokodil = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3677"));
            CA!.Noun_Eichenbohlen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3678"));
            CA!.Noun_Zugbruecke = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3679"));
            CA!.Noun_Graben = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3680"));
            CA!.Noun_Blutlachen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3681"));
            CA!.Noun_Blutlache = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3682"));
            CA!.Noun_Lache = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3683"));
            CA!.Noun_Folterinstrumente = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3684"));
            CA!.Noun_Nager = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3685"));
            CA!.Noun_Streckbank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3686"));
            CA!.Noun_Waende = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3687"));
            CA!.Noun_Wendeltreppe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3688"));
            CA!.Noun_Brustwehr = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3689"));
            CA!.Noun_Brust = Nouns.Add(Noun.NounLoca("Noun_Brust"));
            CA!.Noun_Panoramablick = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3690"));
            CA!.Noun_Waelder = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3692"));
            CA!.Noun_Buecher = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3693"));
            CA!.Noun_Fluegeltuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3694"));
            CA!.Noun_Panoramabild = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3695"));
            CA!.Noun_Phiolen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3696"));
            CA!.Noun_Regale = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3697"));
            CA!.Noun_Schreibtisch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3698"));
            CA!.Noun_Schreibtische = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3699"));
            CA!.Noun_Sessel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3700"));
            CA!.Noun_Stuehlchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3701"));
            CA!.Noun_Geschirr = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3702"));
            CA!.Noun_Steinofen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3703"));
            CA!.Noun_Middlefinger = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3704"));
            CA!.Noun_Toya = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3705"));
            CA!.Noun_Tortilla = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3706"));
            CA!.Noun_Tony = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3707"));
            CA!.Noun_Freshman = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3708"));
            CA!.Noun_Tom = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3709"));
            CA!.Noun_Jones = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3710"));
            CA!.Noun_Sam = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3711"));
            CA!.Noun_Graham = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3712"));
            CA!.Noun_Statuen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3713"));
            CA!.Noun_Panoramen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3714"));
            CA!.Noun_Koerbe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3715"));
            CA!.Noun_Behaelter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3716"));
            CA!.Noun_Baenke = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3717"));
            CA!.Noun_Altar = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3718"));
            CA!.Noun_Stiege = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3719"));
            CA!.Noun_Kellerfenster = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3720"));
            CA!.Noun_Sims = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3721"));
            CA!.Noun_Schublade = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3722"));
            CA!.Noun_Arbeitstisch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3723"));
            CA!.Noun_Tralje = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3724"));
            CA!.Noun_Lastenaufzug = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3725"));
            CA!.Noun_Kordel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3726"));
            CA!.Noun_Dosentelefon = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3727"));
            CA!.Noun_Biomuell = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3728"));
            CA!.Noun_Stoeckchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3729"));
            CA!.Noun_Stoehnen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3730"));
            CA!.Noun_Topf = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3731"));
            CA!.Noun_Bratensosse = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3732"));
            CA!.Noun_Ofen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3733"));
            CA!.Noun_Backform = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3734"));
            CA!.Noun_Kellertuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3735"));
            CA!.Noun_Bild = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3736"));
            CA!.Noun_Schrein = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3737"));
            CA!.Noun_Papierkorb = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3738"));
            CA!.Noun_Flachmann = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3739"));
            CA!.Noun_Bodenkacheln = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3740"));
            CA!.Noun_Stahltuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3741"));
            CA!.Noun_Lustgarten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3742"));
            CA!.Noun_Gebirge = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3743"));
            CA!.Noun_Olivenbaeume = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3744"));
            CA!.Noun_Strasse = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3745"));
            Nouns.AddLoca(CA!.Noun_Strasse!.ID, "Adv_InitializeGame_Person_I_3746");
            CA!.Noun_Dorf = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3747"));
            CA!.Noun_Gebaeude = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3748"));
            CA!.Noun_Huetten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3749"));
            CA!.Noun_Rampe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3750"));
            CA!.Noun_Ritze = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3751"));
            CA!.Noun_Unkraut = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3752"));
            CA!.Noun_Seifenlauge = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3753"));
            CA!.Noun_Seife = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3754"));
            CA!.Noun_Lauge = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3755"));
            CA!.Noun_Telefon = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3756"));
            Nouns.AddLoca(CA!.Noun_Telefon!.ID, "Adv_InitializeGame_Person_I_3756a");
            CA!.Noun_Marker = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3757"));
            CA!.Noun_Tonne = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3758"));
            CA!.Noun_Labor = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3759"));
            CA!.Noun_Monitore = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3760"));
            CA!.Noun_Schraenke = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3761"));
            CA!.Noun_Morast = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3762"));
            CA!.Noun_Moder = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3763"));
            CA!.Noun_Schimmel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3764"));
            CA!.Noun_Hafenbecken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3765"));
            CA!.Noun_Pier = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3766"));
            CA!.Noun_Werkstatt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3767"));
            CA!.Noun_Bohlen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3768"));
            CA!.Noun_Boote = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3769"));
            CA!.Noun_Hafenbucht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3770"));
            CA!.Noun_Gasse = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3771"));
            CA!.Noun_Kramladen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3772"));
            CA!.Noun_Polizeiwache = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3773"));
            CA!.Noun_Post = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3774"));
            CA!.Noun_Redaktion = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3775"));
            CA!.Noun_Klotuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3776"));
            CA!.Noun_Klo = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3777"));
            CA!.Noun_Rolltreppe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3778"));
            CA!.Noun_Nichtdose = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3779"));
            CA!.Noun_Nichtdosen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3780"));
            CA!.Noun_Nichtkonserve = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3781"));
            CA!.Noun_Nichtkonserven = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3782"));
            CA!.Noun_Nichtsims = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3783"));
            CA!.Noun_Nichtvorhang = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3784"));
            CA!.Noun_Sternekoeche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3785"));
            CA!.Noun_Earpods = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3786"));
            CA!.Noun_Huellen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3787"));
            CA!.Noun_Ladekabel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3788"));
            CA!.Noun_Verkaufstische = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3789"));
            CA!.Noun_Durchgang = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3790"));
            CA!.Noun_Gaeste = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3791"));
            CA!.Noun_Gestalten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3792"));
            CA!.Noun_Luft = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3793"));
            CA!.Noun_Tische = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3794"));
            CA!.Noun_Klappe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3795"));
            CA!.Noun_Muellklappe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3796"));
            CA!.Noun_Schacht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3797"));
            CA!.Noun_Muellschacht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3798"));
            CA!.Noun_Couch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3799"));
            CA!.Noun_Stuehle = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3800"));
            CA!.Noun_Tafel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3801"));
            CA!.Noun_Phiole = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3802"));
            CA!.Noun_Container = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3803"));
            CA!.Noun_Disteln = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3804"));
            CA!.Noun_Muell = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3805"));
            CA!.Noun_Muellcontainer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3806"));
            CA!.Noun_Zaeune = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3807"));
            CA!.Noun_Stan = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3808"));
            CA!.Noun_Delivery = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3809"));
            CA!.Noun_Plakate = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3810"));
            CA!.Noun_Postschalter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3811"));
            CA!.Noun_Schreibpult = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3812"));
            CA!.Noun_Pult = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3813"));
            CA!.Noun_Wartebereich = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3814"));
            CA!.Noun_Emil = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3815"));
            CA!.Noun_Ike = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3816"));
            CA!.Noun_Ludmilla = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3817"));
            CA!.Noun_Streichelt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3818"));
            CA!.Noun_Schmitt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3819"));
            CA!.Noun_Julius = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3820"));
            Nouns.AddLoca(CA!.Noun_Julius!.ID, "Adv_InitializeGame_Person_I_3821");
            CA!.Noun_Walton = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3822"));
            CA!.Noun_Schriftzug = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3823"));
            CA!.Noun_Klingel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3824"));
            CA!.Noun_Riegel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3825"));
            CA!.Noun_Backofen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3826"));
            CA!.Noun_Form = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3827"));
            CA!.Noun_Oeffner = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3828"));
            CA!.Noun_Priester = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3829"));
            CA!.Noun_Kuechenjunge = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3830"));
            CA!.Noun_Junge = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3831"));
            CA!.Noun_Proviantmeister = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3832"));
            CA!.Noun_Sofa = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3833"));
            CA!.Noun_Auslagen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3834"));
            CA!.Noun_Drehstaender = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3835"));
            CA!.Noun_Tand = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3836"));
            CA!.Noun_Holztuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3837"));
            CA!.Noun_Maennlein = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3838"));
            CA!.Noun_Maennchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3839"));
            CA!.Noun_Pfanne = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3840"));
            CA!.Noun_Fleischwolf = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3841"));
            CA!.Noun_Wandtattoo = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3842"));
            CA!.Noun_Schere = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3843"));
            CA!.Noun_Bonny = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3844"));
            CA!.Noun_Rocks = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3845"));
            CA!.Noun_Prepper = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3846"));
            CA!.Noun_John = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3847"));
            CA!.Noun_Foster = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3848"));
            CA!.Noun_Deborah = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3849"));
            Nouns.AddLoca(CA!.Noun_Deborah!.ID, "Adv_InitializeGame_Person_I_3850");
            CA!.Noun_Norma = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3851"));
            CA!.Noun_Fakes = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3852"));
            CA!.Noun_Harald = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3853"));
            CA!.Noun_Habicht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3854"));
            CA!.Noun_Prayin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3855"));
            CA!.Noun_Erin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3856"));
            CA!.Noun_Stadtraetin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3857"));
            CA!.Noun_Stadtrat = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3858"));
            CA!.Noun_Buergermeister = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3859"));
            CA!.Noun_Buergermeisterin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3860"));
            CA!.Noun_Frieda = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3861"));
            CA!.Noun_Frimpton = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3862"));
            CA!.Noun_Weiden = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3863"));
            CA!.Noun_Kuehe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3864"));
            CA!.Noun_Stacheldrahtzaun = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3865"));
            CA!.Noun_Zaun = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3866"));
            CA!.Noun_Zigarrenrauch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3867"));
            CA!.Noun_Rauch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3868"));
            CA!.Noun_Trophaeen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3869"));
            CA!.Noun_Bilder = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3870"));
            CA!.Noun_Wimpel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3871"));
            CA!.Noun_Geruch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3872"));
            Nouns.AddLoca(CA!.Noun_Geruch!.ID, "Adv_InitializeGame_Person_I_3873");
            CA!.Noun_Steuerschatulle = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3874"));
            CA!.Noun_Schatulle = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3875"));
            CA!.Noun_Geschmeide = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3876"));
            CA!.Noun_Pokale = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3877"));
            CA!.Noun_Pokal = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3878"));
            CA!.Noun_Auszeichnungen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3879"));
            CA!.Noun_Auszeichnung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3880"));
            CA!.Noun_Reichtum = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3881"));
            CA!.Noun_Vuvuzela = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3882"));
            CA!.Noun_Umgebung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3883"));
            CA!.Noun_Ferdinand = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3884"));
            Nouns.AddLoca(CA!.Noun_Ferdinand!.ID, "Adv_InitializeGame_Person_I_3885");
            CA!.Noun_Tristan = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3886"));
            CA!.Noun_Kisten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3887"));
            CA!.Noun_Staubpartikel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3888"));
            CA!.Noun_Buesche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3889"));
            CA!.Noun_Farne = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3890"));
            CA!.Noun_Friedhof = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3891"));
            CA!.Noun_Laubbaeume = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3892"));
            CA!.Noun_Wegraender = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3893"));
            CA!.Noun_Exponate = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3894"));
            CA!.Noun_Werkzeugkasten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3895"));
            CA!.Noun_Schilder = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3896"));
            CA!.Noun_Staender = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3897"));
            CA!.Noun_Werkbank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3898"));
            CA!.Noun_Leo = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3899"));
            CA!.Noun_Aktenschrank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3900"));
            CA!.Noun_Kalender = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3901"));
            CA!.Noun_Schemel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3902"));
            CA!.Noun_Dirty = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3903"));
            CA!.Noun_Karl = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3904"));
            CA!.Noun_Larry = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3905"));
            CA!.Noun_Professor = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3906"));
            Nouns.AddLoca(CA!.Noun_Professor!.ID, "Adv_InitializeGame_Person_I_3907");
            CA!.Noun_Skarabaeus = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3908"));
            CA!.Noun_Geraetschaften = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3909"));
            CA!.Noun_Tabletten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3910"));
            CA!.Noun_Tablette = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3911"));
            CA!.Noun_Bund = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3912"));
            CA!.Noun_Highway = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3913"));
            CA!.Noun_Korb = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3914"));
            CA!.Noun_Krug = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3915"));
            CA!.Noun_Bierkrug = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3916"));
            CA!.Noun_Wege = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3917"));
            CA!.Noun_Graeber = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3918"));
            CA!.Noun_Grabsteine = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3919"));
            CA!.Noun_Grabstein = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3920"));
            CA!.Noun_Grab = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3921"));
            CA!.Noun_Brunnen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3922"));
            Nouns.AddLoca(CA!.Noun_Brunnen!.ID, "Adv_Well");
            CA!.Noun_Zombiehorde = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3923"));
            CA!.Noun_Zombies = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3924"));
            CA!.Noun_Zombie = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3925"));
            CA!.Noun_Haeuser = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3926"));
            CA!.Noun_Balkon = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3927"));
            CA!.Noun_Glaspalaeste = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3928"));
            CA!.Noun_Glaspalast = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3929"));
            CA!.Noun_Palast = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3930"));
            CA!.Noun_Platz = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3931"));
            CA!.Noun_Plakette = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3932"));
            CA!.Noun_Logistikzentrum = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3933"));
            CA!.Noun_Zentrum = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3934"));
            CA!.Noun_George = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3935"));
            CA!.Noun_Ruler = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3936"));
            CA!.Noun_Horizont = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3937"));
            CA!.Noun_Eremitin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3938"));
            CA!.Noun_Acker = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3939"));
            CA!.Noun_Flackerlicht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3940"));
            CA!.Noun_Flackern = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3941"));
            CA!.Noun_Flaemmchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3942"));
            CA!.Noun_Gas = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3943"));
            CA!.Noun_Sumpfgas = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3944"));
            CA!.Noun_Wasser = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3945"));
            CA!.Noun_Bericht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3946"));
            CA!.Noun_Rechenschaftsbericht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3947"));
            CA!.Noun_Briefkasten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3948"));
            CA!.Noun_Postkasten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3949"));
            CA!.Noun_Kasten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3950"));
            CA!.Noun_Schraubstock = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3951"));
            Nouns.AddLoca(CA!.Noun_Schraubstock!.ID, "Adv_InitializeGame_Person_I_3951a");

            CA!.Noun_Bauernhaus = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3952"));
            CA!.Noun_Bauernhof = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3953"));
            CA!.Noun_Haus = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3954"));
            CA!.Noun_Wohnhaus = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3955"));
            CA!.Noun_Landmaschinen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3956"));
            CA!.Noun_Maschinen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3957"));
            CA!.Noun_Maschine = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3958"));
            CA!.Noun_Maisfeld = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3959"));
            CA!.Noun_Matsch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3960"));
            CA!.Noun_Scheune = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3961"));
            CA!.Noun_Laubbaum = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3962"));
            CA!.Noun_Weg = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3963"));
            CA!.Noun_Werkzeugschrank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3964"));
            CA!.Noun_Strohballenberg = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3965"));
            CA!.Noun_Strohballen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3966"));
            CA!.Noun_Scheunentor = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3967"));
            CA!.Noun_Lichtschalter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3968"));
            CA!.Noun_Balken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3969"));
            CA!.Noun_Wesir = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3970"));
            CA!.Noun_Grosswesir = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3971"));
            CA!.Noun_Gift = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3972"));
            CA!.Noun_Flakon = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3973"));
            CA!.Noun_Flakons = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3974"));
            CA!.Noun_Bier = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3975"));
            CA!.Noun_Tal = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3976"));
            CA!.Noun_Blumenwiese = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3977"));
            CA!.Noun_Favelas = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3978"));
            CA!.Noun_Favela = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3979"));
            CA!.Noun_Maisstauden = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3980"));
            CA!.Noun_Maiskolben = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3981"));
            CA!.Noun_Erdreich = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3982"));
            CA!.Noun_Lichtung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3983"));
            CA!.Noun_Birken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3984"));
            CA!.Noun_Wohnstube = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3985"));
            CA!.Noun_Vorratskammer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3986"));
            CA!.Noun_Senfomat = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3987"));
            Nouns.AddLoca(CA!.Noun_Senfomat!.ID, "Adv_InitializeGame_Person_I_3988");
            CA!.Noun_Apparat = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3989"));
            CA!.Noun_Stube = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3990"));
            CA!.Noun_Kuechenzeile = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3991"));
            CA!.Noun_Wasserhahn = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3992"));
            CA!.Noun_Spuelbecken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3993"));
            CA!.Noun_Kammer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3994"));
            CA!.Noun_Esstisch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3995"));
            CA!.Noun_Anrichte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3996"));
            CA!.Noun_Wandregal = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3997"));
            CA!.Noun_Symbole = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3998"));
            CA!.Noun_Sprueche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3999"));
            CA!.Noun_Spruch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4000"));
            CA!.Noun_Sinnsprueche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4001"));
            CA!.Noun_Schlafkammer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4002"));
            CA!.Noun_Nippes = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4003"));
            CA!.Noun_Geroell = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4004"));
            CA!.Noun_Felswand = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4005"));
            CA!.Noun_Toilettenraum = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4006"));
            CA!.Noun_Toilette = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4007"));
            CA!.Noun_Plumpsklo = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4008"));
            CA!.Noun_Fensterschlitz = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4009"));
            CA!.Noun_Gewoelbe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4010"));
            CA!.Noun_Steintreppe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4011"));
            CA!.Noun_Betonboden = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4012"));
            CA!.Noun_Dampfer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4013"));
            CA!.Noun_Boulevard = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4014"));
            CA!.Noun_Edelfavelas = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4015"));
            CA!.Noun_Kommunikationszentrum = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4016"));
            CA!.Noun_Hightechzaun = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4017"));
            CA!.Noun_Zahlenschloss = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4018"));
            CA!.Noun_Taefelchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4019"));
            CA!.Noun_Gewicht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4020"));
            CA!.Noun_Knoten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4021"));
            CA!.Noun_Ringschraube = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4022"));
            CA!.Noun_Schraube = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4023"));
            CA!.Noun_Ring = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4024"));
            CA!.Noun_Hakenseil = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4025"));
            Nouns.AddLoca(CA!.Noun_Hakenseil!.ID, "Adv_Noun_Ropehook");
            CA!.Noun_Stockseil = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4026"));
            CA!.Noun_Hecken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4027"));
            CA!.Noun_Hecke = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4028"));
            CA!.Noun_Brieffach = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4029"));
            CA!.Noun_Fach = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4030"));
            CA!.Noun_Sekretaer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4031"));
            CA!.Noun_Apparaturen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4032"));
            CA!.Noun_Apparatur = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4033"));
            CA!.Noun_Juwelen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4034"));
            CA!.Noun_Mall = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4035"));
            CA!.Noun_Shop = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4036"));
            CA!.Noun_Glastuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4037"));
            CA!.Noun_Angebote = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4038"));
            CA!.Noun_Paletten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4039"));
            CA!.Noun_Platten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4040"));
            CA!.Noun_Pillen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4041"));
            CA!.Noun_Droge = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4042"));
            CA!.Noun_Panorama = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4043"));
            CA!.Noun_Statue = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4044"));
            CA!.Noun_Krone = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4045"));
            CA!.Noun_Ohr = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4046"));
            CA!.Noun_Baerenfallen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4047"));
            CA!.Noun_Wertstoffe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4048"));
            CA!.Noun_Geld = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4049"));
            CA!.Noun_Mauer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4050"));
            CA!.Noun_Wehr = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4051"));
            CA!.Noun_Faesschen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4052"));
            CA!.Noun_Drehwolf = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4053"));
            CA!.Noun_Tattoo = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4054"));
            CA!.Noun_Wolf = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4055"));
            CA!.Noun_Aufzug = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4056"));
            CA!.Noun_Berater = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4057"));
            Nouns.AddLoca(CA!.Noun_Berater!.ID, "Adv_InitializeGame_Person_I_4057a");
            Nouns.AddLoca(CA!.Noun_Berater!.ID, "Adv_InitializeGame_Person_I_4057b");
            Nouns.AddLoca(CA!.Noun_Berater!.ID, "Adv_InitializeGame_Person_I_4057c");

            CA!.Noun_Blut = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4058"));
            CA!.Noun_Exberater = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4059"));
            CA!.Noun_Gefangener = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4060"));
            CA!.Noun_Exgefangener = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4061"));
            CA!.Noun_Feld = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4062"));
            CA!.Noun_Folterwerkzeuge = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4063"));
            CA!.Noun_Garnitur = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4064"));
            CA!.Noun_Hof = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4065"));
            CA!.Noun_Instrumente = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4066"));
            CA!.Noun_Kacheln = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4067"));
            CA!.Noun_Kolben = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4068"));
            CA!.Noun_Kueche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4069"));
            CA!.Noun_Mais = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4070"));
            CA!.Noun_Maisstaude = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4071"));
            CA!.Noun_Partikel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4072"));
            CA!.Noun_Scheibe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4073"));
            CA!.Noun_Scheiben = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4074"));
            CA!.Noun_Schrift = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4075"));
            CA!.Noun_Staude = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4076"));
            CA!.Noun_Steine = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4077"));
            CA!.Noun_Werkzeuge = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4078"));
            CA!.Noun_Zeile = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4079"));
            CA!.Noun_Boot = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4080"));
            CA!.Noun_Computer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4081"));
            CA!.Noun_Desk = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4082"));
            CA!.Noun_Desks = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4083"));
            CA!.Noun_Gitterstab = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4084"));
            CA!.Noun_Stab = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4085"));
            CA!.Noun_Beschlaege = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4086"));
            CA!.Noun_Eisen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4087"));
            CA!.Noun_Eisenbeschlaege = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4088"));
            CA!.Noun_Eisenbeschlag = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4089"));
            CA!.Noun_Schreibmaschine = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4090"));
            CA!.Noun_Bars = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4091"));
            CA!.Noun_Barfrau = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4092"));
            CA!.Noun_Strandbars = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4093"));
            CA!.Noun_Strandbar = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4094"));
            CA!.Noun_Brocken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4095"));
            CA!.Noun_Gang = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4096"));
            CA!.Noun_Helm = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4097"));
            CA!.Noun_Steinbrocken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4098"));
            CA!.Noun_Bratensauce = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4099"));
            CA!.Noun_Sauce = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4100"));
            CA!.Noun_Sosse = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4101"));
            Nouns.AddLoca(CA!.Noun_Sosse!.ID, "Adv_InitializeGame_Noun_Sosse");
            CA!.Noun_Maler = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4102"));
            CA!.Noun_Exqueen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4103"));
            Nouns.AddLoca(CA!.Noun_Exqueen!.ID, "Adv_InitializeGame_Person_I_4104");
            CA!.Noun_Exexkoenigin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4105"));
            CA!.Noun_Kanne = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4106"));
            CA!.Noun_Kate = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4107"));
            CA!.Noun_Queen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4108"));
            Nouns.AddLoca(CA!.Noun_Queen!.ID, "Adv_InitializeGame_Person_I_4109");
            CA!.Noun_Bahn = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4110"));
            CA!.Noun_Bahnen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4111"));
            CA!.Noun_Club = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4112"));
            CA!.Noun_Clubhaus = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4113"));
            CA!.Noun_Golfbahnen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4114"));
            CA!.Noun_Golfplatz = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4115"));
            CA!.Noun_Senftopf = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4116"));
            CA!.Noun_Senffass = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4117"));
            CA!.Noun_Tank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4118"));
            CA!.Noun_Tankverschluss = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4119"));
            Nouns.AddLoca(CA!.Noun_Tankverschluss!.ID, "Adv_InitializeGame_Person_I_4119a");
            CA!.Noun_Traktor = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4120"));
            CA!.Noun_Schlauchende = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4121"));
            CA!.Noun_Trecker = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4122"));
            CA!.Noun_Verschluss = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4123"));
            CA!.Noun_Glasscheiben = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4124"));
            CA!.Noun_Bueros = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4125"));
            CA!.Noun_Buero = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4126"));
            CA!.Noun_Geraete = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4127"));
            CA!.Noun_Matschpfuetze = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4128"));
            CA!.Noun_Pfuetze = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4129"));
            CA!.Noun_Regentonne = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4130"));
            CA!.Noun_Kleiderschrank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4131"));
            CA!.Noun_Schlafgemach = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4132"));
            CA!.Noun_Bettdecke = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4133"));
            CA!.Noun_Portrait = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4134"));
            CA!.Noun_Benachrichtigung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4135"));
            CA!.Noun_Benachrichtigungskarte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4136"));
            CA!.Noun_Hightechklo = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4137"));
            CA!.Noun_Bildhauer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4138"));
            CA!.Noun_Leiber = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4139"));
            CA!.Noun_Kabel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4140"));
            CA!.Noun_Kabelisolierung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4141"));
            CA!.Noun_Isolierung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4142"));
            CA!.Noun_Abgrund = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4143"));
            CA!.Noun_Grube = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4144"));
            CA!.Noun_Instrument = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4145"));
            CA!.Noun_Menschenleiber = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4146"));
            CA!.Noun_Musikinstrumente = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4147"));
            CA!.Noun_Ausgabe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4148"));
            CA!.Noun_Ausgabefach = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4149"));
            CA!.Noun_Knochentuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4150"));
            CA!.Noun_Frachtdokumente = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4151"));
            Nouns.AddLoca(CA!.Noun_Frachtdokumente!.ID, "Adv_InitializeGame_Person_I_4152");
            CA!.Noun_Dokumente = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4153"));
            CA!.Noun_Zettel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4154"));
            CA!.Noun_Berder = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4155"));
            CA!.Noun_Bruecke = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4156"));
            CA!.Noun_Daemonen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4157"));
            CA!.Noun_Pfuhl = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4158"));
            CA!.Noun_Satanspfuhl = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4159"));
            CA!.Noun_Zeichen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4160"));
            CA!.Noun_Feuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4161"));
            CA!.Noun_Foltersitzgarnitur = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4162"));
            CA!.Noun_Hoellenfeuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4163"));
            CA!.Noun_Schwaden = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4164"));
            CA!.Noun_Schwefelschwaden = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4165"));
            CA!.Noun_Fahndungsplakat = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4166"));
            CA!.Noun_Fahndungsplakate = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4167"));
            CA!.Noun_Plakat = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4168"));
            CA!.Noun_Metallschrank = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4169"));
            CA!.Noun_Faeulnis = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4170"));
            CA!.Noun_Daemonentor = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4171"));
            CA!.Noun_Satanspalast = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4172"));
            CA!.Noun_Hoellenkreatur = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4173"));
            CA!.Noun_Kreatur = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4174"));
            CA!.Noun_Schaelchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4175"));
            CA!.Noun_Suhle = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4176"));
            CA!.Noun_Teufelssuhle = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4177"));
            CA!.Noun_Friteuse = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4178"));
            CA!.Noun_Lakaien = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4179"));
            CA!.Noun_Lakai = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4180"));
            CA!.Noun_Essenshalde = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4181"));
            CA!.Noun_Halde = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4182"));
            CA!.Noun_Lebensmittel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4183"));
            CA!.Noun_Dome = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Dome"));
            CA!.Noun_Kaeptn = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4184"));
            Nouns.AddLoca(CA!.Noun_Kaeptn!.ID, "Adv_InitializeGame_Kaeptn");
            CA!.Noun_Pentagramme = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4185"));
            CA!.Noun_Schaedel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4186"));
            CA!.Noun_Lava = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4187"));
            CA!.Noun_Flaschenzug = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4188"));
            CA!.Noun_Lift = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4189"));
            CA!.Noun_Schnur = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4190"));
            CA!.Noun_Faser = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4191"));
            CA!.Noun_Hightechfaser = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4192"));
            CA!.Noun_Angelschnur = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4193"));
            CA!.Noun_Suessigkeitenbrunnen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4194"));
            CA!.Noun_Zuendschnur = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4195"));
            CA!.Noun_Pappaufsteller = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4196"));
            CA!.Noun_Aufsteller = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4197"));
            CA!.Noun_Lunte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4198"));
            CA!.Noun_Truemmerhaufen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4199"));
            CA!.Noun_Fuerstin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4200"));
            CA!.Noun_Hoellenfuerstin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4201"));
            CA!.Noun_Schmierereien = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4202"));
            CA!.Noun_Elendshuetten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4203"));
            CA!.Noun_Hochbau = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4204"));
            CA!.Noun_Hochbauten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4205"));
            CA!.Noun_Hochhaus = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4206"));
            CA!.Noun_Geisterschiff = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4207"));
            CA!.Noun_Gebeine = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4208"));
            CA!.Noun_Schaufenster = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4209"));
            CA!.Noun_Stangen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4210"));
            CA!.Noun_Muelleimer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4211"));
            CA!.Noun_Gitter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4212"));
            CA!.Noun_Staebe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4213"));
            CA!.Noun_Staebchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4214"));
            CA!.Noun_Grappa = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4215"));
            CA!.Noun_Bauer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4216"));
            CA!.Noun_Senf = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4217"));
            CA!.Noun_Esse = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4218"));
            CA!.Noun_Zucker = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4219"));
            CA!.Noun_Paeckchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4220"));
            CA!.Noun_Wanne = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4221"));
            CA!.Noun_Spinnweben = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4222"));
            CA!.Noun_Prunktuer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4223"));
            CA!.Noun_Nackttaenzerinnen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4224"));
            CA!.Noun_Nackttaenzerin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4225"));
            CA!.Noun_Taenzerinnen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4226"));
            CA!.Noun_Taenzerin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4227"));
            CA!.Noun_Koeche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4228"));
            CA!.Noun_Folie = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4229"));
            CA!.Noun_Holz = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4230"));
            CA!.Noun_Metall = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4231"));
            CA!.Noun_Schiebewagen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4232"));
            CA!.Noun_Wagen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4233"));
            CA!.Noun_Postsack = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4234"));
            CA!.Noun_Heliumbehaelter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4235"));
            CA!.Noun_Helium = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4236"));
            CA!.Noun_Flasche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4237"));
            CA!.Noun_Bodenteppich = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4238"));
            CA!.Noun_Naegel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4239"));
            CA!.Noun_Loch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4240"));
            CA!.Noun_Berg = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4241"));
            CA!.Noun_Puppenberg = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4242"));
            CA!.Noun_Puppen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4243"));
            CA!.Noun_Stoffpuppen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4244"));
            CA!.Noun_Stofftiere = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4245"));
            CA!.Noun_Wuermer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4246"));
            CA!.Noun_Gewand = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4247"));
            CA!.Noun_Servierhaube = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4248"));
            CA!.Noun_Haube = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4249"));
            CA!.Noun_Servierplatte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4250"));
            CA!.Noun_Platte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4251"));
            CA!.Noun_Mahl = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4252"));
            CA!.Noun_Werbetafeln = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4253"));
            CA!.Noun_Tafeln = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4254"));
            CA!.Noun_Ballen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4255"));
            CA!.Noun_Bacon = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4256"));
            CA!.Noun_Streifen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4257"));
            CA!.Noun_Blumen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4258"));
            CA!.Noun_Wiese = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4259"));
            CA!.Noun_Joystick = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4260"));
            CA!.Noun_Anlage = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4261"));
            CA!.Noun_Kran = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4262"));
            CA!.Noun_Krananlage = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4263"));
            CA!.Noun_Buecherhaufen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4264"));
            CA!.Noun_Haufen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4265"));
            CA!.Noun_Hippie = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4266"));
            CA!.Noun_Partypeople = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4267"));
            Nouns.AddLoca(CA!.Noun_Partypeople!.ID, "Adv_InitializeGame_Person_I_4268");
            CA!.Noun_Party = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4269"));
            CA!.Noun_People = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4270"));
            CA!.Noun_Blaetter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4271"));
            CA!.Noun_Blatt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4272"));
            CA!.Noun_Ruecken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4273"));
            CA!.Noun_Hippieruecken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4274"));
            CA!.Noun_Pullover = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4275"));
            CA!.Noun_Kelch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4276"));
            CA!.Noun_Blume = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4277"));
            CA!.Noun_Bluetenkelch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4278"));
            CA!.Noun_Landvermesser = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4279"));
            CA!.Noun_Vermesser = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4280"));
            CA!.Noun_Moerser = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4281"));
            Nouns.AddLoca(CA!.Noun_Moerser!.ID, "Adv_InitializeGame_Person_I_4282");
            CA!.Noun_Stoessel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4283"));
            CA!.Noun_Gin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4284"));
            CA!.Noun_Kohle = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4285"));
            CA!.Noun_Satanisten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4286"));
            CA!.Noun_Satanist = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4287"));
            CA!.Noun_Attraktionen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4288"));
            CA!.Noun_Attraktion = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4289"));
            CA!.Noun_Lautsprecher = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4290"));
            CA!.Noun_Smartphone = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4291"));
            Nouns.AddLoca(CA!.Noun_Smartphone!.ID, "Adv_InitializeGame_Person_I_4292");
            CA!.Noun_Dimensionstor = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4293"));
            CA!.Noun_Motiv = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4294"));
            CA!.Noun_Motive = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4295"));
            CA!.Noun_Ruine = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4296"));
            CA!.Noun_Mansion = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4297"));
            CA!.Noun_Galgen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4298"));
            CA!.Noun_Gehenkte = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4299"));
            CA!.Noun_Erde = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4300"));
            CA!.Noun_Idiot = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4301"));
            CA!.Noun_Steinpfad = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4302"));
            CA!.Noun_Farmer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4303"));
            CA!.Noun_Farmerin = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4304"));
            CA!.Noun_Kadaver = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4305"));
            CA!.Noun_Mogul = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4306"));
            CA!.Noun_Nachricht = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4307"));
            CA!.Noun_Notiz = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4308"));
            CA!.Noun_Peitsche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4309"));
            CA!.Noun_Schale = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4310"));
            CA!.Noun_Schrauber = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4311"));
            CA!.Noun_Spielgeldboegen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4312"));
            CA!.Noun_Werkzeug = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4313"));
            CA!.Noun_Runen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4314"));
            CA!.Noun_Teufelsstatuette = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4315"));
            CA!.Noun_Teufel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4316"));
            CA!.Noun_Boegen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4317"));
            CA!.Noun_Papierbogen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4318"));
            CA!.Noun_Abteilung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4319"));
            CA!.Noun_Accessoires = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4320"));
            CA!.Noun_Fetisch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4321"));
            CA!.Noun_Fetischaccessoires = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4322"));
            CA!.Noun_Lackundleder_Abteilung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4323"));
            CA!.Noun_Leder = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4324"));
            CA!.Noun_Lederoutfit = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4325"));
            CA!.Noun_Lederoutfits = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4326"));
            CA!.Noun_Luxus = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4327"));
            CA!.Noun_Luxusabteilung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4328"));
            CA!.Noun_Outfit = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4329"));
            CA!.Noun_Sextoys = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4330"));
            CA!.Noun_Toys = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4331"));
            CA!.Noun_Dildos = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4332"));
            CA!.Noun_Dildo = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4333"));
            CA!.Noun_Tempel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4334"));
            CA!.Noun_Waesche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4335"));
            CA!.Noun_Wolken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4336"));
            CA!.Noun_Wolke = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4337"));
            CA!.Noun_Henkerswald = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4338"));
            CA!.Noun_Nackttaenzer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4339"));
            CA!.Noun_Taenzer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4340"));
            CA!.Noun_Pflanzen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4341"));
            CA!.Noun_Saeure = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4342"));
            CA!.Noun_Saeureseen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4343"));
            CA!.Noun_Schling = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4344"));
            CA!.Noun_Schlingpflanzen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4345"));
            CA!.Noun_See = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4346"));
            CA!.Noun_Seen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4347"));
            CA!.Noun_Becken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4348"));
            CA!.Noun_Waschbecken = Nouns.Add(Noun.NounLoca("Noun_Waschbecken"));

            CA!.Noun_Kapelle = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4349"));
            CA!.Noun_Kirche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4350"));
            CA!.Noun_Turm = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4351"));
            CA!.Noun_Wirtschaftsgebaeude = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4352"));
            CA!.Noun_Ball = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4353"));

            CA!.Noun_Wichser = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4354"));
            CA!.Noun_Arschloch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4355"));
            CA!.Noun_Drecksau = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4356"));
            CA!.Noun_Werkzeugkiste = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4357"));
            CA!.Noun_Dart = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4358"));
            CA!.Noun_Schein = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4359"));
            CA!.Noun_Farbeimer = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4360"));
            CA!.Noun_Farbe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4361"));
            CA!.Noun_Bezug = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4362"));
            CA!.Noun_Schleuder = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4363"));
            Nouns.AddLoca(CA!.Noun_Schleuder!.ID, "Adv_InitializeGame_Person_I_4364");
            CA!.Noun_Stift = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4365"));
            CA!.Noun_Balg = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4366"));
            CA!.Noun_Stange = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4367"));
            CA!.Noun_Mohn = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4368"));
            CA!.Noun_Opium = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4369"));
            CA!.Noun_Schlafmittel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4370"));
            CA!.Noun_Ecke = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4371"));
            CA!.Noun_Lied = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4372"));
            CA!.Noun_Gemuese = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4373"));
            CA!.Noun_Zucchini = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4374"));
            CA!.Noun_Tomaten = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4375"));
            CA!.Noun_Tomate = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4376"));
            CA!.Noun_Lauch = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4377"));
            Nouns.AddLoca(CA!.Noun_Lauch!.ID, "Adv_InitializeGame_Person_I_4378");
            Nouns.AddLoca(CA!.Noun_Lauch!.ID, "Adv_InitializeGame_Person_I_4379");
            CA!.Noun_Karaffe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4380"));
            CA!.Noun_Schnapsglas = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4381"));
            CA!.Noun_Schnaps = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4382"));
            CA!.Noun_Dokument = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4383"));

            CA!.Noun_Ketchupflecken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4384"));
            CA!.Noun_Ketchup = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4385"));
            CA!.Noun_Flecken = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4386"));
            CA!.Noun_Gefangene = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4387"));
            CA!.Noun_Maden = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4388"));
            CA!.Noun_Engerlinge = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4389"));

            CA!.Noun_Metropole = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4390"));
            CA!.Noun_Huegel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4391"));
            CA!.Noun_Burgruine = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4392"));
            CA!.Noun_Teufelswald = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4393"));
            CA!.Noun_Schwefel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4394"));
            CA!.Noun_Burg = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4395"));

            CA!.Noun_Fuellfederhalter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4396"));
            CA!.Noun_Federhalter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4397"));
            CA!.Noun_Fueller = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4398"));
            CA!.Noun_Schlaufe = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4399"));
            CA!.Noun_Tuete = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4400"));

            CA!.Noun_Schreib = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4401"));
            CA!.Noun_Stifthalter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4402"));
            CA!.Noun_Halter = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4403"));
            CA!.Noun_Lieferscheine = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4404"));
            CA!.Noun_Scheine = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4405"));
            CA!.Noun_Glasschneider = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4406"));
            CA!.Noun_Schneider = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4407"));
            CA!.Noun_Urkunde = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4408"));
            CA!.Noun_Pendel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4409"));
            CA!.Noun_Aubergine = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4410"));
            CA!.Noun_Spruehflasche = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4411"));

            CA!.Noun_Gewaechshaus = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4412"));
            CA!.Noun_Terminal = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4413"));
            CA!.Noun_Natron = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4414"));
            CA!.Noun_Packung = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4415"));
            CA!.Noun_Apfelessig = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4416"));
            CA!.Noun_Apfel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4417"));
            CA!.Noun_Essig = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4418"));
            CA!.Noun_Polierlappen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4419"));
            CA!.Noun_Lappen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4420"));

            CA!.Noun_Grapefruitextrakt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4421"));
            CA!.Noun_Grapefruit = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4422"));
            CA!.Noun_Extrakt = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4423"));
            CA!.Noun_Flaeschchen = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_4424"));


            CA!.Noun_Dimensions = Nouns.Add(Noun.NounLoca("Noun_Dimensions"));
            CA!.Noun_Folter = Nouns.Add(Noun.NounLoca("Noun_Folter"));
            CA!.Noun_Lachen = Nouns.Add(Noun.NounLoca("Noun_Lachen"));
            CA!.Noun_Streck = Nouns.Add(Noun.NounLoca("Noun_Streck"));
            CA!.Noun_Versammlungs = Nouns.Add(Noun.NounLoca("Noun_Versammlungs"));

            CA!.Noun_Wirtschafts = Nouns.Add(Noun.NounLoca("Noun_Wirtschafts"));
            CA!.Noun_Wendel = Nouns.Add(Noun.NounLoca("Noun_Wendel"));
            CA!.Noun_Paradies = Nouns.Add(Noun.NounLoca("Noun_Paradies"));
            CA!.Noun_Mann = Nouns.Add(Noun.NounLoca("Noun_Mann"));
            CA!.Noun_Eichen = Nouns.Add(Noun.NounLoca("Noun_Eichen"));
            CA!.Noun_Blick = Nouns.Add(Noun.NounLoca("Noun_Blick"));

            CA!.Noun_Fluegel = Nouns.Add(Noun.NounLoca("Noun_Fluegel"));
            CA!.Noun_Steuer = Nouns.Add(Noun.NounLoca("Noun_Steuer"));
            CA!.Noun_Back = Nouns.Add(Noun.NounLoca("Noun_Back"));
            CA!.Noun_Arbeit = Nouns.Add(Noun.NounLoca("Noun_Arbeit"));
            CA!.Noun_Oliven = Nouns.Add(Noun.NounLoca("Noun_Oliven"));
            CA!.Noun_Wohn = Nouns.Add(Noun.NounLoca("Noun_Wohn"));
            CA!.Noun_Hafen = Nouns.Add(Noun.NounLoca("Noun_Hafen"));
            CA!.Noun_Agrikultur = Nouns.Add(Noun.NounLoca("Noun_Agrikultur"));
            CA!.Noun_Polizei = Nouns.Add(Noun.NounLoca("Noun_Polizei"));
            CA!.Noun_Bereich = Nouns.Add(Noun.NounLoca("Noun_Bereich"));
            CA!.Noun_Laub = Nouns.Add(Noun.NounLoca("Noun_Laub"));
            CA!.Noun_Regen = Nouns.Add(Noun.NounLoca("Noun_Regen"));
            CA!.Noun_Warte = Nouns.Add(Noun.NounLoca("Noun_Warte"));

            CA!.Noun_Dreh = Nouns.Add(Noun.NounLoca("Noun_Dreh"));
            CA!.Noun_Ess = Nouns.Add(Noun.NounLoca("Noun_Ess"));
            CA!.Noun_Fracht = Nouns.Add(Noun.NounLoca("Noun_Fracht"));
            CA!.Noun_Garten = Nouns.Add(Noun.NounLoca("Noun_Garten"));
            CA!.Noun_Kombination = Nouns.Add(Noun.NounLoca("Noun_Kombination"));
            CA!.Noun_Lust = Nouns.Add(Noun.NounLoca("Noun_Lust"));
            CA!.Noun_Nackt = Nouns.Add(Noun.NounLoca("Noun_Nackt"));
            CA!.Noun_Prunk = Nouns.Add(Noun.NounLoca("Noun_Prunk"));
            CA!.Noun_Raum = Nouns.Add(Noun.NounLoca("Noun_Raum"));
            CA!.Noun_Schlitz = Nouns.Add(Noun.NounLoca("Noun_Schlitz"));
            CA!.Noun_Spielzeug = Nouns.Add(Noun.NounLoca("Noun_Spielzeug"));
            CA!.Noun_Stahl = Nouns.Add(Noun.NounLoca("Noun_Stahl"));
            CA!.Noun_Staub = Nouns.Add(Noun.NounLoca("Noun_Staub"));
            CA!.Noun_Stumpf = Nouns.Add(Noun.NounLoca("Noun_Stumpf"));
            CA!.Noun_Sumpf = Nouns.Add(Noun.NounLoca("Noun_Sumpf"));
            CA!.Noun_Wohn2 = Nouns.Add(Noun.NounLoca("Noun_Wohn2"));
            CA!.Noun_Zigarren = Nouns.Add(Noun.NounLoca("Noun_Zigarren"));

            // CA!.Noun_Edel = Nouns.Add(Noun.NounLoca("Noun_Edel"));
            CA!.Noun_Ende = Nouns.Add(Noun.NounLoca("Noun_Ende"));
            CA!.Noun_Fahndung = Nouns.Add(Noun.NounLoca("Noun_Fahndung"));
            CA!.Noun_Himmel = Nouns.Add(Noun.NounLoca("Noun_Himmel"));
            CA!.Noun_Heaven = Nouns.Add(Noun.NounLoca("Noun_Heaven"));
            CA!.Noun_Kommunikation = Nouns.Add(Noun.NounLoca("Noun_Kommunikation"));
            CA!.Noun_Lade = Nouns.Add(Noun.NounLoca("Noun_Lade"));
            CA!.Noun_Logistik = Nouns.Add(Noun.NounLoca("Noun_Logistik"));
            CA!.Noun_Palaeste = Nouns.Add(Noun.NounLoca("Noun_Palaeste"));
            CA!.Noun_Satan = Nouns.Add(Noun.NounLoca("Noun_Satan"));
            CA!.Noun_Servier = Nouns.Add(Noun.NounLoca("Noun_Servier"));
            CA!.Noun_Stern = Nouns.Add(Noun.NounLoca("Noun_Stern"));
            CA!.Noun_Verkaufs = Nouns.Add(Noun.NounLoca("Noun_Verkaufs"));

            CA!.Noun_Alfonsius = Nouns.Add(Noun.NounLoca("Noun_Alfonsius"));
            CA!.Noun_Anzug = Nouns.Add(Noun.NounLoca("Noun_Anzug"));
            CA!.Noun_Baeren = Nouns.Add(Noun.NounLoca("Noun_Baeren"));
            CA!.Noun_Baseball = Nouns.Add(Noun.NounLoca("Noun_Baseball"));
            CA!.Noun_Botanik = Nouns.Add(Noun.NounLoca("Noun_Botanik"));
            CA!.Noun_Buesser = Nouns.Add(Noun.NounLoca("Noun_Buesser"));
            CA!.Noun_Daemon = Nouns.Add(Noun.NounLoca("Noun_Daemon"));
            CA!.Noun_Experten = Nouns.Add(Noun.NounLoca("Noun_Experten"));
            CA!.Noun_Fallen = Nouns.Add(Noun.NounLoca("Noun_Fallen"));
            CA!.Noun_Fesseln = Nouns.Add(Noun.NounLoca("Noun_Fesseln"));
            CA!.Noun_Frischhalte = Nouns.Add(Noun.NounLoca("Noun_Frischhalte"));
            CA!.Noun_Friteuse1 = Nouns.Add(Noun.NounLoca("Noun_Friteuse1"));
            CA!.Noun_Gebaeude_pl = Nouns.Add(Noun.NounLoca("Noun_Gebaeude_pl"));
            CA!.Noun_Geist = Nouns.Add(Noun.NounLoca("Noun_Geist"));
            CA!.Noun_Geraet = Nouns.Add(Noun.NounLoca("Noun_Geraet"));
            CA!.Noun_Giess = Nouns.Add(Noun.NounLoca("Noun_Giess"));
            CA!.Noun_Golf = Nouns.Add(Noun.NounLoca("Noun_Golf"));
            CA!.Noun_Hanf = Nouns.Add(Noun.NounLoca("Noun_Hanf"));
            CA!.Noun_Henker = Nouns.Add(Noun.NounLoca("Noun_Henker"));
            CA!.Noun_Insel = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Person_I_3691"));
            CA!.Noun_Kappe = Nouns.Add(Noun.NounLoca("Noun_Kappe"));
            CA!.Noun_Kartoffel = Nouns.Add(Noun.NounLoca("Noun_Kartoffel"));
            CA!.Noun_Knochen = Nouns.Add(Noun.NounLoca("Noun_Knochen"));
            CA!.Noun_Kopf = Nouns.Add(Noun.NounLoca("Noun_Kopf"));
            CA!.Noun_Liefer = Nouns.Add(Noun.NounLoca("Noun_Liefer"));
            CA!.Noun_Lippenstift = Nouns.Add(Noun.NounLoca("Noun_Lippenstift"));
            CA!.Noun_Meinung = Nouns.Add(Noun.NounLoca("Noun_Meinung"));
            CA!.Noun_Menschen = Nouns.Add(Noun.NounLoca("Noun_Menschen"));
            CA!.Noun_Musik = Nouns.Add(Noun.NounLoca("Noun_Musik"));
            CA!.Noun_Outfits = Nouns.Add(Noun.NounLoca("Noun_Outfits"));
            CA!.Noun_Papp = Nouns.Add(Noun.NounLoca("Noun_Papp"));
            CA!.Noun_Permanent = Nouns.Add(Noun.NounLoca("Noun_Permanent"));
            CA!.Noun_Polier = Nouns.Add(Noun.NounLoca("Noun_Polier"));
            CA!.Noun_Rechenschafts = Nouns.Add(Noun.NounLoca("Noun_Rechenschafts"));
            CA!.Noun_Satans = Nouns.Add(Noun.NounLoca("Noun_Satans"));
            CA!.Noun_Schaukel = Nouns.Add(Noun.NounLoca("Noun_Schaukel"));
            CA!.Noun_Schiebe = Nouns.Add(Noun.NounLoca("Noun_Schiebe"));
            CA!.Noun_Schlaf = Nouns.Add(Noun.NounLoca("Noun_Schlaf"));
            CA!.Noun_Shot = Nouns.Add(Noun.NounLoca("Noun_Shot"));
            CA!.Noun_Sitz = Nouns.Add(Noun.NounLoca("Noun_Sitz"));
            CA!.Noun_Slip = Nouns.Add(Noun.NounLoca("Noun_Slip"));
            CA!.Noun_Soda = Nouns.Add(Noun.NounLoca("Noun_Soda"));
            CA!.Noun_Spiel = Nouns.Add(Noun.NounLoca("Noun_Spiel"));
            CA!.Noun_Spreng = Nouns.Add(Noun.NounLoca("Noun_Spreng"));
            CA!.Noun_Sprueh = Nouns.Add(Noun.NounLoca("Noun_Sprueh"));
            CA!.Noun_Stueck = Nouns.Add(Noun.NounLoca("Noun_Stueck"));
            CA!.Noun_Suessigkeiten = Nouns.Add(Noun.NounLoca("Noun_Suessigkeiten"));
            CA!.Noun_Taucher = Nouns.Add(Noun.NounLoca("Noun_Taucher"));
            CA!.Noun_Teufels = Nouns.Add(Noun.NounLoca("Noun_Teufels"));
            CA!.Noun_Ticket = Nouns.Add(Noun.NounLoca("Noun_Ticket"));
            CA!.Noun_Visiten = Nouns.Add(Noun.NounLoca("Noun_Visiten"));

            CA!.Noun_Bell = Nouns.Add(Noun.NounLoca("Noun_Bell"));
            CA!.Noun_Beton = Nouns.Add(Noun.NounLoca("Noun_Beton"));
            CA!.Noun_Block = Nouns.Add(Noun.NounLoca("Noun_Block"));
            CA!.Noun_Dinner = Nouns.Add(Noun.NounLoca("Noun_Dinner"));
            CA!.Noun_Flask = Nouns.Add(Noun.NounLoca("Noun_Flask"));
            CA!.Noun_Hip = Nouns.Add(Noun.NounLoca("Noun_Hip"));
            CA!.Noun_Pulley = Nouns.Add(Noun.NounLoca("Noun_Pulley"));
            // CA!.Noun_Creature = Nouns.Add(Noun.NounLoca("Noun_Creature"));
            CA!.Noun_Hell = Nouns.Add(Noun.NounLoca("Noun_Hell"));
            CA!.Noun_Horde = Nouns.Add(Noun.NounLoca("Noun_Horde"));

            CA!.Noun_Shards = Nouns.Add(Noun.NounLoca("Noun_Shards"));
            CA!.Noun_China = Nouns.Add(Noun.NounLoca("Noun_China"));
            CA!.Noun_Waste = Nouns.Add(Noun.NounLoca("Noun_Waste"));

        }

        void InitNounsFast(int size = -1)
        {
            if (size != -1)
            {
                Nouns!.TList = new Dictionary<string, Noun>(size, StringComparer.CurrentCultureIgnoreCase);

            }

            var Nounlist = new List<KeyValuePair<string, Noun>>(1303);

            Nouns!.SetupNounBuffer(1303);
            /*
            for (int x = 0; x < 1303; x++)
            {
                Noun n;
                CA!.Noun_Seil = new Noun();
                CA!.Noun_Seil.Loca = "Adv_InitializeGame_Person_I_3263";
                Nounlist.Add(new(CA!.Noun_Seil.Name + x.ToString(), CA!.Noun_Seil));
            }
            */

            string s = loca.Adv_InitializeGame_Person_I_3263;

            // Neue Nouns
            CA!.Noun_Krempel = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Krempel, "Noun_Krempel"));
            CA!.Noun_Spuren = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Spuren, "Noun_Spuren"));
            CA!.Noun_Abdeckung = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Abdeckung, "Noun_Abdeckung"));
            CA!.Noun_Deckel = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Deckel, "Noun_Deckel"));
            CA!.Noun_Verbandskasten = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Verbandskasten, "Noun_Verbandskasten"));
            CA!.Noun_Plastik = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Plastik, "Noun_Plastik"));
            CA!.Noun_Pilz = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Pilz, "Noun_Pilz"));
            CA!.Noun_Funghi = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Funghi, "Noun_Funghi"));
            CA!.Noun_Sporen = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Sporen, "Noun_Sporen"));
            CA!.Noun_Schwamm = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Schwamm, "Noun_Schwamm"));


            CA!.Noun_Ritterruestung = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Ritterruestung, "Noun_Ritterruestung"));
            CA!.Noun_Ritter = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Ritter, "Noun_Ritter"));
            CA!.Noun_Ruestung = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Ruestung, "Noun_Ruestung"));
            CA!.Noun_Eule = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Eule, "Noun_Eule"));
            CA!.Noun_Skelett = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Skelett, "Noun_Skelett"));
            CA!.Noun_Fish = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Fish, "Noun_Fish"));
            CA!.Noun_Schlange = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Schlange, "Noun_Schlange"));
            CA!.Noun_Elster = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Elster, "Noun_Elster"));
            CA!.Noun_Beutelchen = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Beutelchen, "Noun_Beutelchen"));
            CA!.Noun_Pulver = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Pulver, "Noun_Pulver"));
            CA!.Noun_Kerzenhalter = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Kerzenhalter, "Noun_Kerzenhalter"));
            CA!.Noun_Klaue = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Klaue, "Noun_Klaue"));
            CA!.Noun_Zuckerzange = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Zuckerzange, "Noun_Zuckerzange"));
            CA!.Noun_Rollpflaster = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Rollpflaster, "Noun_Rollpflaster"));
            CA!.Noun_Klauenzange = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Klauenzange, "Noun_Klauenzange"));

            CA!.Noun_Lupe = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Lupe, "Noun_Lupe"));
            CA!.Noun_Quietscheentchen = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Quietscheentchen, "Noun_Quietscheentchen"));
            CA!.Noun_Kaese = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Kaese, "Noun_Kaese"));
            CA!.Noun_Mondstein = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Mondstein, "Noun_Mondstein"));
            CA!.Noun_Mond = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Mond, "Noun_Mond"));
            CA!.Noun_Plastikbeutel = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Plastikbeutel, "Noun_Plastikbeutel"));
            CA!.Noun_Plastiktuete = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Plastiktuete, "Noun_Plastiktuete"));
            CA!.Noun_Wunderwarzenschwamm = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Wunderwarzenschwamm, "Noun_Wunderwarzenschwamm"));
            CA!.Noun_Schlacke = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Schlacke, "Noun_Schlacke"));
            CA!.Noun_Muenze = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Muenze, "Noun_Muenze"));
            CA!.Noun_Nebel = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Nebel, "Noun_Nebel"));
            CA!.Noun_Pentagramm = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Pentagramm, "Noun_Pentagramm"));
            CA!.Noun_Fussmatte = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Fussmatte, "Noun_Fussmatte"));
            CA!.Noun_Oeffnung = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Oeffnung, "Noun_Oeffnung"));
            CA!.Noun_Siegel = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Siegel, "Noun_Siegel"));
            CA!.Noun_Waescheleine = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Waescheleine, "Noun_Waescheleine"));
            CA!.Noun_Unterhose = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Unterhose, "Noun_Unterhose"));
            CA!.Noun_Unterwaesche = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Unterwaesche, "Noun_Unterwaesche"));
            CA!.Noun_Holzabdeckung = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Holzabdeckung, "Noun_Holzabdeckung"));
            CA!.Noun_Waschmaschine = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Waschmaschine, "Noun_Waschmaschine"));
            CA!.Noun_Waescheaufhaengmaschine = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Waescheaufhaengmaschine, "Noun_Waescheaufhaengmaschine"));
            CA!.Noun_Waeschekorb = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Waeschekorb, "Noun_Waeschekorb"));
            CA!.Noun_Karton = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Karton, "Noun_Karton"));
            CA!.Noun_Labortisch = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Labortisch, "Noun_Labortisch"));
            CA!.Noun_Kaefige = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Kaefige, "Noun_Kaefige"));
            CA!.Noun_Erstehilfekasten = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Erstehilfekasten, "Noun_Erstehilfekasten"));
            CA!.Noun_Metallschale = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Metallschale, "Noun_Metallschale"));
            CA!.Noun_Halterung = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Halterung, "Noun_Halterung"));
            CA!.Noun_Dunkelheitsmaschine = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Dunkelheitsmaschine, "Noun_Dunkelheitsmaschine"));
            CA!.Noun_Vogelstaender = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Vogelstaender, "Noun_Vogelstaender"));
            CA!.Noun_Matratze = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Matratze, "Noun_Matratze"));
            CA!.Noun_Kuehlschrank = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Kuehlschrank, "Noun_Kuehlschrank"));
            CA!.Noun_Gefrierfach = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Gefrierfach, "Noun_Gefrierfach"));
            CA!.Noun_Kachel = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Kachel, "Noun_Kachel"));
            CA!.Noun_Badewanne = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Badewanne, "Noun_Badewanne"));
            CA!.Noun_Spuelung = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Spuelung, "Noun_Spuelung"));
            CA!.Noun_Kerze = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Kerze, "Noun_Kerze"));
            CA!.Noun_Matte = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Matte, "Noun_Matte"));
            CA!.Noun_Halter = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Halter, "Noun_Halter"));
            CA!.Noun_Beutel = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Beutel, "Noun_Beutel"));
            CA!.Noun_Buchstaben = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Buchstaben, "Noun_Buchstaben"));
            CA!.Noun_Rolle = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Rolle, "Noun_Rolle"));

            CA!.Noun_Rune = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Rune, "Noun_Rune"));
            CA!.Noun_Warnschild = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Warnschild, "Noun_Warnschild"));
            CA!.Noun_Wasch = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Wasch, "Noun_Wasch"));
            CA!.Noun_Gefrier = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Gefrier, "Noun_Gefrier"));
            CA!.Noun_Froster = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Froster, "Noun_Froster"));
            CA!.Noun_Ente = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Ente, "Noun_Ente"));
            CA!.Noun_Entchen = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Entchen, "Noun_Entchen"));
            CA!.Noun_Gummiente = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Gummiente, "Noun_Gummiente"));
            CA!.Noun_Flamme = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Flamme, "Noun_Flamme"));
            CA!.Noun_Juwel = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Juwel, "Noun_Juwel"));
            CA!.Noun_Edelstein = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Edelstein, "Noun_Edelstein"));
            CA!.Noun_Versteck = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Versteck, "Noun_Versteck"));
            CA!.Noun_Fliese = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Fliese, "Noun_Fliese"));
            CA!.Noun_Fliesen = Nouns!.Add(Noun.NounLocaLoca(loca.Noun_Fliesen, "Noun_Fliesen"));

            CA!.Noun_Seil = Nouns!.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3263, "Adv_InitializeGame_Person_I_3263"));
            CA!.Noun_Revolver = Nouns!.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3264, "Adv_InitializeGame_Person_I_3264"));
            Nouns.AddLocaLoca(CA!.Noun_Revolver!.ID, loca.Adv_InitializeGame_Person_I_3265, "Adv_InitializeGame_Person_I_3265");
            Nouns.AddLocaLoca(CA!.Noun_Revolver!.ID, loca.Adv_InitializeGame_Person_I_3266, "Adv_InitializeGame_Person_I_3266");
            Nouns.AddLocaLoca(CA!.Noun_Revolver!.ID, loca.Adv_InitializeGame_Person_I_3267, "Adv_InitializeGame_Person_I_3267");
            Nouns.AddLocaLoca(CA!.Noun_Revolver!.ID, loca.Adv_InitializeGame_Person_I_3268, "Adv_InitializeGame_Person_I_3268");
            CA!.Noun_Kram = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3269, "Adv_InitializeGame_Person_I_3269"));
            CA!.Noun_Kissen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3270, "Adv_InitializeGame_Person_I_3270"));
            CA!.Noun_Sonderangebote = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3271, "Adv_InitializeGame_Person_I_3271"));
            CA!.Noun_Sonderangebot = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3272, "Adv_InitializeGame_Person_I_3272"));
            CA!.Noun_Angebot = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3273, "Adv_InitializeGame_Person_I_3273"));
            CA!.Noun_Kiste = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3274, "Adv_InitializeGame_Person_I_3274"));
            CA!.Noun_Schluessel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3275, "Adv_InitializeGame_Person_I_3275"));
            CA!.Noun_Schachtel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3276, "Adv_InitializeGame_Person_I_3276"));
            CA!.Noun_Baumstumpf = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3277, "Adv_InitializeGame_Person_I_3277"));
            CA!.Noun_Helfie = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3278, "Adv_InitializeGame_Person_I_3278"));
            CA!.Noun_Helfer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3279, "Adv_InitializeGame_Person_I_3279"));
            CA!.Noun_Robi = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3280, "Adv_InitializeGame_Person_I_3280"));
            CA!.Noun_Robot = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3281, "Adv_InitializeGame_Person_I_3281"));
            CA!.Noun_Truhe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3282, "Adv_InitializeGame_Person_I_3282"));
            CA!.Noun_Schatztruhe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3283, "Adv_InitializeGame_Person_I_3283"));
            CA!.Noun_Weltfrieden = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3284, "Adv_InitializeGame_Person_I_3284"));
            CA!.Noun_Krieg = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3285, "Adv_InitializeGame_Person_I_3285"));
            CA!.Noun_Tasche = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3286, "Adv_InitializeGame_Person_I_3286"));
            CA!.Noun_Pocket = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Pocket, "Noun_Pocket"));
            CA!.Noun_Dealer = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Dealer, "Noun_Dealer"));
            CA!.Noun_Trader = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Trader, "Noun_Trader"));
            CA!.Noun_Hamberder = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3287, "Adv_InitializeGame_Person_I_3287"));
            CA!.Noun_Hamburger = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3288, "Adv_InitializeGame_Person_I_3288"));
            CA!.Noun_Burger = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3289, "Adv_InitializeGame_Person_I_3289"));
            CA!.Noun_Golfball = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3290, "Adv_InitializeGame_Person_I_3290"));
            CA!.Noun_Buch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3291, "Adv_InitializeGame_Person_I_3291"));
            CA!.Noun_Zeitungsausschnitt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3292, "Adv_InitializeGame_Person_I_3292"));
            CA!.Noun_Basecap = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3293, "Adv_InitializeGame_Person_I_3293"));
            Nouns!.AddLocaLoca(CA!.Noun_Basecap!.ID, loca.Adv_InitializeGame_Person_I_3294, "Adv_InitializeGame_Person_I_3294");
            Nouns!.AddLocaLoca(CA!.Noun_Basecap!.ID, loca.Adv_InitializeGame_Person_I_3295, "Adv_InitializeGame_Person_I_3295");
            Nouns!.AddLocaLoca(CA!.Noun_Basecap!.ID, loca.Adv_InitializeGame_Person_I_3296, "Adv_InitializeGame_Person_I_3296");
            CA!.Noun_Vorhaenge = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3297, "Adv_InitializeGame_Person_I_3297"));
            CA!.Noun_Vorhang = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3298, "Adv_InitializeGame_Person_I_3298"));
            CA!.Noun_Moebel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3299, "Adv_InitializeGame_Person_I_3299"));
            CA!.Noun_Porzellan = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3300, "Adv_InitializeGame_Person_I_3300"));
            CA!.Noun_Fenster = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3301, "Adv_InitializeGame_Person_I_3301"));
            CA!.Noun_Eingangstuer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3302, "Adv_InitializeGame_Person_I_3302"));
            CA!.Noun_Treppe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3303, "Adv_InitializeGame_Person_I_3303"));
            CA!.Noun_Kellertreppe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3304, "Adv_InitializeGame_Person_I_3304"));
            CA!.Noun_Gelaender = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3305, "Adv_InitializeGame_Person_I_3305"));
            CA!.Noun_Spiegel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3306, "Adv_InitializeGame_Person_I_3306"));
            CA!.Noun_Zauberspiegel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3307, "Adv_InitializeGame_Person_I_3307"));
            CA!.Noun_Zeitung = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3308, "Adv_InitializeGame_Person_I_3308"));
            CA!.Noun_Papier = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3309, "Adv_InitializeGame_Person_I_3309"));
            CA!.Noun_Ausschnitt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3310, "Adv_InitializeGame_Person_I_3310"));
            CA!.Noun_Regal = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3311, "Adv_InitializeGame_Person_I_3311"));
            CA!.Noun_Manual = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3312, "Adv_InitializeGame_Person_I_3312"));
            Nouns.AddLocaLoca(CA!.Noun_Manual!.ID, loca.Adv_InitializeGame_Person_I_3313, "Adv_InitializeGame_Person_I_3313");
            CA!.Noun_Sand = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3314, "Adv_InitializeGame_Person_I_3314"));
            CA!.Noun_Muscheln = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3315, "Adv_InitializeGame_Person_I_3315"));
            CA!.Noun_Tuer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3316, "Adv_InitializeGame_Person_I_3316"));
            CA!.Noun_Sandkoerner = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3317, "Adv_InitializeGame_Person_I_3317"));
            CA!.Noun_Sven = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3318, "Adv_InitializeGame_Person_I_3318"));
            CA!.Noun_Irrer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3319, "Adv_InitializeGame_Person_I_3319"));
            CA!.Noun_Draht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3320, "Adv_InitializeGame_Person_I_3320"));
            CA!.Noun_Meer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3321, "Adv_InitializeGame_Person_I_3321"));
            CA!.Noun_Fahrstuhl = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3322, "Adv_InitializeGame_Person_I_3322"));
            CA!.Noun_Palme = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3323, "Adv_InitializeGame_Person_I_3323"));
            CA!.Noun_Schild = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3324, "Adv_InitializeGame_Person_I_3324"));
            CA!.Noun_Wald = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3325, "Adv_InitializeGame_Person_I_3325"));
            CA!.Noun_Muscheln = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3326, "Adv_InitializeGame_Person_I_3326"));
            CA!.Noun_Kieselstrand = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3327, "Adv_InitializeGame_Person_I_3327"));
            CA!.Noun_Kiesel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3328, "Adv_InitializeGame_Person_I_3328"));
            CA!.Noun_Strand = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3329, "Adv_InitializeGame_Person_I_3329"));
            CA!.Noun_Busch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3330, "Adv_InitializeGame_Person_I_3330"));
            CA!.Noun_Decke = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3331, "Adv_InitializeGame_Person_I_3331"));
            CA!.Noun_Wand = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3332, "Adv_InitializeGame_Person_I_3332"));
            CA!.Noun_Kaninchenhoehle = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3333, "Adv_InitializeGame_Person_I_3333"));
            CA!.Noun_Kaninchenhoehle = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3334, "Adv_InitializeGame_Person_I_3334"));
            CA!.Noun_Kaninchenhoehle = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3335, "Adv_InitializeGame_Person_I_3335"));
            CA!.Noun_Waldgras = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3336, "Adv_InitializeGame_Person_I_3336"));
            CA!.Noun_Zweige = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3337, "Adv_InitializeGame_Person_I_3337"));
            CA!.Noun_Zweig = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3338, "Adv_InitializeGame_Person_I_3338"));
            CA!.Noun_Messer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3339, "Adv_InitializeGame_Person_I_3339"));
            CA!.Noun_Gebuesch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3340, "Adv_InitializeGame_Person_I_3340"));
            CA!.Noun_Papagei = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3341, "Adv_InitializeGame_Person_I_3341"));
            CA!.Noun_Stock = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3342, "Adv_InitializeGame_Person_I_3342"));
            CA!.Noun_Erdhuegel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3343, "Adv_InitializeGame_Person_I_3343"));
            CA!.Noun_Ast = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3344, "Adv_InitializeGame_Person_I_3344"));
            CA!.Noun_Ameisenhaufen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3345, "Adv_InitializeGame_Person_I_3345"));
            CA!.Noun_Brombeerstraeucher = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3346, "Adv_InitializeGame_Person_I_3346"));
            CA!.Noun_Brombeerstraeucher = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3347, "Adv_InitializeGame_Person_I_3347"));
            CA!.Noun_Straeucher = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3348, "Adv_InitializeGame_Person_I_3348"));
            CA!.Noun_Strauch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3349, "Adv_InitializeGame_Person_I_3349"));
            CA!.Noun_Verschlag = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3350, "Adv_InitializeGame_Person_I_3350"));
            CA!.Noun_Huette = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3351, "Adv_InitializeGame_Person_I_3351"));
            CA!.Noun_Eremit = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3352, "Adv_InitializeGame_Person_I_3352"));
            CA!.Noun_Eimerchen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3353, "Adv_InitializeGame_Person_I_3353"));
            CA!.Noun_Keller = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3354, "Adv_InitializeGame_Person_I_3354"));
            CA!.Noun_Seildraht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3355, "Adv_InitializeGame_Person_I_3355"));
            CA!.Noun_Kobra = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3356, "Adv_InitializeGame_Person_I_3356"));
            CA!.Noun_Haselstrauch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3357, "Adv_InitializeGame_Person_I_3357"));
            CA!.Noun_Gras = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3358, "Adv_InitializeGame_Person_I_3358"));
            CA!.Noun_Astseil = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3359, "Adv_InitializeGame_Person_I_3359"));
            CA!.Noun_Fishing = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Fishing, "Noun_Fishing"));
            CA!.Noun_Angel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3360, "Adv_InitializeGame_Person_I_3360"));
            CA!.Noun_Gewandtasche = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3361, "Adv_InitializeGame_Person_I_3361"));
            CA!.Noun_Boden = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3362, "Adv_InitializeGame_Person_I_3362"));
            CA!.Noun_Bodendielen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3363, "Adv_InitializeGame_Person_I_3363"));
            CA!.Noun_Cracker = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3364, "Adv_InitializeGame_Person_I_3364"));
            CA!.Noun_Crackers = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Crackers, "Noun_Crackers"));
            CA!.Noun_Crackerschachtel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3365, "Adv_InitializeGame_Person_I_3365"));
            CA!.Noun_Dielen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3366, "Adv_InitializeGame_Person_I_3366"));
            CA!.Noun_Grillzange = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3367, "Adv_InitializeGame_Person_I_3367"));
            CA!.Noun_Herd = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3368, "Adv_InitializeGame_Person_I_3368"));
            CA!.Noun_Kaefig = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3369, "Adv_InitializeGame_Person_I_3369"));
            CA!.Noun_Keks = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3370, "Adv_InitializeGame_Person_I_3370"));
            CA!.Noun_Lampe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3371, "Adv_InitializeGame_Person_I_3371"));
            CA!.Noun_Laterne = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3372, "Adv_InitializeGame_Person_I_3372"));
            CA!.Noun_Ritz = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3373, "Adv_InitializeGame_Person_I_3373"));
            CA!.Noun_Schachtel_mit_Crackern = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3374, "Adv_InitializeGame_Person_I_3374"));
            CA!.Noun_Akten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3375, "Adv_InitializeGame_Person_I_3375"));
            CA!.Noun_Schrank = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3376, "Adv_InitializeGame_Person_I_3376"));
            CA!.Noun_Kuechenschrank = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Kuechenschrank, "Noun_Kuechenschrank"));
            CA!.Noun_Zelle = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3377, "Adv_InitializeGame_Person_I_3377"));
            CA!.Noun_Streichholzbriefchen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3378, "Adv_InitializeGame_Person_I_3378"));
            CA!.Noun_Streichhoelzer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3379, "Adv_InitializeGame_Person_I_3379"));
            CA!.Noun_Vogelbauer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3380, "Adv_InitializeGame_Person_I_3380"));
            CA!.Noun_Cage = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Cage, "Noun_Cage"));
            CA!.Noun_Zange = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3381, "Adv_InitializeGame_Person_I_3381"));
            CA!.Noun_Vogelkaefig = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3382, "Adv_InitializeGame_Person_I_3382"));
            CA!.Noun_Astgabel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3383, "Adv_InitializeGame_Person_I_3383"));
            CA!.Noun_Eiche = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3384, "Adv_InitializeGame_Person_I_3384"));
            CA!.Noun_Fluestertuete = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3385, "Adv_InitializeGame_Person_I_3385"));
            CA!.Noun_Megafon = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3386, "Adv_InitializeGame_Person_I_3386"));
            CA!.Noun_Bett = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3387, "Adv_InitializeGame_Person_I_3387"));
            CA!.Noun_Himmelbett = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3388, "Adv_InitializeGame_Person_I_3388"));
            CA!.Noun_Sitzgarnitur = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3389, "Adv_InitializeGame_Person_I_3389"));
            CA!.Noun_Schatzkiste = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3390, "Adv_InitializeGame_Person_I_3390"));
            CA!.Noun_Geruempel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3391, "Adv_InitializeGame_Person_I_3391"));
            Nouns.AddLocaLoca(CA!.Noun_Geruempel!.ID, loca.Adv_InitializeGame_Person_I_3392, "Adv_InitializeGame_Person_I_3392");
            CA!.Noun_Tisch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3393, "Adv_InitializeGame_Person_I_3393"));
            CA!.Noun_Stuhl = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3394, "Adv_InitializeGame_Person_I_3394"));
            CA!.Noun_Baeume = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3395, "Adv_InitializeGame_Person_I_3395"));
            CA!.Noun_Baum = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3396, "Adv_InitializeGame_Person_I_3396"));
            CA!.Noun_Bucht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3397, "Adv_InitializeGame_Person_I_3397"));
            CA!.Noun_Felsen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3398, "Adv_InitializeGame_Person_I_3398"));
            CA!.Noun_Fels = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3399, "Adv_InitializeGame_Person_I_3399"));
            CA!.Noun_Frank = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3400, "Adv_InitializeGame_Person_I_3400"));
            CA!.Noun_Cannon = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3401, "Adv_InitializeGame_Person_I_3401"));
            CA!.Noun_Brombeeren = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3402, "Adv_InitializeGame_Person_I_3402"));
            CA!.Noun_Truemmer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3403, "Adv_InitializeGame_Person_I_3403"));
            CA!.Noun_Rad = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3404, "Adv_InitializeGame_Person_I_3404"));
            CA!.Noun_Kutsche = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3405, "Adv_InitializeGame_Person_I_3405"));
            CA!.Noun_Korn = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3406, "Adv_InitializeGame_Person_I_3406"));
            CA!.Noun_Achse = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3407, "Adv_InitializeGame_Person_I_3407"));
            CA!.Noun_Eimer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3408, "Adv_InitializeGame_Person_I_3408"));
            CA!.Noun_Pfad = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3409, "Adv_InitializeGame_Person_I_3409"));
            CA!.Noun_Buschwerk = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3410, "Adv_InitializeGame_Person_I_3410"));
            CA!.Noun_Oberflaeche = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3411, "Adv_InitializeGame_Person_I_3411"));
            CA!.Noun_Kokosnuesse = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3412, "Adv_InitializeGame_Person_I_3412"));
            CA!.Noun_Kokosnuss = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3413, "Adv_InitializeGame_Person_I_3413"));
            CA!.Noun_Nuesse = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3414, "Adv_InitializeGame_Person_I_3414"));
            CA!.Noun_Nuss = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3415, "Adv_InitializeGame_Person_I_3415"));
            CA!.Noun_Licht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3416, "Adv_InitializeGame_Person_I_3416"));
            CA!.Noun_Schimmer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3417, "Adv_InitializeGame_Person_I_3417"));
            CA!.Noun_Lichtschimmer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3418, "Adv_InitializeGame_Person_I_3418"));
            CA!.Noun_Stufe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3419, "Adv_InitializeGame_Person_I_3419"));
            CA!.Noun_Stufen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3420, "Adv_InitializeGame_Person_I_3420"));
            CA!.Noun_Ameise = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3421, "Adv_InitializeGame_Person_I_3421"));
            CA!.Noun_Ameisen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3422, "Adv_InitializeGame_Person_I_3422"));
            CA!.Noun_Waldameise = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3423, "Adv_InitializeGame_Person_I_3423"));
            CA!.Noun_Waldameisen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3424, "Adv_InitializeGame_Person_I_3424"));
            CA!.Noun_Senke = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3425, "Adv_InitializeGame_Person_I_3425"));
            CA!.Noun_Lagerverwalter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3426, "Adv_InitializeGame_Person_I_3426"));
            CA!.Noun_Verwalter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3427, "Adv_InitializeGame_Person_I_3427"));
            CA!.Noun_Lagerist = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3428, "Adv_InitializeGame_Person_I_3428"));
            CA!.Noun_Kapitaen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3429, "Adv_InitializeGame_Person_I_3429"));
            CA!.Noun_Ahab = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3430, "Adv_InitializeGame_Person_I_3430"));
            CA!.Noun_Schankwirtin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3431, "Adv_InitializeGame_Person_I_3431"));
            CA!.Noun_Wirtin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3432, "Adv_InitializeGame_Person_I_3432"));
            CA!.Noun_Kneipenwirtin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3433, "Adv_InitializeGame_Person_I_3433"));
            CA!.Noun_Luegian = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3434, "Adv_InitializeGame_Person_I_3434"));
            CA!.Noun_Speichelt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3435, "Adv_InitializeGame_Person_I_3435"));
            CA!.Noun_Marineoffizier = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3436, "Adv_InitializeGame_Person_I_3436"));
            CA!.Noun_Offizier = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3437, "Adv_InitializeGame_Person_I_3437"));
            CA!.Noun_Redakteur = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3438, "Adv_InitializeGame_Person_I_3438"));
            CA!.Noun_Luegner = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3439, "Adv_InitializeGame_Person_I_3439"));
            CA!.Noun_Verleumder = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3440, "Adv_InitializeGame_Person_I_3440"));
            CA!.Noun_Pit = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3441, "Adv_InitializeGame_Person_I_3441"));
            CA!.Noun_Paula = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3442, "Adv_InitializeGame_Person_I_3442"));
            CA!.Noun_Paracelsus = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3443, "Adv_InitializeGame_Person_I_3443"));
            CA!.Noun_Arzt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3444, "Adv_InitializeGame_Person_I_3444"));
            CA!.Noun_Aerztin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3445, "Adv_InitializeGame_Person_I_3445"));
            CA!.Noun_Harpune = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3446, "Adv_InitializeGame_Person_I_3446"));
            CA!.Noun_Pflaster = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3447, "Adv_InitializeGame_Person_I_3447"));
            CA!.Noun_Pflasterstein = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3448, "Adv_InitializeGame_Person_I_3448"));
            CA!.Noun_Tor = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3449, "Adv_InitializeGame_Person_I_3449"));
            CA!.Noun_Bar = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3450, "Adv_InitializeGame_Person_I_3450"));
            CA!.Noun_Hafenbar = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3451, "Adv_InitializeGame_Person_I_3451"));
            CA!.Noun_Hafenkaschemme = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3452, "Adv_InitializeGame_Person_I_3452"));
            CA!.Noun_Hafenkneipe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3453, "Adv_InitializeGame_Person_I_3453"));
            CA!.Noun_Hafenpinte = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3454, "Adv_InitializeGame_Person_I_3454"));
            CA!.Noun_Kaschemme = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3455, "Adv_InitializeGame_Person_I_3455"));
            CA!.Noun_Klohaeuschen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3456, "Adv_InitializeGame_Person_I_3456"));
            CA!.Noun_Klopapier = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3457, "Adv_InitializeGame_Person_I_3457"));
            CA!.Noun_Presseausweis = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3458, "Adv_InitializeGame_Person_I_3458"));
            CA!.Noun_Kneipe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3459, "Adv_InitializeGame_Person_I_3459"));
            CA!.Noun_Lagerhaus = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3460, "Adv_InitializeGame_Person_I_3460"));
            CA!.Noun_Lagerhaus_e = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Lagerhaus_e, "Noun_Lagerhaus_e"));
            CA!.Noun_Lagerhouse = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Lagerhouse, "Noun_Lagerhouse"));
            CA!.Noun_Pinte = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3461, "Adv_InitializeGame_Person_I_3461"));
            CA!.Noun_Schiff = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3462, "Adv_InitializeGame_Person_I_3462"));
            CA!.Noun_Verlag = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3463, "Adv_InitializeGame_Person_I_3463"));
            CA!.Noun_Haken = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3464, "Adv_InitializeGame_Person_I_3464"));
            CA!.Noun_Prospekt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3465, "Adv_InitializeGame_Person_I_3465"));
            CA!.Noun_Badge = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3466, "Adv_InitializeGame_Person_I_3466"));
            CA!.Noun_Dennis = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3467, "Adv_InitializeGame_Person_I_3467"));
            CA!.Noun_Handelsvertreter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3468, "Adv_InitializeGame_Person_I_3468"));
            CA!.Noun_Kuh = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3469, "Adv_InitializeGame_Person_I_3469"));
            CA!.Noun_Mechaniker = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3470, "Adv_InitializeGame_Person_I_3470"));
            CA!.Noun_Schraubenschluessel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3471, "Adv_InitializeGame_Person_I_3471"));
            CA!.Noun_Waltraud = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3472, "Adv_InitializeGame_Person_I_3472"));
            CA!.Noun_Woods = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3473, "Adv_InitializeGame_Person_I_3473"));
            CA!.Noun_Bank = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3474, "Adv_InitializeGame_Person_I_3474"));
            CA!.Noun_Barhocker = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3475, "Adv_InitializeGame_Person_I_3475"));
            CA!.Noun_Druckmaschine = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3476, "Adv_InitializeGame_Person_I_3476"));
            CA!.Noun_Fensterbank = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3477, "Adv_InitializeGame_Person_I_3477"));
            CA!.Noun_Hahn = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3478, "Adv_InitializeGame_Person_I_3478"));
            CA!.Noun_Hocker = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3479, "Adv_InitializeGame_Person_I_3479"));
            CA!.Noun_Manuskript = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3480, "Adv_InitializeGame_Person_I_3480"));
            CA!.Noun_Papierausgabe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3481, "Adv_InitializeGame_Person_I_3481"));
            CA!.Noun_Tresen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3482, "Adv_InitializeGame_Person_I_3482"));
            CA!.Noun_Wagenheber = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3483, "Adv_InitializeGame_Person_I_3483"));
            CA!.Noun_Zapfhahn = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3484, "Adv_InitializeGame_Person_I_3484"));
            CA!.Noun_Du = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3485, "Adv_InitializeGame_Person_I_3485"));
            Nouns.AddLocaLoca(CA!.Noun_Du!.ID, loca.Adv_InitializeGame_Person_I_3486, "Adv_InitializeGame_Person_I_3486");
            Nouns.AddLocaLoca(CA!.Noun_Du!.ID, loca.Pronoun_dir, "Pronoun_dir");
            CA!.Noun_Ich = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3487, "Adv_InitializeGame_Person_I_3487"));
            Nouns.AddLocaLoca(CA!.Noun_Ich!.ID, loca.Adv_InitializeGame_Person_I_3488, "Adv_InitializeGame_Person_I_3488");
            CA!.Noun_Handschellen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3489, "Adv_InitializeGame_Person_I_3489"));
            CA!.Noun_Beamter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3490, "Adv_InitializeGame_Person_I_3490"));
            CA!.Noun_Postbeamter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3491, "Adv_InitializeGame_Person_I_3491"));
            CA!.Noun_Radfuehrung = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3492, "Adv_InitializeGame_Person_I_3492"));
            CA!.Noun_Radaufhaengung = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3493, "Adv_InitializeGame_Person_I_3493"));
            CA!.Noun_Pferd = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3494, "Adv_InitializeGame_Person_I_3494"));
            CA!.Noun_Formulare = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3495, "Adv_InitializeGame_Person_I_3495"));
            CA!.Noun_Formular = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3496, "Adv_InitializeGame_Person_I_3496"));
            CA!.Noun_Ross = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3497, "Adv_InitializeGame_Person_I_3497"));
            CA!.Noun_Schalter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3498, "Adv_InitializeGame_Person_I_3498"));
            CA!.Noun_Blumenkohl = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3499, "Adv_InitializeGame_Person_I_3499"));
            CA!.Noun_Blumenkohlgehirn = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3500, "Adv_InitializeGame_Person_I_3500"));
            CA!.Noun_Kohl = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3501, "Adv_InitializeGame_Person_I_3501"));
            CA!.Noun_Bogen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3502, "Adv_InitializeGame_Person_I_3502"));
            CA!.Noun_Brief = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3503, "Adv_InitializeGame_Person_I_3503"));
            CA!.Noun_Briefumschlag = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3504, "Adv_InitializeGame_Person_I_3504"));
            CA!.Noun_Brille = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3505, "Adv_InitializeGame_Person_I_3505"));
            CA!.Noun_Frame = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Frame, "Noun_Frame"));
            CA!.Noun_Cocktailglas = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3506, "Adv_InitializeGame_Person_I_3506"));
            CA!.Noun_Dose = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3507, "Adv_InitializeGame_Person_I_3507"));
            CA!.Noun_Dosen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3508, "Adv_InitializeGame_Person_I_3508"));
            CA!.Noun_Konserven = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3509, "Adv_InitializeGame_Person_I_3509"));
            CA!.Noun_Konserve = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3510, "Adv_InitializeGame_Person_I_3510"));
            CA!.Noun_Dosenoeffner = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3511, "Adv_InitializeGame_Person_I_3511"));
            CA!.Noun_Fleisch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3512, "Adv_InitializeGame_Person_I_3512"));
            CA!.Noun_Hack = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3513, "Adv_InitializeGame_Person_I_3513"));
            CA!.Noun_Foto = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3514, "Adv_InitializeGame_Person_I_3514"));
            CA!.Noun_Gebiss = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3515, "Adv_InitializeGame_Person_I_3515"));
            CA!.Noun_Vampirgebiss = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3516, "Adv_InitializeGame_Person_I_3516"));
            CA!.Noun_Gehirn = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3517, "Adv_InitializeGame_Person_I_3517"));
            CA!.Noun_Giesskanne = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3518, "Adv_InitializeGame_Person_I_3518"));
            CA!.Noun_Drink = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3519, "Adv_InitializeGame_Person_I_3519"));
            CA!.Noun_Giftflakon = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3520, "Adv_InitializeGame_Person_I_3520"));
            CA!.Noun_Kamera = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3521, "Adv_InitializeGame_Person_I_3521"));
            CA!.Noun_Kaleidoskop = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3522, "Adv_InitializeGame_Person_I_3522"));
            CA!.Noun_Schatz = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3523, "Adv_InitializeGame_Person_I_3523"));
            CA!.Noun_Pracht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Pracht, "Adv_InitializeGame_Pracht"));
            CA!.Noun_Schlaftabletten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3524, "Adv_InitializeGame_Person_I_3524"));
            Nouns.AddLocaLoca(CA!.Noun_Schlaftabletten!.ID, loca.Adv_InitializeGame_Person_I_3525, "Adv_InitializeGame_Person_I_3525");
            CA!.Noun_Spielgeld = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3526, "Adv_InitializeGame_Person_I_3526"));
            Nouns.AddLocaLoca(CA!.Noun_Spielgeld!.ID, loca.Adv_InitializeGame_Person_I_3527, "Adv_InitializeGame_Person_I_3527");
            CA!.Noun_Spielgeldbogen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3528, "Adv_InitializeGame_Person_I_3528"));
            CA!.Noun_Stapel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3529, "Adv_InitializeGame_Person_I_3529"));
            CA!.Noun_Ziegel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3530, "Adv_InitializeGame_Person_I_3530"));
            CA!.Noun_Ziegelstein = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3531, "Adv_InitializeGame_Person_I_3531"));
            CA!.Noun_Schluesselbund = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3532, "Adv_InitializeGame_Person_I_3532"));
            CA!.Noun_Alfonsius_Statuette = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3533, "Adv_InitializeGame_Person_I_3533"));
            CA!.Noun_Briefe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3534, "Adv_InitializeGame_Person_I_3534"));
            CA!.Noun_Cocktail = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3535, "Adv_InitializeGame_Person_I_3535"));
            CA!.Noun_Corona = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Corona, "Adv_InitializeGame_Corona"));
            CA!.Noun_Dartscheibe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3536, "Adv_InitializeGame_Person_I_3536"));
            Nouns.AddLocaLoca(CA!.Noun_Dartscheibe!.ID, loca.Adv_InitializeGame_Person_I_3537, "Adv_InitializeGame_Person_I_3537");
            CA!.Noun_Fass = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3538, "Adv_InitializeGame_Person_I_3538"));
            CA!.Noun_Fensterglas = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3539, "Adv_InitializeGame_Person_I_3539"));
            Nouns.AddLocaLoca(CA!.Noun_Fensterglas!.ID, loca.Adv_InitializeGame_Person_I_3540, "Adv_InitializeGame_Person_I_3540");
            CA!.Noun_Fleischwanne = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3541, "Adv_InitializeGame_Person_I_3541"));
            CA!.Noun_Flugblaetter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3542, "Adv_InitializeGame_Person_I_3542"));
            CA!.Noun_Getraenk = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3543, "Adv_InitializeGame_Person_I_3543"));
            CA!.Noun_Gutachten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3544, "Adv_InitializeGame_Person_I_3544"));
            CA!.Noun_Hackfleisch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3545, "Adv_InitializeGame_Person_I_3545"));
            CA!.Noun_Hose = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3546, "Adv_InitializeGame_Person_I_3546"));
            CA!.Noun_Karren = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3547, "Adv_InitializeGame_Person_I_3547"));
            CA!.Noun_Kelle = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3548, "Adv_InitializeGame_Person_I_3548"));
            CA!.Noun_Laubsaege = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3549, "Adv_InitializeGame_Person_I_3549"));
            CA!.Noun_Lieferschein = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3550, "Adv_InitializeGame_Person_I_3550"));
            CA!.Noun_Abholschein = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3551, "Adv_InitializeGame_Person_I_3551"));
            CA!.Noun_Postkarte = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3552, "Adv_InitializeGame_Person_I_3552"));
            CA!.Noun_Karte = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3553, "Adv_InitializeGame_Person_I_3553"));
            CA!.Noun_Regenwuermer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3554, "Adv_InitializeGame_Person_I_3554"));
            CA!.Noun_Scherbe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3555, "Adv_InitializeGame_Person_I_3555"));
            CA!.Noun_Senffaesschen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3556, "Adv_InitializeGame_Person_I_3556"));
            CA!.Noun_Sinnspruch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3557, "Adv_InitializeGame_Person_I_3557"));
            CA!.Noun_Statuette = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3558, "Adv_InitializeGame_Person_I_3558"));
            CA!.Noun_Taucheranzughose = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3559, "Adv_InitializeGame_Person_I_3559"));
            CA!.Noun_Umruehrstab = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3560, "Adv_InitializeGame_Person_I_3560"));
            Nouns.AddLocaLoca(CA!.Noun_Umruehrstab!.ID, loca.Adv_InitializeGame_Umruehrstab, "Adv_InitializeGame_Umruehrstab");
            CA!.Noun_stirring = Nouns.Add(Noun.NounLocaLoca(loca.Noun_stirring, "Noun_stirring"));
            CA!.Noun_Zuckerpaeckchen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3561, "Adv_InitializeGame_Person_I_3561"));
            CA!.Noun_Baconstreifen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3562, "Adv_InitializeGame_Person_I_3562"));
            CA!.Noun_Bettbezug = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3563, "Adv_InitializeGame_Person_I_3563"));
            CA!.Noun_Felsbrocken = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3564, "Adv_InitializeGame_Person_I_3564"));
            CA!.Noun_Feudel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3565, "Adv_InitializeGame_Person_I_3565"));
            CA!.Noun_Cloth = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Cloth, "Noun_Cloth"));
            CA!.Noun_Feuerzeug = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3566, "Adv_InitializeGame_Person_I_3566"));
            CA!.Noun_Frischhaltefolie = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3567, "Adv_InitializeGame_Person_I_3567"));
            CA!.Noun_Gefaess = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3568, "Adv_InitializeGame_Person_I_3568"));
            CA!.Noun_Spachtelmasse = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3569, "Adv_InitializeGame_Person_I_3569"));
            CA!.Noun_Spachtel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3570, "Adv_InitializeGame_Person_I_3570"));
            CA!.Noun_Masse = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3571, "Adv_InitializeGame_Person_I_3571"));
            CA!.Noun_Glas = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3572, "Adv_InitializeGame_Person_I_3572"));
            Nouns.AddLocaLoca(CA!.Noun_Glas!.ID, loca.Adv_InitializeGame_Person_I_3573, "Adv_InitializeGame_Person_I_3573");
            CA!.Noun_Brillenglas = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3574, "Adv_InitializeGame_Person_I_3574"));
            CA!.Noun_Hanfseil = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3575, "Adv_InitializeGame_Person_I_3575"));
            CA!.Noun_Hightech_Fessel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3576, "Adv_InitializeGame_Person_I_3576"));
            CA!.Noun_Hightech = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3577, "Adv_InitializeGame_Person_I_3577"));
            CA!.Noun_Fessel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3578, "Adv_InitializeGame_Person_I_3578"));
            CA!.Noun_Holzstueck = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3579, "Adv_InitializeGame_Person_I_3579"));
            CA!.Noun_Kanister = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3580, "Adv_InitializeGame_Person_I_3580"));
            CA!.Noun_Verduennung = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Verduennung, "Adv_InitializeGame_Verduennung"));
            CA!.Noun_Oel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3581, "Adv_InitializeGame_Person_I_3581"));
            CA!.Noun_Lotterielos = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3582, "Adv_InitializeGame_Person_I_3582"));
            CA!.Noun_Lotterie = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3583, "Adv_InitializeGame_Person_I_3583"));
            CA!.Noun_Megaphon = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3584, "Adv_InitializeGame_Person_I_3584"));
            CA!.Noun_Metallstueck = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3585, "Adv_InitializeGame_Person_I_3585"));
            CA!.Noun_Papierboegen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3586, "Adv_InitializeGame_Person_I_3586"));
            CA!.Noun_Patties = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3587, "Adv_InitializeGame_Person_I_3587"));
            CA!.Noun_Stimme = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3588, "Adv_InitializeGame_Person_I_3588"));
            CA!.Noun_Pattie = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3589, "Adv_InitializeGame_Person_I_3589"));
            CA!.Noun_Permanentmarker = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3590, "Adv_InitializeGame_Person_I_3590"));
            Nouns.AddLocaLoca(CA!.Noun_Permanentmarker!.ID, loca.Adv_InitializeGame_Person_I_3591, "Adv_InitializeGame_Person_I_3591");
            CA!.Noun_Peruecke = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3592, "Adv_InitializeGame_Person_I_3592"));
            CA!.Noun_Phoney_Island_Gin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3593, "Adv_InitializeGame_Person_I_3593"));
            CA!.Noun_Ratte = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3594, "Adv_InitializeGame_Person_I_3594"));
            CA!.Noun_Schaufelchen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3595, "Adv_InitializeGame_Person_I_3595"));
            Nouns.AddLocaLoca(CA!.Noun_Schaufelchen!.ID, loca.Adv_InitializeGame_Person_I_3596, "Adv_InitializeGame_Person_I_3596");
            CA!.Noun_Schaukelpferd = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3597, "Adv_InitializeGame_Person_I_3597"));
            CA!.Noun_Schlauch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3598, "Adv_InitializeGame_Person_I_3598"));
            CA!.Noun_Schuerze = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3599, "Adv_InitializeGame_Person_I_3599"));
            CA!.Noun_Sprengsatz = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3600, "Adv_InitializeGame_Person_I_3600"));
            CA!.Noun_Bombe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3601, "Adv_InitializeGame_Person_I_3601"));
            CA!.Noun_Stein = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3602, "Adv_InitializeGame_Person_I_3602"));
            CA!.Noun_Steinschleuder = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3603, "Adv_InitializeGame_Person_I_3603"));
            CA!.Noun_Visitenkarte = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3604, "Adv_InitializeGame_Person_I_3604"));
            CA!.Noun_Zustellkarte = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3605, "Adv_InitializeGame_Person_I_3605"));
            CA!.Noun_Bart = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3606, "Adv_InitializeGame_Person_I_3606"));
            CA!.Noun_Berder_Kadaver = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3607, "Adv_InitializeGame_Person_I_3607"));
            CA!.Noun_Bescheinigung = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3608, "Adv_InitializeGame_Person_I_3608"));
            CA!.Noun_Blasebalg = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3609, "Adv_InitializeGame_Person_I_3609"));
            CA!.Noun_Botanikbuch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3610, "Adv_InitializeGame_Person_I_3610"));
            CA!.Noun_Botanikbuecher = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3611, "Adv_InitializeGame_Person_I_3611"));
            CA!.Noun_Buessergewand = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3612, "Adv_InitializeGame_Person_I_3612"));
            CA!.Noun_Einschreiben = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3613, "Adv_InitializeGame_Person_I_3613"));
            CA!.Noun_Eisenstange = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3614, "Adv_InitializeGame_Person_I_3614"));
            CA!.Noun_Kartoffelsack = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3615, "Adv_InitializeGame_Person_I_3615"));
            CA!.Noun_Kette = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3616, "Adv_InitializeGame_Person_I_3616"));
            CA!.Noun_Kneifzange = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3617, "Adv_InitializeGame_Person_I_3617"));
            CA!.Noun_Knurznurznuss = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3618, "Adv_InitializeGame_Person_I_3618"));
            CA!.Noun_Kondome = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3619, "Adv_InitializeGame_Person_I_3619"));
            CA!.Noun_Kondom = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3620, "Adv_InitializeGame_Person_I_3620"));
            CA!.Noun_Praeser = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3621, "Adv_InitializeGame_Person_I_3621"));
            CA!.Noun_Luemmeltuete = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3622, "Adv_InitializeGame_Person_I_3622"));
            CA!.Noun_Luemmeltueten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3623, "Adv_InitializeGame_Person_I_3623"));
            CA!.Noun_Leiche = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3624, "Adv_InitializeGame_Person_I_3624"));
            CA!.Noun_Lippenstift_Nachricht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3625, "Adv_InitializeGame_Person_I_3625"));
            CA!.Noun_Mitteilung = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3626, "Adv_InitializeGame_Person_I_3626"));
            CA!.Noun_Peitschen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3627, "Adv_InitializeGame_Person_I_3627"));
            CA!.Noun_Raupe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3628, "Adv_InitializeGame_Person_I_3628"));
            CA!.Noun_Sack = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3629, "Adv_InitializeGame_Person_I_3629"));
            CA!.Noun_Schaufel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3630, "Adv_InitializeGame_Person_I_3630"));
            CA!.Noun_Schlafmohn = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3631, "Adv_InitializeGame_Person_I_3631"));
            CA!.Noun_Schlommi = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3632, "Adv_InitializeGame_Person_I_3632"));
            CA!.Noun_Schloss = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3633, "Adv_InitializeGame_Person_I_3633"));
            CA!.Noun_Vorhaengeschloss = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3634, "Adv_InitializeGame_Person_I_3634"));
            CA!.Noun_Schraubenzieher = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3635, "Adv_InitializeGame_Person_I_3635"));
            CA!.Noun_Umschlag = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3636, "Adv_InitializeGame_Person_I_3636"));
            CA!.Noun_Zellenschluessel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3637, "Adv_InitializeGame_Person_I_3637"));
            CA!.Noun_Nullbehaelter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3638, "Adv_InitializeGame_Person_I_3638"));
            CA!.Noun_Francesco = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3639, "Adv_InitializeGame_Person_I_3639"));
            CA!.Noun_Ghoul = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3640, "Adv_InitializeGame_Person_I_3640"));
            Nouns.AddLocaLoca(CA!.Noun_Ghoul!.ID, loca.Adv_InitializeGame_Person_I_3641, "Adv_InitializeGame_Person_I_3641");
            CA!.Noun_Phoney = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3642, "Adv_InitializeGame_Person_I_3642"));
            Nouns.AddLocaLoca(CA!.Noun_Phoney!.ID, loca.Adv_InitializeGame_Person_I_3643, "Adv_InitializeGame_Person_I_3643");
            CA!.Noun_Scaramango = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3644, "Adv_InitializeGame_Person_I_3644"));
            CA!.Noun_Messias = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3645, "Adv_InitializeGame_Person_I_3645"));
            CA!.Noun_Stroh = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3646, "Adv_InitializeGame_Person_I_3646"));
            CA!.Noun_Lager = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3647, "Adv_InitializeGame_Person_I_3647"));
            CA!.Noun_Schlaflager = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3648, "Adv_InitializeGame_Person_I_3648"));
            CA!.Noun_Zellentuer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3649, "Adv_InitializeGame_Person_I_3649"));
            CA!.Noun_Dolly = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3650, "Adv_InitializeGame_Person_I_3650"));
            CA!.Noun_Something = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Something, "Noun_Something"));
            CA!.Noun_Gemaelde = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3651, "Adv_InitializeGame_Person_I_3651"));
            CA!.Noun_Kamin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3652, "Adv_InitializeGame_Person_I_3652"));
            CA!.Noun_Leuchter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3653, "Adv_InitializeGame_Person_I_3653"));
            CA!.Noun_Podest = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3654, "Adv_InitializeGame_Person_I_3654"));
            CA!.Noun_Sitzbank = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3655, "Adv_InitializeGame_Person_I_3655"));
            CA!.Noun_Stealthy = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3656, "Adv_InitializeGame_Person_I_3656"));
            CA!.Noun_Steven = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3657, "Adv_InitializeGame_Person_I_3657"));
            CA!.Noun_Gestalt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3658, "Adv_InitializeGame_Person_I_3658"));
            CA!.Noun_Schemen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3659, "Adv_InitializeGame_Person_I_3659"));
            CA!.Noun_Teppich = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3660, "Adv_InitializeGame_Person_I_3660"));
            CA!.Noun_Rug = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Rug, "Noun_Rug"));
            CA!.Noun_Thron = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3661, "Adv_InitializeGame_Person_I_3661"));
            CA!.Noun_Zepter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3662, "Adv_InitializeGame_Person_I_3662"));
            CA!.Noun_Wache = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3663, "Adv_InitializeGame_Person_I_3663"));
            Nouns.AddLocaLoca(CA!.Noun_Wache!.ID, loca.Adv_InitializeGame_Person_I_3664, "Adv_InitializeGame_Person_I_3664");
            CA!.Noun_Brueckenwache = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3665, "Adv_InitializeGame_Person_I_3665"));
            Nouns.AddLocaLoca(CA!.Noun_Brueckenwache!.ID, loca.Adv_InitializeGame_Person_I_3666, "Adv_InitializeGame_Person_I_3666");
            CA!.Noun_Mauern = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3667, "Adv_InitializeGame_Person_I_3667"));
            CA!.Noun_Eisentuer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3668, "Adv_InitializeGame_Person_I_3668"));
            CA!.Noun_Muelltonne = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3669, "Adv_InitializeGame_Person_I_3669"));
            CA!.Noun_Bettchen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3670, "Adv_InitializeGame_Person_I_3670"));
            CA!.Noun_Steinbank = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3671, "Adv_InitializeGame_Person_I_3671"));
            CA!.Noun_Felsbalkon = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3672, "Adv_InitializeGame_Person_I_3672"));
            CA!.Noun_Talkessel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3673, "Adv_InitializeGame_Person_I_3673"));
            CA!.Noun_Stadt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3674, "Adv_InitializeGame_Person_I_3674"));
            CA!.Noun_Versammlungsplatz = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3675, "Adv_InitializeGame_Person_I_3675"));
            CA!.Noun_Ketten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3676, "Adv_InitializeGame_Person_I_3676"));
            CA!.Noun_Krokodil = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3677, "Adv_InitializeGame_Person_I_3677"));
            CA!.Noun_Eichenbohlen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3678, "Adv_InitializeGame_Person_I_3678"));
            CA!.Noun_Zugbruecke = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3679, "Adv_InitializeGame_Person_I_3679"));
            CA!.Noun_Graben = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3680, "Adv_InitializeGame_Person_I_3680"));
            CA!.Noun_Blutlachen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3681, "Adv_InitializeGame_Person_I_3681"));
            CA!.Noun_Blutlache = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3682, "Adv_InitializeGame_Person_I_3682"));
            CA!.Noun_Lache = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3683, "Adv_InitializeGame_Person_I_3683"));
            CA!.Noun_Folterinstrumente = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3684, "Adv_InitializeGame_Person_I_3684"));
            CA!.Noun_Nager = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3685, "Adv_InitializeGame_Person_I_3685"));
            CA!.Noun_Streckbank = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3686, "Adv_InitializeGame_Person_I_3686"));
            CA!.Noun_Waende = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3687, "Adv_InitializeGame_Person_I_3687"));
            CA!.Noun_Wendeltreppe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3688, "Adv_InitializeGame_Person_I_3688"));
            CA!.Noun_Brustwehr = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3689, "Adv_InitializeGame_Person_I_3689"));
            CA!.Noun_Brust = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Brust, "Noun_Brust"));
            CA!.Noun_Panoramablick = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3690, "Adv_InitializeGame_Person_I_3690"));
            CA!.Noun_Waelder = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3692, "Adv_InitializeGame_Person_I_3692"));
            CA!.Noun_Buecher = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3693, "Adv_InitializeGame_Person_I_3693"));
            CA!.Noun_Fluegeltuer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3694, "Adv_InitializeGame_Person_I_3694"));
            CA!.Noun_Panoramabild = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3695, "Adv_InitializeGame_Person_I_3695"));
            CA!.Noun_Phiolen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3696, "Adv_InitializeGame_Person_I_3696"));
            CA!.Noun_Regale = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3697, "Adv_InitializeGame_Person_I_3697"));
            CA!.Noun_Schreibtisch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3698, "Adv_InitializeGame_Person_I_3698"));
            CA!.Noun_Schreibtische = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3699, "Adv_InitializeGame_Person_I_3699"));
            CA!.Noun_Sessel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3700, "Adv_InitializeGame_Person_I_3700"));
            CA!.Noun_Stuehlchen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3701, "Adv_InitializeGame_Person_I_3701"));
            CA!.Noun_Geschirr = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3702, "Adv_InitializeGame_Person_I_3702"));
            CA!.Noun_Steinofen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3703, "Adv_InitializeGame_Person_I_3703"));
            CA!.Noun_Middlefinger = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3704, "Adv_InitializeGame_Person_I_3704"));
            CA!.Noun_Toya = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3705, "Adv_InitializeGame_Person_I_3705"));
            CA!.Noun_Tortilla = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3706, "Adv_InitializeGame_Person_I_3706"));
            CA!.Noun_Tony = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3707, "Adv_InitializeGame_Person_I_3707"));
            CA!.Noun_Freshman = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3708, "Adv_InitializeGame_Person_I_3708"));
            CA!.Noun_Tom = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3709, "Adv_InitializeGame_Person_I_3709"));
            CA!.Noun_Jones = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3710, "Adv_InitializeGame_Person_I_3710"));
            CA!.Noun_Sam = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3711, "Adv_InitializeGame_Person_I_3711"));
            CA!.Noun_Graham = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3712, "Adv_InitializeGame_Person_I_3712"));
            CA!.Noun_Statuen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3713, "Adv_InitializeGame_Person_I_3713"));
            CA!.Noun_Panoramen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3714, "Adv_InitializeGame_Person_I_3714"));
            CA!.Noun_Koerbe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3715, "Adv_InitializeGame_Person_I_3715"));
            CA!.Noun_Behaelter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3716, "Adv_InitializeGame_Person_I_3716"));
            CA!.Noun_Baenke = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3717, "Adv_InitializeGame_Person_I_3717"));
            CA!.Noun_Altar = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3718, "Adv_InitializeGame_Person_I_3718"));
            CA!.Noun_Stiege = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3719, "Adv_InitializeGame_Person_I_3719"));
            CA!.Noun_Kellerfenster = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3720, "Adv_InitializeGame_Person_I_3720"));
            CA!.Noun_Sims = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3721, "Adv_InitializeGame_Person_I_3721"));
            CA!.Noun_Schublade = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3722, "Adv_InitializeGame_Person_I_3722"));
            CA!.Noun_Arbeitstisch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3723, "Adv_InitializeGame_Person_I_3723"));
            CA!.Noun_Tralje = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3724, "Adv_InitializeGame_Person_I_3724"));
            CA!.Noun_Lastenaufzug = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3725, "Adv_InitializeGame_Person_I_3725"));
            CA!.Noun_Kordel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3726, "Adv_InitializeGame_Person_I_3726"));
            CA!.Noun_Dosentelefon = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3727, "Adv_InitializeGame_Person_I_3727"));
            CA!.Noun_Biomuell = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3728, "Adv_InitializeGame_Person_I_3728"));
            CA!.Noun_Stoeckchen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3729, "Adv_InitializeGame_Person_I_3729"));
            CA!.Noun_Stoehnen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3730, "Adv_InitializeGame_Person_I_3730"));
            CA!.Noun_Topf = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3731, "Adv_InitializeGame_Person_I_3731"));
            CA!.Noun_Bratensosse = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3732, "Adv_InitializeGame_Person_I_3732"));
            CA!.Noun_Ofen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3733, "Adv_InitializeGame_Person_I_3733"));
            CA!.Noun_Backform = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3734, "Adv_InitializeGame_Person_I_3734"));
            CA!.Noun_Kellertuer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3735, "Adv_InitializeGame_Person_I_3735"));
            CA!.Noun_Bild = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3736, "Adv_InitializeGame_Person_I_3736"));
            CA!.Noun_Schrein = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3737, "Adv_InitializeGame_Person_I_3737"));
            CA!.Noun_Papierkorb = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3738, "Adv_InitializeGame_Person_I_3738"));
            CA!.Noun_Flachmann = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3739, "Adv_InitializeGame_Person_I_3739"));
            CA!.Noun_Bodenkacheln = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3740, "Adv_InitializeGame_Person_I_3740"));
            CA!.Noun_Stahltuer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3741, "Adv_InitializeGame_Person_I_3741"));
            CA!.Noun_Lustgarten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3742, "Adv_InitializeGame_Person_I_3742"));
            CA!.Noun_Gebirge = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3743, "Adv_InitializeGame_Person_I_3743"));
            CA!.Noun_Olivenbaeume = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3744, "Adv_InitializeGame_Person_I_3744"));
            CA!.Noun_Strasse = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3745, "Adv_InitializeGame_Person_I_3745"));
            Nouns.AddLocaLoca(CA!.Noun_Strasse!.ID, loca.Adv_InitializeGame_Person_I_3746, "Adv_InitializeGame_Person_I_3746");
            CA!.Noun_Dorf = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3747, "Adv_InitializeGame_Person_I_3747"));
            CA!.Noun_Gebaeude = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3748, "Adv_InitializeGame_Person_I_3748"));
            CA!.Noun_Huetten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3749, "Adv_InitializeGame_Person_I_3749"));
            CA!.Noun_Rampe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3750, "Adv_InitializeGame_Person_I_3750"));
            CA!.Noun_Ritze = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3751, "Adv_InitializeGame_Person_I_3751"));
            CA!.Noun_Unkraut = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3752, "Adv_InitializeGame_Person_I_3752"));
            CA!.Noun_Seifenlauge = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3753, "Adv_InitializeGame_Person_I_3753"));
            CA!.Noun_Seife = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3754, "Adv_InitializeGame_Person_I_3754"));
            CA!.Noun_Lauge = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3755, "Adv_InitializeGame_Person_I_3755"));
            CA!.Noun_Telefon = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3756, "Adv_InitializeGame_Person_I_3756"));
            Nouns.AddLocaLoca(CA!.Noun_Telefon!.ID, loca.Adv_InitializeGame_Person_I_3756a, "Adv_InitializeGame_Person_I_3756a");
            CA!.Noun_Marker = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3757, "Adv_InitializeGame_Person_I_3757"));
            CA!.Noun_Tonne = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3758, "Adv_InitializeGame_Person_I_3758"));
            CA!.Noun_Labor = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3759, "Adv_InitializeGame_Person_I_3759"));
            CA!.Noun_Monitore = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3760, "Adv_InitializeGame_Person_I_3760"));
            CA!.Noun_Schraenke = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3761, "Adv_InitializeGame_Person_I_3761"));
            CA!.Noun_Morast = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3762, "Adv_InitializeGame_Person_I_3762"));
            CA!.Noun_Moder = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3763, "Adv_InitializeGame_Person_I_3763"));
            CA!.Noun_Schimmel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3764, "Adv_InitializeGame_Person_I_3764"));
            CA!.Noun_Hafenbecken = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3765, "Adv_InitializeGame_Person_I_3765"));
            CA!.Noun_Pier = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3766, "Adv_InitializeGame_Person_I_3766"));
            CA!.Noun_Werkstatt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3767, "Adv_InitializeGame_Person_I_3767"));
            CA!.Noun_Bohlen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3768, "Adv_InitializeGame_Person_I_3768"));
            CA!.Noun_Boote = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3769, "Adv_InitializeGame_Person_I_3769"));
            CA!.Noun_Hafenbucht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3770, "Adv_InitializeGame_Person_I_3770"));
            CA!.Noun_Gasse = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3771, "Adv_InitializeGame_Person_I_3771"));
            CA!.Noun_Kramladen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3772, "Adv_InitializeGame_Person_I_3772"));
            CA!.Noun_Polizeiwache = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3773, "Adv_InitializeGame_Person_I_3773"));
            CA!.Noun_Post = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3774, "Adv_InitializeGame_Person_I_3774"));
            CA!.Noun_Redaktion = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3775, "Adv_InitializeGame_Person_I_3775"));
            CA!.Noun_Klotuer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3776, "Adv_InitializeGame_Person_I_3776"));
            CA!.Noun_Klo = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3777, "Adv_InitializeGame_Person_I_3777"));
            CA!.Noun_Rolltreppe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3778, "Adv_InitializeGame_Person_I_3778"));
            CA!.Noun_Nichtdose = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3779, "Adv_InitializeGame_Person_I_3779"));
            CA!.Noun_Nichtdosen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3780, "Adv_InitializeGame_Person_I_3780"));
            CA!.Noun_Nichtkonserve = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3781, "Adv_InitializeGame_Person_I_3781"));
            CA!.Noun_Nichtkonserven = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3782, "Adv_InitializeGame_Person_I_3782"));
            CA!.Noun_Nichtsims = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3783, "Adv_InitializeGame_Person_I_3783"));
            CA!.Noun_Nichtvorhang = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3784, "Adv_InitializeGame_Person_I_3784"));
            CA!.Noun_Sternekoeche = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3785, "Adv_InitializeGame_Person_I_3785"));
            CA!.Noun_Earpods = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3786, "Adv_InitializeGame_Person_I_3786"));
            CA!.Noun_Huellen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3787, "Adv_InitializeGame_Person_I_3787"));
            CA!.Noun_Ladekabel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3788, "Adv_InitializeGame_Person_I_3788"));
            CA!.Noun_Verkaufstische = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3789, "Adv_InitializeGame_Person_I_3789"));
            CA!.Noun_Durchgang = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3790, "Adv_InitializeGame_Person_I_3790"));
            CA!.Noun_Gaeste = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3791, "Adv_InitializeGame_Person_I_3791"));
            CA!.Noun_Gestalten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3792, "Adv_InitializeGame_Person_I_3792"));
            CA!.Noun_Luft = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3793, "Adv_InitializeGame_Person_I_3793"));
            CA!.Noun_Tische = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3794, "Adv_InitializeGame_Person_I_3794"));
            CA!.Noun_Klappe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3795, "Adv_InitializeGame_Person_I_3795"));
            CA!.Noun_Muellklappe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3796, "Adv_InitializeGame_Person_I_3796"));
            CA!.Noun_Schacht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3797, "Adv_InitializeGame_Person_I_3797"));
            CA!.Noun_Muellschacht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3798, "Adv_InitializeGame_Person_I_3798"));
            CA!.Noun_Couch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3799, "Adv_InitializeGame_Person_I_3799"));
            CA!.Noun_Stuehle = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3800, "Adv_InitializeGame_Person_I_3800"));
            CA!.Noun_Tafel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3801, "Adv_InitializeGame_Person_I_3801"));
            CA!.Noun_Phiole = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3802, "Adv_InitializeGame_Person_I_3802"));
            CA!.Noun_Container = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3803, "Adv_InitializeGame_Person_I_3803"));
            CA!.Noun_Disteln = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3804, "Adv_InitializeGame_Person_I_3804"));
            CA!.Noun_Muell = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3805, "Adv_InitializeGame_Person_I_3805"));
            CA!.Noun_Muellcontainer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3806, "Adv_InitializeGame_Person_I_3806"));
            CA!.Noun_Zaeune = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3807, "Adv_InitializeGame_Person_I_3807"));
            CA!.Noun_Stan = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3808, "Adv_InitializeGame_Person_I_3808"));
            CA!.Noun_Delivery = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3809, "Adv_InitializeGame_Person_I_3809"));
            CA!.Noun_Plakate = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3810, "Adv_InitializeGame_Person_I_3810"));
            CA!.Noun_Postschalter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3811, "Adv_InitializeGame_Person_I_3811"));
            CA!.Noun_Schreibpult = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3812, "Adv_InitializeGame_Person_I_3812"));
            CA!.Noun_Pult = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3813, "Adv_InitializeGame_Person_I_3813"));
            CA!.Noun_Wartebereich = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3814, "Adv_InitializeGame_Person_I_3814"));
            CA!.Noun_Emil = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3815, "Adv_InitializeGame_Person_I_3815"));
            CA!.Noun_Ike = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3816, "Adv_InitializeGame_Person_I_3816"));
            CA!.Noun_Ludmilla = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3817, "Adv_InitializeGame_Person_I_3817"));
            CA!.Noun_Streichelt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3818, "Adv_InitializeGame_Person_I_3818"));
            CA!.Noun_Schmitt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3819, "Adv_InitializeGame_Person_I_3819"));
            CA!.Noun_Julius = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3820, "Adv_InitializeGame_Person_I_3820"));
            Nouns.AddLocaLoca(CA!.Noun_Julius!.ID, loca.Adv_InitializeGame_Person_I_3821, "Adv_InitializeGame_Person_I_3821");
            CA!.Noun_Walton = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3822, "Adv_InitializeGame_Person_I_3822"));
            CA!.Noun_Schriftzug = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3823, "Adv_InitializeGame_Person_I_3823"));
            CA!.Noun_Klingel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3824, "Adv_InitializeGame_Person_I_3824"));
            CA!.Noun_Riegel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3825, "Adv_InitializeGame_Person_I_3825"));
            CA!.Noun_Backofen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3826, "Adv_InitializeGame_Person_I_3826"));
            CA!.Noun_Form = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3827, "Adv_InitializeGame_Person_I_3827"));
            CA!.Noun_Oeffner = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3828, "Adv_InitializeGame_Person_I_3828"));
            CA!.Noun_Priester = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3829, "Adv_InitializeGame_Person_I_3829"));
            CA!.Noun_Kuechenjunge = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3830, "Adv_InitializeGame_Person_I_3830"));
            CA!.Noun_Junge = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3831, "Adv_InitializeGame_Person_I_3831"));
            CA!.Noun_Proviantmeister = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3832, "Adv_InitializeGame_Person_I_3832"));
            CA!.Noun_Sofa = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3833, "Adv_InitializeGame_Person_I_3833"));
            CA!.Noun_Auslagen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3834, "Adv_InitializeGame_Person_I_3834"));
            CA!.Noun_Drehstaender = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3835, "Adv_InitializeGame_Person_I_3835"));
            CA!.Noun_Tand = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3836, "Adv_InitializeGame_Person_I_3836"));
            CA!.Noun_Holztuer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3837, "Adv_InitializeGame_Person_I_3837"));
            CA!.Noun_Maennlein = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3838, "Adv_InitializeGame_Person_I_3838"));
            CA!.Noun_Maennchen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3839, "Adv_InitializeGame_Person_I_3839"));
            CA!.Noun_Pfanne = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3840, "Adv_InitializeGame_Person_I_3840"));
            CA!.Noun_Fleischwolf = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3841, "Adv_InitializeGame_Person_I_3841"));
            CA!.Noun_Wandtattoo = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3842, "Adv_InitializeGame_Person_I_3842"));
            CA!.Noun_Schere = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3843, "Adv_InitializeGame_Person_I_3843"));
            CA!.Noun_Bonny = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3844, "Adv_InitializeGame_Person_I_3844"));
            CA!.Noun_Rocks = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3845, "Adv_InitializeGame_Person_I_3845"));
            CA!.Noun_Prepper = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3846, "Adv_InitializeGame_Person_I_3846"));
            CA!.Noun_John = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3847, "Adv_InitializeGame_Person_I_3847"));
            CA!.Noun_Foster = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3848, "Adv_InitializeGame_Person_I_3848"));
            CA!.Noun_Deborah = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3849, "Adv_InitializeGame_Person_I_3849"));
            Nouns.AddLocaLoca(CA!.Noun_Deborah!.ID, loca.Adv_InitializeGame_Person_I_3850, "Adv_InitializeGame_Person_I_3850");
            CA!.Noun_Norma = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3851, "Adv_InitializeGame_Person_I_3851"));
            CA!.Noun_Fakes = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3852, "Adv_InitializeGame_Person_I_3852"));
            CA!.Noun_Harald = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3853, "Adv_InitializeGame_Person_I_3853"));
            CA!.Noun_Habicht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3854, "Adv_InitializeGame_Person_I_3854"));
            CA!.Noun_Prayin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3855, "Adv_InitializeGame_Person_I_3855"));
            CA!.Noun_Erin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3856, "Adv_InitializeGame_Person_I_3856"));
            CA!.Noun_Stadtraetin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3857, "Adv_InitializeGame_Person_I_3857"));
            CA!.Noun_Stadtrat = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3858, "Adv_InitializeGame_Person_I_3858"));
            CA!.Noun_Buergermeister = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3859, "Adv_InitializeGame_Person_I_3859"));
            CA!.Noun_Buergermeisterin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3860, "Adv_InitializeGame_Person_I_3860"));
            CA!.Noun_Frieda = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3861, "Adv_InitializeGame_Person_I_3861"));
            CA!.Noun_Frimpton = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3862, "Adv_InitializeGame_Person_I_3862"));
            CA!.Noun_Weiden = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3863, "Adv_InitializeGame_Person_I_3863"));
            CA!.Noun_Kuehe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3864, "Adv_InitializeGame_Person_I_3864"));
            CA!.Noun_Stacheldrahtzaun = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3865, "Adv_InitializeGame_Person_I_3865"));
            CA!.Noun_Zaun = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3866, "Adv_InitializeGame_Person_I_3866"));
            CA!.Noun_Zigarrenrauch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3867, "Adv_InitializeGame_Person_I_3867"));
            CA!.Noun_Rauch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3868, "Adv_InitializeGame_Person_I_3868"));
            CA!.Noun_Trophaeen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3869, "Adv_InitializeGame_Person_I_3869"));
            CA!.Noun_Bilder = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3870, "Adv_InitializeGame_Person_I_3870"));
            CA!.Noun_Wimpel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3871, "Adv_InitializeGame_Person_I_3871"));
            CA!.Noun_Geruch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3872, "Adv_InitializeGame_Person_I_3872"));
            Nouns.AddLocaLoca(CA!.Noun_Geruch!.ID, loca.Adv_InitializeGame_Person_I_3873, "Adv_InitializeGame_Person_I_3873");
            CA!.Noun_Steuerschatulle = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3874, "Adv_InitializeGame_Person_I_3874"));
            CA!.Noun_Schatulle = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3875, "Adv_InitializeGame_Person_I_3875"));
            CA!.Noun_Geschmeide = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3876, "Adv_InitializeGame_Person_I_3876"));
            CA!.Noun_Pokale = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3877, "Adv_InitializeGame_Person_I_3877"));
            CA!.Noun_Pokal = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3878, "Adv_InitializeGame_Person_I_3878"));
            CA!.Noun_Auszeichnungen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3879, "Adv_InitializeGame_Person_I_3879"));
            CA!.Noun_Auszeichnung = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3880, "Adv_InitializeGame_Person_I_3880"));
            CA!.Noun_Reichtum = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3881, "Adv_InitializeGame_Person_I_3881"));
            CA!.Noun_Vuvuzela = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3882, "Adv_InitializeGame_Person_I_3882"));
            CA!.Noun_Umgebung = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3883, "Adv_InitializeGame_Person_I_3883"));
            CA!.Noun_Ferdinand = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3884, "Adv_InitializeGame_Person_I_3884"));
            Nouns.AddLocaLoca(CA!.Noun_Ferdinand!.ID, loca.Adv_InitializeGame_Person_I_3885, "Adv_InitializeGame_Person_I_3885");
            CA!.Noun_Tristan = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3886, "Adv_InitializeGame_Person_I_3886"));
            CA!.Noun_Kisten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3887, "Adv_InitializeGame_Person_I_3887"));
            CA!.Noun_Staubpartikel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3888, "Adv_InitializeGame_Person_I_3888"));
            CA!.Noun_Buesche = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3889, "Adv_InitializeGame_Person_I_3889"));
            CA!.Noun_Farne = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3890, "Adv_InitializeGame_Person_I_3890"));
            CA!.Noun_Friedhof = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3891, "Adv_InitializeGame_Person_I_3891"));
            CA!.Noun_Laubbaeume = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3892, "Adv_InitializeGame_Person_I_3892"));
            CA!.Noun_Wegraender = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3893, "Adv_InitializeGame_Person_I_3893"));
            CA!.Noun_Exponate = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3894, "Adv_InitializeGame_Person_I_3894"));
            CA!.Noun_Werkzeugkasten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3895, "Adv_InitializeGame_Person_I_3895"));
            CA!.Noun_Schilder = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3896, "Adv_InitializeGame_Person_I_3896"));
            CA!.Noun_Staender = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3897, "Adv_InitializeGame_Person_I_3897"));
            Nouns.AddLocaLoca(CA!.Noun_Staender!.ID, loca.Noun_Stand, "Noun_Stand");
            CA!.Noun_Werkbank = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3898, "Adv_InitializeGame_Person_I_3898"));
            CA!.Noun_Leo = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3899, "Adv_InitializeGame_Person_I_3899"));
            CA!.Noun_Aktenschrank = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3900, "Adv_InitializeGame_Person_I_3900"));
            CA!.Noun_Kalender = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3901, "Adv_InitializeGame_Person_I_3901"));
            CA!.Noun_Schemel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3902, "Adv_InitializeGame_Person_I_3902"));
            CA!.Noun_Dirty = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3903, "Adv_InitializeGame_Person_I_3903"));
            CA!.Noun_Karl = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3904, "Adv_InitializeGame_Person_I_3904"));
            CA!.Noun_Larry = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3905, "Adv_InitializeGame_Person_I_3905"));
            CA!.Noun_Professor = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3906, "Adv_InitializeGame_Person_I_3906"));
            Nouns.AddLocaLoca(CA!.Noun_Professor!.ID, loca.Adv_InitializeGame_Person_I_3907, "Adv_InitializeGame_Person_I_3907");
            CA!.Noun_Skarabaeus = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3908, "Adv_InitializeGame_Person_I_3908"));
            CA!.Noun_Geraetschaften = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3909, "Adv_InitializeGame_Person_I_3909"));
            CA!.Noun_Tabletten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3910, "Adv_InitializeGame_Person_I_3910"));
            CA!.Noun_Tablette = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3911, "Adv_InitializeGame_Person_I_3911"));
            CA!.Noun_Bund = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3912, "Adv_InitializeGame_Person_I_3912"));
            CA!.Noun_Highway = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3913, "Adv_InitializeGame_Person_I_3913"));
            CA!.Noun_Korb = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3914, "Adv_InitializeGame_Person_I_3914"));
            CA!.Noun_Krug = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3915, "Adv_InitializeGame_Person_I_3915"));
            CA!.Noun_Bierkrug = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3916, "Adv_InitializeGame_Person_I_3916"));
            CA!.Noun_Wege = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3917, "Adv_InitializeGame_Person_I_3917"));
            CA!.Noun_Graeber = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3918, "Adv_InitializeGame_Person_I_3918"));
            CA!.Noun_Grabsteine = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3919, "Adv_InitializeGame_Person_I_3919"));
            CA!.Noun_Grabstein = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3920, "Adv_InitializeGame_Person_I_3920"));
            CA!.Noun_Grab = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3921, "Adv_InitializeGame_Person_I_3921"));
            CA!.Noun_Brunnen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3922, "Adv_InitializeGame_Person_I_3922"));
            Nouns.AddLocaLoca(CA!.Noun_Brunnen!.ID, loca.Adv_Well, "Adv_Well");
            CA!.Noun_Zombiehorde = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3923, "Adv_InitializeGame_Person_I_3923"));
            CA!.Noun_Zombies = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3924, "Adv_InitializeGame_Person_I_3924"));
            CA!.Noun_Zombie = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3925, "Adv_InitializeGame_Person_I_3925"));
            CA!.Noun_Haeuser = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3926, "Adv_InitializeGame_Person_I_3926"));
            CA!.Noun_Balkon = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3927, "Adv_InitializeGame_Person_I_3927"));
            CA!.Noun_Glaspalaeste = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3928, "Adv_InitializeGame_Person_I_3928"));
            CA!.Noun_Glaspalast = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3929, "Adv_InitializeGame_Person_I_3929"));
            CA!.Noun_Palast = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3930, "Adv_InitializeGame_Person_I_3930"));
            CA!.Noun_Platz = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3931, "Adv_InitializeGame_Person_I_3931"));
            CA!.Noun_Plakette = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3932, "Adv_InitializeGame_Person_I_3932"));
            CA!.Noun_Logistikzentrum = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3933, "Adv_InitializeGame_Person_I_3933"));
            CA!.Noun_Zentrum = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3934, "Adv_InitializeGame_Person_I_3934"));
            CA!.Noun_George = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3935, "Adv_InitializeGame_Person_I_3935"));
            CA!.Noun_Ruler = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3936, "Adv_InitializeGame_Person_I_3936"));
            CA!.Noun_Horizont = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3937, "Adv_InitializeGame_Person_I_3937"));
            CA!.Noun_Eremitin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3938, "Adv_InitializeGame_Person_I_3938"));
            CA!.Noun_Acker = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3939, "Adv_InitializeGame_Person_I_3939"));
            CA!.Noun_Flackerlicht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3940, "Adv_InitializeGame_Person_I_3940"));
            CA!.Noun_Flackern = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3941, "Adv_InitializeGame_Person_I_3941"));
            CA!.Noun_Flaemmchen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3942, "Adv_InitializeGame_Person_I_3942"));
            CA!.Noun_Gas = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3943, "Adv_InitializeGame_Person_I_3943"));
            CA!.Noun_Sumpfgas = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3944, "Adv_InitializeGame_Person_I_3944"));
            CA!.Noun_Wasser = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3945, "Adv_InitializeGame_Person_I_3945"));
            CA!.Noun_Bericht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3946, "Adv_InitializeGame_Person_I_3946"));
            CA!.Noun_Rechenschaftsbericht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3947, "Adv_InitializeGame_Person_I_3947"));
            CA!.Noun_Briefkasten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3948, "Adv_InitializeGame_Person_I_3948"));
            CA!.Noun_Postkasten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3949, "Adv_InitializeGame_Person_I_3949"));
            CA!.Noun_Kasten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3950, "Adv_InitializeGame_Person_I_3950"));
            CA!.Noun_Schraubstock = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3951, "Adv_InitializeGame_Person_I_3951"));
            CA!.Noun_Bauernhaus = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3952, "Adv_InitializeGame_Person_I_3952"));
            CA!.Noun_Bauernhof = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3953, "Adv_InitializeGame_Person_I_3953"));
            CA!.Noun_Haus = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3954, "Adv_InitializeGame_Person_I_3954"));
            CA!.Noun_Wohnhaus = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3955, "Adv_InitializeGame_Person_I_3955"));
            CA!.Noun_Landmaschinen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3956, "Adv_InitializeGame_Person_I_3956"));
            CA!.Noun_Maschinen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3957, "Adv_InitializeGame_Person_I_3957"));
            CA!.Noun_Maschine = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3958, "Adv_InitializeGame_Person_I_3958"));
            CA!.Noun_Maisfeld = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3959, "Adv_InitializeGame_Person_I_3959"));
            CA!.Noun_Matsch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3960, "Adv_InitializeGame_Person_I_3960"));
            CA!.Noun_Scheune = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3961, "Adv_InitializeGame_Person_I_3961"));
            CA!.Noun_Laubbaum = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3962, "Adv_InitializeGame_Person_I_3962"));
            CA!.Noun_Weg = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3963, "Adv_InitializeGame_Person_I_3963"));
            CA!.Noun_Werkzeugschrank = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3964, "Adv_InitializeGame_Person_I_3964"));
            CA!.Noun_Strohballenberg = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3965, "Adv_InitializeGame_Person_I_3965"));
            CA!.Noun_Strohballen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3966, "Adv_InitializeGame_Person_I_3966"));
            CA!.Noun_Scheunentor = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3967, "Adv_InitializeGame_Person_I_3967"));
            CA!.Noun_Lichtschalter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3968, "Adv_InitializeGame_Person_I_3968"));
            CA!.Noun_Balken = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3969, "Adv_InitializeGame_Person_I_3969"));
            CA!.Noun_Wesir = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3970, "Adv_InitializeGame_Person_I_3970"));
            CA!.Noun_Grosswesir = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3971, "Adv_InitializeGame_Person_I_3971"));
            CA!.Noun_Gift = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3972, "Adv_InitializeGame_Person_I_3972"));
            CA!.Noun_Flakon = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3973, "Adv_InitializeGame_Person_I_3973"));
            CA!.Noun_Flakons = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3974, "Adv_InitializeGame_Person_I_3974"));
            CA!.Noun_Bier = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3975, "Adv_InitializeGame_Person_I_3975"));
            CA!.Noun_Tal = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3976, "Adv_InitializeGame_Person_I_3976"));
            CA!.Noun_Blumenwiese = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3977, "Adv_InitializeGame_Person_I_3977"));
            CA!.Noun_Favelas = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3978, "Adv_InitializeGame_Person_I_3978"));
            CA!.Noun_Favela = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3979, "Adv_InitializeGame_Person_I_3979"));
            CA!.Noun_Maisstauden = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3980, "Adv_InitializeGame_Person_I_3980"));
            CA!.Noun_Maiskolben = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3981, "Adv_InitializeGame_Person_I_3981"));
            CA!.Noun_Erdreich = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3982, "Adv_InitializeGame_Person_I_3982"));
            CA!.Noun_Lichtung = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3983, "Adv_InitializeGame_Person_I_3983"));
            CA!.Noun_Birken = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3984, "Adv_InitializeGame_Person_I_3984"));
            CA!.Noun_Wohnstube = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3985, "Adv_InitializeGame_Person_I_3985"));
            CA!.Noun_Vorratskammer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3986, "Adv_InitializeGame_Person_I_3986"));
            CA!.Noun_Senfomat = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3987, "Adv_InitializeGame_Person_I_3987"));
            Nouns.AddLocaLoca(CA!.Noun_Senfomat!.ID, loca.Adv_InitializeGame_Person_I_3988, "Adv_InitializeGame_Person_I_3988");
            CA!.Noun_Apparat = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3989, "Adv_InitializeGame_Person_I_3989"));
            CA!.Noun_Stube = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3990, "Adv_InitializeGame_Person_I_3990"));
            CA!.Noun_Kuechenzeile = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3991, "Adv_InitializeGame_Person_I_3991"));
            CA!.Noun_Wasserhahn = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3992, "Adv_InitializeGame_Person_I_3992"));
            CA!.Noun_Spuelbecken = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3993, "Adv_InitializeGame_Person_I_3993"));
            CA!.Noun_Kammer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3994, "Adv_InitializeGame_Person_I_3994"));
            CA!.Noun_Esstisch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3995, "Adv_InitializeGame_Person_I_3995"));
            CA!.Noun_Anrichte = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3996, "Adv_InitializeGame_Person_I_3996"));
            CA!.Noun_Wandregal = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3997, "Adv_InitializeGame_Person_I_3997"));
            CA!.Noun_Symbole = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3998, "Adv_InitializeGame_Person_I_3998"));
            CA!.Noun_Sprueche = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3999, "Adv_InitializeGame_Person_I_3999"));
            CA!.Noun_Spruch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4000, "Adv_InitializeGame_Person_I_4000"));
            CA!.Noun_Sinnsprueche = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4001, "Adv_InitializeGame_Person_I_4001"));
            CA!.Noun_Schlafkammer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4002, "Adv_InitializeGame_Person_I_4002"));
            CA!.Noun_Nippes = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4003, "Adv_InitializeGame_Person_I_4003"));
            CA!.Noun_Geroell = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4004, "Adv_InitializeGame_Person_I_4004"));
            CA!.Noun_Felswand = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4005, "Adv_InitializeGame_Person_I_4005"));
            CA!.Noun_Toilettenraum = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4006, "Adv_InitializeGame_Person_I_4006"));
            CA!.Noun_Toilette = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4007, "Adv_InitializeGame_Person_I_4007"));
            CA!.Noun_Plumpsklo = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4008, "Adv_InitializeGame_Person_I_4008"));
            CA!.Noun_Fensterschlitz = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4009, "Adv_InitializeGame_Person_I_4009"));
            CA!.Noun_Gewoelbe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4010, "Adv_InitializeGame_Person_I_4010"));
            CA!.Noun_Steintreppe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4011, "Adv_InitializeGame_Person_I_4011"));
            CA!.Noun_Betonboden = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4012, "Adv_InitializeGame_Person_I_4012"));
            CA!.Noun_Dampfer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4013, "Adv_InitializeGame_Person_I_4013"));
            CA!.Noun_Boulevard = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4014, "Adv_InitializeGame_Person_I_4014"));
            CA!.Noun_Edelfavelas = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4015, "Adv_InitializeGame_Person_I_4015"));
            CA!.Noun_Kommunikationszentrum = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4016, "Adv_InitializeGame_Person_I_4016"));
            CA!.Noun_Hightechzaun = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4017, "Adv_InitializeGame_Person_I_4017"));
            CA!.Noun_Zahlenschloss = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4018, "Adv_InitializeGame_Person_I_4018"));
            CA!.Noun_Taefelchen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4019, "Adv_InitializeGame_Person_I_4019"));
            CA!.Noun_Gewicht = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4020, "Adv_InitializeGame_Person_I_4020"));
            CA!.Noun_Knoten = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4021, "Adv_InitializeGame_Person_I_4021"));
            CA!.Noun_Ringschraube = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4022, "Adv_InitializeGame_Person_I_4022"));
            CA!.Noun_Schraube = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4023, "Adv_InitializeGame_Person_I_4023"));
            CA!.Noun_Ring = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4024, "Adv_InitializeGame_Person_I_4024"));
            CA!.Noun_Hakenseil = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4025, "Adv_InitializeGame_Person_I_4025"));
            Nouns.AddLocaLoca(CA!.Noun_Hakenseil!.ID, loca.Adv_Noun_Ropehook, "Adv_Noun_Ropehook");
            CA!.Noun_Stockseil = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4026, "Adv_InitializeGame_Person_I_4026"));
            CA!.Noun_Hecken = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4027, "Adv_InitializeGame_Person_I_4027"));
            CA!.Noun_Hecke = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4028, "Adv_InitializeGame_Person_I_4028"));
            CA!.Noun_Brieffach = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4029, "Adv_InitializeGame_Person_I_4029"));
            CA!.Noun_Fach = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4030, "Adv_InitializeGame_Person_I_4030"));
            CA!.Noun_Sekretaer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4031, "Adv_InitializeGame_Person_I_4031"));
            CA!.Noun_Apparaturen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4032, "Adv_InitializeGame_Person_I_4032"));
            CA!.Noun_Apparatur = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4033, "Adv_InitializeGame_Person_I_4033"));
            CA!.Noun_Juwelen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4034, "Adv_InitializeGame_Person_I_4034"));
            CA!.Noun_Mall = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4035, "Adv_InitializeGame_Person_I_4035"));
            CA!.Noun_Shop = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4036, "Adv_InitializeGame_Person_I_4036"));
            CA!.Noun_Glastuer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4037, "Adv_InitializeGame_Person_I_4037"));
            CA!.Noun_Angebote = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4038, "Adv_InitializeGame_Person_I_4038"));
            CA!.Noun_Paletten = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4039, "Adv_InitializeGame_Person_I_4039"));
            CA!.Noun_Platten = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4040, "Adv_InitializeGame_Person_I_4040"));
            CA!.Noun_Pillen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4041, "Adv_InitializeGame_Person_I_4041"));
            CA!.Noun_Droge = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4042, "Adv_InitializeGame_Person_I_4042"));
            CA!.Noun_Panorama = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4043, "Adv_InitializeGame_Person_I_4043"));
            CA!.Noun_Statue = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4044, "Adv_InitializeGame_Person_I_4044"));
            CA!.Noun_Krone = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4045, "Adv_InitializeGame_Person_I_4045"));
            CA!.Noun_Ohr = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4046, "Adv_InitializeGame_Person_I_4046"));
            CA!.Noun_Baerenfallen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4047, "Adv_InitializeGame_Person_I_4047"));
            CA!.Noun_Wertstoffe = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4048, "Adv_InitializeGame_Person_I_4048"));
            CA!.Noun_Geld = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4049, "Adv_InitializeGame_Person_I_4049"));
            CA!.Noun_Mauer = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4050, "Adv_InitializeGame_Person_I_4050"));
            CA!.Noun_Wehr = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4051, "Adv_InitializeGame_Person_I_4051"));
            CA!.Noun_Faesschen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4052, "Adv_InitializeGame_Person_I_4052"));
            CA!.Noun_Drehwolf = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4053, "Adv_InitializeGame_Person_I_4053"));
            CA!.Noun_Tattoo = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4054, "Adv_InitializeGame_Person_I_4054"));
            CA!.Noun_Wolf = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4055, "Adv_InitializeGame_Person_I_4055"));
            CA!.Noun_Aufzug = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4056, "Adv_InitializeGame_Person_I_4056"));
            CA!.Noun_Berater = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4057, "Adv_InitializeGame_Person_I_4057"));
            Nouns.AddLocaLoca(CA!.Noun_Berater!.ID, loca.Adv_InitializeGame_Person_I_4057a, "Adv_InitializeGame_Person_I_4057a");
            Nouns.AddLocaLoca(CA!.Noun_Berater!.ID, loca.Adv_InitializeGame_Person_I_4057b, "Adv_InitializeGame_Person_I_4057b");
            Nouns.AddLocaLoca(CA!.Noun_Berater!.ID, loca.Adv_InitializeGame_Person_I_4057c, "Adv_InitializeGame_Person_I_4057c");

            CA!.Noun_Blut = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4058, "Adv_InitializeGame_Person_I_4058"));
            CA!.Noun_Exberater = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4059, "Adv_InitializeGame_Person_I_4059"));
            CA!.Noun_Gefangener = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4060, "Adv_InitializeGame_Person_I_4060"));
            CA!.Noun_Exgefangener = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4061, "Adv_InitializeGame_Person_I_4061"));
            CA!.Noun_Feld = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4062, "Adv_InitializeGame_Person_I_4062"));
            CA!.Noun_Folterwerkzeuge = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4063, "Adv_InitializeGame_Person_I_4063"));
            CA!.Noun_Garnitur = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4064, "Adv_InitializeGame_Person_I_4064"));
            CA!.Noun_Hof = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4065, "Adv_InitializeGame_Person_I_4065"));
            CA!.Noun_Instrumente = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4066, "Adv_InitializeGame_Person_I_4066"));
            CA!.Noun_Kacheln = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4067, "Adv_InitializeGame_Person_I_4067"));
            CA!.Noun_Kolben = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4068, "Adv_InitializeGame_Person_I_4068"));
            CA!.Noun_Kueche = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4069, "Adv_InitializeGame_Person_I_4069"));
            CA!.Noun_Mais = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4070, "Adv_InitializeGame_Person_I_4070"));
            CA!.Noun_Maisstaude = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4071, "Adv_InitializeGame_Person_I_4071"));
            CA!.Noun_Partikel = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4072, "Adv_InitializeGame_Person_I_4072"));
            CA!.Noun_Scheibe = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4073, "Adv_InitializeGame_Person_I_4073"));
            CA!.Noun_Scheiben = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4074, "Adv_InitializeGame_Person_I_4074"));
            CA!.Noun_Schrift = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4075, "Adv_InitializeGame_Person_I_4075"));
            CA!.Noun_Staude = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4076, "Adv_InitializeGame_Person_I_4076"));
            CA!.Noun_Steine = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4077, "Adv_InitializeGame_Person_I_4077"));
            CA!.Noun_Werkzeuge = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4078, "Adv_InitializeGame_Person_I_4078"));
            CA!.Noun_Zeile = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4079, "Adv_InitializeGame_Person_I_4079"));
            CA!.Noun_Boot = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4080, "Adv_InitializeGame_Person_I_4080"));
            CA!.Noun_Computer = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4081, "Adv_InitializeGame_Person_I_4081"));
            CA!.Noun_Desk = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4082, "Adv_InitializeGame_Person_I_4082"));
            CA!.Noun_Desks = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4083, "Adv_InitializeGame_Person_I_4083"));
            CA!.Noun_Gitterstab = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4084, "Adv_InitializeGame_Person_I_4084"));
            CA!.Noun_Stab = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4085, "Adv_InitializeGame_Person_I_4085"));
            CA!.Noun_Beschlaege = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4086, "Adv_InitializeGame_Person_I_4086"));
            CA!.Noun_Eisen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4087, "Adv_InitializeGame_Person_I_4087"));
            CA!.Noun_Eisenbeschlaege = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4088, "Adv_InitializeGame_Person_I_4088"));
            CA!.Noun_Eisenbeschlag = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4089, "Adv_InitializeGame_Person_I_4089"));
            CA!.Noun_Schreibmaschine = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4090, "Adv_InitializeGame_Person_I_4090"));
            CA!.Noun_Bars = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4091, "Adv_InitializeGame_Person_I_4091"));
            CA!.Noun_Barfrau = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4092, "Adv_InitializeGame_Person_I_4092"));
            CA!.Noun_Strandbars = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4093, "Adv_InitializeGame_Person_I_4093"));
            CA!.Noun_Strandbar = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4094, "Adv_InitializeGame_Person_I_4094"));
            CA!.Noun_Brocken = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4095, "Adv_InitializeGame_Person_I_4095"));
            CA!.Noun_Gang = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4096, "Adv_InitializeGame_Person_I_4096"));
            CA!.Noun_Helm = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4097, "Adv_InitializeGame_Person_I_4097"));
            CA!.Noun_Steinbrocken = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4098, "Adv_InitializeGame_Person_I_4098"));
            CA!.Noun_Bratensauce = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4099, "Adv_InitializeGame_Person_I_4099"));
            CA!.Noun_Sauce = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4100, "Adv_InitializeGame_Person_I_4100"));
            CA!.Noun_Sosse = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4101, "Adv_InitializeGame_Person_I_4101"));
            Nouns.AddLocaLoca(CA!.Noun_Sosse!.ID, loca.Adv_InitializeGame_Noun_Sosse, "Adv_InitializeGame_Noun_Sosse");
            CA!.Noun_Maler = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4102, "Adv_InitializeGame_Person_I_4102"));
            CA!.Noun_Exqueen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4103, "Adv_InitializeGame_Person_I_4103"));
            Nouns.AddLocaLoca(CA!.Noun_Exqueen!.ID, loca.Adv_InitializeGame_Person_I_4104, "Adv_InitializeGame_Person_I_4104");
            CA!.Noun_Exexkoenigin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4105, "Adv_InitializeGame_Person_I_4105"));
            CA!.Noun_Kanne = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4106, "Adv_InitializeGame_Person_I_4106"));
            CA!.Noun_Kate = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4107, "Adv_InitializeGame_Person_I_4107"));
            CA!.Noun_Queen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4108, "Adv_InitializeGame_Person_I_4108"));
            Nouns.AddLocaLoca(CA!.Noun_Queen!.ID, loca.Adv_InitializeGame_Person_I_4109, "Adv_InitializeGame_Person_I_4109");
            CA!.Noun_Bahn = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4110, "Adv_InitializeGame_Person_I_4110"));
            CA!.Noun_Bahnen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4111, "Adv_InitializeGame_Person_I_4111"));
            CA!.Noun_Club = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4112, "Adv_InitializeGame_Person_I_4112"));
            CA!.Noun_Clubhaus = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4113, "Adv_InitializeGame_Person_I_4113"));
            CA!.Noun_Golfbahnen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4114, "Adv_InitializeGame_Person_I_4114"));
            CA!.Noun_Golfplatz = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4115, "Adv_InitializeGame_Person_I_4115"));
            CA!.Noun_Senftopf = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4116, "Adv_InitializeGame_Person_I_4116"));
            CA!.Noun_Senffass = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4117, "Adv_InitializeGame_Person_I_4117"));
            CA!.Noun_Tank = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4118, "Adv_InitializeGame_Person_I_4118"));
            CA!.Noun_Tankverschluss = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4119, "Adv_InitializeGame_Person_I_4119"));
            Nouns.AddLocaLoca(CA!.Noun_Tankverschluss!.ID, loca.Adv_InitializeGame_Person_I_4119a, "Adv_InitializeGame_Person_I_4119a");
            CA!.Noun_Traktor = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4120, "Adv_InitializeGame_Person_I_4120"));
            CA!.Noun_Schlauchende = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4121, "Adv_InitializeGame_Person_I_4121"));
            CA!.Noun_Trecker = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4122, "Adv_InitializeGame_Person_I_4122"));
            CA!.Noun_Verschluss = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4123, "Adv_InitializeGame_Person_I_4123"));
            CA!.Noun_Glasscheiben = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4124, "Adv_InitializeGame_Person_I_4124"));
            CA!.Noun_Bueros = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4125, "Adv_InitializeGame_Person_I_4125"));
            CA!.Noun_Buero = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4126, "Adv_InitializeGame_Person_I_4126"));
            CA!.Noun_Geraete = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4127, "Adv_InitializeGame_Person_I_4127"));
            CA!.Noun_Matschpfuetze = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4128, "Adv_InitializeGame_Person_I_4128"));
            CA!.Noun_Pfuetze = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4129, "Adv_InitializeGame_Person_I_4129"));
            CA!.Noun_Regentonne = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4130, "Adv_InitializeGame_Person_I_4130"));
            CA!.Noun_Kleiderschrank = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4131, "Adv_InitializeGame_Person_I_4131"));
            CA!.Noun_Schlafgemach = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4132, "Adv_InitializeGame_Person_I_4132"));
            CA!.Noun_Bettdecke = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4133, "Adv_InitializeGame_Person_I_4133"));
            CA!.Noun_Portrait = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4134, "Adv_InitializeGame_Person_I_4134"));
            CA!.Noun_Benachrichtigung = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4135, "Adv_InitializeGame_Person_I_4135"));
            CA!.Noun_Benachrichtigungskarte = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4136, "Adv_InitializeGame_Person_I_4136"));
            CA!.Noun_Hightechklo = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4137, "Adv_InitializeGame_Person_I_4137"));
            CA!.Noun_Bildhauer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4138, "Adv_InitializeGame_Person_I_4138"));
            CA!.Noun_Leiber = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4139, "Adv_InitializeGame_Person_I_4139"));
            CA!.Noun_Kabel = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4140, "Adv_InitializeGame_Person_I_4140"));
            CA!.Noun_Kabelisolierung = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4141, "Adv_InitializeGame_Person_I_4141"));
            CA!.Noun_Isolierung = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4142, "Adv_InitializeGame_Person_I_4142"));
            CA!.Noun_Abgrund = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4143, "Adv_InitializeGame_Person_I_4143"));
            CA!.Noun_Grube = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4144, "Adv_InitializeGame_Person_I_4144"));
            CA!.Noun_Instrument = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4145, "Adv_InitializeGame_Person_I_4145"));
            CA!.Noun_Menschenleiber = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4146, "Adv_InitializeGame_Person_I_4146"));
            CA!.Noun_Musikinstrumente = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4147, "Adv_InitializeGame_Person_I_4147"));
            CA!.Noun_Ausgabe = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4148, "Adv_InitializeGame_Person_I_4148"));
            CA!.Noun_Ausgabefach = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4149, "Adv_InitializeGame_Person_I_4149"));
            CA!.Noun_Knochentuer = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4150, "Adv_InitializeGame_Person_I_4150"));
            CA!.Noun_Frachtdokumente = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4151, "Adv_InitializeGame_Person_I_4151"));
            Nouns.AddLocaLoca(CA!.Noun_Frachtdokumente!.ID, loca.Adv_InitializeGame_Person_I_4152, "Adv_InitializeGame_Person_I_4152");
            CA!.Noun_Dokumente = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4153, "Adv_InitializeGame_Person_I_4153"));
            CA!.Noun_Zettel = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4154, "Adv_InitializeGame_Person_I_4154"));
            CA!.Noun_Berder = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4155, "Adv_InitializeGame_Person_I_4155"));
            CA!.Noun_Bruecke = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4156, "Adv_InitializeGame_Person_I_4156"));
            CA!.Noun_Daemonen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4157, "Adv_InitializeGame_Person_I_4157"));
            CA!.Noun_Pfuhl = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4158, "Adv_InitializeGame_Person_I_4158"));
            CA!.Noun_Satanspfuhl = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4159, "Adv_InitializeGame_Person_I_4159"));
            CA!.Noun_Zeichen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4160, "Adv_InitializeGame_Person_I_4160"));
            CA!.Noun_Feuer = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4161, "Adv_InitializeGame_Person_I_4161"));
            CA!.Noun_Foltersitzgarnitur = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4162, "Adv_InitializeGame_Person_I_4162"));
            CA!.Noun_Hoellenfeuer = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4163, "Adv_InitializeGame_Person_I_4163"));
            CA!.Noun_Schwaden = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4164, "Adv_InitializeGame_Person_I_4164"));
            CA!.Noun_Schwefelschwaden = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4165, "Adv_InitializeGame_Person_I_4165"));
            CA!.Noun_Fahndungsplakat = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4166, "Adv_InitializeGame_Person_I_4166"));
            CA!.Noun_Fahndungsplakate = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4167, "Adv_InitializeGame_Person_I_4167"));
            CA!.Noun_Plakat = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4168, "Adv_InitializeGame_Person_I_4168"));
            CA!.Noun_Metallschrank = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4169, "Adv_InitializeGame_Person_I_4169"));
            CA!.Noun_Faeulnis = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4170, "Adv_InitializeGame_Person_I_4170"));



            // bis hier
            CA!.Noun_Daemonentor = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4171, "Adv_InitializeGame_Person_I_4171"));
            CA!.Noun_Satanspalast = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4172, "Adv_InitializeGame_Person_I_4172"));
            CA!.Noun_Hoellenkreatur = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4173, "Adv_InitializeGame_Person_I_4173"));
            CA!.Noun_Kreatur = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4174, "Adv_InitializeGame_Person_I_4174"));
            CA!.Noun_Schaelchen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4175, "Adv_InitializeGame_Person_I_4175"));
            CA!.Noun_Suhle = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4176, "Adv_InitializeGame_Person_I_4176"));
            CA!.Noun_Teufelssuhle = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4177, "Adv_InitializeGame_Person_I_4177"));
            CA!.Noun_Friteuse = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4178, "Adv_InitializeGame_Person_I_4178"));
            CA!.Noun_Lakaien = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4179, "Adv_InitializeGame_Person_I_4179"));
            CA!.Noun_Lakai = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4180, "Adv_InitializeGame_Person_I_4180"));
            CA!.Noun_Essenshalde = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4181, "Adv_InitializeGame_Person_I_4181"));
            CA!.Noun_Halde = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4182, "Adv_InitializeGame_Person_I_4182"));
            CA!.Noun_Lebensmittel = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4183, "Adv_InitializeGame_Person_I_4183"));
            CA!.Noun_Kaeptn = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4184, "Adv_InitializeGame_Person_I_4184"));
            Nouns.AddLocaLoca(CA!.Noun_Kaeptn!.ID, loca.Adv_InitializeGame_Kaeptn, "Adv_InitializeGame_Kaeptn");
            CA!.Noun_Pentagramme = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4185, "Adv_InitializeGame_Person_I_4185"));
            CA!.Noun_Schaedel = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4186, "Adv_InitializeGame_Person_I_4186"));
            CA!.Noun_Lava = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4187, "Adv_InitializeGame_Person_I_4187"));
            CA!.Noun_Flaschenzug = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4188, "Adv_InitializeGame_Person_I_4188"));
            CA!.Noun_Lift = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4189, "Adv_InitializeGame_Person_I_4189"));
            CA!.Noun_Schnur = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4190, "Adv_InitializeGame_Person_I_4190"));
            CA!.Noun_Faser = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4191, "Adv_InitializeGame_Person_I_4191"));
            CA!.Noun_Hightechfaser = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4192, "Adv_InitializeGame_Person_I_4192"));
            CA!.Noun_Angelschnur = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4193, "Adv_InitializeGame_Person_I_4193"));
            CA!.Noun_Suessigkeitenbrunnen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4194, "Adv_InitializeGame_Person_I_4194"));
            CA!.Noun_Zuendschnur = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4195, "Adv_InitializeGame_Person_I_4195"));
            CA!.Noun_Pappaufsteller = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4196, "Adv_InitializeGame_Person_I_4196"));
            CA!.Noun_Aufsteller = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4197, "Adv_InitializeGame_Person_I_4197"));
            CA!.Noun_Lunte = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4198, "Adv_InitializeGame_Person_I_4198"));
            CA!.Noun_Truemmerhaufen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4199, "Adv_InitializeGame_Person_I_4199"));
            CA!.Noun_Fuerstin = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4200, "Adv_InitializeGame_Person_I_4200"));
            CA!.Noun_Hoellenfuerstin = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4201, "Adv_InitializeGame_Person_I_4201"));
            CA!.Noun_Schmierereien = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4202, "Adv_InitializeGame_Person_I_4202"));
            CA!.Noun_Elendshuetten = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4203, "Adv_InitializeGame_Person_I_4203"));
            CA!.Noun_Hochbau = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4204, "Adv_InitializeGame_Person_I_4204"));
            CA!.Noun_Hochbauten = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4205, "Adv_InitializeGame_Person_I_4205"));
            CA!.Noun_Hochhaus = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4206, "Adv_InitializeGame_Person_I_4206"));
            CA!.Noun_Geisterschiff = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4207, "Adv_InitializeGame_Person_I_4207"));
            CA!.Noun_Gebeine = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4208, "Adv_InitializeGame_Person_I_4208"));
            CA!.Noun_Schaufenster = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4209, "Adv_InitializeGame_Person_I_4209"));
            CA!.Noun_Stangen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4210, "Adv_InitializeGame_Person_I_4210"));
            CA!.Noun_Muelleimer = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4211, "Adv_InitializeGame_Person_I_4211"));
            CA!.Noun_Gitter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4212, "Adv_InitializeGame_Person_I_4212"));
            CA!.Noun_Staebe = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4213, "Adv_InitializeGame_Person_I_4213"));
            CA!.Noun_Staebchen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4214, "Adv_InitializeGame_Person_I_4214"));
            CA!.Noun_Grappa = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4215, "Adv_InitializeGame_Person_I_4215"));
            CA!.Noun_Bauer = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4216, "Adv_InitializeGame_Person_I_4216"));
            CA!.Noun_Senf = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4217, "Adv_InitializeGame_Person_I_4217"));
            CA!.Noun_Esse = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4218, "Adv_InitializeGame_Person_I_4218"));
            CA!.Noun_Zucker = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4219, "Adv_InitializeGame_Person_I_4219"));
            CA!.Noun_Paeckchen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4220, "Adv_InitializeGame_Person_I_4220"));
            CA!.Noun_Wanne = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4221, "Adv_InitializeGame_Person_I_4221"));
            CA!.Noun_Spinnweben = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4222, "Adv_InitializeGame_Person_I_4222"));
            CA!.Noun_Prunktuer = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4223, "Adv_InitializeGame_Person_I_4223"));
            CA!.Noun_Nackttaenzerinnen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4224, "Adv_InitializeGame_Person_I_4224"));
            CA!.Noun_Nackttaenzerin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4225, "Adv_InitializeGame_Person_I_4225"));
            CA!.Noun_Taenzerinnen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4226, "Adv_InitializeGame_Person_I_4226"));
            CA!.Noun_Taenzerin = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4227, "Adv_InitializeGame_Person_I_4227"));
            CA!.Noun_Koeche = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4228, "Adv_InitializeGame_Person_I_4228"));
            CA!.Noun_Folie = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4229, "Adv_InitializeGame_Person_I_4229"));
            CA!.Noun_Holz = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4230, "Adv_InitializeGame_Person_I_4230"));
            CA!.Noun_Metall = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4231, "Adv_InitializeGame_Person_I_4231"));
            CA!.Noun_Schiebewagen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4232, "Adv_InitializeGame_Person_I_4232"));
            CA!.Noun_Wagen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4233, "Adv_InitializeGame_Person_I_4233"));
            CA!.Noun_Postsack = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4234, "Adv_InitializeGame_Person_I_4234"));
            CA!.Noun_Heliumbehaelter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4235, "Adv_InitializeGame_Person_I_4235"));
            CA!.Noun_Helium = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4236, "Adv_InitializeGame_Person_I_4236"));
            CA!.Noun_Flasche = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4237, "Adv_InitializeGame_Person_I_4237"));
            CA!.Noun_Bodenteppich = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4238, "Adv_InitializeGame_Person_I_4238"));
            CA!.Noun_Naegel = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4239, "Adv_InitializeGame_Person_I_4239"));
            CA!.Noun_Loch = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4240, "Adv_InitializeGame_Person_I_4240"));
            CA!.Noun_Berg = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4241, "Adv_InitializeGame_Person_I_4241"));
            CA!.Noun_Puppenberg = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4242, "Adv_InitializeGame_Person_I_4242"));
            CA!.Noun_Puppen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4243, "Adv_InitializeGame_Person_I_4243"));
            CA!.Noun_Stoffpuppen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4244, "Adv_InitializeGame_Person_I_4244"));
            CA!.Noun_Stofftiere = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4245, "Adv_InitializeGame_Person_I_4245"));
            CA!.Noun_Wuermer = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4246, "Adv_InitializeGame_Person_I_4246"));
            CA!.Noun_Gewand = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4247, "Adv_InitializeGame_Person_I_4247"));
            CA!.Noun_Servierhaube = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4248, "Adv_InitializeGame_Person_I_4248"));
            CA!.Noun_Haube = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4249, "Adv_InitializeGame_Person_I_4249"));
            CA!.Noun_Servierplatte = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4250, "Adv_InitializeGame_Person_I_4250"));
            CA!.Noun_Platte = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4251, "Adv_InitializeGame_Person_I_4251"));
            CA!.Noun_Mahl = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4252, "Adv_InitializeGame_Person_I_4252"));
            CA!.Noun_Werbetafeln = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4253, "Adv_InitializeGame_Person_I_4253"));
            CA!.Noun_Tafeln = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4254, "Adv_InitializeGame_Person_I_4254"));
            CA!.Noun_Ballen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4255, "Adv_InitializeGame_Person_I_4255"));
            CA!.Noun_Bacon = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4256, "Adv_InitializeGame_Person_I_4256"));
            CA!.Noun_Streifen = Nouns.Add(Noun.NounLocaLoca ( loca.Adv_InitializeGame_Person_I_4257, "Adv_InitializeGame_Person_I_4257"));
            CA!.Noun_Blumen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4258, "Adv_InitializeGame_Person_I_4258"));
            CA!.Noun_Wiese = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4259, "Adv_InitializeGame_Person_I_4259"));
            CA!.Noun_Joystick = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4260, "Adv_InitializeGame_Person_I_4260"));
            CA!.Noun_Anlage = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4261, "Adv_InitializeGame_Person_I_4261"));
            CA!.Noun_Kran = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4262, "Adv_InitializeGame_Person_I_4262"));
            CA!.Noun_Krananlage = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4263, "Adv_InitializeGame_Person_I_4263"));
            CA!.Noun_Buecherhaufen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4264, "Adv_InitializeGame_Person_I_4264"));
            CA!.Noun_Haufen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4265, "Adv_InitializeGame_Person_I_4265"));
            CA!.Noun_Hippie = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4266, "Adv_InitializeGame_Person_I_4266"));
            CA!.Noun_Partypeople = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4267, "Adv_InitializeGame_Person_I_4267"));
            Nouns.AddLocaLoca(CA!.Noun_Partypeople!.ID, loca.Adv_InitializeGame_Person_I_4268, "Adv_InitializeGame_Person_I_4268");
            CA!.Noun_Party = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4269, "Adv_InitializeGame_Person_I_4269"));
            CA!.Noun_People = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4270, "Adv_InitializeGame_Person_I_4270"));
            CA!.Noun_Blaetter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4271, "Adv_InitializeGame_Person_I_4271"));
            CA!.Noun_Blatt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4272, "Adv_InitializeGame_Person_I_4272"));
            CA!.Noun_Ruecken = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4273, "Adv_InitializeGame_Person_I_4273"));
            CA!.Noun_Hippieruecken = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4274, "Adv_InitializeGame_Person_I_4274"));
            CA!.Noun_Pullover = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4275, "Adv_InitializeGame_Person_I_4275"));
            CA!.Noun_Kelch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4276, "Adv_InitializeGame_Person_I_4276"));
            CA!.Noun_Blume = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4277, "Adv_InitializeGame_Person_I_4277"));
            CA!.Noun_Bluetenkelch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4278, "Adv_InitializeGame_Person_I_4278"));
            CA!.Noun_Landvermesser = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4279, "Adv_InitializeGame_Person_I_4279"));
            CA!.Noun_Vermesser = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4280, "Adv_InitializeGame_Person_I_4280"));
            CA!.Noun_Moerser = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4281, "Adv_InitializeGame_Person_I_4281"));
            Nouns.AddLocaLoca(CA!.Noun_Moerser!.ID, loca.Adv_InitializeGame_Person_I_4282, "Adv_InitializeGame_Person_I_4282");
            CA!.Noun_Stoessel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4283, "Adv_InitializeGame_Person_I_4283"));
            CA!.Noun_Gin = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4284, "Adv_InitializeGame_Person_I_4284"));
            CA!.Noun_Kohle = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4285, "Adv_InitializeGame_Person_I_4285"));
            CA!.Noun_Satanisten = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4286, "Adv_InitializeGame_Person_I_4286"));
            CA!.Noun_Satanist = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4287, "Adv_InitializeGame_Person_I_4287"));
            CA!.Noun_Attraktionen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4288, "Adv_InitializeGame_Person_I_4288"));
            CA!.Noun_Attraktion = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4289, "Adv_InitializeGame_Person_I_4289"));
            CA!.Noun_Lautsprecher = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4290, "Adv_InitializeGame_Person_I_4290"));
            CA!.Noun_Smartphone = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4291, "Adv_InitializeGame_Person_I_4291"));
            Nouns.AddLocaLoca(CA!.Noun_Smartphone!.ID, loca.Adv_InitializeGame_Person_I_4292, "Adv_InitializeGame_Person_I_4292");
            CA!.Noun_Dimensionstor = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4293, "Adv_InitializeGame_Person_I_4293"));
            CA!.Noun_Motiv = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4294, "Adv_InitializeGame_Person_I_4294"));
            CA!.Noun_Motive = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4295, "Adv_InitializeGame_Person_I_4295"));
            CA!.Noun_Ruine = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4296, "Adv_InitializeGame_Person_I_4296"));
            CA!.Noun_Mansion = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4297, "Adv_InitializeGame_Person_I_4297"));
            CA!.Noun_Galgen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4298, "Adv_InitializeGame_Person_I_4298"));
            CA!.Noun_Gehenkte = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4299, "Adv_InitializeGame_Person_I_4299"));
            CA!.Noun_Erde = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4300, "Adv_InitializeGame_Person_I_4300"));
            CA!.Noun_Idiot = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4301, "Adv_InitializeGame_Person_I_4301"));
            CA!.Noun_Steinpfad = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4302, "Adv_InitializeGame_Person_I_4302"));
            CA!.Noun_Farmer = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4303, "Adv_InitializeGame_Person_I_4303"));
            CA!.Noun_Farmerin = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4304, "Adv_InitializeGame_Person_I_4304"));
            CA!.Noun_Kadaver = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4305, "Adv_InitializeGame_Person_I_4305"));
            CA!.Noun_Mogul = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4306, "Adv_InitializeGame_Person_I_4306"));
            CA!.Noun_Nachricht = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4307, "Adv_InitializeGame_Person_I_4307"));
            CA!.Noun_Notiz = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4308, "Adv_InitializeGame_Person_I_4308"));
            CA!.Noun_Peitsche = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4309, "Adv_InitializeGame_Person_I_4309"));
            CA!.Noun_Schale = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4310, "Adv_InitializeGame_Person_I_4310"));
            CA!.Noun_Schrauber = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4311, "Adv_InitializeGame_Person_I_4311"));
            CA!.Noun_Spielgeldboegen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4312, "Adv_InitializeGame_Person_I_4312"));
            CA!.Noun_Werkzeug = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4313, "Adv_InitializeGame_Person_I_4313"));
            CA!.Noun_Runen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4314, "Adv_InitializeGame_Person_I_4314"));
            CA!.Noun_Teufelsstatuette = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4315, "Adv_InitializeGame_Person_I_4315"));
            CA!.Noun_Teufel = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4316, "Adv_InitializeGame_Person_I_4316"));
            CA!.Noun_Boegen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4317, "Adv_InitializeGame_Person_I_4317"));
            CA!.Noun_Papierbogen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4318, "Adv_InitializeGame_Person_I_4318"));
            CA!.Noun_Abteilung = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4319, "Adv_InitializeGame_Person_I_4319"));
            CA!.Noun_Accessoires = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4320, "Adv_InitializeGame_Person_I_4320"));
            CA!.Noun_Fetisch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4321, "Adv_InitializeGame_Person_I_4321"));
            CA!.Noun_Fetischaccessoires = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4322, "Adv_InitializeGame_Person_I_4322"));
            CA!.Noun_Lackundleder_Abteilung = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4323, "Adv_InitializeGame_Person_I_4323"));
            CA!.Noun_Leder = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4324, "Adv_InitializeGame_Person_I_4324"));
            CA!.Noun_Lederoutfit = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4325, "Adv_InitializeGame_Person_I_4325"));
            CA!.Noun_Lederoutfits = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4326, "Adv_InitializeGame_Person_I_4326"));
            CA!.Noun_Luxus = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4327, "Adv_InitializeGame_Person_I_4327"));
            CA!.Noun_Luxusabteilung = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4328, "Adv_InitializeGame_Person_I_4328"));
            CA!.Noun_Outfit = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4329, "Adv_InitializeGame_Person_I_4329"));
            CA!.Noun_Sextoys = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4330, "Adv_InitializeGame_Person_I_4330"));
            CA!.Noun_Toys = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4331, "Adv_InitializeGame_Person_I_4331"));
            CA!.Noun_Dildos = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4332, "Adv_InitializeGame_Person_I_4332"));
            CA!.Noun_Dildo = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4333, "Adv_InitializeGame_Person_I_4333"));
            CA!.Noun_Tempel = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4334, "Adv_InitializeGame_Person_I_4334"));
            CA!.Noun_Waesche = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4335, "Adv_InitializeGame_Person_I_4335"));
            CA!.Noun_Wolken = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4336, "Adv_InitializeGame_Person_I_4336"));
            CA!.Noun_Wolke = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4337, "Adv_InitializeGame_Person_I_4337"));
            CA!.Noun_Henkerswald = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4338, "Adv_InitializeGame_Person_I_4338"));
            CA!.Noun_Nackttaenzer = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4339, "Adv_InitializeGame_Person_I_4339"));
            CA!.Noun_Taenzer = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4340, "Adv_InitializeGame_Person_I_4340"));
            CA!.Noun_Pflanzen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4341, "Adv_InitializeGame_Person_I_4341"));
            CA!.Noun_Saeure = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4342, "Adv_InitializeGame_Person_I_4342"));
            CA!.Noun_Saeureseen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4343, "Adv_InitializeGame_Person_I_4343"));
            CA!.Noun_Schling = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4344, "Adv_InitializeGame_Person_I_4344"));
            CA!.Noun_Schlingpflanzen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4345, "Adv_InitializeGame_Person_I_4345"));
            CA!.Noun_See = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4346, "Adv_InitializeGame_Person_I_4346"));
            CA!.Noun_Seen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4347, "Adv_InitializeGame_Person_I_4347"));
            CA!.Noun_Becken = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4348, "Adv_InitializeGame_Person_I_4348"));
            CA!.Noun_Waschbecken = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Waschbecken, "Noun_Waschbecken"));

            CA!.Noun_Kapelle = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4349, "Adv_InitializeGame_Person_I_4349"));
            CA!.Noun_Kirche = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4350, "Adv_InitializeGame_Person_I_4350"));
            CA!.Noun_Turm = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4351, "Adv_InitializeGame_Person_I_4351"));
            CA!.Noun_Wirtschaftsgebaeude = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4352, "Adv_InitializeGame_Person_I_4352"));
            CA!.Noun_Ball = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4353, "Adv_InitializeGame_Person_I_4353"));

            CA!.Noun_Wichser = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4354, "Adv_InitializeGame_Person_I_4354"));
            CA!.Noun_Arschloch = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4355, "Adv_InitializeGame_Person_I_4355"));
            CA!.Noun_Drecksau = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4356, "Adv_InitializeGame_Person_I_4356"));
            CA!.Noun_Werkzeugkiste = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4357, "Adv_InitializeGame_Person_I_4357"));
            CA!.Noun_Dart = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4358, "Adv_InitializeGame_Person_I_4358"));
            CA!.Noun_Schein = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4359, "Adv_InitializeGame_Person_I_4359"));
            CA!.Noun_Farbeimer = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4360, "Adv_InitializeGame_Person_I_4360"));
            CA!.Noun_Farbe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4361, "Adv_InitializeGame_Person_I_4361"));
            CA!.Noun_Bezug = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4362, "Adv_InitializeGame_Person_I_4362"));
            CA!.Noun_Schleuder = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4363, "Adv_InitializeGame_Person_I_4363"));
            Nouns.AddLocaLoca(CA!.Noun_Schleuder!.ID, loca.Adv_InitializeGame_Person_I_4364, "Adv_InitializeGame_Person_I_4364");
            CA!.Noun_Stift = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4365, "Adv_InitializeGame_Person_I_4365"));
            CA!.Noun_Balg = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4366, "Adv_InitializeGame_Person_I_4366"));
            CA!.Noun_Stange = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4367, "Adv_InitializeGame_Person_I_4367"));
            CA!.Noun_Mohn = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4368, "Adv_InitializeGame_Person_I_4368"));
            CA!.Noun_Opium = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4369, "Adv_InitializeGame_Person_I_4369"));
            CA!.Noun_Schlafmittel = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4370, "Adv_InitializeGame_Person_I_4370"));
            CA!.Noun_Ecke = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4371, "Adv_InitializeGame_Person_I_4371"));
            CA!.Noun_Lied = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4372, "Adv_InitializeGame_Person_I_4372"));
            CA!.Noun_Gemuese = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4373, "Adv_InitializeGame_Person_I_4373"));
            CA!.Noun_Zucchini = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4374, "Adv_InitializeGame_Person_I_4374"));
            CA!.Noun_Tomaten = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4375, "Adv_InitializeGame_Person_I_4375"));
            CA!.Noun_Tomate = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4376, "Adv_InitializeGame_Person_I_4376"));
            CA!.Noun_Lauch = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4377, "Adv_InitializeGame_Person_I_4377"));
            Nouns.AddLocaLoca(CA!.Noun_Lauch!.ID, loca.Adv_InitializeGame_Person_I_4378, "Adv_InitializeGame_Person_I_4378");
            Nouns.AddLocaLoca(CA!.Noun_Lauch!.ID, loca.Adv_InitializeGame_Person_I_4379, "Adv_InitializeGame_Person_I_4379");
            CA!.Noun_Karaffe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4380, "Adv_InitializeGame_Person_I_4380"));
            CA!.Noun_Schnapsglas = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4381, "Adv_InitializeGame_Person_I_4381"));
            CA!.Noun_Schnaps = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4382, "Adv_InitializeGame_Person_I_4382"));
            CA!.Noun_Dokument = Nouns.Add(Noun.NounLocaLoca(  loca.Adv_InitializeGame_Person_I_4383, "Adv_InitializeGame_Person_I_4383"));

            CA!.Noun_Ketchupflecken = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4384, "Adv_InitializeGame_Person_I_4384"));
            CA!.Noun_Ketchup = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4385, "Adv_InitializeGame_Person_I_4385"));
            CA!.Noun_Flecken = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4386, "Adv_InitializeGame_Person_I_4386"));
            CA!.Noun_Gefangene = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4387, "Adv_InitializeGame_Person_I_4387"));
            CA!.Noun_Maden = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4388, "Adv_InitializeGame_Person_I_4388"));
            CA!.Noun_Engerlinge = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4389, "Adv_InitializeGame_Person_I_4389"));

            CA!.Noun_Metropole = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4390, "Adv_InitializeGame_Person_I_4390"));
            CA!.Noun_Huegel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4391, "Adv_InitializeGame_Person_I_4391"));
            CA!.Noun_Burgruine = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4392, "Adv_InitializeGame_Person_I_4392"));
            CA!.Noun_Teufelswald = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4393, "Adv_InitializeGame_Person_I_4393"));
            CA!.Noun_Schwefel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4394, "Adv_InitializeGame_Person_I_4394"));
            CA!.Noun_Burg = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4395, "Adv_InitializeGame_Person_I_4395"));

            CA!.Noun_Fuellfederhalter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4396, "Adv_InitializeGame_Person_I_4396"));
            CA!.Noun_Federhalter = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4397, "Adv_InitializeGame_Person_I_4397"));
            CA!.Noun_Fueller = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4398, "Adv_InitializeGame_Person_I_4398"));
            CA!.Noun_Schlaufe = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4399, "Adv_InitializeGame_Person_I_4399"));
            CA!.Noun_Tuete = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4400, "Adv_InitializeGame_Person_I_4400"));

            CA!.Noun_Schreib = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4401, "Adv_InitializeGame_Person_I_4401"));
            CA!.Noun_Stifthalter = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4402, "Adv_InitializeGame_Person_I_4402"));
            CA!.Noun_Scheine = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4405, "Adv_InitializeGame_Person_I_4405"));
            CA!.Noun_Glasschneider = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4406, "Adv_InitializeGame_Person_I_4406"));
            CA!.Noun_Schneider = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4407, "Adv_InitializeGame_Person_I_4407"));
            CA!.Noun_Urkunde = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4408, "Adv_InitializeGame_Person_I_4408"));
            CA!.Noun_Pendel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4409, "Adv_InitializeGame_Person_I_4409"));
            CA!.Noun_Aubergine = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4410, "Adv_InitializeGame_Person_I_4410"));
            CA!.Noun_Spruehflasche = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4411, "Adv_InitializeGame_Person_I_4411"));

            CA!.Noun_Gewaechshaus = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4412, "Adv_InitializeGame_Person_I_4412"));
            CA!.Noun_Terminal = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4413, "Adv_InitializeGame_Person_I_4413"));
            CA!.Noun_Natron = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4414, "Adv_InitializeGame_Person_I_4414"));
            CA!.Noun_Packung = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4415, "Adv_InitializeGame_Person_I_4415"));
            CA!.Noun_Apfelessig = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4416, "Adv_InitializeGame_Person_I_4416"));
            CA!.Noun_Apfel = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4417, "Adv_InitializeGame_Person_I_4417"));
            CA!.Noun_Essig = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4418, "Adv_InitializeGame_Person_I_4418"));
            CA!.Noun_Polierlappen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4419, "Adv_InitializeGame_Person_I_4419"));
            CA!.Noun_Lappen = Nouns.Add(Noun.NounLocaLoca( loca.Adv_InitializeGame_Person_I_4420, "Adv_InitializeGame_Person_I_4420"));

            CA!.Noun_Grapefruitextrakt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4421, "Adv_InitializeGame_Person_I_4421"));
            CA!.Noun_Grapefruit = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4422, "Adv_InitializeGame_Person_I_4422"));
            CA!.Noun_Extrakt = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4423, "Adv_InitializeGame_Person_I_4423"));
            CA!.Noun_Flaeschchen = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_4424, "Adv_InitializeGame_Person_I_4424"));


            CA!.Noun_Dimensions = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Dimensions, "Noun_Dimensions"));
            CA!.Noun_Folter = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Folter, "Noun_Folter"));
            CA!.Noun_Lachen = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Lachen, "Noun_Lachen"));
            CA!.Noun_Streck = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Streck, "Noun_Streck"));
            CA!.Noun_Versammlungs = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Versammlungs, "Noun_Versammlungs"));

            CA!.Noun_Wirtschafts = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Wirtschafts, "Noun_Wirtschafts"));
            CA!.Noun_Wendel = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Wendel, "Noun_Wendel"));
            CA!.Noun_Paradies = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Paradies, "Noun_Paradies"));
            CA!.Noun_Mann = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Mann, "Noun_Mann"));
            CA!.Noun_Eichen = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Eichen, "Noun_Eichen"));
            CA!.Noun_Blick = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Blick, "Noun_Blick"));

            CA!.Noun_Fluegel = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Fluegel, "Noun_Fluegel"));
            CA!.Noun_Steuer = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Steuer, "Noun_Steuer"));
            CA!.Noun_Back = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Back, "Noun_Back"));
            CA!.Noun_Arbeit = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Arbeit, "Noun_Arbeit"));
            CA!.Noun_Oliven = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Oliven, "Noun_Oliven"));
            CA!.Noun_Wohn = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Wohn, "Noun_Wohn"));
            CA!.Noun_Hafen = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Hafen, "Noun_Hafen"));
            CA!.Noun_Agrikultur = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Agrikultur, "Noun_Agrikultur"));
            CA!.Noun_Polizei = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Polizei, "Noun_Polizei"));
            CA!.Noun_Bereich = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Bereich, "Noun_Bereich"));
            CA!.Noun_Laub = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Laub, "Noun_Laub"));
            CA!.Noun_Regen = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Regen, "Noun_Regen"));
            CA!.Noun_Warte = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Warte, "Noun_Warte"));

            CA!.Noun_Dreh = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Dreh, "Noun_Dreh"));
            CA!.Noun_Ess = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Ess, "Noun_Ess"));
            CA!.Noun_Fracht = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Fracht, "Noun_Fracht"));
            CA!.Noun_Garten = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Garten, "Noun_Garten"));
            CA!.Noun_Kombination = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Kombination, "Noun_Kombination"));
            CA!.Noun_Lust = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Lust, "Noun_Lust"));
            CA!.Noun_Nackt = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Nackt, "Noun_Nackt"));
            CA!.Noun_Prunk = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Prunk, "Noun_Prunk"));
            CA!.Noun_Raum = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Raum, "Noun_Raum"));
            CA!.Noun_Schlitz = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Schlitz, "Noun_Schlitz"));
            CA!.Noun_Spielzeug = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Spielzeug, "Noun_Spielzeug"));
            CA!.Noun_Stahl = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Stahl, "Noun_Stahl"));
            CA!.Noun_Staub = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Staub, "Noun_Staub"));
            CA!.Noun_Stumpf = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Stumpf, "Noun_Stumpf"));
            CA!.Noun_Sumpf = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Sumpf, "Noun_Sumpf"));
            CA!.Noun_Wohn2 = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Wohn2, "Noun_Wohn2"));
            CA!.Noun_Zigarren = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Zigarren, "Noun_Zigarren"));

            // CA!.Noun_Edel = Nouns.Add(Noun.NounLocaLoca("Noun_Edel"));
            CA!.Noun_Ende = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Ende, "Noun_Ende"));
            CA!.Noun_Fahndung = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Fahndung, "Noun_Fahndung"));
            CA!.Noun_Himmel = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Himmel, "Noun_Himmel"));
            CA!.Noun_Heaven = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Heaven, "Noun_Heaven"));
            CA!.Noun_Kommunikation = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Kommunikation, "Noun_Kommunikation"));
            CA!.Noun_Lade = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Lade, "Noun_Lade"));
            CA!.Noun_Logistik = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Logistik, "Noun_Logistik"));
            CA!.Noun_Palaeste = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Palaeste, "Noun_Palaeste"));
            CA!.Noun_Satan = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Satan, "Noun_Satan"));
            CA!.Noun_Servier = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Servier, "Noun_Servier"));
            CA!.Noun_Stern = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Stern, "Noun_Stern"));
            CA!.Noun_Verkaufs = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Verkaufs, "Noun_Verkaufs"));

            CA!.Noun_Alfonsius = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Alfonsius, "Noun_Alfonsius"));
            CA!.Noun_Anzug = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Anzug, "Noun_Anzug"));
            CA!.Noun_Baeren = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Baeren, "Noun_Baeren"));
            CA!.Noun_Baseball = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Baseball, "Noun_Baseball"));
            CA!.Noun_Botanik = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Botanik, "Noun_Botanik"));
            CA!.Noun_Buesser = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Buesser, "Noun_Buesser"));
            CA!.Noun_Daemon = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Daemon, "Noun_Daemon"));
            CA!.Noun_Experten = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Experten, "Noun_Experten"));
            CA!.Noun_Fallen = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Fallen, "Noun_Fallen"));
            CA!.Noun_Fesseln = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Fesseln, "Noun_Fesseln"));
            CA!.Noun_Frischhalte = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Frischhalte, "Noun_Frischhalte"));
            CA!.Noun_Friteuse1 = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Friteuse1, "Noun_Friteuse1"));
            CA!.Noun_Gebaeude_pl = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Gebaeude_pl, "Noun_Gebaeude_pl"));
            CA!.Noun_Geist = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Geist, "Noun_Geist"));
            CA!.Noun_Geraet = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Geraet, "Noun_Geraet"));
            CA!.Noun_Giess = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Giess, "Noun_Giess"));
            CA!.Noun_Golf = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Golf, "Noun_Golf"));
            CA!.Noun_Hanf = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Hanf, "Noun_Hanf"));
            CA!.Noun_Henker = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Henker, "Noun_Henker"));
            CA!.Noun_Insel = Nouns.Add(Noun.NounLocaLoca(loca.Adv_InitializeGame_Person_I_3691, "Adv_InitializeGame_Person_I_3691"));
            CA!.Noun_Kappe = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Kappe, "Noun_Kappe"));
            CA!.Noun_Kartoffel = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Kartoffel, "Noun_Kartoffel"));
            CA!.Noun_Knochen = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Knochen, "Noun_Knochen"));
            CA!.Noun_Kopf = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Kopf, "Noun_Kopf"));
            CA!.Noun_Liefer = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Liefer, "Noun_Liefer"));
            CA!.Noun_Lippenstift = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Lippenstift, "Noun_Lippenstift"));
            CA!.Noun_Meinung = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Meinung, "Noun_Meinung"));
            CA!.Noun_Menschen = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Menschen, "Noun_Menschen"));
            CA!.Noun_Musik = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Musik, "Noun_Musik"));
            CA!.Noun_Outfits = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Outfits, "Noun_Outfits"));
            CA!.Noun_Papp = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Papp, "Noun_Papp"));
            CA!.Noun_Permanent = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Permanent, "Noun_Permanent"));
            CA!.Noun_Polier = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Polier, "Noun_Polier"));
            CA!.Noun_Rechenschafts = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Rechenschafts, "Noun_Rechenschafts"));
            CA!.Noun_Satans = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Satans, "Noun_Satans"));
            CA!.Noun_Schaukel = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Schaukel, "Noun_Schaukel"));
            CA!.Noun_Schiebe = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Schiebe, "Noun_Schiebe"));
            CA!.Noun_Schlaf = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Schlaf, "Noun_Schlaf"));
            CA!.Noun_Shot = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Shot, "Noun_Shot"));
            CA!.Noun_Sitz = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Sitz, "Noun_Sitz"));
            CA!.Noun_Slip = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Slip, "Noun_Slip"));
            CA!.Noun_Soda = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Soda, "Noun_Soda"));
            CA!.Noun_Spiel = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Spiel, "Noun_Spiel"));
            CA!.Noun_Spreng = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Spreng, "Noun_Spreng"));
            CA!.Noun_Sprueh = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Sprueh, "Noun_Sprueh"));
            CA!.Noun_Stueck = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Stueck, "Noun_Stueck"));
            CA!.Noun_Suessigkeiten = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Suessigkeiten, "Noun_Suessigkeiten"));
            CA!.Noun_Taucher = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Taucher, "Noun_Taucher"));
            CA!.Noun_Teufels = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Teufels, "Noun_Teufels"));
            CA!.Noun_Ticket = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Ticket, "Noun_Ticket"));
            CA!.Noun_Visiten = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Visiten, "Noun_Visiten"));

            CA!.Noun_Bell = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Bell, "Noun_Bell"));
            CA!.Noun_Beton = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Beton, "Noun_Beton"));
            CA!.Noun_Block = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Block, "Noun_Block"));
            CA!.Noun_Dinner = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Dinner, "Noun_Dinner"));
            CA!.Noun_Flask = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Flask, "Noun_Flask"));
            CA!.Noun_Hip = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Hip, "Noun_Hip"));
            CA!.Noun_Pulley = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Pulley, "Noun_Pulley"));
            // CA!.Noun_Creature = Nouns.Add(Noun.NounLocaLoca("Noun_Creature"));
            CA!.Noun_Hell = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Hell, "Noun_Hell"));
            CA!.Noun_Horde = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Horde, "Noun_Horde"));

            CA!.Noun_Shards = Nouns.Add(Noun.NounLocaLoca(loca.Noun_Shards, "Noun_Shards"));
            CA!.Noun_China = Nouns.Add(Noun.NounLocaLoca(loca.Noun_China, "Noun_China"));
            CA!.Noun_Waste = Nouns.Add(Noun.NounLocaLoca( loca.Noun_Waste, "Noun_Waste"));
            CA!.Noun_Dome = Nouns.Add(Noun.NounLoca("Adv_InitializeGame_Dome"));

            Nouns!.TList = new Dictionary<string, Noun>(Nouns.GetNounBuffer()!, StringComparer.CurrentCultureIgnoreCase);

        }

        void InitPersons()
        {
            CA!.Person_Knights_Armor = Persons!.Add(Person.PersonLoca(new List<Noun> { CA!.Noun_Ritterruestung! }, new List<Adj> { CA!.Adj_stattlich! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L06_Long_Floor, "Adv_Person_Knights_Armor", Co.SZ_medium, true, DoRitterruestung, Nouns, Adjs));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Takeable));
            Persons!.Last()!.SynNames = new List<Noun> { CA!.Noun_Ritter!, CA!.Noun_Ruestung! };
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Talkable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_GiveTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_QuestionTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_UsableWith));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Listenable));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Touchwithable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_CleanableWith));

            CA!.Person_Owl = Persons!.Add(Person.PersonLoca(new List<Noun> { CA!.Noun_Eule! }, new List<Adj> { CA!.Adj_ausgestopft! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L05_Atrium, "Adv_Person_Owl", Co.SZ_medium, true, DoOwl, Nouns, Adjs));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Takeable));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Talkable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_GiveTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_QuestionTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_UsableWith));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Listenable));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Touchwithable), relTypes.r_essential);
            Persons!.Last()!.IsBackground = true;

            CA!.Person_Librarian = Persons!.Add(Person.PersonLoca(new List<Noun> { CA!.Noun_Skelett! }, new List<Adj> { CA!.Adj_vergilbt! }, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L09_Library, "Adv_Person_Librarian", Co.SZ_medium, true, DoSkeleton, Nouns, Adjs));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Talkable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_GiveTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_QuestionTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_UsableWith));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Listenable));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Touchwithable), relTypes.r_essential);

            CA!.Person_Fish = Persons!.Add(Person.PersonLoca(new List<Noun> { CA!.Noun_Fish! }, new List<Adj> { CA!.Adj_ausgestopft! }, Co.SEX_MALE, CB!.LocType_On_Item, CA!.I11_Left_Shelf!.ID, "Adv_Person_Fish", Co.SZ_medium, true, DoFish, Nouns, Adjs));
            CA!.Person_Fish.CanBeTaken = true;
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Takeable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Talkable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_GiveTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_QuestionTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_UsableWith));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Listenable));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Touchwithable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_UsableWith));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Throwable));

            CA!.Person_Parrot = Persons!.Add(Person.PersonLoca(new List<Noun> { CA!.Noun_Papagei! }, new List<Adj> { CA!.Adj_ausgestopft! }, Co.SEX_MALE, CB!.LocType_On_Item, CA!.I11_Left_Shelf.ID, "Adv_Person_Parrot", Co.SZ_medium, true, DoParrot, Nouns, Adjs));
            CA!.Person_Parrot!.CanBeTaken = true;
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Takeable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Talkable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_GiveTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_QuestionTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_UsableWith));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Listenable));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Touchwithable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Throwable), relTypes.r_essential);

            CA!.Person_Snake = Persons!.Add(Person.PersonLoca(new List<Noun> { CA!.Noun_Schlange! }, new List<Adj> { CA!.Adj_ausgestopft! }, Co.SEX_FEMALE, CB!.LocType_On_Item, CA!.I11_Right_Shelf!.ID, "Adv_Person_Snake", Co.SZ_medium, true, DoSnake, Nouns, Adjs));
            CA!.Person_Snake.CanBeTaken = true;
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Takeable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Talkable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_GiveTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_QuestionTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_UsableWith));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Listenable));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Touchwithable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Throwable), relTypes.r_essential);

            CA!.Person_Magpie = Persons!.Add(Person.PersonLoca(new List<Noun> { CA!.Noun_Elster! }, new List<Adj> { CA!.Adj_ausgestopft! }, Co.SEX_FEMALE, CB!.LocType_On_Item, CA!.I11_Bird_Stand!.ID, "Adv_Person_Magpie", Co.SZ_medium, true, DoMagpie, Nouns, Adjs));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Talkable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Takeable), relTypes.r_essential);
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_GiveTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_QuestionTarget));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_UsableWith));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Listenable));
            Persons!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Touchwithable), relTypes.r_essential);
        }

        // List<IUIServices.ZipObject> zo2 = UIS.LoadFromZip("initdata");
        // Nouns = LoadNouns(zo2[0].Data); //  (zo2[0].Data as NounList;  // LoadNouns();

#pragma warning disable CS0108 // "Adv.InitializeGame()" blendet den vererbten Member "AdvBase.InitializeGame()" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.

        public void InitializeGame( )
#pragma warning restore CS0108 // "Adv.InitializeGame()" blendet den vererbten Member "AdvBase.InitializeGame()" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        {
            GD!.InitRandom(43);
            CA = new CoAdv();
            // Co.CA = CA;


 
            LI = new List<LatestInput>();

            A = new AdvData();
            A.StartLoc = CA.L01_Dark_Forest; // CA!.LX_01_Hausflur;
            A.Tense = CB!.Tense_Past;
            CA!.Person_Self = CA!.Person_I;
            A!.ActLoc = A.StartLoc;
            // A!.ActPerson = CA!.Person_I!.ID;
            A!.ActScore = 0;
            A.MaxScore = 33;
            // A.Adventure = this;

            InitOrderPath();
            CurrentEventName = loca.ScoreEvent_Start;

            Categories = new CategoryRelList( true );

            // MCE = new List<MCEntry>();
            Items = new ItemList(1500);

            Grammar.Init(A, VerbTenses!, Items, Persons!);
            // DoGrammar = new Grammar(A, VerbTenses, Items, Persons);

            Persons = new PersonList(this, A, Items);

            Grammar.SetPersons(Persons);

            Topics = new TopicList();

            Adjs = new AdjList();
            Stats = new StatusList();
            Scores = new ScoreList();
            // OrderList = new OrderList( SaveOrderTable);
            // OrderList.SetShowChanges = MW.UpdateOrderList;
            // OrderList.AddOrderList( "Liste1");


            locations = new locationList(this, A, Items, Persons, Verbs!, CB, Stats, VerbTenses!);

            Orders = new Order();
            // Orders = new Order(this, A, Verbs, Items, Persons, Topics, locations, Stats, Scores, GD!.OrderList, Nouns, Adjs, Preps, Pronouns, Fills, ItemQueue, CB, CA, LI);

            // Helper.ConfigInsert(Persons, Items, locations, Topics, CB, A, this );
            // MW.controlAkk.Text = "Hanswurst";

            timeFiGedoens = stopwatch!.ElapsedMilliseconds;


            InitCategories();

            timeFiCategories = stopwatch.ElapsedMilliseconds;

            if (LoadedInitData == null)
                InitVerbsPart2Fast();
            else
                Verbs = LoadVerbs();

            timeFiVerbs = stopwatch.ElapsedMilliseconds;

            if (LoadedInitData == null)
                InitAdjectivesFast();
            else
                Adjs = LoadAdjs();

            timeFiAdjectives = stopwatch.ElapsedMilliseconds;

            if (LoadedInitData == null)
                InitNounsFast();
            else
                Nouns = LoadNouns();

            timeFiNouns = stopwatch.ElapsedMilliseconds;

            if (LoadedInitData == null)
                InitPLL();
            else
            {
                PLL = LoadPLL();
                PLLEng = LoadPLLEng();
            }
            timeFiPLL = stopwatch.ElapsedMilliseconds;

            // Neu Nouns

            if (LoadedInitData == null)
            {
                // var Itemlist = new List<KeyValuePair<string, Verb>>(600);

                Items!.SetupItemBuffer(1500);

                CA!.Person_Everyone = Persons!.Add(Person.PersonLoca(null, null, Co.SEX_MALE, CB!.LocType_Loc, -1, "Adv_InitializeGame_Person_Everyone_4425", Co.SZ_medium, true, null, Nouns, Adjs));
                CA!.Person_Everyone.IsRegular = false;
                CA!.Person_Self = CA!.Person_I = CA!.Person_Self = Persons!.Add(Person.PersonLoca(new List<Noun> { CA!.Noun_Ich! }, null, Co.SEX_MALE, CB!.LocType_Loc, A!.ActLoc, "Adv_InitializeGame_Person_Self_4426", Co.SZ_medium, true, null, Nouns, Adjs));
                CA!.Person_Self.IsRegular = false;
                Persons!.Last()!.SynNames!.Add(CA!.Noun_Du!);
                CA!.Person_You = Persons!.Add(Person.PersonLoca(null, null, Co.SEX_MALE, CB!.LocType_Loc, -1, "Adv_InitializeGame_Person_You_4428", Co.SZ_medium, true, null, Nouns, Adjs));
                CA!.Person_You.IsRegular = false;
                CA!.Person_3rdperson = Persons!.Add(Person.PersonLoca(null, null, Co.SEX_MALE, CB!.LocType_Loc, -1, "Adv_InitializeGame_Person_3rdperson_4429", Co.SZ_medium, true, null, Nouns, Adjs));
                CA!.Person_3rdperson.IsRegular = false;



                CA!.I00_Nullbehaelter = Items!.Add(Item.ItemLoca(new List<Noun> { CA!.Noun_Nullbehaelter! }, new List<Adj> { CA!.Adj_fragwuerdig! }, Co.SEX_MALE, CB!.LocType_Person, CA!.Person_Self.ID, "Adv_InitializeGame_Person_Self_4430", Co.SZ_medium, false, true, Nouns, Adjs));
                Items!.Last()!.CanBeClosed = true;
                Items!.Last()!.CanPutIn = true;
                Items!.Last()!.StorageIn = 100;
                Items!.Last()!.IsClosed = true;
                Items!.Last()!.IsRegular = false;

                CA!.I00_Nullbehaelter2 = Items!.Add(Item.ItemLoca(new List<Noun> { CA!.Noun_Nullbehaelter! }, new List<Adj> { CA!.Adj_seltsam! }, Co.SEX_MALE, CB!.LocType_Person, CA!.Person_Self.ID, "Adv_InitializeGame_Person_Self_4431", Co.SZ_medium, false, true, Nouns, Adjs));
                Items!.Last()!.CanBeClosed = true;
                Items!.Last()!.CanPutIn = true;
                Items!.Last()!.StorageIn = 10000;
                Items!.Last()!.IsClosed = true;
                Items!.Last()!.IsRegular = false;

                CA!.I00_Nullbehaelter3 = Items!.Add(Item.ItemLoca(new List<Noun> { CA!.Noun_Nullbehaelter! }, new List<Adj> { CA!.Adj_abscheulich! }, Co.SEX_MALE, CB!.LocType_Person, CA!.Person_Self.ID, "Adv_InitializeGame_Person_Self_4432", Co.SZ_medium, false, true, Nouns, Adjs));
                Items!.Last()!.CanBeClosed = true;
                Items!.Last()!.CanPutIn = true;
                Items!.Last()!.StorageIn = 10000;
                Items!.Last()!.IsClosed = true;
                Items!.Last()!.IsRegular = false;


                if (GameTestMode == false)
                {
                    CA!.I00_Nullbehaelter!.locationID = 0;
                    CA!.I00_Nullbehaelter2!.locationID = 0;
                    CA!.I00_Nullbehaelter3!.locationID = 0;
                }
                Items!.Last()!.Categories!.Add(Categories!.Find(A.Cat_Cleanable));
                Items!.Last()!.Categories!.Add(Categories!.Find(A.CounterCat_UsableWith));

                InitItems();
                InitPersons();
            }
            else
            {
                Items = LoadItems();

                Persons = LoadPersons();
            }

            timeFiPersons = stopwatch.ElapsedMilliseconds;


            /*
        public Person? Person_Kuechenchefin;
        public Person? Person_Proviantmeister;
        public Person? Person_Kuechenjunge;
        public Person? Person_Priester;

        public Person? Person_Dolly_PV1;
        public Person? Person_Stealthy_Steven_PV1;
        public Person? Person_Phoney_PV1;
        public Person? Person_Ghoul_PV1;
        public Person? Person_Scaramango_PV1;
        public Person? Person_Brueckenwache_PV1;
        public Person? Person_Fette_Wache_PV1;
        public Person? Person_Middlefinger_PV1;
        public Person? Person_Kuechenchefin_PV1;
        public Person? Person_Proviantmeister_PV1;
        public Person? Person_Kuechenjunge_PV1;
        public Person? Person_Priester_PV1;

            */

            if (LoadedInitData == null)
            {
            }
            //
            // CA!.TP_Boden = Topics.Add(new Topic(new List<Noun> { CA!.Noun_Boden }, new List<Adj> { CA!.Adj_gewoehnlich }, Co.SEX_MALE, Nouns, Adjs));
            // CA!.TP_Ecke = Topics.Add(new Topic(new List<Noun> { CA!.Noun_Ecke }, null, Co.SEX_FEMALE, Nouns, Adjs));
            CA!.TP_Versteck = Topics!.Add(new Topic(new List<Noun> { CA!.Noun_Versteck! }, null, Co.SEX_NEUTER, Nouns!, Adjs!));
            // TEST
            // Aufgemerkt: Das muss nachher wieder raus, sobald die CAs korrekt verschaltet sind
            if (LoadedInitData == null)
            {
                A!.ActPerson = CA!.Person_I!.ID;
            }

            /*
            else
            {
                Items = LoadItems();
            }
            */
            timeFiItems = stopwatch.ElapsedMilliseconds;

            // ScanCloneSignatures();

            if (LoadedInitData == null)
            {
                Initlocations();
            }
            else
            {
                locations = LoadLocations();
            }

            timeFiLocations = stopwatch.ElapsedMilliseconds;




            // PV.PVLoc.Add(new List<PVLoc>());
            // PV.PVLoc.Add(new List<PVLoc>());
            // PV.PVLoc.Add(new List<PVLoc>());

            // PV[0] = new List<PVLoc>();


            // PV.Add(List<PVLoc>());

            /*
                    public enum epv { pv0, pv1, pv2 }
                List<PVInfo>[] PV { get; set; }
            */

            // locations.Add(new location(CA!.L0_02_Kerker, "Kerker", "(Beschreibung fehlt)", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0));

            InitStatus();

            timeFiStatus = stopwatch.ElapsedMilliseconds;

            if (LoadedInitData == null)
            {
            }
            InitScores();

            timeFiScores = stopwatch.ElapsedMilliseconds;

            SetScoreOutput();

            if (LoadedInitData == null)
            {
            }

            PropertyInfo myPropertyInfo1 = CA!.GetType()!.GetProperty( loca.Adv_InitializeGame_Person_I_4577)!;
            Item? Ix = (Item)myPropertyInfo1!.GetValue(CA)!;






            timeFiParserReset = stopwatch.ElapsedMilliseconds;
        }


        void InitStatus()
        {
            CA!.Status_Tuer_Bibliothek = Stats!.Add(new Status());
            CA!.Status_Tuer_Schlafkammer = Stats!.Add(new Status());
            CA!.Status_Tuer_Schlafkammer_angeschaut = Stats!.Add(new Status());
            CA!.Status_Tuer_Labor = Stats!.Add(new Status());
            CA!.Status_Kerzenhalter = Stats!.Add(new Status());

            CA!.Status_Eule_Klaue = Stats!.Add(new Status());
            CA!.Status_Ritterruestung_Klaue = Stats!.Add(new Status());
            CA!.Status_Schlange_Klaue = Stats!.Add(new Status());
            CA!.Status_Elster_Klaue = Stats!.Add(new Status());
            CA!.Status_Fisch_Klaue = Stats!.Add(new Status());
            CA!.Status_Papagei_Klaue = Stats!.Add(new Status());
            CA!.Status_Skelett_Klaue = Stats!.Add(new Status());

            CA!.Status_Antwort_Unterwaesche = Stats!.Add(new Status());
            CA!.Status_Antwort_Ruestung = Stats!.Add(new Status());
            CA!.Status_Antwort_Lieblingstier = Stats!.Add(new Status());
            CA!.Status_Coin_Taken = Stats!.Add(new Status());

            CA!.Status_Fish_Coin = Stats!.Add(new Status());
            CA!.Status_Coin_Entdeckt = Stats!.Add(new Status());

            CA!.Status_Schale_Befestigt = Stats!.Add(new Status());
            CA!.Status_Elster_Tauschintro = Stats!.Add(new Status());
            CA!.Status_Klaue_Nehmversuch = Stats!.Add(new Status());
            CA!.Status_Quiz_Start = Stats!.Add(new Status());
            CA!.Status_Rezept_Gelesen = Stats!.Add(new Status());
        }

        void InitScores()
        {
            CA!.Score_Beutelchen = Scores!.Add(new Score((int)scoreVal.easy, scoreChapter.chapter_one));
            CA!.Score_Kerzenhalter = Scores!.Add(new Score((int)scoreVal.easy, scoreChapter.chapter_one));
            CA!.Score_Transfer1 = Scores!.Add(new Score((int)scoreVal.mediocre, scoreChapter.chapter_one));
            CA!.Score_Zuckerzange = Scores!.Add(new Score((int)scoreVal.easy, scoreChapter.chapter_one));
            CA!.Score_Kaese = Scores!.Add(new Score((int)scoreVal.easy, scoreChapter.chapter_one));
            CA!.Score_Polierlappen = Scores!.Add(new Score((int)scoreVal.easy, scoreChapter.chapter_one));
            CA!.Score_Plastiktuete = Scores!.Add(new Score((int)scoreVal.easy, scoreChapter.chapter_one));
            CA!.Score_Schluessel = Scores!.Add(new Score((int)scoreVal.easy, scoreChapter.chapter_one));
            CA!.Score_Erste_Belebung = Scores!.Add(new Score((int)scoreVal.mediocre, scoreChapter.chapter_one));
            CA!.Score_Erstes_Gespraech = Scores!.Add(new Score((int)scoreVal.mediocre, scoreChapter.chapter_one));
            CA!.Score_Tuer_eintreten = Scores!.Add(new Score((int)scoreVal.simple, scoreChapter.chapter_one));
            CA!.Score_Tuer_aufschliessen = Scores!.Add(new Score((int)scoreVal.simple, scoreChapter.chapter_one));
            CA!.Score_Rollpflaster = Scores!.Add(new Score((int)scoreVal.easy, scoreChapter.chapter_one));
            CA!.Score_Klauenzange1 = Scores!.Add(new Score((int)scoreVal.simple, scoreChapter.chapter_one));
            CA!.Score_Klauenzange2 = Scores!.Add(new Score((int)scoreVal.advanced, scoreChapter.chapter_one));
            CA!.Score_Antwort_Unterwaesche = Scores!.Add(new Score((int)scoreVal.simple, scoreChapter.chapter_one));
            CA!.Score_Antwort_Ruestung = Scores!.Add(new Score((int)scoreVal.mediocre, scoreChapter.chapter_one));
            CA!.Score_Antwort_Tier= Scores!.Add(new Score((int)scoreVal.simple, scoreChapter.chapter_one));
            CA!.Score_Bibliothek_offen = Scores!.Add(new Score((int)scoreVal.advanced, scoreChapter.chapter_one));
            CA!.Score_Buch = Scores!.Add(new Score((int)scoreVal.easy, scoreChapter.chapter_one));
            CA!.Score_Deckel = Scores!.Add(new Score((int)scoreVal.simple, scoreChapter.chapter_one));
            CA!.Score_Muenze = Scores!.Add(new Score((int)scoreVal.advanced, scoreChapter.chapter_one));
            CA!.Score_Muenze_Gefunden = Scores!.Add(new Score((int)scoreVal.advanced, scoreChapter.chapter_one));
            CA!.Score_Polierter_Stein = Scores!.Add(new Score((int)scoreVal.mediocre, scoreChapter.chapter_one));
            CA!.Score_Lichtloser_Stein = Scores!.Add(new Score((int)scoreVal.mediocre, scoreChapter.chapter_one));
            CA!.Score_Mondstein = Scores!.Add(new Score((int)scoreVal.advanced, scoreChapter.chapter_one));
            CA!.Score_Schwamm = Scores!.Add(new Score((int)scoreVal.advanced, scoreChapter.chapter_one));
            CA!.Score_Schlacke = Scores!.Add(new Score((int)scoreVal.advanced, scoreChapter.chapter_one));
            CA!.Score_Meues_Pulver = Scores!.Add(new Score((int)scoreVal.complex, scoreChapter.chapter_one));
            CA!.Score_Transfer2= Scores!.Add(new Score((int)scoreVal.mindblowing, scoreChapter.chapter_one));
            CA!.Score_Schale_Befestigung = Scores!.Add(new Score((int)scoreVal.easy, scoreChapter.chapter_one));
        }

        public string? _currentEventName;
        public ObservableCollection<OrderTable>? _otlCurrent;
        public int _ixCurrent;
        public int _actLocEvent;
        public int _lastLocEvent;
        public int _actLocEventSeqStart;
        public int _actLocEventStartPoint;
        public int _lastLocEventStartPoint;
        public bool _actLocCollecting;
        public int _lastLoc;
        public int _actLoc;
        private int _lastLastLoc;

        public string? LatestEventName
        {
            get; set;
        }



        public bool DoRitterruestung(int locationID)
        {
            try
            {
                if (CA!.Status_Ritterruestung_Klaue!.Val > 0)
                {
                    CA!.Status_Ritterruestung_Klaue.Val--;
                    if (CA!.Status_Ritterruestung_Klaue.Val == 0)
                    {
                        StoryOutput(CA!.L06_Long_Floor, CA!.Person_I, loca.DoRR_Finish);
                    }
                }

                if (CA!.Person_I!.locationID == locationID)
                {
                    if (CA.Status_Ritterruestung_Klaue.Val <= 0 && (Items!.IsItemInv(CA.I00_Unstable_Pliers_With_Claw) || Items!.IsItemInv(CA.I00_Stable_Pliers_With_Claw)))
                    {
                       
                        int val = GD!.RandomNumber(0, 10);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.L06_Long_Floor, CA!.Person_I, loca.DoRR_Seufzen);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.L06_Long_Floor, CA!.Person_I, loca.DoRR_Wispern);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.L06_Long_Floor, CA!.Person_I, loca.DoRR_Bewegen);
                            }

                        }
                    }
                    else if (CA!.Status_Ritterruestung_Klaue.Val > 0)
                    {

                        int val = GD!.RandomNumber(0, 10);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.L06_Long_Floor, CA!.Person_I, loca.DoRR_Action1);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.L06_Long_Floor, CA!.Person_I, loca.DoRR_Action2);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.L06_Long_Floor, CA!.Person_I, loca.DoRR_Action3);
                            }
                            else if (val < 4)
                            {
                                StoryOutput(CA!.L06_Long_Floor, CA!.Person_I, loca.DoRR_Action4);
                            }
                            else if (val < 5)
                            {
                                StoryOutput(CA!.L06_Long_Floor, CA!.Person_I, loca.DoRR_Action5);
                            }

                        }
                    }
                }
            }
            catch // (Exception ex)
            {
            }
            return true;
        }
        public bool DoOwl(int locationID)
        {
            try
            {
                if (CA!.Status_Eule_Klaue!.Val > 0)
                {
                    CA!.Status_Eule_Klaue!.Val--;

                    if (CA!.Status_Eule_Klaue!.Val == 0)
                    {
                        StoryOutput(CA!.L05_Atrium, CA!.Person_I, loca.DoOwl_Finish);
                    }
                }
                if (CA!.Person_I!.locationID == locationID)
                {
                    if (CA.Status_Eule_Klaue!.Val <= 0 && (Items!.IsItemInv(CA.I00_Unstable_Pliers_With_Claw) || Items!.IsItemInv(CA.I00_Stable_Pliers_With_Claw)))
                    {
                        int val = GD!.RandomNumber(0, 10);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.L05_Atrium, CA!.Person_I, loca.DoOwl_Seufzen);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.L05_Atrium, CA!.Person_I, loca.DoOwl_Wispern);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.L05_Atrium, CA!.Person_I, loca.DoOwl_Bewegen);
                            }

                        }
                    }
                    else if (CA!.Status_Eule_Klaue.Val > 0)
                    {
                        int val = GD!.RandomNumber(0, 10);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.L05_Atrium, CA!.Person_I, loca.DoOwl_Action1);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.L05_Atrium, CA!.Person_I, loca.DoOwl_Action2);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.L05_Atrium, CA!.Person_I, loca.DoOwl_Action3);
                            }
                            else if (val < 4)
                            {
                                StoryOutput(CA!.L05_Atrium, CA!.Person_I, loca.DoOwl_Action4);
                            }
                            else if (val < 5)
                            {
                                StoryOutput(CA!.L05_Atrium, CA!.Person_I, loca.DoOwl_Action5);
                            }

                        }
                    }
                }
            }
            catch // (Exception ex)
            {
            }
            return true;
        }
        public bool DoSkeleton(int locationID)
        {
            try
            {
                if (CA!.Status_Skelett_Klaue!.Val > 0)
                {
                    CA!.Status_Skelett_Klaue.Val--;
                    if (CA!.Status_Skelett_Klaue.Val == 0)
                    {
                        StoryOutput(CA!.L09_Library, CA!.Person_I, loca.Do_Skeleton_Finish);
                    }
                }

                if (CA!.Person_I!.locationID == locationID)
                {
                    if (CA.Status_Skelett_Klaue.Val <= 0 && (Items!.IsItemInv(CA.I00_Unstable_Pliers_With_Claw) || Items.IsItemInv(CA.I00_Stable_Pliers_With_Claw)))
                    {
                        int val = GD!.RandomNumber(0, 10);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.L09_Library, CA!.Person_I, loca.DoSkelett_Reaktion1);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.L09_Library, CA!.Person_I, loca.DoSkelett_Reaktion2);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.L09_Library, CA!.Person_I, loca.DoSkelett_Reaktion3);
                            }

                        }
                    }
                    else if (CA!.Status_Skelett_Klaue.Val > 0)
                    {
                        int val = GD!.RandomNumber(0, 10);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.L09_Library, CA!.Person_I, loca.DoSkelett_Action1);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.L09_Library, CA!.Person_I, loca.DoSkelett_Action2);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.L09_Library, CA!.Person_I, loca.DoSkelett_Action3);
                            }
                            else if (val < 4)
                            {
                                StoryOutput(CA!.L09_Library, CA!.Person_I, loca.DoSkelett_Action4);
                            }
                            else if (val < 5)
                            {
                                StoryOutput(CA!.L09_Library, CA!.Person_I, loca.DoSkelett_Action5);
                            }

                        }
                    }
                }
            }
            catch // (Exception ex)
            {
            }

            return true;
        }
        public bool DoParrot(int locationID)
        {
            try
            {
                if (CA!.Status_Papagei_Klaue!.Val > 0)
                {
                    CA!.Status_Papagei_Klaue.Val--;
                    if (CA!.Status_Papagei_Klaue.Val == 0)
                    {
                        StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Parrot_Finish);
                    }
                }

                if (CA!.Person_I!.locationID == locationID)
                {
                    if (CA.Status_Papagei_Klaue.Val <= 0 && (Items!.IsItemInv(CA.I00_Unstable_Pliers_With_Claw) || Items.IsItemInv(CA.I00_Stable_Pliers_With_Claw)))
                    {
                        int val = GD!.RandomNumber(0, 30);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Parrot_Reaktion1);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Parrot_Reaktion2);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Parrot_Reaktion3);
                            }

                        }
                    }
                    else if (CA!.Status_Papagei_Klaue.Val > 0)
                    {
                        int val = GD!.RandomNumber(0, 30);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Parrot_Action1);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Parrot_Action2);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Parrot_Action3);
                            }
                            else if (val < 4)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Parrot_Action4);
                            }
                            else if (val < 5)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Parrot_Action5);
                            }

                        }
                    }
                }
            }
            catch // (Exception ex)
            {
            }

            return true;
        }
        public bool DoMagpie(int locationID)
        {
            try
            {
                if (CA!.Status_Elster_Klaue!.Val > 0)
                {
                    CA!.Status_Elster_Klaue.Val--;
                    if (CA!.Status_Elster_Klaue.Val == 0)
                    {
                        StoryOutput(CA!.Person_Magpie!.locationID, CA!.Person_I, loca.Do_Magpie_Finish);
                    }
                }

                if (CA!.Person_I!.locationID == locationID)
                {
                    if (CA.Status_Elster_Klaue.Val <= 0 && (Items!.IsItemInv(CA.I00_Unstable_Pliers_With_Claw) || Items!.IsItemInv(CA.I00_Stable_Pliers_With_Claw)))
                    {
                        int val = GD!.RandomNumber(0, 30);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Magpie_Reaktion1);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Magpie_Reaktion2);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Magpie_Reaktion3);
                            }

                        }
                    }
                    else if (CA!.Status_Elster_Klaue.Val > 0)
                    {
                        int val = GD!.RandomNumber(0, 30);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Magpie_Action1);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Magpie_Action2);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Magpie_Action3);
                            }
                            else if (val < 4)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Magpie_Action4);
                            }
                            else if (val < 5)
                            {
                                StoryOutput(CA!.Person_Parrot!.locationID, CA!.Person_I, loca.Do_Magpie_Action5);
                            }

                        }
                    }
                }
            }
            catch // (Exception ex)
            {
            }

            return true;
        }
        public bool DoFish(int locationID)
        {
            try
            {
                if (CA!.Status_Fisch_Klaue!.Val > 0)
                {
                    CA!.Status_Fisch_Klaue.Val--;
                    if (CA!.Status_Fisch_Klaue.Val == 0)
                    {
                        StoryOutput(CA!.Person_Fish!.locationID, CA!.Person_I, loca.Do_Fish_Finish);
                    }
                }

                if (CA!.Person_I!.locationID == locationID)
                {
                    if (CA.Status_Fisch_Klaue.Val <= 0 && (Items!.IsItemInv(CA.I00_Unstable_Pliers_With_Claw) || Items!.IsItemInv(CA.I00_Stable_Pliers_With_Claw)))
                    {
                        int val = GD!.RandomNumber(0, 30);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.Person_Fish!.locationID, CA!.Person_I, loca.Do_Fish_Reaktion1);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.Person_Fish!.locationID, CA!.Person_I, loca.Do_Fish_Reaktion2);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.Person_Fish!.locationID, CA!.Person_I, loca.Do_Fish_Reaktion3);
                            }

                        }
                    }
                    else if (CA!.Status_Fisch_Klaue.Val > 0)
                    {
                        int val = GD!.RandomNumber(0, 30);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.Person_Fish!.locationID, CA!.Person_I, loca.Do_Fish_Action1);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.Person_Fish!.locationID, CA!.Person_I, loca.Do_Fish_Action2);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.Person_Fish!.locationID, CA!.Person_I, loca.Do_Fish_Action3);
                            }
                            else if (val < 4)
                            {
                                StoryOutput(CA!.Person_Fish!.locationID, CA!.Person_I, loca.Do_Fish_Action4);
                            }
                            else if (val < 5)
                            {
                                StoryOutput(CA!.Person_Fish!.locationID, CA!.Person_I, loca.Do_Fish_Action5);
                            }

                        }
                    }
                }
            }
            catch //  (Exception ex)
            {
            }

            return true;
        }
        public bool DoSnake(int locationID)
        {
            try
            {
                if (CA!.Status_Schlange_Klaue!.Val > 0)
                {
                    CA!.Status_Schlange_Klaue.Val--;
                    if (CA!.Status_Schlange_Klaue.Val == 0)
                    {
                        StoryOutput(CA!.Person_Snake!.locationID, CA!.Person_I, loca.Do_Snake_Finish);
                    }
                }

                if (CA!.Person_I!.locationID == locationID)
                {
                    if (CA.Status_Schlange_Klaue.Val <= 0 && (Items!.IsItemInv(CA.I00_Unstable_Pliers_With_Claw) || Items!.IsItemInv(CA.I00_Stable_Pliers_With_Claw)))
                    {
                        int val = GD!.RandomNumber(0, 30);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.Person_Snake!.locationID, CA!.Person_I, loca.Do_Snake_Reaktion1);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.Person_Snake!.locationID, CA!.Person_I, loca.Do_Snake_Reaktion2);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.Person_Snake!.locationID, CA!.Person_I, loca.Do_Snake_Reaktion3);
                            }

                        }
                    }
                    else if (CA!.Status_Schlange_Klaue.Val > 0)
                    {
                        int val = GD!.RandomNumber(0, 30);
                        {
                            if (val < 1)
                            {
                                StoryOutput(CA!.Person_Snake!.locationID, CA!.Person_I, loca.Do_Snake_Action1);
                            }
                            else if (val < 2)
                            {
                                StoryOutput(CA!.Person_Snake!.locationID, CA!.Person_I, loca.Do_Snake_Action2);
                            }
                            else if (val < 3)
                            {
                                StoryOutput(CA!.Person_Snake!.locationID, CA!.Person_I, loca.Do_Snake_Action3);
                            }
                            else if (val < 4)
                            {
                                StoryOutput(CA!.Person_Snake!.locationID, CA!.Person_I, loca.Do_Snake_Action4);
                            }
                            else if (val < 5)
                            {
                                StoryOutput(CA!.Person_Snake!.locationID, CA!.Person_I, loca.Do_Snake_Action5);
                            }

                        }
                    }
                }
            }
            catch // (Exception ex)
            {
            }

            return true;
        }

        public string? PathSegment( string s, int segmentNo )
        {
            if (s != null)
            {
                string[] s1 = s.Split('/');
                if (segmentNo < s1.Length )
                    return s1[segmentNo];
                else
                    return null;
            }
            else
                return null;
        }
        public string PathInsertSegment( string s, int segmentNo, string insertString )
        {
            string[] s1 = s.Split('/');

            if( segmentNo < s1.Length)
            {
                s1[segmentNo] = insertString;

                s = s1[0];

                for( int ix = 1; ix < s1.Length; ix++)
                {
                    s += "/" + s1[ix];
                }
            }
            else if ( segmentNo == s1.Length)
            {
                s += "/" + insertString;
            }
            return s;
        }
        public string? CurrentEventName 
        {
            get => _currentEventName;
            set
            {
                if( _currentEventName != value )
                {
                    if (_otlCurrent != null)
                    {
                        string path2 = String.Format(loca.ScoreEvent_Von_Bis, _currentEventName, loca.ScoreEvent_Finish);
                        int ix = _ixCurrent - 1;
                        if( ix >= 1380)
                        {
                        }
                        while (     ix >=0 
                                &&  (       PathSegment(_otlCurrent[ix]!.OrderPath!, 1) == path2 
                                        || _otlCurrent[ix].OrderActive == false )
                                    ) 
                            ix--;

                        ix++;

                        string path3 = String.Format(loca.ScoreEvent_Von_Bis, _currentEventName, value);

                        int ixStart = ix;

                        for (; ix <= _ixCurrent; ix++)
                        {
                            string fullPath = "";

                            if (_otlCurrent[ix].OrderPath != null)
                                fullPath = PathInsertSegment(_otlCurrent[ix].OrderPath!, 1, path3);
                            else if ( ix >= ixStart )
                            {
                                fullPath = _otlCurrent[ix-1]!.OrderPath!;

                            }
                            else if ( ix < _ixCurrent )
                            {
                                fullPath = _otlCurrent[ix + 1]!.OrderPath!;

                            }
                            
                            _otlCurrent[ix].OrderPath = fullPath;
                        }
                    }
                    LatestEventName = _currentEventName;
                    _currentEventName = value;
                }
            }
        }

        private int _ixLatest = -1;

        public void SecureOrderPath(ObservableCollection<OrderTable> otlX, int ix)
        {
            if (otlX[ix].OrderPath == null)
            {
                int ix2 = ix;
                while ( ix2 >= 0 && otlX[ix2].OrderPath == null)
                {

                    ix2--;
                }
                if( ix2 >= 0)
                {
                    otlX[ix].OrderPath = otlX[ix2].OrderPath;
                }
            }

        }


        public void InitOrderPath()
        {
            _actLocEvent = -1;
            _currentEventName = "";
            _actLocCollecting = false;
            _lastLoc = -1;
            _lastLastLoc = -1;
            _actLoc = -1;
            _actLocEventStartPoint = -1;
            _lastLocEventStartPoint = -1;
        }

        public void CreateOrderPath(ObservableCollection<OrderTable> otl, int ix)
        {
            try
            {
                // Wenn für diesen Index schon ein Pfad angelegt wurde, dann raus hier
                if (ix == _ixLatest)
                {
                    return;
                }
                _ixLatest = ix;

                if (ix == 2)
                {

                }

                // Wenn CA == null, dann fehlt die Initialisierung -> Abbruch 
                if (CA == null)
                    return;

                string fullPath;
                string path1 = loca.Path_Chapter_01;
                string path2_1 = CurrentEventName!;
                string path2_2 = loca.ScoreEvent_Finish;
                string? path2 = null;
                string? path3 = null;
                // string? path4 = null;

                // während des Pfadaufbaus reicht Abschnitt path2 immer vom CurrentEventName bis "Current"
                path2 = String.Format(loca.ScoreEvent_Von_Bis, CurrentEventName, loca.ScoreEvent_Finish);

                _otlCurrent = otl;
                _ixCurrent = ix;

                _actLoc = CA!.Person_I!.locationID;

                // Aktuell werden Aktionen gesammelt
                if (_actLocCollecting == false)
                {
                    // _actLoc hat sich geändert? Dann ab hier Locations zählen
                    // if (_lastLoc != _actLoc && _lastLoc != -1)
                    if (_lastLastLoc != _lastLoc && _lastLastLoc != -1)
                    {
                        _actLocCollecting = true;

                        _actLocEventSeqStart = ix - 1;
                        _actLocEventStartPoint = _lastLastLoc;

                        // Hier wird schon mal die Location x zwischengespeichert fürs später "Gehe von 'x' nach 'y'"
                        // _lastLocEventStartPoint = _actLocEventStartPoint;
                        // _actLocEventStartPoint = _actLocEvent;

                    }
                    else
                    {

                    }
                }
                // Aktuell werden Gehe-Aktionen gesammelt, aber die letzte Aktion ist keine Gehe-Aktion mehr
                // wir müssen also die letzten gesammelten Gehe-Aktionen nachbearbeiten
                else if (_actLocCollecting == true && _lastLoc == _lastLastLoc)
                {
                    if (ix - _actLocEventSeqStart > 2 && _actLocEventSeqStart >= 2)
                    {
                        string pathx = String.Format(loca.ScoreEvent_Gehen_Von_Bis, locations!.Find(_actLocEventStartPoint)!.LocName, locations!.Find(_lastLoc)!.LocName);

                        // for (int ix2 = _actLocEventSeqStart - 1; ix2 < (ix - 2); ix2++)
                        for (int ix2 = _actLocEventSeqStart; ix2 < (ix - 1); ix2++)
                        {
                            SecureOrderPath(_otlCurrent, ix2);

                            _otlCurrent[ix2].OrderPath = PathInsertSegment(_otlCurrent[ix2].OrderPath!, 2, pathx);

                        }

                    }
                    else
                    {
                        /*
                        if (AdvGame!.DialogOngoing && Orders.persistentMCMenu != null)
                        {
                            string speaker = loca.ScoreEvent_Talk_Self;

                            if (Orders.persistentMCMenu?.MCSpeakerText.Count > 1)
                                if (Orders.persistentMCMenu.MCSpeakerText[1].SpeakerID != Orders.persistentMCMenu.MCSpeakerText[0].SpeakerID)
                                    speaker = String.Format(loca.ScoreEvent_Talk_With, Persons.Find(Orders.persistentMCMenu.MCSpeakerText[1].SpeakerID).FullName(Co.CASE_DAT));

                            path3 = speaker;
                        }
                        */
                    }

                    _actLocCollecting = false;
                }

                if( AdvGame!.Orders != Orders )
                {

                }

                if (AdvGame!.DialogOngoing && AdvGame!.Orders!.persistentMCMenu != null)
                {
                    string speaker = loca.ScoreEvent_Talk_Self;

                    if (AdvGame!.Orders.persistentMCMenu?.MCSpeakerText.Count > 1)
                        if (AdvGame!.Orders.persistentMCMenu.MCSpeakerText[1].SpeakerID != AdvGame!.Orders.persistentMCMenu.MCSpeakerText[0].SpeakerID)
                            speaker = String.Format(loca.ScoreEvent_Talk_With, AdvGame!.Persons!.Find(AdvGame!.Orders.persistentMCMenu.MCSpeakerText[1].SpeakerID)!.FullName(Co.CASE_DAT, CurrentNouns! ));

                    path3 = speaker;
                }

                _lastLocEvent = _actLocEvent;
                _actLocEvent = _actLoc;


                fullPath = path1;
                if (path2 != null)
                    fullPath += "/" + path2;
                if (path3 != null)
                    fullPath += "/" + path3;
                /*
                if (path4 != null)
                    fullPath += "/" + path4;
                */
                otl![ix].OrderPath = fullPath;

                _lastLastLoc = _lastLoc;
                _lastLoc = _actLoc;
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("CreateOrderPath: " + ex.Message, IGlobalData.protMode.crisp);
            }

        }

        public void CreateOrderPathOld( ObservableCollection<OrderTable> otl, int ix)
        {
            // Wenn für diesen Index schon ein Pfad angelegt wurde, dann raus hier
            if( ix == _ixLatest )
            {
                return; // OTL![ix].OrderPath;
            }
            _ixLatest = ix;

            if( ix == 17 )
            {

            }

            // Wenn CA == null, dann fehlt die Initialisierung -> Abbruch 
            if (CA == null)
                return;

            string fullPath;
            string path1 = loca.Path_Chapter_01;
            string path2_1 = CurrentEventName!;
            string path2_2 = loca.ScoreEvent_Finish;
            string? path2 = null;
            string? path3 = null;
            string? path4 = null;

 
            // während des Pfadaufbaus reicht Abschnitt path2 immer vom CurrentEventName bis "Current"
            path2 = String.Format(loca.ScoreEvent_Von_Bis, CurrentEventName, loca.ScoreEvent_Finish );

            _otlCurrent = otl;
            _ixCurrent = ix;

            _actLoc = CA!.Person_I!.locationID;

            // Aktuell werden Aktionen gesammelt
            if ( _actLocCollecting == false )
            {
                // _actLoc hat sich geändert? Dann ab hier Locations zählen
                if( _actLocEvent != _actLoc && _actLocEvent != -1 )
                {
                    _actLocCollecting = true;

                    _actLocEventSeqStart = ix -1;
                    // Dieser Spezialfall dürfte eigentlich niemals auftreten
                    if (ix == 0) 
                        _actLocEventSeqStart = 0;

                    // Hier wird schon mal die Location x zwischengespeichert fürs später "Gehe von 'x' nach 'y'"
                    _lastLocEventStartPoint = _actLocEventStartPoint;
                    _actLocEventStartPoint = _actLocEvent;

                    // ToDo: Ist es wirklich sinnvoll, dass hier schon path3 generiert wird, auch wenn sich womöglich nachher rausstellt, dass wir doch eine Aktionssequenz draus machen?
                    path3 = String.Format(loca.ScoreEvent_Gehen_Von_Bis, locations!.Find(_actLocEventStartPoint)!.LocName, loca.ScoreEvent_Finish);

                    // Hier wird der Beginn der Gehe-Sequenz schon mal in den OrderPath des Anfangspunktes geschrieben.
                    if(otl![_actLocEventSeqStart+1].OrderPath != null )
                        otl![_actLocEventSeqStart+1].OrderPath = PathInsertSegment(otl![_actLocEventSeqStart+1].OrderPath!, 2, path3);


                }
            }
            // Aktuell werden Gehe-Aktionen gesammelt, aber die letzte Aktion ist keine Gehe-Aktion mehr
            // wir müssen also die letzten gesammelten Gehe-Aktionen nachbearbeiten
            else if(_actLocCollecting == true && _actLocEvent == _actLoc)
            {


                path3 = String.Format(loca.ScoreEvent_Gehen_Von_Bis, locations!.Find(_actLocEventStartPoint)!.LocName, loca.ScoreEvent_Finish);
                int ctEntrys = 0;

                ctEntrys = ix - _actLocEventSeqStart - 1;

                // Nur ein einziger Location-Wechsel? Das wird dann als Aktion gewertet und an die letzte Aktionssequenz angehängt
                if (ctEntrys == 1)
                {
                    /*
                    if (_lastLocEventStartPoint != -1)
                        path3 = String.Format(loca.ScoreEvent_Aktionen, locations!.Find(_lastLocEventStartPoint)!.LocName);
                    else
                    */
                        path3 = String.Format(loca.ScoreEvent_Aktionen, locations!.Find(_actLocEventStartPoint)!.LocName);
                   otl![_actLocEventSeqStart+1].OrderPath = PathInsertSegment(otl![_actLocEventSeqStart + 1].OrderPath!, 2, path3);
                }
                // Mehr als ein Location-Wechsel? Dann wird die Sequenz entsprechend als Gehe-Sequenz aktualisiert
                else if (ctEntrys > 1)
                {
                    path3 = String.Format(loca.ScoreEvent_Gehen_Von_Bis, locations!.Find(_actLocEventStartPoint)!.LocName, locations!.Find(_lastLoc)!.LocName);

                    for (int ix3 = _actLocEventSeqStart+1; ix3 < ix; ix3++)
                    {
                        SecureOrderPath(_otlCurrent, ix3);

                        _otlCurrent[ix3].OrderPath = PathInsertSegment(_otlCurrent[ix3].OrderPath!, 2, path3);

                    }
                }

                /*
                // ix2: Letzter Eintrag VOR dem als sicherer Gehe-Aktion geltenden ix - 1
                int ix2 = ix - 2;

                if ( ix2 > 0 )
                {
                    while (ix2 > 0 && PathSegment(otl![ix2].OrderPath!, 2) == path3)
                    {
                        ix2--;
                        ctEntrys++;
                    }

                    // Nur ein einziger Location-Wechsel? Das wird dann als Aktion gewertet und an die letzte Aktionssequenz angehängt
                    if( ctEntrys == 1)
                    {
                        int loc = _lastLastLoc;
                        if ( loc == -1 )
                        {
                            loc = _lastLoc;
                        }
                        if (loc == -1)
                        {
                            loc = _actLoc;
                        }
                        path3 = String.Format(loca.ScoreEvent_Aktionen, locations!.Find(loc)!.LocName);
                        otl![ix2+1].OrderPath = PathInsertSegment(otl![ix - 1].OrderPath!, 2, path3);
                    }
                    else if ( ctEntrys > 1 )
                    {
                        path4 = String.Format(loca.ScoreEvent_Gehen_Von_Bis, locations!.Find(_actLocEventStartPoint)!.LocName, locations!.Find(_lastLoc)!.LocName);

                        for ( int ix3 = ix2 +1; ix3 < ix; ix3++)
                        {
                            SecureOrderPath(_otlCurrent, ix3);

                            _otlCurrent[ix3].OrderPath = PathInsertSegment(_otlCurrent[ix3].OrderPath!, 2, path4);

                        }
                    }
                }

                // Jetzt wird die aktuelle Aktion geschrieben
                path3 = String.Format(loca.ScoreEvent_Aktionen, locations!.Find(_actLoc)!.LocName);
                // Hier wurde ein Fall abgefangen, der eigentlich gar nicht auftreten dürfte
                if (ix > 0)
                {
                    if (otl![ix - 1].OrderPath != null)
                        otl![ix - 1].OrderPath = PathInsertSegment(otl![ix - 1].OrderPath!, 2, path3);
                }
                 */
                _actLocCollecting = false;

            }
            _actLocEvent = _actLoc;

            if( _actLocCollecting == true )
            {
                path3 = String.Format(loca.ScoreEvent_Gehen_Von_Bis, locations!.Find(_actLocEventStartPoint)!.LocName, loca.ScoreEvent_Finish);

            }
            else
            {
                path3 = String.Format(loca.ScoreEvent_Aktionen, locations!.Find(_actLoc)!.LocName);
            }
            if( AdvGame!.DialogOngoing && AdvGame!.Orders!.persistentMCMenu != null )
            {
                string speaker = loca.ScoreEvent_Talk_Self; 

                if (AdvGame!.Orders.persistentMCMenu?.MCSpeakerText.Count > 1)
                    if (AdvGame!.Orders.persistentMCMenu.MCSpeakerText[1].SpeakerID != AdvGame!.Orders.persistentMCMenu.MCSpeakerText[0].SpeakerID)
                        speaker = String.Format( loca.ScoreEvent_Talk_With, AdvGame!.Persons!.Find(AdvGame!.Orders.persistentMCMenu.MCSpeakerText[1].SpeakerID )!.FullName(Co.CASE_DAT, CurrentNouns! ) );

                path4 = speaker;
            }

            fullPath = path1;
            if (path2 != null)
                fullPath += "/" + path2;
            /*
            if (path3 != null)
                fullPath += "/" + path3;
            if (path4 != null)
                fullPath += "/" + path4;
            */
            otl![ix].OrderPath = fullPath;

            if (_actLoc != _lastLoc)
            {
                // _lastLastLoc = _lastLoc;
                _lastLoc = _actLoc;
            }
        }

        public void Replacelocation(locationList ll, ItemList il, PersonList pl, int sourcelocation, int destlocation, bool exchangeItems = true)
        {
            locations!.Replacelocation(ll, il, pl, sourcelocation, destlocation, exchangeItems);
            PV.Find(sourcelocation)!.replacement = true;
        }

        public bool ResetParser()
        {
            Parser = new Parse(this, PLL, Verbs, Preps, Pronouns, Nouns, Adjs, Fills, Items, Persons, Topics, ItemQueue);
            return true;
        }

 

        public bool DoMCRestart(List<MCMenuEntry> MCMEntry)
        {
            AdvGame!.UIS!.ExecuteRestart( true);
            return (true);
        }
        public bool DoMCRestartDeutsch(List<MCMenuEntry> MCMEntry)
        {
            loca.GD!.Language = IGlobalData.language.german;
            AdvGame!.UIS!.ExecuteRestart(true);
            return (true);
        }
        public bool DoMCRestartEnglisch(List<MCMenuEntry> MCMEntry)
        {
            loca.GD!.Language = IGlobalData.language.english;
            AdvGame!.UIS!.ExecuteRestart(true);
            return (true);
        }

        public bool DoMCRestartSlot(List<MCMenuEntry> MCMEntry, int Slot)
        {
            UIS!.RestartSlot = Slot;
            AdvGame!.UIS!.ExecuteRestart();
            UIS!.RestartSlot = -1;
            return (true);
        }

        public bool CheckDoAutosave()
        {
            if( GD!.Adventure != null )
            {
                Autosave( true );
            }
            return true;
        }
        public bool Autosave( bool forceSave = false)
        {
            Orders!.CoreSave( loca.Adv_Autosave_4578, forceSave);
            UIS!.SaveUIConfig();
            return (true);
        }

        string? DoStringMagic(string? s, AbstractAdvObject? AO1, AbstractAdvObject? AO2)
        {
            if (s == null) return (null);
            int i = 0;
            int Rest = s.Length;

            string s2 = "";

            string FindAkk1 = loca.Adv_Autosave_4579;
            string FindNom1 = loca.Adv_Autosave_4580;
            string FindDat1 = loca.Adv_Autosave_4581;
            string FindAkk2 = loca.Adv_Autosave_4582;
            string FindNom2 = loca.Adv_Autosave_4583;
            string FindDat2 = loca.Adv_Autosave_4584;
            for (i = 0; i < s.Length; i++)
            {
                bool processed = false;

                if (FindAkk1.Length <= Rest)
                {
                    if (s.Substring(i, FindAkk1.Length) == FindAkk1)
                    {
                        if (AO1 != null)
                            s2 += AO1.FullName(AO1, Co.CASE_AKK, CurrentNouns! );
                        else
                            s2 += loca.Adv_Autosave_4585;

                        processed = true;
                        i += FindAkk1.Length - 1;
                        Rest -= FindAkk1.Length - 1;
                    }
                }
                if (FindNom1.Length <= Rest)
                {
                    if (s.Substring(i, FindNom1.Length) == FindNom1)
                    {
                        if (AO1 != null)
                            s2 += AO1.FullName(AO1, Co.CASE_NOM, CurrentNouns! );
                        else
                            s2 += loca.Adv_Autosave_4586;

                        processed = true;
                        i += FindNom1.Length - 1;
                        Rest -= FindNom1.Length - 1;
                    }
                }
                if (FindDat1.Length <= Rest)
                {
                    if (s.Substring(i, FindDat1.Length) == FindDat1)
                    {
  
                        if (AO1 != null)
                            s2 += AO1.FullName(AO1, Co.CASE_DAT, CurrentNouns!);
                        else
                            s2 += loca.Adv_Autosave_4587;

                        processed = true;
                        i += FindDat1.Length - 1;
                        Rest -= FindDat1.Length - 1;
                    }
                }
                if (FindAkk2.Length <= Rest)
                {
                    if (s.Substring(i, FindAkk2.Length) == FindAkk2)
                    {
                        if (AO2 != null)
                        {
                            s2 += AO2.FullName(AO2, Co.CASE_AKK, CurrentNouns!);
                        }
                        else
                            s2 += loca.Adv_Autosave_4588;
                        processed = true;
                        i += FindAkk2.Length - 1;
                        Rest -= FindAkk2.Length - 1;
                    }
                }
                if (FindNom2.Length <= Rest)
                {
                    if (s.Substring(i, FindNom2.Length) == FindNom2)
                    {
                        if (AO2 != null)
                        {
                            s2 += AO2.FullName(AO2, Co.CASE_NOM, CurrentNouns!);
                        }
                        else
                            s2 += loca.Adv_Autosave_4589;
                        processed = true;
                        i += FindNom2.Length - 1;
                        Rest -= FindNom2.Length - 1;
                    }
                }
                if (FindDat2.Length <= Rest)
                {
                    if (s.Substring(i, FindDat2.Length) == FindDat2)
                    {
   
                        if (AO2 != null)
                        {
                            s2 += AO2.FullName(AO2, Co.CASE_DAT, CurrentNouns!);
                        }
                        else
                            s2 += loca.Adv_Autosave_4590;
                        processed = true;
                        i += FindDat2.Length - 1;
                        Rest -= FindDat2.Length - 1;
                    }
                }


                if (!processed)
                {
                    s2 += s[i];
                }
                Rest--;
            }
 
            return (s2);
        }


        public int FindContainers(int Loc, int Where, List<PI> il, int ExcludeLoc)
        {
            int Ct = 0;

            foreach( Item? item in Items!.List!.Values ) // for (int i = 0; i < Items!.List.Count; i++)
            {
                // Item? Item = Items!.List[i];

                if ((Co.GenerateLoc(item) == Loc) && (item.IsHidden == false) && (item.IsMentionable == true))
                {
                    if ((item.CanPutIn) && (item.InvisibleIn == false) && ((item.CanBeClosed == false) || (item.IsClosed == false)))
                    {
                        if ((Where == CB!.LocType_In_Item) && (Co.GenerateLoc(CB!.LocType_In_Item, item.ID) != ExcludeLoc))
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Item, item.ID));
                        }
                        Ct += FindContainers(Co.GenerateLoc(CB!.LocType_In_Item, item.ID), Where, il, ExcludeLoc);
                    }
                    else if ((item.CanPutBehind) && (item.InvisibleBehind == false))
                    {
                        if ((Where == CB!.LocType_Behind_Item) && (Co.GenerateLoc(CB!.LocType_Behind_Item, item.ID) != ExcludeLoc))
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Item, item.ID));
                        }
                        Ct += FindContainers(Co.GenerateLoc(CB!.LocType_Behind_Item, item.ID), Where, il, ExcludeLoc);
                    }
                    else if ((item.CanPutOn) && (item.InvisibleOn == false))
                    {
                        if ((Where == CB!.LocType_On_Item) && (Co.GenerateLoc(CB!.LocType_On_Item, item.ID) != ExcludeLoc))
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Item, item.ID));
                        }
                        Ct += FindContainers(Co.GenerateLoc(CB!.LocType_On_Item, item.ID), Where, il, ExcludeLoc);
                    }
                    else if ((item.CanPutBeside) && (item.InvisibleBeside == false))
                    {
                        if ((Where == CB!.LocType_Beside_Item) && (Co.GenerateLoc(CB!.LocType_Beside_Item, item.ID) != ExcludeLoc))
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Item, item.ID));
                        }
                        Ct += FindContainers(Co.GenerateLoc(CB!.LocType_Beside_Item, item.ID), Where, il, ExcludeLoc);
                    }
                    else if ((item.CanPutBelow) && (item.InvisibleBelow == false))
                    {
                        if ((Where == CB!.LocType_Below_Item) && (Co.GenerateLoc(CB!.LocType_Below_Item, item.ID) != ExcludeLoc))
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Item, item.ID));
                        }
                        Ct += FindContainers(Co.GenerateLoc(CB!.LocType_Below_Item, item.ID), Where, il, ExcludeLoc);
                    }
                }
            }
            foreach (Person? person in Persons!.List!.Values) // for (int i = 0; i < Persons!.List.Count; i++)
            {
                // Person? Person = Persons!.Find(Persons!.List[i].ID);
                if (Co.GenerateLoc(person) == Loc)
                {
                    if ((person.CanPutIn) && ((person.CanBeClosed == false) || (person.IsClosed == false)))
                    {
                        if (Where == CB!.LocType_In_Person)
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Person, person.ID));
                        }
                        Ct += FindContainers(Co.GenerateLoc(CB!.LocType_In_Person, person.ID), Where, il, ExcludeLoc);
                    }
                    else
                    {
                        Ct += FindContainers(Co.GenerateLoc(CB!.LocType_Person, person.ID), Where, il, ExcludeLoc);
                    }
                }
            }
            return Ct;
        }


        bool HasItemCategory(Item? item, int Category)
        {
            bool found = false;

            if ((Category == A.Cat_Takeable) && (Co.GenerateLoc(item) != Co.GenerateLoc(CB!.LocType_Person, A!.ActPerson))) return (item!.CanBeTaken);
            if (Category == A.Cat_Examinable) return (true);

            /*
            if ((Category == A.Cat_ExamineInable) && (item.CanPutIn) && ((item.CanBeClosed == false) || (item.IsClosed == false))) return (item.CanPutIn);
            if ((Category == A.Cat_ExamineOnable) && (item.CanPutOn)) return (item.CanPutOn);
            if ((Category == A.Cat_ExamineBelowable) && (item.CanPutBelow)) return (item.CanPutBelow);
            if ((Category == A.Cat_ExamineBehindable) && (item.CanPutBehind)) return (item.CanPutBehind);
            if ((Category == A.Cat_ExamineBesideable) && (item.CanPutBeside)) return (item.CanPutBeside);
            if ((Category == A.Cat_Dropable) && (Co.GenerateLoc(item) == Co.GenerateLoc(CB!.LocType_Person, A!.ActPerson))) return (item.CanBeTaken);
            if ((Category == A.Cat_Openable) && (item.CanBeClosed) && (item.IsClosed)) return (item.CanBeClosed);
            if ((Category == A.Cat_Closeable) && (item.CanBeClosed) && (!item.IsClosed)) return (item.CanBeClosed);
            if ((Category == A.Cat_Closeable) && (item.CanBeClosed) && (!item.IsClosed)) return (item.CanBeClosed);
            if ((Category == A.Cat_TakeOutable) && (item.locationType == CB!.LocType_In_Item)) return (true);
            if ((Category == A.Cat_TakeFromable) && (item.locationType == CB!.LocType_On_Item)) return (true);
            if ((Category == A.Cat_TakeFromBelowable) && (item.locationType == CB!.LocType_Below_Item)) return (true);
            if ((Category == A.Cat_TakeFromBehindable) && (item.locationType == CB!.LocType_Behind_Item)) return (true);
            if ((Category == A.Cat_TakeFromBesideable) && (item.locationType == CB!.LocType_Beside_Item)) return (true);
            if ((Category == A.Cat_PutInable) && (item.CanBeTaken)) return (true);
            if ((Category == A.Cat_PutOnable) && (item.CanBeTaken)) return (true);
            if ((Category == A.Cat_PutBelowable) && (item.CanBeTaken)) return (true);
            if ((Category == A.Cat_PutBehindable) && (item.CanBeTaken)) return (true);
            if ((Category == A.Cat_PutBesideable) && (item.CanBeTaken)) return (true);
            if ((Category == A.CounterCat_TakeOutable) && (item.CanPutIn) && ((item.CanBeClosed == false) || (item.IsClosed == false))) return (true);
            if ((Category == A.CounterCat_TakeFromable) && (item.CanPutOn)) return (true);
            if ((Category == A.CounterCat_TakeFromBelowable) && (item.CanPutBelow)) return (true);
            if ((Category == A.CounterCat_TakeFromBehindable) && (item.CanPutBehind)) return (true);
            if ((Category == A.CounterCat_TakeFromBesideable) && (item.CanPutBeside)) return (true);
            */

            if (item!.Categories!.List!.ContainsKey(Category))
            {
                CategoryRel c = Categories!.List![Category];
                if ((!AdvGame!.GD!.LayoutDescription.SimpleMC || c.Relevance == relTypes.r_essential))
                    found = true;
            }
            /*
            foreach (CategoryRel c in item!.Categories!.List!)
            {
                if (c.Category!.CategoryID == Category && ( !AdvGame!.GD!.SimpleMC || c.Relevance == relTypes.r_essential ) )
                    found = true;
            }
            */
            return (found);
        }
        bool HasPersonCategory(Person? person, int Category)
        {
            bool found = false;

            if (Category == A.Cat_Takeable) return (person!.CanBeTaken);
            if (Category == A.Cat_Examinable) return (true);
            if ((Category == A.Cat_ExamineInable) && (person!.CanPutIn) && ((person!.CanBeClosed == false) || (person!.IsClosed == false))) return (person!.CanPutIn);
            if ((Category == A.Cat_ExamineOnable)) return (false);
            if ((Category == A.Cat_ExamineBelowable)) return (false);
            if ((Category == A.Cat_ExamineBehindable)) return (false);
            if ((Category == A.Cat_ExamineBesideable)) return (false);
            if ((Category == A.Cat_Dropable) && (Co.GenerateLoc(person) == Co.GenerateLoc(CB!.LocType_Person, A!.ActPerson))) return (person!.CanBeTaken);
            if ((Category == A.Cat_Openable) && (person!.CanBeClosed) && (person.IsClosed)) return (person!.CanBeClosed);
            if ((Category == A.Cat_Closeable) && (person!.CanBeClosed) && (!person.IsClosed)) return (person!.CanBeClosed);
            if ((Category == A.Cat_TakeFromable) && (person!.locationType == CB!.LocType_On_Item)) return (true);
            if ((Category == A.Cat_TakeFromBelowable) && (person!.locationType == CB!.LocType_Below_Item)) return (true);
            if ((Category == A.Cat_TakeFromBehindable) && (person!.locationType == CB!.LocType_Behind_Item)) return (true);
            if ((Category == A.Cat_TakeFromBesideable) && (person!.locationType == CB!.LocType_Beside_Item)) return (true);
            if ((Category == A.CounterCat_TakeOutable) && (person!.CanPutIn) && ((person.CanBeClosed == false) || (person!.IsClosed == false))) return (true);

            foreach (CategoryRel c in person!.Categories!.List!.Values)
            {
                if (c.Category!.CategoryID == Category)
                    found = true;
            }
            return (found);
        }


        public bool ItemExcluded(Item? item, List<PI> ilExclude)
        {
            bool excluded = false;

            if (ilExclude != null)
            {
                for (int i = 0; i < ilExclude.Count; i++)
                {
                    if ((item!.ID == ilExclude[i].ID) && (ilExclude[i].Type == PI.TypeVal.Item))
                        excluded = true;
                }
            }

            return excluded;
        }

        public bool PersonExcluded(Person? person, List<PI> ilExclude)
        {
            bool excluded = false;

            if (ilExclude != null)
            {
                for (int i = 0; i < ilExclude.Count; i++)
                {
                    if ((person!.ID == ilExclude[i].ID) && (ilExclude[i].Type == PI.TypeVal.Person))
                        excluded = true;
                }
            }

            return excluded;
        }

        public int FindCategoryItemsPersons(int Loc, int Category, List<PI> il, List<PI>? ilExclude = null)
        {
            int Ct = 0;

            // for (int i = 0; i < Items!.List.Count; i++)
            foreach (Item? item in Items!.List!.Values)
            {
                // Item? Item = Items!.List[i];

                if (Co.GenerateLoc(item) == Loc)
                {
                    if ((item.CanPutIn) && ((item.CanBeClosed == false) || (item.IsClosed == false)))
                    {
                        if ((HasItemCategory(item, Category)) && (!ItemExcluded(item, ilExclude!)))
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Item, item.ID));
                        }
                        Ct += FindCategoryItemsPersons(Co.GenerateLoc(CB!.LocType_In_Item, item.ID), Category, il);
                    }
                    else if (item.CanPutBehind)
                    {
                        if ((HasItemCategory(item, Category)) && (!ItemExcluded(item, ilExclude!)))
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Item, item.ID));
                        }
                        Ct += FindCategoryItemsPersons(Co.GenerateLoc(CB!.LocType_Behind_Item, item.ID), Category, il);
                    }
                    else if (item.CanPutOn)
                    {
                        if ((HasItemCategory(item, Category)) && (!ItemExcluded(item, ilExclude!)))
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Item, item.ID));
                        }
                        Ct += FindCategoryItemsPersons(Co.GenerateLoc(CB!.LocType_On_Item, item.ID), Category, il);
                    }
                    else if ((item.CanPutBeside))
                    {
                        if ((HasItemCategory(item, Category)) && (!ItemExcluded(item, ilExclude!)))
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Item, item.ID));
                        }
                        Ct += FindCategoryItemsPersons(Co.GenerateLoc(CB!.LocType_Beside_Item, item.ID), Category, il);
                    }
                    else if (item.CanPutBelow)
                    {
                        if ((HasItemCategory(item, Category)) && (!ItemExcluded(item, ilExclude!)))
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Item, item.ID));
                        }
                        Ct += FindCategoryItemsPersons(Co.GenerateLoc(CB!.LocType_Below_Item, item.ID), Category, il);
                    }
                    else
                    {
                        if ((HasItemCategory(item, Category)) && (!ItemExcluded(item, ilExclude!)) && item.IsHidden == false)
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Item, item.ID));
                        }
                    }
                }
            }
            foreach (Person? person in Persons!.List!.Values)
//                 for (int i = 0; i < Persons!.List.Count; i++)
            {
                // Person? Person = Persons!.Find(Persons!.List[i].ID);
                if (Co.GenerateLoc(person) == Loc)
                {
                    if ((person.CanPutIn) && ((person.CanBeClosed == false) || (person.IsClosed == false)))
                    {
                        if ((HasPersonCategory(person, Category)) && (!PersonExcluded(person, ilExclude!)))
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Person, person.ID));
                        }
                        Ct += FindCategoryItemsPersons(Co.GenerateLoc(CB!.LocType_In_Person, person.ID), Category, il);
                    }
                    else
                    {
                        if ((HasPersonCategory(person, Category)) && (!PersonExcluded(person, ilExclude!)))
                        {
                            Ct++;
                            il.Add(new PI(PI.TypeVal.Person, person.ID));
                        }
                        Ct += FindCategoryItemsPersons(Co.GenerateLoc(CB!.LocType_Person, person.ID), Category, il);
                    }
                }
            }
            return Ct;
        }


        public bool DoMCItem(int itemID)
        {
            Item? item = Items!.Find(itemID);
            int idCt = 1;
            int idCtChoice = 2;
            // char Key = '1';

            MCMenu mcM = AdvMCMenu(CA!.Person_I!, false, 1 + CB!.MCE_Choice_Off);
            List<int> cfollower;
            cfollower = new List<int>();
            List<int> follower;
            follower = new List<int>();
            follower.Add(-1);

            cfollower.Add(idCt);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, Items!.GetName(itemID, Co.CASE_AKK, CurrentNouns ), idCt++, follower, null, 0, false, false, false, null, null));

            follower = new List<int>();
            follower.Add(-1);
            // Ignores: 001
            // mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1, Items!.GetName(itemID, Co.CASE_NOM) + " untersuchen", idCt++, follower, null, 0, false, false, false, null, "untersuche " + Items!.GetName(itemID, Co.CASE_NOM)));
            cfollower.Add(idCt);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4591, itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4592, itemID )));

            if ((item!.CanBeTaken) && (item!.GetLoc() != Co.GenerateLoc(CB!.LocType_Person, A!.ActPerson)))
            {
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4593, itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4594, itemID )));
            }
            if ((item.locationType == CB!.LocType_Person) && (item.locationID == A!.ActPerson) && (!AdvGame!.GD!.LayoutDescription.SimpleMC))
            {
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4595, itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4596, itemID )));
            }
            if ((item.CanBeClosed) && (item.IsClosed))
            {
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4597, itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4598, itemID )));
            }
            if ((item.CanBeClosed) && (!item.IsClosed) )
            {
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4599, itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4600, itemID )));
            }
            if ((item.CanPutBehind) && (!item.InvisibleBehind) )
            {
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4601, itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4602, itemID )));
            }
            if ((item.CanPutBelow) && (!item.InvisibleBelow) )
            {
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4603, itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4604, itemID )));
            }
            if ((item.CanPutOn) && (!item.InvisibleOn))
            {
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4605, itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4606, itemID )));
            }
            if ((item.CanPutBeside) && (!item.InvisibleBeside))
            {
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4607, itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4608, itemID )));
            }
            if ((item.CanPutIn) && (item.CanBeClosed) && (!item.IsClosed) && (!item.InvisibleIn))
            {
                cfollower.Add(idCt);
                // mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1, "In " + Items!.GetName(itemID, Co.CASE_NOM) + " schauen", idCt++, follower, null, 0, false, false, false, null, "schaue in " + Items!.GetName(itemID, Co.CASE_NOM)));
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4609, itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4610, itemID )));
            }
            // Wenn ein Item genommen werden kann, dann kann man es auch in ein Behältnis (oder auf oder unter...) stopfen. 
            // Die entsprechenden Kontextmenüs werden nur angezeigt, wenn es auch Targets gibt
            if (item.CanBeTaken)
            {
                List<PI> il = new List<PI>();
                int ctContainers = 0;
                int StartLoc = Co.GenerateLoc(CB!.LocType_Loc, A!.ActLoc);
                int ExcludeLoc = Co.GenerateLoc(item.locationType, item.locationID);

                ctContainers = FindContainers(StartLoc, CB!.LocType_In_Item, il, ExcludeLoc);
                if (ctContainers > 0)
                {
                    List<int> dfollower;
                    dfollower = new List<int>();
                    List<int> efollower;
                    efollower = new List<int>();

                    if (ctContainers == 0)
                        dfollower.Add(-1);
                    else
                        dfollower.Add(idCtChoice + CB!.MCE_Choice_Off);

                    cfollower.Add(idCt);

                    string? s5 = Helper.Insert(loca.Adv_DoMCItem_Person_I_4612, itemID);

                    s5 = null;

                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4611, itemID ), idCt++, dfollower, null, 0, false, false, false, null,  s5));

                    efollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4613, itemID ), idCt++, follower, null, 0, false, false, false, null, null));
                    foreach (PI pi in il)
                    {
                        if (pi.Type == PI.TypeVal.Item)
                        {
                            Item? it2 = Items!.Find(pi.ID);
                            string s4 = it2!.FullName(Co.CASE_NOM, CurrentNouns!, true)!;
                            string s2 =  Helper.Insert(loca.Adv_DoMCItem_Person_I_4614, itemID, it2.ID );
                            efollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s4, idCt++, follower, null, 0, false, false, false, null, s2));
                        }
                    }
                    efollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCItem_Person_I_4615, idCt++, follower, null, 0, false, false, false, null, null));

                    mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", idCtChoice + CB!.MCE_Choice_Off, efollower, null, 0, false, false, false, null, null));
                    idCtChoice++;
                }

                il = new List<PI>();
                ctContainers = FindContainers(StartLoc, CB!.LocType_On_Item, il, ExcludeLoc);
                if (ctContainers > 0)
                {
                    List<int> dfollower;
                    dfollower = new List<int>();
                    List<int> efollower;
                    efollower = new List<int>();

                    if (ctContainers == 0)
                        dfollower.Add(-1);
                    else
                        dfollower.Add(idCtChoice + CB!.MCE_Choice_Off);

                    cfollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4616, itemID ), idCt++, dfollower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4617, itemID )));

                    efollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4618, itemID ), idCt++, follower, null, 0, false, false, false, null, null));
                    foreach (PI pi in il)
                    {
                        if (pi.Type == PI.TypeVal.Item)
                        {
                            Item? it2 = Items!.Find(pi.ID);
                            string s4 = it2!.FullName(Co.CASE_NOM, CurrentNouns!, true)!;
                            string s2 =  Helper.Insert(loca.Adv_DoMCItem_Person_I_4619, itemID, it2.ID )!;
                            efollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s4, idCt++, follower, null, 0, false, false, false, null, s2));
                        }
                    }
                    efollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCItem_Person_I_4620, idCt++, follower, null, 0, false, false, false, null, null));

                    mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", idCtChoice + CB!.MCE_Choice_Off, efollower, null, 0, false, false, false, null, null));
                    idCtChoice++;
                }

                il = new List<PI>();
                ctContainers = FindContainers(StartLoc, CB!.LocType_Behind_Item, il, ExcludeLoc);
                if (ctContainers > 0)
                {
                    List<int> dfollower;
                    dfollower = new List<int>();
                    List<int> efollower;
                    efollower = new List<int>();

                    if (ctContainers == 0)
                        dfollower.Add(-1);
                    else
                        dfollower.Add(idCtChoice + CB!.MCE_Choice_Off);

                    cfollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4621, itemID ), idCt++, dfollower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4622, itemID )));

                    efollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4623, itemID ), idCt++, follower, null, 0, false, false, false, null, null));
                    foreach (PI pi in il)
                    {
                        if (pi.Type == PI.TypeVal.Item)
                        {
                            Item? it2 = Items!.Find(pi.ID);
                            string s4 = it2!.FullName(Co.CASE_NOM, CurrentNouns!, true)!;
                            string s2 =  Helper.Insert(loca.Adv_DoMCItem_Person_I_4624, itemID, it2.ID )!;
                            efollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s4, idCt++, follower, null, 0, false, false, false, null, s2));
                        }
                    }
                    efollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCItem_Person_I_4625, idCt++, follower, null, 0, false, false, false, null, null));

                    mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", idCtChoice + CB!.MCE_Choice_Off, efollower, null, 0, false, false, false, null, null));
                    idCtChoice++;
                }

                il = new List<PI>();
                ctContainers = FindContainers(StartLoc, CB!.LocType_Below_Item, il, ExcludeLoc);
                if (ctContainers > 0)
                {
                    List<int> dfollower;
                    dfollower = new List<int>();
                    List<int> efollower;
                    efollower = new List<int>();

                    if (ctContainers == 0)
                        dfollower.Add(-1);
                    else
                        dfollower.Add(idCtChoice + CB!.MCE_Choice_Off);

                    cfollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4626, itemID ), idCt++, dfollower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4627, itemID )));

                    efollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4628, itemID ), idCt++, follower, null, 0, false, false, false, null, null));
                    foreach (PI pi in il)
                    {
                        if (pi.Type == PI.TypeVal.Item)
                        {
                            Item? it2 = Items!.Find(pi.ID);
                            string s4 = it2!.FullName(Co.CASE_NOM, CurrentNouns!, true)!;
                            string s2 =  Helper.Insert(loca.Adv_DoMCItem_Person_I_4629, itemID, it2.ID );
                            efollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s4, idCt++, follower, null, 0, false, false, false, null, s2));
                        }
                    }
                    efollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCItem_Person_I_4630, idCt++, follower, null, 0, false, false, false, null, null));

                    mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", idCtChoice + CB!.MCE_Choice_Off, efollower, null, 0, false, false, false, null, null));
                    idCtChoice++;

                }
                il = new List<PI>();
                ctContainers = FindContainers(StartLoc, CB!.LocType_Beside_Item, il, ExcludeLoc);
                if (ctContainers > 0)
                {
                    List<int> dfollower;
                    dfollower = new List<int>();
                    List<int> efollower;
                    efollower = new List<int>();

                    if (ctContainers == 0)
                        dfollower.Add(-1);
                    else
                        dfollower.Add(idCtChoice + CB!.MCE_Choice_Off);

                    cfollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4631, itemID ), idCt++, dfollower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4632, itemID )));

                }
            }

            if (item.Categories!.List!.Count > 0)
            {
                // for (int i = 0; i < item.Categories!.List.Count; i++)
                foreach (CategoryRel cr in item.Categories!.List.Values)
                {
                    List<int> dfollower;
                    dfollower = new List<int>();
                    List<int> efollower;
                    efollower = new List<int>();

                    int CountCounter = 0;

                    if (cr.CategoryID == A.Cat_CuttableWith)
                        CountCounter = 0;

                    if (cr.CategoryID < 1000 && (cr.Relevance == relTypes.r_essential || !AdvGame!.GD!.LayoutDescription.SimpleMC))
                    {
                        if (cr.CounterCategoryID != -1 && (cr.Relevance == relTypes.r_essential || !AdvGame!.GD!.LayoutDescription.SimpleMC))
                        {
                            foreach (Item? it2 in Items!.List!.Values)
                            {
                                if (it2 != item)
                                {
                                    foreach (CategoryRel c in it2!.Categories!.List!.Values)
                                    {
                                        if (c != null)
                                        {
                                            // int a = 1;
 
                                            if (c.Relevance == relTypes.r_essential || !AdvGame!.GD!.LayoutDescription.SimpleMC)
                                            {
                                                if ((c.Category!.CategoryID == cr.CounterCategoryID) && (Items!.IsItemHere(it2, Co.Range_Visible) == true))
                                                    CountCounter++;

                                            }
                                        }
                                    }
                                }
                            }
                            foreach (Person pe2 in Persons!.List!.Values)
                            {
                                foreach (CategoryRel c in pe2!.Categories!.List!.Values)
                                {
                                    if (c != null)
                                    {
                                        if (c.Relevance == relTypes.r_essential || !AdvGame!.GD!.LayoutDescription.SimpleMC)
                                        {
                                            if ((c.Category!.CategoryID == cr.CounterCategoryID) && (Persons!.IsPersonHere(pe2, Co.Range_Visible) == true))
                                                CountCounter++;
                                        }
                                    }
                                }
                            }
                        }

                        if (CountCounter == 0)
                        {
                            dfollower.Add(-1);
                        }
                        else
                        {
                            dfollower.Add(idCtChoice + CB!.MCE_Choice_Off);
                        }

                        string? s1 = DoStringMagic(cr.ContextMenuText, item, null)!;
                        string? s2 = DoStringMagic(cr.ParseLine, item, null)!;
                        string? s3 = DoStringMagic(cr.Headline2, item, null)!;

                        if ((cr.CounterCategoryID == -1) || (CountCounter > 0))
                        {
                            cfollower.Add(idCt);
                            if (cr.CounterCategoryID != -1)
                                s2 = null;
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s1, idCt++, dfollower, null, 0, false, false, false, null, s2));
                        }

                        if (CountCounter > 0)
                        {
                            efollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, s1, idCt++, follower, null, 0, false, false, false, null, null));
                            foreach (Item? it2 in Items!.List!.Values)
                            {
                                if (it2 != item)
                                {
                                    foreach (CategoryRel c in it2!.Categories!.List!.Values)
                                    {
                                        if (c != null)
                                        {
                                            if (c.Relevance == relTypes.r_essential || !AdvGame!.GD!.LayoutDescription.SimpleMC)
                                            {
                                                if ((c.Category!.CategoryID == cr.CounterCategoryID) && (Items!.IsItemHere(it2, Co.Range_Visible) == true))
                                                {
                                                    string s4 = it2.FullName(Co.CASE_DAT, CurrentNouns!, true)!;

                                                    if (cr.ParseLine == null)
                                                        s4 = "";
                                                    else if (cr.ParseLine!.Contains(loca.Adv_DoMCItem_Person_I_4633))
                                                        s4 = it2.FullName(Co.CASE_NOM, CurrentNouns!,  true)!;
                                                    else if (cr.ParseLine!.Contains(loca.Adv_DoMCItem_Person_I_4634))
                                                        s4 = it2.FullName(Co.CASE_AKK, CurrentNouns!, true)!;

                                                    s2 = DoStringMagic(cr.ParseLine, item, it2)!;
                                                    efollower.Add(idCt);
                                                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s4, idCt++, follower, null, 0, false, false, false, null, s2));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            foreach (Person pe2 in Persons!.List!.Values)
                            {
                                foreach (CategoryRel c in pe2.Categories!.List!.Values)
                                {
                                    if (c != null)
                                    {
                                        if (c.Relevance == relTypes.r_essential || !AdvGame!.GD!.LayoutDescription.SimpleMC)
                                        {
                                            if ((c.Category!.CategoryID == cr.CounterCategoryID) && (Persons!.IsPersonHere(pe2, Co.Range_Visible) == true))
                                            {
                                                string s4 = pe2.FullName(Co.CASE_DAT, CurrentNouns!, true)!;
                                                if (cr.ParseLine!.Contains(loca.Adv_DoMCItem_Person_I_4635))
                                                    s4 = pe2.FullName(Co.CASE_NOM, CurrentNouns!, true)!;
                                                else if (cr.ParseLine!.Contains(loca.Adv_DoMCItem_Person_I_4636))
                                                    s4 = pe2.FullName(Co.CASE_AKK, CurrentNouns!, true)!;
                                                s2 = DoStringMagic(cr.ParseLine, item, pe2)!;
                                                efollower.Add(idCt);
                                                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s4, idCt++, follower, null, 0, false, false, false, null, s2));
                                            }
                                        }
                                    }
                                }
                            }
                            efollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCItem_Person_I_4637, idCt++, follower, null, 0, false, false, false, null, null));

                            mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", idCtChoice + CB!.MCE_Choice_Off, efollower, null, 0, false, false, false, null, null));
                            idCtChoice++;
                        }
                    }
                }
                /*
                for (int i = 0; i < item.Categories!.List.Count; i++)
                { 
                    List<int> dfollower;
                    dfollower = new List<int>();
                    List<int> efollower;
                    efollower = new List<int>();

                    int CountCounter = 0;

                    if (item.Categories!.List[i].CategoryID == A.Cat_CuttableWith)  
                       CountCounter =0;

                    if (item.Categories!.List[i].CategoryID < 1000 && (item.Categories!.List[i].Relevance == relTypes.r_essential || !AdvGame!.GD!.SimpleMC))
                    {
                        if (item.Categories!.List[i].CounterCategoryID != -1 && (item.Categories!.List[i].Relevance == relTypes.r_essential || !AdvGame!.GD!.SimpleMC))
                        {
                            foreach (Item? it2 in Items!.List!.Values)
                            {
                                if (it2 != item)
                                {
                                    foreach (CategoryRel c in it2!.Categories!.List!.Values)
                                    {
                                        if (c != null)
                                        {
                                            // int a = 1;
                                            if (it2 == CA!.I0_09_Regale)
                                            {
                                            }

                                            if( c.Relevance == relTypes.r_essential || !AdvGame!.GD!.SimpleMC )
                                            {
                                                if ((c.Category!.CategoryID == item.Categories!.List[i].CounterCategoryID) && (Items!.IsItemHere(it2, Co.Range_Visible) == true))
                                                    CountCounter++;

                                            }
                                        }
                                    }
                                }
                            }
                            foreach (Person pe2 in Persons!.List!.Values)
                            {
                                foreach (CategoryRel c in pe2!.Categories!.List!.Values)
                                {
                                    if (c != null)
                                    {
                                        if (c.Relevance == relTypes.r_essential || !AdvGame!.GD!.SimpleMC)
                                        {
                                            if ((c.Category!.CategoryID == item.Categories!.List[i].CounterCategoryID) && (Persons!.IsPersonHere(pe2, Co.Range_Visible) == true))
                                                CountCounter++;
                                        }
                                    }
                                }
                            }
                        }

                        if (CountCounter == 0)
                        {
                            dfollower.Add(-1);
                        }
                        else
                        {
                            dfollower.Add(idCtChoice + CB!.MCE_Choice_Off);
                        }

                        string? s1 = DoStringMagic(item!.Categories!.List[i].ContextMenuText, item, null)!;
                        string? s2 = DoStringMagic(item!.Categories!.List[i].ParseLine, item, null)!;
                        string? s3 = DoStringMagic(item!.Categories!.List[i].Headline2, item, null)!;

                        if ((item.Categories!.List[i].CounterCategoryID == -1) || (CountCounter > 0))
                        {
                            cfollower.Add(idCt);
                            if (item.Categories!.List[i].CounterCategoryID != -1)
                                s2 = null;
                             mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s1, idCt++, dfollower, null, 0, false, false, false, null, s2));
                        }

                        if (CountCounter > 0)
                        {
                            efollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, s1, idCt++, follower, null, 0, false, false, false, null, null));
                            foreach (Item? it2 in Items!.List!.Values)
                            {
                                if (it2 != item)
                                {
                                    foreach (CategoryRel c in it2!.Categories!.List!.Values)
                                    {
                                        if (c != null)
                                        {
                                            if (c.Relevance == relTypes.r_essential || !AdvGame!.GD!.SimpleMC)
                                            {
                                                if ((c.Category!.CategoryID == item.Categories!.List[i].CounterCategoryID) && (Items!.IsItemHere(it2, Co.Range_Visible) == true))
                                                {
                                                    string s4 = it2.FullName(Co.CASE_DAT, true)!;
                                                    if (item.Categories!.List[i].ParseLine!.Contains( loca.Adv_DoMCItem_Person_I_4633))
                                                        s4 = it2.FullName(Co.CASE_NOM, true)!;
                                                    else if (item.Categories!.List[i].ParseLine!.Contains( loca.Adv_DoMCItem_Person_I_4634))
                                                        s4 = it2.FullName(Co.CASE_AKK, true)!;

                                                    s2 = DoStringMagic(item.Categories!.List[i].ParseLine, item, it2)!;
                                                    efollower.Add(idCt);
                                                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s4, idCt++, follower, null, 0, false, false, false, null, s2));
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            foreach (Person pe2 in Persons!.List!.Values)
                            {
                                foreach (CategoryRel c in pe2.Categories!.List!.Values)
                                {
                                    if (c != null)
                                    {
                                        if (c.Relevance == relTypes.r_essential || !AdvGame!.GD!.SimpleMC)
                                        {
                                            if ((c.Category!.CategoryID == item.Categories!.List[i].CounterCategoryID) && (Persons!.IsPersonHere(pe2, Co.Range_Visible) == true))
                                            {
                                                string s4 = pe2.FullName(Co.CASE_DAT, true)!;
                                                if( item.Categories!.List[i].ParseLine!.Contains( loca.Adv_DoMCItem_Person_I_4635))
                                                    s4 = pe2.FullName(Co.CASE_NOM, true)!;
                                                else if (item.Categories!.List[i].ParseLine!.Contains( loca.Adv_DoMCItem_Person_I_4636))
                                                    s4 = pe2.FullName(Co.CASE_AKK, true)!;
                                                s2 = DoStringMagic(item.Categories!.List[i].ParseLine, item, pe2)!;
                                                efollower.Add(idCt);
                                                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s4, idCt++, follower, null, 0, false, false, false, null, s2));
                                            }
                                        }
                                    }
                                }
                            }
                            efollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCItem_Person_I_4637, idCt++, follower, null, 0, false, false, false, null, null));

                            mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", idCtChoice + CB!.MCE_Choice_Off, efollower, null, 0, false, false, false, null, null));
                            idCtChoice++;
                        }
                    }
                }
                */
            }
            List<int> xFollower = new List<int>();
            xFollower.Add(idCtChoice + CB!.MCE_Choice_Off);

            /*
            cfollower.Add(idCt);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, "Info", idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("Info zu [It1,Dat]", itemID )));
            */

            cfollower.Add(idCt);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCItem_Person_I_4638, idCt++, follower, null, 0, false, false, false, null, null));

            mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", 1 + CB!.MCE_Choice_Off, cfollower, null, 0, false, false, false, null, null));

            cfollower = new List<int>();

            xFollower = new List<int>();
            xFollower.Add(-1);

            cfollower.Add(idCt);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4639, itemID ), idCt++, xFollower, null, 0, false, false, false, null, null));

            cfollower.Add(idCt);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCItem_Person_I_4640, idCt++, xFollower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4641, itemID )));

            cfollower.Add(idCt);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCItem_Person_I_4642, idCt++, xFollower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4643, itemID )));

            cfollower.Add(idCt);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCItem_Person_I_4644, idCt++, xFollower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4645, itemID )));

            cfollower.Add(idCt);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCItem_Person_I_4646, idCt++, xFollower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCItem_Person_I_4647, itemID )));

            cfollower.Add(idCt);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCItem_Person_I_4648, idCt++, follower, null, 0, false, false, false, null, null));

            mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", idCtChoice + CB!.MCE_Choice_Off, cfollower, null, 0, false, false, false, null, null));
            idCtChoice++;

            mcM.MCS = new Phoney_MAUI.Core.MCMenuView();
            mcM.Set(0);
            Orders!.temporaryMCMenu = mcM;
            Orders!.persistentMCMenu = null;
            // mcM.AddCurrent(1);
            mcM.MCS.MCOutput(mcM, MCSelectionParser, false);
            return true;
        }

        public bool DoMCPerson(Person? personID)
        {
            Person? person = Persons!.Find(personID!)!;
            int idCt = 1;
            int idCtChoice = 2;

            MCMenu mcM = AdvMCMenu(CA!.Person_I!, false, 1 + CB!.MCE_Choice_Off);
            List<int> cfollower = new List<int>();
            List<int> follower = new List<int>();
            follower.Add(-1);

            if (personID!.ID == A!.ActPerson)
            {

                mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, loca.Adv_DoMCPerson_Person_I_4649, idCt++, follower, null, 0, false, false, false, null, null));

                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCPerson_Person_I_4650, idCt++, follower, null, 0, false, false, false, null, loca.Adv_DoMCPerson_Person_I_4651));
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCPerson_Person_I_4652, idCt++, follower, null, 0, false, false, false, null, loca.Adv_DoMCPerson_Person_I_4653));
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCPerson_Person_I_4654, idCt++, follower, null, 0, false, false, false, null, loca.Adv_DoMCPerson_Person_I_4655));
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCPerson_Person_I_4656, idCt++, follower, null, 0, false, false, false, null, null));

                follower = new List<int>();
                for (int j = 1; j < idCt; j++)
                {
                    follower.Add(j);

                }
                mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", 1 + CB!.MCE_Choice_Off, follower, null, 0, false, false, false, null, null));

                mcM.MCS = new Phoney_MAUI.Core.MCMenuView();
                mcM.Set(0);
                Orders!.temporaryMCMenu = mcM;
                Orders!.persistentMCMenu = null;
                // MCM.AddCurrent(1);
                mcM.MCS.MCOutput(mcM, MCSelectionParser, false);
            }
            else
            {
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, Persons!.GetPersonName(personID, Co.CASE_AKK, CurrentNouns! ), idCt++, follower, null, 0, false, false, false, null, null));

                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCPerson_Person_I_4657, personID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCPerson_Person_I_4658, personID )));

                if ((person!.locationType == CB!.LocType_Loc) && (person.locationID == A!.ActLoc) && (person.CanBeTaken))
                {
                    cfollower.Add(idCt);
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert(loca.Adv_DoMCPerson_Person_I_4659, personID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCPerson_Person_I_4660, personID )));
                }

                /*
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1,  Helper.Insert("Mit [Pt1,Dat] reden", personID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("rede mit [Pt1,Nom]", personID )));
                */

                if (person.Categories!.List!.Count > 0)
                {
                    // for (int i = 0; i < item.Categories!.List.Count; i++)
                    foreach (CategoryRel cr in person.Categories!.List.Values)
                    {
                        // for (int i = 0; i < person.Categories!.List.Count; i++)
                        // {
                        List<int> dfollower;
                        dfollower = new List<int>();
                        List<int> efollower;
                        efollower = new List<int>();

                        int CountCounter = 0;

                        if (cr.CategoryID < 1000)
                        {
                            if (cr.CounterCategoryID != -1)
                            {
                                foreach (Item? it2 in Items!.List!.Values)
                                {
                                    foreach (CategoryRel c in it2.Categories!.List!.Values)
                                    {
                                        if (c != null)
                                        {
                                            if ((c.Category!.CategoryID == cr.CounterCategoryID) && (Items!.IsItemHere(it2, Co.Range_Visible) == true))
                                                CountCounter++;
                                        }
                                    }
                                }

                                foreach (Person pe2 in Persons!.List!.Values)
                                {
                                    if (pe2 != person)
                                    {
                                        foreach (CategoryRel c in pe2.Categories!.List!.Values)
                                        {
                                            if (c != null)
                                            {
                                                if ((c.Category!.CategoryID == cr.CounterCategoryID) && (Persons!.IsPersonHere(pe2, Co.Range_Visible) == true))
                                                    CountCounter++;
                                            }
                                        }
                                    }
                                }
                            }

                            if (CountCounter == 0)
                            {
                                dfollower.Add(-1);
                            }
                            else
                            {
                                dfollower.Add(idCtChoice + CB!.MCE_Choice_Off);
                            }

                            string? s1 = DoStringMagic(cr.ContextMenuText, person, null)!;
                            string? s2 = DoStringMagic(cr.ParseLine, person, null)!;
                            string? s3 = DoStringMagic(cr.Headline2, person, null)!;

                            if ((cr.CounterCategoryID == -1) || (CountCounter > 0))
                            {
                                cfollower.Add(idCt);
                                if (cr.CounterCategoryID != -1)
                                    s2 = null;

                                // mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s1, idCt++, dfollower, null, 0, false, false, false, null, null));
                                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s1, idCt++, dfollower, null, 0, false, false, false, null, s2));
                            }

                            if (CountCounter > 0)
                            {
                                efollower.Add(idCt);
                                mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, s1, idCt++, follower, null, 0, false, false, false, null, null));
                                // mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, s1, idCt++, follower, null, 0, false, false, false, null, null));
                                foreach (Item? it2 in Items!.List!.Values)
                                {
                                    foreach (CategoryRel c in it2.Categories!.List!.Values)
                                    {
                                        if (c != null)
                                        {
                                            if ((c.Category!.CategoryID == cr.CounterCategoryID) && (Items!.IsItemHere(it2, Co.Range_Visible) == true))
                                            {
                                                string s4 = it2.FullName(Co.CASE_DAT, CurrentNouns! )!;
                                                s2 = DoStringMagic(cr.ParseLine, person, it2)!;
                                                efollower.Add(idCt);
                                                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s4, idCt++, follower, null, 0, false, false, false, null, s2));
                                            }
                                        }
                                    }
                                }
                                foreach (Person pe2 in Persons!.List!.Values)
                                {
                                    if (pe2 != person)
                                    {
                                        foreach (CategoryRel c in pe2.Categories!.List!.Values)
                                        {
                                            if (c != null)
                                            {
                                                if ((c.Category!.CategoryID == cr.CounterCategoryID) && (Persons!.IsPersonHere(pe2, Co.Range_Visible) == true))
                                                {
                                                    string s4 = pe2.FullName(Co.CASE_DAT, CurrentNouns! )!;
                                                    s2 = DoStringMagic(cr.ParseLine, person, pe2)!;
                                                    efollower.Add(idCt);
                                                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, s4, idCt++, follower, null, 0, false, false, false, null, s2));
                                                }
                                            }
                                        }
                                    }
                                }
                                efollower.Add(idCt);
                                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCPerson_Person_I_4661, idCt++, follower, null, 0, false, false, false, null, null));

                                mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", idCtChoice + CB!.MCE_Choice_Off, efollower, null, 0, false, false, false, null, null));
                                idCtChoice++;
                            }
                        }
                    }
                }

                List<int> xFollower = new List<int>();
                xFollower.Add(idCtChoice + CB!.MCE_Choice_Off);

                /*
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, "Info", idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("Info zu [Pt1,Akk]", personID )));
                */
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCPerson_Person_I_4662, idCt++, follower, null, 0, false, false, false, null, null));

                mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", 1 + CB!.MCE_Choice_Off, cfollower, null, 0, false, false, false, null, null));

                cfollower = new List<int>();

                xFollower = new List<int>();
                xFollower.Add(-1);

                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, null,  Helper.Insert(loca.Adv_DoMCPerson_Person_I_4663, personID ), idCt++, xFollower, null, 0, false, false, false, null, null));

                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCPerson_Person_I_4664, idCt++, xFollower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCPerson_Person_I_4665, personID )));

                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCPerson_Person_I_4666, idCt++, xFollower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCPerson_Person_I_4667, personID )));

                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCPerson_Person_I_4668, idCt++, xFollower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCPerson_Person_I_4669, personID )));

                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCPerson_Person_I_4670, idCt++, xFollower, null, 0, false, false, false, null,  Helper.Insert(loca.Adv_DoMCPerson_Person_I_4671, personID )));

                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCPerson_Person_I_4672, idCt++, follower, null, 0, false, false, false, null, null));

                mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", idCtChoice + CB!.MCE_Choice_Off, cfollower, null, 0, false, false, false, null, null));
                idCtChoice++;

                /*
                cfollower.Add(idCt);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, "Ende", idCt++, follower, null, 0, false, false, false, null, null));
                mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", 1 + CB!.MCE_Choice_Off, cfollower, null, 0, false, false, false, null, null));
               */

                mcM.MCS = new Phoney_MAUI.Core.MCMenuView() ;
                mcM.Set(0);
                Orders!.temporaryMCMenu = mcM;
                Orders!.persistentMCMenu = null;

                // mcM.AddCurrent(1);
                mcM.MCS.MCOutput(mcM, MCSelectionParser, false);

                Phoney_MAUI.App.CurrentPage!.Focus();

                return true;
            }
            return true;
        }



        public bool DoMCCategory(string Title, string ParseLine, int CategoryID, string? Stage2Syntax = null )
        {
            if (Stage2Syntax == null)
                Stage2Syntax = loca.Adv_DoMCCategory_4673;

            int idCt = 1;
            int idCtChoice = 2;
            List<PI> il = new List<PI>();
            int ctCategoryItems = 0;
            int StartLoc = Co.GenerateLoc(CB!.LocType_Loc, A!.ActLoc);
            List<PI> ilCounter = new List<PI>();
            List<PI> ilTemp = new List<PI>();
            int ctCounterCategoryItems = 0;
            int CounterCatID = -1;

            ctCategoryItems = FindCategoryItemsPersons(StartLoc, CategoryID, il);

            MCMenu mcM = AdvMCMenu(CA!.Person_I!, false, 1 + CB!.MCE_Choice_Off);
            List<int> cfollower = new List<int>();
            List<int> dfollower = new List<int>();
            List<int> follower = new List<int>();
            follower.Add(-1);

            cfollower.Add(idCt);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, Title, idCt++, follower, null, 0, false, false, false, null, null));

            CategoryRel c = Categories!.Find(CategoryID)!;
            if (c != null)
            {
                CounterCatID = c.CounterCategoryID;
                if (CounterCatID > -1)
                {
                    ctCounterCategoryItems = FindCategoryItemsPersons(StartLoc, CounterCatID, ilCounter);
                }
            }

            if (ctCategoryItems > 0)
            {
                for (int i = 0; i < ctCategoryItems; i++)
                {

                    if (il[i].Type == PI.TypeVal.Item)
                    {
                        if (CounterCatID <= 0)
                        {
                            string s1 = DoStringMagic(ParseLine, Items!.Find(il[i].ID), null)!;
                            cfollower.Add(idCt);
                            follower = new List<int>();
                            follower.Add(-1);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, Items!.GetName(il[i].ID, Co.CASE_NOM, CurrentNouns), idCt++, follower, null, 0, false, false, false, null, s1));
                        }
                        else
                        {
                            string s1 = DoStringMagic(ParseLine, Items!.Find(il[i].ID), null)!;
                            follower = new List<int>();
                            follower.Add(idCtChoice + CB!.MCE_Choice_Off);
                            cfollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, Items!.GetName(il[i].ID, Co.CASE_NOM, CurrentNouns), idCt++, follower, null, 0, false, false, false, null, s1));


                            dfollower = new List<int>();
                            follower = new List<int>();
                            follower.Add(-1);

                            dfollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, s1, idCt++, follower, null, 0, false, false, false, null, null));

                            AbstractAdvObject AO;

                            if (il[i].Type == PI.TypeVal.Item)
                            {
                                ilTemp = new List<PI>();
                                ilTemp.Add(new PI(PI.TypeVal.Item, il[i].ID));
                                AO = Items!.Find(il[i].ID)!;
                            }
                            else
                            {
                                ilTemp = new List<PI>();
                                ilTemp.Add(new PI(PI.TypeVal.Item, il[i].ID));
                                AO = Persons!.Find(il[i].ID)!;
                            }

                            ctCounterCategoryItems = FindCategoryItemsPersons(StartLoc, CounterCatID, ilCounter, ilTemp);


                            for (int j = 0; j < ctCounterCategoryItems; j++)
                            {
                                if (ilCounter[j].Type == PI.TypeVal.Item)
                                {
                                    string s2 = DoStringMagic(ParseLine, AO, Items!.Find(ilCounter[j].ID))!;
                                    dfollower.Add(idCt);
                                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, DoStringMagic(Stage2Syntax, Items!.Find(ilCounter[j].ID), null), idCt++, follower, null, 0, false, false, false, null, s2));

                                }
                                else if (ilCounter[j].Type == PI.TypeVal.Person)
                                {
                                    string s2 = DoStringMagic(ParseLine, AO, Persons!.Find(ilCounter[j].ID))!;
                                    dfollower.Add(idCt);
                                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, DoStringMagic(Stage2Syntax, Persons!.Find(ilCounter[j].ID), null), idCt++, follower, null, 0, false, false, false, null, s2));

                                }
                            }

                            dfollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCCategory_Person_I_4674, idCt++, follower, null, 0, false, false, false, null, null));

                            mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", (idCtChoice++) + CB!.MCE_Choice_Off, dfollower, null, 0, false, false, false, null, null));
                            follower = new List<int>();
                            follower.Add(-1);

                        }
                    }
                    else if (il[i].Type == PI.TypeVal.Person)
                    {
                        if (CounterCatID <= 0)
                        {
                            string s1 = DoStringMagic(ParseLine, Persons!.Find(il[i].ID), null)!;
                            cfollower.Add(idCt);
                            follower = new List<int>();
                            follower.Add(-1);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, Persons!.Find(il[i].ID)!.FullName(Co.CASE_NOM, CurrentNouns! ), idCt++, follower, null, 0, false, false, false, null, s1));
                        }
                        else
                        {
                            string s1 = DoStringMagic(ParseLine, Persons!.Find(il[i].ID!), null)!;
                            follower = new List<int>();
                            follower.Add(idCtChoice + CB!.MCE_Choice_Off);
                            cfollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, Persons!.Find(il[i].ID)!.FullName(Co.CASE_NOM, CurrentNouns! ), idCt++, follower, null, 0, false, false, false, null, s1));


                            dfollower = new List<int>();
                            follower = new List<int>();
                            follower.Add(-1);

                            dfollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, s1, idCt++, follower, null, 0, false, false, false, null, null));

                            AbstractAdvObject AO;

                            if (il[i].Type == PI.TypeVal.Item)
                            {
                                ilTemp = new List<PI>();
                                ilTemp.Add(new PI(PI.TypeVal.Item, il[i].ID));
                                AO = Items!.Find(il[i].ID)!;
                            }
                            else
                            {
                                ilTemp = new List<PI>();
                                ilTemp.Add(new PI(PI.TypeVal.Item, il[i].ID));
                                AO = Persons!.Find(il[i].ID)!;
                            }

                            ctCounterCategoryItems = FindCategoryItemsPersons(StartLoc, CounterCatID, ilCounter, ilTemp);


                            for (int j = 0; j < ctCounterCategoryItems; j++)
                            {

                                if (ilCounter[j].Type == PI.TypeVal.Item)
                                {
                                    string s2 = DoStringMagic(ParseLine, AO, Items!.Find(ilCounter[j].ID!))!;
                                    dfollower.Add(idCt);
                                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, DoStringMagic(Stage2Syntax, Items!.Find(ilCounter[j].ID), null), idCt++, follower, null, 0, false, false, false, null, s2));

                                }
                                else if (ilCounter[j].Type == PI.TypeVal.Person)
                                {
                                    string s2 = DoStringMagic(ParseLine, AO, Persons!.Find(ilCounter[j].ID))!;
                                    dfollower.Add(idCt);
                                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, DoStringMagic(Stage2Syntax, Persons!.Find(ilCounter[j].ID), null), idCt++, follower, null, 0, false, false, false, null, s2));

                                }
                            }

                            dfollower.Add(idCt);
                            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCCategory_Person_I_4675, idCt++, follower, null, 0, false, false, false, null, null));

                            mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", (idCtChoice++) + CB!.MCE_Choice_Off, dfollower, null, 0, false, false, false, null, null));
                            follower = new List<int>();
                            follower.Add(-1);

                        }
                    }
                }
            }
            cfollower.Add(idCt);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCCategory_Person_I_4676, idCt++, follower, null, 0, false, false, false, null, null));

            mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", 1 + CB!.MCE_Choice_Off, cfollower, null, 0, false, false, false, null, null));
            mcM.MCS = new Phoney_MAUI.Core.MCMenuView()!;
            mcM.Set(0);
            Orders!.temporaryMCMenu = mcM;
            Orders!.persistentMCMenu = null;
            // mcM.AddCurrent(1);
            mcM.MCS.MCOutput(mcM, MCSelectionParser, false);
            return true;


#pragma warning disable CS0162 // Unerreichbarer Code wurde entdeckt.
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCCategory_Person_I_4677, idCt++, follower, null, 0, false, false, false, null, loca.Adv_DoMCCategory_Person_I_4678));
#pragma warning restore CS0162 // Unerreichbarer Code wurde entdeckt.
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCCategory_Person_I_4679, idCt++, follower, null, 0, false, false, false, null, loca.Adv_DoMCCategory_Person_I_4680));
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_DoMCCategory_Person_I_4681, idCt++, follower, null, 0, false, false, false, null, loca.Adv_DoMCCategory_Person_I_4682));

            return (true);
        }


        public bool LinkCallback(string s)
        {
            SetStoryLine = false;


            // Noloca: 001
            if (s.Substring(0, 6) == "Item: ")
            {
                int itemID = Int32.Parse(s.Substring(6));

                if( !Items!.IsItemHere( itemID, Co.Range_Here ) )
                {
                    int loc;
                    loc = Items!.GetItemLoc(itemID);
                    Orders!.GoTargetlocation(loc);

                }
                if (Items!.IsItemHere(itemID, Co.Range_Here))
                {
                    return DoMCItem(itemID);
                }
                /*
                DoMCItem(itemID);
                Item? Item = Items!.Find(itemID);
                int idCt = 1;
                // char Key = '1';

                MCMenu mcM = AdvMCMenu(1, false, 1 + CB!.MCE_Choice_Off);
                List<int> follower;


                follower = new List<int>();
                follower.Add(-1);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, 0, Items!.GetName(itemID, Co.CASE_AKK), idCt++, follower, null, 0, false, false, false, null, null));

                follower = new List<int>();
                follower.Add(-1);
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1,  Helper.Insert("[It1,Nom] untersuchen", itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("untersuche [It1,Nom]", itemID )));

                if ((item.locationType == CB!.LocType_Loc) && (item.locationID == A!.ActLoc))
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1,  Helper.Insert("[It1,Nom] nehmen", itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("nimm [It1,Nom]", itemID )));
                if ((item.locationType == CB!.LocType_Person) && (item.locationID == A!.ActPerson))
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1,  Helper.Insert("[It1,Nom] weglegen", itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("lege [It1,Nom] ab", itemID )));
                if ((item.CanBeClosed) && (item.IsClosed))
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1,  Helper.Insert("[It1,Nom] öffnen", itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("öffne [It1,Nom]", itemID )));
                if ((item.CanBeClosed) && (!item.IsClosed))
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1,  Helper.Insert("[It1,Nom] schließen", itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("schließe [It1,Nom]", itemID )));
                if (item.CanPutBehind)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1,  Helper.Insert("Hinter [It1,Nom] schauen", itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("schaue hinter [It1,Nom]", itemID )));
                if (item.CanPutBelow)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1,  Helper.Insert("Unter [It1,Nom] schauen", itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("schaue unter [It1,Nom]", itemID )));
                if (item.CanPutOn)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1,  Helper.Insert("Auf [It1,Nom] schauen", itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("schaue auf [It1,Nom]", itemID )));
                if (item.CanPutBeside)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1,  Helper.Insert("Neben [It1,Nom] schauen", itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("schaue neben [It1,Nom]", itemID )));
                if ((item.CanPutIn) && (item.CanBeClosed) && (!item.IsClosed))
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1,  Helper.Insert("In [It1,Nom] schauen", itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("schaue in[It1,Nom]", itemID )));



                mcM.Add(new MCMenuEntry(CB!.MCE_Text, 1, "Ende", idCt++, follower, null, 0, false, false, false, null, null));

                follower = new List<int>();
                for (int j = 1; j < idCt; j++)
                {
                    follower.Add(j);

                }
                mcM.Add(new MCMenuEntry(CB!.MCE_Choice, 0, "", 1 + CB!.MCE_Choice_Off, follower, null, 0, false, false, false, null, null));
                mcM.MCS = new MCMenuShow(MW);
                mcM.Set(0);
                // mcM.AddCurrent(1);
                mcM.MCS.MCOutput(mcM, MCSelectionParser, false);
                */
            }
            // Noloca: 001
            else if (s.Substring(0, 5) == "Dir: ")
            {
                int dir = Int32.Parse(s.Substring(5 ));
                Orders!.Go(Persons!.Find(A!.ActPerson), dir);
            }
            // Noloca: 001
            else if (s.Substring(0, 5) == "Loc: ")
            {
                int loc = Int32.Parse(s.Substring(5));
                Orders!.GoTargetlocation(loc);

            }
            // Noloca: 001
            else if (s.Substring(0, 6) == "ActLoc")
            {
                int idCt = 1;
                // char Key = '1';

                MCMenu mcM = AdvMCMenu(CA!.Person_I!, false, 1 + CB!.MCE_Choice_Off);
                List<int> follower;


                follower = new List<int>();
                follower.Add(-1);

                mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, locations!.Act().LocName + loca.Adv_LinkCallback_Person_I_4683, idCt++, follower, null, 0, false, false, false, null, null));

                if (locations.Act().LocExit[1] > 0)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4684, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4685));
                if (locations.Act().LocExit[2] > 0)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4686, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4687));
                if (locations.Act().LocExit[3] > 0)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4688, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4689));
                if (locations.Act().LocExit[4] > 0)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4690, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4691));
                if (locations.Act().LocExit[5] > 0)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4692, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4693));
                if (locations.Act().LocExit[6] > 0)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4694, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4695));
                if (locations.Act().LocExit[7] > 0)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4696, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4697));
                if (locations.Act().LocExit[8] > 0)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4698, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4699));
                if (locations.Act().LocExit[9] > 0)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4700, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4701));
                if (locations.Act().LocExit[10] > 0)
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4702, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4703));

                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4704, idCt++, follower, null, 0, false, false, false, null, null));

                follower = new List<int>();
                for (int j = 1; j < idCt; j++)
                {
                    follower.Add(j);

                }
                mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", 1 + CB!.MCE_Choice_Off, follower, null, 0, false, false, false, null, null));

                mcM.MCS = new Phoney_MAUI.Core.MCMenuView();
                mcM.Set(0);
                Orders!.temporaryMCMenu = mcM;
                Orders!.persistentMCMenu = null;
                // MCM.AddCurrent(1);
                mcM.MCS.MCOutput(mcM, MCSelectionParser, false);
            }
            // Noloca: 001
            else if (s.Substring(0, 9) == "ActPerson")
            {
                int idCt = 1;
                // char Key = '1';

                MCMenu mcM = AdvMCMenu(CA!.Person_I!, false, 1 + CB!.MCE_Choice_Off);
                List<int> follower;


                follower = new List<int>();
                follower.Add(-1);

                mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, loca.Adv_LinkCallback_Person_I_4705, idCt++, follower, null, 0, false, false, false, null, null));

                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4706, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4707));
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4708, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4709));
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4710, idCt++, follower, null, 0, false, false, false, null, loca.Adv_LinkCallback_Person_I_4711));
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.Adv_LinkCallback_Person_I_4712, idCt++, follower, null, 0, false, false, false, null, null));

                follower = new List<int>();
                for (int j = 1; j < idCt; j++)
                {
                    follower.Add(j);

                }
                mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, "", 1 + CB!.MCE_Choice_Off, follower, null, 0, false, false, false, null, null));

                mcM.MCS = new Phoney_MAUI.Core.MCMenuView();
                mcM.Set(0);
                Orders!.temporaryMCMenu = mcM;
                Orders!.persistentMCMenu = null;
                // MCM.AddCurrent(1);
                mcM.MCS.MCOutput(mcM, MCSelectionParser, false);

            }
            // Noloca: 001
            else if (s.Substring(0, 8) == "Person: ")
            {
               int personID = Int32.Parse(s.Substring(8 ));
                if (personID > 0)
                {
                    Person p = Persons!.Find(personID)!;

                    if (!Persons!.IsPersonHere(p, Co.Range_Here))
                    {
                        (int _lType, int _lID) loc;
                        loc = Persons!.GetPersonLoc(p);
                        Orders!.GoTargetlocation(loc._lID);

                    }
                    if (Persons!.IsPersonHere(p, Co.Range_Here))
                    {
                        if (p != null)
                            return DoMCPerson(Persons!.Find(personID));
                        else
                            return false;
                    }
                }
                else
                    return false;

             }
            UIS!.DoUIUpdate();
            UIS!.StoryTextObj!.AdvTextRefresh();

#if !NEWSCROLL
            UIS!.Scr!.ScrollPageFinal();
            UIS!.Scr!.SetNext = true;
#endif
            return (true);
        }



        public bool MCSelectionParser(MCMenu MCM, int Selection)
        {
            bool found = false;
            if (Selection <= 1) return found;

            MCMenuEntry tMCME; //  = MCM.FindID(Selection);

            if (Selection >= 1)
            {
                // Diese Funktion muss nicht aufzeichnen
                // OrderList.AddOrder(orderType.mcChoice, null, Selection);

                // Hier wird nur noch die eigentliche Selection behandelt, den Rest übernimmt Set()
                tMCME = MCM.FindID(Selection)!;
                if (tMCME!.DeactivateAfterSelect)
                    tMCME!.Hidden = MCMenuEntry.HiddenType.outdated;

                // AdvGame!.StoryOutput(Persons!.Find(MCME.Speaker).locationID, CA!.Person_Everyone, "");
                MCM.Set(tMCME.ID);

                AdvGame!.SkipAfterDialog = false;

                if (UIS!.FeedbackTextObj!.FeedbackModeMC == false && UIS!.FlushText == false)
                {
                    if (tMCME.ParseString != null)
                    {
                        // Diese Meethode macht nix
                        // UIS!.FeedbackTextObj.FeedbackTextOutput(tMCME.ParseString);
                        DoGameLoop(tMCME.ParseString);
                        UIS.SetInputline("");
                    }
                }
            }

            // MW.MCOutputExit();

            return found;

        }



        public bool ResetStoryText()
        {
            UIS!.ResetStoryText();
            // STE.SetMainWindow(MW!, UIS!);
            return true;
        }

        public bool ResetFeedbackText()
        {
            UIS!.ResetFeedbackText();
            // FBE.SetMainWindow(MW);
            return true;
        }

        public bool SetCallbacks()
        {
            // Hier werden alle Callback-Funktionen für alle Items, Persons, Topics gesetzt - damit sie auch nach dem Ladevorgang noch zur Verfügung stehen

            return (true);
        }


        public bool SetObjectReferences(ItemList Items, PersonList Persons, locationList locations, NounList Nouns, AdjList Adjs, VerbList Verbs, PrepList Preps, FillList Fills, StatusList Stats, List<LatestInput> LI, TopicList Topics, CoAdv CA, CoBase CB)
        {
            this.Items = Items;
            this.Persons = Persons;
            this.locations = locations;
            this.Adjs = Adjs;
            this.Preps = Preps;
            this.Fills = Fills;
            this.Stats = Stats;
            this.LI = LI;
            this.Topics = Topics;
            this.CA = CA;
            this.CB = CB;
            return true;
        }



        public bool DoRandomWalk(int PersonID, List<int> ValidLocs)
        {
            int validDirs = 0;
            Person? person = Persons!.Find(PersonID);


            if (person!.locationType == CB!.LocType_Loc)
            {
                location loc = locations!.Find(person!.locationID!)!;

                for (int i = 1; i < 10; i++)
                {
                    for (int j = 0; j < ValidLocs.Count; j++)
                    {
                        if (loc!.LocExit[i] == ValidLocs[j])
                        {
                            validDirs++;
                        }
                    }
                }

                if (validDirs > 0)
                {
                    int val = GD!.RandomNumber(0, validDirs);

                    for (int i = 1; i < 10; i++)
                    {
                        for (int j = 0; j < ValidLocs.Count; j++)
                        {
                            if (loc!.LocExit[i] == ValidLocs[j])
                            {
                                if (val == 0)
                                {
                                    Orders!.Go(Persons!.Find(PersonID), i);
                                }
                                else
                                    val--;
                            }
                        }
                    }


                }
            }
            return true;
        }



        public void ScanCloneSignatures()
        {
            int similares = 0;

            foreach( Item? i in Items!.List!.Values)
            {
                // bool foundTwoSimilar = false;

                foreach( Item? i2 in Items!.List!.Values )
                {
                    if ( i2 != i )
                    {
                        bool foundDifference = false;

                        foreach (Noun n in i!.Names!)
                        {
                            bool foundSimilar = false;
                            foreach( Noun n2 in i2!.Names!)
                            {
                                if( n2 == n)
                                {
                                    foundSimilar = true;
                                    break;
                                }
                            }
                            if( foundSimilar != true)
                            {
                                foundDifference = true;
                                break;
                            }
                        }

                        if( !foundDifference)
                        {
                            foreach (Adj a in i!.Adjectives!)
                            {
                                bool foundSimilar = false;
                                foreach (Adj a2 in i2!.Adjectives!)
                                {
                                    if (a2 == a)
                                    {
                                        foundSimilar = true;
                                        break;
                                    }
                                }
                                if (foundSimilar != true)
                                {
                                    foundDifference = true;
                                    break;
                                }
                            }

                        }
                        if (!foundDifference)
                        {
                            // foundTwoSimilar = true;
                            similares++;
                        }
                    }
                }
            }
            foreach (Person p in Persons!.List!.Values)
            {
                // bool foundTwoSimilar = false;

                foreach (Person p2 in Persons!.List!.Values)
                {
                    if (p2 != p)
                    {
                        bool foundDifference = false;

                        foreach (Noun n in p!.Names!)
                        {
                            bool foundSimilar = false;
                            foreach (Noun n2 in p2!.Names!)
                            {
                                if (n2 == n)
                                {
                                    foundSimilar = true;
                                    break;
                                }
                            }
                            if (foundSimilar != true)
                            {
                                foundDifference = true;
                                break;
                            }
                        }

                        if (!foundDifference)
                        {
                            foreach (Adj a in p!.Adjectives!)
                            {
                                bool foundSimilar = false;
                                foreach (Adj a2 in p2!.Adjectives!)
                                {
                                    if (a2 == a)
                                    {
                                        foundSimilar = true;
                                        break;
                                    }
                                }
                                if (foundSimilar != true)
                                {
                                    foundDifference = true;
                                    break;
                                }
                            }

                        }
                        if (!foundDifference)
                        {
                            // foundTwoSimilar = true;
                            similares++;
                        }
                    }
                }
            }

            if (similares > 0)
            {
                // Hä?
                // similares = similares;

            }
        }

        public void LighterInit(Item? item)
        {
            item!.SetStatus(CA!.iStatus_Lantern, 0);
            item!.SetStatus(CA!.iStatus_Lantern_Count, 0);
            item!.Categories!.Add(Categories!.Find(A.Cat_Enlightable));
            item!.AppendixLoca = "Adv_LighterInit_5706";
        }

        public void LighterSwitchToOn(Item? item)
        {
            item!.SetStatus(CA!.iStatus_Lantern, 1);
            item!.Categories!.Delete(A.Cat_Enlightable);
            item!.Categories!.Add(Categories!.Find(A.Cat_Extinguishable));
            item!.AppendixLoca = "Adv_LighterSwitchToOn_5707";
        }

        public void LighterSwitchToOff(Item? item)
        {
            item!.SetStatus(CA!.iStatus_Lantern, 0);
            item!.Categories!.Delete(A.Cat_Extinguishable);
            item!.Categories!.Add(Categories!.Find(A.Cat_Enlightable));
            item!.AppendixLoca = "Adv_LighterSwitchToOff_5708";
        }


        public void LockedDoorInit(Item? item)
        {
            item!.SetStatus(CA!.iStatus_Locked, 1);
            item!.Categories!.Add(Categories!.Find(A.Cat_Unlockable));
        }

        public void LockedDoorSwitchToUnlocked(Item? item, bool searchCounter = true)
        {
            if (item!.GetStatus(CA!.iStatus_Locked) != -1)
            {
                item!.SetStatus(CA!.iStatus_Locked, 0);
                item!.Categories!.Delete(A.Cat_Unlockable);
                item!.Categories!.Add(Categories!.Find(A.Cat_Lockable));
                item!.IsLocked = false;

                if (searchCounter && item.GetStatus(CA!.iStatus_Counter_Door) != -1)
                {
                    Item? item2 = Items!.Find(item.GetStatus(CA!.iStatus_Counter_Door));
                    if (item2 !=null)
                        LockedDoorSwitchToUnlocked(item2, false);
                }
            }
        }

        public void LockedDoorSwitchToLocked(Item? item, bool searchCounter = true)
        {
            if (item!.GetStatus(CA!.iStatus_Locked) != -1)
            {
                item!.SetStatus(CA!.iStatus_Locked, 1);
                item!.Categories!.Delete(A.Cat_Lockable);
                item!.Categories!.Add(Categories!.Find(A.Cat_Unlockable));
                item!.IsClosed = true;
                item!.IsLocked = true;
                if (searchCounter && item.GetStatus(CA!.iStatus_Counter_Door) != -1)
                {
                    Item? item2 = Items!.Find(item.GetStatus(CA!.iStatus_Counter_Door));
                    LockedDoorSwitchToLocked(item2, false);
                }
            }
        }

        public void CounterDoorInit(Item? item, int ItemID)
        {
            item!.SetStatus(CA!.iStatus_Counter_Door, ItemID);
            item!.SetStatus(CA!.iStatus_Locked, 0);
        }

        public void CounterDoorOpen(Item? item)
        {
            if (item!.GetStatus(CA!.iStatus_Locked!) != -1 && item.GetStatus(CA!.iStatus_Counter_Door) != -1)
            {
                Item? item2 = Items!.Find(item.GetStatus(CA!.iStatus_Counter_Door));
                if ((item2!.IsClosed) && (item2.CanBeClosed) && (item2!.IsLocked == false))
                {
                    StoryOutput(item2.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Adv_CounterDoorOpen_Person_Everyone_5709, item2.ID ));
                    item2.IsClosed = false;
                }
            }
        }

        public void CounterDoorClose(Item? item)
        {
            if (item!.GetStatus(CA!.iStatus_Locked) != -1 && item!.GetStatus(CA!.iStatus_Counter_Door) != -1)
            {
                Item? item2 = Items!.Find(item.GetStatus(CA!.iStatus_Counter_Door));
                if ((!item2!.IsClosed) && (item2!.CanBeClosed))
                {
                    StoryOutput(item2!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Adv_CounterDoorClose_Person_Everyone_5710, item2!.ID ));
                    item2!.IsClosed = true;
                }
            }
        }
    }




    [Serializable]

    public class CoAdv
    {

        public Verb? Verb_Enlight;
        public Verb? Verb_Spread;
        public Verb? Verb_Fixate;

        public Verb? Verb_Story;
        public Verb? Verb_Script;
        public Verb? Verb_Undo;
        public Verb? Verb_Verb_W;

        public Verb? Verb_Throw;

        public Verb? Verb_Brief;

        public Verb? Verb_Verbose;

        public Verb? Verb_PV_Up;

        public Verb? Verb_PV_Down;

        public Verb? Verb_Testwindow;

        public Verb? Verb_Phone;

        public Verb? Verb_Draw;

        public Verb? Verb_Push;

        public Verb? Verb_Push_To;

        public Verb? Verb_Read;

        public Verb? Verb_Untighten;

        public Verb? Verb_Break;

        public Verb? Verb_Cut;

        public Verb? Verb_Form;

        public Verb? Verb_Tie;

        public Verb? Verb_Fish;

        public Verb? Verb_Light;

        public Verb? Verb_Extinguish;

        public Verb? Verb_Grab;

        public Verb? Verb_Eat;

        public Verb? Verb_Sell;

        public Verb? Verb_Fill;

        public Verb? Verb_Stuff;

        public Verb? Verb_Pick;

        public Verb? Verb_Catch;

        public Verb? Verb_Drink;

        public Verb? Verb_Touch;

        public Verb? Verb_Knock;

        public Verb? Verb_Spit;

        public Verb? Verb_Listen;

        public Verb? Verb_Attach;
        public Verb? Verb_Attach2;
        public Verb? Verb_Play;
        public Verb? Verb_Phoneyvision;
        public Verb? Verb_Realitaet;

        public Verb? Verb_Hang;

        public Verb? Verb_Dip;

        public Verb? Verb_Tip;

        public Verb? Verb_Water;

        public Verb? Verb_Arrest;

        public Verb? Verb_Meditate;

        public Verb? Verb_Press;

        public Verb? Verb_Puncture;

        public Verb? Verb_Photograph;

        public Verb? Verb_Mount;

        public Verb? Verb_Saw;

        public Verb? Verb_Smear;

        public Verb? Verb_Smear2;

        public Verb? Verb_Blow;

        public Verb? Verb_Poison;

        public Verb? Verb_Compare;

        public Verb? Verb_Creep;

        public Verb? Verb_Follow;

        public Verb? Verb_Jump;

        public Verb? Verb_Turn;

        public Verb? Verb_Mix;

        public Verb? Verb_Pluck;

        public Verb? Verb_Suck;

        public Verb? Verb_Sit;

        public Verb? Verb_Exchange;

        public Verb? Verb_Untie;
        public Verb? Verb_Abandon;

        public Verb? Verb_Bind;

        public Verb? Verb_Free;

        public Verb? Verb_Hold;

        public Verb? Verb_Pinch;

        public Verb? Verb_Bury;

        public Verb? Verb_Bumse;

        public Verb? Verb_Toete;

        public Verb? Verb_Schlage;

        public Verb? Verb_Kitzle;

        public Verb? Verb_Kuschle;

        public Verb? Verb_Streichle;

        public Verb? Verb_Joggle;

        public Verb? Verb_Sleep;

        public Verb? Verb_Spark;

        public Verb? Verb_Leave;

        public Verb? Verb_Determine;

        public Verb? Verb_Remove;

        public Verb? Verb_Clean;
        public Verb? Verb_Soil;

        public Verb? Verb_Wash;

        public Verb? Verb_Split;

        public Verb? Verb_Fry;

        public Verb? Verb_Wrap;

        public Verb? Verb_Paint;

        public Verb? Verb_Wear;

        public Verb? Verb_Search;

        public Verb? Verb_Poke;

        public Verb? Verb_Dig;

        public Verb? Verb_Wake;

        public Verb? Verb_Shout;

        public Verb? Verb_Search2;

        public Verb? Verb_Leave2;

        public Verb? Verb_Slide;

        public Verb? Verb_Attack;


        public Verb? Verb_Accede;

        public Verb? Verb_Be;
        public Verb? Verb_Swim;
        public Verb? Verb_Kick;

        public Verb? Verb_Repair;

        public Verb? Verb_Sort;


        public Verb? Verb_Confess;

        public Verb? Verb_Sroke;

        public Verb? Verb_Switch;

        public Verb? Verb_Score;

        public Verb? Verb_Steal;

        public Verb? Verb_Exits;

        public Verb? Verb_Stroke;

        public Verb? Verb_Lift;

        public Verb? Verb_Wipe;


        public Verb? Verb_Move;

        public Verb? Verb_Destroy;

        public Verb? Verb_Chop;

        public Verb? Verb_Plunge;

        public Verb? Verb_Roll;

        public Verb? Verb_Demolish;

        public Verb? Verb_Crack;

        public Verb? Verb_Glue;

        public Verb? Verb_Heat;

        public Verb? Verb_Pulverize;

        public Verb? Verb_Tidy;

        public Verb? Verb_Brush;


        public Verb? Verb_Type;

        public Verb? Verb_Dance;

        public Verb? Verb_Swing;

        public Verb? Verb_Store;

        public Verb? Verb_Sing;

        public Verb? Verb_Lick;

        public Verb? Verb_Hide;

        public Verb? Verb_Tear;

        public Verb? Verb_Rip;

        public Verb? Verb_Burn;

        public Verb? Verb_Smoke;

        public Verb? Verb_Lay;

        public Verb? Verb_Crumble;

        public Verb? Verb_Let;

        public Verb? Verb_Kiss;

        public Verb? Verb_Credits;

        public Verb? Verb_Pray;

        public Verb? Verb_Bend;

        public Verb? Verb_Scroll;

        public Verb? Verb_Leverage;

        public Verb? Verb_Count;

        public Verb? Verb_Make;

        public Verb? Verb_Breath;

        public Verb? Verb_Spray;

        public Verb? Verb_Illustration;
        public Verb? Verb_Unlock;
        public Verb? Verb_Lock;


        // Neu Verb

        // Neue Adjs
        public Adj? Adj_ausgestopft;
        public Adj? Adj_beschrieben;
        public Adj? Adj_besonders;
        public Adj? Adj_gekuehlt;
        public Adj? Adj_hasserfuellt;
        public Adj? Adj_instabil;
        public Adj? Adj_lichtlos;
        public Adj? Adj_magisch;
        public Adj? Adj_mueffelnd;
        public Adj? Adj_neblig;
        public Adj? Adj_peinlich;
        public Adj? Adj_schimmernd;
        public Adj? Adj_sinister;
        public Adj? Adj_stattlich;
        public Adj? Adj_verrueckt;
        public Adj? Adj_vertrocknet;


        public Adj? Adj_magic;

        public Adj? Adj_organic;
        public Adj? Adj_stark;

        public Adj? Adj_reissfest;

        public Adj? Adj_gruen;

        public Adj? Adj_gross;

        public Adj? Adj_rot;

        public Adj? Adj_klein;

        public Adj? Adj_mittel;

        public Adj? Adj_allwissend;

        public Adj? Adj_rostig;

        public Adj? Adj_gigantisch;

        public Adj? Adj_heftig;

        public Adj? Adj_atemberaubend;

        public Adj? Adj_veraltet;

        public Adj? Adj_vergammelt;

        public Adj? Adj_gewoehnlich;

        public Adj? Adj_vergilbt;

        public Adj? Adj_zerrissen;

        public Adj? Adj_kaputt;

        public Adj? Adj_dreckig;

        public Adj? Adj_verschlossen;

        public Adj? Adj_breit;

        public Adj? Adj_marode;

        public Adj? Adj_klapprig;

        public Adj? Adj_fein;

        public Adj? Adj_ausgeblichen;

        public Adj? Adj_wahnsinnig;

        public Adj? Adj_irre;

        public Adj? Adj_bekloppt;

        public Adj? Adj_dicht;

        public Adj? Adj_graviert;

        public Adj? Adj_hoch;

        public Adj? Adj_kurz;

        public Adj? Adj_weit;

        public Adj? Adj_formschoen;

        public Adj? Adj_biegsam;

        public Adj? Adj_einfach;

        public Adj? Adj_prachtvoll;

        public Adj? Adj_tief;

        public Adj? Adj_stumpf;

        public Adj? Adj_bunt;

        public Adj? Adj_lang;

        public Adj? Adj_stabil;

        public Adj? Adj_schaebig;

        public Adj? Adj_schuechtern;

        public Adj? Adj_knurrig;

        public Adj? Adj_heruntergekommen;

        public Adj? Adj_grimmig;

        public Adj? Adj_braun;

        public Adj? Adj_alt;

        public Adj? Adj_offen;

        public Adj? Adj_primitiv;

        public Adj? Adj_gefaehrlich;

        public Adj? Adj_schmuddelig;

        public Adj? Adj_wackelig;

        public Adj? Adj_modrig;

        public Adj? Adj_niedrig;

        public Adj? Adj_schmal;

        public Adj? Adj_herumliegend;

        public Adj? Adj_lecker;

        public Adj? Adj_zerbrochen;

        public Adj? Adj_robust;

        public Adj? Adj_wabernd;

        public Adj? Adj_herumstehend;

        public Adj? Adj_schwach;

        public Adj? Adj_gepflueckt;

        public Adj? Adj_betrunken;

        public Adj? Adj_fesch;

        public Adj? Adj_unfesch;

        public Adj? Adj_steif;

        public Adj? Adj_verwittert;

        public Adj? Adj_eifrig;

        public Adj? Adj_druckfrisch;

        public Adj? Adj_schwer;

        public Adj? Adj_uneben;

        public Adj? Adj_finster;

        public Adj? Adj_stolz;

        public Adj? Adj_spitz;

        public Adj? Adj_gescheckt;

        public Adj? Adj_oelverschmiert;

        public Adj? Adj_windig;

        public Adj? Adj_unscheinbar;

        public Adj? Adj_glaenzend;

        public Adj? Adj_rustikal;

        public Adj? Adj_solide;

        public Adj? Adj_schlaefrig;

        public Adj? Adj_feurig;

        public Adj? Adj_albern;

        public Adj? Adj_ausgebleicht;

        public Adj? Adj_blutig;

        public Adj? Adj_dunkel;

        public Adj? Adj_farbig;

        public Adj? Adj_frisch;

        public Adj? Adj_gebacken;

        public Adj? Adj_getunkt;

        public Adj? Adj_gezinkt;

        public Adj? Adj_glaslos;

        public Adj? Adj_haesslich;

        public Adj? Adj_leer;

        public Adj? Adj_plump;

        public Adj? Adj_reisserisch;

        public Adj? Adj_schief;

        public Adj? Adj_schmutzig;

        public Adj? Adj_unterbelichtet;

        public Adj? Adj_ueberbelichtet;

        public Adj? Adj_ueppig;

        public Adj? Adj_unscharf;

        public Adj? Adj_vergiftet;

        public Adj? Adj_verschmiert;

        public Adj? Adj_verwackelt;

        public Adj? Adj_verziert;

        public Adj? Adj_zerknittert;

        public Adj? Adj_zierlich;

        public Adj? Adj_blau;

        public Adj? Adj_gekachelt;
        public Adj? Adj_episch;

        public Adj? Adj_erlogen;

        public Adj? Adj_heimtueckisch;

        public Adj? Adj_herrenlos;

        public Adj? Adj_lachhaft;

        public Adj? Adj_loechrig;

        public Adj? Adj_niedertraechtig;

        public Adj? Adj_zerfleddert;

        public Adj? Adj_oval;

        public Adj? Adj_schaendlich;

        public Adj? Adj_scharfkantig;

        public Adj? Adj_subversiv;

        public Adj? Adj_suspekt;

        public Adj? Adj_verbloedet;

        public Adj? Adj_verbogen;

        public Adj? Adj_zerkratzt;

        public Adj? Adj_verraeterisch;

        public Adj? Adj_wuselnd;

        public Adj? Adj_zerknickt;

        public Adj? Adj_durchsichtig;

        public Adj? Adj_edel;

        public Adj? Adj_fettig;

        public Adj? Adj_gebraten;

        public Adj? Adj_gefuellt;

        public Adj? Adj_geifernd;

        public Adj? Adj_handlich;

        public Adj? Adj_hoffnungsfroh;

        public Adj? Adj_klebrig;

        public Adj? Adj_lebhaft;

        public Adj? Adj_lesbar;

        public Adj? Adj_maechtig;

        public Adj? Adj_modisch;

        public Adj? Adj_roh;

        public Adj? Adj_tot;

        public Adj? Adj_unbedruckt;

        public Adj? Adj_verdammungswuerdig;

        public Adj? Adj_verlogen;

        public Adj? Adj_verschlammt;

        public Adj? Adj_versifft;

        public Adj? Adj_stinkend;

        public Adj? Adj_hoelzern;

        public Adj? Adj_aufgeblasen;

        public Adj? Adj_bewusstlos;

        public Adj? Adj_esoterisch;

        public Adj? Adj_extragross;

        public Adj? Adj_falsch;

        public Adj? Adj_gekritzelt;

        public Adj? Adj_gerieben;

        public Adj? Adj_gluehend;

        public Adj? Adj_offiziell;

        public Adj? Adj_schmierig;

        public Adj? Adj_stachlig;

        public Adj? Adj_verwesend;

        public Adj? Adj_wuchtig;

        public Adj? Adj_fragwuerdig;

        public Adj? Adj_leichenblass;

        public Adj? Adj_schimmlig;

        public Adj? Adj_abgeranzt;

        public Adj? Adj_baufaellig;

        public Adj? Adj_steinern;

        public Adj? Adj_verrusst;

        public Adj? Adj_grob;

        public Adj? Adj_dick;

        public Adj? Adj_weitlaeufig;

        public Adj? Adj_trueb;

        public Adj? Adj_abgewetzt;

        public Adj? Adj_antiquiert;

        public Adj? Adj_eklig;

        public Adj? Adj_feucht;

        public Adj? Adj_getrocknet;

        public Adj? Adj_nutzlos;

        public Adj? Adj_ausgedehnt;

        public Adj? Adj_wundervoll;

        public Adj? Adj_paradiesisch;

        public Adj? Adj_ausladend;

        public Adj? Adj_kitschig;

        public Adj? Adj_klobig;

        public Adj? Adj_klotzig;

        public Adj? Adj_opulent;

        public Adj? Adj_verdaechtig;

        public Adj? Adj_winzig;

        public Adj? Adj_fett;

        public Adj? Adj_steil;

        public Adj? Adj_adrett;

        public Adj? Adj_zerschlissen;

        public Adj? Adj_plueschig;

        public Adj? Adj_golden;

        public Adj? Adj_gekalkt;

        public Adj? Adj_abscheulich;

        public Adj? Adj_duenn;

        public Adj? Adj_religioes;

        public Adj? Adj_zahlreich;

        public Adj? Adj_morsch;

        public Adj? Adj_gesplittert;

        public Adj? Adj_glatt;

        public Adj? Adj_superglatt;

        public Adj? Adj_fleckig;

        public Adj? Adj_ehrwuerdig;

        public Adj? Adj_links;

        public Adj? Adj_rechts;

        public Adj? Adj_feudal;

        public Adj? Adj_ledern;

        public Adj? Adj_riesig;

        public Adj? Adj_glitzernd;

        public Adj? Adj_metallen;

        public Adj? Adj_poliert;

        public Adj? Adj_modern;

        public Adj? Adj_malerisch;

        public Adj? Adj_imposant;

        public Adj? Adj_hochaufragend;

        public Adj? Adj_knorrig;

        public Adj? Adj_verfallen;

        public Adj? Adj_windschief;

        public Adj? Adj_wuchernd;

        public Adj? Adj_flimmernd;

        public Adj? Adj_mobil;

        public Adj? Adj_monstroes;

        public Adj? Adj_schwarz;

        public Adj? Adj_herausgeputzt;

        public Adj? Adj_staubig;

        public Adj? Adj_uebel;

        public Adj? Adj_duftend;

        public Adj? Adj_juwelenbesetzt;

        public Adj? Adj_emsig;

        public Adj? Adj_weiss;

        public Adj? Adj_laenglich;

        public Adj? Adj_teuer;

        public Adj? Adj_dunstig;

        public Adj? Adj_rund;

        public Adj? Adj_versoffen;

        public Adj? Adj_wacklig;

        public Adj? Adj_geschmackvoll;

        public Adj? Adj_langgezogen;

        public Adj? Adj_hoffnungslos;

        public Adj? Adj_unbefestigt;

        public Adj? Adj_altbacken;

        public Adj? Adj_angezeichnet;

        public Adj? Adj_jaemmerlich;

        public Adj? Adj_farbenfroh;

        public Adj? Adj_seltsam;

        public Adj? Adj_auffaellig;

        public Adj? Adj_ungewoehnlich;

        public Adj? Adj_ueberdimensioniert;

        public Adj? Adj_befestigt;

        public Adj? Adj_abgegrast;

        public Adj? Adj_ausgemergelt;

        public Adj? Adj_guelden;

        public Adj? Adj_hochkaraetig;

        public Adj? Adj_unheimlich;

        public Adj? Adj_bescheiden;

        public Adj? Adj_trunksuechtig;

        public Adj? Adj_festgetrampelt;

        public Adj? Adj_tanzend;

        public Adj? Adj_exotisch;

        public Adj? Adj_erstaunlich;

        public Adj? Adj_funkelnd;

        public Adj? Adj_zahllos;

        public Adj? Adj_obskur;

        public Adj? Adj_geflochten;

        public Adj? Adj_schneebedeckt;

        public Adj? Adj_monumental;

        public Adj? Adj_vierspurig;

        public Adj? Adj_voll;

        public Adj? Adj_verwildert;

        public Adj? Adj_gemauert;

        public Adj? Adj_ueberschaubar;

        public Adj? Adj_kaufwuetig;

        public Adj? Adj_strahlend;

        public Adj? Adj_gleissend;

        public Adj? Adj_mondaen;

        public Adj? Adj_verhaermt;

        public Adj? Adj_knoecheltief;

        public Adj? Adj_sumpfig;

        public Adj? Adj_unstet;

        public Adj? Adj_heruntergewirtschaftet;

        public Adj? Adj_matschig;

        public Adj? Adj_vertikal;

        public Adj? Adj_jung;

        public Adj? Adj_geschwaetzig;

        public Adj? Adj_idyllisch;

        public Adj? Adj_reif;

        public Adj? Adj_ueberwuchert;

        public Adj? Adj_hochgewachsen;

        public Adj? Adj_altmodisch;

        public Adj? Adj_verkalkt;

        public Adj? Adj_fromm;

        public Adj? Adj_eng;

        public Adj? Adj_schmucklos;

        public Adj? Adj_langweilig;

        public Adj? Adj_karg;

        public Adj? Adj_ueberfluessig;

        public Adj? Adj_hell;

        public Adj? Adj_kaerglich;

        public Adj? Adj_gepflegt;

        public Adj? Adj_alkoholisiert;

        public Adj? Adj_gluecklich;

        public Adj? Adj_saftig;

        public Adj? Adj_majestaetisch;

        public Adj? Adj_unertraeglich;

        public Adj? Adj_gruselig;

        public Adj? Adj_tonnenschwer;

        public Adj? Adj_futuristisch;

        public Adj? Adj_beleuchtet;

        public Adj? Adj_verfuehrerisch;

        public Adj? Adj_guenstig;

        public Adj? Adj_glattpoliert;

        public Adj? Adj_hinterlistig;

        public Adj? Adj_hoffnungsvoll;

        public Adj? Adj_leicht;

        public Adj? Adj_massiv;

        public Adj? Adj_luftig;

        public Adj? Adj_knietief;

        public Adj? Adj_protzig;

        public Adj? Adj_wohlhabend;

        public Adj? Adj_nagelneu;

        public Adj? Adj_grossflaechig;

        public Adj? Adj_angrenzend;

        public Adj? Adj_drehbar;

        public Adj? Adj_hochmodern;

        public Adj? Adj_begehbar;

        public Adj? Adj_halbfertig;

        public Adj? Adj_geraeumig;

        public Adj? Adj_lose;

        public Adj? Adj_brennend;

        public Adj? Adj_geschunden;

        public Adj? Adj_bruechig;

        public Adj? Adj_elektrisch;

        public Adj? Adj_zuckend;

        public Adj? Adj_satanisch;

        public Adj? Adj_duester;

        public Adj? Adj_rabenschwarz;

        public Adj? Adj_verderbt;

        public Adj? Adj_wichtig;

        public Adj? Adj_massenhaft;

        public Adj? Adj_schwimmend;

        public Adj? Adj_verkohlt;

        public Adj? Adj_teuflisch;

        public Adj? Adj_knochenbesetzt;

        public Adj? Adj_lodernd;

        public Adj? Adj_schwebend;

        public Adj? Adj_knallrot;

        public Adj? Adj_kohlrabenschwarz;

        public Adj? Adj_glaesern;

        public Adj? Adj_beschmiert;

        public Adj? Adj_dampfend;

        public Adj? Adj_schimmelnd;

        public Adj? Adj_verwerflich;

        public Adj? Adj_daemonisch;

        public Adj? Adj_herabhaengend;

        public Adj? Adj_ueberquellend;

        public Adj? Adj_obszoen;

        public Adj? Adj_ansehnlich;

        public Adj? Adj_trostlos;

        public Adj? Adj_knochenfarben;

        public Adj? Adj_okkult;

        public Adj? Adj_angekokelt;

        public Adj? Adj_steinig;

        public Adj? Adj_verrucht;

        public Adj? Adj_bleich;

        public Adj? Adj_suendig;

        public Adj? Adj_gelb;

        public Adj? Adj_lila;

        public Adj? Adj_weinrot;

        public Adj? Adj_prall;

        public Adj? Adj_erlesen;

        public Adj? Adj_zertrampelt;

        public Adj? Adj_traumatisiert;

        public Adj? Adj_locker;

        public Adj? Adj_baumelnd;

        public Adj? Adj_wild;

        public Adj? Adj_feiernd;

        public Adj? Adj_unreif;

        public Adj? Adj_orange;

        public Adj? Adj_extrastark;

        public Adj? Adj_angekettet;

        public Adj? Adj_glimmend;

        public Adj? Adj_froehlich;

        public Adj? Adj_geladen;

        public Adj? Adj_verrottet;

        public Adj? Adj_kuemmerlich;

        public Adj? Adj_blutrot;

        public Adj? Adj_knoechern;

        public Adj? Adj_guetig;

        public Adj? Adj_verzweifelt;

        public Adj? Adj_ungluecklich;

        public Adj? Adj_misstrauisch;

        public Adj? Adj_vorsichtig;

        public Adj? Adj_anerkennend;

        public Adj? Adj_beilaeufig;

        public Adj? Adj_empoert;

        public Adj? Adj_ergriffen;

        public Adj? Adj_hinterhaeltig;

        public Adj? Adj_lauernd;

        public Adj? Adj_mitleidig;

        public Adj? Adj_sabbernd;

        public Adj? Adj_suesslich;

        public Adj? Adj_geoeffnet;

        public Adj? Adj_spriessend;

        public Adj? Adj_grossspurig;

        public Adj? Adj_kleinlaut;

        public Adj? Adj_nachdenklich;

        public Adj? Adj_triumphierend;

        public Adj? Adj_eifernd;

        public Adj? Adj_entschlossen;

        public Adj? Adj_entsetzt;

        public Adj? Adj_enttaeuscht;

        public Adj? Adj_entzueckt;

        public Adj? Adj_erregt;

        public Adj? Adj_fassungslos;

        public Adj? Adj_genervt;

        public Adj? Adj_geruehrt;

        public Adj? Adj_grossmuetig;

        public Adj? Adj_vorwurfsvoll;

        public Adj? Adj_aufgebracht;

        public Adj? Adj_bedeutungsschwer;

        public Adj? Adj_entnervt;

        public Adj? Adj_zerknirscht;

        public Adj? Adj_erschrocken;

        public Adj? Adj_gelassen;

        public Adj? Adj_gierig;

        public Adj? Adj_gleichgueltig;

        public Adj? Adj_hungrig;

        public Adj? Adj_resigniert;

        public Adj? Adj_ueberrascht;

        public Adj? Adj_verstaendnisvoll;

        public Adj? Adj_gewagt;

        public Adj? Adj_verstoerend;

        public Adj? Adj_verwegen;

        public Adj? Adj_bizarr;

        public Adj? Adj_bedauernd;

        public Adj? Adj_beunruhigt;

        public Adj? Adj_gelangweilt;

        public Adj? Adj_herablassend;

        public Adj? Adj_irritiert;

        public Adj? Adj_listig;

        public Adj? Adj_nachdruecklich;

        public Adj? Adj_spoettisch;

        public Adj? Adj_stur;

        public Adj? Adj_verunsichert;

        public Adj? Adj_divin;

        public Adj? Adj_niedlich;

        public Adj? Adj_abgedreht;

        public Adj? Adj_aufgeregt;

        public Adj? Adj_erstaunt;

        public Adj? Adj_hilfsbereit;

        public Adj? Adj_leichthin;

        public Adj? Adj_neugierig;

        public Adj? Adj_sueffisant;

        public Adj? Adj_verbittert;

        public Adj? Adj_weinerlich;

        public Adj? Adj_ungehalten;

        public Adj? Adj_bedrohlich;

        public Adj? Adj_belehrend;

        public Adj? Adj_bewundernd;

        public Adj? Adj_hypothetisch;

        public Adj? Adj_grinsend;

        public Adj? Adj_gruebelnd;

        public Adj? Adj_erfreut;

        public Adj? Adj_weihevoll;

        public Adj? Adj_hypnotisch;

        public Adj? Adj_aechzend;

        public Adj? Adj_beglueckt;

        public Adj? Adj_blechern;

        public Adj? Adj_verwundert;


        public Adj? Adj_angewidert;

        public Adj? Adj_anklagend;

        public Adj? Adj_betroffen;

        public Adj? Adj_diplomatisch;

        public Adj? Adj_ehrlich;

        public Adj? Adj_feierlich;

        public Adj? Adj_giftig;

        public Adj? Adj_hastig;

        public Adj? Adj_schnaubend;

        public Adj? Adj_selbstgefaellig;

        public Adj? Adj_seufzend;

        public Adj? Adj_superschlau;

        public Adj? Adj_verwirrt;

        public Adj? Adj_zerstreut;

        public Adj? Adj_hoellisch;

        public Adj? Adj_toedlich;

        public Adj? Adj_begeistert;

        public Adj? Adj_leise;

        public Adj? Adj_skeptisch;

        public Adj? Adj_besorgt;

        public Adj? Adj_betruebt;

        public Adj? Adj_zweifelnd;

        public Adj? Adj_enthusiastisch;

        public Adj? Adj_klappernd;

        public Adj? Adj_boesartig;

        public Adj? Adj_zusammenfassend;

        public Adj? Adj_zuversichtlich;

        public Adj? Adj_ablehnend;

        public Adj? Adj_deprimiert;

        public Adj? Adj_erschuettert;

        public Adj? Adj_gaehnend;

        public Adj? Adj_geheimnisvoll;

        public Adj? Adj_sinnierend;

        public Adj? Adj_stoehnend;

        public Adj? Adj_streng;

        public Adj? Adj_ueberschaeumend;

        public Adj? Adj_verbluefft;


        public Adj? Adj_harsch;

        public Adj? Adj_missbilligend;

        public Adj? Adj_tapfer;

        public Adj? Adj_abwehrend;

        public Adj? Adj_beschwichtigend;

        public Adj? Adj_energisch;

        public Adj? Adj_gequaelt;

        public Adj? Adj_gestresst;

        public Adj? Adj_traurig;

        public Adj? Adj_ungeduldig;

        public Adj? Adj_verstaendnislos;

        public Adj? Adj_zwinkernd;


        public Adj? Adj_flehend;

        public Adj? Adj_gebrochen;

        public Adj? Adj_leidend;

        public Adj? Adj_zuvorkommend;

        public Adj? Adj_euphorisch;

        public Adj? Adj_reserviert;

        public Adj? Adj_verschlagen;

        public Adj? Adj_mitfuehlend;

        public Adj? Adj_selbstmitleidig;

        public Adj? Adj_unbehaglich;

        public Adj? Adj_entruestet;


        public Adj? Adj_selbstbewusst;

        public Adj? Adj_sehnsuchtsvoll;

        public Adj? Adj_erschoepft;

        public Adj? Adj_grosszuegig;


        public Adj? Adj_grummelnd;

        public Adj? Adj_hektisch;

        public Adj? Adj_hoehnisch;

        public Adj? Adj_schaeumend;

        public Adj? Adj_schnittig;

        public Adj? Adj_untertaenig;


        public Adj? Adj_veraergert;

        public Adj? Adj_verzueckt;

        public Adj? Adj_blasiert;

        public Adj? Adj_ehrfuerchtig;

        public Adj? Adj_eitel;

        public Adj? Adj_nervoes;

        public Adj? Adj_schmunzelnd;

        public Adj? Adj_schweissabwischend;

        public Adj? Adj_gertenschlank;

        public Adj? Adj_saeuselnd;

        public Adj? Adj_ueberschnappend;

        public Adj? Adj_wuetend;


        public Adj? Adj_arglos;

        public Adj? Adj_argwoehnisch;

        public Adj? Adj_atemlos;

        public Adj? Adj_aufmunternd;

        public Adj? Adj_entspannt;

        public Adj? Adj_geschaeftig;

        public Adj? Adj_herausfordernd;

        public Adj? Adj_hysterisch;

        public Adj? Adj_hypnotisiert;

        public Adj? Adj_sauer;

        public Adj? Adj_scheinheilig;

        public Adj? Adj_ueberzeugt;

        public Adj? Adj_unglaeubig;

        public Adj? Adj_keifen;

        public Adj? Adj_schwaermen;

        public Adj? Adj_versonnen;

        public Adj? Adj_stachlig2;

        public Adj? Adj_alarmiert;

        public Adj? Adj_beaengstigt;

        public Adj? Adj_bestuerzt;

        public Adj? Adj_erbost;

        public Adj? Adj_heiser;

        public Adj? Adj_schnappatmend;

        public Adj? Adj_seelenruhig;

        public Adj? Adj_schnaufend;

        public Adj? Adj_tadelnd;


        public Adj? Adj_unsicher;

        public Adj? Adj_brutal;

        public Adj? Adj_ermunternd;

        public Adj? Adj_freudig;

        public Adj? Adj_gackernd;

        public Adj? Adj_geschlagen;

        public Adj? Adj_ruhig;

        public Adj? Adj_unbeeindruckt;

        public Adj? Adj_verlegen;

        public Adj? Adj_verschaemt;

        public Adj? Adj_gehaessig;


        public Adj? Adj_abwesend;

        public Adj? Adj_luftschnappend;

        public Adj? Adj_panisch;

        public Adj? Adj_verdriesslich;


        public Adj? Adj_augenzwinkernd;

        public Adj? Adj_befremdet;

        public Adj? Adj_jovial;

        public Adj? Adj_schluchzend;

        public Adj? Adj_schwaermerisch;

        public Adj? Adj_zoegerlich;


        public Adj? Adj_eisig;

        public Adj? Adj_gereizt;


        public Adj? Adj_erroetend;

        public Adj? Adj_verschnupft;


        public Adj? Adj_stoned;

        public Adj? Adj_zackig;

        public Adj? Adj_westlich;

        public Adj? Adj_oestlich;

        public Adj? Adj_heruntergelassen;

        public Adj? Adj_elegant;

        public Adj? Adj_pathetisch;

        public Adj? Adj_samten;

        public Adj? Adj_notorisch;

        public Adj? Adj_fern;

        public Adj? Adj_erhaben;

        public Adj? Adj_blaesslich;

        public Adj? Adj_gewienert;

        public Adj? Adj_gesaeubert;
        public Adj? Adj_eisern;
        public Adj? Adj_bio;
        public Adj? Adj_super;
        public Adj? Adj_bedeutungslos;
        public Adj? Adj_panoramisch;
        public Adj? Adj_neu;
        public Adj? Adj_extra;
        public Adj? Adj_registriert;
        public Adj? Adj_ruiniert;

        // Neu Adj

        public Noun? Noun_Seil;

        public Noun? Noun_Revolver; 

        public Noun? Noun_Kiste;

        public Noun? Noun_Kram;

        public Noun? Noun_Sonderangebote;

        public Noun? Noun_Sonderangebot;

        public Noun? Noun_Angebote;

        public Noun? Noun_Angebot;


        public Noun? Noun_Schluessel;

        public Noun? Noun_Schachtel;

        public Noun? Noun_Baumstumpf;

        public Noun? Noun_Du;

        public Noun? Noun_Ich;

        public Noun? Noun_Helfie;

        public Noun? Noun_Helfer;

        public Noun? Noun_Robi;

        public Noun? Noun_Robot;

        public Noun? Noun_Truhe;

        public Noun? Noun_Schatztruhe;

        public Noun? Noun_Weltfrieden;

        public Noun? Noun_Krieg;

        public Noun? Noun_Tasche;
        public Noun? Noun_Dome;

        public Noun? Noun_Pocket;
        public Noun? Noun_Trader;
        public Noun? Noun_Dealer;
        public Noun? Noun_Bag;
        public Noun? Noun_Hamberder;

        public Noun? Noun_Hamburger;

        public Noun? Noun_Burger;

        public Noun? Noun_Golfball;

        public Noun? Noun_Buch;

        public Noun? Noun_Zeitungsausschnitt;

        public Noun? Noun_Basecap;

        public Noun? Noun_Vorhaenge;

        public Noun? Noun_Vorhang;

        public Noun? Noun_Moebel;

        public Noun? Noun_Moder;

        public Noun? Noun_Porzellan;

        public Noun? Noun_Fenster;

        public Noun? Noun_Eingangstuer;

        public Noun? Noun_Treppe;

        public Noun? Noun_Kellertreppe;

        public Noun? Noun_Gelaender;

        public Noun? Noun_Spiegel;

        public Noun? Noun_Zeitung;

        public Noun? Noun_Papier;

        public Noun? Noun_Ausschnitt;

        public Noun? Noun_Regal;

        public Noun? Noun_Manual;

        public Noun? Noun_Sand;

        public Noun? Noun_Muscheln;

        public Noun? Noun_Tuer;

        public Noun? Noun_Sandkoerner;

        public Noun? Noun_Sven;

        public Noun? Noun_Irrer;

        public Noun? Noun_Draht;

        public Noun? Noun_Meer;

        public Noun? Noun_Fahrstuhl;

        public Noun? Noun_Palme;

        public Noun? Noun_Schild;

        public Noun? Noun_Wald;

        public Noun? Noun_Kiesel;

        public Noun? Noun_Kieselstrand;

        public Noun? Noun_Strand;

        public Noun? Noun_Muschel;

        public Noun? Noun_Busch;

        public Noun? Noun_Decke;

        public Noun? Noun_Kaninchenhoehle;

        public Noun? Noun_Waldgras;

        public Noun? Noun_Wand;

        public Noun? Noun_Zweige;

        public Noun? Noun_Zweig;

        public Noun? Noun_Messer;

        public Noun? Noun_Gebuesch;

        public Noun? Noun_Papagei;

        public Noun? Noun_Stock;

        public Noun? Noun_Ast;

        public Noun? Noun_Erdhuegel;

        public Noun? Noun_Ameisenhaufen;

        public Noun? Noun_Brombeerstraeucher;

        public Noun? Noun_Straeucher;

        public Noun? Noun_Strauch;

        public Noun? Noun_Verschlag;

        public Noun? Noun_Huette;

        public Noun? Noun_Eremit;

        public Noun? Noun_Eimerchen;

        public Noun? Noun_Keller;

        public Noun? Noun_Seildraht;

        public Noun? Noun_Kobra;

        public Noun? Noun_Haselstrauch;

        public Noun? Noun_Gras;

        public Noun? Noun_Astseil;

        public Noun? Noun_Fishing;

        public Noun? Noun_Angel;

        public Noun? Noun_Gewandtasche;

        public Noun? Noun_Boden;

        public Noun? Noun_Bodendielen;

        public Noun? Noun_Cracker;
        public Noun? Noun_Crackers;

        public Noun? Noun_Crackerschachtel;

        public Noun? Noun_Dielen;

        public Noun? Noun_Grillzange;

        public Noun? Noun_Herd;

        public Noun? Noun_Kaefig;

        public Noun? Noun_Keks;

        public Noun? Noun_Lampe;

        public Noun? Noun_Laterne;

        public Noun? Noun_Ritz;

        public Noun? Noun_Schachtel_mit_Crackern;

        public Noun? Noun_Schrank;
        public Noun? Noun_Kuechenschrank;

        public Noun? Noun_Akten;

        public Noun? Noun_Zelle;

        public Noun? Noun_Streichholzbriefchen;

        public Noun? Noun_Streichhoelzer;

        public Noun? Noun_Vogelbauer;

        public Noun? Noun_Cage;
        public Noun? Noun_Zange;

        public Noun? Noun_Vogelkaefig;

        public Noun? Noun_Eiche;

        public Noun? Noun_Fluestertuete;

        public Noun? Noun_Astgabel;

        public Noun? Noun_Megafon;

        public Noun? Noun_Bett;

        public Noun? Noun_Geruempel;

        public Noun? Noun_Tisch;

        public Noun? Noun_Stuhl;

        public Noun? Noun_Zauberspiegel;

        public Noun? Noun_Baeume;

        public Noun? Noun_Baum;

        public Noun? Noun_Bucht;

        public Noun? Noun_Felsen;

        public Noun? Noun_Fels;

        public Noun? Noun_Frank;

        public Noun? Noun_Cannon;

        public Noun? Noun_Brombeeren;

        public Noun? Noun_Truemmer;

        public Noun? Noun_Rad;

        public Noun? Noun_Kutsche;

        public Noun? Noun_Korn;

        public Noun? Noun_Achse;

        public Noun? Noun_Eimer;

        public Noun? Noun_Pfad;

        public Noun? Noun_Buschwerk;

        public Noun? Noun_Oberflaeche;

        public Noun? Noun_Kokosnuesse;

        public Noun? Noun_Kokosnuss;

        public Noun? Noun_Nuesse;

        public Noun? Noun_Nuss;

        public Noun? Noun_Licht;

        public Noun? Noun_Schimmer;

        public Noun? Noun_Lichtschimmer;

        public Noun? Noun_Stufe;

        public Noun? Noun_Stufen;

        public Noun? Noun_Ameise;

        public Noun? Noun_Ameisen;

        public Noun? Noun_Waldameise;

        public Noun? Noun_Waldameisen;

        public Noun? Noun_Senke;

        public Noun? Noun_Lagerverwalter;

        public Noun? Noun_Verwalter;

        public Noun? Noun_Lagerist;

        public Noun? Noun_Kapitaen;

        public Noun? Noun_Ahab;

        public Noun? Noun_Schankwirtin;

        public Noun? Noun_Wirtin;

        public Noun? Noun_Kneipenwirtin;

        public Noun? Noun_Luegian;

        public Noun? Noun_Speichelt;

        public Noun? Noun_Marineoffizier;

        public Noun? Noun_Offizier;

        public Noun? Noun_Redakteur;

        public Noun? Noun_Luegner;

        public Noun? Noun_Verleumder;

        public Noun? Noun_Pit;

        public Noun? Noun_Paula;

        public Noun? Noun_Paracelsus;

        public Noun? Noun_Arzt;

        public Noun? Noun_Aerztin;

        public Noun? Noun_Harpune;

        public Noun? Noun_Pflaster;

        public Noun? Noun_Pflasterstein;

        public Noun? Noun_Tor;

        public Noun? Noun_Bar;

        public Noun? Noun_Hafenbar;

        public Noun? Noun_Hafenkaschemme;

        public Noun? Noun_Hafenkneipe;

        public Noun? Noun_Hafenpinte;

        public Noun? Noun_Kaschemme;

        public Noun? Noun_Klohaeuschen;

        public Noun? Noun_Klopapier;

        public Noun? Noun_Presseausweis;

        public Noun? Noun_Kneipe;

        public Noun? Noun_Lagerhaus;
        public Noun? Noun_Lagerhaus_e;
        public Noun? Noun_Lagerhouse;

        public Noun? Noun_Pinte;

        public Noun? Noun_Schiff;

        public Noun? Noun_Verlag;

        public Noun? Noun_Haken;

        public Noun? Noun_Prospekt;

        public Noun? Noun_Kissen;

        public Noun? Noun_Badge;

        public Noun? Noun_Dennis;

        public Noun? Noun_Handelsvertreter;

        public Noun? Noun_Kuh;

        public Noun? Noun_Mechaniker;

        public Noun? Noun_Schraubenschluessel;

        public Noun? Noun_Waltraud;

        public Noun? Noun_Woods;

        public Noun? Noun_Bank;

        public Noun? Noun_Barhocker;

        public Noun? Noun_Druckmaschine;

        public Noun? Noun_Fensterbank;

        public Noun? Noun_Hahn;

        public Noun? Noun_Hocker;

        public Noun? Noun_Manuskript;

        public Noun? Noun_Papierausgabe;

        public Noun? Noun_Schreibmaschine;

        public Noun? Noun_Tresen;

        public Noun? Noun_Wagenheber;

        public Noun? Noun_Zapfhahn;

        public Noun? Noun_Handschellen;

        public Noun? Noun_Postbeamter;

        public Noun? Noun_Beamter;

        public Noun? Noun_Radfuehrung;

        public Noun? Noun_Radaufhaengung;

        public Noun? Noun_Pferd;

        public Noun? Noun_Formulare;

        public Noun? Noun_Ross;

        public Noun? Noun_Schalter;

        public Noun? Noun_Blumenkohl;

        public Noun? Noun_Blumenkohlgehirn;

        public Noun? Noun_Kohl;

        public Noun? Noun_Bogen;

        public Noun? Noun_Brief;

        public Noun? Noun_Briefumschlag;

        public Noun? Noun_Brille;
        public Noun? Noun_Frame;

        public Noun? Noun_Cocktailglas;

        public Noun? Noun_Dose;

        public Noun? Noun_Konserven;

        public Noun? Noun_Konserve;

        public Noun? Noun_Dosenoeffner;

        public Noun? Noun_Fleisch;

        public Noun? Noun_Hack;

        public Noun? Noun_Foto;

        public Noun? Noun_Gebiss;

        public Noun? Noun_Vampirgebiss;

        public Noun? Noun_Gehirn;

        public Noun? Noun_Giesskanne;

        public Noun? Noun_Drink;

        public Noun? Noun_Giftflakon;

        public Noun? Noun_Kamera;

        public Noun? Noun_Kaleidoskop;

        public Noun? Noun_Schatz;

        public Noun? Noun_Pracht;
        public Noun? Noun_Schlaftabletten;

        public Noun? Noun_Spielgeld;

        public Noun? Noun_Spielgeldbogen;

        public Noun? Noun_Stapel;

        public Noun? Noun_Ziegel;

        public Noun? Noun_Ziegelstein;

        public Noun? Noun_Schluesselbund;

        public Noun? Noun_Alfonsius_Statuette;

        public Noun? Noun_Briefe;

        public Noun? Noun_Cocktail;
        public Noun? Noun_Corona;

        public Noun? Noun_Dartscheibe;

        public Noun? Noun_Fass;

        public Noun? Noun_Fensterglas;

        public Noun? Noun_Fleischwanne;

        public Noun? Noun_Flugblaetter;

        public Noun? Noun_Getraenk;

        public Noun? Noun_Gutachten;

        public Noun? Noun_Hackfleisch;

        public Noun? Noun_Hose;

        public Noun? Noun_Karren;

        public Noun? Noun_Kelle;

        public Noun? Noun_Laubsaege;

        public Noun? Noun_Lieferschein;

        public Noun? Noun_Abholschein;

        public Noun? Noun_Postkarte;

        public Noun? Noun_Karte;

        public Noun? Noun_Regenwuermer;

        public Noun? Noun_Scherbe;

        public Noun? Noun_Senffaesschen;

        public Noun? Noun_Sinnspruch;

        public Noun? Noun_Statuette;

        public Noun? Noun_Taucheranzughose;

        public Noun? Noun_Umruehrstab;

        public Noun? Noun_stirring;
        public Noun? Noun_Zuckerpaeckchen;

        public Noun? Noun_Baconstreifen;

        public Noun? Noun_Bettbezug;

        public Noun? Noun_Felsbrocken;

        public Noun? Noun_Feudel;
        public Noun? Noun_Cloth;
        public Noun? Noun_Rag;

        public Noun? Noun_Feuerzeug;

        public Noun? Noun_Frischhaltefolie;

        public Noun? Noun_Gefaess;

        public Noun? Noun_Spachtelmasse;

        public Noun? Noun_Spachtel;

        public Noun? Noun_Masse;

        public Noun? Noun_Glas;

        public Noun? Noun_Brillenglas;

        public Noun? Noun_Hanfseil;

        public Noun? Noun_Hightech_Fessel;

        public Noun? Noun_Hightech;

        public Noun? Noun_Fessel;

        public Noun? Noun_Holzstueck;

        public Noun? Noun_Kanister;

        public Noun? Noun_Verduennung;
        public Noun? Noun_Oel;

        public Noun? Noun_Lotterielos;

        public Noun? Noun_Lotterie;

        public Noun? Noun_Megaphon;

        public Noun? Noun_Metallstueck;

        public Noun? Noun_Papierboegen;

        public Noun? Noun_Patties;

        public Noun? Noun_Stimme;

        public Noun? Noun_Pattie;

        public Noun? Noun_Permanentmarker;

        public Noun? Noun_Peruecke;

        public Noun? Noun_Phoney_Island_Gin;

        public Noun? Noun_Ratte;

        public Noun? Noun_Schaufelchen;

        public Noun? Noun_Schaukelpferd;

        public Noun? Noun_Schlauch;

        public Noun? Noun_Schuerze;

        public Noun? Noun_Sprengsatz;

        public Noun? Noun_Bombe;

        public Noun? Noun_Stein;

        public Noun? Noun_Steinschleuder;

        public Noun? Noun_Visitenkarte;

        public Noun? Noun_Zustellkarte;

        public Noun? Noun_Bart;

        public Noun? Noun_Berder_Kadaver;

        public Noun? Noun_Bescheinigung;

        public Noun? Noun_Blasebalg;

        public Noun? Noun_Schraube;

        public Noun? Noun_Botanikbuch;

        public Noun? Noun_Botanikbuecher;

        public Noun? Noun_Buessergewand;

        public Noun? Noun_Deborah;

        public Noun? Noun_Norma;

        public Noun? Noun_Fakes;

        public Noun? Noun_Harald;

        public Noun? Noun_Habicht;

        public Noun? Noun_Einschreiben;

        public Noun? Noun_Eisenstange;

        public Noun? Noun_Kartoffelsack;

        public Noun? Noun_Kette;

        public Noun? Noun_Kneifzange;

        public Noun? Noun_Knurznurznuss;

        public Noun? Noun_Kondome;

        public Noun? Noun_Kondom;

        public Noun? Noun_Praeser;

        public Noun? Noun_Luemmeltuete;

        public Noun? Noun_Luemmeltueten;

        public Noun? Noun_Leiche;

        public Noun? Noun_Lippenstift_Nachricht;

        public Noun? Noun_Mitteilung;

        public Noun? Noun_Peitschen;

        public Noun? Noun_Raupe;

        public Noun? Noun_Sack;

        public Noun? Noun_Schaufel;

        public Noun? Noun_Schlafmohn;

        public Noun? Noun_Schlommi;

        public Noun? Noun_Schloss;

        public Noun? Noun_Vorhaengeschloss;

        public Noun? Noun_Schraubenzieher;

        public Noun? Noun_Umschlag;

        public Noun? Noun_Zellenschluessel;

        public Noun? Noun_Nullbehaelter;

        public Noun? Noun_Ghoul;

        public Noun? Noun_Phoney;

        public Noun? Noun_Francesco;

        public Noun? Noun_Scaramango;

        public Noun? Noun_Messias;

        public Noun? Noun_Zellentuer;

        public Noun? Noun_Stroh;

        public Noun? Noun_Lager;

        public Noun? Noun_Schlaflager;

        public Noun? Noun_Wache;

        public Noun? Noun_Brueckenwache;

        public Noun? Noun_Dolly;
        public Noun? Noun_Something;

        public Noun? Noun_Gemaelde;

        public Noun? Noun_Kamin;

        public Noun? Noun_Leuchter;

        public Noun? Noun_Podest;

        public Noun? Noun_Sitzbank;

        public Noun? Noun_Stealthy;

        public Noun? Noun_Steven;

        public Noun? Noun_Gestalt;

        public Noun? Noun_Schemen;

        public Noun? Noun_Teppich;
        public Noun? Noun_Rug;

        public Noun? Noun_Thron;

        public Noun? Noun_Zepter;

        public Noun? Noun_Mauern;

        public Noun? Noun_Eisentuer;

        public Noun? Noun_Muelltonne;

        public Noun? Noun_Bettchen;

        public Noun? Noun_Steinbank;

        public Noun? Noun_Felsbalkon;

        public Noun? Noun_Talkessel;

        public Noun? Noun_Stadt;

        public Noun? Noun_Versammlungsplatz;

        public Noun? Noun_Ketten;

        public Noun? Noun_Krokodil;

        public Noun? Noun_Eichenbohlen;

        public Noun? Noun_Zugbruecke;

        public Noun? Noun_Graben;

        public Noun? Noun_Blutlachen;

        public Noun? Noun_Blutlache;

        public Noun? Noun_Lache;

        public Noun? Noun_Folterinstrumente;

        public Noun? Noun_Nager;

        public Noun? Noun_Streckbank;

        public Noun? Noun_Waende;

        public Noun? Noun_Wendeltreppe;

        public Noun? Noun_Brustwehr;

        public Noun? Noun_Panoramablick;

        public Noun? Noun_Waelder;

        public Noun? Noun_Insel;

        public Noun? Noun_Buecher;

        public Noun? Noun_Fluegeltuer;

        public Noun? Noun_Panoramabild;

        public Noun? Noun_Phiolen;

        public Noun? Noun_Regale;

        public Noun? Noun_Sessel;

        public Noun? Noun_Schreibtisch;

        public Noun? Noun_Stuehlchen;

        public Noun? Noun_Geschirr;

        public Noun? Noun_Steinofen;

        public Noun? Noun_Middlefinger;

        public Noun? Noun_Toya;

        public Noun? Noun_Tortilla;

        public Noun? Noun_Tom;

        public Noun? Noun_Jones;

        public Noun? Noun_Sam;

        public Noun? Noun_Graham;

        public Noun? Noun_Tony;

        public Noun? Noun_Freshman;

        public Noun? Noun_Statuen;

        public Noun? Noun_Panoramen;

        public Noun? Noun_Koerbe;

        public Noun? Noun_Behaelter;

        public Noun? Noun_Baenke;

        public Noun? Noun_Altar;

        public Noun? Noun_Stiege;

        public Noun? Noun_Kellerfenster;

        public Noun? Noun_Dosen;

        public Noun? Noun_Sims;

        public Noun? Noun_Arbeitstisch;

        public Noun? Noun_Schublade;

        public Noun? Noun_Tralje;

        public Noun? Noun_Lastenaufzug;

        public Noun? Noun_Kordel;

        public Noun? Noun_Dosentelefon;

        public Noun? Noun_Biomuell;

        public Noun? Noun_Stoeckchen;

        public Noun? Noun_Stoehnen;

        public Noun? Noun_Topf;

        public Noun? Noun_Bratensosse;

        public Noun? Noun_Ofen;

        public Noun? Noun_Backform;

        public Noun? Noun_Kellertuer;

        public Noun? Noun_Bild;

        public Noun? Noun_Schrein;

        public Noun? Noun_Papierkorb;

        public Noun? Noun_Flachmann;

        public Noun? Noun_Himmelbett;

        public Noun? Noun_Sitzgarnitur;

        public Noun? Noun_Schatzkiste;

        public Noun? Noun_Bodenkacheln;

        public Noun? Noun_Stahltuer;

        public Noun? Noun_Lustgarten;

        public Noun? Noun_Gebirge;

        public Noun? Noun_Olivenbaeume;

        public Noun? Noun_Strasse;

        public Noun? Noun_Gebaeude;

        public Noun? Noun_Huetten;

        public Noun? Noun_Rampe;

        public Noun? Noun_Dorf;

        public Noun? Noun_Ritze;

        public Noun? Noun_Unkraut;

        public Noun? Noun_Lauge;

        public Noun? Noun_Seife;

        public Noun? Noun_Seifenlauge;

        public Noun? Noun_Telefon;

        public Noun? Noun_Marker;

        public Noun? Noun_Tonne;

        public Noun? Noun_Labor;

        public Noun? Noun_Monitore;

        public Noun? Noun_Schraenke;

        public Noun? Noun_Morast;

        public Noun? Noun_Schimmel;

        public Noun? Noun_Hafenbecken;

        public Noun? Noun_Werkstatt;

        public Noun? Noun_Pier;

        public Noun? Noun_Bohlen;

        public Noun? Noun_Boote;

        public Noun? Noun_Hafenbucht;

        public Noun? Noun_Gasse;

        public Noun? Noun_Kramladen;

        public Noun? Noun_Polizeiwache;

        public Noun? Noun_Post;

        public Noun? Noun_Redaktion;

        public Noun? Noun_Klotuer;

        public Noun? Noun_Klo;

        public Noun? Noun_Rolltreppe;

        public Noun? Noun_Nichtvorhang;

        public Noun? Noun_Sternekoeche;

        public Noun? Noun_Nichtdose;

        public Noun? Noun_Nichtdosen;

        public Noun? Noun_Nichtkonserve;

        public Noun? Noun_Nichtkonserven;

        public Noun? Noun_Nichtsims;

        public Noun? Noun_Ladekabel;

        public Noun? Noun_Verkaufstische;

        public Noun? Noun_Earpods;

        public Noun? Noun_Huellen;

        public Noun? Noun_Durchgang;

        public Noun? Noun_Gaeste;

        public Noun? Noun_Gestalten;

        public Noun? Noun_Luft;

        public Noun? Noun_Tische;

        public Noun? Noun_Klappe;

        public Noun? Noun_Muellklappe;

        public Noun? Noun_Schacht;

        public Noun? Noun_Muellschacht;

        public Noun? Noun_Couch;

        public Noun? Noun_Stuehle;

        public Noun? Noun_Tafel;

        public Noun? Noun_Phiole;

        public Noun? Noun_Muell;

        public Noun? Noun_Muellcontainer;

        public Noun? Noun_Zaeune;

        public Noun? Noun_Disteln;

        public Noun? Noun_Container;

        public Noun? Noun_Stan;

        public Noun? Noun_Delivery;

        public Noun? Noun_Plakate;

        public Noun? Noun_Postschalter;

        public Noun? Noun_Schreibpult;

        public Noun? Noun_Pult;

        public Noun? Noun_Wartebereich;

        public Noun? Noun_Emil;

        public Noun? Noun_Ike;

        public Noun? Noun_Ludmilla;

        public Noun? Noun_Streichelt;

        public Noun? Noun_Schmitt;

        public Noun? Noun_Julius;

        public Noun? Noun_Walton;

        public Noun? Noun_Schreibtische;

        public Noun? Noun_Schriftzug;

        public Noun? Noun_Klingel;

        public Noun? Noun_Riegel;

        public Noun? Noun_Backofen;

        public Noun? Noun_Form;

        public Noun? Noun_Oeffner;

        public Noun? Noun_Priester;

        public Noun? Noun_Junge;

        public Noun? Noun_Kuechenjunge;

        public Noun? Noun_Proviantmeister;

        public Noun? Noun_Sofa;

        public Noun? Noun_Auslagen;

        public Noun? Noun_Drehstaender;

        public Noun? Noun_Tand;

        public Noun? Noun_Holztuer;

        public Noun? Noun_Maennchen;

        public Noun? Noun_Maennlein;

        public Noun? Noun_Wandtattoo;

        public Noun? Noun_Schere;

        public Noun? Noun_Fleischwolf;

        public Noun? Noun_Pfanne;

        public Noun? Noun_Bonny;

        public Noun? Noun_Rocks;

        public Noun? Noun_John;

        public Noun? Noun_Prepper;

        public Noun? Noun_Foster;

        public Noun? Noun_Erin;

        public Noun? Noun_Stadtraetin;

        public Noun? Noun_Frieda;

        public Noun? Noun_Frimpton;

        public Noun? Noun_Stadtrat;

        public Noun? Noun_Buergermeister;

        public Noun? Noun_Buergermeisterin;

        public Noun? Noun_Prayin;

        public Noun? Noun_Kuehe;

        public Noun? Noun_Weiden;

        public Noun? Noun_Stacheldrahtzaun;

        public Noun? Noun_Zaun;

        public Noun? Noun_Zigarrenrauch;

        public Noun? Noun_Rauch;

        public Noun? Noun_Trophaeen;

        public Noun? Noun_Bilder;

        public Noun? Noun_Wimpel;

        public Noun? Noun_Geruch;

        public Noun? Noun_Steuerschatulle;

        public Noun? Noun_Schatulle;

        public Noun? Noun_Geschmeide;

        public Noun? Noun_Pokale;

        public Noun? Noun_Pokal;

        public Noun? Noun_Auszeichnungen;

        public Noun? Noun_Auszeichnung;

        public Noun? Noun_Reichtum;

        public Noun? Noun_Vuvuzela;

        public Noun? Noun_Umgebung;

        public Noun? Noun_Ferdinand;

        public Noun? Noun_Tristan;

        public Noun? Noun_Staubpartikel;

        public Noun? Noun_Kisten;

        public Noun? Noun_Buesche;

        public Noun? Noun_Farne;

        public Noun? Noun_Friedhof;

        public Noun? Noun_Laubbaeume;

        public Noun? Noun_Wegraender;

        public Noun? Noun_Schilder;

        public Noun? Noun_Staender;

        public Noun? Noun_Werkbank;

        public Noun? Noun_Werkzeugkasten;

        public Noun? Noun_Exponate;

        public Noun? Noun_Leo;

        public Noun? Noun_Kalender;

        public Noun? Noun_Schemel;

        public Noun? Noun_Aktenschrank;

        public Noun? Noun_Larry;

        public Noun? Noun_Professor;

        public Noun? Noun_Dirty;

        public Noun? Noun_Skarabaeus;

        public Noun? Noun_Karl;

        public Noun? Noun_Geraetschaften;

        public Noun? Noun_Tabletten;

        public Noun? Noun_Tablette;

        public Noun? Noun_Bund;

        public Noun? Noun_Highway;

        public Noun? Noun_Korb;

        public Noun? Noun_Krug;

        public Noun? Noun_Bierkrug;

        public Noun? Noun_Brunnen;

        public Noun? Noun_Grab;

        public Noun? Noun_Graeber;

        public Noun? Noun_Grabstein;

        public Noun? Noun_Grabsteine;

        public Noun? Noun_Wege;

        public Noun? Noun_Zombiehorde;

        public Noun? Noun_Zombies;

        public Noun? Noun_Zombie;

        public Noun? Noun_Haeuser;

        public Noun? Noun_Glaspalast;

        public Noun? Noun_Palast;

        public Noun? Noun_Platz;

        public Noun? Noun_Glaspalaeste;

        public Noun? Noun_Balkon;

        public Noun? Noun_Plakette;

        public Noun? Noun_Logistikzentrum;

        public Noun? Noun_Zentrum;

        public Noun? Noun_George;

        public Noun? Noun_Ruler;

        public Noun? Noun_Horizont;

        public Noun? Noun_Eremitin;

        public Noun? Noun_Acker;

        public Noun? Noun_Flackerlicht;

        public Noun? Noun_Flackern;

        public Noun? Noun_Sumpfgas;

        public Noun? Noun_Gas;

        public Noun? Noun_Wasser;

        public Noun? Noun_Flaemmchen;

        public Noun? Noun_Bericht;

        public Noun? Noun_Rechenschaftsbericht;

        public Noun? Noun_Postkasten;

        public Noun? Noun_Briefkasten;

        public Noun? Noun_Kasten;

        public Noun? Noun_Schraubstock;

        public Noun? Noun_Bauernhaus;

        public Noun? Noun_Bauernhof;

        public Noun? Noun_Haus;

        public Noun? Noun_Landmaschinen;

        public Noun? Noun_Maisfeld;

        public Noun? Noun_Maschinen;

        public Noun? Noun_Matsch;

        public Noun? Noun_Scheune;

        public Noun? Noun_Wohnhaus;

        public Noun? Noun_Laubbaum;

        public Noun? Noun_Weg;

        public Noun? Noun_Werkzeugschrank;

        public Noun? Noun_Strohballenberg;

        public Noun? Noun_Strohballen;

        public Noun? Noun_Scheunentor;

        public Noun? Noun_Lichtschalter;

        public Noun? Noun_Balken;

        public Noun? Noun_Flakon;

        public Noun? Noun_Flakons;

        public Noun? Noun_Bier;

        public Noun? Noun_Gift;

        public Noun? Noun_Grosswesir;

        public Noun? Noun_Wesir;

        public Noun? Noun_Tal;

        public Noun? Noun_Blumenwiese;

        public Noun? Noun_Favelas;

        public Noun? Noun_Favela;

        public Noun? Noun_Maisstauden;

        public Noun? Noun_Erdreich;

        public Noun? Noun_Maiskolben;

        public Noun? Noun_Lichtung;

        public Noun? Noun_Birken;

        public Noun? Noun_Wohnstube;

        public Noun? Noun_Vorratskammer;

        public Noun? Noun_Senfomat;

        public Noun? Noun_Apparat;

        public Noun? Noun_Stube;

        public Noun? Noun_Kammer;

        public Noun? Noun_Esstisch;

        public Noun? Noun_Anrichte;

        public Noun? Noun_Kuechenzeile;

        public Noun? Noun_Wasserhahn;

        public Noun? Noun_Spuelbecken;

        public Noun? Noun_Schlafkammer;

        public Noun? Noun_Nippes;

        public Noun? Noun_Sinnsprueche;

        public Noun? Noun_Wandregal;

        public Noun? Noun_Symbole;

        public Noun? Noun_Sprueche;

        public Noun? Noun_Spruch;

        public Noun? Noun_Geroell;

        public Noun? Noun_Felswand;

        public Noun? Noun_Plumpsklo;

        public Noun? Noun_Toilettenraum;

        public Noun? Noun_Toilette;

        public Noun? Noun_Fensterschlitz;

        public Noun? Noun_Steintreppe;

        public Noun? Noun_Gewoelbe;

        public Noun? Noun_Betonboden;

        public Noun? Noun_Dampfer;

        public Noun? Noun_Boulevard;

        public Noun? Noun_Edelfavelas;

        public Noun? Noun_Kommunikationszentrum;

        public Noun? Noun_Hightechzaun;

        public Noun? Noun_Zahlenschloss;

        public Noun? Noun_Taefelchen;

        public Noun? Noun_Gewicht;

        public Noun? Noun_Knoten;

        public Noun? Noun_Ringschraube;

        public Noun? Noun_Ring;

        public Noun? Noun_Hakenseil;

        public Noun? Noun_Stockseil;

        public Noun? Noun_Hecken;

        public Noun? Noun_Hecke;

        public Noun? Noun_Fach;

        public Noun? Noun_Brieffach;

        public Noun? Noun_Sekretaer;

        public Noun? Noun_Apparaturen;

        public Noun? Noun_Apparatur;

        public Noun? Noun_Juwelen;

        public Noun? Noun_Mall;

        public Noun? Noun_Shop;

        public Noun? Noun_Glastuer;

        public Noun? Noun_Paletten;

        public Noun? Noun_Platten;

        public Noun? Noun_Pillen;

        public Noun? Noun_Droge;

        public Noun? Noun_Panorama;

        public Noun? Noun_Statue;

        public Noun? Noun_Ohr;

        public Noun? Noun_Krone;

        public Noun? Noun_Baerenfallen;

        public Noun? Noun_Wertstoffe;

        public Noun? Noun_Geld;

        public Noun? Noun_Mauer;

        public Noun? Noun_Wehr;

        public Noun? Noun_Faesschen;

        public Noun? Noun_Drehwolf;

        public Noun? Noun_Tattoo;

        public Noun? Noun_Wolf;


        public Noun? Noun_Aufzug;

        public Noun? Noun_Berater;

        public Noun? Noun_Blut;

        public Noun? Noun_Exberater;

        public Noun? Noun_Gefangener;

        public Noun? Noun_Exgefangener;

        public Noun? Noun_Feld;

        public Noun? Noun_Folterwerkzeuge;

        public Noun? Noun_Garnitur;

        public Noun? Noun_Hof;

        public Noun? Noun_Instrumente;

        public Noun? Noun_Werkzeuge;

        public Noun? Noun_Zeile;

        public Noun? Noun_Staude;

        public Noun? Noun_Steine;

        public Noun? Noun_Kacheln;

        public Noun? Noun_Kolben;

        public Noun? Noun_Kueche;

        public Noun? Noun_Mais;

        public Noun? Noun_Maisstaude;

        public Noun? Noun_Maschine;

        public Noun? Noun_Partikel;

        public Noun? Noun_Scheibe;

        public Noun? Noun_Scheiben ;

        public Noun? Noun_Schrift;

        public Noun? Noun_Boot;

        public Noun? Noun_Computer;

        public Noun? Noun_Desk;

        public Noun? Noun_Desks;

        public Noun? Noun_Gitterstab;

        public Noun? Noun_Stab;

        public Noun? Noun_Eisenbeschlag;

        public Noun? Noun_Eisenbeschlaege;

        public Noun? Noun_Eisen;

        public Noun? Noun_Beschlaege;

        public Noun? Noun_Strandbars;

        public Noun? Noun_Strandbar;

        public Noun? Noun_Bars;

        public Noun? Noun_Barfrau;

        public Noun? Noun_Helm;

        public Noun? Noun_Steinbrocken;

        public Noun? Noun_Brocken;

        public Noun? Noun_Gang;

        public Noun? Noun_Bratensauce;

        public Noun? Noun_Sauce;

        public Noun? Noun_Sosse;

        public Noun? Noun_Maler;

        public Noun? Noun_Kate;

        public Noun? Noun_Queen;

        public Noun? Noun_Exqueen;

        public Noun? Noun_Exexkoenigin;

        public Noun? Noun_Kanne;

        public Noun? Noun_Golfbahnen;

        public Noun? Noun_Golfplatz;

        public Noun? Noun_Bahn;

        public Noun? Noun_Bahnen;

        public Noun? Noun_Club;

        public Noun? Noun_Clubhaus;

        public Noun? Noun_Senffass;

        public Noun? Noun_Senftopf;

        public Noun? Noun_Schlauchende;

        public Noun? Noun_Tank;

        public Noun? Noun_Tankverschluss;

        public Noun? Noun_Trator;

        public Noun? Noun_Trecker;

        public Noun? Noun_Verschluss;

        public Noun? Noun_Traktor;

        public Noun? Noun_Glasscheiben;

        public Noun? Noun_Bueros;

        public Noun? Noun_Buero;

        public Noun? Noun_Geraete;

        public Noun? Noun_Matschpfuetze;

        public Noun? Noun_Pfuetze;

        public Noun? Noun_Regentonne;

        public Noun? Noun_Kleiderschrank;

        public Noun? Noun_Schlafgemach;

        public Noun? Noun_Bettdecke;

        public Noun? Noun_Portrait;

        public Noun? Noun_Benachrichtigung;

        public Noun? Noun_Benachrichtigungskarte;

        public Noun? Noun_Hightechklo;

        public Noun? Noun_Bildhauer;

        public Noun? Noun_Leiber;

        public Noun? Noun_Kabel;

        public Noun? Noun_Kabelisolierung;

        public Noun? Noun_Isolierung;

        public Noun? Noun_Grube;

        public Noun? Noun_Instrument;

        public Noun? Noun_Musikinstrumente;

        public Noun? Noun_Menschenleiber;

        public Noun? Noun_Abgrund;

        public Noun? Noun_Ausgabe;

        public Noun? Noun_Ausgabefach;

        public Noun? Noun_Knochentuer;

        public Noun? Noun_Frachtdokumente;

        public Noun? Noun_Dokumente;

        public Noun? Noun_Zettel;

        public Noun? Noun_Berder;

        public Noun? Noun_Daemonen;

        public Noun? Noun_Zeichen;

        public Noun? Noun_Satanspfuhl;

        public Noun? Noun_Pfuhl;

        public Noun? Noun_Bruecke;

        public Noun? Noun_Schwaden;

        public Noun? Noun_Schwefelschwaden;

        public Noun? Noun_Foltersitzgarnitur;

        public Noun? Noun_Hoellenfeuer;

        public Noun? Noun_Feuer;

        public Noun? Noun_Plakat;

        public Noun? Noun_Fahndungsplakate;

        public Noun? Noun_Fahndungsplakat;

        public Noun? Noun_Metallschrank;

        public Noun? Noun_Daemonentor;

        public Noun? Noun_Faeulnis;

        public Noun? Noun_Satanspalast;

        public Noun? Noun_Hoellenkreatur;

        public Noun? Noun_Kreatur;

        public Noun? Noun_Schaelchen;

        public Noun? Noun_Suhle;

        public Noun? Noun_Teufelssuhle;

        public Noun? Noun_Lakaien;

        public Noun? Noun_Lakai;

        public Noun? Noun_Friteuse;

        public Noun? Noun_Essenshalde;

        public Noun? Noun_Halde;

        public Noun? Noun_Lebensmittel;

        public Noun? Noun_Kaeptn;

        public Noun? Noun_Schaedel;

        public Noun? Noun_Pentagramme;

        public Noun? Noun_Lava;

        public Noun? Noun_Zuendschnur;

        public Noun? Noun_Schnur;

        public Noun? Noun_Angelschnur;

        public Noun? Noun_Hightechfaser;

        public Noun? Noun_Faser;

        public Noun? Noun_Lunte;

        public Noun? Noun_Suessigkeitenbrunnen;

        public Noun? Noun_Pappaufsteller;

        public Noun? Noun_Aufsteller;

        public Noun? Noun_Lift;

        public Noun? Noun_Flaschenzug;

        public Noun? Noun_Truemmerhaufen;

        public Noun? Noun_Fuerstin;

        public Noun? Noun_Hoellenfuerstin;

        public Noun? Noun_Schmierereien;

        public Noun? Noun_Elendshuetten;

        public Noun? Noun_Hochhaus;

        public Noun? Noun_Hochbauten;

        public Noun? Noun_Hochbau;

        public Noun? Noun_Geisterschiff;

        public Noun? Noun_Gebeine;

        public Noun? Noun_Schaufenster;

        public Noun? Noun_Stangen;

        public Noun? Noun_Muelleimer;

        public Noun? Noun_Gitter;

        public Noun? Noun_Staebe;

        public Noun? Noun_Staebchen;

        public Noun? Noun_Grappa;

        public Noun? Noun_Bauer;

        public Noun? Noun_Senf;

        public Noun? Noun_Esse;

        public Noun? Noun_Zucker;

        public Noun? Noun_Paeckchen;

        public Noun? Noun_Wanne;

        public Noun? Noun_Spinnweben;

        public Noun? Noun_Prunktuer;

        public Noun? Noun_Nackttaenzerinnen;

        public Noun? Noun_Nackttaenzerin;

        public Noun? Noun_Taenzerinnen;

        public Noun? Noun_Taenzerin;


        public Noun? Noun_Koeche;

        public Noun? Noun_Holz;

        public Noun? Noun_Metall;

        public Noun? Noun_Folie;

        public Noun? Noun_Schiebewagen;

        public Noun? Noun_Wagen;

        public Noun? Noun_Postsack;

        public Noun? Noun_Heliumbehaelter;

        public Noun? Noun_Helium;

        public Noun? Noun_Flasche;

        public Noun? Noun_Bodenteppich;

        public Noun? Noun_Naegel;

        public Noun? Noun_Loch;

        public Noun? Noun_Berg;

        public Noun? Noun_Puppenberg;

        public Noun? Noun_Puppen;

        public Noun? Noun_Stoffpuppen;

        public Noun? Noun_Stofftiere;

        public Noun? Noun_Wuermer;

        public Noun? Noun_Gewand;

        public Noun? Noun_Servierhaube;

        public Noun? Noun_Haube;

        public Noun? Noun_Servierplatte;

        public Noun? Noun_Platte;

        public Noun? Noun_Mahl;

        public Noun? Noun_Werbetafeln;

        public Noun? Noun_Tafeln;

        public Noun? Noun_Bacon;

        public Noun? Noun_Ballen;

        public Noun? Noun_Streifen;

        public Noun? Noun_Blumen;

        public Noun? Noun_Wiese;

        public Noun? Noun_Kran;

        public Noun? Noun_Krananlage;

        public Noun? Noun_Buecherhaufen;

        public Noun? Noun_Haufen;

        public Noun? Noun_Anlage;

        public Noun? Noun_Joystick;

        public Noun? Noun_Hippie;

        public Noun? Noun_Partypeople;

        public Noun? Noun_Party;

        public Noun? Noun_People;

        public Noun? Noun_Blaetter;

        public Noun? Noun_Blatt;

        public Noun? Noun_Ruecken;

        public Noun? Noun_Hippieruecken;

        public Noun? Noun_Pullover;

        public Noun? Noun_Bluetenkelch;

        public Noun? Noun_Kelch;

        public Noun? Noun_Blume;

        public Noun? Noun_Landvermesser;

        public Noun? Noun_Vermesser;

        public Noun? Noun_Moerser;

        public Noun? Noun_Stoessel;

        public Noun? Noun_Gin;

        public Noun? Noun_Kohle;

        public Noun? Noun_Satanisten;

        public Noun? Noun_Satanist;

        public Noun? Noun_Attraktionen;

        public Noun? Noun_Attraktion;

        public Noun? Noun_Lautsprecher;

        public Noun? Noun_Smartphone;

        public Noun? Noun_Dimensionstor;

        public Noun? Noun_Ruine;

        public Noun? Noun_Motive;

        public Noun? Noun_Motiv;

        public Noun? Noun_Mansion;

        public Noun? Noun_Galgen;

        public Noun? Noun_Gehenkte;

        public Noun? Noun_Erde;

        public Noun? Noun_Idiot;

        public Noun? Noun_Steinpfad;

        public Noun? Noun_Farmerin;

        public Noun? Noun_Farmer;

        public Noun? Noun_Spielgeldboegen;

        public Noun? Noun_Werkzeug;

        public Noun? Noun_Kadaver;

        public Noun? Noun_Mogul;

        public Noun? Noun_Nachricht;

        public Noun? Noun_Notiz;

        public Noun? Noun_Schale;

        public Noun? Noun_Schrauber;

        public Noun? Noun_Peitsche;

        public Noun? Noun_Runen;

        public Noun? Noun_Teufelsstatuette;

        public Noun? Noun_Teufel;

        public Noun? Noun_Boegen;

        public Noun? Noun_Papierbogen;


        public Noun? Noun_Abteilung;

        public Noun? Noun_Accessoires;

        public Noun? Noun_Fetisch;

        public Noun? Noun_Fetischaccessoires;

        public Noun? Noun_Lackundleder_Abteilung;

        public Noun? Noun_Leder;

        public Noun? Noun_Lederoutfit;

        public Noun? Noun_Lederoutfits;

        public Noun? Noun_Luxus;

        public Noun? Noun_Luxusabteilung;

        public Noun? Noun_Outfit;

        public Noun? Noun_Sextoys;

        public Noun? Noun_Dildos;

        public Noun? Noun_Dildo;

        public Noun? Noun_Toys;

        public Noun? Noun_Tempel;

        public Noun? Noun_Waesche;

        public Noun? Noun_Wolken;

        public Noun? Noun_Wolke;

        public Noun? Noun_Henkerswald;

        public Noun? Noun_Nackttaenzer;

        public Noun? Noun_Taenzer;


        public Noun? Noun_Schling;

        public Noun? Noun_Schlingpflanzen;

        public Noun? Noun_See;

        public Noun? Noun_Seen;

        public Noun? Noun_Pflanzen;

        public Noun? Noun_Saeure;

        public Noun? Noun_Saeureseen;

        public Noun? Noun_Becken;
        public Noun? Noun_Waschbecken;


        public Noun? Noun_Wirtschaftsgebaeude;

        public Noun? Noun_Turm;

        public Noun? Noun_Kapelle;

        public Noun? Noun_Kirche;

        public Noun? Noun_Ball;



        public Noun? Noun_Wichser;

        public Noun? Noun_Arschloch;

        public Noun? Noun_Drecksau;

        public Noun? Noun_Werkzeugkiste;

        public Noun? Noun_Dart;

        public Noun? Noun_Schein;

        public Noun? Noun_Farbeimer;

        public Noun? Noun_Farbe;

        public Noun? Noun_Bezug;

        public Noun? Noun_Schleuder;

        public Noun? Noun_Stift;

        public Noun? Noun_Balg;

        public Noun? Noun_Stange;

        public Noun? Noun_Mohn;

        public Noun? Noun_Opium;

        public Noun? Noun_Schlafmittel;

        public Noun? Noun_Ecke;

        public Noun? Noun_Lied;

        public Noun? Noun_Gemuese;

        public Noun? Noun_Lauch;

        public Noun? Noun_Tomate;

        public Noun? Noun_Tomaten;

        public Noun? Noun_Zucchini;

        public Noun? Noun_Karaffe;

        public Noun? Noun_Schnapsglas;

        public Noun? Noun_Schnaps;

        public Noun? Noun_Dokument;

        public Noun? Noun_Ketchup;

        public Noun? Noun_Flecken;

        public Noun? Noun_Ketchupflecken;

        public Noun? Noun_Gefangene;

        public Noun? Noun_Maden;

        public Noun? Noun_Engerlinge;

        public Noun? Noun_Metropole;

        public Noun? Noun_Huegel;

        public Noun? Noun_Burgruine;

        public Noun? Noun_Teufelswald;

        public Noun? Noun_Schwefel;

        public Noun? Noun_Burg;

        public Noun? Noun_Fuellfederhalter;

        public Noun? Noun_Federhalter;

        public Noun? Noun_Formular;

        public Noun? Noun_Fueller;

        public Noun? Noun_Schlaufe;

        public Noun? Noun_Tuete;


        public Noun? Noun_Schreib;

        public Noun? Noun_Stifthalter;

        public Noun? Noun_Halter;

        public Noun? Noun_Lieferscheine;

        public Noun? Noun_Scheine;

        public Noun? Noun_Glasschneider;

        public Noun? Noun_Schneider;

        public Noun? Noun_Urkunde;

        public Noun? Noun_Pendel;

        public Noun? Noun_Aubergine;

        public Noun? Noun_Spruehflasche;


        public Noun? Noun_Gewaechshaus;

        public Noun? Noun_Terminal;

        public Noun? Noun_Natron;

        public Noun? Noun_Packung;

        public Noun? Noun_Apfelessig;

        public Noun? Noun_Apfel;

        public Noun? Noun_Essig;

        public Noun? Noun_Polierlappen;

        public Noun? Noun_Lappen;


        public Noun? Noun_Grapefruitextrakt;

        public Noun? Noun_Grapefruit;

        public Noun? Noun_Extrakt;

        public Noun? Noun_Flaeschchen;

        public Noun? Noun_Dimensions;
        public Noun? Noun_Folter;
        public Noun? Noun_Kessel;
        public Noun? Noun_Lachen;
        public Noun? Noun_Streck;
        public Noun? Noun_Versammlungs;
        public Noun? Noun_Wirtschafts;
        public Noun? Noun_Wendel;
        public Noun? Noun_Paradies;
        public Noun? Noun_Mann;
        public Noun? Noun_Eichen;
        public Noun? Noun_Brust;
        public Noun? Noun_Blick;
        public Noun? Noun_Fluegel;
        public Noun? Noun_Steuer;
        public Noun? Noun_Back;
        public Noun? Noun_Arbeit;
        public Noun? Noun_Lasten;
        public Noun? Noun_Oliven;
        public Noun? Noun_Wohn;
        public Noun? Noun_Hafen;
        public Noun? Noun_Agrikultur;
        public Noun? Noun_Laden;
        public Noun? Noun_Polizei;
        public Noun? Noun_Bereich;
        public Noun? Noun_Laub;
        public Noun? Noun_Regen;
        public Noun? Noun_Warte;

        public Noun? Noun_Dreh;
        public Noun? Noun_Ess;
        public Noun? Noun_Fracht;
        public Noun? Noun_Garten;
        public Noun? Noun_Kombination;
        public Noun? Noun_Lust;
        public Noun? Noun_Nackt;
        public Noun? Noun_Prunk;
        public Noun? Noun_Raum;
        public Noun? Noun_Schlitz;
        public Noun? Noun_Spielzeug;
        public Noun? Noun_Stahl;
        public Noun? Noun_Staub;
        public Noun? Noun_Stumpf;
        public Noun? Noun_Sumpf;
        public Noun? Noun_Wohn2;
        public Noun? Noun_Zigarren;

        public Noun? Noun_Edel;
        public Noun? Noun_Ende;
        public Noun? Noun_Fahndung;
        public Noun? Noun_Himmel;
        public Noun? Noun_Heaven;
        public Noun? Noun_Kommunikation;
        public Noun? Noun_Lade;
        public Noun? Noun_Logistik;
        public Noun? Noun_Palaeste;
        public Noun? Noun_Satan;
        public Noun? Noun_Servier;
        public Noun? Noun_Stern;
        public Noun? Noun_Verkaufs;

        public Noun? Noun_Alfonsius;
        public Noun? Noun_Anzug;
        public Noun? Noun_Baeren;
        public Noun? Noun_Baseball;
        public Noun? Noun_Botanik;
        public Noun? Noun_Buesser;
        public Noun? Noun_Daemon;
        public Noun? Noun_Experten;
        public Noun? Noun_Fallen;
        public Noun? Noun_Fesseln;
        public Noun? Noun_Frischhalte;
        public Noun? Noun_Friteuse1;
        public Noun? Noun_Fuellfeder;
        public Noun? Noun_Gebaeude_pl;
        public Noun? Noun_Geist;
        public Noun? Noun_Geraet;
        public Noun? Noun_Giess;
        public Noun? Noun_Golf;
        public Noun? Noun_Hanf;
        public Noun? Noun_Henker;
        public Noun? Noun_Island;
        public Noun? Noun_Kappe;
        public Noun? Noun_Kartoffel;
        public Noun? Noun_Knochen;
        public Noun? Noun_Kopf;
        public Noun? Noun_Liefer;
        public Noun? Noun_Lippenstift;
        public Noun? Noun_Meinung;
        public Noun? Noun_Menschen;
        public Noun? Noun_Musik;
        public Noun? Noun_Outfits;
        public Noun? Noun_Papp;
        public Noun? Noun_Permanent;
        public Noun? Noun_Polier;
        public Noun? Noun_Rechenschafts;
        public Noun? Noun_Satans;
        public Noun? Noun_Schaukel;
        public Noun? Noun_Schiebe;
        public Noun? Noun_Schlaf;
        public Noun? Noun_Shot;
        public Noun? Noun_Sitz;
        public Noun? Noun_Slip;
        public Noun? Noun_Soda;
        public Noun? Noun_Spiel;
        public Noun? Noun_Spreng;
        public Noun? Noun_Sprueh;
        public Noun? Noun_Stueck;
        public Noun? Noun_Suessigkeiten;
        public Noun? Noun_Taucher;
        public Noun? Noun_Teufels;
        public Noun? Noun_Ticket;
        public Noun? Noun_Visiten;
        public Noun? Noun_Zustell;

        public Noun? Noun_Bell;
        public Noun? Noun_Beton;
        public Noun? Noun_Block;
        public Noun? Noun_Dinner;
        public Noun? Noun_Flask;
        public Noun? Noun_Hip;
        public Noun? Noun_Pulley;
        public Noun? Noun_Creature;
        public Noun? Noun_Horde;
        public Noun? Noun_Princess;
        public Noun? Noun_Hell;
        public Noun? Noun_Shards;
        public Noun? Noun_China;
        public Noun? Noun_Waste;

        public Noun? Noun_Ritterruestung;
        public Noun? Noun_Ritter;
        public Noun? Noun_Ruestung;
        public Noun? Noun_Eule;
        public Noun? Noun_Skelett;
        public Noun? Noun_Fish;
        public Noun? Noun_Schlange;
        public Noun? Noun_Elster;
        public Noun? Noun_Beutelchen;
        public Noun? Noun_Pulver;
        public Noun? Noun_Kerzenhalter;
        public Noun? Noun_Klaue;
        public Noun? Noun_Zuckerzange;
        public Noun? Noun_Rollpflaster;
        public Noun? Noun_Klauenzange;

        // Neue Nouns

        public Noun? Noun_Lupe;
        public Noun? Noun_Quietscheentchen;
        public Noun? Noun_Kaese;
        public Noun? Noun_Mondstein;
        public Noun? Noun_Mond;
        public Noun? Noun_Plastikbeutel;
        public Noun? Noun_Wunderwarzenschwamm;
        public Noun? Noun_Schlacke;
        public Noun? Noun_Muenze;
        public Noun? Noun_Nebel;
        public Noun? Noun_Fussmatter;
        public Noun? Noun_Pentagramm;

        public Noun? Noun_Fussmatte;
        public Noun? Noun_Oeffnung;
        public Noun? Noun_Siegel;
        public Noun? Noun_Waescheleine;
        public Noun? Noun_Unterhose;
        public Noun? Noun_Unterwaesche;
        public Noun? Noun_Holzabdeckung;
        public Noun? Noun_Waschmaschine;
        public Noun? Noun_Waescheaufhaengmaschine;
        public Noun? Noun_Waeschekorb;
        public Noun? Noun_Karton;
        public Noun? Noun_Labortisch;
        public Noun? Noun_Kaefige;
        public Noun? Noun_Erstehilfekasten;
        public Noun? Noun_Metallschale;
        public Noun? Noun_Halterung;
        public Noun? Noun_Dunkelheitsmaschine;
        public Noun? Noun_Vogelstaender;
        public Noun? Noun_Matratze;
        public Noun? Noun_Kuehlschrank;
        public Noun? Noun_Gefrierfach;
        public Noun? Noun_Kachel;
        public Noun? Noun_Badewanne;
        public Noun? Noun_Spuelung;
        public Noun? Noun_Matte;
        public Noun? Noun_Beutel;
        public Noun? Noun_Kerze;
        public Noun? Noun_Buchstaben;
        public Noun? Noun_Rolle;

        public Noun? Noun_Rune;
        public Noun? Noun_Warnschild;
        public Noun? Noun_Wasch;
        public Noun? Noun_Gefrier;
        public Noun? Noun_Froster;
        public Noun? Noun_Ente;
        public Noun? Noun_Entchen;
        public Noun? Noun_Gummiente;
        public Noun? Noun_Flamme;
        public Noun? Noun_Juwel;
        public Noun? Noun_Edelstein;
        public Noun? Noun_Plastiktuete;
        public Noun? Noun_Versteck;
        public Noun? Noun_Fliese;
        public Noun? Noun_Fliesen;

        // Neue Nouns
        public Noun? Noun_Krempel;
        public Noun? Noun_Spuren;
        public Noun? Noun_Abdeckung;
        public Noun? Noun_Deckel;
        public Noun? Noun_Verbandskasten;
        public Noun? Noun_Plastik;
        public Noun? Noun_Pilz;
        public Noun? Noun_Funghi;
        public Noun? Noun_Sporen;
        public Noun? Noun_Schwamm;


        public Person? Person_Everyone { get; set; }

        public Person? Person_Self { get; set; }

        public Person? Person_You { get; set; }

        public Person? Person_I { get; set; }

        public Person? Person_3rdperson { get; set; }

        public Person? Person_Knights_Armor { get; set; }
        public Person? Person_Owl { get; set; }
        public Person? Person_Librarian { get; set; }
        public Person? Person_Fish { get; set; }
        public Person? Person_Parrot { get; set; }
        public Person? Person_Snake { get; set; }
        public Person? Person_Magpie { get; set; }

        public Topic? TP_Versteck;


        public int PL_Use;

        public int PL_UseMC;

        public int PL_Use_W;

        public int PL_Use_WMC;

        public int PL_Throw;

        public int PL_Throw_Out;

        public int PL_Throw_In;

        public int PL_ThrowMC;

        public int PL_Draw;

        public int PL_DrawOut;

        public int PL_DrawOff;

        public int PL_Draw_Down;

        public int PL_DrawMC;

        public int PL_Push;

        public int PL_PushMC;

        public int PL_Push_To;

        public int PL_Push_ToMC;

        public int PL_Push_Up;

        public int PL_Unlock_W_P;

        public int PL_Unlock_W_PMC;

        public int PL_Say_To_P;

        public int PL_Say_To_P2;

        public int PL_Say_To_PMC;

        public int PL_Say_To_I;

        public int PL_Say_To_I2;

        public int PL_Demand_From_P;

        public int PL_Demand_From_PMC;

        public int PL_Give_To_P;

        public int PL_Give_To_PMC;

        public int PL_Show_To_P;

        public int PL_Give_To_P2;

        public int PL_Show_To_P2;

        public int PL_Plea_From_P;

        public int PL_Plea_From_PMC;

        public int PL_Read;

        public int PL_ReadMC;

        public int PL_Untighten;

        public int PL_UntightenMC;

        public int PL_Break;

        public int PL_Break_Down;

        public int PL_BreakMC;

        public int PL_Use_W_P;

        public int PL_Unscrew_W;

        public int PL_Unscrew_W2;

        public int PL_Truncate_W;

        public int PL_Use_W_PMC;

        public int PL_Mount;

        public int PL_Saw;

        public int PL_Saw2;

        public int PL_Cut;

        public int PL_CutMC;

        public int PL_Tie;

        public int PL_Tie_P;

        public int PL_Tie_P2;

        public int PL_TieMC;

        public int PL_Fish;

        public int PL_FishMC;

        public int PL_Light;

        public int PL_LightMC;

        public int PL_EnlightW;

        public int PL_LightW;

        public int PL_LightWMC;

        public int PL_Extinguish;

        public int PL_ExtinguishMC;

        public int PL_Grab;

        public int PL_GrabMC;

        public int PL_Eat;

        public int PL_Eat_P;

        public int PL_EatMC;

        public int PL_Fill;

        public int PL_Fill2;

        public int PL_FillMC;

        public int PL_Stuff;

        public int PL_Pick;

        public int PL_PickMC;

        public int PL_Sell;

        public int PL_SellMC;

        public int PL_SellTo;

        public int PL_SellToMC;

        public int PL_CatchP;

        public int PL_CatchPMC;

        public int PL_Pick_W;

        public int PL_Pick_WMC;

        public int PL_Drink;

        public int PL_DrinkFrom;

        public int PL_Touch;

        public int PL_DrinkMC;

        public int PL_TouchMC;

        public int PL_Knock;

        public int PL_Knock2;

        public int PL_Knock_Solo;

        public int PL_Spit;

        public int PL_SpitP;

        public int PL_SpitDown;

        public int PL_Listen;

        public int PL_Listen_Solo;

        public int PL_Listen_Person;

        public int PL_Listen_Topic;

        public int PL_AttachTo;

        public int PL_HangTo;

        public int PL_ClimbUpMC;

        public int PL_ClimbUp;

        public int PL_ClimbDown2;

        public int PL_ClimbDown;

        public int PL_ClimbOn;

        public int PL_ClimbThrough;

        public int PL_ClimbIn;

        public int PL_Dip;

        public int PL_Tip;

        public int PL_Tip_Solo;

        public int PL_Tip_In;

        public int PL_Pour;

        public int PL_Pour2;

        public int PL_Arrest;

        public int PL_ArrestW;

        public int PL_Meditate;

        public int PL_Meditate_Solo;

        public int PL_Press;

        public int PL_Ring;
        public int PL_Press_In;
        public int PL_Press_On;

        public int PL_Puncture;

        public int PL_PunctureReverse;

        public int PL_Photograph;

        public int PL_Photograph2;

        public int PL_Soil;
        public int PL_Smear;

        public int PL_Smear2;

        public int PL_SmearReverse;

        public int PL_Blow;

        public int PL_BlowWith;

        public int PL_Poison;

        public int PL_Compare;

        public int PL_Creep;

        public int PL_Follow;

        public int PL_Jump;

        public int PL_Jump_In;

        public int PL_Jump_On;

        public int PL_Jump_Through;

        public int PL_Turn;

        public int PL_Mix;

        public int PL_Pluck;

        public int PL_Suck;

        public int PL_Suck2;

        public int PL_Sit1;

        public int PL_Sit2;

        public int PL_Sit3;

        public int PL_Sit4;

        public int PL_Lay1;

        public int PL_Lay2;

        public int PL_Lay3;

        public int PL_Lay4;

        public int PL_Exchange;

        public int PL_Crumble;

        public int PL_Crumble_in;

        public int PL_Abandon;

        public int PL_Kiss_P;

        public int PL_Dress;
        public int PL_DrawShut;

        public int PL_Undress;

        public int PL_DrawWith;

        public int PL_Free;

        public int PL_Stir;

        public int PL_Stir2;

        public int PL_Park;

        public int PL_PlaceTo;

        public int PL_PlaceToP;

        public int PL_Pinch;

        public int PL_BuryP;

        public int PL_BuryPSolo;

        public int PL_Beat;

        public int PL_BeatW;

        public int PL_Cuddle;

        public int PL_Fuck;

        public int PL_Kill;

        public int PL_KillW;

        public int PL_Pet;

        public int PL_Tickle;

        public int PL_TickleW;

        public int PL_Joggle;

        public int PL_Sleep;

        public int PL_Sleep2;

        public int PL_Sleep3;

        public int PL_Spark;

        public int PL_Leave;

        public int PL_Determine;

        public int PL_Remove;

        public int PL_Clean;

        public int PL_Wash;

        public int PL_Split;

        public int PL_Wear;

        public int PL_Wrap;

        public int PL_Wrap2;

        public int PL_Paint;

        public int PL_Paint_Solo;

        public int PL_Place_Solo;

        public int PL_Plea_Solo;

        public int PL_PoisonSolo;

        public int PL_PunctureSolo;

        public int PL_Show_Solo;

        public int PL_Smear_Solo;

        public int PL_Spark_Solo;

        public int PL_Throw_Solo;

        public int PL_Throw_Person;

        public int PL_AskSolo;

        public int PL_Clean_Solo;

        public int PL_Clean_W;

        public int PL_Cut_Solo;

        public int PL_Demand_Solo;

        public int PL_Determine_Solo;

        public int PL_ExchangeSolo;

        public int PL_Fill_Solo;

        public int PL_Give_Solo;

        public int PL_Give_To_I;

        public int PL_GrabSolo;

        public int PL_HangSolo;

        public int PL_AttachSolo;

        public int PL_MixSolo;

        public int PL_Puncture_Solo;

        public int PL_SmearSolo;

        public int PL_TieSolo;

        public int PL_Wash_Solo;

        public int PL_Wrap_Solo;

        public int PL_Search;

        public int PL_SearchW;

        public int PL_Poke;

        public int PL_Dig;

        public int PL_Wake;

        public int PL_Shout;

        public int PL_Slide;

        public int PL_Attack;

        public int PL_Pray;

        public int PL_Bend;

        public int PL_Scroll;

        public int PL_Leverage;

        public int PL_Count;

        public int PL_Breath;

        public int PL_Make_On;

        public int PL_Make_Off;

        public int PL_Spray;

        public int PL_Spray_Solo;


        public int PL_MixReverse;

        public int PL_MixIn;

        public int PL_Accede;

        public int PL_Be;

        public int PL_Repair;

        public int PL_Sort;

        public int PL_Confess;

        public int PL_Stroke;

        public int PL_SwitchOff;

        public int PL_SwitchOn;

        public int PL_Lift;

        public int PL_Wipe;

        public int PL_WipeW;

        public int PL_Exits;

        public int PL_Steal;

        public int PL_StealP;

        public int PL_StealWP;

        public int PL_Score;


        public int PL_Destroy;

        public int PL_Chop;

        public int PL_ChopW;

        public int PL_Plunge;

        public int PL_Plunge_Out;

        public int PL_RollIn;

        public int PL_Roll_Solo;

        public int PL_Demolish;

        public int PL_GlueTo;

        public int PL_Heat;

        public int PL_HeatW;

        public int PL_Pulverize;

        public int PL_Pulverize_W;

        public int PL_Tidy;

        public int PL_BrushW;


        public int PL_Type;

        public int PL_Fry;

        public int PL_Form;

        public int PL_FormFrom;

        public int PL_Dance_Person;

        public int PL_Dance;

        public int PL_Hang;

        public int PL_Hang2;

        public int PL_Swing2;

        public int PL_Swing;

        public int PL_Store;

        public int PL_SingSolo;

        public int PL_Sing;

        public int PL_Lick;

        public int PL_Hide;

        public int PL_Hide_P;


        public int PL_Burn;

        public int PL_Burn_W;

        public int PL_Burn_In;

        public int PL_Smoke;

        public int PL_Tear;

        public int PL_Credits;

        public int PL_Manual;

        public int PL_Phone;

        public int PL_PhoneW;

        public int PL_Testwindow;

        public int PL_Brief;

        public int PL_Verbose;

        public int PL_Illustration;

        public int PL_Undo;

        public int L01_Dark_Forest { get; set; }
        public int L02_In_Front_Of_A_Hut { get; set; }
        public int L03_In_The_Parlor { get; set; }
        public int L04_Shabby_Little_Chamber { get; set; }
        public int L05_Atrium { get; set; }
        public int L06_Long_Floor { get; set; }
        public int L07_Lower_Floor { get; set; }
        public int L08_Laundry_Room { get; set; }
        public int L09_Library { get; set; }
        public int L10_Laboratory { get; set; }
        public int L11_Storage_Room { get; set; }
        public int L12_Sleeping_Room { get; set; }
        public int L13_Kitchen { get; set; }
        public int L14_Bathroom { get; set; }
        public int L15_Nowhere { get; set; }
        public Item? I00_Nullbehaelter{ get; set; }

        public Item? I00_Nullbehaelter2{ get; set; }

        public Item? I00_Nullbehaelter3{ get; set; }

        public Item? I00_Pouch { get; set; }
        public Item? I00_Magic_Powder { get; set; }
        public Item? I00_Supermagic_Powder { get; set; }
        public Item? I00_Magic_Candle { get; set; }
        public Item? I00_Claw { get; set; }
        public Item? I00_Sugar_Pliers { get; set; }
        public Item? I00_Key { get; set; }
        public Item? I00_Roll_Plaster { get; set; }
        public Item? I00_Unstable_Pliers_With_Claw { get; set; }
        public Item? I00_Stable_Pliers_With_Claw { get; set; }
        public Item? I00_Polishing_Rag { get; set; }
        public Item? I00_Magnifier { get; set; }
        public Item? I00_Squeaky_Duck { get; set; }
        public Item? I00_Paper_Sheets { get; set; }
        public Item? I00_Book_Master { get; set; }
        public Item? I00_Cheese { get; set; }
        public Item? I00_Polished_Stone { get; set; }
        public Item? I00_Lightless_Stone { get; set; }
        public Item? I00_Moonstone { get; set; }
        public Item? I00_Plastic_Bag { get; set; }
        public Item? I00_Wonder_Wart_Sponge { get; set; }
        public Item? I00_Slag { get; set; }
        public Item? I00_Plunger { get; set; }

        public Item? I01_Forest { get; set; }
        public Item? I01_Trees { get; set; }
        public Item? I01_Mist { get; set; }
        public Item? I01_Forest_Grass { get; set; }

        public Item? I02_Doormat { get; set; }
        public Item? I02_Shed { get; set; }
        public Item? I02_Forest { get; set; }
        public Item? I02_Trees { get; set; }
        public Item? I02_Mist { get; set; }
        public Item? I02_Door{ get; set; }

        public Item? I03_Pentagram { get; set; }
        public Item? I03_Runes { get; set; }
        public Item? I03_Door { get; set; }
        public Item? I03_Door_Outside { get; set; }

        public Item? I04_Shelf { get; set; }
        public Item? I04_Cupboard { get; set; }
        public Item? I04_Wall { get; set; }
        public Item? I04_Floor { get; set; }
        public Item? I04_Flap { get; set; }
        public Item? I04_Opening { get; set; }
        public Item? I04_Clutter { get; set; }
        public Item? I04_Door { get; set; }

        public Item? I05_Pentagram { get; set; }
        public Item? I05_Pedestal { get; set; }
        public Item? I05_Sign { get; set; }
        public Item? I05_Sill { get; set; }
        public Item? I05_Library_Door { get; set; }
        public Item? I05_Door { get; set; }
        public Item? I05_Moon { get; set; }
        public Item? I05_Heaven { get; set; }

        public Item? I06_Door { get; set; }
        public Item? I06_Seal { get; set; }
        public Item? I06_Sign { get; set; }
        public Item? I06_Door_Blue { get; set; }
        public Item? I06_Door_Red { get; set; }
        public Item? I06_Door_Wide { get; set; }
        public Item? I06_Door_White { get; set; }
        public Item? I06_Letters { get; set; }

        public Item? I07_Door { get; set; }
        public Item? I07_Door_Blue { get; set; }
        public Item? I07_Door_Green { get; set; }

        public Item? I08_Clothes_Line { get; set; }
        public Item? I08_Underpants { get; set; }
        public Item? I08_Well { get; set; }
        public Item? I08_Wooden_Cover { get; set; }
        public Item? I08_Water { get; set; }
        public Item? I00_Coin { get; set; }
        public Item? I08_Washing_Machine { get; set; }
        public Item? I08_Clothes { get; set; }
        public Item? I08_Machine_For_Hanging_Up_Laundry { get; set; }
        public Item? I08_Laundry_Basket { get; set; }
        public Item? I08_Door_Green { get; set; }


        public Item? I09_Red_Shelf { get; set; }
        public Item? I09_Green_Shelf { get; set; }
        public Item? I09_Librarians_Desk { get; set; }
        public Item? I09_Angry_Book { get; set; }
        public Item? I09_Crazy_Book { get; set; }
        public Item? I09_Demonic_Book { get; set; }
        public Item? I09_Satanic_Book { get; set; }
        public Item? I09_Weird_Book { get; set; }
        public Item? I09_Sign { get; set; }
        public Item? I09_Carton { get; set; }
        public Item? I09_Books_Master { get; set; }
        public Item? I09_Library_Door { get; set; }

        public Item? I10_Labor_Table { get; set; }
        public Item? I10_Cages { get; set; }
        public Item? I10_First_Aid_Kit { get; set; }
        public Item? I10_Drawer { get; set; }
        public Item? I10_Bracket { get; set; }
        public Item? I10_Metall_Tray { get; set; }
        public Item? I10_Darkness_Machine { get; set; }
        public Item? I10_Hatch { get; set; }
        public Item? I10_Opening { get; set; }
        public Item? I10_Switch { get; set; }
        public Item? I10_Giant_Mortar { get; set; }
        public Item? I10_Labor_Door { get; set; }

        public Item? I11_Left_Shelf { get; set; }
        public Item? I11_Right_Shelf { get; set; }
        public Item? I11_Bird_Stand { get; set; }
        public Item? I11_Door_Blue { get; set; }
        public Item? I11_Clutter { get; set; }

        public Item? I12_Matress { get; set; }
        public Item? I12_Door{ get; set; }
        public Item? I12_Bed { get; set; }

        public Item? I12_Wardrobe { get; set; }

        public Item? I13_Drawer { get; set; }
        public Item? I13_Cupboard { get; set; }
        public Item? I13_Fridge { get; set; }
        public Item? I13_Freezer { get; set; }
        public Item? I13_Door_White { get; set; }
        public Item? I13_Sideboard { get; set; }

        public Item? I14_Mirror { get; set; }
        public Item? I14_Writing { get; set; }
        public Item? I14_Sink { get; set; }
        public Item? I14_Tiles { get; set; }
        public Item? I14_Special_Tile { get; set; }
        public Item? I14_Opening { get; set; }
        public Item? I14_Bathtub { get; set; }
        public Item? I14_Toilet { get; set; }
        public Item? I14_Flushing { get; set; }
        public Item? I14_Door_Red{ get; set; }

        public int iStatus_Lantern;

        public int iStatus_Lantern_Count;

        public int iStatus_Locked;

        public int iStatus_Counter_Door;

        public Status? Status_Tuer_Labor;
        public Status? Status_Tuer_Schlafkammer;
        public Status? Status_Tuer_Bibliothek;
        public Status? Status_Kerzenhalter;
        public Status? Status_Eule_Klaue;
        public Status? Status_Ritterruestung_Klaue;
        public Status? Status_Schlange_Klaue;
        public Status? Status_Elster_Klaue;
        public Status? Status_Fisch_Klaue;
        public Status? Status_Papagei_Klaue;
        public Status? Status_Skelett_Klaue;

        public Status? Status_Tuer_Schlafkammer_angeschaut;

        public Status? Status_Antwort_Unterwaesche;
        public Status? Status_Antwort_Ruestung;
        public Status? Status_Antwort_Lieblingstier;
        public Status? Status_Coin_Taken;
        public Status? Status_Fish_Coin;
        public Status? Status_Coin_Entdeckt;
        public Status? Status_Schale_Befestigt;
        public Status? Status_Elster_Tauschintro;
        public Status? Status_Klaue_Nehmversuch;
        public Status? Status_Quiz_Start;
        public Status? Status_Rezept_Gelesen;

        public Score? Score_Beutelchen;         // set
        public Score? Score_Kerzenhalter;       // set
        public Score? Score_Transfer1; // set
        public Score? Score_Zuckerzange;    // set
        public Score? Score_Kaese;  // set
        public Score? Score_Polierlappen; // set
        public Score? Score_Plastiktuete; // set
        public Score? Score_Schluessel; // set
        public Score? Score_Erste_Belebung; // set
        public Score? Score_Erstes_Gespraech; // set
        public Score? Score_Tuer_eintreten; // set
        public Score? Score_Tuer_aufschliessen; // Set
        public Score? Score_Rollpflaster;   // Set
        public Score? Score_Klauenzange1; // Set
        public Score? Score_Klauenzange2; // Set
        public Score? Score_Antwort_Unterwaesche; // Set
        public Score? Score_Antwort_Ruestung; // Set
        public Score? Score_Antwort_Tier; // Set
        public Score? Score_Bibliothek_offen; // Set
        public Score? Score_Buch;           // set
        public Score? Score_Deckel;        // set
        public Score? Score_Muenze; // set
        public Score? Score_Muenze_Gefunden; // set
        public Score? Score_Polierter_Stein; // set
        public Score? Score_Lichtloser_Stein; // set
        public Score? Score_Mondstein; // set
        public Score? Score_Schwamm;  // set
        public Score? Score_Schlacke;   // set
        public Score? Score_Meues_Pulver;
        public Score? Score_Transfer2; // set
        public Score? Score_Schale_Befestigung; // set

        public int imc_Suche_Versteck = 2;
        public int imc_Pentagramm = 3;
        public int imc_Klaue_nicht_nehmbar = 4;
        public int imc_Rede_Tote_Eule = 5;
        public int imc_Rede_Tote_Ruestung = 6;
        public int imc_Zuckerzange = 7;
        public int imc_Kaese = 8;
        public int imc_Klauenzange_fixieren = 9;
        public int imc_Start = 10;
        public int imc_Atrium_Ankunft = 11;
        public int imc_Klaue_nicht_fixiert = 12;
        public int imc_Klaue_noch_niemand_belebt = 13;
        public int imc_Klaue_noch_niemand_gesprochen = 14;
        public int imc_Klaue_ok_Exit = 15;
        public int imc_Uhu_Fragen = 20;
        public int imc_Uhu_Fragen_Unterwaesche = 21;
        public int imc_Uhu_Fragen_Ruestung = 22;
        public int imc_Uhu_Fragen_Tier = 23;
        public int imc_Neues_Pulver_Wie = 24;
        public int imc_Mondstein_Woher = 25;
        public int imc_Schwamm_Woher = 26;
        public int imc_Goldmuenze_Woher = 27;
        public int imc_Muenze_Bergen_Wie = 28;
        public int imc_Kaese_Wozu = 29;
        public int imc_Kiesel_Wozu = 30;
        public int imc_Lichtloser_Stein_Wozu = 31;
        public int imc_Sporen_Wozu = 32;
        public int imc_Alle_Zutaten_da = 33;
        public int imc_Schlacke_Wozu = 34;
        public int imc_Neues_Pulver_Wozu = 35;
        public int imc_Ende = 36;
        public int imc_Kaese_Not_Found = 37;
        public int imc_Goldmuenze_Woher2 = 38;



        public CoAdv()
        {
            L01_Dark_Forest = SerialNumberGenerator.Instance.NextSerial;
            L02_In_Front_Of_A_Hut = SerialNumberGenerator.Instance.NextSerial;
            L03_In_The_Parlor = SerialNumberGenerator.Instance.NextSerial;
            L04_Shabby_Little_Chamber = SerialNumberGenerator.Instance.NextSerial;
            L05_Atrium = SerialNumberGenerator.Instance.NextSerial;
            L06_Long_Floor = SerialNumberGenerator.Instance.NextSerial;
            L07_Lower_Floor = SerialNumberGenerator.Instance.NextSerial;
            L08_Laundry_Room = SerialNumberGenerator.Instance.NextSerial;
            L09_Library = SerialNumberGenerator.Instance.NextSerial;
            L10_Laboratory = SerialNumberGenerator.Instance.NextSerial;
            L11_Storage_Room = SerialNumberGenerator.Instance.NextSerial;
            L12_Sleeping_Room = SerialNumberGenerator.Instance.NextSerial;
            L13_Kitchen = SerialNumberGenerator.Instance.NextSerial;
            L14_Bathroom = SerialNumberGenerator.Instance.NextSerial;
            L15_Nowhere = SerialNumberGenerator.Instance.NextSerial;


            PL_Use = SerialNumberGenerator.Instance.NextSerial;
            PL_Use_W = SerialNumberGenerator.Instance.NextSerial;
            PL_Throw = SerialNumberGenerator.Instance.NextSerial;
            PL_ThrowMC = SerialNumberGenerator.Instance.NextSerial;
            PL_Throw_Out = SerialNumberGenerator.Instance.NextSerial;
            PL_Throw_In = SerialNumberGenerator.Instance.NextSerial;
            PL_Draw = SerialNumberGenerator.Instance.NextSerial;
            PL_DrawOut = SerialNumberGenerator.Instance.NextSerial;
            PL_DrawOff = SerialNumberGenerator.Instance.NextSerial;
            PL_Draw_Down= SerialNumberGenerator.Instance.NextSerial;
            PL_Push = SerialNumberGenerator.Instance.NextSerial;
            PL_Push_To = SerialNumberGenerator.Instance.NextSerial;
            PL_Push_Up = SerialNumberGenerator.Instance.NextSerial;
            PL_Unlock_W_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Say_To_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Say_To_P2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Say_To_I = SerialNumberGenerator.Instance.NextSerial;
            PL_Say_To_I2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Demand_From_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Give_To_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Show_To_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Give_To_P2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Show_To_P2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Plea_From_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Read = SerialNumberGenerator.Instance.NextSerial;
            PL_Untighten = SerialNumberGenerator.Instance.NextSerial;
            PL_Break = SerialNumberGenerator.Instance.NextSerial;
            PL_Break_Down = SerialNumberGenerator.Instance.NextSerial;
            PL_Use_W_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Unscrew_W = SerialNumberGenerator.Instance.NextSerial;
            PL_Unscrew_W2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Truncate_W = SerialNumberGenerator.Instance.NextSerial;
            PL_Mount = SerialNumberGenerator.Instance.NextSerial;
            PL_Saw = SerialNumberGenerator.Instance.NextSerial;
            PL_Saw2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Cut = SerialNumberGenerator.Instance.NextSerial;
            PL_Tie = SerialNumberGenerator.Instance.NextSerial;
            PL_Tie_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Tie_P2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Fish = SerialNumberGenerator.Instance.NextSerial;
            PL_Light = SerialNumberGenerator.Instance.NextSerial;
            PL_Extinguish = SerialNumberGenerator.Instance.NextSerial;
            PL_Grab = SerialNumberGenerator.Instance.NextSerial;
            PL_Eat = SerialNumberGenerator.Instance.NextSerial;
            PL_Eat_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Fill = SerialNumberGenerator.Instance.NextSerial;
            PL_Fill2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Pick = SerialNumberGenerator.Instance.NextSerial;
            PL_Stuff = SerialNumberGenerator.Instance.NextSerial;
            PL_Sell = SerialNumberGenerator.Instance.NextSerial;
            PL_SellTo = SerialNumberGenerator.Instance.NextSerial;
            PL_CatchP = SerialNumberGenerator.Instance.NextSerial;
            PL_Touch = SerialNumberGenerator.Instance.NextSerial;
            PL_Drink = SerialNumberGenerator.Instance.NextSerial;
            PL_DrinkFrom = SerialNumberGenerator.Instance.NextSerial;
            PL_TouchMC = SerialNumberGenerator.Instance.NextSerial;
            PL_DrinkMC = SerialNumberGenerator.Instance.NextSerial;
            PL_Knock = SerialNumberGenerator.Instance.NextSerial;
            PL_Knock2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Knock_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Spit = SerialNumberGenerator.Instance.NextSerial;
            PL_SpitP = SerialNumberGenerator.Instance.NextSerial;
            PL_SpitDown = SerialNumberGenerator.Instance.NextSerial;
            PL_Listen = SerialNumberGenerator.Instance.NextSerial;
            PL_Listen_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Listen_Person = SerialNumberGenerator.Instance.NextSerial;
            PL_Listen_Topic = SerialNumberGenerator.Instance.NextSerial;
            PL_AttachTo = SerialNumberGenerator.Instance.NextSerial;
            PL_HangTo = SerialNumberGenerator.Instance.NextSerial;
            PL_ClimbUpMC = SerialNumberGenerator.Instance.NextSerial;
            PL_ClimbUp = SerialNumberGenerator.Instance.NextSerial;
            PL_ClimbDown2 = SerialNumberGenerator.Instance.NextSerial;
            PL_ClimbDown = SerialNumberGenerator.Instance.NextSerial;
            PL_ClimbOn = SerialNumberGenerator.Instance.NextSerial;
            PL_ClimbThrough = SerialNumberGenerator.Instance.NextSerial;
            PL_ClimbIn = SerialNumberGenerator.Instance.NextSerial;
            PL_Dip = SerialNumberGenerator.Instance.NextSerial;
            PL_Tip = SerialNumberGenerator.Instance.NextSerial;
            PL_Tip_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Arrest = SerialNumberGenerator.Instance.NextSerial;
            PL_ArrestW = SerialNumberGenerator.Instance.NextSerial;
            PL_Blow = SerialNumberGenerator.Instance.NextSerial;
            PL_BlowWith = SerialNumberGenerator.Instance.NextSerial;
            PL_Poison = SerialNumberGenerator.Instance.NextSerial;
            PL_Compare = SerialNumberGenerator.Instance.NextSerial;
            PL_Follow = SerialNumberGenerator.Instance.NextSerial;
            PL_Jump = SerialNumberGenerator.Instance.NextSerial;
            PL_Jump_In = SerialNumberGenerator.Instance.NextSerial;
            PL_Jump_On = SerialNumberGenerator.Instance.NextSerial;
            PL_Jump_Through = SerialNumberGenerator.Instance.NextSerial;
            PL_Turn = SerialNumberGenerator.Instance.NextSerial;
            PL_Mix = SerialNumberGenerator.Instance.NextSerial;
            PL_Pluck = SerialNumberGenerator.Instance.NextSerial;
            PL_Suck = SerialNumberGenerator.Instance.NextSerial;
            PL_Suck2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Sit1 = SerialNumberGenerator.Instance.NextSerial;
            PL_Sit2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Sit3 = SerialNumberGenerator.Instance.NextSerial;
            PL_Sit4 = SerialNumberGenerator.Instance.NextSerial;

            PL_Lay1 = SerialNumberGenerator.Instance.NextSerial;
            PL_Lay2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Lay3 = SerialNumberGenerator.Instance.NextSerial;
            PL_Lay4 = SerialNumberGenerator.Instance.NextSerial;

            PL_Exchange = SerialNumberGenerator.Instance.NextSerial;
            PL_Crumble = SerialNumberGenerator.Instance.NextSerial;
            PL_Crumble_in = SerialNumberGenerator.Instance.NextSerial;
            PL_Abandon = SerialNumberGenerator.Instance.NextSerial;
            PL_Kiss_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Press = SerialNumberGenerator.Instance.NextSerial;
            PL_Press_In = SerialNumberGenerator.Instance.NextSerial;
            PL_Press_On = SerialNumberGenerator.Instance.NextSerial;
            PL_Ring = SerialNumberGenerator.Instance.NextSerial;
            PL_Dress = SerialNumberGenerator.Instance.NextSerial;
            PL_DrawShut = SerialNumberGenerator.Instance.NextSerial;
            PL_Undress = SerialNumberGenerator.Instance.NextSerial;
            PL_DrawWith = SerialNumberGenerator.Instance.NextSerial;
            PL_Free = SerialNumberGenerator.Instance.NextSerial;
            PL_Meditate_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Soil = SerialNumberGenerator.Instance.NextSerial;
            PL_Smear2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Pour = SerialNumberGenerator.Instance.NextSerial;
            PL_Pour2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Stir = SerialNumberGenerator.Instance.NextSerial;
            PL_Stir2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Park = SerialNumberGenerator.Instance.NextSerial;
            PL_PlaceTo = SerialNumberGenerator.Instance.NextSerial;
            PL_PlaceToP = SerialNumberGenerator.Instance.NextSerial;
            PL_Pinch = SerialNumberGenerator.Instance.NextSerial;
            PL_BuryP = SerialNumberGenerator.Instance.NextSerial;
            PL_BuryPSolo = SerialNumberGenerator.Instance.NextSerial;
            PL_Beat = SerialNumberGenerator.Instance.NextSerial;
            PL_BeatW = SerialNumberGenerator.Instance.NextSerial;
            PL_Cuddle = SerialNumberGenerator.Instance.NextSerial;
            PL_Fuck = SerialNumberGenerator.Instance.NextSerial;
            PL_Pray = SerialNumberGenerator.Instance.NextSerial;
            PL_Bend = SerialNumberGenerator.Instance.NextSerial;
            PL_Leverage = SerialNumberGenerator.Instance.NextSerial;
            PL_Scroll = SerialNumberGenerator.Instance.NextSerial;
            PL_Count = SerialNumberGenerator.Instance.NextSerial;
            PL_Breath = SerialNumberGenerator.Instance.NextSerial;
            PL_Make_On = SerialNumberGenerator.Instance.NextSerial;
            PL_Make_Off = SerialNumberGenerator.Instance.NextSerial;
            PL_Spray = SerialNumberGenerator.Instance.NextSerial;
            PL_Spray_Solo = SerialNumberGenerator.Instance.NextSerial;

            PL_Kill = SerialNumberGenerator.Instance.NextSerial;
            PL_KillW = SerialNumberGenerator.Instance.NextSerial;
            PL_Pet = SerialNumberGenerator.Instance.NextSerial;
            PL_Tickle = SerialNumberGenerator.Instance.NextSerial;
            PL_TickleW = SerialNumberGenerator.Instance.NextSerial;
            PL_Joggle = SerialNumberGenerator.Instance.NextSerial;
            PL_Sleep = SerialNumberGenerator.Instance.NextSerial;
            PL_Sleep2= SerialNumberGenerator.Instance.NextSerial;
            PL_Sleep3 = SerialNumberGenerator.Instance.NextSerial;
            PL_Spark = SerialNumberGenerator.Instance.NextSerial;
            PL_Leave = SerialNumberGenerator.Instance.NextSerial;
            PL_Determine = SerialNumberGenerator.Instance.NextSerial;
            PL_Remove = SerialNumberGenerator.Instance.NextSerial;
            PL_Clean = SerialNumberGenerator.Instance.NextSerial;
            PL_Split = SerialNumberGenerator.Instance.NextSerial;
            PL_Wash = SerialNumberGenerator.Instance.NextSerial;
            PL_Wear = SerialNumberGenerator.Instance.NextSerial;
            PL_Wrap = SerialNumberGenerator.Instance.NextSerial;
            PL_Wrap2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Paint = SerialNumberGenerator.Instance.NextSerial;

            PL_AttachSolo = SerialNumberGenerator.Instance.NextSerial;
            PL_Clean_Solo= SerialNumberGenerator.Instance.NextSerial;
            PL_Clean_W = SerialNumberGenerator.Instance.NextSerial;
            PL_Cut_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Demand_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Determine_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_ExchangeSolo = SerialNumberGenerator.Instance.NextSerial;
            PL_Fill_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Give_Solo= SerialNumberGenerator.Instance.NextSerial;
            PL_Give_To_I = SerialNumberGenerator.Instance.NextSerial;
            PL_GrabSolo = SerialNumberGenerator.Instance.NextSerial;
            PL_HangSolo = SerialNumberGenerator.Instance.NextSerial;
            PL_MixSolo = SerialNumberGenerator.Instance.NextSerial;
            PL_Paint_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Plea_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_PoisonSolo= SerialNumberGenerator.Instance.NextSerial;
            PL_Puncture_Solo= SerialNumberGenerator.Instance.NextSerial;
            PL_Show_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_SmearSolo= SerialNumberGenerator.Instance.NextSerial;
            PL_Spark_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Throw_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Throw_Person = SerialNumberGenerator.Instance.NextSerial;
            PL_TieSolo = SerialNumberGenerator.Instance.NextSerial;
            PL_Wash_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Wrap_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_AskSolo= SerialNumberGenerator.Instance.NextSerial;
            PL_Place_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Place_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Search = SerialNumberGenerator.Instance.NextSerial;
            PL_SearchW= SerialNumberGenerator.Instance.NextSerial;
            PL_Poke = SerialNumberGenerator.Instance.NextSerial;
            PL_Dig = SerialNumberGenerator.Instance.NextSerial;
            PL_Wake = SerialNumberGenerator.Instance.NextSerial;
            PL_Shout = SerialNumberGenerator.Instance.NextSerial;
            PL_Slide = SerialNumberGenerator.Instance.NextSerial;
            PL_Attack = SerialNumberGenerator.Instance.NextSerial;

            PL_MixReverse = SerialNumberGenerator.Instance.NextSerial;
            PL_MixIn= SerialNumberGenerator.Instance.NextSerial;
            PL_Accede = SerialNumberGenerator.Instance.NextSerial;
            PL_Be = SerialNumberGenerator.Instance.NextSerial;
            PL_Repair = SerialNumberGenerator.Instance.NextSerial;
            PL_Sort = SerialNumberGenerator.Instance.NextSerial;
            PL_Confess = SerialNumberGenerator.Instance.NextSerial;
            PL_Stroke = SerialNumberGenerator.Instance.NextSerial;
            PL_SwitchOff = SerialNumberGenerator.Instance.NextSerial;
            PL_SwitchOn = SerialNumberGenerator.Instance.NextSerial;
            PL_Lift = SerialNumberGenerator.Instance.NextSerial;
            PL_Wipe = SerialNumberGenerator.Instance.NextSerial;
            PL_WipeW = SerialNumberGenerator.Instance.NextSerial;
            PL_Exits = SerialNumberGenerator.Instance.NextSerial;
            PL_Steal = SerialNumberGenerator.Instance.NextSerial;
            PL_Score = SerialNumberGenerator.Instance.NextSerial;
            PL_StealP = SerialNumberGenerator.Instance.NextSerial;
            PL_StealWP = SerialNumberGenerator.Instance.NextSerial;

            PL_Destroy = SerialNumberGenerator.Instance.NextSerial;
            PL_Chop = SerialNumberGenerator.Instance.NextSerial;
            PL_ChopW = SerialNumberGenerator.Instance.NextSerial;
            PL_Plunge = SerialNumberGenerator.Instance.NextSerial;
            PL_Plunge_Out = SerialNumberGenerator.Instance.NextSerial;
            PL_RollIn = SerialNumberGenerator.Instance.NextSerial;
            PL_Roll_Solo = SerialNumberGenerator.Instance.NextSerial;
            PL_Demolish = SerialNumberGenerator.Instance.NextSerial;
            PL_GlueTo = SerialNumberGenerator.Instance.NextSerial;
            PL_Heat = SerialNumberGenerator.Instance.NextSerial;
            PL_HeatW = SerialNumberGenerator.Instance.NextSerial;
            PL_Pulverize = SerialNumberGenerator.Instance.NextSerial;
            PL_Pulverize_W = SerialNumberGenerator.Instance.NextSerial;
            PL_Tidy = SerialNumberGenerator.Instance.NextSerial;
            PL_BrushW = SerialNumberGenerator.Instance.NextSerial;

            PL_Type = SerialNumberGenerator.Instance.NextSerial;
            PL_Fry = SerialNumberGenerator.Instance.NextSerial;
            PL_Form = SerialNumberGenerator.Instance.NextSerial;
            PL_FormFrom = SerialNumberGenerator.Instance.NextSerial;
            PL_Dance_Person = SerialNumberGenerator.Instance.NextSerial;
            PL_Dance = SerialNumberGenerator.Instance.NextSerial;
            PL_Hang = SerialNumberGenerator.Instance.NextSerial;
            PL_Hang2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Swing2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Swing = SerialNumberGenerator.Instance.NextSerial;
            PL_Store = SerialNumberGenerator.Instance.NextSerial;

            PL_SingSolo = SerialNumberGenerator.Instance.NextSerial;
            PL_Sing = SerialNumberGenerator.Instance.NextSerial;
            PL_Lick = SerialNumberGenerator.Instance.NextSerial;
            PL_Hide = SerialNumberGenerator.Instance.NextSerial;
            PL_Hide_P = SerialNumberGenerator.Instance.NextSerial;

            PL_Burn = SerialNumberGenerator.Instance.NextSerial;
            PL_Burn_W = SerialNumberGenerator.Instance.NextSerial;
            PL_Burn_In = SerialNumberGenerator.Instance.NextSerial;
            PL_Smoke = SerialNumberGenerator.Instance.NextSerial;
            PL_Tear = SerialNumberGenerator.Instance.NextSerial;
            PL_Testwindow = SerialNumberGenerator.Instance.NextSerial;
            PL_Brief = SerialNumberGenerator.Instance.NextSerial;
            PL_Verbose = SerialNumberGenerator.Instance.NextSerial;
            PL_Credits = SerialNumberGenerator.Instance.NextSerial;
            PL_Manual = SerialNumberGenerator.Instance.NextSerial;
            PL_Phone = SerialNumberGenerator.Instance.NextSerial;
            PL_PhoneW = SerialNumberGenerator.Instance.NextSerial;
            PL_Illustration = SerialNumberGenerator.Instance.NextSerial;
            PL_Undo = SerialNumberGenerator.Instance.NextSerial;

            PL_LightW = SerialNumberGenerator.Instance.NextSerial;
            PL_EnlightW = SerialNumberGenerator.Instance.NextSerial;

            iStatus_Lantern = SerialNumberGenerator.Instance.NextSerial;
            iStatus_Lantern_Count = SerialNumberGenerator.Instance.NextSerial;
            iStatus_Locked = SerialNumberGenerator.Instance.NextSerial;
            iStatus_Counter_Door = SerialNumberGenerator.Instance.NextSerial;
        }
    }
}
