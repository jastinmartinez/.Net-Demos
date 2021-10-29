using CXP.Models;
using CXP.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CXP.Controllers
{
    public class InputDocumentController : Controller
    {
        private readonly InputDocumentRepository _inputDocumentRepository = new InputDocumentRepository();

        public ActionResult Index()
        {
            return View(_inputDocumentRepository.GetAllEntity());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inputDocument = _inputDocumentRepository.FindEntity(id);
            if (inputDocument == null)
            {
                return HttpNotFound();
            }
            return View(inputDocument);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InputDocument inputDocument)
        {
            if (ModelState.IsValid)
            {
                var providerRepository = new ProviderRepository();

                var provider = providerRepository.GetAllEntity().Where(x => x.ProviderID == inputDocument.InputDocumentProviderID).FirstOrDefault();

                provider.ProviderBalance += inputDocument.InputDocumentAmount;

                providerRepository.UpdateEntity(provider);

                _inputDocumentRepository.InsertEntity(inputDocument);

                return RedirectToAction("Index");
            }

            return View(inputDocument);
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inputDocument = _inputDocumentRepository.FindEntity(id);
            if (inputDocument == null)
            {
                return HttpNotFound();
            }
            return View(inputDocument);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InputDocument inputDocument)
        {
            if (ModelState.IsValid)
            {
                _inputDocumentRepository.UpdateEntity(inputDocument);

                return RedirectToAction("Index");
            }
            return View(inputDocument);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inputDocument = _inputDocumentRepository.FindEntity(id);
            if (inputDocument == null)
            {
                return HttpNotFound();
            }
            return View(inputDocument);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {

            var inputDocument = _inputDocumentRepository.FindEntity(id);
            _inputDocumentRepository.DeleteEntity(inputDocument);

            return RedirectToAction("Index");
        }
    }
}
