using Final_Project.Models;
using Final_Project.Models.Entites;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace Final_Project.Controllers
{
    public class AccountController : Controller
    {
        Company Db = new Company();
        public List<User> users = null;
       
        public AccountController() { 
        users= Db.Users.ToList();
        }
        public IActionResult Login(string returnUrl="/")
        {
            users = Db.Users.ToList();
            Login login=new Login();
            login.ReturnUrl = returnUrl;
            return View(login);
        }
        [HttpPost]
        public async Task<IActionResult>Login(Login l)
        {
            var user=users.Where(u=> u.Name==l.Username && u.Password==l.Password).FirstOrDefault();
            if (user!=null) {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,Convert.ToString(user.Id)),
                    new Claim(ClaimTypes.Name,user.Name),
                    new Claim(ClaimTypes.Role,user.Role),
                    new Claim("CompanyITI","Code")
                };

                //var identity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                //var principal=new ClaimsPrincipal(identity);
                //await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principal,
                //    new AuthenticationProperties()
                //    {
                //        IsPersistent=l.RememberMe
                //    });
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                return LocalRedirect(l.ReturnUrl);
            }
            else
            {
                ViewBag.Message = "Invalid Credential";
                return View(l);
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return LocalRedirect("/");
        }
}
}
