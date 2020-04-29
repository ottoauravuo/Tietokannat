using System;
using System.Collections.Generic;
using System.Text;
using PhonePersonDB.Models;

namespace PhonePersonDB.Repositories
{
    public interface IPersonRepository
    {
        //CRUD
        void Create(Person person);
        //List<Person> Read();
        Person ReadById(long id);
        void Update(long id, Person person);
        void Delete(long id);
    }
}
