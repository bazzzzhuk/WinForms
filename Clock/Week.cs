using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
	public class Week
	{
		static readonly string[] NAMES = { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" };
		byte days;
		public byte DaysMask
		{
			get => days;
			set { days = value; }
		}
		public Week(byte days)
		{
			this.days = days;
		}
		public override string ToString()
		{
			string days = "";
			for (byte i = 0; i < 7; i++)
			{
				byte day = (byte)(1 << i);
				if ((this.days & day) != 0) days += $"{NAMES[i]}," ;
			}
			days = days.Trim(',');
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
