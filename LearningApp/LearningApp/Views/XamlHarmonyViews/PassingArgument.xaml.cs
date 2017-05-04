using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningApp.Views.XamlHarmony
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PassingArgument : ContentPage
    {
        public PassingArgument()
        {
            InitializeComponent();
            this.BackgroundColor = Color.Black;
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
        }
        bool OnTimerTick()
        {
            DateTime dt = DateTime.Now;

            timeLabel.Text = dt.ToString("T");
            dateLabel.Text = dt.ToString("D");
            return true;
        }
    }
}
