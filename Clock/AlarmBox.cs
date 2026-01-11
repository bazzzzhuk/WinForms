using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;
using Microsoft.Win32;

namespace Clock
{
	public partial class AlarmBox : UserControl
	{
		bool Alarm = false;
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AllocConsole();
		public AlarmBox()
		{
			AllocConsole();
			InitializeComponent();
			this.chcdWeekDay.Items.AddRange(new object[] {
			"Пн",
			"Вт",
			"Ср",
			"Чт",
			"Пт",
			"Сб",
			"Вс"});
			if (Alarm)
				Console.WriteLine("!!!!");
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void OneTime_CheckedChanged(object sender, EventArgs e)
		{
			chcdWeekDay.Visible = !OneTime.Checked;
		}

		private void timer1_Tick_1(object sender, EventArgs e)
		{
			if (OnOff_Alarm.Checked && !Alarm)
			{
				if (dateTimePicker1.Value.ToString("HH:mm") == DateTime.Now.ToString("HH:mm"))
				{
					Alarm = true;
					this.OnOff_Alarm.Checked = false;
					//this.timer1.Stop();
					//this.timer1.Dispose();
					//this.timer1 = null;
				Console.WriteLine("Сработал будильник");
				//MessageBox.Show
				//		(
				//		"!!!",
				//		"!!!",
				//		MessageBoxButtons.OK,
				//		MessageBoxIcon.Information
				//		);
				}
			}

		}

		private void dateTimePicker1_EnabledChanged(object sender, EventArgs e)
		{
		}

		private void OnOff_Alarm_CheckedChanged(object sender, EventArgs e)
		{
			if(OnOff_Alarm.Checked==false&&Alarm)Alarm = false;
		}
	}
}
