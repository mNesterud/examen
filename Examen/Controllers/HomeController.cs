using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Examen.Models;

namespace Examen.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Tack för att du stöttar denna studie!";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Start()
        {
            return View();
        }
        public void SaveTime(string rID, string time, string timeType, string browserType)
        {
            int id = Convert.ToInt16(rID);
            decimal theTime = decimal.Parse(time);

            using (DBEntities db = new DBEntities())
            {
                Respondent r = db.Respondents.Where(x => x.Id == id).FirstOrDefault();

                if (timeType.ToLower() == "loginfind")
                {
                    r.LogInFind = theTime;
                    r.BrowserType = browserType;
                    db.SaveChanges();
                }
                else if (timeType.ToLower() == "loginclick")
                {
                    r.LogInClick = theTime;
                    db.SaveChanges();
                }
                else if (timeType.ToLower() == "qstart")
                {
                    r.QStart = theTime;
                    db.SaveChanges();
                }

            }

        }
    }
}
