using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model
{
   public class TimesheetResponse:Response
    {
      
        private List<Timesheet> _Timesheets;

        public List<Timesheet> Timesheets
        {
            get { return _Timesheets; }
            set { _Timesheets = value; }
        }
        public int RecordCount { get; set; }
    }
    public class Timesheet
    {
        public int ProjectID { get; set; }
        public int TimesheetID { get; set; }
        public string ResourceCodeResourceID { get; set; }
        public string ResourceName { get; set; }
        public string ProjectName { get; set; }
        public string PeriodEnding { get; set; }
        public string PayAmount { get; set; }
        public string TimesheetPayAmount { get; set; }
        public string ZcBillAmount { get; set; }
        public int? Adjusted { get; set; }
        public bool IsApprovalReady { get; set; }
        public string SubmitDate { get; set; }
        public string Units { get; set; }
        public int ProjStatusID { get; set; }
        public string ProjStatus { get; set; }
        public int ResourceID { get; set; }
        public string Status { get; set; }
        public int TimeStatusID { get; set; }
        public string BillCurrencyCode { get; set; }
        public string PayCurrencyCode { get; set; }
        public string TotalAmount { get; set; }
        public bool IsLastTimesheet { get; set; }
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public int? VendorID { get; set; }
        public string TotalHours { get; set; }
       
        public bool SickTimeAccrualTracking { get; set; }
        public string BusinessUnit { get; set; }
    }
}
