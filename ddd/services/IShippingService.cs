using ddd.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.services
{
    public interface IShippingService: IService
    {
        decimal CalculateShipping(Tuple<decimal, int> weight, Tuple<decimal, decimal, decimal, int> size);
    }
}
