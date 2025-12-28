//#define SHOWMESSAGE
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
		int lasthosenIndex;
		public FontDialog()
		{
			InitializeComponent();
			lasthosenIndex = 1;
			LoadFonts("*.ttf");
			LoadFonts("*.otf");
			//comboBoxFont.SelectedIndex = 1;
			int i = comboBoxFont.FindString(Properties.Settings.Default.CTPath.ToString());
			comboBoxFont.SelectedIndex = i;
#if SHOWMESSAGE
			MessageBox.Show(
					null,
					i.ToString(),
					"Выбранный элемент КомбоБокса",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information); 
#endif

		}

		private void FontDialog_Load(object sender, EventArgs e)
		{
			//MessageBox.Show(
			//	null,
			//	Properties.Settings.Default.my_size_font.ToString(),
			//	"my_size_font 1",
			//MessageBoxButtons.OK,
			//MessageBoxIcon.Information);
			//numericUpDownFontSize.Value = decimal.Parse(Properties.Settings.Default.my_size_font.ToString());
			//MessageBox.Show(
			//	null,
			//	numericUpDownFontSize.Value.ToString(),
			//	"my_size_font 2",
			//MessageBoxButtons.OK,
			//MessageBoxIcon.Information);
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
			numericUpDownFontSize.Value = decimal.Parse(Properties.Settings.Default.my_size_font.ToString());

			SetFont();
		}
		void SetFont()
		{
			PrivateFontCollection pfc = new PrivateFontCollection();
#if SHOWMESSAGE
			MessageBox.Show(
					null,
					comboBoxFont.SelectedItem.ToString(),
					"SetFont()",
				MessageBoxButtons.OK,
				MessageBoxIcon.Information); 
#endif
			Clock.Properties.Settings.Default.CTPath = comboBoxFont.SelectedItem.ToString();
			pfc.AddFontFile(comboBoxFont.SelectedItem.ToString());
			labelExample.Font = new Font(pfc.Families[0], (float)numericUpDownFontSize.Value);
			Properties.Settings.Default.myExFont = labelExample.Font;
			Properties.Settings.Default.my_size_font = labelExample.Font.Size.ToString();
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			this.Font = labelExample.Font;
			Properties.Settings.Default.CTPath = comboBoxFont.SelectedItem.ToString();
			Properties.Settings.Default.Save();
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
