using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Thibetanus.DBModels.MongDB;

namespace Thibetanus.DBmanager.MongDB
{
    class MongDBConnect: DBConnect
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        private static readonly string Conn = "mongodb://127.0.0.1:27017";
        /// <summary>
        /// 指定的数据库
        /// </summary>
        private static readonly string DBName = "Thibetanus";

        private IMongoDatabase GetDataBase()
        {
            MongoClient client = new MongoClient(Conn);
            IMongoDatabase database = client.GetDatabase(DBName);
            return database;
        }

        public List<TSource> FindAll<TSource, Tkey>(Func<TSource, Tkey> orderby) where TSource : class
        {
            String tableName = typeof(TSource).Name;
            var collection = GetDataBase().GetCollection<TSource>(tableName);
            var filterBuilder = Builders<TSource>.Filter;
            var filter = filterBuilder.Empty;
            return collection.Find(filter).ToList().OrderBy(orderby).ToList();
        }

        public DBConnect StartConnect()
        {
            throw new NotImplementedException();
        }

        public void CloseConnect()
        {
            throw new NotImplementedException();
        }

        public int SaveChange()
        {
            throw new NotImplementedException();
        }

        public void Commite()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public DBConnect BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void EndTransaction()
        {
            throw new NotImplementedException();
        }

        public int Add<TSource>(TSource model) where TSource : class
        {
            throw new NotImplementedException();
        }

        public int Modify<TSource>(TSource model) where TSource : class
        {
            throw new NotImplementedException();
        }

        public int Delete<TSource>(IEnumerable<TSource> data) where TSource : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public MongDBConnect()
        {

        }
    }
}
