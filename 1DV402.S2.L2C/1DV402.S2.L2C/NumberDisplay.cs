using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
	class NumberDisplay
	{
		private int _number;
		private int _maxNumber;

		public int Number
		{
			get { return _number; }
			private set { _number = value; }
		}

		public int MaxNumber
		{
			get { return _maxNumber; }
			private set { _maxNumber = value; }
		}

		public NumberDisplay(int maxNumber)
			: this(maxNumber, 0)
		{
		}

		public NumberDisplay(int maxNumber, int number)
		{
			MaxNumber = maxNumber;
			Number = number;
		}

		public override bool Equals(object obj)
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}
			// If parameter cannot be cast to Point return false.
			NumberDisplay numberDisplay = obj as NumberDisplay;
			if ((object)numberDisplay == null)
			{
				return false;
			}
			// return true if fields match
			return ((Number == numberDisplay.Number)
					&&
					(MaxNumber == numberDisplay.MaxNumber));
		}

		/// <summary>
		/// Also implement Equals(type) for enhanced peformance according to msdn
		/// </summary>
		/// <param name="numberDisplay"></param>
		/// <returns></returns>
		public bool Equals(NumberDisplay numberDisplay)
		{
			// If parameter is null return false:
			if ((object)numberDisplay == null)
			{
				return false;
			}
			// return true if fields match
			return ((Number == numberDisplay.Number)
					&&
					(MaxNumber == numberDisplay.MaxNumber));
		}





	}
}
