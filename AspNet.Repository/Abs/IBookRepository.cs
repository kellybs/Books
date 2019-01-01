using AspNetCore.Dtos;
using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using System;
using System.Collections.Generic;

namespace AspNet.Repository.Abs
{
    public interface IBookRepository
    {
        bool Create(Books model);

        bool Delete(Books model);

        bool Update(Books model);

        Books GetItem(Guid id);

        PageList<BookQueryInfo> GetList(BookQuery query);

        int Count(int publicHouse);

        int CountByTypeID(int subTypeId);
        
    }
}
