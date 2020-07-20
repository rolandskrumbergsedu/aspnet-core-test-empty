using AspNetCoreTestEmpty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreTestEmpty.Services
{
    public class PersonService : IPersonService
    {
        private static List<Person> _allPeople = new List<Person>
        {
            new Person
            {
                Id = 1,
                Address = "Test address",
                Age = 10,
                Email = "test@test.com",
                IsMale = true,
                Name = "Test",
                Surname = "Test again"
            },
            new Person
            {
                Id = 2,
                Address = "Test address 2",
                Age = 100,
                Email = "test2@test.com",
                IsMale = false,
                Name = "Test 2",
                Surname = "Test again 2"
            }
        };

        public Person AddPerson(Person person)
        {
            _allPeople.Add(person);
            return person;
        }

        public void DeletePersonById(string id)
        {
            var personToRemove = _allPeople.FirstOrDefault(x => x.Id.ToString() == id);
            _allPeople.Remove(personToRemove);
        }

        public List<Person> GetPeople()
        {
            return _allPeople;
        }

        public Person UpdatePerson(Person person)
        {
            var personToUpdate = _allPeople.FirstOrDefault(x => x.Id == person.Id);
            personToUpdate.Name = person.Name;
            personToUpdate.Surname = person.Surname;
            personToUpdate.IsMale = person.IsMale;
            personToUpdate.Address = person.Address;
            personToUpdate.Age = person.Age;
            personToUpdate.Email = person.Email;
            return personToUpdate;
        }
    }
}
