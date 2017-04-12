using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class QuestionAndResponses
    {
        public Question Q { get; set; }
        public List<Response> Responses { get; set; }
        public int SelectedResponseId { get; set; }

        public QuestionAndResponses(int QuestionId)
        {
            using (DBEntities db = new DBEntities())
            {
                Q = db.Questions.Where(x => x.Id == QuestionId).FirstOrDefault();
                Responses = new List<Response>();
                foreach (QuestionResponse qr in db.QuestionResponses)
                {
                    if (qr.QuestionID == QuestionId)
                    {
                        Responses.Add(db.Responses.Where(x => x.Id == qr.ResponseID).FirstOrDefault());
                    }
                }
            }
            SelectedResponseId = 0;

        }
    }
}