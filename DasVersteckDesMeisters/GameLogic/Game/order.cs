using advtest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Text;

using Phoney_MAUI.Model;

// Ignores: 003

/*
 Helper.Insert("untersuche [It1,Nom]", itemID );
AdvGame!.StoryOutput( Helper.Insert("[Il1,Akk][VP:sein,2] nicht abschließbar.", item1!.ID, CA!.Person_3rdperson ));
mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert("[It1,Nom] betrachten", itemID ), idCt++));
mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert("[It1,Nom] betrachten", itemID ), idCt++, follower, null, 0, false, false, false, null,  Helper.Insert("untersuche [It1,Nom]", itemID )));
ListItems( Helper.Insert("[Plv1,Akk,sehen] ", PersonID ), PersonID, CB!.LocType_Person, PersonID!.ID, false, false);
AdvGame!.StoryOutput( Helper.Insert("[Il1,Akk] [VP:sein,2] nicht abschließbar.", item1!.ID, CA!.Person_3rdperson ));
                AdvGame!.StoryOutput( Helper.Insert("[Il1,Akk] [VP:sein,2] nicht abschließbar.", item1!.ID, CA!.Person_3rdperson ));
ListItems( Helper.Insert("[Plv1,Akk,sehen] ", PersonID ), PersonID, CB!.LocType_Person, PersonID!.ID, false, false);
AdvGame!.FeedbackOutput(PersonID,  Helper.Insert("[Pl1,Akk] [VP:sehen,2] keine Veranlassung, [It3,Dat] [It4,Nom] zu geben.", PersonID, PersonID, item2!.ID, item1!.ID ));
AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert("[Il1,Akk] [VI:sein,2] geschlossen, aber nicht abgeschlossen.", Item!.ID, Item!.ID ));
mcM.Add(new MCMenuEntry(CB!.MCE_Text, CA!.Person_I,  Helper.Insert("[It1,Nom] betrachten", itemID ), idCt++, follower, null, 0, false, false, false, null, "untersuche [It1,Nom] Helper.Insert(" , itemID )));
AdvGame!.StoryOutput( Helper.Insert("[Pt1,Nom] kratzte sich am Kopf und sagte nichts.", person ));
AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert("Ich weigerte mich einfach, [Pt1,Akk] anzuschauen.", person ));
*/

namespace GameCore
{

    [Serializable]

    public partial class Order: AbstractOrder
    {


        /*
        public Order(Adv? AdvGame, AdvData? A,VerbList? Verbs, ItemList? Items, PersonList? Persons, TopicList? Topics, locationList? locations, StatusList? Stats, ScoreList? Scores, GameCore.OrderList? OrderList, NounList? Nouns, AdjList? Adjs, PrepList? Preps, PronounList? Pronouns, FillList? Fills, ItemQueue? IQ, CoAdv? CA, List<LatestInput>? LI)
            : base(AdvGame, A, Verbs, Items, Persons, Topics, locations, Stats, Scores, OrderList, Nouns, Adjs, Preps, Pronouns, Fills, IQ, CA, LI)
        {
            
        }
        */

 


        public bool TakeMC( Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_TakeMC_015, loca.Order_TakeMC_016, A!.Cat_Takeable);
            return false;
        }

