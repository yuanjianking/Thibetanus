using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.DBmanager.MongDB;
using Thibetanus.DBmanager.PostgreSQL;

namespace Thibetanus.DBmanager
{
    class DBFactory
    {
        public enum DBServerType
        {
            [Description(" Postgre")]
            PostgreSQL,
            [Description("mongdb")]
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
                case DBServerType.PostgreSQL:
                    connect = new PostgreSQLConnect();
                    break;
                default:
                    break;
            }
            return connect;
        }

        public DBConnect GetMongDBConnect()
        {
            return new MongDBConnect();
        }

        public DBConnect GetPostgreSQLDBConnect()
        {
            return new PostgreSQLConnect();
        }
    }
}
