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
    public class StatusFluxoTransacoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StatusFluxoTransacoes
        public ActionResult Index()
        {
            return View(db.StatusFluxoTransacoes.ToList());
        }

        // GET: StatusFluxoTransacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusFluxoTransacao statusFluxoTransacao = db.StatusFluxoTransacoes.Find(id);
            if (statusFluxoTransacao == null)
            {
                return HttpNotFound();
            }
            return View(statusFluxoTransacao);
        }

        // GET: StatusFluxoTransacoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusFluxoTransacoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StatusID,DescricaoStatus")] StatusFluxoTransacao statusFluxoTransacao)
        {
            if (ModelState.IsValid)
            {
                db.StatusFluxoTransacoes.Add(statusFluxoTransacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusFluxoTransacao);
        }

        // GET: StatusFluxoTransacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusFluxoTransacao statusFluxoTransacao = db.StatusFluxoTransacoes.Find(id);
            if (statusFluxoTransacao == null)
            {
                return HttpNotFound();
            }
            return View(statusFluxoTransacao);
        }

        // POST: StatusFluxoTransacoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StatusID,DescricaoStatus")] StatusFluxoTransacao statusFluxoTransacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusFluxoTransacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusFluxoTransacao);
        }

        // GET: StatusFluxoTransacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StatusFluxoTransacao statusFluxoTransacao = db.StatusFluxoTransacoes.Find(id);
            if (statusFluxoTransacao == null)
            {
                return HttpNotFound();
            }
            return View(statusFluxoTransacao);
        }

        // POST: StatusFluxoTransacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StatusFluxoTransacao statusFluxoTransacao = db.StatusFluxoTransacoes.Find(id);
            db.StatusFluxoTransacoes.Remove(statusFluxoTransacao);
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
