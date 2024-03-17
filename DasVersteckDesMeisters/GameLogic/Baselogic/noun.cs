using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Xml.Linq;
using Newtonsoft.Json;

using Phoney_MAUI.Model;

namespace GameCore
{
    public static class ReflectionHelper
    { 
    }

        [Serializable]
    public class Noun: IWord
    {
        public string? LocaHandle 
        {
            get;
            set; 
        }
        public string? Loca { get; set; }
        private string? _name;
        public int ix;
 
        [JsonIgnore]
        public string? Name
        {
            get
            {
                /*
                if( ix > 0 )
                {
                    TypeInfo x = typeof(loca).GetTypeInfo();
                    PropertyInfo pi = x.DeclaredProperties.ElementAt(ix);

                    string s = (string)pi.GetValue(null);
                    return s;
                }
                else 
                */
                if( LocaHandle != null)
                {
                    return LocaHandle;
                }
                else if (Loca != null)
                {
                    if (!string.IsNullOrEmpty(Loca))
                    {
                        Type? t = typeof(loca);

                        PropertyInfo? pi = t.GetProperty(Loca);

                        // TypeInfo x = typeof(loca).GetTypeInfo();
                        // x.GetPro
                        // TypeInfo x = ((t as System.RuntimeType).DeclaredProperties.ElementAt(4).GetMethod as MethodInfo);

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

        public int ID { get; set; }


        public Noun()
        {
            this.ix = -1;
        }

        public Noun(int ID, string? Name)
        {
            this.ID = ID;
            this.Name = Name;
            this.ix = -1;
        }

        public Noun(string Name) : this(SerialNumberGenerator.Instance.NextSerial, Name)
        {
            this.ix = -1;
        }
        public static Noun NounLoca(int ID, string locaName)
        {
            Noun noun = new();
            noun.ID = ID;
            noun.Loca = locaName;

            return noun;
        }
        public static Noun NounLoca(string locaName)
        {
            return (NounLoca(SerialNumberGenerator.Instance.NextSerial, locaName));
        }

        public static Noun NounLocaLoca(int ID, string locaHandle, string locaName)
        {
            Noun noun = new();
            noun.ID = ID;
            noun.LocaHandle = locaHandle;
            noun.Loca = locaName;

            return noun;
        }
        public static Noun NounLocaLoca(string locahandle, string locaName)
        {
            return (NounLocaLoca(SerialNumberGenerator.Instance.NextSerial, locahandle, locaName));
        }

    }
    [Serializable]

    public class NounList: IWordList<Noun>
    {
        public IDictionary<string,Noun>? TList 
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
        public IDictionary<string, Noun>? TListE { get; set; }
        public IDictionary<string, Noun>? TListD { get; set; }

        List<KeyValuePair<string, Noun>>? NounBuffer = null;

        public void SetupNounBuffer( int size )
        {
            NounBuffer = new List<KeyValuePair<string, Noun>>(size);
        }
        public List<KeyValuePair<string, Noun>>? GetNounBuffer()
        {
            return NounBuffer;
        }

        // CultureInfo CI;
        public NounList() : base()
        {
            TList = new Dictionary<string, Noun>(StringComparer.CurrentCultureIgnoreCase);
            loca.GD!.AddLanguageCallback(RestoreNouns);
            // CI = new CultureInfo("de-DE", false);
        }
        /*
        public Noun? Add(int ID, string? name)
        {
            if (TList == null)
            {
                TList = new Dictionary<string, Noun>(StringComparer.CurrentCultureIgnoreCase);
            }
            Noun n = new Noun(ID, name);
            // Noloca: 001
            TList.Add( key: name!.ToLower(), value: n );
            return n;
        }

        public Noun AddLoca(int ID, string locaName)
        {
            if (TList == null)
            {
                TList = new Dictionary<string, Noun>(StringComparer.CurrentCultureIgnoreCase);
            }
            Noun n = new( ID, null );
            n.Loca = locaName;

            // Noun n = new Noun(ID, name);
            // Noloca: 001

            TList.Add(key: n.Name!.ToLower(), value: n);
            return n;
        }


        public Noun? Add( string? name )
        {
            return Add(SerialNumberGenerator.Instance.NextSerial, name);
        }

        public Noun? Add(Noun? noun)
        {
            if (TList == null)
            {
                TList = new Dictionary<string, Noun>(StringComparer.CurrentCultureIgnoreCase);
            }
            // Noloca: 001
            TList.Add( key: noun!.Name!.ToLower(), value: noun);
            // TList.Add(key: noun!.ID!, value: noun);
            return (noun);
        }
        */
        public Noun? Add(int ID, string? name)
        {
            Noun n = new Noun();
            n.Name = name;
            NounBuffer!.Add(new(n.Name!.ToLower(), n));
            return n;
        }

        public Noun AddLoca(int ID, string locaName)
        {
            Noun n = new Noun();
            n.ID = ID;
            n.Loca = locaName;
            NounBuffer!.Add(new(n.Name!, n));


            // Noun n = new Noun(ID, name);
            // Noloca: 001
            return n;
        }
        public Noun AddLocaLoca(int ID, string locahandle, string locaName)
        {
            Noun n = new Noun();
            n.ID = ID;
            n.LocaHandle = locahandle;
            n.Loca = locaName;
            NounBuffer!.Add(new(n.Name!, n));


            // Noun n = new Noun(ID, name);
            // Noloca: 001
            return n;
        }


        public Noun? Add(string? name)
        {
            return Add(SerialNumberGenerator.Instance.NextSerial, name);
        }

        public Noun? Add(Noun? noun)
        {
            NounBuffer!.Add(new(noun!.Name!.ToLower(), noun));
            return (noun);
        }

        public string? GetNoun(int NounID)
        {
            return (Find(NounID)!.Name);
        }


        public Noun? Find(string? name)
        {
            Noun? Ret = null;
            // Noloca: 004
            string? name1 = name!.ToLower();
            string? name2 = null;

            if (name!.EndsWith( "en") || name!.EndsWith( "ern"))
            {
                name2 = name1!.Substring(0, name1!.Length - 1);
            }
            else if (name!.EndsWith( "eln") )
            {
                name2 = name1!.Substring(0, name1!.Length - 1);
            }

            if (name2 != null)
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
                        Noun Ret = null;

                        string name2 = name;
                        string add2 = "";

                        char lastChar = name2[name2.Length - 1];
                        if( lastChar == 'r' || lastChar == 'e') 
                         {
                            name2 = name2 + "n";
                            add2 = "n";
                        }

                        foreach (Noun ele in TList)
                        {
                            if (        ( String.Compare(ele.Name.ToLower(new CultureInfo( "de-DE", false)), name.ToLower(new CultureInfo( "de-DE", false))) == 0)
                                    ||  ( String.Compare(ele.Name.ToLower(new CultureInfo( "de-DE", false)) + add2, name2.ToLower(new CultureInfo( "de-DE", false))) == 0)
                               )
                            {
                                Ret = ele;
                            }
                            if (Ret != null) break;
                        }
                        return Ret;
                        */
        }

        void CheckTList()
        {
            if (TList == null)
            {
                if (loca.GD!.Language == IGlobalData.language.english && TListE == null)
                {
                    RestoreNouns();
                }
                else if (loca.GD!.Language == IGlobalData.language.german && TListD == null)
                {
                    RestoreNouns();
                }

            }
        }
        public Noun? Find(int ID)
        {
            Noun? Ret = null;

            CheckTList();

            foreach (Noun ele in TList!.Values)
            {
                if (ele.ID == ID)
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret;
        }

        private class StringEqualityComparer : IEqualityComparer<string>
        {
            public static IEqualityComparer<string> sComparer { get; } = new StringEqualityComparer();
            public bool Equals(string? x, string? y)
            {
                /*
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Name == y.Name;
                */
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x == y;
            }

            public int GetHashCode(string n)
            {
                return (n != null ? GetHashCodeString( n ) : 0);
            }
            public unsafe int GetHashCodeString(string hashString)
            {
                fixed (char* str = hashString)
                {
                    char* chPtr = str;
                    int num = 0x15051505;
                    int num2 = num;
                    int* numPtr = (int*)chPtr;
                    for (int i = hashString.Length; i > 0; i -= 4)
                    {
                        num = (((num << 5) + num) + (num >> 0x1b)) ^ numPtr[0];
                        if (i <= 2)
                        {
                            break;
                        }
                        num2 = (((num2 << 5) + num2) + (num2 >> 0x1b)) ^ numPtr[1];
                        numPtr += 2;
                    }
                    return (num + (num2 * 0x5d588b65));
                }
            }
        }

        public bool RestoreNouns()
        {
            if (loca.GD!.Language == IGlobalData.language.english )
            {
                if (TListD == null)
                    TListD = TListE;

                IDictionary<string, Noun>? TList2 = new Dictionary<string, Noun>(StringComparer.CurrentCultureIgnoreCase);

                foreach (var ele in TListD!.Values)
                {
                    Noun ele2 = (Noun)ele;
                    /*
                    ele2.Loca = ele.Loca;
                    ele2.ID = ele.ID;
                    ele2.LocaHandle = ele.LocaHandle;
                    ele2.Name = ele.Name;
                    */
                    TypeInfo x = typeof(loca).GetTypeInfo();
                    PropertyInfo? pi = x.GetProperty(ele.Loca!); 

                    string? s = (string?)pi!.GetValue(null);

                    ele2.LocaHandle = s;

                    TList2.Add(key: ele2.Name!, value: ele2);
                    // TList2.Add(key: ele2.Name, value: ele2);
                }
                TListE = TList2;
                TList2 = null;

            }
            else if (loca.GD!.Language == IGlobalData.language.german )
            {
                IDictionary<string, Noun>? TList2 = new Dictionary<string, Noun>(StringComparer.CurrentCultureIgnoreCase);
                if (TListE == null)
                    TListE = TListD;

                foreach (var ele in TListE!.Values)
                {
                    Noun ele2 = (Noun)ele;
                    /*
                    ele2.Loca = ele.Loca;
                    ele2.ID = ele.ID;
                    ele2.LocaHandle = ele.LocaHandle;
                    ele2.Name = ele.Name;
                    */
                    TypeInfo x = typeof(loca).GetTypeInfo();
                    PropertyInfo? pi = x.GetProperty(ele.Loca!);

                    string? s = (string?)pi!.GetValue(null);

                    ele2.LocaHandle = s;

                    TList2.Add(key: ele2.Name!, value: ele2);
                    // TList2.Add(key: ele2.Name, value: ele2);
                }
                TListD = TList2;
                TList2 = null;

            }

            /*
            // TList.Count, StringEqualityComparer.sComparer
        IDictionary<string, Noun> TList2 = new Dictionary<string, Noun>( StringComparer.CurrentCultureIgnoreCase  );
        CultureInfo ci = new CultureInfo("de-DE", false);

        foreach (var ele in TList.Values)
        {
            Noun ele2 = (Noun)ele;

            TList2.Add(key: ele2.Name.ToLower( ci ), value: ele2);
            // TList2.Add(key: ele2.Name, value: ele2);
        }
        TList = TList2;
        TList2 = null;
            */

            return true;
        }
    }
}
