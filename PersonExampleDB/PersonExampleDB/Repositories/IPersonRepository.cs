﻿using System;
using System.Collections.Generic;
using System.Text;
using PersonExampleDB.Data;

namespace PersonExampleDB.Repositories
{
    public interface IPersonRepository
    {
        //CRUD
        void Create(Person person);
        List<Person> ReadByCity(string city);
        Person ReadById(long id);
        void Update(long id, Person person);
        void Delete(long id);
    }
}
