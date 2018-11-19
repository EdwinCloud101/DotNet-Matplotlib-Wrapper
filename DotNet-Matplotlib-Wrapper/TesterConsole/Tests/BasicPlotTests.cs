using System;
using System.Collections.Generic;
using LibStandard;
using LibStandard.Matplotlib;
using LibStandard.Matplotlib.PlotDesign;
using LibStandard.Matplotlib.PlotDesign.TickDesign;
using LibStandard.Matplotlib.PlotOperation;
using LibStandard.Matplotlib.PlotOperation.CommandComposer;
using NUnit.Framework;

namespace TesterConsole.Tests
{
    [TestFixture]
    public class BasicPlotTests
    {
        [Test]
        public void Version3Test()
        {
            IPythonProcess pythonProcess = new PythonProcess(PythonResources.GetPythonPath());

            ITitle title = new Title("This is a title", 16);
            IPlotColor colors = new PlotColor();
            colors.OutsideColor = "#979899";
            colors.InsideColor = "#d1d1d1";

            IXTick<int> xTick = new XTick<int>(new List<Tuple<int, string>>
            {
                new Tuple<int, string>(1,"11/13 \\n Tue"),
                new Tuple<int, string>(2,"11/14 \\n Wed"),
                new Tuple<int, string>(3,"11/15 \\n Thu"),
                new Tuple<int, string>(4,"11/16 \\n Fri"),
                new Tuple<int, string>(5,"11/17 \\n Sat")
            });

            IYTick<decimal> yTick = new YTick<decimal>(new List<Tuple<decimal, string>>
            {
                new Tuple<decimal, string>(0.0m,"0 %"),
                new Tuple<decimal, string>(0.1m, "0.1 %"),
                new Tuple<decimal, string>(0.2m, "0.2 %"),
                new Tuple<decimal, string>(0.3m, "0.3 %"),
                new Tuple<decimal, string>(0.4m, "0.4 %"),
                new Tuple<decimal, string>(0.5m, "0.5 %")
            });

            IDesign<int, decimal> design = new Design<int, decimal>(title, colors, xTick, yTick,true);

            var xyPair1 = new XyPair<int, decimal>() { X = { 1, 2, 3, 4, 5 }, Y = { 0.31m, 0.22m, 0.22m, 0.22m, 0.21m }, HasScatter = true };
            var xyPair2 = new XyPair<int, decimal>() { X = { 1, 2, 3, 4, 5 }, Y = { 0.03m, 0.03m, 0.03m, 0.02m, 0.02m }, HasScatter = true };
            var xyPair3 = new XyPair<int, decimal>() { X = { 1, 2, 3, 4, 5 }, Y = { 0.11m, 0.12m, 0.10m, 0.09m, 0.09m }, HasScatter = true };

            IGeneralComposer<int,decimal> composer = new GeneralComposer<int, decimal>(pythonProcess);

            IPlotV3<int, decimal> plot = new PlotV3<int, decimal>(pythonProcess, design, composer);
            plot.AddSource(xyPair1);
            plot.AddSource(xyPair2);
            plot.AddSource(xyPair3);
            plot.Show();
        }


        [Test]
        public void Version2Test()
        {
            //IPythonProcess pythonProcess = new PythonProcess(PythonResources.GetPythonPath());

            //#region MyRegion

            //IDesign<int, decimal> design = new Design<int, decimal>();
            //design.Title = "This is a title";
            //design.TitleFontSize = 16;
            //design.OutsideColor = "#979899";
            //design.InsideColor = "#d1d1d1";

            //design.XTick.Add(new Tuple<int, string>(1, "11/13 \\n Tue"));
            //design.XTick.Add(new Tuple<int, string>(2, "11/14 \\n Wed"));
            //design.XTick.Add(new Tuple<int, string>(3, "11/15 \\n Thu"));
            //design.XTick.Add(new Tuple<int, string>(4, "11/16 \\n Fri"));
            //design.XTick.Add(new Tuple<int, string>(5, "11/17 \\n Sat"));

            //design.YTick.Add(new Tuple<decimal, string>(0.0m, "0 %"));
            //design.YTick.Add(new Tuple<decimal, string>(0.1m, "0.1 %"));
            //design.YTick.Add(new Tuple<decimal, string>(0.2m, "0.2 %"));
            //design.YTick.Add(new Tuple<decimal, string>(0.3m, "0.3 %"));
            //design.YTick.Add(new Tuple<decimal, string>(0.4m, "0.4 %"));
            //design.YTick.Add(new Tuple<decimal, string>(0.5m, "0.5 %"));

            //#endregion

            //var xyPair1 = new XyPair<int, decimal>() { X = { 1, 2, 3, 4, 5 }, Y = { 0.31m, 0.22m, 0.22m, 0.22m, 0.21m }, HasScatter = true };
            //var xyPair2 = new XyPair<int, decimal>() { X = { 1, 2, 3, 4, 5 }, Y = { 0.03m, 0.03m, 0.03m, 0.02m, 0.02m }, HasScatter = true };
            //var xyPair3 = new XyPair<int, decimal>() { X = { 1, 2, 3, 4, 5 }, Y = { 0.11m, 0.12m, 0.10m, 0.09m, 0.09m }, HasScatter = true };

            //IPlotV2<int, decimal> plot = new PlotV2<int, decimal>(pythonProcess, design);
            //plot.AddSource(xyPair1);
            //plot.AddSource(xyPair2);
            //plot.AddSource(xyPair3);
            //plot.Show();
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
