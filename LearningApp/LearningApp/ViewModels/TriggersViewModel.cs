using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using LearningApp.Views.TriggersDemo;

namespace LearningApp.ViewModels
{
    public class TriggersViewModel : ViewModelBase
    {
        public TriggersViewModel()
        {

        }
        #region Properties
        public INavigation Navigation { get; set; }
        private string _lblText = "Normal Focus Trigger";

        public string lblText
        {
            get { return _lblText; }
            set { _lblText = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; RaisePropertyChanged(); }
        }

        private string _EnterValue;

        public string EnterValue
        {
            get { return _EnterValue; }
            set { _EnterValue = value; RaisePropertyChanged(); }
        }

        #endregion
        #region Commands
        private RelayCommand<string> _TriggerCommand;

        public RelayCommand<string> TriggerCommand
        {
            get
            {
                return _TriggerCommand ?? (_TriggerCommand = new RelayCommand<string>((value) =>
                {
                    switch (value)
                    {
                        case "event":
                            EventsTriggers et = new EventsTriggers();
                            et.BindingContext = this;
                            Navigation.PushAsync(et);
                            break;
                        case "data":
                            DataTriggers dt = new DataTriggers();
                            dt.BindingContext = this;
                            Navigation.PushAsync(dt);
                            break;
                        default:
                            break;
                    }
                }));
            }
            set { _TriggerCommand = value; }
        }

      
        private RelayCommand _CheckCommand;

        public RelayCommand CheckCommand
        {
            get
            {
                return _CheckCommand ?? (_CheckCommand = new RelayCommand(() =>
                {
                    EnterValue = string.Format(" you have entered {0}", Name!=string.Empty?Name : "Nothing");
                }));
            }
            set { _CheckCommand = value; }
        }

        #endregion
    }
}
