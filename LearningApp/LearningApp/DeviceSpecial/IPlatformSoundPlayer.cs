using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningApp.DeviceSpecial
{
    public interface IPlatformSoundPlayer
    {
        void PlaySound(int samplingRate, byte[] soundData);
    }
}
