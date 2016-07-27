using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_97
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			DecimalNumber two = new DecimalNumber(1);
			for(int i = 0; i < 7830457; i++)
			{
				two = Add(two, two);
			}
			DecimalNumber result = new DecimalNumber(0);
			for(int i = 0; i < 28433; i++)
			{
				result = Add(two, result);
			}
			result += new DecimalNumber(1);
			EMisc.End("..." + result);
		}

		static DecimalNumber Add(DecimalNumber a, DecimalNumber b)
		{
			int carry = 0;
			DecimalNumber result = new DecimalNumber();
			int aCount = a.Count;
			int bCount = b.Count;

			for(int i = 0; i < Math.Min(10, Math.Max(aCount, bCount)); i++)
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
