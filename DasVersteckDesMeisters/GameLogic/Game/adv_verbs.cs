using System;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;

namespace GameCore;


public partial class Adv: AdvBase
{
    void InitVerbs( int size = -1)
    {
        if( size != -1 )
        {
            Verbs!.TList = new Dictionary<string, Verb>( size, StringComparer.CurrentCultureIgnoreCase );

        }

        CA!.Verb_Enlight = Verbs!.AddLoca("Verb_beleuchte");
        Verbs.AddLoca(CA!.Verb_Enlight.ID, "Verb_bescheine");
        Verbs.AddLoca(CA!.Verb_Enlight.ID, "Verb_erhelle");

        CA!.Verb_Spread = Verbs!.AddLoca( "Verb_streue");

        CA!.Verb_Story = Verbs!.AddLoca("Order_Story");
        Verbs.AddLoca(CA!.Verb_Story.ID, "Verb_Script");

        CA!.Verb_Undo = Verbs!.AddLoca("Verb_Undo");

        CA!.Verb_Testwindow = Verbs.AddLoca( "Adv_13001");

        CA!.Verb_Phone = Verbs.AddLoca( "Adv_13002");

        CA!.Verb_Throw = Verbs.AddLoca( "Adv_13003");
        Verbs.AddLoca(CA!.Verb_Throw.ID, "Adv_13004");

        CA!.Verb_Brief = Verbs.AddLoca( "Adv_13005");
        Verbs.AddLoca(CA!.Verb_Brief.ID, "Adv_13006");

        CA!.Verb_Verbose = Verbs.AddLoca( "Adv_13007");
        Verbs.AddLoca(CA!.Verb_Verbose.ID, "Adv_13008");

        CA!.Verb_Push = Verbs.AddLoca( "Adv_13009");
        Verbs.AddLoca(CA!.Verb_Push.ID, "Adv_13010");
        Verbs.AddLoca(CA!.Verb_Push.ID, "Adv_13011");
        Verbs.AddLoca(CA!.Verb_Push.ID, "Adv_13012");
        Verbs.AddLoca(CA!.Verb_Push.ID, "Adv_13013");
        Verbs.AddLoca(CA!.Verb_Push.ID, "Adv_13014");

        CA!.Verb_Draw = Verbs.AddLoca( "Adv_13015");
        Verbs.AddLoca(CA!.Verb_Draw.ID, "Adv_13016");

        CA!.Verb_Read = Verbs.AddLoca( "Adv_13017");
        Verbs.AddLoca(CA!.Verb_Read.ID, "Adv_13018");
        Verbs.AddLoca(CA!.Verb_Read.ID, "Adv_13019");

        CA!.Verb_Untighten = Verbs.AddLoca( "Adv_13020");
        Verbs.AddLoca(CA!.Verb_Untighten.ID, "Adv_13021");
        Verbs.AddLoca(CA!.Verb_Untighten.ID, "Adv_13022");
        Verbs.AddLoca(CA!.Verb_Untighten.ID, "Adv_13023");

        CA!.Verb_Break = Verbs.AddLoca( "Adv_13024");
        Verbs.AddLoca(CA!.Verb_Break.ID, "Adv_13025");
        Verbs.AddLoca(CA!.Verb_Break.ID, "Adv_13026");
        Verbs.AddLoca(CA!.Verb_Break.ID, "Adv_13027");

        CA!.Verb_Cut = Verbs.AddLoca( "Adv_13028");
        Verbs.AddLoca(CA!.Verb_Cut.ID, "Adv_13029");
        Verbs.AddLoca(CA!.Verb_Cut.ID, "Adv_13030");

        CA!.Verb_Tie = Verbs.AddLoca( "Adv_13031");
        Verbs.AddLoca(CA!.Verb_Tie.ID, "Adv_13032");
        Verbs.AddLoca(CA!.Verb_Tie.ID, "Adv_13033");
        Verbs.AddLoca(CA!.Verb_Tie.ID, "Adv_13034");
        Verbs.AddLoca(CA!.Verb_Tie.ID, "Adv_13035");

        CA!.Verb_Fish = Verbs.AddLoca( "Adv_13036");

        CA!.Verb_Light = Verbs.AddLoca( "Adv_13037");
        Verbs.AddLoca(CA!.Verb_Light.ID, "Adv_13038");
        Verbs.AddLoca(CA!.Verb_Light.ID, "Adv_13039");
        Verbs.AddLoca(CA!.Verb_Light.ID, "Adv_13040");
        Verbs.AddLoca(CA!.Verb_Light.ID, "Adv_13041");
        Verbs.AddLoca(CA!.Verb_Light.ID, "Adv_13042");

        CA!.Verb_Extinguish = Verbs.AddLoca( "Adv_13043");
        Verbs.AddLoca(CA!.Verb_Extinguish.ID, "Adv_13044");

        CA!.Verb_Grab = Verbs.AddLoca( "Adv_13045");
        Verbs.AddLoca(CA!.Verb_Grab.ID, "Adv_13046");

        CA!.Verb_Eat = Verbs.AddLoca( "Adv_13047");
        Verbs.AddLoca(CA!.Verb_Eat.ID, "Adv_13048");
        Verbs.AddLoca(CA!.Verb_Eat.ID, "Adv_13049");

        CA!.Verb_Sell = Verbs.AddLoca( "Adv_13050");
        Verbs.AddLoca(CA!.Verb_Sell.ID, "Adv_13051");
        Verbs.AddLoca(CA!.Verb_Sell.ID, "Adv_13052");
        Verbs.AddLoca(CA!.Verb_Sell.ID, "Adv_13053");

        CA!.Verb_Fill = Verbs.AddLoca( "Adv_13054");
        Verbs.AddLoca(CA!.Verb_Fill.ID, "Adv_13055");

        CA!.Verb_Stuff = Verbs.AddLoca( "Adv_13056");
        Verbs.AddLoca(CA!.Verb_Fill.ID, "Adv_13057");

        CA!.Verb_Pick = Verbs.AddLoca( "Adv_13058");
        Verbs.AddLoca(CA!.Verb_Pick.ID, "Adv_13059");

        CA!.Verb_Catch = Verbs.AddLoca( "Adv_13060");
        Verbs.AddLoca(CA!.Verb_Catch.ID, "Adv_13061");

        CA!.Verb_Drink = Verbs.AddLoca( "Adv_13062");
        Verbs.AddLoca(CA!.Verb_Drink.ID, "Adv_13063");

        CA!.Verb_Touch = Verbs.AddLoca( "Adv_13064");
        Verbs.AddLoca(CA!.Verb_Touch.ID, "Adv_13065");

        CA!.Verb_Knock = Verbs.AddLoca( "Adv_13066");
        Verbs.AddLoca(CA!.Verb_Knock.ID, "Adv_13067");

        CA!.Verb_Spit = Verbs.AddLoca( "Adv_13068");
        Verbs.AddLoca(CA!.Verb_Spit.ID, "Adv_13069");
        Verbs.AddLoca(CA!.Verb_Spit.ID, "Adv_13070");
        Verbs.AddLoca(CA!.Verb_Spit.ID, "Adv_13071");

        CA!.Verb_Listen = Verbs.AddLoca( "Adv_13072");
        Verbs.AddLoca(CA!.Verb_Listen.ID, "Adv_13073");
        Verbs.AddLoca(CA!.Verb_Listen.ID, "Adv_13074");
        Verbs.AddLoca(CA!.Verb_Listen.ID, "Adv_13075");
        Verbs.AddLoca(CA!.Verb_Listen.ID, "Adv_13076");
        Verbs.AddLoca(CA!.Verb_Listen.ID, "Adv_13077");

        CA!.Verb_Attach = Verbs.AddLoca( "Adv_13078");
        Verbs.AddLoca(CA!.Verb_Attach.ID, "Adv_13079");

        CA!.Verb_Attach2 = Verbs.AddLoca("Verb_Attach");
        Verbs.AddLoca(CA!.Verb_Attach2.ID, "Verb_Fix");

        CA!.Verb_Play = Verbs.AddLoca("Verb_Play");

        CA!.Verb_Phoneyvision = Verbs.AddLoca("Verb_Phoneyvision");
        Verbs.AddLoca(CA!.Verb_Phoneyvision.ID, "Verb_Phoneyvision2");

        CA!.Verb_Realitaet = Verbs.AddLoca("Verb_Realitaet");
        Verbs.AddLoca(CA!.Verb_Realitaet.ID, "Verb_Realitaet2");

        CA!.Verb_Hang = Verbs.AddLoca( "Adv_13080");
        Verbs.AddLoca(CA!.Verb_Hang.ID, "Adv_13081");

        CA!.Verb_Dip = Verbs.AddLoca( "Adv_13082");
        Verbs.AddLoca(CA!.Verb_Dip.ID, "Adv_13083");
        Verbs.AddLoca(CA!.Verb_Dip.ID, "Adv_13084");
        Verbs.AddLoca(CA!.Verb_Dip.ID, "Adv_13085");

        CA!.Verb_Tip = Verbs.AddLoca( "Adv_13086");
        Verbs.AddLoca(CA!.Verb_Tip.ID, "Adv_13087");
        Verbs.AddLoca(CA!.Verb_Tip.ID, "Adv_13088");
        Verbs.AddLoca(CA!.Verb_Tip.ID, "Adv_13089");

        CA!.Verb_Water = Verbs.AddLoca( "Adv_13090");
        Verbs.AddLoca(CA!.Verb_Water.ID, "Adv_13091");

        CA!.Verb_Arrest = Verbs.AddLoca( "Adv_13092");

        CA!.Verb_Meditate = Verbs.AddLoca( "Adv_13093");
        Verbs.AddLoca(CA!.Verb_Meditate.ID, "Adv_13094");

        CA!.Verb_Press = Verbs.AddLoca( "Adv_13095");
        Verbs.AddLoca(CA!.Verb_Press.ID, "Adv_13096");
        Verbs.AddLoca(CA!.Verb_Press.ID, "Adv_13097");

        CA!.Verb_Puncture = Verbs.AddLoca( "Adv_13098");
        Verbs.AddLoca(CA!.Verb_Puncture.ID, "Adv_13099");
        Verbs.AddLoca(CA!.Verb_Puncture.ID, "Adv_13100");
        Verbs.AddLoca(CA!.Verb_Puncture.ID, "Adv_13101");
        Verbs.AddLoca(CA!.Verb_Puncture.ID, "Adv_Verb_perforiere");
        Verbs.AddLoca(CA!.Verb_Puncture.ID, "Adv_Verb_durchsteche");
        Verbs.AddLoca(CA!.Verb_Puncture.ID, "Adv_Verb_bohre");
        Verbs.AddLoca(CA!.Verb_Puncture.ID, "Adv_Verb_durchbohre");

        CA!.Verb_Photograph = Verbs.AddLoca( "Adv_13102");
        Verbs.AddLoca(CA!.Verb_Photograph.ID, "Adv_13103");

        CA!.Verb_Mount = Verbs.AddLoca( "Adv_13104");
        Verbs.AddLoca(CA!.Verb_Mount.ID, "Adv_13105");

        CA!.Verb_Saw = Verbs.AddLoca( "Adv_13106");
        Verbs.AddLoca(CA!.Verb_Saw.ID, "Adv_13107");

        CA!.Verb_Smear = Verbs.AddLoca( "Adv_13108");
        Verbs.AddLoca(CA!.Verb_Smear.ID, "Adv_13109");

        CA!.Verb_Smear2 = Verbs.AddLoca( "Adv_13110");
        Verbs.AddLoca(CA!.Verb_Smear2.ID, "Adv_13111");

        CA!.Verb_Blow = Verbs.AddLoca( "Adv_13112");
        Verbs.AddLoca(CA!.Verb_Blow.ID, "Adv_13113");
        Verbs.AddLoca(CA!.Verb_Blow.ID, "Adv_13114");
        Verbs.AddLoca(CA!.Verb_Blow.ID, "Adv_13115");
        Verbs.AddLoca(CA!.Verb_Blow.ID, "Adv_13116");

        CA!.Verb_Poison = Verbs.AddLoca( "Adv_13117");

        CA!.Verb_Compare = Verbs.AddLoca( "Adv_13118");
        Verbs.AddLoca(CA!.Verb_Compare.ID, "Adv_13119");

        CA!.Verb_Creep = Verbs.AddLoca( "Adv_13120");
        Verbs.AddLoca(CA!.Verb_Creep.ID, "Adv_13121");

        CA!.Verb_Follow = Verbs.AddLoca( "Adv_13122");
        Verbs.AddLoca(CA!.Verb_Follow.ID, "Adv_13123");
        Verbs.AddLoca(CA!.Verb_Follow.ID, "Adv_13124");
        Verbs.AddLoca(CA!.Verb_Follow.ID, "Adv_13125");

        CA!.Verb_Jump = Verbs.AddLoca( "Adv_13126");
        Verbs.AddLoca(CA!.Verb_Jump.ID, "Adv_13127");
        Verbs.AddLoca(CA!.Verb_Jump.ID, "Adv_13128");
        Verbs.AddLoca(CA!.Verb_Jump.ID, "Adv_13129");

        CA!.Verb_Turn = Verbs.AddLoca( "Adv_13130");
        Verbs.AddLoca(CA!.Verb_Turn.ID, "Adv_13131");
        Verbs.AddLoca(CA!.Verb_Turn.ID, "Adv_13132");
        Verbs.AddLoca(CA!.Verb_Turn.ID, "Adv_13133");

        CA!.Verb_Mix = Verbs.AddLoca( "Adv_13134");
        Verbs.AddLoca(CA!.Verb_Mix.ID, "Adv_13135");
        Verbs.AddLoca(CA!.Verb_Mix.ID, "Adv_13136");
        Verbs.AddLoca(CA!.Verb_Mix.ID, "Adv_13137");
        Verbs.AddLoca(CA!.Verb_Mix.ID, "Adv_13138");
        Verbs.AddLoca(CA!.Verb_Mix.ID, "Adv_13139");

        CA!.Verb_Pluck = Verbs.AddLoca( "Adv_13140");
        Verbs.AddLoca(CA!.Verb_Pluck.ID, "Adv_13141");

        CA!.Verb_Suck = Verbs.AddLoca( "Adv_13142");
        Verbs.AddLoca(CA!.Verb_Suck.ID, "Adv_13143");

        CA!.Verb_Sit = Verbs.AddLoca( "Adv_13144");
        Verbs.AddLoca(CA!.Verb_Sit.ID, "Adv_13145");
        Verbs.AddLoca(CA!.Verb_Sit.ID, "Adv_13146");
        Verbs.AddLoca(CA!.Verb_Sit.ID, "Adv_13147");

        CA!.Verb_Exchange = Verbs.AddLoca( "Adv_13148");
        Verbs.AddLoca(CA!.Verb_Exchange.ID, "Adv_13149");

        CA!.Verb_Bind = Verbs.AddLoca( "Adv_13150");
        Verbs.AddLoca(CA!.Verb_Bind.ID, "Adv_13151");

        CA!.Verb_Free = Verbs.AddLoca( "Adv_13152");
        Verbs.AddLoca(CA!.Verb_Free.ID, "Adv_13153");

        CA!.Verb_Hold = Verbs.AddLoca( "Adv_13154");
        Verbs.AddLoca(CA!.Verb_Hold.ID, "Adv_13155");

        CA!.Verb_Pinch = Verbs.AddLoca( "Adv_13156");
        Verbs.AddLoca(CA!.Verb_Pinch.ID, "Adv_13157");

        CA!.Verb_Bury = Verbs.AddLoca( "Adv_13158");
        Verbs.AddLoca(CA!.Verb_Bury.ID, "Adv_13159");
        Verbs.AddLoca(CA!.Verb_Bury.ID, "Adv_13160");
        Verbs.AddLoca(CA!.Verb_Bury.ID, "Adv_13161");
        Verbs.AddLoca(CA!.Verb_Bury.ID, "Adv_13162");
        Verbs.AddLoca(CA!.Verb_Bury.ID, "Adv_13163");
        Verbs.AddLoca(CA!.Verb_Bury.ID, "Adv_13164");

        CA!.Verb_Bumse = Verbs.AddLoca( "Adv_13165");
        Verbs.AddLoca(CA!.Verb_Bumse.ID, "Adv_13166");
        Verbs.AddLoca(CA!.Verb_Bumse.ID, "Adv_13167");
        Verbs.AddLoca(CA!.Verb_Bumse.ID, "Adv_13168");
        Verbs.AddLoca(CA!.Verb_Bumse.ID, "Adv_13169");
        Verbs.AddLoca(CA!.Verb_Bumse.ID, "Adv_13170");

        CA!.Verb_Kitzle = Verbs.AddLoca( "Adv_13171");
        Verbs.AddLoca(CA!.Verb_Kitzle.ID, "Adv_13172");

        CA!.Verb_Kuschle = Verbs.AddLoca( "Adv_13173");
        Verbs.AddLoca(CA!.Verb_Kuschle.ID, "Adv_13174");

        CA!.Verb_Schlage = Verbs.AddLoca( "Adv_13175");
        Verbs.AddLoca(CA!.Verb_Schlage.ID, "Adv_13176");

        CA!.Verb_Streichle = Verbs.AddLoca( "Adv_13177");
        Verbs.AddLoca(CA!.Verb_Streichle.ID, "Adv_13178");

        CA!.Verb_Toete = Verbs.AddLoca( "Adv_13179");
        Verbs.AddLoca(CA!.Verb_Toete.ID, "Adv_13180");

        CA!.Verb_Joggle = Verbs.AddLoca( "Adv_13181");
        Verbs.AddLoca(CA!.Verb_Joggle.ID, "Adv_13182");
        
        CA!.Verb_Sleep = Verbs.AddLoca( "Adv_13183");
        Verbs.AddLoca(CA!.Verb_Sleep.ID, "Adv_13184");

        CA!.Verb_Spark = Verbs.AddLoca( "Adv_13185");
        Verbs.AddLoca(CA!.Verb_Spark.ID, "Adv_13186");
        CA!.Verb_Leave = Verbs.AddLoca( "Adv_13187");
        Verbs.AddLoca(CA!.Verb_Leave.ID, "Adv_13188");
        CA!.Verb_Determine = Verbs.AddLoca( "Adv_13189");
        Verbs.AddLoca(CA!.Verb_Determine.ID, "Adv_13190");
        CA!.Verb_Remove = Verbs.AddLoca( "Adv_13191");
        Verbs.AddLoca(CA!.Verb_Remove.ID, "Adv_13192");

        CA!.Verb_Clean = Verbs.AddLoca( "Adv_13193");
        Verbs.AddLoca(CA!.Verb_Clean.ID, "Adv_13194");
        Verbs.AddLoca(CA!.Verb_Clean.ID, "Adv_13195");
        Verbs.AddLoca(CA!.Verb_Clean.ID, "Adv_13196");
        Verbs.AddLoca(CA!.Verb_Clean.ID, "Adv_13197");
        Verbs.AddLoca(CA!.Verb_Clean.ID, "Adv_13198");
        Verbs.AddLoca(CA!.Verb_Clean.ID, "Adv_13199");
        Verbs.AddLoca(CA!.Verb_Clean.ID, "Adv_13200");
        Verbs.AddLoca(CA!.Verb_Clean.ID, "Adv_13201");
        Verbs.AddLoca(CA!.Verb_Clean.ID, "Adv_13202");

        CA!.Verb_Soil = Verbs.AddLoca("Verb_Soil");
        Verbs.AddLoca(CA!.Verb_Soil.ID, "Verb_Soil2");
        Verbs.AddLoca(CA!.Verb_Soil.ID, "Verb_Soil3");
        Verbs.AddLoca(CA!.Verb_Soil.ID, "Verb_Soil4");
        Verbs.AddLoca(CA!.Verb_Soil.ID, "Verb_Soil5");
        Verbs.AddLoca(CA!.Verb_Soil.ID, "Verb_Soil6");

        CA!.Verb_Wash = Verbs.AddLoca( "Adv_13203");
        Verbs.AddLoca(CA!.Verb_Wash.ID, "Adv_13204");

        CA!.Verb_Split = Verbs.AddLoca( "Adv_13205");
        Verbs.AddLoca(CA!.Verb_Split.ID, "Adv_13206");
        Verbs.AddLoca(CA!.Verb_Split.ID, "Adv_13207");
        Verbs.AddLoca(CA!.Verb_Split.ID, "Adv_13208");

        CA!.Verb_Fry = Verbs.AddLoca( "Adv_13209");
        Verbs.AddLoca(CA!.Verb_Fry.ID, "Adv_13210");

        CA!.Verb_Form = Verbs.AddLoca( "Adv_13211");

        CA!.Verb_Wrap = Verbs.AddLoca( "Adv_13212");
        Verbs.AddLoca(CA!.Verb_Wrap.ID, "Adv_13213");

        CA!.Verb_Paint = Verbs.AddLoca( "Adv_13214");
        Verbs.AddLoca(CA!.Verb_Paint.ID, "Adv_13215");
        Verbs.AddLoca(CA!.Verb_Paint.ID, "Adv_13216");
        Verbs.AddLoca(CA!.Verb_Paint.ID, "Adv_13217");

        CA!.Verb_Wear = Verbs.AddLoca( "Adv_13218");
        Verbs.AddLoca(CA!.Verb_Wear.ID, "Adv_13219");

        CA!.Verb_Search = Verbs.AddLoca( "Adv_13220");
        Verbs.AddLoca(CA!.Verb_Search.ID, "Adv_13221");

        CA!.Verb_Search2 = Verbs.AddLoca( "Adv_13222");
        Verbs.AddLoca(CA!.Verb_Search2.ID, "Adv_13223");

        CA!.Verb_Poke = Verbs.AddLoca( "Adv_13224");
        Verbs.AddLoca(CA!.Verb_Poke.ID, "Adv_13225");

        CA!.Verb_Dig = Verbs.AddLoca( "Adv_13226");
        Verbs.AddLoca(CA!.Verb_Dig.ID, "Adv_13227");

        CA!.Verb_Wake = Verbs.AddLoca( "Adv_13228");
        Verbs.AddLoca(CA!.Verb_Wake.ID, "Adv_13229");

        CA!.Verb_Shout = Verbs.AddLoca( "Adv_13230");
        Verbs.AddLoca(CA!.Verb_Shout.ID, "Adv_13231");
        Verbs.AddLoca(CA!.Verb_Shout.ID, "Adv_13232");
        Verbs.AddLoca(CA!.Verb_Shout.ID, "Adv_13233");

        CA!.Verb_Leave2 = Verbs.AddLoca( "Adv_13234");
        Verbs.AddLoca(CA!.Verb_Leave2.ID, "Adv_13235");

        CA!.Verb_Slide = Verbs.AddLoca( "Adv_13236");
        Verbs.AddLoca(CA!.Verb_Slide.ID, "Adv_13237");
        Verbs.AddLoca(CA!.Verb_Slide.ID, "Adv_13238");
        Verbs.AddLoca(CA!.Verb_Slide.ID, "Adv_13239");

        CA!.Verb_Attack = Verbs.AddLoca( "Adv_13240");
        Verbs.AddLoca(CA!.Verb_Attack.ID, "Adv_13241");

        CA!.Verb_Accede = Verbs.AddLoca( "Adv_13242");
        CA!.Verb_Be = Verbs.AddLoca( "Adv_13243");
        Verbs.AddLoca(CA!.Verb_Be.ID, "Adv_13244");
        Verbs.AddLoca(CA!.Verb_Be.ID, "Adv_13245");
        Verbs.AddLoca(CA!.Verb_Be.ID, "Adv_13246");
        Verbs.AddLoca(CA!.Verb_Be.ID, "Adv_13247");

        CA!.Verb_Repair = Verbs.AddLoca( "Adv_13248");
        Verbs.AddLoca(CA!.Verb_Repair.ID, "Adv_13249");

        CA!.Verb_Sort = Verbs.AddLoca( "Adv_13250");
        Verbs.AddLoca(CA!.Verb_Sort.ID, "Adv_13251");

        CA!.Verb_Confess = Verbs.AddLoca( "Adv_13252");
        Verbs.AddLoca(CA!.Verb_Confess.ID, "Adv_13253");

        CA!.Verb_Stroke = Verbs.AddLoca( "Adv_13254");
        Verbs.AddLoca(CA!.Verb_Stroke.ID, "Adv_13255");

        CA!.Verb_Switch = Verbs.AddLoca( "Adv_13256");
        Verbs.AddLoca(CA!.Verb_Switch.ID, "Adv_13257");

        CA!.Verb_Lift = Verbs.AddLoca( "Adv_13258");
        Verbs.AddLoca(CA!.Verb_Lift.ID, "Adv_13259");

        CA!.Verb_Wipe = Verbs.AddLoca( "Adv_13260");
        Verbs.AddLoca(CA!.Verb_Wipe.ID, "Adv_13261");

        CA!.Verb_Exits = Verbs.AddLoca( "Adv_13262");
        Verbs.AddLoca(CA!.Verb_Exits.ID, "Adv_13263");
        Verbs.AddLoca(CA!.Verb_Exits.ID, "Adv_13264");
        Verbs.AddLoca(CA!.Verb_Exits.ID, "Adv_13265");
        Verbs.AddLoca(CA!.Verb_Exits.ID, "Adv_13266");

        CA!.Verb_Steal = Verbs.AddLoca( "Adv_13267");
        Verbs.AddLoca(CA!.Verb_Steal.ID, "Adv_13268");

        CA!.Verb_Score = Verbs.AddLoca( "Adv_13269");
        Verbs.AddLoca(CA!.Verb_Score.ID, "Adv_13270");

        CA!.Verb_Move = Verbs.AddLoca( "Adv_13271");
        Verbs.AddLoca(CA!.Verb_Move.ID, "Adv_13272");

        CA!.Verb_Destroy = Verbs.AddLoca( "Adv_13273");
        Verbs.AddLoca(CA!.Verb_Destroy.ID, "Adv_13274");

        CA!.Verb_Chop = Verbs.AddLoca( "Adv_13275");
        Verbs.AddLoca(CA!.Verb_Chop.ID, "Adv_13276");
        Verbs.AddLoca(CA!.Verb_Chop.ID, "Adv_13277");
        Verbs.AddLoca(CA!.Verb_Chop.ID, "Adv_13278");
        Verbs.AddLoca(CA!.Verb_Chop.ID, "Adv_13279");
        Verbs.AddLoca(CA!.Verb_Chop.ID, "Adv_13280");


        CA!.Verb_Plunge = Verbs.AddLoca( "Adv_13281");
        Verbs.AddLoca(CA!.Verb_Plunge.ID, "Adv_13282");

        CA!.Verb_Roll = Verbs.AddLoca( "Adv_13283");
        Verbs.AddLoca(CA!.Verb_Roll.ID, "Adv_13284");

        CA!.Verb_Demolish = Verbs.AddLoca( "Adv_13285");
        Verbs.AddLoca(CA!.Verb_Demolish.ID, "Adv_13286");

        CA!.Verb_Crack = Verbs.AddLoca( "Adv_13287");
        Verbs.AddLoca(CA!.Verb_Crack.ID, "Adv_13288");

        CA!.Verb_Glue = Verbs.AddLoca( "Adv_13289");
        Verbs.AddLoca(CA!.Verb_Glue.ID, "Adv_13290");

        CA!.Verb_Heat = Verbs.AddLoca( "Adv_13291");
        Verbs.AddLoca(CA!.Verb_Heat.ID, "Adv_13292");

        CA!.Verb_Pulverize = Verbs.AddLoca( "Adv_13293");
        Verbs.AddLoca(CA!.Verb_Pulverize.ID, "Adv_13294");
        Verbs.AddLoca(CA!.Verb_Pulverize.ID, "Adv_13295");
        Verbs.AddLoca(CA!.Verb_Pulverize.ID, "Adv_13296");
        Verbs.AddLoca(CA!.Verb_Pulverize.ID, "Verb_zerstosse");
        Verbs.AddLoca(CA!.Verb_Pulverize.ID, "Verb_zerstoss");
        Verbs.AddLoca(CA!.Verb_Pulverize.ID, "Verb_zerdruecke");
        Verbs.AddLoca(CA!.Verb_Pulverize.ID, "Verb_zerdrueck");

        CA!.Verb_Tidy = Verbs.AddLoca( "Adv_13297");
        Verbs.AddLoca(CA!.Verb_Tidy.ID, "Adv_13298");

        CA!.Verb_Brush = Verbs.AddLoca( "Adv_13299");
        Verbs.AddLoca(CA!.Verb_Brush.ID, "Adv_13300");

        CA!.Verb_Type = Verbs.AddLoca( "Adv_13301");

        CA!.Verb_Dance = Verbs.AddLoca( "Adv_13302");
        Verbs.AddLoca(CA!.Verb_Dance.ID, "Adv_13303");

        CA!.Verb_Swing = Verbs.AddLoca( "Adv_13304");
        Verbs.AddLoca(CA!.Verb_Swing.ID, "Adv_13305");

        CA!.Verb_Store = Verbs.AddLoca( "Adv_13306");
        Verbs.AddLoca(CA!.Verb_Store.ID, "Adv_13307");

        CA!.Verb_Sing = Verbs.AddLoca( "Adv_13308");
        Verbs.AddLoca(CA!.Verb_Sing.ID, "Adv_13309");

        CA!.Verb_Lick = Verbs.AddLoca( "Adv_13310");
        Verbs.AddLoca(CA!.Verb_Lick.ID, "Adv_13311");

        CA!.Verb_Hide = Verbs.AddLoca( "Adv_13312");
        Verbs.AddLoca(CA!.Verb_Hide.ID, "Adv_13313");

        CA!.Verb_Tear = Verbs.AddLoca( "Adv_13314");
        Verbs.AddLoca(CA!.Verb_Tear.ID, "Adv_13315");

        CA!.Verb_Rip = Verbs.AddLoca( "Adv_13316");
        Verbs.AddLoca(CA!.Verb_Rip.ID, "Adv_13317");

        CA!.Verb_Burn = Verbs.AddLoca( "Adv_13318");
        Verbs.AddLoca(CA!.Verb_Burn.ID, "Adv_13319");

        CA!.Verb_Smoke = Verbs.AddLoca( "Adv_13320");
        Verbs.AddLoca(CA!.Verb_Smoke.ID, "Adv_13321");

        CA!.Verb_Lay = Verbs.AddLoca( "Adv_13322");
        Verbs.AddLoca(CA!.Verb_Lay.ID, "Adv_13323");

        CA!.Verb_Crumble = Verbs.AddLoca( "Adv_13324");
        Verbs.AddLoca(CA!.Verb_Crumble.ID, "Adv_13325");
        Verbs.AddLoca(CA!.Verb_Crumble.ID, "Adv_13326");

        CA!.Verb_Let = Verbs.AddLoca( "Adv_13327");
        Verbs.AddLoca(CA!.Verb_Let.ID, "Adv_13328");

        CA!.Verb_Kiss = Verbs.AddLoca( "Adv_13329");
        Verbs.AddLoca(CA!.Verb_Kiss.ID, "Adv_13330");

        CA!.Verb_Pray = Verbs.AddLoca( "Adv_13331");
        Verbs.AddLoca(CA!.Verb_Pray.ID, "Adv_13332");

        CA!.Verb_Bend = Verbs.AddLoca( "Adv_13333");
        Verbs.AddLoca(CA!.Verb_Bend.ID, "Adv_13334");

        CA!.Verb_Leverage = Verbs.AddLoca( "Adv_13335");


        CA!.Verb_Count = Verbs.AddLoca( "Adv_13336");
        Verbs.AddLoca(CA!.Verb_Count.ID, "Adv_13337");

        CA!.Verb_Scroll = Verbs.AddLoca( "Adv_13338");

        CA!.Verb_Credits = Verbs.AddLoca( "Adv_13339");
        Verbs.AddLoca(CA!.Verb_Credits.ID, "Adv_13340");

        CA!.Verb_Make = Verbs.AddLoca( "Adv_13341");
        Verbs.AddLoca(CA!.Verb_Make.ID, "Adv_13342");

        CA!.Verb_Breath = Verbs.AddLoca( "Adv_13343");

        CA!.Verb_Spray = Verbs.AddLoca( "Adv_13344");
        Verbs.AddLoca(CA!.Verb_Spray.ID, "Adv_13345");

        CA!.Verb_Illustration = Verbs.AddLoca( "Adv_13346");
        Verbs.AddLoca(CA!.Verb_Illustration.ID, "Adv_13347");

        CA!.Verb_Unlock = Verbs.AddLoca("Adv_Unlock");

        CA!.Verb_Lock = Verbs.AddLoca("Adv_Lock");

        CA!.Verb_Abandon = Verbs.AddLoca("Adv_Abandon");

        CA!.Verb_Untie = Verbs.AddLoca("Adv_Untie");
    }

