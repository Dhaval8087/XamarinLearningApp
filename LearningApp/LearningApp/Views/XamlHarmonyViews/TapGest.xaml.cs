using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views.XamlHarmonyViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TapGest : ContentPage
    {
        public TapGest()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var Boxview = sender as BoxView;

            Random rnd = new Random();
            Boxview.Color = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            MainSt.BackgroundColor = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

        }
    }
}
