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
    public class InputDocumentStateController : Controller
    {
        private readonly InputDocumentStateRepository _inputDocumentStateRepository = new InputDocumentStateRepository();

        public ActionResult Index()
        {
            return View(_inputDocumentStateRepository.GetAllEntity());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inputDocumentState = _inputDocumentStateRepository.FindEntity(id);
            if (inputDocumentState == null)
            {
                return HttpNotFound();
            }
            return View(inputDocumentState);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InputDocumentState inputDocumentState)
        {
            if (ModelState.IsValid)
            {

                _inputDocumentStateRepository.InsertEntity(inputDocumentState);

                return RedirectToAction("Index");
            }

            return View(inputDocumentState);
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inputDocumentState = _inputDocumentStateRepository.FindEntity(id);
            if (inputDocumentState == null)
            {
                return HttpNotFound();
            }
            return View(inputDocumentState);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InputDocumentState inputDocumentState)
        {
            if (ModelState.IsValid)
            {
                _inputDocumentStateRepository.UpdateEntity(inputDocumentState);

                return RedirectToAction("Index");
            }
            return View(inputDocumentState);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inputDocumentState = _inputDocumentStateRepository.FindEntity(id);
            if (inputDocumentState == null)
            {
                return HttpNotFound();
            }
            return View(inputDocumentState);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var inputDocumentState = _inputDocumentStateRepository.FindEntity(id);

            if (new InputDocumentRepository().GetAllEntity().Where(x => x.InputDocumentStateID == inputDocumentState.InputDocumentStateID).Count() == 0)
            {

                _inputDocumentStateRepository.DeleteEntity(inputDocumentState);

                return RedirectToAction("Index");
            }
            else
            {

                TempData["msg"] = "<script>alert('El Estado de documento de entrada " + inputDocumentState.InputDocumentDescription + " No puede ser elimnado tiene transacciones realizadas');</script>";
            }
            return View(inputDocumentState);
        }
    }
}