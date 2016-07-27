using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_53
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			int count = 0;
			for(long n = 1; n <= 100; n++)
			{
				for(long r = 1; r <= n; r++)
				{
					if(EMath.nCrApproximate(n, r) > 1000000)
					{
						count++;
					}
				}
			}
			EMisc.End(count);
		}
	}
}
