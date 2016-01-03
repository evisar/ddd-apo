using Ninject;
using Ninject.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.extensions
{
    public static class KernelExtension
    {
        public static TService Get<TService, T>(this IKernel kernel, T item)
        {
            var name = (from c in typeof(TService).GetConstructors()
                       from p in c.GetParameters()
                       where p.ParameterType == typeof(T)
                       select p.Name).FirstOrDefault();

            return kernel.Get<TService>(
                new ConstructorArgument(name, item));
        }
    }
}
