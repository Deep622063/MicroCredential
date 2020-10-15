using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using ProjectOne.Controllers;
using ProjectOne.Models;
using ProjectOne.Repository;
using Xunit;

namespace Test
{
    public class CustomersControllerTest : ControllerBase
    {
        [Fact]
        public void GetMethodWithOutParameter_ShouldReturnListOfCustomers()
        {
            //Arrange
            var mockService = new Mock<ICustomersRepository>();
            mockService.Setup(service => service.GetAll().ToList()).Returns(this.GetAll());
            var controller = new CustomersController(mockService.Object);

            //Act
            var result = controller.Get();

            //Assert
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Customer>>(actionResult.Value);

        }

        [Fact]
        public void GetMethodWithOutParameter_ShouldReturnNotFoundResult()
        {
            // Arrange
            var mockService = new Mock<ICustomersRepository>();
            mockService.Setup(service => service.GetAll().ToList()).Returns((List<Customer>)null);
            var controller = new CustomersController(mockService.Object);

            // Act
            var response = controller.Get() as ObjectResult;

            //Assert
            Assert.NotNull(response);
            Assert.Equal("No Customers found", response.Value);
            Assert.Equal(404, response.StatusCode.Value);
        }

        [Fact]
        public void GetMethodWithIdParameter_ShouldReturnCustomer()
        {
            // Arrange            
            var mockService = new Mock<ICustomersRepository>();
            mockService.Setup(service => service.GetById(It.IsAny<int>())).Returns(this.GetCustomerbyid());
            var controller = new CustomersController(mockService.Object);

            // Act
            var result = controller.Get(1) as OkObjectResult;
            // Assert            
            Assert.NotNull(result);
            var customer = result.Value as Customer;
            Assert.NotNull(customer);
            Assert.Equal("Three", customer.UserName);
        }

        [Fact]
        public void GetMethodWithParameter_ShouldReturnNotFoundResult()
        {
            // Arrange            
            var mockService = new Mock<ICustomersRepository>();
            var controller = new CustomersController(mockService.Object);

            // Act
            var response = controller.Get(1212) as ObjectResult;

            // Assert
            Assert.NotNull(response);
            Assert.Equal("No customer found", response.Value);
            Assert.Equal(404, response.StatusCode.Value);
        }

        [Fact]
        public void PostMethod_ShouldReturnExpectedResult()
        {
            var mockService = new Mock<ICustomersRepository>();
            mockService.Setup(service => service.AddCustomer(It.IsAny<Customer>())).Returns(GetCustomer());
            var controller = new CustomersController(mockService.Object);

            // Act
            var response = controller.Post(GetCustomer()) as ObjectResult;

            // Assert  
            Assert.NotNull(response);
            Assert.Equal("Customer has been added", response.Value);
            Assert.Equal(201, response.StatusCode.Value);
        }

        [Fact]
        public void PutMethod_ShouldReturnExpectedResult()
        {
            var newcustomer = new Customer() { Id = 3, UserName = "changedthree", Name = "Test user3", AccountType = ProjectOne.Enums.AccountType.Individual, Country = ProjectOne.Enums.Country.Bhutan, DateOfBith = new DateTime(), EmailAddress = "1@1.com", Line1 = "AddressLine1", Line2 = "AddressLine2", Line3 = "AddressLine3", Password = "Password", PermanentAccountNumber = "abcdef111", PhoneNumber = "1234567891", State = "state" };
            var mockService = new Mock<ICustomersRepository>();
            mockService.Setup(service => service.UpdateCustomer(It.IsAny<Customer>())).Equals(newcustomer);
            var controller = new CustomersController(mockService.Object);

            // Act
            var result = controller.Put(1, newcustomer) as OkObjectResult;

            // Assert  
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            var customer = result.Value as Customer;
            Assert.NotNull(customer);
            Assert.Equal("Good Name", customer.Name);
        }

