using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Text;

using DataAccessLibrary.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DataAccessLibrary.EFDataAccess
{
	internal class EFContext : DbContext
	{
		internal DbSet<Person> People { get; set; }
		internal DbSet<Employer> Employers { get; set; }
		internal DbSet<Address> Addresses { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			IConfigurationBuilder builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			IConfiguration config = builder.Build();

			string connectionstring = config.GetConnectionString("EFSQL");

			base.OnConfiguring(optionsBuilder);
			_ = optionsBuilder.UseSqlServer(connectionstring);
		}
	}
}
