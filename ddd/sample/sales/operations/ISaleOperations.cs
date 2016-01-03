using ddd.common;
using System;
namespace ddd.sample.sales.operations
{
    public interface ISaleOperations: IOperation<Sale>
    {
        bool Calculate();
    }
}
