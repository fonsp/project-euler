using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_74
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			EMisc.StartStopwatch();
			EMisc.CurrentSolution = 0;
			for(long i = 1; i < 1000000; i++)
			{
				if(Test(i))
				{
					EMisc.CurrentSolution = (int)EMisc.CurrentSolution + 1;
				}
			}
			EMisc.End();
		}

		static Func<int, long> Fac = new LookUpMethodList<long>(EMath.Factorial).Get;

		static bool Test(long input)
		{
			List<long> chain = new List<long>();
			for(int length = 0; length < 60; length++)
			{
				if(chain.Contains(input))
				{
					return false;
				}
				chain.Add(input);
				input = EMath.GetDigits(input).Sum(digit => Fac((int) digit));
			}
			return true;
		}
	}
}
