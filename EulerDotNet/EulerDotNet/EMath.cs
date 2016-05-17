using System;
using System.Collections.Generic;
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
				output.Add(n%10);
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
			long result = x;
			while(y > 1)
			{
				result *= x;
				y--;
			}
			return result;
		}
	}

	public class EMisc
	{
		public static string ArrayToString<T>(T[] x)
		{
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
			Console.WriteLine("Solution: {0}", result);
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
	}
}