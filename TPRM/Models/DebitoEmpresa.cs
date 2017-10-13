using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TPRM.Models
{
    public class DebitoEmpresa
    {
        [Key]
        [Column(Order = 1)]
        public int DebitoEmpresaID { get; set; }

        [ForeignKey("Empresa")]
        [Column(Order = 2)]
        public int EmpresaID { get; set; }

        [ForeignKey("Transacao")]
        [Column(Order = 3)]
        public int TransacaoID { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        [Column(Order = 4)]
        [Display(Name = "Valor da Transação")]
        public decimal ValorDebito { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Transacao Transacao { get; set; }
    }
}