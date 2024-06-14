using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubbeleKingen.Models.GameTypes
{
    public class NoKJGame : GameScoreType
    {
        public NoKJGame(string name, int sc4, int sc3) : base(name, sc4, sc3)
        {}

        public override List<int> GetInitialScores(int pCount)
        {
            return [0, 1, 2, 3, 4, 5, 6, 7, 8];
        }
    }
}
