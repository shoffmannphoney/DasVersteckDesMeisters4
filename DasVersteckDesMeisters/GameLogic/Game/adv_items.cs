
using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace GameCore;


public partial class Adv: AdvBase
{

    public void InitItems()
    {

        Items!.List = new Dictionary<int, Item>(Items.GetItemBuffer()!);

        

        CA!.I01_Forest = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Wald! }, new List<Adj> { CA!.Adj_neblig! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L01_Dark_Forest, loca.Adv_I01_Forest, "Adv_I01_Forest", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I01_Trees = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Baeume! }, new List<Adj> { CA!.Adj_karg! }, Co.SEX_MALE_PL, CB!.LocType_Loc, CA!.L01_Dark_Forest, loca.Adv_I01_Trees, "Adv_I01_Trees", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Baum! };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I01_Mist = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Nebel! }, null, Co.SEX_MALE, CB!.LocType_Loc, CA!.L01_Dark_Forest, loca.Adv_I01_Mist, "Adv_I01_Mist", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I01_Forest_Grass = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Waldgras! }, null, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L01_Dark_Forest, loca.Adv_I01_Forest_Grass, "Adv_I01_Forest_Grass", Co.SZ_small, true, false, Nouns, Adjs));
        CA!.I01_Forest_Grass.SynNames = new List<Noun> { CA!.Noun_Gras! };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I02_Doormat = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Fussmatte! }, new List<Adj> { CA!.Adj_zerschlissen! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L02_In_Front_Of_A_Hut, loca.Adv_I02_Doormat, "Adv_I02_Doormat", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Matte! };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_ExamineBelowable ));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutBelow = true;
        Items!.Last().StorageBelow = 15;
        Items!.Last().InvisibleBelow = true;

        CA!.I02_Shed = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Huette! }, new List<Adj> { CA!.Adj_baufaellig! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L02_In_Front_Of_A_Hut, loca.Adv_I02_Shed, "Adv_I02_Shed", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I02_Forest = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Wald! }, new List<Adj> { CA!.Adj_neblig! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L02_In_Front_Of_A_Hut, loca.Adv_I02_Forest, "Adv_I02_Forest", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I02_Trees = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Baeume! }, new List<Adj> { CA!.Adj_karg! }, Co.SEX_MALE_PL, CB!.LocType_Loc, CA!.L02_In_Front_Of_A_Hut, loca.Adv_I02_Trees, "Adv_I02_Trees", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Baum! };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I02_Door = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_solide! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L02_In_Front_Of_A_Hut, loca.Adv_I02_Door, "Adv_I02_Door", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        LockedDoorSwitchToUnlocked(Items!.Last());

        CA!.I02_Mist = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Nebel! }, null, Co.SEX_MALE, CB!.LocType_Loc, CA!.L02_In_Front_Of_A_Hut, loca.Adv_I02_Mist, "Adv_I02_Mist", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I03_Door_Outside = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_solide! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L03_In_The_Parlor, loca.Adv_I03_Door_Solid, "Adv_I03_Door_Solid", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        CounterDoorInit(Items!.Last(), CA!.I02_Door!.ID);
        CounterDoorInit(CA!.I02_Door, Items!.Last()!.ID);
        LockedDoorSwitchToUnlocked(Items!.Last());

        CA!.I03_Pentagram = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Pentagramm! }, null, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L03_In_The_Parlor, loca.Adv_I03_Pentagram, "Adv_I03_Pentagram", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I03_Runes = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Runen! }, new List<Adj> { CA!.Adj_geheimnisvoll! }, Co.SEX_FEMALE_PL, CB!.LocType_Loc, CA!.L03_In_The_Parlor, loca.Adv_I03_Runes, "Adv_I03_Runes", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Rune! };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I03_Door = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_schaebig! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L03_In_The_Parlor, loca.Adv_I03_Door, "Adv_I03_Door", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        LockedDoorSwitchToUnlocked(CA!.I03_Door);


        CA!.I04_Door = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_schaebig! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L04_Shabby_Little_Chamber, loca.Adv_I04_Door, "Adv_I04_Door", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        LockedDoorSwitchToUnlocked(CA!.I04_Door);
        CounterDoorInit(Items!.Last(), CA!.I03_Door!.ID);
        CounterDoorInit(CA!.I03_Door, Items!.Last()!.ID);

        CA!.I04_Shelf= Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Regal! }, new List<Adj> { CA!.Adj_wacklig! }, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L04_Shabby_Little_Chamber, loca.Adv_I04_Shelf, "Adv_I04_Shelf", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Pushable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Pullable));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 30;

        CA!.I04_Cupboard = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Schrank! }, new List<Adj> { CA!.Adj_wuchtig! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L04_Shabby_Little_Chamber, loca.Adv_I04_Cupboard, "Adv_I04_Cupboard", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Pushable), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Pullable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 30;

        CA!.I04_Wall = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Wand! }, null, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L04_Shabby_Little_Chamber, loca.Adv_I04_Wall, "Adv_I04_Wall", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I04_Flap = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Klappe! }, null, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I04_Flap, "Adv_I04_Flap", Co.SZ_small, false, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;

        CA!.I04_Opening = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Oeffnung! }, null, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I04_Opening, "Adv_I04_Opening", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_ExamineInable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 20;

        CA!.I05_Pentagram = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Pentagramm! }, null, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L05_Atrium, loca.Adv_I05_Pentagram, "Adv_I05_Pentagram", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I05_Pedestal = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Podest! }, new List<Adj> { CA!.Adj_verziert! }, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L05_Atrium, loca.Adv_I05_Pedestal, "Adv_I05_Pedestal", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 20;

        CA!.I05_Sign = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Schild! }, new List<Adj> { CA!.Adj_auffaellig! }, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L05_Atrium, loca.Adv_I05_Sign, "Adv_I05_Sign", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Warnschild! };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I05_Sill = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Sims! }, new List<Adj> { CA!.Adj_hoch! }, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L05_Atrium, loca.Adv_I05_Sill, "Adv_I05_Sill", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 20;


        CA!.I05_Library_Door = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_verziert! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L05_Atrium, loca.Adv_I05_Library_Door, "Adv_I05_Library_Door", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;

        CA!.I05_Door = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_breit! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L05_Atrium, loca.Adv_I05_Door, "Adv_I05_Door", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;

        CA!.I05_Moon = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Mond! }, new List<Adj> { CA!.Adj_voll! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L05_Atrium, loca.Adv_I05_Moon, "Adv_I05_Moon", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_ThrowTarget));

        CA!.I06_Door_Wide = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_breit! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L06_Long_Floor, loca.Adv_I06_Door_Wide, "Adv_I06_Door_Wide", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        CounterDoorInit(Items!.Last(), CA!.I05_Door!.ID);
        CounterDoorInit(CA!.I05_Door, Items!.Last()!.ID);

        CA!.I06_Door = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_wuchtig! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L06_Long_Floor, loca.Adv_I06_Door, "Adv_I06_Door", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;

        CA!.I06_Door_Red = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_rot! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L06_Long_Floor, loca.Adv_I06_Door_Red, "Adv_I06_Door_Red", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;

        CA!.I06_Door_White = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_weiss! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L06_Long_Floor, loca.Adv_I06_Door_White, "Adv_I06_Door_White", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;

        CA!.I06_Letters = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Buchstaben! }, new List<Adj> { CA!.Adj_duenn! }, Co.SEX_MALE_PL, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I06_Letters, "Adv_I06_Letters", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readwithable), relTypes.r_essential);

        CA!.I06_Seal = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Siegel! }, new List<Adj> { CA!.Adj_edel! }, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L06_Long_Floor, loca.Adv_I06_Seal, "Adv_I06_Seal", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Breakable));

        CA!.I06_Sign = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Schild! }, null, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L06_Long_Floor, loca.Adv_I06_Sign, "Adv_I06_Sign", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I07_Door = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_massiv! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L07_Lower_Floor, loca.Adv_I07_Door, "Adv_I07_Door", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynAdjectives = new List<Adj> { CA!.Adj_schwer! };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        LockedDoorInit(CA!.I07_Door);

        CA!.I07_Door_Blue = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_blau! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L07_Lower_Floor, loca.Adv_I07_Door_Blue, "Adv_I07_Door_Blue", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;


        CA!.I07_Door_Green = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_gruen! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L07_Lower_Floor, loca.Adv_I07_Door_Green, "Adv_I07_Door_Green", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;

        CA!.I08_Door_Green = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_blau! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L08_Laundry_Room, loca.Adv_I08_Door_Blue, "Adv_I08_Door_Blue", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        CounterDoorInit(Items!.Last(), CA!.I07_Door_Blue!.ID);
        CounterDoorInit(CA!.I07_Door_Blue, Items!.Last()!.ID);

        CA!.I08_Clothes_Line = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Waescheleine! }, null, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L08_Laundry_Room, loca.Adv_I08_Clothes_Line, "Adv_I08_Clothes_Line", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I08_Washing_Machine = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Waschmaschine! }, new List<Adj> { CA!.Adj_wuchtig! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L08_Laundry_Room, loca.Adv_I08_Washing_Machine, "Adv_I08_Washing_Machine", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA.Noun_Wasch!, CA.Noun_Maschine };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 30;
        Items!.Last().InvisibleIn = false;

        CA!.I08_Underpants = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Unterhose! }, new List<Adj> { CA!.Adj_zerschlissen! }, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I08_Washing_Machine.ID, loca.Adv_I08_Underpants, "Adv_I08_Underpants", Co.SZ_small, false, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I08_Well = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Brunnen! }, new List<Adj> { CA!.Adj_massiv! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L08_Laundry_Room, loca.Adv_I08_Well, "Adv_I08_Well", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 0;

        CA!.I08_Wooden_Cover = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Holzabdeckung! }, new List<Adj> { CA!.Adj_schwer! }, Co.SEX_FEMALE, CB!.LocType_On_Item, CA!.I08_Well.ID, loca.Adv_I08_Wooden_Cover, "Adv_I08_Wooden_Cover", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA.Noun_Holz, CA.Noun_Abdeckung, CA.Noun_Deckel };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Pushable), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Pullable));

        CA!.I08_Water = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Wasser! }, null, Co.SEX_NEUTER, CB!.LocType_In_Item, CA!.I08_Well.ID, loca.Adv_I08_Water, "Adv_I08_Water", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Illuminated), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_ThrowTarget), relTypes.r_essential);


        CA!.I08_Clothes = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Waesche! }, new List<Adj> { CA!.Adj_mueffelnd! }, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I08_Washing_Machine.ID, loca.Adv_I08_Clothes, "Adv_I08_Clothes", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_TipTarget), relTypes.r_essential);

        CA!.I08_Machine_For_Hanging_Up_Laundry = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Waescheaufhaengmaschine! }, new List<Adj> { CA!.Adj_kaputt! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L08_Laundry_Room, loca.Adv_I08_Machine_For_Hanging_Up_Laundry, "Adv_I08_Machine_For_Hanging_Up_Laundry", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I08_Laundry_Basket = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Waeschekorb! }, null, Co.SEX_MALE, CB!.LocType_Loc, CA!.L08_Laundry_Room, loca.Adv_I08_Laundry_Basket, "Adv_I08_Laundry_Basket", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 0;

        CA!.I09_Library_Door = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_verziert! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L09_Library, loca.Adv_I09_Library_Door, "Adv_I09_Library_Door", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        CounterDoorInit(Items!.Last(), CA!.I05_Library_Door!.ID);
        CounterDoorInit(CA!.I05_Library_Door, Items!.Last()!.ID);

        CA!.I09_Red_Shelf = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Regal! }, new List<Adj> { CA!.Adj_rot! }, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L09_Library, loca.Adv_I09_Red_Shelf, "Adv_I09_Red_Shelf", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 30;

        CA!.I09_Green_Shelf = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Regal! }, new List<Adj> { CA!.Adj_gruen! }, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L09_Library, loca.Adv_I09_Green_Shelf, "Adv_I09_Green_Shelf", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 30;

        CA!.I09_Librarians_Desk = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tresen! }, new List<Adj> { CA!.Adj_hoelzern! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L09_Library, loca.Adv_I09_Librarians_Desk, "Adv_I09_Librarians_Desk", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I09_Angry_Book = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Buch! }, new List<Adj> { CA!.Adj_hasserfuellt! }, Co.SEX_NEUTER, CB!.LocType_On_Item, CA!.I09_Green_Shelf.ID, loca.Adv_I09_Angry_Book, "Adv_I09_Angry_Book", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I09_Crazy_Book = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Buch! }, new List<Adj> { CA!.Adj_verrueckt! }, Co.SEX_NEUTER, CB!.LocType_On_Item, CA!.I09_Green_Shelf.ID, loca.Adv_I09_Crazy_Book, "Adv_I09_Crazy_Book", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I09_Demonic_Book = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Buch! }, new List<Adj> { CA!.Adj_daemonisch! }, Co.SEX_NEUTER, CB!.LocType_On_Item, CA!.I09_Red_Shelf.ID, loca.Adv_I09_Demonic_Book, "Adv_I09_Demonic_Book", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I09_Satanic_Book = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Buch! }, new List<Adj> { CA!.Adj_satanisch! }, Co.SEX_NEUTER, CB!.LocType_On_Item, CA!.I09_Red_Shelf.ID, loca.Adv_I09_Satanic_Book, "Adv_I09_Satanic_Book", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I09_Weird_Book = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Buch! }, new List<Adj> { CA!.Adj_seltsam! }, Co.SEX_NEUTER, CB!.LocType_On_Item, CA!.I09_Red_Shelf.ID, loca.Adv_I09_Weird_Book, "Adv_I09_Weird_Book", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I09_Sign = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Schild! }, new List<Adj> { CA!.Adj_auffaellig! }, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L09_Library, loca.Adv_I09_Sign, "Adv_I09_Sign", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I09_Carton = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Karton! }, new List<Adj> { CA!.Adj_gross! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L09_Library, loca.Adv_I09_Carton, "Adv_I09_Carton", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 20;
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;

        CA!.I09_Books_Master = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Buecher! }, new List<Adj> { CA!.Adj_peinlich! }, Co.SEX_NEUTER_PL, CB!.LocType_In_Item, CA!.I09_Carton.ID, loca.Adv_I09_Books_Master, "Adv_I09_Books_Master", Co.SZ_small, false, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I10_Labor_Table = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Labortisch! }, new List<Adj> { CA!.Adj_stabil! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L10_Laboratory, loca.Adv_I10_Labor_Table, "Adv_I10_Labor_Table", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 20;

        CA!.I10_Cages = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Kaefige! }, new List<Adj> { CA!.Adj_metallen! }, Co.SEX_MALE_PL, CB!.LocType_Loc, CA!.L10_Laboratory, loca.Adv_I10_Cages, "Adv_I10_Cages", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 30;

        CA!.I10_First_Aid_Kit = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Erstehilfekasten! }, new List<Adj> { CA!.Adj_modern! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L10_Laboratory, loca.Adv_I10_First_Aid_Kit, "Adv_I10_First_Aid_Kit", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Kasten, CA!.Noun_Verbandskasten };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 20;

        CA!.I10_Drawer = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Schublade! }, new List<Adj> { CA!.Adj_klebrig! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L10_Laboratory, loca.Adv_I10_Drawer, "Adv_I10_Drawer", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 20;

        CA!.I10_Bracket = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Halterung! }, new List<Adj> { CA!.Adj_stabil! }, Co.SEX_FEMALE, CB!.LocType_On_Item, CA!.I10_Labor_Table.ID, loca.Adv_I10_Bracket, "Adv_I10_Bracket", Co.SZ_small, false, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_AttachTarget), relTypes.r_essential);

        CA!.I10_Metall_Tray= Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Metallschale! }, new List<Adj> { CA!.Adj_angekokelt! }, Co.SEX_FEMALE, CB!.LocType_On_Item, CA!.I10_Labor_Table.ID, loca.Adv_I10_Metal_Tray, "Adv_I10_Metal_Tray", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun>{ CA!.Noun_Schale };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Heatable ), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Attachable), relTypes.r_essential);
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 30;

        CA!.I10_Darkness_Machine = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Dunkelheitsmaschine! }, new List<Adj> { CA!.Adj_sinister! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L10_Laboratory, loca.Adv_I10_Darkness_Machine, "Adv_I10_Darkness_Machine", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 0;

        CA!.I10_Hatch = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Klappe! }, null, Co.SEX_FEMALE, CB!.LocType_On_Item, CA!.I10_Darkness_Machine.ID, loca.Adv_I10_Hatch, "Adv_I10_Hatch", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;

        CA!.I10_Opening = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Oeffnung! }, null, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I10_Opening, "Adv_I10_Opening", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 20;

        CA!.I10_Switch = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Schalter! }, null, Co.SEX_MALE, CB!.LocType_On_Item, CA!.I10_Darkness_Machine.ID, loca.Adv_I10_Switch, "Adv_I10_Switch", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Pressable), relTypes.r_essential);

        CA!.I10_Giant_Mortar = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Moerser! }, new List<Adj> { CA!.Adj_gigantisch! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L10_Laboratory, loca.Adv_I10_Giant_Mortar, "Adv_I10_Giant_Mortar", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 20;

        CA!.I10_Labor_Door = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, null, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L10_Laboratory, loca.Adv_I10_Labor_Door, "Adv_I10_Labor_Door", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        CounterDoorInit(Items!.Last(), CA!.I07_Door!.ID);
        CounterDoorInit(CA!.I07_Door, Items!.Last()!.ID);


        CA!.I11_Door_Blue = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_gruen! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L11_Storage_Room, loca.Adv_I11_Door_Green, "Adv_I11_Door_Green", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        CounterDoorInit(Items!.Last(), CA!.I07_Door_Blue!.ID);
        CounterDoorInit(CA!.I07_Door_Blue, Items!.Last()!.ID);

        CA!.I11_Left_Shelf = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Regal! }, new List<Adj> { CA!.Adj_links! }, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L11_Storage_Room, loca.Adv_I11_Left_Shelf, "Adv_I11_Left_Shelf", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 30;

        CA!.I11_Right_Shelf = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Regal! }, new List<Adj> { CA!.Adj_rechts! }, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L11_Storage_Room, loca.Adv_I11_Right_Shelf, "Adv_I11_Right_Shelf", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 30;

        CA!.I11_Bird_Stand = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Vogelstaender! }, new List<Adj> { CA!.Adj_robust! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L11_Storage_Room, loca.Adv_I11_Bird_Stand, "Adv_I11_Bird_Stand", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Staender };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 30;

        CA!.I12_Door = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_wuchtig! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L12_Sleeping_Room, loca.Adv_I12_Door, "Adv_I12_Door", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        CounterDoorInit(Items!.Last(), CA!.I06_Door!.ID);
        CounterDoorInit(CA!.I06_Door, Items!.Last()!.ID);

        CA!.I12_Wardrobe = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Kleiderschrank! }, new List<Adj> { CA!.Adj_wuchtig! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L12_Sleeping_Room, loca.Adv_I12_Wardrobe, "Adv_I12_Wardrobe", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Schrank };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 20;

        CA!.I12_Bed = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Bett! }, new List<Adj> { CA!.Adj_feudal! }, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L12_Sleeping_Room, loca.Adv_I12_Bed, "Adv_I12_Bed", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 20;

        CA!.I12_Matress = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Matratze! }, null, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L12_Sleeping_Room, loca.Adv_I12_Matress, "Adv_I12_Matress", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_ExamineBelowable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutBelow = true;
        Items!.Last().StorageBelow = 20;
        Items!.Last().InvisibleBelow = true;

        CA!.I13_Drawer = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Schublade! }, null, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L13_Kitchen, loca.Adv_I13_Drawer, "Adv_I13_Drawer", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 20;


        CA!.I13_Cupboard = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Schrank! }, null, Co.SEX_MALE, CB!.LocType_Loc, CA!.L13_Kitchen, loca.Adv_I13_Cupboard, "Adv_I13_Cupboard", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Kuechenschrank };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 40;

        CA!.I13_Fridge = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Kuehlschrank! }, null, Co.SEX_MALE, CB!.LocType_Loc, CA!.L13_Kitchen, loca.Adv_I13_Fridge, "Adv_I13_Fridge", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 40;


        CA!.I13_Freezer = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Gefrierfach! }, null, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L13_Kitchen, loca.Adv_I13_Freezer, "Adv_I13_Freezer", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Gefrier, CA!.Noun_Fach, CA.Noun_Froster };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 20;


        CA!.I13_Door_White = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_weiss! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L13_Kitchen, loca.Adv_I13_Door_White, "Adv_I13_Door_White", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        CounterDoorInit(Items!.Last(), CA!.I06_Door_White!.ID);
        CounterDoorInit(CA!.I06_Door_White, Items!.Last()!.ID);

        CA!.I14_Door_Red = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_rot! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L14_Bathroom, loca.Adv_I14_Door_Red, "Adv_I14_Door_Red", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanBeClosed = true;
        Items!.Last().IsClosed = true;
        CounterDoorInit(Items!.Last(), CA!.I06_Door_Red!.ID);
        CounterDoorInit(CA!.I06_Door_Red, Items!.Last()!.ID);

        CA!.I14_Mirror = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Spiegel! }, new List<Adj> { CA!.Adj_hoch! }, Co.SEX_MALE, CB!.LocType_Loc, CA!.L14_Bathroom, loca.Adv_I14_Mirror, "Adv_I14_Mirror", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I14_Writing = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Schrift! }, null, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L14_Bathroom, loca.Adv_I14_Writing, "Adv_I14_Writing", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I14_Sink = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Waschbecken! }, null, Co.SEX_NEUTER, CB!.LocType_Loc, CA!.L14_Bathroom, loca.Adv_I14_Sink, "Adv_I14_Sink", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Becken };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I14_Tiles = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Wand! }, new List<Adj> { CA!.Adj_gekachelt}, Co.SEX_FEMALE_PL, CB!.LocType_Loc, CA!.L14_Bathroom, loca.Adv_I14_Kacheln, "Adv_I14_Kacheln", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Kachel };
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Kacheln };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I14_Special_Tile = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Kachel! }, new List<Adj> { CA!.Adj_besonders! }, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I14_Special_Tile, "Adv_I14_Special_Tile", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I14_Opening = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Oeffnung! }, null, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I14_Opening, "Adv_I14_Opening", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Grabintoable), relTypes.r_essential);

        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 20;
        Items!.Last().InvisibleIn = true;

        CA!.I14_Bathtub = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Badewanne! }, null, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L14_Bathroom, loca.Adv_I14_Bathtub, "Adv_I14_Bathtub", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().CanPutOn = true;
        Items!.Last().StorageOn = 20;

        CA!.I14_Toilet = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Toilette! }, null, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L14_Bathroom, loca.Adv_I14_Toilet, "Adv_I14_Toilet", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Usable));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().IsClosed = true;
        Items!.Last().CanBeClosed = true;

        CA!.I14_Flushing = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Spuelung! }, null, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L14_Bathroom, loca.Adv_I14_Flushing, "Adv_I14_Flushing", Co.SZ_small, true, false, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Usable));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));


        CA!.I00_Pouch = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Beutelchen! }, new List<Adj> { CA!.Adj_ledern! }, Co.SEX_NEUTER, CB!.LocType_Below_Item, CA!.I02_Doormat.ID, loca.Adv_I00_Pouch, "Adv_I00_Pouch", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Beutel! };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Eatable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().IsClosed = true;
        Items!.Last().CanBeClosed = true;
        Items!.Last().CanPutIn = true;
        Items!.Last().StorageIn = 20;

        CA!.I00_Magic_Powder = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Pulver! }, new List<Adj> { CA!.Adj_magisch! }, Co.SEX_NEUTER, CB!.LocType_In_Item, CA!.I00_Pouch.ID, loca.Adv_I00_Pouch, "Adv_I00_Magic_Powder", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Staub! };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Eatable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Tipable), relTypes.r_essential);

        CA!.I00_Supermagic_Powder = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Pulver! }, new List<Adj> { CA!.Adj_magisch! }, Co.SEX_NEUTER, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I00_Supermagic_Powder, "Adv_I00_Supermagic_Powder", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Staub! };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Eatable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Tipable), relTypes.r_essential);

        CA!.I00_Magic_Candle = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Kerzenhalter! }, new List<Adj> { CA!.Adj_magisch! }, Co.SEX_MALE, CB!.LocType_In_Item, CA!.I04_Opening.ID, loca.Adv_I00_Magic_Candle, "Adv_I00_Magic_Candle", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Kerze!, CA!.Noun_Halter!, CA!.Noun_Flamme };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Enlightable), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Usable), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_TipTarget), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_Heater), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_Lighter), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Lightable), relTypes.r_essential);

        CA!.I00_Claw = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Klaue! }, new List<Adj> { CA!.Adj_funkelnd! }, Co.SEX_FEMALE, CB!.LocType_On_Item, CA!.I05_Pedestal.ID, loca.Adv_I00_Claw, "Adv_I00_Claw", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Juwel, CA!.Noun_Stein, CA!.Noun_Edelstein };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_TakeWith ), relTypes.r_essential);

        CA!.I00_Sugar_Pliers = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Zuckerzange! }, new List<Adj> { CA!.Adj_verziert! }, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I13_Drawer.ID, loca.Adv_I00_Sugar_Pliers, "Adv_I00_Sugar_Pliers", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Zange };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_TakeWith_Tool), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Wraparoundable), relTypes.r_essential);

        CA!.I00_Key = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Schluessel! }, new List<Adj> { CA!.Adj_verziert! }, Co.SEX_MALE, CB!.LocType_In_Item, CA!.I14_Opening.ID, loca.Adv_I00_Key, "Adv_I00_Key", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_Key));

        CA!.I00_Roll_Plaster = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Rollpflaster! }, new List<Adj> { CA!.Adj_vergilbt! }, Co.SEX_NEUTER, CB!.LocType_In_Item, CA!.I10_First_Aid_Kit.ID, loca.Adv_I00_Roll_Plaster, "Adv_I00_Roll_Plaster", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Pflaster, CA!.Noun_Rolle};
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Wraparoundable), relTypes.r_essential);

        CA!.I00_Unstable_Pliers_With_Claw = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Klauenzange! }, new List<Adj> { CA!.Adj_instabil! }, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I00_Unstable_Pliers_With_Claw, "Adv_I00_Unstable_Pliers_With_Claw", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Klaue, CA!.Noun_Zange };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_TakeWith_Tool), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_Wraparound_Tool), relTypes.r_essential);

        CA!.I00_Stable_Pliers_With_Claw = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Klauenzange! }, new List<Adj> { CA!.Adj_stabil! }, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I00_Stable_Pliers_With_Claw, "Adv_I00_Stable_Pliers_With_Claw", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Klaue, CA!.Noun_Zange };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_Wraparound_Tool), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_TouchWith_Tool), relTypes.r_essential);

        CA!.I00_Polishing_Rag = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Polierlappen! }, new List<Adj> { CA!.Adj_alt! }, Co.SEX_MALE, CB!.LocType_In_Item, CA!.I13_Cupboard.ID, loca.Adv_I00_Polishing_Rag, "Adv_I00_Polishing_Rag", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Lappen };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_CleanTool), relTypes.r_essential);

        CA!.I00_Magnifier = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Lupe! }, new List<Adj> { CA!.Adj_gross! }, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I10_Drawer.ID, loca.Adv_I00_Magnifier, "Adv_I00_Magnifier", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_Read_Tool), relTypes.r_essential);

        CA!.I00_Squeaky_Duck = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Quietscheentchen! }, new List<Adj> { CA!.Adj_gelb! }, Co.SEX_NEUTER, CB!.LocType_On_Item, CA!.I14_Bathtub.ID, loca.Adv_I00_Squeaky_Duck, "Adv_I00_Squeaky_Duck", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Ente!, CA!.Noun_Entchen, CA!.Noun_Gummiente };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Usable));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Talkable), relTypes.r_essential);

        CA!.I00_Paper_Sheets = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Papierboegen! }, new List<Adj> { CA!.Adj_beschrieben! }, Co.SEX_MALE_PL, CB!.LocType_Below_Item, CA!.I12_Matress.ID, loca.Adv_I00_Paper_Sheets, "Adv_I00_Paper_Sheets", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA.Noun_Papier, CA.Noun_Bogen, CA.Noun_Boegen };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I00_Book_Master = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Buch! }, new List<Adj> { CA!.Adj_peinlich! }, Co.SEX_NEUTER, CB!.LocType_In_Item, CA!.I09_Carton.ID, loca.Adv_I00_Book_Master, "Adv_I00_Book_Master", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Readable));

        CA!.I00_Cheese = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Kaese! }, new List<Adj> { CA!.Adj_vertrocknet! }, Co.SEX_MALE, CB!.LocType_In_Item, CA!.I13_Fridge.ID, loca.Adv_I00_Cheese, "Adv_I00_Cheese", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Eatable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I00_Polished_Stone = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Stein! }, new List<Adj> { CA!.Adj_poliert! }, Co.SEX_MALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I00_Polished_Stone, "Adv_I00_Polished_Stone", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I00_Lightless_Stone = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Stein! }, new List<Adj> { CA!.Adj_lichtlos! }, Co.SEX_MALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I00_Lightless_Stone, "Adv_I00_Lightless_Stone", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I00_Moonstone = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Mondstein! }, null, Co.SEX_MALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I00_Moonstone, "Adv_I00_Moonstone", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Stein };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I00_Plastic_Bag = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Plastikbeutel! }, new List<Adj> { CA!.Adj_gekuehlt! }, Co.SEX_MALE, CB!.LocType_In_Item, CA!.I13_Freezer.ID, loca.Adv_I00_Plastic_Bag, "Adv_I00_Plastic_Bag", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA!.Noun_Beutel, CA!.Noun_Plastik, CA.Noun_Pilz, CA.Noun_Schimmel, CA.Noun_Funghi, CA.Noun_Sporen, CA!.Noun_Plastiktuete, CA!.Noun_Tuete };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Tipable), relTypes.r_essential);

        CA!.I00_Wonder_Wart_Sponge = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Wunderwarzenschwamm! }, new List<Adj> { CA!.Adj_prachtvoll! }, Co.SEX_MALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I00_Wonder_Wart_Sponge, "Adv_I00_Wonder_Wart_Sponge", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().SynNames = new List<Noun> { CA.Noun_Pilz, CA.Noun_Schimmel, CA.Noun_Funghi, CA.Noun_Sporen, CA.Noun_Schwamm };
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        CA!.I00_Slag = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Schlacke! }, new List<Adj> { CA!.Adj_schwarz! }, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I00_Slag, "Adv_I00_Slag", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Pulverizable), relTypes.r_essential);

        CA!.I00_Plunger = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Stoessel! }, new List<Adj> { CA!.Adj_schwer! }, Co.SEX_MALE, CB!.LocType_In_Item, CA!.I10_Giant_Mortar.ID, loca.Adv_I00_Plunger, "Adv_I00_Plunger", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith), relTypes.r_essential);
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_Pulverizer ), relTypes.r_essential);

        CA!.I00_Coin = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Muenze! }, new List<Adj> { CA!.Adj_schimmernd! }, Co.SEX_FEMALE, CB!.LocType_In_Item, CA!.I00_Nullbehaelter.ID, loca.Adv_I00_Coin, "Adv_I00_Coin", Co.SZ_small, false, true, Nouns, Adjs));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_Smellable));
        Items!.Last().Categories?.Add(Categories?.Find(A.Cat_UsableWith));
        Items!.Last().Categories?.Add(Categories?.Find(A.CounterCat_UsableWith));

        Items!.List = new Dictionary<int, Item>(Items.GetItemBuffer()!);

        // Item-Transfers gehen erst, wenn das Dictionary bereit ist
        /*
        loca.GD!.Language = GlobalData.language.english;
        List<string> itemNames = new();
        foreach( Item i in Items!.List.Values)
        {
            string s = i.FullName(i, Co.CASE_NOM, true, true, true );
            itemNames.Add(s);
        }
        */
    }
}