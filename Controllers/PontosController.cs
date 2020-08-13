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
    public class PontosController : Controller
    {
        private PontoContext db = new PontoContext();

        // GET: Pontos
        public ActionResult Index()
        {
            return View(db.Pontos.ToList());
        }

        // GET: Pontos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponto ponto = db.Pontos.Find(id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            return View(ponto);
        }

        // GET: Pontos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pontos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PontoID,Nome,Descricao,Endereco,Telefone,DataFinal,CreationTime,Status")] Ponto ponto)
        {
            if (ModelState.IsValid)
            {
                db.Pontos.Add(ponto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ponto);
        }

        // GET: Pontos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponto ponto = db.Pontos.Find(id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            return View(ponto);
        }

        // POST: Pontos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PontoID,Nome,Descricao,Endereco,Telefone,DataFinal,CreationTime,Status")] Ponto ponto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ponto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ponto);
        }

        // GET: Pontos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ponto ponto = db.Pontos.Find(id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            return View(ponto);
        }

        // POST: Pontos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ponto ponto = db.Pontos.Find(id);
            db.Pontos.Remove(ponto);
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
