using System;

namespace UartReader
{
    public interface IFileWriter:IDisposable
    {
        void WriteLine(string line);
    }
}