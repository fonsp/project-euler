using EulerDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_357
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			long product = 1;
			var allowedPrimes = Enumerable.Range(0, int.MaxValue).Select(i => EMath.GetPrime(i)).TakeWhile(p =>
			 {
				 return p < 100000000 / 2;
				 product *= p;
				 return product <= 100000000;
			 }).ToList();
			EMisc.End(allowedPrimes.Count());
			//allowedPrimes = new List<long>() { 2, 3 };
			//EMisc.End(EMisc.Subsets(allowedPrimes).Count());
			EMisc.End(EMisc.Subsets(allowedPrimes).Select(l => l.Aggregate((long)1, (a, b) => a * b)).Where(ActualCheck).Sum());

			MultiThreader<int> mt;
			EMisc.StartStopwatch();
			mt = new MultiThreader<int>(8, n => FastCheck(n) ? n : 0, 1, 1000000);
			Console.WriteLine(mt.Get());
			mt = new MultiThreader<int>(8, n => ActualCheck(n) ? n : 0, 1, 1000000);
			Console.WriteLine(mt.Get());
			EMisc.End();

			Console.WriteLine(mt.Get());

			mt = new MultiThreader<int>(8, n => (NecessaryCheck(n) && SufficientCheck(n)) ? n : 0, 1, 100000);
			mt = new MultiThreader<int>(8, n => (NecessaryCheck(n) && ActualCheck(n)) ? n : 0, 1, 100000);
			Console.WriteLine(mt.Get());

		}

		static bool NecessaryCheck(long n)
		{
			bool firstDivisor = true;
			long tempN = n;
			long d = 2;
			while(tempN > 1)
			{
				if(tempN % d == 0)
				{
					tempN /= d;
					if(tempN % d == 0)
					{
						if(!firstDivisor)
						{
							return false;
						}
						else
						{
							return n == d * d;
						}
					}
					firstDivisor = false;
				}
				d += d == 2 ? 1 : 2;
			}
			return true;
		}

		static bool SufficientCheck(long n)
		{
			long divisorUpperBound = n;
			long tempN = divisorUpperBound;
			long d = 2;
			while(d <= divisorUpperBound && tempN > 1)
			{
				if(tempN % d == 0)
				{
					var ndivd = n / d;
					divisorUpperBound = ndivd;
					if(!EMath.IsPrime(d + ndivd))
					{
						return false;
					}
					do
					{
						tempN = tempN / d;
					} while(tempN % d == 0);
				}
				d = d == 2 ? 3 : d + 2;
			}
			return true;
		}

		static bool FastCheck(long n)
		{
			long divisorUpperBound = n;
			long tempN = divisorUpperBound;
			long d = 2;
			while(d <= divisorUpperBound && tempN > 1)
			{
				if(tempN % d == 0)
				{
					var ndivd = n / d;
					divisorUpperBound = ndivd;
					if(!EMath.IsPrime(d + ndivd))
					{
						return false;
					}
					tempN /= d;
					if(tempN % d == 0)
					{
						return false;
					}
				}
				d = d == 2 ? 3 : d + 2;
			}
			return true;
		}

		static bool ActualCheck(long n)
		{
			long tempN = n;
			long d = 2;
			while(tempN > 1)
			{
				if(tempN % d == 0)
				{
					if(!EMath.IsPrime(d + n / d))
					{
						return false;
					}
					tempN /= d;
				}
				else
				{
					d += 1;
				}
			}
			return true;
		}
	}
}
