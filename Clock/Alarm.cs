using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
	public class Alarm
	{
		public DateTime Date {  get; set; }	
		public DateTime Time { get; set; }
		public Week Days { get; set; }
		public string Filename { get; set; }
		public override string ToString()
		{
			string info = "";
			info += $"{Time.ToString("HH:mm:ss")} ";
			//info += $"\t{Days}";
			info += Date != DateTime.MinValue ? 
				Date.ToString("dd.MM.yyyy") : (Days.DaysMask != 0 && Days.DaysMask != 127 ?
				Days.ToString()+(Days.DaysMask.ToString().Length < 7 ? "" : "  ") : "Каждый день");
			info += $"\t{Filename.Split('\\').Last()}";
			return info;
		}
	}
}
