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
    public class SuprimentosController : Controller
    {
        private PontoContext db = new PontoContext();

        // GET: Suprimentos
        public ActionResult Index()
        {
            return View(db.Suprimentos.ToList());
        }

        // GET: Suprimentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suprimento suprimento = db.Suprimentos.Find(id);
            if (suprimento == null)
            {
                return HttpNotFound();
            }
            return View(suprimento);
        }

        // GET: Suprimentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suprimentos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SuprimentoID,Nome,icon")] Suprimento suprimento)
        {
            if (ModelState.IsValid)
            {
                db.Suprimentos.Add(suprimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(suprimento);
        }

        // GET: Suprimentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suprimento suprimento = db.Suprimentos.Find(id);
            if (suprimento == null)
            {
                return HttpNotFound();
            }
            return View(suprimento);
        }

        // POST: Suprimentos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SuprimentoID,Nome,icon")] Suprimento suprimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(suprimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(suprimento);
        }

        // GET: Suprimentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suprimento suprimento = db.Suprimentos.Find(id);
            if (suprimento == null)
            {
                return HttpNotFound();
            }
            return View(suprimento);
        }

        // POST: Suprimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suprimento suprimento = db.Suprimentos.Find(id);
            db.Suprimentos.Remove(suprimento);
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
