using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

using Phoney_MAUI.Model;
using Phoney_MAUI.Core;

namespace GameCore
{
    [Serializable]

    public class locationAdd
    {

        public int Stat { get; set;  }

        public int Val { get; set; }

        public string? Loca { get; set; }
        private string? _text;

        [JsonIgnore]

        public string? Text
        {
            get
            {
                return loca.TextOrLoca(_text, Loca) as string;
            }
            set
            {
                _text = value;
            }
        }


        public locationAdd( int Stat, int Val, string Text )
        {
            this.Stat = Stat;
            this.Val = Val;
            this.Text = Text;
        }
        public static locationAdd locationAddLoca(int Stat, int Val, string Text)
        {
            locationAdd la = new(Stat, Val, null!);

            la.Loca = Text;

            return la;
        }
    }

    [Serializable]

    public class location
    {

        public string? LocaLocNameHandle { get; set; }
        public string? LocaLocName { get; set; }
        public string? LocaLocDesc { get; set; }
        public string? LocaLocDescRaw { get; set; }
        private string? _locName;
        private string? _locDescription;
        private string? _locDescRaw;
        public string? _locDescRawHandle;

        [JsonIgnore]
        public string? LocName
        {
            get
            {
                return loca.TextOrLoca(_locName, LocaLocName,LocaLocNameHandle)!;
            }
            set
            {
                _locName = value;
            }
        }
        [JsonIgnore]
       public string? LocDescription
        {
            get
            {
                return _locDescription;
            }
            set
            {
                _locDescription= value;
            }
        }
        public string? LocDescRaw
        {
            get
            {
                return loca.TextOrLoca(_locDescRaw, LocaLocDesc)!;
            }
            set
            {
                _locDescRaw = value;
            }
        }

        public string? LocPicture { get; set; }

        public int ID { get; set; }

        public int[] LocExit { get; set; }

        public int[] LocExitBlocker { get; set; }

        public bool Visited { get; set; }

        public List<locationAdd> locadd { get; set; } = new();

        [JsonIgnore][NonSerialized] protected DelAdvObject? controller;
        public string? controllerName;

        public bool ActivityBlocked { get; set; }
        [JsonConstructor]

        public location()
        {
            LocExit = new int[11];
            LocExitBlocker = new int[11];
        }

        public static location? locationLoca(int Index, string Name, string Description, int N, int NE, int E, int SE, int S, int SW, int W, int NW, int U, int D)
        {
            try
            {
                location l = new();

                l.LocaLocName = Name;
                l.ID = Index;
                l.locadd = new List<locationAdd>();

                l.LocDescRaw = Description;
                l.LocDescription = Helper.Insert(loca.GetLoca(l.LocDescRaw));

                l.LocExit = new int[11];
                l.LocPicture = null;

                l.LocExit[Co.DIR_N] = N;
                l.LocExit[Co.DIR_NE] = NE;
                l.LocExit[Co.DIR_E] = E;
                l.LocExit[Co.DIR_SE] = SE;
                l.LocExit[Co.DIR_S] = S;
                l.LocExit[Co.DIR_SW] = SW;
                l.LocExit[Co.DIR_W] = W;
                l.LocExit[Co.DIR_NW] = NW;
                l.LocExit[Co.DIR_U] = U;
                l.LocExit[Co.DIR_D] = D;

                l.LocExitBlocker = new int[11];

                for (int i = 0; i <= 10; i++)
                    l.LocExitBlocker[i] = 0;

                return (l);
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.locationLoca: " + e.Message.ToString(), IGlobalData.protMode.crisp);
                return null;
            }

        }
        public static location? locationLocaLoca(int Index, string NameHandle, string Name, string DescriptionHandle, string Description, int N, int NE, int E, int SE, int S, int SW, int W, int NW, int U, int D)
        {
            try
            {
                location l = new();

                l.LocaLocNameHandle = NameHandle;
                l.LocaLocName = Name;

                l.ID = Index;
                l.locadd = new List<locationAdd>();

                l._locDescRawHandle = DescriptionHandle;
                l.LocDescRaw = Description;
                l.LocDescription = Helper.Insert(l._locDescRawHandle);

                l.LocExit = new int[11];
                l.LocPicture = null;

                l.LocExit[Co.DIR_N] = N;
                l.LocExit[Co.DIR_NE] = NE;
                l.LocExit[Co.DIR_E] = E;
                l.LocExit[Co.DIR_SE] = SE;
                l.LocExit[Co.DIR_S] = S;
                l.LocExit[Co.DIR_SW] = SW;
                l.LocExit[Co.DIR_W] = W;
                l.LocExit[Co.DIR_NW] = NW;
                l.LocExit[Co.DIR_U] = U;
                l.LocExit[Co.DIR_D] = D;

                l.LocExitBlocker = new int[11];

                for (int i = 0; i <= 10; i++)
                    l.LocExitBlocker[i] = 0;

                return (l);
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.locationLocaLoca: " + e.Message.ToString(), IGlobalData.protMode.crisp);
                return null;
            }

        }

        public location(int Index, string Name, string Description, int N, int NE, int E, int SE, int S, int SW, int W, int NW, int U, int D)
        {
            try
            {
                LocName = Name;
                ID = Index;
                locadd = new List<locationAdd>();

                LocDescription = Helper.Insert(Description);
                // LocDescription = Description;

                LocExit = new int[11];
                LocPicture = null;

                LocExit[Co.DIR_N] = N;
                LocExit[Co.DIR_NE] = NE;
                LocExit[Co.DIR_E] = E;
                LocExit[Co.DIR_SE] = SE;
                LocExit[Co.DIR_S] = S;
                LocExit[Co.DIR_SW] = SW;
                LocExit[Co.DIR_W] = W;
                LocExit[Co.DIR_NW] = NW;
                LocExit[Co.DIR_U] = U;
                LocExit[Co.DIR_D] = D;

                LocExitBlocker = new int[11];

                for (int i = 0; i <= 10; i++)
                    LocExitBlocker[i] = 0;

            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.location: " + e.Message.ToString(), IGlobalData.protMode.crisp);
            }

        }


