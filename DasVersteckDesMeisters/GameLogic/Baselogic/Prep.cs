using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Input;
using Newtonsoft.Json;

namespace GameCore
{
    [Serializable]

    public class Prep: IWord
    {

        public string? LocaHandle
        {
            get;
            set;
        }
        public string? Loca { get; set; }
        private string? _name;

        public string? Name
        {
            get
            {
                if (LocaHandle != null)
                {
                    return LocaHandle;
                }
                else if(Loca != null)
                {
                    if (!string.IsNullOrEmpty(Loca))
                    {
                        Type t = typeof(loca);

                        PropertyInfo pi = t.GetProperty(Loca)!;

                        // var prop = loca.GetType().GetProperty(Loca);
                        var s = pi.GetValue(null) as string;

                        return s!;
                    }
                    else
                        return _name!;
                }
                else
                    return _name!;
            }
            set
            {
                _name = value;
            }
        }

        public int ID { get; set; }

        [JsonConstructor]

        public Prep(int ID, string? Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public Prep(string Name) : this(SerialNumberGenerator.Instance.NextSerial, Name)
        {

        }
    }
    [Serializable]

    public class PrepList: IWordList<Prep>
    {

        public IDictionary<string, Prep>? TList { get; set; }

        public PrepList() : base()
        {
            TList = new Dictionary<string, Prep>(StringComparer.CurrentCultureIgnoreCase);
            loca.GD!.AddLanguageCallback(RestorePrep);
        }

        public Prep? Add(int ID, string? name)
        {
            if (TList == null)
            {
                TList = new Dictionary<string, Prep>();
            }
            Prep? p = new Prep(ID, name);
            TList.Add( p.Name!, p );
            return p;
        }

        public Prep? Add( string? name )
        {
            return Add(SerialNumberGenerator.Instance.NextSerial, name);
        }

        public Prep Add(Prep prep)
        {
            if (TList == null)
            {
                TList = new Dictionary<string, Prep>();
            }
            TList.Add(prep.Name!, prep);
            return (prep);

        }

        public string GetPrep(int PrepID)
        {
            return (Find(PrepID)!.Name!);
        }

        public virtual Prep? Find(string? name)
        {
            // string? name = name2;
            if (TList!.ContainsKey(name!))
                return (TList[name!]);
            return null!;
            /*
            Prep? Ret = null;

            foreach (Prep ele in TList!)
            {
                // Noloca: 002
                if (String.Compare(ele.Name!.ToLower(new CultureInfo( "de-DE", false)), name!.ToLower(new CultureInfo( "de-DE", false))) == 0)
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret;
            */
        }
        public Prep Find(int ID)
        {
            Prep? Ret = null;

            foreach (Prep ele in TList!.Values)
            {
                if (ele.ID == ID)
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret!;

        }

        public Prep AddLoca(int ID, string locaName)
        {
            if (TList == null)
            {
                TList = new Dictionary<string, Prep>();
            }
            Prep p = new(ID, null!);
            p.Loca = locaName;

            TList.Add(p.Name!, p);
            return p;
        }
        public Prep AddLoca(string locaName)
        {
            return AddLoca(SerialNumberGenerator.Instance.NextSerial, locaName);
        }


        public bool RestorePrep()
        {
            IDictionary<string, Prep>? TList2 = new Dictionary<string, Prep>();

            foreach (var ele in TList!.Values)
            {
                Prep ele2 = (Prep)ele;

                TypeInfo x = typeof(loca).GetTypeInfo();
                PropertyInfo? pi = x.GetProperty(ele.Loca!);

                string? s = (string?)pi!.GetValue(null);

                ele2.LocaHandle = s;

                TList2.Add(key: ele2.Name!, value: ele2);

                /*
                Prep ele2 = (Prep)ele;

                TList2.Add(ele2.Name, ele2);
                */
            }
            TList = TList2;
            TList2 = null;

            return true;
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