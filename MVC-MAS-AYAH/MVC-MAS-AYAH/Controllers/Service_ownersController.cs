using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVC_MAS_AYAH;

namespace MVC_MAS_AYAH.Controllers
{
    public class Service_ownersController : Controller
    {
        private MasterpieceEntities db = new MasterpieceEntities();

        // GET: Service_owners
        public ActionResult Index(int? id)
        {
            if (id == null) { 
            var service_owners = db.Service_owners.Include(s => s.AspNetUser).Include(s => s.Servicess);
            return View(service_owners.ToList());
        }
            else
            {
                var service_owners = db.Service_owners.Where(a=>a.Service_Id==id).Include(s => s.AspNetUser).Include(s => s.Servicess);
                return View(service_owners.ToList());
            }

        }
        [Authorize]

        public ActionResult profile(int? id)

        {
            if (User.IsInRole("ServiceOwner"))
            {
                var user = User.Identity.GetUserId();
                var subscriper = db.Service_owners.FirstOrDefault(x => x.Asp_Id == user);
                if (subscriper == null)
                {
                    return HttpNotFound();
                }
                return View(subscriper);
            }
            else if (User.IsInRole("User"))
            {
                var subscriper = db.Service_owners.FirstOrDefault(x => x.Id == id);
                if (subscriper == null)
                {
                    return HttpNotFound();
                }
                return View(subscriper);
            }
            return View();

        }
        //if (id == null)
        //{
        //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //}
        //Service_owners service_owners = db.Service_owners.Find(id);
        //if (service_owners == null)
        //{
        //    return HttpNotFound();
        //}
        //return View(service_owners);



        // GET: Service_owners/Details/5
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

        // GET: Service_owners/Create
        public ActionResult Create()
        {
            ViewBag.Asp_Id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Service_Id = new SelectList(db.Servicesses, "Id", "Service_name");
            return View();
        }

        // POST: Service_owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Descripion,Photograph,Image_to_work,Service_Id,Image_to_work2,Image_to_work3,Image_to_work4,Image_to_work5,Image_to_work6,Image_to_work7,Image_to_work8,Image_to_work9,Image_to_work10,Asp_Id")] Service_owners service_owners)
        {
            if (ModelState.IsValid)
            {
                db.Service_owners.Add(service_owners);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Asp_Id = new SelectList(db.AspNetUsers, "Id", "Email", service_owners.Asp_Id);
            ViewBag.Service_Id = new SelectList(db.Servicesses, "Id", "Service_name", service_owners.Service_Id);
            return View(service_owners);
        }

        // GET: Service_owners/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.Asp_Id = new SelectList(db.AspNetUsers, "Id", "Email", service_owners.Asp_Id);
            ViewBag.Service_Id = new SelectList(db.Servicesses, "Id", "Service_name", service_owners.Service_Id);
            return View(service_owners);
        }

        // POST: Service_owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Descripion,Photograph,Image_to_work,Service_Id,Image_to_work2,Image_to_work3,Image_to_work4,Image_to_work5,Image_to_work6,Image_to_work7,Image_to_work8,Image_to_work9,Image_to_work10,Asp_Id")] Service_owners service_owners)
        {
            if (ModelState.IsValid)
            {
                db.Entry(service_owners).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Asp_Id = new SelectList(db.AspNetUsers, "Id", "Email", service_owners.Asp_Id);
            ViewBag.Service_Id = new SelectList(db.Servicesses, "Id", "Service_name", service_owners.Service_Id);
            return View(service_owners);
        }

        // GET: Service_owners/Delete/5
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

        // POST: Service_owners/Delete/5
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

        public ActionResult EditProfile()
        {
            var user = User.Identity.GetUserId();
            var subscriper = db.Service_owners.FirstOrDefault(x => x.Asp_Id == user);
            Session["Image1"] = subscriper.Image_to_work;
            Session["Image10"] = subscriper.Image_to_work10;
            Session["Image2"] = subscriper.Image_to_work2;
            Session["Image3"] = subscriper.Image_to_work3;
            Session["Imageph"] = subscriper.Photograph;

            if (subscriper == null)
            {
                return HttpNotFound();
            }
            return View(subscriper);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile1([Bind(Include = "Id,Number,Descripion,Photograph,Image_to_work,Service_Id,Image_to_work2,Image_to_work3,Image_to_work4,Image_to_work5,Image_to_work6,Image_to_work7,Image_to_work8,Image_to_work9,Image_to_work10,Asp_Id")] Service_owners service_owners, AspNetUser aspNetUser, HttpPostedFileBase Photograph, HttpPostedFileBase Image_to_work, HttpPostedFileBase Image_to_work10, HttpPostedFileBase Image_to_work2, HttpPostedFileBase Image_to_work3, HttpPostedFileBase PhoneNumber, FormCollection form)
        {
            var user = User.Identity.GetUserId();
            var sub = db.Service_owners.FirstOrDefault(x => x.Asp_Id == user);
            var od = db.AspNetUsers.FirstOrDefault(x => x.PhoneNumber == user);

            if (ModelState.IsValid)
            {
                if (Photograph != null)
                {
                    string pathpic = Path.GetFileName(Photograph.FileName);
                    Photograph.SaveAs(Path.Combine(Server.MapPath("~/images/"), Photograph.FileName));
                    sub.Photograph = Path.GetFileName(Photograph.FileName);
                }
                else
                {
                    sub.Photograph = Session["Imageph"].ToString();
                }
                if (Image_to_work != null)
                {
                    string Image_to_worke = Path.GetFileName(Image_to_work.FileName);
                    Image_to_work.SaveAs(Path.Combine(Server.MapPath("~/images/"), Image_to_work.FileName));
                    sub.Image_to_work = Path.GetFileName(Image_to_work.FileName);

                }
                else
                {
                    sub.Image_to_work = Session["Image1"].ToString();
                }
                if (Image_to_work10 != null)
                {
                    string Image_to_work10e = Path.GetFileName(Image_to_work10.FileName);
                    Image_to_work10.SaveAs(Path.Combine(Server.MapPath("~/images/"), Image_to_work10.FileName));
                    sub.Image_to_work10 = Path.GetFileName(Image_to_work10.FileName);

                }
                else
                {
                    sub.Image_to_work10 = Session["Image10"].ToString();
                }
                if (Image_to_work2 != null)
                {
                    string Image_to_work2e = Path.GetFileName(Image_to_work2.FileName);
                    Image_to_work2.SaveAs(Path.Combine(Server.MapPath("~/images/"), Image_to_work2.FileName));
                    sub.Image_to_work2 = Path.GetFileName(Image_to_work2.FileName);

                }
                else
                {
                    sub.Image_to_work2 = Session["Image2"].ToString();
                }
                if (Image_to_work3 != null)
                {
                    string Image_to_work3e = Path.GetFileName(Image_to_work3.FileName);
                    Image_to_work3.SaveAs(Path.Combine(Server.MapPath("~/images/"), Image_to_work3.FileName));
                    sub.Image_to_work3 = Path.GetFileName(Image_to_work3.FileName);

                }
                else
                {
                    sub.Image_to_work3 = Session["Image3"].ToString();
                }
                sub.Number = service_owners.Number;
                sub.Descripion = service_owners.Descripion;
                sub.Service_Id= service_owners.Service_Id;
                //od.PhoneNumber = AspNetUser.PhoneNumber;
                db.SaveChanges();
                AspNetUser userr = db.AspNetUsers.Find(User.Identity.GetUserId());
                userr.PhoneNumber = form["name"];
                db.SaveChanges();

            }
            return RedirectToAction("Profile", "Service_owners");
        }
    }
}
