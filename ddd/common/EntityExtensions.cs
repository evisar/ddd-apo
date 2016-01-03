using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace injection.common
{
    public static class EntityExtensions
    {
        public static IEnumerable<IOperation<TEntity>> GetOperations<TEntity>(this TEntity entity, IKernel kernel)
            where TEntity : class, IEntity
        {
            var types =
                from type in AppDomain.CurrentDomain.GetAssemblies().SelectMany(asm => asm.GetTypes())
                where typeof(IOperation<TEntity>).IsAssignableFrom(type)
                select type;

            foreach (var type in types)
            {
                yield return kernel.Get(type, new ConstructorArgument("entity", entity)) as IOperation<TEntity>;
            }


        }
    }
}
