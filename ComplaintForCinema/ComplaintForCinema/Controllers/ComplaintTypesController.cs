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
    public class ComplaintTypesController : Controller
    {
        private ComplaintCinemaEntities db = new ComplaintCinemaEntities();

        // GET: ComplaintTypes
        public ActionResult Index()
        {
            return View(db.ComplaintTypes.ToList());
        }

        // GET: ComplaintTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintType complaintType = db.ComplaintTypes.Find(id);
            if (complaintType == null)
            {
                return HttpNotFound();
            }
            return View(complaintType);
        }

        // GET: ComplaintTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplaintTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplaintTypeID,ComplaintTypeDescription,ComplaintTypeIsActive")] ComplaintType complaintType)
        {
            if (ModelState.IsValid)
            {
                complaintType.ComplaintTypeID = Guid.NewGuid();
                db.ComplaintTypes.Add(complaintType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complaintType);
        }

        // GET: ComplaintTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintType complaintType = db.ComplaintTypes.Find(id);
            if (complaintType == null)
            {
                return HttpNotFound();
            }
            return View(complaintType);
        }

        // POST: ComplaintTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplaintTypeID,ComplaintTypeDescription,ComplaintTypeIsActive")] ComplaintType complaintType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaintType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complaintType);
        }

        // GET: ComplaintTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintType complaintType = db.ComplaintTypes.Find(id);
            if (complaintType == null)
            {
                return HttpNotFound();
            }
            return View(complaintType);
        }

        // POST: ComplaintTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ComplaintType complaintType = db.ComplaintTypes.Find(id);
            db.ComplaintTypes.Remove(complaintType);
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