        public bool AddCondText( int Cond, int Val, string Text )
        {
            this.locadd.Add( new locationAdd( Cond, Val, Text ) );
            return (true);

        }
        public bool AddCondTextLoca(int Cond, int Val, string Text)
        {
            this.locadd.Add( locationAdd.locationAddLoca(Cond, Val, Text));
            this.locadd[this.locadd.Count - 1].Text = Helper.Insert(Text);
            return (true);

        }

        public void SetController(DelAdvObject controller)
        {
            this.controller = controller;
            if( controller != null )
                 this.controllerName = controller.Method.Name;
        }


        public DelAdvObject GetController()
        {
            return (this.controller!);
        }

        public string? GetControllerName()
        {
            return (this.controllerName!);
        }

        public bool SetControllerByName( string? controllerName, Adv AdvGame )
        {
#pragma warning disable CS0219 // Die Variable "success" ist zugewiesen, ihr Wert wird aber nie verwendet.
            bool success = true;
#pragma warning restore CS0219 // Die Variable "success" ist zugewiesen, ihr Wert wird aber nie verwendet.

            try
            {
                this.controller = (DelAdvObject)Delegate.CreateDelegate(typeof(DelAdvObject), AdvGame, this.controllerName!, false);
            }
            catch (Exception e)
            {
                GlobalData.AddLog("SetControllerByName: " + e.Message, IGlobalData.protMode.crisp);

                success = false;
            }
            return (false);
        }
    }

    [Serializable]

    public class locationList
    {
        [JsonIgnore]
        public GlobalData? GD
        {
            get => GlobalData.CurrentGlobalData;
            // set => GlobalData.CurrentGlobalData = value;
        }

        [JsonIgnore]
        public AdvData? A
        {
            get => GD!.Adventure!.A;
            // set => GD!.Adventure!.A = value;
        }
        [JsonIgnore]
        public PersonList? Persons
        {
            get => GD!.Adventure!.Persons;
            // set => GD!.Adventure!.Persons = value;
        }
        [JsonIgnore]
        public StatusList? Stats
        {
            get => GD!.Adventure!.Stats;
            // set => GD!.Adventure!.Stats = value;
        }
        [JsonIgnore]
        public ItemList? Items
        {
            get => GD!.Adventure!.Items;
            // set => GD!.Adventure!.Items = value;
        }
        [JsonIgnore]
        public Adv? AdvGame
        {
            get => GD!.Adventure;
            // set => GD!.Adventure = value;
        }
        [JsonIgnore]
        public VerbList? Verbs
        {
            get => GD!.Adventure!.Verbs;
            // set => GD!.Adventure!.Verbs = value;
        }
        [JsonIgnore]
        public VTList? VT
        {
            get => GD!.Adventure!.VerbTenses;
            // set => GD!.Adventure!.VT = value;
        }
        [JsonIgnore]
        public CoBase? CB
        {
            get => GD!.Adventure!.CB;
            // set => GD!.Adventure!.CB = value;
        }


        // [JsonIgnore][NonSerialized]  private Adv AdvGame;

        public Dictionary<int, location> List { get; set; }


        // [JsonIgnore]public ItemList Items { get; set; }

        // [JsonIgnore]public PersonList Persons { get; set; }

        // [JsonIgnore]public StatusList Stats { get; set; }

        // [JsonIgnore]public AdvData A { get; set; }
        // [NonSerialized] private MainWindow MW;
        // [JsonIgnore]public VerbList Verbs { get; set; }

        // [JsonIgnore]public VTList VT { get; set; }
        // private Grammar Grammar;
       // [JsonIgnore] public CoBase CB { get; set; }
        [JsonIgnore]private DelTextOutput? textOutput;



        private location? _lastlocation = null;


        public delegate bool DelTextOutput( string s);
        [JsonConstructor]

        public locationList( Adv AdvGame, AdvData A, ItemList Items, PersonList Persons, VerbList Verbs, CoBase CB, StatusList Stats, VTList VT )
        {
            List = new Dictionary<int, location>();
            // this.Items = Items;
            // this.Persons = Persons;
            // this.Verbs = Verbs;
            // this.CB = CB;
            // this.Stats = Stats;
            // this.A = A;
#pragma warning disable CS1717 // Zuweisung zur gleichen Variablen. Wollten Sie eine andere Zuweisung durchführen?
            this.textOutput = textOutput!;
#pragma warning restore CS1717 // Zuweisung zur gleichen Variablen. Wollten Sie eine andere Zuweisung durchführen?
            // this.VT = VT;
            // this.Grammar = Grammar;
            // this.MW = MW;
            // this.AdvGame = AdvGame;

            loca.GD!.AddLanguageCallback(RestoreLocations);

        }

        public void SetAdv(Adv AdvGame)
        {
            // this.AdvGame = AdvGame;
        }


        public int Count ()
        {
            return List.Count;
        }


        private string SubString( string s, int Pos, int Len )
        {

            string SubString = "";
            if( Pos < s.Length)
            {
                if( Pos + Len > s.Length )
                {
                    Len = s.Length - Pos;
                }
                SubString = s.Substring(Pos, Len);
            }
            return (SubString);
        }

        public void Add(location L)
        {
            if (List == null)
            {
                List = new Dictionary<int, location>();
            }
            // new this.GetType().GetConstructor();
            List.Add(key: L.ID, value: L);
            _lastlocation = L;
            // List.Add(L);
        }


