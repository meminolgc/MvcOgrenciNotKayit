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
        // GET: Ogrenci
        DbOkulMvcEntities db = new DbOkulMvcEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }
    }
}