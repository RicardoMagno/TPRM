using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TPRM.Models;
using System.Web.Security;

namespace TPRM.Controllers
{
    public class DebitoClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DebitoClientes
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var listaDebitoClientes = from dc in db.DebitoClientes
                                      join e in db.Empresas on dc.EmpresaID equals e.EmpresaID
                                      join t in db.Transacoes on dc.TransacaoID equals t.TransacaoID
                                      join u in db.Users on dc.UsuarioID equals u.Id
                                      group dc by new { dc.UsuarioID, u.UserName } into a
                                      select new CustomDebitoCliente
                                      {
                                          UsuarioID = a.Key.UsuarioID,
                                          UserName = a.Key.UserName,
                                          ValorDebito = a.Sum(item => item.ValorDebito)
                                      };

            return View(listaDebitoClientes.ToList());
        }

        public static void CreateDebitoClientes(Transacao transacao, ApplicationDbContext db)
        {
            decimal ValorUnitarioTransacao = Convert.ToDecimal(ConfigurationManager.AppSettings["ValorUnitarioTransacao"].ToString());
            DebitoCliente debitoCliente = new DebitoCliente();
            debitoCliente.EmpresaID = transacao.EmpresaContratanteID;
            debitoCliente.TransacaoID = transacao.TransacaoID;
            debitoCliente.UsuarioID = transacao.UsuarioID;
            debitoCliente.ValorDebito = ValorUnitarioTransacao;

            db.DebitoClientes.Add(debitoCliente);
            db.SaveChanges();

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
