using System;
using System.Collections.Generic;
using System.Text;

namespace LibStandard
{
    public class PythonProcessHistory : IPythonProcessHistory
    {
        public List<string> Commands { get; private set; }

        public void AddCommand(string command)
        {
            Commands.Add(command);
        }

        public PythonProcessHistory()
        {
            //Should I do lazy loading?
            Commands = new List<string>();
        }
    }

    public interface IPythonProcessHistory
    {
        void AddCommand(string command);
        List<string> Commands { get; }
    }
}
