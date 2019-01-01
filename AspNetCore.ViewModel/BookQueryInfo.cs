using AspNetCore.Entitys;
using System.Collections.Generic;

namespace AspNetCore.ViewModel
{
    public class BookQueryInfo: Books
    {
        public string TypeName { get; set; }


        public string PublishName { get; set; }
    }

    public class BookUI {
     

        public Books Book { get; set; }

        public List<BookTypes> BookType { get; set; }

        public List<PublishHouse> PublishList { get; set; }
    }
}
