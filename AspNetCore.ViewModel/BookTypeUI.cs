using AspNetCore.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.ViewModel
{
    public class BookTypeUI
    {
        public List<BookTypes> BookList { get; set; }

        public List<BookTypes> ParentBooks { get; set; }
    }
}
