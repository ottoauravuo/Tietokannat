using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface ITransactionRepo
    {
        //CRUD
        void Create(Transaction transaction);
        List<Transaction> ReadTransactions();
        Transaction ReadById(long id);
        void Update(long id, Transaction transaction);
        void Delete(long id);
    }
}