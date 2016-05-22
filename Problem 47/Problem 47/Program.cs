using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_47
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			int count = 0;
			for(long i = 1;; i++)
			{
				if(EMath.GetPrimeFactors(i).Distinct().Count() == 4)
				{
					count++;
					if(count == 4)
					{
						EMisc.End(i - 3);
					}
				}
				else
				{
					count = 0;
				}
			}
		}
	}
}
