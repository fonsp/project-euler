using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_85
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			EMisc.StartStopwatch();
			const long N = 2000000;
			long bestDist = 2000000;
			for(long k = 1; k < 2000; k++)
			{
				long n = Convert.ToInt64(Math.Floor((Math.Sqrt(1 + 16 * N / (k * k + k) - 1.0)) / 2.0));
				for(int i = 0; i < 2; i++)
				{
					long sum = n * k * (n + 1) * (k + 1) / 4;
					long dist = Math.Abs(sum - N);
					if(dist < bestDist)
					{
						bestDist = dist;
						EMisc.CurrentSolution = n * k;
					}
					n++;
				}
			}
			EMisc.End();
		}
	}
}
