namespace Betweenle
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			wordTop = new wordleWord();
			wordBottom = new wordleWord();
			wordGuess = new wordleWord();
			gauge = new BetweenleGauge();
			btnNewGame = new Button();
			tbMessages = new TextBox();
			tbGuesses = new TextBox();
			lblGuesses = new Label();
			btnGiveUp = new Button();
			formsPlot1 = new ScottPlot.WinForms.FormsPlot();
			btnScale = new Button();
			grpStats = new GroupBox();
			dataGridView1 = new DataGridView();
			Stat = new DataGridViewTextBoxColumn();
			Value = new DataGridViewTextBoxColumn();
			grpStats.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// wordTop
			// 
			wordTop.AcceptInput = false;
			wordTop.Location = new Point(132, 41);
			wordTop.MaximumSize = new Size(605, 141);
			wordTop.MinimumSize = new Size(605, 141);
			wordTop.Name = "wordTop";
			wordTop.Size = new Size(605, 141);
			wordTop.TabIndex = 0;
			wordTop.Word = "AAAAA";
			// 
			// wordBottom
			// 
			wordBottom.AcceptInput = false;
			wordBottom.Location = new Point(132, 335);
			wordBottom.MaximumSize = new Size(605, 141);
			wordBottom.MinimumSize = new Size(605, 141);
			wordBottom.Name = "wordBottom";
			wordBottom.Size = new Size(605, 141);
			wordBottom.TabIndex = 3;
			wordBottom.Word = "ZZZZZ";
			// 
			// wordGuess
			// 
			wordGuess.AcceptInput = false;
			wordGuess.Location = new Point(132, 188);
			wordGuess.MaximumSize = new Size(605, 141);
			wordGuess.MinimumSize = new Size(605, 141);
			wordGuess.Name = "wordGuess";
			wordGuess.Size = new Size(605, 141);
			wordGuess.TabIndex = 4;
			wordGuess.Word = "     ";
			wordGuess.KeyDown += wordGuess_KeyDown;
			// 
			// gauge
			// 
			gauge.BottomNum = 50D;
			gauge.horizontalBarHeight = 5;
			gauge.horizontalBarWidth = 30;
			gauge.Location = new Point(12, 41);
			gauge.Name = "gauge";
			gauge.Size = new Size(95, 435);
			gauge.TabIndex = 9;
			gauge.TopNum = 5D;
			gauge.verticalBarWidth = 5;
			// 
			// btnNewGame
			// 
			btnNewGame.Location = new Point(132, 12);
			btnNewGame.Name = "btnNewGame";
			btnNewGame.Size = new Size(75, 23);
			btnNewGame.TabIndex = 10;
			btnNewGame.Text = "New Game";
			btnNewGame.UseVisualStyleBackColor = true;
			btnNewGame.Click += btnNewGame_Click;
			// 
			// tbMessages
			// 
			tbMessages.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			tbMessages.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			tbMessages.Location = new Point(743, 73);
			tbMessages.Multiline = true;
			tbMessages.Name = "tbMessages";
			tbMessages.ReadOnly = true;
			tbMessages.ScrollBars = ScrollBars.Vertical;
			tbMessages.Size = new Size(344, 403);
			tbMessages.TabIndex = 12;
			// 
			// tbGuesses
			// 
			tbGuesses.Location = new Point(798, 44);
			tbGuesses.Name = "tbGuesses";
			tbGuesses.ReadOnly = true;
			tbGuesses.Size = new Size(100, 23);
			tbGuesses.TabIndex = 13;
			tbGuesses.Text = "0";
			// 
			// lblGuesses
			// 
			lblGuesses.AutoSize = true;
			lblGuesses.Location = new Point(743, 47);
			lblGuesses.Name = "lblGuesses";
			lblGuesses.Size = new Size(49, 15);
			lblGuesses.TabIndex = 14;
			lblGuesses.Text = "Guesses";
			// 
			// btnGiveUp
			// 
			btnGiveUp.Location = new Point(213, 12);
			btnGiveUp.Name = "btnGiveUp";
			btnGiveUp.Size = new Size(75, 23);
			btnGiveUp.TabIndex = 15;
			btnGiveUp.Text = "Give Up";
			btnGiveUp.UseVisualStyleBackColor = true;
			btnGiveUp.Click += btnGiveUp_Click;
			// 
			// formsPlot1
			// 
			formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			formsPlot1.DisplayScale = 1F;
			formsPlot1.Location = new Point(282, 51);
			formsPlot1.Name = "formsPlot1";
			formsPlot1.Size = new Size(787, 250);
			formsPlot1.TabIndex = 16;
			// 
			// btnScale
			// 
			btnScale.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			btnScale.Location = new Point(994, 22);
			btnScale.Name = "btnScale";
			btnScale.Size = new Size(75, 23);
			btnScale.TabIndex = 17;
			btnScale.Text = "Auto Scale";
			btnScale.UseVisualStyleBackColor = true;
			btnScale.Click += btnScale_Click;
			// 
			// grpStats
			// 
			grpStats.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			grpStats.Controls.Add(dataGridView1);
			grpStats.Controls.Add(btnScale);
			grpStats.Controls.Add(formsPlot1);
			grpStats.Location = new Point(12, 482);
			grpStats.Name = "grpStats";
			grpStats.Size = new Size(1075, 307);
			grpStats.TabIndex = 18;
			grpStats.TabStop = false;
			grpStats.Text = "Stats";
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AllowUserToResizeRows = false;
			dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Stat, Value });
			dataGridView1.Location = new Point(3, 19);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.Size = new Size(273, 282);
			dataGridView1.TabIndex = 0;
			// 
			// Stat
			// 
			Stat.HeaderText = "Stat";
			Stat.Name = "Stat";
			Stat.ReadOnly = true;
			// 
			// Value
			// 
			Value.HeaderText = "Value";
			Value.Name = "Value";
			Value.ReadOnly = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1099, 801);
			Controls.Add(grpStats);
			Controls.Add(btnGiveUp);
			Controls.Add(lblGuesses);
			Controls.Add(tbGuesses);
			Controls.Add(tbMessages);
			Controls.Add(btnNewGame);
			Controls.Add(gauge);
			Controls.Add(wordGuess);
			Controls.Add(wordBottom);
			Controls.Add(wordTop);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "Form1";
			Text = "Betweenle";
			Load += Form1_Load;
			grpStats.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private wordleWord wordTop;
		private wordleWord wordBottom;
		private wordleWord wordGuess;
		private BetweenleGauge gauge;
		private Button btnNewGame;
		private TextBox tbMessages;
		private TextBox tbGuesses;
		private Label lblGuesses;
		private Button btnGiveUp;
		private ScottPlot.WinForms.FormsPlot formsPlot1;
		private Button btnScale;
		private GroupBox grpStats;
		private DataGridView dataGridView1;
		private DataGridViewTextBoxColumn Stat;
		private DataGridViewTextBoxColumn Value;
	}
}
