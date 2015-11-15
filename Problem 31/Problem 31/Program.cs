using System;

namespace Problem_31
{
	class Program
	{
		static void Main(string[] args)
		{
			int total = 0;

			Derp(new int[] { 0, 0, 0, 0, 0, -1 }, new int[] { 200, 100, 50, 20, 10, 5, 2 }, 5, 200, ref total);

			Console.WriteLine("Result: {0}", total);
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		static void Derp(int[] values, int[] coins, int level, int max, ref int total)
		{
			values[level]++;

			int sum = 0;
			for(int i = 0; i < values.Length; i++)
			{
				sum += Math.Max(0, values[i]) * coins[i];
			}
			if(level == values.Length - 1)
			{
				total += 1 + (max - sum) / coins[values.Length];
			}
			else if(sum == max)
			{
				total += 1;
			}

			/*Console.Write("[");
			foreach(int value in values)
			{
				Console.Write("{0}, ", value);
			}
			Console.WriteLine("\b\b]: {0}", total);*/

			if(sum >= max)
			{
				values[level] = -1;
				level--;
			}
			else if(level < values.Length - 1)
			{
				level++;
			}

			if(level < 0)
			{
				return;
			}
			Derp(values, coins, level, max, ref total);
		}
	}
}