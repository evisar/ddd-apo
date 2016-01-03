using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ddd.infrastructure
{
    public class Logger: ILogger
    {
        public void Log(object sender, string method, params object[] arguments)
        {
            
        }
    }
}
