using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Security.Permissions;
using Newtonsoft.Json;

using Phoney_MAUI.Model;


namespace GameCore
{
    public enum relTypes { r_essential, r_high, r_med, r_low }

    public interface IParseElement
    {

    }
    [Serializable]
    public class ParseElement
    {

    }
    interface IWord
    {
        string? Name { get; }
        int ID { get; }
    }


    [Serializable]
    public abstract class Word : IWord
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public Word(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public Word( string Name ) : this(SerialNumberGenerator.Instance.NextSerial, Name)
        {
        }
    }
    [Serializable]
    public abstract class AbstractVariety : IParseElement
    {
        string? Name { get; set; }
        int ID { get; set; }
        public AbstractVariety()
        {
        }

    }
    [Serializable]
    public class Variety : AbstractVariety
    {
        public Variety()
        {
        }

    }
    [Serializable]
    public abstract class AbstractNothing : IWord
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public AbstractNothing( int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public AbstractNothing( string Name ) : this(SerialNumberGenerator.Instance.NextSerial, Name)
        {
        }
    }
    [Serializable]
    public class Nothing : IWord
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public Nothing(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        public Nothing(string Name) : this(SerialNumberGenerator.Instance.NextSerial, Name)
        {

        }
    }

    interface IWordList<T> 
    {
        public abstract T? Add(int ID, string? name);
        public abstract T? Add(string? name);
        public abstract T? Find(string? name);
        public abstract T? Find(int ID);
    }

    [Serializable]
    public abstract class WordList<T> where T : Word
    {
        public IList<T> TList { get; set; }

        public WordList()
        {
            TList = new List<T>();
        }
        public abstract T Add(int ID, string name);

        public abstract T Add(string name);

