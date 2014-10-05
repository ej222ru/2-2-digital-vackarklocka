﻿using System;
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
			: this(maxNumber,0 )
		{
		}

		public NumberDisplay(int maxNumber, int number)
		{
			Number = number;
			MaxNumber = maxNumber;
		}

		public override bool Equals(object obj)
		{

			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}
			// If parameter cannot be cast to NumberDisplay return false.
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

		public override int GetHashCode()
		{
			return Convert.ToInt32(ToString());
		}
		public void Increment()
		{
			if (++Number > MaxNumber)
				Number = 0;
		}
		public override string ToString()
		{
			if (Number <10)
				return String.Format("{0,1}", Number);
			else
				return String.Format("{0,2}", Number);
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

		public static bool operator ==(NumberDisplay a, NumberDisplay b)
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
		public static bool operator !=(NumberDisplay a, NumberDisplay b)
		{
			return !(a == b);
		}

 
  
	}

}
