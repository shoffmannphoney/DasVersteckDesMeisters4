using System;
using System.Collections.Generic;
using System.Diagnostics;

using Phoney_MAUI.Model;

namespace GameCore
{


    public partial class Order: AbstractOrder
    {

        private int ChoiceIx( int ix)
        {
            return (ix * 10);
        }


        public virtual bool  InfoMC(Person PersonID, ParseTokenList PTL)
        {
            /*
            if( AdvGame!.GD!.SilentMode )
            {
                AdvGame!.StoryOutput( "Keine Hilfe-Modus-Ausführung während des Replays");
                return false;
            }
            */
            AdvGame!.StoryOutput( loca.Order_InfoMC_10360);
            GenericDialog(PersonID, InfoMCDialog, true, null, null, true);


            bool handled = true;
            return handled;
        }


        public int CalcIx( int off )
        {
            return (300000 + (off * 100));
        }

        public void InfoMCDialog(MCMenu mcM, List<int> tFollower, List<int> cFollower)
        {
            // bool handled = false;
            mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Order_InfoMCDialog_Person_Self_10361, 1, 1 + CB!.MCE_Choice_Off, true));

            int ix = 10000;
            AdvGame!.GenericTipps = new();


            // ix = CalcIx(CA!.imc_Start_dialog);
            cFollower.Add(ix);
            mcM.Add(new MCMenuEntry(null, loca.Order_InfoMCDialog_Person_Self_10362, ix, CB!.MCE_Choice1, true, true));
            ix += 10;


