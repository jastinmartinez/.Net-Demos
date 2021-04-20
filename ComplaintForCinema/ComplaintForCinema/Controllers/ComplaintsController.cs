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
    public class ComplaintsController : Controller
    {
        private ComplaintCinemaEntities db = new ComplaintCinemaEntities();

        // GET: Complaints
        public ActionResult Index()
        {
            var complaints = db.Complaints.Include(c => c.AspNetUser).Include(c => c.ComplaintLocation).Include(c => c.ComplaintProduct).Include(c => c.ComplaintStatu).Include(c => c.ComplaintType);
            return View(complaints.ToList());
        }

        // GET: Complaints/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // GET: Complaints/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.ComplaintLocationID = new SelectList(db.ComplaintLocations, "ComplaintLocationID", "ComplaintLocationDescription");
            ViewBag.ComplaintProductID = new SelectList(db.ComplaintProducts, "ComplaintProductID", "ComplaintProductDescription");
            ViewBag.ComplaintStatusID = new SelectList(db.ComplaintStatus, "ComplaintStatusID", "ComplaintStatusDescription");
            ViewBag.ComplaintTypeID = new SelectList(db.ComplaintTypes, "ComplaintTypeID", "ComplaintTypeDescription");
            return View();
        }

        // POST: Complaints/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplaintID,ComplaintTypeID,ComplaintTitle,ComplaintDescription,UserID,ComplaintProductID,ComplaintDate,ComplaintStatusID,ComplaintLocationID,ComplaintCommets")] Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                complaint.ComplaintID = Guid.NewGuid();
                db.Complaints.Add(complaint);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", complaint.UserID);
            ViewBag.ComplaintLocationID = new SelectList(db.ComplaintLocations, "ComplaintLocationID", "ComplaintLocationDescription", complaint.ComplaintLocationID);
            ViewBag.ComplaintProductID = new SelectList(db.ComplaintProducts, "ComplaintProductID", "ComplaintProductDescription", complaint.ComplaintProductID);
            ViewBag.ComplaintStatusID = new SelectList(db.ComplaintStatus, "ComplaintStatusID", "ComplaintStatusDescription", complaint.ComplaintStatusID);
            ViewBag.ComplaintTypeID = new SelectList(db.ComplaintTypes, "ComplaintTypeID", "ComplaintTypeDescription", complaint.ComplaintTypeID);
            return View(complaint);
        }

        // GET: Complaints/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", complaint.UserID);
            ViewBag.ComplaintLocationID = new SelectList(db.ComplaintLocations, "ComplaintLocationID", "ComplaintLocationDescription", complaint.ComplaintLocationID);
            ViewBag.ComplaintProductID = new SelectList(db.ComplaintProducts, "ComplaintProductID", "ComplaintProductDescription", complaint.ComplaintProductID);
            ViewBag.ComplaintStatusID = new SelectList(db.ComplaintStatus, "ComplaintStatusID", "ComplaintStatusDescription", complaint.ComplaintStatusID);
            ViewBag.ComplaintTypeID = new SelectList(db.ComplaintTypes, "ComplaintTypeID", "ComplaintTypeDescription", complaint.ComplaintTypeID);
            return View(complaint);
        }

        // POST: Complaints/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplaintID,ComplaintTypeID,ComplaintTitle,ComplaintDescription,UserID,ComplaintProductID,ComplaintDate,ComplaintStatusID,ComplaintLocationID,ComplaintCommets")] Complaint complaint)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaint).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AspNetUsers, "Id", "Email", complaint.UserID);
            ViewBag.ComplaintLocationID = new SelectList(db.ComplaintLocations, "ComplaintLocationID", "ComplaintLocationDescription", complaint.ComplaintLocationID);
            ViewBag.ComplaintProductID = new SelectList(db.ComplaintProducts, "ComplaintProductID", "ComplaintProductDescription", complaint.ComplaintProductID);
            ViewBag.ComplaintStatusID = new SelectList(db.ComplaintStatus, "ComplaintStatusID", "ComplaintStatusDescription", complaint.ComplaintStatusID);
            ViewBag.ComplaintTypeID = new SelectList(db.ComplaintTypes, "ComplaintTypeID", "ComplaintTypeDescription", complaint.ComplaintTypeID);
            return View(complaint);
        }

        // GET: Complaints/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complaint complaint = db.Complaints.Find(id);
            if (complaint == null)
            {
                return HttpNotFound();
            }
            return View(complaint);
        }

        // POST: Complaints/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Complaint complaint = db.Complaints.Find(id);
            db.Complaints.Remove(complaint);
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
