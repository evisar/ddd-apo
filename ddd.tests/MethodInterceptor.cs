using Castle.DynamicProxy;
using ddd.infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.tests
{
    public class MethodInterceptor<T>: IInterceptor
        where T: IInfrastructure
    {
        readonly T _service;
        readonly Action<T, IInvocation> _handle;
        public MethodInterceptor(T service, Action<T, IInvocation> handle)
        {
            _service = service;
            _handle = handle;
        }
        public void Intercept(IInvocation invocation)
        {
            _handle(_service, invocation);
            invocation.Proceed();
        }
    }
}
