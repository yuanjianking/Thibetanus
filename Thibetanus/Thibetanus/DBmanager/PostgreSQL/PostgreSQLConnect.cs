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
        public List<TSource> FindAll<TSource>() where TSource : class
        {
            using (var context = new PostgreSQLContext())
            {
               // PostgreSQLContxtSeeder.Seed(context);
                //var users = context.Users.Include(u => u.Orders).ToList();
                //users.ForEach(u =>
                //{
                //    System.Console.WriteLine(u);
                //});
                return context.Set<TSource>().ToList();
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
            using (PostgreSQLContext context = new PostgreSQLContext())
            {
                TSource v = context.Set<TSource>().Find(ids);
                if (v == null)
                {
                    return;
                }
                context.Set<TSource>().Remove(v);
                context.SaveChanges();
            }
        }

        public void Modify<TSource>(TSource model) where TSource : class
        {
            using (PostgreSQLContext context = new PostgreSQLContext())
            {
                if (context.Entry<TSource>(model).State == EntityState.Detached)
                {
                    context.Set<TSource>().Attach(model);
                    context.Entry<TSource>(model).State = EntityState.Modified;
                }
                context.SaveChanges();
            }
        }

        public void Add<TSource>(TSource model) where TSource : class
        {
            using (PostgreSQLContext context = new PostgreSQLContext())
            {
                context.Set<TSource>().Add(model);
                context.SaveChanges();
            }
        }
     
    }
}
