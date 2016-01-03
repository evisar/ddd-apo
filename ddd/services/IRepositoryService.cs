using ddd.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.services
{
    public interface IRepositoryService<T>
        where T: class, IAggregate
    {
        void Save(T entity);
        void Delete(T entity);
        IQueryable<T> Query();
    }
}
