using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_26
{
	class Program
	{
		static void Main(string[] args)
		{
			int bestNumber = -1, bestCycle = 0;
			for(int d = 2; d < 1000; d++)
			{
				//Console.Write("1/{0}\t= 0.", d);
				int n = 1, m = 0;
				for(int i = 0; i < PrecedingDigits(d); i++)
				{
					Iterate(ref n, ref m, d);
					//Console.Write(m);
				}
				if(n != 0)
				{
					//Console.Write("(");
					int count = 1;
					Iterate(ref n, ref m, d);
					//Console.Write(m);
					int initialN = n;
					int initialM = m;
					Iterate(ref n, ref m, d);
					while(n != initialN || m != initialM)
					{
						count++;
						//Console.Write(m);
						Iterate(ref n, ref m, d);
					}
					//Console.Write(")");
					if(count > bestCycle)
					{
						bestCycle = count;
						bestNumber = d;
					}
				}
				//Console.WriteLine();
			}
			//Console.WriteLine();
			Console.WriteLine("Best result: 1/{0} has a {1}-digit reciprocal cycle.", bestNumber, bestCycle);
			Console.Write("1/{0} = 0.", bestNumber);
			int na = 1, ma = 0;

			for(int i = 0; i < PrecedingDigits(bestNumber); i++)
			{
				Iterate(ref na, ref ma, bestNumber);
				Console.Write(ma);
			}
			Console.Write("(");
			for(int i = 0; i < bestCycle; i++)
			{
				Iterate(ref na, ref ma, bestNumber);
				Console.Write(ma);
			}
			Console.WriteLine(")");
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		static int PrecedingDigits(int n)
		{
			int div2 = 0;
			while(n % 2 == 0)
			{
				n = n / 2;
				div2++;
			}
			int div5 = 0;
			while(n % 5 == 0)
			{
				n = n / 5;
				div5++;
			}
			return Math.Max(div2, div5);
		}

		static void Iterate(ref int n, ref int m, int d)
		{
			m = (10 * n) / d;
			n = (10 * n) % d;
		}
	}
}
