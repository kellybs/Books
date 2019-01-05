using AspNet.Repository.Abs;
using AspNetCore.Entitys;
using System.Collections.Generic;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;

namespace AspNet.Repository.Impl
{
    public class PublishHouseRepository : IPublishHouseRepository
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public long Create(PublishHouse model)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {                
                return conn.Insert(model);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(PublishHouse model)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                return conn.Delete(model);
            }
        }

        /// <summary>
        /// 根据名称查找记录是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public PublishHouse Exists(string name)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql = "select PublishHouseID,PublishName,IsRecommend from PublishHouse where PublishName=@PublishName";
                return conn.QueryFirstOrDefault<PublishHouse>(sql, new { PublishName = name });
            }
        }

        /// <summary>
        /// 获取单条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PublishHouse GetItem(int id)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql= "select PublishHouseID,PublishName,IsRecommend from PublishHouse where PublishHouseID=@PublishHouseID";
                return conn.QuerySingleOrDefault<PublishHouse>(sql, new { PublishHouseID = id });
            }
        }

        /// <summary>
        /// 获取所有记录
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PublishHouse> GetList()
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql = "select PublishHouseID,PublishName,IsRecommend from PublishHouse  order by PublishHouseID desc";
                return conn.Query<PublishHouse>(sql);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(PublishHouse model)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                return conn.Update(model);
            }
        }
    }
}
