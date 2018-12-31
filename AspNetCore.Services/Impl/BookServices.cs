using AspNet.Repository.Abs;
using AspNetCore.Dtos;
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
    public class BookServices : IBookServices
    {
        private readonly IBookRepository book;

        public BookServices(IBookRepository _book)
        {
            book = _book;
        }

        public ResultInfo Create(BookAdd model)
        {
            var item = model.Book;

            ResultInfo ri = new ResultInfo() { Code=-1 };

            if (model.SubTypes == 0)
            {
                ri.Msg = "请选择子类";
                return ri;
            }

            if (item.PublishHouseID == 0)
            {
                ri.Msg = "请选择出版社";
                return ri;
            }

            if (string.IsNullOrWhiteSpace(item.BookName))
            {
                ri.Msg = "请输入书籍名称";
                return ri;
            }

            if (string.IsNullOrWhiteSpace(item.Author))
            {
                ri.Msg = "请输入作者";
                return ri;
            }
            if (string.IsNullOrWhiteSpace(item.Summary))
            {
                ri.Msg = "请输入简介";
                return ri;
            }

            item.CreateTime = DateTime.Now;
            item.BookId = Guid.NewGuid();
            try
            {
                book.Create(item);

                ri.Code = 0;
                ri.Msg = "Success";
                ri.Url = "/Book";
            }
            catch
            {

            }
            


            return ri;
        }

        public PageList<BookQueryInfo> GetList(BookQuery query)
        {
            return book.GetList(query);
        }
    }
}