    public void InitVerbsPart1Fast(int size = -1)
    {
        if (size != -1)
        {
            Verbs!.TList = new Dictionary<string, Verb>(size, StringComparer.CurrentCultureIgnoreCase);

        }
        var Verblist = new List<KeyValuePair<string, Verb>>(600);

        Verbs!.SetupVerbBuffer(600);


        CB!.Verb_German = Verbs.AddLocaLoca( loca.AdvBase_Deutsch, "AdvBase_Deutsch");
        Verbs.AddLocaLoca( loca.AdvBase_Deutsch2, CB!.Verb_German.ID, "AdvBase_Deutsch2");
        Verbs.AddLocaLoca( loca.AdvBase_Deutsch3, CB!.Verb_German.ID, "AdvBase_Deutsch3");
        CB!.Verb_English = Verbs.AddLocaLoca( loca.AdvBase_Englisch, "AdvBase_Englisch");
        Verbs.AddLocaLoca( loca.AdvBase_Englisch2, CB!.Verb_English.ID, "AdvBase_Englisch2");
        Verbs.AddLocaLoca( loca.AdvBase_Englisch3, CB!.Verb_English.ID, "AdvBase_Englisch3");

        CB!.Verb_N = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14129, "AdvBase_InitializeGame_14129");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14130, CB!.Verb_N.ID, "AdvBase_InitializeGame_14130");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14131, CB!.Verb_N.ID, "AdvBase_InitializeGame_14131");

        CB!.Verb_NE = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14132, "AdvBase_InitializeGame_14132");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14133, CB!.Verb_NE.ID, "AdvBase_InitializeGame_14133");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14134, CB!.Verb_NE.ID, "AdvBase_InitializeGame_14134");

        CB!.Verb_E = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14135, "AdvBase_InitializeGame_14135");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14136, CB!.Verb_E.ID, "AdvBase_InitializeGame_14136");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14137, CB!.Verb_E.ID, "AdvBase_InitializeGame_14137");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14138, CB!.Verb_E.ID, "AdvBase_InitializeGame_14138");

        CB!.Verb_SE = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14139, "AdvBase_InitializeGame_14139");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14140, CB!.Verb_SE.ID, "AdvBase_InitializeGame_14140");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14141, CB!.Verb_SE.ID, "AdvBase_InitializeGame_14141");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14142, CB!.Verb_SE.ID, "AdvBase_InitializeGame_14142");

        CB!.Verb_S = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14143, "AdvBase_InitializeGame_14143");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14144, CB!.Verb_S.ID, "AdvBase_InitializeGame_14144");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14145, CB!.Verb_S.ID, "AdvBase_InitializeGame_14145");

        CB!.Verb_SW = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14146, "AdvBase_InitializeGame_14146");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14147, CB!.Verb_SW.ID, "AdvBase_InitializeGame_14147");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14148, CB!.Verb_SW.ID, "AdvBase_InitializeGame_14148");

        CB!.Verb_W = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14149, "AdvBase_InitializeGame_14149");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14150, CB!.Verb_W.ID, "AdvBase_InitializeGame_14150");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14151, CB!.Verb_W.ID, "AdvBase_InitializeGame_14151");

        CB!.Verb_NW = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14152, "AdvBase_InitializeGame_14152");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14153, CB!.Verb_NW.ID, "AdvBase_InitializeGame_14153");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14154, CB!.Verb_NW.ID, "AdvBase_InitializeGame_14154");

        CB!.Verb_U = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14155, "AdvBase_InitializeGame_14155");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14156, CB!.Verb_U.ID, "AdvBase_InitializeGame_14156");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14157, CB!.Verb_U.ID, "AdvBase_InitializeGame_14157");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14158, CB!.Verb_U.ID, "AdvBase_InitializeGame_14158");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14159, CB!.Verb_U.ID, "AdvBase_InitializeGame_14159");

        CB!.Verb_D = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14160, "AdvBase_InitializeGame_14160");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14161, CB!.Verb_D.ID, "AdvBase_InitializeGame_14161");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14162, CB!.Verb_D.ID, "AdvBase_InitializeGame_14162");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14163, CB!.Verb_D.ID, "AdvBase_InitializeGame_14163");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14164, CB!.Verb_D.ID, "AdvBase_InitializeGame_14164");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14165, CB!.Verb_D.ID, "AdvBase_InitializeGame_14165");

        CB!.Verb_Inventory = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14166, "AdvBase_InitializeGame_14166");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14167, CB!.Verb_Inventory.ID, "AdvBase_InitializeGame_14167");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14168, CB!.Verb_Inventory.ID, "AdvBase_InitializeGame_14168");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14169, CB!.Verb_Inventory.ID, "AdvBase_InitializeGame_14169");

        CB!.Verb_location = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14170, "AdvBase_InitializeGame_14170");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14171, CB!.Verb_location.ID, "AdvBase_InitializeGame_14171");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14172, CB!.Verb_location.ID, "AdvBase_InitializeGame_14172");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14173, CB!.Verb_location.ID, "AdvBase_InitializeGame_14173");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14174, CB!.Verb_location.ID, "AdvBase_InitializeGame_14174");

        CB!.Verb_Examine = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14175, "AdvBase_InitializeGame_14175");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14176, CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14176");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14177, CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14177");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14178, CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14178");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14179, CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14179");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14180, CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14180");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14181, CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14181");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14182, CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14182");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14183, CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14183");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14184, CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14184");

        CB!.Verb_Take = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14185, "AdvBase_InitializeGame_14185");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14186, CB!.Verb_Take.ID, "AdvBase_InitializeGame_14186");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14187, CB!.Verb_Take.ID, "AdvBase_InitializeGame_14187");

        CB!.Verb_Go = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14188, "AdvBase_InitializeGame_14188");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14189, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14189");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14190, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14190");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14191, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14191");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14192, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14192");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14193, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14193");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14194, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14194");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14195, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14195");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14196, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14196");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14197, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14197");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14198, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14198");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14199, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14199");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14200, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14200");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14201, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14201");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14202, CB!.Verb_Go.ID, "AdvBase_InitializeGame_14202");

        CB!.Verb_Enter = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14203, "AdvBase_InitializeGame_14203");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14204, CB!.Verb_Enter.ID, "AdvBase_InitializeGame_14204");

        CB!.Verb_Climb = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14205, "AdvBase_InitializeGame_14205");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14206, CB!.Verb_Climb.ID, "AdvBase_InitializeGame_14206");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14207, CB!.Verb_Climb.ID, "AdvBase_InitializeGame_14207");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14208, CB!.Verb_Climb.ID, "AdvBase_InitializeGame_14208");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14209, CB!.Verb_Climb.ID, "AdvBase_InitializeGame_14209");

        CB!.Verb_Use = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14210, "AdvBase_InitializeGame_14210");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14211, CB!.Verb_Use.ID, "AdvBase_InitializeGame_14211");

        CB!.Verb_Unscrew = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_Unscrew, "AdvBase_InitializeGame_Unscrew");

        CB!.Verb_Truncate = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_Truncate, "AdvBase_InitializeGame_Truncate");

        CB!.Verb_Words = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14212, "AdvBase_InitializeGame_14212");

        CB!.Verb_Verbs = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14213, "AdvBase_InitializeGame_14213");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14214, CB!.Verb_Verbs.ID, "AdvBase_InitializeGame_14214");

        CB!.Verb_ProtOn = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14215, "AdvBase_InitializeGame_14215");
        CB!.Verb_ProtOff = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14216, "AdvBase_InitializeGame_14216");


        CB!.Verb_Drop = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14217, "AdvBase_InitializeGame_14217");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14218, CB!.Verb_Drop.ID, "AdvBase_InitializeGame_14218");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14219, CB!.Verb_Drop.ID, "AdvBase_InitializeGame_14219");

        CB!.Verb_Place = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14220, "AdvBase_InitializeGame_14220");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14221, CB!.Verb_Place.ID, "AdvBase_InitializeGame_14221");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14222, CB!.Verb_Place.ID, "AdvBase_InitializeGame_14222");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14223, CB!.Verb_Place.ID, "AdvBase_InitializeGame_14223");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14224, CB!.Verb_Place.ID, "AdvBase_InitializeGame_14224");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14225, CB!.Verb_Place.ID, "AdvBase_InitializeGame_14225");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14226, CB!.Verb_Place.ID, "AdvBase_InitializeGame_14226");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14227, CB!.Verb_Place.ID, "AdvBase_InitializeGame_14227");

        CB!.Verb_Open = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14228, "AdvBase_InitializeGame_14228");

        CB!.Verb_Close = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14229, "AdvBase_InitializeGame_14229");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14230, CB!.Verb_Close.ID, "AdvBase_InitializeGame_14230");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14231, CB!.Verb_Close.ID, "AdvBase_InitializeGame_14231");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14232, CB!.Verb_Close.ID, "AdvBase_InitializeGame_14232");

        CB!.Verb_Lock_W = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14233, "AdvBase_InitializeGame_14233");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14234, CB!.Verb_Lock_W.ID, "AdvBase_InitializeGame_14234");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14235, CB!.Verb_Lock_W.ID, "AdvBase_InitializeGame_14235");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14236, CB!.Verb_Lock_W.ID, "AdvBase_InitializeGame_14236");

 
        CB!.Verb_Save = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14237, "AdvBase_InitializeGame_14237");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14238, CB!.Verb_Save.ID, "AdvBase_InitializeGame_14238");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14239, CB!.Verb_Save.ID, "AdvBase_InitializeGame_14239");

        CB!.Verb_Load = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14240, "AdvBase_InitializeGame_14240");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14241, CB!.Verb_Load.ID, "AdvBase_InitializeGame_14241");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14242, CB!.Verb_Load.ID, "AdvBase_InitializeGame_14242");

        CB!.Verb_Help = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14243, "AdvBase_InitializeGame_14243");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14244, CB!.Verb_Help.ID, "AdvBase_InitializeGame_14244");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14245, CB!.Verb_Help.ID, "AdvBase_InitializeGame_14245");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14246, CB!.Verb_Help.ID, "AdvBase_InitializeGame_14246");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14247, CB!.Verb_Help.ID, "AdvBase_InitializeGame_14247");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14248, CB!.Verb_Help.ID, "AdvBase_InitializeGame_14248");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14249, CB!.Verb_Help.ID, "AdvBase_InitializeGame_14249");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14250, CB!.Verb_Help.ID, "AdvBase_InitializeGame_14250");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14251, CB!.Verb_Help.ID, "AdvBase_InitializeGame_14251");

        CB!.Verb_Info = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14252, "AdvBase_InitializeGame_14252");

        CB!.Verb_Clue = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14253, "AdvBase_InitializeGame_14253");

        CB!.Verb_Solution = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14254, "AdvBase_InitializeGame_14254");

        CB!.Verb_Give = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14255, "AdvBase_InitializeGame_14255");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14256, CB!.Verb_Give.ID, "AdvBase_InitializeGame_14256");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14257, CB!.Verb_Give.ID, "AdvBase_InitializeGame_14257");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14258, CB!.Verb_Give.ID, "AdvBase_InitializeGame_14258");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14259, CB!.Verb_Give.ID, "AdvBase_InitializeGame_14259");

        CB!.Verb_Show = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14260, "AdvBase_InitializeGame_14260");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14261, CB!.Verb_Show.ID, "AdvBase_InitializeGame_14261");
        // Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14261, CB!.Verb_Show.ID, "AdvBase_InitializeGame_14261");

        CB!.Verb_Plea = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14262, "AdvBase_InitializeGame_14262");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14263, CB!.Verb_Plea.ID, "AdvBase_InitializeGame_14263");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14264, CB!.Verb_Plea.ID, "AdvBase_InitializeGame_14264");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14265, CB!.Verb_Plea.ID, "AdvBase_InitializeGame_14265");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14266, CB!.Verb_Plea.ID, "AdvBase_InitializeGame_14266");

        CB!.Verb_Demand = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14267, "AdvBase_InitializeGame_14267");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14268, CB!.Verb_Demand.ID, "AdvBase_InitializeGame_14268");

        CB!.Verb_Say = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14269, "AdvBase_InitializeGame_14269");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14270, CB!.Verb_Say.ID, "AdvBase_InitializeGame_14270");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14271, CB!.Verb_Say.ID, "AdvBase_InitializeGame_14271");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14272, CB!.Verb_Say.ID, "AdvBase_InitializeGame_14272");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14273, CB!.Verb_Say.ID, "AdvBase_InitializeGame_14273");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14274, CB!.Verb_Say.ID, "AdvBase_InitializeGame_14274");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14275, CB!.Verb_Say.ID, "AdvBase_InitializeGame_14275");

        CB!.Verb_Ask = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14276, "AdvBase_InitializeGame_14276");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14277, CB!.Verb_Ask.ID, "AdvBase_InitializeGame_14277");

        CB!.Verb_Taste = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14278, "AdvBase_InitializeGame_14278");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14279, CB!.Verb_Taste.ID, "AdvBase_InitializeGame_14279");

        CB!.Verb_Smell = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14280, "AdvBase_InitializeGame_14280");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14281, CB!.Verb_Smell.ID, "AdvBase_InitializeGame_14281");

        CB!.Verb_Wait = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14282, "AdvBase_InitializeGame_14282");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14283, CB!.Verb_Wait.ID, "AdvBase_InitializeGame_14283");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14284, CB!.Verb_Wait.ID, "AdvBase_InitializeGame_14284");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14285, CB!.Verb_Wait.ID, "AdvBase_InitializeGame_14285");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14286, CB!.Verb_Wait.ID, "AdvBase_InitializeGame_14286");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14287, CB!.Verb_Wait.ID, "AdvBase_InitializeGame_14287");

        CB!.Verb_Quit = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14288, "AdvBase_InitializeGame_14288");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14289, CB!.Verb_Quit.ID, "AdvBase_InitializeGame_14289");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14290, CB!.Verb_Quit.ID, "AdvBase_InitializeGame_14290");

        CB!.Verb_Restart = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14291, "AdvBase_InitializeGame_14291");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14292, CB!.Verb_Restart.ID, "AdvBase_InitializeGame_14292");

        CB!.Verb_Startpoint = Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14293, "AdvBase_InitializeGame_14293");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14294, CB!.Verb_Startpoint.ID, "AdvBase_InitializeGame_14294");
        Verbs.AddLocaLoca( loca.AdvBase_InitializeGame_14295, CB!.Verb_Startpoint.ID, "AdvBase_InitializeGame_14295");

    }
    public void InitVerbsPart2Fast(int size = -1)
    {
        CA!.Verb_Enlight = Verbs!.AddLocaLoca(loca.Verb_beleuchte, "Verb_beleuchte");
        Verbs.AddLocaLoca(loca.Verb_bescheine, CA!.Verb_Enlight.ID, "Verb_bescheine");
        Verbs.AddLocaLoca(loca.Verb_erhelle, CA!.Verb_Enlight.ID, "Verb_erhelle");

        CA!.Verb_Spread = Verbs!.AddLocaLoca(loca.Verb_streue, "Verb_streue");

        CA!.Verb_Story = Verbs!.AddLocaLoca( loca.Order_Story, "Order_Story");
        Verbs.AddLocaLoca( loca.Verb_Script, CA!.Verb_Story.ID, "Verb_Script");

        CA!.Verb_Undo = Verbs!.AddLocaLoca( loca.Verb_Undo, "Verb_Undo");

        CA!.Verb_Testwindow = Verbs.AddLocaLoca( loca.Adv_13001, "Adv_13001");

        CA!.Verb_Phone = Verbs.AddLocaLoca( loca.Adv_13002, "Adv_13002");

        CA!.Verb_Throw = Verbs.AddLocaLoca( loca.Adv_13003, "Adv_13003");
        Verbs.AddLocaLoca( loca.Adv_13004, CA!.Verb_Throw.ID, "Adv_13004");

        CA!.Verb_Brief = Verbs.AddLocaLoca( loca.Adv_13005, "Adv_13005");
        Verbs.AddLocaLoca( loca.Adv_13006, CA!.Verb_Brief.ID, "Adv_13006");

        CA!.Verb_Verbose = Verbs.AddLocaLoca( loca.Adv_13007, "Adv_13007");
        Verbs.AddLocaLoca( loca.Adv_13008, CA!.Verb_Verbose.ID, "Adv_13008");

        CA!.Verb_Push = Verbs.AddLocaLoca( loca.Adv_13009, "Adv_13009");
        Verbs.AddLocaLoca( loca.Adv_13010, CA!.Verb_Push.ID, "Adv_13010");
        Verbs.AddLocaLoca( loca.Adv_13011, CA!.Verb_Push.ID, "Adv_13011");
        Verbs.AddLocaLoca( loca.Adv_13012, CA!.Verb_Push.ID, "Adv_13012");
        Verbs.AddLocaLoca( loca.Adv_13013, CA!.Verb_Push.ID, "Adv_13013");
        Verbs.AddLocaLoca( loca.Adv_13014, CA!.Verb_Push.ID, "Adv_13014");

        CA!.Verb_Draw = Verbs.AddLocaLoca( loca.Adv_13015, "Adv_13015");
        Verbs.AddLocaLoca( loca.Adv_13016, CA!.Verb_Draw.ID, "Adv_13016");

        CA!.Verb_Read = Verbs.AddLocaLoca( loca.Adv_13017, "Adv_13017");
        Verbs.AddLocaLoca( loca.Adv_13018, CA!.Verb_Read.ID, "Adv_13018");
        Verbs.AddLocaLoca( loca.Adv_13019, CA!.Verb_Read.ID, "Adv_13019");

        CA!.Verb_Untighten = Verbs.AddLocaLoca( loca.Adv_13020, "Adv_13020");
        Verbs.AddLocaLoca( loca.Adv_13021, CA!.Verb_Untighten.ID, "Adv_13021");
        Verbs.AddLocaLoca( loca.Adv_13022, CA!.Verb_Untighten.ID, "Adv_13022");
        Verbs.AddLocaLoca( loca.Adv_13023, CA!.Verb_Untighten.ID, "Adv_13023");

        CA!.Verb_Break = Verbs.AddLocaLoca( loca.Adv_13024, "Adv_13024");
        Verbs.AddLocaLoca( loca.Adv_13025, CA!.Verb_Break.ID, "Adv_13025");
        Verbs.AddLocaLoca( loca.Adv_13026, CA!.Verb_Break.ID, "Adv_13026");
        Verbs.AddLocaLoca( loca.Adv_13027, CA!.Verb_Break.ID, "Adv_13027");

        CA!.Verb_Cut = Verbs.AddLocaLoca( loca.Adv_13028, "Adv_13028");
        Verbs.AddLocaLoca( loca.Adv_13029, CA!.Verb_Cut.ID, "Adv_13029");
        Verbs.AddLocaLoca( loca.Adv_13030, CA!.Verb_Cut.ID, "Adv_13030");

        CA!.Verb_Tie = Verbs.AddLocaLoca( loca.Adv_13031, "Adv_13031");
        Verbs.AddLocaLoca( loca.Adv_13032, CA!.Verb_Tie.ID, "Adv_13032");
        Verbs.AddLocaLoca( loca.Adv_13033, CA!.Verb_Tie.ID, "Adv_13033");
        Verbs.AddLocaLoca( loca.Adv_13034, CA!.Verb_Tie.ID, "Adv_13034");
        Verbs.AddLocaLoca( loca.Adv_13035, CA!.Verb_Tie.ID, "Adv_13035");

        CA!.Verb_Fish = Verbs.AddLocaLoca( loca.Adv_13036, "Adv_13036");

        CA!.Verb_Light = Verbs.AddLocaLoca( loca.Adv_13037, "Adv_13037");
        Verbs.AddLocaLoca( loca.Adv_13038, CA!.Verb_Light.ID, "Adv_13038");
        Verbs.AddLocaLoca( loca.Adv_13039, CA!.Verb_Light.ID, "Adv_13039");
        Verbs.AddLocaLoca( loca.Adv_13040, CA!.Verb_Light.ID, "Adv_13040");
        Verbs.AddLocaLoca( loca.Adv_13041, CA!.Verb_Light.ID, "Adv_13041");
        Verbs.AddLocaLoca( loca.Adv_13042, CA!.Verb_Light.ID, "Adv_13042");

        CA!.Verb_Extinguish = Verbs.AddLocaLoca( loca.Adv_13043, "Adv_13043");
        Verbs.AddLocaLoca( loca.Adv_13044, CA!.Verb_Extinguish.ID, "Adv_13044");

        CA!.Verb_Grab = Verbs.AddLocaLoca( loca.Adv_13045, "Adv_13045");
        Verbs.AddLocaLoca( loca.Adv_13046, CA!.Verb_Grab.ID, "Adv_13046");

        CA!.Verb_Eat = Verbs.AddLocaLoca( loca.Adv_13047, "Adv_13047");
        Verbs.AddLocaLoca( loca.Adv_13048, CA!.Verb_Eat.ID, "Adv_13048");
        Verbs.AddLocaLoca( loca.Adv_13049, CA!.Verb_Eat.ID, "Adv_13049");

        CA!.Verb_Sell = Verbs.AddLocaLoca( loca.Adv_13050, "Adv_13050");
        Verbs.AddLocaLoca( loca.Adv_13051, CA!.Verb_Sell.ID, "Adv_13051");
        Verbs.AddLocaLoca( loca.Adv_13052, CA!.Verb_Sell.ID, "Adv_13052");
        Verbs.AddLocaLoca( loca.Adv_13053, CA!.Verb_Sell.ID, "Adv_13053");

        CA!.Verb_Fill = Verbs.AddLocaLoca( loca.Adv_13054, "Adv_13054");
        Verbs.AddLocaLoca( loca.Adv_13055, CA!.Verb_Fill.ID, "Adv_13055");

        CA!.Verb_Stuff = Verbs.AddLocaLoca( loca.Adv_13056, "Adv_13056");
        Verbs.AddLocaLoca( loca.Adv_13057, CA!.Verb_Fill.ID, "Adv_13057");

        CA!.Verb_Pick = Verbs.AddLocaLoca( loca.Adv_13058, "Adv_13058");
        Verbs.AddLocaLoca( loca.Adv_13059, CA!.Verb_Pick.ID, "Adv_13059");

        CA!.Verb_Catch = Verbs.AddLocaLoca( loca.Adv_13060, "Adv_13060");
        Verbs.AddLocaLoca( loca.Adv_13061, CA!.Verb_Catch.ID, "Adv_13061");

        CA!.Verb_Drink = Verbs.AddLocaLoca( loca.Adv_13062, "Adv_13062");
        Verbs.AddLocaLoca( loca.Adv_13063, CA!.Verb_Drink.ID, "Adv_13063");

        CA!.Verb_Touch = Verbs.AddLocaLoca( loca.Adv_13064, "Adv_13064");
        Verbs.AddLocaLoca( loca.Adv_13065, CA!.Verb_Touch.ID, "Adv_13065");

        CA!.Verb_Knock = Verbs.AddLocaLoca( loca.Adv_13066, "Adv_13066");
        Verbs.AddLocaLoca( loca.Adv_13067, CA!.Verb_Knock.ID, "Adv_13067");

        CA!.Verb_Spit = Verbs.AddLocaLoca( loca.Adv_13068, "Adv_13068");
        Verbs.AddLocaLoca( loca.Adv_13069, CA!.Verb_Spit.ID, "Adv_13069");
        Verbs.AddLocaLoca( loca.Adv_13070, CA!.Verb_Spit.ID, "Adv_13070");
        Verbs.AddLocaLoca( loca.Adv_13071, CA!.Verb_Spit.ID, "Adv_13071");

        CA!.Verb_Listen = Verbs.AddLocaLoca( loca.Adv_13072, "Adv_13072");
        Verbs.AddLocaLoca( loca.Adv_13073, CA!.Verb_Listen.ID, "Adv_13073");
        Verbs.AddLocaLoca( loca.Adv_13074, CA!.Verb_Listen.ID, "Adv_13074");
        Verbs.AddLocaLoca( loca.Adv_13075, CA!.Verb_Listen.ID, "Adv_13075");
        Verbs.AddLocaLoca( loca.Adv_13076, CA!.Verb_Listen.ID, "Adv_13076");
        Verbs.AddLocaLoca( loca.Adv_13077, CA!.Verb_Listen.ID, "Adv_13077");

        CA!.Verb_Attach = Verbs.AddLocaLoca( loca.Adv_13078, "Adv_13078");
        Verbs.AddLocaLoca( loca.Adv_13079, CA!.Verb_Attach.ID, "Adv_13079");

        CA!.Verb_Attach2 = Verbs.AddLocaLoca( loca.Verb_Attach, "Verb_Attach");
        Verbs.AddLocaLoca( loca.Verb_Fix, CA!.Verb_Attach2.ID, "Verb_Fix");

        CA!.Verb_Play = Verbs.AddLocaLoca( loca.Verb_Play, "Verb_Play");

        CA!.Verb_Phoneyvision = Verbs.AddLocaLoca( loca.Verb_Phoneyvision, "Verb_Phoneyvision");

        CA!.Verb_Realitaet = Verbs.AddLocaLoca( loca.Verb_Realitaet, "Verb_Realitaet");

        CA!.Verb_Hang = Verbs.AddLocaLoca( loca.Adv_13080, "Adv_13080");
        Verbs.AddLocaLoca( loca.Adv_13081, CA!.Verb_Hang.ID, "Adv_13081");

        CA!.Verb_Dip = Verbs.AddLocaLoca( loca.Adv_13082, "Adv_13082");
        Verbs.AddLocaLoca( loca.Adv_13083, CA!.Verb_Dip.ID, "Adv_13083");
        Verbs.AddLocaLoca( loca.Adv_13084, CA!.Verb_Dip.ID, "Adv_13084");
        Verbs.AddLocaLoca( loca.Adv_13085, CA!.Verb_Dip.ID, "Adv_13085");

        CA!.Verb_Tip = Verbs.AddLocaLoca(loca.Adv_13086, "Adv_13086");
        Verbs.AddLocaLoca( loca.Adv_13087, CA!.Verb_Tip.ID, "Adv_13087");
        Verbs.AddLocaLoca( loca.Adv_13088, CA!.Verb_Tip.ID, "Adv_13088");
        Verbs.AddLocaLoca( loca.Adv_13089, CA!.Verb_Tip.ID, "Adv_13089");

        CA!.Verb_Water = Verbs.AddLocaLoca( loca.Adv_13090, "Adv_13090");
        Verbs.AddLocaLoca( loca.Adv_13091, CA!.Verb_Water.ID, "Adv_13091");

        CA!.Verb_Arrest = Verbs.AddLocaLoca( loca.Adv_13092, "Adv_13092");

        CA!.Verb_Meditate = Verbs.AddLocaLoca( loca.Adv_13093, "Adv_13093");
        Verbs.AddLocaLoca( loca.Adv_13094, CA!.Verb_Meditate.ID, "Adv_13094");

        CA!.Verb_Press = Verbs.AddLocaLoca( loca.Adv_13095, "Adv_13095");
        Verbs.AddLocaLoca( loca.Adv_13096, CA!.Verb_Press.ID, "Adv_13096");
        Verbs.AddLocaLoca( loca.Adv_13097, CA!.Verb_Press.ID, "Adv_13097");

        CA!.Verb_Puncture = Verbs.AddLocaLoca( loca.Adv_13098, "Adv_13098");
        Verbs.AddLocaLoca( loca.Adv_13099, CA!.Verb_Puncture.ID, "Adv_13099");
        Verbs.AddLocaLoca( loca.Adv_13100, CA!.Verb_Puncture.ID, "Adv_13100");
        Verbs.AddLocaLoca( loca.Adv_13101, CA!.Verb_Puncture.ID, "Adv_13101");
        Verbs.AddLocaLoca( loca.Adv_Verb_perforiere, CA!.Verb_Puncture.ID, "Adv_Verb_perforiere");
        Verbs.AddLocaLoca( loca.Adv_Verb_durchsteche, CA!.Verb_Puncture.ID, "Adv_Verb_durchsteche");
        Verbs.AddLocaLoca( loca.Adv_Verb_bohre, CA!.Verb_Puncture.ID, "Adv_Verb_bohre");
        Verbs.AddLocaLoca( loca.Adv_Verb_durchbohre, CA!.Verb_Puncture.ID, "Adv_Verb_durchbohre");

        CA!.Verb_Photograph = Verbs.AddLocaLoca( loca.Adv_13102, "Adv_13102");
        Verbs.AddLocaLoca( loca.Adv_13103, CA!.Verb_Photograph.ID, "Adv_13103");

        CA!.Verb_Mount = Verbs.AddLocaLoca( loca.Adv_13104, "Adv_13104");
        Verbs.AddLocaLoca( loca.Adv_13105, CA!.Verb_Mount.ID, "Adv_13105");

        CA!.Verb_Saw = Verbs.AddLocaLoca( loca.Adv_13106, "Adv_13106");
        Verbs.AddLocaLoca( loca.Adv_13107, CA!.Verb_Saw.ID, "Adv_13107");

        CA!.Verb_Smear = Verbs.AddLocaLoca( loca.Adv_13108, "Adv_13108");
        Verbs.AddLocaLoca( loca.Adv_13109, CA!.Verb_Smear.ID, "Adv_13109");

        CA!.Verb_Smear2 = Verbs.AddLocaLoca( loca.Adv_13110, "Adv_13110");
        Verbs.AddLocaLoca( loca.Adv_13111, CA!.Verb_Smear2.ID, "Adv_13111");

        CA!.Verb_Blow = Verbs.AddLocaLoca( loca.Adv_13112, "Adv_13112");
        Verbs.AddLocaLoca( loca.Adv_13113, CA!.Verb_Blow.ID, "Adv_13113");
        Verbs.AddLocaLoca( loca.Adv_13114, CA!.Verb_Blow.ID, "Adv_13114");
        Verbs.AddLocaLoca( loca.Adv_13115, CA!.Verb_Blow.ID, "Adv_13115");
        Verbs.AddLocaLoca( loca.Adv_13116, CA!.Verb_Blow.ID, "Adv_13116");

        CA!.Verb_Poison = Verbs.AddLocaLoca( loca.Adv_13117, "Adv_13117");

        CA!.Verb_Compare = Verbs.AddLocaLoca( loca.Adv_13118, "Adv_13118");
        Verbs.AddLocaLoca( loca.Adv_13119, CA!.Verb_Compare.ID, "Adv_13119");

        CA!.Verb_Creep = Verbs.AddLocaLoca( loca.Adv_13120, "Adv_13120");
        Verbs.AddLocaLoca( loca.Adv_13121, CA!.Verb_Creep.ID, "Adv_13121");

        CA!.Verb_Follow = Verbs.AddLocaLoca( loca.Adv_13122, "Adv_13122");
        Verbs.AddLocaLoca( loca.Adv_13123, CA!.Verb_Follow.ID, "Adv_13123");
        Verbs.AddLocaLoca( loca.Adv_13124, CA!.Verb_Follow.ID, "Adv_13124");
        Verbs.AddLocaLoca( loca.Adv_13125, CA!.Verb_Follow.ID, "Adv_13125");

        CA!.Verb_Jump = Verbs.AddLocaLoca( loca.Adv_13126, "Adv_13126");
        Verbs.AddLocaLoca( loca.Adv_13127, CA!.Verb_Jump.ID, "Adv_13127");
        Verbs.AddLocaLoca( loca.Adv_13128, CA!.Verb_Jump.ID, "Adv_13128");
        Verbs.AddLocaLoca( loca.Adv_13129, CA!.Verb_Jump.ID, "Adv_13129");

        CA!.Verb_Turn = Verbs.AddLocaLoca( loca.Adv_13130, "Adv_13130");
        Verbs.AddLocaLoca( loca.Adv_13131, CA!.Verb_Turn.ID, "Adv_13131");
        Verbs.AddLocaLoca( loca.Adv_13132, CA!.Verb_Turn.ID, "Adv_13132");
        Verbs.AddLocaLoca( loca.Adv_13133, CA!.Verb_Turn.ID, "Adv_13133");

        CA!.Verb_Mix = Verbs.AddLocaLoca( loca.Adv_13134, "Adv_13134");
        Verbs.AddLocaLoca( loca.Adv_13135, CA!.Verb_Mix.ID, "Adv_13135");
        Verbs.AddLocaLoca( loca.Adv_13136, CA!.Verb_Mix.ID, "Adv_13136");
        Verbs.AddLocaLoca( loca.Adv_13137, CA!.Verb_Mix.ID, "Adv_13137");
        Verbs.AddLocaLoca( loca.Adv_13138, CA!.Verb_Mix.ID, "Adv_13138");
        Verbs.AddLocaLoca( loca.Adv_13139, CA!.Verb_Mix.ID, "Adv_13139");

        CA!.Verb_Pluck = Verbs.AddLocaLoca( loca.Adv_13140, "Adv_13140");
        Verbs.AddLocaLoca( loca.Adv_13141, CA!.Verb_Pluck.ID, "Adv_13141");

        CA!.Verb_Suck = Verbs.AddLocaLoca( loca.Adv_13142, "Adv_13142");
        Verbs.AddLocaLoca( loca.Adv_13143, CA!.Verb_Suck.ID, "Adv_13143");

        CA!.Verb_Sit = Verbs.AddLocaLoca( loca.Adv_13144, "Adv_13144");
        Verbs.AddLocaLoca( loca.Adv_13145, CA!.Verb_Sit.ID, "Adv_13145");
        Verbs.AddLocaLoca( loca.Adv_13146, CA!.Verb_Sit.ID, "Adv_13146");
        Verbs.AddLocaLoca( loca.Adv_13147, CA!.Verb_Sit.ID, "Adv_13147");

        CA!.Verb_Exchange = Verbs.AddLocaLoca( loca.Adv_13148, "Adv_13148");
        Verbs.AddLocaLoca( loca.Adv_13149, CA!.Verb_Exchange.ID, "Adv_13149");

        CA!.Verb_Bind = Verbs.AddLocaLoca( loca.Adv_13150, "Adv_13150");
        Verbs.AddLocaLoca( loca.Adv_13151, CA!.Verb_Bind.ID, "Adv_13151");

        CA!.Verb_Free = Verbs.AddLocaLoca( loca.Adv_13152, "Adv_13152");
        Verbs.AddLocaLoca( loca.Adv_13153, CA!.Verb_Free.ID, "Adv_13153");

        CA!.Verb_Hold = Verbs.AddLocaLoca( loca.Adv_13154, "Adv_13154");
        Verbs.AddLocaLoca( loca.Adv_13155, CA!.Verb_Hold.ID, "Adv_13155");

        CA!.Verb_Pinch = Verbs.AddLocaLoca( loca.Adv_13156, "Adv_13156");
        Verbs.AddLocaLoca( loca.Adv_13157, CA!.Verb_Pinch.ID, "Adv_13157");

        CA!.Verb_Bury = Verbs.AddLocaLoca( loca.Adv_13158, "Adv_13158");
        Verbs.AddLocaLoca( loca.Adv_13159, CA!.Verb_Bury.ID, "Adv_13159");
        Verbs.AddLocaLoca( loca.Adv_13160, CA!.Verb_Bury.ID, "Adv_13160");
        Verbs.AddLocaLoca( loca.Adv_13161, CA!.Verb_Bury.ID, "Adv_13161");
        Verbs.AddLocaLoca( loca.Adv_13162, CA!.Verb_Bury.ID, "Adv_13162");
        Verbs.AddLocaLoca( loca.Adv_13163, CA!.Verb_Bury.ID, "Adv_13163");
        Verbs.AddLocaLoca( loca.Adv_13164, CA!.Verb_Bury.ID, "Adv_13164");

        CA!.Verb_Bumse = Verbs.AddLocaLoca( loca.Adv_13165, "Adv_13165");
        Verbs.AddLocaLoca( loca.Adv_13166, CA!.Verb_Bumse.ID, "Adv_13166");
        Verbs.AddLocaLoca( loca.Adv_13167, CA!.Verb_Bumse.ID, "Adv_13167");
        Verbs.AddLocaLoca( loca.Adv_13168, CA!.Verb_Bumse.ID, "Adv_13168");
        Verbs.AddLocaLoca( loca.Adv_13169, CA!.Verb_Bumse.ID, "Adv_13169");
        Verbs.AddLocaLoca( loca.Adv_13170, CA!.Verb_Bumse.ID, "Adv_13170");

        CA!.Verb_Kitzle = Verbs.AddLocaLoca( loca.Adv_13171, "Adv_13171");
        Verbs.AddLocaLoca( loca.Adv_13172, CA!.Verb_Kitzle.ID, "Adv_13172");

        CA!.Verb_Kuschle = Verbs.AddLocaLoca( loca.Adv_13173, "Adv_13173");
        Verbs.AddLocaLoca( loca.Adv_13174, CA!.Verb_Kuschle.ID, "Adv_13174");

        CA!.Verb_Schlage = Verbs.AddLocaLoca( loca.Adv_13175, "Adv_13175");
        Verbs.AddLocaLoca( loca.Adv_13176, CA!.Verb_Schlage.ID, "Adv_13176");

        CA!.Verb_Streichle = Verbs.AddLocaLoca( loca.Adv_13177, "Adv_13177");
        Verbs.AddLocaLoca( loca.Adv_13178, CA!.Verb_Streichle.ID, "Adv_13178");

        CA!.Verb_Toete = Verbs.AddLocaLoca( loca.Adv_13179, "Adv_13179");
        Verbs.AddLocaLoca( loca.Adv_13180, CA!.Verb_Toete.ID, "Adv_13180");

        CA!.Verb_Joggle = Verbs.AddLocaLoca( loca.Adv_13181, "Adv_13181");
        Verbs.AddLocaLoca( loca.Adv_13182, CA!.Verb_Joggle.ID, "Adv_13182");

        CA!.Verb_Sleep = Verbs.AddLocaLoca( loca.Adv_13183, "Adv_13183");
        Verbs.AddLocaLoca( loca.Adv_13184, CA!.Verb_Sleep.ID, "Adv_13184");

        CA!.Verb_Spark = Verbs.AddLocaLoca( loca.Adv_13185, "Adv_13185");
        Verbs.AddLocaLoca( loca.Adv_13186, CA!.Verb_Spark.ID, "Adv_13186");
        CA!.Verb_Leave = Verbs.AddLocaLoca( loca.Adv_13187, "Adv_13187");
        Verbs.AddLocaLoca( loca.Adv_13188, CA!.Verb_Leave.ID, "Adv_13188");
        CA!.Verb_Determine = Verbs.AddLocaLoca( loca.Adv_13189, "Adv_13189");
        Verbs.AddLocaLoca( loca.Adv_13190, CA!.Verb_Determine.ID, "Adv_13190");
        CA!.Verb_Remove = Verbs.AddLocaLoca( loca.Adv_13191, "Adv_13191");
        Verbs.AddLocaLoca( loca.Adv_13192, CA!.Verb_Remove.ID, "Adv_13192");

        CA!.Verb_Clean = Verbs.AddLocaLoca( loca.Adv_13193, "Adv_13193");
        Verbs.AddLocaLoca( loca.Adv_13194, CA!.Verb_Clean.ID, "Adv_13194");
        Verbs.AddLocaLoca( loca.Adv_13195, CA!.Verb_Clean.ID, "Adv_13195");
        Verbs.AddLocaLoca( loca.Adv_13196, CA!.Verb_Clean.ID, "Adv_13196");
        Verbs.AddLocaLoca( loca.Adv_13197, CA!.Verb_Clean.ID, "Adv_13197");
        Verbs.AddLocaLoca( loca.Adv_13198, CA!.Verb_Clean.ID, "Adv_13198");
        Verbs.AddLocaLoca( loca.Adv_13199, CA!.Verb_Clean.ID, "Adv_13199");
        Verbs.AddLocaLoca( loca.Adv_13200, CA!.Verb_Clean.ID, "Adv_13200");
        Verbs.AddLocaLoca( loca.Adv_13201, CA!.Verb_Clean.ID, "Adv_13201");
        Verbs.AddLocaLoca( loca.Adv_13202, CA!.Verb_Clean.ID, "Adv_13202");

        CA!.Verb_Soil = Verbs.AddLocaLoca( loca.Verb_Soil, "Verb_Soil");
        Verbs.AddLocaLoca( loca.Verb_Soil2, CA!.Verb_Soil.ID, "Verb_Soil2");
        Verbs.AddLocaLoca( loca.Verb_Soil3, CA!.Verb_Soil.ID, "Verb_Soil3");
        Verbs.AddLocaLoca( loca.Verb_Soil4, CA!.Verb_Soil.ID, "Verb_Soil4");
        Verbs.AddLocaLoca( loca.Verb_Soil5, CA!.Verb_Soil.ID, "Verb_Soil5");
        Verbs.AddLocaLoca( loca.Verb_Soil6, CA!.Verb_Soil.ID, "Verb_Soil6");

        CA!.Verb_Wash = Verbs.AddLocaLoca( loca.Adv_13203, "Adv_13203");
        Verbs.AddLocaLoca( loca.Adv_13204, CA!.Verb_Wash.ID, "Adv_13204");

        CA!.Verb_Split = Verbs.AddLocaLoca( loca.Adv_13205, "Adv_13205");
        Verbs.AddLocaLoca( loca.Adv_13206, CA!.Verb_Split.ID, "Adv_13206");
        Verbs.AddLocaLoca( loca.Adv_13207, CA!.Verb_Split.ID, "Adv_13207");
        Verbs.AddLocaLoca( loca.Adv_13208, CA!.Verb_Split.ID, "Adv_13208");

        CA!.Verb_Fry = Verbs.AddLocaLoca( loca.Adv_13209, "Adv_13209");
        Verbs.AddLocaLoca( loca.Adv_13210, CA!.Verb_Fry.ID, "Adv_13210");

        CA!.Verb_Form = Verbs.AddLocaLoca( loca.Adv_13211, "Adv_13211");

        CA!.Verb_Wrap = Verbs.AddLocaLoca( loca.Adv_13212, "Adv_13212");
        Verbs.AddLocaLoca( loca.Adv_13213, CA!.Verb_Wrap.ID, "Adv_13213");

        CA!.Verb_Paint = Verbs.AddLocaLoca( loca.Adv_13214, "Adv_13214");
        Verbs.AddLocaLoca( loca.Adv_13215, CA!.Verb_Paint.ID, "Adv_13215");
        Verbs.AddLocaLoca( loca.Adv_13216, CA!.Verb_Paint.ID, "Adv_13216");
        Verbs.AddLocaLoca( loca.Adv_13217, CA!.Verb_Paint.ID, "Adv_13217");

        CA!.Verb_Wear = Verbs.AddLocaLoca( loca.Adv_13218, "Adv_13218");
        Verbs.AddLocaLoca( loca.Adv_13219, CA!.Verb_Wear.ID, "Adv_13219");

        CA!.Verb_Search = Verbs.AddLocaLoca( loca.Adv_13220, "Adv_13220");
        Verbs.AddLocaLoca( loca.Adv_13221, CA!.Verb_Search.ID, "Adv_13221");

        CA!.Verb_Search2 = Verbs.AddLocaLoca( loca.Adv_13222, "Adv_13222");
        Verbs.AddLocaLoca( loca.Adv_13223, CA!.Verb_Search2.ID, "Adv_13223");

        CA!.Verb_Poke = Verbs.AddLocaLoca( loca.Adv_13224, "Adv_13224");
        Verbs.AddLocaLoca( loca.Adv_13225, CA!.Verb_Poke.ID, "Adv_13225");

        CA!.Verb_Dig = Verbs.AddLocaLoca( loca.Adv_13226, "Adv_13226");
        Verbs.AddLocaLoca( loca.Adv_13227, CA!.Verb_Dig.ID, "Adv_13227");

        CA!.Verb_Wake = Verbs.AddLocaLoca( loca.Adv_13228, "Adv_13228");
        Verbs.AddLocaLoca( loca.Adv_13229, CA!.Verb_Wake.ID, "Adv_13229");

        CA!.Verb_Shout = Verbs.AddLocaLoca( loca.Adv_13230, "Adv_13230");
        Verbs.AddLocaLoca( loca.Adv_13231, CA!.Verb_Shout.ID, "Adv_13231");
        Verbs.AddLocaLoca( loca.Adv_13232, CA!.Verb_Shout.ID, "Adv_13232");
        Verbs.AddLocaLoca( loca.Adv_13233, CA!.Verb_Shout.ID, "Adv_13233");

        CA!.Verb_Leave2 = Verbs.AddLocaLoca( loca.Adv_13234, "Adv_13234");
        Verbs.AddLocaLoca( loca.Adv_13235, CA!.Verb_Leave2.ID, "Adv_13235");

        CA!.Verb_Slide = Verbs.AddLocaLoca( loca.Adv_13236, "Adv_13236");
        Verbs.AddLocaLoca( loca.Adv_13237, CA!.Verb_Slide.ID, "Adv_13237");
        Verbs.AddLocaLoca( loca.Adv_13238, CA!.Verb_Slide.ID, "Adv_13238");
        Verbs.AddLocaLoca( loca.Adv_13239, CA!.Verb_Slide.ID, "Adv_13239");

        CA!.Verb_Attack = Verbs.AddLocaLoca( loca.Adv_13240, "Adv_13240");
        Verbs.AddLocaLoca( loca.Adv_13241, CA!.Verb_Attack.ID, "Adv_13241");

        CA!.Verb_Accede = Verbs.AddLocaLoca( loca.Adv_13242, "Adv_13242");
        CA!.Verb_Be = Verbs.AddLocaLoca( loca.Adv_13243, "Adv_13243");
        Verbs.AddLocaLoca( loca.Adv_13244, CA!.Verb_Be.ID, "Adv_13244");
        Verbs.AddLocaLoca( loca.Adv_13245, CA!.Verb_Be.ID, "Adv_13245");
        Verbs.AddLocaLoca( loca.Adv_13246, CA!.Verb_Be.ID, "Adv_13246");
        Verbs.AddLocaLoca( loca.Adv_13247, CA!.Verb_Be.ID, "Adv_13247");

        CA!.Verb_Repair = Verbs.AddLocaLoca( loca.Adv_13248, "Adv_13248");
        Verbs.AddLocaLoca( loca.Adv_13249, CA!.Verb_Repair.ID, "Adv_13249");

        CA!.Verb_Sort = Verbs.AddLocaLoca( loca.Adv_13250, "Adv_13250");
        Verbs.AddLocaLoca( loca.Adv_13251, CA!.Verb_Sort.ID, "Adv_13251");

        CA!.Verb_Confess = Verbs.AddLocaLoca( loca.Adv_13252, "Adv_13252");
        Verbs.AddLocaLoca( loca.Adv_13253, CA!.Verb_Confess.ID, "Adv_13253");

        CA!.Verb_Stroke = Verbs.AddLocaLoca( loca.Adv_13254, "Adv_13254");
        Verbs.AddLocaLoca( loca.Adv_13255, CA!.Verb_Stroke.ID, "Adv_13255");

        CA!.Verb_Switch = Verbs.AddLocaLoca( loca.Adv_13256, "Adv_13256");
        Verbs.AddLocaLoca( loca.Adv_13257, CA!.Verb_Switch.ID, "Adv_13257");

        CA!.Verb_Lift = Verbs.AddLocaLoca( loca.Adv_13258, "Adv_13258");
        Verbs.AddLocaLoca( loca.Adv_13259, CA!.Verb_Lift.ID, "Adv_13259");

        CA!.Verb_Wipe = Verbs.AddLocaLoca( loca.Adv_13260, "Adv_13260");
        Verbs.AddLocaLoca( loca.Adv_13261, CA!.Verb_Wipe.ID, "Adv_13261");

        CA!.Verb_Exits = Verbs.AddLocaLoca( loca.Adv_13262, "Adv_13262");
        Verbs.AddLocaLoca( loca.Adv_13263, CA!.Verb_Exits.ID, "Adv_13263");
        Verbs.AddLocaLoca( loca.Adv_13264, CA!.Verb_Exits.ID, "Adv_13264");
        Verbs.AddLocaLoca( loca.Adv_13265, CA!.Verb_Exits.ID, "Adv_13265");
        Verbs.AddLocaLoca( loca.Adv_13266, CA!.Verb_Exits.ID, "Adv_13266");

        CA!.Verb_Steal = Verbs.AddLocaLoca( loca.Adv_13267, "Adv_13267");
        Verbs.AddLocaLoca( loca.Adv_13268, CA!.Verb_Steal.ID, "Adv_13268");

        CA!.Verb_Score = Verbs.AddLocaLoca( loca.Adv_13269, "Adv_13269");
        Verbs.AddLocaLoca( loca.Adv_13270, CA!.Verb_Score.ID, "Adv_13270");

        CA!.Verb_Move = Verbs.AddLocaLoca( loca.Adv_13271, "Adv_13271");
        Verbs.AddLocaLoca( loca.Adv_13272, CA!.Verb_Move.ID, "Adv_13272");

        CA!.Verb_Destroy = Verbs.AddLocaLoca( loca.Adv_13273, "Adv_13273");
        Verbs.AddLocaLoca( loca.Adv_13274, CA!.Verb_Destroy.ID, "Adv_13274");

        CA!.Verb_Chop = Verbs.AddLocaLoca( loca.Adv_13275, "Adv_13275");
        Verbs.AddLocaLoca( loca.Adv_13276, CA!.Verb_Chop.ID, "Adv_13276");
        Verbs.AddLocaLoca( loca.Adv_13277, CA!.Verb_Chop.ID, "Adv_13277");
        Verbs.AddLocaLoca( loca.Adv_13278, CA!.Verb_Chop.ID, "Adv_13278");
        Verbs.AddLocaLoca( loca.Adv_13279, CA!.Verb_Chop.ID, "Adv_13279");
        Verbs.AddLocaLoca( loca.Adv_13280, CA!.Verb_Chop.ID, "Adv_13280");


        CA!.Verb_Plunge = Verbs.AddLocaLoca( loca.Adv_13281, "Adv_13281");
        Verbs.AddLocaLoca( loca.Adv_13282, CA!.Verb_Plunge.ID, "Adv_13282");

        CA!.Verb_Roll = Verbs.AddLocaLoca( loca.Adv_13283, "Adv_13283");
        Verbs.AddLocaLoca( loca.Adv_13284, CA!.Verb_Roll.ID, "Adv_13284");

        CA!.Verb_Demolish = Verbs.AddLocaLoca( loca.Adv_13285, "Adv_13285");
        Verbs.AddLocaLoca( loca.Adv_13286, CA!.Verb_Demolish.ID, "Adv_13286");

        CA!.Verb_Crack = Verbs.AddLocaLoca( loca.Adv_13287, "Adv_13287");
        Verbs.AddLocaLoca( loca.Adv_13288, CA!.Verb_Crack.ID, "Adv_13288");

        CA!.Verb_Glue = Verbs.AddLocaLoca( loca.Adv_13289, "Adv_13289");
        Verbs.AddLocaLoca( loca.Adv_13290, CA!.Verb_Glue.ID, "Adv_13290");

        CA!.Verb_Heat = Verbs.AddLocaLoca( loca.Adv_13291, "Adv_13291");
        Verbs.AddLocaLoca( loca.Adv_13292, CA!.Verb_Heat.ID, "Adv_13292");

        CA!.Verb_Pulverize = Verbs.AddLocaLoca( loca.Adv_13293, "Adv_13293");
        Verbs.AddLocaLoca( loca.Adv_13294, CA!.Verb_Pulverize.ID, "Adv_13294");
        Verbs.AddLocaLoca( loca.Adv_13295, CA!.Verb_Pulverize.ID, "Adv_13295");
        Verbs.AddLocaLoca( loca.Adv_13296, CA!.Verb_Pulverize.ID, "Adv_13296");

        CA!.Verb_Tidy = Verbs.AddLocaLoca( loca.Adv_13297, "Adv_13297");
        Verbs.AddLocaLoca( loca.Adv_13298, CA!.Verb_Tidy.ID, "Adv_13298");

        CA!.Verb_Brush = Verbs.AddLocaLoca( loca.Adv_13299, "Adv_13299");
        Verbs.AddLocaLoca( loca.Adv_13300, CA!.Verb_Brush.ID, "Adv_13300");

        CA!.Verb_Type = Verbs.AddLocaLoca( loca.Adv_13301, "Adv_13301");

        CA!.Verb_Dance = Verbs.AddLocaLoca( loca.Adv_13302, "Adv_13302");
        Verbs.AddLocaLoca( loca.Adv_13303, CA!.Verb_Dance.ID, "Adv_13303");

        CA!.Verb_Swing = Verbs.AddLocaLoca( loca.Adv_13304, "Adv_13304");
        Verbs.AddLocaLoca( loca.Adv_13305, CA!.Verb_Swing.ID, "Adv_13305");

        CA!.Verb_Store = Verbs.AddLocaLoca( loca.Adv_13306, "Adv_13306");
        Verbs.AddLocaLoca( loca.Adv_13307, CA!.Verb_Store.ID, "Adv_13307");

        CA!.Verb_Sing = Verbs.AddLocaLoca( loca.Adv_13308, "Adv_13308");
        Verbs.AddLocaLoca( loca.Adv_13309, CA!.Verb_Sing.ID, "Adv_13309");

        CA!.Verb_Lick = Verbs.AddLocaLoca( loca.Adv_13310, "Adv_13310");
        Verbs.AddLocaLoca( loca.Adv_13311, CA!.Verb_Lick.ID, "Adv_13311");

        CA!.Verb_Hide = Verbs.AddLocaLoca( loca.Adv_13312, "Adv_13312");
        Verbs.AddLocaLoca( loca.Adv_13313, CA!.Verb_Hide.ID, "Adv_13313");

        CA!.Verb_Tear = Verbs.AddLocaLoca( loca.Adv_13314, "Adv_13314");
        Verbs.AddLocaLoca( loca.Adv_13315, CA!.Verb_Tear.ID, "Adv_13315");

        CA!.Verb_Rip = Verbs.AddLocaLoca( loca.Adv_13316, "Adv_13316");
        Verbs.AddLocaLoca( loca.Adv_13317, CA!.Verb_Rip.ID, "Adv_13317");

        CA!.Verb_Burn = Verbs.AddLocaLoca( loca.Adv_13318, "Adv_13318");
        Verbs.AddLocaLoca( loca.Adv_13319, CA!.Verb_Burn.ID, "Adv_13319");

        CA!.Verb_Smoke = Verbs.AddLocaLoca( loca.Adv_13320, "Adv_13320");
        Verbs.AddLocaLoca( loca.Adv_13321, CA!.Verb_Smoke.ID, "Adv_13321");

        CA!.Verb_Lay = Verbs.AddLocaLoca( loca.Adv_13322, "Adv_13322");
        Verbs.AddLocaLoca( loca.Adv_13323, CA!.Verb_Lay.ID, "Adv_13323");

        CA!.Verb_Crumble = Verbs.AddLocaLoca( loca.Adv_13324, "Adv_13324");
        Verbs.AddLocaLoca( loca.Adv_13325, CA!.Verb_Crumble.ID, "Adv_13325");
        Verbs.AddLocaLoca( loca.Adv_13326, CA!.Verb_Crumble.ID, "Adv_13326");

        CA!.Verb_Let = Verbs.AddLocaLoca( loca.Adv_13327, "Adv_13327");
        Verbs.AddLocaLoca( loca.Adv_13328, CA!.Verb_Let.ID, "Adv_13328");

        CA!.Verb_Kiss = Verbs.AddLocaLoca( loca.Adv_13329, "Adv_13329");
        Verbs.AddLocaLoca( loca.Adv_13330, CA!.Verb_Kiss.ID, "Adv_13330");

        CA!.Verb_Pray = Verbs.AddLocaLoca( loca.Adv_13331, "Adv_13331");
        Verbs.AddLocaLoca( loca.Adv_13332, CA!.Verb_Pray.ID, "Adv_13332");

        CA!.Verb_Bend = Verbs.AddLocaLoca( loca.Adv_13333, "Adv_13333");
        Verbs.AddLocaLoca( loca.Adv_13334, CA!.Verb_Bend.ID, "Adv_13334");

        CA!.Verb_Leverage = Verbs.AddLocaLoca( loca.Adv_13335, "Adv_13335");


        CA!.Verb_Count = Verbs.AddLocaLoca( loca.Adv_13336, "Adv_13336");
        Verbs.AddLocaLoca( loca.Adv_13337, CA!.Verb_Count.ID, "Adv_13337");

        CA!.Verb_Scroll = Verbs.AddLocaLoca( loca.Adv_13338, "Adv_13338");

        CA!.Verb_Credits = Verbs.AddLocaLoca( loca.Adv_13339, "Adv_13339");
        Verbs.AddLocaLoca( loca.Adv_13340, CA!.Verb_Credits.ID, "Adv_13340");

        CA!.Verb_Make = Verbs.AddLocaLoca( loca.Adv_13341, "Adv_13341");
        Verbs.AddLocaLoca( loca.Adv_13342, CA!.Verb_Make.ID, "Adv_13342");

        CA!.Verb_Breath = Verbs.AddLocaLoca( loca.Adv_13343, "Adv_13343");

        CA!.Verb_Spray = Verbs.AddLocaLoca( loca.Adv_13344, "Adv_13344");
        Verbs.AddLocaLoca( loca.Adv_13345, CA!.Verb_Spray.ID, "Adv_13345");

        CA!.Verb_Illustration = Verbs.AddLocaLoca( loca.Adv_13346, "Adv_13346");
        Verbs.AddLocaLoca( loca.Adv_13347, CA!.Verb_Illustration.ID, "Adv_13347");

        CA!.Verb_Unlock = Verbs.AddLocaLoca( loca.Adv_Unlock, "Adv_Unlock");

        CA!.Verb_Lock = Verbs.AddLocaLoca( loca.Adv_Lock, "Adv_Lock");

        CA!.Verb_Abandon = Verbs.AddLocaLoca( loca.Adv_Abandon, "Adv_Abandon");

        CA!.Verb_Untie = Verbs.AddLocaLoca( loca.Adv_Untie, "Adv_Untie");

        Verbs!.TList = new Dictionary<string, Verb>(Verbs.GetVerbBuffer()!, StringComparer.CurrentCultureIgnoreCase );
    }
}
