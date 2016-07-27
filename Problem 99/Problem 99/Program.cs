using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_99
{
	struct Number : IComparable<Number>
	{
		public double num, exp;
		public int line;

		public Number(double num, double exp, int line)
		{
			this.num = num;
			this.exp = exp;
			this.line = line;
		}

		public int CompareTo(Number x)
		{
			return (exp * Math.Log(num)).CompareTo(x.exp * Math.Log(x.num));
		}
	}
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			string[] input = File.ReadAllLines("base_exp.txt");
			List<Number> nums = input.Select(line => line.Split(new string[] {","}, StringSplitOptions.None)).Select((split, i) => new Number(Convert.ToDouble(split[0]), Convert.ToDouble(split[1]), i + 1)).ToList();
			nums.Sort((x,y) => x.CompareTo(y));
			EMisc.End(nums.Last().line);
		}
	}
}
