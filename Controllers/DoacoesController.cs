using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PontoDeAjuda;
using PontoDeAjuda.DAL;

namespace PontoDeAjuda.Controllers
{
    public class DoacoesController : Controller
    {
        private PontoContext db = new PontoContext();

        // GET: Doacoes
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.Doacoes.ToList());
        }

        // GET: Doacoes/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doacao doacao = db.Doacoes.Find(id);
            if (doacao == null)
            {
                return HttpNotFound();
            }
            return View(doacao);
        }

        // GET: Doacoes/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doacoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "DoacaoID,Nome,icon")] Doacao doacao)
        {
            if (ModelState.IsValid)
            {
                db.Doacoes.Add(doacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(doacao);
        }

        // GET: Doacoes/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doacao doacao = db.Doacoes.Find(id);
            if (doacao == null)
            {
                return HttpNotFound();
            }
            return View(doacao);
        }

        // POST: Doacoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "DoacaoID,Nome,icon")] Doacao doacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(doacao);
        }

        // GET: Doacoes/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doacao doacao = db.Doacoes.Find(id);
            if (doacao == null)
            {
                return HttpNotFound();
            }
            return View(doacao);
        }

        // POST: Doacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Doacao doacao = db.Doacoes.Find(id);
            db.Doacoes.Remove(doacao);
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
