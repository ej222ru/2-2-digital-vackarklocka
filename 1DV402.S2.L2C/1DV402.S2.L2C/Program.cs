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
		}
	}
	/*
			static void test
			{
				int testNumber1 = 1;
				int testNumber2 = 1;
				int count = 1;
				NumberDisplay MyNumberDisplay = new NumberDisplay(12, testNumber1);
				NumberDisplay AnotherDisplay = new NumberDisplay(12, testNumber2);
				do
				{


					if (MyNumberDisplay.Equals(AnotherDisplay))
						Console.WriteLine(string.Format("Likadana object {0} {1}", MyNumberDisplay.Number, AnotherDisplay.Number));
					else
						Console.WriteLine("Olika object {0} {1}", MyNumberDisplay.Number, AnotherDisplay.Number);

					Console.WriteLine(string.Format("GetHashCode {0} : {1}", MyNumberDisplay.GetHashCode(), AnotherDisplay.GetHashCode()));
					Console.WriteLine("ToString() " + MyNumberDisplay.ToString() + " : " + AnotherDisplay.ToString());
					MyNumberDisplay.Increment();
					if ((MyNumberDisplay.Number % 2) == 0)
						AnotherDisplay.Increment();
					Console.WriteLine("***************************");
					Console.WriteLine("");
				} while (count++ < 20);

			}
		}
	}
		*/
}