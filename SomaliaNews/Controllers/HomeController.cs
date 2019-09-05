using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using SomaliaNews.Models;

namespace SomaliaNews.Controllers
{
    public class HomeController : Controller
    {
        private NewsDbContext db = new NewsDbContext();

        public ActionResult Index()
        {
            return View(db.News.ToList());
        }


        public ActionResult Details(int Id)

        {
            var news = db.News.Find(Id);
            return View(news);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}