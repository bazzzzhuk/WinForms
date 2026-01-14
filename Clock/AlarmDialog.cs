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
	}
}
