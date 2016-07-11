
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThereminPlayer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string fileName = "ShortAhhh.wav";
            string path = Path.Combine(Environment.CurrentDirectory, @"Wavs\", fileName);

            float ctr = 1.1f;

            while (true)
            {
                Wav wav = new Wav(path);
                wav.ApplyPitchShifting(ctr);
                wav.BackupWaveData();
                wav.SaveModifiedWavData();
                wav.Play();
                ctr = ctr + 0.1f;
            }
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());



            
        }

       

        
    }
}
