using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankApp.Data;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class BankRepo : IBankRepo
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();
        public void Create(Bank bank)
        {
            _bankdbContext.Bank.Add(bank);
            _bankdbContext.SaveChanges();
        }

        public void Delete(long id)
        {
            var deletedBank = ReadById(id);
            if (deletedBank != null)
            {
                _bankdbContext.Bank.Remove(deletedBank);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Haluttu pankki poistettu");
            }
            else
            {
                Console.WriteLine("Poistaminen epäonnistui - ID tuntematon");
            }
        }

        public Bank ReadById(long id)
        {
            var bank = _bankdbContext.Bank
                .Where(b => b.Id == id)
                .FirstOrDefault();
            return bank;
        }

        public void Update(long id, Bank bank)
        {
            var isBankReal = ReadById(id);
            if (isBankReal != null)
            {
                _bankdbContext.Update(bank);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti");
            }
            else
            {
                Console.WriteLine($"Päivitys epäonnistui - Pankkia ei ole olemassa");
            }
        }
    }
}