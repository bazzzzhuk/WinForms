//#define SHOWMESSAGE
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;



namespace Clock
{
	public partial class MainForm : Form
	{
		FontDialog fontDialog;
		ColorDialog foregroundColorDialog;
		ColorDialog backgroundColorDialog;

		public MainForm()
		{
#if SHOWMESSAGE
			MessageBox.Show(
				null,
				Properties.Settings.Default.myExFont.Name,
				"Шрифт по умолчанию:",
			MessageBoxButtons.OK,
			MessageBoxIcon.Information);

			MessageBox.Show(
				null,
				Clock.Properties.Settings.Default.CTPath,
				"Какой шрифт сохранён:",
			MessageBoxButtons.OK,
			MessageBoxIcon.Information);
#endif
			InitializeComponent();

			this.Location = new Point
				(Screen.PrimaryScreen.Bounds.Width - this.Width - 350,
				350
				);

			label_font.Text = Properties.Settings.Default.CTPath.ToString();
			//label_index.Text = FontDialog.SelectedItem.ToString();

			this.MaximizeBox = false;
			this.MinimizeBox = false;
			SetVisibility(false);
			fontDialog = new FontDialog();
			foregroundColorDialog = new ColorDialog();
			backgroundColorDialog = new ColorDialog();
			this.TopMost = tsmiTopmost.Checked = true;
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
			DialogResult result = foregroundColorDialog.ShowDialog();
			if (result == DialogResult.OK)
				labelTime.ForeColor = foregroundColorDialog.Color;
		}

		private void tsmiBackgroundColor_Click(object sender, EventArgs e)
		{
			DialogResult result = backgroundColorDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				labelTime.BackColor = backgroundColorDialog.Color;
				Properties.Settings.Default.myBackColor = backgroundColorDialog.Color;
				Properties.Settings.Default.Save();
			}
		}

		private void tsmiFont_Click(object sender, EventArgs e)
		{
			fontDialog.Location = new Point
				(
				this.Location.X - fontDialog.Width + 10,
				this.Location.Y
				);
			fontDialog.Font = Properties.Settings.Default.myExFont;
			DialogResult result = fontDialog.ShowDialog();
			if (result == DialogResult.OK)
			{
				Properties.Settings.Default.myExFont = fontDialog.Font;

				labelTime.Font = fontDialog.Font;
				label_font.Text = Properties.Settings.Default.CTPath.ToString();
				Properties.Settings.Default.Save();

			}
			//fontDialog.ShowDialog();
		}

		private void tsmiAutoStart_CheckedChanged(object sender, EventArgs e)
		{
			string key_name = "ClockPV_521";
			RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true); //true - открыть ветку на запись
			if (tsmiAutoStart.Checked) rk.SetValue(key_name, Application.ExecutablePath);
			else rk.DeleteValue(key_name, false); //false - не бросать исключение если данная запись отсутствует в реестре.
			rk.Dispose();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Save();
			//MessageBox.Show(
			//	null,
			//	Properties.Settings.Default.CTPath.ToString(),
			//	"font_closing",
			//MessageBoxButtons.OK,
			//MessageBoxIcon.Information);
		}

		private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			Properties.Settings.Default.Save();
#if SHOWMESSAGE
			string sshow = $"Сохраняемый шрифт:\t\t{Properties.Settings.Default.CTPath.ToString()}\nРазмер сохраняемого шрифта: \t{Properties.Settings.Default.my_size_font.ToString()}";
			MessageBox.Show(
				null,
				sshow,
				"Сохранение перед выходом",
			MessageBoxButtons.OK,
			MessageBoxIcon.Information); 
#endif
		}
	}
}
