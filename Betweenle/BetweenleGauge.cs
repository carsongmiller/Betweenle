using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Betweenle
{
	public partial class BetweenleGauge : UserControl
	{
		private double topNumCurrent = 50;
		private double bottomNumCurrent = 50;

		public int verticalBarWidth {
			get => verticalBar.Width;
			set => verticalBar.Width = value;
		}
		public int horizontalBarHeight
		{
			get => horizontalBar.Height;
			set => horizontalBar.Height = value;
		}
		public int horizontalBarWidth
		{
			get => horizontalBar.Width;
			set => horizontalBar.Width = value;
		}

		public double TopNum
		{
			get => topNumCurrent;
			set => SetGauge(value, bottomNumCurrent);
		}

		public double BottomNum
		{
			get => bottomNumCurrent;
			set => SetGauge(topNumCurrent, value);
		}

		public BetweenleGauge()
		{
			InitializeComponent();
		}

		private void BetweenleGauge_Load(object sender, EventArgs e)
		{

		}

		public void SetGauge(double topNum, double bottomNum)
		{
			topNumCurrent = topNum;
			bottomNumCurrent = bottomNum;

			var topNumDisplay = "";
			var bottomNumDisplay = "";

			if (topNum >= 5)
			{
				lblTop.Text = Math.Round(topNum, 0).ToString();
			}
			else if (topNum >= 1)
			{
				lblTop.Text = Math.Round(topNum, 1).ToString();
			}
			else
			{
				lblTop.Text = Math.Round(topNum, 2).ToString();
			}

			if (bottomNum >= 5)
			{
				lblBottom.Text = Math.Round(bottomNum, 0).ToString();
			}
			else if (bottomNum >= 1)
			{
				lblBottom.Text = Math.Round(bottomNum, 1).ToString();
			}
			else
			{
				lblBottom.Text = Math.Round(bottomNum, 2).ToString();
			}

			var percentage = topNum / (topNum + bottomNum);

			horizontalBar.Top = (int)((verticalBar.Height - horizontalBar.Height) * percentage + lblTop.Height);
		}

		public void Clear()
		{
			lblTop.Text = "??";
			lblBottom.Text = "??";
			CenterHorizontalBar();
		}

		private void CenterHorizontalBar()
		{
			horizontalBar.Top = (int)((verticalBar.Height - horizontalBar.Height) / 2 + lblTop.Height);
		}

		private void BetweenleGauge_Resize(object sender, EventArgs e)
		{
			verticalBar.Width = verticalBarWidth;
			verticalBar.Left = (Width - verticalBar.Width) / 2;
			verticalBar.Top = lblTop.Height;
			verticalBar.Height = Height - 2 * lblTop.Height;

			horizontalBar.Left = (Width - horizontalBar.Width) / 2;
			SetGauge(topNumCurrent, bottomNumCurrent);
		}
	}
}
