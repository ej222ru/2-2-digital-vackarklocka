using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
	class ClockDisplay
	{
		private NumberDisplay _minuteDisplay;
		private NumberDisplay _hourDisplay;

		public string Time { get; set; }


		public ClockDisplay()
		{

		}

		public ClockDisplay(int hour, int minute)
		{

		}

		public ClockDisplay(string time)
		{
			// time comes as HH:mm


		}
	}
}