            ix = CalcIx(CA!.imc_Start);
            if (locations.Find( CA!.L02_In_Front_Of_A_Hut ).Visited == false )
            {
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Start, ix, CB!.MCE_Choice1, true, true));
                ix += 10;
            }
            ix = CalcIx(CA!.imc_Suche_Versteck);
            if (locations.Find(CA!.L02_In_Front_Of_A_Hut).Visited == true && locations.Find(CA!.L05_Atrium ).Visited == false)
            {
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Suche_Versteck, ix, CB!.MCE_Choice1, true, true));
                ix += 10;
            }
            ix = CalcIx(CA!.imc_Pentagramm);
            if (locations.Find(CA!.L03_In_The_Parlor ).Visited == true && locations.Find(CA!.L05_Atrium).Visited == false )
            {
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Pentagramm, ix, CB!.MCE_Choice1, true, true));
                ix += 10;
            }

            ix = CalcIx(CA!.imc_Atrium_Ankunft);
            if (locations.Find(CA!.L05_Atrium).Visited == true && CA.Status_Klaue_Nehmversuch.Val == 0 && CA.I00_Claw.locationID == CA.I05_Pedestal.ID )
            {
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Atrium_Ankunft, ix, CB!.MCE_Choice1, true, true));
                ix += 10;
            }
            ix = CalcIx(CA!.imc_Klaue_nicht_nehmbar);
            if ( CA.Status_Klaue_Nehmversuch.Val == 1 && CA.I00_Claw.locationID == CA.I05_Pedestal.ID)
            {
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Klaue_nicht_nehmbar, ix, CB!.MCE_Choice1, true, true));
                ix += 10;
            }

            ix = CalcIx(CA!.imc_Klaue_nicht_fixiert);
            if ( CA.I00_Unstable_Pliers_With_Claw.locationID != CA.I00_Nullbehaelter.ID && CA.I00_Unstable_Pliers_With_Claw.locationID != CA.I00_Nullbehaelter2.ID)
            {
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Klaue_nicht_fixiert, ix, CB!.MCE_Choice1, true, true));
                ix += 10;
            }
            ix = CalcIx(CA!.imc_Klaue_noch_niemand_belebt );
            if (CA.I00_Stable_Pliers_With_Claw.locationID != CA.I00_Nullbehaelter.ID && CA.Score_Erste_Belebung.Active == false )
            {
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Klaue_noch_niemand_belebt, ix, CB!.MCE_Choice1, true, true));
                ix += 10;
            }
            else  if (CA.I00_Stable_Pliers_With_Claw.locationID != CA.I00_Nullbehaelter.ID && CA.Score_Erstes_Gespraech.Active == false)
            {
                ix = CalcIx(CA!.imc_Klaue_noch_niemand_gesprochen);
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Klaue_noch_niemand_gesprochen, ix, CB!.MCE_Choice1, true, true));
                ix += 10;
            }


            cFollower.Add(ix);
            mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Order_InfoMCDialog_Person_Self_11228, ix, -1, true, false));
            ix += 10;

            // MC-Menü wird gesetzt
            mcM.Add(new MCMenuEntry(1 + CB!.MCE_Choice_Off, cFollower));
            if( AdvGame!.UIS!.MCM != null)
            {
                /*
                if( AdvGame!.UIS!.MCM.DoRecording == true)
                    AdvGame!.UIS!.MCM.DoRecording = false;
                */
            }
        }


        public void CalcGenericTipp(MCMenu mcM, Score scoreentry, int ix)
        {
            // Während der SilentMode läuft, müssen hier keine Menüeinträge justiert werden
            if (AdvGame!.GD!.SilentMode == true) return;

            if( scoreentry.SpoilerState >= spoiler.tipp)
            {
                mcM.FindID(ChoiceIx(ix) + 2)!.Hidden = MCMenuEntry.HiddenType.visible;
                mcM.FindID(ChoiceIx(ix) + 3)!.Hidden = MCMenuEntry.HiddenType.hidden;
            }
            else
            {
                mcM.FindID(ChoiceIx(ix) + 2)!.Hidden = MCMenuEntry.HiddenType.hidden;
                mcM.FindID(ChoiceIx(ix) + 3)!.Hidden = MCMenuEntry.HiddenType.visible;
            }

            if (scoreentry.SpoilerState >= spoiler.spoiler)
            {
                mcM.FindID(ChoiceIx(ix) + 4)!.Hidden = MCMenuEntry.HiddenType.visible;
                mcM.FindID(ChoiceIx(ix) + 5)!.Hidden = MCMenuEntry.HiddenType.hidden;
            }
            else
            {
                mcM.FindID(ChoiceIx(ix) + 4)!.Hidden = MCMenuEntry.HiddenType.hidden;
                mcM.FindID(ChoiceIx(ix) + 5)!.Hidden = MCMenuEntry.HiddenType.visible;
            }
            if (scoreentry.SpoilerState >= spoiler.solution)
            {
                mcM.FindID(ChoiceIx(ix) + 6)!.Hidden = MCMenuEntry.HiddenType.visible;
                mcM.FindID(ChoiceIx(ix) + 7)!.Hidden = MCMenuEntry.HiddenType.hidden;
            }
            else
            {
                mcM.FindID(ChoiceIx(ix) + 6)!.Hidden = MCMenuEntry.HiddenType.hidden;
                mcM.FindID(ChoiceIx(ix) + 7)!.Hidden = MCMenuEntry.HiddenType.visible;
            }
        }


        public void SetGenericTipps( MCMenu mcM, string headline, Score scoreentry, int ix )
        {
            List<int> cFollower2 = new();

            cFollower2.Add(ChoiceIx(ix) + 1);
            mcM.Add(new MCMenuEntry(null, headline, ChoiceIx(ix) + 1, ChoiceIx(ix) + 1, false));

            cFollower2.Add(ChoiceIx(ix) + 2);
            mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Order_SetGenericTipps_Person_Self_11229, ChoiceIx(ix) + 2, ChoiceIx(ix) + 10, true, false));
            cFollower2.Add(ChoiceIx(ix) + 3);
            mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Order_SetGenericTipps_Person_Self_11230, ChoiceIx(ix) + 3, ChoiceIx(ix) + 10, true, false));
            // mcM.Add(new MCMenuEntry(CA!.Person_Self, "Tipp (25% Punktabzug)", ChoiceIx(ix) + 3, ChoiceIx(ix) + 10, true, false));

            cFollower2.Add(ChoiceIx(ix) + 4);
            mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Order_SetGenericTipps_Person_Self_11231, ChoiceIx(ix) + 4, ChoiceIx(ix) + 20, true, false));
            cFollower2.Add(ChoiceIx(ix) + 5);
            mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Order_SetGenericTipps_Person_Self_11232, ChoiceIx(ix) + 5, ChoiceIx(ix) + 20, true, false));
            // mcM.Add(new MCMenuEntry(CA!.Person_Self, "Hilfe (50% Punktabzug)", ChoiceIx(ix) + 5, ChoiceIx(ix) + 20, true, false));

            cFollower2.Add(ChoiceIx(ix) + 6);
            mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Order_SetGenericTipps_Person_Self_11233, ChoiceIx(ix) + 6, ChoiceIx(ix) + 30, true, false));
            cFollower2.Add(ChoiceIx(ix) + 7);
            mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Order_SetGenericTipps_Person_Self_11234, ChoiceIx(ix) + 7, ChoiceIx(ix) + 30, true, false));
            // mcM.Add(new MCMenuEntry(CA!.Person_Self, "Lösung (75% Punktabzug)", ChoiceIx(ix) + 7, ChoiceIx(ix) + 30, true, false));

            cFollower2.Add(ChoiceIx(ix) + 8);
            mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Order_SetGenericTipps_Person_Self_11235, ChoiceIx(ix) + 8, CB!.MCE_Choice1, true, false));

            mcM.Add(new MCMenuEntry(ChoiceIx(ix), cFollower2));

            CalcGenericTipp(mcM, scoreentry, ix );

            AdvGame!.GenericTipps!.Add(new GenericTipp(mcM, headline, scoreentry!, ix));
        }


        public void CalcGenericTipps( MCMenu mcM )
        {
            foreach( GenericTipp gt in AdvGame!.GenericTipps!)
            {
                CalcGenericTipp(mcM, gt.scoreentry, gt.ix);
            }
        }

    }

    public class GenericTipp
    {

        public MCMenu mcM { get; set; }

        public string headline { get; set; }

        public Score scoreentry { get; set; }

        public int ix { get; set; }


        public GenericTipp(MCMenu mcM, string headline, Score scoreentry, int ix)
        {
            this.mcM = mcM;
            this.headline = headline;
            this.scoreentry = scoreentry;
            this.ix = ix;
        }
    }

}
