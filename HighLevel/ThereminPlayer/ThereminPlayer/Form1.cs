﻿using System;
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
            string wavLocation = Path.Combine(Environment.CurrentDirectory, @"Wavs\", fileName);

            ArduinoInputReceiver receiver = new ArduinoInputReceiver(wavLocation);
            receiver.Open();
            /*while (true)
            {
                Wav wav = new Wav(wavLocation);
                wav.Reset();
                wav.ApplyPitchShifting(2f);
                wav.BackupWaveData();
                wav.SaveModifiedWavData();
                wav.Play();
            }*/
            
        }
    }
}
