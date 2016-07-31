using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_52
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			for(long x = 1; Test(x); x++)
			{
			}
		}

		static bool Test(long x)
		{
			List<long> compare = EMath.GetDigits(x);
			compare.Sort();
			int length = compare.Count;
			for(long i = 2; i <= 6; i++)
			{
				long y = i * x;
				if(!LengthIsCorrect(y, length))
				{
					return true;
				}
				List<long> digits = EMath.GetDigits(y);
				digits.Sort();
				if(!digits.SequenceEqual(compare))
				{
					return true;
				}
			}
			EMisc.End(x);
			return false;
		}

		static bool LengthIsCorrect(long y, int length)
		{
			int count = 0;
			while(y > 0)
			{
				y /= 10;
				count++;
			}
			return count == length;
		}
	}
}
