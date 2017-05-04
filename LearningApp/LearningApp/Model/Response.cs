using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model
{
   public  class Response
    {
        public  bool ResultSuccess { get; set; }
        public  List<ResultMessage> resultMessages { get; set; }
    }
    public class ResultMessage
    {
        public string Key { get; set; }
        public string Message { get; set; }
    }
}
