using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Phoney_MAUI.Model;
using Phoney_MAUI.Core;

namespace GameCore
{
    [Serializable]

    public class DialogList
    {

        public MCMenu? LatestDialog { get; set; }
        [NonSerialized] 
        [JsonIgnore]

        public DelDialog? func;

        public string? FuncName { get; set; }
    }
    [Serializable]

    public class Person: AbstractAdvObject
    {

        public int locationType { get; set; }

        public int locationID { get; set; }

        public List<int>? UnlockItems { get; set; }

        public bool CanCarryItems { get; set; }

        public int Size { get; set; }

        public int Storage { get; set; }

        public int StorageIn { get; set; }

        public bool CanBeClosed { get; set; }

        public bool CanBeLocked { get; set; }

        public bool IsClosed { get; set; }

        public bool IsLocked { get; set; }

        public bool CanPutIn { get; set; }

        public bool CanBeTaken { get; set; }

        public string? HereTextLoca { get; set; }

        private string? _hereText;
        [JsonIgnore]
        public string? HereText
        {
            get
            {
                return loca.TextOrLoca(_hereText, HereTextLoca);

            }
            set
            {
                _hereText = value; 
            }
        }
        public bool ActivityBlocked { get; set; }
        // public MCMenu LatestDialog { get; set; }

        public List<DialogList>? DialogList { get; set; }

        public bool IsBackground { get; set; }

        public bool IsHidden { get; set; }

        public bool IsRegular { get; set; }

        public bool IsWanderer { get; set; }

        public List<int>? WandererList { get; set; }

        public Person()
        {

        }

        public Person(int pPersonID, List<Noun>? pNames, List<Adj>? pAdjectives, int pSex, int plocationType, int plocationID, string? pDescription, int pSize, bool pCanCarryItems, DelAdvObject? pPersonController, NounList? pNouns, AdjList? pAdjs)
                        : base(pPersonID, pNames, null, pAdjectives, null, pSex, pDescription, true, pPersonController, pNouns, pAdjs)

        {
            /*
            PersonID = pPersonID;
            Sex = pSex;
            Description = pDescription;
            Adjectives = new List<int>();
            SynAdjectives = new List<int>();
            SynNames = new List<int>();
            Active = true;
            PersonController = pPersonController;

            foreach (var element in pAdjectives)
            {
                Adjectives.Add(element);
            }

            Names = new List<int>();
            foreach (var element in pNames)
            {
                Names.Add(element);
            }
            */
            locationType = plocationType;
            locationID = plocationID;
            CanCarryItems = pCanCarryItems;
            Size = pSize;
            CanBeLocked = false;
            CanBeClosed = false;
            IsClosed = false;
            IsLocked = false;
            CanPutIn = false;
            CanBeTaken = false;
            UnlockItems = new List<int>();
            DialogList = new List<DialogList>();
            IsBackground = false;
            IsHidden = false;
            IsRegular = true;
        }

         public Person(List<Noun>? pNames, List<Adj>? pAdjectives, int pSex, int plocationType, int plocationID, string? pDescription, int pSize, bool pCanCarryItems, DelAdvObject? pPersonController, NounList? pNouns, AdjList? pAdjs)
                : this(SerialNumberGenerator.Instance.NextSerial, pNames, pAdjectives, pSex, plocationType, plocationID, pDescription, pSize, pCanCarryItems, pPersonController, pNouns, pAdjs)

        {
        }

