﻿using System;
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
    public class Subscriptions1Controller : Controller
    {
        private MasterpieceEntities db = new MasterpieceEntities();

        // GET: Subscriptions1
        public ActionResult Index()
        {
            var subscriptions = db.Subscriptions.Include(s => s.AspNetUser);
            return View(subscriptions.ToList());
        }
        public ActionResult Users(string search)
        {
            return View("Index", db.Subscriptions.Where(p => p.Subscription_Beg.ToString().Contains(search) || p.Subscription_Duration.ToString().Contains(search) || p.Subscription_Amount.ToString().Contains(search) || p.Subscription_End.ToString().Contains(search)));
        }
        // GET: Subscriptions1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // GET: Subscriptions1/Create
        public ActionResult Create()
        {
            ViewBag.usr_id = new SelectList(db.AspNetUsers, "Id", "PhoneNumber");
            return View();
        }

        // POST: Subscriptions1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Last_Day,Subtype,Amount,Condition,usr_id")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Subscriptions.Add(subscription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.usr_id = new SelectList(db.Service_owners, "Id", "Number", subscription.usr_id);
            return View(subscription);
        }

        // GET: Subscriptions1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            ViewBag.usr_id = new SelectList(db.Service_owners, "Id", "Number", subscription.usr_id);
            return View(subscription);
        }

        // POST: Subscriptions1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Last_Day,Subtype,Amount,Condition,usr_id")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subscription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.usr_id = new SelectList(db.Service_owners, "Id", "Number", subscription.usr_id);
            return View(subscription);
        }

        // GET: Subscriptions1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return HttpNotFound();
            }
            return View(subscription);
        }

        // POST: Subscriptions1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            db.Subscriptions.Remove(subscription);
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
