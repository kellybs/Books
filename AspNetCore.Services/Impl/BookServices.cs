﻿using AspNet.Repository.Abs;
using AspNetCore.Dtos;
using AspNetCore.Entitys;
using AspNetCore.Services.Abstracts;
using AspNetCore.ViewModel;
using log4net;
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
        private ILog log;
        public BookServices(IBookRepository _book)
        {
            book = _book;
            
            this.log = LogManager.GetLogger("NETCoreRepository", typeof(BookServices));            
        }


        private ResultInfo Check(BookUI model)
        {
            ResultInfo ri = new ResultInfo();

            if (model.Book.ParentType == 0)
            {
                ri.Msg = "请选择父类";
                return ri;
            }


            if (model.Book.SubType == 0)
            {
                ri.Msg = "请选择子类";
                return ri;
            }


            if (model.Book.PublishHouseID == 0)
            {
                ri.Msg = "请选择出版社";
                return ri;
            }

            if (string.IsNullOrWhiteSpace(model.Book.BookName))
            {
                ri.Msg = "请输入书籍名称";
                return ri;
            }

            if (string.IsNullOrWhiteSpace(model.Book.Author))
            {
                ri.Msg = "请输入作者";
                return ri;
            }
            if (string.IsNullOrWhiteSpace(model.Book.Summary))
            {
                ri.Msg = "请输入简介";
                return ri;
            }

            ri.Code = 0;
            return ri;
        }

        public ResultInfo Create(BookUI model)
        {

            var books = Check(model);
            if (books.Code != 0) return books;

            var item = model.Book;           

            item.CreateTime = DateTime.Now;
            item.BookId = Guid.NewGuid();
            try
            {
                book.Create(item);

                books.Code = 0;
                books.Msg = "Success";
                books.Url = "/Book";
            }
            catch(Exception e)
            {
                log.Error("Create:", e);
                books.Msg = "异常错误";
            }
            


            return books;
        }

        public ResultInfo Delete(Guid id)
        {
            ResultInfo ri = new ResultInfo();

            Books model = book.GetItem(id);
            if (null == model)
            {
                ri.Msg = "删除的记录不存在";
                return ri;
            }

            try
            {
                book.Delete(model);
                ri.Code = 0;

            }
            catch(Exception error)
            {
                log.Error("Delete:", error);
                ri.Msg = "异常错误";
            }

            return ri;
        }

        public Books GetItem(Guid id)
        {
            return book.GetItem(id);
        }

        public PageList<BookQueryInfo> GetList(BookQuery query)
        {
            var list= book.GetList(query);
            list.Href = $"/Book?ParentType={query.ParentType}&SubType={query.SubType}&=PublishHouseId={query.PublishHouseId}";
            return list;
        }

        public ResultInfo Update(BookUI model)
        {
            var books = Check(model);
            if (books.Code != 0) return books;
            books.Code = -1;
            var item = book.GetItem(model.Book.BookId);
            if (item == null)
            {
                books.Msg = "修改的信息不存在";
                return books;
            }

            model.Book.CreateTime = item.CreateTime;

            try
            {
                book.Update(model.Book);
                books.Code = 0;
                books.Msg = "Success";
                books.Url = "/Book";

            }
            catch(Exception e)
            {
                log.Error("Update:", e);
                books.Msg = "异常错误";
            }

            return books;
        }
    }
}
