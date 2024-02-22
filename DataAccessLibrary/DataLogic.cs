using System;
using System.Collections.Generic;
using System.Net;

using DataAccessLibrary.EFDataAccess;
using DataAccessLibrary.Models;

using Microsoft.Extensions.Configuration;

namespace DataAccessLibrary
{
	public class DataLogic : IDataLogic
	{
		private readonly IConfiguration _configuration;
		private readonly ICrud _crud;

		public DataLogic(IConfiguration configuration, DBTYPES dbType)
		{
			_configuration = configuration;
			switch ( dbType )
			{
				case DBTYPES.EntityFramework:
					_crud = new EFCrud(_configuration, "EFSQL");
					break;
				default:
					break;
			}
		}

		public void SaveNewAddress(Address address)
		{
			_crud.CreateAddress(address);
		}

		public void SaveNewEmployer(Employer employer)
		{
			_crud.CreateEmployer(employer);
		}

		public void SaveNewPerson(Person person)
		{
			_crud.CreatePerson(person);
		}

		public void DeleteAddress(Address address)
		{
			_crud.DeleteAddress(address);
		}

		public void DeleteEmployer(Employer employer)
		{
			_crud.DeleteEmployer(employer);
		}

		public void DeletePerson(Person person)
		{
			_crud.DeletePerson(person);
		}

		public Address GetAddressById(int addressId)
		{
			Address output = _crud.RetrieveAddressById(addressId);
			return output;
		}

		public List<Address> GetAllAddresses()
		{
			List<Address> output = _crud.RetrieveAllAddresses();
			return output;
		}

		public List<Employer> GetAllEmployers()
		{
			List<Employer> output = _crud.RetrieveAllEmployers();
			return output;
		}

		public List<Person> GetAllPeople()
		{
			List<Person> output = _crud.RetrieveAllPeople();
			return output;
		}

		public Employer GetEmployerById(int employerId)
		{
			Employer output = _crud.RetrieveEmployerById(employerId);
			return output;
		}

		public Person GetPersonById(int personId)
		{
			Person output = _crud.RetrievePersonById(personId);
			return output;
		}

		public void UpdateAddress(Address address)
		{
			_crud.UpdateAddress(address);
		}

		public void UpdateEmployer(Employer employer)
		{
			_crud.UpdateEmployer(employer);
		}

		public void UpdatePerson(Person person)
		{
			_crud.UpdatePerson(person);
		}
	}
}
