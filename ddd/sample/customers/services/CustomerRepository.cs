using ddd.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.customers.services
{
    public class CustomerRepository: ICustomerRepository
    {
        static List<Customer> _customers = new List<Customer>();
        public void Save(Customer entity)
        {
            _customers.Add(entity);
        }

        public void Delete(Customer entity)
        {
            _customers.Remove(entity);
        }

        public IQueryable<Customer> Query()
        {
            return _customers.AsQueryable();
        }
    }
}
