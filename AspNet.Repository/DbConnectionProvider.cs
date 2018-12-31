using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace AspNet.Repository
{

    
    public abstract class DbConnectionProvider
    {
        public static Main_DbConnectionProvider Main = new Main_DbConnectionProvider();

        public abstract IDbConnection CreateDbConnection(DataBaseType dataBaseType = DataBaseType.Master);
    }

    public class Main_DbConnectionProvider : DbConnectionProvider
    {

        const string sqlConn = "Server=.;Database=db_Core;User ID=sa;Password=123456;";

        public Database MaterDatabase { get; private set; }

        public Main_DbConnectionProvider()
        {

          
            try
            {
                this.MaterDatabase = DatabaseFactory.CreateDatabase(sqlConn);
            }
            catch (Exception ex)
            {

            }
        }

        public override IDbConnection CreateDbConnection(DataBaseType dataBaseType = DataBaseType.Master)
        {
            return this.MaterDatabase.CreateConnection();
        }

       
    }

    /// <summary>
    /// 数据库配置
    /// </summary>
    public class DataBaseConfig
    {
        #region SqlServer链接配置
        /// <summary>
        /// 默认的Sql Server的链接字符串
        /// </summary>
        private static string DefaultSqlConnectionString = @"Data Source=.;Initial Catalog=db_Core;User ID=sa;Password=rdc123$;";
        public static IDbConnection GetSqlConnection(string sqlConnectionString = null)
        {
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                sqlConnectionString = DefaultSqlConnectionString;
            }
            IDbConnection conn = new SqlConnection(sqlConnectionString);

            
            conn.Open();
            return conn;
        }
        #endregion
    }
}
