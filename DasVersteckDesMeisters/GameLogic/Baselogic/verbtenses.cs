using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

using Phoney_MAUI.Model;

namespace GameCore
{
    [Serializable]

    public class VTL
    {
        string? Loca { get; set; }
        string? _verbNameTense;

        public VTL( string? loca, string? verbNameTense)
        {
            this.Loca = loca;
            this.VerbNameTense = verbNameTense;
        }
        public string? VerbNameTense
        {
            get
            {
                if (Loca != null)
                {
                    if (!string.IsNullOrEmpty(Loca))
                    {
                        Type t = typeof(loca);

                        PropertyInfo pi = t!.GetProperty(Loca)!;

                        // var prop = loca.GetType().GetProperty(Loca);
                        var s = (pi!.GetValue(null) as string)!;

                        return s;
                    }
                    else
                        return _verbNameTense;
                }
                else
                    return _verbNameTense;
            }
            set
            {
                _verbNameTense = value;
            }

        }
    }
    [Serializable]
    public class VerbTenses
    {
        public List<VTL>? _vtl;

        public int ID { get; set; }

        public List<VTL> VerbNameTense 
        { 
            get { return _vtl!; }
            set { _vtl = value;  }
        }

        public VerbTenses()
        {

        }
        public VerbTenses(int VTID, string s0, string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12)
        {
            ID = VTID;
            VerbNameTense = new List<VTL>();

            VerbNameTense.Add( new VTL(null, s0) ) ;
            VerbNameTense.Add(new VTL(null, s1));
            VerbNameTense.Add(new VTL(null, s2));
            VerbNameTense.Add(new VTL(null, s3));
            VerbNameTense.Add(new VTL(null, s4));
            VerbNameTense.Add(new VTL(null, s5));
            VerbNameTense.Add(new VTL(null, s6));
            VerbNameTense.Add(new VTL(null, s7));
            VerbNameTense.Add(new VTL(null, s8));
            VerbNameTense.Add(new VTL(null, s9));
            VerbNameTense.Add(new VTL(null, s10));
            VerbNameTense.Add(new VTL(null, s11));
            VerbNameTense.Add(new VTL(null, s12));
        }

    }
    [Serializable]

    public class VTList
    {

        public List<VerbTenses> List;

        public bool RestoreVTList()
        {
            return true;
        }
        public VTList()
        {
            List = new List<VerbTenses>();
            loca.GD!.AddLanguageCallback(RestoreVTList);

        }

        public void Add(int ID, string s0, string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12)
        {
            if (List == null)
            {
                List = new List<VerbTenses>();
            }
            List.Add(new VerbTenses(ID, s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12 ));
        }
        public void AddLoca(int ID, string s0, string s1, string s2, string s3, string s4, string s5, string s6, string s7, string s8, string s9, string s10, string s11, string s12)
        {
            if (List == null)
            {
                List = new List<VerbTenses>();
            }
            List.Add(VTList.VerbTensesLoca(ID, s0, s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12));
        }

        public void Add(VerbTenses VT)
        {
            if (List == null)
            {
                List = new List<VerbTenses>();
            }
            List.Add(VT);
        }

        public VerbTenses? Find(int pID)
        {
            VerbTenses? tSt = null;

            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].ID == pID)
                {
                    tSt = List[i];
                }
            }
            return (tSt);
        }
        public static VerbTenses VerbTensesLoca(int VTID, string s0Loca, string s1Loca, string s2Loca, string s3Loca, string s4Loca, string s5Loca, string s6Loca, string s7Loca, string s8Loca, string s9Loca, string s10Loca, string s11Loca, string s12Loca)
        {
            VerbTenses vt = new();

            vt.VerbNameTense = new List<VTL>();
            vt.ID = VTID;

            vt.VerbNameTense.Add( new VTL(s0Loca, null));
            vt.VerbNameTense.Add(new VTL(s1Loca, null));
            vt.VerbNameTense.Add(new VTL(s2Loca, null));
            vt.VerbNameTense.Add(new VTL(s3Loca, null));
            vt.VerbNameTense.Add(new VTL(s4Loca, null));
            vt.VerbNameTense.Add(new VTL(s5Loca, null));
            vt.VerbNameTense.Add(new VTL(s6Loca, null));
            vt.VerbNameTense.Add(new VTL(s7Loca, null));
            vt.VerbNameTense.Add(new VTL(s8Loca, null));
            vt.VerbNameTense.Add(new VTL(s9Loca, null));
            vt.VerbNameTense.Add(new VTL(s10Loca, null));
            vt.VerbNameTense.Add(new VTL(s11Loca, null));
            vt.VerbNameTense.Add(new VTL(s12Loca, null));

            return vt;
        }
    }
}