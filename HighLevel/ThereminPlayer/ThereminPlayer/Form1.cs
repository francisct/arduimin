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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            

            string fileName = @"Wavs\LongAhhh.wav";

            Wav wav = new Wav(fileName);
            wav.Play();

            ArduinoInputReceiver receiver = new ArduinoInputReceiver(ref wav);
            receiver.Open();




        }
    }
}
