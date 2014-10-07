using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
	class AlarmClock
	{
		private ClockDisplay[] _alarmTimes;
		private ClockDisplay _time;

		public string[] AlarmTimes
		{
			get 
			{ 
				string[] res = new string[_alarmTimes.Length];
				for (int i = 0; i < _alarmTimes.Length; i++)
				{
					res[i] = _alarmTimes[i].Time;
				} 
				return res;
			}
			set
			{
				for (int i = 0; i < _alarmTimes.Length; i++)
				{
					_alarmTimes[i] = new ClockDisplay(value[i]);
				} 
			}
		}

		public string Time
		{
			get { return _time.Time; }
			set { _time.Time = value; }
		}

		public AlarmClock()
			: this(0,0)	{ }

		public AlarmClock(int hour, int minute)
			: this(hour, minute, 0, 0) { }

		public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
		{
			_time = new ClockDisplay(hour, minute);
			_alarmTimes[0] = new ClockDisplay(alarmHour, alarmMinute);
		}

		public AlarmClock(string time, params string[] alarmTimes) 
		{
			if (alarmTimes.Length < 1)
			{
				// do something... exception error msg?
			}
			else
			{
				int i = 0;
				_time = new ClockDisplay(time);
				foreach (string alarmTime in alarmTimes)
				{
					_alarmTimes[i] = new ClockDisplay(alarmTime);
					i++;
				}
			}
			
		}


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

		public override string ToString()
		{
			string formattedAlarmClock;
			formattedAlarmClock = _time.ToString();

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
