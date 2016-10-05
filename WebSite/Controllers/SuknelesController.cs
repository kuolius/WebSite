using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    
    public class SuknelesController : Controller
    {
        private SuknelesDb db = new SuknelesDb();
        

        // GET: Sukneles
        public ActionResult Index()
        {
            return View(db.Sukneles.ToList());
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
