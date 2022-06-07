using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenProgra.Models;

namespace ExamenProgra.Controllers
{
    public class tb_maquillajeController : Controller
    {
        private MaquillajeEntities db = new MaquillajeEntities();

        // GET: tb_maquillaje
        public ActionResult Index()
        {
            return View(db.tb_maquillaje.ToList());
        }

        // GET: tb_maquillaje/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_maquillaje tb_maquillaje = db.tb_maquillaje.Find(id);
            if (tb_maquillaje == null)
            {
                return HttpNotFound();
            }
            return View(tb_maquillaje);
        }

        // GET: tb_maquillaje/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tb_maquillaje/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdMaquillaje,Producto,Marca,Tono,Precio,Lanzamiento,Vencimiento")] tb_maquillaje tb_maquillaje)
        {
            if (ModelState.IsValid)
            {
                db.tb_maquillaje.Add(tb_maquillaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tb_maquillaje);
        }

        // GET: tb_maquillaje/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_maquillaje tb_maquillaje = db.tb_maquillaje.Find(id);
            if (tb_maquillaje == null)
            {
                return HttpNotFound();
            }
            return View(tb_maquillaje);
        }

        // POST: tb_maquillaje/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdMaquillaje,Producto,Marca,Tono,Precio,Lanzamiento,Vencimiento")] tb_maquillaje tb_maquillaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tb_maquillaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tb_maquillaje);
        }

        // GET: tb_maquillaje/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tb_maquillaje tb_maquillaje = db.tb_maquillaje.Find(id);
            if (tb_maquillaje == null)
            {
                return HttpNotFound();
            }
            return View(tb_maquillaje);
        }

        // POST: tb_maquillaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tb_maquillaje tb_maquillaje = db.tb_maquillaje.Find(id);
            db.tb_maquillaje.Remove(tb_maquillaje);
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
