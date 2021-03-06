﻿using Examen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    public class QuestionnaireController : BaseController
    {
        // GET: Questionnaire
        public ActionResult Questionnaire()
        {
            QuestionnaireModel q = new QuestionnaireModel(true);
            return View(q);
        }
        public ActionResult ThankYou()
        {
            return View();
        }
        public PartialViewResult Question(string id)
        {
            QuestionAndResponses qr = new QuestionAndResponses(Convert.ToInt16(id));
            System.Web.HttpContext.Current.Session["LastLoadedQ"] = id;

            return PartialView("Question", qr);
        }

        public PartialViewResult EmailPage()
        {
            Respondent r = (Respondent)Session["Respondent"];

            int uiID = r.UITypeID;

            using (DBEntities db = new DBEntities())
            {
                UIType ui = db.UITypes.Where(x => x.Id == uiID).FirstOrDefault();
                ui.Count++;
                db.SaveChanges();
            }
            System.Web.HttpContext.Current.Session["LastLoadedQ"] = "Email";
            return PartialView("_EmailPage");
        }

        [HttpPost]
        public ActionResult EmailPage(Email e)
        {
            
                using (DBEntities db = new DBEntities())
                {
                   
                    db.Emails.Add(e);
                    try
                    {

                        db.SaveChanges();
                    }
                    catch (Exception error)
                    {
                        
                    }
                }
            
            return View("ThankYou");
        }
        public void KillSession()
        {
            System.Web.HttpContext.Current.Session.Remove("Respondent");
            System.Web.HttpContext.Current.Session.Remove("LastLoadedQ");
        }

        public void SaveChoice(string rID, string qID, string time)
        {
            int responsID = Convert.ToInt16(rID);
            int questionID = Convert.ToInt16(qID);

            decimal theTime;
            decimal.TryParse(time, out theTime);

            Respondent r = (Respondent)Session["Respondent"];

            using(DBEntities db = new DBEntities())
            {
                int qrID = db.QuestionResponses.Where(x => (x.QuestionID == questionID) && (x.ResponseID == responsID)).FirstOrDefault().Id;

                RQR rqr = new RQR()
                {
                    RespondentID = r.Id,
                    QuestionResponseID = qrID,
                    Time = theTime
                };

                db.RQRs.Add(rqr);
                db.SaveChanges();
            }
        }
        public void SaveText(string t, string qID, string time)
        {
            int questionID = Convert.ToInt16(qID);
            
            decimal theTime;
            decimal.TryParse(time, out theTime);

            Respondent r = (Respondent)Session["Respondent"];

            using (DBEntities db = new DBEntities())
            {
                RQT rqt = new RQT()
                {
                    RespondentID = r.Id,
                    QuestionID = questionID,
                    Text = t,
                    Time = theTime
                };

                db.RQTs.Add(rqt);
                db.SaveChanges();
            }

            
        }
    }
}