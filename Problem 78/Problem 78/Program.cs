using System;
using System.Numerics;
using EulerDotNet;

namespace Problem_78
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			for(long i = 1; true; i++)
			{
				int np = EMath.NPartitions(i);
				Console.WriteLine(i);
				if(np == 0)
				{
					EMisc.End(i);
				}
			}
		}
	}
}