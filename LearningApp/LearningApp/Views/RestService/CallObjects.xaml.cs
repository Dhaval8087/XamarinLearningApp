using GalaSoft.MvvmLight.Messaging;
using LearningApp.Model;
using LearningApp.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views.RestService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CallObjects : ContentPage
    {
        public CallObjects()
        {
            InitializeComponent();
            
            Messenger.Default.Register<OpenClosePopUp>(this, OpenPopUp);
            Messenger.Default.Register<DisplayMessagePopUp>(this, ShowMessage);
            CallObjectsViewModel vm = new CallObjectsViewModel();
            
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
        private void OpenPopUp(OpenClosePopUp value)
        {
            if (value.isOpen)
            {
                PopupNavigation.PushAsync(new Credential());
            }
        }
        private void ShowMessage(DisplayMessagePopUp message)
        {
            DisplayAlert(message.Title, message.Message, message.OKCancel);
           

        }

        private void lst_ItemSelected()
        {
            lst.SelectedItem = null;
        }
    }
}
