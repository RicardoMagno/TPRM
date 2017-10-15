using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TPRM.Models
{
    public class DebitoCliente
    {
        [Key]
        [Column(Order = 1)]
        public int DebitoClienteID { get; set; }

        [ForeignKey("Empresa")]
        [Column(Order = 2)]
        public int EmpresaID { get; set; }

        [ForeignKey("Transacao")]
        [Column(Order = 3)]
        public int TransacaoID { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 4)]
        public string UsuarioID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(Order = 5)]
        [Display(Name = "Valor da Transação")]
        public decimal ValorDebito { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Transacao Transacao { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }

    public class CustomDebitoCliente
    {
        public string UsuarioID { get; set; }
        public string UserName { get; set; }
        public decimal ValorDebito { get; set; }
    }
}