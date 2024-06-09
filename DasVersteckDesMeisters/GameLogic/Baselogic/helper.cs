using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

using Phoney_MAUI.Core;

namespace GameCore
{

    public class SerialNumberGenerator
    {
        // Statisches Member bietet sich hier an!

        private static volatile SerialNumberGenerator? instance;


        public static SerialNumberGenerator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SerialNumberGenerator();

                }
                return instance;
            }
        }


        private int count;

        // Oho, ein privater Konstruktur. 

        private SerialNumberGenerator()
        {

        }

        public virtual int  NextSerial
        {
            get
            {
                return (++count);
            }
        }


        public int Count
        {
            get { return count; }
            set 
            { 
                count = value; 
            }
        }
    }


    public static class Helper
    {
        [JsonIgnore]
        public static GlobalData? GD
        {
            get => GlobalData.CurrentGlobalData;
            // set => GlobalData.CurrentGlobalData = value;
        }
      
        [JsonIgnore]
        public static PersonList? _persons
        {
            get => GD!.Adventure!.Persons;
            // set => GD.Adventure.Persons = value;
        }
        [JsonIgnore]
        public static locationList? _locations
        {
            get => GD!.Adventure!.locations;
            // set => GD.Adventure.Persons = value;
        }
        [JsonIgnore]
        public static ItemList? _items
        {
            get => GD!.Adventure!.Items;
            // set => GD.Adventure.Persons = value;
        }
        [JsonIgnore]
        public static TopicList? _topics
        {
            get => GD!.Adventure!.Topics;
            // set => GD.Adventure.Persons = value;
        }
        [JsonIgnore]
        public static CoBase? _cb
        {
            get => GD!.Adventure!.CB;
            // set => GD.Adventure.Persons = value;
        }
        [JsonIgnore]
        public static AdvData? _a
        {
            get => GD!.Adventure!.A;
            // set => GD.Adventure.Persons = value;
        }
        [JsonIgnore]
        public static Adv? _advGame
        {
            get => GD!.Adventure;
            // set => GD.Adventure.Persons = value;
        }

        // static PersonList? _persons;
        // static locationList? _locations;
        // static ItemList? _items;
        // static TopicList? _topics;
        // static CoBase? _cb;
        // static AdvData? _a;
        // static Adv? _advGame;


        public static string? ShrinkQuotationMark( string? s)
        {
            if (s == null) return null;

            StringBuilder s2 = new StringBuilder();
            for ( int i = 0; i < s.Length; i++)
            {
                if (s[i] == '\"')
                    s2.Append('\'');
                else
                    s2.Append(s[i]);
            }
            return s2.ToString();
        }

        public static string StripHTML(string s)
        {
            StringBuilder s2 = new StringBuilder( );

            int i = 0;
            int len = s.Length;

            // Noloca: 002

            while (i < len)
            {
                if (s[i] == '<')
                {
                    if (s[i + 1] == 'b' && s[i + 2] == 'r' && s[i + 3] == '>')
                    {
                        i = i + 4;
                        s2.Append( "\n"); //  = s2 + '\n';
                    }
                    else if (s[i + 1] == 'b' && s[i + 2] == 'r' && s[i + 3] == '/' && s[i + 4] == '>')
                    {
                        bool skipAppend = false;
                        i = i + 5;
                        if( s2.Length > 1 )
                        {
                            int off = s2.Length - 1;

                            if (s2[ off] == '\n' )
                                skipAppend = true;
                        }
                        if( !skipAppend )
                          s2.Append( "\n"); //  = s2 + '\n';
                    }
                    else
                    {
                        try
                        {
                            while (s[i] != '>') i++;
                        }
                        catch // ( Exception e)
                        {
                            // int a = 5;
                        }
                        i++;
                    }
                }
                else
                {
                    s2.Append(s[i++]);
                    // s2 = s2 + s[i++];
                }
            }
            return s2.ToString();

        }

        public static string? FirstUpper(string? s)
        {
            int i;
            int htmltag = 0;
            string s2 = "";
            bool firstDone = false;

            if (s == null) return s;

            for (i = 0; i < s.Length; i++)
            {
                if (s[i] == '<')
                {
                    htmltag++;
                    s2 = s2 + s[i];
                }
                else if (s[i] == '>')
                {
                    htmltag--;
                    s2 = s2 + s[i];
                }
                else if ((htmltag == 0) && (!firstDone))
                {
                    string s1 = Char.ToString(s[i]);
                    // Noloca: 001

                    string s1a = s1.ToUpper(new CultureInfo( "de-DE", false));
                    s2 = s2 + s1a;
                    firstDone = true;
                }
                else
                    s2 = s2 + s[i];

                if (firstDone) break;
            }
            if (i < s.Length)
                s2 += s.Substring(i+1, s.Length - i-1);
            return (s2);

            // return (s);
        }


        /*
        public static void ConfigInsert( PersonList? p, ItemList? i, locationList? locations, TopicList Topics, CoBase cb, AdvData a, Adv AdvGame )
        {
            // _persons = p;
            // _items = i;
            // _cb = cb;
            // _a = a;
            // _advGame = AdvGame;
            // _locations = locations;
            // _topics = Topics;
        }
        */


        public static bool FindString( string source, int pos, string searchString )
        {
            // string s1 = "Hello World";
            // string s2 = "lo W";

            /*
            if (String.Compare(s1, 3, s2, 0, s2.Length) == 0)
            {

            }

                if ( pos + searchString.Length <= source.Length )
            {
            */

            if ( String.Compare(source, pos, searchString, 0, searchString.Length) == 0 )
            // if( source.Substring( pos, searchString.Length ).Equals( searchString) )
            {
                return true; 
            }
            /*
            else
            {
                if (pos + searchString.Length <= source.Length)
                {

                    if (source.Substring(pos, searchString.Length).Equals(searchString))
                    {

                    }
                }
            }
            */
            // }
            return false;
        }

        public static string InsertString(string? s, params object[] obj)
        {
            string? snew = "";
            int ix = 0;

            // Noloca: 100
            while (ix < s!.Length)
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
                        Item? iapp = null;
                        Person? p = null;
                        Person? pt = null;
                        Person? plt = null;
                        Person? plv = null;
                        Person? pVP = null;
                        Person? rp = null;
                        Person? pr = null;
                        Person? papp = null;
                        Item? iVP = null;
                        Topic? t = null;
                        string? pString = null;
                        int aocase = Co.CASE_AKK;
                        int verbID = -1;
                        int itemID = 0;
                        int locationID = 0;
                        int dirID = 0;
                        string insertString = "";

                        // Erst mal werden die location-Inserts eingef�gt, die vollst�ndig im String kodiert sind
                        if (s.Substring(ix, 4) == "[/I]")
                        {
                            lenSeq = 4;
                        }
                        else if (s.Substring(ix, 4) == "[/P]")
                        {
                            lenSeq = 4;
                        }
                        else if (s.Substring(ix, 4) == "[/L]")
                        {
                            lenSeq = 4;
                        }
                        else if (s.Substring(ix, 4) == "[/D]")
                        {
                            lenSeq = 4;
                        }
                        else if (FindString(s, ix, "[S1]"))
                        {
                            lenSeq = 4;
                            insertString = (string)obj[0];
                            snew += insertString;
                        }
                        else if (FindString(s, ix, "[S2]"))
                        {
                            lenSeq = 4;
                            insertString = (string)obj[1];
                            snew += insertString;
                        }
                        else if (FindString(s, ix, "[S3]"))
                        {
                            lenSeq = 4;
                            insertString = (string)obj[2];
                            snew += insertString;
                        }
                        else if (FindString(s, ix, "[S4]"))
                        {
                            lenSeq = 4;
                            insertString = (string)obj[3];
                            snew += insertString;
                        }
                        else if (FindString(s, ix, "[S5]"))
                        {
                            lenSeq = 4;
                            insertString = (string)obj[4];
                            snew += insertString;
                        }
                        else if (FindString(s, ix, "[S6]"))
                        {
                            lenSeq = 4;
                            insertString = (string)obj[5];
                            snew += insertString;
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
                                    lenSeq = pos2;
                                    // ix += pos2;
                                }
                            }
                            else
                                lenSeq = 1;
                            //  ix += 1;
                        }
                        else if (s.Substring(ix, 3) == "[P:")
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
                                    snew += "<Person:" + itemID.ToString("00000.##") + ">" + pString2 + "</Person>";
                                    lenSeq = pos2;
                                    // ix += pos2;
                                }
                            }
                            else
                                lenSeq = 1;
                            //  ix += 1;
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
                                    lenSeq = pos2;
                                    // ix += pos2;
                                }
                            }
                            else
                                lenSeq = 1;
                            // ix += 1;
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
                                    lenSeq = pos2;
                                    // ix += pos2;
                                }
                            }
                            else
                                lenSeq = 1;
                        }
                        else if (FindString(s, ix, "[Dir:"))
                        {
                            int ixDir = s[ix + 5] - 49;
                            int idDir = (int)obj[ixDir];
                            snew += _locations!.GetDirection(idDir);
                            lenSeq += 7;
                        }
                        else if (FindString(s, ix, "[Il1,"))
                        {
                            if (obj[0].GetType() == typeof( Item ))
                            {
                                i = (Item)obj[0];
                            }
                            else
                            {
                                int id = (int)obj[0];
                                i = (Item)_advGame!.Items!.Find(id)!;

                            }
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Il2,"))
                        {
                            if (obj[1].GetType() == typeof(Item))
                            {
                                i = (Item)obj[1];
                            }
                            else
                            {
                                int id = (int)obj[1];
                                i = (Item)_advGame?.Items?.Find(id)!;

                            }
                            // int id = (int)obj[1];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Il3,"))
                        {
                            if (obj[2].GetType() == typeof(Item))
                            {
                                i = (Item)obj[2];
                            }
                            else
                            {
                                int id = (int)obj[2];
                                i = (Item?)_advGame?.Items?.Find(id);

                            }
                            // int id = (int)obj[2];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Il4,"))
                        {
                            if (obj[3].GetType() == typeof(Item))
                            {
                                i = (Item?)obj[3];
                            }
                            else
                            {
                                int id = (int)obj[3];
                                i = (Item?)_advGame?.Items?.Find(id);

                            }
                            // int id = (int)obj[3];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Il5,"))
                        {
                            if (obj[4].GetType() == typeof(Item))
                            {
                                i = (Item)obj[4];
                            }
                            else
                            {
                                int id = (int)obj[4];
                                i = (Item?)_advGame?.Items?.Find(id);

                            }
                            // int id = (int)obj[4];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Il6,"))
                        {
                            if (obj[5].GetType() == typeof(Item))
                            {
                                i = (Item)obj[5];
                            }
                            else
                            {
                                int id = (int)obj[5];
                                i = (Item?)_advGame?.Items?.Find(id);

                            }
                            // int id = (int)obj[5];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Ila1,"))
                        {
                            if (obj[0].GetType() == typeof(Item))
                            {
                                iapp = (Item)obj[0];
                            }
                            else
                            {
                                int id = (int)obj[0];
                                iapp = (Item?)_advGame?.Items?.Find(id);

                            }
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Ila2,"))
                        {
                            if (obj[1].GetType() == typeof(Item))
                            {
                                iapp = (Item?)obj[1];
                            }
                            else
                            {
                                int id = (int)obj[1];
                                iapp = (Item?)_advGame?.Items?.Find(id);

                            }
                            // int id = (int)obj[1];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Ila3,"))
                        {
                            if (obj[2].GetType() == typeof(Item))
                            {
                                iapp = (Item?)obj[2];
                            }
                            else
                            {
                                int id = (int)obj[2];
                                iapp = (Item?)_advGame?.Items?.Find(id);

                            }
                            // int id = (int)obj[2];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Ila4,"))
                        {
                            if (obj[3].GetType() == typeof(Item))
                            {
                                iapp = (Item?)obj[3];
                            }
                            else
                            {
                                int id = (int)obj[3];
                                iapp = (Item?)_advGame!.Items!.Find(id);

                            }
                            // int id = (int)obj[3];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Ila5,"))
                        {
                            if (obj[4].GetType() == typeof(Item))
                            {
                                iapp = (Item?)obj[4];
                            }
                            else
                            {
                                int id = (int)obj[4];
                                iapp = (Item?)_advGame!.Items!.Find(id);

                            }
                            // int id = (int)obj[4];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Ila6,"))
                        {
                            if (obj[5].GetType() == typeof(Item))
                            {
                                iapp = (Item?)obj[5];
                            }
                            else
                            {
                                int id = (int)obj[5];
                                iapp = (Item?)_advGame!.Items!.Find(id);

                            }
                            // int id = (int)obj[5];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Pla1,"))
                        {
                            if (obj[0].GetType() == typeof(Person))
                            {
                                papp = (Person)obj[0];
                            }
                            else
                            {
                                int id = (int)obj[0];
                                papp = (Person?)_advGame?.Persons?.Find(id);

                            }
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Pla2,"))
                        {
                            if (obj[1].GetType() == typeof(Person))
                            {
                                papp = (Person?)obj[1];
                            }
                            else
                            {
                                int id = (int)obj[1];
                                papp = (Person?)_advGame?.Persons?.Find(id);

                            }
                            // int id = (int)obj[1];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Pla3,"))
                        {
                            if (obj[2].GetType() == typeof(Person))
                            {
                                papp = (Person?)obj[2];
                            }
                            else
                            {
                                int id = (int)obj[2];
                                papp = (Person?)_advGame?.Persons?.Find(id);

                            }
                            // int id = (int)obj[2];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Pla4,"))
                        {
                            if (obj[3].GetType() == typeof(Person))
                            {
                                papp = (Person?)obj[3];
                            }
                            else
                            {
                                int id = (int)obj[3];
                                papp = (Person?)_advGame!.Persons!.Find(id);

                            }
                            // int id = (int)obj[3];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Pla5,"))
                        {
                            if (obj[4].GetType() == typeof(Person))
                            {
                                papp = (Person?)obj[4];
                            }
                            else
                            {
                                int id = (int)obj[4];
                                papp = (Person?)_advGame!.Persons!.Find(id);

                            }
                            // int id = (int)obj[4];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Pla6,"))
                        {
                            if (obj[5].GetType() == typeof(Person))
                            {
                                papp = (Person?)obj[5];
                            }
                            else
                            {
                                int id = (int)obj[5];
                                papp = (Person?)_advGame!.Persons!.Find(id);

                            }
                            // int id = (int)obj[5];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[It1,"))
                        {
                            it = (Item?)_items!.Find((int)obj[0]);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[It2,"))
                        {
                            it = (Item?)_items!.Find((int)obj[1]);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[It3,"))
                        {
                            it = (Item?)_items!.Find((int)obj[2]);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[It4,"))
                        {
                            it = (Item?)_items!.Find((int)obj[3]);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[It5,"))
                        {
                            it = (Item?)_items!.Find((int)obj[4]);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[It6,"))
                        {
                            it = (Item?)_items!.Find((int)obj[5]);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Pl1,\""))
                        {
                            p = (Person)obj[0];
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += 6 + pString!.Length + 2;
                        }
                        else if (FindString(s, ix, "[Pl2,\""))
                        {
                            p = (Person)obj[1];
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += 6 + pString!.Length + 2;
                        }
                        else if (FindString(s, ix, "[Pl3,\""))
                        {
                            p = (Person)obj[2];
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += 6 + pString!.Length + 2;
                        }
                        else if (FindString(s, ix, "[Pl4,\""))
                        {
                            p = (Person)obj[3];
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += 6 + pString!.Length + 2;
                        }
                        else if (FindString(s, ix, "[Pl5,\""))
                        {
                            p = (Person)obj[4];
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += 6 + pString!.Length + 2;
                        }
                        else if (FindString(s, ix, "[Pl6,\""))
                        {
                            p = (Person)obj[5];
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += 6 + pString!.Length + 2;
                        }
                        else if (FindString(s, ix, "[Ps"))
                        {
                            int ixPers = s[ix + 3] - 48;
                            int ixString = s[ix + 5] - 48;

                            p = (Person)obj[ixPers -1 ];
                            pString = (string)obj[ixString - 1];
                            lenSeq += "[Ps1,2]".Length;
                        }
                        else if (FindString(s, ix, "[Pl1,"))
                        {
                            pt = (Person)obj[0];
                            lenSeq += "[Pl1,".Length;
                        }
                        else if (FindString(s, ix, "[Pl2,"))
                        {
                            pt = (Person)obj[1];
                            lenSeq += "[Pl2,".Length;
                        }
                        else if (FindString(s, ix, "[Pl3,"))
                        {
                            pt = (Person)obj[2];
                            lenSeq += "[Pl3,".Length;
                        }
                        else if (FindString(s, ix, "[Pl4,"))
                        {
                            pt = (Person)obj[3];
                            lenSeq += "[Pl4,".Length;
                        }
                        else if (FindString(s, ix, "[Pl5,"))
                        {
                            pt = (Person)obj[4];
                            lenSeq += "[Pl5,".Length;
                        }
                        else if (FindString(s, ix, "[Pl6,"))
                        {
                            pt = (Person)obj[5];
                            lenSeq += "[Pl6,".Length;
                        }
                        else if (FindString(s, ix, "[Pt1,"))
                        {
                            pt = (Person)obj[0];
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Pt2,"))
                        {
                            pt = (Person)obj[1];
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Pt3,"))
                        {
                            pt = (Person)obj[2];
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Pt4,"))
                        {
                            pt = (Person)obj[3];
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Pt5,"))
                        {
                            pt = (Person)obj[4];
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Pt6,"))
                        {
                            pt = (Person)obj[5];
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Plt1,"))
                        {
                            plt = (Person)obj[0];
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Plt2,"))
                        {
                            plt = (Person)obj[1];
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Plt3,"))
                        {
                            pt = (Person)obj[2];
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Plt4,"))
                        {
                            pt = (Person)obj[3];
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Plt5,"))
                        {
                            pt = (Person)obj[4];
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Plt6,"))
                        {
                            pt = (Person)obj[5];
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[VP:"))
                        {
                            int pos = s.Substring(ix + "[VP:".Length).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + "[VP:".Length, pos);
                                verbID = SearchVT(pString);
                                lenSeq += "[VP:".Length + pString.Length + 1;

                            }
                            int ixObj = s[ix + lenSeq] - 48;
                            if (ixObj > 0 && ixObj < 10)
                            {
                                if (obj[ixObj - 1].GetType() == typeof(Person))
                                {
                                    pVP = (Person)obj[ixObj - 1];
                                    snew += Grammar.GetVerbDeclination(verbID, pVP, _a!.Tense);
                                }
                                else if (obj[ixObj - 1].GetType() == typeof(Item))
                                {
                                    iVP = (Item)obj[ixObj - 1];
                                    snew += Grammar.GetVerbDeclinationFromItem(verbID, iVP.ID, _a!.Tense);

                                }

                            }
                            lenSeq += 2;
                        }
                        else if (FindString(s, ix, "[VI:"))
                        {
                            int pos = s.Substring(ix + "[VI:".Length).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + "[VI:".Length, pos);
                                verbID = SearchVT(pString);
                                lenSeq += "[VI:".Length + pString.Length + 1;

                            }
                            int ixObj = s[ix + lenSeq] - 48;
                            if (ixObj > 0 && ixObj < 10)
                            {
                                    iVP = (Item)_items!.Find( (int)obj[ixObj - 1] )!;
                                    snew += Grammar.GetVerbDeclinationFromItem(verbID, iVP.ID, _a!.Tense);

                            }
                            lenSeq += 2;
                        }
                        else if (FindString(s, ix, "[RP:"))
                        {
                            int ixPerson = s[ix + 4] - 48;
                            rp = (Person)obj[ixPerson - 1];
                            lenSeq = "[RP:1,".Length;
                        }
                        else if (FindString(s, ix, "[Pr:"))
                        {
                            int ixPerson = s[ix + 4] - 48;
                            pr = (Person)obj[ixPerson - 1];
                            lenSeq = "[Pr:1,".Length;
                        }
                        else if (FindString(s, ix, "[VP1,")
                                        || FindString(s, ix, "[VP2,")
                                        || FindString(s, ix, "[VP3,")
                                        || FindString(s, ix, "[VP4,")
                                        || FindString(s, ix, "[VP5,")
                                        || FindString(s, ix, "[VP6,")
                                    )
                        {
                            int ixPerson = s[ix + 3] - 48;
                            pVP = (Person)obj[ixPerson - 1];

                            int ixVerb = s[ix + 5] - 48;
                            if (ixVerb > 0 && ixVerb < 10)
                            {
                                verbID = (int)obj[ixVerb - 1];
                                snew += Grammar.GetVerbDeclination(verbID, pVP, _a!.Tense);
                            }
                            lenSeq = "[VP1,1]".Length;
                        }
                        else if (FindString(s, ix, "[Top")
                                    )
                        {
                            int ixTopic = s[ix + 4] - 48;
                            t = (Topic)_topics!.Find( (int) obj[ixTopic - 1])!;

                            lenSeq = "[Top1,".Length;
                        }
                        else if (FindString(s, ix, "[Plv1,"))
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
                        else if (FindString(s, ix, "[Plv2,"))
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
                        else if (FindString(s, ix, "[Plv3,"))
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
                        else if (FindString(s, ix, "[Plv4,"))
                        {
                            plv = (Person)obj[3];
                            int pos = s.Substring(ix + 6).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + 6, pos);
                                verbID = SearchVT(pString);
                                lenSeq += 6 + pString.Length + 1;
                            }
                        }
                        else if (FindString(s, ix, "[Plv5,"))
                        {
                            plv = (Person)obj[4];
                            int pos = s.Substring(ix + 6).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + 6, pos);
                                verbID = SearchVT(pString);
                                lenSeq += 6 + pString.Length + 1;
                            }
                        }
                        else if (FindString(s, ix, "[Plv6,"))
                        {
                            plv = (Person)obj[5];
                            int pos = s.Substring(ix + 6).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + 6, pos);
                                verbID = SearchVT(pString);
                                lenSeq += 6 + pString.Length + 1;
                            }
                        }

                        if (FindString(s, ix + lenSeq, "Akk]"))
                        {

                            aocase = Co.CASE_AKK;
                            lenSeq += 4;
                        }
                        else if (FindString(s, ix + lenSeq, "Nom]"))
                        {

                            aocase = Co.CASE_NOM;
                            lenSeq += 4;
                        }
                        else if (FindString(s, ix + lenSeq, "Dat]"))
                        {

                            aocase = Co.CASE_DAT;
                            lenSeq += 4;
                        }
                        else if (FindString(s, ix + lenSeq, "Akku]"))
                        {

                            aocase = Co.CASE_AKK_UNDEF;
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix + lenSeq, "Nomu]"))
                        {

                            aocase = Co.CASE_NOM_UNDEF;
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix + lenSeq, "Datu]"))
                        {

                            aocase = Co.CASE_DAT_UNDEF;
                            lenSeq += 5;
                        }

                        if (i != null)
                        {
                            snew += _items!.GetItemNameLink(i.ID, aocase, _a!.Adventure!.CurrentNouns!);
                        }
                        else if (iapp != null)
                        {
                            snew += _items!.GetItemNameLink(iapp.ID, aocase, _a!.Adventure!.CurrentNouns!, true);
                        }
                        else if (it != null)
                        {
                            snew += _items!.GetName(it.ID, aocase, null);
                        }
                        else if (p != null)
                        {
                            snew += _persons!.GetPersonLink(p, _a!.Adventure!.CurrentNouns!, pString);
                        }
                        else if (pt != null)
                        {
                            snew += _persons!.GetPersonName(pt, aocase, _a!.Adventure!.CurrentNouns!);
                        }
                        else if (plt != null)
                        {
                            snew += _persons!.GetPersonNameLink(plt, aocase, _a!.Adventure!.CurrentNouns! );
                        }
                        else if (plv != null)
                        {
                            snew += _persons!.GetPersonVerbLink(plv, aocase, verbID, _a!.Adventure!.CurrentNouns!, _a!.Tense);
                        }
                        else if (papp != null)
                        {
                            snew += _persons!.GetPersonNameLink(papp, aocase, _a!.Adventure!.CurrentNouns!);
                        }
                        else if ( rp != null)
                        {
                            snew += Grammar.GetReflexivePronoun(rp, aocase);
                        }
                        else if (pr != null)
                        {
                            snew += Grammar.GetPronoun(pr);
                        }
                        else if (t != null)
                        {
                            snew += _topics!.GetTopicName( t.ID, aocase, _a!.Adventure!.CurrentNouns! ); 
                        }

                        if (lenSeq == 0)
                            lenSeq = 1;
                        ix += lenSeq;
                    }

                }
            }
            // Noloca: 000

            return snew;
        }


        public static string Insert( string? s, params object[] obj)
        {
            StringBuilder snew = new();
            try
            {
                int ix = 0;

                // Noloca: 100
                while (ix < s!.Length)
                {
                    int ix2 = ix;
                    while (ix2 < s.Length && s[ix2] != '[')
                    {
                        ix2++;
                    }

                    snew.Append(s.Substring(ix, ix2 - ix));

                    ix = ix2;

                    if (ix2 < s.Length)
                    {
                        if (s[ix] == '[')
                        {
                            int lenSeq = 0;
                            Item? i = null;
                            Item? it = null;
                            Item? iapp = null;
                            Person? p = null;
                            Person? pt = null;
                            Person? plt = null;
                            Person? plv = null;
                            Person? pVP = null;
                            Person? rp = null;
                            Person? pr = null;
                            Person? papp = null;
                            Item? iVP = null;
                            Topic? t = null;
                            string? pString = null;
                            string? insertString = null;
                            int aocase = Co.CASE_AKK;
                            int verbID = -1;
                            int itemID = 0;
                            int personID = 0;
                            int locationID = 0;
                            int dirID = 0;

                            // string s4 = s.Substring(ix, 4);
                            // string s3 = s.Substring(ix, 3);
                            // Erst mal werden die location-Inserts eingef�gt, die vollst�ndig im String kodiert sind
                            // if ( s4.Equals( "[/I]") )
                            if (FindString(s, ix, "[/I]"))
                            {
                                lenSeq = 4;
                            }
                            else if (FindString(s, ix, "[/P]"))
                            {
                                lenSeq = 4;
                            }
                            else if (FindString(s, ix, "[/L]"))
                            {
                                lenSeq = 4;
                            }
                            // else if (s4.Equals(  "[/D]"))
                            else if (FindString(s, ix, "[/D]"))
                            {
                                lenSeq = 4;
                            }
                            else if ( FindString(s,ix, "[S1]"))
                            {
                                lenSeq = 4;
                                insertString = (string)obj[0];
                                snew.Append(insertString);
                            }
                            else if (FindString(s, ix, "[S2]"))
                            {
                                lenSeq = 4;
                                insertString = (string)obj[1];
                                snew.Append(insertString);
                            }
                            else if (FindString(s, ix, "[S3]"))
                            {
                                lenSeq = 4;
                                insertString = (string)obj[2];
                                snew.Append(insertString);
                            }
                            else if (FindString(s, ix, "[S4]"))
                            {
                                lenSeq = 4;
                                insertString = (string)obj[3];
                                snew.Append(insertString);
                            }
                            else if (FindString(s, ix, "[S5]"))
                            {
                                lenSeq = 4;
                                insertString = (string)obj[4];
                                snew.Append(insertString);
                            }
                            else if (FindString(s, ix, "[S6]"))
                            {
                                lenSeq = 4;
                                insertString = (string)obj[5];
                                snew.Append(insertString);
                            }
                            // else if ( s3.Equals( "[I:") )
                            else if (FindString(s, ix, "[I:"))
                            {
                                int pos = s.IndexOf(']', ix + 3);
                                // int pos = s.Substring(ix + 3).IndexOf(']');
                                if (pos != -1)
                                {
                                    pos -= ix + 3;
                                    string pString3 = s.Substring(ix + 3, pos);
                                    itemID = SearchItemID(pString3);
                                    // Link
                                    // sOut += itemID.ToString();

                                    ix += 4 + pos;

                                    int pos2 = s.Substring(ix).IndexOf('[');
                                    if (pos2 != -1)
                                    {
                                        string pString2 = s.Substring(ix, pos2);
                                        // snew.Append( "<Item:" + itemID.ToString("00000.##") + ">" + pString2 + "</Item>" );
                                        snew.Append("<Item:");
                                        snew.Append(itemID.ToString("00000.##"));
                                        snew.Append(">");
                                        snew.Append(pString2);
                                        snew.Append("</Item>");
                                        lenSeq = pos2;
                                        // ix += pos2;
                                    }
                                }
                                else
                                    lenSeq = 1;
                                //  ix += 1;
                            }
                            else if (FindString(s, ix, "[P:"))
                            {
                                int pos = s.IndexOf(']', ix + 3);
                                // int pos = s.Substring(ix + 3).IndexOf(']');
                                if (pos != -1)
                                {
                                    pos -= ix + 3;
                                    string pString3 = s.Substring(ix + 3, pos);
                                    personID = SearchPersonID(pString3);
                                    // Link
                                    // sOut += itemID.ToString();

                                    ix += 4 + pos;

                                    int pos2 = s.Substring(ix).IndexOf('[');
                                    if (pos2 != -1)
                                    {
                                        string pString2 = s.Substring(ix, pos2);
                                        // snew.Append( "<Item:" + itemID.ToString("00000.##") + ">" + pString2 + "</Item>" );
                                        snew.Append("<Person:");
                                        snew.Append(personID.ToString("00000.##"));
                                        snew.Append(">");
                                        snew.Append(pString2);
                                        snew.Append("</Person>");
                                        lenSeq = pos2;
                                        // ix += pos2;
                                    }
                                }
                                else
                                    lenSeq = 1;
                                //  ix += 1;
                            }
                            // else if ( s3.Equals( "[L:"))
                            else if (FindString(s, ix, "[L:"))
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
                                        // snew.Append( "<Loc:" + locationID.ToString("00000.##") + ">" + pString2 + "</Loc>" );
                                        snew.Append("<Loc:");
                                        snew.Append(locationID.ToString("00000.##"));
                                        snew.Append(">");
                                        snew.Append(pString2);
                                        snew.Append("</Loc>");
                                        lenSeq = pos2;
                                        // ix += pos2;
                                    }
                                }
                                else
                                    lenSeq = 1;
                                // ix += 1;
                            }
                            // else if ( s3.Equals( "[D:"))
                            else if (FindString(s, ix, "[D:"))
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
                                        // snew.Append( "<Dir:" + locationID.ToString("00000.##") + ">" + pString2 + "</Dir>" );
                                        snew.Append("<Dir:");
                                        snew.Append(locationID.ToString("00000.##"));
                                        snew.Append(">");
                                        snew.Append(pString2);
                                        snew.Append("</Dir>");
                                        lenSeq = pos2;
                                        // ix += pos2;
                                    }
                                }
                                else
                                    lenSeq = 1;
                            }
                            else if (FindString(s, ix, "[Dir:"))
                            {
                                int ixDir = s[ix + 5] - 49;
                                int idDir = (int)obj[ixDir];
                                snew.Append(_locations!.GetDirection(idDir));
                                lenSeq += 7;
                            }
                            else if (FindString(s, ix, "[Il1,"))
                            {
                                if (obj[0].GetType() == typeof(Item))
                                {
                                    i = (Item)obj[0];
                                }
                                else
                                {
                                    int id = (int)obj[0];
                                    i = (Item)_advGame!.Items!.Find(id)!;

                                }
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Il2,"))
                            {
                                if (obj[1].GetType() == typeof(Item))
                                {
                                    i = (Item)obj[1];
                                }
                                else
                                {
                                    int id = (int)obj[1];
                                    i = (Item)_advGame?.Items?.Find(id)!;

                                }
                                // int id = (int)obj[1];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Il3,"))
                            {
                                if (obj[2].GetType() == typeof(Item))
                                {
                                    i = (Item)obj[2];
                                }
                                else
                                {
                                    int id = (int)obj[2];
                                    i = (Item?)_advGame?.Items?.Find(id);

                                }
                                // int id = (int)obj[2];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Il4,"))
                            {
                                if (obj[3].GetType() == typeof(Item))
                                {
                                    i = (Item?)obj[3];
                                }
                                else
                                {
                                    int id = (int)obj[3];
                                    i = (Item?)_advGame?.Items?.Find(id);

                                }
                                // int id = (int)obj[3];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Il5,"))
                            {
                                if (obj[4].GetType() == typeof(Item))
                                {
                                    i = (Item)obj[4];
                                }
                                else
                                {
                                    int id = (int)obj[4];
                                    i = (Item?)_advGame?.Items?.Find(id);

                                }
                                // int id = (int)obj[4];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Il6,"))
                            {
                                if (obj[5].GetType() == typeof(Item))
                                {
                                    i = (Item)obj[5];
                                }
                                else
                                {
                                    int id = (int)obj[5];
                                    i = (Item?)_advGame?.Items?.Find(id);

                                }
                                // int id = (int)obj[5];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Ila1,"))
                            {
                                if (obj[0].GetType() == typeof(Item))
                                {
                                    iapp = (Item)obj[0];
                                }
                                else
                                {
                                    int id = (int)obj[0];
                                    iapp = (Item?)_advGame?.Items?.Find(id);

                                }
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Ila2,"))
                            {
                                if (obj[1].GetType() == typeof(Item))
                                {
                                    iapp = (Item?)obj[1];
                                }
                                else
                                {
                                    int id = (int)obj[1];
                                    iapp = (Item?)_advGame?.Items?.Find(id);

                                }
                                // int id = (int)obj[1];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Ila3,"))
                            {
                                if (obj[2].GetType() == typeof(Item))
                                {
                                    iapp = (Item?)obj[2];
                                }
                                else
                                {
                                    int id = (int)obj[2];
                                    iapp = (Item?)_advGame?.Items?.Find(id);

                                }
                                // int id = (int)obj[2];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Ila4,"))
                            {
                                if (obj[3].GetType() == typeof(Item))
                                {
                                    iapp = (Item?)obj[3];
                                }
                                else
                                {
                                    int id = (int)obj[3];
                                    iapp = (Item?)_advGame!.Items!.Find(id);

                                }
                                // int id = (int)obj[3];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Ila5,"))
                            {
                                if (obj[4].GetType() == typeof(Item))
                                {
                                    iapp = (Item?)obj[4];
                                }
                                else
                                {
                                    int id = (int)obj[4];
                                    iapp = (Item?)_advGame!.Items!.Find(id);

                                }
                                // int id = (int)obj[4];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Ila6,"))
                            {
                                if (obj[5].GetType() == typeof(Item))
                                {
                                    iapp = (Item?)obj[5];
                                }
                                else
                                {
                                    int id = (int)obj[5];
                                    iapp = (Item?)_advGame!.Items!.Find(id);

                                }
                                // int id = (int)obj[5];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Pla1,"))
                            {
                                if (obj[0].GetType() == typeof(Person))
                                {
                                    papp = (Person)obj[0];
                                }
                                else
                                {
                                    int id = (int)obj[0];
                                    papp = (Person?)_advGame?.Persons?.Find(id);

                                }
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Pla2,"))
                            {
                                if (obj[1].GetType() == typeof(Person))
                                {
                                    papp = (Person?)obj[1];
                                }
                                else
                                {
                                    int id = (int)obj[1];
                                    papp = (Person?)_advGame?.Persons?.Find(id);

                                }
                                // int id = (int)obj[1];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Pla3,"))
                            {
                                if (obj[2].GetType() == typeof(Person))
                                {
                                    papp = (Person?)obj[2];
                                }
                                else
                                {
                                    int id = (int)obj[2];
                                    papp = (Person?)_advGame?.Persons?.Find(id);

                                }
                                // int id = (int)obj[2];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Pla4,"))
                            {
                                if (obj[3].GetType() == typeof(Person))
                                {
                                    papp = (Person?)obj[3];
                                }
                                else
                                {
                                    int id = (int)obj[3];
                                    papp = (Person?)_advGame!.Persons!.Find(id);

                                }
                                // int id = (int)obj[3];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Pla5,"))
                            {
                                if (obj[4].GetType() == typeof(Person))
                                {
                                    papp = (Person?)obj[4];
                                }
                                else
                                {
                                    int id = (int)obj[4];
                                    papp = (Person?)_advGame!.Persons!.Find(id);

                                }
                                // int id = (int)obj[4];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Pla6,"))
                            {
                                if (obj[5].GetType() == typeof(Person))
                                {
                                    papp = (Person?)obj[5];
                                }
                                else
                                {
                                    int id = (int)obj[5];
                                    papp = (Person?)_advGame!.Persons!.Find(id);

                                }
                                // int id = (int)obj[5];
                                // i = (Item)_advGame!.Items!.Find(id);
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[It1,"))
                            {
                                it = (Item?)_items!.Find((int)obj[0]);
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[It2,"))
                            {
                                it = (Item?)_items!.Find((int)obj[1]);
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[It3,"))
                            {
                                it = (Item?)_items!.Find((int)obj[2]);
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[It4,"))
                            {
                                it = (Item?)_items!.Find((int)obj[3]);
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[It5,"))
                            {
                                it = (Item?)_items!.Find((int)obj[4]);
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[It6,"))
                            {
                                it = (Item?)_items!.Find((int)obj[5]);
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Pl1,\""))
                            {
                                p = (Person)obj[0];
                                int pos = s.Substring(ix + 6).IndexOf("\"]");
                                if (pos != -1)
                                    pString = s.Substring(ix + 6, pos);
                                lenSeq += 6 + pString!.Length + 2;
                            }
                            else if (FindString(s, ix, "[Pl2,\""))
                            {
                                p = (Person)obj[1];
                                int pos = s.Substring(ix + 6).IndexOf("\"]");
                                if (pos != -1)
                                    pString = s.Substring(ix + 6, pos);
                                lenSeq += 6 + pString!.Length + 2;
                            }
                            else if (FindString(s, ix, "[Pl3,\""))
                            {
                                p = (Person)obj[2];
                                int pos = s.Substring(ix + 6).IndexOf("\"]");
                                if (pos != -1)
                                    pString = s.Substring(ix + 6, pos);
                                lenSeq += 6 + pString!.Length + 2;
                            }
                            else if (FindString(s, ix, "[Pl4,\""))
                            {
                                p = (Person)obj[3];
                                int pos = s.Substring(ix + 6).IndexOf("\"]");
                                if (pos != -1)
                                    pString = s.Substring(ix + 6, pos);
                                lenSeq += 6 + pString!.Length + 2;
                            }
                            else if (FindString(s, ix, "[Pl5,\""))
                            {
                                p = (Person)obj[4];
                                int pos = s.Substring(ix + 6).IndexOf("\"]");
                                if (pos != -1)
                                    pString = s.Substring(ix + 6, pos);
                                lenSeq += 6 + pString!.Length + 2;
                            }
                            else if (FindString(s, ix, "[Pl6,\""))
                            {
                                p = (Person)obj[5];
                                int pos = s.Substring(ix + 6).IndexOf("\"]");
                                if (pos != -1)
                                    pString = s.Substring(ix + 6, pos);
                                lenSeq += 6 + pString!.Length + 2;
                            }
                            else if (FindString(s, ix, "[Ps"))
                            {
                                int ixPers = s[ix + 3] - 48;
                                int ixString = s[ix + 5] - 48;

                                p = (Person)obj[ixPers - 1];
                                pString = (string)obj[ixString - 1];
                                lenSeq += "[Ps1,2]".Length;
                            }
                            else if (FindString(s, ix, "[Pl1,"))
                            {
                                pt = (Person)obj[0];
                                lenSeq += "[Pl1,".Length;
                            }
                            else if (FindString(s, ix, "[Pl2,"))
                            {
                                pt = (Person)obj[1];
                                lenSeq += "[Pl2,".Length;
                            }
                            else if (FindString(s, ix, "[Pl3,"))
                            {
                                pt = (Person)obj[2];
                                lenSeq += "[Pl3,".Length;
                            }
                            else if (FindString(s, ix, "[Pl4,"))
                            {
                                pt = (Person)obj[3];
                                lenSeq += "[Pl4,".Length;
                            }
                            else if (FindString(s, ix, "[Pl5,"))
                            {
                                pt = (Person)obj[4];
                                lenSeq += "[Pl5,".Length;
                            }
                            else if (FindString(s, ix, "[Pl6,"))
                            {
                                pt = (Person)obj[5];
                                lenSeq += "[Pl6,".Length;
                            }
                            else if (FindString(s, ix, "[Pt1,"))
                            {
                                pt = (Person)obj[0];
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Pt2,"))
                            {
                                pt = (Person)obj[1];
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Pt3,"))
                            {
                                pt = (Person)obj[2];
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Pt4,"))
                            {
                                pt = (Person)obj[3];
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Pt5,"))
                            {
                                pt = (Person)obj[4];
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Pt6,"))
                            {
                                pt = (Person)obj[5];
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix, "[Plt1,"))
                            {
                                plt = (Person)obj[0];
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Plt2,"))
                            {
                                plt = (Person)obj[1];
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Plt3,"))
                            {
                                pt = (Person)obj[2];
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Plt4,"))
                            {
                                pt = (Person)obj[3];
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Plt5,"))
                            {
                                pt = (Person)obj[4];
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[Plt6,"))
                            {
                                pt = (Person)obj[5];
                                lenSeq += 6;
                            }
                            else if (FindString(s, ix, "[VP:"))
                            {
                                int pos = s.Substring(ix + "[VP:".Length).IndexOf(',');
                                if (pos != -1)
                                {
                                    pString = s.Substring(ix + "[VP:".Length, pos);
                                    verbID = SearchVT(pString);
                                    lenSeq += "[VP:".Length + pString.Length + 1;

                                }
                                int ixObj = s[ix + lenSeq] - 48;
                                if (ixObj > 0 && ixObj < 10)
                                {
                                    if (obj[ixObj - 1].GetType() == typeof(Person))
                                    {
                                        pVP = (Person)obj[ixObj - 1];
                                        snew.Append(Grammar.GetVerbDeclination(verbID, pVP, _a!.Tense));
                                    }
                                    else if (obj[ixObj - 1].GetType() == typeof(Item))
                                    {
                                        iVP = (Item)obj[ixObj - 1];
                                        snew.Append(Grammar.GetVerbDeclinationFromItem(verbID, iVP.ID, _a!.Tense));

                                    }

                                }
                                lenSeq += 2;
                            }
                            else if (FindString(s, ix, "[VI:"))
                            {
                                int pos = s.Substring(ix + "[VI:".Length).IndexOf(',');
                                if (pos != -1)
                                {
                                    pString = s.Substring(ix + "[VI:".Length, pos);
                                    verbID = SearchVT(pString);
                                    lenSeq += "[VI:".Length + pString.Length + 1;

                                }
                                int ixObj = s[ix + lenSeq] - 48;
                                if (ixObj > 0 && ixObj < 10)
                                {
                                    iVP = (Item)_items!.Find((int)obj[ixObj - 1])!;
                                    snew.Append(Grammar.GetVerbDeclinationFromItem(verbID, iVP.ID, _a!.Tense));

                                }
                                lenSeq += 2;
                            }
                            else if (FindString(s, ix, "[RP:"))
                            {
                                int ixPerson = s[ix + 4] - 48;
                                rp = (Person)obj[ixPerson - 1];
                                lenSeq = "[RP:1,".Length;
                            }
                            else if (FindString(s, ix, "[Pr:"))
                            {
                                int ixPerson = s[ix + 4] - 48;
                                pr = (Person)obj[ixPerson - 1];
                                lenSeq = "[Pr:1,".Length;
                            }
                            else if (FindString(s, ix, "[VP1,")
                                            || FindString(s, ix, "[VP2,")
                                            || FindString(s, ix, "[VP3,")
                                            || FindString(s, ix, "[VP4,")
                                            || FindString(s, ix, "[VP5,")
                                            || FindString(s, ix, "[VP6,")
                                        )
                            {
                                int ixPerson = s[ix + 3] - 48;
                                pVP = (Person)obj[ixPerson - 1];

                                int ixVerb = s[ix + 5] - 48;
                                if (ixVerb > 0 && ixVerb < 10)
                                {
                                    verbID = (int)obj[ixVerb - 1];
                                    snew.Append(Grammar.GetVerbDeclination(verbID, pVP, _a!.Tense));
                                }
                                lenSeq = "[VP1,1]".Length;
                            }
                            else if (FindString(s, ix, "[Top"))
                            {
                                int ixTopic = s[ix + 4] - 48;
                                t = (Topic)_topics!.Find((int)obj[ixTopic - 1])!;

                                lenSeq = "[Top1,".Length;
                            }
                            else if (FindString(s, ix, "[Plv1,"))
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
                            else if (FindString(s, ix, "[Plv2,"))
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
                            else if (FindString(s, ix, "[Plv3,"))
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
                            else if (FindString(s, ix, "[Plv4,"))
                            {
                                plv = (Person)obj[3];
                                int pos = s.Substring(ix + 6).IndexOf(',');
                                if (pos != -1)
                                {
                                    pString = s.Substring(ix + 6, pos);
                                    verbID = SearchVT(pString);
                                    lenSeq += 6 + pString.Length + 1;
                                }
                            }
                            else if (FindString(s, ix, "[Plv5,"))
                            {
                                plv = (Person)obj[4];
                                int pos = s.Substring(ix + 6).IndexOf(',');
                                if (pos != -1)
                                {
                                    pString = s.Substring(ix + 6, pos);
                                    verbID = SearchVT(pString);
                                    lenSeq += 6 + pString.Length + 1;
                                }
                            }
                            else if (FindString(s, ix, "[Plv6,"))
                            {
                                plv = (Person)obj[5];
                                int pos = s.Substring(ix + 6).IndexOf(',');
                                if (pos != -1)
                                {
                                    pString = s.Substring(ix + 6, pos);
                                    verbID = SearchVT(pString);
                                    lenSeq += 6 + pString.Length + 1;
                                }
                            }

                            if (FindString(s, ix + lenSeq, "Akk]"))
                            {

                                aocase = Co.CASE_AKK;
                                lenSeq += 4;
                            }
                            else if (FindString(s, ix + lenSeq, "Nom]"))
                            {

                                aocase = Co.CASE_NOM;
                                lenSeq += 4;
                            }
                            else if (FindString(s, ix + lenSeq, "Dat]"))
                            {

                                aocase = Co.CASE_DAT;
                                lenSeq += 4;
                            }
                            else if (FindString(s, ix + lenSeq, "Akku]"))
                            {

                                aocase = Co.CASE_AKK_UNDEF;
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix + lenSeq, "Nomu]"))
                            {

                                aocase = Co.CASE_NOM_UNDEF;
                                lenSeq += 5;
                            }
                            else if (FindString(s, ix + lenSeq, "Datu]"))
                            {

                                aocase = Co.CASE_DAT_UNDEF;
                                lenSeq += 5;
                            }

                            if (i != null)
                            {
                                snew.Append(_items!.GetItemNameLink(i.ID, aocase, null ));
                            }
                            else if (iapp != null)
                            {
                                snew.Append(_items!.GetItemNameLink(iapp.ID, aocase, _a!.Adventure!.CurrentNouns, true));
                            }
                            else if (it != null)
                            {
                                snew.Append(_items!.GetName(it.ID, aocase, _a!.Adventure!.CurrentNouns ));
                            }
                            else if (p != null)
                            {
                                snew.Append(_persons!.GetPersonLink(p, _a!.Adventure!.CurrentNouns!, pString));
                            }
                            else if (pt != null)
                            {
                                snew.Append(_persons!.GetPersonName(pt, aocase, _a!.Adventure!.CurrentNouns!));
                            }
                            else if (plt != null)
                            {
                                snew.Append(_persons!.GetPersonNameLink(plt, aocase, _a.Adventure.CurrentNouns));
                            }
                            else if (plv != null)
                            {
                                snew.Append(_persons!.GetPersonVerbLink(plv, aocase, verbID, null, _a!.Tense));
                            }
                            else if (papp != null)
                            {
                                snew.Append(_persons!.GetPersonNameLink(papp, aocase, _a.Adventure.CurrentNouns));
                            }
                            else if (rp != null)
                            {
                                snew.Append(Grammar.GetReflexivePronoun(rp, aocase));
                            }
                            else if (pr != null)
                            {
                                snew.Append(Grammar.GetPronoun(pr));
                            }
                            else if (t != null)
                            {
                                snew.Append(_topics!.GetTopicName(t.ID, aocase, _a.Adventure.CurrentNouns));
                            }

                            if (lenSeq == 0)
                                lenSeq = 1;
                            ix += lenSeq;
                        }

                    }
                }
            }
            catch (Exception e)
            {

            }
            // Noloca: 000

            return snew.ToString();
        }


        public static string InsertNonequals(string? s, params object[] obj)
        {
            StringBuilder snew = new();
            int ix = 0;

            // Noloca: 100
            while (ix < s!.Length)
            {
                int ix2 = ix;
                while (ix2 < s.Length && s[ix2] != '[')
                {
                    ix2++;
                }

                snew.Append(s.Substring(ix, ix2 - ix));

                ix = ix2;

                if (ix2 < s.Length)
                {
                    if (s[ix] == '[')
                    {
                        int lenSeq = 0;
                        Item? i = null;
                        Item? it = null;
                        Item? iapp = null;
                        Person? p = null;
                        Person? pt = null;
                        Person? plt = null;
                        Person? plv = null;
                        Person? pVP = null;
                        Person? rp = null;
                        Person? pr = null;
                        Item? iVP = null;
                        Topic? t = null;
                        string? pString = null;
                        int aocase = Co.CASE_AKK;
                        int verbID = -1;
                        int itemID = 0;
                        int locationID = 0;
                        int dirID = 0;

                        string s4 = s.Substring(ix, 4);
                        string s3 = s.Substring(ix, 3);
                        // Erst mal werden die location-Inserts eingef�gt, die vollst�ndig im String kodiert sind
                        if (s4 == "[/I]")
                        {
                            lenSeq = 4;
                        }
                        else if (s4 == "[/P]")
                        {
                            lenSeq = 4;
                        }
                        else if (s4 == "[/L]")
                        {
                            lenSeq = 4;
                        }
                        else if (s4 == "[/D]")
                        {
                            lenSeq = 4;
                        }
                        else if (s3 == "[I:")
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
                                    // snew.Append( "<Item:" + itemID.ToString("00000.##") + ">" + pString2 + "</Item>" );
                                    snew.Append("<Item:");
                                    snew.Append(itemID.ToString("00000.##"));
                                    snew.Append(">");
                                    snew.Append(pString2);
                                    snew.Append("</Item>");
                                    lenSeq = pos2;
                                    // ix += pos2;
                                }
                            }
                            else
                                lenSeq = 1;
                            //  ix += 1;
                        }
                        else if (s3 == "[L:")
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
                                    // snew.Append( "<Loc:" + locationID.ToString("00000.##") + ">" + pString2 + "</Loc>" );
                                    snew.Append("<Loc:");
                                    snew.Append(locationID.ToString("00000.##"));
                                    snew.Append(">");
                                    snew.Append(pString2);
                                    snew.Append("</Loc>");
                                    lenSeq = pos2;
                                    // ix += pos2;
                                }
                            }
                            else
                                lenSeq = 1;
                            // ix += 1;
                        }
                        else if (s3 == "[D:")
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
                                    // snew.Append( "<Dir:" + locationID.ToString("00000.##") + ">" + pString2 + "</Dir>" );
                                    snew.Append("<Dir:");
                                    snew.Append(locationID.ToString("00000.##"));
                                    snew.Append(">");
                                    snew.Append(pString2);
                                    snew.Append("</Dir>");
                                    lenSeq = pos2;
                                    // ix += pos2;
                                }
                            }
                            else
                                lenSeq = 1;
                        }
                        else if (FindString(s, ix, "[Dir:"))
                        {
                            int ixDir = s[ix + 5] - 49;
                            int idDir = (int)obj[ixDir];
                            snew.Append(_locations!.GetDirection(idDir));
                            lenSeq += 7;
                        }
                        else if (FindString(s, ix, "[Il1,"))
                        {
                            if (obj[0].GetType() == typeof(Item))
                            {
                                i = (Item)obj[0];
                            }
                            else
                            {
                                int id = (int)obj[0];
                                i = (Item)_advGame!.Items!.Find(id)!;

                            }
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Il2,"))
                        {
                            if (obj[1].GetType() == typeof(Item))
                            {
                                i = (Item)obj[1];
                            }
                            else
                            {
                                int id = (int)obj[1];
                                i = (Item)_advGame?.Items?.Find(id)!;

                            }
                            // int id = (int)obj[1];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Il3,"))
                        {
                            if (obj[2].GetType() == typeof(Item))
                            {
                                i = (Item)obj[2];
                            }
                            else
                            {
                                int id = (int)obj[2];
                                i = (Item?)_advGame?.Items?.Find(id);

                            }
                            // int id = (int)obj[2];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Il4,"))
                        {
                            if (obj[3].GetType() == typeof(Item))
                            {
                                i = (Item?)obj[3];
                            }
                            else
                            {
                                int id = (int)obj[3];
                                i = (Item?)_advGame?.Items?.Find(id);

                            }
                            // int id = (int)obj[3];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Il5,"))
                        {
                            if (obj[4].GetType() == typeof(Item))
                            {
                                i = (Item)obj[4];
                            }
                            else
                            {
                                int id = (int)obj[4];
                                i = (Item?)_advGame?.Items?.Find(id);

                            }
                            // int id = (int)obj[4];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Il6,"))
                        {
                            if (obj[5].GetType() == typeof(Item))
                            {
                                i = (Item)obj[5];
                            }
                            else
                            {
                                int id = (int)obj[5];
                                i = (Item?)_advGame?.Items?.Find(id);

                            }
                            // int id = (int)obj[5];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Ila1,"))
                        {
                            if (obj[0].GetType() == typeof(Item))
                            {
                                iapp = (Item)obj[0];
                            }
                            else
                            {
                                int id = (int)obj[0];
                                iapp = (Item?)_advGame?.Items?.Find(id);

                            }
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Ila2,"))
                        {
                            if (obj[1].GetType() == typeof(Item))
                            {
                                iapp = (Item?)obj[1];
                            }
                            else
                            {
                                int id = (int)obj[1];
                                iapp = (Item?)_advGame?.Items?.Find(id);

                            }
                            // int id = (int)obj[1];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Ila3,"))
                        {
                            if (obj[2].GetType() == typeof(Item))
                            {
                                iapp = (Item?)obj[2];
                            }
                            else
                            {
                                int id = (int)obj[2];
                                iapp = (Item?)_advGame?.Items?.Find(id);

                            }
                            // int id = (int)obj[2];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Ila4,"))
                        {
                            if (obj[3].GetType() == typeof(Item))
                            {
                                iapp = (Item?)obj[3];
                            }
                            else
                            {
                                int id = (int)obj[3];
                                iapp = (Item?)_advGame!.Items!.Find(id);

                            }
                            // int id = (int)obj[3];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Ila5,"))
                        {
                            if (obj[4].GetType() == typeof(Item))
                            {
                                iapp = (Item?)obj[4];
                            }
                            else
                            {
                                int id = (int)obj[4];
                                iapp = (Item?)_advGame!.Items!.Find(id);

                            }
                            // int id = (int)obj[4];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Ila6,"))
                        {
                            if (obj[5].GetType() == typeof(Item))
                            {
                                iapp = (Item?)obj[5];
                            }
                            else
                            {
                                int id = (int)obj[5];
                                iapp = (Item?)_advGame!.Items!.Find(id);

                            }
                            // int id = (int)obj[5];
                            // i = (Item)_advGame!.Items!.Find(id);
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[It1,"))
                        {
                            it = (Item?)_items!.Find((int)obj[0]);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[It2,"))
                        {
                            it = (Item?)_items!.Find((int)obj[1]);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[It3,"))
                        {
                            it = (Item?)_items!.Find((int)obj[2]);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[It4,"))
                        {
                            it = (Item?)_items!.Find((int)obj[3]);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[It5,"))
                        {
                            it = (Item?)_items!.Find((int)obj[4]);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[It6,"))
                        {
                            it = (Item?)_items!.Find((int)obj[5]);
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Pl1,\""))
                        {
                            p = (Person)obj[0];
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += 6 + pString!.Length + 2;
                        }
                        else if (FindString(s, ix, "[Pl2,\""))
                        {
                            p = (Person)obj[1];
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += 6 + pString!.Length + 2;
                        }
                        else if (FindString(s, ix, "[Pl3,\""))
                        {
                            p = (Person)obj[2];
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += 6 + pString!.Length + 2;
                        }
                        else if (FindString(s, ix, "[Pl4,\""))
                        {
                            p = (Person)obj[3];
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += 6 + pString!.Length + 2;
                        }
                        else if (FindString(s, ix, "[Pl5,\""))
                        {
                            p = (Person)obj[4];
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += 6 + pString!.Length + 2;
                        }
                        else if (FindString(s, ix, "[Pl6,\""))
                        {
                            p = (Person)obj[5];
                            int pos = s.Substring(ix + 6).IndexOf("\"]");
                            if (pos != -1)
                                pString = s.Substring(ix + 6, pos);
                            lenSeq += 6 + pString!.Length + 2;
                        }
                        else if (FindString(s, ix, "[Ps"))
                        {
                            int ixPers = s[ix + 3] - 48;
                            int ixString = s[ix + 5] - 48;

                            p = (Person)obj[ixPers - 1];
                            pString = (string)obj[ixString - 1];
                            lenSeq += "[Ps1,2]".Length;
                        }
                        else if (FindString(s, ix, "[Pl1,"))
                        {
                            pt = (Person)obj[0];
                            lenSeq += "[Pl1,".Length;
                        }
                        else if (FindString(s, ix, "[Pl2,"))
                        {
                            pt = (Person)obj[1];
                            lenSeq += "[Pl2,".Length;
                        }
                        else if (FindString(s, ix, "[Pl3,"))
                        {
                            pt = (Person)obj[2];
                            lenSeq += "[Pl3,".Length;
                        }
                        else if (FindString(s, ix, "[Pl4,"))
                        {
                            pt = (Person)obj[3];
                            lenSeq += "[Pl4,".Length;
                        }
                        else if (FindString(s, ix, "[Pl5,"))
                        {
                            pt = (Person)obj[4];
                            lenSeq += "[Pl5,".Length;
                        }
                        else if (FindString(s, ix, "[Pl6,"))
                        {
                            pt = (Person)obj[5];
                            lenSeq += "[Pl6,".Length;
                        }
                        else if (FindString(s, ix, "[Pt1,"))
                        {
                            pt = (Person)obj[0];
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Pt2,"))
                        {
                            pt = (Person)obj[1];
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Pt3,"))
                        {
                            pt = (Person)obj[2];
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Pt4,"))
                        {
                            pt = (Person)obj[3];
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Pt5,"))
                        {
                            pt = (Person)obj[4];
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Pt6,"))
                        {
                            pt = (Person)obj[5];
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix, "[Plt1,"))
                        {
                            plt = (Person)obj[0];
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Plt2,"))
                        {
                            plt = (Person)obj[1];
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Plt3,"))
                        {
                            pt = (Person)obj[2];
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Plt4,"))
                        {
                            pt = (Person)obj[3];
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Plt5,"))
                        {
                            pt = (Person)obj[4];
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[Plt6,"))
                        {
                            pt = (Person)obj[5];
                            lenSeq += 6;
                        }
                        else if (FindString(s, ix, "[VP:"))
                        {
                            int pos = s.Substring(ix + "[VP:".Length).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + "[VP:".Length, pos);
                                verbID = SearchVT(pString);
                                lenSeq += "[VP:".Length + pString.Length + 1;

                            }
                            int ixObj = s[ix + lenSeq] - 48;
                            if (ixObj > 0 && ixObj < 10)
                            {
                                if (obj[ixObj - 1].GetType() == typeof(Person))
                                {
                                    pVP = (Person)obj[ixObj - 1];
                                    snew.Append(Grammar.GetVerbDeclination(verbID, pVP, _a!.Tense));
                                }
                                else if (obj[ixObj - 1].GetType() == typeof(Item))
                                {
                                    iVP = (Item)obj[ixObj - 1];
                                    snew.Append(Grammar.GetVerbDeclinationFromItem(verbID, iVP.ID, _a!.Tense));

                                }

                            }
                            lenSeq += 2;
                        }
                        else if (FindString(s, ix, "[VI:"))
                        {
                            int pos = s.Substring(ix + "[VI:".Length).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + "[VI:".Length, pos);
                                verbID = SearchVT(pString);
                                lenSeq += "[VI:".Length + pString.Length + 1;

                            }
                            int ixObj = s[ix + lenSeq] - 48;
                            if (ixObj > 0 && ixObj < 10)
                            {
                                iVP = (Item)_items!.Find((int)obj[ixObj - 1])!;
                                snew.Append(Grammar.GetVerbDeclinationFromItem(verbID, iVP.ID, _a!.Tense));

                            }
                            lenSeq += 2;
                        }
                        else if (FindString(s, ix, "[RP:"))
                        {
                            int ixPerson = s[ix + 4] - 48;
                            rp = (Person)obj[ixPerson - 1];
                            lenSeq = "[RP:1,".Length;
                        }
                        else if (FindString(s, ix, "[Pr:"))
                        {
                            int ixPerson = s[ix + 4] - 48;
                            pr = (Person)obj[ixPerson - 1];
                            lenSeq = "[Pr:1,".Length;
                        }
                        else if (FindString(s, ix, "[VP1,")
                                        || FindString(s, ix, "[VP2,")
                                        || FindString(s, ix, "[VP3,")
                                        || FindString(s, ix, "[VP4,")
                                        || FindString(s, ix, "[VP5,")
                                        || FindString(s, ix, "[VP6,")
                                    )
                        {
                            int ixPerson = s[ix + 3] - 48;
                            pVP = (Person)obj[ixPerson - 1];

                            int ixVerb = s[ix + 5] - 48;
                            if (ixVerb > 0 && ixVerb < 10)
                            {
                                verbID = (int)obj[ixVerb - 1];
                                snew.Append(Grammar.GetVerbDeclination(verbID, pVP, _a!.Tense));
                            }
                            lenSeq = "[VP1,1]".Length;
                        }
                        else if (FindString(s, ix, "[Top"))
                        {
                            int ixTopic = s[ix + 4] - 48;
                            t = (Topic)_topics!.Find((int)obj[ixTopic - 1])!;

                            lenSeq = "[Top1,".Length;
                        }
                        else if (FindString(s, ix, "[Plv1,"))
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
                        else if (FindString(s, ix, "[Plv2,"))
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
                        else if (FindString(s, ix, "[Plv3,"))
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
                        else if (FindString(s, ix, "[Plv4,"))
                        {
                            plv = (Person)obj[3];
                            int pos = s.Substring(ix + 6).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + 6, pos);
                                verbID = SearchVT(pString);
                                lenSeq += 6 + pString.Length + 1;
                            }
                        }
                        else if (FindString(s, ix, "[Plv5,"))
                        {
                            plv = (Person)obj[4];
                            int pos = s.Substring(ix + 6).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + 6, pos);
                                verbID = SearchVT(pString);
                                lenSeq += 6 + pString.Length + 1;
                            }
                        }
                        else if (FindString(s, ix, "[Plv6,"))
                        {
                            plv = (Person)obj[5];
                            int pos = s.Substring(ix + 6).IndexOf(',');
                            if (pos != -1)
                            {
                                pString = s.Substring(ix + 6, pos);
                                verbID = SearchVT(pString);
                                lenSeq += 6 + pString.Length + 1;
                            }
                        }

                        if (FindString(s, ix + lenSeq, "Akk]"))
                        {

                            aocase = Co.CASE_AKK;
                            lenSeq += 4;
                        }
                        else if (FindString(s, ix + lenSeq, "Nom]"))
                        {

                            aocase = Co.CASE_NOM;
                            lenSeq += 4;
                        }
                        else if (FindString(s, ix + lenSeq, "Dat]"))
                        {

                            aocase = Co.CASE_DAT;
                            lenSeq += 4;
                        }
                        else if (FindString(s, ix + lenSeq, "Akku]"))
                        {

                            aocase = Co.CASE_AKK_UNDEF;
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix + lenSeq, "Nomu]"))
                        {

                            aocase = Co.CASE_NOM_UNDEF;
                            lenSeq += 5;
                        }
                        else if (FindString(s, ix + lenSeq, "Datu]"))
                        {

                            aocase = Co.CASE_DAT_UNDEF;
                            lenSeq += 5;
                        }

                        if (i != null)
                        {
                            snew.Append(_items!.GetItemNameLink(i.ID, aocase, _a.Adventure.CurrentNouns));
                        }
                        else if (iapp != null)
                        {
                            snew.Append(_items!.GetItemNameLink(iapp.ID, aocase, _a.Adventure.CurrentNouns, true));
                        }
                        else if (it != null)
                        {
                            snew.Append(_items!.GetName(it.ID, aocase, _a.Adventure.CurrentNouns));
                        }
                        else if (p != null)
                        {
                            snew.Append(_persons!.GetPersonLink(p, _a.Adventure.CurrentNouns, pString));
                        }
                        else if (pt != null)
                        {
                            snew.Append(_persons!.GetPersonName(pt, aocase, _a.Adventure.CurrentNouns));
                        }
                        else if (plt != null)
                        {
                            snew.Append(_persons!.GetPersonNameLink(plt, aocase, _a.Adventure.CurrentNouns));
                        }
                        else if (plv != null)
                        {
                            snew.Append(_persons!.GetPersonVerbLink(plv, aocase, verbID, _a.Adventure.CurrentNouns, _a!.Tense));
                        }
                        else if (rp != null)
                        {
                            snew.Append(Grammar.GetReflexivePronoun(rp, aocase));
                        }
                        else if (pr != null)
                        {
                            snew.Append(Grammar.GetPronoun(pr));
                        }
                        else if (t != null)
                        {
                            snew.Append(_topics!.GetTopicName(t.ID, aocase, _a.Adventure.CurrentNouns));
                        }

                        if (lenSeq == 0)
                            lenSeq = 1;
                        ix += lenSeq;
                    }

                }
            }
            // Noloca: 000

            return snew.ToString();
        }

        static int SearchVT(string s)
        {
            // Ignores: 001
            // Noloca: 001
            s = "VT_" +s;
            System.Reflection.PropertyInfo? pi = typeof(CoBase).GetProperty(s, BindingFlags.Public | BindingFlags.Instance);

            object o = pi?.GetValue(_cb, null)!;

            return (int)o!;
        }
        static int SearchItemID(string s)
        {
            try
            {
                // s = "VT_" + s;
                // Noloca: 001
                System.Reflection.PropertyInfo? pi = typeof(CoAdv).GetProperty(s, BindingFlags.Public | BindingFlags.Instance);

                object o = pi!.GetValue(_advGame!.CA!, null)!;

                return ((o as Item)!.ID)!;
            }
            catch( Exception e)
            {
                GlobalData.AddLog("SearchItemID: " + s, Phoney_MAUI.Model.IGlobalData.protMode.crisp);

            }
            return 0;
        }
        static int SearchPersonID(string s)
        {
            try
            {
                // s = "VT_" + s;
                // Noloca: 001
                System.Reflection.PropertyInfo? pi = typeof(CoAdv).GetProperty(s, BindingFlags.Public | BindingFlags.Instance);

                object o = pi!.GetValue(_advGame!.CA!, null)!;

                return ((o as Person)!.ID)!;

            }
            catch (Exception e)
            {
                GlobalData.AddLog("SearchItemID: " + s, Phoney_MAUI.Model.IGlobalData.protMode.crisp);

            }
            return 0;
        }
        static int SearchlocationID(string s)
        {
            // s = "VT_" + s;
            // Noloca: 001
            System.Reflection.PropertyInfo? pi = typeof(CoAdv).GetProperty(s, BindingFlags.Public | BindingFlags.Instance);

            object o = pi!.GetValue(_advGame!.CA!, null)!;

            return (int)o!;

        }
        static int SearchDir(string s)
        {
            Type type = typeof(Co);

            PropertyInfo[] propertyInfos;
            propertyInfos = typeof(Co).GetProperties(BindingFlags.Public |
                                                          BindingFlags.Static);

            FieldInfo[] fields = typeof(Co).GetFields();      //obtain all fields
                                                        // s = "VT_" + s;
            System.Reflection.FieldInfo? fi = type.GetField(s, BindingFlags.Public | BindingFlags.Static );

            object o = fi!.GetValue(null)!;

            return (int)o!;

        }
    }
}
