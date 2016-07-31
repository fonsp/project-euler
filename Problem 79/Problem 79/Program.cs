using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_79
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			string[] keys = File.ReadAllLines("keylog.txt");
			List<string> keysList = keys.ToList();
			keys = keysList.Distinct().ToArray();
			
			List<OrderPair> pairs = new List<OrderPair>();

			for(char x = '0'; x <= '9'; x++)
			{
				if(x == '4')
				{
					x='6';
				}
				for(char y = (char) (x + 1); y <= '9'; y++)
				{
					while(y == '4' || y == '5')
					{
						y++;
					}
					if(ComesBefore(keys, x, y))
					{
						Console.WriteLine(x + " < " + y);
						pairs.Add(new OrderPair(x, y));
					}
					if(ComesBefore(keys, y, x))
					{
						Console.WriteLine(y + " < " + x);
						pairs.Add(new OrderPair(y, x));
					}
				}
			}
			string word = "";
			while(pairs.Count > 1)
			{
				char x = FindNextChar(ref pairs);
				for(int i = 0; i < pairs.Count; i++)
				{
					if(pairs[i].b == x)
					{
						pairs.RemoveAt(i);
						i--;
					}
				}
				word = x + word;
			}
			if(pairs.Count == 1)
			{
				word = pairs[0].a + "" + pairs[0].b + word;
			}

			EMisc.End(word);
		}

		static char FindNextChar(ref List<OrderPair> pairs)
		{
			for(char x = '0'; x <= '9'; x++)
			{
				bool valid = false;
				for(int i = 0; i < pairs.Count; i++)
				{
					if(pairs[i].b == x)
					{
						valid = true;
					}
				}
				if(valid)
				{
					for(int i = 0; i < pairs.Count; i++)
					{
						if(pairs[i].a == x)
						{
							valid = false;
						}
					}
				}
				if(valid)
				{
					return x;
				}
			}
			throw new Exception();
		}

		static bool ComesBefore(string[] keys, char a, char b)
		{
			foreach(string key in keys)
			{
				if(key[0] == b)
				{
					if(key[1] == a || key[2] == a)
					{
						return false;
					}
				}
				if(key[1] == b)
				{
					if(key[2] == a)
					{
						return false;
					}
				}
			}
			return true;
		}

		static bool Check(string word, string[] keys)
		{
			foreach(string key in keys)
			{
				int n = 0;
				for(int i = 0; i < 3; i++)
				{
					char current = key[i];
					while(n < word.Length && word[n] != current)
					{
						n++;
					}
					if(n == word.Length)
					{
						return false;
					}
				}
			}
			return true;
		}
	}

	struct OrderPair
	{
		public char a, b;

		public OrderPair(char a, char b)
		{
			this.a = a;
			this.b = b;
		}

		public override string ToString()
		{
			return a + "" + b;
		}
	}
}
