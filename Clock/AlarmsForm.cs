using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
	public partial class AlarmsForm : Form
	{
		AlarmDialog alarm;
		public AlarmsForm()
		{
			InitializeComponent();
			alarm = new AlarmDialog();
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			alarm.TopMost = true;
			alarm.Location = new Point(this.Location.X + alarm.Width * 2 - 110, this.Location.Y + 130);
			if (alarm.ShowDialog() == DialogResult.OK)
			{
				listBoxAlarms.Items.Add(alarm.Alarm);
			}
		}

		private void listBoxAlarms_SelectedIndexChanged(object sender, EventArgs e)
		{
			//if (listBoxAlarms.SelectedIndex == -1) return;
			//Alarm selectAlarm = this.listBoxAlarms.SelectedItem as Alarm;
			//MessageBox.Show($"{selectAlarm}");
			//alarm.Location = new Point(this.Location.X + alarm.Width * 2 - 110, this.Location.Y + 130);
			//alarm.TopMost = true;
			//alarm.editAlarm(selectAlarm);
			//if (alarm.ShowDialog() == DialogResult.OK)
			//	listBoxAlarms.Items[listBoxAlarms.SelectedIndex] = alarm.Alarm;
		}

		private void listBoxAlarms_DoubleClick(object sender, EventArgs e)
		{
			if (listBoxAlarms.SelectedIndex == -1) return;
			MessageBox.Show($"{listBoxAlarms.SelectedIndex}");
			this.listBoxAlarms.SelectedItem = listBoxAlarms.SelectedIndex;
			Alarm selectAlarm = listBoxAlarms.SelectedItem as Alarm;
			MessageBox.Show($"{selectAlarm}");
			alarm.Location = new Point(this.Location.X + alarm.Width * 2 - 110, this.Location.Y + 130);
			alarm.TopMost = true;
			alarm.editAlarm(selectAlarm);
			alarm.Refresh();
			if (alarm.ShowDialog() == DialogResult.OK)
				listBoxAlarms.Items[listBoxAlarms.SelectedIndex] = alarm.Alarm;
		}
	}
}
