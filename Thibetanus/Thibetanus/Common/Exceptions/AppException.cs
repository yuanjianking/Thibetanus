using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.Common.Exceptions
{
    class AppException : BaseException
    {
        public AppException(string code) : base(code)
        {
            
        }

        public AppException(string code, string msg) : base(code, msg)
        {
        }
    }
}
