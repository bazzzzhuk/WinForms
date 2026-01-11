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
	public partial class AlarmsDialog : Form
	{
		public List<AlarmBox> alarmsList { get; set; }
		int x = 0, y = 0;

		public AlarmsDialog()
		{
			InitializeComponent();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			AlarmBox alarmBox = new AlarmBox();
			flowLP.Controls.Add(alarmBox);
			
		}
		

	}
}
