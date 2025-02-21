
using System.Text.Json;
using Microsoft.VisualBasic;
using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.TickGenerators;

namespace Betweenle
{
	public partial class Form1 : Form
	{
		private List<string> targetWordsList;
		private List<string> fullWordsList;
		private string targetWord;
		Random rand;
		Records records = new Records();
		string recordsFilename = "records.json";
		bool alreadyCorrect = false;
		bool alreadyForfeit = false;

		Dictionary<double, double> plotRecords = new();

		int guesses
		{
			get => int.Parse(tbGuesses.Text);
			set => tbGuesses.Text = value.ToString();
		}

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadRecords(recordsFilename);

			targetWordsList = new List<string>();
			string fullText = File.ReadAllText("wordsTarget.txt");
			targetWordsList.AddRange(fullText.Split("\r\n"));

			fullWordsList = new List<string>();
			fullText = File.ReadAllText("wordsFull.txt");
			fullWordsList.AddRange(fullText.Split("\r\n"));
			fullWordsList.Insert(0, "aaaaa");
			fullWordsList.Add("zzzzz");

			rand = new Random((int)DateTime.Now.Ticks);
			StartNewGame();

			SetupPlot();
			UpdateStats();
		}

		private void SetupPlot()
		{
			formsPlot1.Plot.Axes.Margins(0.1, 0.4);
			formsPlot1.Plot.Axes.Bottom.Label.Text = "# of Guesses";
			formsPlot1.Plot.Axes.Left.Label.Text = "Frequency";
			CreatePlotData();
			UpdatePlot();
		}

