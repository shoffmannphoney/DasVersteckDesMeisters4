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


        if( item == CA!.I05_Library_Door && CA.Status_Tuer_Bibliothek.Val == 0 )
        {
            AdvGame.StoryOutput(loca.Open_Library_Door_Locked);
            handled = true;
            success = false;
        }
        else if (item == CA!.I06_Door && CA.Status_Tuer_Schlafkammer.Val == 0)
        {
            AdvGame.StoryOutput(loca.Open_Sleepingroom_Door_Locked);
            handled = true;
            success = false;
        }
        else if (item == CA!.I07_Door && CA.Status_Tuer_Labor .Val == 0)
        {
            AdvGame.StoryOutput(loca.Open_Laboratory_Door_Locked);
            handled = true;
            success = false;
        }
        // Base
        if (!handled)
        {
            success = base.Open(PersonID, PTL);
            of.StoryOutput = true;
            of.Success = success;
            of.Handled = true;
            of.Action = true;
        }
        if (item == CA!.I10_Hatch)
        {
            Items.TransferItem(CA!.I10_Opening.ID, CB.LocType_On_Item, CA!.I10_Darkness_Machine.ID);
            AdvGame.StoryOutput(loca.Open_L10_Flap);
        }

        if ((success) && (item.GetStatus(CA!.iStatus_Counter_Door) > 0))
        {
            AdvGame!.CounterDoorOpen(item);
        }

        // Post
        if (success)
        {
            if (item == CA!.I04_Flap)
            {
                AdvGame.StoryOutput(loca.Open_L04_Flap);
                Items.TransferItem(CA.I04_Opening.ID, CB.LocType_Loc, CA.L04_Shabby_Little_Chamber);

            }
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

        if (item == CA!.I10_Hatch)
        {
            Items.TransferItem(CA!.I10_Opening.ID, CB.LocType_In_Item, CA!.I00_Nullbehaelter3.ID );
        }

        // Post
        if (handled)
        {
            if (item == CA!.I04_Flap)
            {
                AdvGame.StoryOutput(loca.Close_L04_Flap);
                Items.TransferItem(CA.I04_Opening.ID, CB.LocType_In_Item, CA.I00_Nullbehaelter2.ID);

            }
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


        if( person.ID == CA.Person_Knights_Armor.ID )
        {
            AdvGame.StoryOutput(loca.Open_Knights_Armor);

        }
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