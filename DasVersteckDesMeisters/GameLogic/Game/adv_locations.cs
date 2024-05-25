using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace GameCore;


public partial class Adv: AdvBase
{

    public void Initlocations()
    {
        locations!.Add(new location(0, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)!);

        locations!.Add(location.locationLocaLoca(CA!.L01_Dark_Forest, loca.Adv_L01_Dark_Forest, "Adv_L01_Dark_Forest",
             loca.Adv_L01_Dark_Forest_Lang, "Adv_L01_Dark_Forest_Lang",
            CA!.L02_In_Front_Of_A_Hut, CA!.L02_In_Front_Of_A_Hut, CA!.L01_Dark_Forest, CA!.L01_Dark_Forest, CA!.L01_Dark_Forest, CA!.L01_Dark_Forest, CA!.L01_Dark_Forest, CA!.L02_In_Front_Of_A_Hut, 0, 0));
        locations!.Last().LocPicture = "ver_l01.jpg";


        locations!.Add(location.locationLocaLoca(CA!.L02_In_Front_Of_A_Hut, loca.Adv_L02_In_Front_Of_A_Hut, "Adv_L02_In_Front_Of_A_Hut",
            loca.Adv_L02_In_Front_Of_A_Hut_Lang, "Adv_L02_In_Front_Of_A_Hut_Lang",
            CA!.L03_In_The_Parlor, 0, 0, 0, CA!.L01_Dark_Forest, 0, 0, 0, 0, 0));
        locations!.Last().LocPicture = "ver_l02.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L03_In_The_Parlor, loca.Adv_L03_In_The_Parlor, "Adv_L03_In_The_Parlor",
            loca.Adv_L03_In_The_Parlor_Lang, "Adv_L03_In_The_Parlor_Lang",
            0, 0, CA!.L04_Shabby_Little_Chamber, 0, CA!.L02_In_Front_Of_A_Hut, 0, 0, 0, 0, 0));
        locations!.Last().LocPicture = "ver_l03.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L04_Shabby_Little_Chamber, loca.Adv_L04_Shabby_Little_Chamber, "Adv_L04_Shabby_Little_Chamber",
            loca.Adv_L04_Shabby_Little_Chamber_Lang, "Adv_L04_Shabby_Little_Chamber_Lang",
            0, 0, 0, 0, 0, 0, CA!.L03_In_The_Parlor, 0, 0, 0));
        locations!.Last().LocPicture = "ver_l04.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L05_Atrium, loca.Adv_L05_Atrium, "Adv_L05_Atrium",
            loca.Adv_L05_Atrium_Lang, "Adv_L05_Atrium_Lang",
            0, 0, 0, 0, CA!.L06_Long_Floor, 0, CA!.L09_Library, 0, 0, 0));
        locations!.Last().LocPicture = "ver_l05.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L06_Long_Floor, loca.Adv_L06_Long_Floor, "Adv_L06_Long_Floor",
            loca.Adv_L06_Long_Floor_Lang, "Adv_L06_Long_Floor_Lang",
            CA!.L05_Atrium, 0, CA!.L13_Kitchen, 0, CA!.L12_Sleeping_Room, 0, CA!.L14_Bathroom, 0, 0, CA.L07_Lower_Floor));
        locations!.Last().LocPicture = "ver_l06.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L07_Lower_Floor, loca.Adv_L07_Lower_Floor, "Adv_L07_Lower_Floor",
            loca.Adv_L07_Lower_Floor_Lang, "Adv_L07_Lower_Floor_Lang",
            0, 0, CA!.L10_Laboratory, 0, CA!.L11_Storage_Room, 0, CA!.L08_Laundry_Room, 0, CA.L06_Long_Floor, 0));
        locations!.Last().LocPicture = "ver_l07.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L08_Laundry_Room, loca.Adv_L08_Laundry_Room, "Adv_L08_Laundry_Room",
            loca.Adv_L08_Laundry_Room_Lang, "Adv_L08_Laundry_Room_Lang",
            0, 0, CA!.L07_Lower_Floor, 0, 0, 0, 0, 0, 0, 0));
        locations!.Last().LocPicture = "ver_l08.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L09_Library, loca.Adv_L09_Library, "Adv_L09_Library",
            loca.Adv_L09_Library_Lang, "Adv_L09_Library_Lang",
            0, 0, CA!.L05_Atrium, 0, 0, 0, 0, 0, 0, 0));
        locations!.Last().LocPicture = "ver_l09.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L10_Laboratory, loca.Adv_L10_Laboratory, "Adv_L10_Laboratory",
            loca.Adv_L10_Laboratory_Lang, "Adv_L10_Laboratory_Lang",
            0, 0, 0, 0, 0, 0, CA!.L07_Lower_Floor, 0, 0, 0));
        locations!.Last().LocPicture = "ver_l10.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L11_Storage_Room, loca.Adv_L11_Storage_Room, "Adv_L11_Storage_Room",
            loca.Adv_L11_Storage_Room_Lang, "Adv_L11_Storage_Room_Lang",
            CA!.L07_Lower_Floor, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        locations!.Last().LocPicture = "ver_l11.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L12_Sleeping_Room, loca.Adv_L12_Sleeping_Room, "Adv_L12_Sleeping_Room",
            loca.Adv_L12_Sleeping_Room_Lang, "Adv_L12_Sleeping_Room_Lang",
            CA!.L06_Long_Floor, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        locations!.Last().LocPicture = "ver_l12.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L13_Kitchen, loca.Adv_L13_Kitchen, "Adv_L13_Kitchen",
            loca.Adv_L13_Kitchen_Lang, "Adv_L13_Kitchen_Lang",
            0, 0, 0, 0, 0, 0, CA!.L06_Long_Floor, 0, 0, 0));
        locations!.Last().LocPicture = "ver_l13.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L14_Bathroom, loca.Adv_L14_Bathroom, "Adv_L14_Bathroom",
            loca.Adv_L14_Bathroom_Lang, "Adv_L14_Bathroom_Lang",
            0, 0, CA!.L06_Long_Floor, 0, 0, 0, 0, 0, 0, 0));
        locations!.Last().LocPicture = "ver_l14.jpg";

        locations!.Add(location.locationLocaLoca(CA!.L15_Nowhere, loca.Adv_L15_Nowhere, "Adv_L15_Nowhere",
            loca.Adv_L15_Nowhere_Lang, "Adv_L15_Nowhere_Lang",
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
        locations!.Last().LocPicture = "ver_l15.jpg";

    }
}