        [Fact]
        public void PutMethod_ShouldReturnNotFoundResult()
        {
            // Arrange            
            var mockService = new Mock<ICustomersRepository>();
            mockService.Setup(service => service.UpdateCustomer(It.IsAny<Customer>())).Equals((Customer)null);
            var controller = new CustomersController(mockService.Object);
            var newcustomer = new Customer() { Id = 3, UserName = "changedthree", Name = "Test user3", AccountType = ProjectOne.Enums.AccountType.Individual, Country = ProjectOne.Enums.Country.Bhutan, DateOfBith = new DateTime(), EmailAddress = "1@1.com", Line1 = "AddressLine1", Line2 = "AddressLine2", Line3 = "AddressLine3", Password = "Password", PermanentAccountNumber = "abcdef111", PhoneNumber = "1234567891", State = "state" };

            // Act
            var result = controller.Put(3, newcustomer) as ObjectResult;

            // Assert            
            Assert.NotNull(result);
            Assert.Equal("Customer not found", result.Value);
            Assert.Equal(404, result.StatusCode.Value);
        }

        [Fact]
        public void DeleteMethod_ShouldReturnExpectedResult()
        {
            var mockService = new Mock<ICustomersRepository>();
            mockService.Setup(service => service.DeleteCustomer(It.IsAny<Customer>())).Equals(true);
            var controller = new CustomersController(mockService.Object);

            // Act
            var result = controller.Delete(3) as ObjectResult;

            // Assert  
            var actionResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void DeleteMethod_ShouldReturnNotFoundResult()
        {
            // Arrange            
            var mockService = new Mock<ICustomersRepository>();
            mockService.Setup(service => service.DeleteCustomer(It.IsAny<Customer>())).Equals(false);
            var controller = new CustomersController(mockService.Object);

            // Act
            var result = controller.Delete(10) as ObjectResult;

            // Assert            
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }

        private List<Customer> GetAll()
        {
            var customers = new List<Customer>()
            {
            new Customer() { Id = 1, UserName = "One", Name = "Test user1", AccountType = ProjectOne.Enums.AccountType.Individual, Country = ProjectOne.Enums.Country.Bhutan, DateOfBith = new DateTime(), EmailAddress = "1@1.com", Line1 = "AddressLine1", Line2 = "AddressLine2", Line3 = "AddressLine3", Password = "Password", PermanentAccountNumber = "abcdef111", PhoneNumber = "1234567891", State = "state" },
            new Customer() { Id = 2, UserName = "Two", Name = "Test user2", AccountType = ProjectOne.Enums.AccountType.Individual, Country = ProjectOne.Enums.Country.Bhutan, DateOfBith = new DateTime(), EmailAddress = "1@1.com", Line1 = "AddressLine1", Line2 = "AddressLine2", Line3 = "AddressLine3", Password = "Password", PermanentAccountNumber = "abcdef111", PhoneNumber = "1234567891", State = "state" },
            new Customer() { Id = 3, UserName = "Three", Name = "Test user3", AccountType = ProjectOne.Enums.AccountType.Individual, Country = ProjectOne.Enums.Country.Bhutan, DateOfBith = new DateTime(), EmailAddress = "1@1.com", Line1 = "AddressLine1", Line2 = "AddressLine2", Line3 = "AddressLine3", Password = "Password", PermanentAccountNumber = "abcdef111", PhoneNumber = "1234567891", State = "state" }
            };

            return customers;
        }

        private Customer GetCustomerbyid()
        {
            return new Customer() { Id = 1, UserName = "Three", Name = "Test user3", AccountType = ProjectOne.Enums.AccountType.Individual, Country = ProjectOne.Enums.Country.Bhutan, DateOfBith = new DateTime(), EmailAddress = "1@1.com", Line1 = "AddressLine1", Line2 = "AddressLine2", Line3 = "AddressLine3", Password = "Password", PermanentAccountNumber = "abcdef111", PhoneNumber = "1234567891", State = "state" };

        }

        private Customer GetCustomer()
        {
            return new Customer() { Id = 3, UserName = "Three", Name = "Test user3", AccountType = ProjectOne.Enums.AccountType.Individual, Country = ProjectOne.Enums.Country.Bhutan, DateOfBith = new DateTime(), EmailAddress = "1@1.com", Line1 = "AddressLine1", Line2 = "AddressLine2", Line3 = "AddressLine3", Password = "Password", PermanentAccountNumber = "abcdef111", PhoneNumber = "1234567891", State = "state" };
        }
    }
}
