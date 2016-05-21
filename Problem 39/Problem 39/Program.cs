using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_39
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> squares = new List<int>();
			for(int i = 1; i <= 500; i++)
			{
				squares.Add(i * i);
			}
			int result = -1;
			int best = -1;
			for(int p = 1; p <= 1000; p++)
			{
				int count = 0;
				for(int x = 1; x < p / 2; x++)
				{
					int m = p * (p - 2 * x);
					int n = 2 * (p - x);
					if(m % n == 0)
					{
						int y = m / n;
						if(squares.Contains(x * x + y * y))
						{
							count++;
						}
					}
				}
				if(count > best)
				{
					best = count;
					result = p;
				}
			}
			EMisc.End(result);
		}
	}
}