        public location Last( )
        {
            return _lastlocation!;

            // return (List[List.Count - 1]);
        }

        public bool RestoreLocationAdds( location l)
        {
            try
            {
                if (l.locadd != null)
                {
                    List<locationAdd>? l2 = new List<locationAdd>();

                    foreach (locationAdd la in l.locadd)
                    {
                        l2.Add(la);
                        if (la.Loca != null)
                            l2[l2.Count - 1].Text = Helper.Insert(la.Loca);
                    }

                    l.locadd = l2;
                    l2 = null;
                }
                return true;
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.RestoreLocationAdds: " + e.Message.ToString(), IGlobalData.protMode.crisp);
                return false;
            }

        }

        public bool RestoreLocations()
        {
            try
            {
                IDictionary<int, location>? TList2 = new Dictionary<int, location>();

                foreach (var ele in List!.Values)
                {
                    location ele2 = (location)ele;

                    TypeInfo x = typeof(loca).GetTypeInfo();
                    if (ele.LocaLocName != null)
                    {
                        PropertyInfo? pi = x.GetProperty(ele.LocaLocName);

                        string? s = (string?)pi!.GetValue(null);

                        ele2.LocaLocNameHandle = s;
                    }
                    if (ele2.LocaLocName != null)
                        ele2.LocName = Helper.Insert(loca.GetLoca(ele2.LocaLocName));

                    if (ele2.LocDescRaw != null)
                        ele2.LocDescription = Helper.Insert(loca.GetLoca(ele2.LocDescRaw));

                    TList2.Add(key: ele2.ID!, value: ele2);
                    // TList2.Add(key: ele2.Name, value: ele2);
                    RestoreLocationAdds(ele2);
                }


                /*
                foreach (var ele in List.Values)
                {
                    location ele2 = (location)ele;

                    if( ele2._locDescRawHandle != null )
                        ele2.LocDescription = Helper.Insert(ele2._locDescRawHandle);

                    TList2.Add(key: ele2.ID, value: ele2);

                    RestoreLocationAdds(ele2);
                }
                */
                List = (Dictionary<int, location>)TList2;
                TList2 = null;

                return true;
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.RestoreLocations: " + e.Message.ToString(), IGlobalData.protMode.crisp);
                return false;
            }
        }



        public location? Find( int locationID )
        {
            if (List.ContainsKey(locationID))
                return List[locationID];
            return null;
            /*
            location l = null;

            foreach( location ele in List ) 
            {
                if( ele.ID == locationID )
                {
                    l = ele;
                    break;
                }
            }
            return l;
            */
        }



        public bool FindRouteStep( int locationID, int tActLoc, int From, List<int> Route, List<string> RouteName, List<int> Visited, bool OnlyKnownLocs )
        {
            try
            {
                bool found = false;

                for (int i = 1; i <= 10; i++)
                {
                    if ((Find(tActLoc)!.LocExit[i] == locationID) && (Find(tActLoc)!.LocExitBlocker[i] == 0))
                    {
                        if ((Find(Find(tActLoc)!.LocExit[i])!.Visited) || (OnlyKnownLocs == false))
                        {
                            RouteName.Insert(0, Find(locationID)!.LocName!);
                            RouteName.Insert(0, Find(Find(tActLoc)!.LocExit[i]!)!.LocName!);
                            Route.Insert(0, i);
                            return (true);
                        }
                    }
                    else if ((Find(tActLoc!)!.LocExit[i] == From) && (Find(tActLoc!)!.LocExitBlocker[i] == 0))
                    {
#pragma warning disable CS0219 // Die Variable "a" ist zugewiesen, ihr Wert wird aber nie verwendet.
                        int a = 4;
#pragma warning restore CS0219 // Die Variable "a" ist zugewiesen, ihr Wert wird aber nie verwendet.
                        // Richtig, hier passiert gar nix
                    }
                    else if ((Find(tActLoc)!.LocExit[i]! != 0) && (Find(tActLoc)!.LocExitBlocker[i]! == 0))
                    {
                        if ((Find(Find(tActLoc)!.LocExit[i])!.Visited) || (OnlyKnownLocs == false))
                        {
                            bool WasThere = false;

                            for (int j = 0; j < Visited.Count; j++)
                            {
                                if (Find(tActLoc)!.LocExit[i]! == Visited[j])
                                {
                                    WasThere = true;
                                    break;
                                }
                            }

                            if (!WasThere)
                            {
                                Visited.Add(Find(tActLoc)!.LocExit[i]!);

                                found = FindRouteStep(locationID, Find(tActLoc)!.LocExit[i], tActLoc, Route, RouteName, Visited, OnlyKnownLocs);
                                if (found)
                                {
                                    RouteName.Insert(0, Find(Find(tActLoc)!.LocExit[i])!.LocName!);
                                    Route.Insert(0, i);
                                    return (found);
                                }
                            }
                        }
                    }
                }
                return found;
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.FindRouteStep: " + e.Message.ToString(), IGlobalData.protMode.crisp);
                return false;
            }

        }


        public List<int>? FindRoute( Person? PersonID, int locationID, bool OnlyKnowLocs = false )
        {
            try
            {
                bool found = false;
                List<int> Visited = new List<int>();

                List<int> Route = new List<int>();
                List<string> RouteName = new List<string>();

                Visited.Add(Persons!.Find(PersonID!)!.locationID!);
                found = FindRouteStep(locationID, Persons!.Find(PersonID!)!.locationID, Persons!.Find(PersonID!)!.locationID, Route, RouteName, Visited, OnlyKnowLocs);

                return (Route);
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.FindRoute: " + e.Message.ToString(), IGlobalData.protMode.crisp);
                return null;
            }

        }

