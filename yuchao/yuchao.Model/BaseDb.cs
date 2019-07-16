using SqlSugar;
using System;

namespace yuchao.Model
{
    public class BaseDb
    {
        public static SqlSugarClient GetClient() {

            SqlSugarClient db = new SqlSugarClient(
                new ConnectionConfig()
                {
                    ConnectionString = BaseDbconfig.ConnectionString,
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true
                }
            );
            return db;
        }
    }
}
