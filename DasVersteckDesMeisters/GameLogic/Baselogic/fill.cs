using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Newtonsoft.Json;

namespace GameCore
{

    [Serializable]

    public class Fill: IWord
    {

        public string? Loca { get; set; }
        private string? _name;

        public string? Name
        {
            get
            {
                if (Loca != null)
                {
                    if (!string.IsNullOrEmpty(Loca))
                    {
                        Type? t = typeof(loca);

                        PropertyInfo? pi = t!.GetProperty(Loca);

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


        public Fill(int ID, string? Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public Fill()
        {

        }
        [JsonConstructor]

        public Fill(string? Name) : this(SerialNumberGenerator.Instance.NextSerial, Name)
        {

        }
    }
    [Serializable]

    public class FillList: IWordList<Fill>
    {

        public IList<Fill> TList { get; set; }

        public FillList() : base()
        {
            loca.GD!.AddLanguageCallback(RestoreFill);
            TList = new List<Fill>();
        }

        public  Fill Add(int ID, string? name)
        {
            if (TList == null)
            {
                TList = new List<Fill>();
            }
            Fill f = new Fill(ID, name);
            TList.Add( f );
            return (f);
        }

        public  Fill Add( string? name) 
        {
            return Add(SerialNumberGenerator.Instance.NextSerial, name);
        }

        public Fill Add ( Fill fill )
        {
            if (TList == null)
            {
                TList = new List<Fill>();
            }
            TList.Add(fill);
            return (fill);

          

        }

        public string? GetFill(int FillID)
        {
            return (Find(FillID)!.Name);
        }


        public virtual Fill?  Find(string? name)
        {
            Fill? Ret = null;

            foreach (Fill ele in TList)
            {
                // Noloca: 002

                if (String.Compare(ele.Name!.ToLower(new CultureInfo( "de-DE", false)), name!.ToLower(new CultureInfo( "de-DE", false))) == 0)
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret;

        }

        public Fill? Find(int ID)
        {
            Fill? Ret = null;

            foreach (Fill ele in TList)
            {
                if (ele.ID == ID)
                {
                    Ret = ele;
                }
                if (Ret != null) break;
            }
            return Ret;

        }

        public Fill AddLoca(int ID, string locaName)
        {
            if (TList == null)
            {
                TList = new List<Fill>();
            }
            Fill f = new(ID, null);
            f.Loca = locaName;

            TList.Add(f);
            return f;
        }
        public Fill AddLoca(string locaName)
        {
            return AddLoca(SerialNumberGenerator.Instance.NextSerial, locaName);
        }


        public bool RestoreFill()
        {
            IList<Fill>? TList2 = new List<Fill>();

            foreach (var ele in TList)
            {
                Fill ele2 = (Fill)ele;

                TList2.Add(ele2);
            }
            TList = TList2;
            TList2 = null;

            return true;
        }
    }
}

