using LearningApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScrollingStack : ContentPage
    {
        public ScrollingStack()
        {
            InitializeComponent();
            ScrollingStackViewModel sv = new ScrollingStackViewModel();
            sv.Navigation = Navigation;
            BindingContext = sv;
           
        }
    }
}
