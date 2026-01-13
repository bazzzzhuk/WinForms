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
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			alarm.Location = new Point(this.Location.X + alarm.Width*2-110, this.Location.Y+130);
			alarm.ShowDialog();
		}
	}
}
