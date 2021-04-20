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
    public class ComplaintStatusController : Controller
    {
        private ComplaintCinemaEntities db = new ComplaintCinemaEntities();

        // GET: ComplaintStatus
        public ActionResult Index()
        {
            return View(db.ComplaintStatus.ToList());
        }

        // GET: ComplaintStatus/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintStatu complaintStatu = db.ComplaintStatus.Find(id);
            if (complaintStatu == null)
            {
                return HttpNotFound();
            }
            return View(complaintStatu);
        }

        // GET: ComplaintStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplaintStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplaintStatusID,ComplaintStatusDescription,ComplaintStatusIsActive")] ComplaintStatu complaintStatu)
        {
            if (ModelState.IsValid)
            {
                complaintStatu.ComplaintStatusID = Guid.NewGuid();
                db.ComplaintStatus.Add(complaintStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complaintStatu);
        }

        // GET: ComplaintStatus/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintStatu complaintStatu = db.ComplaintStatus.Find(id);
            if (complaintStatu == null)
            {
                return HttpNotFound();
            }
            return View(complaintStatu);
        }

        // POST: ComplaintStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplaintStatusID,ComplaintStatusDescription,ComplaintStatusIsActive")] ComplaintStatu complaintStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaintStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complaintStatu);
        }

        // GET: ComplaintStatus/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintStatu complaintStatu = db.ComplaintStatus.Find(id);
            if (complaintStatu == null)
            {
                return HttpNotFound();
            }
            return View(complaintStatu);
        }

        // POST: ComplaintStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ComplaintStatu complaintStatu = db.ComplaintStatus.Find(id);
            db.ComplaintStatus.Remove(complaintStatu);
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
