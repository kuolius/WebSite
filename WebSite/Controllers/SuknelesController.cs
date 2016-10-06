using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;
using PagedList;

namespace WebSite.Controllers
{
    
    public class SuknelesController : Controller
    {
        private SuknelesDb db = new SuknelesDb();
        

        // GET: Sukneles
        public ActionResult Index(string sortOrder,string currentFilter,string searchString,int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.PriceSortParm = sortOrder == "price" ? "price_desc" : "price";

            if(searchString!=null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var sukneles = db.Sukneles.Select(s=>s);

            if(!String.IsNullOrEmpty(searchString))
            {
                sukneles = db.Sukneles.Where(s => s.name.ToUpper().Contains(searchString.ToUpper()));
            }

            switch(sortOrder)
            {
                case "name_desc":
                    sukneles = sukneles.OrderByDescending(s => s.name);
                    break;
                case "price":
                    sukneles = sukneles.OrderBy(s => s.price);
                    break;
                case "price_desc":
                    sukneles = sukneles.OrderByDescending(s => s.price);
                    break;
                default:
                    sukneles = sukneles.OrderBy(s => s.name);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(sukneles.ToPagedList(pageNumber,pageSize));
        }

        // GET: Sukneles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suknele suknele = db.Sukneles.Find(id);
            if (suknele == null)
            {
                return HttpNotFound();
            }
            return View(suknele);
        }

        // GET: Sukneles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sukneles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,genger,price,age")] Suknele suknele)
        {
            if (ModelState.IsValid)
            {
                db.Sukneles.Add(suknele);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suknele);
        }

        // GET: Sukneles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suknele suknele = db.Sukneles.Find(id);
            if (suknele == null)
            {
                return HttpNotFound();
            }
            return View(suknele);
        }

        // POST: Sukneles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,genger,price,age")] Suknele suknele)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suknele).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suknele);
        }

        // GET: Sukneles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suknele suknele = db.Sukneles.Find(id);
            if (suknele == null)
            {
                return HttpNotFound();
            }
            return View(suknele);
        }

        // POST: Sukneles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suknele suknele = db.Sukneles.Find(id);
            db.Sukneles.Remove(suknele);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
