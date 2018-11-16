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
            IMatplotlibComposer matComposer = new MatplotlibComposer(connection);
            IMatplotLibSingleCall singleCall = new MatplotLibSingleCall(matComposer);

            List<string> list1 = new List<string>() {"2018-Jan", "2018-Feb", "2018-Mar" };
            List<string> list2 = new List<string>() { "0%", "0.3%", "0.22%" };

            ITwoListInput twoListInput = new TwoListInput();

            singleCall.Plot2Lists(twoListInput);
        }
    }
}
