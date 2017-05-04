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
    public partial class PlatformSpecific : ContentPage
    {
        public PlatformSpecific()
        {
            InitializeComponent();
            PlatformSpecificViewModel ps = new PlatformSpecificViewModel();
            ps.Navigation = Navigation;
            BindingContext = ps;
        }
    }

}
