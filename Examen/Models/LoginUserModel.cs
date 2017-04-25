using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models
{
    public class LoginUserModel
    {
        public string UserID { get; set; }
        public string Pass { get; set; }

        public LoginUserModel()
        {
            UserID = "JL4W8452";
            Pass = "kldsjlksa5423351";
        }
    }
}