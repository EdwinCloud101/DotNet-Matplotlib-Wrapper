using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace LibStandard
{
    public static class PythonResources
    {
        public static string GetPythonPath()
        {
            return ConfigurationManager.AppSettings["pythonPath"];
        }
    }
}
