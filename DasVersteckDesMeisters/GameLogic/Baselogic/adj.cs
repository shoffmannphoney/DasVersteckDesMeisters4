using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Xml.Linq;
using Newtonsoft.Json;

using Phoney_MAUI.Model;

namespace GameCore
{

    [Serializable]

    public class Adj: IWord
    {
        private string? _name;
        public string? LocaHandle
        {
            get;
            set;
        }

        [JsonIgnore]
        public string? Name 
        { 
            get 
            {
                try
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
                catch (Exception e)
                {
                    Phoney_MAUI.Core.GlobalData.AddLog("Adj Name getter: " + e.Message, IGlobalData.protMode.crisp);
                    return null;
                }

            }
            set
            {
                _name = value;
            }
        }

        public int ID { get; set; }

        public string? Loca { get; set; }

        public string? AdverbName
        {
            get { return Name; }
        }

        public Adj()
        {
            this.ID = 0;
            this.Name = null;
        }

        public Adj(int ID, string? Name) 
        {
            this.ID = ID;
            this.Name = Name; 
        }

        public static Adj? AdjLoca( int ID, string? locaName )
        {
            Adj adj = new();
            adj.ID = ID;
            adj.Loca = locaName;

            return adj;
        }
        public static Adj? AdjLoca( string? locaName)
        {
            return (AdjLoca(SerialNumberGenerator.Instance.NextSerial, locaName));
        }
        public static Adj AdjLocaLoca(int ID, string locaHandle, string locaName)
        {
            Adj adj = new();
            adj.ID = ID;
            adj.LocaHandle = locaHandle;
            adj.Loca = locaName;

            return adj;
        }
        public static Adj AdjLocaLoca(string locaHandle, int ID, string locaName)
        {
            Adj adj = new();
            adj.ID = ID;
            adj.LocaHandle = locaHandle;
            adj.Loca = locaName;

            return adj;
        }
        public static Adj AdjLocaLoca(string locahandle, string locaName)
        {
            return (AdjLocaLoca(SerialNumberGenerator.Instance.NextSerial, locahandle, locaName));
        }

        public Adj( string? locaName) : this(SerialNumberGenerator.Instance.NextSerial,  locaName)
        {

        }
     }

    [Serializable]

    public class AdjList: IWordList<Adj>
    {
        public IDictionary<string, Adj>? TList
        {
            get
            {
                if (loca.GD!.Language == IGlobalData.language.english)
                {
                    return (TListE);
                }
                else
                {
                    return (TListD);

                }
            }
            set
            {
                if (loca.GD!.Language == IGlobalData.language.english)
                {
                    TListE = value;
                }
                else
                {
                    TListD = value;
                }
            }
        }
        public IDictionary<string, Adj>? TListE { get; set; }
        public IDictionary<string, Adj>? TListD { get; set; }

        // public IDictionary<string, Adj> TList { get; set;  }
        // private IDictionary<string, Adj> TList2 { get; set; }
        // public IList<Adj> TList { get; set; }
        List<KeyValuePair<string, Adj>>? AdjBuffer = null;

        public void SetupAdjBuffer(int size)
        {
            AdjBuffer = new List<KeyValuePair<string, Adj>>(size);
        }
        public List<KeyValuePair<string, Adj>>? GetAdjBuffer()
        {
            return AdjBuffer;
        }

        public AdjList() 
        {
            TList = new Dictionary<string,Adj>(StringComparer.CurrentCultureIgnoreCase);
            loca.GD!.AddLanguageCallback(RestoreAdjectives);
       }

        public bool RestoreAdjectives()
        {
            try
            {
                if (loca.GD!.Language == IGlobalData.language.english)
                {
                    if (TListD == null)
                        TListD = TListE;

                    IDictionary<string, Adj>? TList2 = new Dictionary<string, Adj>(StringComparer.CurrentCultureIgnoreCase);

                    foreach (var ele in TListD!.Values)
                    {
                        Adj ele2 = (Adj)ele;

                        TypeInfo x = typeof(loca).GetTypeInfo();
                        PropertyInfo? pi = x.GetProperty(ele.Loca!);

                        string? s = (string?)pi!.GetValue(null);

                        ele2.LocaHandle = s;

                        TList2.Add(key: ele2.Name!, value: ele2);
                        /*
                       Adj ele2 = (Adj)ele;

                       TList2.Add(key: ele2.Name!, value: ele2);
                       */
                        // TList2.Add(key: ele2.Name, value: ele2);
                    }
                    TListE = TList2;
                    TList2 = null;

                }
                else if (loca.GD!.Language == IGlobalData.language.german)
                {
                    if (TListE == null)
                        TListE = TListD;

                    IDictionary<string, Adj>? TList2 = new Dictionary<string, Adj>(StringComparer.CurrentCultureIgnoreCase);

                    foreach (var ele in TListE!.Values)
                    {
                        Adj ele2 = (Adj)ele;

                        TypeInfo x = typeof(loca).GetTypeInfo();
                        PropertyInfo? pi = x.GetProperty(ele.Loca!);

                        string? s = (string?)pi!.GetValue(null);

                        ele2.LocaHandle = s;

                        TList2.Add(key: ele2.Name!, value: ele2);

                        /*
                        Adj ele2 = (Adj)ele;

                        TList2.Add(key: ele2.Name!, value: ele2);
                        // TList2.Add(key: ele2.Name, value: ele2);

                        */
                    }
                    TListD = TList2;
                    TList2 = null;

                }

                /*
                TList2 = new Dictionary<string, Adj>(StringComparer.CurrentCultureIgnoreCase);

                foreach(var ele in TList.Values )
                {
                    Adj ele2 = (Adj)ele;

                    TList2.Add(key: ele2.Name, value: ele2);
                }
                TList = TList2;
                TList2 = null;
                */
                return true;
            }
            catch (Exception e)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("RestoreAdjectives: " + e.Message, IGlobalData.protMode.crisp);
                return false;
            }

        }

