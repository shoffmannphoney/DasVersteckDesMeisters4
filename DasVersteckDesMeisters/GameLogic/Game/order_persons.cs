
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;


using Phoney_MAUI.Model;

namespace GameCore;



public partial class Order: AbstractOrder
{

    public bool SayToP(Person PersonID, ParseTokenList PTL)
    {
        bool handled = false;
        Person person = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[2].WordID);

        if (!handled)
        {
            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_SayToP_Person_Eremitin_13619, person ));

            /*
            if (person!.ID == CA!.Person_Robot)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert("Der kleine Roboter starrte [RP:1,Nom] so verständnislos an, wie ein kleiner Roboter nur verständnislos schauen kann", PersonID ));
            }
            else 
            */
        }

        if (person == CA!.Person_Owl && CA!.Status_Eule_Klaue!.Val <= 0)
        {
            AdvGame!.StoryOutput(loca.Talk_Owl_Dead);
            handled = true;
        }
        else if (person == CA.Person_Knights_Armor && CA.Status_Ritterruestung_Klaue!.Val <= 0)
        {
            AdvGame!.StoryOutput(loca.Talk_Knights_Armor_Dead);
            handled = true;
        }
        else if (person == CA.Person_Knights_Armor && CA.Status_Ritterruestung_Klaue!.Val >= 1)
        {
            AdvGame!.SetScoreToken(CA!.Score_Erstes_Gespraech);
            GenericDialog(CA!.Person_Knights_Armor, KnightsArmorDialog);
            handled = true;
        }
        else if (person == CA.Person_Owl && CA!.Status_Eule_Klaue!.Val >= 1)
        {
            AdvGame!.SetScoreToken(CA!.Score_Erstes_Gespraech);
            GenericDialog(CA!.Person_Owl, OwlDialog);
            handled = true;
        }
        if (person == CA.Person_Librarian && CA!.Status_Skelett_Klaue!.Val <= 0)
        {
            AdvGame!.StoryOutput(loca.Talk_Skeleton_Dead);
            handled = true;
        }
        else if (person == CA.Person_Librarian && CA!.Status_Skelett_Klaue!.Val >= 1)
        {
            AdvGame!.SetScoreToken(CA!.Score_Erstes_Gespraech);
            GenericDialog(CA!.Person_Librarian, LibrarianDialog);
            handled = true;
        }
        if (person == CA.Person_Fish && CA!.Status_Fisch_Klaue!.Val <= 0)
        {
            AdvGame!.StoryOutput(loca.Talk_Fish_Dead);
            handled = true;
        }
        else if (person == CA.Person_Fish && CA!.Status_Fisch_Klaue!.Val >= 1)
        {
            AdvGame!.SetScoreToken(CA!.Score_Erstes_Gespraech);
            GenericDialog(CA!.Person_Fish, FishDialog);
            handled = true;
        }
        if (person == CA.Person_Parrot && CA!.Status_Papagei_Klaue!.Val <= 0)
        {
            AdvGame!.StoryOutput(loca.Talk_Parrot_Dead);
            handled = true;
        }
        if (person == CA.Person_Magpie && CA!.Status_Elster_Klaue!.Val <= 0)
        {
            AdvGame!.StoryOutput(loca.Talk_Magpie_Dead);
            handled = true;
        }
        else if (person == CA.Person_Magpie && CA!.Status_Elster_Klaue!.Val >= 1)
        {
            AdvGame!.SetScoreToken(CA!.Score_Erstes_Gespraech);
            GenericDialog(CA!.Person_Magpie, MagpieDialog);
            handled = true;
        }
        if (person == CA.Person_Parrot && CA!.Status_Papagei_Klaue!.Val >= 1)
        {
            AdvGame!.SetScoreToken(CA!.Score_Erstes_Gespraech);
            GenericDialog(CA!.Person_Parrot, ParrotDialog);
            handled = true;
        }
        if (person == CA.Person_Snake && CA!.Status_Schlange_Klaue!.Val <= 0)
        {
            AdvGame!.StoryOutput(loca.Talk_Snake_Dead);
            handled = true;
        }
        else if (person == CA.Person_Snake && CA!.Status_Schlange_Klaue!.Val >= 1)
        {
            AdvGame!.SetScoreToken(CA!.Score_Erstes_Gespraech);
            GenericDialog(CA!.Person_Snake, SnakeDialog);
            handled = true;
        }



        // Hier wird immer false zurückgegeben, denn zwischen Dialogauftakt und Start des Multiple Choice Menüs sollen keine Actions mehr angestoßen werden
        return (handled);
    }

    public bool ShowToP2(Person PersonID, ParseTokenList PTL)
    {
        Person person1 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[3].WordID);
        Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

        ParseTokenList PT = new ParseTokenList();
        PT.AddVerb(CB!.Verb_Show);
        PT.AddItem(item2);
        PT.AddPrep(CB!.Prep_an);
        PT.AddPerson(person1);

        return ShowToP(PersonID, PT);
    }

    public override bool  ShowToP(Person PersonID, ParseTokenList PTL)
    {
        bool handled = false;
        Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
        Person person2 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[3].WordID);

        // base
        if (!handled)
            handled = !base.GiveToP(PersonID, PTL);

        // Post

        return (handled);
    }

    public bool PleaFromP(Person PersonID, ParseTokenList PTL)
    {
        bool success = true;
        Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
        Person person2 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[3].WordID);

        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_PleaFromP_Person_Everyone_13758, PersonID, person2, item1!.ID ));

        /*
        else if (person2!.ID == CA!.Person_Robot)
        {
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, "Helfie schüttelte mechanisch den Kopf und sagt: \"Caritas-Modus konnte nicht geladen werden.\"");
            success = false;
        }
        */
        // base


        // Post

        return (success);
    }

    public bool DemandFromP(Person PersonID, ParseTokenList PTL)
    {
        bool success = true;
        Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
        Person person2 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[3].WordID);

        AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_DemandFromP_Person_Everyone_13762, PersonID, person2, item1!.ID ));


        return (success);
    }


    public bool GiveToP2(Person PersonID, ParseTokenList PTL)
    {
        Person person1 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[3].WordID);
        Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

        ParseTokenList PT = new ParseTokenList();
        PT.AddVerb(CB!.Verb_Give);
        PT.AddItem(item2);
        PT.AddPrep(CB!.Prep_an);
        PT.AddPerson(person1);

        return GiveToP(PersonID, PT);
    }

    public override bool  GiveToP(Person PersonID, ParseTokenList PTL)
    {
        bool handled = false;
        Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
        Person person2 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[3].WordID);

        if( item1.ID == CA!.I00_Cheese!.ID && person2.ID == CA!.Person_Magpie!.ID)
        {
            if( CA!.Status_Elster_Tauschintro!.Val == 0)
            {
                AdvGame!.StoryOutput(loca.Give_Magpie_Fail);
            }
            else
            {
                GenericDialog(CA!.Person_Magpie, MagpieDialog, 103, false, MagpieDialogCalc);

            }
            handled = true;
        }

        // Pre
        if (!handled)
        {
            AdvGame!.StoryOutput( Helper.Insert(loca.Order_GiveToP_Person_Proviantmeister_13869, PersonID, PersonID, person2, item1 ));

            handled = true;
        }

        // base
        if (!handled)
            handled = !base.GiveToP(PersonID, PTL);

        // Post

        return (handled);
    }

}