        public location Act( )
        {
            return (Find( A!.ActLoc!)!);
        }

        public location LocPersonAct( Person PersonID )
        {

            return (Find(Persons!.Find( PersonID )!.locationID )!);
        }

        public bool Dolocations()
        {
            try
            {
                bool success = true;

                foreach (location l in this.List.Values)
                {
                    if (l.GetController() == null && l.GetControllerName() != null)
                    {
                        l.SetControllerByName(l!.GetControllerName()!, AdvGame!);
                    }


                    if ((l.GetController() != null) && (!l.ActivityBlocked))
                    {
                        l.GetController()(l.ID);
                    }
                }
                return (success);
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.Dolocations: " + e.Message.ToString(), IGlobalData.protMode.crisp);
                return false;
            }

        }


        public string GetDirection(int Dir)
        {
            if (Dir == Co.DIR_N)
                return ( loca.locationList_GetDirection_16125);
            else if (Dir == Co.DIR_NE)
                return ( loca.locationList_GetDirection_16126);
            else if (Dir == Co.DIR_E)
                return ( loca.locationList_GetDirection_16127);
            else if (Dir == Co.DIR_SE)
                return ( loca.locationList_GetDirection_16128);
            else if (Dir == Co.DIR_S)
                return ( loca.locationList_GetDirection_16129);
            else if (Dir == Co.DIR_SW)
                return ( loca.locationList_GetDirection_16130);
            else if (Dir == Co.DIR_W)
                return ( loca.locationList_GetDirection_16131);
            else if (Dir == Co.DIR_NW)
                return ( loca.locationList_GetDirection_16132);
            else if (Dir == Co.DIR_U)
                return ( loca.locationList_GetDirection_16133);
            else if (Dir == Co.DIR_D)
                return ( loca.locationList_GetDirection_16134);
            else
                return ( loca.locationList_GetDirection_16135);
        }

        public bool ListPersons(int LocType, int LocID)
        {
            try
            {
                foreach (Person tPerson in Persons!.List!.Values)
                {
                    if (tPerson.locationType == LocType && tPerson.locationID == LocID && tPerson.ID != A!.ActPerson && tPerson.IsBackground == false)
                    {
                        if ((tPerson.HereText != "") && (tPerson.HereText != null))
                            AdvGame!.StoryOutput(LocID, null, Persons!.GetPersonNameLink(tPerson.HereText, tPerson));
                        else if (tPerson.IsHidden == false)
                            AdvGame!.StoryOutput(LocID, null, Helper.Insert(loca.locationList_ListPersons_16136, tPerson));

                    }
                }
                return (true);
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.ListPersons: " + e.Message.ToString(), IGlobalData.protMode.crisp);
                return false;
            }

        }


        public void ShowLocation( int locationID, bool fullShow = false )
        {
            if (this.Find(locationID)!.Visited && AdvGame!.GD!.Brief && fullShow == false)
            {
                ShowLocationShort(locationID);
            }
            else
            {
                ShowLocationFull(locationID);
                this.Find(locationID)!.Visited = true;
            }
        }

