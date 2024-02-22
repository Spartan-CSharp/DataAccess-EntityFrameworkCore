﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using DataAccessLibrary.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary.EFDataAccess
{
	public class EFCrud : ICrud
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionStringName;

		public EFCrud(IConfiguration configuration, string connectionStringName)
		{
			_configuration = configuration;
			_connectionStringName = connectionStringName;
		}

		public void CreatePerson(Person person)
		{
			using ( EFContext db = new EFContext() )
			{
				db.People.Add(person);
				db.SaveChanges();
			}
		}

		public void CreateEmployer(Employer employer)
		{
			using ( EFContext db = new EFContext() )
			{
				db.Employers.Add(employer);
				db.SaveChanges();
			}
		}
		public void CreateAddress(Address address)
		{
			using ( EFContext db = new EFContext() )
			{
				db.Addresses.Add(address);
				db.SaveChanges();
			}
		}

		public List<Person> RetrieveAllPeople()
		{
			using ( EFContext db = new EFContext() )
			{
				List<Person> output = db.People.Include(e => e.Employer).Include(a => a.Addresses).ToList();
				return output;
			}
		}

		public Person RetrievePersonById(int id)
		{
			using ( EFContext db = new EFContext() )
			{
				Person output = db.People.Include(e => e.Employer).Include(a => a.Addresses).Where(p => p.Id == id).First();
				return output;
			}
		}

		public List<Person> RetrievePeopleByEmployerId(int employerId)
		{
			using ( EFContext db = new EFContext() )
			{
				List<Person> output = db.People.Include(e => e.Employer).Include(a => a.Addresses).Where(p => p.Employer.Id == employerId).ToList();
				return output;
			}
		}

		public List<Employer> RetrieveAllEmployers()
		{
			using ( EFContext db = new EFContext() )
			{
				List<Employer> output = db.Employers.Include(a => a.Addresses).ToList();
				return output;
			}
		}

		public Employer RetrieveEmployerById(int id)
		{
			using ( EFContext db = new EFContext() )
			{
				Employer output = db.Employers.Include(a => a.Addresses).Where(e => e.Id == id).First();
				return output;
			}
		}

		public List<Address> RetrieveAllAddresses()
		{
			using ( EFContext db = new EFContext() )
			{
				List<Address> output = db.Addresses.ToList();
				return output;
			}
		}

		public Address RetrieveAddressById(int id)
		{
			using ( EFContext db = new EFContext() )
			{
				Address output = db.Addresses.Where(a => a.Id == id).First();
				return output;
			}
		}

		public void UpdatePerson(Person person)
		{
			using ( EFContext db = new EFContext() )
			{
				Person record = db.People.Include(e => e.Employer).Include(a => a.Addresses).Where(p => p.Id == person.Id).First();

				record.FirstName = person.FirstName;
				record.LastName = person.LastName;
				record.IsActive = person.IsActive;

				record.Addresses.Clear();

				foreach ( Address item in person.Addresses )
				{
					record.Addresses.Add(item);
				}

				record.Employer = person.Employer;

				db.SaveChanges();
			}
		}

		public void UpdateEmployer(Employer employer)
		{
			using ( EFContext db = new EFContext() )
			{
				Employer record = db.Employers.Include(a => a.Addresses).Where(e => e.Id == employer.Id).First();

				record.CompanyName = employer.CompanyName;

				record.Addresses.Clear();

				foreach ( Address item in employer.Addresses )
				{
					record.Addresses.Add(item);
				}

				db.SaveChanges();
			}
		}

		public void UpdateAddress(Address address)
		{
			using ( EFContext db = new EFContext() )
			{
				Address record = db.Addresses.Where(a => a.Id == address.Id).First();

				record.StreetAddress = address.StreetAddress;
				record.City = address.City;
				record.State = address.State;
				record.ZipCode = address.ZipCode;

				db.SaveChanges();
			}
		}

		public void DeletePerson(Person person)
		{
			using ( EFContext db = new EFContext() )
			{
				Person record = db.People.Include(e => e.Employer).Include(a => a.Addresses).Where(p => p.Id == person.Id).First();

				db.People.Remove(record);

				db.SaveChanges();
			}
		}

		public void DeleteEmployer(Employer employer)
		{
			using ( EFContext db = new EFContext() )
			{
				Employer record = db.Employers.Include(a => a.Addresses).Where(e => e.Id == employer.Id).First();

				db.Employers.Remove(record);

				db.SaveChanges();
			}
		}

		public void DeleteAddress(Address address)
		{
			using ( EFContext db = new EFContext() )
			{
				Address record = db.Addresses.Where(a => a.Id == address.Id).First();

				db.Addresses.Remove(record);

				db.SaveChanges();
			}
		}
	}
}
