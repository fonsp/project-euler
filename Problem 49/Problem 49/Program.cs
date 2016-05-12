using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_49
{
	class Program
	{
		static void Main(string[] args)
		{
			for(int j = 1001; j < 10000; j += 2)
			{
				if(IsPrime(j))
				{
					primes.Add(j);
				}
			}

			int i = 0;
			while(i < primes.Count)
			{
				var list = GetPermutations(primes[i]);
				LeavePrimes(ref list);
				foreach(int prime in list)
				{
					primes.Remove(prime);
				}
				if(list.Count >= 3)
				{
					var diffs = new List<int>();
					for(int j = 0; j < list.Count - 1; j++)
					{
						diffs.Add(list[j + 1] - list[j]);
					}
					while(diffs.Count >= 2)
					{
						for(int j = 0; j < diffs.Count - 1; j++)
						{
							if(diffs[j] == diffs[j + 1])
							{
								Console.WriteLine("{0}: {1}, {2}, {3}", diffs[j], list[j], list[j+1], list[j+2]);
							}
						}
						int best = -1;
						int sum = int.MaxValue;
						for(int j = 0; j < diffs.Count - 1; j++)
						{
							int s = diffs[j] + diffs[j + 1];
							if(s < sum)
							{
								best = j;
								sum = s;
							}
						}
						diffs[best] = diffs[best] + diffs[best + 1];
						diffs.RemoveAt(best+1);
						list.RemoveAt(best+1);
					}
				}
			}

			Console.ReadKey();
		}

		public static List<int> GetPermutations(int n)
		{
			List<int> output = new List<int>();
			List<int> digits = new List<int>();
			int x = n;
			for(int i = 0; i < 4; i++)
			{
				digits.Add(x % 10);
				x /= 10;
			}
			for(int i = 0; i < 24; i++)
			{
				x = i;
				var temp = digits.ToArray().ToList();

				int result = 0;
				for(int j = 4; j >= 1; j--)
				{
					result *= 10;
					result += temp[x % j];
					temp.RemoveAt(x % j);
					x /= j;
				}
				if(result > 1000)
				{
					output.Add(result);
				}
			}
			output = output.Distinct().ToList();
			output.Sort();
			foreach(int i in output)
			{
				//Console.WriteLine(i);
			}
			return output;
		}

		public static void LeavePrimes(ref List<int> list)
		{
			int i = 0;
			while(i < list.Count)
			{
				if(IsPrime(list[i]))
				{
					i++;
				}
				else
				{
					list.RemoveAt(i);
				}
			}
		}

		private static List<int> primes = new List<int>();

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
