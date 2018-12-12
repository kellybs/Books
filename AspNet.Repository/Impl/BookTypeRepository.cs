using AspNet.Repository.Abstracts;
using AspNetCore.Entitys;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace AspNet.Repository.Impl
{
    public class BookTypeRepository:DapperRepository,IBookTypeRepository
    {
        public BookTypeRepository()
           : base(DbConnectionProvider.Main)
        {
        }

        public bool Create(BookTypes model)
        {
            return DbConnection().Insert(model) > 0;
        }

        public List<BookTypes> GetList()
        {
            string sql = "select BookTypeId,TypeName,ParentId  from booktypes";
            return this.DbConnection().Query<BookTypes>(sql).ToList();
        }
    }
}
