using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThereminPlayer
{
    class ArduinoInputReceiver
    {

        public SerialPort _serialPort;
        private int _baudRate;
        private int _dataBits;
        private Handshake _handshake;
        private Parity _parity;
        private string _portName;
        private StopBits _stopBits;
        private Wav wav;

        /// <summary> 
        /// Holds data received until we get a terminator. 
        /// </summary> 
        private string tString;
        /// <summary> 
        /// End of transmition byte in this case EOT (ASCII 4). 
        /// </summary> 
        private byte _terminator;

        public ArduinoInputReceiver(Wav wav)
        {
            this.wav = wav;
            _serialPort = new SerialPort();
            _baudRate = 9600;
            _dataBits = 8;
            _handshake = Handshake.None;
            _parity = Parity.None;
            _portName = "COM5";
            _stopBits = StopBits.One;
            tString = string.Empty;
            _terminator = 0x4;
        }

        public void Open()
        {
            _serialPort = new SerialPort(_portName, _baudRate);
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            _serialPort.Open();
        }

        void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Initialize a buffer to hold the received data 
            byte[] buffer = new byte[_serialPort.ReadBufferSize];

            //There is no accurate method for checking how many bytes are read 
            //unless you check the return from the Read method 
            int bytesRead = _serialPort.Read(buffer, 0, buffer.Length);

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
        }
    }
}
