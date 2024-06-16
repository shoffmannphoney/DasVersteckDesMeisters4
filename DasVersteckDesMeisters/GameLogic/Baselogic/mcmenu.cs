using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using Newtonsoft.Json;
using Phoney_MAUI.Core;


// Beliebte Verben
// VT_fragen
// VT_fordern
// VT_sagen
// VT_sprechen
// außerdem sinnvoll 
// VT_wueten
// VT_schreien
// VT_bruellen
// VT_wispern
// VT_fluestern
// VT_grunzen
// VT_brummen
// VT_entgegnen
// VT_lachen
// VT_kreischen
// VT_keuchen
// VT_jauchzen
// VT_troeten
// VT_saeuseln
// VT_erwaehnen

// Beliebte Adverben
// Adj_guetig
// Adj_allwissend
// Adj_heftig
// Adj_dreckig
// außerdem sinnvoll
// Adj_aufgebracht
// Adj_beilaeufig
using Phoney_MAUI.Model;


namespace GameCore
{
    [Serializable]

    public class MCMenuEntry
    {

        public enum HiddenType { visible = 0, hidden, outdated };

        public int Type { get; set; }

        public int Speaker { get; set; }

        public string? Loca { get; set; }

        [JsonIgnore]
        public string? _text;

        public string? TextOrLoca
        {
            get
            {
                if (Loca == null)
                {
                    return _text;
                }
                else
                {
                    return null;
                }
            }
            set
            { 
                _text = value;
            }
        }

        [JsonIgnore]
        public string? Text
        {
            get
            {
                if (Loca != null)
                {
                    if (!string.IsNullOrEmpty(Loca))
                    {
                        Type t = typeof(loca);

                        PropertyInfo? pi = t.GetProperty(Loca);

                        // var prop = loca.GetType().GetProperty(Loca);
                        var s = pi!.GetValue(null) as string;

                        return s;
                    }
                    else
                        return _text;
                }
                else
                    return _text;
            }
            set
            {
                _text = value;
            }
        }


        public int SpeakVerb { get; set; }

        public Adj? SpeakAdverb { get; set; }

        public int ID { get; set; }

        public List<int>? Follower { get; set; }

        public Status? Status { get; set; }

        public int Val { get; set; }
        [JsonIgnore][NonSerialized]  private DelMCMenuEntry? Del;

        public string? delName;

        public List<int>? Keys { get; set; }

        public bool DeactivateAfterSelect { get; set; }

        public bool StoryRelevant { get; set; }

        public HiddenType Hidden { get; set; }
        public bool DefaultBreak { get; set; }

        public string? ParseString { get; set; }

        public int FlagID { get; set; }


        [JsonConstructor]
        public MCMenuEntry()
        {

        }
        public MCMenuEntry(int pEntryType, Person? pSpeaker, string? pEntryText, int pEntryID, List<int> pEntryFollower, Status? pEntryStatus, int pEntryVal, bool pStoryRelevant, bool pDeactiveAfterSelect, bool pHidden, DelMCMenuEntry? pDel, string? pParseString)
        {
            Type = pEntryType;
            Speaker = pSpeaker == null ? 0 : pSpeaker.ID;
            Text = Helper.FirstUpper( pEntryText );
            Follower = pEntryFollower;
            Status = pEntryStatus;
            Val = pEntryVal;
            Del = pDel;
            if (pDel != null)
                delName = pDel.Method.Name;
            ID = pEntryID;
            DeactivateAfterSelect = pDeactiveAfterSelect;
            if (pHidden)
                Hidden = MCMenuEntry.HiddenType.hidden;
            Keys = new List<int>();
            ParseString = pParseString;
            StoryRelevant = pStoryRelevant;
            SpeakVerb = 0;
        }


        public MCMenuEntry(Person? pSpeaker, string? pEntryText, int pEntryID, int OneFollower, bool pStoryRelevant)
        {
            Type = Co.CB!.MCE_Text;
            Speaker = pSpeaker == null ? 0 : pSpeaker.ID;
            Text = pEntryText;
            Follower = new List<int>();
            Follower.Add(OneFollower);
            Status = null;
            Val = 0;
            Del = null;
            delName = null;
            ID = pEntryID;
            DeactivateAfterSelect = false;
            Hidden = 0;
            Keys = new List<int>();
            ParseString = null;
            StoryRelevant = pStoryRelevant;
            SpeakVerb = 0;
        }

        public MCMenuEntry(Person? pSpeaker, string? pEntryText, int pEntryID, bool pStoryRelevant)
        {
            Type = Co.CB!.MCE_Text;
            Speaker = pSpeaker == null ? 0 : pSpeaker.ID;
            Text = pEntryText;
            Follower = new List<int>();
            Follower.Add(pEntryID + 1);
            Status = null;
            Val = 0;
            Del = null;
            delName = null;
            ID = pEntryID;
            DeactivateAfterSelect = false;
            Hidden = 0;
            Keys = new List<int>();
            ParseString = null;
            StoryRelevant = pStoryRelevant;
            SpeakVerb = 0;
        }

