using System;
using System.IO.Ports;
using System.Text;

namespace UartReader
{
    public class UartReader : IUartReader
    {
        private readonly SerialPort serialPort;
        private readonly IFileWriter fileWriter;
        public int BytesCounter { get; private set; }

        public UartReader(SerialPort serialPort, IFileWriter fileWriter)
        {
            this.serialPort = serialPort;
            this.fileWriter = fileWriter;
        }

        public void ReadSerial()
        {
            serialPort.Encoding = Encoding.GetEncoding(28591);
            serialPort.DataReceived += serialPort_DataRecieved;
            serialPort.Open();
        }

        private void serialPort_DataRecieved(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {

            var buffer = serialPort.ReadExisting();
            foreach (char c in buffer)
            {
                fileWriter.Write(c.ToString().Trim());
                BytesCounter++;

            }
           // fileWriter.WriteLine(Convert.ToChar(serialPort.ReadByte()).ToString());
        }

        public void Dispose()
        {
            serialPort?.Dispose();
            fileWriter?.Dispose();
        }
    }
}