using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.Common.Exceptions
{
    class SystemException : BaseException
    {
        public SystemException(string code) : base(code)
        {
        }

        public SystemException(string code, string msg) : base(code, msg)
        {
        }
    }
}
