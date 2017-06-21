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
    public class PessoaController : Controller
    {
        private ContextoEF db = new ContextoEF();

        // GET: Pessoa
        public ActionResult Index()
        {
            var pessoas = db.Pessoas.Include(p => p.Profissao).Include(p => p.Usuario);
            return View(pessoas.ToList());
        }

        // GET: Pessoa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoa/Create
        public ActionResult Create()
        {
            ViewBag.ProfissaoId = new SelectList(db.Profissoes, "ProfissaoId", "Descricao");
            ViewBag.PessoaId = new SelectList(db.Usuarios, "UsuarioId", "Senha");
            return View();
        }

        // POST: Pessoa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PessoaId,Nome,Sobrenome,CPF,DataNascimento,DataCadastro,Email,Matricula,ProfissaoId")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProfissaoId = new SelectList(db.Profissoes, "ProfissaoId", "Descricao", pessoa.ProfissaoId);
            ViewBag.PessoaId = new SelectList(db.Usuarios, "UsuarioId", "Senha", pessoa.PessoaId);
            return View(pessoa);
        }

        // GET: Pessoa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfissaoId = new SelectList(db.Profissoes, "ProfissaoId", "Descricao", pessoa.ProfissaoId);
            ViewBag.PessoaId = new SelectList(db.Usuarios, "UsuarioId", "Senha", pessoa.PessoaId);
            return View(pessoa);
        }

        // POST: Pessoa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PessoaId,Nome,Sobrenome,CPF,DataNascimento,DataCadastro,Email,Matricula,ProfissaoId")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProfissaoId = new SelectList(db.Profissoes, "ProfissaoId", "Descricao", pessoa.ProfissaoId);
            ViewBag.PessoaId = new SelectList(db.Usuarios, "UsuarioId", "Senha", pessoa.PessoaId);
            return View(pessoa);
        }

        // GET: Pessoa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoas.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoa);
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
