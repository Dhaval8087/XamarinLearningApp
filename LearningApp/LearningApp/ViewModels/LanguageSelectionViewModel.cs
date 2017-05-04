using GalaSoft.MvvmLight;
using LearningApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningApp.Uitility;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using LearningApp.Views;
using LearningApp.Views.MarkUpExtension;

namespace LearningApp.ViewModels
{
    public class LanguageSelectionViewModel:ViewModelBase
    {
        public LanguageSelectionViewModel()
        {
            Languages.Add(new Language { Name = "English", code = "en" });
            Languages.Add(new Language { Name = "German", code = "de" });
            LanguageNames = Languages.Select(p => p.Name).ToObservableCollection();
        }
        private ObservableCollection<string> _LanguageNames=new ObservableCollection<string>();

        public ObservableCollection<string> LanguageNames
        {
            get { return _LanguageNames; }
            set { _LanguageNames = value; RaisePropertyChanged(); }
        }

        public INavigation Navigation { get; set; }

        private ObservableCollection<Language> _Language=new ObservableCollection<Language>();

        public ObservableCollection<Language> Languages
        {
            get { return _Language; }
            set { _Language = value; RaisePropertyChanged(); }
        }

        private string _SelectedCat;

        public string SelectedCat
        {
            get { return _SelectedCat; }
            set { _SelectedCat = value;RaisePropertyChanged(); }
        }

        private RelayCommand _Go;

        public RelayCommand Go
        {
            get { return _Go ?? (_Go = new RelayCommand(()=> {
                var languageCode = Languages.Where(p => p.Name == SelectedCat).FirstOrDefault().code;
                CustomMarkUp xe = new CustomMarkUp(languageCode);
                Navigation.PushAsync(xe);

             })); }
            set { _Go = value; }
        }


    }
}
