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
			_alarmTimes = new ClockDisplay[1];
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
				_alarmTimes = new ClockDisplay[alarmTimes.Length];
				foreach (string alarmTime in alarmTimes)
				{
					_alarmTimes[i] = new ClockDisplay(alarmTime);
					i++;
				}
			}
			
		}


		public override bool Equals(object obj)
		{

			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}
			// If parameter cannot be cast to NumberDisplay return false.
			AlarmClock alarmClock = obj as AlarmClock;
			if ((object)alarmClock == null)
			{
				return false;
			}
			// return true if fields match
			return (ToString() == alarmClock.ToString());
		}
		public override int GetHashCode()
		{
			return ToString().GetHashCode();
		}

		public bool TickTock()
		{
			bool ret = false;
			_time.Increment();
			foreach (ClockDisplay alarm in _alarmTimes)
			{
				if (_time.Equals(alarm))
				{
					ret = true;
					break;
				}
			}
			return ret;
		}
		public override string ToString()
		{
			string formattedAlarmClock = "";
			formattedAlarmClock = string.Format("{0,8} (", _time.ToString());
			for (int i=0; i <  _alarmTimes.Length; i++)
			{
				formattedAlarmClock += _alarmTimes[i].ToString();
				if (i + 1 < _alarmTimes.Length)
					formattedAlarmClock += ", ";
				else
					formattedAlarmClock += ")";
			}
			return formattedAlarmClock;
		}

		public static bool operator ==(AlarmClock alarmClock_A, AlarmClock alarmClock_B)
		{
			// If both are null, or both are same instance, return true.
			if (System.Object.ReferenceEquals(alarmClock_A, alarmClock_B))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)alarmClock_A == null) || ((object)alarmClock_B == null))
			{
				return false;
			}
			return alarmClock_A.Equals(alarmClock_B);
		}
		public static bool operator !=(AlarmClock alarmClock_A, AlarmClock alarmClock_B)
		{
			return !(alarmClock_A == alarmClock_B);
		}

	}
}
