using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_69
{
	class Program
	{
		static long bestN = -1;
		static double bestRatio = 0;

		[STAThread]
		static void Main(string[] args)
		{
			Node n = new Node();
			n.length = 1;
			n.primeIndices = new List<int>() {0};
			n.primeFactors = new List<long>() {2};
			n.value = 2;

			while(n.length != 0)
			{
				n.Iterate();
			}

			EMisc.End(bestN);
		}

		public static void Test(long n, List<long> primeFactors)
		{
			List<long> distinct = primeFactors.Distinct().ToList();
			long phi = 1;
			for(long i = 3; i <= n/2; i+=2)
			{
				// This repeats every block of (product of distinct)

				if(RelativePrimes(distinct, i))
				{
					phi++;
				}
			}
			phi *= 2;
			double ratio = ((double)n) / ((double)phi);
			if(ratio > bestRatio)
			{
				bestRatio = ratio;
				bestN = n;
				Console.WriteLine("{0}, {1} with ratio {2}", EMisc.ArrayToString(EMath.GetPrimeFactors(n).ToArray()), n, ratio);
				EMisc.CurrentSolution = n;
			}
		}

		private static bool RelativePrimes(List<long> distinct, long i)
		{
			for(int j = 0; j < distinct.Count; j++)
			{
				if(i % distinct[j] == 0)
				{
					return false;
				}
			}
			return true;
		}
	}

	class Node
	{
		public int length = -1;
		public List<long> primeFactors = new List<long>();
		public List<int> primeIndices = new List<int>();
		public long value;

		public void Iterate()
		{
			if(value <= 1000000)
			{
				Program.Test(value, primeFactors);
			}

			int lastIndex = primeIndices[length - 1];
			long lastPrime = primeFactors[length - 1];
			long newValue = value * lastPrime;
			if(newValue <= 1000000)
			{
				length++;
				value = newValue;
				primeIndices.Add(lastIndex);
				primeFactors.Add(lastPrime);
			}
			else
			{
				long newPrime = EMath.GetPrime(lastIndex + 1);
				newValue = (value / lastPrime) * newPrime;
				if(newValue <= 1000000)
				{
					value = newValue;
					primeFactors[length - 1] = newPrime;
					primeIndices[length - 1] = lastIndex + 1;
				}
				else
				{
					if(length == 0)
					{
						throw new Exception("No more iteration possible");
					}
					length--;
					value /= lastPrime;
					primeIndices.RemoveAt(length);
					primeFactors.RemoveAt(length);
					lastIndex = primeIndices[length - 1];
					lastPrime = primeFactors[length - 1];
					primeIndices[length - 1] = lastIndex + 1;
					newPrime = EMath.GetPrime(lastIndex + 1);
					primeFactors[length - 1] = newPrime;
					value = (value / lastPrime) * newPrime;
				}
			}
		}
	}
}
