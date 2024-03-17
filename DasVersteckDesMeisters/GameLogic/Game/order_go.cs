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

        if (success)
        {
        }
        // Nachträglich kann auch noch was ausgegeben werden, sogar abhängig vom Rückgabewert
        if (success)
        {
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