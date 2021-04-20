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
    public class ComplaintCategoriesController : Controller
    {
        private ComplaintCinemaEntities db = new ComplaintCinemaEntities();

        // GET: ComplaintCategories
        public ActionResult Index()
        {
            return View(db.ComplaintCategories.ToList());
        }

        // GET: ComplaintCategories/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintCategory complaintCategory = db.ComplaintCategories.Find(id);
            if (complaintCategory == null)
            {
                return HttpNotFound();
            }
            return View(complaintCategory);
        }

        // GET: ComplaintCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComplaintCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplaintCategoryID,ComplaintCategoryDescription,ComplaintCategoryIsActive")] ComplaintCategory complaintCategory)
        {
            if (ModelState.IsValid)
            {
                complaintCategory.ComplaintCategoryID = Guid.NewGuid();
                db.ComplaintCategories.Add(complaintCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complaintCategory);
        }

        // GET: ComplaintCategories/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintCategory complaintCategory = db.ComplaintCategories.Find(id);
            if (complaintCategory == null)
            {
                return HttpNotFound();
            }
            return View(complaintCategory);
        }

        // POST: ComplaintCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplaintCategoryID,ComplaintCategoryDescription,ComplaintCategoryIsActive")] ComplaintCategory complaintCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaintCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complaintCategory);
        }

        // GET: ComplaintCategories/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintCategory complaintCategory = db.ComplaintCategories.Find(id);
            if (complaintCategory == null)
            {
                return HttpNotFound();
            }
            return View(complaintCategory);
        }

        // POST: ComplaintCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ComplaintCategory complaintCategory = db.ComplaintCategories.Find(id);
            db.ComplaintCategories.Remove(complaintCategory);
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
