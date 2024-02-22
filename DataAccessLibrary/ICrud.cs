using System;
using System.Collections.Generic;
using System.Text;

using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
	public interface ICrud
	{
		void CreateAddress(Address address);
		void CreateEmployer(Employer employer);
		void CreatePerson(Person person);
		void DeleteAddress(Address address);
		void DeleteEmployer(Employer employer);
		void DeletePerson(Person person);
		Address RetrieveAddressById(int id);
		List<Address> RetrieveAllAddresses();
		List<Employer> RetrieveAllEmployers();
		List<Person> RetrieveAllPeople();
		Employer RetrieveEmployerById(int id);
		List<Person> RetrievePeopleByEmployerId(int employerId);
		Person RetrievePersonById(int id);
		void UpdateAddress(Address address);
		void UpdateEmployer(Employer employer);
		void UpdatePerson(Person person);
	}
}
