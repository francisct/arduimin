using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThereminPlayer
{
    public partial class Form1 : Form
    {
        Wav wav;
        ArduinoInputReceiver receiver;
        string fileName = @"Wavs\LongAhhh.wav";

        public Form1()
        {
            InitializeComponent();
            buildFileComboList();

        }

        private void buildFileComboList()
        {
            string[] files = Directory.GetFiles(@"Wavs\");
            for (int i=0; i < files.Length; i++)
            {
                comboBox1.Items.Add(files[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            

            if (wav == null)
            {
                wav = new Wav(fileName);
            }
            wav.Play();

            receiver = new ArduinoInputReceiver(ref wav);
            receiver.Open();




        }

        private void button2_Click(object sender, EventArgs e)
        {
            wav.Stop();
            receiver.Stop();
        }


        private void radioHalfPitch_CheckedChanged(object sender, EventArgs e)
        {
            wav.halfPitch = true;
        }

        private void radioFullPitch_CheckedChanged(object sender, EventArgs e)
        {
            wav.halfPitch = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wav == null)
            {
                wav = new Wav(fileName);
            }
            wav.setWav(comboBox1.SelectedItem.ToString());
        }
    }
}
