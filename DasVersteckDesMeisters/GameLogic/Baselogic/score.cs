using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;

namespace GameCore
{

    public enum spoiler { nospoiler, info, tipp, spoiler, solution }

    public enum scoreVal { nothing = 0, easy = 10, simple = 20, mediocre = 30, advanced = 40, complex = 50, mindblowing = 80 }

    public enum scoreChapter { no_chapter = 0, chapter_one, chapter_two, chapter_three, chapter_four }
    [Serializable]

    public class Score
    {

        public int ID { get; set; }

        public int Val { get; set; }

        public bool Active 
        {   get; 
            set; 
        }

        public spoiler SpoilerState { get;  internal set; }

        public scoreChapter Chapter { get;  internal set; }
        private string? _comment;
        public string? LocaComment { get; set; }

        public string? Comment 
        {
            get
            {
                return loca.TextOrLoca(_comment, LocaComment) as string;
            }
            /*
            set
            {
                _comment = value;
            }
            */
        }
        // private string? _eventName;
        public string? LocaEventName{ get; set; }

        public string? EventNameComment
        {
            get
            {

                // return loca.TextOrLocaInsert(_eventName, LocaEventName) as string;
                return loca.TextOrLoca(null, LocaEventName) as string;
            }
            set
            {
                _comment = value;
            }
        }


        public int InqScore()
        {
            /*
            int score = Val;
            if (SpoilerState == spoiler.solution) 
                score = (Val * 25) / 100;
            else if (SpoilerState == spoiler.spoiler) 
                score = (Val * 50) / 100;
            else if (SpoilerState == spoiler.tipp) 
                score = (Val * 75) / 100;
            else score = Val;
            */
            int score = Val;

            return score;
        }
        [JsonConstructor]

         public Score(int ID, int val, string? locaEventname, scoreChapter c = scoreChapter.no_chapter, string? comment = null)
        {
            this.ID = ID;
            this.Val = val;
            this.LocaComment = comment;
            this.LocaEventName = locaEventname;
            this.Chapter = c;
        }

        public Score(int ID, int val, string? comment = null)
        {
            this.ID = ID;
            this.Val = val;
            this.LocaComment = comment;
            this.Chapter = scoreChapter.no_chapter;
        }
        public Score(int ID, int val,  scoreChapter c = scoreChapter.no_chapter, string? comment = null)
        {
            this.ID = ID;
            this.Val = val;
            this.LocaEventName = null;
            this.LocaComment = comment;
            this.Chapter = c;
        }

        public Score(int ID, int val, string? LocaEventname, string? comment = null)
        {
            this.ID = ID;
            this.Val = val;
            this.LocaEventName = LocaEventName;
            this.LocaComment = comment;
            this.Chapter = scoreChapter.no_chapter;
        }


        public Score(int val ) : this(SerialNumberGenerator.Instance.NextSerial, val, scoreChapter.no_chapter, null)
        {

        }

        public Score( int val, string? comment ) : this(SerialNumberGenerator.Instance.NextSerial, val, scoreChapter.no_chapter, comment)
        {

        }
        public Score(int val, string? LocaEventName, string? comment) : this(SerialNumberGenerator.Instance.NextSerial, val, LocaEventName, scoreChapter.no_chapter, comment)
        {

        }

        public Score(int val, string? LocaEventname, scoreChapter c, string? comment = null) : this(SerialNumberGenerator.Instance.NextSerial, val, LocaEventname, c, comment)
        {

        }

        public Score(int val, scoreChapter c = scoreChapter.no_chapter) : this(SerialNumberGenerator.Instance.NextSerial, val, c, null )
        {

        }

        public void IncSpoilerState(spoiler spoilerState)
        {
            if (spoilerState > this.SpoilerState && !Active)
                this.SpoilerState = spoilerState;
        }
    }

    [Serializable]

    public class ScoreList
    {

        public List<Score>? Scores { get; set; }


        public ScoreList()
        {
            Scores = new List<Score>();
        }
        ~ScoreList()
        {
            Scores = null;
        }


        public Score? Find(int id)
        {
            Score? found = null;

            foreach( Score s in Scores!)
            {
                if( s.ID == id)
                {
                    found = s;
                    break;
                }
            }
            return found;
        }

        public Score? Find(Score score)
        {
            Score? found = null;

            foreach (Score s in Scores!)
            {
                if (s == score)
                {
                    found = s;
                    break;
                }
            }
            return found;
        }


        public int TotalScore()
        {
            int score = 0;
            int ix = 0;
            foreach( Score s in Scores!)
            {
                int a = 0;

                if (s.Active)
                    score += s.InqScore();
                else
                    a = ix;

                ix++;
            }
            return score;
        }

        public int MaximumScore()
        {
            int score = 0;
            foreach (Score s in Scores!)
            {
                score += s.Val;

            }
            return score;
        }

        public Score Add(int id, int val, string? comment = null )
        {
            if (Scores== null)
            {
                Scores = new List<Score>();
            }
            Score newScore = new Score(id, val, comment);
            Scores.Add(newScore);
            return newScore;
        }

        public Score Add(Score score )
        {
            if (Scores == null)
            {
                Scores = new List<Score>();
            }
            Scores.Add(score);
            return (score);
        }
    }
}
