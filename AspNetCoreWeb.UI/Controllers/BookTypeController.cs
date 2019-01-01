using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Services.Abstracts;
using AspNetCore.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCoreWeb.UI.Controllers
{
    public class BookTypeController : Controller
    {

        private readonly IBookTypeServices bookTypeServices;

        public BookTypeController(IBookTypeServices books, IOptions<DbConn> dbconn)
        {
            bookTypeServices = books;
            var connection = dbconn.Value;

            string result = connection.SqlServer;
        }

        public ActionResult Index()
        {
            var list = bookTypeServices.Query();
            return View(list);
        }

    

        // GET: BookType/Create
        public ActionResult Create()
        {
            BookTypeModel model = new BookTypeModel() {
                Parent=bookTypeServices.GetParentList()
            };
            
            return View(model);
        }

        // POST: BookType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookTypeModel model,IFormCollection collection)
        {
            var ri = bookTypeServices.Create(model);

            return Json(ri);
        }

      
        // POST: BookType/Delete/5
        [HttpPost]
        
        public ActionResult Delete(int id)
        {
            var ri = bookTypeServices.Delete(id);

            return Json(ri);
        }
    }
}