using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model
{
    public class TimesheetRequest:Request
    {
        public int contactID { get; set; }
        public int resourceID { get; set; }
        public int pageSize { get; set; }
        public int offset { get; set; }
    }
    
   
}
