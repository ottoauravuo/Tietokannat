using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface IBankRepo
    {
        //CRUD
        void Create(Bank bank);
        Bank ReadById(long id);
        void Update(long id, Bank bank);
        void Delete(long id);

    }
}