using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_55
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			int count = 0;
			for(long i = 1; i < 10000; i++)
			{
				DecimalNumber dn = new DecimalNumber(i);
				if(EMath.IsLychrel(dn + dn.Reversed(), 55))
				{
					count++;
					//Console.WriteLine("yes", i);
				}
				else
				{
					//Console.WriteLine("no", i);
				}
			}
			EMisc.End(count);
		}
	}
}
