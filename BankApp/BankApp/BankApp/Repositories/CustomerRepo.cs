using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BankApp.Data;
using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Repositories
{
    class CustomerRepo : ICustomerRepo
    {
        private readonly BankdbContext _bankdbContext = new BankdbContext();
        public Customer Create(Customer customer)
        {
            _bankdbContext.Customer.Add(customer);
            _bankdbContext.SaveChanges();
            return customer;
        }

        public void Delete(long id)
        {
            var deletedCustomer = ReadById(id);
            if (deletedCustomer != null)
            {
                _bankdbContext.Customer.Remove(deletedCustomer);
                _bankdbContext.SaveChanges();
            }
        }

        public List<Customer> ReadAllCustomers()
        {
            var customers = _bankdbContext.Customer
                .ToList();
            return customers;
        }

        public Customer ReadById(long customerId)
        {
            var customer = _bankdbContext.Customer
                .Where(c => c.Id == customerId)
                .FirstOrDefault();
            return customer;
        }

        public void Update(long id, Customer customer)
        {
            var customerIsReal = ReadById(id);
            if (customerIsReal != null)
            {
                _bankdbContext.Update(customer);
                _bankdbContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu");
            }
            else
            {
                Console.WriteLine($"Päivitys epäonnistui - Henkilöä ei ole olemassa");
            }
        }

        public Customer ReadByCustomerId(long id)
        {
            var customer = _bankdbContext.Customer
                .Include(c => c.Account)
                .Where(c => c.Id == id)
                .FirstOrDefault();
            return customer;
        }
    }
}