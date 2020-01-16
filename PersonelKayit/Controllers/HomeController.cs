using PersonelKayit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;
using PersonelKayit.Content;

namespace PersonelKayit.Controllers
{ 
    public class HomeController : Controller
    {
        PersonelDbContext db = new PersonelDbContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [LoginControl]
        public ActionResult Home()
        {
            var p = db.Personels.ToList();
            return View(p);

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var log = db.Users.Where(a => a.Name.Equals(user.Name) && a.Password.Equals(user.Password)).FirstOrDefault();
                if (log != null)
                {
                    Session["Name"] = log.Name.ToString();
                    Session["Password"] = log.Password.ToString();
                    return RedirectToAction("Home", "Home");
                }
                else
                {
                    ViewBag.LoginError = "Hatalı kullanıcı ve şifre";

                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult UserCreate()
        {
            return View();
        }

        [HttpPost]
        [LoginControl]
        public ActionResult UserCreate(User user)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            db.Users.Add(user);
            db.SaveChanges();
           
            ViewBag.Return="Kaydetme işleminiz gerçekleşti.";
            return RedirectToAction("UserCreate");

        }

        public ActionResult PersonelCreate()
        {
            return View();
        }

        [HttpPost]
        [LoginControl]
        public ActionResult PersonelCreate(Personel personel)
        {

            if (!ModelState.IsValid)
            {
                return View();
                
            }
               
            db.Personels.Add(personel);
            db.SaveChanges();
            ViewBag.LoginError = "Kaydetme işleminiz gerçekleşmiştir.";
            return View();

        }

        [HttpPost]
        [LoginControl]
        public ActionResult Delete(int id)
        {
            Personel p = db.Personels.Find(id);
            db.Personels.Remove(p);
            db.SaveChanges();
            return Json(true);
        }
    }
}