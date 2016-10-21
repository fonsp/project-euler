using EulerDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_77
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			for(long n = 10; true; n++)
			{
				if(count(n) > 5000)
				{
					EMisc.End(n);
				}
			}
		}

		static long count(long n)
		{
			long sum = 0;
			long p = 2;
			int i = 0;
			while(p <= n)
			{
				sum += count(n, p);

				i++;
				p = EMath.GetPrime(i);
			}
			return sum;
		}

		static long count(long n, long max)
		{
			if(max < 1 || n < 0 || max > n)
			{
				return 0;
			}
			if(n == max)
			{
				return EMath.IsPrime(n) ? 1 : 0;
			}
			if(max == 1)
			{
				return n % 2 == 0 ? 1 : 0;
			}
			long sum = 0;

			long p = 2;
			int i = 0;
			while(n - max >= p && p <= max)
			{
				sum += count(n - max, p);

				i++;
				p = EMath.GetPrime(i);
			}
			return sum;
		}
	}
}
