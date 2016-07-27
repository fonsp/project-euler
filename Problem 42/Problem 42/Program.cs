using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_42
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			long result = 0;
			foreach(string word in EData.P42Words)
			{
				long sum = 0;
				for(int i = 0; i < word.Length; i++)
				{
					sum += word[i] - '@';
				}
				if(EMath.IsTriangular(sum))
				{
					result++;
				}
			}
			EMisc.End(result);
		}
	}
}
