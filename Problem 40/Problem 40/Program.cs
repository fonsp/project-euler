using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_40
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			long result = 1;
			List<long> counts = new List<long>() {0};
			long last = 0;
			for(long i = 0; last < 1000000; i++)
			{
				long count = (i+1) * 9 * EMath.IntPow(10, (int)i);
				last += count;
				counts.Add(last);
			}

			for(int i = 0; i <= 6; i++)
			{
				long digitN = EMath.IntPow(10, i) - 1;
				int n = counts.Count - 1;
				while(counts[n] > digitN)
				{
					n--;
				}
				long x = EMath.IntPow(10, n) + (digitN - counts[n]) / (n+1);
				long d = long.Parse(x.ToString()[(int) ((digitN - counts[n]) % (n+1))].ToString());
				result *= d;
				//Console.WriteLine("d{0} = {1}", digitN + 1, d);
			}
			EMisc.End(result);
		}
	}
}
