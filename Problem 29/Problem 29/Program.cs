using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_29
{
	public class Power
	{
		public int a, b;

		public Power(int a, int b)
		{
			this.a = a;
			this.b = b;
		}

		public override bool Equals(object obj)
		{
			if(obj == null)
			{
				return false;
			}
			Power x = (Power)obj;
			if(x.b * a == b * a && x.a * b == a * b)
			{
				return true;
			}
			if(x.b < b)
			{
				return x.Equals(this);
			}
			return a == ConvertPower(x, b).a;
		}

		public override int GetHashCode()
		{
			return a ^ b;
		}

		public override string ToString()
		{
			return a + "^" + b + " = " + Math.Pow(a, b);
		}

		public static int GreatestCommonDivisor(int x, int y)
		{
			if(x < y)
			{
				return GreatestCommonDivisor(y, x);
			}
			if(y == 0)
			{
				return x;
			}
			return GreatestCommonDivisor(y, x % y);
		}

		public static Power ConvertPower(Power power, int newPower)
		{
			Power output = new Power(1, newPower);
			for(int p = 2; p <= power.a; p++)
			{
				if(IsPrime(p))
				{
					int n = CountDivisors(power.a, p);
					if((n * power.b) % newPower != 0)
					{
						return new Power(-1, -1);
					}
					for(int i = 0; i < (n * power.b) / newPower; i++)
					{
						output.a *= p;
					}
				}
			}
			return output;
		}

		public static int CountDivisors(int x, int y)
		{
			int i = 0;
			while(x != 1)
			{
				if(x % y != 0)
				{
					return i;
				}
				x = x / y;
				i++;
			}
			return i;
		}

		public static bool IsPrime(int n)
		{
			for(int i = 2; i <= n / 2; i++)
			{
				if(n % i == 0)
				{
					return false;
				}
			}
			return true;
		}
	}

	public class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine(Power.ConvertPower(new Power(4, 3), 2));
			//Console.WriteLine();

			List<Power> powers = new List<Power>();
			
			Console.Write("[          ]\b\b\b\b\b\b\b\b\b\b\b");
			for(int a = 2; a <= 100; a++)
			{
				for(int b = 2; b <= 100; b++)
				{
					Power power = new Power(b, a);
					if(!powers.Contains(power))
					{
						powers.Add(power);
						//Console.WriteLine(power);
					}
					/*foreach(Power p in powers)
					{
						if(!p.Equals(power) && (Math.Pow(p.a, p.b) == Math.Pow(power.a, power.b)))
						{
							int z = 1 + 1;
						}
					}*/
				}
				if(a % 10 == 0)
				{
					Console.Write("=");
				}
			}
			Console.WriteLine();
			Console.WriteLine("Distinct powers: {0}", powers.Count);
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}
