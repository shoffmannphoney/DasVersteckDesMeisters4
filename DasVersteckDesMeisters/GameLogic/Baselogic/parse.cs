using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using System.Globalization;

using Phoney_MAUI.Model;
using Phoney_MAUI.Core;

namespace GameCore
{
    interface IParseToken
    {
    }

    [Serializable]


    public abstract class AbstractParseToken : IParseToken
    {
        public enum ptTypes
        {
            item,
            person,
            topic,
            verb,
            noun,
            adj,
            prep,
            pronoun,
            fill
        }

        public Object? O { get; set; }

        public int RangeInfo { get; set; }

        public int CaseVal { get; set; }
        public ptTypes PTType { get; set; }

        // public AbstractParseToken();
        // public abstract AbstractParseToken(IParseElement O, int RangeInfo);
    }

    [Serializable]

    public class ParseToken: AbstractParseToken
    {

        public ParseToken()
        {
        }

        public ParseToken( IParseElement O, int RangeInfo, int CaseVal = 2 )
        {
            this.O = O;
            this.RangeInfo = RangeInfo;
            this.CaseVal = CaseVal;
        }
    }
    [Serializable]

    public class ParseTokenList
    {
        public bool ConvenienceActionNotOpenFirst { get; set; }
        public bool ConvenienceActionNotExamineAfter { get; set; }
        [JsonIgnore]
        public GlobalData? GD
        {
            get => GlobalData.CurrentGlobalData;
            // set => GlobalData.CurrentGlobalData = value;
        }
        [JsonIgnore]
        public VerbList? V
        {
            get => GD!.Adventure!.Verbs;
            // set => GD!.Adventure!.Verbs = value;
        }

        // private VerbList? V { get; set; }
        [JsonIgnore]
        public PrepList? P
        {
            get => GD!.Adventure!.Preps;
            // set => GD!.Adventure!.Preps = value;
        }

        // private PrepList? P { get; set; }

        [JsonIgnore]
        public PronounList? Pro
        {
            get => GD!.Adventure!.Pronouns;
            // set => GD!.Adventure!.Pronouns = value;
        }
        // private PronounList? Pro { get; set; }
        [JsonIgnore]
        public NounList? N
        {
            get => GD!.Adventure!.Nouns;
            // set => GD!.Adventure!.Nouns = value;
        }
        [JsonIgnore]
        public AdjList? A
        {
            get => GD!.Adventure!.Adjs;
            // set => GD!.Adventure!.Adjs = value;
        }

        // private NounList? N { get; set; }

        // private AdjList? A { get; set; }

        [JsonIgnore]
        public FillList? F
        {
            get => GD!.Adventure!.Fills;
            // set => GD!.Adventure!.Fills = value;
        }
        // private FillList? F { get; set; }

        [JsonIgnore]
        public ItemQueue? IQ
        {
            get => GD!.Adventure!.ItemQueue;
            // set => GD!.Adventure!.ItemQueue = value;
        }
        // public ItemQueue? IQ { get; set; }


        public IList<ParseToken>? PList { get; set; }

        private bool techOrder;


        public bool TechOrder
        {
            get { return techOrder; }
            set { techOrder = value; }
        }

        public int Count()
        {
            return (PList!.Count);
        }


        public ParseTokenList? Clone()
        {
            ParseTokenList ptlDest = new ParseTokenList();

            ptlDest.PList = new List<ParseToken> ( this!.PList!);

            return ptlDest;
        }

        public void Insert( int Index, ParseToken PT  )
        {
            PList!.Insert(Index, PT);
        }

        public void RemoveAt(int Index )
        {
            PList!.RemoveAt(Index);
        }

        public ParseToken? Index( int Index)
        {
            /*
            if ( Index < PList.Count ) 
                return PList[Index];
            else
                return null;
            */
            try 
            {
                return PList![Index]!;
            }
            catch 
            {
                return null;
            }

        }

        public bool VarietyCheckItem( int Index )
        {
            bool ret = true;

            for( int i = Index +1; i <= Index + PList![Index]!.RangeInfo; i++ )
            {
                if (PList[i]!.O!.GetType() != typeof(Item))
                { 
                    ret = false;
                    break; 
                }
            }
            return ret;
        }

        public bool VarietyCheckPerson(int Index)
        {
            bool ret = true;
            for (int i = Index + 1; i <= Index + PList![Index].RangeInfo; i++)
            {
                if (PList[i]!.O!.GetType() != typeof(Person))
                {
                    ret = false;
                    break;
                }
            }

            return ret;
        }

        public bool VarietyCheckTopic(int Index)
        {
            bool ret = true;
            for (int i = Index + 1; i <= Index + PList![Index].RangeInfo; i++)
            {
                if (PList![i].O!.GetType()! != typeof(Topic))
                {
                    ret = false;
                    break;
                }
            }

            return ret;
        }


        public ParseTokenList()
        {
            PList = new List<ParseToken>();
            // this.V = V;
            // this.P = P;
            // this.Pro = Pro;
            // this.N = N;
            // this.A = A;
            // this.F = F;
            // this.IQ = IQ;
        }

        public void SetParseTokenList(VerbList? V, PrepList? P, PronounList? Pro, NounList? N, AdjList? A, FillList? F,
            ItemQueue? IQ)
        {
            // this.V = V;
            // this.P = P;
            // this.Pro = Pro;
            // this.N = N;
            // this.A = A;
            // this.F = F;
            // this.IQ = IQ;

         }

        public void AddVerb(Verb? VerbID)
        {
            if (VerbID == null) return;

            ParseToken pt = new ParseToken();

            if (PList == null)
            {
                PList = new List<ParseToken>();
            }

            pt.PTType = ParseToken.ptTypes.verb;
            pt.O = V!.Find(VerbID);
            PList.Add(pt);
        }

        public void AddNothing(int Val)
        {
            ParseToken pt = new ParseToken();

            if (PList == null)
            {
                PList = new List<ParseToken>();
            }

            Nothing N = new Nothing(Val, loca.ParseTokenList_AddNothing_16222 );
            N.ID = Val;
            pt.O = N;
            PList.Add(pt);
        }

        public void AddPrep(Prep? prepID)
        {
            ParseToken pt = new ParseToken();
            if (PList == null)
            {
                PList = new List<ParseToken>();
            }
            pt.PTType = ParseToken.ptTypes.prep;
            pt.O = P!.Find(prepID!.Name);
            PList.Add(pt);
        }


        public void AddItem()
        {
            this.AddItemRange( Co.Range_Here);
        }

        public void AddItem( Item I)
        {
            this.AddItemRange(Co.Range_Here);
            this.PList![this.PList!.Count - 1].O = I;
        }

        public void AddPerson()
        {
            this.AddPersonRange(Co.Range_Here);
        }

        public void AddPerson(Person P)
        {
            this.AddItemRange(Co.Range_Here);
            this.PList![this.PList!.Count - 1].O = P;
        }

        public void AddTopic()
        {
            this.AddTopicRange(Co.Range_Here);
        }

        public void AddTopic(Topic Tx)
        {
            this.AddTopicRange(Co.Range_Here);
            this.PList![this.PList!.Count - 1].O = Tx;
        }

        public void AddItemRange( int Range)
        {
            ParseToken pt = new ParseToken();
            if (PList == null)
            {
                PList = new List<ParseToken>();
            }
            pt.O = new Item();
            pt.RangeInfo = Range;
            pt.PTType = AbstractParseToken.ptTypes.item;
            PList.Add(pt);
        }

        public void AddPersonRange( int Range )
        {
            ParseToken pt = new ParseToken();
            if (PList == null)
            {
                PList = new List<ParseToken>();
            }
            pt.O = new Person();
            pt.RangeInfo = Range;
            pt.PTType = AbstractParseToken.ptTypes.person;
            PList.Add(pt);
        }

        public void AddTopicRange( int Range)
        {
            ParseToken pt = new ParseToken();
            if (PList == null)
            {
                PList = new List<ParseToken>();
            }
            pt.O = new Topic();
            pt.RangeInfo = Range;
            pt.PTType = AbstractParseToken.ptTypes.topic;
            PList.Add(pt);
        }

        public void AddNoun(int NounID )
        {
            ParseToken pt = new ParseToken();
            if (PList == null)
            {
                PList = new List<ParseToken>();
            }
            pt.O = N!.Find(NounID);
            pt.PTType = AbstractParseToken.ptTypes.noun;
            PList.Add(pt);
        }

        public void AddFill(int FillID)
        {
            ParseToken pt = new ParseToken();
            if (PList == null)
            {
                PList = new List<ParseToken>();
            }
            pt.O = F!.Find(FillID);
            pt.PTType = AbstractParseToken.ptTypes.fill;
            PList.Add(pt);
        }

        public void AddPronoun(int PronounID)
        {
            ParseToken pt = new ParseToken();
            if (PList == null)
            {
                PList = new List<ParseToken>();
            }
            pt.O = Pro!.Find(PronounID);
            pt.PTType = AbstractParseToken.ptTypes.pronoun;
            PList.Add(pt);
        }

        public void AddAdj(int AdjID)
        {
            ParseToken pt = new ParseToken();
            if (PList == null)
            {
                PList = new List<ParseToken>();
            }
            pt.O = A!.Find(AdjID);
            pt.PTType = AbstractParseToken.ptTypes.adj;
            PList.Add(pt);
        }


        public Person? GetFirstPerson()
        {
            int i;
            Person? person = null;

            for (i = 0; i < this.Count(); i++)
            {
                if (this.Index(i)!.O!.GetType() == typeof(Person))
                {
                    person = (Person)this.Index(i)!.O!;
                }
                if (person != null) break;
            }
            return (person);
        }

        public Person? GetSecondPerson()
        {
            int i;
            int ct = 0;
            Person? person = null;

            for (i = 0; i < this.Count(); i++)
            {
                if (this.Index(i)!.O!.GetType() == typeof(Person))
                {
                    ct++;
                    if (ct == 2)
                    {
                        person = (Person)this.Index(i)!.O!;
                    }
                }
                if (person != null) break;
            }
            return (person);
        }

        public Person? GetThirdPerson()
        {
            int i;
            int ct = 0;
            Person? person = null;

            for (i = 0; i < this.Count(); i++)
            {
                if (this!.Index(i)!.O!.GetType() == typeof(Person))
                {
                    ct++;
                    if (ct == 3)
                    {
                        person = (Person)this.Index(i)!.O!;
                    }
                }
                if (person != null) break;
            }
            return (person);
        }

        public Item? GetFirstItem()
        {
            int i;
            Item? item = null;

            for (i = 0; i < this.Count(); i++)
            {
                if (this.Index(i)!.O!.GetType()! == typeof(Item))
                {
                    item = (Item)this.Index(i)!.O!;
                }
                if (item != null) break;
            }
            return (item);
        }

        public Item? GetSecondItem()
        {
            int i;
            int ct = 0;
            Item? item = null;

            for (i = 0; i < this.Count(); i++)
            {
                if (this.Index(i)!.O!.GetType()! == typeof(Item))
                {
                    ct++;
                    if (ct == 2)
                    {
                        item = (Item)this.Index(i)!.O!;
                    }
                }
                if (item != null) break;
            }
            return (item);
        }

        public Item? GetThirdItem()
        {
            int i;
            int ct = 0;
            Item? item = null;

            for (i = 0; i < this.Count(); i++)
            {
                if (this.Index(i)!.O!.GetType()! == typeof(Item))
                {
                    ct++;
                    if (ct == 3)
                    {
                        item = (Item)this.Index(i)!.O!;
                    }
                }
                if (item != null) break;
            }
            return (item);
        }


        public Topic? GetFirstTopic()
        {
            int i;
            Topic? topic = null;

            for (i = 0; i < this.Count(); i++)
            {
                if (this.Index(i)!.O!.GetType()! == typeof(Topic))
                {
                    topic = (Topic)this.Index(i)!.O!;
                }
                if (topic != null) break;
            }
            return (topic);
        }

        public Topic? GetSecondTopic()
        {
            int i;
            int ct = 0;
            Topic? topic = null;

            for (i = 0; i < this.Count(); i++)
            {
                if (this.Index(i)!.O!.GetType()! == typeof(Topic))
                {
                    ct++;
                    if (ct == 2)
                    {
                        topic = (Topic)this.Index(i)!.O!;
                    }
                }
                if (topic != null) break;
            }
            return (topic);
        }

        public Topic? GetThirdTopic()
        {
            int i;
            int ct = 0;
            Topic? topic = null;

            for (i = 0; i < this.Count(); i++)
            {
                if (this.Index(i)!.O!.GetType() == typeof(Topic))
                {
                    ct++;
                    if (ct == 3)
                    {
                        topic = (Topic)this.Index(i)!.O!;
                    }
                }
                if (topic != null) break;
            }
            return (topic);
        }
    }
    [Serializable]

    public class ParseList
    {

        private VerbList V { get; set; }


        public IList<Object> PList { get; set; }


        public ParseList( VerbList V )
        {
            PList = new List<Object>();
            this.V = V;
        }

        public void AddVerb( int VerbID )
        {
            if (PList == null)
            {
                PList = new List<Object>();
            }
            PList.Add( V.Find( VerbID )! );
        }
    }
    [Serializable]

    public class ParseLine
    {
        [JsonIgnore]

        private Del? _parseMethod;

        public string? _parseMethodName;

        public int ParseID { get; set; }

        public ParseTokenList? PTL { get; set; }

        [JsonIgnore]

        public Del? ParseMethod 
        {
            //                 this.controller = (DelAdvObject)Delegate.CreateDelegate(typeof(DelAdvObject), AdvGame, this.controllerName, false);

            get { return _parseMethod; }
            set { _parseMethod = value; _parseMethodName = value?.Method.Name;  }
        } //  (MainWindow MWx, List<ParseToken> Adv_PT);


        public bool CollectIt { get; set; }



        public static ParseLine Copy( ParseLine plSource )
        {
            ParseLine plDest = new ParseLine(plSource.ParseID, null, plSource.ParseMethod);
            plDest.PTL = plSource.PTL!.Clone( );
            plDest.CollectIt = plSource.CollectIt;

            plDest.PTL!.PList = new List<ParseToken>();
            foreach( ParseToken pt in plSource.PTL!.PList! )
            {
                plDest.PTL!.PList.Add(new ParseToken());
                plDest.PTL!.PList[plDest.PTL!.PList.Count - 1].O = pt.O;
                plDest.PTL!.PList[plDest.PTL!.PList.Count - 1].RangeInfo = pt.RangeInfo;
            }
            // plSource.PTL!.PList);
            return (plDest);
        }

