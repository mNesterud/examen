using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Examen.Models;

namespace Examen.Models
{
    public class QuestionnaireModel
    {
        public List<Question> AllQuestions { get; set; }
        public bool Efficient { get; set; }
        public int LastMultipleChoiceId { get; set; }
        public List<RQR> RQRList { get; set; }
        public List<RQT> RQTList { get; set; }

        public QuestionnaireModel(bool EfficientUI)
        {
            using (DBEntities db = new DBEntities()){
                AllQuestions = db.Questions.ToList();
            }

            foreach (Question q in AllQuestions)
            {
                if (q.MultipleChoise)
                {
                    LastMultipleChoiceId = q.Id;
                }
            }

            Efficient = EfficientUI;


            RQRList = new List<RQR>();
            RQTList = new List<RQT>();
        }
    }
}