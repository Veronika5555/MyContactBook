using MyContactBook.Models;
using System.Collections.Generic;

namespace MyContactBook.Database.Repository
{
    public interface IRepository
    {
        public void AddPerson(Person person);
        public Person GetPerson(int id);
        public List<Person> GetAllPeople();
        public void RemovePerson(int id);
        public void UpdatePerson(Person person);
        public void Save();
    }
}
