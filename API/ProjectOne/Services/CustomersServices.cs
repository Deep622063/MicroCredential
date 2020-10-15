using Models.Model;
using Repository.Repository;
using System.Collections.Generic;
using System.Linq;

namespace ProjectOne.Services
{
    public class CustomersServices : ICustomersServices
    {
        private IDataRepository<Customer> _customersRepository;

        public CustomersServices(IDataRepository<Customer> customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public List<Customer> GetAll()
        {
            return _customersRepository.GetAll();
        }

        public Customer GetById(int id)
        {
            return _customersRepository.GetById(id);
        }

        public Customer GetByName(string name)
        {
            return _customersRepository.GetByName(name);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            _customersRepository.Update(customer);

            return customer;
        }

        public Customer AddCustomer(Customer customer)
        {
            _customersRepository.Add(customer);

            return customer;
        }

        public bool DeleteCustomer(int id)
        {
            var customer = this.GetAll().SingleOrDefault(x => x.Id == id);

            return _customersRepository.Delete(customer) == customer;
        }
    }
}
