using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PersonExampleDB.Data;

namespace PersonExampleDB.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersontestdbContext _persontestdbContext = new PersontestdbContext();

        public void Create(Person person)
        {
            string sql = $"INSERT INTO PERSON (FirstName, LastName, City, ShoeSize)" +
                $" VALUES ({person.FirstName}, {person.LastName}, {person.City}, {person.ShoeSize})";

            _persontestdbContext.Add(person);
            _persontestdbContext.SaveChanges();

        }

        public List<Person> ReadByCity(string city)
        {
            var persons = _persontestdbContext.Person.
                FromSqlRaw($"SELECT * FROM PERSON WHERE CITY = {city}").
                ToList();
            return persons;
        }

        public Person ReadById(long id)
        {
            var person = _persontestdbContext
                .Person
                .Include(p => p.Phone)
                .FirstOrDefault(p => p.Id == id);
            return person;
        }

        public void Update(long id, Person person)
        {
            var isPersonAlive = ReadById(id);
            if(isPersonAlive != null)
            {
                _persontestdbContext.Update(person);
                _persontestdbContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti");
            }
            else
            {
                Console.WriteLine("Tietojen tallennus epäonnistui - henkilöä ei ole olemassa");
            }
        }

        public void Delete(long id)
        {
            var deletedPerson = ReadById(id);
            if (deletedPerson != null)
            {
                _persontestdbContext.Person.Remove(deletedPerson);
                _persontestdbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti");
            }
            else
            {
                Console.WriteLine("Tiedon poisto EI onnistunut - ID tuntematon");
            }
        }
    }
}
