using AspNetCore.Dtos;
using AspNetCore.Entitys;
using AspNetCore.ViewModel;

namespace AspNetCore.Services.Abstracts
{
    public interface IBookServices
    {
        ResultInfo Create(BookAdd model);

        PageList<BookQueryInfo> GetList(BookQuery query);
    }
}