        public void ShowLocationFull( int locationID )
        {
            try
            {
                List<Item> itemShowOn = new();
                List<Item> itemShowIn = new();
                int anzahlGefunden = 0;

                // int x = 4;

                // MW.TextOutput( " <a href =\"#\" onclick=\"document.getElementById('#eof').scrollIntoView(true);window.external.JSCallback('ActLoc');\">" + "<b>" + LOC[A!.ActLoc].LocName + "</b></a>");
                // Ignores: 003
                // AdvGame.StoryOutput(locationID, 0, " <a style=\"cursor:pointer\" onclick=\"document.getElementById('#eof').scrollntoView(true);window.external.JSCallback('ActLoc');\">" + "<b>" + this.Find( locationID ).LocName + "</b></a>");
#if CHROMIUM
            // Noloca: 007
            string scr = System.Web.HttpUtility.HtmlEncode( "boundAsync.JSCallback(\"ActLoc\");");
            // Ignores: 005 
            AdvGame.StoryOutput(locationID, null, " <a style='cursor:pointer' onclick='"+scr + "'><b></b></a>");


            if( AdvGame.A!.PicSize != AdvData.picSize.none && this.Find( locationID !)!.LocPicture != null )
            {
                string size = "20%";
                if( AdvGame.A!.PicSize == AdvData.picSize.medium )
                    size = "40%";
                if( AdvGame.A!.PicSize == AdvData.picSize.large )
                    size = "60%";

                string s1 = this.Find(locationID)!.LocPicture!;

                 
                // string s = string.Format( "<center><img src=\"localfolder:./{0}\" width=\"{1}\" align=\"middle\" /> </center>", this.Find( locationID ).LocPicture, size );
                string s = string.Format("<center><img src=\"customfileprotocol:./{0}\" width=\"{1}\" align=\"middle\" /> </center>", s1, size);

                AdvGame.StoryOutput(locationID, null, s);
            }
            /*
            if( locationID == AdvGame.CA!.L0_03_Thronsaal ||  locationID == AdvGame.CA!.LX_01_Hausflur )
            {
                string s = "<center><img src=\"localfolder:./l0_03.jpg\" width=\"400\" align=\"middle\" /> </center>";



            }
            */
#elif MAUI
                // Noloca: 007
                string scr = System.Web.HttpUtility.HtmlEncode("window.location.href = 'https://defineobject.Actloc/");
                // Ignores: 005 
                AdvGame!.StoryOutput(locationID, null, " <a style='cursor:pointer' onclick='" + scr + "'><b></b></a>");


                AdvGame!.UIS!.LoadPicToHtml(this.Find(locationID)!.LocPicture!);

                /*
                // Noloca: 007
                string scr = System.Web.HttpUtility.HtmlEncode("window.location.href = 'https://defineobject.Actloc/" );
                // Ignores: 005 
                AdvGame.StoryOutput(locationID, null, " <a style='cursor:pointer' onclick='" + scr + "'><b></b></a>");


                if (AdvGame.A!.PicSize != AdvData.picSize.none && this.Find(locationID!)!.LocPicture != null)
                {
                    string size = "20%";
                    if (AdvGame.A!.PicSize == AdvData.picSize.medium)
                        size = "40%";
                    if (AdvGame.A!.PicSize == AdvData.picSize.large)
                        size = "60%";

                    string s1 = this.Find(locationID)!.LocPicture!;


                    // string s = string.Format( "<center><img src=\"localfolder:./{0}\" width=\"{1}\" align=\"middle\" /> </center>", this.Find( locationID ).LocPicture, size );
                    string s = string.Format("<center><img src=\"customfileprotocol:./{0}\" width=\"{1}\" align=\"middle\" /> </center>", s1, size);

                    AdvGame.StoryOutput(locationID, null, s);
                }
                */
#else
            // Ignores: 004
            AdvGame.StoryOutput(locationID, null, loca.locationList_ShowlocationFull_16137);
#endif
                string sFull = GetLocName(this.Find(locationID!)!.LocDescription!)!;
                AdvGame.StoryOutput(locationID, null, sFull);
                for (int i = 0; i < this.Find(locationID!)!.locadd.Count; i++)
                {
                    if (Stats!.Find(this.Find(locationID!)!.locadd[i].Stat)!.Val == this.Find(locationID!)!.locadd[i].Val)
                    {
                        AdvGame.StoryOutput(locationID, null, this.Find(locationID)!.locadd[i].Text);

                    }
                }
                AdvGame.HeadlineOutput(GetLocName(this.Find(locationID!)!.LocName!));
                AdvGame.UIS.DoUIUpdate();
                ListPersons(AdvGame.CB!.LocType_Loc, locationID);

                foreach (Item item in Items!.List!.Values)
                {
                    if ((item.locationType == AdvGame.CB!.LocType_Loc) && (item.locationID == A!.ActLoc) && (item.IsBackground == false))
                    {
                        anzahlGefunden++;
                    }
                    if (item.locationType == AdvGame.CB!.LocType_Loc && item.locationID == A!.ActLoc && item.ShowStorageOn)
                    {
                        itemShowOn.Add(item);
                    }
                    if (item.locationType == AdvGame.CB!.LocType_Loc && item.locationID == A!.ActLoc && item.ShowStorageIn && item.IsClosed == false)
                    {
                        itemShowIn.Add(item);
                    }

                }
                /*
                for (int i = 0; i < Items!.List.Count; i++)
                {
                    if ((Items!.List[i].locationType == AdvGame.CB!.LocType_Loc) && (Items!.List[i].locationID == A!.ActLoc) && (Items!.List[i].IsBackground == false))
                    {
                        anzahlGefunden++;
                    }

                }
                */
                if (anzahlGefunden > 0)
                {
                    AdvGame.StoryOutput(locationID, null, Persons!.GetPersonVerbLink(Persons!.Find(A!.ActPerson!)!, Co.CASE_AKK, AdvGame.CB!.VT_sehen, AdvGame.CurrentNouns, A.Tense) + loca.locationList_ShowlocationFull_16138);

                    foreach (Item item in Items!.List.Values)
                    {
                        if ((item.locationType == AdvGame.CB!.LocType_Loc) && (item.locationID == A!.ActLoc) && (item.IsBackground == false))
                        {
                            AdvGame.StoryOutput(locationID, null, Helper.Insert(loca.locationList_ShowlocationFull_16139, item.ID));
                            anzahlGefunden++;
                        }

                    }
                    /*
                    for (int i = 0; i < Items!.List.Count; i++)
                    {
                        if ((Items!.List[i].locationType == AdvGame.CB!.LocType_Loc) && (Items!.List[i].locationID == A!.ActLoc) && (Items!.List[i].IsBackground == false))
                        {
                            AdvGame.StoryOutput(locationID, null,  Helper.Insert("- [Il1,Nomu]", Items!.List[i].ID ));
                            anzahlGefunden++;
                        }

                    }
                    */
                }

                foreach (Item i in itemShowOn)
                {
                    AdvGame!.Orders!.ListItemsPersons(Helper.Insert(loca.locationList_ShowlocationFull_16140, i.ID, AdvGame!.CA!.Person_3rdperson!), AdvGame!.CA!.Person_I!, CB!.LocType_On_Item, i.ID, false, true, Co.CASE_AKK_UNDEF);

                }
                foreach (Item i in itemShowIn)
                {
                    AdvGame!.Orders!.ListItemsPersons(Helper.Insert(loca.locationList_ShowlocationFull_Person_I_16141, i.ID, AdvGame!.CA!.Person_3rdperson!), AdvGame!.CA!.Person_I!, CB!.LocType_In_Item, i.ID, false, true, Co.CASE_AKK_UNDEF);
                }



                this.Find(locationID)!.Visited = true;
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.ShowLocationFull: " + e.Message.ToString(), IGlobalData.protMode.crisp);
            }

        }

