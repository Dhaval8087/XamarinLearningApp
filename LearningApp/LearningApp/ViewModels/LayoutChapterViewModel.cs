using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using LearningApp.Views.AbsoluteLayoutPanel;

namespace LearningApp.ViewModels
{
    public class LayoutChapterViewModel:ViewModelBase
    {
        #region Property
        public INavigation Navigation { get; set; }
        #endregion
        #region Command
        private RelayCommand<string> _AbsoluteCommand;

        public RelayCommand<string> AbsoluteCommand
        {
            get { return _AbsoluteCommand ?? (_AbsoluteCommand = new RelayCommand<string>((value) =>
              {
                  switch (value)
                  {
                      case "layoutattached":
                          Navigation.PushAsync(new AbsoluteLayoutBasic());
                          break;
                      case "layoutflags":
                          Navigation.PushAsync(new LayoutFlags());
                          break;
                      default:
                          break;
                  }
              })); }
            set { _AbsoluteCommand = value; }
        }

        #endregion
    }
}
