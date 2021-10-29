using CXP.Models;
using CXP.Repository.Implementation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CXP.Controllers
{
    public class AccountingSeatController : Controller
    {
        private readonly AccountingSeatRepository _accountingSeatRepository = new AccountingSeatRepository();

        public ActionResult Index()
        {
            return View(_accountingSeatRepository.GetAllEntity());
        }

        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var inputDocument = _accountingSeatRepository.FindEntity(id);
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
        public ActionResult Create(AccountingSeat acoutingSeat)
        {
            if (ModelState.IsValid)
            {

                var inputDcouments = new InputDocumentRepository().GetAllEntity().Where(x => x.InputDocumentInvoiceDate == acoutingSeat.AccountSeatDate && x.InputDocumentAccountSeatID is null).ToList();

                var accountingSeatPostDetails = new List<AccountingSeatPostDetail>();

                foreach (var item in inputDcouments)
                {
                    accountingSeatPostDetails.Add(new AccountingSeatPostDetail { monto = item.InputDocumentAmount, tipoMovimientoId = item.InputDocumentMovementType == "CR" ? 2 : 1, cuentasContablesId = 3 });
                }

                var accountingpost = new AccountingSeatPost
                {
                    descripcion = acoutingSeat.AccountSeatDescription,
                    fecha = acoutingSeat.AccountSeatDate,
                    estado = "R",
                    monedasId = 1,
                    tasaCambio = 1,
                    catalogoAuxiliarId = 2,
                    transacciones = accountingSeatPostDetails

                };

                var request = (HttpWebRequest)WebRequest.Create("https://contabilidad2021.azurewebsites.net/api/Asientos");
                request.ContentType = "application/json";
                request.Method = "POST";

                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(accountingpost);

                    streamWriter.Write(json);
                }

                var response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    using (var streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        var result = JsonConvert.DeserializeObject<AccountingSeatPost>(streamReader.ReadToEnd());

                        acoutingSeat.AccountSeatID = result.id;

                        _accountingSeatRepository.InsertEntity(acoutingSeat);

                        foreach (var item in inputDcouments)
                        {
                            item.InputDocumentAccountSeatID = result.id;
                            new InputDocumentRepository().UpdateEntity(item);
                        }

                    }
                }

                return RedirectToAction("Index");
            }

            return View(acoutingSeat);
        }
    }
}