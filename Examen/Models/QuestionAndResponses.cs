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
        public int QNumber { get; set; }
        public int SelectedResponseId { get; set; }

        public QuestionAndResponses(int Next)
        {
            using (DBEntities db = new DBEntities())
            {
              
                List<Question> All = db.Questions.Where(x => x.MultipleChoise == true).ToList();
                All.AddRange(db.Questions.Where(x => x.MultipleChoise == false).ToList());
                Q = All[Next - 1];
                QNumber = Next;

                Responses = new List<Response>();
                foreach (QuestionResponse qr in db.QuestionResponses)
                {
                    if (qr.QuestionID == Q.Id)
                    {
                        Responses.Add(db.Responses.Where(x => x.Id == qr.ResponseID).FirstOrDefault());
                    }
                }
            }
            SelectedResponseId = 0;

        }
    }
}