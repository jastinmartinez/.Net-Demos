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
    public class ComplaintProductsController : Controller
    {
        private ComplaintCinemaEntities db = new ComplaintCinemaEntities();

        // GET: ComplaintProducts
        public ActionResult Index()
        {
            var complaintProducts = db.ComplaintProducts.Include(c => c.ComplaintCategory);
            return View(complaintProducts.ToList());
        }

        // GET: ComplaintProducts/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintProduct complaintProduct = db.ComplaintProducts.Find(id);
            if (complaintProduct == null)
            {
                return HttpNotFound();
            }
            return View(complaintProduct);
        }

        // GET: ComplaintProducts/Create
        public ActionResult Create()
        {
            ViewBag.ComplaintCategoryID = new SelectList(db.ComplaintCategories, "ComplaintCategoryID", "ComplaintCategoryDescription");
            return View();
        }

        // POST: ComplaintProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplaintProductID,ComplaintProductDescription,ComplaintCategoryID,ComplaintProductIsActive")] ComplaintProduct complaintProduct)
        {
            if (ModelState.IsValid)
            {
                complaintProduct.ComplaintProductID = Guid.NewGuid();
                db.ComplaintProducts.Add(complaintProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComplaintCategoryID = new SelectList(db.ComplaintCategories, "ComplaintCategoryID", "ComplaintCategoryDescription", complaintProduct.ComplaintCategoryID);
            return View(complaintProduct);
        }

        // GET: ComplaintProducts/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintProduct complaintProduct = db.ComplaintProducts.Find(id);
            if (complaintProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplaintCategoryID = new SelectList(db.ComplaintCategories, "ComplaintCategoryID", "ComplaintCategoryDescription", complaintProduct.ComplaintCategoryID);
            return View(complaintProduct);
        }

        // POST: ComplaintProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplaintProductID,ComplaintProductDescription,ComplaintCategoryID,ComplaintProductIsActive")] ComplaintProduct complaintProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complaintProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComplaintCategoryID = new SelectList(db.ComplaintCategories, "ComplaintCategoryID", "ComplaintCategoryDescription", complaintProduct.ComplaintCategoryID);
            return View(complaintProduct);
        }

        // GET: ComplaintProducts/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplaintProduct complaintProduct = db.ComplaintProducts.Find(id);
            if (complaintProduct == null)
            {
                return HttpNotFound();
            }
            return View(complaintProduct);
        }

        // POST: ComplaintProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ComplaintProduct complaintProduct = db.ComplaintProducts.Find(id);
            db.ComplaintProducts.Remove(complaintProduct);
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
