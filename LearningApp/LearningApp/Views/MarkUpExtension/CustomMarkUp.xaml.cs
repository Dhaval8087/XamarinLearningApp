using LearningApp.DeviceSpecial;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views.MarkUpExtension
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomMarkUp : ContentPage
    {
        public CustomMarkUp()
        {
            InitializeComponent();
        }
        public CustomMarkUp(string SelectedLanguage)
        {
            CultureInfo cl = new CultureInfo(SelectedLanguage);
            DependencyService.Get<ILocalization>().SetCulture(cl);
            InitializeComponent();
        }
        public void SetCulture(string SelectedLanguage)
        {
            CultureInfo cl = new CultureInfo(SelectedLanguage);
            DependencyService.Get<ILocalization>().SetCulture(cl);
        }
    }
}
