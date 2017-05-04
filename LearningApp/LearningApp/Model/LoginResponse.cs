﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model
{
    public class LoginResponse:Response
    {
        public string EmailAddress { get; set; }
        public string FullName { get; set; }
        public string AuthToken { get; set; }
        public string UserType { get; set; }
        public int UserTypeID { get; set; }
        public int ClientID { get; set; }
        public int ResourceID { get; set; }
        public int PreferredLanguageID { get; set; }
        public int ContactID { get; set; }
        public Guid UserID { get; set; }
        public int UserPreferredCNLanguageID { get; set; }
        public int VendorID { get; set; }
        public string EmpClassID { get; set; }
       
        public bool IsEnabledLivePerson { get; set; }
        public int EnrollStatusID { get; set; }
        public string LoggedInUserProfileImageName { get; set; }
        public bool? IsSubscribed { get; set; }
        public bool IsAnEnrollmentActive { get; set; }
        public bool IsAnEnrollmentPending { get; set; }
        public string UserPreferredTimeZoneName { get; set; }
        public string UserPreferredLanguageName { get; set; }
        public string ZCWUserID { get; set; }
        public string UserPreferredTimeZone { get; set; }
        public string UserCulture { get; set; }
       
    }
}
