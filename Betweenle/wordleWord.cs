using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Betweenle
{
	public partial class wordleWord : UserControl
	{
		public bool AcceptInput { get; set; } = false;

		public wordleWord()
		{
			InitializeComponent();
		}

		public string Word
		{
			get
			{
				return tbLetter1.Text + tbLetter2.Text + tbLetter3.Text + tbLetter4.Text + tbLetter5.Text;
			}
			set
			{
				value = value.PadRight(5);
				value = value.ToUpper();
				tbLetter1.Text = value.Substring(0, 1);
				tbLetter2.Text = value.Substring(1, 1);
				tbLetter3.Text = value.Substring(2, 1);
				tbLetter4.Text = value.Substring(3, 1);
				tbLetter5.Text = value.Substring(4, 1);
			}
		}

		public void AddLetter(char letter)
		{
			var trimmed = Word.Trim();
			if (trimmed.Length < 5) 
			{
				Word = trimmed + letter;
			}
		}

		public void Backspace()
		{
			var trimmed = Word.Trim();
			if (trimmed.Length > 0)
			{
				Word = trimmed.Substring(0, trimmed.Length - 1);
			}
		}

		public void Clear()
		{
			Word = "";
			TurnBlack();
		}

		public void TurnGreen()
		{
			tbLetter1.ForeColor = Color.Green;
			tbLetter2.ForeColor = Color.Green;
			tbLetter3.ForeColor = Color.Green;
			tbLetter4.ForeColor = Color.Green;
			tbLetter5.ForeColor = Color.Green;
		}

		public void TurnBlack()
		{
			tbLetter1.ForeColor = Color.Black;
			tbLetter2.ForeColor = Color.Black;
			tbLetter3.ForeColor = Color.Black;
			tbLetter4.ForeColor = Color.Black;
			tbLetter5.ForeColor = Color.Black;
		}
	}
}
