using CXP.App.DAL.Repository.Implementation;
using CXP.Repository.Implementation;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace CXP.Models
{

    [Table("AccountingSeat")]
    public class AccountingSeat
    {
        [System.ComponentModel.DataAnnotations.Key]
        [ExplicitKey]
        public int AccountSeatID { get; set; }

        [DisplayName("Descripcion Asiento")]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Digitar Asiento")]
        public String AccountSeatDescription { get; set; }

        [DisplayName("Fecha Asiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        [Required(ErrorMessage = "Digitar Fecha Asiento")]
        public DateTime AccountSeatDate { get; set; }

    }
}