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
       

        public MongDBConnect()
        {

        }

        public void StartConnect()
        {
            throw new NotImplementedException();
        }

        public void CloseConnect()
        {
            throw new NotImplementedException();
        }

        public void SaveChange()
        {
            throw new NotImplementedException();
        }

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

        public void Modify<TSource>(TSource model) where TSource : class
        {
            throw new NotImplementedException();
        }

        public void Add<TSource>(TSource model) where TSource : class
        {
            throw new NotImplementedException();
        }

    
    }
}
