using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using System.Collections.Generic;

namespace AspNetCore.Services.Abstracts
{
    public interface IBookTypeServices
    {
        BookTypeUI Query();

        List<BookTypes> GetParentList();

        ResultInfo Create(BookTypeModel model);

        BookTypes GetItem(int id);

        List<BookTypes> SearchAll();

        List<BookTypes> GetListByParentID(int parentId);

        ResultInfo Delete(int id);
    }
}
