using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_32
{
	class Program
	{
		static void Main(string[] args)
		{
			int sum = 0;
			for(int n = 2345; n < 8342; n++)
			{
				if(IsValid(n))
				{
					sum += n;
				}
			}
			Console.WriteLine("Sum: {0}", sum);
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

		public static bool IsValid(int n)
		{
			if(!IsPandigital(n))
			{
				return false;
			}

			for(int i = 2; i < n / 2; i++)
			{
				if(n % i == 0)
				{
					string s = i.ToString() + (n / i).ToString() + n;
					if(s.Length == 9 && IsPandigital(s))
					{
						Console.WriteLine("{0} x {1} = {2}", i, n / i, n);
						return true;
					}
				}
			}
			return false;
		}

		public static bool IsPandigital(string n)
		{
			bool[] chars = new[] {false, false, false, false, false, false, false, false, false, false};
			foreach(char c in n)
			{
				if(chars[c - '0'])
				{
					return false;
				}
				chars[c - '0'] = true;
			}
			return !chars[0];
		}

		public static bool IsPandigital(int n)
		{
			return IsPandigital(n.ToString());
		}
	}
}