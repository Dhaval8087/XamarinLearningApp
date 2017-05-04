using LearningApp.DeviceSpecial;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(LearningApp.iOS.PlatformInfo))]
namespace LearningApp.iOS
{
    public class PlatformInfo : IPlatformInfo
    {

        public string GetModel()
        {


            return string.Format("{0} {1}", new UIDevice().SystemName, new UIDevice().Model);
        }

        public string GetVersion()
        {
            return new UIDevice().SystemVersion.ToString();
        }
    }
}