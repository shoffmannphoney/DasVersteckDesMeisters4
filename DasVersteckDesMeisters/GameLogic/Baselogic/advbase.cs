using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Text;
using System.Reflection;
using System.Security.Cryptography;
using System.Collections;

using Phoney_MAUI.Model;
using Phoney_MAUI.Core;

namespace GameCore
{

    [Serializable]

    public class AdvData
    {
        [JsonIgnore]
        public GlobalData? GD
        {
            get => GlobalData.CurrentGlobalData;
            // set => GlobalData.CurrentGlobalData = value;
        }
        [JsonIgnore]
        public Adv? Adventure
        {
            get => GD!.Adventure!;

        }

        int _actLoc;

        public int ActLoc 
        { 
            get => _actLoc;
            set
            {
                bool _layoutRefresh = false;
                if( _actLoc != value )
                {
                    _layoutRefresh = true;
                }
                _actLoc = value;
                if( _layoutRefresh == true )
                {
                    Adventure?.Orders?.LayoutRefresh();
                }
            }
        }

        public int ActPerson { get; set; }

        public int ActScore { get; set; }

        public int MaxScore { get; set; }

        public int StartLoc { get; set; }



        public int Difficulty_Easy = 1;

        public int Difficulty_Medium = 2;

        public int Difficulty_Heavy = 3;

        public enum picSize { none, small, medium, large }

        public picSize PicSize { get; set; } = picSize.none;


        /*
        public int P_Everyone = 0;
        public int P_Self = 2;
        public int P_You = 1;
        public int P_I = 2;
        public int P_3rdperson = 3;
        public int P_Helfie = 4;
        public int P_Dolly = 5;
        public int P_Stealthy_Steven = 6;
        public int P_Phoney = 25;
        public int P_Ghoul = 26;
        public int P_Scaramango = 27;
        public int P_Brueckenwache = 28;
        */
        /*
        public int P_Robot = 5;
        public int P_Sven = 6;
        public int P_Papagei = 7;
        public int P_Eremit = 8;
        public int P_Kobra = 9;
        public int P_Frank_Cannon = 10;
        public int P_Lagerverwalter = 11;
        public int P_Ahab = 12;
        public int P_Schankwirt = 13;
        public int P_Marineoffizier = 14;
        public int P_Redakteur = 15;
        public int P_Fescher_Pit = 16;
        public int P_Arzt = 17;
        public int P_Mechaniker = 18;
        public int P_Handelsvertreter = 19;
        public int P_Baeuerin = 20;
        public int P_Dennis = 21;
        public int P_Kuh = 22;
        public int P_Beamter = 23;
        public int P_Pferd = 24;
        */


        public int Cat_Eatable = 1;

        public int Cat_Tasteable = 2;

        public int Cat_Smellable = 3;

        public int Cat_Readable = 4;

        public int Cat_Fillable = 5;

        public int Cat_GoThroughable = 6;

        public int Cat_GoToable = 7;

        public int Cat_Climbable = 8;

        public int Cat_Climbupable = 9;

        public int Cat_Climbdownable = 10;

        public int Cat_Usable = 11;

        public int Cat_UsableWith = 12;

        public int Cat_Throwable = 13;

        public int Cat_Pullable = 14;

        public int Cat_Pushable = 15;

        public int Cat_PushableTo = 16;

        public int Cat_Waste = 17;

        public int Cat_Giveable = 18;

        public int Cat_Questionable = 19;

        public int Cat_Untightenable = 20;

        public int Cat_Breakable = 21;

        public int Cat_Cutable = 22;

        public int Cat_Tieable = 23;

        public int Cat_Fishable = 24;

        public int Cat_Enlightable = 25;

        public int Cat_Extinguishable = 26;

        public int Cat_Grabable = 27;

        public int Cat_Sellable = 28;

        public int Cat_Pickable = 29;

        public int Cat_Catcheable = 30;

        public int Cat_Unlockable = 31;

        public int Cat_Takeable = 32;       // via Item-Flags

        public int Cat_Enterable = 33;

        public int Cat_Examinable = 34;       // jedes item und jede Person ist examinable

        public int Cat_ExamineInable = 35;       // abhängig von Flag canPutIn

        public int Cat_ExamineOnable = 36;       // abhängig von Flag canPutOn

        public int Cat_ExamineBelowable = 37;       // abhängig von Flag canPutBelow

        public int Cat_ExamineBehindable = 38;       // abhängig von Flag canPutBehind

        public int Cat_ExamineBesideable = 39;       // abhängig von Flag canPutBeside

        public int Cat_Dropable = 40;       // Wie Takeable

        public int Cat_Openable = 41;       // abhängig von Flag canBeClosed

        public int Cat_Closeable = 42;       // abhängig von Flag canBeClosed

        public int Cat_TakeOutable = 43;       // via Item-Flags

        public int Cat_TakeFromable = 44;       // via Item-Flags

        public int Cat_TakeFromBehindable = 45;       // via Item-Flags

        public int Cat_TakeFromBesideable = 46;       // via Item-Flags

        public int Cat_TakeFromBelowable = 47;       // via Item-Flags

        public int Cat_PutInable = 48;       // via Item-Flags

        public int Cat_PutOnable = 49;       // via Item-Flags

        public int Cat_PutBehindable = 50;       // via Item-Flags

        public int Cat_PutBesideable = 51;       // via Item-Flags

        public int Cat_PutBelowable = 52;       // via Item-Flags

        public int Cat_Talkable = 53;

        public int Cat_Pleaable = 54;

        public int Cat_Demandable = 55;

        public int Cat_Drinkable = 56;

        public int Cat_Touchable = 57;

        public int Cat_Lockable = 58;

        public int Cat_Knockable = 59;

        public int Cat_Listenable = 60;

        public int Cat_Arrestable = 61;

        public int Cat_Pressable = 62;

        public int Cat_ArrestableWith = 63;

        public int Cat_Showable = 64;


        public int Cat_Turnable = 65;

        public int Cat_Fotographable = 66;

        public int Cat_Paintable = 67;

        public int Cat_Smearable = 68;

        public int Cat_Wrapable = 69;

        public int Cat_Cleanable = 70;

        public int Cat_Repairable = 71;

        public int Cat_Feedable = 72;

        public int Cat_Sitable = 73;

        public int Cat_Sleepable = 74;

        public int Cat_Sortable = 75;

        public int Cat_Spittable = 76;

        public int Cat_Swimable = 77;

        public int Cat_Tipable = 78;

        public int Cat_CleanableWith = 79;

        public int Cat_Digable = 80;

        public int Cat_Searchable = 81;

        public int Cat_Buyable = 82;

        public int Cat_Dressable = 83;

        public int Cat_Pokeable = 84;

        public int Cat_Attachable = 85;

        public int Cat_Punctureable = 86;

        public int Cat_Dipable = 88;

        public int Cat_Meditateable = 89;

        public int Cat_Wearable = 90;

        public int Cat_Waterable = 91;

        public int Cat_Mixable = 92;

        public int Cat_Sawable = 93;

        public int Cat_Suckable = 94;

        public int Cat_FillableWith = 95;

        public int Cat_CuttableWith = 96;

        public int Cat_Crackable = 97;

        public int Cat_Breathable = 98;

        public int Cat_Smokeable = 99;

        public int Cat_Leaveable = 100;

        public int Cat_Stealable = 101;

        public int Cat_Countable = 102;

        public int Cat_Playable = 103;

        public int Cat_Typeable = 104;

        public int Cat_Tearable = 105;

        public int Cat_TipInable = 106;

        public int Cat_Mountable = 107;

        public int Cat_Parkable = 108;

        public int Cat_DrawOffable = 109;

        public int Cat_ClimbInable = 110;

        public int Cat_UseKamerable = 111;

        public int Cat_Freeable = 112;

        public int Cat_Polishable = 113;

        public int Cat_Unwearable = 114;

        public int Cat_Undressable = 115;

        public int Cat_Followable = 116;
        public int Cat_Illuminated = 117;
        public int Cat_Grabintoable= 118;

        public int Cat_TakeWith = 119;
        public int Cat_Wraparoundable = 120;
        public int Cat_Touchwithable = 121;
        public int Cat_Readwithable = 122;
        public int Cat_Heatable = 123;
        public int Cat_Lightable = 124;
        public int Cat_Pulverizable = 125;

        public int CounterCat_Fill = 1001;

        public int CounterCat_UsableWith = 1002;

        public int CounterCat_ThrowTarget = 1003;

        public int CounterCat_PushTarget = 1004;

        public int CounterCat_GiveTarget = 1005;

        public int CounterCat_QuestionTarget = 1006;

        public int CounterCat_Knife = 1007;

        public int CounterCat_TieTarget = 1008;

        public int CounterCat_FishingRod = 1009;

        public int CounterCat_Lighter = 1010;

        public int CounterCat_Grabber = 1011;

        public int CounterCat_SellTarget = 1012;

        public int CounterCat_PickTarget = 1013;

        public int CounterCat_Key = 1014;

        public int CounterCat_TakeOutable = 1015;
        public int CounterCat_TakeFromable = 1016;
        public int CounterCat_TakeFromBehindable = 1017;
        public int CounterCat_TakeFromBesideable = 1018;
        public int CounterCat_TakeFromBelowable = 1019;

        public int CounterCat_PutInable = 1020;

        public int CounterCat_PutOnable = 1021;

        public int CounterCat_PutBehindable = 1022;

        public int CounterCat_PutBesideable = 1023;

        public int CounterCat_PutBelowable = 1024;

        public int CounterCat_ArrestTarget = 1025;

        public int CounterCat_FotoTarget = 1026;

        public int CounterCat_PaintTool = 1027;

        public int CounterCat_SmearTarget = 1028;

        public int CounterCat_WrapTarget = 1029;

        public int CounterCat_FotoTool = 1030;

        public int CounterCat_FeedTarget = 1031;

        public int CounterCat_TipTarget = 1032;

        public int CounterCat_CleanTool = 1033;

        public int CounterCat_PokeTarget = 1034;

        public int CounterCat_AttachTarget = 1035;

        public int CounterCat_PunctureTool = 1036;

        public int CounterCat_DipTool = 1038;

        public int CounterCat_WaterTool = 1039;

        public int CounterCat_MixTarget = 1040;

        public int CounterCat_SawTool = 1041;

        public int CounterCat_FillTool = 1042;

        public int CounterCat_CutTool = 1043;

        public int CounterCat_MountTool = 1044;

        public int CounterCat_PolishTool = 1045;

        public int CounterCat_ShowTarget = 1046;

        public int CounterCat_TakeWith_Tool = 1047;

        public int CounterCat_Wraparound_Tool = 1048;
        public int CounterCat_TouchWith_Tool = 1049;
        public int CounterCat_Read_Tool = 1050;
        public int CounterCat_Heater = 1051;
        public int CounterCat_Pulverizer = 1052;

        public bool Finish = false;

        public int Tense { get; set; }
        int difficulty = 3;


        public int Difficulty
        {
            get
            {
                return difficulty;
            }
            set
            {
                if ((value >= 1) && (value <= 3))
                    this.difficulty = value;
            }
        }


        private string SubString(string s, int Pos, int Len)
        {

            string SubString = "";
            if (Pos < s.Length)
            {
                if (Pos + Len > s.Length)
                {
                    Len = s.Length - Pos;
                }
                SubString = s.Substring(Pos, Len);
            }
            return (SubString);
        }


        public string GetConvertedText(string Description)
        {
            /*
            int i, j, k;

            string zwString = "";
            for (i = 0; i < Description.Length; i++)
            {
                if (Description[i] == '<')
                {
                    bool found = false;

                    if (SubString(Description, i, 4) == "<br>")
                    {
                        i += 3;
                        zwString += "<br>";
                    }
                    else if (SubString(Description, i, 6) == "<Item:")
                    {
                        int l;
                        for (l = i + 6; l < Description.Length; l++)
                        {
                            if (Description[l] == '>')
                                break;
                        }
                        int itemID = Int32.Parse(Description.Substring(i + 6, l - i - 6));
                        for (k = l + 1; k < Description.Length; k++)
                        {
                            if ((Description[k] == '<') && (Description[k + 1] == '/') && (Description[k + 2] == 'I'))
                            {
                                // string ItemName = GetLocName(Description.Substring(i + 12, k - i - 12));
                                string ItemName = GetConvertedText(Description.Substring(l + 1, k - l - 1));

                                i = k + 6;
            // Ignores: 005
                                zwString = zwString + "<a style=\"cursor:pointer\" class=\"class1\" onclick=\"window.external.JSCallback('Item: " $"{itemID:00000}');\"></a>";
            // Ignores: 002
                                // zwString = zwString + "<a href=\"https:www.spiegel.de\" class=\"class1\">Link</a>";
            // Ignores: 005
                                // ZwString = ZwString + "<a href=\"#\" onclick=\"window.clipboardData.setData( 'Text', 'Item: " + $"{itemID:00000}" + "' );\">" + ItemName + "</a>";
                                found = true;
                            }
                            if (found) break;
                        }
                    }
                    else if (SubString(Description, i, 5) == "<Dir:")
                    {
                        int l;
                        for (l = i + 5; l < Description.Length; l++)
                        {
                            if (Description[l] == '>')
                                break;
                        }
                        int dirID = Int32.Parse(Description.Substring(i + 5, l - i - 5));
                        for (k = l + 1; k < Description.Length; k++)
                        {
                            if ((Description[k] == '<') && (Description[k + 1] == '/') && (Description[k + 2] == 'D'))
                            {
                                // string Linktext = GetLocName(Description.Substring(i + 11, k - i - 11));
                                string Linktext = GetConvertedText(Description.Substring(l + 1, k - l - 1));
                                i = k + 5;
            // Ignores: 005
                                // ZwString = ZwString + "<a href=\"#\" onclick=\"ToClip( 'Dir: " + $"{DirID:00000}" + "' );\">" + Linktext + "</a>";
            // Ignores: 005
                                // zwString = zwString + "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('Dir: " + $"{dirID:00000}" + "');\">" + Linktext + "</a>";

                                zwString = zwString + Linktext;

                                found = true;
                            }
                            if (found) break;
                        }
                    }
                    else if (SubString(Description, i, 5) == "<Loc:")
                    {
                        int l;
                        for (l = i + 5; l < Description.Length; l++)
                        {
                            if (Description[l] == '>')
                                break;
                        }
                        int locID = Int32.Parse(Description.Substring(i + 5, l - i - 5));
                        for (k = i + 10; k < Description.Length; k++)
                        {
                            if ((Description[k] == '<') && (Description[k + 1] == '/') && (Description[k + 2] == 'L'))
                            {
                                // string Linktext = GetLocName(Description.Substring(i + 11, k - i - 11));
                                string Linktext = GetConvertedText(Description.Substring(l + 1, k - l - 1));
                                i = k + 5;
            // Ignores: 004
                                // zwString = zwString + "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('Loc: " + $"{locID:00000}" + "');\">" + Linktext + "</a>";
            // Ignores: 004
                                zwString = zwString + "<a style=\"cursor:pointer\" class=\"class2\" onclick=\"window.external.JSCallback('Loc: " $"{locID:00000}');\"></a>";
                                // zwString = zwString + Linktext;

                                found = true;
                            }
                            if (found) break;
                        }
                    }
                    else if (SubString(Description, i, 10) == "<AP_AKK_C>")
                    {
                        string persName = "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('ActPerson');\">" +Adventure!.FirstUpper(Adventure!.Persons!.GetPersonName(Adventure!.Persons!.Find(ActPerson), Co.CASE_AKK)) + "</a>";
                        zwString = zwString + persName;
                        i = i + 9;
                    }
                    else if (SubString(Description, i, 8) == "<AP_AKK>")
                    {
                        string persName = "<a style=\"cursor:pointer\"vonclick=\"window.external.JSCallback('ActPerson');\">" +Adventure!.Persons!.GetPersonName(Adventure!.Persons!.Find(ActPerson), Co.CASE_AKK) + "</a>";
                        // string PersName = GetPersonName(A!.ActPerson, Co.CASE_AKK);

                        zwString = zwString + persName;
                        i = i + 7;
                    }
                    else if (SubString(Description, i, 8) == "<APVTPr:")
                    {
                        bool found2 = false;

                        j = i + 8;
                        for (; j < Description.Length; j++)
                        {
                            if (Description[j] == '>')
                            {
                                string s = Description.Substring(i + 8, j - i - 8);
                                for (k = 0; k < Adventure!.VerbTenses.List.Count; k++)
                                {
                                    if (s == Adventure!.VerbTenses.List[k].VerbNameTense[0])
                                    {
                                        zwString = zwString + Grammar.GetVerbDeclination(Adventure!.VerbTenses.List[k].ID, Adventure!.Persons!.Find(ActPerson), Tense);
                                        found2 = true;
                                    }
                                    if (found2) break;
                                }
                            }
                            if (found2) break;
                        }
                        i = j;
                    }
                    else if (SubString(Description, i, 8) == "<APVTPa:")
                    {
                        bool found2 = false;

                        j = i + 8;
                        for (; j < Description.Length; j++)
                        {
                            if (Description[j] == '>')
                            {
                                string s = SubString(Description, i + 8, j - i - 8);
                                for (k = 0; k < Adventure!.VerbTenses.List.Count; k++)
                                {
                                    if (s == Adventure!.VerbTenses.List[k].VerbNameTense[0])
                                    {
                                        zwString = zwString + Grammar.GetVerbDeclination(Adventure!.VerbTenses.List[k].ID, Adventure!.Persons!.Find(ActPerson), Adventure!.CB!.Tense_Past);
                                        found2 = true;
                                    }
                                    if (found2) break;
                                }
                            }
                            if (found2) break;
                        }
                        i = j;
                    }
                    else
                        zwString = zwString + Description[i];
                }
                else
                    zwString = zwString + Description[i];
            }
            return (zwString);
            */
            int i, j, k;

            StringBuilder zwString = new StringBuilder();
            for (i = 0; i < Description.Length; i++)
            {
                if (Description[i] == '<')
                {
                    bool found = false;

                    // Noloca: 022
                    if (SubString(Description, i, 4) == "<br>")
                    {
                        i += 3;
                        zwString.Append("<br>");
                    }
                    else if (SubString(Description, i, 5) == "<br/>")
                    {
                        i += 4;
                        zwString.Append("<br/>");
                    }
                    else if (SubString(Description, i, 6) == "<Item:")
                    {
                        int l;
                        for (l = i + 6; l < Description.Length; l++)
                        {
                            if (Description[l] == '>')
                                break;
                        }
                        int itemID = Int32.Parse(Description.Substring(i + 6, l - i - 6));
                        for (k = l + 1; k < Description.Length; k++)
                        {
                            if ((Description[k] == '<') && (Description[k + 1] == '/') && (Description[k + 2] == 'I'))
                            {
                                // string ItemName = GetLocName(Description.Substring(i + 12, k - i - 12));
                                string ItemName = GetConvertedText(Description.Substring(l + 1, k - l - 1));

                                i = k + 6;
                                // Ignores: 001
                                // zwString.Append( "<a style=\"cursor:pointer\" class=\"class1\" onclick=\"Test22(1)\">" + ItemName + "</a>");
#if CHROMIUM
                                // Noloca: 002
                                string scr = System.Web.HttpUtility.HtmlEncode("boundAsync.JSCallback(\"Item: " + $"{itemID:00000}\");");
                                // Ignores: 004
                                // Noloca: 004
                                zwString.Append("<a style='cursor:pointer' class='class1' onclick='" + scr + "'>" + ItemName + "</a>");
                                // zwString.Append( "<a style=\"cursor:pointer\" class=\"class1\" onclick=\"boundAsync.JSCallback(\"Item: " + $"{itemID:00000}" + "\");\">" + ItemName + "</a>");
#elif MAUI
                                // Noloca: 002
                                string scr = System.Web.HttpUtility.HtmlEncode("window.location.href = 'https://defineobject.Item/" + $"{itemID:00000}';");
                                // Ignores: 004
                                // Noloca: 004
                                zwString.Append("<a style='cursor:pointer' class='class1' onclick='" + scr + "'>" + ItemName + "</a>");
                                // zwString.Append( "<a style=\"cursor:pointer\" class=\"class1\" onclick=\"boundAsync.JSCallback(\"Item: " + $"{itemID:00000}" + "\");\">" + ItemName + "</a>");
#else
                                // Noloca: 002
                               zwString.Append( "<a style=\"cursor:pointer\" class=\"class1\" onclick=\"window.external.JSCallback('Item: " + $"{itemID:00000}');\"></a>");
#endif
                                // CEFTEST
                                // zwString.Append( "<a style=\"cursor:pointer\" class=\"class1\" onclick=\"alert('Huhu', 'Schubidu');\">" + ItemName + "</a>");
                                // zwString = zwString + "<a style=\"cursor:pointer\" class=\"class1\" onclick=\"window.external.JSCallback('Item: " + $"{itemID:00000}" + "');\">" + ItemName + "</a>";
                                // zwString = zwString + "<a href=\"https:www.spiegel.de\" class=\"class1\">Link</a>";
                                // ZwString = ZwString + "<a href=\"#\" onclick=\"window.clipboardData.setData( 'Text', 'Item: " + $"{itemID:00000}" + "' );\">" + ItemName + "</a>";
                                found = true;
                            }
                            if (found) break;
                        }
                    }
                    // Noloca: 001
                    else if (SubString(Description, i, 5) == "<Dir:")
                    {
                        int l;
                        for (l = i + 5; l < Description.Length; l++)
                        {
                            if (Description[l] == '>')
                                break;
                        }
                        int dirID = Int32.Parse(Description.Substring(i + 5, l - i - 5));
                        for (k = l + 1; k < Description.Length; k++)
                        {
                            if ((Description[k] == '<') && (Description[k + 1] == '/') && (Description[k + 2] == 'D'))
                            {
                                // string Linktext = GetLocName(Description.Substring(i + 11, k - i - 11));
                                // string Linktext = GetConvertedText(Description.Substring(l + 1, k - l - 1));
                                // zwString = zwString + Linktext;

                                zwString.Append(GetConvertedText(Description.Substring(l + 1, k - l - 1)));
                                i = k + 5;
                                // ZwString = ZwString + "<a href=\"#\" onclick=\"ToClip( 'Dir: " + $"{DirID:00000}" + "' );\">" + Linktext + "</a>";
                                // zwString = zwString + "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('Dir: " + $"{dirID:00000}" + "');\">" + Linktext + "</a>";



                                found = true;
                            }
                            if (found) break;
                        }
                    }
                    // Noloca: 001
                    else if (SubString(Description, i, 5) == "<Loc:")
                    {
                        int l;
                        for (l = i + 5; l < Description.Length; l++)
                        {
                            if (Description[l] == '>')
                                break;
                        }
                        int locID = Int32.Parse(Description.Substring(i + 5, l - i - 5));
                        for (k = i + 10; k < Description.Length; k++)
                        {
                            if ((Description[k] == '<') && (Description[k + 1] == '/') && (Description[k + 2] == 'L'))
                            {
                                // string Linktext = GetLocName(Description.Substring(i + 11, k - i - 11));
                                string Linktext = GetConvertedText(Description.Substring(l + 1, k - l - 1));
                                i = k + 5;
                                // zwString = zwString + "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('Loc: " + $"{locID:00000}" + "');\">" + Linktext + "</a>";
                                // zwString = zwString + "<a style=\"cursor:pointer\" class=\"class2\" onclick=\"window.external.JSCallback('Loc: " + $"{locID:00000}" + "');\">" + Linktext + "</a>";
#if CHROMIUM
                                string scr2 = System.Web.HttpUtility.HtmlEncode(loca.AdvData_GetConvertedText_14092 + loca.AdvData_GetConvertedText_14093);
                                string scr = System.Web.HttpUtility.HtmlEncode(loca.AdvData_GetConvertedText_14092 + $"{locID:00000}\");");
                                // Ignores: 003
                                zwString.Append(loca.AdvData_GetConvertedText_14094 + scr + loca.AdvData_GetConvertedText_14095 + Linktext + loca.AdvData_GetConvertedText_14096);
#elif MAUI
                                // string scr2 = System.Web.HttpUtility.HtmlEncode(loca.AdvData_GetConvertedText_14092 + loca.AdvData_GetConvertedText_14093);
                                // string scr = System.Web.HttpUtility.HtmlEncode(loca.AdvData_GetConvertedText_14092 + $"{locID:00000}\");");
                                string scr = System.Web.HttpUtility.HtmlEncode("window.location.href = 'https://defineobject.Loc/" + $"{locID:00000}';");
                                // Ignores: 003
                                zwString.Append(loca.AdvData_GetConvertedText_14094 + scr + loca.AdvData_GetConvertedText_14095 + Linktext + loca.AdvData_GetConvertedText_14096);
#else
                                // ToDo: Reparieren für non-Chromium
                               zwString.Append( loca.AdvData_GetConvertedText_14097 + Linktext + loca.AdvData_GetConvertedText_14098);
#endif
                                // zwString = zwString + Linktext;

                                found = true;
                            }
                            if (found) break;
                        }
                    }
                    // Noloca: 001
                    else if (SubString(Description, i, 10) == "<AP_AKK_C>")
                    {
#if CHROMIUM
                        // Noloca: 002

                        string scr = "boundAsync.JSCallback('ActPerson');>" + Adventure?.FirstUpper(Adventure?.Persons?.GetPersonName(Adventure!.Persons!.Find(ActPerson), Co.CASE_AKK));
                        // Ignores: 002
                        // Noloca: 002
                        string persName = "<a style='cursor:pointer' class='class1' onclick='" + scr + "</a>";
#elif MAUI
                        // Noloca: 002

                        // string scr = "boundAsync.JSCallback('ActPerson');>" + Adventure?.FirstUpper(Adventure?.Persons?.GetPersonName(Adventure!.Persons!.Find(ActPerson), Co.CASE_AKK));
                        string scr = System.Web.HttpUtility.HtmlEncode("window.location.href = 'https://defineobject.ActPerson/'") + "'>";
                        scr += Adventure?.FirstUpper(Adventure?.Persons?.GetPersonName(Adventure!.Persons!.Find(ActPerson), Co.CASE_AKK));
                        // Ignores: 002
                        // Noloca: 002
                        string persName = "<a style='cursor:pointer' class='class1' onclick='" + scr + "</a>";
#else
                        string persName = loca.AdvData_GetConvertedText_14099 +Adventure!.FirstUpper(Adventure!.Persons!.GetPersonName(Adventure!.Persons!.Find(ActPerson), Co.CASE_AKK)) + loca.AdvData_GetConvertedText_14100;
#endif
                        // zwString = zwString + persName;
                        zwString.Append(persName);
                        i = i + 9;
                    }
                    else if (SubString(Description, i, 8) == loca.AdvData_GetConvertedText_14101)
                    {
#if CHROMIUM
                        // Ignores: 001
                        string scr = System.Web.HttpUtility.HtmlEncode(loca.AdvData_GetConvertedText_14102 + Adventure?.Persons?.GetPersonName(Adventure!.Persons!.Find(ActPerson), Co.CASE_AKK));
                        // Ignores: 002
                        string persName = loca.AdvData_GetConvertedText_14103 + scr + loca.AdvData_GetConvertedText_14104;
#elif MAUI
                        // Ignores: 001
                        // string scr = System.Web.HttpUtility.HtmlEncode(loca.AdvData_GetConvertedText_14102 + Adventure?.Persons?.GetPersonName(Adventure!.Persons!.Find(ActPerson), Co.CASE_AKK));
                        string scr = System.Web.HttpUtility.HtmlEncode("window.location.href = 'https://defineobject.ActPerson/';>");
                        scr += Adventure?.Persons?.GetPersonName(Adventure!.Persons!.Find(ActPerson), Co.CASE_AKK);
                        // Ignores: 002
                        string persName = loca.AdvData_GetConvertedText_14103 + scr + loca.AdvData_GetConvertedText_14104;
#else
                        string persName = loca.AdvData_GetConvertedText_14105 +Adventure!.Persons!.GetPersonName(Adventure!.Persons!.Find(ActPerson), Co.CASE_AKK) + loca.AdvData_GetConvertedText_14106;
#endif
                        // string PersName = GetPersonName(A!.ActPerson, Co.CASE_AKK);

                        // zwString = zwString + persName;
                        zwString.Append(persName);
                        i = i + 7;
                    }
                    else if (SubString(Description, i, 8) == loca.AdvData_GetConvertedText_14107)
                    {
                        bool found2 = false;

                        j = i + 8;
                        for (; j < Description.Length; j++)
                        {
                            if (Description[j] == '>')
                            {
                                string s = Description.Substring(i + 8, j - i - 8);
                                for (k = 0; k < Adventure!.VerbTenses?.List.Count; k++)
                                {
                                    if (s == Adventure!.VerbTenses?.List[k].VerbNameTense[0].VerbNameTense)
                                    {
                                        zwString.Append(Grammar.GetVerbDeclination(Adventure!.VerbTenses!.List[k]!.ID!, Adventure!.Persons!.Find(ActPerson)!, Tense));
                                        found2 = true;
                                    }
                                    if (found2) break;
                                }
                            }
                            if (found2) break;
                        }
                        i = j;
                    }
                    else if (SubString(Description, i, 8) == loca.AdvData_GetConvertedText_14108)
                    {
                        bool found2 = false;

                        j = i + 8;
                        for (; j < Description.Length; j++)
                        {
                            if (Description[j] == '>')
                            {
                                string s = SubString(Description, i + 8, j - i - 8);
                                for (k = 0; k < Adventure!.VerbTenses!.List.Count; k++)
                                {
                                    if (s == Adventure!.VerbTenses.List[k].VerbNameTense[0].VerbNameTense)
                                    {
                                        zwString.Append(Grammar.GetVerbDeclination(Adventure!.VerbTenses.List[k].ID, Adventure!.Persons!.Find(ActPerson)!, Adventure!.CB!.Tense_Past));
                                        found2 = true;
                                    }
                                    if (found2) break;
                                }
                            }
                            if (found2) break;
                        }
                        i = j;
                    }
                    else
                        zwString.Append(Description[i]);
                }
                else
                    zwString.Append(Description[i]);
            }
            return (zwString.ToString());
        }

        /*
        public string GetConvertedText(string OriginalText)
        {
            int i, j, k;

            string FinalText = "";
            for (i = 0; i < OriginalText.Length; i++)
            {
                if (OriginalText[i] == '<')
                {
                    bool found = false;

                    if (SubString(OriginalText, i, 6) == "<Item:")
                    {
                        int itemID = Int32.Parse(OriginalText.Substring(i + 6, 5));
                        for (k = i + 12; k < OriginalText.Length; k++)
                        {
                            if ((OriginalText[k] == '<') && (OriginalText[k + 1] == '/') && (OriginalText[k + 2] == 'I'))
                            {
                                string ItemName = GetConvertedText(OriginalText.Substring(i + 12, k - i - 12));
                                i = k + 6;
        // Ignores: 005
                                FinalText = FinalText + "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('Item: " $"{itemID:00000}');\"></a>";
        // Ignores: 005
                                // ZwString = ZwString + "<a href=\"#\" onclick=\"window.clipboardData.setData( 'Text', 'Item: " + $"{itemID:00000}" + "' );\">" + ItemName + "</a>";
                                found = true;
                            }
                            if (found) break;
                        }
                    }
                    else if (SubString(OriginalText, i, 6) == "<Person:")
                    {
                        int personID = Int32.Parse(OriginalText.Substring(i + 6, 7));
                        for (k = i + 14; k < OriginalText.Length; k++)
                        {
                            if ((OriginalText[k] == '<') && (OriginalText[k + 1] == '/') && (OriginalText[k + 2] == 'P'))
                            {
                                string personName = GetConvertedText(OriginalText.Substring(i + 14, k - i - 14));
                                i = k + 8;
                                FinalText = FinalText + "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('Item: " $"{personID:00000}');\"></a>";
                                // ZwString = ZwString + "<a href=\"#\" onclick=\"window.clipboardData.setData( 'Text', 'Item: " + $"{itemID:00000}" + "' );\">" + ItemName + "</a>";
                                found = true;
                            }
                            if (found) break;
                        }
                    }
                    else if (SubString(OriginalText, i, 5) == "<Dir:")
                    {
                        int dirID = Int32.Parse(OriginalText.Substring(i + 5, 5));
                        for (k = i + 10; k < OriginalText.Length; k++)
                        {
                            if ((OriginalText[k] == '<') && (OriginalText[k + 1] == '/') && (OriginalText[k + 2] == 'D'))
                            {
                                string Linktext = GetConvertedText(OriginalText.Substring(i + 11, k - i - 11));
                                i = k + 5;
                                // ZwString = ZwString + "<a href=\"#\" onclick=\"ToClip( 'Dir: " + $"{DirID:00000}" + "' );\">" + Linktext + "</a>";
                                FinalText = FinalText + "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('Dir: " $"{dirID:00000}');\"></a>";
                                // ZwString = ZwString + "<a href=\"#\" onclick=\"window.external.Test2('Dir: 00004');\"</a>";
                                // FinalText = FinalText + " " + Linktext  
                                found = true;
                            }
                            if (found) break;
                        }
                    }
                    else if (SubString(OriginalText, i, 10) == "<AP_AKK_C>")
                    {
                        string persName = "<a style=\"cursor:pointer\" onclick=\"window.external.JSCallback('ActPerson');\">" +Adventure!.FirstUpper(Adventure!.Persons!.GetPersonName(Adventure!.Persons!.Find( ActPerson ), Co.CASE_AKK)) + "</a>";
                        FinalText = FinalText + persName;
                        i = i + 9;
                    }
                    else if (SubString(OriginalText, i, 8) == "<AP_AKK>")
                    {
                        string persName = "<a style=\"cursor:pointer\"vonclick=\"window.external.JSCallback('ActPerson');\">" +Adventure!.Persons!.GetPersonName(Adventure!.Persons!.Find( ActPerson ), Co.CASE_AKK) + "</a>";
                        // string PersName = GetPersonName(A!.ActPerson, Co.CASE_AKK);

                        FinalText = FinalText + persName;
                        i = i + 7;
                    }
                    else if (SubString(OriginalText, i, 8) == "<APVTPr:")
                    {
                        bool found2 = false;

                        j = i + 8;
                        for (; j < OriginalText.Length; j++)
                        {
                            if (OriginalText[j] == '>')
                            {
                                string s = OriginalText.Substring(i + 8, j - i - 8);
                                for (k = 0; k < Adventure!.VerbTenses.List.Count; k++)
                                {
                                    if (s == Adventure!.VerbTenses.List[k].VerbNameTense[0])
                                    {
                                        FinalText = FinalText + Grammar.GetVerbDeclination(Adventure!.VerbTenses.List[k].ID, Adventure!.Persons!.Find( ActPerson ), Tense);
                                        found2 = true;
                                    }
                                    if (found2) break;
                                }
                            }
                            if (found2) break;
                        }
                        i = j;
                    }
                    else if (SubString(OriginalText, i, 8) == "<APVTPa:")
                    {
                        bool found2 = false;

                        j = i + 8;
                        for (; j < OriginalText.Length; j++)
                        {
                            if (OriginalText[j] == '>')
                            {
                                string s = SubString(OriginalText, i + 8, j - i - 8);
                                for (k = 0; k < Adventure!.VerbTenses.List.Count; k++)
                                {
                                    if (s == Adventure!.VerbTenses.List[k].VerbNameTense[0])
                                    {
                                        FinalText = FinalText + Grammar.GetVerbDeclination(Adventure!.VerbTenses.List[k].ID, Adventure!.Persons!.Find( ActPerson ), Adventure!.CB!.Tense_Past);
                                        found2 = true;
                                    }
                                    if (found2) break;
                                }
                            }
                            if (found2) break;
                        }
                        i = j;
                    }
                    else
                        FinalText = FinalText + OriginalText[i];
                }
                else
                    FinalText = FinalText + OriginalText[i];
            }
            return (FinalText);

        }
        */
    }
    [Serializable]

    public class AdvBase
    {
        ParseLineList? _pll = null;
        ParseLineList? _pllEng = null;

 
        public CoBase? CB { get; set; }

        public int LatestInputPt { get; set; }

         public List<LatestInput> LI { get; set; } = new();

        public string tLastParseString = "";

         public AdvData A { get; set; } = new();

         protected Adv? AdvGame 
        {   
            get
            {
                return GlobalData.CurrentGlobalData!.Adventure;
            }
            set
            {
                GlobalData.CurrentGlobalData!.Adventure = value;
            }
        }

        public locationList? locations { get; set; }

        public ParseLineList? PLL
        {
            get
            {
                if (loca.GD!.Language == IGlobalData.language.english && _pllEng != null)
                    return _pllEng;
                else
                    return _pll;
            }
            set
            {
                _pll = value;
            }
        }
        public ParseLineList? PLLEng
        {
            get
            {
                return _pllEng;
            }
            set
            {
                _pllEng = value;
            }
        }

         public ItemList? Items { get; set; }

         public PersonList? Persons { get; set; }
        
         public TopicList? Topics { get; set; }

        public StatusList? Stats { get; set; }

         public ScoreList? Scores { get; set; }
        // public Grammar DoGrammar;
        
        public Order? Orders { get; set; }

        public VTList? VerbTenses { get; set; }

        public VerbList? Verbs { get; set; }

        public AdjList? Adjs { get; set; }

        public NounList? Nouns { get; set; }

        public PrepList? Preps { get; set; }
        public PronounList? Pronouns { get; set; }
       public ItemQueue? ItemQueue { get; set; }

        public FillList? Fills { get; set; }

        public Parse? Parser { get; set; }

        public CategoryRelList? Categories { get; set; }

        public bool GameTestMode = false;

        public bool SetStoryLine { get; set; }


        private bool dialogOngoing = false;

        private bool skipAfterDialog = false;

        [JsonIgnore]
        public GlobalData? GD
        {
            get => GlobalData.CurrentGlobalData;
            set => GlobalData.CurrentGlobalData = value;
        }

        public Phoney_MAUI.Model.IUIServices? UIS
        {
            get => GlobalData.CurrentGlobalData!.UIS;
            set => GlobalData.CurrentGlobalData!.UIS = value;
        }

        public bool DialogOngoing
        {
            get { return dialogOngoing; }
            set { dialogOngoing = value; }
        }

        public bool SkipAfterDialog
        {
            get { return skipAfterDialog; }
            set { skipAfterDialog = value; }
        }

        // [JsonIgnore][NonSerialized] private MainWindow MW;


