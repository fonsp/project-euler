using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_100
{
	class Program
	{

		[STAThread]
		static void Main(string[] args)
		{
			BigInteger n = 2, b;
			Console.WriteLine(EMath.Sqrt2Half);
			double prev = .01;
			while(true)
			{
				if(Asdf(n, out b))
				{
					double nD = (double) n;
					double ratio = nD / prev;
					prev = nD;
					Console.WriteLine("{0}/{1}, {2}, {3}", b, n, (double)b / (double)n, ratio);
					
					if(n > BigInteger.Pow(10, 12))
					{
						EMisc.End(b);
					}
					if(ratio < 10)
					{
						n = new BigInteger(nD * ratio);
					}
					else
					{
						n++;
					}
				}
				else
				{
					n++;
				}
			}
		}

		static bool Asdf(BigInteger n, out BigInteger b)
		{
			BigInteger x;
			/*double sqrt = Math.Exp(BigInteger.Log(n) / 2);

			b = new BigInteger(Math.Floor(sqrt));*/
			b = new BigInteger(Math.Floor((double)n * EMath.Sqrt2Half));
			n = n * (n - 1) / 2;
			x = b * (b + 1);
			while(x > n)
			{
				b--;
				x = b * (b + 1);
			}
			while(x < n)
			{
				b++;
				x = b * (b + 1);
			}
			if(x == n)
			{
				b++;
				return true;
			}
			return false;
		}
	}
}
