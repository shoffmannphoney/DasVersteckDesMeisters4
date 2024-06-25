using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Phoney_MAUI.Core;

namespace GameCore
{
    [Serializable]

    public static class Grammar
    {
        [JsonIgnore]
        public static GlobalData? GD
        {
            get => GlobalData.CurrentGlobalData;
            // set => GlobalData.CurrentGlobalData = value;
        }
        [JsonIgnore]
        public static ItemList? Items
        {
            get => GD!.Adventure!.Items;
            // set => GD.Adventure!.Items = value;
        }

        // private static ItemList? Items { get; set; }
        [JsonIgnore]
        public static PersonList? Persons
        {
            get => GD!.Adventure!.Persons;
            // set => GD.Adventure!.Persons = value;
        }

        // private static PersonList? Persons { get; set; }

        [JsonIgnore]
        public static AdvData? A
        {
            get => GD!.Adventure!.A;
            // set => GD.Adventure!.A = value;
        }
        //         [JsonIgnore]
        public static VTList? VT
        {
            get => GD!.Adventure!.VerbTenses;
            // set => GD.Adventure!.VT = value;
        }
        [JsonIgnore]
        public static Adv? AdvGame
        {
            get => GD!.Adventure;
            // set => GD.Adventure = value;
        }
        // private static AdvData? A { get; set; }

        // private static VTList? VT { get; set; }


        public static void Init( AdvData? pA, VTList? pVT,ItemList? pItems, PersonList? pPersons )
        {
            // Items = pItems;
            // Persons = pPersons;
            // A = pA;
            // VT = pVT;
        }

