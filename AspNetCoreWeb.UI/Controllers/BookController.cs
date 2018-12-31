using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Dtos;
using AspNetCore.Services.Abstracts;
using AspNetCore.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWeb.UI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices book;
        private readonly IBookTypeServices bookTypeServices;
        private readonly IPublishHouseServices publishHouseServices;

        public BookController(IBookServices _book, IBookTypeServices _bookTypeServices, IPublishHouseServices _publishHouseServices)
        {
            this.book = _book;
            bookTypeServices = _bookTypeServices;
            publishHouseServices = _publishHouseServices;
        }

        public IActionResult Index(BookQuery query)
        {
            var list = book.GetList(query);
            return View(list);
        }


        public IActionResult Create()
        {
            BookAdd book = new BookAdd() {
                BookType = bookTypeServices.GetParentList(),
                PublishList = publishHouseServices.GetList(),
                SubTypes=0
            };
          
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookAdd model, IFormCollection collection)
        {
            var ri = book.Create(model);

            return Json(ri);
        }


        public IActionResult GetSub(int id)
        {
            var list = bookTypeServices.GetListByParentID(id);
            return Json(list);
        }

    }
}