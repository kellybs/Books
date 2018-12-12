using AspNet.Repository.Impl;
using AspNetCore.Entitys;
using AspNetCore.Services.Abstracts;
using AspNetCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.Services.Impl
{
    public class BookTypeServices : IBookTypeServices
    {
        private readonly BookTypeRepository bookTypeRepository;

        public BookTypeServices(BookTypeRepository _bookTypeRepository)
        {
            bookTypeRepository = _bookTypeRepository;
        }
        public BookTypeUI Query()
        {
            List<BookTypes> list = bookTypeRepository.GetList();
            BookTypeUI ui = new BookTypeUI() {
                BookList = list
            };

            if (null != list && list.Count > 0)
            {
                ui.ParentBooks = list.Where(t => t.ParentId == 0).ToList();
            }
            return ui;
        }
    }
}
