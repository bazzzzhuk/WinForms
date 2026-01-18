using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
	public class Week
	{
		static readonly string[] NAMES = { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };
		public byte days { get; set; }

		
		public Week(byte days)
		{
			this.days = days;
		}
		public void Extract(System.Windows.Forms.CheckedListBox clb)
		{
			if (clb.Items.Count != 7) return;
			for(byte i = 0; i < 7; i++)
			{
				//(clb.Items[i] as CheckBox).Checked = Convert.ToBoolean((1<<i) & days);
				clb.SetItemChecked(i, Convert.ToBoolean((1 << i) & days));
			}
				//return clb;
		}
		public byte Extract(string s)
		{
			string[] ss = s.Split(',').ToArray();
			byte days = 0;
			MessageBox.Show(ss.Length.ToString());
			if (ss.Length==null) return days;
			for(byte i = 0; i < 7; i++)
			{
				if (ss.Contains(NAMES[i]))
					days |= (byte)(1 << i);
			}
				return days;
		}
		
		public override string ToString()
		{
			string days = "";
			for (byte i = 0; i < 7; i++)
			{
				byte day = (byte)(1 << i);
				if ((this.days & day) != 0) days += $"{NAMES[i]}," ;
			}
			days = days.TrimEnd(',');
			return days;
			/*
			 * -----------------------------------------------
			 ~ NOT Побитовое отрицание (инверсия - это унарная операция при которой единицы заменяются нулями и наоборот)
			 | OR - Побитовое сложение
			 
			  << SHL - Shift left, умножение на два в степени
			  >> SHR = деление
			 */
		}
	}
}
