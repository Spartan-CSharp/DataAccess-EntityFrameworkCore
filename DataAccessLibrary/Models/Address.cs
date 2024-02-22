using System.ComponentModel.DataAnnotations;

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
