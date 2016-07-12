using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThereminPlayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            string fileName = "ShortAhhh.wav";
            string path = Path.Combine(Environment.CurrentDirectory, @"Wavs\", fileName);

            float ctr = 1.1f;
            Wav wav = new Wav(path);

            ArduinoInputReceiver receiver = new ArduinoInputReceiver();
            receiver.Open();
           /* while (true)
            {
                
                wav.ApplyPitchShifting(ctr);
                wav.BackupWaveData();
                wav.SaveModifiedWavData();
                wav.Play();
                ctr = ctr + 0.1f;
            }*/
        }
    }
}
