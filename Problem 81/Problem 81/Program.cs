using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;
using System.IO;

namespace Problem_81
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			loadMatrix("matrix.txt");
			scores[0, 0] = matrix[0, 0];
			for(int d = 1; d < 2 * N - 1; d++)
			{
				for(int x = Math.Max(0, d + 1 - N); x < d + 1 - Math.Max(0, d + 1 - N); x++)
				{
					int i = x;
					int j = d - x;

					int value = matrix[i, j];
					scores[i, j] = value + Math.Min(getScore(i - 1, j), getScore(i, j - 1));
					
				}
			}
			EMisc.End(scores[N-1,N-1]);
		}

		static int getScore(int i, int j)
		{
			if(i < 0 || j < 0 || i >= N || j >= N)
			{
				return int.MaxValue / 2;
			}
			return scores[i, j];
		}

		static int[,] matrix;
		static int[,] scores;
		static int N;

		static void loadMatrix(string path)
		{
			string[] lines = File.ReadAllLines(path);
			N = lines.Length;
			matrix = new int[N, N];
			scores = new int[N, N];

			for(int i = 0; i < N; i++)
			{
				string[] line = lines[i].Split(new char[] { ',' });
				for(int j = 0; j < N; j++)
				{
					matrix[i, j] = int.Parse(line[j]);
				}
			}
		}

	}
}
