using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_44
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			for(long d = 0; ; d += 2000000)
			{
				Console.WriteLine(d);
				Search(d);
			}
		}

		static List<long> initialValues = new List<long>() { 0, 0 };

		static void Search(long maxD)
		{
			long bestD = long.MaxValue;

			bool running = true;
			for(long i = 1; running; i++)
			{
				if(initialValues.Count - 1 < i)
				{
					initialValues.Add(0);
				}
				long lastD = GetP(1 + i) - GetP(1);
				if(lastD > maxD)
				{
					running = false;
				}
				long j = initialValues[(int)i];
				for(j = 1; lastD < maxD; j++)
				{
					lastD = i * (3 * i + 6 * j - 1) / 2;
					if(IsP(lastD) && IsP((3 * i * i + 6 * i * j - i + 6 * j * j - 2 * j) / 2))
					{
						if(lastD < bestD)
						{
							bestD = lastD;
						}
						// Solution found!
					}
				}
				initialValues[(int) i] = j - 1;
			}

			if(bestD != long.MaxValue)
			{
				EMisc.End(bestD);
			}
		}

		static List<long> numbers = new List<long>() { 1 };

		static long GetP(long n)
		{
			return EMath.PentagonalNumber(n);
			while(numbers.Count - 1 < n)
			{
				numbers.Add(EMath.PentagonalNumber(numbers.Count));
			}
			return numbers[(int)n];
		}

		static bool IsP(long p)
		{
			long x = 24 * p + 1;
			long root;
			if(!EMath.IsPerfectSquare(x, out root))
			{
				return false;
			}
			return (root + 1) % 6 == 0;
			while(numbers[numbers.Count - 1] < p)
			{
				numbers.Add(EMath.PentagonalNumber(numbers.Count));
			}

			return numbers.Contains(p);
		}
	}
}