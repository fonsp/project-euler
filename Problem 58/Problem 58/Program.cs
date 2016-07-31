using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_58
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			EMisc.StartStopwatch();
			long totalCount = 5, primeCount = 3, sideLength = 2, n = 9;
			while(primeCount * 10 >= totalCount)
			{
				sideLength+=2;
				for(int i = 0; i < 3; i++)
				{
					n += sideLength;
					if(EMath.IsPrime(n))
					{
						primeCount++;
					}
				}
				n += sideLength;
				totalCount += 4;
			}
			EMisc.End(sideLength+1);
		}
	}
}