        public void ShowLocationShort(int locationID)
        {
            try
            {
                int anzahlGefunden = 0;

#if CHROMIUM
            // Noloca: 003
            string scr = System.Web.HttpUtility.HtmlEncode( "boundAsync.JSCallback(\"ActLoc\");");
            AdvGame.StoryOutput(locationID, null, " <a style='cursor:pointer' onclick='" +scr + "'><b>" + this.Find(locationID)!.LocName + "</b></a>");
#elif MAUI
                // Noloca: 003
                string scr = System.Web.HttpUtility.HtmlEncode("window.location.href = 'https://defineobject.ActLoc/");
                AdvGame!.StoryOutput(locationID, null, " <a style='cursor:pointer' onclick='" + scr + "'><b>" + this.Find(locationID)!.LocName + "</b></a>");
#else
            // Noloca: 002
            AdvGame.StoryOutput(locationID, null, " <a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('ActLoc');\"><b></b></a>");
#endif
                // AdvGame.StoryOutput(locationID, null, " <a style=\"cursor:pointer\" onclick=\"document.getElementById('#eof').scrollIntoView(true);window.external.JSCallback('ActLoc');\">" + "<b>" + this.Find(locationID).LocName + "</b></a>");
                AdvGame.HeadlineOutput(GetLocName(this.Find(locationID)!.LocName!));
                ListPersons(AdvGame.CB!.LocType_Loc, locationID);

                foreach (Item item in Items!.List!.Values)
                {
                    if ((item.locationType == AdvGame.CB!.LocType_Loc) && (item.locationID == A!.ActLoc) && (item.IsBackground == false))
                    {
                        anzahlGefunden++;
                    }

                }
                /*
                for (int i = 0; i < Items!.List.Count; i++)
                {
                    if ((Items!.List[i].locationType == AdvGame.CB!.LocType_Loc) && (Items!.List[i].locationID == A!.ActLoc) && (Items!.List[i].IsBackground == false))
                    {
                        anzahlGefunden++;
                    }

                }
                */
                if (anzahlGefunden > 0)
                {
                    AdvGame.StoryOutput(locationID, null, Persons!.GetPersonVerbLink(Persons!.Find(A!.ActPerson)!, Co.CASE_AKK, AdvGame.CB!.VT_sehen, AdvGame.CurrentNouns, A.Tense) + loca.locationList_ShowlocationFull_16138);

                    foreach (Item item in Items!.List.Values)
                    {
                        if ((item.locationType == AdvGame.CB!.LocType_Loc) && (item.locationID == A!.ActLoc) && (item.IsBackground == false))
                        {
                            // Noloca: 001
                            AdvGame.StoryOutput(locationID, null, Helper.Insert("- [Il1,Nomu]", item.ID));
                            anzahlGefunden++;
                        }

                    }
                    /*
                    for (int i = 0; i < Items!.List.Count; i++)
                    {
                        if ((Items!.List[i].locationType == AdvGame.CB!.LocType_Loc) && (Items!.List[i].locationID == A!.ActLoc) && (Items!.List[i].IsBackground == false))
                        {
                            AdvGame.StoryOutput(locationID, null,  Helper.Insert("- [Il1,Nomu]", Items!.List[i].ID ));
                            anzahlGefunden++;
                        }

                    }
                    */
                }
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.ShowLocationShort: " + e.Message.ToString(), IGlobalData.protMode.crisp);
            }

        }

