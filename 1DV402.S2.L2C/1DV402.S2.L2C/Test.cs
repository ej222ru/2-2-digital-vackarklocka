
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
	class Test
	{
		const string HorizontalLine = "======================================"; 
		public void ViewErrorMessage(string message)
		{
			Console.BackgroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ResetColor();
		}
		private static void ViewTestHeader(string message, bool printTM = false)
		{
			Console.WriteLine("");
			Console.WriteLine(HorizontalLine);
			Console.WriteLine(message);
			Console.WriteLine("");
			if (printTM)
			{
				Console.BackgroundColor = ConsoleColor.DarkRed;
				Console.WriteLine(Strings1.Frame + "\n" + Strings1.TM + "\n" + Strings1.Modellnr + "\n" + Strings1.Frame + "\n");
				Console.ResetColor();
			}
		}
		private static void Alarm()
		{
			for (int i = 0; i < 3; i++)
			{
				Console.Beep();
				Console.Write(Strings1.Alarm);
			}
		}
		public bool Test1()
		{
			bool ret = true;
			AlarmClock ac = new AlarmClock();
			ViewTestHeader("Test 1.\n" + Strings1.Test1);
			Console.WriteLine(ac.ToString());
			return ret;
		}
		public bool Test2()
		{
			bool ret = true;
			int hour = 9;
			int minute = 42;
			AlarmClock ac = new AlarmClock(hour, minute);
			ViewTestHeader(string.Format("Test 2. \n" + Strings1.Test2, hour, minute));
			Console.WriteLine(ac.ToString());
			return ret;
		}
		public bool Test3(AlarmClock ac)
		{
			bool ret = true;

			ViewTestHeader("Test 3.\n" + Strings1.Test3);
			Console.WriteLine(ac.ToString());
			return ret;
		}
		public bool Test4(AlarmClock ac)
		{
			bool ret = true;

			ViewTestHeader("Test 4.\n" + Strings1.Test4);
			Console.WriteLine(ac.ToString());
			return ret;
		}
		public bool Test5(AlarmClock ac)
		{
			bool ret = true;
			string time = "23:58";
			ac.Time = time;

			ViewTestHeader(string.Format("Test 5.\n" + Strings1.Test5, time), true);

			int i = 13;
			do
			{
				ac.TickTock();
				Console.WriteLine(ac.ToString());
			} while (--i > 0);
			return ret;
		}
		public bool Test6(AlarmClock ac)
		{
			bool ret = true;
			string time = "6:12";
			string[] alarm = { "6:15" };
			ac.Time = time;
			ac.AlarmTimes = alarm;
			ViewTestHeader(string.Format("Test 6.\n" + Strings1.Test6, time, alarm[0]), true);
			int i = 6;
			do
			{
				if (ac.TickTock())
				{
					Console.Write(ac.ToString());
					Alarm();
					Console.WriteLine("");
				}
				else
					Console.WriteLine(ac.ToString());
			} while (--i > 0);
			return ret;
		}
		public bool Test7(AlarmClock ac)
		{
			bool ret = true;
			string time = "24:89";
			string[] alarm = { "7:69" };
			ViewTestHeader(string.Format("Test 7.\n" + Strings1.Test7, time, alarm[0]));
			try
			{
				ac.Time = time;
			}
			catch (FormatException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorTime, time));
			}
			try
			{
				ac.AlarmTimes = alarm;
			}
			catch (FormatException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorTime, alarm));
			}
			return ret;
		}
		public bool Test8()
		{
			bool ret = true;
			string time = "24:89";
			string[] alarm = { "7:69" };
			string[] alarmOK = { "7:33" };

			ViewTestHeader(string.Format("Test 8.\n" + Strings1.Test8, time, alarm[0]));
			try
			{
				AlarmClock ac = new AlarmClock(time, alarmOK);
			}
			catch (FormatException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorTime, time));
			}
			try
			{
				AlarmClock ac1 = new AlarmClock(time, alarmOK);
			}
			catch (FormatException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorTime, alarm));
			}
			return ret;
		}
		public bool Test9()
		{
			bool ret = true;
			string time = "-4:89";
			string[] alarm = { "-7:14" };
			string[] alarmOK = { "7:33" };

			ViewTestHeader(string.Format("Test 9.\n" + Strings1.Test9, time, alarm[0]));
			try
			{
				AlarmClock ac = new AlarmClock(time, alarmOK);
			}
			catch (FormatException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorTime, time));
			}
			try
			{
				AlarmClock ac1 = new AlarmClock(time, alarmOK);
			}
			catch (FormatException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorTime, alarm));
			}
			return ret;
		}
		public bool Test10()
		{
			bool ret = true;
			int hour = -9;
			int minute = 42;
			ViewTestHeader(string.Format("Test 10. \n" + Strings1.Test9, hour, minute));
			try
			{
				AlarmClock ac1 = new AlarmClock(hour, minute);

			}
			catch (ArgumentException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorHour, hour));
			}

			try
			{
				hour = 9;
				minute = -42;
				AlarmClock ac2 = new AlarmClock(hour, minute);
			}
			catch (ArgumentException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorMinute, minute));
			}
			return ret;
		}
		public bool Test11()
		{
			bool ret = true;
			string time = "NoValidTime";
			string[] alarm = { "NoValidAlarmTime" };
			string[] alarmOK = { "7:33" };

			ViewTestHeader(string.Format("Test 11.\n" + Strings1.Test11, time, alarm[0]));
			try
			{
				AlarmClock ac = new AlarmClock(time, alarmOK);
			}
			catch (FormatException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorTime, time));
			}
			try
			{
				AlarmClock ac1 = new AlarmClock(time, alarmOK);
			}
			catch (FormatException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorTime, alarm));
			}
			return ret;
		}
		public bool Test12()
		{
			bool ret = true;
			int maxNumber = -9;

			try
			{
				ViewTestHeader(string.Format("Test 12. \n" + Strings1.Test12, maxNumber));
				NumberDisplay nd = new NumberDisplay(maxNumber);
			}
			catch (ArgumentException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorMaxNumber, maxNumber));
			}

			return ret;
		}
		public bool Test13()
		{
			bool ret = true;
			string time = "NoValidTime";

			try
			{
				ViewTestHeader(string.Format("Test 13. \n" + Strings1.Test13, time));
				ClockDisplay nd = new ClockDisplay(time);
			}
			catch (FormatException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorTime, time));
			}

			return ret;
		}
		public bool Test14()
		{
			bool ret = true;
			string[] times = { "7:07", "7:10", "NoValidAlarm", "22:45" };
			try
			{

				ViewTestHeader(string.Format("Test 14. \n" + Strings1.Test14, times[2]));
				AlarmClock ac3 = new AlarmClock("7:07", "7:10", "NoValidAlarm", "22:45");
			}
			catch (FormatException)
			{
				ViewErrorMessage(string.Format(Strings1.ErrorTime, times[2]));
			}
			return ret;
		}
		public bool Test15()
		{
			bool ret = true;
			string[] times = { "7:07" };
			try
			{
				ViewTestHeader("Test 15.\n" + Strings1.Test15);
				AlarmClock ac3 = new AlarmClock("7:07");
			}
			catch (ArgumentException argumentException)
			{
				ViewErrorMessage(argumentException.Message);
			}
			return ret;
		}
	}
}