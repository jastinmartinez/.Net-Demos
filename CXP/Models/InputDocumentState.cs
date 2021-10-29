

using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = Dapper.Contrib.Extensions.KeyAttribute;
using TableAttribute = Dapper.Contrib.Extensions.TableAttribute;

namespace CXP.Models
{
    [Table("InputDocumentState")]
    public class InputDocumentState
    {
        [Key]
        [System.ComponentModel.DisplayName("ID")]
        public int InputDocumentStateID { get; set; }

        [System.ComponentModel.DisplayName("Tipo De Documento De Entrada")]
        [Required(ErrorMessage = "Digitar Tipo De Documento De Entrada")]
        [StringLength(50, ErrorMessage = "Limite 50 Caracteres")]
        public string InputDocumentDescription { get; set; }

    }
}