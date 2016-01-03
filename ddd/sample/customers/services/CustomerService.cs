using ddd.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.customers.services
{
    public class CustomerService: ICustomerService
    {
        readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Customer FindById(Guid id)
        {
            return _customerRepository.Query().Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
