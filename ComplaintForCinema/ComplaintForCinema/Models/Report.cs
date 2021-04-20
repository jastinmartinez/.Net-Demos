using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ComplaintForCinema.Models
{
    public class Report
    {
        [Display(Name = "ID")]
        public Guid ComplaintID { get; set; }
        [Display(Name = "Tipo")]
        public String ComplaintTypeDescription { get; set; }
        [Display(Name = "Titulo")]
        public String ComplaintTitle { get; set; }
        [Display(Name = "Descripcion")]
        public String ComplaintDescription { get; set; }
        [Display(Name = "Usuario")]
        public String Email { get; set; }
        [Display(Name = "Producto")]
        public String ComplaintProductDescription { get; set; }
        [Display(Name = "Fecha")]
        public DateTime ComplaintDate { get; set; }
        [Display(Name = "Estado")]
        public String ComplaintStatusDescription { get; set; }
        [Display(Name = "Ubicacion")]
        public String ComplaintLocationDescription { get; set; }
        [Display(Name = "Comentarios")]
        public String ComplaintCommets { get; set; }

    }
}