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
	public partial class AlarmsForm : Form
	{
	AlarmDialog alarm;
		public AlarmsForm()
		{
			InitializeComponent();
			alarm = new AlarmDialog();
			this.Location = new Point
				(Screen.PrimaryScreen.Bounds.Width - this.Width - 350,
				350
				);
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			alarm.ShowDialog();
		}
	}
}
