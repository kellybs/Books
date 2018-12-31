using AspNetCore.Entitys;
using System.Collections.Generic;

namespace AspNetCore.ViewModel
{
    public class BookTypeUI
    {
        public List<BookTypeName> BookList { get; set; }

        public List<BookTypeName> ParentBooks { get; set; }
    }


    public class BookTypeModel
    {
        public BookTypes BookType { get; set; }

        public IEnumerable<BookTypes> Parent { get; set; }
    }
}
