﻿using System;
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

        public QuestionnaireModel(bool EfficientUI)
        {
            using (DBEntities db = new DBEntities()){
                AllQuestions = db.Questions.ToList();
            }
            Efficient = EfficientUI;
        }
    }
}