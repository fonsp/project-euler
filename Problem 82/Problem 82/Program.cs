using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;
using System.IO;

namespace Problem_82
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			loadMatrix("matrix.txt");
			for(int i = 0; i < N; i++)
			{
				scores[i, 0] = matrix[i, 0];
			}
			for(int j = 1; j < N; j++)
			{
				for(int i = 0; i < N; i++)
				{
					scores[i, j] = scores[i, j - 1] + matrix[i, j];
				}
				for(int i = 1; i < N; i++)
				{
					scores[i, j] = Math.Min(scores[i, j], scores[i - 1, j] + matrix[i, j]);
				}
				for(int i = N - 2; i >= 0; i--)
				{
					scores[i, j] = Math.Min(scores[i, j], scores[i + 1, j] + matrix[i, j]);
				}
			}
			int min = int.MaxValue;
			for(int i = 0; i < N; i++)
			{
				min = Math.Min(scores[i, N - 1], min);
			}
			EMisc.End(min);
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
