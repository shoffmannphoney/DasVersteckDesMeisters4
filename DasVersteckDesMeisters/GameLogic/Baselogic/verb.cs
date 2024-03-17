using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Newtonsoft.Json;

using Phoney_MAUI.Model;

namespace GameCore
{
    [Serializable]

    public class Verb: IWord
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
                else if (Loca != null)
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
                        return _name;
                }
                else
                    return _name;
            }
            set
            {
                _name = value;
            }
        }

        public Verb()
        {
        }


        public int ID { get; set; }

        public Verb(int ID, string? Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
        [JsonConstructor]

        public Verb(string Name) : this(SerialNumberGenerator.Instance.NextSerial, Name)
        {

        }
        public static Verb? VerbLoca(int ID, string locaName)
        {
            Verb verb = new( ID, null );
            verb.ID = ID;
            verb.Loca = locaName;

            return verb;
        }
        public static Verb? VerbLoca(string locaName)
        {
            return (VerbLoca(SerialNumberGenerator.Instance.NextSerial, locaName));
        }
        public static Verb VerbLocaLoca(int ID, string locaHandle, string locaName)
        {
            Verb verb = new();
            verb.ID = ID;
            verb.LocaHandle = locaHandle;
            verb.Loca = locaName;

            return verb;
        }
        public static Verb VerbLocaLoca(string locahandle, string locaName)
        {
            return (VerbLocaLoca(SerialNumberGenerator.Instance.NextSerial, locahandle, locaName));
        }

    }


    [Serializable]

    public class VerbList: IWordList<Verb>
    {

        public IDictionary<string,Verb> TList { get; set; }

        List<KeyValuePair<string, Verb>>? VerbBuffer = null;

        public void SetupVerbBuffer(int size)
        {
            VerbBuffer = new List<KeyValuePair<string, Verb>>(size);
        }
        public List<KeyValuePair<string, Verb>>? GetVerbBuffer()
        {
            return VerbBuffer;
        }

        public VerbList() : base()
        {
            //  TList = new List<Verb>();
            TList = new Dictionary<string, Verb>(StringComparer.CurrentCultureIgnoreCase);
            loca.GD?.AddLanguageCallback(RestoreVerbs);
        }

        public Verb? Add(int ID, string? name)
        {
            if (TList == null)
            {
                TList = new Dictionary<string, Verb>(StringComparer.CurrentCultureIgnoreCase);
            }
            Verb? v = new Verb(ID, name);
            // Noloca: 001
            TList.Add( key: name!, value: v );
            return v;
        }

        public Verb Add( string? name )
        {
            return Add(SerialNumberGenerator.Instance.NextSerial!, name!)!;
        }
        public Verb AddLoca(int ID, string locaName)
        {
            if (TList == null)
            {
                TList = new Dictionary<string, Verb>(StringComparer.CurrentCultureIgnoreCase);
            }
            Verb v = new(ID, null);
            v.Loca = locaName;

            if (loca.GD?.Language == IGlobalData.language.german)
                TList.Add(key: v.Name!.ToLower(new CultureInfo("de-DE", false)), value: v);
            else
                TList.Add(key: v.Name!.ToLower(new CultureInfo("en-US", false)), value: v);


            return v;
        }
        public Verb AddLoca(string locaName)
        {
            return AddLoca(SerialNumberGenerator.Instance.NextSerial, locaName);
        }
        public Verb AddLocaLoca(string locahandle, string locaName)
        {
            return AddLocaLoca(SerialNumberGenerator.Instance.NextSerial, locahandle, locaName);
        }

        public Verb AddLocaLoca(int ID, string locahandle, string locaName)
        {
            Verb v = new Verb();
            v.ID = ID;
            v.LocaHandle = locahandle;
            v.Loca = locaName;
            VerbBuffer!.Add(new(v.Name!, v));


            // Noun n = new Noun(ID, name);
            // Noloca: 001
            return v;
        }
        public Verb AddLocaLoca(string locahandle, int ID, string locaName)
        {
            Verb v = new Verb();
            v.ID = ID;
            v.LocaHandle = locahandle;
            v.Loca = locaName;
            VerbBuffer!.Add(new(v.Name!.ToLower(), v));


            // Noun n = new Noun(ID, name);
            // Noloca: 001
            return v;
        }

        public Verb Find(string? name2)
        {
            // Noloca: 001
            string? name = name2;
            if (TList.ContainsKey(name!))
                return (TList[name!]);
            return null!;
            /*
            Verb Ret = null;

            string name2 = name;

            foreach (Verb ele in TList)
            {
                if ((String.Compare(ele.Name.ToLower(new CultureInfo( "de-DE", false)), name.ToLower(new CultureInfo( "de-DE", false))) == 0)
                        || (String.Compare(ele.Name.ToLower(new CultureInfo( "de-DE", false)), name2.ToLower(new CultureInfo( "de-DE", false))) == 0)
                   )
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret;
            */
        }

        public Verb? Find(int ID)
        {
            Verb? Ret = null;

            foreach (Verb ele in TList.Values)
            {
                if (ele.ID == ID)
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret;
        }

        public Verb? Find(Verb verb)
        {
            Verb? v = null;

            TList.TryGetValue(verb.Name!, out v);
            return v;
            /*
            // Noloca: 001
            if (TList.ContainsKey(verb.name))
                return (TList[name]);
            return null!;
            */
            /*
            Verb Ret = null;

            foreach (Verb ele in TList)
            {
                if (ele.ID == verb.ID)
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret;
            */
        }
        public bool RestoreVerbs()
        {
            IDictionary<string, Verb>? TList2 = new Dictionary<string, Verb>(StringComparer.CurrentCultureIgnoreCase);

            foreach (var ele in TList!.Values)
            {
                Verb ele2 = (Verb)ele;

                TypeInfo x = typeof(loca).GetTypeInfo();
                PropertyInfo? pi = x.GetProperty(ele.Loca!);

                string? s = (string?)pi!.GetValue(null);

                ele2.LocaHandle = s;

                TList2.Add(key: ele2.Name!, value: ele2);
                // TList2.Add(key: ele2.Name, value: ele2);
            }
            /*
            foreach (var ele in TList.Values)
            {
                Verb ele2 = (Verb)ele;

                if (loca.GD!.Language == IGlobalData.language.german)
                    TList2.Add(key: ele2.Name!, value: ele2);
                else
                    TList2.Add(key: ele2.Name!, value: ele2);
            }
            */
            TList = TList2;
            TList2 = null;

            return true;
        }

    }

    /*
    [Serializable]
    public class Verb : Word 
    {
        public Verb( int ID, string Name ): base( ID, Name )
        { 
        }

        /*
        public string VerbName { get; set; }
        public int VerbIndex { get; set; }
        public Verb(int oIndex, string oName)
        {
            VerbIndex = oIndex;
            VerbName = oName;

        }
    }
    */
}