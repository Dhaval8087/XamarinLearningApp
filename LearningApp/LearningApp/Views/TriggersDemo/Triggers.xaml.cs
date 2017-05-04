using LearningApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views.TriggersDemo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Triggers : ContentPage
    {
        public Triggers()
        {
            InitializeComponent();
            TriggersViewModel vm = new TriggersViewModel();
            vm.Navigation = Navigation;
            this.BindingContext = vm;
        }
    }
}
