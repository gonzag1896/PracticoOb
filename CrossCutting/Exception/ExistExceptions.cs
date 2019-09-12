using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Exception
{
    public class ExistExceptions: SystemException
    {
        public ExistExceptions()
            : base("No existe el empleado")
        {

        }
    }
}
