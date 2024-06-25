using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Phoney_MAUI.Model;
using Phoney_MAUI.Core;

namespace GameCore;

public static partial class loca
{
    // static IGlobalData? _gd = null;
    [JsonIgnore]
    public static GlobalData? GD
    {
        get => GlobalData.CurrentGlobalData;
        set => GlobalData.CurrentGlobalData = value;
    }
    [JsonIgnore]
    public static GlobalData? _gd
    {
        get => GlobalData.CurrentGlobalData;
        set => GlobalData.CurrentGlobalData = value;
    }
    /*
    public static IGlobalData? GD
    {
        get { return _gd; }
        set { _gd = value; }
    }
    */

    public static void Setloca(IGlobalData GD)
    {
        // _gd = GD;
    }
    /*
    public static string? TextOrLoca(string? _text, string? locaString)
    {
        if (locaString != null)
        {
            if (!string.IsNullOrEmpty(locaString))
            {
                Type t = typeof(loca);

                PropertyInfo? pi = t.GetProperty(locaString);

                // var prop = loca.GetType().GetProperty(Loca);
                var s = pi?.GetValue(null) as string;

                return s;
            }
            else
                return _text;
        }
        else
            return _text;
    }
    */
    public static string? TextOrLoca(string? _text, string? locaString, string? locaStringHandle = null)
    {
        if (locaStringHandle != null)
        {
            return locaStringHandle;
        }
        else if (locaString != null)
        {
            if (!string.IsNullOrEmpty(locaString))
            {
                Type t = typeof(loca);

                PropertyInfo? pi = t.GetProperty(locaString)!;

                // var prop = loca.GetType().GetProperty(Loca);
                string? s = null;

                if (pi?.GetValue(null) != null)
                    s = Helper.Insert(pi?.GetValue(null) as string);
                else
                {
                    // int a = 5;
                }


                return s;
            }
            else
                return _text;
        }
        else
            return _text;
    }
    public static string? GetLoca(string key)
    {
        if (!string.IsNullOrEmpty(key))
        {
            Type t = typeof(loca);

            PropertyInfo? pi = t.GetProperty(key);

            // var prop = loca.GetType().GetProperty(Loca);
            return (pi!.GetValue(null)!.ToString());

        }
        else
            return null;

    }
    public static string Order_GoTargetlocation_10306
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wusste nicht, wie ich dorthin kommen sollte.";
            else
                return "I didn't know how to get there.";
        }
    }
    public static string Verb_putze
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "putze";
            else
                return "____clean";
        }

    }
    public static string Verb_zerstosse
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "zerstoße";
            else
                return "crush";
        }

    }
    public static string Verb_zerstoss
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "zerstoß";
            else
                return "_crush";
        }

    }
    public static string Verb_zerdruecke
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "zerdrücke";
            else
                return "squash";
        }

    }
    public static string Verb_zerdrueck
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "zerdrück";
            else
                return "_squash";
        }

    }
    public static string Info_Start
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand mitten im Wald. Wo befand sich bloß das Versteck des Meisters? Hier irgendwo in der Nähe musste doch seine Hütte sein!";
            else
                return "I was standing in the middle of the forest. Where was the master's hiding place? His hut had to be around here somewhere!";
        }

    }
    public static string Info_Suche_Versteck
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Die Hütte des Meisters hatte ich gefunden. Aber das war ganz sicher nicht sein Versteck, zumindest sah sie aus wie eine baufällige Bruchbude. Irgendwo hier musste doch ein verborgener Eingang liegen!";
            else
                return "(Tips!) I had found the master's hut. But it certainly wasn't his hiding place, at least it looked like a dilapidated hovel. There had to be a hidden entrance here somewhere!";
        }

    }
    public static string Info_Suche_Versteck_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie konnte ich das geheime Domizil des Meisters finden?";
            else
                return "How did I find the master's secret residence?";
        }

    }
    public static string Info_Suche_Versteck_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Ich war mir sicher: Ohne magische Hlfe würde es nicht gehen!";
            else
                return "(Tip) I was sure that it wouldn't work without magical help!";
        }

    }
    public static string Info_Suche_Versteck_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Manche Leute legten sich ihren Ersatzschlüssel unter die Fußmatte. Und wer weiß, was sich alles in der schäbigen Kammmer finden ließ.";
            else
                return "(Help) Some people put their spare keys under the doormat. And who knows what could be found in the shabby chambers.";
        }

    }
    public static string Info_Suche_Versteck_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Unter der Fußmatte vor der Hütte lag ein Beutelchen mit magischem Pulver. Hinter dem Schrank in der schäbigen Kammer befand sich eine Klappe, und in der Öffnung dahinter eine magische Kerze. Aufs Pentagramm stellen in der Stube, Pulver drauf streuen - und schon ging die Reise los.";
            else
                return "(Solution) Under the doormat in front of the hut was a small bag of magic powder. There was a flap behind the cupboard in the shabby room and a magic candle in the opening behind it. Place it on the pentagram in the living room, sprinkle the powder on it - and the journey begins.";
        }

    }
    public static string Info_Pentagramm
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Ein Pentagramm mitten in der Stube der Hütte. Das hatte doch gewiss etwas zu bedeuten. Aber was?";
            else
                return "(Tips!) A pentagram in the middle of the living room of the hut. Surely that meant something. But what?";
        }

    }
    public static string Info_Pentagramm_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was hatte es mit dem Pentagramm auf sich?";
            else
                return "What was the pentagram all about?";
        }

    }
    public static string Info_Pentagramm_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Meister Gunnar liebte Pentagramme. Wo sie waren, war Magie nicht weit. Und nutze Meiser Gunnar seine Pentgramme nicht gerne für Teleportzauber?";
            else
                return "(Tip) Master Gunnar loved pentagrams. Wherever they were, magic wasn't far away. And didn't Master Gunnar like to use his pentagrams for teleport spells?";
        }

    }
    public static string Info_Pentagramm_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Meister Gunnar hatte das Pentagamm hier sicher nicht zum Spaß hingemalt. Vermutlich lagen hier irgendwo Zauberzutaten. Ich sollte alles in und vor der Hütte gründllich absuchen.";
            else
                return "(Help) Master Gunnar certainly didn't paint the pentagam here for fun. There were probably magic ingredients here somewhere. I should search everything inside and outside the hut thoroughly.";
        }

    }
    public static string Info_Pentagramm_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Unter der Fußmatte vor der Hütte lag ein Beutelchen mit magischem Pulver. Hinter dem Schrank in der schäbigen Kammer befand sich eine Klappe, und in der Öffnung dahinter eine magische Kerze. Aufs Pentagramm stellen in der Stube, Pulver drauf streuen - und schon ging die Reise los.";
            else
                return "(Solution) Under the doormat in front of the hut was a small bag of magic powder. There was a flap behind the cupboard in the shabby room and a magic candle in the opening behind it. Place it on the pentagram in the living room, sprinkle the powder on it - and the journey begins.";
        }

    }
    public static string Info_Atrium_Ankunft
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich war im Versteck des Meisters angekommen. Jetzt noch schnell die Klaue an mich nehmen und nichts wie raus hier!";
            else
                return "I had arrived at the master's hideout. Now let's quickly grab the claw and get out of here!";
        }

    }
    public static string Info_Klaue_nicht_nehmbar
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Ich hatte die Klaue gefunden. Leider schien es viel zu gefährlich zu sein, sie einfach zu nehmen.";
            else
                return "(Tips!) I had found the claw. Unfortunately, it seemed far too dangerous to just take it.";
        }

    }
    public static string Info_Klaue_nicht_nehmbar_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie konnte ich die Klaue an mich nehmen?";
            else
                return "How could I take the claw?";
        }

    }
    public static string Info_Klaue_nicht_nehmbar_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Wenn ich sie nicht direkt nehmen konnte, dann gab es vielleicht einen Gegenstand, der mir beim Nehmen helfen könnte.";
            else
                return "(Tip) If I couldn't take it directly, then maybe there was an object that could help me take it.";
        }

    }
    public static string Info_Klaue_nicht_nehmbar_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) In der Küchenschublade fand sich ein nützlicher Gegenstand, um die Klaue damit aufzunehmen. Leider war das Ganze aber nicht perfekt.";
            else
                return "(Help) A useful object was found in the kitchen drawer to pick up the claw. Unfortunately, it wasn't perfect.";
        }

    }
    public static string Info_Klaue_nicht_nehmbar_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) In der Küchenschublade fand ich eine Zuckerzange. Die konnte ich mit der Klaue benutzen, um sie hochzunehmen. Fehlte noch eine Fixierung für das ganze Gebilde.";
            else
                return "(Solution) I found a pair of sugar tongs in the kitchen drawer. I was able to use the claw to pick it up. I still needed a fixation for the whole thing.";
        }

    }
    public static string Info_Klaue_nicht_fixiert
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hatte die Klaue gefunden und mit der Zuckerzange an mich genommen. Leider war das Gebilde alles anderes als stabil.";
            else
                return "I found the claw and took it with the sugar tongs. Unfortunately, the structure was anything but stable.";
        }

    }
    public static string Info_Klaue_nicht_fixiert_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie konnte ich die Klaue in der Zuckerzange fixieren?";
            else
                return "How could I fix the claw in the sugar tongs?";
        }

    }
    public static string Info_Klaue_nicht_fixiert_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Ich brauchte ja eigentlich nur etwas, das die Zuckerzange zusammendrücke.";
            else
                return "(Tips!) All I really needed was something to compress the sugar tongs.";
        }

    }
    public static string Info_Klaue_nicht_fixiert_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Ich brauchte irgendein Klebeband, zur Not tat es Pflaster. Sollte Meister Gunnar nicht irgendwo in seinem Labor einen Erste-Hilfe-Kasten haben?";
            else
                return "(Help) I needed some adhesive tape, if necessary I could use plaster. Shouldn't Master Gunnar have a first aid kit somewhere in his lab?";
        }

    }
    public static string Info_Klaue_nicht_fixiert_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Im Labor gab es einen Erste-Hilfe-Kasten. Dort konnte ich Rollpflaster finden. Das ließ sich dann um den Griff der Zange wickeln und so zusammendrücken. Fertig war der perfekte Klauenhalter.";
            else
                return "(Solution) There was a first aid box in the laboratory. I was able to find a roll of plaster there. This could then be wrapped around the handle of the pliers and pressed together. The perfect claw holder was ready.";
        }

    }
    public static string Info_Klaue_noch_niemand_belebt
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Ich hatte nun diese schicke Klauenzange. Aber was sollte ich damit machen?";
            else
                return "(Tips!) I now had these fancy claw pliers. But what should I do with it?";
        }

    }
    public static string Info_Klaue_noch_niemand_belebt_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was tun mit der Klaue?";
            else
                return "What to do with the claw?";
        }

    }
    public static string Info_Klaue_noch_niemand_belebt_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Naja, sie soll ja Lebensenergie übertragen. Wem könnte das gut tun?";
            else
                return "(Tip) Well, it's supposed to transfer life energy. Who could benefit from that?";
        }

    }
    public static string Info_Klaue_noch_niemand_belebt_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Ob die ausgestopfte Eule oder andere Exlebewesen wohl positiv darauf reagieren, mit der Klaue berührt zu werden?";
            else
                return "(Help) I wonder if the stuffed owl or other ex-living creatures react positively to being touched with a claw?";
        }

    }
    public static string Info_Klaue_noch_niemand_belebt_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Mit der Klaue ließen sich nicht nur alle ausgestopften Viecher wiederbeleben, sondern auch die Ritterrüstung auf dem Flur.";
            else
                return "(Solution) The claw could be used to revive not only all the stuffed animals, but also the knight's armor in the hallway.";
        }

    }
    public static string Info_Klaue_noch_niemand_gesprochen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Ich hatte nun diese schicke Klauenzange und damit auch schon etwas belebt. Aber was sollte ich jetzt damit machen?";
            else
                return "(Tips!) I now had these fancy claw pliers and had already revitalized them a bit. But what should I do with it now?";
        }

    }
    public static string Info_Klaue_noch_niemand_gesprochen_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was tun mit der schicken stabilen Klauenzange?";
            else
                return "What to do with the stylish, sturdy claw pliers?";
        }

    }
    public static string Info_Klaue_noch_niemand_gesprochen_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Tja, was hatte man davon, etwas zu beleben?";
            else
                return "(Tip) Well, what was the point of reviving something?";
        }

    }
    public static string Info_Klaue_noch_niemand_gesprochen_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Jemand, der wiederbelebt war, hatte vielleicht Lust, sich mit mir zu unterhalten?";
            else
                return "(Help) Someone who was revived might have wanted to talk to me?";
        }

    }
    public static string Info_Klaue_noch_niemand_gesprochen_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Ich konnte alle ausgestopften Viecher und die Ritterrüstung wiederbeleben und anschließend Gespräche mit ihnen führen.";
            else
                return "(Solution) I was able to revive all the stuffed animals and the knight's armor and then have conversations with them.";
        }

    }
    public static string Info_Uhu_Fragen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Eule hatte Fragen an mich, die ich beantworten musste, um in die Bibliothek zu gelangen.";
            else
                return "The owl had questions for me that I had to answer in order to get into the library.";
        }

    }
    public static string Info_Uhu_Fragen_Unterwaesche
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Die erste Frage der Eule bezog sich auf die Unterwäsche-Marke des Meisters.";
            else
                return "(Tips!) The owl's first question was about the master's brand of underwear.";
        }

    }
    public static string Info_Uhu_Fragen_Unterwaesche_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie fand ich heraus, welche Unterwäschemarke der Meister trug?";
            else
                return "How did I find out what brand of underwear the master wore?";
        }

    }
    public static string Info_Uhu_Fragen_Unterwaesche_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Einfach mal nachschauen, was ich für Wäsche fand, konnte keine schlechte Idee sein.";
            else
                return "(Tip) Just having a look at what I found for laundry couldn't have been a bad idea.";
        }

    }
    public static string Info_Uhu_Fragen_Unterwaesche_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) In der Waschküche fand sich sicherlich auch Unterwäsche des Meisters. Ich musste sie mir nur genau anschauen.";
            else
                return "(Help) I was sure to find the master's underwear in the laundry room. I just had to take a close look at them.";
        }

    }
    public static string Info_Uhu_Fragen_Unterwaesche_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) In der Waschmaschine in der Waschküche fand sich eine Unterhose, auf der die Marke stand. Das musste ich mir einfach nur anschauen.";
            else
                return "(Solution) In the washing machine in the laundry room, I found a pair of underpants with the brand written on them. I just had to have a look.";
        }

    }
    public static string Info_Uhu_Fragen_Ruestung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Die zweite Frage der Eule bezog sich auf den früheren Besitzer der Ritterrüstung.";
            else
                return "(Tips!) The owl's second question referred to the former owner of the knight's armor.";
        }

    }
    public static string Info_Uhu_Fragen_Ruestung_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie fand ich heraus, wem die Ritterüstung früher gehört hatte?";
            else
                return "How did I find out who had owned the knight's armor in the past?";
        }

    }
    public static string Info_Uhu_Fragen_Ruestung_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Vielleicht war der Name ja eingraviert und musste nur freigelegt werden?";
            else
                return "(Hint) Maybe the name was engraved and just needed to be uncovered?";
        }

    }
    public static string Info_Uhu_Fragen_Ruestung_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Mit einem Polierlappen ließ sich die Rüstung sicherlich gut reinigen. So etwas konnte sich in der Küche finden.";
            else
                return "(Help) The armor could certainly be cleaned well with a polishing cloth. Something like this could be found in the kitchen.";
        }

    }
    public static string Info_Uhu_Fragen_Ruestung_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Im Küchenschrank in der Küche befand sich ein Polierlappen. Damit konnte ich die Rüstung reinigen, aber die entdeckte Schrift war zu klein. Im Labor des Meisters fand sich eine Lupe in der Schublade, damit konnte ich die Schrift entziffern.";
            else
                return "(Help) There was a polishing cloth in the kitchen cupboard in the kitchen. I used it to clean the armor, but the writing I found was too small. I found a magnifying glass in the drawer of the master's laboratory and was able to decipher the writing.";
        }

    }
    public static string Info_Uhu_Fragen_Tier
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps) Die dritte Frage der Eule bezog sich auf das Lieblingstier des Meisters.";
            else
                return "(Tips) The owl's third question was about the master's favorite animal.";
        }

    }
    public static string Info_Uhu_Fragen_Tier_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie fand ich heraus, was das Lieblingstier des Meisters war?";
            else
                return "How did I find out what the master's favorite animal was?";
        }

    }
    public static string Info_Uhu_Fragen_Tier_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Vielleicht fand sich das besagte Lieblingstier ja irgendwo? Hatte der Meister vielleicht in seinem allerprivatesten Refugium solche Hinweise hinterlassen?";
            else
                return "(Tips!) Perhaps the favorite animal in question could be found somewhere? Had the master perhaps left such clues in his most private retreat?";
        }

    }
    public static string Info_Uhu_Fragen_Tier_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Ich musste ins Schlafgemach des Meisters. Dass die Tür versiegelt war, war vermutlich für eine zerstörungswütige Ritterrüstung kein so großes Hindernis.";
            else
                return "(Help) I had to get into the master's bedchamber. The fact that the door was sealed was probably not such a big obstacle for a destructive knight's armor.";
        }

    }
    public static string Info_Uhu_Fragen_Tier_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Ich musste ins Schlafgemach des Meisters. Um die Tür aufzubekommen, sollte ich mir Schild und Siegel darauf genau anschauen. Dann redete ich am Besten mit der wiederbelebten Ritterrüstung und sagte ihr, sie solle die Tür einrennen. Im Schlafzimmer fand ich dann unter der Matratze Liebeslyrik der verstörenden Art.";
            else
                return "(Solution) I had to get into the master's bedchamber. To get the door open, I should take a close look at the shield and sigil on it. Then I talked to the revived knight's armor and told her to break down the door. In the bedroom, I found some disturbing love poetry under the mattress.";
        }

    }
    public static string Info_Neues_Rezept_Wie
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wusste nun, wie man das magische Pulver für den Teleport herstellte. War das mein Ticket aus dem Versteck heraus?";
            else
                return "I now knew how to make the magic powder for the teleport. Was this my ticket out of hiding?";
        }

    }
    public static string Info_Kaese_Not_Found
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Ich hatte nicht die geringste Ahnung, wo ich hier hier einen Mondstein auftreiben sollte.";
            else
                return "(Tips!) I didn't have the slightest idea where I was supposed to find a moonstone here.";
        }

    }
    public static string Info_Kaese_Not_Found_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie kam ich an einen Mondstein?";
            else
                return "How did I get a moonstone?";
        }

    }
    public static string Info_Kaese_Not_Found_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Nun, nicht alles, was ein Mondstein war, hatte auch als solches angefangen. Manchmal begann alles mit hart gewordenen Lebensmitteln.";
            else
                return "(Tip) Well, not everything that was a moonstone had started out as one. Sometimes it all started with food that had become hard.";
        }

    }
    public static string Info_Kaese_Not_Found_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Im Kühlschrank fand ich alten, harten Käse. Vielleicht half mir der. ";
            else
                return "(Help) I found old, hard cheese in the fridge. Maybe that helped me.";
        }

    }
    public static string Info_Kaese_Not_Found_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Im Kühlschrank fand ich alten, harten Käse. Vielleicht konnte ich den später gegen etwas eintauschen.";
            else
                return "(Help) I found old, hard cheese in the fridge. Maybe I could swap it for something later.";
        }

    }
    public static string Info_Kaese_Wozu
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Was sollte ich bloß mit einem vertrockneten Stück Käse anfangen?";
            else
                return "(Tips!) What should I do with a dried-up piece of cheese?";
        }

    }
    public static string Info_Kaese_Wozu_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was sollte ich bloß mit einem vertrockneten Stück Käse anfangen?";
            else
                return "What was I supposed to do with a dried-up piece of cheese?";
        }

    }
    public static string Info_Kaese_Wozu_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Vielleicht konnte ich das Ding irgendwo eintauschen? Wer tauschte überhaupt im Domizil?";
            else
                return "(Hint) Maybe I could trade the thing somewhere? Who traded in the domicile anyway?";
        }

    }
    public static string Info_Kaese_Wozu_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Vielleicht konnte ich das Ding bei der Elster eintauschen?";
            else
                return "(Hint) Maybe I could trade the thing somewhere? Who traded in the domicile anyway?";
        }

    }
    public static string Info_Kaese_Wozu_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Vielleicht konnte ich das Ding bei der Elster eintauschen? Auch wenn das Ergebnis des Tauschgeschäfts vielleicht nur ein Zwischenschritt war.";
            else
                return "(Solution) Maybe I could trade the thing in at the Elster? Even if the result of the swap was perhaps only an intermediate step.";
        }

    }
    public static string Info_Kiesel_Wozu
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Was sollte ich bloß mit einem dämlichen Kiesel anfangen? Da konnte die Elster auch noch so stolz auf ihren depperten Schatz sein...";
            else
                return "(Tips!) What was I supposed to do with a stupid pebble? The magpie could be so proud of its stupid treasure...";
        }

    }
    public static string Info_Kiesel_Wozu_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was sollte ich mit dem Kiesel anfangen?";
            else
                return "What should I do with the pebble?";
        }

    }
    public static string Info_Kiesel_Wozu_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Das Buch des Meisters in der Bibliothek enthielt einige Tipps dazu.";
            else
                return "(Tip) The master's book in the library contained some tips on this.";
        }

    }
    public static string Info_Kiesel_Wozu_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Die Dunkelheitsmaschine im Labor konnte dem Kiesel zumindest mal alles Licht entziehen. Das wäre doch schon mal ein ordentlicher Fortschritt.";
            else
                return "(Help) The darkness machine in the laboratory was at least able to remove all light from the pebble. That would be quite a bit of progress.";
        }

    }
    public static string Info_Kiesel_Wozu_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Ich legte den Kiesel in die Dunkelheitsmaschine, betätigte den Schalter, und bekam einen vollkommen lichtlosen Stein. Der ideale Grundstoff für den nächsten Schritt: Den Mondstein!";
            else
                return "(Solution) I put the pebble in the darkness machine, pressed the switch and got a completely lightless stone. The ideal raw material for the next step: the moonstone!";
        }

    }
    public static string Info_Lichtloser_Stein_Wozu
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Was sollte ich bloß mit diesem komischen lichtlosen Kiesel anfangen?";
            else
                return "(Tips!) What should I do with this strange lightless pebble?";
        }

    }
    public static string Info_Lichtloser_Stein_Wozu_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was konnte ich mit dem lichtlosen Kiesel anfangen?";
            else
                return "What could I do with the lightless pebble?";
        }

    }
    public static string Info_Lichtloser_Stein_Wozu_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Ein lichtloser Stein war geradezu dafür gemacht, um sich mit Mondlicht vollzusaugen. Dazu musste man nur dem Mond so nahe wie möglich kommen.";
            else
                return "(Tip) A lightless stone was virtually made to soak up moonlight. All you had to do was get as close to the moon as possible.";
        }

    }
    public static string Info_Lichtloser_Stein_Wozu_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Der lichtlose Stein würde sich mit Mondlicht vollsaugen, wenn er dem Mond nahe genug kam. Nun brauchte es nur noch eine Möglichkeit, vom Atrium aus zum Vollmond zu fliegen.";
            else
                return "(Help) The lightless stone would soak up moonlight when it got close enough to the moon. Now all that was needed was a way to fly from the atrium to the full moon.";
        }

    }
    public static string Info_Lichtloser_Stein_Wozu_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Der lichtlose Stein würde sich mit Mondlicht vollsaugen, wenn er dem Mond nahe genug kam. Das konnte der Papagei übernehmen, wenn ich ihm gut zuredete und anschließend in den Himmel warf.";
            else
                return "(Help) The lightless stone would soak up moonlight when it got close enough to the moon. Now all that was needed was a way to fly from the atrium to the full moon.";
        }

    }
    public static string Info_Goldmuenze_Woher
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Ich brauchte eine Goldmünze. Wo fand ich hier sowas?";
            else
                return "(Tips!) I needed a gold coin. Where could I find one here?";
        }

    }
    public static string Info_Goldmuenze_Woher_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie kam ich hier an eine Goldmünze?";
            else
                return "How did I get a gold coin here?";
        }

    }
    public static string Info_Goldmuenze_Woher_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Meistens fand sich ja in Brunnen allerlei Kleingeld, das unbedachte Passanten hinein warfen.";
            else
                return "(Tip) Most of the time, all kinds of small change were found in fountains, thrown in by careless passers-by.";
        }

    }
    public static string Info_Goldmuenze_Woher_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) In der Waschküche stand ein Brunnen, dessen Deckel ich wegschieben konnte. Jetzt musste ich nur noch im dunklen Wasser etwas entdecken.";
            else
                return "(Help) There was a well in the laundry room, the lid of which I was able to push away. Now I just had to discover something in the dark water.";
        }

    }
    public static string Info_Goldmuenze_Woher_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) In der Waschküche stand ein Brunnen, dessen Deckel ich wegschieben konnte. Wenn ich mit der Kerze ins Wasser leuchtete, würde ich die Münze entdecken.";
            else
                return "(Solution) There was a well in the laundry room, the lid of which I could push away. If I shone the candle into the water, I would discover the coin.";
        }

    }
    public static string Info_Goldmuenze_Woher2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Ich hatte eine goldene Münze unten im Brunnen entdeckt. Wie kam ich dort heran?";
            else
                return "(Tips!) I had discovered a golden coin at the bottom of the well. How did I get there?";
        }

    }
    public static string Info_Goldmuenze_Woher2_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie kam ich an die Goldmünze im Brunnen?";
            else
                return "How did I get the gold coin in the fountain?";
        }

    }
    public static string Info_Goldmuenze_Woher2_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Selbst konnte ich da sicher nicht runtertauchen. Das war viel zu gefährlich.";
            else
                return "(Tip) I certainly couldn't dive down there myself. It was far too dangerous.";
        }

    }
    public static string Info_Goldmuenze_Woher2_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Vielleicht konnte ich den ausgestopften Fisch überreden, in den Brunnen zu tauchen?";
            else
                return "(Help) Maybe I could persuade the stuffed fish to dive into the well?";
        }

    }
    public static string Info_Goldmuenze_Woher2_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Ich sollte den Fisch bitten, nach der Münze zu tauchen. Wenn er erst eingewilligt hatte, brauchte ich ihn nur ins Wasser zu werfen.";
            else
                return "(Solution) I should ask the fish to dive for the coin. Once it had agreed, all I had to do was throw it into the water.";
        }

    }
    public static string Info_Schwamm_Woher
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Wie sollte ich bloß einen Wunderwarzenschwamm auftreiben? Und was war das eigentlich für ein bescheuerter Name?";
            else
                return "(Tips!) How was I supposed to find a wonder wart sponge? And what kind of stupid name was that anyway?";
        }

    }
    public static string Info_Schwamm_Woher_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie sollte ich einen Wunderwarzenschwamm auftreiben?";
            else
                return "How should I find a wonder wart sponge?";
        }

    }
    public static string Info_Schwamm_Woher_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Wenn hier sowas nicht wuchs, dann konnte ich es vielleicht züchten?";
            else
                return "(Hint) If something like that didn't grow here, then maybe I could breed it?";
        }

    }
    public static string Info_Schwamm_Woher_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Wenn hier sowas nicht wuchs, dann konnte ich es vielleicht züchten. Ich brauchte die passenden Sporen und einen feuchten Untergrund.";
            else
                return "(Help) If something like that didn't grow here, then perhaps I could grow it. I needed the right spores and a moist substrate.";
        }

    }
    public static string Info_Schwamm_Woher_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Im Gefrierfach fand ich die Sporen. In der Waschküche konnte ich die Wäsche aus der Waschmaschine nehmen und in den Wäschekorb legen. Wenn ich die Sporen auf die nasse Wäsche legte, würde in Nullkommanichts ein Wunderwarzenschwamm gedeihen.";
            else
                return "(Solution) I found the spores in the freezer compartment. In the laundry room, I was able to take the laundry out of the washing machine and put it in the laundry basket. If I put the spores on the wet laundry, a miracle wart sponge would grow in no time at all.";
        }

    }
    public static string Info_Alle_Zutaten_da
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Ich hatte alle Zutaten für das magische Pulver. Und jetzt?";
            else
                return "(Tips!) I had all the ingredients for the magic powder. And now?";
        }

    }
    public static string Info_Alle_Zutaten_da_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie konnte ich das magische Pulver herstellen?";
            else
                return "How could I make the magic powder?";
        }

    }
    public static string Info_Alle_Zutaten_da_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Im Labor befand sich eine Metallschale, die ich an einer Halterung befestigen konnte. Kein schlechter Start.";
            else
                return "(Tip) There was a metal bowl in the lab that I could attach to a holder. Not a bad start.";
        }

    }
    public static string Info_Alle_Zutaten_da_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Im Labor befand sich eine Metallschale, die ich an einer Halterung befestigen konnte. Dann legte ich alle Zutaten hinein. Und jetzt brauchte die Sache nur noch etwas Feuer!";
            else
                return "(Help) There was a metal bowl in the lab that I could attach to a holder. Then I put all the ingredients in it. And now it just needed some fire!";
        }

    }
    public static string Info_Alle_Zutaten_da_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Im Labor befand sich eine Metallschale, die ich an einer Halterung befestigte. Dann legte ich alle Zutaten hinein und erhitzte das ganze mit der magischen Kerze!";
            else
                return "(Solution) There was a metal bowl in the laboratory, which I attached to a holder. Then I put all the ingredients in it and heated the whole thing with the magic candle!";
        }

    }
    public static string Info_Schlacke_Wozu
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Ich hatte einen netten Klumpen Schlacke erzeugt. Was machte ich jetzt damit?";
            else
                return "(Tips!) I had created a nice lump of slag. What did I do with it now?";
        }

    }
    public static string Info_Schlacke_Wozu_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was konnte ich jetzt mit der Schlacke tun?";
            else
                return "What could I do with the slag now?";
        }

    }
    public static string Info_Schlacke_Wozu_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Praktischerweise fand sich alles Handwerkszeug zur Weiterverarbeitung im Labor.";
            else
                return "(Tip) Conveniently, all the tools for further processing were in the laboratory.";
        }

    }
    public static string Info_Schlacke_Wozu_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Im Labor fanden sich Mörser und Stößel, um den Klumpen klein zu stößeln.";
            else
                return "(Help) A mortar and pestle were found in the laboratory to crush the lump.";
        }

    }
    public static string Info_Schlacke_Wozu_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Ich legte die Schlacke in den Mörser und bearbeitete sie mit dem Stößel. Das Ergebnis war das magische Pulver, das ich so dringend benötigte.";
            else
                return "(solution) I put the slag in the mortar and worked it with the pestle. The result was the magic powder I so desperately needed.";
        }

    }
    public static string Info_Neues_Pulver_Wozu
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hatte magisches Pulver hergestellt. Meister Gunnar wäre stolz auf mich. Also solange er nicht mitbekam, was ich sonst noch so ausgefressen hatte. Jetzt musste ich hier allerdings noch den Abflug machen.";
            else
                return "I had made magic powder. Master Gunnar would be proud of me. As long as he didn't find out what else I'd been up to. But now I still had to leave here.";
        }

    }
    public static string Info_Ende
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich war hier am Ende. Es gab nichts mehr zu tun. ";
            else
                return "I was at the end here. There was nothing more to do. ";
        }

    }
    public static string Order_Switch_English_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Spiel würde jetzt gerne auf Englisch wechseln, aber die englischen Texte sind noch gar nicht fertig. Kommt irgendwann noch!";
            else
                return "The game would like to switch to English now, but the English texts are not ready yet. Will come at some point!";
        }

    }
    public static string KnockOn_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich klopfte an [S1]. Nichts weiter geschah.";
            else
                return "I knocked on [S1]. Nothing else happened.";
        }
    }
    public static string KnockOn_Armor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich klopfte an [P:Person_Knights_Armor]die Ritterrüstung[/P]. Es schepperte, ansonsten geschah wenig.";
            else
                return "I knocked on [P:Person_Knights_Armor]the knight's armor[/P]. It rattled, but little else happened.";
        }
    }
    public static string Order_Score_891
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines hoffnungslosen Kleinkriminellen...";
            else
                return "... of a hopeless petty criminal...";
        }
    }
    public static string Order_Score_892
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines schwächlichen Strauchdiebs...";
            else
                return "... of a feeble shrub thief...";
        }
    }
    public static string Order_Score_893
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines hoffnungsvollen Straßenräubers...";
            else
                return "... of a promising highwayman...";
        }
    }
    public static string Order_Score_894
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines ambitionierten Verbrechers...";
            else
                return "... of an ambitious criminal...";
        }
    }
    public static string Order_Score_895
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines fortgeschrittenen Diebeskünstlers...";
            else
                return "... of an advanced thief artist...";
        }
    }
    public static string Order_Score_896
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines Masterminds des unfreiwilligen Eigentumstransfers...";
            else
                return "... a mastermind of the involuntary transfer of ownership...";
        }
    }
    public static string Order_Score_897
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines wahren Meisterdiebs...";
            else
                return "... of a true master thief...";
        }
    }

    public static string Give_Magpie_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wozu sollte ich [P:Person_Magpie]der Elster[/P] meinen [I:I00_Cheese]schönen Käse[/I] anbieten? Vielleicht sollte ich erst mal mit ihr reden.";
            else
                return "Why should I offer [P:Person_Magpie]the magpie[/P] my [I:I00_Cheese]nice cheese[/I]? Maybe I should talk to her first.";
        }
    }
    public static string Grab_In_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In [Il1,Nom] konnte ich nicht hineingreifen.";
            else
                return "I could not reach into [Il1,Nom].";
        }
    }
    public static string Grab_In_Find
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff in [Il1,Nom] hinein und ertastete so einiges.";
            else
                return "I reached into [Il1,Nom] and felt a lot of things.";
        }
    }
    public static string Drop_Pouch_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das [I:I00_Pouch]Beutelchen[/I] behielt ich bei mir. Wer weiß, ob ich es nochmal brauchte.";
            else
                return "I kept the little bag with me. Who knows if I'll need it again.";
        }
    }


    public static string OrderFeedback_PathFileNameFromFileName_14053
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "\\documents\\My Games\\The Masters Lair";
            else
                return "\\documents\\My Games\\The Masters Lair";
        }
    }
    public static string OrderFeedback_PathFileNameFromFileName_MAUI
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "\\documents\\My Games\\The Masters Lair";
            else
                return "\\documents\\My Games\\The Masters Lair";
        }
    }
    public static string MAUI_UI_Home_WindowTitle
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Versteck des Meisters - eine Art Exitgame";
            else
                return "The Masters Lair - a kind of escape game";
        }
    }

    public static string Order_Story_Info
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die komplette bisherige Geschichte liegt als 'Versteck_Meister_Story_Recording.html' im Verzeichnis 'Das Versteck des Meisters'.";
            else
                return "The complete story so far is available as 'masters_lair_Story_Recording.html' in the directory 'The Masters Lair'.";
        }

    }
    public static string OrderFeedback_LoadMC_Person_I_14024
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "\\documents\\My Games\\The Masters Lair";
            else
                return "\\documents\\My Games\\The Masters Lair";
        }
    }

    public static string Order_ManualDialog_Person_Self_10331
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[benutze Gegenstand mit anderem Gegenstand] Wendet einen Gegenstand mit einem anderen an. Was genau passiert, sollte sich aus dem Kontext ergeben: \"Benutze Feuerzeug mit Zigarette\". Aber vorsicht: Das hier ist ein Nichtraucherspiel. Wer im Versteck des Meisters raucht, zahlt 200€ für die Endreinigung.";
            else
                return "[use item with another item] Uses one item with another. What exactly happens should be clear from the context: \"Use lighter with cigarette\". But be careful: this is a non-smoking game. Anyone who smokes in the master's hiding place pays €200 for the final cleaning.";
        }
    }

    public static string Order_ManualDialog_Person_Self_10315
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Interactive Fiction ist eine Geschichte, die du als Spieler selbst vorantreiben musst.<br>Du bewegst dich durch eine fremde Welt, begegnest Leuten und findest Dinge. Wie die Geschichte sich entwickelt, hängt davon ab, was du den Leuten erzählst, was du mit den Gegenständen anfängst und zu welchen Orten du dich wendest. Dabei kommunizierst du mit der Geschichte über Texteingaben oder Multiple Choice. Genau so ist es auch bei \"Das Versteck des Meisters\".";
            else
                return "Interactive Fiction is a story that you as the player have to drive forward yourself.<br>You move through a strange world, meet people and find things. How the story develops depends on what you tell people, what you do with the objects and which places you go to. You communicate with the story via text input or multiple choice. It's exactly the same with \"The Master's Lair\".";
        }
    }
    public static string Order_ManualDialog_Person_Self_10316
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "\"Das Versteck des Meisters\" ist eine interactive Fiction (eine interaktive Geschichte), die per Multiple Choice sowie (größtenteils) auch per Texteingabe gespielt werden kann.<br>";
            else
                return "\"The Master's Lair\" is an interactive fiction (an interactive story) that can be played via multiple choice and (for the most part) also via text input.<br>";
        }
    }
    public static string Order_ManualDialog_Person_Self_10317
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "\"Das Versteck des Meisters\" lässt sich komplett mit Multiple Choice spielen, und zwar in zwei Modi: Wählst du \"Simples Multiple Choice\", wirst du weniger Optionen erhalten, was du machen kannst. Die Lösungen werden dadurch etwas einfacher. Wählst du diese Option nicht, erhältst du mehr Optionen. Lösbar ist das Spiel in jedem Fall. Wähle die einfachere Option, wenn du dich von zuvielen Handlungsmöglichkeiten umzingelt fühlst.<br>Bei Multiple Choice kannst du Gegenstände, Personen oder Orte direkt anklicken: Entweder im Fließtext oder in einer der zuschaltbaren Listen. Sogleich erhältst du eine Auswahl an Möglichkeiten, die du nun hast. Einfach was auswählen - und schon wird es ausgeführt, oder dir mitgeteilt, warum das gerade eine schlechte Idee war.<br>Du kannst über die Befehlsliste auch den umgekehrten Weg gehen und zuerst einmal einen Befehl auswählen. Wenn der Befehl nur mit einem Objekt funktioniert, wirst du danach gefragt.<br>Dialoge und alle Entscheidungen im Spiel funktionieren grundsätzlich über Multiple Choice. ";
            else
                return "\\\"The Master's Lair\" can be played entirely with multiple choice, in two modes: If you choose \\\"Simple Multiple Choice\\\", you will be given fewer options of what you can do. This will make the solutions a little easier. If you do not select this option, you will be given more options. The game can be solved in any case. Choose the simpler option if you feel surrounded by too many possible courses of action.<br>With multiple choice, you can click on objects, people or places directly: either in the continuous text or in one of the selectable lists. You will immediately be presented with a selection of options. Simply select something - and it will be executed, or you will be told why it was a bad idea.<br>You can also go the other way round via the command list and select a command first. If the command only works with one object, you will be asked for it.<br>Dialogs and all decisions in the game are based on multiple choice. ";
        }
    }
    public static string Order_ManualDialog_Person_Self_10318
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "\"Das Versteck des Meisters\" beinhaltet einen klassischen Textparser. Eingaben wie \"töte die spröde Kröte mit der schnöden Tröte\" werden selbstverständlich verstanden (sofern Kröte und Tröte vor Ort sind). Wenn es für deine Eingaben mehrere Interpretationsmöglichkeiten gibt, fragt das Spiel nach. Redest du mit Personen oder musst du eine Entscheidung treffen, kommt immer auch Multiple Choice ins Spiel. Alle Multiple Choice Menüs können übrigens auch mit der Tastatur bedient werden.<br>Wenn du ein fortgeschrittener Spieler bist und die volle Spieltiefe haben willst, sei dir die Texteingabe empfohlen.";
            else
                return "\"The Master's Lair\" contains a classic text parser. Inputs such as \"kill Bill with the quill\" are understood as a matter of course (provided Bill and quill are present). If there are several possible interpretations for your entries, the game will ask you. If you talk to people or have to make a decision, multiple choice always comes into play. All multiple choice menus can also be operated using the keyboard.<br>If you are an advanced player and want the full depth of the game, text input is recommended.";
        }
    }

    public static string Order_ManualDialog_Person_Self_10310
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Über 'Das Versteck des Meisters'";
            else
                return "About 'The Masters's Lair'";
        }
    }

    public static string AttachTo_Schale_Ok
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich befestigte [I:I10_Metall_Tray]die Schale[/I] an [I:I10_Bracket]der Halterung[/I].";
            else
                return "I attached [I:I10_Metal_Tray]the tray[/I] to [I:I10_Bracket]the bracket[/I].";
        }
    }
    public static string Heat_NoFire
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Magic_Candle]Der Kerzenhalter[/I] war ausgeschaltet.";
            else
                return "[I:I00_Magic_Candle]The candlestick[/I] was switched off.";
        }
    }
    public static string Heat_NoTray
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I10_Metall_Tray]Die Metallschale[/I] war nicht vernünftig befestigt.";
            else
                return "[I:I10_Metal_Tray]The metal tray[/I] was not properly attached.";
        }
    }
    public static string Heat_NoIngredients
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Zutaten waren nicht alle so an ihrem Platz, wie sie das sein sollten.";
            else
                return "The ingredients were not all in place as they should be.";
        }
    }
    public static string Heat_Success
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich erhitzte [I:I10_Metall_Tray]die Metallschale[/I] mit den Zutaten darin, und konnte mit ansehen, wie sie zu [I:I00_Slag]Schlacke[/I] verschmolzen.";
            else
                return "I heated [I:I10_metal_tray]the metal tray[/I] with the ingredients in it, and watched as they melted into [I:I00_Slag]slag[/I].";
        }
    }
    public static string Eat_Forest_Gras
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich überlegte einen Sekundenbruchteil lang, mich gierig auf [I:I01_Forest_Gras]das Waldgras[/I] zu stürzen und es in mich hinein zu schlingen. Dann fiel mir wieder ein, dass ich vorhin gut gegessen und daher überhaupt keinen Hunger hatte.";
            else
                return "I thought for a split second about greedily pouncing on [I:I01_Forest_Grass]the forest grass[/I] and gulping it down. Then I remembered that I had eaten well earlier and therefore wasn't hungry at all.";
        }
    }
    public static string Eat_Cheese
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Cheese]Das Käsestück[/I] war knochenhart, das konnte ich wirklich nicht essen.";
            else
                return "[I:I00_Cheese]The piece of cheese[/I] was as hard as a bone, I really couldn't eat it.";
        }
    }
    public static string Smell_L04_Tree
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I01_Trees]Die Bäume[/I] rochen nach Feuchtigkeit und moosüberwucherter Rinde.";
            else
                return "The trees smelled of damp and moss-covered bark.";
        }
    }
    public static string Smell_Forest_Grass
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I01_Forest_Gras]Das Waldgras[/I] roch wie Waldgras, das sich vollends mit Feuchtigkeit vollgesogen hatte.";
            else
                return "[I:I01_Forest_Grass]The forest grass[/I] smelled like forest grass that had become completely saturated with moisture.";
        }
    }
    public static string Smell_I02_Doormat
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I02_Doormat]Die Türmatte[/I] roch feucht und muffig.";
            else
                return "[I:I02_Doormat]The door mat[/I] smelled damp and musty.";
        }
    }
    public static string Smell_I04_Cupboard
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I04_Cupboard]Der Schrank[/I] roch nach altem, wurmstichigen Holz.";
            else
                return "[I:I04_Cupboard]The cupboard[/I] smelled of old, worm-eaten wood.";
        }
    }
    public static string Smell_I04_Shelf
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I04_Shelf]Das Regal[/I] roch nach altem, wurmstichigen Holz.";
            else
                return "[I:I04_Shelf]The shelf[/I] smelled of old, worm-eaten wood.";
        }
    }
    public static string Smell_I03_Pentagram
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I03_Pentagram]Das Pentagramm[/I] roch ein wenig nach alter Farbe.";
            else
                return "[I:I03_Pentagram]The pentagram[/I] smelled a little like old paint.";
        }
    }
    public static string Smell_I05_Pentagram
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I05_Pentagram]Das Pentagramm[/I] roch ein wenig nach alter Farbe.";
            else
                return "[I:I05_Pentagram]The pentagram[/I] smelled a little like old paint.";
        }
    }
    public static string Smell_I06_Seal
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich roch ein wenig altes Siegelwachs.";
            else
                return "I smelled a little old sealing wax.";
        }
    }
    public static string Smell_I07_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I07_Door]Die Tür[/I] roch ein wenig nach allen möglichen magischen Zutaten. Meister Gunnar sollte sich mal öfters die Hände waschen, wenn er hier rumlief.";
            else
                return "[I:I07_Door]The door[/I] smelled a little of all kinds of magical ingredients. Master Gunnar should wash his hands more often when he walked around here.";
        }
    }
    public static string Smell_I08_Clothes
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I08_Clothes]Die Wäsche[/I] roch so muffig, wie Wäsche eben riecht, wenn sie ewig nass in [I:I08_Washing_Machine]der Waschmaschine[/I] gelegen hat.";
            else
                return "[I:I08_Clothes]The laundry[/I] smelled as musty as laundry smells when it has been wet for ages in [I:I08_Washing_Machine]the washing machine[/I].";
        }
    }
    public static string Smell_I09_Books_Master
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I09_Books_Master]Die Bücher[/I] verbreiteten den verheißungsvollen Duft druckfrischer Bücher. Schade, dass der Buchinhalt da nicht mithalten konnte.";
            else
                return "[I:I09_Books_Master]The books[/I] exuded the promising aroma of books hot off the press. Too bad the book content couldn't keep up.";
        }
    }
    public static string Smell_I10_Giant_Mortar
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I10_Giant_Mortar]Im Mörser[/I] roch es nach allerlei zerstößelten Magiepülverchen.";
            else
                return "[I:I10_Giant_Mortar]The mortar[/I] smelled of all kinds of crushed magic powders.";
        }
    }
    public static string Smell_I10_Metal_Tray
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I10_Metall_Tray]Die Schale[/I] roch nach alten Verbrennungsrückständen.";
            else
                return "[I:I10_Metal_Tray]The tray[/I] smelled of old combustion residue.";
        }
    }
    public static string Smell_I12_Matress
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I12_Matress]Die Matratze[/I] roch nach einem fragwürdigen Duftspray. Wozu war diese Aktion wohl notwendig geworden?";
            else
                return "[I:I12_Matress]The mattress[/I] smelled of a questionable fragrance spray. Why was this action necessary?";
        }
    }
    public static string Smell_I13_Cupboard
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I13_Cupboard]Der Küchenschrank[/I] roch nur noch wenig nach Holz.";
            else
                return "[I:I13_Cupboard]The kitchen cupboard[/I] smelled only slightly of wood.";
        }
    }
    public static string Smell_I14_Bathtub
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich roch nichts besonderes.";
            else
                return "I didn't smell anything special.";
        }
    }
    public static string Smell_I14_Toilet
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I14_Toilet]Die Toilette[/I] roch nun auch nicht viel anders als viele andere Toiletten, die ich gesehen hatte.";
            else
                return "[I:I14_Toilet]The toilet[/I] didn't smell much different from many other toilets I had seen.";
        }
    }
    public static string Smell_I14_Flushing
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I14_Flushing]Die Spülung[/I] roch nach nichts weiter.";
            else
                return "[I:I14_Flushing]The flush[/I] smelled like nothing else.";
        }
    }
    public static string Smell_I00_Book_Master
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Book_Master]Das Buch[/I] verströmte den hoffnungsfrohen Geruch eines frischgedruckten Exemplars.";
            else
                return "[I:I00_Book_Master]The book[/I] exuded the hopeful smell of a freshly printed copy.";
        }
    }
    public static string Smell_I00_Cheese
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Cheese]Der Käse[/I] roch ein wenig säuerlich, verströmte aber sehr wenig Geruch.";
            else
                return "[I:I00_Cheese]The cheese[/I] smelled a little sour, but gave off very little odor.";
        }
    }
    public static string Smell_I00_Magic_Candle
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Magic_Candle]Die magische Kerze[/I] verströmte ein wenig Geruch von magischem Kerzenwachs.";
            else
                return "[I:I00_Magic_Candle]The magic candle[/I] gave off a little scent of magic candle wax.";
        }
    }
    public static string Smell_I00_Magic_Powder
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich ging besser nicht zu nah an [I:I00_Magic_Powder]das Pulver[/I] mit der Nase, sonst zog ich mir noch versehentlich eine Line von dem Zeug.";
            else
                return "I better not get too close to [I:I00_Magic_Powder]the powder[/I] with my nose or I might accidentally draw a line from the stuff.";
        }
    }
    public static string Smell_I00_Supermagic_Powder
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich ging besser nicht zu nah an [I:I00_Supermagic_Powder]das Pulver[/I] mit der Nase, sonst zog ich mir noch versehentlich eine Line von dem Zeug.";
            else
                return "I better not get too close to [I:I00_Supermagic_Powder]the powder[/I] with my nose, otherwise I'd accidentally draw a line from the stuff.";
        }
    }
    public static string Smell_I00_Paper_Sheets
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Paper_Sheets]Die Papierbögen[/I] rochen leicht muffig.";
            else
                return "[I:I00_Paper_Sheets]The sheets of paper[/I] smelled slightly musty.";
        }
    }
    public static string Smell_I00_Plastic_Bag
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Plastic_Bag]Der Plastikbeutel[/I] mit den Sporen roch nach feuchtem Erdboden.";
            else
                return "[I:I00_Plastic_Bag]The plastic bag[/I] with the spores smelled of damp soil.";
        }
    }
    public static string Smell_I00_Polishing_Rag
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Polishing_Rag]Der Polierlappen[/I] verströmte genau den muffigen Geruch, den man solchen Lappen immer nachsagte.";
            else
                return "[I:I00_Polishing_Rag]The polishing rag[/I] exuded exactly the musty smell that such rags were always said to have.";
        }
    }
    public static string Smell_I00_Pouch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Pouch]Das Beutelchen[/I] roch nach altem Leder.";
            else
                return "[I:I00_Pouch]The pouch[/I] smelled of old leather.";
        }
    }
    public static string Smell_I00_Roll_Plaster
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Roll_Plaster]Das Pflaster[/I] roch ein wenig nach Klebstoff.";
            else
                return "[I:I00_Roll_Plaster]The plaster[/I] smelled a little like glue.";
        }
    }
    public static string Smell_I00_Slag
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Slag]Die Schlacke[/I] roch verkohlt.";
            else
                return "[I:I00_Slag]The slag[/I] smelled charred.";
        }
    }
    public static string Smell_I00_Wonder_Wart_Sponge
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Wonder_Wart_Sponge]Der Wunderwarzenschwamm[/I] verströmte einen herrlichen und unverwechselbaren wunderwarzenschwammartigen Geruch.";
            else
                return "[I:I00_Wonder_Wart_Sponge]The wonder wart sponge[/I] gave off a wonderful and unmistakable wonder wart sponge-like smell.";
        }
    }
    public static string Smell_Person_Fish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Fish]Der Fisch[/P] roch unangenehm nach nassem Sägemehl.";
            else
                return "[P:Person_Fish]The fish[/P] smelled unpleasantly of wet sawdust.";
        }
    }
    public static string Smell_Person_Owl
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Owl]Die Eule[/P] roch etwas muffig.";
            else
                return "[P:Person_Owl]The owl[/P] smelled a little musty.";
        }
    }
    public static string Smell_Person_Magpie
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Magpie]Die Elster[/P] roch wie ein ungewaschener Rabenvogel.";
            else
                return "[P:Person_Magpie]The magpie[/P] smelled like an unwashed raven.";
        }
    }
    public static string Smell_Knights_Armor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Knights_Armor]Die Ritterrüstung[/P] roch leicht nach Poliermittel.";
            else
                return "[P:Person_Knights_Armor]The armor[/P] smelled faintly of polish.";
        }
    }
    public static string Smell_Person_Parrot
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Parrot]Der Papagei[/P] roch einfach nach nichts.";
            else
                return "[P:Person_Parrot]The parrot[/P] simply smelled of nothing.";
        }
    }
    public static string Take_Eule
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Owl]Die Eule[/P] war auf dem Sims festgeklebt. Vermutlich ein Klimaschützer.";
            else
                return "[P:Person_Owl]The owl[/P] was glued to the ledge. Presumably a climate protector.";
        }
    }
    public static string Take_Elster
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Magpie]Die Elster[/P] war magisch festgekettet. Die würde ich wohl nicht hier wegbekommen.";
            else
                return "[P:Person_Magpie]The magpie[/P] was magically chained. I probably wouldn't be able to get it out of here.";
        }
    }
    public static string Take_Schale
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I10_Metall_Tray]Die Schale[/I] war super dort, wo sie jetzt war.";
            else
                return "[I:I10_Metal_Tray]The tray[/I] was great where it was now.";
        }
    }

    public static string ThrowPersonAt_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nach reiflicher Überlegung fiel [RP:1,Dat] doch kein guter Grund ein, [Pl2,Nom] nach [Il3,Dat] zu werfen.";
            else
                return "After careful consideration, [RP:1,Dat] could not think of a good reason to throw [Pl2,Nom] at [Ll3,Dat] after all.";
        }
    }
    public static string ThrowPersonIn_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nach reiflicher Überlegung fiel [RP:1,Dat] doch kein guter Grund ein, [Pl2,Nom] in [Il3,Dat] zu werfen.";
            else
                return "After careful consideration, [RP:1,Dat] could not think of a good reason to throw [Pl2,Nom] in [Ll3,Dat] after all.";
        }
    }
    public static string TouchW_Books
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das letzte, was dieses Buch brauchte, war noch eine weitere Ladung magischer Lebensenergie. Bitte, bitte nicht.";
            else
                return "The last thing this book needed was another charge of magical life energy. Please, please don't.";
        }
    }
    public static string Touch_Angry_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff nach [I:I09_Angry_Book]dem hasserfüllten Buch[/I], und es schnappte zähnefletschend nach mir.";
            else
                return "I reached for [I:I09_Angry_Book]the hateful book[/I], and it snapped at me, snarling.";
        }
    }
    public static string Touch_Crazy_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff nach [I:I09_Cray_Book]dem verrückten Buch[/I]. Das verrückte Gekicher, das daraus dring, ließ mich inne halten.";
            else
                return "I reached for [I:I09_Cray_Book]the crazy book[/I]. The crazy giggling that came from it gave me pause.";
        }
    }
    public static string Touch_Weird_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff nach [I:I09_Weird_Book]dem seltsamen Buch[/I]. Das wirre Geflüster und das Rascheln der Buchseiten schreckten mich ab davor, es zu berühren.";
            else
                return "I reached for [I:I09_Weird_Book]the strange book[/I]. The confused whispering and the rustling of the book's pages put me off touching it.";
        }
    }
    public static string Touch_Demonic_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff nach [I:I09_Demonic_Book]dem dämonischen Buch[/I]. Die glutroten Augen auf dem Einband richteten sich erwartungsvoll auf mich. Rasch ließ ich von meinem Vorhaben ab.";
            else
                return "I reached for [I:I09_Demonic_Book]the demonic book[/I]. The glowing red eyes on the cover turned expectantly towards me. I quickly abandoned my plan.";
        }
    }
    public static string Touch_Satanic_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff nach [I:I09_Satanic_Book]dem satanischen Buch[/I]. Die Seiten raschelten erwartungsvoll, als wollten sie mich auf der Stelle verschlingen. Rasch ließ ich von meinem Vorhaben ab.";
            else
                return "I reached for [I:I09_Satanic_Book]the satanic book[/I]. The pages rustled expectantly, as if they wanted to devour me on the spot. I quickly abandoned my plan.";
        }
    }
    public static string SpreadOn_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie soll [Il1,Akk] auf [Il2,Nom] gestreut werden?";
            else
                return "How should [Il1,Akk] be scattered on [Il2,Nom]?";
        }
    }
    public static string SpreadOn_Clothes_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich sollte [I:I08_Clothes]die Wäsche[/I] erst mal aus [I:I08_Washing_Machine]der Waschmaschine[/I] holen, ehe ich irgendwelche Experimente damit machte.";
            else
                return "I should [I:I08_Clothes]get the laundry[/I] out of [I:I08_Washing_Machine]the washing machine[/I] first before I did any experiments with it.";
        }
    }
    public static string SpreadOn_Clothes_WWS
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich streute den Inhalt des Beutels auf [I:I08_Clothes]die feuchte Wäsche[/I]. In atemberaubender Geschwindigkeit wuchs darauf [I:I00_Wonder_Wart_Sponge]ein riesiger Wunderwarzenschwamm[/I], der gar eklig anzusehen war.";
            else
                return "I sprinkled the contents of the bag onto [I:I08_Clothes]the damp laundry[/I]. At breathtaking speed, [I:I00_Wonder_Wart_Sponge]a huge wonder wart sponge[/I] grew on it, which was disgusting to look at.";
        }
    }
    public static string Enlight_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie sollte [Il1,Akk] mit [Il2,Nom] beleuchtet werden?";
            else
                return "How should [Il1,Akk] be illuminated with [Il2,Nom]?";
        }
    }
    public static string Enlight_Stone_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hielt den Stein in den Himmel, so nah wie möglich an den Mond heran. Leider passierte nichts weiter.";
            else
                return "I held the stone up to the sky, as close to the moon as possible. Unfortunately, nothing else happened.";
        }
    }
    public static string Enlight_Solo_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Womit sollte [Il1,Akk] beleuchtet werden?";
            else
                return "What should be used to illuminate [Il1,Akk]?";
        }
    }
    public static string Enlight_Fail_NoCoin
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich leuchtete in [I:I08_Water]das Wasser[/I], aber fand nichts weiter neues.";
            else
                return "I shone a light into the water, but found nothing else new.";
        }
    }
    public static string Enlight_Fail_NoLight
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich leuchtete mit [I:I00_Magic_Candle]dem Kerzenhalter[/I] in [I:I08_Water]das Wasser[/I], aber das hätte wirklich deutlich besser funktioniert, wenn die Kerze an gewesen wäre.";
            else
                return "I shone [I:I00_Magic_Candle]the candle holder[/I] into [I:I08_Water]the water[/I], but that would really have worked much better if the candle had been on.";
        }
    }
    public static string Enlight_Find_Coin
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich leuchtete mit [I:I00_Magic_Candle]dem Kerzenhalter[/I] in [I:I08_Water]das Wasser[/I]. Irgendwo tief auf dem Grund blitzte etwas helles, metallenes auf. Wie [I:I00_Coin]eine Münze[/I].";
            else
                return "I shone [I:I00_Magic_Candle]the candleholder[/I] into [I:I08_Water]the water[/I]. Somewhere deep at the bottom, something bright and metallic flashed. Like [I:I00_Coin]a coin[/I].";
        }
    }

    public static string Verb_beleuchte
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "beleuchte";
            else
                return "illuminate";
        }
    }
    public static string Verb_erhelle
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "erhelle";
            else
                return "_illuminate";
        }
    }
    public static string Verb_bescheine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "bescheine";
            else
                return "shone";
        }
    }
    public static string Verb_fixiere
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "fixiere";
            else
                return "_fix";
        }
    }
    public static string Verb_fixier
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "fixier";
            else
                return "__fix";
        }
    }


    public static string DoRR_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mit einem leichten Ächzen wich alles \"Leben\" aus [P:Person_Knights_Armor]der Ritterrüstung[/P].";
            else
                return "With a slight groan, all \"life\" gave way to [P:Person_Knights_Armor]the knight's armor[/P].";
        }
    }

    public static string DoRR_Seufzen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus der Richtung [P:Person_Knights_Armor]der Ritterrüstung[/P] dran ein leises Seufzen an mein Ohr.";
            else
                return "From the direction of [P:Person_Knights_Armor]the knight's armor[/P], a soft sigh reached my ear.";
        }
    }
    public static string DoRR_Bewegen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus den Augenwinkeln bemerkte ich etwas. Hatte sich [P:Person_Knights_Armor]die Ritterrüstung[/P] etwa bewegt?";
            else
                return "I noticed something out of the corner of my eye. Had [P:Person_Knights_Armor]the armor[/P] moved?";
        }
    }
    public static string DoRR_Wispern
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine fast unhörbare Stimme drang an mein Ohr: \"Die Klaue! Die Klaue ist hier!\" Hatte da etwa [P:Person_Knights_Armor]die Ritterrüstung[/P] gesprochen?";
            else
                return "An almost inaudible voice reached my ear: \\\"The claw! The claw is here!\" Was that [P:Person_Knights_Armor]the armor[/P] speaking?";
        }
    }

    public static string DoRR_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Knights_Armor]Die Ritterrüstung[/P] klapperte vor sich hin.";
            else
                return "[P:Person_Knights_Armor]The knight's armor[/P] rattled to itself.";
        }
    }
    public static string DoRR_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Knights_Armor]Die Ritterrüstung[/P] grölte: \"Einer, einer geht noch rein!\"";
            else
                return "[P:Person_Knights_Armor]The knight's armor[/P] roared: \"One, one more to go in!\"";
        }
    }
    public static string DoRR_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Knights_Armor]Die Ritterrüstung[/P] führte ein kleines Tänzchen auf.";
            else
                return "[P:Person_Knights_Armor]The armor[/P] performed a little dance.";
        }
    }
    public static string DoRR_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Knights_Armor]Die Ritterrüstung[/P] schaute in meine Richtung. \"Ihre Papiere bitte!\" ";
            else
                return "[P:Person_Knights_Armor]The knight's armor[/P] looked in my direction. \"Your papers please!\"";
        }
    }
    public static string DoRR_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Knights_Armor]Die Ritterrüstung[/P] drehte quietschend ihren Kopf hin und her.";
            else
                return "[P:Person_Knights_Armor]The knight's armor[/P] turned its head back and forth, squeaking.";
        }
    }
    public static string Do_Fish_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mit einem letzten \"Blub\" wich alles \"Leben\" aus [P:Person_Fish]dem Fisch[/P].";
            else
                return "With a final bubble, all \"life\" was evacuated from [P:Person_Fish]the fish[/P].";
        }
    }
    public static string Do_Fish_Reaktion1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Von irgendwoher drang ein leises \"Blub\". ";
            else
                return "A soft bubbling sound came from somewhere.";
        }
    }
    public static string Do_Fish_Reaktion2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Von irgendwoher drang ein Rascheln. ";
            else
                return "A rustling sound came from somewhere. ";
        }
    }
    public static string Do_Fish_Reaktion3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Von irgendwoher drang ein glucksendes Geräusch.";
            else
                return "A gurgling sound came from somewhere.";
        }
    }
    public static string Do_Fish_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Fish]Der ausgestopfte Fisch[/P] blubberte vor sich hin.";
            else
                return "[P:Person_Fish]The stuffed fish[/P] bubbled away.";
        }
    }
    public static string Do_Fish_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Fish]Der ausgestopfte Fisch[/P] spuckte eine Staubfontäne aus.";
            else
                return "[P:Person_Fish]The stuffed fish[/P] spat out a fountain of dust.";
        }
    }
    public static string Do_Fish_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Fish]Der ausgestopfte Fisch[/P] sah mich an und sagte \"Blub\".";
            else
                return "[P:Person_Fish]The stuffed fish[/P] looked at me and make a bubbling sound.";
        }
    }
    public static string Do_Fish_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Fish]Der ausgestopfte Fisch[/P] zappelte fröhlich vor sich hin.";
            else
                return "[P:Person_Fish]The stuffed fish[/P] wriggled happily.";
        }
    }
    public static string Do_Fish_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Fish]Der ausgestopfte Fisch[/P] versuchte, davon zu schwimmen, was ohne Wasser nur mäßig gut gelang.";
            else
                return "[P:Person_Fish]The stuffed fish[/P] tried to swim away, which was only moderately successful without water.";
        }
    }
    public static string Do_Magpie_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Magpie]Die Elster[/P] krächzte noch einmal kurz, dann wurde sie wieder leblos.";
            else
                return "[P:Person_Magpie]The magpie[/P] cawed once more briefly, then became lifeless again.";
        }
    }
    public static string Do_Parrot_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mit einem leisen Krächzen verwandelte sich [P:Person_Parrot]der Papagei[/P] wieder in seine eigentliche, ausgestopfte Version zurück.";
            else
                return "With a soft caw, [P:Person_Parrot]the parrot[/P] transformed back into its actual, stuffed version.";
        }
    }
    public static string Do_Parrot_Reaktion1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hatte ich da eben ein leises Krächzen gehört?";
            else
                return "Had I just heard a soft croak?";
        }
    }
    public static string Do_Parrot_Reaktion2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Parrot]Der ausgestopfte Papagei[/P] schien mich auffordernd anzustarren.";
            else
                return "[P:Person_Parrot]The stuffed parrot[/P] seemed to be staring at me in invitation.";
        }
    }
    public static string Do_Parrot_Reaktion3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Parrot]Der ausgestopfte Papagei[/P] schien langsam sein Gefieder zu plustern. Äh, ich musste mir das einbilden...";
            else
                return "[P:Person_Parrot]The stuffed parrot[/P] seemed to be slowly fluffing its feathers. Uh, I had to be imagining things...";
        }
    }
    public static string Do_Parrot_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Parrot]Der ausgestopfte Papagei[/P] musterte mich unverhohlen. \"Fürwahr, fürwahr, man kann sich seinen Besuch nicht immer aussuchen.\" ";
            else
                return "[P:Person_Parrot]The stuffed parrot[/P] eyed me blatantly. \"Truly, truly, you can't always choose your visitors.\" ";
        }
    }
    public static string Do_Parrot_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Parrot]Der ausgestopfte Papagei[/P] musterte mich unverschämt. \"Hat dir schon mal jemand gesagt, dass du sehr viel besser aussähest, wenn du dein Gesicht mit Nougatcreme einriebest?\" ";
            else
                return "[P:Person_Parrot]The stuffed parrot[/P] eyed me impertinently. \"Has anyone ever told you that you'd look a lot better if you rubbed nougat cream on your face?\" ";
        }
    }
    public static string Do_Parrot_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Parrot]Der ausgestopfte Papagei[/P] gähnte genervt.";
            else
                return "[P:Person_Parrot]The stuffed parrot[/P] yawned annoyed.";
        }
    }
    public static string Do_Parrot_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Parrot]Der ausgestopfte Papagei[/P] plusterte sein Gefieder auf. ";
            else
                return "[P:Person_Parrot]The stuffed parrot[/P] fluffed up its feathers.";
        }
    }
    public static string Do_Parrot_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Parrot]Der ausgestopfte Papagei[/P] musterte mich herablassend.";
            else
                return "[P:Person_Parrot]The stuffed parrot[/P] eyed me condescendingly.";
        }
    }

    public static string Do_Magpie_Reaktion1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hatte ich da eben aus der Richtung [P:Person_Magpie]der Elster[/P] ein leises Krächzen gehört?";
            else
                return "Did I just hear a soft cawing from the direction of [P:Person_Magpie]the magpie[/P]?";
        }
    }
    public static string Do_Magpie_Reaktion2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Magpie]Diese dämliche Elster[/P] schien mich ausgesprochen unverschämterweise anzustarren.";
            else
                return "[P:Person_Magpie]That stupid magpie[/P] seemed to be staring at me in a decidedly insolent manner.";
        }
    }
    public static string Do_Magpie_Reaktion3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus den Augenwinkeln heraus nahm ich wahr, dass [P:Person_Magpie]die Elster[/P] sich bewegt hatte. Nur einen Millimeter, aber ich war mir sicher!";
            else
                return "Out of the corner of my eye, I noticed that [P:Person_Magpie]the magpie[/P] had moved. Just a millimeter, but I was sure of it!";
     }
    }
    public static string Do_Magpie_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Magpie]Die Elster[/P] schimpfte mit derartig schrecklichen Schimpfworten vor sich hin, dass ich ganz rot wurde.";
            else
                return "[P:Person_Magpie]The magpie[/P] scolded me with such horrible swear words that I turned red.";
        }
    }
    public static string Do_Magpie_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Magpie]Die Elster[/P] schnappte nach mir. Zum Glück war ich schneller.";
            else
                return "[P:Person_Magpie]The magpie[/P] snapped at me. Luckily I was quicker.";
        }
    }
    public static string Do_Magpie_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Magpie]Die Elster[/P] pickte nach meiner Hand. Zum Glück war ich schneller.";
            else
                return "[P:Person_Magpie]The magpie[/P] pecked at my hand. Luckily I was quicker.";
        }
    }
    public static string Do_Magpie_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Magpie]Die Elster[/P] krächzte eine schiere Schimpfkanonade auf mich los.";
            else
                return "[P:Person_Magpie]The magpie[/P] cawed a sheer torrent of abuse at me.";
        }
    }
    public static string Do_Magpie_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Magpie]Die Elster[/P] schaute mich wütend an.";
            else
                return "[P:Person_Magpie]The magpie[/P] looked at me angrily.";
        }
    }
    public static string Do_Skeleton_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Knochen [P:Person_Librarian]des Skeletts[/P] klapperten noch einmal vor sich hin, dann war wieder Stille.";
            else
                return "The bones [P:Person_Librarian]of the skeleton[/P] rattled once more, then there was silence again.";
        }
    }
    public static string DoSkelett_Reaktion1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Knochen [P:Person_Librarian]des Skeletts[/P] klapperten leise vor sich hin.";
            else
                return "The bones [P:Person_Librarian]of the skeleton[/P] rattled softly.";
        }
    }
    public static string DoSkelett_Reaktion2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Librarian]Das Skelett[/P] schien mich durchdringend anzustarren.";
            else
                return "[P:Person_Librarian]The skeleton[/P] seemed to stare at me piercingly.";
        }
    }
    public static string DoSkelett_Reaktion3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Librarian]Das Skelett[/P] schien irgendwas zu wispern und die Hand nach mir zu recken.";
            else
                return "[P:Person_Librarian]The skeleton[/P] seemed to whisper something and reach out to me.";
        }
    }
    public static string DoSkelett_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Librarian]Das Skelett[/P] nahm ein Buch vom Stapel, drückte einen Stempel auf ein Einlegeblatt, und legte es dann auf den nächsten Stapel.";
            else
                return "[P:Person_Librarian]The skeleton[/P] took a book from the pile, pressed a stamp on an insert sheet, and then placed it on the next pile.";
        }
    }
    public static string DoSkelett_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Librarian]Das Skelett[/P] sah mich durchdringend an. \"Keine Eselsohren in die Bücher machen!\" ";
            else
                return "[P:Person_Librarian]The skeleton[/P] looked at me piercingly. \\\"Don't dog-ear the books!\" ";
        }
    }
    public static string DoSkelett_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Librarian]Das Skelett[/P] stützte den Kopf auf die Hände und stöhnte: \"Das wird mir alles zuviel...\" ";
            else
                return "[P:Person_Librarian]The skeleton[/P] leaned its head on its hands and groaned: \"This is all getting too much for me...\" ";
        }
    }
    public static string DoSkelett_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Librarian]Das Skelett[/P] musterte mich skeptisch. \"Die Bücher in den Regalen bitte nicht anfassen. Sonst endest du wie ich.\" ";
            else
                return "[P:Person_Librarian]The skeleton[/P] eyed me skeptically. \\\"Please don't touch the books on the shelves. Otherwise you'll end up like me.\" ";
        }
    }
    public static string DoSkelett_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Librarian]Das Skelett[/P] summte leise vor sich hin.";
            else
                return "[P:Person_Librarian]The skeleton[/P] hummed quietly to itself.";
        }
    }
    public static string Do_Snake_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein letztes Zischeln, dann wurde [P:Person_Snake]die Schlange[/P] wieder steif und leblos.";
            else
                return "One last hiss, then [P:Person_Snake]the snake[/P] became stiff and lifeless again.";
        }
    }
    public static string Do_Snake_Reaktion1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hatte ich da eben ein leises Zischeln gehört?";
            else
                return "Had I just heard a soft hiss?";
        }
    }
    public static string Do_Snake_Reaktion2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Dieses Rascheln gerade hatte ich mir doch nicht eingebildet!";
            else
                return "I hadn't just imagined that rustling sound!";
        }
    }
    public static string Do_Snake_Reaktion3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich vernahm ein leises Knistern. Woher das wohl kam?";
            else
                return "I heard a soft crackling sound. I wonder where it was coming from?";
        }
    }
    public static string Do_Snake_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Snake]Die Schlange[/P] zischelte wütend.";
            else
                return "[P:Person_Snake]The snake[/P] hissed angrily.";
        }
    }
    public static string Do_Snake_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Snake]Die Schlange[/P] zischelte fröhlich.";
            else
                return "[P:Person_Snake]The snake[/P] hissed happily.";
        }
    }
    public static string Do_Snake_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Snake]Die Schlange[/P] zischelte zischelnd.";
            else
                return "[P:Person_Snake]The snake[/P] hissed with a hiss.";
        }
    }
    public static string Do_Snake_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Snake]Die Schlange[/P] schlängelte sich.";
            else
                return "[P:Person_Snake]The snake[/P] slithered.";
        }
    }
    public static string Do_Snake_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Snake]Die Schlange[/P] bleckte mit ihrer langen Zunge um sich.";
            else
                return "[P:Person_Snake]The snake[/P] bared its long tongue.";
        }
    }

    public static string DoOwl_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mit einem leichten \"Uhuuuh\" wich alles \"Leben\" aus [P:Person_Owl]der Eule[/P].";
            else
                return "With a slight \"Uhuuuh\", everything \"lives\" evaded [P:Person_Owl]the owl[/P].";
        }
    }

    public static string DoOwl_Seufzen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus der Richtung [P:Person_Owl]der Eule[/P] dran ein leiser Eulenruf an mein Ohr.";
            else
                return "From the direction of [P:Person_Owl]the owl[/P], a soft owl call reached my ear.";
        }
    }
    public static string DoOwl_Bewegen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus den Augenwinkeln bemerkte ich etwas. Hatte sich [P:Person_Owl]die ausgestopfte Eule[/P] etwa bewegt?";
            else
                return "I noticed something out of the corner of my eye. Had [P:Person_Owl]the stuffed owl[/P] moved?";
        }
    }
    public static string DoOwl_Wispern
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine fast unhörbare Stimme drang an mein Ohr. Ich konnte sie nicht verstehen.";
            else
                return "An almost inaudible voice reached my ear: I couldn't understand it.";
        }
    }

    public static string DoOwl_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Owl]Die Eule[/P] stieß leise Rufe aus.";
            else
                return "[P:Person_Owl]The owl[/P] hooted softly.";
        }
    }
    public static string DoOwl_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Owl]Die Eule[/P] putzte sich unter dem linken Flügel.";
            else
                return "[P:Person_Owl]The owl[/P] preened under the left wing.";
        }
    }
    public static string DoOwl_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Owl]Die Eule[/P] putzte sich unter dem rechten Flügel.";
            else
                return "[P:Person_Owl]The owl[/P] preened under the right wing.";
        }
    }
    public static string DoOwl_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Owl]Die Eule[/P] musterte mich voller Weisheit und Güte.";
            else
                return "[P:Person_Owl]The owl[/P] eyed me with wisdom and kindness.";
        }
    }
    public static string DoOwl_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Owl]Die Eule[/P] musterte mich ungeduldig.";
            else
                return "[P:Person_Owl]The owl[/P] eyed me impatiently.";
        }
    }

    public static string Adv_Person_Knights_Armor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die klapprige Ritterrüstung stand etwas windschief in der Gegend herum.";
            else
                return "The rickety knight's armor was standing around a little crooked.";
        }
    }
    public static string Adv_Person_Owl
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Eule musterte mich mit aller Weisheit im Blick, derer ausgestopfte Eulen eben so fähig sind.";
            else
                return "The owl eyed me with all the wisdom that stuffed owls are capable of.";
        }
    }
    public static string Adv_Person_Librarian
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Skelett ruhte recht entspannt auf einem Bürostuhl hinter [I:I09_Librarians_Desk]dem Bibliothekstresen[/I].";
            else
                return "The skeleton was resting quite relaxed on an office chair behind [I:I09_Librarians_Desk]the library counter[/I].";
        }
    }
    public static string Adv_Person_Fish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Fisch glotze mich an wie... wie ein Fisch!";
            else
                return "The fish stared at me like... like a fish!";
        }
    }
    public static string Adv_Person_Parrot
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein ausgestopfter grüner Papagei mit einigen lustigen bunten Federn.";
            else
                return "A stuffed green parrot with some funny colorful feathers.";
        }
    }
    public static string Adv_Person_Magpie
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Elster musterte mich unverhohlen, als hätte sie die Absicht, im nächsten Moment meine sämtlichen Wertgegenstände an sich zu reißen.";
            else
                return "The magpie looked at me blatantly, as if it intended to snatch all my valuables in the next moment.";
        }
    }
    public static string Adv_Person_Snake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Schlange starrte mich aus toten Augen an, als wolle sie mich in Sicherheit wiegen vor ihrem tödlichen Biss. Aber nicht mit mir!";
            else
                return "The snake stared at me from dead eyes, as if it wanted to lull me into safety from its deadly bite. But I wasn't taken in by that!";
        }
    }
    public static string Take_Underwear
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich ließ [I:I08_Underpants]die Unterhose[/I] liegen, wo sie war. Wenn Meister Gunnar seiner Wäsche bedurfte, dann sollte er selbst drauf achten.";
            else
                return "I left [I:I08_Underpants]the underpants[/I] where they were. If Master Gunnar needed his underwear, he should take care of it himself.";
        }
    }
    public static string Take_Coin
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I00_Coin]Die Münze[/I] schimmerte tief unten [I:I08_Well]im Brunnen[/I]. Ich konnte sie mit der Hand nicht erreichen und in [I:I08_Water]das eiskalte Wasser[/I] eintauchen konnte ich auch nicht.";
            else
                return "[I:I00_Coin]The coin[/I] shimmered deep down [I:I08_Well]in the well[/I]. I couldn't reach it with my hand and I couldn't dive into [I:I08_Water]the icy cold water[/I] either.";
        }
    }
    public static string Take_Supermagic_Powder
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich füllte [I:I00_Supermagic_Powder]das magische Pülverchen[/I] in mein [I:I00_Pouch]kleines Lederbeutelchen[/I].";
            else
                return "I filled [I:I00_Supermagic_Powder]the magic powder[/I] into my [I:I00_Pouch]small leather pouch[/I].";
        }
    }
    public static string Take_Supermagic_Powder_NoPouch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte [I:I00_Supermagic_Powder]das magische Pülverchen[/I] in mein [I:I00_Pouch]kleines Lederbeutelchen[/I] füllen, stellte aber fest, dass ich dieses gar nicht dabei hatte.";
            else
                return "I wanted to fill [I:I00_Supermagic_Powder]the magic powder[/I] into my [I:I00_Pouch]small leather pouch[/I], but realized that I didn't have it with me.";
        }
    }
    public static string Take_Clothes
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Angewidert zog ich [I:I08_Clothes]die Stinkewäsche[/I] aus [I:I08_Washing_Machine]der Waschmaschine[/I]. Ich schaffte es gerade noch, sie in [I:I08_Laundry_Basket]den Wäschekorb[/I] zu befördern, bevor mir redlich schlecht wurde.";
            else
                return "Disgusted, I pulled [I:I08_Clothes]the stinky clothes[/I] out of [I:I08_Washing_Machine]the washing machine[/I]. I just managed to get them into [I:I08_Laundry_Basket]the laundry basket[/I] before I got really sick.";
        }
    }
    public static string Take_Tuermatte
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff nach [I:I02_Doormat]der Türmatte[/I], ließ sie aber dann doch liegen. Was wollte ich mit dem ollen Ding?";
            else
                return "I reached for [I:I02_Doormat]the door mat[/I], but then left it behind. What did I want with that old thing?";
        }
    }

    public static string Touch_Fish_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte [P:Person_Fish]den Fisch[/P] mit [I:I00_Claw]der Klaue[/I] berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "I wanted to touch [P:Person_Fish]the fish[/P] with [I:I00_Claw]the claw[/I]. But I was afraid that this unstable construction would fly around my ears and the claw would tumble to the ground. I had to stabilize my claw holder somehow.";
        }
    }
    public static string Touch_Fish_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte [P:Person_Fish]den Fisch[/P] mit [I:I00_Claw]der Klaue[/I]. Sofort belebte sich der Fisch und zappelte wie verrückt. Hm, ich musste wohl keine Angst haben, dass er außerhalb des Wasser erstickte...";
            else
                return "I touched [P:Person_Fish]the fish[/P] with [I:I00_Claw]the claw[/I]. Immediately, the fish revived and wriggled like crazy. Hm, I guess I didn't have to worry about it suffocating outside the water...";
        }
    }
    public static string Touch_Fish_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte [P:Person_Fish]den Fisch[/P] mit [I:I00_Claw]der Klaue[/I]. Da der Fisch schon wach war, hielt sich der Effekt in Grenzen.";
            else
                return "I touched [P:Person_Fish]the fish[/P] with [I:I00_Claw]the claw[/I]. Since the fish was already awake, the effect was limited.";
        }
    }
    public static string Touch_Magpie_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte die Elster mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "I wanted to touch the magpie with my claw. But I was afraid that this unstable construction would fly around my ears and the claw would tumble to the ground. I had to stabilize my claw holder somehow.";
        }
    }
    public static string Touch_Magpie_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die Elster mit der Klaue. Sofort belebte sich der Vogel und schimpfte krächzend wie verrückt. Warum mault er mich eigentlich an? Verdammtes Mistvieh.";
            else
                return "I touched the magpie with my claw. The bird immediately came to life and cawed like crazy. Why is he grumbling at me? Damned bastard.";
        }
    }
    public static string Touch_Magpie_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die Elster mit der Klaue. Da die Elster schon wach war, hielt sich der Effekt in Grenzen.";
            else
                return "I touched the magpie with my claw. As the magpie was already awake, the effect was limited.";
        }
    }
    public static string Touch_Parrot_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte den Papageien mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "I wanted to touch the parrot with my claw. But I was afraid that this unstable construction would fly around my ears and the claw would tumble to the floor. I had to stabilize my claw holder somehow.";
        }
    }
    public static string Touch_Parrot_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte den Papageien mit der Klaue. Sofort belebte sich der Vogel und bauschte sein Gefieder auf.";
            else
                return "I touched the parrot with my claw. The bird immediately perked up and puffed out its feathers.";
        }
    }
    public static string Touch_Parrot_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte den Papageien mit der Klaue. Da der Papagei schon wach war, hielt sich der Effekt in Grenzen.";
            else
                return "I touched the parrot with my claw. As the parrot was already awake, the effect was limited.";
        }
    }
    public static string Touch_Snake_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte die Schlange mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "I wanted to touch the snake with my claw. But I was afraid that this unstable construction would fly around my ears and the claw would tumble to the ground. I had to stabilize my claw holder somehow.";
        }
    }
    public static string Touch_Snake_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die Schlange mit der Klaue. Sofort belebte sich das Vieh und schlängelte fröhlich vor sich hin.";
            else
                return "I touched the snake with my claw. The creature immediately came to life and wriggled happily.";
        }
    }
    public static string Touch_Snake_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die Schlange mit der Klaue. Da die Schlange schon wach war, hielt sich der Effekt in Grenzen.";
            else
                return "I touched the snake with my claw. As the snake was already awake, the effect was limited.";
        }
    }

    public static string Touch_Librarian_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte das Skelett mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "I wanted to touch the skeleton with my claw. But I was afraid that this unstable construction would fly around my ears and the claw would tumble to the ground. I had to stabilize my claw holder somehow.";
        }
    }
    public static string Touch_Librarian_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte das Skelett mit der Klaue. Sofort ruckte es hoch und schauten mich verstört an. \"Wenn du die Abgabefrist überschritten hast, wird es teuer!\"";
            else
                return "I touched the skeleton with my claw. It immediately jerked up and looked at me distraught. \\\"If you've missed the deadline, it's going to be expensive!\"";
        }
    }
    public static string Touch_Librarian_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte das Skelett mit der Klaue. Da das Skelett schon wach war, musterte es mich nur etwas verwirrt.";
            else
                return "I touched the skeleton with my claw. As the skeleton was already awake, it just looked at me in confusion.";
        }
    }

    public static string Touch_Duck_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte das Quietscheentchen mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "I wanted to touch the squeaky duck with my claw. But I was afraid that this unstable construction would fly around my ears and the claw would tumble to the floor. I had to stabilize my claw holder somehow.";
        }
    }
    public static string Touch_Duck_StableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte das Quietscheentchen mit der Klaue. Das gelbe Ding gab einen absolut jämmerlichen Klagelaut von sich und erlosch wieder mit einem tiefen Seufzer. Was nur, was hatte dieses arme \"Tier\" erlebt?";
            else
                return "I touched the little squeaker with my claw. The yellow thing made an absolutely pathetic wailing sound and went out again with a deep sigh. What on earth had this poor \"animal\" experienced?";
        }
    }


    public static string Touch_Owl_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte [P:Person_Owl]die Eule[/P] mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "I wanted to touch [P:Person_Owl]the owl[/P] with my claw. But I was afraid that this unstable construction would fly around my ears and the claw would tumble to the ground. I had to stabilize my claw holder somehow.";
        }
    }
    public static string Touch_KnightsArmour_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte die Ritterrüstung mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "I wanted to touch the armor with my claw. But I was afraid that this unstable construction would fly around my ears and the claw would tumble to the ground. I had to stabilize my claw holder somehow.";
        }
    }
    public static string Touch_Owl_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte [P:Person_Owl]die ausgestopfte Eule[/P] mit der Klaue. Sofort öffneten sich die Augen der Eule und schauten mich verschlafen an. \"Ich hoffe, es ist wichtig.\"<br>War das eigentlich normal, dass Eulen gähnen?";
            else
                return "Ich berührte [P:Person_Owl]die ausgestopfte Eule[/P] mit der Klaue. Sofort öffneten sich die Augen der Eule und schauten mich verschlafen an. \"Ich hoffe, es ist wichtig.\"<br>War das eigentlich normal, dass Eulen gähnen?";
        }
    }
    public static string Touch_Owl_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte [P:Person_Owl]die ausgestopfte Eule[/P] mit der Klaue. Da die Eule schon wach war, musterte sie mich nur etwas verwirrt.";
            else
                return "I touched the stuffed owl[/P] with my claw. Since the owl was already awake, it just looked at me a little confused.";
        }
    }
    public static string Touch_KnightsArmour_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die Ritterrüstung mit der Klaue. Sofort klappte sich das Visier der Rüstung hoch, und dahinter erkannte ich - nichts. \"Was glotzt du so?\" schepperte es aus dem Innern. Danach begann die Ritterrüstung mit einigen extravanten Dehnübungen.";
            else
                return "I touched the armor with my claw. The visor of the armor immediately flipped up, and behind it I saw - nothing. \\\"What are you looking at?\" rattled from inside. The knight's armor then began some extravagant stretching exercises.";
        }
    }
    public static string Touch_KnightsArmour_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die Ritterrüstung mit der Klaue. \"Nicht so oft bitte\", schepperte es aus dem Innern. \"Sonst kann ich heute Nacht wieder nicht schlafen.\"";
            else
                return "I touched the armor with my claw. \"Not so often, please,\" it rattled from inside. \"Otherwise I won't be able to sleep again tonight.\"";
        }
    }


    public static string Tip_MagicPowder_MagicCandle_NoFlame
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sicher würde es cool aussehen, [I:I00_Magic_Powder]das magische Pulver[/I] auf [I:I00_Magic_Candle]die Kerze[/I] rieseln zu lassen. Aber wenn diese brannte, gäbe es doch deutlich mehr Action.";
            else
                return "Sure, it would look cool to let [I:I00_Magic_Powder]the magic powder[/I] trickle onto [I:I00_Magic_Candle]the candle[/I]. But if it was burning, there would be a lot more action.";
        }
    }
    public static string Tip_MagicPowder_Pentagramm
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hatte zwar in Meister Gunnars Unterricht selten gut aufgepasst, aber ich war mir doch einigermaßen sicher, dass solche magischen Pülverchen einer gewissen Hitzeeinwirkung bedurften, um zu wirken.";
            else
                return "I had rarely paid much attention in Master Gunnar's lessons, but I was reasonably sure that such magical powders needed a certain amount of heat to work.";
        }
    }
    public static string Tip_MagicPowder_MagicCandle_NoMagic
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sicher würde die magische Flamme das Pulver entfachen und irgendeinen Effekt erzeugen. Aber wenn nicht irgendwas die Magie kanalisierte, wie ein Pentagramm zum Beispiel, dann würde mir das alles wenig nutzen.";
            else
                return "Sure, the magical flame would ignite the powder and produce some kind of effect. But if there wasn't something channeling the magic, like a pentagram for example, then it wouldn't do me much good.";
        }
    }
    public static string Tip_SupermagicPowder_MagicCandle_NoMagic
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sicher würde die magische Flamme das Pulver entfachen und irgendeinen Effekt erzeugen. Aber wenn nicht irgendwas die Magie kanalisierte, wie ein Pentagramm zum Beispiel, dann würde mir das alles wenig nutzen. Mir fiel ein, dass sich im Atrium ein Pentagramm befand.";
            else
                return "Sure, the magical flame would ignite the powder and produce some kind of effect. But if there wasn't something channeling the magic, like a pentagram for example, then it wouldn't do me much good. I remembered that there was a pentagram in the atrium.";
        }
    }
    public static string Tip_MagicPowder_MagicCandle_Do
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stellte mich in die Mitte des Pentagramms und ließ das magische Pulver in die Flamme rieseln. Sofort ergoss sich ein riesiger Funkenregen über mich und eine Stimme flüsterte in mein Ohr: \"KABUMM!\"<br><br>Im nächsten Moment schwebte ich mitten durch eine sternklare Nacht. Unter mir endlose Schwärze, nur ein helles Rechteck leuchtete unter mir. Ich stürzte direkt darauf zu. Ich schrie und schrie.<br><br>Plötzlich öffnete sich auf meinem Rücken ein Päckchen, dessen Anwesenheit ich bisher nicht wahrgenommen hatte. Ein magischer Fallschirm entfaltete sich und bremste meinen Sturz. Sacht sank ich auf das helle Rechteck zu und landete schließlich sanft auf meinen Füßen. Im selben Moment verschwand der magische Fallschirm. Ich war angekommen im Versteck des Meisters! Jetzt musste ich nur noch die Klaue einstecken und schauen, dass ich so schnell wie möglich wegkam.<br><br>";
            else
                return "I stood in the center of the pentagram and let the magic powder trickle into the flame. Immediately a huge shower of sparks poured over me and a voice whispered in my ear: \"KABOOM!\"<br><br>The next moment I was floating through the middle of a starry night. Below me was endless blackness, only a bright rectangle shone below me. I rushed straight towards it. I screamed and screamed.<br><br>Suddenly, a small package opened on my back, the presence of which I had not noticed before. A magical parachute unfolded and slowed my fall. I sank gently towards the bright rectangle and finally landed softly on my feet. At the same moment, the magic parachute disappeared. I had arrived at the master's hiding place! Now I just had to put the claw away and make sure I got away as quickly as possible.<br><br>";

        }
    }
    public static string Tip_SupermagicPowder_MagicCandle_Do
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stellte mich in die Mitte des Pentagramms und ließ das magische Pulver in die Flamme rieseln. Sofort ergoss sich ein riesiger Funkenregen über mich und eine Stimme flüsterte in mein Ohr: \"KABUMM!\"<br><br>Im nächsten Moment stand ich in einem anderen Raum. Wo war ich? Alles war dunkel.<br>Und plötzlich öffneten sich nicht weit entfernt von mir zwei glutrot leuchtende Augen.";
            else
                return "I stood in the middle of the pentagram and let the magic powder trickle into the flame. Immediately, a huge shower of sparks poured over me and a voice whispered in my ear: : \"KABOOM!\"<br><br>The next moment I was standing in another room. Where was I? Everything was dark.<br>And suddenly, not far from me, two glowing red eyes opened.";
        }
    }
    public static string UseW_SugarPliers_Claw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hob die Klaue mit der Zuckerzange an und nahm sie an mich. Da die Klaue groß genug war, blieb sie zwar in der Zange stecken, aber [I:I00_Unstable_Pliers_With_Claw]das ganze Gebilde[/I] war höchst instabil. Ich musste es fixieren, wenn ich es länger mit mir herumtragen wollte.";
            else
                return "I lifted the claw with the sugar tongs and took it. As the claw was big enough, it stayed in the tongs, but [I:I00_Unstable_Pliers_With_Claw]the whole thing[/I] was very unstable. I had to fix it in place if I wanted to carry it around with me for any length of time.";
        }
    }
    public static string UseW_Plunger_Slag
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich zerstößelte die Schlacke und erhielt [I:I00_Supermagic_Powder]ein feines Pulver[/I]. Sehr schön, mein Ticket nach Hause war mir sicher.";
            else
                return "I crushed the slag and received [I:I00_Supermagic_Powder]a fine powder[/I]. Very nice, my ticket home was safe.";
        }
    }
    public static string UseW_Plunger_Slag_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Um [I:I00_Slag]die Schlacke[/I] zu zerstößeln, sollte ich sie erst mal in einen geeigneten Behälter legen.";
            else
                return "To [I:I00_Slag]crush the slag[/I], I should first place it in a suitable container.";
        }
    }
    public static string UseW_Pentagram_Powder
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das magische Pulver einfach aufs Pentagramm streuen? Ha, so einfach wars dann doch nicht! Ein wenig Hitzeentwicklung war sicherlich förderlich.";
            else
                return "Just sprinkle the magic powder on the pentagram? Ha, it wasn't that easy after all! A little heat development was certainly helpful.";
        }
    }
 
    public static string Wrap_Rollpflaster_Pliers_Ok
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich klebte einen langen Klebestreifen um die Zuckerzange mit der Klaue darin. Der Klebestreifen hielt die Zuckerzange so fest zusammen, dass die Klaue sicher befestgt war.<br>Das Rollpflaster war alle, also warf ich die leere Rolle weg.<br><br>Perfekt, ich hatte also [I:I00_Stable_Pliers_With_Claw]die Klaue[/I] an mich genommen. Wie aber kam ich jetzt aus diesem seltsamen Domizil wieder heraus? Einen Ausgang hatte ich bisher nicht gefunden. Dafür gab es ja sicherlich auch einen Grund.";
            else
                return "I stuck a long strip of adhesive tape around the sugar tongs with the claw inside. The adhesive strip held the sugar tongs together so tightly that the claw was securely fixed.<br>I had run out of plaster, so I threw the empty roll away.<br><br>Perfect, so I had [I:I00_Stable_Pliers_With_Claw]taken the claw[/I]. But how did I get out of this strange domicile? I hadn't found an exit yet. There was certainly a reason for that.";
        }
    }
    public static string Wipe_KnightsArmor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wischte ein wenig an [P:Person_Knights_Armor]der Rüstung[/P] herum. Sonderlich viel Effekt hatte das nicht, also ließ ich es.";
            else
                return "I wiped a little at [P:Person_Knights_Armor]the armor[/P]. It didn't have much effect, so I left it alone.";
        }
    }
    public static string Examine_Behind_Cupboard
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es war zu dunkel, um viel zu erkennen. Aber zeichneten sich an der Wand hinter [I:I04_Cupboard]dem Schrank[/I] nicht die Konturen eines Rechtecks ab? ";
            else
                return "It was too dark to see much. But couldn't the outline of a rectangle be seen on the wall behind [I:I04_Cupboard]the cupboard[/I]? ";
        }
    }
    public static string Examine_Behind_Cupboard2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hinter [I:I04_Cupboard]dem abgerückten Schrank[/I] war [I:I04_Flap]eine Klappe[/I] in der Wand zu sehen.";
            else
                return "Behind [I:I04_Cupboard]the removed cupboard[/I] was [I:I04_Flap]a flap[/I] in the wall.";
        }
    }
    public static string Examine_In_Opening
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich schaute in [I:I14_Opening]die dunkle Öffnung[/I]. [I:I00_Key]Ein verzierter Schlüssel[/I] kam zum Vorschein.";
            else
                return "I looked into [I:I14_Opening]the dark opening[/I]. [I:I00_Key]An ornate key[/I] appeared.";
        }
    }
    public static string Unlock_Labor_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich steckte [I:I00_Key]den Schlüssel[/I] in das Schloss [I:I07_Door]der Tür zum Labor[/I]. Die Tür ließ sich ohne Probleme aufschließen.";
            else
                return "I inserted [I:I00_Key]the key[/I] into the lock [I:I07_Door]of the door to the lab[/I]. The door unlocked without any problems.";
        }
    }
    public static string Unlock_Library_Door_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich versuchte [I:I00_Key]den verzierten Schlüssel[/I] in [I:I05_Library_Door]die verzierte Tür[/I] der Bibliothek zu stecken, aber leider hörten die Gemeinsamkeiten bei den Verzierungen auf. Der Schlüssel passte nicht.";
            else
                return "I tried to insert [I:I00_Key]the ornate key[/I] into [I:I05_Library_Door]the ornate door[/I] of the library, but unfortunately the similarities stopped at the ornaments. The key did not fit.";
        }
    }
    public static string Unlock_Labor_Door_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich steckte [I:I00_Key]den Schlüssel[/I] in das Schloss [I:I07_Door]der Tür zum Labor[/I]. Die Tür ließ sich aber nicht aufschließen, da sie schon aufgeschlossen war.";
            else
                return "I put [I:I00_Key]the key[/I] into the lock [I:I07_Door]of the door to the lab[/I]. But the door couldn't be unlocked because it was already unlocked.";
        }
    }
    public static string Take_Claw_Sign
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Gierig griff ich nach [I:I00_Claw]der Klaue[/I]. Mein, endlich war sie mein!<br>Aus den Augenwinkeln heraus nahm ich das am Podest befindliche [I:I05_Sign]Warnschild[/I] wahr und hielt erst mal inne.";
            else
                return "I greedily reached for [I:I00_Claw]the claw[/I]. Mine, finally she was mine!<br>Out of the corner of my eye, I noticed the [I:I05_Sign]warning sign[/I] on the pedestal and paused for a moment.";
        }
    }
    public static string Talk_Owl_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Owl]Die Eule[/P] starrte mich aus toten Augen an. Irgendwelche geistreichen Antworten waren wohl von ihr auch nicht zu erwarten.";
            else
                return "[P:Person_Owl]The owl[/P] stared at me out of dead eyes. Any witty answers were probably not to be expected from her either.";
        }
    }
    public static string Talk_Skeleton_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Librarian]Das Bibliothekarsskelett[/P] schaute mich strafend, aber wortlos an. Plötzlich fielen mir die Bücher meiner Kindheit ein, die ich zu spät zurückgebracht hatte.";
            else
                return "[P:Person_Owl]The owl[/P] stared at me out of dead eyes. Any witty answers were probably not to be expected from her either.";
        }
    }
    public static string Talk_Magpie_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Magpie]Die Elster[/P] starrte mich aus toten Augen an. Ein bisschen mehr Mühe könnte sie sich ja schon geben, fand ich.";
            else
                return "[P:Person_Magpie]The magpie[/P] stared at me out of dead eyes. She could try a little harder, I thought.";
        }
    }
    public static string Talk_Parrot_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Parrot]Der Papagei[/P] starrte mich aus toten Augen an. Ich versuchte, ebenso tot zurück zu starren. Blödes Vieh.";
            else
                return "[P:Person_Parrot]The parrot[/P] stared at me from dead eyes. I tried to stare back just as dead. Stupid critter.";
        }
    }
    public static string Talk_Snake_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Snake]Die Schlange[/P] zeigte wenig Gesprächsbereitschaft. Ob das daran lag, dass sie tot und ausgestopft war?";
            else
                return "[P:Person_Snake]The snake[/P] showed little willingness to talk. Was it because it was dead and stuffed?";
        }
    }
    public static string Talk_Fish_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Fish]Der Fisch[/P] schwieg. Ob das daran lag, dass er tot und ausgestopft war?";
            else
                return "[P:Person_Fish]The fish[/P] remained silent. Was it because it was dead and stuffed?";
        }
    }
    public static string Talk_Knights_Armor_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[P:Person_Knights_Armor]Die Ritterrüstung[/P] sagte keinen Piep. Irgendwie war das auch gut so.";
            else
                return "[P:Person_Knights_Armor]The knight's armor[/P] didn't say a peep. Somehow that was a good thing.";
        }
    }

    public static string Close_L04_Flap
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I04_Flap]Die Klappe[/I] schob sich wieder vor [I:I04_Opening]die Öffnung[/P].";
            else
                return "[I:I04_Flap]The flap[/I] slid in front of [I:I04_Opening]the opening[/P] again.";
        }
    }
    public static string Open_Knights_Armor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich öffnete das Visier der Rüstung und schaute hinein. Wie erwartet, war die Rüstung leer. Zum Glück. Ich ließ das Visier wieder herunter.";
            else
                return "I opened the visor of the armor and looked inside. As expected, the armor was empty. Fortunately. I lowered the visor again.";
        }
    }
    
    public static string Open_L04_Flap
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hinter [I:I04_Flap]der Klappe[/I] kam [I:I04_Opening]eine dunkle Öffnung[/I] zum Vorschein.";
            else
                return "Behind [I:I04_Flap]the flap[/I], [I:I04_Opening]a dark opening[/I] appeared.";
        }
    }
    public static string Open_L10_Flap
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I10_Hatch]Unter der Klappe[/I] kam [I:I10_Opening]eine dunkle Öffnung[/I] zum Vorschein.";
            else
                return "[I:I10_Hatch]A dark opening[/I] appeared under the flap[/I].";
        }
    }
    public static string Press_Switch_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I10_Switch]Der Schalter[/I] ließ sich nicht betätigen. Vielleicht lag es daran, dass [I:I10_Hatch]die Klappe[/I] offen war?";
            else
                return "[I:I10_Switch]The switch[/I] could not be operated. Maybe it was because [I:I10_Hatch]the flap[/I] was open?";
        }
    }
    public static string Press_Switch_Nothing_Happens
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich betätigte [I:I10_Switch]den Schalter[/I]. Sofort begann [I:I10_Darkness_Machine]die Dunkelheitsmaschine[/I] damit, ein einlullendes Summen zu verbreiten. Sonst passiert leider weiter gar nichts.";
            else
                return "I pressed [I:I10_Switch]the switch[/I]. Immediately [I:I10_Darkness_Machine]the darkness machine[/I] began to emit a lulling hum. Unfortunately, nothing else happens.";
        }
    }
    public static string Press_Switch_Saug
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich betätigte den Schalter. Sofort begann die Dunkelheitsmaschine damit, ein einlullendes Summen zu verbreiten. Gleichzeitig drang helles Licht um die Ritzen der Klappe. Ob das wohl von dem Licht stammte, dass aus dem Stein herausgezogen worden war?";
            else
                return "I pressed the switch. The darkness machine immediately began to emit a lulling hum. At the same time, bright light penetrated around the cracks in the flap. I wonder if it was from the light that had been pulled out of the stone.";
        }
    }
    public static string Examine_Under_Doormat
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Unter [I:I02_Doormat]der Fußmatte[/I] entdeckte ich [I:I00_Pouch]ein kleines Beutelchen[/I].";
            else
                return "Under [I:I02_Doormat]the doormat[/I] I discovered [I:I00_Pouch]a small pouch[/I].";
        }
    }
    public static string Push_L04_Cupboard
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich rückte [I:I04_Cupboard]den Schrank[/I] ein Stück von der Wand ab. Dahinter kam [I:I04_Flap]eine kleine Klappe[/I] zum Vorschein.";
            else
                return "I moved [I:I04_Cupboard]the cupboard[/I] a little away from the wall. Behind it, [I:I04_Flap]a small flap[/I] appeared.";
        }
    }
    public static string Push_L08_Wooden_Cover
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich schob [I:I08_Wooden_Cover]die Holzabdeckung[/I] vom [I:I08_Well]Brunnen[/I] weg. Darunter blickte ich [I:I08_Water]in tiefes dunkles Wasser[/I].";
            else
                return "I pushed [I:I08_Wooden_Cover]the wooden cover[/I] away from the [I:I08_Well]well[/I]. Underneath, I looked [I:I08_Water]into deep dark water[/I].";
        }
    }
    public static string Examine_Well2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I08_Well]Im Brunnen[/I] schimmerte [I:I08_Water]das dunkle, tiefe Wasser[/I].";
            else
                return "[I:I08_Well]In the well[/I] shimmered [I:I08_Water]the dark, deep water[/I].";
        }
    }
    public static string Push_Mist
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich versuche, [I:I01_Mist]den Nebel[/I] mit meinen Händen wegzuschieben. Erschreckenderweise griffen die Hände einfach durch die Schwaden hindurch.";
            else
                return "I try to push [I:I01_Mist]the fog[/I] away with my hands. Frighteningly, my hands simply reached through the swathes.";
        }
    }
    public static string Climb_Tree_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Stamm des Baumes war vom Nebel viel zu nass. Meine Hände rutschen ab, zumal es keine tief hängenden Äste gab, an denen man sich hätte gut festhalten können. Überhaupt: Was wollte ich da oben?";
            else
                return "The trunk of the tree was far too wet from the fog. My hands slipped, especially as there were no low-hanging branches to hold on to. What was I doing up there in the first place?";
        }
    }
    public static string Open_Library_Door_Locked
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I05_Library_Door]Die Tür zur Bibliothek[/I] war verschlossen.";
            else
                return "[I:I05_Library_Door]The door to the library[/I] was locked.";
        }
    }
    public static string Open_Sleepingroom_Door_Locked
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I06_Door]Die breite Tür[/I] in der südlichen Wand war verriegelt und verrammelt.";
            else
                return "[I:I06_Door]The wide door[/I] in the southern wall was locked and barred.";
        }
    }
    public static string Open_Laboratory_Door_Locked
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I07_Door]Die massive Tür, auf der groß und breit \"Labor\" stand, war fest verriegelt.";
            else
                return "[I:I07_Door]The massive door, which read \"Labor\" in large letters, was firmly locked.";
        }
    }
    public static string Order_SetupDialog_10144
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<br>********<br>Wie möchtest du diese \"Interactive Fiction\" spielen?";
            else
                return "<br>********<br>How would you like to play this \"interactive fiction\"?";
        }
    }
    public static string Order_SetupDialog_10144a
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie möchtest du diese \"Interactive Fiction\" spielen?";
            else
                return "How would you like to play this \"interactive fiction\"?";
        }
    }
    public static string Order_SetupDialog_Person_Self_10145
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "So simpel wie möglich per Multiple Choice";
            else
                return "As simple as possible via multiple choice";
        }
    }
    public static string Order_SetupDialog_Person_Self_10146
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Multiple Choice, aber die ganze Bandbreite";
            else
                return "Multiple choice, but the whole range";
        }
    }
    public static string Order_SetupDialog_Person_Self_10147
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich bin Profi, ich tippe meine Eingaben";
            else
                return "I am a professional, I type my inputs";
        }
    }
    public static string Order_SetupDialog_Person_Self_10148
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was ist Interactive Fiction?";
            else
                return "What is Interactive Fiction?";
        }
    }
    public static string Order_SetupDialog_Person_Self_10149
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Welche Auswirkungen hat meine Entscheidung?";
            else
                return "What are the implications of my decision?";
        }
    }
    public static string Order_SetupDialog_Person_Self_10150
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du hältst hier einen interaktiven Roman in den Händen, der erst durch deine Eingaben vorangetrieben wird.<br>Rede mit Personen, durchsuche die Räume, interagiere mit Gegenständen - und schon geht die Story voran. Wenn du nicht vertraut bist mit Interactive Fiction, probiere die Multiple Choice Eingaben aus, dann siehst du sehr schnell, wie du die Story vorantreibst. Ob du tippst oder Entscheidungen per Multiple Choice triffst, ist übrigens für die Story nicht wichtig.";
            else
                return "You are holding an interactive novel in your hands, which is driven forward by your input.<br>Talk to people, search the rooms, interact with objects - and the story moves forward. If you're not familiar with interactive fiction, try the multiple choice inputs and you'll see very quickly how you move the story forward. Whether you type or make multiple choice decisions is not important to the story, by the way.";
        }
    }
    public static string Order_SetupDialog_Person_Self_10151
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Deine Entscheidung beeinflusst lediglich ein paar Voreinstellungen im Spiel. Grob gesagt gibt es 3 Modi:<br>Einfaches Multiple Choice - nur die nötigsten Optionen zur Auswahl<br>Umfangreiches Multiple Choice - umfassendere Spieloptionen<br>Texteingabe - alle Aktionen werden als direkte Befehle eingegeben.<br>Dialoge und viele Spielentscheidungen sind übrigens immer Multiple Choice. Die drei Modi sind unterschiedlich schwer, aber die Story bleibt gleich und du kannst jederzeit über das Spielmenü das Spiel umkonfigurieren. Für echte Interactive Fiction Neulinge sei das vereinfachte Multiple Choice empfohlen. Wichtig übrigens: Auch hier könnt ihr Befehle tippen, wenn Multiple Choice mal nicht die richtigen Optionen bietet.";
            else
                return "Your decision only affects a few preferences in the game. Roughly speaking, there are 3 modes:<br>Simple multiple choice - only the most necessary options to choose from<br>Extensive multiple choice - more extensive game options<br>Text input - all actions are entered as direct commands.<br>Dialogues and many game decisions are always multiple choice, by the way. The three modes vary in difficulty, but the story remains the same and you can reconfigure the game at any time via the game menu. For true Interactive Fiction newbies, the simplified Multiple Choice is recommended. Important by the way: You can also type commands here if Multiple Choice doesn't offer the right options.";
        }
    }
    public static string Order_SetupDialog_Person_Self_10152
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ok, einfaches Multiple Choice wird konfiguriert.";
            else
                return "Ok, simple multiple choice is configured.";
        }
    }
    public static string Order_SetupDialog_Person_Self_10153
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ok, umfassendes Multiple Choice wird konfiguriert.";
            else
                return "Ok, comprehensive multiple choice is configured.";
        }
    }
    public static string Order_SetupDialog_Person_Self_10154
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Multiple Choice Menüs werden ausgeblendet.";
            else
                return "Multiple choice menus are hidden.";
        }
    }
    public static string Adv_Intro0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>";
            else
                return "<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>";
        }
    }
    public static string Adv_Intro1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<br>*** Das Versteck des Meisters ***<br><br><br>Eine Art Exitgame<br/><br/><br/><br/>Version {0} vom {1}<br/><br/>Ein Spiel von Stefan Hoffmann<br/><br/>";
            else
                return "<br>*** The Master's Lair ***<br><br><br>A kind of escape game<br/><br/><br/><br/>Version {0} from {1}<br/><br/>A game by Stefan Hoffmann<br/><br/>";
        }
    }
    public static string Adv_Intro2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Seit Stunden stapfte ich durch dieses neblige Gehölz und verlor so langsam die Geduld. Noch immer kochte in mir die Wut! Was bildete sich dieser Mistkerl eigentlich ein?<br>Meister Gunnar hatte uns Studenten gestern verkündet, dass er mit einer erlesenen Schar seiner Anbeter im Gefolge ins Land Polonistan reisen würde, um sich dort in den hohen magischen Giftkünsten zu schulen. Natürlich konnte ich mein vorlautes Maul nicht halten und musste ihn fragen, ob ich auch mitkommen dürfe.<br>Er musterte mich von oben bis unten, dann brach er in Lachen aus.<br>In dem Moment zerbrach etwas in mir. Ich beschloss, meine unnützen Studien bei Meister Gunnar zu beenden. Ich würde es ihm heimzahlen und ihm das Wertvollste nehmen, was er besaß. Er würde den Tag noch verfluchten, an dem er mich so vor den Kopf geschlagen hatte.";
            else
                return "I had been trudging through this foggy grove for hours and was slowly losing my patience. My anger was still boiling inside me! What did this bastard think he was doing?<br>Master Gunnar had announced to us students yesterday that he would be traveling to the land of Polonistan with a select band of his worshippers in his wake to train in the high magical arts of poison. Of course, I couldn't keep my cheeky mouth shut and had to ask him if I could come too.<br>He looked me up and down, then burst out laughing.<br>At that moment, something inside me broke. I decided to end my useless studies with Master Gunnar. I would get back at him and take away the most valuable thing he had. He would curse the day he had beaten me over the head like that.";
        }
    }
    public static string Adv_Intro3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es war ja richtig: Ich war gewiss nicht sein gelehrigster Schüler. Und wenn sich bei mir irgendwo ein Talent gezeigt hätte, dann im Abschreiben, Ausleihen und nicht zurückbringen, oder auch schlicht im Stehlen. Ich hatte durchaus ein großes Interesse an Reichtümern aller Art, also auch jenen, die Meister Gunnar, wie man hörte, in seiner gut verborgenen Hütte im Wald versteckte. Darunter sogar die berühmte Klaue, das wohl wertvollste magische Juwel der Welt. Und jetzt, wo der Meister auf und davon war, konnte er mich nicht daran hindern, diesen Schatz an mich zu bringen. Ich hatte nicht nur meine Rache, sondern wurde auch noch steinreich!";
            else
                return "It was true: I was certainly not his most studious pupil. And if I had shown any talent, it was in copying, borrowing and not returning, or simply stealing. I had a great interest in riches of all kinds, including those that Master Gunnar was rumored to have hidden in his well-hidden hut in the forest. Among them was even the famous claw, probably the most valuable magical jewel in the world. And now that the master was off and running, he couldn't stop me from getting my hands on this treasure. Not only did I get my revenge, I also became filthy rich!";
        }
    }
    public static string Adv_Intro4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mein Studium der Magie war ohnehin verloren. Immerhin, mit der Klaue im Gepäck würde mich die Diebesgilde mit Handkuss nehmen. Jetzt musste ich nur noch den Weg zur Hütte finden in diesem verdammten Nebel!<br/><br/>";
            else
                return "My studies in magic were lost anyway. With the claw in my luggage, the thieves' guild would finally kiss my ass. Now I just had to find my way to the hat in this damn fog!<br/><br/>";
        }
    }

    public static string Order_ExamineThrough_IX_03_Spiegel_280
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Durch [Il1,Nom] konnte ich nicht schauen.";
            else
                return "I couldn't see through [Il1,Nom].";
        }
    }


    public static string Order_LayDown_Person_I_423
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich überlegte, mich hinzulegen. Aber so müde war ich dann doch nicht.";
            else
                return "I thought about lying down. But then I was not that tired.";
        }
    }
    public static string Order_ExamineOut_I1_08_Fenster_283
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus [Il1,Nom] konnte ich nicht herausschauen.";
            else
                return "I could not see out of [Il1,Nom].";
        }
    }

    public static string Adj_blau
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blau";
            else
                return "blue";
        }
    }
    public static string Adj_gekachelt
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "gekachelt";
            else
                return "tiled";
        }
    }
    public static string Adj_gruen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "grün";
            else
                return "green";
        }
    }
    public static string Adj_stattlich
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "stattlich";
            else
                return "stately";
        }
    }
    public static string Adj_ausgestopft
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "ausgestopft";
            else
                return "stuffed";
        }
    }
    public static string Adj_magisch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "magisch";
            else
                return "_magic";
        }
    }
    public static string Adj_instabil
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "instabil";
            else
                return "unstable";
        }
    }
    public static string Adj_beschrieben
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "beschrieben";
            else
                return "written";
        }
    }
    public static string Adj_peinlich
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "peinlich";
            else
                return "embarrassing";
        }
    }
    public static string Adj_vertrocknet
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "vertrocknet";
            else
                return "withered";
        }
    }
    public static string Adj_lichtlos
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "lichtlos";
            else
                return "lightless";
        }
    }
    public static string Adj_gekuehlt
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "gekühlt";
            else
                return "cooled";
        }
    }
    public static string Adj_schimmernd
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "schimmernd";
            else
                return "shimmering";
        }
    }
    public static string Adj_neblig
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "neblig";
            else
                return "foggy";
        }
    }
    public static string Adj_mueffelnd
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "müffelnd";
            else
                return "smelly";
        }
    }
    public static string Adj_hasserfuellt
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "hasserfüllt";
            else
                return "hasserfüllt";
        }
    }
    public static string Adj_verrueckt
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "verrückt";
            else
                return "_crazy";
        }
    }
    public static string Adj_sinister
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "sinistr";
            else
                return "sinister";
        }
    }
    public static string Adj_besonders
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "besonder";
            else
                return "special";
        }
    }
    public static string Noun_Versteck
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Versteck";
            else
                return "lair";
        }
    }
    public static string Noun_Fliese
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Fliese";
            else
                return "tile";
        }
    }
    public static string Noun_Fliesen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Fliesen";
            else
                return "_tiles";
        }
    }
    public static string Noun_Krempel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Krempel";
            else
                return "clutter";
        }
    }
    public static string Noun_Edelstein
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Edelstein";
            else
                return "gem";
        }
    }
    public static string Noun_Kuechenschrank
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Küchenschrank";
            else
                return "cupboard";
        }
    }
    public static string Noun_Juwel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Juwel";
            else
                return "jewel";
        }
    }
    public static string Noun_Stand
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Stand";
            else
                return "___Stand";
        }
    }
    public static string Noun_Waschbecken
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Waschbecken";
            else
                return "sink";
        }
    }
    public static string Noun_Flamme
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Flamme";
            else
                return "flame";
        }
    }
    public static string Noun_Rune
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Rune";
            else
                return "rune";
        }
    }
    public static string Noun_Warnschild
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Warnschild";
            else
                return "warning";
        }
    }
    public static string Noun_Wasch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wasch";
            else
                return "wash";
        }
    }
    public static string Noun_Gefrier
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Gefrier";
            else
                return "freeze";
        }
    }
    public static string Noun_Froster
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Froster";
            else
                return "_freezer";
        }
    }
    public static string Noun_Ente
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ente";
            else
                return "duck";
        }
    }
    public static string Noun_Entchen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Entchen";
            else
                return "duckling";
        }
    }
    public static string Noun_Gummiente
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Gummiente";
            else
                return "rubber";
        }
    }
    public static string Noun_Abdeckung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Abdeckung";
            else
                return "cover";
        }
    }
    public static string Noun_Deckel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Deckel";
            else
                return "____cover";
        }
    }
    public static string Noun_Verbandskasten
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Verbandskasten";
            else
                return "First-Aid";
        }
    }
    public static string Noun_Kit
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "kit";
            else
                return "kit";
        }
    }
    public static string Noun_Plastik
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Plastik";
            else
                return "plastic";
        }
    }
    public static string Noun_Pilz
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Pilz";
            else
                return "fungus";
        }
    }
    public static string Noun_Funghi
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Funghi";
            else
                return "Funghi";
        }
    }
    public static string Noun_Sporen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sporen";
            else
                return "spores";
        }
    }
    public static string Noun_Schwamm
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Schwamm";
            else
                return "sponge";
        }
    }
    public static string Noun_Rolle
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Rolle";
            else
                return "roll";
        }
    }
    public static string Noun_Buchstaben
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Buchstaben";
            else
                return "_letters";
        }
    }
    public static string Noun_Beutel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Beutel";
            else
                return "bag";
        }
    }
    public static string Noun_Kerze
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Kerze";
            else
                return "candle";
        }
    }
    public static string Noun_Halter
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Halter";
            else
                return "bracket";
        }
    }
    public static string Noun_Matte
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Matte";
            else
                return "mat";
        }
    }

    public static string Noun_Ritterruestung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ritterrüstung";
            else
                return "armor";
        }
    }
    public static string Noun_Ritter
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ritter";
            else
                return "knight";
        }
    }
    public static string Noun_Ruestung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Rüstung";
            else
                return "armnor";
        }
    }
    public static string Noun_Eule
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eule";
            else
                return "owl";
        }
    }
    public static string Noun_Skelett
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Skelett";
            else
                return "skeleton";
        }
    }
    public static string Noun_Fish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Fisch";
            else
                return "fish";
        }
    }
    public static string Noun_Schlange
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Schlange";
            else
                return "snake";
        }
    }

    public static string Noun_Elster
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Elster";
            else
                return "magpie";
        }
    }
    public static string Noun_Beutelchen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Beutelchen";
            else
                return "_bag";
        }
    }
    public static string Noun_Pulver
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Pulver";
            else
                return "powder";
        }
    }
    public static string Noun_Kerzenhalter
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Kerzenhalter";
            else
                return "candleholder";
        }
    }
    public static string Noun_Klaue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Klaue";
            else
                return "claw";
        }
    }
    public static string Noun_Zuckerzange
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Zuckerzange";
            else
                return "_sugar";
        }
    }
    public static string Noun_Rollpflaster
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Rollpflaster";
            else
                return "rolling";
        }
    }
    public static string Noun_Klauenzange
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Klauenzange";
            else
                return "_claw";
        }
    }
    public static string Noun_Lupe
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Lupe";
            else
                return "magnifier";
        }
    }
    public static string Noun_Quietscheentchen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Quietscheentchen";
            else
                return "squeaky";
        }
    }
    public static string Noun_Kaese
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Käse";
            else
                return "cheese";
        }
    }
    public static string Noun_Mondstein
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mondstein";
            else
                return "moon stone";
        }
    }
    public static string Noun_Mond
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mond";
            else
                return "moon";
        }
    }
    public static string Noun_Plastikbeutel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Plastikbeutel";
            else
                return "plastic bag";
        }
    }
    public static string Noun_Plastiktuete
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Plastiktüte";
            else
                return "_plastic bag";
        }
    }
    public static string Noun_Wunderwarzenschwamm
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wunderwarzenschwamm";
            else
                return "wonder";
        }
    }
    public static string Noun_Schlacke
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Schlacke";
            else
                return "slag";
        }
    }
    public static string Noun_Muenze
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Münze";
            else
                return "coin";
        }
    }
    public static string Noun_Nebel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nebel";
            else
                return "mist";
        }
    }
    public static string Noun_Fussmatte
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Fußmatte";
            else
                return "doormat";
        }
    }
    public static string Noun_Pentagramm
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Pentagramm";
            else
                return "pentagram";
        }
    }
    public static string Noun_Oeffnung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Öffnung";
            else
                return "opening";
        }
    }
    public static string Noun_Siegel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Siegel";
            else
                return "seal";
        }
    }
    public static string Noun_Waescheleine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wäscheleine";
            else
                return "clothesline";
        }
    }
    public static string Noun_Unterhose
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Unterhose";
            else
                return "underpants";
        }
    }
    public static string Noun_Unterwaesche
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Unterwäsche";
            else
                return "underwear";
        }
    }
    public static string Noun_Holzabdeckung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Holzabdeckung";
            else
                return "_wooden cover";
        }
    }
    public static string Noun_Waschmaschine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Waschmaschine";
            else
                return "_washing machine";
        }
    }
    public static string Noun_Waescheaufhaengmaschine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wäscheaufhängmaschine";
            else
                return "_Laundry hanging machine";
        }
    }
    public static string Noun_Waeschekorb
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wäschekorb";
            else
                return "_laundry basket";
        }
    }
    public static string Noun_Karton
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Karton";
            else
                return "carton";
        }
    }
    public static string Noun_Labortisch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Labortisch";
            else
                return "_bench";
        }
    }
    public static string Noun_Kaefige
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Käfige";
            else
                return "cages";
        }
    }
    public static string Noun_Erstehilfekasten
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Erste-Hilfe-Kasten";
            else
                return "_First_Aid_Kit";
        }
    }
    public static string Noun_Halterung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Halterung";
            else
                return "_bracket";
        }
    }
    public static string Noun_Metallschale
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Metallschale";
            else
                return "_metal tray";
        }
    }
    public static string Noun_Dunkelheitsmaschine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Dunkelheitsmaschine";
            else
                return "darknessmachine";
        }
    }
    public static string Noun_Vogelstaender
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Vogelständer";
            else
                return "birdstand";
        }
    }
    public static string Noun_Matratze
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Matratze";
            else
                return "matress";
        }
    }
    public static string Noun_Kuehlschrank
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Kühlschrank";
            else
                return "fridge";
        }
    }
    public static string Noun_Gefrierfach
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Gefrierfach";
            else
                return "freezer";
        }
    }
    public static string Noun_Kachel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Kachel";
            else
                return "_tile";
        }
    }
    public static string Noun_Badewanne
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Badewanne";
            else
                return "bathtub";
        }
    }
    public static string Noun_Toilette
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Toilette";
            else
                return "toilet";
        }
    }
    public static string Noun_Spuelung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Spülung";
            else
                return "flushing";
        }
    }

    public static string Adv_L01_Dark_Forest
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein dunkler Wald";
            else
                return "A dark forest";
        }
    }
    public static string Adv_L01_Dark_Forest_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich streifte durch einen [I:I01_Forest]nebligen Wald[/I]. Längst war die Nacht herein gebrochen, und ich sah kaum die Hand vor Augen. Das einzige Licht, das es gab, kam von [I:I01_Mist]den Nebelschwaden[/I], die vom hellen Vollmondlicht erleuchtet wurden. Die Silhouetten [I:I01_Trees]der knorrigen Bäume[/I] waberten im sachten Wind auf mich zu und griffen nach mir. Die mit  [I:I01_Forest_Grass]dichtem Waldgras[/I] bewachsenen Wege führten [L:L02_In_Front_Of_A_Hut]in alle Richtungen[/L].";
            else
                return "I was wandering through a [I:I01_Forest]misty forest[/I]. Night had long since fallen and I could barely see my hand in front of my eyes. The only light there was came from [I:I01_Mist]the wisps of mist[/I], illuminated by the bright light of the full moon. The silhouettes of [I:I01_Trees]the gnarled trees[/I] wafted towards me in the gentle wind, reaching out for me. The paths overgrown with [I:I01_Forest_Grass]thick forest grass[/I] led [L:L02_In_Front_Of_A_Hut]in all directions[/L].\r\n\r\nTranslated with DeepL.com (free version)";
        }
    }

    public static string Adv_L02_In_Front_Of_A_Hut
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Vor einer Hütte";
            else
                return "In front of a hut";
        }
    }
    public static string Adv_L02_In_Front_Of_A_Hut_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand vor [I:I02_Shed]einer verfallenen Hütte[/I] im [I:I02_Forest]Wald[/I]. Eigentlich sah ich wenig mehr als die Silhouette [I:I02_Shed]eines niedrigen Gebäudes[/I], das sich [I:I02_Mist]aus dem dichten Nebel[/I] hervorhob.<br>Das sollte das edle Domizil von Meister Gunnar sein? Schwer zu glauben, dass er sein fettes Uni-Salär nicht für etwas besseres hätte aufwenden können, eine schicke Stadtvilla zum Beispiel. Also gut, er wohnte wohl freiwillig in dieser Bruchbude. Ganz sicher hatte diese Immobilie noch ein Geheimnis, das sie preiszugeben hatte.<br>[I:I02_Shed]Die Hütte[/I] war aus grobem Stein gemauert und hatte [I:I02_Door]eine solide Eingangstür[/I]. Dass davor ordentlich drapiert [I:I02_Doormat]eine Fußmatte[/I] lag, verbesserte den Gesamteindruck nicht wesentlich. [L:L03_In_The_Parlor]Der Eingang zur Hütte lag nördlich[/L]. [L:L01_Dark_Forest]Alle anderen Wege führten zurück in den Wald[/L].";
            else
                return "I was standing in front of [I:I02_Shed]a dilapidated hut[/I] in the [I:I02_Forest]forest[/I]. Actually, I saw little more than the silhouette [I:I02_Shed]of a low building[/I] that stood out [I:I02_Mist]from the dense fog[/I].<br>This was supposed to be the noble residence of Master Gunnar? It's hard to believe that he couldn't have spent his fat university salary on something better, a chic city villa for example. All right, he probably lived in this dump of his own free will. Surely this property still had a secret to reveal.<br>[I:I02_Shed]The hut[/I] was made of rough stone and had [I:I02_Door]a solid entrance door[/I]. The fact that there was a neatly draped [I:I02_Doormat]doormat[/I] in front of it didn't improve the overall impression much. [L:L03_In_The_Parlor]The entrance to the hut was to the north[/L]. [L:L01_Dark_Forest]All other paths led back into the forest[/L].";
        }
    }
    public static string Adv_L02_In_Front_Of_A_Hut_Lang2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand vor [I:I02_Shed]einer verfallenen Hütte[/I] im [I:I02_Forest]Wald[/I]. Eigentlich sah ich wenig mehr als die Silhouette [I:I02_Shed]eines niedrigen Gebäudes[/I], das sich [I:I02_Mist]aus dem dichten Nebel[/I] hervorhob.<br>Wie das edle Domizil eines Meistermagiers wirkte die ranzige Bude eher nicht. Aber sicher hatte diese Immobilie noch ein Geheimnis, das sie preiszugeben hatte.<br>[I:I02_Shed]Die Hütte[/I] war aus grobem Stein gemauert und hatte [I:I02_Door]eine solide Eingangstür[/I]. Dass davor ordentlich drapiert [I:I02_Doormat]eine Fußmatte[/I] lag, verbesserte den Gesamteindruck nicht wesentlich. [L:L03_In_The_Parlor]Der Eingang zur Hütte lag nördlich[/L]. [L:L01_Dark_Forest]Alle anderen Wege führten zurück in den Wald[/L].";
            else
                return "I was standing in front of [I:I02_Shed]a dilapidated hut[/I] in the [I:I02_Forest]forest[/I]. Actually, I saw little more than the silhouette [I:I02_Shed]of a low building[/I], which stood out [I:I02_Mist]from the dense fog[/I].<br>The rancid building didn't look like the noble residence of a master magician. But surely this property still had a secret to reveal.<br>[I:I02_Shed]The hut[/I] was made of rough stone and had [I:I02_Door]a solid entrance door[/I]. The fact that there was a neatly draped [I:I02_Doormat]doormat[/I] in front of it didn't improve the overall impression much. [L:L03_In_The_Parlor]The entrance to the hut was to the north[/L]. [L:L01_Dark_Forest]All other paths led back into the forest[/L].";
        }
    }

    public static string Adv_L03_In_The_Parlor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Stube der Hütte des Meisters";
            else
                return "In the parlor of the master's hut";
        }
    }
    public static string Adv_L03_In_The_Parlor_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das hier konnte ja wohl nicht die Stube sein, in der der Meister lebte! Ich stand nämlich in einem komplett leeren, kalten Raum. Immerhin kündete ein [I:I03_Pentagram]in rot geschmiertes Pentagramm[/I] auf dem Boden davon, dass hier irgendwer irgendwas mit Zauberkräften am Hut hatte. Auch [I:I03_Runes]die Runen an der Wand[/I] hinterließen eine einigermaßen klare Botschaft.<br>Also gut, das war definitiv nicht das Wohngemach des Meisters. Aber vielleicht war dieser Ort ja der Eingang zu seinem eigentlichen Domizil. Das läge zumindest nahe.<br>In [L:L04_Shabby_Little_Chamber]östlicher Richtung[/L] befand sich [I:I03_Door]eine schäbige kleine Tür[/I]. [L:L02_In_Front_Of_A_Hut]Nach Süden[/L] gings [I:I03_Door_Outside]durch eine schwere Tür[/I] wieder nach draußen.";
            else
                return "This couldn't be the room where the master lived! I was standing in a completely empty, cold room. After all, a [I:I03_Pentagram]pentagram[/I] smeared in red on the floor told us that someone here had something to do with magic. Even [I:I03_Runes]the runes on the wall[/I] left a reasonably clear message.<br>Alright, this was definitely not the master's living quarters. But perhaps this place was the entrance to his actual domicile. That would at least be obvious.<br>In [L:L04_Shabby_Little_Chamber]eastern direction[/L] there was [I:I03_Door]a shabby little door[/I]. [L:L02_In_Front_Of_A_Hut]To the south[/L] we went [I:I03_Door_Outside]through a heavy door[/I] back outside.";
        }
    }
    public static string Adv_L03_In_The_Parlor_Lang2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand in einem komplett leeren, kalten Raum. Immerhin kündete [I:I03_Pentagram]in rot geschmiertes Pentagramm[/I] auf dem Boden davon, dass hier irgendwer irgendwas mit Zauberkräften am Hut hatte. Auch [I:I03_Runes]die Runen an der Wand hinterließen eine einigermaßen klare Botschaft.<br>Also gut, das war definitiv nicht das Wohngemach des Meisters. Aber vielleicht war dieser Ort ja der Eingang zu seinem eigentlichen Domizil. Das läge zumindest nahe.<br>In [L:L04_Shabby_Little_Chamber]östlicher Richtung[/L] befand sich [I:I03_Door]eine schäbige kleine Tür[/I]. [L:L02_In_Front_Of_A_Hut]Nach Süden[/L] gings [I:I03_Door_Outside]durch eine schwere Tür[/I] wieder nach draußen.";
            else
                return "This couldn't be the room where the master lived! I was standing in a completely empty, cold room. At least there was a [I:I03_Pentagram]pentagram[/I] smeared in red on the floor telling me that someone here had something to do with magic. Even [I:I03_Runes]the runes on the wall left a reasonably clear message.<br>Alright, this was definitely not the master's living quarters. But perhaps this place was the entrance to his actual domicile. That would at least be obvious.<br>In [L:L04_Shabby_Little_Chamber]eastern direction[/L] there was [I:I03_Door]a shabby little door[/I]. [L:L02_In_Front_Of_A_Hut]To the south[/L] we went [I:I03_Door_Outside]through a heavy door[/I] back outside.";
        }
    }


    public static string Adv_L04_Shabby_Little_Chamber
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In einer schäbigen kleinen Kammer";
            else
                return "In a shabby little chamber";
        }
    }
    public static string Adv_L04_Shabby_Little_Chamber_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand in einer schäbigen kleinen Kammer, in der sich neben [I:I04_Cupboard]einem großen Schrank[/I] und [I:I04_Shelf]einem Regal[/I] eigentlich nur vollkommen desolates Gerümpel befand. Wenigstens lag auch keine halb verweste Matratze in der Ecke. Ich hatte also schon mal nicht das Schlafzimmer des Meisters gefunden. Zum Glück.<br>Durch eine [L:L03_In_The_Parlor]westlich[/L] gelegene [I:I04_Door]Tür[/I] gelangte man [L:L03_In_The_Parlor]zurück in die Stube[/L].";
            else
                return "I was standing in a shabby little room in which, apart from [I:I04_Cupboard]a large cupboard[/I] and [I:I04_Shelf]a shelf[/I], there was nothing but completely desolate junk. At least there wasn't a half-decomposed mattress in the corner. So I hadn't found the master's bedroom yet. Fortunately.<br>Through a [L:L03_In_The_Parlor]west[/L] [I:I04_Door]door[/I] you could [L:L03_In_The_Parlor]get back into the parlor[/L].";
        }
    }
    public static string Adv_L04_Shabby_Little_Chamber_Lang2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand in einer schäbigen kleinen Kammer, in der sich neben [I:I04_Cupboard]einem großen Schrank[/I] und [I:I04_Shelf]einem Regal[/I] eigentlich nur vollkommen desolates Gerümpel befand. <br>Durch eine [L:L03_In_The_Parlor]westlich[/L] gelegene [I:I04_Door]Tür[/I] gelangte man [L:L03_In_The_Parlor]zurück in die Stube[/L].";
            else
                return "I was standing in a shabby little room in which, apart from [I:I04_Cupboard]a large cupboard[/I] and [I:I04_Shelf]a shelf[/I], there was nothing but completely desolate junk. <br>Through a [L:L03_In_The_Parlor]west[/L] [I:I04_Door]door[/I] you could [L:L03_In_The_Parlor]get back into the parlor[/L].";
        }
    }

    public static string Adv_L05_Atrium
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Im Atrium des Meisterverstecks";
            else
                return "In the atrium of the master's lair";
        }
    }
    public static string Adv_L05_Atrium_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand im Atrium des geheimen Domizils von Meister Gunnar. Das sah schon eher nach einer standesgemäßen Butze für einen angeblichen Meistermagier aus. Der große Raum war von fast quadratischer Form. Durch das offene Dach konnte ich hinausblicken in eine endlose, sternenklare Nacht mit [I:I05_Moon]einem riesigen Vollmond[/I]. Darüber hinaus gab es keinerlei Hinweis darauf, in welcher seltsamen Dimension ich mich hier befand. Immerhin: Hier gab es keinen Nebel.<br>[I:I05_Library_Door]Eine breite, verzierte Tür[/I] in der [L:L09_Library]westlichen Wand[/L] mit der Aufschrift \"Bibliothek\" weckte meine Aufmerksamkeit. Daneben befand sich [I:I05_Sill]ein schmales Sims[/I], auf dem [P:Person_Owl]eine ausgestopfte Eule[/P] saß.<br>In einer Ecke war [I:I05_Pentagram]ein großes, rotes Pentagramm[/I] auf den Boden gemalt. [I:I05_Door]Eine weitere Tür[/I] führte [L:L06_Long_Floor]nach Süden[/L]. Genau im Zentrum des Atriums stand [I:I05_Pedestal]ein hohes, mit Gold verziertes Podest[/I].";
            else
                return "I was standing in the atrium of Master Gunnar's secret domicile. It looked more like a befitting abode for a supposed master magician. The large room was almost square in shape. Through the open roof I could look out into an endless, starry night with [I:I05_Moon]a huge full moon[/I]. Furthermore, there was no indication of what strange dimension I was in here. After all, there was no fog here.<br>[I:I05_Library_Door]A wide, ornate door[/I] in the [L:L09_Library]western wall[/L] with the inscription \"Library\" caught my attention. Next to it was [I:I05_Sill]a narrow ledge[/I] on which [P:Person_Owl]a stuffed owl[/P] sat.<br>In one corner, [I:I05_Pentagram]a large, red pentagram[/I] was painted on the floor. [I:I05_Door]Another door[/I] led [L:L06_Long_Floor]to the south[/L]. Right in the center of the atrium stood [I:I05_Pedestal]a high pedestal[/I] decorated with gold.";
        }
    }
    public static string Adv_L05_Atrium_Lang2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand im Atrium des geheimen - und durchaus opulenten - Domizils von Meister Gunnar. Der große Raum war von fast quadratischer Form. Durch das offene Dach konnte ich hinausblicken in eine endlose, sternenklare Nacht mit [I:I05_Moon]einem riesigen Vollmond[/I]. Darüber hinaus gab es keinerlei Hinweis darauf, in welcher seltsamen Dimension ich mich hier befand.<br>[I:I05_Library_Door]Eine breite, verzierte Tür[/I] mit der Aufschrift \"Bibliothek\" befand sich in der [L:L09_Library]westlichen Wand[/L].Daneben befand sich [I:I05_Sill]ein schmales Sims[/I], auf dem [P:Person_Owl]eine ausgestopfte Eule[/P] saß.<br>In einer Ecke war [I:I05_Pentagram]ein großes, rotes Pentagramm[/I] auf den Boden gemalt. [I:I05_Door]Eine weitere Tür[/I] führte [L:L06_Long_Floor]nach Süden[/L]. Genau im Zentrum des Atriums stand [I:I05_Pedestal]ein hohes, mit Gold verziertes Podest[/I].";
            else
                return "I was standing in the atrium of Master Gunnar's secret - and quite opulent - domicile. The large room was almost square in shape. Through the open roof, I could see out into an endless, starry night with [I:I05_Moon]a huge full moon[/I]. Beyond that, there was no indication of what strange dimension I was in.<br>[I:I05_Library_Door]A wide, ornate door[/I] with the inscription \"Library\" was located in the [L:L09_Library]western wall[/L].Next to it was [I:I05_Sill]a narrow ledge[/I] on which [P:Person_Owl]a stuffed owl[/P] sat.<br>In one corner, [I:I05_Pentagram]a large, red pentagram[/I] was painted on the floor. [I:I05_Door]Another door[/I] led [L:L06_Long_Floor]to the south[/L]. Right in the center of the atrium stood [I:I05_Pedestal]a high pedestal[/I] decorated with gold.";
        }
    }

    public static string Adv_L05_Atrium_Klaue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf dem Podest funkelte [I:I00_Claw]die prächtige, riesenhafte Klaue[/I], das Objekt meiner Begierde.";
            else
                return "On the pedestal sparkled [I:I00_Claw]the magnificent, gigantic claw[/I], the object of my desire.";
        }
    }
    public static string Adv_L04_Opening
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hinter [I:I04_Flap]einer Klappe[/I] an der Wand war eine [I:I04_Opening]dunkle Öffnung[/I] zu erkennen.";
            else
                return "Behind [I:I04_Flap]a flap[/I] on the wall, a [I:I04_Opening]dark opening[/I] could be seen.";
        }
    }
    public static string Adv_L04_Flap
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "An der Wand hinter [I:I04_Cupboard]dem Schrank[/I] befand sich [I:I04_Flap]einer Klappe[/I].";
            else
                return "On the wall behind [I:I04_Cupboard]the cupboard[/I] was [I:I04_Flap]a flap[/I].";
        }
    }
    public static string Adv_L06_Floor_Letters
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "An der Ritterrüstung befanden sich einige durch eifriges Polieren [I:I06_Letters] freigelegte Buchstaben[/I].";
            else
                return "There were some letters[/I] on the knight's armor that had been uncovered by zealous polishing[I:I06_Letters].";
        }
    }
    public static string Adv_L08_Schwamm
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Im Wäschekorb wucherte [I:I00_Wonder_Wart_Sponge] ein riesenhafter Wunderwarzenschwamm[/I] auf [I:I08_Clothes]einem Haufen nasser Wäsche[/I].";
            else
                return "In the laundry basket, [I:I00_Wonder_Wart_Sponge] a giant wonder wart sponge[/I] was growing on [I:I08_Clothes]a pile of wet laundry[/I].";
        }
    }
    public static string Adv_L08_Waesche
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Im Wäschekorb lag [I:I08_Clothes]ein Haufen nasser Wäsche[/I].";
            else
                return "There was [I:I08_Clothes]a pile of wet laundry[/I] in the laundry basket.";
        }
    }
    public static string Adv_L08_Abdeckung_drauf
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf dem Brunnen befand sich [I:I08_Wooden_Cover]eine hölzerne Abdeckung[/I].";
            else
                return "There was [I:I08_Wooden_Cover]a wooden cover[/I] on the fountain.";
        }
    }
    public static string Adv_L14_Opening
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine der Kacheln an der Wand fehlte, stattdessen klaffte dort [I:I14_Opening]eine Öffnung[/I].";
            else
                return "One of the tiles on the wall was missing, instead there was [I:I14_Opening]a gaping hole[/I].";
        }
    }
    public static string Adv_L14_Tile
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I14_Special_Tile]Eine der Kacheln[/I] an der Wand wirkte etwas anders als die anderen.";
            else
                return "[I:I14_Special_Tile]One of the tiles[/I] on the wall looked slightly different from the others.";
        }
    }
    public static string Adv_L08_Abdeckung_runter
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[I:I08_Wooden_Cover]Die Abdeckung des Brunnens[/I] lehnte zur Seite geschoben am Brunnen.";
            else
                return "[I:I08_Wooden_Cover]The cover of the fountain[/I] leaned against the fountain, pushed to one side.";
        }
    }

    public static string Adv_L06_Long_Floor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf einem langen Flur";
            else
                return "In a long corridor";
        }
    }

    // CA!.I06_Door = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_wuchtig! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L06_Long_Floor, loca.Adv_I06_Door, "Adv_I06_Door", Co.SZ_small, true, false, Nouns, Adjs));
    public static string Adv_L06_Long_Floor_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand auf einem langen Flur, der offensichtlich mehrere wichtige Räume des Meisterverstecks miteinander verband. [L:L05_Atrium]Nördlich[/L] führte [I:I06_Door_Wide]eine breite Tür[/I] zurück ins Atrium. [L:L12_Sleeping_Room]Direkt gegenüber an der Südwand[/L] befand sich [I:I06_Door]eine wuchtig Tür[/I] mit [I:I06_Sign]Schild[/I] \"Privat\" darauf. [L:L13_Kitchen]In der östlichen Wand[/L] befand sich [I:I06_Door_White]eine weiße Tür[/I], [L:L14_Bathroom]in der westlichen Wand[/L] [I:I06_Door_Red]eine rote Tür[/I]. Eine gewendelte Treppe führte [L:L07_Lower_Floor]nach unten[/L].";
            else
                return "I was standing in a long corridor that obviously connected several important rooms of the master hideout. [L:L05_Atrium]To the north[/L], [I:I06_Door_Wide]a wide door[/I] led back into the atrium. [L:L12_Sleeping_Room]Directly opposite on the south wall[/L] was [I:I06_Door]a massive door[/I] with a [I:I06_Sign]\"Private\" sign[/I] on it. [L:L13_Kitchen]In the eastern wall[/L] was [I:I06_Door_White]a white door[/I], [L:L14_Bathroom]in the western wall[/L] [I:I06_Door_Red]a red door[/I]. A spiral staircase led [L:L07_Lower_Floor]down[/L].";
        }
    }
    public static string Adv_L07_Lower_Floor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf dem Flur des Untergeschosses";
            else
                return "In the hallway of the basement";
        }
    }
    public static string Adv_L07_Lower_Floor_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es war erstaunlich, dass dieser Flur tatsächlich aussah wie ein Kellerflur. Gab es doch nicht das geringste Anzeichen dafür, dass sich dieses Geschoss in einem Keller befand. Im trüben Licht einer Funzel erkannte ich weiß gestrichene Wände, graue Bodenkacheln und insgesamt drei Türen. Dabei lag [L:L08_Laundry_Room]westlich[/L] eine [I:I07_Door_Green]grüne Tür[/I], [L:L11_Storage_Room]südlich[/L] [I:I07_Door_Blue]eine blaue Tür[/I], sowie [L:L10_Laboratory]im Osten[/L] [I:I07_Door]eine massive schwere Tür[/I]. Eine gewendelte Treppe führte [L:L06_Long_Floor]nach oben[/L].";
            else
                return "It was amazing that this corridor actually looked like a basement corridor. There was not the slightest sign that this floor was in a cellar. In the dim light of a twinkle, I recognized white-painted walls, grey floor tiles and a total of three doors. There was [L:L08_Laundry_Room]to the west[/L] a [I:I07_Door_Green]green door[/I], [L:L11_Storage_Room]to the south[L/L] [I:I07_Door_Blue]a blue door[/I], and [L:L10_Laboratory]to the east[/L] [I:I07_Door]a massive heavy door[/I]. A spiral staircase led [L:L06_Long_Floor]upstairs[/L].";
        }
    }
    public static string Adv_L08_Laundry_Room
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Waschküche";
            else
                return "In the laundry room";
        }
    }
    public static string Adv_L08_Laundry_Room_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich befand mich in der Waschküche des Meisters. Sofort ins Auge stach mir die brandneue [I:I08_Washing_Machine]magische Waschmaschine[/I] \"Magic 2000\", vor der außerdem [I:I08_Laundry_Basket]ein großer Wäschekorb[/I] stand. In einer Ecke befand sich [I:I08_Well]ein gemauerter Brunnen[/I]. Unter der Decke hingen [I:I08_Clothes_Line]lauter Wäscheleinen[/I]. Der einzige Ausgang führte durch [I:I08_Door_Green]eine grüne Tür[/I] in der [L:L07_Lower_Floor]östlichen Wand[/L].";
            else
                return "I found myself in the master's laundry room. I was immediately struck by the brand new [I:I08_Washing_Machine]magic washing machine[/I] \"Magic 2000\", in front of which there was also [I:I08_Laundry_Basket]a large laundry basket[/I]. In one corner was [I:I08_Well]a brick fountain[/I]. There were [I:I08_Clothes_Line]lots of clotheslines[/I] hanging from the ceiling. The only exit was through [I:I08_Door_Green]a green door[/I] in the [L:L07_Lower_Floor]eastern wall[/L]";
        }
    }
    public static string Adv_L08_Laundry_Room_Lang2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich befand mich in der Waschküche des Meisters. In einer Ecke stand die brandneue [I:I08_Washing_Machine]magische Waschmaschine[/I] \"Magic 2000\", vor der außerdem [I:I08_Laundry_Basket]ein großer Wäschekorb[/I] stand. In einer Ecke befand sich [I:I08_Well]ein gemauerter Brunnen[/I]. Unter der Decke hingen [I:I08_Clothes_Line]lauter Wäscheleinen[/I]. Der einzige Ausgang führte durch [I:I08_Door_Green]eine grüne Tür[/I] in der [L:L07_Lower_Floor]östlichen Wand[/L].";
            else
                return "I found myself in the master's laundry room. In one corner was the brand new [I:I08_Washing_Machine]magic washing machine[/I] \"Magic 2000\", in front of which there was also [I:I08_Laundry_Basket]a large laundry basket[/I]. In one corner was [I:I08_Well]a brick fountain[/I]. There were [I:I08_Clothes_Line]lots of clotheslines[/I] hanging from the ceiling. The only exit was through [I:I08_Door_Green]a green door[/I] in the [L:L07_Lower_Floor]eastern wall[/L].";
        }
    }
    public static string Adv_L09_Library
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Bibliothek";
            else
                return "In the library";
        }
    }
    public static string Adv_L09_Library_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand in einem hohen Raum, in dem sich Regal an Regal reihte, die über und über mit zahllosen unheimlich aussehenden Büchern vollgestellt werden. Besonders [I:I09_Green_Shelf]ein grünes Regal[/I] und [I:I09_Red_Shelf]ein rotes Regal[/I] fielen mir dabei ins Auge. Dabei sah ein Band gefährlicher aus als der andere. In einer Ecke befand sich [I:I09_Librarians_Desk]ein Bibliothekarstresen[/I], hinter dem [P:Person_Librarian]ein Skelett[/P] saß. In einer Ecke stand [I:I09_Carton]ein Karton[/I]. Der einzige Weg nach draußen war durch [I:I09_Library_Door]eine verzierte Tür[/I] in der [L:L05_Atrium]Ostwand[/L].";
            else
                return "I was standing in a high-ceilinged room where shelf after shelf was lined with countless scary-looking books. In particular, [I:I09_Green_Shelf]a green shelf[/I] and [I:I09_Red_Shelf]a red shelf[/I] caught my eye. One volume looked more dangerous than the other. In one corner was [I:I09_Librarians_Desk]a librarian's desk[/I], behind which sat [P:Person_Librarian]a skeleton[/P]. In one corner was [I:I09_Carton]a cardboard box[/I]. The only way out was through [I:I09_Library_Door]an ornate door[/I] in the [L:L05_Atrium]east wall[/L].";
        }
    }

    public static string Adv_L10_Laboratory
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Im Labor des Meisters";
            else
                return "In the master's laboratory";
        }
    }
    public static string Adv_L10_Laboratory_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Dies also war das großartige Privatlabor des Meisters. Als mir mein Studium noch wichtig war, wäre ich vor Ehrfurcht erstarrt. Vor mir lag [I:I10_Labor_Table]der große Labortisch[/I] des Meisters mit allerlei Hilfsmitteln darauf. Im Tisch befand sich [I:I10_Drawer]eine Schublade[/I]. Neben dem Tisch erkannte ich [I:I10_Darkness_Machine]eine der berühmten Dunkelheitsmaschinen[/I], die angeblich Meister Gunnar selbst erfunden hatte. An der Wand hing vorbildlicherweise [I:I10_First_Aid_Kit]ein großer Erste-Hilfe-Kasten[/I]. In [L:L07_Lower_Floor]der westlichen Wand[/L] führte [I:I10_Labor_Door]eine Tür[/I] zurück zum Flur.";
            else
                return "So this was the master's magnificent private laboratory. When my studies were still important to me, I would have frozen in awe. In front of me was [I:I10_Labor_Table]the master's large laboratory table[/I] with all kinds of tools on it. In the table was [I:I10_Drawer]a drawer[/I]. Next to the table, I recognized [I:I10_Darkness_Machine]one of the famous darkness machines[/I] that Master Gunnar himself had supposedly invented. Hanging on the wall was an exemplary [I:I10_First_Aid_Kit]large first aid kit[/I]. In [L:L07_Lower_Floor]the western wall[/L], [I:I10_Labor_Door]a door[/I] led back to the corridor.";
        }
    }
    public static string Adv_L10_Laboratory_Lang2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand im Privatlabor von Meister Gunnar. Vor mir lag [I:I10_Labor_Table]der große Labortisch[/I] des Meisters mit allerlei Hilfsmitteln darauf. Im Tisch befand sich [I:I10_Drawer]eine Schublade[/I]. Neben dem Tisch erkannte ich [I:I10_Darkness_Machine]eine der berühmten Dunkelheitsmaschinen[/I], die angeblich Meister Gunnar selbst erfunden hatte. An der Wand hing vorbildlicherweise [I:I10_First_Aid_Kit]ein großer Erste-Hilfe-Kasten[/I]. In [L:L07_Lower_Floor]der westlichen Wand[/L] führte [I:I10_Labor_Door]eine Tür[/I] zurück zum Flur.";
            else
                return "I was standing in Master Gunnar's private laboratory. In front of me was [I:I10_Labor_Table]the master's large laboratory table[/I] with all kinds of tools on it. In the table was [I:I10_Drawer]a drawer[/I]. Next to the table, I recognized [I:I10_Darkness_Machine]one of the famous darkness machines[/I] that Master Gunnar himself had supposedly invented. Hanging on the wall was an exemplary [I:I10_First_Aid_Kit]large first aid kit[/I]. In [L:L07_Lower_Floor]the western wall[/L], [I:I10_Labor_Door]a door[/I] led back to the corridor.";
        }
    }
    public static string Adv_L11_Storage_Room
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In einem Lagerraum";
            else
                return "In a storage room";
        }
    }
    public static string Adv_L11_Storage_Room_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich befand mich in einem niedrigen, aber sehr lang gezogenen Lagerraum. Hier befand sich in endlosen Regalen der Krempel von Meister Gunnar. Besonders ins Auge fielen mir dabei [I:I11_Left_Shelf]das linke Regal[/I] und [I:I11_Right_Shelf]das rechte Regal[/I] direkt vor mir, sowie [I:I11_Bird_Stand]ein Vogelständer[/I]. [I:I11_Door_Blue]Eine blaue Tür[/I] [L:L07_Lower_Floor]in der Nordwand führte nach draußen[/L].";
            else
                return "I found myself in a low, but very long storage room. Master Gunnar's junk was stored here on endless shelves. I was particularly struck by [I:I11_Left_Shelf]the left shelf[/I] and [I:I11_Right_Shelf]the right shelf[/I] directly in front of me, as well as [I:I11_Bird_Stand]a bird stand[/I]. [I:I11_Door_Blue]A blue door[/I] [L:L07_Lower_Floor]in the north wall led outside[/L].";
        }
    }
    public static string Adv_L12_Sleeping_Room
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Im Schlafgemach des Meisters";
            else
                return "In the master's bedchamber";
        }
    }
    public static string Adv_L12_Sleeping_Room_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das also war das geheimnisvolle Schlafgemach des Meisters. Nicht gerade eine verruchte Liebeshöhle, um willige Studentinnen abzuschleppen. Eher ein Mancave für Fortgeschrittene. [I:I12_Bed]Ein riesiges Bett[/I] dominierte den Raum, auf dem [I:I12_Matress]eine hohe, luftige Matratze[/I] lag. In einer Raumecke stand [I:I12_Wardrobe]ein Schrank[/I]. Durch [I:I12_Door]eine zerbrochene Tür[/I] in der Nordwand gelangte man [L:L06_Long_Floor]zurück zum Flur[/L].";
            else
                return "So this was the master's mysterious bedchamber. Not exactly a wicked love den for hooking up with willing students. More like an advanced mancave. [I:I12_Bed]A huge bed[/I] dominated the room, on which [I:I12_Matress]a high, airy mattress[/I] lay. In one corner of the room stood [I:I12_Wardrobe]a wardrobe[/I]. Through [I:I12_Door]a broken door[/I] in the north wall you could [L:L06_Long_Floor]get back to the hallway[/L].";
        }
    }

    public static string Adv_L13_Kitchen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In einer Küche";
            else
                return "In a kitchen";
        }
    }
    public static string Adv_L13_Kitchen_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich befand mich in einer überwiegend rustikal eingerichteten Küche. Neben [I:I13_Cupboard]einem rustikalen Küchenschrank[/I] gab es eine Anrichte mit [I:I13_Drawer]einer breiten Schublade[/I] darin. Neben dem Küchenschrank befand sich [I:I13_Fridge]ein großer magischer Kühlschrank[/I] mit [I:I13_Freezer]einem ebensolchen Gefrierfach[/I]. Der einzige Ausgang führte durch [I:I13_Door_White]die westliche Tür[/I] zurück [L:L06_Long_Floor]auf den Flur[/L].";
            else
                return "I found myself in a predominantly rustic kitchen. Next to [I:I13_Cupboard]a rustic kitchen cupboard[/I] there was a sideboard with [I:I13_Drawer]a wide drawer[/I] in it. Next to the cupboard was [I:I13_Fridge]a large magical fridge[/I] with [I:I13_Freezer]a freezer compartment[/I]. The only exit led through [I:I13_Door_White]the western door[/I] back [L:L06_Long_Floor]to the corridor[/L].";
        }
    }
    public static string Adv_L14_Bathroom
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Im Badezimmer";
            else
                return "In the bathroom";
        }
    }
    public static string Adv_L14_Bathroom_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Badezimmer des Meisters fiel feudaler aus als gedacht. Das fing an mit den auffällig gemaserten [I:I14_Tiles]grauen Kacheln an der Wand[/I]. [I:I14_Bathtub]Die große Badewanne[/I] wies eine Whirlpoolfunction auf. Über [I:I14_Sink]dem Waschbecken[/I] hing [I:I14_Mirror]ein großer, fein gearbeiteter Spiegel[/I]. Nur [I:I14_Toilet]die Toilette[/I] nebst [I:I14_Flushing]Spülung[/I] war No-Name-Ware aus dem Baumarkt. In der [L:L06_Long_Floor]östlichen Wand[/L] führte [I:I14_Door_Red]eine Tür[/I] zurück [L:L06_Long_Floor]zum Flur[/L].";
            else
                return "The master's bathroom turned out to be more feudal than expected. It started with the strikingly grained [I:I14_Tiles]gray tiles on the wall[/I]. [I:I14_Bathtub]The large bathtub[/I] had a whirlpool function. Above the washbasin hung [I:I14_Mirror]a large, finely crafted mirror[/I]. Only [I:I14_Toilet]the toilet[/I] and [I:I14_Flushing]flush[/I] were no-name products from the DIY store. In the [L:L06_Long_Floor]eastern wall[/L], [I:I14_Door_Red]a door[/I] led back [L:L06_Long_Floor]to the corridor[/L].";
        }
    }
    public static string Adv_L15_Nowhere
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Irgendwo im Nirgendwo";
            else
                return "Somewhere in the middle of nowhere";
        }
    }
    public static string Adv_L15_Nowhere_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich befand mich im Nirgendwo. Hier gab es nichts, keine Ausgänge, keine Gegenstände, nicht einmal ausgestopfte Tiere. Nein, hier gab es nur nackte Verzweiflung und die nicht mehr zu leugnende Erkenntnis:<br>GAME OVER!";
            else
                return "I was in the middle of nowhere. There was nothing here, no exits, no objects, not even stuffed animals. No, there was only naked despair and a realization that could no longer be denied:<br>GAME OVER!";
        }
    }

    public static string Adv_I00_Pouch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein kleines ledernes Beutelchen.";
            else
                return "A small leather pouch.";
        }
    }
    public static string Adv_I00_Magic_Powder
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein fein gemahlenes Pulver, das sich leicht magisch anfühlte.";
            else
                return "A finely ground powder that felt slightly magical.";
        }
    }
    public static string Adv_I00_Supermagic_Powder
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein fein gemahlenes Pulver, das sich leicht magisch anfühlte.";
            else
                return "A finely ground powder that felt slightly magical.";
        }
    }
    public static string Adv_I00_Magic_Candle
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein sehr moderner Kerzenhalter, der mittels eines magischen Drehrads entzündet werden konnte.<br>Die magische, immerwährende Kerze war erloschen.";
            else
                return "A very modern candlestick that could be lit by means of a magical rotating wheel.<br>The magical, everlasting candle had gone out.";
        }
    }
    public static string Adv_I00_Magic_Candle_Lighted
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein sehr moderner Kerzenhalter, der mittels eines magischen Drehrads entzündet werden konnte.<br>Die magische, immerwährende Kerze brannte lichterloh.";
            else
                return "A very modern candle holder that could be lit using a magical rotating wheel.<br>The magical, everlasting candle burned brightly.";
        }
    }
    public static string Enlighten_Magic_Candle_Yes
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich drehte das magische Rad am [I:I00_Magic_Candle]Kerzenhalter[/I]. Sofort entfachte sich an der Kerzenspitze eine ordentliche Flamme.";
            else
                return "I turned the magic wheel on the [I:I00_Magic_Candle]candle holder[/I]. The tip of the candle immediately ignited a decent flame.";
        }
    }
    public static string Enlighten_Magic_Candle_No
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich drehte das magische Rad am [I:I00_Magic_Candle]Kerzenhalter[/I]. Nichts weiter passierte, da die Kerze schon brannte.";
            else
                return "I turned the magic wheel on the [I:I00_Magic_Candle]candle holder[/I]. Nothing else happened because the candle was already burning.";
        }
    }
    public static string Extinguish_Magic_Candle_Yes
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich pustete [I:I00_Magic_Candle]die Kerze[/I] aus. Die Flamme erlosch sofort.";
            else
                return "I blew out [I:I00_Magic_Candle]the candle[/I]. The flame went out immediately.";
        }
    }
    public static string Extinguish_Magic_Candle_No
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich pustete und pustete, aber da [I:I00_Magic_Candle]die Kerze[/I] schon erloschen war, tat sich hier nichts weiter.";
            else
                return "I blew and blew, but since [I:I00_Magic_Candle]the candle[/I] had already gone out, nothing else happened.";
        }
    }

    public static string Adv_I00_Claw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein riesiger Edelstein, rund geformt mit einem spitzen, klauenartigen Ende. Im Inneren des Steins waberte grünes Licht.";
            else
                return "A huge gemstone, round in shape with a pointed, claw-like end. Green light wafted inside the stone.";
        }
    }
    public static string Adv_I00_Roll_Plaster
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine Rolle mit altem, vergilbtem Pflaster.";
            else
                return "A roll of old, yellowed plaster.";
        }
    }
    public static string Adv_I00_Unstable_Pliers_With_Claw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Zuckerzange steckt vorne die Klaue drin. Das ganze Gebilde war ganz schön instabil.";
            else
                return "The claw is stuck in the front of the sugar tongs. The whole thing was pretty unstable.";
        }
    }
    public static string Adv_I00_Stable_Pliers_With_Claw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Zuckerzange steckte vorne die Klaue drin. Da der Zangengriff mit Rollpflaster umwickelt war, war die Klaue stabil eingeklemmt in der Zange.";
            else
                return "The claw was stuck in the front of the sugar tongs. As the handle of the tongs was wrapped in plaster, the claw was firmly clamped in the tongs.";
        }
    }
    public static string Adv_I00_Magnifier
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine sehr große, stark vergrößernde Lupe.";
            else
                return "A very large, highly magnifying magnifying glass.";
        }
    }
    public static string Adv_I00_Squeaky_Duck
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein quietschegelbes Quietscheentchen aus billigstem Plastik. Schwer zu glauben, dass ein akademisches Schwergewicht wie Meister Gunnar damit sein Badevergnügen aufwerten konnte.";
            else
                return "A squeaky yellow squeaky duck made of the cheapest plastic. It's hard to believe that an academic heavyweight like Master Gunnar could use it to enhance his bathing pleasure.";
        }
    }
    public static string Adv_I00_Paper_Sheets
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Stapel beschriebener Papierbögen. Ich begann zu lesen, was dort stand: \"Oh, du mein Quietscheentchen! Dein ist mein ganzes Streben...\" Ich hielt inne, ehe ich meine Restachtung vor Meister Gunnar auch noch verlor.";
            else
                return "A pile of written sheets of paper. I began to read what was written there: \"Oh, you my squeaky duck! All my aspirations are yours...\" I paused before I lost my respect for Master Gunnar too.";
        }
    }
    public static string Adv_I00_Book_Master
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Belegexemplar des Buchs von Meister Gunnar: \"Die geheimen Magietricks von Meister Gunnar\" Auf einer der ersten Seiten befand sich eine Lithografie von Meister Gunnar, die ihn sehr naturgetreu, aber auch unfassbar schmierig darstelle.";
            else
                return "A specimen copy of the book by Master Gunnar: \"The Secret Magic Tricks of Master Gunnar\" On one of the first pages there was a lithograph of Master Gunnar, which depicted him very lifelike, but also incredibly greasy.";
        }
    }
    public static string Adv_I00_Cheese
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Käsestück war völlig vertrocknet und für ein menschliches Wesen nicht mehr essbar.";
            else
                return "The piece of cheese was completely dried out and no longer edible for a human being.";
        }
    }
    public static string Adv_I00_Polished_Stone
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein blank polierter Kieselstein.";
            else
                return "A brightly polished pebble.";
        }
    }
    public static string Adv_I00_Sugar_Pliers
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mit dieser verzierten Zuckerzange konnte man Würfelzucker in den Tee befördern oder andere lustige Dinge anstellen.";
            else
                return "With these decorated sugar tongs, you could put sugar cubes in your tea or do other fun things.";
        }
    }
    public static string Adv_I00_Key
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein verzierter, altmodischer Bartschlüssel.";
            else
                return "An ornate, old-fashioned bar key.";
        }
    }
    public static string Adv_I00_Polishing_Rag
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Lappen, wie man ihn zum Polieren von Metall verwendete.";
            else
                return "A cloth used for polishing metal.";
        }
    }

    public static string Adv_I00_Lightless_Stone
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Stein, der schwärzer als schwarz war. Er war sozusagen der Inbegriff von Lichtlosigkeit.";
            else
                return "A stone that was blacker than black. It was the epitome of lightlessness, so to speak.";
        }
    }

    public static string Adv_I00_Moonstone
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Kiesel war nun vollständig mit Mondlicht vollgesogen. Das machte ihn zum Mondstein.";
            else
                return "The pebble was now completely saturated with moonlight. That made it a moonstone.";
        }
    }
    public static string Adv_I00_Plastic_Bag
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Plastikbeutel, gefüllt mit einer komischen Substanz. Darauf klebte ein Warnaufkleber \"Vorsicht! Aggressive Pilzsporen! Nicht ins Müsli\" Da sprach einer aus Erfahrung, schien mir.";
            else
                return "A plastic bag filled with a strange substance. It had a warning sticker on it \"Caution! Aggressive fungal spores! Do not put in muesli\" Someone was speaking from experience, it seemed to me.";
        }
    }
    public static string Adv_I00_Wonder_Wart_Sponge
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Noch nie zuvor hatte ich einen derartig prachtvollen Wunderwarzenschwamm gesehen. Das konnte natürlich auch daran liegen, dass ich noch nie zuvor ein solches Ding gesehen hatte.";
            else
                return "Never before had I seen such a magnificent wonder wart sponge. Of course, this could also be due to the fact that I had never seen such a thing before.";
        }
    }
    public static string Adv_I00_Slag
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus meinen schönen Zutaten war ein unansehnlicher Schlackeklumpen geworden.";
            else
                return "My beautiful ingredients had turned into an unsightly lump of slag.";
        }
    }
    public static string Adv_I00_Plunger
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein großer Stößel für einen großen Mörser.";
            else
                return "A large pestle for a large mortar.";
        }
    }
    public static string Adv_I00_Coin
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine golden schimmernde Münze.";
            else
                return "A sparkling golden coin.";
        }
    }
    public static string Adv_I00_Coin2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Zu dumm, dass sie unten auf dem Grund des Brunnens lag und unerreichbar war.";
            else
                return "Too bad it was at the bottom of the well and out of reach.";
        }
    }
    public static string Adv_I01_Forest
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Vollmond tauchte den Nebel in ein fahles Licht, das die Silhouetten der knorrigen Bäume hervorhob.";
            else
                return "The full moon bathed the fog in a pale light that highlighted the silhouettes of the gnarled trees.";
        }
    }
    public static string Adv_I01_Trees
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es gab hier unzählige knorrige Bäume in einem nebligen Wald. Keiner davon erschien mir sonderlich interessant.";
            else
                return "There were countless gnarled trees in a misty forest. None of them seemed particularly interesting to me.";
        }
    }
    public static string Adv_I01_Mist
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Vollmond tauchte den Nebel in ein fahles Leuchten.";
            else
                return "The full moon bathed the fog in a pale glow.";
        }
    }
    public static string Adv_I01_Forest_Grass
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es handelte sich um gewöhnliches, weiches Waldgras, das mir gerade so rein gar nichts nutzte.";
            else
                return "It was ordinary, soft forest grass that was of no use to me at all.";
        }
    }
    public static string Adv_I02_Doormat
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine große Türmatte mit der wenig erfreulichen Aufschrift: \"Betteln und Hausieren verboten!\"";
            else
                return "A large door mat with the unpleasant inscription: \"No begging and peddling!\"";
        }
    }
    public static string Adv_I02_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Durch diese sehr solide wirkende Tür gelangte man ins Innere der Hütte. Dass die Tür nicht abgeschlossen war, ließ sich bereits daran erkennen, dass sie überhaupt kein Schloss hatte.";
            else
                return "This very solid-looking door led to the inside of the hut. The fact that the door was not locked was evident from the fact that it had no lock at all.";
        }
    }
    public static string Adv_I02_Shed
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine einsame, etwas schäbige Hütte mitten im Wald. Wegen des starken Nebels erkannte ich nicht allzu viel davon. Aber ein Prachtbau war dieses Gebäude bestimmt nicht. Warum leistete sich Meister Gunnar nicht einen schicken Loft in der Stadt?";
            else
                return "A lonely, somewhat shabby hut in the middle of the forest. I couldn't make out much of it because of the heavy fog. But this building was certainly not a magnificent structure. Why didn't Master Gunnar afford a fancy loft in the city?";
        }
    }
    public static string Adv_I02_Forest
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Vollmond tauchte den Nebel in ein fahles Licht, das die Silhouetten der knorrigen Bäume hervorhob.";
            else
                return "The full moon bathed the fog in a pale light that highlighted the silhouettes of the gnarled trees.";
        }
    }
    public static string Adv_I02_Trees
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Jenseits der Hütte wuchsen hier unzählige knorrige Bäume im nebligen Wald. Keiner davon erschien mir sonderlich interessant.";
            else
                return "Beyond the hut, countless gnarled trees grew in the misty forest. None of them seemed particularly interesting to me.";
        }
    }
    public static string Adv_I03_Door_Solid
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Durch eine solide Tür konnte man dieses fürstliche Domizil verlassen.";
            else
                return "You could leave this princely residence through a solid door.";
        }
    }
    public static string Adv_I02_Mist
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nebel, soweit das Auge reichte.";
            else
                return "Fog as far as the eye could see.";
        }
    }
    public static string Adv_I03_Pentagram
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf den Holzboden war mit roter Farbe ein Pentagramm gemalt. ";
            else
                return "A pentagram was painted on the wooden floor with red paint. ";
        }
    }
    public static string Adv_I03_Runes
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hätte ich im Unterricht besser aufgepasst, hätte ich vermutlich bestimmen können, was diese Runen aussagten. So aber sah ich nur eine Ansammlung seltsamer Runen, die irgendwie bedrohlich wirkten. ";
            else
                return "If I had paid more attention in class, I would probably have been able to determine what these runes meant. But as it was, all I saw was a collection of strange runes that seemed somehow threatening. ";
        }
    }
    public static string Adv_I03_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der östlichen Wand befand sich ein schäbiges kleines Türchen.";
            else
                return "There was a shabby little door in the eastern wall.";
        }
    }
    public static string Adv_I04_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die schäbige Tür in der westlichen Wand führt aus der Kammer heraus.";
            else
                return "The shabby door in the western wall leads out of the chamber.";
        }
    }
    public static string Adv_I04_Shelf
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich blickte auf ein klappriges Regal, das selbst für meinen eigenen Keller zu schäbig gewesen wäre.";
            else
                return "I looked at a rickety shelf that would have been too shabby even for my own cellar.";
        }
    }
    public static string Adv_I04_Cupboard
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der wurmstichige Schrank stand nutzlos im Weg.";
            else
                return "The worm-eaten cupboard stood uselessly in the way.";
        }
    }
    public static string Adv_I04_Clutter
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Selten hatte ich so trostlosen Krempel gesehen.";
            else
                return "Rarely had I seen such dreary junk.";
        }
    }
    public static string Adv_I04_Cupboard_Add
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Schrank war ein Stückweit von der Wand abgerückt.";
            else
                return "The cupboard had moved a little away from the wall.";
        }
    }
    public static string Adv_I04_Cupboard_Add2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf dem Boden vor dem Schrank befanden sich Abschürfungen auf dem Boden, als wäre der Schrank öfters abgerückt worden.";
            else
                return "There were abrasions on the floor in front of the cupboard, as if the cupboard had been moved several times.";
        }
    }
    public static string Adv_I04_Wall
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die steinerne Wand war grob gemauert und ganz schön schief.";
            else
                return "The stone wall was roughly built and quite crooked.";
        }
    }
    public static string Adv_I04_Floor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Morscher Dielenboden, auf dem sich jede Menge Schrammen befanden, insbesondere vor [I:I04_Cupboard]dem Schrank[/I].";
            else
                return "Rotten floorboards with lots of scratches, especially in front of [I:I04_Cupboard]the cupboard[/I].";
        }
    }
    public static string Adv_I04_Flap
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine kleine Metallklappe, wie man sie an Schornsteinen fand.";
            else
                return "A small metal flap like those found on chimneys.";
        }
    }
    public static string Adv_I04_Opening
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Wand klaffte eine dunkle, rechteckige Öffnung.";
            else
                return "A dark, rectangular opening gaped in the wall.";
        }
    }
    public static string Adv_I05_Library_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der westlichen Wand befand sich eine hohe, verzierte Tür. Ein hölzernes Schrift mit dem Schriftzug \"Bibliothek\" ließ wenig Zweifel daran, was sich hinter dieser Tür befand.";
            else
                return "There was a tall, ornate door in the western wall. Wooden lettering with the words \"Libraray\" left little doubt as to what was behind this door.";
        }
    }
    public static string Adv_I05_Pentagram
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf den Steinboden war mit roter Farbe ein Pentagramm gemalt. ";
            else
                return "A pentagram was painted in red on the stone floor. ";
        }
    }
    public static string Adv_I05_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Südwand führte eine Tür aus dem Atrium.";
            else
                return "A door in the south wall led out of the atrium.";
        }
    }
    public static string Adv_I05_Moon
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Über dem Atrium stand ein riesiger, heller Vollmond, fast zum Greifen nah.";
            else
                return "A huge, bright full moon stood above the atrium, almost close enough to touch.";
        }
    }
    public static string Adv_I05_Heaven
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Über dem Atrium war ein sternenklarer Nachthimmel zu sehen, voller heller Sterne und mit einem prächtigen Vollmond.";
            else
                return "A starry night sky could be seen above the atrium, full of bright stars and with a magnificent full moon.";
        }
    }
    public static string Adv_I05_Pedestal
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein edel verziertes Podest und mit Gold überzogen. Ein nicht zu übersehendes Warnschild war daran befestigt.";
            else
                return "An elegantly decorated pedestal covered in gold. An unmissable warning sign was attached to it.";
        }
    }
    public static string Adv_I05_Sign
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das große rote Warnschild verkündete: 'Klaue nicht berühren! Lebensgefahr!'<br>Darunter stand klein: 'Auch belebende Energien sind ungesund, wenn man zuviel davon abbekommt!'";
            else
                return "Das große rote Warnschild verkündete: 'Klaue nicht berühren! Lebensgefahr!'<br>Darunter stand klein: 'Auch belebende Energien sind ungesund, wenn man zuviel davon abbekommt!'";
        }
    }
    public static string Adv_I05_Sill
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Neben [I:I05_Library_Door]der Tür[/I] in der westlichen Wand befand sich ein hohes Sims. Darauf war eine [P:Person_Owl]ausgestopfte Eule[/P] platziert.";
            else
                return "Next to [I:I05_Library_Door]the door[/I] in the western wall was a high ledge. A [P:Person_Owl]stuffed owl[/P] was placed on it.";
        }
    }

    public static string Adv_I06_Door_Wide
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die breite Tür führte zurück ins Atrium.";
            else
                return "The wide door led back into the atrium.";
        }
    }
    public static string Adv_I06_Letters
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Einige kleine Buchstaben auf der Rückseite [P:Person_Knights_Armor]der Rüstung[/P]. Mit bloßem Auge waren sie nicht zu entziffern.";
            else
                return "Some small letters on the back [P:Person_Knights_Armor]of the armor[/P]. They were indecipherable to the naked eye.";
        }
    }
    public static string Adv_I06_Door_Red
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Westwand befand sich eine rote Tür mit der Aufschrift \"Bad\".";
            else
                return "There was a red door in the west wall with the inscription \"Bathroom\".";
        }
    }
    public static string Adv_I06_Door_White
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf der weißen Tür in der Ostwand stand \"Küche\".";
            else
                return "The white door in the east wall read \"Kitchen\".";
        }
    }
    public static string Adv_I06_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine robuste Tür, die mit [I:I06_Seal]einem magischen Siegel[/I] versehen war. Neben der Klinke hing [I:I06_Sign]ein kleines Schild[/I].";
            else
                return "A sturdy door with [I:I06_Seal]a magical seal[/I] on it. Next to the handle hung [I:I06_Sign]a small sign[/I].";
        }
    }
    public static string Adv_I06_Door_Broken
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine robuste Tür, die mit [I:I06_Seal]einem magischen Siegel[/I] versehen war. Neben der Klinke hing [I:I06_Sign]ein kleines Schild[/I]. Die Tür war halb zerbrochen und hing nur noch lose in den Angeln. Von dem einstigen magischen Schutz war nichts mehr zu bemerken.";
            else
                return "A sturdy door with [I:I06_Seal]a magical seal[/I] on it. Next to the handle hung [I:I06_Sign]a small sign[/I]. The door was half broken and hung loosely on its hinges. There was nothing left of the former magical protection.";
        }
    }
    public static string Adv_I06_Seal
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es handelte sich um ein magisches Siegel mit den Initialen von Meister Gunnar darauf.";
            else
                return "It was a magical seal with the initials of Master Gunnar on it.";
        }
    }
    public static string Adv_I06_Seal_Broken
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es handelte sich um ein magisches Siegel mit den Initialen von Meister Gunnar darauf. Das Siegel war mitten durchgebrochen. Irgendwie enttäuschend für ein magisches Siegel...";
            else
                return "It was a magical seal with the initials of Master Gunnar on it. The seal was broken in half. Kind of disappointing for a magic seal...";
        }
    }
    public static string Adv_I06_Sign
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf dem Schild stand groß \"Privat\". Sehr witzig. Und darunter stand noch in klein: \"Keine rohe Gewalt anwenden!\" Tja, warum eigentlich nicht?";
            else
                return "The sign said \"Private\" in large letters. Very funny. And underneath it said in small letters: \\\"Do not use brute force!\" Well, why not?";
        }
    }
    public static string Adv_I06_Sign_Broken
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf dem Schild stand groß \"Privat\". Sehr witzig. Und darunter stand noch in klein: \"Keine rohe Gewalt anwenden!\" Danke nochmal für den Tipp, liebes Schild.";
            else
                return "The sign said \"Private\" in large letters. Very funny. And underneath it said in small letters: \"Do not use brute force!\" Thanks again for the tip, dear sign.";
        }
    }

    public static string Adv_I07_Door_Blue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine blaue Tür führte nach Westen.";
            else
                return "A blue door led to the west.";
        }
    }
    public static string Adv_I07_Door_Green
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der südlichen Wand befand sich eine wenig auffällige grüne Tür.";
            else
                return "There was an unremarkable green door in the southern wall.";
        }
    }

    public static string Adv_I07_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine schwere, sehr massive Tür führte nach Osten. Der Schriftzug \"Labor\" war schon leicht abgeblättert. Unter dem Türgriff befand sich ein Schlüsselloch für einen großen Bartschlüssel.";
            else
                return "A heavy, very solid door led to the east. The lettering \"Labor\" was already slightly peeled off. There was a keyhole under the door handle for a large bearded key.";
        }
    }
    public static string Adv_I08_Door_Blue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Durch die blaue Tür gelangte man zurück zum Flur des Untergeschosses.";
            else
                return "The blue door led back to the corridor in the basement.";
        }
    }
    public static string Adv_I08_Clothes_Line
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mehrere Wäscheleinen reichten von einer Seite der Waschküche zur anderen und zurück. Kleidung hing nicht daran.";
            else
                return "Several washing lines stretched from one side of the laundry room to the other and back. There were no clothes hanging on them.";
        }
    }
    public static string Adv_I08_Underpants
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine hässliche alte Unterhose, der man ihre edle Herkunft aber noch ansah. Es stand nämlich groß und breit \"Karl Lagerhaus\" darauf.";
            else
                return "Ugly old underpants, but you could still see their noble origins. It said \"Karl Lagerhaus\" big and wide on them.";
        }
    }
    public static string Adv_I08_Well
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mitten in der Waschküche befand sich ein gemauerter Brunnen.";
            else
                return "There was a brick well in the middle of the laundry room.";
        }
    }
    public static string Adv_I08_Well_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die hölzerne Abdeckung deckte den Brunnen ab.";
            else
                return "The wooden cover covered the well.";
        }
    }
    public static string Adv_I08_Well_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Irgendwo tief unten im Brunnen hatte kurz etwas geschimmert. Aber es war zu dunkel, um wirklich etwas [I:I08_Water]im Wasser[/I] zu erkennen.";
            else
                return "Somewhere deep down in the well, something had shimmered briefly. But it was too dark to really recognize anything [I:I08_Water]in the water[/I].";
        }
    }
    public static string Adv_I08_Wooden_Cover
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die hölzerne Abdeckung war dazu gedacht, [I:I08_Well]den Brunnen[/I] abzudecken, damit niemand hinein fiel.";
            else
                return "The wooden cover was intended to [I:I08_Well]cover the well[/I] so that no one fell in.";
        }
    }
    public static string Adv_I08_Water
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Wasser füllte [I:I08_Well]den Brunnen[/I] fast bis zum Rand. Es reichte hinab bis in dunkle Tiefen.";
            else
                return "The water filled [I:I08_Well]the well[/I] almost to the brim. It reached down into the dark depths.";
        }
    }
    public static string Adv_I08_Washing_Machine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine magische Waschmaschine neuester Bauart. Ich kannte nicht viele Leute, die sich so etwas leisten konnten.";
            else
                return "A magical washing machine of the latest design. I didn't know many people who could afford something like that.";
        }
    }
    public static string Adv_I08_Clothes
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Haufen mit feuchter, müffelnder Wäsche. Ich hoffe, bei dieser oberflächlichen Untersuchung konnte ich es belassen.";
            else
                return "A pile of damp, smelly laundry. I hope I was able to leave it at this superficial examination.";
        }
    }
    public static string Adv_I08_Machine_For_Hanging_Up_Laundry
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine vollautomatische Wäscheaufhängmaschine. Leider waren ihre Arme verbogen und verknotet. Meister Gunnars Umgang mit wertvollem Haushaltsequipment war doch sehr fragwürdig.";
            else
                return "A fully automatic laundry hanging machine. Unfortunately, its arms were bent and knotted. Master Gunnar's handling of valuable household equipment was very questionable.";
        }
    }
    public static string Adv_I08_Laundry_Basket
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein sehr gewöhnlicher Wäschekorb.";
            else
                return "A very ordinary laundry basket.";
        }
    }
    public static string Adv_I09_Red_Shelf
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein recht robust aussehendes rotes Regal.";
            else
                return "A rather robust-looking red shelf.";
        }
    }
    public static string Adv_I09_Green_Shelf
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein recht robust aussehendes grünes Regal.";
            else
                return "A rather robust-looking green shelf.";
        }
    }
    public static string Adv_I09_Library_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Durch die verzierte Tür gelangte man ins Atrium zurück.";
            else
                return "The ornate door led back into the atrium.";
        }
    }
    public static string Adv_I09_Librarians_Desk
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein schwerer hölzerner Bibliothekstresen.";
            else
                return "A heavy wooden library counter.";
        }
    }
    public static string Adv_I09_Angry_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Buch schnappte hasserfüllt nach mir.";
            else
                return "The book snapped hatefully at me.";
        }
    }
    public static string Adv_I09_Crazy_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich streckte die Finger nach dem verrückten Buch aus. Plötzlich platzte es in ein irres Lachen heraus. Hastig zog ich meine Hand zurück.";
            else
                return "I stretched out my fingers towards the crazy book. Suddenly it burst out in a maniacal laugh. I hastily pulled my hand back.";
        }
    }
    public static string Adv_I09_Demonic_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Buch musterte mich mit seinen tiefroten Dämonenaugen. Ich schaute lieber weg.";
            else
                return "The book scrutinized me with its deep red demon eyes. I preferred to look away.";
        }
    }
    public static string Adv_I09_Satanic_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Buch hatte eine Teufelsfratze auf der Vorderseite, die mich hämisch angrinste. Ab und an kicherte die Fratze zutiefst bösartig.";
            else
                return "The book had a devil's grimace on the front that grinned at me maliciously. Now and again the grimace giggled in a deeply malicious way.";
        }
    }
    public static string Adv_I09_Weird_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Buch brabbelte wirr vor sich hin. Genervt zog ich meine Hand zurück.";
            else
                return "The book was babbling away. Annoyed, I pulled my hand back.";
        }
    }
    public static string Adv_I09_Sign
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf dem Schild stand: \"Bücher ohne sachkundige Unterstützung nicht berühren! Lebensgefahr!\"";
            else
                return "The sign said: \\\"Do not touch books without expert assistance! Danger to life!\"";
        }
    }
    public static string Adv_I09_Carton
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein großer, schwerer Karton von \"Egobooster Selfpublishing\"";
            else
                return "A large, heavy cardboard box from \"Egobooster Selfpublishing\"";
        }
    }
    public static string Adv_I09_Books_Master
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Stapel Belegexemplare des Buchs von Meister Gunnar: \"Die geheimen Magietricks von Meister Gunnar\" Auf einer der ersten Seiten befand sich eine Lithografie von Meister Gunnar, die ihn sehr naturgetreu, aber auch unfassbar schmierig darstelle.<br>Ich konnte einen Brechreiz gerade so noch unterdrücken.";
            else
                return "A stack of specimen copies of Master Gunnar's book: \"The secret magic tricks of Master Gunnar\". On one of the first pages there was a lithograph of Master Gunnar, which depicted him very realistically, but also incredibly greasy.<br>I could barely suppress a nausea.";
        }
    }
    public static string Adv_I10_Labor_Table
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der lange Labortisch reichte von einer Wand zur anderen und war übersät mit gefährlich aussehenden Dingen.";
            else
                return "The long laboratory table stretched from one wall to the other and was littered with dangerous-looking things.";
        }
    }
    public static string Adv_I10_Cages
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die mannshohen Metallkäfige waren vermutlich geeignet, auch gefährlichste Kreaturen sicher in ihrem Inneren gefangen zu setzen. Trotzdem fand ich es sehr beruhigend, was vermutlich daran lag, dass die Käfige allesamt leer waren.";
            else
                return "The man-sized metal cages were probably suitable for keeping even the most dangerous creatures safely trapped inside. Nevertheless, I found it very reassuring, which was probably due to the fact that the cages were all empty.";
        }
    }
    public static string Adv_I11_Door_Green
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die grüne Tür in der Nordwand führte nach draußen.";
            else
                return "The green door in the north wall led outside.";
        }
    }
    public static string Adv_I11_Clutter
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Schwer zu sagen, warum dieses Zeug nicht längst entsorgt worden war.";
            else
                return "It's hard to say why this stuff hadn't been disposed of long ago.";
        }
    }
    public static string Adv_I10_First_Aid_Kit
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der wuchtige Erste-Hilfe-Kasten wirkte, als wäre schon so mancher Feuerregen auf ihn hernieder gegangen.";
            else
                return "The massive first aid kit looked as if it had already been hit by many a rain of fire.";
        }
    }
    public static string Adv_I10_Drawer
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Im [I:I10_Labor_Table]Labortisch[/I] befand sich eine gewöhnliche Schublade.";
            else
                return "The [I:I10_Labor_Table]laboratory table[/I] contained an ordinary drawer.";
        }
    }
    public static string Adv_I10_Bracket
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mit der metallenen Halterung ließ sich bestimmt etwas fixieren, ein anderer Teil der Versuchsanordnung zum Beispiel.";
            else
                return "The metal holder could certainly be used to hold something in place, another part of the experimental set-up for example.";
        }
    }
    public static string Adv_I10_Metal_Tray
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Metallschale war an der Unterseite schwarz. Wie oft war diese Schale wohl schon erhitzt worden?";
            else
                return "The metal bowl was black on the underside. How often had this bowl been heated?";
        }
    }
    public static string Adv_I10_Darkness_Machine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ehrfürchtig betrachtete ich das Gerät. Ich hatte es sofort als die wertvolle Dunkelheitsmaschine erkannt, die Meister Gunnar vor kurzem im Unterricht gezeigt hatte. Damit konnte man einem Gegenstand sämtliches Licht entziehen? Und warum? Damit er neues, magisches Licht aufnehmen konnte. Ein beeindruckendes Beispiel fortgeschrittener Magie, von dem ich gerne mehr verstanden hätte. Schade, dass ich gerade dabei war, mein Studium gegen die Wand zu fahren.<br>Auf der Oberseite der Maschine befand sich [I:I10_Switch]ein Schalter[/I] und direkt daneben [I:I10_Hatch]eine Klappe[/I].";
            else
                return "I looked at the device in awe. I had immediately recognized it as the precious darkness machine that Master Gunnar had recently shown me in class. You could use it to remove all light from an object? And why? So that he could absorb new, magical light. An impressive example of advanced magic that I would have liked to understand more about. Too bad I was just about to drive my studies into the wall.<br>On the top of the machine there was [I:I10_Switch]a switch[/I] and right next to it [I:I10_Hatch]a flap[/I].";
        }
    }
    public static string Adv_I10_Darkness_Machine_a
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Klappe war geöffnet und gab den Blick auf [I:I10_Opening]eine darunter liegende Öffnung[/I] frei.";
            else
                return "The flap was open, revealing [I:I10_Opening]an opening[/I] underneath.";
        }
    }
    public static string Adv_I10_Hatch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In [I:I10_Darkness_Machine]der Dunkelheitsmaschine[/I] befand ich eine kleine Klappe.";
            else
                return "In [I:I10_Darkness_Machine]the darkness machine[/I] I found a small flap.";
        }
    }
    public static string Adv_I10_Opening
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Unter [I:I10_Hatch]der Klappe[/I] an [I:I10_Darkness_Machine]der Dunkelheitsmaschine[/I] lag eine kleine Öffnung.";
            else
                return "Under [I:I10_Hatch]the hatch[/I] on [I:I10_Darkness_Machine]the darkness machine[/I] was a small opening.";
        }
    }
    public static string Adv_I10_Switch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Ein/Aus-Schalter.";
            else
                return "An on/off switch.";
        }
    }
    public static string Adv_I10_Giant_Mortar
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein sehr großer Mörser, in dem Meister Gunnar vermutlich seine Pülverchen zusammenstößelte.";
            else
                return "A very large mortar in which Master Gunnar probably pounded his powders together.";
        }
    }
    public static string Adv_I10_Labor_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Tür in der Westwand des Labors führte nach draußen zum Flur.";
            else
                return "The door in the west wall of the lab led outside to the corridor.";
        }
    }
    public static string Adv_I11_Left_Shelf
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Links von mir befand sich ein hohes Regal.";
            else
                return "There was a high shelf to my left.";
        }
    }
    public static string Adv_I11_Right_Shelf
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Rechts von mir befand sich ein hohes Regal.";
            else
                return "There was a high shelf to my right.";
        }
    }
    public static string Adv_I11_Bird_Stand
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf der Vogelstange saß eine - festgekettete - [P:Person_Magpie]ausgestopfte Elster[/P].";
            else
                return "On the bird perch sat a - chained - [P:Person_Magpie]stuffed magpie[/P].";
        }
    }
    public static string Adv_I12_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine angedetschte Tür in der Nordwand führte zurück zum Flur.";
            else
                return "A door in the north wall led back to the hallway.";
        }
    }
    public static string Adv_I12_Wardrobe
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der wuchtige Kleiderschrank war mit kitschigen Motiven bemalt. Er nahm gefühlt die eine Hälfe des Raumes ein. ";
            else
                return "The massive closet was painted with kitschy motifs. It felt like it took up half of the room. ";
        }
    }
    public static string Adv_I12_Bed
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein feudales Bett, wie geschaffen für ein sinnenfrohes Lotterleben. Leider passte der Rest des Raumes überhaupt nicht dazu.";
            else
                return "A feudal bed, as if made for a sensual lotter life. Unfortunately, the rest of the room didn't match it at all.";
        }
    }
    public static string Adv_I12_Matress
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine sehr dicke, teure Matratze mit XXL-Ausmaßen. Groß genug, um darauf eine Ferienwohnung zu errichten.";
            else
                return "A very thick, expensive mattress with XXL dimensions. Big enough to build a vacation apartment on.";
        }
    }
    public static string Adv_I13_Drawer
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine hölzerne Schublade in der Anrichte.";
            else
                return "A wooden drawer in the sideboard.";
        }
    }
    public static string Adv_I13_Door_White
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine weiße Tür in der westlichen Wand führte zurück zum Flur.";
            else
                return "A white door in the western wall led back to the hallway.";
        }
    }
    public static string Adv_I13_Cupboard
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein wenig aufregender Küchenschrank stand an der Wand.";
            else
                return "An unexciting kitchen cupboard stood against the wall.";
        }
    }
    public static string Adv_I13_Fridge
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein sehr moderner magischer Kühlschrank, wie dafür gemacht, köstliche Leckereien lange frisch zu halten.";
            else
                return "A very modern magic fridge, made to keep delicious treats fresh for a long time.";
        }
    }
    public static string Adv_I13_Sideboard
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf der Anrichte stand allerlei Zeug rum, dass mich absolut null interessierte.";
            else
                return "There was all sorts of stuff on the sideboard that was of absolutely no interest to me.";
        }
    }
    public static string Adv_I13_Freezer
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "An der Unterseite des Kühlschranks befand sich ein großes Gefrierfach.";
            else
                return "There was a large freezer compartment at the bottom of the fridge.";
        }
    }
    public static string Adv_I14_Mirror
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein gewöhnlicher Badezimmerspiegel, bis auf den Umstand, dass jemand etwas mit einem Permanentmarker [I:I14_Writing]einen Schriftzug[/I] auf den Spiegel hinterlassen hatte.";
            else
                return "An ordinary bathroom mirror, except for the fact that someone had left some [I:I14_Writing]writing[/I] on the mirror with a permanent marker.";
        }
    }
    public static string Adv_I14_Door_Red
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine rote Tür in der östlichen Wand führte zurück zum Flur.";
            else
                return "A red door in the eastern wall led back to the hallway.";
        }
    }
    public static string Adv_I14_Writing
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Schriftzug besagte: \"Labor abschließen nicht vergessen!\" Hatte der Meister Angst vor ungebetenen Besuchern in seinem magischen Versteck, oder lags an den Bewohnern seines Labors?";
            else
                return "The lettering said: \\\"Don't forget to lock the lab!\" Was the master afraid of uninvited visitors in his magical lair, or was it the inhabitants of his laboratory?";
        }
    }
    public static string Adv_I14_Kacheln
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Badezimmer war mit sehr gewöhnlich aussehenden grauen Kacheln gekachelt.";
            else
                return "The bathroom was tiled with very ordinary looking gray tiles.";
        }
    }
    public static string Adv_I14_Sink
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eins von diesen pseudomodernen hohen runden Dingern, die ebenso so stylisch wie teuer aussahen.";
            else
                return "One of those pseudo-modern high round things that looked as stylish as they were expensive.";
        }
    }
    public static string Examine_I14_Kacheln_Kachel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine [I:I14_Special_Tile]der Kacheln[/I] hatte eine etwas andere Farbe als die anderen.";
            else
                return "One [I:I14_Special_Tile]of the tiles[/I] had a slightly different color than the others.";
        }
    }
    public static string Adv_I14_Bathtub
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine große Badewanne mit magischem Whirlpool-Einsatz.";
            else
                return "A large bathtub with a magical whirlpool insert.";
        }
    }
    public static string Adv_I14_Special_Tile
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Kachel war gar nicht echt, sondern eine Projektion. Kaum hatte ich das gedacht, verschwand sie auch schon und [I:I14_Opening]eine Öffnung[/I] wurde sichtbar dahinter.";
            else
                return "The tile wasn't real at all, but a projection. As soon as I thought that, it disappeared and [I:I14_Opening]an opening[/I] became visible behind it.";
        }
    }
    public static string Adv_I14_Toilet
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine ganz gewöhnliche Toilette. Wo blieb hier die Magie, Meister Gunnar?";
            else
                return "An ordinary toilet. Where was the magic here, Master Gunnar?";
        }
    }
    public static string Adv_I14_Opening
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Dort, wo sich die Projektion einer Fliese befunden hatte, befand sich nun eine kachelgroße Öffnung in der Wand.";
            else
                return "Where the projection of a tile had been, there was now a tile-sized opening in the wall.";
        }
    }
    public static string Adv_I14_Flushing
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine unmagische Toilettenspülung.";
            else
                return "An unmagical toilet flush.";
        }
    }

    public static string Owl_Dialog_Start_Long
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuh, uhuuh, wer stört meinen Schlaf?";
            else
                return "Hoo hoo, who's disturbing my sleep?";
        }
    }
    public static string Owl_Dialog_Start_Long2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich. Passt dir daran irgendwas nicht?";
            else
                return "Me. Is there anything you don't like about it?";
        }
    }
    public static string Owl_Dialog_Start_Long3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, äh.... Uhuuh, uhuuh, was kann ich für dich tun?";
            else
                return "Well, uh.... Hoo hoo, what can I do for you?";
        }
    }
    public static string Owl_Dialog_Start_Short
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuh, uhuuh, was kann ich für dich tun?";
            else
                return "Hoo hoo, what can I do for you?";
        }
    }
    public static string Owl_Dialog_Job
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was genau ist dein Job hier?";
            else
                return "What exactly is your job here?";
        }
    }
    public static string Owl_Dialog_Job2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuh, uhuuh, ich soll dieses Atrium mit meiner Weisheit durchdringen... ";
            else
                return "Hoo hoo, I'm supposed to penetrate this atrium with my wisdom... ";
        }
    }
    public static string Owl_Dialog_Job3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ok, das klappt schon mal nur so mittel.";
            else
                return "Ok, that only works moderately well.";
        }
    }
    public static string Owl_Dialog_Job4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... und dafür sorgen, dass nicht jeder Hinz und Kunz in der Bibliothek Unsinn anstellt. Nein, frag nicht, welcher Hinz und Kunz gemeint sind. Meister Gunnar hat mich immer nur komisch angeschaut, wenn ich danach gefragt habe.";
            else
                return "... ... and make sure that not Hinz and Kunz are up to mischief in the library. No, don't ask me which Hinz and Kunz are meant. Master Gunnar always just looked at me funny when I asked.";
        }
    }
    public static string Owl_Dialog_Klaue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was kannst du mir über die Klaue sagen?";
            else
                return "What can you tell me about the claw?";
        }
    }
    public static string Owl_Dialog_Klaue2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, nicht viel. Es ist ein Edelstein mit magischen Fähigkeiten. Sie belebt untote Materie kurzzeitig. Hält nicht lange vor, aber besser als nichts.";
            else
                return "Well, not much. It's a gemstone with magical powers. It revives undead matter for a short time. Doesn't last long, but it's better than nothing.";
        }
    }
    public static string Owl_Dialog_Klaue3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sie ist ja sicher sehr wertvoll. Weißt du zufällig, wer einen solchen Edelstein kaufen würde?";
            else
                return "It is certainly very valuable. Do you happen to know who would buy such a gemstone?";
        }
    }
    public static string Owl_Dialog_Klaue4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Zum Glück steht er ja nicht zum Verkauf! Aber es gibt da ganz sicher viele Schwarzmagier, die würden ein Vermögen für diesen Stein hinlegen. Sie würden ganze Zivilisationen damit in den Untergang stürzen, aber was so ein echter Schwarzmagier ist, den kümmert das ja nicht...";
            else
                return "Fortunately, it's not for sale! But there are certainly many black magicians who would spend a fortune on this stone. They would bring entire civilizations to ruin with it, but if you're a real black magician, you don't care...";
        }
    }
    public static string Owl_Dialog_Bibliothek
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie kommt man eigentlich in die Bibliothek?";
            else
                return "How do you actually get into the library?";
        }
    }

    public static string Owl_Dialog_Bibliothek2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Indem man am großen Bibliotheksquiz teilnimmt und alle 3 Fragen richtig beantwortet! Und los gehts mit Frage 1: Welche Unterwäsche-Marke bevorzugt der Meister?";
            else
                return "By taking part in the big library quiz and answering all 3 questions correctly! And let's start with question 1: Which underwear brand does the master prefer?";
        }
    }
    public static string Owl_Dialog_Woin5Jahren
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Einen tollen Job als Türwächter hast du hier. Wo siehst du dich eigentlich in deiner beruflichen Weiterentwicklung in 5 Jahren?";
            else
                return "You have a great job here as a door guard. Where do you see yourself in your professional development in 5 years' time?";
        }
    }

    public static string Owl_Dialog_Woin5Jahren2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuh, uhuuh, bis dahin möchte ich zum Senior Bibliothekstür Beauftragten aufsteigen und ein ganzes Team an ausgestopften Türwächter-Eulen betreuen.";
            else
                return "Hoo hoo, by then I want to be promoted to Senior Library Door Supervisor and supervise a whole team of stuffed door guard owls.";
        }
    }
    public static string Owl_Dialog_Woin5Jahren3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Exzellent! Und da die Anzahl der zu bewachenden Bibliothekstüren gleich bleibt, habt ihr automatisch mehr Zeit für völlig überflüssige Bürokratie!";
            else
                return "Excellent! And since the number of library doors to be guarded remains the same, you automatically have more time for completely superfluous bureaucracy!";
        }
    }
    public static string Owl_Dialog_Woin5Jahren4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuh, uhuuh, welch geniale Idee! Wir werden Vordrucke mit mehreren Durchschlägen bekommen, mit völlig unverständlichen Feldern zum Ankreuzen!";
            else
                return "Hoo hoo, what a brilliant idea! We'll get forms with several carbon copies, with completely incomprehensible boxes to tick!";
        }
    }

    public static string Owl_Dialog_MeisterGunnar
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was kannst du mir über Meister Gunnar erzählen? Ist der wirklich so verschroben, wie man immer hört?";
            else
                return "What can you tell me about Master Gunnar? Is he really as eccentric as you always hear?";
        }
    }
    public static string Owl_Dialog_MeisterGunnar2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du meinst, ob er das nur vortäuscht und in Wirklichkeit dralle Blondinen hierher einlädt, um ihnen die 'Geheimnisse der Magie' hautnah zu zeigen?";
            else
                return "You mean, is he just faking it and really inviting buxom blondes here to show them the 'secrets of magic' up close?";
        }
    }
    public static string Owl_Dialog_MeisterGunnar3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Äh, klingt interessant. Rede weiter.";
            else
                return "Uh, sounds interesting. Keep talking.";
        }
    }
    public static string Owl_Dialog_MeisterGunnar4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wer weiß, vielleicht stimmt ja auch das sorgfältig gehegte Image des verschrobenen Grantlers, der am liebsten mit ausgestopften Tieren und unbelebten Gegenständen redet, weil ihn Menschen überfordern. Die Wahrheit ist... nun... kompliziert... aber glücklicherweise kann sie uns egal sein.";
            else
                return "Who knows, maybe the carefully cultivated image of the cranky grump who prefers to talk to stuffed animals and inanimate objects because people overwhelm him is true. The truth is... well... complicated... but fortunately we don't have to worry about it.";
        }
    }
    public static string Owl_Dialog_Quiz1_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uh, ist die Frage nicht zu persönlich?";
            else
                return "Uh, isn't the question too personal?";
        }
    }
    public static string Owl_Dialog_Quiz1_1_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Schon, aber da der Meister sie selbst ausgesucht hat, kann dir das wirklich egal sein. Uhuuh, uhuuh, falsche Antwort. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Yes, but since the master chose them himself, you really couldn't care less. Hoo hoo, wrong answer. Get back to me if you want to try again.";
        }
    }
    public static string Owl_Dialog_Quiz1_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich setze den 50:50 Joker!";
            else
                return "I'll bet the 50:50 joker!";
        }
    }
    public static string Owl_Dialog_Quiz1_2_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuuh, uhuuuh, leider gibts keinen Joker, also war dies eine falsche Antwort. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Hoo hoo, unfortunately there is no joker, so this was a wrong answer. Get in touch if you want to try again.";
        }
    }
    public static string Owl_Dialog_Quiz1_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es ist eine No-Name-Marker von einem großen Online-Versandhaus.";
            else
                return "It is a no-name marker from a large online mail order company.";
        }
    }
    public static string Owl_Dialog_Quiz1_3_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du solltest dem Meister ruhig etwas mehr Geschmack zutrauen. Leider falsch. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "You should trust the master with a little more taste. Unfortunately wrong. Get in touch if you want to try again.";
        }
    }
    public static string Owl_Dialog_Quiz1_4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Edel-Unterwäsche der berühmten Marke 'Karl Lagerhaus'.";
            else
                return "Fine underwear from the famous brand 'Karl Lagerhaus'.";
        }
    }
    public static string Owl_Dialog_Quiz1_4_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Exzellent. Nur die und keine andere Wäsche. Sehr gut, kommen wir zur zweiten Frage: Wer hat einst die Ritterrüstung auf dem Flur getragen?";
            else
                return "Excellent. Only these and no other linen. Very well, let's move on to the second question: who once wore the knight's armor in the hallway?";
        }
    }
    public static string Owl_Dialog_Quiz2_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Heißen diese Ritter nicht sowieso alle 'Kunibert'? Dann wirds diesmal sicher auch so sein.";
            else
                return "Aren't these knights all called 'Kunibert' anyway? Then it'll certainly be the same this time.";
        }
    }
    public static string Owl_Dialog_Quiz2_1_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, dieser Ritter hieß nicht Kunibert. Damit wäre auch deine These logisch vollständig widerlegt. Also leider falsch. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Well, this knight was not called Kunibert. This would also completely refute your thesis logically. So unfortunately it's wrong. Get in touch if you want to try again.";
        }
    }
    public static string Owl_Dialog_Quiz2_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Würde es dich sehr verwirren, wenn ich jetzt einen Telefonjoker einsetzen würde?";
            else
                return "Would you be very confused if I were to use a telephone joker now?";
        }
    }
    public static string Owl_Dialog_Quiz2_2_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nein, würde es nicht, weil ich nicht mal weiß, was ein Telefon ist. Das muss ich also leider als falsche Antwort werten. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "No, it wouldn't, because I don't even know what a phone is. So I'm afraid that's the wrong answer. Get in touch if you want to try again.";
        }
    }
    public static string Owl_Dialog_Quiz2_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sind Namen nicht eigentlich Schall und Rauch?";
            else
                return "Aren't names just smoke and mirrors?";
        }
    }
    public static string Owl_Dialog_Quiz2_3_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ja, sind sie. Außer denen, die bei einem Quiz abgefragt werden. Das muss ich also leider als falsche Antwort werten. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Yes, they are. Except the ones that are asked in a quiz. So I'm afraid that's a wrong answer. Get in touch if you want to try again.";
        }
    }
    public static string Owl_Dialog_Quiz2_4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Rüstung war dereinst Eigentum von Ritter Norbert, dem Reinlichen.";
            else
                return "The armor was once the property of Knight Norbert the Clean.";
        }
    }
    public static string Owl_Dialog_Quiz2_4_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuh, uhuuu, das ist richtig! Sehr gut, damit stehst du im Finale! Kommen wir zur dritten Frage: Was ist das einzige Tier, das der Meister wirklich liebt?";
            else
                return "Huu-huu, that's right! Very good, that puts you in the final! Let's move on to the third question: What is the only animal that the master really loves?";
        }
    }
    public static string Owl_Dialog_Quiz3_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ach, ich weiß nicht. Das ist schon wieder so eine verdammt persönliche Frage.";
            else
                return "Oh, I don't know. That's another damn personal question.";
        }
    }
    public static string Owl_Dialog_Quiz3_1_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ja, ist es. Und deine Antwort war leider falsch. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Yes, it is. And unfortunately your answer was wrong. Get in touch if you want to try again.";
        }
    }
    public static string Owl_Dialog_Quiz3_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich denke, sein Lieblingstier ist die Eule. Welche Kreatur strahlt sonst soviel Anmut und Weisheit aus?";
            else
                return "I think his favorite animal is the owl. What other creature radiates so much grace and wisdom?";
        }
    }
    public static string Owl_Dialog_Quiz3_2_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine weise, kluge und - leider auch - falsche Antwort. Nein, die Eulen liebt er nicht. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "A wise, clever and - unfortunately - wrong answer. No, he doesn't love the owls. Get in touch if you want to try again.";
        }
    }
    public static string Owl_Dialog_Quiz3_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Fisch muss es sein! Nervt nicht rum, schwimmt sinnlos im Kreis und hält die Klappe. Das ideale Tier für Meister Gunnar.";
            else
                return "It has to be the fish! Doesn't get on your nerves, swims pointlessly in circles and keeps its mouth shut. The ideal animal for Master Gunnar.";
        }
    }
    public static string Owl_Dialog_Quiz3_2_2_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Fisch passt ganz gut aufs Profil, aber andere Kreaturen passen eben noch besser. Nein, die Fische liebt er nicht. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "The fish fits the profile quite well, but other creatures fit even better. No, he doesn't love the fish. Get in touch if you want to try again.";
        }
    }
    public static string Owl_Dialog_Quiz3_4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Quietscheentchen! Wo wurde jemals soviel reine Liebe gefunden wie zwischen einem Mann und seinem Quietscheentchen?";
            else
                return "The squeaky duck! Where has so much pure love ever been found as between a man and his squeaky duck?";
        }
    }
    public static string Owl_Dialog_Quiz3_4_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wusstest du, dass Menschen mir Angst machen? Ja, die Antwort ist richtig. Herzlichen Glückwunsch. Der Weg ist frei.";
            else
                return "Did you know that people scare me? Yes, the answer is correct. Congratulations. The path is clear.";
        }
    }
    public static string Owl_Dialog_Ende
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich geh dann mal Eulen nach Athen tragen.";
            else
                return "I'll go carry owls to Athens.";
        }
    }
    public static string Owl_Library_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es summte vernehmlich, und dann klackte irgendein Mechanismus in der Bibliothekstür.";
            else
                return "There was an audible buzz and then some mechanism in the library door clicked.";
        }
    }


    // Dialoge

    // Buch 
    public static string Book_Dialog_Ende
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Buch zuklappen.";
            else
                return "Close the book.";
        }
    }
    public static string Book_Dialog_Start
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich schlug das Buch auf. Auf der rechten Seite befand sich das Inhaltsverzeichnis. Von der linken Seite grinste mich der schmierige Meister Gunnar an.";
            else
                return "I opened the book. On the right-hand page was the table of contents. From the left-hand page, the smarmy Master Gunnar grinned at me.";
        }
    }
    public static string Book_Dialog_Gunnar
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Über Meister Gunnar";
            else
                return "About Master Gunnar";
        }
    }
    public static string Book_Dialog_Gunnar2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Dieses Kapitel berichtete gewohnt bescheiden über Meister Gunnar: Meistermagier, brillanter Wissenschaftler, Sexgott... Daneben prangte eine sehr lebensechte, aber unfassbar schmierige Lithografie von Meister Gunnar. Ich ließ das Buch sinken und holte erst mal kräftig Luft.";
            else
                return "This chapter gave the usual modest account of Master Gunnar: master magician, brilliant scientist, sex god... Next to it was a very lifelike but incredibly greasy lithograph of Master Gunnar. I put the book down and took a deep breath.";
        }
    }
    public static string Book_Dialog_Teleports
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Über Kurzstreckenteleports";
            else
                return "About short-distance teleports";
        }
    }
    public static string Book_Dialog_Teleports2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "'Die wichtigsten Hardfacts über Kurzstreckenteleports!<br>Man benötigt 3 Zutaten, erhitze diese, bis sie zu Schlacke verbrennen, zerreibe diese dann zu Pulver und entzünde dies. Und dann: \"Kabumm!\"<br>Die Zutaten sind:<br>- Ein Mondstein<br>- eine goldene Münze<br>- ein Wunderwarzenschwamm'<br>Na, das klang ja fast machbar. War das mein Ticket aus diesem vermaledeiten Versteck?";
            else
                return "'The most important hard facts about short-haul teleports!<br>You need 3 ingredients, heat them until they burn to slag, then grind them into powder and ignite this. And then: \"Kaboom!\"<br>The ingredients are:<br>- a moon stone<br>- a golden coin<br>- a wonder wart sponge'<br>Well, that almost sounded feasible. Was that my ticket out of that damn hiding place?";
        }
    }
    public static string Book_Dialog_Sextips
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "So optimieren Sie Ihr Liebesleben!";
            else
                return "How to optimize your love life!";
        }
    }
    public static string Book_Dialog_Sextips2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "'Magie kennt nicht nur hervorragende Aphrodisiaka, sondern kann auch bei allen anderen Belangen der geschlechtlichen Liebe zur Förderung und Erbauung eingesetzt werden. Es ist also wahr: Wenn Sie den perfekten Liebhaber suchen, dann werden Sie...'<br>Ich ließ das Buch sinken und starrte ein paar Sekunden einfach nur ins Nichts.";
            else
                return "'Magic not only knows excellent aphrodisiacs, but can also be used to promote and edify all other aspects of sexual love. So it's true: if you are looking for the perfect lover, then you will...'<br>I put the book down and just stared into nothingness for a few seconds.";
        }
    }
    public static string Book_Dialog_Mondsteine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Über die Herstellung von Mondsteinen";
            else
                return "About the production of moonstones";
        }
    }

    public static string Book_Dialog_Mondsteine2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "'Die Herstellung von Mondsteinen ist dank meiner Erfindung der Dunkelheitsmaschine fast ein Kinderspiel geworden. Man nehme einen gewöhnlichen Kiesel und entziehe ihm mit meiner neuartigen Erfindung jegliches Licht. Zurück bleibt ein Stein, der vollkommen lichtlos ist und der unfassbare Schwärze ausstrahlt. Das einzige, was ihn nun dazu bewegen kann, sich noch einmal mit Licht anzureichern, ist helles, konzentriertes Mondlicht. Dazu muss man allerdings möglichst nah an den Mond heran. Für dieses Problem habe ich noch keine gute Lösung gefunden, aber Ihnen fällt schon was ein! Wie man hört, können manche Vögel sehr hoch fliegen. Vielleicht reicht das ja schon, um den Stein ausreichend nah ans Mondlicht heran zu bringen.'";
            else
                return "'The production of moonstones has become almost child's play thanks to my invention of the darkness machine. Take an ordinary pebble and remove all light from it using my new invention. What remains is a stone that is completely devoid of light and radiates incomprehensible blackness. The only thing that can make it fill up with light again is bright, concentrated moonlight. To do this, however, you have to get as close to the moon as possible. I haven't found a good solution to this problem yet, but you'll think of something! I've heard that some birds can fly very high. Maybe that's enough to get the stone close enough to the moonlight.";
        }
    }

    // Bibliothekarin
    public static string Lib_Dialog_Ende
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich finde alleine raus, danke.";
            else
                return "I'll find out on my own, thanks.";
        }
    }
    public static string Lib_Dialog_Start_Long
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Na, das war ja mal wieder an der Zeit. Wahrscheinlich bin ich die Letzte, die hier wiederbelebt worden ist. Wo ist eigentlich Meister Gunnar? Er steht doch sonst mehr auf diese jungen, hübschen...";
            else
                return "Well, it was about time again. I'm probably the last one to be revived here. Where is Master Gunnar anyway? He's usually more into these young, pretty...";
        }
    }
    public static string Lib_Dialog_Start_Long2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hey, ich habe auch Gefühle! Also mal bitte Ruhe. Und Meister Gunnar ist nicht da. Ist das ein Problem für dich?";
            else
                return "Hey, I have feelings too! So please be quiet. And Master Gunnar isn't here. Is that a problem for you?";
        }
    }
    public static string Lib_Dialog_Start_Long3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ganz im Gegenteil! Es ist geradezu... Nun, kommen wir zum Thema. Was kann ich für dich tun?";
            else
                return "Quite the opposite! It's downright... Well, let's get to the point. What can I do for you?";
        }
    }

    public static string Lib_Dialog_Start_Short
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, was kann ich für dich tun?";
            else
                return "Well, what can I do for you?";
        }
    }
    public static string Lib_Dialog_Belebung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was ist das für ein Gefühl für dich, von dieser Klaue belebt zu werden?";
            else
                return "What does it feel like for you to be animated by this claw?";
        }
    }
    public static string Lib_Dialog_Belebung2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es ist ... nun... unglaublich... seltsam. Ich weiß gar nicht, ob es dir aufgefallen ist. Aber ich bin eigentlich tot!";
            else
                return "It's ... well... unbelievable... strange. I don't even know if you've noticed. But I'm actually dead!";
        }
    }
    public static string Lib_Dialog_Belebung3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Verdammt, jetzt wo du es sagst! Das ist ja unglaublich!";
            else
                return "Damn, now that you mention it! That's unbelievable!";
        }
    }
    public static string Lib_Dialog_Belebung4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Genau. Und dank der Klaue fühle ich mich einfach jung und frisch wie am ersten Tag.";
            else
                return "Exactly. And thanks to the claw, I feel as young and fresh as on the first day.";
        }
    }
    public static string Lib_Dialog_Klaue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was weißt du über die Klaue?";
            else
                return "What do you know about the claw?";
        }
    }
    public static string Lib_Dialog_Klaue2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, sie wird urkundlich zum ersten mal im Jahr 1487 in den Aufzeichnungen des Grafen von Grafenhausen erwähnt und...";
            else
                return "Well, it was first mentioned in documents in 1487 in the records of the Count of Grafenhausen and...";
        }
    }
    public static string Lib_Dialog_Klaue3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich könnte schwören, über dieses tolle Juwel gibts sicher auch noch weit spannendere Details zu berichten...";
            else
                return "I could swear that there are certainly even more exciting details to report on this great jewel...";
        }
    }
    public static string Lib_Dialog_Klaue4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ja, kann sein. Hab ich dich gelangweilt? Das passiert mir leider öfters.";
            else
                return "Yes, maybe. Have I bored you? Unfortunately, that happens to me quite often.";
        }
    }

    public static string Lib_Dialog_Buecher
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du hast hier ja schon sehr gefährliche Bücher, kann das sein?";
            else
                return "You already have some very dangerous books here, could that be?";
        }
    }
    public static string Lib_Dialog_Buecher2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Gefährlich? Ach, soweit würde ich nicht gehen. Manche sind sehr temperamentvoll, das stimmt natürlich. Mehrere von ihnen töten natürlich gerne ihre Leser...";
            else
                return "Dangerous? Oh, I wouldn't go that far. Some are very temperamental, of course. Several of them like to kill their readers, of course...";
        }
    }
    public static string Lib_Dialog_Buecher3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... natürlich. Wer kann es ihnen verdenken?";
            else
                return "... of course. Who can blame them?";
        }
    }
    public static string Lib_Dialog_Buecher4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... und außerdem enthalten sie ein wahnsinniges Wissen, das natürlich schon wieder so wahnsinnig ist, dass außer Meister Gunnar ohnehin niemand etwas mit diesen Büchern anfangen kann.";
            else
                return "... and they also contain an insane amount of knowledge, which is of course so insane that nobody except Master Gunnar can do anything with these books anyway.";
        }
    }
    public static string Lib_Dialog_Leihfrist
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Dass man geköpft und gevierteilt wird, wenn man in einer Bibliothek die Leihfrist überschreitet - das ist aber ein Ammenmärchen, oder?";
            else
                return "That you'll be beheaded and quartered if you exceed the loan period in a library - that's an old wives' tale, isn't it?";
        }
    }
    public static string Lib_Dialog_Leihfrist2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ach das... klar, das stimmt natürlich so nicht.";
            else
                return "Oh that... Of course, that's not true.";
        }
    }
    public static string Lib_Dialog_Leihfrist3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Da bin ich ja erleichtert. Es kam mir immer ganz schön übertrieben vor.";
            else
                return "I'm relieved about that. It always seemed pretty exaggerated to me.";
        }
    }
    public static string Lib_Dialog_Leihfrist4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ach ja? Mir nicht! In Wirklichkeit wird einem bei lebendigem Leibe die Haut abgezogen und der geschundene Leib häppchenweise frittiert. Ha, nimm das, Leihfristüberziehungsübeltäter!";
            else
                return "Oh yes, not me! In reality, your skin is peeled off while you're still alive and your maltreated body is deep-fried in morsels. Ha, take that, overdue borrowing offender!";
        }
    }
    public static string Lib_Dialog_Meister
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was weißt du über Meister Gunnar?";
            else
                return "Was weißt du über Meister Gunnar?";
        }
    }
    public static string Lib_Dialog_Meister2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, ein weiser alter Mann, dessen Vorliebe für blutjunge Gespielinnen durchaus stärker ausgeprägt ist als die Vorliebe blutjunger Gespielinnen für alte verwelkte Zauberer. Darüber hinaus ist er ein passabler Zauberer.";
            else
                return "Nun, ein weiser alter Mann, dessen Vorliebe für blutjunge Gespielinnen durchaus stärker ausgeprägt ist als die Vorliebe blutjunger Gespielinnen für alte verwelkte Zauberer. Darüber hinaus ist er ein passabler Zauberer.";
        }
    }
    public static string Lib_Dialog_Meister3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Gibts denn nichts an ihm, das dich beeindruckt?";
            else
                return "Gibts denn nichts an ihm, das dich beeindruckt?";
        }
    }
    public static string Lib_Dialog_Meister4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, wenn du so direkt fragst... Nein.";
            else
                return "Nun, wenn du so direkt fragst... Nein.";
        }
    }

    public static string Snake_Dialog_Ende
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich schlängel mich mal davon.";
            else
                return "Ich schlängel mich mal davon.";
        }
    }
    public static string Snake_Dialog_Start_Long
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Äh, ja? Wasss gibtsss?";
            else
                return "Äh, ja? Wasss gibtsss?";
        }
    }
    public static string Snake_Dialog_Start_Long2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du wirkst so verpeilt. Alles okay bei dir?";
            else
                return "Du wirkst so verpeilt. Alles okay bei dir?";
        }
    }
    public static string Snake_Dialog_Start_Long3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Äh nein. Vorhin war ich noch tot, davor mal am Leben, davor wieder tot... Wer soll sich das eigentlich merken können?";
            else
                return "Äh nein. Vorhin war ich noch tot, davor mal am Leben, davor wieder tot... Wer soll sich das eigentlich merken können?";
        }
    }
    public static string Snake_Dialog_Start_Short
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Äh, ja? Wasss gibtsss?";
            else
                return "Äh, ja? Wasss gibtsss?";
        }
    }
    public static string Snake_Dialog_Belebung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich habe dich mittels modernster Magie wiederbelebt. Ist das nicht toll?";
            else
                return "Ich habe dich mittels modernster Magie wiederbelebt. Ist das nicht toll?";
        }
    }
    public static string Snake_Dialog_Belebung2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Äh, was ist daran bitte toll? Ich war ganz zzzzufrieden damit, tot und ausgestopft zu sein. Das Schlimmste aber ist das ewige hin und her. Ich lag gerade mal für einige Jahre tot in diesem Regal herum, jetzt muss ich mich schon wieder umgewöhnen.";
            else
                return "Äh, was ist daran bitte toll? Ich war ganz zzzzufrieden damit, tot und ausgestopft zu sein. Das Schlimmste aber ist das ewige hin und her. Ich lag gerade mal für einige Jahre tot in diesem Regal herum, jetzt muss ich mich schon wieder umgewöhnen.";
        }
    }
    public static string Snake_Dialog_Belebung3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ans Totsein muss man sich nicht gewöhnen, das passiert alles von ganz allein.";
            else
                return "Ans Totsein muss man sich nicht gewöhnen, das passiert alles von ganz allein.";
        }
    }
    public static string Snake_Dialog_Belebung4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du hassssst natürlich voll den Durchblick, du neunmalkluger Nichttoter.";
            else
                return "Du hassssst natürlich voll den Durchblick, du neunmalkluger Nichttoter.";
        }
    }
    public static string Snake_Dialog_Herkunft
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Und wo kommst du ursprünglich her?";
            else
                return "Und wo kommst du ursprünglich her?";
        }
    }
    public static string Snake_Dialog_Herkunft2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Woher soll ich das wissen? Ich kann mich noch dran erinnern, früher durch das tiefe Gras einer Wiese geschlängelt zu sein. Dann plötzlich packt mich jemand - un dann wird es schwarz um mich.";
            else
                return "Woher soll ich das wissen? Ich kann mich noch dran erinnern, früher durch das tiefe Gras einer Wiese geschlängelt zu sein. Dann plötzlich packt mich jemand - un dann wird es schwarz um mich.";
        }
    }
    public static string Snake_Dialog_Herkunft3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das klingt ja schrecklich. Aber wer kommt auf die Idee, eine Schlange auszustopfen? Eine eher langweilige wie dich zumal...";
            else
                return "Das klingt ja schrecklich. Aber wer kommt auf die Idee, eine Schlange auszustopfen? Eine eher langweilige wie dich zumal...";
        }
    }
    public static string Snake_Dialog_Herkunft4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Na danke. Das Ausstopfen war zwar unangenehm, aber seitdem sind meine gesamten Zipperlein verschwunden. Ich kann nur jedem empfehlen, sich ausstopfen zu lassen.";
            else
                return "Na danke. Das Ausstopfen war zwar unangenehm, aber seitdem sind meine gesamten Zipperlein verschwunden. Ich kann nur jedem empfehlen, sich ausstopfen zu lassen.";
        }
    }
    public static string Snake_Dialog_Meister
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was kannst du mir über Meister Gunnar sagen?";
            else
                return "Was kannst du mir über Meister Gunnar sagen?";
        }
    }
    public static string Snake_Dialog_Meister2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Er ist unser Meissster hier! Ich persönlich finde ja... aber lassen wir das...";
            else
                return "Er ist unser Meissster hier! Ich persönlich finde ja... aber lassen wir das...";
        }
    }
    public static string Snake_Dialog_Meister3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sprich dich ruhig aus.";
            else
                return "Sprich dich ruhig aus.";
        }
    }
    public static string Snake_Dialog_Meister4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ach, ich finde einfach, ein Großmeister der Magie sollte es irgendwann auch mal hinbekommen, nicht seine Socken überall herumliegen zu lassen.";
            else
                return "Ach, ich finde einfach, ein Großmeister der Magie sollte es irgendwann auch mal hinbekommen, nicht seine Socken überall herumliegen zu lassen.";
        }
    }

    public static string Parrot_Dialog_Ende
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich mache dann mal die Flatter.";
            else
                return "Ich mache dann mal die Flatter.";
        }
    }

    public static string Parrot_Dialog_Start_Long
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Oh, ich bin erwacht. Welch großartiger Moment! Würde mich nicht dein Antlitz eines besseren belehren, so würde ich dies für einen guten Tag halten.";
            else
                return "Oh, ich bin erwacht. Welch großartiger Moment! Würde mich nicht dein Antlitz eines besseren belehren, so würde ich dies für einen guten Tag halten.";
        }
    }
    public static string Parrot_Dialog_Start_Long2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sag mal, hast du mich gerade übelst beleidigt, keine 5 Sekunden, nachdem ich dich wiederbelebt habe?";
            else
                return "Sag mal, hast du mich gerade übelst beleidigt, keine 5 Sekunden, nachdem ich dich wiederbelebt habe?";
        }
    }
    public static string Parrot_Dialog_Start_Long3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Fürwahr, es ist dies nicht der Fall. Da kein gesprochenes Wort das Elend in eurem Gesicht zur Gänze zu erfassen mag, ist jede Beschreibung reine Schönfärberei!";
            else
                return "Fürwahr, es ist dies nicht der Fall. Da kein gesprochenes Wort das Elend in eurem Gesicht zur Gänze zu erfassen mag, ist jede Beschreibung reine Schönfärberei!";
        }
    }
    public static string Parrot_Dialog_Start_Short
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich sehe, deine Schönheit hat seit unserem letzten Gespräch nicht gewinnen können.";
            else
                return "Ich sehe, deine Schönheit hat seit unserem letzten Gespräch nicht gewinnen können.";
        }
    }
    public static string Parrot_Dialog_Belebung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du könntest dich wirklich mal dankbar zeigen, dass ich dich wiederbelebt habe.";
            else
                return "Du könntest dich wirklich mal dankbar zeigen, dass ich dich wiederbelebt habe.";
        }
    }
    public static string Parrot_Dialog_Belebung2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wohlan, das könnte ich wohl. Würde es dir etwas ausmachen, einen alten Kartoffelsack über dein Gesicht zu stülpen, solange ich deine Schönheit preise?";
            else
                return "Wohlan, das könnte ich wohl. Würde es dir etwas ausmachen, einen alten Kartoffelsack über dein Gesicht zu stülpen, solange ich deine Schönheit preise?";
        }
    }
    public static string Parrot_Dialog_Belebung3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Woher kommt bloß diese unbändige Lust, dich in den nächsten Kükenschredder zu stopfen?";
            else
                return "Woher kommt bloß diese unbändige Lust, dich in den nächsten Kükenschredder zu stopfen?";
        }
    }
    public static string Parrot_Dialog_Belebung4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, es kann nicht verwundern, dass deine Seele keinen helleren Lichtschein wirft als dein Angesicht.";
            else
                return "Nun, es kann nicht verwundern, dass deine Seele keinen helleren Lichtschein wirft als dein Angesicht.";
        }
    }
    public static string Parrot_Dialog_Herkunft
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du hältst dich ja schon für was besseres, kann das sein?";
            else
                return "Du hältst dich ja schon für was besseres, kann das sein?";
        }
    }
    public static string Parrot_Dialog_Herkunft2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, nein. Ich BIN etwas besseres. Selbstredend ist es so. Schon immer wollte ich hoch hinaus und zu den Sternen greifen. Dort, nur dort würde ich meinem Schicksal ins Auge blicken.";
            else
                return "Nun, nein. Ich BIN etwas besseres. Selbstredend ist es so. Schon immer wollte ich hoch hinaus und zu den Sternen greifen. Dort, nur dort würde ich meinem Schicksal ins Auge blicken.";
        }
    }
    public static string Parrot_Dialog_Herkunft3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, stattdessen habe ich dich in einem leeren Lagerraum gefunden, ausgestopft und verstaubt. Das muss schon an dir nagen, oder?";
            else
                return "Nun, stattdessen habe ich dich in einem leeren Lagerraum gefunden, ausgestopft und verstaubt. Das muss schon an dir nagen, oder?";
        }
    }
    public static string Parrot_Dialog_Herkunft4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wenn es so wäre, würde ich es einem Fremden niemals gestehen! Ich würde davon berichten, dass es immer schon mein Traum war, mit Holzwolle ausgestopft herum zu liegen und die Vergänglichkeit des Daseins zu zelebrieren. Zum Glück kriege ich ja die meiste Zeit davon gar nichts mit.";
            else
                return "Wenn es so wäre, würde ich es einem Fremden niemals gestehen! Ich würde davon berichten, dass es immer schon mein Traum war, mit Holzwolle ausgestopft herum zu liegen und die Vergänglichkeit des Daseins zu zelebrieren. Zum Glück kriege ich ja die meiste Zeit davon gar nichts mit.";
        }
    }
    public static string Parrot_Dialog_Meister
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was hältst du so von Meister Gunnar?";
            else
                return "Was hältst du so von Meister Gunnar?";
        }
    }
    public static string Parrot_Dialog_Meister2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ach, es fällt mir schwer, dies offen auszusprechen. Wie gerne würde ich seine Wohltaten lobpreisen, bietet er mir doch ein, wenn auch karges, Heim. Ich will nicht undankbar erscheinen, aber... ";
            else
                return "Ach, es fällt mir schwer, dies offen auszusprechen. Wie gerne würde ich seine Wohltaten lobpreisen, bietet er mir doch ein, wenn auch karges, Heim. Ich will nicht undankbar erscheinen, aber... ";
        }
    }
    public static string Parrot_Dialog_Meister3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uh, das klingt ja hoch spannend. Erzähl mir mehr!";
            else
                return "Uh, das klingt ja hoch spannend. Erzähl mir mehr!";
        }
    }
    public static string Parrot_Dialog_Meister4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, sagen wir so: Hier spielen sich die seltsamsten Dinge ab, wenn er mal wieder \"Damenbesuch\" hat. Du würdest es nicht glauben! Seltsamer ist es hier nur dann, wenn Meister Gunnar allein ist. DANN ist es wirklich.... Uh, ich sollte schweigen.";
            else
                return "Nun, sagen wir so: Hier spielen sich die seltsamsten Dinge ab, wenn er mal wieder \"Damenbesuch\" hat. Du würdest es nicht glauben! Seltsamer ist es hier nur dann, wenn Meister Gunnar allein ist. DANN ist es wirklich.... Uh, ich sollte schweigen.";
        }
    }
    public static string Parrot_Dialog_Fliegen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich habe hier einen lichtlosen Stein. Könntest du ihn nehmen und damit Richtung Mond fliegen?";
            else
                return "Ich habe hier einen lichtlosen Stein. Könntest du ihn nehmen und damit Richtung Mond fliegen?";
        }
    }
    public static string Parrot_Dialog_Fliegen2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, dir ist bewusst, dass ich den Mond keinesfalls erreichen werde, so sehr ich es auch versuche?";
            else
                return "Nun, dir ist bewusst, dass ich den Mond keinesfalls erreichen werde, so sehr ich es auch versuche?";
        }
    }
    public static string Parrot_Dialog_Fliegen3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "So nah wie möglich ran reicht ja vielleicht. Du sollst ja nur dafür sorgen, dass sich der lichtlose Stein mit Mondlicht vollsaugt.";
            else
                return "So nah wie möglich ran reicht ja vielleicht. Du sollst ja nur dafür sorgen, dass sich der lichtlose Stein mit Mondlicht vollsaugt.";
        }
    }

    public static string Parrot_Dialog_Fliegen4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das klingt nach einem großartigen Auftrag für einen wie mich, der gerne hoch hinaus will. Gib mir den Stein und wirf mich in den Himmel. Ich werde mein Möglichstes tun!";
            else
                return "Das klingt nach einem großartigen Auftrag für einen wie mich, der gerne hoch hinaus will. Gib mir den Stein und wirf mich in den Himmel. Ich werde mein Möglichstes tun!";
        }
    }
    public static string Throw_Parrot_Mondstein_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte den Papagei in die Luft werfen, aber da fiel mir auf, dass seine Lebensenergie wieder erloschen war.";
            else
                return "Ich wollte den Papagei in die Luft werfen, aber da fiel mir auf, dass seine Lebensenergie wieder erloschen war.";
        }
    }
    public static string Throw_Parrot_Mondstein
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich warf den Papageien in den Himmel. Er flog hoch hinauf und verschwand bald ganz aus meinem Blick.<br>Ich wartete und wartete, aber der Papagei kam nicht zurück.<br>Doch da, plötzlich, sah ich ihn herabsinken, in seinem Schnabel einen glimmenden Stein. Ein Mondstein! Er hatte es tatsächlich geschafft. Er sank herab und landete auf meinem Arm. Bereitwillig ließ er den Mondstein in meine offene Hand fallen.<br>\"Das war fürwahr eine wundervolle Reise. So nah war ich dem Mond noch nie\" seufzte der Papagei, mal ganz ohne Mikroagressionen.";
            else
                return "Ich warf den Papageien in den Himmel. Er flog hoch hinauf und verschwand bald ganz aus meinem Blick.<br>Ich wartete und wartete, aber der Papagei kam nicht zurück.<br>Doch da, plötzlich, sah ich ihn herabsinken, in seinem Schnabel einen glimmenden Stein. Ein Mondstein! Er hatte es tatsächlich geschafft. Er sank herab und landete auf meinem Arm. Bereitwillig ließ er den Mondstein in meine offene Hand fallen.<br>\"Das war fürwahr eine wundervolle Reise. So nah war ich dem Mond noch nie\" seufzte der Papagei, mal ganz ohne Mikroagressionen.";
        }
    }
    public static string Throw_Parrot_Moon
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich sollte den Papageien nicht grundlos durch die Gegend werfen. Auch wenn ihm ein paar Flugübungen sicherlich gut tun würden.";
            else
                return "Ich sollte den Papageien nicht grundlos durch die Gegend werfen. Auch wenn ihm ein paar Flugübungen sicherlich gut tun würden.";
        }
    }

    public static string Magpie_Dialog_Start_Long
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "*Krächz* Du willst doch bestimmt irgendwas. Ich hätte es mir denken können.";
            else
                return "*Krächz* Du willst doch bestimmt irgendwas. Ich hätte es mir denken können.";
        }
    }
    public static string Magpie_Dialog_Start_Long2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wollen wir nicht alle irgendwas? Also warum so unfreundlich?";
            else
                return "Wollen wir nicht alle irgendwas? Also warum so unfreundlich?";
        }
    }
    public static string Magpie_Dialog_Start_Long3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Weil ich eine Elster bin. Wenn ich dich nicht beklaue, will ich dir wenigstens den Tag versauen.";
            else
                return "Weil ich eine Elster bin. Wenn ich dich nicht beklaue, will ich dir wenigstens den Tag versauen.";
        }
    }
    public static string Magpie_Dialog_Start_Short
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "*Krächz* Du schon wieder.";
            else
                return "*Krächz* Du schon wieder.";
        }
    }
    public static string Magpie_Dialog_Ende
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich lasse dich mal wieder in Ruhe. Dann kannst du dir selbst den Tag versauen.";
            else
                return "Ich lasse dich mal wieder in Ruhe. Dann kannst du dir selbst den Tag versauen.";
        }
    }
    public static string Magpie_Dialog_Belebung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Toll so eine Wiederbelebung durch die Klaue, oder?";
            else
                return "Toll so eine Wiederbelebung durch die Klaue, oder?";
        }
    }
    public static string Magpie_Dialog_Belebung2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "So, findest du? Mich erinnert sie eher dran, dass ich hier immer noch festgekettet bin. Danke dafür.";
            else
                return "So, findest du? Mich erinnert sie eher dran, dass ich hier immer noch festgekettet bin. Danke dafür.";
        }
    }
    public static string Magpie_Dialog_Belebung3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Lass dich nicht ärgern! Denke doch lieber an etwas schönes!";
            else
                return "Lass dich nicht ärgern! Denke doch lieber an etwas schönes!";
        }
    }
    public static string Magpie_Dialog_Belebung4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Woran denn bitte? An eine schöne Blumenwiese? Den hellen Sonnenschein? Gibts hier alles nicht. Danke nochmal, dass du mich dran erinnerst.";
            else
                return "Woran denn bitte? An eine schöne Blumenwiese? Den hellen Sonnenschein? Gibts hier alles nicht. Danke nochmal, dass du mich dran erinnerst.";
        }
    }

    public static string Magpie_Dialog_Herkunft
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Und wie hat es dich hierher verschlagen?";
            else
                return "Und wie hat es dich hierher verschlagen?";
        }
    }
    public static string Magpie_Dialog_Herkunft2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ach, blöde Geschichte. Ich fliege in einen Garten, sehe etwas glitzerndes und schnapp danach... zack, magische Falle, mausetot, alles aus.";
            else
                return "Ach, blöde Geschichte. Ich fliege in einen Garten, sehe etwas glitzerndes und schnapp danach... zack, magische Falle, mausetot, alles aus.";
        }
    }
    public static string Magpie_Dialog_Herkunft3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das ist ja schrecklich. Aber wer stiehlt, muss mit sowas rechnen!";
            else
                return "Das ist ja schrecklich. Aber wer stiehlt, muss mit sowas rechnen!";
        }
    }
    public static string Magpie_Dialog_Herkunft4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Klugscheißer. Dabei habe ich mir das Klauen längst abgewöhnt. Wie du sicher weißt, stehen Rabenvögel auch auf coole Tauschgeschäfte. Wir klauen nur, wenn alle Leute um uns herum zu blöd sind, uns einen fairen Tausch anzubieten!";
            else
                return "Klugscheißer. Dabei habe ich mir das Klauen längst abgewöhnt. Wie du sicher weißt, stehen Rabenvögel auch auf coole Tauschgeschäfte. Wir klauen nur, wenn alle Leute um uns herum zu blöd sind, uns einen fairen Tausch anzubieten!";
        }
    }
    public static string Magpie_Dialog_Kette
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Warum hat Meister Gunnar dich hier festgekettet?";
            else
                return "Warum hat Meister Gunnar dich hier festgekettet?";
        }
    }
    public static string Magpie_Dialog_Kette2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ach, blöde Geschichte. Nicht der Rede wert...";
            else
                return "Ach, blöde Geschichte. Nicht der Rede wert...";
        }
    }
    public static string Magpie_Dialog_Kette3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Erzähle ruhig trotzdem. Ich hab Zeit.";
            else
                return "Erzähle ruhig trotzdem. Ich hab Zeit.";
        }
    }
    public static string Magpie_Dialog_Kette4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ach, der Meister hat mich beim Klauen erwischt in seinem Labor. Hat ihm wohl nicht gefallen, dass seine wertvoillsten Ingredenzien weg waren. Seitdem hat er mich hier magisch angekettet. Die Kette ist unzerstörbar. Versuche es gar nicht erst.";
            else
                return "Ach, der Meister hat mich beim Klauen erwischt in seinem Labor. Hat ihm wohl nicht gefallen, dass seine wertvoillsten Ingredenzien weg waren. Seitdem hat er mich hier magisch angekettet. Die Kette ist unzerstörbar. Versuche es gar nicht erst.";
        }
    }
    public static string Magpie_Dialog_Tauschen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hätte hier ein nettes Stück Käse für dich im Angebot. Deal?";
            else
                return "Ich hätte hier ein nettes Stück Käse für dich im Angebot. Deal?";
        }
    }
    public static string Magpie_Dialog_Tauschen2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das ist ja bretthart und ungenießbar! Geil! Dafür kann ich dir einen schönen, polierten Stein dafür anbieten!";
            else
                return "Das ist ja bretthart und ungenießbar! Geil! Dafür kann ich dir einen schönen, polierten Stein dafür anbieten!";
        }
    }
    public static string Magpie_Dialog_Tauschen3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich werde irgendwie das Gefühl nicht los, du machst es mir zu leicht. Aber was solls.";
            else
                return "Ich werde irgendwie das Gefühl nicht los, du machst es mir zu leicht. Aber was solls.";
        }
    }
    public static string Magpie_Dialog_Tauschen4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Genau. Deal. *Krächz*";
            else
                return "Genau. Deal. *Krächz*";
        }
    }



    public static string Fish_Dialog_Start_Long
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Blub!";
            else
                return "Blub!";
        }
    }
    public static string Fish_Dialog_Start_Long2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wollte ich auch gerade sagen.";
            else
                return "Wollte ich auch gerade sagen.";
        }
    }
    public static string Fish_Dialog_Start_Long3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was willst du?";
            else
                return "Was willst du?";
        }
    }
    public static string Fish_Dialog_Start_Short
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Blub?";
            else
                return "Blub?";
        }
    }
    public static string Fish_Dialog_Ende
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Blub over und out.";
            else
                return "Blub over und out.";
        }
    }

    public static string Fish_Dialog_Belebung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie fühlt sich das an, wenn man von der Klaue wiederbelebt wird?";
            else
                return "Wie fühlt sich das an, wenn man von der Klaue wiederbelebt wird?";
        }
    }
    public static string Fish_Dialog_Belebung2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "'wiederbelebt' ist ein großes Wort. Ich fühle mich, als hätte man mich ausgenommen und mit Holzwolle ausgestopft.";
            else
                return "'wiederbelebt' ist ein großes Wort. Ich fühle mich, als hätte man mich ausgenommen und mit Holzwolle ausgestopft.";
        }
    }
    public static string Fish_Dialog_Belebung3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, daran könnte ja durchaus... ";
            else
                return "Nun, daran könnte ja durchaus... ";
        }
    }
    public static string Fish_Dialog_Belebung4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Halt, kein Wort mehr! So genau will ich das wirklich nicht wissen!";
            else
                return "Halt, kein Wort mehr! So genau will ich das wirklich nicht wissen!";
        }
    }
    public static string Fish_Dialog_Herkunft
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Und wie bist du hierher gelangt?";
            else
                return "Und wie bist du hierher gelangt?";
        }
    }
    public static string Fish_Dialog_Herkunft2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Oh, das ist eine lange Geschichte, blub. Ich schwamm eines Tages im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis... ";
            else
                return "Oh, das ist eine lange Geschichte, blub. Ich schwamm eines Tages im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis... ";
        }
    }
    public static string Fish_Dialog_Herkunft3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Danke, ich habs verstanden!";
            else
                return "Danke, ich habs verstanden!";
        }
    }
    public static string Fish_Dialog_Herkunft4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... und dann machts plötzlich schwupp, und ich habe einen komischen Haken im Mund, an dem man mich aus dem Wasser herauszieht. Danach war nichts mehr. Schlimme Geschichte, ich weiß.";
            else
                return "... und dann machts plötzlich schwupp, und ich habe einen komischen Haken im Mund, an dem man mich aus dem Wasser herauszieht. Danach war nichts mehr. Schlimme Geschichte, ich weiß.";
        }
    }
    public static string Fish_Dialog_Leben
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was ist das für ein Leben so als ausgestopfter Fisch?";
            else
                return "Was ist das für ein Leben so als ausgestopfter Fisch?";
        }
    }
    public static string Fish_Dialog_Leben2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Leben? Das ist doch kein Leben! Ich will dir sagen, was Leben ist! Und zwar: Schwimmen, und zwar ...im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis... ";
            else
                return "Leben? Das ist doch kein Leben! Ich will dir sagen, was Leben ist! Und zwar: Schwimmen, und zwar ...im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis im Kreis... ";
        }
    }
    public static string Fish_Dialog_Leben3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Danke, ich habs verstanden! Im Kreis schwimmen ist natürlich das Höchste!";
            else
                return "Danke, ich habs verstanden! Im Kreis schwimmen ist natürlich das Höchste!";
        }
    }
    public static string Fish_Dialog_Leben4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Bei dir klingt das so seltsam.";
            else
                return "Bei dir klingt das so seltsam.";
        }
    }

    public static string Fish_Dialog_Coin
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Würdest du für mich in einen Brunnen tauchen und dort eine schimmernde Münze vom Grund aufnehmen?";
            else
                return "Würdest du für mich in einen Brunnen tauchen und dort eine schimmernde Münze vom Grund aufnehmen?";
        }
    }
    public static string Fish_Dialog_Coin2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Klar. Und was ist drin für mich?";
            else
                return "Klar. Und was ist drin für mich?";
        }
    }
    public static string Fish_Dialog_Coin3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Na, was wohl! Du darfst eine Weile im Wasser schwimmen, immer schon im Kreis, im Kreis, im Kreis, im Kreis...";
            else
                return "Na, was wohl! Du darfst eine Weile im Wasser schwimmen, immer schon im Kreis, im Kreis, im Kreis, im Kreis...";
        }
    }
    public static string Fish_Dialog_Coin4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich habs ja verstanden. Wirf mich ins Wasser, der Rest findet sich.";
            else
                return "Ich habs ja verstanden. Wirf mich ins Wasser, der Rest findet sich.";
        }
    }

    // KNights Armour
    public static string KA_Dialog_Start_Long
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ächz, das wurde ja mal wieder Zeit, dass mich irgendwer weckt. Den Umstand, dass ich dein Gesicht noch nie zuvor gesehen habe und du im Domizil von Meister Gunnar nichts verloren hast, werde ich daher bis auf weiteres ignorieren.";
            else
                return "Ächz, das wurde ja mal wieder Zeit, dass mich irgendwer weckt. Den Umstand, dass ich dein Gesicht noch nie zuvor gesehen habe und du im Domizil von Meister Gunnar nichts verloren hast, werde ich daher bis auf weiteres ignorieren.";
        }
    }
    public static string KA_Dialog_Start_Long2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Oha, eine Ritterrüstung, die spricht! Wie kann das angehen? Ist hier etwa Magie im Spiel?";
            else
                return "Oha, eine Ritterrüstung, die spricht! Wie kann das angehen? Ist hier etwa Magie im Spiel?";
        }
    }
    public static string KA_Dialog_Start_Long3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was für eine selten dämliche Frage. Dass die Klaue ein bisschen mehr kann als einfach nur schön zu leuchten, weißt du doch selbst. Aber genug geplaudert. Du willst doch sicher irgendwas.";
            else
                return "Was für eine selten dämliche Frage. Dass die Klaue ein bisschen mehr kann als einfach nur schön zu leuchten, weißt du doch selbst. Aber genug geplaudert. Du willst doch sicher irgendwas.";
        }
    }

    public static string KA_Dialog_Start_Short
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du schon wieder? Es ist erstaunlich, wie schnell einem Leute lästig fallen können.";
            else
                return "Du schon wieder? Es ist erstaunlich, wie schnell einem Leute lästig fallen können.";
        }
    }
    public static string KA_Dialog_Belebung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nochmal zum Mitschreiben: Wie kann es sein, dass du als leere Rüstung von der Klaue belebt wurdest?";
            else
                return "Nochmal zum Mitschreiben: Wie kann es sein, dass du als leere Rüstung von der Klaue belebt wurdest?";
        }
    }
    public static string KA_Dialog_Belebung2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wer weiß. Vermutlich liegt es an meiner edlen Herkunft, die soviel Energien in dieser Rüstung hinterlassen hat, dass sie wie ein eigenständiges Lebewesen ist.";
            else
                return "Wer weiß. Vermutlich liegt es an meiner edlen Herkunft, die soviel Energien in dieser Rüstung hinterlassen hat, dass sie wie ein eigenständiges Lebewesen ist.";
        }
    }
    public static string KA_Dialog_Belebung3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sehr überzeugend ist das jetzt nicht gerade...";
            else
                return "Sehr überzeugend ist das jetzt nicht gerade...";
        }
    }
    public static string KA_Dialog_Belebung4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ja, was weiß denn ich? Hör mal, ich bin eine Ritterrüstung und kein Infocenter. Ich würde viel lieber irgendwas cooles machen, über den Flur tanzen, ein paar Leute umrennen, eine Tür eintreten. Was man als Ritterrüstung eben so macht.";
            else
                return "Ja, was weiß denn ich? Hör mal, ich bin eine Ritterrüstung und kein Infocenter. Ich würde viel lieber irgendwas cooles machen, über den Flur tanzen, ein paar Leute umrennen, eine Tür eintreten. Was man als Ritterrüstung eben so macht.";
        }
    }

    public static string KA_Dialog_Klaue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was weißt du über die Klaue? Das Juwel ist ja weit erstaunlicher, als ich dachte!";
            else
                return "Was weißt du über die Klaue? Das Juwel ist ja weit erstaunlicher, als ich dachte!";
        }
    }
    public static string KA_Dialog_Klaue2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Och naja, ein grünes Juwel halt. Liegt hier so rum. Ganz cool eigentlich. Ab und an kommt Meister Gunnar vorbei, belebt mich damit und erzählt mir von seinen Problemen. Es hat also auch Nachteile.";
            else
                return "Och naja, ein grünes Juwel halt. Liegt hier so rum. Ganz cool eigentlich. Ab und an kommt Meister Gunnar vorbei, belebt mich damit und erzählt mir von seinen Problemen. Es hat also auch Nachteile.";
        }
    }
    public static string KA_Dialog_Klaue3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Lassen sich damit noch andere unbelebte Gegenstände hier im Meisterversteck beleben?";
            else
                return "Lassen sich damit noch andere unbelebte Gegenstände hier im Meisterversteck beleben?";
        }
    }
    public static string KA_Dialog_Klaue4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Unbelebte Gegenstände? Du redest nicht etwa von mir? Hör mal, Freundchen, wenn du frech werden willst.... Ach, was reg ich mich auf. Probiere die Klaue doch einfach mal aus bei den ganzen ausgestopften Viechern hier. Die werden sich schon melden, wenn sie nicht wiederbelebt werden wollen. Es hält ja leider eh nie lange an.";
            else
                return "Unbelebte Gegenstände? Du redest nicht etwa von mir? Hör mal, Freundchen, wenn du frech werden willst.... Ach, was reg ich mich auf. Probiere die Klaue doch einfach mal aus bei den ganzen ausgestopften Viechern hier. Die werden sich schon melden, wenn sie nicht wiederbelebt werden wollen. Es hält ja leider eh nie lange an.";
        }
    }

    public static string KA_Dialog_Ruestung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was hast du da eigentlich für eine schicke Rüstung?";
            else
                return "Was hast du da eigentlich für eine schicke Rüstung?";
        }
    }
    public static string KA_Dialog_Ruestung2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Äh, was redest du? Ich BIN die Rüstung. Ich gehörte einst... aber das tut nichts zur Sache. Ich hätte damals diese NDA nicht unterschreiben sollen...";
            else
                return "Äh, was redest du? Ich BIN die Rüstung. Ich gehörte einst... aber das tut nichts zur Sache. Ich hätte damals diese NDA nicht unterschreiben sollen...";
        }
    }
    public static string KA_Dialog_Ruestung3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Stehst du eigentlich schon lange hier herum?";
            else
                return "Stehst du eigentlich schon lange hier herum?";
        }
    }
    public static string KA_Dialog_Ruestung4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Tja, gute Frage. Ich hab mein Zeitgefühl völlig verloren. Ich stehe einfach nur hier herum, ab und zu wache ich auf, mache irgendwas kaputt, und dann schlafe ich wieder ein. Ein erfülltes Leben ist das nicht gerade.";
            else
                return "Tja, gute Frage. Ich hab mein Zeitgefühl völlig verloren. Ich stehe einfach nur hier herum, ab und zu wache ich auf, mache irgendwas kaputt, und dann schlafe ich wieder ein. Ein erfülltes Leben ist das nicht gerade.";
        }
    }
    public static string KA_Dialog_Owner
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was kannst du mir über den ursprünglichen Besitzer der Rüstung sagen?";
            else
                return "Was kannst du mir über den ursprünglichen Besitzer der Rüstung sagen?";
        }
    }
    public static string KA_Dialog_Owner2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Oh, ich KÖNNTE jede Menge erzählen. Aber leider bin ich zur Verschwiegenheit verpflichtet. Wenn du verstehst, was ich meine...";
            else
                return "Oh, ich KÖNNTE jede Menge erzählen. Aber leider bin ich zur Verschwiegenheit verpflichtet. Wenn du verstehst, was ich meine...";
        }
    }
    public static string KA_Dialog_Owner3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, nein. Ich verstehe kein Wort. Du kannst mir doch sicher den Namen deines Besitzers sagen. Einfach nur den Namen.";
            else
                return "Nun, nein. Ich verstehe kein Wort. Du kannst mir doch sicher den Namen deines Besitzers sagen. Einfach nur den Namen.";
        }
    }
    public static string KA_Dialog_Owner4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du wirst verstehen... aus Gründen der Diskretion... Also gut, ich geb's ja zu: Ich hab den Namen vergessen. Ist mir selbst peinlich. Aber steht du mal äonenlang als leere Rüstung auf einem Flur herum. Da vergisst man noch ganz andere Sachen.";
            else
                return "Du wirst verstehen... aus Gründen der Diskretion... Also gut, ich geb's ja zu: Ich hab den Namen vergessen. Ist mir selbst peinlich. Aber steht du mal äonenlang als leere Rüstung auf einem Flur herum. Da vergisst man noch ganz andere Sachen.";
        }
    }

    public static string KA_Dialog_Tanzen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Möchtest du nicht mal ein Tänzchen wagen? Ich sehe so gerne steppende Ritterrüstungen!";
            else
                return "Möchtest du nicht mal ein Tänzchen wagen? Ich sehe so gerne steppende Ritterrüstungen!";
        }
    }
    public static string KA_Dialog_Tanzen2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das lass ich mir nicht zweimal sagen! Wollen wir gemeinsam einen Tango tanzen?";
            else
                return "Das lass ich mir nicht zweimal sagen! Wollen wir gemeinsam einen Tango tanzen?";
        }
    }
    public static string KA_Dialog_Tanzen3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Schlecht, ganz schlecht. Mein Hühnerauge...";
            else
                return "Schlecht, ganz schlecht. Mein Hühnerauge...";
        }
    }
    public static string KA_Dialog_Tanzen4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Faule Ausrede! Egal, dann gibts eben Pogo!";
            else
                return "Faule Ausrede! Egal, dann gibts eben Pogo!";
        }
    }
    public static string KA_Dialog_Tuer_Einrennen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hast du nicht Lust, die Tür zum Schlafzimmer des Meisters einzurennen?";
            else
                return "Hast du nicht Lust, die Tür zum Schlafzimmer des Meisters einzurennen?";
        }
    }
    public static string KA_Dialog_Tuer_Einrennen2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Oh, Lust hätte ich durchaus. Aber das... das wäre schwere Sachbeschädigung. Das wird mir Meister Gunnar nie verzeihen. Womöglich wird er mich niemals wieder mit der Klaue berühren, und dann stehe ich hier einfach nur herum und fange Staub.";
            else
                return "Oh, Lust hätte ich durchaus. Aber das... das wäre schwere Sachbeschädigung. Das wird mir Meister Gunnar nie verzeihen. Womöglich wird er mich niemals wieder mit der Klaue berühren, und dann stehe ich hier einfach nur herum und fange Staub.";
        }
    }
    public static string KA_Dialog_Tuer_Einrennen3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Meister Gunnar hat die Klaue doch gar nicht mehr, sondern ich bin es, mit dem du dich gutstellen musst! Also los, hopp hopp!";
            else
                return "Meister Gunnar hat die Klaue doch gar nicht mehr, sondern ich bin es, mit dem du dich gutstellen musst! Also los, hopp hopp!";
        }
    }
    public static string KA_Dialog_Tuer_Einrennen4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "So gesehen... Aus dem Weeeeeg!";
            else
                return "So gesehen... Aus dem Weeeeeg!";
        }
    }
    public static string KA_Dialog_Ende
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Danke, reicht.";
            else
                return "Danke, reicht.";
        }
    }

    public static string KnightArmour_Tanzen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Ritterrüstung begann, einen wilden Pogo zu tanzen, brüllte dabei anarchistische Parolen und verlangte lautstark nach Dosenbier. Ich verkroch mich in der hintersten Ecke des Flurs und wartete das Ende des Dramas ab. Zum Glück schien die Rüstung nicht allzu viel Ausdauer zu besitzen und kam schon bald wieder zum Stehen...";
            else
                return "Die Ritterrüstung begann, einen wilden Pogo zu tanzen, brüllte dabei anarchistische Parolen und verlangte lautstark nach Dosenbier. Ich verkroch mich in der hintersten Ecke des Flurs und wartete das Ende des Dramas ab. Zum Glück schien die Rüstung nicht allzu viel Ausdauer zu besitzen und kam schon bald wieder zum Stehen...";
        }
    }
    public static string KnightArmour_Tuer
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Ritterrüstung nahm Anlauf und rannte dann brüllend auf die Tür des meisterlichen Schlafgemachs zu - und krachte schließlich gegen [I:I06_Door]die solide Tür[/I], die prompt aus den Angeln flog. Die Ritterrüstung rappelte sich auf, hängte etwas betreten die Tür wieder ein und kehrte an ihren Platz zurück. \"Ah, das tat gut!\"";
            else
                return "Die Ritterrüstung nahm Anlauf und rannte dann brüllend auf die Tür des meisterlichen Schlafgemachs zu - und krachte schließlich gegen [I:I06_Door]die solide Tür[/I], die prompt aus den Angeln flog. Die Ritterrüstung rappelte sich auf, hängte etwas betreten die Tür wieder ein und kehrte an ihren Platz zurück. \"Ah, das tat gut!\"";
        }
    }
    public static string Order_InfoMCDialog_Person_Self_11228
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Danke, reicht.";
            else
                return "Thank you, enough.";
        }
    }
    public static string Order_SetGenericTipps_Person_Self_11229
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Tipp";
            else
                return "clue";
        }
    }
    public static string Order_SetGenericTipps_Person_Self_11230
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Tipp";
            else
                return "clue";
        }
    }
    public static string Order_SetGenericTipps_Person_Self_11231
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hilfe";
            else
                return "Help";
        }
    }
    public static string Order_SetGenericTipps_Person_Self_11232
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hilfe";
            else
                return "Help";
        }
    }
    public static string Order_SetGenericTipps_Person_Self_11233
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Lösung";
            else
                return "Solution";
        }
    }
    public static string Order_SetGenericTipps_Person_Self_11234
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Lösung";
            else
                return "Solution";
        }
    }
    public static string Order_SetGenericTipps_Person_Self_11235
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Kein Tipp";
            else
                return "No clue";
        }
    }
    public static string Illuminate1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string Illuminate2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string Illuminate3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom> mit <> beleuchten";
            else
                return "ignite <nameNom> with <>";
        }
    }
    public static string Illuminate4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "beleuchte <nameNom> mit <nameDat2>";
            else
                return "ignite <nameNom> with <nameDat2>";
        }
    }
    public static string Grabinto1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string Grabinto2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string Grabinto3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "in <nameNom> greifen";
            else
                return "grab <nameNom> with <>";
        }
    }
    public static string Grabinto4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "greife in <nameNom>";
            else
                return "grab <nameNom> with <nameDat2>";
        }
    }
    public static string Takewith1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string Takewith2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string Takewith3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom> mit <> nehmen";
            else
                return "grab <nameNom> with <>";
        }
    }
    public static string Takewith4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "nimm <nameNom> mit <nameDat2>";
            else
                return "grab <nameNom> with <nameDat2>";
        }
    }
    public static string WrapAround1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string WrapAround2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string WrapAround3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom> um <> wickeln";
            else
                return "grab <nameNom> with <>";
        }
    }
    public static string WrapAround4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "wickle <nameNom> um <nameDat2>";
            else
                return "grab <nameNom> with <nameDat2>";
        }
    }

    public static string TouchWith1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string TouchWith2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string TouchWith3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom> mit <> berühren";
            else
                return "grab <nameNom> with <>";
        }
    }
    public static string TouchWith4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "berühre <nameNom> mit <nameDat2>";
            else
                return "grab <nameNom> with <nameDat2>";
        }
    }
    public static string ReadWith1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string ReadWith2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string ReadWith3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom> mit <> lesen";
            else
                return "grab <nameNom> with <>";
        }
    }
    public static string ReadWith4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "lies <nameNom> mit <nameDat2>";
            else
                return "grab <nameNom> with <nameDat2>";
        }
    }
    public static string Heatable1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string Heatable2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string Heatable3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom> mit <> erhitzen";
            else
                return "grab <nameNom> with <>";
        }
    }
    public static string Heatable4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "erhitze <nameNom> mit <nameDat2>";
            else
                return "grab <nameNom> with <nameDat2>";
        }
    }
    public static string Pulverize1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string Pulverize2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string Pulverize3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom> mit <> zerreiben";
            else
                return "grab <nameNom> with <>";
        }
    }
    public static string Pulverize4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "zerreibe <nameNom> mit <nameDat2>";
            else
                return "grab <nameNom> with <nameDat2>";
        }
    }
    public static string Light1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string Light2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom>";
            else
                return "<nameNom>";
        }
    }
    public static string Light3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<nameNom> entzünden";
            else
                return "grab <nameNom> with <>";
        }
    }
    public static string Light4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "entzünde <nameNom>";
            else
                return "grab <nameNom> with <nameDat2>";
        }
    }
    public static string Blubbern1
    {
        get
        {
            return "blubbern";
            /*
           if (_gd!.Language == IGlobalData.language.german)
               return "sagen";
           else
               return "say";
               */
        }
    }
    public static string Blubbern2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blubbere";
            else
                return "say";
        }
    }
    public static string Blubbern3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blubberst";
            else
                return "say";
        }
    }
    public static string Blubbern4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blubbert";
            else
                return "says";
        }
    }
    public static string Blubbern5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blubbern";
            else
                return "say";
        }
    }
    public static string Blubbern6
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blubbert";
            else
                return "say";
        }
    }
    public static string Blubbern7
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blubbern";
            else
                return "say";
        }
    }
    public static string Blubbern8
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blubberte";
            else
                return "said";
        }
    }
    public static string Blubbern9
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blubbertest";
            else
                return "said";
        }
    }
    public static string Blubbern10
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blubberte";
            else
                return "said";
        }
    }
    public static string Blubbern11
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blubberten";
            else
                return "said";
        }
    }
    public static string Blubbern12
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blubbertet";
            else
                return "said";
        }
    }
    public static string Blubbern13
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "blubberten";
            else
                return "said";
        }
    }
    public static string Order_Credits_1937
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein besonderer Dank geht an die - freiwilligen und weniger freiwilligen - Tester: Wiebke Scholz, StJohn Limbo, Olaf Nowacki, Jan Lachnit, IkeC, Bilbo und auch an den grantelnden Herrn Oehm<br>Icon von macrovector on Freepik";
            else
                return "Ein besonderer Dank geht an die - freiwilligen und weniger freiwilligen - Tester: Wiebke Scholz, StJohn Limbo, Olaf Nowacki, Jan Lachnit, IkeC, Bilbo und auch an den grantelnden Herrn Oehm<br>Icon von macrovector on Freepik";
        }
    }

    public static string General_Info
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Feedback willkommen insbesondere zum User Interface von \"Das Versteck des Meisters\". Das System lässt sich auf vielfältige Weisen bedienen: Texteingabe, Multiple Choice, Spracheingabe, oder auch eine Kombination aus allen dreien. Ich freue mich sehr auf eure Rückmeldung.\nWer Lust hat, etwas zu experimentieren, der findet in den Settings jede Menge UI-Optionen.\n\n\n\n";
            else
                return "Feedback willkommen insbesondere zum User Interface von \"Das Versteck des Meisters\". Das System lässt sich auf vielfältige Weisen bedienen: Texteingabe, Multiple Choice, Spracheingabe, oder auch eine Kombination aus allen dreien. Ich freue mich sehr auf eure Rückmeldung.\nWer Lust hat, etwas zu experimentieren, der findet in den Settings jede Menge UI-Optionen.\n\n\n\n";
        }
    }
    public static string Verb_speichern
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "speichern";
            else
                return "___save";
        }
    }
    public static string MAUI_Infodialog_Ok
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ok";
            else
                return "Ok";
        }
    }
    public static string MAUI_Infodialog_Info
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wichtige Info";
            else
                return "Wichtige Info";
        }
    }
    public static string MAUI_Infodialog_Autosave_Failed
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der automatisch abgelegte Spielstand war kaputt oder veraltet, und wurde daher nicht geladen.";
            else
                return "Der automatisch abgelegte Spielstand war kaputt oder veraltet, und wurde daher nicht geladen.";
        }
    }
    public static string MAUI_Infodialog_Savegame_Failed
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der gewählte Spielstand war kaputt oder veraltet, und wurde daher nicht geladen.";
            else
                return "Der gewählte Spielstand war kaputt oder veraltet, und wurde daher nicht geladen.";
        }
    }

    public static string Pronoun_dir
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "dir";
            else
                return "__you";
        }
    }
    public static string prep_wo
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "wo";
            else
                return "wo";
        }
    }
    public static string prep_was
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "was";
            else
                return "was";
        }
    }
    public static string Verb_bin
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "bin";
            else
                return "bin";
        }
    }
    public static string Verb_sein
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "sein";
            else
                return "sein";
        }
    }
    public static string Verb_sind
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "sind";
            else
                return "sind";
        }
    }
    public static string Verb_ist
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "ist";
            else
                return "ist";
        }
    }
    public static string Verb_war
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "war";
            else
                return "war";
        }
    }
    public static string ExamineReflexive_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Irgendwie war mir nicht im Geringsten klar, wie ich wen mit was anschauen sollte.";
            else
                return "Irgendwie war mir nicht im Geringsten klar, wie ich wen mit was anschauen sollte.";
        }
    }
    public static string locationReflexive_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich spürte keinerlei Lust, den Aufenthaltsort von [Pl1,Dat] zu ermitteln.";
            else
                return "Ich spürte keinerlei Lust, den Aufenthaltsort von [Pl1,Dat] zu ermitteln.";
        }
    }
    public static string WhereIs_Versteck1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wo das Versteck war? Wenn ich das so einfach beantworten könnte, wären wir hier fertig.";
            else
                return "Wo das Versteck war? Wenn ich das so einfach beantworten könnte, wären wir hier fertig.";
        }
    }
    public static string WhereIs_Versteck2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich denke, ich befand mich hier genau in diesem Versteck. Oder zumindest gehörte dieser Ort dazu.";
            else
                return "Ich denke, ich befand mich hier genau in diesem Versteck. Oder zumindest gehörte dieser Ort dazu.";
        }
    }
    public static string WhereIs_Failed
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hatte keine Ahnung, wo sich [Top1,Nom] befand.";
            else
                return "Ich hatte keine Ahnung, wo sich [Top1,Nom] befand.";
        }
    }
    public static string Autosave_Outdated
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Autosavegame ist veraltet. Das Spiel startet von vorne.";
            else
                return "Das Autosavegame ist veraltet. Das Spiel startet von vorne.";
        }
    }
    public static string Use_Toilet
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich benutzte die Toilette. Sogleich fühlte ich mich besser.";
            else
                return "Ich benutzte die Toilette. Sogleich fühlte ich mich besser.";
        }
    }
    public static string Use_Flushing
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich betätigte die Spülung. Sie funktionierte reibungslos.";
            else
                return "Ich betätigte die Spülung. Sie funktionierte reibungslos.";
        }
    }
    public static string Verb_Up
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "rauf";
            else
                return "__up";
        }
    }
    public static string Throw_Person_Solo
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wohin sollte ich [Pl1,Nom] werfen?";
            else
                return "Wohin sollte ich [Pl1,Nom] werfen?";
        }
    }
    public static string Noun_Heaven
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Heaven";
            else
                return "heaven";
        }
    }
    public static string Noun_Spuren
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Spuren";
            else
                return "trails";
        }
    }
    public static string OrderFeedback_ListIPersons
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "- [Pl1,Akk][S2]";
            else
                return "- [Pl1,Akk][S2]";
        }
    }
    public static string OrderFeedback_ListIPersons_clickable
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "- [Pla1,Akk][S2]";
            else
                return "- [Pla1,Akk][S2]";
        }
    }
    public static string OrderFeedback_ListIPersons_clickable_U
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "- [Pla1,Akku][S2]";
            else
                return "- [Pla1,Akku][S2]";
        }
    }
    public static string OrderFeedback_ListIPersons_clickable_Akku
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "- [Pla1,Akku][S2]";
            else
                return "- [Pla1,Akku][S2]";
        }
    }
    public static string OrderFeedback_ListPersons_Nom
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "- [Pl1,Nom][S2]";
            else
                return "- [Pl1,Nom][S2]";
        }
    }
    public static string Verb_Skript
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "skript";
            else
                return "skript";
        }
    }
    public static string Verb_Transkript
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "transkript";
            else
                return "transkript";
        }
    }
    public static string Verb_Transcript
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "transcript";
            else
                return "transcript";
        }
    }
    public static string Verb_Schwimme
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "schwimme";
            else
                return "swim";
        }
    }
    public static string Verb_Schwimm
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "schwimm";
            else
                return "_swim";
        }
    }
    public static string Verb_Trete
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "trete";
            else
                return "kick";
        }
    }
    public static string Verb_Tritt
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "tritt";
            else
                return "_kick";
        }
    }
    public static string Info_Script
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Alle Eingaben werden automatisch aufgezeichnet und finden sich im Logbuch-Menü.<br>mit '# bla bla' können Kommentare aufgezeichnet werden.<br>Spielstände und Transkripts finden sich unter Windows im Ordner 'document/My Games/Das Versteck des Meisters'";
            else
                return "Alle Eingaben werden automatisch aufgezeichnet und finden sich im Logbuch-Menü.<br>mit '# bla bla' können Kommentare aufgezeichnet werden.<br>Spielstände und Transkripts finden sich unter Windows im Ordner 'document/My Games/Das Versteck des Meisters'";
        }
    }

    public static string Dive_In_Well
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hatte keine Lust, in den Brunnen zu springen. Das Wasser war viel zu kalt.";
            else
                return "Ich hatte keine Lust, in den Brunnen zu springen. Das Wasser war viel zu kalt.";
        }
    }
    public static string Dive_In_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Warum sollte ich in [Il1,Nom] tauchen?";
            else
                return "Warum sollte ich in [Il1,Nom] tauchen?";
        }
    }
    public static string Swim_In_Well
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hatte keine Lust, in dem Brunnen zu schwimmen. Das Wasser war viel zu kalt.";
            else
                return "Ich hatte keine Lust, in dem Brunnen zu schwimmen. Das Wasser war viel zu kalt.";
        }
    }
    public static string Swim_In_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie sollte ich in [Il1,Dat] schwimmen?";
            else
                return "Wie sollte ich in [Il1,Dat] schwimmen?";
        }
    }
    public static string Kick_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich trat fest gegen [Il1,Dat]. Ah, das tat gut.";
            else
                return "Ich trat fest gegen [Il1,Dat]. Ah, das tat gut.";
        }
    }
    public static string MAUI_UI_Menu_Restart
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Neustart";
            else
                return "Restart";
        }
    }
    public static string MAUI_UI_Menu_Order_Restart
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Neustart";
            else
                return "Restart";
        }
    }
    public static string ListItems_Basetext
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[Plv1,sehen,Akk] darin: ";
            else
                return "[Plv1,sehen,Akk] darin: ";
        }
    }
    public static string OrderFeedback_ListItemsPersons_Person_Everyone_14069_App
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "- [Ila1,Nom]";
            else
                return "- [Ila1,Nom]";
        }
    }
    public static string Order_Fixate_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auch nach reiflicher Überlegung fiel mir nicht ein, wie ich [Il1,Nom] mit [Il2,Dat] fixieren konnte.";
            else
                return "Auch nach reiflicher Überlegung fiel mir nicht ein, wie ich [Il1,Nom] mit [Il2,Dat] fixieren konnte.";
        }
    }
    public static string Adv_L11_Magpie
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf dem Ständer befand sich [P:Person_Magpie]eine ausgestopfte Elster[/P].";
            else
                return "Auf dem Ständer befand sich [P:Person_Magpie]eine ausgestopfte Elster[/P].";
        }
    }
    public static string Adv_L11_Animals
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf den Regalen tummelten sich allerlei ausgestopfte Viecher.";
            else
                return "Auf den Regalen tummelten sich allerlei ausgestopfte Viecher.";
        }
    }
    public static string Adv_L11_Animal
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf den Regalen lag nur noch ein einzelnes ausgestopftes Viech.";
            else
                return "Auf den Regalen lag nur noch ein einzelnes ausgestopftes Viech.";
        }
    }
    public static string Verb_Restore
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Restore";
            else
                return "Restore";
        }
    }
    public static string Order_Place_No_Animal
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[Pla1,Nom] wollte ich nirgends ablegen.";
            else
                return "[Pla1,Nom] wollte ich nirgends ablegen.";
        }
    }
    public static string Order_Place_In_No_Animal
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[Pla1,Nom] wollte ich nirgends hineinlegen.";
            else
                return "[Pla1,Nom] wollte ich nirgends hineinlegen.";
        }
    }
    public static string Order_Place_Self_On_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf [Il1,Nom] wollte ich mich beim besten Willen nicht legen.";
            else
                return "Auf [Il1,Nom] wollte ich mich beim besten Willen nicht legen.";
        }
    }
    public static string Order_PlaceP_On_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[Pla1,Nom] wollte ich keineswegs auf [Ila2,Dat] ablegen.";
            else
                return "[Pla1,Nom] wollte ich keineswegs auf [Ila2,Dat] ablegen.";
        }
    }
    public static string Order_Steal_Failed
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich verzichtete darauf, [Ila1,Nom] zu stehlen.";
            else
                return "Ich verzichtete darauf, [Ila1,Nom] zu stehlen.";
        }
    }
    public static string Order_Steal_Failed_Klaue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Zu diesem Mörder-Wortspiel konnte ich mich wirklich nur noch beglückwünschen.";
            else
                return "Zu diesem Mörder-Wortspiel konnte ich mich wirklich nur noch beglückwünschen.";
        }
    }
    public static string Order_WrapAround_Not
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nach reiflicher Überlegung fiel mir doch kein guter Grund ein, [Il1,Nom] um [Il2,AKK] zu wickeln.";
            else
                return "After careful consideration, I couldn't think of a good reason to wrap [Il1,Nom] around [Il2,Dat] after all.";
        }
    }
    public static string Inv_Opened
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return " (offen)";
            else
                return " (offen)";
        }
    }
    public static string Inv_Closed
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return " (geschlossen)";
            else
                return " (geschlossen)";
        }
    }
}


