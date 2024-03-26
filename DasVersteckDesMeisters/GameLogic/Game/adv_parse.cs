using System;
using System.Collections.Generic;
using Phoney_MAUI.Model;

namespace GameCore;


public partial class Adv : AdvBase
{


    public bool InitPLL()
    {
        GC.Collect();
        InitPLLGer();
        InitPLLEng();
        return true;
    }

    public void InitPLLGer()
    { 
        ParseTokenList PList;

        PLL = new ParseLineList();

        // Story
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Story);
        PLL.Add(new ParseLine(CB!.PL_Story, PList, Orders!.WriteStory));

        // Englisch
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_English);
        PLL.Add(new ParseLine(CB!.PL_English, PList, Orders!.English));

        // Deutsch
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_German );
        PLL.Add(new ParseLine(CB!.PL_German, PList, Orders!.German ));

        // Take
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Take, PList, Orders!.Take));

        // Take Down
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CB!.PL_TakeDown, PList, Orders!.TakeDown));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_ab);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_TakeDown, PList, Orders!.TakeDown));

        // Take MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PLL.Add(new ParseLine(CB!.PL_Take, PList, Orders!.TakeMC, false));

        // Take all
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_alles);
        PLL.Add(new ParseLine(CB!.PL_TakeAll, PList, Orders!.TakeAll));

        // Play
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Play);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Play, PList, Orders!.Play));

        // gehe nach norden
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_N);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoN));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_N);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoN));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_N);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoN));


        // gehe nach nordosten
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_NE);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoNE));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_NE);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoNE));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_NE);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoNE));

        // gehe nach osten
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_E);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoE));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_E);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoE));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_E);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoE));

        // Südosten
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_SE);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoSE));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_SE);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoSE));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_SE);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoSE));

        // Süden
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_S);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoS));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_S);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoS));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_S);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoS));

        // Südwesten
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_SW);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoSW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_SW);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoSW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_SW);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoSW));

        // Westen
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_W);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_W);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_W);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PLL.Add(new ParseLine(CB!.PL_GoMC, PList, Orders!.GoMC));

        // Nordwesten
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_NW);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoNW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_NW);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoNW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_NW);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoNW));

        // Hoch
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoU));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_U);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoU));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_U);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoU));

        // runter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_D);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoD));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_D);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoD));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_D);
        PLL.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoD));

        // gehe durch 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_durch);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Go_Through, PList, Orders!.GoThrough));

        // gehe durch 
        /*
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Go_Through2, PList, Orders!.GoThrough));
        */

        // gehe hinter 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_hinter);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Go_Behind, PList, Orders!.GoBehind));

        // gehe durch MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_durch);
        PLL.Add(new ParseLine(CB!.PL_Go_Through, PList, Orders!.GoThroughMC));

        // gehe zu
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Go_To, PList, Orders!.GoTo));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Go_To2, PList, Orders!.GoTo));

        // gehe in
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Go_In, PList, Orders!.GoIn));


        // gehe zu MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_zu);
        PLL.Add(new ParseLine(CB!.PL_Go_To2, PList, Orders!.GoToMC, false));


        // Inv
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Inventory);
        PLL.Add(new ParseLine(CB!.PL_Inventory, PList, Orders!.Inventory));

        // Examine
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddItemRange(Co.Range_Visible);
        PLL.Add(new ParseLine(CB!.PL_Examine, PList, Orders!.Examine));

        // Examine MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PLL.Add(new ParseLine(CB!.PL_Examine, PList, Orders!.ExamineMC, false));

        // U Item
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddItemRange(Co.Range_Visible);
        PLL.Add(new ParseLine(CB!.PL_Examine, PList, Orders!.Examine));

        // schaue auf
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineOn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineOn));

        // schaue auf MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_auf);
        PLL.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineOnMC, false));

        // schaue in
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Examine_In, PList, Orders!.ExamineIn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineOn));

        // schaue in MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_in);
        PLL.Add(new ParseLine(CB!.PL_Examine_In, PList, Orders!.ExamineInMC, false));

        // schaue behind
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_hinter);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Examine_Behind, PList, Orders!.ExamineBehind));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_hinter);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineOn));

        // schaue behind MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_hinter);
        PLL.Add(new ParseLine(CB!.PL_Examine_Behind, PList, Orders!.ExamineBehindMC, false));

        // schaue below
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_unter);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Examine_Below, PList, Orders!.ExamineBelow));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_unter);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineOn));

        // schaue below MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_unter);
        PLL.Add(new ParseLine(CB!.PL_Examine_Below, PList, Orders!.ExamineBelowMC, false));

        // schaue beside
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_neben);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Examine_Beside, PList, Orders!.ExamineBeside));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_neben);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineOn));

        // schaue beside MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_neben);
        PLL.Add(new ParseLine(CB!.PL_Examine_Beside, PList, Orders!.ExamineBesideMC, false));

        // Schaue durch
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_durch);
        PList.AddItemRange(Co.Range_Visible);
        PLL.Add(new ParseLine(CB!.PL_Examine_Through, PList, Orders!.ExamineThrough));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_durch);
        PList.AddItemRange(Co.Range_Visible);
        PLL.Add(new ParseLine(CB!.PL_Examine_Through, PList, Orders!.ExamineThrough));

        // Schaue aus
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_aus);
        PList.AddItemRange(Co.Range_Visible);
        PLL.Add(new ParseLine(CB!.PL_Examine_Out, PList, Orders!.ExamineOut));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_aus);
        PList.AddItemRange(Co.Range_Visible);
        PLL.Add(new ParseLine(CB!.PL_Examine_Out, PList, Orders!.ExamineOut));

        // Examine Topic
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddTopic();
        PLL.Add(new ParseLine(CB!.PL_Examine_T, PList, Orders!.ExamineT));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddTopic();
        PLL.Add(new ParseLine(CB!.PL_Examine_T, PList, Orders!.ExamineT));


        // location
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_location);
        PLL.Add(new ParseLine(CB!.PL_location, PList, Orders!.location));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddVerb(CB!.Verb_location);
        PLL.Add(new ParseLine(CB!.PL_location, PList, Orders!.location));

        // Drop
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Drop);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Drop, PList, Orders!.Drop));

        // Drop MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CB!.PL_Drop, PList, Orders!.DropMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CB!.PL_Drop, PList, Orders!.Drop));

        // Hinlegen
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_hin);
        PLL.Add(new ParseLine(CB!.PL_Lay_Down, PList, Orders!.LayDown));

        // Öffne
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Open);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Open, PList, Orders!.Open));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PLL.Add(new ParseLine(CB!.PL_Open, PList, Orders!.OpenUp));

        // Öffne MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Open);
        PLL.Add(new ParseLine(CB!.PL_Open, PList, Orders!.OpenMC, false));

        // schließe
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Close, PList, Orders!.Close));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_zu);
        PLL.Add(new ParseLine(CB!.PL_Close, PList, Orders!.Close));


        // schließe MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PLL.Add(new ParseLine(CB!.PL_Close, PList, Orders!.CloseMC, false));

        // Unlock
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Open);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Unlock_W, PList, Orders!.UnlockW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PLL.Add(new ParseLine(CB!.PL_Unlock_W, PList, Orders!.UnlockW));

        // Unlock MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Open);
        PList.AddPrep(CB!.Prep_mit);
        PLL.Add(new ParseLine(CB!.PL_Unlock_W, PList, Orders!.UnlockWMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddPrep(CB!.Prep_mit);
        PList.AddPrep(CB!.Prep_auf);
        PLL.Add(new ParseLine(CB!.PL_Unlock_W, PList, Orders!.UnlockWMC, false));

        // Lock
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Lock_W);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Lock_W1, PList, Orders!.LockW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Lock_W1, PList, Orders!.LockW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_zu);
        PLL.Add(new ParseLine(CB!.PL_Lock_W2, PList, Orders!.LockW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CB!.PL_Lock_W3, PList, Orders!.LockW));

        // Lock MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Lock_W);
        PList.AddPrep(CB!.Prep_mit);
        PLL.Add(new ParseLine(CB!.PL_Lock_WMC, PList, Orders!.LockWMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddPrep(CB!.Prep_mit);
        PList.AddPrep(CB!.Prep_zu);
        PLL.Add(new ParseLine(CB!.PL_Lock_WMC, PList, Orders!.LockWMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddPrep(CB!.Prep_mit);
        PLL.Add(new ParseLine(CB!.PL_Lock_WMC, PList, Orders!.LockWMC, false));

        // Lege auf xx
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_PlaceSoloOn, PList, Orders!.PlaceSoloOn));

        // Lege in
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceIn));

        // Lege in MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_in);
        PLL.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceInMC, false));

        // Lege auf
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Place_On, PList, Orders!.PlaceOn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CB!.PL_Place_On, PList, Orders!.PlaceOn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CB!.PL_Place_On, PList, Orders!.PlaceOn));

        // Lege auf MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_auf);
        PLL.Add(new ParseLine(CB!.PL_Place_On, PList, Orders!.PlaceOnMC, false));

        // Lege hinter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_hinter);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Place_Behind, PList, Orders!.PlaceBehind));

        // Lege hinter MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_hinter);
        PLL.Add(new ParseLine(CB!.PL_Place_Behind, PList, Orders!.PlaceBehindMC, false));

        // Lege unter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_unter);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Place_Under, PList, Orders!.PlaceUnder));

        // Lege unter MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_unter);
        PLL.Add(new ParseLine(CB!.PL_Place_Under, PList, Orders!.PlaceUnderMC, false));

        // Lege neben
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_neben);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Place_Beside, PList, Orders!.PlaceBeside));

        // Lege neben MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_neben);
        PLL.Add(new ParseLine(CB!.PL_Place_Beside, PList, Orders!.PlaceBesideMC, false));

        // Nimm aus
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_aus);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Take_Out, PList, Orders!.TakeOut));

        // Nimm aus MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_aus);
        PLL.Add(new ParseLine(CB!.PL_Take_Out, PList, Orders!.TakeOutMC, false));

        // Nimm von 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_von);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Take_From, PList, Orders!.TakeFrom));

        // Nimm von MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_von);
        PLL.Add(new ParseLine(CB!.PL_Take_From, PList, Orders!.TakeFromMC, false));

        // Nimm hinter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_hinter);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Take_From_Behind, PList, Orders!.TakeBehind));

        // Nimm hinter MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_hinter);
        PLL.Add(new ParseLine(CB!.PL_Take_From_Behind, PList, Orders!.TakeBehindMC, false));

        // Nimm unter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_unter);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Take_From_Under, PList, Orders!.TakeUnder));

        // Nimm unter MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_unter);
        PLL.Add(new ParseLine(CB!.PL_Take_From_Under, PList, Orders!.TakeUnderMC, false));

        // Nimm neben
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_neben);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Place_Beside, PList, Orders!.TakeBeside));

        // Nimm neben MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_neben);
        PLL.Add(new ParseLine(CB!.PL_Place_Beside, PList, Orders!.TakeBesideMC, false));

        // Speichern
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot1);
        PLL.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot2);
        PLL.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot3);
        PLL.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot4);
        PLL.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot5);
        PLL.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot6);
        PLL.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot7);
        PLL.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot8);
        PLL.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot9);
        PLL.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot10);
        PLL.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PLL.Add(new ParseLine(CB!.PL_Save_MC, PList, Orders!.SaveMC, false));

        // Laden
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot1);
        PLL.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot2);
        PLL.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot3);
        PLL.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot4);
        PLL.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot5);
        PLL.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot6);
        PLL.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot7);
        PLL.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot8);
        PLL.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot9);
        PLL.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot10);
        PLL.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PLL.Add(new ParseLine(CB!.PL_Load_MC, PList, Orders!.LoadMC, false));

        // Lokale Befehle, also solche, die keine base-Implementierung haben

        // Benutzen
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Use);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Use, PList, Orders!.Use));

        // Benutzen MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Use);
        PLL.Add(new ParseLine(CA!.PL_Use, PList, Orders!.UseMC, false));

        // Benutzen mit
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Use);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Use_W, PList, Orders!.UseW));

        // Benutzen mit MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Use);
        PList.AddPrep(CB!.Prep_mit);
        PLL.Add(new ParseLine(CA!.PL_Use_W, PList, Orders!.UseWMC, false));

        // Benutzen mit Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Use);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Use_W_P, PList, Orders!.UseWP));

        // Schraube los
        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schraube!.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Unscrew_W, PList, Orders!.UnscrewW));


        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schraube.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_los);
        PLL.Add(new ParseLine(CA!.PL_Unscrew_W2, PList, Orders!.UnscrewW));

        // kappen/truncate
        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Basecap!.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Truncate_W, PList, Orders!.TruncateW));

        // Spanne ein in 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mount);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Mount, PList, Orders!.MountW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mount);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ein);
        PLL.Add(new ParseLine(CA!.PL_Mount, PList, Orders!.MountW));

        // Spanne 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mount);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Mount, PList, Orders!.Mount));

        // Säge mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Saw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Saw, PList, Orders!.Saw));

        // Säge
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Saw);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Saw2, PList, Orders!.SawSolo));


        // Words
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Words);
        PLL.Add(new ParseLine(CB!.PL_Words, PList, Orders!.Words));

        // Verbs
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Verbs);
        PLL.Add(new ParseLine(CB!.PL_Verbs, PList, Orders!.Verblist));

        // Protokoll an
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_ProtOn);
        PLL.Add(new ParseLine(CB!.PL_Prot_On, PList, Orders!.ProtOn));

        // Protokoll aus
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_ProtOff);
        PLL.Add(new ParseLine(CB!.PL_Prot_Off, PList, Orders!.ProtOff));

        // Wirf nach
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.Throw));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.Throw));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.Throw));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder!.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.Throw));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder!.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.Throw));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.Throw));

        // Wirf nach
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowPnach));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowPnach));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowPnach));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder!.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowPnach));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder!.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowPnach));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowPnach));

        // Wirf nach MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddPrep(CB!.Prep_nach);
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_weg);
        PLL.Add(new ParseLine(CB!.PL_Drop2, PList, Orders!.Drop));


        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder.ID);
        PList.AddPrep(CB!.Prep_nach);
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowMC, false));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder.ID);
        PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowMC, false));

        // Throw out of
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_aus);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw_Out, PList, Orders!.ThrowOut));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_aus);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw_Out, PList, Orders!.ThrowOut));

        // Throw in 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw_In, PList, Orders!.ThrowIn));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw_In, PList, Orders!.ThrowIn));

        // Wirf solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw_Solo, PList, Orders!.ThrowSolo));

        // Wirf nach Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Throw_Person, PList, Orders!.ThrowP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Throw_Person, PList, Orders!.ThrowP));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder.ID);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Throw_Solo, PList, Orders!.ThrowSolo));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Throw_Person, PList, Orders!.ThrowP));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Throw_Person, PList, Orders!.ThrowP));

        // Ziehen an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Draw, PList, Orders!.Draw));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Draw, PList, Orders!.Draw));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_zurueck);
        PLL.Add(new ParseLine(CA!.PL_Draw, PList, Orders!.Draw));

        // Ziehe heraus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_heraus);
        PLL.Add(new ParseLine(CA!.PL_DrawOut, PList, Orders!.DrawOut));

        // Ziehe ab
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CA!.PL_DrawOff, PList, Orders!.DrawOff));

        // Ziehen an MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CA!.PL_Draw, PList, Orders!.DrawMC, false));

        // Ziehe Item an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CA!.PL_Dress, PList, Orders!.Dress));

        // Ziehe Item auf
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PLL.Add(new ParseLine(CA!.PL_Dress, PList, Orders!.Dress));

        // Ziehe Item zu
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_zu);
        PLL.Add(new ParseLine(CA!.PL_DrawShut, PList, Orders!.DrawShut));

        // Ziehe Item aus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_aus);
        PLL.Add(new ParseLine(CA!.PL_Undress, PList, Orders!.Undress));

        // Ziehe Item mit Item heraus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_heraus);
        PLL.Add(new ParseLine(CA!.PL_DrawWith, PList, Orders!.DrawWith));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_DrawWith, PList, Orders!.DrawWith));

        // Ziehen runter
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_runter);
        PLL.Add(new ParseLine(CA!.PL_Draw_Down, PList, Orders!.DrawDown));

        // Schiebe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Push);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Push, PList, Orders!.Push));

        // Schiebe MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Push);
        PLL.Add(new ParseLine(CA!.PL_Push, PList, Orders!.PushMC, false));

        // Schiebe Zu
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Push);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Push_To, PList, Orders!.PushTo));

        // Schiebe hoch
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Push);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_hoch);
        PLL.Add(new ParseLine(CA!.PL_Push_Up, PList, Orders!.PushUp));

        // Schiebe Zu MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Push);
        PList.AddPrep(CB!.Prep_zu);
        PLL.Add(new ParseLine(CA!.PL_Push_To, PList, Orders!.PushToMC, false));

        // Hilfe
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Help);
        PLL.Add(new ParseLine(CB!.PL_Help, PList, Orders!.InfoMC));

        // Hilfe
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Help);
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Help_For, PList, Orders!.HelpFor));

        // Hilfe
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Help);
        PList.AddPrep(CB!.Prep_zu);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Help_For_P, PList, Orders!.HelpForP));

        // Hilfe
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Help);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Help_For2, PList, Orders!.HelpFor));

        // Hilfe
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Help);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Help_For_P2, PList, Orders!.HelpForP));

        // Info
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Info);
        PLL.Add(new ParseLine(CB!.PL_Info, PList, Orders!.GameInfo));

        // Info
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Info);
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Info_For, PList, Orders!.InfoFor));

        // Info
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Info);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Info_For2, PList, Orders!.InfoFor));

        // Info
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Info);
        PList.AddPrep(CB!.Prep_zu);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Info_For_P, PList, Orders!.InfoForP));

        // Info
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Help);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Info_For_P2, PList, Orders!.InfoForP));

        // Clue
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Clue);
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Clue_For, PList, Orders!.ClueFor));

        // Clue
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Clue);
        PList.AddPrep(CB!.Prep_zu);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Clue_For_P, PList, Orders!.ClueForP));

        // Clue
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Clue);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Clue_For2, PList, Orders!.ClueFor));

        // Clue
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Clue);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Clue_For_P2, PList, Orders!.ClueForP));

        // Solution
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Solution);
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Solution_For, PList, Orders!.SolutionFor));

        // Solution
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Solution);
        PList.AddPrep(CB!.Prep_zu);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Solution_For_P, PList, Orders!.SolutionForP));

        // Solution
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Solution);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Solution_For2, PList, Orders!.SolutionFor));

        // Solution
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Solution);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Solution_For_P2, PList, Orders!.SolutionForP));

        // Take Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Take_P, PList, Orders!.TakeP));

        // Examine Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPersonRange(Co.Range_Visible);
        PLL.Add(new ParseLine(CB!.PL_Examine_P, PList, Orders!.ExamineP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPersonRange(Co.Range_Visible);
        PLL.Add(new ParseLine(CB!.PL_Examine_P, PList, Orders!.ExamineP));

        // Open Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Open);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Open_P, PList, Orders!.OpenP));

        // Close Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Close_P, PList, Orders!.CloseP));

        // Unlock Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Open);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Unlock_W_P, PList, Orders!.UnlockWP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PLL.Add(new ParseLine(CA!.PL_Unlock_W_P, PList, Orders!.UnlockWP));

        // Lock Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Lock_W);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Lock_W_P, PList, Orders!.LockWP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_zu);
        PLL.Add(new ParseLine(CB!.PL_Lock_W_P, PList, Orders!.LockWP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Lock_W_P, PList, Orders!.LockWP));

        // Lege in Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Place_In_P, PList, Orders!.PlaceInP));

        // Lege Person in 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Place_P_In, PList, Orders!.PlacePIn));

        // Lege - solo
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Place_Solo, PList, Orders!.PlaceSolo));

        // Give to Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Give_To_P, PList, Orders!.GiveToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddItem();
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Give_To_P, PList, Orders!.GiveToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddPerson();
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Give_To_P2, PList, Orders!.GiveToP2));


        // Give to Person MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CA!.PL_Give_To_P, PList, Orders!.GiveToPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PLL.Add(new ParseLine(CA!.PL_Give_To_P, PList, Orders!.GiveToPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Give_Solo, PList, Orders!.GiveSolo, false));

        // Give to Item
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Give_To_I, PList, Orders!.GiveToI));

        // Show to Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Show);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Show_To_P, PList, Orders!.ShowToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Show);
        PList.AddItem();
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Show_To_P, PList, Orders!.ShowToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Show);
        PList.AddPerson();
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Show_To_P2, PList, Orders!.ShowToP2));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Show);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Show_Solo, PList, Orders!.ShowSolo, false));

        // Plea from Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Plea);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_von);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Plea_From_P, PList, Orders!.PleaFromP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Plea);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Plea_Solo, PList, Orders!.PleaSolo));

        // Plea from Person MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Plea);
        PList.AddPrep(CB!.Prep_von);
        PLL.Add(new ParseLine(CA!.PL_Plea_From_P, PList, Orders!.PleaFromPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Plea);
        PLL.Add(new ParseLine(CA!.PL_Plea_From_P, PList, Orders!.PleaFromPMC, false));

        // Demand from Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Demand);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_von);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Demand_From_P, PList, Orders!.DemandFromP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Demand);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Demand_Solo, PList, Orders!.DemandSolo));

        // Demand from Person MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Demand);
        PList.AddPrep(CB!.Prep_von);
        PLL.Add(new ParseLine(CA!.PL_Demand_From_P, PList, Orders!.DemandFromPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Demand);
        PLL.Add(new ParseLine(CA!.PL_Demand_From_P, PList, Orders!.DemandFromPMC, false));

        // Say to Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_zu);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Say_To_P, PList, Orders!.SayToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_mit);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Say_To_P, PList, Orders!.SayToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Say_To_P2, PList, Orders!.SayToP));

        // Say to Person MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_zu);
        PLL.Add(new ParseLine(CA!.PL_Say_To_P, PList, Orders!.SayToPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_mit);
        PLL.Add(new ParseLine(CA!.PL_Say_To_P, PList, Orders!.SayToPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PLL.Add(new ParseLine(CA!.PL_Say_To_P, PList, Orders!.SayToPMC, false));

        // Say to Item
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Say_To_I, PList, Orders!.SayToI));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Say_To_I, PList, Orders!.SayToI));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Say_To_I2, PList, Orders!.SayToI));


        // Fragen nach Item
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Ask);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Ask, PList, Orders!.Ask));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Ask);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_AskSolo, PList, Orders!.AskSolo));

        // Fragen nach Item MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Ask);
        PList.AddPrep(CB!.Prep_nach);
        PLL.Add(new ParseLine(CB!.PL_Ask, PList, Orders!.AskMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Ask);
        PLL.Add(new ParseLine(CB!.PL_Ask, PList, Orders!.AskMC, false));

        // Fragen nach Topic
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Ask);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddTopicRange(Co.Range_Known);
        PLL.Add(new ParseLine(CB!.PL_Ask_Topic, PList, Orders!.AskTopic));

        // Fragen nach Person
        /* Problematisch: Zu viele Charaktere heißen gleich. Und das kann der Parser nicht händlen. 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Ask);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddPersonRange(Co.Range_Known);
        PLL.Add(new ParseLine(CB!.PL_Ask_Person, PList, Orders!.AskPerson));
        */

        // lies
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Read);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Read, PList, Orders!.Read));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Read);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Read, PList, Orders!.ReadW));

        // lies MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Read);
        PLL.Add(new ParseLine(CA!.PL_Read, PList, Orders!.ReadMC, false));

        // Betrete Item
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Enter);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Enter, PList, Orders!.Enter));

        // Betrete Item MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Enter);
        PLL.Add(new ParseLine(CB!.PL_Enter, PList, Orders!.EnterMC, false));

        // Klettere Item
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Climb, PList, Orders!.Climb));

        // Klettere <>
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PLL.Add(new ParseLine(CB!.PL_ClimbMC, PList, Orders!.ClimbMC, false));

        // Klettere Item hoch
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_hoch);
        PLL.Add(new ParseLine(CA!.PL_ClimbUp, PList, Orders!.ClimbUp));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddItem();
        PList.AddVerb(CB!.Verb_U);
        PLL.Add(new ParseLine(CA!.PL_ClimbUp, PList, Orders!.ClimbUp));

        // Klettere durch Item 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_durch);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_ClimbThrough, PList, Orders!.ClimbThrough));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_aus);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_ClimbThrough, PList, Orders!.ClimbOut));

        // Klettere in Item 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_ClimbIn, PList, Orders!.ClimbIn));

        // Klettere Item hoch MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_hoch);
        PLL.Add(new ParseLine(CA!.PL_ClimbUpMC, PList, Orders!.ClimbUpMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddVerb(CB!.Verb_U);
        PLL.Add(new ParseLine(CA!.PL_ClimbUpMC, PList, Orders!.ClimbUpMC, false));

        // Klettere auf
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_ClimbOn, PList, Orders!.ClimbOn));


        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_ClimbOn, PList, Orders!.ClimbOn));

        // riechen
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Smell, PList, Orders!.Smell));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Smell2, PList, Orders!.Smell));

        // rieche MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CB!.PL_Smell, PList, Orders!.SmellMC, false));

        // rieche Solo
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PLL.Add(new ParseLine(CB!.PL_SmellSolo, PList, Orders!.SmellSolo));

        // riechen Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Smell_P, PList, Orders!.SmellP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PList.AddPrep(CB!.Prep_an);
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_Smell2_P, PList, Orders!.SmellP));

        // schmecke
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Taste);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Taste, PList, Orders!.Taste));

        // schmecke MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Taste);
        PLL.Add(new ParseLine(CB!.PL_Taste, PList, Orders!.TasteMC, false));

        // Klettere Item runter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_runter);
        PLL.Add(new ParseLine(CA!.PL_ClimbDown, PList, Orders!.ClimbDown));

        // Klettere Item runter MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddVerb(CB!.Verb_D);
        PLL.Add(new ParseLine(CA!.PL_ClimbDown2, PList, Orders!.ClimbDownMC, false));

        // Klettere Item runter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddItem();
        PList.AddVerb(CB!.Verb_D);
        PLL.Add(new ParseLine(CA!.PL_ClimbDown, PList, Orders!.ClimbDown));

        // Klettere Item runter MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_runter);
        PLL.Add(new ParseLine(CA!.PL_ClimbDown2, PList, Orders!.ClimbDownMC, false));


        // Warten
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Wait);
        PLL.Add(new ParseLine(CB!.PL_Wait, PList, Orders!.Wait));

        // Warten auf
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Wait);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddPersonRange(Co.Range_Active);
        PLL.Add(new ParseLine(CB!.PL_Wait2, PList, Orders!.WaitFor));

        // Quit
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Quit);
        PLL.Add(new ParseLine(CB!.PL_Quit, PList, Orders!.Quit, false));

        // Restart
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Restart);
        PLL.Add(new ParseLine(CB!.PL_Restart, PList, Orders!.Restart, false));

        // Restart Restart
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Restart);
        PList.AddVerb(CB!.Verb_Restart);
        PLL.Add(new ParseLine(CB!.PL_Restart2, PList, Orders!.RestartNoAsk, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Restart);
        PList.AddVerb(CB!.Verb_Restart);
        PList.AddVerb(CB!.Verb_German);
        PLL.Add(new ParseLine(CB!.PL_Restart3, PList, Orders!.RestartNoAskGerman, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Restart);
        PList.AddVerb(CB!.Verb_Restart);
        PList.AddVerb(CB!.Verb_English);
        PLL.Add(new ParseLine(CB!.PL_Restart4, PList, Orders!.RestartNoAskEnglish, false));

        // lösen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Untighten);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Untighten, PList, Orders!.Untighten));

        // lösen MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Untighten);
        PLL.Add(new ParseLine(CA!.PL_Untighten, PList, Orders!.UntightenMC, false));

        // lösen mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Untighten);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Untighten, PList, Orders!.UntightenW));

        // brechen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Break);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Break, PList, Orders!.Break));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Break);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CA!.PL_Break, PList, Orders!.Break));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Break);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_heraus );
        PLL.Add(new ParseLine(CA!.PL_Break, PList, Orders!.Break));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Break);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PLL.Add(new ParseLine(CA!.PL_Break_Down, PList, Orders!.BreakDown));

        // brechen MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Break);
        PLL.Add(new ParseLine(CA!.PL_Break, PList, Orders!.BreakMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Break);
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CA!.PL_Break, PList, Orders!.BreakMC, false));

        // schneiden 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Cut);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CA!.PL_Cut, PList, Orders!.Cut));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Cut);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Cut, PList, Orders!.Cut));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Cut);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Cut_Solo, PList, Orders!.CutSolo));

        // schneiden MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Cut);
        PList.AddPrep(CB!.Prep_mit);
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CA!.PL_Cut, PList, Orders!.CutMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Cut);
        PList.AddPrep(CB!.Prep_mit);
        PLL.Add(new ParseLine(CA!.PL_Cut, PList, Orders!.CutMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Cut);
        PLL.Add(new ParseLine(CA!.PL_Cut, PList, Orders!.CutMC, false));

        // verknoten
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bind);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        // verknoten Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tie_P, PList, Orders!.TieP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bind);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tie_P, PList, Orders!.TieP));

        // verknoten
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Kette!.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Tie_P2, PList, Orders!.TieP));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Kette!.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tie_P2, PList, Orders!.TieP));

        // verknoten
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_TieSolo, PList, Orders!.TieSolo));

        // verknoten MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddPrep(CB!.Prep_mit);
        PLL.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.TieMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.TieMC, false));


        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Kette.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Kette.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        // verknoten Person
        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Kette.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tie_P, PList, Orders!.TieP));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Kette.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tie_P, PList, Orders!.TieP));

        /*
        // verknoten
        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Kette.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));
        */

        // verknoten
        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Kette.ID);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_TieSolo, PList, Orders!.TieSolo));

        // verknoten MC
        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Kette.ID);
        PList.AddPrep(CB!.Prep_mit);
        PLL.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.TieMC, false));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Kette.ID);
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.TieMC, false));


        // angeln
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fish);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Fish, PList, Orders!.Fish));

        // angeln mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fish);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Fish, PList, Orders!.FishWith));

        // angeln mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fish);
        PList.AddPrep(CB!.Prep_mit);
        PLL.Add(new ParseLine(CA!.PL_Fish, PList, Orders!.FishWithMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fish);
        PLL.Add(new ParseLine(CA!.PL_Fish, PList, Orders!.FishWithMC, false));

        // Streue
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spread);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_EnlightW, PList, Orders!.SpreadOn));

        // Beleuchte
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Enlight);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_EnlightW, PList, Orders!.EnlightenW));

        // entzünde
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Light);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_LightW, PList, Orders!.LightW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Light);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CA!.PL_LightW, PList, Orders!.LightW));

        // entzünde
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Light);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Light, PList, Orders!.Light));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Light);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CA!.PL_Light, PList, Orders!.Light));

        // entzünde MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Light);
        PLL.Add(new ParseLine(CA!.PL_Light, PList, Orders!.LightMC, false));


        // löschen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Extinguish);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Extinguish, PList, Orders!.Extinguish));

        // löschen MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Extinguish);
        PLL.Add(new ParseLine(CA!.PL_Extinguish, PList, Orders!.ExtinguishMC, false));

        // greifen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Grab);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Grab, PList, Orders!.Grab));

        // greifen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Grab);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_GrabSolo, PList, Orders!.GrabSolo));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Grab, PList, Orders!.Grab));

        // greifen MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Grab);
        PList.AddPrep(CB!.Prep_mit);
        PLL.Add(new ParseLine(CA!.PL_Grab, PList, Orders!.GrabMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_mit);
        PLL.Add(new ParseLine(CA!.PL_Grab, PList, Orders!.GrabMC, false));


        // esse
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Eat);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Eat, PList, Orders!.Eat));

        // esse MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Eat);
        PLL.Add(new ParseLine(CA!.PL_Eat, PList, Orders!.EatMC, false));

        // esse Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Eat);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Eat_P, PList, Orders!.EatP));


        // verkaufen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sell);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Sell, PList, Orders!.Sell));

        // verkaufen an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sell);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_SellTo, PList, Orders!.SellTo));

        // verkaufen an MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sell);
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CA!.PL_SellTo, PList, Orders!.SellToMC));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sell);
        PLL.Add(new ParseLine(CA!.PL_SellTo, PList, Orders!.SellToMC, false));

        // pflücken
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pick);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Pick, PList, Orders!.Pick));

        // pflücken MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pick);
        PLL.Add(new ParseLine(CA!.PL_Pick, PList, Orders!.PickMC, false));


        // pflücken in 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pick);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Pick_W, PList, Orders!.PickW));

        // pflücken in MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pick);
        PList.AddPrep(CB!.Prep_in);
        PLL.Add(new ParseLine(CA!.PL_Pick_W, PList, Orders!.PickWMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pick);
        PLL.Add(new ParseLine(CA!.PL_Pick_W, PList, Orders!.PickWMC, false));

        // fange
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Catch);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_CatchP, PList, Orders!.CatchP));

        // füllen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fill);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Fill, PList, Orders!.FillW));

        // füllen in
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fill);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Fill2, PList, Orders!.FillIn));

        // füllen 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fill);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Fill_Solo, PList, Orders!.FillSolo));

        // füllen MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fill);
        PList.AddPrep(CB!.Prep_mit);
        PLL.Add(new ParseLine(CA!.PL_Fill, PList, Orders!.FillWMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fill);
        PLL.Add(new ParseLine(CA!.PL_Fill, PList, Orders!.FillWMC, false));

        // stopfe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Stuff);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Stuff, PList, Orders!.StuffIn));

        // trinken
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Drink);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Drink, PList, Orders!.Drink));

        // trinke MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Drink);
        PLL.Add(new ParseLine(CA!.PL_Drink, PList, Orders!.DrinkMC, false));

        // trinken aus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Drink);
        PList.AddPrep(CB!.Prep_aus);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_DrinkFrom, PList, Orders!.DrinkFrom));

        // berühre
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Touch);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Touch, PList, Orders!.Touch));

        // berühre MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Touch);
        PLL.Add(new ParseLine(CA!.PL_Touch, PList, Orders!.TouchMC, false));

        // berühre Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Touch);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Touch, PList, Orders!.TouchP));


        // berühre Person mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Touch);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit );
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Touch, PList, Orders!.TouchPW));

        // Klopfe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Knock);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Knock, PList, Orders!.KnockOn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Knock);
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Knock2, PList, Orders!.KnockOn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Knock);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Knock2, PList, Orders!.KnockOn));

        // Klopfe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Knock);
        PLL.Add(new ParseLine(CA!.PL_Knock_Solo, PList, Orders!.KnockSolo));

        // spucke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spit);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Spit, PList, Orders!.SpitOn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Spit, PList, Orders!.SpitOn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CA!.PL_Spit, PList, Orders!.SpitOn));

        // spucke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spit);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_SpitP, PList, Orders!.SpitOnP));

        // spucke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spit);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_SpitP, PList, Orders!.SpitOnP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spit);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CA!.PL_SpitP, PList, Orders!.SpitOnP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spit);
        PList.AddVerb(CB!.Verb_D);
        PLL.Add(new ParseLine(CA!.PL_SpitDown, PList, Orders!.SpitDown));

        // lausche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Listen);
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Listen, PList, Orders!.ListenOn));

        // lauschen allgemein
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Listen);
        PLL.Add(new ParseLine(CA!.PL_Listen_Solo, PList, Orders!.Listen));

        // lauschen Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Listen);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Listen_Person, PList, Orders!.ListenToP));

        // lauschen Topic
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Listen);
        PList.AddTopic();
        PLL.Add(new ParseLine(CA!.PL_Listen_Topic, PList, Orders!.ListenToT));

        // verbinde 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_AttachTo, PList, Orders!.AttachTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_AttachTo, PList, Orders!.AttachTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_AttachTo, PList, Orders!.AttachTo));

        // verbinde 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_AttachSolo, PList, Orders!.AttachSolo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hang);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_HangTo, PList, Orders!.HangTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hang);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_HangSolo, PList, Orders!.HangSolo));

        // lausche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Listen);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Listen, PList, Orders!.ListenOn));


        // MC Item
        PList = new ParseTokenList();
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_MC_Item, PList, Orders!.MCItem, false));

        // MC Person
        PList = new ParseTokenList();
        PList.AddPerson();
        PLL.Add(new ParseLine(CB!.PL_MC_Person, PList, Orders!.MCPerson, false));

        // tunke 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Dip, PList, Orders!.Dip));

        // kippe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tip_Solo, PList, Orders!.TipSolo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_aus);
        PLL.Add(new ParseLine(CA!.PL_Tip_Solo, PList, Orders!.TipSolo));

        // kippe auf
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tip, PList, Orders!.Tip));

        // kippe in
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tip_In, PList, Orders!.TipIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ueber);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tip_In, PList, Orders!.TipIn));

        // kippe auf Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Tip, PList, Orders!.TipP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ueber);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Tip, PList, Orders!.TipP));

        // gieße
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Water);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Pour, PList, Orders!.Water));

        // gieße mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Water);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Pour2, PList, Orders!.WaterW));

        // gieße in
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Water);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Pour2, PList, Orders!.WaterWIn));

        // verhafte
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Arrest);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Arrest, PList, Orders!.Arrest));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_fest);
        PLL.Add(new ParseLine(CA!.PL_Arrest, PList, Orders!.Arrest));

        // verhafte mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Arrest);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_ArrestW, PList, Orders!.ArrestW));

        // meditiere
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Meditate);
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Meditate, PList, Orders!.Meditate));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Meditate);
        PList.AddPrep(CB!.Prep_ueber);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Meditate, PList, Orders!.Meditate));

        // meditiere
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Meditate);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Meditate, PList, Orders!.Meditate));

        // meditiere solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Meditate);
        PLL.Add(new ParseLine(CA!.PL_Meditate_Solo, PList, Orders!.MeditateSolo));

        // drücke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Press);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Press, PList, Orders!.Press));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Press);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Press, PList, Orders!.Press));

        // drücke in 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Press);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Press_In, PList, Orders!.PressIn));

        // steche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Puncture);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Puncture, PList, Orders!.Puncture));

        // steche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Puncture);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_PunctureReverse, PList, Orders!.PunctureReverse));

        // steche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Puncture);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_PunctureSolo, PList, Orders!.PunctureSolo));

        // fotografiere
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Photograph);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Photograph, PList, Orders!.PhotographP));

        // fotografiere
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Photograph);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Photograph2, PList, Orders!.PhotographP2));

        // beschmutze mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Soil);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Soil, PList, Orders!.Soil));


        // schmiere an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Smear, PList, Orders!.Smear));

        // schmiere auf
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Smear2, PList, Orders!.SmearOn));

        // schmiere an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Smear, PList, Orders!.SmearP));

        // schmiere auf
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Smear2, PList, Orders!.SmearOnP));

        // schmiere
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_SmearSolo, PList, Orders!.SmearSolo));

        // beschmiere mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear2);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_SmearReverse, PList, Orders!.SmearReverseP));

        // tröte
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Blow);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Blow, PList, Orders!.Blow));

        // blase an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Blow);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_BlowWith, PList, Orders!.BlowWith));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Blow);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CA!.PL_BlowWith, PList, Orders!.BlowWith));

        // Vergleichen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Compare);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Compare, PList, Orders!.Compare));

        // vergifte
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poison);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Poison, PList, Orders!.Poison));

        // vergifte solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poison);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_PoisonSolo, PList, Orders!.PoisonSolo));

        // Krieche in
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Creep);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Creep, PList, Orders!.Creep));

        // Follow
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Follow);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Follow, PList, Orders!.Follow));

        // Jump
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Jump, PList, Orders!.Jump));

        // Jump in
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Jump_In, PList, Orders!.JumpIn));

        // Jump auf
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Jump_On, PList, Orders!.JumpOn));

        // Jump durch
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PList.AddPrep(CB!.Prep_durch);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Jump_Through, PList, Orders!.JumpThrough));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PList.AddPrep(CB!.Prep_aus);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Jump_Through, PList, Orders!.JumpThrough));

        // Turn
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Turn);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Turn, PList, Orders!.Turn));

        // rühre mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Mix, PList, Orders!.MixW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_um);
        PLL.Add(new ParseLine(CA!.PL_Mix, PList, Orders!.MixW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_MixReverse, PList, Orders!.MixWReverse));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_MixIn, PList, Orders!.MixIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_um);
        PLL.Add(new ParseLine(CA!.PL_MixIn, PList, Orders!.MixIn));

        // rühre Solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_MixSolo, PList, Orders!.MixSolo));

        // Pluck
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pluck);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Pluck, PList, Orders!.Pluck));

        // Suck
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Suck);
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Suck, PList, Orders!.Suck));

        // Suck
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Suck);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Suck2, PList, Orders!.Suck));

        // Sit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sit);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Sit1, PList, Orders!.Sit));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Sit2, PList, Orders!.Sit));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sit);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Sit3, PList, Orders!.SitP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sit);
        PList.AddPerson();
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Sit4, PList, Orders!.SitP));

        // Platzieren auf
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CB!.PL_Place_On, PList, Orders!.PlaceOn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CB!.PL_Place_On, PList, Orders!.PlaceOn));

        // Liege
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lay);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Lay1, PList, Orders!.Lay));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lay);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Lay2, PList, Orders!.Lay));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lay);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Lay3, PList, Orders!.LayP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lay);
        PList.AddPerson();
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Lay4, PList, Orders!.LayP));

        // Zerbrösel
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Crumble);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Crumble, PList, Orders!.CrumbleW));

        // Zerbrösel
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Crumble);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Crumble_in, PList, Orders!.CrumbleIn));

        // Lasse x stehen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Let);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_stehen);
        PLL.Add(new ParseLine(CA!.PL_Abandon, PList, Orders!.Abandon));

        // Küsse person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Kiss);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Kiss_P, PList, Orders!.KissP));

        // Beten
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pray);
        PLL.Add(new ParseLine(CA!.PL_Pray, PList, Orders!.Pray));

        // Biegen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bend);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Bend, PList, Orders!.Bend));

        // Scroll
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Scroll);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Scroll, PList, Orders!.Scroll));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Scroll);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Scroll, PList, Orders!.Scroll));

        // Leverage
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Leverage);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Leverage, PList, Orders!.Leverage));

        // Count
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Count);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Count, PList, Orders!.Count));

        // Breath
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Breath);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Breath, PList, Orders!.Breath));

        // Make
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Make);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PLL.Add(new ParseLine(CA!.PL_Make_On, PList, Orders!.MakeOn));

        // Make
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Make);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_aus);
        PLL.Add(new ParseLine(CA!.PL_Make_Off, PList, Orders!.MakeOff));

        // Sprühe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spray);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Spray, PList, Orders!.SprayOn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spray);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Spray_Solo, PList, Orders!.SpraySolo));

        // Tausche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Exchange);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Exchange, PList, Orders!.Exchange));

        // Tausche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Exchange);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_gegen);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Exchange, PList, Orders!.Exchange));

        // Tausche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Exchange);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_ExchangeSolo, PList, Orders!.ExchangeSolo));

        // Binde x los
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bind);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_los);
        PLL.Add(new ParseLine(CA!.PL_Free, PList, Orders!.Free));

        // befreie x
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Free);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Free, PList, Orders!.Free));

        /*
        // rühre x mit y 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_um);
        PLL.Add(new ParseLine(CA!.PL_Stir, PList, Orders!.Stir));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Stir2, PList, Orders!.Stir));
        */

        // stelle x ab
        /*
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CA!.PL_Park, PList, Orders!.Park));
        */

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hold);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_PlaceTo, PList, Orders!.PlaceTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hold);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_an);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_PlaceToP, PList, Orders!.PlaceToP));

        // Kneife mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pinch);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Pinch, PList, Orders!.PinchW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pinch);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CA!.PL_Pinch, PList, Orders!.PinchW));

        // begrabe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bury);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_BuryP, PList, Orders!.BuryP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bury);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_BuryPSolo, PList, Orders!.BuryPSolo));

        // Töte
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Toete);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Kill, PList, Orders!.Kill));

        // Töte mit 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Toete);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_KillW, PList, Orders!.KillW));

        // Tickle
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Kitzle);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Tickle, PList, Orders!.Tickle));

        // Tickle W
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Kitzle);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_TickleW, PList, Orders!.TickleW));

        // Fuck
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bumse);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Fuck, PList, Orders!.Fuck));

        // Beat
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Schlage);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Beat, PList, Orders!.Beat));

        // Beat W
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Schlage);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_BeatW, PList, Orders!.BeatW));

        // Aufschlagen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Schlage);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PLL.Add(new ParseLine(CB!.PL_Open, PList, Orders!.Open));



        // Pet
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Streichle);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Pet, PList, Orders!.Pet));

        // Cuddle
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Kuschle);
        PList.AddPrep(CB!.Prep_mit);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Cuddle, PList, Orders!.Cuddle));

        // Joggle
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Joggle);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Joggle, PList, Orders!.Joggle));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Joggle);
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Joggle, PList, Orders!.Joggle));

        // Sleep Solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sleep);
        PLL.Add(new ParseLine(CA!.PL_Sleep3, PList, Orders!.SleepSolo));

        // Sleep
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sleep);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Sleep, PList, Orders!.Sleep));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sleep);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Sleep2, PList, Orders!.Sleep));

        // Entfache
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spark);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Spark, PList, Orders!.Spark));

        // Entfache Solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spark);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Spark_Solo, PList, Orders!.SparkSolo));

        // verlasse
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Leave);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Leave, PList, Orders!.Leave));

        // verlasse solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Leave);
        PLL.Add(new ParseLine(CA!.PL_Leave, PList, Orders!.LeaveSolo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Leave2);
        PLL.Add(new ParseLine(CA!.PL_Leave, PList, Orders!.LeaveSolo));

        // Determine
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Determine);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Determine, PList, Orders!.DetermineW));

        // Determine Solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Determine);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Determine_Solo, PList, Orders!.DetermineSolo));

        // Remove
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Remove);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Remove, PList, Orders!.Remove));

        // Clean
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Clean);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Clean, PList, Orders!.CleanIn));

        // Clean
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Clean);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Clean_Solo, PList, Orders!.CleanSolo));

        // Clean with
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Clean);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Clean_W, PList, Orders!.CleanW));

        // Clean Person with
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Clean);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Clean_W, PList, Orders!.CleanPW));

        /*
        // Wash
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Clean);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Wash, PList, Orders!.WashIn));
        */

        /*
        // Wash solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Clean);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Wash_Solo, PList, Orders!.WashSolo));
        */

        // Split
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Split);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Split, PList, Orders!.Split));

        // wickle
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wrap);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_um);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Wrap, PList, Orders!.WrapP));

        // wickle
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wrap);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Wrap2, PList, Orders!.WrapP2));

        // wickle
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wrap);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_um);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Wrap2, PList, Orders!.WrapAround));


        // wickle Solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wrap);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Wrap_Solo, PList, Orders!.WrapSolo));

        // bemale Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Paint);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Paint, PList, Orders!.PaintP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Paint);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Paint, PList, Orders!.PaintP));


        // bemale Person solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Paint);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Paint_Solo, PList, Orders!.PaintSolo));

        // Trage/wear
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wear);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Wear, PList, Orders!.Wear));

        // Search
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Search, PList, Orders!.Search));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search2);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Search, PList, Orders!.Search));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_SearchW, PList, Orders!.SearchW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search2);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_SearchW, PList, Orders!.SearchW));

        // Search Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Search, PList, Orders!.SearchP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search2);
        PList.AddPrep(CB!.Prep_in);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Search, PList, Orders!.SearchP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_SearchW, PList, Orders!.SearchWP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search2);
        PList.AddPrep(CB!.Prep_in);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_SearchW, PList, Orders!.SearchWP));

        // Poke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poke);
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Poke, PList, Orders!.Poke));

        // Poke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poke);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Poke, PList, Orders!.Poke));

        // Poke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poke);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Poke, PList, Orders!.PokeRev));

        // Poke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Puncture);
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Poke, PList, Orders!.Poke));

        // Poke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Puncture);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Poke, PList, Orders!.PokeRev));

        // Dig
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dig);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Dig, PList, Orders!.Dig));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dig);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Dig, PList, Orders!.Dig));

        // Wake
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wake);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_auf);
        PLL.Add(new ParseLine(CA!.PL_Wake, PList, Orders!.WakeP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wake);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Wake, PList, Orders!.WakeP));

        // Ruf
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Shout);
        PLL.Add(new ParseLine(CA!.PL_Shout, PList, Orders!.Shout));

        // Spring
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PLL.Add(new ParseLine(CA!.PL_Jump, PList, Orders!.JumpSolo));

        // rutsche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Slide);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Slide, PList, Orders!.Slide));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Slide);
        PList.AddItem();
        PList.AddVerb(CB!.Verb_D);
        PLL.Add(new ParseLine(CA!.PL_Slide, PList, Orders!.Slide));

        // Accede
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Accede);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Accede, PList, Orders!.Accede));

        // Wer bin ich?
        PList = new ParseTokenList();
        PList.AddPrep(CB!.Prep_Wer);
        PList.AddVerb(CA!.Verb_Be);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Be, PList, Orders!.Be));

        // Reparieren
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Repair);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Repair, PList, Orders!.Repair));

        // Sortieren
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sort);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Sort, PList, Orders!.Sort));

        // Gestehe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Confess);
        PLL.Add(new ParseLine(CA!.PL_Confess, PList, Orders!.Confess));

        // Streiche über
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Stroke);
        PList.AddPrep(CB!.Prep_ueber);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Stroke, PList, Orders!.Stroke));

        // Schalte aus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Switch);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_aus);
        PLL.Add(new ParseLine(CA!.PL_SwitchOff, PList, Orders!.SwitchOff));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Switch);
        PList.AddPrep(CB!.Prep_aus);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_SwitchOff, PList, Orders!.SwitchOff));

        // Schalte ein
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Switch);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ein);
        PLL.Add(new ParseLine(CA!.PL_SwitchOn, PList, Orders!.SwitchOn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Switch);
        PList.AddPrep(CB!.Prep_ein);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_SwitchOn, PList, Orders!.SwitchOn));

        // Heben
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lift);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Lift, PList, Orders!.Lift));

        // Wischen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wipe);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Wipe, PList, Orders!.Wipe));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wipe);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_WipeW, PList, Orders!.WipeW));

        // Wischen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wipe);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Wipe, PList, Orders!.WipeP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wipe);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_WipeW, PList, Orders!.WipeWP));


        // Ausgänge
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Exits);
        PLL.Add(new ParseLine(CA!.PL_Exits, PList, Orders!.Exits));
        // 
        // bestehlen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Steal);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_StealP, PList, Orders!.StealP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Steal);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_von);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_StealWP, PList, Orders!.StealWP));

        // gleite über
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Slide);
        PList.AddPrep(CB!.Prep_ueber);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Slide, PList, Orders!.Slide));

        // Score
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Score);
        PLL.Add(new ParseLine(CA!.PL_Score, PList, Orders!.Score));

        // Destroy
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Destroy);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Destroy, PList, Orders!.Destroy));

        // Chop
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Chop);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Chop, PList, Orders!.Chop));

        // Chop
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Chop);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_ChopW, PList, Orders!.ChopW));

        // Chop
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Chop);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_ChopW, PList, Orders!.ChopW));

        // Plunge
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Plunge);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Plunge, PList, Orders!.PlungeIn));

        // Plunge aus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Plunge);
        PList.AddPrep(CB!.Prep_aus);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Plunge_Out, PList, Orders!.PlungeOut));

        // Roll in 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Roll);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_RollIn, PList, Orders!.RollIn));

        // Roll  
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Roll);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Roll_Solo, PList, Orders!.RollSolo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Roll);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PLL.Add(new ParseLine(CA!.PL_Roll_Solo, PList, Orders!.RollSolo));

        // Demolish
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Demolish);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Demolish, PList, Orders!.Demolish));

        // DemolishW
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Demolish);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Demolish, PList, Orders!.DemolishW));

        // Crack
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Crack);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Demolish, PList, Orders!.Demolish));

        // Glue To
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Glue);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_to);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_GlueTo, PList, Orders!.GlueTo));

        // Heat
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Heat);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Heat, PList, Orders!.Heat));

        // HeatW
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Heat);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_HeatW, PList, Orders!.HeatW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Heat);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_HeatW, PList, Orders!.HeatW));

        // Pulverize
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pulverize);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Pulverize, PList, Orders!.Pulverize));

        // Pulverize with
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pulverize);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Pulverize_W, PList, Orders!.PulverizeW));

        // Pulverize in
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pulverize);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Pulverize_W, PList, Orders!.PulverizeW));

        // Tidy
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tidy);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PLL.Add(new ParseLine(CA!.PL_Tidy, PList, Orders!.Tidy));

        // Brush
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Brush);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_BrushW, PList, Orders!.BrushW));


        // Tippe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Type);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Type, PList, Orders!.Type));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Type);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Type, PList, Orders!.Type));

        // Fry/ Brate
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fry);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Fry, PList, Orders!.FrySolo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fry);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Fry, PList, Orders!.FryIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fry);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Fry, PList, Orders!.FryIn));

        // Form
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Form);
        PList.AddTopic();
        PLL.Add(new ParseLine(CA!.PL_Form, PList, Orders!.Form));

        // Form aus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Form);
        PList.AddTopic();
        PList.AddPrep(CB!.Prep_aus);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_FormFrom, PList, Orders!.FormFrom));

        // Tanze/Dance
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dance);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Dance_Person, PList, Orders!.DanceWP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dance);
        PList.AddPrep(CB!.Prep_mit);
        PList.AddPerson();
        PLL.Add(new ParseLine(CA!.PL_Dance_Person, PList, Orders!.DanceWP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dance);
        PLL.Add(new ParseLine(CA!.PL_Dance, PList, Orders!.Dance));

        // Hängen/hang
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hang);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Hang, PList, Orders!.Hang));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hang);
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Hang2, PList, Orders!.Hang2));

        // Schwinge/swing
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Swing);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Swing, PList, Orders!.Swing));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Swing);
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Swing2, PList, Orders!.Swing2));

        // Store
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Store);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Store, PList, Orders!.Store));

        // Umdrehen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Turn);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_um);
        PLL.Add(new ParseLine(CA!.PL_Turn, PList, Orders!.TurnP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Turn);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CA!.PL_Turn, PList, Orders!.TurnP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Turn);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_herum);
        PLL.Add(new ParseLine(CA!.PL_Turn, PList, Orders!.TurnP));

        // Singe solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sing);
        PLL.Add(new ParseLine(CA!.PL_SingSolo, PList, Orders!.SingSolo));

        // Singe solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sing);
        PList.AddTopic();
        PLL.Add(new ParseLine(CA!.PL_Sing, PList, Orders!.Sing));

        // Lecke an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lick);
        PList.AddPrep(CB!.Prep_an);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Lick, PList, Orders!.Lick));

        // verstecke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hide);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_hinter);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Hide_P, PList, Orders!.HideP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hide);
        PList.AddPrep(CB!.Prep_hinter);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Hide, PList, Orders!.Hide));

        // verbrenne
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Burn);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Burn_W, PList, Orders!.BurnW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Burn);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Burn, PList, Orders!.Burn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Burn);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Burn_In, PList, Orders!.BurnIn));

        // rauche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smoke);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Smoke, PList, Orders!.Smoke));

        // zerreiße
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tear);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tear, PList, Orders!.Tear));

        // reiße ab
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Rip);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_Tear, PList, Orders!.RipOff));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Rip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLL.Add(new ParseLine(CA!.PL_Tear, PList, Orders!.RipOff));

        // Testwindow
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Testwindow);
        PLL.Add(new ParseLine(CA!.PL_Testwindow, PList, Orders!.Testwindow));

        // Brief
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Brief);
        PLL.Add(new ParseLine(CA!.PL_Brief, PList, Orders!.Brief));

        // Verbose
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Verbose);
        PLL.Add(new ParseLine(CA!.PL_Verbose, PList, Orders!.Verbose));

        // telefoniere
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Phone);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_PhoneW, PList, Orders!.PhoneW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Phone);
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLL.Add(new ParseLine(CA!.PL_PhoneW, PList, Orders!.PhoneW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Phone);
        PLL.Add(new ParseLine(CA!.PL_Phone, PList, Orders!.Phone));

        // Anleitung
        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Manual!.ID);
        PLL.Add(new ParseLine(CA!.PL_Manual, PList, Orders!.Manual, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Credits);
        PLL.Add(new ParseLine(CA!.PL_Credits, PList, Orders!.Credits));

        // Grafik
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddPrep(CB!.Prep_Stufe1);
        PLL.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationSmall));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddPrep(CB!.Prep_Stufe2);
        PLL.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationMediocre));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddPrep(CB!.Prep_Stufe3);
        PLL.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationLarge));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddAdj(CA.Adj_klein!.ID);
        PLL.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationSmall));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddAdj(CA.Adj_mittel!.ID);
        PLL.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationMediocre));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddAdj(CA.Adj_gross!.ID);
        PLL.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationLarge));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddPrep(CB!.Prep_aus);
        PLL.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationOff));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Undo);
        PLL.Add(new ParseLine(CA!.PL_Undo, PList, Orders!.Undo));
        /*
                     // Schleudere nach
                     PList = new ParseTokenList();
                     PList.AddTopic(CA!.Nounverb_Schleuder);
                     PList.AddItem();
                     PList.AddPrep(CB!.Prep_nach);
                     PList.AddItem();
                     PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.Throw));

                     // Schleudere zu
                     PList = new ParseTokenList();
                     PList.AddTopic(CA!.Nounverb_Schleuder);
                     PList.AddItem();
                     PList.AddPrep(CB!.Prep_zu);
                     PList.AddItem();
                     PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.Throw));
                     */
    }

    public void InitPLLEng()
    {
        ParseTokenList PList;


        PLLEng = new ParseLineList();

        // Story
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Story);
        PLLEng.Add(new ParseLine(CB!.PL_Story, PList, Orders!.WriteStory));

        // Deutsch
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_German);
        PLLEng.Add(new ParseLine(CB!.PL_German, PList, Orders!.German));

        // Englisch
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_English);
        PLLEng.Add(new ParseLine(CB!.PL_English, PList, Orders!.English));


        // Take
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Take, PList, Orders!.Take));


        // Take MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PLLEng.Add(new ParseLine(CB!.PL_Take, PList, Orders!.TakeMC, false));

        // Take all
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_alles);
        PLLEng.Add(new ParseLine(CB!.PL_TakeAll, PList, Orders!.TakeAll));

        // Take Down
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddVerb(CB!.Verb_D);
        PLLEng.Add(new ParseLine(CB!.PL_TakeDown, PList, Orders!.TakeDown));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddVerb(CB!.Verb_D);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_TakeDown, PList, Orders!.TakeDown));

        // Play
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Play);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Play, PList, Orders!.Play));

        // gehe nach norden
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_N);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoN));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_N);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoN));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_N);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoN));


        // gehe nach nordosten
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_NE);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoNE));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_NE);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoNE));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_NE);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoNE));

        // gehe nach osten
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_E);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoE));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_E);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoE));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_E);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoE));

        // Südosten
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_SE);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoSE));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_SE);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoSE));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_SE);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoSE));

        // Süden
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_S);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoS));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_S);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoS));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_S);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoS));

        // Südwesten
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_SW);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoSW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_SW);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoSW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_SW);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoSW));

        // Westen
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_W);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_W);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_W);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PLLEng.Add(new ParseLine(CB!.PL_GoMC, PList, Orders!.GoMC));

        // Nordwesten
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_NW);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoNW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_NW);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoNW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_NW);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoNW));

        // Hoch
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoU));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_U);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoU));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_U);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoU));

        // runter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_D);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoD));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddVerb(CB!.Verb_D);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoD));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddVerb(CB!.Verb_D);
        PLLEng.Add(new ParseLine(CB!.PL_Go, PList, Orders!.GoD));

        // gehe durch 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_through);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Go_Through, PList, Orders!.GoThrough));

        // gehe durch 
        /*
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Go_Through2, PList, Orders!.GoThrough));
        */

        // gehe hinter 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_behind);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Go_Behind, PList, Orders!.GoBehind));

        // gehe durch MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_through);
        PLLEng.Add(new ParseLine(CB!.PL_Go_Through, PList, Orders!.GoThroughMC));

        // gehe zu
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Go_To, PList, Orders!.GoTo));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Go_To2, PList, Orders!.GoTo));

        // gehe in
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Go_In, PList, Orders!.GoIn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Go_In, PList, Orders!.GoIn));


        // gehe zu MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Go);
        PList.AddPrep(CB!.Prep_nach);
        PLLEng.Add(new ParseLine(CB!.PL_Go_To2, PList, Orders!.GoToMC, false));


        // Inv
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Inventory);
        PLLEng.Add(new ParseLine(CB!.PL_Inventory, PList, Orders!.Inventory));

        // Examine
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddItemRange(Co.Range_Visible);
        PLLEng.Add(new ParseLine(CB!.PL_Examine, PList, Orders!.Examine));

        // Examine MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PLLEng.Add(new ParseLine(CB!.PL_Examine, PList, Orders!.ExamineMC, false));

        // U Item
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddItemRange(Co.Range_Visible);
        PLLEng.Add(new ParseLine(CB!.PL_Examine, PList, Orders!.Examine));

        // schaue auf
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineOn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineOn));

        // schaue auf MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_on);
        PLLEng.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineOnMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine, PList, Orders!.Examine));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine, PList, Orders!.Examine));

        // schaue auf MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_at);
        PLLEng.Add(new ParseLine(CB!.PL_Examine, PList, Orders!.ExamineMC, false));

        // schaue in
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_In, PList, Orders!.ExamineIn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_In, PList, Orders!.ExamineIn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineIn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineIn));

        // schaue in MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_in);
        PLLEng.Add(new ParseLine(CB!.PL_Examine_In, PList, Orders!.ExamineInMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_into);
        PLLEng.Add(new ParseLine(CB!.PL_Examine_In, PList, Orders!.ExamineInMC, false));

        // schaue behind
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_behind);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_Behind, PList, Orders!.ExamineBehind));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_behind);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineBehind ));

        // schaue behind MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_behind);
        PLLEng.Add(new ParseLine(CB!.PL_Examine_Behind, PList, Orders!.ExamineBehindMC, false));

        // schaue below
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_under);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_Below, PList, Orders!.ExamineBelow));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_under);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_On, PList, Orders!.ExamineBelow));

        // schaue below MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_under);
        PLLEng.Add(new ParseLine(CB!.PL_Examine_Below, PList, Orders!.ExamineBelowMC, false));

        // schaue beside
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_beside);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_Beside, PList, Orders!.ExamineBeside));

        // schaue beside MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_beside);
        PLLEng.Add(new ParseLine(CB!.PL_Examine_Beside, PList, Orders!.ExamineBesideMC, false));

        // Schaue durch
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_through);
        PList.AddItemRange(Co.Range_Visible);
        PLLEng.Add(new ParseLine(CB!.PL_Examine_Through, PList, Orders!.ExamineThrough));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPrep(CB!.Prep_through);
        PList.AddItemRange(Co.Range_Visible);
        PLLEng.Add(new ParseLine(CB!.PL_Examine_Through, PList, Orders!.ExamineThrough));

        // Schaue aus
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPrep(CB!.Prep_out);
        PList.AddItemRange(Co.Range_Visible);
        PLLEng.Add(new ParseLine(CB!.PL_Examine_Out, PList, Orders!.ExamineOut));

        // Examine Topic
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddTopic();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_T, PList, Orders!.ExamineT));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddTopic();
        PLLEng.Add(new ParseLine(CB!.PL_Examine_T, PList, Orders!.ExamineT));

        // location
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_location);
        PLLEng.Add(new ParseLine(CB!.PL_location, PList, Orders!.location));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddVerb(CB!.Verb_location);
        PLLEng.Add(new ParseLine(CB!.PL_location, PList, Orders!.location));

        // Drop
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Drop);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Drop, PList, Orders!.Drop));

        // Drop MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Drop);
        PLLEng.Add(new ParseLine(CB!.PL_Drop, PList, Orders!.DropMC, false));

        /*
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Drop, PList, Orders!.Drop));

        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Drop, PList, Orders!.Drop));
        */

        // Hinlegen
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPerson();
        PList.AddVerb(CB!.Verb_D);
        PLLEng.Add(new ParseLine(CB!.PL_Lay_Down, PList, Orders!.LayDown));

        // Öffne
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Open);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Open, PList, Orders!.Open));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PLLEng.Add(new ParseLine(CB!.PL_Open, PList, Orders!.OpenUp));

        // Öffne MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Open);
        PLLEng.Add(new ParseLine(CB!.PL_Open, PList, Orders!.OpenMC, false));

        // schließe
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Close, PList, Orders!.Close));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_zu);
        PLLEng.Add(new ParseLine(CB!.PL_Close, PList, Orders!.Close));


        // schließe MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PLLEng.Add(new ParseLine(CB!.PL_Close, PList, Orders!.CloseMC, false));

        // Unlock
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Open);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Unlock_W, PList, Orders!.UnlockW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Unlock);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Unlock_W, PList, Orders!.UnlockW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_auf);
        PLLEng.Add(new ParseLine(CB!.PL_Unlock_W, PList, Orders!.UnlockW));

        // Unlock MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Open);
        PList.AddPrep(CB!.Prep_with);
        PLLEng.Add(new ParseLine(CB!.PL_Unlock_W, PList, Orders!.UnlockWMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddPrep(CB!.Prep_with);
        PList.AddPrep(CB!.Prep_auf);
        PLLEng.Add(new ParseLine(CB!.PL_Unlock_W, PList, Orders!.UnlockWMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Unlock);
        PList.AddPrep(CB!.Prep_with);
        PList.AddPrep(CB!.Prep_auf);
        PLLEng.Add(new ParseLine(CB!.PL_Unlock_W, PList, Orders!.UnlockWMC, false));

        // Lock
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lock);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Lock_W1, PList, Orders!.LockW));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schloss!.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Lock_W1, PList, Orders!.LockW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Lock_W1, PList, Orders!.LockW));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_zu);
        PLLEng.Add(new ParseLine(CB!.PL_Lock_W2, PList, Orders!.LockW));

        /*
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_ab);
        PLLEng.Add(new ParseLine(CB!.PL_Lock_W3, PList, Orders!.LockW));
        */
        // Lock MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lock);
        PList.AddPrep(CB!.Prep_with);
        PLLEng.Add(new ParseLine(CB!.PL_Lock_WMC, PList, Orders!.LockWMC, false));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schloss.ID);
        PList.AddPrep(CB!.Prep_with);
        PLLEng.Add(new ParseLine(CB!.PL_Lock_WMC, PList, Orders!.LockWMC, false));


        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddPrep(CB!.Prep_with);
        PList.AddPrep(CB!.Prep_zu);
        PLLEng.Add(new ParseLine(CB!.PL_Lock_WMC, PList, Orders!.LockWMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddPrep(CB!.Prep_with);
        PLLEng.Add(new ParseLine(CB!.PL_Lock_WMC, PList, Orders!.LockWMC, false));

        // Lege auf xx
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_PlaceSoloOn, PList, Orders!.PlaceSoloOn));

        PList = new ParseTokenList();
        PList!.AddNoun(CA!.Noun_Platz!.ID);
        PList!.AddPrep(CB!.Prep_auf);
        PList!.AddItem();
        PLLEng!.Add(new ParseLine(CB!.PL_PlaceSoloOn, PList, Orders!.PlaceSoloOn));

        // Lege in
        PList = new ParseTokenList();
        PList!.AddVerb(CB!.Verb_Place);
        PList!.AddItem();
        PList!.AddPrep(CB!.Prep_in);
        PList!.AddItem();
        PLLEng!.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceIn));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceIn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceIn));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceIn));


        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceIn));

        // Lege in MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_in);
        PLLEng.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceInMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_into);
        PLLEng.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceInMC, false));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddPrep(CB!.Prep_in);
        PLLEng.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceInMC, false));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddPrep(CB!.Prep_into);
        PLLEng.Add(new ParseLine(CB!.PL_Place_In, PList, Orders!.PlaceInMC, false));

        // Lege auf
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_On, PList, Orders!.PlaceOn));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_On, PList, Orders!.PlaceOn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_On, PList, Orders!.PlaceOn));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_On, PList, Orders!.PlaceOn));

        // Lege auf MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_on);
        PLLEng.Add(new ParseLine(CB!.PL_Place_On, PList, Orders!.PlaceOnMC, false));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddPrep(CB!.Prep_on);
        PLLEng.Add(new ParseLine(CB!.PL_Place_On, PList, Orders!.PlaceOnMC, false));

        // Lege hinter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_behind);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_Behind, PList, Orders!.PlaceBehind));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_behind);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_Behind, PList, Orders!.PlaceBehind));

        // Lege hinter MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_behind);
        PLLEng.Add(new ParseLine(CB!.PL_Place_Behind, PList, Orders!.PlaceBehindMC, false));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddPrep(CB!.Prep_behind);
        PLLEng.Add(new ParseLine(CB!.PL_Place_Behind, PList, Orders!.PlaceBehindMC, false));

        // Lege unter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_under);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_Under, PList, Orders!.PlaceUnder));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_under);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_Under, PList, Orders!.PlaceUnder));

        // Lege unter MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_under);
        PLLEng.Add(new ParseLine(CB!.PL_Place_Under, PList, Orders!.PlaceUnderMC, false));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddPrep(CB!.Prep_under);
        PLLEng.Add(new ParseLine(CB!.PL_Place_Under, PList, Orders!.PlaceUnderMC, false));

        // Lege neben
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_beside);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_Beside, PList, Orders!.PlaceBeside));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_beside);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_Beside, PList, Orders!.PlaceBeside));

        // Lege neben MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPrep(CB!.Prep_beside);
        PLLEng.Add(new ParseLine(CB!.PL_Place_Beside, PList, Orders!.PlaceBesideMC, false));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddPrep(CB!.Prep_beside);
        PLLEng.Add(new ParseLine(CB!.PL_Place_Beside, PList, Orders!.PlaceBesideMC, false));

        // Nimm aus
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_from);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Take_Out, PList, Orders!.TakeOut));

        // Nimm aus MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_from);
        PLLEng.Add(new ParseLine(CB!.PL_Take_Out, PList, Orders!.TakeOutMC, false));

        // Nimm von MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_from);
        PLLEng.Add(new ParseLine(CB!.PL_Take_From, PList, Orders!.TakeFromMC, false));

        // Nimm hinter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_behind);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Take_From_Behind, PList, Orders!.TakeBehind));

        // Nimm hinter MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_behind);
        PLLEng.Add(new ParseLine(CB!.PL_Take_From_Behind, PList, Orders!.TakeBehindMC, false));

        // Nimm unter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_under);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Take_From_Under, PList, Orders!.TakeUnder));

        // Nimm unter MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_under);
        PLLEng.Add(new ParseLine(CB!.PL_Take_From_Under, PList, Orders!.TakeUnderMC, false));

        // Nimm neben
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_beside);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_Beside, PList, Orders!.TakeBeside));

        // Nimm neben MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_beside);
        PLLEng.Add(new ParseLine(CB!.PL_Place_Beside, PList, Orders!.TakeBesideMC, false));

        // Speichern
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot1);
        PLLEng.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot2);
        PLLEng.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot3);
        PLLEng.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot4);
        PLLEng.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot5);
        PLLEng.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot6);
        PLLEng.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot7);
        PLLEng.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot8);
        PLLEng.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot9);
        PLLEng.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PList.AddPrep(CB!.Prep_Slot10);
        PLLEng.Add(new ParseLine(CB!.PL_Save, PList, Orders!.Save, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Save);
        PLLEng.Add(new ParseLine(CB!.PL_Save_MC, PList, Orders!.SaveMC, false));

        // Laden
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot1);
        PLLEng.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot2);
        PLLEng.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot3);
        PLLEng.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot4);
        PLLEng.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot5);
        PLLEng.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot6);
        PLLEng.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot7);
        PLLEng.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot8);
        PLLEng.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot9);
        PLLEng.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PList.AddPrep(CB!.Prep_Slot10);
        PLLEng.Add(new ParseLine(CB!.PL_Load, PList, Orders!.Load, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Load);
        PLLEng.Add(new ParseLine(CB!.PL_Load_MC, PList, Orders!.LoadMC, false));

        // Lokale Befehle, also solche, die keine base-Implementierung haben

        // Benutzen
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Use);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Use, PList, Orders!.Use));

        // Benutzen MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Use);
        PLLEng.Add(new ParseLine(CA!.PL_Use, PList, Orders!.UseMC, false));

        // Benutzen mit
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Use);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Use_W, PList, Orders!.UseW));

        // Benutzen mit MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Use);
        PList.AddPrep(CB!.Prep_with);
        PLLEng.Add(new ParseLine(CA!.PL_Use_W, PList, Orders!.UseWMC, false));

        // Benutzen mit Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Use);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Use_W_P, PList, Orders!.UseWP));

        // Schraube los
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Unscrew);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Unscrew_W, PList, Orders!.UnscrewW));


        // kappen/truncate
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Truncate);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Truncate_W, PList, Orders!.TruncateW));

        // Spanne ein in 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mount);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Mount, PList, Orders!.MountW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mount);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Mount, PList, Orders!.MountW));


        // Spanne 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mount);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Mount, PList, Orders!.Mount));

        // Säge mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Saw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Saw, PList, Orders!.Saw));

        // Säge
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Saw);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Saw2, PList, Orders!.SawSolo));


        // Words
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Words);
        PLLEng.Add(new ParseLine(CB!.PL_Words, PList, Orders!.Words));

        // Verbs
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Verbs);
        PLLEng.Add(new ParseLine(CB!.PL_Verbs, PList, Orders!.Verblist));

        // Protokoll an
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_ProtOn);
        PLLEng.Add(new ParseLine(CB!.PL_Prot_On, PList, Orders!.ProtOn));

        // Protokoll aus
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_ProtOff);
        PLLEng.Add(new ParseLine(CB!.PL_Prot_Off, PList, Orders!.ProtOff));

        // Wirf nach
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.Throw));

        // Wirf nach MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddPrep(CB!.Prep_nach);
        PLLEng.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.Throw));

        // Wirf nach MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddPrep(CB!.Prep_at);
        PLLEng.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PLLEng.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_away);
        PLLEng.Add(new ParseLine(CB!.PL_Drop2, PList, Orders!.Drop));

        // Wirf nach
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowPnach));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowPnach));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowPnach));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder!.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowPnach));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder!.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_zu);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowPnach));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schleuder.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_auf);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.ThrowPnach));

        // Throw out of
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_out);
        PList.AddPrep(CB!.Prep_of);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Throw_Out, PList, Orders!.ThrowOut));

        // Throw in 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Throw_In, PList, Orders!.ThrowIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Throw_In, PList, Orders!.ThrowIn));

        // Wirf solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Throw_Solo, PList, Orders!.ThrowSolo));

        // Wirf nach Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Throw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Throw_Person, PList, Orders!.ThrowP));

        // Ziehen an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Draw, PList, Orders!.Draw));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Draw, PList, Orders!.Draw));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddNoun(CA!.Noun_Ruecken!.ID);
        PLLEng.Add(new ParseLine(CA!.PL_Draw, PList, Orders!.Draw));

        // Ziehe heraus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddPrep(CB!.Prep_out);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_DrawOut, PList, Orders!.DrawOut));

        // Ziehe ab
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddPrep(CB!.Prep_off);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_DrawOff, PList, Orders!.DrawOff));

        // Ziehen an MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddPrep(CB!.Prep_on);
        PLLEng.Add(new ParseLine(CA!.PL_Draw, PList, Orders!.DrawMC, false));

        // Ziehe Item mit Item heraus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_DrawWith, PList, Orders!.DrawWith));

        // Ziehen runter
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Draw);
        PList.AddItem();
        PList.AddVerb(CB!.Verb_D);
        PLLEng.Add(new ParseLine(CA!.PL_Draw_Down, PList, Orders!.DrawDown));

        // Schiebe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Push);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Push, PList, Orders!.Push));

        // Schiebe MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Push);
        PLLEng.Add(new ParseLine(CA!.PL_Push, PList, Orders!.PushMC, false));

        // Schiebe Zu
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Push);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Push_To, PList, Orders!.PushTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Push);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Push_To, PList, Orders!.PushTo));

        // Schiebe hoch
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Push);
        PList.AddItem();
        PList.AddVerb(CB!.Verb_U);
        PLLEng.Add(new ParseLine(CA!.PL_Push_Up, PList, Orders!.PushUp));

        // Schiebe Zu MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Push);
        PList.AddPrep(CB!.Prep_nach);
        PLLEng.Add(new ParseLine(CA!.PL_Push_To, PList, Orders!.PushToMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Push);
        PList.AddPrep(CB!.Prep_to);
        PLLEng.Add(new ParseLine(CA!.PL_Push_To, PList, Orders!.PushToMC, false));

        // Hilfe
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Help);
        PLLEng.Add(new ParseLine(CB!.PL_Help, PList, Orders!.InfoMC));

        // Hilfe
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Help);
        PList.AddPrep(CB!.Prep_about);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Help_For, PList, Orders!.HelpFor));

        // Hilfe
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Help);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Help_For_P, PList, Orders!.HelpForP));

        // Hilfe
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Help);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Help_For2, PList, Orders!.HelpFor));

        // Hilfe
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Help);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Help_For_P2, PList, Orders!.HelpForP));

        // Info
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Info);
        PLLEng.Add(new ParseLine(CB!.PL_Info, PList, Orders!.GameInfo));

        // Info
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Info);
        PList.AddPrep(CB!.Prep_about);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Info_For, PList, Orders!.InfoFor));

        // Info
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Info);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Info_For2, PList, Orders!.InfoFor));

        // Info
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Info);
        PList.AddPrep(CB!.Prep_about);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Info_For_P, PList, Orders!.InfoForP));

        // Info
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Help);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Info_For_P2, PList, Orders!.InfoForP));

        // Clue
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Clue);
        PList.AddPrep(CB!.Prep_for);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Clue_For, PList, Orders!.ClueFor));

        // Clue
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Clue);
        PList.AddPrep(CB!.Prep_for);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Clue_For_P, PList, Orders!.ClueForP));

        // Clue
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Clue);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Clue_For2, PList, Orders!.ClueFor));

        // Clue
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Clue);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Clue_For_P2, PList, Orders!.ClueForP));

        // Solution
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Solution);
        PList.AddPrep(CB!.Prep_for);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Solution_For, PList, Orders!.SolutionFor));

        // Solution
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Solution);
        PList.AddPrep(CB!.Prep_for);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Solution_For_P, PList, Orders!.SolutionForP));

        // Solution
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Solution);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Solution_For2, PList, Orders!.SolutionFor));

        // Solution
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Solution);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Solution_For_P2, PList, Orders!.SolutionForP));

        // Take Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Take_P, PList, Orders!.TakeP));

        // Examine Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Examine);
        PList.AddPersonRange(Co.Range_Visible);
        PLLEng.Add(new ParseLine(CB!.PL_Examine_P, PList, Orders!.ExamineP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_U);
        PList.AddPersonRange(Co.Range_Visible);
        PLLEng.Add(new ParseLine(CB!.PL_Examine_P, PList, Orders!.ExamineP));

        // Open Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Open);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Open_P, PList, Orders!.OpenP));

        // Close Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Close_P, PList, Orders!.CloseP));

        // Unlock Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Open);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Unlock_W_P, PList, Orders!.UnlockWP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Unlock);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Unlock_W_P, PList, Orders!.UnlockWP));

        // Lock Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lock);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Lock_W_P, PList, Orders!.LockWP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Close);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Lock_W_P, PList, Orders!.LockWP));

        // Lege in Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Place_In_P, PList, Orders!.PlaceInP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Place_In_P, PList, Orders!.PlaceInP));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Place_In_P, PList, Orders!.PlaceInP));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Place_In_P, PList, Orders!.PlaceInP));

        // Lege Person in 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_P_In, PList, Orders!.PlacePIn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_P_In, PList, Orders!.PlacePIn));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_P_In, PList, Orders!.PlacePIn));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Place_P_In, PList, Orders!.PlacePIn));

        // Lege - solo
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Place);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Place_Solo, PList, Orders!.PlaceSolo));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Platz.ID);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Place_Solo, PList, Orders!.PlaceSolo));

        // Give to Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Give_To_P, PList, Orders!.GiveToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Give_To_P, PList, Orders!.GiveToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddItem();
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Give_To_P, PList, Orders!.GiveToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddPerson();
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Give_To_P2, PList, Orders!.GiveToP2));


        // Give to Person MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddPrep(CB!.Prep_nach);
        PLLEng.Add(new ParseLine(CA!.PL_Give_To_P, PList, Orders!.GiveToPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddPrep(CB!.Prep_to);
        PLLEng.Add(new ParseLine(CA!.PL_Give_To_P, PList, Orders!.GiveToPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PLLEng.Add(new ParseLine(CA!.PL_Give_To_P, PList, Orders!.GiveToPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Give_Solo, PList, Orders!.GiveSolo, false));

        // Give to Item
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Give_To_I, PList, Orders!.GiveToI));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Give);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_to);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Give_To_I, PList, Orders!.GiveToI));

        // Show to Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Show);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Show_To_P, PList, Orders!.ShowToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Show);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_to);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Show_To_P, PList, Orders!.ShowToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Show);
        PList.AddItem();
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Show_To_P, PList, Orders!.ShowToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Show);
        PList.AddPerson();
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Show_To_P2, PList, Orders!.ShowToP2));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Show);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Show_Solo, PList, Orders!.ShowSolo, false));

        // Plea from Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Plea);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_from);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Plea_From_P, PList, Orders!.PleaFromP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Plea);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Plea_Solo, PList, Orders!.PleaSolo));

        // Plea from Person MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Plea);
        PList.AddPrep(CB!.Prep_from);
        PLLEng.Add(new ParseLine(CA!.PL_Plea_From_P, PList, Orders!.PleaFromPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Plea);
        PLLEng.Add(new ParseLine(CA!.PL_Plea_From_P, PList, Orders!.PleaFromPMC, false));

        // Demand from Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Demand);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_from);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Demand_From_P, PList, Orders!.DemandFromP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Demand);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Demand_Solo, PList, Orders!.DemandSolo));

        // Demand from Person MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Demand);
        PList.AddPrep(CB!.Prep_from);
        PLLEng.Add(new ParseLine(CA!.PL_Demand_From_P, PList, Orders!.DemandFromPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Demand);
        PLLEng.Add(new ParseLine(CA!.PL_Demand_From_P, PList, Orders!.DemandFromPMC, false));

        // Say to Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Say_To_P, PList, Orders!.SayToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_to);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Say_To_P, PList, Orders!.SayToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_with);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Say_To_P, PList, Orders!.SayToP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Say_To_P2, PList, Orders!.SayToP));

        // Say to Person MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_nach);
        PLLEng.Add(new ParseLine(CA!.PL_Say_To_P, PList, Orders!.SayToPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_at);
        PLLEng.Add(new ParseLine(CA!.PL_Say_To_P, PList, Orders!.SayToPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_with);
        PLLEng.Add(new ParseLine(CA!.PL_Say_To_P, PList, Orders!.SayToPMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PLLEng.Add(new ParseLine(CA!.PL_Say_To_P, PList, Orders!.SayToPMC, false));

        // Say to Item
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Say_To_I, PList, Orders!.SayToI));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Say_To_I, PList, Orders!.SayToI));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Say_To_I, PList, Orders!.SayToI));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Say);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Say_To_I2, PList, Orders!.SayToI));


        // Fragen nach Item
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Ask);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_for);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Ask, PList, Orders!.Ask));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Ask);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_AskSolo, PList, Orders!.AskSolo));

        // Fragen nach Item MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Ask);
        PList.AddPrep(CB!.Prep_for);
        PLLEng.Add(new ParseLine(CB!.PL_Ask, PList, Orders!.AskMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Ask);
        PLLEng.Add(new ParseLine(CB!.PL_Ask, PList, Orders!.AskMC, false));

        // Fragen nach Topic
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Ask);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_about);
        PList.AddTopicRange(Co.Range_Known);
        PLLEng.Add(new ParseLine(CB!.PL_Ask_Topic, PList, Orders!.AskTopic));

        // Fragen nach Person
        /* Problematisch: Zu viele Charaktere heißen gleich. Und das kann der Parser nicht händlen. 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Ask);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddPersonRange(Co.Range_Known);
        PLLEng.Add(new ParseLine(CB!.PL_Ask_Person, PList, Orders!.AskPerson));
        */

        // lies
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Read);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Read, PList, Orders!.Read));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Read);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Read, PList, Orders!.ReadW));

        // lies MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Read);
        PLLEng.Add(new ParseLine(CA!.PL_Read, PList, Orders!.ReadMC, false));

        // Betrete Item
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Enter);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Enter, PList, Orders!.Enter));

        // Betrete Item MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Enter);
        PLLEng.Add(new ParseLine(CB!.PL_Enter, PList, Orders!.EnterMC, false));

        // Klettere Item
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Climb, PList, Orders!.Climb));

        // Klettere <>
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PLLEng.Add(new ParseLine(CB!.PL_ClimbMC, PList, Orders!.ClimbMC, false));

        // Klettere Item hoch
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_hoch);
        PLLEng.Add(new ParseLine(CA!.PL_ClimbUp, PList, Orders!.ClimbUp));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddItem();
        PList.AddVerb(CB!.Verb_U);
        PLLEng.Add(new ParseLine(CA!.PL_ClimbUp, PList, Orders!.ClimbUp));

        // Klettere durch Item 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_through);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_ClimbThrough, PList, Orders!.ClimbThrough));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_out);
        PList.AddPrep(CB!.Prep_of);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_ClimbThrough, PList, Orders!.ClimbOut));

        // Klettere in Item 
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_ClimbIn, PList, Orders!.ClimbIn));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_ClimbIn, PList, Orders!.ClimbIn));

        // Klettere Item hoch MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_hoch);
        PLLEng.Add(new ParseLine(CA!.PL_ClimbUpMC, PList, Orders!.ClimbUpMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddVerb(CB!.Verb_U);
        PLLEng.Add(new ParseLine(CA!.PL_ClimbUpMC, PList, Orders!.ClimbUpMC, false));

        // Klettere auf
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_ClimbOn, PList, Orders!.ClimbOn));

        // riechen
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Smell, PList, Orders!.Smell));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Smell2, PList, Orders!.Smell));

        // rieche MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PList.AddPrep(CB!.Prep_on);
        PLLEng.Add(new ParseLine(CB!.PL_Smell, PList, Orders!.SmellMC, false));

        // rieche Solo
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PLLEng.Add(new ParseLine(CB!.PL_SmellSolo, PList, Orders!.SmellSolo));

        // riechen Person
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Smell_P, PList, Orders!.SmellP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PList.AddPrep(CB!.Prep_on);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Smell2_P, PList, Orders!.SmellP));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Smell);
        PList.AddPrep(CB!.Prep_off);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_Smell2_P, PList, Orders!.SmellP));

        // schmecke
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Taste);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_Taste, PList, Orders!.Taste));

        // schmecke MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Taste);
        PLLEng.Add(new ParseLine(CB!.PL_Taste, PList, Orders!.TasteMC, false));

        // Klettere Item runter MC
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddVerb(CB!.Verb_D);
        PLLEng.Add(new ParseLine(CA!.PL_ClimbDown2, PList, Orders!.ClimbDownMC, false));

        // Klettere Item runter
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Climb);
        PList.AddVerb(CB!.Verb_D);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_ClimbDown, PList, Orders!.ClimbDown));

        // Warten
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Wait);
        PLLEng.Add(new ParseLine(CB!.PL_Wait, PList, Orders!.Wait));

        // Warten auf
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Wait);
        PList.AddPrep(CB!.Prep_for);
        PList.AddPersonRange(Co.Range_Active);
        PLLEng.Add(new ParseLine(CB!.PL_Wait2, PList, Orders!.WaitFor));

        // Quit
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Quit);
        PLLEng.Add(new ParseLine(CB!.PL_Quit, PList, Orders!.Quit, false));

        // Restart
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Restart);
        PLLEng.Add(new ParseLine(CB!.PL_Restart, PList, Orders!.Restart, false));

        // Restart Restart
        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Restart);
        PList.AddVerb(CB!.Verb_Restart);
        PLLEng.Add(new ParseLine(CB!.PL_Restart2, PList, Orders!.RestartNoAsk, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Restart);
        PList.AddVerb(CB!.Verb_Restart);
        PList.AddVerb(CB!.Verb_German);
        PLLEng.Add(new ParseLine(CB!.PL_Restart3, PList, Orders!.RestartNoAskGerman, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Restart);
        PList.AddVerb(CB!.Verb_Restart);
        PList.AddVerb(CB!.Verb_English);
        PLLEng.Add(new ParseLine(CB!.PL_Restart4, PList, Orders!.RestartNoAskEnglish, false));
        
        // lösen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Untighten);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Untighten, PList, Orders!.Untighten));

        // lösen MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Untighten);
        PLLEng.Add(new ParseLine(CA!.PL_Untighten, PList, Orders!.UntightenMC, false));

        // lösen mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Untighten);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Untighten, PList, Orders!.UntightenW));

        // brechen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Break);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Break, PList, Orders!.Break));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Break);
        PList.AddVerb(CB!.Verb_D);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Break_Down, PList, Orders!.BreakDown));

        // brechen MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Break);
        PLLEng.Add(new ParseLine(CA!.PL_Break, PList, Orders!.BreakMC, false));

        // schneiden 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Cut);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Cut, PList, Orders!.Cut));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Cut);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Cut_Solo, PList, Orders!.CutSolo));

        // schneiden MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Cut);
        PList.AddPrep(CB!.Prep_with);
        PLLEng.Add(new ParseLine(CA!.PL_Cut, PList, Orders!.CutMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Cut);
        PLLEng.Add(new ParseLine(CA!.PL_Cut, PList, Orders!.CutMC, false));

        // verknoten
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bind);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bind);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Knoten!.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        /*
        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Knoten!.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));
        */

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Knoten!.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        // verknoten Person
        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Knoten!.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie_P, PList, Orders!.TieP));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Knoten!.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie_P, PList, Orders!.TieP));

        PList.AddVerb(CA!.Verb_Tie);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie_P, PList, Orders!.TieP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie_P, PList, Orders!.TieP));

        // verknoten
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Knoten.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Knoten.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.Tie));

        // verknoten
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_TieSolo, PList, Orders!.TieSolo));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Knoten.ID);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_TieSolo, PList, Orders!.TieSolo));

        // verknoten MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddPrep(CB!.Prep_nach);
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.TieMC, false));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Knoten.ID);
        PList.AddPrep(CB!.Prep_at);
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.TieMC, false));


        /*
        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Knoten);
        PList.AddPrep(CB!.Prep_nach);
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.TieMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tie);
        PList.AddPrep(CB!.Prep_at);
        PLLEng.Add(new ParseLine(CA!.PL_Tie, PList, Orders!.TieMC, false));
        */

        // angeln
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fish);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Fish, PList, Orders!.Fish));

        // angeln mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fish);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Fish, PList, Orders!.FishWith));

        // angeln mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fish);
        PList.AddPrep(CB!.Prep_with);
        PLLEng.Add(new ParseLine(CA!.PL_Fish, PList, Orders!.FishWithMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fish);
        PLLEng.Add(new ParseLine(CA!.PL_Fish, PList, Orders!.FishWithMC, false));

        // Streue
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spread);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_EnlightW, PList, Orders!.SpreadOn));

        // Beleuchte
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Enlight);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_LightW, PList, Orders!.EnlightenW));

        // entzünde
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Light);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_LightW, PList, Orders!.LightW));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Licht!.ID);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_LightW, PList, Orders!.LightW));

        // entzünde
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Light);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Light, PList, Orders!.Light));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Licht!.ID);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Light, PList, Orders!.Light));

        // entzünde MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Light);
        PLLEng.Add(new ParseLine(CA!.PL_Light, PList, Orders!.LightMC, false));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Licht.ID);
        PLLEng.Add(new ParseLine(CA!.PL_Light, PList, Orders!.LightMC, false));

        // löschen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Extinguish);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Extinguish, PList, Orders!.Extinguish));

        // löschen MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Extinguish);
        PLLEng.Add(new ParseLine(CA!.PL_Extinguish, PList, Orders!.ExtinguishMC, false));

        // greifen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Grab);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Grab, PList, Orders!.Grab));

        // greifen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Grab);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_GrabSolo, PList, Orders!.GrabSolo));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Grab, PList, Orders!.Grab));

        // greifen MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Grab);
        PList.AddPrep(CB!.Prep_with);
        PLLEng.Add(new ParseLine(CA!.PL_Grab, PList, Orders!.GrabMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CB!.Verb_Take);
        PList.AddPrep(CB!.Prep_with);
        PLLEng.Add(new ParseLine(CA!.PL_Grab, PList, Orders!.GrabMC, false));


        // esse
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Eat);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Eat, PList, Orders!.Eat));

        // esse MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Eat);
        PLLEng.Add(new ParseLine(CA!.PL_Eat, PList, Orders!.EatMC, false));

        // esse Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Eat);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Eat_P, PList, Orders!.EatP));


        // verkaufen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sell);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Sell, PList, Orders!.Sell));

        // verkaufen an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sell);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_SellTo, PList, Orders!.SellTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sell);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_SellTo, PList, Orders!.SellTo));

        // verkaufen an MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sell);
        PList.AddPrep(CB!.Prep_nach);
        PLLEng.Add(new ParseLine(CA!.PL_SellTo, PList, Orders!.SellToMC));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sell);
        PList.AddPrep(CB!.Prep_at);
        PLLEng.Add(new ParseLine(CA!.PL_SellTo, PList, Orders!.SellToMC));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sell);
        PLLEng.Add(new ParseLine(CA!.PL_SellTo, PList, Orders!.SellToMC, false));

        // pflücken
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pick);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pick, PList, Orders!.Pick));

        // pflücken MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pick);
        PLLEng.Add(new ParseLine(CA!.PL_Pick, PList, Orders!.PickMC, false));


        // pflücken in 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pick);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pick_W, PList, Orders!.PickW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pick);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pick_W, PList, Orders!.PickW));

        // pflücken in MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pick);
        PList.AddPrep(CB!.Prep_in);
        PLLEng.Add(new ParseLine(CA!.PL_Pick_W, PList, Orders!.PickWMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pick);
        PList.AddPrep(CB!.Prep_into);
        PLLEng.Add(new ParseLine(CA!.PL_Pick_W, PList, Orders!.PickWMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pick);
        PLLEng.Add(new ParseLine(CA!.PL_Pick_W, PList, Orders!.PickWMC, false));

        // fange
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Catch);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_CatchP, PList, Orders!.CatchP));

        // füllen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fill);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Fill, PList, Orders!.FillW));

        // füllen in
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fill);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Fill2, PList, Orders!.FillIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fill);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Fill2, PList, Orders!.FillIn));

        // füllen 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fill);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Fill_Solo, PList, Orders!.FillSolo));

        // füllen MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fill);
        PList.AddPrep(CB!.Prep_with);
        PLLEng.Add(new ParseLine(CA!.PL_Fill, PList, Orders!.FillWMC, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fill);
        PLLEng.Add(new ParseLine(CA!.PL_Fill, PList, Orders!.FillWMC, false));

        // stopfe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Stuff);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Stuff, PList, Orders!.StuffIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Stuff);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Stuff, PList, Orders!.StuffIn));

        // trinken
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Drink);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Drink, PList, Orders!.Drink));

        // trinke MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Drink);
        PLLEng.Add(new ParseLine(CA!.PL_Drink, PList, Orders!.DrinkMC, false));

        PList = new ParseTokenList();
        PList.AddNoun( CA!.Noun_Drink!.ID );
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Drink, PList, Orders!.Drink));

        // trinken aus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Drink);
        PList.AddPrep(CB!.Prep_from);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_DrinkFrom, PList, Orders!.DrinkFrom));

        // berühre
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Touch);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Touch, PList, Orders!.Touch));

        // berühre MC
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Touch);
        PLLEng.Add(new ParseLine(CA!.PL_Touch, PList, Orders!.TouchMC, false));

        // berühre Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Touch);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Touch, PList, Orders!.TouchP));

        // berühre Person mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Touch);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Touch, PList, Orders!.TouchPW));


        // Klopfe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Knock);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Knock, PList, Orders!.KnockOn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Knock);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Knock2, PList, Orders!.KnockOn));

        // Klopfe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Knock);
        PLLEng.Add(new ParseLine(CA!.PL_Knock_Solo, PList, Orders!.KnockSolo));

        // spucke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spit);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Spit, PList, Orders!.SpitOn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spit);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Spit, PList, Orders!.SpitOn));

        // spucke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spit);
        PList.AddPrep(CB!.Prep_on);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_SpitP, PList, Orders!.SpitOnP));

        // spucke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spit);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_SpitP, PList, Orders!.SpitOnP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spit);
        PList.AddVerb(CB!.Verb_D);
        PLLEng.Add(new ParseLine(CA!.PL_SpitDown, PList, Orders!.SpitDown));

        // lausche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Listen);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Listen, PList, Orders!.ListenOn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Listen);
        PList.AddPrep(CB!.Prep_to);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Listen, PList, Orders!.ListenOn));

        // lauschen allgemein
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Listen);
        PLLEng.Add(new ParseLine(CA!.PL_Listen_Solo, PList, Orders!.Listen));

        // lauschen Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Listen);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Listen_Person, PList, Orders!.ListenToP));

        // lauschen Topic
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Listen);
        PList.AddTopic();
        PLLEng.Add(new ParseLine(CA!.PL_Listen_Topic, PList, Orders!.ListenToT));

        // verbinde 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_AttachTo, PList, Orders!.AttachTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_AttachTo, PList, Orders!.AttachTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_AttachTo, PList, Orders!.AttachTo));

        /*
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_AttachTo, PList, Orders!.AttachTo));
        */

        // verbinde 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_AttachSolo, PList, Orders!.AttachSolo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach2);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_AttachTo, PList, Orders!.AttachTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach2);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_AttachTo, PList, Orders!.AttachTo));

        /*
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach2);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_AttachTo, PList, Orders!.AttachTo));
        */

        // verbinde 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Attach2);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_AttachSolo, PList, Orders!.AttachSolo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hang);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_HangTo, PList, Orders!.HangTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hang);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_HangTo, PList, Orders!.HangTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hang);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_HangSolo, PList, Orders!.HangSolo));

        // lausche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Listen);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Listen, PList, Orders!.ListenOn));


        // MC Item
        PList = new ParseTokenList();
        PList.AddItem();
        PLLEng.Add(new ParseLine(CB!.PL_MC_Item, PList, Orders!.MCItem, false));

        // MC Person
        PList = new ParseTokenList();
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CB!.PL_MC_Person, PList, Orders!.MCPerson, false));

        // tunke 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Dip, PList, Orders!.Dip));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Dip, PList, Orders!.Dip));

        // kippe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tip_Solo, PList, Orders!.TipSolo));

        // kippe auf
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tip, PList, Orders!.Tip));

        // kippe in
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tip_In, PList, Orders!.TipIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tip_In, PList, Orders!.TipIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_over);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tip_In, PList, Orders!.TipIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_upon);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tip_In, PList, Orders!.TipIn));

        // kippe auf Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Tip, PList, Orders!.TipP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_over);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Tip, PList, Orders!.TipP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_upon);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Tip, PList, Orders!.TipP));

        // gieße
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Water);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pour, PList, Orders!.Water));

        // gieße mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Water);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pour2, PList, Orders!.WaterW));

        // gieße on
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Water);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pour2, PList, Orders!.WaterWOn));

        // gieße on
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Water);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Pour2, PList, Orders!.TipP));

        // gieße in
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Water);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pour2, PList, Orders!.WaterWIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Water);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pour2, PList, Orders!.WaterWIn));

        // verhafte
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Arrest);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Arrest, PList, Orders!.Arrest));

        // verhafte mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Arrest);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_ArrestW, PList, Orders!.ArrestW));

        // meditiere
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Meditate);
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Meditate, PList, Orders!.Meditate));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Meditate);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Meditate, PList, Orders!.Meditate));

        // meditiere
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Meditate);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Meditate, PList, Orders!.Meditate));

        // meditiere solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Meditate);
        PLLEng.Add(new ParseLine(CA!.PL_Meditate_Solo, PList, Orders!.MeditateSolo));

        // drücke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Press);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Press, PList, Orders!.Press));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Press);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Press, PList, Orders!.Press));

        // drücke
        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Ring!.ID);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Ring, PList, Orders!.Ring));

        // drücke in 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Press);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Press_In, PList, Orders!.PressIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Press);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Press_In, PList, Orders!.PressIn));

        // drücke auf 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Press);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Press_On, PList, Orders!.PressOn));

        // steche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Puncture);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Puncture, PList, Orders!.Puncture));

        // steche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Puncture);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_PunctureReverse, PList, Orders!.PunctureReverse));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Puncture);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_PunctureReverse, PList, Orders!.PunctureReverse));

        // steche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Puncture);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_PunctureSolo, PList, Orders!.PunctureSolo));

        // fotografiere
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Photograph);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Photograph, PList, Orders!.PhotographP));

        // fotografiere
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Photograph);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Photograph2, PList, Orders!.PhotographP2));

        // schmiere an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Smear, PList, Orders!.Smear));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Smear, PList, Orders!.Smear));

        // schmiere auf
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Smear2, PList, Orders!.SmearOn));

        // schmiere an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Smear, PList, Orders!.SmearP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Smear, PList, Orders!.SmearP));

        // schmiere auf
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Smear2, PList, Orders!.SmearOnP));

        // schmiere
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_SmearSolo, PList, Orders!.SmearSolo));

        // beschmiere mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smear2);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_SmearReverse, PList, Orders!.SmearReverseP));

        // tröte
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Blow);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Blow, PList, Orders!.Blow));

        // blase an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Blow);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_BlowWith, PList, Orders!.BlowWith));

        // Vergleichen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Compare);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Compare, PList, Orders!.Compare));

        // vergifte
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poison);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Poison, PList, Orders!.Poison));

        // vergifte solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poison);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_PoisonSolo, PList, Orders!.PoisonSolo));

        // Krieche in
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Creep);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Creep, PList, Orders!.Creep));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Creep);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Creep, PList, Orders!.Creep));

        // Follow
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Follow);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Follow, PList, Orders!.Follow));

        // Jump
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Jump, PList, Orders!.Jump));

        // Jump in
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Jump_In, PList, Orders!.JumpIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Jump_In, PList, Orders!.JumpIn));

        // Jump auf
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Jump_On, PList, Orders!.JumpOn));

        // Jump durch
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PList.AddPrep(CB!.Prep_through);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Jump_Through, PList, Orders!.JumpThrough));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PList.AddPrep(CB!.Prep_out);
        PList.AddPrep(CB!.Prep_of);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Jump_Through, PList, Orders!.JumpThrough));

        // Turn
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Turn);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Turn, PList, Orders!.Turn));

        // rühre mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Mix, PList, Orders!.MixW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_MixReverse, PList, Orders!.MixWReverse));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_MixReverse, PList, Orders!.MixWReverse));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_MixIn, PList, Orders!.MixIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_MixIn, PList, Orders!.MixIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_MixIn, PList, Orders!.MixIn));

        // rühre Solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Mix);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_MixSolo, PList, Orders!.MixSolo));

        // Pluck
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pluck);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pluck, PList, Orders!.Pluck));

        // Suck
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Suck);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Suck, PList, Orders!.Suck));

        // Suck
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Suck);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Suck2, PList, Orders!.Suck));

        // Sit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sit);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Sit1, PList, Orders!.Sit));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sit);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Sit2, PList, Orders!.Sit));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sit);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Sit3, PList, Orders!.SitP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sit);
        PList.AddPerson();
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Sit4, PList, Orders!.SitP));

        // Liege
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lay);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Lay1, PList, Orders!.Lay));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lay);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Lay2, PList, Orders!.Lay));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lay);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Lay3, PList, Orders!.LayP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lay);
        PList.AddPerson();
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Lay4, PList, Orders!.LayP));

        // Zerbrösel
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Crumble);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Crumble, PList, Orders!.CrumbleW));

        // Zerbrösel
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Crumble);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Crumble_in, PList, Orders!.CrumbleIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Crumble);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Crumble_in, PList, Orders!.CrumbleIn));

        // Lasse x stehen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Abandon);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Abandon, PList, Orders!.Abandon));

        // Küsse person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Kiss);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Kiss_P, PList, Orders!.KissP));

        // Beten
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pray);
        PLLEng.Add(new ParseLine(CA!.PL_Pray, PList, Orders!.Pray));

        // Biegen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bend);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Bend, PList, Orders!.Bend));

        // Scroll
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Scroll);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Scroll, PList, Orders!.Scroll));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Scroll);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Scroll, PList, Orders!.Scroll));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Scroll);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Scroll, PList, Orders!.Scroll));

        // Leverage
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Leverage);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Leverage, PList, Orders!.Leverage));

        // Count
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Count);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Count, PList, Orders!.Count));

        // Breath
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Breath);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Breath, PList, Orders!.Breath));

        // Make
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Turn);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Make_On, PList, Orders!.MakeOn));

        // Make
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Turn);
        PList.AddPrep(CB!.Prep_off);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Make_Off, PList, Orders!.MakeOff));

        // Sprühe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spray);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Spray, PList, Orders!.SprayOn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spray);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Spray_Solo, PList, Orders!.SpraySolo));

        // Tausche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Exchange);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Exchange, PList, Orders!.Exchange));

        // Tausche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Exchange);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_for);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Exchange, PList, Orders!.Exchange));

        // Tausche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Exchange);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_ExchangeSolo, PList, Orders!.ExchangeSolo));

        // Binde x los
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Untie);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Free, PList, Orders!.Untighten));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Untie);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with );
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Free, PList, Orders!.UntightenW ));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Untie);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Free, PList, Orders!.Free));

        // befreie x
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Free);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Free, PList, Orders!.Free));


        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hold);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_PlaceTo, PList, Orders!.PlaceTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hold);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_PlaceTo, PList, Orders!.PlaceTo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hold);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_PlaceToP, PList, Orders!.PlaceToP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hold);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_PlaceToP, PList, Orders!.PlaceToP));

        // Kneife mit
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pinch);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pinch, PList, Orders!.PinchW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pinch);
        PList.AddPrep(CB!.Prep_off);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pinch, PList, Orders!.PinchW));

        // begrabe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bury);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_BuryP, PList, Orders!.BuryP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bury);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_BuryPSolo, PList, Orders!.BuryPSolo));

        // Töte
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Toete);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Kill, PList, Orders!.Kill));

        // Töte mit 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Toete);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_KillW, PList, Orders!.KillW));

        // Tickle
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Kitzle);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Tickle, PList, Orders!.Tickle));

        // Tickle W
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Kitzle);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_TickleW, PList, Orders!.TickleW));

        // Fuck
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Bumse);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Fuck, PList, Orders!.Fuck));

        // Beat
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Schlage);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Beat, PList, Orders!.Beat));

        // Beat W
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Schlage);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_BeatW, PList, Orders!.BeatW));

        // Pet
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Streichle);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Pet, PList, Orders!.Pet));

        // Cuddle
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Kuschle);
        PList.AddPrep(CB!.Prep_with);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Cuddle, PList, Orders!.Cuddle));

        // Joggle
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Joggle);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Joggle, PList, Orders!.Joggle));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Joggle);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Joggle, PList, Orders!.Joggle));

        // Sleep Solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sleep);
        PLLEng.Add(new ParseLine(CA!.PL_Sleep3, PList, Orders!.SleepSolo));

        // Sleep
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sleep);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Sleep, PList, Orders!.Sleep));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sleep);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Sleep, PList, Orders!.Sleep));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sleep);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Sleep2, PList, Orders!.Sleep));

        // Entfache
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spark);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Spark, PList, Orders!.Spark));

        // Entfache Solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Spark);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Spark_Solo, PList, Orders!.SparkSolo));

        // verlasse
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Leave);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Leave, PList, Orders!.Leave));

        // verlasse solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Leave);
        PLLEng.Add(new ParseLine(CA!.PL_Leave, PList, Orders!.LeaveSolo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Leave2);
        PLLEng.Add(new ParseLine(CA!.PL_Leave, PList, Orders!.LeaveSolo));

        // Determine
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Determine);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Determine, PList, Orders!.DetermineW));

        // Determine Solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Determine);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Determine_Solo, PList, Orders!.DetermineSolo));

        // Remove
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Remove);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Remove, PList, Orders!.Remove));

        // Clean
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Clean);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Clean, PList, Orders!.CleanIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Clean);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Clean, PList, Orders!.CleanIn));


        // Clean
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Clean);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Clean_Solo, PList, Orders!.CleanSolo));

        // Clean with
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Clean);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Clean_W, PList, Orders!.CleanW));

        // Clean Person with
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Clean);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Clean_W, PList, Orders!.CleanPW));

        // Split
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Split);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Split, PList, Orders!.Split));

        // wickle
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wrap);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_around);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Wrap, PList, Orders!.WrapP));

        // wickle
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wrap);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Wrap2, PList, Orders!.WrapP2));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wrap);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Wrap2, PList, Orders!.WrapP2));

        // wickle Solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wrap);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Wrap_Solo, PList, Orders!.WrapSolo));

        // bemale Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Paint);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Paint, PList, Orders!.PaintP));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Farbe!.ID);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Paint, PList, Orders!.PaintP));

        // bemale Person solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Paint);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Paint_Solo, PList, Orders!.PaintSolo));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Farbe!.ID);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Paint_Solo, PList, Orders!.PaintSolo));

        // Trage/wear
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wear);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Wear, PList, Orders!.Wear));

        // Search
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Search, PList, Orders!.Search));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search2);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Search, PList, Orders!.Search));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search2);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Search, PList, Orders!.Search));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_SearchW, PList, Orders!.SearchW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search2);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_SearchW, PList, Orders!.SearchW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search2);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_SearchW, PList, Orders!.SearchW));

        // Search Person
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Search, PList, Orders!.SearchP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search2);
        PList.AddPrep(CB!.Prep_in);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Search, PList, Orders!.SearchP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_SearchW, PList, Orders!.SearchWP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Search2);
        PList.AddPrep(CB!.Prep_in);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_SearchW, PList, Orders!.SearchWP));

        // Poke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poke);
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Poke, PList, Orders!.Poke));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poke);
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Poke, PList, Orders!.Poke));

        // Poke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poke);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Poke, PList, Orders!.Poke));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poke);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Poke, PList, Orders!.Poke));

        // Poke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poke);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Poke, PList, Orders!.PokeRev));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Poke);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Poke, PList, Orders!.PokeRev));

        // Dig
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dig);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Dig, PList, Orders!.Dig));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dig);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Dig, PList, Orders!.Dig));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dig);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Dig, PList, Orders!.Dig));

        // Wake
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wake);
        PList.AddPerson();
        PList.AddVerb(CB!.Verb_U);
        PLLEng.Add(new ParseLine(CA!.PL_Wake, PList, Orders!.WakeP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wake);
        PList.AddVerb(CB!.Verb_U);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Wake, PList, Orders!.WakeP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wake);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Wake, PList, Orders!.WakeP));

        // Ruf
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Shout);
        PLLEng.Add(new ParseLine(CA!.PL_Shout, PList, Orders!.Shout));

        // Spring
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Jump);
        PLLEng.Add(new ParseLine(CA!.PL_Jump, PList, Orders!.JumpSolo));

        // rutsche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Slide);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Slide, PList, Orders!.Slide));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Slide);
        PList.AddVerb(CB!.Verb_D);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Slide, PList, Orders!.Slide));

        // Accede
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Accede);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Accede, PList, Orders!.Accede));

        // Wer bin ich?
        PList = new ParseTokenList();
        PList.AddPrep(CB!.Prep_Wer);
        PList.AddVerb(CA!.Verb_Be);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Be, PList, Orders!.Be));

        // Reparieren
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Repair);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Repair, PList, Orders!.Repair));

        // Sortieren
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sort);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Sort, PList, Orders!.Sort));

        // Gestehe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Confess);
        PLLEng.Add(new ParseLine(CA!.PL_Confess, PList, Orders!.Confess));

        // Streiche über
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Stroke);
        PList.AddPrep(CB!.Prep_over);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Stroke, PList, Orders!.Stroke));

        // Schalte aus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Switch);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_off);
        PLLEng.Add(new ParseLine(CA!.PL_SwitchOff, PList, Orders!.SwitchOff));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Switch);
        PList.AddPrep(CB!.Prep_off);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_SwitchOff, PList, Orders!.SwitchOff));

        // Schalte ein
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Switch);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_on);
        PLLEng.Add(new ParseLine(CA!.PL_SwitchOn, PList, Orders!.SwitchOn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Switch);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_SwitchOn, PList, Orders!.SwitchOn));

        // Heben
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lift);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Lift, PList, Orders!.Lift));

        // Wischen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wipe);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Wipe, PList, Orders!.Wipe));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wipe);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_WipeW, PList, Orders!.WipeW));

        // Wischen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wipe);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Wipe, PList, Orders!.WipeP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Wipe);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_mit);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_WipeW, PList, Orders!.WipeWP));

        // Ausgänge
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Exits);
        PLLEng.Add(new ParseLine(CA!.PL_Exits, PList, Orders!.Exits));
        // 
        // bestehlen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Steal);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_StealP, PList, Orders!.StealP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Steal);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_from);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_StealWP, PList, Orders!.StealWP));

        // gleite über
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Slide);
        PList.AddPrep(CB!.Prep_over);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Slide, PList, Orders!.Slide));

        // Score
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Score);
        PLLEng.Add(new ParseLine(CA!.PL_Score, PList, Orders!.Score));

        // Destroy
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Destroy);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Destroy, PList, Orders!.Destroy));

        // Chop
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Chop);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Chop, PList, Orders!.Chop));

        // Chop
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Chop);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_ChopW, PList, Orders!.ChopW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Chop);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_ChopW, PList, Orders!.ChopW));

        // Chop
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Chop);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_ChopW, PList, Orders!.ChopW));

        // Plunge
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Plunge);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Plunge, PList, Orders!.PlungeIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Plunge);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Plunge, PList, Orders!.PlungeIn));

        // Plunge aus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Plunge);
        PList.AddPrep(CB!.Prep_out);
        PList.AddPrep(CB!.Prep_of);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Plunge_Out, PList, Orders!.PlungeOut));

        // Roll in 
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Roll);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_RollIn, PList, Orders!.RollIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Roll);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_RollIn, PList, Orders!.RollIn));

        // Roll  
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Roll);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Roll_Solo, PList, Orders!.RollSolo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Roll);
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Roll_Solo, PList, Orders!.RollSolo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Roll);
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Roll_Solo, PList, Orders!.RollSolo));

        // Demolish
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Demolish);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Demolish, PList, Orders!.Demolish));

        // DemolishW
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Demolish);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Demolish, PList, Orders!.DemolishW));

        // Crack
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Crack);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Demolish, PList, Orders!.Demolish));

        // Glue To
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Glue);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_GlueTo, PList, Orders!.GlueTo));

        // Heat
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Heat);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Heat, PList, Orders!.Heat));

        // HeatW
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Heat);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_HeatW, PList, Orders!.HeatW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Heat);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_HeatW, PList, Orders!.HeatW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Heat);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_HeatW, PList, Orders!.HeatW));

        // Pulverize
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pulverize);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pulverize, PList, Orders!.Pulverize));

        // Pulverize with
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pulverize);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pulverize_W, PList, Orders!.PulverizeW));

        // Pulverize in
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pulverize);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pulverize_W, PList, Orders!.PulverizeW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Pulverize);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Pulverize_W, PList, Orders!.PulverizeW));

        // Tidy
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tidy);
        PList.AddVerb(CB!.Verb_U);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tidy, PList, Orders!.Tidy));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tidy);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tidy, PList, Orders!.Tidy));

        // Brush
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Brush);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_BrushW, PList, Orders!.BrushW));


        // Tippe
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Type);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Type, PList, Orders!.Type));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Type);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Type, PList, Orders!.Type));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schreib!.ID);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Type, PList, Orders!.Type));

        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Schreib!.ID);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Type, PList, Orders!.Type));

        // Fry/ Brate
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fry);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Fry, PList, Orders!.FrySolo));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fry);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Fry, PList, Orders!.FryIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fry);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Fry, PList, Orders!.FryIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Fry);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Fry, PList, Orders!.FryIn));

        // Form
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Form);
        PList.AddTopic();
        PLLEng.Add(new ParseLine(CA!.PL_Form, PList, Orders!.Form));

        // Form aus
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Form);
        PList.AddTopic();
        PList.AddPrep(CB!.Prep_from);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_FormFrom, PList, Orders!.FormFrom));

        // Tanze/Dance
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dance);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Dance_Person, PList, Orders!.DanceWP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dance);
        PList.AddPrep(CB!.Prep_with);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Dance_Person, PList, Orders!.DanceWP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Dance);
        PLLEng.Add(new ParseLine(CA!.PL_Dance, PList, Orders!.Dance));

        // Hängen/hang
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hang);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Hang, PList, Orders!.Hang));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hang);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Hang2, PList, Orders!.Hang2));

        // Schwinge/swing
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Swing);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Swing, PList, Orders!.Swing));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Swing);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Swing, PList, Orders!.Swing));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Swing);
        PList.AddPrep(CB!.Prep_nach);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Swing2, PList, Orders!.Swing2));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Swing);
        PList.AddPrep(CB!.Prep_at);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Swing2, PList, Orders!.Swing2));

        // Store
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Store);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Store, PList, Orders!.Store));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Store);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Store, PList, Orders!.Store));

        // Umdrehen
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Turn);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_around);
        PLLEng.Add(new ParseLine(CA!.PL_Turn, PList, Orders!.TurnP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Turn);
        PList.AddPerson();
        PLLEng.Add(new ParseLine(CA!.PL_Turn, PList, Orders!.TurnP));


        // Singe solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sing);
        PLLEng.Add(new ParseLine(CA!.PL_SingSolo, PList, Orders!.SingSolo));

        // Singe solo
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Sing);
        PList.AddTopic();
        PLLEng.Add(new ParseLine(CA!.PL_Sing, PList, Orders!.Sing));

        // Lecke an
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Lick);
        PList.AddPrep(CB!.Prep_on);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Lick, PList, Orders!.Lick));

        // verstecke
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hide);
        PList.AddPerson();
        PList.AddPrep(CB!.Prep_behind);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Hide_P, PList, Orders!.HideP));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Hide);
        PList.AddPrep(CB!.Prep_behind);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Hide, PList, Orders!.Hide));

        // verbrenne
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Burn);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Burn_W, PList, Orders!.BurnW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Burn);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Burn, PList, Orders!.Burn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Burn);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_in);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Burn_In, PList, Orders!.BurnIn));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Burn);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_into);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Burn_In, PList, Orders!.BurnIn));

        // rauche
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Smoke);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Smoke, PList, Orders!.Smoke));

        // zerreiße
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Tear);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tear, PList, Orders!.Tear));

        // reiße ab
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Rip);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_Tear, PList, Orders!.RipOff));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Rip);
        PList.AddItem();
        PList.AddPrep(CB!.Prep_off);
        PLLEng.Add(new ParseLine(CA!.PL_Tear, PList, Orders!.RipOff));

        // Testwindow
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Testwindow);
        PLLEng.Add(new ParseLine(CA!.PL_Testwindow, PList, Orders!.Testwindow));

        // Brief
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Brief);
        PLLEng.Add(new ParseLine(CA!.PL_Brief, PList, Orders!.Brief));

        // Verbose
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Verbose);
        PLLEng.Add(new ParseLine(CA!.PL_Verbose, PList, Orders!.Verbose));

        // telefoniere
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Phone);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_PhoneW, PList, Orders!.PhoneW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Phone);
        PList.AddPrep(CB!.Prep_with);
        PList.AddItem();
        PLLEng.Add(new ParseLine(CA!.PL_PhoneW, PList, Orders!.PhoneW));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Phone);
        PLLEng.Add(new ParseLine(CA!.PL_Phone, PList, Orders!.Phone));

        // Anleitung
        PList = new ParseTokenList();
        PList.AddNoun(CA!.Noun_Manual!.ID);
        PLLEng.Add(new ParseLine(CA!.PL_Manual, PList, Orders!.Manual, false));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Credits);
        PLLEng.Add(new ParseLine(CA!.PL_Credits, PList, Orders!.Credits));

        // Grafik
        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddPrep(CB!.Prep_Stufe1);
        PLLEng.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationSmall));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddPrep(CB!.Prep_Stufe2);
        PLLEng.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationMediocre));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddPrep(CB!.Prep_Stufe3);
        PLLEng.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationLarge));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddAdj(CA.Adj_klein!.ID);
        PLLEng.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationSmall));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddAdj(CA.Adj_mittel!.ID);
        PLLEng.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationMediocre));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddAdj(CA.Adj_gross!.ID);
        PLLEng.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationLarge));


        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Illustration);
        PList.AddPrep(CB!.Prep_off);
        PLLEng.Add(new ParseLine(CA!.PL_Illustration, PList, Orders!.IllustrationOff));

        PList = new ParseTokenList();
        PList.AddVerb(CA!.Verb_Undo);
        PLLEng.Add(new ParseLine(CA!.PL_Undo, PList, Orders!.Undo));
        /*
                     // Schleudere nach
                     PList = new ParseTokenList();
                     PList.AddTopic(CA!.Nounverb_Schleuder);
                     PList.AddItem();
                     PList.AddPrep(CB!.Prep_nach);
                     PList.AddItem();
                     PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.Throw));

                     // Schleudere zu
                     PList = new ParseTokenList();
                     PList.AddTopic(CA!.Nounverb_Schleuder);
                     PList.AddItem();
                     PList.AddPrep(CB!.Prep_zu);
                     PList.AddItem();
                     PLL.Add(new ParseLine(CA!.PL_Throw, PList, Orders!.Throw));
                     */
    }

}