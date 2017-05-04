using LearningApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views.AbsoluteLayoutPanel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LayoutChapter : ContentPage
    {
        public LayoutChapter()
        {
            InitializeComponent();
            LayoutChapterViewModel vm = new LayoutChapterViewModel();
            vm.Navigation = Navigation;
            BindingContext = vm;
        }
    }
}
