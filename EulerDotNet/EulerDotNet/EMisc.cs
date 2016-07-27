using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace EulerDotNet
{
	public class EMisc
	{
		public static Stopwatch stopwatch = new Stopwatch();
		public static bool displayTime = false;
		private static object currentSolution = null;

		public static object CurrentSolution
		{
			get
			{
				return currentSolution;
			}
			set
			{
				currentSolution = value;
				Console.Title = "Current solution: " + currentSolution;
			}
		}

		public static void StartStopwatch()
		{
			stopwatch.Start();
			displayTime = true;
		}
		public static string ArrayToString<T>(T[] x)
		{
			// TODO: support List
			if(x == null)
			{
				return null;
			}
			if(x.Length == 0)
			{
				return "{}";
			}
			string output = "{" + x[0];
			for(int i = 1; i < x.Length; i++)
			{
				output += ", " + x[i];
			}
			return output + "}";
		}

		public static void End<T>(T[] result)
		{
			End(ArrayToString(result));
		}

		public static void End<T>(T result)
		{
			Console.WriteLine();
			if(displayTime)
			{
				stopwatch.Stop();
				Console.WriteLine("Solution: {0}, solved in {1} ms", result, stopwatch.ElapsedMilliseconds);
			}
			else
			{
				Console.WriteLine("Solution: {0}", result);
			}
			Console.WriteLine(CopyToClipboard(result)? "Copied to clipboard!": "Failed to copy to clipboard :(");

			Console.ReadKey();
			Environment.Exit(0);
		}

		public static void End()
		{
			Console.WriteLine();
			if(currentSolution == null)
			{
				currentSolution = "no solution";
			}
			End(currentSolution);
		}

		public static bool CopyToClipboard<T>(T data)
		{
			try
			{
				Clipboard.SetText(data.ToString());
				return true;
			}
			catch(Exception e)
			{
				return false;
			}
		}

		public static void Swap<T>(ref T a, ref T b)
		{
			T temp = a;
			a = b;
			b = temp;
		}

		/// <summary>
		/// Steinhaus-Johnson-Trotter algorithm iterates through all permutations of a given array by swapping two values on each iteration.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="array"></param>
		/// <param name="dirs">A byte array of length n filled with zeroes</param>
		/// <param name="n">Length of array and dirs</param>
		/// <param name="minValue">Minimal value of the given type</param>
		public static bool IteratePermutation<T>(T[] array, byte[] dirs, long n, T minValue) where T : IComparable
		{
			int largestMobI = -1;
			T largestMob = minValue;
			int dir = 0;
			for(int j = 0; j < n; j++)
			{
				T value = array[j];
				if(j < n - 1 && dirs[j] == 1 && value.CompareTo(array[j + 1]) > 0)
				{
					if(value.CompareTo(largestMob) >= 0)
					{
						largestMob = value;
						largestMobI = j;
						dir = 1;
					}
				}
				if(j > 0 && dirs[j] == 0 && value.CompareTo(array[j - 1]) > 0)
				{
					if(value.CompareTo(largestMob) >= 0)
					{
						largestMob = value;
						largestMobI = j;
						dir = -1;
					}
				}
			}
			if(largestMobI == -1)
			{
				return false;
			}
			Swap(ref array[largestMobI], ref array[largestMobI + dir]);
			Swap(ref dirs[largestMobI], ref dirs[largestMobI + dir]);
			for(int j = 0; j < n; j++)
			{
				if(array[j].CompareTo(largestMob) > 0)
				{
					dirs[j] = (byte)(dirs[j] ^ 1);
				}
			}
			return true;
		}

		[Obsolete("Remove i parameter")]
		public static bool IteratePermutation<T>(T[] array, byte[] dirs, long i, long n, T minValue) where T : IComparable
		{
			return IteratePermutation(array, dirs, n, minValue);
		}
	}

	public class MultiThreader<T>
	{
		public readonly int nThreads;
		public readonly Func<long, long> rangeMethod;
		public readonly Func<T, long> listMethod; 
		public long min, max;
		public IList<T> inputList; 
		private long[] sums;
		private Thread[] pool;

		private void DoWorkRange(int threadNum)
		{
			for(long i = threadNum; i < 1 + max - min; i += nThreads)
			{
				sums[threadNum] += rangeMethod(i + min);
			}
			Console.WriteLine("{0} done", threadNum);
		}

		private void DoWorkList(int threadNum)
		{
			for(int i = threadNum; i < inputList.Count; i += nThreads)
			{
				sums[threadNum] += listMethod(inputList[i]);
			}
			Console.WriteLine("{0} done", threadNum);
		}

		public MultiThreader(int nThreads, Func<long, long> method, long min, long max)
		{
			this.nThreads = nThreads;
			this.rangeMethod = method;
			this.max = max;
			this.min = min;
			pool = new Thread[nThreads];
			sums = new long[nThreads];
			for(int i = 0; i < nThreads; i++)
			{
				int threadNum = i;
				pool[i] = new Thread(() => DoWorkRange(threadNum));
			}
		}

		public MultiThreader(int nThreads, Func<T, long> method, IList<T> inputList)
		{
			this.nThreads = nThreads;
			this.listMethod = method;
			this.inputList = inputList;
			pool = new Thread[nThreads];
			
			for(int i = 0; i < nThreads; i++)
			{
				int threadNum = i;
				pool[i] = new Thread(() => DoWorkList(threadNum));
			}
		}

		public long Get()
		{
			sums = new long[nThreads];
			for(int i = 0; i < nThreads; i++)
			{
				pool[i].Start();
			}
			bool done = false;
			while(!done)
			{
				done = true;
				for(int i = 0; i < nThreads; i++)
				{
					if(pool[i].IsAlive)
					{
						done = false;
						i = nThreads;
					}
				}
				Thread.Sleep(10);
			}
			return sums.Sum();
		}
	}
}