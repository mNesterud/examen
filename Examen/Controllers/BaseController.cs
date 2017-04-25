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
            if (System.Web.HttpContext.Current.Session["Respondent"] != null)
            {
                UIType ui = UI(((Respondent)System.Web.HttpContext.Current.Session["Respondent"]).UITypeID);
                ViewBag.UIType = ui.Name;
            }
            else
            {
                using (DBEntities db = new DBEntities())
                {
                    UIType ui = db.UITypes.OrderBy(x => x.Count).FirstOrDefault();
                    Respondent r = new Respondent();
                    r.UITypeID = ui.Id;
                    db.Respondents.Add(r);
                    db.SaveChanges();
                    System.Web.HttpContext.Current.Session["Respondent"] = r;
                    ViewBag.UIType = ui.Name;
                }
            }
        }
        private UIType UI(int id)
        {
            UIType ui = new UIType();
            using (DBEntities db = new DBEntities())
            {
                ui = db.UITypes.Where(x => x.Id == id).FirstOrDefault();
            }
            return ui;
        }
        
    }
}