using Blogger.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Areas.admin.Controllers
{
    [Area("admin"),Authorize]
    public class BegenilerController : Controller
    {
        private DatabaseContext db;
        public BegenilerController(DatabaseContext db)
        {
            this.db = db;
        }
        [Route("/admin/Begeniler/{id}")]
        public IActionResult Index(int id)
        {
            return View(db.LikeDisLike.Where(x=> x.BlogId == id));
        }
    }
}
