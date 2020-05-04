using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankApp.Data;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class AccountRepo : IAccountRepo
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();
        public void Create(Account account)
        {
            _bankdbContext.Account.Add(account);
            _bankdbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        internal object ReadById(long id)
        {
            var account = _bankdbContext.Account
                .Include(a => a.BankId)
                .Where(a => a.BankId == id)
                .FirstOrDefault();
            return account;
        }

        internal object ReadAccountById(long id)
        {
            var account = _bankdbContext.Account
                .Include(a => a.CustomerId)
                .Where(a => a.CustomerId == id)
                .FirstOrDefault();
            return account;
        }

        public Account ReadAccountsByBankId(long id)
        {
            var account = _bankdbContext.Account
                .Include(a => a.BankId)
                .Where(a => a.BankId == id)
                .FirstOrDefault();
            return account;
        }

        public List<Account> ReadAllAccounts()
        {
            var accounts = _bankdbContext.Account
                .ToList();
            return accounts;
        }

        public void CreateTransaction(Transaction transaction)
        {
            _bankdbContext.Transaction.Add(transaction);
            var account = ReadAccountByIban(transaction.Iban);
            account.Balance += transaction.Amount;
            _bankdbContext.Account.Update(account);
            _bankdbContext.SaveChanges();
        }

        private object ReadAccountById(string iban)
        {
            throw new NotImplementedException();
        }

        public Account ReadAccountByIban(string iban)
        {
            var account = _bankdbContext.Account
                .FirstOrDefault(a => a.Iban == iban);
            return account;
        }

        public void Update(long id, Account account)
        {
            throw new NotImplementedException();
        }

        Account IAccountRepo.ReadById(long id)
        {
            throw new NotImplementedException();
        }

        internal object ReadAccountsByBankId()
        {
            throw new NotImplementedException();
        }


    }
}
