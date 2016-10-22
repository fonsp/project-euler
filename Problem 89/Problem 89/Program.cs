using EulerDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_89
{
	class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			int savings = 0;
			foreach(string s in File.ReadAllLines("roman.txt"))
			{
				savings += s.Length;
				savings -= ToRoman(ToInt(s)).Length;
			}
			EMisc.End(savings);
		}

		static int ToInt(string r)
		{
			int n = 0;
			int i = r.Length - 1;
			while(i > 0)
			{
				int a = GetChar(r[i]);
				int b = GetChar(r[i - 1]);
				if(b < a)
				{
					n += a - b;
					i -= 2;
				}
				else
				{
					n += a;
					i--;
				}
			}
			if(i == 0)
			{
				n += GetChar(r[0]);
			}
			return n;
		}

		static int GetChar(char c)
		{
			switch(c)
			{
				case 'I':
					return 1;
				case 'V':
					return 5;
				case 'X':
					return 10;
				case 'L':
					return 50;
				case 'C':
					return 100;
				case 'D':
					return 500;
				case 'M':
					return 1000;
			}
			return -1;
		}

		static string ToRoman(int n)
		{
			string output = "";
			string[] numerals = new string[] {"M","CM","D","CD","C","XC", "L", "XL", "X", "IX"};
			foreach(string numeral in numerals)
			{
				int bound = ToInt(numeral);
				while(n >= bound)
				{
					n -= bound;
					output += numeral;
				}
			}
			return output + finalRomans[n];
		}

		static string[] finalRomans = new string[] { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII" };
	}
}