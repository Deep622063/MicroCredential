using Models.Model;
using System.Collections.Generic;

namespace ProjectOne.Services
{
    public interface ICustomersServices
    {
        List<Customer> GetAll();

        Customer GetById(int id);

        Customer GetByName(string name);

        Customer UpdateCustomer(Customer customer);

        Customer AddCustomer(Customer customer);

        bool DeleteCustomer(int id);
    }
}
