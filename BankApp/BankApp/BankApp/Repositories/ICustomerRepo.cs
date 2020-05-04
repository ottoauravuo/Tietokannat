using System;
using System.Collections.Generic;
using System.Text;
using BankApp.Models;

namespace BankApp.Repositories
{
    public interface ICustomerRepo
    {
        //CRUD
        Customer Create(Customer customer);
        Customer ReadById(long id);
        List<Customer> ReadAllCustomers();
        void Update(long id, Customer customer);
        void Delete(long id);
    }
}