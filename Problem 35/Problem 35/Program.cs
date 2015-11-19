using System;
using System.Collections.Generic;

namespace Problem_35
{
	class Program
	{
		static void Main(string[] args)
		{
			/*List<int[]> rotations = Rotations(543210);
			rotations.Reverse();*/

			List<int> result = new List<int>() {2, 3, 5, 7};
			List<int> ones = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
			for(int i = 2; i < 7; i++)
			{
				Console.WriteLine("======== {0} digits", i);
				//FindCircularPrimes(rotations, 6, result, i, ones.GetRange(0, i).ToArray(), i - 1);
				FindCircularPrimes(result, i, ones.GetRange(0, i).ToArray(), i - 1);
			}

			foreach(int i in result)
			{
				Console.WriteLine(i);
			}

			Console.WriteLine();
			Console.WriteLine("{0} results", result.Count);
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		private static void FindCircularPrimes(List<int> result, int digits, int[] current, int level)
		{

			if(level == digits - 1)
			{
				if(CheckRotations(current, digits))
				{
					result.Add(DigitArrayToInt(current));
				}
			}
			if(current[level] == 9)
			{
				if(level == 0)
				{
					return;
				}
				current[level] = 1;
				if(level != digits - 1)
				{
					current[level] -= 2;
				}
				level--;
			}
			else
			{
				current[level] += 2;
				if(level != digits - 1)
				{
					level++;
				}
			}
			FindCircularPrimes(result, digits, current, level);
		}

		private static bool CheckRotations(int[] current, int digits)
		{
			for(int i = 0; i < digits; i++)
			{
				int[] currentShuffle = new int[digits];
				for(int j = 0; j < digits; j++)
				{
					currentShuffle[j] = current[(i + j) % digits];
				}
				if(!IsPrime(currentShuffle))
				{
					return false;
				}
			}
			return true;
		}

		/*private static void FindCircularPrimes(List<int[]> rotations, int rotationCount, List<int> result, int digits, int[] current, int level)
		{

			if(level == digits - 1)
			{
				if(CheckPermutations(rotations, rotationCount, digits, current))
				{
					result.Add(DigitArrayToInt(current));
				}
			}
			if(current[level] == 9)
			{
				if(level == 0)
				{
					return;
				}
				current[level] = 1;
				if(level != digits - 1)
				{
					current[level] -= 2;
				}
				level--;
			}
			else
			{
				current[level] += 2;
				if(level != digits - 1)
				{
					level++;
					//TODO: increase all following digits to the current digit
				}
			}
			FindCircularPrimes(rotations, rotationCount, result, digits, current, level);
		}
		
		private static bool CheckPermutations(List<int[]> rotations, int rotationCount, int digits, int[] current)
		{
			int[] currentShuffle = new int[digits];
			for(int i = 0; i < Factorial(digits); i++)
			{
				for(int j = 0; j < digits; j++)
				{
					currentShuffle[j] = current[rotations[i][rotationCount - j - 1]];
				}
				if(!IsPrime(currentShuffle))
				{
					return false;
				}
			}
			return true;
		}*/

		/*public static List<int[]> Rotations(int input)
		{
			List<int> inputDigits = new List<int>();
			while(input > 0)
			{
				inputDigits.Add(input % 10);
				input /= 10;
			}

			int n = inputDigits.Count;
			int nfac = Factorial(inputDigits.Count);
			int[][] results = new int[nfac][];
			for(int i = 0; i < nfac; i++)
			{
				results[i] = new int[n];
				results[i][0] = inputDigits[i * n / nfac];
			}

			Rotate(results, inputDigits.ToArray(), 1);

			List<int[]> output = new List<int[]>();
			for(int i = 0; i < nfac; i++)
			{
				output.Add(results[i]);
			}
			return output;
		}

		private static void Rotate(int[][] results, int[] digits, int level)
		{
			int nfac = results.Length;
			int n = digits.Length;

			int count = Factorial(n - level - 1);
			for(int a = 0; a < nfac / count; a++)
			{
				int digit = ValidDigit(results[a * count], digits, n, level, a % (n - level));
				for(int b = 0; b < count; b++)
				{
					results[a * count + b][level] = digit;
				}
			}
			if(level < n - 1)
			{
				Rotate(results, digits, level + 1);
			}
		}

		private static int ValidDigit(int[] result, int[] digits, int n, int level, int start)
		{
			int index = 0;
			for(int i = 0; i < n; i++)
			{
				int currentDigit = digits[index];
				bool valid = true;
				for(int j = 0; j < level; j++)
				{
					if(result[j] == currentDigit)
					{
						index++;
						valid = false;
					}
				}
				if(valid)
				{
					if(start == 0)
					{
						return currentDigit;
					}
					start--;
					index++;
				}
			}
			return -999999;
		}

		private static int Factorial(int n)
		{
			int output = 1;
			for(int i = 1; i <= n; i++)
			{
				output *= i;
			}
			return output;
		}*/


		public static bool IsPrime(int p)
		{
			for(int i = 3; i < Math.Sqrt(p) + 1; i += 2)
			{
				if(p % i == 0)
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsPrime(int[] p)
		{
			return IsPrime(DigitArrayToInt(p));
		}

		public static int DigitArrayToInt(int[] digits)
		{
			int n = 0;
			foreach(int d in digits)
			{
				n *= 10;
				n += d;
			}
			return n;
		}
	}
}