using System;
using System.Collections.Generic;

namespace EulerDotNet
{
	public class LookUpMethodList<T>
	{
		public List<T> values = new List<T>();
		private int valueCount = 0;
		public Func<long, T> method;

		public LookUpMethodList(Func<long, T> method)
		{
			this.method = method;
		}

		public T Get(int input)
		{
			while(valueCount - 1 < input)
			{
				values.Add(method(valueCount++));
			}
			return values[input];
		}
	}

	public class LookUpMethodDictionary<T>
	{
		public Dictionary<int, T> values = new Dictionary<int, T>();
		public Func<long, T> method;

		public LookUpMethodDictionary(Func<long, T> method)
		{
			this.method = method;
		}

		public T Get(int input)
		{
			if(!values.ContainsKey(input))
			{
				T output = method(input);
				values.Add(input, output);
				return output;
			}
			return values[input];
		}
	}

	public class LookUpMethodDictionary<TIn, TOut>
	{
		public Dictionary<TIn, TOut> values = new Dictionary<TIn, TOut>();
		public Func<TIn, TOut> method;

		public LookUpMethodDictionary(Func<TIn, TOut> method)
		{
			this.method = method;
		}

		public TOut Get(TIn input)
		{
			if(!values.ContainsKey(input))
			{
				TOut output = method(input);
				values.Add(input, output);
				return output;
			}
			return values[input];
		}
	}
}