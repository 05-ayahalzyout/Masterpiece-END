using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace MVC_MAS_AYAH.Controllers
{
    public class HomeController : Controller
    {
        private MasterpieceEntities db = new MasterpieceEntities();

        public ActionResult Index()
        {
            ViewBag.serv=db.Servicesses.Select(a=>a.Service_name).ToList();
            var Owner = db.Service_owners.ToList();
            return View(Owner);

        }
       
        public ActionResult _ImageSer(int? id)
        {

            if (id == null)
            {
                return PartialView(db.Service_owners.ToList());
            }
            else
            {
                return PartialView(db.Service_owners.Where(a => a.Id == id).ToList());


            }

        }
        public ActionResult Homepage()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult SendEmail(FormCollection form)
        {


            string name = form["name"];
            string email = form["email"];
            string message = form["message"];
            string subject = form["subject"];
            MailMessage mail = new MailMessage();
            mail.To.Add("ayahalzyout514@gmail.com");
            mail.From = new MailAddress(form["email"]);

            mail.Subject = form["subject"];
            mail.Body = message;
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("ayahalzyout514@gmail.com", "gfozvghsconqtxli\r\n");
            smtp.Send(mail);

            return RedirectToAction("Contact");
        }
        public ActionResult sample()
        {
            return View();
        }
        public ActionResult Design()
        {
            return View();
        }

        public ActionResult kash(int?id)
        {
            Session["SubId"] = id;

            return View();
        }
        public ActionResult PaySubscription()
        {
            int AccountID = (int)Session["SubId"];
            Account Acc = db.Accounts.Find(AccountID);
            int duration =(int)Acc.Duration;
            float price = (float)Acc.Price;
            Subscription subsc=new Subscription();
            subsc.usr_id = User.Identity.GetUserId();
            subsc.Subscription_Duration= duration;
            subsc.Subscription_End = DateTime.Now.Date.AddMonths(duration);
            subsc.Subscription_Beg = DateTime.Now.Date;
            subsc.Subscription_Amount =(decimal)price;
            db.Subscriptions.Add(subsc);
            db.SaveChanges();
            AspNetUser User5 = db.AspNetUsers.Find(User.Identity.GetUserId());
            string email = User5.Email;
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            mail.From = new MailAddress("ayahalzyout514@gmail.com");

            mail.Subject = "اشتراك";
            mail.Body = " نتمنى لك الرزق و التوفيق 🧡<br/>شكرا لك لزياره موقعنا , تم الاشتراك بنجاح";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("ayahalzyout514@gmail.com", "gfozvghsconqtxli\r\n");
            smtp.Send(mail);
            return RedirectToAction("Index");
        }
    }
}
    