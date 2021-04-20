using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ComplaintForCinema;

namespace ComplaintForCinema.Controllers
{
    public class ComplaintDepartamentsController : Controller
    {
        private ComplaintCinemaEntities db = new ComplaintCinemaEntities();

        // GET: ComplaintDepartaments
        public ActionResult Index()
        {
            return View(db.ComplaintDepartaments.ToList());
        }

        // GET: ComplaintDepartaments/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintDepartament complaintDepartament = db.ComplaintDepartaments.Find(id);
            if (complaintDepartament == null)
            {
                return HttpNotFound();
            }
            return View(complaintDepartament);
        }

        // GET: ComplaintDepartaments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplaintDepartaments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplaintDepartamentID,ComplaintDepartamentDescription,ComplaintDepartamentIsActive")] ComplaintDepartament complaintDepartament)
        {
            if (ModelState.IsValid)
            {
                complaintDepartament.ComplaintDepartamentID = Guid.NewGuid();
                db.ComplaintDepartaments.Add(complaintDepartament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complaintDepartament);
        }

        // GET: ComplaintDepartaments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintDepartament complaintDepartament = db.ComplaintDepartaments.Find(id);
            if (complaintDepartament == null)
            {
                return HttpNotFound();
            }
            return View(complaintDepartament);
        }

        // POST: ComplaintDepartaments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplaintDepartamentID,ComplaintDepartamentDescription,ComplaintDepartamentIsActive")] ComplaintDepartament complaintDepartament)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaintDepartament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complaintDepartament);
        }

        // GET: ComplaintDepartaments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintDepartament complaintDepartament = db.ComplaintDepartaments.Find(id);
            if (complaintDepartament == null)
            {
                return HttpNotFound();
            }
            return View(complaintDepartament);
        }

        // POST: ComplaintDepartaments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ComplaintDepartament complaintDepartament = db.ComplaintDepartaments.Find(id);
            db.ComplaintDepartaments.Remove(complaintDepartament);
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
