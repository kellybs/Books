using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Entitys;
using AspNetCore.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreWeb.UI.Controllers
{
    public class PublishController : Controller
    {
        private readonly IPublishHouseServices publish;

        public PublishController(IPublishHouseServices _publish)
        {
            publish = _publish;
        }
        public IActionResult Index()
        {
            var list = publish.GetList();
            return View(list);
        }

        public IActionResult Create()
        {           
            return View(new PublishHouse());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublishHouse model, IFormCollection collection)
        {
            var ri = publish.Create(model);

            return Json(ri);
        }

        public IActionResult Edit(int id)
        {
            var model = publish.GetItem(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PublishHouse model, IFormCollection collection)
        {
            var ri = publish.Update(model);

            return Json(ri);
        }

        [HttpPost]
    
        public ActionResult Delete(int id)
        {
            var ri = publish.Delete(id);

            return Json(ri);
        }
    }
}