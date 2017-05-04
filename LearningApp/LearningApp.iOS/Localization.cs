using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using LearningApp.DeviceSpecial;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(LearningApp.iOS.Localization))]
namespace LearningApp.iOS
{
    public class Localization : ILocalization
    {
        public CultureInfo GetCurrentCulture()
        {
            //var netLanguage = "en";
            //var androidLocale = Java.Util.Locale.Default;
            //var netLanguage = Thread.CurrentThread.CurrentCulture; //androidLocale.ToString().Replace("_", "-");
            // this gets called a lot - try/catch can be expensive so consider caching or something
            System.Globalization.CultureInfo ci = null;
            try
            {
                ci = new System.Globalization.CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
            }
            catch (CultureNotFoundException e1)
            {

            }
            return ci;
        }

        public void SetCulture(CultureInfo ci)
        {
            Thread.CurrentThread.CurrentCulture = ci;
        }
    }
}