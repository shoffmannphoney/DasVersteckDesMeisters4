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
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_GoMCDialog_Person_Self_10293", 1, 1 + CB!.MCE_Choice_Off, false));
            int ix = 100;
            // int cix = 2;

            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(null, "Order_GoMCDialog_Person_Self_10294", ix, -1, false, true));
            ix += 1;

            if (A!.ActLoc <= CA!.L04_Shabby_Little_Chamber)
            {
                AddLoc(CA!.L01_Dark_Forest, mcM, Goto_L01_Dark_Forest, cFollower, ref ix);
                AddLoc(CA!.L02_In_Front_Of_A_Hut, mcM, Goto_L02_In_Front_Of_A_Hut, cFollower, ref ix);
                AddLoc(CA!.L03_In_The_Parlor, mcM, Goto_L03_In_The_Parlor, cFollower, ref ix);
                AddLoc(CA!.L04_Shabby_Little_Chamber, mcM, Goto_L04_Shabby_Little_Chamber, cFollower, ref ix);
            }
            else
            {
                AddLoc(CA!.L05_Atrium, mcM, Goto_L05_Atrium, cFollower, ref ix);
                AddLoc(CA!.L06_Long_Floor, mcM, Goto_L06_Long_Floor, cFollower, ref ix);
                AddLoc(CA!.L07_Lower_Floor, mcM, Goto_L07_Lower_Floor, cFollower, ref ix);
                AddLoc(CA!.L08_Laundry_Room, mcM, Goto_L08_Laundry_Room, cFollower, ref ix);
                AddLoc(CA!.L09_Library, mcM, Goto_L09_Library, cFollower, ref ix);
                AddLoc(CA!.L10_Laboratory, mcM, Goto_L10_Laboratory, cFollower, ref ix);
                AddLoc(CA!.L11_Storage_Room, mcM, Goto_L11_Storage_Room, cFollower, ref ix);
                AddLoc(CA!.L12_Sleeping_Room, mcM, Goto_L12_Sleeping_Room, cFollower, ref ix);
                AddLoc(CA!.L13_Kitchen, mcM, Goto_L13_Kitchen, cFollower, ref ix);
                AddLoc(CA!.L14_Bathroom, mcM, Goto_L14_Bathroom, cFollower, ref ix);

            }
            cFollower.Add(ix);
            mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, "Order_GoMCDialog_Person_Self_10295", ix, -1, true, true));
            ix += 1;


            // MC-Menü wird gesetzt
            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));
        }
        public bool Goto_L14_Bathroom(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L14_Bathroom, doRecord);

            return true;
        }
        public bool Goto_L14_Bathroom(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L14_Bathroom(MCMEntry, false);
        }
        public bool Goto_L13_Kitchen(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L13_Kitchen, doRecord);

            return true;
        }
        public bool Goto_L13_Kitchen(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L13_Kitchen(MCMEntry, false);
        }
        public bool Goto_L12_Sleeping_Room(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L12_Sleeping_Room, doRecord);

            return true;
        }
        public bool Goto_L12_Sleeping_Room(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L12_Sleeping_Room(MCMEntry, false);
        }
        public bool Goto_L11_Storage_Room(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L11_Storage_Room, doRecord);

            return true;
        }
        public bool Goto_L11_Storage_Room(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L11_Storage_Room(MCMEntry, false);
        }
        public bool Goto_L10_Laboratory(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L10_Laboratory, doRecord);

            return true;
        }
        public bool Goto_L10_Laboratory(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L10_Laboratory(MCMEntry, false);
        }
        public bool Goto_L09_Library(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L09_Library, doRecord);

            return true;
        }
        public bool Goto_L09_Library(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L09_Library(MCMEntry, false);
        }
        public bool Goto_L08_Laundry_Room(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L08_Laundry_Room, doRecord);

            return true;
        }
        public bool Goto_L08_Laundry_Room(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L08_Laundry_Room(MCMEntry, false);
        }
        public bool Goto_L07_Lower_Floor(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L07_Lower_Floor, doRecord);

            return true;
        }
        public bool Goto_L07_Lower_Floor(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L07_Lower_Floor(MCMEntry, false);
        }
        public bool Goto_L06_Long_Floor(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L06_Long_Floor, doRecord);

            return true;
        }
        public bool Goto_L06_Long_Floor(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L06_Long_Floor(MCMEntry, false);
        }
        public bool Goto_L05_Atrium(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L05_Atrium, doRecord);

            return true;
        }
        public bool Goto_L05_Atrium(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L05_Atrium(MCMEntry, false);
        }


        public bool Goto_L01_Dark_Forest(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L01_Dark_Forest, doRecord);

            return true;
        }
        public bool Goto_L01_Dark_Forest(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L01_Dark_Forest(MCMEntry, false);
        }


        public bool Goto_L02_In_Front_Of_A_Hut(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L02_In_Front_Of_A_Hut, doRecord);

            return true;
        }
        public bool Goto_L02_In_Front_Of_A_Hut(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L02_In_Front_Of_A_Hut(MCMEntry, false);
        }
        public bool Goto_L03_In_The_Parlor(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L03_In_The_Parlor, doRecord);

            return true;
        }
        public bool Goto_L03_In_The_Parlor(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L03_In_The_Parlor(MCMEntry, false);
        }
        public bool Goto_L04_Shabby_Little_Chamber(List<MCMenuEntry>? MCMEntry, bool doRecord = false)
        {

            DoRoute(CA!.L04_Shabby_Little_Chamber, doRecord);

            return true;
        }
        public bool Goto_L04_Shabby_Little_Chamber(List<MCMenuEntry>? MCMEntry)
        {
            return Goto_L04_Shabby_Little_Chamber(MCMEntry, false);
        }

        public void AddLoc( int Loc, MCMenu mcM, Phoney_MAUI.Model.DelMCMenuEntry Callback, List<int> cFollower, ref int Ix )
        {
            if (locations!.Find(Loc)!.Visited && A!.ActLoc != Loc)
            {
                cFollower.Add(Ix);
                mcM.Add(MCMenuEntry.MCMenuEntryLoca(CA!.Person_Self, locations!.Find(Loc)!.LocaLocName, Ix, -1, false, true));
                mcM.Last()!.SetDel(Callback);
                Ix++;
            }

        }

        public void DoRoute(int Dest, bool doRecord = false, bool forceBrief = true)
        {
            bool success = false;

            bool brief = AdvGame!.GD!.Brief;
            bool silent = AdvGame!.GD!.UISuppressed;

            if (forceBrief)
                AdvGame!.GD!.Brief = true;

            AdvGame!.GD!.UISuppressed = true;

            if (Persons!.Find(A!.ActPerson)!.locationID != Dest)
            {

                List<int> Route = locations!.FindRoute(Persons!.Find(A!.ActPerson), Dest);
                if (Route != null)
                {
                    for (int i = 0; i < Route.Count; i++)
                    {
                        bool oldBrief = AdvGame!.GD!.Brief;

                        if (doRecord)
                        {
                            string? recordString = null;
                            if (Route[i] == Co.DIR_N)
                                recordString = loca.Order_DoRoute_10296;
                            else if (Route[i] == Co.DIR_NE)
                                recordString = loca.Order_DoRoute_10297;
                            else if (Route[i] == Co.DIR_E)
                                recordString = loca.Order_DoRoute_10298;
                            else if (Route[i] == Co.DIR_SE)
                                recordString = loca.Order_DoRoute_10299;
                            else if (Route[i] == Co.DIR_S)
                                recordString = loca.Order_DoRoute_10300;
                            else if (Route[i] == Co.DIR_SW)
                                recordString = loca.Order_DoRoute_10301;
                            else if (Route[i] == Co.DIR_W)
                                recordString = loca.Order_DoRoute_10302;
                            else if (Route[i] == Co.DIR_NW)
                                recordString = loca.Order_DoRoute_10303;
                            else if (Route[i] == Co.DIR_U)
                                recordString = loca.Order_DoRoute_10304;
                            else if (Route[i] == Co.DIR_D)
                                recordString = loca.Order_DoRoute_10305;

                            AdvGame!.RecordOrder(recordString);
                        }
                        if (i == Route.Count - 1)
                        {
                            AdvGame!.GD!.Brief = brief;
                        }
                        success = GoDir(Persons!.Find(A!.ActPerson), Route[i]);
                        if (!success) break;

                        // if (AdvGame!.DialogOngoing == false && AdvGame!.SkipAfterDialog == false)
                        {
                            Persons!.DoNPCs();
                            locations!.Dolocations();
                        }

                        AdvGame!.GD!.Brief = oldBrief;
                    }
                }
            }

            AdvGame!.GD!.Brief = brief;

            AdvGame!.GD!.UISuppressed = silent;
            // AdvGame!.UIS!.DoUIUpdate();
        }

        public bool GoTargetlocation(int loc)
        {
            if (loc >= CA!.L05_Atrium && loc <= CA!.L14_Bathroom && A!.ActLoc >= CA!.L05_Atrium && A!.ActLoc <= CA!.L14_Bathroom)
            {
                DoRoute(loc, true);

            }
            else if (loc >= CA!.L01_Dark_Forest && loc <= CA!.L04_Shabby_Little_Chamber && A!.ActLoc >= CA!.L01_Dark_Forest && A!.ActLoc <= CA!.L04_Shabby_Little_Chamber)
            {
                DoRoute(loc, true);

            }
            else
            {
                AdvGame!.StoryOutput(loca.Order_GoTargetlocation_10306);
            }

            return true;
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
            mcM.Last()!.DefaultBreak = true;
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