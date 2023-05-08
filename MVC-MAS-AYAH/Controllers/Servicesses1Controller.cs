using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_MAS_AYAH;

namespace MVC_MAS_AYAH.Controllers
{
    public class Servicesses1Controller : Controller
    {
        private MasterpieceEntities db = new MasterpieceEntities();

        // GET: Servicesses1
        public ActionResult Index()
        {
            return View(db.Servicesses.ToList());
        }

        public PartialViewResult View()
        {
            //var prodec = db.proudects.Include(m => m.subcat);

            //var majors = db.subcats.Include(m => m.Category );
            //return PartialView(majors.ToList());


            return PartialView(db.Servicesses.ToList());
        }

        // GET: Servicesses1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicess servicess = db.Servicesses.Find(id);
            if (servicess == null)
            {
                return HttpNotFound();
            }
            return View(servicess);
        }

        // GET: Servicesses1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicesses1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Service_name,Servic_image,Description")] Servicess servicess)
        {
            if (ModelState.IsValid)
            {
                db.Servicesses.Add(servicess);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(servicess);
        }

        // GET: Servicesses1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicess servicess = db.Servicesses.Find(id);
            if (servicess == null)
            {
                return HttpNotFound();
            }
            return View(servicess);
        }

        // POST: Servicesses1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Service_name,Servic_image,Description")] Servicess servicess)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servicess);
        }

        // GET: Servicesses1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicess servicess = db.Servicesses.Find(id);
            if (servicess == null)
            {
                return HttpNotFound();
            }
            return View(servicess);
        }

        // POST: Servicesses1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicess servicess = db.Servicesses.Find(id);
            db.Servicesses.Remove(servicess);
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
