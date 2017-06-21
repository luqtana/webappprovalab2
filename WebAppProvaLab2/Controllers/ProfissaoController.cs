using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppProvaLab2.Contexto;
using WebAppProvaLab2.Models;

namespace WebAppProvaLab2.Controllers
{
    public class ProfissaoController : Controller
    {
        private ContextoEF db = new ContextoEF();

        // GET: Profissao
        public ActionResult Index()
        {
            return View(db.Profissoes.ToList());
        }

        // GET: Profissao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissao profissao = db.Profissoes.Find(id);
            if (profissao == null)
            {
                return HttpNotFound();
            }
            return View(profissao);
        }

        // GET: Profissao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profissao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfissaoId,Descricao,CBO")] Profissao profissao)
        {
            if (ModelState.IsValid)
            {
                db.Profissoes.Add(profissao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profissao);
        }

        // GET: Profissao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissao profissao = db.Profissoes.Find(id);
            if (profissao == null)
            {
                return HttpNotFound();
            }
            return View(profissao);
        }

        // POST: Profissao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfissaoId,Descricao,CBO")] Profissao profissao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profissao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profissao);
        }

        // GET: Profissao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profissao profissao = db.Profissoes.Find(id);
            if (profissao == null)
            {
                return HttpNotFound();
            }
            return View(profissao);
        }

        // POST: Profissao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profissao profissao = db.Profissoes.Find(id);
            db.Profissoes.Remove(profissao);
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
