using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TPRM.Models
{
    public class UsuarioEmpresa
    {
        [Key]
        [Column(Order = 1)]
        public int UsuarioEmpresaID { get; set; }

        [ForeignKey("ApplicationUser")]
        [Column(Order = 2)]
        public string ApplicationUserID { get; set; }

        [ForeignKey("Empresa")]
        [Column(Order = 3)]
        public int EmpresaID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Empresa Empresa { get; set; }

    }
}