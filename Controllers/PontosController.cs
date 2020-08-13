using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PontoDeAjuda;
using PontoDeAjuda.DAL;
using PontoDeAjuda.Models;

namespace PontoDeAjuda.Controllers
{
    public class PontosController : Controller
    {
        private PontoContext db = new PontoContext();

        // GET: Pontos
        public ActionResult Index()
        {
            var pontos = db.Pontos.Include(c => c.Doacoes);
            return View(pontos.ToList());
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
            var ponto = new Ponto();
            ponto.Doacoes = new List<Doacao>();
            PopulateAssignedDoacaoData(ponto);
            return View();
        }

        // POST: Pontos/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PontoID,Nome,Descricao,Endereco,Telefone,DataFinal,CreationTime,Status")] Ponto ponto, string[] selectedDoacoes)
        {
            if (selectedDoacoes != null)
            {
                ponto.Doacoes = new List<Doacao>();
                foreach (var doacao in selectedDoacoes)
                {
                    var doacaoToAdd = db.Doacoes.Find(int.Parse(doacao));
                    ponto.Doacoes.Add(doacaoToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                db.Pontos.Add(ponto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            PopulateAssignedDoacaoData(ponto);
            return View(ponto);
        }

        // GET: Pontos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ponto = db.Pontos
                .Include(i => i.Doacoes)
                .Where(i => i.PontoID == id)
                .Single();
            PopulateAssignedDoacaoData(ponto);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            return View(ponto);
        }
        private void PopulateAssignedDoacaoData(Ponto ponto)
        {
            var allDoacoes = db.Doacoes;
            var Doacoes = new HashSet<int>(ponto.Doacoes.Select(c => c.DoacaoID));
            var viewModel = new List<AssignedDoacaoData>();
            foreach (var doacao in allDoacoes)
            {
                viewModel.Add(new AssignedDoacaoData
                {
                    DoacaoID = doacao.DoacaoID,
                    Nome = doacao.Nome,
                    icon = doacao.icon,
                    Assigned = Doacoes.Contains(doacao.DoacaoID)
                });
            }
            ViewBag.Doacoes = viewModel;
        }
        // POST: Pontos/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] selectedDoacoes)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ponto = db.Pontos
                .Include(i => i.Doacoes)
                .Where(i => i.PontoID == id)
                .Single();

            if (TryUpdateModel(ponto, "",
            new string[] { "Nome", "Descricao", "Endereco", "Telefone", "DataFinal" }))
            {
                try
                {

                    UpdatePondodeAjuda(selectedDoacoes, ponto);

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateAssignedDoacaoData(ponto);
            return View(ponto);
        }
        private void UpdatePondodeAjuda(string[] selectedPontos, Ponto ponto)
        {
            if (ponto == null)
            {
                ponto.Doacoes = new List<Doacao>();
                return;
            }

            var selectedPontosHS = new HashSet<string>(selectedPontos);
            var pontosDeAjuda = new HashSet<int>
                (ponto.Doacoes.Select(c => c.DoacaoID));
            foreach (var doacoes in db.Doacoes)
            {
                if (selectedPontosHS.Contains(doacoes.DoacaoID.ToString()))
                {
                    if (!pontosDeAjuda.Contains(doacoes.DoacaoID))
                    {
                        ponto.Doacoes.Add(doacoes);
                    }
                }
                else
                {
                    if (pontosDeAjuda.Contains(doacoes.DoacaoID))
                    {
                        ponto.Doacoes.Remove(doacoes);
                    }
                }
            }
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
