using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Thibetanus.DBmanager
{
    interface DBConnect : IDisposable
    {
        DBConnect StartConnect();
        void CloseConnect();
        int SaveChange();
        void Commite();
        void Rollback();
        DBConnect BeginTransaction();
        void EndTransaction();
        List<TSource> FindAll<TSource,Tkey>(Func<TSource, Tkey> orderby) where TSource : class;
        int Add<TSource>(TSource model) where TSource : class;
        int Modify<TSource>(TSource model) where TSource : class;
        int Delete<TSource>(IEnumerable<TSource> data) where TSource : class;
    }
}
