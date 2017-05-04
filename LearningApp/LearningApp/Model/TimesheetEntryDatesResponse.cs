using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace LearningApp.Model
{
    public class TimesheetEntryDatesResponse:Response
    {
        private ObservableCollection<string> _timesheetEntryDates;

        public ObservableCollection<string> TimesheetEntryDates
        {
            get { return _timesheetEntryDates ?? (_timesheetEntryDates=new ObservableCollection<string>()); }
            set { _timesheetEntryDates = value; }
        }

    }
}
