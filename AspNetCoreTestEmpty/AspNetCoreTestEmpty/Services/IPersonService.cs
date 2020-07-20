using AspNetCoreTestEmpty.Models;
using System.Collections.Generic;

namespace AspNetCoreTestEmpty.Services
{
    public interface IPersonService
    {
        List<Person> GetPeople();
        Person AddPerson(Person person);
        Person UpdatePerson(Person person);
        void DeletePersonById(string id);
    }
}
