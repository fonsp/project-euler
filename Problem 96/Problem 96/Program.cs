using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_96
{
	class Program
	{
		static void Main(string[] args)
		{
			/*string[] lines = File.ReadAllLines("sudoku.txt");
			string[] output = new string[lines.Length / 10];
            for(int b = 0; b < lines.Length / 10; b++)
            {
	            output[b] = "";
				for(int i = 1; i < 10; i++)
				{
					output[b] += lines[i + 10 * b].Replace('0', '.');
				}
			}
			File.WriteAllLines("sudoku81.txt", output);*/

			EMisc.End(File.ReadAllLines("sudoku81solved.txt").Sum(line => Convert.ToInt64(line.Substring(0, 3))));
		}
	}
}