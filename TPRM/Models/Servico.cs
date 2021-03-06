﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TPRM.Models
{
    [Table("Servicos")]
    public class Servico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServicoID { get; set; }

        [Required]        
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Tipo de Serviço")]
        public string TipoServico { get; set; }

        [Required]
        [Display(Name = "Valor do Serviço")]
        public decimal ValorServico { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 10)]
        [Display(Name = "Breve Descrição do Serviço")]
        public string DescricaoServico { get; set; }

        [Display(Name = "Disponível?")]
        public bool DisponibilidadeServico { get; set; }
    }
}
