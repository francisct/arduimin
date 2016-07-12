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

            ArduinoInputReceiver receiver = new ArduinoInputReceiver(wav);
            receiver.Open2();

            String tString = "";
            while (true)
            {
                //Initialize a buffer to hold the received data 
                byte[] buffer = new byte[receiver._serialPort.ReadBufferSize];

                //There is no accurate method for checking how many bytes are read 
                //unless you check the return from the Read method 
                int bytesRead = receiver._serialPort.Read(buffer, 0, buffer.Length);

                //For the example assume the data we are received is ASCII data. 
                tString += Encoding.ASCII.GetString(buffer, 0, bytesRead);

                string myString = (tString.Length > 3) ? tString.Substring(tString.Length - 4, 4) : tString;
                //We add + 1 because the library PitchShifter is from 1 to 2
                float shiftPitch = float.Parse(myString) + 1.0f;
                wav.Reset();
                wav.ApplyPitchShifting(shiftPitch);
                wav.BackupWaveData();
                wav.SaveModifiedWavData();
                wav.Play();

                /* wav.ApplyPitchShifting(ctr);
                 wav.BackupWaveData();
                 wav.SaveModifiedWavData();
                 wav.Play();
                 ctr = ctr + 0.1f;*/
            }
        }
    }
}
