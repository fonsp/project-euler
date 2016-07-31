using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_76
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			EMisc.StartStopwatch();
			EMisc.End(EMath.NPartitions(100)-1);
		}
	}
}
