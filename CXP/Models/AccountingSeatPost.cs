using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CXP.Models
{
    public class AccountingSeatPost
    {
        public int id { get; set; }

        public String descripcion { get; set; }
        public int catalogoAuxiliarId { get; set; }
        public DateTime fecha { get; set; }
        public String estado { get; set; }
        public int monedasId { get; set; }
        public int tasaCambio { get; set; }
        public List<AccountingSeatPostDetail> transacciones { get; set; }
    }
}

public class AccountingSeatPostDetail
{
    public int cuentasContablesId { get; set; }
    public int tipoMovimientoId { get; set; }
    public long monto { get; set; }
}


