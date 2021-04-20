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
    public class ComplaintJobHistoriesController : Controller
    {
        private ComplaintCinemaEntities db = new ComplaintCinemaEntities();

        // GET: ComplaintJobHistories
        public ActionResult Index()
        {
            var complaintJobHistories = db.ComplaintJobHistories.Include(c => c.Complaint).Include(c => c.AspNetUser);
            return View(complaintJobHistories.ToList());
        }

        // GET: ComplaintJobHistories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintJobHistory complaintJobHistory = db.ComplaintJobHistories.Find(id);
            if (complaintJobHistory == null)
            {
                return HttpNotFound();
            }
            return View(complaintJobHistory);
        }

        // GET: ComplaintJobHistories/Create
        public ActionResult Create()
        {
            ViewBag.ComplaintID = new SelectList(db.Complaints, "ComplaintID", "ComplaintTitle");
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: ComplaintJobHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplaintJobHistoryID,ComplaintID,ComplaintJobHistoryDescription,ComplaintJobHistoryDate,UserID")] ComplaintJobHistory complaintJobHistory)
        {
            if (ModelState.IsValid)
            {
                complaintJobHistory.ComplaintJobHistoryID = Guid.NewGuid();
                db.ComplaintJobHistories.Add(complaintJobHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComplaintID = new SelectList(db.Complaints, "ComplaintID", "ComplaintTitle", complaintJobHistory.ComplaintID);
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", complaintJobHistory.UserID);
            return View(complaintJobHistory);
        }

        // GET: ComplaintJobHistories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintJobHistory complaintJobHistory = db.ComplaintJobHistories.Find(id);
            if (complaintJobHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplaintID = new SelectList(db.Complaints, "ComplaintID", "ComplaintTitle", complaintJobHistory.ComplaintID);
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", complaintJobHistory.UserID);
            return View(complaintJobHistory);
        }

        // POST: ComplaintJobHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplaintJobHistoryID,ComplaintID,ComplaintJobHistoryDescription,ComplaintJobHistoryDate,UserID")] ComplaintJobHistory complaintJobHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaintJobHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComplaintID = new SelectList(db.Complaints, "ComplaintID", "ComplaintTitle", complaintJobHistory.ComplaintID);
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", complaintJobHistory.UserID);
            return View(complaintJobHistory);
        }

        // GET: ComplaintJobHistories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintJobHistory complaintJobHistory = db.ComplaintJobHistories.Find(id);
            if (complaintJobHistory == null)
            {
                return HttpNotFound();
            }
            return View(complaintJobHistory);
        }

        // POST: ComplaintJobHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ComplaintJobHistory complaintJobHistory = db.ComplaintJobHistories.Find(id);
            db.ComplaintJobHistories.Remove(complaintJobHistory);
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
