using System;

namespace UartReader
{
    public interface IUartReader:IDisposable
    {
        void ReadSerial();
    }
}