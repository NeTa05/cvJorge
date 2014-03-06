using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjCurriculum.Classes;//adding class to send email
using prjCurriculum.Models;//adding model recommend
namespace prjCurriculum.Controllers
{
    public class HomeController : Controller
    {
        private RecommendDB db = new RecommendDB();
        //view
        public ActionResult Index()
        {
            return View();
        }
        //view
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(string email, string message, string name)
        {
            Email objectEmail    =   new Email(email, message, name);
            bool status          =   this.IsValidEmail(email);
            string msg           =   "";
            if (!status)
                msg              =   "Email";
            else
            {
                if (!message.Equals("") && !name.Equals(""))
                {
                    objectEmail.SendEmail();
                    msg          =   "Enviado";
                }
            }
            return Content(msg);
        }
        //view
        public ActionResult Recommend()
        {
            List<Recommend> recommend   =    db.Recommends.ToList();
            ViewBag.recommend           =    recommend;
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Aulas/Create

        [HttpPost]
        public ActionResult Create(string name = "", string telephone = "", string email="", string comment="")
        {
            Recommend recommend        =     new Recommend();
            recommend.Name             =     name;
            recommend.Telephone        =     telephone;
            recommend.Email            =     email;
            recommend.Comment          =     comment;
            string msg                 =     "";
            bool status                =     this.IsValidEmail(email);
            if (!status)
                msg                    =     "Email";
            else
            {
                int num;
                bool isNum = int.TryParse(telephone, out num);
                if (!name.Equals("") && !comment.Equals(""))
                {
                    if (isNum)
                    {
                        db.Recommends.Add(recommend);
                        db.SaveChanges();
                        msg            =     "Enviado";
                    }
                }
            } 
            return Content(msg);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //close db
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
