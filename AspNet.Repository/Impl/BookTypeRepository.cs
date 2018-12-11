using AspNet.Repository.Abstracts;
using AspNetCore.Entitys;
using Dapper;
using Dapper.Contrib.Extensions;

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
    }
}
