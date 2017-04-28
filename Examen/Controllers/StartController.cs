using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    public class StartController : Controller
    {
        // GET: Start
        public ActionResult Start()
        {
            return View();
        }
        public void PreKillSession()
        {
            System.Web.HttpContext.Current.Session.Remove("Respondent");
            System.Web.HttpContext.Current.Session.Remove("LastLoadedQ");
        }
    }
}