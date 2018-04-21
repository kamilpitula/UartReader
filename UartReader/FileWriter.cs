using System;
using System.IO;
using System.Text;

namespace UartReader
{
    public class FileWriter : IFileWriter
    {
        private readonly StreamWriter streamWriter;
        public FileWriter(StreamWriter streamWriter)
        {
            this.streamWriter = streamWriter;
        }

        public void WriteLine(string line)
        {
            streamWriter.WriteLine(line);
        }
        public void Write(string text)
        {
            streamWriter.Write(text);
        }

        public void Dispose()
        {
            streamWriter.Close();
        }

        private string ToHex(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                sb.AppendFormat("0x{0:X2}", (int) c);
            }
            return sb.ToString().Trim();

        }
    }
}