using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using LearningApp.Services;
using Rg.Plugins.Popup.Services;
using LearningApp.Views.RestService;
using GalaSoft.MvvmLight.Messaging;
using LearningApp.Model;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Collections.ObjectModel;
using LearningApp.Uitility;
using Xamarin.Forms;
using XLabs.Forms.Controls;
using GalaSoft.MvvmLight.Messaging;
namespace LearningApp.ViewModels
{
    public class CallObjectsViewModel : ViewModelBase
    {
        CallWebService service = null;
        public CallObjectsViewModel()
        {
            service = new CallWebService();
            Messenger.Default.Register<string>(this, LoadData);
            Messenger.Default.Register<LoadTimesheet>(this, LoadTimeSheet);
            DateboxColor = Color.FromHex("#3c9ece");
            PaycodeboxColor = Color.FromHex("#c1eaf6");
            IsDate = true;
            IsTrackCodelbl = true;
            IsDatelbl = false;
            IsPayCodelbl = true;
            ContentView ctn = new ContentView();
            Label ll = new Label();
            ll.Text = "BackEnd";
            ll.FontSize = 30;
            ctn.Content = ll;



        }

        #region Property

        public INavigation Navigation { get; set; }
        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set { _IsBusy = value; RaisePropertyChanged(); }
        }
        private Timesheet _SelectedTimesheet;

