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

namespace TPRM.Controllers
{
    public class DebitoEmpresasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DebitoEmpresas
        public ActionResult Index()
        {
            var debitoEmpresas = db.DebitoEmpresas.Include(d => d.Empresa).Include(d => d.Transacao);
            return View(debitoEmpresas.ToList());
        }

        // GET: DebitoEmpresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitoEmpresa debitoEmpresa = db.DebitoEmpresas.Find(id);
            if (debitoEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(debitoEmpresa);
        }

        // GET: DebitoEmpresas/Create
        public ActionResult Create()
        {
            ViewBag.EmpresaID = new SelectList(db.Empresas, "EmpresaID", "CNPJ");
            ViewBag.TransacaoID = new SelectList(db.Transacoes, "TransacaoID", "DescricaoTransacao");
            return View();
        }

        // POST: DebitoEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DebitoEmpresaID,EmpresaID,TransacaoID,ValorDebito")] DebitoEmpresa debitoEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.DebitoEmpresas.Add(debitoEmpresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmpresaID = new SelectList(db.Empresas, "EmpresaID", "CNPJ", debitoEmpresa.EmpresaID);
            ViewBag.TransacaoID = new SelectList(db.Transacoes, "TransacaoID", "DescricaoTransacao", debitoEmpresa.TransacaoID);
            return View(debitoEmpresa);
        }

        public static void CreateDebitoEmpresa(Transacao transacao, ApplicationDbContext db)
        {
            decimal ValorUnitarioTransacao = Convert.ToDecimal(ConfigurationManager.AppSettings["ValorUnitarioTransacao"].ToString());
            DebitoEmpresa debitoEmpresa = new DebitoEmpresa();
            debitoEmpresa.EmpresaID = transacao.EmpresaContratanteID;
            debitoEmpresa.TransacaoID = transacao.TransacaoID;
            debitoEmpresa.ValorDebito = ValorUnitarioTransacao;

            db.DebitoEmpresas.Add(debitoEmpresa);
            db.SaveChanges();          

        }

        // GET: DebitoEmpresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitoEmpresa debitoEmpresa = db.DebitoEmpresas.Find(id);
            if (debitoEmpresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmpresaID = new SelectList(db.Empresas, "EmpresaID", "CNPJ", debitoEmpresa.EmpresaID);
            ViewBag.TransacaoID = new SelectList(db.Transacoes, "TransacaoID", "DescricaoTransacao", debitoEmpresa.TransacaoID);
            return View(debitoEmpresa);
        }

        // POST: DebitoEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DebitoEmpresaID,EmpresaID,TransacaoID,ValorDebito")] DebitoEmpresa debitoEmpresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(debitoEmpresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaID = new SelectList(db.Empresas, "EmpresaID", "CNPJ", debitoEmpresa.EmpresaID);
            ViewBag.TransacaoID = new SelectList(db.Transacoes, "TransacaoID", "DescricaoTransacao", debitoEmpresa.TransacaoID);
            return View(debitoEmpresa);
        }

        // GET: DebitoEmpresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DebitoEmpresa debitoEmpresa = db.DebitoEmpresas.Find(id);
            if (debitoEmpresa == null)
            {
                return HttpNotFound();
            }
            return View(debitoEmpresa);
        }

        // POST: DebitoEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DebitoEmpresa debitoEmpresa = db.DebitoEmpresas.Find(id);
            db.DebitoEmpresas.Remove(debitoEmpresa);
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
