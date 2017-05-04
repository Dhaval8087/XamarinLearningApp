using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using LearningApp.Services;
using Newtonsoft.Json;
using LearningApp.Model;
using Rg.Plugins.Popup.Services;
using LearningApp.Views.RestService;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace LearningApp.ViewModels
{
    public class CredentialViewModel : ViewModelBase
    {
        CallWebService service;
        public CredentialViewModel()
        {
            service = new CallWebService();
        }

        #region Property

        private string _EmailAddress = "wle@billenglish.com";

        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { _EmailAddress = value; RaisePropertyChanged(); }
        }
        private string _Password = "rspl123#";

        public string Password
        {
            get { return _Password; }
            set { _Password = value; RaisePropertyChanged(); }
        }
        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set { _IsBusy = value; RaisePropertyChanged(); }
        }
        private string _Error;

        public string Error
        {
            get { return _Error; }
            set { _Error = value; RaisePropertyChanged(); }
        }


        #endregion
        #region Command
        private RelayCommand _Login;

        public RelayCommand Login
        {
            get { return _Login ?? (_Login = new RelayCommand(LoginCommand)); }
            set { _Login = value; }
        }

        private RelayCommand _Cancel;

        public RelayCommand Cancel
        {
            get
            {
                return _Cancel ?? (_Cancel = new RelayCommand(() =>
                {
                    Messenger.Default.Send<OpenClosePopUp>(new OpenClosePopUp { isOpen = false });
                }));
            }
            set { _Cancel = value; }
        }

        #endregion
        #region Private methods
        private async void LoginCommand()
        {
            IsBusy = true;
            await service.CallLoginService(EmailAddress, Password, (result) =>
           {

               IsBusy = false;

               var loginresponse = JsonConvert.DeserializeObject<LoginResponse>(result);
               if (loginresponse.ResultSuccess)
               {
                   Messenger.Default.Send<OpenClosePopUp>(new OpenClosePopUp { isOpen = false });
                   App.isValid = true;
                   App.LoginResponse = JsonConvert.DeserializeObject<LoginResponse>(result);
                   GenerateLoggedOnUser();
                   Messenger.Default.Send<string>("Load Data");
               }
               else
               {
                   Error = loginresponse.resultMessages.FirstOrDefault().Message;
               }


           });
        }
        private void GenerateLoggedOnUser()
        {
            LoggedonUser log = new LoggedonUser();
            log.userCulture = App.LoginResponse.UserCulture;
            log.userGUID = App.LoginResponse.UserID.ToString();
            log.userID = App.LoginResponse.ContactID > 0 ? App.LoginResponse.ContactID : App.LoginResponse.ResourceID;
            log.userName = App.LoginResponse.EmailAddress;
            log.userPreferredCNLanguageID = App.LoginResponse.UserPreferredCNLanguageID;
            log.userPreferredLanguageID = App.LoginResponse.UserPreferredCNLanguageID;
            log.userPreferredLanguageName = App.LoginResponse.UserPreferredLanguageName;
            log.userPreferredTimeZoneID = App.LoginResponse.UserPreferredTimeZone;
            log.userPreferredTimeZoneName = App.LoginResponse.UserPreferredTimeZoneName;
            log.userType = App.LoginResponse.UserTypeID;
            log.zcwUserID = App.LoginResponse.ZCWUserID;
            App.LoggedonUser = log;

        }
        #endregion
    }
}
