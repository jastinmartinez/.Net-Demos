using CXP.App.DAL.Repository.Implementation;
using CXP.Repository.Implementation;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;

namespace CXP.Models
{
    [Table("InputDocument")]
    public class InputDocument
    {
        [Key]
        public long InputDocumentID { get; set; }

        [DisplayName("No. Factura")]
        [Required(ErrorMessage = "Digitar No. Factura")]
        public string InputDocumentInvoiceNumber { get; set; }

        [DisplayName("Fecha Factura")]
        [Required(ErrorMessage = "Digitar Fecha Factura")]
        public DateTime InputDocumentInvoiceDate { get; set; }

        [DisplayName("Cantidad")]
        [Required(ErrorMessage = "Digitar Cantidad")]
        public long InputDocumentAmount { get; set; }

        [DisplayName("Fecha")]
        public DateTime InputDocumentDate { get; set; }

        [DisplayName("Proveedor")]
        [Required(ErrorMessage = "Seleccionar Proveedor")]
        public int InputDocumentProviderID { get; set; }

        [DisplayName("Concepto De Pago")]
        [Required(ErrorMessage = "Seleccionar Concepto De Pago")]
        public int InputDocumentPayConceptID { get; set; }

        [DisplayName("Tipo De Movimineto")]
        [Required(ErrorMessage = "Seleccionar Concepto De Pago")]
        public String InputDocumentMovementType { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Seleccionar Estado")]
        public int InputDocumentStateID { get; set; }

        [DisplayName("Contabilizado")]
        public int? InputDocumentAccountSeatID { get; set; }

        //Very Low Performance need refactor for matter of time I implemented this
        [Write(false)]
        public String GetProvider => new ProviderRepository().GetAllEntity().First(x => x.ProviderID == InputDocumentProviderID).ProviderName;

        //Very Low Performance need refactor for matter of time I implemented this
        [Write(false)]
        public String GetInputDocumentState => new InputDocumentStateRepository().GetAllEntity().First(x => x.InputDocumentStateID == InputDocumentStateID).InputDocumentDescription;

        //Very Low Performance need refactor for matter of time I implemented this
        [Write(false)]
        public string GetPayConcept => new PayConcepRepository().GetAllEntity().First(x => x.PayConceptID == InputDocumentPayConceptID).PayConceptDescription;

        public static IEnumerable<SelectListItem> GetProviders(MastersStatus mastersStatus)
        {
            var providerRepo = mastersStatus == MastersStatus.All ? new ProviderRepository().GetAllEntity() : new ProviderRepository().GetAllEntity().Where(x => x.ProviderState).ToList();

            foreach (var item in providerRepo)
            {
                yield return new SelectListItem { Text = item.ProviderName, Value = item.ProviderID.ToString() };
            }
        }

        public static IEnumerable<SelectListItem> GetInputDocumentStates()
        {
            foreach (var item in new InputDocumentStateRepository().GetAllEntity())
            {
                yield return new SelectListItem { Text = item.InputDocumentDescription, Value = item.InputDocumentStateID.ToString() };
            }
        }

        public static IEnumerable<SelectListItem> GetPayConcepts(MastersStatus mastersStatus)
        {
            var payConceptRepo = mastersStatus == MastersStatus.All ? new PayConcepRepository().GetAllEntity() : new PayConcepRepository().GetAllEntity().Where(x => x.PayConceptState).ToList();

            foreach (var item in payConceptRepo)
            {
                yield return new SelectListItem { Text = item.PayConceptDescription, Value = item.PayConceptID.ToString() };
            }
        }

        public static IEnumerable<SelectListItem> GetMovemenType()
        {
            var movmentType = new List<String> { "CR", "DB" };

            foreach (var item in movmentType)
            {
                yield return new SelectListItem { Text = item, Value = item };
            }
        }
    }

    public enum MastersStatus
    {
        All,
        Availables
    }

}