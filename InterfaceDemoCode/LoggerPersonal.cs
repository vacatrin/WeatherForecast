using System;
using System.Collections.Generic;
using InterfaceDemoCore.Interfaces;

namespace InterfaceDemoCore
{
    public class LoggerPersonal : ILoggerPersonal
    {
        public void LogPers(string element)
        {
            System.Diagnostics.Debug.WriteLine($"LogPers: {element}");
        }
    }
}
