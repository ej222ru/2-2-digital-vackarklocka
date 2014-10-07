using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _1DV402.S2.L2C
{
	class ClockDisplay
	{
		static string pattern = "^(([0-1]?[0-9})|([2][0-3])):([0-5][0-9])$";
		Regex rgx = new Regex(pattern);

		private NumberDisplay _minuteDisplay;
		private NumberDisplay _hourDisplay;

		public string Time {
			get { 
				string ret = _hourDisplay.ToString("0") + ":" + _minuteDisplay.ToString("00");
				return ret;
			}
			set 
			{ 
				MatchCollection matches = rgx.Matches(value);
				if (matches.Count > 0)
				{
					string[] res = new string[2];
					char[] delim = new char[] {':'};
					res = value.Split(delim, 2);
					_hourDisplay.Number = int.Parse(res[0]);
					_minuteDisplay.Number = int.Parse(res[1]);
				}
				else
					throw new FormatException();
			}
		}

		public ClockDisplay()
			: this(0,0)	{ }

		public ClockDisplay(int hour, int minute)
		{
			_hourDisplay = new NumberDisplay(23, hour);
			_minuteDisplay = new NumberDisplay(59, minute);
		}

		public ClockDisplay(string time)
		{
			// time comes as HH:mm
			Time = time;
		}

		public override bool Equals(object obj)
		{
			// check if same object
			if (this == obj) return true;
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}
			// If parameter cannot be cast to NumberDisplay return false.
			ClockDisplay clockDisplay = obj as ClockDisplay;
			if ((object)clockDisplay == null)
			{
				return false;
			}
			// return true if fields match
			return ((_hourDisplay == clockDisplay._hourDisplay)
					&&
					(_minuteDisplay == clockDisplay._minuteDisplay));
		}

		/// <summary>
		/// Also implement Equals(type) for enhanced peformance according to msdn
		/// </summary>
		/// <param name="clockDisplay"></param>
		/// <returns></returns>
		public bool Equals(ClockDisplay clockDisplay)
		{
			// If parameter is null return false:
			if ((object)clockDisplay == null)
			{
				return false;
			}
			// return true if fields match
			return ((_hourDisplay == clockDisplay._hourDisplay)
					&&
					(_minuteDisplay == clockDisplay._minuteDisplay));
		}
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}
		public void Increment()
		{
			_minuteDisplay.Increment();
			if (_minuteDisplay.Number == 0)
				_hourDisplay.Increment();
		}
		public override string ToString()
		{
			return Time;
		}
		public string ToString(string format)
		{
			if (format.Equals("0") || format.Equals("G"))
				return ToString();
			else if (format.Equals("00"))
			{
				return String.Format("{0,2}", Number);
			}
			else
			{
				throw new FormatException();
			}
		}

		public static bool operator ==(ClockDisplay a, ClockDisplay b)
		{
			// If both are null, or both are same instance, return true.
			if (System.Object.ReferenceEquals(a, b))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)a == null) || ((object)b == null))
			{
				return false;
			}
			return a.Equals(b);
		}
		public static bool operator !=(ClockDisplay a, ClockDisplay b)
		{
			return !(a == b);
		}

 
	}
}
