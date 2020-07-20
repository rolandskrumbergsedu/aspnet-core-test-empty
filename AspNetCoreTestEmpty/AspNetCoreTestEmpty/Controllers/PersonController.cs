using AspNetCoreTestEmpty.Models;
using AspNetCoreTestEmpty.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreTestEmpty.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<List<Person>> Get()
        {
            return _personService.GetPeople();
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(string id)
        {
            return _personService.GetPeople().FirstOrDefault(x => x.Id.ToString() == id);
        }

        [HttpPost]
        public ActionResult<Person> Add(Person person)
        {
            _personService.AddPerson(person);
            return person;
        }

        [HttpPut]
        public ActionResult<Person> Update(Person person)
        {
            return _personService.UpdatePerson(person);
        }

        [HttpDelete("{id}")]
        public ActionResult<Person> Delete(string id)
        {
            _personService.DeletePersonById(id);
            return Ok();
        }
    }
}
