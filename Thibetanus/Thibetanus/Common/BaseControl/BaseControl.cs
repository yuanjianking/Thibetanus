using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.Common.Helper;
using Thibetanus.DBmanager;

namespace Thibetanus.Common.BaseControl
{
    class BaseControl
    {
        protected readonly DBFactory.DBServerType DBServerType = DBFactory.DBServerType.PostgreSQL;

        public BaseControl()
       {
       }

        public void CopyModel(object target, object source)
        {
            Type type1 = target.GetType();
            Type type2 = source.GetType();
            foreach (var mi in type2.GetProperties())
            {
                var des = type1.GetProperty(mi.Name);
                if (des != null)
                {
                    if(mi.PropertyType.FullName == des.PropertyType.FullName)
                    try
                    {
                        var data = mi.GetValue(source, null);
                        if (data != null)
                        {
                            des.SetValue(target, data);
                        }
                    }
                    catch(Exception e)
                    {
                    }
                }
            }
        }

    }
}
