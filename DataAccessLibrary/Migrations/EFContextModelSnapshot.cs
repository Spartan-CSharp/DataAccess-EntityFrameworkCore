﻿// <auto-generated />
using System;

using DataAccessLibrary.EFDataAccess;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLibrary.Migrations
{
	[DbContext(typeof(EFContext))]
	partial class EFContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "3.1.32")
				.HasAnnotation("Relational:MaxIdentifierLength", 128)
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			modelBuilder.Entity("DataAccessLibrary.Models.Address", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int")
						.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

					b.Property<string>("City")
						.IsRequired()
						.HasColumnType("nvarchar(50)")
						.HasMaxLength(50);

					b.Property<int?>("EmployerId")
						.HasColumnType("int");

					b.Property<int?>("PersonId")
						.HasColumnType("int");

					b.Property<string>("State")
						.IsRequired()
						.HasColumnType("nvarchar(10)")
						.HasMaxLength(10);

					b.Property<string>("StreetAddress")
						.IsRequired()
						.HasColumnType("nvarchar(200)")
						.HasMaxLength(200);

					b.Property<string>("ZipCode")
						.IsRequired()
						.HasColumnType("nvarchar(10)")
						.HasMaxLength(10);

					b.HasKey("Id");

					b.HasIndex("EmployerId");

					b.HasIndex("PersonId");

					b.ToTable("Addresses");
				});

			modelBuilder.Entity("DataAccessLibrary.Models.Employer", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int")
						.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

					b.Property<string>("CompanyName")
						.IsRequired()
						.HasColumnType("nvarchar(200)")
						.HasMaxLength(200);

					b.HasKey("Id");

					b.ToTable("Employers");
				});

			modelBuilder.Entity("DataAccessLibrary.Models.Person", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("int")
						.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

					b.Property<int?>("EmployerId")
						.HasColumnType("int");

					b.Property<string>("FirstName")
						.IsRequired()
						.HasColumnType("nvarchar(50)")
						.HasMaxLength(50);

					b.Property<bool?>("IsActive")
						.HasColumnType("bit");

					b.Property<string>("LastName")
						.IsRequired()
						.HasColumnType("nvarchar(50)")
						.HasMaxLength(50);

					b.HasKey("Id");

					b.HasIndex("EmployerId");

					b.ToTable("People");
				});

			modelBuilder.Entity("DataAccessLibrary.Models.Address", b =>
				{
					b.HasOne("DataAccessLibrary.Models.Employer", null)
						.WithMany("Addresses")
						.HasForeignKey("EmployerId");

					b.HasOne("DataAccessLibrary.Models.Person", null)
						.WithMany("Addresses")
						.HasForeignKey("PersonId");
				});

			modelBuilder.Entity("DataAccessLibrary.Models.Person", b =>
				{
					b.HasOne("DataAccessLibrary.Models.Employer", "Employer")
						.WithMany("People")
						.HasForeignKey("EmployerId");
				});
#pragma warning restore 612, 618
		}
	}
}
