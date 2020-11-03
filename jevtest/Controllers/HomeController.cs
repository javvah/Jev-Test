using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using jevtest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            List<SelectListItem> droplsit = (from x in DBveri.UserRolls.ToList()
                                             select new SelectListItem {
                                                 Text = x.Roll,
                                                 Value = x.id.ToString()

                                             }).ToList();
            ViewBag.ListOfRolls = droplsit;
            return View();
        }

        [HttpPost]
        public IActionResult Index5(Users yeniuye)
        {
            var yeniuyerolu = DBveri.UserRolls.Where(x => x.id == yeniuye.Roll.id).FirstOrDefault();
            yeniuye.Roll = yeniuyerolu;
            DBveri.MyUsers.Add(yeniuye);
            DBveri.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult uyesil(int id)
        {
            var silinecek = DBveri.MyUsers.Find(id);
            DBveri.MyUsers.Remove(silinecek);
            DBveri.SaveChanges();
            return RedirectToAction("Adminpage");
        }

        [Authorize]
        public IActionResult Adminpage()
        {
            List<SelectListItem> droplsit = (from x in DBveri.UserRolls.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Roll,
                                                 Value = x.id.ToString()

                                             }).ToList();
            ViewBag.ListOfRolls = droplsit;
            Users A = new Users();
            ViewBag.obj = A;
            // var uyelist = DBveri.MyUsers.ToList(); ilişki olazsa
            var uyelist = DBveri.MyUsers.Include(x=>x.Roll).ToList();
            return View(uyelist);
        }
        [Authorize]
        public IActionResult verigetir(int id)
        {
            List<SelectListItem> droplsit = (from x in DBveri.UserRolls.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.Roll,
                                                 Value = x.id.ToString()

                                             }).ToList();
            ViewBag.ListOfRolls = droplsit;
            var uye = DBveri.MyUsers.Find(id);
            return View(uye);
        }

        [Authorize]
        public IActionResult dbguncelle(Users uye)
        {
            var eskiveri = DBveri.MyUsers.Find(uye.UserId);
            var yeniuyerolu = DBveri.UserRolls.Where(x => x.id == uye.Roll.id).FirstOrDefault();
            eskiveri.Roll = yeniuyerolu;
            eskiveri.Name = uye.Name;
            eskiveri.SureName = uye.SureName;
            eskiveri.companey = uye.companey;
            eskiveri.username = uye.username;
            eskiveri.password = uye.password;
            eskiveri.Rollid = yeniuyerolu.id;
            DBveri.SaveChanges();
            return RedirectToAction("Adminpage");
        }
        [Authorize]
        public IActionResult Rollist(int id)
        {
            var uyeler = DBveri.MyUsers.Where(x => x.Rollid == id).ToList();
            var rolname = DBveri.UserRolls.Where(x => x.id == id).Select(y => y.Roll).FirstOrDefault();
            ViewBag.pageheader = rolname;
            return View(uyeler);
        }

      
    }
}