        public MCMenuEntry(Person? pSpeaker, string? pEntryText, int pEntryID, int OneFollower, bool pStoryRelevant, DelMCMenuEntry? Del)
        {
            Type = Co.CB!.MCE_Text;
            Speaker = pSpeaker == null ? 0 : pSpeaker.ID;
            Text = pEntryText;
            Follower = new List<int>();
            Follower.Add(OneFollower);
            Status = null;
            Val = 0;
            this.Del = Del;
            this.delName = Del!.Method.Name;
            ID = pEntryID;
            DeactivateAfterSelect = false;
            Hidden = 0;
            Keys = new List<int>();
            ParseString = null;
            StoryRelevant = pStoryRelevant;
            SpeakVerb = 0;
        }

        public MCMenuEntry(Person? pSpeaker, string? pEntryText, int pEntryID, int OneFollower, bool pStoryRelevant, bool pDeactivateAFterSelect)
        {
            Type = Co.CB!.MCE_Text;
            Speaker = pSpeaker == null ? 0 : pSpeaker.ID;
            Text = pEntryText;
            Follower = new List<int>();
            Follower.Add(OneFollower);
            Status = null;
            Val = 0;
            Del = null;
            delName = null;
            ID = pEntryID;
            DeactivateAfterSelect = pDeactivateAFterSelect;
            Hidden = 0;
            Keys = new List<int>();
            ParseString = null;
            StoryRelevant = pStoryRelevant;
            SpeakVerb = 0;
        }

        public MCMenuEntry(int pEntryID, List<int> pEntryFollower)
        {
            Type = Co.CB!.MCE_Choice;
            Speaker = 0;
            Text = "";
            Follower = pEntryFollower;
            Status = null;
            Val = 0;
            Del = null;
            delName = null;
            ID = pEntryID;
            DeactivateAfterSelect = false;
            Hidden = 0;
            Keys = new List<int>();
            ParseString = null;
            StoryRelevant = false;
            SpeakVerb = 0;
        }

        public MCMenuEntry(int pEntryID, Status Status, int Val, int OneFollower)
        {
            if (pEntryID >= Co.CB!.MCE_Status_Off && pEntryID < Co.CB!.MCE_Follower_Off)
            {
                Type = Co.CB!.MCE_Status;
                Speaker = 0;
                Text = "";
                Follower = new List<int>();
                Follower.Add(OneFollower);
                this.Status = Status;
                this.Val = Val;
                Del = null;
                delName = null;
                ID = pEntryID;
                DeactivateAfterSelect = false;
                Hidden = 0;
                Keys = new List<int>();
                ParseString = null;
                StoryRelevant = false;
                SpeakVerb = 0;
            }
            else
            {
                Type = Co.CB!.MCE_Follower;
                Speaker = 0;
                Text = "";
                Follower = new List<int>();
                Follower.Add(OneFollower);
                this.Status = Status;
                this.Val = Val;
                Del = null;
                delName = null;
                ID = pEntryID;
                DeactivateAfterSelect = false;
                Hidden = 0;
                Keys = new List<int>();
                ParseString = null;
                StoryRelevant = false;
                SpeakVerb = 0;
            }
        }

        public MCMenuEntry(int pEntryID, int FlagDeactivateAfterSelect, int OneFollower)
        {
            Type = Co.CB!.MCE_Flag_Deactivate;
            Speaker = 0;
            Text = "";
            Follower = new List<int>();
            Follower.Add(OneFollower);
            this.FlagID = FlagDeactivateAfterSelect;
            Del = null;
            delName = null;
            ID = pEntryID;
            DeactivateAfterSelect = false;
            Hidden = 0;
            Keys = new List<int>();
            ParseString = null;
            StoryRelevant = false;
            SpeakVerb = 0;
        }

        // Und hier die Variaten für Loca
        public MCMenuEntry MCMenuEntryLoca(int pEntryType, Person? pSpeaker, string? pEntryTextLoca, int pEntryID, List<int> pEntryFollower, Status pEntryStatus, int pEntryVal, bool pStoryRelevant, bool pDeactiveAfterSelect, bool pHidden, DelMCMenuEntry pDel, string pParseString)
        {
            MCMenuEntry mcME = new MCMenuEntry(pEntryType, pSpeaker, null, pEntryID, pEntryFollower, pEntryStatus, pEntryVal, pStoryRelevant, pDeactiveAfterSelect, pHidden, pDel, pParseString);
            mcME.Text = null;
            mcME.Loca = pEntryTextLoca;
            return mcME;
        }


        public static MCMenuEntry MCMenuEntryLoca(Person? pSpeaker, string? pEntryTextLoca, int pEntryID, int OneFollower, bool pStoryRelevant)
        {
            MCMenuEntry mcME = new MCMenuEntry(pSpeaker, null, pEntryID, OneFollower, pStoryRelevant);
            mcME.Text = null;
            mcME.Loca = pEntryTextLoca;
            return mcME;
        }

        public static MCMenuEntry MCMenuEntryLoca(Person? pSpeaker, string? pEntryTextLoca, int pEntryID, bool pStoryRelevant)
        {
            MCMenuEntry mcME = new MCMenuEntry(pSpeaker, null, pEntryID, pStoryRelevant);
            mcME.Text = null;
            mcME.Loca = pEntryTextLoca;
            return mcME;
        }

