using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TPRM.Models
{
    [Table("StatusFluxoTransacao")]
    public class StatusFluxoTransacao
    {
        [Key]
        public int StatusID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Descrição do Status")]
        public string DescricaoStatus { get; set; }        

    }
}