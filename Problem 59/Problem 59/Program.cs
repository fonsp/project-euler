using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EulerDotNet;

namespace Problem_59
{
	class Program
	{
		private static byte[] cypher;
		private static int cypherLength;

		[STAThread]
		static void Main(string[] args)
		{
			cypherLength = EData.P59Bytes.Length;
			cypher = new byte[cypherLength];
			for(int i = 0; i < cypherLength; i++)
			{
				cypher[i] = (byte) EData.P59Bytes[i];
			}
			byte[] key = new byte[3];
			for(int offset = 0; offset < 3; offset++)
			{
				long best = long.MinValue;
				for(byte x = (byte) 'a'; x <= 'z'; x++)
				{
					long test = Test(x, offset);
					if(test > best)
					{
						key[offset] = x;
						best = test;
					}
				}
			}
			EMisc.End(GetResult(key));
		}

		static long Test(byte key, int offset)
		{
			long count = 0;
			for(int i = offset; i < cypherLength; i += 3)
			{
				byte x = (byte) (cypher[i] ^ key);
				if(x < 9)
				{
					return long.MinValue;
				}
				if(x > 13 && x < ' ')
				{
					return long.MinValue;
				}
				if(x == ' ')
				{
					count += 5;
				}
				count++;
			}
			return count;
		}

		static long GetResult(byte[] key)
		{
			long result = 0;
			for(int i = 0; i < cypherLength; i++)
			{
				result += cypher[i] ^ key[i % 3];
			}
			return result;
		}
	}
}
