using AspNetCore.Entitys;

namespace AspNet.Repository.Abstracts
{
    public interface IBookTypeRepository
    {
        bool Create(BookTypes model);
    }
}
