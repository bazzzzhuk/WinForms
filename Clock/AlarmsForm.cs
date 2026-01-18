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
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			AlarmDialog alarm = new AlarmDialog();
			alarm.TopMost = true;
			alarm.Location = new Point(this.Location.X + alarm.Width*2-110, this.Location.Y+130);
			if (alarm.ShowDialog() == DialogResult.OK)
			{
				listBoxAlarms.Items.Add(new Alarm(alarm.Alarm));
			}
			
		}

		private void listBoxAlarms_DoubleClick(object sender, EventArgs e)
		{
			if(listBoxAlarms.Items.Count > 0 && listBoxAlarms.SelectedItem != null)
			{
				AlarmDialog alarm = new AlarmDialog(listBoxAlarms.SelectedItem as Alarm);
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
			StreamWriter writer = new StreamWriter("AlarmsSettings.ini");

			for (int i = 0; i < listBoxAlarms.Items.Count; i++)
			{
				//writer.WriteLine((listBoxAlarms.Items[i] as Alarm).ToString());
				writer.WriteLine("Alarm:");
				writer.WriteLine(DateTime.Today.Add((listBoxAlarms.Items[i] as Alarm).Time).ToString("HH:mm:ss"));
				writer.WriteLine((listBoxAlarms.Items[i] as Alarm).Date.ToString("yyyy.MM.dd"));
				writer.WriteLine((listBoxAlarms.Items[i] as Alarm).Days);
				writer.WriteLine((listBoxAlarms.Items[i] as Alarm).Filename.Split('\\').Last().ToString());
			}

			writer.Close();
			System.Diagnostics.Process.Start("notepad", "AlarmsSettings.ini");
		}
		private void AlarmsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			//SaveAlarms();
		}

		private void AlarmsForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			//SaveAlarms();
		}
	}
}