        public void SetParseMethodByString( Object o )
        {
            this._parseMethod = (Del)Delegate.CreateDelegate(typeof(Del), o, this._parseMethodName!, false);
        }

        public ParseLine(int ParseID2, ParseTokenList? PTL, Del? D, bool collectIt = true)
        {
            this.PTL = PTL; 

            /*
            foreach (ParseToken element in PT2)
            {
                PT.Add(new ParseToken(element.WordType, element.WordID));
            }
            */
            ParseID = ParseID2;
            ParseMethod = D;
            CollectIt = collectIt;
        }
    }
    [Serializable]


    public class ParseLineList
    {

        public List<ParseLine>? List { get; set; }


        public ParseLineList()
        {

        }

        public void Add(ParseLine PL )
        {
            if (List == null)
            {
                List = new List<ParseLine>();
            }
            // new this.GetType().GetConstructor();
            List.Add(PL);
        }


        public ParseLine CloneListEntry( int pllCt )
        {
            ParseLine pl = ParseLine.Copy(this.List![pllCt]);
            return pl;
        }

    }


    interface IParse
    {

    }
    [Serializable]

    public class Parse: IParse
    {
        // private MainWindow MW { get; }

        [JsonIgnore]
        public GlobalData? GD
        {
            get => GlobalData.CurrentGlobalData;
            // set => GlobalData.CurrentGlobalData = value;
        }
        [JsonIgnore]
        public VerbList? Verbs
        {
            get => GD!.Adventure!.Verbs;
            // set => GD!.Adventure!.Verbs = value;
        }
        // private VerbList? Verbs { get; set; }

        [JsonIgnore]
        public PrepList? Preps
        {
            get => GD!.Adventure!.Preps;
            // set => GD!.Adventure!.Preps = value;
        }
        // private PrepList? Preps { get; set; }

        [JsonIgnore]
        public PronounList? Pronouns
        {
            get => GD!.Adventure!.Pronouns;
            // set => GD!.Adventure!.Pronouns = value;
        }
        // private PronounList? Pronouns { get; set; }

        [JsonIgnore]
        public NounList? Nouns
        {
            get => GD!.Adventure!.Nouns;
            // set => GD!.Adventure!.Nouns = value;
        }
        // private NounList? Nouns { get; set; }

        [JsonIgnore]
        public AdjList? Adjs
        {
            get => GD!.Adventure!.Adjs;
            // set => GD!.Adventure!.Adjs = value;
        }
        // private AdjList? Adjs { get; set; }

        [JsonIgnore]
        public FillList? Fills
        {
            get => GD!.Adventure!.Fills;
            // set => GD!.Adventure!.Fills = value;
        }
        // private FillList? Fills { get; set; }

        [JsonIgnore]
        public TopicList? Topics
        {
            get => GD!.Adventure!.Topics;
            // set => GD!.Adventure!.Topics = value;
        }
        // private TopicList? Topics { get; set; }

        private ParseLineList? PLL { get; set; }

        [JsonIgnore]
        public PersonList? Persons
        {
            get => GD!.Adventure!.Persons;
            // set => GD!.Adventure!.Persons = value;
        }
        //private PersonList? Persons { get; set; }

        [JsonIgnore]
        public ItemQueue? ItemQueue
        {
            get => GD!.Adventure!.ItemQueue;
            // set => GD!.Adventure!.ItemQueue = value;
        }
        // private ItemQueue? ItemQueue { get; set; }

        [JsonIgnore]
        public ItemList? Items
        {
            get => GD!.Adventure!.Items;
            // set => GD!.Adventure!.Items = value;
        }
        // private ItemList? Items { get; set; }
        [JsonIgnore]
        public Adv? AdvGame
        {
            get => GD!.Adventure;
            // set => GD!.Adventure = value;
        }
        // [JsonIgnore][NonSerialized]  private Adv? AdvGame;

        ParseTokenList? tPTL { get; set; }
        ParseTokenList? tPTLNew { get; set; }
        [JsonIgnore][NonSerialized] DelParseLineList? cbSuccess;
        string? tErrorText;

        public string? LatestParseResult;

        public ParseTokenList? latestPTL;

        public ParseLineList? latestPTLSignatures;
        ParseLineList? tptlSignatures;

        string? LastParseLine { get; set; }
        string? LastParseLineNew { get; set; }


        public string? StringVersion(ParseTokenList ptl)
        {

            string? s = "";


            foreach (ParseToken pt in ptl.PList!)
            {
                if (pt.O?.GetType() == typeof(Verb))
                {
                    s = s + (pt.O as Verb)!.Name + " ";
                }
                else if (pt.O?.GetType() == typeof(Prep))
                {
                    s = s + (pt.O as Prep)!.Name + " ";
                }
                else if (pt.O?.GetType() == typeof(Pronoun))
                {
                    s = s + (pt.O as Pronoun)!.Name + " ";
                }
                else if (pt.O?.GetType() == typeof(Fill))
                {
                    s = s + (pt.O as Fill)!.Name + " ";
                }
                else if (pt.O?.GetType() == typeof(Noun))
                {
                    s = s + (pt.O as Noun)!.Name + " ";
                }
                else if (pt.O?.GetType() == typeof(Adj))
                {
                    s = s + (pt.O as Adj)!.Name + " ";
                }
                else if (pt.O?.GetType() == typeof(Item))
                {
                    int caseVal = pt.CaseVal;

                    if (caseVal == 0)
                        caseVal = Co.CASE_NOM;
                    s = s + Items!.GetName((pt.O as Item)!.ID, caseVal, AdvGame.CurrentNouns) + " ";
                }
                else if (pt.O?.GetType() == typeof(Person))
                {
                    s = s + Persons!.GetPersonName((pt.O as Person), pt.CaseVal, AdvGame.CurrentNouns) + " ";
                }
            }

            return s;
        }


        public Parse(Adv? Adventure, ParseLineList? PLL, VerbList? V, PrepList? P, PronounList? Pro, NounList? N, AdjList? A, FillList? F, ItemList? Items, PersonList? Persons, TopicList? Topics, ItemQueue? IQ)
        {
            // PList = new List<ParseToken>();
            this.PLL = PLL;
            // this.AdvGame = Adventure;
            // this.Verbs = V;
            // this.Preps = P;
            // this.Pronouns = Pro;
            // this.Nouns = N;
            // this.Adjs = A;
            // this.Fills = F;
            // this.Persons = Persons;
            // this.Items = Items;
            // this.Topics = Topics;
            // this.ItemQueue= IQ;
            // this.MW = MW;

        }


        public void SetAdv(Adv Adventure)
        {
            // this.AdvGame = Adventure;
        }

        public bool SetObjectReferences(ItemList Items, PersonList Persons, NounList Nouns, AdjList Adjs, VerbList Verbs, PrepList Preps, FillList Fills, TopicList Topics, ParseLineList PLL)
        {
            // this.Items = Items;
            // this.Persons = Persons;
            // this.Nouns = Nouns;
            // this.Adjs = Adjs;
            // this.Verbs = Verbs;
            // this.Preps = Preps;
            // this.Fills = Fills;
            // this.Topics = Topics;
            // this.PLL = PLL;
            return true;
        }


        private bool StringToParseTokens(string s, ParseTokenList PTL, ref string ErrorText)
        {
            string[] separatedWords;
            char[] charSeparators = new char[] { ',', ' ', '.', ';' };
            separatedWords = s.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            bool found = false;
            Item? itemsFound = null;
            int personsFound = 0;
            int topicsFound = 0;
            ErrorText = "";

            foreach (string element in separatedWords)
            {
                found = false;
                if (!found)
                {
                    Noun n = Nouns!.Find(element)!;
                    if (n != null)
                    {
                        PTL!.AddNoun(n.ID);
                        found = true;
                    }
                }
                if (!found)
                {
                    Adj a = Adjs!.FindAdj(element)!;
                    if (a != null)
                    {
                        PTL!.AddAdj(a.ID);
                        found = true;
                    }
                }
                if (!found)
                {
                    Verb v = Verbs!.Find(element)!;
                    if (v != null)
                    {
                        PTL!.AddVerb(v);
                        found = true;
                    }
                }
                if (!found)
                {
                    Prep p = Preps!.Find(element)!;
                    if (p != null)
                    {
                        PTL!.AddPrep(p);
                        found = true;
                    }
                }
                if (!found)
                {
                    Fill f = Fills!.Find(element)!;
                    if (f != null)
                    {
                        PTL!.AddFill(f.ID);
                        found = true;
                    }
                }
                if (!found)
                {
                    ErrorText = String.Format( loca.Parse_StringToParseTokens_16223, element);

                    break;
                }
            }
            // Adj + Nouns zu Items
            if (found)
            {
                int i, j;

                for (i = 0; i < PTL!.Count(); i++)
                {
                    
                    List<Item> possibleItems = new List<Item>();
                    List<Person> possiblePersons = new List<Person>();
                    List<Topic> possibleTopics = new List<Topic>();

                    // Hier wird ein Item eingeleitet
                    if ((PTL!.Index(i)!.O!.GetType()! == typeof(Adj)) || (PTL!.Index(i)!.O!.GetType()! == typeof(Noun)))
                    {
                        for (j = i + 1; j < PTL!.Count(); j++)
                        {
                            // Hier wird ein Item eingeleitet
                            if ((PTL!.Index(j)!.O!.GetType()! != typeof(Adj)) && (PTL!.Index(j)!.O!.GetType() != typeof(Noun)))
                                break;

                        }


                        // soviel kann man nun festhalten: Das Item reicht von i bis j-1
                        /*
                        for (int li = 0; li < Items!.List.Count; li++)
                        {
                            int k, l;
                            bool identical = false;
                            bool foundItem = Items!.IsItemHere(Items!.List[li], Co.Range_Active);

                            if (foundItem)
                            {
                                // jetzt werden alle Einträge abgeglichen
                                for (k = i; k < j; k++)
                                {
                                    identical = false;
                                    if (PTL!.Index(k).O.GetType() == typeof(Noun))
                                    {
                                        for (l = 0; l < Items!.List[li].Names.Count; l++)
                                        {
                                            if (((Noun)PTL!.Index(k).O).ID == Items!.List[li].Names[l].ID)
                                            {
                                                identical = true;
                                            }
                                        }
                                        for (l = 0; l < Items!.List[li].SynNames!.Count; l++)
                                        {
                                            if (((Noun)PTL!.Index(k).O).ID == Items!.List[li].SynNames[l].ID)
                                            {
                                                identical = true;
                                            }
                                        }
                                    }
                                    else if (PTL!.Index(k).O.GetType() == typeof(Adj))
                                    {
                                        for (l = 0; l < Items!.List[li].Adjectives.Count; l++)
                                        {
                                            if (((Adj)PTL!.Index(k).O).ID == Items!.List[li].Adjectives[l].ID)
                                            {
                                                identical = true;
                                            }
                                        }
                                        for (l = 0; l < Items!.List[li].SynAdjectives.Count; l++)
                                        {
                                            if (((Adj)PTL!.Index(k).O).ID == Items!.List[li].SynAdjectives[l].ID)
                                            {
                                                identical = true;
                                            }
                                        }
                                    }
                                    if (!identical) break;
                                }
                            }
                            // Ja, dieses Item könnte es sein. 
                            if (identical)
                            {
                                possibleItems!.Add(Items!.List[li]);
                                itemsFound = li;
                            }
                        }
                        */
                        foreach (Item liItem in Items!.List!.Values)
                        {
                            int k, l;
                            bool identical = false;
                            bool foundItem = Items!.IsItemHere(liItem, Co.Range_Active);

                            if (foundItem)
                            {
                                // jetzt werden alle Einträge abgeglichen
                                for (k = i; k < j; k++)
                                {
                                    identical = false;
                                    if (PTL!.Index(k)!.O!.GetType() == typeof(Noun))
                                    {
                                        for (l = 0; l < liItem!.Names!.Count; l++)
                                        {
                                            if (((Noun)PTL!.Index(k)!.O!)!.ID! == liItem!.Names![l]!.ID)
                                            {
                                                identical = true;
                                            }
                                        }
                                        for (l = 0; l < liItem.SynNames!.Count; l++)
                                        {
                                            if (((Noun)PTL!.Index(k)!.O!)!.ID! == liItem!.SynNames![l]!.ID)
                                            {
                                                identical = true;
                                            }
                                        }
                                    }
                                    else if (PTL!.Index(k)!.O!.GetType() == typeof(Adj))
                                    {
                                        for (l = 0; l < liItem!.Adjectives!.Count; l++)
                                        {
                                            if (((Adj)PTL!.Index(k)!.O!)!.ID! == liItem!.Adjectives![l]!.ID)
                                            {
                                                identical = true;
                                            }
                                        }
                                        for (l = 0; l < liItem!.SynAdjectives!.Count; l++)
                                        {
                                            if (((Adj)PTL!.Index(k)!.O!)!.ID! == liItem!.SynAdjectives![l]!.ID!)
                                            {
                                                identical = true;
                                            }
                                        }
                                    }
                                    if (!identical) break;
                                }
                            }
                            // Ja, dieses Item könnte es sein. 
                            if (identical)
                            {
                                possibleItems!.Add(liItem);
                                itemsFound = liItem;
                            }

                        }


                        // Jetzt suchen wir noch nach Personen
                        for (int li = 0; li < Persons!.List!.Count; li++)
                        {
                            int k, l;
                            bool identical = false;
                            bool foundPerson = Persons!.IsPersonHere(Persons!.List[li], Co.Range_Active);

                            if (foundPerson)
                            {
                                // jetzt werden alle Einträge abgeglichen
                                for (k = i; k < j; k++)
                                {
                                    identical = false;
                                    if (PTL!.Index(k)!.O!.GetType() == typeof(Noun))
                                    {
                                        for (l = 0; l < Persons!.List![li]!.Names!.Count; l++)
                                        {
                                            if (((Noun)PTL!.Index(k)!.O!)!.ID! == Persons!.List![li!]!.Names![l!]!.ID!)
                                            {
                                                identical = true;
                                            }
                                        }
                                        for (l = 0; l < Persons!.List[li].SynNames!.Count; l++)
                                        {
                                            if (((Noun)PTL!.Index(k)!.O!)!.ID! == Persons!.List![li!]!.SynNames![l!]!.ID!)
                                            {
                                                identical = true;
                                            }
                                        }
                                    }
                                    else if (PTL!.Index(k)!.O!.GetType() == typeof(Adj))
                                    {
                                        for (l = 0; l < Persons!.List[li]!.Adjectives!.Count; l++)
                                        {
                                            if (((Adj)PTL!.Index(k)!.O!)!.ID! == Persons!.List![li!].Adjectives![l]!.ID!)
                                            {
                                                identical = true;
                                            }
                                        }
                                        for (l = 0; l < Persons!.List[li].SynAdjectives!.Count; l++)
                                        {
                                            if (((Adj)PTL!.Index(k)!.O!)!.ID == Persons!.List![li]!.SynAdjectives![l]!.ID!)
                                            {
                                                identical = true;
                                            }
                                        }
                                    }
                                    if (!identical) break;
                                }
                            }
                            // Ja, dieses Item könnte es sein. 
                            if (identical)
                            {
                                possiblePersons!.Add(Persons!.List[li]);
                                personsFound = li;
                            }
                        }
                        // Jetzt suchen wir noch nach Topics
                        for (int li = 0; li < Topics!.List!.Count!; li++)
                        {
                            int k, l;
                            bool identical = false;
                            bool foundTopic = Topics.IsTopicHere(Topics.List[li], Co.Range_Active);

                            if (foundTopic)
                            {
                                // jetzt werden alle Einträge abgeglichen
                                for (k = i; k < j; k++)
                                {
                                    identical = false;
                                    if (PTL!.Index(k)!.O!.GetType() == typeof(Noun))
                                    {
                                        for (l = 0; l < Topics.List[li].Names!.Count!; l++)
                                        {
                                            if (((Noun)PTL!.Index(k)!.O!)!.ID! == Topics!.List![li]!.Names![l]!.ID!)
                                            {
                                                identical = true;
                                            }
                                        }
                                        for (l = 0; l < Topics.List[li].SynNames!.Count; l++)
                                        {
                                            if (((Noun)PTL!.Index(k)!.O!)!.ID! == Topics!.List[li]!.SynNames![l]!.ID!)
                                            {
                                                identical = true;
                                            }
                                        }
                                    }
                                    else if (PTL!.Index(k)!.O!.GetType() == typeof(Adj))
                                    {
                                        for (l = 0; l < Topics.List[li].Adjectives!.Count!; l++)
                                        {
                                            if (((Adj)PTL!.Index(k)!.O!)!.ID == Topics!.List[li]!.Adjectives![l]!.ID)
                                            {
                                                identical = true;
                                            }
                                        }
                                        for (l = 0; l < Topics.List[li].SynAdjectives!.Count!; l++)
                                        {
                                            if (((Adj)PTL!.Index(k)!.O!)!.ID == Topics.List[li].SynAdjectives![l]!.ID)
                                            {
                                                identical = true;
                                            }
                                        }
                                    }
                                    if (!identical) break;
                                }
                            }
                            // Ja, dieses Item könnte es sein. 
                            if (identical)
                            {
                                possibleTopics.Add(Topics.List[li]);
                                topicsFound = li;
                            }
                        }

                        int itemPersonTopicCount = possibleItems!.Count + possiblePersons!.Count + possibleTopics.Count;
                        if (itemPersonTopicCount == 0)
                        {
                            ErrorText = loca.Parse_StringToParseTokens_16224;
                            found = false;
                        }
                        else if (itemPersonTopicCount >= 2)
                        {
                            int l = i;
                            int ct = 0;
                            PTL!.Insert(l++, new ParseToken((IParseElement)new Variety(), Co.Range_Overall));
                            PTL!.Index(l - 1)!.RangeInfo = itemPersonTopicCount;

                            ct = possibleItems!.Count;
                            while (ct > 0)
                            {
                                ct--;
                                PTL!.Insert(l++, new ParseToken(Items!.List[Items!.GetItemIx(possibleItems[ct].ID)], Co.Range_Overall));
                                // ((Item)PTL!.Index(l - 1).O).ID = PossibleItems[Ct].ID;
                            }
                            ct = possiblePersons!.Count;
                            while (ct > 0)
                            {
                                ct--;
                                PTL!.Insert(l++, new ParseToken((IParseElement)Persons!.List[Persons!.GetPersonIx(possiblePersons[ct].ID)], Co.Range_Overall));
                            }
                            ct = possibleTopics.Count;
                            while (ct > 0)
                            {
                                ct--;
                                PTL!.Insert(l++, new ParseToken((IParseElement)Topics.List[Topics.GetTopicIx(possibleTopics[ct].ID)], Co.Range_Overall));
                            }
                            found = true;
                            for (int k = i + itemPersonTopicCount; k < j + itemPersonTopicCount; k++)
                            {
                                PTL!.RemoveAt(l);
                            }
                        }
                        else
                        {
                            // Keine Ahnung, wofür dieser Codeblock gut ist
                            if (possibleItems!.Count == 1)
                            {
                                PTL!.Insert(i, new ParseToken((IParseElement)itemsFound!, Co.Range_Overall)!);
                                for (int k = i; k < j; k++)
                                {
                                    PTL!.RemoveAt(i + 1);
                                }
                            }
                            else if (possibleTopics.Count == 1)
                            {
                                PTL!.Insert(i, new ParseToken((IParseElement)Topics.List[topicsFound], Co.Range_Overall));
                                for (int k = i; k < j; k++)
                                {
                                    PTL!.RemoveAt(i + 1);
                                }
                            }
                            else
                            {
                                PTL!.Insert(i, new ParseToken((IParseElement)Persons!.List[personsFound], Co.Range_Overall));
                                for (int k = i; k < j; k++)
                                {
                                    PTL!.RemoveAt(i + 1);
                                }

                            }
                            found = true;
                        }
                    }
                    else if (PTL!.Index(i)!.O!.GetType() == typeof(Fill))
                    {
                        PTL!.RemoveAt(i);
                        i--;
                    }

                    if (!found) break;
                }
            }
            return (found);
        }


