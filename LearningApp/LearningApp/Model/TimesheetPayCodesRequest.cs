using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model
{
    public class TimesheetPayCodesRequest : Request
    {
        public int TimesheetID { get; set; }
        public int ProjectID { get; set; }
        public DateTime TimesheetEndingDate { get; set; }
        public int TimesheetTypeID { get; set; }
        public DateTime TheDate { get; set; }
    }
}
