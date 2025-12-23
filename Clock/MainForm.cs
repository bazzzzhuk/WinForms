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
			Point pos = new Point();
		public MainForm()
		{
			//this.Location =  pos;
			InitializeComponent();
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			SetVisibility(false);
			//this.MouseDown += new MouseEventHandler(this);
		}
		void SetVisibility(bool visible)
		{
			cb_ShowDate.Visible = visible;
			cb_ShowWeekday.Visible = visible;
			btn_HideControls.Visible = visible;
			this.ShowInTaskbar = visible;
			this.FormBorderStyle = visible ? FormBorderStyle.FixedSingle:FormBorderStyle.None;
			this.TransparencyKey = visible? Color.Empty:this.BackColor;
			this.BackgroundImage = visible ? Clock.Properties.Resources._60b3361734465db24cec5759441644db : null;
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
		
		private void tsmiTopmost_Click(object sender, EventArgs e)=> this.TopMost = tsmiTopmost.Checked;
		

		private void tsmiShowControls_CheckedChanged(object sender, EventArgs e)
		{
			SetVisibility((sender as ToolStripMenuItem).Checked);
			//Sender - это отправитель события (Control, который прислал событие)
			//Если на элемент окна(Control) воздействует пользователь при помощи клавиатуры или мыши,
			//этот (Control) отправляет событие своему родителю, а родиетль может обрабатывать или 
			//не обрабатывать это событие.
		}

		private void tsmiShowDate_CheckedChanged(object sender, EventArgs e)=>
			cb_ShowDate.Checked = tsmiShowDate.Checked;

		private void cb_ShowDate_CheckedChanged(object sender, EventArgs e) =>
			tsmiShowDate.Checked = cb_ShowDate.Checked;

		private void tsmiShowWeekday_CheckedChanged(object sender, EventArgs e) =>
			cb_ShowWeekday.Checked = tsmiShowWeekday.Checked;

		private void cb_ShowWeekday_CheckedChanged(object sender, EventArgs e) =>
			tsmiShowWeekday.Checked = cb_ShowWeekday.Checked;

		private void tsmiQuit_Click(object sender, EventArgs e)=> this.Close();

		private void tsmiForegroundColor_Click(object sender, EventArgs e)
		{
			if (ColorDialog.ShowDialog() == DialogResult.OK) this.ForeColor = ColorDialog.Color;
		}

		private void tsmiBackgroundColor_Click(object sender, EventArgs e)
		{
			if (ColorDialog.ShowDialog() == DialogResult.OK)labelTime.BackColor = ColorDialog.Color;
		}
		
		int x = 0;
		int y = 0;
		private void MainForm_MouseDown(object sender, MouseEventArgs e)
		{
			x = e.X;
			y = e.Y;
		}

		private void MainForm_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) // или любую другую, какая удобнее
			{
				//pos = new Point(Cursor.Position.X/2, Cursor.Position.Y/2);
				//this.Location = PointToClient(pos);
				this.Left += e.X - x;
				this.Top += e.Y - y;
			}
		}

		private void labelTime_MouseDown(object sender, MouseEventArgs e)
		{
			x = e.X;
			y = e.Y;
		}

		private void labelTime_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left) // или любую другую, какая удобнее
			{
				//pos = new Point(Cursor.Position.X/2, Cursor.Position.Y/2);
				//this.Location = PointToClient(pos);
				this.Left += e.X - x;
				this.Top += e.Y - y;
			}
		}
				
		private void tsmiFont_Click(object sender, EventArgs e)
		{
			if (fontDialog.ShowDialog() == DialogResult.OK) labelTime.Font = fontDialog.Font;

		}
	}
}
