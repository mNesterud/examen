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
            ViewBag.Message = "Vad trevligt att du vill genomföra enkäten. Tack för att du stöttar vårt examensarbete!";

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
        public void SaveTime(string rID, string time, string loginFind)
        {
            bool isLoginFind = Convert.ToBoolean(loginFind);
            int id = Convert.ToInt16(rID);
            decimal theTime = decimal.Parse(time);

            using (DBEntities db = new DBEntities())
            {
                Respondent r = db.Respondents.Where(x => x.Id == id).FirstOrDefault();
            
            if (isLoginFind)
            {
                
            }
            else if (!isLoginFind)
            {

            }

            }

        }
    }
}
