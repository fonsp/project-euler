using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_38
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			long best = long.MinValue;
			for(int n = 9; n > 1; n--)
			{
				long last = long.MinValue;
				long i = 1;
				while(last < 1000000000)
				{
					last = 0;
					int totalLength = 0;
					bool[] digits = new bool[9];
					bool pandigital = true;
					for(long x = 1; x <= n; x++)
					{
						long z = x * i;
						long w = z;
						int length = 0;
						while(w > 0)
						{
							if(w % 10 == 0 || digits[w % 10 - 1])
							{
								pandigital = false;
								x = n + 1;
								w = 0;
							}
							else
							{
								digits[w % 10 - 1] = true;
								w /= 10;
								length++;
							}
						}
						totalLength += length;
						last *= EMath.IntPow(10, length);
						last += z;
					}
					if(pandigital && last > best)
					{
						best = last;
						Console.WriteLine(best);
					}
					i++;
				}
				Console.WriteLine(n);
			}
			EMisc.End(best);
		}
	}
}
