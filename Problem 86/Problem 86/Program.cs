using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_86
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			/*string output = "";
			long M = 1;
			long c = 1;
			while(c <= 15000)
			{
				M++;
				c = Count(M);
				Console.WriteLine("{0}\t{1}",M,c);
				output += M + "," + c + "\r\n";
			}
			File.WriteAllText("output.txt",output);
			EMisc.End(M);*/
			long M = 0;
			long c = 0;
			while(c <= 1000000)
			{
				M++;
				c += Count(M);
				Console.WriteLine(M+ ", " + c);
			}
			EMisc.End(M);
		}

		static long Count(long M)
		{
			long xS, yS, zS, sum = 0;
			for(long x = M; x <= M; x++)
			{
				xS = S(x);
				for(long y = 1; y <= x; y++)
				{
					yS = S(y);
					for(long z = 1; z <= y; z++)
					{
						zS = S(z);
						long[] lengths = new long[3];
						lengths[0] = xS + S(y + z);
						lengths[1] = yS + S(x + z);
						lengths[2] = zS + S(x + y);
						if(EMath.IsPerfectSquare(lengths.Min()))
						{
							sum++;
						}
					}
				}
			}
			return sum;
		}

		static long S(long x)
		{
			return x * x;
		}
	}
}
