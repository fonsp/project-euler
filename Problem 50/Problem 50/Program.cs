using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_50
{
	class Program
	{
		static void Main(string[] args)
		{
			int sum = 0, n = 0;
			for(; sum < 1000000; n++)
			{
				sum += Prime(n);
			}
			int start = 0;
			while(!IsPrime(sum))
			{
				start++;
				if(sum > 1000000)
				{
					start = 0;
					n--;
				}
				sum = 0;
				for(int i = 0; i < n; i++)
				{
					sum += Prime(i + start);
				}
			}
			Console.WriteLine(sum);
			Console.ReadKey();
		}

		private static List<int> primes = new List<int>() {2,3};
		private static int last = 3; 
		public static int Prime(int i)
		{
			while(i >= primes.Count)
			{
				last += 2;
				if(IsPrime(last))
				{
					primes.Add(last);
				}
			}
			return primes[i];
		}

		public static bool IsPrime(int i)
		{
			if(i < 2)
			{
				return false;
			}
			if(i < 4)
			{
				return true;
			}
			if(i % 2 == 0 || i % 3 == 0)
			{
				return false;
			}
			int n = 0, x;
			while(true)
			{
				x = 5 + 3 * n - (n % 2);
				n++;
				if(i % x == 0)
				{
					return false;
				}
				if(x * x > i)
				{
					return true;
				}
			}
		}
	}
}
