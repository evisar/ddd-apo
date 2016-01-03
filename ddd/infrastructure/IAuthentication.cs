using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ddd.infrastructure
{
    public interface IAuthentication:IInfrastructure
    {
        bool Authenticate(IPrincipal user, object sender, string method, params object[] arguments);
    }
}
