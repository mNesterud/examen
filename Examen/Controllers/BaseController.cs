using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public BaseController()
        {
            UIType ui = new UIType();
            using (DBEntities db = new DBEntities()){

                ui = db.UITypes.OrderBy(x => x.Count).FirstOrDefault();

                ViewBag.UIType = ui.Name;
            }
        }
    }
}