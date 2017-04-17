using Examen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen.Controllers
{
    public class QuestionnaireController : Controller
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

        public PartialViewResult Question(string id, int rID, int qrID)
        {
            QuestionAndResponses qr = new QuestionAndResponses(Convert.ToInt16(id));

            return PartialView("Question", qr);
        }

        public PartialViewResult Question(string id, int rID, int qID, string t)
        {
            QuestionAndResponses qr = new QuestionAndResponses(Convert.ToInt16(id));

            return PartialView("Question", qr);
        }
    }
}