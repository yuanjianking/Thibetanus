using Microsoft.EntityFrameworkCore;
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

        public void StartConnect()
        {
            if(context == null)
                context = new PostgreSQLContext();
        }

        public void CloseConnect()
        {
            context.Dispose();
            context = null;
        }

        public void SaveChange()
        {
            if (context != null)
                context.SaveChanges();
        }

        public  List<TSource> FindAll<TSource, Tkey>(Func<TSource, Tkey> orderby) where TSource : class
        {
            using (var context = new PostgreSQLContext())
            {
                PostgreSQLContxtSeeder.Seed(context);
                var users = context.Users.Include(u => u.Orders).ToList();
                users.ForEach(u =>
                {
                    Console.WriteLine(u);
                });
                return context.Set<TSource>().AsNoTracking().OrderBy(orderby).ToList();
            }
        }
        
        public IEnumerable<TSource> GetLstInfo<TSource>(Expression<Func<TSource, bool>> express) where TSource : class
        {
            using (PostgreSQLContext context = new PostgreSQLContext())
            {
                return context.Set<TSource>().Where(express).ToList();
            }
        }

        public TSource GetModel<TSource>(params string[] id) where TSource : class
        {
            using (PostgreSQLContext context = new PostgreSQLContext())
            {
                return context.Set<TSource>().Find(id);
            }
        }

        public void Delete<TSource>(params string[] ids) where TSource : class
        {
         //   using (PostgreSQLContext context = new PostgreSQLContext())
       //     {
                TSource v = context.Set<TSource>().Find(ids);
                if (v == null)
                {
                    return;
                }
                context.Set<TSource>().Remove(v);
        //        context.SaveChanges();
       //     }
        }

        public void Modify<TSource>(TSource model) where TSource : class
        {
            //using (PostgreSQLContext context = new PostgreSQLContext())
            {
                if (context.Entry(model).State == EntityState.Detached)
                {
                    context.Set<TSource>().Attach(model);
                    context.Entry(model).State = EntityState.Modified;
                }
            }
        }

        public void Modify<TSource>(List<TSource> models) where TSource : class
        {
            //using (PostgreSQLContext context = new PostgreSQLContext())
            {
                foreach(TSource model in models)
                { 
                    if (context.Entry(model).State == EntityState.Detached)
                    {
                        context.Set<TSource>().Attach(model);
                        context.Entry(model).State = EntityState.Modified;
                    }
                }
            }
        }


        public void Add<TSource>(TSource model) where TSource : class
        {
           // using (PostgreSQLContext context = new PostgreSQLContext())
            {
                context.Set<TSource>().Add(model);
            }
        }

        public void Add<TSource>(List<TSource> models) where TSource : class
        {
            //using (PostgreSQLContext context = new PostgreSQLContext())
            {
                foreach (TSource model in models)
                    context.Set<TSource>().Add(model);
            }
        }

    }
}
