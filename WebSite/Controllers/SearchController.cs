using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class SearchController : Controller
    {
        private Models.SuknelesDb db = new Models.SuknelesDb();
        // GET: Search
        [HttpGet]
        public ActionResult Search(string q)
        {
            var sukneles = db.Sukneles.Where(a => a.name.Contains(q));
            return View(sukneles);
        }
    }
}