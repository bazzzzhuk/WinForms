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
		public MainForm()
		{
			this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Width - this.Width-8, 0);
			InitializeComponent();
			this.MaximizeBox = false;
			this.MinimizeBox = false;
		}
		void SetVisibility(bool visible)
		{
			cb_ShowDate.Visible = visible;
			cb_ShowWeekday.Visible = visible;
			btn_HideControls.Visible = visible;
			this.ShowInTaskbar = visible;
			this.FormBorderStyle = visible ? FormBorderStyle.FixedSingle:FormBorderStyle.None;
			this.TransparencyKey = visible? Color.Empty:this.BackColor;
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
				labelTime.Text +=$"\n{DateTime.Now.ToString("yyyy:MM:dd")}";
			if (cb_ShowWeekday.Checked)
				labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
			notifyIcon.Text = labelTime.Text;
		}

		private void btn_HideControls_Click(object sender, EventArgs e)
		{
			SetVisibility(false);
		}

		private void labelTime_MouseHover(object sender, EventArgs e)
		{
			SetVisibility(true);			
		}

		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			this.TopMost= true;
			this.TopMost= false;
		}

		private void tb_show_Date_Click(object sender, EventArgs e)
		{
			if(cb_ShowDate.Checked == true) cb_ShowDate.Checked = false;
			else cb_ShowDate.Checked = true;
			ClockContextMenuStrip.Focus();
			//ClockContextMenuStrip.Text.();
			ClockContextMenuStrip.Close();
		}

		private void tb_show_Day_Click(object sender, EventArgs e)
		{
			if (cb_ShowWeekday.Checked == true) cb_ShowWeekday.Checked = false;
			else cb_ShowWeekday.Checked = true;
			ClockContextMenuStrip.Focus();
			ClockContextMenuStrip.Close();
		}

		private void tb_Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
