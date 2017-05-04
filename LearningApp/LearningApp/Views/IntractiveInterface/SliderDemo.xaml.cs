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
    public partial class SliderDemo : ContentPage
    {
        public SliderDemo()
        {
            InitializeComponent();
            
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            slidervalue.Text = Math.Round(Convert.ToDecimal(e.NewValue),2).ToString();
        }

        private void CustomeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            nativeslidervalue.Text = Math.Round(Convert.ToDecimal(e.NewValue), 2).ToString();
        }
    }
}
