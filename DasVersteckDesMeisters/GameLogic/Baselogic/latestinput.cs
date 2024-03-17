using System;

namespace GameCore
{
    [Serializable]
    public class LatestInput
    {
        public string Text { get; set; }

        public LatestInput(string s)
        {
            Text = s;
        }
    }
}
