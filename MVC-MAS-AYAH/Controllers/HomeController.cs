using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MVC_MAS_AYAH.Controllers
{
    public class HomeController : Controller
    {
        private MasterpieceEntities db = new MasterpieceEntities();

        public ActionResult Index()
        {
            return View(db.Servicesses.ToList());

        }
        public ActionResult _ImageSer(int ? id)
        {
            
                if (id == null)
                {
                    return PartialView(db.Service_owners.ToList());
                }
                else
                {
                    return PartialView(db.Service_owners.Where(a=>a.Id==id).ToList());


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
            smtp.Credentials = new System.Net.NetworkCredential("ayahalzyout514@gmail.com", "rtdpuwxwvqfesdtd");
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

        public ActionResult kash()
        {

            return View();
        }

    }
}