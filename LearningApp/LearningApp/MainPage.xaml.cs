using LearningApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LearningApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainPageViewModel mv = new MainPageViewModel();
            mv.Navigation = Navigation;
            BindingContext = mv;
            
        }
    }
}
