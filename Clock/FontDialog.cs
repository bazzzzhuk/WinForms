using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace Clock
{
	public partial class FontDialog : Form
	{
		public Font Font { get; set; }
		public string Filename {  get; set; }

		int lasthosenIndex;
		public FontDialog()
		{
			InitializeComponent();
			lasthosenIndex = 0;
			LoadFonts("*.ttf");
			LoadFonts("*.otf");
			comboBoxFont.SelectedIndex = 1;
		}
		public FontDialog(string Fontname):this()
		{
			Filename = Fontname;
			lasthosenIndex =  comboBoxFont.FindString(Fontname);
			if(lasthosenIndex==-1)comboBoxFont.SelectedIndex = 1;
			comboBoxFont.SelectedIndex = lasthosenIndex;
			SetFont();
			Font = labelExample.Font;
		}

		private void FontDialog_Load(object sender, EventArgs e)
		{
			numericUpDownFontSize.Value = (decimal)Font.Size;
		}
		void LoadFonts(string extension)
		{
			string currentDir = Application.ExecutablePath;
			Directory.SetCurrentDirectory($"{currentDir}\\..\\..\\..\\Fonts");
			//MessageBox.Show
			//	(
			//	this,
			//	//currentDir,
			//	Directory.GetCurrentDirectory(),
			//	"CurrentDirectory",
			//	MessageBoxButtons.OK,
			//	MessageBoxIcon.Information
			//	);

			string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), extension);
			for (int i = 0; i < files.Length; i++)
			{
				comboBoxFont.Items.Add(files[i].Split('\\').Last());
			}
		}

		private void comboBoxFont_SelectedIndexChanged(object sender, EventArgs e)
		{
			string info = $"selected:\nIndex:\t{comboBoxFont.SelectedIndex.ToString()}";
			info += $"\nItem:{comboBoxFont.SelectedItem}";
			info += $"\nText:{comboBoxFont.SelectedText}";
			info += $"\nValue:{comboBoxFont.SelectedValue}";
			//MessageBox.Show(this, info, "SelectedIdexChanged", MessageBoxButtons.OK, MessageBoxIcon.Information);
			SetFont();
		}
		void SetFont()
		{
			Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..\\..\\..\\Fonts");
			PrivateFontCollection pfc = new PrivateFontCollection();
			pfc.AddFontFile(comboBoxFont.SelectedItem.ToString());
			labelExample.Font = new Font(pfc.Families[0], (float)numericUpDownFontSize.Value);
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			this.Font = labelExample.Font;
			this.Filename = comboBoxFont.SelectedItem.ToString();
			this.lasthosenIndex = comboBoxFont.SelectedIndex;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			labelExample.Font = this.Font;
			comboBoxFont.SelectedIndex = lasthosenIndex;
		}

		private void numericUpDownFontSize_ValueChanged(object sender, EventArgs e)
		{
			SetFont();
		}
	}
}
