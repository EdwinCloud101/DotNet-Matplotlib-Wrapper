namespace LibStandard.Matplotlib
{
    public class MatplotLibSingleCall : IMatplotLibSingleCall
    {
        public IMatplotlibComposer Composer { get; private set; }
        public void Plot2Lists(ITwoListInput twoListInput)
        {
            string path = Composer.Connector.PythonPath;
        }

        public MatplotLibSingleCall(IMatplotlibComposer pythonConnector)
        {
            Composer = pythonConnector;
        }
    }

    public interface IMatplotLibSingleCall
    {
        IMatplotlibComposer Composer { get; }
        void Plot2Lists(ITwoListInput twoListInput);
    }
}