        private int CountAmbiguousEntries(ParseTokenList PTL)
        {
            int ctAmbi = 0;
            for (int i = 0; i < PTL!.Count(); i++)
            {
                if (PTL!.Index(i)!.O!.GetType() == typeof(Variety))
                    ctAmbi++;
            }
            return (ctAmbi);
        }



        private bool ValidParseToken(ParseToken PT, ParseToken PT2)
        {
            if (PT2 == null)
                return (false);

            if ((PT.O!.GetType() == typeof(Item)) && (PT2.O!.GetType() == typeof(Item)) && (PT2.RangeInfo == Co.Range_Here))
                return (Items!.IsItemHere((Item)PT.O, PT2.RangeInfo));
            if ((PT.O!.GetType() == typeof(Person)) && (PT2.O!.GetType() == typeof(Person)) && (PT2.RangeInfo == Co.Range_Here))
                return (Persons!.IsPersonHere((Person)PT.O, PT2.RangeInfo));
            if ((PT.O!.GetType() == typeof(Item)) && (PT2.O!.GetType() == typeof(Item)) && (PT2.RangeInfo == Co.Range_Active))
                return (((Item)PT.O).Active);
            if ((PT.O!.GetType() == typeof(Person)) && (PT2.O!.GetType() == typeof(Person)) && (PT2.RangeInfo == Co.Range_Active))
                return (((Person)PT.O).Active);
            if ((PT.O!.GetType() == typeof(Item)) && (PT2.O!.GetType() == typeof(Item)))
                return (true);
            if ((PT.O!.GetType() == typeof(Person)) && (PT2.O!.GetType() == typeof(Person)))
                return (true);
            /*
                        if ((PT.O.GetType() == typeof(Item)))
                            return (true);
                        if ((PT.O.GetType() == typeof(Person)))
                            return (true);
            */
            if ((PT.O.GetType() == typeof(Topic)) && (PT2.O!.GetType() == typeof(Topic)) && (PT2.RangeInfo == Co.Range_Active))
                return (((Topic)PT.O).Active);
            if ((PT.O.GetType() == typeof(Topic)))
                return (true);

            return (false);
        }

        private int CountAmbiguousEntryObjects(ParseTokenList PTL, int ParseID, int Ix)
        {
            int ct = 0;
            int parseIx = -1;

            for (int i = 0; i < PLL!.List!.Count!; i++)
            {
                if (PLL.List[i].ParseID == ParseID)
                {
                    parseIx = i;
                    break;
                }
            }
            if (parseIx >= 0)
            {
                int aObj = (PTL!.Index(Ix)!.RangeInfo + Ix + 1)!;
                // In der WordID ist die Anzahl an folgenden Objekten kodiert. 
                for (int i = Ix + 1; i < aObj; i++)
                {
                    ParseToken PT = PTL!.Index(i)!;

                    if (ValidParseToken(PT, PLL!.List![parseIx]!.PTL!.Index(Ix)!) == true)
                        ct++;
                }
            }

            if( ct >= 2)
            {

            }

            return (ct);
        }

        private int GetAmbiguousEntryObjectIx(ParseTokenList PTL, int ParseID, int Ix)
        {
            int ct = -1;
            int parseIx = -1;
            int i = 0;
            for (i = 0; i < PLL!.List!.Count!; i++)
            {
                if (PLL.List[i].ParseID == ParseID)
                {
                    parseIx = i;
                    break;
                }
            }

            if (parseIx >= 0)
            {
                int aObj = (PTL!.Index(Ix)!.RangeInfo + Ix + 1)!;
                // In der WordID ist die Anzahl an folgenden Objekten kodiert. 
                for (i = Ix + 1; i < aObj; i++)
                {
                    ParseToken pt = PTL!.Index(i)!;

                    // if (ValidParseToken(PT, PTL!.Index(ParseIx)) == true)
                    if (ValidParseToken(pt, PLL!.List![parseIx]!.PTL!.Index(Ix)!) == true)
                    {
                        ct = (i - Ix);
                        break;
                    }
                }
            }
            return (ct);
        }


        private int GetParseIxFromID(int ParseID)
        {
            int ix;

            for (ix = 0; ix < PLL!.List!.Count!; ix++)
            {
                if (PLL.List[ix].ParseID == ParseID)
                    break;
            }
            return (ix);
        }



        private bool RequestFirstAmbiguous(MCMenu MCM2, ParseTokenList PTL, int ParseID)
        {
            for (int i = 0; i < PTL!.Count(); i++)
            {
                if (PTL!.Index(i)!.O!.GetType() == typeof(Variety))
                {
                    // Erst mal durchzählen, wie viele in Frage kommende Objekte es gibt
                    int numItems = CountAmbiguousEntryObjects(PTL!, ParseID!, i);

                    // Fall 1: Es gibt überhaupt kein Item mehr. Damit ist die Suche gescheitert und die ganze ParseLine kann abgeschossen werden
                    if (numItems == 0)
                    {
                        AdvGame!.FeedbackOutput(AdvGame!.CA!.Person_Everyone!, loca.Parse_RequestFirstAmbiguous_Person_Everyone_16225);
                        AdvGame!.OutputExit(MCM2);
                        // Unklar, ob das so einfach geht. 
                        return (false);
                    }
                    else if (numItems == 1)
                    {
                        int Ix = GetAmbiguousEntryObjectIx(PTL, ParseID, i);

                        CallbackAmbiguous(MCM2, Ix + 1);
                    }
                    else
                    {
                        MCMenu mcM = AdvGame!.AdvMCMenu(AdvGame!.CA!.Person_I!, false, 1 + AdvGame.CB!.MCE_Choice_Off);
                        List<int> follower;
                        int count = PTL!.Index(i)!.RangeInfo!;
                        int idCt = 1;

                        // 1
                        follower = new List<int>();
                        follower.Add(-1);
                        mcM.Add(new MCMenuEntry(AdvGame.CB!.MCE_Text, null, loca.Parse_RequestFirstAmbiguous_Person_I_16226, idCt++, follower, null, 0, false, false, false, null, null));

                        // Jetzt wird geprüft, wie viele Objekte tatsächlich verfügbar sind
                        // Auch hier kann die Anzahl auf 0 oder 1 sinken, dann wird entsprechend kein Entscheidungsmenü aufgerufen.
                        for (int j = i + 1; j <= i + count; j++)
                        {
                            int ix = GetParseIxFromID(ParseID);
                            int wordType = PLL!.List![ix]!.PTL!.Index(i)!.RangeInfo!;
                            if ((PTL!.Index(j)!.O!.GetType() == typeof(Person)) && (!Persons!.IsPersonHere((Person)PTL!.Index(j)!.O!, wordType)))
                            {
                                PTL!.RemoveAt(j);
                                j--;
                                count--;
                                (PTL!.Index(i)!.RangeInfo)--;
                            }
                            else if ((PTL!.Index(j)!.O!.GetType() == typeof(Item)) && (!Items!.IsItemHere((Item)PTL!.Index(j)!.O!, wordType)))
                            {
                                PTL!.RemoveAt(j);
                                j--;
                                count--;
                                PTL!.Index(i)!.RangeInfo--;
                            }
                            else if ((PTL!.Index(j)!.O!.GetType() == typeof(Topic)) && (!Topics!.IsTopicHere((Topic)PTL!.Index(j)!.O!, wordType)))
                            {
                                PTL!.RemoveAt(j);
                                j--;
                                count--;
                                PTL!.Index(i)!.RangeInfo--;
                            }

                        }

                        // Fall 1: Es gibt überhaupt kein Item mehr. Damit ist die Suche gescheitert und die ganze ParseLine kann abgeschossen werden
                        if (count == 0)
                        {
                            AdvGame!.FeedbackOutput(AdvGame!.CA!.Person_Everyone!, loca.Parse_RequestFirstAmbiguous_Person_Everyone_16227);
                            AdvGame!.OutputExit(MCM2);
                            // Unklar, ob das so einfach geht. 
                            return (false);
                        }
                        else if (count == 1)
                        {
                            int Ix = GetAmbiguousEntryObjectIx(PTL, ParseID, i);

                            CallbackAmbiguous(MCM2, Ix + 1);
                        }
                        else
                        {
                            for (int j = i + 1; j <= i + count; j++)
                            {
                                int ix = GetParseIxFromID(ParseID);
                                int wordType = PLL!.List![ix].PTL!.Index(i)!.RangeInfo!;

                                // Schritt 1: Alle nicht sichtbaren Personen, Items und Topics werden aus der Liste geworfen
                                if ((PTL!.Index(j)!.O!.GetType() == typeof(Person)) && (Persons!.IsPersonHere((Person)PTL!.Index(j)!.O!, wordType)))
                                {
                                    follower = new List<int>();
                                    follower.Add(-1);
                                    mcM.Add(new MCMenuEntry(AdvGame!.CB!.MCE_Text, AdvGame!.CA!.Person_I, Persons!.GetPersonName(((Person)PTL!.Index(j)!.O!), Co.CASE_NOM, AdvGame.CurrentNouns), idCt++, follower, null, 0, false, false, false, null, null));
                                }
                                if ((PTL!.Index(j)!.O!.GetType() == typeof(Item)) && (Items!.IsItemHere((Item)PTL!.Index(j)!.O!, wordType)))
                                {
                                    follower = new List<int>();
                                    follower.Add(-1);
                                    mcM.Add(new MCMenuEntry(AdvGame!.CB!.MCE_Text, AdvGame.CA!.Person_I, Items!.GetName(((Item)PTL!.Index(j)!.O!).ID!, Co.CASE_NOM, AdvGame.CurrentNouns), idCt++, follower, null, 0, false, false, false, null, null));
                                }
                                if ((PTL!.Index(j)!.O!.GetType() == typeof(Topic)) && (Topics!.IsTopicHere((Topic)PTL!.Index(j)!.O!, wordType)))
                                {
                                    follower = new List<int>();
                                    follower.Add(-1);
                                    mcM.Add(new MCMenuEntry(AdvGame!.CB!.MCE_Text, AdvGame!.CA!.Person_I, Topics!.GetTopicName(((Topic)PTL!.Index(j)!.O!).ID!, Co.CASE_NOM, AdvGame.CurrentNouns), idCt++, follower, null, 0, false, false, false, null, null));
                                }
                            }
                            follower = new List<int>();
                            follower.Add(1);
                            for (int j = i + 1; j <= i + count; j++)
                            {
                                follower.Add(j - i + 1);

                            }
                            mcM.Add(new MCMenuEntry(AdvGame.CB!.MCE_Choice, null, "", 1 + AdvGame.CB!.MCE_Choice_Off, follower, null, 0, false, false, false, null, null));
                            mcM.MCS = mcM.MenuShow();
                            mcM.Set(0);
                            mcM.MCS.MCOutput(mcM, CallbackAmbiguous, false);
                            AdvGame.Orders!.temporaryMCMenu = mcM;
                            AdvGame.Orders!.persistentMCMenu = null;
                        }
                    }
                }
            }
            return true;
        }


