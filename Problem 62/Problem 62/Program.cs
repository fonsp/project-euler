using EulerDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem_62
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			int lastLength = 0;
			long n = 0;
			while (true)
			{
				BigInteger x = new BigInteger(n);
				x = x * x * x;
				List<byte> currentDigits = toDigits(x);
				currentDigits.Sort();
				int length = currentDigits.Count;
				if (length > lastLength)
				{
					foreach(List<long> f in frequency)
					{
						List<BigInteger> results = new List<BigInteger>();
						if(f.Count == 5)
						{
							List<BigInteger> cubes = new List<BigInteger>();
							foreach(long i in f)
							{
								BigInteger z = new BigInteger(i);
								cubes.Add(z * z * z);
							}
							cubes.Sort();
							results.Add(cubes[0]);
						}
						if(results.Count != 0)
						{
							results.Sort();
							EMisc.End(results[0]);
						}
					}


					digits = new List<List<byte>>();
					frequency = new List<List<long>>();
					lastLength = length;
				}
				bool match = false;
				for(int i = 0; i < digits.Count && !match; i++)
				{
					if(equalLists(currentDigits, digits[i], length))
					{
						match = true;
						frequency[i].Add(n);
					}
				}
				if (!match)
				{
					digits.Add(currentDigits);
					frequency.Add(new List<long> { n });
				}
				n++;
				//Console.ReadKey();
			}
		}

		static bool equalLists(List<byte> a, List<byte> b, int length)
		{
			for(int i = 0; i < length; i++)
			{
				if(a[i] != b[i])
				{
					return false;
				}
			}
			return true;
		}

		static List<List<long>> frequency = new List<List<long>>();
		static List<List<byte>> digits = new List<List<byte>>();

		static List<byte> toDigits(BigInteger x)
		{
			List<byte> output = new List<byte>();
			while(x > 0)
			{
				BigInteger rem;
				x = BigInteger.DivRem(x, 10, out rem);
				output.Add((byte)rem);
			}
			//output.Reverse();
			return output;
		}
	}
}
