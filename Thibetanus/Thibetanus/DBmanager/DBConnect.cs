using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBmanager
{
    interface DBConnect
    {
        void StartConnect();
        void CloseConnect();
        void SaveChange();
        
        List<TSource> FindAll<TSource,Tkey>(Func<TSource, Tkey> orderby) where TSource : class;
        void Add<TSource>(TSource model) where TSource : class;
        void Modify<TSource>(TSource model) where TSource : class;       
        void Delete<TSource>(params string[] ids) where TSource : class;
    }
}
