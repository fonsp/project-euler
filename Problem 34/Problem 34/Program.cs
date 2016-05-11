using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_34
{
	class Program
	{
		private Program(string[] args)
		{
			int sum = 0;
			for(int i = 3; i < 10000000; i++)
			{
				int n = i, facsum = 0;
				while(n > 0)
				{
					facsum += F(n % 10);
					n /= 10;
				}
				if(i == facsum)
				{
					sum += i;
					Console.WriteLine(i);
				}
			}
			Console.WriteLine("Solution: {0}", sum);
			Console.ReadKey();
		}

		public int F(int n)
		{
			if(n == 0)
			{
				return 1;
			}
			return n * F(n - 1);
		}

		static void Main(string[] args)
		{
			new Program(args);
		}
	}
}

/*
	Max 7 digits: 9! = 362,880. 8 digits > 10,000,000 and < 8 * 9! = 2,903,040.
*/