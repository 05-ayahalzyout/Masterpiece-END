using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_MAS_AYAH;

namespace MVC_MAS_AYAH.Controllers
{
    public class ServicessesController : Controller
    {
        private MasterpieceEntities db = new MasterpieceEntities();

        // GET: Servicesses
        public ActionResult Index()
        {
            return View(db.Servicesses.ToList());
        }

        public ActionResult Users(string search)
        {
            return View("Index", db.Servicesses.Where(p => p.Servic_image.Contains(search) || p.Service_name.Contains(search) || p.Description.Contains(search)).ToList());
        }

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

        // GET: Servicesses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servicesses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Service_name,Servic_image,Description")] Servicess servicess, HttpPostedFileBase picture)
        {
            {
                try
                {

                    if (ModelState.IsValid)
                    {
                        try
                        {
                            string fileName = Path.GetFileName(picture.FileName);
                            string path = "~/images/" + Path.GetFileName(picture.FileName);
                            string path2 = Path.GetFileName(picture.FileName);
                            picture.SaveAs(Server.MapPath(path));
                            servicess.Servic_image = path2.ToString();
                            int flag = 0;
                            foreach (var item in db.Servicesses)
                            {
                                if (servicess.Service_name == item.Service_name)
                                {
                                    ViewBag.alert = "You can not add the facility is alerady exist";
                                    flag = 1;
                                }
                            }
                            if (flag == 0)
                            {
                                db.Servicesses.Add(servicess);
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                        }

                        catch (Exception ex)
                        {
                            servicess.Servic_image = Session["img"].ToString();
                            db.Servicesses.Add(servicess);
                            return RedirectToAction("Index");
                        }

                    }

                    return View(servicess);
                }
                catch (Exception ex)
                {


                    ViewBag.alert = "you must upload Image";
                    return View(servicess);


                }
            }


            //if (ModelState.IsValid)
            //{
            //    db.Servicesses.Add(servicess);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(servicess);
        }

        // GET: Servicesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicess servicess = db.Servicesses.Find(id);
            Session["eidtimg"] = servicess.Servic_image;
            if (servicess == null)
            {
                return HttpNotFound();
            }

            return View(servicess);
        }

        // POST: Servicesses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Service_name,Servic_image,Description")] Servicess servicess, HttpPostedFileBase picture)
        {
            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    //string fileName = Path.GetFileName(image.FileName);
                    string path = Server.MapPath("~/images/") + picture.FileName;
                    picture.SaveAs(path);
                    servicess.Servic_image = picture.FileName;
                }
                else
                {
                    servicess.Servic_image = Session["eidtimg"].ToString();
                }
                db.Entry(servicess).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            return View(servicess);
        }

        // GET: Servicesses/Delete/5
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

        // POST: Servicesses/Delete/5
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