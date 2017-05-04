using LearningApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views.XamlHarmonyViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XamlHarmony : ContentPage
    {
        public XamlHarmony()
        {
            InitializeComponent();
            XamlHarmonyViewModel vm = new XamlHarmonyViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;
            /*Button x = new Button();
            x.Text = "Click Me";
            x.CommandParameter = "Test";
            x.Command = GetCommand();
            ss.Children.Add(x);*/

        }
        public ICommand GetCommand()
        {
            var commad = new Command<string>((val) =>
            {
                DisplayAlert("Title", val, "OK");
            });
            return commad;
        }
       

      
    }
}
