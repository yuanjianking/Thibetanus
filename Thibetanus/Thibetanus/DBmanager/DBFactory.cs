using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.DBmanager.MongDB;

namespace Thibetanus.DBmanager
{
    class DBFactory
    {
        public enum DBServerType
        {
            [Description("关系数据库")]
            ServerSQL,
            [Description("本地SQL数据库")]
            LocalSQL,
            [Description("内存SQL数据库")]
            MemorySQL,
            [Description("内存NoSQL数据库")]
            MemoryNoSQL,
            [Description("本地KV数据库")]
            LocalKV,
            [Description("其它数据库,redis,mongdb等")]
            NoSQL
        }

        public DBConnect GetDBConnect(DBServerType type)
        {
            DBConnect connect = null;
            switch (type)
            {
                case DBServerType.NoSQL:
                    connect = new MongDBConnect();
                    break;
                default:
                    break;

            }
            return connect;
        }
    }
}
