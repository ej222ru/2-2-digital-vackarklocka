using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
	class Program
	{

		static void Main(string[] args)
		{
			Test myTest = new Test();
			try
			{
				myTest.Test1();

				myTest.Test2();
				AlarmClock ac1 = new AlarmClock(13, 24, 7, 35);
				myTest.Test3(ac1);
				AlarmClock ac2 = new AlarmClock("7:07", "7:10", "12:34", "22:45");
				myTest.Test4(ac2);
				myTest.Test5(ac2);
				myTest.Test6(ac1);
				myTest.Test7(ac1);
				myTest.Test8();
				myTest.Test9();
				myTest.Test10();
				myTest.Test11();
				myTest.Test12();
				myTest.Test13();
				myTest.Test14();
				myTest.Test15();
			}
			catch(Exception exception)
			{  // open catch for everything really unexpected
				myTest.ViewErrorMessage(exception.Message);
			}
		}

	}
}
