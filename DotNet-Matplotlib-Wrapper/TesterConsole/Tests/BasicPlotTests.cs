using System.Collections.Generic;
using LibStandard;
using LibStandard.Matplotlib;
using LibStandard.Matplotlib.PlotDesign;
using LibStandard.Matplotlib.PlotOperation;
using NUnit.Framework;

namespace TesterConsole.Tests
{
    [TestFixture]
    public class BasicPlotTests
    {
        [Test]
        public void Version2Test()
        {
            IPythonProcess pythonProcess = new PythonProcess(PythonResources.GetPythonPath());

            IDesign design = new Design();
            design.Title = "This is a title";
            design.TitleFontSize = 16;
            design.OutsideColor = "#979899";
            design.InsideColor = "#d1d1d1";

            var xyPair1 = new XyPair<int, decimal>() {X = {1,2,3,4,5},Y = {0.31m,0.22m,0.22m,0.22m,0.21m}};
            var xyPair2 = new XyPair<int, decimal>() { X = { 1, 2, 3, 4, 5 }, Y = { 0.03m, 0.03m, 0.03m, 0.02m, 0.02m } };
            var xyPair3 = new XyPair<int, decimal>() { X = { 1, 2, 3, 4, 5 }, Y = { 0.11m, 0.12m, 0.10m, 0.09m, 0.09m } };

            IPlotV2<int, decimal> plot = new PlotV2<int, decimal>(pythonProcess, design);
            plot.AddSource(xyPair1);
            plot.AddSource(xyPair2);
            plot.AddSource(xyPair3);
            plot.Show();
        }

        [Test]
        public void TwoAxisBasicTest()
        {
            //IPythonProcess pythonProcess = new PythonProcess(PythonResources.GetPythonPath());
            //IMatplotLibSingleCall<int, decimal> singleCall = new Plot<int, decimal>(pythonProcess);

            //List<int> list1 = new List<int>() { 1, 2, 3, 4 };
            //List<decimal> list2 = new List<decimal>() { 0.0m, 0.31m, 0.22m, 0.22m };

            //ITwoListInput<int, decimal> twoListInput = new TwoListInput<int, decimal>();

            //IDesign design = new Design();
            //design.Title = "This is a title";
            //design.TitleFontSize = 16;
            //design.OutsideColor = "#979899";
            //design.InsideColor = "#d1d1d1";

            //twoListInput.Design = design;
            //twoListInput.XLabel = "";
            //twoListInput.XValues = list1;
            //twoListInput.YLabel = "Growth Rate(%)";
            //twoListInput.YValues = list2;

            //singleCall.Plot2Lists(twoListInput);
        }
    }
}
