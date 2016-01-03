using ddd.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.customers
{
    public class Customer: IAggregate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CountryId { get; set; } 
    }
}
