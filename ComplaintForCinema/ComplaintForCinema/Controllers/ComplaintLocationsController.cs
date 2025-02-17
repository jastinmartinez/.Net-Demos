﻿using System;
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
    public class ComplaintLocationsController : Controller
    {
        private ComplaintCinemaEntities db = new ComplaintCinemaEntities();

        // GET: ComplaintLocations
        public ActionResult Index()
        {
            return View(db.ComplaintLocations.ToList());
        }

        // GET: ComplaintLocations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintLocation complaintLocation = db.ComplaintLocations.Find(id);
            if (complaintLocation == null)
            {
                return HttpNotFound();
            }
            return View(complaintLocation);
        }

        // GET: ComplaintLocations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplaintLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplaintLocationID,ComplaintLocationDescription,ComplaintLocationIsActive")] ComplaintLocation complaintLocation)
        {
            if (ModelState.IsValid)
            {
                complaintLocation.ComplaintLocationID = Guid.NewGuid();
                db.ComplaintLocations.Add(complaintLocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complaintLocation);
        }

        // GET: ComplaintLocations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintLocation complaintLocation = db.ComplaintLocations.Find(id);
            if (complaintLocation == null)
            {
                return HttpNotFound();
            }
            return View(complaintLocation);
        }

        // POST: ComplaintLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplaintLocationID,ComplaintLocationDescription,ComplaintLocationIsActive")] ComplaintLocation complaintLocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaintLocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complaintLocation);
        }

        // GET: ComplaintLocations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintLocation complaintLocation = db.ComplaintLocations.Find(id);
            if (complaintLocation == null)
            {
                return HttpNotFound();
            }
            return View(complaintLocation);
        }

        // POST: ComplaintLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ComplaintLocation complaintLocation = db.ComplaintLocations.Find(id);
            db.ComplaintLocations.Remove(complaintLocation);
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
