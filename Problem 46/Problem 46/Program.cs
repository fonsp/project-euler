using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_46
{
	class Program
	{
		static void Main(string[] args)
		{
			long i = 9;
			while(true)
			{
				i += 2;
				if(!EMath.IsPrime(i))
				{
					if(!Check(i))
					{
						EMisc.End(i);
					}
				}
			}
		}

		static bool Check(long i)
		{
			long doubleSquare = 0;
			long x = 1;
			while(doubleSquare < i)
			{
				doubleSquare = 2 * x * x;
				int index = 0;
				long sum = 0;
				while(sum < i)
				{
					sum = EMath.GetPrime(index) + doubleSquare;
                    index++;
				}
				if(sum == i)
				{
					return true;
				}
				x++;
			}
			return false;
		}
	}
}
