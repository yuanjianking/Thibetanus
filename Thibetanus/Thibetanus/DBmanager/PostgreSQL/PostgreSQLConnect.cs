using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.DBModels.MongDB;

namespace Thibetanus.DBmanager.PostgreSQL
{
    class PostgreSQLConnect : DBConnect
    {
        private PostgreSQLContext context = null;
        private IDbContextTransaction transaction = null;

        public DBConnect StartConnect()
        {
            if (context == null)
                context = new PostgreSQLContext();
            return this;
        }

        public void CloseConnect()
        {
            if(context != null)
            { 
                context.Dispose();
                context = null;
            }
        }

        public int SaveChange()
        {
            if (context != null)
                return context.SaveChanges();
            return 0;
        }

        public void Commite()
        {
            if (transaction != null)
                transaction.Commit();
        }

        public void Rollback()
        {
            if (transaction != null)
                transaction.Rollback();
        }

        public DBConnect BeginTransaction()
        {
            if (context != null)
                transaction = context.Database.BeginTransaction();
            else
            {
                StartConnect();
                transaction = context.Database.BeginTransaction();
            }
            return this;
        }

        public void EndTransaction()
        {
            if (transaction != null)
            { 
                transaction.Dispose();
                transaction = null;
                CloseConnect();
            }
        }

        public void Dispose()
        {
            EndTransaction();
            CloseConnect();
        }


        public List<TSource> FindAll<TSource, Tkey>(Func<TSource, Tkey> orderby) where TSource : class
        {
            //PostgreSQLContxtSeeder.Seed(context);
           // var users = context.Users.Include(u => u.Orders).ToList();
            //users.ForEach(u =>
            //{
            //    Console.WriteLine(u);
            //});
            return context.Set<TSource>().AsNoTracking().OrderBy(orderby).ToList();
        }

        //public List<TSource> FindAll<TSource, Tkey>(Func<TSource, Tkey> orderby) where TSource : class
        //{
        //    //var users = context.Users.Include(u => u.Orders).ToList();
        //    //users.ForEach(u =>
        //    //{
        //    //    Console.WriteLine(u);
        //    //});
        //    return context.Set<TSource>().AsNoTracking().OrderBy(orderby).ToList();
        //}

        public IQueryable<TSource> GetWhere<TSource>(Expression<Func<TSource, bool>> express) where TSource : class
        {
            return context.Set<TSource>().Where(express);
        }

        public TSource GetModel<TSource>(params string[] id) where TSource : class
        {
            return context.Set<TSource>().Find(id);
        }

        public int Modify<TSource>(TSource model) where TSource : class
        {
            if (context.Entry(model).State == EntityState.Detached)
            {
                context.Set<TSource>().Attach(model);
                context.Entry(model).State = EntityState.Modified;
            }
            return context.SaveChanges();
        }

        public int Add<TSource>(TSource model) where TSource : class
        {
            context.Set<TSource>().Add(model);
            return context.SaveChanges();
        }

        public int Delete<TSource>(IEnumerable<TSource> data) where TSource : class
        {        
            if (data != null)
            {
                context.Set<TSource>().RemoveRange(data);
            }
            return context.SaveChanges();
        }
    }
}
