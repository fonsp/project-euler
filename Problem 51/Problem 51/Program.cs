using EulerDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_51
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			Console.WriteLine("The result might be:");
			for(int i = 0; i < 19; i++)
			{
				powers[i] = EMath.IntPow(10, i);
			}

			long all = 1;
			for(int l = 2; true; l++)
			{
				all += powers[l-1];

				long count = EMath.IntPow(2, l - 2);
				for (long n = 1; n < count; n++)
				{
					long digits = 0;
					List<int> remaining = new List<int>() { 0 };
					for(int x = 0; x < l - 1; x++)
					{
						if ((n >> x) % 2 == 1)
						{
							digits += powers[x + 1];
						} else
						{
							remaining.Add(x + 1);
						}
					}
					int remainingCount = remaining.Count;
					long secondCount = EMath.IntPow(10, remainingCount);
					for(long nn = 1/* + powers[remainingCount - 1]*/; nn < secondCount; nn+=2)
					{
						long number = 0;
						for(int i = 0; i < remainingCount; i++)
						{
							long currentDigit = powers[remaining[i]];
							number += currentDigit * ((nn / powers[i]) % 10);
						}
						int testr = test(number, digits, 8);
						/*if (testr == 7)
						{
							long p = get(number, digits);
							Console.WriteLine("{0}x{1}\t=> {2}", p, digits, firstPrime7(number, digits, l - remainingCount));

						}*/
						if (testr == 8)
						{
							long p = get(number, digits);
							Console.WriteLine("{0}x{1}\t=> {2}", p, digits, firstPrime(number, digits));

						}
					}
				}
			}

			EMisc.End();
		}

		static long firstPrime(long p, long digits)
		{
			int digitsize = 0;
			long q = digits;
			while (q > 0)
			{
				q /= 10;
				digitsize++;
			}
			long i = 0;
			if(digitsize > 0)
			{
				i = 1;
			}
			for (; i < 10; i++)
			{
				if(EMath.IsPrime(digits*i + p))
				{
					return digits * i + p;
				}
			}
			return -1;
		}

		/*static long firstPrime(long p, long digits)
		{
			int psize = 0, digitsize = 0;
			long q = p;
			while (q > 0)
			{
				q /= 10;
				psize++;
				digits /= 10;
			}
			q = digits;
			while (q > 0)
			{
				q /= 10;
				digitsize++;
			}
			if (digitsize == 0)
			{
				return p;
			}
			long ppow = powers[psize];
			for (long i = powers[digitsize - 1]; i < powers[digitsize]; i++)
			{
				if (EMath.IsPrime(ppow * i + p))
				{
					return ppow * i + p;
				}
			}
			return -1;
		}*/

		static long firstPrime7(long p, long digits, int digitcount)
		{
			int psize = 0, digitsize = 0;
			long q = p;
			while (q > 0)
			{
				q /= 10;
				psize++;
			}
			q = digits;
			List<long> remainingDigits = new List<long>();
			long all = 0;
			int idigit = 0;
			while (q > 0)
			{
				if(q %10 == 1)
				{
					remainingDigits.Add(powers[digitsize]);
					all += powers[idigit];
					idigit++;
				}
				q /= 10;
				digitsize++;
			}
			long i = 1;
			if (digitsize > psize)
			{
				i = powers[digitcount - 1];
			}
			long ppow = powers[psize];
			long dpow = powers[digitcount];
			for (; i < dpow; i++)
			{
				if(i % all == 0)
				{
					continue;
				}
				long n = p;
				q = i;
				for(int j = 0; j < digitcount; j++)
				{
					n += remainingDigits[j] * (q % 10);
					q /= 10;
				}
				if (EMath.IsPrime(n))
				{
					return n;
				}
			}
			return -2;
		}

		static int test(long n, long digits, int nprimes)
		{
			int count = 0;
			for (int i = 0; i < 10; i++)
			{
				if (i > count + 10 - nprimes)
				{
					return -1;
				}
				if (EMath.IsPrime(n))
				{
					count++;
				}
				n += digits;
			}
			return count;
		}

		static long get(long n, long digits)
		{
			for (int i = 0; i < 10; i++)
			{
				if (EMath.IsPrime(n))
				{
					return n;
				}
				n += digits;
			}
			return -1;
		}

		static long[] powers = new long[19];
	}
}