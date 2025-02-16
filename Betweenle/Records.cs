using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betweenle
{
	internal class Records
	{
		public List<Record> records { get; set; }


		public Records()
		{
			records = new List<Record>();
		}

		public void AddRecord(string word, int guesses)
		{
			records.Add(new Record(word, guesses));
		}

		public struct Record
		{
			public Record(string w, int g)
			{
				word = w;
				guesses = g;
			}
			public string word { get; set; }
			public int guesses { get; set; }
		}
	}
}
