using AspNetCoreTestEmpty.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AspNetCoreTestEmpty.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
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

        [HttpGet]
        public ActionResult<List<Person>> Get()
        {
            return _allPeople;
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(string id)
        {
            return _allPeople.FirstOrDefault(x => x.Id.ToString() == id);
        }

        [HttpPost]
        public ActionResult<Person> Add(Person person)
        {
            _allPeople.Add(person);
            return person;
        }

        [HttpPut]
        public ActionResult<Person> Update(Person person)
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

        [HttpDelete("{id}")]
        public ActionResult<Person> Delete(string id)
        {
            var personToRemove = _allPeople.FirstOrDefault(x => x.Id.ToString() == id);
            _allPeople.Remove(personToRemove);
            return Ok();
        }
    }
}
