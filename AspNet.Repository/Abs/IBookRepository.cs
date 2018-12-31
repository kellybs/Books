using AspNetCore.Dtos;
using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using System.Collections.Generic;

namespace AspNet.Repository.Abs
{
    public interface IBookRepository
    {
        bool Create(Books model);

        PageList<BookQueryInfo> GetList(BookQuery query);
        
    }
}
