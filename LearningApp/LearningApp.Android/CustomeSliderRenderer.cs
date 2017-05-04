using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LearningApp.Extension;
using LearningApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Android.Graphics;

[assembly: ExportRenderer(typeof(CustomeSlider), typeof(CustomeSliderRenderer))]
namespace LearningApp.Droid
{
    class CustomeSliderRenderer: SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;
            
            
            Control.SetThumb(Resources.GetDrawable("icon.png"));
            //Control.TickMarkTintMode = PorterDuff.Mode.Darken;
            

            /*Control.MinimumTrackTintColor = UIColor.Red;
            Control.MaximumTrackTintColor = UIColor.Green;
            Control.SetThumbImage(UIImage.FromBundle("Icon-Small.png"), UIControlState.Normal);*/

        }
    }
}