        public static MCMenuEntry MCMenuEntryLoca(Person? pSpeaker, string? pEntryTextLoca, int pEntryID, int OneFollower, bool pStoryRelevant, DelMCMenuEntry Del)
        {
            MCMenuEntry mcME = new MCMenuEntry(pSpeaker, null, pEntryID, OneFollower, pStoryRelevant, Del);
            mcME.Text = null;
            mcME.Loca = pEntryTextLoca;
            return mcME;
        }

        public static MCMenuEntry MCMenuEntryLoca(Person? pSpeaker, string? pEntryTextLoca, int pEntryID, int OneFollower, bool pStoryRelevant, bool pDeactivateAFterSelect)
        {
            MCMenuEntry mcME = new MCMenuEntry(pSpeaker, null, pEntryID, OneFollower, pStoryRelevant, pDeactivateAFterSelect);
            mcME.Text = null;
            mcME.Loca = pEntryTextLoca;
            return mcME;
        }



        public int GetFollower()
        {
            int val = Follower![Co.RandomNumber(0, Follower.Count)];

            return (val);
        }


        public bool SetDel(DelMCMenuEntry Del)
        {
            this.Del = Del;
            if (Del != null)
            {
                this.delName = Del.Method.Name;
            }
            return true;
        }

        public void SetSpeaker( int speakVerb, Adj? speakAdverb = null )
        {
            this.SpeakVerb = speakVerb;
            this.SpeakAdverb = speakAdverb;
        }

        public DelMCMenuEntry? GetDel(Adv AdvGame)
        {
            if (this.Del == null && this.delName != null)
            {
                try
                {
                    this.Del = (DelMCMenuEntry)Delegate.CreateDelegate(typeof(DelMCMenuEntry), AdvGame, this.delName, false);
                }
                catch (Exception e)
                {
                    GlobalData.AddLog("GetDel: " + e.Message, IGlobalData.protMode.crisp);

                    try
                    {
                        this.Del = (DelMCMenuEntry)Delegate.CreateDelegate(typeof(DelMCMenuEntry), AdvGame!.Orders!, this.delName, false);

                    }
                    catch
                    {
                        GlobalData.AddLog("GetDel: " + e.Message, IGlobalData.protMode.crisp);
                        this.Del = null;
                    }
                }
            }
            return (this.Del);
        }
    }

    [Serializable]

    public class MCSpeaker
    {

        public int SpeakerID { get; }

        public string SpeakerText { get; }

        [JsonConstructor]
        public MCSpeaker(int SpeakerID, string SpeakerText)
        {
            this.SpeakerID = SpeakerID;
            this.SpeakerText = SpeakerText;
        }

        public MCSpeaker(Person Speaker, string SpeakerText)
        {
            this.SpeakerID = Speaker == null ? 0 : Speaker.ID;
            this.SpeakerText = SpeakerText;
        }
    }

    [Serializable]

    public class MCMenu
    {
        [JsonIgnore]
        private Phoney_MAUI.Core.MCMenuView? _mcs;

        [JsonIgnore]
        public Phoney_MAUI.Core.MCMenuView? MCS
        {
            get => _mcs;
            set
            {
                _mcs = value;
            }
        }

        public int Count { get => List.Count ;  }


        public List<MCMenuEntry> List { get; set; }

        public List<int>? current { get; set; }       
        [JsonIgnore]
        public GlobalData? GD
        {
            get => GlobalData.CurrentGlobalData;
            // set => GlobalData.CurrentGlobalData = value;
        }
        [JsonIgnore]
        public CoBase? CB
        {
            get => GD!.Adventure!.CB;
            // set => GD.Adventure!.CB = value;
        }


        // private CoBase CB { get; set; }

        [JsonIgnore]
        public StatusList? Stats
        {
            get => GD!.Adventure!.Stats;
            // set => GD.Adventure!.Stats = value;
        }
        // private StatusList? Stats { get; set; }

        [JsonIgnore]
        public PersonList? Persons
        {
            get => GD!.Adventure!.Persons;
            // set => GD.Adventure!.Persons = value;
        }
        // private PersonList? Persons { get; set; }

        public int SpeakerID { get; set; }

        [JsonIgnore]
        public AdvData? A
        {
            get => GD!.Adventure!.A;
            // set => GD.Adventure!.A = value;
        }
        // private AdvData A { get; set; }
        // private MainWindow MW;

        public List<MCSpeaker> MCSpeakerText { get; set; }
        public bool TextOutput { get; set; }
        public int Start { get; set; }
        public int NewStart { get; set; }

        private bool _addEmptyLine = false;

        public bool DoRecording { get; set; }
        [JsonIgnore]
        public Adv? AdvGame
        {
            get => GD!.Adventure;
            // set => GD.Adventure = value;
        }
        // [JsonIgnore][NonSerialized]  public Adv AdvGame;

        [JsonIgnore][NonSerialized]  public DelMCMenuEntry? DialogGlobalDel;


        public List<int>? Current
        {
            get { return current; }
            set { current = value; }
        }

        char taste = '1';


