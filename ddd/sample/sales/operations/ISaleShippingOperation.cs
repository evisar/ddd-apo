using ddd.common;
using System;
namespace ddd.sample.sales.operations
{
    public interface ISaleShippingOperation: IOperation<Sale>
    {
        decimal CalculateShipping();
    }
}
