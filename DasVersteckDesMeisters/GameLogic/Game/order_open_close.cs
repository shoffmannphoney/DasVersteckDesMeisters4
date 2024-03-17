using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace GameCore;



public partial class Order: AbstractOrder
{

    public override bool  Open(Person PersonID, ParseTokenList PTL )
    {
        OrderFeedback of = new OrderFeedback();

        bool success = true;
        bool handled = false;

        of.Success = true;

        Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


        // Base
        if (!handled)
        {
            success = base.Open(PersonID, PTL);
            of.StoryOutput = true;
            of.Success = success;
            of.Handled = true;
            of.Action = true;
        }

        if ((success) && (item.GetStatus(CA!.iStatus_Counter_Door) > 0))
        {
            AdvGame!.CounterDoorOpen(item);
        }

        // Post
        if (success)
        {
        }

        if (handled)
            success = true;
        return (success);
    }

    public override bool  Close(Person PersonID, ParseTokenList PTL)
    {
        OrderFeedback of = new OrderFeedback();

        bool handled = false;

        Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

        // Pre
        // Base
        if (!handled)
        {

            handled = base.Close(PersonID, PTL);
            of.StoryOutput = false;
            of.Success = true;
            of.Handled = true;
            of.Action = true;
        }

        if ((handled) && (item.GetStatus(CA!.iStatus_Counter_Door) > 0))
        {
            AdvGame!.CounterDoorClose(item);
        }



        return (handled);
    }

    public override bool  OpenP(Person PersonID, ParseTokenList PTL)
    {
        bool success = true;

        Person person = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);


        // Pre
        // Base
        if (success)
            success = base.OpenP(PersonID, PTL);

        // Post
        return (success);
    }

    public override bool  CloseP(Person PersonID, ParseTokenList PTL)
    {
        bool success = true;

        Person person = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);

        // Pre
        // Base
        if (success)
            success = base.CloseP(PersonID, PTL);

        // Post
        return (success);
    }

}