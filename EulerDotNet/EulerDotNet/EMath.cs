using System;
using System.Collections.Generic;
using System.Numerics;

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

		// a > b plz
		public static bool AreRelativePrimes(long a, long b)
		{
			if(b > a)
			{
				return AreRelativePrimes(b, a);
			}
			if(b == 1)
			{
				return true;
			}
			if(a % b == 0)
			{
				return false;
			}
			long p = 2;
			for(int i = 1; p < b; i++)
			{
				if(a % p == 0 && b % p == 0)
				{
					return false;
				}
				p = GetPrime(i);
			}
			return true;
		}

		public static long GreatesCommonDenomitor(long a, long b)
		{
			long c;
			while(b != 0)
			{
				c = a % b;
				a = b;
				b = c;
			}
			return a;
		}

		public static int GreatesCommonDenomitor(int a, int b)
		{
			int c;
			while(b != 0)
			{
				c = a % b;
				a = b;
				b = c;
			}
			return a;
		}

		public static long TriangularNumber(long n)
		{
			return n * (n + 1) / 2;
		}

		public static bool IsTriangular(long n)
		{
			long root;
			if(!IsPerfectSquare(8 * n + 1, out root))
			{
				return false;
			}
			return (root - 1) % 2 == 0;
		}

		public static long PentagonalNumber(long n)
		{
			return n * (3 * n - 1) / 2;
		}

		public static bool IsPentagonal(long n)
		{
			long root;
			if(!IsPerfectSquare(24 * n + 1, out root))
			{
				return false;
			}
			return (1 - root) % 6 == 0;
		}

		public static long HexagonalNumber(long n)
		{
			return n * (2 * n - 1);
		}

		public static bool IsHexagonal(long n)
		{
			long root;
			if(!IsPerfectSquare(8 * n + 1, out root))
			{
				return false;
			}
			return (1 - root) % 4 == 0;
		}

		public static int CountDigits(long n)
		{
			int count = 0;
			for(; n > 0; count++)
			{
				n /= 10;
			}
			return count;
		}

		public static int CountDigits(int n)
		{
			int count = 0;
			for(; n > 0; count++)
			{
				n /= 10;
			}
			return count;
		}

		private static BigInteger ten = new BigInteger(10);
		public static int CountDigits(BigInteger n)
		{
			int count = 0;
			for(; n > BigInteger.Zero; count++)
			{
				n /= ten;
			}
			return count;
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

		public static bool IsPalindromic(DecimalNumber n)
		{
			for(int i = 0; i < (n.Count + 1) / 2; i++)
			{
				if(n[i] != n[n.Count - i - 1])
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsPalindromic(long n)
		{
			return IsPalindromic(new DecimalNumber(n));
		}

		public static bool IsLychrel(DecimalNumber n, int maxIterations, bool verbose = false)
		{
			if(verbose) { Console.WriteLine("{0}, {1}", n, maxIterations); }
			if(maxIterations < 0)
			{
				return true;
			}
			if(IsPalindromic(n))
			{
				return false;
			}
			return IsLychrel(n + n.Reversed(), maxIterations - 1);
		}

		// ReSharper disable once InconsistentNaming
		public static long nCr(long n, long r)
		{
			if(r > n / 2)
			{
				return nCr(n, n - r);
			}
			long result = 1;
			for(long i = 1 + n - r; i <= n; i++)
			{
				result *= i;
			}
			for(long i = 1; i <= r; i++)
			{
				result /= i;
			}
			return result;
		}

		// ReSharper disable once InconsistentNaming
		public static double nCrApproximate(long n, long r)
		{
			if(r > n / 2)
			{
				return nCrApproximate(n, n - r);
			}
			double result = 1;
			for(long i = 1 + n - r; i <= n; i++)
			{
				result *= i;
			}
			for(long i = 1; i <= r; i++)
			{
				result /= i;
			}
			return result;
		}

		private static long[] A000041 = { 1, 1, 2, 3, 5, 7, 11, 15, 22, 30, 42, 56, 77, 101, 135, 176, 231, 297, 385, 490, 627, 792, 1002, 1255, 1575, 1958, 2436, 3010, 3718, 4565, 5604, 6842, 8349, 10143, 12310, 14883, 17977, 21637, 26015, 31185, 37338, 44583, 53174, 63261, 75175, 89134, 105558, 124754, 147273, 173525 };
		// A000041
		public static int NPartitions(long n)
		{
			/*if(n < A000041.Length)
			{
				return A000041[n];
			}*/
			/*long total = 1;
			for(long max = n - 1; max > 0; max--)
			{
				long remainder = n - max;
				total += NPartitions(remainder, max);
			}
			return total;*/

			for(; lastN <= n; lastN++)
			{
				for(long max = 1; max <= lastN; max++)
				{
					NPCache.Add((NPartitions(lastN - max, max) + NPartitions(lastN, max - 1)) % 1000000);
				}
			}

			return NPartitions(n, n);
		}

		private static long lastN = 1;
		private static List<int> NPCache = new List<int>(100000000);
		private static int NPartitions(long n, long max)
		{
			if(max < 1 || n < 0)
			{
				return 0;
			}
			if(max == 1 || n <= 1)
			{
				return 1;
			}
			if(max > n)
			{
				return NPartitions(n, n);
			}

			return NPCache[(int)((n * (n - 1) / 2) + max - 1)];


			long sum = 0;
			/*for(long numOfMaxBlocks = n / max; numOfMaxBlocks >= 0; numOfMaxBlocks--)
			{
				sum += NPartitions(n - numOfMaxBlocks * max, max - 1);
			}*/
			return NPartitions(n - max, max) + NPartitions(n, max - 1);
		}

		public static double Sqrt2 = 1.41421356237309504880168872420969807856967187537694807317667973799;
		public static double Sqrt2Half = 0.70710678118654752440084436210485;
	}

	public class DecimalNumber : List<int>
	{
		public DecimalNumber(long n)
		{
			while(n > 0)
			{
				Add((int)(n % 10));
				n /= 10;
			}
		}
		public DecimalNumber() : base()
		{

		}

		public long ToLong()
		{
			long result = 0;
			for(int i = 0; i < Count; i++)
			{
				result *= 10;
				result += this[i];
			}
			return result;
		}

		public DecimalNumber Reversed()
		{
			Trim();
			DecimalNumber result = new DecimalNumber();
			for(int i = 0; i < Count; i++)
			{
				result.Add(this[Count - i - 1]);
			}
			return result;
		}

		public void Trim()
		{
			if(this.Count == 0)
			{
				return;
			}
			if(this[Count - 1] == 0)
			{
				RemoveAt(Count - 1);
			}
		}

		public override string ToString()
		{
			string result = "";
			for(int i = 0; i < Count; i++)
			{
				result += this[Count - i - 1];
			}
			return result;
		}


		public static DecimalNumber operator +(DecimalNumber a, DecimalNumber b)
		{
			int carry = 0;
			DecimalNumber result = new DecimalNumber();
			int aCount = a.Count;
			int bCount = b.Count;

			for(int i = 0; i < Math.Max(aCount, bCount); i++)
			{
				if(i < aCount)
				{
					carry += a[i];
				}
				if(i < bCount)
				{
					carry += b[i];
				}
				result.Add(carry % 10);
				carry /= 10;
			}
			if(carry != 0)
			{
				result.Add(carry);
			}
			return result;
		}

	}
}