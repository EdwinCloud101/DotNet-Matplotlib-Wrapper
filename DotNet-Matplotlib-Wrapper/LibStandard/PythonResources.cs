using System.Configuration;

namespace LibStandard
{
    public static class PythonResources
    {
        public static string GetPythonPath()
        {
            return "cmd.exe"; //ConfigurationManager.AppSettings["pythonPath"];
        }
    }
}
