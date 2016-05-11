using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_37
{
	class Program
	{
		static void Main(string[] args)
		{
			new Program();
		}

		private long[] left = new long[] { 2, 3, 5, 7 };
		private long[] middle = new long[] { 1, 3, 7, 9 };
		private long[] right = new long[] { 3, 7, 9 };

		private long found = 0;
		private long sum = 0;
		private long i = 10;
		private int length = 2;
		private int[] indices = new int[] { 0, 0 };
		public Program()
		{
			while(found < 11)
			{
				i = left[indices[0]];
				for(int x = 0; x < length - 2; x++)
				{
					i *= 10;
					i += middle[indices[1 + x]];
				}
				i *= 10;
				i += right[indices[length - 1]];

				//Console.WriteLine(i);

				Check();

				bool done = false;
				int pos = length - 1;
				while(!done)
				{
					if(pos == -1)
					{
						length++;
						indices = new int[length];
						done = true;
						break;
					}
					indices[pos]++;
					indices[pos] = indices[pos] % (pos == length - 1 ? 3 : 4);
					if(indices[pos] == 0)
					{
						pos--;
					}
					else
					{
						done = true;
					}
				}
				
			}
			Console.WriteLine("Solution: {0}", sum);
			Console.ReadKey();
		}

		void Check()
		{
			if(!IsPrime(i))
			{
				i++;
				return;
			}
			long length = 1;
			long n = i / 10;
			while(n > 0)
			{
				if(!IsPrime(n))
				{
					i += Power10(length);
					return;
				}
				n /= 10;
				length++;
			}
			for(long p = length - 1; p > 0; p--)
			{
				if(!IsPrime(i % Power10(p)))
				{
					i++;
					return;
				}
			}
			Console.WriteLine(i);
			found++;
			sum += i;
			i++;
		}

		List<long> powers = new List<long>() { 1 };
		long Power10(long power)
		{
			while(powers.Count < power + 1)
			{
				powers.Add(10 * powers[powers.Count - 1]);
			}
			return powers[(int)power];
		}

		bool IsPrime(long i)
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
			long n = 0, x;
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

			return true;
		}
	}
}