        public override bool  TakeAll(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();

            int ct = 0;
            foreach (Item it in Items!.List!.Values)
            {
                if (it.CanBeTaken && Items!.IsItemHere(it, Co.Range_Here) && !Items!.IsItemInv(it))
                {
                    ParseTokenList PT = new ParseTokenList();
                    PT.AddVerb(CB!.Verb_Take);
                    PT.AddItem(it);
                    Take(PersonID, PT);

                    ct++;
                }
            }

            of.Success = true;
            of.Handled = true;
            of.Action = true;
            of.StoryOutput = true;  

            if (ct > 0)
                return true;
            else
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_TakeAll_Person_Everyone_017, PersonID ));
                return true;
            }
        }


        public override bool Take(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();

            bool success = false;
            bool handled = false;

            // Nach den gesamten Prüfungen von Adv_PT ist garantiert, dass sich die Werte an dieser Stelle befinden.
            Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if( item == CA.I00_Claw)
            {
                AdvGame!.StoryOutput( loca.Take_Claw_Sign );
                handled = true;

            }
            if (item == CA.I08_Underpants )
            {
                AdvGame!.StoryOutput(loca.Take_Underwear );
                handled = true;

            }
            if (item == CA.I10_Metall_Tray && CA.Status_Schale_Befestigt.Val == 1 )
            {
                AdvGame!.StoryOutput(loca.Take_Schale);
                handled = true;

            }
            if (item == CA.I00_Coin && CA.Status_Coin_Taken.Val == 0 )
            {
                AdvGame!.StoryOutput(loca.Take_Coin);
                handled = true;

            }
            if (item == CA.I00_Supermagic_Powder && CA.I00_Supermagic_Powder.locationID == CA.I10_Giant_Mortar.ID )
            {
                AdvGame!.StoryOutput(loca.Take_Supermagic_Powder);
                Items.TransferItem(CA.I00_Supermagic_Powder.ID, CA.I00_Pouch.ID);
                handled = true;

            }
            if (item == CA!.I08_Clothes && CA.I08_Clothes.locationID == CA!.I08_Washing_Machine.ID)
            {
                AdvGame!.StoryOutput(loca.Take_Clothes);
                Items.TransferItem(CA!.I08_Clothes.ID, CA!.I08_Laundry_Basket.ID);
                handled = true;

            }

            if (!success && !handled)
            {
                success = base.Take(PersonID, PTL);
                of.Success = success;
                of.Handled = true;
                of.Action = true;
                of.StoryOutput = true;
            }


            // Die Flaglogik funktioniert wie folgt
            // success sagt aus, ob die aktuelle Aktion erfolgreich war. Immer wenn es einen StoryOutput gab, gilt die Aktion als erfolgreich
            // handled sagt aus, dass eine Aktion irgendwo in der Methode erfolgreich gehändelt wurde. Wenn nur ein FeedbackOutput erfolgt ist, gilt die Aktion nicht als gehändelt
            // Daraus folgt, dass eine gehändelte Aktion zugleich auch als success gewertet werden muss
            if (handled)
                success = true;
            return (success);
        }

        public override bool  TakeP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();

            bool success = true;

            // Nach den gesamten Prüfungen von Adv_PT ist garantiert, dass sich die Werte an dieser Stelle befinden.
            Person person = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);

            // Lokale Abfragen
            if (success)
                success = base.TakeP(PersonID, PTL);

            if (success)
            {
                of.Success = true;
                of.Handled = true;
                of.Action = true;
                of.StoryOutput = true;
            }
            return (success);
        }


        public bool SetPV( int pv )
        {
            return true; 
        }


        public bool ExamineThrough(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool success = false;
            bool handled = false;

            Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if ( !handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_ExamineThrough_IX_03_Spiegel_280, item ));
                success = true;
                handled = true;

                of.StoryOutput = true;
                of.Handled = true;
                of.Action = true;
            }

            return success;
        }

        public bool ExamineOut(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool success = false;
            bool handled = false;

            Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_ExamineOut_I1_08_Fenster_283, item ));

                of.FeedbackOutput = true;
                of.Handled = true;
            }

            return success;
        }


        public override bool  Examine(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool success = true;
            bool handled = true;

            Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);



            // Lokale Examine-Texte
            if (success)
                success = base.Examine(PersonID, PTL);

            of.StoryOutput = true;
            of.Success = true;
            of.Handled = true;
            of.Action = true;

            if (item == CA.I14_Tiles && CA.I14_Special_Tile.locationID != CA.L14_Bathroom && CA.I14_Opening.locationID != CA.L14_Bathroom)
            {
                AdvGame!.StoryOutput(loca.Examine_I14_Kacheln_Kachel );
                Items.TransferItem(CA.I14_Special_Tile.ID, CB.LocType_Loc, CA.L14_Bathroom);

            }
            if (item == CA.I14_Special_Tile)
            {
                Items.TransferItem(CA.I14_Special_Tile.ID, CA.I00_Nullbehaelter2.ID);
                Items.TransferItem(CA.I14_Opening.ID, CB.LocType_Loc, CA.L14_Bathroom);

            }
            if( item == CA.I00_Paper_Sheets)
            {
                CA.Status_Antwort_Lieblingstier.Val = 1;
            }
            if (item == CA.I08_Underpants)
            {
                CA.Status_Antwort_Unterwaesche.Val = 1;
            }
            if (item == CA.I06_Sign)
            {
                CA.Status_Tuer_Schlafkammer_angeschaut.Val = 1;
            }
            if( ( item == CA.I08_Well || item == CA.I08_Wooden_Cover ) && CA.I08_Wooden_Cover.locationID == CA.I08_Well.ID )
            {
                AdvGame!.StoryOutput(loca.Adv_I08_Well_2);
                
            }
            if( item == CA.I00_Coin && CA!.Status_Coin_Taken.Val == 0 )
            {
                AdvGame!.StoryOutput(loca.Adv_I00_Coin2);
            }

            return (handled);
        }

        public override bool  ExamineP(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();

            bool handled = false;

            Person person = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);

                // Lokale Examine-Texte
            if (!handled)
                handled = base.ExamineP(PersonID, PTL);

            of.StoryOutput = true;
            of.Success = true;
            of.Handled = true;
            of.Action = true;


            return (handled); 

        }


        public bool ItemFromInv( Item item1, Person PersonID )
        {
            bool canBeDropped = true;

            if( item1.IsDressed == true )
            {
                ParseTokenList PT = new ParseTokenList();
                PT.AddVerb(CA!.Verb_Draw );
                PT.AddItem(item1);
                PT.AddPrep(CB!.Prep_aus);

                Undress(PersonID, PT);
            }
            return (canBeDropped);

        }

        public override bool  Drop(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool success = true;
            bool handled = true;

            Item item = PTL.GetFirstItem()!; 

            // Vorab-Checks
            if (success)
            {
                if (item!.locationID != PersonID!.ID)
                {
                    Take(PersonID, PTL);
                    if (item.locationID != PersonID!.ID)
                        success = false;
                }

                if (success)
                    success = ItemFromInv(item, PersonID);
            }

            if (success)
                handled = base.Drop(PersonID, PTL);

            of.StoryOutput = true;
            of.Success = true;
            of.Handled = true;
            of.Action = true;

            // Post-Actions
            return (handled);
        }

        public override bool  location(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool success = true;

            if (success)
                success = base.location(PersonID, PTL);

            of.StoryOutput = true;
            of.Success = true;
            of.Handled = true;
            of.Action = true;

            if (success)
            {
            }
            return (success);
        }

        public override bool  Inventory(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();
            bool success = true;

            if (success)
                success = base.Inventory(PersonID, PTL);

            of.StoryOutput = true;
            of.Success = true;
            of.Handled = true;
            of.Action = true;

            if (success)
            {
            }
            return (success);
        }

        public  bool LayDown(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();

            bool success = true;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if( person1!.ID == CA!.Person_I!.ID)
                AdvGame!.StoryOutput( loca.Order_LayDown_Person_I_423);
            else
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_LayDown_Person_I_424, person1! ));


            of.StoryOutput = true;
            of.Success = true;
            of.Handled = true;
            of.Action = true;

            return (success);
        }


        public bool OpenUp(Person PersonID, ParseTokenList PTL)
        {
            OrderFeedback of = new OrderFeedback();

            bool success = true;
            // bool handled = false;

            of.Success = true;

            Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_OpenUp_425, item!.ID! ));
            return success;

        }


         public bool Ask(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            bool handled = false;
            Person person = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);
            Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[3].WordID);

            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Ask_Person_Everyone_426, PersonID, person!, item!.ID! ));


            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Ask_I1_09_Phiolen_429, person ));
            }
            return (success);
        }

        public bool AskPerson(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            bool handled = false;
            Person person = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);
            Person person2= PTL.GetSecondPerson()!; //  GetItemRef(Adv_PT[3].WordID);

            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone!,  Helper.Insert(loca.Order_AskPerson_Person_Everyone_430, PersonID, person!, person2 ));

            if( !handled )
            {
                AdvGame!.StoryOutput( Helper.Insert(loca.Order_AskPerson_Person_Everyone_431, person ));
            }

            return (success);
        }

        public bool AskTopic(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Person person = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);
            Topic topic = PTL.GetFirstTopic()!; //  GetTopicRef(Adv_PT[3].WordID);

            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_AskTopic_Person_Everyone_432, PersonID, person, topic!.ID ));

            return (success);
        }

        public void RestoreTemporaryDialog( MCMenu? mcM, string FuncName)
        {
            DelMCMSelection? Func = null;

            if (FuncName == "MCSelectionParser")
            {
                // Type t = GD.Adventure.GetType();
                // MethodInfo mi = t.GetMethod(FuncName);
                Func = AdvGame!.MCSelectionParser; //  (DelMCMSelection)DelMCMSelection.CreateDelegate(typeof(DelMCMSelection), AdvGame, mi);
            }
            /*
            else if ( FuncName == "MCSelection")
            {
                Func = AdvGame.UIS.MCM.MCSelection;
            }
            */
            else
            {
                Type t = this.GetType();
                MethodInfo? mi = t.GetMethod(FuncName);
                if (mi != null)
                {
                    Func = (DelMCMSelection)DelMCMSelection.CreateDelegate(typeof(DelMCMSelection), AdvGame!.Orders, mi!);
                }
            }

            AdvGame!.LastSpeaker = CA!.Person_I;

            mcM!.ResetSpeaker();
            
            mcM.AddSpeaker(CA!.Person_Self, Helper.Insert(loca.Order_GenericDialog_Person_Self_437, CA!.Person_Self!));

            int StartVal = MCID;


            temporaryMCMenu = mcM;

            persistentMCMenu = null;
            mcM.MCS = mcM.MenuShow();
            AdvGame.UIS!.MCM = mcM;
            mcM.MCS.SetCallbackSelection( Func );

            bool continued = mcM.Set(StartVal);

            if( Func == null )
            {
                Func = AdvGame.UIS.MCM.MCSelection;
            }

            if (continued)
                mcM.MCS.MCOutput(mcM, Func, false);

            // GenericDialog( Persons.Find( PersonID), )
        }


        // Wichtig: Diese Methode funktioniert mit StartVal nur dann sauber, wenn die StartFunc angegeben wird (oder es keine solche gibt)
        public void RestoreGeneratedDialog( int PersonID, string FuncName )
        {
             Type t = this.GetType();
            MethodInfo mi = t.GetMethod(FuncName)!;
            DelDialog Func = (DelDialog)DelDialog.CreateDelegate(typeof( DelDialog), AdvGame!.Orders, mi!);

            // System.Reflection.PropertyInfo? pi = typeof(CoBase).GetProperty(s, BindingFlags.Public | BindingFlags.Instance);
            // object o = pi!.GetValue(CB, null)!;

            Person? p = Persons!.Find(PersonID);
            MCMenu? mcM = p!.GetLatestDialog(Func!, this);
            AdvGame.LastSpeaker = p;

            mcM!.ResetSpeaker();
            if (p!= null)
            {
                mcM.AddSpeaker(CA!.Person_Self, Helper.Insert(loca.Order_GenericDialog_Person_Self_437, CA!.Person_Self!));
                mcM.AddSpeaker(p, Helper.Insert(loca.Order_GenericDialog_Person_Self_438, p));
            }
            else
            {
                mcM.AddSpeaker(CA!.Person_Self, "");
                mcM.AddSpeaker(p, "");
            }

            int StartVal = MCID;

            /*
            if (mcM.GetNewStart() >= 0)
                mcM.SetStartFromNew();
            else 
            if (StartVal >= 0)
            {
                mcM.SetStart(StartVal);
                if (mcM.FindID(StartVal)?.DeactivateAfterSelect == true)
                {
                    mcM!.FindID(StartVal)!.Hidden = MCMenuEntry.HiddenType.outdated;
                }
            }
            else
                mcM.SetStart(1);
            */


            persistentMCMenu = mcM;

            temporaryMCMenu = null;
            mcM.MCS = mcM.MenuShow();
            AdvGame.UIS!.MCM = mcM;

            bool continued = mcM.Set(StartVal);

            if (p != null)
                Persons!.Find(PersonID)!.SetLatestDialog(mcM, Func!);

            if (continued)
                mcM.MCS.MCOutput(mcM, mcM.MCSelection, false);

            // GenericDialog( Persons.Find( PersonID), )
        }
        public void GenericDialog( Person? PersonID, DelDialog? Func, int StartVal, bool AlwaysRestart = false, DelMCMenuEntry? StartFunc = null, string? talkString = null, bool doRecording = true)
        {
            MCMenu? mcM = null;

            // Wenn es kein Dialog ist, dann ist es ein Monolog
            if( PersonID == null )
            {
                PersonID = CA!.Person_I;
            }

            if (PersonID != null)
            {
                mcM = Persons!.Find(PersonID)!.GetLatestDialog(Func!, this);
                AdvGame!.LastSpeaker = PersonID;
            }
            if ((mcM == null) || (AlwaysRestart))
            {

                mcM = new MCMenu( Stats!, Persons!, CA!.Person_Self, A!, AdvGame!, true, 1, doRecording);
                List<int> tFollower;
                List<int> cFollower;
                // int idCt = 1;
                persistentMCMenu = mcM;
                MCMenuFunc = Func!.Method.Name.ToString();
                temporaryMCMenu = null;

                if (PersonID != null)
                {
                    if( talkString == null )
                    {
                        mcM.AddSpeaker(CA!.Person_Self, String.Format( loca.Order_GenericDialog_Person_Self_433, Persons!.GetPersonVerbLink(CA!.Person_Self!, Co.CASE_AKK, CB!.VT_sagen, A!.Tense) ) );
                        mcM.AddSpeaker(PersonID, String.Format(loca.Order_GenericDialog_Person_Self_434, Persons!.GetPersonVerbLink(PersonID, Co.CASE_AKK, CB!.VT_sagen, A!.Tense) ) );
                    }
                    else
                    {
                        mcM.AddSpeaker(CA!.Person_Self, String.Format(loca.Order_GenericDialog_Person_Self_435, Persons!.GetPersonNameLink(CA!.Person_Self!, Co.CASE_AKK ), talkString) );
                        mcM.AddSpeaker(PersonID, String.Format(loca.Order_GenericDialog_Person_Self_436, Persons!.GetPersonNameLink(PersonID!, Co.CASE_AKK ), talkString ) );

                    }
                }
                else
                {
                    mcM.AddSpeaker(CA!.Person_Self, "");
                    mcM.AddSpeaker(CA!.Person_Self, "");

                }
                tFollower = new List<int>();
                cFollower = new List<int>();

                Func!(mcM!, tFollower!, cFollower!);
            }
            else
            {
                mcM.ResetSpeaker();
                if (PersonID != null)
                {
                    mcM.AddSpeaker(CA!.Person_Self,  Helper.Insert(loca.Order_GenericDialog_Person_Self_437, CA!.Person_Self! ));
                    mcM.AddSpeaker(PersonID,  Helper.Insert(loca.Order_GenericDialog_Person_Self_438, PersonID ));
                }
                else
                {
                    mcM.AddSpeaker(CA!.Person_Self, "");
                    mcM.AddSpeaker(PersonID, "");

                }
            }

            if (mcM.GetNewStart() >= 0)
                mcM.SetStartFromNew();
            else if (StartVal >= 0)
            { 
                mcM.SetStart(StartVal);
                if( mcM.FindID(StartVal)?.DeactivateAfterSelect == true )
                {
                    mcM!.FindID(StartVal)!.Hidden = MCMenuEntry.HiddenType.outdated;
                }
            }
            else
                mcM.SetStart(1);


            persistentMCMenu = mcM;
            temporaryMCMenu = null;

            if (PersonID != null)
                MCPersonID = PersonID.ID;
            else
                MCPersonID = 0;

            mcM.MCS = mcM.MenuShow();

            if ( StartFunc != null )
            {
                // Wird eine Startfunktion angegeben, wird diese aufgerufen.
                // Es wird davon ausgegangen, dass diese Startfunktion das Startparameter nicht auswertet, denn es hängt eine leere Liste 
                // drin. Und das ist auch sachgerecht, dieses Parameter wird wirklich nirgends verwendet.
                List<MCMenuEntry> tMCME2 = new List<MCMenuEntry>() { };
                StartFunc(tMCME2);
            }

            bool continued = mcM.Set(0);

            if (PersonID != null)
                Persons!.Find(PersonID)!.SetLatestDialog(mcM, Func!);

            if(continued)
                mcM.MCS.MCOutput(mcM, mcM.MCSelection, false);

        }


        public void GenericDialog( Person? PersonID, DelDialog? Func, bool AlwaysRestart = false, DelMCMenuEntry? StartFunc = null, string? talkString = null, bool doRecording = true)
        {
            GenericDialog(PersonID, Func, -1, AlwaysRestart, StartFunc, talkString, doRecording );
        }

        public bool SayToI(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item = PTL.GetFirstItem()!; //  GetPersonRef(Adv_PT[2].WordID);


            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, loca.Order_SayToI_Person_Everyone_446);

            }
            return handled;
        }


        public override bool  UnlockW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);
            // int ItemID1 = GetItemIx(Adv_PT[1].WordID);
            // int ItemID2 = GetItemIx(Adv_PT[3].WordID);

            // Pre
            if( item1 == CA.I07_Door && item2 == CA.I00_Key)
            {
                CA.Status_Tuer_Labor.Val = 1;
                AdvGame!.StoryOutput(loca.Unlock_Labor_Door);
                handled = true;
            }


            // Base
            if (!handled)
                handled = base.UnlockW(PersonID, PTL);
            if (!handled)
            {
            }
            else
            {
                AdvGame!.LockedDoorSwitchToUnlocked(item1);

            }
            return (handled);
        }

        public bool Unlock(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Unlock_453, item1!.ID ));

            return (handled);
        }

        public bool Lock(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Lock_454, item1!.ID ));

            return (handled);
        }

        public bool Place(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Place_455, item1!.ID ));

            return (handled);
        }

        public bool Mount(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Mount_456, item1!.ID ));

            return (handled);
        }

        public bool PoisonSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PoisonSolo_457, item1!.ID ));

            return (handled);
        }

        public bool MixSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_MixSolo_458, item1!.ID ));

            return (handled);
        }

        public bool ExchangeSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_ExchangeSolo_459, item1!.ID ));

            return (handled);
        }

        public bool SparkSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_SparkSolo_460, item1!.ID ));

            return (handled);
        }

        public bool DetermineSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_DetermineSolo_461, item1!.ID ));

            return (handled);
        }

        public bool CleanSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            
            if( ! handled)
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_CleanSolo_I00_Giesskanne_Alk_463, item1!.ID ));

            return (handled);
        }

        public bool WashSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_WashSolo_464, item1!.ID ));

            return (handled);
        }

        public bool WrapSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_WrapSolo_465, item1!.ID ));

            return (handled);
        }

        public bool ThrowSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_ThrowSolo_466, item1!.ID ));

            return (handled);
        }

        public bool PlaceSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if( !handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PlaceSolo_I0_08_Bettchen_467, item1!.ID ));

                handled = true;
            }

            return (handled);
        }

        public bool PlaceSoloOn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if( !handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PlaceSoloOn_I0_08_Bettchen_468, item1!.ID ));
                handled = true;
            }

            return (handled);
        }

        public bool GiveSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_GiveSolo_469, item1!.ID ));

            return (handled);
        }

        public bool ShowSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_ShowSolo_470, item1!.ID ));

            return (handled);
        }

        public bool PleaSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PleaSolo_471, item1!.ID ));

            return (handled);
        }

        public bool DemandSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_DemandSolo_472, item1!.ID ));

            return (handled);
        }

        public bool CutSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_CutSolo_473, item1!.ID ));

            return (handled);
        }

        public bool TieSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_TieSolo_474, item1!.ID ));

            return (handled);
        }

        public bool GrabSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_GrabSolo_475, item1!.ID ));

            return (handled);
        }

        public bool FillSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_FillSolo_476, item1!.ID ));

            return (handled);
        }

        public bool AttachSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_AttachSolo_477, item1!.ID ));

            return (handled);
        }

        public bool HangSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_HangSolo_478, item1!.ID ));

            return (handled);
        }

        public bool PunctureSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PunctureSolo_479, item1!.ID ));

            return (handled);
        }

        public bool SmearSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_SmearSolo_480, item1!.ID ));

            return (handled);
        }

        public bool AskSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1= PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_AskSolo_481, person1! ));

            return (handled);
        }

        public bool PaintSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PaintSolo_482, person1 ));

            return (handled);
        }

        public override bool  UnlockWP(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Person person11 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[3].WordID);

            // Pre
            // Base
            if (success)
                success = base.UnlockWP(PersonID, PTL);
            if (success)
            {
                // AdvGame!.LockedDoorSwitchToUnlocked(item1);

            }
            return (success);
        }

        public override bool  LockW(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            bool handled = false;

            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);
            // int ItemID1 = GetItemIx(Adv_PT[1].WordID);
            // int ItemID2 = GetItemIx(Adv_PT[3].WordID);

            // Pre
            // Base
            if (success && !handled)
                success = base.LockW(PersonID, PTL);
            if (success)
            {
                AdvGame!.LockedDoorSwitchToLocked(item1);
            }

            if (handled)
                success = true;

            return (success);
        }

        public override bool  LockWP(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Person person1 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[3].WordID);

            // Pre
            // Base
            if (success)
                success = base.LockWP(PersonID, PTL);
            if (success)
            {
                // AdvGame!.LockedDoorSwitchToLocked(item1);
            }
            return (success);
        }

        public override bool  TakeUnder(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;

            // Pre

            // base
            if (success)
                success = base.Take(PersonID, PTL);

            // Post

            return (success);
        }

        public override bool  TakeOut(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[3].WordID);

            // Pre

            // base
            if (success)
                success = base.Take(PersonID, PTL);

            // Post

            return (success);
        }

        public override bool  TakeFrom(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;

            // Pre

            // base
            if (success)
                success = base.Take(PersonID, PTL);

            // Post

            return (success);
        }

        public override bool  TakeBehind(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;

            // Pre

            // base
            if (success)
                success = base.Take(PersonID, PTL);

            // Post

            return (success);
        }

        public override bool  TakeBeside(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;

            // Pre

            // base
            if (success)
                success = base.Take(PersonID, PTL);

            // Post

            return (success);
        }



        public override bool  PlaceUnder(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            // Pre

            if (!handled)
            {
                if (item1.locationID != PersonID!.ID)
                {
                    Take(PersonID, PTL);
                    if (item1.locationID != PersonID!.ID)
                        handled = true;
                }

                if (!handled)
                    handled = !ItemFromInv(item1, PersonID);
            }

            // base
            if (!handled)
                success = base.PlaceUnder(PersonID, PTL);

            // Post

            return (true );
        }

        public bool MountW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            return handled;
        }

        public override bool  PlaceIn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            bool success = true;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            // Pre
            if (!handled)
            {
                if( item1.locationID != PersonID!.ID )
                {
                    Take(PersonID, PTL);
                    if (item1.locationID != PersonID!.ID)
                        handled = true;
                }

                if( !handled)
                    handled = !ItemFromInv(item1, PersonID);
            }

            if (!handled)
            {
            }
            /*
            if (item1!.ID == CA!.I00_Schatz && item2!.ID ==CA!.I0_08_Kiste)
            {
                int x = 5;
            }
            */
                // base
                if (!handled)
                handled = base.PlaceIn(PersonID, PTL);

            // Post
            if (handled && success )
            {
            }
            return (handled);
        }

        public override bool  PlaceInP(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person2 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[3].WordID);

            // Pre
            if (success)
            {
                if (success)
                {
                    if (item1.locationID != PersonID!.ID)
                    {
                        Take(PersonID, PTL);
                        if (item1.locationID != PersonID!.ID)
                            success = false;
                    }

                    if (success )
                        success = ItemFromInv(item1, PersonID);
                }
            }

            // base
            if (success)
                success = base.PlaceInP(PersonID, PTL);

            // Post

            return (success);
        }

        public  bool PlacePIn(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person1 = PTL.GetFirstPerson()!; //  GetPersonRef(Adv_PT[3].WordID);

            if( person1!.ID == CA!.Person_I!.ID)
            { 
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_PlacePIn_I1_08_Bett_572, item2!.ID ));
            }
            else 
            {
                AdvGame!.StoryOutput( loca.Order_PlacePIn_I1_08_Bett_573);
            }
            return (success);
        }

        public bool GiveToI(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetPersonRef(Adv_PT[3].WordID);
            
            // Pre
            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_GiveToI_I00_Hamberder_576, PersonID, PersonID,  item2!.ID,  item1!.ID ));

                handled = true;
            }

            // base
            if (!handled)
                handled = !base.GiveToP(PersonID, PTL);

            // Post

            return (handled);
        }

        public override bool PlaceOn(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            // Pre
            if (success)
            {
                if (item1.locationID != PersonID!.ID)
                {
                    Take(PersonID, PTL);
                    if (item1.locationID != PersonID!.ID)
                        success = false;
                }

                if (success)
                    success = ItemFromInv(item1, PersonID);
            }

            // base
            if (success)
                success = base.PlaceOn(PersonID, PTL);

            // Post
            if( success)
            {

            }

            if (handled)
                success = true;

            return (success);
        }

        public override bool  PlaceBehind(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            // Pre
            if (success)
            {
                if (item1.locationID != PersonID!.ID)
                {
                    Take(PersonID, PTL);
                    if (item1.locationID != PersonID!.ID)
                        success = false;
                }

                if (success)
                    success = ItemFromInv(item1, PersonID);
            }

            // base
            if (success)
                success = base.PlaceBehind(PersonID, PTL);

            // Post

            return (success);
        }

        public override bool  PlaceBeside(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            // Pre
            if (success)
            {
                if (item1.locationID != PersonID!.ID)
                {
                    Take(PersonID, PTL);
                    if (item1.locationID != PersonID!.ID)
                        success = false;
                }

                if (success)
                    success = ItemFromInv(item1, PersonID);
            }

            // base
            if (success)
                success = base.PlaceBeside(PersonID, PTL);

            // Post

            return (success);
        }

        public override bool  ExamineBelow(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);

            if( item1 == CA!.I02_Doormat && CA!.I02_Doormat.InvisibleBelow == true )
            {
                AdvGame.StoryOutput(loca.Examine_Under_Doormat);
                CA!.I02_Doormat.InvisibleBelow = false;
                handled = true;
            }
            if (item1 == CA!.I12_Matress && CA!.I12_Matress.InvisibleBelow == true)
            {
                CA!.I12_Matress.InvisibleBelow = false;
            }

            // base
            if (!handled)
                handled = base.ExamineBelow(PersonID, PTL);

            return (handled);

        }

        public override bool ExamineIn(Person PersonID, ParseTokenList PTL )
        {
            bool success = true;
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);

            // Pre
            if( item1 == CA.I14_Opening && CA.I14_Opening.InvisibleIn == true )
            {
                AdvGame.StoryOutput(loca.Examine_In_Opening);

                CA.I14_Opening.InvisibleIn = false;
            }


            // base
            if (success && !handled)
                success = base.ExamineIn(PersonID, PTL);

       

            // Post
            if (handled)
                success = true;

            return (success);
        }

        public override bool  ExamineOn(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);

            // Pre

            // base
            if (success)
                success = base.ExamineOn(PersonID, PTL);

            // Post

            return (success);

        }

        public override bool  ExamineBehind(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            bool handled = true;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);


            // base
            if (success)
                success = base.ExamineBehind(PersonID, PTL);

            // Post
            if( success )
            {

              }

            return (handled);
        }

        public override bool  ExamineBeside(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);

            // base
            if (success)
                success = base.ExamineBeside(PersonID, PTL);

            // Post

            return (success);
        }

        public override bool  Taste(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);

            // Pre

            // base
            if (success)
                success = base.Taste(PersonID, PTL);

            // Post

            return (success);
        }

        public override bool  Smell(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[2].WordID);


            // Pre

            // base
            if (success)
                success = base.Smell(PersonID, PTL);

            // Post
            return (success);
        }

        public override bool  SmellP(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[2].WordID);

            // Pre

            // base
            if (success)
                success = base.SmellP(PersonID, PTL);

            // Post

            return (success);
        }

        public bool SmellSolo(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;


            return (success);
        }


        public bool Use(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


            if( item1 == CA.I00_Nullbehaelter)
            {
                CA.I10_Metall_Tray.CanPutIn = true;
                CA.I10_Metall_Tray.StorageIn = 30;

                /*
                // CA.Status_Elster_Klaue.Val = 30;
                // CA.Status_Eule_Klaue.Val = 30;
                // CA.Status_Ritterruestung_Klaue.Val = 30;

                CA.Status_Kerzenhalter.Val = 1;
                CA.Status_Antwort_Lieblingstier.Val = 1;
                CA.Status_Antwort_Ruestung.Val = 1;
                CA.Status_Antwort_Unterwaesche.Val = 1;
                // CA.Status_Tuer_Bibliothek.Val = 1;
                CA.Status_Tuer_Labor.Val = 1;
                // CA.Status_Tuer_Schlafkammer.Val = 1;

                // Items.TransferItem(CA.I00_Unstable_Pliers_With_Claw.ID, CB.LocType_Person, CA.Person_I.ID);
                Items.TransferItem(CA.I00_Stable_Pliers_With_Claw.ID, CB.LocType_Person, CA.Person_I.ID);
                Items.TransferItem(CA.I00_Magic_Candle.ID, CB.LocType_Person, CA.Person_I.ID);
                Items.TransferItem(CA.I00_Lightless_Stone.ID, CB.LocType_Person, CA.Person_I.ID);

                A.ActLoc = CA.L12_Sleeping_Room;
                Persons.TransferPerson(CA.Person_I.ID, CB.LocType_Person, A.ActLoc);
                locations.ShowlocationFull(A.ActLoc);

                AdvGame.StoryOutput("Möp");
                */
                success = true;
            }

            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID, Helper.Insert(loca.Order_Use_I2_07_Fahrstuhl_742, item1!.ID));
            }
            if (handled)
                success = true;

            return (success);
        }

        public bool Extinguish(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (item1 == CA.I00_Magic_Candle)
            {
                if (CA.Status_Kerzenhalter.Val == 1)
                {
                    CA.Status_Kerzenhalter.Val = 0;
                    CA!.I00_Magic_Candle.LocaDescription = "Adv_I00_Magic_Candle";
                    CA!.I00_Magic_Candle.LocaDescriptionHandle = loca.Adv_I00_Magic_Candle;
                    AdvGame.StoryOutput(loca.Extinguish_Magic_Candle_Yes);
                }
                else
                {
                    AdvGame.StoryOutput(loca.Extinguish_Magic_Candle_No);

                }
                success = true;
            }

            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_Extinguish_I2_47_Hoellenfeuer_744, item1!.ID ));
            }
            return (success);
        }

        public bool KnockSolo(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID, loca.Order_KnockSolo_745);
            }
            return (true);
        }

        public override bool  KnockOn(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            bool response = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            
            if ( !success )
            {
                success = base.KnockOn(PersonID, PTL);
            }
            if (success)
            {

                if ( !response )
                {
                    AdvGame!.StoryOutput( loca.Order_KnockOn_I2_36_Muellcontainer_772);
                    response = true;

                }
            }
            return (success);
        }

        public bool SpitOn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_SpitOn_I00_Blumenkohl_frisch_774, item1!.ID ));
            }
            return (handled);
        }


        public bool SpitDown(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID, loca.Order_SpitDown_Person_Fette_Wache_Turm_PV1_775);
            }
            return handled;
        }

        public bool SpitOnP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_SpitOnP_Person_Ghoul_PV1_unconscious_786, person1 ));
            }
            return (handled);
        }

        public bool ListenOn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_ListenOn_Person_Everyone_791, item1!.ID ));
            }
            return (handled);
        }

        public bool Listen(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            if (!handled)
            {
                AdvGame!.StoryOutput( loca.Order_Listen_Person_Scaramango_793);
            }
            return (handled);
        }

        public bool ListenToP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_ListenToP_Person_Phoney_PV1_795, person1 ));
            }
            return (handled);
        }

        public bool ListenToT(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Topic topic1 = PTL.GetFirstTopic()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_ListenToT_799, topic1!.ID ));
            }
            return (handled);
        }

        public bool AttachTo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if( item1 == CA.I10_Metall_Tray && item2 == CA.I10_Bracket )
            {
                CA.Status_Schale_Befestigt.Val = 1;
                AdvGame!.StoryOutput(loca.AttachTo_Schale_Ok);
                handled = true;
            }

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_AttachTo_Person_Everyone_803, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool HangTo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);
            
            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_HangTo_Person_Everyone_804, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Dip(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Dip_Person_Everyone_807, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Tip(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if( item1 == CA.I00_Magic_Powder && item2 == CA!.I00_Magic_Candle )
            {
                if( CA.Status_Kerzenhalter.Val == 0)
                {
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, loca.Tip_MagicPowder_MagicCandle_NoFlame);

                }
                else if ( CA.Person_I.locationID != CA.L03_In_The_Parlor )
                {
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, loca.Tip_MagicPowder_MagicCandle_NoMagic);

                }
                else
                {
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, loca.Tip_MagicPowder_MagicCandle_Do);
                    Items.TransferItem(CA.I00_Magic_Powder.ID, CA.I00_Nullbehaelter.ID);
                    A.ActLoc = CA.L05_Atrium;
                    Persons.TransferPerson(Persons!.Find(CA!.Person_I!)!.ID, CB!.LocType_Loc, A!.ActLoc);
                    locations.ShowlocationFull(A.ActLoc);
                }
                handled = true;
            }
            else if (item1 == CA.I00_Supermagic_Powder&& item2 == CA!.I00_Magic_Candle)
            {
                if (CA.Status_Kerzenhalter.Val == 0)
                {
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, loca.Tip_MagicPowder_MagicCandle_NoFlame);

                }
                else if (CA.Person_I.locationID != CA.L05_Atrium)
                {
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, loca.Tip_SupermagicPowder_MagicCandle_NoMagic);

                }
                else
                {
                    AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, loca.Tip_SupermagicPowder_MagicCandle_Do);
                    Items.TransferItem(CA.I00_Supermagic_Powder.ID, CA.I00_Nullbehaelter.ID);
                    A.ActLoc = CA.L15_Nowhere;
                    Persons.TransferPerson(Persons!.Find(CA!.Person_I!)!.ID, CB!.LocType_Loc, A!.ActLoc);
                    locations.ShowlocationFull(A.ActLoc);
                }
                handled = true;
            }

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_TipSolo_Person_Everyone_822, item1!.ID ));
            }
            return (handled);
        }

        public bool Water(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Water_Person_Everyone_823, item1!.ID ));
            }
            return (handled);
        }

        public bool WaterWOn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CA!.Verb_Water);
            PT.AddItem(item1);
            PT.AddPrep(CB!.Prep_on);
            PT.AddItem(item2);

            Tip(PersonID, PT);

            handled = true;
            return handled;
        }

        public bool WaterW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

             if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_WaterW_Person_Everyone_824, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool WaterWIn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_WaterWIn_Person_Everyone_825, item1!.ID, item2!.ID ));
            }
            return (handled);
        }


        public bool TipIn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_TipIn_Person_Everyone_842, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Poison(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item1 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Poison_Person_Everyone_843, item2!.ID, item1!.ID ));
            }
            return (handled);
        }

        public bool Compare(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item1 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Compare_Person_Everyone_845, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool TipP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person2 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_TipP_Person_Everyone_854, item1!.ID, person2 ));
            }
            return (handled);
        }

        public bool Creep(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Creep_Person_Everyone_858, item1!.ID ));
            }
            return (handled);
        }

        public bool Follow(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Follow_Person_Everyone_861, item1!.ID ));
            }
            return (handled);
        }

        public bool Slide(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Slide_Person_Everyone_863, item1!.ID ));
            }
            return (handled);
        }

        public bool Accede(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Accede_I2_03_Thron_865, item1!.ID ));
            }
            return (handled);
        }

        public bool Repair(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Repair_IX_03_Regal_867, item1!.ID ));
            }
            return (handled);
        }

        public bool Sort(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Sort_I0_06_Geruempel_869, item1!.ID ));
            }
            return (handled);
        }

        public bool Stroke(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Stroke_IX_03_Wand_871, item1!.ID ));
            }
            return (handled);
        }

        public bool SwitchOff(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_SwitchOff_I0_12_Herd_873, item1!.ID ));
            }
            return (handled);
        }

        public bool SwitchOn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


            if (!handled)
            {
                AdvGame!.StoryOutput( Helper.Insert(loca.Order_SwitchOn_I0_12_Herd_875, item1!.ID ));
            }
            return (handled);
        }

        public bool Lift(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Lift_I2_03_Teppich_877, item1!.ID ));
            }
            return (handled);
        }

        public bool Wipe(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Wipe_I0_12_Boden_superglatt_880, item1!.ID ));
            }
            return (handled);
        }

        public bool WipeP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);


            if (!handled)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.Wipe_Generally, person1!.ID));
            }
            return (handled);
        }
        public bool WipeWP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


            if (!handled)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.Wipe_WP_Generally, person1!.ID, item2!.ID));
            }
            return (handled);
        }


        public bool StealP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1= PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_StealP_Person_Phoney_PV1_883, person1 ));
            }
            return (handled);
        }

        public bool StealWP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1= PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person2 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_StealWP_Person_Phoney_PV1_887, item1!.ID, person2 ));
            }
            return (handled);
        }

        public bool WipeW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_WipeW_I00_Eimer_889, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Confess(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            if (!handled)
            {
                AdvGame!.StoryOutput( loca.Order_Confess_890);
                handled = true;
            }
            return (handled);
        }

        public bool Score(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            string[] titel = 
            {   loca.Order_Score_891,
                loca.Order_Score_892,
                loca.Order_Score_893,
                loca.Order_Score_894,
                loca.Order_Score_895,
                loca.Order_Score_896,
                loca.Order_Score_897,
                loca.Order_Score_898,
                loca.Order_Score_899,
                loca.Order_Score_900
            };

            if (!handled)
            {
                int val = Scores!.TotalScore()!;
                int max = 0;
                AdvGame!.StoryOutput( String.Format( loca.Order_Score_901, val, Scores!.MaximumScore() ) );

                if (val > 4000)
                    max = 9;
                else if (val > 3500)
                    max = 8;
                else if (val > 3000)
                    max = 7;
                else if (val > 2500)
                    max = 6;
                else if (val > 2000)
                    max = 5;
                else if (val > 1500)
                    max = 4;
                else if (val > 1000)
                    max = 3;
                else if (val > 600)
                    max = 2;
                else if (val > 300)
                    max = 1;

                if (max > 0)
                {
                }
                titel[max] = String.Format( loca.Order_Score_902, titel[max] );

                AdvGame!.StoryOutput( loca.Order_Score_903);

                for( int i = 0; i <= max; i++)
                {
                    AdvGame!.StoryOutput(titel[i]);
                }
                AdvGame!.StoryOutput( loca.Order_Score_904);
                handled = true;

                double c1score = 0;
                double c2score = 0;
                double c3score = 0;
                double c4score = 0;

                double c1totalscore = 0;
                double c2totalscore = 0;
                double c3totalscore = 0;
                double c4totalscore = 0;

                int tipps = 0;
                int spoilers = 0;
                int solutions = 0;

                foreach ( Score sc in Scores!.Scores! )
                {
                    if (sc.SpoilerState == spoiler.tipp)
                        tipps++;
                    else if (sc.SpoilerState == spoiler.spoiler)
                        spoilers++;
                    else if (sc.SpoilerState == spoiler.solution)
                        solutions++;

                    if( sc.Chapter == scoreChapter.chapter_one)
                    {
                        c1totalscore += sc!.Val;

                        if (sc.Active)
                            c1score += sc!.Val;
                    }
                    if (sc.Chapter == scoreChapter.chapter_two)
                    {
                        c2totalscore += sc!.Val;

                        if (sc.Active)
                            c2score += sc!.Val;
                    }
                    if (sc.Chapter == scoreChapter.chapter_three)
                    {
                        c3totalscore += sc!.Val;

                        if (sc.Active)
                            c3score += sc!.Val;
                    }
                    if (sc.Chapter == scoreChapter.chapter_four)
                    {
                        c4totalscore += sc!.Val;

                        if (sc.Active)
                            c4score += sc!.Val;
                    }

                }

                if( tipps == 0 && spoilers == 0 && solutions == 0 )
                    AdvGame!.StoryOutput( loca.Order_Score_905);
                else
                {
                    string s1 = string.Format( loca.Order_Score_906, tipps, spoilers, solutions);
                    AdvGame!.StoryOutput(s1);

                }

#if (DEBUG)
                string s = string.Format( loca.Order_Score_907, (double) ( ( c1score * 100 ) / c1totalscore) );
                AdvGame!.StoryOutput( String.Format( loca.Order_Score_908,  s )  );

                s = string.Format( loca.Order_Score_909, (double)( ( c2score * 100 ) / c2totalscore ) );
                AdvGame!.StoryOutput(String.Format(loca.Order_Score_910, s)) ;

                s = string.Format( loca.Order_Score_911, (double)( ( c3score * 100) / c3totalscore ) );
                AdvGame!.StoryOutput(String.Format(loca.Order_Score_912, s)) ;

                s = string.Format( loca.Order_Score_913, (double)( ( c4score *100) / c4totalscore ) );
                AdvGame!.StoryOutput(String.Format(loca.Order_Score_914, s)) ;

                double cscore = c1score + c2score + c3score + c4score;
                double ctotalscore = c1totalscore + c2totalscore + c3totalscore + c4totalscore;

                s = string.Format( loca.Order_Score_915, (double)(( cscore * 100) / ctotalscore));
                AdvGame!.StoryOutput(String.Format(loca.Order_Score_916, s)) ;

#endif
            }

            AdvGame!.SetScoreOutput();
            return (handled);
        }

        public bool Destroy(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Destroy_I00_Brille_920, item1!.ID ));
            }
            return (handled);
        }

        public bool RollIn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1= PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_RollIn_I00_Frischhaltefolie_922,  person1, item2!.ID ));
            }
            return (handled);
        }

        public bool RollSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_RollSolo_I2_45_Bodenteppich_923, item1!.ID ));
            }
            return (handled);
        }

        public bool Chop(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Chop_IX_03_Regal_926, item1!.ID ));
            }
            return (handled);
        }

        public bool ChopW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);


            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_ChopW_IX_03_Regal_928, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Demolish(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Demolish_I00_Hightech_Fessel_930, item1!.ID ));
            }
            return (handled);
        }

        public bool DemolishW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_DemolishW_I00_Sprengsatz_klebrig_931, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool PlungeIn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PlungeIn_IX_03_Spiegel_932, item1!.ID ));
            }
            return (handled);
        }

        public bool PlungeOut(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PlungeOut_I0_08_Fenster_934, item1!.ID ));
            }
            return (handled);
        }

        public bool Move(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Move_IX_01_Moebel_936, item1!.ID ));
            }
            return (handled);
        }

        public bool GlueTo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);
            
            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_GlueTo_I1_51_Phoney_Portrait_937, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool HeatW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if( item1 == CA.I10_Metall_Tray && item2 == CA.I00_Magic_Candle)
            {
                if( CA.Status_Schale_Befestigt.Val == 0 )
                {
                    AdvGame.StoryOutput(loca.Heat_NoTray);
                }
                else if (CA.Status_Kerzenhalter.Val == 0)
                {
                    AdvGame.StoryOutput(loca.Heat_NoFire);
                }
                else if ( CA.I00_Moonstone.locationID != CA.I10_Metall_Tray.ID || CA.I00_Coin.locationID != CA.I10_Metall_Tray.ID || CA.I00_Wonder_Wart_Sponge.locationID != CA.I10_Metall_Tray.ID)
                {
                    AdvGame.StoryOutput(loca.Heat_NoIngredients);
                }
                else
                {
                    AdvGame.StoryOutput(loca.Heat_Success);
                    Items.TransferItem( CA.I00_Moonstone.ID, CA.I00_Nullbehaelter2.ID);
                    Items.TransferItem(CA.I00_Coin.ID, CA.I00_Nullbehaelter2.ID);
                    Items.TransferItem(CA.I00_Wonder_Wart_Sponge.ID, CA.I00_Nullbehaelter2.ID);
                    Items.TransferItem(CA.I00_Slag.ID, CA.I10_Metall_Tray.ID);
                }
                handled = true;
            }

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_HeatW_I00_Kohle_gluehend_939, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Heat(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            
            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Heat_I2_24_Schalter_942, item1!.ID ));
            }
            return (handled);
        }

        public bool Pulverize(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Pulverize_I00_Schlaftabletten_stark_945, item1!.ID ));
            }
            return (handled);
        }

        public bool PulverizeW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PulverizeW_I2_09_Moerser_946, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool BrushW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_BrushW_I00_Stock_verschmiert_947, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Store(Person PersonID, ParseTokenList PTL)
        {
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            bool success = PlaceIn(PersonID, PTL);


            return (success);
        }

        public bool Tidy(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Tidy_I0_06_Geruempel_951, item1!.ID ));
            }
            return (handled);
        }

        public bool Swing2(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Tidy_I2_03_Leuchter_953, item1!.ID ));
            }
            return (handled);
        }

        public bool Hang2(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Tidy_I2_03_Leuchter_955, item1!.ID ));
            }
            return (handled);
        }

        public bool Type(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Type_I1_32_Computer_956, item1!.ID ));
            }
            return (handled);
        }

        public bool Dance(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            if (!handled)
            {
                AdvGame!.StoryOutput( loca.Order_Dance_957);
            }
            return (handled);
        }

        public bool DanceWP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_DanceWP_Person_Dolly_961, person1 ));
            }
            return (handled);
        }

        public bool Swing(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if( person1!.ID == CA!.Person_I!.ID)
            {
                ParseTokenList PT = new ParseTokenList();
                PT.AddVerb(CA!.Verb_Swing);
                PT.AddPrep(CB!.Prep_an);
                PT.AddItem(item2);
                Swing2(PersonID, PT);
                handled = true;

            }
            else
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Swing_Person_I_962, person1, item2!.ID ));
            }
            handled = true;
            return (handled);
        }

        public bool Hang(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (person1!.ID == CA!.Person_I!.ID)
            {
                ParseTokenList PT = new ParseTokenList();
                PT.AddVerb(CA!.Verb_Hang);
                PT.AddPrep(CB!.Prep_an);
                PT.AddItem(item2);
                Hang2(PersonID, PT);
                handled = true;

            }
            else
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Hang_Person_I_963, person1, item2!.ID ));
            }
            handled = true;
            return (handled);
        }


        public bool FrySolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_FrySolo_I1_24_Pfanne_Oel_964, item1!.ID ));
            }
            return (handled);
        }

        public bool FryIn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);


            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_FryIn_I1_24_Pfanne_Oel_965, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Form(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Topic topic1 = PTL.GetFirstTopic()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Form_I00_Hackfleisch_967, topic1!.ID ));
            }
            return (handled);
        }

        public bool FormFrom(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Topic topic1 = PTL.GetFirstTopic()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!;


            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_FormFrom_I1_24_Pfanne_Oel_970, topic1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Exits(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            int ctExits = 0;
            int tmpExits = 0;
            string s; 

            AdvGame!.StoryOutput( loca.Order_Exits_971);

            location l = locations!.Find(CA!.Person_I!.locationID!)!;


            foreach( int x in l.LocExit! )
            {
                if (x != 0) ctExits++;
            }

            if (ctExits == 0)
                s = loca.Order_Exits_Person_I_972;
            else if (ctExits == 1)
                s = loca.Order_Exits_Person_I_973;
            else
                s = loca.Order_Exits_Person_I_974;

            for (int i = 1; i <= 10; i++)
            {
                if (l.LocExit[i] > 0)
                {
                    switch (i)
                    {
                        case 1: s += loca.Order_Exits_Person_I_975; break;
                        case 2: s += loca.Order_Exits_Person_I_976; break;
                        case 3: s += loca.Order_Exits_Person_I_977; break;
                        case 4: s += loca.Order_Exits_Person_I_978; break;
                        case 5: s += loca.Order_Exits_Person_I_979; break;
                        case 6: s += loca.Order_Exits_Person_I_980; break;
                        case 7: s += loca.Order_Exits_Person_I_981; break;
                        case 8: s += loca.Order_Exits_Person_I_982; break;
                        case 9: s += loca.Order_Exits_Person_I_983; break;
                        case 10: s += loca.Order_Exits_Person_I_984; break;

                    }
                    tmpExits++;
                    if( tmpExits == ctExits - 1)
                    {
                        s += loca.Order_Exits_Person_I_985; 
                    }
                    else if( tmpExits != ctExits )
                    {
                        s += loca.Order_Exits_Person_I_986;
                    }
                }
            }
            s += loca.Order_Exits_Person_I_987;
            AdvGame!.StoryOutput(s);
            handled = true;

            return (handled);
        }

        public bool Be(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (person1!.ID == CA!.Person_I!.ID)
            {
                AdvGame!.StoryOutput( loca.Order_Be_Person_I_988);
                handled = true;
            }

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Be_Person_I_989, person1 ));
                handled = true;
            }
            return (handled);
        }

        public bool Attack(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Attack_Person_Everyone_992, person1 ));
            }
            return (handled);
        }

        public bool Jump(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Jump_Person_Everyone_995, item1!.ID ));
            }
            return (handled);
        }

        public bool JumpSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;


            if (!handled)
            {
                AdvGame!.StoryOutput( loca.Order_JumpSolo_996);
            }
            return (handled);
        }

        public bool JumpIn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

             if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_JumpIn_Person_Everyone_998, item1!.ID ));
            }
            return (handled);
        }

        public bool JumpOn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_JumpOn_Person_Everyone_1003, item1!.ID ));
            }
            return (handled);
        }

        public bool JumpThrough(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_JumpThrough_Person_Everyone_1005, item1!.ID ));
            }
            return (handled);
        }

        public bool Turn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Turn_Person_Everyone_1020, item1!.ID ));
            }
            return (handled);
        }

        public bool Pluck(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Pluck_Person_Everyone_1023, item1!.ID ));
            }
            return (handled);
        }

        public bool TurnP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if( person1!.ID == CA!.Person_I!.ID)
            {

                handled = true;
            }
            else
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_TurnP_Person_Everyone_1026, person1 ));
                handled = true;
            }
            return (handled);
        }

        public bool Suck(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Suck_Person_Everyone_1030, item1!.ID ));
            }
            return (handled);
        }

        public bool SitP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if( person1!.ID == CA!.Person_I!.ID)
            {
                handled = Sit(PersonID, PTL);
            }
            else
            {
                AdvGame!.StoryOutput( loca.Order_SitP_Person_I_1031);
                handled = true;
            }
            return handled;
        }


        public bool Sit(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Sit_Person_Everyone_1043, item1!.ID ));
            }
            return (handled);
        }

        public bool LayP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (person1!.ID == CA!.Person_I!.ID)
            {
                handled = Lay(PersonID, PTL);
            }
            else
            {
                AdvGame!.StoryOutput( loca.Order_LayP_Person_I_1044);
                handled = true;
            }
            return handled;
        }


        public bool Lay(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Lay_Person_Everyone_1046, item1!.ID ));
            }
            return (handled);
        }

        public bool MixWReverse(Person PersonID, ParseTokenList PTL)
        {
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CA!.Verb_Mix);
            PT.AddItem(item2);
            PT.AddPrep(CB!.Prep_mit);
            PT.AddItem(item1);

            return MixW(PersonID, PT);
        }

        public bool MixW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_MixW_I00_Grapefruitextrakt_1047, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool MixIn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_MixIn_I0_12_Topf_1049, item1!.ID ));
            }
            return (handled);
        }

        public bool Exchange(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Exchange_I00_Papierboegen_1053, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool CrumbleW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_CrumbleW_I00_Papierboegen_1055, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool CrumbleIn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_CrumbleIn_I00_Glas_Gin_1056, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Leverage(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Leverage_I00_Stock_lang_1060, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Abandon(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Abandon_I00_Karren_1061, item1!.ID ));
            }
            return (handled);
        }

        public bool KissP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_KissP_Person_PrayinErin_PV1_1068, person1 ));
            }
            return (handled);
        }

        public bool Pray(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            if (!handled)
            {
                AdvGame!.StoryOutput( loca.Order_Pray_1071);
            }
            return (handled);
        }

        public bool Free(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Free_Person_Scaramango_1073,  person1 ));
            }
            return (handled);
        }

        public bool FreeI(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_FreeI_I1_02_Gefangene_1076, item1 ));
            }
            return (handled);
        }

        public bool Meditate(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Meditate_Person_Everyone_1078, item1!.ID ));
            }
            return (handled);
        }

        public bool Bend(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Bend_Person_Everyone_1080, item1!.ID ));
            }
            return (handled);
        }

        public bool Scroll(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Scroll_Person_Everyone_1085, item1!.ID ));
            }
            return (handled);
        }

        public bool Count(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Count_Person_Everyone_1090, item1!.ID ));
            }
            return (handled);
        }

        public bool Breath(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Breath_Person_Everyone_1091, item1!.ID ));
            }
            return (handled);
        }

        public bool SpraySolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_SpraySolo_Person_Everyone_1093, item1!.ID ));
            }
            return (handled);
        }

        public bool SprayOn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_SprayOn_Person_Everyone_1094, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool MakeOn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_MakeOn_Person_Everyone_1098, item1!.ID ));
            }
            return (handled);
        }

        public bool MakeOff(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_MakeOff_Person_Everyone_1101, item1!.ID ));
            }
            return (handled);
        }

        public bool MeditateSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, loca.Order_MeditateSolo_Person_Everyone_1103);
            }
            return (handled);
        }

        public bool Dress(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if ( !handled)
            {

                if (item1.locationID != PersonID!.ID)
                {
                    AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Dress_I00_Basecap_1105, item1!.ID ));
                    handled = true;
                }
                else if( item1.Dressable && !item1.IsDressed)
                {
                    AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Dress_I00_Basecap_1106, item1!.ID ));
                    handled = true;
                    item1.IsDressed = true;

                    if(item1.Categories!.Find( A!.Cat_Wearable )! != null )
                    {
                        item1.Categories!.Delete(A!.Cat_Wearable );
                        item1.Categories!.Add(AdvGame!.Categories!.Find(A!.Cat_Unwearable) );
                    }
                    if (item1.Categories!.Find(A!.Cat_Dressable) != null)
                    {
                        item1.Categories!.Delete(A!.Cat_Dressable);
                        item1.Categories!.Add(AdvGame!.Categories!.Find(A!.Cat_Undressable));
                    }
                    // item1.Appendix = " (angezogen)";
                }
                else if ( item1.IsDressed )
                {
                    AdvGame!.StoryOutput(Helper.Insert(loca.Order_Dress_Already_Dressed, item1!.ID));
                    handled = true;

                }
                if (!handled)
                {
                    AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Dress_I00_Basecap_1107, item1!.ID ));
                }

            }
            return (handled);
        }

        public bool Undress(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


            if (item1.Dressable && item1.IsDressed)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Undress_I00_Peruecke_1111, item1!.ID ));
                handled = true;
                item1.IsDressed = false;
                item1.Appendix = null;

                if (item1.Categories!.Find(A!.Cat_Unwearable)! != null)
                {
                    item1.Categories!.Delete(A!.Cat_Unwearable);
                    item1.Categories!.Add(AdvGame!.Categories!.Find(A!.Cat_Wearable));
                }
                if (item1.Categories!.Find(A!.Cat_Undressable) != null)
                {
                    item1.Categories!.Delete(A!.Cat_Undressable);
                    item1.Categories!.Add(AdvGame!.Categories!.Find(A!.Cat_Dressable));
                }
            }
            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Undress_I00_Peruecke_1112, item1!.ID ));
            }


            return (handled);
        }

        public bool Press(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if( item1 == CA!.I10_Switch)
            {
                if( CA!.I10_Hatch.IsClosed == false )
                {
                    AdvGame!.StoryOutput(loca.Press_Switch_Fail);
                }
                else if ( CA.I00_Polished_Stone.locationID == CA!.I10_Opening.ID )
                {
                    Items.TransferItem(CA!.I00_Polished_Stone.ID, CA.I00_Nullbehaelter.ID);
                    Items.TransferItem(CA!.I00_Lightless_Stone.ID, CA.I10_Opening.ID);
                    AdvGame!.StoryOutput(loca.Press_Switch_Saug);
                }
                else
                {
                    AdvGame!.StoryOutput(loca.Press_Switch_Nothing_Happens);

                }
                handled = true;
            }

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Press_Person_Everyone_1126, item1!.ID ));
            }
            return (handled);
        }

        public bool Ring(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.Order_Ring_Item, item1!.ID));
            }
            return (handled);
        }

        public bool PressIn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_PressIn_Person_Everyone_1127, item1!.ID, item2!.ID ));
            }
            return (handled);
        }
        public bool PressOn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.Order_PressOn, item1!.ID, item2!.ID));
            }
            return (handled);
        }

        public bool Blow(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Blow_Person_Everyone_1129, item1!.ID ));
            }
            return (handled);
        }

        public bool BlowWith(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone, Helper.Insert(loca.Order_BlowWith_Person_Everyone_1131, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Puncture(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Puncture_Person_Everyone_1133, item1!.ID, item2!.ID ));
            }
            return (handled);
        }
        // Hier ist das Subjekt das 2. Item statt wie bei der anderen Variante

        public bool PunctureReverse(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            // Hier werden die Items schlicht in anderer Reihenfolge abgeholt. So bleibt der Code komplett gleich
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item1 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_PunctureReverse_Person_Everyone_1135, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Soil(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            ParseTokenList PT = new ParseTokenList();
            PT.AddVerb(CA!.Verb_Smear);
            PT.AddItem(item2);
            PT.AddPrep(CB!.Prep_mit);
            PT.AddItem(item1);
            Smear(PersonID, PT);
            handled = true;

            return (handled);
        }


        public bool Smear(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Smear_Person_Everyone_1140, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool SmearOn(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_SmearOn_Person_Everyone_1141, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool SmearReverse(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item1 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_SmearReverse_Person_Everyone_1142, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool SmearP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person2 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_SmearP_Person_Everyone_1144, item1!.ID, person2 ));
            }
            return (handled);
        }

        public bool SmearOnP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person2 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_SmearOnP_Person_Everyone_1146, item1!.ID, person2 ));
            }
            return (handled);
        }

        public bool SmearReverseP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person2 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_SmearReverseP_Person_Everyone_1148, item1!.ID, person2 ));
            }
            return (handled);
        }

        public bool PhotographP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!;

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PhotographP_Person_Ludmilla_PV1_1165, person1 ));
            handled = true;

            return (handled);
        }

        public bool PhotographP2(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_PhotographP_Person_Everyone_1166, item2!.ID ));
            }
            return (handled);
        }

        public bool Arrest(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_Arrest_Person_Everyone_1182, person1 ));
            }
            return (handled);
        }

        public bool ArrestW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_ArrestW_Person_Everyone_1185, person1, item2 ));
            }
            return (handled);
        }

        public bool ExamineMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_ExamineMC_1186, loca.Order_ExamineMC_1187, A!.Cat_Examinable);
            return false;
        }

        public bool ExamineInMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_ExamineInMC_1188, loca.Order_ExamineInMC_1189, A!.Cat_ExamineInable);
            return false;
        }

        public bool ExamineOnMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_ExamineOnMC_1190, loca.Order_ExamineOnMC_1191, A!.Cat_ExamineOnable);
            return false;
        }

        public bool ExamineBehindMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_ExamineBehindMC_1192, loca.Order_ExamineBehindMC_1193, A!.Cat_ExamineBehindable);
            return false;
        }

        public bool ExamineBelowMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_ExamineBelowMC_1194, loca.Order_ExamineBelowMC_1195, A!.Cat_ExamineBelowable);
            return false;
        }

        public bool ExamineBesideMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_ExamineBesideMC_1196, loca.Order_ExamineBesideMC_1197, A!.Cat_ExamineBesideable);
            return false;
        }


        public bool ExamineT( Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Topic topic = PTL.GetFirstTopic()!; 

             /* Diese beiden Topics sind irgendwie brandgefährlich
            if (topic == CA!.TP_Boden)
            {
                AdvGame!.StoryOutput( "Ja, es stimmte: ich hatte hier Boden unter den Füßen.");
                handled = true;
            }
            if (topic == CA!.TP_Ecke)
            {
                int r = PersonID!.locationID;

                AdvGame!.StoryOutput( "In den Ecken sah ich nichts besonderes.");
                handled = true;
            }
            */
            if ( !handled )
            {
                AdvGame!.FeedbackOutput(PersonID, topic!.FullName(topic, Co.CASE_NOM) + loca.Order_ExamineT_1198);

            }
            return (handled);
        }

        public bool UseMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_UseMC_1199, loca.Order_UseMC_1200, A!.Cat_Usable);
            return false;
        }

        public bool DropMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_DropMC_1201, loca.Order_DropMC_1202, A!.Cat_Dropable!);
            return false;
        }

        public bool OpenMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_OpenMC_1203, loca.Order_OpenMC_1204, A!.Cat_Openable);
            return false;
        }

        public bool CloseMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_CloseMC_1205, loca.Order_CloseMC_1206, A!.Cat_Closeable);
            return false;
        }

        public bool TasteMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_TasteMC_1207, loca.Order_TasteMC_1208, A!.Cat_Tasteable);
            return false;
        }

        public bool BreakMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_BreakMC_1209, loca.Order_BreakMC_1210, A!.Cat_Breakable);
            return false;
        }

        public bool DrawMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_DrawMC_1211, loca.Order_DrawMC_1212, A!.Cat_Pullable);
            return false;
        }

        public bool EatMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_EatMC_1213, loca.Order_EatMC_1214, A!.Cat_Eatable);
            return false;
        }

        public bool ExtinguishMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_ExtinguishMC_1215, loca.Order_ExtinguishMC_1216, A!.Cat_Extinguishable);
            return false;
        }

        public bool LightMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_LightMC_1217, loca.Order_LightMC_1218, A!.Cat_Enlightable);
            return false;
        }

        public bool PickMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_PickMC_1219, loca.Order_PickMC_1220, A!.Cat_Pickable);
            return false;
        }

        public bool PushMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_PushMC_1221, loca.Order_PushMC_1222, A!.Cat_Pushable);
            return false;
        }

        public bool ReadMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_ReadMC_1223, loca.Order_ReadMC_1224, A!.Cat_Readable);
            return false;
        }

        public bool DrinkMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_DrinkMC_1225, loca.Order_DrinkMC_1226, A!.Cat_Drinkable);
            return false;
        }

        public bool TouchMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_TouchMC_1227, loca.Order_TouchMC_1228, A!.Cat_Touchable);
            return false;
        }

        public bool SmellMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_SmellMC_1229, loca.Order_SmellMC_1230, A!.Cat_Smellable);
            return false;
        }

        public bool UntightenMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_UntightenMC_1231, loca.Order_UntightenMC_1232, A!.Cat_Untightenable);
            return false;
        }

        public bool UseWMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_UseWMC_1233, loca.Order_UseWMC_1234, A!.Cat_UsableWith, loca.Order_UseWMC_1235 );
            return false;
        }

        public bool UnlockWMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_UnlockWMC_1236, loca.Order_UnlockWMC_1237, A!.Cat_Unlockable, loca.Order_UnlockWMC_1238);
            return false;
        }

        public bool LockWMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_LockWMC_1239, loca.Order_LockWMC_1240, A!.Cat_Unlockable, loca.Order_LockWMC_1241);
            return false;
        }

        public bool TakeOutMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_TakeOutMC_1242, loca.Order_TakeOutMC_1243, A!.Cat_TakeOutable, loca.Order_TakeOutMC_1244);
            return false;
        }

        public bool TakeFromMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_TakeFromMC_1245, loca.Order_TakeFromMC_1246, A!.Cat_TakeFromable, loca.Order_TakeFromMC_1247);
            return false;
        }

        public bool TakeBehindMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_TakeBehindMC_1248, loca.Order_TakeBehindMC_1249, A!.Cat_TakeFromBehindable, loca.Order_TakeBehindMC_1250);
            return false;
        }

        public bool TakeUnderMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_TakeUnderMC_1251, loca.Order_TakeUnderMC_1252, A!.Cat_TakeFromBelowable, loca.Order_TakeUnderMC_1253);
            return false;
        }

        public bool TakeBesideMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_TakeBesideMC_1254, loca.Order_TakeBesideMC_1255, A!.Cat_TakeFromBesideable, loca.Order_TakeBesideMC_1256);
            return false;
        }

        public bool PushToMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_PushToMC_1257, loca.Order_PushToMC_1258, A!.Cat_PushableTo, loca.Order_PushToMC_1259);
            return false;
        }

        public bool PlaceInMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_PlaceInMC_1260, loca.Order_PlaceInMC_1261, A!.Cat_PutInable, loca.Order_PlaceInMC_1262);
            return false;
        }

        public bool PlaceOnMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_PlaceOnMC_1263, loca.Order_PlaceOnMC_1264, A!.Cat_PutOnable, loca.Order_PlaceOnMC_1265);
            return false;
        }

        public bool PlaceBehindMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_PlaceBehindMC_1266, loca.Order_PlaceBehindMC_1267, A!.Cat_PutBehindable, loca.Order_PlaceBehindMC_1268);
            return false;
        }

        public bool PlaceUnderMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_PlaceUnderMC_1269, loca.Order_PlaceUnderMC_1270, A!.Cat_PutBelowable, loca.Order_PlaceUnderMC_1271);
            return false;
        }

        public bool PlaceBesideMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_PlaceBesideMC_1272, loca.Order_PlaceBesideMC_1273, A!.Cat_PutBesideable, loca.Order_PlaceBesideMC_1274);
            return false;
        }


        public bool ThrowMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_ThrowMC_1275, loca.Order_ThrowMC_1276, A!.Cat_Throwable, loca.Order_ThrowMC_1277);
            return false;
        }

        public bool CutMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_CutMC_1278, loca.Order_CutMC_1279, A!.Cat_Cutable, loca.Order_CutMC_1280);
            return false;
        }

        public bool TieMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_TieMC_1281, loca.Order_TieMC_1282, A!.Cat_Tieable, loca.Order_TieMC_1283);
            return false;
        }

        public bool FishWithMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_FishWithMC_1284, loca.Order_FishWithMC_1285, A!.Cat_Fishable, loca.Order_FishWithMC_1286);
            return false;
        }

        public bool GrabMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_GrabMC_1287, loca.Order_GrabMC_1288, A!.Cat_Fishable, loca.Order_GrabMC_1289);
            return false;
        }

        public bool SellToMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_SellToMC_1290, loca.Order_SellToMC_1291, A!.Cat_Sellable, loca.Order_SellToMC_1292);
            return false;
        }

        public bool PickWMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_PickWMC_1293, loca.Order_PickWMC_1294, A!.Cat_Pickable, loca.Order_PickWMC_1295);
            return false;
        }

        public bool FillWMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_FillWMC_1296, loca.Order_FillWMC_1297, A!.Cat_Fillable, loca.Order_FillWMC_1298);
            return false;
        }

        public bool SayToPMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_SayToPMC_1299, loca.Order_SayToPMC_1300, A!.Cat_Talkable, loca.Order_SayToPMC_1301);
            return false;
        }

        public bool GiveToPMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_GiveToPMC_1302, loca.Order_GiveToPMC_1303, A!.Cat_Giveable, loca.Order_GiveToPMC_1304);
            return false;
        }

        public bool PleaFromPMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_PleaFromPMC_1305, loca.Order_PleaFromPMC_1306, A!.Cat_Pleaable, loca.Order_PleaFromPMC_1307);
            return false;
        }

        public bool DemandFromPMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_DemandFromPMC_1308, loca.Order_DemandFromPMC_1309, A!.Cat_Pleaable, loca.Order_DemandFromPMC_1310);
            return false;
        }

        public bool AskMC(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.DoMCCategory( loca.Order_AskMC_1311, loca.Order_AskMC_1312, A!.Cat_Questionable, loca.Order_AskMC_1313);
            return false;
        }




        public bool Climb(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_Climb_I2_26_Treppe_1340, item1!.ID ));
            }
            return (success);
        }

        public bool ClimbUp(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_ClimbUp_I2_24_Treppe_1344 , item1!.ID ));
            }
            return (success);
        }

        public bool ClimbThrough(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_ClimbThrough_Person_Everyone_1350, item1!.ID ));
            }
            return (success);
        }

        public bool ClimbOut(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_ClimbOut_Person_Everyone_1356, item1!.ID ));
            }
            return (success);
        }

        public bool ClimbIn(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            /*
            if (item1!.ID == CA!.I0_12_Ofen!.ID)
            {
                AdvGame!.StoryOutput( loca.Order_ClimbIn_I0_12_Ofen_1357);
                success = true;
            }
            */
            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_ClimbIn_I0_52_Klo_1358, item1!.ID ));
                success = true;
            }
            return (success);
        }

        public bool ClimbOn(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_ClimbOn_I0_13_Regale_1360, item1!.ID ));
            }
            return (success);
        }

        public bool ClimbDown(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!success)
            {
                    AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_ClimbDown_IX_02_Treppe_1363, item1!.ID ));
            }
            return (success);
        }


        public bool ProtOn(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.GD!.OrderList!.orderWriteMode = orderWriteMode.always;
            AdvGame!.FeedbackOutput(PersonID, loca.Order_ProtOn_1364);
            return true;
        }

        public bool ProtOff(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.GD!.OrderList!.orderWriteMode = orderWriteMode.never;
            AdvGame!.FeedbackOutput(PersonID, loca.Order_ProtOff_1365);
            return true;
        }


        public bool Verblist(Person PersonID, ParseTokenList PTL)
        {
            // bool success = false;
            string s = "";
            int ct = 0;

            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, loca.Order_Verblist_1366);

            foreach (Verb v in Verbs!.TList!.Values!)
            {
                s = s + v.Name + " ";

            }
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, s);
            ct += Verbs.TList.Count;
            s = "";
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, String.Format( loca.Order_Verblist_1367, ct ) );
            return true;
        }

        public bool Words(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            string s="";
            int ct= 0;

            if ( AdvGame!.GameTestMode == true )
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, loca.Order_Words_1368);

            foreach( Verb v in Verbs!.TList!.Values!)
            {
                s = s + v.Name + " ";

            }
            /*
            for ( int i = 0; i < Verbs.TList.Count; i++)
            {
                s = s + Verbs.TList[i].Name + " ";
            }
            */
            if ( AdvGame!.GameTestMode == true)
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, s);
            ct += Verbs.TList.Count;
            s = "";

            if ( AdvGame!.GameTestMode == true)
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, loca.Order_Words_1369);

            /*
            for (int i = 0; i < Adjs!.TList.Count; i++)
            {
                s = s + Adjs!.TList[i].Name + " ";
            }
            */
            foreach( var s3 in Adjs!.TList!.Values! )
            {
                string? s2 = ( s3 as Adj ).Name;
                s = s + s2 + " ";
            }
            if ( AdvGame!.GameTestMode == true)
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, s);
            ct += Adjs!.TList.Count;
            s = "";

            if ( AdvGame!.GameTestMode == true)
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, loca.Order_Words_1370);

            foreach (var s3 in Nouns!.TList!.Values!)
            {
                string? s2 = (s3 as Noun).Name;
                s = s + s2 + " ";
            }
  /*
            for (int i = 0; i < Nouns.TList.Count; i++)
            {
                s = s + Nouns.TList[i].Name + " ";
            }
  */
            if ( AdvGame!.GameTestMode == true )
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, s);
            ct += Nouns.TList.Count;
            s = "";

            if ( AdvGame!.GameTestMode == true)
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, loca.Order_Words_1371);

            foreach( Prep p in Preps!.TList!.Values)
            {
                s = s + p.Name + " ";
            }
            /*
            for (int i = 0; i < Preps!.TList!.Count!; i++)
            {
                s = s + Preps.TList[i].Name + " ";
            }
            */
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, s);
            ct += Preps.TList.Count;
            s = "";

            if ( AdvGame!.GameTestMode == true)
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, loca.Order_Words_1372);

            for (int i = 0; i < Fills!.TList!.Count!; i++)
            {
                s = s + Fills.TList[i].Name + " ";
            }
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, s);
            ct += Fills.TList.Count;
            s = "";

            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, String.Format( loca.Order_Words_1373, ct ) );

            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, String.Format(loca.Order_Words_1374, Items!.List!.Count) ) ;
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, String.Format(loca.Order_Words_1375, Persons!.List!.Count) );
            AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, String.Format(loca.Order_Words_1376, locations!.List!.Count ) ) ;

            return (success);
        }

        public bool UnscrewW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_UnscrewW_I00_Schraubenzieher_1377, item1!.ID, item2!.ID ));
                // AdvGame!.StoryOutput( Insert( "Ich hatte nicht die geringste Idee, wie ich [Il1,Akk] mit [Pl2,\"Jodelpaul\"] losschrauben sollte.", item1, CA!.Person_Bildhauer_PV1));
                handled = true;
            }
            return handled = true;
        }

        public bool TruncateW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_TruncateW_I00_Kneifzange_1378, item1!.ID, item2!.ID ));
                handled = true;
            }
            return handled = true;
        }
        // location-Unabhängig


        public bool UseW(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            if( item1 == CA.I00_Sugar_Pliers && item2 == CA.I00_Claw )
            {
                AdvGame!.StoryOutput(loca.UseW_SugarPliers_Claw);
                Items.TransferItem(CA.I00_Claw.ID, CA.I00_Nullbehaelter2.ID);
                Items.TransferItem(CA.I00_Sugar_Pliers.ID, CA.I00_Nullbehaelter2.ID);
                Items.TransferItem(CA.I00_Unstable_Pliers_With_Claw.ID, CB.LocType_Person, CA.Person_I.ID);

                handled = true;
            }
            if (        ( item2 == CA.I00_Plunger && item1 == CA.I00_Slag)
                    || (item1 == CA.I00_Plunger && item2 == CA.I00_Slag)
               )
            {
                AdvGame!.StoryOutput(loca.UseW_Plunger_Slag);
                Items.TransferItem(CA.I00_Slag.ID, CA.I00_Nullbehaelter2.ID);
                Items.TransferItem(CA.I00_Supermagic_Powder.ID, CA.I10_Giant_Mortar.ID);

                handled = true;
            }
            else if (item1 == CA!.I08_Water && item2 == CA!.I00_Magic_Candle)
            {
                EnlightenW(PersonID, PTL);

                handled = true;
            }
            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_UseW_I00_Blasebalg_1477, item1!.ID, item2!.ID ));
                handled = true;
            }
            return (handled);
        }


        public bool Spark(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  
            Item item2 = PTL.GetSecondItem()!;

            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_Spark_I00_Blasebalg_1478, item1!.ID, item2!.ID ));
            }
            return (handled);
        }


        public bool Stir(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  
            Item item2 = PTL.GetSecondItem()!;

            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_Stir_I00_Umruehrstab_1479, item1!.ID, item2!.ID ));
            }
            return (handled);
        }


        public bool LightW( Person PersonID, ParseTokenList PTL )
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  
            Item item2 = PTL.GetSecondItem()!; 

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_LightW_I1_53_Ofen_1489, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }
        public bool SpreadOn(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  
            Item item2 = PTL.GetSecondItem()!;

            if (item1 == CA!.I00_Plastic_Bag  && item2 == CA!.I08_Clothes)
            {
                if (CA!.I08_Clothes.locationID == CA.I08_Washing_Machine.ID ) 
                {
                    AdvGame!.StoryOutput(loca.SpreadOn_Clothes_Fail);

                }
                else
                {
                    AdvGame!.StoryOutput(loca.SpreadOn_Clothes_WWS);
                    Items.TransferItem(CA!.I00_Plastic_Bag.ID, CB.LocType_In_Item, CA!.I00_Nullbehaelter.ID);
                    Items.TransferItem(CA!.I00_Wonder_Wart_Sponge.ID, CB.LocType_In_Item, CA!.I08_Laundry_Basket.ID);

                }
                success = true;
            }

            if (!success)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.SpreadOn_Fail, item1!.ID, item2!.ID));
                success = true;
            }
            return (success);

        }
        public bool EnlightenW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  
            Item item2 = PTL.GetSecondItem()!;

            if( item1 == CA!.I08_Water && item2 == CA!.I00_Magic_Candle)
            {
                if( CA!.Status_Kerzenhalter.Val == 0 )
                {
                    AdvGame!.StoryOutput(loca.Enlight_Fail_NoLight);

                }
                else if ( CA!.I00_Coin.locationID != CA.I00_Nullbehaelter.ID )
                {
                    AdvGame!.StoryOutput(loca.Enlight_Fail_NoCoin);

                }
                else
                {
                    AdvGame!.StoryOutput(loca.Enlight_Find_Coin );
                    Items.TransferItem(CA!.I00_Coin.ID, CB.LocType_In_Item, CA!.I08_Well.ID);
                    CA!.Status_Coin_Entdeckt.Val = 1;

                }
                success = true;
            }

            if (!success)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.Enlight_Fail, item1!.ID, item2!.ID));
                success = true;
            }
            return (success);

        }

        public bool Light(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  

            if( item1 == CA.I00_Magic_Candle)
            {
                if( CA.Status_Kerzenhalter.Val == 0 )
                {
                    CA.Status_Kerzenhalter.Val = 1;
                    CA!.I00_Magic_Candle.LocaDescription =  "Adv_I00_Magic_Candle_Lighted";
                    CA!.I00_Magic_Candle.LocaDescriptionHandle = loca.Adv_I00_Magic_Candle_Lighted;
                    AdvGame.StoryOutput(loca.Enlighten_Magic_Candle_Yes);
                }
                else
                {
                    AdvGame.StoryOutput(loca.Enlighten_Magic_Candle_No);

                }
                success = true;
            }

            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_Light_I00_Feuerzeug_1490, item1!.ID ));
            }
            return (success);

        }

        public bool Grab(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  
            Item item2 = PTL.GetSecondItem()!;

 
            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_Grab_1491, item1!.ID, item2!.ID ));
            }
            return (success);

        }

        public bool Fry(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_Fry_I1_24_Pfanne_Oel_1492, item1!.ID, item2!.ID ));
            }
            return (success);

        }

        public void CBStealthyPhoney( )
         {
            int val = RandomNumber(0, 10);

            if( val < 2)
                AdvGame!.StoryOutput(CA!.Person_I!.locationID, CA!.Person_I!, loca.Order_CBStealthyPhoney_Person_I_1493);
            else if (val < 2)
                AdvGame!.StoryOutput(CA!.Person_I!.locationID, CA!.Person_I!, loca.Order_CBStealthyPhoney_Person_I_1494);

        }
        public bool UsePW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[3].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if( person1 == CA.Person_Fish && item2 == CA.I08_Water && CA.I00_Coin.locationID == CA.I08_Well.ID )
            {
                AdvGame!.StoryOutput(loca.UsePW_Fish_Coin );
                Items.TransferItem(CA.I00_Coin.ID, CB.LocType_Person, CA.Person_I.ID);
                CA.Status_Coin_Taken.Val = 1;
                success = true;
            }

            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID, Helper.Insert(loca.UsePW_Fail, person1!.ID, item2));
            }
            return (success);
        }

        public bool UseWP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person2 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[3].WordID);

            if (person2 == CA.Person_Fish && item1 == CA.I08_Water && CA.I00_Coin.locationID == CA.I08_Well.ID)
            {
                UsePW( PersonID, PTL);
                success = true;
            }

            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_UseWP_Person_Fette_Wache_1533, item1!.ID, person2 ));
            }
            return (success);
        }

        public bool Tie(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);


            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_Tie_I1_53_Ofen_1541, item1!.ID, item2!.ID ));
            }
            return (success);
        }

        public bool TieP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[3].WordID);

            if (!success)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_TieP_I00_Kette_1542, item2!.ID,  person1 ));
            }
            return (success);
        }

        public bool Throw(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);


            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Throw_I0_08_Fenster_1551, PersonID, item1!.ID, item2!.ID ));
            }
            return (success);
        }

        public bool ThrowP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person2  = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[3].WordID);


            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_ThrowP_Person_Dolly_1557, PersonID, item1!.ID, person2 ));
            }
            return (success);
        }
        public bool ThrowPnach(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[3].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if( person1 == CA.Person_Parrot && item2 == CA.I05_Moon && CA.I00_Lightless_Stone.locationID == CA.Person_Parrot.ID )
            {
                AdvGame.StoryOutput(loca.Throw_Parrot_Mondstein);
                Items.TransferItem(CA.I00_Moonstone.ID, CB.LocType_Person, CA.Person_I.ID);
                Items.TransferItem(CA.I00_Lightless_Stone.ID, CB.LocType_In_Item, CA.I00_Nullbehaelter.ID);
                success = true;

            }

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, Helper.Insert(loca.ThrowPersonAt_Fail, PersonID, person1!, item2.ID));
            }
            return (success);
        }

        public bool ThrowIn(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_ThrowIn_I1_03_Kamin_1566, PersonID, item1!.ID, item2!.ID ));
            }
            return (success);
        }

        public bool ThrowOut(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_ThrowOut_I1_08_Fenster_1576, PersonID, item1!.ID, item2!.ID ));
            }
            return (success);
        }

        public bool DrawDown(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_DrawDown_I1_40_Pullover_1577, item1!.ID, item1!.ID ));
            }
            return (handled);
        }

        public bool PushUp(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_PushUp_I1_40_Pullover_1578, item1!.ID, item1!.ID ));
            }
            return (handled);
        }

        public bool DrawWith(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
 
            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_DrawWith_I00_Kneifzange_1579, item1!.ID, item1!.ID, item2!.ID ));
            }
            return (handled);
        }

        public bool Draw(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Draw_I1_45_Naegel_1647, item1!.ID, item1!.ID ));
                handled = true;
            }
            return (handled);
        }

        public bool DrawOut(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_DrawOut_I1_04_Stein_Lose_1648, item1!.ID, item1!.ID ));
            }
            return (handled);
        }

        public bool DrawOff(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_DrawOff_I0_50_Bettdecke_Bacon_1649, item1!.ID, item1!.ID ));
            }
            return (handled);
        }
        public bool DrawShut(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);


            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, Helper.Insert(loca.Order_DrawShut_Fail, item1!.ID, item1!.ID));
            }
            return (handled);
        }

        public bool Push(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen

            if( item1 == CA!.I04_Cupboard && CA.I04_Flap.locationID == CA.I00_Nullbehaelter.ID )
            {
                AdvGame.StoryOutput(loca.Push_L04_Cupboard);
                Items.TransferItem(CA.I04_Flap.ID, CB.LocType_Loc, CA.L04_Shabby_Little_Chamber);
                handled = true;
            }
            else if (item1 == CA!.I08_Wooden_Cover && CA.I08_Wooden_Cover.locationID == CA.I08_Well.ID)
            {
                AdvGame.StoryOutput(loca.Push_L08_Wooden_Cover);
                Items.TransferItem(CA.I08_Wooden_Cover.ID, CB.LocType_Loc, CA.L08_Laundry_Room);
                CA.I08_Well.CanPutOn = false;
                CA.I08_Well.CanPutIn = true;
                CA.I08_Well.StorageIn = 50;

                handled = true;
            }

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Push_I2_35_Buecherhaufen_1698, item1!.ID, item1!.ID ));
            }
            return (handled);
        }

        public bool Untighten(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Untighten_I00_Blasebalg_1711, item!.ID ));
            }
            return (success);
        }

        public bool UntightenW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen

            if (!success)
            {
                AdvGame!.StoryOutput( Helper.Insert(loca.Order_UntightenW_I00_Kneifzange_1712, item1!.ID, item2!.ID ));
            }
            return (success);
        }





        public bool PushTo(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PushTo_IX_03_Regal_1715, item1!.ID, item2!.ID ));
            }
            return (success);
        }


        public bool Read( Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if( item1 == CA.I14_Writing)
            {
                AdvGame!.StoryOutput(loca.Adv_I14_Writing );
                success = true;

            }
            else if ( item1 == CA.I00_Book_Master)
            {
                GenericDialog(CA!.Person_I, BookDialog);
                success = true;

            }

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Read_I00_Prospekt_1727, PersonID, item1!.ID ));
                success = true;
            }
            return (success);
        }
        public bool ReadW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if( item2 != CA.I00_Magnifier )
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, Helper.Insert(loca.Read_Without_Magnifier, item2!.ID));
                success = true;


            }
            else if ( item1 == CA.I06_Letters && item2 == CA.I00_Magnifier )
            {
                AdvGame!.StoryOutput(loca.Read_Letters);
                CA!.Status_Antwort_Ruestung.Val = 1;
                success = true;
            }

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, Helper.Insert(loca.Order_Read_I00_Prospekt_1727, PersonID, item1!.ID));
                success = true;
            }
            return (success);
        }

        public bool Break(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Break_I1_35_Fenster_1736, PersonID, item1!.ID ));
                handled = true;
            }
            return (handled);
        }

        public bool BreakDown(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_BreakDown_I0_29_Tuer_1738, PersonID, item1!.ID ));
                handled = true;
            }
            return (handled);
        }

        public bool Split(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Split_I00_Brille_1739, item1!.ID ));
                handled = true;
            }
            return (handled);
        }

        public bool Drink(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Drink_I00_Giftflakon_1754, PersonID, item1!.ID ));
            }
            return (true);
        }

        public bool DrinkFrom(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!success)
            {
                AdvGame!.StoryOutput( Helper.Insert(loca.Order_DrinkFrom_I1_12_Blutlache_1758, PersonID, item1!.ID ));
            }
            return (success);
        }

        public bool Touch(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen

            if( item1 == CA!.I09_Angry_Book )
            {
                AdvGame!.StoryOutput(loca.Touch_Angry_Book );
                success = true;
            }
            else if (item1 == CA!.I09_Crazy_Book)
            {
                AdvGame!.StoryOutput(loca.Touch_Crazy_Book);
                success = true;
            }
            if (item1 == CA!.I09_Demonic_Book)
            {
                AdvGame!.StoryOutput(loca.Touch_Demonic_Book);
                success = true;
            }
            if (item1 == CA!.I09_Satanic_Book)
            {
                AdvGame!.StoryOutput(loca.Touch_Satanic_Book);
                success = true;
            }
            if (item1 == CA!.I09_Weird_Book)
            {
                AdvGame!.StoryOutput(loca.Touch_Weird_Book);
                success = true;
            }

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Touch_I2_29_Faeulnis_1760, PersonID, item1!.ID ));
                success = true;
            }
            return (success);
        }

        public bool TouchP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Person Person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_TouchP_Person_Stealthy_Steven_1763, PersonID, Person1 ));
                success = true;
            }
            return (success);
        }
        public bool TouchW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (  ( item1 == CA!.I09_Weird_Book || item1 == CA!.I09_Angry_Book || item1 == CA!.I09_Crazy_Book || item1 == CA!.I09_Demonic_Book || item1 == CA!.I09_Satanic_Book ) && item2 == CA!.I00_Stable_Pliers_With_Claw )
            {
                AdvGame!.StoryOutput(loca.TouchW_Books);
                success = true;
            }

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, Helper.Insert(loca.Order_TouchW_General, PersonID, item1, item2));
                success = true;
            }
            return (success);
        }


        public bool TouchPW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if( person1 == CA.Person_Owl && item2 == CA.I00_Unstable_Pliers_With_Claw )
            {

                AdvGame!.StoryOutput(loca.Touch_Owl_UnstableClaw);
                success = true;
            }
            else if (person1 == CA.Person_Knights_Armor && item2 == CA.I00_Unstable_Pliers_With_Claw)
            {

                AdvGame!.StoryOutput(loca.Touch_KnightsArmour_UnstableClaw);
                success = true;
            }
            else if (person1 == CA.Person_Librarian && item2 == CA.I00_Unstable_Pliers_With_Claw)
            {

                AdvGame!.StoryOutput(loca.Touch_Librarian_UnstableClaw);
                success = true;
            }
            else if (person1 == CA.Person_Fish && item2 == CA.I00_Unstable_Pliers_With_Claw)
            {

                AdvGame!.StoryOutput(loca.Touch_Fish_UnstableClaw);
                success = true;
            }
            else if (person1 == CA.Person_Magpie && item2 == CA.I00_Unstable_Pliers_With_Claw)
            {

                AdvGame!.StoryOutput(loca.Touch_Magpie_UnstableClaw);
                success = true;
            }
            else if (person1 == CA.Person_Snake && item2 == CA.I00_Unstable_Pliers_With_Claw)
            {

                AdvGame!.StoryOutput(loca.Touch_Snake_UnstableClaw);
                success = true;
            }
            else if (person1 == CA.Person_Parrot && item2 == CA.I00_Unstable_Pliers_With_Claw)
            {

                AdvGame!.StoryOutput(loca.Touch_Parrot_UnstableClaw);
                success = true;
            }
            else if (person1 == CA.Person_Knights_Armor && item2 == CA.I00_Stable_Pliers_With_Claw)
            {
                if( CA!.Status_Ritterruestung_Klaue.Val == 0)
                    AdvGame!.StoryOutput(loca.Touch_KnightsArmour_StableClaw_Wake );
                else
                    AdvGame!.StoryOutput(loca.Touch_KnightsArmour_StableClaw_WakeAgain);

                CA!.Status_Ritterruestung_Klaue.Val = 10;
                success = true;
            }
            else if (person1 == CA.Person_Owl && item2 == CA.I00_Stable_Pliers_With_Claw)
            {
                if( CA!.Status_Eule_Klaue.Val == 0 )
                    AdvGame!.StoryOutput(loca.Touch_Owl_StableClaw_Wake);
                else
                    AdvGame!.StoryOutput(loca.Touch_Owl_StableClaw_WakeAgain);

                CA!.Status_Eule_Klaue.Val = 10;
                success = true;
            }
            else if (person1 == CA.Person_Librarian && item2 == CA.I00_Stable_Pliers_With_Claw)
            {
                if (CA!.Status_Skelett_Klaue.Val == 0)
                    AdvGame!.StoryOutput(loca.Touch_Librarian_StableClaw_Wake);
                else
                    AdvGame!.StoryOutput(loca.Touch_Librarian_StableClaw_WakeAgain);

                CA!.Status_Skelett_Klaue.Val = 10;
                success = true;
            }
            else if (person1 == CA.Person_Fish && item2 == CA.I00_Stable_Pliers_With_Claw)
            {
                if (CA!.Status_Fisch_Klaue.Val == 0)
                    AdvGame!.StoryOutput(loca.Touch_Fish_StableClaw_Wake);
                else
                    AdvGame!.StoryOutput(loca.Touch_Fish_StableClaw_WakeAgain);

                CA!.Status_Fisch_Klaue.Val = 10;
                success = true;
            }
            else if (person1 == CA.Person_Snake && item2 == CA.I00_Stable_Pliers_With_Claw)
            {
                if (CA!.Status_Schlange_Klaue.Val == 0)
                    AdvGame!.StoryOutput(loca.Touch_Snake_StableClaw_Wake);
                else
                    AdvGame!.StoryOutput(loca.Touch_Snake_StableClaw_WakeAgain);

                CA!.Status_Schlange_Klaue.Val = 10;
                success = true;
            }
            else if (person1 == CA.Person_Magpie && item2 == CA.I00_Stable_Pliers_With_Claw)
            {
                if (CA!.Status_Elster_Klaue.Val == 0)
                    AdvGame!.StoryOutput(loca.Touch_Magpie_StableClaw_Wake);
                else
                    AdvGame!.StoryOutput(loca.Touch_Magpie_StableClaw_WakeAgain);

                CA!.Status_Elster_Klaue.Val = 10;
                success = true;
            }
            else if (person1 == CA.Person_Parrot && item2 == CA.I00_Stable_Pliers_With_Claw)
            {
                if (CA!.Status_Papagei_Klaue.Val == 0)
                    AdvGame!.StoryOutput(loca.Touch_Parrot_StableClaw_Wake);
                else
                    AdvGame!.StoryOutput(loca.Touch_Parrot_StableClaw_WakeAgain);

                CA!.Status_Papagei_Klaue.Val = 10;
                success = true;
            }

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, Helper.Insert(loca.Order_TouchPW_General, PersonID, person1, item2 ));
                success = true;
            }
            return (success);
        }

        public bool Fish(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item = PTL.GetFirstItem()!;

            {
                AdvGame!.StoryOutput( loca.Order_Fish_I00_Nullbehaelter2_1765);
                success = true;
            }

            if ( success == false )
            {
                AdvGame!.StoryOutput( Helper.Insert(loca.Order_Fish_I00_Nullbehaelter2_1766,  item!.ID ));

            }

            return (success);
        }

        public bool FishWith(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!handled)
            {
                if (success)
                {
                    success = Fish(PersonID, PTL);
                }
                else
                {
                    AdvGame!.StoryOutput(  Helper.Insert(loca.Order_FishWith_I00_Stock_lang_1768, item2!.ID ));
                }
            }
            else
                success = handled;

            return (success);
        }

        public bool Saw(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Saw_I00_Laubsaege_1771, item1!.ID, item2!.ID ));
            }

            return (success);
        }


        public bool SawSolo(Person PersonID, ParseTokenList PTL)
        {
            bool success = false; 

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, loca.Order_SawSolo_I00_Laubsaege_1772);
            }
            return success;
        }


        public bool Cut(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2 = PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Cut_I00_Glasschneider_1780, item1!.ID, item2!.ID ));
            }

            return (success);
        }


        public bool Eat(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Eat_I00_Regenwuermer_1802, item!.ID ));
                success = true;
            }
            return (success);

        }

        public bool EatP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person = PTL.GetFirstPerson()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_EatP_Person_I_1805, person ));
                success = true;
            }
            return (success);

        }

        public bool Sell(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Sell_1806, item!.ID ));
                success = true;
            }
            return (success);

        }

        public bool Pick(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Pick_I1_28_Blume_1810, item!.ID ));
                success = true;
            }
            return (success);

        }

        public bool CatchP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person = PTL.GetFirstPerson()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_CatchP_Person_Everyone_1813, person ));
                success = true;
            }
            return (success);

        }

        public bool SellTo(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item = PTL.GetFirstItem()!;
            Person person = PTL.GetFirstPerson()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_SellTo_1814, item!.ID, person ));
            }
            return (success);

        }

        public bool Fill(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Fill_1815, item!.ID ));
                success = true;
            }
            return (success);

        }

        public bool Joggle(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Joggle_I0_02_Zellentuer_rechts_1822, item!.ID ));
                success = true;
            }
            return (success);

        }

        public bool Sleep(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Sleep_I1_08_Bett_1825, item!.ID ));
                success = true;
            }
            return (success);

        }

        public bool SleepSolo(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, loca.Order_SleepSolo_1826);
                success = true;
            }
            return (success);

        }

        public bool Park(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            Item item = PTL.GetFirstItem()!;

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Park_I00_Karren_1828, item!.ID ));
                handled = true;
            }
            return (handled);

        }


        public bool FillW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_FillW_I1_45_Heliumbehaelter_1854, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool FillIn(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_FillIn_I00_Kanister_Verduennung_1855, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool StuffIn(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_StuffIn_I00_Kanister_Verduennung_1856, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool Remove(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Remove_I0_49_Kabelisolierung_1857, item1!.ID ));
                success = true;
            }
            return (success);

        }

        public bool Search(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Search_I0_49_Strohballen_1864, item1!.ID ));
                success = true;
            }
            return (success);

        }

        public bool SearchW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_SearchW_I00_Vuvuzela_1865, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }
        public bool SearchP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.Order_Search_Person, person1));
                success = true;
            }
            return (success);

        }

        public bool SearchWP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;
            Item item2 = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.Order_Search_Person_W, person1, item2!.ID));
                success = true;
            }
            return (success);

        }

        public bool Poke(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Poke_I0_12_Maden_1866, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool PokeRev(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PokeRev_I0_12_Maden_1867, item2!.ID, item1!.ID ));
                success = true;
            }
            return (success);

        }

        public bool Dig(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Dig_I0_33_Graeber_1870, item1!.ID ));
                success = true;
            }
            return (success);

        }

        public bool WakeP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_WakeP_Person_Tristan_PV1_tot_1873, person1, person1 ));
                success = true;
            }
            return (success);

        }

        public bool Shout(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            if (!success)
            {
                AdvGame!.StoryOutput( loca.Order_Shout_1879);
                success = true;
            }
            return (success);

        }

        public bool CleanIn(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_CleanIn_I1_46_Wasserhahn_1880, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool CleanW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;


            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_CleanW_Person_I_1885, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }
        public bool CleanPW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;
            Item item2 = PTL.GetFirstItem()!;

            if( person1 == CA.Person_Knights_Armor && item2 == CA.I00_Polishing_Rag && CA.I06_Letters.locationID == CA.I00_Nullbehaelter.ID )
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.CleanPW_Knights_Armour ));
                Items.TransferItem(CA.I06_Letters.ID, CB.LocType_Loc, CA.L06_Long_Floor);
                success = true;
            }

            if (!success)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.CleanPW_General, person1!, item2!.ID));
                success = true;
            }
            return (success);

        }

        public bool WashIn(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_WashIn_I1_46_Wasserhahn_1886, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool DetermineW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_DetermineW_I00_Botanikbuch_1887, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool PickW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_PickW_1888, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool PlaceTo(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_PlaceTo_I00_Vogelbauer_1890, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool TickleW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;
            Item item2 = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_TickleW_Person_Phoney_PV1_1892,  person1, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool BeatW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;
            Item item2 = PTL.GetFirstItem()!;



            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_BeatW_Person_Ghoul_Kerker_PV1_1895, person1, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool KillW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;
            Item item2 = PTL.GetFirstItem()!;


            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_KillW_Person_Tristan_PV1_1899, person1, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool Hide(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Hide_I1_13_Vorhang_1904, item1!.ID ));
                success = true;
            }
            return (success);

        }

        public bool BurnW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_BurnW_I00_Feuerzeug_1911, item1!.ID, item2!.ID ));
                success = true;
            }
            return success;
        }

        public bool BurnIn(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_BurnIn_I1_03_Kamin_1919, item1!.ID, item2!.ID ));
                success = true;
            }
            return success;
        }

        public bool Burn(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;

            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Burn_I00_Kohle_glimmend_1920, item1!.ID ));
                success = true;
            }
            return (success);

        }

        public bool Tear(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;

            if ( !success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Tear_I00_Nullbehaelter2_1928, item1!.ID ));
                success = true;
            }
            return (success);

        }

        public bool Testwindow(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            AdvGame!.UIS!.StartTestWindow();
            return (success);

        }

        public bool Brief(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            AdvGame!.GD!.Brief = true;
            AdvGame!.StoryOutput( loca.Order_Brief_1929);
            return (success);

        }

        public bool Verbose(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            AdvGame!.GD!.Brief = false;
            AdvGame!.StoryOutput( loca.Order_Verbose_1930);
            return (success);

        }

        public bool RipOff(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_RipOff_I00_Zeitung_abscheulich_1932, item1!.ID ));
                success = true;
            }
            return (success);

        }

        public bool PhoneW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PhoneW_I0_10_Dosentelefon_1933, item1!.ID ));
                success = true;
            }
            return (success);

        }

        public bool Phone(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            if (!success)
            {
                AdvGame!.StoryOutput( loca.Order_Phone_I00_Smartphone_1934);
                success = true;
            }
            return (success);

        }


        public bool Credits(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.StoryOutput( loca.Order_Credits_1935);
            AdvGame!.StoryOutput( loca.Order_Credits_1936);
            AdvGame!.StoryOutput( loca.Order_Credits_1937);

            // AdvGame!.Orders.GenericDialog(null, AdvGame!.Orders.SetupDialog);

            return (true);

        }

        public bool IllustrationSmall(Person PersonID, ParseTokenList PTL)
        {
            GD!.PicMode = IGlobalData.picMode.small;
            // AdvGame!.A!.PicSize = AdvData.picSize.small;

            AdvGame!.StoryOutput( loca.Order_IllustrationSmall_1938);
            AdvGame!.StoryOutput(loca.Order_IllustrationInfo);

            // AdvGame!.Orders.GenericDialog(null, AdvGame!.Orders.SetupDialog);

            return (true);

        }

        public bool IllustrationMediocre(Person PersonID, ParseTokenList PTL)
        {
            GD!.PicMode = IGlobalData.picMode.medium;
            // AdvGame!.A!.PicSize = AdvData.picSize.medium;

            AdvGame!.StoryOutput( loca.Order_IllustrationMediocre_1939);
            AdvGame!.StoryOutput(loca.Order_IllustrationInfo);

            // AdvGame!.Orders.GenericDialog(null, AdvGame!.Orders.SetupDialog);

            return (true);

        }

        public bool IllustrationLarge(Person PersonID, ParseTokenList PTL)
        {
            GD!.PicMode = IGlobalData.picMode.big;
            // AdvGame!.A!.PicSize = AdvData.picSize.large;

            AdvGame!.StoryOutput( loca.Order_IllustrationLarge_1940);
            AdvGame!.StoryOutput(loca.Order_IllustrationInfo);

            // AdvGame!.Orders.GenericDialog(null, AdvGame!.Orders.SetupDialog);

            return (true);

        }

        public bool IllustrationOff(Person PersonID, ParseTokenList PTL)
        {
            GD!.PicMode = IGlobalData.picMode.off;
            // AdvGame!.A!.PicSize = AdvData.picSize.none;

            AdvGame!.StoryOutput( loca.Order_IllustrationOff_1941);

            // AdvGame!.Orders.GenericDialog(null, AdvGame!.Orders.SetupDialog);

            return (true);

        }
        public bool Undo(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.StoryOutput(loca.Order_Undo_Info );

            // AdvGame!.Orders.GenericDialog(null, AdvGame!.Orders.SetupDialog);

            return (true);

        }

        public bool GameInfo(Person PersonID, ParseTokenList PTL)
        {
            for (int ix = 0; ix < 1; ix++)
            {
                AdvGame!.StoryOutput(loca.Order_GameInfo_1942);
                AdvGame!.StoryOutput(loca.Order_GameInfo_1943);
                AdvGame!.StoryOutput(loca.Order_GameInfo_1944);
                AdvGame!.StoryOutput(loca.Order_GameInfo_1945);
                AdvGame!.StoryOutput(loca.Order_GameInfo_1946);
                AdvGame!.StoryOutput(loca.Order_GameInfo_1947);
                AdvGame!.StoryOutput(loca.Order_GameInfo_1948);
                AdvGame!.StoryOutput(String.Format(loca.Order_GameInfo_1949, AdvGame!.GD!.Version.Version1, AdvGame!.GD!.Version.Version2, AdvGame!.GD!.Version.Version3, AdvGame!.GD!.Version.VersionDate.Day, AdvGame!.GD!.Version.VersionDate.Month, AdvGame!.GD!.Version.VersionDate.Year));
            }
            // AdvGame!.Orders.GenericDialog(null, AdvGame!.Orders.SetupDialog);

            return (true);

        }

        public bool Smoke(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;


            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_Smoke_1950, item1!.ID ));
                success = true;
            }
            return (success);

        }

        public bool TakeDown(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.Order_Take_Down, item1!.ID));
                success = true;
            }
            return (success);

        }
        public bool Play(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.Order_Play, item1!.ID));
                success = true;
            }
            return (success);

        }

        public bool HideP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;
            Item item2 = PTL.GetFirstItem()!;

            if (person1!.ID == CA!.Person_I!.ID)
            {
                Hide(PersonID, PTL);

                success = true;
            }

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_HideP_Person_I_1951, person1, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool Tickle(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;


            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Tickle_Person_Phoney_PV1_1953, person1 ));
                success = true;
            }
            return (success);

        }

        public bool Kill(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Kill_I00_Nullbehaelter_1958, person1 ));
                success = true;
            }
            return (success);

        }

        public bool Beat(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Beat_Person_Phoney_PV1_1960, person1 ));
                success = true;
            }
            return (success);

        }

        public bool Fuck(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Fuck_Person_Phoney_PV1_1962, person1 ));
                success = true;
            }
            return (success);

        }

        public bool LickP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_LickP_Person_Phoney_PV1_1964, person1 ));
                success = true;
            }
            return (success);

        }

        public bool Lick(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Lick_IX_03_Spiegel_1966, item1!.ID ));
                success = true;
            }
            return (success);

        }

        public bool SingSolo(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;

            AdvGame!.StoryOutput( loca.Order_SingSolo_1967);

            return (success);

        }

        public bool Sing(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Topic topic1 = PTL.GetFirstTopic()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, loca.Order_Sing_1969);
                success = true;
            }
            return (success);

        }

        public bool Cuddle(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;
            
            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Cuddle_Person_Phoney_PV1_1971, person1 ));
                success = true;
            }
            return (success);

        }

        public bool Pet(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Person person1 = PTL.GetFirstPerson()!;
            
            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_Pet_Person_Phoney_PV1_1973, person1 ));
                success = true;
            }
            return (success);

        }

        public bool WrapP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person2 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[3].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen

            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_WrapP_Person_Ludmilla_PV1_1974, item1!.ID, person2 ));
            }
            return (success);
        }

        public bool WrapP2(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person2 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[3].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_WrapP_Person_Ludmilla_PV1_1975, person2, item1!.ID ));
            }
            return (success);
        }
        public bool WrapAround(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Item item2= PTL.GetSecondItem()!; //  GetItemRef(Adv_PT[3].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if( item1 == CA.I00_Roll_Plaster && item2 == CA.I00_Unstable_Pliers_With_Claw)
            {
                AdvGame.StoryOutput(loca.Wrap_Rollpflaster_Pliers_Ok);
                Items.TransferItem(CA.I00_Unstable_Pliers_With_Claw.ID, CA.I00_Nullbehaelter.ID);
                Items.TransferItem(CA.I00_Stable_Pliers_With_Claw.ID, CB.LocType_Person, CA!.Person_I.ID);
                success = true;
            }

            if (!success)
            {
                AdvGame!.StoryOutput(Helper.Insert(loca.Order_WrapP_Person_Ludmilla_PV1_1975, item2, item1!.ID));
            }
            return (success);
        }


        public bool PaintP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item2 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);
            Person person1 = PTL.GetFirstPerson()!; //  GetItemRef(Adv_PT[3].WordID);

            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            if (!success)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_PaintP_Person_Ludmilla_1976, person1, item2!.ID ));
            }
            return (success);
        }

        public bool Wear(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            success = Dress(PersonID, PTL);
            // Hier Erfolgsoperationen auflisten und Success auf true setzen
            return (success);
        }


        public bool PlaceToP(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Person person2 = PTL.GetFirstPerson()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_PlaceToP_I00_Vogelbauer_1978, item1!.ID, person2 ));
                success = true;
            }
            return (success);

        }

        public bool PinchW(Person PersonID, ParseTokenList PTL)
        {
            bool success = false;

            Item item1 = PTL.GetFirstItem()!;
            Item item2 = PTL.GetSecondItem()!;

            if (!success)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID,  Helper.Insert(loca.Order_PinchW_I00_Kneifzange_1979, item1!.ID, item2!.ID ));
                success = true;
            }
            return (success);

        }

        public bool BuryP(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;

            Item item2 = PTL.GetFirstItem()!;
            Person person1 = PTL.GetFirstPerson()!;

            BuryPSolo(PersonID, PTL);

            return (success);

        }

        public bool BuryPSolo(Person PersonID, ParseTokenList PTL)
        {
            bool success = true;

            Person person1 = PTL.GetFirstPerson()!;

            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_BuryPSolo_Person_Tristan_PV1_tot_1988, person1 ));
                BuryPSolo(PersonID, PTL);
            }

            return (success);

        }


        public virtual bool  HelpFor(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            Item item = PTL.GetFirstItem()!;

            AdvGame!.StoryOutput(  Helper.Insert(loca.Order_HelpFor_1989, item!.ID ));
            return (handled);
        }

        public virtual bool  HelpForP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            Person person = PTL.GetFirstPerson()!;

            if (!handled)
            {
                AdvGame!.StoryOutput(  Helper.Insert(loca.Order_HelpForP_1990, person ));
            }
            return (handled);
        }

        public virtual bool  Info(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            if ( !handled)
            {
                AdvGame!.FeedbackOutput(PersonID, loca.Order_Info_Person_I_2170);
                handled = true;
            }
            return (handled);
        }

        public virtual bool  InfoFor(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            Item item = PTL.GetFirstItem()!;

            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_InfoFor_I00_Spielgeldbogen_2204, item!.ID ));
            }
            return (handled);
        }

        public virtual bool  InfoForP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            Person person = PTL.GetFirstPerson()!;

            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_InfoForP_Person_Dolly_2210, person ));
            }
            return (handled);

        }

        public virtual bool  ClueFor(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            Item item = PTL.GetFirstItem()!;

            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_ClueFor_I00_Spielgeldbogen_2215, item!.ID ));
            }
            return (handled);
        }

        public virtual bool  ClueForP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            Person person = PTL.GetFirstPerson()!;

            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_ClueForP_2216, person ));
            }
            return (handled);
        }

        public virtual bool  SolutionFor(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            Item item = PTL.GetFirstItem()!;

            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_SolutionFor_I0_13_Dosen_2220, item!.ID ));
            }
            return (handled);
        }

        public virtual bool  SolutionForP(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;

            Person person = PTL.GetFirstPerson()!;

            if (!handled)
            {
                AdvGame!.FeedbackOutput(PersonID,  Helper.Insert(loca.Order_SolutionForP_2221, person ));
            }
            return (handled);
        }


        public bool Help(Person PersonID, ParseTokenList PTL)
        {
            AdvGame!.StoryOutput( loca.Order_Help_2222);
            return false;
        }

        public bool WriteStory(Person PersonID, ParseTokenList PTL)
        {
            if( AdvGame!.UIS!.WriteStory() )
                AdvGame!.StoryOutput(loca.Order_Story_Info);

            return false;
        }


        public bool DoSomething(List<MCMenuEntry> tMCE)
        {
            // AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, PersonID, "Schubidu");

            return (false);
        }


        public override bool  Save(Person PersonID, ParseTokenList PTL)
        {
            if (AdvGame!.GD!.SilentMode)
            {
                AdvGame!.StoryOutput( loca.Order_Save_2223);
                return false;
            }
            if (PTL.Index(1)!.O == null) return (false);

            Prep slotID = ((Prep)PTL.Index(1)!.O!);
#pragma warning disable CS0219 // Die Variable "slotNr" ist zugewiesen, ihr Wert wird aber nie verwendet.
            int slotNr;
#pragma warning restore CS0219 // Die Variable "slotNr" ist zugewiesen, ihr Wert wird aber nie verwendet.

            if (slotID == CB!.Prep_Slot1) slotNr = 1;
            else if (slotID == CB!.Prep_Slot2) slotNr = 2;
            else if (slotID == CB!.Prep_Slot3) slotNr = 3;
            else if (slotID == CB!.Prep_Slot4) slotNr = 4;
            else if (slotID == CB!.Prep_Slot5) slotNr = 5;
            else if (slotID == CB!.Prep_Slot6) slotNr = 6;
            else if (slotID == CB!.Prep_Slot7) slotNr = 7;
            else if (slotID == CB!.Prep_Slot8) slotNr = 8;
            else if (slotID == CB!.Prep_Slot9) slotNr = 9;
            else if (slotID == CB!.Prep_Slot10) slotNr = 10;
            else slotNr = 1;

            bool success = true;

            // Pre

            // base
            if (success)
                success = base.Save(Persons!.Find( A!.ActPerson )!, PTL);

            // Post

            return (false);
        }

        public override bool  Load(Person PersonID, ParseTokenList PTL)
        {
            if (AdvGame!.GD!.SilentMode)
            {
                AdvGame!.StoryOutput( loca.Order_Load_2224);
                return false;
            }
            if (PTL.Index(1)!.O == null) return (false);

            Prep slotID = ((Prep)PTL.Index(1)!.O!);
#pragma warning disable CS0219 // Die Variable "slotNr" ist zugewiesen, ihr Wert wird aber nie verwendet.
            int slotNr;
#pragma warning restore CS0219 // Die Variable "slotNr" ist zugewiesen, ihr Wert wird aber nie verwendet.

            if (slotID == CB!.Prep_Slot1) slotNr = 1;
            else if (slotID == CB!.Prep_Slot2) slotNr = 2;
            else if (slotID == CB!.Prep_Slot3) slotNr = 3;
            else if (slotID == CB!.Prep_Slot4) slotNr = 4;
            else if (slotID == CB!.Prep_Slot5) slotNr = 5;
            else if (slotID == CB!.Prep_Slot6) slotNr = 6;
            else if (slotID == CB!.Prep_Slot7) slotNr = 7;
            else if (slotID == CB!.Prep_Slot8) slotNr = 8;
            else if (slotID == CB!.Prep_Slot9) slotNr = 9;
            else if (slotID == CB!.Prep_Slot10) slotNr = 10;
            else slotNr = 1;

            bool success = true;

            // Pre

            // base
            if (success)
                success = base.Load( Persons!.Find( A!.ActPerson )!, PTL );

            // Post

            success = AdvGame!.DoUIUpdate();

            return (false);
        }


        public bool Restart01(List<MCMenuEntry> MCMEntry)
        {
            AdvGame!.DoMCRestartSlot( MCMEntry, 1);

            return (false);
        }


        public bool Restart09(List<MCMenuEntry> MCMEntry)
        {
            AdvGame!.DoMCRestartSlot(MCMEntry, 9);

            return (false);
        }
        public bool TipSolo(Person PersonID, ParseTokenList PTL)
        {
            bool handled = false;
            Item item1 = PTL.GetFirstItem()!; //  GetItemRef(Adv_PT[1].WordID);

            if (!handled)
            {
                AdvGame!.StoryOutput(Persons!.Find(PersonID)!.locationID, CA!.Person_Everyone,  Helper.Insert(loca.Order_TipSolo_Person_Everyone_822, item1!.ID ));
            }
            return (handled);
        }

    }
}