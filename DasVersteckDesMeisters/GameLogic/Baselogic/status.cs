using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GameCore
{
    [Serializable]

    public class Status
    {

        public int ID { get; set;  }

        public int Val { get; set; }
        [JsonConstructor]


        public Status(int pID, int pVal = 0)
        {
            ID = pID;
            Val = pVal;
        }

        public Status( int pVal = 0) : this(SerialNumberGenerator.Instance.NextSerial, pVal )
        {

        }
    }
    [Serializable]

    public class StatusList
    {

        public List<Status> List { get; set; }


        public StatusList()
        {
            List = new List<Status>();
        }


        public Status Add(int ID, int Val = 0 )
        {
            if ( List == null)
            {
                List = new List<Status>();
            }
            Status newStatus = new Status(ID, Val);
            List.Add(newStatus);
            return newStatus;
        }

        public Status Add( Status Stat)
        {
            if (List == null)
            {
                List = new List<Status>();
            }
            List.Add( Stat);
            return (Stat);
        }

        public Status? Find(int pID)
        {
            Status? tSt = null;

            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].ID == pID)
                {
                    tSt = List[i];
                }
            }
            return (tSt);
        }

        public bool Delete(int pID)
        {
            bool deleted = false;

            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].ID == pID)
                {
                    List.RemoveAt(i);
                    deleted = true;
                    break;
                }
            }
            return deleted;
        }


        public int Count
        {
            get { return (List.Count); }
        }

        public Status? FindIndex( int Index )
        {
            Status? tSt = null;
            if( Index < List.Count)
            {
                tSt = List[Index];
            }
            return (tSt);
        }
    }
}