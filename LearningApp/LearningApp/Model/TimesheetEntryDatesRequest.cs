using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model
{
    public class TimesheetEntryDatesRequest:Request
    {
        public DateTime TimesheetEndingDate { get; set; }
        public int ProjectID { get; set; }
    }
}
