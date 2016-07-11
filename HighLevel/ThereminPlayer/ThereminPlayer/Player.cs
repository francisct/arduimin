using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreAudioApi;

namespace ThereminPlayer
{
    private readonly MMDeviceEnumerator _deviceEnumerator = new MMDeviceEnumerator();
    private readonly MMDevice _playbackDevice;

    class Player
    {
        public Player(float volume, float pitch)
        {

        }

        public void SetVolume(int volumeLevel)
        {
            if (volumeLevel < 0 || volumeLevel > 100)
                throw new ArgumentException("Volume must be between 0 and 100!");

            _playbackDevice.AudioEndpointVolume.MasterVolumeLevelScalar = volumeLevel / 100.0f;
        }
    }
}
