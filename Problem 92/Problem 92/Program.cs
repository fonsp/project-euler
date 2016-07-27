using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_92
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			long sum = 0;
			for(int i = 1; i < 1000; i++)
			{
				if(ChainEndsAt89(i))
				{
					sum++;
					Cache89[i] = true;
				}
				else
				{
					Cache89[i] = false;
				}
			}
			for(int i = 1000; i < 10000000; i++)
			{
				if(EndsAt89(i))
				{
					sum++;
				}
			}
			EMisc.End(sum);
		}

		static bool[] Cache89 = new bool[1000];
		static bool EndsAt89(long n)
		{
			if(n < 1000)
			{
				return Cache89[n];
			}
			return EndsAt89(Iterate(n));
		}

		static bool ChainEndsAt89(long n)
		{
			if(n == 89)
			{
				return true;
			}
			if(n == 1)
			{
				return false;
			}
			return ChainEndsAt89(Iterate(n));
		}

		static long Iterate(long n)
		{
			var x = EMath.GetDigits(n);
			return x.Sum(z => z * z);
		}
	}
}
