
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