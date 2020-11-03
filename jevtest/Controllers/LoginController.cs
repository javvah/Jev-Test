using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using jevtest.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace jevtest.Controllers
{
    public class LoginController : Controller
    {
        Context DBveri = new Context();

        
        public IActionResult Index()
        {
            return View("signin");
        }
        
        [HttpGet]
        public IActionResult signin()
        {
            return View();
        }
     
        public async Task<IActionResult> signin(Users p)
        {
            var xdb = DBveri.MyUsers.FirstOrDefault(x => x.username == p.username && x.password == p.password);
            if (xdb != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.username)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Adminpage", "Home");
            }
          
            return View();
        }

        public IActionResult logout()
        {
            HttpContext.SignOutAsync();
            return View("signin");
        }


    }
}
