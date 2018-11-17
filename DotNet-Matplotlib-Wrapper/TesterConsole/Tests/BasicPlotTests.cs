using System.Collections.Generic;
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
            IPythonProcess pythonProcess = new PythonProcess(PythonResources.GetPythonPath());
            IMatplotLibSingleCall<int, decimal> singleCall = new MatplotLibSingleCall<int, decimal>(pythonProcess);

            List<int> list1 = new List<int>() { 1, 2, 3, 4 };
            List<decimal> list2 = new List<decimal>() { 0.0m, 0.31m, 0.22m, 0.22m };

            ITwoListInput<int, decimal> twoListInput = new TwoListInput<int, decimal>();
            twoListInput.Input1 = list1;
            twoListInput.Input2 = list2;
            singleCall.Plot2Lists(twoListInput);
        }
    }
}
