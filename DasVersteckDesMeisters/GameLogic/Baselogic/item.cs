using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Phoney_MAUI.Model;
using Phoney_MAUI.Core;

namespace GameCore
{
    [Serializable]

    public class Item: AbstractAdvObject
    {
        /*
        public int ItemID { get; set; }
        public int Names { get; set; }
        public List<int> SynNames { get; set; }
        public List<int> Adjectives { get; set; }
        public List<int> SynAdjectives { get; set; }
        public int Sex { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        */

        public int locationType { get; set; }

        public int locationID { get; set; }

        public bool CanBeClosed { get; set; }

        public bool CanBeLocked { get; set; }

        public bool IsClosed { get; set; }

        public bool IsLocked { get; set; }

        public bool IsCage { get; set; }

        public bool CanPutIn { get; set; }

        public bool ListInsideItems{ get; set; }

        public bool CanPutBehind { get; set; }

        public bool CanPutBelow { get; set; }

        public bool CanPutOn { get; set; }

        public bool CanPutBeside { get; set; }

        public bool InvisibleIn { get; set;  }

        public bool InvisibleBehind { get; set; }

        public bool InvisibleBelow { get; set; }

        public bool InvisibleOn { get; set; }

        public bool InvisibleBeside { get; set; }

        public bool IsDressed { get; set; }

        public bool Dressable { get; set; }

        public bool IsRegular { get; set; }

        public bool IsMovable { get; set; }


        new public bool IsCountable
        {   get { return base.IsCountable;  } 
            set { base.IsCountable = value; } 
        }

        public bool IsBackground { get; set; }

        public bool IsMentionable { get; set; }

        public bool IsLessImportant { get; set; }

        public bool CanBeTaken { get; set; }

        public List<int>? UnlockItems { get; set; }

        public int Size { get; set; }

        public int StorageIn { get; set; }

        public int StorageBehind { get; set; }

        public int StorageBelow { get; set; }

        public int StorageBeside { get; set; }

        public int StorageOn { get; set; }

        public bool ShowStorageOn { get; set; }

        public bool ShowStorageIn { get; set; }

        public bool IsHidden{ get; set; }

        public bool locationStatic { get; set; }

        public Item()
        {

        }


        public Item(int pItemID, List<Noun>? pNames, List<Adj>? pAdjectives, int pSex, int plocationType, int plocationID, string? pDescription, int pSize, bool pIsBackground, bool pCanBeTaken, NounList? pNouns, AdjList? pAdjs)
            : base(pItemID, pNames, null, pAdjectives, null, pSex, pDescription, true, null, pNouns, pAdjs)
        {

            // ItemID = pItemID;
            // Names = pNames;
            // Sex = pSex;
            // Description = pDescription;
            // Adjectives = new List<int>();
            // SynAdjectives = new List<int>();
            // SynNames = new List<int>();
            // Active = true;

            // foreach (var element in pAdjectives)
            // {
            // Adjectives.Add(element);
            // }
            locationType = plocationType;
            locationID = plocationID;
            IsBackground = pIsBackground;
            IsMentionable = true;
            CanBeTaken = pCanBeTaken;
            Size = pSize;
            UnlockItems = new List<int>();
            InvisibleBehind = true;
            InvisibleBelow = true;
            IsCage = false;
            IsHidden = false;
            IsRegular = true;
            IsCountable = true;
        }

        public Item(List<Noun>? pNames, List<Adj>? pAdjectives, int pSex, int plocationType, int plocationID, string? pDescription, int pSize, bool pIsBackground, bool pCanBeTaken, NounList? pNouns, AdjList? pAdjs)
                 : this(SerialNumberGenerator.Instance.NextSerial, pNames, pAdjectives, pSex, plocationType, plocationID, pDescription, pSize, pIsBackground, pCanBeTaken, pNouns, pAdjs)

        {
        }


