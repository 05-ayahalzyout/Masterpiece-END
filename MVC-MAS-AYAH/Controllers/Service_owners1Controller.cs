using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using MVC_MAS_AYAH;

namespace MVC_MAS_AYAH.Controllers
{
    public class Service_owners1Controller : Controller
    {
        private MasterpieceEntities db = new MasterpieceEntities();

        // GET: Service_owners1
        public ActionResult Index()
        {
            var service_owners = db.Service_owners.Include(s => s.AspNetUser).Include(s => s.Servicess);
            return View(service_owners.ToList());
        }

        // GET: Service_owners1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_owners service_owners = db.Service_owners.Find(id);
            if (service_owners == null)
            {
                return HttpNotFound();
            }
            return View(service_owners);

        }

        // GET: Service_owners1/Create
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Service_owners1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Descripion,Photograph,Image_to_work,Service_Id,Image_to_work2,Image_to_work3,Image_to_work4,Image_to_work5,Image_to_work6,Image_to_work7,Image_to_work8,Image_to_work9,Image_to_work10,Asp_Id")] Service_owners service_owners, HttpPostedFileBase picture)
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
                            service_owners.Photograph = path2.ToString();
                            string f = Path.GetFileName(picture.FileName);
                            string p = "~/images/" + Path.GetFileName(picture.FileName);
                            string pa = Path.GetFileName(picture.FileName);
                            picture.SaveAs(Server.MapPath(path));
                            service_owners.Image_to_work = path2.ToString();
                            string fil = Path.GetFileName(picture.FileName);
                            string paa = "~/images/" + Path.GetFileName(picture.FileName);
                            string pat = Path.GetFileName(picture.FileName);
                            picture.SaveAs(Server.MapPath(path));
                            service_owners.Image_to_work10 = path2.ToString();
                            string file = Path.GetFileName(picture.FileName);
                            string paaa = "~/images/" + Path.GetFileName(picture.FileName);
                            string path22 = Path.GetFileName(picture.FileName);
                            picture.SaveAs(Server.MapPath(path));
                            service_owners.Image_to_work2 = path2.ToString();
                            string fileNam = Path.GetFileName(picture.FileName);
                            string patha = "~/images/" + Path.GetFileName(picture.FileName);
                            string path2a = Path.GetFileName(picture.FileName);
                            picture.SaveAs(Server.MapPath(path));
                            service_owners.Image_to_work3 = path2.ToString();
                            string fileNa = Path.GetFileName(picture.FileName);
                            string pathaa = "~/images/" + Path.GetFileName(picture.FileName);
                            string path2q = Path.GetFileName(picture.FileName);
                            picture.SaveAs(Server.MapPath(path));
                            service_owners.Image_to_work4 = path2.ToString();
                            string fileNama = Path.GetFileName(picture.FileName);
                            string pathz = "~/images/" + Path.GetFileName(picture.FileName);
                            string path2z = Path.GetFileName(picture.FileName);
                            picture.SaveAs(Server.MapPath(path));
                            service_owners.Image_to_work5 = path2.ToString();
                            string fileNaz = Path.GetFileName(picture.FileName);
                            string patd = "~/images/" + Path.GetFileName(picture.FileName);
                            string pathd = Path.GetFileName(picture.FileName);
                            picture.SaveAs(Server.MapPath(path));
                            service_owners.Image_to_work6 = path2.ToString();
                            string fileNk = Path.GetFileName(picture.FileName);
                            string patk = "~/images/" + Path.GetFileName(picture.FileName);
                            string pathk = Path.GetFileName(picture.FileName);
                            picture.SaveAs(Server.MapPath(path));
                            service_owners.Image_to_work7 = path2.ToString();
                            string fileNsame = Path.GetFileName(picture.FileName);
                            string pasth = "~/images/" + Path.GetFileName(picture.FileName);
                            string pasth2 = Path.GetFileName(picture.FileName);
                            picture.SaveAs(Server.MapPath(path));
                            service_owners.Image_to_work8 = path2.ToString();
                            string fizleName = Path.GetFileName(picture.FileName);
                            string pzath = "~/images/" + Path.GetFileName(picture.FileName);
                            string pzath2 = Path.GetFileName(picture.FileName);
                            picture.SaveAs(Server.MapPath(path));
                            service_owners.Image_to_work9 = path2.ToString();
                            int flag = 0;
                            foreach (var item in db.Servicesses)
                            {
                                if (service_owners.Number == item.Service_name)
                                {
                                    ViewBag.alert = "You can not add the facility is alerady exist";
                                    flag = 1;
                                }
                            }
                            if (flag == 0)
                            {
                                db.Service_owners.Add(service_owners);
                                db.SaveChanges();
                                return RedirectToAction("Index");
                            }
                        }

                        catch (Exception ex)
                        {
                            service_owners.Photograph = Session["img"].ToString();
                            db.Service_owners.Add(service_owners);
                            return RedirectToAction("Index");
                        }

                    }

                    return View(service_owners);
                }
                catch (Exception ex)
                {


                    ViewBag.alert = "you must upload Image";
                    return View(service_owners);


                }
            }
            //if (ModelState.IsValid)
            //{
            //    db.Service_owners.Add(service_owners);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //ViewBag.Asp_Id = new SelectList(db.AspNetUsers, "Id", "Email", service_owners.Asp_Id);
            //ViewBag.Service_Id = new SelectList(db.Servicesses, "Id", "Service_name", service_owners.Service_Id);
            //return View(service_owners);
        }

        // GET: Service_owners1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_owners service_owners = db.Service_owners.Find(id);
            Session["Image_to_work"] = service_owners.Image_to_work;
            Session["Image_to_work10"] = service_owners.Image_to_work10;
            Session["Image_to_work2"] = service_owners.Image_to_work2;
            Session["Image_to_work3"] = service_owners.Image_to_work3;
            Session["eidtimg"] = service_owners.Photograph;

            if (service_owners == null)
            {
                return HttpNotFound();
            }
            return View(service_owners);

        }

        // POST: Service_owners1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Descripion,Photograph,Image_to_work,Service_Id,Image_to_work2,Image_to_work3,Image_to_work4,Image_to_work5,Image_to_work6,Image_to_work7,Image_to_work8,Image_to_work9,Image_to_work10,Asp_Id")] Service_owners service_owners, HttpPostedFileBase picture, HttpPostedFileBase Image_to_work , HttpPostedFileBase Image_to_work2 , HttpPostedFileBase Image_to_work3 , HttpPostedFileBase Image_to_work10)
        {
            if (ModelState.IsValid)
            {

                if (picture != null)
                {
                    //string fileName = Path.GetFileName(image.FileName);
                    string path = Server.MapPath("~/images/") + picture.FileName;
                    picture.SaveAs(path);
                    service_owners.Photograph = picture.FileName;
                }
                else
                {
                    service_owners.Photograph = Session["eidtimg"].ToString();
                }

                if (Image_to_work != null)
                {
                    //string fileName = Path.GetFileName(image.FileName);
                    string path = Server.MapPath("~/images/") + Image_to_work.FileName;
                    Image_to_work.SaveAs(path);
                   
                  service_owners.Image_to_work= Image_to_work.FileName;


                }
                else
                {
                    service_owners.Image_to_work = Session["Image_to_work"].ToString();
                }


                  if (Image_to_work2 != null)
                {
                    //string fileName = Path.GetFileName(image.FileName);
                    string path = Server.MapPath("~/images/") + Image_to_work2.FileName;
                    Image_to_work2.SaveAs(path);
                   
                    service_owners.Image_to_work2 = Image_to_work2.FileName;
                 
                }
                else
                {
                    service_owners.Image_to_work2 = Session["Image_to_work2"].ToString();
                }

                if (Image_to_work3 != null)
                {
                    //string fileName = Path.GetFileName(image.FileName);
                    string path = Server.MapPath("~/images/") + Image_to_work3.FileName;
                    Image_to_work3.SaveAs(path);

                    service_owners.Image_to_work3 = Image_to_work3.FileName;


                }
                else
                {
                    service_owners.Image_to_work3 = Session["Image_to_work3"].ToString();
                }



                if (Image_to_work10 != null)
                {
                    //string fileName = Path.GetFileName(image.FileName);
                    string path = Server.MapPath("~/images/") + Image_to_work10.FileName;
                    Image_to_work10.SaveAs(path);

                    service_owners.Image_to_work10 = Image_to_work10.FileName;


                }
                else
                {
                    service_owners.Image_to_work10 = Session["Image_to_work10"].ToString();
                }

                db.Entry(service_owners).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(service_owners);

        }

        // GET: Service_owners1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service_owners service_owners = db.Service_owners.Find(id);
            if (service_owners == null)
            {
                return HttpNotFound();
            }
            return View(service_owners);
        }

        // POST: Service_owners1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service_owners service_owners = db.Service_owners.Find(id);
            db.Service_owners.Remove(service_owners);
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
