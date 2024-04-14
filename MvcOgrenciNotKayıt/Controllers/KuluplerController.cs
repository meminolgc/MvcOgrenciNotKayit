using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOgrenciNotKayıt.Models.EntityFramework;

namespace MvcOgrenciNotKayıt.Controllers
{
    public class KuluplerController : Controller
    {
        // GET: Kulupler
        DbOkulMvcEntities db = new DbOkulMvcEntities();

        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }
    }
}