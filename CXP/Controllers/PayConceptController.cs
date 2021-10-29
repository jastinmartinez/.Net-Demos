using CXP.App.DAL.Repository.Implementation;
using CXP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CXP.Controllers
{
    public class PayConceptController : Controller
    {
        private readonly PayConcepRepository _payConceptRepository = new PayConcepRepository();


        public ActionResult Index()
        {
            return View(_payConceptRepository.GetAllEntity());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var payConcept = _payConceptRepository.FindEntity(id);
            if (payConcept == null)
            {
                return HttpNotFound();
            }
            return View(payConcept);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PayConcept payConcept)
        {
            if (ModelState.IsValid)
            {

                _payConceptRepository.InsertEntity(payConcept);

                return RedirectToAction("Index");
            }

            return View(payConcept);
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var payConcept = _payConceptRepository.FindEntity(id);
            if (payConcept == null)
            {
                return HttpNotFound();
            }
            return View(payConcept);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PayConcept payConcept)
        {
            if (ModelState.IsValid)
            {
                _payConceptRepository.UpdateEntity(payConcept);

                return RedirectToAction("Index");
            }
            return View(payConcept);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var payConcept = _payConceptRepository.FindEntity(id);
            if (payConcept == null)
            {
                return HttpNotFound();
            }
            return View(payConcept);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {

            var payConcept = _payConceptRepository.FindEntity(id);
            _payConceptRepository.DeleteEntity(payConcept);

            return RedirectToAction("Index");
        }

    }
}