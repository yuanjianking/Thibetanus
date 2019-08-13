using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private IMongoDatabase GetDataBase()
        {
            MongoClient client = new MongoClient(Conn);
            IMongoDatabase database = client.GetDatabase(DBName);
            return database;
        }
        
        public List<T1> SelectAll<T1>(string tableName)
        {
            var collection = GetDataBase().GetCollection<T1>(tableName);
            var filterBuilder = Builders<T1>.Filter;
            var filter = filterBuilder.Empty;
            return collection.Find(filter).ToList();
        }
    }
}
