using System;

namespace LibStandard
{
    public class PythonConnector : IPythonConnector
    {
        public string PythonPath { get; private set; }

        public PythonConnector(string pythonPath)
        {
            PythonPath = pythonPath;
        }
    }

    public interface IPythonConnector
    {
        string PythonPath { get; }
    }
}
