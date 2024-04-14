using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOgrenciNotKayıt.Models.EntityFramework;

namespace MvcOgrenciNotKayıt.Controllers
{
    public class DefaultController : Controller
    {
        DbOkulMvcEntities db = new DbOkulMvcEntities();

        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER drs)
        {
            db.TBLDERSLER.Add(drs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DersGetir(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            return View("DersGetir", ders);
        }
        public ActionResult Güncelle(TBLDERSLER p)
        {
            var drs = db.TBLDERSLER.Find(p.DERSID);
            drs.DERSAD = p.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}