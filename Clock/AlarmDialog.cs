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
	public partial class AlarmDialog : Form
	{
		OpenFileDialog fileDialog;
		public Alarm Alarm { get; private set; }
		public AlarmDialog()
		{
			InitializeComponent();
			dtpDate.Enabled = false;
			fileDialog = new OpenFileDialog();
			fileDialog.Filter =
				"All sound files (*.mp3; *.flac; *.flacc; *.wav; *.ogg) |*.mp3; *.flac; *.flacc; *.wav; *.ogg|" +
				"MP3 files(*.mp3)|*.mp3|" +
				"Flac files (*.flac; *.flacc)|*.flac;*.flacc|" +
				"WAV files (*.wav)|*.wav|" +
				"OGG files (*.ogg)|*.ogg";
			Alarm = new Alarm();
		}
		public AlarmDialog(Alarm alarm):this()
		{
			Alarm = alarm;
			Extract();
		}
		void Extract()
		{
			if (Alarm.Date != DateTime.MinValue)
			{ 
				dtpDate.Value = Alarm.Date; 
				checkBoxUseDate.Checked = true;
			}
			dtpTime.Value = Alarm.Time;
			Alarm.Days.Extract(clbWeekDays);
			labelFilename.Text = Alarm.Filename;
		}

		private void checkBoxUseDate_CheckedChanged(object sender, EventArgs e)
		{
			dtpDate.Enabled = (sender as CheckBox).Checked;
			clbWeekDays.Enabled = !dtpDate.Enabled;
		}

		private void buttonADD_Click(object sender, EventArgs e)
		{
			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				string ext = System.IO.Path.GetExtension(fileDialog.FileName);
				if (String.Compare(ext, ".url", true) == 0)
				{
					fileDialog.FileName = null;
					//DialogResult = DialogResult.Retry;
				}
				else
					labelFilename.Text = fileDialog.FileName;
			}


		}

		private void clbWeekDays_ItemCheck(object sender, ItemCheckEventArgs e)
		{
		}

		private void clbWeekDays_SelectedIndexChanged(object sender, EventArgs e)
		{
			Console.WriteLine("clbWeekDays_selectedIndexChanges");
			for (int i = 0; i < clbWeekDays.CheckedItems.Count; i++)
				Console.Write($"{clbWeekDays.CheckedItems[i]}\t");
			Console.WriteLine();
			byte days = 0;
			for (int i = 0; i < clbWeekDays.CheckedIndices.Count; i++)
			{
				days |= (byte)(1 << clbWeekDays.CheckedIndices[i]);
				Console.Write($"{clbWeekDays.CheckedIndices[i]}\t");
			}
			Console.WriteLine($"Days mask:{days}");
			Console.WriteLine("\n---------------------------------\n");

		}
		byte GetDaysMask()
		{
			byte days = 0;
			for (int i = 0; i < clbWeekDays.CheckedIndices.Count; i++)
				days |= (byte)(1 << clbWeekDays.CheckedIndices[i]);
			return days;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			Alarm.Date = checkBoxUseDate.Checked?dtpDate.Value : DateTime.MinValue;
			Alarm.Time = dtpTime.Value;
			Alarm.Days = new Week(GetDaysMask());
			Alarm.Filename = labelFilename.Text;
		}
	}
}
