using System;
using System.Collections.Generic;
using System.Text;

namespace LibStandard.Matplotlib
{
    public class MatplotlibComposer : IMatplotlibComposer
    {
        public IPythonConnector Connector { get; private set; }

        public MatplotlibComposer(IPythonConnector connector)
        {
            Connector = connector;
        }
    }

    public interface IMatplotlibComposer
    {
        IPythonConnector Connector { get; }
    }
}
