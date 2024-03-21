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
            AdvGame!.StoryOutput(loca.Adv_Intro0);
            AdvGame!.StoryOutput(String.Format(loca.Adv_Intro1, GD!.Version.GetVersion(), GD!.Version.GetVersionDate()));

            AdvGame!.StoryOutput(loca.Adv_Intro2);
            AdvGame!.StoryOutput(loca.Adv_Intro3);
            AdvGame!.StoryOutput(loca.Adv_Intro4);

            AdvGame!.locations!.ShowlocationFull(A!.ActLoc);
        }


    }
}
