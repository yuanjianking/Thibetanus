using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.Common.Exceptions
{
    class BaseException:Exception
    {
        protected string ErrorCode = null;
        protected string ErrorMessage = null;


        public BaseException(string code,string msg)
        {
            ErrorCode = code;
            ErrorMessage = msg;
        }

        override
        public string ToString()
        {
            return string.Format("Code:{0},Message{1}", ErrorCode, ErrorMessage);
        }
    }
}