        public bool RecordOrder(string? s)
        {
            int val = 0;
            GD!.OrderList!.AddOrder(orderType.orderText!, s!, null, loca.GD!.Language, Parser!.latestPTL, Parser!.latestPTLSignatures, ref val);
            if (GD!.OrderList.CurrentOrderListIx > 0)
            {
                GD!.OrderList.AddOrderCurrentRun(orderType.orderText, s, null, loca.GD!.Language, Parser.latestPTL, Parser.latestPTLSignatures);
                // MW.UpdateOrderList(GD!.OrderList);
            }
            return true;
        }

        public bool DoGameLoopIfSuccess(ParseLineList? ptlSignatures = null)
        {
            // bool callDoMethods = false;
            bool collectIt = false;


            if (ptlSignatures != null)
            {
                if (ptlSignatures!.List![0]!.CollectIt == true)
                    collectIt = true;
            }


            string s = LI[LI.Count - 1].Text;
            AdvGame!.GD!.LastCommandSucceeded = true;
            if (GD!.SilentMode == false && s != "" && collectIt)
            {
                if (Parser!.LatestParseResult != "" && Parser!.LatestParseResult != null)
                    s = Parser!.LatestParseResult;

                int val = 0;

                // return true;

                GD!.OrderList!.AddOrder(orderType.orderText, s, null, loca.GD!.Language, Parser.latestPTL, Parser.latestPTLSignatures, ref val);
                if (GD!.OrderList.CurrentOrderListIx > 0)
                {
                    GD!.OrderList.AddOrderCurrentRun(orderType.orderText, s, null, loca.GD!.Language, Parser.latestPTL, Parser.latestPTLSignatures);
                    // MW.UpdateOrderList(GD!.OrderList);
                }


                GD!.OrderList.FlushCollection();
            }
            // Hier wurde komplett zweigleisig ein weiterer Mechanismus aufgebaut, wow
            if (UIS!.MCMS == null)
            {
                // callDoMethods = true;
            }
            else if (UIS!.MCMS.Visible)
            {
                // callDoMethods = true;
            }



            if (AdvGame!.DialogOngoing == false && AdvGame!.SkipAfterDialog == false && ptlSignatures!.List![0]!.CollectIt!)
            {
                Persons!.DoNPCs();
                locations!.Dolocations();
            }
            /* ToDo:
             Klären, ob das so gebraucht wird. Ich habs jetzt einfach mal nach DoGameLoop verschoben, sonst wirds z.T. doppelt ausgeführt
            AdvGame.SkipAfterDialog = false;
            UIS!.DoUIUpdate();
            UIS!.StoryTextObj!.AdvTextRefresh();
            UIS!.Scr!.ScrollPageFinal();
            UIS!.Scr!.SetNext = true;
            */
            return true;
        }


        public bool DoGameLoop(string s, ParseTokenList? ptl = null, ParseLineList? ptlSignatures = null)
        {

            bool success = false;
            if (s != null)
            {
                UIS!.InitBrowserUpdate();
                int ct = GD!.OrderList!.gridRefresh;

                if (GD!.FeedbackWindow == false && GD!.UseMoreBuffer == false)
                {
                    // UIS!.StoryTextObj!.BufferedInput = loca.AdvBase_DoGameLoop_Person_I_14113 + s;
                    StoryOutput(loca.AdvBase_DoGameLoop_Person_I_14113 + s);
                }

                LI.Add(new LatestInput(s));
                LatestInputPt = LI.Count;
                // Nur ein Kommentar? Dann wird dieser aufgezeichnet
                if (AdvGame!.GD!.SilentMode == false && (s.StartsWith(loca.AdvBase_DoGameLoop_14109) || s.StartsWith(loca.AdvBase_DoGameLoop_14110)))
                {
                    int i;
                    for (i = 1; i < s.Length; i++)
                    {
                        if (s[i] != ' ') break;
                    }
                    string s2 = loca.AdvBase_DoGameLoop_14111 + s.Substring(i);

                    int val = 0;
                    AdvGame.GD!.OrderList!.AddOrder(orderType.comment, s2, null, loca.GD!.Language, null, null, ref val);
                    if (AdvGame.GD!.OrderList.CurrentOrderListIx > 0)
                        AdvGame.GD!.OrderList.AddOrderCurrentRun(orderType.comment, s2, null, loca.GD!.Language, null, null);

                    if (!GD!.FeedbackWindow)
                    {
                        StoryOutput(s);
                    }

                    AdvGame.FeedbackOutput(AdvGame.CA!.Person_I!, loca.AdvBase_DoGameLoop_Person_I_14112, true);
#if !NEWSCROLL
                    AdvGame.UIS!.Scr.ScrollPageFinal();
#endif
                }
                else
                {
                    if (GD!.FeedbackWindow == false)
                    {
                        if( GD!.UseMoreBuffer == true )
                            UIS!.StoryTextObj!.BufferedInput = loca.AdvBase_DoGameLoop_Person_I_14113 + s;
                    }
                    // Ignores: 001

                    bool collectIt = Parser!.DoParseNew(s, DoGameLoopIfSuccess, ptl, ptlSignatures);
                    string s1 = (GD!.OrderList.gridRefresh - ct).ToString();
                }
                // FeedbackOutput(AdvGame.CA!.Person_Everyone, s1 );
                /*
                Parser.DoParse( s );
                success = Persons!.DoNPCs();
                success = locations.Dolocations();
                success = MW.DoUIUpdate();
                */

                // Neuer Code: Prüfen, ob das hier so bleiben kann. Voller Refresh
                AdvGame.SkipAfterDialog = false;
                UIS!.DoUIUpdate();
                UIS!.StoryTextObj!.AdvTextRefresh();
                UIS!.FinishBrowserUpdate( IUIServices.onBrowserContentLoaded.PageDown);
                // SCROLLTEST
                // UIS!.Scr!.ScrollPageFinal();
#if !NEWSCROLL
                UIS!.Scr!.SetNext = true;
#endif
                // Alter Code: Nur der TextRefresh, der dafür aber womöglich doppelt
                // UIS.StoryTextObj!.AdvTextRefresh();
            }
            return (success);
        }



        public bool WaitForCondition(Person person, DelVoid conditionMethod)
        {
            if (AdvGame!.GD!.SilentMode == false) return false;
            if (person.GetController(AdvGame) == null) return false;
            bool getCondition = false;

            for (int ix = 0; ix < 500; ix++)
            {
                if (conditionMethod() == true)
                {
                    getCondition = true;
                    break;
                }
                person!.GetController(AdvGame!)!(person!.locationID!);
            }
            return getCondition;
        }


        public bool WaitForWanderer(Person? person, int destLoc)
        {
            bool meetWanderer = false;
            bool waitingMakesSense = false;

            if (AdvGame!.GD!.SilentMode == false) return false;
            // Wenn der Wanderer schon am Ziel ist: return
            if (person!.locationID == destLoc) return true;

            // Wenn die Person kein Wanderer ist, braucht man auch nicht zu warten
            if (person.IsWanderer == false) return false;

            if (person.WandererList == null)
                return false;
            else
            {
                foreach (int i in person.WandererList)
                {
                    if (i == destLoc)
                    {
                        waitingMakesSense = true;
                        break;
                    }
                }
            }

            if (waitingMakesSense && person.GetController(AdvGame) != null)
            {
                for (int ix = 0; ix < 500; ix++)
                {
                    if (person.locationID == destLoc)
                    {
                        meetWanderer = true;
                        break;
                    }
                    person!.GetController(AdvGame!)!(person!.ID!);
                }
            }

            return meetWanderer;
        }

        public AdvBase()
        {
            // Initialisierungen, die ich nur mache, um die Warning wegzubekommen:
 

            // MW = Ausgabeklasse;
        }


        public Phoney_MAUI.Core.MCMenuView MenuShow()
        {
            Phoney_MAUI.Core.MCMenuView m = (Phoney_MAUI.Core.MCMenuView) new Phoney_MAUI.Core.MCMenuView();
             return (m);
        }

        public void OutputExit(MCMenu M)
        {
            if (M != null)
            {
                DialogOngoing = false;
                M.MCS!.Close();

            }
        }

        public MCMenu AdvMCMenu(Person SpeakerID, bool TextOutput, int Start)
        {
            MCMenu mcM = new MCMenu(Stats!, Persons!, SpeakerID, A, AdvGame!, TextOutput, Start)!;
            UIS!.LastMCMenu = mcM;

            return (mcM);
        }


        public bool DoUIUpdate()
        {
            if (UIS == null)
                return (false);
            else
                return UIS!.DoUIUpdate();
        }


        public bool PictureOutput(string picName)
        {
            if (AdvGame!.A!.PicSize != AdvData.picSize.none && picName != null)
            {
                string size = loca.AdvBase_PictureOutput_14114;
                if (AdvGame.A!.PicSize == AdvData.picSize.medium)
                    size = loca.AdvBase_PictureOutput_14115;
                if (AdvGame.A!.PicSize == AdvData.picSize.large)
                    size = loca.AdvBase_PictureOutput_14116;


                string s = string.Format(loca.AdvBase_PictureOutput_14117, picName, size);

                return StoryOutput(AdvGame.CA!.Person_I!.locationID, AdvGame.CA!.Person_I, s);
            }
            else
            {
                return false;
            }

        }

        public bool StoryDividingLine()
        {
            if( GD!.LayoutDescription.ParagraphClusterMode != ILayoutDescription.ParagraphClusters.none)
                UIS!.StoryTextObj!.DividingLine();
            else
                UIS!.StoryTextObj!.NotDividingLine();

            return true;
        }

        public bool StoryOutput(string? Text)
        {
            if (AdvGame!.CA == null)
                return false;

            return StoryOutput(AdvGame!.CA!.Person_I!.locationID, AdvGame!.CA!.Person_I, Text);
        }

        public bool StoryOutput(int locationID, Person? PersonID, string? Text)
        {
            if (PersonID == null) PersonID = A!.Adventure!.CA!.Person_Everyone;

            if (((PersonID!.ID == A!.Adventure!.CA!.Person_Everyone!.ID) || (PersonID!.ID == A!.ActPerson))
                    && ((locationID == Persons!.Find(A!.ActPerson)!.locationID) || (locationID == 0))
               )
            {
                if (SetStoryLine == false)
                {
                    // DividingLine
                    if( GD!.LayoutDescription.ParagraphClusterMode != ILayoutDescription.ParagraphClusters.none)
                        UIS!.StoryTextObj!.DividingLine();
                    else
                        UIS!.StoryTextObj!.NotDividingLine();

                    // UIS.Scr.CompileToEnd();
                    /*
                       string line = "</p><hr><p class=\"sansserif\">";
                       MW.StoryTextObj.TextStrip(line);
                       MW.TextOutput(line);
                       */
                    SetStoryLine = true;
                    UIS!.StoryTextObj.CurrentLinesPerTurn = 0;
                }

                if (UIS!.StoryTextObj!.BufferedInput != null)
                {
                    string s = UIS!.StoryTextObj.BufferedInput;
                    UIS!.StoryTextObj.BufferedInput = null;
                    StoryOutput(locationID, PersonID, s);
                }

                GD!.OrderList!.AddOrderText(Helper.StripHTML(Text!));
                UIS!.TextOutput(A!.GetConvertedText(Text!)!);
                // MW.TextOutput( Text);
            }
            return (true);
        }


        public string StateDescription()
        {
            string s = "";

            s += loca.AdvBase_StateDescription_14122;

            s += loca.AdvBase_StateDescription_14123;

            s += locations!.GetLocName(locations!.Find(A!.ActLoc)!.LocName!)!;

            s += loca.AdvBase_StateDescription_14124;

            string s1 = loca.AdvBase_StateDescription_14125;
            if (AdvGame.LastSpeaker != null)
            {
                s1 = Persons!.GetPersonName(AdvGame!.LastSpeaker, Co.CASE_DAT)!;
            }
            s += String.Format(loca.AdvBase_StateDescription_14126, s1);

            s += loca.AdvBase_StateDescription_14127;

            s += String.Format(loca.AdvBase_StateDescription_14128, Scores!.TotalScore());

            if (AdvGame.GD!.Language == IGlobalData.language.german)
                s += loca.AdvBase_SaveGame_Add_German;
            else
                s += loca.AdvBase_SaveGame_Add_English;

            return s;
        }

        public bool StoryOutput(List<int> locationIDs, Person PersonID, string Text)
        {
            int actLoc = Persons!.Find(A!.ActPerson)!.locationID;
            bool putOut = false;
            if (PersonID == null) PersonID = A!.Adventure!.CA!.Person_Everyone!;

            if (locationIDs == null)
            {
                putOut = true;
            }
            else
            {
                foreach (int loc in locationIDs)
                {
                    if (loc == actLoc)
                    {
                        putOut = true;
                        break;
                    }
                }
            }

            if (((PersonID == A!.Adventure!.CA!.Person_Everyone) || (PersonID!.ID == A!.ActPerson))
                    && (putOut == true)
               )
            {
                if (SetStoryLine == false)
                {
                    // Noloca: 001
                    string line = "</p><hr><p class=\"sansserif\">";
                    UIS!.StoryTextObj!.TextStrip(line);
                    UIS!.TextOutput(line);
                    SetStoryLine = true;
                }

                UIS!.TextOutput(A.GetConvertedText(Text));
                // MW.TextOutput( Text);
            }
            return (true);
        }

        public bool FeedbackOutput(Person PersonID, string text, bool sys = false)
        {
            if ((PersonID == A!.Adventure!.CA!.Person_Everyone) || (PersonID.ID == A!.ActPerson))
            {
                if (GD!.FeedbackWindow == true)
                {
                    UIS!.FeedbackTextObj.FeedbackTextOutput(text);

                    GD!.OrderList!.AddOrderFeedback(AdvGame!.LI[AdvGame.LI.Count - 1]!.Text!, Helper.StripHTML(text), sys);
                    if (GD!.OrderList!.CurrentOrderListIx > 0)
                    {
                        GD!.OrderList.AddOrderFeedbackCurrentRun(AdvGame.LI[AdvGame.LI.Count - 1].Text, Helper.StripHTML(text), sys);
                    }

                }
                else
                {
                    StoryOutput(text);
                    if (AdvGame!.LI!.Count > 0)
                    {
                        GD!.OrderList!.AddOrderFeedback(AdvGame!.LI[AdvGame.LI.Count - 1]!.Text!, Helper.StripHTML(text)!, sys);
                        if (GD!.OrderList!.CurrentOrderListIx > 0)
                        {
                            GD!.OrderList!.AddOrderFeedbackCurrentRun(AdvGame.LI[AdvGame.LI.Count - 1].Text, Helper.StripHTML(text), sys);
                        }
                    }
                }
            }
            return (true);
        }

        public bool FeedbackOutput(string text, bool sys = false)
        {
            FeedbackOutput(A.Adventure!.CA!.Person_Everyone!, text, sys);
            return true;
        }


        public void RemoveEmptyDividingLine()
        {
            UIS!.StoryTextObj!.RemoveEmptyDividingLine();
        }

        public bool HeadlineOutput(string Text)
        {
            UIS!.HeadlineOutput(Text);
            return (true);
        }

        public string? FirstUpper(string? Text)
        {
            return (Helper.FirstUpper(Text));
        }

        // byte[]? nounBuffer;
        // string? nounString;

        public string SaveObj(object o)
        {
            string str = JsonConvert.SerializeObject(o, Newtonsoft.Json.Formatting.Indented);
            return str;

        }

        public string SaveNouns()
        {
            /*
            // Hier wird erst mal der Index fest verdrahtet
            int ix = 0;
            foreach ( Noun n in Nouns.TList.Values )
            {
                Type? t = typeof(loca);
                TypeInfo y = typeof(loca).GetTypeInfo();
                int ct = y.DeclaredProperties.Count();
                for ( int ix2 = 1; ix2 < ct; ix2++ )
                {
                    TypeInfo x = typeof(loca).GetTypeInfo();
                    PropertyInfo pi = x.DeclaredProperties.ElementAt(ix2);

                    string s = (string) pi.GetValue(null);

                    if( s.Equals( n.Name ) )
                    {
                        n.ix = ix2;
                        break;
                    }
                    // if ( pi.GetValue(loca))

                }
                ix++;
            }
            */
            string str = JsonConvert.SerializeObject(Nouns, Newtonsoft.Json.Formatting.Indented);
            return str;

        }
        public string SaveAdjs()
        {
            string str = JsonConvert.SerializeObject(Adjs, Newtonsoft.Json.Formatting.Indented);
            return str;

        }
        public string SaveVerbs()
        {
            string str = JsonConvert.SerializeObject(Verbs, Newtonsoft.Json.Formatting.Indented);
            return str;

        }
        public string SaveLocations()
        {
            string str = JsonConvert.SerializeObject(locations, Newtonsoft.Json.Formatting.Indented);
            return str;

        }
        public string SavePLL()
        {
            string str = JsonConvert.SerializeObject(PLL, Newtonsoft.Json.Formatting.Indented);
            return str;

        }
        public string SavePLLEng()
        {
            string str = JsonConvert.SerializeObject(PLLEng, Newtonsoft.Json.Formatting.Indented);
            return str;

        }
        public string SavePersons()
        {
            string str = JsonConvert.SerializeObject(Persons, Newtonsoft.Json.Formatting.Indented);
            return str;

        }
        public string SaveItems()
        {
            List<Item> li = new();
            foreach( Item it in Items!.List!.Values)
            {
                li.Add(it);
            }

            string str = JsonConvert.SerializeObject(li, Newtonsoft.Json.Formatting.Indented);
            return str;

        }
        public string SavePreps()
        {
            string str = JsonConvert.SerializeObject(Preps, Newtonsoft.Json.Formatting.Indented);
            return str;

        }

        public string? SearchInitData( string s)
        {
            foreach( IUIServices.ZipObject zo in LoadedInitData! )
            {
                if( zo.Name == s)
                {
                    return zo.Data;
                }
            }
            return null;
        }

        public PrepList? LoadPreps()
        {
            string? istring = SearchInitData("preps");
            PrepList? preps = JsonConvert.DeserializeObject<PrepList>(istring!);
            return preps;
        }

        public VerbList? LoadVerbs()
        {
            string? vstring = SearchInitData("verbs");
            VerbList? v = JsonConvert.DeserializeObject<VerbList>(vstring!)!;
            return v;
        }
        public AdjList? LoadAdjs( )
        {
            string? astring = SearchInitData("adjs");
            AdjList? a = JsonConvert.DeserializeObject<AdjList>(astring!)!;
            return a;
        }
        public NounList? LoadNouns()
        {
            string? nstring = SearchInitData("nouns");
            NounList? n = JsonConvert.DeserializeObject<NounList>(nstring!)!;
            return n;
            /*
            using (var ms = new MemoryStream( nounBuffer ))
            {
                using (var reader = new BsonReader(ms))
                {
                    var serializer = new Newtonsoft.Json.JsonSerializer();
                    n = serializer.Deserialize<NounList>(reader);
                }
            }
            return n;
            */

            /*
            using (var ms = new MemoryStream(nounString))
            {
                var serializer = new Newtonsoft.Json.JsonSerializer();
                n = serializer.Deserialize(reader);
            }
            return n;
            */
        }
        public ParseLineList? LoadPLL()
        {
            string? pllstring = SearchInitData("pll");
            ParseLineList? pll = JsonConvert.DeserializeObject<ParseLineList>(pllstring!)!;
            int ix = 0;
            foreach (ParseLine pl in pll!.List!)
            {
                ParseTokenList ptl = pl.PTL!;

                pl.SetParseMethodByString( Orders!);

                foreach (ParseToken pt in ptl.PList!)
                {
                    string? sO = pt.O!.ToString();
                    // bool converted = false;

                    if (pt.PTType == ParseToken.ptTypes.noun )
                    {
                        pt.O = JsonConvert.DeserializeObject<Noun>(sO!);
                        // converted = true;
                    }
                    // Adjs
                    else if ( pt.PTType == ParseToken.ptTypes.adj )
                    {
                        pt.O = JsonConvert.DeserializeObject<Adj>(sO!);
                        // converted = true;

                    }
                    // Verbs (Spielbezogener Wortschatz)
                    else if (pt.PTType == ParseToken.ptTypes.verb)
                    {
                        pt.O = JsonConvert.DeserializeObject<Verb>(sO!);
                        // converted = true;

                    }
                    // Fills
                    else if ((pt.PTType == ParseToken.ptTypes.fill))
                    {
                        pt.O = JsonConvert.DeserializeObject<Fill>(sO!);
                        // converted = true;

                    }

                    // Pronouns
                    else if ((pt.PTType == ParseToken.ptTypes.pronoun))
                    {
                        pt.O = JsonConvert.DeserializeObject<Pronoun>(sO!);
                        // converted = true;

                    }
                    // Preps
                    else if (pt.PTType == ParseToken.ptTypes.prep)
                    {
                        pt.O = JsonConvert.DeserializeObject<Prep>(sO!);
                        // converted = true;

                    }
                    // Verbs (Basis-Wortschatz)
                    else if ((pt.PTType == ParseToken.ptTypes.prep))
                    {
                        pt.O = JsonConvert.DeserializeObject<Verb>(sO!);
                        // converted = true;

                    }
                    // Items 
                    else if ((pt.PTType == ParseToken.ptTypes.item))
                    {
                        pt.O = new Item();
                        // converted = true;

                    }
                    // Persons 
                    else if ((pt.PTType == ParseToken.ptTypes.person))
                    {
                        pt.O = new Person();
                        // converted = true;

                    }

                }
                ix++;
            }
            return pll;
        }
        public ParseLineList? LoadPLLEng()
        {
            string? pllstring = SearchInitData("plleng");
            ParseLineList? pll = JsonConvert.DeserializeObject<ParseLineList>(pllstring!)!;
            return pll;
        }
        public List<CAAdjs>? LoadAdjLinks()
        {
            string? caadjstring = SearchInitData("adjlinks");
            List<CAAdjs>? caa = JsonConvert.DeserializeObject<List<CAAdjs>>(caadjstring!)!;
            return caa;
        }
        public List<CANouns>? LoadNounLinks()
        {
            string? canounstring = SearchInitData("nounlinks");
            List<CANouns>? can = JsonConvert.DeserializeObject<List<CANouns>>(canounstring!)!;
            return can;
        }
        public List<CAVerbs>? LoadVerbLinks()
        {
            string? caverbstring = SearchInitData("verblinks");
            List<CAVerbs>? cav = JsonConvert.DeserializeObject<List<CAVerbs>>(caverbstring!)!;
            return cav;
        }
        public List<CAVerbs>? LoadVerbLinksCB()
        {
            string? caverbstring = SearchInitData("verblinkscb");
            List<CAVerbs>? cav = JsonConvert.DeserializeObject<List<CAVerbs>>(caverbstring!)!;
            return cav;
        }
        public List<CAPersons>? LoadPersonLinks()
        {
            string? capersonstring = SearchInitData("personlinks");
            List<CAPersons>? cap = JsonConvert.DeserializeObject<List<CAPersons>>(capersonstring!)!;
            return cap;
        }
        public List<CAInts>? LoadCAInts()
        {
            string? caintsstring = SearchInitData("caints");
            List<CAInts>? caints = JsonConvert.DeserializeObject<List<CAInts>>(caintsstring!)!;
            return caints;
        }
        public List<CAInts>? LoadCAIntProps()
        {
            string? caintsstring = SearchInitData("caintprops");
            List<CAInts>? caints = JsonConvert.DeserializeObject<List<CAInts>>(caintsstring!)!;
            return caints;
        }
        public List<CAPreps>? LoadCBPreps()
        {
            string? caprepsstring = SearchInitData("prepscb");
            List<CAPreps>? caints = JsonConvert.DeserializeObject<List<CAPreps>>(caprepsstring!)!;
            return caints;
        }
        public List<CAItems>? LoadItemLinks()
        {
            string? caitemstring = SearchInitData("itemlinks");
            List<CAItems>? cai = JsonConvert.DeserializeObject<List<CAItems>>(caitemstring!)!;
            return cai;
        }

        public class CANouns
        {
            public string? Name { get; set; }
            public int NounID { get; set; }
        }
        public class CAVerbs
        {
            public string? Name { get; set; }
            public int VerbID { get; set; }
        }
        public class CAInts
        {
            public string? Name { get; set; }
            public int Val { get; set; }
        }
        public class CAPreps
        {
            public string? Name { get; set; }
            public int PrepID { get; set; }
        }
        public class CAAdjs
        {
            public string? Name { get; set; }
            public int AdjID { get; set; }
        }
        public class CAPersons
        {
            public string? Name { get; set; }
            public int PersonID { get; set; }
        }
        public class CALocations
        {
            public string? Name { get; set; }
            public int LocationID { get; set; }
        }
        public class CAItems
        {
            public string? Name { get; set; }
            public int ItemID { get; set; }
        }

        public List<IUIServices.ZipObject>? LoadedInitData { get; set; }


        public void LoadInitData()
        {
            List<IUIServices.ZipObject> zo = UIS!.LoadFromZip("initdata");
            LoadedInitData = zo;
        }
        public object? LoadFromInitData( string? name  )
        {
            object? o = null;

