using AspNet.Repository.Abs;
using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper.Contrib.Extensions;

namespace AspNet.Repository.Impl
{
    public class BookTypeRepository:IBookTypeRepository
    {  

        public int Create(BookTypes model)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                string sql = "insert into BookTypes(TypeName,ParentId) values(@typename,@ParentId)";
                return conn.Execute(sql, model);
            }
        }

        public bool Delete(BookTypes model)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                return conn.Delete(model);
            }
        }

        public List<BookTypes> GetChildList(int parentId)
        {
            const string sql = "select BookTypeId,TypeName,ParentId  from booktypes where ParentId=@ParentId ";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {                
                return conn.Query<BookTypes>(sql, new { ParentId = parentId }).ToList();
            }
        }

        public BookTypes GetItem(int id)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql = "select BookTypeId,TypeName,ParentId  from booktypes where BookTypeId=@Id ";
                return conn.QuerySingle<BookTypes>(sql, new { Id = id });
            }
        }

        public BookTypes GetItemByName(string name)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql = "select BookTypeId,TypeName,ParentId  from booktypes where TypeName=@TypeName ";
                return conn.QueryFirstOrDefault<BookTypes>(sql, new { TypeName = name });
            }
        }

        public List<BookTypeName> GetList()
        {
           

            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql = "select b.BookTypeId,b.TypeName,b.ParentId,k.TypeName as ParentName  from booktypes b left join BookTypes k on b.ParentId=k.BookTypeId";
                return conn.Query<BookTypeName>(sql).ToList();
            }
        }

        public List<BookTypes> GetParentList()
        {


            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql = "select BookTypeId,TypeName,ParentId  from booktypes where parentid=0 ";
                return conn.Query<BookTypes>(sql).ToList();
            }
        }

        public List<BookTypes> SearchAll()
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql = "select BookTypeId,TypeName,ParentId  from booktypes ";
                return conn.Query<BookTypes>(sql).ToList();
            }
        }
    }
}
