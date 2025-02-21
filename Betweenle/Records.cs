using ScottPlot.Colormaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Betweenle
{
	internal class Records
	{
		public List<Record> records { get; set; }

		/// <summary>
		/// List of all guesses that weren't forfeits (every single guess, with repeats--not a dictionary)
		/// </summary>
		public int[] nonForfeitGuessList
		{
			get => records.Where(x => !x.forfeit).Select(x => x.guesses).ToArray();
		}

		/// <summary>
		/// A dictionary of all guesses
		/// </summary>
		public Dictionary<int, int> guessCounts
		{
			get
			{
				var dict = new Dictionary<int, int>();
				foreach (var guess in nonForfeitGuessList)
				{
					if (dict.ContainsKey(guess)) dict[guess]++;
					else dict[guess] = 1;
				}
				return dict;
			}
		}

		public double StandardDeviation
		{
			get
			{
				double mean = nonForfeitGuessList.Average();
				double sumOfSquares = nonForfeitGuessList.Select(val => Math.Pow(val - mean, 2)).Sum();
				double variance = sumOfSquares / nonForfeitGuessList.Count();
				return Math.Sqrt(variance);
			}
		}

		public double mean { get => nonForfeitGuessList.Average(); }
		public double median { get => nonForfeitGuessList.Length % 2 == 0 ? (nonForfeitGuessList[nonForfeitGuessList.Length / 2] + nonForfeitGuessList[nonForfeitGuessList.Length / 2 - 1]) / 2 : nonForfeitGuessList[nonForfeitGuessList.Length / 2]; }
		public int forfeits { get => records.Select(x => x.forfeit).ToArray().Count(b => b); }

		public Records()
		{
			records = new List<Record>();
		}

		public void AddRecord(string word, int guesses, bool forfeit)
		{
			records.Add(new Record(word, guesses, forfeit));
		}

		public struct Record
		{
			public Record(string w, int g, bool f)
			{
				word = w;
				guesses = g;
				forfeit = f;
			}
			public string word { get; set; }
			public int guesses { get; set; }
			public bool forfeit { get; set; }
		}
	}
}
