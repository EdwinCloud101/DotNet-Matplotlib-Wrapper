using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace LibStandard
{
    public class PythonProcess : IPythonProcess
    {
        public List<string> Instructions { get; private set; }
        public string PythonPath { get; private set; }

        public void AddInstruction(string command)
        {
            Instructions.Add(command);
        }

        public void CommitInstruction()
        {
            Process process = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;
            info.WindowStyle = ProcessWindowStyle.Hidden;

            process.StartInfo = info;
            process.Start();

            string content = "";

            using (StreamWriter writer = process.StandardInput)
            {
                if (writer.BaseStream.CanWrite)
                {
                    foreach (var item in Instructions)
                    {
                        writer.WriteLine(item);
                        content += item + Environment.NewLine;
                    }
                }
            }//using

            File.WriteAllText(@"D:\Temp\1.py", content);
        }

        public PythonProcess(string pythonPath)
        {
            PythonPath = pythonPath;
            Instructions = new List<string>();
        }
    }

    public interface IPythonProcess
    {
        List<string> Instructions { get; }
        void AddInstruction(string command);
        void CommitInstruction();
        string PythonPath { get; }
    }
}
