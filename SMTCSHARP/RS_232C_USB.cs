using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMTCSHARP
{
    internal class RS_232C_USB
    {
        // (0)Class variable
        private System.IO.Ports.SerialPort SerialPort;                                  // Serial Port Device
        public string MsgBuf = "";                                                     // Received Data

        // (1)Connect
        public bool OpenInterface(string port, string speed)
        {
            bool ret = false;

            try
            {
                SerialPort = new System.IO.Ports.SerialPort();                          // Create a serial port object
                SerialPort.PortName = port;                                             // Set the COM port
                SerialPort.BaudRate = Convert.ToInt32(speed);                           // Set communication speed
                SerialPort.Open();                                                      // Open the serial port
                ret = true;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return ret;
        }

        // (2)Disconnect
        public bool CloseInterface()
        {
            bool ret = false;

            try
            {
                if (SerialPort.IsOpen)
                {
                    SerialPort.Close();                                                 // Close the serial port
                }
                SerialPort.Dispose();                                                   // Dispose the serial port object
                ret = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return ret;
        }

        // (3)Send commands
        public bool SendMsg(string strMsg)
        {
            bool ret = false;

            try
            {
                strMsg += "\r\n";                                                       // Add a terminator, CR+LR, to transmitted command
                SerialPort.Write(strMsg);                                               // Write data in the transmit buffer
                ret = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return ret;
        }

        // (4)Receive
        public bool ReceiveMsg(long timeout_ms)
        {
            bool ret = false;
            string rcv = "";
            StringBuilder buf = new StringBuilder();
            Stopwatch sw = new Stopwatch();

            try
            {
                MsgBuf = "";                                                            // Clear received data

                sw.Start();                                                             // Start a stopwatch
                                                                                        // Continue the loop until LF is received                                                                        //
                while (true)
                {
                    if (SerialPort.BytesToRead > 0)
                    {
                        rcv = SerialPort.ReadExisting();                                // Read data from the receive buffer
                        rcv = rcv.Replace("\r", "");                                    // Delete CR in received data
                        if (rcv.IndexOf("\n") >= 0)                                     // End the loop when LF is received
                        {
                            rcv = rcv.Substring(0, rcv.IndexOf("\n"));                  // Extract data without LF and the following from the original received data
                            buf.Append(rcv);                                            // Save the data
                            MsgBuf = buf.ToString();
                            break;
                        }
                        else
                        {
                            buf.Append(rcv);                                            // Save the data
                        }
                    }
                    // Timeout processing
                    if (sw.ElapsedMilliseconds > timeout_ms)
                    {
                        MsgBuf = "Timeout";
                        MessageBox.Show(MsgBuf);
                        return ret;
                    }
                }
                sw.Stop();                                                              // Stop a stopwatch
                ret = true;
            }
            catch (Exception e)
            {
                MsgBuf = "Error";
                MessageBox.Show(e.Message);
            }

            return ret;
        }

        // (5)Transmit and receive commands
        public bool SendQueryMsg(string strMsg, long timeout_ms)
        {
            bool ret = false;

            if (SerialPort.BytesToRead > 0)                                             // If exist the data in the receive buffer, read all data.
            {
                SerialPort.ReadExisting();
            }

            ret = SendMsg(strMsg);                                                      // Transmit commands
            if (ret)
            {
                if (strMsg.Contains("?"))
                {
                    ret = ReceiveMsg(timeout_ms);                                       // Receive response when command transmission is succeeded
                }
            }

            return ret;
        }
    }
}
