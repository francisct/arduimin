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

        private SerialPort _serialPort;
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
            _portName = "COM1";
            _stopBits = StopBits.One;
            tString = string.Empty;
            _terminator = 0x4;
        }

        public void Open2()
        {
            _serialPort = new SerialPort("COM4", 9600);
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            _serialPort.Open();
            while (true)
            {
                String s = Console.ReadLine();
                if (s.Equals("exit"))
                {
                    break;
                }
                _serialPort.Write(s + '\n');
            }
            _serialPort.Close();
        }

        public bool Open()
        {
            try
            {
                _serialPort.BaudRate = _baudRate;
                _serialPort.DataBits = _dataBits;
                _serialPort.Handshake = _handshake;
                _serialPort.Parity = _parity;
                _serialPort.PortName = _portName;
                _serialPort.StopBits = _stopBits;
                _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);
            }
            catch { return false; }
            return true;
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
            //Check if string contains the terminator  
            if (tString.IndexOf((char)_terminator) > -1)
            {
                //If tString does contain terminator we cannot assume that it is the last character received 
                string workingString = tString.Substring(0, tString.IndexOf((char)_terminator));
                //Remove the data up to the terminator from tString 
                tString = tString.Substring(tString.IndexOf((char)_terminator));
                //Do something with workingString 
                Console.WriteLine(workingString);


                wav.ApplyPitchShifting(2f);
                wav.BackupWaveData();
                wav.SaveModifiedWavData();
                wav.Play();
            }
        }
    }
}
