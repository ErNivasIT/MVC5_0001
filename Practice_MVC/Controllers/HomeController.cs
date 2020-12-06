using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using GuestResponse.Model;
using Practice_MVC.Model;

namespace Practice_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<Product> products = new List<Product> {
             new Product()
            {
                Product_ID = 1,
                Name = "Football",
                Description = "Football Description",
                Category = "WaterSports",
                Price = 275M
            },
              new Product()
            {
                Product_ID = 2,
                Name = "Surf Board",
                Description = "Surf Board Description",
                Category = "WaterSports",
                Price = 275M
            },
              new Product()
            {
                Product_ID = 3,
                Name = "Running Shoes",
                Description = "Running Shoes Description",
                Category = "WaterSports",
                Price = 275M
            }
            };
            return View(products);
        }
        //public ActionResult Index()
        //{
        //    int hours = DateTime.Now.Hour;
        //    ViewBag.Greeting = hours < 12 ? "Good Morning" : "Good Afrernoon";
        //    return View();
        //}
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public ViewResult RsvpForm(GuestResponse.Model.GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                MailModel objModel = new MailModel();
                objModel.From = "shri.mca2010@gmail.com";
                objModel.To = guestResponse.Email;
                objModel.Subject = "Regarding the Invitation of Party ";
                string responseType = guestResponse.WillAttend.Value == true ? "Glad to hear that you are attending the party, See you there !!!"
                    : "It would be have better that you attend, be first on the next party !!!";

                objModel.Body = "Dear " + guestResponse.Name + ", <br/> Thanks for your valuable response regarding the Invitation !!!<br/>" + responseType;

                MailMessage mail = new MailMessage();
                mail.To.Add(objModel.To);
                mail.From = new MailAddress(objModel.From);
                mail.Subject = objModel.Subject;
                string Body = objModel.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("shri.mca2010@gmail.com", "GoodMail*123");// Enter senders User name and password
                smtp.Send(mail);
                //Email Logic
                return View("Thanks", guestResponse);
            }
            return View();
        }
        [HttpGet]
        public ActionResult Thanks()
        {
            return View();
        }
    }
}
