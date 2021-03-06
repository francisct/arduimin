﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mike.Rules;
using System.IO;
using System.Media;
using NAudio.Wave;
using System.Threading;

namespace ThereminPlayer
{

    class Wav
    {

        string wavFile;
        string modifiedWavFile;
        // Read header, data and channels as separated data

        // Normalized data stores. Store values in the format -1.0 to 1.0
        byte[] waveheader = null;
        byte[] wavedata = null;

        int sampleRate = 0;

        float[] in_data_l = null;
        float[] in_data_r = null;

        byte[] copydata = null;

        public Wav(string wavFile)
        {
            this.wavFile = wavFile;
        }

        public void Reset()
        {
            if (File.Exists(wavFile))
            {
                GetWaveData(wavFile, out waveheader, out wavedata, out sampleRate, out in_data_l, out in_data_r);
            }
        }

        public void Play()
        {
            using (var wfr = new WaveFileReader(modifiedWavFile))
            using (WaveChannel32 wc = new WaveChannel32(wfr) { PadWithZeroes = false })
            using (var audioOutput = new DirectSoundOut())
            {
                audioOutput.Init(wc);

               audioOutput.Play();

                while (audioOutput.PlaybackState != PlaybackState.Stopped)
                {
                    Thread.Sleep(20);
                }

                audioOutput.Stop();
            }
                
            
        }

        public void ApplyPitchShifting(float pitchShift)
        {
            if (in_data_l != null)
                PitchShifter.PitchShift(pitchShift, in_data_l.Length, (long)1024, (long)10, sampleRate, in_data_l);

            if (in_data_r != null)
                PitchShifter.PitchShift(pitchShift, in_data_r.Length, (long)1024, (long)10, sampleRate, in_data_r);

        }

        public void BackupWaveData()
        {
            copydata = new byte[wavedata.Length];
            Array.Copy(wavedata, copydata, wavedata.Length);

            GetWaveData(in_data_l, in_data_r, ref wavedata);
        }

        public bool DidDataChange()
        {

            for (int i = 0; i < wavedata.Length; i++)
            {
                if (wavedata[i] != copydata[i])
                {
                    return true;
                    Console.WriteLine("Data has changed!");
                    break;
                }
            }return false;
        }

        public void SaveModifiedWavData()
        {
            string fileName = "out.wav";
            modifiedWavFile = Path.Combine(Environment.CurrentDirectory, @"Wavs\", fileName);

            
            string targetFilePath = modifiedWavFile;
            if (File.Exists(targetFilePath))
                try
                { File.Delete(targetFilePath);
                    using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(targetFilePath)))
                    {
                        writer.Write(waveheader);
                        writer.Write(wavedata);
                    }
                }
                catch(Exception e)
                {

                }

            
        }

        // Returns left and right float arrays. 'right' will be null if sound is mono.
        public static void GetWaveData(string filename, out byte[] header, out byte[] data, out int sampleRate, out float[] left, out float[] right)
        {
            byte[] wav = File.ReadAllBytes(filename);

            // Determine if mono or stereo
            int channels = wav[22];     // Forget byte 23 as 99.999% of WAVs are 1 or 2 channels

            // Get sample rate
            sampleRate = BitConverter.ToInt32(wav, 24);

            int pos = 12;

            // Keep iterating until we find the data chunk (i.e. 64 61 74 61 ...... (i.e. 100 97 116 97 in decimal))
            while (!(wav[pos] == 100 && wav[pos + 1] == 97 && wav[pos + 2] == 116 && wav[pos + 3] == 97))
            {
                pos += 4;
                int chunkSize = wav[pos] + wav[pos + 1] * 256 + wav[pos + 2] * 65536 + wav[pos + 3] * 16777216;
                pos += 4 + chunkSize;
            }

            pos += 4;

            int subchunk2Size = BitConverter.ToInt32(wav, pos);
            pos += 4;

            // Pos is now positioned to start of actual sound data.
            int samples = subchunk2Size / 2;     // 2 bytes per sample (16 bit sound mono)
            if (channels == 2)
                samples /= 2;        // 4 bytes per sample (16 bit stereo)

            // Allocate memory (right will be null if only mono sound)
            left = new float[samples];

            if (channels == 2)
                right = new float[samples];
            else
                right = null;

            header = new byte[pos];
            Array.Copy(wav, header, pos);

            data = new byte[subchunk2Size];
            Array.Copy(wav, pos, data, 0, subchunk2Size);

            // Write to float array/s:
            int i = 0;
            while (pos < subchunk2Size)
            {

                left[i] = BytesToNormalized_16(wav[pos], wav[pos + 1]);
                pos += 2;
                if (channels == 2)
                {
                    right[i] = BytesToNormalized_16(wav[pos], wav[pos + 1]);
                    pos += 2;
                }
                i++;
            }
        }

        // Return byte data from left and right float data. Ignore right when sound is mono
        public static void GetWaveData(float[] left, float[] right, ref byte[] data)
        {
            // Calculate k
            // This value will be used to convert float to Int16
            // We are not using Int16.Max to avoid peaks due to overflow conversions            
            float k = (float)Int16.MaxValue / left.Select(x => Math.Abs(x)).Max();

            // Revert data to byte format
            Array.Clear(data, 0, data.Length);
            int dataLenght = left.Length;
            int byteId = -1;
            using (BinaryWriter writer = new BinaryWriter(new MemoryStream(data)))
            {
                for (int i = 0; i < dataLenght; i++)
                {
                    byte byte1 = 0;
                    byte byte2 = 0;

                    byteId++;
                    NormalizedToBytes_16(left[i], k, out byte1, out byte2);
                    writer.Write(byte1);
                    writer.Write(byte2);

                    if (right != null)
                    {
                        byteId++;
                        NormalizedToBytes_16(right[i], k, out byte1, out byte2);
                        writer.Write(byte1);
                        writer.Write(byte2);
                    }
                }
            }
        }

        // Convert two bytes to one double in the range -1 to 1
        static float BytesToNormalized_16(byte firstByte, byte secondByte)
        {
            // convert two bytes to one short (little endian)
            short s = (short)((secondByte << 8) | firstByte);
            // convert to range from -1 to (just below) 1
            return s / 32678f;
        }

        // Convert a float value into two bytes (use k as conversion value and not Int16.MaxValue to avoid peaks)
        static void NormalizedToBytes_16(float value, float k, out byte firstByte, out byte secondByte)
        {
            short s = (short)(value * k);
            firstByte = (byte)(s & 0x00FF);
            secondByte = (byte)(s >> 8);
        }
    }
}
