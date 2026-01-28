using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Runtime.InteropServices.ComTypes;
using static System.Net.WebRequestMethods;
using System.Security.AccessControl;
using System.Security.Principal;


namespace Clock
{
	public partial class MainForm : Form
	{
		FontDialog fontDialog;
		ColorDialog foregroundColorDialog;
		ColorDialog backgroundColorDialog;
		AlarmsForm alarms;
		Alarm alarm;
		DateTime dateTime;


		public MainForm()
		{
			InitializeComponent();
			this.Location = new Point
				(Screen.PrimaryScreen.Bounds.Width - this.Width - 150,
				150
				);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			SetVisibility(false);
			fontDialog = new FontDialog();
			foregroundColorDialog = new ColorDialog();
			backgroundColorDialog = new ColorDialog();
			alarms = new AlarmsForm();
			alarm = null;
			LoadSettings();
			//this.TopMost = tsmiTopmost.Checked = true;
			axWindowsMediaPlayer.Visible = false;
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
		void SaveSettings()
		{
			//FileStream fs = null;
			//MessageBox.Show(path);

			//// Handles whether there is a `\` or not.
			////MessageBox.Show(this, Directory.GetCurrentDirectory(),"Setting path",MessageBoxButtons.OK, MessageBoxIcon.Information);
			//fs = new FileStream(filePath, FileMode.CreateNew);
			//StreamWriter writer = new StreamWriter(filePath);
			//DirectoryInfo[] cDirs = new DirectoryInfo(@"c:\").GetDirectories();
			// Write each directory name to a file.
			String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			String path2 = ($"{Application.ExecutablePath}\\..");
			String folderName = Path.Combine(path, "Clock_PV521"); ;
			DirectoryInfo drInfo = new DirectoryInfo(folderName);
			//if (drInfo.Exists) drInfo.Create();
			var filePath = Path.Combine(folderName, "Settings_Clock.ini");

			FileInfo fileInf = new FileInfo(filePath);
			//if (fileInf.Exists) fileInf.Create();

			string filePath2 = Path.Combine(path2, "TEST.txt");
			//string filePath2 = Path.Combine("c:\\", "TEST.txt");
			//using (FileStream myFile = new FileStream(filePath2, FileMode.Open, FileAccess.Read))
			//{
			//	FileSecurity fileSec = myFile.GetAccessControl();
			//	FileSystemAccessRule newRule = new FileSystemAccessRule(new System.Security.Principal.NTAccount(@"admin"), FileSystemRights.FullControl, AccessControlType.Allow);
			//	fileSec.AddAccessRule(newRule);
			//	System.IO.File.SetAccessControl(filePath2, fileSec);
			//}

			//using (FileStream myFile = new FileStream(filePath2, FileMode.Open, FileAccess.Read))
			//{
			//}
			using (StreamWriter writer1 = new StreamWriter(filePath2))
			{
				writer1.WriteLine("TEST2");
				writer1.WriteLine("TEST2");
				writer1.Close();
			}
			var fileSecurity = new System.Security.AccessControl.FileSecurity();
			var everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
			var rule = new FileSystemAccessRule(everyone, FileSystemRights.FullControl, AccessControlType.Allow);
			fileSecurity.AddAccessRule(rule);
			System.IO.File.SetAccessControl(filePath2, fileSecurity);

			//var fileSecurity = new System.Security.AccessControl.FileSecurity();
			//var everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
			//var rule = new FileSystemAccessRule(everyone, FileSystemRights.FullControl, AccessControlType.Allow);
			//fileSecurity.AddAccessRule(rule);

			//System.IO.File.SetAccessControl("TEST.txt", fileSecurity);

			FileInfo fileInf2 = new FileInfo(filePath);
			if (!fileInf.Exists) fileInf.Create();


			using (StreamWriter writer = new StreamWriter(filePath))
			{
				writer.WriteLine(this.Location.X);
				writer.WriteLine(this.Location.Y);

				writer.WriteLine(tsmiTopmost.Checked);
				writer.WriteLine(tsmiShowControls.Checked);
				writer.WriteLine(tsmiShowConsole.Checked);
				//
				writer.WriteLine(tsmiShowDate.Checked);
				writer.WriteLine(tsmiShowWeekday.Checked);
				writer.WriteLine(tsmiAutoStart.Checked);
				//
				writer.WriteLine(labelTime.BackColor.ToArgb());
				writer.WriteLine(labelTime.ForeColor.ToArgb());
				//
				writer.WriteLine(fontDialog.Filename);
				writer.WriteLine(labelTime.Font.Size);

				writer.Close();
			}
			//

			//System.Diagnostics.Process.Start("notepad", "Settings.ini");
		}


		void LoadSettings()
		{
			String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			//MessageBox.Show(path);

			var filePath = Path.Combine(path, "Clock_PV521\\Settings_Clock.ini"); // Handles whether there is a `\` or not.


			//Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
			try
			{
				string line = "";
				using (StreamReader reader = new StreamReader(filePath))
				{
					//StreamReader reader = new StreamReader(filePath);
					this.Location = new Point
						(
						Convert.ToInt32(reader.ReadLine()),
						Convert.ToInt32(reader.ReadLine())
						);

					this.TopMost = tsmiTopmost.Checked = bool.Parse(reader.ReadLine());
					tsmiShowControls.Checked = bool.Parse(reader.ReadLine());
					tsmiShowConsole.Checked = bool.Parse(reader.ReadLine());
					tsmiShowDate.Checked = bool.Parse(reader.ReadLine());
					tsmiShowWeekday.Checked = bool.Parse(reader.ReadLine());
					tsmiAutoStart.Checked = bool.Parse(reader.ReadLine());

					labelTime.BackColor = backgroundColorDialog.Color = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));
					labelTime.ForeColor = foregroundColorDialog.Color = Color.FromArgb(Convert.ToInt32(reader.ReadLine()));

					fontDialog = new FontDialog(reader.ReadLine(), reader.ReadLine());
					labelTime.Font = fontDialog.Font;

					reader.Close();
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(this, ex.Message, "SettingsException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
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
			if (alarm != null
				&& (
				alarm.Date == DateTime.MaxValue ?
				alarm.Days.Contains((byte)DateTime.Now.DayOfWeek) :
				CompareDates(alarm.Date, DateTime.Now)
				)
				&& alarm.Time.Hours == DateTime.Now.Hour
				&& alarm.Time.Minutes == DateTime.Now.Minute
				&& alarm.Time.Seconds == DateTime.Now.Second
				)
				PlayAlarm();
			//MessageBox.Show(alarm.ToString());
			if (DateTime.Now.Second % 5 == 0) alarm = FindNextAlarm();
			notifyIcon.Text = labelTime.Text;
		}
		void PlayAlarm()
		{
			axWindowsMediaPlayer.URL = alarm.Filename;
			axWindowsMediaPlayer.settings.volume = 50;
			axWindowsMediaPlayer.Ctlcontrols.play();
			axWindowsMediaPlayer.Visible = true;
		}
		void SetPlayerInvisible(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
		{
			if (
				axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsMediaEnded ||
				axWindowsMediaPlayer.playState == WMPLib.WMPPlayState.wmppsStopped
				)
				axWindowsMediaPlayer.Visible = false;
		}
		bool CompareDates(DateTime date1, DateTime date2)
		{
			return date1.Year == date2.Year && date1.Month == date2.Month && date1.Day == date2.Day;
		}
		Alarm FindNextAlarm()
		{
			Alarm[] actualAlarms = alarms.List.Items.Cast<Alarm>().Where(a => a.Time > DateTime.Now.TimeOfDay).ToArray();
			return actualAlarms.Min();
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
				labelTime.BackColor = backgroundColorDialog.Color;
		}

		private void tsmiFont_Click(object sender, EventArgs e)
		{
			fontDialog.Location = new Point
				(
				this.Location.X - fontDialog.Width + 10,
				this.Location.Y
				);
			fontDialog.Font = labelTime.Font;
			DialogResult result = fontDialog.ShowDialog();
			if (result == DialogResult.OK)
				labelTime.Font = fontDialog.Font;
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
			SaveSettings();
			alarms.SaveAlarms();
		}

		private void tsmiAlarms_Click(object sender, EventArgs e)
		{
			alarms.Location = (this.Location.X - alarms.Width < 0) ?

				new Point(this.Location.X + this.Width,
				this.Location.Y)
				:
				new Point
				(this.Location.X - alarms.Width,
				this.Location.Y)
				;
			alarms.ShowDialog();
		}

		private void tsmiShowConsole_CheckedChanged(object sender, EventArgs e)
		{
			if ((sender as ToolStripMenuItem).Checked) AllocConsole();
			else FreeConsole();
		}
		[DllImport("kernel32.dll")]
		public static extern void AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern void FreeConsole();

		private void Sleep_btn_Click(object sender, EventArgs e)
		{
			alarm = new Alarm();
			//alarm = FindNextAlarm();
			alarm = alarms.List.Items[0] as Alarm;
			string time_sleep = $"{alarm.Date.ToString("dd.MM.yyyy")} {alarm.Time}";
			if (alarm != null) MessageBox.Show(time_sleep);
			else MessageBox.Show("???");
			WakeUP wup = new WakeUP();
			wup.Woken += WakeUP_Woken;
			dateTime = Convert.ToDateTime(time_sleep);
			wup.SetWakeUpTime(dateTime);
			Application.SetSuspendState(PowerState.Suspend, false, false);
		}
		private void WakeUP_Woken(object sender, EventArgs e)
		{
			MessageBox.Show("Do something!!!");
		}
	}
}
