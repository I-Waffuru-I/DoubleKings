using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubbeleKingen.Models
{
    public abstract class GameScoreType
    {
		private int score4;
		private int score3;
		private string name = "";

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		public int Score3
		{
			get { return score3; }
			set { score3 = value; }
		}
		public int Score4
		{
			get { return score4; }
			set { score4 = value; }
		}


		public GameScoreType(string name,int sc4, int sc3)
		{
			Name = name;
			Score4 = sc4;
			Score3 = sc3;
		}

		public abstract List<int> GetInitialScores(int pCount);


	}
}
