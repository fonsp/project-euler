using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EulerDotNet
{
	/// <summary>
	/// Extended math library
	/// </summary>
	public class EMath
	{
		public static bool IsPrime(decimal i)
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
			if(i == 5)
			{
				return true;
			}
			decimal n = 0, x;
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

		public static bool IsPrime(long i)
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
			if(i == 5)
			{
				return true;
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
			if(i == 5)
			{
				return true;
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
		}

		public static long GetPrime(int index)
		{
			long last = EData.primeList[EData.primeList.Count - 1];
			while(EData.primeList.Count < index + 1)
			{
				last += 2;
				if(IsPrime(last))
				{
					EData.primeList.Add(last);
				}
			}
			return EData.primeList[index];
		}

		public static List<long> GetPrimeFactors(long n)
		{
			List<long> output = new List<long>();
			int i = 0;
			while(n > 1)
			{
				long p = GetPrime(i);
				while(n % p == 0)
				{
					output.Add(p);
					n /= p;
				}
				i++;
			}
			return output;
		} 

		public static long TriangularNumber(long n)
		{
			return n * (n + 1) / 2;
		}

		public static long PentagonalNumber(long n)
		{
			return n * (3 * n - 1) / 2;
		}

		public static long HexagonalNumber(long n)
		{
			return n * (2 * n - 1);
		}

		public static List<long> GetDigits(long n)
		{
			List<long> output = new List<long>();
			while(n > 0)
			{
				output.Add(n % 10);
				n /= 10;
			}
			return output;
		}

		public static long FromDigits(long[] digits)
		{
			long value = 0;
			for(int i = 0; i < digits.Length; i++)
			{
				value *= 10;
				value += digits[i];
			}
			return value;
		}

		public static long FromDigits(int[] digits)
		{
			long value = 0;
			for(int i = 0; i < digits.Length; i++)
			{
				value *= 10;
				value += digits[i];
			}
			return value;
		}

		public static decimal FromDigitsToDecimal(long[] digits)
		{
			decimal value = 0;
			for(int i = 0; i < digits.Length; i++)
			{
				value *= 10;
				value += digits[i];
			}
			return value;
		}

		public static long IntPow(long x, int y)
		{
			if(y < 0)
			{
				throw new ArgumentException();
			}
			if(y == 0)
			{
				return 1;
			}
			long result = x;
			while(y > 1)
			{
				result *= x;
				y--;
			}
			return result;
		}

		public static bool IsPerfectSquare(long n)
		{
			if(n < 0)
			{
				return false;
			}
			switch((int)(n & 0xF))
			{
				case 0:
				case 1:
				case 4:
				case 9:
					long x = (long)Math.Sqrt(n);
					return x * x == n;
				default:
					return false;
			}
		}

		public static bool IsPerfectSquare(long n, out long root)
		{
			root = -1;
			if(n < 0)
			{
				return false;
			}
			switch((int)(n & 0xF))
			{
				case 0:
				case 1:
				case 4:
				case 9:
					root = (long)Math.Sqrt(n);
					return root * root == n;
				default:
					return false;
			}
		}

		public static long Factorial(long n)
		{
			long result = 1;
			while(n > 1)
			{
				result *= n;
				n--;
			}
			return result;
		} 
	}

	public class EMisc
	{
		public static Stopwatch stopwatch = new Stopwatch();
		public static bool displayTime = false;

		public static void StartStopwatch()
		{
			stopwatch.Start();
			displayTime = true;
		}
		public static string ArrayToString<T>(T[] x)
		{
			// TODO: support List
			if(x == null)
			{
				return null;
			}
			if(x.Length == 0)
			{
				return "{}";
			}
			string output = "{" + x[0];
			for(int i = 1; i < x.Length; i++)
			{
				output += ", " + x[i];
			}
			return output + "}";
		}

		public static void End<T>(T[] result)
		{
			End(ArrayToString(result));
		}

		public static void End<T>(T result)
		{
			Console.WriteLine();
			if(displayTime)
			{
				stopwatch.Stop();
				Console.WriteLine("Solution: {0}, solved in {1} ms", result, stopwatch.ElapsedMilliseconds);
			}
			else
			{
				Console.WriteLine("Solution: {0}", result);
			}
			try
			{
				Clipboard.SetText(result.ToString());
				Console.WriteLine("Copied to clipboard!");
			}
			catch(Exception e)
			{
				Console.WriteLine("Failed to copy to clipboard :(");
			}

			Console.ReadKey();
			Environment.Exit(0);
		}

		public static void Swap<T>(ref T a, ref T b)
		{
			T temp = a;
			a = b;
			b = temp;
		}

		/// <summary>
		/// Steinhaus-Johnson-Trotter algorithm iterates through all permutations of a given array by swapping two values on each iteration.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array"></param>
		/// <param name="dirs">A byte array of length n filled with zeroes</param>
		/// <param name="n">Length of array and dirs</param>
		/// <param name="minValue">Minimal value of the given type</param>
		public static bool IteratePermutation<T>(T[] array, byte[] dirs, long n, T minValue) where T : IComparable
		{
			int largestMobI = -1;
			T largestMob = minValue;
			int dir = 0;
			for(int j = 0; j < n; j++)
			{
				T value = array[j];
				if(j < n - 1 && dirs[j] == 1 && value.CompareTo(array[j + 1]) > 0)
				{
					if(value.CompareTo(largestMob) >= 0)
					{
						largestMob = value;
						largestMobI = j;
						dir = 1;
					}
				}
				if(j > 0 && dirs[j] == 0 && value.CompareTo(array[j - 1]) > 0)
				{
					if(value.CompareTo(largestMob) >= 0)
					{
						largestMob = value;
						largestMobI = j;
						dir = -1;
					}
				}
			}
			if(largestMobI == -1)
			{
				return false;
			}
			Swap(ref array[largestMobI], ref array[largestMobI + dir]);
			Swap(ref dirs[largestMobI], ref dirs[largestMobI + dir]);
			for(int j = 0; j < n; j++)
			{
				if(array[j].CompareTo(largestMob) > 0)
				{
					dirs[j] = (byte) (dirs[j] ^ 1);
				}
			}
			return true;
		}

		[Obsolete("Remove i parameter")]
		public static bool IteratePermutation<T>(T[] array, byte[] dirs, long i, long n, T minValue) where T : IComparable
		{
			return IteratePermutation(array, dirs, n, minValue);
		}
	}
}