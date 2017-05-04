using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using LearningApp.DeviceSpecial;
using AudioToolbox;
using Xamarin.Forms;
using LearningApp.iOS;

[assembly: Dependency(typeof(PlatformSoundPlayer))]
namespace LearningApp.iOS
{
    public class PlatformSoundPlayer : IPlatformSoundPlayer
    {

        public void PlaySound(int samplingRate, byte[] soundData)
        {
            UIAlertView alert = new UIAlertView();
            alert.Message = "Check Audio";
            alert.Show();
        }
    }
}