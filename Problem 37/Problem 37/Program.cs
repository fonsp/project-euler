using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_37
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			new Program2();
		}

		private long[] left = new long[] { 2, 3, 5, 7 };
		private long[] middle = new long[] { 1, 3, 7, 9 };
		private long[] right = new long[] { 3, 7, 9 };

		private long found = 0;
		private long sum = 0;
		private long i = 10;
		private long length = 2;
		private long[] indices = new long[] { 0, 0 };
		public Program()
		{
			while(found < 11)
			{
				i = left[indices[0]];
				for(long x = 0; x < length - 2; x++)
				{
					i *= 10;
					i += middle[indices[1 + x]];
				}
				i *= 10;
				i += right[indices[length - 1]];

				if(i < 0)
				{
					Console.WriteLine(i);
				}

				Check();

				bool done = false;
				long pos = length - 1;
				while(!done)
				{
					if(pos == -1)
					{
						length++;
						Console.WriteLine(length);
						indices = new long[length];
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
			if(!EMath.IsPrime(i))
			{
				i++;
				return;
			}
			long length = 1;
			long n = i / 10;
			while(n > 0)
			{
				if(!EMath.IsPrime(n))
				{
					i += Power10(length);
					return;
				}
				n /= 10;
				length++;
			}
			for(long p = length - 1; p > 0; p--)
			{
				if(!EMath.IsPrime(i % Power10(p)))
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

		static List<long> powers = new List<long>() { 1 };
		public static long Power10(long power)
		{
			while(powers.Count < power + 1)
			{
				powers.Add(10 * powers[powers.Count - 1]);
			}
			return powers[(int)power];
		}

		static List<long> longPowers = new List<long>() { 1 };
		public static long longPower10(long power)
		{
			while(longPowers.Count < power + 1)
			{
				longPowers.Add(10 * longPowers[powers.Count - 1]);
			}
			return longPowers[(int)power];
		}
	}

	class Program2
	{
		private long sum = 0;
		private long found = 0;
		private long length = 2;
		private long[] digits = new long[] {1, 3, 7, 9};
		private long[] number = new long[] {-1, -1};
		
		public Program2()
		{
			while(found < 11)
			{
				Check(lasti);
			}
			EMisc.End(sum);
		}

		public int lasti = 0;

		void Check(int i)
		{
			if(i == -1)
			{
				length++;
				number = new long[length];
				for(int x = 0; x < length; x++)
				{
					number[x] = -1;
				}
				if(found < 11)
				{
					lasti = 0;
				}
				return;
			}
			if(i == length)
			{
				long n = EMath.FromDigits(number);
				//Console.WriteLine(n);
				if(CheckBackWards(n))
				{
					found++;
					Console.WriteLine(n);
					sum += n;
				}
				lasti = i - 1;
				return;
			}
			if(number[i] == 9)
			{
				number[i] = -1;
				lasti = i - 1;
				return;
			}
			number[i] += 2;
			if(i == 0)
			{
				if(number[i] == 4)
				{
					number[i] = 3;
				}
				if(number[i] == 1)
				{
					number[i] = 2;
				}
			}
			if(EMath.IsPrime(EMath.FromDigits(number.Take(i + 1).ToArray())))
			{
				lasti = i + 1;
			}
		}

		static bool CheckBackWards(long i)
		{
			long length = 0;
			long x = i;
			while(x > 0)
			{
				x /= 10;
				length++;
			}
			for(long p = length - 1; p > 0; p--)
			{
				if(!EMath.IsPrime(i % Program.Power10((int)p)))
				{
					return false;
				}
			}
			return true;
		}
	}
}
