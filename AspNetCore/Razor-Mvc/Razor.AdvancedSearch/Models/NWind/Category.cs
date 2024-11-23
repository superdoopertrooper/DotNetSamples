using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EqDemo.Models
{
	public class Asin
	{
		public string AsinName { get; set; }

		public string Description { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("AsinID")]
		public int Id { get; set; }

		[ScaffoldColumn(false)]
		public byte[] Picture { get; set; }
	}

	public class Category
	{
		public string CategoryName { get; set; }

		public string Description { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		[Column("CategoryID")]
		public int Id { get; set; }

		[ScaffoldColumn(false)]
		public byte[] Picture { get; set; }
	}
}