        public Adj Add(int ID, string? name)
        {
            if (TList == null)
            {
                TList = new Dictionary<string,Adj>(StringComparer.CurrentCultureIgnoreCase);
            }
            Adj a = new Adj(ID, name);
            string sname = "bla";
            if (name != null) sname = name;
            TList.Add( key: sname, value: a);
            return (a);
        }

        public Adj? Add( string? name )
        {
            if (TList == null)
            {
                TList = new Dictionary<string,Adj>(StringComparer.CurrentCultureIgnoreCase);
            }
            Adj a = new Adj(name);
            string sname = "bla";
            if (name != null) sname = name;
            TList.Add(key: sname, value: a);
            return (a);
        }

        public Adj? Add( Adj? adj )
        {
            AdjBuffer!.Add(new(adj!.Name!, adj));
            return (adj);
            /*
             if (TList == null)
             {
                 TList = new Dictionary<string, Adj>(StringComparer.CurrentCultureIgnoreCase);
             }
             string sname = "bla";
             if (adj != null) sname = adj!.Name!;
             TList!.Add(key: sname!, value: adj!);
             return (adj);
             */
        }

        public Adj? Find( string? name )
        {
            Adj? Ret = null;

            foreach (var ele in TList!.Values)
            {
                Adj ele2 = (Adj)ele;
                // Noloca: 002

                if (String.Compare(ele2.Name!, name!) == 0)
                {
                    Ret = ele2;
                }
                if (Ret != null) break;
                /*
                if (String.Compare(ele.Name.ToLower(new CultureInfo( "de-DE", false)), name.ToLower(new CultureInfo( "de-DE", false))) == 0)
                {
                    Ret = ele;
                }
                if (Ret != null) break;
                */
            }
            return Ret;
        }

        public Adj? Find( int ID )
        {
            // return TList[ ID ];
            Adj? Ret = null;


            foreach (Adj ele in TList!.Values)
            {
                if (ele.ID == ID)
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret;
        }

        public string? GetAdj(int AdjID)
        {
            return (Find( AdjID )!.Name );
        }

        public string? GetAdverb(int AdjID)
        {
            return (Find(AdjID)!.Name);
        }

        public Adj? FindAdj(string name)
        {
            try
            {

                Adj? Ret = null;
                // Noloca: 001

                string? name1 = name.ToLower(new CultureInfo("de-DE", false));
                string? name2 = null;
                string? name3 = null;

                // Noloca: 001
                if (name.EndsWith("e"))
                {
                    name2 = name.Substring(0, name.Length - 1);
                }
                // Noloca: 004
                if (name.EndsWith("es") || name.EndsWith("er") || name.EndsWith("en") || name.EndsWith("em"))
                {
                    name3 = name.Substring(0, name.Length - 2);
                }

                if (name3 != null)
                {
                    if (TList!.ContainsKey(name3))
                    {
                        Ret = TList[name3];
                    }

                }
                if (Ret == null && name2 != null)
                {
                    if (TList!.ContainsKey(name2))
                    {
                        Ret = TList[name2];
                    }

                }
                if (Ret == null && name1 != null)
                {
                    if (TList!.ContainsKey(name1))
                    {
                        Ret = TList[name1];
                    }

                }
                return Ret;
                /*
                Adj Ret = null;


                foreach (Adj ele in TList.Values )
                {
                    Adj ele2 = (Adj)ele;
                    if ((String.Compare(name.ToLower(new CultureInfo( "de-DE", false)), ele2.Name.ToLower(new CultureInfo( "de-DE", false))) == 0)
                           || (String.Compare(name.ToLower(new CultureInfo( "de-DE", false)), ele2.Name.ToLower(new CultureInfo( "de-DE", false)) + "e") == 0)
                           || (String.Compare(name.ToLower(new CultureInfo( "de-DE", false)), ele2.Name.ToLower(new CultureInfo( "de-DE", false)) + " es") == 0)
                           || (String.Compare(name.ToLower(new CultureInfo( "de-DE", false)), ele2.Name.ToLower(new CultureInfo( "de-DE", false)) + "er") == 0)
                           || (String.Compare(name.ToLower(new CultureInfo( "de-DE", false)), ele2.Name.ToLower(new CultureInfo( "de-DE", false)) + "en") == 0)
                           || (String.Compare(name.ToLower(new CultureInfo( "de-DE", false)), ele2.Name.ToLower(new CultureInfo( "de-DE", false)) + "em") == 0)
                       )
                    {
                        Ret = ele2;
                    }
                    if (Ret != null) break;
                }
                return Ret;
                */
            }
            catch (Exception e)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("FindAdj: " + e.Message, IGlobalData.protMode.crisp);
                return null;
            }

        }
    }

}

