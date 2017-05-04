using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LearningApp.DeviceSpecial;
using Xamarin.Forms;
using System.Threading;

[assembly: Dependency(typeof(LearningApp.Droid.Localization))]
namespace LearningApp.Droid
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