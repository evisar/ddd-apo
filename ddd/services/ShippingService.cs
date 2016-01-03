using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.services
{
    public class ShippingService: IShippingService
    {
        public decimal CalculateShipping(Tuple<decimal, int> weight, Tuple<decimal, decimal, decimal, int> size)
        {
            return 0.1m;
        }
    }
}
