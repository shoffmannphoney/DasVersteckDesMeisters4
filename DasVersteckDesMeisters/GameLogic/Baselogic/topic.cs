using System;
using System.Collections.Generic;


namespace GameCore
{
    [Serializable]
    public class Topic: AbstractAdvObject
    {
        /*
        public int TopicID { get; set; }
        public List<int> Names { get; set; }
        public List<int> SynNames { get; set; }
        public List<int> Adjectives { get; set; }
        public List<int> SynAdjectives { get; set; }
        public int Sex { get; set; }
        public bool Active { get; set; }
        */

        public Topic()
        {

        }
        public Topic(int pTopicID, List<Noun> pNames, List<Adj> pAdjectives, int pSex, NounList pNouns, AdjList pAdjs )
           : base(pTopicID, pNames, null, pAdjectives, null, pSex, null, true, null, pNouns, pAdjs)
        {
            /*
            TopicID = pTopicID;
            Sex = pSex;
            Adjectives = new List<int>();
            SynAdjectives = new List<int>();
            SynNames = new List<int>();
            Active = true;

            foreach (var element in pAdjectives)
            {
                Adjectives.Add(element);
            }

            Names = new List<int>();
            foreach (var element in pNames)
            {
                Names.Add(element);
            }
            */
        }
        public Topic(List<Noun> pNames, List<Adj> pAdjectives, int pSex, NounList pNouns, AdjList pAdjs)
                 : this(SerialNumberGenerator.Instance.NextSerial, pNames, pAdjectives, pSex, pNouns, pAdjs)

        {
        }
        public Topic Clone()
        {
            Topic t = (Topic)this.MemberwiseClone();
            return t;
        }
    }
    [Serializable]
    public class TopicList: AbstractAdvObjectList<AdvObject>
    {
#pragma warning disable CS0108 // "TopicList.List" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.List" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        public TopicList( ) : base()
        {
            List = new List<Topic>();
            loca.GD!.AddLanguageCallback(RestoreTopics);
        }
        public List<Topic> List { get; set; }
#pragma warning restore CS0108 // "TopicList.List" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.List" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
#pragma warning disable CS0108 // "TopicList.Last()" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.Last()" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.

        public Topic Last()
#pragma warning restore CS0108 // "TopicList.Last()" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.Last()" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        {
            return (List[List.Count - 1]);
        }
        public Topic Add(Topic I)
        {
            if (List == null)
            {
                List = new List<Topic>();
            }
            // new this.GetType().GetConstructor();
            List.Add(I);
            return (I);
            // base.Add((AdvObject)I);
        }
#pragma warning disable CS0108 // "TopicList.Find(int)" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.Find(int)" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.

        public Topic? Find(int ID)
#pragma warning restore CS0108 // "TopicList.Find(int)" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.Find(int)" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        {
            Topic? ret = null;

            foreach (Topic ele in List)
            {
                if (ele.ID == ID)
                {
                    ret = ele;
                }
                if (ret != null) break;
            }
            return ret;
        }
        public Topic? Find(Topic T)
        {
            Topic? ret = null;

            foreach (Topic ele in List)
            {
                if (ele.ID == T.ID)
                {
                    ret = ele;
                }
                if (ret != null) break;
            }
            return ret;
        }
#pragma warning disable CS0108 // "TopicList.FindIx(int)" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.FindIx(int)" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.

        public int FindIx(int ID)
#pragma warning restore CS0108 // "TopicList.FindIx(int)" blendet den vererbten Member "AbstractAdvObjectList<AdvObject>.FindIx(int)" aus. Verwenden Sie das new-Schlüsselwort, wenn das Ausblenden vorgesehen war.
        {
            int index = -1;

            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].ID == ID)
                {
                    index = i;
                }
                if (index > -1) break;
            }
            return index;

        }
        public bool IsTopicHere(Topic T, int Mode)
        {
            bool foundTopic = false;

            if (Mode == Co.Range_Active)
            {
                if (T.Active)
                    foundTopic = true;
            }
            else
            {
                foundTopic = true;
            }

            return (foundTopic);
        }
        public int GetTopicIx(int TopicID)
        {
            int rTopicIX = 0;
            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i].ID == TopicID)
                {
                    rTopicIX = i;
                }
            }
            return (rTopicIX);
        }
        public int GetTopicIx(Topic T )
        {
            int rTopicIX = 0;
            for (int i = 0; i < this.List.Count; i++)
            {
                if (this.List[i] == T)
                {
                    rTopicIX = i;
                }
            }
            return (rTopicIX);
        }
        public string GetTopicName(int TopicID, int Case)
        {
            return (this.List[this.FindIx(TopicID)].FullName(this.Find(TopicID)!, Case )!);
        }
        public bool RestoreTopics()
        {
            if (List == null) return true;

            List <Topic>? TList2 = new List<Topic>();

            foreach (var ele in List)
            {
                Topic ele2 = (Topic)ele;


                // TList2.Add(key: ele2.ID, value: ele2);
                TList2.Add( ele2);

            }
            List = (List<Topic>)TList2;
            TList2 = null;

            return true;
        }
    }
}
