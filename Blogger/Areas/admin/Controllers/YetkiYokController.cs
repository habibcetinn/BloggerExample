using Microsoft.AspNetCore.Mvc;

namespace Blogger.Areas.admin.Controllers
{
    [Area("admin")]
    public class YetkiYokController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
