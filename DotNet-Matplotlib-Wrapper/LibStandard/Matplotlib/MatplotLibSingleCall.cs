namespace LibStandard.Matplotlib
{
    public class MatplotLibSingleCall : IMatplotLibSingleCall
    {
        public IPythonConnector Connector { get; private set; }
        public void Plot2Lists(ITwoListInput twoListInput)
        {
            string path = Connector.PythonPath;
        }

        public MatplotLibSingleCall(IPythonConnector pythonConnector)
        {
            Connector = pythonConnector;
        }
    }

    public interface IMatplotLibSingleCall
    {
        IPythonConnector Connector { get; }
        void Plot2Lists(ITwoListInput twoListInput);
    }
}
