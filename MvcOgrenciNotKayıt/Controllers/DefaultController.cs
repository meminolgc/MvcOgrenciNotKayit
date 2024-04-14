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
    }
}