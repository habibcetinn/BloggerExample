using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Blogger.Areas.admin.Controllers
{
    [Area("admin")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string email,string Sifre)
        {
            if (email =="admin@admin.com" && Sifre =="123")
            {
                //Giriş Yapan kişinin bilgilerini tutabileceğimiz ve hızlıca yönetmemizi sağlayan sınıf yapısına Claims denir.
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,"admin"),
                    new Claim(ClaimTypes.Surname,"Yönetici"),
                      new Claim(ClaimTypes.Role,"Yönetici")
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,"YonetiLogin");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);
                return Redirect("/admin/Bloglarim");
            }
            else
            {
                ViewBag.Mesaj = "Kullanıcı Adı veya Şifre Hatalı";
            }

            return View();
        }

        public IActionResult Cikis()
        {
            HttpContext.SignOutAsync();
            return Redirect("/admin/Login");
        }
    }
}
