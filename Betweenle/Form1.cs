
using System.Text.Json;

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
		}

		private void SaveRecords()
		{
			string json = JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true});
			File.WriteAllText(recordsFilename, json);
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
			var testWord = word.ToLower();
			var topWordIndex = fullWordsList.IndexOf(wordTop.Word.ToLower());
			var bottomWordIndex = fullWordsList.IndexOf(wordBottom.Word.ToLower());
			var guessIndex = fullWordsList.IndexOf(testWord);
			var targetIndex = fullWordsList.IndexOf(targetWord);

			if (testWord == targetWord)
			{
				guesses++;

				AddMessage($"Correct! ({word})");
				wordGuess.TurnGreen();

				records.AddRecord(word, guesses);
				SaveRecords();

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

			gauge.Clear();

			guesses = 0;

			wordTop.Word = "AAAAA";
			wordBottom.Word = "ZZZZZ";
			wordGuess.Clear();
		}

		private void btnGiveUp_Click(object sender, EventArgs e)
		{
			AddMessage($"You Lose!  Word was {targetWord.ToUpper()}");
		}
	}
}
