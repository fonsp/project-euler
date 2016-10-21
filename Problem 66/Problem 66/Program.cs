using EulerDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem_66
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			List<int> test = Enumerable.Range(1, 1000).ToList();
			List<List<long>> factors = new List<List<long>>();



			long best = -1;
			for(int i = 0; i < test.Count; i++)
			{
				
				long D = test[i];
				if(EMath.IsPerfectSquare(D))
				{
					test.RemoveAt(i);
					i--;
				}
				else
				{
					factors.Add(EMath.GetPrimeFactors(D).Distinct().ToList());
					factors[i].Sort();
				}
			}
			long step = 10000;
			for(long maxlong = 2 + step; test.Count > 0; maxlong += step)
			{
				Console.WriteLine("{0}, {1} remaining", maxlong, test.Count);
				for(int i = 0; i < test.Count; i++)
				{
					long D = test[i];

					long x = minX(D, maxlong - step, maxlong, factors[i]);
					//Console.WriteLine("{0}: {1}", D, x);
					if(x != -1)
					{
						test.RemoveAt(i);
						i--;

						if(x > best)
						{
							EMisc.CurrentSolution = D;
							best = x;
						}
					}
				}
			}
			EMisc.End();
		}

		static long minX(long D, long minlong, long maxlong, List<long> factors)
		{
			long x = minlong;
			while(x < 3037000498 && x <= maxlong)
			{
				//if(relprime(x,factors))
				//{
					long xs = S(x) - 1;
					if(xs % D == 0)
					{
						if(EMath.IsPerfectSquare(xs / D))
						{
							return x;
						}
						/*if(isSquare(xs / D))
						{
							return x;
						}*/
					}
				//}
				x++;
			}
			while(x <= maxlong)
			{
				BigInteger xs = S(x) - BigInteger.One;
				BigInteger rem;
				BigInteger div = BigInteger.DivRem(xs, D, out rem);
				if(rem == 0)
				{
					if(isSquare(div))
					{
						return x;
					}
				}
				x++;
			}
			return -1;
		}

		static bool relprime(long x, List<long> factors)
		{
			for(int i = 0; i < factors.Count && i < 7; i++)
			{
				if(x % factors[i] == 0)
				{
					return false;
				}
			}
			return true;
		}

		/*static long minX(long D)
		{
			long x = 2;
			while(true)
			{
				BigInteger xs = S(x) - BigInteger.One;
				BigInteger rem;
				BigInteger div = BigInteger.DivRem(xs, D, out rem);
				if(rem == 0)
				{
					if(EMath.IsPerfectSquare(div))
					{
						return x;
					}
				}
				x++;
			}
		}*/

		static long currentI = 0;
		static long currentMax = 0;
		static List<long> steps = new List<long>();

		static bool isSquare(long x)
		{
			while(currentMax < x)
			{
				long p = currentI + currentI + 1;
				currentI++;
				currentMax += p;
				steps.Add(p);
			}
			int i = 0;
			long currentSum = 0;
			while(currentSum < x)
			{
				currentSum += steps[i];
				i++;
			}
			return x == currentSum;
		}

		static double sqrt(BigInteger x)
		{
			return Math.Exp(BigInteger.Log(x) / 2.0);
		}

		static bool isSquare(BigInteger x)
		{
			BigInteger n = new BigInteger(sqrt(x));
			BigInteger square = n * n;
			while(square > x)
			{
				n = n - BigInteger.One;
				square = n * n;
			}
			while(square < x)
			{
				n = n - BigInteger.One;
				square = n * n;
			}
			return square == x;
		}

		static long S(long x)
		{
			return x * x;
		}

		static BigInteger S(BigInteger x)
		{
			return x * x;
		}
	}
}
