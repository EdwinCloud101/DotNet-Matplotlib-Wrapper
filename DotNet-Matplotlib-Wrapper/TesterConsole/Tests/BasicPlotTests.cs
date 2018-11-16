using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibStandard;
using LibStandard.Matplotlib;
using NUnit.Framework;

namespace TesterConsole.Tests
{
    [TestFixture]
    public class BasicPlotTests
    {
        [Test]
        public void TwoAxisBasicTest()
        {
            IPythonConnector connection = new PythonConnector(PythonResources.GetPythonPath());
            IMatplotLibSingleCall singleCall = new MatplotLibSingleCall(connection);
        }
    }
}
