using ddd.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.integration
{
    public interface IIntegrationService<TAggregate>: IService
        where TAggregate: class, IAggregate
    {
    }
}