        public string GetLocName(string Description)
        {
            return A!.GetConvertedText(Description);
            /*
            int i, j, k;

            string zwString = "";
            for (i = 0; i < Description.Length; i++)
            {
                if (Description[i] == '<')
                {
                    bool found = false;

                    if (SubString(Description, i, 4) == "<br>")
                    {
                        i += 4;
                        zwString += "<br>";
                    }
                    else if ( SubString(Description, i, 6) == "<Item:")
                    {
                        int l;
                        for( l = i + 6; l < Description.Length; l++)
                        {
                            if (Description[l] == '>')
                                break;
                        }
                        int itemID = Int32.Parse(Description.Substring(i + 6, l - i - 6 ));
                        for (k = l + 1; k < Description.Length; k++)
                        {
                            if ((Description[k] == '<') && (Description[k + 1] == '/') && (Description[k + 2] == 'I'))
                            {
                                // string ItemName = GetLocName(Description.Substring(i + 12, k - i - 12));
                                string ItemName = GetLocName(Description.Substring(l+1, k - l - 1));

                                i = k + 6;
// Ignores: 005
                                zwString = zwString + "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('Item: " $"{itemID:00000}');\"></a>";
                                // ZwString = ZwString + "<a href=\"#\" onclick=\"window.clipboardData.setData( 'Text', 'Item: " + $"{itemID:00000}" + "' );\">" + ItemName + "</a>";
                                found = true;
                            }
                            if (found) break;
                        }
                    }
                    else if (SubString(Description, i, 5) == "<Dir:")
                    {
                        int l;
                        for (l = i + 5; l < Description.Length; l++)
                        {
                            if (Description[l] == '>')
                                break;
                        }
                        int dirID = Int32.Parse(Description.Substring(i + 5, l - i - 5));
                        for (k = l + 1; k < Description.Length; k++)
                        {
                            if ((Description[k] == '<') && (Description[k + 1] == '/') && (Description[k + 2] == 'D'))
                            {
                                // string Linktext = GetLocName(Description.Substring(i + 11, k - i - 11));
                                string Linktext = GetLocName(Description.Substring(l + 1, k - l - 1));
                                i = k + 5;
                                // ZwString = ZwString + "<a href=\"#\" onclick=\"ToClip( 'Dir: " + $"{DirID:00000}" + "' );\">" + Linktext + "</a>";
                                // zwString = zwString + "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('Dir: " + $"{dirID:00000}" + "');\">" + Linktext + "</a>";

                                zwString = zwString + Linktext; 

                                found = true;
                            }
                            if (found) break;
                        }
                    }
                    else if (SubString(Description, i, 5) == "<Loc:")
                    {
                        int l;
                        for (l = i + 5; l < Description.Length; l++)
                        {
                            if (Description[l] == '>')
                                break;
                        }
                        int locID = Int32.Parse(Description.Substring(i + 5, l - i - 5));
                        for (k = i + 10; k < Description.Length; k++)
                        {
                            if ((Description[k] == '<') && (Description[k + 1] == '/') && (Description[k + 2] == 'L'))
                            {
                                // string Linktext = GetLocName(Description.Substring(i + 11, k - i - 11));
                                string Linktext = GetLocName(Description.Substring(l + 1, k - l - 1));
                                i = k + 5;
                                // zwString = zwString + "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('Loc: " + $"{locID:00000}" + "');\">" + Linktext + "</a>";
                                zwString = zwString + Linktext;

                                found = true;
                            }
                            if (found) break;
                        }
                    }
                    else if (SubString(Description, i, 10) == "<AP_AKK_C>")
                    {
                        string persName = "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('ActPerson');\">" +AdvGame.FirstUpper(Persons!.GetPersonName(Persons!.Find( A!.ActPerson ), Co.CASE_AKK)) + "</a>";
                        zwString = zwString + persName;
                        i = i + 9;
                    }
                    else if (SubString(Description, i, 8) == "<AP_AKK>")
                    {
                        string persName =  Helper.Insert("<a style=\"cursor:pointer\"vonclick=\"window.external.JSCallback('ActPerson');\">[Pt1,Akk]</a>",  Persons!.Find( A!.ActPerson ) );
                        // string PersName = GetPersonName(A!.ActPerson, Co.CASE_AKK);

                        zwString = zwString + persName;
                        i = i + 7;
                    }
                    else if (SubString(Description, i, 8) == "<APVTPr:")
                    {
                        bool found2 = false;

                        j = i + 8;
                        for (; j < Description.Length; j++)
                        {
                            if (Description[j] == '>')
                            {
                                string s = Description.Substring(i + 8, j - i - 8);
                                for (k = 0; k < VT.List.Count; k++)
                                {
                                    if (s == VT.List[k].VerbNameTense[0])
                                    {
                                        zwString = zwString + Grammar.GetVerbDeclination(VT.List[k].ID, Persons!.Find( A!.ActPerson ), A.Tense);
                                        found2 = true;
                                    }
                                    if (found2) break;
                                }
                            }
                            if (found2) break;
                        }
                        i = j;
                    }
                    else if (SubString(Description, i, 8) == "<APVTPa:")
                    {
                        bool found2 = false;

                        j = i + 8;
                        for (; j < Description.Length; j++)
                        {
                            if (Description[j] == '>')
                            {
                                string s = SubString(Description, i + 8, j - i - 8);
                                for (k = 0; k < VT.List.Count; k++)
                                {
                                    if (s == VT.List[k].VerbNameTense[0])
                                    {
                                        zwString = zwString + Grammar.GetVerbDeclination(VT.List[k].ID, Persons!.Find( A!.ActPerson ), AdvGame.CB!.Tense_Past);
                                        found2 = true;
                                    }
                                    if (found2) break;
                                }
                            }
                            if (found2) break;
                        }
                        i = j;
                    }
                }
                else
                    zwString = zwString + Description[i];
            }
            return (zwString);
            */
        }

        public bool SaveItemsFromlocation( locationList ll, ItemList il, int sourcelocation, int destlocation)
        {
            try
            {
                // Alle mobilen Objekte aus der sourcelocation werden in der destlocation abgelegt, aktuell übrigens auch, wenn 
                // sie im Safe verschlossen lägen. Das hier ist eine Absicherung gegen Dead Ends.
                foreach (Item it in il.List!.Values)
                {
                    (int _iType, int _iID) loc;
                    loc = Items!.GetItemLoc(it);
                    if (loc._iID == sourcelocation && loc._iType == CB!.LocType_Loc && (it.CanBeTaken == true || it.IsMovable))
                    {
                        it.locationID = destlocation;
                        it.locationType = CB!.LocType_Loc;
                    }

                }
                return true;
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.SaveItemsFromlocation: " + e.Message.ToString(), IGlobalData.protMode.crisp);
                return false;
            }

        }

        public bool Replacelocation(locationList ll, ItemList il, PersonList pl, int sourcelocation, int destlocation, bool exchangeItems = true)
        {
            try
            {
                bool setActLoc = false;
                string source = String.Format(loca.locationList_Replacelocation_16142, sourcelocation);
                string dest = String.Format(loca.locationList_Replacelocation_16143, destlocation);

                if (AdvGame!.CA!.Person_I!.locationID == sourcelocation)
                    setActLoc = true;

                foreach (location loc in ll.List.Values)
                {
                    for (int dir = 1; dir < 11; dir++)
                    {
                        if (loc.LocExit[dir] == sourcelocation)
                        {
                            loc.LocExit[dir] = destlocation;
                            ll.Find(destlocation)!.LocExit[Co.CounterDir(dir)!] = loc.ID;
                        }
                    }

                    int pos = loc!.LocDescription!.IndexOf(source)!;
                    if (pos > -1)
                    {
                        loc.LocDescription = loc.LocDescription.Replace(source, dest);
                    }
                }

                // Alle mobilen Objekte aus der alten location werden in der neuen location abgelegt, aktuell übrigens auch, wenn 
                // sie im Safe verschlossen lägen. Das hier ist eine Absicherung gegen Dead Ends.
                foreach (Item it in il.List!.Values)
                {
                    (int _iType, int _iID) loc;
                    loc = Items!.GetItemLoc(it);
                    if (loc._iID == sourcelocation && loc._iType == CB!.LocType_Loc && (it.CanBeTaken == true || it.IsMovable))
                    {
                        it.locationID = destlocation;
                        it.locationType = CB!.LocType_Loc;
                    }

                }
                foreach (Person pe in pl!.List!.Values!)
                {
                    (int _iType, int _iID) loc;
                    loc = Persons!.GetPersonLoc(pe, true);
                    if (loc._iID == sourcelocation && loc._iType == CB!.LocType_Loc)
                    {
                        pe.locationID = destlocation;
                        pe.locationType = CB!.LocType_Loc;
                    }
                    /*
                    if (pe.locationID == sourcelocation && pe.locationType == CB!.LocType_Loc)
                    {
                        pe.locationID = destlocation;
                    }
                    */
                }


                if (setActLoc)
                {
                    AdvGame.A!.ActLoc = destlocation;
                }
                return true;
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.Replacelocation: " + e.Message.ToString(), IGlobalData.protMode.crisp);
                return false;
            }

        }

