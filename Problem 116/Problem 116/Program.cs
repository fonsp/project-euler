using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem_116
{
	class State
	{
		public long n;
		public long[] indices;

		public State(long n)
		{
			this.n = n;
			indices = new long[n];
			for(long i = 0; i < n; i++)
			{
				indices[i] = -1;
			}
		}
	}
	class Program
	{
		public const long L = 50; 
		public static long[] sums = new long[3];
		static void Main(string[] args)
		{
			Thread[] threads = new Thread[3];
			for(long c = 2; c <= 4; c++)
			{
				var c1 = c;
				threads[c-2] = new Thread(() => ComputeSum(c1));
				threads[c-2].Start();
			}

			bool busy = true;
			while(busy)
			{
				Thread.Sleep(10);
				busy = false;
				for(long c = 2; c <= 4; c++)
				{
					if(threads[c - 2].IsAlive)
					{
						busy = true;
					}
				}
			}

			long sum = 0;
			for(long c = 2; c <= 4; c++)
			{
				sum += sums[c - 2];
			}
			Console.WriteLine("Solution: {0}", sum);
			File.WriteAllText("solution.txt", sum.ToString());
			Console.ReadKey();
		}

		public static void ComputeSum(long c)
		{
			sums[c - 2] += 1 + L - c;
			for(long n = 2; n <= L / c; n++)
			{
				long[] indices = new long[n - 1];
				for(long i = 0; i < n - 1; i++)
				{
					indices[i] = c * i;
				}
				while(indices != null)
				{
					indices = Compute(c, n, indices);
				}
				Console.WriteLine("C: {0}, N: {1}/{2}, S[{0}]: {3}", c, n, L/c, sums[c - 2]);
				Console.Title = n + "/" + L / c;
			}
		}

		public static bool running = true;

		public static long[] Compute(long c, long n, long[] indices)
		{
			if(indices.Length != n - 1)
			{
				throw new ArgumentException();
			}

			/*
			long cursor = 0;
			for(long i = 0; i < n - 1; i++)
			{
				while(cursor < indices[i])
				{
					Console.Write(".");
					cursor++;
				}
				Console.Write("[");
				for(long x = 0; x < c-2; x++)
				{
					Console.Write("#");
				}
				Console.Write("]");
				cursor += c;
			}
			while(cursor < L)
			{
				Console.Write(".");
				cursor++;
			}
			Console.WriteLine();
			*/
			sums[c - 2] += 1 + L - indices[n - 2] - 2 * c;

			if(indices[0] == L - c * n)
			{
				running = false;
				return null;
			}

			bool done = false;
			long depth = 1;
			while(!done)
			{
				indices[n - depth - 1]++;
				for(long i = n - depth; i <= n - 2; i++)
				{
					indices[i] = indices[i - 1] + c;
				}
				if(indices[n - 2] <= L - 2*c)
				{
					done = true;
				}
				depth++;
			}
			running = true;
			return indices;
		}
	}
}