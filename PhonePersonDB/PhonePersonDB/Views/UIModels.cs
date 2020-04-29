using System;
using System.Collections.Generic;
using System.Text;
using PhonePersonDB.Models;
using PhonePersonDB.Repositories;

namespace PhonePersonDB.Views
{
    class UIModels
    {
        private readonly PersonRepository _personRepository = new PersonRepository();
        public void Create()
        {
            Person person = new Person();
            person.Name = "Tommi";
            person.Age = 16;
            person.Phone = new List<Phone>
            {
            new Phone{Type = "WORK", Number = "0405111177"},
            new Phone{Type = "HOME", Number = "0511114046"}
            };
            Console.WriteLine("Uusi henkilö luotu tietokantaan.");
            _personRepository.Create(person);
        }

        public void ReadById(long id)
        {
            var person = _personRepository.ReadById(id);

            if (person == null)
            {
                Console.WriteLine($"Asiakasta numerolla {id} ei löydy!");
            }
            else
            {
                Console.WriteLine($"{person.Id}    {person.Name}    {person.Age}v.\nNumero:");
                foreach (var p in person.Phone)
                {
                    Console.WriteLine($"\t{p.Type}\t{p.Number}");
                }
            }
        }

        public void Update()
        {
            Person updatePerson = _personRepository.ReadById(3);
            updatePerson.Name = "Jaska";
            updatePerson.Age = 22;
            //updatePerson.Phone = 04400440;
            _personRepository.Update(3, updatePerson);
        }

        public void Delete(long id)
        {
            ReadById(id);
            _personRepository.Delete(id);
            ReadById(id);
        }
    }
}
