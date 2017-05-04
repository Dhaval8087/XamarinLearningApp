using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using LearningApp.Views.IntractiveInterface;

namespace LearningApp.ViewModels
{
    public class InteractiveChapterViewModel : ViewModelBase
    {
        #region Property
        public INavigation Navigation { get; set; }
        #endregion
        #region Command
        private RelayCommand<string> _Interactive;

        public RelayCommand<string> Interactive
        {
            get
            {
                return _Interactive ?? (_Interactive = new RelayCommand<string>((value) =>
                {
                    switch (value)
                    {
                        case "slider":
                            Navigation.PushAsync(new SliderDemo());
                            break;
                        case "choosingkeyboard":
                            Navigation.PushAsync(new ChoosingKeyboard());
                            break;
                        case "editor":
                            Navigation.PushAsync(new Views.IntractiveInterface.Editor());
                            break;
                        default:
                            break;
                    }
                }));
            }
            set { _Interactive = value; }
        }

        #endregion
    }
}
