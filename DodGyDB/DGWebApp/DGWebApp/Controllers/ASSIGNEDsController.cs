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
    public class ASSIGNEDsController : Controller
    {
        private DGdbEntities1 db = new DGdbEntities1();

        // GET: ASSIGNEDs
        [Authorize]
        public ActionResult Index()
        {
            var aSSIGNEDs = db.ASSIGNEDs.Include(a => a.MODULE1).Include(a => a.STUDENT1);
            return View(aSSIGNEDs.ToList());
        }

        // GET: ASSIGNEDs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASSIGNED aSSIGNED = db.ASSIGNEDs.Find(id);
            if (aSSIGNED == null)
            {
                return HttpNotFound();
            }
            return View(aSSIGNED);
        }

        // GET: ASSIGNEDs/Create
        public ActionResult Create()
        {
            ViewBag.Module = new SelectList(db.MODULEs, "MAC", "MAC");
            ViewBag.Student = new SelectList(db.STUDENTs, "StudentID", "StudentID");
            return View();
        }

        // POST: ASSIGNEDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Student,Module,DateIssued")] ASSIGNED aSSIGNED)
        {
            if (ModelState.IsValid)
            {
                db.ASSIGNEDs.Add(aSSIGNED);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Module = new SelectList(db.MODULEs, "MAC", "MAC", aSSIGNED.Module);
            ViewBag.Student = new SelectList(db.STUDENTs, "StudentID", "StudentID", aSSIGNED.Student);
            return View(aSSIGNED);
        }

        // GET: ASSIGNEDs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASSIGNED aSSIGNED = db.ASSIGNEDs.Find(id);
            if (aSSIGNED == null)
            {
                return HttpNotFound();
            }
            ViewBag.Module = new SelectList(db.MODULEs, "MAC", "MAC", aSSIGNED.Module);
            ViewBag.Student = new SelectList(db.STUDENTs, "StudentID", "StudentID", aSSIGNED.Student);
            return View(aSSIGNED);
        }

        // POST: ASSIGNEDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Student,Module,DateIssued")] ASSIGNED aSSIGNED)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aSSIGNED).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Module = new SelectList(db.MODULEs, "MAC", "MAC", aSSIGNED.Module);
            ViewBag.Student = new SelectList(db.STUDENTs, "StudentID", "StudentID", aSSIGNED.Student);
            return View(aSSIGNED);
        }

        // GET: ASSIGNEDs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASSIGNED aSSIGNED = db.ASSIGNEDs.Find(id);
            if (aSSIGNED == null)
            {
                return HttpNotFound();
            }
            return View(aSSIGNED);
        }

        // POST: ASSIGNEDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ASSIGNED aSSIGNED = db.ASSIGNEDs.Find(id);
            db.ASSIGNEDs.Remove(aSSIGNED);
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
