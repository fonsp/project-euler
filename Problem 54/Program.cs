using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Card
{
	public static char[] Values = new char[]{'2','3','4','5','6','7','8','9','T','J','Q','K','A'};
	public int value;
	public char colour;

	public Card(string text)
	{
		value = Values.ToList().FindIndex(c => c == text[0]);
		colour = text[1];
	}
}

public class Hand
{
	public Card[] cards;
	public List<int> values;
	public List<int> sortedUniqueValues;

	public List<char> colours;

	public int rank;
	public int rankedValue;

	public Hand(string text)
	{
		cards = text.Split(new char[] { ' ' }).Select(t => new Card(t)).ToArray();
		values = cards.Select(c => c.value).ToList();
		sortedUniqueValues = values.Distinct().OrderByDescending(x => x).ToList();
		colours = cards.Select(c => c.colour).Distinct().ToList();

		DeterimeRanking();
	}

	private static List<Func<Hand, bool>> rankers = new List<Func<Hand, bool>> {
		h => (! new List<int>{8, 9, 10, 11, 12}.Except(h.values).Any()) && h.colours.Count() == 1,
		h => h.sortedUniqueValues.Count() == 5 && h.sortedUniqueValues[0] == h.sortedUniqueValues[4] + 4 && h.colours.Count() == 1,
		h => h.sortedUniqueValues.Any(v => h.values.Count(x => x == v) == 4),
		h => h.sortedUniqueValues.Count() == 2,
		h => h.colours.Count() == 1,
		h => h.sortedUniqueValues.Count() == 5 && h.sortedUniqueValues[0] == h.sortedUniqueValues[4] + 4,
		h => h.sortedUniqueValues.Any(v => h.values.Count(x => x == v) == 3),
		h => h.sortedUniqueValues.Count() == 3,
		h => h.sortedUniqueValues.Count() == 4,
		h => true
	};

	private static List<Func<Hand, int>> rankerValues = new List<Func<Hand, int>> {
		h => 12,
		h => h.sortedUniqueValues[0],
		h => h.sortedUniqueValues.First(v => h.values.Count(x => x==v)==4),
		h => h.sortedUniqueValues.First(v => h.values.Count(x => x==v)==3),
		h => h.sortedUniqueValues[0],
		h => h.sortedUniqueValues[0],
		h => h.sortedUniqueValues.First(v => h.values.Count(x => x==v)==3),
		h => h.sortedUniqueValues.Where(v => h.values.Count(x => x==v)==2).Max(),
		h => h.sortedUniqueValues.First(v => h.values.Count(x => x==v)==2),
		h => h.sortedUniqueValues[0]
	};

	private void DeterimeRanking()
	{
		rank = rankers.FindIndex(f => f(this));
		rankedValue = rankerValues[rank](this);
	}

	public static bool operator >(Hand a, Hand b)
	{
		if(a.rank < b.rank)	return true;
		if(a.rank > b.rank) return false;
		return a.rankedValue > b.rankedValue;
	}

	public static bool operator <(Hand a, Hand b)
	{
		return b > a;
	}
}

public class Program
{
	public static void Main()
	{
		var lines = File.ReadAllLines("p054_poker.txt");
		Console.WriteLine(lines.Count(line => new Hand(line.Substring(0, 14)) > new Hand(line.Substring(15))));
	}
}
