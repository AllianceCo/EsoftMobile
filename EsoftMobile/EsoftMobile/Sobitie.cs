using SQLite;
using System;

namespace EsoftMobile
{
	[Table("Sobitie")]
	public class Sobitie
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string FIO { get; set; }
		public string Type { get; set; }
		public int Phone { get; set; }
		public string Comment { get; set; }
		public DateTime Date { get; set; }
	}
}
