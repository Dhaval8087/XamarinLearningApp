using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.Model
{
    public class PayCodeResponse:Response
    {
        private List<PayCodeInfo> payCodeInfoList;

        public PayCodeResponse()
        {
            payCodeInfoList = new List<PayCodeInfo>();
        }

        public List<PayCodeInfo> PayCodeInfoList
        {
            get { return payCodeInfoList; }
            set { payCodeInfoList = value; }
        }
    }
    public class PayCodeInfo
    {
        public int ProjID { get; set; }
        public int PayCodeID { get; set; }
        public string PayCodeName { get; set; }
        public string PayRate { get; set; }
        public string BillRate { get; set; }
        public string PayCodeDesc { get; set; }
        public string TimesheetUnits { get; set; }
        public string ZCBillRate { get; set; }
        public string CustomerBillRate { get; set; }
        public string SupplierRate { get; set; }
        public string PayRate_dv { get; set; }
        public string PayUnit { get; set; }

        //Fix for ZMOB-2297 -- added workable to identify sick/lunch time to disable meal break toggle button
        public bool IsMealBreakToggleSwitchVisible { get; set; }
        public bool IsUnitsDropdownVisibleForPeriodicDetail { get; set; }

        ///Fix for ZMOB-2997
        public int PayCodeRateTypeID { get; set; }

        //ZMOB-3014
        public string UnitHeader { get; set; }

    }
}
