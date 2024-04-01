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
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Suche_Versteck, ix, ChoiceIx(ix), true, false));
                SetGenericTipps(mcM, loca.Info_Suche_Versteck_0, CA!.Score_Transfer1!, ix);

                mcM.AddEntry(null, loca.Info_Suche_Versteck_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(SucheVersteck25);

                mcM.AddEntry(null, loca.Info_Suche_Versteck_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(SucheVersteck50);

                mcM.AddEntry(null, loca.Info_Suche_Versteck_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(SucheVersteck75);


                // ix += 30;
            }
            ix = CalcIx(CA!.imc_Pentagramm);
            if (locations.Find(CA!.L03_In_The_Parlor ).Visited == true && locations.Find(CA!.L05_Atrium).Visited == false )
            {
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Pentagramm, ix, ChoiceIx(ix), true, false));
                SetGenericTipps(mcM, loca.Info_Pentagramm_0, CA!.Score_Transfer1!, ix);

                mcM.AddEntry(null, loca.Info_Pentagramm_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(SucheVersteck25);

                mcM.AddEntry(null, loca.Info_Pentagramm_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(SucheVersteck50);

                mcM.AddEntry(null, loca.Info_Pentagramm_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(SucheVersteck75);
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
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Klaue_nicht_nehmbar, ix, ChoiceIx(ix), true, false));
                SetGenericTipps(mcM, loca.Info_Klaue_nicht_nehmbar_0, CA!.Score_Klauenzange1!, ix);

                mcM.AddEntry(null, loca.Info_Klaue_nicht_nehmbar_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(Klauenzange1_25);

                mcM.AddEntry(null, loca.Info_Klaue_nicht_nehmbar_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(Klauenzange1_50);

                mcM.AddEntry(null, loca.Info_Klaue_nicht_nehmbar_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(Klauenzange1_75);
            }

            ix = CalcIx(CA!.imc_Klaue_nicht_fixiert);
            if ( CA.I00_Unstable_Pliers_With_Claw.locationID != CA.I00_Nullbehaelter.ID && CA.I00_Unstable_Pliers_With_Claw.locationID != CA.I00_Nullbehaelter2.ID)
            {
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Klaue_nicht_fixiert, ix, ChoiceIx(ix), true, false));
                SetGenericTipps(mcM, loca.Info_Klaue_nicht_fixiert_0, CA!.Score_Klauenzange2!, ix);

                mcM.AddEntry(null, loca.Info_Klaue_nicht_fixiert_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(Klauenzange2_25);

                mcM.AddEntry(null, loca.Info_Klaue_nicht_fixiert_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(Klauenzange2_50);

                mcM.AddEntry(null, loca.Info_Klaue_nicht_fixiert_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(Klauenzange2_75);
            }
            ix = CalcIx(CA!.imc_Klaue_noch_niemand_belebt );
            if (CA.I00_Stable_Pliers_With_Claw.locationID != CA.I00_Nullbehaelter.ID && CA.Score_Erste_Belebung.Active == false )
            {
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Klaue_noch_niemand_belebt, ix, ChoiceIx(ix), true, false));
                SetGenericTipps(mcM, loca.Info_Klaue_noch_niemand_belebt_0, CA!.Score_Erste_Belebung!, ix);

                mcM.AddEntry(null, loca.Info_Klaue_noch_niemand_belebt_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(ErsteBelebung25);

                mcM.AddEntry(null, loca.Info_Klaue_noch_niemand_belebt_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(ErsteBelebung50);

                mcM.AddEntry(null, loca.Info_Klaue_noch_niemand_belebt_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(ErsteBelebung75);
            }
            else  if (CA.I00_Stable_Pliers_With_Claw.locationID != CA.I00_Nullbehaelter.ID && CA.Score_Erstes_Gespraech.Active == false)
            {
                ix = CalcIx(CA!.imc_Klaue_noch_niemand_gesprochen);
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Klaue_noch_niemand_gesprochen, ix, ChoiceIx(ix), true, false));
                SetGenericTipps(mcM, loca.Info_Klaue_noch_niemand_gesprochen_0, CA.Score_Erstes_Gespraech!, ix);

                mcM.AddEntry(null, loca.Info_Klaue_noch_niemand_gesprochen_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(ErstesGespraech25);

                mcM.AddEntry(null, loca.Info_Klaue_noch_niemand_gesprochen_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(ErstesGespraech50);

                mcM.AddEntry(null, loca.Info_Klaue_noch_niemand_gesprochen_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(ErstesGespraech75);
            }

            ix = CalcIx(CA!.imc_Uhu_Fragen );
            if (CA.Status_Quiz_Start.Val == 1 && CA.Status_Tuer_Bibliothek.Val == 0 )
            {
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Uhu_Fragen, ix, CB!.MCE_Choice1, true, true));
                ix += 10;

                if( CA.Status_Antwort_Unterwaesche.Val == 0)
                {
                    ix = CalcIx(CA!.imc_Uhu_Fragen_Unterwaesche );
                    cFollower.Add(ix);
                    mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Uhu_Fragen_Unterwaesche, ix, ChoiceIx(ix), true, false));
                    SetGenericTipps(mcM, loca.Info_Uhu_Fragen_Unterwaesche_0, CA.Score_Antwort_Unterwaesche, ix);

                    mcM.AddEntry(null, loca.Info_Uhu_Fragen_Unterwaesche_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(AntwortUnterwaesche25);

                    mcM.AddEntry(null, loca.Info_Uhu_Fragen_Unterwaesche_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(AntwortUnterwaesche50);

                    mcM.AddEntry(null, loca.Info_Uhu_Fragen_Unterwaesche_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(AntwortUnterwaesche75);
                }

                if ( CA.Status_Antwort_Ruestung.Val == 0)
                {
                    ix = CalcIx(CA!.imc_Uhu_Fragen_Ruestung);
                    cFollower.Add(ix);
                    mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Uhu_Fragen_Ruestung, ix, ChoiceIx(ix), true, false));
                    SetGenericTipps(mcM, loca.Info_Uhu_Fragen_Ruestung_0, CA.Score_Antwort_Ruestung, ix);

                    mcM.AddEntry(null, loca.Info_Uhu_Fragen_Ruestung_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(AntwortRuestung25);

                    mcM.AddEntry(null, loca.Info_Uhu_Fragen_Ruestung_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(AntwortRuestung50);

                    mcM.AddEntry(null, loca.Info_Uhu_Fragen_Ruestung_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(AntwortRuestung75);
                }

                if (CA.Status_Antwort_Lieblingstier.Val == 0)
                {
                    ix = CalcIx(CA!.imc_Uhu_Fragen_Tier);
                    cFollower.Add(ix);
                    mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Uhu_Fragen_Tier, ix, ChoiceIx(ix), true, false));
                    SetGenericTipps(mcM, loca.Info_Uhu_Fragen_Tier_0, CA.Score_Antwort_Tier, ix);

                    mcM.AddEntry(null, loca.Info_Uhu_Fragen_Tier_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(AntwortTier25);

                    mcM.AddEntry(null, loca.Info_Uhu_Fragen_Tier_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(AntwortTier50);

                    mcM.AddEntry(null, loca.Info_Uhu_Fragen_Tier_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(AntwortTier75);
                }
            }

            ix = CalcIx(CA!.imc_Neues_Pulver_Wie );
            if( CA.Status_Rezept_Gelesen.Val == 1 && CA.I00_Supermagic_Powder.locationID == CA.I00_Nullbehaelter.ID)
            {
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Neues_Rezept_Wie, ix, CB!.MCE_Choice1, true, true));

                if (CA!.I00_Cheese.locationID == CA.I13_Fridge.ID)
                {
                    ix = CalcIx(CA!.imc_Kaese_Not_Found);
                    cFollower.Add(ix);
                    mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Kaese_Not_Found, ix, ChoiceIx(ix), true, false));
                    SetGenericTipps(mcM, loca.Info_Kaese_Not_Found_0, CA.Score_Kaese, ix);

                    mcM.AddEntry(null, loca.Info_Kaese_Not_Found_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(Kaese25);

                    mcM.AddEntry(null, loca.Info_Kaese_Not_Found_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(Kaese50);

                    mcM.AddEntry(null, loca.Info_Kaese_Not_Found_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(Kaese75);
                }
                else if (CA.I00_Polished_Stone.locationID == CA.I00_Nullbehaelter.ID)
                {
                    ix = CalcIx(CA!.imc_Kaese_Wozu);
                    cFollower.Add(ix);
                    mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Kaese_Wozu, ix, ChoiceIx(ix), true, false));
                    SetGenericTipps(mcM, loca.Info_Kaese_Wozu_0, CA.Score_Polierter_Stein, ix);

                    mcM.AddEntry(null, loca.Info_Kaese_Wozu_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(PolierterStein25);

                    mcM.AddEntry(null, loca.Info_Kaese_Wozu_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(PolierterStein50);

                    mcM.AddEntry(null, loca.Info_Kaese_Wozu_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(PolierterStein75);
                }
                else if (CA.I00_Lightless_Stone.locationID == CA.I00_Nullbehaelter.ID)
                {
                    ix = CalcIx(CA!.imc_Kiesel_Wozu );
                    cFollower.Add(ix);
                    mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Kiesel_Wozu, ix, ChoiceIx(ix), true, false));
                    SetGenericTipps(mcM, loca.Info_Kiesel_Wozu_0, CA.Score_Lichtloser_Stein, ix);

                    mcM.AddEntry(null, loca.Info_Kiesel_Wozu_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(LichtloserStein25);

                    mcM.AddEntry(null, loca.Info_Kiesel_Wozu_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(LichtloserStein50);

                    mcM.AddEntry(null, loca.Info_Kiesel_Wozu_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(LichtloserStein75);
                }
                else if (CA.I00_Moonstone.locationID == CA.I00_Nullbehaelter.ID)
                {
                    ix = CalcIx(CA!.imc_Lichtloser_Stein_Wozu );
                    cFollower.Add(ix);
                    mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Lichtloser_Stein_Wozu, ix, ChoiceIx(ix), true, false));
                    SetGenericTipps(mcM, loca.Info_Lichtloser_Stein_Wozu_0, CA.Score_Mondstein, ix);

                    mcM.AddEntry(null, loca.Info_Lichtloser_Stein_Wozu_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(Mondstein25);

                    mcM.AddEntry(null, loca.Info_Lichtloser_Stein_Wozu_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(Mondstein50);

                    mcM.AddEntry(null, loca.Info_Lichtloser_Stein_Wozu_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(Mondstein75);
                }


                if (CA.I00_Coin.locationID == CA.I00_Nullbehaelter.ID  )
                {
                    ix = CalcIx(CA.imc_Goldmuenze_Woher);
                    cFollower.Add(ix);
                    mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Goldmuenze_Woher, ix, ChoiceIx(ix), true, false));
                    SetGenericTipps(mcM, loca.Info_Goldmuenze_Woher_0, CA.Score_Muenze_Gefunden, ix);

                    mcM.AddEntry(null, loca.Info_Goldmuenze_Woher_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(MuenzeGefunden25);

                    mcM.AddEntry(null, loca.Info_Goldmuenze_Woher_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(MuenzeGefunden50);

                    mcM.AddEntry(null, loca.Info_Goldmuenze_Woher_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(MuenzeGefunden75);
                }
                else if (CA.I00_Coin.locationID == CA.I08_Water.ID)
                {
                    ix = CalcIx(CA.imc_Goldmuenze_Woher2);
                    cFollower.Add(ix);
                    mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Goldmuenze_Woher2, ix, ChoiceIx(ix), true, false));
                    SetGenericTipps(mcM, loca.Info_Goldmuenze_Woher2_0, CA.Score_Muenze, ix);

                    mcM.AddEntry(null, loca.Info_Goldmuenze_Woher2_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(Muenze25);

                    mcM.AddEntry(null, loca.Info_Goldmuenze_Woher2_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(Muenze50);

                    mcM.AddEntry(null, loca.Info_Goldmuenze_Woher2_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(Muenze75);
                }

                if (CA.I00_Wonder_Wart_Sponge.locationID == CA.I00_Nullbehaelter.ID )
                {
                    ix = CalcIx(CA.imc_Schwamm_Woher);
                    cFollower.Add(ix);
                    mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Schwamm_Woher, ix, ChoiceIx(ix), true, false));
                    SetGenericTipps(mcM, loca.Info_Schwamm_Woher_0, CA.Score_Schwamm, ix);

                    mcM.AddEntry(null, loca.Info_Schwamm_Woher_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(Schwamm25);

                    mcM.AddEntry(null, loca.Info_Schwamm_Woher_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(Schwamm50);

                    mcM.AddEntry(null, loca.Info_Schwamm_Woher_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                    mcM.Last()!.SetDel(Schwamm75);
                }
            }
            if ( Items.IsItemInv( CA.I00_Moonstone ) && Items.IsItemInv( CA.I00_Wonder_Wart_Sponge ) && Items.IsItemInv( CA.I00_Coin ) )
            {
                ix = CalcIx(CA.imc_Alle_Zutaten_da);
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Alle_Zutaten_da, ix, ChoiceIx(ix), true, false));
                SetGenericTipps(mcM, loca.Info_Alle_Zutaten_da_0, CA.Score_Schlacke, ix);

                mcM.AddEntry(null, loca.Info_Alle_Zutaten_da_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(Schlacke25);

                mcM.AddEntry(null, loca.Info_Alle_Zutaten_da_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(Schlacke50);

                mcM.AddEntry(null, loca.Info_Alle_Zutaten_da_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(Schlacke75);
            }
            if ( CA.I00_Slag.locationID != CA.I00_Nullbehaelter.ID && CA.I00_Slag.locationID != CA.I00_Nullbehaelter2.ID)
            {
                ix = CalcIx(CA.imc_Schlacke_Wozu);
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Schlacke_Wozu, ix, ChoiceIx(ix), true, false));
                SetGenericTipps(mcM, loca.Info_Schlacke_Wozu_0, CA.Score_Meues_Pulver, ix);

                mcM.AddEntry(null, loca.Info_Schlacke_Wozu_1, ChoiceIx(ix) + 10, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(NeuesPulver25);

                mcM.AddEntry(null, loca.Info_Schlacke_Wozu_2, ChoiceIx(ix) + 20, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(NeuesPulver50);

                mcM.AddEntry(null, loca.Info_Schlacke_Wozu_3, ChoiceIx(ix) + 30, ChoiceIx(ix), true);
                mcM.Last()!.SetDel(NeuesPulver75);
            }
            if (CA.I00_Supermagic_Powder.locationID != CA.I00_Nullbehaelter.ID )
            {
                ix = CalcIx(CA.imc_Neues_Pulver_Wozu);
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Neues_Pulver_Wozu, ix, CB!.MCE_Choice1, true, true));
            }
            if (CA.Person_I.locationID == CA.L15_Nowhere )
            {
                ix = CalcIx(CA.imc_Ende );
                cFollower.Add(ix);
                mcM.Add(new MCMenuEntry(CA!.Person_Self, loca.Info_Ende, ix, CB!.MCE_Choice1, true, true));
            }

            ix += 10;

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

        public bool SucheVersteck25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Transfer1!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool SucheVersteck50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Transfer1!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool SucheVersteck75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Transfer1!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool Klauenzange1_25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Klauenzange1!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Klauenzange1_50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Klauenzange1!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Klauenzange1_75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Klauenzange1!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool Klauenzange2_25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Klauenzange2!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Klauenzange2_50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Klauenzange2!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Klauenzange2_75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Klauenzange2!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool ErsteBelebung25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Erste_Belebung!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool ErsteBelebung50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Erste_Belebung!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool ErsteBelebung75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Erste_Belebung!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool ErstesGespraech25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Erstes_Gespraech!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool ErstesGespraech50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Erstes_Gespraech!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool ErstesGespraech75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Erstes_Gespraech!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool AntwortUnterwaesche25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Antwort_Unterwaesche!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool AntwortUnterwaesche50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Antwort_Unterwaesche!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool AntwortUnterwaesche75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Antwort_Unterwaesche!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool AntwortRuestung25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Antwort_Ruestung!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool AntwortRuestung50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Antwort_Ruestung!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool AntwortRuestung75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Antwort_Ruestung!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool AntwortTier25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Antwort_Tier!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool AntwortTier50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Antwort_Tier!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool AntwortTier75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Antwort_Tier!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool Kaese25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Kaese!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Kaese50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Kaese!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Kaese75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Kaese!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool PolierterStein25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Polierter_Stein!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool PolierterStein50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Polierter_Stein!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool PolierterStein75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Polierter_Stein!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool LichtloserStein25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Lichtloser_Stein!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool LichtloserStein50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Lichtloser_Stein!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool LichtloserStein75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Lichtloser_Stein!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool Mondstein25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Mondstein!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Mondstein50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Mondstein!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Mondstein75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Mondstein!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool MuenzeGefunden25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Muenze_Gefunden!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool MuenzeGefunden50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Muenze_Gefunden!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool MuenzeGefunden75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Muenze_Gefunden!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool Muenze25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Muenze!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Muenze50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Muenze!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Muenze75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Muenze!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool Schwamm25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Schwamm!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Schwamm50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Schwamm!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Schwamm75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Schwamm!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool Schlacke25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Schlacke!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Schlacke50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Schlacke!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool Schlacke75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Schlacke!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
        }
        public bool NeuesPulver25(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Meues_Pulver!.IncSpoilerState(spoiler.tipp);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool NeuesPulver50(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Meues_Pulver!.IncSpoilerState(spoiler.spoiler);

            CalcGenericTipps(AdvGame!.UIS!.MCM!);
            return true;
        }

        public bool NeuesPulver75(List<MCMenuEntry> MCMEntry)
        {
            CA!.Score_Meues_Pulver!.IncSpoilerState(spoiler.solution);
            CalcGenericTipps(AdvGame!.UIS!.MCM!);


            return true;
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
