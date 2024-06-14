using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubbeleKingen.Models.GameTypes
{
    class No7OrLastGame : GameScoreType
    {
        public No7OrLastGame(string name, int sc4, int sc3) : base(name, sc4, sc3)
        {
        }

        public override List<int> GetInitialScores(int pCount)
        {
            return [0, 2, 3, 5];
        }
    }
}
