using System.Collections.Generic;
// using System.IO;
using System.Runtime.Serialization;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Text;
using System.IO.Compression;
using System.CodeDom;
using System.Threading.Channels;
using System.Runtime.Intrinsics.X86;
using System.Security.Policy;
using System.Collections.ObjectModel;
// using System.Text.Json.Serialization;
using Phoney_MAUI.Model;

using Phoney_MAUI.Core;

namespace GameCore
{
    [Serializable]
    public class CatLists
    {
        public IDictionary<int, CategoryRel>? cr;
        public IDictionary<int, CategoryRel>? cr2;
    }

    public class OrderFeedback
    {

        public bool Handled { get; set; }               // Flag für die methoden-interne Steuerung: zeigt an, dass eine Eingabe bereits bearbeitet wurde

        public bool Success { get; set; }               // Flag zeigt an, ob die Eingabe erfolgreich war im Sinne von "Es erfolgte ein Storyoutput"

        public bool Action { get; set; }                // Flag zeigt an, ob eine Eingabe erfolgreich war im Sinne von "Zählt als valide Aktion, nach der sich auch NPCs usw. bewegen dürfen"

        public bool FeedbackOutput { get; set; }        // Flag zeigt an: Feedback-Output erfolgt in diesem Turn

        public bool StoryOutput { get; set; }           // Flag zeigt an: Story-Output erfolgt in diesem Turn

        public bool StartDialog { get; set; }           // Flag zeigt an, dass in der Methode in den Dialogmodus geschaltet wurde
    }

    [Serializable]

    public abstract class AbstractOrder
    {

        public MCMenu? persistentMCMenu;
        public MCMenu? temporaryMCMenu;
        public string? MCMenuFunc;

        public string? MCCallbackName
        {
            get => GD!.UIS!._MCCallbackName;
            set
            {
                GD!.UIS!._MCCallbackName = value;
            }
        }