            foreach( IUIServices.ZipObject zio in LoadedInitData! )
            {
                if( zio.Name == name )
                {
                    o = zio.Data;
                }
            }
            return o;
        }
        public void InitializeGeneralGameData( Adv thisAdv )
        {
            CB = new();
            // Co.CB = CB;
            Verbs = new VerbList();
            Adjs = new AdjList();
            Nouns = new NounList();
            Fills = new FillList();
            Preps = new PrepList();
            Pronouns = new PronounList();
            ItemQueue = new ItemQueue(20);


            A = new AdvData();
            A!.ActLoc = A.StartLoc;
            // A!.ActPerson = A.Adventure!.CA!.Person_Self.ID;

#pragma warning disable CS0168 // Die Variable "PT" ist deklariert, wird aber nie verwendet.
            List<ParseToken> PT;
#pragma warning restore CS0168 // Die Variable "PT" ist deklariert, wird aber nie verwendet.

            if (LoadedInitData == null)
            {
                thisAdv.InitVerbsPart1Fast();
                /*
                CB!.Verb_German = Verbs.AddLoca("AdvBase_Deutsch");
                Verbs.AddLoca(CB!.Verb_German.ID, "AdvBase_Deutsch2");
                Verbs.AddLoca(CB!.Verb_German.ID, "AdvBase_Deutsch3");
                CB!.Verb_English = Verbs.AddLoca("AdvBase_Englisch");
                Verbs.AddLoca(CB!.Verb_English.ID, "AdvBase_Englisch2");
                Verbs.AddLoca(CB!.Verb_English.ID, "AdvBase_Englisch3");

                CB!.Verb_N = Verbs.AddLoca("AdvBase_InitializeGame_14129");
                Verbs.AddLoca(CB!.Verb_N.ID, "AdvBase_InitializeGame_14130");
                Verbs.AddLoca(CB!.Verb_N.ID, "AdvBase_InitializeGame_14131");

                CB!.Verb_NE = Verbs.AddLoca("AdvBase_InitializeGame_14132");
                Verbs.AddLoca(CB!.Verb_NE.ID, "AdvBase_InitializeGame_14133");
                Verbs.AddLoca(CB!.Verb_NE.ID, "AdvBase_InitializeGame_14134");

                CB!.Verb_E = Verbs.AddLoca("AdvBase_InitializeGame_14135");
                Verbs.AddLoca(CB!.Verb_E.ID, "AdvBase_InitializeGame_14136");
                Verbs.AddLoca(CB!.Verb_E.ID, "AdvBase_InitializeGame_14137");
                Verbs.AddLoca(CB!.Verb_E.ID, "AdvBase_InitializeGame_14138");

                CB!.Verb_SE = Verbs.AddLoca("AdvBase_InitializeGame_14139");
                Verbs.AddLoca(CB!.Verb_SE.ID, "AdvBase_InitializeGame_14140");
                Verbs.AddLoca(CB!.Verb_SE.ID, "AdvBase_InitializeGame_14141");
                Verbs.AddLoca(CB!.Verb_SE.ID, "AdvBase_InitializeGame_14142");

                CB!.Verb_S = Verbs.AddLoca("AdvBase_InitializeGame_14143");
                Verbs.AddLoca(CB!.Verb_S.ID, "AdvBase_InitializeGame_14144");
                Verbs.AddLoca(CB!.Verb_S.ID, "AdvBase_InitializeGame_14145");

                CB!.Verb_SW = Verbs.AddLoca("AdvBase_InitializeGame_14146");
                Verbs.AddLoca(CB!.Verb_SW.ID, "AdvBase_InitializeGame_14147");
                Verbs.AddLoca(CB!.Verb_SW.ID, "AdvBase_InitializeGame_14148");

                CB!.Verb_W = Verbs.AddLoca("AdvBase_InitializeGame_14149");
                Verbs.AddLoca(CB!.Verb_W.ID, "AdvBase_InitializeGame_14150");
                Verbs.AddLoca(CB!.Verb_W.ID, "AdvBase_InitializeGame_14151");

                CB!.Verb_NW = Verbs.AddLoca("AdvBase_InitializeGame_14152");
                Verbs.AddLoca(CB!.Verb_NW.ID, "AdvBase_InitializeGame_14153");
                Verbs.AddLoca(CB!.Verb_NW.ID, "AdvBase_InitializeGame_14154");

                CB!.Verb_U = Verbs.AddLoca("AdvBase_InitializeGame_14155");
                Verbs.AddLoca(CB!.Verb_U.ID, "AdvBase_InitializeGame_14156");
                Verbs.AddLoca(CB!.Verb_U.ID, "AdvBase_InitializeGame_14157");
                Verbs.AddLoca(CB!.Verb_U.ID, "AdvBase_InitializeGame_14158");
                Verbs.AddLoca(CB!.Verb_U.ID, "AdvBase_InitializeGame_14159");

                CB!.Verb_D = Verbs.AddLoca("AdvBase_InitializeGame_14160");
                Verbs.AddLoca(CB!.Verb_D.ID, "AdvBase_InitializeGame_14161");
                Verbs.AddLoca(CB!.Verb_D.ID, "AdvBase_InitializeGame_14162");
                Verbs.AddLoca(CB!.Verb_D.ID, "AdvBase_InitializeGame_14163");
                Verbs.AddLoca(CB!.Verb_D.ID, "AdvBase_InitializeGame_14164");
                Verbs.AddLoca(CB!.Verb_D.ID, "AdvBase_InitializeGame_14165");

                CB!.Verb_Inventory = Verbs.AddLoca("AdvBase_InitializeGame_14166");
                Verbs.AddLoca(CB!.Verb_Inventory.ID, "AdvBase_InitializeGame_14167");
                Verbs.AddLoca(CB!.Verb_Inventory.ID, "AdvBase_InitializeGame_14168");
                Verbs.AddLoca(CB!.Verb_Inventory.ID, "AdvBase_InitializeGame_14169");

                CB!.Verb_location = Verbs.AddLoca("AdvBase_InitializeGame_14170");
                Verbs.AddLoca(CB!.Verb_location.ID, "AdvBase_InitializeGame_14171");
                Verbs.AddLoca(CB!.Verb_location.ID, "AdvBase_InitializeGame_14172");
                Verbs.AddLoca(CB!.Verb_location.ID, "AdvBase_InitializeGame_14173");
                Verbs.AddLoca(CB!.Verb_location.ID, "AdvBase_InitializeGame_14174");

                CB!.Verb_Examine = Verbs.AddLoca("AdvBase_InitializeGame_14175");
                Verbs.AddLoca(CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14176");
                Verbs.AddLoca(CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14177");
                Verbs.AddLoca(CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14178");
                Verbs.AddLoca(CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14179");
                Verbs.AddLoca(CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14180");
                Verbs.AddLoca(CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14181");
                Verbs.AddLoca(CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14182");
                Verbs.AddLoca(CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14183");
                Verbs.AddLoca(CB!.Verb_Examine.ID, "AdvBase_InitializeGame_14184");

                CB!.Verb_Take = Verbs.AddLoca("AdvBase_InitializeGame_14185");
                Verbs.AddLoca(CB!.Verb_Take.ID, "AdvBase_InitializeGame_14186");
                Verbs.AddLoca(CB!.Verb_Take.ID, "AdvBase_InitializeGame_14187");

                CB!.Verb_Go = Verbs.AddLoca("AdvBase_InitializeGame_14188");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14189");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14190");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14191");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14192");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14193");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14194");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14195");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14196");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14197");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14198");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14199");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14200");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14201");
                Verbs.AddLoca(CB!.Verb_Go.ID, "AdvBase_InitializeGame_14202");

                CB!.Verb_Enter = Verbs.AddLoca("AdvBase_InitializeGame_14203");
                Verbs.AddLoca(CB!.Verb_Enter.ID, "AdvBase_InitializeGame_14204");

                CB!.Verb_Climb = Verbs.AddLoca("AdvBase_InitializeGame_14205");
                Verbs.AddLoca(CB!.Verb_Climb.ID, "AdvBase_InitializeGame_14206");
                Verbs.AddLoca(CB!.Verb_Climb.ID, "AdvBase_InitializeGame_14207");
                Verbs.AddLoca(CB!.Verb_Climb.ID, "AdvBase_InitializeGame_14208");
                Verbs.AddLoca(CB!.Verb_Climb.ID, "AdvBase_InitializeGame_14209");

                CB!.Verb_Use = Verbs.AddLoca("AdvBase_InitializeGame_14210");
                Verbs.AddLoca(CB!.Verb_Use.ID, "AdvBase_InitializeGame_14211");

                CB!.Verb_Unscrew = Verbs.AddLoca("AdvBase_InitializeGame_Unscrew");

                CB!.Verb_Truncate = Verbs.AddLoca("AdvBase_InitializeGame_Truncate");

                CB!.Verb_Words = Verbs.AddLoca("AdvBase_InitializeGame_14212");

                CB!.Verb_Verbs = Verbs.AddLoca("AdvBase_InitializeGame_14213");
                Verbs.AddLoca(CB!.Verb_Verbs.ID, "AdvBase_InitializeGame_14214");

                CB!.Verb_ProtOn = Verbs.AddLoca("AdvBase_InitializeGame_14215");
                CB!.Verb_ProtOff = Verbs.AddLoca("AdvBase_InitializeGame_14216");


                CB!.Verb_Drop = Verbs.AddLoca("AdvBase_InitializeGame_14217");
                Verbs.AddLoca(CB!.Verb_Drop.ID, "AdvBase_InitializeGame_14218");
                Verbs.AddLoca(CB!.Verb_Drop.ID, "AdvBase_InitializeGame_14219");

                CB!.Verb_Place = Verbs.AddLoca("AdvBase_InitializeGame_14220");
                Verbs.AddLoca(CB!.Verb_Place.ID, "AdvBase_InitializeGame_14221");
                Verbs.AddLoca(CB!.Verb_Place.ID, "AdvBase_InitializeGame_14222");
                Verbs.AddLoca(CB!.Verb_Place.ID, "AdvBase_InitializeGame_14223");
                Verbs.AddLoca(CB!.Verb_Place.ID, "AdvBase_InitializeGame_14224");
                Verbs.AddLoca(CB!.Verb_Place.ID, "AdvBase_InitializeGame_14225");
                Verbs.AddLoca(CB!.Verb_Place.ID, "AdvBase_InitializeGame_14226");
                Verbs.AddLoca(CB!.Verb_Place.ID, "AdvBase_InitializeGame_14227");

                CB!.Verb_Open = Verbs.AddLoca("AdvBase_InitializeGame_14228");

                CB!.Verb_Close = Verbs.AddLoca("AdvBase_InitializeGame_14229");
                Verbs.AddLoca(CB!.Verb_Close.ID, "AdvBase_InitializeGame_14230");
                Verbs.AddLoca(CB!.Verb_Close.ID, "AdvBase_InitializeGame_14231");
                Verbs.AddLoca(CB!.Verb_Close.ID, "AdvBase_InitializeGame_14232");

                CB!.Verb_Lock_W = Verbs.AddLoca("AdvBase_InitializeGame_14233");
                Verbs.AddLoca(CB!.Verb_Lock_W.ID, "AdvBase_InitializeGame_14234");
                Verbs.AddLoca(CB!.Verb_Lock_W.ID, "AdvBase_InitializeGame_14235");
                Verbs.AddLoca(CB!.Verb_Lock_W.ID, "AdvBase_InitializeGame_14236");

                CB!.Verb_Save = Verbs.AddLoca("AdvBase_InitializeGame_14237");
                Verbs.AddLoca(CB!.Verb_Save.ID, "AdvBase_InitializeGame_14238");
                Verbs.AddLoca(CB!.Verb_Save.ID, "AdvBase_InitializeGame_14239");

                CB!.Verb_Load = Verbs.AddLoca("AdvBase_InitializeGame_14240");
                Verbs.AddLoca(CB!.Verb_Load.ID, "AdvBase_InitializeGame_14241");
                Verbs.AddLoca(CB!.Verb_Load.ID, "AdvBase_InitializeGame_14242");

                CB!.Verb_Help = Verbs.AddLoca("AdvBase_InitializeGame_14243");
                Verbs.AddLoca(CB!.Verb_Help.ID, "AdvBase_InitializeGame_14244");
                Verbs.AddLoca(CB!.Verb_Help.ID, "AdvBase_InitializeGame_14245");
                Verbs.AddLoca(CB!.Verb_Help.ID, "AdvBase_InitializeGame_14246");
                Verbs.AddLoca(CB!.Verb_Help.ID, "AdvBase_InitializeGame_14247");
                Verbs.AddLoca(CB!.Verb_Help.ID, "AdvBase_InitializeGame_14248");
                Verbs.AddLoca(CB!.Verb_Help.ID, "AdvBase_InitializeGame_14249");
                Verbs.AddLoca(CB!.Verb_Help.ID, "AdvBase_InitializeGame_14250");
                Verbs.AddLoca(CB!.Verb_Help.ID, "AdvBase_InitializeGame_14251");

                CB!.Verb_Info = Verbs.AddLoca("AdvBase_InitializeGame_14252");

                CB!.Verb_Clue = Verbs.AddLoca("AdvBase_InitializeGame_14253");

                CB!.Verb_Solution = Verbs.AddLoca("AdvBase_InitializeGame_14254");

                CB!.Verb_Give = Verbs.AddLoca("AdvBase_InitializeGame_14255");
                Verbs.AddLoca(CB!.Verb_Give.ID, "AdvBase_InitializeGame_14256");
                Verbs.AddLoca(CB!.Verb_Give.ID, "AdvBase_InitializeGame_14257");
                Verbs.AddLoca(CB!.Verb_Give.ID, "AdvBase_InitializeGame_14258");
                Verbs.AddLoca(CB!.Verb_Give.ID, "AdvBase_InitializeGame_14259");

                CB!.Verb_Show = Verbs.AddLoca("AdvBase_InitializeGame_14260");
                Verbs.AddLoca(CB!.Verb_Show.ID, "AdvBase_InitializeGame_14261");

                CB!.Verb_Plea = Verbs.AddLoca("AdvBase_InitializeGame_14262");
                Verbs.AddLoca(CB!.Verb_Plea.ID, "AdvBase_InitializeGame_14263");
                Verbs.AddLoca(CB!.Verb_Plea.ID, "AdvBase_InitializeGame_14264");
                Verbs.AddLoca(CB!.Verb_Plea.ID, "AdvBase_InitializeGame_14265");
                Verbs.AddLoca(CB!.Verb_Plea.ID, "AdvBase_InitializeGame_14266");

                CB!.Verb_Demand = Verbs.AddLoca("AdvBase_InitializeGame_14267");
                Verbs.AddLoca(CB!.Verb_Demand.ID, "AdvBase_InitializeGame_14268");

                CB!.Verb_Say = Verbs.AddLoca("AdvBase_InitializeGame_14269");
                Verbs.AddLoca(CB!.Verb_Say.ID, "AdvBase_InitializeGame_14270");
                Verbs.AddLoca(CB!.Verb_Say.ID, "AdvBase_InitializeGame_14271");
                Verbs.AddLoca(CB!.Verb_Say.ID, "AdvBase_InitializeGame_14272");
                Verbs.AddLoca(CB!.Verb_Say.ID, "AdvBase_InitializeGame_14273");
                Verbs.AddLoca(CB!.Verb_Say.ID, "AdvBase_InitializeGame_14274");
                Verbs.AddLoca(CB!.Verb_Say.ID, "AdvBase_InitializeGame_14275");

                CB!.Verb_Ask = Verbs.AddLoca("AdvBase_InitializeGame_14276");
                Verbs.AddLoca(CB!.Verb_Ask.ID, "AdvBase_InitializeGame_14277");

                CB!.Verb_Taste = Verbs.AddLoca("AdvBase_InitializeGame_14278");
                Verbs.AddLoca(CB!.Verb_Taste.ID, "AdvBase_InitializeGame_14279");

                CB!.Verb_Smell = Verbs.AddLoca("AdvBase_InitializeGame_14280");
                Verbs.AddLoca(CB!.Verb_Smell.ID, "AdvBase_InitializeGame_14281");

                CB!.Verb_Wait = Verbs.AddLoca("AdvBase_InitializeGame_14282");
                Verbs.AddLoca(CB!.Verb_Wait.ID, "AdvBase_InitializeGame_14283");
                Verbs.AddLoca(CB!.Verb_Wait.ID, "AdvBase_InitializeGame_14284");
                Verbs.AddLoca(CB!.Verb_Wait.ID, "AdvBase_InitializeGame_14285");
                Verbs.AddLoca(CB!.Verb_Wait.ID, "AdvBase_InitializeGame_14286");
                Verbs.AddLoca(CB!.Verb_Wait.ID, "AdvBase_InitializeGame_14287");

                CB!.Verb_Quit = Verbs.AddLoca("AdvBase_InitializeGame_14288");
                Verbs.AddLoca(CB!.Verb_Quit.ID, "AdvBase_InitializeGame_14289");
                Verbs.AddLoca(CB!.Verb_Quit.ID, "AdvBase_InitializeGame_14290");

                CB!.Verb_Restart = Verbs.AddLoca("AdvBase_InitializeGame_14291");
                Verbs.AddLoca(CB!.Verb_Restart.ID, "AdvBase_InitializeGame_14292");

                CB!.Verb_Startpoint = Verbs.AddLoca("AdvBase_InitializeGame_14293");
                Verbs.AddLoca(CB!.Verb_Startpoint.ID, "AdvBase_InitializeGame_14294");
                Verbs.AddLoca(CB!.Verb_Startpoint.ID, "AdvBase_InitializeGame_14295");
                */
            }

            if (LoadedInitData == null)
            {
                CB!.Prep_mit = Preps.AddLoca("AdvBase_InitializeGame_14296");
                CB!.Prep_in = Preps.AddLoca("AdvBase_InitializeGame_14297");
                Preps.AddLoca(CB!.Prep_in.ID, "AdvBase_InitializeGame_14298");
                Preps.AddLoca(CB!.Prep_in.ID, "AdvBase_InitializeGame_14299");
                CB!.Prep_nach = Preps.AddLoca("AdvBase_InitializeGame_14300");
                CB!.Prep_ab = Preps.AddLoca("AdvBase_InitializeGame_14301");
                CB!.Prep_weg = Preps.AddLoca("AdvBase_InitializeGame_14302");
                CB!.Prep_zu = Preps.AddLoca("AdvBase_InitializeGame_14303");
                Preps.AddLoca(CB!.Prep_zu.ID, "AdvBase_InitializeGame_14304");
                Preps.AddLoca(CB!.Prep_zu.ID, "AdvBase_InitializeGame_14305");
                CB!.Prep_gegen = Preps.AddLoca("AdvBase_InitializeGame_14306");

                CB!.Prep_auf = Preps.AddLoca("AdvBase_InitializeGame_14307");
                CB!.Prep_hinter = Preps.AddLoca("AdvBase_InitializeGame_14308");
                CB!.Prep_unter = Preps.AddLoca("AdvBase_InitializeGame_14309");
                CB!.Prep_neben = Preps.AddLoca("AdvBase_InitializeGame_14310");
                CB!.Prep_aus = Preps.AddLoca("AdvBase_InitializeGame_14311");
                CB!.Prep_von = Preps.AddLoca("AdvBase_InitializeGame_14312");
                CB!.Prep_Slot1 = Preps.AddLoca("AdvBase_InitializeGame_14313");
                CB!.Prep_Slot2 = Preps.AddLoca("AdvBase_InitializeGame_14314");
                CB!.Prep_Slot3 = Preps.AddLoca("AdvBase_InitializeGame_14315");
                CB!.Prep_Slot4 = Preps.AddLoca("AdvBase_InitializeGame_14316");
                CB!.Prep_Slot5 = Preps.AddLoca("AdvBase_InitializeGame_14317");
                CB!.Prep_Slot6 = Preps.AddLoca("AdvBase_InitializeGame_14318");
                CB!.Prep_Slot7 = Preps.AddLoca("AdvBase_InitializeGame_14319");
                CB!.Prep_Slot8 = Preps.AddLoca("AdvBase_InitializeGame_14320");
                CB!.Prep_Slot9 = Preps.AddLoca("AdvBase_InitializeGame_14321");
                CB!.Prep_Slot10 = Preps.AddLoca("AdvBase_InitializeGame_14322");
                CB!.Prep_an = Preps.AddLoca("AdvBase_InitializeGame_14323");
                Preps.AddLoca(CB!.Prep_an.ID, "AdvBase_InitializeGame_14324");
                CB!.Prep_hoch = Preps.AddLoca("AdvBase_InitializeGame_14325");
                Preps.AddLoca(CB!.Prep_hoch.ID, "AdvBase_InitializeGame_14326");
                CB!.Prep_runter = Preps.AddLoca("AdvBase_InitializeGame_14327");
                Preps.AddLoca(CB!.Prep_runter.ID, "AdvBase_InitializeGame_14328");
                Preps.AddLoca(CB!.Prep_runter.ID, "AdvBase_InitializeGame_14329");
                CB!.Prep_durch = Preps.AddLoca("AdvBase_InitializeGame_14330");
                Preps.AddLoca(CB!.Prep_durch.ID, "AdvBase_InitializeGame_14331");
                CB!.Prep_zurueck = Preps.AddLoca("AdvBase_InitializeGame_14332");
                CB!.Prep_alles = Preps.AddLoca("AdvBase_InitializeGame_14333");
                CB!.Prep_heraus = Preps.AddLoca("AdvBase_InitializeGame_14334");
                CB!.Prep_los = Preps.AddLoca("AdvBase_InitializeGame_14335");
                CB!.Prep_um = Preps.AddLoca("AdvBase_InitializeGame_14336");
                CB!.Prep_ueber = Preps.AddLoca("AdvBase_InitializeGame_14337");
                CB!.Prep_fest = Preps.AddLoca("AdvBase_InitializeGame_14338");
                CB!.Prep_hin = Preps.AddLoca("AdvBase_InitializeGame_14339");
                CB!.Prep_ein = Preps.AddLoca("AdvBase_InitializeGame_14340");
                CB!.Prep_Wer = Preps.AddLoca("AdvBase_InitializeGame_14341");
                CB!.Prep_herum = Preps.AddLoca("AdvBase_InitializeGame_14342");
                CB!.Prep_stehen = Preps.AddLoca("AdvBase_InitializeGame_14343");

                CB!.Prep_Stufe1 = Preps.AddLoca("AdvBase_InitializeGame_14344");
                CB!.Prep_Stufe2 = Preps.AddLoca("AdvBase_InitializeGame_14345");
                CB!.Prep_Stufe3 = Preps.AddLoca("AdvBase_InitializeGame_14346");


                CB!.Prep_with = Preps.AddLoca("AdvBase_InitializeGame_prep_with");
                CB!.Prep_to = Preps.AddLoca("AdvBase_InitializeGame_prep_to");
                CB!.Prep_off = Preps.AddLoca("AdvBase_InitializeGame_prep_off");
                CB!.Prep_away = Preps.AddLoca("AdvBase_InitializeGame__prep_away");
                CB!.Prep_towards = Preps.AddLoca("AdvBase_InitializeGame_prep_towards");
                CB!.Prep_against = Preps.AddLoca("AdvBase_InitializeGame_prep_against");

                CB!.Prep_on = Preps.AddLoca("AdvBase_InitializeGame_prep_on");
                CB!.Prep_behind = Preps.AddLoca("AdvBase_InitializeGame_prep_behind");
                CB!.Prep_under = Preps.AddLoca("AdvBase_InitializeGame_prep_under");
                CB!.Prep_beside = Preps.AddLoca("AdvBase_InitializeGame_prep_beside");
                CB!.Prep_out = Preps.AddLoca("AdvBase_InitializeGame_prep_out");
                CB!.Prep_from = Preps.AddLoca("AdvBase_InitializeGame_prep_from");
                CB!.Prep_at = Preps.AddLoca("AdvBase_InitializeGame_prep_at");
                CB!.Prep_through = Preps.AddLoca("AdvBase_InitializeGame_prep_through");
                CB!.Prep_back = Preps.AddLoca("AdvBase_InitializeGame_prep_back");
                CB!.Prep_over = Preps.AddLoca("AdvBase_InitializeGame_prep_over");
                CB!.Prep_upon = Preps.AddLoca("AdvBase_InitializeGame_prep_upon");
                CB!.Prep_around = Preps.AddLoca("AdvBase_InitializeGame_prep_around");
                CB!.Prep_all = Preps.AddLoca("AdvBase_InitializeGame_prep_all");
                CB!.Prep_about = Preps.AddLoca("AdvBase_InitializeGame_prep_about");
                CB!.Prep_of = Preps.AddLoca("AdvBase_InitializeGame_prep_of");

                CB!.Prep_for = Preps.AddLoca("AdvBase_InitializeGame_prep_for");
                CB!.Prep_into = Preps.AddLoca("AdvBase_InitializeGame_prep_into");
            }
            else
            {
                Preps = LoadPreps();
            }

            /*
             CB!.Pronoun_Male = Pronouns.Add(new Pronoun( "er", Co.SEX_MALE));
             Pronouns.Add(new Pronoun(CB!.Pronoun_Male.ID, "ihn", Co.SEX_MALE));
             Pronouns.Add(new Pronoun(CB!.Pronoun_Male.ID, "ihm", Co.SEX_MALE));

             CB!.Pronoun_Female = Pronouns.Add(new Pronoun( "sie", Co.SEX_FEMALE));
             Pronouns.Add(new Pronoun(CB!.Pronoun_Female.ID, "ihr", Co.SEX_FEMALE));

             CB!.Pronoun_Neuter = Pronouns.Add(new Pronoun( "es", Co.SEX_NEUTER));
             Pronouns.Add(new Pronoun(CB!.Pronoun_Male.ID, "ihn", Co.SEX_MALE));
             Pronouns.Add(new Pronoun(CB!.Pronoun_Male.ID, "ihm", Co.SEX_MALE));

             CB!.Pronoun_Male_PL = Pronouns.Add(new Pronoun( "sie", Co.SEX_MALE_PL));
             Pronouns.Add(new Pronoun(CB!.Pronoun_Male_PL.ID, "ihnen", Co.SEX_MALE_PL));

             CB!.Pronoun_Female_PL = Pronouns.Add(new Pronoun( "sie", Co.SEX_FEMALE_PL));
             Pronouns.Add(new Pronoun(CB!.Pronoun_Female_PL.ID, "ihnen", Co.SEX_FEMALE_PL));

             CB!.Pronoun_Neuter_PL = Pronouns.Add(new Pronoun( "sie", Co.SEX_NEUTER_PL));
             Pronouns.Add(new Pronoun(CB!.Pronoun_Neuter_PL.ID, "ihnen", Co.SEX_NEUTER_PL));
             */
            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14347", Co.SEX_MALE));
            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14348", Co.SEX_MALE));
            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14349", Co.SEX_MALE));

            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14350", Co.SEX_FEMALE));
            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14351", Co.SEX_FEMALE));

            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14352", Co.SEX_NEUTER));
            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14353", Co.SEX_MALE));
            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14354", Co.SEX_MALE));

            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14355", Co.SEX_MALE_PL));
            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14356", Co.SEX_MALE_PL));

            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14357", Co.SEX_FEMALE_PL));
            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14358", Co.SEX_FEMALE_PL));

            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14359", Co.SEX_NEUTER_PL));
            Pronouns.Add(Pronoun.PronounLoca("AdvBase_InitializeGame_14360", Co.SEX_NEUTER_PL));

            // FL = new List<Fill>();
            Fills.Add(Fills.AddLoca("AdvBase_InitializeGame_14361"));
            Fills.Add(Fills.AddLoca("AdvBase_InitializeGame_14362"));
            Fills.Add(Fills.AddLoca("AdvBase_InitializeGame_14363"));
            Fills.Add(Fills.AddLoca("AdvBase_InitializeGame_14364"));
            Fills.Add(Fills.AddLoca("AdvBase_InitializeGame_14365"));
            Fills.Add(Fills.AddLoca("AdvBase_InitializeGame_14366"));
            Fills.Add(Fills.AddLoca("AdvBase_InitializeGame_14367"));
            Fills.Add(Fills.AddLoca("AdvBase_InitializeGame_14368"));


            // Verben initialisieren
            VerbTenses = new VTList();

            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_gehen, "AdvBase_InitializeGame_14369", "AdvBase_InitializeGame_14370", "AdvBase_InitializeGame_14371", "AdvBase_InitializeGame_14372", "AdvBase_InitializeGame_14373", "AdvBase_InitializeGame_14374", "AdvBase_InitializeGame_14375", "AdvBase_InitializeGame_14376", "AdvBase_InitializeGame_14377", "AdvBase_InitializeGame_14378", "AdvBase_InitializeGame_14379", "AdvBase_InitializeGame_14380", "AdvBase_InitializeGame_14381"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_nehmen, "AdvBase_InitializeGame_14382", "AdvBase_InitializeGame_14383", "AdvBase_InitializeGame_14384", "AdvBase_InitializeGame_14385", "AdvBase_InitializeGame_14386", "AdvBase_InitializeGame_14387", "AdvBase_InitializeGame_14388", "AdvBase_InitializeGame_14389", "AdvBase_InitializeGame_14390", "AdvBase_InitializeGame_14391", "AdvBase_InitializeGame_14392", "AdvBase_InitializeGame_14393", "AdvBase_InitializeGame_14394"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_oeffnen, "AdvBase_InitializeGame_14395", "AdvBase_InitializeGame_14396", "AdvBase_InitializeGame_14397", "AdvBase_InitializeGame_14398", "AdvBase_InitializeGame_14399", "AdvBase_InitializeGame_14400", "AdvBase_InitializeGame_14401", "AdvBase_InitializeGame_14402", "AdvBase_InitializeGame_14403", "AdvBase_InitializeGame_14404", "AdvBase_InitializeGame_14405", "AdvBase_InitializeGame_14406", "AdvBase_InitializeGame_14407"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_schliessen, "AdvBase_InitializeGame_14408", "AdvBase_InitializeGame_14409", "AdvBase_InitializeGame_14410", "AdvBase_InitializeGame_14411", "AdvBase_InitializeGame_14412", "AdvBase_InitializeGame_14413", "AdvBase_InitializeGame_14414", "AdvBase_InitializeGame_14415", "AdvBase_InitializeGame_14416", "AdvBase_InitializeGame_14417", "AdvBase_InitializeGame_14418", "AdvBase_InitializeGame_14419", "AdvBase_InitializeGame_14420"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_untersuchen, "AdvBase_InitializeGame_14421", "AdvBase_InitializeGame_14422", "AdvBase_InitializeGame_14423", "AdvBase_InitializeGame_14424", "AdvBase_InitializeGame_14425", "AdvBase_InitializeGame_14426", "AdvBase_InitializeGame_14427", "AdvBase_InitializeGame_14428", "AdvBase_InitializeGame_14429", "AdvBase_InitializeGame_14430", "AdvBase_InitializeGame_14431", "AdvBase_InitializeGame_14432", "AdvBase_InitializeGame_14433"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_koennen, "AdvBase_InitializeGame_14434", "AdvBase_InitializeGame_14435", "AdvBase_InitializeGame_14436", "AdvBase_InitializeGame_14437", "AdvBase_InitializeGame_14438", "AdvBase_InitializeGame_14439", "AdvBase_InitializeGame_14440", "AdvBase_InitializeGame_14441", "AdvBase_InitializeGame_14442", "AdvBase_InitializeGame_14443", "AdvBase_InitializeGame_14444", "AdvBase_InitializeGame_14445", "AdvBase_InitializeGame_14446"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_haben, "AdvBase_InitializeGame_14447", "AdvBase_InitializeGame_14448", "AdvBase_InitializeGame_14449", "AdvBase_InitializeGame_14450", "AdvBase_InitializeGame_14451", "AdvBase_InitializeGame_14452", "AdvBase_InitializeGame_14453", "AdvBase_InitializeGame_14454", "AdvBase_InitializeGame_14455", "AdvBase_InitializeGame_14456", "AdvBase_InitializeGame_14457", "AdvBase_InitializeGame_14458", "AdvBase_InitializeGame_14459"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_holen, "AdvBase_InitializeGame_14460", "AdvBase_InitializeGame_14461", "AdvBase_InitializeGame_14462", "AdvBase_InitializeGame_14463", "AdvBase_InitializeGame_14464", "AdvBase_InitializeGame_14465", "AdvBase_InitializeGame_14466", "AdvBase_InitializeGame_14467", "AdvBase_InitializeGame_14468", "AdvBase_InitializeGame_14469", "AdvBase_InitializeGame_14470", "AdvBase_InitializeGame_14471", "AdvBase_InitializeGame_14472"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_ziehen, "AdvBase_InitializeGame_14473", "AdvBase_InitializeGame_14474", "AdvBase_InitializeGame_14475", "AdvBase_InitializeGame_14476", "AdvBase_InitializeGame_14477", "AdvBase_InitializeGame_14478", "AdvBase_InitializeGame_14479", "AdvBase_InitializeGame_14480", "AdvBase_InitializeGame_14481", "AdvBase_InitializeGame_14482", "AdvBase_InitializeGame_14483", "AdvBase_InitializeGame_14484", "AdvBase_InitializeGame_14485"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_schauen, "AdvBase_InitializeGame_14486", "AdvBase_InitializeGame_14487", "AdvBase_InitializeGame_14488", "AdvBase_InitializeGame_14489", "AdvBase_InitializeGame_14490", "AdvBase_InitializeGame_14491", "AdvBase_InitializeGame_14492", "AdvBase_InitializeGame_14493", "AdvBase_InitializeGame_14494", "AdvBase_InitializeGame_14495", "AdvBase_InitializeGame_14496", "AdvBase_InitializeGame_14497", "AdvBase_InitializeGame_14498"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_umschauen, "AdvBase_InitializeGame_14499", "AdvBase_InitializeGame_14500", "AdvBase_InitializeGame_14501", "AdvBase_InitializeGame_14502", "AdvBase_InitializeGame_14503", "AdvBase_InitializeGame_14504", "AdvBase_InitializeGame_14505", "AdvBase_InitializeGame_14506", "AdvBase_InitializeGame_14507", "AdvBase_InitializeGame_14508", "AdvBase_InitializeGame_14509", "AdvBase_InitializeGame_14510", "AdvBase_InitializeGame_14511"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_anschauen, "AdvBase_InitializeGame_14512", "AdvBase_InitializeGame_14513", "AdvBase_InitializeGame_14514", "AdvBase_InitializeGame_14515", "AdvBase_InitializeGame_14516", "AdvBase_InitializeGame_14517", "AdvBase_InitializeGame_14518", "AdvBase_InitializeGame_14519", "AdvBase_InitializeGame_14520", "AdvBase_InitializeGame_14521", "AdvBase_InitializeGame_14522", "AdvBase_InitializeGame_14523", "AdvBase_InitializeGame_14524"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_legen, "AdvBase_InitializeGame_14525", "AdvBase_InitializeGame_14526", "AdvBase_InitializeGame_14527", "AdvBase_InitializeGame_14528", "AdvBase_InitializeGame_14529", "AdvBase_InitializeGame_14530", "AdvBase_InitializeGame_14531", "AdvBase_InitializeGame_14532", "AdvBase_InitializeGame_14533", "AdvBase_InitializeGame_14534", "AdvBase_InitializeGame_14535", "AdvBase_InitializeGame_14536", "AdvBase_InitializeGame_14537"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_sehen, "AdvBase_InitializeGame_14538", "AdvBase_InitializeGame_14539", "AdvBase_InitializeGame_14540", "AdvBase_InitializeGame_14541", "AdvBase_InitializeGame_14542", "AdvBase_InitializeGame_14543", "AdvBase_InitializeGame_14544", "AdvBase_InitializeGame_14545", "AdvBase_InitializeGame_14546", "AdvBase_InitializeGame_14547", "AdvBase_InitializeGame_14548", "AdvBase_InitializeGame_14549", "AdvBase_InitializeGame_14550"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_geben, "AdvBase_InitializeGame_14551", "AdvBase_InitializeGame_14552", "AdvBase_InitializeGame_14553", "AdvBase_InitializeGame_14554", "AdvBase_InitializeGame_14555", "AdvBase_InitializeGame_14556", "AdvBase_InitializeGame_14557", "AdvBase_InitializeGame_14558", "AdvBase_InitializeGame_14559", "AdvBase_InitializeGame_14560", "AdvBase_InitializeGame_14561", "AdvBase_InitializeGame_14562", "AdvBase_InitializeGame_14563"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_stehen, "AdvBase_InitializeGame_14564", "AdvBase_InitializeGame_14565", "AdvBase_InitializeGame_14566", "AdvBase_InitializeGame_14567", "AdvBase_InitializeGame_14568", "AdvBase_InitializeGame_14569", "AdvBase_InitializeGame_14570", "AdvBase_InitializeGame_14571", "AdvBase_InitializeGame_14572", "AdvBase_InitializeGame_14573", "AdvBase_InitializeGame_14574", "AdvBase_InitializeGame_14575", "AdvBase_InitializeGame_14576"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_sein, "AdvBase_InitializeGame_14577", "AdvBase_InitializeGame_14578", "AdvBase_InitializeGame_14579", "AdvBase_InitializeGame_14580", "AdvBase_InitializeGame_14581", "AdvBase_InitializeGame_14582", "AdvBase_InitializeGame_14583", "AdvBase_InitializeGame_14584", "AdvBase_InitializeGame_14585", "AdvBase_InitializeGame_14586", "AdvBase_InitializeGame_14587", "AdvBase_InitializeGame_14588", "AdvBase_InitializeGame_14589"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_kauern, "AdvBase_InitializeGame_14590", "AdvBase_InitializeGame_14591", "AdvBase_InitializeGame_14592", "AdvBase_InitializeGame_14593", "AdvBase_InitializeGame_14594", "AdvBase_InitializeGame_14595", "AdvBase_InitializeGame_14596", "AdvBase_InitializeGame_14597", "AdvBase_InitializeGame_14598", "AdvBase_InitializeGame_14599", "AdvBase_InitializeGame_14600", "AdvBase_InitializeGame_14601", "AdvBase_InitializeGame_14602"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_herumzerren, "AdvBase_InitializeGame_14603", "AdvBase_InitializeGame_14604", "AdvBase_InitializeGame_14605", "AdvBase_InitializeGame_14606", "AdvBase_InitializeGame_14607", "AdvBase_InitializeGame_14608", "AdvBase_InitializeGame_14609", "AdvBase_InitializeGame_14610", "AdvBase_InitializeGame_14611", "AdvBase_InitializeGame_14612", "AdvBase_InitializeGame_14613", "AdvBase_InitializeGame_14614", "AdvBase_InitializeGame_14615"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_halten, "AdvBase_InitializeGame_14616", "AdvBase_InitializeGame_14617", "AdvBase_InitializeGame_14618", "AdvBase_InitializeGame_14619", "AdvBase_InitializeGame_14620", "AdvBase_InitializeGame_14621", "AdvBase_InitializeGame_14622", "AdvBase_InitializeGame_14623", "AdvBase_InitializeGame_14624", "AdvBase_InitializeGame_14625", "AdvBase_InitializeGame_14626", "AdvBase_InitializeGame_14627", "AdvBase_InitializeGame_14628"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_wollen, "AdvBase_InitializeGame_14629", "AdvBase_InitializeGame_14630", "AdvBase_InitializeGame_14631", "AdvBase_InitializeGame_14632", "AdvBase_InitializeGame_14633", "AdvBase_InitializeGame_14634", "AdvBase_InitializeGame_14635", "AdvBase_InitializeGame_14636", "AdvBase_InitializeGame_14637", "AdvBase_InitializeGame_14638", "AdvBase_InitializeGame_14639", "AdvBase_InitializeGame_14640", "AdvBase_InitializeGame_14641"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_bitten, "AdvBase_InitializeGame_14642", "AdvBase_InitializeGame_14643", "AdvBase_InitializeGame_14644", "AdvBase_InitializeGame_14645", "AdvBase_InitializeGame_14646", "AdvBase_InitializeGame_14647", "AdvBase_InitializeGame_14648", "AdvBase_InitializeGame_14649", "AdvBase_InitializeGame_14650", "AdvBase_InitializeGame_14651", "AdvBase_InitializeGame_14652", "AdvBase_InitializeGame_14653", "AdvBase_InitializeGame_14654"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_fordern, "AdvBase_InitializeGame_14655", "AdvBase_InitializeGame_14656", "AdvBase_InitializeGame_14657", "AdvBase_InitializeGame_14658", "AdvBase_InitializeGame_14659", "AdvBase_InitializeGame_14660", "AdvBase_InitializeGame_14661", "AdvBase_InitializeGame_14662", "AdvBase_InitializeGame_14663", "AdvBase_InitializeGame_14664", "AdvBase_InitializeGame_14665", "AdvBase_InitializeGame_14666", "AdvBase_InitializeGame_14667"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_setzen, "AdvBase_InitializeGame_14668", "AdvBase_InitializeGame_14669", "AdvBase_InitializeGame_14670", "AdvBase_InitializeGame_14671", "AdvBase_InitializeGame_14672", "AdvBase_InitializeGame_14673", "AdvBase_InitializeGame_14674", "AdvBase_InitializeGame_14675", "AdvBase_InitializeGame_14676", "AdvBase_InitializeGame_14677", "AdvBase_InitializeGame_14678", "AdvBase_InitializeGame_14679", "AdvBase_InitializeGame_14680"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_setzen, "AdvBase_InitializeGame_14681", "AdvBase_InitializeGame_14682", "AdvBase_InitializeGame_14683", "AdvBase_InitializeGame_14684", "AdvBase_InitializeGame_14685", "AdvBase_InitializeGame_14686", "AdvBase_InitializeGame_14687", "AdvBase_InitializeGame_14688", "AdvBase_InitializeGame_14689", "AdvBase_InitializeGame_14690", "AdvBase_InitializeGame_14691", "AdvBase_InitializeGame_14692", "AdvBase_InitializeGame_14693"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_finden, "AdvBase_InitializeGame_14694", "AdvBase_InitializeGame_14695", "AdvBase_InitializeGame_14696", "AdvBase_InitializeGame_14697", "AdvBase_InitializeGame_14698", "AdvBase_InitializeGame_14699", "AdvBase_InitializeGame_14700", "AdvBase_InitializeGame_14701", "AdvBase_InitializeGame_14702", "AdvBase_InitializeGame_14703", "AdvBase_InitializeGame_14704", "AdvBase_InitializeGame_14705", "AdvBase_InitializeGame_14706"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_aufstehen, "AdvBase_InitializeGame_14707", "AdvBase_InitializeGame_14708", "AdvBase_InitializeGame_14709", "AdvBase_InitializeGame_14710", "AdvBase_InitializeGame_14711", "AdvBase_InitializeGame_14712", "AdvBase_InitializeGame_14713", "AdvBase_InitializeGame_14714", "AdvBase_InitializeGame_14715", "AdvBase_InitializeGame_14716", "AdvBase_InitializeGame_14717", "AdvBase_InitializeGame_14718", "AdvBase_InitializeGame_14719"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_strangulieren, "AdvBase_InitializeGame_14720", "AdvBase_InitializeGame_14721", "AdvBase_InitializeGame_14722", "AdvBase_InitializeGame_14723", "AdvBase_InitializeGame_14724", "AdvBase_InitializeGame_14725", "AdvBase_InitializeGame_14726", "AdvBase_InitializeGame_14727", "AdvBase_InitializeGame_14728", "AdvBase_InitializeGame_14729", "AdvBase_InitializeGame_14730", "AdvBase_InitializeGame_14731", "AdvBase_InitializeGame_14732"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_druecken, "AdvBase_InitializeGame_14733", "AdvBase_InitializeGame_14734", "AdvBase_InitializeGame_14735", "AdvBase_InitializeGame_14736", "AdvBase_InitializeGame_14737", "AdvBase_InitializeGame_14738", "AdvBase_InitializeGame_14739", "AdvBase_InitializeGame_14740", "AdvBase_InitializeGame_14741", "AdvBase_InitializeGame_14742", "AdvBase_InitializeGame_14743", "AdvBase_InitializeGame_14744", "AdvBase_InitializeGame_14745"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_fallen, "AdvBase_InitializeGame_14746", "AdvBase_InitializeGame_14747", "AdvBase_InitializeGame_14748", "AdvBase_InitializeGame_14749", "AdvBase_InitializeGame_14750", "AdvBase_InitializeGame_14751", "AdvBase_InitializeGame_14752", "AdvBase_InitializeGame_14753", "AdvBase_InitializeGame_14754", "AdvBase_InitializeGame_14755", "AdvBase_InitializeGame_14756", "AdvBase_InitializeGame_14757", "AdvBase_InitializeGame_14758"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_sagen, "AdvBase_InitializeGame_14759", "AdvBase_InitializeGame_14760", "AdvBase_InitializeGame_14761", "AdvBase_InitializeGame_14762", "AdvBase_InitializeGame_14763", "AdvBase_InitializeGame_14764", "AdvBase_InitializeGame_14765", "AdvBase_InitializeGame_14766", "AdvBase_InitializeGame_14767", "AdvBase_InitializeGame_14768", "AdvBase_InitializeGame_14769", "AdvBase_InitializeGame_14770", "AdvBase_InitializeGame_14771"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_blubbern, "Blubbern1", "Blubbern2", "Blubbern3", "Blubbern4", "Blubbern5", "Blubbern6", "Blubbern7", "Blubbern8", "Blubbern9", "Blubbern10", "Blubbern11", "Blubbern12", "Blubbern13"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_fragen, "AdvBase_InitializeGame_14772", "AdvBase_InitializeGame_14773", "AdvBase_InitializeGame_14774", "AdvBase_InitializeGame_14775", "AdvBase_InitializeGame_14776", "AdvBase_InitializeGame_14777", "AdvBase_InitializeGame_14778", "AdvBase_InitializeGame_14779", "AdvBase_InitializeGame_14780", "AdvBase_InitializeGame_14781", "AdvBase_InitializeGame_14782", "AdvBase_InitializeGame_14783", "AdvBase_InitializeGame_14784"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_lesen, "AdvBase_InitializeGame_14785", "AdvBase_InitializeGame_14786", "AdvBase_InitializeGame_14787", "AdvBase_InitializeGame_14788", "AdvBase_InitializeGame_14789", "AdvBase_InitializeGame_14790", "AdvBase_InitializeGame_14791", "AdvBase_InitializeGame_14792", "AdvBase_InitializeGame_14793", "AdvBase_InitializeGame_14794", "AdvBase_InitializeGame_14795", "AdvBase_InitializeGame_14796", "AdvBase_InitializeGame_14797"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_steigen, "AdvBase_InitializeGame_14798", "AdvBase_InitializeGame_14799", "AdvBase_InitializeGame_14800", "AdvBase_InitializeGame_14801", "AdvBase_InitializeGame_14802", "AdvBase_InitializeGame_14803", "AdvBase_InitializeGame_14804", "AdvBase_InitializeGame_14805", "AdvBase_InitializeGame_14806", "AdvBase_InitializeGame_14807", "AdvBase_InitializeGame_14808", "AdvBase_InitializeGame_14809", "AdvBase_InitializeGame_14810"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_schmecken, "AdvBase_InitializeGame_14811", "AdvBase_InitializeGame_14812", "AdvBase_InitializeGame_14813", "AdvBase_InitializeGame_14814", "AdvBase_InitializeGame_14815", "AdvBase_InitializeGame_14816", "AdvBase_InitializeGame_14817", "AdvBase_InitializeGame_14818", "AdvBase_InitializeGame_14819", "AdvBase_InitializeGame_14820", "AdvBase_InitializeGame_14821", "AdvBase_InitializeGame_14822", "AdvBase_InitializeGame_14823"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_riechen, "AdvBase_InitializeGame_14824", "AdvBase_InitializeGame_14825", "AdvBase_InitializeGame_14826", "AdvBase_InitializeGame_14827", "AdvBase_InitializeGame_14828", "AdvBase_InitializeGame_14829", "AdvBase_InitializeGame_14830", "AdvBase_InitializeGame_14831", "AdvBase_InitializeGame_14832", "AdvBase_InitializeGame_14833", "AdvBase_InitializeGame_14834", "AdvBase_InitializeGame_14835", "AdvBase_InitializeGame_14836"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_warten, "AdvBase_InitializeGame_14837", "AdvBase_InitializeGame_14838", "AdvBase_InitializeGame_14839", "AdvBase_InitializeGame_14840", "AdvBase_InitializeGame_14841", "AdvBase_InitializeGame_14842", "AdvBase_InitializeGame_14843", "AdvBase_InitializeGame_14844", "AdvBase_InitializeGame_14845", "AdvBase_InitializeGame_14846", "AdvBase_InitializeGame_14847", "AdvBase_InitializeGame_14848", "AdvBase_InitializeGame_14849"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_erscheinen, "AdvBase_InitializeGame_14850", "AdvBase_InitializeGame_14851", "AdvBase_InitializeGame_14852", "AdvBase_InitializeGame_14853", "AdvBase_InitializeGame_14854", "AdvBase_InitializeGame_14855", "AdvBase_InitializeGame_14856", "AdvBase_InitializeGame_14857", "AdvBase_InitializeGame_14858", "AdvBase_InitializeGame_14859", "AdvBase_InitializeGame_14860", "AdvBase_InitializeGame_14861", "AdvBase_InitializeGame_14862"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_loesen, "AdvBase_InitializeGame_14863", "AdvBase_InitializeGame_14864", "AdvBase_InitializeGame_14865", "AdvBase_InitializeGame_14866", "AdvBase_InitializeGame_14867", "AdvBase_InitializeGame_14868", "AdvBase_InitializeGame_14869", "AdvBase_InitializeGame_14870", "AdvBase_InitializeGame_14871", "AdvBase_InitializeGame_14872", "AdvBase_InitializeGame_14873", "AdvBase_InitializeGame_14874", "AdvBase_InitializeGame_14875"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_befinden, "AdvBase_InitializeGame_14876", "AdvBase_InitializeGame_14877", "AdvBase_InitializeGame_14878", "AdvBase_InitializeGame_14879", "AdvBase_InitializeGame_14880", "AdvBase_InitializeGame_14881", "AdvBase_InitializeGame_14882", "AdvBase_InitializeGame_14883", "AdvBase_InitializeGame_14884", "AdvBase_InitializeGame_14885", "AdvBase_InitializeGame_14886", "AdvBase_InitializeGame_14887", "AdvBase_InitializeGame_14888"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_brechen, "AdvBase_InitializeGame_14889", "AdvBase_InitializeGame_14890", "AdvBase_InitializeGame_14891", "AdvBase_InitializeGame_14892", "AdvBase_InitializeGame_14893", "AdvBase_InitializeGame_14894", "AdvBase_InitializeGame_14895", "AdvBase_InitializeGame_14896", "AdvBase_InitializeGame_14897", "AdvBase_InitializeGame_14898", "AdvBase_InitializeGame_14899", "AdvBase_InitializeGame_14900", "AdvBase_InitializeGame_14901"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_kraechzen, "AdvBase_InitializeGame_14902", "AdvBase_InitializeGame_14903", "AdvBase_InitializeGame_14904", "AdvBase_InitializeGame_14905", "AdvBase_InitializeGame_14906", "AdvBase_InitializeGame_14907", "AdvBase_InitializeGame_14908", "AdvBase_InitializeGame_14909", "AdvBase_InitializeGame_14910", "AdvBase_InitializeGame_14911", "AdvBase_InitializeGame_14912", "AdvBase_InitializeGame_14913", "AdvBase_InitializeGame_14914"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_greifen, "AdvBase_InitializeGame_14915", "AdvBase_InitializeGame_14916", "AdvBase_InitializeGame_14917", "AdvBase_InitializeGame_14918", "AdvBase_InitializeGame_14919", "AdvBase_InitializeGame_14920", "AdvBase_InitializeGame_14921", "AdvBase_InitializeGame_14922", "AdvBase_InitializeGame_14923", "AdvBase_InitializeGame_14924", "AdvBase_InitializeGame_14925", "AdvBase_InitializeGame_14926", "AdvBase_InitializeGame_14927"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_stochern, "AdvBase_InitializeGame_14928", "AdvBase_InitializeGame_14929", "AdvBase_InitializeGame_14930", "AdvBase_InitializeGame_14931", "AdvBase_InitializeGame_14932", "AdvBase_InitializeGame_14933", "AdvBase_InitializeGame_14934", "AdvBase_InitializeGame_14935", "AdvBase_InitializeGame_14936", "AdvBase_InitializeGame_14937", "AdvBase_InitializeGame_14938", "AdvBase_InitializeGame_14939", "AdvBase_InitializeGame_14940"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_versuchen, "AdvBase_InitializeGame_14941", "AdvBase_InitializeGame_14942", "AdvBase_InitializeGame_14943", "AdvBase_InitializeGame_14944", "AdvBase_InitializeGame_14945", "AdvBase_InitializeGame_14946", "AdvBase_InitializeGame_14947", "AdvBase_InitializeGame_14948", "AdvBase_InitializeGame_14949", "AdvBase_InitializeGame_14950", "AdvBase_InitializeGame_14951", "AdvBase_InitializeGame_14952", "AdvBase_InitializeGame_14953"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_betreten, "AdvBase_InitializeGame_14954", "AdvBase_InitializeGame_14955", "AdvBase_InitializeGame_14956", "AdvBase_InitializeGame_14957", "AdvBase_InitializeGame_14958", "AdvBase_InitializeGame_14959", "AdvBase_InitializeGame_14960", "AdvBase_InitializeGame_14961", "AdvBase_InitializeGame_14962", "AdvBase_InitializeGame_14963", "AdvBase_InitializeGame_14964", "AdvBase_InitializeGame_14965", "AdvBase_InitializeGame_14966"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_schneiden, "AdvBase_InitializeGame_14967", "AdvBase_InitializeGame_14968", "AdvBase_InitializeGame_14969", "AdvBase_InitializeGame_14970", "AdvBase_InitializeGame_14971", "AdvBase_InitializeGame_14972", "AdvBase_InitializeGame_14973", "AdvBase_InitializeGame_14974", "AdvBase_InitializeGame_14975", "AdvBase_InitializeGame_14976", "AdvBase_InitializeGame_14977", "AdvBase_InitializeGame_14978", "AdvBase_InitializeGame_14979"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_verknoten, "AdvBase_InitializeGame_14980", "AdvBase_InitializeGame_14981", "AdvBase_InitializeGame_14982", "AdvBase_InitializeGame_14983", "AdvBase_InitializeGame_14984", "AdvBase_InitializeGame_14985", "AdvBase_InitializeGame_14986", "AdvBase_InitializeGame_14987", "AdvBase_InitializeGame_14988", "AdvBase_InitializeGame_14989", "AdvBase_InitializeGame_14990", "AdvBase_InitializeGame_14991", "AdvBase_InitializeGame_14992"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_leuchten, "AdvBase_InitializeGame_14993", "AdvBase_InitializeGame_14994", "AdvBase_InitializeGame_14995", "AdvBase_InitializeGame_14996", "AdvBase_InitializeGame_14997", "AdvBase_InitializeGame_14998", "AdvBase_InitializeGame_14999", "AdvBase_InitializeGame_15000", "AdvBase_InitializeGame_15001", "AdvBase_InitializeGame_15002", "AdvBase_InitializeGame_15003", "AdvBase_InitializeGame_15004", "AdvBase_InitializeGame_15005"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_entzuenden, "AdvBase_InitializeGame_15006", "AdvBase_InitializeGame_15007", "AdvBase_InitializeGame_15008", "AdvBase_InitializeGame_15009", "AdvBase_InitializeGame_15010", "AdvBase_InitializeGame_15011", "AdvBase_InitializeGame_15012", "AdvBase_InitializeGame_15013", "AdvBase_InitializeGame_15014", "AdvBase_InitializeGame_15015", "AdvBase_InitializeGame_15016", "AdvBase_InitializeGame_15017", "AdvBase_InitializeGame_15018"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_loeschen, "AdvBase_InitializeGame_15019", "AdvBase_InitializeGame_15020", "AdvBase_InitializeGame_15021", "AdvBase_InitializeGame_15022", "AdvBase_InitializeGame_15023", "AdvBase_InitializeGame_15024", "AdvBase_InitializeGame_15025", "AdvBase_InitializeGame_15026", "AdvBase_InitializeGame_15027", "AdvBase_InitializeGame_15028", "AdvBase_InitializeGame_15029", "AdvBase_InitializeGame_15030", "AdvBase_InitializeGame_15031"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_fischen, "AdvBase_InitializeGame_15032", "AdvBase_InitializeGame_15033", "AdvBase_InitializeGame_15034", "AdvBase_InitializeGame_15035", "AdvBase_InitializeGame_15036", "AdvBase_InitializeGame_15037", "AdvBase_InitializeGame_15038", "AdvBase_InitializeGame_15039", "AdvBase_InitializeGame_15040", "AdvBase_InitializeGame_15041", "AdvBase_InitializeGame_15042", "AdvBase_InitializeGame_15043", "AdvBase_InitializeGame_15044"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_moegen, "AdvBase_InitializeGame_15045", "AdvBase_InitializeGame_15046", "AdvBase_InitializeGame_15047", "AdvBase_InitializeGame_15048", "AdvBase_InitializeGame_15049", "AdvBase_InitializeGame_15050", "AdvBase_InitializeGame_15051", "AdvBase_InitializeGame_15052", "AdvBase_InitializeGame_15053", "AdvBase_InitializeGame_15054", "AdvBase_InitializeGame_15055", "AdvBase_InitializeGame_15056", "AdvBase_InitializeGame_15057"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_sprechen, "AdvBase_InitializeGame_15058", "AdvBase_InitializeGame_15059", "AdvBase_InitializeGame_15060", "AdvBase_InitializeGame_15061", "AdvBase_InitializeGame_15062", "AdvBase_InitializeGame_15063", "AdvBase_InitializeGame_15064", "AdvBase_InitializeGame_15065", "AdvBase_InitializeGame_15066", "AdvBase_InitializeGame_15067", "AdvBase_InitializeGame_15068", "AdvBase_InitializeGame_15069", "AdvBase_InitializeGame_15070"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_beruehren, "AdvBase_InitializeGame_15071", "AdvBase_InitializeGame_15072", "AdvBase_InitializeGame_15073", "AdvBase_InitializeGame_15074", "AdvBase_InitializeGame_15075", "AdvBase_InitializeGame_15076", "AdvBase_InitializeGame_15077", "AdvBase_InitializeGame_15078", "AdvBase_InitializeGame_15079", "AdvBase_InitializeGame_15080", "AdvBase_InitializeGame_15081", "AdvBase_InitializeGame_15082", "AdvBase_InitializeGame_15083"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_fuehren, "AdvBase_InitializeGame_15084", "AdvBase_InitializeGame_15085", "AdvBase_InitializeGame_15086", "AdvBase_InitializeGame_15087", "AdvBase_InitializeGame_15088", "AdvBase_InitializeGame_15089", "AdvBase_InitializeGame_15090", "AdvBase_InitializeGame_15091", "AdvBase_InitializeGame_15092", "AdvBase_InitializeGame_15093", "AdvBase_InitializeGame_15094", "AdvBase_InitializeGame_15095", "AdvBase_InitializeGame_15096"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_lassen, "AdvBase_InitializeGame_15097", "AdvBase_InitializeGame_15098", "AdvBase_InitializeGame_15099", "AdvBase_InitializeGame_15100", "AdvBase_InitializeGame_15101", "AdvBase_InitializeGame_15102", "AdvBase_InitializeGame_15103", "AdvBase_InitializeGame_15104", "AdvBase_InitializeGame_15105", "AdvBase_InitializeGame_15106", "AdvBase_InitializeGame_15107", "AdvBase_InitializeGame_15108", "AdvBase_InitializeGame_15109"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_passen, "AdvBase_InitializeGame_15110", "AdvBase_InitializeGame_15111", "AdvBase_InitializeGame_15112", "AdvBase_InitializeGame_15113", "AdvBase_InitializeGame_15114", "AdvBase_InitializeGame_15115", "AdvBase_InitializeGame_15116", "AdvBase_InitializeGame_15117", "AdvBase_InitializeGame_15118", "AdvBase_InitializeGame_15119", "AdvBase_InitializeGame_15120", "AdvBase_InitializeGame_15121", "AdvBase_InitializeGame_15122"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_weichen, "AdvBase_InitializeGame_15123", "AdvBase_InitializeGame_15124", "AdvBase_InitializeGame_15125", "AdvBase_InitializeGame_15126", "AdvBase_InitializeGame_15127", "AdvBase_InitializeGame_15128", "AdvBase_InitializeGame_15129", "AdvBase_InitializeGame_15130", "AdvBase_InitializeGame_15131", "AdvBase_InitializeGame_15132", "AdvBase_InitializeGame_15133", "AdvBase_InitializeGame_15134", "AdvBase_InitializeGame_15135"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_heben, "AdvBase_InitializeGame_15136", "AdvBase_InitializeGame_15137", "AdvBase_InitializeGame_15138", "AdvBase_InitializeGame_15139", "AdvBase_InitializeGame_15140", "AdvBase_InitializeGame_15141", "AdvBase_InitializeGame_15142", "AdvBase_InitializeGame_15143", "AdvBase_InitializeGame_15144", "AdvBase_InitializeGame_15145", "AdvBase_InitializeGame_15146", "AdvBase_InitializeGame_15147", "AdvBase_InitializeGame_15148"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_klopfen, "AdvBase_InitializeGame_15149", "AdvBase_InitializeGame_15150", "AdvBase_InitializeGame_15151", "AdvBase_InitializeGame_15152", "AdvBase_InitializeGame_15153", "AdvBase_InitializeGame_15154", "AdvBase_InitializeGame_15155", "AdvBase_InitializeGame_15156", "AdvBase_InitializeGame_15157", "AdvBase_InitializeGame_15158", "AdvBase_InitializeGame_15159", "AdvBase_InitializeGame_15160", "AdvBase_InitializeGame_15161"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_zeigen, "AdvBase_InitializeGame_15162", "AdvBase_InitializeGame_15163", "AdvBase_InitializeGame_15164", "AdvBase_InitializeGame_15165", "AdvBase_InitializeGame_15166", "AdvBase_InitializeGame_15167", "AdvBase_InitializeGame_15168", "AdvBase_InitializeGame_15169", "AdvBase_InitializeGame_15170", "AdvBase_InitializeGame_15171", "AdvBase_InitializeGame_15172", "AdvBase_InitializeGame_15173", "AdvBase_InitializeGame_15174"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_entgegnen, "AdvBase_InitializeGame_15175", "AdvBase_InitializeGame_15176", "AdvBase_InitializeGame_15177", "AdvBase_InitializeGame_15178", "AdvBase_InitializeGame_15179", "AdvBase_InitializeGame_15180", "AdvBase_InitializeGame_15181", "AdvBase_InitializeGame_15182", "AdvBase_InitializeGame_15183", "AdvBase_InitializeGame_15184", "AdvBase_InitializeGame_15185", "AdvBase_InitializeGame_15186", "AdvBase_InitializeGame_15187"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_erwaehnen, "AdvBase_InitializeGame_15188", "AdvBase_InitializeGame_15189", "AdvBase_InitializeGame_15190", "AdvBase_InitializeGame_15191", "AdvBase_InitializeGame_15192", "AdvBase_InitializeGame_15193", "AdvBase_InitializeGame_15194", "AdvBase_InitializeGame_15195", "AdvBase_InitializeGame_15196", "AdvBase_InitializeGame_15197", "AdvBase_InitializeGame_15198", "AdvBase_InitializeGame_15199", "AdvBase_InitializeGame_15200"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_kreischen, "AdvBase_InitializeGame_15201", "AdvBase_InitializeGame_15202", "AdvBase_InitializeGame_15203", "AdvBase_InitializeGame_15204", "AdvBase_InitializeGame_15205", "AdvBase_InitializeGame_15206", "AdvBase_InitializeGame_15207", "AdvBase_InitializeGame_15208", "AdvBase_InitializeGame_15209", "AdvBase_InitializeGame_15210", "AdvBase_InitializeGame_15211", "AdvBase_InitializeGame_15212", "AdvBase_InitializeGame_15213"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_saeuseln, "AdvBase_InitializeGame_15214", "AdvBase_InitializeGame_15215", "AdvBase_InitializeGame_15216", "AdvBase_InitializeGame_15217", "AdvBase_InitializeGame_15218", "AdvBase_InitializeGame_15219", "AdvBase_InitializeGame_15220", "AdvBase_InitializeGame_15221", "AdvBase_InitializeGame_15222", "AdvBase_InitializeGame_15223", "AdvBase_InitializeGame_15224", "AdvBase_InitializeGame_15225", "AdvBase_InitializeGame_15226"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_bruellen, "AdvBase_InitializeGame_15227", "AdvBase_InitializeGame_15228", "AdvBase_InitializeGame_15229", "AdvBase_InitializeGame_15230", "AdvBase_InitializeGame_15231", "AdvBase_InitializeGame_15232", "AdvBase_InitializeGame_15233", "AdvBase_InitializeGame_15234", "AdvBase_InitializeGame_15235", "AdvBase_InitializeGame_15236", "AdvBase_InitializeGame_15237", "AdvBase_InitializeGame_15238", "AdvBase_InitializeGame_15239"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_wueten, "AdvBase_InitializeGame_15240", "AdvBase_InitializeGame_15241", "AdvBase_InitializeGame_15242", "AdvBase_InitializeGame_15243", "AdvBase_InitializeGame_15244", "AdvBase_InitializeGame_15245", "AdvBase_InitializeGame_15246", "AdvBase_InitializeGame_15247", "AdvBase_InitializeGame_15248", "AdvBase_InitializeGame_15249", "AdvBase_InitializeGame_15250", "AdvBase_InitializeGame_15251", "AdvBase_InitializeGame_15252"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_schreien, "AdvBase_InitializeGame_15253", "AdvBase_InitializeGame_15254", "AdvBase_InitializeGame_15255", "AdvBase_InitializeGame_15256", "AdvBase_InitializeGame_15257", "AdvBase_InitializeGame_15258", "AdvBase_InitializeGame_15259", "AdvBase_InitializeGame_15260", "AdvBase_InitializeGame_15261", "AdvBase_InitializeGame_15262", "AdvBase_InitializeGame_15263", "AdvBase_InitializeGame_15264", "AdvBase_InitializeGame_15265"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_wispern, "AdvBase_InitializeGame_15266", "AdvBase_InitializeGame_15267", "AdvBase_InitializeGame_15268", "AdvBase_InitializeGame_15269", "AdvBase_InitializeGame_15270", "AdvBase_InitializeGame_15271", "AdvBase_InitializeGame_15272", "AdvBase_InitializeGame_15273", "AdvBase_InitializeGame_15274", "AdvBase_InitializeGame_15275", "AdvBase_InitializeGame_15276", "AdvBase_InitializeGame_15277", "AdvBase_InitializeGame_15278"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_fluestern, "AdvBase_InitializeGame_15279", "AdvBase_InitializeGame_15280", "AdvBase_InitializeGame_15281", "AdvBase_InitializeGame_15282", "AdvBase_InitializeGame_15283", "AdvBase_InitializeGame_15284", "AdvBase_InitializeGame_15285", "AdvBase_InitializeGame_15286", "AdvBase_InitializeGame_15287", "AdvBase_InitializeGame_15288", "AdvBase_InitializeGame_15289", "AdvBase_InitializeGame_15290", "AdvBase_InitializeGame_15291"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_grunzen, "AdvBase_InitializeGame_15292", "AdvBase_InitializeGame_15293", "AdvBase_InitializeGame_15294", "AdvBase_InitializeGame_15295", "AdvBase_InitializeGame_15296", "AdvBase_InitializeGame_15297", "AdvBase_InitializeGame_15298", "AdvBase_InitializeGame_15299", "AdvBase_InitializeGame_15300", "AdvBase_InitializeGame_15301", "AdvBase_InitializeGame_15302", "AdvBase_InitializeGame_15303", "AdvBase_InitializeGame_15304"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_brummen, "AdvBase_InitializeGame_15305", "AdvBase_InitializeGame_15306", "AdvBase_InitializeGame_15307", "AdvBase_InitializeGame_15308", "AdvBase_InitializeGame_15309", "AdvBase_InitializeGame_15310", "AdvBase_InitializeGame_15311", "AdvBase_InitializeGame_15312", "AdvBase_InitializeGame_15313", "AdvBase_InitializeGame_15314", "AdvBase_InitializeGame_15315", "AdvBase_InitializeGame_15316", "AdvBase_InitializeGame_15317"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_lachen, "AdvBase_InitializeGame_15318", "AdvBase_InitializeGame_15319", "AdvBase_InitializeGame_15320", "AdvBase_InitializeGame_15321", "AdvBase_InitializeGame_15322", "AdvBase_InitializeGame_15323", "AdvBase_InitializeGame_15324", "AdvBase_InitializeGame_15325", "AdvBase_InitializeGame_15326", "AdvBase_InitializeGame_15327", "AdvBase_InitializeGame_15328", "AdvBase_InitializeGame_15329", "AdvBase_InitializeGame_15330"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_keuchen, "AdvBase_InitializeGame_15331", "AdvBase_InitializeGame_15332", "AdvBase_InitializeGame_15333", "AdvBase_InitializeGame_15334", "AdvBase_InitializeGame_15335", "AdvBase_InitializeGame_15336", "AdvBase_InitializeGame_15337", "AdvBase_InitializeGame_15338", "AdvBase_InitializeGame_15339", "AdvBase_InitializeGame_15340", "AdvBase_InitializeGame_15341", "AdvBase_InitializeGame_15342", "AdvBase_InitializeGame_15343"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_jauchzen, "AdvBase_InitializeGame_15344", "AdvBase_InitializeGame_15345", "AdvBase_InitializeGame_15346", "AdvBase_InitializeGame_15347", "AdvBase_InitializeGame_15348", "AdvBase_InitializeGame_15349", "AdvBase_InitializeGame_15350", "AdvBase_InitializeGame_15351", "AdvBase_InitializeGame_15352", "AdvBase_InitializeGame_15353", "AdvBase_InitializeGame_15354", "AdvBase_InitializeGame_15355", "AdvBase_InitializeGame_15356"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_troeten, "AdvBase_InitializeGame_15357", "AdvBase_InitializeGame_15358", "AdvBase_InitializeGame_15359", "AdvBase_InitializeGame_15360", "AdvBase_InitializeGame_15361", "AdvBase_InitializeGame_15362", "AdvBase_InitializeGame_15363", "AdvBase_InitializeGame_15364", "AdvBase_InitializeGame_15365", "AdvBase_InitializeGame_15366", "AdvBase_InitializeGame_15367", "AdvBase_InitializeGame_15368", "AdvBase_InitializeGame_15369"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_lachen, "AdvBase_InitializeGame_15370", "AdvBase_InitializeGame_15371", "AdvBase_InitializeGame_15372", "AdvBase_InitializeGame_15373", "AdvBase_InitializeGame_15374", "AdvBase_InitializeGame_15375", "AdvBase_InitializeGame_15376", "AdvBase_InitializeGame_15377", "AdvBase_InitializeGame_15378", "AdvBase_InitializeGame_15379", "AdvBase_InitializeGame_15380", "AdvBase_InitializeGame_15381", "AdvBase_InitializeGame_15382"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_erklaeren, "AdvBase_InitializeGame_15383", "AdvBase_InitializeGame_15384", "AdvBase_InitializeGame_15385", "AdvBase_InitializeGame_15386", "AdvBase_InitializeGame_15387", "AdvBase_InitializeGame_15388", "AdvBase_InitializeGame_15389", "AdvBase_InitializeGame_15390", "AdvBase_InitializeGame_15391", "AdvBase_InitializeGame_15392", "AdvBase_InitializeGame_15393", "AdvBase_InitializeGame_15394", "AdvBase_InitializeGame_15395"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_kichern, "AdvBase_InitializeGame_15396", "AdvBase_InitializeGame_15397", "AdvBase_InitializeGame_15398", "AdvBase_InitializeGame_15399", "AdvBase_InitializeGame_15400", "AdvBase_InitializeGame_15401", "AdvBase_InitializeGame_15402", "AdvBase_InitializeGame_15403", "AdvBase_InitializeGame_15404", "AdvBase_InitializeGame_15405", "AdvBase_InitializeGame_15406", "AdvBase_InitializeGame_15407", "AdvBase_InitializeGame_15408"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_zischen, "AdvBase_InitializeGame_15409", "AdvBase_InitializeGame_15410", "AdvBase_InitializeGame_15411", "AdvBase_InitializeGame_15412", "AdvBase_InitializeGame_15413", "AdvBase_InitializeGame_15414", "AdvBase_InitializeGame_15415", "AdvBase_InitializeGame_15416", "AdvBase_InitializeGame_15417", "AdvBase_InitializeGame_15418", "AdvBase_InitializeGame_15419", "AdvBase_InitializeGame_15420", "AdvBase_InitializeGame_15421"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_fabulieren, "AdvBase_InitializeGame_15422", "AdvBase_InitializeGame_15423", "AdvBase_InitializeGame_15424", "AdvBase_InitializeGame_15425", "AdvBase_InitializeGame_15426", "AdvBase_InitializeGame_15427", "AdvBase_InitializeGame_15428", "AdvBase_InitializeGame_15429", "AdvBase_InitializeGame_15430", "AdvBase_InitializeGame_15431", "AdvBase_InitializeGame_15432", "AdvBase_InitializeGame_15433", "AdvBase_InitializeGame_15434"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_flehen, "AdvBase_InitializeGame_15435", "AdvBase_InitializeGame_15436", "AdvBase_InitializeGame_15437", "AdvBase_InitializeGame_15438", "AdvBase_InitializeGame_15439", "AdvBase_InitializeGame_15440", "AdvBase_InitializeGame_15441", "AdvBase_InitializeGame_15442", "AdvBase_InitializeGame_15443", "AdvBase_InitializeGame_15444", "AdvBase_InitializeGame_15445", "AdvBase_InitializeGame_15446", "AdvBase_InitializeGame_15447"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_dozieren, "AdvBase_InitializeGame_15448", "AdvBase_InitializeGame_15449", "AdvBase_InitializeGame_15450", "AdvBase_InitializeGame_15451", "AdvBase_InitializeGame_15452", "AdvBase_InitializeGame_15453", "AdvBase_InitializeGame_15454", "AdvBase_InitializeGame_15455", "AdvBase_InitializeGame_15456", "AdvBase_InitializeGame_15457", "AdvBase_InitializeGame_15458", "AdvBase_InitializeGame_15459", "AdvBase_InitializeGame_15460"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_drohen, "AdvBase_InitializeGame_15461", "AdvBase_InitializeGame_15462", "AdvBase_InitializeGame_15463", "AdvBase_InitializeGame_15464", "AdvBase_InitializeGame_15465", "AdvBase_InitializeGame_15466", "AdvBase_InitializeGame_15467", "AdvBase_InitializeGame_15468", "AdvBase_InitializeGame_15469", "AdvBase_InitializeGame_15470", "AdvBase_InitializeGame_15471", "AdvBase_InitializeGame_15472", "AdvBase_InitializeGame_15473"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_frohlocken, "AdvBase_InitializeGame_15474", "AdvBase_InitializeGame_15475", "AdvBase_InitializeGame_15476", "AdvBase_InitializeGame_15477", "AdvBase_InitializeGame_15478", "AdvBase_InitializeGame_15479", "AdvBase_InitializeGame_15480", "AdvBase_InitializeGame_15481", "AdvBase_InitializeGame_15482", "AdvBase_InitializeGame_15483", "AdvBase_InitializeGame_15484", "AdvBase_InitializeGame_15485", "AdvBase_InitializeGame_15486"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_grummeln, "AdvBase_InitializeGame_15487", "AdvBase_InitializeGame_15488", "AdvBase_InitializeGame_15489", "AdvBase_InitializeGame_15490", "AdvBase_InitializeGame_15491", "AdvBase_InitializeGame_15492", "AdvBase_InitializeGame_15493", "AdvBase_InitializeGame_15494", "AdvBase_InitializeGame_15495", "AdvBase_InitializeGame_15496", "AdvBase_InitializeGame_15497", "AdvBase_InitializeGame_15498", "AdvBase_InitializeGame_15499"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_maulen, "AdvBase_InitializeGame_15500", "AdvBase_InitializeGame_15501", "AdvBase_InitializeGame_15502", "AdvBase_InitializeGame_15503", "AdvBase_InitializeGame_15504", "AdvBase_InitializeGame_15505", "AdvBase_InitializeGame_15506", "AdvBase_InitializeGame_15507", "AdvBase_InitializeGame_15508", "AdvBase_InitializeGame_15509", "AdvBase_InitializeGame_15510", "AdvBase_InitializeGame_15511", "AdvBase_InitializeGame_15512"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_prahlen, "AdvBase_InitializeGame_15513", "AdvBase_InitializeGame_15514", "AdvBase_InitializeGame_15515", "AdvBase_InitializeGame_15516", "AdvBase_InitializeGame_15517", "AdvBase_InitializeGame_15518", "AdvBase_InitializeGame_15519", "AdvBase_InitializeGame_15520", "AdvBase_InitializeGame_15521", "AdvBase_InitializeGame_15522", "AdvBase_InitializeGame_15523", "AdvBase_InitializeGame_15524", "AdvBase_InitializeGame_15525"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_seufzen, "AdvBase_InitializeGame_15526", "AdvBase_InitializeGame_15527", "AdvBase_InitializeGame_15528", "AdvBase_InitializeGame_15529", "AdvBase_InitializeGame_15530", "AdvBase_InitializeGame_15531", "AdvBase_InitializeGame_15532", "AdvBase_InitializeGame_15533", "AdvBase_InitializeGame_15534", "AdvBase_InitializeGame_15535", "AdvBase_InitializeGame_15536", "AdvBase_InitializeGame_15537", "AdvBase_InitializeGame_15538"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_stoehnen, "AdvBase_InitializeGame_15539", "AdvBase_InitializeGame_15540", "AdvBase_InitializeGame_15541", "AdvBase_InitializeGame_15542", "AdvBase_InitializeGame_15543", "AdvBase_InitializeGame_15544", "AdvBase_InitializeGame_15545", "AdvBase_InitializeGame_15546", "AdvBase_InitializeGame_15547", "AdvBase_InitializeGame_15548", "AdvBase_InitializeGame_15549", "AdvBase_InitializeGame_15550", "AdvBase_InitializeGame_15551"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_berichten, "AdvBase_InitializeGame_15552", "AdvBase_InitializeGame_15553", "AdvBase_InitializeGame_15554", "AdvBase_InitializeGame_15555", "AdvBase_InitializeGame_15556", "AdvBase_InitializeGame_15557", "AdvBase_InitializeGame_15558", "AdvBase_InitializeGame_15559", "AdvBase_InitializeGame_15560", "AdvBase_InitializeGame_15561", "AdvBase_InitializeGame_15562", "AdvBase_InitializeGame_15563", "AdvBase_InitializeGame_15564"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_aechzen, "AdvBase_InitializeGame_15565", "AdvBase_InitializeGame_15566", "AdvBase_InitializeGame_15567", "AdvBase_InitializeGame_15568", "AdvBase_InitializeGame_15569", "AdvBase_InitializeGame_15570", "AdvBase_InitializeGame_15571", "AdvBase_InitializeGame_15572", "AdvBase_InitializeGame_15573", "AdvBase_InitializeGame_15574", "AdvBase_InitializeGame_15575", "AdvBase_InitializeGame_15576", "AdvBase_InitializeGame_15577"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_betteln, "AdvBase_InitializeGame_15578", "AdvBase_InitializeGame_15579", "AdvBase_InitializeGame_15580", "AdvBase_InitializeGame_15581", "AdvBase_InitializeGame_15582", "AdvBase_InitializeGame_15583", "AdvBase_InitializeGame_15584", "AdvBase_InitializeGame_15585", "AdvBase_InitializeGame_15586", "AdvBase_InitializeGame_15587", "AdvBase_InitializeGame_15588", "AdvBase_InitializeGame_15589", "AdvBase_InitializeGame_15590"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_schwadronieren, "AdvBase_InitializeGame_15591", "AdvBase_InitializeGame_15592", "AdvBase_InitializeGame_15593", "AdvBase_InitializeGame_15594", "AdvBase_InitializeGame_15595", "AdvBase_InitializeGame_15596", "AdvBase_InitializeGame_15597", "AdvBase_InitializeGame_15598", "AdvBase_InitializeGame_15599", "AdvBase_InitializeGame_15600", "AdvBase_InitializeGame_15601", "AdvBase_InitializeGame_15602", "AdvBase_InitializeGame_15603"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_antworten, "AdvBase_InitializeGame_15604", "AdvBase_InitializeGame_15605", "AdvBase_InitializeGame_15606", "AdvBase_InitializeGame_15607", "AdvBase_InitializeGame_15608", "AdvBase_InitializeGame_15609", "AdvBase_InitializeGame_15610", "AdvBase_InitializeGame_15611", "AdvBase_InitializeGame_15612", "AdvBase_InitializeGame_15613", "AdvBase_InitializeGame_15614", "AdvBase_InitializeGame_15615", "AdvBase_InitializeGame_15616"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_murmeln, "AdvBase_InitializeGame_15617", "AdvBase_InitializeGame_15618", "AdvBase_InitializeGame_15619", "AdvBase_InitializeGame_15620", "AdvBase_InitializeGame_15621", "AdvBase_InitializeGame_15622", "AdvBase_InitializeGame_15623", "AdvBase_InitializeGame_15624", "AdvBase_InitializeGame_15625", "AdvBase_InitializeGame_15626", "AdvBase_InitializeGame_15627", "AdvBase_InitializeGame_15628", "AdvBase_InitializeGame_15629"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_beschwoeren, "AdvBase_InitializeGame_15630", "AdvBase_InitializeGame_15631", "AdvBase_InitializeGame_15632", "AdvBase_InitializeGame_15633", "AdvBase_InitializeGame_15634", "AdvBase_InitializeGame_15635", "AdvBase_InitializeGame_15636", "AdvBase_InitializeGame_15637", "AdvBase_InitializeGame_15638", "AdvBase_InitializeGame_15639", "AdvBase_InitializeGame_15640", "AdvBase_InitializeGame_15641", "AdvBase_InitializeGame_15642"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_rufen, "AdvBase_InitializeGame_15643", "AdvBase_InitializeGame_15644", "AdvBase_InitializeGame_15645", "AdvBase_InitializeGame_15646", "AdvBase_InitializeGame_15647", "AdvBase_InitializeGame_15648", "AdvBase_InitializeGame_15649", "AdvBase_InitializeGame_15650", "AdvBase_InitializeGame_15651", "AdvBase_InitializeGame_15652", "AdvBase_InitializeGame_15653", "AdvBase_InitializeGame_15654", "AdvBase_InitializeGame_15655"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_draengeln, "AdvBase_InitializeGame_15656", "AdvBase_InitializeGame_15657", "AdvBase_InitializeGame_15658", "AdvBase_InitializeGame_15659", "AdvBase_InitializeGame_15660", "AdvBase_InitializeGame_15661", "AdvBase_InitializeGame_15662", "AdvBase_InitializeGame_15663", "AdvBase_InitializeGame_15664", "AdvBase_InitializeGame_15665", "AdvBase_InitializeGame_15666", "AdvBase_InitializeGame_15667", "AdvBase_InitializeGame_15668"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_beschwichtigen, "AdvBase_InitializeGame_15669", "AdvBase_InitializeGame_15670", "AdvBase_InitializeGame_15671", "AdvBase_InitializeGame_15672", "AdvBase_InitializeGame_15673", "AdvBase_InitializeGame_15674", "AdvBase_InitializeGame_15675", "AdvBase_InitializeGame_15676", "AdvBase_InitializeGame_15677", "AdvBase_InitializeGame_15678", "AdvBase_InitializeGame_15679", "AdvBase_InitializeGame_15680", "AdvBase_InitializeGame_15681"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_stottern, "AdvBase_InitializeGame_15682", "AdvBase_InitializeGame_15683", "AdvBase_InitializeGame_15684", "AdvBase_InitializeGame_15685", "AdvBase_InitializeGame_15686", "AdvBase_InitializeGame_15687", "AdvBase_InitializeGame_15688", "AdvBase_InitializeGame_15689", "AdvBase_InitializeGame_15690", "AdvBase_InitializeGame_15691", "AdvBase_InitializeGame_15692", "AdvBase_InitializeGame_15693", "AdvBase_InitializeGame_15694"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_draengen, "AdvBase_InitializeGame_15695", "AdvBase_InitializeGame_15696", "AdvBase_InitializeGame_15697", "AdvBase_InitializeGame_15698", "AdvBase_InitializeGame_15699", "AdvBase_InitializeGame_15700", "AdvBase_InitializeGame_15701", "AdvBase_InitializeGame_15702", "AdvBase_InitializeGame_15703", "AdvBase_InitializeGame_15704", "AdvBase_InitializeGame_15705", "AdvBase_InitializeGame_15706", "AdvBase_InitializeGame_15707"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_gruebeln, "AdvBase_InitializeGame_15708", "AdvBase_InitializeGame_15709", "AdvBase_InitializeGame_15710", "AdvBase_InitializeGame_15711", "AdvBase_InitializeGame_15712", "AdvBase_InitializeGame_15713", "AdvBase_InitializeGame_15714", "AdvBase_InitializeGame_15715", "AdvBase_InitializeGame_15716", "AdvBase_InitializeGame_15717", "AdvBase_InitializeGame_15718", "AdvBase_InitializeGame_15719", "AdvBase_InitializeGame_15720"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_johlen, "AdvBase_InitializeGame_15721", "AdvBase_InitializeGame_15722", "AdvBase_InitializeGame_15723", "AdvBase_InitializeGame_15724", "AdvBase_InitializeGame_15725", "AdvBase_InitializeGame_15726", "AdvBase_InitializeGame_15727", "AdvBase_InitializeGame_15728", "AdvBase_InitializeGame_15729", "AdvBase_InitializeGame_15730", "AdvBase_InitializeGame_15731", "AdvBase_InitializeGame_15732", "AdvBase_InitializeGame_15733"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_lallen, "AdvBase_InitializeGame_15734", "AdvBase_InitializeGame_15735", "AdvBase_InitializeGame_15736", "AdvBase_InitializeGame_15737", "AdvBase_InitializeGame_15738", "AdvBase_InitializeGame_15739", "AdvBase_InitializeGame_15740", "AdvBase_InitializeGame_15741", "AdvBase_InitializeGame_15742", "AdvBase_InitializeGame_15743", "AdvBase_InitializeGame_15744", "AdvBase_InitializeGame_15745", "AdvBase_InitializeGame_15746"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_nothing, "AdvBase_InitializeGame_15747", "AdvBase_InitializeGame_15748", "AdvBase_InitializeGame_15749", "AdvBase_InitializeGame_15750", "AdvBase_InitializeGame_15751", "AdvBase_InitializeGame_15752", "AdvBase_InitializeGame_15753", "AdvBase_InitializeGame_15754", "AdvBase_InitializeGame_15755", "AdvBase_InitializeGame_15756", "AdvBase_InitializeGame_15757", "AdvBase_InitializeGame_15758", "AdvBase_InitializeGame_15759"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_raunen, "AdvBase_InitializeGame_15760", "AdvBase_InitializeGame_15761", "AdvBase_InitializeGame_15762", "AdvBase_InitializeGame_15763", "AdvBase_InitializeGame_15764", "AdvBase_InitializeGame_15765", "AdvBase_InitializeGame_15766", "AdvBase_InitializeGame_15767", "AdvBase_InitializeGame_15768", "AdvBase_InitializeGame_15769", "AdvBase_InitializeGame_15770", "AdvBase_InitializeGame_15771", "AdvBase_InitializeGame_15772"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_schaeumen, "AdvBase_InitializeGame_15773", "AdvBase_InitializeGame_15774", "AdvBase_InitializeGame_15775", "AdvBase_InitializeGame_15776", "AdvBase_InitializeGame_15777", "AdvBase_InitializeGame_15778", "AdvBase_InitializeGame_15779", "AdvBase_InitializeGame_15780", "AdvBase_InitializeGame_15781", "AdvBase_InitializeGame_15782", "AdvBase_InitializeGame_15783", "AdvBase_InitializeGame_15784", "AdvBase_InitializeGame_15785"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_schnauben, "AdvBase_InitializeGame_15786", "AdvBase_InitializeGame_15787", "AdvBase_InitializeGame_15788", "AdvBase_InitializeGame_15789", "AdvBase_InitializeGame_15790", "AdvBase_InitializeGame_15791", "AdvBase_InitializeGame_15792", "AdvBase_InitializeGame_15793", "AdvBase_InitializeGame_15794", "AdvBase_InitializeGame_15795", "AdvBase_InitializeGame_15796", "AdvBase_InitializeGame_15797", "AdvBase_InitializeGame_15798"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_sinnieren, "AdvBase_InitializeGame_15799", "AdvBase_InitializeGame_15800", "AdvBase_InitializeGame_15801", "AdvBase_InitializeGame_15802", "AdvBase_InitializeGame_15803", "AdvBase_InitializeGame_15804", "AdvBase_InitializeGame_15805", "AdvBase_InitializeGame_15806", "AdvBase_InitializeGame_15807", "AdvBase_InitializeGame_15808", "AdvBase_InitializeGame_15809", "AdvBase_InitializeGame_15810", "AdvBase_InitializeGame_15811"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_behaupten, "AdvBase_InitializeGame_15812", "AdvBase_InitializeGame_15813", "AdvBase_InitializeGame_15814", "AdvBase_InitializeGame_15815", "AdvBase_InitializeGame_15816", "AdvBase_InitializeGame_15817", "AdvBase_InitializeGame_15818", "AdvBase_InitializeGame_15819", "AdvBase_InitializeGame_15820", "AdvBase_InitializeGame_15821", "AdvBase_InitializeGame_15822", "AdvBase_InitializeGame_15823", "AdvBase_InitializeGame_15824"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_erzaehlen, "AdvBase_InitializeGame_15825", "AdvBase_InitializeGame_15826", "AdvBase_InitializeGame_15827", "AdvBase_InitializeGame_15828", "AdvBase_InitializeGame_15829", "AdvBase_InitializeGame_15830", "AdvBase_InitializeGame_15831", "AdvBase_InitializeGame_15832", "AdvBase_InitializeGame_15833", "AdvBase_InitializeGame_15834", "AdvBase_InitializeGame_15835", "AdvBase_InitializeGame_15836", "AdvBase_InitializeGame_15837"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_staunen, "AdvBase_InitializeGame_15838", "AdvBase_InitializeGame_15839", "AdvBase_InitializeGame_15840", "AdvBase_InitializeGame_15841", "AdvBase_InitializeGame_15842", "AdvBase_InitializeGame_15843", "AdvBase_InitializeGame_15844", "AdvBase_InitializeGame_15845", "AdvBase_InitializeGame_15846", "AdvBase_InitializeGame_15847", "AdvBase_InitializeGame_15848", "AdvBase_InitializeGame_15849", "AdvBase_InitializeGame_15850"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_jammern, "AdvBase_InitializeGame_15851", "AdvBase_InitializeGame_15852", "AdvBase_InitializeGame_15853", "AdvBase_InitializeGame_15854", "AdvBase_InitializeGame_15855", "AdvBase_InitializeGame_15856", "AdvBase_InitializeGame_15857", "AdvBase_InitializeGame_15858", "AdvBase_InitializeGame_15859", "AdvBase_InitializeGame_15860", "AdvBase_InitializeGame_15861", "AdvBase_InitializeGame_15862", "AdvBase_InitializeGame_15863"));

            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_keifen, "AdvBase_InitializeGame_15864", "AdvBase_InitializeGame_15865", "AdvBase_InitializeGame_15866", "AdvBase_InitializeGame_15867", "AdvBase_InitializeGame_15868", "AdvBase_InitializeGame_15869", "AdvBase_InitializeGame_15870", "AdvBase_InitializeGame_15871", "AdvBase_InitializeGame_15872", "AdvBase_InitializeGame_15873", "AdvBase_InitializeGame_15874", "AdvBase_InitializeGame_15875", "AdvBase_InitializeGame_15876"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_schwaermen, "AdvBase_InitializeGame_15877", "AdvBase_InitializeGame_15878", "AdvBase_InitializeGame_15879", "AdvBase_InitializeGame_15880", "AdvBase_InitializeGame_15881", "AdvBase_InitializeGame_15882", "AdvBase_InitializeGame_15883", "AdvBase_InitializeGame_15884", "AdvBase_InitializeGame_15885", "AdvBase_InitializeGame_15886", "AdvBase_InitializeGame_15887", "AdvBase_InitializeGame_15888", "AdvBase_InitializeGame_15889"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_verkuenden, "AdvBase_InitializeGame_15890", "AdvBase_InitializeGame_15891", "AdvBase_InitializeGame_15892", "AdvBase_InitializeGame_15893", "AdvBase_InitializeGame_15894", "AdvBase_InitializeGame_15895", "AdvBase_InitializeGame_15896", "AdvBase_InitializeGame_15897", "AdvBase_InitializeGame_15898", "AdvBase_InitializeGame_15899", "AdvBase_InitializeGame_15900", "AdvBase_InitializeGame_15901", "AdvBase_InitializeGame_15902"));

            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_schnaufen, "AdvBase_InitializeGame_15903", "AdvBase_InitializeGame_15904", "AdvBase_InitializeGame_15905", "AdvBase_InitializeGame_15906", "AdvBase_InitializeGame_15907", "AdvBase_InitializeGame_15908", "AdvBase_InitializeGame_15909", "AdvBase_InitializeGame_15910", "AdvBase_InitializeGame_15911", "AdvBase_InitializeGame_15912", "AdvBase_InitializeGame_15913", "AdvBase_InitializeGame_15914", "AdvBase_InitializeGame_15915"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_gaehnen, "AdvBase_InitializeGame_15916", "AdvBase_InitializeGame_15917", "AdvBase_InitializeGame_15918", "AdvBase_InitializeGame_15919", "AdvBase_InitializeGame_15920", "AdvBase_InitializeGame_15921", "AdvBase_InitializeGame_15922", "AdvBase_InitializeGame_15923", "AdvBase_InitializeGame_15924", "AdvBase_InitializeGame_15925", "AdvBase_InitializeGame_15926", "AdvBase_InitializeGame_15927", "AdvBase_InitializeGame_15928"));

            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_freuen, "AdvBase_InitializeGame_15929", "AdvBase_InitializeGame_15930", "AdvBase_InitializeGame_15931", "AdvBase_InitializeGame_15932", "AdvBase_InitializeGame_15933", "AdvBase_InitializeGame_15934", "AdvBase_InitializeGame_15935", "AdvBase_InitializeGame_15936", "AdvBase_InitializeGame_15937", "AdvBase_InitializeGame_15938", "AdvBase_InitializeGame_15939", "AdvBase_InitializeGame_15940", "AdvBase_InitializeGame_15941"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_loben, "AdvBase_InitializeGame_15942", "AdvBase_InitializeGame_15943", "AdvBase_InitializeGame_15944", "AdvBase_InitializeGame_15945", "AdvBase_InitializeGame_15946", "AdvBase_InitializeGame_15947", "AdvBase_InitializeGame_15948", "AdvBase_InitializeGame_15949", "AdvBase_InitializeGame_15950", "AdvBase_InitializeGame_15951", "AdvBase_InitializeGame_15952", "AdvBase_InitializeGame_15953", "AdvBase_InitializeGame_15954"));

            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_heulen, "AdvBase_InitializeGame_15955", "AdvBase_InitializeGame_15956", "AdvBase_InitializeGame_15957", "AdvBase_InitializeGame_15958", "AdvBase_InitializeGame_15959", "AdvBase_InitializeGame_15960", "AdvBase_InitializeGame_15961", "AdvBase_InitializeGame_15962", "AdvBase_InitializeGame_15963", "AdvBase_InitializeGame_15964", "AdvBase_InitializeGame_15965", "AdvBase_InitializeGame_15966", "AdvBase_InitializeGame_15967"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_raeuspern, "AdvBase_InitializeGame_15968", "AdvBase_InitializeGame_15969", "AdvBase_InitializeGame_15970", "AdvBase_InitializeGame_15971", "AdvBase_InitializeGame_15972", "AdvBase_InitializeGame_15973", "AdvBase_InitializeGame_15974", "AdvBase_InitializeGame_15975", "AdvBase_InitializeGame_15976", "AdvBase_InitializeGame_15977", "AdvBase_InitializeGame_15978", "AdvBase_InitializeGame_15979", "AdvBase_InitializeGame_15980"));

            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_roecheln, "AdvBase_InitializeGame_15981", "AdvBase_InitializeGame_15982", "AdvBase_InitializeGame_15983", "AdvBase_InitializeGame_15984", "AdvBase_InitializeGame_15985", "AdvBase_InitializeGame_15986", "AdvBase_InitializeGame_15987", "AdvBase_InitializeGame_15988", "AdvBase_InitializeGame_15989", "AdvBase_InitializeGame_15990", "AdvBase_InitializeGame_15991", "AdvBase_InitializeGame_15992", "AdvBase_InitializeGame_15993"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_schlucken, "AdvBase_InitializeGame_15994", "AdvBase_InitializeGame_15995", "AdvBase_InitializeGame_15996", "AdvBase_InitializeGame_15997", "AdvBase_InitializeGame_15998", "AdvBase_InitializeGame_15999", "AdvBase_InitializeGame_16000", "AdvBase_InitializeGame_16001", "AdvBase_InitializeGame_16002", "AdvBase_InitializeGame_16003", "AdvBase_InitializeGame_16004", "AdvBase_InitializeGame_16005", "AdvBase_InitializeGame_16006"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_winseln, "AdvBase_InitializeGame_16007", "AdvBase_InitializeGame_16008", "AdvBase_InitializeGame_16009", "AdvBase_InitializeGame_16010", "AdvBase_InitializeGame_16011", "AdvBase_InitializeGame_16012", "AdvBase_InitializeGame_16013", "AdvBase_InitializeGame_16014", "AdvBase_InitializeGame_16015", "AdvBase_InitializeGame_16016", "AdvBase_InitializeGame_16017", "AdvBase_InitializeGame_16018", "AdvBase_InitializeGame_16019"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_betrachten, "AdvBase_InitializeGame_16020", "AdvBase_InitializeGame_16021", "AdvBase_InitializeGame_16022", "AdvBase_InitializeGame_16023", "AdvBase_InitializeGame_16024", "AdvBase_InitializeGame_16025", "AdvBase_InitializeGame_16026", "AdvBase_InitializeGame_16027", "AdvBase_InitializeGame_16028", "AdvBase_InitializeGame_16029", "AdvBase_InitializeGame_16030", "AdvBase_InitializeGame_16031", "AdvBase_InitializeGame_16032"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_knurren, "AdvBase_InitializeGame_16033", "AdvBase_InitializeGame_16034", "AdvBase_InitializeGame_16035", "AdvBase_InitializeGame_16036", "AdvBase_InitializeGame_16037", "AdvBase_InitializeGame_16038", "AdvBase_InitializeGame_16039", "AdvBase_InitializeGame_16040", "AdvBase_InitializeGame_16041", "AdvBase_InitializeGame_16042", "AdvBase_InitializeGame_16043", "AdvBase_InitializeGame_16044", "AdvBase_InitializeGame_16045"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_verlassen, "AdvBase_InitializeGame_16046", "AdvBase_InitializeGame_16047", "AdvBase_InitializeGame_16048", "AdvBase_InitializeGame_16049", "AdvBase_InitializeGame_16050", "AdvBase_InitializeGame_16051", "AdvBase_InitializeGame_16052", "AdvBase_InitializeGame_16053", "AdvBase_InitializeGame_16054", "AdvBase_InitializeGame_16055", "AdvBase_InitializeGame_16056", "AdvBase_InitializeGame_16057", "AdvBase_InitializeGame_16058"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_fahren, "AdvBase_InitializeGame_16059", "AdvBase_InitializeGame_16060", "AdvBase_InitializeGame_16061", "AdvBase_InitializeGame_16062", "AdvBase_InitializeGame_16063", "AdvBase_InitializeGame_16064", "AdvBase_InitializeGame_16065", "AdvBase_InitializeGame_16066", "AdvBase_InitializeGame_16067", "AdvBase_InitializeGame_16068", "AdvBase_InitializeGame_16069", "AdvBase_InitializeGame_16070", "AdvBase_InitializeGame_16071"));
            VerbTenses.Add(VTList.VerbTensesLoca(CB!.VT_summen, "AdvBase_InitializeGame_16072", "AdvBase_InitializeGame_16073", "AdvBase_InitializeGame_16074", "AdvBase_InitializeGame_16075", "AdvBase_InitializeGame_16076", "AdvBase_InitializeGame_16077", "AdvBase_InitializeGame_16078", "AdvBase_InitializeGame_16079", "AdvBase_InitializeGame_16080", "AdvBase_InitializeGame_16081", "AdvBase_InitializeGame_16082", "AdvBase_InitializeGame_16083", "AdvBase_InitializeGame_16084"));

            /*
            VerbTenses.Add(new VerbTenses(CB!.VT_gehen, loca.AdvBase_InitializeGame_14369, loca.AdvBase_InitializeGame_14370, loca.AdvBase_InitializeGame_14371, loca.AdvBase_InitializeGame_14372, loca.AdvBase_InitializeGame_14373, loca.AdvBase_InitializeGame_14374, loca.AdvBase_InitializeGame_14375, loca.AdvBase_InitializeGame_14376, loca.AdvBase_InitializeGame_14377, loca.AdvBase_InitializeGame_14378, loca.AdvBase_InitializeGame_14379, loca.AdvBase_InitializeGame_14380, loca.AdvBase_InitializeGame_14381));
            VerbTenses.Add(new VerbTenses(CB!.VT_nehmen, loca.AdvBase_InitializeGame_14382, loca.AdvBase_InitializeGame_14383, loca.AdvBase_InitializeGame_14384, loca.AdvBase_InitializeGame_14385, loca.AdvBase_InitializeGame_14386, loca.AdvBase_InitializeGame_14387, loca.AdvBase_InitializeGame_14388, loca.AdvBase_InitializeGame_14389, loca.AdvBase_InitializeGame_14390, loca.AdvBase_InitializeGame_14391, loca.AdvBase_InitializeGame_14392, loca.AdvBase_InitializeGame_14393, loca.AdvBase_InitializeGame_14394 ));
            VerbTenses.Add(new VerbTenses(CB!.VT_oeffnen, loca.AdvBase_InitializeGame_14395, loca.AdvBase_InitializeGame_14396, loca.AdvBase_InitializeGame_14397, loca.AdvBase_InitializeGame_14398, loca.AdvBase_InitializeGame_14399, loca.AdvBase_InitializeGame_14400, loca.AdvBase_InitializeGame_14401, loca.AdvBase_InitializeGame_14402, loca.AdvBase_InitializeGame_14403, loca.AdvBase_InitializeGame_14404, loca.AdvBase_InitializeGame_14405, loca.AdvBase_InitializeGame_14406, loca.AdvBase_InitializeGame_14407));
            VerbTenses.Add(new VerbTenses(CB!.VT_schliessen, loca.AdvBase_InitializeGame_14408, loca.AdvBase_InitializeGame_14409, loca.AdvBase_InitializeGame_14410, loca.AdvBase_InitializeGame_14411, loca.AdvBase_InitializeGame_14412, loca.AdvBase_InitializeGame_14413, loca.AdvBase_InitializeGame_14414, loca.AdvBase_InitializeGame_14415, loca.AdvBase_InitializeGame_14416, loca.AdvBase_InitializeGame_14417, loca.AdvBase_InitializeGame_14418, loca.AdvBase_InitializeGame_14419, loca.AdvBase_InitializeGame_14420));
            VerbTenses.Add(new VerbTenses(CB!.VT_untersuchen, loca.AdvBase_InitializeGame_14421, loca.AdvBase_InitializeGame_14422, loca.AdvBase_InitializeGame_14423, loca.AdvBase_InitializeGame_14424, loca.AdvBase_InitializeGame_14425, loca.AdvBase_InitializeGame_14426, loca.AdvBase_InitializeGame_14427, loca.AdvBase_InitializeGame_14428, loca.AdvBase_InitializeGame_14429, loca.AdvBase_InitializeGame_14430, loca.AdvBase_InitializeGame_14431, loca.AdvBase_InitializeGame_14432, loca.AdvBase_InitializeGame_14433));
            VerbTenses.Add(new VerbTenses(CB!.VT_koennen, loca.AdvBase_InitializeGame_14434, loca.AdvBase_InitializeGame_14435, loca.AdvBase_InitializeGame_14436, loca.AdvBase_InitializeGame_14437, loca.AdvBase_InitializeGame_14438, loca.AdvBase_InitializeGame_14439, loca.AdvBase_InitializeGame_14440, loca.AdvBase_InitializeGame_14441, loca.AdvBase_InitializeGame_14442, loca.AdvBase_InitializeGame_14443, loca.AdvBase_InitializeGame_14444, loca.AdvBase_InitializeGame_14445, loca.AdvBase_InitializeGame_14446));
            VerbTenses.Add(new VerbTenses(CB!.VT_haben, loca.AdvBase_InitializeGame_14447, loca.AdvBase_InitializeGame_14448, loca.AdvBase_InitializeGame_14449, loca.AdvBase_InitializeGame_14450, loca.AdvBase_InitializeGame_14451, loca.AdvBase_InitializeGame_14452, loca.AdvBase_InitializeGame_14453, loca.AdvBase_InitializeGame_14454, loca.AdvBase_InitializeGame_14455, loca.AdvBase_InitializeGame_14456, loca.AdvBase_InitializeGame_14457, loca.AdvBase_InitializeGame_14458, loca.AdvBase_InitializeGame_14459));
            VerbTenses.Add(new VerbTenses(CB!.VT_holen, loca.AdvBase_InitializeGame_14460, loca.AdvBase_InitializeGame_14461, loca.AdvBase_InitializeGame_14462, loca.AdvBase_InitializeGame_14463, loca.AdvBase_InitializeGame_14464, loca.AdvBase_InitializeGame_14465, loca.AdvBase_InitializeGame_14466, loca.AdvBase_InitializeGame_14467, loca.AdvBase_InitializeGame_14468, loca.AdvBase_InitializeGame_14469, loca.AdvBase_InitializeGame_14470, loca.AdvBase_InitializeGame_14471, loca.AdvBase_InitializeGame_14472));
            VerbTenses.Add(new VerbTenses(CB!.VT_ziehen, loca.AdvBase_InitializeGame_14473, loca.AdvBase_InitializeGame_14474, loca.AdvBase_InitializeGame_14475, loca.AdvBase_InitializeGame_14476, loca.AdvBase_InitializeGame_14477, loca.AdvBase_InitializeGame_14478, loca.AdvBase_InitializeGame_14479, loca.AdvBase_InitializeGame_14480, loca.AdvBase_InitializeGame_14481, loca.AdvBase_InitializeGame_14482, loca.AdvBase_InitializeGame_14483, loca.AdvBase_InitializeGame_14484, loca.AdvBase_InitializeGame_14485));
            VerbTenses.Add(new VerbTenses(CB!.VT_schauen, loca.AdvBase_InitializeGame_14486, loca.AdvBase_InitializeGame_14487, loca.AdvBase_InitializeGame_14488, loca.AdvBase_InitializeGame_14489, loca.AdvBase_InitializeGame_14490, loca.AdvBase_InitializeGame_14491, loca.AdvBase_InitializeGame_14492, loca.AdvBase_InitializeGame_14493, loca.AdvBase_InitializeGame_14494, loca.AdvBase_InitializeGame_14495, loca.AdvBase_InitializeGame_14496, loca.AdvBase_InitializeGame_14497, loca.AdvBase_InitializeGame_14498));
            VerbTenses.Add(new VerbTenses(CB!.VT_umschauen, loca.AdvBase_InitializeGame_14499, loca.AdvBase_InitializeGame_14500, loca.AdvBase_InitializeGame_14501, loca.AdvBase_InitializeGame_14502, loca.AdvBase_InitializeGame_14503, loca.AdvBase_InitializeGame_14504, loca.AdvBase_InitializeGame_14505, loca.AdvBase_InitializeGame_14506, loca.AdvBase_InitializeGame_14507, loca.AdvBase_InitializeGame_14508, loca.AdvBase_InitializeGame_14509, loca.AdvBase_InitializeGame_14510, loca.AdvBase_InitializeGame_14511));
            VerbTenses.Add(new VerbTenses(CB!.VT_anschauen, loca.AdvBase_InitializeGame_14512, loca.AdvBase_InitializeGame_14513, loca.AdvBase_InitializeGame_14514, loca.AdvBase_InitializeGame_14515, loca.AdvBase_InitializeGame_14516, loca.AdvBase_InitializeGame_14517, loca.AdvBase_InitializeGame_14518, loca.AdvBase_InitializeGame_14519, loca.AdvBase_InitializeGame_14520, loca.AdvBase_InitializeGame_14521, loca.AdvBase_InitializeGame_14522, loca.AdvBase_InitializeGame_14523, loca.AdvBase_InitializeGame_14524));
            VerbTenses.Add(new VerbTenses(CB!.VT_legen, loca.AdvBase_InitializeGame_14525, loca.AdvBase_InitializeGame_14526, loca.AdvBase_InitializeGame_14527, loca.AdvBase_InitializeGame_14528, loca.AdvBase_InitializeGame_14529, loca.AdvBase_InitializeGame_14530, loca.AdvBase_InitializeGame_14531, loca.AdvBase_InitializeGame_14532, loca.AdvBase_InitializeGame_14533, loca.AdvBase_InitializeGame_14534, loca.AdvBase_InitializeGame_14535, loca.AdvBase_InitializeGame_14536, loca.AdvBase_InitializeGame_14537));
            VerbTenses.Add(new VerbTenses(CB!.VT_sehen, loca.AdvBase_InitializeGame_14538, loca.AdvBase_InitializeGame_14539, loca.AdvBase_InitializeGame_14540, loca.AdvBase_InitializeGame_14541, loca.AdvBase_InitializeGame_14542, loca.AdvBase_InitializeGame_14543, loca.AdvBase_InitializeGame_14544, loca.AdvBase_InitializeGame_14545, loca.AdvBase_InitializeGame_14546, loca.AdvBase_InitializeGame_14547, loca.AdvBase_InitializeGame_14548, loca.AdvBase_InitializeGame_14549, loca.AdvBase_InitializeGame_14550));
            VerbTenses.Add(new VerbTenses(CB!.VT_geben, loca.AdvBase_InitializeGame_14551, loca.AdvBase_InitializeGame_14552, loca.AdvBase_InitializeGame_14553, loca.AdvBase_InitializeGame_14554, loca.AdvBase_InitializeGame_14555, loca.AdvBase_InitializeGame_14556, loca.AdvBase_InitializeGame_14557, loca.AdvBase_InitializeGame_14558, loca.AdvBase_InitializeGame_14559, loca.AdvBase_InitializeGame_14560, loca.AdvBase_InitializeGame_14561, loca.AdvBase_InitializeGame_14562, loca.AdvBase_InitializeGame_14563));
            VerbTenses.Add(new VerbTenses(CB!.VT_stehen, loca.AdvBase_InitializeGame_14564, loca.AdvBase_InitializeGame_14565, loca.AdvBase_InitializeGame_14566, loca.AdvBase_InitializeGame_14567, loca.AdvBase_InitializeGame_14568, loca.AdvBase_InitializeGame_14569, loca.AdvBase_InitializeGame_14570, loca.AdvBase_InitializeGame_14571, loca.AdvBase_InitializeGame_14572, loca.AdvBase_InitializeGame_14573, loca.AdvBase_InitializeGame_14574, loca.AdvBase_InitializeGame_14575, loca.AdvBase_InitializeGame_14576));
            VerbTenses.Add(new VerbTenses(CB!.VT_sein, loca.AdvBase_InitializeGame_14577, loca.AdvBase_InitializeGame_14578, loca.AdvBase_InitializeGame_14579, loca.AdvBase_InitializeGame_14580, loca.AdvBase_InitializeGame_14581, loca.AdvBase_InitializeGame_14582, loca.AdvBase_InitializeGame_14583, loca.AdvBase_InitializeGame_14584, loca.AdvBase_InitializeGame_14585, loca.AdvBase_InitializeGame_14586, loca.AdvBase_InitializeGame_14587, loca.AdvBase_InitializeGame_14588, loca.AdvBase_InitializeGame_14589));
            VerbTenses.Add(new VerbTenses(CB!.VT_kauern, loca.AdvBase_InitializeGame_14590, loca.AdvBase_InitializeGame_14591, loca.AdvBase_InitializeGame_14592, loca.AdvBase_InitializeGame_14593, loca.AdvBase_InitializeGame_14594, loca.AdvBase_InitializeGame_14595, loca.AdvBase_InitializeGame_14596, loca.AdvBase_InitializeGame_14597, loca.AdvBase_InitializeGame_14598, loca.AdvBase_InitializeGame_14599, loca.AdvBase_InitializeGame_14600, loca.AdvBase_InitializeGame_14601, loca.AdvBase_InitializeGame_14602));
            VerbTenses.Add(new VerbTenses(CB!.VT_herumzerren, loca.AdvBase_InitializeGame_14603, loca.AdvBase_InitializeGame_14604, loca.AdvBase_InitializeGame_14605, loca.AdvBase_InitializeGame_14606, loca.AdvBase_InitializeGame_14607, loca.AdvBase_InitializeGame_14608, loca.AdvBase_InitializeGame_14609, loca.AdvBase_InitializeGame_14610, loca.AdvBase_InitializeGame_14611, loca.AdvBase_InitializeGame_14612, loca.AdvBase_InitializeGame_14613, loca.AdvBase_InitializeGame_14614, loca.AdvBase_InitializeGame_14615));
            VerbTenses.Add(new VerbTenses(CB!.VT_halten, loca.AdvBase_InitializeGame_14616, loca.AdvBase_InitializeGame_14617, loca.AdvBase_InitializeGame_14618, loca.AdvBase_InitializeGame_14619, loca.AdvBase_InitializeGame_14620, loca.AdvBase_InitializeGame_14621, loca.AdvBase_InitializeGame_14622, loca.AdvBase_InitializeGame_14623, loca.AdvBase_InitializeGame_14624, loca.AdvBase_InitializeGame_14625, loca.AdvBase_InitializeGame_14626, loca.AdvBase_InitializeGame_14627, loca.AdvBase_InitializeGame_14628));
            VerbTenses.Add(new VerbTenses(CB!.VT_wollen, loca.AdvBase_InitializeGame_14629, loca.AdvBase_InitializeGame_14630, loca.AdvBase_InitializeGame_14631, loca.AdvBase_InitializeGame_14632, loca.AdvBase_InitializeGame_14633, loca.AdvBase_InitializeGame_14634, loca.AdvBase_InitializeGame_14635, loca.AdvBase_InitializeGame_14636, loca.AdvBase_InitializeGame_14637, loca.AdvBase_InitializeGame_14638, loca.AdvBase_InitializeGame_14639, loca.AdvBase_InitializeGame_14640, loca.AdvBase_InitializeGame_14641));
            VerbTenses.Add(new VerbTenses(CB!.VT_bitten, loca.AdvBase_InitializeGame_14642, loca.AdvBase_InitializeGame_14643, loca.AdvBase_InitializeGame_14644, loca.AdvBase_InitializeGame_14645, loca.AdvBase_InitializeGame_14646, loca.AdvBase_InitializeGame_14647, loca.AdvBase_InitializeGame_14648, loca.AdvBase_InitializeGame_14649, loca.AdvBase_InitializeGame_14650, loca.AdvBase_InitializeGame_14651, loca.AdvBase_InitializeGame_14652, loca.AdvBase_InitializeGame_14653, loca.AdvBase_InitializeGame_14654));
            VerbTenses.Add(new VerbTenses(CB!.VT_fordern, loca.AdvBase_InitializeGame_14655, loca.AdvBase_InitializeGame_14656, loca.AdvBase_InitializeGame_14657, loca.AdvBase_InitializeGame_14658, loca.AdvBase_InitializeGame_14659, loca.AdvBase_InitializeGame_14660, loca.AdvBase_InitializeGame_14661, loca.AdvBase_InitializeGame_14662, loca.AdvBase_InitializeGame_14663, loca.AdvBase_InitializeGame_14664, loca.AdvBase_InitializeGame_14665, loca.AdvBase_InitializeGame_14666, loca.AdvBase_InitializeGame_14667));
            VerbTenses.Add(new VerbTenses(CB!.VT_setzen, loca.AdvBase_InitializeGame_14668, loca.AdvBase_InitializeGame_14669, loca.AdvBase_InitializeGame_14670, loca.AdvBase_InitializeGame_14671, loca.AdvBase_InitializeGame_14672, loca.AdvBase_InitializeGame_14673, loca.AdvBase_InitializeGame_14674, loca.AdvBase_InitializeGame_14675, loca.AdvBase_InitializeGame_14676, loca.AdvBase_InitializeGame_14677, loca.AdvBase_InitializeGame_14678, loca.AdvBase_InitializeGame_14679, loca.AdvBase_InitializeGame_14680));
            VerbTenses.Add(new VerbTenses(CB!.VT_setzen, loca.AdvBase_InitializeGame_14681, loca.AdvBase_InitializeGame_14682, loca.AdvBase_InitializeGame_14683, loca.AdvBase_InitializeGame_14684, loca.AdvBase_InitializeGame_14685, loca.AdvBase_InitializeGame_14686, loca.AdvBase_InitializeGame_14687, loca.AdvBase_InitializeGame_14688, loca.AdvBase_InitializeGame_14689, loca.AdvBase_InitializeGame_14690, loca.AdvBase_InitializeGame_14691, loca.AdvBase_InitializeGame_14692, loca.AdvBase_InitializeGame_14693));
            VerbTenses.Add(new VerbTenses(CB!.VT_finden, loca.AdvBase_InitializeGame_14694, loca.AdvBase_InitializeGame_14695, loca.AdvBase_InitializeGame_14696, loca.AdvBase_InitializeGame_14697, loca.AdvBase_InitializeGame_14698, loca.AdvBase_InitializeGame_14699, loca.AdvBase_InitializeGame_14700, loca.AdvBase_InitializeGame_14701, loca.AdvBase_InitializeGame_14702, loca.AdvBase_InitializeGame_14703, loca.AdvBase_InitializeGame_14704, loca.AdvBase_InitializeGame_14705, loca.AdvBase_InitializeGame_14706));
            VerbTenses.Add(new VerbTenses(CB!.VT_aufstehen, loca.AdvBase_InitializeGame_14707, loca.AdvBase_InitializeGame_14708, loca.AdvBase_InitializeGame_14709, loca.AdvBase_InitializeGame_14710, loca.AdvBase_InitializeGame_14711, loca.AdvBase_InitializeGame_14712, loca.AdvBase_InitializeGame_14713, loca.AdvBase_InitializeGame_14714, loca.AdvBase_InitializeGame_14715, loca.AdvBase_InitializeGame_14716, loca.AdvBase_InitializeGame_14717, loca.AdvBase_InitializeGame_14718, loca.AdvBase_InitializeGame_14719));
            VerbTenses.Add(new VerbTenses(CB!.VT_strangulieren, loca.AdvBase_InitializeGame_14720, loca.AdvBase_InitializeGame_14721, loca.AdvBase_InitializeGame_14722, loca.AdvBase_InitializeGame_14723, loca.AdvBase_InitializeGame_14724, loca.AdvBase_InitializeGame_14725, loca.AdvBase_InitializeGame_14726, loca.AdvBase_InitializeGame_14727, loca.AdvBase_InitializeGame_14728, loca.AdvBase_InitializeGame_14729, loca.AdvBase_InitializeGame_14730, loca.AdvBase_InitializeGame_14731, loca.AdvBase_InitializeGame_14732));
            VerbTenses.Add(new VerbTenses(CB!.VT_druecken, loca.AdvBase_InitializeGame_14733, loca.AdvBase_InitializeGame_14734, loca.AdvBase_InitializeGame_14735, loca.AdvBase_InitializeGame_14736, loca.AdvBase_InitializeGame_14737, loca.AdvBase_InitializeGame_14738, loca.AdvBase_InitializeGame_14739, loca.AdvBase_InitializeGame_14740, loca.AdvBase_InitializeGame_14741, loca.AdvBase_InitializeGame_14742, loca.AdvBase_InitializeGame_14743, loca.AdvBase_InitializeGame_14744, loca.AdvBase_InitializeGame_14745));
            VerbTenses.Add(new VerbTenses(CB!.VT_fallen, loca.AdvBase_InitializeGame_14746, loca.AdvBase_InitializeGame_14747, loca.AdvBase_InitializeGame_14748, loca.AdvBase_InitializeGame_14749, loca.AdvBase_InitializeGame_14750, loca.AdvBase_InitializeGame_14751, loca.AdvBase_InitializeGame_14752, loca.AdvBase_InitializeGame_14753, loca.AdvBase_InitializeGame_14754, loca.AdvBase_InitializeGame_14755, loca.AdvBase_InitializeGame_14756, loca.AdvBase_InitializeGame_14757, loca.AdvBase_InitializeGame_14758));
            VerbTenses.Add(new VerbTenses(CB!.VT_sagen, loca.AdvBase_InitializeGame_14759, loca.AdvBase_InitializeGame_14760, loca.AdvBase_InitializeGame_14761, loca.AdvBase_InitializeGame_14762, loca.AdvBase_InitializeGame_14763, loca.AdvBase_InitializeGame_14764, loca.AdvBase_InitializeGame_14765, loca.AdvBase_InitializeGame_14766, loca.AdvBase_InitializeGame_14767, loca.AdvBase_InitializeGame_14768, loca.AdvBase_InitializeGame_14769, loca.AdvBase_InitializeGame_14770, loca.AdvBase_InitializeGame_14771));
            VerbTenses.Add(new VerbTenses(CB!.VT_fragen, loca.AdvBase_InitializeGame_14772, loca.AdvBase_InitializeGame_14773, loca.AdvBase_InitializeGame_14774, loca.AdvBase_InitializeGame_14775, loca.AdvBase_InitializeGame_14776, loca.AdvBase_InitializeGame_14777, loca.AdvBase_InitializeGame_14778, loca.AdvBase_InitializeGame_14779, loca.AdvBase_InitializeGame_14780, loca.AdvBase_InitializeGame_14781, loca.AdvBase_InitializeGame_14782, loca.AdvBase_InitializeGame_14783, loca.AdvBase_InitializeGame_14784));
            VerbTenses.Add(new VerbTenses(CB!.VT_lesen, loca.AdvBase_InitializeGame_14785, loca.AdvBase_InitializeGame_14786, loca.AdvBase_InitializeGame_14787, loca.AdvBase_InitializeGame_14788, loca.AdvBase_InitializeGame_14789, loca.AdvBase_InitializeGame_14790, loca.AdvBase_InitializeGame_14791, loca.AdvBase_InitializeGame_14792, loca.AdvBase_InitializeGame_14793, loca.AdvBase_InitializeGame_14794, loca.AdvBase_InitializeGame_14795, loca.AdvBase_InitializeGame_14796, loca.AdvBase_InitializeGame_14797));
            VerbTenses.Add(new VerbTenses(CB!.VT_steigen, loca.AdvBase_InitializeGame_14798, loca.AdvBase_InitializeGame_14799, loca.AdvBase_InitializeGame_14800, loca.AdvBase_InitializeGame_14801, loca.AdvBase_InitializeGame_14802, loca.AdvBase_InitializeGame_14803, loca.AdvBase_InitializeGame_14804, loca.AdvBase_InitializeGame_14805, loca.AdvBase_InitializeGame_14806, loca.AdvBase_InitializeGame_14807, loca.AdvBase_InitializeGame_14808, loca.AdvBase_InitializeGame_14809, loca.AdvBase_InitializeGame_14810));
            VerbTenses.Add(new VerbTenses(CB!.VT_schmecken, loca.AdvBase_InitializeGame_14811, loca.AdvBase_InitializeGame_14812, loca.AdvBase_InitializeGame_14813, loca.AdvBase_InitializeGame_14814, loca.AdvBase_InitializeGame_14815, loca.AdvBase_InitializeGame_14816, loca.AdvBase_InitializeGame_14817, loca.AdvBase_InitializeGame_14818, loca.AdvBase_InitializeGame_14819, loca.AdvBase_InitializeGame_14820, loca.AdvBase_InitializeGame_14821, loca.AdvBase_InitializeGame_14822, loca.AdvBase_InitializeGame_14823));
            VerbTenses.Add(new VerbTenses(CB!.VT_riechen, loca.AdvBase_InitializeGame_14824, loca.AdvBase_InitializeGame_14825, loca.AdvBase_InitializeGame_14826, loca.AdvBase_InitializeGame_14827, loca.AdvBase_InitializeGame_14828, loca.AdvBase_InitializeGame_14829, loca.AdvBase_InitializeGame_14830, loca.AdvBase_InitializeGame_14831, loca.AdvBase_InitializeGame_14832, loca.AdvBase_InitializeGame_14833, loca.AdvBase_InitializeGame_14834, loca.AdvBase_InitializeGame_14835, loca.AdvBase_InitializeGame_14836));
            VerbTenses.Add(new VerbTenses(CB!.VT_warten, loca.AdvBase_InitializeGame_14837, loca.AdvBase_InitializeGame_14838, loca.AdvBase_InitializeGame_14839, loca.AdvBase_InitializeGame_14840, loca.AdvBase_InitializeGame_14841, loca.AdvBase_InitializeGame_14842, loca.AdvBase_InitializeGame_14843, loca.AdvBase_InitializeGame_14844, loca.AdvBase_InitializeGame_14845, loca.AdvBase_InitializeGame_14846, loca.AdvBase_InitializeGame_14847, loca.AdvBase_InitializeGame_14848, loca.AdvBase_InitializeGame_14849));
            VerbTenses.Add(new VerbTenses(CB!.VT_erscheinen, loca.AdvBase_InitializeGame_14850, loca.AdvBase_InitializeGame_14851, loca.AdvBase_InitializeGame_14852, loca.AdvBase_InitializeGame_14853, loca.AdvBase_InitializeGame_14854, loca.AdvBase_InitializeGame_14855, loca.AdvBase_InitializeGame_14856, loca.AdvBase_InitializeGame_14857, loca.AdvBase_InitializeGame_14858, loca.AdvBase_InitializeGame_14859, loca.AdvBase_InitializeGame_14860, loca.AdvBase_InitializeGame_14861, loca.AdvBase_InitializeGame_14862));
            VerbTenses.Add(new VerbTenses(CB!.VT_loesen, loca.AdvBase_InitializeGame_14863, loca.AdvBase_InitializeGame_14864, loca.AdvBase_InitializeGame_14865, loca.AdvBase_InitializeGame_14866, loca.AdvBase_InitializeGame_14867, loca.AdvBase_InitializeGame_14868, loca.AdvBase_InitializeGame_14869, loca.AdvBase_InitializeGame_14870, loca.AdvBase_InitializeGame_14871, loca.AdvBase_InitializeGame_14872, loca.AdvBase_InitializeGame_14873, loca.AdvBase_InitializeGame_14874, loca.AdvBase_InitializeGame_14875));
            VerbTenses.Add(new VerbTenses(CB!.VT_befinden, loca.AdvBase_InitializeGame_14876, loca.AdvBase_InitializeGame_14877, loca.AdvBase_InitializeGame_14878, loca.AdvBase_InitializeGame_14879, loca.AdvBase_InitializeGame_14880, loca.AdvBase_InitializeGame_14881, loca.AdvBase_InitializeGame_14882, loca.AdvBase_InitializeGame_14883, loca.AdvBase_InitializeGame_14884, loca.AdvBase_InitializeGame_14885, loca.AdvBase_InitializeGame_14886, loca.AdvBase_InitializeGame_14887, loca.AdvBase_InitializeGame_14888));
            VerbTenses.Add(new VerbTenses(CB!.VT_brechen, loca.AdvBase_InitializeGame_14889, loca.AdvBase_InitializeGame_14890, loca.AdvBase_InitializeGame_14891, loca.AdvBase_InitializeGame_14892, loca.AdvBase_InitializeGame_14893, loca.AdvBase_InitializeGame_14894, loca.AdvBase_InitializeGame_14895, loca.AdvBase_InitializeGame_14896, loca.AdvBase_InitializeGame_14897, loca.AdvBase_InitializeGame_14898, loca.AdvBase_InitializeGame_14899, loca.AdvBase_InitializeGame_14900, loca.AdvBase_InitializeGame_14901));
            VerbTenses.Add(new VerbTenses(CB!.VT_kraechzen, loca.AdvBase_InitializeGame_14902, loca.AdvBase_InitializeGame_14903, loca.AdvBase_InitializeGame_14904, loca.AdvBase_InitializeGame_14905, loca.AdvBase_InitializeGame_14906, loca.AdvBase_InitializeGame_14907, loca.AdvBase_InitializeGame_14908, loca.AdvBase_InitializeGame_14909, loca.AdvBase_InitializeGame_14910, loca.AdvBase_InitializeGame_14911, loca.AdvBase_InitializeGame_14912, loca.AdvBase_InitializeGame_14913, loca.AdvBase_InitializeGame_14914));
            VerbTenses.Add(new VerbTenses(CB!.VT_greifen, loca.AdvBase_InitializeGame_14915, loca.AdvBase_InitializeGame_14916, loca.AdvBase_InitializeGame_14917, loca.AdvBase_InitializeGame_14918, loca.AdvBase_InitializeGame_14919, loca.AdvBase_InitializeGame_14920, loca.AdvBase_InitializeGame_14921, loca.AdvBase_InitializeGame_14922, loca.AdvBase_InitializeGame_14923, loca.AdvBase_InitializeGame_14924, loca.AdvBase_InitializeGame_14925, loca.AdvBase_InitializeGame_14926, loca.AdvBase_InitializeGame_14927));
            VerbTenses.Add(new VerbTenses(CB!.VT_stochern, loca.AdvBase_InitializeGame_14928, loca.AdvBase_InitializeGame_14929, loca.AdvBase_InitializeGame_14930, loca.AdvBase_InitializeGame_14931, loca.AdvBase_InitializeGame_14932, loca.AdvBase_InitializeGame_14933, loca.AdvBase_InitializeGame_14934, loca.AdvBase_InitializeGame_14935, loca.AdvBase_InitializeGame_14936, loca.AdvBase_InitializeGame_14937, loca.AdvBase_InitializeGame_14938, loca.AdvBase_InitializeGame_14939, loca.AdvBase_InitializeGame_14940));
            VerbTenses.Add(new VerbTenses(CB!.VT_versuchen, loca.AdvBase_InitializeGame_14941, loca.AdvBase_InitializeGame_14942, loca.AdvBase_InitializeGame_14943, loca.AdvBase_InitializeGame_14944, loca.AdvBase_InitializeGame_14945, loca.AdvBase_InitializeGame_14946, loca.AdvBase_InitializeGame_14947, loca.AdvBase_InitializeGame_14948, loca.AdvBase_InitializeGame_14949, loca.AdvBase_InitializeGame_14950, loca.AdvBase_InitializeGame_14951, loca.AdvBase_InitializeGame_14952, loca.AdvBase_InitializeGame_14953));
            VerbTenses.Add(new VerbTenses(CB!.VT_betreten, loca.AdvBase_InitializeGame_14954, loca.AdvBase_InitializeGame_14955, loca.AdvBase_InitializeGame_14956, loca.AdvBase_InitializeGame_14957, loca.AdvBase_InitializeGame_14958, loca.AdvBase_InitializeGame_14959, loca.AdvBase_InitializeGame_14960, loca.AdvBase_InitializeGame_14961, loca.AdvBase_InitializeGame_14962, loca.AdvBase_InitializeGame_14963, loca.AdvBase_InitializeGame_14964, loca.AdvBase_InitializeGame_14965, loca.AdvBase_InitializeGame_14966));
            VerbTenses.Add(new VerbTenses(CB!.VT_schneiden, loca.AdvBase_InitializeGame_14967, loca.AdvBase_InitializeGame_14968, loca.AdvBase_InitializeGame_14969, loca.AdvBase_InitializeGame_14970, loca.AdvBase_InitializeGame_14971, loca.AdvBase_InitializeGame_14972, loca.AdvBase_InitializeGame_14973, loca.AdvBase_InitializeGame_14974, loca.AdvBase_InitializeGame_14975, loca.AdvBase_InitializeGame_14976, loca.AdvBase_InitializeGame_14977, loca.AdvBase_InitializeGame_14978, loca.AdvBase_InitializeGame_14979));
            VerbTenses.Add(new VerbTenses(CB!.VT_verknoten, loca.AdvBase_InitializeGame_14980, loca.AdvBase_InitializeGame_14981, loca.AdvBase_InitializeGame_14982, loca.AdvBase_InitializeGame_14983, loca.AdvBase_InitializeGame_14984, loca.AdvBase_InitializeGame_14985, loca.AdvBase_InitializeGame_14986, loca.AdvBase_InitializeGame_14987, loca.AdvBase_InitializeGame_14988, loca.AdvBase_InitializeGame_14989, loca.AdvBase_InitializeGame_14990, loca.AdvBase_InitializeGame_14991, loca.AdvBase_InitializeGame_14992));
            VerbTenses.Add(new VerbTenses(CB!.VT_leuchten, loca.AdvBase_InitializeGame_14993, loca.AdvBase_InitializeGame_14994, loca.AdvBase_InitializeGame_14995, loca.AdvBase_InitializeGame_14996, loca.AdvBase_InitializeGame_14997, loca.AdvBase_InitializeGame_14998, loca.AdvBase_InitializeGame_14999, loca.AdvBase_InitializeGame_15000, loca.AdvBase_InitializeGame_15001, loca.AdvBase_InitializeGame_15002, loca.AdvBase_InitializeGame_15003, loca.AdvBase_InitializeGame_15004, loca.AdvBase_InitializeGame_15005));
            VerbTenses.Add(new VerbTenses(CB!.VT_entzuenden, loca.AdvBase_InitializeGame_15006, loca.AdvBase_InitializeGame_15007, loca.AdvBase_InitializeGame_15008, loca.AdvBase_InitializeGame_15009, loca.AdvBase_InitializeGame_15010, loca.AdvBase_InitializeGame_15011, loca.AdvBase_InitializeGame_15012, loca.AdvBase_InitializeGame_15013, loca.AdvBase_InitializeGame_15014, loca.AdvBase_InitializeGame_15015, loca.AdvBase_InitializeGame_15016, loca.AdvBase_InitializeGame_15017, loca.AdvBase_InitializeGame_15018));
            VerbTenses.Add(new VerbTenses(CB!.VT_loeschen, loca.AdvBase_InitializeGame_15019, loca.AdvBase_InitializeGame_15020, loca.AdvBase_InitializeGame_15021, loca.AdvBase_InitializeGame_15022, loca.AdvBase_InitializeGame_15023, loca.AdvBase_InitializeGame_15024, loca.AdvBase_InitializeGame_15025, loca.AdvBase_InitializeGame_15026, loca.AdvBase_InitializeGame_15027, loca.AdvBase_InitializeGame_15028, loca.AdvBase_InitializeGame_15029, loca.AdvBase_InitializeGame_15030, loca.AdvBase_InitializeGame_15031));
            VerbTenses.Add(new VerbTenses(CB!.VT_fischen, loca.AdvBase_InitializeGame_15032, loca.AdvBase_InitializeGame_15033, loca.AdvBase_InitializeGame_15034, loca.AdvBase_InitializeGame_15035, loca.AdvBase_InitializeGame_15036, loca.AdvBase_InitializeGame_15037, loca.AdvBase_InitializeGame_15038, loca.AdvBase_InitializeGame_15039, loca.AdvBase_InitializeGame_15040, loca.AdvBase_InitializeGame_15041, loca.AdvBase_InitializeGame_15042, loca.AdvBase_InitializeGame_15043, loca.AdvBase_InitializeGame_15044));
            VerbTenses.Add(new VerbTenses(CB!.VT_moegen, loca.AdvBase_InitializeGame_15045, loca.AdvBase_InitializeGame_15046, loca.AdvBase_InitializeGame_15047, loca.AdvBase_InitializeGame_15048, loca.AdvBase_InitializeGame_15049, loca.AdvBase_InitializeGame_15050, loca.AdvBase_InitializeGame_15051, loca.AdvBase_InitializeGame_15052, loca.AdvBase_InitializeGame_15053, loca.AdvBase_InitializeGame_15054, loca.AdvBase_InitializeGame_15055, loca.AdvBase_InitializeGame_15056, loca.AdvBase_InitializeGame_15057));
            VerbTenses.Add(new VerbTenses(CB!.VT_sprechen, loca.AdvBase_InitializeGame_15058, loca.AdvBase_InitializeGame_15059, loca.AdvBase_InitializeGame_15060, loca.AdvBase_InitializeGame_15061, loca.AdvBase_InitializeGame_15062, loca.AdvBase_InitializeGame_15063, loca.AdvBase_InitializeGame_15064, loca.AdvBase_InitializeGame_15065, loca.AdvBase_InitializeGame_15066, loca.AdvBase_InitializeGame_15067, loca.AdvBase_InitializeGame_15068, loca.AdvBase_InitializeGame_15069, loca.AdvBase_InitializeGame_15070));
            VerbTenses.Add(new VerbTenses(CB!.VT_beruehren, loca.AdvBase_InitializeGame_15071, loca.AdvBase_InitializeGame_15072, loca.AdvBase_InitializeGame_15073, loca.AdvBase_InitializeGame_15074, loca.AdvBase_InitializeGame_15075, loca.AdvBase_InitializeGame_15076, loca.AdvBase_InitializeGame_15077, loca.AdvBase_InitializeGame_15078, loca.AdvBase_InitializeGame_15079, loca.AdvBase_InitializeGame_15080, loca.AdvBase_InitializeGame_15081, loca.AdvBase_InitializeGame_15082, loca.AdvBase_InitializeGame_15083));
            VerbTenses.Add(new VerbTenses(CB!.VT_fuehren, loca.AdvBase_InitializeGame_15084, loca.AdvBase_InitializeGame_15085, loca.AdvBase_InitializeGame_15086, loca.AdvBase_InitializeGame_15087, loca.AdvBase_InitializeGame_15088, loca.AdvBase_InitializeGame_15089, loca.AdvBase_InitializeGame_15090, loca.AdvBase_InitializeGame_15091, loca.AdvBase_InitializeGame_15092, loca.AdvBase_InitializeGame_15093, loca.AdvBase_InitializeGame_15094, loca.AdvBase_InitializeGame_15095, loca.AdvBase_InitializeGame_15096));
            VerbTenses.Add(new VerbTenses(CB!.VT_lassen, loca.AdvBase_InitializeGame_15097, loca.AdvBase_InitializeGame_15098, loca.AdvBase_InitializeGame_15099, loca.AdvBase_InitializeGame_15100, loca.AdvBase_InitializeGame_15101, loca.AdvBase_InitializeGame_15102, loca.AdvBase_InitializeGame_15103, loca.AdvBase_InitializeGame_15104, loca.AdvBase_InitializeGame_15105, loca.AdvBase_InitializeGame_15106, loca.AdvBase_InitializeGame_15107, loca.AdvBase_InitializeGame_15108, loca.AdvBase_InitializeGame_15109));
            VerbTenses.Add(new VerbTenses(CB!.VT_passen, loca.AdvBase_InitializeGame_15110, loca.AdvBase_InitializeGame_15111, loca.AdvBase_InitializeGame_15112, loca.AdvBase_InitializeGame_15113, loca.AdvBase_InitializeGame_15114, loca.AdvBase_InitializeGame_15115, loca.AdvBase_InitializeGame_15116, loca.AdvBase_InitializeGame_15117, loca.AdvBase_InitializeGame_15118, loca.AdvBase_InitializeGame_15119, loca.AdvBase_InitializeGame_15120, loca.AdvBase_InitializeGame_15121, loca.AdvBase_InitializeGame_15122));
            VerbTenses.Add(new VerbTenses(CB!.VT_weichen, loca.AdvBase_InitializeGame_15123, loca.AdvBase_InitializeGame_15124, loca.AdvBase_InitializeGame_15125, loca.AdvBase_InitializeGame_15126, loca.AdvBase_InitializeGame_15127, loca.AdvBase_InitializeGame_15128, loca.AdvBase_InitializeGame_15129, loca.AdvBase_InitializeGame_15130, loca.AdvBase_InitializeGame_15131, loca.AdvBase_InitializeGame_15132, loca.AdvBase_InitializeGame_15133, loca.AdvBase_InitializeGame_15134, loca.AdvBase_InitializeGame_15135));
            VerbTenses.Add(new VerbTenses(CB!.VT_heben, loca.AdvBase_InitializeGame_15136, loca.AdvBase_InitializeGame_15137, loca.AdvBase_InitializeGame_15138, loca.AdvBase_InitializeGame_15139, loca.AdvBase_InitializeGame_15140, loca.AdvBase_InitializeGame_15141, loca.AdvBase_InitializeGame_15142, loca.AdvBase_InitializeGame_15143, loca.AdvBase_InitializeGame_15144, loca.AdvBase_InitializeGame_15145, loca.AdvBase_InitializeGame_15146, loca.AdvBase_InitializeGame_15147, loca.AdvBase_InitializeGame_15148));
            VerbTenses.Add(new VerbTenses(CB!.VT_klopfen, loca.AdvBase_InitializeGame_15149, loca.AdvBase_InitializeGame_15150, loca.AdvBase_InitializeGame_15151, loca.AdvBase_InitializeGame_15152, loca.AdvBase_InitializeGame_15153, loca.AdvBase_InitializeGame_15154, loca.AdvBase_InitializeGame_15155, loca.AdvBase_InitializeGame_15156, loca.AdvBase_InitializeGame_15157, loca.AdvBase_InitializeGame_15158, loca.AdvBase_InitializeGame_15159, loca.AdvBase_InitializeGame_15160, loca.AdvBase_InitializeGame_15161));
            VerbTenses.Add(new VerbTenses(CB!.VT_zeigen, loca.AdvBase_InitializeGame_15162, loca.AdvBase_InitializeGame_15163, loca.AdvBase_InitializeGame_15164, loca.AdvBase_InitializeGame_15165, loca.AdvBase_InitializeGame_15166, loca.AdvBase_InitializeGame_15167, loca.AdvBase_InitializeGame_15168, loca.AdvBase_InitializeGame_15169, loca.AdvBase_InitializeGame_15170, loca.AdvBase_InitializeGame_15171, loca.AdvBase_InitializeGame_15172, loca.AdvBase_InitializeGame_15173, loca.AdvBase_InitializeGame_15174));
            VerbTenses.Add(new VerbTenses(CB!.VT_entgegnen, loca.AdvBase_InitializeGame_15175, loca.AdvBase_InitializeGame_15176, loca.AdvBase_InitializeGame_15177, loca.AdvBase_InitializeGame_15178, loca.AdvBase_InitializeGame_15179, loca.AdvBase_InitializeGame_15180, loca.AdvBase_InitializeGame_15181, loca.AdvBase_InitializeGame_15182, loca.AdvBase_InitializeGame_15183, loca.AdvBase_InitializeGame_15184, loca.AdvBase_InitializeGame_15185, loca.AdvBase_InitializeGame_15186, loca.AdvBase_InitializeGame_15187));
            VerbTenses.Add(new VerbTenses(CB!.VT_erwaehnen, loca.AdvBase_InitializeGame_15188, loca.AdvBase_InitializeGame_15189, loca.AdvBase_InitializeGame_15190, loca.AdvBase_InitializeGame_15191, loca.AdvBase_InitializeGame_15192, loca.AdvBase_InitializeGame_15193, loca.AdvBase_InitializeGame_15194, loca.AdvBase_InitializeGame_15195, loca.AdvBase_InitializeGame_15196, loca.AdvBase_InitializeGame_15197, loca.AdvBase_InitializeGame_15198, loca.AdvBase_InitializeGame_15199, loca.AdvBase_InitializeGame_15200));
            VerbTenses.Add(new VerbTenses(CB!.VT_kreischen, loca.AdvBase_InitializeGame_15201, loca.AdvBase_InitializeGame_15202, loca.AdvBase_InitializeGame_15203, loca.AdvBase_InitializeGame_15204, loca.AdvBase_InitializeGame_15205, loca.AdvBase_InitializeGame_15206, loca.AdvBase_InitializeGame_15207, loca.AdvBase_InitializeGame_15208, loca.AdvBase_InitializeGame_15209, loca.AdvBase_InitializeGame_15210, loca.AdvBase_InitializeGame_15211, loca.AdvBase_InitializeGame_15212, loca.AdvBase_InitializeGame_15213));
            VerbTenses.Add(new VerbTenses(CB!.VT_saeuseln, loca.AdvBase_InitializeGame_15214, loca.AdvBase_InitializeGame_15215, loca.AdvBase_InitializeGame_15216, loca.AdvBase_InitializeGame_15217, loca.AdvBase_InitializeGame_15218, loca.AdvBase_InitializeGame_15219, loca.AdvBase_InitializeGame_15220, loca.AdvBase_InitializeGame_15221, loca.AdvBase_InitializeGame_15222, loca.AdvBase_InitializeGame_15223, loca.AdvBase_InitializeGame_15224, loca.AdvBase_InitializeGame_15225, loca.AdvBase_InitializeGame_15226));
            VerbTenses.Add(new VerbTenses(CB!.VT_bruellen, loca.AdvBase_InitializeGame_15227, loca.AdvBase_InitializeGame_15228, loca.AdvBase_InitializeGame_15229, loca.AdvBase_InitializeGame_15230, loca.AdvBase_InitializeGame_15231, loca.AdvBase_InitializeGame_15232, loca.AdvBase_InitializeGame_15233, loca.AdvBase_InitializeGame_15234, loca.AdvBase_InitializeGame_15235, loca.AdvBase_InitializeGame_15236, loca.AdvBase_InitializeGame_15237, loca.AdvBase_InitializeGame_15238, loca.AdvBase_InitializeGame_15239));
            VerbTenses.Add(new VerbTenses(CB!.VT_wueten, loca.AdvBase_InitializeGame_15240, loca.AdvBase_InitializeGame_15241, loca.AdvBase_InitializeGame_15242, loca.AdvBase_InitializeGame_15243, loca.AdvBase_InitializeGame_15244, loca.AdvBase_InitializeGame_15245, loca.AdvBase_InitializeGame_15246, loca.AdvBase_InitializeGame_15247, loca.AdvBase_InitializeGame_15248, loca.AdvBase_InitializeGame_15249, loca.AdvBase_InitializeGame_15250, loca.AdvBase_InitializeGame_15251, loca.AdvBase_InitializeGame_15252));
            VerbTenses.Add(new VerbTenses(CB!.VT_schreien, loca.AdvBase_InitializeGame_15253, loca.AdvBase_InitializeGame_15254, loca.AdvBase_InitializeGame_15255, loca.AdvBase_InitializeGame_15256, loca.AdvBase_InitializeGame_15257, loca.AdvBase_InitializeGame_15258, loca.AdvBase_InitializeGame_15259, loca.AdvBase_InitializeGame_15260, loca.AdvBase_InitializeGame_15261, loca.AdvBase_InitializeGame_15262, loca.AdvBase_InitializeGame_15263, loca.AdvBase_InitializeGame_15264, loca.AdvBase_InitializeGame_15265));
            VerbTenses.Add(new VerbTenses(CB!.VT_wispern, loca.AdvBase_InitializeGame_15266, loca.AdvBase_InitializeGame_15267, loca.AdvBase_InitializeGame_15268, loca.AdvBase_InitializeGame_15269, loca.AdvBase_InitializeGame_15270, loca.AdvBase_InitializeGame_15271, loca.AdvBase_InitializeGame_15272, loca.AdvBase_InitializeGame_15273, loca.AdvBase_InitializeGame_15274, loca.AdvBase_InitializeGame_15275, loca.AdvBase_InitializeGame_15276, loca.AdvBase_InitializeGame_15277, loca.AdvBase_InitializeGame_15278));
            VerbTenses.Add(new VerbTenses(CB!.VT_fluestern, loca.AdvBase_InitializeGame_15279, loca.AdvBase_InitializeGame_15280, loca.AdvBase_InitializeGame_15281, loca.AdvBase_InitializeGame_15282, loca.AdvBase_InitializeGame_15283, loca.AdvBase_InitializeGame_15284, loca.AdvBase_InitializeGame_15285, loca.AdvBase_InitializeGame_15286, loca.AdvBase_InitializeGame_15287, loca.AdvBase_InitializeGame_15288, loca.AdvBase_InitializeGame_15289, loca.AdvBase_InitializeGame_15290, loca.AdvBase_InitializeGame_15291));
            VerbTenses.Add(new VerbTenses(CB!.VT_grunzen, loca.AdvBase_InitializeGame_15292, loca.AdvBase_InitializeGame_15293, loca.AdvBase_InitializeGame_15294, loca.AdvBase_InitializeGame_15295, loca.AdvBase_InitializeGame_15296, loca.AdvBase_InitializeGame_15297, loca.AdvBase_InitializeGame_15298, loca.AdvBase_InitializeGame_15299, loca.AdvBase_InitializeGame_15300, loca.AdvBase_InitializeGame_15301, loca.AdvBase_InitializeGame_15302, loca.AdvBase_InitializeGame_15303, loca.AdvBase_InitializeGame_15304));
            VerbTenses.Add(new VerbTenses(CB!.VT_brummen, loca.AdvBase_InitializeGame_15305, loca.AdvBase_InitializeGame_15306, loca.AdvBase_InitializeGame_15307, loca.AdvBase_InitializeGame_15308, loca.AdvBase_InitializeGame_15309, loca.AdvBase_InitializeGame_15310, loca.AdvBase_InitializeGame_15311, loca.AdvBase_InitializeGame_15312, loca.AdvBase_InitializeGame_15313, loca.AdvBase_InitializeGame_15314, loca.AdvBase_InitializeGame_15315, loca.AdvBase_InitializeGame_15316, loca.AdvBase_InitializeGame_15317));
            VerbTenses.Add(new VerbTenses(CB!.VT_lachen, loca.AdvBase_InitializeGame_15318, loca.AdvBase_InitializeGame_15319, loca.AdvBase_InitializeGame_15320, loca.AdvBase_InitializeGame_15321, loca.AdvBase_InitializeGame_15322, loca.AdvBase_InitializeGame_15323, loca.AdvBase_InitializeGame_15324, loca.AdvBase_InitializeGame_15325, loca.AdvBase_InitializeGame_15326, loca.AdvBase_InitializeGame_15327, loca.AdvBase_InitializeGame_15328, loca.AdvBase_InitializeGame_15329, loca.AdvBase_InitializeGame_15330));
            VerbTenses.Add(new VerbTenses(CB!.VT_keuchen, loca.AdvBase_InitializeGame_15331, loca.AdvBase_InitializeGame_15332, loca.AdvBase_InitializeGame_15333, loca.AdvBase_InitializeGame_15334, loca.AdvBase_InitializeGame_15335, loca.AdvBase_InitializeGame_15336, loca.AdvBase_InitializeGame_15337, loca.AdvBase_InitializeGame_15338, loca.AdvBase_InitializeGame_15339, loca.AdvBase_InitializeGame_15340, loca.AdvBase_InitializeGame_15341, loca.AdvBase_InitializeGame_15342, loca.AdvBase_InitializeGame_15343));
            VerbTenses.Add(new VerbTenses(CB!.VT_jauchzen, loca.AdvBase_InitializeGame_15344, loca.AdvBase_InitializeGame_15345, loca.AdvBase_InitializeGame_15346, loca.AdvBase_InitializeGame_15347, loca.AdvBase_InitializeGame_15348, loca.AdvBase_InitializeGame_15349, loca.AdvBase_InitializeGame_15350, loca.AdvBase_InitializeGame_15351, loca.AdvBase_InitializeGame_15352, loca.AdvBase_InitializeGame_15353, loca.AdvBase_InitializeGame_15354, loca.AdvBase_InitializeGame_15355, loca.AdvBase_InitializeGame_15356));
            VerbTenses.Add(new VerbTenses(CB!.VT_troeten, loca.AdvBase_InitializeGame_15357, loca.AdvBase_InitializeGame_15358, loca.AdvBase_InitializeGame_15359, loca.AdvBase_InitializeGame_15360, loca.AdvBase_InitializeGame_15361, loca.AdvBase_InitializeGame_15362, loca.AdvBase_InitializeGame_15363, loca.AdvBase_InitializeGame_15364, loca.AdvBase_InitializeGame_15365, loca.AdvBase_InitializeGame_15366, loca.AdvBase_InitializeGame_15367, loca.AdvBase_InitializeGame_15368, loca.AdvBase_InitializeGame_15369));
            VerbTenses.Add(new VerbTenses(CB!.VT_lachen, loca.AdvBase_InitializeGame_15370, loca.AdvBase_InitializeGame_15371, loca.AdvBase_InitializeGame_15372, loca.AdvBase_InitializeGame_15373, loca.AdvBase_InitializeGame_15374, loca.AdvBase_InitializeGame_15375, loca.AdvBase_InitializeGame_15376, loca.AdvBase_InitializeGame_15377, loca.AdvBase_InitializeGame_15378, loca.AdvBase_InitializeGame_15379, loca.AdvBase_InitializeGame_15380, loca.AdvBase_InitializeGame_15381, loca.AdvBase_InitializeGame_15382));
            VerbTenses.Add(new VerbTenses(CB!.VT_erklaeren, loca.AdvBase_InitializeGame_15383, loca.AdvBase_InitializeGame_15384, loca.AdvBase_InitializeGame_15385, loca.AdvBase_InitializeGame_15386, loca.AdvBase_InitializeGame_15387, loca.AdvBase_InitializeGame_15388, loca.AdvBase_InitializeGame_15389, loca.AdvBase_InitializeGame_15390, loca.AdvBase_InitializeGame_15391, loca.AdvBase_InitializeGame_15392, loca.AdvBase_InitializeGame_15393, loca.AdvBase_InitializeGame_15394, loca.AdvBase_InitializeGame_15395));
            VerbTenses.Add(new VerbTenses(CB!.VT_kichern, loca.AdvBase_InitializeGame_15396, loca.AdvBase_InitializeGame_15397, loca.AdvBase_InitializeGame_15398, loca.AdvBase_InitializeGame_15399, loca.AdvBase_InitializeGame_15400, loca.AdvBase_InitializeGame_15401, loca.AdvBase_InitializeGame_15402, loca.AdvBase_InitializeGame_15403, loca.AdvBase_InitializeGame_15404, loca.AdvBase_InitializeGame_15405, loca.AdvBase_InitializeGame_15406, loca.AdvBase_InitializeGame_15407, loca.AdvBase_InitializeGame_15408));
            VerbTenses.Add(new VerbTenses(CB!.VT_zischen, loca.AdvBase_InitializeGame_15409, loca.AdvBase_InitializeGame_15410, loca.AdvBase_InitializeGame_15411, loca.AdvBase_InitializeGame_15412, loca.AdvBase_InitializeGame_15413, loca.AdvBase_InitializeGame_15414, loca.AdvBase_InitializeGame_15415, loca.AdvBase_InitializeGame_15416, loca.AdvBase_InitializeGame_15417, loca.AdvBase_InitializeGame_15418, loca.AdvBase_InitializeGame_15419, loca.AdvBase_InitializeGame_15420, loca.AdvBase_InitializeGame_15421));
            VerbTenses.Add(new VerbTenses(CB!.VT_fabulieren, loca.AdvBase_InitializeGame_15422, loca.AdvBase_InitializeGame_15423, loca.AdvBase_InitializeGame_15424, loca.AdvBase_InitializeGame_15425, loca.AdvBase_InitializeGame_15426, loca.AdvBase_InitializeGame_15427, loca.AdvBase_InitializeGame_15428, loca.AdvBase_InitializeGame_15429, loca.AdvBase_InitializeGame_15430, loca.AdvBase_InitializeGame_15431, loca.AdvBase_InitializeGame_15432, loca.AdvBase_InitializeGame_15433, loca.AdvBase_InitializeGame_15434));
            VerbTenses.Add(new VerbTenses(CB!.VT_flehen, loca.AdvBase_InitializeGame_15435, loca.AdvBase_InitializeGame_15436, loca.AdvBase_InitializeGame_15437, loca.AdvBase_InitializeGame_15438, loca.AdvBase_InitializeGame_15439, loca.AdvBase_InitializeGame_15440, loca.AdvBase_InitializeGame_15441, loca.AdvBase_InitializeGame_15442, loca.AdvBase_InitializeGame_15443, loca.AdvBase_InitializeGame_15444, loca.AdvBase_InitializeGame_15445, loca.AdvBase_InitializeGame_15446, loca.AdvBase_InitializeGame_15447));
            VerbTenses.Add(new VerbTenses(CB!.VT_dozieren, loca.AdvBase_InitializeGame_15448, loca.AdvBase_InitializeGame_15449, loca.AdvBase_InitializeGame_15450, loca.AdvBase_InitializeGame_15451, loca.AdvBase_InitializeGame_15452, loca.AdvBase_InitializeGame_15453, loca.AdvBase_InitializeGame_15454, loca.AdvBase_InitializeGame_15455, loca.AdvBase_InitializeGame_15456, loca.AdvBase_InitializeGame_15457, loca.AdvBase_InitializeGame_15458, loca.AdvBase_InitializeGame_15459, loca.AdvBase_InitializeGame_15460));
            VerbTenses.Add(new VerbTenses(CB!.VT_drohen, loca.AdvBase_InitializeGame_15461, loca.AdvBase_InitializeGame_15462, loca.AdvBase_InitializeGame_15463, loca.AdvBase_InitializeGame_15464, loca.AdvBase_InitializeGame_15465, loca.AdvBase_InitializeGame_15466, loca.AdvBase_InitializeGame_15467, loca.AdvBase_InitializeGame_15468, loca.AdvBase_InitializeGame_15469, loca.AdvBase_InitializeGame_15470, loca.AdvBase_InitializeGame_15471, loca.AdvBase_InitializeGame_15472, loca.AdvBase_InitializeGame_15473));
            VerbTenses.Add(new VerbTenses(CB!.VT_frohlocken, loca.AdvBase_InitializeGame_15474, loca.AdvBase_InitializeGame_15475, loca.AdvBase_InitializeGame_15476, loca.AdvBase_InitializeGame_15477, loca.AdvBase_InitializeGame_15478, loca.AdvBase_InitializeGame_15479, loca.AdvBase_InitializeGame_15480, loca.AdvBase_InitializeGame_15481, loca.AdvBase_InitializeGame_15482, loca.AdvBase_InitializeGame_15483, loca.AdvBase_InitializeGame_15484, loca.AdvBase_InitializeGame_15485, loca.AdvBase_InitializeGame_15486));
            VerbTenses.Add(new VerbTenses(CB!.VT_grummeln, loca.AdvBase_InitializeGame_15487, loca.AdvBase_InitializeGame_15488, loca.AdvBase_InitializeGame_15489, loca.AdvBase_InitializeGame_15490, loca.AdvBase_InitializeGame_15491, loca.AdvBase_InitializeGame_15492, loca.AdvBase_InitializeGame_15493, loca.AdvBase_InitializeGame_15494, loca.AdvBase_InitializeGame_15495, loca.AdvBase_InitializeGame_15496, loca.AdvBase_InitializeGame_15497, loca.AdvBase_InitializeGame_15498, loca.AdvBase_InitializeGame_15499));
            VerbTenses.Add(new VerbTenses(CB!.VT_maulen, loca.AdvBase_InitializeGame_15500, loca.AdvBase_InitializeGame_15501, loca.AdvBase_InitializeGame_15502, loca.AdvBase_InitializeGame_15503, loca.AdvBase_InitializeGame_15504, loca.AdvBase_InitializeGame_15505, loca.AdvBase_InitializeGame_15506, loca.AdvBase_InitializeGame_15507, loca.AdvBase_InitializeGame_15508, loca.AdvBase_InitializeGame_15509, loca.AdvBase_InitializeGame_15510, loca.AdvBase_InitializeGame_15511, loca.AdvBase_InitializeGame_15512));
            VerbTenses.Add(new VerbTenses(CB!.VT_prahlen, loca.AdvBase_InitializeGame_15513, loca.AdvBase_InitializeGame_15514, loca.AdvBase_InitializeGame_15515, loca.AdvBase_InitializeGame_15516, loca.AdvBase_InitializeGame_15517, loca.AdvBase_InitializeGame_15518, loca.AdvBase_InitializeGame_15519, loca.AdvBase_InitializeGame_15520, loca.AdvBase_InitializeGame_15521, loca.AdvBase_InitializeGame_15522, loca.AdvBase_InitializeGame_15523, loca.AdvBase_InitializeGame_15524, loca.AdvBase_InitializeGame_15525));
            VerbTenses.Add(new VerbTenses(CB!.VT_seufzen, loca.AdvBase_InitializeGame_15526, loca.AdvBase_InitializeGame_15527, loca.AdvBase_InitializeGame_15528, loca.AdvBase_InitializeGame_15529, loca.AdvBase_InitializeGame_15530, loca.AdvBase_InitializeGame_15531, loca.AdvBase_InitializeGame_15532, loca.AdvBase_InitializeGame_15533, loca.AdvBase_InitializeGame_15534, loca.AdvBase_InitializeGame_15535, loca.AdvBase_InitializeGame_15536, loca.AdvBase_InitializeGame_15537, loca.AdvBase_InitializeGame_15538));
            VerbTenses.Add(new VerbTenses(CB!.VT_stoehnen, loca.AdvBase_InitializeGame_15539, loca.AdvBase_InitializeGame_15540, loca.AdvBase_InitializeGame_15541, loca.AdvBase_InitializeGame_15542, loca.AdvBase_InitializeGame_15543, loca.AdvBase_InitializeGame_15544, loca.AdvBase_InitializeGame_15545, loca.AdvBase_InitializeGame_15546, loca.AdvBase_InitializeGame_15547, loca.AdvBase_InitializeGame_15548, loca.AdvBase_InitializeGame_15549, loca.AdvBase_InitializeGame_15550, loca.AdvBase_InitializeGame_15551));
            VerbTenses.Add(new VerbTenses(CB!.VT_berichten, loca.AdvBase_InitializeGame_15552, loca.AdvBase_InitializeGame_15553, loca.AdvBase_InitializeGame_15554, loca.AdvBase_InitializeGame_15555, loca.AdvBase_InitializeGame_15556, loca.AdvBase_InitializeGame_15557, loca.AdvBase_InitializeGame_15558, loca.AdvBase_InitializeGame_15559, loca.AdvBase_InitializeGame_15560, loca.AdvBase_InitializeGame_15561, loca.AdvBase_InitializeGame_15562, loca.AdvBase_InitializeGame_15563, loca.AdvBase_InitializeGame_15564));
            VerbTenses.Add(new VerbTenses(CB!.VT_aechzen, loca.AdvBase_InitializeGame_15565, loca.AdvBase_InitializeGame_15566, loca.AdvBase_InitializeGame_15567, loca.AdvBase_InitializeGame_15568, loca.AdvBase_InitializeGame_15569, loca.AdvBase_InitializeGame_15570, loca.AdvBase_InitializeGame_15571, loca.AdvBase_InitializeGame_15572, loca.AdvBase_InitializeGame_15573, loca.AdvBase_InitializeGame_15574, loca.AdvBase_InitializeGame_15575, loca.AdvBase_InitializeGame_15576, loca.AdvBase_InitializeGame_15577));
            VerbTenses.Add(new VerbTenses(CB!.VT_betteln, loca.AdvBase_InitializeGame_15578, loca.AdvBase_InitializeGame_15579, loca.AdvBase_InitializeGame_15580, loca.AdvBase_InitializeGame_15581, loca.AdvBase_InitializeGame_15582, loca.AdvBase_InitializeGame_15583, loca.AdvBase_InitializeGame_15584, loca.AdvBase_InitializeGame_15585, loca.AdvBase_InitializeGame_15586, loca.AdvBase_InitializeGame_15587, loca.AdvBase_InitializeGame_15588, loca.AdvBase_InitializeGame_15589, loca.AdvBase_InitializeGame_15590));
            VerbTenses.Add(new VerbTenses(CB!.VT_schwadronieren, loca.AdvBase_InitializeGame_15591, loca.AdvBase_InitializeGame_15592, loca.AdvBase_InitializeGame_15593, loca.AdvBase_InitializeGame_15594, loca.AdvBase_InitializeGame_15595, loca.AdvBase_InitializeGame_15596, loca.AdvBase_InitializeGame_15597, loca.AdvBase_InitializeGame_15598, loca.AdvBase_InitializeGame_15599, loca.AdvBase_InitializeGame_15600, loca.AdvBase_InitializeGame_15601, loca.AdvBase_InitializeGame_15602, loca.AdvBase_InitializeGame_15603));
            VerbTenses.Add(new VerbTenses(CB!.VT_antworten, loca.AdvBase_InitializeGame_15604, loca.AdvBase_InitializeGame_15605, loca.AdvBase_InitializeGame_15606, loca.AdvBase_InitializeGame_15607, loca.AdvBase_InitializeGame_15608, loca.AdvBase_InitializeGame_15609, loca.AdvBase_InitializeGame_15610, loca.AdvBase_InitializeGame_15611, loca.AdvBase_InitializeGame_15612, loca.AdvBase_InitializeGame_15613, loca.AdvBase_InitializeGame_15614, loca.AdvBase_InitializeGame_15615, loca.AdvBase_InitializeGame_15616));
            VerbTenses.Add(new VerbTenses(CB!.VT_murmeln, loca.AdvBase_InitializeGame_15617, loca.AdvBase_InitializeGame_15618, loca.AdvBase_InitializeGame_15619, loca.AdvBase_InitializeGame_15620, loca.AdvBase_InitializeGame_15621, loca.AdvBase_InitializeGame_15622, loca.AdvBase_InitializeGame_15623, loca.AdvBase_InitializeGame_15624, loca.AdvBase_InitializeGame_15625, loca.AdvBase_InitializeGame_15626, loca.AdvBase_InitializeGame_15627, loca.AdvBase_InitializeGame_15628, loca.AdvBase_InitializeGame_15629));
            VerbTenses.Add(new VerbTenses(CB!.VT_beschwoeren, loca.AdvBase_InitializeGame_15630, loca.AdvBase_InitializeGame_15631, loca.AdvBase_InitializeGame_15632, loca.AdvBase_InitializeGame_15633, loca.AdvBase_InitializeGame_15634, loca.AdvBase_InitializeGame_15635, loca.AdvBase_InitializeGame_15636, loca.AdvBase_InitializeGame_15637, loca.AdvBase_InitializeGame_15638, loca.AdvBase_InitializeGame_15639, loca.AdvBase_InitializeGame_15640, loca.AdvBase_InitializeGame_15641, loca.AdvBase_InitializeGame_15642));
            VerbTenses.Add(new VerbTenses(CB!.VT_rufen, loca.AdvBase_InitializeGame_15643, loca.AdvBase_InitializeGame_15644, loca.AdvBase_InitializeGame_15645, loca.AdvBase_InitializeGame_15646, loca.AdvBase_InitializeGame_15647, loca.AdvBase_InitializeGame_15648, loca.AdvBase_InitializeGame_15649, loca.AdvBase_InitializeGame_15650, loca.AdvBase_InitializeGame_15651, loca.AdvBase_InitializeGame_15652, loca.AdvBase_InitializeGame_15653, loca.AdvBase_InitializeGame_15654, loca.AdvBase_InitializeGame_15655));
            VerbTenses.Add(new VerbTenses(CB!.VT_draengeln, loca.AdvBase_InitializeGame_15656, loca.AdvBase_InitializeGame_15657, loca.AdvBase_InitializeGame_15658, loca.AdvBase_InitializeGame_15659, loca.AdvBase_InitializeGame_15660, loca.AdvBase_InitializeGame_15661, loca.AdvBase_InitializeGame_15662, loca.AdvBase_InitializeGame_15663, loca.AdvBase_InitializeGame_15664, loca.AdvBase_InitializeGame_15665, loca.AdvBase_InitializeGame_15666, loca.AdvBase_InitializeGame_15667, loca.AdvBase_InitializeGame_15668));
            VerbTenses.Add(new VerbTenses(CB!.VT_beschwichtigen, loca.AdvBase_InitializeGame_15669, loca.AdvBase_InitializeGame_15670, loca.AdvBase_InitializeGame_15671, loca.AdvBase_InitializeGame_15672, loca.AdvBase_InitializeGame_15673, loca.AdvBase_InitializeGame_15674, loca.AdvBase_InitializeGame_15675, loca.AdvBase_InitializeGame_15676, loca.AdvBase_InitializeGame_15677, loca.AdvBase_InitializeGame_15678, loca.AdvBase_InitializeGame_15679, loca.AdvBase_InitializeGame_15680, loca.AdvBase_InitializeGame_15681));
            VerbTenses.Add(new VerbTenses(CB!.VT_stottern, loca.AdvBase_InitializeGame_15682, loca.AdvBase_InitializeGame_15683, loca.AdvBase_InitializeGame_15684, loca.AdvBase_InitializeGame_15685, loca.AdvBase_InitializeGame_15686, loca.AdvBase_InitializeGame_15687, loca.AdvBase_InitializeGame_15688, loca.AdvBase_InitializeGame_15689, loca.AdvBase_InitializeGame_15690, loca.AdvBase_InitializeGame_15691, loca.AdvBase_InitializeGame_15692, loca.AdvBase_InitializeGame_15693, loca.AdvBase_InitializeGame_15694));
            VerbTenses.Add(new VerbTenses(CB!.VT_draengen, loca.AdvBase_InitializeGame_15695, loca.AdvBase_InitializeGame_15696, loca.AdvBase_InitializeGame_15697, loca.AdvBase_InitializeGame_15698, loca.AdvBase_InitializeGame_15699, loca.AdvBase_InitializeGame_15700, loca.AdvBase_InitializeGame_15701, loca.AdvBase_InitializeGame_15702, loca.AdvBase_InitializeGame_15703, loca.AdvBase_InitializeGame_15704, loca.AdvBase_InitializeGame_15705, loca.AdvBase_InitializeGame_15706, loca.AdvBase_InitializeGame_15707));
            VerbTenses.Add(new VerbTenses(CB!.VT_gruebeln, loca.AdvBase_InitializeGame_15708, loca.AdvBase_InitializeGame_15709, loca.AdvBase_InitializeGame_15710, loca.AdvBase_InitializeGame_15711, loca.AdvBase_InitializeGame_15712, loca.AdvBase_InitializeGame_15713, loca.AdvBase_InitializeGame_15714, loca.AdvBase_InitializeGame_15715, loca.AdvBase_InitializeGame_15716, loca.AdvBase_InitializeGame_15717, loca.AdvBase_InitializeGame_15718, loca.AdvBase_InitializeGame_15719, loca.AdvBase_InitializeGame_15720));
            VerbTenses.Add(new VerbTenses(CB!.VT_johlen, loca.AdvBase_InitializeGame_15721, loca.AdvBase_InitializeGame_15722, loca.AdvBase_InitializeGame_15723, loca.AdvBase_InitializeGame_15724, loca.AdvBase_InitializeGame_15725, loca.AdvBase_InitializeGame_15726, loca.AdvBase_InitializeGame_15727, loca.AdvBase_InitializeGame_15728, loca.AdvBase_InitializeGame_15729, loca.AdvBase_InitializeGame_15730, loca.AdvBase_InitializeGame_15731, loca.AdvBase_InitializeGame_15732, loca.AdvBase_InitializeGame_15733));
            VerbTenses.Add(new VerbTenses(CB!.VT_lallen, loca.AdvBase_InitializeGame_15734, loca.AdvBase_InitializeGame_15735, loca.AdvBase_InitializeGame_15736, loca.AdvBase_InitializeGame_15737, loca.AdvBase_InitializeGame_15738, loca.AdvBase_InitializeGame_15739, loca.AdvBase_InitializeGame_15740, loca.AdvBase_InitializeGame_15741, loca.AdvBase_InitializeGame_15742, loca.AdvBase_InitializeGame_15743, loca.AdvBase_InitializeGame_15744, loca.AdvBase_InitializeGame_15745, loca.AdvBase_InitializeGame_15746));
            VerbTenses.Add(new VerbTenses(CB!.VT_nothing, loca.AdvBase_InitializeGame_15747, loca.AdvBase_InitializeGame_15748, loca.AdvBase_InitializeGame_15749, loca.AdvBase_InitializeGame_15750, loca.AdvBase_InitializeGame_15751, loca.AdvBase_InitializeGame_15752, loca.AdvBase_InitializeGame_15753, loca.AdvBase_InitializeGame_15754, loca.AdvBase_InitializeGame_15755, loca.AdvBase_InitializeGame_15756, loca.AdvBase_InitializeGame_15757, loca.AdvBase_InitializeGame_15758, loca.AdvBase_InitializeGame_15759));
            VerbTenses.Add(new VerbTenses(CB!.VT_raunen, loca.AdvBase_InitializeGame_15760, loca.AdvBase_InitializeGame_15761, loca.AdvBase_InitializeGame_15762, loca.AdvBase_InitializeGame_15763, loca.AdvBase_InitializeGame_15764, loca.AdvBase_InitializeGame_15765, loca.AdvBase_InitializeGame_15766, loca.AdvBase_InitializeGame_15767, loca.AdvBase_InitializeGame_15768, loca.AdvBase_InitializeGame_15769, loca.AdvBase_InitializeGame_15770, loca.AdvBase_InitializeGame_15771, loca.AdvBase_InitializeGame_15772));
            VerbTenses.Add(new VerbTenses(CB!.VT_schaeumen, loca.AdvBase_InitializeGame_15773, loca.AdvBase_InitializeGame_15774, loca.AdvBase_InitializeGame_15775, loca.AdvBase_InitializeGame_15776, loca.AdvBase_InitializeGame_15777, loca.AdvBase_InitializeGame_15778, loca.AdvBase_InitializeGame_15779, loca.AdvBase_InitializeGame_15780, loca.AdvBase_InitializeGame_15781, loca.AdvBase_InitializeGame_15782, loca.AdvBase_InitializeGame_15783, loca.AdvBase_InitializeGame_15784, loca.AdvBase_InitializeGame_15785));
            VerbTenses.Add(new VerbTenses(CB!.VT_schnauben, loca.AdvBase_InitializeGame_15786, loca.AdvBase_InitializeGame_15787, loca.AdvBase_InitializeGame_15788, loca.AdvBase_InitializeGame_15789, loca.AdvBase_InitializeGame_15790, loca.AdvBase_InitializeGame_15791, loca.AdvBase_InitializeGame_15792, loca.AdvBase_InitializeGame_15793, loca.AdvBase_InitializeGame_15794, loca.AdvBase_InitializeGame_15795, loca.AdvBase_InitializeGame_15796, loca.AdvBase_InitializeGame_15797, loca.AdvBase_InitializeGame_15798));
            VerbTenses.Add(new VerbTenses(CB!.VT_sinnieren, loca.AdvBase_InitializeGame_15799, loca.AdvBase_InitializeGame_15800, loca.AdvBase_InitializeGame_15801, loca.AdvBase_InitializeGame_15802, loca.AdvBase_InitializeGame_15803, loca.AdvBase_InitializeGame_15804, loca.AdvBase_InitializeGame_15805, loca.AdvBase_InitializeGame_15806, loca.AdvBase_InitializeGame_15807, loca.AdvBase_InitializeGame_15808, loca.AdvBase_InitializeGame_15809, loca.AdvBase_InitializeGame_15810, loca.AdvBase_InitializeGame_15811));
            VerbTenses.Add(new VerbTenses(CB!.VT_behaupten, loca.AdvBase_InitializeGame_15812, loca.AdvBase_InitializeGame_15813, loca.AdvBase_InitializeGame_15814, loca.AdvBase_InitializeGame_15815, loca.AdvBase_InitializeGame_15816, loca.AdvBase_InitializeGame_15817, loca.AdvBase_InitializeGame_15818, loca.AdvBase_InitializeGame_15819, loca.AdvBase_InitializeGame_15820, loca.AdvBase_InitializeGame_15821, loca.AdvBase_InitializeGame_15822, loca.AdvBase_InitializeGame_15823, loca.AdvBase_InitializeGame_15824));
            VerbTenses.Add(new VerbTenses(CB!.VT_erzaehlen, loca.AdvBase_InitializeGame_15825, loca.AdvBase_InitializeGame_15826, loca.AdvBase_InitializeGame_15827, loca.AdvBase_InitializeGame_15828, loca.AdvBase_InitializeGame_15829, loca.AdvBase_InitializeGame_15830, loca.AdvBase_InitializeGame_15831, loca.AdvBase_InitializeGame_15832, loca.AdvBase_InitializeGame_15833, loca.AdvBase_InitializeGame_15834, loca.AdvBase_InitializeGame_15835, loca.AdvBase_InitializeGame_15836, loca.AdvBase_InitializeGame_15837));
            VerbTenses.Add(new VerbTenses(CB!.VT_staunen, loca.AdvBase_InitializeGame_15838, loca.AdvBase_InitializeGame_15839, loca.AdvBase_InitializeGame_15840, loca.AdvBase_InitializeGame_15841, loca.AdvBase_InitializeGame_15842, loca.AdvBase_InitializeGame_15843, loca.AdvBase_InitializeGame_15844, loca.AdvBase_InitializeGame_15845, loca.AdvBase_InitializeGame_15846, loca.AdvBase_InitializeGame_15847, loca.AdvBase_InitializeGame_15848, loca.AdvBase_InitializeGame_15849, loca.AdvBase_InitializeGame_15850));
            VerbTenses.Add(new VerbTenses(CB!.VT_jammern, loca.AdvBase_InitializeGame_15851, loca.AdvBase_InitializeGame_15852, loca.AdvBase_InitializeGame_15853, loca.AdvBase_InitializeGame_15854, loca.AdvBase_InitializeGame_15855, loca.AdvBase_InitializeGame_15856, loca.AdvBase_InitializeGame_15857, loca.AdvBase_InitializeGame_15858, loca.AdvBase_InitializeGame_15859, loca.AdvBase_InitializeGame_15860, loca.AdvBase_InitializeGame_15861, loca.AdvBase_InitializeGame_15862, loca.AdvBase_InitializeGame_15863));

            VerbTenses.Add(new VerbTenses(CB!.VT_keifen, loca.AdvBase_InitializeGame_15864, loca.AdvBase_InitializeGame_15865, loca.AdvBase_InitializeGame_15866, loca.AdvBase_InitializeGame_15867, loca.AdvBase_InitializeGame_15868, loca.AdvBase_InitializeGame_15869, loca.AdvBase_InitializeGame_15870, loca.AdvBase_InitializeGame_15871, loca.AdvBase_InitializeGame_15872, loca.AdvBase_InitializeGame_15873, loca.AdvBase_InitializeGame_15874, loca.AdvBase_InitializeGame_15875, loca.AdvBase_InitializeGame_15876));
            VerbTenses.Add(new VerbTenses(CB!.VT_schwaermen, loca.AdvBase_InitializeGame_15877, loca.AdvBase_InitializeGame_15878, loca.AdvBase_InitializeGame_15879, loca.AdvBase_InitializeGame_15880, loca.AdvBase_InitializeGame_15881, loca.AdvBase_InitializeGame_15882, loca.AdvBase_InitializeGame_15883, loca.AdvBase_InitializeGame_15884, loca.AdvBase_InitializeGame_15885, loca.AdvBase_InitializeGame_15886, loca.AdvBase_InitializeGame_15887, loca.AdvBase_InitializeGame_15888, loca.AdvBase_InitializeGame_15889));
            VerbTenses.Add(new VerbTenses(CB!.VT_verkuenden, loca.AdvBase_InitializeGame_15890, loca.AdvBase_InitializeGame_15891, loca.AdvBase_InitializeGame_15892, loca.AdvBase_InitializeGame_15893, loca.AdvBase_InitializeGame_15894, loca.AdvBase_InitializeGame_15895, loca.AdvBase_InitializeGame_15896, loca.AdvBase_InitializeGame_15897, loca.AdvBase_InitializeGame_15898, loca.AdvBase_InitializeGame_15899, loca.AdvBase_InitializeGame_15900, loca.AdvBase_InitializeGame_15901, loca.AdvBase_InitializeGame_15902));

            VerbTenses.Add(new VerbTenses(CB!.VT_schnaufen, loca.AdvBase_InitializeGame_15903, loca.AdvBase_InitializeGame_15904, loca.AdvBase_InitializeGame_15905, loca.AdvBase_InitializeGame_15906, loca.AdvBase_InitializeGame_15907, loca.AdvBase_InitializeGame_15908, loca.AdvBase_InitializeGame_15909, loca.AdvBase_InitializeGame_15910, loca.AdvBase_InitializeGame_15911, loca.AdvBase_InitializeGame_15912, loca.AdvBase_InitializeGame_15913, loca.AdvBase_InitializeGame_15914, loca.AdvBase_InitializeGame_15915));
            VerbTenses.Add(new VerbTenses(CB!.VT_gaehnen, loca.AdvBase_InitializeGame_15916, loca.AdvBase_InitializeGame_15917, loca.AdvBase_InitializeGame_15918, loca.AdvBase_InitializeGame_15919, loca.AdvBase_InitializeGame_15920, loca.AdvBase_InitializeGame_15921, loca.AdvBase_InitializeGame_15922, loca.AdvBase_InitializeGame_15923, loca.AdvBase_InitializeGame_15924, loca.AdvBase_InitializeGame_15925, loca.AdvBase_InitializeGame_15926, loca.AdvBase_InitializeGame_15927, loca.AdvBase_InitializeGame_15928));

            VerbTenses.Add(new VerbTenses(CB!.VT_freuen, loca.AdvBase_InitializeGame_15929, loca.AdvBase_InitializeGame_15930, loca.AdvBase_InitializeGame_15931, loca.AdvBase_InitializeGame_15932, loca.AdvBase_InitializeGame_15933, loca.AdvBase_InitializeGame_15934, loca.AdvBase_InitializeGame_15935, loca.AdvBase_InitializeGame_15936, loca.AdvBase_InitializeGame_15937, loca.AdvBase_InitializeGame_15938, loca.AdvBase_InitializeGame_15939, loca.AdvBase_InitializeGame_15940, loca.AdvBase_InitializeGame_15941));
            VerbTenses.Add(new VerbTenses(CB!.VT_loben, loca.AdvBase_InitializeGame_15942, loca.AdvBase_InitializeGame_15943, loca.AdvBase_InitializeGame_15944, loca.AdvBase_InitializeGame_15945, loca.AdvBase_InitializeGame_15946, loca.AdvBase_InitializeGame_15947, loca.AdvBase_InitializeGame_15948, loca.AdvBase_InitializeGame_15949, loca.AdvBase_InitializeGame_15950, loca.AdvBase_InitializeGame_15951, loca.AdvBase_InitializeGame_15952, loca.AdvBase_InitializeGame_15953, loca.AdvBase_InitializeGame_15954));

            VerbTenses.Add(new VerbTenses(CB!.VT_heulen, loca.AdvBase_InitializeGame_15955, loca.AdvBase_InitializeGame_15956, loca.AdvBase_InitializeGame_15957, loca.AdvBase_InitializeGame_15958, loca.AdvBase_InitializeGame_15959, loca.AdvBase_InitializeGame_15960, loca.AdvBase_InitializeGame_15961, loca.AdvBase_InitializeGame_15962, loca.AdvBase_InitializeGame_15963, loca.AdvBase_InitializeGame_15964, loca.AdvBase_InitializeGame_15965, loca.AdvBase_InitializeGame_15966, loca.AdvBase_InitializeGame_15967));
            VerbTenses.Add(new VerbTenses(CB!.VT_raeuspern, loca.AdvBase_InitializeGame_15968, loca.AdvBase_InitializeGame_15969, loca.AdvBase_InitializeGame_15970, loca.AdvBase_InitializeGame_15971, loca.AdvBase_InitializeGame_15972, loca.AdvBase_InitializeGame_15973, loca.AdvBase_InitializeGame_15974, loca.AdvBase_InitializeGame_15975, loca.AdvBase_InitializeGame_15976, loca.AdvBase_InitializeGame_15977, loca.AdvBase_InitializeGame_15978, loca.AdvBase_InitializeGame_15979, loca.AdvBase_InitializeGame_15980));

            VerbTenses.Add(new VerbTenses(CB!.VT_roecheln, loca.AdvBase_InitializeGame_15981, loca.AdvBase_InitializeGame_15982, loca.AdvBase_InitializeGame_15983, loca.AdvBase_InitializeGame_15984, loca.AdvBase_InitializeGame_15985, loca.AdvBase_InitializeGame_15986, loca.AdvBase_InitializeGame_15987, loca.AdvBase_InitializeGame_15988, loca.AdvBase_InitializeGame_15989, loca.AdvBase_InitializeGame_15990, loca.AdvBase_InitializeGame_15991, loca.AdvBase_InitializeGame_15992, loca.AdvBase_InitializeGame_15993));
            VerbTenses.Add(new VerbTenses(CB!.VT_schlucken, loca.AdvBase_InitializeGame_15994, loca.AdvBase_InitializeGame_15995, loca.AdvBase_InitializeGame_15996, loca.AdvBase_InitializeGame_15997, loca.AdvBase_InitializeGame_15998, loca.AdvBase_InitializeGame_15999, loca.AdvBase_InitializeGame_16000, loca.AdvBase_InitializeGame_16001, loca.AdvBase_InitializeGame_16002, loca.AdvBase_InitializeGame_16003, loca.AdvBase_InitializeGame_16004, loca.AdvBase_InitializeGame_16005, loca.AdvBase_InitializeGame_16006));
            VerbTenses.Add(new VerbTenses(CB!.VT_winseln, loca.AdvBase_InitializeGame_16007, loca.AdvBase_InitializeGame_16008, loca.AdvBase_InitializeGame_16009, loca.AdvBase_InitializeGame_16010, loca.AdvBase_InitializeGame_16011, loca.AdvBase_InitializeGame_16012, loca.AdvBase_InitializeGame_16013, loca.AdvBase_InitializeGame_16014, loca.AdvBase_InitializeGame_16015, loca.AdvBase_InitializeGame_16016, loca.AdvBase_InitializeGame_16017, loca.AdvBase_InitializeGame_16018, loca.AdvBase_InitializeGame_16019));
            VerbTenses.Add(new VerbTenses(CB!.VT_betrachten, loca.AdvBase_InitializeGame_16020, loca.AdvBase_InitializeGame_16021, loca.AdvBase_InitializeGame_16022, loca.AdvBase_InitializeGame_16023, loca.AdvBase_InitializeGame_16024, loca.AdvBase_InitializeGame_16025, loca.AdvBase_InitializeGame_16026, loca.AdvBase_InitializeGame_16027, loca.AdvBase_InitializeGame_16028, loca.AdvBase_InitializeGame_16029, loca.AdvBase_InitializeGame_16030, loca.AdvBase_InitializeGame_16031, loca.AdvBase_InitializeGame_16032));
            VerbTenses.Add(new VerbTenses(CB!.VT_knurren, loca.AdvBase_InitializeGame_16033, loca.AdvBase_InitializeGame_16034, loca.AdvBase_InitializeGame_16035, loca.AdvBase_InitializeGame_16036, loca.AdvBase_InitializeGame_16037, loca.AdvBase_InitializeGame_16038, loca.AdvBase_InitializeGame_16039, loca.AdvBase_InitializeGame_16040, loca.AdvBase_InitializeGame_16041, loca.AdvBase_InitializeGame_16042, loca.AdvBase_InitializeGame_16043, loca.AdvBase_InitializeGame_16044, loca.AdvBase_InitializeGame_16045));
            VerbTenses.Add(new VerbTenses(CB!.VT_verlassen, loca.AdvBase_InitializeGame_16046, loca.AdvBase_InitializeGame_16047, loca.AdvBase_InitializeGame_16048, loca.AdvBase_InitializeGame_16049, loca.AdvBase_InitializeGame_16050, loca.AdvBase_InitializeGame_16051, loca.AdvBase_InitializeGame_16052, loca.AdvBase_InitializeGame_16053, loca.AdvBase_InitializeGame_16054, loca.AdvBase_InitializeGame_16055, loca.AdvBase_InitializeGame_16056, loca.AdvBase_InitializeGame_16057, loca.AdvBase_InitializeGame_16058));
            VerbTenses.Add(new VerbTenses(CB!.VT_fahren, loca.AdvBase_InitializeGame_16059, loca.AdvBase_InitializeGame_16060, loca.AdvBase_InitializeGame_16061, loca.AdvBase_InitializeGame_16062, loca.AdvBase_InitializeGame_16063, loca.AdvBase_InitializeGame_16064, loca.AdvBase_InitializeGame_16065, loca.AdvBase_InitializeGame_16066, loca.AdvBase_InitializeGame_16067, loca.AdvBase_InitializeGame_16068, loca.AdvBase_InitializeGame_16069, loca.AdvBase_InitializeGame_16070, loca.AdvBase_InitializeGame_16071));
            VerbTenses.Add(new VerbTenses(CB!.VT_summen, loca.AdvBase_InitializeGame_16072, loca.AdvBase_InitializeGame_16073, loca.AdvBase_InitializeGame_16074, loca.AdvBase_InitializeGame_16075, loca.AdvBase_InitializeGame_16076, loca.AdvBase_InitializeGame_16077, loca.AdvBase_InitializeGame_16078, loca.AdvBase_InitializeGame_16079, loca.AdvBase_InitializeGame_16080, loca.AdvBase_InitializeGame_16081, loca.AdvBase_InitializeGame_16082, loca.AdvBase_InitializeGame_16083, loca.AdvBase_InitializeGame_16084));
            */

            // A!.ActLoc = A.StartLoc;

        }
        /*
        public void AddScore(int Score)
        {
            string s = "leicht";

            if (A.Difficulty == A.Difficulty_Medium) s = "mittel";
            else if (A.Difficulty == A.Difficulty_Heavy) s = "schwer";

            A!.ActScore += Score;
        // Ignores: 006
            MW.ScoreOutput( "Score: "+A!.ActScore+"/"+A.MaxScore+" ( " +s + ")");

            if( Score > 0 )
        // Ignores: 004
                StoryOutput(A!.ActLoc, Persons!.Find( A!.ActPerson ), "*** Der Score erhöht sich um " +Score + " auf " +A!.ActScore + " ***");
        }
        */

        public bool GetScoreToken(Score score)
        {
            return (score.Active);
        }

        public void SetScoreToken(Score? score)
        {
            if (score!.Active == false)
            {
                score!.Active = true;
                int actScore = Scores!.TotalScore();
                int addScore = score!.InqScore();
                string s = "";


                SetScoreOutput();

                /*
                if (score.SpoilerState == spoiler.tipp)
                    s = "(75%)";
                else if (score.SpoilerState == spoiler.spoiler)
                    s = "(50%)";
                if (score.SpoilerState == spoiler.solution)
                    s = "(25%)";
                */

                if (addScore > 0)
                {
                    if (score.Comment != null)
                        StoryOutput(score.Comment);

                    StoryOutput(loca.AdvBase_SetScoreToken_16085 + addScore + s + loca.AdvBase_SetScoreToken_16086 + (actScore) + loca.AdvBase_SetScoreToken_16087);
                }
            }
        }

        
        public void SetScoreOutput()
        {
            double cscore = 0;
            double ctotalscore = 0;

            double score = 0;
            double totalscore = 0;

            if (AdvGame == null) return;

            foreach (Score sc in Scores!.Scores!)
            {

                if (sc.Chapter != scoreChapter.no_chapter)
                {
                    totalscore += sc.Val;

                    if (sc.Active)
                        score += sc.Val;
                }

            }

            int val = 0;
            UIS!.SetScore(cscore, ctotalscore, score, totalscore, val);

            /* delegiert an UIS

            AdvGame.MW.PB1.Value = (double)((cscore * 100) / ctotalscore);
            AdvGame.MW.PB2.Value = (double)((score * 100) / totalscore);
            AdvGame.MW.PB1.ToolTip = string.Format(loca.AdvBase_SetScoreOutput_16088, AdvGame.CA!.Status_Episode.Val, (double)((cscore * 100) / ctotalscore));
            AdvGame.MW.PB2.ToolTip = string.Format(loca.AdvBase_SetScoreOutput_16089, (double)((score * 100) / totalscore));
            */

            // string s = string.Format(loca.AdvBase_SetScoreOutput_16090, AdvGame.CA!.Status_Episode.Val);
            // AdvGame.UIS!.SetScoreEpisode(s);
            // ( AdvGame.UIS.ScoreEpisode as TextBlock).Text = s;
            // MW.ScoreOutput(s);
            // Ignores: 003
            // MW.ScoreOutput( "Score: " + Scores.TotalScore() + "/" + Scores.MaximumScore() );

        }

        public void Close()
        {
            UIS!.Close();
        }

        int SearchVT(string s)
        {
            s = loca.AdvBase_Close_16091 + s;
            System.Reflection.PropertyInfo? pi = typeof(CoBase).GetProperty(s, BindingFlags.Public | BindingFlags.Instance);

            object o = pi!.GetValue(CB!, null)!;

            return (int)o;
        }


        public int SearchItemID(string s)
        {
            // s = "VT_" + s;
            System.Reflection.PropertyInfo? pi = typeof(CoAdv).GetProperty(s, BindingFlags.Public | BindingFlags.Instance);

            object o = pi!.GetValue(AdvGame!.CA!, null!)!;

            return (o as Item)!.ID!;

        }

        public int SearchlocationID(string s)
        {
            // s = "VT_" + s;
            System.Reflection.PropertyInfo? pi = typeof(CoAdv).GetProperty(s, BindingFlags.Public | BindingFlags.Instance);

            object o = pi!.GetValue(AdvGame!.CA!, null!)!;

            return (int)o!;

        }

        public int SearchDir(string s)
        {
            Type type = typeof(Co);

            // s = "VT_" + s;
            System.Reflection.PropertyInfo? pi = type.GetProperty(s, BindingFlags.Public | BindingFlags.Instance);

            object? o = pi!.GetValue(null!, null);

            return (int)o!;

        }


        public string Insert(string s, params object[] obj)
        {
            string snew = "";
            int ix = 0;

            // Noloca: 044
            while (ix < s.Length)
            {
                int ix2 = ix;
                while (ix2 < s.Length && s[ix2] != '[')
                {
                    ix2++;
                }

                snew += s.Substring(ix, ix2 - ix);

                ix = ix2;

                if (ix2 < s.Length)
                {
                    if (s[ix] == '[')
                    {
                        int lenSeq = 0;
                        Item? i = null;
                        Item? it = null;
                        Person? p = null;
                        Person? pt = null;
                        Person? plt = null;
                        Person? plv = null;
                        string? pString = null;
                        int aocase = Co.CASE_AKK;
                        int verbID = -1;
                        int itemID = 0;
                        int locationID = 0;
                        int dirID = 0;

                        // Erst mal werden die location-Inserts eingefügt, die vollständig im String kodiert sind
                        if (s.Substring(ix, 4) == "[/I]")
                        {
                            ix += 4;
                        }
                        else if (s.Substring(ix, 4) == "[/L]")
                        {
                            ix += 4;
                        }
                        else if (s.Substring(ix, 3) == "[I:")
                        {
                            int pos = s.Substring(ix + 3).IndexOf(']');
                            if (pos != -1)
                            {
                                string pString3 = s.Substring(ix + 3, pos);
                                itemID = SearchItemID(pString3);
                                // Link
                                // sOut += itemID.ToString();

                                ix += 4 + pos;

                                int pos2 = s.Substring(ix).IndexOf('[');
                                if (pos2 != -1)
                                {
                                    string pString2 = s.Substring(ix, pos2);
                                    snew += "<Item:" + itemID.ToString("00000.##") + ">" + pString2 + "</Item>";
                                    ix += pos2;
                                }
                            }
                            else
                                ix += 1;
                        }
                        else if (s.Substring(ix, 3) == "[L:")
                        {
                            int pos = s.Substring(ix + 3).IndexOf(']');
                            if (pos != -1)
                            {
                                string pString3 = s.Substring(ix + 3, pos);
                                locationID = SearchlocationID(pString3);
                                // Link
                                // sOut += locationID.ToString();

                                ix += 4 + pos;

                                int pos2 = s.Substring(ix).IndexOf('[');
                                if (pos2 != -1)
                                {
                                    string pString2 = s.Substring(ix, pos2);
                                    // Ignores: 004
                                    snew += "<Loc:" + locationID.ToString("00000.##") + ">" + pString2 + "</Loc>";
                                    ix += pos2;
                                }
                            }
                            else
                                ix += 1;
                        }
                        else if (s.Substring(ix, 3) == "[D:")
                        {
                            int pos = s.Substring(ix + 3).IndexOf(']');
                            if (pos != -1)
                            {
                                string pString3 = s.Substring(ix + 3, pos);
                                dirID = SearchDir(pString3);
                                // Link
                                // sOut += locationID.ToString();

                                ix += 4 + pos;

                                int pos2 = s.Substring(ix).IndexOf('[');
                                if (pos2 != -1)
                                {
                                    string pString2 = s.Substring(ix, pos2);
                                    snew += "<Dir:" + locationID.ToString("00000.##") + ">" + pString2 + "</Dir>";
                                    ix += pos2;
                                }
                            }
                            else
                                ix += 1;
                        }
                        // ... und dann folgen die allgemeinen Inserts, die per Parameter nachgezogen werden
                        else if (s.Substring(ix, 5) == "[Il1,")
                        {
                            i = (Item)obj[0];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 5) == "[Il2,")
                        {
                            i = (Item)obj[1];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 5) == "[Il3,")
                        {
                            i = (Item)obj[2];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 5) == "[It1,")
                        {
                            it = (Item)obj[0];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 5) == "[It2,")
                        {
                            it = (Item)obj[1];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 5) == "[It3,")
                        {
                            it = (Item)obj[2];
                            lenSeq += 54;
                        }
                        else if (s.Substring(ix, 6) == "[Pl1,\"")
                        {
                            p = (Person)obj[0];
                            // Ignores: 001
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += (int) ( 6 + pString?.Length + 2 )!;
                        }
                        else if (s.Substring(ix, 6) == "[Pl2,\"")
                        {
                            p = (Person)obj[1];
                            // Ignores: 001
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += (int)( 6 + pString?.Length + 2 )!;
                        }
                        // Ignores: 001
                        else if (s.Substring(ix, 6) == "[Pl3,\"")
                        {
                            p = (Person)obj[2];
                            // Ignores: 001
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += (int)( 6 + pString?.Length + 2 )!;
                        }
                        // Ignores: 001
                        else if (s.Substring(ix, 5) == "[Pt1,")
                        {
                            pt = (Person)obj[0];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 5) == "[Pt2,")
                        {
                            pt = (Person)obj[1];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 5) == "[Pt3,")
                        {
                            pt = (Person)obj[2];
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix, 6) == "[Plt1,")
                        {
                            plt = (Person)obj[0];
                            lenSeq += 6;
                        }
                        else if (s.Substring(ix, 6) == "[Plt2,")
                        {
                            plt = (Person)obj[1];
                            lenSeq += 6;
                        }
                        else if (s.Substring(ix, 5) == "[Plt3,")
                        {
                            pt = (Person)obj[2];
                            lenSeq += 6;
                        }
                        else if (s.Substring(ix, 6) == "[Plv1,")
                        {
                            plv = (Person)obj[0];
                            int pos = s.Substring(ix + 6).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + 6, pos);
                                verbID = SearchVT(pString);
                                lenSeq += 6 + pString.Length + 1;

                            }
                        }
                        else if (s.Substring(ix, 6) == "[Plv2,")
                        {
                            plv = (Person)obj[1];
                            int pos = s.Substring(ix + 6).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + 6, pos);
                                verbID = SearchVT(pString);
                                lenSeq += 6 + pString.Length + 1;

                            }
                        }
                        else if (s.Substring(ix, 6) == "[Plv3,")
                        {
                            plv = (Person)obj[2];
                            int pos = s.Substring(ix + 6).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + 6, pos);
                                verbID = SearchVT(pString);
                                lenSeq += 6 + pString.Length + 1;
                            }
                        }

                        if (s.Substring(ix + lenSeq, 4) == "Akk]")
                        {

                            aocase = Co.CASE_AKK;
                            lenSeq += 4;
                        }
                        else if (s.Substring(ix + lenSeq, 4) == "Nom]")
                        {

                            aocase = Co.CASE_NOM;
                            lenSeq += 4;
                        }
                        else if (s.Substring(ix + lenSeq, 4) == "Dat]")
                        {

                            aocase = Co.CASE_DAT;
                            lenSeq += 4;
                        }
                        else if (s.Substring(ix + lenSeq, 5) == "Akku]")
                        {

                            aocase = Co.CASE_AKK_UNDEF;
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix + lenSeq, 5) == "Nomu]")
                        {

                            aocase = Co.CASE_NOM_UNDEF;
                            lenSeq += 5;
                        }
                        else if (s.Substring(ix + lenSeq, 5) == "Datu]")
                        {

                            aocase = Co.CASE_DAT_UNDEF;
                            lenSeq += 5;
                        }

                        if (i != null)
                        {
                            snew += Items!.GetItemNameLink(i.ID, aocase);
                        }
                        else if (it != null)
                        {
                            snew += Items!.GetName(it.ID, aocase);
                        }
                        else if (p != null)
                        {
                            snew += Persons!.GetPersonLink(p, pString);
                        }
                        else if (pt != null)
                        {
                            snew += Persons!.GetPersonName(pt, aocase);
                        }
                        else if (plt != null)
                        {
                            snew += Persons!.GetPersonNameLink(plt, aocase);
                        }
                        else if (plv != null)
                        {
                            snew += Persons!.GetPersonVerbLink(plv, aocase, verbID, A.Tense);
                        }

                        if (lenSeq == 0)
                            lenSeq = 1;
                        ix += lenSeq;
                    }

                }
            }

            return snew;
        }
    }
    
    [Serializable]

    public class SaveObj
    {
        public IGlobalData.language jsonLanguage { get; set; }
        public Phoney_MAUI.Core.Version? jsonVersion { get; set; }

        public locationList? jsonlocations { get; set; }

        public AdjList? jsonAdjs { get; set; }

        public AdvData? jsonA { get; set; }

        public NounList? jsonNouns { get; set; }

        public VerbList? jsonVerbs{ get; set; }

        public PrepList? jsonPreps { get; set; }

        public PronounList? jsonPronouns { get; set; }

        public ItemQueue? jsonItemQueue { get; set; }

        public FillList? jsonFills { get; set; }

        public ItemList? jsonItems { get; set; }

        public StatusList? jsonStats { get; set; }

        public ScoreList? jsonScores { get; set; }

        public List<LatestInput>? jsonLI { get; set; }

        public TopicList? jsonTopics { get; set; }

        public PersonList? jsonPersons { get; set; }

        public CoBase? jsonCB { get; set; }

        public CoAdv? jsonCA { get; set; }

        public Parse? jsonParser { get; set; }

        public Phoney_MAUI.Core.StoryText? jsonStoryText { get; set; }
        
        public Phoney_MAUI.Core.FeedbackText? jsonFeedbackText { get; set; }

        public VTList? jsonVerbTenses { get; set; }

        public PhoneyVision? jsonPV { get; set; }

        public OrderListTable? jsonOrderListTable{ get; set; }
        public GameDefinitions? JsonGameDefinitions{ get; set; }
    }
    [Serializable]

    public static class Co
    {

        public static int DIR_N = 1;

        public static int DIR_NE = 2;

        public static int DIR_E = 3;

        public static int DIR_SE = 4;

        public static int DIR_S = 5;

        public static int DIR_SW = 6;

        public static int DIR_W = 7;

        public static int DIR_NW = 8;

        public static int DIR_U = 9;

        public static int DIR_D = 10;


        public static int CODIR_N = 5;

        public static int CODIR_NE = 6;

        public static int CODIR_E = 7;

        public static int CODIR_SE = 8;

        public static int CODIR_S = 1;

        public static int CODIR_SW = 2;

        public static int CODIR_W = 3;

        public static int CODIR_NW = 4;

        public static int CODIR_U = 10;

        public static int CODIR_D = 9;


        public static int CASE_NOM = 1;

        public static int CASE_AKK = 2;

        public static int CASE_DAT = 3;

        public static int CASE_GEN = 4;

        public static int CASE_NOM_UNDEF = 5;

        public static int CASE_AKK_UNDEF = 6;

        public static int CASE_DAT_UNDEF = 7;

        public static int CASE_GEN_UNDEF = 8;

        // public const int UserdefIDOff = 1000;


        public static int Range_Here = 1;

        public static int Range_Active = 2;

        public static int Range_Overall = 3;

        public static int Range_Visible = 4;

        public static int Range_Known = 5;


        public static int SEX_MALE = 1;

        public static int SEX_FEMALE = 2;

        public static int SEX_NEUTER = 3;

        public static int SEX_MALE_PL = 4;

        public static int SEX_FEMALE_PL = 5;

        public static int SEX_NEUTER_PL = 6;


        public static int SZ_tiny = 1;

        public static int SZ_small = 3;

        public static int SZ_medium = 6;

        public static int SZ_big = 10;

        public static int SZ_gigantic = 20;

        [JsonIgnore]
        public static GlobalData? GD
        {
            get => GlobalData.CurrentGlobalData;
            // set => GlobalData.CurrentGlobalData = value;
        }


        //        public static Adv AdvGlobal;

        [JsonIgnore]
        public static CoBase? CB
        {
            get => GD!.Adventure!.CB;
            // set => GD!.Adventure.CB = value;
        }
        [JsonIgnore]
        public static CoAdv? CA
        {
            get => GD!.Adventure!.CA;
            // set => GD!.Adventure.CA = value;
        }
        // public static CoBase? CB; //  = new();

        // public static CoAdv? CA; //  = new();
  
        public static int GenerateLoc(int locationType,  int locationID )
        {
            return ((locationType * 65536) + locationID);
        }

        public static int GenerateLoc(Item? item )
        {
            return ((item!.locationType * 65536) + item!.locationID);
        }

        public static int GenerateLoc(Person? person)
        {
            return ((person!.locationType * 65536) + person!.locationID);
        }

        public static int GetPersLoc(int PersonID)
        {
            return ((CB!.LocType_Person * 65536) + PersonID);
        }

        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public static string PathFileName()
        {
            // Noloca: 003

            /*
            string? up = System.Environment.GetEnvironmentVariable( "USERPROFILE");
            string? pathName = up + "\\documents\\My Games\\Phoney Island Multi";         
            string? pathfileName = pathName + "\\" ;
            */

            string pathFileName = Phoney_MAUI.Core.GlobalData.CurrentPath() + "\\";

            return pathFileName!;
        }


        public static int CounterDir( int dir )
        {
            int[] cd = new int[]{ 0, 5, 6, 7, 8, 1, 2, 3, 4, 10, 9 };

            return cd[dir];
        }
    }

    [Serializable]

    public class CoBase
    {

        public Verb? Verb_German;
        public Verb? Verb_English;

        public Verb? Verb_N;
        public Verb? Verb_NE;

        public Verb? Verb_E;

        public Verb? Verb_SE;

        public Verb? Verb_S;

        public Verb? Verb_SW;

        public Verb? Verb_W;

        public Verb? Verb_NW;

        public Verb? Verb_U;

        public Verb? Verb_D;

        public Verb? Verb_Take;

        public Verb? Verb_Examine;

        public Verb? Verb_Inventory;

        public Verb? Verb_location;

        public Verb? Verb_Go;

        public Verb? Verb_Drop;

        public Verb? Verb_Open;

        public Verb? Verb_Unlock_W;

        public Verb? Verb_Close;

        public Verb? Verb_Lock_W;

        public Verb? Verb_Lock;

        public Verb? Verb_Place;

        public Verb? Verb_Save;

        public Verb? Verb_Load;

        public Verb? Verb_Help;

        public Verb? Verb_Info;

        public Verb? Verb_Clue;

        public Verb? Verb_Solution;

        public Verb? Verb_Give;

        public Verb? Verb_Plea;

        public Verb? Verb_Demand;

        public Verb? Verb_Say;

        public Verb? Verb_Ask;

        public Verb? Verb_Words;

        public Verb? Verb_Verbs;

        public Verb? Verb_ProtOn;

        public Verb? Verb_ProtOff;

        public Verb? Verb_Enter;

        public Verb? Verb_Climb;

        public Verb? Verb_Use;

        public Verb? Verb_Unscrew;
        public Verb? Verb_Truncate;

        public Verb? Verb_Taste;

        public Verb? Verb_Smell;

        public Verb? Verb_Quit;

        public Verb? Verb_Restart;

        public Verb? Verb_Wait;

        public Verb? Verb_Startpoint;

        public Verb? Verb_Show;


        public int FillID_DEF_ART;

        public int FillID_WASTE;


        public Fill Fill_DEF_ART = new();

        public Fill Fill_WASTE = new();


        public Prep? Prep_mit;

        public Prep? Prep_in;

        public Prep? Prep_nach;

        public Prep? Prep_weg;

        public Prep? Prep_ab;

        public Prep? Prep_zu;

        public Prep? Prep_auf;

        public Prep? Prep_hinter;

        public Prep? Prep_unter;

        public Prep? Prep_neben;

        public Prep? Prep_aus;

        public Prep? Prep_von;

        public Prep? Prep_Slot1;

        public Prep? Prep_Slot2;

        public Prep? Prep_Slot3;

        public Prep? Prep_Slot4;

        public Prep? Prep_Slot5;

        public Prep? Prep_Slot6;

        public Prep? Prep_Slot7;

        public Prep? Prep_Slot8;

        public Prep? Prep_Slot9;

        public Prep? Prep_Slot10;

        public Prep? Prep_an;

        public Prep? Prep_hoch;

        public Prep? Prep_runter;

        public Prep? Prep_durch;

        public Prep? Prep_zurueck;

        public Prep? Prep_alles;

        public Prep? Prep_heraus;

        public Prep? Prep_los;

        public Prep? Prep_gegen;

        public Prep? Prep_um;

        public Prep? Prep_ueber;

        public Prep? Prep_fest;

        public Prep? Prep_hin;

        public Prep? Prep_ein;

        public Prep? Prep_Wer;

        public Prep? Prep_herum;

        public Prep? Prep_stehen;

        public Prep? Prep_Stufe1;

        public Prep? Prep_Stufe2;

        public Prep? Prep_Stufe3;

        public Prep? Prep_with;
        public Prep? Prep_to;
        public Prep? Prep_off;
        public Prep? Prep_away;
        public Prep? Prep_towards;
        public Prep? Prep_against;

        public Prep? Prep_on;
        public Prep? Prep_behind;
        public Prep? Prep_under;
        public Prep? Prep_beside;
        public Prep? Prep_out;
        public Prep? Prep_from;
        public Prep? Prep_at;
        public Prep? Prep_through;
        public Prep? Prep_back;
        public Prep? Prep_over;
        public Prep? Prep_around;
        public Prep? Prep_of;
        public Prep? Prep_all;
        public Prep? Prep_about;
        public Prep? Prep_for;
        public Prep? Prep_into;
        public Prep? Prep_upon;


        public Pronoun Pronoun_Male = new();

        public Pronoun Pronoun_Female = new();

        public Pronoun Pronoun_Neuter = new();

        public Pronoun Pronoun_Male_PL = new();

        public Pronoun Pronoun_Female_PL = new();

        public Pronoun Pronoun_Neuter_PL = new();


        public int PL_Go;

        public int PL_GoMC;

        public int PL_Take;
        public int PL_English;
        public int PL_German;
        public int PL_Story;

        public int PL_Phoneyvision;
        public int PL_Realitaet;
        public int PL_TakeAll;

        public int PL_Play;
        public int PL_TakeDown;
        public int PL_TakeMC;

        public int PL_Examine;

        public int PL_ExamineMC;

        public int PL_location;

        public int PL_Inventory;

        public int PL_Drop;

        public int PL_Drop2 ;

        public int PL_PVUp;

        public int PL_PVDown;

        public int PL_DropMC;

        public int PL_Open;

        public int PL_OpenMC;

        public int PL_Unlock_W;

        public int PL_Unlock_WMC;

        public int PL_Close;

        public int PL_CloseMC;

        public int PL_Lock_W1;

        public int PL_Lock_W2;

        public int PL_Lock_W3;

        public int PL_Lock_WMC;

        public int PL_Place;

        public int PL_Place_In;

        public int PL_PlaceSoloOn;

        public int PL_Place_InMC;

        public int PL_Place_On;

        public int PL_Place_OnMC;

        public int PL_Place_Under;

        public int PL_Place_UnderMC;

        public int PL_Place_Behind;

        public int PL_Place_BehindMC;

        public int PL_Place_Beside;

        public int PL_Place_BesideMC;

        public int PL_Take_Out;

        public int PL_Take_OutMC;

        public int PL_Take_From;

        public int PL_Take_FromMC;

        public int PL_Take_From_Under;

        public int PL_Take_From_UnderMC;

        public int PL_Take_From_Behind;

        public int PL_Take_From_BehindMC;

        public int PL_Take_From_Beside;

        public int PL_Take_From_BesideMC;

        public int PL_Examine_In;

        public int PL_Examine_InMC;

        public int PL_Examine_On;

        public int PL_Examine_OnMC;

        public int PL_Examine_Below;

        public int PL_Examine_BelowMC;

        public int PL_Examine_Behind;

        public int PL_Examine_BehindMC;

        public int PL_Examine_Beside;

        public int PL_Examine_Through;

        public int PL_Examine_Out;

        public int PL_Examine_T;

        public int PL_Examine_BesideMC;

        public int PL_Save;

        public int PL_Load;

        public int PL_Help;

        public int PL_Take_P;

        public int PL_Take_PMC;

        public int PL_Examine_P;

        public int PL_Examine_PMC;

        public int PL_Open_P;

        public int PL_Open_PMC;

        public int PL_Unlock_P;

        public int PL_Unlock_PMC;

        public int PL_Close_P;

        public int PL_Close_PMC;

        public int PL_Lock_W_P;

        public int PL_Lock_W_PMC;

        public int PL_Place_In_P;

        public int PL_Place_P_In;

        public int PL_Place_In_PMC;

        public int PL_Give;

        public int PL_GiveMC;

        public int PL_Plea;

        public int PL_PleaMC;

        public int PL_Demand;

        public int PL_DemandMC;

        public int PL_Say;

        public int PL_Say2;

        public int PL_SayMC;

        public int PL_Ask;

        public int PL_AskMC;

        public int PL_Save_MC;

        public int PL_Load_MC;

        public int PL_Ask_Topic;

        public int PL_Ask_Person;

        public int PL_Ask_TopicMC;

        public int PL_Words;

        public int PL_Verbs;

        public int PL_Prot_On;

        public int PL_Prot_Off;

        public int PL_Climb;

        public int PL_ClimbMC;

        public int PL_Climb_UP;

        public int PL_Climb_UPMC;

        public int PL_Climb_Down;

        public int PL_Climb_DownMC;

        public int PL_Enter;

        public int PL_EnterMC;

        public int PL_Go_Through;

        public int PL_Go_Through2;

        public int PL_Go_ThroughMC;

        public int PL_Go_Behind;

        public int PL_Taste;

        public int PL_TasteMC;

        public int PL_Smell;

        public int PL_SmellSolo;

        public int PL_Smell2;

        public int PL_Smell_P;

        public int PL_Smell2_P;

        public int PL_SmellMC;

        public int PL_Quit;

        public int PL_QuitMC;

        public int PL_Restart;

        public int PL_Restart2;
        public int PL_Restart3;
        public int PL_Restart4;

        public int PL_Startpoint;

        public int PL_Wait;

        public int PL_Wait2;

        public int PL_WaitMC;

        public int PL_Go_To;

        public int PL_Go_ToMC;

        public int PL_Go_To2;

        public int PL_Go_To2MC;

        public int PL_Go_In;

        public int PL_MC_Item;

        public int PL_MC_Person;

        public int PL_Help_For;

        public int PL_Info;

        public int PL_Info_For;

        public int PL_Clue_For;

        public int PL_Solution_For;

        public int PL_Help_For_P;

        public int PL_Info_For_P;

        public int PL_Clue_For_P;

        public int PL_Solution_For_P;

        public int PL_Help_For2;

        public int PL_Info_For2;

        public int PL_Clue_For2;

        public int PL_Solution_For2;

        public int PL_Help_For_P2;

        public int PL_Info_For_P2;

        public int PL_Clue_For_P2;

        public int PL_Solution_For_P2;

        public int PL_Lay_Down;



        public int VT_gehen { get; set; }

        public int VT_nehmen { get; set; }

        public int VT_oeffnen { get; set; }

        public int VT_schliessen { get; set; }

        public   int VT_untersuchen { get; set; }

        public   int VT_koennen { get; set; }

        public   int VT_haben { get; set; }

        public   int VT_holen { get; set; }

        public   int VT_ziehen { get; set; }

        public   int VT_schauen { get; set; }

        public   int VT_legen { get; set; }

        public   int VT_sehen { get; set; }

        public   int VT_geben { get; set; }

        public   int VT_stehen { get; set; }

        public   int VT_sein { get; set; }

        public   int VT_kauern { get; set; }

        public   int VT_herumzerren { get; set; }

        public   int VT_anschauen { get; set; }

        public   int VT_halten { get; set; }

        public   int VT_umschauen { get; set; }

        public   int VT_wollen { get; set; }

        public   int VT_bitten { get; set; }

        public   int VT_fordern { get; set; }

        public   int VT_setzen { get; set; }

        public   int VT_denken { get; set; }

        public   int VT_finden { get; set; }

        public   int VT_aufstehen { get; set; }

        public   int VT_strangulieren { get; set; }

        public   int VT_druecken { get; set; }

        public   int VT_fallen { get; set; }

        public   int VT_sagen { get; set; }
        public int VT_blubbern { get; set; }

        public int VT_knurren { get; set; }

        public int VT_fragen { get; set; }

        public int VT_verlassen { get; set; }

        public int VT_fahren { get; set; }

        public int VT_lesen { get; set; }

        public   int VT_steigen { get; set; }

        public   int VT_schmecken { get; set; }

        public   int VT_riechen { get; set; }

        public   int VT_warten { get; set; }

        public int VT_erscheinen { get; set; }

        public int VT_loesen { get; set; }

        public int VT_befinden { get; set; }

        public int VT_brechen { get; set; }

        public int VT_kraechzen { get; set; }

        public int VT_greifen { get; set; }

        public int VT_stochern { get; set; }

        public int VT_versuchen { get; set; }

        public int VT_betreten { get; set; }

        public int VT_schneiden { get; set; }

        public int VT_verknoten { get; set; }

        public int VT_leuchten { get; set; }

        public int VT_entzuenden { get; set; }

        public int VT_loeschen { get; set; }

        public int VT_fischen { get; set; }

        public int VT_moegen { get; set; }

        public int VT_sprechen { get; set; }

        public int VT_beruehren { get; set; }

        public int VT_passen { get; set; }

        public int VT_lassen { get; set; }

        public int VT_fuehren { get; set; }

        public int VT_weichen { get; set; }

        public int VT_heben { get; set; }

        public int VT_klopfen { get; set; }

        public int VT_zeigen { get; set; }


        public int VT_bruellen { get; set; }

        public int VT_brummen { get; set; }

        public int VT_entgegnen { get; set; }

        public int VT_erwaehnen { get; set; }

        public int VT_fluestern { get; set; }

        public int VT_grunzen { get; set; }

        public int VT_jauchzen { get; set; }

        public int VT_keuchen { get; set; }

        public int VT_kreischen { get; set; }

        public int VT_lachen { get; set; }

        public int VT_saeuseln { get; set; }

        public int VT_schreien { get; set; }

        public int VT_wispern { get; set; }

        public int VT_wueten { get; set; }

        public int VT_troeten { get; set; }


        public int VT_zischen { get; set; }

        public int VT_kichern { get; set; }

        public int VT_erklaeren { get; set; }

        public int VT_flehen { get; set; }

        public int VT_fabulieren { get; set; }


        public int VT_dozieren { get; set; }

        public int VT_drohen { get; set; }

        public int VT_frohlocken { get; set; }

        public int VT_grummeln { get; set; }

        public int VT_maulen { get; set; }

        public int VT_prahlen { get; set; }

        public int VT_seufzen { get; set; }

        public int VT_stoehnen { get; set; }


        public int VT_berichten { get; set; }

        public int VT_aechzen { get; set; }

        public int VT_betteln { get; set; }

        public int VT_schwadronieren { get; set; }

        public int VT_antworten { get; set; }

        public int VT_murmeln { get; set; }

        public int VT_beschwoeren { get; set; }

        public int VT_rufen { get; set; }


        public int VT_draengeln { get; set; }

        public int VT_beschwichtigen { get; set; }

        public int VT_stottern { get; set; }


        public int VT_lallen { get; set; }

        public int VT_nothing { get; set; }

        public int VT_schaeumen { get; set; }

        public int VT_schnauben { get; set; }

        public int VT_raunen { get; set; }

        public int VT_draengen { get; set; }

        public int VT_gruebeln { get; set; }

        public int VT_johlen { get; set; }

        public int VT_sinnieren { get; set; }


        public int VT_erzaehlen { get; set; }

        public int VT_staunen { get; set; }

        public int VT_behaupten { get; set; }

        public int VT_jammern { get; set; }


        public int VT_keifen { get; set; }

        public int VT_schwaermen { get; set; }

        public int VT_verkuenden { get; set; }


        public int VT_schnaufen { get; set; }

        public int VT_gaehnen { get; set; }


        public int VT_freuen { get; set; }

        public int VT_loben { get; set; }


        public int VT_heulen { get; set; }

        public int VT_raeuspern { get; set; }

        public int VT_roecheln { get; set; }

        public int VT_schlucken { get; set; }

        public int VT_winseln { get; set; }

        public int VT_betrachten { get; set; }

        public int VT_summen { get; set; }



        public int Tense_1P_Sin_Present = 1;

        public int Tense_2P_Sin_Present =2;

        public int Tense_3P_Sin_Present = 3;

        public int Tense_1P_Pl_Present =4;

        public int Tense_2P_Pl_Present =5;

        public int Tense_3P_Pl_Present =6;

        public int Tense_1P_Sin_Past =7;

        public int Tense_2P_Sin_Past =8;

        public int Tense_3P_Sin_Past =9;

        public int Tense_1P_Pl_Past =10;

        public int Tense_2P_Pl_Past =11;

        public int Tense_3P_Pl_Past =12;

        public int Tense_Past = 13;

        public int Tense_Present = 14;


        public int LocType_Loc;

        public int LocType_In_Item;

        public int LocType_Person;

        public int LocType_Behind_Item;

        public int LocType_On_Item;

        public int LocType_Below_Item;

        public int LocType_Beside_Item;

        public int LocType_In_Person;

        public int LocType_To_Person;



        public int MCE_Text = 1;

        public int MCE_Choice = 2;

        public int MCE_Status = 3;

        public int MCE_Flag_Hidden = 4;

        public int MCE_Flag_Deactivate = 5;

        public int MCE_Follower = 6;


        public int MCE_Choice_Off = 1000;

        public int MCE_Flag_Off = 2000;

        public int MCE_Flag_DeactivateAfterSelect_Off = 2000;

        public int MCE_Flag_Hidden_Off = 3000;

        public int MCE_Status_Off = 4000;

        public int MCE_Follower_Off = 5000;

        public int MCE_End_Off = 6000;


        public int MCE_Choice1 = 1001;

        public int MCE_Choice2 = 1002;

        public int MCE_Choice3 = 1003;

        public int MCE_Choice4 = 1004;

        public int MCE_Choice5 = 1005;

        public int MCE_Choice6 = 1006;


        public int MCE_Status1 = 4001;

        public int MCE_Status2 = 4002;

        public int MCE_Status3 = 4003;

        public int MCE_Status4 = 4004;

        public int MCE_Status5 = 4005;

        public int MCE_Status6 = 4006;

        public int MCE_Status7 = 4007;

        public int MCE_Status8 = 4008;


        public int MCEix;

        public int MCEixOld;

        public int MCE_ID;


        public int MCE_Hidden = 1;


        public int MCE_ID_HELP = 1;


        public CoBase()
        { 
            /*
            VerbID_N = SerialNumberGenerator.Instance.NextSerial;
            VerbID_NE = SerialNumberGenerator.Instance.NextSerial;
            VerbID_E = SerialNumberGenerator.Instance.NextSerial;
            VerbID_SE = SerialNumberGenerator.Instance.NextSerial;
            VerbID_S = SerialNumberGenerator.Instance.NextSerial;
            VerbID_SW = SerialNumberGenerator.Instance.NextSerial;
            VerbID_W = SerialNumberGenerator.Instance.NextSerial;
            VerbID_NW = SerialNumberGenerator.Instance.NextSerial;
            VerbID_U = SerialNumberGenerator.Instance.NextSerial;
            VerbID_D = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Take = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Examine = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Inventory = SerialNumberGenerator.Instance.NextSerial;
            VerbID_location = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Go = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Drop = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Open = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Unlock_W = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Close = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Lock_W = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Place = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Save = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Load = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Help = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Give = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Plea = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Demand = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Say = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Ask = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Words = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Enter = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Climb = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Use = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Taste = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Smell = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Quit = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Restart = SerialNumberGenerator.Instance.NextSerial;
            VerbID_Wait = SerialNumberGenerator.Instance.NextSerial;
            */

            FillID_DEF_ART = SerialNumberGenerator.Instance.NextSerial;
            FillID_WASTE = SerialNumberGenerator.Instance.NextSerial;

            PL_English = SerialNumberGenerator.Instance.NextSerial;
            PL_German = SerialNumberGenerator.Instance.NextSerial;
            PL_Story = SerialNumberGenerator.Instance.NextSerial;
            PL_Phoneyvision = SerialNumberGenerator.Instance.NextSerial;
            PL_Realitaet = SerialNumberGenerator.Instance.NextSerial;
            PL_Go = SerialNumberGenerator.Instance.NextSerial;
            PL_GoMC = SerialNumberGenerator.Instance.NextSerial;
            PL_Take = SerialNumberGenerator.Instance.NextSerial;
            PL_TakeAll = SerialNumberGenerator.Instance.NextSerial;
            PL_TakeDown = SerialNumberGenerator.Instance.NextSerial;
            PL_TakeMC = SerialNumberGenerator.Instance.NextSerial;
            PL_Play = SerialNumberGenerator.Instance.NextSerial;
            PL_Examine = SerialNumberGenerator.Instance.NextSerial;
            PL_location = SerialNumberGenerator.Instance.NextSerial;
            PL_Inventory = SerialNumberGenerator.Instance.NextSerial;
            PL_Drop = SerialNumberGenerator.Instance.NextSerial;
            PL_Drop2 = SerialNumberGenerator.Instance.NextSerial;
            PL_PVUp = SerialNumberGenerator.Instance.NextSerial;
            PL_PVDown = SerialNumberGenerator.Instance.NextSerial;
            PL_Open = SerialNumberGenerator.Instance.NextSerial;
            PL_Lay_Down = SerialNumberGenerator.Instance.NextSerial;
            PL_Unlock_W = SerialNumberGenerator.Instance.NextSerial;
            PL_Close = SerialNumberGenerator.Instance.NextSerial;
            PL_Lock_W1 = SerialNumberGenerator.Instance.NextSerial;
            PL_Lock_W2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Lock_W3 = SerialNumberGenerator.Instance.NextSerial;
            PL_Lock_WMC = SerialNumberGenerator.Instance.NextSerial;
            PL_Place = SerialNumberGenerator.Instance.NextSerial;
            PL_Place_In = SerialNumberGenerator.Instance.NextSerial;
            PL_PlaceSoloOn = SerialNumberGenerator.Instance.NextSerial;
            PL_Place_On = SerialNumberGenerator.Instance.NextSerial;
            PL_Place_Under = SerialNumberGenerator.Instance.NextSerial;
            PL_Place_Behind = SerialNumberGenerator.Instance.NextSerial;
            PL_Place_Beside = SerialNumberGenerator.Instance.NextSerial;
            PL_Take_Out = SerialNumberGenerator.Instance.NextSerial;
            PL_Take_From = SerialNumberGenerator.Instance.NextSerial;
            PL_Take_From_Under = SerialNumberGenerator.Instance.NextSerial;
            PL_Take_From_Behind = SerialNumberGenerator.Instance.NextSerial;
            PL_Take_From_Beside = SerialNumberGenerator.Instance.NextSerial;
            PL_Examine_In = SerialNumberGenerator.Instance.NextSerial;
            PL_Examine_On = SerialNumberGenerator.Instance.NextSerial;
            PL_Examine_Below = SerialNumberGenerator.Instance.NextSerial;
            PL_Examine_Behind = SerialNumberGenerator.Instance.NextSerial;
            PL_Examine_Beside = SerialNumberGenerator.Instance.NextSerial;
            PL_Examine_Through = SerialNumberGenerator.Instance.NextSerial;
            PL_Examine_Out = SerialNumberGenerator.Instance.NextSerial;
            PL_Examine_T = SerialNumberGenerator.Instance.NextSerial;
            PL_Save = SerialNumberGenerator.Instance.NextSerial;
            PL_Load = SerialNumberGenerator.Instance.NextSerial;
            PL_Help = SerialNumberGenerator.Instance.NextSerial;
            PL_Help_For = SerialNumberGenerator.Instance.NextSerial;
            PL_Info_For = SerialNumberGenerator.Instance.NextSerial;
            PL_Clue_For = SerialNumberGenerator.Instance.NextSerial;
            PL_Solution_For = SerialNumberGenerator.Instance.NextSerial;
            PL_Help_For_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Info_For_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Clue_For_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Solution_For_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Help_For2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Info_For2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Clue_For2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Solution_For2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Help_For_P2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Info_For_P2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Clue_For_P2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Solution_For_P2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Take_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Examine_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Open_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Unlock_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Close_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Lock_W_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Place_In_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Place_P_In = SerialNumberGenerator.Instance.NextSerial;
            PL_Give = SerialNumberGenerator.Instance.NextSerial;
            PL_Plea = SerialNumberGenerator.Instance.NextSerial;
            PL_Demand = SerialNumberGenerator.Instance.NextSerial;
            PL_Say = SerialNumberGenerator.Instance.NextSerial;
            PL_Say2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Ask = SerialNumberGenerator.Instance.NextSerial;
            PL_Save_MC = SerialNumberGenerator.Instance.NextSerial;
            PL_Load_MC = SerialNumberGenerator.Instance.NextSerial;
            PL_Ask_Topic = SerialNumberGenerator.Instance.NextSerial;
            PL_Ask_Person = SerialNumberGenerator.Instance.NextSerial;
            PL_Words = SerialNumberGenerator.Instance.NextSerial;
            PL_Verbs = SerialNumberGenerator.Instance.NextSerial;
            PL_Prot_On = SerialNumberGenerator.Instance.NextSerial;
            PL_Prot_Off = SerialNumberGenerator.Instance.NextSerial;
            PL_Climb = SerialNumberGenerator.Instance.NextSerial;
            PL_Enter = SerialNumberGenerator.Instance.NextSerial;
            PL_Go_Through = SerialNumberGenerator.Instance.NextSerial;
            PL_Go_Through2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Go_Behind = SerialNumberGenerator.Instance.NextSerial;
            PL_Taste = SerialNumberGenerator.Instance.NextSerial;
            PL_Smell = SerialNumberGenerator.Instance.NextSerial;
            PL_SmellSolo = SerialNumberGenerator.Instance.NextSerial;
            PL_Smell2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Smell_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Smell2_P = SerialNumberGenerator.Instance.NextSerial;
            PL_Quit = SerialNumberGenerator.Instance.NextSerial;
            PL_Restart = SerialNumberGenerator.Instance.NextSerial;
            PL_Restart2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Restart3 = SerialNumberGenerator.Instance.NextSerial;
            PL_Restart4 = SerialNumberGenerator.Instance.NextSerial;
            PL_Wait = SerialNumberGenerator.Instance.NextSerial;
            PL_Wait2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Go_To = SerialNumberGenerator.Instance.NextSerial;
            PL_Go_To2 = SerialNumberGenerator.Instance.NextSerial;
            PL_Go_In = SerialNumberGenerator.Instance.NextSerial;
            PL_MC_Item = SerialNumberGenerator.Instance.NextSerial;
            PL_MC_Person = SerialNumberGenerator.Instance.NextSerial;

            VT_gehen = SerialNumberGenerator.Instance.NextSerial;
            VT_nehmen = SerialNumberGenerator.Instance.NextSerial;
            VT_oeffnen = SerialNumberGenerator.Instance.NextSerial;
            VT_schliessen = SerialNumberGenerator.Instance.NextSerial;
            VT_untersuchen = SerialNumberGenerator.Instance.NextSerial;
            VT_koennen = SerialNumberGenerator.Instance.NextSerial;
            VT_haben = SerialNumberGenerator.Instance.NextSerial;
            VT_holen = SerialNumberGenerator.Instance.NextSerial;
            VT_ziehen = SerialNumberGenerator.Instance.NextSerial;
            VT_schauen = SerialNumberGenerator.Instance.NextSerial;
            VT_klopfen = SerialNumberGenerator.Instance.NextSerial;
            VT_legen = SerialNumberGenerator.Instance.NextSerial;
            VT_sehen = SerialNumberGenerator.Instance.NextSerial;
            VT_geben = SerialNumberGenerator.Instance.NextSerial;
            VT_stehen = SerialNumberGenerator.Instance.NextSerial;
            VT_sein = SerialNumberGenerator.Instance.NextSerial;
            VT_kauern = SerialNumberGenerator.Instance.NextSerial;
            VT_herumzerren = SerialNumberGenerator.Instance.NextSerial;
            VT_anschauen = SerialNumberGenerator.Instance.NextSerial;
            VT_halten = SerialNumberGenerator.Instance.NextSerial;
            VT_umschauen = SerialNumberGenerator.Instance.NextSerial;
            VT_wollen = SerialNumberGenerator.Instance.NextSerial;
            VT_bitten = SerialNumberGenerator.Instance.NextSerial;
            VT_fordern = SerialNumberGenerator.Instance.NextSerial;
            VT_setzen = SerialNumberGenerator.Instance.NextSerial;
            VT_denken = SerialNumberGenerator.Instance.NextSerial;
            VT_finden = SerialNumberGenerator.Instance.NextSerial;
            VT_aufstehen = SerialNumberGenerator.Instance.NextSerial;
            VT_strangulieren = SerialNumberGenerator.Instance.NextSerial;
            VT_druecken = SerialNumberGenerator.Instance.NextSerial;
            VT_fallen = SerialNumberGenerator.Instance.NextSerial;
            VT_sagen = SerialNumberGenerator.Instance.NextSerial;
            VT_blubbern = SerialNumberGenerator.Instance.NextSerial;
            VT_fragen = SerialNumberGenerator.Instance.NextSerial;
            VT_lesen = SerialNumberGenerator.Instance.NextSerial;
            VT_steigen = SerialNumberGenerator.Instance.NextSerial;
            VT_schmecken = SerialNumberGenerator.Instance.NextSerial;
            VT_riechen = SerialNumberGenerator.Instance.NextSerial;
            VT_erscheinen = SerialNumberGenerator.Instance.NextSerial;
            VT_loesen = SerialNumberGenerator.Instance.NextSerial;
            VT_befinden = SerialNumberGenerator.Instance.NextSerial;
            VT_brechen = SerialNumberGenerator.Instance.NextSerial;
            VT_kraechzen = SerialNumberGenerator.Instance.NextSerial;
            VT_greifen = SerialNumberGenerator.Instance.NextSerial;
            VT_stochern = SerialNumberGenerator.Instance.NextSerial;
            VT_versuchen = SerialNumberGenerator.Instance.NextSerial;
            VT_betreten = SerialNumberGenerator.Instance.NextSerial;
            VT_schneiden = SerialNumberGenerator.Instance.NextSerial;
            VT_verknoten = SerialNumberGenerator.Instance.NextSerial;
            VT_leuchten = SerialNumberGenerator.Instance.NextSerial;
            VT_entzuenden = SerialNumberGenerator.Instance.NextSerial;
            VT_loeschen = SerialNumberGenerator.Instance.NextSerial;
            VT_fischen = SerialNumberGenerator.Instance.NextSerial;
            VT_moegen = SerialNumberGenerator.Instance.NextSerial;
            VT_sprechen = SerialNumberGenerator.Instance.NextSerial;
            VT_beruehren = SerialNumberGenerator.Instance.NextSerial;
            VT_passen = SerialNumberGenerator.Instance.NextSerial;
            VT_lassen = SerialNumberGenerator.Instance.NextSerial;
            VT_fuehren = SerialNumberGenerator.Instance.NextSerial;
            VT_weichen = SerialNumberGenerator.Instance.NextSerial;
            VT_heben = SerialNumberGenerator.Instance.NextSerial;
            VT_warten = SerialNumberGenerator.Instance.NextSerial;
            VT_zeigen = SerialNumberGenerator.Instance.NextSerial;

            VT_entgegnen = SerialNumberGenerator.Instance.NextSerial;
            VT_erwaehnen = SerialNumberGenerator.Instance.NextSerial;
            VT_kreischen = SerialNumberGenerator.Instance.NextSerial;
            VT_saeuseln = SerialNumberGenerator.Instance.NextSerial;
            VT_bruellen = SerialNumberGenerator.Instance.NextSerial;
            VT_wueten = SerialNumberGenerator.Instance.NextSerial;
            VT_schreien = SerialNumberGenerator.Instance.NextSerial;
            VT_wispern = SerialNumberGenerator.Instance.NextSerial;
            VT_fluestern = SerialNumberGenerator.Instance.NextSerial;
            VT_grunzen = SerialNumberGenerator.Instance.NextSerial;
            VT_brummen = SerialNumberGenerator.Instance.NextSerial;
            VT_lachen = SerialNumberGenerator.Instance.NextSerial;
            VT_keuchen = SerialNumberGenerator.Instance.NextSerial;
            VT_jauchzen = SerialNumberGenerator.Instance.NextSerial;
            VT_troeten = SerialNumberGenerator.Instance.NextSerial;
            VT_lachen = SerialNumberGenerator.Instance.NextSerial;
            VT_erklaeren = SerialNumberGenerator.Instance.NextSerial;
            VT_kichern = SerialNumberGenerator.Instance.NextSerial;
            VT_zischen = SerialNumberGenerator.Instance.NextSerial;
            VT_fabulieren = SerialNumberGenerator.Instance.NextSerial;
            VT_flehen = SerialNumberGenerator.Instance.NextSerial;

            VT_dozieren = SerialNumberGenerator.Instance.NextSerial;
            VT_drohen = SerialNumberGenerator.Instance.NextSerial;
            VT_frohlocken= SerialNumberGenerator.Instance.NextSerial;
            VT_grummeln = SerialNumberGenerator.Instance.NextSerial;
            VT_maulen = SerialNumberGenerator.Instance.NextSerial;
            VT_prahlen = SerialNumberGenerator.Instance.NextSerial;
            VT_seufzen = SerialNumberGenerator.Instance.NextSerial;
            VT_stoehnen = SerialNumberGenerator.Instance.NextSerial;
            VT_berichten = SerialNumberGenerator.Instance.NextSerial;
            VT_betteln = SerialNumberGenerator.Instance.NextSerial;
            VT_schwadronieren = SerialNumberGenerator.Instance.NextSerial;
            VT_aechzen = SerialNumberGenerator.Instance.NextSerial;

            VT_antworten= SerialNumberGenerator.Instance.NextSerial;
            VT_murmeln = SerialNumberGenerator.Instance.NextSerial;
            VT_beschwoeren = SerialNumberGenerator.Instance.NextSerial;
            VT_aechzen = SerialNumberGenerator.Instance.NextSerial;
            VT_rufen = SerialNumberGenerator.Instance.NextSerial;
            VT_stoehnen = SerialNumberGenerator.Instance.NextSerial;

            VT_draengen = SerialNumberGenerator.Instance.NextSerial;
            VT_gruebeln = SerialNumberGenerator.Instance.NextSerial;
            VT_johlen = SerialNumberGenerator.Instance.NextSerial;
            VT_lallen = SerialNumberGenerator.Instance.NextSerial;
            VT_nothing = SerialNumberGenerator.Instance.NextSerial;
            VT_raunen = SerialNumberGenerator.Instance.NextSerial;
            VT_schaeumen = SerialNumberGenerator.Instance.NextSerial;
            VT_schnauben = SerialNumberGenerator.Instance.NextSerial;
            VT_sinnieren = SerialNumberGenerator.Instance.NextSerial;

            VT_behaupten= SerialNumberGenerator.Instance.NextSerial;
            VT_erzaehlen = SerialNumberGenerator.Instance.NextSerial;
            VT_staunen = SerialNumberGenerator.Instance.NextSerial;
            VT_jammern = SerialNumberGenerator.Instance.NextSerial;

            VT_keifen = SerialNumberGenerator.Instance.NextSerial;
            VT_schwaermen = SerialNumberGenerator.Instance.NextSerial;
            VT_verkuenden = SerialNumberGenerator.Instance.NextSerial;
            VT_schnaufen  = SerialNumberGenerator.Instance.NextSerial;
            VT_gaehnen = SerialNumberGenerator.Instance.NextSerial;
            VT_freuen = SerialNumberGenerator.Instance.NextSerial;
            VT_loben = SerialNumberGenerator.Instance.NextSerial;

            VT_heulen = SerialNumberGenerator.Instance.NextSerial;
            VT_raeuspern = SerialNumberGenerator.Instance.NextSerial;
            VT_knurren = SerialNumberGenerator.Instance.NextSerial;

            VT_fahren = SerialNumberGenerator.Instance.NextSerial;
            VT_verlassen = SerialNumberGenerator.Instance.NextSerial;

            VT_roecheln = SerialNumberGenerator.Instance.NextSerial;
            VT_schlucken = SerialNumberGenerator.Instance.NextSerial;
            VT_winseln = SerialNumberGenerator.Instance.NextSerial;
            VT_betrachten = SerialNumberGenerator.Instance.NextSerial;

            LocType_Loc = SerialNumberGenerator.Instance.NextSerial;
            LocType_In_Item = SerialNumberGenerator.Instance.NextSerial;
            LocType_Person = SerialNumberGenerator.Instance.NextSerial;
            LocType_Behind_Item = SerialNumberGenerator.Instance.NextSerial;
            LocType_On_Item = SerialNumberGenerator.Instance.NextSerial;
            LocType_Below_Item = SerialNumberGenerator.Instance.NextSerial;
            LocType_Beside_Item = SerialNumberGenerator.Instance.NextSerial;
            LocType_In_Person = SerialNumberGenerator.Instance.NextSerial;
            LocType_To_Person = SerialNumberGenerator.Instance.NextSerial;

        }
    }
}