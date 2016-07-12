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
        private string _portName;
        private Wav wav;
        public bool open;
        
        private string tString;

        public ArduinoInputReceiver(ref Wav wav)
        {
            this.wav = wav;
            _serialPort = new SerialPort();
            _baudRate = 9600;
            _portName = "COM5";
            tString = string.Empty;
            open = false;
        }

        public void Open()
        {
            _serialPort = new SerialPort(_portName, _baudRate);
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            _serialPort.Open();
            open = true;
        }

        public void Stop()
        {
            _serialPort.Close();
            open = false;
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
            try
            {
                float shiftPitch = float.Parse(myString);
                wav.ApplyPitchShifting(shiftPitch);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
