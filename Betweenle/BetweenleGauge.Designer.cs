namespace Betweenle
{
	partial class BetweenleGauge
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			lblTop = new Label();
			lblBottom = new Label();
			verticalBar = new Panel();
			horizontalBar = new Panel();
			SuspendLayout();
			// 
			// lblTop
			// 
			lblTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			lblTop.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblTop.Location = new Point(0, 0);
			lblTop.Name = "lblTop";
			lblTop.Size = new Size(62, 44);
			lblTop.TabIndex = 0;
			lblTop.Text = "??";
			lblTop.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// lblBottom
			// 
			lblBottom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			lblBottom.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lblBottom.Location = new Point(0, 393);
			lblBottom.Name = "lblBottom";
			lblBottom.Size = new Size(62, 44);
			lblBottom.TabIndex = 1;
			lblBottom.Text = "??";
			lblBottom.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// verticalBar
			// 
			verticalBar.BackColor = Color.FromArgb(64, 64, 64);
			verticalBar.ForeColor = Color.Gray;
			verticalBar.Location = new Point(28, 49);
			verticalBar.Name = "verticalBar";
			verticalBar.Size = new Size(5, 350);
			verticalBar.TabIndex = 2;
			// 
			// horizontalBar
			// 
			horizontalBar.BackColor = Color.FromArgb(255, 128, 0);
			horizontalBar.ForeColor = Color.IndianRed;
			horizontalBar.Location = new Point(15, 60);
			horizontalBar.Name = "horizontalBar";
			horizontalBar.Size = new Size(30, 5);
			horizontalBar.TabIndex = 3;
			// 
			// BetweenleGauge
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(horizontalBar);
			Controls.Add(verticalBar);
			Controls.Add(lblBottom);
			Controls.Add(lblTop);
			Name = "BetweenleGauge";
			Size = new Size(62, 437);
			Resize += BetweenleGauge_Resize;
			ResumeLayout(false);
		}

		#endregion

		private Label lblTop;
		private Label lblBottom;
		private Panel verticalBar;
		private Panel horizontalBar;
	}
}
