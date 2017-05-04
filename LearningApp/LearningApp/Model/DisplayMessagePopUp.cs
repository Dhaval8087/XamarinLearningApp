using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model
{
    public class DisplayMessagePopUp
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public string OKCancel { get; set; }
        public DisplayMessagePopUp(string title,string message,string okcancel)
        {
            this.Title = title;
            this.Message = message;
            this.OKCancel = okcancel;
        }
    }
}
