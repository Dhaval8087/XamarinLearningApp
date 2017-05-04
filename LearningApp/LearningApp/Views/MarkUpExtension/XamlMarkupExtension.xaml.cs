using LearningApp.DeviceSpecial;
using LearningApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views
{
  
    public partial class XamlMarkupExtension : ContentPage
    {
        public XamlMarkupExtension()
        {
            InitializeComponent();
            XamlMarkupExtensionViewModel vm = new XamlMarkupExtensionViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
       
    }
}
