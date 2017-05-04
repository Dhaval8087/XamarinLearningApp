using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LearningApp.Model;
using LearningApp.Services;
using LearningApp.Views.RestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using LearningApp.Uitility;
using GalaSoft.MvvmLight.Messaging;

namespace LearningApp.ViewModels
{
    public class CreateObjectViewModel:ViewModelBase
    {
        public TimesheetEntryDatesRequest TimesheetEntryDate { get; set; }
        public TimesheetPayCodesRequest TimesheetPaycode { get; set; }
        public ProjectTrackCodesRequest ProjTrackCode { get; set; }
        CallWebService service = null;
        public INavigation Navigation { get; set; }
        public TimesheetDetailsResponse TimesheetDetails { get; set; }
        public CreateObjectViewModel()
        {
            service = new CallWebService();
        }
        #region Property
        public string ObjectType { get; set; }
        private ObservableCollection<string> _ObjectCollection;

        public ObservableCollection<string> ObjectCollection
        {
            get { return _ObjectCollection ?? (_ObjectCollection=new ObservableCollection<string>()); }
            set { _ObjectCollection = value; RaisePropertyChanged(); }
        }
        private string _SelectedEntryObject;

        public string SelectedEntryObject
        {
            get { return _SelectedEntryObject; }
            set { _SelectedEntryObject = value;RaisePropertyChanged(); }
        }
        private string _SelectedEntryDate;

        public string SelectedEntryDate
        {
            get { return _SelectedEntryDate; }
            set { _SelectedEntryDate = value;RaisePropertyChanged(); }
        }

        private string _SelectedEntryPaycode;

        public string SelectedEntryPaycode
        {
            get { return _SelectedEntryPaycode; }
            set { _SelectedEntryPaycode = value;RaisePropertyChanged(); }
        }
        private string _SelectedEntryTrackcode;

        public string SelectedEntryTrackcode
        {
            get { return _SelectedEntryTrackcode; }
            set { _SelectedEntryTrackcode = value;RaisePropertyChanged(); }
        }
        public ObservableCollection<PayCodeInfo> PayCodeList { get; set; }
        public ObservableCollection<ProjectTrackCode> TrackCodeList { get; set; }

        private string _Units;

        public string Units
        {
            get { return _Units; }
            set { _Units = value;RaisePropertyChanged(); }
        }

        #endregion
        #region Command
        private RelayCommand<string> _TimesheetEntryDateFocus;

        public RelayCommand<string> TimesheetEntryDateFocus
        {
            get { return _TimesheetEntryDateFocus ?? new RelayCommand<string>(async (string value) =>
            {
                ObjectType = value;
                switch (ObjectType)
                {
                    case "Date":
                        await service.GetTimesheetEntryDatesRequest(TimesheetEntryDate, res =>
                        {
                            ObjectList lst = new ObjectList();
                            lst.BindingContext = this;
                            Navigation.PushAsync(lst);
                           
                          
                            ObjectCollection = JsonConvert.DeserializeObject<TimesheetEntryDatesResponse>(res).TimesheetEntryDates;
                        });
                        break;
                    case "Paycode":
                        
                        TimesheetPaycode.TheDate = Convert.ToDateTime(SelectedEntryDate);
                        await service.GetTimesheetPayCodesRequest(TimesheetPaycode, res =>
                        {
                            ObjectList lst = new ObjectList();
                            lst.BindingContext = this;
                            Navigation.PushAsync(lst);
                            PayCodeList = JsonConvert.DeserializeObject<PayCodeResponse>(res).PayCodeInfoList.ToObservableCollection();
                            ObjectCollection = PayCodeList.Select(p=>p.PayCodeName).ToObservableCollection();
                            
                        });
                        break;
                    case "Trackcode":
                        await service.GetProjectTrackCodesRequest(ProjTrackCode, res =>
                        {
                            ObjectList lst = new ObjectList();
                            lst.BindingContext = this;
                            Navigation.PushAsync(lst);
                            TrackCodeList = JsonConvert.DeserializeObject<ProjectTrackCodeResponse>(res).ProjectTrackCodes.ToObservableCollection();
                            ObjectCollection = TrackCodeList.Select(p => p.TrackCodeName).ToObservableCollection();
                        });
                        break;
                    default:
                        break;
                }
                
            }); }
            set { _TimesheetEntryDateFocus = value; }
        }
        private RelayCommand _ObjectEntrySelected;

        public RelayCommand ObjectEntrySelected
        {
            get { return _ObjectEntrySelected ?? new RelayCommand(()=> 
            {
                switch (ObjectType)
                {
                    case "Date":
                        SelectedEntryDate = SelectedEntryObject;
                        break;
                    case "Paycode":
                        SelectedEntryPaycode = SelectedEntryObject;
                        break;
                    case "Trackcode":
                        SelectedEntryTrackcode = SelectedEntryObject;
                        break;
                    default:
                        break;
                }
                Navigation.PopAsync();
            }); }
            set { _ObjectEntrySelected = value; }
        }

        private RelayCommand _SaveTimesheet;

        public RelayCommand SaveTimesheet
        {
            get { return _SaveTimesheet ?? (_SaveTimesheet = new RelayCommand(SaveTimesheetMethod)); }
            set { _SaveTimesheet = value; }
        }

        #endregion
        #region Private Method
        async void SaveTimesheetMethod()
        {
             TimesheetDetails.TimeSheetEntryList.Add(new TimesheetEntry()
             {
                 //PayCodeID=PayCodeList.Where(p=>p.)
                 PayCodeID=PayCodeList.Where(p=>p.PayCodeName==SelectedEntryPaycode).FirstOrDefault().PayCodeID,
                 PayCodeRateTypeID = 1,
                 TimesheetEntryDate = Convert.ToDateTime(SelectedEntryDate),
                 TrackCodeID = TrackCodeList.Where(p => p.TrackCodeName ==SelectedEntryTrackcode).FirstOrDefault().TrackCodeID,
                   Units=Units

             });
             SaveOrSubmitTimesheetRequest request = new SaveOrSubmitTimesheetRequest();
             request.PrimaryApprovalManagerID = TimesheetDetails.ApprovalManagerId;
             request.ActionTypeID = 1;
             request.EndDate = TimesheetDetails.EndDt;
             request.ProjectID = TimesheetDetails.ProjectID;
             request.ResourceID = TimesheetDetails.ResourceID;
             request.TimesheetID = TimesheetDetails.TimesheetID;
             request.timesheetEntries = TimesheetDetails.TimeSheetEntryList;

             await service.SaveorSubmitTimesheet(request, res =>
             {
                 var response = JsonConvert.DeserializeObject<SaveOrSubmitTimesheetResponse>(res);
                 if(response.ResultSuccess)
                 {
                    
                      Navigation.PopAsync();
                     Messenger.Default.Send<DisplayMessagePopUp>(new DisplayMessagePopUp("Success Message", response.resultMessages.FirstOrDefault().Message, "ok"));
                     Messenger.Default.Send<LoadTimesheet>(new LoadTimesheet());

                 }

             });

            
            
        }
        #endregion
    }
}
