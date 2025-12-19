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
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			this.MaximizeBox = false;
			this.MinimizeBox = false;
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
				labelTime.Text +=$"\n{DateTime.Now.ToString("yyyy:MM:dd")}";
			if (cb_ShowWeekday.Checked)
				labelTime.Text += $"\n{DateTime.Now.DayOfWeek}";
				
		}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}

		private void btn_HideControls_Click(object sender, EventArgs e)
		{
			cb_ShowDate.Visible = false;
			cb_ShowWeekday.Visible = false;
			btn_HideControls.Visible = false;
			this.ShowInTaskbar = false;
		}
	}
}