        public static Person PersonLoca(int pItemID, List<Noun>? pNames, List<Adj>? pAdjectives, int pSex, int plocationType, int plocationID, string? pDescription, int pSize, bool pCanCarryItems, DelAdvObject? pPersonController, NounList? pNouns, AdjList? pAdjs )
        {
            Person pe = new Person(pItemID, pNames, pAdjectives, pSex, plocationType, plocationID, null, pSize, pCanCarryItems, pPersonController, pNouns, pAdjs );
            pe.LocaDescription = pDescription;
            pe.Description = Helper.Insert(pDescription);

            return (pe);
        }
         public static Person PersonLoca (List<Noun>? pNames, List<Adj>? pAdjectives, int pSex, int plocationType, int plocationID, string? pDescription, int pSize, bool pCanCarryItems, DelAdvObject? pPersonController, NounList? pNouns, AdjList? pAdjs)
        {
            return PersonLoca(SerialNumberGenerator.Instance.NextSerial, pNames, pAdjectives, pSex, plocationType, plocationID, pDescription, pSize, pCanCarryItems, pPersonController, pNouns, pAdjs);

        }


        public void SetLatestDialog( MCMenu M, DelDialog Func )
        {
            bool handled = false;

            if (DialogList != null)
            {
                foreach (DialogList dl in DialogList)
                {
                    if (dl.func == Func)
                    {
                        dl.LatestDialog = M;
                        handled = true;
                        break;
                    }
                }
            }

            if ( !handled)
            {
                DialogList!.Add(new DialogList() { LatestDialog = M, func = Func});
                DialogList[DialogList.Count - 1]!.FuncName = Func.Method.Name;
            }
        }


        public MCMenu? GetLatestDialog( DelDialog Func, object o )
        {
            MCMenu? m = null;

            if (DialogList != null)
            {
                foreach (DialogList dl in DialogList)
                {
                    if (dl.func == null && dl.FuncName != null)
                    {
                        dl.func = (DelDialog)Delegate.CreateDelegate(typeof(DelDialog), o, dl.FuncName, false);

                    }

                    if (dl.func == Func)
                    {
                        m = dl.LatestDialog;
                        break;
                    }
                }
            }

            return (m);
        }

        public Person Clone()
        {
            Person p = (Person)this.MemberwiseClone();
            return p;
        }

        public int GetLoc()
        {
            return ((locationType * 65536) + locationID);
        }

        public string? FullName(AbstractAdvObject AO, int Case, bool ShowAppendix = false)
        {
            return base.FullName(AO, Case, false, ShowAppendix, false);
        }

        public string? FullName(int Case,bool ShowAppendix = false)
        {
            return base.FullName(this, Case, false, ShowAppendix, false);
        }
    }
    [Serializable]

    public class PersonList: AbstractAdvObjectList<AdvObject>
    {

        // public Dictionary<int, Person> List { get; set; }
        new public IDictionary<int, Person>? List
        {
            get
            {
                if (loca.GD?.Language == IGlobalData.language.english)
                {
                    return (ListE);
                }
                else
                {
                    return (ListD);

                }
            }
            set
            {
                if (loca.GD!.Language == IGlobalData.language.english)
                {
                    ListE = value;
                }
                else
                {
                    ListD = value;
                }
            }
        }
        public IDictionary<int, Person>? ListE { get; set; }
        public IDictionary<int, Person>? ListD { get; set; }


#pragma warning restore CS0108 // "PersonList.List" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.List" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.

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
            // set => GD.Adventure.A = value;
        }
        // public AdvData A { get; set; }

        [JsonIgnore]
        public ItemList? Items
        {
            get => GD!.Adventure!.Items;
            // set => GD.Adventure.Items = value;
        }
        // public ItemList Items { get; set; }
        [JsonIgnore]
        public Adv? AdvGame
        {
            get => GD!.Adventure!;
            // set => GD.Adventure = value;
        }
        // [JsonIgnore] [NonSerialized]  private Adv AdvGame;
        // private Grammar DoGrammar;

        private Person? _lastPerson= null;


        public PersonList( Adv AdvGame, AdvData A, ItemList Items, int size = -1 ) : base()
        {
            // this.A = A;
            // this.Items = Items;
            // this.AdvGame = AdvGame;

            if (size != -1)
                this.List = new Dictionary<int, Person>(size);
            // this.DoGrammar = DoGrammar;
            loca.GD?.AddLanguageCallback(RestorePersons);
        }


