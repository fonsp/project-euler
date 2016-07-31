using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_56
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			int best = 0;

			BigInteger hundred = new BigInteger(100);
			for(BigInteger a = BigInteger.One; a <= hundred; a++)
			{
				BigInteger x = BigInteger.One;
				for(int b = 1; b <= 100; b++)
				{
					x *= a;
					int sum = DigitSum(x);
					best = Math.Max(sum, best);
				}
			}
			EMisc.End(best);
		}

		static BigInteger ten = new BigInteger(10);

		static int DigitSum(BigInteger n)
		{
			BigInteger sum = BigInteger.Zero;
			BigInteger rem;
			while(n != BigInteger.Zero)
			{
				n = BigInteger.DivRem(n, ten, out rem);
				sum += rem;
			}
			return (int)sum;
		}
	}
}
