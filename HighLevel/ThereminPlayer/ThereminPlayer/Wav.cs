
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace ThereminPlayer
{

    class Wav
    {
        SoundEffectInstance soundInstance;


        string wavFile;
        

        public Wav(string wavFile)
        {
            this.wavFile = wavFile;
            var soundfile = TitleContainer.OpenStream(wavFile);
            var soundEffect = SoundEffect.FromStream(soundfile);
            soundInstance = soundEffect.CreateInstance();
        }

        public void Play()
        {
            soundInstance.Play();
        }

        public void ApplyPitchShifting(float pitchShift)
        {
            soundInstance.Pitch = pitchShift;
        }
    }
}
