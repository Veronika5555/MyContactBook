using MyContactBook.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyContactBook.Database.Repository
{
    public class Repository : IRepository
    {
        private AppDbContext _ctx;

        public Repository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddPerson(Person person)
        {
            _ctx.Contacts.Add(person);
        }

        public Person GetPerson(int id)
        {
            return _ctx.Contacts.FirstOrDefault(p => p.Id == id);
        }

        public List<Person> GetAllPeople()
        {
            return _ctx.Contacts.ToList();
        }

        public void RemovePerson(int id)
        {
            _ctx.Remove(GetPerson(id));
        }

        public void UpdatePerson(Person person)
        {
            _ctx.Update(person);
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}