using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface IAccountRepo
    {
        //CRUD
        void Create(Account account);
        Account ReadById(long id);
        List<Account> ReadAllAccounts();
        void Update(long id, Account account);
        void Delete(long id);
    }
}