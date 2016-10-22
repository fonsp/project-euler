using EulerDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_91
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			EMisc.StartStopwatch();
			MultiThreader<long> n = new MultiThreader<long>(4, (x => Iterate(x)), 0, 50 * 50 - 1);
			EMisc.End(n.Get());
		}

		static long Iterate(long index)
		{
			return CountXY(2 + index / 50, 2 + index % 50);
		}

		static long CountXY(long x, long y)
		{
			long sum = 0;
			for(long ix = 0; ix <= x - 1; ix++)
			{
				for(long iy = 0; iy <= y - 1; iy++)
				{
					if(ix == x - 1 && iy == y - 1)
					{
						continue;
					}
					long asq = S(ix) + S(y - 1);
					long bsq = S(iy) + S(x - 1);
					long csq = S(x - 1 - ix) + S(y - 1 - iy);

					if(asq + bsq == csq || asq + csq == bsq || bsq + csq == asq)
					{
						sum++;
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
