using LearningApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LanguageSelection : ContentPage
    {
        public LanguageSelection()
        {
            InitializeComponent();
            LanguageSelectionViewModel vm = new LanguageSelectionViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }

        private void Span_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }
    }
}
