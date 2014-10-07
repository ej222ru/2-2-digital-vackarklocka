using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
	class Program
	{
		const string HorizontalLine = "======================================"; 
		static void Main(string[] args)
		{
			Test1();

			Test2();
			Test3();
			AlarmClock ac = new AlarmClock("7:07", "7:10", "12:34", "22:45");
			Test4(ac);
			Test5(ac);
		}

		private static bool Test1()
		{
			bool ret = true;
			AlarmClock ac = new AlarmClock();
			ViewTestHeader("Test 1.\n" + Strings1.Test1 + "\n");
			Console.WriteLine(ac.ToString());
			return ret;
		}
		private static bool Test2()
		{
			bool ret = true;
			int hour = 9;
			int minute = 42;
			AlarmClock ac = new AlarmClock(hour, minute);
			ViewTestHeader(string.Format("Test 2. \n" + Strings1.Test2, hour, minute));
			Console.WriteLine(ac.ToString());
			return ret;
		}
		private static bool Test3()
		{
			bool ret = true;
			AlarmClock ac = new AlarmClock(13, 24, 7, 35);
			ViewTestHeader("Test 3.\n" + Strings1.Test3 + "\n");
			Console.WriteLine(ac.ToString());
			return ret;
		}

		private static bool Test4(AlarmClock ac)
		{
			bool ret = true;

			ViewTestHeader("Test 4.\n" + Strings1.Test4 + "\n");
			Console.WriteLine(ac.ToString());
			return ret;
		}
		private static bool Test5(AlarmClock ac)
		{
			bool ret = true;
			string time =  "23:58";
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

		private static void Run(AlarmClock ac, int minutes)
		{
			for (int i = 0; i < minutes; i++)
			{
				ac.TickTock();
			}
		}
		private static void ViewErrorMessage(string message)
		{
			Console.BackgroundColor = ConsoleColor.DarkRed;
			Console.WriteLine(message);
			Console.ResetColor();
		}
		private static void ViewTestHeader(string message, bool printTM=false)
		{
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
	}
}
