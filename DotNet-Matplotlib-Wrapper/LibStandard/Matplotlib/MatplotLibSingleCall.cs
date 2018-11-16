namespace LibStandard.Matplotlib
{
    public class MatplotLibSingleCall : IMatplotLibSingleCall
    {
        public IPythonConnector Connector { get; private set; }
        public TwoListInput Plot2Lists()
        {
            throw new System.NotImplementedException();
        }

        public MatplotLibSingleCall(IPythonConnector pythonConnector)
        {
            Connector = pythonConnector;
        }
    }

    public interface IMatplotLibSingleCall
    {
        IPythonConnector Connector { get; }
        TwoListInput Plot2Lists();
    }
}
