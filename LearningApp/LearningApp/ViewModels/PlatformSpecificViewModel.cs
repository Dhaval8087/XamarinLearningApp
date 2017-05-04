using GalaSoft.MvvmLight;
using LearningApp.DeviceSpecial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using GalaSoft.MvvmLight.Command;
namespace LearningApp.ViewModels
{
    public class PlatformSpecificViewModel : ViewModelBase
    {
        #region Varibale Declaration
        const int samplingRate = 22050;
        #endregion

        #region Constructor
        public PlatformSpecificViewModel()
        {
            IPlatformInfo platformInfo = DependencyService.Get<IPlatformInfo>();
            ModelName = platformInfo.GetModel();
            VersionName = platformInfo.GetVersion();
            ButtonText = "Start Sound";
        }
        #endregion

        #region Properties
        public INavigation Navigation { get; set; }
        public bool isStart = true;
        private string _ModelName;

        public string ModelName
        {
            get { return _ModelName; }
            set { _ModelName = value; RaisePropertyChanged(); }
        }
        private string _VersionName;

        public string VersionName
        {
            get { return _VersionName; }
            set { _VersionName = value; RaisePropertyChanged(); }
        }
        private string _ButtonText;

        public string ButtonText
        {
            get { return _ButtonText; }
            set { _ButtonText = value; RaisePropertyChanged(); }
        }

        #endregion

        #region Commands
        private RelayCommand _PlaySound;

        public RelayCommand PlaySound
        {
            get { return _PlaySound ?? (_PlaySound = new RelayCommand(PlaySoundClick)); }
            set { _PlaySound = value; }
        }
       


        #endregion

        #region Private Methods
        private void PlaySoundClick()
        {
            if(ButtonText== "Stop Sound")
            {
                isStart = false;
                ButtonText = "Play Sound";
            }
            else
            {
                ButtonText = "Stop Sound";
                isStart = true;
            }
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                double frequency = 440;
                int duration = 250;
                short[] shortBuffer = new short[samplingRate * duration / 1000];
                double angleIncrement = frequency / samplingRate;
                double angle = 0; // normalized 0 to 1 
                for (int i = 0; i < shortBuffer.Length; i++)
                {
                    double sample; // 0 to 1 
                    if (angle < 0.25)
                        sample = 4 * angle; // 1 to -1 
                    else if (angle < 0.75)
                        sample = 4 * (0.5 - angle); // -1 to 0 
                    else sample = 4 * (angle - 1);
                    shortBuffer[i] = (short)(32767 * sample);
                    angle += angleIncrement;
                    while (angle > 1) angle -= 1;
                }
                byte[] byteBuffer = new byte[2 * shortBuffer.Length];
                Buffer.BlockCopy(shortBuffer, 0, byteBuffer, 0, byteBuffer.Length);
                DependencyService.Get<IPlatformSoundPlayer>().PlaySound(samplingRate, byteBuffer);
                return isStart;
            });
              
        }
        #endregion




    }
}
