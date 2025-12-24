using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
	public partial class MainForm : Form
	{
		ColorDialog foregroundColorDialog;
		ColorDialog backgroundColorDialog;

		public MainForm()
		{
			InitializeComponent();
			this.Location = new Point
				(Screen.PrimaryScreen.Bounds.Width-this.Width -350,
				350
				);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			SetVisibility(false);
			foregroundColorDialog = new ColorDialog();
			backgroundColorDialog = new ColorDialog();
		}
		void SetVisibility(bool visible)
		{
			cb_ShowDate.Visible = visible;
			cb_ShowWeekday.Visible = visible;
			btn_HideControls.Visible = visible;
			this.ShowInTaskbar = visible;
			this.FormBorderStyle = visible ? FormBorderStyle.FixedSingle : FormBorderStyle.None;
			this.TransparencyKey = visible ? Color.Empty : this.BackColor;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			//labelTime.Text = DateTime.Now.ToString
			//	(
			//	"hh:mm:ss tt",
			//	System.Globalization.CultureInfo.InvariantCulture
			//	);
			labelTime.Text = DateTime.Now.ToString("HH:mm:ss");
			if (cb_ShowDate.Checked)
				labelTime.Text += $"\n{DateTime.Now.ToString("yyyy:MM:dd")}";
			if (cb_ShowWeekday.Checked)
				labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
			notifyIcon.Text = labelTime.Text;
		}

		private void btn_HideControls_Click(object sender, EventArgs e)
		{
			SetVisibility(tsmiShowControls.Checked = false);
		}

		//private void labelTime_MouseHover(object sender, EventArgs e)
		//{
		//	SetVisibility(true);			
		//}

		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			if (!TopMost)
			{
				this.TopMost = true;
				this.TopMost = false;
			}
		}

		private void tsmiTopmost_Click(object sender, EventArgs e) => this.TopMost = tsmiTopmost.Checked;


		private void tsmiShowControls_CheckedChanged(object sender, EventArgs e)
		{
			SetVisibility((sender as ToolStripMenuItem).Checked);
			//Sender - это отправитель события (Control, который прислал событие)
			//Если на элемент окна(Control) воздействует пользователь при помощи клавиатуры или мыши,
			//этот (Control) отправляет событие своему родителю, а родиетль может обрабатывать или 
			//не обрабатывать это событие.
		}

		private void tsmiShowDate_CheckedChanged(object sender, EventArgs e) =>
			cb_ShowDate.Checked = tsmiShowDate.Checked;

		private void cb_ShowDate_CheckedChanged(object sender, EventArgs e) =>
			tsmiShowDate.Checked = cb_ShowDate.Checked;

		private void tsmiShowWeekday_CheckedChanged(object sender, EventArgs e) =>
			cb_ShowWeekday.Checked = tsmiShowWeekday.Checked;

		private void cb_ShowWeekday_CheckedChanged(object sender, EventArgs e) =>
			tsmiShowWeekday.Checked = cb_ShowWeekday.Checked;

		private void tsmiQuit_Click(object sender, EventArgs e) => this.Close();

		private void tsmiForegroundColor_Click(object sender, EventArgs e)
		{
			foregroundColorDialog.ShowDialog();
			labelTime.ForeColor = foregroundColorDialog.Color;
		}

		private void tsmiBackgroundColor_Click(object sender, EventArgs e)
		{
			backgroundColorDialog.ShowDialog();
			labelTime.BackColor = backgroundColorDialog.Color;
		}
	}
}
