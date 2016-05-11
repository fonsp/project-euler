using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_33
{
	class Program
	{
		static void Main(string[] args)
		{
			new Program(args);
		}

		public int pi = 1, pj = 1;

		public Program(string[] args)
		{
			for(int j = 11; j < 100; j++)
			{
				if(j % 10 == 0)
				{
					j++;
				}
				for(int i = 11; i < j; i++)
				{
					if(i % 10 == 0)
					{
						i++;
					}

					int a = i / 10;
					int b = i % 10;
					int c = j / 10;
					int d = j % 10;
					if(a == c)
					{
						FracEquals(i, j, b, d);
					}
					if(a == d)
					{
						FracEquals(i, j, b, c);
					}
					if(b == c)
					{
						FracEquals(i, j, a, d);
					}
					if(b == d)
					{
						FracEquals(i, j, a, c);
					}
					//FracEquals(i, j, i % 10, j % 10);
					//FracEquals(i, j, i / 10, j % 10);
					//FracEquals(i, j, i % 10, j / 10);
					//FracEquals(i, j, i / 10, j / 10);
				}
			}

			for(int x = 2; x <= Math.Min(pi, pj); x++)
			{
				if(pi % x == 0 && pj % x == 0)
				{
					pi /= x;
					pj /= x;
					x = 1;
				}
			}
			Console.WriteLine("{0}/{1}", pi, pj);

			Console.WriteLine();
			Console.ReadKey();
		}

		public bool FracEquals(int i, int j, int n, int m)
		{
			if(i * m != n * j)
			{
				return false;
			}
			if(i / 10 == i % 10 && j / 10 == j % 10)
			{
				return false;
			}
			if(i == j)
			{
				return false;
			}
			pi *= n;
			pj *= m;
			Console.WriteLine("{0}/{1} = {2}/{3}", i, j, n, m);

			return true;
		}
	}
}
