using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LearningApp.Views;
using LearningApp.Views.AbsoluteLayoutPanel;
using LearningApp.Views.IntractiveInterface;
using LearningApp.Views.RestService;
using LearningApp.Views.XamlHarmonyViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LearningApp.ViewModels
{
    public class MainPageViewModel:ViewModelBase
    {
        private RelayCommand<string> _ScrollingTab;

        public RelayCommand<string> ScrollingTab
        {
            get { return _ScrollingTab ?? (_ScrollingTab = new RelayCommand<string>(ScrollingStack)); }
            set { _ScrollingTab = value; }
        }
        private INavigation _Navigation;

        public INavigation Navigation
        {
            get { return _Navigation; }
            set { _Navigation = value; }
        }



        #region private methods
        private void ScrollingStack(string LessionName)
        {
            switch (LessionName)
            {
                case "ScrollingTab":
                    Navigation.PushAsync(new ScrollingStack());
                    break;
                case "ButtonClick":
                    Navigation.PushAsync(new ButtonClick());
                    break;
                case "PlateformSpecific":
                    Navigation.PushAsync(new PlatformSpecific());
                    break;
                case "XAMLMarkup":
                    Navigation.PushAsync(new XamlMarkupExtension());
                    break;
                case "XAMLHarmony":
                    Navigation.PushAsync(new XamlHarmony());
                    break;
                case "Bindable":
                    Navigation.PushAsync(new BindableProp());
                    break;
                case "RestService":
                    Navigation.PushAsync(new CallObjects());
                    break;
                case "Absolutelayout":
                    Navigation.PushAsync(new LayoutChapter());
                    break;
                case "Interactiveinterface":
                    Navigation.PushAsync(new InteractiveChapter());
                    break;
                case "alert":
                    Navigation.PushAsync(new AlertDemo());
                    break;
                default:
                    break;
            }
           
        }
        #endregion

    }
}
