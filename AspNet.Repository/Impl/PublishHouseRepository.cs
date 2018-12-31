using AspNet.Repository.Abs;
using AspNetCore.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace AspNet.Repository.Impl
{
    public class PublishHouseRepository : IPublishHouseRepository
    {
        public long Create(PublishHouse model)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {                
                return conn.Insert(model);
            }
        }

        public PublishHouse GetItem(int id)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql= "select PublishHouseID,PublishName,IsRecommend from PublishHouse where PublishHouseID=@PublishHouseID";
                return conn.QuerySingleOrDefault<PublishHouse>(sql, new { PublishHouseID = id });
            }
        }

        public IEnumerable<PublishHouse> GetList()
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql = "select PublishHouseID,PublishName,IsRecommend from PublishHouse  order by PublishHouseID desc";
                return conn.Query<PublishHouse>(sql);
            }
        }
    }
}
