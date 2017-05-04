using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model
{
    public class LoggedonUser
    {
        public int userID { get; set; }
        public int userType { get; set; }
        public int userPreferredLanguageID { get; set; }
        public int userPreferredCNLanguageID { get; set; }
        public string userPreferredLanguageName { get; set; }
        public string userPreferredTimeZoneName { get; set; }
        public string userName { get; set; }
        public string zcwUserID { get; set; }
        public string userCulture { get; set; }
        public string userGUID { get; set; }
        public string userPreferredTimeZoneID { get; set; }
    }
}
