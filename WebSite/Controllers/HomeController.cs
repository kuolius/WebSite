using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;


namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private SuknelesDb db = new SuknelesDb();
        // GET: Home
        public ActionResult Index(string id)
        {
            return View();
        }

        public ActionResult DailyDeal()
        {
            var suknele = GetDailyDeal();
            return PartialView("_DailyDeal", suknele);

        }
        
        private Suknele GetDailyDeal()
        {
            var suknele = db.Sukneles.OrderBy(a => a.price).First();
            suknele.price *= .5m;
            return suknele;
        }

        [HttpGet]
        public ActionResult SearchResults(string q)
        {
            var sukneles = GetSukneles(q);
            return PartialView(sukneles);
        }

        private List<Suknele> GetSukneles(string q)
        {
            return db.Sukneles.Where(s => s.name.Contains(q)).ToList();
        }

        public ActionResult QuickSearch(string term)
        {
            var sukneles = db.Sukneles.Where(a => a.name.Contains(term)).ToList().Select(a => new { value = a.name });
            return Json(sukneles, JsonRequestBehavior.AllowGet);
        }
    }
}