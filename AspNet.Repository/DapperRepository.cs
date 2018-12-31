using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Repository
{
    public abstract class DapperRepository
    {
        public const int TIMEOUT = 20;

        public DbConnectionProvider DbConnectionProvider { get; private set; }

        public DapperRepository(DbConnectionProvider dbConnectionProvider)
        {
            this.DbConnectionProvider = dbConnectionProvider;
        }

        public IDbConnection DbConnection(DataBaseType dataBaseType = DataBaseType.Master)
        {
            if (this.DbConnectionProvider != null)
            {
                return this.DbConnectionProvider.CreateDbConnection(dataBaseType);
            }
            throw new InvalidOperationException("Can not create DbConnection");
        }


        public void SqlInsertBatch(DataTable data, SqlRowsCopiedEventHandler onSqlRowsCopied = null, IDbTransaction transaction = null)
        {
            var tblName = data.TableName;
            var tran = (SqlTransaction)transaction;
            SqlConnection conn = null;
            if (tran != null)
            {
                conn = tran.Connection;
            }
            else
            {
                conn = this.DbConnection() as SqlConnection;
            }
            using (conn)
            {
                conn.Open();
                using (var bulkCopy = new SqlBulkCopy(conn, SqlBulkCopyOptions.Default, tran))
                {
                    bulkCopy.DestinationTableName = tblName;
                    for (int i = 0; i < data.Columns.Count; i++)
                    {
                        bulkCopy.ColumnMappings.Add(data.Columns[i].ColumnName, data.Columns[i].ColumnName);
                    }
                    bulkCopy.BatchSize = 1000;
                    bulkCopy.NotifyAfter = 1000;
                    bulkCopy.SqlRowsCopied += onSqlRowsCopied;
                    bulkCopy.WriteToServer(data);
                }
            }
        }
    }
}