        [JsonConstructor]
        public MCMenu(StatusList Stats, PersonList? Persons, int SpeakerID, AdvData A, Adv AdvGame, bool TextOutput,
            int Start, bool doRecording = true)
        {
            if (doRecording == false)
                doRecording = false;

            List = new List<MCMenuEntry>();
            Current = new List<int>();
            // this.CB = CB;
            // this.Stats = Stats;
            // this.Persons = Persons;
            // this.A = A;
            // this.AdvGame= AdvGame;
            this.TextOutput = TextOutput;
            this.Start = Start;
            this.SpeakerID = SpeakerID;
            this.NewStart = -1;
            this.DoRecording = doRecording;

            List<int> Follow = new List<int>();
            Follow.Add(Start);
            List.Add(new MCMenuEntry(CB!.MCE_Text, null, null, 0, Follow, null, 0, false, false, false, null, null));
            MCSpeakerText = new List<MCSpeaker>();
        }


        public MCMenu( StatusList Stats, PersonList? Persons, Person? SpeakerID, AdvData A, Adv AdvGame, bool TextOutput, int Start, bool doRecording = true )
        {
            int speakerID = 0;

            if (SpeakerID != null)
                speakerID = SpeakerID.ID;

            if( doRecording == false)
                doRecording = false;

            List = new List<MCMenuEntry>();
            Current = new List<int>();
            // this.CB = CB;
            // this.Stats = Stats;
            // this.Persons = Persons;
            // this.A = A;
            // this.AdvGame= AdvGame;
            this.TextOutput = TextOutput;
             this.Start = Start;
            this.SpeakerID = speakerID;
            this.NewStart = -1;
            this.DoRecording = doRecording;

            List<int> Follow = new List<int>();
            Follow.Add(Start);
            List.Add(new MCMenuEntry(CB!.MCE_Text, null, null, 0, Follow, null, 0, false, false, false, null, null ));
            MCSpeakerText = new List<MCSpeaker>();
        }


        public void AddEntry(Person? pSpeaker, string? pEntryText, int pEntryID, bool pStoryRelevant)
        {
            Add( new MCMenuEntry(pSpeaker, pEntryText, pEntryID, pStoryRelevant) );
        }

        public void AddEntry(Person? pSpeaker, string? pEntryText, int pEntryID, int pFollower, bool pStoryRelevant)
        {
            Add( new MCMenuEntry(pSpeaker, pEntryText, pEntryID, pFollower, pStoryRelevant) ); 
        }

        public void AddEntry(Person? pSpeaker, string? pEntryText, int pEntryID, bool pStoryRelevant, bool pDeactivateAFterSelect)
        {
            Add( new MCMenuEntry(pSpeaker, pEntryText, pEntryID, pEntryID + 1, pStoryRelevant, pDeactivateAFterSelect) );
        }

        public void AddEntry(Person? pSpeaker, string? pEntryText, int pEntryID, int pFollower, bool pStoryRelevant, bool pDeactivateAFterSelect)
        {
            Add( new MCMenuEntry(pSpeaker, pEntryText, pEntryID, pFollower, pStoryRelevant, pDeactivateAFterSelect) );
        }


        
        public void SetAdv(Adv AdvGame)
        {
            // this.AdvGame = AdvGame;
        }


        public void ResetSpeaker()
        {
            MCSpeakerText = new List<MCSpeaker>();
        }

        public void AddSpeaker( Person? SpeakerID, string? Text )
        {
            MCSpeakerText.Add(new MCSpeaker(SpeakerID!, Text!));
            Persons!.Find(SpeakerID!)!.ActivityBlocked = true;
        }

        public string GetSpeakerText( Person? SpeakerID )
        {
            string Text = "";

            for( int i = 0; i < MCSpeakerText.Count; i++ )
            {
                if( MCSpeakerText[i].SpeakerID == SpeakerID!.ID )
                {
                    Text = MCSpeakerText[i].SpeakerText; 
                }
            }
            return (Text);
        }

        public void Add( MCMenuEntry E )
        {
            E.Keys = new List<int>();
            List.Add(E);
        }

        public void AddCurrent( int ID )
        {
            Current!.Add( ID );
            FindID(ID)!.Keys = new List<int>();
            MCMenuEntry? tMCME2 = FindID( ID );
            if ((tMCME2!.Type == CB!.MCE_Text ) & (tMCME2!.Follower!.Count > 0) && ( tMCME2!.Speaker == SpeakerID ))
            {
                FindID(ID)!.Keys!.Add((int)taste);
                if (taste == '9')
                    taste = 'a';
                else if (taste == 'z')
                    taste = 'A';
                else
                    taste++;

            }
        }

        public void ResetCurrent()
        {
            Current!.Clear();
            /* Wow, wie alt ist dieser Code?
            while (current.Count > 0)
                current.RemoveAt(0);
            */
            taste = '1';
        }

        public MCMenuEntry? Last()
        {
            return (List[List.Count - 1]);
        }

        public MCMenuEntry? GetIx( int Ix )
        {
            if (Ix < List.Count)
                return (List[Ix]);
            else
                return (null);
        }

