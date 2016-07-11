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
  

            private void buttonConnect_Click(object sender, EventArgs e)
            {
            var comPorts = new string[10]; //You really shouldn't have many more than 10 ports open at a time.... Right?
            comPorts = SerialPort.GetPortNames();
            foreach (var comPort in comPorts)
                listBoxComPorts.Items.Add(comPort);
            listBoxBaudRate.Items.Add(9600);

            SerialPort arduinoPort = new SerialPort()
                {
                    PortName = userPortChoice.ToString(),
                    BaudRate = Convert.ToInt16(userBaudChoice)
                };
                arduinoPort.Open();
                arduinoPort.NewLine = "\r\n";

                #endregion

                #region Real Code
                /*-------------------------------------------------------*
                 * --------------THE REAL CODE SECTION-------------------*
                 *-------------------------------------------------------*/
                while (arduinoPort.IsOpen)
                {
                    //
                    //BEGIN making a string array based on serial data sent via USB from the Arduino UNO
                    //
                }
                #endregion
            }
        }
    }
