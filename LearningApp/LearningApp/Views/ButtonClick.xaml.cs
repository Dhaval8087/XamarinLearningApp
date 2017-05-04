using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonClick : ContentPage
    {
        public ButtonClick()
        {
            InitializeComponent();
        }

        private void OnLeft_Clicked(object sender, EventArgs e)
        {
           
            greenBox.TranslationX = greenBox.TranslationX - 20;
        }

        private void OnRight_Clicked(object sender, EventArgs e)
        {
            greenBox.TranslationX = greenBox.TranslationX + 20;
        }

        private void OnTop_Clicked(object sender, EventArgs e)
        {
            greenBox.TranslationY = greenBox.TranslationY - 20;
        }

        private void OnDown_Clicked(object sender, EventArgs e)
        {
            greenBox.TranslationY = greenBox.TranslationY + 20;
        }
    }
}
