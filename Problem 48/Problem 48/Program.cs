using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_48
{
	class Program
	{
		static int[] result = new int[10];
		static void Main(string[] args)
		{
			for(long i = 1; i <= 1000; i++)
			{
				int[] temp = ToArray(1);
				for(int j = 1; j <= i; j++)
				{
					temp = Multiply(temp, i);
				}
				result = Add(result, temp);
			}
			for(int i = 0; i < 10; i++)
			{
				Console.Write(result[i]);
			}
			Console.ReadKey();
		}

		static int[] Multiply(int[] x, long y)
		{
			int[] output = new int[10];
			if(y < 10)
			{
				while(y > 0)
				{
					output = Add(output, x);
					y--;
					Fix(output);
				}
				return output;
			}
			while(y > 0)
			{
				int[] temp = Multiply(x, y % 10);
				output = Add(output, temp);

				for(int i = 0; i < 9; i++)
				{
					x[i] = x[i + 1];
				}
				x[9] = 0;
				y /= 10;
			}
			Fix(output);
			return output;
		}

		static int[] Add(int[] x, long y)
		{
			return Add(x, ToArray(y));
		}

		static int[] Add(int[] x, int[] y)
		{
			int[] output = new int[10];
			for(int i = 9; i >= 0; i--)
			{
				output[i] = x[i] + y[i];
			}
			Fix(output);
			return output;
		}

		static int[] ToArray(long x)
		{
			int[] output = new int[10];
			for(int i = 9; i >= 0; i--)
			{
				output[i] = (int)(x % 10);
				x /= 10;
			}
			Fix(output);
			return output;
		}

		static void Fix(int[] x)
		{
			for(int i = 9; i >= 1; i--)
			{
				if(x[i] > 9)
				{
					x[i - 1] += x[i] / 10;
					x[i] = x[i] % 10;
				}
			}
			x[0] = x[0] % 10;
		}
	}
}
