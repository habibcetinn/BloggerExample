using Blogger.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace Blogger.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseContext db;
        public HomeController(DatabaseContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            // 2 veya daha fazla tabloyu, Html tarafına göndermek için Tuple Nesnesini kullanırız.
            var datalar = Tuple.Create<List<Blogs>, List<Projects>>(db.Blogs.ToList(),db.Projects.ToList());

            //    var TekSatir = Tuple.Create<Blogs, Projects>(db.Blogs.First(), db.Projects.First());

            // Uzun ve Sistemi yavaşlatır.
            //ViewBag.Proje = db.Projects.ToList();
            //ViewBag.Blog = db.Blogs.ToList();

            return View(datalar);
        }
    }
}
