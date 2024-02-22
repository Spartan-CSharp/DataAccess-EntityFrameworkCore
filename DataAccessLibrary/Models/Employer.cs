using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLibrary.Models
{
	public class Employer
	{
		[Required]
		[Key]
		public int Id { get; set; }
		[MaxLength(200)]
		[Required]
		public string CompanyName { get; set; }
		public virtual ICollection<Person> People { get; set; } = new List<Person>();
		public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
	}
}
