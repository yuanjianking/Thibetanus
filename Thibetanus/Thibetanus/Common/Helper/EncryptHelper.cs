using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.Common.Helper
{
    static class EncryptHelper
    {

        public static String EncryptToSHA1(String content, Encoding encode)
        {
            try
            {
                byte[] bytes_in = encode.GetBytes(content);//将待加密字符串转为byte类型
                byte[] bytes_out = SHA1.Create().ComputeHash(bytes_in);//Hash运算
                String result = BitConverter.ToString(bytes_out);//将运算结果转为string类型
                result = result.Replace("-", "").ToUpper();//替换掉 BitConverter.ToString转换后的"-",并转为大写
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
