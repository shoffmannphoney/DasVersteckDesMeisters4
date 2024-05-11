using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace GameCore;



public partial class Order: AbstractOrder
{

    public bool GoBehind(Person PersonID, ParseTokenList PTL)
    {
        OrderFeedback of = new OrderFeedback();

        bool success = true;
        Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


        if (success == true)
        {
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_GoBehind_I2_34_Tresen_13349, item!.ID ));
            of.Success = false;
            of.StoryOutput = true;
            of.Action = true;
            of.Handled = true;
        }

        return (success);
    }

    public bool GoThrough(Person PersonID, ParseTokenList PTL)
    {
        OrderFeedback of = new OrderFeedback();
        bool success = true;
        Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


        if( item == CA!.I02_Door)
        {
            GoDir(PersonID, Co.DIR_N);
            of.Handled = true;
        }
        else if(item == CA!.I03_Door_Outside)
        {
            GoDir(PersonID, Co.DIR_S);
            of.Handled = true;

        }
        else if (item == CA!.I03_Door)
        {
            GoDir(PersonID, Co.DIR_E);
            of.Handled = true;

        }
        else if (item == CA!.I04_Door)
        {
            GoDir(PersonID, Co.DIR_W);
            of.Handled = true;

        }
        else if (item == CA!.I05_Library_Door)
        {
            GoDir(PersonID, Co.DIR_W);
            of.Handled = true;

        }
        else if (item == CA!.I05_Door)
        {
            GoDir(PersonID, Co.DIR_S);
            of.Handled = true;

        }
        else if (item == CA!.I06_Door_Wide)
        {
            GoDir(PersonID, Co.DIR_N);
            of.Handled = true;

        }
        else if (item == CA!.I06_Door_White)
        {
            GoDir(PersonID, Co.DIR_E);
            of.Handled = true;

        }
        else if (item == CA!.I06_Door_Red)
        {
            GoDir(PersonID, Co.DIR_W);
            of.Handled = true;

        }
        else if (item == CA!.I06_Door)
        {
            GoDir(PersonID, Co.DIR_S);
            of.Handled = true;

        }
        else if (item == CA!.I07_Door)
        {
            GoDir(PersonID, Co.DIR_E);
            of.Handled = true;

        }
        else if (item == CA!.I07_Door_Green)
        {
            GoDir(PersonID, Co.DIR_W);
            of.Handled = true;

        }
        else if (item == CA!.I07_Door_Blue)
        {
            GoDir(PersonID, Co.DIR_S);
            of.Handled = true;

        }
        else if (item == CA!.I08_Door_Green)
        {
            GoDir(PersonID, Co.DIR_E);
            of.Handled = true;

        }
        else if (item == CA!.I09_Library_Door)
        {
            GoDir(PersonID, Co.DIR_E);
            of.Handled = true;

        }
        else if (item == CA!.I10_Labor_Door)
        {
            GoDir(PersonID, Co.DIR_W);
            of.Handled = true;

        }
        else if (item == CA!.I11_Door_Blue)
        {
            GoDir(PersonID, Co.DIR_N);
            of.Handled = true;

        }
        else if (item == CA!.I12_Door)
        {
            GoDir(PersonID, Co.DIR_N);
            of.Handled = true;

        }
        else if (item == CA!.I13_Door_White)
        {
            GoDir(PersonID, Co.DIR_W);
            of.Handled = true;

        }
        else if (item == CA!.I14_Door_Red)
        {
            GoDir(PersonID, Co.DIR_E);
            of.Handled = true;

        }

        if (of.Handled == false)
        {
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_GoThrough_I2_47_Tuer_13360, item!.ID ));
            of.Success = success;
            of.StoryOutput = true;
            of.Action = true;
            of.Handled = true;
        }

        return (of.Handled);
    }

    public bool GoTo(Person PersonID, ParseTokenList PTL)
    {
        OrderFeedback of = new OrderFeedback();
        bool success = true;
        Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

        if (success == true)
        {
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_GoTo_I2_39_Wald_tief_13362, item!.ID ));
            of.Success = success;
            of.StoryOutput = true;
            of.Action = true;
            of.Handled = true;
        }

        return true;
    }

    public bool GoIn(Person PersonID, ParseTokenList PTL)
    {
        OrderFeedback of = new OrderFeedback();
        bool success = true;
        Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


        if (success == true)
        {
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_GoIn_IX_03_Spiegel_13373, item!.ID ));
            of.Success = success;
            of.StoryOutput = true;
            of.Action = true;
            of.Handled = true;
        }
        else
        {
            success = true;

        }

        return (success);
    }

    public bool GoDir(Person? PersonID, int Dir)
    {
        int CoDir = 0;

        if (Dir == 1) CoDir = Co.DIR_N;
        else if (Dir == 2) CoDir = Co.DIR_NE;
        else if (Dir == 3) CoDir = Co.DIR_E;
        else if (Dir == 4) CoDir = Co.DIR_SE;
        else if (Dir == 5) CoDir = Co.DIR_S;
        else if (Dir == 6) CoDir = Co.DIR_SW;
        else if (Dir == 7) CoDir = Co.DIR_W;
        else if (Dir == 8) CoDir = Co.DIR_NW;
        else if (Dir == 9) CoDir = Co.DIR_U;
        else if (Dir == 10) CoDir = Co.DIR_D;



        return Go(PersonID!, CoDir);
 
    }


    public override bool Go(Person? PersonID, int Dir)
    {
        OrderFeedback of = new OrderFeedback();

        bool karrenAvail = false;
        bool handled = true;
        bool success = true;
        int OldLoc = PersonID!.locationID;

        if ((Persons!.GetLoc(PersonID) == Co.CA!.L02_In_Front_Of_A_Hut ) && (Dir == Co.DIR_N) && (CA!.I02_Door!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I02_Door);
            Open(PersonID, PT);
            success = true;
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L03_In_The_Parlor ) && (Dir == Co.DIR_S) && (CA!.I03_Door_Outside!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I03_Door_Outside);
            Open(PersonID, PT);
            success = true;
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L03_In_The_Parlor) && (Dir == Co.DIR_E) && (CA!.I03_Door!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I03_Door);
            Open(PersonID, PT);
            success = true;
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L04_Shabby_Little_Chamber) && (Dir == Co.DIR_W) && (CA!.I04_Door!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I04_Door);
            Open(PersonID, PT);
            success = true;
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L05_Atrium) && (Dir == Co.DIR_W) && (CA!.I05_Library_Door!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I05_Library_Door);
            success = Open(PersonID, PT);
            if (CA!.I05_Library_Door.IsClosed == true)
                success = false;
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L05_Atrium) && (Dir == Co.DIR_S) && (CA!.I05_Door!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I05_Door);
            success = Open(PersonID, PT);
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L06_Long_Floor) && (Dir == Co.DIR_S) && (CA!.I06_Door!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I06_Door);
            success = Open(PersonID, PT);
            if (CA!.I06_Door.IsClosed == true)
                success = false;
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L06_Long_Floor) && (Dir == Co.DIR_N) && (CA!.I06_Door_Wide!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I06_Door_Wide);
            success = Open(PersonID, PT);
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L06_Long_Floor) && (Dir == Co.DIR_E) && (CA!.I06_Door_White.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I06_Door_White);
            success = Open(PersonID, PT);
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L06_Long_Floor) && (Dir == Co.DIR_W) && (CA!.I06_Door_Red!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I06_Door_Red);
            success = Open(PersonID, PT);
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L07_Lower_Floor ) && (Dir == Co.DIR_E) && (CA!.I07_Door!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I07_Door);
            success = Open(PersonID, PT);
            if (CA!.I07_Door.IsClosed == true)
                success = false;
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L07_Lower_Floor) && (Dir == Co.DIR_S) && (CA!.I07_Door_Blue!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I07_Door_Blue);
            success = Open(PersonID, PT);
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L07_Lower_Floor) && (Dir == Co.DIR_W) && (CA!.I07_Door_Green!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I07_Door_Green);
            success = Open(PersonID, PT);
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L08_Laundry_Room ) && (Dir == Co.DIR_E) && (CA!.I08_Door_Green!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I08_Door_Green);
            success = Open(PersonID, PT);
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L09_Library) && (Dir == Co.DIR_E) && (CA!.I09_Library_Door!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I09_Library_Door);
            success = Open(PersonID, PT);
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L10_Laboratory ) && (Dir == Co.DIR_W) && (CA!.I10_Labor_Door!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I10_Labor_Door);
            success = Open(PersonID, PT);
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L11_Storage_Room ) && (Dir == Co.DIR_S) && (CA!.I11_Door_Blue!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I11_Door_Blue);
            success = Open(PersonID, PT);
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L12_Sleeping_Room ) && (Dir == Co.DIR_N) && (CA!.I12_Door!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I12_Door);
            success = Open(PersonID, PT);
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L13_Kitchen ) && (Dir == Co.DIR_W) && (CA!.I13_Door_White!.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I13_Door_White);
            success = Open(PersonID, PT);
        }
        else if ((Persons!.GetLoc(PersonID) == Co.CA!.L14_Bathroom ) && (Dir == Co.DIR_E) && (CA!.I14_Door_Red !.IsClosed))
        {
            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CB!.Verb_Open);
            PT.AddItem(CA!.I14_Door_Red);
            success = Open(PersonID, PT);
        }




        // Noch immer aktuell, die Basisklasse aufzurufen? Tja, dann tun wir das.
        if (success)
        {
            handled = success = base.Go(PersonID, Dir);
            of.Success = success;
            of.Handled = true;
            of.Action = true;
        }

        // Nachträglich kann auch noch was ausgegeben werden, sogar abhängig vom Rückgabewert
        if (success)
        {
            SetLocDescriptions();
        }

        // return of.Action;
        return (handled);

    }


    public override bool  GoN(Person PersonID, ParseTokenList PTL)
    {
        return (Go(PersonID, Co.DIR_N));
    }

    public override bool  GoNE(Person PersonID, ParseTokenList PTL)
    {
        return (Go(PersonID, Co.DIR_NE));
    }

    public override bool  GoE(Person PersonID, ParseTokenList PTL)
    {
        return (Go(PersonID, Co.DIR_E));
    }

    public override bool  GoSE(Person PersonID, ParseTokenList PTL)
    {
        return (Go(PersonID, Co.DIR_SE));
    }

    public override bool  GoS(Person PersonID, ParseTokenList PTL)
    {
        return (Go(PersonID, Co.DIR_S));
    }

    public override bool  GoSW(Person PersonID, ParseTokenList PTL)
    {
        return (Go(PersonID, Co.DIR_SW));
    }

    public override bool  GoW(Person PersonID, ParseTokenList PTL)
    {
        return (Go(PersonID, Co.DIR_W));
    }

    public override bool  GoNW(Person PersonID, ParseTokenList PTL)
    {
        return (Go(PersonID, Co.DIR_NW));
    }

    public override bool  GoU(Person PersonID, ParseTokenList PTL)
    {
        return (Go(PersonID, Co.DIR_U));
    }

    public override bool  GoD(Person PersonID, ParseTokenList PTL)
    {
        return (Go(PersonID, Co.DIR_D));
    }

    public bool ClimbDownMC(Person PersonID, ParseTokenList PTL)
    {
        AdvGame!.DoMCCategory( loca.Order_ClimbDownMC_13520, loca.Order_ClimbDownMC_13521, A!.Cat_Climbdownable);
        return false;
    }

    public bool ClimbUpMC(Person PersonID, ParseTokenList PTL)
    {
        AdvGame!.DoMCCategory( loca.Order_ClimbUpMC_13522, loca.Order_ClimbUpMC_13523, A!.Cat_Climbupable);
        return false;
    }

    public bool GoThroughMC(Person PersonID, ParseTokenList PTL)
    {
        AdvGame!.DoMCCategory( loca.Order_GoThroughMC_13524, loca.Order_GoThroughMC_13525, A!.Cat_GoThroughable);
        return false;
    }

    public bool GoToMC(Person PersonID, ParseTokenList PTL)
    {
        AdvGame!.DoMCCategory( loca.Order_GoToMC_13526, loca.Order_GoToMC_13527, A!.Cat_GoToable);
        return false;
    }

    public bool EnterMC(Person PersonID, ParseTokenList PTL)
    {
        AdvGame!.DoMCCategory( loca.Order_EnterMC_13528, loca.Order_EnterMC_13529, A!.Cat_Enterable);
        return false;
    }

    public bool Enter(Person PersonID, ParseTokenList PTL)
    {
        bool success = false;
        Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

        if( item1.ID == CA.I02_Shed.ID)
        {
            GoDir(PersonID, Co.DIR_N);
            success = true;
        }

        // Hier Erfolgsoperationen auflisten und Success auf true setzen
        if (!success)
        {
            AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_Enter_I2_39_Wald_13537, item1!.ID ));
        }
        return (success);
    }

    public bool Leave(Person PersonID, ParseTokenList PTL)
    {
        bool success = false;
        Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


        // Hier Erfolgsoperationen auflisten und Success auf true setzen
        if (!success)
        {
            AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_Leave_I2_42_Golfplatz_13538, item1!.ID ));
        }
        return (success);
    }

    public bool LeaveSolo(Person PersonID, ParseTokenList PTL)
    {
        bool success = false;

        if( CA!.Person_I!.locationID == CA.L04_Shabby_Little_Chamber)
        {
            GoDir(PersonID, Co.DIR_W);
            success = true;
        }
        else if (CA!.Person_I!.locationID == CA.L05_Atrium)
        {
            GoDir(PersonID, Co.DIR_S);
            success = true;
        }
        else if (CA!.Person_I!.locationID == CA.L09_Library)
        {
            GoDir(PersonID, Co.DIR_E);
            success = true;
        }
        else if (CA!.Person_I!.locationID == CA.L08_Laundry_Room)
        {
            GoDir(PersonID, Co.DIR_E);
            success = true;
        }
        else if (CA!.Person_I!.locationID == CA.L10_Laboratory)
        {
            GoDir(PersonID, Co.DIR_W);
            success = true;
        }
        else if (CA!.Person_I!.locationID == CA.L11_Storage_Room)
        {
            GoDir(PersonID, Co.DIR_N);
            success = true;
        }
        else if (CA!.Person_I!.locationID == CA.L12_Sleeping_Room)
        {
            GoDir(PersonID, Co.DIR_N);
            success = true;
        }
        else if (CA!.Person_I!.locationID == CA.L13_Kitchen)
        {
            GoDir(PersonID, Co.DIR_W);
            success = true;
        }
        else if (CA!.Person_I!.locationID == CA.L14_Bathroom)
        {
            GoDir(PersonID, Co.DIR_E);
            success = true;
        }

        // Hier Erfolgsoperationen auflisten und Success auf true setzen
        if (!success)
        {
            AdvGame!.FeedbackOutput(PersonID, loca.Order_LeaveSolo_13539);
        }
        return (success);
    }

    public bool ClimbMC(Person PersonID, ParseTokenList PTL)
    {
        AdvGame!.DoMCCategory( loca.Order_ClimbMC_13540, loca.Order_ClimbMC_13541, A!.Cat_Climbable);
        return false;
    }
}