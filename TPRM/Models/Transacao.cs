using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TPRM.Models
{
    [Table("Transacoes")]
    public class Transacao
    {
        [Key]
        public int TransacaoID { get; set; }

        [ForeignKey("EmpresaContratante")]
        [Column(Order = 1)]
        [Display(Name = "Empresa Contratante")]
        public int EmpresaContratanteID { get; set; }

        [ForeignKey("EmpresaContratada")]
        [Column(Order = 2)]
        [Required]
        [Display(Name = "Empresa Contratada")]
        public int EmpresaContratadaID { get; set; }

        [ForeignKey("Servico")]
        [Column(Order = 3)]
        [Required]
        [Display(Name = "Tipo Serviço")]
        public int TipoServicoID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor da Transação")]
        public decimal ValorTransacao { get; set; }

        [Required]
        [Display(Name = "Descrição da Transação")]
        [StringLength(50, MinimumLength = 3)]
        public string DescricaoTransacao { get; set; }

        [ForeignKey("StatusTransacao")]
        [Display(Name = "Status Transação")]
        [Required]
        public int StatusTransacaoID { get; set; }

        public virtual StatusFluxoTransacao StatusTransacao { get; set; }
        public virtual Empresa EmpresaContratante { get; set; }
        public virtual Empresa EmpresaContratada { get; set; }
        public virtual Servico Servico { get; set; }

    }
}