using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;
using BankApp.Repositories;

namespace BankApp.Views
{
    class UiModels
    {
        private readonly BankRepo _bankRepo = new BankRepo();
        private readonly CustomerRepo _customerRepo = new CustomerRepo();
        private readonly AccountRepo _accountRepo = new AccountRepo();
        private readonly TransactionRepo _transactionRepo = new TransactionRepo();

        public void CreateBank()
        {
            Bank bank = new Bank();
            bank.Name = "Uusi pankki X";
            bank.Bic = "1235555555";
            Console.WriteLine("Uusi pankki luotu");
            _bankRepo.Create(bank);
        }

        public void CreateCustomerAccount()
        {
            Customer customer = new Customer();

            customer.BankId = 7;
            customer.Firstname = "Pertti";
            customer.Lastname = "Puunanen";
            customer.Account = new List<Account>
            {
                new Account
                {
                    Balance = 10,
                    Name = "Pertin Tili",
                    Iban = "88449922",
                    BankId = 7
                }
            };
            _customerRepo.Create(customer);
        }

        internal void ReadCustomerByBankId(long bankId)
        {
            var customers = _customerRepo.ReadAllCustomers();
            if (customers == null)
            {
                Console.WriteLine($"Pankkia ID:llä {bankId} ei löydy");
            }
            else
            {
                Console.WriteLine("Pankin asiakkaat:");
                foreach (var c in customers)
                {
                    if (c.BankId == bankId)
                    {
                        Console.WriteLine($"Asiakas nr. {c.Id}    {c.Firstname} {c.Lastname}");
                    }
                }
            }
        }

        internal void ReadAccountsByBankId(long bankId)
        {
            var accounts = _accountRepo.ReadAllAccounts();
            Console.WriteLine("Pankin tilit:");
            foreach (var a in accounts)
            {
                if (accounts == null)
                {
                    Console.WriteLine("Ei ole tilejä");
                }
                else if (a.BankId == bankId)
                {
                    Console.WriteLine($"Tili: {a.Name}\nBalance: {a.Balance}");
                }
            }
        }

        internal void ReadTransactionById(long id)
        {
            var transactions = _transactionRepo.ReadTransactions();

            foreach (var t in transactions)
            {
                if (transactions == null)
                {
                    Console.WriteLine("ei löydy");
                }
                else
                {
                    Console.WriteLine($"Määrä: {t.Amount}\nAika: {t.TimeStamp}");
                }
            }
        }

        public void DeleteBank(long id)
        {
            ReadBankById(id);
            _bankRepo.Delete(id);
            ReadBankById(id);
        }

        public void ReadBankById(long id)
        {
            var bank = _bankRepo.ReadById(id);
            if (bank == null)
            {
                Console.WriteLine($"Pankki numerolla {id} ei löydy");
            }
            else
            {
                Console.WriteLine($"{bank.Id}   {bank.Name}");
            }
        }

        public void UpdateBank()
        {
            Bank updateBank = _bankRepo.ReadById(9);
            updateBank.Name = "Päivitetty pankki";
            updateBank.Bic = "OPAIJF";
            _bankRepo.Update(9, updateBank);
        }

        public void UpdateCustomer()
        {
            Customer updateCustomer = _customerRepo.ReadById(25);
            updateCustomer.Firstname = "Testi";
            updateCustomer.Lastname = "Homma";
            updateCustomer.BankId = 7;

            _customerRepo.Update(25, updateCustomer);
        }

        public void DeleteCustomer(long id)
        {
            ReadCustomerById(id);
            _customerRepo.Delete(id);
            ReadCustomerById(id);
        }

        public void ReadCustomerById(long id)
        {
            var customer = _customerRepo.ReadById(id);
            if (customer == null)
            {
                Console.WriteLine($"Henkilöä ID:llä {id} ei löydy");
            }
            else
            {
                Console.WriteLine($"Henkilö poistettu tietokannasta ---- {customer.Id}    {customer.Firstname} {customer.Lastname}");
            }
        }

        public void ReadCustomerInfo(long customerId)
        {
            var customer = _customerRepo.ReadById(customerId);
            if (customer == null)
            {
                Console.WriteLine($"Asiakasta kyseisellä ID:llä ei löydy");
            }
            else
            {
                Console.WriteLine($"{customer.Firstname} {customer.Lastname}");
                foreach (var c in customer.Account)
                {
                    Console.WriteLine($"Tili: {c.Name}\tBalance: {c.Balance}");
                }
            }
        }

        public void AddTransaction()
        {
            Transaction transaction = new Transaction();
            transaction.Iban = "FI112233445566778899";
            transaction.Amount = 99999;
            transaction.TimeStamp = DateTime.Now;
            _accountRepo.CreateTransaction(transaction);
            Console.WriteLine("Paina ENTER jatkaaksesi");
        }
    }
}
