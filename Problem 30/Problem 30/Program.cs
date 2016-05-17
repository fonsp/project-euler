using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_30
{
	public class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			long sum = 0;
			for(long i = 11; i < 1000000; i++)
			{
				List<long> digits = EMath.GetDigits(i);
				long num = 0;
				foreach(int digit in digits)
				{
					num += EMath.IntPow(digit, 5);
				}
				if(num == i)
				{
					Console.WriteLine(i);
					sum += i;
				}
			}

			EMisc.End(sum);
		}
	}
}
