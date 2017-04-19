using Examen.Models;
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
        public PartialViewResult Question(string id)
        {
            QuestionAndResponses qr = new QuestionAndResponses(Convert.ToInt16(id));

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
            return PartialView("_EmailPage");
        }

        [HttpPost]
        public ActionResult EmailPage(Email e)
        {
            if (ModelState.IsValid)
            {
                using (DBEntities db = new DBEntities())
                {
                    Email e2 = new Email();
                    e2.Id = e.Id;
                    e2.Mail = e.Mail;
                    db.Emails.Add(e2);
                    db.SaveChanges();
                }
            }
            return View("ThankYou");
        }
        //public PartialViewResult QuestionSaveChoice(string id, int rID, int qrID)
        //{
        //    QuestionAndResponses qr = new QuestionAndResponses(Convert.ToInt16(id));

        //    return PartialView("Question", qr);
        //}

        //public PartialViewResult QuestionSaveText(string id, int rID, int qID, string t)
        //{
        //    QuestionAndResponses qr = new QuestionAndResponses(Convert.ToInt16(id));

        //    return PartialView("Question", qr);
        //}

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