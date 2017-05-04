using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model
{
    public class ApprovalManagerResponse:Response
    {
        private List<Manager> _Managers;

        public List<Manager> Managers
        {
            get { return _Managers ?? (_Managers=new List<Manager>()); }
            set { _Managers = value; }
        }

    }
    public class Manager
    {
        public string ManagerName { get; set; }
        public int ManagerID { get; set; }
    }
}
