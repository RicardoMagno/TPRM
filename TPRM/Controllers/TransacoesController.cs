﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TPRM.Models;

namespace TPRM.Controllers
{
    public class TransacoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transacoes
        [Authorize(Roles = "Admin, Analista, Cliente")]
        public ActionResult Index()
        {            
            var transacoes = db.Transacoes.Include(t => t.EmpresaContratante).Include(t => t.EmpresaContratada).Include(t => t.Servico).Include(t => t.StatusTransacao);
            return View(transacoes.ToList());
        }

        // GET: Transacoes/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacoes.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // GET: Transacoes/Create
        [Authorize(Roles = "Admin, Cliente")]
        public ActionResult Create()
        {
            var idUserLogged = GetUserID();

            var idUsuarioEmpresa = from b in db.UsuarioEmpresas
                        where b.ApplicationUserID.Equals(idUserLogged)
                        select b;

            Empresa empresa = db.Empresas.Find(idUsuarioEmpresa.Single().EmpresaID);
            
            ViewBag.EmpresaContratanteID = new SelectList(db.Empresas.Where(e => e.EmpresaID == empresa.EmpresaID), "EmpresaID", "RazaoSocial");
            ViewBag.EmpresaContratadaID = new SelectList(db.Empresas.Where(e => e.EmpresaID != empresa.EmpresaID), "EmpresaID", "RazaoSocial");
            ViewBag.TipoServicoID = new SelectList(db.Servicos.Where(s => s.DisponibilidadeServico == true), "ServicoID", "TipoServico");
            ViewBag.StatusTransacaoID = new SelectList(db.StatusFluxoTransacoes.Where(s => s.DescricaoStatus.Contains("Pendente")), "StatusID", "DescricaoStatus");
            return View();
        }

        // POST: Transacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Cliente")]
        public ActionResult Create([Bind(Include = "TransacaoID,EmpresaContratanteID,EmpresaContratadaID,TipoServicoID,ValorTransacao,DescricaoTransacao,StatusTransacaoID")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                InsertUserIdTransacao(transacao);
                db.Transacoes.Add(transacao);
                db.SaveChanges();

                //TODO
                var userID = GetUserID();
                var c = (from a in db.Transacoes
                         where a.UsuarioID.Equals(userID)
                         orderby a.TransacaoID descending
                         select a).Take(1);

                Transacao t = c.Single();
                DebitoClientesController.CreateDebitoClientes(t, db);

                return RedirectToAction("Index");
            }

            ViewBag.EmpresaContratanteID = new SelectList(db.Empresas, "EmpresaID", "RazaoSocial", transacao.EmpresaContratanteID);
            ViewBag.EmpresaContratadaID = new SelectList(db.Empresas, "EmpresaID", "RazaoSocial", transacao.EmpresaContratadaID);            
            ViewBag.TipoServicoID = new SelectList(db.Servicos, "ServicoID", "TipoServico", transacao.TipoServicoID);
            ViewBag.StatusTransacaoID = new SelectList(db.StatusFluxoTransacoes, "StatusID", "DescricaoStatus", transacao.StatusTransacaoID);
            return View(transacao);
        }
        
        private Transacao InsertUserIdTransacao(Transacao transacao)
        {
            transacao.UsuarioID = GetUserID();
            return transacao;
        }
        
        private string GetUserID()
        {            
            return User.Identity.GetUserId();
        }

        // GET: Transacoes/Edit/5
        [Authorize(Roles = "Admin, Analista")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacoes.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }

            Servico servico = db.Servicos.Find(transacao.TipoServicoID);
            ViewBag.ValorServico = servico.ValorServico;
            ViewBag.DescricaoServico = servico.DescricaoServico;

            ViewBag.EmpresaContratanteID = new SelectList(db.Empresas.Where(e => e.EmpresaID == transacao.EmpresaContratanteID), "EmpresaID", "RazaoSocial", transacao.EmpresaContratanteID);
            ViewBag.EmpresaContratadaID = new SelectList(db.Empresas.Where(e => e.EmpresaID == transacao.EmpresaContratadaID), "EmpresaID", "RazaoSocial", transacao.EmpresaContratadaID);            
            ViewBag.TipoServicoID = new SelectList(db.Servicos.Where(s => s.ServicoID == transacao.TipoServicoID), "ServicoID", "TipoServico", transacao.TipoServicoID);
            ViewBag.StatusTransacaoID = new SelectList(db.StatusFluxoTransacoes, "StatusID", "DescricaoStatus", transacao.StatusTransacaoID);
            return View(transacao);
        }

        // POST: Transacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Analista")]
        public ActionResult Edit([Bind(Include = "TransacaoID,EmpresaContratanteID,EmpresaContratadaID,TipoServicoID,ValorTransacao,DescricaoTransacao,StatusTransacaoID")] Transacao transacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmpresaContratanteID = new SelectList(db.Empresas, "EmpresaID", "CNPJ", transacao.EmpresaContratanteID);
            ViewBag.EmpresaContratadaID = new SelectList(db.Empresas, "EmpresaID", "CNPJ", transacao.EmpresaContratadaID);
            ViewBag.TipoServicoID = new SelectList(db.Servicos, "ServicoID", "TipoServico", transacao.TipoServicoID);
            ViewBag.StatusTransacaoID = new SelectList(db.StatusFluxoTransacoes, "StatusID", "DescricaoStatus", transacao.StatusTransacaoID);
            return View(transacao);
        }

        // GET: Transacoes/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacao transacao = db.Transacoes.Find(id);
            if (transacao == null)
            {
                return HttpNotFound();
            }
            return View(transacao);
        }

        // POST: Transacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Transacao transacao = db.Transacoes.Find(id);
            db.Transacoes.Remove(transacao);
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
