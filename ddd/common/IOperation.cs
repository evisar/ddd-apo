using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.common
{
    public interface IOperation<TEntity>: IDisposable
        where TEntity: class, IEntity
    {
        TEntity Entity { get; }
    }
}