        public virtual T? Find(string name)
        {
            T? Ret = null;

            foreach (T ele in TList )
            {
                if (String.Compare(ele.Name.ToLower(new CultureInfo( "de-DE", false)), name.ToLower(new CultureInfo( "de-DE", false))) == 0)
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret;

        }
        public T? Find(int ID)
        {
            T? Ret = null;

            foreach (T ele in TList)
            {
                if ( ele.ID == ID )
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret;

        }
        public T Add( Word word )
        {
            if (TList == null)
            {
                TList = new List<T>();
            }
            // new this.GetType().GetConstructor();
            TList.Add( (T) word );
            return (T) word;
        }

    }

    interface IToken
    {
        public string? Name { get; }
        public int ID { get; }

    }

    [Serializable]
    public abstract class AbstractToken : IToken
    {
        public string? Name { get; }
        public int ID { get; }

        public AbstractToken(int ID, string? Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }

    [Serializable]
    public class ooToken : AbstractToken
    {
        public ooToken( int ID ) : base(ID, null )
        {
        }
    }

     interface IAdvObject : IParseElement
    {
    }

    [Serializable]
    public abstract class AbstractAdvObject : IAdvObject
    {
        [JsonIgnore] public List<Noun>? _names;
        [JsonIgnore] public List<Noun>? _synNames;
        [JsonIgnore] public List<Adj>? _adjectives;
        [JsonIgnore] public List<Adj>? _synAdjectives;

        [JsonIgnore] public List<Noun>? _namesEng;
        [JsonIgnore] public List<Noun>? _synNamesEng;
        [JsonIgnore] public List<Adj>? _adjectivesEng;
        [JsonIgnore] public List<Adj>? _synAdjectivesEng;

        public int ID { get; set; }
        public List<Noun>? Names 
        { 
            get 
            {
                if (loca.GD!.Language == IGlobalData.language.english && _namesEng != null)
                    return _namesEng;
                else
                    return _names;
            }
            set 
            {
                _names = value; 
            } 
        }
        public List<Noun>? SynNames
        {
            get
            {
                if (loca.GD!.Language == IGlobalData.language.english && _synNamesEng != null)
                    return _synNamesEng;
                else
                    return _synNames;
            }
            set
            {
                _synNames = value;
            }
        }
        public List<Adj>? Adjectives
        {
            get
            {
                if (loca.GD!.Language == IGlobalData.language.english && _adjectivesEng != null)
                    return _adjectivesEng;
                else
                    return _adjectives;
            }
            set
            {
                _adjectives = value;
            }
        }
        public List<Adj>? SynAdjectives
        {
            get
            {
                if (loca.GD!.Language == IGlobalData.language.english && _synAdjectivesEng != null)
                    return _synAdjectivesEng;
                else
                    return _synAdjectives;
            }
            set
            {
                _synAdjectives = value;
            }
        }
        public List<Noun>? NamesEng
        {
            get
            {
                return _namesEng;
            }
            set
            {
                _namesEng = value;
            }
        }
        public List<Noun>? SynNamesEng
        {
            get
            {
                return _synNamesEng;
            }
            set
            {
                _synNamesEng = value;
            }
        }
        public List<Adj>? AdjectivesEng
        {
            get
            {
                return _adjectivesEng;
            }
            set
            {
                _adjectivesEng = value;
            }
        }
        public List<Adj>? SynAdjectivesEng
        {
            get
            {
                return _synAdjectivesEng;
            }
            set
            {
                _synAdjectivesEng = value;
            }
        }

        public int _sexGer;
        public int _sexEng;

        public int Sex 
        { 
            get 
            {
                if (loca.GD!.Language == IGlobalData.language.german)
                    return _sexGer;
                else
                    return _sexEng;
            }
            set
            {
                _sexGer = value;
            }
        }

        public int SexEng 
        {
            get { return _sexEng; }
            set { _sexEng = value;  } 
        }
        private string? _description;
        public string? LocaDescriptionHandle { get; set; }
        public string? LocaDescription{ get; set; }

        [JsonIgnore]
        public string? Description
        {
            get
            {
                return( Helper.Insert( loca.TextOrLoca(_description, LocaDescription, LocaDescriptionHandle) ) );
             }
            set
            {
                _description = value;
            }
        }

        public string? Picture { get; set; }
        public bool Active { get; set; }
        [JsonIgnore][NonSerialized] public DelAdvObject? controller;
        public string? controllerName;
        private NounList? Nouns { get; set; }
        private AdjList? Adjs { get; set; }
        public CategoryRelList? Categories { get; set; }
        public relTypes Relevance { get; set; }
        public StatusList? SL { get; set; }
        public string? _appendix { get; set; }
        public bool IsCountable { get; set; }
        public bool Known { get; set; }
        // public CategoryCatList Categories { get; set; }
        public AbstractAdvObject()
        {

        }

        public string? AppendixLoca { get; set; }

        public string? Appendix
        {
            get
            {
                return loca.TextOrLoca(_appendix, AppendixLoca);
            }
            set
            {
                _appendix = value;
            }
        }


        public static string Insert(string s, params object[] obj)
        {
            return s;
        }
        public AbstractAdvObject( int ID, List<Noun>? Names, List<Noun>? SynNames, List<Adj>? Adjectives, List<Adj>? SynAdjectives, int Sex, string? Desc, bool Active, DelAdvObject? Controller, NounList? Nouns, AdjList? Adjs  )
        {
            this.ID = ID;
            this.Names = Names;
            this.SynNames = SynNames;
            this.Adjectives = Adjectives;
            this.SynAdjectives = SynAdjectives;
            this.Sex = Sex;
            this.SexEng = Sex;
            this.Description = Desc;
            this.Active = Active;
            this.controller = Controller;
            this.Known = false;
            this.Relevance = relTypes.r_essential;
            if (Controller != null)
            {
                this.controllerName = Controller.Method.Name;
            }
            else
                this.controllerName = null;
            this.Nouns = Nouns;
            this.Adjs = Adjs;
            this.Categories = new CategoryRelList();
            this.SL= new StatusList();
            this.IsCountable = true;

            if (this.Names == null) this.Names = new List<Noun>();
            if (this.SynNames == null) this.SynNames = new List<Noun>();
            if (this.Adjectives == null) this.Adjectives = new List<Adj>();
            if (this.SynAdjectives== null) this.SynAdjectives= new List<Adj>();
        }

        public bool SetController( DelAdvObject Controller )
        {
            this.controller = Controller;
            if( controller != null )
                this.controllerName = Controller.Method.Name;


            return true;
        }

        public DelAdvObject? GetController( object o)
        {
            if( this.controller == null && this.controllerName != null )
            {
                
                this.controller = (DelAdvObject) Delegate.CreateDelegate(typeof(DelAdvObject), o, this.controllerName, false);
            }
            return (this.controller);
        }

        public virtual string? FullName( AbstractAdvObject AO, int Case, bool ForceArticle = false, bool ShowAppendix = false, bool spaceAsUnderline = false)
        {
            string? space = " ";
            if (spaceAsUnderline)
                space = ".";

            int j;
            // int IX = GetPersonIx(PersonID);
            string? s = "";

            AO.Known = true;

            // if (PersonID == A.P_I) return ( "ich");
            // if (PersonID == A.P_You) return ( "du");

            if( loca.GD!.Language == IGlobalData.language.german)
            {
                if ((AO.Adjectives?.Count > 0) || (ForceArticle))
                {
                    if (Case == Co.CASE_NOM)
                    {
                        if (AO.Sex == Co.SEX_MALE)
                            s = s + "den";
                        else if (AO.Sex == Co.SEX_FEMALE)
                            s = s + "die";
                        else if (AO.Sex == Co.SEX_NEUTER)
                            s = s + "das";
                        else
                            s = s + "die";
                    }
                    else if (Case == Co.CASE_AKK)
                    {
                        if (AO.Sex == Co.SEX_MALE)
                            s = s + "der";
                        else if (AO.Sex == Co.SEX_FEMALE)
                            s = s + "die";
                        else if (AO.Sex == Co.SEX_NEUTER)
                            s = s + "das";
                        else
                            s = s + "die";
                    }
                    else if (Case == Co.CASE_DAT)
                    {
                        if (AO.Sex == Co.SEX_MALE)
                            s = s + "dem";
                        else if (AO.Sex == Co.SEX_FEMALE)
                            s = s + "der";
                        else if (AO.Sex == Co.SEX_NEUTER)
                            s = s + "dem";
                        else
                            s = s + "den";
                    }
                    else if (Case == Co.CASE_NOM_UNDEF && AO.IsCountable)
                    {
                        if (AO.Sex == Co.SEX_MALE)
                            s = s + "einen";
                        else if (AO.Sex == Co.SEX_FEMALE)
                            s = s + "eine";
                        else if (AO.Sex == Co.SEX_NEUTER)
                            s = s + "ein";
                    }
                    else if (Case == Co.CASE_AKK_UNDEF && AO.IsCountable)
                    {
                        if (AO.Sex == Co.SEX_MALE)
                            s = s + "ein";
                        else if (AO.Sex == Co.SEX_FEMALE)
                            s = s + "eine";
                        else if (AO.Sex == Co.SEX_NEUTER)
                            s = s + "ein";
                    }
                    else if (Case == Co.CASE_DAT_UNDEF && AO.IsCountable)
                    {
                        if (AO.Sex == Co.SEX_MALE)
                            s = s + "einem";
                        else if (AO.Sex == Co.SEX_FEMALE)
                            s = s + "einer";
                        else if (AO.Sex == Co.SEX_NEUTER)
                            s = s + "einem";
                    }
                }
                for (j = 0; j < AO.Adjectives?.Count; j++)
                {
                    Adj adj = (Adj)AO.Adjectives[j];
                    if (j > 0)
                        s = s + ",";

                    s = s + space + adj.Name; // Adjs!.GetAdj(adj);

                    if (adj!.Name?[adj!.Name!.Length - 1] == 'e')
                    {
                        if (Case == Co.CASE_NOM)
                        {
                            if (AO.Sex == Co.SEX_MALE_PL || AO.Sex == Co.SEX_FEMALE_PL || AO.Sex == Co.SEX_NEUTER_PL)
                                s = s + "n";
/*
                            if (AO.Sex == Co.SEX_MALE)
                                s = s + "n";
                            else if (AO.Sex == Co.SEX_FEMALE)
                                ; //  s = s
                            else if (AO.Sex == Co.SEX_NEUTER)
                                ; //  s = s;
                            else
                                s = s + "n";
*/
                        }
                        else if (Case == Co.CASE_AKK)
                        {
                            if (AO.Sex == Co.SEX_MALE_PL || AO.Sex == Co.SEX_FEMALE_PL || AO.Sex == Co.SEX_NEUTER_PL)
                                s = s + "n";
                            /*
                            if (AO.Sex == Co.SEX_MALE)
                                s = s;
                            else if (AO.Sex == Co.SEX_FEMALE)
                                s = s;
                            else if (AO.Sex == Co.SEX_NEUTER)
                                s = s;
                            else
                                s = s + "n";
                            */
                        }
                        else if (Case == Co.CASE_DAT)
                        {
                            if (AO.Sex == Co.SEX_MALE)
                                s = s + "n";
                            else if (AO.Sex == Co.SEX_FEMALE)
                                s = s + "n";
                            else if (AO.Sex == Co.SEX_NEUTER)
                                s = s + "n";
                            else
                                s = s + "n";
                        }
                        else if (Case == Co.CASE_NOM_UNDEF)
                        {
                            if (AO.Sex == Co.SEX_MALE)
                                s = s + "n";
                            // else if (AO.Sex == Co.SEX_FEMALE)
                            //     ;
                            else if (AO.Sex == Co.SEX_NEUTER)
                                s = s + "s";
                            // else
                            //     ;
                        }
                        else if (Case == Co.CASE_AKK_UNDEF)
                        {
                            if (AO.Sex == Co.SEX_MALE)
                                s = s + "r";
                            // else if (AO.Sex == Co.SEX_FEMALE)
                            //     ;
                            else if (AO.Sex == Co.SEX_NEUTER)
                                s = s + "s";
                            else
                                s = s + "e";
                        }
                        else if (Case == Co.CASE_DAT_UNDEF)
                        {
                            if (AO.Sex == Co.SEX_MALE)
                                s = s + "n";
                            else if (AO.Sex == Co.SEX_FEMALE)
                                s = s + "n";
                            else if (AO.Sex == Co.SEX_NEUTER)
                                s = s + "n";
                            else
                                s = s + "n";
                        }

                    }
                    else if (adj.Name?[adj.Name!.Length - 1] == 'a')
                    {
                        // Lila, Rosa etc. werden gar nicht dekliniert, die bleiben so, wie sie sind
                    }
                    else
                    {
                        if (Case == Co.CASE_NOM)
                        {
                            if (AO.Sex == Co.SEX_MALE)
                                s = s + "en";
                            else if (AO.Sex == Co.SEX_FEMALE)
                                s = s + "e";
                            else if (AO.Sex == Co.SEX_NEUTER)
                                s = s + "e";
                            else
                                s = s + "en";
                        }
                        else if (Case == Co.CASE_AKK)
                        {
                            if (AO.Sex == Co.SEX_MALE)
                                s = s + "e";
                            else if (AO.Sex == Co.SEX_FEMALE)
                                s = s + "e";
                            else if (AO.Sex == Co.SEX_NEUTER)
                                s = s + "e";
                            else
                                s = s + "en";
                        }
                        else if (Case == Co.CASE_DAT)
                        {
                            if (AO.Sex == Co.SEX_MALE)
                                s = s + "en";
                            else if (AO.Sex == Co.SEX_FEMALE)
                                s = s + "en";
                            else if (AO.Sex == Co.SEX_NEUTER)
                                s = s + "en";
                            else
                                s = s + "en";
                        }
                        else if (Case == Co.CASE_NOM_UNDEF)
                        {
                            if (AO.Sex == Co.SEX_MALE)
                                s = s + "en";
                            else if (AO.Sex == Co.SEX_FEMALE)
                                s = s + "e";
                            else if (AO.Sex == Co.SEX_NEUTER)
                                s = s + "es";
                            else
                                s = s + "e";
                        }
                        else if (Case == Co.CASE_AKK_UNDEF)
                        {
                            if (AO.Sex == Co.SEX_MALE)
                                s = s + "er";
                            else if (AO.Sex == Co.SEX_FEMALE)
                                s = s + "e";
                            else if (AO.Sex == Co.SEX_NEUTER)
                                s = s + "es";
                            else
                                s = s + "e";
                        }
                        else if (Case == Co.CASE_DAT_UNDEF)
                        {
                            if (AO.Sex == Co.SEX_MALE)
                                s = s + "en";
                            else if (AO.Sex == Co.SEX_FEMALE)
                                s = s + "en";
                            else if (AO.Sex == Co.SEX_NEUTER)
                                s = s + "en";
                            else
                                s = s + "en";
                        }

                    }


                }

                int i;
                for (i = 0; i < AO.Names?.Count; i++)
                {
                    Noun noun = AO.Names[i];

                    if (s == "")
                        // s = Nouns.GetNoun(AO.Names[i]);
                        s = noun.Name;
                    else
                        // s = s + " " + Nouns.GetNoun(AO.Names[i]);
                        s = s + space + noun.Name;

                    if ((Case == Co.CASE_DAT) && ((AO.Sex == Co.SEX_FEMALE_PL) || (AO.Sex == Co.SEX_MALE_PL) || (AO.Sex == Co.SEX_NEUTER_PL)))
                    {
                        if (s?[s!.Length - 1] == 'e') s += "n";
                        else if (s!.EndsWith("el")) s += "n";
                    }
                }

                if ((Appendix != null) && (ShowAppendix))
                {
                    s = s + space + Appendix;
                }

            }
            else
            {
                if ((AO.Adjectives?.Count > 0) || (ForceArticle))
                {
                    if (Case == Co.CASE_NOM)
                    {
                        s = s + "the";
                    }
                    else if (Case == Co.CASE_AKK)
                    {
                        s = s + "the";
                    }
                    else if (Case == Co.CASE_DAT)
                    {
                        s = s + "the";
                    }
                    else if ( Sex == Co.SEX_FEMALE || Sex == Co.SEX_MALE || Sex == Co.SEX_NEUTER )
                    {
                        if (Case == Co.CASE_NOM_UNDEF && AO.IsCountable)
                        {
                            s = s + "a";
                        }
                        else if (Case == Co.CASE_AKK_UNDEF && AO.IsCountable)
                        {
                            s = s + "a";
                        }
                        else if (Case == Co.CASE_DAT_UNDEF && AO.IsCountable)
                        {
                            s = s + "a";
                        }

                    }
                }
                for (j = 0; j < AO!.Adjectives!.Count; j++)
                {
                    Adj adj = (Adj)AO!.Adjectives[j];
                    if (j > 0)
                        s = s + ",";

                    s = s + space + adj.Name; // Adjs!.GetAdj(adj);
                }

                int i;
                for (i = 0; i < AO.Names?.Count; i++)
                {
                    Noun noun = AO.Names[i];

                    if (s == "")
                        // s = Nouns.GetNoun(AO.Names[i]);
                        s = noun.Name;
                    else
                        // s = s + " " + Nouns.GetNoun(AO.Names[i]);
                        s = s + space + noun.Name;

                }

                if ((Appendix != null) && (ShowAppendix))
                {
                    s = s + space + Appendix;
                }

            }

            // HIer wird jetzt noch ein Link draus gemacht
            return (s);
        }

        public Status? FindStatus( int ID, bool findAndInsert = true )
        {
            Status? statReturn = null;

            for (int i = 0; i < this.SL?.Count; i++ )
            {
                if( this.SL.FindIndex(i)!.ID == ID)
                {
                    statReturn = this.SL.FindIndex(i);
                    break;
                }
            }
            if (statReturn == null && findAndInsert )
            {
                statReturn = new Status(ID, 0);
                this!.SL!.Add( statReturn );
            }
            return (statReturn);
        }
        public Status FindStatus( Status stat )
        {
            return (stat);
        }


        public void SetStatus( int ID, int Val )
        {
            FindStatus(ID)!.Val = Val;
        }
        public int GetStatus( int ID )
        {
            if (FindStatus(ID, false) == null)
                return -1;
            else
                return (FindStatus(ID)!.Val);
        }
        public void DeleteStatus(int ID)
        {
            this!.SL!.Delete(ID);
        }
    }
    [Serializable]
    public class AdvObject : AbstractAdvObject
    {
        public AdvObject(int ID, List<Noun> Names, List<Noun> SynNames, List<Adj> Adjectives, List<Adj> SynAdjectives, int Sex, string Desc, bool Active, DelAdvObject Controller, NounList Nouns, AdjList Adjs) : base( ID, Names, SynNames, Adjectives, SynAdjectives, Sex, Desc, Active, Controller, Nouns, Adjs )
        {
        }
    }
    interface IAdvObjectList<T> where T : AdvObject
    {
        public AdvObject Find(int ID);
        public int FindIx(int ID);
        public void Add(AdvObject AO);
        public AdvObject Last();
    }


    [Serializable]
    public abstract class AbstractAdvObjectList<T>  where T : AdvObject
    {
        public List<T> List { get; set; }

        public AbstractAdvObjectList()
        {
            List = new List<T>();
        }

       public T? Find(int ID)
        {
            T? Ret = null;

            foreach (T AOele in List)
            {
                if (AOele.ID == ID)
                {
                    Ret = AOele;
                }
                if (Ret != null) break;
            }
            return Ret;

        }
        /*
        public int FindIx(int ID)
        {
            int Index = -1;

            for( int i = 0; i < List.Count; i++ )
            {
                if (List[i].ID == ID)
                {
                    Index = i;
                }
                if (Index > -1) break;
            }
            return Index;

        }
        */
        public void Add(T AO )
        {
            if (List == null)
            {
                List = new List<T>();
            }
            // new this.GetType().GetConstructor();
            List.Add(AO);
        }

        public T Last( )
        {
           
            return (List[List.Count - 1]);
        }
    }
    [Serializable]
    public class Category
    {
        public int CategoryID { get; set; }
        public int CounterCategoryID { get; set;  }
        private string? _headLine1;
        private string? _headLine2;
        private string? _contextMenuText;
        private string? _parseLine;

        public string? LocaHeadline1 { get; set; }
        public string? LocaHeadline2 { get; set; }
        public string? LocaContextMenuText { get; set; }
        public string? LocaParseLine { get; set; }
        public string? Headline1 
        {
            get
            {
                return loca.TextOrLoca(_headLine1, LocaHeadline1);
            }
            set
            {
                _headLine1 = value;
            }
        }
        public string? Headline2
        {
            get
            {
                return loca.TextOrLoca(_headLine2, LocaHeadline2);
            }
            set
            {
                _headLine2 = value;
            }
        }
        public string? ContextMenuText
        {
            get
            {
                return loca.TextOrLoca(_contextMenuText, LocaContextMenuText);
            }
            set
            {
                _contextMenuText = value;
            }
        }
        public string? ParseLine
        {
            get
            {
                return loca.TextOrLoca(_parseLine, LocaParseLine);
            }
            set
            {
                _parseLine = value;
            }
        }
        [JsonConstructor]
        public Category(int CategoryID, int CounterCategoryID, string headline1, string headline2, string contextMenuText, string parseLine)
        {
            this.CategoryID = CategoryID;
            this.CounterCategoryID = CounterCategoryID;
            this.Headline1 = headline1;
            this.Headline2 = headline2;
            this.ContextMenuText = contextMenuText;
            this.ParseLine = parseLine;
        }

        public Category(int CategoryID)
        {
            this.CategoryID = CategoryID;
            this.CounterCategoryID = -1;
            this.Headline1 = null;
            this.Headline2 = null;
            this.ContextMenuText = null;
            this.ParseLine = null;
        }
        public Category()
        {
            this.CategoryID = -1;
            this.CounterCategoryID = -1;
            this.Headline1 = null;
            this.Headline2 = null;
            this.ContextMenuText = null;
            this.ParseLine = null;
        }
        public static Category CategoryLoca(int CategoryID, int CounterCategoryID, string? locaHeadline1, string? locaHeadline2, string? locaContextMenuText, string? locaParseLine)
        {
            Category c = new Category(CategoryID);

            c.CounterCategoryID = CounterCategoryID;
            c.LocaHeadline1 = locaHeadline1;
            c.LocaHeadline2 = locaHeadline2;
            c.LocaContextMenuText = locaContextMenuText;
            c.LocaParseLine = locaParseLine;

            return c;
        }
        /*
        public Category(int CategoryID, int CounterCategoryID, string? locaHeadline1, string? locaHeadline2, string? locaContextMenuText, string? locaParseLine)
        {
            this.CategoryID = CategoryID;

            this.CounterCategoryID = CounterCategoryID;
            this.LocaHeadline1 = locaHeadline1;
            this.LocaHeadline2 = locaHeadline2;
            this.LocaContextMenuText = locaContextMenuText;
            this.LocaParseLine = locaParseLine;

        }
        */
    }
    [Serializable]
    public class CategoryRel
    {
        public Category? Category { get; }
        public relTypes Relevance { get; set;  }
        [JsonConstructor]
        public CategoryRel(Category? category, relTypes rel = relTypes.r_essential )
        {
            this.Category = category;
            this.Relevance = rel;
        }
        public CategoryRel()
        {

        }

        public CategoryRel( int CategoryID, int CounterCategoryID, relTypes Relevance)
        {
            this.CategoryID = CategoryID;
            this.CounterCategoryID = CounterCategoryID;
            this.Relevance = Relevance;
        }

        public int CategoryID
        { 
            get 
            { 
                if( Category != null )
                {
                    return Category.CategoryID;

                }
                else
                {
                    return -1;
                }
            }
            set 
            { 
                if( Category != null )
                    Category.CategoryID = (int) value; 
                else
                {

                }
            }
        }
        public int CounterCategoryID 
        { 
            get 
            {
                if (Category != null)
                {
                    return Category.CounterCategoryID;

                }
                else
                {
                    return -1;
                }
            }
            set 
            {
                if (Category != null)
                    Category.CounterCategoryID = (int)value;
                else
                {

                }
            }
        }
        public string? Headline1 { get { return Category!.Headline1; } }
        public string? Headline2 { get { return Category!.Headline2;  } }
        public string? ContextMenuText { get { return Category!.ContextMenuText; } }
        public string? ParseLine { get { return Category!.ParseLine; } }
    }
    [Serializable]
    public class CategoryList
    {
        public List<Category>? List { get; set; }

        public CategoryList()
        {
            List = new List<Category>();
        }

        public Category? Find(int ID)
        {
            Category? Ret = null;

            foreach (Category c in List!)
            {
                
                if (c.CategoryID == ID)
                {
                    Ret = c;
                }
                if (Ret != null) break;
            }
            return Ret;

        }
        public CategoryRel? FindAsRel(int ID, relTypes rType = relTypes.r_essential )
        {
            Category? Ret = null;

            foreach (Category c in List!)
            {

                if (c.CategoryID == ID)
                {
                    Ret = c;
                }
                if (Ret != null) break;
            }
            CategoryRel? cRel = new CategoryRel(Ret, rType);
            return cRel;

        }

        public void Delete( int ID )
        {
            int DelIx = FindIx(ID);
            if( DelIx > 0 )
                List!.RemoveAt(DelIx);
        }
        public int FindIx(int ID)
        {
            int Index = -1;

            for (int i = 0; i < List!.Count; i++)
            {
                if (List[i].CategoryID == ID)
                {
                    Index = i;
                }
                if (Index > -1) break;
            }
            return Index;

        }
        public void Add(Category AO)
        {
            if (List == null)
            {
                List = new List<Category>();
            }
            // new this.GetType().GetConstructor();
            List.Add(AO);
        }
        public void Add( int CategoryID )
        {
            List!.Add( ( Find(CategoryID) as Category )! ); 
        }

        public Category Last()
        {
            return (List![List!.Count - 1]!);
        }
    }
    [Serializable]
    public class CategoryRelList
    {
        public Dictionary<int,CategoryRel>? List { get; set; }

        public CategoryRelList()
        {
            List = new Dictionary<int, CategoryRel>();

        }

        public CategoryRelList( bool fullInit = false)
        {
            List = new Dictionary<int, CategoryRel>();

            if( fullInit)
                loca.GD!.AddLanguageCallback(RestoreCategoryRelList);
        }


        public bool RestoreCategoryRelList( )
        {
            Dictionary<int, CategoryRel>? TList2 = new Dictionary<int, CategoryRel>();

            foreach (KeyValuePair<int,CategoryRel> el in List!)
            {
                TList2.Add(el.Key, el.Value );

            }
            List = TList2;
            TList2 = null;


            return true;
        }

        public CategoryRel? Find(int ID)
        {
            if( List!.ContainsKey( ID ) == true )
            {
                return (List[ID]);
            }
            return null;
            /*
            CategoryRel? Ret = null;

            foreach (CategoryRel c in List!)
            {

                if( c != null )
                {
                    if (c.CategoryID == ID )
                        Ret = c;
                }
                if (Ret != null) break;
            }
            return Ret;
            */
        }

        public void Delete(int ID)
        {
            List!.Remove(ID);
            /*
            int DelIx = FindIx(ID);
            if (DelIx >= 0)
                List!.RemoveAt(DelIx);
            */
        }
        /*
        public int FindIx(int ID)
        {
            int Index = -1;

            for (int i = 0; i < List!.Count; i++)
            {
                if (List[i].CategoryID == ID)
                {
                    Index = i;
                }
                if (Index > -1) break;
            }
            return Index;
        }
            */
        public void Add(CategoryRel? AO)
        {
            if (AO == null)
                return;

            if (List == null)
            {
                List = new Dictionary<int, CategoryRel>();
            }
            if(List.ContainsKey(AO.CategoryID ) == true )
            {

            }
            // new this.GetType().GetConstructor();
            List.Add(AO.CategoryID, AO);
        }
        public void Add(CategoryRel? AO, relTypes rt)
        {
            if (List == null)
            {
                List = new Dictionary<int, CategoryRel>();
            }
            // new this.GetType().GetConstructor();
            CategoryRel AO1 = new CategoryRel( AO!.Category, rt );
            if (List.ContainsKey(AO1.CategoryID) == true)
            {

            }
            List.Add(AO1.CategoryID, AO1);
        }
        public void Add(int CategoryID)
        {
            CategoryRel? ao1 = Find(CategoryID); 
            List!.Add(ao1!.CategoryID, ao1);
        }
        /*
        public CategoryRel? Last()
        {
            return (List![List!.Count - 1]);
        }
        */
    }
}