		private void SaveRecords()
		{
			string json = JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });
			File.WriteAllText(recordsFilename, json);
		}

		private void CreatePlotData()
		{
			foreach (var record in records.records)
			{
				if (record.forfeit) continue;

				if (!plotRecords.ContainsKey(record.guesses))
				{
					plotRecords.Add(record.guesses, 1);
				}
				else
				{
					plotRecords[record.guesses]++;
				}
			}
		}

		private void AddPlotDatum(int guessCount)
		{
			if (!plotRecords.ContainsKey(guessCount))
			{
				plotRecords.Add(guessCount, 1);
			}
			else
			{
				plotRecords[guessCount]++;
			}
		}

		private void UpdatePlot()
		{
			formsPlot1.Plot.Clear();
			var barPlot = formsPlot1.Plot.Add.Bars(plotRecords.Keys.ToArray<double>(), plotRecords.Values);

			foreach (var bar in barPlot.Bars)
			{
				bar.Label = bar.Value.ToString();
			}

			barPlot.ValueLabelStyle.Bold = true;
			barPlot.ValueLabelStyle.FontSize = 18;
			barPlot.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Orange);

			AutoScalePlot();
		}

		private void AutoScalePlot()
		{
			formsPlot1.Plot.Axes.AutoScale();
			formsPlot1.Refresh();
		}

		private void UpdateStats()
		{
			AddOrUpdateStat("# of Games", records.records.Count);
			AddOrUpdateStat("# Completed", records.nonForfeitGuessList.Count());
			AddOrUpdateStat("Standard Deviation", Math.Round(records.StandardDeviation, 1));
			AddOrUpdateStat("Average", Math.Round(records.mean, 1));
			AddOrUpdateStat("Mediam", Math.Round(records.median, 1));
			AddOrUpdateStat("Forfeits", records.forfeits);
		}

		private void AddOrUpdateStat(string name, double value)
		{
			//Check if the row exists, then update it if it does
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				if (row.Cells[0].Value == name)
				{
					row.Cells[1].Value = value;
					return;
				}
			}

			var newRow = new DataGridViewRow();
			var cell0 = new DataGridViewTextBoxCell();
			cell0.Value = name;
			var cell1 = new DataGridViewTextBoxCell();
			cell1.Value = value;

			newRow.Cells.Add(cell0);
			newRow.Cells.Add(cell1);

			dataGridView1.Rows.Add(newRow);
		}

		private void LoadRecords(string path)
		{
			if (File.Exists(path))
			{
				string fullText = File.ReadAllText(path);
				records = JsonSerializer.Deserialize<Records>(fullText);
			}
		}

		private void wordGuess_KeyDown(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z) ||  // Letters A-Z
				(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) || // Digits 0-9 (Main keyboard)
				(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)) // Digits 0-9 (Numpad)
			{
				var kc = new KeysConverter();
				wordGuess.AddLetter(kc.ConvertToString(e.KeyCode).ElementAt(0));
			}
			else if (e.KeyCode == Keys.Back)
			{
				wordGuess.Backspace();
			}
		}

		private void AddRecord(int guessCount, string word, bool forfeit)
		{
			records.AddRecord(word, guessCount, forfeit);
			SaveRecords();

			if (!forfeit) AddPlotDatum(guessCount);
			UpdatePlot();

			UpdateStats();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			if (isLetter(keyData))
			{
				wordGuess.AddLetter(keyData.ToString().ElementAt(0));
				return true;
			}
			else if (keyData == Keys.Back)
			{
				wordGuess.Backspace();
				return true;
			}
			else if (keyData == Keys.Enter)
			{
				CheckGuess(wordGuess.Word);
				return true;
			}
			else
			{
				return base.ProcessCmdKey(ref msg, keyData);
			}
		}

		private bool isLetter(Keys key)
		{
			return key >= Keys.A && key <= Keys.Z;
		}

		private bool CheckGuess(string word)
		{
			if (alreadyCorrect) return false;
			if (alreadyForfeit)
			{
				AddMessage("Start a new game");
				return false;
			}

			var testWord = word.ToLower();
			var topWordIndex = fullWordsList.IndexOf(wordTop.Word.ToLower());
			var bottomWordIndex = fullWordsList.IndexOf(wordBottom.Word.ToLower());
			var guessIndex = fullWordsList.IndexOf(testWord);
			var targetIndex = fullWordsList.IndexOf(targetWord);

			if (testWord == targetWord)
			{
				guesses++;

				alreadyCorrect = true;

				AddMessage($"Correct! ({word})");
				wordGuess.TurnGreen();

				AddRecord(guesses, word, false);

				return true;
			}
			else if (guessIndex == -1)
			{
				AddMessage($"Word not in list ({word})");
				return false;
			}
			else if (guessIndex < topWordIndex || guessIndex > bottomWordIndex)
			{
				AddMessage($"Word out of bounds ({word})");
				wordGuess.Clear();
				return false;
			}
			else
			{
				AddMessage($"Incorrect ({word})");

				guesses++;

				if (guessIndex < targetIndex)
				{
					wordTop.Word = word;
					topWordIndex = guessIndex;
				}
				else
				{
					wordBottom.Word = word;
					bottomWordIndex = guessIndex;
				}

				var percentToTop = (double)(targetIndex - topWordIndex) / fullWordsList.Count;
				var percentToBottom = (double)(bottomWordIndex - targetIndex) / fullWordsList.Count;

				gauge.SetGauge(percentToTop * 100, percentToBottom * 100);

				wordGuess.Clear();

				return false;
			}
		}

		private void AddMessage(string text)
		{
			tbMessages.AppendText(text + "\r\n");
		}

		private void btnNewGame_Click(object sender, EventArgs e)
		{
			StartNewGame();
		}

		private void StartNewGame()
		{
			targetWord = targetWordsList.ElementAt(rand.Next() % targetWordsList.Count);
			alreadyCorrect = false;
			alreadyForfeit = false;

			gauge.Clear();

			guesses = 0;

			wordTop.Word = "AAAAA";
			wordBottom.Word = "ZZZZZ";
			wordGuess.Clear();
		}

		private void btnGiveUp_Click(object sender, EventArgs e)
		{
			if (alreadyForfeit)
			{
				AddMessage("Can't give up twice!");
				return;
			}
			AddMessage($"You Lose!  Word was {targetWord.ToUpper()}");
			alreadyForfeit = true;
			AddRecord(guesses, targetWord, true);
		}

		private void btnScale_Click(object sender, EventArgs e)
		{
			AutoScalePlot();
		}
	}
}
