using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPRM.Models;

namespace TPRM.Controllers
{
    public class UsuarioEmpresasController : Controller
    {
        
        public static void Create(UsuarioEmpresa usuarioEmpresa, ApplicationDbContext db)
        {
            db.UsuarioEmpresas.Add(usuarioEmpresa);
            db.SaveChanges();  
        }

        public void Edit(UsuarioEmpresa usuarioEmpresa, ApplicationDbContext db)
        {
            db.Entry(usuarioEmpresa).State = EntityState.Modified;
            db.SaveChanges();            
        }

        public void DeleteConfirmed(int id, ApplicationDbContext db)
        {
            UsuarioEmpresa usuarioEmpresa = db.UsuarioEmpresas.Find(id);
            db.UsuarioEmpresas.Remove(usuarioEmpresa);
            db.SaveChanges();
        }
        
    }
}
