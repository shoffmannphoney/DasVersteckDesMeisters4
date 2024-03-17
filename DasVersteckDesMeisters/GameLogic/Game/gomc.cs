using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameCore
{


    public partial class Order: AbstractOrder
    {

        public bool GoMC(Person PersonID, ParseTokenList PTL)
        {

            AdvGame!.StoryOutput( loca.Order_GoMC_10256);
            GenericDialog(PersonID, GoMCDialog, true, null, null);
            return true;
        }

        // Phase 1: Wir befinden uns in einer der Anfangs-location
        public void GoMCDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower)
        {
        }

        public bool GoTargetlocation(int loc)
        {
            return false;
        }
        public bool Manual(Person PersonID, ParseTokenList PTL)
        {
            GenericDialog(PersonID, ManualDialog, false, null, null, false);
            return true;
        }
         public void ManualDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower)
        {
            // bool handled = false;
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10307", 1, 1 + CB!.MCE_Choice_Off, false));
            int ix = 100;
            // int cix = 2;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10308", ix, -1, false, true));
            ix += 1;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10309", ix, 1400, false, false));
            ix += 1;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10310", ix, 1100, false, false));
            ix += 1;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10311", ix, 1200, false, false));
            ix += 1;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10312", ix, 1300, false, false));
            ix += 1;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10313", ix, CB!.MCE_Choice2, false, false));
            ix += 1;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10314", ix, -1, false, false));
            ix += 1;


            // MC-Menü wird gesetzt
            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));


            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10315", 1400, CB!.MCE_Choice1, true, false));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10316", 1100, CB!.MCE_Choice1, true, false));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10317", 1200, CB!.MCE_Choice1, true, false));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10318", 1300, CB!.MCE_Choice1, true, false));


            cFollower = new();
            ix = 200;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10319", ix, -1, false, true));
            ix += 1;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10320", ix, 2000, false, false));
            ix += 1;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10321", ix, 2100, false, false));
            ix += 1;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10322", ix, 2200, false, false));
            ix += 1;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10323", ix, 2400, false, false));
            ix += 1;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10324", ix, 2300, false, false));
            ix += 1;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_ManualDialog_Person_Self_10325", ix, CB!.MCE_Choice1, false, false));
            ix += 1;


            // MC-Menü wird gesetzt
            mcM.Add(new MCMenuEntry(2 + CB!.MCE_Choice_Off, cFollower));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10326", 2000, 2001, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10327", 2001, 2002, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10328", 2002, 2003, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10329", 2003, 2004, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10330", 2004, 2005, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10331", 2005, 2006, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10332", 2006, 2007, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10333", 2007, 2008, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10334", 2008, 2009, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10335", 2009, 2010, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10336", 2010, 2011, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10337", 2011, CB!.MCE_Choice2, true, false));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10338", 2100, 2101, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10339", 2101, 2102, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10340", 2102, 2103, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10341", 2103, 2104, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10342", 2104, CB!.MCE_Choice2, true, false));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10343", 2200, 2201, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10344", 2201, 2202, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10345", 2202, CB!.MCE_Choice2, true, false));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10346", 2300, 2301, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10347", 2301, 2302, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10348", 2302, 2303, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10349", 2303, 2304, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10350", 2304, 2305, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10351", 2305, 2306, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10352", 2306, 2307, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10353", 2307, CB!.MCE_Choice2, true, false));

            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10354", 2400, 2401, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10355", 2401, 2402, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10356", 2402, 2403, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10357", 2403, 2404, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10358", 2404, 2405, true, false));
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_ManualDialog_Person_Self_10359", 2405, CB!.MCE_Choice2, true, false));
 
        
        }
   }

}