using AspNet.Repository.Abs;
using AspNetCore.Dtos;
using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet.Repository.Impl
{
    public class BookRepository : IBookRepository
    {
        public bool Create(Books model)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                return conn.Insert(model)>0;
            }
        }       

        public PageList<BookQueryInfo> GetList(BookQuery query)
        {
            var barList = new PageList<BookQueryInfo>(query.PageIndex, query.PageSize);

            var queryString = @"
                                  select * from ( SELECT ROW_NUMBER() OVER(ORDER BY CreateTime DESC ) as RowID,* FROM Books where 1=1 {0}) r
                                where r.RowID>=@StartIndex  and r.RowID<@EndIndex;

                                select Count(*) as RecordTotal from Books
                                where 1=1  {0} ";
            DynamicParameters para = new DynamicParameters();
            para.Add("@StartIndex", query.StartIndex);
            para.Add("@EndIndex", query.EndIndex);

            string whereStr = string.Empty;
            if (query.BookTypeId>0)
            {
                whereStr += " and  BookTypeId=@BookTypeId ";
                para.Add("@BookTypeId", query.BookTypeId);
            }

            if (query.PublishHouseId > 0)
            {
                whereStr += " and  PublishHouseId=@PublishHouseId ";
                para.Add("@PublishHouseId", query.PublishHouseId);
            }
            queryString = string.Format(queryString, whereStr);

            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                using (var multi = conn.QueryMultiple(queryString, para))
                {
                    barList.List = multi.Read<BookQueryInfo>().ToList();
                    barList.RecordTotal = multi.ReadSingle<int>();
                }
                    
            }           

            return barList;
        }
    }
}
