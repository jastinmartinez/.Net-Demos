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
    public class Complaint_ComplaintDepartamentController : Controller
    {
        private ComplaintCinemaEntities db = new ComplaintCinemaEntities();

        // GET: Complaint_ComplaintDepartament
        public ActionResult Index()
        {
            var complaint_ComplaintDepartament = db.Complaint_ComplaintDepartament.Include(c => c.Complaint).Include(c => c.ComplaintDepartament);
            return View(complaint_ComplaintDepartament.ToList());
        }

        // GET: Complaint_ComplaintDepartament/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint_ComplaintDepartament complaint_ComplaintDepartament = db.Complaint_ComplaintDepartament.Find(id);
            if (complaint_ComplaintDepartament == null)
            {
                return HttpNotFound();
            }
            return View(complaint_ComplaintDepartament);
        }

        // GET: Complaint_ComplaintDepartament/Create
        public ActionResult Create()
        {
            ViewBag.ComplaintID = new SelectList(db.Complaints, "ComplaintID", "ComplaintTitle");
            ViewBag.ComplaintDepartamentID = new SelectList(db.ComplaintDepartaments, "ComplaintDepartamentID", "ComplaintDepartamentDescription");
            return View();
        }

        // POST: Complaint_ComplaintDepartament/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Complaint_ComplaintDepartamentID,ComplaintDepartamentID,ComplaintID")] Complaint_ComplaintDepartament complaint_ComplaintDepartament)
        {
            if (ModelState.IsValid)
            {
                complaint_ComplaintDepartament.Complaint_ComplaintDepartamentID = Guid.NewGuid();
                db.Complaint_ComplaintDepartament.Add(complaint_ComplaintDepartament);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComplaintID = new SelectList(db.Complaints, "ComplaintID", "ComplaintTitle", complaint_ComplaintDepartament.ComplaintID);
            ViewBag.ComplaintDepartamentID = new SelectList(db.ComplaintDepartaments, "ComplaintDepartamentID", "ComplaintDepartamentDescription", complaint_ComplaintDepartament.ComplaintDepartamentID);
            return View(complaint_ComplaintDepartament);
        }

        // GET: Complaint_ComplaintDepartament/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint_ComplaintDepartament complaint_ComplaintDepartament = db.Complaint_ComplaintDepartament.Find(id);
            if (complaint_ComplaintDepartament == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplaintID = new SelectList(db.Complaints, "ComplaintID", "ComplaintTitle", complaint_ComplaintDepartament.ComplaintID);
            ViewBag.ComplaintDepartamentID = new SelectList(db.ComplaintDepartaments, "ComplaintDepartamentID", "ComplaintDepartamentDescription", complaint_ComplaintDepartament.ComplaintDepartamentID);
            return View(complaint_ComplaintDepartament);
        }

        // POST: Complaint_ComplaintDepartament/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Complaint_ComplaintDepartamentID,ComplaintDepartamentID,ComplaintID")] Complaint_ComplaintDepartament complaint_ComplaintDepartament)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaint_ComplaintDepartament).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComplaintID = new SelectList(db.Complaints, "ComplaintID", "ComplaintTitle", complaint_ComplaintDepartament.ComplaintID);
            ViewBag.ComplaintDepartamentID = new SelectList(db.ComplaintDepartaments, "ComplaintDepartamentID", "ComplaintDepartamentDescription", complaint_ComplaintDepartament.ComplaintDepartamentID);
            return View(complaint_ComplaintDepartament);
        }

        // GET: Complaint_ComplaintDepartament/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint_ComplaintDepartament complaint_ComplaintDepartament = db.Complaint_ComplaintDepartament.Find(id);
            if (complaint_ComplaintDepartament == null)
            {
                return HttpNotFound();
            }
            return View(complaint_ComplaintDepartament);
        }

        // POST: Complaint_ComplaintDepartament/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Complaint_ComplaintDepartament complaint_ComplaintDepartament = db.Complaint_ComplaintDepartament.Find(id);
            db.Complaint_ComplaintDepartament.Remove(complaint_ComplaintDepartament);
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
