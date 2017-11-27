using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem_433
{
	class Solver
	{
		ulong N;

		ushort[,] preComputed;

		ushort[] preComputedCompact;
		int compactIndicer(ulong x, ulong y)
		{
			return (int)(x * (x + 1) / 2 + y);
		}

		ulong highestManhattanDistance = 0;

		ulong manhattanDistance(ulong x, ulong y)
		{
			return x + y - 2;
		}

		ushort Eprecomp(ulong x, ulong y)
		{
			if(y > x)
			{
				return Eprecomp(y, x);
			}
			if(y == 0)
			{
				return 0;
			}
			//return preComputed[x - 1, y - 1];
			return preComputedCompact[compactIndicer(x - 1, y - 1)];
		}

		ushort E(ulong x, ulong y)
		{
			if(y > x)
			{
				return (ushort)(1+E(y, x));
			}
			if (y == 0)
			{
				return 0;
			}
			if(x == y)
			{
				return 1;
			}
			ushort res;
			if (manhattanDistance(x, y) < highestManhattanDistance)
			{
				res = (ushort)(1 + E(y, x % y));
			}
			else
			{
				res = (ushort)(1 + E(y, x % y));
			}
			//preComputed[x - 1, y - 1] = res;
			//preComputedCompact[compactIndicer(x - 1, y - 1)] = res;
			return res;
		}

		public Solver(ulong N)
		{
			this.N = N;
			//preComputed = new ushort[N, N];
			//++preComputedCompact = new ushort[N * (N + 1) / 2];
			for(ulong dist = 0; dist <= N-1; dist++)
			{
				for(ulong x = 0; x < (dist+1) / 2; x++)
				{
					//Console.WriteLine("{0} {1} {2}", dist, 1 + dist - x, 1 + x);
					E(1 + dist - x, 1+ x);
				}
				highestManhattanDistance = dist + 1;
			}
			for (ulong dist = N-1; dist > 0; dist--)
			{
				for (ulong x = 0; x < (dist + 1) / 2; x++)
				{
					//Console.WriteLine("{0} {1} {2}", dist, 1 + N - 1 - x, 1 + N - 1 - (dist - 1 - x));
					E(1 + N - 1 - x, 1 + N - 1 - (dist - 1 - x));
				}
				highestManhattanDistance = 2 * N - dist;
			}
			/*
			Console.WriteLine(E(1, 1));
			Console.WriteLine(E(10, 6));
			Console.WriteLine(E(6, 10));*/
		}

		public ulong S()
		{
			ulong sum = 0;
			foreach (var point in preComputedCompact)
			{
				sum += point;
			}
			return sum;
		}
	}

	class SecondSolver
	{
		ulong N;
		ulong CacheLim;
		// Based on the first 400 values of S(N) I deduce that the max value in the cache follows
		// max(E(x,y) | x,y<=N) = 3.15 * N^.238
		// https://docs.google.com/spreadsheets/d/16oyqzbsVKLeNczkYWMcWTZ3_5wmfKVFldmptNhfI0ZA/edit?usp=sharing
		// in this case, max(E(x,y) | x,y<=5e6) = 124
		byte[][] cache;

		ulong highestYComputed = 0;

		byte E(ulong x, ulong y)
		{
			if(y > x)
			{
				return (byte)(1+E(y, x));
			}
			if(y == x)
			{
				return 1;
			}
			if(y == 0)
			{
				return 0;
			}
			if(y <= highestYComputed)
			{
				return cache[y - 1][(x - y) % y];
			}
			return (byte)(1 + E(y, x % y));
		}

		public ulong Sum = 0;

		public void BuildCache()
		{
			Console.Clear();
			Console.SetCursorPosition(0, 0);
			Console.WriteLine("Cache: ");
			Console.WriteLine("Done: ");
			bool writeToCache = true;
			for(ulong y = 1; y <= N; y++)
			{
				if(y == CacheLim + 1)
				{
					writeToCache = false;
				}
				ulong limit = Math.Min(y, N + 1 - y);
				var column = new byte[limit];
				ulong columnSum = 0;
				for(ulong ax = 0; ax < limit; ax++)
				{
					var val = E(ax + y, y);
					column[ax] = val;
					columnSum += val;
					//Console.SetCursorPosition((int)(2 * y), (int)(2 * (ax + y)));
					//Console.Write(E(ax + y, y));
				}
				//Console.WriteLine(columnSum);
				ulong columnCount = ((N + 1 - y) / y);
				Sum += columnCount * columnSum;
				for(ulong ax = 0; ax < N - columnCount*y - (y-1); ax++)
				{
					Sum += column[ax];
				}
				if (writeToCache)
				{
					cache[y - 1] = column;
					highestYComputed = y;
				} else
				{
					column = null;
				}
				Console.SetCursorPosition(7, 0);
				Console.Write(Math.Min((100 * (y - 1)) / CacheLim, 100).ToString("D3"));
				Console.Write('%');
				Console.SetCursorPosition(6, 1);
				Console.Write(Math.Min((100 * (y - 1)) / N, 100).ToString("D3"));
				Console.Write('%');

			}
			Sum -= N; // extract diagonal
			Sum *= 2; // copy to upper triangle
			Sum += N * (N - 1) / 2; // add 1 to upper triangle
			Sum += N; // return diagonal
		}

		public SecondSolver(ulong N, ulong CacheLim)
		{
			this.N = N;
			this.CacheLim = CacheLim;
			cache = new byte[Math.Min(N,CacheLim)][];
			BuildCache();
		}
	}

	class Program
	{
		static uint E(ulong x, ulong y)
		{
			uint n = 0;
			while(y != 0)
			{
				ulong newy = x % y;
				x = y;
				y = newy;
				n++;
			}
			return n;
		}

		static void Main(string[] args)
		{
			/*var S = new Solver(N).S();
			S *= 2;
			S += N * (N - 1) / 2;
			S += N;
			Console.WriteLine(S);*/
			/*
			ulong N = 10000;
			for (ulong clim = 2500; clim <= 10000; clim += 1500)
			{
				Stopwatch sw = new Stopwatch();
				sw.Start();
				var S = new SecondSolver(N, clim).Sum;
				sw.Stop();
				Console.WriteLine("{0}, {1}", clim, sw.ElapsedMilliseconds);
			}*/
			Stopwatch sw = new Stopwatch();
			sw.Start();
			var S = new SecondSolver(500000, 50000).Sum;
			sw.Stop();
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);

			Console.WriteLine(S);
			Console.ReadKey();

		}
	}
}
