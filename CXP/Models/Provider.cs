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
    [Table("Provider")]
    public class Provider
    {
        [Key]
        public int ProviderID { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Digitar Nombre")]
        [StringLength(250, ErrorMessage = "Limite 250 Caracteres")]
        public string ProviderName { get; set; }

        [DisplayName("Tipo De Persona")]
        public string ProviderPersonType { get; set; }

        [DisplayName("RNC / Cedula")]
        [Required(ErrorMessage = "Digitar RNC / Cedula")]
        [StringLength(13, ErrorMessage = "Limite 13 Caracteres")]
        public string ProviderRNC { get; set; }

        [DisplayName("Balance")]
        [Required(ErrorMessage = "Digitar Balance")]
        public double ProviderBalance { get; set; }

        [DisplayName("Estado")]
        public bool ProviderState { get; set; }

        [Write(false)]
        public String GetPersonType => ProviderPersonType == "J" ? "Juridica" : "Fisica";

        public static IEnumerable<SelectListItem> GetPersonsType()
        {
            yield return new SelectListItem { Text = "Fisica", Value = "F" };
            yield return new SelectListItem { Text = "Juridica", Value = "J" };
        }

    }


}