using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
	public interface IDataLogic
	{
		void DeleteAddress(Address address);
		void DeleteEmployer(Employer employer);
		void DeletePerson(Person person);
		Address GetAddressById(int addressId);
		List<Address> GetAllAddresses();
		List<Employer> GetAllEmployers();
		List<Person> GetAllPeople();
		Employer GetEmployerById(int employerId);
		Person GetPersonById(int personId);
		void SaveNewAddress(Address address);
		void SaveNewEmployer(Employer employer);
		void SaveNewPerson(Person person);
		void UpdateAddress(Address address);
		void UpdateEmployer(Employer employer);
		void UpdatePerson(Person person);
	}
}
