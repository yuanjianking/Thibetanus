using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.Common.Helper
{
    class ModelHelper
    {
        public static void CopyModel(object target, object source)
        {
            Type type1 = target.GetType();
            Type type2 = source.GetType();
            foreach (var mi in type2.GetProperties())
            {
                var des = type1.GetProperty(mi.Name);
                if (des != null)
                {
                    if (mi.PropertyType.FullName == des.PropertyType.FullName)
                        try
                        {
                            var data = mi.GetValue(source, null);
                            if (data != null)
                            {
                                if (des.PropertyType == typeof(int) || des.PropertyType == typeof(string))
                                {
                                    des.SetValue(target, data);
                                }
                                else if (des.GetType().GetInterface("IEnumerable") != null)
                                {

                                }
                                else
                                {
                                  
                                }                                
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                }
            }
        }
    }
}
