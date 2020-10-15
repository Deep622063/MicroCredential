using Microsoft.EntityFrameworkCore;
using ProjectOne.Data;
using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOne.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private CustomersDbContext customersDbContext;

        public CustomersRepository(CustomersDbContext _customersDbContext)
        {
            customersDbContext = _customersDbContext;
        }

        public DbSet<Customer> GetAll()
        {
            return customersDbContext.Customers;
        }

        public Customer GetById(int id)
        {
            return customersDbContext.Customers.SingleOrDefault(customer => customer.Id == id);
        }

        public Customer GetByName(string name)
        {
            return customersDbContext.Customers.SingleOrDefault(customer => customer.Name.ToLower().StartsWith(name.ToLower()));
        }

        public void UpdateCustomer(Customer customer)
        {
            customersDbContext.Customers.Update(customer);
            customersDbContext.SaveChanges();
        }

        public void AddCustomer(Customer customer)
        {
            customersDbContext.Customers.Add(customer);
            customersDbContext.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            customersDbContext.Customers.Remove(customer);
            customersDbContext.SaveChanges();
        }
    }
}
