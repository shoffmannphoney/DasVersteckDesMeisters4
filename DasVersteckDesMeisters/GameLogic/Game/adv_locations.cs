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
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0));
    }
}