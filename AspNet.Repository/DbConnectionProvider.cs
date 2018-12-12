using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Database MaterDatabase { get; private set; }



        public Main_DbConnectionProvider()
        {
            try
            {
                this.MaterDatabase = DatabaseFactory.CreateDatabase(AppSetting.GetConfig("ConnectionStrings:SqlServerConnection"));

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
}
