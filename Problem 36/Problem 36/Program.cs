using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_36
{
	class Program
	{
		private int sum = 0;
		public Program(string[] args)
		{
			for(int i = 1; i < 1000000; i++)
			{
				Result(i);
			}
			Console.WriteLine("Solution: {0}", sum);
			Console.ReadKey();
		}

		void Result(int i)
		{
			int n = i;
			int binLength = 0;
			while(n != 0)
			{
				binLength++;
				n = n >> 1;
			}
			if(!BinIsSymmetrical(i, binLength))
			{
				return;
			}
			int reverse = 0;
			n = i;
			while(n != 0)
			{
				reverse *= 10;
				reverse += n % 10;
				n /= 10;
			}
			if(reverse != i)
			{

				return;
			}
			sum += i;
		}

		public bool BinIsSymmetrical(int n, int binLength)
		{
			for(int i = 0; i < binLength/2; i++)
			{
				if((n >> i) % 2 != (n >> (binLength - i - 1)) % 2)
				{
					return false;
				}
			}
			return true;
		}

		static void Main(string[] args)
		{
			new Program(args);
		}
	}
}
