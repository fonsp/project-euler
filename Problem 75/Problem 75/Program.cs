using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_75
{
	class Program
	{
		static List<long> primeLengths = new List<long>();
		const double s = 1.4142135623730950488016887242097;
		private const long maxL = 1500000;
		[STAThread]
		static void Main(string[] args)
		{
			EMisc.StartStopwatch();
			long count = 0;
			long L;
			for(long n = 1; 2*(n+1)*(2*n+1) <= maxL; n++)
			{
				L = 0;
				for(long m = n + 1; L <= maxL; m += 2)
				{
					L = 2 * m * (m + n);
					if(EMath.AreRelativePrimes(m, n))
					{
						if(L <= maxL)
						{
							primeLengths.Add(L);
						}
						//Console.WriteLine("{0}, {1}", L, maxL/L);
					}
				}
			}
			primeLengths.Sort();
			for(int i = 0; i < primeLengths.Count; i++)
			{
				L = primeLengths[i];
				count += maxL / L;
				for(int j = 0; j < i; j++)
				{
					long B = primeLengths[j];
					long gcd = EMath.GreatesCommonDenomitor(L, B);
					count -= maxL / ((L / gcd) * B);
				}
			}

			EMisc.End(count);
		}

		static bool Test(long L)
		{
			int divisors = nPrimeDivisors(L);
			if(divisors > 1)
			{
				return false;
			}
			if(divisors == 1)
			{
				return true;
			}
			if(divisors == 0)
			{
				for(long x = 1; x < s * L; x++)
				{
					long n = L * (L - 2 * x);
					long m = 2 * (L - x);
					if(n % m == 0)
					{
						primeLengths.Add(L);
						return true;
					}
				}
			}
			return false;
		}

		static int nPrimeDivisors(long L)
		{
			return primeLengths.Count(primeLength => L % primeLength == 0);
		}
	}
}
