using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace UartReader
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Starting application");

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
                     "\\results";
            if (!Directory.Exists(path))
                 Directory.CreateDirectory(path);

            var fullPath = Path.Combine(path, $"result_{DateTime.Now.ToString("ddMMyyyy_hhmmss")}.txt");

            var streamWriter =
                new StreamWriter(fullPath,false);
            var fileWriter = new FileWriter(streamWriter);
            var serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            
            var uartReader = new UartReader(serialPort, fileWriter);
            Console.WriteLine("Reading.....");

            uartReader.ReadSerial();

            Console.WriteLine("Press any key to close port...");

            Console.ReadKey();
            Console.WriteLine($"Recieved {uartReader.BytesCounter} bytes");
            uartReader.Dispose();
            
            Console.WriteLine("Press any key to close");
            Console.WriteLine($"Results path: {fullPath}");
            Console.ReadKey();
            Console.WriteLine("Closing...");

        }
    }
}
