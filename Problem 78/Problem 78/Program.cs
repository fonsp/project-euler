using System;
using System.Numerics;
using EulerDotNet;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem_78
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			for (int i = 1; true; i++)
			{
				int np = EMath.NPartitions(i, 1000000);
				Console.WriteLine("{0}\t{1}", i, np);
				//Console.ReadKey();
				if (np == 0)
				{
					EMisc.End(i);
				}
			}
		}
	}
}