        public static string? GetReflexivePronoun(Person PersonID, int Case)
        {
            try
            {
                string s = "";
                if (Case == Co.CASE_AKK)
                {
                    if (PersonID.ID == A!.Adventure!.CA!.Person_I!.ID)
                        s = loca.Person_I_16092;
                    else if (PersonID.ID == A!.Adventure!.CA!.Person_You!.ID)
                        s = loca.Person_You_16093;
                    else
                        s = loca.Person_You_16094;
                }
                else if (Case == Co.CASE_DAT)
                {
                    if (PersonID.ID == A!.Adventure!.CA!.Person_I!.ID)
                        s = loca.Person_I_16095;
                    else if (PersonID.ID == A!.Adventure!.CA!.Person_You!.ID)
                        s = loca.Person_You_16096;
                    else
                        s = loca.Person_You_16097;

                }
                return s;
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("Grammar.GetReflexivePronoun: " + ex.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
                return null;
            }

        }

        public static string? GetPossesivePronoun(Person PersonID, int Case)
        {
            try
            {
                Person person = Persons!.Find(PersonID!)!;
                string s = "";
                if (Case == Co.CASE_AKK)
                {

                    if (PersonID.ID == A!.Adventure!.CA!.Person_I!.ID)
                        s = loca.Person_I_16098;
                    else if (PersonID!.ID == A!.Adventure!.CA!.Person_You!.ID)
                        s = loca.Person_You_16099;
                    else if ((person!.Sex == Co.SEX_MALE) || (person!.Sex == Co.SEX_NEUTER))
                        s = loca.Person_You_16100;
                    else
                        s = loca.Person_You_16101;
                }
                if (Case == Co.CASE_NOM)
                {
                    if (PersonID.ID == A!.Adventure!.CA!.Person_I!.ID)
                        s = loca.Person_I_16102;
                    else if (PersonID.ID == A!.Adventure!.CA!.Person_You!.ID)
                        s = loca.Person_You_16103;
                    else if ((person!.Sex == Co.SEX_MALE) || (person!.Sex == Co.SEX_NEUTER))
                        s = loca.Person_You_16104;
                    else
                        s = loca.Person_You_16105;
                }
                else if (Case == Co.CASE_DAT)
                {
                    if (PersonID.ID == A!.Adventure!.CA!.Person_I!.ID)
                        s = loca.Person_I_16106;
                    else if (PersonID.ID == A!.Adventure!.CA!.Person_You!.ID)
                        s = loca.Person_You_16107;
                    else if ((person!.Sex == Co.SEX_MALE) || (person!.Sex == Co.SEX_NEUTER))
                        s = loca.Person_You_16108;
                    else
                        s = loca.Person_You_16109;
                }
                else if (Case == Co.CASE_GEN)
                {
                    if (PersonID.ID == A!.Adventure!.CA!.Person_I!.ID)
                        s = loca.Person_I_16110;
                    else if (PersonID.ID == A!.Adventure!.CA!.Person_You!.ID)
                        s = loca.Person_You_16111;
                    else if ((person!.Sex == Co.SEX_MALE) || (person!.Sex == Co.SEX_NEUTER))
                        s = loca.Person_You_16112;
                    else
                        s = loca.Person_You_16113;
                }
                return s;
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("Grammar.GetPossesivePronoun: " + ex.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
                return null;
            }

        }

        // public static string GetPronoun(Person PersonID);

        public static string? GetPronoun(Person PersonID)
        {
            try
            {
                Person person = Persons!.Find(PersonID)!;

                if (PersonID.ID == A!.Adventure!.CA!.Person_I!.ID) return (loca.Person_I_16114);
                if (PersonID.ID == A!.Adventure!.CA!.Person_You!.ID) return (loca.Person_You_16115);
                if (person!.Sex == Co.SEX_FEMALE) return (loca.Person_You_16116);
                if (person!.Sex == Co.SEX_MALE) return (loca.Person_You_16117);
                if (person!.Sex == Co.SEX_NEUTER) return (loca.Person_You_16118);
                if (person!.Sex == Co.SEX_FEMALE_PL) return (loca.Person_You_16119);
                if (person!.Sex == Co.SEX_MALE) return (loca.Person_You_16120);
                if (person!.Sex == Co.SEX_NEUTER) return (loca.Person_You_16121);
                return (loca.Person_You_16122);
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("Grammar.GetPronoun: " + ex.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
                return null;
            }

        }


        public static string GetVerbDeclination(int VerbID, Person? PersonID, int Tense)
        {
            try
            {
                string s = "";
                if (Persons == null) return s;

                Person? person = Persons!.Find(PersonID!)!;

                if (person == null)
                    person = Persons!.Find(A!.Adventure!.CA!.Person_I!)!;

                if (Tense == Co.CB!.Tense_Present)
                {
                    if (PersonID!.ID == A!.Adventure!.CA!.Person_I!.ID) Tense = Co.CB!.Tense_1P_Sin_Present;
                    else if (PersonID!.ID == A!.Adventure!.CA!.Person_You!.ID) Tense = Co.CB!.Tense_2P_Sin_Present;
                    else
                    {
                        Tense = Co.CB!.Tense_3P_Sin_Present;
                        if (person!.Sex == Co.SEX_FEMALE_PL || person!.Sex == Co.SEX_MALE_PL || person!.Sex == Co.SEX_NEUTER_PL)
                            Tense = Co.CB!.Tense_3P_Pl_Present;
                    }
                }
                else if (Tense == Co.CB!.Tense_Past)
                {
                    if (PersonID!.ID == A!.Adventure!.CA!.Person_I!.ID) Tense = Co.CB!.Tense_1P_Sin_Past;
                    else if (PersonID.ID == A!.Adventure!.CA!.Person_You!.ID) Tense = Co.CB!.Tense_2P_Sin_Past;
                    else
                    {
                        Tense = Co.CB!.Tense_3P_Sin_Past;
                        if (person!.Sex == Co.SEX_FEMALE_PL || person!.Sex == Co.SEX_MALE_PL || person!.Sex == Co.SEX_NEUTER_PL)
                            Tense = Co.CB!.Tense_3P_Pl_Past;
                    }
                }

                for (int i = 0; i < VT!.List.Count; i++)
                {
                    if (VT.List[i].ID == VerbID)
                    {
                        s = VT.List[i].VerbNameTense[Tense].VerbNameTense!;
                    }
                }
                return s!;
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("base_order.GetVerbDeclination: " + ex.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
                return null;
            }


        }

        public static string? GetVerbDeclinationFromItem(int VerbID, int ItemID, int Tense)
        {
            try
            {
                string s = "";
                if (Persons == null) return s;

                Item item = Items!.Find(ItemID)!;

                if (Tense == Co.CB!.Tense_Present)
                {
                    Tense = Co.CB!.Tense_3P_Sin_Present;
                    if (item!.Sex == Co.SEX_FEMALE_PL || item!.Sex == Co.SEX_MALE_PL || item!.Sex == Co.SEX_NEUTER_PL)
                        Tense = Co.CB!.Tense_3P_Pl_Present;
                }
                else if (Tense == Co.CB!.Tense_Past)
                {
                    Tense = Co.CB!.Tense_3P_Sin_Past;
                    if (item!.Sex == Co.SEX_FEMALE_PL || item!.Sex == Co.SEX_MALE_PL || item!.Sex == Co.SEX_NEUTER_PL)
                        Tense = Co.CB!.Tense_3P_Pl_Past;
                }

                for (int i = 0; i < VT!.List.Count; i++)
                {
                    if (VT.List[i].ID == VerbID)
                    {
                        s = VT!.List[i].VerbNameTense[Tense].VerbNameTense!;
                    }
                }
                return s!;
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("Grammar.GetVerbDeclinationFromItem: " + ex.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
                return null;
            }

        }

        public static string? GetVerbDeclination(int VerbID, AbstractAdvObject AO, int Tense)
        {
            try
            {
                string s = "";

                if (AO == null)
                    return s;


                if (Tense == Co.CB!.Tense_Present)
                {
                    if (AO == A!.Adventure!.CA!.Person_I!) Tense = Co.CB!.Tense_1P_Sin_Present;
                    else if (AO == A!.Adventure!.CA!.Person_You) Tense = Co.CB!.Tense_2P_Sin_Present;
                    else if (AO.Sex == Co.SEX_FEMALE_PL || AO.Sex == Co.SEX_MALE_PL || AO.Sex == Co.SEX_NEUTER_PL) Tense = Co.CB!.Tense_3P_Pl_Present;
                    else Tense = Co.CB!.Tense_3P_Sin_Present;
                }
                else if (Tense == Co.CB!.Tense_Past)
                {
                    if (AO == A!.Adventure!.CA!.Person_I!) Tense = Co.CB!.Tense_1P_Sin_Past;
                    else if (AO == A!.Adventure!.CA!.Person_You) Tense = Co.CB!.Tense_2P_Sin_Past;
                    else if (AO.Sex == Co.SEX_FEMALE_PL || AO.Sex == Co.SEX_MALE_PL || AO.Sex == Co.SEX_NEUTER_PL) Tense = Co.CB!.Tense_3P_Pl_Past;
                    else Tense = Co.CB!.Tense_3P_Sin_Past;
                }

                for (int i = 0; i < VT!.List.Count; i++)
                {
                    if (VT!.List[i].ID == VerbID)
                    {
                        s = VT.List[i].VerbNameTense[Tense].VerbNameTense!;
                    }
                }
                return s!;
            }
            catch (Exception ex)
            {
                Phoney_MAUI.Core.GlobalData.AddLog("Grammar.GetVerbDeclination: " + ex.Message, Phoney_MAUI.Model.IGlobalData.protMode.crisp);
                return null;
            }

        }

        public static void SetPersons(PersonList pPersons)
        {
            // Persons = pPersons;
        }
    }
}