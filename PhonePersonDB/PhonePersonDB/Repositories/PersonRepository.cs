using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PhonePersonDB.Models;

namespace PhonePersonDB.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PhonepersondbContext _phonepersondbContext = new PhonepersondbContext();

        public void Create(Person person)
        {
            _phonepersondbContext.Person.Add(person);
            _phonepersondbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            //DELETE * FROM PERSON WHERE ID={id}
            var deletedPerson = ReadById(id);
            if (deletedPerson != null)
            {
                _phonepersondbContext.Person.Remove(deletedPerson);
                _phonepersondbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut - ID tuntematon");
            }
        }

        internal object ReadById()
        {
            throw new NotImplementedException();
        }

        internal object Person(long id)
        {
            throw new NotImplementedException();
        }

        public Person ReadById(long id)
        {
            var person = _phonepersondbContext.Person
                .Include(p => p.Phone)
                .Where(p => p.Id == id)
                .FirstOrDefault();
            return person;
        }

        public List<Person> Read()
        {
            var persons = _phonepersondbContext.Person
                .Include(p=>p.Phone)
                .ToList();
            return persons;
        }

        public Person GetPhone(int id)
        {
            var persons = _phonepersondbContext.Person.Include(p => p.Phone).Single(p => p.Id == id);
            return persons;
        }

        public void Update(long id, Person person)
        {
            var isPersonAlive = ReadById(id);
            if (isPersonAlive != null)
            {
                _phonepersondbContext.Update(person);
                _phonepersondbContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui - henkilöä ei ole olemassa");
            }
        }
    }
}
