using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubbeleKingen.Models.GameTypes
{
    class NoHeartsGame : GameScoreType
    {
        public NoHeartsGame(string name, int sc4, int sc3) : base(name, sc4, sc3)
        {
        }

        public override List<int> GetInitialScores(int pCount)
        {
            List<int> scores = new();
            int total = (pCount == 3) ? 14 : 14;

            for (int i = 0; i < total; i++)
            {
                scores.Add(i);
            }

            return scores;
        }
    }
}
