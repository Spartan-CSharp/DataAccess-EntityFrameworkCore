using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLibrary.Models
{
	public class Address
	{
		[Required]
		[Key]
		public int Id { get; set; }
		[MaxLength(200)]
		[Required]
		public string StreetAddress { get; set; }
		[MaxLength(50)]
		[Required]
		public string City { get; set; }
		[MaxLength(10)]
		[Required]
		public string State { get; set; }
		[MaxLength(10)]
		[Required]
		public string ZipCode { get; set; }
	}
}
