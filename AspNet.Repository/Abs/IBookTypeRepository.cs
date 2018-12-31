using AspNetCore.Entitys;
using AspNetCore.ViewModel;
using System.Collections.Generic;

namespace AspNet.Repository.Abs
{
    public interface IBookTypeRepository
    {
        int Create(BookTypes model);

        List<BookTypeName> GetList();

        List<BookTypes> GetParentList();

        List<BookTypes> SearchAll();

        BookTypes GetItem(int id);

        BookTypes GetItemByName(string name);
    }
}
