using GalaSoft.MvvmLight;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
using LearningApp.Views.XamlHarmony;
using LearningApp.Views.XamlHarmonyViews;

namespace LearningApp.ViewModels
{
    public class XamlHarmonyViewModel : ViewModelBase
    {
        public INavigation Navigation { get; set; }

        private RelayCommand<string> _XamlHarmonyCommand;

        public RelayCommand<string> XamlHarmonyCommand
        {
            get { return _XamlHarmonyCommand ?? (_XamlHarmonyCommand = new RelayCommand<string>(XamlHarmony)); }
            set { _XamlHarmonyCommand = value; }
        }

        #region Private Method
        private void XamlHarmony(string pageName)
        {
            switch (pageName)
            {
                case "PassingArguments":
                    Navigation.PushAsync(new PassingArgument());
                    break;
                case "TapGest":
                    Navigation.PushAsync(new TapGest());
                    break;
                default:
                    break;
            }
        }
        #endregion

    }
}