        public string? ConvertlocationInserts(string sIn)
        {
            try
            {
                string sOut = "";

                int ix = 0;

                while (ix < sIn.Length)
                {
                    int ix2 = ix;
                    int itemID = 0;
                    int locationID = 0;
                    int dirID = 0;
                    while (ix2 < sIn.Length && sIn[ix2] != '[')
                    {
                        ix2++;
                    }

                    sOut += sIn.Substring(ix, ix2 - ix);

                    ix = ix2;

                    if (ix2 < sIn.Length)
                    {
                        if (sIn[ix] == '[')
                        {
                            if (sIn.Substring(ix, 4) == loca.locationList_ConvertlocationInserts_16144)
                            {
                                ix += 4;
                            }
                            else if (sIn.Substring(ix, 4) == loca.locationList_ConvertlocationInserts_16145)
                            {
                                ix += 4;
                            }
                            else if (sIn.Substring(ix, 3) == loca.locationList_ConvertlocationInserts_16146)
                            {
                                int pos = sIn.Substring(ix + 3).IndexOf(']');
                                if (pos != -1)
                                {
                                    string pString = sIn.Substring(ix + 3, pos);
                                    itemID = SearchItemID(pString);
                                    // Link
                                    // sOut += itemID.ToString();

                                    ix += 4 + pos;

                                    int pos2 = sIn.Substring(ix).IndexOf('[');
                                    if (pos2 != -1)
                                    {
                                        string pString2 = sIn.Substring(ix, pos2);
                                        sOut += loca.locationList_ConvertlocationInserts_16147 + itemID.ToString(loca.locationList_ConvertlocationInserts_16148) + loca.locationList_ConvertlocationInserts_16149 + pString2 + loca.locationList_ConvertlocationInserts_16150;
                                        ix += pos2;
                                    }
                                }
                                else
                                    ix += 1;
                            }
                            else if (sIn.Substring(ix, 3) == loca.locationList_ConvertlocationInserts_16151)
                            {
                                int pos = sIn.Substring(ix + 3).IndexOf(']');
                                if (pos != -1)
                                {
                                    string pString = sIn.Substring(ix + 3, pos);
                                    locationID = SearchlocationID(pString);
                                    // Link
                                    // sOut += locationID.ToString();

                                    ix += 4 + pos;

                                    int pos2 = sIn.Substring(ix).IndexOf('[');
                                    if (pos2 != -1)
                                    {
                                        string pString2 = sIn.Substring(ix, pos2);
                                        // Ignores: 004
                                        sOut += loca.locationList_ConvertlocationInserts_16152 + locationID.ToString(loca.locationList_ConvertlocationInserts_16153) + loca.locationList_ConvertlocationInserts_16154 + pString2 + loca.locationList_ConvertlocationInserts_16155;
                                        ix += pos2;
                                    }
                                }
                                else
                                    ix += 1;
                            }
                            else if (sIn.Substring(ix, 3) == loca.locationList_ConvertlocationInserts_16156)
                            {
                                int pos = sIn.Substring(ix + 3).IndexOf(']');
                                if (pos != -1)
                                {
                                    string pString = sIn.Substring(ix + 3, pos);
                                    dirID = SearchDir(pString);
                                    // Link
                                    // sOut += locationID.ToString();

                                    ix += 4 + pos;

                                    int pos2 = sIn.Substring(ix).IndexOf('[');
                                    if (pos2 != -1)
                                    {
                                        string pString2 = sIn.Substring(ix, pos2);
                                        sOut += loca.locationList_ConvertlocationInserts_16157 + locationID.ToString(loca.locationList_ConvertlocationInserts_16158) + loca.locationList_ConvertlocationInserts_16159 + pString2 + loca.locationList_ConvertlocationInserts_16160;
                                        ix += pos2;
                                    }
                                }
                                else
                                    ix += 1;
                            }
                        }
                    }
                }


                return sOut;
            }
            catch (Exception e)
            {
                GlobalData.AddLog("location.ConvertlocationInserts: " + e.Message.ToString(), IGlobalData.protMode.crisp);
                return null;
            }

        }


        public int SearchItemID( string s)
        {
            // s = "VT_" + s;
            System.Reflection.PropertyInfo? pi = typeof(CoAdv).GetProperty(s, BindingFlags.Public | BindingFlags.Instance);

            object o = pi!.GetValue(AdvGame!.CA, null)!;

            return ( o as Item)!.ID!;

        }

        public int SearchlocationID(string s)
        {
            // s = "VT_" + s;
            System.Reflection.PropertyInfo? pi = typeof(CoAdv).GetProperty(s, BindingFlags.Public | BindingFlags.Instance);

            object o = pi!.
                GetValue(AdvGame!.CA!, null)!;

            return (int)o!;

        }

        public int SearchDir(string s)
        {
            Type type = typeof(Co);

            // s = "VT_" + s;
            System.Reflection.PropertyInfo? pi = type.GetProperty(s, BindingFlags.Public | BindingFlags.Instance);

            object o = pi!.GetValue(null, null)!;

            return (int)o!;

        }
    }


}