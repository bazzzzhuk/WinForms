using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Clock
{
	public partial class AlarmsForm : Form
	{
		//AlarmDialog alarm;
		public ListBox List { get => listBoxAlarms; }
		public AlarmsForm()
		{
			InitializeComponent();
			//alarm = new AlarmDialog();	
			LoadAlarms();
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			AlarmDialog alarm = new AlarmDialog();
			alarm.TopMost = true;
			alarm.Location = new Point(this.Location.X + alarm.Width * 2 - 110, this.Location.Y + 130);
			if (alarm.ShowDialog() == DialogResult.OK)
			{
				listBoxAlarms.Items.Add(new Alarm(alarm.Alarm));
			}

		}

		private void listBoxAlarms_DoubleClick(object sender, EventArgs e)
		{
			if (listBoxAlarms.Items.Count > 0 && listBoxAlarms.SelectedItem != null)
			{
				AlarmDialog alarm = new AlarmDialog(listBoxAlarms.SelectedItem as Alarm);
				alarm.TopMost = true;
				alarm.Location = new Point(this.Location.X + alarm.Width * 2 - 110, this.Location.Y + 130);
				alarm.ShowDialog();
				listBoxAlarms.Items[listBoxAlarms.SelectedIndex] = new Alarm(alarm.Alarm);
			}
			else
			{
				buttonAdd_Click(sender, e);
			}
		}

		public void SaveAlarms()
		{
			Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
			//if(listBoxAlarms.Items.Count == 0)return;
			StreamWriter writer = new StreamWriter("AlarmsSettings.ini");
			for (int i = 0; i < listBoxAlarms.Items.Count; i++)
			{
				writer.WriteLine((listBoxAlarms.Items[i] as Alarm).AlarmToString());
			}
			writer.Close();
			//System.Diagnostics.Process.Start("notepad", "AlarmsSettings.ini");
		}
		
		public void LoadAlarms()
		{
			Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..");
			try
			{
				StreamReader reader = new StreamReader("AlarmsSettings.ini");
				//string alarm_ok = reader.ReadLine();
				//if (new FileInfo("AlarmsSettings.ini").Length == 0) return;
				string s = "";
				while (reader.ReadLine() == "Alarm:")
				{
					Alarm alarm = new Alarm();
					//string DateAndTime = reader.ReadLine() + " " + reader.ReadLine();
					DateTime load_day = DateTime.Parse(reader.ReadLine().ToString());
					//load_day = DateTime.MaxValue;
					//MessageBox.Show(load_day.ToString());
					if(load_day.ToString()== "31.12.9999 23:59:59")load_day = DateTime.MaxValue;
					alarm.Date = load_day; 
						//DateTime.Parse(load_day.ToString("yyyy.MM.dd"));
					//MessageBox.Show(DT.Date.ToString("yyyy.MM.dd"));
					alarm.Time = TimeSpan.Parse(reader.ReadLine());
					alarm.Days = null;
					s = reader.ReadLine();
					//MessageBox.Show(s);
					alarm.Days = new Week(byte.Parse(s));
					alarm.Filename = reader.ReadLine().ToString();
					//AlarmDialog alarm_l = new AlarmDialog(alarm);
					List.Items.Add(new Alarm(alarm));
					//MessageBox.Show(alarm.ToString());
				}

				reader.Close();
			}
			catch (Exception ex)
			{
				//reader.Close();
				MessageBox.Show(this, ex.Message, "AlarmSettingsException", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}

		}
		private void AlarmsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			//SaveAlarms();
		}

		private void AlarmsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			//SaveAlarms();
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (listBoxAlarms.SelectedIndex != -1)
				listBoxAlarms.Items.RemoveAt(listBoxAlarms.SelectedIndex);
		}

	}
}
