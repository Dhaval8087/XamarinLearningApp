using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using LearningApp.iOS;
using LearningApp.Extension;

[assembly: ExportRenderer(typeof(CustomeSlider),typeof(CustomeSliderRenderer))]
namespace LearningApp.iOS
{
    public class CustomeSliderRenderer : SliderRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;
            
            Control.MinimumTrackTintColor = UIColor.Red;
            Control.MaximumTrackTintColor = UIColor.Green;
            Control.SetThumbImage(UIImage.FromBundle("Icon-Small.png"), UIControlState.Normal);

        }
    }
}