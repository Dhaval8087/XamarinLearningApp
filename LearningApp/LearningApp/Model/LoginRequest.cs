using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model
{
    public class LoginRequest:Request
    {
       
        public string emailAddress { get; set; }
        public string password { get; set; }

    }
}