        public MCMenuEntry? FindID( int ID )
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].ID == ID)
                    return (List[i]);
            }
            return (null);
        }

        public bool SetDel(int ID, DelMCMenuEntry Del )
        {
            FindID(ID)!.SetDel( Del );
            return (true);
        }

        public DelMCMenuEntry? GetDel(int ID)
        {
            return( FindID(ID)!.GetDel( AdvGame! ) );
        }

        public MCMenuEntry? GetCurrent(int Ix) 
        {
            if (Ix < Current!.Count)
            {
               return (FindID(Current[Ix]));
            }
            else
                return (null);
        }

        public bool MCSelection( MCMenu MCM, int Selection)
        {
            if ( Selection >= 0 )
            {
                MCMenuEntry? MCME = FindID(Selection);

                if (MCM.DoRecording)
                {
                    int val = 0;
                    // Ignores: 001
                    AdvGame!.GD!.OrderList!.AddOrder(orderType.mcChoice, loca.MCMenu_MCSelection_16161 +MCME!.Text, Selection, loca.GD!.Language, null, null, ref val);
                    if (AdvGame!.GD!.OrderList!.CurrentOrderListIx > 0)
                    {
                        // Ignores: 001
                        AdvGame!.GD!.OrderList!.AddOrderCurrentRun(orderType.mcChoice, loca.MCMenu_MCSelection_16162 +MCME!.Text, Selection, loca.GD!.Language, null, null);
                        // AdvGame!.MW.UpdateOrderList(AdvGame!.GD!.OrderList);
                    }
                }
                // Hier wird nur noch die eigentliche Selection behandelt, den Rest übernimmt Set()
                if (MCME!.DeactivateAfterSelect) 
                    MCME!.Hidden = MCMenuEntry.HiddenType.outdated;

                if( MCME!.Speaker == 0 )
                {
                    // int a = 5;
                }
                else
                {
                    if (Persons == null)
                    {
                    }
                    else if (Persons!.Find(MCME.Speaker) != null)
                    {
                        _addEmptyLine = true;
                        // AdvGame!.StoryOutput(Persons!.Find(MCME.Speaker)!.locationID, A!.Adventure!.CA!.Person_Everyone, "");
                    }
                }

                Set(MCME.ID);
            }

            return (true);
        }

        public void SetCallBack(MCMenuEntry? tMCME )
        {
            if (tMCME != null)
            {
                if (tMCME.GetDel(AdvGame!) != null)
                {
                    List<MCMenuEntry> tMCME2 = new List<MCMenuEntry>() { tMCME };
                    tMCME!.GetDel(AdvGame!)!(tMCME2!);
                }
            }
            if (DialogGlobalDel != null)
            {
                List<MCMenuEntry> tMCME2 = new List<MCMenuEntry>() { tMCME! };
                DialogGlobalDel(tMCME2);
            }
        }

        public bool Set( int pID)
        {
            bool leave = false;
            MCMenuEntry? tMCME = null;

            try
            {
                if (pID == 0 && AdvGame!.GD!.SilentMode == true && TextOutput == false)
                {
                    OrderTable otTemp;
                    otTemp = AdvGame!.GD!.OrderList!.GetCurrentOrderTable();
                    otTemp.OrderActive = false;
                    AdvGame!.FeedbackOutput(AdvGame!.CA!.Person_Everyone!, loca.MCMenu_Set_Person_Everyone_16163);
                    /*
                    if( MCS.visible)
                    {
                        for (int i = 0; i < MCSpeakerText.Count; i++)
                        {
                            Persons!.Find(MCSpeakerText[i].SpeakerID).ActivityBlocked = false;
                        }
                        MCS.Close();
                        AdvGame!.DialogOngoing = false;
                    }
                    */
                    return false;
                }
                else if (AdvGame!.GD!.SilentMode == true)
                {
                    //  int a = 5;
                }

                AdvGame!.DialogOngoing = true;

                tMCME = FindID(pID);

                while ((tMCME != null) && (!leave) && AdvGame!.GD!.ValidRun)
                {
                    /*
                    if (tMCME.Del != null)
                    {
                        List<MCMenuEntry> tMCME2 = new List<MCMenuEntry>() { tMCME };
                        tMCME.Del(tMCME2);
                    }
                    */

                    if (tMCME.Type == CB!.MCE_Status)
                    {
                        Status? tST = tMCME.Status; // FindID(tMCME.Status).Status;

                        tST!.Val = tMCME.Val;
                        SetCallBack(tMCME);
                        tMCME = FindID(tMCME.GetFollower());
                    }
                    else if (tMCME.Type == CB!.MCE_Follower)
                    {
                        FindID(tMCME!.Status!.ID)!.Follower![0] = tMCME!.Val!;
                        // Status tST = Stats.Find(tMCME.Status); // FindID(tMCME.Status).Status;

                        // tST.Val = tMCME.Val;
                        SetCallBack(tMCME);
                        tMCME = FindID(tMCME.GetFollower());
                    }
                    else if (tMCME.Type == CB!.MCE_Flag_Hidden)
                    {
                        MCMenuEntry tMCME2 = FindID(tMCME!.FlagID)!;

                        if (tMCME2 != null)
                        {
                            if (tMCME!.Val == 0)
                            {
                                tMCME2.Hidden = MCMenuEntry.HiddenType.visible;
                            }
                            else
                            {
                                tMCME2.Hidden = MCMenuEntry.HiddenType.hidden;
                            }
                        }
                        SetCallBack(tMCME);
                        tMCME = FindID(tMCME!.GetFollower());
                    }
                    else if (tMCME!.Type == CB!.MCE_Flag_Deactivate)
                    {
                        MCMenuEntry tMCME2 = FindID(tMCME!.FlagID)!;

                        if (tMCME2 != null)
                        {
                            if (tMCME.Val == 0)
                            {
                                tMCME2.DeactivateAfterSelect = false;
                            }
                            else
                            {
                                tMCME2.DeactivateAfterSelect = true;
                            }
                        }
                        SetCallBack(tMCME);
                        tMCME = FindID(tMCME!.GetFollower());
                    }
                    else if (tMCME!.Type == CB!.MCE_Choice)
                    {
                        // AdvGame!.StoryDividingLine();
                        ResetCurrent();

                        for (int i = 0; i < tMCME!.Follower!.Count; i++)
                        {
                            if (FindID(tMCME!.Follower[i])!.Hidden == MCMenuEntry.HiddenType.visible)
                                AddCurrent(tMCME!.Follower[i]);
                        }

                        if (AdvGame!.GD!.SilentMode == false)
                        {
                            leave = true;
                        }
                        else
                        {
                            OrderTable otTemp;

                            otTemp = AdvGame!.GD!.OrderList!.GetNextOrderTable()!;
                            // otTemp = AdvGame!.GD!.OrderList!.GetNextOrderTable()!;

                            if (otTemp.OrderType == orderType.mcChoice && AdvGame!.GD!.OrderList.CheckIndexStillValid(AdvGame!.GD!.OrderListFinalIx))
                            {
                                // DividingLine
                                // AdvGame!.UIS!.StoryTextObj!.DividingLine();

                                int? nextID = otTemp.OrderChoice;
                                if (nextID != null)
                                {
                                    tMCME = FindID((int)nextID);
                                    if (tMCME == null)
                                    {
                                        AdvGame!.GD!.ValidRun = false;
                                    }
                                    else if (tMCME.Hidden != MCMenuEntry.HiddenType.visible)
                                    {
                                        AdvGame!.GD!.ValidRun = false;

                                    }
                                    /*
                                    else if ( tMCME.Type == CB!.MCE_Choice)
                                    {
                                        AdvGame!.StoryOutput(" ");

                                    }
                                    */
                                }
                                else
                                    AdvGame!.GD!.ValidRun = false;

                                if (AdvGame!.GD!.ValidRun)
                                {
                                    // Ignores: 001
                                    otTemp.OrderText = loca.MCMenu_Set_Person_Everyone_16164 + Helper.ShrinkQuotationMark(tMCME!.Text);
                                    // Ignores: 001
                                    AdvGame!.GD!.OrderList.AddOrderCurrentRun(orderType.mcChoice, loca.MCMenu_Set_Person_Everyone_16165 + Helper.ShrinkQuotationMark(tMCME.Text), otTemp.OrderChoice, otTemp.oLG, null, null);
                                    if (tMCME != null)
                                    {
                                        if (tMCME!.Hidden != MCMenuEntry.HiddenType.visible)
                                        {
                                            // int a = 5;
                                        }

                                        if (tMCME.DeactivateAfterSelect)
                                            tMCME.Hidden = MCMenuEntry.HiddenType.outdated;
                                        if (Persons!.Find(tMCME.Speaker!) != null && tMCME.StoryRelevant)
                                        {
                                            // 31.03.2024
                                            // AdvGame!.StoryDividingLine();
                                            AdvGame!.StoryOutput(Persons!.Find(tMCME!.Speaker!)!.locationID, A!.Adventure!.CA!.Person_Everyone, "---");
                                        }
                                    }

                                }

                            }
                            else if (AdvGame!.Orders!.persistentMCMenu!.DoRecording == true)
                            {
                                AdvGame!.GD!.InterruptedDialog = true;
                                AdvGame!.GD!.InteruptedDialogID = tMCME.ID;
                                AdvGame!.GD!.InterruptedDialogCanBeInterruped = AdvGame!.UIS!.MCCanBeInterrupted;
                                // AdvGame!.GD!.InterruptedDialogMCMSelection = AdvGame!.MW.DelMCMSelection;
                                AdvGame!.GD!.InterruptedDialogMCM = AdvGame!.Orders.persistentMCMenu;
                                AdvGame!.GD!.InterruptedDialogMCMSelection = AdvGame!.Orders.persistentMCMenu.MCSelection;
                                AdvGame!.GD!.ValidRun = false;
                            }
                            else
                            {
                                // int a = 5;
                            }
                        }
                    }
                    else if (tMCME.Type == CB!.MCE_Text)
                    {
                        // Wenn TextOutput aktiviert ist, wird der Text oben im Fenster ausgegeben und NICHT unten im FeedbackWindow. Entsprechend muss man ihn auch nicht wegklicken
                        if (TextOutput)
                        {
                            // Wenn SpeakVerb und ggf. SpeakAdverb gesetzt sind
                            if (tMCME.SpeakVerb > 0 && tMCME.Speaker != 0 && tMCME.SpeakVerb != AdvGame!.CB!.VT_nothing)
                            {
                                string speakertext = Persons!.Find(tMCME.Speaker)!.FullName(Co.CASE_AKK, AdvGame.CurrentNouns!, true) + " " + Grammar.GetVerbDeclination(tMCME.SpeakVerb, Persons.Find(tMCME.Speaker), A!.Tense);
                                string? empty = null;
                                if (tMCME.SpeakAdverb != null)
                                    // Ignores: 001
                                    speakertext += " " + tMCME.SpeakAdverb.AdverbName;

                                speakertext += loca.MCMenu_Set_Person_Everyone_16166;
                                speakertext = Helper.FirstUpper(speakertext!)!;


                                if (_addEmptyLine)
                                {
                                    AdvGame!.StoryDividingLine();
                                    // empty = " <br> </br>";
                                    _addEmptyLine = false;
                                }

                                if (tMCME.StoryRelevant)
                                {
                                    if (empty != null)
                                    {
                                        // 31.03.2024
                                        // AdvGame!.StoryDividingLine();
                                        AdvGame!.StoryOutput(0, A!.Adventure!.CA!.Person_Everyone, empty);
                                    }
                                    if (speakertext != "")
                                    {
                                        // Ignores: 001
                                        // 31.03.2024
                                        // AdvGame!.StoryDividingLine();
                                        AdvGame!.StoryOutput(0, A!.Adventure!.CA!.Person_Everyone, speakertext + loca.MCMenu_Set_Person_Everyone_16167 + Helper.ShrinkQuotationMark(tMCME.Text!) + loca.MCMenu_Set_Person_Everyone_16168);
                                    }
                                    else
                                    {
                                        // 31.03.2024
                                        // AdvGame!.StoryDividingLine();
                                        AdvGame!.StoryOutput(0, A!.Adventure!.CA!.Person_Everyone, tMCME.Text);
                                    }
                                }

                                SetCallBack(tMCME);
                                tMCME = FindID(tMCME.GetFollower());
                            }
                            // Wenn ein Sprecher vorhanden ist...
                            else if ((tMCME.Speaker != 0) && (tMCME.StoryRelevant) && tMCME.SpeakVerb != AdvGame!.CB!.VT_nothing)
                            {
                                string speakertext = GetSpeakerText(Persons!.Find(tMCME.Speaker));
                                string? empty = null;
                                // ... und wenn dann auch wirklich ein Speakertext gesetzt wird, dann wird der Text in Anführungszeichen gesetzt, und NUR dann.
                                if (_addEmptyLine)
                                {
                                    empty = " <br> </br>";
                                    _addEmptyLine = false;
                                }

                                if (empty != null)
                                {
                                    // AdvGame!.StoryOutput(0, A!.Adventure!.CA!.Person_Everyone, empty);
                                }

                                if (speakertext != "")
                                {
                                    // Ignores: 001
                                    // 31.03.2024
                                    // AdvGame!.StoryDividingLine();
                                    AdvGame!.StoryOutput(0, A!.Adventure!.CA!.Person_Everyone, speakertext + loca.MCMenu_Set_Person_Everyone_16169 + Helper.ShrinkQuotationMark(tMCME.Text) + loca.MCMenu_Set_Person_Everyone_16170);
                                }
                                else
                                {
                                    // 31.03.2024
                                    // AdvGame!.StoryDividingLine();
                                    AdvGame!.StoryOutput(0, A!.Adventure!.CA!.Person_Everyone, tMCME.Text);
                                }
                                SetCallBack(tMCME);
                                tMCME = FindID(tMCME.GetFollower());
                            }
                            else if (tMCME.StoryRelevant && (tMCME.Speaker == 0 || tMCME.SpeakVerb == AdvGame!.CB!.VT_nothing))
                            {
                                string? empty = null;
                                if (_addEmptyLine)
                                {
                                    empty = " <br> </br>";
                                    _addEmptyLine = false;
                                }
                                if (empty != null)
                                {
                                    // 31.03.2024
                                    // AdvGame!.StoryDividingLine();
                                    AdvGame!.StoryOutput(0, A!.Adventure!.CA!.Person_Everyone, empty);
                                    AdvGame!.StoryOutput(0, A!.Adventure!.CA!.Person_Everyone, tMCME.Text);
                                }
                                else
                                {
                                    // AdvGame!.StoryDividingLine();
                                    AdvGame!.StoryOutput(0, A!.Adventure!.CA!.Person_Everyone, tMCME.Text);

                                }

                                SetCallBack(tMCME);
                                tMCME = FindID(tMCME.GetFollower());

                            }
                            else if (tMCME.Speaker != 0)
                            {
                                SetCallBack(tMCME);
                                tMCME = FindID(tMCME.GetFollower());
                            }
                            else if (tMCME.ID == 0)
                            {
                                SetCallBack(tMCME);
                                tMCME = FindID(tMCME.GetFollower());
                            }
                            else
                            {
                                tMCME = FindID(tMCME.GetFollower());
                            }
                        }
                        else
                        {
                            MCMenuEntry tMCME2 = FindID(tMCME.GetFollower()!)!;

                            if ((tMCME2 != null)
                                && (tMCME2.Type == CB!.MCE_Text)
                              )
                            {
                                ResetCurrent();
                                AddCurrent(tMCME.GetFollower());
                                leave = true;
                            }
                            else
                            {
                                SetCallBack(tMCME);
                                tMCME = FindID(tMCME.GetFollower());
                            }
                        }
                    }
                }
                // Testweise wird hier MCSelection nicht gesetzt, da dies ggf. andere Delegates überschreiben würde
                // MCS.MCOutput(this, MCSelection, false);

                // Im Silent-Modus wird das MultipleChoice-Menü weder aktiviert noch deaktiviert.
                if (AdvGame!.GD!.SilentMode == false)
                {
                    // Remark: Experimentell (aber erfolgreich)
                    // this.MCSelection statt Null übergeben. Unklar, wofür hier jemals null übergeben wurde, das verhindert callbacks
                    // als Reaktion auf Input
                    // MCS!.MCOutput(this, this.MCSelection!, false);
                    MCS!.MCOutput(this, null, false);
                    // AdvGame!.UIS!.StoryTextObj!.AdvTextRefresh();
                    // AdvGame!.UIS!.Scr.SetScrollerToEnd();

                    // wenn wir irgendwann auf einen leeren Follower gestoßen sind, dann ist der vermutliche Grund dafür, dass der Dialog einfach zu Ende ist.
                    if (((tMCME == null) && (!leave)))
                    {
                        for (int i = 0; i < MCSpeakerText.Count; i++)
                        {
                            Persons!.Find(MCSpeakerText[i].SpeakerID)!.ActivityBlocked = false;
                        }

                        MCS.Close();
                        AdvGame!.DialogOngoing = false;
                        AdvGame!.SkipAfterDialog = true;
                        // AdvGame!.UIS!.StoryTextObj!.AdvTextRefresh();
                        // AdvGame!.UIS!.Scr.SetScrollerToEnd();
                    }
                    else
                    {
                        AdvGame!.UIS!.StoryTextObj!.AdvTextRefresh();
#if !NEWSCROLL
                    AdvGame!.UIS!.Scr.SetScrollerToEnd();
#endif
                    }
                }
                else
                {
                    for (int i = 0; i < MCSpeakerText.Count; i++)
                    {
                        Persons!.Find(MCSpeakerText[i].SpeakerID)!.ActivityBlocked = false;
                    }
                    MCS!.Close();
                    AdvGame!.DialogOngoing = false;
                    AdvGame!.SkipAfterDialog = true;
                }

                if (tMCME != null)
                {
                    AdvGame!.Orders!.MCID = tMCME.ID;
                }
            }
            catch (Exception e)
            {
                GlobalData.AddLog("MCMenu.Set: " + e.Message , IGlobalData.protMode.crisp);
            }

            if (tMCME == null || AdvGame!.GD!.ValidRun == false )
                return false;
            else
                return true;
        }

        public Phoney_MAUI.Core.MCMenuView MenuShow()
        {
            return( AdvGame!.MenuShow() );
        }


        public void OutputExit()
        {
            AdvGame!.OutputExit( this );
        }



        public void Deactivate( int ID )
        {
            MCMenuEntry mcME = FindID(ID)!;

            if ( mcME != null )
            {
                mcME.Hidden = MCMenuEntry.HiddenType.hidden; 
            }
        }

        public void DeactivateAndFinish(int ID)
        {
            MCMenuEntry mcME = FindID(ID)!;

            if (mcME != null)
            {
                mcME.Hidden = MCMenuEntry.HiddenType.outdated;
            }
        }

        public void Activate(int ID)
        {
            MCMenuEntry mcME = FindID(ID)!;

            if (mcME != null)
            {
                mcME.Hidden = 0;
            }
        }


        public void TestStatusHide( int StatID, int StatVal, int MCID )
        {
            if (Stats!.Find(StatID)!.Val == StatVal)
            {
                if (FindID(MCID)!.Hidden != MCMenuEntry.HiddenType.outdated)
                    FindID(MCID)!.Hidden = MCMenuEntry.HiddenType.visible;
            }
            else
            {
                if (FindID(MCID)!.Hidden != MCMenuEntry.HiddenType.outdated)
                    FindID(MCID)!.Hidden = MCMenuEntry.HiddenType.hidden;
            }

        }

        public void SetStart( int StartID )
        {
            this.Start = StartID;
            List[0].Follower![0] = StartID; 
        }

        public void SetStartFromNew()
        {
            if (this.NewStart >= 0)
            {
                SetStart(this.NewStart);
                this.NewStart = -1;
            }
        }

        public void SetNewStart(int StartID)
        {
            this.NewStart = StartID;
        }

        public int GetNewStart()
        {
            return this.NewStart;
        }

        public void AddStart( int NextStartID )
        {
            List[0].Follower!.Add(NextStartID);
        }
    }
}