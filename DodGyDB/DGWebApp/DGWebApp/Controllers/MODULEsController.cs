using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DGWebApp;

namespace DGWebApp.Controllers
{
    public class MODULEsController : Controller
    {
        private DGdbEntities1 db = new DGdbEntities1();

        // GET: MODULEs
        public ActionResult Index()
        {
            return View(db.MODULEs.ToList());
        }

        // GET: MODULEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULE mODULE = db.MODULEs.Find(id);
            if (mODULE == null)
            {
                return HttpNotFound();
            }
            return View(mODULE);
        }

        // GET: MODULEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MODULEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAC")] MODULE mODULE)
        {
            if (ModelState.IsValid)
            {
                db.MODULEs.Add(mODULE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mODULE);
        }

        // GET: MODULEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULE mODULE = db.MODULEs.Find(id);
            if (mODULE == null)
            {
                return HttpNotFound();
            }
            return View(mODULE);
        }

        // POST: MODULEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAC")] MODULE mODULE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mODULE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mODULE);
        }

        // GET: MODULEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MODULE mODULE = db.MODULEs.Find(id);
            if (mODULE == null)
            {
                return HttpNotFound();
            }
            return View(mODULE);
        }

        // POST: MODULEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MODULE mODULE = db.MODULEs.Find(id);
            db.MODULEs.Remove(mODULE);
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