        private bool CallbackAmbiguous(MCMenu MCM, int Selection)
        {
            bool found = false;

            // Selection = 1 ist immer die Titelzeile, die müssen wir abziehen
            Selection--;

            for (int i = 0; i < tPTL!.Count(); i++)
            {
                int removeCt = tPTL!.Index(i)!.RangeInfo + 1;

                if (tPTL!.Index(i)!.O!.GetType() == typeof(Variety))
                {
                    if (tPTL!.Index(i + Selection)!.O!.GetType() == typeof(Item))
                    {
                        tPTL!.Insert(i, new ParseToken((IParseElement)tPTL!.Index(i + Selection)!.O!, Co.Range_Here));
                    }
                    else if (tPTL!.Index(i + Selection)!.O!.GetType() == typeof(Person))
                    {
                        tPTL!.Insert(i, new ParseToken((IParseElement)tPTL!.Index(i + Selection)!.O!, Co.Range_Here));
                    }
                    else if (tPTL!.Index(i + Selection)!.O!.GetType() == typeof(Topic))
                    {
                        tPTL!.Insert(i, new ParseToken((IParseElement)tPTL!.Index(i + Selection)!.O!, Co.Range_Here));
                    }

                    while (removeCt > 0)
                    {
                        tPTL!.RemoveAt(i + 1);
                        removeCt--;
                    }
                    found = true;
                    break;
                }
            }

            if (found)
            {
                // Noch weitere unterschiedliche Items in der Liste?
                int parseID = FindInitialParseline(tPTL);

                if (CountAmbiguousEntries(tPTL) > 0)
                {
                    RequestFirstAmbiguous(MCM, tPTL, parseID);
                    found = false;
                }
                else
                {
                    AdvGame!.OutputExit(MCM);
                    found = FindFinalParseline(tPTL);
                }
            }
            return found;
        }



        private int FindInitialParseline(ParseTokenList PTL)
        {
            int i, j;
            int iPL;
            int found_PT;
            int found_PL = -1;
            int found_ParseID = -1;

#pragma warning disable CS0219 // Die Variable "found" ist zugewiesen, ihr Wert wird aber nie verwendet.
            bool found = true;
#pragma warning restore CS0219 // Die Variable "found" ist zugewiesen, ihr Wert wird aber nie verwendet.

            for (j = 0; j < PLL!.List!.Count!; j++)
            {
                found_PT = 0;
                for (i = 0, iPL = 0; i < PLL.List[j].PTL!.Count(); i++)
                {
                    /*
                    if (PLL.List[j].PTL!.Index(i)?.O.GetType() == typeof(Verb))
                    {
                        Verb v = (Verb)PLL.List[j].PTL!.Index(i)?.O;
                        if (v.Name == "benutze")
                            v.Name = "benutze";
                    }
                    */

                    if (iPL >= PTL!.Count()) break;

                    if ((PLL!.List[j]!.PTL!.Index(i)!.O!.GetType() == typeof(Item))
                        )
                    {
                        if (PTL!.Index(iPL)!.O!.GetType() == typeof(Item))
                        {
                            found_PT++;
                            iPL++;
                        }
                        else if (PTL!.Index(iPL)!.O!.GetType() == typeof(Variety) && PTL!.VarietyCheckItem(iPL))
                        {
                            int Num = PTL!.Index(iPL)!.RangeInfo!; //  Adv_PL[iPL].WordID;
                            found_PT += Num + 1;
                            iPL += Num + 1;
                        }
                        else
                            iPL++;

                    }
                    else if ((PLL.List[j].PTL!.Index(i)!.O!.GetType() == typeof(Person))
                        )
                    {
                        if (PTL!.Index(iPL)!.O!.GetType() == typeof(Person))
                        {
                            found_PT++;
                            iPL++;
                        }
                        else if (PTL!.Index(iPL)!.O!.GetType() == typeof(Variety) && PTL!.VarietyCheckPerson(iPL))
                        {
                            int Num = PTL!.Index(iPL)!.RangeInfo;
                            found_PT += Num + 1;
                            iPL += Num + 1;
                        }
                        else
                            iPL++;
                    }
                    else if ((PLL.List[j].PTL!.Index(i)!.O!.GetType() == typeof(Topic))
                        )
                    {
                        if (PTL!.Index(iPL)!.O!.GetType() == typeof(Topic))
                        {
                            found_PT++;
                            iPL++;
                        }
                        else if (PTL!.Index(iPL)!.O!.GetType() == typeof(Variety) && PTL!.VarietyCheckTopic(iPL))
                        {
                            int Num = PTL!.Index(iPL)!.RangeInfo;
                            found_PT += Num + 1;
                            iPL += Num + 1;
                        }
                        else
                            iPL++;
                    }
                    else if (PLL.List[j].PTL!.Index(i)!.O!.GetType() == typeof(Prep))
                    {
                        if (PTL!.Index(iPL)!.O!.GetType() == typeof(Prep))
                        {
                            if ((PLL!.List![j]!.PTL!.Index(i)!.O as Prep)!.ID == (PTL!.Index(iPL)!.O as Prep)!.ID)
                            {
                                found_PT++;
                                iPL++;
                            }
                            else
                                iPL++;
                        }
                        else
                            iPL++;
                    }
                    else if ((PLL!.List[j]!.PTL!.Index(i)!.O!.GetType() == PTL!.Index(iPL)!.O!.GetType())
                                && (PLL!.List[j]!.PTL!.Index(i)!.O == PTL!.Index(iPL)!.O)
                            )
                    {
                        found_PT++;
                        iPL++;
                    }
                    else
                    {
                        iPL++;
                    }
                }
                if (found_PT == PTL!.Count())
                {
                    found_PL = j;
                    break;
                }
            }
            // yeah, ich habs gefunden
            if (found_PL >= 0)
            {
                found = true;
                found_ParseID = PLL.List[found_PL].ParseID;
            }
            else
            {
                AdvGame!.FeedbackOutput(AdvGame!.CA!.Person_Everyone!, String.Format( loca.Parse_FindInitialParseline_Person_Everyone_16228, LastParseLine) );
                found = false;
            }

            return found_ParseID;
        }


        private bool FindFinalParseline(ParseTokenList PTL)
        {
            int i, j;
            int found_PT;
            int found_PL = -1;
            bool found = true;
            int iPL;

            for (j = 0; j < PLL!.List!.Count!; j++)
            {
                found_PT = 0;
                for (i = 0, iPL = 0; i < PLL.List[j].PTL!.Count(); i++)
                {
                    if (i >= PTL!.Count()) break;

                    if ((PLL!.List[j]!.PTL!.Index(i)!.O!.GetType() == typeof(Item))
                        )
                    {
                        if (PTL!.Index(iPL)!.O!.GetType() == typeof(Item))
                        {
                            if (Items!.IsItemHere((Item)PTL!.Index(iPL)!.O!, PLL.List[j].PTL!.Index(i)!.RangeInfo))
                            {
                                found_PT++;
                            }
                            iPL++;
                        }
                        else
                            iPL++;

                    }
                    else if ((PLL!.List[j]!.PTL!.Index(i)!.O!.GetType() == typeof(Person))
                        )
                    {
                        if (PTL!.Index(iPL)!.O!.GetType() == typeof(Person))
                        {
                            if (Persons!.IsPersonHere((Person)PTL!.Index(iPL)!.O!, PLL!.List[j]!.PTL!.Index(i)!.RangeInfo))
                            {
                                found_PT++;
                            }
                            iPL++;
                        }
                        else
                            iPL++;
                    }
                    else if (PLL!.List[j]!.PTL!.Index(i)!.O!.GetType() == typeof(Topic))
                    {
                        if (PTL!.Index(iPL)!.O!.GetType() == typeof(Topic))
                        {
                            found_PT++;
                            iPL++;
                        }
                        else
                            iPL++;
                    }
                    else if ((PLL!.List[j]!.PTL!.Index(i)!.O!.GetType() == PTL!.Index(iPL)!.O!.GetType())
                                && (PLL!.List[j]!.PTL!.Index(i)!.O == PTL!.Index(iPL)!.O)
                            )
                    {
                        if (PTL!.Index(iPL)!.O!.GetType() == typeof(Verb))
                        {
                            if (((Verb)PTL!.Index(iPL)!.O!).ID == ((Verb)PLL!.List[j].PTL!.Index(i)!.O!).ID)
                                found_PT++;
                        }
                        else if (PTL!.Index(iPL)!.O!.GetType() == typeof(Prep))
                        {
                            if (((Prep)PTL!.Index(iPL)!.O!).ID == ((Prep)PLL!.List[j].PTL!.Index(i)!.O!).ID)
                                found_PT++;

                        }
                        else if (PTL!.Index(iPL)!.O!.GetType() == typeof(Fill))
                        {
                            if (((Fill)PTL!.Index(iPL)!.O!).ID == ((Fill)PLL!.List[j].PTL!.Index(i)!.O!).ID)
                                found_PT++;
                        }
                        iPL++;
                    }
                    else
                    {
                        iPL++;
                    }

                }
                if ((found_PT == PTL!.Count()) && (found_PT == PLL!.List[j].PTL!.Count()))
                {
                    found_PL = j;
                    break;
                }
            }
            // yeah, ich habs gefunden
            if (found_PL >= 0)
            {
                // Hier erfolgt dann auch sogleich der Aufruf der Delegate.
                PLL!.List![found_PL!]!.ParseMethod!(Persons!.Find(AdvGame!.A!.ActPerson!)!, PTL!);
            }
            else
            {
                AdvGame!.FeedbackOutput(AdvGame!.CA!.Person_Everyone!, String.Format(loca.Parse_FindFinalParseline_Person_Everyone_16229, LastParseLine));
                found = false;
            }

            return found;
        }

        public void DoParse(string s)
        {
            LastParseLine = s;

            string errorText = "";

            ParseTokenList ptl = new ParseTokenList();

            tPTL = ptl;
            bool found = StringToParseTokens(s, ptl, ref errorText);

            if (!found)
                AdvGame!.FeedbackOutput(AdvGame!.CA!.Person_Everyone!, errorText);
            else
            {
                int parseID = FindInitialParseline(ptl);

                if (parseID > -1)
                {
                    if (CountAmbiguousEntries(ptl) > 0)
                    {
                        RequestFirstAmbiguous(null!, ptl, parseID);
                        found = false;
                    }
                }
                else
                    found = false;
            }

            // Tja, jetzt noch die größte aller Fragen: existieren diese Befehle?
            if (found)
            {
                // Innerhalb dieser Methode werden dann auch etwaige Order-Funktionen aufgerufen
                found = FindFinalParseline(ptl);

            }
        }

        public class GenericItem
        {
            public Item? Item { get; set; }
            public int Off { get; set; }
            public int Count
            {
                get
                {
                    int sum = 0;
                    sum += (int) ( this.Item!.Adjectives?.Count + this.Item!.Names?.Count )!;
                    return sum;
                }
            }
        }

