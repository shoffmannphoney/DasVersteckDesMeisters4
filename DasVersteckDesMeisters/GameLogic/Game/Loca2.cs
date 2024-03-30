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
                return "Von hier aus konnte ich nirgends mehr hingehen.";
            else
                return "I had nowhere to go from here.";
        }
    }
    public static string Verb_zerstosse
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "zerstoße";
            else
                return "zerstoße";
        }

    }
    public static string Verb_zerstoss
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "zerstoß";
            else
                return "zerstoß";
        }

    }
    public static string Verb_zerdruecke
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "zerdrücke";
            else
                return "zerdrücke";
        }

    }
    public static string Verb_zerdrueck
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "zerdrück";
            else
                return "zerdrück";
        }

    }
    public static string Info_Start
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand mitten im Wald. Wo befand sich bloß das Versteck des Meisters? Hier irgendwo in der Nähe musste doch seine Hütte sein!";
            else
                return "Ich stand mitten im Wald. Wo befand sich bloß das Versteck des Meisters? Hier irgendwo in der Nähe musste doch seine Hütte sein!";
        }

    }
    public static string Info_Suche_Versteck
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Die Hütte des Meisters hatte ich gefunden. Aber das war ganz sicher nicht sein Versteck, zumindest sah sie aus wie eine baufällige Bruchbude. Irgendwo hier musste doch ein verborgener Eingang liegen!";
            else
                return "(Tipps!) Die Hütte des Meisters hatte ich gefunden. Aber das war ganz sicher nicht sein Versteck, zumindest sah sie aus wie eine baufällige Bruchbude. Irgendwo hier musste doch ein verborgener Eingang liegen!";
        }

    }
    public static string Info_Suche_Versteck_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie konnte ich das geheime Domizil des Meisters finden?";
            else
                return "Wie konnte ich das geheime Domizil des Meisters finden?";
        }

    }
    public static string Info_Suche_Versteck_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Ich war mir sicher: Ohne magische Hlfe würde es nicht gehen!";
            else
                return "(Tipp) Ich war mir sicher: Ohne magische Hlfe würde es nicht gehen!";
        }

    }
    public static string Info_Suche_Versteck_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Manche Leute legten sich ihren Ersatzschlüssel unter die Fußmatte. Und wer weiß, was sich alles in der schäbigen Kammmer finden ließ.";
            else
                return "(Hilfe) Manche Leute legten sich ihren Ersatzschlüssel unter die Fußmatte. Und wer weiß, was sich alles in der schäbigen Kammmer finden ließ.";
        }

    }
    public static string Info_Suche_Versteck_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Unter der Fußmatte vor der Hütte lag ein Beutelchen mit magischem Pulver. Hinter dem Schrank in der schäbigen Kammer befand sich eine Klappe, und in der Öffnung dahinter eine magische Kerze. Aufs Pentagramm stellen in der Stube, Pulver drauf streuen - und schon ging die Reise los.";
            else
                return "(Lösung) Unter der Fußmatte vor der Hütte lag ein Beutelchen mit magischem Pulver. Hinter dem Schrank in der schäbigen Kammer befand sich eine Klappe, und in der Öffnung dahinter eine magische Kerze. Aufs Pentagramm stellen in der Stube, Pulver drauf streuen - und schon ging die Reise los.";
        }

    }
    public static string Info_Pentagramm
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Ein Pentagramm mitten in der Stube der Hütte. Das hatte doch gewiss etwas zu bedeuten. Aber was?";
            else
                return "(Tipps!) Ein Pentagramm mitten in der Stube der Hütte. Das hatte doch gewiss etwas zu bedeuten. Aber was?";
        }

    }
    public static string Info_Pentagramm_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was hatte es mit dem Pentagramm auf sich?";
            else
                return "Was hatte es mit dem Pentagramm auf sich?";
        }

    }
    public static string Info_Pentagramm_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Meister Gunnar liebte Pentagramme. Wo sie waren, war Magie nicht weit. Und nutze Meiser Gunnar seine Pentgramme nicht gerne für Teleportzauber?";
            else
                return "(Tipp) Meister Gunnar liebte Pentagramme. Wo sie waren, war Magie nicht weit. Und nutze Meiser Gunnar seine Pentgramme nicht gerne für Teleportzauber?";
        }

    }
    public static string Info_Pentagramm_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Meister Gunnar hatte das Pentagamm hier sicher nicht zum Spaß hingemalt. Vermutlich lagen hier irgendwo Zauberzutaten. Ich sollte alles in und vor der Hütte gründllich absuchen.";
            else
                return "(Hilfe) Meister Gunnar hatte das Pentagamm hier sicher nicht zum Spaß hingemalt. Vermutlich lagen hier irgendwo Zauberzutaten. Ich sollte alles in und vor der Hütte gründllich absuchen.";
        }

    }
    public static string Info_Pentagramm_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Unter der Fußmatte vor der Hütte lag ein Beutelchen mit magischem Pulver. Hinter dem Schrank in der schäbigen Kammer befand sich eine Klappe, und in der Öffnung dahinter eine magische Kerze. Aufs Pentagramm stellen in der Stube, Pulver drauf streuen - und schon ging die Reise los.";
            else
                return "(Lösung) Unter der Fußmatte vor der Hütte lag ein Beutelchen mit magischem Pulver. Hinter dem Schrank in der schäbigen Kammer befand sich eine Klappe, und in der Öffnung dahinter eine magische Kerze. Aufs Pentagramm stellen in der Stube, Pulver drauf streuen - und schon ging die Reise los.";
        }

    }
    public static string Info_Atrium_Ankunft
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich war im Versteck des Meisters angekommen. Jetzt noch schnell die Klaue an mich nehmen und nichts wie raus hier!";
            else
                return "Ich war im Versteck des Meisters angekommen. Jetzt noch schnell die Klaue an mich nehmen und nichts wie raus hier!";
        }

    }
    public static string Info_Klaue_nicht_nehmbar
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps) Ich hatte die Klaue gefunden. Leider schien es viel zu gefährlich zu sein, sie einfach zu nehmen.";
            else
                return "(Tipps) Ich hatte die Klaue gefunden. Leider schien es viel zu gefährlich zu sein, sie einfach zu nehmen.";
        }

    }
    public static string Info_Klaue_nicht_nehmbar_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie konnte ich die Klaue an mich nehmen?";
            else
                return "Wie konnte ich die Klaue an mich nehmen?";
        }

    }
    public static string Info_Klaue_nicht_nehmbar_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Wenn ich sie nicht direkt nehmen konnte, dann gab es vielleicht einen Gegenstand, der mir beim Nehmen helfen könnte.";
            else
                return "(Tipp) Wenn ich sie nicht direkt nehmen konnte, dann gab es vielleicht einen Gegenstand, der mir beim Nehmen helfen könnte.";
        }

    }
    public static string Info_Klaue_nicht_nehmbar_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) In der Küchenschublade fand sich ein nützlicher Gegenstand, um die Klaue damit aufzunehmen. Leider war das Ganze aber nicht perfekt.";
            else
                return "(Hilfe) In der Küchenschublade fand sich ein nützlicher Gegenstand, um die Klaue damit aufzunehmen. Leider war das Ganze aber nicht perfekt.";
        }

    }
    public static string Info_Klaue_nicht_nehmbar_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) In der Küchenschublade fand ich eine Zuckerzange. Die konnte ich mit der Klaue benutzen, um sie hochzunehmen. Fehlte noch eine Fixierung für das ganze Gebilde.";
            else
                return "(Lösung) In der Küchenschublade fand ich eine Zuckerzange. Die konnte ich mit der Klaue benutzen, um sie hochzunehmen. Fehlte noch eine Fixierung für das ganze Gebilde.";
        }

    }
    public static string Info_Klaue_nicht_fixiert
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hatte die Klaue gefunden und mit der Zuckerzange an mich genommen. Leider war das Gebilde alles anderes als stabil.";
            else
                return "Ich hatte die Klaue gefunden und mit der Zuckerzange an mich genommen. Leider war das Gebilde alles anderes als stabil.";
        }

    }
    public static string Info_Klaue_nicht_fixiert_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie konnte ich die Klaue in der Zuckerzange fixieren?";
            else
                return "Wie konnte ich die Klaue in der Zuckerzange fixieren?";
        }

    }
    public static string Info_Klaue_nicht_fixiert_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps) Ich brauchte ja eigentlich nur etwas, das die Zuckerzange zusammendrücke.";
            else
                return "(Tipps) Ich brauchte ja eigentlich nur etwas, das die Zuckerzange zusammendrücke.";
        }

    }
    public static string Info_Klaue_nicht_fixiert_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Ich brauchte irgendein Klebeband, zur Not tat es Pflaster. Sollte Meister Gunnar nicht irgendwo in seinem Labor einen Erste-Hilfe-Kasten haben?";
            else
                return "(Hilfe) Ich brauchte irgendein Klebeband, zur Not tat es Pflaster. Sollte Meister Gunnar nicht irgendwo in seinem Labor einen Erste-Hilfe-Kasten haben?";
        }

    }
    public static string Info_Klaue_nicht_fixiert_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Im Labor gab es einen Erste-Hilfe-Kasten. Dort konnte ich Rollpflaster finden. Das ließ sich dann um den Griff der Zange wickeln und so zusammendrücken. Fertig war der perfekte Klauenhalter.";
            else
                return "(Lösung) Im Labor gab es einen Erste-Hilfe-Kasten. Dort konnte ich Rollpflaster finden. Das ließ sich dann um den Griff der Zange wickeln und so zusammendrücken. Fertig war der perfekte Klauenhalter.";
        }

    }
    public static string Info_Klaue_noch_niemand_belebt
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Ich hatte nun diese schicke Klauenzange. Aber was sollte ich damit machen?";
            else
                return "(Tipps!) Ich hatte nun diese schicke Klauenzange. Aber was sollte ich damit machen?";
        }

    }
    public static string Info_Klaue_noch_niemand_belebt_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was tun mit der Klaue?";
            else
                return "Was tun mit der Klaue?";
        }

    }
    public static string Info_Klaue_noch_niemand_belebt_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Naja, sie soll ja Lebensenergie übertragen. Wem könnte das gut tun?";
            else
                return "(Tipp) Naja, sie soll ja Lebensenergie übertragen. Wem könnte das gut tun?";
        }

    }
    public static string Info_Klaue_noch_niemand_belebt_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Ob die ausgestopfte Eule oder andere Exlebewesen wohl positiv darauf reagieren, mit der Klaue berührt zu werden?";
            else
                return "(Hilfe) Ob die ausgestopfte Eule oder andere Exlebewesen wohl positiv darauf reagieren, mit der Klaue berührt zu werden?";
        }

    }
    public static string Info_Klaue_noch_niemand_belebt_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Mit der Klaue ließen sich nicht nur alle ausgestopften Viecher wiederbeleben, sondern auch die Ritterrüstung auf dem Flur.";
            else
                return "(Lösung) Mit der Klaue ließen sich nicht nur alle ausgestopften Viecher wiederbeleben, sondern auch die Ritterrüstung auf dem Flur.";
        }

    }
    public static string Info_Klaue_noch_niemand_gesprochen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps) Ich hatte nun diese schicke Klauenzange und damit auch schon etwas belebt. Aber was sollte ich jetzt damit machen?";
            else
                return "(Tipps) Ich hatte nun diese schicke Klauenzange und damit auch schon etwas belebt. Aber was sollte ich jetzt damit machen?";
        }

    }
    public static string Info_Klaue_noch_niemand_gesprochen_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was tun mit der schicken stabilen Klauenzange?";
            else
                return "Was tun mit der schicken stabilen Klauenzange?";
        }

    }
    public static string Info_Klaue_noch_niemand_gesprochen_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Tja, was hatte man davon, etwas zu beleben?";
            else
                return "(Tipp) Tja, was hatte man davon, etwas zu beleben?";
        }

    }
    public static string Info_Klaue_noch_niemand_gesprochen_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Jemand, der wiederbelebt war, hatte vielleicht Lust, sich mit mir zu unterhalten?";
            else
                return "(Hilfe) Jemand, der wiederbelebt war, hatte vielleicht Lust, sich mit mir zu unterhalten?";
        }

    }
    public static string Info_Klaue_noch_niemand_gesprochen_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) Ich konnte alle ausgestopften Viecher und die Ritterrüstung wiederbeleben und anschließend Gespräche mit ihnen führen.";
            else
                return "(Lösung) Ich konnte alle ausgestopften Viecher und die Ritterrüstung wiederbeleben und anschließend Gespräche mit ihnen führen.";
        }

    }
    public static string Info_Uhu_Fragen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Eule hatte Fragen an mich, die ich beantworten musste, um in die Bibliothek zu gelangen.";
            else
                return "Die Eule hatte Fragen an mich, die ich beantworten musste, um in die Bibliothek zu gelangen.";
        }

    }
    public static string Info_Uhu_Fragen_Unterwaesche
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Die erste Frage der Eule bezog sich auf die Unterwäsche-Marke des Meisters.";
            else
                return "(Tipps!) Die erste Frage der Eule bezog sich auf die Unterwäsche-Marke des Meisters.";
        }

    }
    public static string Info_Uhu_Fragen_Unterwaesche_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie fand ich heraus, welche Unterwäschemarke der Meister trug?";
            else
                return "Wie fand ich heraus, welche Unterwäschemarke der Meister trug?";
        }

    }
    public static string Info_Uhu_Fragen_Unterwaesche_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Einfach mal nachschauen, was ich für Wäsche fand, konnte keine schlechte Idee sein.";
            else
                return "(Tipp) Einfach mal nachschauen, was ich für Wäsche fand, konnte keine schlechte Idee sein.";
        }

    }
    public static string Info_Uhu_Fragen_Unterwaesche_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) In der Waschküche fand sich sicherlich auch Unterwäsche des Meisters. Ich musste sie mir nur genau anschauen.";
            else
                return "(Hilfe) In der Waschküche fand sich sicherlich auch Unterwäsche des Meisters. Ich musste sie mir nur genau anschauen.";
        }

    }
    public static string Info_Uhu_Fragen_Unterwaesche_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Lösung) In der Waschmaschine in der Waschküche fand sich eine Unterhose, auf der die Marke stand. Das musste ich mir einfach nur anschauen.";
            else
                return "(Lösung) In der Waschmaschine in der Waschküche fand sich eine Unterhose, auf der die Marke stand. Das musste ich mir einfach nur anschauen.";
        }

    }
    public static string Info_Uhu_Fragen_Ruestung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps!) Die zweite Frage der Eule bezog sich auf den früheren Besitzer der Ritterrüstung.";
            else
                return "(Tipps!) Die zweite Frage der Eule bezog sich auf den früheren Besitzer der Ritterrüstung.";
        }

    }
    public static string Info_Uhu_Fragen_Ruestung_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie fand ich heraus, wem die Ritterüstung früher gehört hatte?";
            else
                return "Wie fand ich heraus, wem die Ritterüstung früher gehört hatte?";
        }

    }
    public static string Info_Uhu_Fragen_Ruestung_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipp) Vielleicht war der Name ja eingraviert und musste nur freigelegt werden?";
            else
                return "(Tipp) Vielleicht war der Name ja eingraviert und musste nur freigelegt werden?";
        }

    }
    public static string Info_Uhu_Fragen_Ruestung_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Mit einem Polierlappen ließ sich die Rüstung sicherlich gut reinigen. So etwas konnte sich in der Küche finden.";
            else
                return "(Hilfe) Mit einem Polierlappen ließ sich die Rüstung sicherlich gut reinigen. So etwas konnte sich in der Küche finden.";
        }

    }
    public static string Info_Uhu_Fragen_Ruestung_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Hilfe) Im Küchenschrank in der Küche befand sich ein Polierlappen. Damit konnte ich die Rüstung reinigen, aber die entdeckte Schrift war zu klein. Im Labor des Meisters fand sich eine Lupe in der Schublade, damit konnte ich die Schrift entziffern.";
            else
                return "(Hilfe) Im Küchenschrank in der Küche befand sich ein Polierlappen. Damit konnte ich die Rüstung reinigen, aber die entdeckte Schrift war zu klein. Im Labor des Meisters fand sich eine Lupe in der Schublade, damit konnte ich die Schrift entziffern.";
        }

    }
    public static string Info_Uhu_Fragen_Tier
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[Tipps] Die dritte Frage der Eule bezog sich auf das Lieblingstier des Meisters.";
            else
                return "[Tipps] Die dritte Frage der Eule bezog sich auf das Lieblingstier des Meisters.";
        }

    }
    public static string Info_Uhu_Fragen_Tier_0
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie fand ich heraus, was das Lieblingstier des Meisters war?";
            else
                return "Wie fand ich heraus, was das Lieblingstier des Meisters war?";
        }

    }
    public static string Info_Uhu_Fragen_Tier_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps) Vielleicht fand sich das besagte Lieblingstier ja irgendwo? Hatte der Meister vielleicht in seinem allerprivatesten Refugium solche Hinweise hinterlassen?";
            else
                return "(Tipps) Vielleicht fand sich das besagte Lieblingstier ja irgendwo? Hatte der Meister vielleicht in seinem allerprivatesten Refugium solche Hinweise hinterlassen?";
        }

    }
    public static string Info_Uhu_Fragen_Tier_xxx
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "(Tipps) Vielleicht fand sich das besagte Lieblingstier ja irgendwo? Hatte der Meister vielleicht in seinem allerprivatesten Refugium solche Hinweise hinterlassen?";
            else
                return "(Tipps) Vielleicht fand sich das besagte Lieblingstier ja irgendwo? Hatte der Meister vielleicht in seinem allerprivatesten Refugium solche Hinweise hinterlassen?";
        }

    }
    public static string Info_Neues_Rezept_Wie
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wusste nun, wie man das magische Pulver für den Teleport herstellte. War das mein Ticket aus dem Versteck heraus?";
            else
                return "Ich wusste nun, wie man das magische Pulver für den Teleport herstellte. War das mein Ticket aus dem Versteck heraus?";
        }

    }
    public static string Info_Kaese_Not_Found
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hatte nicht die geringste Ahnung, wo ich hier hier einen Mondstein auftreiben sollte.";
            else
                return "Ich hatte nicht die geringste Ahnung, wo ich hier hier einen Mondstein auftreiben sollte.";
        }

    }
    public static string Info_Kaese_Wozu
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was sollte ich bloß mit einem vertrockneten Stück Käse anfangen?";
            else
                return "Was sollte ich bloß mit einem vertrockneten Stück Käse anfangen?";
        }

    }
    public static string Info_Kiesel_Wozu
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was sollte ich bloß mit einem dämlichen Kiesel anfangen? Da konnte die Elster auch noch so stolz auf ihren depperten Schatz sein...";
            else
                return "Was sollte ich bloß mit einem dämlichen Kiesel anfangen? Da konnte die Elster auch noch so stolz auf ihren depperten Schatz sein...";
        }

    }
    public static string Info_Lichtloser_Stein_Wozu
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was sollte ich bloß mit diesem komischen lichtlosen Kiesel anfangen?";
            else
                return "Was sollte ich bloß mit diesem komischen lichtlosen Kiesel anfangen?";
        }

    }
    public static string Info_Goldmuenze_Woher
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hatte eine goldene Münze unten im Brunnen entdeckt. Wie kam ich dort heran?";
            else
                return "Ich hatte eine goldene Münze unten im Brunnen entdeckt. Wie kam ich dort heran?";
        }

    }
    public static string Info_Goldmuenze_Woher2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was sollte ich hier bloß mit dieser Goldmünze anfangen?";
            else
                return "Was sollte ich hier bloß mit dieser Goldmünze anfangen?";
        }

    }
    public static string Info_Schwamm_Woher
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie sollte ich bloß einen Wunderwarzenschwamm auftreiben? Und was war das eigenetlich für ein bescheuerter Name?";
            else
                return "Wie sollte ich bloß einen Wunderwarzenschwamm auftreiben? Und was war das eigenetlich für ein bescheuerter Name?";
        }

    }
    public static string Info_Alle_Zutaten_da
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hatte alle Zutaten für das magische Pulver. Und jetzt?";
            else
                return "Ich hatte alle Zutaten für das magische Pulver. Und jetzt?";
        }

    }
    public static string Info_Schlacke_Wozu
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hatte einen netten Klumpen Schlacke erzeugt. Was machte ich jetzt damit?";
            else
                return "Ich hatte einen netten Klumpen Schlacke erzeugt. Was machte ich jetzt damit?";
        }

    }
    public static string Info_Neues_Pulver_Wozu
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hatte magisches Pulver hergestellt. Meister Gunnar wäre stolz auf mich. Also solange er nicht mitbekam, was ich sonst noch so ausgefressen hatte.";
            else
                return "Ich hatte magisches Pulver hergestellt. Meister Gunnar wäre stolz auf mich. Also solange er nicht mitbekam, was ich sonst noch so ausgefressen hatte.";
        }

    }
    public static string Info_Ende
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich war hier am Ende. Es gab nichts mehr zu tun. ";
            else
                return "Ich war hier am Ende. Es gab nichts mehr zu tun. ";
        }

    }
    public static string Order_Switch_English_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Spiel würde jetzt gerne auf Englisch wechseln, aber die englischen Texte sind noch gar nicht fertig. Kommt irgendwann noch!";
            else
                return "Das Spiel würde jetzt gerne auf Englisch wechseln, aber die englischen Texte sind noch gar nicht fertig. Kommt irgendwann noch!";
        }

    }
    public static string KnockOn_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich klopfte an [Pl1,Nom]. Nichts weiter geschah.";
            else
                return "Ich klopfte an [Pl1,Nom]. Nothing else happened.";
        }
    }
    public static string KnockOn_Armor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich klopfte an die Ritterrüstung. Es schepperte, ansonsten geschah wenig.";
            else
                return "Ich klopfte an die Ritterrüstung. Es schepperte, ansonsten geschah wenig.";
        }
    }
    public static string Order_Score_891
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines hoffnungslosen Kleinkriminellen...";
            else
                return "... eines hoffnungslosen Kleinkriminellen...";
        }
    }
    public static string Order_Score_892
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines schwächlichen Strauchdiebs...";
            else
                return "... eines schwächlichen Strauchdiebs...";
        }
    }
    public static string Order_Score_893
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines hoffnungsvollen Straßenräubers...";
            else
                return "... eines hoffnungsvollen Straßenräubers...";
        }
    }
    public static string Order_Score_894
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines ambitionierten Verbrechers...";
            else
                return "... eines ambitionierten Verbrechers...";
        }
    }
    public static string Order_Score_895
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines fortgeschrittenen Diebeskünstlers...";
            else
                return "... eines fortgeschrittenen Diebeskünstlers...";
        }
    }
    public static string Order_Score_896
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines Masterminds des unfreiwilligen Eigentumstransfers...";
            else
                return "... eines Masterminds des unfreiwilligen Eigentumstransfers...";
        }
    }
    public static string Order_Score_897
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... eines wahren Meisterdiebs...";
            else
                return "... eines wahren Meisterdiebs...";
        }
    }

    public static string Give_Magpie_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wozu sollte ich der Elster meinen schönen Kä#se anbieten? Vielleicht sollte ich erst mal mit ihr reden.";
            else
                return "Wozu sollte ich der Elster meinen schönen Kä#se anbieten? Vielleicht sollte ich erst mal mit ihr reden.";
        }
    }
    public static string Grab_In_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In [Il1,Nom] konnte ich nicht hineingreifen.";
            else
                return "In [Il1,Nom] konnte ich nicht hineingreifen.";
        }
    }
    public static string Grab_In_Find
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff in [Il1,Nom] hinein und ertastete so einiges.";
            else
                return "Ich griff in [Il1,Nom] hinein und ertastete so einiges.";
        }
    }
    public static string Drop_Pouch_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Beutelchen behielt ich bei mir. Wer weiß, ob ich es nochmal brauchte.";
            else
                return "Das Beutelchen behielt ich bei mir. Wer weiß, ob ich es nochmal brauchte.";
        }
    }


    public static string OrderFeedback_PathFileNameFromFileName_14053
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "\\documents\\My Games\\Das Versteck des Meisters";
            else
                return "\\documents\\My Games\\Das Versteck des Meisters";
        }
    }
    public static string OrderFeedback_PathFileNameFromFileName_MAUI
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "\\documents\\My Games\\Das Versteck des Meisters";
            else
                return "\\documents\\My Games\\Das Versteck des Meisters";
        }
    }
    public static string MAUI_UI_Home_WindowTitle
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Versteck des Meisters - eine Art Exitgame";
            else
                return "Das Versteck des Meisters - eine Art Exitgame";
        }
    }

    public static string Order_Story_Info
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die komplette bisherige Geschichte liegt als 'Versteck_Meister_Story_Recording.html' im Verzeichnis 'Das Versteck des Meisters'.";
            else
                return "Die komplette bisherige Geschichte liegt als 'Versteck_Meister_Story_Recording.html' im Verzeichnis 'Das Versteck des Meisters'.";
        }

    }
    public static string OrderFeedback_LoadMC_Person_I_14024
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "\\documents\\My Games\\Das Versteck des Meisters";
            else
                return "\\documents\\My Games\\Das Versteck des Meisters";
        }
    }

    public static string Order_ManualDialog_Person_Self_10331
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "[benutze Gegenstand mit anderem Gegenstand] Wendet einen Gegenstand mit einem anderen an. Was genau passiert, sollte sich aus dem Kontext ergeben: \"Benutze Feuerzeug mit Zigarette\". Aber vorsicht: Das hier ist ein Nichtraucherspiel. Wer im Versteck des Meisters raucht, zahlt 200€ für die Endreinigung.";
            else
                return "[benutze Gegenstand mit anderem Gegenstand] Wendet einen Gegenstand mit einem anderen an. Was genau passiert, sollte sich aus dem Kontext ergeben: \"Benutze Feuerzeug mit Zigarette\". Aber vorsicht: Das hier ist ein Nichtraucherspiel. Wer im Versteck des Meisters raucht, zahlt 200€ für die Endreinigung.";
        }
    }

    public static string Order_ManualDialog_Person_Self_10315
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Interactive Fiction ist eine Geschichte, die du als Spieler selbst vorantreiben musst.<br>Du bewegst dich durch eine fremde Welt, begegnest Leuten und findest Dinge. Wie die Geschichte sich entwickelt, hängt davon ab, was du den Leuten erzählst, was du mit den Gegenständen anfängst und zu welchen Orten du dich wendest. Dabei kommunizierst du mit der Geschichte über Texteingaben oder Multiple Choice. Genau so ist es auch bei \"Das Versteck des Meisters\".";
            else
                return "Interactive Fiction ist eine Geschichte, die du als Spieler selbst vorantreiben musst.<br>Du bewegst dich durch eine fremde Welt, begegnest Leuten und findest Dinge. Wie die Geschichte sich entwickelt, hängt davon ab, was du den Leuten erzählst, was du mit den Gegenständen anfängst und zu welchen Orten du dich wendest. Dabei kommunizierst du mit der Geschichte über Texteingaben oder Multiple Choice. Genau so ist es auch bei \"Das Versteck des Meisters\".";
        }
    }
    public static string Order_ManualDialog_Person_Self_10316
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "\"Das Versteck des Meisters\" ist eine interactive Fiction (eine interaktive Geschichte), die per Multiple Choice sowie (größtenteils) auch per Texteingabe gespielt werden kann.<br>";
            else
                return "\"Das Versteck des Meisters\" ist eine interactive Fiction (eine interaktive Geschichte), die per Multiple Choice sowie (größtenteils) auch per Texteingabe gespielt werden kann.<br>";
        }
    }
    public static string Order_ManualDialog_Person_Self_10317
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "\"Das Versteck des Meisters\" lässt sich komplett mit Multiple Choice spielen, und zwar in zwei Modi: Wählst du \"Simples Multiple Choice\", wirst du weniger Optionen erhalten, was du machen kannst. Die Lösungen werden dadurch etwas einfacher. Wählst du diese Option nicht, erhältst du mehr Optionen. Lösbar ist das Spiel in jedem Fall. Wähle die einfachere Option, wenn du dich von zuvielen Handlungsmöglichkeiten umzingelt fühlst.<br>Bei Multiple Choice kannst du Gegenstände, Personen oder Orte direkt anklicken: Entweder im Fließtext oder in einer der zuschaltbaren Listen. Sogleich erhältst du eine Auswahl an Möglichkeiten, die du nun hast. Einfach was auswählen - und schon wird es ausgeführt, oder dir mitgeteilt, warum das gerade eine schlechte Idee war.<br>Du kannst über die Befehlsliste auch den umgekehrten Weg gehen und zuerst einmal einen Befehl auswählen. Wenn der Befehl nur mit einem Objekt funktioniert, wirst du danach gefragt.<br>Dialoge und alle Entscheidungen im Spiel funktionieren grundsätzlich über Multiple Choice. ";
            else
                return "\"Das Versteck des Meisters\" lässt sich komplett mit Multiple Choice spielen, und zwar in zwei Modi: Wählst du \"Simples Multiple Choice\", wirst du weniger Optionen erhalten, was du machen kannst. Die Lösungen werden dadurch etwas einfacher. Wählst du diese Option nicht, erhältst du mehr Optionen. Lösbar ist das Spiel in jedem Fall. Wähle die einfachere Option, wenn du dich von zuvielen Handlungsmöglichkeiten umzingelt fühlst.<br>Bei Multiple Choice kannst du Gegenstände, Personen oder Orte direkt anklicken: Entweder im Fließtext oder in einer der zuschaltbaren Listen. Sogleich erhältst du eine Auswahl an Möglichkeiten, die du nun hast. Einfach was auswählen - und schon wird es ausgeführt, oder dir mitgeteilt, warum das gerade eine schlechte Idee war.<br>Du kannst über die Befehlsliste auch den umgekehrten Weg gehen und zuerst einmal einen Befehl auswählen. Wenn der Befehl nur mit einem Objekt funktioniert, wirst du danach gefragt.<br>Dialoge und alle Entscheidungen im Spiel funktionieren grundsätzlich über Multiple Choice. ";
        }
    }
    public static string Order_ManualDialog_Person_Self_10318
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "\"Das Versteck des Meisters\" beinhaltet einen klassischen Textparser. Eingaben wie \"töte die spröde Kröte mit der schnöden Tröte\" werden selbstverständlich verstanden (sofern Kröte und Tröte vor Ort sind). Wenn es für deine Eingaben mehrere Interpretationsmöglichkeiten gibt, fragt das Spiel nach. Redest du mit Personen oder musst du eine Entscheidung treffen, kommt immer auch Multiple Choice ins Spiel. Alle Multiple Choice Menüs können übrigens auch mit der Tastatur bedient werden.<br>Wenn du ein fortgeschrittener Spieler bist und die volle Spieltiefe haben willst, sei dir die Texteingabe empfohlen.";
            else
                return "\"Das Versteck des Meisters\" beinhaltet einen klassischen Textparser. Eingaben wie \"töte die spröde Kröte mit der schnöden Tröte\" werden selbstverständlich verstanden (sofern Kröte und Tröte vor Ort sind). Wenn es für deine Eingaben mehrere Interpretationsmöglichkeiten gibt, fragt das Spiel nach. Redest du mit Personen oder musst du eine Entscheidung treffen, kommt immer auch Multiple Choice ins Spiel. Alle Multiple Choice Menüs können übrigens auch mit der Tastatur bedient werden.<br>Wenn du ein fortgeschrittener Spieler bist und die volle Spieltiefe haben willst, sei dir die Texteingabe empfohlen.";
        }
    }

    public static string Order_ManualDialog_Person_Self_10310
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Über 'Das Versteck des Meisters'";
            else
                return "Über 'Das Versteck des Meisters'";
        }
    }

    public static string AttachTo_Schale_Ok
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich befestigte die Schale an der Halterung.";
            else
                return "Ich befestigte die Schale an der Halterung.";
        }
    }
    public static string Heat_NoFire
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Kerzenhalter war ausgeschaltet.";
            else
                return "Der Kerzenhalter war ausgeschaltet.";
        }
    }
    public static string Heat_NoTray
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Metallschale war nicht vernünftig befestigt.";
            else
                return "Die Metallschale war nicht vernünftig befestigt.";
        }
    }
    public static string Heat_NoIngredients
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Zutaten waren nicht alle so an ihrem Platz, wie sie das sein sollten.";
            else
                return "Die Zutaten waren nicht alle so an ihrem Platz, wie sie das sein sollten.";
        }
    }
    public static string Heat_Success
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich erhitzte die Metallschale mit den Zutaten darin, und konnte mitansehen, wie sie zu Schlacke verschmolzen.";
            else
                return "Ich erhitzte die Metallschale mit den Zutaten darin, und konnte mitansehen, wie sie zu Schlacke verschmolzen.";
        }
    }
    public static string Eat_Forest_Gras
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich überlegte einen Sekundenbruchteil lang, mich gierig auf das Waldgras zu stürzen und es in mich hinein zu schlingen. Dann fiel mir wieder ein, dass ich vorhin gut gegessen und daher überhaupt keinen Hunger hatte.";
            else
                return "Ich überlegte einen Sekundenbruchteil lang, mich gierig auf das Waldgras zu stürzen und es in mich hinein zu schlingen. Dann fiel mir wieder ein, dass ich vorhin gut gegessen und daher überhaupt keinen Hunger hatte.";
        }
    }
    public static string Take_Eule
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Eule war auf dem Sims festgeklebt. Vermutlich ein Klimaschützer.";
            else
                return "Die Eule war auf dem Sims festgeklebt. Vermutlich ein Klimaschützer.";
        }
    }
    public static string Take_Elster
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Elster war magisch festgekettet. Die würde ich wohl nicht hier wegbekommen.";
            else
                return "Die Elster war magisch festgekettet. Die würde ich wohl nicht hier wegbekommen.";
        }
    }
    public static string Take_Schale
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Schale war super dort, wo sie jetzt war.";
            else
                return "Die Schale war super dort, wo sie jetzt war.";
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
                return "DAs letzte, was dieses Buch brauchte, war noch eine weitere Ladung magischer Lebensenergie. Bitte, bitte nicht.";
            else
                return "DAs letzte, was dieses Buch brauchte, war noch eine weitere Ladung magischer Lebensenergie. Bitte, bitte nicht.";
        }
    }
    public static string Touch_Angry_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff nach dem hasserfüllten Buch, und es schnappte zähnefletschend nach mir.";
            else
                return "Ich griff nach dem hasserfüllten Buch, und es schnappte zähnefletschend nach mir.";
        }
    }
    public static string Touch_Crazy_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff nach dem verrückten Buch. Das verrückte Gekicher, das daraus dring, ließ mich inne halten.";
            else
                return "Ich griff nach dem verrückten Buch. Das verrückte Gekicher, das daraus dring, ließ mich inne halten.";
        }
    }
    public static string Touch_Weird_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff nach dem seltsamen Buch. Das wirre Geflüster und das Rascheln der Buchseiten schreckten mich ab davor, es zu berühren.";
            else
                return "Ich griff nach dem seltsamen Buch. Das wirre Geflüster und das Rascheln der Buchseiten schreckten mich ab davor, es zu berühren.";
        }
    }
    public static string Touch_Demonic_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff nach dem dämonischen Buch. Die glutroten Augen auf dem Einband richteten sich erwartungsvoll auf mich. Rasch ließ ich von meinem Vorhaben ab.";
            else
                return "Ich griff nach dem dämonischen Buch. Die glutroten Augen auf dem Einband richteten sich erwartungsvoll auf mich. Rasch ließ ich von meinem Vorhaben ab.";
        }
    }
    public static string Touch_Satanic_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff nach dem satanischen Buch. Die Seiten raschelten erwartungsvoll, als wollten sie mich auf der Stelle verschlingen. Rasch ließ ich von meinem Vorhaben ab.";
            else
                return "Ich griff nach dem satanischen Buch. Die Seiten raschelten erwartungsvoll, als wollten sie mich auf der Stelle verschlingen. Rasch ließ ich von meinem Vorhaben ab.";
        }
    }
    public static string SpreadOn_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie soll [Il1,Akk] auf [Il2,Nom] gestreut werden?";
            else
                return "Wie soll [Il1,Akk] auf [Il2,Nom] gestreut werden?";
        }
    }
    public static string SpreadOn_Clothes_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich sollte die Wäsche erst mal aus der Waschmaschine holen, ehe ich irgendwelche Experimente damit machte.";
            else
                return "Ich sollte die Wäsche erst mal aus der Waschmaschine holen, ehe ich irgendwelche Experimente damit machte.";
        }
    }
    public static string SpreadOn_Clothes_WWS
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich streute den Inhalt des Beutels auf die feuchte Wäsche. In atemberaubender Geschwindigkeit wuchs darauf ein riesiger Wunderwarzenschwamm, der gar eklig anzusehen war..";
            else
                return "Ich streute den Inhalt des Beutels auf die feuchte Wäsche. In atemberaubender Geschwindigkeit wuchs darauf ein riesiger Wunderwarzenschwamm, der gar eklig anzusehen war..";
        }
    }
    public static string Enlight_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie soll [Il1,Akk] mit [Il2,Nom] erleuchtet werden?";
            else
                return "Wie soll [Il1,Akk] mit [Il2,Nom] erleuchtet werden?";
        }
    }
    public static string Enlight_Fail_NoCoin
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich leuchtete in das Wasser, aber fand nichts weiter neues.";
            else
                return "Ich leuchtete in das Wasser, aber fand nichts weiter neues.";
        }
    }
    public static string Enlight_Fail_NoLight
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich leuchtete mit dem Kerzenhalter in das Wasser, aber das hätte wirklich deutlich besser funktioniert, wenn die Kerze an gewesen wäre.";
            else
                return "Ich leuchtete mit dem Kerzenhalter in das Wasser, aber das hätte wirklich deutlich besser funktioniert, wenn die Kerze an gewesen wäre.";
        }
    }
    public static string Enlight_Find_Coin
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich leuchtete mit dem Kerzenhalter in das Wasser. Irgendwo tief auf dem Grund blitzte etwas helles, metallenes auf. Wie eine Münze.";
            else
                return "Ich leuchtete mit dem Kerzenhalter in das Wasser. Irgendwo tief auf dem Grund blitzte etwas helles, metallenes auf. Wie eine Münze.";
        }
    }

    public static string Verb_beleuchte
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "beleuchte";
            else
                return "beleuchte";
        }
    }
    public static string Verb_erhelle
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "erhelle";
            else
                return "erhelle";
        }
    }
    public static string Verb_bescheine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "bescheine";
            else
                return "bescheine";
        }
    }


    public static string DoRR_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mit einem leichten Ächzen wich alles \"Leben\" aus der Ritterrüstung.";
            else
                return "Mit einem leichten Ächzen wich alles \"Leben\" aus der Ritterrüstung.";
        }
    }

    public static string DoRR_Seufzen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus der Richtung der Ritterrüstung dran ein leises Seufzen an mein Ohr.";
            else
                return "Aus der Richtung der Ritterrüstung dran ein leises Seufzen an mein Ohr.";
        }
    }
    public static string DoRR_Bewegen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus den Augenwinkeln bemerkte ich etwas. Hatte sich die Ritterrüstung etwa bewegt?";
            else
                return "Aus den Augenwinkeln bemerkte ich etwas. Hatte sich die Ritterrüstung etwa bewegt?";
        }
    }
    public static string DoRR_Wispern
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine fast unhörbare Stimme drang an mein Ohr: \"Die Klaue! Die Klaue ist hier!\" Hatte da etwa die Ritterrüstung gesprochen?";
            else
                return "Eine fast unhörbare Stimme drang an mein Ohr: \"Die Klaue! Die Klaue ist hier!\" Hatte da etwa die Ritterrüstung gesprochen?";
        }
    }

    public static string DoRR_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Ritterrüstung klapperte vor sich hin.";
            else
                return "Die Ritterrüstung klapperte vor sich hin.";
        }
    }
    public static string DoRR_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Ritterrüstung grölte: \"Einer, einer geht noch rein!\"";
            else
                return "Die Ritterrüstung grölte: \"Einer, einer geht noch rein!\"";
        }
    }
    public static string DoRR_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Ritterrüstung führte ein kleines Tänzchen auf.";
            else
                return "Die Ritterrüstung führte ein kleines Tänzchen auf.";
        }
    }
    public static string DoRR_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Ritterrüstung schaute in meine Richtung. \"Ihre Papiere bitte!\" ";
            else
                return "Die Ritterrüstung schaute in meine Richtung. \"Ihre Papiere bitte!\" ";
        }
    }
    public static string DoRR_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Ritterrüstung drehte quietschend ihren Kopf hin und her.";
            else
                return "Die Ritterrüstung drehte quietschend ihren Kopf hin und her.";
        }
    }
    public static string Do_Fish_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mit einem letzten \"Blub\" wich alles \"Leben\" aus dem Fisch.";
            else
                return "Mit einem letzten \"Blub\" wich alles \"Leben\" aus dem Fisch.";
        }
    }
    public static string Do_Fish_Reaktion1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Von irgendwoher drang ein leises \"Blub\". ";
            else
                return "Von irgendwoher drang ein leises \"Blub\". ";
        }
    }
    public static string Do_Fish_Reaktion2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Von irgendwoher drang ein Rascheln. ";
            else
                return "Von irgendwoher drang ein Rascheln. ";
        }
    }
    public static string Do_Fish_Reaktion3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Von irgendwoher drang ein glucksendes Geräusch.";
            else
                return "Von irgendwoher drang ein glucksendes Geräusch.";
        }
    }
    public static string Do_Fish_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der ausgestopfte Fisch blubberte vor sich hin.";
            else
                return "Der ausgestopfte Fisch blubberte vor sich hin.";
        }
    }
    public static string Do_Fish_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der ausgestopfte Fisch spuckte eine Staubfontäne aus.";
            else
                return "Der ausgestopfte Fisch spuckte eine Staubfontäne aus.";
        }
    }
    public static string Do_Fish_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der ausgestopfte Fisch sah mich an und sagte \"Blub\".";
            else
                return "Der ausgestopfte Fisch sah mich an und sagte \"Blub\".";
        }
    }
    public static string Do_Fish_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der ausgestopfte Fisch zappelte fröhlich vor sich hin.";
            else
                return "Der ausgestopfte Fisch zappelte fröhlich vor sich hin.";
        }
    }
    public static string Do_Fish_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der ausgestopfte Fisch versuchte, davon zu schwimmen, was ohne Wasser nur mäßig gut gelang.";
            else
                return "Der ausgestopfte Fisch versuchte, davon zu schwimmen, was ohne Wasser nur mäßig gut gelang.";
        }
    }
    public static string Do_Magpie_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Elster krächzte noch einmal kurz, dann wurde sie wieder leblos.";
            else
                return "Die Elster krächzte noch einmal kurz, dann wurde sie wieder leblos.";
        }
    }
    public static string Do_Parrot_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mit einem leisen Krächzen verwandelte sich der Papagei wieder in seine eigentliche, ausgestopfte Version zurück.";
            else
                return "Mit einem leisen Krächzen verwandelte sich der Papagei wieder in seine eigentliche, ausgestopfte Version zurück.";
        }
    }
    public static string Do_Parrot_Reaktion1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hatte ich da eben ein leises Krächzen gehört?";
            else
                return "Hatte ich da eben ein leises Krächzen gehört?";
        }
    }
    public static string Do_Parrot_Reaktion2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der ausgestopfte Papagei schien mich auffordernd anzustarren.";
            else
                return "Der ausgestopfte Papagei schien mich auffordernd anzustarren.";
        }
    }
    public static string Do_Parrot_Reaktion3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der ausgestopfte Papagei schien langsam sein Gefieder zu plustern. Äh, ich musste mir das einbilden...";
            else
                return "Der ausgestopfte Papagei schien langsam sein Gefieder zu plustern. Äh, ich musste mir das einbilden...";
        }
    }
    public static string Do_Parrot_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der ausgestopfte Papagei musterte mich unverhohlen. \"Fürwahr, fürwahr, man kann sich seinen Besuch nicht immer aussuchen.\" ";
            else
                return "Der ausgestopfte Papagei musterte mich unverhohlen. \"Fürwahr, fürwahr, man kann sich seinen Besuch nicht immer aussuchen.\" ";
        }
    }
    public static string Do_Parrot_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der ausgestopfte Papagei musterte mich unverchämt. \"Hat dir schon mal jemand gesagt, dass du sehr viel besser aussähest, wenn du dein Gesicht mit Nougatcreme einriebest?\" ";
            else
                return "Der ausgestopfte Papagei musterte mich unverchämt. \"Hat dir schon mal jemand gesagt, dass du sehr viel besser aussähest, wenn du dein Gesicht mit Nougatcreme einriebest?\" ";
        }
    }
    public static string Do_Parrot_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der ausgestopfte Papagei gähnte genervt. ";
            else
                return "Der ausgestopfte Papagei gähnte genervt. ";
        }
    }
    public static string Do_Parrot_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der ausgestopfte Papagei plusterte sein Gefieder auf. ";
            else
                return "Der ausgestopfte Papagei plusterte sein Gefieder auf. ";
        }
    }
    public static string Do_Parrot_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der ausgestopfte Papagei musterte mich herablassend.";
            else
                return "Der ausgestopfte Papagei musterte mich herablassend.";
        }
    }

    public static string Do_Magpie_Reaktion1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hatte ich da eben aus der Richtung der Elster ein leises Krächzen gehört?";
            else
                return "Hatte ich da eben aus der Richtung der Elster ein leises Krächzen gehört?";
        }
    }
    public static string Do_Magpie_Reaktion2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Diese dämliche Elster schien mich ausgesprochen unverschämterweise anzustarren.";
            else
                return "Diese dämliche Elster schien mich ausgesprochen unverschämterweise anzustarren.";
        }
    }
    public static string Do_Magpie_Reaktion3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus den Augenwinkeln heraus nahm ich wahr, dass die Elster sich bewegt hatte. Nur einen Millimeter, aber ich war mir sicher!";
            else
                return "Aus den Augenwinkeln heraus nahm ich wahr, dass die Elster sich bewegt hatte. Nur einen Millimeter, aber ich war mir sicher!";
        }
    }
    public static string Do_Magpie_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Elster schimpfte mit derartig schrecklichen Schimpfworten vor sich hin, dass ich ganz rot wurde.";
            else
                return "Die Elster schimpfte mit derartig schrecklichen Schimpfworten vor sich hin, dass ich ganz rot wurde.";
        }
    }
    public static string Do_Magpie_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Elster schnappte nach mir. Zum Glück war ich schneller.";
            else
                return "Die Elster schnappte nach mir. Zum Glück war ich schneller.";
        }
    }
    public static string Do_Magpie_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Elster pickte nach meiner Hand. Zum Glück war ich schneller.";
            else
                return "Die Elster pickte nach meiner Hand. Zum Glück war ich schneller.";
        }
    }
    public static string Do_Magpie_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Elster krächzte eine schiere Schimpfkanonade auf mich los.";
            else
                return "Die Elster krächzte eine schiere Schimpfkanonade auf mich los.";
        }
    }
    public static string Do_Magpie_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Elster schaute mich wüte4nd an.";
            else
                return "Die Elster schaute mich wüte4nd an.";
        }
    }
    public static string Do_Skeleton_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Knochen des Skeletts klapperten noch einmal vor sich hin, dann war wieder Stille.";
            else
                return "Die Knochen des Skeletts klapperten noch einmal vor sich hin, dann war wieder Stille.";
        }
    }
    public static string DoSkelett_Reaktion1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Knochen des Skeletts klapperten leise vor sich hin.";
            else
                return "Die Knochen des Skeletts klapperten leise vor sich hin.";
        }
    }
    public static string DoSkelett_Reaktion2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Skelett schien mich durchdringend anzustarren.";
            else
                return "Das Skelett schien mich durchdringend anzustarren.";
        }
    }
    public static string DoSkelett_Reaktion3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Skelett schien irgendwas zu wispern und die Hand nach mir zu recken.";
            else
                return "Das Skelett schien irgendwas zu wispern und die Hand nach mir zu recken.";
        }
    }
    public static string DoSkelett_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Skelett nahm ein Buch vom Stapel, drückte einen Stempel auf ein Einlegeblatt, und legte es dann auf den nächsten Stapel.";
            else
                return "Das Skelett nahm ein Buch vom Stapel, drückte einen Stempel auf ein Einlegeblatt, und legte es dann auf den nächsten Stapel.";
        }
    }
    public static string DoSkelett_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Skelett sah mich durchdringend an. \"Keine Eselsohren in die Bücher machen!\" ";
            else
                return "Das Skelett sah mich durchdringend an. \"Keine Eselsohren in die Bücher machen!\" ";
        }
    }
    public static string DoSkelett_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Skelett stützte den Kopf auf die Hände und stöhnte: \"Das wird mir alles zuviel...\" ";
            else
                return "Das Skelett stützte den Kopf auf die Hände und stöhnte: \"Das wird mir alles zuviel...\" ";
        }
    }
    public static string DoSkelett_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Skelett musterte mich skeptisch. \"Die Bücher in den Regalen bitte nicht anfassen. Sonst endest du wie ich.\" ";
            else
                return "Das Skelett musterte mich skeptisch. \"Die Bücher in den Regalen bitte nicht anfassen. Sonst endest du wie ich.\" ";
        }
    }
    public static string DoSkelett_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Skelett summte leise vor sich hin.";
            else
                return "Das Skelett summte leise vor sich hin.";
        }
    }
    public static string Do_Snake_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein letztes Zischeln, dann wurde die Snake wieder steif und leblos.";
            else
                return "Ein letztes Zischeln, dann wurde die Snake wieder steif und leblos.";
        }
    }
    public static string Do_Snake_Reaktion1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hatte ich da eben ein leises Zischeln gehört?";
            else
                return "Hatte ich da eben ein leises Zischeln gehört?";
        }
    }
    public static string Do_Snake_Reaktion2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Dieses Rascheln gerade hatte ich mir doch nicht eingebildet!";
            else
                return "Dieses Rascheln gerade hatte ich mir doch nicht eingebildet!";
        }
    }
    public static string Do_Snake_Reaktion3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich vernahm ein leises Knistern. Woher das wohl kam?";
            else
                return "Ich vernahm ein leises Knistern. Woher das wohl kam?";
        }
    }
    public static string Do_Snake_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Schlange zischelte wütend.";
            else
                return "Die Schlange zischelte wütend.";
        }
    }
    public static string Do_Snake_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Schlange zischelte fröhlich.";
            else
                return "Die Schlange zischelte fröhlich.";
        }
    }
    public static string Do_Snake_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Schlange zischelte zischelnd.";
            else
                return "Die Schlange zischelte zischelnd.";
        }
    }
    public static string Do_Snake_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Schlange schlängelte sich.";
            else
                return "Die Schlange schlängelte sich.";
        }
    }
    public static string Do_Snake_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Schlange bleckte mit ihrer langen Zunge um sich.";
            else
                return "Die Schlange bleckte mit ihrer langen Zunge um sich.";
        }
    }

    public static string DoOwl_Finish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mit einem leichten \"Uhuuuh\" wich alles \"Leben\" aus der Eule.";
            else
                return "Mit einem leichten \"Uhuuuh\" wich alles \"Leben\" aus der Eule.";
        }
    }

    public static string DoOwl_Seufzen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus der Richtung der Eule dran ein leises Gurren an mein Ohr.";
            else
                return "Aus der Richtung der Eule dran ein leises Gurren an mein Ohr.";
        }
    }
    public static string DoOwl_Bewegen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus den Augenwinkeln bemerkte ich etwas. Hatte sich die ausgestopfte Eule etwa bewegt?";
            else
                return "Aus den Augenwinkeln bemerkte ich etwas. Hatte sich die ausgestopfte Eule etwa bewegt?";
        }
    }
    public static string DoOwl_Wispern
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine fast unhörbare Stimme drang an mein Ohr. Ich konnte sie nicht verstehen.";
            else
                return "Eine fast unhörbare Stimme drang an mein Ohr: Ich konnte sie nicht verstehen.";
        }
    }

    public static string DoOwl_Action1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Eule stieß leise Rufe aus.";
            else
                return "Die Eule stieß leise Rufe aus.";
        }
    }
    public static string DoOwl_Action2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Eule putzte sich unter dem linken Flügel.";
            else
                return "Die Eule putzte sich unter dem linken Flügel.";
        }
    }
    public static string DoOwl_Action3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Eule putzte sich unter dem rechten Flügel.";
            else
                return "Die Eule putzte sich unter dem rechten Flügel.";
        }
    }
    public static string DoOwl_Action4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Eule musterte mich voller Weisheit und Güte.";
            else
                return "Die Eule musterte mich voller Weisheit und Güte.";
        }
    }
    public static string DoOwl_Action5
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Eule musterte mich ungeduldig.";
            else
                return "Die Eule musterte mich ungeduldig.";
        }
    }

    public static string Adv_Person_Knights_Armor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die klapprige Ritterrüstung stand etwas windschief in der Gegend herum.";
            else
                return "Die klapprige Ritterrüstung stand etwas windschief in der Gegend herum.";
        }
    }
    public static string Adv_Person_Owl
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Eule musterte mich mit aller Weisheit im Blick, derer ausgestopfte Eulen eben so fähig sind.";
            else
                return "Die Eule musterte mich mit aller Weisheit im Blick, derer ausgestopfte Eulen eben so fähig sind.";
        }
    }
    public static string Adv_Person_Librarian
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Skelett ruhte recht entspannt auf einem Bürostuhl hinter dem Bibliothekstresen.";
            else
                return "Das Skelett ruhte recht entspannt auf einem Bürostuhl hinter dem Bibliothekstresen.";
        }
    }
    public static string Adv_Person_Fish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Fisch glotze mich an wie... wie ein Fisch!";
            else
                return "Der Fisch glotze mich an wie... wie ein Fisch!";
        }
    }
    public static string Adv_Person_Parrot
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein ausgestopfter grüner Papagei mit einigen lustigen bunten Federn.";
            else
                return "Ein ausgestopfter grüner Papagei mit einigen lustigen bunten Federn.";
        }
    }
    public static string Adv_Person_Magpie
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Elster musterte mich unverhohlen, als hätte sie die Absicht, im nächsten Moment meine sämtlichen Wertgegenstände an sich zu reißen.";
            else
                return "Die Elster musterte mich unverhohlen, als hätte sie die Absicht, im nächsten Moment meine sämtlichen Wertgegenstände an sich zu reißen.";
        }
    }
    public static string Adv_Person_Snake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Schlange starrte mich aus toten Augen an, als wolle sie mich in Sicherheit wiegen vor ihrem tödlichen Biss. Aber nicht mit mir!";
            else
                return "Die Schlange starrte mich aus toten Augen an, als wolle sie mich in Sicherheit wiegen vor ihrem tödlichen Biss. Aber nicht mit mir!";
        }
    }
    public static string Take_Underwear
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich ließ die Unterhose liegen, wo sie war. Wenn Meister Gunnar seiner Wäsche bedurfte, dann sollte er selbst drauf achten.";
            else
                return "Ich ließ die Unterhose liegen, wo sie war. Wenn Meister Gunnar seiner Wäsche bedurfte, dann sollte er selbst drauf achten.";
        }
    }
    public static string Take_Coin
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Münze schimmerte tief unten im Brunnen. Ich konnte sie mit der Hand nicht erreichen und in das eiskalte Wasser eintauchen konnte ich auch nicht.";
            else
                return "Die Münze schimmerte tief unten im Brunnen. Ich konnte sie mit der Hand nicht erreichen und in das eiskalte Wasser eintauchen konnte ich auch nicht.";
        }
    }
    public static string Take_Supermagic_Powder
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich füllte das magische Pülverchen in mein kleines magisches Beutelchen.";
            else
                return "Ich füllte das magische Pülverchen in mein kleines magisches Beutelchen.";
        }
    }
    public static string Take_Clothes
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Angewidert zog ich die Stinkewäsche aus der Waschmaschine. Ich schaffte es gerade noch, sie in den Wäschekorb zu befördern, bevor mir redlich schlecht wurde.";
            else
                return "Angewidert zog ich die Stinkewäsche aus der Waschmaschine. Ich schaffte es gerade noch, sie in den Wäschekorb zu befördern, bevor mir redlich schlecht wurde.";
        }
    }
    public static string Take_Tuermatte
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich griff nach der Türmatte, ließ sie aber dann doch liegen. Was wollte ich mit dem ollen Ding?";
            else
                return "Ich griff nach der Türmatte, ließ sie aber dann doch liegen. Was wollte ich mit dem ollen Ding?";
        }
    }

    public static string Touch_Fish_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte den Fisch mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "Ich wollte den Fisch mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
        }
    }
    public static string Touch_Fish_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte den Fisch mit der Klaue. Sofort belebte sich der Fisch und zappelte wie verrückt. Hm, ich musste wohl keine Angst haben, dass er außerhalb des Wasser erstickte...";
            else
                return "Ich berührte den Fisch mit der Klaue. Sofort belebte sich der Fisch und zappelte wie verrückt. Hm, ich musste wohl keine Angst haben, dass er außerhalb des Wasser erstickte...";
        }
    }
    public static string Touch_Fish_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte den Fisch mit der Klaue. Da der Fisch schon wach war, hielt sich der Effekt in Grenzen.";
            else
                return "Ich berührte den Fisch mit der Klaue. Da der Fisch schon wach war, hielt sich der Effekt in Grenzen.";
        }
    }
    public static string Touch_Magpie_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte die Elster mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "Ich wollte die Elster mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
        }
    }
    public static string Touch_Magpie_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die Elster mit der Klaue. Sofort belebte sich der Vogel und schimpfte krächzend wie verrückt. Warum mault er mich eigentlich an? Verdammtes Mistvieh.";
            else
                return "Ich berührte die Elster mit der Klaue. Sofort belebte sich der Vogel und schimpfte krächzend wie verrückt. Warum mault er mich eigentlich an? Verdammtes Mistvieh.";
        }
    }
    public static string Touch_Magpie_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die Elster mit der Klaue. Da die Elster schon wach war, hielt sich der Effekt in Grenzen.";
            else
                return "Ich berührte die Elster mit der Klaue. Da die Elster schon wach war, hielt sich der Effekt in Grenzen.";
        }
    }
    public static string Touch_Parrot_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte den Papageien mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "Ich wollte den Papageien mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
        }
    }
    public static string Touch_Parrot_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte den Papageien mit der Klaue. Sofort belebte sich der Vogel und bauschte sein Gefieder auf.";
            else
                return "Ich berührte den Papageien mit der Klaue. Sofort belebte sich der Vogel und bauschte sein Gefieder auf.";
        }
    }
    public static string Touch_Parrot_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte den Papageien mit der Klaue. Da der Papagei schon wach war, hielt sich der Effekt in Grenzen.";
            else
                return "Ich berührte den Papageien mit der Klaue. Da der Papagei schon wach war, hielt sich der Effekt in Grenzen.";
        }
    }
    public static string Touch_Snake_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte die Schlange mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "Ich wollte die Schlange mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
        }
    }
    public static string Touch_Snake_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die Schlange mit der Klaue. Sofort belebte sich das Vieh und schlängelte fröhlich vor sich hin.";
            else
                return "Ich berührte die Schlange mit der Klaue. Sofort belebte sich das Vieh und schlängelte fröhlich vor sich hin.";
        }
    }
    public static string Touch_Snake_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die Schlange mit der Klaue. Da die Schlange schon wach war, hielt sich der Effekt in Grenzen.";
            else
                return "Ich berührte die Schlange mit der Klaue. Da die Schlange schon wach war, hielt sich der Effekt in Grenzen.";
        }
    }

    public static string Touch_Librarian_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte das Skelett mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "Ich wollte das Skelett mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
        }
    }
    public static string Touch_Librarian_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte das Skelett mit der Klaue. Sofort ruckte es hoch und schauten mich verstört an. \"Wenn du die Abgabefrist überschritten hast, wird es teuer!\"";
            else
                return "Ich berührte das Skelett mit der Klaue. Sofort ruckte es hoch und schauten mich verstört an. \"Wenn du die Abgabefrist überschritten hast, wird es teuer!\"";
        }
    }
    public static string Touch_Librarian_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte das Skelett mit der Klaue. Da das Skelett schon wach war, musterte es mich nur etwas verwirrt.";
            else
                return "Ich berührte das Skelett mit der Klaue. Da das Skelett schon wach war, musterte es mich nur etwas verwirrt.";
        }
    }



    public static string Touch_Owl_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte die Eule mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "Ich wollte die Eule mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
        }
    }
    public static string Touch_KnightsArmour_UnstableClaw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wollte die Ritterrüstung mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
            else
                return "Ich wollte die Ritterrüstung mit der Klaue berühren. Aber ich hatte Angst, das mir diese instabile Konstruktion um die Ohren flog und die Klaue auf den Boden purzelte. Ich musste meinen Klauenhalter irgendwie stabilisieren.";
        }
    }
    public static string Touch_Owl_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die ausgestopfte Eule mit der Klaue. Sofort öffneten sich die Augen der Eule und schauten mich verschlafen an. \"Ich hoffe, es ist wichtig.\"<br>War das eigentlich normal, dass Eulen gähnen?";
            else
                return "Ich berührte die ausgestopfte Eule mit der Klaue. Sofort öffneten sich die Augen der Eule und schauten mich verschlafen an. \"Ich hoffe, es ist wichtig.\"<br>War das eigentlich normal, dass Eulen gähnen?";
        }
    }
    public static string Touch_Owl_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die ausgestopfte Eule mit der Klaue. Da die Eule schon wach war, musterte sie mich nur etwas verwirrt.";
            else
                return "Ich berührte die ausgestopfte Eule mit der Klaue. Da die Eule schon wach war, musterte sie mich nur etwas verwirrt.";
        }
    }
    public static string Touch_KnightsArmour_StableClaw_Wake
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die Ritterrüstung mit der Klaue. Sofort klappte sich das Visier der Rüstung hoch, und dahinter erkannte ich - nichts. \"Was glotzt du so?\" schepperte es aus dem Innern. Danach begann die Ritterrüstung mit einigen extravanten Dehnübungen.";
            else
                return "Ich berührte die Ritterrüstung mit der Klaue. Sofort klappte sich das Visier der Rüstung hoch, und dahinter erkannte ich - nichts. \"Was glotzt du so?\" schepperte es aus dem Innern. Danach begann die Ritterrüstung mit einigen extravanten Dehnübungen.";
        }
    }
    public static string Touch_KnightsArmour_StableClaw_WakeAgain
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich berührte die Ritterrüstung mit der Klaue. \"Nicht so oft bitte\", schepperte es aus dem Innern. \"Sonst kann ich heute Nacht wieder nicht schlafen.\"";
            else
                return "Ich berührte die Ritterrüstung mit der Klaue. \"Nicht so oft bitte\", schepperte es aus dem Innern. \"Sonst kann ich heute Nacht wieder nicht schlafen.\"";
        }
    }


    public static string Tip_MagicPowder_MagicCandle_NoFlame
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sicher würde es cool aussehen, das magische Pulver auf die Kerze rieseln zu lassen. Aber wenn diese brannte, gäbe es doch deutlich mehr Action.";
            else
                return "Sicher würde es cool aussehen, das magische Pulver auf die Kerze rieseln zu lassen. Aber wenn diese brannte, gäbe es doch deutlich mehr Action.";
        }
    }
    public static string Tip_MagicPowder_MagicCandle_NoMagic
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sicher würde die magische Flamme das Pulver entfachen und irgendeinen Effekt erzeugen. Aber wenn nicht irgendwas die Magie kanalisierte, wie ein Pentagramm zum Beispiel, dann würde mir das alles wenig nutzen.";
            else
                return "Sicher würde die magische Flamme das Pulver entfachen und irgendeinen Effekt erzeugen. Aber wenn nicht irgendwas die Magie kanalisierte, wie ein Pentagramm zum Beispiel, dann würde mir das alles wenig nutzen.";
        }
    }
    public static string Tip_SupermagicPowder_MagicCandle_NoMagic
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sicher würde die magische Flamme das Pulver entfachen und irgendeinen Effekt erzeugen. Aber wenn nicht irgendwas die Magie kanalisierte, wie ein Pentagramm zum Beispiel, dann würde mir das alles wenig nutzen. Mir fiel ein, dass sich im Atrium ein Pentagramm befand.";
            else
                return "Sicher würde die magische Flamme das Pulver entfachen und irgendeinen Effekt erzeugen. Aber wenn nicht irgendwas die Magie kanalisierte, wie ein Pentagramm zum Beispiel, dann würde mir das alles wenig nutzen. Mir fiel ein, dass sich im Atrium ein Pentagramm befand.";
        }
    }
    public static string Tip_MagicPowder_MagicCandle_Do
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stellte mich in die Mitte des Pentagramms und ließ das magische Pulver in die Flamme rieseln. Sofort ergoss sich ein riesiger Funkenregen über mich und eine Stimme flüsterte in mein Ohr: \"KABUMM!\"<br><br>Im nächsten Moment schwebte ich mitten durch eine sternklare Nacht. Unter mir endlose Schwärze, nur ein helles Rechteck leuchtete unter mir. Ich stürzte direkt darauf zu. Ich schrie und schrie.<br><br>Plötzlich öffnete sich auf meinem Rücken ein Päckchen, dessen Anwesenheit ich bisher nicht wahrgenommen hatte. Ein magischer Fallschirm entfaltete sich und bremste meinen Sturz. Sacht sank ich auf das helle Rechteck zu und landete schließlich sanft auf meinen Füßen. Im selben Moment verschwand der magische Fallschirm. Ich war angekommen im Versteck des Meisters! Jetzt musste ich nur noch die Klaue einstecken und schauen, dass ich so schnell wie möglich wegkam.<br><br>";
            else
                return "Ich stellte mich in die Mitte des Pentagramms und ließ das magische Pulver in die Flamme rieseln. Sofort ergoss sich ein riesiger Funkenregen über mich und eine Stimme flüsterte in mein Ohr: \"KABUMM!\"<br><br>Im nächsten Moment schwebte ich mitten durch eine sternklare Nacht. Unter mir endlose Schwärze, nur ein helles Rechteck leuchtete unter mir. Ich stürzte direkt darauf zu. Ich schrie und schrie.<br><br>Plötzlich öffnete sich auf meinem Rücken ein Päckchen, dessen Anwesenheit ich bisher nicht wahrgenommen hatte. Ein magischer Fallschirm entfaltete sich und bremste meinen Sturz. Sacht sank ich auf das helle Rechteck zu und landete schließlich sanft auf meinen Füßen. Im selben Moment verschwand der magische Fallschirm. Ich war angekommen im Versteck des Meisters! Jetzt musste ich nur noch die Klaue einstecken und schauen, dass ich so schnell wie möglich wegkam.<br><br>";
        }
    }
    public static string Tip_SupermagicPowder_MagicCandle_Do
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stellte mich in die Mitte des Pentagramms und ließ das magische Pulver in die Flamme rieseln. Sofort ergoss sich ein riesiger Funkenregen über mich und eine Stimme flüsterte in mein Ohr: \"KABUMM!\"<br><br>Im nächsten Moment stand ich in einem anderen Raum. Wo war ich? Alles war dunkel.<br>Und plötzlich öffneten sich nicht weit entfernt von mir zwei glutrot leuchtende Augen.";
            else
                return "Ich stellte mich in die Mitte des Pentagramms und ließ das magische Pulver in die Flamme rieseln. Sofort ergoss sich ein riesiger Funkenregen über mich und eine Stimme flüsterte in mein Ohr: \"KABUMM!\"<br><br>Im nächsten Moment stand ich in einem anderen Raum. Wo war ich? Alles war dunkel.<br>Und plötzlich öffneten sich nicht weit entfernt von mir zwei glutrot leuchtende Augen.";
        }
    }
    public static string UseW_SugarPliers_Claw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich hob die Klaue mit der Zuckerzange an und nahm sie an mich. Da die Klaue groß genug war, blieb sie zwar in der Zange stecken, aber das ganze Gebilde war höchst instabil. Ich musste es fixieren, wenn ich es länger mit mir herumtragen wollte.";
            else
                return "Ich hob die Klaue mit der Zuckerzange an und nahm sie an mich. Da die Klaue groß genug war, blieb sie zwar in der Zange stecken, aber das ganze Gebilde war höchst instabil. Ich musste es fixieren, wenn ich es länger mit mir herumtragen wollte.";
        }
    }
    public static string UseW_Plunger_Slag
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich zerstößelte die Schlacke und erhielt ein feines Pulver. Sehr schön, mein Ticket nach Hause war mir sicher.";
            else
                return "Ich zerstößelte die Schlacke und erhielt ein feines Pulver. Sehr schön, mein Ticket nach Hause war mir sicher.";
        }
    }

    public static string Wrap_Rollpflaster_Pliers_Ok
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich klebte einen langen Klebestreifen um die Zuckerzange mit der Klaue darin. Der Klebestreifen hielt die Zuckerzange so fest zusammen, dass die Klaue sicher befestgt war.<br>Das Rollpflaster war alle, also warf ich die leere Rolle weg.";
            else
                return "Ich klebte einen langen Klebestreifen um die Zuckerzange mit der Klaue darin. Der Klebestreifen hielt die Zuckerzange so fest zusammen, dass die Klaue sicher befestgt war.<br>Das Rollpflaster war alle, also warf ich die leere Rolle weg.";
        }
    }
    public static string Wipe_KnightsArmor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich wischte ein wenig an der Rüstung herum. Sonderlich viel Effekt hatte das nicht, also ließ ich es.";
            else
                return "Ich wischte ein wenig an der Rüstung herum. Sonderlich viel Effekt hatte das nicht, also ließ ich es.";
        }
    }
    public static string Examine_In_Opening
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich schaute in die dunkle Öffnung. Ein rostiger Schlüssel kam zum Vorschein.";
            else
                return "Ich schaute in die dunkle Öffnung. Ein rostiger Schlüssel kam zum Vorschein.";
        }
    }
    public static string Unlock_Labor_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich steckte den Schlüssel in das Schloss der Tür zum Labor. Die Tür ließ sich ohne Probleme aufschließen.";
            else
                return "Ich steckte den Schlüssel in das Schloss der Tür zum Labor. Die Tür ließ sich ohne Probleme aufschließen.";
        }
    }
    public static string Unlock_Labor_Door_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich steckte den Schlüssel in das Schloss der Tür zum Labor. Die Tür ließ sich aber nicht aufschließen, da sie schon aufgeschlossen war.";
            else
                return "Ich steckte den Schlüssel in das Schloss der Tür zum Labor. Die Tür ließ sich aber nicht aufschließen, da sie schon aufgeschlossen war.";
        }
    }
    public static string Take_Claw_Sign
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Gierig griff ich nach der Klaue. Mein, endlich war sie mein!<br>Aus den Augenwinkeln heraus nahm ich das am Podest befindliche Warnschild war und hielt erst mal inne.";
            else
                return "Gierig griff ich nach der Klaue. Mein, endlich war sie mein!<br>Aus den Augenwinkeln heraus nahm ich das am Podest befindliche Warnschild war und hielt erst mal inne.";
        }
    }
    public static string Talk_Owl_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Eule starrte mich aus toten Augen an. Irgendwelche geistreichen Antworten waren wohl von ihr auch nicht zu erwarten.";
            else
                return "Die Eule starrte mich aus toten Augen an. Irgendwelche geistreichen Antworten waren wohl von ihr auch nicht zu erwarten.";
        }
    }
    public static string Talk_Skeleton_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Bibliothekarsskelett schaute mich strafend, aber wortlos an. Plötzlich fielen mir die Bücher meiner Kindheit ein, die ich zu spät zurückgebracht hatte.";
            else
                return "Das Bibliothekarsskelett schaute mich strafend, aber wortlos an. Plötzlich fielen mir die Bücher meiner Kindheit ein, die ich zu spät zurückgebracht hatte.";
        }
    }
    public static string Talk_Magpie_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Elster starrte mich aus toten Augen an. Ein bisschen mehr Mühe könnte sie sich ja schon geben, fand ich.";
            else
                return "Die Elster starrte mich aus toten Augen an. Ein bisschen mehr Mühe könnte sie sich ja schon geben, fand ich.";
        }
    }
    public static string Talk_Parrot_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Papagei starrte mich aus toten Augen an. Ich versuchte, ebenso tot zurück zu starren. Blödes Vieh.";
            else
                return "Der Papagei starrte mich aus toten Augen an. Ich versuchte, ebenso tot zurück zu starren. Blödes Vieh.";
        }
    }
    public static string Talk_Snake_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Schlange zeigte wenig Gesprächsbereitschaft. Ob das daran lag, dass sie tot und ausgestopft war?";
            else
                return "Die Schlange zeigte wenig Gesprächsbereitschaft. Ob das daran lag, dass sie tot und ausgestopft war?";
        }
    }
    public static string Talk_Fish_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Fisch schwieg. Ob das daran lag, dass er tot und ausgestopft war?";
            else
                return "Der Fisch schwieg. Ob das daran lag, dass er tot und ausgestopft war?";
        }
    }
    public static string Talk_Knights_Armor_Dead
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Ritterrüstung sagte keinen Piep. Irgendwie war das auch gut so.";
            else
                return "Die Ritterrüstung sagte keinen Piep. Irgendwie war das auch gut so.";
        }
    }

    public static string Close_L04_Flap
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Klappe schob sich wieder vor die Öffnung.";
            else
                return "Die Klappe schob sich wieder vor die Öffnung.";
        }
    }
    public static string Open_L04_Flap
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hinter der Klappe kam eine dunkle Öffnung zum Vorschein.";
            else
                return "Hinter der Klappe kam eine dunkle Öffnung zum Vorschein.";
        }
    }
    public static string Open_L10_Flap
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Unter der Klappe kam eine dunkle Öffnung zum Vorschein.";
            else
                return "Unter der Klappe kam eine dunkle Öffnung zum Vorschein.";
        }
    }
    public static string Press_Switch_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Schalter ließ sich nicht betätigen. Vielleicht lag es daran, dass die Klappe offen war?";
            else
                return "Der Schalter ließ sich nicht betätigen. Vielleicht lag es daran, dass die Klappe offen war?";
        }
    }
    public static string Press_Switch_Nothing_Happens
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich betätigte den Schalter. Sofort begann die Dunkelheitsmaschine damit, ein einlullendes Summen zu verbreiten. Sonst passiert leider weiter gar nichts.";
            else
                return "Ich betätigte den Schalter. Sofort begann die Dunkelheitsmaschine damit, ein einlullendes Summen zu verbreiten. Sonst passiert leider weiter gar nichts.";
        }
    }
    public static string Press_Switch_Saug
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich betätigte den Schalter. Sofort begann die Dunkelheitsmaschine damit, ein einlullendes Summen zu verbreiten. Gleichzeitig drang helles Licht um die Ritzen der Klappe. Ob das wohl von dem Licht stammte, dass aus dem Stein herausgezogen worden war?";
            else
                return "Ich betätigte den Schalter. Sofort begann die Dunkelheitsmaschine damit, ein einlullendes Summen zu verbreiten. Gleichzeitig drang helles Licht um die Ritzen der Klappe. Ob das wohl von dem Licht stammte, dass aus dem Stein herausgezogen worden war?";
        }
    }
    public static string Examine_Under_Doormat
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Unter der Fußmatte entdeckte ich ein kleines Beutelchen.";
            else
                return "Unter der Fußmatte entdeckte ich ein kleines Beutelchen.";
        }
    }
    public static string Push_L04_Cupboard
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich rückte den Schrank ein Stück von der Wand ab. Dahinter kam eine kleine Klappe zum Vorschein.";
            else
                return "Ich rückte den Schrank ein Stück von der Wand ab. Dahinter kam eine kleine Klappe zum Vorschein.";
        }
    }
    public static string Push_L08_Wooden_Cover
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich schob die Holzabdeckung vom Brunnen weg. Darunter blickte ich in tiefe Schwärze.";
            else
                return "Ich schob die Holzabdeckung vom Brunnen weg. Darunter blickte ich in tiefe Schwärze.";
        }
    }
    public static string Push_Mist
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich versuche, den Nebel mit meinen Händen wegzuschieben. Erschreckenderweise griffen die Hände einfach durch die Schwaden hindurch.";
            else
                return "Ich versuche, den Nebel mit meinen Händen wegzuschieben. Erschreckenderweise griffen die Hände einfach durch die Schwaden hindurch.";
        }
    }
    public static string Climb_Tree_Fail
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Stamm des Baumes war vom Nebel viel zu nass. Meine Hände rutschen ab, zumal es keine tief hängenden Äste gab, an denen man sich hätte gut festhalten können. Überhaupt: Was wollte ich da oben?";
            else
                return "Der Stamm des Baumes war vom Nebel viel zu nass. Meine Hände rutschen ab, zumal es keine tief hängenden Äste gab, an denen man sich hätte gut festhalten können. Überhaupt: Was wollte ich da oben?";
        }
    }
    public static string Open_Library_Door_Locked
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Tür zur Bibliothek war verschlossen.";
            else
                return "Die Tür zur Bibliothek war verschlossen.";
        }
    }
    public static string Open_Sleepingroom_Door_Locked
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Tür war verriegelt und verrammelt.";
            else
                return "Die Tür war verriegelt und verrammelt.";
        }
    }
    public static string Open_Laboratory_Door_Locked
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die schwere Tür, auf der groß und breit \"Labor\" stand, war fest verriegelt.";
            else
                return "Die schwere Tür, auf der groß und breit \"Labor\" stand, war fest verriegelt.";
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
                return "<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>";
            else
                return "<br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/><br/>";
        }
    }
    public static string Adv_Intro1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "<br>*** Das Versteck des Meisters ***<br><br><br>Eine Art Exitgame<br/><br/><br/><br/>Version {0} vom {1}<br/><br/>Ein Spiel von Stefan Hoffmann<br/><br/>";
            else
                return "<br>*** Das Versteck des Meisters ***<br><br><br>Eine Art Exitgame<br/><br/><br/><br/>Version {0} vom {1}<br/><br/>Ein Spiel von Stefan Hoffmann<br/><br/>";
        }
    }
    public static string Adv_Intro2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Seit Stunden stapfte ich durch dieses neblige Gehölz und verlor so langsam die Geduld. Noch immer kochte in mir die Wut! Was bildete sich dieser Mistkerl eigentlich ein?<br>Meister Gunnar hatte uns Studenten gestern verkündet, dass er mit einer erlesenen Schar seiner Anbeter im Gefolge ins Land Polonistan reisen würde, um sich dort in den hohen magischen Giftkünsten zu schulen. Natürlich konnte ich mein vorlautes Maul nicht halten und musste ihn fragen, ob ich auch mitkommen dürfe.<br>Er musterte mich von oben bis unten, dann brach er in Lachen aus.<br>In dem Moment zerbrach etwas in mir. Ich beschloss, meine unnützen Studien bei Meister Gunnar zu beenden. Ich würde es ihm heimzahlen und ihm das Wertvollste nehmen, was er besaß. Er würde den Tag noch verfluchten, an dem er mich so vor den Kopf geschlagen hatte.";
            else
                return "Seit Stunden stapfte ich durch dieses neblige Gehölz und verlor so langsam die Geduld. Noch immer kochte in mir die Wut! Was bildete sich dieser Mistkerl eigentlich ein?<br>Meister Gunnar hatte uns Studenten gestern verkündet, dass er mit einer erlesenen Schar seiner Anbeter im Gefolge ins Land Polonistan reisen würde, um sich dort in den hohen magischen Giftkünsten zu schulen. Natürlich konnte ich mein vorlautes Maul nicht halten und musste ihn fragen, ob ich auch mitkommen dürfe.<br>Er musterte mich von oben bis unten, dann brach er in Lachen aus.<br>In dem Moment zerbrach etwas in mir. Ich beschloss, meine unnützen Studien bei Meister Gunnar zu beenden. Ich würde es ihm heimzahlen und ihm das Wertvollste nehmen, was er besaß. Er würde den Tag noch verfluchten, an dem er mich so vor den Kopf geschlagen hatte.";
        }
    }
    public static string Adv_Intro3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es war ja richtig: Ich war gewiss nicht sein gelehrigster Schüler. Und wenn sich bei mir irgendwo ein Talent gezeigt hätte, dann im Abschreiben, Ausleihen und nicht zurückbringen, oder auch schlicht im Stehlen. Ich hatte durchaus ein großes Interesse an Reichtümern aller Art, also auch jenen, die Meister Gunnar, wie man hörte, in seiner gut verborgenen Hütte im Wald versteckte. Darunter sogar die berühmte Klaue, das wohl wertvollste magische Juwel der Welt. Und jetzt, wo der Meister auf und davon war, konnte er mich nicht darana hindern, diesen Schatz an mich zu bringen. Ich hatte nicht nur meine Rache, sondern wurde auch noch steinreich!";
            else
                return "Es war ja richtig: Ich war gewiss nicht sein gelehrigster Schüler. Und wenn sich bei mir irgendwo ein Talent gezeigt hätte, dann im Abschreiben, Ausleihen und nicht zurückbringen, oder auch schlicht im Stehlen. Ich hatte durchaus ein großes Interesse an Reichtümern aller Art, also auch jenen, die Meister Gunnar, wie man hörte, in seiner gut verborgenen Hütte im Wald versteckte. Darunter sogar die berühmte Klaue, das wohl wertvollste magische Juwel der Welt. Und jetzt, wo der Meister auf und davon war, konnte er mich nicht darana hindern, diesen Schatz an mich zu bringen. Ich hatte nicht nur meine Rache, sondern wurde auch noch steinreich!";
        }
    }
    public static string Adv_Intro4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mein Studium der Magie war ohnehin verloren. Immerhin, mit der Klaue im Gepäck würde mich die Diebesgilde mit Handkuss nehmen. Jetzt musste ich nur noch den Weg zur Hütte finden in diesem verdammten Nebel!<br/><br/>";
            else
                return "Mein Studium der Magie war ohnehin verloren. Immerhin, mit der Klaue im Gepäck würde mich die Diebesgilde mit Handkuss nehmen. Jetzt musste ich nur noch den Weg zur Hütte finden in diesem verdammten Nebel!<br/><br/>";
        }
    }

    public static string Order_ExamineThrough_IX_03_Spiegel_280
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Durch [Il1,Nom] konnte ich nicht schauen.";
            else
                return "I could not look through [Il1,Nom].";
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
                return "blau";
        }
    }
    public static string Adj_gekachelt
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "gekachelt";
            else
                return "gekachelt";
        }
    }
    public static string Adj_gruen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "grün";
            else
                return "grün";
        }
    }
    public static string Adj_stattlich
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "stattlich";
            else
                return "stattlich";
        }
    }
    public static string Adj_ausgestopft
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "ausgestopft";
            else
                return "ausgestopft";
        }
    }
    public static string Adj_magisch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "magisch";
            else
                return "magisch";
        }
    }
    public static string Adj_instabil
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "instabil";
            else
                return "instabil";
        }
    }
    public static string Adj_beschrieben
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "beschrieben";
            else
                return "beschrieben";
        }
    }
    public static string Adj_peinlich
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "peinlich";
            else
                return "peinlich";
        }
    }
    public static string Adj_vertrocknet
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "vertrocknet";
            else
                return "vertrocknet";
        }
    }
    public static string Adj_lichtlos
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "lichtlos";
            else
                return "lichtlos";
        }
    }
    public static string Adj_gekuehlt
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "gekühlt";
            else
                return "gekühlt";
        }
    }
    public static string Adj_schimmernd
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "schimmernd";
            else
                return "schimmernd";
        }
    }
    public static string Adj_neblig
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "neblig";
            else
                return "neblig";
        }
    }
    public static string Adj_mueffelnd
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "müffelnd";
            else
                return "müffelnd";
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
                return "verrückt";
        }
    }
    public static string Adj_sinister
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "sinistr";
            else
                return "sinistr";
        }
    }
    public static string Adj_besonders
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "besonders";
            else
                return "besonders";
        }
    }
    public static string Noun_Flamme
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Flamme";
            else
                return "Flamme";
        }
    }
    public static string Noun_Rune
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Rune";
            else
                return "Rune";
        }
    }
    public static string Noun_Warnschild
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Warnschild";
            else
                return "Warnschild";
        }
    }
    public static string Noun_Wasch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wasch";
            else
                return "Wasch";
        }
    }
    public static string Noun_Gefrier
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Gefrier";
            else
                return "Gefrier";
        }
    }
    public static string Noun_Froster
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Froster";
            else
                return "Froster";
        }
    }
    public static string Noun_Ente
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ente";
            else
                return "Ente";
        }
    }
    public static string Noun_Entchen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Entchen";
            else
                return "Entchen";
        }
    }
    public static string Noun_Gummiente
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Gummiente";
            else
                return "Gummiente";
        }
    }
    public static string Noun_Abdeckung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Abdeckung";
            else
                return "Abdeckung";
        }
    }
    public static string Noun_Deckel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Deckel";
            else
                return "Deckel";
        }
    }
    public static string Noun_Verbandskasten
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Verbandskasten";
            else
                return "Verbandskasten";
        }
    }
    public static string Noun_Plastik
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Plastik";
            else
                return "Plastik";
        }
    }
    public static string Noun_Pilz
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Pilz";
            else
                return "Pilz";
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
                return "Sporen";
        }
    }
    public static string Noun_Schwamm
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Schwamm";
            else
                return "Schwamm";
        }
    }
    public static string Noun_Rolle
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Rolle";
            else
                return "Rolle";
        }
    }
    public static string Noun_Buchstaben
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Buchstaben";
            else
                return "Buchstaben";
        }
    }
    public static string Noun_Beutel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Beutel";
            else
                return "Beutel";
        }
    }
    public static string Noun_Kerze
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Kerze";
            else
                return "Kerze";
        }
    }
    public static string Noun_Halter
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Halter";
            else
                return "Halter";
        }
    }
    public static string Noun_Matte
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Matte";
            else
                return "Matte";
        }
    }

    public static string Noun_Ritterruestung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ritterrüstung";
            else
                return "Ritterrüstung";
        }
    }
    public static string Noun_Ritter
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ritter";
            else
                return "Ritter";
        }
    }
    public static string Noun_Ruestung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Rüstung";
            else
                return "Rüstung";
        }
    }
    public static string Noun_Eule
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eule";
            else
                return "Eule";
        }
    }
    public static string Noun_Skelett
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Skelett";
            else
                return "Skelett";
        }
    }
    public static string Noun_Fish
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Fisch";
            else
                return "Fisch";
        }
    }
    public static string Noun_Schlange
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Schlange";
            else
                return "Schlange";
        }
    }

    public static string Noun_Elster
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Elster";
            else
                return "Elster";
        }
    }
    public static string Noun_Beutelchen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Beutelchen";
            else
                return "Beutelchen";
        }
    }
    public static string Noun_Pulver
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Pulver";
            else
                return "Pulver";
        }
    }
    public static string Noun_Kerzenhalter
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Kerzenhalter";
            else
                return "Kerzenhalter";
        }
    }
    public static string Noun_Klaue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Klaue";
            else
                return "Klaue";
        }
    }
    public static string Noun_Zuckerzange
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Zuckerzange";
            else
                return "Zuckerzange";
        }
    }
    public static string Noun_Rollpflaster
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Rollpflaster";
            else
                return "Rollpflaster";
        }
    }
    public static string Noun_Klauenzange
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Klauenzange";
            else
                return "Klauenzange";
        }
    }
    public static string Noun_Lupe
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Lupe";
            else
                return "Lupe";
        }
    }
    public static string Noun_Quietscheentchen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Quietscheentchen";
            else
                return "Quietscheentchen";
        }
    }
    public static string Noun_Kaese
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Käse";
            else
                return "Käse";
        }
    }
    public static string Noun_Mondstein
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mondstein";
            else
                return "Mondstein";
        }
    }
    public static string Noun_Mond
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mond";
            else
                return "Mond";
        }
    }
    public static string Noun_Plastikbeutel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Plastikbeutel";
            else
                return "Plastikbeutel";
        }
    }
    public static string Noun_Wunderwarzenschwamm
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wunderwarzenschwamm";
            else
                return "Wunderwarzenschwamm";
        }
    }
    public static string Noun_Schlacke
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Schlacke";
            else
                return "Schlacke";
        }
    }
    public static string Noun_Muenze
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Münze";
            else
                return "Münze";
        }
    }
    public static string Noun_Nebel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nebel";
            else
                return "Nebel";
        }
    }
    public static string Noun_Fussmatte
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Fußmatte";
            else
                return "Fußmatte";
        }
    }
    public static string Noun_Pentagramm
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Pentagramm";
            else
                return "Pentagramm";
        }
    }
    public static string Noun_Oeffnung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Öffnung";
            else
                return "Öffnung";
        }
    }
    public static string Noun_Siegel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Siegel";
            else
                return "Siegel";
        }
    }
    public static string Noun_Waescheleine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wäscheleine";
            else
                return "Wäscheleine";
        }
    }
    public static string Noun_Unterhose
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Unterhose";
            else
                return "Unterhose";
        }
    }
    public static string Noun_Holzabdeckung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Holzabdeckung";
            else
                return "Holzabdeckung";
        }
    }
    public static string Noun_Waschmaschine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Waschmaschine";
            else
                return "Waschmaschine";
        }
    }
    public static string Noun_Waescheaufhaengmaschine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wäscheaufhängmaschine";
            else
                return "Wäscheaufhängmaschine";
        }
    }
    public static string Noun_Waeschekorb
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wäschekorb";
            else
                return "Wäschekorb";
        }
    }
    public static string Noun_Karton
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Karton";
            else
                return "Karton";
        }
    }
    public static string Noun_Labortisch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Labortisch";
            else
                return "Labortisch";
        }
    }
    public static string Noun_Kaefige
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Käfige";
            else
                return "Käfige";
        }
    }
    public static string Noun_Erstehilfekasten
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Erste-Hilfe-Kasten";
            else
                return "Erste-Hilfe-Kasten";
        }
    }
    public static string Noun_Halterung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Halterung";
            else
                return "Halterung";
        }
    }
    public static string Noun_Metallschale
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Metallschale";
            else
                return "Metallschale";
        }
    }
    public static string Noun_Dunkelheitsmaschine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Dunkelheitsmaschine";
            else
                return "Dunkelheitsmaschine";
        }
    }
    public static string Noun_Vogelstaender
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Vogelständer";
            else
                return "Vogelständer";
        }
    }
    public static string Noun_Matratze
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Matratze";
            else
                return "Matratze";
        }
    }
    public static string Noun_Kuehlschrank
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Kühlschrank";
            else
                return "Kühlschrank";
        }
    }
    public static string Noun_Gefrierfach
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Gefrierfach";
            else
                return "Gefrierfach";
        }
    }
    public static string Noun_Kachel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Kachel";
            else
                return "Kachel";
        }
    }
    public static string Noun_Badewanne
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Badewanne";
            else
                return "Badewanne";
        }
    }
    public static string Noun_Toilette
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Toilette";
            else
                return "Toilette";
        }
    }
    public static string Noun_Spuelung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Spülung";
            else
                return "Spülung";
        }
    }

    public static string Adv_L01_Dark_Forest
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein dunkler Wald";
            else
                return "Ein dunkler Wald";
        }
    }
    public static string Adv_L01_Dark_Forest_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich streifte durch einen [I:I01_Forest]nebligen Wald[/I]. Längst war die Nacht herein gebrochen, und ich sah kaum die Hand vor Augen. Das einzige Licht, das es gab, kam von [I:I01_Mist]den Nebelschwaden[/I], die vom hellen Vollmondlicht erleuchtet wurden. Die Silhouetten [I:I01_Trees]der knorrigen Bäume[/I] waberten im sachten Wind auf mich zu und griffen nach mir. Die mit  [I:I01_Forest_Grass]dichtem Waldgras[/I] bewachsenen Wege führten [L:L02_In_Front_Of_A_Hut]in alle Richtungen[/L].";
            else
                return "Ich streifte durch einen [I:I01_Forest]nebligen Wald[/I]. Längst war die Nacht herein gebrochen, und ich sah kaum die Hand vor Augen. Das einzige Licht, das es gab, kam von [I:I01_Mist]den Nebelschwaden[/I], die vom hellen Vollmondlicht erleuchtet wurden. Die Silhouetten [I:I01_Trees]der knorrigen Bäume[/I] waberten im sachten Wind auf mich zu und griffen nach mir. Die mit  [I:I01_Forest_Grass]dichtem Waldgras[/I] bewachsenen Wege führten [L:L02_In_Front_Of_A_Hut]in alle Richtungen[/L].";
        }
    }

    public static string Adv_L02_In_Front_Of_A_Hut
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Vor einer Hütte";
            else
                return "Vor einer Hütte";
        }
    }
    public static string Adv_L02_In_Front_Of_A_Hut_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand vor [I:I02_Shed]einer verfallenen Hütte[/] im [I:I02_Forest]Wald[/I]. Eigentlich sah ich wenig mehr als die Silhouette [I:I02_Shed]eines niedrigen Gebäudes[/I], das sich [I:I02_Mist]aus dem dichten Nebel[/I] hervorhob.<br>Das sollte das edle Domizil von Meister Gunnar sein? Schwer zu glauben, dass er sein fettes Uni-Salär nicht für etwas besseres hätte aufwenden können, eine schicke Stadtvilla zum Beispiel. Also gut, er wohnte wohl freiwillig in dieser Bruchbude. Ganz sicher hatte diese Immobilie noch ein Geheimnis, das sie preiszugeben hatte.<br>[I:I02_Shed]Die Hütte[/I] war aus grobem Stein gemauert und hatte [I:I02_Door]eine solide Eingangstür[/I]. Dass davor ordentlich drapiert [I:I02_Doormat]eine Fußmatte[/I] lag, verbesserte den Gesamteindruck nicht wesentlich. [L:L03_In_The_Parlor]Der Eingang zur Hütte lag nördlich[/L]. [L:L01_Dark_Forest]Alle anderen Wege führten zurück in den Wald[/L].";
            else
                return "Ich stand vor [I:I02_Shed]einer verfallenen Hütte[/] im [I:I02_Forest]Wald[/I]. Eigentlich sah ich wenig mehr als die Silhouette [I:I02_Shed]eines niedrigen Gebäudes[/I], das sich [I:I02_Mist]aus dem dichten Nebel[/I] hervorhob.<br>Das sollte das edle Domizil von Meister Gunnar sein? Schwer zu glauben, dass er sein fettes Uni-Salär nicht für etwas besseres hätte aufwenden können, eine schicke Stadtvilla zum Beispiel. Also gut, er wohnte wohl freiwillig in dieser Bruchbude. Ganz sicher hatte diese Immobilie noch ein Geheimnis, das sie preiszugeben hatte.<br>[I:I02_Shed]Die Hütte[/I] war aus grobem Stein gemauert und hatte [I:I02_Door]eine solide Eingangstür[/I]. Dass davor ordentlich drapiert [I:I02_Doormat]eine Fußmatte[/I] lag, verbesserte den Gesamteindruck nicht wesentlich. [L:L03_In_The_Parlor]Der Eingang zur Hütte lag nördlich[/L]. [L:L01_Dark_Forest]Alle anderen Wege führten zurück in den Wald[/L].";
        }
    }

    public static string Adv_L03_In_The_Parlor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Stube der Hütte des Meisters";
            else
                return "In der Stube der Hütte des Meisters";
        }
    }
    public static string Adv_L03_In_The_Parlor_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das hier konnte ja wohl nicht die Stube sein, in der der Meister lebte! Ich stand nämlich in einem komplett leeren, kalten Raum. Immerhin kündete [I:I03_Pentagram]in rot geschmiertes Pentagramm[/I] auf dem Boden davon, dass hier irgendwer irgendwas mit Zauberkräften am Hut hatte. Auch [I:I03_Runes]die Runen an der Wand hinterließen eine einigermaßen klare Botschaft.<br>Also gut, das war definitiv nicht das Wohngemach des Meisters. Aber vielleicht war dieser Ort ja der Eingang zu seinem eigentlichen Domizil. Das läge zumindest nahe.<br>In [L:L04_Shabby_Little_Chamber]östlicher Richtung[L] befand sich [I:I03_Door]eine schäbige kleine Tür[/I]. [L:L02_In_Front_Of_A_Hut]Nach Süden[/L] gings [I:I03_Door_Outside]durch eine schwere Tür[/I] wieder nach draußen.";
            else
                return "Das hier konnte ja wohl nicht die Stube sein, in der der Meister lebte! Ich stand nämlich in einem komplett leeren, kalten Raum. Immerhin kündete [I:I03_Pentagram]in rot geschmiertes Pentagramm[/I] auf dem Boden davon, dass hier irgendwer irgendwas mit Zauberkräften am Hut hatte. Auch [I:I03_Runes]die Runen an der Wand hinterließen eine einigermaßen klare Botschaft.<br>Also gut, das war definitiv nicht das Wohngemach des Meisters. Aber vielleicht war dieser Ort ja der Eingang zu seinem eigentlichen Domizil. Das läge zumindest nahe.<br>In [L:L04_Shabby_Little_Chamber]östlicher Richtung[L] befand sich [I:I03_Door]eine schäbige kleine Tür[/I]. [L:L02_In_Front_Of_A_Hut]Nach Süden[/L] gings [I:I03_Door_Outside]durch eine schwere Tür[/I] wieder nach draußen.";
        }
    }


    public static string Adv_L04_Shabby_Little_Chamber
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In einer schäbigen kleinen Kammer";
            else
                return "In einer schäbigen kleinen Kammer";
        }
    }
    public static string Adv_L04_Shabby_Little_Chamber_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand in einer schäbigen kleinen Kammer, in der sich neben [I:I04_Cupboard]einem großen Schrank[/I] und [I:I04_Shelf]einem Regal[/I] eigentlich nur vollkommen desolates Gerümpel befand. Wenigstens lag auch keine halb verweste Matratze in der Ecke. Ich hatte also schon mal nicht das Schlafzimmer des Meisters gefunden. Zum Glück.<br>Durch eine [L:L03_In_The_Parlor]westlich[/L] gelegene [I:I04_Door]Tür[/I] gelangte man [L:L03_In_The_Parlor]zurück in die Stube[/L].";
            else
                return "Ich stand in einer schäbigen kleinen Kammer, in der sich neben [I:I04_Cupboard]einem großen Schrank[/I] und [I:I04_Shelf]einem Regal[/I] eigentlich nur vollkommen desolates Gerümpel befand. Wenigstens lag auch keine halb verweste Matratze in der Ecke. Ich hatte also schon mal nicht das Schlafzimmer des Meisters gefunden. Zum Glück.<br>Durch eine [L:L03_In_The_Parlor]westlich[/L] gelegene [I:I04_Door]Tür[/I] gelangte man [L:L03_In_The_Parlor]zurück in die Stube[/L].";
        }
    }

    public static string Adv_L05_Atrium
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Im Atrium des Meisterverstecks";
            else
                return "Im Atrium des Meisterverstecks";
        }
    }
    public static string Adv_L05_Atrium_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand im Atrium des geheimen Domizils von Meister Gunnar. Das sah schon eher nach einer standesgemäßen Butze für einen angeblichen Meistermagier aus. Der große Raum war von fast quadratischer Form. Durch das offene Dach konnte ich hinausblicken in eine endlose, sternenklare Nacht mit [I:I05_Moon]einem riesigen Vollmond[/I]. Darüber hinaus gab es keinerlei Hinweis darauf, in welcher seltsamen Dimension ich mich hier befand. Immerhin: Hier gab es keinen Nebel.<br>[I:I05_Library_Door]Eine breite, verzierte Tür[/I] in der [L:L09_Library]westlichen Wand[/L] mit der Aufschrift \"Bibliothek\" weckte meine Aufmerksamkeit. Daneben befand sich [I:I05_Sill]ein schmales Sims[/I].<br>Genau im Zentrum des Atriums stand [I:I05_Pedestal]ein hohes, mit Gold verziertes Podest[/I]. In einer Ecke war [I:I05_Pentagram]ein großes, rotes Pentagramm[/I] auf den Boden gemalt. [I:I05_Door]Eine weitere Tür[/I] führte [L:L06_Long_Floor]nach Süden[/L].";
            else
                return "Ich stand im Atrium des geheimen Domizils von Meister Gunnar. Das sah schon eher nach einer standesgemäßen Butze für einen angeblichen Meistermagier aus. Der große Raum war von fast quadratischer Form. Durch das offene Dach konnte ich hinausblicken in eine endlose, sternenklare Nacht mit [I:I05_Moon]einem riesigen Vollmond[/I]. Darüber hinaus gab es keinerlei Hinweis darauf, in welcher seltsamen Dimension ich mich hier befand. Immerhin: Hier gab es keinen Nebel.<br>[I:I05_Library_Door]Eine breite, verzierte Tür[/I] in der [L:L09_Library]westlichen Wand[/L] mit der Aufschrift \"Bibliothek\" weckte meine Aufmerksamkeit. Daneben befand sich [I:I05_Sill]ein schmales Sims[/I].<br>Genau im Zentrum des Atriums stand [I:I05_Pedestal]ein hohes, mit Gold verziertes Podest[/I]. In einer Ecke war [I:I05_Pentagram]ein großes, rotes Pentagramm[/I] auf den Boden gemalt. [I:I05_Door]Eine weitere Tür[/I] führte [L:L06_Long_Floor]nach Süden[/L].";
        }
    }

    public static string Adv_L06_Long_Floor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf einem langen Flur";
            else
                return "Auf einem langen Flur";
        }
    }

    // CA!.I06_Door = Items!.Add(Item.ItemLocaLoca(new List<Noun> { CA!.Noun_Tuer! }, new List<Adj> { CA!.Adj_wuchtig! }, Co.SEX_FEMALE, CB!.LocType_Loc, CA!.L06_Long_Floor, loca.Adv_I06_Door, "Adv_I06_Door", Co.SZ_small, true, false, Nouns, Adjs));
    public static string Adv_L06_Long_Floor_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand auf einem langen Flur, der offensichtlich mehrere wichtige Räume des Meisterverstecks miteinander verband. [L:L05_Atrium]Nördlich[/L] führte [I:I06_Door_Wide]eine breite Tür[/I] zurück ins Atrium. [L:L12_Sleeping_Room]Direkt gegenüber an der Südwand[/L] befand sich [I:I06_Door]eine schwere Tür[/I] mit [I:I06_Sign]Schild[/I] \"Privat\" darauf. [L:L13_Kitchen]In der östlichen Wand[/L] befand sich [I:I06_Door_White]eine weiße Tür[/I], [L:L14_Bathroom]in der westlichen Wand[/L] [I:I06_Door_Red]eine rote Tür[/I]. Eine gewendelte Treppe führte [L:L07_Lower_Floor]nach unten[/L].";
            else
                return "Ich stand auf einem langen Flur, der offensichtlich mehrere wichtige Räume des Meisterverstecks miteinander verband. [L:L05_Atrium]Nördlich[/L] führte [I:I06_Door_Wide]eine breite Tür[/I] zurück ins Atrium. [L:L12_Sleeping_Room]Direkt gegenüber an der Südwand[/L] befand sich [I:I06_Door]eine schwere Tür[/I] mit [I:I06_Sign]Schild[/I] \"Privat\" darauf. [L:L13_Kitchen]In der östlichen Wand[/L] befand sich [I:I06_Door_White]eine weiße Tür[/I], [L:L14_Bathroom]in der westlichen Wand[/L] [I:I06_Door_Red]eine rote Tür[/I]. Eine gewendelte Treppe führte [L:L07_Lower_Floor]nach unten[/L].";
        }
    }
    public static string Adv_L07_Lower_Floor
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf dem Flur des Untergeschosses";
            else
                return "Auf dem Flur des Untergeschosses";
        }
    }
    public static string Adv_L07_Lower_Floor_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es war erstaunlich, dass dieser Flur tatsächlich aussah wie ein Kellerflur. Gab es doch nicht das geringste Anzeichen dafür, dass sich dieses Geschoss in einem Keller befand. Im trüben Licht einer Funzel erkannte ich weiß gestrichene Wände, graue Bodenkacheln und insgesamt drei Türen. Dabei lag [L:L08_Laundry_Room]westlich[/L] eine [I:I07_Door_Green]grüne Tür[/I], [L:L11_Storage_Room]südlich[L/L] [I:I07_Door_Blue]eine blaue Tür[/I], sowie [L:L10_Laboratory]im Osten[/L] [I:I07_Door]eine massive schwere Tür[/I]. Eine gewendelte Treppe führte [L:L06_Long_Floor]nach oben[/L].";
            else
                return "Es war erstaunlich, dass dieser Flur tatsächlich aussah wie ein Kellerflur. Gab es doch nicht das geringste Anzeichen dafür, dass sich dieses Geschoss in einem Keller befand. Im trüben Licht einer Funzel erkannte ich weiß gestrichene Wände, graue Bodenkacheln und insgesamt drei Türen. Dabei lag [L:L08_Laundry_Room]westlich[/L] eine [I:I07_Door_Green]grüne Tür[/I], [L:L11_Storage_Room]südlich[L/L] [I:I07_Door_Blue]eine blaue Tür[/I], sowie [L:L10_Laboratory]im Osten[/L] [I:I07_Door]eine massive schwere Tür[/I]. Eine gewendelte Treppe führte [L:L06_Long_Floor]nach oben[/L].";
        }
    }
    public static string Adv_L08_Laundry_Room
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Waschküche";
            else
                return "In der Waschküche";
        }
    }
    public static string Adv_L08_Laundry_Room_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich befand mich in der Waschküche des Meisters. Sofort ins Auge stach mir die brandneue [I:I08_Washing_Machine]magische Waschmaschine[/I] \"Magic 2000\", vor der außerdem [I:I08_Laundry_Basket]ein großer Wäschekorb[/I] stand. In einer Ecke befand sich [I:I08_Well]ein gemauerter Brunnen[/I]. Unter der Decke hingen [I:I08_Clothes_Line]lauter Wäscheleinen[/I]. Der einzige Ausgang führte durch [I:I08_Door_Green]eine grüne Tür[/I] in der [L:L07_Lower_Floor]östlichen Wand[/L].";
            else
                return "Ich befand mich in der Waschküche des Meisters. Sofort ins Auge stach mir die brandneue magische Waschmaschine \"Magic 2000\", vor der außerdem ein großer Wäschekorb stand. In einer Ecke befand sich ein gemauerter Brunnen. Unter der Decke hingen lauter Wäscheleinenschnüre. Der einzige Ausgang führte durch eine Tür in der östlichen Wand.";
        }
    }
    public static string Adv_L09_Library
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Bibliothek";
            else
                return "In der Bibliothek";
        }
    }
    public static string Adv_L09_Library_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich stand in einer verwunschenen Kammer, in der sich Regal an Regal reihte, die über und über mit zahllosen unheimlich aussehenden Büchern vollgestellt werden. Dabei sah ein Band gefährlicher aus als der andere. In einer Ecke befand sich ein Bibliothekarstresen, hinter dem ein Skelett saß. In einer Ecke stand ein Karton. Der einzige Weg nach draußen war durch eine verzierte Tür in der Ostwand.";
            else
                return "Ich stand in einer verwunschenen Kammer, in der sich Regal an Regal reihte, die über und über mit zahllosen unheimlich aussehenden Büchern vollgestellt werden. Dabei sah ein Band gefährlicher aus als der andere. In einer Ecke befand sich ein Bibliothekarstresen, hinter dem ein Skelett saß. In einer Ecke stand ein Karton. Der einzige Weg nach draußen war durch eine verzierte Tür in der Ostwand.";
        }
    }

    public static string Adv_L10_Laboratory
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Im Labor des Meisters";
            else
                return "Im Labor des Meisters";
        }
    }
    public static string Adv_L10_Laboratory_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Dies also war das großartige Privatlabor des Meisters. Zu Zeiten, in denen ich mein Studium noch ernst genommen hätte, wäre ich vor Ehrfurcht erstarrt. Vor mir lag der große Labortisch mit allerlei Hilfsmitteln darauf. Im Tisch befand sich eine Schublade. Neben dem Tisch erkannte ich eine der berühmten Dunkelheitsmaschinen, die angeblich Meister Gunnar selbst erfunden hatte. An der Wand hing vorbildlicherweise ein großer Erste-Hilfe-Kasten. In der westlichen Wand führte eine Tür zurück zum Flur.";
            else
                return "Dies also war das großartige Privatlabor des Meisters. Zu Zeiten, in denen ich mein Studium noch ernst genommen hätte, wäre ich vor Ehrfurcht erstarrt. Vor mir lag der große Labortisch mit allerlei Hilfsmitteln darauf. Im Tisch befand sich eine Schublade. Neben dem Tisch erkannte ich eine der berühmten Dunkelheitsmaschinen, die angeblich Meister Gunnar selbst erfunden hatte. An der Wand hing vorbildlicherweise ein großer Erste-Hilfe-Kasten. In der westlichen Wand führte eine Tür zurück zum Flur.";
        }
    }
    public static string Adv_L11_Storage_Room
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In einem Lagerraum";
            else
                return "In einem Lagerraum";
        }
    }
    public static string Adv_L11_Storage_Room_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich befand mich in einem niedrigen, aber sehr großen Lagerraum. Hier befand sich in endlosen Regalen der Krempel von Meister Gunnar. Besondere Aufmerksamkeit weckten dabei bei mir das linke und das rechte Regal direkt vor mir, sowie ein Vogelständer. Eine Tür in der Nordwand führte nach draußen.";
            else
                return "Ich befand mich in einem niedrigen, aber sehr großen Lagerraum. Hier befand sich in endlosen Regalen der Krempel von Meister Gunnar. Besondere Aufmerksamkeit weckten dabei bei mir das linke und das rechte Regal direkt vor mir, sowie ein Vogelständer. Eine Tür in der Nordwand führte nach draußen.";
        }
    }
    public static string Adv_L12_Sleeping_Room
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Im Schlafgemach des Meisters";
            else
                return "Im Schlafgemach des Meisters";
        }
    }
    public static string Adv_L12_Sleeping_Room_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das also war das geheimnisvolle Schlafgemach des Meisters. Nicht gerade eine Liebeshöhle, um willige Studentinnen abzuschleppen. Eher ein Mancave für Fortgeschrittene. Ein riesiges Bett dominierte den Raum, auf dem eine hohe, luftige Matratze lag. In einer Raumecke stand ein Schrank. Durch eine kaputte Tür in der Nordwand gelangte man zurück zum Flur.";
            else
                return "Das also war das geheimnisvolle Schlafgemach des Meisters. Nicht gerade eine Liebeshöhle, um willige Studentinnen abzuschleppen. Eher ein Mancave für Fortgeschrittene. Ein riesiges Bett dominierte den Raum, auf dem eine hohe, luftige Matratze lag. In einer Raumecke stand ein Schrank. Durch eine kaputte Tür in der Nordwand gelangte man zurück zum Flur.";
        }
    }

    public static string Adv_L13_Kitchen
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In einer Küche";
            else
                return "In einer Küche";
        }
    }
    public static string Adv_L13_Kitchen_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich befand mich in einer überwiegend rustikal eingerichteten Küche. Neben einem rustikalen Küchenschrank gab es eine Anrichte mit einer breiten Schublader darin. Neben dem Küchenschrank befand sich ein großer magischer Kühlschrank mit einem ebensolchen Gefrierfach. Der einzige Ausgang führte westlich zurück auf den Flur.";
            else
                return "Ich befand mich in einer überwiegend rustikal eingerichteten Küche. Neben einem rustikalen Küchenschrank gab es eine Anrichte mit einer breiten Schublader darin. Neben dem Küchenschrank befand sich ein großer magischer Kühlschrank mit einem ebensolchen Gefrierfach. Der einzige Ausgang führte westlich zurück auf den Flur.";
        }
    }
    public static string Adv_L14_Bathroom
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Im Badezimmer";
            else
                return "Im Badezimmer";
        }
    }
    public static string Adv_L14_Bathroom_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Badezimmer des Meisters fiel feudaler aus als gedacht. Das fing an mit den auffällig gemaserten grauen Kacheln an der Wand. Die große Badewanne enthielt eine Whirlpoolfunction. Über dem Waschbecken hing ein großer, fein gearbeiteter Spiegel. Nur die Toilette nebst Spülung war No-Name-Ware aus dem Baumarkt. In der östlichen Wand befand sich eine Tür zurück zum Flur.";
            else
                return "Das Badezimmer des Meisters fiel feudaler aus als gedacht. Das fing an mit den auffällig gemaserten grauen Kacheln an der Wand. Die große Badewanne enthielt eine Whirlpoolfunction. Über dem Waschbecken hing ein großer, fein gearbeiteter Spiegel. Nur die Toilette nebst Spülung war No-Name-Ware aus dem Baumarkt. In der östlichen Wand befand sich eine Tür zurück zum Flur.";
        }
    }
    public static string Adv_L15_Nowhere
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Irgendwo im Nirgendwo";
            else
                return "Irgendwo im Nirgendwo";
        }
    }
    public static string Adv_L15_Nowhere_Lang
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich befand mich im Nirgendwo. Hier gab es nichts, keine Ausgänge, keine Gegenstände, nicht einmal ausgestopfte Tiere. Nein, hier gab es nur nackte Verzweiflung und die nicht mehr zu leugnende Erkenntnis:<br>GAME OVER!";
            else
                return "Ich befand mich im Nirgendwo. Hier gab es nichts, keine Ausgänge, keine Gegenstände, nicht einmal ausgestopfte Tiere. Nein, hier gab es nur nackte Verzweiflung und die nicht mehr zu leugnende Erkenntnis:<br>GAME OVER!";
        }
    }

    public static string Adv_I00_Pouch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein kleines ledernes Beutelchen.";
            else
                return "Ein kleines ledernes Beutelchen.";
        }
    }
    public static string Adv_I00_Magic_Powder
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein fein gemahlenes Pulver, das sich leicht magisch anfühlte.";
            else
                return "Ein fein gemahlenes Pulver, das sich leicht magisch anfühlte.";
        }
    }
    public static string Adv_I00_Supermagic_Powder
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein fein gemahlenes Pulver, das sich leicht magisch anfühlte.";
            else
                return "Ein fein gemahlenes Pulver, das sich leicht magisch anfühlte.";
        }
    }
    public static string Adv_I00_Magic_Candle
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein sehr moderner Kerzenhalter, der mittels eines magischen Drehrads entzündet werden konnte.<br>Die magische, immerwährende Kerze war erloschen.";
            else
                return "Ein sehr moderner Kerzenhalter, der mittels eines magischen Drehrads entzündet werden konnte.<br>Die magische, immerwährende Kerze war erloschen.";
        }
    }
    public static string Adv_I00_Magic_Candle_Lighted
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein sehr moderner Kerzenhalter, der mittels eines magischen Drehrads entzündet werden konnte.<br>Die magische, immerwährende Kerze brannte lichterloh.";
            else
                return "Ein sehr moderner Kerzenhalter, der mittels eines magischen Drehrads entzündet werden konnte.<br>Die magische, immerwährende Kerze brannte lichterloh.";
        }
    }
    public static string Enlighten_Magic_Candle_Yes
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich drehte das magische Rad am Kerzenhalter. Sofort entfachte sich an der Kerzenspitze eine ordentliche Flamme.";
            else
                return "Ich drehte das magische Rad am Kerzenhalter. Sofort entfachte sich an der Kerzenspitze eine ordentliche Flamme.";
        }
    }
    public static string Enlighten_Magic_Candle_No
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich drehte das magische Rad am Kerzenhalter. Nichts weiter passierte, da die Kerze schon brannte.";
            else
                return "Ich drehte das magische Rad am Kerzenhalter. Nichts weiter passierte, da die Kerze schon brannte.";
        }
    }
    public static string Extinguish_Magic_Candle_Yes
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich pustete die Kerze aus. Die Flamme erlosch sofort.";
            else
                return "Ich pustete die Kerze aus. Die Flamme erlosch sofort.";
        }
    }
    public static string Extinguish_Magic_Candle_No
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich pustete und pustete, aber da die Kerze schon erloschen war, tat sich hier nichts weiter.";
            else
                return "Ich pustete und pustete, aber da die Kerze schon erloschen war, tat sich hier nichts weiter.";
        }
    }

    public static string Adv_I00_Claw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein riesiger Edelstein, rund geformt mit einem spitzen, klauenartigen Ende. Im Inneren des Steins waberte grünes Licht.";
            else
                return "Ein riesiger Edelstein, rund geformt mit einem spitzen, klauenartigen Ende. Im Inneren des Steins waberte grünes Licht.";
        }
    }
    public static string Adv_I00_Roll_Plaster
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine Rolle mit altem, vergilbtem Pflaster.";
            else
                return "Eine Rolle mit altem, vergilbtem Pflaster.";
        }
    }
    public static string Adv_I00_Unstable_Pliers_With_Claw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Zuckerzange steckt vorne die Klaue drin. Das ganze Gebilde war ganz schön instabil.";
            else
                return "In der Zuckerzange steckt vorne die Klaue drin. Das ganze Gebilde war ganz schön instabil.";
        }
    }
    public static string Adv_I00_Stable_Pliers_With_Claw
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Zuckerzange steckt vorne die Klaue drin. Da der Zangengriff mit Rollplflaster umwickelt war, war die Klaue stabil eingeklemmt in der Zange.";
            else
                return "In der Zuckerzange steckt vorne die Klaue drin. Da der Zangengriff mit Rollplflaster umwickelt war, war die Klaue stabil eingeklemmt in der Zange.";
        }
    }
    public static string Adv_I00_Magnifier
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine sehr große, stark vergrößernde Lupe";
            else
                return "Eine sehr große, stark vergrößernde Lupe";
        }
    }
    public static string Adv_I00_Squeaky_Duck
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein quietschegelbes Quietscheentchen aus billigstem Plastik. Schwer zu glauben, dass ein akademisches Schwergewicht wie Meister Gunnar damit sein Badevergnügen aufwerten konnte.";
            else
                return "Ein quietschegelbes Quietscheentchen aus billigstem Plastik. Schwer zu glauben, dass ein akademisches Schwergewicht wie Meister Gunnar damit sein Badevergnügen aufwerten konnte.";
        }
    }
    public static string Adv_I00_Paper_Sheets
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Stapel beschriebener Papierbögen. Ich begann zu lesen, was dort stand: \"Oh, du mein Quietscheentchen! Dein ist mein ganzes Streben...\" Ich hielt inne, ehe ich meine Restachtung vor Meister Gunnar auch noch verlor.";
            else
                return "Ein Stapel beschriebener Papierbögen. Ich begann zu lesen, was dort stand: \"Oh, du mein Quietscheentchen! Dein ist mein ganzes Streben...\" Ich hielt inne, ehe ich meine Restachtung vor Meister Gunnar auch noch verlor.";
        }
    }
    public static string Adv_I00_Book_Master
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Belegexemplar des Buchs von Meister Gunnar: \"Die geheimen Magietricks von Meister Gunnar\" Auf einer der ersten Seiten befand sich eine Lithografie von Meister Gunnar, die ihn sehr naturgetreu, aber auch unfassbar schmierig darstelle.";
            else
                return "Ein Belegexemplar des Buchs von Meister Gunnar: \"Die geheimen Magietricks von Meister Gunnar\" Auf einer der ersten Seiten befand sich eine Lithografie von Meister Gunnar, die ihn sehr naturgetreu, aber auch unfassbar schmierig darstelle.";
        }
    }
    public static string Adv_I00_Cheese
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Käsestück war völlig vertrocknet und für ein menschliches Wesen nicht mehr essbar.";
            else
                return "Das Käsestück war völlig vertrocknet und für ein menschliches Wesen nicht mehr essbar.";
        }
    }
    public static string Adv_I00_Polished_Stone
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein blank polierter Kieselstein.";
            else
                return "Ein blank polierter Kieselstein.";
        }
    }
    public static string Adv_I00_Sugar_Pliers
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mit dieser verzierten Zuckerzange konnte man Würfelzucker in den Tee befördern oder andere lustige Dinge anstellen.";
            else
                return "Mit dieser verzierten Zuckerzange konnte man Würfelzucker in den Tee befördern oder andere lustige Dinge anstellen.";
        }
    }
    public static string Adv_I00_Key
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein verzierter, altmodischer Bartschlüssel ";
            else
                return "Ein verzierter, altmodischer Bartschlüssel ";
        }
    }
    public static string Adv_I00_Polishing_Rag
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Lappen, wie man ihn zum Polieren von Metall verwendete.";
            else
                return "Ein Lappen, wie man ihn zum Polieren von Metall verwendete.";
        }
    }

    public static string Adv_I00_Lightless_Stone
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Stein, der schwärzer als schwarz war. Er war sozusagen der Inbegriff von Lichtlosigkeit.";
            else
                return "Ein Stein, der schwärzer als schwarz war. Er war sozusagen der Inbegriff von Lichtlosigkeit.";
        }
    }

    public static string Adv_I00_Moonstone
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Kiesel war nun vollständig mit Mondlicht vollgesogen. Das machte ihn zum Mondstein.";
            else
                return "Der Kiesel war nun vollständig mit Mondlicht vollgesogen. Das machte ihn zum Mondstein.";
        }
    }
    public static string Adv_I00_Plastic_Bag
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Plastikbeutel, gefüllt mit einer komischen Substanz. Darauf klebte ein Warnaufkleber \"Vorsicht! Aggressive Pilzsporen! Nicht ins Müsli\" Da sprach einer aus Erfahrung, schien mir.";
            else
                return "Ein Plastikbeutel, gefüllt mit einer komischen Substanz. Darauf klebte ein Warnaufkleber \"Vorsicht! Aggressive Pilzsporen! Nicht ins Müsli\" Da sprach einer aus Erfahrung, schien mir.";
        }
    }
    public static string Adv_I00_Wonder_Wart_Sponge
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Noch nie zuvor hatte ich einen deartig prachtvollen Wunderwarzenschwamm gesehen. Das konnte natürlich auch daran liegen, dass ich noch nie zuvor ein solches Ding gesehen hatte.";
            else
                return "Noch nie zuvor hatte ich einen deartig prachtvollen Wunderwarzenschwamm gesehen. Das konnte natürlich auch daran liegen, dass ich noch nie zuvor ein solches Ding gesehen hatte.";
        }
    }
    public static string Adv_I00_Slag
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Aus meinen schönen Zutaten war ein unansehnlicher Schlackeklumpen gworden.";
            else
                return "Aus meinen schönen Zutaten war ein unansehnlicher Schlackeklumpen gworden.";
        }
    }
    public static string Adv_I00_Plunger
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein großer Stößel für einen großen Mörser.";
            else
                return "Ein großer Stößel für einen großen Mörser.";
        }
    }
    public static string Adv_I00_Coin
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine golden schimmernde Münze.";
            else
                return "Eine golden funkelnde Münze.";
        }
    }
    public static string Adv_I00_Coin2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Zu dumm, dass sie unten auf dem Grund des Brunnens lag und unerreichbar war.";
            else
                return "Zu dumm, dass sie unten auf dem Grund des Brunnens lag und unerreichbar war.";
        }
    }
    public static string Adv_I01_Forest
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Vollmond tauchte den Nebel in ein fahles Licht, das die Silhouetten der knorrigen Bäume hervorhob.";
            else
                return "Der Vollmond tauchte den Nebel in ein fahles Licht, das die Silhouetten der knorrigen Bäume hervorhob.";
        }
    }
    public static string Adv_I01_Trees
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es gab hier unzählige knorrige Bäume in einem nebligen Wald. Keiner davon erschien mir sonderlich interessant.";
            else
                return "Es gab hier unzählige knorrige Bäume in einem nebligen Wald. Keiner davon erschien mir sonderlich interessant.";
        }
    }
    public static string Adv_I01_Mist
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Vollmond tauchte den Nebel in ein fahles Leuchten.";
            else
                return "Der Vollmond tauchte den Nebel in ein fahles Leuchten.";
        }
    }
    public static string Adv_I01_Forest_Grass
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es handelte sich um gewöhnliches, weiches Waldgras, das mir gerade so rein gar nichts nutzte.";
            else
                return "Es handelte sich um gewöhnliches, weiches Waldgras, das mir gerade so rein gar nichts nutzte.";
        }
    }
    public static string Adv_I02_Doormat
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine große Türmatte mit der wenig erfreulichen Aufschrift: \"Betteln und Hausieren verboten!\"";
            else
                return "Eine große Türmatte mit der wenig erfreulichen Aufschrift: \"Betteln und Hausieren verboten!\"";
        }
    }
    public static string Adv_I02_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Durch diese sehr solide wirkende Tür gelangte man ins Innere der Hütte. Dass die Tür nicht abgeschlossen war, ließ sich bereits daran erkennen, dass sie überhaupt kein Schloss hatte.";
            else
                return "Durch diese sehr solide wirkende Tür gelangte man ins Innere der Hütte. Dass die Tür nicht abgeschlossen war, ließ sich bereits daran erkennen, dass sie überhaupt kein Schloss hatte.";
        }
    }
    public static string Adv_I02_Shed
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine einsame, etwas schäbige Hütte mitten im Wald. Wegen des starken Nebels erkannte ich nicht allzu viel davon. Aber ein Prachtbau war dieses Gebäude bestimmt nicht. Warum leistete sich Meister Gunnar nicht einen schicken Loft in der Stadt?";
            else
                return "Eine einsame, etwas schäbige Hütte mitten im Wald. Wegen des starken Nebels erkannte ich nicht allzu viel davon. Aber ein Prachtbau war dieses Gebäude bestimmt nicht. Warum leistete sich Meister Gunnar nicht einen schicken Loft in der Stadt?";
        }
    }
    public static string Adv_I02_Forest
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Vollmond tauchte den Nebel in ein fahles Licht, das die Silhouetten der knorrigen Bäume hervorhob.";
            else
                return "Der Vollmond tauchte den Nebel in ein fahles Licht, das die Silhouetten der knorrigen Bäume hervorhob.";
        }
    }
    public static string Adv_I02_Trees
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Jenseits der Hütte wuchsen hier unzählige knorrige Bäume im nebligen Wald. Keiner davon erschien mir sonderlich interessant.";
            else
                return "Jenseits der Hütte wuchsen hier unzählige knorrige Bäume im nebligen Wald. Keiner davon erschien mir sonderlich interessant.";
        }
    }
    public static string Adv_I03_Door_Solid
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Durch eine solide Tür konnte man dieses fürstliche Domizil verlassen.";
            else
                return "Durch eine solide Tür konnte man dieses fürstliche Domizil verlassen.";
        }
    }
    public static string Adv_I02_Mist
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nebel, soweit das Auge reichte.";
            else
                return "Nebel, soweit das Auge reichte.";
        }
    }
    public static string Adv_I03_Pentagram
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf den Holzboden war mit roter Farbe ein Pentagramm gemalt. ";
            else
                return "Auf den Holzboden war mit roter Farbe ein Pentagramm gemalt. ";
        }
    }
    public static string Adv_I03_Runes
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hätte ich im Unterricht besser aufgepasst, hätte ich vermutlich bestimmen können, was diese Runen aussagten. So aber sah ich nur eine Ansammlung seltsamer Runen, die irgendwie bedrohlich wirkten. ";
            else
                return "Hätte ich im Unterricht besser aufgepasst, hätte ich vermutlich bestimmen können, was diese Runen aussagten. So aber sah ich nur eine Ansammlung seltsamer Runen, die irgendwie bedrohlich wirkten. ";
        }
    }
    public static string Adv_I03_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der östlichen Wand befand sich ein schäbiges kleines Türchen.";
            else
                return "In der östlichen Wand befand sich ein schäbiges kleines Türchen.";
        }
    }
    public static string Adv_I04_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die schäbige Tür in der westlichen Wand führt aus der Kammer heraus.";
            else
                return "Die schäbige Tür in der westlichen Wand führt aus der Kammer heraus.";
        }
    }
    public static string Adv_I04_Shelf
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich blickte auf ein klappriges Regal, das selbst für meinen eigenen Keller zu schäbig gewesen wäre.";
            else
                return "Ich blickte auf ein klappriges Regal, das selbst für meinen eigenen Keller zu schäbig gewesen wäre.";
        }
    }
    public static string Adv_I04_Cupboard
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der wurmstichige Schrank stand nutzlos im Weg.";
            else
                return "Der wurmstichige Schrank stand nutzlos im Weg.";
        }
    }
    public static string Adv_I04_Wall
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die steinerne Wand war grob gemauert und ganz schön schief.";
            else
                return "Die steinerne Wand war grob gemauert und ganz schön schief.";
        }
    }
    public static string Adv_I04_Flap
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine kleine Metallklappe, wie man sie an Schornsteinen fand.";
            else
                return "Eine kleine Metallklappe, wie man sie an Schornsteinen fand.";
        }
    }
    public static string Adv_I04_Opening
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Wand klaffte eine dunkle, rechteckige Öffnung.";
            else
                return "In der Wand klaffte eine dunkle, rechteckige Öffnung.";
        }
    }
    public static string Adv_I05_Library_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der westlichen Wand befand sich eine hohe, verzierte Tür. Ein hölzernes Schrift mit dem Schriftzug \"Bibliothek\" ließ wenig Zweifel daran, was sich hinter dieser Tür befand.";
            else
                return "In der westlichen Wand befand sich eine hohe, verzierte Tür. Ein hölzernes Schrift mit dem Schriftzug \"Bibliothek\" ließ wenig Zweifel daran, was sich hinter dieser Tür befand.";
        }
    }
    public static string Adv_I05_Pentagram
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf den Steinboden war mit roter Farbe ein Pentagramm gemalt. ";
            else
                return "Auf den Steinboden war mit roter Farbe ein Pentagramm gemalt. ";
        }
    }
    public static string Adv_I05_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Südwand führte eine Tür aus dem Atrium.";
            else
                return "In der Südwand führte eine Tür aus dem Atrium.";
        }
    }
    public static string Adv_I05_Moon
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Über dem Atrium stand ein riesiger, heller Vollmond, fast zum Greifen nah.";
            else
                return "Über dem Atrium stand ein riesiger, heller Vollmond, fast zum Greifen nah.";
        }
    }
    public static string Adv_I05_Pedestal
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein edel verziertes Podest und mit Gold überzogen. Ein nicht zu übersehendes Warnschild war daran befestigt.";
            else
                return "Ein edel verziertes Podest und mit Gold überzogen. Ein nicht zu übersehendes Warnschild war daran befestigt.";
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
                return "Neben der Tür in der westlichen Wand befand sich ein hohes Sims.";
            else
                return "Neben der Tür in der westlichen Wand befand sich ein hohes Sims.";
        }
    }

    public static string Adv_I06_Door_Wide
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine breite Tür führte zurück ins Atrium.";
            else
                return "Eine breite Tür führte zurück ins Atrium.";
        }
    }
    public static string Adv_I06_Letters
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Einige kleine Buchstaben auf der Rückseite der Rüstung. Mit bloßem Auge waren sie nicht zu entziffern.";
            else
                return "Einige kleine Buchstaben auf der Rückseite der Rüstung. Mit bloßem Auge waren sie nicht zu entziffern.";
        }
    }
    public static string Adv_I06_Door_Red
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Westwand befand sich eine rote Tür mit der Aufschrift \"Bad\".";
            else
                return "In der Westwand befand sich eine rote Tür mit der Aufschrift \"Bad\".";
        }
    }
    public static string Adv_I06_Door_White
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf der weißen Tür in der Ostwand stand \"Küche\".";
            else
                return "Auf der weißen Tür in der Ostwand stand \"Küche\".";
        }
    }
    public static string Adv_I06_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine robuste Tür, die mit einem magischen Siegel versehen war. Neben der Klinke hing ein kleines Schild.";
            else
                return "Eine robuste Tür, die mit einem magischen Siegel versehen war. Neben der Klinke hing ein kleines Schild.";
        }
    }
    public static string Adv_I06_Door_Broken
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine robuste Tür, die mit einem magischen Siegel versehen war. Neben der Klinke hing ein kleines Schild. Die Tür war halb zerbrochen und hing nur noch lose in den Angeln. Von dem einstigen magischen Schutz war nichts mehr zu bemerken.";
            else
                return "Eine robuste Tür, die mit einem magischen Siegel versehen war. Neben der Klinke hing ein kleines Schild. Die Tür war halb zerbrochen und hing nur noch lose in den Angeln. Von dem einstigen magischen Schutz war nichts mehr zu bemerken.";
        }
    }
    public static string Adv_I06_Seal
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es handelte sich um ein magisches Siegel mit den Initialen von Meister Gunnar darauf.";
            else
                return "Es handelte sich um ein magisches Siegel mit den Initialen von Meister Gunnar darauf.";
        }
    }
    public static string Adv_I06_Seal_Broken
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es handelte sich um ein magisches Siegel mit den Initialen von Meister Gunnar darauf. Das Siegel war mitten durchgebrochen. Iregendwie enttäuschend für ein magisches Siegel...";
            else
                return "Es handelte sich um ein magisches Siegel mit den Initialen von Meister Gunnar darauf. Das Siegel war mitten durchgebrochen. Iregendwie enttäuschend für ein magisches Siegel...";
        }
    }
    public static string Adv_I06_Sign
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf dem Schild stand groß \"Privat\". Sehr witzig. Und darunter stand noch in klein: \"Keine rohe Gewalt anwenden!\" Tja, warum eigentlich nicht?";
            else
                return "Auf dem Schild stand groß \"Privat\". Sehr witzig. Und darunter stand noch in klein: \"Keine rohe Gewalt anwenden!\" Tja, warum eigentlich nicht?";
        }
    }
    public static string Adv_I06_Sign_Broken
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf dem Schild stand groß \"Privat\". Sehr witzig. Und darunter stand noch in klein: \"Keine rohe Gewalt anwenden!\" Danke nochmal für den Tipp, liebes Schild.";
            else
                return "Auf dem Schild stand groß \"Privat\". Sehr witzig. Und darunter stand noch in klein: \"Keine rohe Gewalt anwenden!\" Danke nochmal für den Tipp, liebes Schild.";
        }
    }

    public static string Adv_I07_Door_Blue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine blaue Tür führte nach Westen.";
            else
                return "Eine blaue Tür führte nach Westen.";
        }
    }
    public static string Adv_I07_Door_Green
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der südlichen Wand befand sich eine wenig auffällige grüne Tür.";
            else
                return "In der südlichen Wand befand sich eine wenig auffällige grüne Tür.";
        }
    }

    public static string Adv_I07_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine schwere, sehr massive Tür führte nach Osten. Der Schriftzug \"Labor\" war schon leicht abgeblättert. Unter dem Türgriff befand sich ein Schlüsselloch für einen großen Bartschlüssel.";
            else
                return "Eine schwere, sehr massive Tür führte nach Osten. Der Schriftzug \"Labor\" war schon leicht abgeblättert. Unter dem Türgriff befand sich ein Schlüsselloch für einen großen Bartschlüssel.";
        }
    }
    public static string Adv_I08_Door_Blue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Durch die blaue Tür gelangte man zurück zum Flur des Untergeschosses.";
            else
                return "Durch die blaue Tür gelangte man zurück zum Flur des Untergeschosses.";
        }
    }
    public static string Adv_I08_Clothes_Line
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mehrere Wäscheleinen reichten von einer Seite der Waschküche zur anderen und zurück.<br>Eine einsame Unterhose baumelte an einer der Leinen.";
            else
                return "Mehrere Wäscheleinen reichten von einer Seite der Waschküche zur anderen und zurück.<br>Eine einsame Unterhose baumelte an einer der Leinen.";
        }
    }
    public static string Adv_I08_Underpants
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine hässliche alte Unterhose, der man ihre edle Herkunft aber noch ansah. Es stand nämlich groß und breit \"Karl Lagerhaus\" darauf.";
            else
                return "Eine hässliche alte Unterhose, der man ihre edle Herkunft aber noch ansah. Es stand nämlich groß und breit \"Karl Lagerhaus\" darauf.";
        }
    }
    public static string Adv_I08_Well
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mitten in der Waschküche befand sich ein gemauerter Brunnen.";
            else
                return "Mitten in der Waschküche befand sich ein gemauerter Brunnen.";
        }
    }
    public static string Adv_I08_Well_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die hölzerne Abdeckung deckte den Brunnen ab.";
            else
                return "Die hölzerne Abdeckung deckte den Brunnen ab.";
        }
    }
    public static string Adv_I08_Well_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Irgendwo tief unten im Brunnen hatte kurz etwas geschimmert. Aber es war zu dunkel, um wirklich etwas im Wasser zu erkennen.";
            else
                return "Irgendwo tief unten im Brunnen hatte kurz etwas geschimmert. Aber es war zu dunkel, um wirklich etwas im Wasser zu erkennen.";
        }
    }
    public static string Adv_I08_Wooden_Cover
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die hölzerne Abdeckung war dazu gedacht, den Brunnen abzudecken, damit niemand hinein fiel.";
            else
                return "Die hölzerne Abdeckung war dazu gedacht, den Brunnen abzudecken, damit niemand hinein fiel.";
        }
    }
    public static string Adv_I08_Water
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Wasser füllte den Brunnen fast bis zum Rand. Es reichte hinab bin in dunkle Tiefen.";
            else
                return "Das Wasser füllte den Brunnen fast bis zum Rand. Es reichte hinab bin in dunkle Tiefen.";
        }
    }
    public static string Adv_I08_Washing_Machine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine magische Waschmaschine neuester Bauart. Ich kannte nicht viele Leute, die sich so etwas leisten konnten.";
            else
                return "Eine magische Waschmaschine neuester Bauart. Ich kannte nicht viele Leute, die sich so etwas leisten konnten.";
        }
    }
    public static string Adv_I08_Clothes
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Haufen mit feuchter, müffelnder Wäsche. Ich hoffe, bei dieser oberflächlichen Untersuchung konnte ich es belassen.";
            else
                return "Ein Haufen mit feuchter, müffelnder Wäsche. Ich hoffe, bei dieser oberflächlichen Untersuchung konnte ich es belassen.";
        }
    }
    public static string Adv_I08_Machine_For_Hanging_Up_Laundry
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine vollautomatische Wäscheaufhängmaschine. Leider waren ihre Arme verbogen und verknotet. Meister Gunnars Umgang mit wertvollem Haushaltsequipment war doch sehr fragwürdig.";
            else
                return "Eine vollautomatische Wäscheaufhängmaschine. Leider waren ihre Arme verbogen und verknotet. Meister Gunnars Umgang mit wertvollem Haushaltsequipment war doch sehr fragwürdig.";
        }
    }
    public static string Adv_I08_Laundry_Basket
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein sehr gewöhnlicher Wäschekorb.";
            else
                return "Ein sehr gewöhnlicher Wäschekorb.";
        }
    }
    public static string Adv_I09_Red_Shelf
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein recht robust aussehendes rotes Regal.";
            else
                return "Ein recht robust aussehendes rotes Regal.";
        }
    }
    public static string Adv_I09_Green_Shelf
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein recht robust aussehendes grünes Regal.";
            else
                return "Ein recht robust aussehendes grünes Regal.";
        }
    }
    public static string Adv_I09_Library_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Durch die verzierte Tür gelangte man ins Atrium zurück.";
            else
                return "Durch die verzierte Tür gelangte man ins Atrium zurück.";
        }
    }
    public static string Adv_I09_Librarians_Desk
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein schwerer hölzerner Bbliothekstresen.";
            else
                return "Ein schwerer hölzerner Bbliothekstresen.";
        }
    }
    public static string Adv_I09_Angry_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Buch schnappte hasserfüllt nach mir.";
            else
                return "Das Buch schnappte hasserfüllt nach mir.";
        }
    }
    public static string Adv_I09_Crazy_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich streckte die Finger nach dem verrückten Buch aus. Plötzlich platzte es in ein irres Lachen heraus. Hastig zog ich meine Hand zurück.";
            else
                return "Ich streckte die Finger nach dem verrückten Buch aus. Plötzlich platzte es in ein irres Lachen heraus. Hastig zog ich meine Hand zurück.";
        }
    }
    public static string Adv_I09_Demonic_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Buch musterte mich mit seinen tiefroten Dämonenaugen. Ich schaute lieber weg.";
            else
                return "Das Buch musterte mich mit seinen tiefroten Dämonenaugen. Ich schaute lieber weg.";
        }
    }
    public static string Adv_I09_Satanic_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Buch hatte eine Teufelsfratze auf der Vorderseite, die mich hämisch angrinste. Ab und an kicherte die Fratze zutiefst bösartig.";
            else
                return "Das Buch hatte eine Teufelsfratze auf der Vorderseite, die mich hämisch angrinste. Ab und an kicherte die Fratze zutiefst bösartig.";
        }
    }
    public static string Adv_I09_Weird_Book
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Buch brabbelte wirr vor sich hin. Genervt zog ich meine Hand zurück.";
            else
                return "Das Buch brabbelte wirr vor sich hin. Genervt zog ich meine Hand zurück.";
        }
    }
    public static string Adv_I09_Sign
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf dem Schild stand: \"Bücher nicht ohne sachkundige Unterstützung berühren! Lebensgefahr!\"";
            else
                return "Auf dem Schild stand: \"Bücher nicht ohne sachkundige Unterstützung berühren! Lebensgefahr!\"";
        }
    }
    public static string Adv_I09_Carton
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein großer, schwerer Karton von \"Egobooster Selfpublishing\"";
            else
                return "Ein großer, schwerer Karton von \"Egobooster Selfpublishing\"";
        }
    }
    public static string Adv_I09_Books_Master
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Stapel Belegexemplare des Buchs von Meister Gunnar: \"Die geheimen Magietricks von Meister Gunnar\" Auf einer der ersten Seiten befand sich eine Lithografie von Meister Gunnar, die ihn sehr naturgetreu, aber auch unfassbar schmierig darstelle.<br>Ich konnte einen Brechreiz gerade so noch unterdrücken.";
            else
                return "Ein Stapel Belegexemplare des Buchs von Meister Gunnar: \"Die geheimen Magietricks von Meister Gunnar\" Auf einer der ersten Seiten befand sich eine Lithografie von Meister Gunnar, die ihn sehr naturgetreu, aber auch unfassbar schmierig darstelle.<br>Ich konnte einen Brechreiz gerade so noch unterdrücken.";
        }
    }
    public static string Adv_I10_Labor_Table
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der lange Labortisch reichte von einer Wand zur anderen und war übersät mit gefährlich aussehenden Dingen.";
            else
                return "Der lange Labortisch reichte von einer Wand zur anderen und war übersät mit gefährlich aussehenden Dingen.";
        }
    }
    public static string Adv_I10_Cages
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die mannshohen Metallkäfige waren vermutlich geeignet, auch gefährlichste Kreaturen sicher in ihrem Inneren gefangen zu setzen. Trotzdem fand ich es sehr beruhigend, dass die Käfige allesamt leer waren.";
            else
                return "Die mannshohen Metallkäfige waren vermutlich geeignet, auch gefährlichste Kreaturen sicher in ihrem Inneren gefangen zu setzen. Trotzdem fand ich es sehr beruhigend, dass die Käfige allesamt leer waren.";
        }
    }
    public static string Adv_I11_Door_Green
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die grüne Tür in der Nordwand führte nach draußen.";
            else
                return "Die grüne Tür in der Nordwand führte nach draußen.";
        }
    }
    public static string Adv_I10_First_Aid_Kit
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der wuchtige Erste-Hilfe-Kasten wirkte, als sei schon so mancher Feuerregen auf ihn hernieder gegangen wäre.";
            else
                return "Der wuchtige Erste-Hilfe-Kasten wirkte, als sei schon so mancher Feuerregen auf ihn hernieder gegangen wäre.";
        }
    }
    public static string Adv_I10_Drawer
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Im Labortisch befand sich eine gewöhnliche Schublade.";
            else
                return "Im Labortisch befand sich eine gewöhnliche Schublade.";
        }
    }
    public static string Adv_I10_Bracket
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Mit der metallenen Halterung ließ sich bestimmt etwas fixieren, ein anderer Teil der Versuchsanordnung zum Beispiel.";
            else
                return "Mit der metallenen Halterung ließ sich bestimmt etwas fixieren, ein anderer Teil der Versuchsanordnung zum Beispiel.";
        }
    }
    public static string Adv_I10_Metal_Tray
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Metallschale war an der Unterseite schwarz. Wie oft war diese Schale wohl schon erhitzt worden?";
            else
                return "Die Metallschale war an der Unterseite schwarz. Wie oft war diese Schale wohl schon erhitzt worden?";
        }
    }
    public static string Adv_I10_Darkness_Machine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ehrfürchtig betrachtete ich das Gerät. Ich hatte es sofort als die wertvoll Dunkelheitsmaschine erkannt, die Meister Gunnar vor kurzem im Unterricht gezeigt hatte. Damit konnte man einem Gegenstand sämtliches Licht entziehen? Und warum? Damit er neues, magisches Licht aufnahm. Ein beeindruckendes Beispiel fortgeschrittener Magie, von dem ich gerne mehr verstanden hätte. Schade, dass ich gerade dabei war, mein Studium gegen die Wand zu fahren.";
            else
                return "Ehrfürchtig betrachtete ich das Gerät. Ich hatte es sofort als die wertvoll Dunkelheitsmaschine erkannt, die Meister Gunnar vor kurzem im Unterricht gezeigt hatte. Damit konnte man einem Gegenstand sämtliches Licht entziehen? Und warum? Damit er neues, magisches Licht aufnahm. Ein beeindruckendes Beispiel fortgeschrittener Magie, von dem ich gerne mehr verstanden hätte. Schade, dass ich gerade dabei war, mein Studium gegen die Wand zu fahren.";
        }
    }
    public static string Adv_I10_Hatch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "In der Dunkelheitsmaschine befand ich eine kleine Klappe.";
            else
                return "In der Dunkelheitsmaschine befand ich eine kleine Klappe.";
        }
    }
    public static string Adv_I10_Opening
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Unter der Klapep an der Dunkelheitsmaschine lag eine kleine Öffnung.";
            else
                return "Unter der Klapep an der Dunkelheitsmaschine lag eine kleine Öffnung.";
        }
    }
    public static string Adv_I10_Switch
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein Ein/Aus-Schalter.";
            else
                return "Ein Ein/Aus-Schalter.";
        }
    }
    public static string Adv_I10_Giant_Mortar
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein sehr großer Mörser, in dem Meister Gunnar vermutlich seine Pülverchen zusammenstößelte.";
            else
                return "Ein sehr großer Mörser, in dem Meister Gunnar vermutlich seine Pülverchen zusammenstößelte.";
        }
    }
    public static string Adv_I10_Labor_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Tür in der Westwand des Labors führte nach draußen zum Flur.";
            else
                return "Die Tür in der Westwand des Labors führte nach draußen zum Flur.";
        }
    }
    public static string Adv_I11_Left_Shelf
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Links von mir befand sich ein hohes Regal.";
            else
                return "Links von mir befand sich ein hohes Regal.";
        }
    }
    public static string Adv_I11_Right_Shelf
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Rechts von mir befand sich ein hohes Regal.";
            else
                return "Rechts von mir befand sich ein hohes Regal.";
        }
    }
    public static string Adv_I11_Bird_Stand
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Auf der Vogelstange saß eine - festgekettete - ausgestopfte Elster.";
            else
                return "Auf der Vogelstange saß eine - festgekettete - ausgestopfte Elster.";
        }
    }
    public static string Adv_I12_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine angedetschte Tür in der Nordwand führte zurück zum Flur.";
            else
                return "Eine angedetschte Tür in der Nordwand führte zurück zum Flur.";
        }
    }
    public static string Adv_I12_Wardrobe
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der wuchtige Kleiderschrank war mit kitschigen Motiven bemalt. Er nahm gefühlt die eine Hälfe des Raumes ein. ";
            else
                return "Der wuchtige Kleiderschrank war mit kitschigen Motiven bemalt. Er nahm gefühlt die eine Hälfe des Raumes ein. ";
        }
    }
    public static string Adv_I12_Bed
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein feudales Bett, wie geschaffen für ein sinnenfrohes Lotterleben. Leider passte der Rest des Raumes überhaupt nicht dazu.";
            else
                return "Ein feudales Bett, wie geschaffen für ein sinnenfrohes Lotterleben. Leider passte der Rest des Raumes überhaupt nicht dazu.";
        }
    }
    public static string Adv_I12_Matress
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine sehr dicke, teure Matratze mit XXL-Ausmaßen. Groß genug, um darauf eine Ferienwohnung zu errichten.";
            else
                return "Eine sehr dicke, teure Matratze mit XXL-Ausmaßen. Groß genug, um darauf eine Ferienwohnung zu errichten.";
        }
    }
    public static string Adv_I13_Drawer
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine hölzerne Schublade in der Anrichte.";
            else
                return "Eine hölzerne Schublade in der Anrichte.";
        }
    }
    public static string Adv_I13_Door_White
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine weiße Tür in der westlichen Wand führte zurück zum Flur.";
            else
                return "Eine weiße Tür in der westlichen Wand führte zurück zum Flur.";
        }
    }
    public static string Adv_I13_Cupboard
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein wenig aufregender Küchenschrank stand an der Wand.";
            else
                return "Ein wenig aufregender Küchenschrank stand an der Wand.";
        }
    }
    public static string Adv_I13_Fridge
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein sehr moderner magischer Kühlschrank, wie dafür gemacht, köstliche Leckereien lange frisch zu halten.";
            else
                return "Ein sehr moderner magischer Kühlschrank, wie dafür gemacht, köstliche Leckereien lange frisch zu halten.";
        }
    }
    public static string Adv_I13_Freezer
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "An der Unterseite des Kühlschranks befand sich ein großes Gefrierfach.";
            else
                return "An der Unterseite des Kühlschranks befand sich ein großes Gefrierfach.";
        }
    }
    public static string Adv_I14_Mirror
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ein gewöhnlicher Badezimmerspielge, bis auf den Umstand, dass jemand etwas mit einem Permanentmarker auf den Spiegel geschrieben hatte.";
            else
                return "Ein gewöhnlicher Badezimmerspielge, bis auf den Umstand, dass jemand etwas mit einem Permanentmarker auf den Spiegel geschrieben hatte.";
        }
    }
    public static string Adv_I14_Door_Red
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine rote Tür in der östlichen Wand führte zurück zum Flur.";
            else
                return "Eine rote Tür in der östlichen Wand führte zurück zum Flur.";
        }
    }
    public static string Adv_I14_Writing
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Schriftzug besagte: \"Labor abschließen nicht vergessen!\" Hatte der Meister Angst vor ungebetenen Besuchern in seinem magischen Versteck, oder lags an den Bewohnern seines Labors?";
            else
                return "Der Schriftzug besagte: \"Labor abschließen nicht vergessen!\" Hatte der Meister Angst vor ungebetenen Besuchern in seinem magischen Versteck, oder lags an den Bewohnern seines Labors?";
        }
    }
    public static string Adv_I14_Kacheln
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Badezimmer war mit sehr gewöhnlich aussehenden grauen Kacheln gekachelt.";
            else
                return "Das Badezimmer war mit sehr gewöhnlich aussehenden grauen Kacheln gekachelt.";
        }
    }
    public static string Examine_I14_Kacheln_Kachel
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine der Kacheln hatte eine etwas andere Farbe als die anderen.";
            else
                return "Eine der Kacheln hatte eine etwas andere Farbe als die anderen.";
        }
    }
    public static string Adv_I14_Bathtub
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine große Badewanne mit magischem Whirlpool-Einsatz.";
            else
                return "Eine große Badewanne mit magischem Whirlpool-Einsatz.";
        }
    }
    public static string Adv_I14_Special_Tile
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Kachel war gar nicht echt, sondern eine Projektion. Kaum hatte ich das gedacht, verschwand sie auch schon und eine Öffnung wurde sichtbar dahinter.";
            else
                return "Die Kachel war gar nicht echt, sondern eine Projektion. Kaum hatte ich das gedacht, verschwand sie auch schon und eine Öffnung wurde sichtbar dahinter.";
        }
    }
    public static string Adv_I14_Toilet
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine ganz gewöhnliche Toilette. Wo blieb hier die Magie, Meister Gunnar?";
            else
                return "Eine ganz gewöhnliche Toilette. Wo blieb hier die Magie, Meister Gunnar?";
        }
    }
    public static string Adv_I14_Opening
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Dort, wo sich die Projektion einer Fliese befunden hatte, befand sich nun eine kachelgroße Öffnung in der Wand.";
            else
                return "Dort, wo sich die Projektion einer Fliese befunden hatte, befand sich nun eine kachelgroße Öffnung in der Wand.";
        }
    }
    public static string Adv_I14_Flushing
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine unmagische Toilettenspülung.";
            else
                return "Eine unmagische Toilettenspülung.";
        }
    }

    public static string Owl_Dialog_Start_Long
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuh, uhuuh, wer stört meinen Schlaf?";
            else
                return "Uhuuh, uhuuh, wer stört meinen Schlaf?";
        }
    }
    public static string Owl_Dialog_Start_Long2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich. Passt dir daran irgendwas nicht?";
            else
                return "Ich. Passt dir daran irgendwas nicht?";
        }
    }
    public static string Owl_Dialog_Start_Long3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, äh.... Uhuuh, uhuuh, was kann ich für dich tun?";
            else
                return "Nun, äh.... Uhuuh, uhuuh, was kann ich für dich tun?";
        }
    }
    public static string Owl_Dialog_Start_Short
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuh, uhuuh, was kann ich für dich tun?";
            else
                return "Uhuuh, uhuuh, was kann ich für dich tun?";
        }
    }
    public static string Owl_Dialog_Job
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was genau ist dein Job hier?";
            else
                return "Was genau ist dein Job hier?";
        }
    }
    public static string Owl_Dialog_Job2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuh, uhuuh, ich soll dieses Atrium mit meiner Weisheit durchdringen... ";
            else
                return "Uhuuh, uhuuh, ich soll dieses Atrium mit meiner Weisheit durchdringen... ";
        }
    }
    public static string Owl_Dialog_Job3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ok, das klappt schon mal nur so mittel.";
            else
                return "Ok, das klappt schon mal nur so mittel.";
        }
    }
    public static string Owl_Dialog_Job4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... und dafür sorgen, dass nicht jeder Hinz und Kunz in der Bibliothek Unsinn anstellt. Nein, frag nicht, welcher Hinz und Kunz gemeint sind. Meister Gunnar hat mich immer nur komisch angeschaut, wenn ich danach gefragt habe.";
            else
                return "... und dafür sorgen, dass nicht jeder Hinz und Kunz in der Bibliothek Unsinn anstellt. Nein, frag nicht, welcher Hinz und Kunz gemeint sind. Meister Gunnar hat mich immer nur komisch angeschaut, wenn ich danach gefragt habe.";
        }
    }
    public static string Owl_Dialog_Klaue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was kannst du mir über die Klaue sagen?";
            else
                return "Was kannst du mir über die Klaue sagen?";
        }
    }
    public static string Owl_Dialog_Klaue2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, nicht viel. Es ist ein Edelstein mit magischen Fähigkeiten. Sie belebt untote Materie kurzzeitig. Hält nicht lange vor, aber besser als nichts.";
            else
                return "Nun, nicht viel. Es ist ein Edelstein mit magischen Fähigkeiten. Sie belebt untote Materie kurzzeitig. Hält nicht lange vor, aber besser als nichts.";
        }
    }
    public static string Owl_Dialog_Klaue3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sie ist ja sicher sehr wertvoll. Weißt du zufällig, wer einen solchen Edelstein kaufen würde?";
            else
                return "Sie ist ja sicher sehr wertvoll. Weißt du zufällig, wer einen solchen Edelstein kaufen würde?";
        }
    }
    public static string Owl_Dialog_Klaue4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Zum Glück steht er ja nicht zum Verkauf! Aber es gibt da ganz sicher viele Schwarzmagier, die würden ein Vermögen für diesen Stein hinlegen. Sie würden ganze Zivilisationen damit in den Untergang stürzen, aber was so ein echter Schwarzmagier ist, den kümmert das ja nicht...";
            else
                return "Zum Glück steht er ja nicht zum Verkauf! Aber es gibt da ganz sicher viele Schwarzmagier, die würden ein Vermögen für diesen Stein hinlegen. Sie würden ganze Zivilisationen damit in den Untergang stürzen, aber was so ein echter Schwarzmagier ist, den kümmert das ja nicht...";
        }
    }
    public static string Owl_Dialog_Bibliothek
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wie kommt man eigentlich in die Bibliothek?";
            else
                return "Wie kommt man eigentlich in die Bibliothek?";
        }
    }

    public static string Owl_Dialog_Bibliothek2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Indem man am großen Bibliotheksquiz teilnimmt und alle 3 Fragen richtig beantwortet! Und los gehts mit Frage 1: Welche Unterwäsche-Marke bevorzugt der Meister?";
            else
                return "Indem man am großen Bibliotheksquiz teilnimmt und alle 3 Fragen richtig beantwortet! Und los gehts mit Frage 1: Welche Unterwäsche-Marke bevorzugt der Meister?";
        }
    }
    public static string Owl_Dialog_Woin5Jahren
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Einen tollen Job als Türwächter hast du hier. Wo siehst du dich eigentlich in deiner beruflichen Weiterentwicklung in 5 Jahren?";
            else
                return "Einen tollen Job als Türwächter hast du hier. Wo siehst du dich eigentlich in deiner beruflichen Weiterentwicklung in 5 Jahren?";
        }
    }

    public static string Owl_Dialog_Woin5Jahren2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuh, uhuuh, bis dahin möchte ich zum Senior Bibliothekstür Beauftragten aufsteigen und ein ganzes Team an ausgestopften Türwächter-Eulen betreuen.";
            else
                return "Uhuuh, uhuuh, bis dahin möchte ich zum Senior Bibliothekstür Beauftragten aufsteigen und ein ganzes Team an ausgestopften Türwächter-Eulen betreuen.";
        }
    }
    public static string Owl_Dialog_Woin5Jahren3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Exzellent! Und da die Anzahl der zu bewachenden Bibliothekstüren gleich bleibt, habt ihr automatisch mehr Zeit für völlig überflüssige Bürokratie!";
            else
                return "Exzellent! Und da die Anzahl der zu bewachenden Bibliothekstüren gleich bleibt, habt ihr automatisch mehr Zeit für völlig überflüssige Bürokratie!";
        }
    }
    public static string Owl_Dialog_Woin5Jahren4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuh, uhuuh, welch geniale Idee! Wir werden Vordrucke mit mehreren Durchschlägen bekommen, mit völlig unverständlichen Feldern zum Ankreuzen!";
            else
                return "Uhuuh, uhuuh, welch geniale Idee! Wir werden Vordrucke mit mehreren Durchschlägen bekommen, mit völlig unverständlichen Feldern zum Ankreuzen!";
        }
    }

    public static string Owl_Dialog_MeisterGunnar
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was kannst du mir über Meister Gunnar erzählen? Ist der wirklich so verschroben, wie man immer hört?";
            else
                return "Was kannst du mir über Meister Gunnar erzählen? Ist der wirklich so verschroben, wie man immer hört?";
        }
    }
    public static string Owl_Dialog_MeisterGunnar2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du meinst, ob er in Wirklichkeit dralle Blondinen hierher einlädt, um ihnen die 'Geheimnisse der Magie' hautnah zu zeigen?";
            else
                return "Du meinst, ob er in Wirklichkeit dralle Blondinen hierher einlädt, um ihnen die 'Geheimnisse der Magie' hautnah zu zeigen?";
        }
    }
    public static string Owl_Dialog_MeisterGunnar3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Äh, klingt interessant. Rede weiter.";
            else
                return "Äh, klingt interessant. Rede weiter.";
        }
    }
    public static string Owl_Dialog_MeisterGunnar4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wer weiß, vielleicht stimmt ja auch das sorgfältig gehegte Image des verschrobenen Grantlers, der am liebsten mit ausgestopften Tieren und unbelebten Gegenständen redet, weil ihn Menschen überfordern. Die Wahrheit ist irgendwo da draußen...";
            else
                return "Wer weiß, vielleicht stimmt ja auch das sorgfältig gehegte Image des verschrobenen Grantlers, der am liebsten mit ausgestopften Tieren und unbelebten Gegenständen redet, weil ihn Menschen überfordern. Die Wahrheit ist irgendwo da draußen...";
        }
    }
    public static string Owl_Dialog_Quiz1_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uh, ist die Frage nicht zu persönlich?";
            else
                return "Uh, ist die Frage nicht zu persönlich?";
        }
    }
    public static string Owl_Dialog_Quiz1_1_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Schon, aber da der Meister sie selbst ausgesucht hat, kann dir das wirklich egal sein. Uhuuh, uhuuh, falsche Antwort. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Schon, aber da der Meister sie selbst ausgesucht hat, kann dir das wirklich egal sein. Uhuuh, uhuuh, falsche Antwort. Melde dich, wenn du es nochmal versuchen willst.";
        }
    }
    public static string Owl_Dialog_Quiz1_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich setze den 50:50 Joker!";
            else
                return "Ich setze den 50:50 Joker!";
        }
    }
    public static string Owl_Dialog_Quiz1_2_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuuh, uhuuuh, leider gibts keinen Joker, also war dies eine falsche Antwort. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Uhuuuh, uhuuuh, leider gibts keinen Joker, also war dies eine falsche Antwort. Melde dich, wenn du es nochmal versuchen willst.";
        }
    }
    public static string Owl_Dialog_Quiz1_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es ist eine No-Name-Marker von einem großen Online-Versandhaus.";
            else
                return "Es ist eine No-Name-Marker von einem großen Online-Versandhaus.";
        }
    }
    public static string Owl_Dialog_Quiz1_3_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du solltest dem Meister ruhig etwas mehr Geschmack zutrauen. Leider falsch. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Du solltest dem Meister ruhig etwas mehr Geschmack zutrauen. Leider falsch. Melde dich, wenn du es nochmal versuchen willst.";
        }
    }
    public static string Owl_Dialog_Quiz1_4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Edel-Unterwäsche der berühmten Marke 'Karl Lagerhaus'.";
            else
                return "Edel-Unterwäsche der berühmten Marke 'Karl Lagerhaus'.";
        }
    }
    public static string Owl_Dialog_Quiz1_4_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Exzellent. Nur die und keine andere Wäsche. Sehr gut, kommen wir zur zweiten Frage: Wer hat einst die Ritterrüstung auf dem Flur getragen?";
            else
                return "Exzellent. Nur die und keine andere Wäsche. Sehr gut, kommen wir zur zweiten Frage: Wer hat einst die Ritterrüstung auf dem Flur getragen?";
        }
    }
    public static string Owl_Dialog_Quiz2_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Heißen diese Ritter nicht sowieso alle 'Kunibert'? Dann wirds diesmal sicher auch so sein.";
            else
                return "Heißen diese Ritter nicht sowieso alle 'Kunibert'? Dann wirds diesmal sicher auch so sein.";
        }
    }
    public static string Owl_Dialog_Quiz2_1_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, dieser Ritter hieß nicht Kunibert. Damit wäre auch deine These logisch vollständig widerlegt. Also leider falsch. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Nun, dieser Ritter hieß nicht Kunibert. Damit wäre auch deine These logisch vollständig widerlegt. Also leider falsch. Melde dich, wenn du es nochmal versuchen willst.";
        }
    }
    public static string Owl_Dialog_Quiz2_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Würde es dich sehr verwirren, wenn ich jetzt einen Telefonjoker einsetzen würde?";
            else
                return "Würde es dich sehr verwirren, wenn ich jetzt einen Telefonjoker einsetzen würde?";
        }
    }
    public static string Owl_Dialog_Quiz2_2_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nein, würde es nicht, weil ic nicht mal weiß, was ein Telefon ist. Das muss ich also leider als falsche Antwort werten. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Nein, würde es nicht, weil ic nicht mal weiß, was ein Telefon ist. Das muss ich also leider als falsche Antwort werten. Melde dich, wenn du es nochmal versuchen willst.";
        }
    }
    public static string Owl_Dialog_Quiz2_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Sind Namen nicht eigentlich Schall und Rauch?";
            else
                return "Sind Namen nicht eigentlich Schall und Rauch?";
        }
    }
    public static string Owl_Dialog_Quiz2_3_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ja, sind sie. Außer denen, die bei einem Quiz abgefragt werden. Das muss ich also leider als falsche Antwort werten. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Ja, sind sie. Außer denen, die bei einem Quiz abgefragt werden. Das muss ich also leider als falsche Antwort werten. Melde dich, wenn du es nochmal versuchen willst.";
        }
    }
    public static string Owl_Dialog_Quiz2_4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Rüstung war dereinst Eigentum von Ritter Norbert, dem Reinlichen.";
            else
                return "Die Rüstung war dereinst Eigentum von Ritter Norbert, dem Reinlichen.";
        }
    }
    public static string Owl_Dialog_Quiz2_4_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Uhuuh, uhuuu, das ist richtig! Sehr gut, damit stehst du im Finale! Kommen wir zur dritten Frage: Was ist das einzige Tier, das der Meister wirklich liebt?";
            else
                return "Uhuuh, uhuuu, das ist richtig! Sehr gut, damit stehst du im Finale! Kommen wir zur dritten Frage: Was ist das einzige Tier, das der Meister wirklich liebt?";
        }
    }
    public static string Owl_Dialog_Quiz3_1
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ach, ich weiß nicht. Das ist schon wieder so eine verdammt persönliche Frage.";
            else
                return "Ach, ich weiß nicht. Das ist schon wieder so eine verdammt persönliche Frage.";
        }
    }
    public static string Owl_Dialog_Quiz3_1_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ja, ist es. Und deine Antwort war leider falsch. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Ja, ist es. Und deine Antwort war leider falsch. Melde dich, wenn du es nochmal versuchen willst.";
        }
    }
    public static string Owl_Dialog_Quiz3_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich denke, sein Lieblingstier ist die Eule. Welche Kreatur strahlt sonst soviel Anmut und Weisheit aus?";
            else
                return "Ich denke, sein Lieblingstier ist die Eule. Welche Kreatur strahlt sonst soviel Anmut und Weisheit aus?";
        }
    }
    public static string Owl_Dialog_Quiz3_2_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Eine weise, kluge und - leider auch - falsche Antwort. Nein, die Eulen liebt er nicht. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Eine weise, kluge und - leider auch - falsche Antwort. Nein, die Eulen liebt er nicht. Melde dich, wenn du es nochmal versuchen willst.";
        }
    }
    public static string Owl_Dialog_Quiz3_3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Fisch muss es sein! Nervt nicht rum, schwimmt sinnlos im Kreis und hält die Klappe. Das ideale Tier für Meister Gunnar.";
            else
                return "Der Fisch muss es sein! Nervt nicht rum, schwimmt sinnlos im Kreis und hält die Klappe. Das ideale Tier für Meister Gunnar.";
        }
    }
    public static string Owl_Dialog_Quiz3_2_2_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Der Fisch passt ganz gut aufs Profil, aber andere Kreaturen passen eben noch besser. Nein, die Fische liebt er nicht. Melde dich, wenn du es nochmal versuchen willst.";
            else
                return "Der Fisch passt ganz gut aufs Profil, aber andere Kreaturen passen eben noch besser. Nein, die Fische liebt er nicht. Melde dich, wenn du es nochmal versuchen willst.";
        }
    }
    public static string Owl_Dialog_Quiz3_4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Das Quietscheentchen! Wo wurde jemals soviel reine Liebe entdeckt wie zwischen einem Mann und seinem Quietscheentchen?";
            else
                return "Das Quietscheentchen! Wo wurde jemals soviel reine Liebe entdeckt wie zwischen einem Mann und seinem Quietscheentchen?";
        }
    }
    public static string Owl_Dialog_Quiz3_4_2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Wusstest du, dass Menschen mir Angst machen? Ja, die Antwort ist richtig. Herzlichen Glückwunsch. Der Weg ist frei.";
            else
                return "Wusstest du, dass Menschen mir Angst machen? Ja, die Antwort ist richtig. Herzlichen Glückwunsch. Der Weg ist frei.";
        }
    }
    public static string Owl_Dialog_Ende
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich geh dann mal Eulen nach Athen tragen.";
            else
                return "Ich geh dann mal Eulen nach Athen tragen.";
        }
    }
    public static string Owl_Library_Door
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es summte vernehmlich, und dann klackte irgendein Mechanismus in der Bibliothekstür.";
            else
                return "Es summte vernehmlich, und dann klackte irgendein Mechanismus in der Bibliothekstür.";
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
                return "Buch zuklappen.";
        }
    }
    public static string Book_Dialog_Start
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich schlug das Buch auf. Auf der rechten Seite befand sich das Inhaltsverzeichnis. Von der linken Seite grinste mich der schmierige Meister Gunnar an.";
            else
                return "Ich schlug das Buch auf. Auf der rechten Seite befand sich das Inhaltsverzeichnis. Von der linken Seite grinste mich der schmierige Meister Gunnar an.";
        }
    }
    public static string Book_Dialog_Gunnar
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Über Meister Gunnar";
            else
                return "Über Meister Gunnar";
        }
    }
    public static string Book_Dialog_Gunnar2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Dieses Kapitel berichtete gewohnt bescheiden über Meister Gunnar: Meistermagier, brillianter Wissenschaftler, Sexgott... Daneben prangte eine sehr lebensechte, aber unfassbar schmierige Lithografie von Meister Gunnar. Ich ließ das Buch sinken und holte erst mal kräftig Luft.";
            else
                return "Dieses Kapitel berichtete gewohnt bescheiden über Meister Gunnar: Meistermagier, brillianter Wissenschaftler, Sexgott... Daneben prangte eine sehr lebensechte, aber unfassbar schmierige Lithografie von Meister Gunnar. Ich ließ das Buch sinken und holte erst mal kräftig Luft.";
        }
    }
    public static string Book_Dialog_Teleports
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Über Kurzstreckenteleports";
            else
                return "Über Kurzstreckenteleports";
        }
    }
    public static string Book_Dialog_Teleports2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die wichtigsten Hardfacts über Kurzstreckenteleports!<br>Man benötigt 3 Zutaten, erhitze diese, bis sie zu Schlacke verbrennen, zerreibe diese dann zu Pulver und entzünde dies. Und dann: \"Kabumm!\"<br>Die Zutaten sind:<br>- Ein Mondstein<br>- eine goldene Münze<br>- ein Wunderwarzenschwamm<br>Na, das klang ja fast machbar. War das mein Ticket aus diesem vermaledeiten Versteck?";
            else
                return "Die wichtigsten Hardfacts über Kurzstreckenteleports!<br>Man benötigt 3 Zutaten, erhitze diese, bis sie zu Schlacke verbrennen, zerreibe diese dann zu Pulver und entzünde dies. Und dann: \"Kabumm!\"<br>Die Zutaten sind:<br>- Ein Mondstein<br>- eine goldene Münze<br>- ein Wunderwarzenschwamm<br>Na, das klang ja fast machbar. War das mein Ticket aus diesem vermaledeiten Versteck?";
        }
    }
    public static string Book_Dialog_Sextips
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die neuesten heißen Sextips";
            else
                return "Die neuesten heißen Sextips";
        }
    }
    public static string Book_Dialog_Sextips2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "'Magie ist nicht nur ein sehr gutes Aphrodisaikum, sondern auch sonst beflügelnd für alle Spielarten des Matratzensports. Wenn Sie den perfekten Liebhaber suchen...'<br>Ich ließ das Buch sinken und starrte ein paar Sekunden einfach nur ins Nichts.";
            else
                return "'Magie ist nicht nur ein sehr gutes Aphrodisaikum, sondern auch sonst beflügelnd für alle Spielarten des Matratzensports. Wenn Sie den perfekten Liebhaber suchen...'<br>Ich ließ das Buch sinken und starrte ein paar Sekunden einfach nur ins Nichts.";
        }
    }
    public static string Book_Dialog_Mondsteine
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Über die Herstellung von Mondsteinen";
            else
                return "Über die Herstellung von Mondsteinen";
        }
    }

    public static string Book_Dialog_Mondsteine2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Die Herstellung von Mondsteinen ist dank meiner Erfindung der Dunkelheitsmaschine fast ein Kinderspiel geworden. Man nehme einen gewöhnlichen Kiesel und entziehe ihm mit meiner neuartigen Erfindung jegliches Licht. Zurück bleibt ein Stein, der vollkommen lichtlos ist und der unfassbare Schwärze ausstrahlt. Das einzige, was ihn nun dazu bewegen kann, sich noch einmal mit Licht anzureichern, ist helles, konzentriertes Mondlicht. Dazu muss man allerdings möglichst nah an den Mond heran. Für dieses Problem habe ich noch keine gute Lösung gefunden, aber Ihnen fällt schon was ein! Wie man hört, können manche Vögel sehr hoch fliegen. Vielleicht reicht das ja schon, um den Stein ausreichend nah ans Mondlicht heran zu bringen.";
            else
                return "Die Herstellung von Mondsteinen ist dank meiner Erfindung der Dunkelheitsmaschine fast ein Kinderspiel geworden. Man nehme einen gewöhnlichen Kiesel und entziehe ihm mit meiner neuartigen Erfindung jegliches Licht. Zurück bleibt ein Stein, der vollkommen lichtlos ist und der unfassbare Schwärze ausstrahlt. Das einzige, was ihn nun dazu bewegen kann, sich noch einmal mit Licht anzureichern, ist helles, konzentriertes Mondlicht. Dazu muss man allerdings möglichst nah an den Mond heran. Für dieses Problem habe ich noch keine gute Lösung gefunden, aber Ihnen fällt schon was ein! Wie man hört, können manche Vögel sehr hoch fliegen. Vielleicht reicht das ja schon, um den Stein ausreichend nah ans Mondlicht heran zu bringen.";
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
                return "Ich finde alleine raus, danke.";
        }
    }
    public static string Lib_Dialog_Start_Long
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Na, das war ja mal wieder an der Zeit. Wahrscheinlich bin ich die Letzte, die hier wiederbelebt worden ist. Wo ist eigentlich Meister Gunnar? Er steht doch sonst mehr auf diese jungen, hübschen...";
            else
                return "Na, das war ja mal wieder an der Zeit. Wahrscheinlich bin ich die Letzte, die hier wiederbelebt worden ist. Wo ist eigentlich Meister Gunnar? Er steht doch sonst mehr auf diese jungen, hübschen...";
        }
    }
    public static string Lib_Dialog_Start_Long2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Hey, ich habe auch Gefühle! Also mal bitte Ruhe. Und Meister Gunnar ist nicht da. Ist das ein Problem für dich?";
            else
                return "Hey, ich habe auch Gefühle! Also mal bitte Ruhe. Und Meister Gunnar ist nicht da. Ist das ein Problem für dich?";
        }
    }
    public static string Lib_Dialog_Start_Long3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ganz im Gegenteil! Es ist geradezu... Nun, kommen wir zum Thema. Was kann ich für dich tun?";
            else
                return "Ganz im Gegenteil! Es ist geradezu... Nun, kommen wir zum Thema. Was kann ich für dich tun?";
        }
    }

    public static string Lib_Dialog_Start_Short
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, was kann ich für dich tun?";
            else
                return "Nun, was kann ich für dich tun?";
        }
    }
    public static string Lib_Dialog_Belebung
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was ist das für ein Gefühl für dich, von dieser Klaue belebt zu werden?";
            else
                return "Was ist das für ein Gefühl für dich, von dieser Klaue belebt zu werden?";
        }
    }
    public static string Lib_Dialog_Belebung2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Es ist ... nun... unglaublich... seltsam. Ich weiß gar nicht, ob es dir aufgefallen ist. Aber ich bin eigentlich tot!";
            else
                return "Es ist ... nun... unglaublich... seltsam. Ich weiß gar nicht, ob es dir aufgefallen ist. Aber ich bin eigentlich tot!";
        }
    }
    public static string Lib_Dialog_Belebung3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Verdammt, jetzt wo du es sagst! Das ist ja unglaublich!";
            else
                return "Verdammt, jetzt wo du es sagst! Das ist ja unglaublich!";
        }
    }
    public static string Lib_Dialog_Belebung4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Genau. Und dank der Klaue fühle ich mich einfach jung und frisch wie am ersten Tag.";
            else
                return "Genau. Und dank der Klaue fühle ich mich einfach jung und frisch wie am ersten Tag.";
        }
    }
    public static string Lib_Dialog_Klaue
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Was weißt du über die Klaue?";
            else
                return "Was weißt du über die Klaue?";
        }
    }
    public static string Lib_Dialog_Klaue2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Nun, sie wird urkundlich zum ersten mal im Jahr 1487 in den Aufzeichnungen des Grafen von Grafenhausen erwähnt und...";
            else
                return "Nun, sie wird urkundlich zum ersten mal im Jahr 1487 in den Aufzeichnungen des Grafen von Grafenhausen erwähnt und...";
        }
    }
    public static string Lib_Dialog_Klaue3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ich könnte schwören, über dieses tolle Juwel gibts sicher auch noch weit spannendere Details zu berichten...";
            else
                return "Ich könnte schwören, über dieses tolle Juwel gibts sicher auch noch weit spannendere Details zu berichten...";
        }
    }
    public static string Lib_Dialog_Klaue4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ja, kann sein. Hab ich dich gelangweilt? Das passiert mir leider öfters.";
            else
                return "Ja, kann sein. Hab ich dich gelangweilt? Das passiert mir leider öfters.";
        }
    }

    public static string Lib_Dialog_Buecher
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Du hast hier ja schon sehr gefährliche Bücher, kann das sein?";
            else
                return "Du hast hier ja schon sehr gefährliche Bücher, kann das sein?";
        }
    }
    public static string Lib_Dialog_Buecher2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Gefährlich? Ach, soweit würde ich nicht gehen. Manche sind sehr temperamentvoll, das stimmt natürlich. Mehrere von ihnen töten natürlich gerne ihre Leser...";
            else
                return "Gefährlich? Ach, soweit würde ich nicht gehen. Manche sind sehr temperamentvoll, das stimmt natürlich. Mehrere von ihnen töten natürlich gerne ihre Leser...";
        }
    }
    public static string Lib_Dialog_Buecher3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... natürlich. Wer kann es ihnen verdenken?";
            else
                return "... natürlich. Wer kann es ihnen verdenken?";
        }
    }
    public static string Lib_Dialog_Buecher4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "... und außerdem enthalten sie ein wahnsinniges Wissen, das natürlich schon wieder so wahnsinnig ist, dass außer Meister Gunnar ohnehin niemand etwas mit diesen Büchern anfangen kann.";
            else
                return "... und außerdem enthalten sie ein wahnsinniges Wissen, das natürlich schon wieder so wahnsinnig ist, dass außer Meister Gunnar ohnehin niemand etwas mit diesen Büchern anfangen kann.";
        }
    }
    public static string Lib_Dialog_Leihfrist
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Dass man geköpft und gevierteilt wird, wenn man in einer Bibliothek die Leihfrist überschreitet - das ist aber ein Ammenmärchen, oder?";
            else
                return "Dass man geköpft und gevierteilt wird, wenn man in einer Bibliothek die Leihfrist überschreitet - das ist aber ein Ammenmärchen, oder?";
        }
    }
    public static string Lib_Dialog_Leihfrist2
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ach das... klar, das stimmt natürlich so nicht.";
            else
                return "Ach das... klar, das stimmt natürlich so nicht.";
        }
    }
    public static string Lib_Dialog_Leihfrist3
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Da bin ich ja erleichtert. Es kam mir immer ganz schön übertrieben vor.";
            else
                return "Da bin ich ja erleichtert. Es kam mir immer ganz schön übertrieben vor.";
        }
    }
    public static string Lib_Dialog_Leihfrist4
    {
        get
        {
            if (_gd!.Language == IGlobalData.language.german)
                return "Ach ja? Mir nicht! In Wirklichkeit wird einem bei lebendigem Leibe die Haut abgezogen und der geschundene Leib häppchenweise frittiert. Ha, nimm das, Leihfristüberziehungsübeltäter!";
            else
                return "Ach ja? Mir nicht! In Wirklichkeit wird einem bei lebendigem Leibe die Haut abgezogen und der geschundene Leib häppchenweise frittiert. Ha, nimm das, Leihfristüberziehungsübeltäter!";
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
                return "Nun, ein weiser alter Mann, dessen Vorliebe für blutjunge Gespielinnen durchaus größer ausgeprägt ist als die Vorliebe blutjunger Gespielinnen für alte verwelkte Zauberer. Darüber hinaus ist er ein passabler Zauberer.";
            else
                return "Nun, ein weiser alter Mann, dessen Vorliebe für blutjunge Gespielinnen durchaus größer ausgeprägt ist als die Vorliebe blutjunger Gespielinnen für alte verwelkte Zauberer. Darüber hinaus ist er ein passabler Zauberer.";
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
                return "Wenn es so wäre, würde ich es einem Fremden niemals gestehen! Ich würde davon berichten, dass es immer schon mein Traum war, mit Holzwolle ausgestopft herum zu liegen und die Vergänglichkeit des Daseins zu zelebrieren. Zum Glück krieege ich ja die meiste Zeit davon gar nichts mit.";
            else
                return "Wenn es so wäre, würde ich es einem Fremden niemals gestehen! Ich würde davon berichten, dass es immer schon mein Traum war, mit Holzwolle ausgestopft herum zu liegen und die Vergänglichkeit des Daseins zu zelebrieren. Zum Glück krieege ich ja die meiste Zeit davon gar nichts mit.";
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
                return "Ich warf den Papageien in den Himmel. Er flog hoch hinauf und verschwand bald ganz aus meinem Blick.<br>Ich wartete und wartete, aber der Papagei kam nicht zurück.<br>Doch da, plötzlich, sah ich ihn herabsinken, in seinem Schnabel einen glimmenden Stein. Ein Mondstein! Er hatte es tatsächlich geschafft. Er sank herab und landete auf meinem Arm. Bereitwillig ließ er den Mondstein in meine offene fallen.<br>\"Das war fürwahr eine wundervolle Reise. So nah war ich dem Mond noch nie\" seufzte der Papagei, mal ganz ohne Mikroagressionen.";
            else
                return "Ich warf den Papageien in den Himmel. Er flog hoch hinauf und verschwand bald ganz aus meinem Blick.<br>Ich wartete und wartete, aber der Papagei kam nicht zurück.<br>Doch da, plötzlich, sah ich ihn herabsinken, in seinem Schnabel einen glimmenden Stein. Ein Mondstein! Er hatte es tatsächlich geschafft. Er sank herab und landete auf meinem Arm. Bereitwillig ließ er den Mondstein in meine offene fallen.<br>\"Das war fürwahr eine wundervolle Reise. So nah war ich dem Mond noch nie\" seufzte der Papagei, mal ganz ohne Mikroagressionen.";
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
                return "Das ist ja bretthart und ungenießbar! Ich kann dir höchstens einen schönen, polierten Stein dafür anbieten!";
            else
                return "Das ist ja bretthart und ungenießbar! Ich kann dir höchstens einen schönen, polierten Stein dafür anbieten!";
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
                return "Würdest du für mich in einen Brunnen tauchen und dort eine schimmernde Münze vom Grund aufnehmen.";
            else
                return "Würdest du für mich in einen Brunnen tauchen und dort eine schimmernde Münze vom Grund aufnehmen.";
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
                return "Die Ritterrüstung nahm Anlauf und rannte dann brüllend auf die Tür des meisterlichen Schlafgemachs zu - und krachte schließlich gegen die solide Tür, die prompt aus den Angeln flog. Die Ritterrüstung rappelte sich auf, hängte etwas betreten die Tür wieder ein und kehrte an ihren Platz zurück. \"Ah, das tat gut!\"";
            else
                return "Die Ritterrüstung nahm Anlauf und rannte dann brüllend auf die Tür des meisterlichen Schlafgemachs zu - und krachte schließlich gegen die solide Tür, die prompt aus den Angeln flog. Die Ritterrüstung rappelte sich auf, hängte etwas betreten die Tür wieder ein und kehrte an ihren Platz zurück. \"Ah, das tat gut!\"";
        }
    }
}


 
