using EulerDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem_610
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			double result = 0;

			// This calculates the contribution of a possible addition of a sequence of 'M' to the start of the sequence. 
			// Since sum_{i=1)^\infty x^i = x/(1-x)
			result += 1000 * .14 / (1.0 - .14);
			// Recursive call.
			result += Calc("", 0);

			EMisc.End(result.ToString("F8", System.Globalization.CultureInfo.InvariantCulture));
		}

		static double Calc(string prefix, int currentValue)
		{
			double result = 0;
			int numberOfChildren = 0;
			foreach(char suffix in EMath.RomanCharacters)
			{
				int value;
				string newPrefix = prefix + suffix;
				if(IsValidAndMinimal(newPrefix, out value))
				{
					numberOfChildren++;
					result += .14 * Calc(newPrefix, value);
				}
			}
			// The # char
			result += .02 * currentValue;
			// Normalize: if a character is invalid, it is redrawn.
			return result / (numberOfChildren * .14 + .02);
		}

		static bool IsValidAndMinimal(string roman, out int value)
		{
			value = -1;
			if(roman == "")
			{
				return true;
			}
			// Since we treated the M trail seperately
			if(roman.Length == 1 && roman[0] == 'M')
			{
				return false;
			}
			value = EMath.RomanToInt(roman);
			return roman == EMath.IntToRoman(value);
		}
	}
}
