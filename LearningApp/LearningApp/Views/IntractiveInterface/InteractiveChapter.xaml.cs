using LearningApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views.IntractiveInterface
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InteractiveChapter : ContentPage
    {
        public InteractiveChapter()
        {
            InitializeComponent();
            InteractiveChapterViewModel vm = new InteractiveChapterViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}
