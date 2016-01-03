using ddd.integration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.customers.services
{
    public interface ICustomerService: IIntegrationService<Customer>
    {
        Customer FindById(Guid id);
    }
}
