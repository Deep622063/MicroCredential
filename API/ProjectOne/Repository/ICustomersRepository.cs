using Microsoft.EntityFrameworkCore;
using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Repository
{
    public interface ICustomersRepository
    {
        DbSet<Customer> GetAll();

        Customer GetById(int id);

        Customer GetByName(string name);

        void UpdateCustomer(Customer customer);

        void AddCustomer(Customer customer);

        void DeleteCustomer(Customer customer);
    }
}