        public static Item ItemLoca(int pItemID, List<Noun>? pNames, List<Adj>? pAdjectives, int pSex, int plocationType, int plocationID, string pDescription, int pSize, bool pIsBackground, bool pCanBeTaken, NounList? pNouns, AdjList? pAdjs)
        {
            Item it = new Item( pItemID, pNames, pAdjectives, pSex, plocationType, plocationID, null, pSize, pIsBackground, pCanBeTaken, pNouns, pAdjs);
            it.LocaDescription = pDescription;
            it.Description = Helper.Insert( pDescription );

            int sexEng;

            if (pSex == Co.SEX_MALE || pSex == Co.SEX_FEMALE || pSex == Co.SEX_NEUTER)
                sexEng = Co.SEX_NEUTER;
            else
                sexEng = Co.SEX_NEUTER_PL;

            it.SexEng = sexEng;

            return (it);
            // ItemID = pItemID;
            // Names = pNames;
            // Sex = pSex;
            // Description = pDescription;
            // Adjectives = new List<int>();
            // SynAdjectives = new List<int>();
            // SynNames = new List<int>();
            // Active = true;

            // foreach (var element in pAdjectives)
            // {
            // Adjectives.Add(element);
            // }
        }
        public static Item ItemLocaLoca(int pItemID, List<Noun>? pNames, List<Adj>? pAdjectives, int pSex, int plocationType, int plocationID, string pDescriptionHandle, string pDescription, int pSize, bool pIsBackground, bool pCanBeTaken, NounList? pNouns, AdjList? pAdjs)
        {
            Item it = new Item(pItemID, pNames, pAdjectives, pSex, plocationType, plocationID, null, pSize, pIsBackground, pCanBeTaken, pNouns, pAdjs);
            it.LocaDescriptionHandle = pDescriptionHandle;
            it.LocaDescription = pDescription;
            // it.Description = Helper.Insert(pDescription);

            int sexEng;

            if (pSex == Co.SEX_MALE || pSex == Co.SEX_FEMALE || pSex == Co.SEX_NEUTER)
                sexEng = Co.SEX_NEUTER;
            else
                sexEng = Co.SEX_NEUTER_PL;

            it.SexEng = sexEng;

            return (it);
            // ItemID = pItemID;
            // Names = pNames;
            // Sex = pSex;
            // Description = pDescription;
            // Adjectives = new List<int>();
            // SynAdjectives = new List<int>();
            // SynNames = new List<int>();
            // Active = true;

            // foreach (var element in pAdjectives)
            // {
            // Adjectives.Add(element);
            // }
        }
        public static Item ItemLoca(List<Noun>? pNames, List<Adj>? pAdjectives, int pSex, int plocationType, int plocationID, string pDescription, int pSize, bool pIsBackground, bool pCanBeTaken, NounList? pNouns, AdjList? pAdjs)

        {
            return (ItemLoca(SerialNumberGenerator.Instance.NextSerial, pNames, pAdjectives, pSex, plocationType, plocationID, pDescription, pSize, pIsBackground, pCanBeTaken, pNouns, pAdjs));
        }

        public static Item ItemLocaLoca(List<Noun>? pNames, List<Adj>? pAdjectives, int pSex, int plocationType, int plocationID, string pDescriptionHandle, string pDescription, int pSize, bool pIsBackground, bool pCanBeTaken, NounList? pNouns, AdjList? pAdjs)

        {
            return (ItemLocaLoca(SerialNumberGenerator.Instance.NextSerial, pNames, pAdjectives, pSex, plocationType, plocationID, pDescriptionHandle, pDescription, pSize, pIsBackground, pCanBeTaken, pNouns, pAdjs));
        }


        public Item Clone()
        {
            Item i = (Item) this.MemberwiseClone();
            return i;
        }

        public bool SetLoc( int locationType, int locationID )
        {
            this.locationType = locationType;
            this.locationID = locationID;
            
            return (true);
        }

        public string? FullName(AbstractAdvObject AO, int Case, List<Noun> CurrentNouns, bool ShowAppendix = false)
        {
            return base.FullName(AO, Case, CurrentNouns, true, ShowAppendix, false);
        }

        public string? FullName(int Case, List<Noun> CurrentNouns, bool ShowAppendix = false)
        {
            string? fName = base.FullName(this, Case, CurrentNouns, true, ShowAppendix, false);
            if (ShowAppendix && this.IsDressed)
            {
                fName = fName + loca.ItemList_GetName_16123;
            }

            return fName;
        }

        public int GetLoc( )
        {
            return ((locationType * 65536) + locationID);
        }
    }


    public class PI
    {

        public enum TypeVal { Item, Person }

        public TypeVal Type;

        public int ID;


        public PI( TypeVal Type, int ID )
        {
            this.Type = Type;
            this.ID = ID;
        }
    }

    [Serializable]

    public class ItemList: AbstractAdvObjectList<AdvObject>
    {
#pragma warning disable CS0108 // "ItemList.List" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.List" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.



#pragma warning restore CS0108 // "ItemList.List" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.List" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.

