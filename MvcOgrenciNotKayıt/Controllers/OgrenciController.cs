using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOgrenciNotKayıt.Models.EntityFramework;

namespace MvcOgrenciNotKayıt.Controllers
{
    public class OgrenciController : Controller
    {
        DbOkulMvcEntities db = new DbOkulMvcEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }
        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER ogr)
        {
            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == ogr.TBLKULUPLER.KULUPID).FirstOrDefault();
            ogr.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(ogr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            return View("OgrenciGetir", ogrenci);
        }
    }
}