        public Timesheet SelectedTimesheet
        {
            get { return _SelectedTimesheet; }
            set { _SelectedTimesheet = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<Timesheet> _Timesheets = new ObservableCollection<Timesheet>();

        public ObservableCollection<Timesheet> Timesheets
        {
            get { return _Timesheets; }
            set { _Timesheets = value; RaisePropertyChanged(); }
        }
        private TimesheetDetailsResponse _TimesheetDetails;

        public TimesheetDetailsResponse TimesheetDetails
        {
            get { return _TimesheetDetails; }
            set { _TimesheetDetails = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<Manager> _ApprovalManagers;

        public ObservableCollection<Manager> ApprovalManagers
        {
            get { return _ApprovalManagers; }
            set { _ApprovalManagers = value; RaisePropertyChanged("ApprovalManagers"); }
        }
        private Manager _SelectedApprovalManager;

        public Manager SelectedApprovalManager
        {
            get { return _SelectedApprovalManager; }
            set { _SelectedApprovalManager = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<TimesheetEntry> _TimesheetsEntries;

        public ObservableCollection<TimesheetEntry> TimesheetsEntries
        {
            get { return _TimesheetsEntries ?? (_TimesheetsEntries = new ObservableCollection<TimesheetEntry>()); }
            set { _TimesheetsEntries = value; RaisePropertyChanged(); }
        }


        private Color _DateboxColor;

        public Color DateboxColor
        {
            get { return _DateboxColor; }
            set { _DateboxColor = value; RaisePropertyChanged(); }
        }
        private Color _PaycodeboxColor;

        public Color PaycodeboxColor
        {
            get { return _PaycodeboxColor; }
            set { _PaycodeboxColor = value; RaisePropertyChanged(); }
        }

        private bool _IsDate;

        public bool IsDate
        {
            get { return _IsDate; }
            set { _IsDate = value; RaisePropertyChanged(); }
        }
        private bool _IsPayCode = false;

        public bool IsPayCode
        {
            get { return _IsPayCode; }
            set { _IsPayCode = value; RaisePropertyChanged(); }
        }

        private bool _IsTrackCode;

        public bool IsTrackCode
        {
            get { return _IsTrackCode; }
            set { _IsTrackCode = value; RaisePropertyChanged(); }
        }
        private bool _IsTrackCodelbl;

        public bool IsTrackCodelbl
        {
            get { return _IsTrackCodelbl; }
            set { _IsTrackCodelbl = value; RaisePropertyChanged(); }
        }
        private bool _IsPayCodelbl;

        public bool IsPayCodelbl
        {
            get { return _IsPayCodelbl; }
            set { _IsPayCodelbl = value; RaisePropertyChanged(); }
        }

        private bool _IsDatelbl;

        public bool IsDatelbl
        {
            get { return _IsDatelbl; }
            set { _IsDatelbl = value; RaisePropertyChanged(); }
        }
        private ContentView _TimesheetEntryContent;

        public ContentView TimesheetEntryContent
        {
            get { return _TimesheetEntryContent; }
            set { _TimesheetEntryContent = value; RaisePropertyChanged(); }
        }

        #endregion

        #region Command

        private RelayCommand _ApprovalManageFocused;

        public RelayCommand ApprovalManageFocused
        {
            get { return _ApprovalManageFocused ?? (_ApprovalManageFocused = new RelayCommand(LoadApprovalManager)); }
            set { _ApprovalManageFocused = value; }
        }

        private RelayCommand<string> _ShowObjectValues;

        public RelayCommand<string> ShowObjectValues
        {
            get { return _ShowObjectValues ?? (ShowObjectValues = new RelayCommand<string>(ShowObjectMethod)); }
            set { _ShowObjectValues = value; }
        }

        private RelayCommand _TimesheetSelected;

        public RelayCommand TimesheetSelected
        {
            get { return _TimesheetSelected ?? (_TimesheetSelected = new RelayCommand(TimesheetSelectedMethod)); }
            set { _TimesheetSelected = value; }
        }
        private RelayCommand _ApprovalManagerSelected;

        public RelayCommand ApprovalManagerSelected
        {
            get { return _ApprovalManagerSelected ?? (_ApprovalManagerSelected = new RelayCommand(ApprovalManageSelectedMethod)); }
            set { _ApprovalManagerSelected = value; }
        }
        private RelayCommand<string> _TapCommand;

        public RelayCommand<string> TapCommand
        {
            get { return _TapCommand ?? (_TapCommand = new RelayCommand<string>(TappedMethod)); }
            set { _TapCommand = value; }
        }
        private RelayCommand _AddTimesheet;

        public RelayCommand AddTimesheet
        {
            get { return _AddTimesheet ?? (_AddTimesheet = new RelayCommand(AddTimesheetMethod)); }
            set { _AddTimesheet = value; }
        }

        private RelayCommand _LogoutCommand;

        public RelayCommand LogoutCommand
        {
            get
            {
                return _LogoutCommand ?? (_LogoutCommand = new RelayCommand(() =>
                {
                    App.isValid = false;
                    App.LoginResponse = new LoginResponse();
                    Timesheets = new ObservableCollection<Timesheet>();
                }));
            }
            set { _LogoutCommand = value; }
        }




        #endregion

        #region Private Methods
        private void ShowObjectMethod(string Object)
        {
            switch (Object)
            {
                case "T":
                    if (!App.isValid)
                    {
                        Messenger.Default.Send<OpenClosePopUp>(new OpenClosePopUp { isOpen = true });
                        // PopupNavigation.PushAsync(new Credential());
                    }
                    else
                    {
                        LoadTimeSheetData();
                    }


                    break;
                default:
                    break;
            }
        }
        private void LoadData(string value)
        {
            if (value == "Load Data")
            {
                LoadTimeSheetData();
            }
        }
        private async void LoadTimeSheetData()
        {

            IsBusy = true;
            await service.CallFilterSearchTimesheetService((res) =>
            {
                IsBusy = false;
                TimesheetResponse response = JsonConvert.DeserializeObject<TimesheetResponse>(res);

                Timesheets = response.Timesheets.ToObservableCollection();
            });


        }

        private  void TimesheetSelectedMethod()
        {
           

            try
            {
                LoadTimesheetDetail(() =>
                {
                    var objDetails = new ObjectDetails();
                    objDetails.BindingContext = this;
                    Navigation.PushAsync(objDetails);
                });
               
            }
            catch (Exception ex)
            {

                var abc = ex.Message;
            }



        }
        private async void LoadTimesheetDetail(Action Callback)
        {
            await service.GetTimesheetDetailsRequest(SelectedTimesheet.TimesheetID, (res) =>
            {
                TimesheetDetails = JsonConvert.DeserializeObject<TimesheetDetailsResponse>(res);
                RaisePropertyChanged("TimesheerDetails");
                if(IsDate)
                {
                    TimesheetsEntries = TimesheetDetails.TimeSheetEntryList.OrderByDescending(p => p.TimesheetEntryDate).ToObservableCollection();
                }
                else if(IsPayCode)
                {
                    TimesheetsEntries = TimesheetDetails.TimeSheetEntryList.OrderByDescending(p => p.PayCodeName).ToObservableCollection();
                }
                
                Callback();
                
            });
        }
        private async void LoadApprovalManager()
        {
            var appManager = new ApprovalManagers();
            appManager.BindingContext = this;
            await Navigation.PushAsync(appManager);
            await service.GetApprovalManagersRequest(SelectedTimesheet.ProjectID, (res) =>
            {
                var approvalManager = JsonConvert.DeserializeObject<ApprovalManagerResponse>(res);
                ApprovalManagers = approvalManager.Managers.ToObservableCollection();
            });
        }
        private void ApprovalManageSelectedMethod()
        {

            Navigation.PopAsync(true);
            var SelectedApprovarManage = ApprovalManagers.Where(p => p.ManagerID == SelectedApprovalManager.ManagerID).FirstOrDefault();
            if (SelectedApprovalManager != null)
            {
                TimesheetDetails.ApprovalManager = SelectedApprovalManager.ManagerName;
                TimesheetDetails.ApprovalManagerId = SelectedApprovalManager.ManagerID;
                RaisePropertyChanged("TimesheetDetails");
            }


        }

        private void TappedMethod(string value)
        {
            switch (value)
            {
                case "Date":
                    App.Current.Resources["DateColor"] = Color.FromHex("#3c9ece");
                    App.Current.Resources["PayCode"] = Color.FromHex("#c1eaf6");
                    App.Current.Resources["TrackCode"] = Color.FromHex("#c1eaf6");
                    IsPayCode = false;
                    IsDate = true;
                    IsTrackCode = false;
                    IsTrackCodelbl = true;
                    IsDatelbl = false;
                    IsPayCodelbl = true;
                    break;
                case "PayCode":
                    App.Current.Resources["PayCode"] = Color.FromHex("#3c9ece");
                    App.Current.Resources["DateColor"] = Color.FromHex("#c1eaf6");
                    App.Current.Resources["TrackCode"] = Color.FromHex("#c1eaf6");
                    IsPayCode = true;
                    IsDate = false;
                    IsTrackCode = false;
                    IsTrackCodelbl = true;
                    IsDatelbl = true;
                    IsPayCodelbl = false;
                    break;
                case "TrackCode":
                    App.Current.Resources["TrackCode"] = Color.FromHex("#3c9ece");
                    App.Current.Resources["DateColor"] = Color.FromHex("#c1eaf6");
                    App.Current.Resources["PayCode"] = Color.FromHex("#c1eaf6");
                    IsTrackCode = true;
                    IsDate = false;
                    IsPayCode = false;
                    IsTrackCodelbl = false;
                    IsPayCodelbl = true;
                    IsDatelbl = true;

                    break;
                default:
                    break;
            }
        }
        void AddTimesheetMethod()
        {
            CreateObjectViewModel vm = new CreateObjectViewModel();
            TimesheetEntryDatesRequest RequestObject = new TimesheetEntryDatesRequest();
            RequestObject.TimesheetEndingDate = TimesheetDetails.EndDt;
            RequestObject.ProjectID = SelectedTimesheet.ProjectID;

            TimesheetPayCodesRequest requestpay = new TimesheetPayCodesRequest();
            requestpay.TimesheetID = SelectedTimesheet.TimesheetID;
            requestpay.TimesheetTypeID = TimesheetDetails.TimesheetTypeID.Value;
            requestpay.ProjectID = TimesheetDetails.ProjectID;
            requestpay.TimesheetEndingDate = TimesheetDetails.EndDt;

            ProjectTrackCodesRequest trackReq = new ProjectTrackCodesRequest();
            trackReq.ProjectID = SelectedTimesheet.ProjectID;
            trackReq.TimesheetEndingDate = TimesheetDetails.EndDt;
            trackReq.TimesheetID = SelectedTimesheet.TimesheetID;
            trackReq.Offset = 0;
            trackReq.PageSize = 10;


            vm.TimesheetPaycode = requestpay;
            vm.TimesheetEntryDate = RequestObject;
            vm.ProjTrackCode = trackReq;
            vm.TimesheetDetails = TimesheetDetails;
            vm.TimesheetDetails.TimesheetID = SelectedTimesheet.TimesheetID;
            vm.Navigation = Navigation;
            CreateObject co = new CreateObject();
            co.BindingContext = vm;
            Navigation.PushAsync(co);
        }
        void LoadTimeSheet(LoadTimesheet ld)
        {
            LoadTimesheetDetail(()=> { });
        }
        #endregion
    }
}
