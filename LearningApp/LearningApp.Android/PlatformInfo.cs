using Android.OS;
using Xamarin.Forms;
using LearningApp.DeviceSpecial;


[assembly: Dependency(typeof(LearningApp.Droid.PlatformInfo))]
namespace LearningApp.Droid
{
    public class PlatformInfo : IPlatformInfo
    {
        
        public string GetModel()
        {
           

            return string.Format("{0} {1}", Build.Manufacturer, Build.Model);
        }

        public string GetVersion()
        {
            return Build.VERSION.Release.ToString();
        }
    }
}