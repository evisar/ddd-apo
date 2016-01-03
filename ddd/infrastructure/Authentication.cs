using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ddd.infrastructure
{
    public class Authentication: IAuthentication
    {
        public bool Authenticate(IPrincipal user, object sender, string method, params object[] arguments)
        {
            return false;
        }
    }
}
