using System;
using System.Numerics;
using EulerDotNet;

namespace Problem_57
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			EMisc.StartStopwatch();
			long sum = 0;
			BigInteger a = 1, b = 1;
			for(int i = 0; i < 1000; i++)
			{
				a += b;
				EMisc.Swap(ref a, ref b);
				a += b;
				BigInteger gcd = BigInteger.GreatestCommonDivisor(a, b);
				a /= gcd;
				b /= gcd;
				if(EMath.CountDigits(a) > EMath.CountDigits(b))
				{
					sum++;
				}
			}
			EMisc.End(sum);
		}
	}
}