using Microsoft.EntityFrameworkCore;
using ProjectOne.Data;
using ProjectOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    public class DatabaseFixture : IDisposable
    {
        public CustomersDbContext dbContext;

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<CustomersDbContext>().UseInMemoryDatabase(databaseName: "CustomersDB")
        .Options;
            dbContext = new CustomersDbContext(options);

            dbContext.Customers.Add(new Customer() { Id = 1, UserName = "One", Name = "Test user1", AccountType = ProjectOne.Enums.AccountType.Individual, Country = ProjectOne.Enums.Country.Bhutan, DateOfBith = new DateTime(), EmailAddress = "1@1.com", Line1 = "AddressLine1", Line2 = "AddressLine2", Line3 = "AddressLine3", Password = "Password", PermanentAccountNumber = "abcdef111", PhoneNumber = "1234567891", State = "state" });
            dbContext.Customers.Add(new Customer() { Id = 2, UserName = "Two", Name = "Test user2", AccountType = ProjectOne.Enums.AccountType.Individual, Country = ProjectOne.Enums.Country.Bhutan, DateOfBith = new DateTime(), EmailAddress = "1@1.com", Line1 = "AddressLine1", Line2 = "AddressLine2", Line3 = "AddressLine3", Password = "Password", PermanentAccountNumber = "abcdef111", PhoneNumber = "1234567891", State = "state" });
            dbContext.Customers.Add(new Customer() { Id = 3, UserName = "Three", Name = "Test user3", AccountType = ProjectOne.Enums.AccountType.Individual, Country = ProjectOne.Enums.Country.Bhutan, DateOfBith = new DateTime(), EmailAddress = "1@1.com", Line1 = "AddressLine1", Line2 = "AddressLine2", Line3 = "AddressLine3", Password = "Password", PermanentAccountNumber = "abcdef111", PhoneNumber = "1234567891", State = "state" });
            dbContext.SaveChanges();
        }

        public void Dispose()
        {

        }
    }
}