        public void SetAdv( Adv AdvGame )
        {
            // this.AdvGame = AdvGame;
        }
#pragma warning disable CS0108 // "PersonList.Last()" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.Last()" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.

        public Person? Last()
#pragma warning restore CS0108 // "PersonList.Last()" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.Last()" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        {
            return _lastPerson;
            // return (List[List.Values.Count - 1]);
        }

        public Person Add(Person I)
        {
            if (List == null)
            {
                List = new Dictionary<int, Person>();
            }
            // new this.GetType().GetConstructor();
            List.Add(key: I.ID, value: I);
            _lastPerson = I;
            return (I);
            // base.Add((AdvObject)I);
        }
#pragma warning disable CS0108 // "PersonList.Find(int)" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.Find(int)" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.

        public Person? Find(int ID)
#pragma warning restore CS0108 // "PersonList.Find(int)" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.Find(int)" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        {
            if (List!.ContainsKey(ID))
                return List[ID];
            return null;
/*
            Person ret = null;

            foreach (Person ele 
                in List)
            {
                if (ele.ID == ID)
                {
                    ret = ele;
                }
                if (ret != null) break;
            }
            return ret;
*/
        }

        public Person? Find(Person p )
        {
            if (p == null) 
                return null;
            if (List!.ContainsKey(p.ID))
                return List[p.ID];
            return null;
/*
            Person ret = null;

            if ( p == null )
                return ret;

            foreach (Person ele
                in List)
            {
                if (ele.ID == p.ID )
                {
                    ret = ele;
                }
                if (ret != null) break;
            }
            return ret;
*/
        }
