using ddd.sample;
using ddd.sample.sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.services
{
    public interface ITaxService
    {
        void Calculate(Sale sale, bool inprice);
    }
}
