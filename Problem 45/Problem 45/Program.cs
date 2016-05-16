using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;


namespace Problem_45
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			long t=0, p=0, h=0;
			long tValue=1, pValue=1, hValue=1;
			while(true)
			{
				long max = Math.Max(tValue, Math.Max(pValue, hValue));
				if(tValue == pValue && pValue == hValue)
				{
					if(max > 40755)
					{
						EMisc.End(max);
					}
					Console.WriteLine(max);
					max++;
				}
				while(tValue < max)
				{
					t++;
					tValue = EMath.TriangularNumber(t);
				}
				while(pValue < max)
				{
					p++;
					pValue = EMath.PentagonalNumber(p);
				}
				while(hValue < max)
				{
					h++;
					hValue = EMath.HexagonalNumber(h);
				}
			}
		}
	}
}