#pragma warning disable CS0108 // "PersonList.FindIx(int)" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.FindIx(int)" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        public List<Person>? FindByName(Person p)
        {
            List<Person> PDest = new();


            if (p == null)
                return PDest;


            foreach( Person p2 in this!.List!.Values )
            {
                bool identical = true;
                foreach( Adj a in p!.Adjectives!)
                {
                    int ix;
                    bool found = false;
                    for( ix = 0; ix < p2!.Adjectives!.Count; ix++)
                    {
                        if( a.ID == p2.Adjectives[ix].ID)
                        {
                            found = true;
                            break;
                        }
                    }
                    if( !found)
                    {

                        for (ix = 0; ix < p2!.SynAdjectives!.Count; ix++)
                        {
                            if (a.ID == p2.SynAdjectives[ix].ID)
                            {
                                found = true;
                                break;
                            }
                        }
                    }
                    if (!found)
                        identical = false;
                }
                foreach (Noun n in p!.Names!)
                {
                    int ix;
                    bool found = false;
                    for (ix = 0; ix < p2.Names!.Count; ix++)
                    {
                        if (n.ID == p2.Names[ix].ID)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {

                        for (ix = 0; ix < p2.SynNames!.Count; ix++)
                        {
                            if (n.ID == p2.SynNames[ix].ID)
                            {
                                found = true;
                                break;
                            }
                        }
                    }
                    if (!found)
                        identical = false;
                }

                if( identical )
                {
                    PDest.Add(p2);
                }
            }
            return PDest;
        }
        public int FindIx(int ID)
#pragma warning restore CS0108 // "PersonList.FindIx(int)" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.FindIx(int)" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        {
            /*
            if (List.ContainsKey(ID))
                return List[ID];
            return null;
            */

            int index = -1;

            for (int i = 0; i < List!.Count; i++)
            {
                if (List[i].ID == ID)
                {
                    index = i;
                }
                if (index > -1) break;
            }
            return index;

        }

        public int GetLoc( int PersonID )
        {
            int loc = -1;

            if ( Find( PersonID ) != null  )
            {
                loc = Find(PersonID)!.locationID;
            }
            return loc;
        }

        public int GetLoc(Person p )
        {
            int loc = -1;

            if (Find(p ) != null)
            {
                loc = p.locationID;
            }
            return loc;
        }

        public string GetPersonNameLink(string s, Person PersonID)
        {
#if CHROMIUM
            // Noloca: 002
            string scr = System.Web.HttpUtility.HtmlEncode( "boundAsync.JSCallback(\"Person: " + $"{PersonID.ID:00000}\");");
            // Ignores: 003
            // Noloca: 003
            s = "<a style='cursor:pointer' onclick='" +scr + "'>" +s + "</a>";
#elif MAUI
            string scr = System.Web.HttpUtility.HtmlEncode("window.location.href = 'https://defineobject.Person/" + $"{PersonID:00000}';");

            s = "<a style='cursor:pointer' onclick='" + scr + "'>" + s + "</a>";
#else
            // Ignores: 003
            // Noloca: 003
            s = "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback( 'Person: " + $"{PersonID.ID:00000}' );\"></a>";
#endif

            return (s);
        }

        public string SetPersonLink( string s, Person PersonID, string PersonText )
        {
#if CHROMIUM
            // Noloca: 002
            string scr = System.Web.HttpUtility.HtmlEncode( "boundAsync.JSCallback(\"Person: " + $"{PersonID.ID:00000}\");");
            // Ignores: 003
            // Noloca: 003
            s = "<a style='cursor:pointer' onclick='" +scr + ">" +PersonText + "</a>";
#elif MAUI
            string scr = System.Web.HttpUtility.HtmlEncode("window.location.href = 'https://defineobject.Person/" + $"{PersonID:00000}';");
            s = "<a style='cursor:pointer' onclick='" + scr + ">" + PersonText + "</a>";

#else
            // Ignores: 003
            // Noloca: 003
            s = "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback( 'Person: " + $"{PersonID.ID:00000}' );\"></a>";
#endif

            return (s);

        }

        public bool DoNPCs()
        {
            bool success = true;

            foreach (Person p in this!.List!.Values)
            {
                if (( p.GetController( AdvGame!) != null) && ( !p.ActivityBlocked) )
                {
                    p!.GetController(AdvGame!)!(p!.locationID!);
                }
            }
            return (success);
        }

 
        public string? GetPersonName(Person? PersonID, int Case)
        {
            if (PersonID == A!.Adventure!.CA!.Person_I) return (loca.Adv_InitializeGame_Person_I_3487);
            else if (PersonID == A.Adventure!.CA!.Person_You) return ( loca.PersonList_GetPersonName_Person_You_16235);
            // else return (this.List[this.FindIx(PersonID)].FullName(this.Find(PersonID), Case));#

            // Dieser Code hier lief plötzlich nicht mehr mit den neuen Inserts. Problem: die Persons-Liste ist komplett 
            // veraltet
            // else return (PersonID.FullName(this.Find(PersonID), Case));
            else return (PersonID!.FullName(PersonID, Case));
        }

        public string GetPersonVerb(Person PersonID, int Case, int VerbID, int Tense)
        {
            // string s = GetPersonName(PersonID, Case) +  Helper.Insert(" [VP:,1]", PersonID );
            // Noloca: 001
            string s = GetPersonName(PersonID, Case) + Helper.Insert(" [VP1,2]", PersonID, VerbID);
            return s;
        }

        public string GetPersonVerbLink(Person PersonID, int Case, int VerbID, int Tense)
        {
            // Noloca: 001
            string s = this.GetPersonNameLink( PersonID, Case) +  Helper.Insert(" [VP1,2]", PersonID, VerbID );
            return s;
        }
        /*
        public bool IsPersonHere( Person PersonID, int Mode )
        {
            return (IsPersonHere(Find(PersonID), Mode));
        }
        */

        public bool IsPersonHere(Person? P, int Mode, bool waitForWanderer = false)
        {
            bool foundPerson = false;

            if (Mode == Co.Range_Here)
            {
                if( waitForWanderer )
                {
                    AdvGame!.WaitForWanderer(P, A!.ActLoc);
                }
                if ((P!.locationType == Co.CB!.LocType_Person) && (P!.locationID == A!.ActPerson))
                    foundPerson = true;

                if ((P!.locationType == Co.CB!.LocType_Loc) && (P!.locationID == A!.ActLoc))
                    foundPerson = true;

                if (!foundPerson)
                {
                    if (P!.locationType == Co.CB!.LocType_In_Item)
                    {
                        if (P!.locationID != 0)
                        {
                            Item item2 = Items!.Find(P!.locationID)!;

                            if ((item2.CanBeClosed == false) || (item2.IsClosed == false))
                            {
                                foundPerson = Items!.IsItemHere(item2, Co.Range_Here);
                            }
                        }
                        else
                        {
                            foundPerson = false; 
                        }
                    }
                    else if ((P.locationType == Co.CB!.LocType_Below_Item)
                                || (P.locationType == Co.CB!.LocType_On_Item)
                                || (P.locationType == Co.CB!.LocType_Beside_Item)
                                || (P.locationType == Co.CB!.LocType_Behind_Item)
                            )
                    {
                        Item item2 = Items!.Find( P.locationID)!;
                        foundPerson = Items!.IsItemHere(item2, Co.Range_Here);
                    }
                    else if ((P.locationType == Co.CB!.LocType_In_Person)
                                || (P.locationType == Co.CB!.LocType_To_Person)
                            )
                    {
                        Person person2 = this!.Find( P!.locationID)!;
                        foundPerson = IsPersonHere(person2, Mode);
                    }
                }
            }
            else if (Mode == Co.Range_Visible)
            {
                if ((P!.locationType == Co.CB!.LocType_Person) && (P!.locationID == A!.ActPerson))
                    foundPerson = true;

                if ((P!.locationType == Co.CB!.LocType_Loc) && (P!.locationID == A!.ActLoc))
                    foundPerson = true;

                if (!foundPerson)
                {
                    if (P!.locationType == Co.CB!.LocType_In_Item)
                    {
                        Item item2 = Items!.Find(P!.locationID)!;
                        if (item2 !=null)
                        {
                            if ((item2.CanBeClosed == false) || (item2.IsClosed == false) || (item2.IsCage == true))
                            {
                                foundPerson = Items!.IsItemHere(item2, Co.Range_Here);
                            }
                        }
                    }
                    else if ((P!.locationType == Co.CB!.LocType_Below_Item)
                                || (P!.locationType == Co.CB!.LocType_On_Item)
                                || (P!.locationType == Co.CB!.LocType_Beside_Item)
                                || (P!.locationType == Co.CB!.LocType_Behind_Item)
                            )
                    {
                        Item item2 = Items!.Find(P!.locationID)!;
                        foundPerson = Items!.IsItemHere(item2, Co.Range_Here);
                    }
                    else if ((P.locationType == Co.CB!.LocType_In_Person)
                                || (P.locationType == Co.CB!.LocType_To_Person)
                            )
                    {
                        Person person2 = this!.Find(P.locationID)!;
                        foundPerson = IsPersonHere(person2, Mode);
                    }
                }
            }
            else if (Mode == Co.Range_Active)
            {
                if (P!.Active)
                    foundPerson = true;
            }
            else if (Mode == Co.Range_Known)
            {
                if (P!.Known)
                    foundPerson = true;
            }
            else
            {
                foundPerson = true;
            }

            return (foundPerson);
        }

        public bool IsPersonLoc( int PersonID, int locationType, int locationID )
        {
            return (IsPersonLoc(Find(PersonID), locationType, locationID));
        }

        public bool IsPersonLoc(Person? P, int locationType, int locationID )
        {
            bool foundPerson = false;

            if ((P!.locationType == locationType) && (P!.locationID == locationID))
                foundPerson = true;


            return foundPerson;
        }


        public bool TransferPerson(int PersonID, int plocationType, int plocationID)
        {
            return TransferPerson(Find(PersonID), plocationType, plocationID);
        }



        private bool TransferPerson(Person? P, int plocationType, int plocationID)
        {
            if (P!.locationType == Co.CB!.LocType_In_Item)
            {
                Item item2 = Items!.Find(P.locationID)!;
                if( item2 !=null )
                    item2.StorageIn += P.Size;

            }
            else if (P.locationType == Co.CB!.LocType_On_Item)
            {
                Item item2 = Items!.Find(P.locationID)!;
                if (item2 !=null)
                    item2.StorageOn += P.Size;
            }
            else if (P.locationType == Co.CB!.LocType_Below_Item)
            {
                Item item2 = Items!.Find(P!.locationID)!;
                if (item2 !=null)
                    item2.StorageBelow += P.Size;
            }
            else if (P.locationType == Co.CB!.LocType_Behind_Item)
            {
                Item item2 = Items!.Find(P!.locationID)!;
                if (item2 !=null)
                    item2.StorageBehind += P.Size;
            }
            else if (P.locationType == Co.CB!.LocType_Beside_Item)
            {
                Item item2 = Items!.Find(P!.locationID)!;
                if (item2 !=null)
                    item2.StorageBeside += P.Size;
            }

            P.locationType = plocationType;
            P.locationID = plocationID;

            if( P.ID == A!.ActPerson )
            {
                A!.ActLoc = P.locationID;
            }

            if (P.locationType == Co.CB!.LocType_In_Item)
            {
                Item item2 = Items!.Find(plocationID)!;
                item2.StorageIn -= P!.Size;
            }
            else if (P.locationType == Co.CB!.LocType_On_Item)
            {
                Item item2 = Items!.Find(plocationID)!;
                item2.StorageOn -= P!.Size;
            }
            else if (P.locationType == Co.CB!.LocType_Below_Item)
            {
                Item item2 = Items!.Find(plocationID)!;
                item2.StorageBelow -= P!.Size;
            }
            else if (P.locationType == Co.CB!.LocType_Behind_Item)
            {
                Item item2 = Items!.Find(plocationID)!;
                item2.StorageBehind -= P!.Size;
            }
            else if (P.locationType == Co.CB!.LocType_Beside_Item)
            {
                Item item2 = Items!.Find(plocationID)!;
                item2.StorageBeside -= P!.Size;
            }

            /* Unnötig, denn am Ende der Bearbeitungssequenz wird sowieso immer DoUIUpdate() aufgerufen
            if( P!.ID == A!.ActPerson)
                AdvGame.DoUIUpdate();
            */
            return (true);
        }

        public int GetPersonIx(int PersonID)
        {
            int rPersonIX = 0;
            for (int i = 0; i < this!.List!.Count; i++)
            {
                if (this.List[i].ID == PersonID)
                {
                    rPersonIX = i;
                }
            }
            return (rPersonIX);
        }

        public string GetPersonNameLink(Person PersonID, int Case)
        {
            string? s = this.GetPersonName(PersonID, Case);

            if( s != loca.PersonList_GetPersonNameLink_16236 )
            {
#if CHROMIUM
                // Noloca: 002
                string scr = System.Web.HttpUtility.HtmlEncode( "boundAsync.JSCallback(\"Person: " + $"{PersonID.ID:00000}\");");
                // Ignores: 003
                // Noloca: 003
                s = "<a style='cursor:pointer' class='class1' onclick='" +scr + "'>" +s + "</a>";
#elif MAUI
                string scr = System.Web.HttpUtility.HtmlEncode( "boundAsync.JSCallback(\"Person: " + $"{PersonID.ID:00000}\");");
                s = "<a style='cursor:pointer' class='class1' onclick='" +scr + "'>" +s + "</a>";
#else
                // Ignores: 003
                // Noloca: 003
                s = "<a style=\"cursor:pointer\" href=\"https:www.spiegel.de\" class=\"class1\" onclick=\"window.external.JSCallback( 'Person: " + $"{PersonID.ID:00000}' );\"></a>";
#endif
            }
            else
            {
#if CHROMIUM
                // Noloca: 002
                string scr = System.Web.HttpUtility.HtmlEncode( "boundAsync.JSCallback(\"Person: " + $"{PersonID.ID:00000}\");");
                // Ignores: 003
                // Noloca: 003
                s = "<a style='cursor:pointer' onclick='" +scr + "'>" +s + "</a>";
#elif MAUI
                string scr = System.Web.HttpUtility.HtmlEncode( "boundAsync.JSCallback(\"Person: " + $"{PersonID.ID:00000}\");");
                s = "<a style='cursor:pointer' onclick='" +scr + "'>" +s + "</a>";
#else
                // Ignores: 003
                // Noloca: 002
                s = "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback( 'Person: " + $"{PersonID.ID:00000}' );\"></a>";
#endif
            }
            return (s);
        }

        public string GetPersonLink(Person? PersonID, string? desc )
        {
            string? s = this.GetPersonName(PersonID, Co.CASE_NOM);

            // Noloca: 001
            if (s != "ich")
            {
#if CHROMIUM

                // Noloca: 002
                string scr = System.Web.HttpUtility.HtmlEncode( "boundAsync.JSCallback(\"Person: " + $"{PersonID!.ID:00000}\");");
            // Ignores: 003
                 s = loca.PersonList_GetPersonLink_16237 +scr + loca.PersonList_GetPersonLink_16238 +desc + loca.PersonList_GetPersonLink_16239;
#else
                // Ignores: 003
                // Noloca: 003
                s = "<a style=\"cursor:pointer\" class=\"class1\" onclick=\"window.external.JSCallback( 'Person: " + $"{PersonID!.ID:00000}' );\">" + desc + "</a>";
                // s = "<a style=\"cursor:pointer\" class=\"class1\" onclick=\"window.external.JSCallback( 'Person: " + $"{PersonID!.ID:00000}' );\"></a>";
#endif
            }
            else
            {
#if CHROMIUM
                // Noloca: 002
                string scr = System.Web.HttpUtility.HtmlEncode( "boundAsync.JSCallback(\"Person: " + $"{PersonID!.ID:00000}\");");
                // Ignores: 003
                // Noloca: 003
                s = "<a style='cursor:pointer' onclick='" +scr + "'>" +desc + "</a>";
#else
                // Ignores: 003
                s = loca.PersonList_GetPersonLink_16240 + loca.PersonList_GetPersonLink_16241;
#endif
            }
            return (s);
        }

        public bool ListPersons(int LocType, int LocID, int OutputLocID )
        {
            foreach (Person tPerson in this!.List!.Values)
            {
                if (tPerson.locationType == LocType && tPerson.locationID == LocID && tPerson.ID != A!.ActPerson)
                {
                    if ((tPerson.HereText != "") && (tPerson.HereText != null))
                        AdvGame!.StoryOutput(OutputLocID, A.Adventure!.CA!.Person_Everyone, GetPersonNameLink(tPerson.HereText, tPerson ));
                    else if ( !tPerson.IsHidden)
                        AdvGame!.StoryOutput(OutputLocID, A.Adventure!.CA!.Person_Everyone, GetPersonVerbLink(tPerson, Co.CASE_AKK, Co.CB!.VT_sein, A.Tense) + loca.PersonList_ListPersons_Person_Everyone_16242);

                }
            }
            return (true);
        }

        public int FindContainers(int Loc, int Where, List<PI> il)
        {
            int Ct = 0;

            for (int i = 0; i < List!.Count; i++)
            {
                Person person = Find(List[i].ID)!;
                if ((Where == AdvGame!.CB!.LocType_In_Item) && (Loc == Co.GenerateLoc(person)) && (person.CanPutIn) && ((person.CanBeClosed == false) || (person.IsClosed == false)))
                {
                    Ct++;
                    il.Add(new PI(PI.TypeVal.Person, person.ID));
                }
            }
            return Ct;
        }


        public int LocOnly( Person PersonID )
        {
            return (Find(PersonID)!.locationID);
        }

        public (int lType, int lID) GetPersonLoc(Person? person, bool findSelf = false )
        {
            (int _lType, int _lID) loc;

            if (person!.IsRegular == false && ( findSelf == false || person!.locationID <= 0 ) )
            {
                loc._lType = Co.CB!.LocType_Loc;
                loc._lID = -1;
            }
            else if (person.locationType == Co.CB!.LocType_In_Item)
            {
                loc = this.Items!.GetItemLoc(this.Items!.Find(person.locationID));
            }
            else if (person.locationType == Co.CB!.LocType_Behind_Item)
            {
                loc = this.Items!.GetItemLoc(this.Items!.Find(person.locationID));
            }
            else if (person.locationType == Co.CB!.LocType_Below_Item)
            {
                loc = this.Items!.GetItemLoc(this.Items!.Find(person.locationID));
            }
            else if (person.locationType == Co.CB!.LocType_Beside_Item)
            {
                loc = this.Items!.GetItemLoc(this.Items!.Find(person.locationID));
            }
            else if (person.locationType == Co.CB!.LocType_On_Item)
            {
                loc = this.Items!.GetItemLoc(this.Items!.Find(person.locationID));
            }
            else if (person.locationType == Co.CB!.LocType_In_Person)
            {
                loc = this.GetPersonLoc(this.Find(person.locationID));
            }
            else if (person.locationType == Co.CB!.LocType_Person)
            {
                loc = this.GetPersonLoc(this.Find(person.locationID));
            }
            else if (person.locationType == Co.CB!.LocType_To_Person)
            {
                loc = this.GetPersonLoc(this.Find(person.locationID));
            }
            else
            {
                loc._lType = Co.CB!.LocType_Loc;
                loc._lID = person.locationID;
            }

            return (loc);

        }

        public bool RestorePersonList( )
        {
            IDictionary<int, Person>? TList2 = new Dictionary<int, Person>();

            foreach (var ele in ListD!.Values)
            {
                Person ele2 = (Person)ele;

                TList2.Add(key: ele2.ID, value: ele2);
                // TList2.Add(key: ele2.Name, value: ele2);
            }
            List = TList2;
            TList2 = null;
            return true;
        }
        public bool RestorePersons()
        {
            if (loca.GD!.Language == IGlobalData.language.english && ListE == null)
            {
                IDictionary<int, Person>? TList2 = new Dictionary<int, Person>();

                foreach (var ele in ListD!.Values)
                {
                    Person ele2 = (Person)ele;

                    TList2.Add(key: ele2.ID, value: ele2);
                    // TList2.Add(key: ele2.Name, value: ele2);
                }
                ListE = TList2;
                TList2 = null;

            }
            if (loca.GD!.Language == IGlobalData.language.german && ListD == null)
            {
                IDictionary<int, Person>? TList2 = new Dictionary<int, Person>();

                foreach (var ele in ListE!.Values)
                {
                    Person ele2 = (Person)ele;

                    TList2.Add(key: ele2.ID, value: ele2);
                    // TList2.Add(key: ele2.Name, value: ele2);
                }
                ListD = TList2;
                TList2 = null;

            }

            return true;

            /*
            IDictionary<int, Person> TList2 = new Dictionary<int, Person>();

            foreach (var ele in List.Values)
            {
                Person ele2 = (Person)ele;

                if (ele2.LocaDescription != null)
                    ele2.Description = Helper.Insert(loca.GetLoca(ele2.LocaDescription));


                TList2.Add(key: ele2.ID, value: ele2);

            }
            List = (Dictionary<int, Person>)TList2;
            TList2 = null;

            return true;
            */
        }
    }
}