        public int MCID;
        public int MCPersonID;

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
            get => GD!.Adventure!.Persons!;
            // set => GD!.Adventure!.Persons = value;
        }
        [JsonIgnore]
        public StatusList? Stats
        {
            get => GD!.Adventure!.Stats!;
            // set => GD!.Adventure!.Stats = value;
        }
        [JsonIgnore]
        public ItemList? Items
        {
            get => GD!.Adventure!.Items!;
            // set => GD!.Adventure!.Items = value;
        }
        [JsonIgnore]
        public Adv? AdvGame
        {
            get => GD!.Adventure!;
            // set => GD!.Adventure = value;
        }
        [JsonIgnore]
        public VerbList? Verbs
        {
            get => GD!.Adventure!.Verbs!;
            // set => GD!.Adventure!.Verbs = value;
        }
        [JsonIgnore]
        public NounList? Nouns
        {
            get => GD!.Adventure!.Nouns!;
            // set => GD!.Adventure!.Nouns = value;
        }
        [JsonIgnore]
        public AdjList? Adjs
        {
            get => GD!.Adventure!.Adjs!;
            // set => GD!.Adventure!.Adjs = value;
        }
        [JsonIgnore]
        public FillList? Fills
        {
            get => GD!.Adventure!.Fills!;
            // set => GD!.Adventure!.Fills = value;
        }
        [JsonIgnore]
        public TopicList? Topics
        {
            get => GD!.Adventure!.Topics;
            // set => GD!.Adventure!.Topics = value;
        }
        [JsonIgnore]
        public locationList? locations
        {
            get => GD!.Adventure!.locations;
            // set => GD!.Adventure!.locations = value;
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
        [JsonIgnore]
        public CoAdv? CA
        {
            get => GD!.Adventure!.CA;
            // set => GD!.Adventure!.CA = value;
        }
        [JsonIgnore]
        public PrepList? Preps
        {
            get => GD!.Adventure!.Preps;
            // set => GD!.Adventure!.Preps = value;
        }
        [JsonIgnore]
        public PronounList? Pronouns
        {
            get => GD!.Adventure!.Pronouns;
            // set => GD!.Adventure!.Pronouns = value;
        }
        [JsonIgnore]
        public ItemQueue? ItemQueue
        {
            get => GD!.Adventure!.ItemQueue;
            // set => GD!.Adventure!.ItemQueue = value;
        }
        [JsonIgnore]
        public ScoreList? Scores
        {
            get => GD!.Adventure!.Scores;
            // set => GD!.Adventure!.Scores = value;
        }
        [JsonIgnore]
        public List<LatestInput>? LI
        {
            get => GD!.Adventure!.LI;
            // set => GD!.Adventure!.LI = value;
        }


        // protected AdvData? A { get; set; }
        // [JsonIgnore][NonSerialized] protected Adv? AdvGame;
        // protected VerbList? Verbs { get; set; }
        // protected TopicList? Topics { get; set; }
        // protected ItemList? Items { get; set; }
        // protected PersonList? Persons { get; set; }
        // protected MainWindow MW
        // protected locationList? locations { get; set; }
        // protected PrepList? Preps { get; set; }
        // protected PronounList? Pronouns { get; set; }
        // protected ItemQueue? ItemQueue { get; set; }
        // protected NounList? Nouns { get; set; }
        // protected AdjList? Adjs { get; set; }
        // protected FillList? Fills { get; set; }
        // protected StatusList? Stats { get; set; }
        //  protected ScoreList? Scores { get; set; }
        // protected OrderList OrderList { get; set; }
        // protected CoBase? CB { get; set; }
        // protected CoAdv? CA { get; set; }
        // protected List<LatestInput>? LI { get; set; }

        public void SetAdventureGame(Adv AdvGame)
        {
            // this.AdvGame = AdvGame;
        }

        /*
        public void SetLinksToAdv(Adv? AdvGame, AdvData? A, VerbList? Verbs, ItemList? Items, PersonList? Persons,
            TopicList? Topics, locationList? locations, StatusList? Stats, ScoreList? Scores, GameCore.OrderList? OrderList,
            NounList? Nouns, AdjList? Adjs, PrepList? Preps, PronounList? Pronouns, FillList? Fills, ItemQueue? IQ,
            CoBase? CB, CoAdv? CA, List<LatestInput>? LI)
        {
            // this.A = A;
            // this.AdvGame = AdvGame;
            // this.MW = MW;
            // this.Items = Items;
            // this.Persons = Persons;
            // this.Verbs = Verbs;

            // this.Topics = Topics;
            // this.locations = locations;
            // this.Adjs = Adjs;
            // this.Nouns = Nouns;
            // this.Preps = Preps;
            // this.Pronouns = Pronouns;
            // this.Fills = Fills;
            // this.ItemQueue = IQ;
            // this.Stats = Stats;
            // this.Scores = Scores;
            // this.OrderList = OrderList;
            // this.DoGrammar = DoGrammar;
            // this.CB = CB;
            // this.CA = CA;
            // Das wird hoffentlich noch obsolet mit dem nächsten Umbau
            // this.MCV = MCV;
            // this.MCE = MCE;
            // this.LI = LI;

        }
        public AbstractOrder(Adv? AdvGame, AdvData? A, VerbList? Verbs, ItemList? Items, PersonList? Persons, TopicList? Topics, locationList? locations, StatusList? Stats, ScoreList? Scores, OrderList? OrderList, NounList? Nouns, AdjList? Adjs, PrepList? Preps, PronounList? Pronouns, FillList? Fills, ItemQueue? IQ, CoBase? CB, CoAdv? CA, List<LatestInput>? LI)
        {
            // this.A = A;
            // this.AdvGame = AdvGame;
            // this.MW = MW;
            // this.Items = Items;
            // this.Persons = Persons;
            // this.Verbs = Verbs;

            // this.Topics = Topics;
            // this.locations = locations;
            // this.Adjs = Adjs;
            // this.Nouns = Nouns;
            // this.Preps = Preps;
            // this.Pronouns = Pronouns;
            // this.Fills = Fills;
            // this.ItemQueue = IQ;
            // this.Stats = Stats;
            // this.Scores = Scores;
            // this.OrderList = OrderList;
            // this.DoGrammar = DoGrammar;
            // this.CB = CB;
            // this.CA = CA;
            // Das wird hoffentlich noch obsolet mit dem nächsten Umbau
            // this.MCV = MCV;
            // this.MCE = MCE;
            // this.LI = LI;
        }


        public void SetAdv(Adv AdvGame)
        {
            // this.AdvGame = AdvGame;
        }
        */


        public string Insert(string s, params object[] obj)
        {
            string snew = "";
            int ix = 0;

            while (ix < s.Length)
            {
                int ix2 = ix;
                while (ix2 < s.Length && s[ix2] != '[')
                {
                    ix2++;
                }

                snew += s.Substring(ix, ix2 - ix);

                ix = ix2;

                if (ix2 < s.Length)
                {
                    if (s[ix] == '[')
                    {
                        int lenSeq = 0;
                        Item? i = null;
                        Item? it = null;
                        Person? p = null;
                        Person? pt = null;
                        Person? plt = null;
                        Person? plv = null;
                        string? pString = null;
                        int aocase = Co.CASE_AKK;
                        int verbID = -1;

                        if (s.Substring(ix, 5) == loca.OrderFeedback_Insert_13870)
                        {
                            i = (Item)obj[0];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 5) == loca.OrderFeedback_Insert_13871)
                        {
                            i = (Item)obj[1];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 5) == loca.OrderFeedback_Insert_13872)
                        {
                            i = (Item)obj[2];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 5) == loca.OrderFeedback_Insert_13873)
                        {
                            it = (Item)obj[0];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 5) == loca.OrderFeedback_Insert_13874)
                        {
                            it = (Item)obj[1];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 5) == loca.OrderFeedback_Insert_13875)
                        {
                            it = (Item)obj[2];
                            lenSeq += 54;
                        }
                        else if (s.Substring(ix, 6) == loca.OrderFeedback_Insert_13876)
                        {
                            p = (Person)obj[0];
                            // Ignores: 001
                            int pos = s.Substring(ix + 6).IndexOf(loca.OrderFeedback_Insert_13877);
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += (int)( 6 + pString!.Length + 2);
                        }
                        // Ignores: 001
                        else if (s.Substring(ix, 6) == loca.OrderFeedback_Insert_13878)
                        {
                            p = (Person)obj[1];
                            // Ignores: 001
                            int pos = s.Substring(ix + 6).IndexOf(loca.OrderFeedback_Insert_13879);
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += (int)( 6 + pString!.Length + 2);
                        }
                        // Ignores: 001
                        else if (s.Substring(ix, 6) == loca.OrderFeedback_Insert_13880)
                        {
                            p = (Person)obj[2];
                            // Ignores: 001
                            int pos = s.Substring(ix + 6).IndexOf(loca.OrderFeedback_Insert_13881);
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += (int)( 6 + pString!.Length + 2);
                        }
                        // Ignores: 001
                        else if (s.Substring(ix, 5) == loca.OrderFeedback_Insert_13882)
                        {
                            pt = (Person)obj[0];
                            lenSeq += 5;
                        }
                        // Ignores: 001
                        else if (s.Substring(ix, 5) == loca.OrderFeedback_Insert_13883)
                        {
                            pt = (Person)obj[1];
                            lenSeq += 5;
                        }
                        // Ignores: 001
                        else if (s.Substring(ix, 5) == loca.OrderFeedback_Insert_13884)
                        {
                            pt = (Person)obj[2];
                            lenSeq += 5;
                        }
                        // Ignores: 001
                        else if (s.Substring(ix, 6) == loca.OrderFeedback_Insert_13885)
                        {
                            plt = (Person)obj[0];
                            lenSeq += 6;
                        }
                        // Ignores: 001
                        else if (s.Substring(ix, 6) == loca.OrderFeedback_Insert_13886)
                        {
                            plt = (Person)obj[1];
                            lenSeq += 6;
                        }
                        // Ignores: 001
                        else if (s.Substring(ix, 5) == loca.OrderFeedback_Insert_13887)
                        {
                            pt = (Person)obj[2];
                            lenSeq += 6;
                        }
                        // Ignores: 001
                        else if (s.Substring(ix, 6) == loca.OrderFeedback_Insert_13888)
                        {
                            plv = (Person)obj[0];
                            int pos = s.Substring(ix + 6).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + 6, pos);
                                verbID = SearchVT(pString);
                                lenSeq += 6 + pString.Length + 1;

                            }
                        }
                        else if (s.Substring(ix, 6) == loca.OrderFeedback_Insert_13889)
                        {
                            plv = (Person)obj[1];
                            int pos = s.Substring(ix + 6).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + 6, pos);
                                verbID = SearchVT(pString);
                                lenSeq += 6 + pString.Length + 1;

                            }
                        }
                        else if (s.Substring(ix, 6) == loca.OrderFeedback_Insert_13890)
                        {
                            plv = (Person)obj[2];
                            int pos = s.Substring(ix + 6).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + 6, pos);
                                verbID = SearchVT(pString);
                                lenSeq += 6 + pString.Length + 1;
                            }
                        }

                        if (s.Substring(ix + lenSeq, 4) == loca.OrderFeedback_Insert_13891)
                        {

                            aocase = Co.CASE_AKK;
                            lenSeq += 4;
                        }
                        else if (s.Substring(ix + lenSeq, 4) == loca.OrderFeedback_Insert_13892)
                        {

                            aocase = Co.CASE_NOM;
                            lenSeq += 4;
                        }
                        else if (s.Substring(ix + lenSeq, 4) == loca.OrderFeedback_Insert_13893)
                        {

                            aocase = Co.CASE_DAT;
                            lenSeq += 4;
                        }
                        else if (s.Substring(ix + lenSeq, 5) == loca.OrderFeedback_Insert_13894)
                        {

                            aocase = Co.CASE_AKK_UNDEF;
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix + lenSeq, 5) == loca.OrderFeedback_Insert_13895)
                        {

                            aocase = Co.CASE_NOM_UNDEF;
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix + lenSeq, 5) == loca.OrderFeedback_Insert_13896)
                        {

                            aocase = Co.CASE_DAT_UNDEF;
                            lenSeq += 5;
                        }

                        if (i != null)
                        {
                            snew += Items?.GetItemNameLink(i!.ID, aocase);
                        }
                        else if (it != null)
                        {
                            snew += Items?.GetName(it!.ID, aocase);
                        }
                        else if (p != null)
                        {
                            snew += Persons?.GetPersonLink(p, pString);
                        }
                        else if (pt != null)
                        {
                            snew += Persons?.GetPersonName(pt, aocase);
                        }
                        else if (plt != null)
                        {
                            snew += Persons?.GetPersonNameLink(plt, aocase);
                        }
                        else if (plv != null)
                        {
                            snew += Persons?.GetPersonVerbLink(plv, aocase, verbID, (int) A!.Tense);
                        }

                        if (lenSeq == 0)
                            lenSeq = 1;
                        ix += lenSeq;
                    }

                }
            }

            return snew;
        }

        int SearchVT(string s)
        {
            // Ignores: 001
            s = loca.OrderFeedback_Insert_13897 + s;
            System.Reflection.PropertyInfo? pi = typeof(CoBase).GetProperty(s, BindingFlags.Public | BindingFlags.Instance);

            object o = pi!.GetValue(CB, null)!;

            return (int)(o);
        }


        public virtual bool Donothing(Person PersoniD, ParseTokenList PTL)

        {
            return (true);
        }


        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }


        public virtual bool Examine(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();

            Item item = PTL.GetFirstItem()!; // GetItemRef(Adv_PT[1].WordID);

            // Ignores: 001
            // MW.TextOutput( "<i>Du untersuchst " + Items!.GetItemNameLink(I!.ID, Co.CASE_NOM) + ". ( " + I!.ID + ")</i>");
            AdvGame!.StoryOutput((int) Persons?.Find(PersonID)!.locationID!, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_Examine_Person_Everyone_13898, PersonID, item!.ID));
            // AdvGame!.StoryOutput(Person!.Find(PersonID)!.locationID, CA!.Person_Everyone, Insert( "<i>[Plv1,betrachten,Akk] [Il2,Nom].</i>", CA!.Person_I, item ) );
            of.Success = true;
            of.Handled = true;
            of.Action = true;
            of.StoryOutput = true;

            if (item.Picture != null)
                AdvGame!.PictureOutput(item.Picture);

            AdvGame!.StoryOutput((int)Persons!.Find(PersonID)!.locationID, PersonID, item.Description);
            if ((item.CanBeLocked) && (item.CanBeClosed))
            {
                if ((item.IsLocked) && (item.IsClosed))
                {
                    AdvGame!.StoryOutput((int)(Persons!.Find(PersonID)!.locationID), PersonID, Helper.Insert(loca.OrderFeedback_Examine_Person_Everyone_13899, item!.ID, item!.ID));
                }
                else if ((!item.IsLocked) && (item.IsClosed))
                {
                    AdvGame!.StoryOutput((int)(Persons!.Find(PersonID)!.locationID), PersonID, Helper.Insert(loca.OrderFeedback_Examine_Person_Everyone_13900, item!.ID, item!.ID));
                }
                else if ((item.IsLocked) && (!item.IsClosed))
                {
                    AdvGame!.StoryOutput((int)(Persons!.Find(PersonID)!.locationID), PersonID, Helper.Insert(loca.OrderFeedback_Examine_Person_Everyone_13901, item!.ID, item!.ID));
                }
            }
            else if ((!item.CanBeLocked) && (item.CanBeClosed))
            {
                if (item.IsClosed)
                {
                    AdvGame!.StoryOutput((int)( Persons?.Find(PersonID)!.locationID!) , PersonID, Helper.Insert(loca.OrderFeedback_Examine_Person_Everyone_13902, item!.ID, item!.ID));
                }
                else if (!item.IsClosed)
                {
                    AdvGame!.StoryOutput((int)( Persons?.Find(PersonID)!.locationID!) , PersonID, Helper.Insert(loca.OrderFeedback_Examine_Person_Everyone_13903, item!.ID, item!.ID));
                }
            }

            if ((item.CanPutIn) && (!item.InvisibleIn) && ((!item.CanBeClosed) || (item.IsClosed == false)))
            {
                Persons?.ListPersons(AdvGame!.CB!.LocType_In_Item, item!.ID, (int)( Persons?.Find(PersonID)!.locationID!) );
                ListItems(Helper.Insert(loca.OrderFeedback_Examine_Person_Everyone_13904, item!.ID, CA!.Person_3rdperson!), PersonID, CB!.LocType_In_Item, item!.ID, false, true, Co.CASE_AKK_UNDEF);
                item.InvisibleIn = false;
            }
            // In Cages kann man immer reingucken
            if (item.IsCage)
            {
                Persons?.ListPersons(AdvGame!.CB!.LocType_In_Item, item!.ID, (int)( Persons?.Find(PersonID)!.locationID!) );
                ListItems(Helper.Insert(loca.OrderFeedback_Examine_Person_3rdperson_13905, item!.ID, CA!.Person_3rdperson!), PersonID, CB!.LocType_In_Item, item!.ID, false, true, Co.CASE_AKK_UNDEF);
                item.InvisibleIn = false;
            }
            if ((item.CanPutOn) && (!item.InvisibleOn))
            {
                Persons?.ListPersons(AdvGame!.CB!.LocType_On_Item, item!.ID, (int)(Persons?.Find(PersonID)!.locationID!));
                ListItems(Helper.Insert(loca.OrderFeedback_Examine_Person_3rdperson_13906, item!.ID, CA!.Person_3rdperson!), PersonID, CB!.LocType_On_Item, item!.ID, false, true, Co.CASE_AKK_UNDEF);
                item.InvisibleOn = false;
            }
            if ((item.CanPutBehind) && (!item.InvisibleBehind))
            {
                ListItems(Helper.Insert(loca.OrderFeedback_Examine_Person_3rdperson_13907, item!.ID, CA!.Person_3rdperson!), PersonID, CB!.LocType_Behind_Item, item!.ID, false, true, Co.CASE_AKK_UNDEF);
                item.InvisibleBehind = false;
            }
            if ((item.CanPutBelow) && (!item.InvisibleBelow))
            {
                ListItems(Helper.Insert(loca.OrderFeedback_Examine_Person_3rdperson_13908, item!.ID, CA!.Person_3rdperson!), PersonID, CB!.LocType_Below_Item, item!.ID, false, true, Co.CASE_AKK_UNDEF);
                item.InvisibleBelow = false;
            }
            if ((item.CanPutBeside) && (!item.InvisibleBeside))
            {
                ListItems(Helper.Insert(loca.OrderFeedback_Examine_Person_3rdperson_13909, item!.ID, CA!.Person_3rdperson!), PersonID, CB!.LocType_Beside_Item, item!.ID, false, true, Co.CASE_AKK_UNDEF);
                item.InvisibleBeside = false;
            }
            return (true);
        }

        public void LayoutRefresh()
        {
            bool x = AdvGame!.UIS!.UpdateBrowserBlocked;
            AdvGame.UIS.UpdateBrowserBlocked = true;
            AdvGame.UIS.DoUIUpdate();
            AdvGame.UIS.UpdateBrowserBlocked = x;
            // locations!.Showlocation(A!.ActLoc);

        }
        public virtual bool German(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, loca.Order_Switch_German);
            loca.GD!.Language = IGlobalData.language.german;
            LayoutRefresh();
            locations!.Showlocation(A!.ActLoc);
            return true;
        }
        public virtual bool English(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, loca.Order_Switch_English_Fail);
            // loca.GD!.Language = IGlobalData.language.english;
            // LayoutRefresh();
            // locations!.Showlocation(A!.ActLoc);
            return true;
        }
        public virtual bool ExamineP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Person person = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);

            if (person!.ID == CA!.Person_I!.ID)
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_ExamineP_Person_Me_13910, PersonID));
            else
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_ExamineP_Person_Everyone_13910, PersonID, person));

            if (person.Picture != null)
                AdvGame!.PictureOutput(person.Picture);

            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, person.Description);


            of.Success = true;
            of.Handled = true;
            of.Action = true;
            of.StoryOutput = true;

            if ((person.CanBeLocked) && (person.CanBeClosed))
            {
                if ((person.IsLocked) && (person.IsClosed))
                {
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, Helper.Insert(loca.OrderFeedback_ExamineP_Person_Everyone_13911, person!, CA!.Person_3rdperson!));
                }
                else if ((!person.IsLocked) && (person.IsClosed))
                {
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, Helper.Insert(loca.OrderFeedback_ExamineP_Person_3rdperson_13912, person!, CA!.Person_3rdperson!));
                }
                else if ((person.IsLocked) && (!person.IsClosed))
                {
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, Helper.Insert(loca.OrderFeedback_ExamineP_Person_3rdperson_13913, person!, CA!.Person_3rdperson!));
                }
            }
            else if ((!person.CanBeLocked) && (person.CanBeClosed))
            {
                if (person.IsClosed)
                {
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, Helper.Insert(loca.OrderFeedback_ExamineP_Person_3rdperson_13914, person!, CA!.Person_3rdperson!));
                }
                else if (!person.IsClosed)
                {
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, Helper.Insert(loca.OrderFeedback_ExamineP_Person_3rdperson_13915, person!, CA!.Person_3rdperson!));
                }
            }

            if ((person.CanPutIn) && ((!person.CanBeClosed) || (person.IsClosed == false)))
            {
                ListItems(Helper.Insert(loca.OrderFeedback_ExamineP_Person_3rdperson_13916, person!, CA!.Person_3rdperson!), PersonID, CB!.LocType_In_Person, person!.ID, false, true, Co.CASE_AKK_UNDEF);
            }

            return (true);
        }


        public virtual bool Take(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();

            // Nach den gesamten Prüfungen von Adv_PT ist garantiert, dass sich die Werte an dieser Stelle befinden.
            Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            return (ProcessTake(item, PersonID, of));


        }

        public virtual bool TakeAll(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();

            int ct = 0;
            foreach (Item it in Items!.List!.Values)
            {
                if (it.CanBeTaken && Items!.IsItemHere(it, Co.Range_Here) && !Items!.IsItemInv(it))
                {
                    ProcessTake(it, PersonID, of);
                    ct++;
                }
            }

            if (ct > 0)
                return true;
            else
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_TakeAll_Person_Everyone_13917, PersonID));
                return true;
            }
        }

        public virtual bool TakeP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();

            // Nach den gesamten Prüfungen von Adv_PT ist garantiert, dass sich die Werte an dieser Stelle befinden.
            Person pers = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);

            return (ProcessTakeP(pers, PersonID, of));

        }

        public virtual bool Drop(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool success = false;

            // Nach den gesamten Prüfungen von Adv_PT ist garantiert, dass sich die Werte an dieser Stelle befinden.
            Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if ((item!.locationType == CB!.LocType_Person) && (item.locationID == PersonID!.ID))
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_Drop_Person_Everyone_13918, PersonID, item!.ID));
                Items!.TransferItem(item!.ID, CB!.LocType_Loc, Persons!.Find(PersonID)!.locationID);
                success = true;
                // handled = true;
                of.Success = true;
                of.Handled = true;
                of.StoryOutput = true;
            }
            else
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_Drop_Person_Everyone_13919, PersonID, PersonID));
                of.FeedbackOutput = true;
                success = true;
            }
            return (success);
        }


        public virtual bool Inventory(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_Inventory_Person_Everyone_13920, PersonID, PersonID, PersonID));

            ListItems(Helper.Insert(loca.OrderFeedback_Inventory_Person_Everyone_13921, PersonID), PersonID, CB!.LocType_Person, PersonID!.ID, false, false, Co.CASE_NOM);

            of.StoryOutput = true;
            of.Success = true;
            of.Handled = true;
            of.Action = true;
            return (true);
        }

        public virtual bool location(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();

            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_location_Person_Everyone_13922, PersonID, PersonID));
            locations!.ShowlocationFull(Persons!.LocOnly(PersonID));

            of.StoryOutput = true;
            of.Success = true;
            of.Handled = true;
            of.Action = true;
            return (true);
        }

        public virtual bool Go(Person PersonID, int Dir)
        {
            OrderFeedback of = new OrderFeedback();
            bool success = false;

            if (locations!.LocPersonAct(PersonID).LocExit[Dir] > 0)
            {

                if ( Dir == 9)
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_Go_Person_Everyone_13923_Up, PersonID, Dir));
                else if (Dir == 10)
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_Go_Person_Everyone_13923_Down, PersonID, Dir));
                else
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_Go_Person_Everyone_13923, PersonID, Dir));
                Persons!.TransferPerson(PersonID!.ID, CB!.LocType_Loc, locations!.LocPersonAct(PersonID).LocExit[Dir]);


                // Persons!.Find(PersonID)!.locationID = locations!.LocPersonAct(PersonID).LocExit[Dir];
                // Persons!.Find(PersonID)!.locationType = CB!.LocType_Loc;

                if (PersonID!.ID == A!.ActPerson)
                {
                    A!.ActLoc = Persons!.Find(PersonID)!.locationID;
                    locations!.Showlocation(A!.ActLoc);
                }
                if ((PersonID!.ID != A!.ActPerson) && (Persons!.Find(PersonID)!.locationID == Persons!.Find(A!.ActPerson)!.locationID))
                {
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_Go_Person_Everyone_13924, PersonID));

                }
                success = true;
                of.StoryOutput = true;
                of.Success = true;
                of.Handled = true;
                of.Action = true;
            }
            else
            {
                AdvGame!.FeedbackOutput(PersonID, Helper.Insert(loca.OrderFeedback_Go_Person_Everyone_13925, Items!.Find(CA!.I00_Nullbehaelter!)!));
                of.FeedbackOutput = true;
            }
            return (success);
        }

        public virtual bool GoN(Person PersonID, ParseTokenList PTL)
        {
            return (Go(PersonID, Co.DIR_N));
        }

        public virtual bool GoNE(Person PersonID, ParseTokenList PTL)
        {
            return (Go(PersonID, Co.DIR_NE));
        }

        public virtual bool GoE(Person PersonID, ParseTokenList PTL)
        {
            return (Go(PersonID, Co.DIR_E));
        }

        public virtual bool GoSE(Person PersonID, ParseTokenList PTL)
        {
            return (Go(PersonID, Co.DIR_SE));
        }

        public virtual bool GoS(Person PersonID, ParseTokenList PTL)
        {
            return (Go(PersonID, Co.DIR_S));
        }

        public virtual bool GoSW(Person PersonID, ParseTokenList PTL)
        {
            return (Go(PersonID, Co.DIR_SW));
        }

        public virtual bool GoW(Person PersonID, ParseTokenList PTL)
        {
            return (Go(PersonID, Co.DIR_W));
        }

        public virtual bool GoNW(Person PersonID, ParseTokenList PTL)
        {
            return (Go(PersonID, Co.DIR_NW));
        }

        public virtual bool GoU(Person PersonID, ParseTokenList PTL)
        {
            return (Go(PersonID, Co.DIR_U));
        }

        public virtual bool GoD(Person PersonID, ParseTokenList PTL)
        {
            return (Go(PersonID, Co.DIR_D));
        }

        public virtual bool Open(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool succeed = true;
            of.Success = true;

            Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
                                            // int ItemID = GetItemIx(Adv_PT[1].WordID);
            if (item.CanBeClosed == false)
            {
                AdvGame!.StoryOutput(PersonID.locationID, PersonID, Helper.Insert(loca.OrderFeedback_Open_13926, item!.ID, item));
                succeed = false;
                of.Success = false;
                of.Handled = true;
                of.FeedbackOutput = true;
            }
            else if ((item.CanBeClosed == true) && (item.CanBeLocked == true) && (item.IsLocked == true))
            {
                AdvGame!.StoryOutput(PersonID.locationID, PersonID, Helper.Insert(loca.OrderFeedback_Open_13927, item!.ID, CA!.Person_3rdperson!));
                succeed = false;
                of.Success = false;
                of.Handled = true;
                of.FeedbackOutput = true;
            }
            else if (item.IsClosed == false)
            {
                AdvGame!.StoryOutput(PersonID.locationID, PersonID, Helper.Insert(loca.OrderFeedback_Open_Person_3rdperson_13928, item!.ID, CA!.Person_3rdperson!));
                succeed = false;
                of.Success = false;
                of.Handled = true;
                of.FeedbackOutput = true;
            }
            else
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_Open_Person_Everyone_13929, PersonID, item!.ID));
                item.IsClosed = false;
                of.Success = true;
                of.Handled = true;
                of.Action = true;
                of.StoryOutput = true;

                if (PTL.ConvenienceActionNotExamineAfter == false && item.CanPutIn )
                {
                    PTL.ConvenienceActionNotOpenFirst = true;
                    ExamineIn(PersonID, PTL);
                    PTL.ConvenienceActionNotOpenFirst = false;
                }
            }
            return (succeed);
        }

        public virtual bool Close(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool success = false;

            Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
                                            // int ItemID = GetItemIx(Adv_PT[1].WordID);
            if (item.CanBeClosed == false)
            {
                AdvGame!.StoryOutput(PersonID.locationID, PersonID, Helper.Insert(loca.OrderFeedback_Close_13930, item!.ID, item));
                of.FeedbackOutput = true;
                success = true;
            }
            else if (item.IsClosed == true)
            {
                AdvGame!.StoryOutput(PersonID.locationID, PersonID, Helper.Insert(loca.OrderFeedback_Close_13931, item!.ID, CA!.Person_3rdperson!));
                of.FeedbackOutput = true;
                success = true;
            }
            else
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_Close_Person_Everyone_13932, PersonID, item!.ID));
                item.IsClosed = true;
                success = true;
                of.StoryOutput = true;
                of.Success = true;
                of.Handled = true;
                of.Action = true;
            }
            return (success);
        }

        public virtual bool OpenP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool succeed = true;
            of.Success = true;

            Person person = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);
            if (person.CanBeClosed == false)
            {
                AdvGame!.StoryOutput(PersonID.locationID, PersonID, Helper.Insert(loca.OrderFeedback_OpenP_13933, person, person));
                // succeed = false;
                of.Success = false;
                of.Handled = true;
                of.FeedbackOutput = true;
            }
            else if ((person.CanBeClosed == true) && (person.CanBeLocked == true) && (person.IsLocked == true))
            {
                AdvGame!.StoryOutput(PersonID.locationID, PersonID, Helper.Insert(loca.OrderFeedback_OpenP_13934, person, CA!.Person_3rdperson!));
                // succeed = false;
                of.Success = false;
                of.Handled = true;
                of.FeedbackOutput = true;
            }
            else if (person.IsClosed == false)
            {
                AdvGame!.StoryOutput(PersonID.locationID, PersonID, Helper.Insert(loca.OrderFeedback_OpenP_Person_3rdperson_13935, person, CA!.Person_3rdperson!));
                of.Success = false;
                of.Handled = true;
                of.FeedbackOutput = true;
            }
            else
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_OpenP_Person_Everyone_13936, PersonID, person));
                person.IsClosed = false;
                of.StoryOutput = true;
                of.Handled = true;
                of.Action = true;
            }
            return (succeed);
        }

        public virtual bool CloseP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool success = false;
            Person person = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);
                                                  // int ItemID = GetItemIx(Adv_PT[1].WordID);
            if (person.CanBeClosed == false)
            {
                AdvGame!.StoryOutput(PersonID.locationID, PersonID, Helper.Insert(loca.OrderFeedback_CloseP_13937, person, person));
                of.FeedbackOutput = true;
                of.Handled = true;
                success = true;
            }
            else if (person.IsClosed == true)
            {
                AdvGame!.StoryOutput(PersonID.locationID, PersonID, Helper.Insert(loca.OrderFeedback_CloseP_13938, person, CA!.Person_3rdperson!));
                of.FeedbackOutput = true;
                of.Handled = true;
                success = true;
            }
            else
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_CloseP_Person_Everyone_13939, PersonID, person));
                person.IsClosed = true;
                success = true;
                of.StoryOutput = true;
                of.Handled = true;
            }
            return (success);
        }

        public virtual bool UnlockW(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool found = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);
                                              // int ItemID1 = GetItemIx(Adv_PT[1].WordID);
                                              // int ItemID2 = GetItemIx(Adv_PT[3].WordID);

            if (item1.CanBeLocked == false)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_UnlockW_13940, item1!.ID, item1));
                of.FeedbackOutput = true;
                of.Handled = true;
                found = true;
            }
            else if (item1.IsLocked == false)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_UnlockW_Person_3rdperson_13941, item1!.ID, item1));
                of.FeedbackOutput = true;
                of.Handled = true;
                found = true;
            }
            else
            {

                foreach (int i in item1.UnlockItems!)
                {
                    if (i == item2!.ID)
                    {
                        item1.IsLocked = false;
                        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_UnlockW_Person_Everyone_13942, PersonID, item1!.ID, item2!.ID));
                        of.StoryOutput = true;
                        of.Success = true;
                        of.Action = true;
                        of.Handled = true;
                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_UnlockW_Person_Everyone_13943, item1!.ID, item1, item2!.ID));
                    of.FeedbackOutput = true;
                    of.Handled = true;
                    found = true;
                }
            }
            return (found);
        }

        public virtual bool UnlockWP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool found = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[3].WordID);

            if (person1.CanBeLocked == false)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_UnlockWP_13944, person1, person1));
                of.FeedbackOutput = true;
                of.Handled = true;
                found = true;
            }
            else if (person1.IsLocked == false)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_UnlockWP_13945, person1, CA!.Person_3rdperson!));
                of.FeedbackOutput = true;
                of.Handled = true;
                found = true;
            }
            else
            {

                foreach (int i in person1.UnlockItems!)
                {
                    if (i == item2!.ID)
                    {
                        person1.IsLocked = false;
                        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_UnlockWP_Person_Everyone_13946, PersonID, person1, item2!.ID));

                        found = true;
                        of.StoryOutput = true;
                        of.Success = true;
                        of.Action = true;
                        of.Handled = true;
                        break;
                    }
                }
                if (found == false)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_UnlockWP_Person_Everyone_13947, person1, person1, item2!.ID));
                    of.FeedbackOutput = true;
                    found = true;
                }
            }
            return (found);
        }

        public virtual bool LockW(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool found = false;

            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);
                                              // int ItemID1 = GetItemIx(Adv_PT[1].WordID);
                                              // int ItemID2 = GetItemIx(Adv_PT[3].WordID);

            if (item1.CanBeLocked == false)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_LockW_13948, item1!.ID, CA!.Person_3rdperson!));
                of.FeedbackOutput = true;
                of.Handled = true;
                found = true;

            }
            else if (item1.IsLocked == true)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_LockW_Person_3rdperson_13949, item1!.ID, CA!.Person_3rdperson!));
                of.FeedbackOutput = true;
                of.Handled = true;
                found = true;
            }
            else
            {

                foreach (int i in item1.UnlockItems!)
                {
                    if (i == item2!.ID)
                    {
                        item1.IsLocked = true;
                        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_LockW_Person_Everyone_13950, PersonID, item1!.ID, item2!.ID));

                        found = true;
                        of.StoryOutput = true;
                        of.Success = true;
                        of.Action = true;
                        of.Handled = true;
                        break;
                    }
                }
                if (found == false)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_LockW_Person_Everyone_13951, item1!.ID, item1, item2!.ID));
                    of.FeedbackOutput = true;
                    of.Handled = true;
                    found = true;

                }
            }
            return (false);
        }

        public virtual bool LockWP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool found = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[3].WordID);
                                             // int ItemID1 = GetItemIx(Adv_PT[1].WordID);
                                             // int ItemID2 = GetItemIx(Adv_PT[3].WordID);

            if (person1!.CanBeLocked == false)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_LockWP_13952, person1, CA!.Person_3rdperson!));
                of.FeedbackOutput = true;
                of.Handled = true;
                found = true;
            }
            else if (person1.IsLocked == true)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_LockWP_Person_3rdperson_13953, person1, CA!.Person_3rdperson!));
                of.FeedbackOutput = true;
                of.Handled = true;
                found = true;
            }
            else
            {

                foreach (int i in person1.UnlockItems!)
                {
                    if (i == item2!.ID)
                    {
                        person1.IsLocked = true;
                        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_LockWP_Person_Everyone_13954, PersonID, person1, item2!.ID));
                        of.StoryOutput = true;
                        of.Success = true;
                        of.Action = true;
                        of.Handled = true;

                        found = true;
                        break;
                    }
                }
                if (found == false)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_LockWP_Person_Everyone_13955, person1, person1, item2!.ID));
                    of.FeedbackOutput = true;
                    of.Handled = true;
                    found = true;
                }
            }
            return (found);
        }

        public virtual bool TakeUnder(Person PersonID, ParseTokenList PTL)
        {
            return (Take(PersonID, PTL));
        }

        public virtual bool TakeOut(Person PersonID, ParseTokenList PTL)
        {
            return (Take(PersonID, PTL));
        }

        public virtual bool TakeFrom(Person PersonID, ParseTokenList PTL)
        {
            return (Take(PersonID, PTL));
        }

        public virtual bool TakeBehind(Person PersonID, ParseTokenList PTL)
        {
            return (Take(PersonID, PTL));
        }

        public virtual bool TakeBeside(Person PersonID, ParseTokenList PTL)
        {
            return (Take(PersonID, PTL));
        }

        public virtual bool PlaceUnder(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool handled = false;

            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            if (item2.CanPutBelow!)
            {
                if (item1.Size > item2.StorageBelow)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceUnder_13956, item1!.ID, item1, item2!.ID));
                    of.FeedbackOutput = true;
                    of.Handled = true;
                    handled = true;
                }
                else if (item1!.ID == item2!.ID)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceUnder_13957, item1!.ID, item2!.ID));
                    of.FeedbackOutput = true;
                    of.Handled = true;
                    handled = true;
                }
                else
                {
                    if (EnsureTake(item1, PersonID, true))
                    {
                        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_PlaceUnder_Person_Everyone_13958, PersonID, item1!.ID, item2!.ID));
                        Items!.TransferItem(item1!.ID, CB!.LocType_Below_Item, item2!.ID);
                        of.StoryOutput = true;
                        of.Success = true;
                        of.Action = true;
                        of.Handled = true;
                    }
                    handled = true;
                }
            }
            else
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceUnder_Person_Everyone_13959, item2!.ID, item2));
                of.FeedbackOutput = true;
                of.Handled = true;
                handled = true;
            }
            return (handled);
        }

        public virtual bool PlaceIn(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);
            // bool doClose = false;

            if (item1!.ID == item2!.ID)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceIn_13960, item1!.ID, item2!.ID));
                of.FeedbackOutput = true;
                of.Handled = true;
                handled = true;
            }
            else if (item2.CanPutIn)
            {
                bool AutoOpen = false;

                // Wenn ein Item geschlossen ist, wird versucht, es zu öffnen
                if ((item2.IsClosed) && (item2.CanBeClosed))
                {
                    ParseTokenList PT = new ParseTokenList();
                    PT.AddVerb(CB!.Verb_Open);
                    PT.AddItem(item2);
                    if (Open(PersonID, PT))
                    {
                        if (item2.IsClosed == false)
                            AutoOpen = true;
                    }
                    // Wenn sich das Item nicht öffnen ließ, dann wurde hier ein Kommentar ausgegeben und diese Funktion muss nichts mehr schreiben.
                }
                if (((!item2.IsClosed) && (item2.CanBeClosed))
                     || (!item2.CanBeClosed)
                   )
                {
                    if (item1.Size > item2.StorageIn)
                    {
                        AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceIn_13961, item1!.ID, item1, item2!.ID));
                        of.FeedbackOutput = true;
                        of.Handled = true;
                        handled = true;
                    }
                    else
                    {
                        if (EnsureTake(item1, PersonID, true))
                        {
                            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_PlaceIn_Person_Everyone_13962, PersonID, item1!.ID, item2!.ID));
                            Items!.TransferItem(item1!.ID, CB!.LocType_In_Item, item2!.ID);
                            of.StoryOutput = true;
                            of.Success = true;
                            of.Action = true;
                            of.Handled = true;
                        }
                        handled = true;
                    }
                }
                if (AutoOpen)
                {
                    ParseTokenList PT = new ParseTokenList();
                    PT.AddVerb(CB!.Verb_Open);
                    PT.AddItem(item2);
                    Close(PersonID, PT);
                    AutoOpen = true;
                    // Wenn sich das Item nicht öffnen ließ, dann wurde hier ein Kommentar ausgegeben und diese Funktion muss nichts mehr schreiben.
                }
            }
            else
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceIn_Person_Everyone_13963, item2!.ID, item2));
                of.FeedbackOutput = true;
                of.Handled = true;
                handled = true;
            }
            return (handled);
        }

        public virtual bool PlaceInP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person2 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[3].WordID);

            if (person2.CanPutIn!)
            {
                bool autoOpen = false;

                // Wenn ein Item geschlossen ist, wird versucht, es zu öffnen
                if ((person2.IsClosed) && (person2.CanBeClosed))
                {
                    ParseTokenList PT = new ParseTokenList();
                    PT.AddVerb(CB!.Verb_Open);
                    PT.AddPerson(person2);
                    if (Open(PersonID, PT))
                        autoOpen = true;
                    // Wenn sich das Item nicht öffnen ließ, dann wurde hier ein Kommentar ausgegeben und diese Funktion muss nichts mehr schreiben.
                }
                if ((!person2.IsClosed) && (person2.CanBeClosed))
                {
                    if (item1.Size > person2.StorageIn)
                    {
                        AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceInP_13964, item1!.ID, item1, person2));
                        of.FeedbackOutput = true;
                        of.Handled = true;
                        handled = true;
                    }
                    else
                    {
                        if (EnsureTake(item1, PersonID, true))
                        {
                            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_PlaceInP_Person_Everyone_13965, PersonID, item1!.ID, person2));
                            Items!.TransferItem(item1!.ID, CB!.LocType_In_Person, person2!.ID);
                            of.StoryOutput = true;
                            of.Success = true;
                            of.Action = true;
                            of.Handled = true;
                        }
                        handled = true;
                    }
                }
                if (autoOpen)
                {
                    ParseTokenList PT = new ParseTokenList();
                    PT.AddVerb(CB!.Verb_Open);
                    PT.AddPerson(person2);
                    Close(PersonID, PT);
                    autoOpen = true;
                    // Wenn sich das Item nicht öffnen ließ, dann wurde hier ein Kommentar ausgegeben und diese Funktion muss nichts mehr schreiben.
                }
            }
            else
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceInP_Person_Everyone_13966, person2, item1));
                of.FeedbackOutput = true;
                of.Handled = true;
                handled = true;
            }
            return (handled);
        }

        public virtual bool GiveToP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool handled = false;

            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person2 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[3].WordID);

            if (item1.Size > person2.StorageIn)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_GiveToP_13967, person2, item1, item1!.ID));
                of.FeedbackOutput = true;
                of.Handled = true;
                handled = true;
            }
            else
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_GiveToP_Person_Everyone_13968, PersonID, item1!.ID, person2));
                Items!.TransferItem(item1!.ID, CB!.LocType_To_Person, person2!.ID);
                of.StoryOutput = true;
                of.Success = true;
                of.Action = true;
                of.Handled = true;
                handled = true;
            }
            return (handled);
        }

        public virtual bool ShowToP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool handled = false;

            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person2 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[3].WordID);

            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_ShowToP_Person_Everyone_13969, PersonID, item1!.ID, person2));
            of.StoryOutput = true;
            of.Success = true;
            of.Action = true;
            of.Handled = true;
            handled = true;
            return (handled);
        }

        public virtual bool PlaceOn(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            if (item2.CanPutOn)
            {
                if (item1.Size > item2.StorageOn)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceOn_13970, item1!.ID, item1, item2!.ID));
                    of.FeedbackOutput = true;
                    of.Handled = true;
                    handled = true;
                }
                else if (item1!.ID == item2!.ID)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceOn_13971, item1!.ID, item2!.ID));
                    of.FeedbackOutput = true;
                    of.Handled = true;
                    handled = true;
                }
                else
                {
                    if (EnsureTake(item1, PersonID, true))
                    {
                        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_PlaceOn_Person_Everyone_13972, PersonID, item1!.ID, item2!.ID));
                        Items!.TransferItem(item1!.ID, CB!.LocType_On_Item, item2!.ID);
                        of.StoryOutput = true;
                        of.Success = true;
                        of.Action = true;
                        of.Handled = true;
                    }
                    handled = true;
                }
            }
            else
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceOn_Person_Everyone_13973, item2!.ID, item2));
                of.FeedbackOutput = true;
                of.Handled = true;
                handled = true;
            }
            return (handled);
        }

        public virtual bool PlaceBehind(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool handled = false;

            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            if (item2.CanPutBehind)
            {
                if (item1.Size > item2.StorageBehind)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceBehind_13974, item1!.ID, item1, item2!.ID));
                    of.FeedbackOutput = true;
                    of.Handled = true;
                    handled = true;
                }
                else if (item1!.ID == item2!.ID)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceBehind_13975, item1!.ID, item2!.ID));
                    of.FeedbackOutput = true;
                    of.Handled = true;
                    handled = true;
                }
                else
                {
                    if (EnsureTake(item1, PersonID, true))
                    {
                        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_PlaceBehind_Person_Everyone_13976, PersonID, item1!.ID, item2!.ID));
                        Items!.TransferItem(item1!.ID, CB!.LocType_Behind_Item, item2!.ID);
                        of.StoryOutput = true;
                        of.Success = true;
                        of.Action = true;
                        of.Handled = true;
                    }
                    handled = true;
                }
            }
            else
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceBehind_Person_Everyone_13977, item2!.ID, item2));
                of.FeedbackOutput = true;
                of.Handled = true;
                handled = true;
            }
            return (handled);
        }

        public virtual bool PlaceBeside(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool handled = false;

            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            if (item2.CanPutBeside)
            {
                if (item1.Size > item2.StorageBeside)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceBeside_13978, item1!.ID, item1, item2!.ID));
                    of.FeedbackOutput = true;
                    of.Handled = true;
                    handled = true;
                }
                else if (item1!.ID == item2!.ID)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceBeside_13979, item1!.ID, item2!.ID));
                    of.FeedbackOutput = true;
                    of.Handled = true;
                    handled = true;
                }
                else
                {
                    if (EnsureTake(item1, PersonID, true))
                    {
                        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_PlaceBeside_Person_Everyone_13980, PersonID, item1!.ID, item2!.ID));
                        Items!.TransferItem(item1!.ID, CB!.LocType_Beside_Item, item2!.ID);
                        of.StoryOutput = true;
                        of.Success = true;
                        of.Action = true;
                        of.Handled = true;
                    }
                    handled = true;
                }
            }
            else
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_PlaceBeside_Person_Everyone_13981, item2!.ID, item1));
                of.FeedbackOutput = true;
                of.Handled = true;
                handled = true;
            }
            return (handled);
        }

        public virtual bool ExamineBelow(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_ExamineBelow_Person_Everyone_13982, PersonID, item1!.ID));
            ListItems(Helper.Insert(loca.OrderFeedback_ExamineBelow_Person_Everyone_13983, PersonID), PersonID, CB!.LocType_Below_Item, item1!.ID, true, false);
            of.StoryOutput = true;
            of.Success = true;
            of.Action = true;
            of.Handled = true;
            return (true);

        }

        public virtual bool Taste(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_Taste_Person_Everyone_13984, PersonID, item1!.ID));
            of.StoryOutput = true;
            of.Success = true;
            of.Action = true;
            of.Handled = true;
            return (true);
        }

        public virtual bool Smell(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_Smell_Person_Everyone_13985, PersonID, item1!.ID));
            of.StoryOutput = true;
            of.Success = true;
            of.Action = true;
            of.Handled = true;
            return (true);
        }

        public virtual bool SmellP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[2].WordID);
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_SmellP_Person_Everyone_13986, PersonID, person1));
            of.StoryOutput = true;
            of.Success = true;
            of.Action = true;
            of.Handled = true;
            return (true);
        }

        public virtual bool Wait(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_Wait_Person_Everyone_13987, PersonID));
            of.StoryOutput = true;
            of.Success = true;
            of.Action = true;
            of.Handled = true;
            return (true);
        }

        public virtual bool WaitFor(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[2].WordID);

            // Wenn die Person sich offensichtlich nicht bewegt, dann warten wir besser nciht.
            if (person1.GetController(AdvGame!) != null)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_WaitFor_13988, PersonID, person1));
                of.StoryOutput = true;
                of.Success = true;
                of.Action = true;
                of.Handled = true;

                int ct = 0;

                while (person1.locationID != A!.ActLoc)
                {
                    Persons!.DoNPCs();
                    locations!.Dolocations();
                    ct++;

                    if (ct > 100)
                    {
                        AdvGame!.StoryOutput(loca.OrderFeedback_WaitFor_13989);
                        break;
                    }
                }

            }
            return (false);
        }


        public bool DoQuit(List<MCMenuEntry> MCMEntry)
        {
            OrderFeedback of = new OrderFeedback();
            AdvGame!.Autosave();
            AdvGame!.A!.Finish = true;
            AdvGame!.DialogOngoing = false;
            AdvGame!.GD!.OrderList!.SaveOrderTable();
            AdvGame!.Close();
            return (false);
        }

        public virtual bool Quit(Person PersonID, ParseTokenList PTL)
        {
            if (AdvGame!.GD!.SilentMode)
            {
                AdvGame!.StoryOutput(loca.OrderFeedback_Quit_13990);
                return false;
            }

            OrderFeedback of = new OrderFeedback();
            MCMenu mcM = new MCMenu(Stats!, Persons!, CA!.Person_Self!, A!, AdvGame!, true, 1 + CB!.MCE_Choice_Off, false);
            List<int> cFollower;
            cFollower = new List<int>();

            // 1 
            cFollower.Add(1);
            mcM.Add(new MCMenuEntry(null, loca.OrderFeedback_Quit_Person_Self_13991, 1, 0, false));

            // 2 
            cFollower.Add(2);
            mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.OrderFeedback_Quit_Person_Self_13992, 2, -1, false));
            mcM.Last()!.SetDel(DoQuit);

            // 3 
            cFollower.Add(3);
            mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.OrderFeedback_Quit_Person_Self_13993, 3, -1, false));

            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));

            mcM.MCS = mcM.MenuShow();
            
            mcM.Set(0);
            this.temporaryMCMenu = mcM;
            this.persistentMCMenu = null;
            mcM.MCS.MCOutput(mcM, mcM.MCSelection, false);


            return (false);
        }

        public virtual bool Restart(Person PersonID, ParseTokenList PTL)
        {
            if (AdvGame!.GD!.SilentMode)
            {
                AdvGame!.StoryOutput(loca.OrderFeedback_Restart_13994);
                return false;
            }
            OrderFeedback of = new OrderFeedback();
            MCMenu mcM = new MCMenu(Stats!, Persons!, CA!.Person_Self!, A!, AdvGame!, true, 1 + CB!.MCE_Choice_Off, false);
            List<int> cFollower;
            cFollower = new List<int>();

            // 1 
            cFollower.Add(1);
            mcM.Add(new MCMenuEntry(null, loca.OrderFeedback_Restart_Person_Self_13995, 1, 0, false));


            if (loca.GD?.Language == IGlobalData.language.german)
            {
                cFollower.Add(2);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.OrderFeedback_Restart_Person_Self_13996, 2, -1, false));
                mcM.Last()!.SetDel(AdvGame!.DoMCRestartDeutsch);

                /*
                cFollower.Add(3);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.OrderFeedback_Restart_Person_Self_13996a, 3, -1, false));
                mcM.Last()!.SetDel(AdvGame!.DoMCRestartEnglisch);
                */
                // 4 
                cFollower.Add(4);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.OrderFeedback_Restart_Person_Self_13997, 4, -1, false));

            }
            else
            {
                cFollower.Add(2);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.OrderFeedback_Restart_Person_Self_13996, 2, -1, false));
                mcM.Last()!.SetDel(AdvGame!.DoMCRestartEnglisch);
                /*
                cFollower.Add(3);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.OrderFeedback_Restart_Person_Self_13996a, 3, -1, false));
                mcM.Last()!.SetDel(AdvGame!.DoMCRestartDeutsch);
                */
                // 4 
                cFollower.Add(4);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.OrderFeedback_Restart_Person_Self_13997, 4, -1, false));

            }

            // 2 

            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));

            mcM.MCS = mcM.MenuShow();
            mcM.Set(0);
            this.temporaryMCMenu = mcM;
            this.persistentMCMenu = null;
            mcM.MCS.MCOutput(mcM, mcM.MCSelection, false);


            return (false);
        }


        public virtual bool RestartNoAsk(Person PersonID, ParseTokenList PTL)
        {
            if (AdvGame!.GD!.SilentMode == false)
            {
                AdvGame!.FeedbackOutput(loca.OrderFeedback_RestartNoAsk_13998);
                return true;
            }
            OrderFeedback of = new OrderFeedback();
            loca.GD!.Language = IGlobalData.language.german;
            AdvGame!.UIS!.ExecuteRestart();

            return (true);
        }
        public virtual bool RestartNoAskGerman(Person PersonID, ParseTokenList PTL)
        {
            if (AdvGame!.GD!.SilentMode == false)
            {
                AdvGame!.FeedbackOutput(loca.OrderFeedback_RestartNoAsk_13998);
                return true;
            }
            OrderFeedback of = new OrderFeedback();
            loca.GD!.Language = IGlobalData.language.german;
            AdvGame!.UIS!.ExecuteRestart();

            return (true);
        }
        public virtual bool RestartNoAskEnglish(Person PersonID, ParseTokenList PTL)
        {
            if (AdvGame!.GD!.SilentMode == false)
            {
                AdvGame!.FeedbackOutput(loca.OrderFeedback_RestartNoAsk_13998);
                return true;
            }
            OrderFeedback of = new OrderFeedback();
            loca.GD!.Language = IGlobalData.language.english;
            AdvGame!.UIS!.ExecuteRestart();

            return (true);
        }


        public virtual bool ExamineIn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            bool success = true;
            OrderFeedback of = new OrderFeedback();

            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);

            if (item1.CanPutIn == false)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_ExamineIn_13999, item1!.ID));
                handled = true;
            }
            else if (item1.CanBeClosed && item1.IsClosed)
            {
                if (item1.CanBeLocked && item1.IsLocked)
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.OrderFeedback_ExamineIn_14000, item1!.ID, item1));
                    handled = true;
                    success = false;
                    of.FeedbackOutput = true;
                    of.Handled = true;
                    of.Success = false;
                    of.Action = true;
                }
                else if (PTL.ConvenienceActionNotOpenFirst == false)
                {
                    ParseTokenList PT = new ParseTokenList();
                    PT.AddVerb(CB!.Verb_Open);
                    PT.AddItem(item1);
                    PT.ConvenienceActionNotExamineAfter = true;
                    success = Open(PersonID, PT);
                    PT.ConvenienceActionNotExamineAfter = false;
                    of.StoryOutput = true;
                    of.Handled = true;
                    of.Success = success;
                    of.Action = true;
                }
            }
            if (!handled && success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_ExamineIn_Person_Everyone_14001, PersonID, item1!.ID));
                // ListItems( Helper.Insert(loca.OrderFeedback_ExamineIn_Person_Everyone_14002, PersonID ), PersonID, CB!.LocType_In_Item, item1!.ID, true, false, Co.CASE_NOM_UNDEF, null, loca.OrderFeedback_ExamineIn_Person_Everyone_14003 );
                ListItemsPersons(Helper.Insert(loca.OrderFeedback_ExamineIn_Person_Everyone_14002, PersonID), PersonID, CB!.LocType_In_Item, item1!.ID, true, false, Co.CASE_NOM_UNDEF);
                of.StoryOutput = true;
                of.Handled = true;
                of.Action = true;

                handled = true;
            }
            return (handled);

        }

        public virtual bool ExamineOn(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_ExamineOn_Person_Everyone_14004, PersonID, item1!.ID));
            ListItems(Helper.Insert(loca.OrderFeedback_ExamineOn_Person_Everyone_14005, PersonID), PersonID, CB!.LocType_On_Item, item1!.ID, true, false);
            of.StoryOutput = true;
            of.Handled = true;
            of.Success = true;
            of.Action = true;
            return (true);

        }

        public virtual bool ExamineBehind(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_ExamineBehind_Person_Everyone_14006, PersonID, item1!.ID));
            ListItems(Helper.Insert(loca.OrderFeedback_ExamineBehind_Person_Everyone_14007, PersonID), PersonID, CB!.LocType_Behind_Item, item1!.ID, true, false);
            of.StoryOutput = true;
            of.Handled = true;
            of.Success = true;
            of.Action = true;
            return (true);
        }

        public virtual bool ExamineBeside(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_ExamineBeside_Person_Everyone_14008, PersonID, item1!.ID!));
            ListItems(Helper.Insert(loca.OrderFeedback_ExamineBeside_Person_Everyone_14009, PersonID), PersonID, CB!.LocType_Beside_Item, item1!.ID!, true, false);
            of.StoryOutput = true;
            of.Handled = true;
            of.Success = true;
            of.Action = true;
            return (true);
        }

        public virtual bool KnockOn(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_KnockOn_Person_Everyone_14010, PersonID, item1!.ID));
            of.StoryOutput = true;
            of.Handled = true;
            of.Success = true;
            of.Action = true;
            return (true);

        }
        public virtual bool KnockOnP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Person person1= PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[2].WordID);
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.OrderFeedback_KnockOn_Person_Everyone_14010, PersonID, person1));
            of.StoryOutput = true;
            of.Handled = true;
            of.Success = true;
            of.Action = true;
            return (true);

        }


        public virtual bool SaveMC(Person PersonID, ParseTokenList PTL)
        {
            if (AdvGame!.GD!.SilentMode)
            {
                AdvGame!.StoryOutput(loca.OrderFeedback_SaveMC_14011);
                return false;
            }

            OrderFeedback of = new OrderFeedback();
            int idCt = 1;
            // char Key = '1';

            MCMenu mcM = AdvGame!.AdvMCMenu(A!.Adventure!.CA!.Person_I!, false, 1 + CB!.MCE_Choice_Off);
            List<int> follower;


            follower = new List<int>();
            follower.Add(-1);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, loca.OrderFeedback_SaveMC_Person_I_14012, idCt++, follower, null, 0, false, false, false, null, null));

            for (int i = 0; i < 10; i++)
            {
                int Val = i + 1;

                // string? pathName = GlobalData.CurrentPath();
                // Ignores: 002
                string? fileName = Phoney_MAUI.Core.GlobalData.CurrentPath() + loca.OrderFeedback_LoadMC_Person_I_14025 + Val + loca.OrderFeedback_LoadMC_Person_I_14026;

                if (AdvGame.UIS!.ExistFile( fileName))
                {
                    AdvGame!.GD!.SlotDescriptions!.SlotDescriptions![Val] = loca.SlotDescription_Init_16284;
                    // mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.OrderFeedback_SaveMC_Person_I_14013 + loca.OrderFeedback_SaveMC_Person_I_14014 + loca.OrderFeedback_SaveMC_Person_I_14015 + loca.OrderFeedback_SaveMC_Person_I_14016, idCt++, follower, null, 0, false, false, false, null, loca.OrderFeedback_SaveMC_Person_I_14017 + loca.OrderFeedback_SaveMC_Person_I_14018));
                }
                mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, "Slot " + $"{Val:00}" + ": " + $"{AdvGame!.GD!.SlotDescriptions!.SlotDescriptions![Val]}", idCt++, follower, null, 0, false, false, false, null, "speicher " + $"{Val:00}"));
            }


            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.OrderFeedback_SaveMC_Person_I_14019, idCt++, follower, null, 0, false, false, false, null, null));

            follower = new List<int>();
            for (int j = 1; j < idCt; j++)
            {
                follower.Add(j);

            }
            mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, " ", CB!.MCE_Choice_Off + 1, follower, null, 0, false, false, false, null, null));

            mcM.MCS = mcM.MenuShow();
            mcM.Set(0);
            this.temporaryMCMenu = mcM;
            this.persistentMCMenu = null;
            // MCM.AddCurrent(1);
            mcM.MCS.MCOutput(mcM, SaveSelection, false);
            of.Handled = true;
            of.Success = false;
            of.Action = false;
            return (false);
        }

        public bool SaveSelection(MCMenu MCM, int Selection)
        {
            OrderFeedback of = new OrderFeedback();
            if (Selection == -1)
            {
                MCM.OutputExit();
            }
            else if (Selection == -2)
            {
                MCM.OutputExit();
            }
            else
            {
                ParseTokenList PT = new ParseTokenList();

                PT.AddNothing(0);
                switch (Selection - 1)
                {
                    case 1: PT.AddPrep(CB!.Prep_Slot1); break;
                    case 2: PT.AddPrep(CB!.Prep_Slot2); break;
                    case 3: PT.AddPrep(CB!.Prep_Slot3); break;
                    case 4: PT.AddPrep(CB!.Prep_Slot4); break;
                    case 5: PT.AddPrep(CB!.Prep_Slot5); break;
                    case 6: PT.AddPrep(CB!.Prep_Slot6); break;
                    case 7: PT.AddPrep(CB!.Prep_Slot7); break;
                    case 8: PT.AddPrep(CB!.Prep_Slot8); break;
                    case 9: PT.AddPrep(CB!.Prep_Slot9); break;
                    case 10: PT.AddPrep(CB!.Prep_Slot10); break;
                }
                // PT.AddPrep(Selection - 1 + CB!.Prep_Slot1 - 1);

                if (Selection > 1 && Selection <= 11)
                    Save(Persons!.Find(A!.ActPerson)!, PT);

                MCM.OutputExit();
            }
            of.Handled = true;
            of.Success = false;
            of.Action = false;

            return (false);
        }

        public bool LoadSelection(MCMenu MCM, int Selection)
        {
            OrderFeedback of = new OrderFeedback();
            if (Selection == -1)
            {
                MCM.OutputExit();
            }
            else if (Selection == -2)
            {
                MCM.OutputExit();
            }
            else
            {
                ParseTokenList PT = new ParseTokenList();

                if (MCM.FindID(Selection)!.Text!.Substring(0, 5) == loca.OrderFeedback_LoadSelection_14020)
                {
                    int tSelection = Convert.ToInt32(MCM.FindID(Selection)!.Text!.Substring(5, 2));

                    Prep SlotID = CB!.Prep_Slot1!;
                    switch (tSelection)
                    {
                        case 1: SlotID = CB!.Prep_Slot1!; break;
                        case 2: SlotID = CB!.Prep_Slot2!; break;
                        case 3: SlotID = CB!.Prep_Slot3!; break;
                        case 4: SlotID = CB!.Prep_Slot4!; break;
                        case 5: SlotID = CB!.Prep_Slot5!; break;
                        case 6: SlotID = CB!.Prep_Slot6!; break;
                        case 7: SlotID = CB!.Prep_Slot7!; break;
                        case 8: SlotID = CB!.Prep_Slot8!; break;
                        case 9: SlotID = CB!.Prep_Slot9!; break;
                        case 10: SlotID = CB!.Prep_Slot10!; break;
                    }

                    PT.AddNothing(0);
                    PT.AddPrep(SlotID);

                    Load(Persons!.Find(A!.ActPerson)!, PT);
                    AdvGame!.DoUIUpdate();
                    AdvGame!.SetScoreOutput();
                    MCM.OutputExit();
                }
                else
                {
                    MCM.OutputExit();
                }

            }
            of.Handled = true;
            of.Success = false;
            of.Action = false;

            return (false);
        }

        public virtual bool LoadMC(Person PersonID, ParseTokenList PTL)
        {
            if (AdvGame!.GD!.SilentMode)
            {
                AdvGame!.StoryOutput(loca.OrderFeedback_LoadMC_14021);
                return false;
            }

            OrderFeedback of = new OrderFeedback();
            int idCt = 1;
            // char Key = '1';

            MCMenu mcM = AdvGame!.AdvMCMenu(A!.Adventure!.CA!.Person_I!, false, 1 + CB!.MCE_Choice_Off);
            List<int> follower;


            follower = new List<int>();
            follower.Add(-1);
            mcM.Add(new MCMenuEntry(CB!.MCE_Text, null, loca.OrderFeedback_LoadMC_Person_I_14022, idCt++, follower, null, 0, false, false, false, null, null));

            for (int i = 0; i < 10; i++)
            {
                int Val = i + 1;
                // string? pathName = GlobalData.CurrentPath();
                // Ignores: 002
                string? fileName = loca.OrderFeedback_LoadMC_Person_I_14025 + Val + loca.OrderFeedback_LoadMC_Person_I_14026;

                if (AdvGame.UIS!.ExistFile(fileName))
                {
                    // Ignores: 003
                    mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, "Slot " + $"{Val:00}" + ": " + $"{AdvGame!.GD!.SlotDescriptions!.SlotDescriptions![Val]}", idCt++, follower, null, 0, false, false, false, null, "lade " + $"{Val:00}"));
                    // mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.OrderFeedback_LoadMC_Person_I_14027 + loca.OrderFeedback_LoadMC_Person_I_14028+ loca.OrderFeedback_LoadMC_Person_I_14029 + loca.OrderFeedback_LoadMC_Person_I_14030, idCt++, follower, null, 0, false, false, false, null, loca.OrderFeedback_LoadMC_Person_I_14031 + loca.OrderFeedback_LoadMC_Person_I_14032));
                    // IDCt++;
                }
            }


            mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I, loca.OrderFeedback_LoadMC_Person_I_14033, idCt++, follower, null, 0, false, false, false, null, null));

            follower = new List<int>();
            for (int j = 1; j < idCt; j++)
            {
                follower.Add(j);

            }
            mcM.Add(new MCMenuEntry(CB!.MCE_Choice, null, " ", CB!.MCE_Choice_Off + 1, follower, null, 0, false, false, false, null, null));

            mcM.MCS = mcM.MenuShow(); ;
            mcM.Set(0);
            // MCM.AddCurrent(1);
            this.temporaryMCMenu = mcM;
            this.persistentMCMenu = null;
            mcM.MCS.MCOutput(mcM, LoadSelection, false);
            of.Handled = true;
            of.Success = false;
            of.Action = false;
            return (false);

        }


        public void CoreSave(string fileName, bool forceSave = false)
        {
            AdvGame!.UIS!.InitPath();

            /* 21.8.2023: Dieses SaveObj wird hier nicht mehr benötigt
            SaveObj SO = new SaveObj();
            SO.jsonOrderListTable = AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx];
            SO.jsonLanguage = AdvGame!.GD!.Language;
            SO.jsonItems = Items;   // done
            SO.jsonlocations = locations;
            SO.jsonPersons = Persons; // done
            SO.jsonTopics = Topics;
            SO.jsonAdjs = Adjs;
            SO.jsonA = A;
            SO.jsonNouns = Nouns;
            SO.jsonVerbs = Verbs;
            SO.jsonPreps = Preps;
            SO.jsonPronouns = Pronouns;
            SO.jsonFills = Fills;
            SO.jsonStats = Stats;
            SO.jsonScores = Scores;
            SO.jsonLI = LI;
            SO.jsonCA = CA;
            SO.jsonCB = CB;
            SO.jsonStoryText = AdvGame!.STE;
            SO.jsonFeedbackText = AdvGame!.FBE;
            SO.jsonFeedbackText.FeedbackModeMC = false;
            SO.jsonVerbTenses = AdvGame!.VerbTenses;
            SO.jsonPV = AdvGame!.PV;
            SO.jsonVersion = AdvGame!.GD!.Version;
            SO.jsonItemQueue = ItemQueue;

            AdvGame.UIS.CoreSaveToFile(SO, fileName);
            */


            SaveGame( fileName, forceSave );
        }

        /*
        public void CoreSaveToFile(SaveObj SO, string fileName)
        {
            string pathfileName = GlobalData.CurrentPathPlusFilename(fileName);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(pathfileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, SO);
            stream.Close();

        }
        */
        public void SaveItems(ref string output)
        {
            int ix = 0;

            try
            {
                foreach (var dict in Items!.List!)
                {
                    Item it = dict.Value;
                    Item it2 = AdvGame!.GD!.StartStatus!.jsonItems!.List![dict.Key];

                    bool changedIx = false;
                    string changes = "";

                    if (it.locationType != it2.locationType)
                    {
                        changes += string.Format("locationType: {0}\n", it.locationType.ToString());
                        changedIx = true;
                    }
                    if (it.locationID != it2.locationID)
                    {
                        changes += string.Format("locationID: {0}\n", it.locationID.ToString());
                        changedIx = true;
                    }
                    if (it.CanBeClosed != it2.CanBeClosed)
                    {
                        changes += string.Format("CanBeClosed: {0}\n", it.CanBeClosed.ToString());
                        changedIx = true;
                    }
                    if (it.CanBeLocked != it2.CanBeLocked)
                    {
                        changes += string.Format("CanBeLocked: {0}\n", it.CanBeLocked.ToString());
                        changedIx = true;
                    }
                    if (it.IsClosed != it2.IsClosed)
                    {
                        changes += string.Format("IsClosed: {0}\n", it.IsClosed.ToString());
                        changedIx = true;
                    }
                    if (it.IsLocked != it2.IsLocked)
                    {
                        changes += string.Format("IsLocked: {0}\n", it.IsLocked.ToString());
                        changedIx = true;
                    }
                    if (it.IsCage != it2.IsCage)
                    {
                        changes += string.Format("IsCage: {0}\n", it.IsCage.ToString());
                        changedIx = true;
                    }
                    if (it.ListInsideItems != it2.ListInsideItems)
                    {
                        changes += string.Format("ListInsideItems: {0}\n", it.ListInsideItems!.ToString());
                        changedIx = true;
                    }
                    if (it.CanPutIn != it2.CanPutIn)
                    {
                        changes += string.Format("CanPutIn: {0}\n", it.CanPutIn.ToString());
                        changedIx = true;
                    }
                    if (it.CanPutBehind != it2.CanPutBehind)
                    {
                        changes += string.Format("CanPutBehind: {0}\n", it.CanPutBehind.ToString());
                        changedIx = true;
                    }
                    if (it.CanPutBelow != it2.CanPutBelow)
                    {
                        changes += string.Format("CanPutBelow: {0}\n", it.CanPutBelow.ToString());
                        changedIx = true;
                    }
                    if (it.CanPutOn != it2.CanPutOn)
                    {
                        changes += string.Format("CanPutOn: {0}\n", it.CanPutOn.ToString());
                        changedIx = true;
                    }
                    if (it.CanPutBeside != it2.CanPutBeside)
                    {
                        changes += string.Format("CanPutBeside: {0}\n", it.CanPutBeside.ToString());
                        changedIx = true;
                    }
                    if (it.InvisibleIn != it2.InvisibleIn)
                    {
                        changes += string.Format("InvisibleIn: {0}\n", it.InvisibleIn.ToString());
                        changedIx = true;
                    }
                    if (it.InvisibleOn != it2.InvisibleOn)
                    {
                        changes += string.Format("InvisibleOn: {0}\n", it.InvisibleOn.ToString());
                        changedIx = true;
                    }
                    if (it.InvisibleBehind != it2.InvisibleBehind)
                    {
                        changes += string.Format("InvisibleBehind: {0}\n", it.InvisibleBehind.ToString());
                        changedIx = true;
                    }
                    if (it.InvisibleBelow != it2.InvisibleBelow)
                    {
                        changes += string.Format("InvisibleBelow: {0}\n", it.InvisibleBelow.ToString());
                        changedIx = true;
                    }
                    if (it.InvisibleBeside != it2.InvisibleBeside)
                    {
                        changes += string.Format("InvisibleBeside: {0}\n", it.InvisibleBeside.ToString());
                        changedIx = true;
                    }
                    if (it.IsDressed != it2.IsDressed)
                    {
                        changes += string.Format("IsDressed: {0}\n", it.IsDressed.ToString());
                        changedIx = true;
                    }
                    if (it.Dressable != it2.Dressable)
                    {
                        changes += string.Format("Dressable: {0}\n", it.Dressable.ToString());
                        changedIx = true;
                    }
                    if (it.IsRegular != it2.IsRegular)
                    {
                        changes += string.Format("IsRegular: {0}\n", it.IsRegular.ToString());
                        changedIx = true;
                    }
                    if (it.IsMovable != it2.IsMovable)
                    {
                        changes += string.Format("IsMovable: {0}\n", it.IsMovable.ToString());
                        changedIx = true;
                    }
                    if (it.IsCountable != it2.IsCountable)
                    {
                        changes += string.Format("IsCountable: {0}\n", it.IsCountable.ToString());
                        changedIx = true;
                    }
                    if (it.IsBackground != it2.IsBackground)
                    {
                        changes += string.Format("IsBackground: {0}\n", it.IsBackground.ToString());
                        changedIx = true;
                    }
                    if (it.IsMentionable != it2.IsMentionable)
                    {
                        changes += string.Format("IsMentionable: {0}\n", it.IsMentionable.ToString());
                        changedIx = true;
                    }
                    if (it.IsLessImportant != it2.IsLessImportant)
                    {
                        changes += string.Format("IsLessImportant: {0}\n", it.IsLessImportant.ToString());
                        changedIx = true;
                    }
                    if (it.CanBeTaken != it2.CanBeTaken)
                    {
                        changes += string.Format("CanBeTaken: {0}\n", it.CanBeTaken.ToString());
                        changedIx = true;
                    }

                    bool listUnlockItems = false;
                    // 
                    if (it.UnlockItems!.Count != it2.UnlockItems!.Count)
                        listUnlockItems = true;
                    else if (it.UnlockItems!.Count > 0)
                    {
                        int ix2;
                        for (ix2 = 0; ix2 < it.UnlockItems!.Count; ix2++)
                        {
                            if (it.UnlockItems[ix2] != it2.UnlockItems[ix2])
                                listUnlockItems = true;
                        }
                    }
                    if (listUnlockItems)
                    {
                        changes += string.Format("UnlockItems: {0}\n", it.UnlockItems!.Count.ToString());

                        int ix2;

                        for (ix2 = 0; ix2 < it.UnlockItems!.Count; ix2++)
                        {
                            changes += string.Format("{0}\n", it.UnlockItems[ix2]);
                        }
                        changedIx = true;
                    }
                    if (it.Size != it2.Size)
                    {
                        changes += string.Format("Size: {0}\n", it.Size.ToString());
                        changedIx = true;
                    }
                    if (it.StorageIn != it2.StorageIn)
                    {
                        changes += string.Format("StorageIn: {0}\n", it.StorageIn.ToString());
                        changedIx = true;
                    }
                    if (it.StorageOn != it2.StorageOn)
                    {
                        changes += string.Format("StorageOn: {0}\n", it.StorageOn.ToString());
                        changedIx = true;
                    }
                    if (it.StorageBehind != it2.StorageBehind)
                    {
                        changes += string.Format("StorageBehind: {0}\n", it.StorageBehind.ToString());
                        changedIx = true;
                    }
                    if (it.StorageBelow != it2.StorageBelow)
                    {
                        changes += string.Format("StorageBelow: {0}\n", it.StorageBelow.ToString());
                        changedIx = true;
                    }
                    if (it.StorageBeside != it2.StorageBeside)
                    {
                        changes += string.Format("StorageBeside: {0}\n", it.StorageBeside.ToString());
                        changedIx = true;
                    }
                    if (it.ShowStorageIn != it2.ShowStorageIn)
                    {
                        changes += string.Format("ShowStorageIn: {0}\n", it.ShowStorageIn.ToString());
                        changedIx = true;
                    }
                    if (it.ShowStorageOn != it2.ShowStorageOn)
                    {
                        changes += string.Format("ShowStorageOn: {0}\n", it.ShowStorageOn.ToString());
                        changedIx = true;
                    }
                    if (it.IsHidden != it2.IsHidden)
                    {
                        changes += string.Format("IsHidden: {0}\n", it.IsHidden.ToString());
                        changedIx = true;
                    }
                    if (it.locationStatic != it2.locationStatic)
                    {
                        changes += string.Format("locationStatic: {0}\n", it.locationStatic.ToString());
                        changedIx = true;
                    }
                    if (it!.ID != it2!.ID)
                    {
                        changes += string.Format("ID: {0}\n", it!.ID.ToString());
                        changedIx = true;
                    }
                    if (it.Active != it2.Active)
                    {
                        changes += string.Format("Active: {0}\n", it.Active.ToString());
                        changedIx = true;
                    }
                    if (it._sexGer != it2._sexGer)
                    {
                        changes += string.Format("_sexGer: {0}\n", it._sexGer.ToString());
                        changedIx = true;
                    }
                    if (it._sexEng != it2._sexEng)
                    {
                        changes += string.Format("_sexEng: {0}\n", it._sexEng.ToString());
                        changedIx = true;
                    }
                    if (it.LocaDescription != it2.LocaDescription)
                    {
                        changes += string.Format("LocaDescription: {0}\n", it.LocaDescription!.ToString());
                        changedIx = true;
                    }
                    if (it.Picture != it2.Picture)
                    {
                        changes += string.Format("Picture: {0}\n", it.Picture!.ToString());
                        changedIx = true;
                    }
                    if (it.controllerName != it2.controllerName)
                    {
                        changes += string.Format("controllerName: {0}\n", it.controllerName!.ToString());
                        changedIx = true;
                    }
                    if (it._appendix != it2._appendix && it2._appendix != null)
                    {
                        changes += string.Format("_appendix: {0}\n", it._appendix!.ToString());
                        changedIx = true;
                    }
                    if (it.Known != it2.Known)
                    {
                        changes += string.Format("Known: {0}\n", it.Known.ToString());
                        changedIx = true;
                    }
                    if (it.Relevance != it2.Relevance)
                    {
                        changes += string.Format("Relevance: {0}\n", it.Relevance.ToString());
                        changedIx = true;
                    }


                    bool listNames = false;
                    // 
                    if (it._names!.Count != it2._names!.Count)
                        listNames = true;
                    else if (it._names.Count > 0)
                    {
                        int ix2;
                        for (ix2 = 0; ix2 < it._names.Count; ix2++)
                        {
                            if (it._names[ix2]!.ID != it2._names[ix2]!.ID)
                                listNames = true;
                        }
                    }
                    if (listNames)
                    {
                        changes += string.Format("Names: {0}\n", it._names.Count.ToString());

                        int ix2;

                        for (ix2 = 0; ix2 < it._names.Count; ix2++)
                        {
                            changes += string.Format("{0}\n", it._names[ix2]!.ID);
                        }
                        changedIx = true;
                    }

                    bool listSynNames = false;
                    // 
                    if (it._synNames!.Count != it2._synNames!.Count)
                        listSynNames = true;
                    else if (it._synNames.Count > 0)
                    {
                        int ix2;
                        for (ix2 = 0; ix2 < it._synNames.Count; ix2++)
                        {
                            if (it._synNames[ix2]!.ID != it2._synNames[ix2]!.ID)
                                listSynNames = true;
                        }
                    }
                    if (listSynNames)
                    {
                        changes += string.Format("SynNames: {0}\n", it._synNames.Count.ToString());

                        int ix2;

                        for (ix2 = 0; ix2 < it._synNames.Count; ix2++)
                        {
                            changes += string.Format("{0}\n", it._synNames[ix2]!.ID);
                        }
                        changedIx = true;
                    }

                    bool listNamesEng = false;
                    // 
                    if (it2._namesEng == null)
                    {

                    }
                    else if (it._namesEng == null)
                    {
                        listNamesEng = true;
                    }
                    else if (it._namesEng!.Count != it2._namesEng!.Count)
                        listNamesEng = true;
                    else if (it._namesEng!.Count > 0)
                    {
                        int ix2;
                        for (ix2 = 0; ix2 < it._namesEng!.Count; ix2++)
                        {
                            if (it._namesEng[ix2]!.ID != it._namesEng[ix2]!.ID)
                                listNamesEng = true;
                        }
                    }
                    if (listNamesEng)
                    {
                        changes += string.Format("NamesEng: {0}\n", it._namesEng!.Count!.ToString());

                        int ix2;

                        for (ix2 = 0; ix2 < it._namesEng.Count; ix2++)
                        {
                            changes += string.Format("{0}\n", it._namesEng[ix2]!.ID);
                        }
                        changedIx = true;
                    }

                    bool listSynNamesEng = false;
                    // 
                    if (it2._synNamesEng == null)
                    {

                    }
                    else if (it._synNamesEng == null)
                    {
                        listNamesEng = true;
                    }
                    else if (it._synNamesEng!.Count != it2._synNamesEng!.Count)
                        listSynNamesEng = true;
                    else if (it._synNames!.Count > 0)
                    {
                        int ix2;
                        for (ix2 = 0; ix2 < it2._synNamesEng!.Count; ix2++)
                        {
                            if (it._synNamesEng[ix2]!.ID != it2._synNamesEng[ix2]!.ID)
                                listSynNamesEng = true;
                        }
                    }
                    if (listSynNamesEng)
                    {
                        changes += string.Format("SynNamesEng: {0}\n", it._synNamesEng!.Count.ToString());

                        int ix2;

                        for (ix2 = 0; ix2 < it._synNamesEng.Count; ix2++)
                        {
                            changes += string.Format("{0}\n", it._synNamesEng[ix2]!.ID);
                        }
                        changedIx = true;
                    }


                    bool listAdjectives = false;
                    // 
                    if (it._adjectives == null)
                    {
                        listNamesEng = true;
                    }
                    else if (it._adjectives!.Count != it2._adjectives!.Count)
                        listAdjectives = true;
                    else if (it._adjectives.Count > 0)
                    {
                        int ix2;
                        for (ix2 = 0; ix2 < it2._adjectives.Count; ix2++)
                        {
                            if (it._adjectives[ix2]!.ID != it2._adjectives[ix2]!.ID)
                                listAdjectives = true;
                        }
                    }
                    if (listAdjectives)
                    {
                        changes += string.Format("Adjectives: {0}\n", it!._adjectives!.Count.ToString());

                        int ix2;

                        for (ix2 = 0; ix2 < it._adjectives.Count; ix2++)
                        {
                            changes += string.Format("{0}\n", it._adjectives[ix2]!.ID);
                        }
                        changedIx = true;
                    }

                    bool listSynAdjectives = false;
                    // 
                    if (it._synAdjectives!.Count != it2._synAdjectives!.Count)
                        listSynAdjectives = true;
                    else if (it._synAdjectives.Count > 0)
                    {
                        int ix2;
                        for (ix2 = 0; ix2 < it2._synAdjectives.Count; ix2++)
                        {
                            if (it._synAdjectives[ix2]!.ID != it2._synAdjectives[ix2]!.ID)
                                listSynAdjectives = true;
                        }
                    }
                    if (listSynAdjectives)
                    {
                        changes += string.Format("SynAdjectives: {0}\n", it._synAdjectives.Count.ToString());

                        int ix2;

                        for (ix2 = 0; ix2 < it._synAdjectives.Count; ix2++)
                        {
                            changes += string.Format("{0}\n", it._synAdjectives[ix2]!.ID);
                        }
                        changedIx = true;
                    }


                    bool listAdjectivesEng = false;
                    // 
                    if (it2._adjectivesEng == null)
                    {

                    }
                    else if (it._adjectivesEng == null)
                    {
                        listAdjectivesEng = true;

                    }
                    else if (it._adjectivesEng!.Count != it2._adjectivesEng!.Count)
                        listAdjectivesEng = true;
                    else if (it._adjectivesEng.Count > 0)
                    {
                        int ix2;
                        for (ix2 = 0; ix2 < it2._adjectivesEng.Count; ix2++)
                        {
                            if (it._adjectivesEng[ix2]!.ID != it2._adjectivesEng[ix2]!.ID)
                                listAdjectivesEng = true;
                        }
                    }
                    if (listAdjectivesEng)
                    {
                        changes += string.Format("AdjectivesEng: {0}\n", it._adjectivesEng!.Count.ToString());

                        int ix2;

                        for (ix2 = 0; ix2 < it._adjectivesEng.Count; ix2++)
                        {
                            changes += string.Format("{0}\n", it._adjectivesEng[ix2]!.ID);
                        }
                        changedIx = true;
                    }

                    bool listSynAdjectivesEng = false;
                    // 
                    if (it2._synAdjectivesEng == null)
                    {

                    }
                    else if (it._synAdjectivesEng!.Count != it2._synAdjectivesEng!.Count)
                        listSynAdjectivesEng = true;
                    else if (it._synAdjectivesEng!.Count > 0)
                    {
                        int ix2;
                        for (ix2 = 0; ix2 < it2._synAdjectivesEng.Count; ix2++)
                        {
                            if (it._synAdjectivesEng[ix2]!.ID != it2._synAdjectivesEng[ix2]!.ID)
                                listSynAdjectivesEng = true;
                        }
                    }
                    if (listSynAdjectivesEng)
                    {
                        changes += string.Format("SynAdjectivesEng: {0}\n", it._synAdjectivesEng!.Count.ToString());

                        int ix2;

                        for (ix2 = 0; ix2 < it._synAdjectivesEng.Count; ix2++)
                        {
                            changes += string.Format("{0}\n", it._synAdjectivesEng[ix2]!.ID);
                        }
                        changedIx = true;
                    }

                    bool listCategoryRel = false;

                    if (it.Categories!.List!.Count != it2.Categories!.List!.Count)
                        listCategoryRel = true;
                    else if (it.Categories!.List.Count > 0)
                    {
 

                        var it2CatList = it2.Categories!.List.GetEnumerator();

                        foreach ( CategoryRel cr in it.Categories!.List.Values)
                        {
                            if (it2CatList.Current.Value != null)
                            {
                                if ((cr.CategoryID == it2CatList.Current.Value.CategoryID)
                                        || (cr.CounterCategoryID != it2CatList.Current.Value.CounterCategoryID)
                                  )
                                    listCategoryRel = true;
                            }
                            it2CatList.MoveNext();
                        }
                        /*
                        for (ix2 = 0; ix2 < it.Categories!.List.Count; ix2++)
                        {
                            if ((it.Categories!.List[ix2].CategoryID != it2.Categories!.List[ix2].CategoryID)
                                    || (it.Categories!.List[ix2].CounterCategoryID != it2.Categories!.List[ix2].CounterCategoryID)
                              )
                                listCategoryRel = true;
                        }
                        */
                    }
                    if (listCategoryRel)
                    {
                        changes += string.Format("Categories: {0}\n", it.Categories!.List.Count.ToString());

                        // int ix2;

                        foreach (CategoryRel cr in it.Categories!.List.Values)
                        {
                            changes += string.Format("{0} {1} {2}\n", cr.CategoryID, cr.CounterCategoryID, cr.Relevance );
                        }
                        /*
                            for (ix2 = 0; ix2 < it.Categories!.List.Count; ix2++)
                        {
                            changes += string.Format("{0} {1}\n", it.Categories!.List[ix2].CategoryID, it.Categories!.List[ix2].CounterCategoryID);
                        }
                        */
                        changedIx = true;
                    }


                    bool listStatus = false;

                    if (it.SL!.Count != it2.SL!.Count)
                        listStatus = true;
                    else if (it.SL.List.Count > 0)
                    {
                        int ix2;
                        for (ix2 = 0; ix2 < it2.SL.List.Count; ix2++)
                        {
                            if ((it.SL.List[ix2]!.ID != it2.SL.List[ix2]!.ID)
                                    || (it.SL.List[ix2].Val != it2.SL.List[ix2].Val)
                              )
                                listStatus = true;
                        }
                    }
                    if (listStatus)
                    {
                        changes += string.Format("Status: {0}\n", it.SL.List.Count.ToString());

                        int ix2;

                        for (ix2 = 0; ix2 < it.SL.List.Count; ix2++)
                        {
                            changes += string.Format("{0} {1}\n", it.SL.List[ix2]!.ID, it.SL.List[ix2].Val);
                        }
                        changedIx = true;
                    }

                    // SL


                    // Alles durch?
                    if (changedIx)
                    {
                        output += string.Format("Item: {0}\n", dict.Key);
                        output += changes;
                    }

                    ix++;
                }
            }
            catch // ( Exception e)
            {

            }
        }

        public void SavePersons(ref string output)
        {
            int ix = 0;

            foreach (var dict in Persons!.List!)
            {
                Person pe = dict.Value;
                Person pe2 = AdvGame!.GD!.StartStatus!.jsonPersons!.List![dict.Key]!;

                bool changedIx = false;
                string changes = "";

                if (pe.locationType != pe2.locationType)
                {
                    changes += string.Format("locationType: {0}\n", pe.locationType.ToString());
                    changedIx = true;
                }
                if (pe.locationID != pe2.locationID)
                {
                    changes += string.Format("locationID: {0}\n", pe.locationID.ToString());
                    changedIx = true;
                }
                if (pe.CanCarryItems != pe2.CanCarryItems)
                {
                    changes += string.Format("CanCarryItems: {0}\n", pe.CanCarryItems!.ToString());
                    changedIx = true;
                }
                if (pe.Size != pe2.Size)
                {
                    changes += string.Format("Size: {0}\n", pe.Size.ToString());
                    changedIx = true;
                }
                if (pe.Storage != pe2.Storage)
                {
                    changes += string.Format("Storage: {0}\n", pe.Storage.ToString());
                    changedIx = true;
                }
                if (pe.StorageIn != pe2.StorageIn)
                {
                    changes += string.Format("StorageIn: {0}\n", pe.StorageIn.ToString());
                    changedIx = true;
                }
                if (pe.CanBeClosed != pe2.CanBeClosed)
                {
                    changes += string.Format("CanBeClosed: {0}\n", pe.CanBeClosed.ToString());
                    changedIx = true;
                }
                if (pe.CanBeLocked != pe2.CanBeLocked)
                {
                    changes += string.Format("CanBeLocked: {0}\n", pe.CanBeLocked.ToString());
                    changedIx = true;
                }
                if (pe.IsClosed != pe2.IsClosed)
                {
                    changes += string.Format("IsClosed: {0}\n", pe.IsClosed.ToString());
                    changedIx = true;
                }
                if (pe.IsLocked != pe2.IsLocked)
                {
                    changes += string.Format("IsLocked: {0}\n", pe.IsLocked.ToString());
                    changedIx = true;
                }
                if (pe.CanBeTaken != pe2.CanBeTaken)
                {
                    changes += string.Format("CanBeTaken: {0}\n", pe.CanBeTaken.ToString());
                    changedIx = true;
                }
                if (pe.HereTextLoca != pe2.HereTextLoca)
                {
                    changes += string.Format("HereTextLoca: {0}\n", pe.HereTextLoca!.ToString()!);
                    changedIx = true;
                }
                if (pe.ActivityBlocked != pe2.ActivityBlocked)
                {
                    changes += string.Format("ActivityBlocked: {0}\n", pe.ActivityBlocked.ToString());
                    changedIx = true;
                }
                if (pe.IsRegular != pe2.IsRegular)
                {
                    changes += string.Format("IsRegular: {0}\n", pe.IsRegular.ToString());
                    changedIx = true;
                }
                if (pe.IsBackground != pe2.IsBackground)
                {
                    changes += string.Format("IsBackground: {0}\n", pe.IsBackground.ToString());
                    changedIx = true;
                }
                if (pe.IsHidden != pe2.IsHidden)
                {
                    changes += string.Format("IsHidden: {0}\n", pe.IsHidden.ToString());
                    changedIx = true;
                }
                if (pe.IsWanderer != pe2.IsWanderer)
                {
                    changes += string.Format("IsWanderer: {0}\n", pe.IsWanderer.ToString());
                    changedIx = true;
                }


                bool listUnlockItems = false;
                // 
                if (pe.UnlockItems!.Count != pe2.UnlockItems!.Count)
                    listUnlockItems = true;
                else if (pe.UnlockItems!.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < pe.UnlockItems!.Count; ix2++)
                    {
                        if (pe.UnlockItems[ix2] != pe.UnlockItems[ix2])
                            listUnlockItems = true;
                    }
                }
                if (listUnlockItems)
                {
                    changes += string.Format("UnlockItems: {0}\n", pe.UnlockItems!.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < pe.UnlockItems!.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", pe.UnlockItems[ix2]);
                    }
                    changedIx = true;
                }

                bool listWanderer = false;
                // 
                if (pe2.WandererList == null)
                {

                }
                else if (pe.WandererList == null)
                    listWanderer = true;
                else if (pe.WandererList.Count != pe2.WandererList.Count)
                    listWanderer = true;
                else if (pe.WandererList.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < pe.WandererList.Count; ix2++)
                    {
                        if (pe.WandererList[ix2] != pe2.WandererList[ix2])
                            listWanderer = true;
                    }
                }
                if (listWanderer)
                {
                    changes += string.Format("WandererList: {0}\n", pe.WandererList!.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < pe.WandererList.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", pe.WandererList[ix2]);
                    }
                    changedIx = true;
                }

                if (pe!.ID != pe2!.ID)
                {
                    changes += string.Format("ID: {0}\n", pe!.ID.ToString());
                    changedIx = true;
                }
                if (pe.Active != pe2.Active)
                {
                    changes += string.Format("Active: {0}\n", pe.Active.ToString());
                    changedIx = true;
                }
                if (pe._sexGer != pe2._sexGer)
                {
                    changes += string.Format("_sexGer: {0}\n", pe._sexGer.ToString());
                    changedIx = true;
                }
                if (pe._sexEng != pe2._sexEng)
                {
                    changes += string.Format("_sexEng: {0}\n", pe._sexEng.ToString());
                    changedIx = true;
                }

                if (pe.LocaDescription != pe2.LocaDescription)
                {
                    changes += string.Format("LocaDescription: {0}\n", pe.LocaDescription!.ToString());
                    changedIx = true;
                }
                if (pe.Picture != pe2.Picture)
                {
                    changes += string.Format("Picture: {0}\n", pe.Picture!.ToString());
                    changedIx = true;
                }
                if (pe.controllerName != pe2.controllerName)
                {
                    changes += string.Format("controllerName: {0}\n", pe.controllerName!.ToString());
                    changedIx = true;
                }
                if (pe._appendix != pe2._appendix)
                {
                    changes += string.Format("_appendix: {0}\n", pe._appendix!.ToString());
                    changedIx = true;
                }
                if (pe.Known != pe2.Known)
                {
                    changes += string.Format("Known: {0}\n", pe.Known.ToString());
                    changedIx = true;
                }
                if (pe.Relevance != pe2.Relevance)
                {
                    changes += string.Format("Relevance: {0}\n", pe.Relevance.ToString());
                    changedIx = true;
                }


                bool listNames = false;
                // 
                if (pe._names!.Count != pe2._names!.Count)
                    listNames = true;
                else if (pe._names.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < pe._names.Count; ix2++)
                    {
                        if (pe._names[ix2]!.ID != pe2._names[ix2]!.ID)
                            listNames = true;
                    }
                }
                if (listNames)
                {
                    changes += string.Format("Names: {0}\n", pe._names.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < pe._names.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", pe._names[ix2]!.ID);
                    }
                    changedIx = true;
                }

                bool listSynNames = false;
                // 
                if (pe!._synNames!.Count != pe2!._synNames!.Count)
                    listSynNames = true;
                else if (pe._synNames.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < pe2._synNames.Count; ix2++)
                    {
                        if (pe._synNames[ix2]!.ID != pe2._synNames[ix2]!.ID)
                            listSynNames = true;
                    }
                }
                if (listSynNames)
                {
                    changes += string.Format("SynNames: {0}\n", pe._synNames.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < pe._synNames.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", pe._synNames[ix2]!.ID);
                    }
                    changedIx = true;
                }

                bool listNamesEng = false;
                // 
                if (pe2._namesEng == null)
                {

                }
                else if (pe._namesEng!.Count != pe2._namesEng!.Count)
                    listNamesEng = true;
                else if (pe._namesEng.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < pe2._namesEng.Count; ix2++)
                    {
                        if (pe._namesEng[ix2]!.ID != pe2._namesEng[ix2]!.ID)
                            listNamesEng = true;
                    }
                }
                if (listNamesEng)
                {
                    changes += string.Format("NamesEng: {0}\n", pe._namesEng!.Count.ToString()!);

                    int ix2;

                    for (ix2 = 0; ix2 < pe._namesEng.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", pe._namesEng[ix2]!.ID);
                    }
                    changedIx = true;
                }

                bool listSynNamesEng = false;
                // 
                if (pe2._synNamesEng == null)
                {

                }
                else if (pe._synNamesEng!.Count != pe2._synNamesEng!.Count)
                    listSynNamesEng = true;
                else if (pe._synNames.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < pe2._synNamesEng.Count; ix2++)
                    {
                        if (pe._synNamesEng[ix2]!.ID != pe2._synNamesEng[ix2]!.ID)
                            listSynNamesEng = true;
                    }
                }
                if (listSynNamesEng)
                {
                    changes += string.Format("SynNamesEng: {0}\n", pe._synNamesEng!.Count.ToString()!);

                    int ix2;

                    for (ix2 = 0; ix2 < pe._synNamesEng.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", pe._synNamesEng[ix2]!.ID);
                    }
                    changedIx = true;
                }


                bool listAdjectives = false;
                // 
                if (pe!._adjectives!.Count != pe2!._adjectives!.Count)
                    listAdjectives = true;
                else if (pe._adjectives.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < pe2._adjectives.Count; ix2++)
                    {
                        if (pe._adjectives[ix2]!.ID != pe2._adjectives[ix2]!.ID)
                            listAdjectives = true;
                    }
                }
                if (listAdjectives)
                {
                    changes += string.Format("Adjectives: {0}\n", pe._adjectives.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < pe._adjectives.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", pe._adjectives[ix2]!.ID);
                    }
                    changedIx = true;
                }

                bool listSynAdjectives = false;
                // 
                if (pe._synAdjectives!.Count != pe2._synAdjectives!.Count)
                    listSynAdjectives = true;
                else if (pe._synAdjectives.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < pe2._synAdjectives.Count; ix2++)
                    {
                        if (pe._synAdjectives[ix2]!.ID != pe2._synAdjectives[ix2]!.ID)
                            listSynAdjectives = true;
                    }
                }
                if (listSynAdjectives)
                {
                    changes += string.Format("SynAdjectives: {0}\n", pe._synAdjectives.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < pe._synAdjectives.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", pe._synAdjectives[ix2]!.ID);
                    }
                    changedIx = true;
                }


                bool listAdjectivesEng = false;
                // 
                if (pe2._adjectivesEng == null)
                {

                }
                else if (pe!._adjectivesEng!.Count != pe2!._adjectivesEng!.Count)
                    listAdjectivesEng = true;
                else if (pe._adjectivesEng.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < pe2._adjectivesEng.Count; ix2++)
                    {
                        if (pe._adjectivesEng[ix2]!.ID != pe2._adjectivesEng[ix2]!.ID)
                            listAdjectivesEng = true;
                    }
                }
                if (listAdjectivesEng)
                {
                    changes += string.Format("AdjectivesEng: {0}\n", pe!._adjectivesEng!.Count.ToString()!);

                    int ix2;

                    for (ix2 = 0; ix2 < pe._adjectivesEng.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", pe._adjectivesEng[ix2]!.ID);
                    }
                    changedIx = true;
                }

                bool listSynAdjectivesEng = false;
                // 
                if (pe2._synAdjectivesEng == null)
                {

                }
                else if (pe!._synAdjectivesEng!.Count != pe2!._synAdjectivesEng!.Count)
                    listSynAdjectivesEng = true;
                else if (pe._synAdjectivesEng.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < pe2._synAdjectivesEng.Count; ix2++)
                    {
                        if (pe._synAdjectivesEng[ix2]!.ID != pe2._synAdjectivesEng[ix2]!.ID)
                            listSynAdjectivesEng = true;
                    }
                }
                if (listSynAdjectivesEng)
                {
                    changes += string.Format("SynAdjectivesEng: {0}\n", pe._synAdjectivesEng!.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < pe._synAdjectivesEng.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", pe._synAdjectivesEng[ix2]!.ID);
                    }
                    changedIx = true;
                }

                bool listCategoryRel = false;

                if (pe.Categories!.List!.Count != pe2.Categories!.List!.Count)
                    listCategoryRel = true;
                else if (pe.Categories!.List.Count > 0)
                {
                    // int ix2;


                    var pe2CatList = pe2.Categories!.List.GetEnumerator();

                    foreach (CategoryRel cr in pe.Categories!.List.Values)
                    {
                        if (pe2CatList.Current.Value != null)
                        {
                            if ((cr.CategoryID == pe2CatList.Current.Value.CategoryID)
                                    || (cr.CounterCategoryID != pe2CatList.Current.Value.CounterCategoryID)
                              )
                                listCategoryRel = true;
                        }
                        pe2CatList.MoveNext();
                    }
                }
                if (listCategoryRel)
                {
                    changes += string.Format("Categories: {0}\n", pe.Categories!.List.Count.ToString());

                    // int ix2;

                    foreach (CategoryRel cr in pe.Categories!.List.Values)
                    {
                        changes += string.Format("{0} {1} {2}\n", cr.CategoryID, cr.CounterCategoryID, cr.Relevance );
                    }

                    changedIx = true;
                }

                /*

                else if (pe.Categories!.List.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < pe2.Categories!.List.Count; ix2++)
                    {
                        if ((pe.Categories!.List[ix2].CategoryID != pe2.Categories!.List[ix2].CategoryID)
                                || (pe.Categories!.List[ix2].CounterCategoryID != pe2.Categories!.List[ix2].CounterCategoryID)
                          )
                            listCategoryRel = true;
                    }
                }
                if (listCategoryRel)
                {
                    changes += string.Format("Categories: {0}\n", pe.Categories!.List.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < pe.Categories!.List.Count; ix2++)
                    {
                        changes += string.Format("{0} {1}\n", pe.Categories!.List[ix2].CategoryID, pe.Categories!.List[ix2].CounterCategoryID);
                    }
                    changedIx = true;
                }
                */

                bool listStatus = false;

                if (pe.SL!.Count != pe2.SL!.Count)
                    listStatus = true;
                else if (pe.SL.List.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < pe2.SL.List.Count; ix2++)
                    {
                        if ((pe.SL.List[ix2]!.ID != pe2.SL.List[ix2]!.ID)
                                || (pe.SL.List[ix2].Val != pe2.SL.List[ix2].Val)
                          )
                            listStatus = true;
                    }
                }
                if (listStatus)
                {
                    changes += string.Format("Status: {0}\n", pe.SL.List.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < pe.SL.List.Count; ix2++)
                    {
                        changes += string.Format("{0} {1}\n", pe.SL.List[ix2]!.ID, pe.SL.List[ix2].Val);
                    }
                    changedIx = true;
                }

                // DialogLists
                bool dialogLists = false;

                if (pe.DialogList!.Count > 0 )
                    dialogLists = true;

                if (dialogLists)
                {
                    string zw1 = string.Format("DialogList: {0}\n", pe.DialogList.Count);
                    changes += zw1;

                    foreach (DialogList dl in pe.DialogList)
                    {

                        string zw = JsonConvert.SerializeObject(dl.LatestDialog);
                        changes += string.Format("Name: {0} {1}\n", dl.FuncName, zw.Length);
                        changes += zw + "\n";
                    }
                    /*
                    changes += string.Format("Status: {0}\n", pe.SL.List.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < pe.SL.List.Count; ix2++)
                    {
                        changes += string.Format("{0} {1}\n", pe.SL.List[ix2]!.ID, pe.SL.List[ix2].Val);
                    }
                    changedIx = true;
                    */
                }


                // SL


                // Alles durch?
                if (changedIx)
                {
                    output += string.Format("Person: {0}\n", dict.Key );
                    output += changes;
                }

                ix++;
            }

        }
        public void SaveTopics(string output)
        {
            int ix = 0;

            foreach (var dict in Topics!.List!)
            {
                Topic tp = dict;
                Topic tp2  = AdvGame!.GD!.StartStatus!.jsonTopics!.List![ix];

                bool changedIx = false;
                string changes = "";


                if (tp!.ID != tp2!.ID)
                {
                    changes += string.Format("ID: {0}\n", tp2!.ID.ToString());
                    changedIx = true;
                }
                if (tp.Active != tp2.Active)
                {
                    changes += string.Format("Active: {0}\n", tp2.Active.ToString());
                    changedIx = true;
                }
                if (tp._sexGer != tp2._sexGer)
                {
                    changes += string.Format("_sexGer: {0}\n", tp2._sexGer.ToString());
                    changedIx = true;
                }
                if (tp._sexEng != tp2._sexEng)
                {
                    changes += string.Format("_sexEng: {0}\n", tp2._sexEng.ToString());
                    changedIx = true;
                }

                if (tp.LocaDescription != tp2.LocaDescription)
                {
                    changes += string.Format("LocaDescription: {0}\n", tp2.LocaDescription!.ToString());
                    changedIx = true;
                }
                if (tp.Picture != tp2.Picture)
                {
                    changes += string.Format("Picture: {0}\n", tp2.Picture!.ToString());
                    changedIx = true;
                }
                if (tp.controllerName != tp2.controllerName)
                {
                    changes += string.Format("controllerName: {0}\n", tp2.controllerName!.ToString());
                    changedIx = true;
                }
                if (tp._appendix != tp2._appendix)
                {
                    changes += string.Format("_appendix: {0}\n", tp2._appendix!.ToString());
                    changedIx = true;
                }
                if (tp.Known != tp2.Known)
                {
                    changes += string.Format("Known: {0}\n", tp2.Known.ToString());
                    changedIx = true;
                }
                if (tp.Relevance != tp2.Relevance)
                {
                    changes += string.Format("Relevance: {0}\n", tp2.Relevance.ToString());
                    changedIx = true;
                }


                bool listNames = false;
                // 
                if (tp._names!.Count != tp2._names!.Count)
                    listNames = true;
                else if (tp._names.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < tp2._names.Count; ix2++)
                    {
                        if (tp._names[ix2]!.ID != tp2._names[ix2]!.ID)
                            listNames = true;
                    }
                }
                if (listNames)
                {
                    changes += string.Format("Names: {0}\n", tp2._names.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < tp2._names.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", tp2._names[ix2]!.ID);
                    }
                    changedIx = true;
                }

                bool listSynNames = false;
                // 
                if (tp._synNames!.Count != tp2._synNames!.Count)
                    listSynNames = true;
                else if (tp._synNames.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < tp2._synNames.Count; ix2++)
                    {
                        if (tp._synNames[ix2]!.ID != tp2._synNames[ix2]!.ID)
                            listSynNames = true;
                    }
                }
                if (listSynNames)
                {
                    changes += string.Format("Names: {0}\n", tp2._synNames.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < tp2._synNames.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", tp2._synNames[ix2]!.ID);
                    }
                    changedIx = true;
                }

                bool listNamesEng = false;
                // 
                if (tp2._namesEng == null)
                {

                }
                else if (tp._namesEng!.Count != tp2._namesEng!.Count)
                    listNamesEng = true;
                else if (tp._namesEng.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < tp2._namesEng.Count; ix2++)
                    {
                        if (tp._namesEng[ix2]!.ID != tp2._namesEng[ix2]!.ID)
                            listNamesEng = true;
                    }
                }
                if (listNamesEng)
                {
                    changes += string.Format("Names: {0}\n", tp2._namesEng!.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < tp2._namesEng.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", tp2._namesEng[ix2]!.ID);
                    }
                    changedIx = true;
                }

                bool listSynNamesEng = false;
                // 
                if (tp2._synNamesEng == null)
                {

                }
                else if (tp._synNamesEng!.Count != tp2._synNamesEng!.Count)
                    listSynNamesEng = true;
                else if (tp._synNames.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < tp2._synNamesEng.Count; ix2++)
                    {
                        if (tp._synNamesEng[ix2]!.ID != tp2._synNamesEng[ix2]!.ID)
                            listSynNamesEng = true;
                    }
                }
                if (listSynNamesEng)
                {
                    changes += string.Format("Names: {0}\n", tp2._synNamesEng!.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < tp2._synNamesEng.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", tp2._synNamesEng[ix2]!.ID);
                    }
                    changedIx = true;
                }


                bool listAdjectives = false;
                // 
                if (tp._adjectives!.Count != tp2._adjectives!.Count)
                    listAdjectives = true;
                else if (tp._adjectives.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < tp2._adjectives.Count; ix2++)
                    {
                        if (tp._adjectives[ix2]!.ID != tp2._adjectives[ix2]!.ID)
                            listAdjectives = true;
                    }
                }
                if (listAdjectives)
                {
                    changes += string.Format("Names: {0}\n", tp2._adjectives.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < tp2._adjectives.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", tp2._adjectives[ix2]!.ID);
                    }
                    changedIx = true;
                }

                bool listSynAdjectives = false;
                // 
                if (tp._synAdjectives!.Count != tp2._synAdjectives!.Count)
                    listSynAdjectives = true;
                else if (tp._synAdjectives.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < tp2._synAdjectives.Count; ix2++)
                    {
                        if (tp._synAdjectives[ix2]!.ID != tp2._synAdjectives[ix2]!.ID)
                            listSynAdjectives = true;
                    }
                }
                if (listSynAdjectives)
                {
                    changes += string.Format("Names: {0}\n", tp2._synAdjectives.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < tp2._synAdjectives.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", tp2._synAdjectives[ix2]!.ID);
                    }
                    changedIx = true;
                }


                bool listAdjectivesEng = false;
                // 
                if (tp2._adjectivesEng == null)
                {

                }
                else if (tp._adjectivesEng!.Count != tp2._adjectivesEng!.Count)
                    listAdjectivesEng = true;
                else if (tp._adjectivesEng.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < tp2._adjectivesEng!.Count; ix2++)
                    {
                        if (tp._adjectivesEng[ix2]!.ID != tp2._adjectivesEng[ix2]!.ID)
                            listAdjectivesEng = true;
                    }
                }
                if (listAdjectivesEng)
                {
                    changes += string.Format("Names: {0}\n", tp2._adjectivesEng!.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < tp2._adjectivesEng.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", tp2._adjectivesEng[ix2]!.ID);
                    }
                    changedIx = true;
                }

                bool listSynAdjectivesEng = false;
                // 
                if (tp2._synAdjectivesEng == null)
                {

                }
                else if (tp._synAdjectivesEng!.Count != tp2._synAdjectivesEng!.Count)
                    listSynAdjectivesEng = true;
                else if (tp._synAdjectivesEng.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < tp2._synAdjectivesEng.Count; ix2++)
                    {
                        if (tp._synAdjectivesEng[ix2]!.ID != tp2._synAdjectivesEng[ix2]!.ID)
                            listSynAdjectivesEng = true;
                    }
                }
                if (listSynAdjectivesEng)
                {
                    changes += string.Format("Names: {0}\n", tp2._synAdjectivesEng!.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < tp2._synAdjectivesEng.Count; ix2++)
                    {
                        changes += string.Format("{0}\n", tp2._synAdjectivesEng[ix2]!.ID);
                    }
                    changedIx = true;
                }

                bool listCategoryRel = false;

                if (tp.Categories!.List!.Count != tp2.Categories!.List!.Count)
                    listCategoryRel = true;
                else if (tp.Categories!.List.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < tp2.Categories!.List.Count; ix2++)
                    {
                        if ((tp.Categories!.List[ix2].CategoryID != tp2.Categories!.List[ix2].CategoryID)
                                || (tp.Categories!.List[ix2].CounterCategoryID != tp2.Categories!.List[ix2].CounterCategoryID)
                          )
                            listCategoryRel = true;
                    }
                }
                if (listCategoryRel)
                {
                    changes += string.Format("Categories: {0}\n", tp2.Categories!.List.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < tp2.Categories!.List.Count; ix2++)
                    {
                        changes += string.Format("{0} {1}\n", tp2.Categories!.List[ix2].CategoryID, tp2.Categories!.List[ix2].CounterCategoryID);
                    }
                    changedIx = true;
                }


                bool listStatus = false;

                if (tp.SL!.Count != tp2.SL!.Count)
                    listStatus = true;
                else if (tp.SL.List.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < tp2.SL.List.Count; ix2++)
                    {
                        if ((tp.SL.List[ix2]!.ID != tp2.SL.List[ix2]!.ID)
                                || (tp.SL.List[ix2].Val != tp2.SL.List[ix2].Val)
                          )
                            listStatus = true;
                    }
                }
                if (listStatus)
                {
                    changes += string.Format("Status: {0}\n", tp2.SL.List.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < tp2.SL.List.Count; ix2++)
                    {
                        changes += string.Format("{0} {1}\n", tp2.SL.List[ix2]!.ID, tp2.SL.List[ix2].Val);
                    }
                    changedIx = true;
                }

                // SL


                // Alles durch?
                if (changedIx)
                {
                    output += string.Format("Item: {0}\n", ix);
                    output += changes;
                }

                ix++;
            }

        }

        public void SaveLocations(ref string output)
        {
            int ix = 0;

            foreach (var dict in locations!.List)
            {
                location lc = dict.Value;
                location lc2 = AdvGame!.GD!.StartStatus!.jsonlocations!.List[dict.Key];

                bool changedIx = false;
                string changes = "";

                if (lc.LocaLocName != lc2.LocaLocName)
                {
                    changes += string.Format("LocaLocName: {0}\n", lc.LocaLocName!.ToString());
                    changedIx = true;
                }
                if (lc.LocaLocDesc != lc2.LocaLocDesc)
                {
                    if (lc2.LocaLocDesc == null)
                        changes += string.Format("LocaLocDesc: null\n");
                    else
                        changes += string.Format("LocaLocDesc: {0}\n", lc.LocaLocDesc!.ToString());
                    changedIx = true;
                }
                if (lc.LocaLocDescRaw != lc2.LocaLocDescRaw)
                {
                    if (lc2.LocaLocDescRaw == null)
                        changes += string.Format("LocaLocDescRaw: null\n");
                    else
                        changes += string.Format("LocaLocDescRaw: {0}\n", lc!.LocaLocDescRaw!.ToString());
                    changedIx = true;
                }
                if (lc.LocPicture != lc2.LocPicture && lc2.LocPicture != null )
                {
                    changes += string.Format("LocPicture: {0}\n", lc.LocPicture!.ToString());
                    changedIx = true;
                }
                if (lc!.ID != lc2!.ID)
                {
                    changes += string.Format("ID: {0}\n", lc!.ID.ToString());
                    changedIx = true;
                }
                if (lc.Visited != lc2.Visited)
                {
                    changes += string.Format("Visited: {0}\n", lc.Visited.ToString());
                    changedIx = true;
                }
                if (lc.controllerName != lc2.controllerName)
                {
                    changes += string.Format("controllerName: {0}\n", lc.controllerName!.ToString());
                    changedIx = true;
                }
                if (lc.ActivityBlocked != lc2.ActivityBlocked)
                {
                    changes += string.Format("ActivityBlocked: {0}\n", lc.ActivityBlocked.ToString());
                    changedIx = true;
                }

                for (int ix2 = 0; ix2 < 10; ix2++)
                {
                    if (lc.LocExit[ix2] != lc2.LocExit[ix2])
                    {
                        changes += string.Format("LocExit: {0} {1}\n", ix2.ToString(), lc.LocExit[ix2].ToString());
                        changedIx = true;

                    }
                }
                for (int ix2 = 0; ix2 < 10; ix2++)
                {
                    if (lc.LocExitBlocker[ix2] != lc2.LocExitBlocker[ix2])
                    {
                        changes += string.Format("LocExitBlocker: {0} {1}\n", ix2.ToString(), lc.LocExitBlocker[ix2].ToString());
                        changedIx = true;

                    }
                }

                bool listLocAdds = false;

                if (lc.locadd.Count != lc2.locadd.Count)
                    listLocAdds = true;
                else if (lc2.locadd.Count > 0)
                {
                    int ix2;
                    for (ix2 = 0; ix2 < lc2.locadd.Count; ix2++)
                    {
                        if ((lc.locadd[ix2].Stat != lc2.locadd[ix2].Stat)
                                || (lc.locadd[ix2].Val != lc2.locadd[ix2].Val)
                                || (lc.locadd[ix2].Loca != lc2.locadd[ix2].Loca)
                            )
                            listLocAdds = true;
                    }
                }
                if (listLocAdds)
                {
                    changes += string.Format("locadd: {0}\n", lc.locadd.Count.ToString());

                    int ix2;

                    for (ix2 = 0; ix2 < lc.locadd.Count; ix2++)
                    {
                        changes += string.Format("{0} {1} {2}\n", lc.locadd[ix2].Stat, lc.locadd[ix2].Val, lc.locadd[ix2].Loca);
                    }
                    changedIx = true;
                }



                if (changedIx)
                {
                    output += string.Format("Location: {0}\n", dict.Key);
                    output += changes;
                }

                ix++;
            }
        }

        public void SaveStats(ref string output)
        {
            int ix = 0;

            foreach (var dict in Stats!.List!)
            {
                Status st = dict;
                Status st2 = AdvGame!.GD!.StartStatus!.jsonStats!.List[ix];

                bool changedIx = false;
                string changes = "";

                if (st!.ID != st2!.ID)
                {
                    changes += string.Format("ID: {0}\n", st!.ID.ToString());
                    changedIx = true;

                }
                if (st.Val != st2.Val)
                {
                    changes += string.Format("Val: {0}\n", st.Val.ToString());
                    changedIx = true;

                }


                if (changedIx)
                {
                    output += string.Format("Stat: {0}\n", ix);
                    output += changes;
                }

                ix++;

            }
        }
        public void SaveScores(ref string output)
        {
            int ix = 0;

            foreach (var dict in Scores!.Scores!)
            {
                Score sc = dict;
                Score sc2 = AdvGame!.GD!.StartStatus!.jsonScores!.Scores![ix!]!;

                bool changedIx = false;
                string changes = "";

                if (sc!.ID != sc2!.ID)
                {
                    changes += string.Format("ID: {0}\n", sc!.ID.ToString());
                    changedIx = true;

                }
                if (sc.SpoilerState != sc2.SpoilerState)
                {
                    changes += string.Format("SpoilerState: {0}\n", sc.SpoilerState.ToString());
                    changedIx = true;

                }
                if (sc.Val != sc2.Val)
                {
                    changes += string.Format("Val: {0}\n", sc.Val.ToString());
                    changedIx = true;

                }

                if (sc.Active != sc2.Active)
                {
                    changes += string.Format("Active: {0}\n", sc.Active.ToString());
                    changedIx = true;

                }
                if (sc.Chapter!= sc2.Chapter)
                {
                    changes += string.Format("Chapter: {0}\n", sc.Chapter.ToString());
                    changedIx = true;

                }
                if (sc.Comment != sc2.Comment )
                {
                    if (sc2.Comment != null)
                    {
                        changes += string.Format("Comment: {0}\n", sc.LocaComment!.ToString());
                        changedIx = true;
                    }
                }


                if (changedIx)
                {
                    output += string.Format("Score: {0}\n", ix);
                    output += changes;
                }

                ix++;
            }
        }

        public void SaveLanguages( ref string output )
        {
            bool changedIx = false;
            string changes = "";

            IGlobalData.language? language = AdvGame!.GD!.Language;
            IGlobalData.language? language2 = AdvGame!.GD!.StartStatus!.jsonLanguage;

            // if (language != language2 )
            {
                changes += string.Format("{0}\n", language );
                changedIx = true;

            }
            if (changedIx)
            {
                output += string.Format("Language Info:\n" );
                output += changes;
            }

        }

        // Hier wird nicht verglichen, sondern auf die Platte geschrieben, fertig
        public void SaveLI( ref string output )
        {
            // GlobalData.language? language2 = AdvGame!.GD!.StartStatus!.jsonLanguage;

            for ( int ix = 0; ix < LI!.Count; ix++)
            {
                output += string.Format("LatestInput:\n{0}\n", LI![ix]!.Text!);
            }
        }

        // Hier wird nicht verglichen, sondern auf die Platte geschrieben, fertig
        public void SaveItemQueue(ref string output)
        {
            for (int ix = 0; ix < AdvGame!.GD!.StartStatus!.jsonItemQueue!._itemQueue!.Count; ix++)
            {
                output += string.Format("ItemQueue ID: {0}\n", AdvGame!.GD!.StartStatus!.jsonItemQueue!._itemQueue![ix]!.ID)!;
            }
        }

        public void SaveSTE(ref string output)
        {
            StringBuilder changes = new();

            IStoryText STE = AdvGame!.STE;
            IStoryText STE2 = AdvGame!.GD!.StartStatus!.jsonStoryText!;

            changes.Append( "STE:\n" );

            // changes += string.Format("latestHtmlOutput:\n{0}@vv@\n", StoryText.latestHtmlOutput);
            // changes += string.Format("latestHtmlOutputReget:\n{0}@vv@\n", StoryText.latestHtmlOutputReget);
            changes.Append(  string.Format("_currentLinesPerTurn: {0}\n", STE!.CurrentLinesPerTurn!) );
            changes.Append(  string.Format("FullRefresh: {0}\n", STE!.FullRefresh) );
            changes.Append(string.Format("HTMLLoaded: {0}\n", STE!.HTMLLoaded) );

            if (STE.OldDividingLine != null)
                changes.Append(string.Format("oldDividingLine:\n{0}@vv@\n", STE.OldDividingLine) );
            if (STE.OldMoreLine != null)
                changes.Append(string.Format("oldMoreLine:\n{0}@vv@\n", STE.OldMoreLine) );
            if (STE.BufferedInput != null)
                changes.Append(string.Format("BufferedInput:\n{0}@vv@\n", STE.BufferedInput) );

            changes.Append(  string.Format("STELines: {0} \n", STE.Slines!.Count) );

            for (int ix = 0; ix < STE.Slines!.Count!; ix++)
            {
                changes.Append(  string.Format("{0}\n", STE.Slines[ix]!.Length) ) ;

                changes.Append( string.Format("{0}\n", STE.Slines[ix]) ) ;

            }

            output += changes.ToString() ;

            /*
            // bool changedIx = false;
            string changes = "";

            IStoryText STE = AdvGame!.STE;
            IStoryText STE2 = AdvGame!.GD!.StartStatus!.jsonStoryText!;

            changes += "STE:\n";

            // changes += string.Format("latestHtmlOutput:\n{0}@vv@\n", StoryText.latestHtmlOutput);
            // changes += string.Format("latestHtmlOutputReget:\n{0}@vv@\n", StoryText.latestHtmlOutputReget);
            changes += string.Format("_currentLinesPerTurn: {0}\n", STE!.CurrentLinesPerTurn!);
            changes += string.Format("FullRefresh: {0}\n", STE!.FullRefresh);
            changes += string.Format("HTMLLoaded: {0}\n", STE!.HTMLLoaded);

            if ( STE.OldDividingLine != null)
                changes += string.Format("oldDividingLine:\n{0}@vv@\n", STE.OldDividingLine);
            if (STE.OldMoreLine != null)
                changes += string.Format("oldMoreLine:\n{0}@vv@\n", STE.OldMoreLine);
            if (STE.BufferedInput != null)
                changes += string.Format("BufferedInput:\n{0}@vv@\n", STE.BufferedInput);


            changes += string.Format("STELines: {0} \n", STE.Slines.Count);

            for( int ix = 0; ix < STE.Slines!.Count!; ix++)
            {
                changes += string.Format("{0}\n", STE.Slines[ix].Length);

                changes += string.Format("{0}\n", STE.Slines[ix] );
            }

            // changes += sb;


            output += changes;
            */
            // SLinesBuffer

        }
        public void SaveFBE(ref string output)
        {
            // bool changedIx = false;
            string changes = "";

            Phoney_MAUI.Core.FeedbackText FBE= AdvGame!.FBE;
            Phoney_MAUI.Core.FeedbackText FBE2 = AdvGame!.GD!.StartStatus!.jsonFeedbackText!;

            changes += "FBE:\n";

            if (FBE != null)
            {
                changes += string.Format("FeedbackOffMC: {0}\n", FBE.FeedbackOffMC!);
                changes += string.Format("FeedbackSizeMC: {0}\n", Phoney_MAUI.Core.FeedbackText.FeedbackSizeMC!);
                changes += string.Format("FeedbackCountMC: {0}\n", FBE.FeedbackCountMC!);
                changes += string.Format("FeedbackModeMC: {0}\n", FBE.FeedbackModeMC)!;
            }

            if (FBE2 != null)
            {
                if (FBE2.FeedbackWindowText != null)
                {
                    for (int ix = 0; ix < FBE2.FeedbackWindowText.Count; ix++)
                    {
                        changes += string.Format("FeedbackWindowText: {0} {1}\n", ix, FBE!.FeedbackWindowText![ix]!);

                    }
                }
                if (FBE2.FeedbackWindowTextMC != null)
                {
                    for (int ix = 0; ix < FBE2.FeedbackWindowTextMC.Count; ix++)
                    {
                        changes += string.Format("FeedbackWindowTextMC: {0} {1}\n", ix, FBE!.FeedbackWindowTextMC![ix]!);

                    }
                }
            }

            output += changes;

        }

        public void SaveA(ref string output)
        {
            // bool changedIx = false;
            string changes = "";

            //  FeedbackText FBE = AdvGame!.FBE;
            AdvData A2 = AdvGame!.GD!.StartStatus!.jsonA!;

            changes += "A:\n";

            changes += string.Format("ActLoc: {0}\n", A!.ActLoc! );
            changes += string.Format("ActPerson: {0}\n", A!.ActPerson!);
            changes += string.Format("ActScore: {0}\n", A!.ActScore!);
            changes += string.Format("MaxScore: {0}\n", A!.MaxScore!);
            changes += string.Format("StartLoc: {0}\n", A!.StartLoc!);
            changes += string.Format("Finish: {0}\n", A!.Finish!);
            changes += string.Format("Tense: {0}\n", A!.Tense!);
            changes += string.Format("difficulty: {0}\n", A!.Difficulty!);

            output += changes;

        }

        public void SaveVersion( ref string output )
        {
            // bool changedIx = false;
            string changes = "";

            //  FeedbackText FBE = AdvGame!.FBE;
            Phoney_MAUI.Core.Version v = AdvGame!.GD!.Version;

            changes += "Version:\n";

            changes += string.Format("{0} {1} {2} {3} {4} {5}\n", v.Version1, v.Version2, v.Version3, v.VersionDate.Day, v.VersionDate.Month, v.VersionDate.Year);

            output += changes;


        }

        public void SavePV(ref string output)
        {
            int ix = 0;

            if (AdvGame!.PV == null)
                return;
            if (AdvGame.PV.PVList == null)
                return;


            foreach (var pv0 in AdvGame!.PV!.PVList! )
            {

                int ix2 = 0;
                foreach ( var pvLoc0 in pv0.PVLoc )
                {
                    bool changedIx = false;
                    string changes = "";

                    PVLoc pvl = pvLoc0;
                    PVLoc pvl2 = AdvGame!.GD!.StartStatus!.jsonPV!.PVList![ix]!.PVLoc![ix2]!;

                    if (pvl.locationID != pvl2.locationID)
                    {
                        changes += string.Format("locationID: {0] {1} {2}\n", ix, ix2, pvl.locationID.ToString());
                        changedIx = true;

                    }
                    if (pvl.PVSubLevel != pvl2.PVSubLevel)
                    {
                        changes += string.Format("PVSubLevel: {0] {1} {2}\n", ix, ix2, pvl.PVSubLevel.ToString());
                        changedIx = true;

                    }
                    if (pvl.replacement!= pvl2.replacement)
                    {
                        changes += string.Format("replacement: {0} {1} {2}\n", ix, ix2, pvl.replacement.ToString());
                        changedIx = true;

                    }

                    if (changedIx)
                    {
                        output += string.Format("PV:\n");
                        output += changes;
                    }

                    ix2++;

                }
 

                ix++;
            }
        }

        public void SaveSlines(ref string output)
        {
            string changes = "";

            output += string.Format("SLines: {0}\n", AdvGame!.UIS!.StoryTextObj!.Slines!.Count);

            for( int ix = 0; ix < AdvGame.UIS.StoryTextObj.Slines.Count; ix++)
            {
                changes = string.Format("{0}\n", AdvGame!.UIS.StoryTextObj.Slines[ix]!.Length);
                changes += AdvGame.UIS.StoryTextObj.Slines[ix];
                changes += "\n";
                output += changes;
            }

        }

        public GameDefinitions GenerateGameDefinitions( bool forceSave )
        {
            GameDefinitions gdi = new();

            if (forceSave)
            {
                if (AdvGame!.UIS!.MCMVVisible)
                {
                    if (AdvGame!.Orders!.persistentMCMenu != null)
                    {
                        gdi.MCVisible = IGameDefinitions.mcvMode.persistent;
                        if (AdvGame.LastSpeaker != null)
                            gdi.MCVLastSpeaker = AdvGame.LastSpeaker.ID;
                        else
                            gdi.MCVLastSpeaker = 0;

                        gdi.MCMenuTemp = null;
                    }
                    else if (AdvGame!.Orders!.temporaryMCMenu != null)
                    {
                        gdi.MCVisible = IGameDefinitions.mcvMode.temporary;
                        gdi.MCMenuTemp = AdvGame!.Orders!.temporaryMCMenu;
                    }
                    else
                    {
                        gdi.MCVisible = IGameDefinitions.mcvMode.none;
                        gdi.MCMenuTemp = null;
                    }
                }
                else
                {
                    gdi.MCVisible = IGameDefinitions.mcvMode.none;
                    gdi.MCMenuTemp = null;

                }

            }
            else
            {
                gdi.MCVisible = IGameDefinitions.mcvMode.none;

                gdi.MCMenuTemp = null;
            }

            if (gdi.MCVisible == IGameDefinitions.mcvMode.temporary)
            {
                gdi.MCCallbackName = AdvGame!.Orders!.MCCallbackName;
            }
            else
            {
                gdi.MCVFuncName = MCMenuFunc;
            }

            // gdi.MCCallbackName = MCCallbackName;
            gdi.MCID = MCID;
            gdi.MCPersonID = MCPersonID;

            gdi.PicMode = AdvGame!.GD!.PicMode;

            gdi.CurrentEventName = AdvGame._currentEventName;
            gdi.IxCurrent = AdvGame._ixCurrent;
            gdi.ActLocEvent = AdvGame._actLocEvent;
            gdi.ActLocEventSeqStart = AdvGame._actLocEventSeqStart;
            gdi.ActLocEventStartPoint = AdvGame._actLocEventStartPoint;
            gdi.LastLocEventStartPoint = AdvGame._lastLocEventStartPoint;
            gdi.ActLocCollecting = AdvGame._actLocCollecting;
            gdi.LastLoc = AdvGame._lastLoc;
            gdi.ActLoc = AdvGame._actLoc;


            return gdi;
        }
        public void SaveGameDefinitions(ref string output, bool forceSave)
        {
            GameDefinitions gdi = GenerateGameDefinitions(forceSave);

            string zw = JsonConvert.SerializeObject(gdi);

            output += string.Format("GameDefinitions: {0}\n", zw.Length );
            output += zw;
            output += "\n";
        }

        public void SaveOrderTable(ref string output)
        {
            int ix = 0;

            output += string.Format("OrderTable:\n");

            if( GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx].Zipped == true )
            {
                GD.OrderList.ReadZipOrderTable(AdvGame!.GD!.OrderList!.CurrentOrderListIx, GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx].Name!);
            }


            StringBuilder sb = new(64000);
            foreach (var ot0 in AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx].OT! )
            {
                OrderTable ot = ot0;
                OrderTable ot2 = ot;//  AdvGame!.MW.GD!.StartStatus.jsonOrderListTable.OT![ix];

                string path = "";
                if (ot2.OrderPath != null)
                    path = ot2.OrderPath;
                else
                {

                }

                if(ot2.OrderType == orderType.mcChoice)
                {
                    sb.Append( string.Format("{0} {3} {4} {5} {2} '{1}'\n", ot2.OrderActive, ot2.OrderText, ot2.OrderChoice, ot2.OrderType, path.Length, ot2.OrderResult!.Length) );

                    sb.Append(path + "\n");
                    sb.Append(ot2.OrderResult + "\n");
                }
                else
                {
                    sb.Append( string.Format("{0} {3} {4} {5} '{1}'\n", ot2.OrderActive, ot2.OrderText, ot2.OrderChoice, ot2.OrderType, path.Length, ot2.OrderResult!.Length) );

                    sb.Append(path + "\n");
                    sb.Append(ot2.OrderResult + "\n");
                }

                ix++;
            }
            output += string.Format("OrderTable: {0} {1}\n", AdvGame!.GD!.OrderList!.CurrentOrderListIx, AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx]!.OT!.Count );


            output += sb.ToString();
        }

        public void SaveGame( string fileName, bool forceSave = false )
        {
            string output = "";
            // int ix = 0;

            SaveItems(ref output);
            SavePersons(ref output);
            SaveLocations(ref output);
            SaveStats(ref output);
            SaveScores(ref output);
            SaveLanguages(ref output);
            SaveLI(ref output);
            SaveItemQueue(ref output);
            SaveSTE(ref output);
            SaveFBE(ref output);
            SaveA(ref output);
            SavePV(ref output);
            SaveVersion(ref output);
            SaveOrderTable(ref output);
            // SaveSlines(ref output);
            SaveGameDefinitions(ref output, forceSave );

            AdvGame!.UIS!.CoreSaveToFile(output, fileName);
            /*
            string pathName = GlobalData.CurrentPath();
            // Ignores: 002
            string pathfileName = pathName + "\\" + "newsave.txt";
            File.WriteAllText(pathfileName, output);
            */
        }


        public void RestoreReflection( SaveObj so ) 
        {
            CoAdv CA = so!.jsonCA!;

            System.Reflection.PropertyInfo[] pi = CA!.GetType().GetProperties();

          
            foreach( PropertyInfo pix in pi )
            {
                try
                {

                    // Hier passiert nix, das hat alles so seine Richtigkeit
                    if (pix.PropertyType.Name == "Int32")
                    {
                    }
                    else if (pix.PropertyType.Name == "Item")
                    {
                        Item item = (pix.GetValue(CA) as Item)!;
                        if (item != null)
                        {
                            if( item.ID == 3788)
                            {

                            }
                            Item item2 = so!.jsonItems!.List![item!.ID!]!;
                            pix.SetValue(CA, item2);
                        }
                    }
                    else if (pix.PropertyType.Name == "Person")
                    {
                        Person person = (pix.GetValue(CA) as Person)!;
                        if (person != null)
                        {
                            Person? person2 = so!.jsonPersons!.List![person!.ID!]!;
                            pix.SetValue(CA, person2);
                        }
                    }
                    else if (pix.PropertyType.Name == "Topic")
                    {
                        Topic topic = (pix.GetValue(CA) as Topic)!;
                        if (topic != null)
                        {
                            Topic topic2 = so!.jsonTopics!.List[topic!.ID];
                            pix.SetValue(CA, topic2);
                        }
                    }
                    else
                    {
                        // int a = 5;
                    }
                }
                catch (Exception e)
                {

                }
            }
            System.Reflection.FieldInfo[] fi = CA.GetType().GetFields();

            foreach ( FieldInfo fix in fi)
            {
                try
                {

                    if (fix.FieldType.Name == "Int32")
                    {
                    }
                    else if (fix.FieldType.Name == "Item")
                    {
                        Item item = (fix.GetValue(CA) as Item)!;
                        if (item != null)
                        {

                            Item item2 = so!.jsonItems!.List![item!.ID!]!;
                            fix.SetValue(CA, item2);
                        }
                    }
                    else if (fix.FieldType.Name == "Person")
                    {
                        Person person = (fix.GetValue(CA) as Person)!;
                        if (person != null)
                        {
                            Person person2 = so!.jsonPersons!.List![person!.ID!]!;
                            fix.SetValue(CA, person2);
                        }
                    }
                    else if (fix.FieldType.Name == "Topic")
                    {
                        Topic topic = (fix.GetValue(CA) as Topic)!;
                        if (topic != null)
                        {
                            Topic topic2 = so!.jsonTopics!.Find(topic!.ID)!;
                            fix.SetValue(CA, topic2);
                        }
                    }
                    else if (fix.FieldType.Name == "Verb")
                    {
                        Verb verb = (fix.GetValue(CA) as Verb)!;
                        if (verb != null)
                        {
                            Verb verb2 = so!.jsonVerbs!.Find(verb!.ID!)!;
                            fix.SetValue(CA, verb2);
                        }
                    }
                    else if (fix.FieldType.Name == "Noun")
                    {
                        Noun noun = (fix.GetValue(CA) as Noun)!;
                        if (noun != null)
                        {
                            Noun noun2 = so!.jsonNouns!.Find(noun!.ID!)!;
                            fix.SetValue(CA, noun2);
                        }
                    }
                    else if (fix.FieldType.Name == "Adj")
                    {
                        Adj adj = (fix.GetValue(CA) as Adj)!;
                        if (adj != null)
                        {
                            Adj adj2 = so!.jsonAdjs!.Find(adj!.ID)!;
                            fix.SetValue(CA, adj2);
                        }
                    }
                    else if (fix.FieldType.Name == "Fill")
                    {
                        Fill fill = (fix.GetValue(CA) as Fill)!;
                        if (fill != null)
                        {
                            Fill fill2 = so!.jsonFills!.Find(fill!.ID!)!;
                            fix.SetValue(CA, fill2);
                        }
                    }
                    else if (fix.FieldType.Name == "Prep")
                    {
                        Prep prep = (fix.GetValue(CA) as Prep)!;
                        if (prep != null)
                        {
                            Prep prep2 = so!.jsonPreps!.Find(prep!.ID!);
                            fix.SetValue(CA, prep2);
                        }
                    }
                    else if (fix.FieldType.Name == "Pronoun")
                    {
                        Pronoun pronoun = (fix.GetValue(CA) as Pronoun)!;
                        if (pronoun != null)
                        {
                            Pronoun pronoun2 = so!.jsonPronouns!.Find(pronoun!.ID!);
                            fix.SetValue(CA, pronoun2);
                        }
                    }
                    else if (fix.FieldType.Name == "Status")
                    {
                        Status status = (fix.GetValue(CA) as Status)!;
                        if (status != null)
                        {
                            Status status2 = so!.jsonStats!.Find(status!.ID!)!;
                            fix.SetValue(CA, status2);
                        }
                    }
                    else if (fix.FieldType.Name == "Score")
                    {
                        Score score = (fix.GetValue(CA) as Score)!;
                        if (score != null)
                        {
                            Score score2 = so!.jsonScores!.Find(score!.ID!)!;
                            fix.SetValue(CA, score2);
                        }
                    }
                    else
                    {
                        // int a = 5;
                    }

                }
                catch (Exception e)
                {

                }
            }
            CoBase CB = so.jsonCB!;

            pi = CB.GetType().GetProperties();


            foreach (PropertyInfo pix in pi)
            {
                // Hier passiert nix, das hat alles so seine Richtigkeit
                if (pix.PropertyType.Name == "Int32")
                {
                }
                else if (pix.PropertyType.Name == "Item")
                {
                    Item item = (pix.GetValue(CB) as Item)!;
                    if (item != null)
                    {

                        Item item2 = so!.jsonItems!.List![item!.ID!]!;
                        pix.SetValue(CB, item2);
                    }
                }
                else if (pix.PropertyType.Name == "Person")
                {
                    Person person = (pix.GetValue(CB) as Person)!;
                    if (person != null)
                    {
                        Person person2 = so!.jsonPersons!.List![person!.ID!]!;
                        pix.SetValue(CB, person2);
                    }
                }
                else if (pix.PropertyType.Name == "Topic")
                {
                    Topic topic = (pix.GetValue(CB) as Topic)!;
                    if (topic != null)
                    {
                        Topic topic2 = so!.jsonTopics!.List[topic!.ID];
                        pix.SetValue(CB, topic2);
                    }
                }
                else
                {
                    // int a = 5;
                }
            }
            fi = CB.GetType().GetFields();

            foreach (FieldInfo fix in fi)
            {
                if (fix.FieldType.Name == "Int32")
                {
                }
                else if (fix.FieldType.Name == "Item")
                {
                    Item item = (fix.GetValue(CB) as Item)!;
                    if (item != null)
                    {

                        Item item2 = so!.jsonItems!.List![item!.ID!]!;
                        fix.SetValue(CB, item2);
                    }
                }
                else if (fix.FieldType.Name == "Person")
                {
                    Person person = (fix.GetValue(CB) as Person)!;
                    if (person != null)
                    {
                        Person person2 = so!.jsonPersons!.List![person!.ID!]!;
                        fix.SetValue(CB, person2);
                    }
                }
                else if (fix.FieldType.Name == "Topic")
                {
                    Topic topic = (fix.GetValue(CB) as Topic)!;
                    if (topic != null)
                    {
                        Topic topic2 = so!.jsonTopics!.Find(topic!.ID!)!;
                        fix.SetValue(CB, topic2);
                    }
                }
                else if (fix.FieldType.Name == "Verb")
                {
                    Verb verb = (fix.GetValue(CB) as Verb)!;
                    if (verb != null)
                    {
                        Verb verb2 = so!.jsonVerbs!.Find(verb!.ID!)!;
                        fix.SetValue(CB, verb2);
                    }
                }
                else if (fix.FieldType.Name == "Noun")
                {
                    Noun noun = (fix.GetValue(CB) as Noun)!;
                    if (noun != null)
                    {
                        Noun noun2 = so!.jsonNouns!.Find(noun!.ID)!;
                        fix.SetValue(CB, noun2);
                    }
                }
                else if (fix.FieldType.Name == "Adj")
                {
                    Adj adj = (fix.GetValue(CB) as Adj)!;
                    if (adj != null)
                    {
                        Adj adj2 = so!.jsonAdjs!.Find(adj!.ID)!;
                        fix.SetValue(CB, adj2);
                    }
                }
                else if (fix.FieldType.Name == "Fill")
                {
                    Fill fill = (fix.GetValue(CB) as Fill)!;
                    if (fill != null)
                    {
                        Fill fill2 = so!.jsonFills!.Find(fill!.ID)!;
                        fix.SetValue(CB, fill2);
                    }
                }
                else if (fix.FieldType.Name == "Prep")
                {
                    Prep prep = (fix.GetValue(CB) as Prep)!;
                    if (prep != null)
                    {
                        Prep prep2 = so!.jsonPreps!.Find(prep!.ID)!;
                        fix.SetValue(CB, prep2);
                    }
                }
                else if (fix.FieldType.Name == "Pronoun")
                {
                    Pronoun pronoun = (fix.GetValue(CB) as Pronoun)!;
                    if (pronoun != null)
                    {
                        Pronoun pronoun2 = so!.jsonPronouns!.Find(pronoun!.ID!)!;
                        fix.SetValue(CB, pronoun2);
                    }
                }
                else if (fix.FieldType.Name == "Status")
                {
                    Status status = (fix.GetValue(CB) as Status)!;
                    if (status != null)
                    {
                        Status status2 = so!.jsonStats!.Find(status!.ID!)!;
                        fix.SetValue(CB, status2);
                    }
                }
                else if (fix.FieldType.Name == "Score")
                {
                    Score score = (fix.GetValue(CB) as Score)!;
                    if (score != null)
                    {
                        Score score2 = so!.jsonScores!.Find(score!.ID!)!;
                        fix.SetValue(CB, score2);
                    }
                }
                else
                {
                    // int a = 5;
                }

            }
        }
        public SaveObj LoadGame( string fileName, ref IGlobalData.language lang)
        {
            string? input = AdvGame!.UIS!.CoreLoadStringFromFile( fileName );

            Adv advTemp = new Adv(false, false, true);
            GD!.AskForPlayLevel = false;
            // SaveObj so_source = AdvGame!.GD!.StartStatus!;
            SaveObj so = new();


            so.jsonItems = advTemp.Items;
            so.jsonPersons = advTemp.Persons;
            so.jsonlocations = advTemp.locations;
            so.jsonStats = advTemp.Stats;
            so.jsonScores = advTemp.Scores;
            so.jsonLanguage = advTemp.GD!.Language;
            so.jsonLI = advTemp.LI;
            so.jsonItemQueue = advTemp.ItemQueue;
            so.jsonStoryText = advTemp.UIS!.StoryTextObj;
            so.jsonFeedbackText = advTemp.UIS.FeedbackTextObj;
            so.jsonA = advTemp.A;
            so.jsonPV = advTemp.PV;


            if(advTemp!.GD!.OrderList!.OTL![advTemp!.GD!.OrderList!.CurrentOrderListIx].Zipped == true )
            {
                GD.OrderList!.ReadZipOrderTable(advTemp.GD!.OrderList!.CurrentOrderListIx, GD!.OrderList!.OTL![advTemp!.GD!.OrderList!.CurrentOrderListIx].Name!);
            }
            so.jsonOrderListTable = advTemp!.GD!.OrderList!.OTL![advTemp!.GD!.OrderList!.CurrentOrderListIx];

            so.jsonAdjs = advTemp.Adjs;
            so.jsonNouns = advTemp.Nouns;
            so.jsonVerbs = advTemp.Verbs;
            so.jsonPreps = advTemp.Preps;
            so.jsonPronouns = advTemp.Pronouns;
            so.jsonFills = advTemp.Fills;
            so.jsonTopics = advTemp.Topics;
            so.jsonCA = advTemp.CA;
            so.jsonCB = advTemp.CB;
            so.jsonVerbTenses = advTemp.VerbTenses;
            so.jsonParser = advTemp.Parser;
            so.jsonVersion = advTemp.GD.Version;
            so.JsonGameDefinitions = advTemp.Orders!.GenerateGameDefinitions(false);
            /*
            so.jsonItems = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<ItemList>(so_source!.jsonItems!)!;
            so.jsonPersons = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<PersonList>(so_source!.jsonPersons!)!;
            so.jsonlocations= Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<locationList>(so_source!.jsonlocations!)!;
            so.jsonStats = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<StatusList>(so_source!.jsonStats!)!;
            so.jsonScores = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<ScoreList>(so_source!.jsonScores!)!;
            so.jsonLanguage = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<IGlobalData.language>(so_source!.jsonLanguage!)!;
            so.jsonLI= Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<List<LatestInput>>(so_source!.jsonLI!)!;
            so.jsonItemQueue = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<ItemQueue>(so_source!.jsonItemQueue!)!;
            so.jsonStoryText = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<Phoney_MAUI.Core.StoryText>(so_source!.jsonStoryText!)!;
            so.jsonFeedbackText = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<Phoney_MAUI.Core.FeedbackText>(so_source!.jsonFeedbackText!)!;
            so.jsonA = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<AdvData>(so_source!.jsonA!)!;
            so.jsonPV = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<PhoneyVision>(so_source!.jsonPV!)!;
            so.jsonOrderListTable = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<OrderListTable>(so_source!.jsonOrderListTable!)!;

            // Ab hier unveränderliche Objekte, die aber natürlich trotzdem aus dem Zerogame gezogen werden müssen
            so!.jsonAdjs = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<AdjList>(so_source!.jsonAdjs!)!;
            so!.jsonNouns = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<NounList>(so_source!.jsonNouns!)!;
            so!.jsonVerbs = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<VerbList>(so_source!.jsonVerbs!)!;
            so!.jsonPreps = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<PrepList>(so_source!.jsonPreps!)!;
            so!.jsonPronouns = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<PronounList>(so_source!.jsonPronouns!)!;
            so!.jsonFills = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<FillList>(so_source!.jsonFills!)!;
            so!.jsonTopics = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<TopicList>(so_source!.jsonTopics!)!;
            so!.jsonCA = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<CoAdv>(so_source!.jsonCA!)!;
            so!.jsonCB = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<CoBase>(so_source!.jsonCB!)!;
            so!.jsonVerbTenses = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<VTList>(so_source!.jsonVerbTenses!)!;
            so!.jsonParser = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<Parse>(so_source!.jsonParser!)!;
            so!.jsonVersion = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<Phoney_MAUI.Core.Version>(so_source!.jsonVersion !)!;
            // so!.jsonSlines = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<List<string>>(so_source!.jsonSlines!)!;
            so!.JsonGameDefinitions = Phoney_MAUI.Core.UIServices.ObjectCopier.Clone<GameDefinitions>(so_source!.JsonGameDefinitions!)!;
            */

            // so!.jsonStoryText.Slines = so.jsonSlines;

            ParseInput(so, input!, ref lang);

            RestoreReflection(so);
            return so;
            // SaveOrderTable(ref output);
        }

        public string ExtractLine( string s1, ref int off )
        {
           
            string newString = "";
            int ctLF = 0;

            int oldOff = off;
            while (s1[off] != 13 && s1[off] != 10 )
            {
                if (s1[off] == 13 || s1[off] == 10)
                    ctLF++;
                if (ctLF >= 2)
                    break;
                off++;

 
                if (off >= s1.Length)
                    break;
            }
            newString = s1.Substring(oldOff, off - oldOff);
            if (off < s1.Length)
            {

                ctLF = 0; 
                while ( s1[off] == 13 || s1[off] == 10 )
                {
                    if (s1[off] == 13 || s1[off] == 10)
                        ctLF++;
                    if (ctLF >= 2)
                        break;

                    off++;
                    if (off >= s1.Length)
                        break;
                }
            }

            return newString;
        }
        public string ExtractTextBlock(string s1, ref int off)
        {
            bool doBreak = false;
            string newString = "";

            int oldOff = off;
            while (off < s1.Length && doBreak == false)
            {
                off++;

                if (s1[off] == '@')
                {
                    if (s1[off + 1] == 'v' && s1[off + 2] == 'v' && s1[off + 3] == '@')
                    {
                        doBreak = true;
                    }
                }

                if (off >= s1.Length)
                    break;
            }
            newString = s1.Substring(oldOff, off - oldOff);
            off += 4;
            if (off < s1.Length)
            {

                while (s1[off] == 13 || s1[off] == 10)
                {
                    off++;
                    if (off >= s1.Length)
                        break;
                }
            }

            return newString;
        }
        public string S1ExtractInput(string s1)
        {
            bool doBreak = false;
            string newString = "";
            int off = 0;
            int startOff = -1;

            while (off < s1.Length && doBreak == false)
            {
 
                if (s1[off] == '\'')
                {
                    doBreak = true;
                    break;
                }

                off++;
                if (off >= s1.Length)
                    break;
            }

            if( doBreak )
            {
                startOff = off + 1;
                off++;
                doBreak = false;

                while (off < s1.Length && doBreak == false)
                {

                    if (s1[off] == '\'')
                    {
                        doBreak = true;
                    }

                    off++;
                    if (off >= s1.Length)
                        break;
                }
            }

            
            if( startOff > 0 )
                newString = s1.Substring(startOff, off - startOff);

            return newString;
        }
        enum sgTypes { unclear, item, person, location, stats, score, languages, ki, itemqueue, ste, fbe, a, pv, ordertable, version }

 
        public void ParseInput( SaveObj soDest, string input, ref IGlobalData.language lang)
        {
            sgTypes SGType = sgTypes.unclear;
            bool proceed = true;
            int off = 0;

            string s1; 
            int currentItem = -1;

            try
            {

                while (proceed)
                {
                    bool handled = false;

                    s1 = ExtractLine(input, ref off);

                    string[] s2 = s1.Split(' ');

                    if (SGType == sgTypes.item)
                    {

                        if (s2[0] == "locationType:")
                        {
                            soDest!.jsonItems!.List![currentItem]!.locationType = Int32.Parse(s2[1])!;
                            handled = true;
                        }
                        else if (s2[0] == "locationID:")
                        {
                            soDest!.jsonItems!.List![currentItem]!.locationID = Int32.Parse(s2[1])!;
                            handled = true;
                        }
                        else if (s2[0] == "StorageIn:")
                        {
                            soDest!.jsonItems!.List![currentItem]!.StorageIn = Int32.Parse(s2[1])!;
                            handled = true;
                        }
                        else if (s2[0] == "StorageBelow:")
                        {
                            soDest!.jsonItems!.List![currentItem]!.StorageBelow = Int32.Parse(s2[1])!;
                            handled = true;
                        }
                        else if (s2[0] == "StorageBehind:")
                        {
                            soDest!.jsonItems!.List![currentItem]!.StorageBelow = Int32.Parse(s2[1])!;
                            handled = true;
                        }
                        else if (s2[0] == "StorageOn:")
                        {
                            soDest!.jsonItems!.List![currentItem]!.StorageOn = Int32.Parse(s2[1])!;
                            handled = true;
                        }
                        else if (s2[0] == "LocaDescription:")
                        {
                            soDest!.jsonItems!.List![currentItem]!.LocaDescription = s2[1]!;
                            handled = true;
                        }
                        else if (s2[0] == "Categories:")
                        {
                            int ct = Int32.Parse(s2[1]);

                            soDest!.jsonItems!.List![currentItem].Categories = new();

                            for (int ix = 0; ix < ct; ix++)
                            {
                                s1 = ExtractLine(input, ref off);
                                s2 = s1.Split(' ');

                                int CategoryID = Int32.Parse(s2[0]);
                                int CounterCategoryID = Int32.Parse(s2[1]);
                                relTypes Relevance = relTypes.r_essential;
                                if (s2.Length >= 3)
                                {
                                    if (s2[2] == "r_high")
                                        Relevance = relTypes.r_high;
                                    else if (s2[2] == "r_med")
                                        Relevance = relTypes.r_med;
                                    else if (s2[2] == "r_low")
                                        Relevance = relTypes.r_low;
                                }
                                CategoryRel cr = AdvGame!.Categories!.Find(CategoryID)!;  
                                soDest!.jsonItems!.List![currentItem].Categories!.Add(cr, Relevance);
                            }
                            /*
                            foreach( CategoryRel cr in soDest!.jsonItems!.List![currentItem].Categories!.List!.Values)
                            {
                                s1 = ExtractLine(input, ref off);
                                s2 = s1.Split(' ');

                                cr.CategoryID = Int32.Parse(s2[0]);
                                cr.CounterCategoryID = Int32.Parse(s2[1]);
                                cr.Relevance = relTypes.r_essential;
                                if (s2[2] !=  null )
                                    cr.Relevance = Int32.Parse(s2[2]);

                            }
                            */
                            handled = true;

                            // changes += string.Format("{0} {1}\n", it.Categories!.List[ix2].CategoryID, it.Categories!.List[ix2].CounterCategoryID);

                        }
                        else if (s2[0] == "Names:")
                        {
                            int ct = Int32.Parse(s2[1]);
                            soDest!.jsonItems!.List![currentItem].Names!.Clear();
                            for (int ix = 0; ix < ct; ix++)
                            {
                                s1 = ExtractLine(input, ref off);
                                s2 = s1.Split(' ');

                                soDest!.jsonItems!.List![currentItem]!.Names!.Add(soDest!.jsonNouns!.TList![s2[0]!]!);
                            }
                            handled = true;

                            // changes += string.Format("{0} {1}\n", it.Categories!.List[ix2].CategoryID, it.Categories!.List[ix2].CounterCategoryID);

                        }
                        else if (s2[0] == "Adjectives:")
                        {
                            int ct = Int32.Parse(s2[1]);
                            soDest!.jsonItems!.List![currentItem]!.Adjectives!.Clear();
                            for (int ix = 0; ix < ct; ix++)
                            {
                                s1 = ExtractLine(input, ref off);
                                s2 = s1.Split(' ');

                                soDest!.jsonItems!.List[currentItem]!.Adjectives!.Add(soDest!.jsonAdjs!.Find(Int32.Parse(s2[0]))!);
                            }
                            handled = true;

                            // changes += string.Format("{0} {1}\n", it.Categories!.List[ix2].CategoryID, it.Categories!.List[ix2].CounterCategoryID);

                        }
                        else if (s2[0] == "Status:")
                        {
                            int ct = Int32.Parse(s2[1]);
                            for (int ix = 0; ix < ct; ix++)
                            {
                                s1 = ExtractLine(input, ref off);
                                s2 = s1.Split(' ');

                                soDest!.jsonItems!.List![currentItem]!.SL!.List[ix]!.ID = Int32.Parse(s2[0]);
                                soDest!.jsonItems!.List![currentItem]!.SL!.List[ix]!.Val = Int32.Parse(s2[1]);
                            }
                            handled = true;

                            // changes += string.Format("{0} {1}\n", it.Categories!.List[ix2].CategoryID, it.Categories!.List[ix2].CounterCategoryID);

                        }


                        /*
                        changes += string.Format("Status: {0}\n", it.SL.List.Count.ToString());

                        int ix2;

                        for (ix2 = 0; ix2 < it.SL.List.Count; ix2++)
                        {
                            changes += string.Format("{0} {1}\n", it.SL.List[ix2]!.ID, it.SL.List[ix2].Val);
                        }
                        */

                        else if (s2[0] == "Known:")
                        {
                            bool known = false;

                            if (s2[1] == "True") known = true;

                            soDest!.jsonItems!.List![currentItem]!.Known = known;
                            handled = true;
                        }
                        else if (s2[0] == "IsClosed:")
                        {
                            bool isClosed = false;

                            if (s2[1] == "True") isClosed = true;

                            soDest!.jsonItems!.List![currentItem]!.IsClosed = isClosed;
                            handled = true;
                        }
                        else if (s2[0] == "IsLocked:")
                        {
                            bool isLocked = false;

                            if (s2[1] == "True") isLocked = true;

                            soDest!.jsonItems!.List![currentItem]!.IsLocked = isLocked;
                            handled = true;
                        }
                        else if (s2[0] == "IsHidden:")
                        {
                            bool isHidden = false;

                            if (s2[1] == "True") isHidden = true;

                            soDest!.jsonItems!.List![currentItem]!.IsHidden = isHidden;
                            handled = true;
                        }
                        else if (s2[0] == "IsDressed:")
                        {
                            bool isDressed = false;

                            if (s2[1] == "True") isDressed = true;

                            soDest!.jsonItems!.List![currentItem!]!.IsDressed = isDressed;
                            handled = true;
                        }
                        else if (s2[0] == "IsBackground:")
                        {
                            bool isBackground = false;

                            if (s2[1] == "True") isBackground = true;

                            soDest!.jsonItems!.List![currentItem]!.IsBackground = isBackground;
                            handled = true;
                        }
                        else if (s2[0] == "IsMentionable:")
                        {
                            bool isMentionable = false;

                            if (s2[1] == "True") isMentionable = true;

                            soDest!.jsonItems!.List![currentItem]!.IsMentionable = isMentionable;
                            handled = true;
                        }
                        else if (s2[0] == "IsLessImportant:")
                        {
                            bool isLessImportant = false;

                            if (s2[1] == "True") isLessImportant = true;

                            soDest!.jsonItems!.List![currentItem]!.IsLessImportant = isLessImportant;
                            handled = true;
                        }
                        else if (s2[0] == "InvisibleBelow:")
                        {
                            bool invisibleBelow = false;

                            if (s2[1] == "True") invisibleBelow = true;

                            soDest!.jsonItems!.List![currentItem]!.InvisibleBelow = invisibleBelow;
                            handled = true;
                        }
                        else if (s2[0] == "InvisibleBehind:")
                        {
                            bool invisibleBehind = false;

                            if (s2[1] == "True") invisibleBehind = true;

                            soDest!.jsonItems!.List![currentItem]!.InvisibleBehind = invisibleBehind;
                            handled = true;
                        }
                        else if (s2[0] == "InvisibleIn:")
                        {
                            bool invisibleIn = false;

                            if (s2[1] == "True") invisibleIn= true;

                            soDest!.jsonItems!.List![currentItem]!.InvisibleIn = invisibleIn;
                            handled = true;
                        }
                        else if (s2[0] == "CanPutBehind:")
                        {
                            bool canPutBehind = false;

                            if (s2[1] == "True") canPutBehind = true;

                            soDest!.jsonItems!.List![currentItem].CanPutBehind = canPutBehind;
                            handled = true;
                        }
                        else if (s2[0] == "CanPutIn:")
                        {
                            bool canPutIn = false;

                            if (s2[1] == "True") canPutIn = true;

                            soDest!.jsonItems!.List![currentItem].CanPutIn = canPutIn;
                            handled = true;
                        }
                        else if (s2[0] == "CanPutOn:")
                        {
                            bool canPutOn = false;

                            if (s2[1] == "True") canPutOn = true;

                            soDest!.jsonItems!.List![currentItem].CanPutOn = canPutOn;
                            handled = true;
                        }
                    }
                    else if (SGType == sgTypes.person)
                    {

                        if (s2[0] == "locationType:")
                        {
                            soDest!.jsonPersons!.List![currentItem].locationType = Int32.Parse(s2[1])!;
                            handled = true;
                        }
                        else if (s2[0] == "locationID:")
                        {
                            soDest!.jsonPersons!.List![currentItem]!.locationID = Int32.Parse(s2[1])!;
                            handled = true;
                        }
                        /*
                        else if (s2[0] == "StorageIn:")
                        {
                            soDest!.jsonPersons.List[currentItem].StorageIn = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        else if (s2[0] == "StorageBelow:")
                        {
                            soDest!.jsonPersons.List[currentItem].StorageBelow = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        else if (s2[0] == "StorageBehind:")
                        {
                            soDest!.jsonPersons.List[currentItem].StorageBelow = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        else if (s2[0] == "StorageOn:")
                        {
                            soDest!.jsonPersons.List[currentItem].StorageOn = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        */
                        else if (s2[0] == "LocaDescription:")
                        {
                            soDest!.jsonPersons!.List![currentItem].LocaDescription = s2[1];
                            handled = true;
                        }
                        else if (s2[0] == "Categories:")
                        {
                            int ct = Int32.Parse(s2[1]);

                            soDest!.jsonPersons!.List![currentItem].Categories = new();

                            for (int ix = 0; ix < ct; ix++)
                            {
                                s1 = ExtractLine(input, ref off);
                                s2 = s1.Split(' ');

                                int CategoryID = Int32.Parse(s2[0]);
                                int CounterCategoryID = Int32.Parse(s2[1]);
                                relTypes Relevance = relTypes.r_essential;
                                if (s2.Length >= 3)
                                {
                                    if (s2[2] == "r_high")
                                        Relevance = relTypes.r_high;
                                    else if (s2[2] == "r_med")
                                        Relevance = relTypes.r_med;
                                    else if (s2[2] == "r_low")
                                        Relevance = relTypes.r_low;
                                }

                                CategoryRel cr = AdvGame!.Categories!.Find(CategoryID)!;
                                soDest!.jsonPersons!.List![currentItem].Categories!.Add(cr, Relevance);
                            }
                            /*
                            int ct = Int32.Parse(s2[1]);

                            foreach (CategoryRel cr in soDest!.jsonPersons!.List![currentItem].Categories!.List!.Values)
                            {
                                s1 = ExtractLine(input, ref off);
                                s2 = s1.Split(' ');

                                cr.CategoryID = Int32.Parse(s2[0]);
                                cr.CounterCategoryID = Int32.Parse(s2[1]);
                            }
                            */
                            /*
                            for (int ix = 0; ix < ct; ix++)
                            {
                                s1 = ExtractLine(input, ref off);
                                s2 = s1.Split(' ');

                                soDest!.jsonPersons!.List![currentItem].Categories!.List![ix].CategoryID = Int32.Parse(s2[0]);
                                soDest!.jsonPersons!.List![currentItem].Categories!.List![ix].CounterCategoryID = Int32.Parse(s2[1]);
                            }
                            */
                            handled = true;

                            // changes += string.Format("{0} {1}\n", it.Categories!.List[ix2].CategoryID, it.Categories!.List[ix2].CounterCategoryID);

                        }
                        else if (s2[0] == "Names:")
                        {
                            int ct = Int32.Parse(s2[1]);
                            soDest!.jsonPersons!.List![currentItem]!.Names!.Clear();
                            for (int ix = 0; ix < ct; ix++)
                            {
                                s1 = ExtractLine(input, ref off);
                                s2 = s1.Split(' ');

                                soDest!.jsonPersons!.List![currentItem].Names!.Add(soDest!.jsonNouns!.Find(Int32.Parse(s2[0]))!);
                            }
                            handled = true;

                            // changes += string.Format("{0} {1}\n", it.Categories!.List[ix2].CategoryID, it.Categories!.List[ix2].CounterCategoryID);

                        }
                        else if (s2[0] == "Adjectives:")
                        {
                            int ct = Int32.Parse(s2[1]);
                            soDest!.jsonPersons!.List![currentItem]!.Adjectives!.Clear();
                            for (int ix = 0; ix < ct; ix++)
                            {
                                s1 = ExtractLine(input, ref off);
                                s2 = s1.Split(' ');

                                soDest!.jsonPersons!.List![currentItem]!.Adjectives!.Add(soDest!.jsonAdjs!.Find(Int32.Parse(s2[0]))!);
                            }
                            handled = true;

                            // changes += string.Format("{0} {1}\n", it.Categories!.List[ix2].CategoryID, it.Categories!.List[ix2].CounterCategoryID);

                        }
                        else if (s2[0] == "Status:")
                        {
                            int ct = Int32.Parse(s2[1]);
                            for (int ix = 0; ix < ct; ix++)
                            {
                                s1 = ExtractLine(input, ref off);
                                s2 = s1.Split(' ');

                                soDest!.jsonPersons!.List![currentItem]!.SL!.List![ix]!.ID = Int32.Parse(s2[0])!;
                                soDest!.jsonPersons!.List![currentItem]!.SL!.List![ix]!.Val = Int32.Parse(s2[1])!;
                            }
                            handled = true;

                            // changes += string.Format("{0} {1}\n", it.Categories!.List[ix2].CategoryID, it.Categories!.List[ix2].CounterCategoryID);

                        }


                        /*
                        changes += string.Format("Status: {0}\n", it.SL.List.Count.ToString());

                        int ix2;

                        for (ix2 = 0; ix2 < it.SL.List.Count; ix2++)
                        {
                            changes += string.Format("{0} {1}\n", it.SL.List[ix2]!.ID, it.SL.List[ix2].Val);
                        }
                        */

                        else if (s2[0] == "Known:")
                        {
                            bool known = false;

                            if (s2[1] == "True") known = true;

                            soDest!.jsonPersons!.List![currentItem].Known = known;
                            handled = true;
                        }
                        else if (s2[0] == "IsClosed:")
                        {
                            bool isClosed = false;

                            if (s2[1] == "True") isClosed = true;

                            soDest!.jsonPersons!.List![currentItem]!.IsClosed = isClosed;
                            handled = true;
                        }
                        else if (s2[0] == "IsLocked:")
                        {
                            bool isLocked = false;

                            if (s2[1] == "True") isLocked = true;

                            soDest!.jsonPersons!.List![currentItem]!.IsLocked = isLocked;
                            handled = true;
                        }
                        else if (s2[0] == "IsHidden:")
                        {
                            bool isHidden = false;

                            if (s2[1] == "True") isHidden = true;

                            soDest!.jsonPersons!.List![currentItem]!.IsHidden = isHidden;
                            handled = true;
                        }
                        /*
                        else if (s2[0] == "IsDressed:")
                        {
                            bool isDressed = false;

                            if (s2[1] == "True") isDressed = true;

                            soDest!.jsonPersons.List[currentItem].IsDressed = isDressed;
                            handled = true;
                        }
                        */
                        else if (s2[0] == "IsBackground:")
                        {
                            bool isBackground = false;

                            if (s2[1] == "True") isBackground = true;

                            soDest!.jsonPersons!.List![currentItem]!.IsBackground = isBackground;
                            handled = true;
                        }
                        else if (s2[0] == "ActivityBlocked:")
                        {
                            bool ActivityBlocked = false;

                            if (s2[1] == "True") ActivityBlocked = true;

                            soDest!.jsonPersons!.List![currentItem]!.ActivityBlocked = ActivityBlocked;
                            handled = true;
                        }
                        else if (s2[0] == "IsWanderer:")
                        {
                            bool isWanderer = false;

                            if (s2[1] == "True") isWanderer = true;

                            soDest!.jsonPersons!.List![currentItem]!.IsWanderer = isWanderer;
                            handled = true;
                        }
                        else if (s2[0] == "DialogList:")
                        {
                            int ct = Int32.Parse(s2[1]);

                            soDest!.jsonPersons!.List![currentItem]!.DialogList = new();

                            for (int ixCt = 0; ixCt < ct; ixCt++)
                            {
                                do
                                {
                                    s1 = ExtractLine(input, ref off);
                                } while (s1 == "");

                                s2 = s1.Split(' ');
                                int length = Int32.Parse(s2[2]);
                                string s3 = input.Substring(off, length);
                                off += length;
                                DialogList dl = new();
                                dl.FuncName = s2[1];
                                dl.LatestDialog = JsonConvert.DeserializeObject<MCMenu>(s3);
                                soDest!.jsonPersons!.List![currentItem]!.DialogList!.Add(dl);
                            }
                            handled = true;

                        }


                        /*                           
                           if (dialogLists)
                           {

                           foreach (DialogList dl in pe.DialogList)
                           {


                           string zw = JsonConvert.SerializeObject(dl.LatestDialog);
                           changes += string.Format("Name: {0} {0}\n", dl.FuncName, zw.Length);
                           changes += zw;
                           }
                           /*
                           changes += string.Format("Status: {0}\n", pe.SL.List.Count.ToString());

                           int ix2;

                           for (ix2 = 0; ix2 < pe.SL.List.Count; ix2++)
                           {
                           changes += string.Format("{0} {1}\n", pe.SL.List[ix2]!.ID, pe.SL.List[ix2].Val);
                           }
                           changedIx = true;
                           * /
                           }

                         */
                        /*
                         else if (s2[0] == "IsMentionable:")
                         {
                             bool isMentionable = false;

                             if (s2[1] == "True") isMentionable = true;

                             soDest!.jsonPersons.List[currentItem].IsMentionable = isMentionable;
                             handled = true;
                         }
                         else if (s2[0] == "IsLessImportant:")
                         {
                             bool isLessImportant = false;

                             if (s2[1] == "True") isLessImportant = true;

                             soDest!.jsonPersons.List[currentItem].IsLessImportant = isLessImportant;
                             handled = true;
                         }
                         */
                        /*
                        else if (s2[0] == "InvisibleBelow:")
                        {
                            bool invisibleBelow = false;

                            if (s2[1] == "True") invisibleBelow = true;

                            soDest!.jsonPersons.List[currentItem].InvisibleBelow = invisibleBelow;
                            handled = true;
                        }
                        else if (s2[0] == "InvisibleBehind:")
                        {
                            bool invisibleBehind = false;

                            if (s2[1] == "True") invisibleBehind = true;

                            soDest!.jsonPersons.List[currentItem].InvisibleBehind = invisibleBehind;
                            handled = true;
                        }
                        else if (s2[0] == "CanPutBehind:")
                        {
                            bool canPutBehind = false;

                            if (s2[1] == "True") canPutBehind = true;

                            soDest!.jsonPersons.List[currentItem].CanPutBehind = canPutBehind;
                            handled = true;
                        }
                         */
                    }

                    /*
                    changes += string.Format("latestHtmlOutput:\n{0}@vv@\n", StoryText.latestHtmlOutput);
                    changes += string.Format("latestHtmlOutputReget:\n{0}@vv@\n", StoryText.latestHtmlOutputReget);
                    changes += string.Format("_currentLinesPerTurn: {0}\n", STE2!.CurrentLinesPerTurn!);
                    changes += string.Format("FullRefresh: {0}\n", STE2!.FullRefresh);
                    changes += string.Format("HMTLLoaded: {0}\n", STE2!.HTMLLoaded);

                    if (STE2.oldDividingLine != null)
                        changes += string.Format("oldDividingLine:\n{0}@vv@\n", STE2.oldDividingLine);
                    if (STE2.oldMoreLine != null)
                        changes += string.Format("oldMoreLine:\n{0}@vv@\n", STE2.oldMoreLine);
                    if (STE2.BufferedInput != null)
                        changes += string.Format("BufferedInput:\n{0}@vv@\n", STE2.BufferedInput);
                    if (STE2.WholeStory != null)
                        changes += string.Format("WholeStory:\n{0}@vv@\n", STE2.WholeStory);
                    if (STE2.LatestStory != null)
                        changes += string.Format("LatestStory:\n{0}@vv@\n", STE2.LatestStory);
                    if (STE2.StoryBuffer != null)
                        changes += string.Format("StoryBuffer:\n{0}@vv@\n", STE2.StoryBuffer);

                   StringBuilder sb = new(64000);
                    for (int ix = 0; ix < STE.Slines!.Count!; ix++)
                    {
                        sb.Append(STE.Slines[ix]);
                        sb.Append("@vv@");
                    }
                    changes += string.Format("STELines: {0} {1}\n", STE.Slines.Count, sb.Length);

                    changes += sb;

                    for (int ix = 0; ix < STE2.SLinesBuffer!.Count!; ix++)
                    {
                        changes += string.Format("LineBuffer {0}:\n{1}@vv@\n", ix, STE2.SLinesBuffer[ix]);

                    }
                    */
                    else if (SGType == sgTypes.ste)
                    {
                        if (s2[0] == "_currentLinesPerTurn:")
                        {
                            int val1 = Int32.Parse(s2[1]);

                            soDest!.jsonStoryText!.CurrentLinesPerTurn = val1;
                            // soDest!.jsonStoryText.latest

                            handled = true;
                        }
                        else if (s2[0] == "FullRefresh:")
                        {
                            bool fullRefresh = false;

                            if (s2[1] == "True") fullRefresh = true;

                            soDest!.jsonStoryText!.FullRefresh = fullRefresh;
                            handled = true;
                        }
                        else if (s2[0] == "HTMLLoaded:")
                        {
                            bool htmlLoaded = false;

                            if (s2[1] == "True") htmlLoaded = true;

                            soDest!.jsonStoryText!.HTMLLoaded = htmlLoaded;
                            handled = true;
                        }
                        else if (s2[0] == "oldDividingLine:")
                        {
                            s1 = ExtractLine(input, ref off);

                            soDest!.jsonStoryText!.OldDividingLine = s1;
                            handled = true;
                        }
                        else if (s2[0] == "STELines:")
                        {
                            int ct = Int32.Parse(s2[1]);
                            // int len = Int32.Parse(s2[2]);

                            soDest!.jsonStoryText!.Slines = new(); // .Clear();
                            /*
                            for (int ix = 0; ix < ct; ix++)
                            {
                                string s3;
                                soDest!.jsonStoryText.Slines.Add(s3 = ExtractLine(input, ref off));
                            }
                            */

                            for (int ix = 0; ix < ct; ix++)
                            {
                                string s3 = ExtractLine(input, ref off);
                                s2 = s3.Split(' ');
                                int ctLine = Int32.Parse(s2[0]);

                                string s4 = input.Substring(off, ctLine);
                                off += ctLine;

                                soDest!.jsonStoryText!.Slines.Add(s4);

                                s3 = ExtractLine(input, ref off);
                            }

                            // string s3 = ExtractLine(input, ref off)
                            if (soDest!.jsonStoryText!.WholeStory != null)
                                soDest!.jsonStoryText.WholeStory.Clear();
                            if (soDest!.jsonStoryText.LatestStory != null)
                                soDest!.jsonStoryText.LatestStory.Clear();

                            handled = true;
                        }
                        /*
                        else if (s2[0] == "WholeStory:")
                        {
                            s1 = ExtractTextBlock(input , ref off);
                            soDest!.jsonStoryText.WholeStory.Clear();
                            soDest!.jsonStoryText.WholeStory.Append (s1 );
                            handled = true;
                        }
                        */
                    }
                    else if (SGType == sgTypes.location)
                    {

                        if (s2[0] == "Visited:")
                        {
                            bool visited = false;

                            if (s2[1] == "True") visited = true;

                            soDest!.jsonlocations!.List[currentItem].Visited = visited;
                            handled = true;
                        }
                        else if (s2[0] == "LocExit:")
                        {
                            int val1 = Int32.Parse(s2[1]);
                            int val2 = Int32.Parse(s2[2]);

                            soDest!.jsonlocations!.List[currentItem].LocExit[val1] = val2;
                            handled = true;
                        }
                        else if (s2[0] == "LocaLocDesc:")
                        {
                            soDest!.jsonlocations!.List[currentItem].LocaLocDesc = s2[1]!;
                            handled = true;
                        }
                        else if (s2[0] == "LocaLocName:")
                        {
                            soDest!.jsonlocations!.List[currentItem].LocaLocName = s2[1]!;
                            handled = true;
                        }
                        else if (s2[0] == "LocaLocDescRaw:")
                        {
                            soDest!.jsonlocations!.List[currentItem].LocaLocDescRaw = s2[1]!;
                            handled = true;
                        }
                        else if (s2[0] == "controllerName:")
                        {
                            soDest!.jsonlocations!.List[currentItem].controllerName = s2[1]!;
                            handled = true;
                        }
                        else if (s2[0] == "LocPicture:")
                        {
                            soDest!.jsonlocations!.List[currentItem].LocPicture = s2[1]!;
                            handled = true;
                        }
                        else if (s2[0] == "locadd:")
                        {
                            int ct = Int32.Parse(s2[1]);

                            soDest!.jsonlocations!.List[currentItem].locadd.Clear();

                            for (int ix2 = 0; ix2 < ct; ix2++)
                            {
                                s1 = ExtractLine(input, ref off);
                                s2 = s1.Split(' ');

                                // changes += string.Format("{0} {1} {2}\n", lc.locadd[ix2].Stat, lc.locadd[ix2].Val, lc.locadd[ix2].Loca);
                                int Stat = Int32.Parse(s2[0]);
                                int Val = Int32.Parse(s2[1]);
                                string Loca = s2[2];

                                soDest!.jsonlocations!.List[currentItem].locadd.Add(new locationAdd(Stat, Val, ""));
                                /*
                                soDest!.jsonlocations!.List[currentItem].locadd[ix2].Stat = Stat;
                                soDest!.jsonlocations!.List[currentItem].locadd[ix2].Val = Val;
                                soDest!.jsonlocations!.List[currentItem].locadd[ix2].Loca = Loca;
                                */
                            }
                            handled = true;
                        }

                        // changes += string.Format("LocExit: {0} {1}\n", ix.ToString(), lc.LocExit[ix2].ToString());
                    }
                    else if (SGType == sgTypes.stats)
                    {
                        if (s2[0] == "Val:")
                        {
                            soDest!.jsonStats!.List![currentItem].Val = Int32.Parse(s2[1]);
                            handled = true;
                        }

                    }
                    else if (SGType == sgTypes.score)
                    {
                        if (s2[0] == "Comment:")
                        {
                            soDest!.jsonScores!.Scores![currentItem].LocaComment = s2[1];
                            handled = true;
                        }
                        else if (s2[0] == "Active:")
                        {
                            bool active = false;

                            if (s2[1] == "True") active = true;

                            soDest!.jsonScores!.Scores![currentItem].Active = active;
                            handled = true;
                        }
                        else if (s2[0] == "SpoilerState:")
                        {
                            spoiler spoiler = spoiler.nospoiler;

                            if (s2[1] == "solution") spoiler = spoiler.solution;
                            if (s2[1] == "spoiler") spoiler = spoiler.spoiler;
                            if (s2[1] == "tipp") spoiler = spoiler.tipp;

                            soDest!.jsonScores!.Scores![currentItem].SpoilerState = spoiler;
                            handled = true;
                        }

                    }
                    else if (SGType == sgTypes.fbe)
                    {
                        if (s2[0] == "FeedbackOffMC:")
                        {
                            // soDest!.jsonFeedbackText.FeedbackOffMC = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        else if (s2[0] == "FeedbackSizeMC:")
                        {
                            // soDest!.jsonFeedbackText. = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        else if (s2[0] == "FeedbackCountMC:")
                        {
                            // soDest!.jsonFeedbackText.FeedbackCountMC = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        else if (s2[0] == "FeedbackModeMC:")
                        {
                            // bool feedbackModeMC = false;

                            // if (s2[1] == "True") feedbackModeMC = true;

                            // soDest!.jsonFeedbackText.FeedbackModeMC = feedbackModeMC;
                            handled = true;
                        }
                        else if (s2[0] == "FeedbackWindowText:")
                        {
                            int ix = Int32.Parse(s2[1]);

                            /*
                            while(ix >= ( soDest!.jsonFeedbackText!.FeedbackWindowText.Count ) )
                            {
                                soDest!.jsonFeedbackText.FeedbackWindowText.Add("");
                            }
                            soDest!.jsonFeedbackText.FeedbackWindowText[ix]= s2[2];
                            */
                            handled = true;
                        }

                        else if (s2[0] == "FeedbackWindowTextMC:")
                        {
                            int ix = Int32.Parse(s2[1]);

                            /*
                            while (ix >= (soDest!.jsonFeedbackText.FeedbackWindowTextMC.Count))
                            {
                                soDest!.jsonFeedbackText.FeedbackWindowTextMC.Add("");
                            }
                            soDest!.jsonFeedbackText.FeedbackWindowTextMC[ix] = s2[2];
                            */
                            handled = true;
                        }

                    }
                    else if (SGType == sgTypes.a)
                    {
                        /*
                        changes += string.Format("ActLoc: {0}\n", A!.ActLoc!);
                        changes += string.Format("ActPerson: {0}\n", A!.ActPerson!);
                        changes += string.Format("ActScore: {0}\n", A!.ActScore!);
                        changes += string.Format("MaxScore: {0}\n", A!.MaxScore!);
                        changes += string.Format("StartLoc: {0}\n", A!.StartLoc!);
                        changes += string.Format("Finish: {0}\n", A!.Finish!);
                        changes += string.Format("Tense: {0}\n", A!.Tense!);
                        changes += string.Format("difficulty: {0}\n", A!.Difficulty!);
                        */

                        if (s2[0] == "ActLoc:")
                        {
                            soDest!.jsonA!.ActLoc = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        else if (s2[0] == "ActPerson:")
                        {
                            soDest!.jsonA!.ActPerson = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        else if (s2[0] == "ActScore:")
                        {
                            soDest!.jsonA!.ActScore = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        else if (s2[0] == "MaxScore:")
                        {
                            soDest!.jsonA!.MaxScore = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        else if (s2[0] == "Finish:")
                        {
                            bool finish = false;

                            if (s2[1] == "True") finish = true;
                            soDest!.jsonA!.Finish = finish;
                            // Nein, das Finish-Flag wird nicht übernommen. Es darf nur gesetzt sein, wenn die App
                            // geschlossen wird und alle Daten gezippt werden sollen vor dem finalen Schreiben und quitten
                            soDest!.jsonA!.Finish = false;
                            handled = true;
                        }
                        else if (s2[0] == "StartLoc:")
                        {
                            soDest!.jsonA!.StartLoc = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        else if (s2[0] == "Tense:")
                        {
                            soDest!.jsonA!.Tense = Int32.Parse(s2[1]);
                            handled = true;
                        }
                        else if (s2[0] == "difficulty:")
                        {
                            soDest!.jsonA!.Difficulty = Int32.Parse(s2[1]);
                            handled = true;
                        }
                    }
                    else if (SGType == sgTypes.pv)
                    {
                        if (s2[0] == "replacement:")
                        {
                            int ix = Int32.Parse(s2[1]);
                            int ix2 = Int32.Parse(s2[2]);

                            PVLoc pvl2 = AdvGame!.GD!.StartStatus!.jsonPV!.PVList![ix]!.PVLoc![ix2]!;

                            bool replacement = false;

                            if (s2[3] == "True") replacement = true;

                            soDest!.jsonPV!.PVList![ix]!.PVLoc[ix2].replacement = replacement;
                            handled = true;
                        }

                        /*
                        if (pvl.locationID != pvl2.locationID)
                        {
                            changes += string.Format("locationID: {0}\n", pvl.locationID.ToString());
                            changedIx = true;

                        }
                        if (pvl.PVSubLevel != pvl2.PVSubLevel)
                        {
                            changes += string.Format("PVSubLevel: {0}\n", pvl.PVSubLevel.ToString());
                            changedIx = true;

                        }
                        if (pvl.replacement != pvl2.replacement)
                        {
                            changes += string.Format("replacement: {0}\n", pvl.replacement.ToString());
                            changedIx = true;

                        }
                        */

                        SGType = sgTypes.fbe;
                        handled = true;

                    }

                    if (s2[0] == "Item:")
                    {
                        currentItem = Int32.Parse(s2[1]);
                        SGType = sgTypes.item;
                        handled = true;
                    }
                    else if (s2[0] == "Person:")
                    {
                        currentItem = Int32.Parse(s2[1]);
                        SGType = sgTypes.person;
                        handled = true;
                    }
                    else if (s2[0] == "Location:")
                    {
                        currentItem = Int32.Parse(s2[1]);
                        SGType = sgTypes.location;
                        handled = true;
                    }
                    else if (s2[0] == "Stat:")
                    {
                        currentItem = Int32.Parse(s2[1]);
                        SGType = sgTypes.stats;
                        handled = true;
                    }
                    else if (s2[0] == "Score:")
                    {
                        currentItem = Int32.Parse(s2[1]);
                        SGType = sgTypes.score;
                        handled = true;
                    }
                    else if (s2[0] == "Language" && s2[1] == "Info:")
                    {
                        s1 = ExtractLine(input, ref off);
                        s2 = s1.Split(' ');
                        IGlobalData.language lengua = IGlobalData.language.german;
                        if (s2[0] == "english") lengua = IGlobalData.language.english;

                        // if( lang != null )
                        lang = lengua;
                        // AdvGame!.GD!.Language = lengua;
                        handled = true;

                    }
                    else if (s2[0] == "STE:")
                    {
                        SGType = sgTypes.ste;
                        handled = true;
                    }
                    else if (s2[0] == "FBE:")
                    {
                        SGType = sgTypes.fbe;
                        handled = true;
                    }
                    else if (s2[0] == "PV:")
                    {
                        SGType = sgTypes.pv;
                        handled = true;
                    }
                    else if (s2[0] == "A:")
                    {
                        SGType = sgTypes.a;
                        handled = true;
                    }
                    else if (s2[0] == "LatestInput:")
                    {
                        s1 = ExtractLine(input, ref off);
                        if (soDest!.jsonLI == null) soDest!.jsonLI = new();
                        soDest!.jsonLI.Add(new LatestInput(s1));
                        handled = true;
                    }
                    else if (s2[0] == "GameDefinitions:")
                    {
                        int len = Int32.Parse(s2[1]);

                        string s3 = input.Substring(off, len);
                        off += len;
                        GameDefinitions gdi = JsonConvert.DeserializeObject<GameDefinitions>(s3)!;

                        soDest.JsonGameDefinitions = gdi;
                        handled = true;
                    }
                    /* Doppelt versehentlich
                    else if (s2[0] == "SLines:")
                    {
                        int ct = Int32.Parse(s2[1]);


                        soDest.jsonSlines = new();


                        for (int ix = 0; ix < ct; ix++)
                        {
                            s1 = ExtractLine(input, ref off);
                            int len = Int32.Parse(s1);

                            string s3 = input.Substring(off, len);
                            off += len;

                            soDest.jsonSlines.Add(s3);
                        }
                    }
                */

                    else if (s2[0] == "Version:")
                    {
                        s1 = ExtractLine(input, ref off);
                        s2 = s1.Split(' ');
                        soDest!.jsonVersion = new Phoney_MAUI.Core.Version();
                        soDest!.jsonVersion.Version1 = Int32.Parse(s2[0]);
                        soDest!.jsonVersion.Version2 = Int32.Parse(s2[1]);
                        soDest!.jsonVersion.Version3 = Int32.Parse(s2[2]);
                        soDest!.jsonVersion.VersionDate = new(Int32.Parse(s2[5]), Int32.Parse(s2[4]), Int32.Parse(s2[3]));

                        handled = true;
                    }
                    else if (s2[0] == "OrderTable:")
                    {
                        s1 = ExtractLine(input, ref off);
                        s2 = s1.Split(' ');
                        currentItem = Int32.Parse(s2[1]);
                        int ct = Int32.Parse(s2[2]);

                        ObservableCollection<OrderTable>? otl = new();

                        // soDest!.jsonOrderListTable!.OT!.Clear();
                        for (int ix = 0; ix < ct; ix++)
                        {
                            s1 = ExtractLine(input, ref off);
                            s2 = s1.Split(' ');

                            OrderTable ot;

                            if (s2[1] == "orderText")
                            {
                                string s4 = S1ExtractInput(s1);
                                string s3 = s4.Substring(0, s4.Length - 1 );
                                ot = new(orderType.orderText, s3, 0, soDest!.jsonLanguage);
                                ot.No = ix + 1;
                            }
                            else if (s2[1] == "mcChoice")
                            {
                                string s4 = S1ExtractInput(s1);
                                string s3 = s4.Substring(0, s4.Length - 1);
                                ot = new(orderType.mcChoice, "", Int32.Parse(s2[4]), soDest!.jsonLanguage);
                                ot.No = ix + 1;
                            }
                            else if (s2[1] == "Comment")
                            {
                                string s3 = S1ExtractInput(s1);
                                ot = new(orderType.comment, s3, 0, soDest!.jsonLanguage);
                                ot.No = ix + 1;
                            }
                            else
                            {
                                string s3 = S1ExtractInput(s1);
                                ot = new(orderType.noText, s3, 0, soDest!.jsonLanguage);
                                ot.No = ix + 1;
                            }
                            int lenPath = Int32.Parse(s2[2]);
                            int lenResult= Int32.Parse(s2[3]);

                            ot.OrderPath = input.Substring(off, lenPath);
                            off += lenPath;

                            ot.OrderResult = input.Substring(off, lenResult);
                            off += lenResult;

                            off += 2;

                            otl.Add(ot);

                        }

                        bool valid = true;
                        if (soDest!.jsonOrderListTable!.Point != otl.Count - 1)
                        {
                            valid = false;
                        }
                        else
                        {
                            for (int ix = 0; ix < soDest!.jsonOrderListTable.Point; ix++)
                            {
                                if (soDest.jsonOrderListTable.OT![ix].OrderType != otl[ix].OrderType)
                                    valid = false;
                                else
                                {
                                    if (otl[ix].OrderType == orderType.orderText)
                                    {
                                        if (String.Compare(soDest.jsonOrderListTable.OT[ix].OrderText, otl[ix].OrderText) != 0)
                                            valid = false;
                                    }
                                    if (otl[ix].OrderType == orderType.mcChoice)
                                    {
                                        if (soDest.jsonOrderListTable.OT[ix].OrderChoice != otl[ix].OrderChoice)
                                            valid = false;
                                    }
                                    if (otl[ix].OrderType == orderType.comment )
                                    {
                                        if (String.Compare(soDest.jsonOrderListTable.OT[ix].OrderText, otl[ix].OrderText) != 0)
                                            valid = false;
                                    }
                                }
                            }
                        }
                        if (valid == false)
                        {
                            OrderListTable _tempOLT = new();
                            _tempOLT.OT = otl;
                            _tempOLT.Name = soDest.jsonOrderListTable.Name + "a";
                            _tempOLT.Point = otl.Count - 1;
                            _tempOLT.TempPoint = -1;
                            _tempOLT.Zipped = false;

                            soDest.jsonOrderListTable = _tempOLT;

                            // soDest.jsonOrderListTable.OT = otl;
                            // soDest.jsonOrderListTable.Point = otl.Count - 1;
                        }
                        // Hm, sollte TempPoint da nicht -1 sein?
                        soDest!.jsonOrderListTable.TempPoint = soDest!.jsonOrderListTable.OT!.Count;
                        SGType = sgTypes.ordertable;
                        handled = true;
                    }
                    else if (!handled && s1 == "")
                    {
                        handled = true;
                    }
                    else if (!handled)
                    {

                    }

                    if (off >= input.Length)
                        break;
                    if (!handled)
                        break;
                }
            }
            catch (Exception e)
            {

            }
        }

        public  Object? GetPropValue( Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null)
                {
                    return null;
                }

                Type type = obj.GetType();
                PropertyInfo? info = type.GetProperty(part);
                if (info == null)
                {
                    return null;
                }

                obj = info.GetValue(obj, null)!;
            }
            return obj;
        }

        public  T GetPropValue<T>( Object obj, String name)
        {
            Object retval = GetPropValue(obj, name)!;
            if (retval == null)
            {
                return default(T)!;
            }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }
 

        public bool ReadSlotDescription()
        {
            // Ignores: 001
            string? pathName = Phoney_MAUI.Core.GlobalData.CurrentPath(); 
            // Ignores: 001
            string? pathfileName = pathName + loca.OrderFeedback_ReadSlotDescription_14040;

            string jsonSource = AdvGame!.UIS!.LoadString(loca.OrderFeedback_ReadSlotDescription_14040)!;
            if ( jsonSource != null )
            {
                AdvGame!.GD!.SlotDescriptions.SlotDescriptions = null;
                Phoney_MAUI.Core.SlotDescription sd = JsonConvert.DeserializeObject<Phoney_MAUI.Core.SlotDescription>(jsonSource)!;
                AdvGame!.GD!.SlotDescriptions = sd!;
            }
            return true;
        }


        public bool WriteSlotDescription()
        {

            string? jsonDest = JsonConvert.SerializeObject(AdvGame!.GD!.SlotDescriptions, Newtonsoft.Json.Formatting.Indented);
            AdvGame!.UIS!.SaveString(loca.OrderFeedback_WriteSlotDescription_14043, jsonDest);

            return true;
        }

        /*
        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static Object ByteArrayToObject(byte[] arrBytes)
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
        */
      
        public virtual bool  Save(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            Prep slotID = ((Prep)PTL!.Index(1)!.O!)!;
            int slotNr;

            if (slotID == CB!.Prep_Slot1) slotNr = 1;
            else if (slotID == CB!.Prep_Slot2) slotNr = 2;
            else if (slotID == CB!.Prep_Slot3) slotNr = 3;
            else if (slotID == CB!.Prep_Slot4) slotNr = 4;
            else if (slotID == CB!.Prep_Slot5) slotNr = 5;
            else if (slotID == CB!.Prep_Slot6) slotNr = 6;
            else if (slotID == CB!.Prep_Slot7) slotNr = 7;
            else if (slotID == CB!.Prep_Slot8) slotNr = 8;
            else if (slotID == CB!.Prep_Slot9) slotNr = 9;
            else if (slotID == CB!.Prep_Slot10) slotNr = 10;
            else slotNr = 1;

            // Ignores: 002
            CoreSave( loca.OrderFeedback_Save_14044 +slotNr + loca.OrderFeedback_Save_14045);
            AdvGame!.GD!.SlotDescriptions!.SlotDescriptions![slotNr] = AdvGame!.StateDescription();

            WriteSlotDescription();
            /*
            string up = System.Environment.GetEnvironmentVariable( "USERPROFILE");
            string pathName = up + "\\documents\\My Games\\Phoney Island";
            string fileName = pathName + "\\slot" +slotNr + ".sav";

            if (!System.IO.Directory.Exists(pathName))
            {
                string p1 = up + "\\documents\\My Games\\Phoney Island";
                System.IO.Directory.CreateDirectory(p1);
                FileInfo filePath = new FileInfo(p1);
            }


            SaveObj SO = new SaveObj();

            SO.jsonItems = Items;
            SO.jsonlocations = locations;
            SO.jsonPersons = Persons;
            SO.jsonTopics = Topics;
            SO.jsonAdjs = Adjs;
            SO.jsonA = A;
            SO.jsonNouns = Nouns;
            SO.jsonVerbs = Verbs;
            SO.jsonPreps = Preps;
            SO.jsonFills = Fills;
            SO.jsonStats = Stats;
            SO.jsonLI = LI;
            SO.jsonCA = CA;
            SO.jsonCB = CB;
            // SO.jsonParser = AdvGame!.Parser;



            // SO.jsonMCE = MCE;
            // SO.jsonMCV = MCV;


            IFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, SO);
            stream.Close();

            // jsonString = JsonSerializer.Serialize(SO);
            // File.WriteAllText(fileName, jsonString);
            */

            // Ignores: 002
            AdvGame!.FeedbackOutput(PersonID, loca.OrderFeedback_Save_14046 +slotNr + loca.OrderFeedback_Save_14047, true);
            return (false);
        }


        public string PathFileNameFromSlot( int SlotNr )
        {
            // Ignores: 001
            string? pathName = Phoney_MAUI.Core.GlobalData.CurrentPath(); 
            // Ignores: 002
            string? pathfileName = pathName + loca.OrderFeedback_PathFileNameFromSlot_14050 +SlotNr+loca.OrderFeedback_PathFileNameFromSlot_14051;

            return pathfileName!;
        }

        public string? PathFileNameFromFileName(string FileName)
        {
            // Ignores: 001
            string? pathName = Phoney_MAUI.Core.GlobalData.CurrentPath();
            // Ignores: 002
            string? pathfileName = pathName + loca.OrderFeedback_PathFileNameFromFileName_14054 + FileName;

            return pathfileName;
        }



        private bool FindOrderlistName(string name)
        {
            bool found = false;

            foreach (OrderListTable otl in AdvGame!.GD!.OrderList!.OTL!)
            {
                if (otl.Name == name)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public bool FindOrAddOrderList(OrderListTable tempOTL)
        {
            bool found = false;
            int index = 0;

            if (AdvGame != null && tempOTL != null )
            {
                foreach (OrderListTable otl in AdvGame!.GD!.OrderList!.OTL!)
                {
                    if (index > 0 && AdvGame!.GD!.OrderList.CompareRuns(otl, tempOTL, index) == true)
                    {
                        found = true;
                        break;
                    }

                    index++;
                }
            }

            if (!found)
            {
                if (tempOTL == null)
                {

                }

                string newName = tempOTL!.Name! + loca.OrderFeedback_FindOrAddOrderList_14055;

                while ( FindOrderlistName( newName) == true )
                {
                    newName += loca.OrderFeedback_FindOrAddOrderList_14056;
                }

                AdvGame!.GD!.OrderList!.AddOrderList(tempOTL!.Name! + loca.OrderFeedback_FindOrAddOrderList_14057);
                AdvGame!.GD!.OrderList!.CurrentOrderListIx = AdvGame!.GD!.OrderList!.OTL!.Count - 1;
                AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx] = tempOTL;
                AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx].Name += loca.OrderFeedback_FindOrAddOrderList_14058;
                AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx].Point = tempOTL.Point; //  AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].OT.Count - 1; 
                /*
                if(AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].Point < AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].OT.Count)
                {
                    for (int ix = AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].Point + 1; ix < AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].OT.Count; ix++)
                    {
                        AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].OT![ix].OrderResult = "";
                        AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].OT![ix].OrderFeedback = "";

                    }

                }
                */

                index = AdvGame!.GD!.OrderList.CurrentOrderListIx;
            }
            else
            {
                
                AdvGame!.GD!.OrderList!.CurrentOLIndex = index;
                AdvGame!.GD!.OrderList!.CurrentOrderListIx = index;
                AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].Point = tempOTL!.Point!; //  AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].OT.Count - 1; 

                /*
                if (AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].Point < AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].OT.Count)
                {
                    for (int ix = AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].Point + 1; ix < AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].OT.Count; ix++)
                    {
                        AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].OT![ix].OrderResult = "";
                        AdvGame!.GD!.OrderList.OTL![AdvGame!.GD!.OrderList.CurrentOrderListIx].OT![ix].OrderFeedback = "";
                    }
                }
                */
            }
            AdvGame!.UIS!.RefreshOrderList();
            return (found);
        }

        /* 21.8.2023 ausgelagert
        public SaveObj CoreLoadFromFile(string fileName)
        {
            SaveObj? SO = null;

            string pathfileName = GlobalData.CurrentPathPlusFilename(fileName);

            using (FileStream fs = new FileStream(pathfileName, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                SO = (SaveObj)formatter.Deserialize(fs);
            }

            return (SO);
        }
        */
        /* 21.8.2023: Nicht mehr benötigt?
        public static SaveObj? CoreLoadFromStartStatus(byte[] StartStatus)
        {
            SaveObj? SO = null;

            using (MemoryStream ms = new MemoryStream(StartStatus))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                SO = (SaveObj)formatter.Deserialize( ms );
            }
            return (SO);
        }
        */

        public void CoreLoad( string fileName, Adv? AdvTest = null )
        {
 
            GC.Collect();
            long mem = GC.GetTotalMemory(true);
            long mem3 = 0;
            long mem4 = 0;
            long mem5 = 0;
            long mem6 = 0;
            long mem7 = 0;
            long mem8 = 0;
            long mem9 = 0;
            long mem10 = 0;
            long mem11 = 0;
            long mem12 = 0;
            long mem13 = 0;
            long mem14 = 0;
            long mem15 = 0;
            long mem16 = 0;
            long mem17 = 0;

            SaveObj? SO=null;
            IGlobalData.language targetlanguage = IGlobalData.language.german; 
            SO = LoadGame(fileName, ref targetlanguage);

            mem14 = GC.GetTotalMemory(true);
            GC.Collect();

            mem15 = GC.GetTotalMemory(true);
            if( SO == null )
            {

            }
            else if ( (AdvGame != null ) && ( AdvGame!.GD!.Version.CheckVersion(SO!.jsonVersion!) == false ) )
            {
                AdvGame!.StoryOutput( String.Format( loca.OrderFeedback_CoreLoad_14062, fileName ));

            }
            else 
            {
                mem16 = GC.GetTotalMemory(true);

                // wenn die Liste nicht 1:1 gefunden wird: 
                // Es wird eine neue Liste angelegt unter dem alten Namen plus ".loaded" hinten dran 
                OrderListTable tempOTL = SO.jsonOrderListTable!;
                FindOrAddOrderList(tempOTL);

                mem17 = GC.GetTotalMemory(true);

                IGlobalData.language lengua = SO!.jsonLanguage;

                AdvGame!.Items = SO!.jsonItems;
                AdvGame!.Persons = SO!.jsonPersons;
                AdvGame!.locations = SO!.jsonlocations!;
                AdvGame!.Adjs = SO!.jsonAdjs;
                // SO.jsonA!.Adventure = AdvGame!;
                AdvGame!.A =  SO!.jsonA!;
                AdvGame!.Nouns = SO!.jsonNouns;
                AdvGame!.Verbs = SO!.jsonVerbs;
                AdvGame!.Preps = SO!.jsonPreps;
                AdvGame!.Pronouns = SO!.jsonPronouns;
                AdvGame!.Fills = SO!.jsonFills;
                AdvGame!.Stats = SO!.jsonStats;
                AdvGame!.ItemQueue = SO!.jsonItemQueue;
                AdvGame!.Scores = SO!.jsonScores;
                AdvGame!.LI = SO!.jsonLI!;
                AdvGame!.Topics = SO!.jsonTopics;
                // Testweise reingenommen: Müssen CA und CB hier aktualisiert werden?
                AdvGame!.CA = SO!.jsonCA!;
                AdvGame!.CB = SO!.jsonCB!;

                // Von STE werden nur die wichtigen Buffer übertragen
                AdvGame.STE = new( (Phoney_MAUI.Core.UIServices) AdvGame!.UIS! );
                AdvGame.STE.Slines = SO!.jsonStoryText!.Slines;
                AdvGame.STE.SlinesBuffer = SO!.jsonStoryText!.SlinesBuffer;


                AdvGame!.FBE = SO!.jsonFeedbackText!;
                AdvGame!.VerbTenses = SO!.jsonVerbTenses!;
                AdvGame!.PV = SO!.jsonPV!;
                // AdvGame!.SetCallbacks();
                mem3 = GC.GetTotalMemory(true);
                locations!.SetAdv(AdvGame);
                mem4 = GC.GetTotalMemory(true);
                Persons!.SetAdv(AdvGame);
                mem4 = GC.GetTotalMemory(true);
                 mem5 = GC.GetTotalMemory(true);
                SetAdventureGame(AdvGame);
                mem6 = GC.GetTotalMemory(true);
                AdvGame!.SetObjectReferences(Items!, Persons!, locations!, Nouns!, Adjs!, Verbs!, Preps!, Fills!, Stats!, LI!, Topics!, CA!, CB!);
                mem7 = GC.GetTotalMemory(true);
                // AdvGame!.A!.Adventure = AdvGame;
                AdvGame!.ResetParser();
                AdvGame!.Parser!.SetObjectReferences(Items!, Persons!, Nouns!, Adjs!, Verbs!, Preps!, Fills!, Topics!, AdvGame!.PLL!);
                AdvGame!.InitPLL();
                mem8 = GC.GetTotalMemory(true);
                AdvGame!.Parser!.SetObjectReferences(Items!, Persons!, Nouns!, Adjs!, Verbs!, Preps!, Fills!, Topics!, AdvGame!.PLL!);
                mem9 = GC.GetTotalMemory(true);
                AdvGame!.ResetParser();
                mem10 = GC.GetTotalMemory(true);
                AdvGame!.ResetStoryText();
                mem11 = GC.GetTotalMemory(true);
                AdvGame!.ResetFeedbackText();
                mem12 = GC.GetTotalMemory(true);
                // Helper.ConfigInsert(Persons, Items, locations, Topics!, CB, A, AdvGame);
                // AdvGame.locations.A = SO.jsonA;
                // AdvGame.locations.Persons = SO.jsonPersons!;
                // AdvGame.Persons.A = SO.jsonA;
                // AdvGame.Items!.A = SO.jsonA;
                Grammar.Init(AdvGame!.A, AdvGame!.VerbTenses, Items, Persons);
                AdvGame.A.ActPerson = SO!.jsonCA!.Person_I!.ID;
                AdvGame.SetAdv( AdvGame );

                if( SO!.JsonGameDefinitions!.MCVisible != IGameDefinitions.mcvMode.none)
                {
                    AdvGame.Orders!.MCPersonID = SO.JsonGameDefinitions.MCPersonID;
                    AdvGame.Orders.MCID = SO.JsonGameDefinitions.MCID;
                    AdvGame.Orders.MCMenuFunc = SO.JsonGameDefinitions.MCVFuncName;

                    if (SO!.JsonGameDefinitions.MCVisible == IGameDefinitions.mcvMode.persistent)
                    {
                        AdvGame.UIS!.MCMV = new Phoney_MAUI.Core.MCMenuView();
                        AdvGame.Orders.RestoreGeneratedDialog(SO.JsonGameDefinitions.MCPersonID,
                            SO.JsonGameDefinitions.MCVFuncName!);
                    }
                    else
                    {
                        AdvGame.UIS!.MCMV = new Phoney_MAUI.Core.MCMenuView();
                        AdvGame.Orders.RestoreTemporaryDialog( SO!.JsonGameDefinitions.MCMenuTemp, SO!.JsonGameDefinitions.MCCallbackName!);
                        // temporary dialogs
                    }
                }
                AdvGame._currentEventName = SO.JsonGameDefinitions.CurrentEventName;
                AdvGame._ixCurrent = SO.JsonGameDefinitions.IxCurrent;
                AdvGame._actLocEvent = SO.JsonGameDefinitions.ActLocEvent;
                AdvGame._actLocEventSeqStart = SO.JsonGameDefinitions.ActLocEventSeqStart;
                AdvGame._actLocEventStartPoint = SO.JsonGameDefinitions.ActLocEventStartPoint;
                AdvGame._lastLocEventStartPoint = SO.JsonGameDefinitions.LastLocEventStartPoint;
                AdvGame._actLocCollecting = SO.JsonGameDefinitions.ActLocCollecting;
                AdvGame._lastLoc = SO.JsonGameDefinitions.LastLoc;
                AdvGame._actLoc = SO.JsonGameDefinitions.ActLoc;

                AdvGame.GD!.PicMode = SO.JsonGameDefinitions.PicMode;

                AdvGame.Orders!.MCCallbackName = SO.JsonGameDefinitions.MCCallbackName;
                AdvGame.Orders.MCID = SO.JsonGameDefinitions.MCID;
                AdvGame.Orders.MCPersonID = SO.JsonGameDefinitions.MCPersonID;


                mem13 = GC.GetTotalMemory(true);

                AdvGame.STE.RecalcLatest();

                // AdvGame!.GD!.Language = targetlanguage;

                foreach (Person p in Persons!.List!.Values!)
                {
                    foreach (DialogList dl in p.DialogList!)
                    {
                        if (dl.LatestDialog != null)
                        {
                            // dl.LatestDialog.AdvGame = AdvGame;
                            dl.LatestDialog.MCS = null;
                        }
                    }
                }

                mem14 = GC.GetTotalMemory(true);

                loca.GD!.ResetLanguageCallbacks();
                loca.GD!.AddLanguageCallback(AdvGame!.UIS!.SetFullUIText!);
                loca.GD!.AddLanguageCallback(AdvGame!.Verbs!.RestoreVerbs!);
                loca.GD!.AddLanguageCallback(AdvGame!.Adjs!.RestoreAdjectives!);
                loca.GD!.AddLanguageCallback(AdvGame!.Nouns!.RestoreNouns!);
                loca.GD!.AddLanguageCallback(AdvGame!.Fills!.RestoreFill!);
                loca.GD!.AddLanguageCallback(AdvGame!.Preps!.RestorePrep !);
                loca.GD!.AddLanguageCallback(AdvGame!.Pronouns!.RestorePronouns!);
                loca.GD!.AddLanguageCallback(AdvGame!.VerbTenses!.RestoreVTList!);
                loca.GD!.AddLanguageCallback(AdvGame!.Categories!.RestoreCategoryRelList!);
                loca.GD!.AddLanguageCallback(AdvGame!.Items!.RestoreItems!);
                loca.GD!.AddLanguageCallback(AdvGame!.Persons!.RestorePersons!);
                loca.GD!.AddLanguageCallback(AdvGame!.Topics!.RestoreTopics!);
                loca.GD!.AddLanguageCallback(AdvGame!.Adjs!.RestoreAdjectives!);
                loca.GD!.AddLanguageCallback(AdvGame!.locations!.RestoreLocations!);
                loca.GD!.AddLanguageCallback(AdvGame!.RestoreLocationName!);
                loca.GD!.AddLanguageCallback(AdvGame!.InitPLL!);
#if MAUI
                loca.GD!.AddLanguageCallback(AdvGame!.UIS.SetLanguage);
#endif

                loca.GD!.Language = targetlanguage;
                GD!.LatestGameDefinition = SO.JsonGameDefinitions;
                LayoutRefresh();
                loca.GD.UIS!.RecalcPictures();
                // locations.Showlocation(A!.ActLoc);

                /*
                AdvGame!.GD!.OrderList.OTL![0] = new OrderListTable(SO.jsonOrderListTable.Name);
                AdvGame!.GD!.OrderList.OTL![0].OT = SO.jsonOrderListTable.OT;
                AdvGame!.GD!.OrderList.OTL![0].Point = SO.jsonOrderListTable.Point;
                AdvGame!.GD!.OrderList.OTL![0].TempPoint = SO.jsonOrderListTable.TempPoint;
                */
                // AdvGame!.GD!.OrderList.SetShowChanges = AdvGame!.MW.UpdateOrderList;
                // AdvGame!.MW.UpdateOrderList(AdvGame!.GD!.OrderList);
                // SetAdventureGame(AdvGame);
            }

            SO = null;
            long mem2 = GC.GetTotalMemory(true);
        }

        public virtual bool  Load(Person PersonID, ParseTokenList PTL )
        {
            OrderFeedback of = new OrderFeedback();
            Prep slotID = ((Prep)PTL!.Index(1)!.O!)!;
            int slotNr;

            if (slotID == CB!.Prep_Slot1) slotNr = 1;
            else if (slotID == CB!.Prep_Slot2) slotNr = 2;
            else if (slotID == CB!.Prep_Slot3) slotNr = 3;
            else if (slotID == CB!.Prep_Slot4) slotNr = 4;
            else if (slotID == CB!.Prep_Slot5) slotNr = 5;
            else if (slotID == CB!.Prep_Slot6) slotNr = 6;
            else if (slotID == CB!.Prep_Slot7) slotNr = 7;
            else if (slotID == CB!.Prep_Slot8) slotNr = 8;
            else if (slotID == CB!.Prep_Slot9) slotNr = 9;
            else if (slotID == CB!.Prep_Slot10) slotNr = 10;
            else slotNr = 1;

            if (AdvGame!.UIS!.ExistFile(PathFileNameFromSlot( slotNr )))
            {
                AdvGame!.FeedbackOutput(PersonID, String.Format( loca.OrderFeedback_Load_14063, slotNr) , true);
                return (false);
            }

            // Ignores: 002
            CoreLoad( loca.OrderFeedback_Load_14064 +slotNr + loca.OrderFeedback_Load_14065);

            /*
            SaveObj SO = new SaveObj();

            SO.jsonIT = IT;
            SO.jsonLOC = Loc;
            SO.jsonADJ = ADJ;
            SO.jsonA = A;
            SO.jsonNN = NN;
            SO.jsonOrd = Ord;
            SO.jsonPR = PR;
            SO.jsonFL = FL;

            jsonString = File.ReadAllText(fileName);
            SO = JsonSerializer.
            SaveObj>(jsonString);
            */

            AdvGame!.FeedbackOutput(PersonID, String.Format( loca.OrderFeedback_Load_14066, slotNr ) , true);
            // locations!.ShowlocationFull(A!.ActLoc);
            AdvGame!.SetScoreOutput();
            return (false);
        }


        public virtual bool  HelpFor(ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            of.Handled = true;
            return true;
        }

        public virtual bool  HelpForP(ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            of.Handled = true;
            return true;
        }

        public virtual bool  Info(ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            of.Handled = true;
            return true;
        }

        public virtual bool  InfoFor(ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            of.Handled = true;
            return true;
        }

        public virtual bool  InfoForP(ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            of.Handled = true;
            return true;
        }

        public virtual bool  ClueFor(ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            of.Handled = true;
            return true;
        }

        public virtual bool  ClueForP(ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            of.Handled = true;
            return true;
        }

        public virtual bool  SolutionFor(ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            of.Handled = true;
            return true;
        }

        public virtual bool  SolutionForP(ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            of.Handled = true;
            return true;
        }

        public virtual bool  Help(ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            of.Handled = true;
            return true;
        }

        // Hilfsfunktion der Order-Klasse

        public bool ListItems(string? InitText, Person? PersonID, int LocType, int LocID, bool ShowHidden, bool SuppressComment, int grammar = 0, OrderFeedback? of = null, string? nothingString = null )
        {
            if (nothingString == null)
                nothingString = loca.OrderFeedback_ListItems_14067;
            int i = 0;

            if( grammar == 0 )
            {
                grammar = Co.CASE_NOM_UNDEF;
            }

            foreach (Item tItem in Items!.List!.Values)
            {
                if ((tItem.locationType == LocType) && (tItem.locationID == LocID) && (tItem.IsBackground == false) && ((tItem.IsHidden == false) || (ShowHidden == true)))
                    i++;
            }
            if (i > 0)
            {
                int Found = 0;
                string insertBase = loca.OrderFeedback_ListItems_Person_Everyone_14068_App;

                if (grammar == Co.CASE_NOM)
                    insertBase = loca.OrderFeedback_ListItems_Nom;


                AdvGame!.StoryOutput(Persons!.Find(PersonID!)!.locationID, CA!.Person_Everyone, InitText);

                if (of != null) of.StoryOutput = true;
                foreach (Item item in Items!.List.Values)
                {
                    if ((item.locationType == LocType) && (item.locationID == LocID) && (item.IsBackground == false) && ((item.IsHidden == false) || (ShowHidden == true)))
                    {
                        // MW.TextOutput( "- <a href=\"https:www.spiegel.de\" onclick=\"var myMenu = new Menu(); myMenu.addMenuItem(\"my menu item A\"); myMenu.addMenuItem(\"my menu item B\"); myMenu.addMenuItem(\"my menu item C\"); myMenu.addMenuItem(\"my menu item D\"); myMenu.writeMenus();\">"+ Items!.GetItemNameLink(IT[j]!.ID, Co.CASE_NOM_UNDEF)+"</a>");
                        AdvGame!.StoryOutput(Persons!.Find(PersonID!)!.locationID, CA!.Person_Everyone,  Helper.Insert(insertBase, item!.ID ));
                        // Items!.List[j].IsHidden = false;
                        Found++;
                        if (item.IsHidden == true) item.IsHidden = false;

                    }
                    /*
                    for (int j = 0; j < Items!.List.Count; j++)
                    {
                        if ((Items!.List[j].locationType == LocType) && (Items!.List[j].locationID == LocID) && (Items!.List[j].IsBackground == false) && ((Items!.List[j].IsHidden == false) || (ShowHidden == true)))
                        {
                            // MW.TextOutput( "- <a href=\"https:www.spiegel.de\" onclick=\"var myMenu = new Menu(); myMenu.addMenuItem(\"my menu item A\"); myMenu.addMenuItem(\"my menu item B\"); myMenu.addMenuItem(\"my menu item C\"); myMenu.addMenuItem(\"my menu item D\"); myMenu.writeMenus();\">"+ Items!.GetItemNameLink(IT[j]!.ID, Co.CASE_NOM_UNDEF)+"</a>");
                            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert("- [Il1,Akk]", Items!.List[j]!.ID ));
                            // Items!.List[j].IsHidden = false;
                            Found++;
                            if (Items!.List[j].IsHidden == true) Items!.List[j].IsHidden = false;

                        }
                    }
                    */
                }
            }
            else if (!SuppressComment)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID!)!.locationID, CA!.Person_Everyone, nothingString );
                if (of != null) of.StoryOutput = true;
            }
            return (true);
        }

        public bool ListItemsPersons(string InitText, Person PersonID, int LocType, int LocID, bool ShowHidden, bool SuppressComment, int caseObject, OrderFeedback? of = null)
        {
            int i = 0;

            foreach (Item tItem in Items!.List!.Values)
            {
                if ((tItem.locationType == LocType) && (tItem.locationID == LocID) && (tItem.IsBackground == false) && ((tItem.IsHidden == false) || (ShowHidden == true)))
                    i++;
            }
            foreach (Person tPerson in Persons!.List!.Values)
            {
                if ((tPerson.locationType == LocType) && (tPerson.locationID == LocID) && (tPerson.IsBackground == false) && ((tPerson.IsHidden == false) || (ShowHidden == true)))
                    i++;
            }
            if (i > 0)
            {
                int Found = 0;

                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, InitText);

                if (of != null) of.StoryOutput = true;
                foreach (Item item in Items!.List.Values)
                {
                    if ((item.locationType == LocType) && (item.locationID == LocID) && (item.IsBackground == false) && ((item.IsHidden == false) || (ShowHidden == true)))
                    {
                        // MW.TextOutput( "- <a href=\"https:www.spiegel.de\" onclick=\"var myMenu = new Menu(); myMenu.addMenuItem(\"my menu item A\"); myMenu.addMenuItem(\"my menu item B\"); myMenu.addMenuItem(\"my menu item C\"); myMenu.addMenuItem(\"my menu item D\"); myMenu.writeMenus();\">"+ Items!.GetItemNameLink(IT[j]!.ID, Co.CASE_NOM_UNDEF)+"</a>");
                        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ListItemsPersons_Person_Everyone_14069_App, item!.ID ));
                        // Items!.List[j].IsHidden = false;
                        Found++;
                        if (item.IsHidden == true) item.IsHidden = false;

                    }
                }
                if (of != null) of.StoryOutput = true;
                foreach (Person person in Persons!.List.Values)
                {
                    if ((person.locationType == LocType) && (person.locationID == LocID) && (person.IsBackground == false) && ((person.IsHidden == false) || (ShowHidden == true)))
                    {
                        // MW.TextOutput( "- <a href=\"https:www.spiegel.de\" onclick=\"var myMenu = new Menu(); myMenu.addMenuItem(\"my menu item A\"); myMenu.addMenuItem(\"my menu item B\"); myMenu.addMenuItem(\"my menu item C\"); myMenu.addMenuItem(\"my menu item D\"); myMenu.writeMenus();\">"+ Items!.GetItemNameLink(IT[j]!.ID, Co.CASE_NOM_UNDEF)+"</a>");
                        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ListItemsPersons_Person_Everyone_14070, person ));
                        // Items!.List[j].IsHidden = false;
                        Found++;
                        if (person.IsHidden == true) person.IsHidden = false;

                    }
                }

            }
            else if (!SuppressComment)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, loca.OrderFeedback_ListItemsPersons_Person_Everyone_14071);
                if (of != null) of.StoryOutput = true;
            }
            return (true);
        }

        public bool ListPersons(string InitText, Person PersonID, int LocType, int LocID, bool ShowHidden, bool SuppressComment, OrderFeedback? of = null)
        {
            int i = 0;

            foreach (Person tPerson in Persons!.List!.Values!)
            {
                if ((tPerson.locationType == LocType) && (tPerson.locationID == LocID) && (tPerson.IsBackground == false) && ((tPerson.IsHidden == false) || (ShowHidden == true)))
                    i++;
            }
            if (i > 0)
            {
                int Found = 0;

                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, InitText);

                if (of != null) of.StoryOutput = true;
                foreach (Person person in Persons!.List.Values)
                {
                    if ((person.locationType == LocType) && (person.locationID == LocID) && (person.IsBackground == false) && ((person.IsHidden == false) || (ShowHidden == true)))
                    {
                        // MW.TextOutput( "- <a href=\"https:www.spiegel.de\" onclick=\"var myMenu = new Menu(); myMenu.addMenuItem(\"my menu item A\"); myMenu.addMenuItem(\"my menu item B\"); myMenu.addMenuItem(\"my menu item C\"); myMenu.addMenuItem(\"my menu item D\"); myMenu.writeMenus();\">"+ Items!.GetItemNameLink(IT[j]!.ID, Co.CASE_NOM_UNDEF)+"</a>");
                        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ListPersons_Person_Everyone_14072,  person ));
                        // Items!.List[j].IsHidden = false;
                        Found++;
                        if (person.IsHidden == true) person.IsHidden = false;

                    }
                    /*
                    for (int j = 0; j < Items!.List.Count; j++)
                    {
                        if ((Items!.List[j].locationType == LocType) && (Items!.List[j].locationID == LocID) && (Items!.List[j].IsBackground == false) && ((Items!.List[j].IsHidden == false) || (ShowHidden == true)))
                        {
                            // MW.TextOutput( "- <a href=\"https:www.spiegel.de\" onclick=\"var myMenu = new Menu(); myMenu.addMenuItem(\"my menu item A\"); myMenu.addMenuItem(\"my menu item B\"); myMenu.addMenuItem(\"my menu item C\"); myMenu.addMenuItem(\"my menu item D\"); myMenu.writeMenus();\">"+ Items!.GetItemNameLink(IT[j]!.ID, Co.CASE_NOM_UNDEF)+"</a>");
                            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert("- [Il1,Akk]", Items!.List[j]!.ID ));
                            // Items!.List[j].IsHidden = false;
                            Found++;
                            if (Items!.List[j].IsHidden == true) Items!.List[j].IsHidden = false;

                        }
                    }
                    */
                }
            }
            else if (!SuppressComment)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, loca.OrderFeedback_ListPersons_Person_Everyone_14073);
                if (of != null) of.StoryOutput = true;
            }
            return (true);
        }

        public virtual bool  ProcessTake(Item I, Person PersonID, OrderFeedback of, bool silent = false )
        {
            bool success = false;

            if (Items!.IsItemHere(I, Co.Range_Here))
            {
                if (I.CanBeTaken == false)
                {
                   AdvGame!.StoryOutput(  Helper.Insert(loca.OrderFeedback_ProcessTake_14074, PersonID, I!.ID ));
                    success = true;
                    of.FeedbackOutput = true;
                }
                else if ((I.locationType == CB!.LocType_Person) && (I.locationID == PersonID!.ID))
                {
                   AdvGame!.StoryOutput(  Helper.Insert(loca.OrderFeedback_ProcessTake_14075, PersonID, I!.ID ));
                    success = true;
                    of.FeedbackOutput = true;
                }
                else
                {
                    if (I.locationType == CB!.LocType_In_Item)
                    {
                        Item item2 = Items!.Find(I.locationID)!;
                        if (!silent)
                        {
                            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTake_Person_Everyone_14076, PersonID, I!.ID, item2!.ID ));
                            of.StoryOutput = true;

                        }
                    }
                    else if (I.locationType == CB!.LocType_On_Item)
                    {
                        Item item2 = Items!.Find(I!.locationID!)!;
                        if (!silent)
                        {
                            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTake_Person_Everyone_14077, PersonID, I!.ID, item2!.ID ));
                            of.StoryOutput = true;
                        }
                    }
                    else if (I.locationType == CB!.LocType_Behind_Item)
                    {
                        Item item2 = Items!.Find(I!.locationID)!;
                        if (!silent)
                        {
                            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTake_Person_Everyone_14078, PersonID, I!.ID, item2!.ID ));
                            of.StoryOutput = true;
                        }
                    }
                    else if (I.locationType == CB!.LocType_Below_Item)
                    {
                        Item item2 = Items!.Find(I.locationID)!;
                        if (!silent)
                        {
                            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTake_Person_Everyone_14079, PersonID, I!.ID, item2!.ID ));
                            of.StoryOutput = true;
                        }
                    }
                    else if (I.locationType == CB!.LocType_Beside_Item)
                    {
                        Item item2 = Items!.Find(I.locationID)!;
                        if (!silent)
                        {
                            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTake_Person_Everyone_14080, PersonID, I!.ID, item2!.ID ));
                            of.StoryOutput = true;
                        }
                    }
                    else
                    {
                        if (!silent)
                        {
                            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTake_Person_Everyone_14081, PersonID, I!.ID ));
                            of.StoryOutput = true;
                        }
                    }
                    Items!.TransferItem(I!.ID, CB!.LocType_Person, PersonID!.ID);
                    I.IsBackground = false;
                    I.IsHidden = false;
                    success = true;
                    of.Success = true;
                    of.Action = true;
                    of.Handled = true;
                    // I.IsHidden = false;
                }
            }
            else
            {
                if (!silent)
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTake_Person_Everyone_14082, PersonID, PersonID, PersonID ));
                of.Success = true;
            }
            return (success);

        }

        public virtual bool  EnsureTake( Item I, Person PersonID, bool silent = false )
        {
            OrderFeedback of = new OrderFeedback();

            if (Items!.IsItemInv(I) == true)
                return true;
            else
            {
                return ProcessTake(I, PersonID, of, silent);
            }
        }

        public virtual bool  ProcessTakeP(Person? P, Person? PersonID, OrderFeedback of )
        {
            bool success = false;
            if (Persons!.IsPersonHere(P, Co.Range_Here))
            {
                if (P!.CanBeTaken == false)
                {
                    AdvGame!.StoryOutput( Helper.Insert(loca.OrderFeedback_ProcessTakeP_14083, PersonID!, P ));
                    of.FeedbackOutput = true;

                    success = true;
                }
                else if ((P.locationType == CB!.LocType_Person) && (P.locationID == PersonID!.ID))
                {
                    AdvGame!.StoryOutput(  Helper.Insert(loca.OrderFeedback_ProcessTakeP_14084, PersonID!, P ));
                    of.FeedbackOutput = true;
                    success = true;
                }
                else
                {
                    if (P.locationType == CB!.LocType_In_Item)
                    {
                        Item item2 = Items!.Find(P.locationID)!;
                        AdvGame!.StoryOutput(Persons!.Find(PersonID!)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTakeP_Person_Everyone_14085, PersonID!, P, item2!.ID ));
                        of.StoryOutput = true;
                    }
                    else if (P.locationType == CB!.LocType_On_Item)
                    {
                        Item item2 = Items!.Find(P.locationID)!;
                        AdvGame!.StoryOutput(Persons!.Find(PersonID!)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTakeP_Person_Everyone_14086, PersonID!, P, item2!.ID ));
                        of.StoryOutput = true;
                    }
                    else if (P.locationType == CB!.LocType_Behind_Item)
                    {
                        Item item2 = Items!.Find(P.locationID)!;
                        AdvGame!.StoryOutput(Persons!.Find(PersonID!)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTakeP_Person_Everyone_14087, PersonID!, P, item2!.ID ));
                        of.StoryOutput = true;
                    }
                    else if (P.locationType == CB!.LocType_Below_Item)
                    {
                        Item item2 = Items!.Find(P.locationID)!;
                        AdvGame!.StoryOutput(Persons!.Find(PersonID!)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTakeP_Person_Everyone_14088, PersonID!, P, item2!.ID ));
                        of.StoryOutput = true;
                    }
                    else if (P.locationType == CB!.LocType_Beside_Item)
                    {
                        Item item2 = Items!.Find(P.locationID)!;
                        AdvGame!.StoryOutput(Persons!.Find(PersonID!)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTakeP_Person_Everyone_14089, PersonID!, P, item2!.ID ));
                        of.StoryOutput = true;
                    }
                    else
                    {
                        AdvGame!.StoryOutput(Persons!.Find(PersonID!)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTakeP_Person_Everyone_14090, PersonID!, P ));
                        of.StoryOutput = true;
                    }
                    Persons!.TransferPerson(P!.ID, CB!.LocType_Person, PersonID!.ID);
                    success = true;
                    of.Success = true;
                    of.Action = true;
                    of.Handled = true;
                }
            }
            else
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID!)!.locationID!, CA!.Person_Everyone,  Helper.Insert(loca.OrderFeedback_ProcessTakeP_Person_Everyone_14091, PersonID!, PersonID! ));
                success = true;
                of.StoryOutput = true;
            }
            return (success);

        }


        public virtual bool  MCItem(Person PersonID, ParseTokenList PTL)
        {
            Item item1 = PTL.GetFirstItem()!;
            // return (AdvGame!.DoMCItem(item1!.ID));
            AdvGame!.DoMCItem(item1!.ID);
            return false;
        }

        public virtual bool  MCPerson(Person PersonID, ParseTokenList PTL)
        {
            Person person1 = PTL.GetFirstPerson()!;
            // return (AdvGame!.DoMCPerson(person1 ));
            AdvGame!.DoMCPerson(person1);
            return false;
        }
    }
}