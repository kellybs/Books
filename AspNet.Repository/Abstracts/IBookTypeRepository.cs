using AspNetCore.Entitys;
using System.Collections.Generic;

namespace AspNet.Repository.Abstracts
{
    public interface IBookTypeRepository
    {
        bool Create(BookTypes model);

        List<BookTypes> GetList();
    }
}
