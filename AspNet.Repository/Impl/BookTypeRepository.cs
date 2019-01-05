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

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Create(BookTypes model)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                string sql = "insert into BookTypes(TypeName,ParentId) values(@typename,@ParentId)";
                return conn.Execute(sql, model);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(BookTypes model)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                return conn.Delete(model);
            }
        }

        /// <summary>
        /// 获取某个分类下的子类
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<BookTypes> GetChildList(int parentId)
        {
            const string sql = "select BookTypeId,TypeName,ParentId  from booktypes where ParentId=@ParentId ";
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {                
                return conn.Query<BookTypes>(sql, new { ParentId = parentId }).ToList();
            }
        }

        /// <summary>
        /// 查找单条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BookTypes GetItem(int id)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql = "select BookTypeId,TypeName,ParentId  from booktypes where BookTypeId=@Id ";
                return conn.QuerySingle<BookTypes>(sql, new { Id = id });
            }
        }

        /// <summary>
        /// 根据名称查找分类信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public BookTypes GetItemByName(string name)
        {
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql = "select BookTypeId,TypeName,ParentId  from booktypes where TypeName=@TypeName ";
                return conn.QueryFirstOrDefault<BookTypes>(sql, new { TypeName = name });
            }
        }

        /// <summary>
        /// 查找全部记录，包括当前信息的父类
        /// </summary>
        /// <returns></returns>
        public List<BookTypeName> GetList()
        {
           

            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql = "select b.BookTypeId,b.TypeName,b.ParentId,k.TypeName as ParentName  from booktypes b left join BookTypes k on b.ParentId=k.BookTypeId";
                return conn.Query<BookTypeName>(sql).ToList();
            }
        }

        /// <summary>
        /// 获取所有父类
        /// </summary>
        /// <returns></returns>
        public List<BookTypes> GetParentList()
        {


            using (IDbConnection conn = DataBaseConfig.GetSqlConnection(null))
            {
                const string sql = "select BookTypeId,TypeName,ParentId  from booktypes where parentid=0 ";
                return conn.Query<BookTypes>(sql).ToList();
            }
        }

        /// <summary>
        /// 查找全部记录
        /// </summary>
        /// <returns></returns>
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
