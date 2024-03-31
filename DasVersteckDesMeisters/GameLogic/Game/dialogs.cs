using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore
{

    public partial class Order: AbstractOrder
    {
 
        public bool SetupDialogSimpleMC(List<MCMenuEntry> MCMEntry)
        {
            if( !AdvGame!.GD!.SilentMode )
                AdvGame!.UIS!.SetSimpleMC();

            StoryIntro();
            return true;
        }

        public bool SetupDialogComplexMC(List<MCMenuEntry> MCMEntry)
        {
            if (!AdvGame!.GD!.SilentMode)
                AdvGame!.UIS!.SetComplexMC();

            StoryIntro();
            return true;
        }

        public bool SetupDialogTextInput(List<MCMenuEntry> MCMEntry)
        {
            if (!AdvGame!.GD!.SilentMode)
                AdvGame!.UIS!.SetTextInput();
            StoryIntro();

            return true;
        }


        public void SetupDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower)
        {
            // 1 
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_SetupDialog_10144", 1,CB!.MCE_Choice1, true));
            mcM.Last()!.SetSpeaker(CB!.VT_murmeln);

            cFollower.Add(99);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca( null, "Order_SetupDialog_10144a", 99, -1, false, false));

            cFollower.Add(100);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_SetupDialog_Person_Self_10145", 100, 200, false, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(101);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_SetupDialog_Person_Self_10146", 101, 210, false, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(102);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_SetupDialog_Person_Self_10147", 102, 220, false, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(103);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_SetupDialog_Person_Self_10148", 103, 230, false, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(104);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_SetupDialog_Person_Self_10149", 104, 240, false, false));

            mcM.Add(new MCMenuEntry(CB!.MCE_Choice1, cFollower));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_SetupDialog_Person_Self_10150", 230, CB!.MCE_Choice1, true));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_SetupDialog_Person_Self_10151", 240, CB!.MCE_Choice1, true));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_SetupDialog_Person_Self_10152", 200, -1, true));
            mcM.Last()!.SetDel(SetupDialogSimpleMC);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_SetupDialog_Person_Self_10153", 210, -1, true));
            mcM.Last()!.SetDel(SetupDialogComplexMC);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_SetupDialog_Person_Self_10154", 220, -1, true));
            mcM.Last()!.SetDel(SetupDialogTextInput);

            /*
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_SetupDialog_Person_Self_10155", 220, -1, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen, CA!.Adj_genervt);
            mcM.Last()!.SetDel(KlauseFail2);
            */
        }
        public void StoryIntro()
        {
            /*
            AdvGame!.StoryOutput(loca.Adv_Intro0);
            AdvGame!.StoryOutput(String.Format(loca.Adv_Intro1, GD!.Version.GetVersion(), GD!.Version.GetVersionDate()));
            */
            AdvGame!.StoryOutput(loca.Adv_Intro2);
            AdvGame!.StoryOutput(loca.Adv_Intro3);
            AdvGame!.StoryOutput(loca.Adv_Intro4);

            AdvGame!.locations!.ShowlocationFull(A!.ActLoc);
        }
        public bool KADialogCalc(List<MCMenuEntry> MCMEntry)
        {
            persistentMCMenu!.SetNewStart(11);

            if(persistentMCMenu!.FindID(104)!.Hidden != MCMenuEntry.HiddenType.hidden && CA.Status_Tuer_Schlafkammer_angeschaut.Val > 0 && CA.Status_Tuer_Schlafkammer.Val == 0 )
            {
                persistentMCMenu!.FindID(105)!.Hidden = MCMenuEntry.HiddenType.visible;

            }

            return true;
        }

        public bool KADialog_Belebung(List<MCMenuEntry> MCMEntry)
        {

            persistentMCMenu!.FindID(104)!.Hidden = MCMenuEntry.HiddenType.visible;

            KADialogCalc(MCMEntry);

            return true;
        }
        public bool KADialog_Tanzen(List<MCMenuEntry> MCMEntry)
        {
            AdvGame!.StoryOutput(loca.KnightArmour_Tanzen);


            KADialogCalc(MCMEntry);

            return true;
        }
        public bool KADialog_Tuer_Einrennen(List<MCMenuEntry> MCMEntry)
        {
            AdvGame!.SetScoreToken(CA!.Score_Tuer_eintreten);

            AdvGame!.StoryOutput(loca.KnightArmour_Tuer);

            CA.Status_Tuer_Schlafkammer.Val = 1;

            CA.I06_Door.LocaDescription = "Adv_I06_Door_Broken";
            CA.I06_Door.LocaDescriptionHandle= loca.Adv_I06_Door_Broken;

            CA.I06_Seal.LocaDescription = "Adv_I06_Seal_Broken";
            CA.I06_Seal.LocaDescriptionHandle = loca.Adv_I06_Seal_Broken;

            CA.I06_Sign.LocaDescription = "Adv_I06_Sign_Broken";
            CA.I06_Sign.LocaDescriptionHandle = loca.Adv_I06_Sign_Broken;


            KADialogCalc(MCMEntry);

            return true;
        }

        public void KnightsArmorDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower)
        {
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Start_Long", 1, 2, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Start_Long2", 2, 3, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Start_Long3", 3, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last()!.SetDel(KADialogCalc);

            // 1 
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Start_Short", 11, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last()!.SetDel(KADialogCalc);

            cFollower.Add(100);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Belebung", 100, 200, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(101);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Klaue", 101, 210, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(102);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Ruestung", 102, 220, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(103);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Owner", 103, 230, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last()!.Hidden = MCMenuEntry.HiddenType.hidden;

            cFollower.Add(104);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Tanzen", 104, 240, true, false));
            mcM.Last()!.Hidden = MCMenuEntry.HiddenType.hidden;
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(105);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Tuer_Einrennen", 105, 250, true, true));
            mcM.Last()!.Hidden = MCMenuEntry.HiddenType.hidden;
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(199);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Ende", 199, -1, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));

            // 200
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Belebung2", 200, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Belebung3", 201, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Belebung4", 202, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last()!.SetDel(KADialog_Belebung);

            // 210
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Klaue2", 210, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Klaue3", 211, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Klaue4", 212, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            // 220
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Ruestung2", 220, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Ruestung3", 221, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Ruestung4", 222, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            // 230
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Owner2", 230, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Owner3", 231, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Owner4", 232, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            // 240
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Tanzen2", 240, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Tanzen3", 241, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Tanzen4", 242, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last()!.SetDel(KADialog_Tanzen);

            // 250
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Tuer_Einrennen2", 250, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Tuer_Einrennen3", 251, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Knights_Armor, "KA_Dialog_Tuer_Einrennen4", 252, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last()!.SetDel(KADialog_Tuer_Einrennen);
        }

        public bool OwlDialogCalc(List<MCMenuEntry> MCMEntry)
        {
            persistentMCMenu!.SetNewStart(11);

            return true;
        }
        public bool OwlDialog_Quizende(List<MCMenuEntry> MCMEntry)
        {
            AdvGame!.StoryOutput(loca.Owl_Library_Door);
            AdvGame!.SetScoreToken(CA!.Score_Bibliothek_offen);
            CA.Status_Tuer_Bibliothek.Val = 1;
            persistentMCMenu!.FindID(102)!.Hidden = MCMenuEntry.HiddenType.outdated;

            return true;
        }

        public bool OwlDialog_Quizstart(List<MCMenuEntry> MCMEntry)
        {
            CA.Status_Quiz_Start.Val = 1;
            persistentMCMenu!.SetNewStart(11);
            if ( CA.Status_Antwort_Lieblingstier.Val > 0 )
            {
                persistentMCMenu!.FindID(353)!.Hidden = MCMenuEntry.HiddenType.visible;

            }
            if (CA.Status_Antwort_Ruestung.Val > 0)
            {
                persistentMCMenu!.FindID(303)!.Hidden = MCMenuEntry.HiddenType.visible;

            }
            if (CA.Status_Antwort_Unterwaesche.Val > 0)
            {
                persistentMCMenu!.FindID(253)!.Hidden = MCMenuEntry.HiddenType.visible;

            }

            return true;
        }
        public void OwlDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower)
        {
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Start_Long", 1, 2, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Start_Long2", 2, 3, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Start_Long3", 3, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);
            mcM.Last()!.SetDel(OwlDialogCalc);

            // 1 
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Start_Short", 11, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);
            mcM.Last()!.SetDel(OwlDialogCalc);

            cFollower.Add(100);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Job", 100, 200, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(101);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Klaue", 101, 210, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(102);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Bibliothek", 102, 220, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(103);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Woin5Jahren", 103, 230, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(104);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_MeisterGunnar", 104, 240, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(199);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "KA_Dialog_Ende", 199, -1, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));

            // 200
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Job2", 200, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Job3", 201, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Job4", 202, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            // 210
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Klaue2", 210, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Klaue3", 211, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Klaue4", 212, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            // 220
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Bibliothek2", 220, 2 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);
            mcM.Last()!.SetDel(OwlDialog_Quizstart);

            // 230
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Woin5Jahren2", 230, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Woin5Jahren3", 231, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Woin5Jahren4", 232, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            // 240
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_MeisterGunnar2", 240, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_MeisterGunnar3", 241, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_MeisterGunnar4", 242, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            cFollower = new List<int>();
            cFollower.Add(250);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Quiz1_1", 250, 260, true, false));

            cFollower.Add(251);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Quiz1_2", 251, 270, true, false));

            cFollower.Add(252);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Quiz1_3", 252, 280, true, false));

            cFollower.Add(253);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Quiz1_4", 253, 290, true, false));
            mcM.Last()!.Hidden = MCMenuEntry.HiddenType.hidden;

            mcM.Add(new MCMenuEntry(2 + CB!.MCE_Choice_Off, cFollower));


            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Quiz1_1_2", 260, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Quiz1_2_2", 270, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Quiz1_3_2", 280, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Quiz1_4_2", 290, 3 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            cFollower = new List<int>();
            cFollower.Add(300);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Quiz2_1", 300, 310, true, false));

            cFollower.Add(301);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Quiz2_2", 301, 320, true, false));

            cFollower.Add(302);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Quiz2_3", 302, 330, true, false));

            cFollower.Add(303);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Quiz2_4", 303, 340, true, false));
            mcM.Last()!.Hidden = MCMenuEntry.HiddenType.hidden;

            mcM.Add(new MCMenuEntry(3 + CB!.MCE_Choice_Off, cFollower));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Quiz2_1_2", 310, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Quiz2_2_2", 320, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Quiz2_3_2", 330, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Quiz2_4_2", 340, 4 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            cFollower = new List<int>();
            cFollower.Add(350);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Quiz3_1", 350, 360, true, false));

            cFollower.Add(351);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Quiz3_2", 351, 370, true, false));

            cFollower.Add(352);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Quiz3_3", 352, 380, true, false));

            cFollower.Add(353);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Owl_Dialog_Quiz3_4", 353, 390, true, false));
            mcM.Last()!.Hidden = MCMenuEntry.HiddenType.hidden;
            mcM.Add(new MCMenuEntry(4 + CB!.MCE_Choice_Off, cFollower));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Quiz3_1_2", 360, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Quiz3_2_2", 370, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Quiz3_3_2", 380, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Owl, "Owl_Dialog_Quiz3_4_2", 390, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sprechen);

            mcM.Last()!.SetDel(OwlDialog_Quizende);
        }

        public bool LibDialogCalc(List<MCMenuEntry> MCMEntry)
        {
            persistentMCMenu!.SetNewStart(11);

            return true;
        }

        public void LibrarianDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower)
        {
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Start_Long", 1, 2, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Lib_Dialog_Start_Long2", 2, 3, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Start_Long3", 3, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last()!.SetDel(LibDialogCalc);

            // 1 
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Start_Short", 11, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last()!.SetDel(LibDialogCalc);

            cFollower.Add(100);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Lib_Dialog_Belebung", 100, 200, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(101);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Lib_Dialog_Klaue", 101, 210, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(102);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Lib_Dialog_Buecher", 102, 220, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(103);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Lib_Dialog_Leihfrist", 103, 230, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(104);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Lib_Dialog_Meister", 104, 240, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(199);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Lib_Dialog_Ende", 199, -1, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));

            // 200
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Belebung2", 200, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Lib_Dialog_Belebung3", 201, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Belebung4", 202, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            // 210
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Klaue2", 210, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Lib_Dialog_Klaue3", 211, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Klaue4", 212, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            // 220
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Buecher2", 220, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Lib_Dialog_Buecher3", 221, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Buecher4", 222, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            // 230
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Leihfrist2", 230, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Lib_Dialog_Leihfrist3", 231, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Leihfrist4", 232, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            // 240
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Meister2", 240, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Lib_Dialog_Meister3", 241, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Librarian, "Lib_Dialog_Meister4", 242, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
        }
        public bool FishDialogCalc(List<MCMenuEntry> MCMEntry)
        {
            persistentMCMenu!.SetNewStart(11);

            if( CA.Status_Coin_Entdeckt.Val > 0 && CA.Status_Fish_Coin.Val == 0 && persistentMCMenu!.FindID(103).Hidden == MCMenuEntry.HiddenType.hidden )
            {

                persistentMCMenu!.FindID(103)!.Hidden = MCMenuEntry.HiddenType.visible;
                
            }
            return true;
        }
        public bool FishDialog_Coin(List<MCMenuEntry> MCMEntry)
        {
            CA.Status_Fish_Coin.Val = 1;
            return true;
        }

        public void FishDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower)
        {
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Fish, "Fish_Dialog_Start_Long", 1, 2, true));
            mcM.Last()!.SetSpeaker(CB!.VT_blubbern);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Fish_Dialog_Start_Long2", 2, 3, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Fish, "Fish_Dialog_Start_Long3", 3, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_blubbern);
            mcM.Last()!.SetDel(FishDialogCalc);

            // 1 
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Fish, "Fish_Dialog_Start_Short", 11, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_blubbern);
            mcM.Last()!.SetDel(FishDialogCalc);

            cFollower.Add(100);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Fish_Dialog_Belebung", 100, 200, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            
            cFollower.Add(101);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Fish_Dialog_Herkunft", 101, 210, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(102);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Fish_Dialog_Leben", 102, 220, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(103);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Fish_Dialog_Coin", 103, 230, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last().Hidden = MCMenuEntry.HiddenType.hidden;

            cFollower.Add(199);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Fish_Dialog_Ende", 199, -1, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));

            // 200
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Fish, "Fish_Dialog_Belebung2", 200, true));
            mcM.Last()!.SetSpeaker(CB!.VT_blubbern);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Fish_Dialog_Belebung3", 201, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Fish, "Fish_Dialog_Belebung4", 202, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_blubbern);

            // 210
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Fish, "Fish_Dialog_Herkunft2", 210, true));
            mcM.Last()!.SetSpeaker(CB!.VT_blubbern);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Fish_Dialog_Herkunft3", 211, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Fish, "Fish_Dialog_Herkunft4", 212, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_blubbern);

            // 220
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Fish, "Fish_Dialog_Leben2", 220, true));
            mcM.Last()!.SetSpeaker(CB!.VT_blubbern);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Fish_Dialog_Leben3", 221, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Fish, "Fish_Dialog_Leben4", 222, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_blubbern);

            // 230
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Fish, "Fish_Dialog_Coin2", 230, true));
            mcM.Last()!.SetSpeaker(CB!.VT_blubbern);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Fish_Dialog_Coin3", 231, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Fish, "Fish_Dialog_Coin4", 232, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_blubbern);
            mcM.Last()!.SetDel(FishDialog_Coin);
        }
        public bool MagpieDialogCalc(List<MCMenuEntry> MCMEntry)
        {
            persistentMCMenu!.SetNewStart(11);

            if( Items.IsItemInv( CA.I00_Cheese) && persistentMCMenu!.FindID(101).Hidden == MCMenuEntry.HiddenType.outdated && persistentMCMenu!.FindID(103).Hidden == MCMenuEntry.HiddenType.hidden)
            {

                persistentMCMenu!.FindID(103)!.Hidden = MCMenuEntry.HiddenType.visible;
                
            }

            return true;
        }
        public bool MagpieDialog_Swap_Intro(List<MCMenuEntry> MCMEntry)
        {
            CA.Status_Elster_Tauschintro.Val = 1;
            MagpieDialogCalc(MCMEntry);

            return true;
        }
        public bool MagpieDialog_Swap( List<MCMenuEntry> MCMEntry)
        {
            Items.TransferItem(CA.I00_Cheese.ID, CB!.LocType_In_Item, CA.I00_Nullbehaelter2.ID);
            Items.TransferItem(CA!.I00_Polished_Stone.ID, CB!.LocType_Person, CA.Person_I.ID);
            AdvGame!.SetScoreToken(CA!.Score_Polierter_Stein);
            return true;
        }

        public void MagpieDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower)
        {
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Magpie, "Magpie_Dialog_Start_Long", 1, 2, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Magpie_Dialog_Start_Long2", 2, 3, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Magpie, "Magpie_Dialog_Start_Long3", 3, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Last()!.SetDel(MagpieDialogCalc);

            // 1 
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Magpie, "Magpie_Dialog_Start_Short", 11, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last()!.SetDel(MagpieDialogCalc);

            cFollower.Add(100);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Magpie_Dialog_Belebung", 100, 200, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(101);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Magpie_Dialog_Herkunft", 101, 210, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(102);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Magpie_Dialog_Kette", 102, 220, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(103);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Magpie_Dialog_Tauschen", 103, 230, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last().Hidden = MCMenuEntry.HiddenType.hidden;

            cFollower.Add(199);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Magpie_Dialog_Ende", 199, -1, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));

            // 200
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Magpie, "Magpie_Dialog_Belebung2", 200, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Magpie_Dialog_Belebung3", 201, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Magpie, "Magpie_Dialog_Belebung4", 202, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);

            // 210
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Magpie, "Magpie_Dialog_Herkunft2", 210, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Magpie_Dialog_Herkunft3", 211, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Magpie, "Magpie_Dialog_Herkunft4", 212, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Last()!.SetDel(MagpieDialog_Swap_Intro);

            // 220
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Magpie, "Magpie_Dialog_Kette2", 220, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Magpie_Dialog_Kette3", 221, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Magpie, "Magpie_Dialog_Kette4", 222, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);

            // 230
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Magpie, "Magpie_Dialog_Tauschen2", 230, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Magpie_Dialog_Tauschen3", 231, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Magpie, "Magpie_Dialog_Tauschen4", 232, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Last()!.SetDel(MagpieDialog_Swap);
        }
        public bool ParrotDialogCalc(List<MCMenuEntry> MCMEntry)
        {
            persistentMCMenu!.SetNewStart(11);

            if( Items.IsItemInv( CA.I00_Lightless_Stone) == true && persistentMCMenu!.FindID(103).Hidden == MCMenuEntry.HiddenType.hidden )
            {
                persistentMCMenu!.FindID(103)!.Hidden = MCMenuEntry.HiddenType.visible;                
            }

            return true;
        }
        public bool ParrotDialog_Fliegen(List<MCMenuEntry> MCMEntry)
        {
            Items.TransferItem(CA.I00_Lightless_Stone.ID, CB!.LocType_Person, CA.Person_Parrot.ID);

            return true;
        }

        public void ParrotDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower)
        {
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Parrot, "Parrot_Dialog_Start_Long", 1, 2, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Parrot_Dialog_Start_Long2", 2, 3, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Parrot, "Parrot_Dialog_Start_Long3", 3, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Last()!.SetDel(ParrotDialogCalc);

            // 1 
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Parrot, "Parrot_Dialog_Start_Short", 11, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Last()!.SetDel(ParrotDialogCalc);

            cFollower.Add(100);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Parrot_Dialog_Belebung", 100, 200, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(101);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Parrot_Dialog_Herkunft", 101, 210, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(102);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Parrot_Dialog_Meister", 102, 220, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(103);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Parrot_Dialog_Fliegen", 103, 230, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last().Hidden = MCMenuEntry.HiddenType.hidden;

            cFollower.Add(199);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Parrot_Dialog_Ende", 199, -1, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));

            // 200
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Parrot, "Parrot_Dialog_Belebung2", 200, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Parrot_Dialog_Belebung3", 201, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Parrot, "Parrot_Dialog_Belebung4", 202, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);

            // 210
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Parrot, "Parrot_Dialog_Herkunft2", 210, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Parrot_Dialog_Herkunft3", 211, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Parrot, "Parrot_Dialog_Herkunft4", 212, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);

            // 220
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Parrot, "Parrot_Dialog_Meister2", 220, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Parrot_Dialog_Meister3", 221, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Parrot, "Parrot_Dialog_Meister4", 222, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);

            // 230
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Parrot, "Parrot_Dialog_Fliegen2", 230, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Parrot_Dialog_Fliegen3", 231, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Parrot, "Parrot_Dialog_Fliegen4", 232, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_kraechzen);
            mcM.Last()!.SetDel(ParrotDialog_Fliegen);
        }
        public bool SnakeDialogCalc(List<MCMenuEntry> MCMEntry)
        {
            persistentMCMenu!.SetNewStart(11);

             return true;
        }
 
        public void SnakeDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower)
        {
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Snake, "Snake_Dialog_Start_Long", 1, 2, true));
            mcM.Last()!.SetSpeaker(CB!.VT_zischen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Snake_Dialog_Start_Long2", 2, 3, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Snake, "Snake_Dialog_Start_Long3", 3, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_zischen);
            mcM.Last()!.SetDel(SnakeDialogCalc);

            // 1 
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Snake, "Snake_Dialog_Start_Short", 11, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last()!.SetDel(SnakeDialogCalc);

            cFollower.Add(100);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Snake_Dialog_Belebung", 100, 200, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(101);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Snake_Dialog_Herkunft", 101, 210, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(102);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Snake_Dialog_Meister", 102, 220, true, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(199);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Snake_Dialog_Ende", 199, -1, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));

            // 200
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Snake, "Snake_Dialog_Belebung2", 200, true));
            mcM.Last()!.SetSpeaker(CB!.VT_zischen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Snake_Dialog_Belebung3", 201, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Snake, "Snake_Dialog_Belebung4", 202, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_zischen);

            // 210
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Snake, "Snake_Dialog_Herkunft2", 210, true));
            mcM.Last()!.SetSpeaker(CB!.VT_zischen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Snake_Dialog_Herkunft3", 211, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Snake, "Snake_Dialog_Herkunft4", 212, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_zischen);

            // 220
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Snake, "Snake_Dialog_Meister2", 220, true));
            mcM.Last()!.SetSpeaker(CB!.VT_zischen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Snake_Dialog_Meister3", 221, true));
            mcM.Last()!.SetSpeaker(CB!.VT_zischen);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Snake, "Snake_Dialog_Meister4", 222, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_zischen);
        }
        public bool BookDialog_Rezept(List<MCMenuEntry> MCMEntry)
        {
            CA.Status_Rezept_Gelesen.Val = 1;

            return true;
        }
        public void BookDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower)
        {
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Book_Dialog_Start", 1, 1 + CB!.MCE_Choice_Off, true));

            cFollower.Add(100);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Book_Dialog_Gunnar", 100, 200, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(101);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Book_Dialog_Teleports", 101, 210, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(102);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Book_Dialog_Sextips", 102, 220, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(103);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Book_Dialog_Mondsteine", 103, 230, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            cFollower.Add(199);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Book_Dialog_Ende", 199, -1, true, false));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));

            // 200
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Book_Dialog_Gunnar2", 200, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            // 210
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Book_Dialog_Teleports2", 210, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
            mcM.Last()!.SetDel(BookDialog_Rezept);

            // 220
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Book_Dialog_Sextips2", 220, 1 + CB!.MCE_Choice_Off    , true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);

            // 230
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Book_Dialog_Mondsteine2", 230, 1 + CB!.MCE_Choice_Off, true));
            mcM.Last()!.SetSpeaker(CB!.VT_sagen);
        }
    }

}
