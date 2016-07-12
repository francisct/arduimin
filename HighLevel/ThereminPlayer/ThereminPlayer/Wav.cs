
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace ThereminPlayer
{

    class Wav
    {
        SoundEffectInstance soundInstance;


        string wavFile;
        public bool halfPitch;

        public Wav(string wavFile)
        {
            setWav(wavFile);
            halfPitch = false;
        }

        public void setWav(string wav)
        {
            bool wasPlaying = false;
            if (soundInstance != null && soundInstance.State == SoundState.Playing)
            {
                Stop();
                wasPlaying = true;
            }
            this.wavFile = wav;
            var soundfile = TitleContainer.OpenStream(wavFile);
            var soundEffect = SoundEffect.FromStream(soundfile);
            soundInstance = soundEffect.CreateInstance();
            soundInstance.IsLooped = true;

            if (wasPlaying)
            {
                Play();
            }
        }

        public void Play()
        {
            soundInstance.Play();
        }

        public void Stop()
        {
            soundInstance.Stop();
        }

        public void ApplyPitchShifting(float pitchShift)
        {
            if (pitchShift > 1)
            {
                pitchShift = pitchShift / 1000;
            }

            if (!halfPitch) {
                soundInstance.Pitch = (pitchShift * 2) - 1f;
            }
            else
            {
                soundInstance.Pitch = pitchShift;
            }
            
        }
    }
}
