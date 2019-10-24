using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace Thibetanus.Common.Exceptions
{
    class BaseException:Exception
    {
        protected string ErrorCode = null;
        protected string ErrorMessage = null;

        public BaseException(string code)
        {
            ErrorCode = code;
            ResourceLoader resourceLoader = ResourceLoader.GetForCurrentView("ExceptionResources");
            ErrorMessage = resourceLoader.GetString(code);
        }

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
