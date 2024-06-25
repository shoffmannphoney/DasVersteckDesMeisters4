using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Input;
using Newtonsoft.Json;

namespace GameCore
{
    [Serializable]

    public class Pronoun: IWord
    {
        public string? Loca { get; set; }
        private string? _name;

        public string? Name
        {
            get
            {
                return loca.TextOrLoca(_name, Loca);
            }
            set
            {
                _name = value;
            }
        }

        public int ID { get; }

        public int Sex { get; }

        [JsonConstructor]

        public Pronoun(int id, string? name, int sex)
        {
            this.ID = id;
            this.Name = name;
            this.Sex = sex;
        }

        public Pronoun()
        {

        }

        public static Pronoun PronounLoca(int id, string? nameLoca, int sex)
        {
            Pronoun p = new( id, null, sex);
            p.Loca = nameLoca;

            return p;
        }
        public static Pronoun PronounLoca( string? nameLoca, int sex)
        {
            return PronounLoca(SerialNumberGenerator.Instance.NextSerial, nameLoca, sex);
        }

        public Pronoun(string name, int sex) : this(SerialNumberGenerator.Instance.NextSerial, name, sex)
        {

        }
    }
    [Serializable]

    public class PronounList: IWordList<Pronoun>
    {

        public IList<Pronoun> TList { get; set; }

        public PronounList() : base()
        {
            TList = new List<Pronoun>();
            loca.GD!.AddLanguageCallback(RestorePronouns);
        }

        public Pronoun Add(int ID, string? name, int sex)
        {
            if (TList == null)
            {
                TList = new List<Pronoun>();
            }
            Pronoun p = new Pronoun(ID, name, sex);
            TList.Add( p );
            return p;
        }

        public Pronoun Add(int id, string? name )
        {
            int sex = Co.SEX_MALE;
            Pronoun p = Find(name);
            if (p != null)
            {
                sex = p.Sex;
            }

            return Add(id, name, sex)!;
        }

        public Pronoun Add( string name, int sex )
        {
            return Add(SerialNumberGenerator.Instance.NextSerial, name, sex);
        }

        public Pronoun Add(string? name)
        {
            return Add(SerialNumberGenerator.Instance.NextSerial, name, Co.SEX_MALE)!;
        }

        public Pronoun Add(Pronoun pronoun)
        {
            if (TList == null)
            {
                TList = new List<Pronoun>();
            }
            TList.Add(pronoun);
            return (pronoun);

        }

        public string GetPronoun(int pronounID)
        {
            return (Find(pronounID).Name)!;
        }

        public virtual Pronoun  Find(string? name)
        {
            Pronoun? Ret = null;

            foreach (Pronoun ele in TList)
            {
                // Noloca: 002
                if (String.Compare(ele.Name!.ToLower(new CultureInfo( "de-DE", false)), name!.ToLower(new CultureInfo( "de-DE", false))) == 0)
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret!;

        }

        public Pronoun Find(int ID)
        {
            Pronoun? Ret = null;

            foreach (Pronoun ele in TList)
            {
                if (ele.ID == ID)
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret!;

        }

        public bool RestorePronouns()
        {
            try
            {
                IList<Pronoun>? TList2 = new List<Pronoun>();

                foreach (var ele in TList)
                {
                    Pronoun ele2 = (Pronoun)ele;

                    TList2.Add(ele2);
                }
                TList = TList2;
                TList2 = null;

                return true;
            }
            catch (Exception e)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("Pronoun.RestorePronouns: " + e.Message.ToString(), Phoney_MAUI.Model.IGlobalData.protMode.crisp);
                return false;
            }

        }
    }
}

/*
using System;

namespace advtest
{
    [Serializable]
    public class Prep
    {
        public string prepName { get; set; }
        public int prepID { get; set; }

        public Prep(int pID, string pName)
        {
            prepID = pID;
            prepName = pName;
        }
    }
}

*/