        new public IDictionary<int, Item>? List
        {
            get
            {
                if (loca.GD!.Language == IGlobalData.language.english)
                {
                    return (ListE!);
                }
                else
                {
                    return (ListD!);

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
        public IDictionary<int, Item>? ListE { get; set; }
        public IDictionary<int, Item>? ListD { get; set; }

        List<KeyValuePair<int, Item>>? ItemBuffer = null;


        [JsonIgnore] public IDictionary<int, Item>? ListTemp;
        public bool InitToTemp;

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
        [JsonIgnore]
        public PersonList? Persons
        {
            get => GD!.Adventure!.Persons;
            // set => GD.Adventure.Persons = value;
        }
        [JsonIgnore]
        public Adv? AdvGame
        {
            get => GD!.Adventure;
            // set => GD.Adventure = value;
        }
        public void SetupItemBuffer(int size)
        {
            ItemBuffer = new List<KeyValuePair<int, Item>>(size);
        }
        public List<KeyValuePair<int, Item>>? GetItemBuffer()
        {
            return ItemBuffer;
        }


        // [JsonIgnore] public AdvData A { get; set; }

        // [JsonIgnore] public PersonList Persons { get; set; }
        // [JsonIgnore] [NonSerialized]  private Adv AdvGame;

        [JsonIgnore] private Item? _lastItem = null;

        public ItemList( int size = -1 ) : base()
        {
            // this.A = A;
            // this.Persons = Persons;
            // this.AdvGame = AdvGame;

            if ( size != -1)
                this.List = new Dictionary<int, Item>(size);

            loca.GD!.AddLanguageCallback(RestoreItems);
        }



#pragma warning disable CS0108 // "ItemList.Last()" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.Last()" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.

        public Item Last()
#pragma warning restore CS0108 // "ItemList.Last()" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.Last()" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        {
            return _lastItem!;
            // return (List[List.Count - 1]);
        }

        public Item Add(Item? I)
        {
            ItemBuffer!.Add(new(I!.ID, I));
            _lastItem = I;
            return I;
            /*
            if (List == null)
            {
                List = new Dictionary<int, Item>();
            }
            // new this.GetType().GetConstructor();
            List.Add(key: (int)I!.ID, value: I);
             _lastItem = I;
            return (I);
            // base.Add((AdvObject)I);
        */
        }
#pragma warning disable CS0108 // "ItemList.Find(int)" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.Find(int)" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.

        public Item? Find(int ID)
#pragma warning restore CS0108 // "ItemList.Find(int)" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.Find(int)" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        {
            if( List!.ContainsKey(ID))
                return List[ID];
            return null;
            /*
            Item ret = null;


            foreach (Item ele in List)
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

        public Item Find(Item I )
        {
            return (List![I.ID]);
            /*
            Item ret = null;
            if( I != null )
            {
                ret = I;
            }
            */
            /*
            foreach (Item ele in List)
            {
                if (ele.ID == I.ID )
                {
                    ret = ele;
                }
                if (ret != null) break;
            }
              return ret;
          */
        }
        /*
#pragma warning disable CS0108 // "ItemList.FindIx(int)" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.FindIx(int)" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        public int FindIx(int ID)
#pragma warning restore CS0108 // "ItemList.FindIx(int)" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.FindIx(int)" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        {
            int index = -1;

            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].ID == ID)
                {
                    index = i;
                }
                if (index > -1) break;
            }
            return index;

        }
        */
        /*
        public int FindIx(Item I )
        {
            int index = -1;

            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].ID == I.ID)
                {
                    index = i;
                }
                if (index > -1) break;
            }
            return index;

        }
        */

        public bool RestoreItems()
        {
            try
            {
                if (loca.GD!.Language == IGlobalData.language.english )
                {
                    if (ListD == null)
                    {
                        ListD = ListE;
                    }
                    IDictionary<int, Item>? TList2 = new Dictionary<int, Item>();

                    foreach (var ele in ListD!.Values!)
                    {
                        Item ele2 = (Item)ele;
                        if (ele2.LocaDescription != null)
                            ele2.Description = ele2.LocaDescriptionHandle = Helper.Insert(loca.GetLoca(ele2.LocaDescription));

                        TList2.Add(key: ele2.ID, value: ele2);
                        // TList2.Add(key: ele2.Name, value: ele2);
                    }
                    ListE = TList2;
                    TList2 = null;

                }
                else if (loca.GD!.Language == IGlobalData.language.german )
                {
                    if( ListE == null )
                    {
                        ListE = ListD;
                    }
                    IDictionary<int, Item>? TList2 = new Dictionary<int, Item>();

                    foreach (var ele in ListE!.Values!)
                    {
                        Item ele2 = (Item)ele;
                        if (ele2.LocaDescription != null)
                            ele2.Description = ele2.LocaDescriptionHandle = Helper.Insert(loca.GetLoca(ele2.LocaDescription));

                        TList2.Add(key: ele2.ID, value: ele2);
                        // TList2.Add(key: ele2.Name, value: ele2);
                    }
                    ListD = TList2;
                    TList2 = null;

                }
            }
            catch// ( Exception e)
            {

            }
            return true;
            /*
                        IDictionary<int, Item> TList2 = new Dictionary<int, Item>(StringComparer.CurrentCultureIgnoreCase);

                        foreach (var ele in List.Values)
                        {
                            Item ele2 = (Item)ele;

                            if (ele2.LocaDescription != null)
                                ele2.Description= Helper.Insert(loca.GetLoca(ele2.LocaDescription));


                            TList2.Add(key: ele2.ID, value: ele2);

                        }
                        List = (Dictionary<int, Item>)TList2;
                        TList2 = null;

                        return true;
            */
        }


        public List<Item> ListItems( int LocType, int LocID )
        {
            List<Item> itemList = new List<Item>();

            foreach( Item item in List!.Values )
            {
                if( item.locationType == LocType && item.locationID == LocID )
                {
                    itemList.Add(item);
                }
            }
            return itemList;
       }


        public int GetItemLoc( int ItemID )
        {
            int loc = -1;
            try
            {

                if (this.Find(ItemID) != null && this.Find(ItemID)!.locationType != Co.CB!.LocType_Loc)
                {
                    loc = GetItemLoc(this.Find(ItemID)!.locationID);

                }
                else if (this.Find(ItemID) != null)
                {
                    loc = this.Find(ItemID)!.locationID;
                }
                else
                {
                    loc = -1;
                }
            }
            catch( Exception e)
            {
                GlobalData.AddLog("GetItemLoc: " + ItemID.ToString(), IGlobalData.protMode.crisp);

            }
            return loc;
        }


        public (int lType, int lID) GetItemLoc( Item? item )
        {
            (int _lType, int _lID) loc;

            if( item!.IsRegular == false)
            {
                loc._lType = Co.CB!.LocType_Loc;
                loc._lID = -1;
            }
            else if (item.locationType == Co.CB!.LocType_In_Item )
            {
                loc = this.GetItemLoc( this.Find( item.locationID ) );
            }
            else if (item.locationType == Co.CB!.LocType_Behind_Item)
            {
                loc = this.GetItemLoc(this.Find(item.locationID) );
            }
            else if (item.locationType == Co.CB!.LocType_Below_Item)
            {
                loc = this.GetItemLoc(this.Find(item.locationID)) ;
            }
            else if (item.locationType == Co.CB!.LocType_Beside_Item)
            {
                loc = this.GetItemLoc(this.Find(item.locationID)) ;
            }
            else if (item.locationType == Co.CB!.LocType_On_Item)
            {
                loc = this.GetItemLoc(this.Find(item.locationID)) ;
            }
            else if (item.locationType == Co.CB!.LocType_In_Person)
            {
                loc = this.Persons!.GetPersonLoc(this.Persons!.Find(item.locationID)) ;
            }
            else if (item.locationType == Co.CB!.LocType_Person)
            {
                loc = this.Persons!.GetPersonLoc(this.Persons!.Find(item.locationID)) ;
            }
            else if (item.locationType == Co.CB!.LocType_To_Person)
            {
                loc = this.Persons!.GetPersonLoc(this.Persons!.Find( item.locationID) );
            }
            else
            {
                loc._lType = Co.CB!.LocType_Loc;
                loc._lID = item.locationID;
            }

            return ( loc );

        }

        public bool IsItemHere( int ItemID, int Mode )
        {
            return (IsItemHere(this.Find(ItemID), Mode));
        }

        public bool IsItemHere(Item? I, int Mode)
        {
            bool foundItem = false;

            if (Mode == Co.Range_Here)
            {
                if (I!.locationType == Co.CB!.LocType_Person)
                { 
                    if (I!.locationID == A!.ActPerson)
                        foundItem = true;
                }
                else if (I!.locationType == Co.CB!.LocType_Loc)
                {
                    if (I!.locationID == A!.ActLoc)
                        foundItem = true;

                }
                else // if (!foundItem)
                {
                    if (I!.locationType == Co.CB!.LocType_In_Item)
                    {
                        Item I2 = this.Find(I!.locationID)!;

                        if ((I2 != null) && ((I2.CanBeClosed == false) || (I2.IsClosed == false)) && (!I2.InvisibleIn))
                        {
                            foundItem = IsItemHere(I2, Mode);
                        }
                    }
                    else
                    {
                        Item I2 = this.Find(I!.locationID)!;
                        if (((I.locationType == Co.CB!.LocType_Below_Item) && (!I2.InvisibleBelow))
                                || ((I!.locationType == Co.CB!.LocType_On_Item) && (!I2.InvisibleOn))
                                || ((I!.locationType == Co.CB!.LocType_Beside_Item) && (!I2.InvisibleBeside))
                                || ((I!.locationType == Co.CB!.LocType_Behind_Item) && (!I2.InvisibleBehind))
                            )
                        {
                            // Item I2 = this.Find(I.locationID);
                            foundItem = IsItemHere(I2, Mode);
                        }
                        else if ((I.locationType == Co.CB!.LocType_In_Person)
                                    || (I.locationType == Co.CB!.LocType_To_Person)
                                )
                        {
                            Person P2 = Persons!.Find(I.locationID)!;
                            foundItem = Persons!.IsPersonHere(P2, Co.Range_Here);
                        }
                    }
                }
            }
            else if (Mode == Co.Range_Visible)
            {
                if (I!.IsHidden == false)
                {
                    if ((I!.locationType == Co.CB!.LocType_Person) && (I.locationID == A!.ActPerson))
                        foundItem = true;

                    if ((I!.locationType == Co.CB!.LocType_Loc) && (I.locationID == A!.ActLoc))
                        foundItem = true;

                    if (!foundItem)
                    {
                        if (I!.locationType == Co.CB!.LocType_In_Item)
                        {
                            Item I2 = this.Find(I.locationID)!;

                            if ( ((I2.CanBeClosed == false) || (I2.IsClosed == false) || (I2.IsCage))&& (!I2.InvisibleIn) )
                            {
                                foundItem = IsItemHere(I2, Mode);
                            }
                        }
                        else if (((I.locationType == Co.CB!.LocType_Below_Item) && (!this.Find(I.locationID)!.InvisibleBelow))
                                    || ((I.locationType == Co.CB!.LocType_On_Item) && (!this.Find(I.locationID)!.InvisibleOn))
                                    || ((I.locationType == Co.CB!.LocType_Beside_Item) && (!this.Find(I.locationID)!.InvisibleBeside))
                                    || ((I.locationType == Co.CB!.LocType_Behind_Item) && (!this.Find(I.locationID)!.InvisibleBehind))
                                )
                        {
                            Item I2 = this.Find(I.locationID)!;
                            foundItem = IsItemHere(I2, Mode);
                        }
                        else if ((I.locationType == Co.CB!.LocType_In_Person)
                                    || (I.locationType == Co.CB!.LocType_To_Person)
                                )
                        {
                            Person P2 = Persons!.Find(I.locationID)!;
                            foundItem = Persons!.IsPersonHere(P2, Co.Range_Here);
                        }
                    }
                }
            }
            else if (Mode == Co.Range_Known)
            {
                if (I!.Known)
                    foundItem = true;
            }
            else if (Mode == Co.Range_Active)
            {
                if (I!.Active)
                    foundItem = true;
            }
            else
            {
                foundItem = true;
            }
            return (foundItem);
        }

        public bool IsItemInv(Item? I)
        {
            bool foundItem = false;

            if ((I!.locationType == Co.CB!.LocType_Person) && (I.locationID == A!.ActPerson))
                foundItem = true;
            else
            {
                if (I.locationType == Co.CB!.LocType_In_Item)
                {
                    if( Find(I!.locationID!)!.CanBeClosed == false || Find(I!.locationID!)!.IsClosed == false )
                    {
                        foundItem = IsItemInv(Find(I!.locationID));
                    }


                }
            }
            return (foundItem);
        }

        public bool TransferItem( int ItemID, int plocationType, int plocationID)
        {
            return TransferItem(Find(ItemID), plocationType, plocationID);
        }
        public bool TransferItem(int ItemID, int DestItemID)
        {
            return TransferItem(Find(ItemID), Find(DestItemID));
        }
        public bool TransferItemPerson(int ItemID, int DestPersonID)
        {
            return TransferItem(Find(ItemID), Persons!.Find(DestPersonID));
        }

        private bool TransferItem( Item? I, Person? p)
        {
            return TransferItem(I, Co.CB!.LocType_Person, p!.ID!);
        }

        private bool TransferItem(Item? I, Item? I2)
        {
            return TransferItem(I, Co.CB!.LocType_In_Item, I2!.ID!);
        }

        private bool TransferItem(Item? I, int plocationType, int plocationID)
        {
            if (I!.locationType == Co.CB!.LocType_In_Item!)
            {
                Item I2 = this.Find(I.locationID)!;
                if( I2 != null )
                if( I2 != null )
                    I2.StorageIn += I.Size;
            }
            else if (I.locationType == Co.CB!.LocType_On_Item)
            {
                Item I2 = this.Find(I.locationID)!;
                if (I2 != null)
                    I2.StorageOn += I.Size;
            }
            else if (I.locationType == Co.CB!.LocType_Below_Item)
            {
                Item I2 = this.Find(I.locationID)!;
                if (I2 != null)
                    I2.StorageBelow += I.Size;
            }
            else if (I.locationType == Co.CB!.LocType_Behind_Item)
            {
                Item I2 = this.Find(I.locationID)!;
                if (I2 != null)
                    I2.StorageBehind += I.Size;
            }
            else if (I.locationType == Co.CB!.LocType_Beside_Item)
            {
                Item I2 = this.Find(I.locationID)!;
                if (I2 != null)
                    I2.StorageBeside += I.Size;
            }
            else if (I.locationType == Co.CB!.LocType_In_Person)
            {
                Person P2 = Persons!.Find(I.locationID)!;
                if (P2 != null)
                    P2.StorageIn += I.Size;
            }
            else if (I.locationType == Co.CB!.LocType_To_Person)
            {
                Person P2 = Persons!.Find(I.locationID)!;
                if (P2 != null)
                    P2.Storage += I.Size;
            }

            I.locationType = plocationType;
            I.locationID = plocationID;

            if (I.locationType == Co.CB!.LocType_In_Item)
            {
                Item I2 = this.Find(plocationID)!;
                I2.StorageIn -= I.Size;
            }
            else if (I.locationType == Co.CB!.LocType_On_Item)
            {
                Item I2 = this.Find(plocationID)!;
                I2.StorageOn -= I.Size;
            }
            else if (I.locationType == Co.CB!.LocType_Below_Item)
            {
                Item I2 = this.Find(plocationID)!;
                I2.StorageBelow -= I.Size;
            }
            else if (I.locationType == Co.CB!.LocType_Behind_Item)
            {
                Item I2 = this.Find(plocationID)!;
                I2.StorageBehind -= I.Size;
            }
            else if (I.locationType == Co.CB!.LocType_Beside_Item)
            {
                Item I2 = this.Find(plocationID)!;
                I2!.StorageBeside -= I.Size;
            }
            else if (I.locationType == Co.CB!.LocType_In_Person)
            {
                Person P2 = Persons!.Find(plocationID)!;
                P2!.StorageIn -= I.Size;
            }
            else if (I.locationType == Co.CB!.LocType_To_Person)
            {
                Person P2 = Persons!.Find(plocationID)!;
                P2!.Storage -= I.Size;
            }

            AdvGame!.DoUIUpdate();

            return (true);
        }

        public int GetItemIx(int ItemID)
        {
            int rItemIX = 0;
            for (int i = 0; i < this.List!.Count; i++)
            {
                if (this.List[i].ID == ItemID)
                {
                    rItemIX = i;
                }
            }
            return (rItemIX);
        }

        public int GetItemIx(Item I )
        {
            int rItemIX = 0;
            for (int i = 0; i < this.List!.Count; i++)
            {
                if (this.List[i].ID == I.ID)
                {
                    rItemIX = i;
                }
            }
            return (rItemIX);
        }

        public string GetName(int ItemID, int Case, List<Noun>? CurrentNouns, bool ShowAppendix = false)
        {
            // string s = this.List[this.FindIx(ItemID)].FullName(this.Find(ItemID), Case, ShowAppendix);
            string s = this.List![ItemID].FullName(this.Find(ItemID!)!, Case, CurrentNouns, ShowAppendix)!;
            // if ( ShowAppendix && this.List[this.FindIx(ItemID)].IsDressed )
            if (ShowAppendix && this.List[ItemID ].IsDressed)
            {
                s = s + loca.ItemList_GetName_16123;
            }
            return (s);
        }

        public string GetName(Item I , int Case, List<Noun> CurrentNouns, bool ShowAppendix = false)
        {
            // string s = this.List[this.FindIx(I.ID)].FullName(I, Case, ShowAppendix);
            string s = I.FullName(I, Case, CurrentNouns, ShowAppendix)!;
            // if (ShowAppendix && this.List[this.FindIx(I.ID)].IsDressed)
            if (ShowAppendix && I.IsDressed)
            {
                s = s + loca.ItemList_GetName_16124;
            }
            return (s);
        }


        public string GetItemNameLink(int ItemID, int Case, List<Noun>? CurrentNouns, bool ShowAppendix = false)
        {
            string s = this.GetName(ItemID, Case, CurrentNouns, ShowAppendix);
#if CHROMIUM
            // Noloca: 002
            string scr = System.Web.HttpUtility.HtmlEncode( "boundAsync.JSCallback(\"Item: " + $"{ItemID:00000}\");");
// Ignores: 005
// Noloca: 005
            s = "<a style='cursor:pointer' class='class1' onclick='" +scr + "'>" +s + "</a>";
#elif MAUI
            string scr = System.Web.HttpUtility.HtmlEncode("window.location.href = 'https://defineobject.Item/" + $"{ItemID:00000}';");
            s = "<a style='cursor:pointer' class='class1' onclick='" + scr + "'>" + s + "</a>";

#else
            // Ignores: 004
            // Noloca: 004
            s = "<a style=\"cursor:pointer\" class=\"class1\" onclick=\"window.external.JSCallback('Item: " + $"{ItemID:00000}' );\"></a>";
#endif

            return (s);
        }

        public string GetItemNameLink(Item I , int Case, List<Noun> CurrentNouns, bool ShowAppendix = false)
        {
            string s = this.GetName(I, Case, CurrentNouns, ShowAppendix);

#if CHROMIUM
            // Noloca: 004
            string scr = System.Web.HttpUtility.HtmlEncode( "boundAsync.JSCallback(\"Item: " + $"{I.ID:00000}\");");
            s = "<a style='cursor:pointer' onclick=''>" +s + "</a>";
#elif MAUI
            // Noloca: 004
            string scr = System.Web.HttpUtility.HtmlEncode("window.location.href = 'https://defineobject.Item/" + $"{I.ID:00000}';");
            s = "<a style='cursor:pointer' onclick=''>" +s + "</a>";
#else
            // Noloca: 002
            s = "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('Item: " + $"{I.ID:00000}' );\"></a>";
#endif

            return (s);
        }



        public int FindContainers(int Loc, int Where, List<PI> il)
        {
            int Ct = 0;

            for (int i = 0; i < List!.Count; i++)
            {
                Item item = Find(List[i].ID)!;
                if ((Where == AdvGame!.CB!.LocType_In_Item) && ( Loc == Co.GenerateLoc(item ) ) && (item!.CanPutIn) && ((item!.CanBeClosed == false) || (item!.IsClosed == false)))
                {
                    Ct++;
                    il.Add(new PI( PI.TypeVal.Item, item.ID ) );
                    FindContainers(Co.GenerateLoc(AdvGame.CB!.LocType_In_Item, item.ID), AdvGame.CB!.LocType_In_Item, il );
                }
                else if ((Where == AdvGame.CB!.LocType_Behind_Item) && (item.CanPutBehind))
                {
                    Ct++;
                    il.Add(new PI(PI.TypeVal.Item, item.ID));
                    FindContainers(Co.GenerateLoc(AdvGame.CB!.LocType_Behind_Item, item.ID), AdvGame.CB!.LocType_Behind_Item, il);
                }
                else if ((Where == AdvGame.CB!.LocType_On_Item) && (item.CanPutOn))
                {
                    Ct++;
                    il.Add(new PI(PI.TypeVal.Item, item.ID));
                    FindContainers(Co.GenerateLoc(AdvGame.CB!.LocType_On_Item, item.ID), AdvGame.CB!.LocType_On_Item, il);
                }
                else if ((Where == AdvGame.CB!.LocType_Beside_Item) && (item.CanPutBeside))
                {
                    Ct++;
                    il.Add(new PI(PI.TypeVal.Item, item.ID));
                    FindContainers(Co.GenerateLoc(AdvGame.CB!.LocType_Beside_Item, item.ID), AdvGame.CB!.LocType_Beside_Item, il);
                }
                else if ((Where == AdvGame.CB!.LocType_Below_Item) && (item.CanPutBelow))
                {
                    Ct++;
                    il.Add(new PI(PI.TypeVal.Item, item.ID));
                    FindContainers(Co.GenerateLoc(AdvGame.CB!.LocType_Below_Item, item.ID), AdvGame.CB!.LocType_Below_Item, il);
                }
            }
            return Ct;
        }
        public static ItemList CloneItemList(ItemList source)
        {
            ItemList dest = new();

            dest.List = new Dictionary<int,Item>();
            // dest.A = source.A
            foreach (Item it in source!.List!.Values)
            {
                Item itDest = new();
                itDest.CanBeClosed = it.CanBeClosed;
                itDest.CanBeLocked = it.CanBeLocked;
                itDest.CanBeTaken = it.CanBeTaken;
                itDest.CanPutBehind = it.CanPutBehind;
                itDest.CanPutBelow = it.CanPutBelow;
                itDest.CanPutBeside = it.CanPutBeside;
                itDest.CanPutIn = it.CanPutIn;
                itDest.CanPutOn = it.CanPutOn;
                itDest.Dressable = it.Dressable;
                itDest.InvisibleBehind = it.InvisibleBehind;
                itDest.InvisibleBelow = it.InvisibleBelow;
                itDest.InvisibleBeside = it.InvisibleBeside;
                itDest.IsBackground = it.IsBackground;
                itDest.InvisibleIn = it.InvisibleIn;
                itDest.InvisibleOn = it.InvisibleOn;
                itDest.IsCage = it.IsCage;
                itDest.IsClosed = it.IsClosed;
                itDest.IsCountable = it.IsCountable;
                itDest.IsDressed = it.IsDressed;
                itDest.IsHidden = it.IsHidden;
                itDest.IsLessImportant = it.IsLessImportant;
                itDest.IsLocked = it.IsLocked;
                itDest.IsMovable = it.IsMovable;
                itDest.IsMentionable = it.IsMentionable;
                itDest.IsRegular = it.IsRegular;
                itDest.ListInsideItems = it.ListInsideItems;
                itDest.ShowStorageIn = it.ShowStorageIn;
                itDest.ShowStorageOn = it.ShowStorageOn;
                itDest.IsCountable = it.IsCountable;
                itDest.locationStatic = it.locationStatic;
                itDest.Active = it.Active;

                itDest.Size = it.Size;
                itDest.StorageBehind = it.StorageBehind;
                itDest.StorageBelow = it.StorageBelow;
                itDest.StorageBeside = it.StorageBeside;
                itDest.StorageIn = it.StorageIn;
                itDest.StorageOn = it.StorageOn;
                itDest.locationID = it.locationID;
                itDest.locationType = it.locationType;

                itDest.Appendix = it.Appendix;
                itDest.ID = it.ID;
                itDest.AppendixLoca = it.AppendixLoca;
                itDest.Description = it.Description;
                itDest.Known = it.Known;
                itDest.LocaDescription = it.LocaDescription;
                itDest.Sex = it.Sex;
                itDest.SexEng = it.SexEng;
                itDest.Picture = it.Picture;

                itDest.controllerName = it.controllerName;
                itDest.controller = it.controller;

                itDest.SL = new();
                itDest.SL.List = new();
                foreach (Status sSource in it!.SL!.List)
                {
                    Status sDest = new Status(sSource.ID, sSource.Val);
                    itDest.SL.List.Add(sDest);
                }

                itDest.UnlockItems = new();
                foreach (int uItem in it!.UnlockItems!)
                {
                    itDest.UnlockItems.Add(uItem);
                }

                itDest.Names = new();
                foreach (Noun n in it!.Names!)
                {
                    itDest.Names.Add(n);
                }
                // itDest.SynNames
                // itDest.Adjectives
                // itDest.SynAdjectives
                // itDest.NamesEng
                // itDest.SynNamesEng
                // itDest.AdjectivesEng
                // itDest.SynAdjectivesEng
                // itDest.Categories
                // itDest.Relevance

                dest.Add(itDest);
            }
            return dest;
        }
    }
    [Serializable]


    public class ItemQueue
    {
        public List<Item>? _itemQueue = null;
        int _maxSize = 10;


        public List<Item> IQ 
        {
            get { return _itemQueue!; }
            set { _itemQueue = value;  }
        }
        int MaxSize
        {
            get { return _maxSize; }
        }


        public ItemQueue( int size )
        {
            _maxSize = size;
            IQ = new List<Item>();
        }


        public void Add( Item item )
        {
            IQ.Add(item);
            while( IQ.Count > MaxSize )
            {
                IQ.RemoveAt(0);
            }
        }
    }

 }