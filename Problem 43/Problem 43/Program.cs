using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_43
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			long sum = 0;
			int[] digits = new[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
			byte[] dirs = new byte[10];
			long permutations = EMath.Factorial(10);
			while(EMisc.IteratePermutation(digits, dirs, -1, 10, -1))
			{
				if(Check(digits))
				{
					Console.Write(EMisc.ArrayToString(digits));
					Console.WriteLine(": {0}",EMath.FromDigits(digits));
					sum += EMath.FromDigits(digits);
				}
			}
			EMisc.End(sum);
		}

		static bool Check(int[] digits)
		{
			for(int startindex = 1; startindex <= 7; startindex++)
			{
				long x = 0;
				for(int i = 0; i < 3; i++)
				{
					x *= 10;
					x += digits[startindex + i];
				}
				if(x % EMath.GetPrime(startindex - 1) != 0)
				{
					return false;
				}
			}
			return true;
		}
	}
}
