using AspNet.Repository.Abs;
using AspNetCore.Dtos;
using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Data;
using System.Linq;

namespace AspNet.Repository.Impl
{
    public class BookRepository : IBookRepository
    {
        public int Count(int publicHouse)
        {
            const string sql = "SELECT COUNT(*) FROM Books WHERE PublishHouseID=@PublishHouseID ";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return (int)conn.ExecuteScalar(sql, new { PublishHouseID = publicHouse });
            }
           
        }

        public int CountByTypeID(int subTypeId)
        {
            const string sql = "SELECT COUNT(*) FROM Books WHERE SubType=@SubType ";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return (int)conn.ExecuteScalar(sql, new { SubType = subTypeId });
            }
        }

        public bool Create(Books model)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Insert(model)>0;
            }
        }

        public bool Delete(Books model)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Delete(model);
            }
        }

        public Books GetItem(Guid id)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                const string sql = "SELECT BookId,BookName,Author,PublishHouseID,ParentType,SubType,CostPrice,RealPrice,PublishDate,ISBN,Summary,IsRecommend,IsHot,CreateTime FROM Books WHERE BookId=@BookId";
                return conn.QuerySingle<Books>(sql, new { BookId = id });
            }
        }

        public PageList<BookQueryInfo> GetList(BookQuery query)
        {
            var barList = new PageList<BookQueryInfo>(query.PageIndex, query.PageSize);

            var queryString = @"
                                  select * from ( SELECT ROW_NUMBER() OVER(ORDER BY CreateTime DESC ) as RowID,* FROM Books where 1=1 {0}) r
                                where RowID between @StartIndex  and @EndIndex;

                                select Count(*) as RecordTotal from Books
                                where 1=1  {0} ";
            DynamicParameters para = new DynamicParameters();
            para.Add("@StartIndex", query.StartIndex);
            para.Add("@EndIndex", query.EndIndex);

            string whereStr = string.Empty;
            if (query.ParentType>0)
            {
                whereStr += " and  ParentType=@ParentType ";
                para.Add("@ParentType", query.ParentType);
            }

            if (query.SubType > 0)
            {
                whereStr += " and  SubType=@SubType ";
                para.Add("@SubType", query.SubType);
            }

            if (query.PublishHouseId > 0)
            {
                whereStr += " and  PublishHouseId=@PublishHouseId ";
                para.Add("@PublishHouseId", query.PublishHouseId);
            }
            queryString = string.Format(queryString, whereStr);

            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                using (var multi = conn.QueryMultiple(queryString, para))
                {
                    barList.List = multi.Read<BookQueryInfo>().ToList();
                    barList.RecordTotal = multi.ReadSingle<int>();
                }
                    
            }           

            return barList;
        }

        public bool Update(Books model)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                return conn.Update(model);
            }
        }
    }
}
