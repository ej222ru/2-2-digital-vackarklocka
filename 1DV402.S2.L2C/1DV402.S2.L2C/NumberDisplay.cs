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
			set 
			{ 
				if ((value >= 0) && (value <= MaxNumber)) 
					_number = value; 
				else
					throw new ArgumentException();
			}
		}

		public int MaxNumber
		{
			get { return _maxNumber; }
			set 
			{
				if (value > 0)
					_maxNumber = value;
				else
					throw new ArgumentException();
			}
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

		/* Jag har lite problem med att förstå hur GetHashCode ska imlementeras.
		 * Vad menas med "Lämpligen returnerar metoden hashkoden för t ex textbeskrivningen av fälten". 
		 * Vad är textbeskrivningen av fälten 
		 * och hur bestämmer man hashkoden för dessa?
		 * 
		 * Kn man inte bara implementera något som ger en unik kod för varje unikt objekt?
		 */
		public override int GetHashCode()
		{
			return Number.GetHashCode() + 100 * MaxNumber.GetHashCode();
			// eller ToString.GetHAshCode();  ??????
		}
		public void Increment()
		{
			if (Number == MaxNumber)
			{
				Number = 0;
			}
			else
				Number++;
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
				return Number.ToString("D2"); 
			}
			else 
			{  
				throw new FormatException();
			}
		}

		/// <summary>
		/// Template from msdn
		/// </summary>
		/// <param name="obj_A"></param>
		/// <param name="obj_B"></param>
		/// <returns></returns>
		public static bool operator ==(NumberDisplay obj_A, NumberDisplay obj_B)
		{
			// If both are null, or both are same instance, return true.
			if (System.Object.ReferenceEquals(obj_A, obj_B))
			{
				return true;
			}

			// If one is null, but not both, return false.
			if (((object)obj_A == null) || ((object)obj_B == null))
			{
				return false;
			}
			return obj_A.Equals(obj_B);
		}
		public static bool operator !=(NumberDisplay obj_A, NumberDisplay obj_B)
		{
			return !(obj_A == obj_B);
		}
	}

}
