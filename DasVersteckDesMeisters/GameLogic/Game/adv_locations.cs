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

    }
}