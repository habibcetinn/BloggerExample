using Blogger.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddDbContext <DatabaseContext>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    x.DefaultScheme= CookieAuthenticationDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(s =>
{
    s.LoginPath = "/admin/Login";
    s.LogoutPath = "/admin/Login/Cikis";
    s.AccessDeniedPath = "/admin/YetkiYok";
});

var app = builder.Build();



app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(x=> x.MapDefaultControllerRoute());

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Login}/{action=Index}/{id?}"
    );
});

app.Run();
