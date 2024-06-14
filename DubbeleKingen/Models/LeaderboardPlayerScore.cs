using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubbeleKingen.Models
{
    public class LeaderboardPlayerScore
    {
		private string _name = "";
		private int _plus;
        private int _min;
		private double _total;


		public string Name
		{
			get { return _name; } 
			set { _name = value; }
		}
        public int Plus
		{
			get { return _plus; }
			set 
			{
				_plus = value; 
				Total = _plus - _min;
            }
        }

		public int Min
		{
			get { return _min; }
			set 
			{
				_min = value;
				Total = _plus - _min;	
			}
		}
		
		public double Total
		{
			get { return _total; }
			set { _total = value; }
		}

		public LeaderboardPlayerScore(string name, int plus, int min)
		{
			Name = name;
			Plus = plus;
			Min = min;
		}
	}
}
