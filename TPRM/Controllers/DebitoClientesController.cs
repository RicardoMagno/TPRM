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
        public ActionResult Index()
        {
            var debitoClientes = db.DebitoClientes.Include(d => d.Empresa).Include(d => d.Transacao).Include(d => d.ApplicationUser);
            return View(debitoClientes.ToList());
        }

        // GET: DebitoClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitoCliente debitoCliente = db.DebitoClientes.Find(id);
            if (debitoCliente == null)
            {
                return HttpNotFound();
            }
            return View(debitoCliente);
        }

        // GET: DebitoClientes/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaID = new SelectList(db.Empresas, "EmpresaID", "CNPJ");
            ViewBag.TransacaoID = new SelectList(db.Transacoes, "TransacaoID", "DescricaoTransacao");
            ViewBag.UsuarioID = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: DebitoClientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DebitoClienteID,EmpresaID,TransacaoID,UsuarioID,ValorDebito")] DebitoCliente debitoCliente)
        {
            if (ModelState.IsValid)
            {
                db.DebitoClientes.Add(debitoCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaID = new SelectList(db.Empresas, "EmpresaID", "CNPJ", debitoCliente.EmpresaID);
            ViewBag.TransacaoID = new SelectList(db.Transacoes, "TransacaoID", "DescricaoTransacao", debitoCliente.TransacaoID);
            ViewBag.UsuarioID = new SelectList(db.Users, "Id", "Email", debitoCliente.UsuarioID);
            return View(debitoCliente);            
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

        // GET: DebitoClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitoCliente debitoCliente = db.DebitoClientes.Find(id);
            if (debitoCliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaID = new SelectList(db.Empresas, "EmpresaID", "CNPJ", debitoCliente.EmpresaID);
            ViewBag.TransacaoID = new SelectList(db.Transacoes, "TransacaoID", "DescricaoTransacao", debitoCliente.TransacaoID);
            ViewBag.UsuarioID = new SelectList(db.Users, "Id", "Email", debitoCliente.UsuarioID);
            return View(debitoCliente);
        }

        // POST: DebitoClientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DebitoClienteID,EmpresaID,TransacaoID,UsuarioID,ValorDebito")] DebitoCliente debitoCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(debitoCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaID = new SelectList(db.Empresas, "EmpresaID", "CNPJ", debitoCliente.EmpresaID);
            ViewBag.TransacaoID = new SelectList(db.Transacoes, "TransacaoID", "DescricaoTransacao", debitoCliente.TransacaoID);
            ViewBag.UsuarioID = new SelectList(db.Users, "Id", "Email", debitoCliente.UsuarioID);
            return View(debitoCliente);
        }

        // GET: DebitoClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitoCliente debitoCliente = db.DebitoClientes.Find(id);
            if (debitoCliente == null)
            {
                return HttpNotFound();
            }
            return View(debitoCliente);
        }

        // POST: DebitoClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DebitoCliente debitoCliente = db.DebitoClientes.Find(id);
            db.DebitoClientes.Remove(debitoCliente);
            db.SaveChanges();
            return RedirectToAction("Index");
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
