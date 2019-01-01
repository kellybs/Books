using AspNetCore.Dtos;
using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using System;

namespace AspNetCore.Services.Abstracts
{
    public interface IBookServices
    {
        ResultInfo Create(BookUI model);

        ResultInfo Delete(Guid id);

        Books GetItem(Guid id);

        ResultInfo Update(BookUI model);

        PageList<BookQueryInfo> GetList(BookQuery query);
    }
}
