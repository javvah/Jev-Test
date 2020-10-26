using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jevtest.Models;
using Microsoft.AspNetCore.Mvc;

namespace jevtest.Controllers
{
    public class HomeController : Controller
    {
        Context DBveri = new Context();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            var ktb = new List<kitab>()
            {
            new kitab() { ID = 1, kitabad="HTTPD",yazar="ali" },
            new kitab() { ID = 2, kitabad = "HTTPD2222", yazar = "hasan" },
            new kitab() { ID = 3, kitabad = "HTTsssPD", yazar = "ahmet" },
            };
            return View(ktb);
        }

        public IActionResult Index3()
        {
            ViewBag.Deger1 = "FUCK THIS WORLD";
            return View();
        }

        public IActionResult Index4()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index5()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index5(Users yeniuye)
        {
            DBveri.MyUsers.Add(yeniuye);
            DBveri.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult uyesil(int id)
        {
            var silinecek = DBveri.MyUsers.Find(id);
            DBveri.MyUsers.Remove(silinecek);
            DBveri.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Adminpage()
        {
            var uyelist = DBveri.MyUsers.ToList();
            return View(uyelist);
        }
        public IActionResult verigetir(int id)
        {
            var uye = DBveri.MyUsers.Find(id);
            return View(uye);
        }

        public IActionResult dbguncelle(Users uye)
        {
            var eskiveri = DBveri.MyUsers.Find(uye.UserId);
            eskiveri.Name = uye.Name;
            eskiveri.SureName = uye.SureName;
            eskiveri.companey = uye.companey;
            eskiveri.username = uye.username;
            eskiveri.password = uye.password;
            DBveri.SaveChanges();
            return RedirectToAction("Adminpage");
        }
    }
}
