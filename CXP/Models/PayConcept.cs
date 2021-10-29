using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;

namespace CXP.Models
{
    [Table("PayConcept")]
    public class PayConcept
    {
        [Dapper.Contrib.Extensions.Key]
        [DisplayName("ID")]
        public long PayConceptID { get; set; }

        [DisplayName("Concepto De Pago")]
        [Required(ErrorMessage = "Digitar Concepto De Pago")]
        [MaxLength(50)]
        public String PayConceptDescription { get; set; }
        [DisplayName("Estado")]
        public bool PayConceptState { get; set; }
    }
}