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
using Xamarin.Forms;
using Android.Media;
using LearningApp.DeviceSpecial;

[assembly: Dependency(typeof(LearningApp.Droid.PlatformSoundPlayer))]
namespace LearningApp.Droid
{
    public class PlatformSoundPlayer: IPlatformSoundPlayer
    {
        AudioTrack previousAudioTrack;

        public void PlaySound(int samplingRate, byte[] soundData)
        {
            if (previousAudioTrack != null)
            {
                previousAudioTrack.Stop();
                previousAudioTrack.Release();
            }
            AudioTrack audioTrack = new AudioTrack(Stream.Music, 
                                                    samplingRate,
                                                    ChannelOut.Mono,
                                                    Android.Media.Encoding.Pcm16bit,
                                                    soundData.Length * sizeof(short),
                                                    AudioTrackMode.Static);
            audioTrack.Write(soundData, 0, soundData.Length);
            audioTrack.Play();
            previousAudioTrack = audioTrack;
        }
    }
}