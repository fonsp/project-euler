using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_41
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			for(int n = 9; n > 0; n--)
			{
				int[] digits = new int[n];
				byte[] dirs = new byte[n];
				for(int i = 0; i < n; i++)
				{
					digits[i] = i + 1;
				}
				long largestPrime = -1;
				while(EMisc.IteratePermutation(digits, dirs, -1, n, -1))
				{
					long x = EMath.FromDigits(digits);
					if(x > largestPrime && EMath.IsPrime(x))
					{
						largestPrime = x;
					}
				}
				if(largestPrime != -1)
				{
					EMisc.End(largestPrime);
				}
			}
		}
	}
}
