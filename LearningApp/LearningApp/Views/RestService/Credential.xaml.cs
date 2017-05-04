using LearningApp.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GalaSoft.MvvmLight.Messaging;
using LearningApp.Model;

namespace LearningApp.Views.RestService
{
   
    public partial class Credential : Rg.Plugins.Popup.Pages.PopupPage
    {
        public Credential()
        {
            InitializeComponent();
            Messenger.Default.Register<OpenClosePopUp>(this, ClosePopUp);
           
            CredentialViewModel vm = new CredentialViewModel();
            
            BindingContext = vm;
        }
        private void ClosePopUp(OpenClosePopUp value)
        {
            if (!value.isOpen)
            {
                PopupNavigation.RemovePageAsync(this);
            }
            
        }
        

    }
}
