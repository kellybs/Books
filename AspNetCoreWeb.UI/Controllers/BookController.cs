using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Dtos;
using AspNetCore.Services.Abstracts;
using AspNetCore.ViewModel;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreWeb.UI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices book;
        private readonly IBookTypeServices bookTypeServices;
        private readonly IPublishHouseServices publishHouseServices;

        private readonly ILog log;

        public BookController(IBookServices _book, IBookTypeServices _bookTypeServices, IPublishHouseServices _publishHouseServices)
        {
           
            book = _book;
            bookTypeServices = _bookTypeServices;
            publishHouseServices = _publishHouseServices;
           
            this.log = LogManager.GetLogger(Startup.repository.Name, typeof(HomeController));
        }

        public IActionResult Index(BookQuery query)
        {           
            var list = book.GetList(query);
            return View(list);
        }


        public IActionResult Create()
        {
            BookUI book = new BookUI() {
                BookType = bookTypeServices.GetParentList(),
                PublishList = publishHouseServices.GetList(),
              
            };
          
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookUI model, IFormCollection collection)
        {
            var ri = book.Create(model);

            return Json(ri);
        }


        public IActionResult GetSub(int id)
        {
            var list = bookTypeServices.GetListByParentID(id);
            return Json(list);
        }

        [HttpPost]       
        public ActionResult Delete(Guid id)
        {
            var ri = book.Delete(id);
            return Json(ri);
        }

        public IActionResult Edit(Guid id)
        {
            var model = book.GetItem(id);
            BookUI bookEdit = new BookUI()
            {
                BookType = bookTypeServices.GetParentList(),
                PublishList = publishHouseServices.GetList(),              
                Book= model,              
            };

            return View(bookEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookUI model, IFormCollection collection)
        {
            var ri = book.Update(model);

            return Json(ri);
        }
    }
}