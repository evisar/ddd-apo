using ddd.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.sample.sales
{
    public class Sale: IAggregate
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }

        public bool Calculated { get; set; }
        public IEnumerable<SaleItem> Items { get; private set; }

        public Sale()
        {
            this.Id = Guid.NewGuid();
        }

        public Tuple<decimal, int> Weight { get; set; }

        public Tuple<decimal, decimal, decimal, int> Size { get; set; }
    }
}
