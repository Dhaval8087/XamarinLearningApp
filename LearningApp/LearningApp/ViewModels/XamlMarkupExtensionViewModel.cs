using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using LearningApp.Views.MarkUpExtension;
using LearningApp.Views;

namespace LearningApp.ViewModels
{
    public class XamlMarkupExtensionViewModel:ViewModelBase
    {
        public string SelectedLanguage { get; set; }
        public INavigation Navigation { get; set; }

        private RelayCommand<string> _XamlMarkupCommand;

        public RelayCommand<string> XamlMarkupCommand
        {
            get { return _XamlMarkupCommand ?? (_XamlMarkupCommand = new RelayCommand<string> (XamlMarkupCommandClick)); }
            set { _XamlMarkupCommand = value; }
        }

        #region Private Method
        private void XamlMarkupCommandClick(string pageName)
        {
            switch (pageName)
            {
                case "AccessStatic":
                    Navigation.PushAsync(new AccessStaticMember());
                    break;
                case "CustomeMarkup":
                    Navigation.PushAsync(new LanguageSelection());
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
