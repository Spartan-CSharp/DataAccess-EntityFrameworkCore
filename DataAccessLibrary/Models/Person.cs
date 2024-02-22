using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLibrary.Models
{
	public class Person
	{
		[Required]
		[Key]
		public int Id { get; set; }
		[MaxLength(50)]
		[Required]
		public string FirstName { get; set; }
		[MaxLength(50)]
		[Required]
		public string LastName { get; set; }
		public bool? IsActive { get; set; }
		public Employer? Employer { get; set; }
		public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
	}
}