        public bool SortGenericItems( List<GenericItem> GenericItems, ParseTokenList ptl )
        {
            int ix = 0;
            List<int> ptlIndices = new();

            for( ix = 1; ix < GenericItems!.Count; ix++ )
            {
                if (GenericItems[ix].Off == GenericItems[ix-1].Off + 1)
                {
                    if(GenericItems[ix].Count == GenericItems[ix - 1].Count - 1)
                    {
                        GenericItems!.RemoveAt(ix);
                        ix--;
                        int ctObject = 0;
                        for (int ixPtl = 0; ixPtl < ptl!.PList!.Count!; ixPtl++ )
                        {
                            if (ptl.PList[ixPtl]!.O!.GetType() == typeof( List<object>))
                            {
                                if (ctObject == ix)
                                    ptlIndices.Add(ixPtl);

                                ctObject++;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void FindGenericSex( GenericItem GenericItem, ItemList Items )
        {
            foreach( Item i in Items!.List!.Values )
            {
                int ix = 0;
                for( ix = 0; ix < i.Names!.Count; ix++ )
                {
                    if(GenericItem!.Item!.Names![0] == i!.Names![ix] )
                    {
                        GenericItem!.Item!.Sex = i.Sex;
                    }
                }
            }
        }


        public bool DoParseNew(string s, DelParseLineList callbackSuccess, ParseTokenList? ptlPreParsed = null, ParseLineList? ptlPreParsedSignature = null)
        {
            PLL = AdvGame!.PLL;

            bool CollectIt = false;
            LastParseLineNew = s;
            cbSuccess = callbackSuccess;
            string errorText = "";
            bool found = false;
            List<GenericItem> genericItems = new();

            ParseTokenList ptl = new ParseTokenList();
            ParseLineList ptlSignatures = new ParseLineList();

            // Ein SkipAfterDialog gilt nur für einen Turn, daher muss es danach zwingend immer zurückgesetzt werden.
            AdvGame!.SkipAfterDialog = false;

            tPTLNew = ptl;
            tptlSignatures = ptlSignatures;
            tErrorText = errorText;


            /*
            if( AdvGame.MW.SilentMode == false && s != "" )
            {
                AdvGame.GD!.OrderList.AddOrder(orderType.orderText, s, null, latestPTL, latestPTLSignatures);
                if (AdvGame.GD!.OrderList.CurrentOrderListIx > 0)
                {
                    AdvGame.GD!.OrderList.AddOrderCurrentRun(orderType.orderText, s, null, latestPTL, latestPTLSignatures);
                    // MW.UpdateOrderList(GD!.OrderList);
                }

            }
            */

            if (AdvGame!.GD!.SilentMode == false && s != "")
            {
                AdvGame!.GD!.OrderList!.StartCollection();


            }

            if (ptlPreParsed == null)
            {
                // Zuerst wird der String in Tokens zerlegt, wobei für Items, Personen und Topics jeweils Listen mit in Frage kommenden Objekten 
                // werden aufgelistet 
                found = StringToParseTokensNew(s, ptl, PLL!.List!, genericItems, ref errorText);
                // Danach werden die passenden Signaturen herausgesucht und die in Frage kommenden Objekte auf solche reduziert, die in irgendeiner
                // passenden Signatur auftauchen (auf diese Weise fliegen alle Objekte raus, die gerade nicht zugänglich sind und auch nicht sein sollen
                // (nimm <Gegenstand> soll einen Fehler melden, wenn der Gegenstand nicht zu sehen ist. Und es soll auch nicht gespoilert werden, dass

                if (found)
                    SortGenericItems(genericItems, ptl);


                // der Gegenstand irgendwo sein könnte)
                if (found)
                    found = ParseTokensToParseSignatures(ptl, ptlSignatures, genericItems, ref errorText);

               // Hier werden die Unklarheiten aufgelöst, beispielsweise durch Nachfragen
                // wenn diese Methode true zurückmeldet, ist sichergestellt, dass ptl nur noch Objektlisten mit maximal einem Eintrag enthält und dass 
                // nur noch eine Signatur existiert
                // Wichtig: In ResolveAmbiguousParseTokens() ist eine Weiche. Wenn die Varianten über MultipleChoice aufgelöst werden müssen, 
                // dann muss die unten stehende Sequenz übersprungen werden. Es wird entsprechend found = false und errorText = "" zurückgemeldet
                if (found)
                    found = ResolveAmbiguousParseTokens(ptl, ptlSignatures, ref errorText);

                if (found)
                    FlatParseTokenList(ptl);

            }
            else
            {
                ptl = ptlPreParsed;
                ptlSignatures = ptlPreParsedSignature!;
                foreach (ParseLine pl in ptlSignatures!.List!)
                {
                    pl.SetParseMethodByString(AdvGame!.Orders!);
                }
                found = true;
            }
            // Nun sollte sichergestellt sein, dass sich in ptl nur noch Listen mit 1 Objekt sowie in ptlSignatures nur noch eine Parse-Signatur befindet
            if (found)
            {
                // Hier wäre nun der Zeitpunkt gekommen, alle Items in der aktuellen Eingabe aufzuzeichnen in der ItemQueue
                StoreItemsInQueue(ptl);

                if (ptlSignatures!.List![0]!.ParseMethod!(Persons!.Find(AdvGame!.A!.ActPerson!)!, ptl!) )
                {
                    LatestParseResult = "";
                    // latestPTL = ptl;
                    // latestPTLSignatures = ptlSignatures;
                    cbSuccess(ptlSignatures);
                    if (ptlSignatures.List[0].CollectIt)
                        CollectIt = true;
                }
                else
                {
                    AdvGame.SkipAfterDialog = false;

#if !NEWSCROLL
                    AdvGame.UIS!.Scr!.ScrollPageFinal();
#endif
                    /*
                     if (AdvGame.MW.SilentMode == true)
                     {
                         string sx;
                         OrderTable ot = AdvGame.GD!.OrderList.OTL![AdvGame.GD!.OrderList.CurrentOrderListIx].OT![AdvGame.GD!.OrderList.OTL![AdvGame.GD!.OrderList.CurrentOrderListIx].TempPoint - 1];
                         sx = ot.OrderFeedback;
                         sx += "bla bla ba";
                         // AdvGame.GD!.OrderList.AddOrderCurrentRun(ot.OrderType, ot.orderText, ot.OrderChoice, null, null);
                         AdvGame.GD!.OrderList.AddOrderFeedbackCurrentRun(ot.orderText, sx);
                     }
                     */
                }
            }
            // return CollectIt;
            if (!found && errorText != "")
            {
                AdvGame.FeedbackOutput(AdvGame.CA!.Person_Everyone!, errorText);
#if !NEWSCROLL
                if( AdvGame.UIS!.Scr != null )
                    AdvGame.UIS!.Scr.ScrollPageFinal();
#endif
            }

            // Wenn wir uns nicht gerade im SilentModus befinden
            /*
            if(AdvGame.GD!.SilentMode == false )
                AdvGame.RemoveEmptyDividingLine();
            */

            return CollectIt;
            /*
            if (!found)
                AdvGame.FeedbackOutput(AdvGame.CA!.Person_Everyone, errorText);
            else
            {
                int parseID = FindInitialParseline(ptl);

                if (parseID > -1)
                {
                    if (CountAmbiguousEntries(ptl) > 0)
                    {
                        RequestFirstAmbiguous(null, ptl, parseID);
                        found = false;
                    }
                }
                else
                    found = false;
            }

            // Tja, jetzt noch die größte aller Fragen: existieren diese Befehle?
            if (found)
            {
                // Innerhalb dieser Methode werden dann auch etwaige Order-Funktionen aufgerufen
                found = FindFinalParseline(ptl);

            }
            */
        }


        private bool IsAmbiguous(ParseTokenList ptl, ParseLineList ptlSignature)
        {
            bool ambi = false;

            foreach (ParseToken pt in ptl.PList!)
            {
                if (pt!.O!.GetType() == typeof(List<object>))
                {
                    if ((pt!.O as List<object>)!.Count > 1)
                        ambi = true;
                }
            }

            if (!ambi)
            {
                if (ptlSignature!.List!.Count! > 1)
                    ambi = true;
            }
            return ambi;
        }

        private bool ResolveAmbiguousParseTokens(ParseTokenList ptl, ParseLineList ptlSignature, ref string errorText)
        {
            bool found = true;
            object? o = null;

            if (IsAmbiguous(ptl, ptlSignature))
            {
                bool foundAmbi = false;
                foreach (ParseToken pt in ptl!.PList!)
                {
                    // wir suchen nach Listen mit einer Länger von größer 1
                    if (pt!.O!.GetType() == typeof(List<object>))
                    {
                        // So, hier wird nun einfach nachgefragt, was nicht passt
                        if ((pt!.O as List<object>)!.Count > 1)
                        {
                            AskAmbigous((pt!.O! as List<object>)!);
                            foundAmbi = true;
                        }
                        o = pt.O.GetType();
                    }
                    if (foundAmbi)
                        break;
                }
                found = false;

              }


            return found;
        }

        private bool FindValidItem(object o1, ParseToken pl)
        {
            bool found = false;

            if (o1.GetType() == typeof(Item) && pl.O != null)
            {
                if (pl.O.GetType() == typeof(Item))
                {
                    if (Items!.IsItemHere((o1 as Item), pl.RangeInfo) == true)
                        return true;
                }
            }
            return (found);
        }

        private bool FindValidPerson(object o1, ParseToken pl)
        {
            bool found = false;

            if (o1.GetType() == typeof(Person) && pl.O != null)
            {
                if (pl.O.GetType() == typeof(Person))
                {
                    if (Persons!.IsPersonHere((o1 as Person), pl.RangeInfo, true) == true)
                        found = true;
                }
            }
            return (found);
        }

        private bool FindValidTopic(object o1, ParseToken pl)
        {
            bool found = false;

            if (o1.GetType() == typeof(Topic) && pl.O != null)
            {
                if (pl.O.GetType() == typeof(Topic))
                {
                    if (Topics!.IsTopicHere((o1 as Topic)!, pl.RangeInfo) == true)
                        found = true;
                }
            }
            return (found);
        }


        private bool ParseTokensToParseSignatures(ParseTokenList ptl, ParseLineList ptlSignature, List<GenericItem> genericItems, ref string errorText)
        {
            List<object> variantObjects = new List<object>();
            // List<object>? latestInvariant = null;
            ptlSignature.List = new List<ParseLine>();
            int ptlCount = ptl.Count()!;

            // Schritt 1: Ermittlung, wie viele zu klärende AdvObjekte es in der ParseTokenList gibt. Dafür wird jeweils ein Flagfeld angelegt.
            // Es werden im nächsten Schritt alle möglichen Signaturen ermittelt. Dabei wird geprüft, ob alle AdvObjekte in einer Signatur gelandet sind
            // Alle, die das nicht sind, können entfernt werden aus der Liste. Das trifft in aller Regel auf Objekte zu, die in der aktuellen location
            // nicht zu sehen sind und auch nicht in Verbindung stehen mit einer Signatur, die auch nicht sichtbare Objekte zulässt (frage karlheinz nach dem verschwundenen Kind)
            foreach (ParseToken p in ptl.PList!)
            {
                if (p.O!.GetType() == typeof(List<object>))
                {
                    variantObjects.Add(new List<object>());
                    variantObjects[variantObjects.Count - 1] = new List<bool>();

                    foreach (object p2 in (p.O! as List<object>)!)
                    {
                        (variantObjects[variantObjects.Count - 1] as List<bool>)!.Add(new bool());
                    }
                }
            }

            // Schritt 2: Ermittlung der in Frage kommenden Signaturen
            int ptlCt, pllCt;
            int found_PT;

            bool found = true;

            for (pllCt = 0; pllCt < PLL!.List!.Count; pllCt++)
            {
                ParseTokenList ptlTemp = PLL!.List![pllCt].PTL!;
                 int ptlTempCount = ptlTemp!.Count();
                found_PT = 0;
                for (ptlCt = 0; ptlCt < ptlTempCount; ptlCt++)
                {
                    if (ptlCt < ptlCount)
                    {
                        Object o2 = ptl!.Index(ptlCt)!.O!;
                        ParseToken pt = ptlTemp.Index(ptlCt)!;
                        // In der ptl ist statt eines AdvObjekts eine Liste von in Frage kommenden Items
                        if (o2!.GetType() == typeof(List<object>))
                        {
                            int found_PT2 = 0;
                            // Spezialfall: Wir lösen das für jedes Listenelement auf
                            foreach (Object o in (ptl.Index(ptlCt)!.O as List<object>)!)
                            {
                                if (FindValidItem(o, pt) == true)
                                {
                                    found_PT2++;
                                }
                                else if (FindValidPerson(o, pt) == true)
                                {
                                    found_PT2++;
                                }
                                else if (FindValidTopic(o, pt) == true)
                                {
                                    found_PT2++;
                                }
                            }
                            if (found_PT2 > 0)
                                found_PT++;
                        }
                        // ein konkretes Item wurde gefunden
                        else if (FindValidItem(o2, pt) == true)
                        {
                            found_PT++;
                        }
                        else if (FindValidPerson(o2, pt) == true)
                        {
                            found_PT++;
                        }
                        else if (FindValidTopic(o2, pt) == true)
                        {
                            found_PT++;
                        }
                        else if (pt.O != null)
                        {
                            Object o = pt.O;

                            /*
                            Type a = o.GetType();
                            Type b = o2.GetType();
                            bool c = a.Equals(b);
                            string sx = String.Format( "{0} - {1} is {2}", a, b, c);
                            */

                            if (PLL!.List![pllCt].ParseID == 1044)
                            {

                            }

                            if (o.GetType().Equals(o2.GetType()))
                            {
                                // if ( o.GetType() == typeof(Verb))
                                if (o.GetType().Equals(typeof(Verb)))
                                {
                                    if ((o as Verb)!.ID == (o2 as Verb)!.ID)
                                        found_PT++;

                                }
                                // else if (o.GetType() == typeof(Noun))
                                else if (o.GetType().Equals(typeof(Noun))) // GetType() == typeof(Noun))
                                {
                                    if ((o as Noun)!.ID == (o2 as Noun)!.ID)
                                        found_PT++;

                                }
                                // else if (o.GetType() == typeof(Adj))
                                else if (o.GetType().Equals(typeof(Adj)))
                                {
                                    if ((o as Adj)!.ID == (o2 as Adj)!.ID)
                                        found_PT++;

                                }
                                // else if (o.GetType() == typeof(Prep))
                                else if (o.GetType().Equals(typeof(Prep)))
                                {
                                    if ((o as Prep)!.ID == (o2 as Prep)!.ID)
                                        found_PT++;

                                }
                                // else if (o.GetType() == typeof(Fill))
                                else if (o.GetType().Equals(typeof(Fill)))
                                {
                                    if ((o as Fill)!.ID == (o2 as Fill)!.ID)
                                        found_PT++;

                                }

                            }
                        }
                        /*
                                                else if ((pt.O.GetType() == o2.GetType())
                                                            && (pt.O == o2 )
                                                        )
                                                {
                                                    found_PT++;
                                                }
                         */
                    }

                    if (found_PT < ptlCt)
                        break;
                }
                // Diese Signatur könnte zutreffend sein
                if (found_PT == ptlCount && found_PT == ptlTempCount)
                {
                    ParseTokenList ptl2 = new ParseTokenList();

                    // Dann wird die Signatur übertragen nach ptlSignature
                    // Schritt 2.1. Signatur übertragen
                    ptlSignature.Add(PLL.CloneListEntry(pllCt));

                    // Schritt 2.2. Jene Adventure-Objekte übertragen, die für diese Signatur in Frage kämen
                    int ptlCt2 = 0;
                    int pltCtAdvObjects = 0;

                    // Wir gehen die ganze Signatur durch und schauen, wo variante Objekte möglich sind
                    for (; ptlCt2 < ptlSignature.List[ptlSignature.List.Count - 1].PTL!.Count(); ptlCt2++)
                    {
                        ParseToken p1 = ptlSignature!.List[ptlSignature!.List!.Count - 1]!.PTL!.PList![ptlCt2];
                        // List<Object> ptlO = (List<Object>) ptl.Index(ptlCt2).O;
                        // .PLL.List[pllCt].PTL!.PList[ptlCt2];

                        // Hier ist ein Item gefragt?
                        if (p1!.O!.GetType().Equals(typeof(Item))) // GetType() == typeof(Item))
                        {
                            p1.O = new List<Object>();

                            if (ptlCt2 >= ptlCount)
                            {

                            }
                            // Diese Bedingung kann eigentlich nur erfüllt sein, anderernfalls gibt's ein größeres Problem
                            else if (ptl!.Index(ptlCt2)!.O!.GetType() == typeof(List<object>))
                            {
                                int ptlCt3 = 0;
                                List<Object> listO = (ptl.Index(ptlCt2)!.O as List<object>)!;
                                // Wir schauen die Liste der in Frage kommenden Objekte durch...
                                foreach (Object o in listO)
                                {
                                    // ... und filtern die Items heraus...
                                    if (o.GetType().Equals(typeof(Item))) // GetType() == typeof( Item ))
                                    {
                                        Item i = (Item)o;
                                        // ... die von der Range her in Frage kommen
                                        if (Items!.IsItemHere(i.ID, p1.RangeInfo) == true)
                                        {
                                            (p1.O as List<Object>)!.Add((object)i);
                                            (variantObjects[pltCtAdvObjects] as List<bool>)![ptlCt3] = true;

                                        }
                                    }
                                    ptlCt3++;
                                }
                            }
                            pltCtAdvObjects++;
                        }
                        // Hier ist eine Person gefragt?
                        else if (p1.O.GetType() == typeof(Person))
                        {
                            p1.O = new List<Object>();

                            // Diese Bedingung kann eigentlich nur erfüllt sein, anderernfalls gibt's ein größeres Problem
                            if (ptl!.Index(ptlCt2)!.O!.GetType() == typeof(List<object>))
                            {
                                int ptlCt3 = 0;
                                // Wir schauen die Liste der in Frage kommenden Objekte durch...
                                foreach (Object o in (ptl!.Index(ptlCt2)!.O as List<object>)!)
                                {
                                    // ... und filtern die Personen heraus...
                                    if (o.GetType() == typeof(Person))
                                    {
                                        Person p = (Person)o;
                                        // ... die von der Range her in Frage kommen
                                        if (Persons!.IsPersonHere(p, p1.RangeInfo) == true)
                                        {
                                            (p1.O as List<Object>)!.Add((object)p);
                                            (variantObjects![pltCtAdvObjects] as List<bool>)![ptlCt3] = true;

                                        }
                                    }
                                    ptlCt3++;
                                }
                            }
                            pltCtAdvObjects++;
                        }
                        // Hier ist ein Topic gefragt?
                        else if (p1.O.GetType() == typeof(Topic))
                        {
                            p1.O = new List<Object>();

                            // Diese Bedingung kann eigentlich nur erfüllt sein, anderernfalls gibt's ein größeres Problem
                            if (ptl.Index(ptlCt2)!.O!.GetType() == typeof(List<object>))
                            {
                                int ptlCt3 = 0;
                                // Wir schauen die Liste der in Frage kommenden Objekte durch...
                                foreach (Object o in (ptl!.Index(ptlCt2)!.O! as List<object>)!)
                                {
                                    // ... und filtern die Personen heraus...
                                    if (o.GetType() == typeof(Topic))
                                    {
                                        Topic t = (Topic)o;
                                        // ... die von der Range her in Frage kommen
                                        if (Topics!.IsTopicHere(t, p1.RangeInfo) == true)
                                        {
                                            (p1!.O! as List<Object>)!.Add((object)t!);
                                            (variantObjects![pltCtAdvObjects] as List<bool>)![ptlCt3] = true;

                                        }
                                    }
                                    ptlCt3++;
                                }
                            }
                            pltCtAdvObjects++;
                        }
                    }
                }
            }


            int aoListCt = ptl.Count() - 1;
            int latestNotFound = -1;

            // Wir gehen die Flagliste von hinten durch
            // ... und suchen passend dazu von hinten beginnend die zugehörigen Variant Items in der Kette heraus
            for (int aoCt = variantObjects.Count - 1; aoCt >= 0; aoCt--)
            {
                List<bool> voFlags = (variantObjects[aoCt] as List<bool>)!;
                List<object>? aoList = null;

                while (ptl!.PList[aoListCt]!.O!.GetType() != typeof(List<object>) && aoListCt > 0)
                {
                    aoListCt--;
                }
                if (ptl!.PList[aoListCt]!.O!.GetType() == typeof(List<object>))
                    aoList = (List<object>)(ptl.PList[aoListCt].O)!;

                // Wenn ein gültiger Eintrag in ptl.PList gefunden, wird auch diese Liste von hinten begonnen und alles rausgeworfen, was für eine der obigen 
                // varianten in Frage kommt.
                if (aoList != null)
                {
                    for (int voFlagCt = voFlags.Count - 1; voFlagCt >= 0; voFlagCt--)
                    {
                        // Wenn ein AdventureObjekt von keiner der oben herausgefilterten Signaturen verwendet wird...
                        if (voFlags[voFlagCt] == false)
                        {
                            // ... dann wird es aus der Liste gelöscht
                            aoList.RemoveAt(voFlagCt);
                        }
                    }
                    if( aoList.Count == 0 )
                    {
                        latestNotFound = aoCt;
                    }
                }
                aoListCt--;

            }

            if (ptlSignature.List.Count == 0)
            {
                /*
                if( genericItems!.Count > 0 && latestNotFound >= 0 )
                {
                    bool stop = false;

                    genericItems[latestNotFound].IsCountable = true;
                    foreach (Item it in Items!.List.Values)
                    {
                        foreach (Noun n in it.Names)
                        {
                            if (n.ID == genericItems[latestNotFound].Names[0].ID)
                            {
                                genericItems[latestNotFound].Sex = it.Sex;
                                stop = true;
                                break;
                            }
                        }
                        if (stop)
                            break;
                    }

                    errorText = genericItems[latestNotFound].FullName(Co.CASE_AKK_UNDEF) + " war hier nicht vorhanden.";
                }
                else
                */
                // Ok, der Fall hier ist. Es wurde keine passende Signatur gefunden, d.h., die Anweisung kann auf keinen Fall ausgeführt werden
                {
                    int ix;
                    int ixV = 0;
                    // Step 1: Alle Items in ptl und variantObjects, die nicht direkt am Ort sind, werden entfernt

                    ixV = 0;
                    for( ix = 0; ix < ptl.PList.Count; ix++)
                    {
                        if(ptl.PList[ix]!.O!.GetType() == typeof( List<object>))
                        {
                            int ixO = 0;

                            foreach( object o in ( ptl!.PList[ix]!.O as List<object> )! )
                            {
                                if( o.GetType() == typeof( Item))
                                {
                                    Item i = (o as Item)!;
                                    if (Items!.IsItemHere(i.ID, Co.Range_Here ) == false )
                                    {
                                        (ptl!.PList![ix]!.O as List<object>)!.RemoveAt(ix);
                                        variantObjects.RemoveAt(ixO);

                                    }
                                }
                                else if (o.GetType() == typeof(Person))
                                {
                                    Person p = (o as Person)!;
                                    if (Persons!.IsPersonHere( p, Co.Range_Here) == false)
                                    {
                                        (ptl.PList[ix]!.O as List<object>)!.RemoveAt(ix);
                                        variantObjects.RemoveAt(ixO);

                                    }

                                }
                                else if (o.GetType() == typeof(Topic))
                                {
                                    (ptl.PList[ix]!.O as List<object>)!.RemoveAt(ix);
                                    variantObjects.RemoveAt(ixO);
                                }
                                ixO++;
                            }
                        }
                        ixV++;
                    }
                    // Step 2: Es wird ermittelt, ob eines der Items gar nicht vorhanden ist.

                    int ctItems = 0;
                    for (ix = 0; ix < ptl.PList.Count; ix++)
                    {
                        bool doBreak = false;

                        if (ptl.PList[ix].O != null)
                        {
                            if(ptl!.PList[ix]!.O!.GetType() == typeof( List<object> ) )
                            {
                                if ((ptl!.PList[ix]!.O as List<object>)!.Count > 0)
                                    ctItems++;
                                else
                                    doBreak = true;
                            }
                        }
                        if (doBreak)
                            break;
                    }

                    // Es ist ein Break erfolgt == in ptl wurde das generische Item identifiziert
                    // ... dann wird dieses als fehlend ausgegeben
                    if (ix < ptl.PList.Count)
                    {
                        Person testPerson = new();

                        testPerson.Adjectives = genericItems[ctItems].Item!.Adjectives;
                        testPerson.Names = genericItems[ctItems].Item!.Names;

                        testPerson.AdjectivesEng = genericItems[ctItems].Item!.AdjectivesEng;
                        testPerson.NamesEng = genericItems[ctItems].Item!.NamesEng;

                        List<Person> p = Persons!.FindByName(testPerson!)!;

                        // if (identical && Persons!.IsPersonHere(person1, Co.Range_Here))
                        // {
                        // possibleAdvObjects.Add(person1);
                        // }
                        for( int ix2 = p!.Count -1; ix2 >= 0; ix2--)
                        {
                            if (Persons.IsPersonHere(p[ix2], Co.Range_Here ) == false )
                            {
                                p.RemoveAt(ix2);
                            }
                        }

                        if (p.Count > 0)
                        {
                            errorText = String.Format(loca.Parse_NotSuitableForPerson, p[0].FullName(Co.CASE_DAT_UNDEF, AdvGame.CurrentNouns)!);

                        }
                        /*
                        else if (p.Count == 1)
                        {
                        }
                        */
                        else
                        {
                            genericItems[ctItems]!.Item!.IsCountable = true;
                            FindGenericSex(genericItems[ctItems]!, Items!);
                            errorText = String.Format(loca.Parse_FindInitialParseline_Person_Everyone_16228, LastParseLineNew);

                        }

                    }
                    // ... anderenfalls kommt die allgemeine Fehlermeldung
                    else
                    {
                        errorText = String.Format(loca.Parse_ParseTokensToParseSignatures_16230, LastParseLineNew);
                    }
                }
                found = false;
            }
            else
                found = true;

            // return found_ParseID;

            return found;
        }


        private bool FindAdvObjectInParseSequence(ParseTokenList ptlTemp, int startOff, int endOff, List<Noun> Names, List<Noun> SynNames, List<Adj> Adjectives, List<Adj> SynAdjectives)
        {
            bool aoFound = false;
            int itemSignCt;
            bool identical;

            // jetzt werden alle Einträge abgeglichen
            for (itemSignCt = startOff; itemSignCt < endOff; itemSignCt++)
            {
                Object o = ptlTemp!.PList![itemSignCt].O!;
                identical = false;
                // if (ptlTemp.Index(itemSignCt).O.GetType() == typeof(Noun))
                if (o.GetType() == typeof(Noun))
                {
                    // if (Names.ContainsKey((o as Noun).ID))
                    //     identical = true;
                    int id = (o as Noun)!.ID;

                    foreach (Noun n in Names)
                    {
                        if (id == n.ID)
                        {
                            identical = true;
                            break;
                        }
                    }
                    if (!identical)
                    {
                        foreach (Noun n in SynNames)
                        {
                            if (id == n.ID)
                            {
                                identical = true;
                                break;
                            }
                        }

                    }
                }
                else if (o.GetType() == typeof(Adj))
                {
                    int id = (o as Adj)!.ID!;

                    foreach (Adj a in Adjectives)
                    {
                        if (id == a.ID)
                        {
                            identical = true;
                            break;
                        }
                    }
                    if (!identical)
                    {
                        foreach (Adj a in SynAdjectives)
                        {
                            if (id == a.ID)
                            {
                                identical = true;
                                break;
                            }
                        }
                    }
                }
                if (!identical) break;
            }

            if (itemSignCt >= endOff)
                aoFound = true;

            return aoFound;
        }

        /*
        List<Object> CollectAdvObjects(ParseTokenList PTL, int ptlCt, int ptlCtSeqEnd)
        {
            List<Object> possibleAdvObjects = new List<Object>();

            // Abgleich mit allen Items: Welche kommen in Frage?
            foreach (Item item1 in Items!.List.Values)
            {
                bool identical = false;

                // alle Items ausfiltern, die nicht aktiv sind 
                bool foundItem = item1.Active; //  Items!.IsItemHere(item1, Co.Range_Active);

                if (foundItem)
                {
                    Item item2 = item1;
                    identical = FindAdvObjectInParseSequence(PTL, ptlCt, ptlCtSeqEnd, item2.Names, item2.SynNames, item2.Adjectives, item2.SynAdjectives);
                }
                // Ja, dieses Item könnte es sein. 
                if (identical)
                {
                    possibleAdvObjects.Add(item1);
                    // lastFoundObject = item1;
                }
            }
        

            // Abgleich mit allen Personen: Welche kommen in Frage?
            foreach (Person person1 in Persons!.List.Values)
            // for (int personCt = 0; personCt < Persons!.List.Count; personCt++)
            {
                bool identical = false;
                bool foundPerson = Persons!.IsPersonHere(person1, Co.Range_Active);

                if (foundPerson)
                {
                    Person person = person1;
                    identical = FindAdvObjectInParseSequence(PTL, ptlCt, ptlCtSeqEnd, person.Names, person.SynNames, person.Adjectives, person.SynAdjectives);
                }
                // Ja, diese Person könnte es sein. 
                if (identical)
                {
                    possibleAdvObjects.Add(person1);
                    // lastFoundObject = person1;
                }
            }
            // Abgleich mit allen Topics: Welche kommen in Frage?
            for (int topicCt = 0; topicCt < Topics.List.Count; topicCt++)
            {
                bool identical = false;
                bool foundTopic = Topics.IsTopicHere(Topics.List[topicCt], Co.Range_Active);

                if (foundTopic)
                {
                    Topic topic = Topics.List[topicCt];
                    identical = FindAdvObjectInParseSequence(PTL, ptlCt, ptlCtSeqEnd, topic.Names, topic.SynNames, topic.Adjectives, topic.SynAdjectives);
                }
                // Ja, dieses Item könnte es sein. 
                if (identical)
                {
                    possibleAdvObjects.Add(Topics.List[topicCt]);
                    // topicsFound = topicCt;
                    // lastFoundObject = Topics.List[topicCt];
                }
            }

            return possibleAdvObjects;
        }
        */

        List<Object> CollectAdvObjectsPresent(ParseTokenList PTL, int ptlCt, int ptlCtSeqEnd)
        {
            List<Object> possibleAdvObjects = new List<Object>();

            // Abgleich mit allen Items: Welche kommen in Frage?
            foreach (Item item1 in Items!.List!.Values)
            {
                bool identical = false;

                // alle Items ausfiltern, die nicht aktiv sind 
                bool foundItem = item1.Active; //  Items!.IsItemHere(item1, Co.Range_Active);

                if (foundItem)
                {
                    Item item2 = item1;
                    identical = FindAdvObjectInParseSequence(PTL, ptlCt, ptlCtSeqEnd, item2!.Names!, item2!.SynNames!, item2!.Adjectives!, item2.SynAdjectives!);
                }
                // Ja, dieses Item könnte es sein. 
                if (identical && Items!.IsItemHere( item1, Co.Range_Here) )
                {
                    possibleAdvObjects.Add(item1);
                    // lastFoundObject = item1;
                }
            }


            // Abgleich mit allen Personen: Welche kommen in Frage?
            foreach (Person person1 in Persons!.List!.Values!)
            // for (int personCt = 0; personCt < Persons!.List.Count; personCt++)
            {
                bool identical = false;
                bool foundPerson = Persons!.IsPersonHere(person1, Co.Range_Active);

                if (foundPerson)
                {
                    Person person = person1;
                    identical = FindAdvObjectInParseSequence(PTL, ptlCt, ptlCtSeqEnd, person.Names!, person.SynNames!, person.Adjectives!, person.SynAdjectives!);
                }
                // Ja, diese Person könnte es sein. 
                if (identical && Persons!.IsPersonHere(person1, Co.Range_Here ) )
                {
                    possibleAdvObjects.Add(person1);
                    // lastFoundObject = person1;
                }
            }
            // Abgleich mit allen Topics: Welche kommen in Frage?
            for (int topicCt = 0; topicCt < Topics!.List!.Count!; topicCt++)
            {
                bool identical = false;
                bool foundTopic = Topics.IsTopicHere(Topics.List[topicCt], Co.Range_Active);

                if (foundTopic)
                {
                    Topic topic = Topics.List[topicCt];
                    identical = FindAdvObjectInParseSequence(PTL, ptlCt, ptlCtSeqEnd, topic!.Names!, topic!.SynNames!, topic!.Adjectives!, topic!.SynAdjectives!);
                }
                // Ja, dieses Item könnte es sein. 
                if (identical)
                {
                    possibleAdvObjects.Add(Topics.List[topicCt]);
                    // topicsFound = topicCt;
                    // lastFoundObject = Topics.List[topicCt];
                }
            }

            return possibleAdvObjects;
        }

        private bool StringToParseTokensNew(string s, ParseTokenList PTL, List<ParseLine> pll, List<GenericItem> genericItems, ref string ErrorText)
        {
            string[] separatedWords;
            char[] charSeparators = new char[] { ',', ' ', '.', ';' };

            // Schritt 1: Parsezeile in einzelne Worte zerlegen
            separatedWords = s.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            bool found = false;
#pragma warning disable CS0219 // Die Variable "itemsFound" ist zugewiesen, ihr Wert wird aber nie verwendet.
            int itemsFound = 0;
#pragma warning restore CS0219 // Die Variable "itemsFound" ist zugewiesen, ihr Wert wird aber nie verwendet.
#pragma warning disable CS0219 // Die Variable "personsFound" ist zugewiesen, ihr Wert wird aber nie verwendet.
            int personsFound = 0;
#pragma warning restore CS0219 // Die Variable "personsFound" ist zugewiesen, ihr Wert wird aber nie verwendet.
            // int topicsFound = 0;
            ErrorText = "";

            // Schritt 2: Erkennen, welche Worte eingegeben wurden 
            foreach (string element in separatedWords)
            {
                string element2 = element;
                // Hinten angehängte Satzzeichen werden entfernt
                if( element2.EndsWith("?") || element2.EndsWith("!") || element2.EndsWith(".") || element2.EndsWith(",") || element2.EndsWith(";") )
                {
                    string element3 = element.Substring(0, element2.Length - 1);
                    if (element3.Length > 0)
                        element2 = element3;
                }
                found = false;
                if (!found)
                {
                    Noun n = Nouns!.Find(element2!)!;
                    if (n != null)
                    {
                        PTL!.AddNoun(n.ID);
                        found = true;
                    }
                }
                if (!found)
                {
                    Adj a = Adjs!.FindAdj(element2)!;
                    if (a != null)
                    {
                        PTL!.AddAdj(a.ID);
                        found = true;
                    }
                }
                if (!found)
                {
                    Verb v = Verbs!.Find(element2);
                    if (v != null)
                    {
                        PTL!.AddVerb(v);
                        found = true;
                    }
                }
                if (!found)
                {
                    Prep p = Preps!.Find(element2)!;
                    if (p != null)
                    {
                        PTL!.AddPrep(p);
                        found = true;
                    }
                }
                if (!found)
                {
                    Fill f = Fills!.Find(element2!)!;
                    if (f != null)
                    {
                        PTL!.AddFill(f.ID);
                        found = true;
                    }
                }
                if (!found)
                {
                    Pronoun pro = Pronouns!.Find(element2);
                    if (pro != null)
                    {
                        PTL!.AddPronoun(pro.ID);
                        found = true;
                    }
                }
                if (!found)
                {
                    ErrorText = String.Format(loca.Parse_StringToParseTokensNew_16231, element2);
                    break;
                }
            }

            // wozu mag das wohl gut sein?
            /*
            bool FindMatchingItemPerson(string s1, string s2)
            {
                bool found = false;

                foreach (Item i in Items!.List.Values)
                {

                }
                return found;
            }
            */

            // Schritt 3: Aus Adjektiven und Nomen lassen sich (möglicherweise mehrere) Items, Personen oder Topics zusammenfügen
            // Adj + Nouns zu Items
            if (found)
            {
                int ptlCt, ptlCtSeqEnd;
                int ctAdditionalItems = 0;
                bool parseGenericItems = true;
                // Object lastFoundObject = null;

                for (ptlCt = 0; ptlCt < PTL!.Count(); ptlCt++)
                {
                    // Spezialfall (nur in Deutsch erst mal): Ein Nomen, das am Satzanfang steht, wird dann als Verb interpretiert, 
                    // wenn es in einer anderen Syntax als explizites Nomen an erster Stelle steht
                    bool treatNounAsVerb = false;

                    if (PTL!.Index(ptlCt)!.O!.GetType() == typeof(Noun) && ptlCt == 0 && PTL!.Count() > 1)
                    {
                        int ix = 0;
                        foreach (ParseLine pl in pll)
                        {
                            ix++;
                            if (pl!.PTL!.PList![0]!.O!.GetType() == typeof(Noun))
                            {
                                Noun n = (pl.PTL!.PList[0].O as Noun)!;
                                if (n!.ID == (PTL!.Index(ptlCt)!.O as Noun)!.ID!)
                                {
                                    treatNounAsVerb = true;
                                    break;
                                }
                            }
                        }
                    }

                    // Spezialfall: Noun as Verb, Eingabe besteht nur aus Noun/Verb, 
                    else if (PTL!.Index(ptlCt)!.O!.GetType() == typeof(Noun) && ptlCt == 0 && PTL!.Count() == 1)
                    {
                        foreach (ParseLine pl in pll)
                        {
                            if (pl.PTL!.Count() == 1)
                            {
                                if(pl!.PTL!.PList![0]!.O!.GetType() == typeof (Noun) )
                                {

                                    if ((pl.PTL!.PList[0]!.O as Noun)!.ID == (PTL!.Index(ptlCt)!.O as Noun)!.ID)
                                    {
                                        treatNounAsVerb = true;
                                    }
                                }
                            }
                        }
                    }

                    // List<Object> possibleAdvObjects = new List<Object>();

                    // Hier wird ein Item eingeleitet
                    if (( (PTL!.Index(ptlCt)!.O!.GetType() == typeof(Adj)) || (PTL!.Index(ptlCt)!.O!.GetType() == typeof(Noun))) && treatNounAsVerb == false )
                    {
                        if (ctAdditionalItems == 0)
                        {
                            genericItems!.Add( new GenericItem());
                            genericItems[genericItems!.Count - 1].Item = new();
                            genericItems[genericItems!.Count - 1].Item!.Names = new();
                            genericItems[genericItems!.Count - 1].Item!.Adjectives = new();
                            genericItems[genericItems!.Count - 1].Off = ptlCt;
                            parseGenericItems = true;
                        }
                        else
                        {
                            ctAdditionalItems--;
                            parseGenericItems = false;

                        }
                        // bool artPhase = false;
                        bool adjPhase = false;
                        bool nomPhase = false;

                        if(PTL!.Index(ptlCt)!.O!.GetType() == typeof(Adj) && parseGenericItems == true )
                        {
                            genericItems[genericItems!.Count - 1]!.Item!.Adjectives!.Add((PTL!.Index(ptlCt)!.O! as Adj)!);

                        }
                        if (PTL!.Index(ptlCt)!.O!.GetType() == typeof(Noun) && parseGenericItems == true )
                        {
                            genericItems[genericItems!.Count - 1]!.Item!.Names!.Add((PTL!.Index(ptlCt)!.O! as Noun)!);

                        }

                        for (ptlCtSeqEnd = ptlCt + 1; ptlCtSeqEnd < PTL!.Count(); ptlCtSeqEnd++)
                        {
                            // Wenn ein Füllwort kommt, obwohl schon Adjektive und Nomen gefunden wurden: Abbruch!
                            if (PTL!.Index(ptlCtSeqEnd)!.O!.GetType() == typeof(Fill) && (adjPhase || nomPhase))
                                break;
                            // Wenn ein Adjektiv kommt, obwohl schon Nomen gefunden wurden: Abbruch!
                            if (PTL!.Index(ptlCtSeqEnd)!.O!.GetType() == typeof(Adj) && ( nomPhase))
                                break;

                            // Der Item/Person/Topic Name geht gerade so lange, bis was anderes als ein Adjektiv oder Nomen kommt
                            if ((PTL!.Index(ptlCtSeqEnd)!.O!.GetType() != typeof(Adj)) && (PTL!.Index(ptlCtSeqEnd)!.O!.GetType() != typeof(Noun)))
                                break;

                            if (PTL!.Index(ptlCtSeqEnd)!.O!.GetType() == typeof(Adj) && parseGenericItems == true )
                            {
                                genericItems[genericItems!.Count - 1]!.Item!.Adjectives!.Add((PTL!.Index(ptlCtSeqEnd)!.O as Adj)!);

                                adjPhase = true;
                            }
                            if (PTL!.Index(ptlCtSeqEnd)!.O!.GetType() == typeof(Noun) && parseGenericItems == true)
                            {
                                genericItems[genericItems!.Count - 1]!.Item!.Names!.Add((PTL!.Index(ptlCtSeqEnd)!.O! as Noun)!);
                                nomPhase = true;
                            }

                        }
                        // soviel kann man nun festhalten: Das Item reicht von ptlCt bis ptlCtSeqEnd-1

                        /*
                        // Abgleich mit allen Items: Welche kommen in Frage?
                        foreach (Item item1 in Items!.List.Values ) 
                        {
                            bool identical = false;

                            // alle Items ausfiltern, die nicht aktiv sind 
                            bool foundItem = Items!.IsItemHere(item1, Co.Range_Active);

                            if (foundItem)
                            {
                                Item item2 = item1;
                                identical = FindAdvObjectInParseSequence(PTL, ptlCt, ptlCtSeqEnd, item2.Names, item2.SynNames, item2.Adjectives, item2.SynAdjectives);
                            }
                            // Ja, dieses Item könnte es sein. 
                            if (identical)
                            {
                                possibleAdvObjects.Add(item1);
                                // lastFoundObject = item1;
                            }
                        }


                        // Abgleich mit allen Personen: Welche kommen in Frage?
                        foreach (Person person1 in Persons!.List) 
                            // for (int personCt = 0; personCt < Persons!.List.Count; personCt++)
                        {
                            bool identical = false;
                            bool foundPerson = Persons!.IsPersonHere(person1, Co.Range_Active);

                            if (foundPerson)
                            {
                                Person person = person1;
                                identical = FindAdvObjectInParseSequence(PTL, ptlCt, ptlCtSeqEnd, person.Names, person.SynNames, person.Adjectives, person.SynAdjectives);
                            }
                            // Ja, diese Person könnte es sein. 
                            if (identical)
                            {
                                possibleAdvObjects.Add(person1);
                                // lastFoundObject = person1;
                            }
                        }
                        // Abgleich mit allen Topics: Welche kommen in Frage?
                        for (int topicCt = 0; topicCt < Topics.List.Count; topicCt++)
                        {
                            bool identical = false;
                            bool foundTopic = Topics.IsTopicHere(Topics.List[topicCt], Co.Range_Active);

                            if (foundTopic)
                            {
                                Topic topic = Topics.List[topicCt];
                                identical = FindAdvObjectInParseSequence(PTL, ptlCt, ptlCtSeqEnd, topic.Names, topic.SynNames, topic.Adjectives, topic.SynAdjectives);
                            }
                            // Ja, dieses Item könnte es sein. 
                            if (identical)
                            {
                                possibleAdvObjects.Add(Topics.List[topicCt]);
                                topicsFound = topicCt;
                                // lastFoundObject = Topics.List[topicCt];
                            }
                        }
                        */

                        List<Object> possibleAdvObjects = CollectAdvObjectsPresent(PTL, ptlCt, ptlCtSeqEnd);

                        if (possibleAdvObjects.Count == 0)
                        {
                            List<object> tPossibleAdvObjects = possibleAdvObjects;
                            int tPtlCtSeqEnd = ptlCtSeqEnd;

                            // Wird ein Item erkannt, sobald ich am Schluss Nomen oder Adjektive ignoriere? Und dem nächsten Item zuschubse?
                            while (possibleAdvObjects.Count == 0 && ptlCtSeqEnd > (ptlCt + 1))
                            {
                                ptlCtSeqEnd--;
                                possibleAdvObjects = CollectAdvObjectsPresent(PTL, ptlCt, ptlCtSeqEnd);
                                // ctAdditionalItems++;
                                // parseGenericItems = false;
                            }

                            /*
                            // Hat nichts gebracht? Dann versuchen wir, das Feld auf Items zu verengen, die aktiv vor Ort sind
                            if (possibleAdvObjects.Count == 0)
                            {
                                possibleAdvObjects = tPossibleAdvObjects;
                                ptlCtSeqEnd = tPtlCtSeqEnd;
                                while (possibleAdvObjects.Count == 0 && ptlCtSeqEnd > (ptlCt + 1))
                                {
                                    ptlCtSeqEnd--;
                                    possibleAdvObjects = CollectAdvObjectsPresent(PTL, ptlCt, ptlCtSeqEnd);
                                }
                            }
                            */

                            // Nö, hat nix gebracht, also wird wieder das alte Item restauriert
                            if (possibleAdvObjects.Count == 0)
                            {
                                possibleAdvObjects = tPossibleAdvObjects;
                                ptlCtSeqEnd = tPtlCtSeqEnd;
                            }
                        }
                        // Zwischenschritt: 


                            // Schritt 3a. Was käme denn in Frage?

                        int itemPersonTopicCount = possibleAdvObjects.Count;
                        if (possibleAdvObjects.Count == 0)
                        {
                            if (genericItems!.Count > 0 ) 
                            {
                                if (genericItems[genericItems!.Count - 1]!.Item!.Names!.Count == 0)
                                {
                                    genericItems[genericItems!.Count - 1].Item!.Names!.Add(AdvGame!.CA!.Noun_Something!);
                                    genericItems[genericItems!.Count - 1].Item!.IsCountable = true;
                                    genericItems[genericItems!.Count - 1].Item!.Sex = Co.SEX_NEUTER;
                                }
                                else
                                {
                                    bool stop = false;

                                    genericItems[genericItems!.Count - 1]!.Item!.IsCountable = true;
                                    foreach (Item it in Items!.List!.Values)
                                    {
                                        foreach (Noun n in it!.Names!)
                                        {
                                            if (n.ID == genericItems[genericItems!.Count - 1]!.Item!.Names![0]!.ID!)
                                            {
                                                genericItems[genericItems!.Count - 1]!.Item!.Sex = it!.Sex;
                                                stop = true;
                                                break;
                                            }
                                        }
                                        if (stop)
                                            break;
                                    }
                                }
                                ErrorText = genericItems[genericItems!.Count - 1]!.Item!.FullName( Co.CASE_AKK_UNDEF, AdvGame.CurrentNouns) + loca.Parse_StringToParseTokensNew_16232;
                            }
                            else
                            {
                                ErrorText = loca.Parse_StringToParseTokensNew_16233;
                            }
                            found = false;
                        }
                        else if (possibleAdvObjects.Count >= 1)
                        {
                            int l = ptlCt;
                            // PTL!.PList[ptlCt].O = possibleAdvObjects.ToArray();

                            PTL!.PList![ptlCt]!.O = new List<object>();
                            foreach( Object ao in possibleAdvObjects )
                            {
                                object o;

                                /*
                                if (ao.GetType() == typeof(Item))
                                {
                                    o = (ao as Item).Clone();
                                }
                                else if (ao.GetType() == typeof(Person))
                                {
                                    o = (ao as Person).Clone();

                                }
                                else
                                {
                                    o = (ao as Topic).Clone();

                                }
                                */
                                if (ao.GetType() == typeof(Item))
                                {
                                    o = (ao as Item)!;
                                }
                                else if (ao.GetType() == typeof(Person))
                                {
                                    o = (ao as Person)!;

                                }
                                else
                                {
                                    o = (ao as Topic)!;

                                }

                                (PTL!.PList![ptlCt]!.O! as List<object>)!.Add(o!);
                            }
                        }
                        else
                        {
                            // jetzt ist per definition lastFoundObject das richtige Objekt ( denn es wurde ja offensichtlich nur ein Objekt gefunden)

                            // Hier wurde die Liste zurückgesetzt zu einem direkten Eintrag. Das ist für die Weiterverarbeitung ungünstig
                            // Der Weiterverarbeitung ist es hingegen völlig egal, ob die Liste nur aus einem Eintrag besteht
                            // PTL!.PList[ptlCt].O = lastFoundObject;

                            found = true;
                        }

                        while( ptlCt < ptlCtSeqEnd - 1)
                        {
                            PTL!.RemoveAt(ptlCt + 1);
                            ptlCtSeqEnd--;
                        }
                        ptlCt = ptlCtSeqEnd - 1;
                    }
                    else if ( PTL!.Index(ptlCt)!.O!.GetType() == typeof(Pronoun))
                    {
                        string name = (PTL!.Index(ptlCt)!.O! as Pronoun)!.Name!;
                        List<int> sexes = new();
                        foreach( Pronoun p in Pronouns!.TList!)
                        {
                            if (p.Name == name)
                                sexes.Add(p.Sex);
                        }
                        // sexes enthält nun eine Liste aller in Frage kommenden Geschlechter
                        bool foundSex = false;
                        int ix = 0;
                        for( ix = ItemQueue!.IQ!.Count! -1; ix >= 0; ix-- )
                        {
                            foreach( int j in sexes)
                            {
                                if (ItemQueue.IQ[ix].Sex == j)
                                {
                                    foundSex = true;
                                    break;
                                }

                            }
                            if (foundSex)
                                break;
                        }
                        if( foundSex )
                        {
                            PTL!.Index(ptlCt)!.O = ItemQueue.IQ[ix];
                        }
                    }

                    // Füllworte werden aus der ParseLine geschmissen
                    else if (PTL!.Index(ptlCt)!.O!.GetType() == typeof(Fill))
                    {
                        PTL!.RemoveAt(ptlCt);
                        ptlCt--;
                    }

                    if (!found) break;

                }
            }
            return (found);
        }

        private bool AskAmbigous(List<object> ambiObjects)
        {
            MCMenu mcM = AdvGame!.AdvMCMenu(AdvGame.CA!.Person_I!, false, 1 + AdvGame.CB!.MCE_Choice_Off);
            List<int> follower;
            int idCt = 1;

            // 1
            follower = new List<int>();
            follower.Add(-1);
            mcM.Add(new MCMenuEntry(AdvGame!.CB!.MCE_Text, null, loca.Parse_AskAmbigous_Person_I_16234, idCt++, follower, null, 0, false, false, false, null, null));


            for (int ambiCt = 0; ambiCt < ambiObjects.Count; ambiCt++)
            {
                // Schritt 1: Alle nicht sichtbaren Personen, Items und Topics werden aus der Liste geworfen
                if ((ambiObjects[ambiCt].GetType() == typeof(Person)) )
                {
                    follower = new List<int>();
                    follower.Add(-1);
                    mcM.Add(new MCMenuEntry(AdvGame.CB!.MCE_Text, AdvGame.CA!.Person_I, Persons!.GetPersonName(((Person)ambiObjects[ambiCt]), Co.CASE_NOM, AdvGame.CurrentNouns), idCt++, follower, null, 0, false, false, false, null, null));
                }
                if ((ambiObjects[ambiCt].GetType() == typeof(Item)) )
                {
                    follower = new List<int>();
                    follower.Add(-1);
                    mcM.Add(new MCMenuEntry(AdvGame.CB!.MCE_Text, AdvGame.CA!.Person_I, Items!.GetName(((Item)ambiObjects[ambiCt]).ID, Co.CASE_NOM, AdvGame.CurrentNouns, true), idCt++, follower, null, 0, false, false, false, null, null));
                }
                if ((ambiObjects[ambiCt].GetType() == typeof(Topic)))
                {
                    follower = new List<int>();
                    follower.Add(-1);
                    mcM.Add(new MCMenuEntry(AdvGame.CB!.MCE_Text, AdvGame.CA!.Person_I, Topics!.GetTopicName(((Topic)ambiObjects[ambiCt]).ID, Co.CASE_NOM, AdvGame.CurrentNouns), idCt++, follower, null, 0, false, false, false, null, null));
                }
            }
            follower = new List<int>();
            for (int followerCt = 1; followerCt < idCt; followerCt++)
            {
                follower.Add(followerCt);

            }
            mcM.Add(new MCMenuEntry(AdvGame.CB!.MCE_Choice, null, "", 1 + AdvGame.CB!.MCE_Choice_Off, follower, null, 0, false, false, false, null, null));
            mcM.MCS = mcM.MenuShow();
            mcM.Set(0);
            mcM.MCS.MCOutput(mcM, AskAmbiguousCallback, false);
            AdvGame.Orders!.temporaryMCMenu = mcM;
            AdvGame.Orders.persistentMCMenu = null;

            return true;
        }


        private void StoreItemsInQueue( ParseTokenList ptl)
        {
            foreach( ParseToken pt in ptl.PList!)
            {
                if( pt.O!.GetType() == typeof( Item ))
                {
                    ptl.IQ!.Add((pt.O! as Item)!);
                }
            }
        }

        private bool AskAmbiguousCallback(MCMenu MCM, int Selection)
        {
            bool found = false;

            // Selection = 1 ist immer die Titelzeile, die müssen wir abziehen
            Selection-=2;

            for (int i = 0; i < tPTLNew!.Count(); i++)
            {
                // Es wird nach dem ersten varianten Listeneintrag gesucht. Die Auswahl bezieht sich darauf
                if (tPTLNew!.Index(i)!.O!.GetType() == typeof(List<object>))
                {
                    // Wichtig: Listen mit einem Eintrag werden als "bearbeitet" gewertet und hier nicht berücksichtigt
                    if( ( tPTLNew!.Index(i)!.O as List<object>)!.Count > 1 )
                    {
                        // Hier werden einfach alle Listeneinträge außer dem ausgewählten rausgekantet (indem eine neue, verkürzte Liste mit 
                        // 1 Eintrag generiert wird
                        List<object> loNew = new List<object>();
                        loNew!.Add(((tPTLNew!.Index(i)!.O! as List<object>)![Selection])!);
                        tPTLNew!.Index(i)!.O = loNew;
                        found = true;
                    }

                }

                if (found)
                    break;
            }
            AdvGame!.OutputExit(MCM);

            if (found)
                found = ParseTokensToParseSignatures(tPTLNew, tptlSignatures!, null!, ref tErrorText!);

            if (found)
                found = ResolveAmbiguousParseTokens(tPTLNew, tptlSignatures!, ref tErrorText!);

            // Nun sollte sichergestellt sein, dass sich in ptl nur noch Listen mit 1 Objekt sowie in ptlSignatures nur noch eine Parse-Signatur befindet
            if (found)
            {
                FlatParseTokenList(tPTLNew);

                LatestParseResult = StringVersion(tPTLNew);
                AdvGame.LI[AdvGame.LI.Count - 1].Text = LatestParseResult!;
                
                // Hier wird die echte Eingabe gegen die "wahre" Eingabe ausgetauscht (= Items sauber aufgelöst)
                AdvGame.UIS!.StoryTextObj!.BufferedInput = LatestParseResult;
                // Speichern aller enthaltenen Items in der Queue
                StoreItemsInQueue(tPTLNew );

                if ( tptlSignatures!.List![0]!.ParseMethod!(Persons!.Find(AdvGame!.A!.ActPerson)!, tPTLNew!) )
                {
                    // LatestParseResult = StringVersion(tPTLNew);
                    // latestPTL = tPTLNew;
                    // latestPTLSignatures = tptlSignatures;
                    cbSuccess!(tptlSignatures!);

                }
                else
                {
                    // LatestParseResult = StringVersion(tPTLNew);
                    // AdvGame.LI[AdvGame.LI.Count - 1].Text = LatestParseResult;

                    if (AdvGame.GD!.SilentMode == false)
                    {

                        // These: Die folgende Codestelle ist obsolet. OrderText wurde hier schon anderweitig aktualisiert.
                        if (AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx!]!.OT![AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx!]!.Point!]!.OrderText! != LatestParseResult)
                        {
                        }
                        AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx!]!.OT![AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx!].Point!]!.OrderText = LatestParseResult!;
                        // Ende der These
                    }
                    if( AdvGame.GD!.SilentMode == true)
                    { 
                        OrderTable ot = AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx!].OT![AdvGame!.GD!.OrderList!.OTL![AdvGame!.GD!.OrderList!.CurrentOrderListIx!]!.Point!];
                        // AdvGame.GD!.OrderList.AddOrderCurrentRun(ot.OrderType, ot.orderText, ot.OrderChoice, null, null);
                        AdvGame.GD!.OrderList.AddOrderFeedbackCurrentRun( ot.OrderText, ot.OrderFeedback);
                    }

                }
            }
            if (!found && tErrorText != "")
                AdvGame!.FeedbackOutput(AdvGame!.CA!.Person_Everyone!, tErrorText!);

            // 
            /*
            if (found)
            {
                // Noch weitere unterschiedliche Items in der Liste?
                int parseID = FindInitialParseline(tPTL);

                if (CountAmbiguousEntries(tPTL) > 0)
                {
                    RequestFirstAmbiguous(MCM, tPTL, parseID);
                    found = false;
                }
                else
                {
                    AdvGame.OutputExit(MCM);
                    found = FindFinalParseline(tPTL);
                }
            }
            */

            GD.UIS.InitBrowserUpdate();
            return found;
        }

        // Reduziert alle Objektlisten auf den jeweils ersten Eintrag in der Liste
        // (d.h. sollte erst aufgerufen werden, wenn sichergestellt ist, dass die Listen nicht länger als 1 Eintrag sind)

        private void FlatParseTokenList( ParseTokenList ptl )
        {
            foreach( ParseToken pt in ptl.PList!)
            {
                if( pt.O!.GetType() == typeof( List<object>))
                {
                    pt.O = ((pt.O as List<object>)!)[0]!;
                }
            }
        }
    }

}