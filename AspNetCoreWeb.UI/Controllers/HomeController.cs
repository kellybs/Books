using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreWeb.UI.Models;
using log4net;
using AspNetCore.Services.Abstracts;
using AspNetCore.Dtos;

namespace AspNetCoreWeb.UI.Controllers
{
    public class HomeController : Controller
    {

        private readonly IBookServices book;
        //private readonly IBookTypeServices bookTypeServices;
        //private readonly IPublishHouseServices publishHouseServices;

        private readonly ILog log;

        public HomeController(IBookServices _book)
        {
            book = _book;

            this.log = LogManager.GetLogger(Startup.repository.Name, typeof(HomeController));
        }

        public IActionResult Index(BookQuery query)
        {

            var home = book.Home(query);

            return View(home);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
