using ddd.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.countries
{
    public class Country: IAggregate
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Calculate { get; set; }
    }
}
