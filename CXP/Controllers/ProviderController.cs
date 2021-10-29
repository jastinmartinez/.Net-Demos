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
    public class ProviderController : Controller
    {
        private readonly ProviderRepository _providerRepository = new ProviderRepository();

        public ActionResult Index()
        {

            return View(_providerRepository.GetAllEntity());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Provider = _providerRepository.FindEntity(id);
            if (Provider == null)
            {
                return HttpNotFound();
            }
            return View(Provider);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Provider provider)
        {
            if (Validation.Validation.ID(provider.ProviderRNC))
            {
                if (ModelState.IsValid)
                {
                    _providerRepository.InsertEntity(provider);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                TempData["msg"] = "<script>alert('Cedula Invalida del proveedor " + provider.ProviderName + "');</script>";
            }

            return View(provider);
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Provider = _providerRepository.FindEntity(id);
            if (Provider == null)
            {
                return HttpNotFound();
            }
            return View(Provider);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Provider Provider)
        {
            if (ModelState.IsValid)
            {
                _providerRepository.UpdateEntity(Provider);

                return RedirectToAction("Index");
            }
            return View(Provider);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Provider = _providerRepository.FindEntity(id);
            if (Provider == null)
            {
                return HttpNotFound();
            }
            return View(Provider);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            //not good code need refactor for matter of time I implemented this


            var Provider = _providerRepository.FindEntity(id);

            if (new InputDocumentRepository().GetAllEntity().Where(x => x.InputDocumentProviderID == Provider.ProviderID).Count() == 0)
            {
                _providerRepository.DeleteEntity(Provider);
                return RedirectToAction("Index");
            }
            else
            {

                TempData["msg"] = "<script>alert('El Proveedor " + Provider.ProviderName + " No puede ser elimnado tiene transacciones realizadas');</script>";
            }

            return View(Provider);
        }
    }
}
