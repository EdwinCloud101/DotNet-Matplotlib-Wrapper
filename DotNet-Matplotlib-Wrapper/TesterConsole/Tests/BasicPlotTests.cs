using System;
using System.Collections.Generic;
using LibStandard;
using LibStandard.Matplotlib;
using LibStandard.Matplotlib.PlotDesign;
using LibStandard.Matplotlib.PlotDesign.TickDesign;
using LibStandard.Matplotlib.PlotOperation;
using LibStandard.Matplotlib.PlotOperation.CommandComposer;
using LibStandard.Matplotlib.PlotOperation.Pairs;
using LibStandard.Matplotlib.PlotOperation.Plots;
using NUnit.Framework;

namespace TesterConsole.Tests
{
    [TestFixture]
    public class BasicPlotTests
    {

        /// <summary>
        /// Test with date only, no datetime considered in the tick
        /// </summary>
        [Test]
        public void DateXPlot()
        {
            var xyPair1 = new XyPair<DateTime, long>("AAAAA");
            xyPair1.AddX(new DateTime(2018, 11, 20, 0, 0, 0));
            xyPair1.AddX(new DateTime(2018, 11, 21, 0, 0, 0));
            xyPair1.AddX(new DateTime(2018, 11, 22, 0, 0, 0));
            xyPair1.AddY(18);
            xyPair1.AddY(32);
            xyPair1.AddY(21);
            xyPair1.HasScatter = true;

            IPythonProcess pythonProcess = new PythonProcess(PythonResources.GetPythonPath());
            ITitle title = new Title("BBBBB", 32);
            IPlotColor colors = new PlotColor();
            colors.OutsideColor = "#979899";
            colors.InsideColor = "#d1d1d1";

            IDesign<DateTime, long> design = new Design<DateTime, long>(title, colors, true, 16m, "▬", "CCCCC", "DDDDD");
            ITickComposer<DateTime, long> tickComposer = new TickComposer<DateTime, long>(false, pythonProcess);
            IGeneralComposer<DateTime, long> composer = new GeneralComposer<DateTime, long>(pythonProcess, tickComposer);
            IPlotV3<DateTime, long> plot = new PlotV3<DateTime, long>(pythonProcess, design, composer);
            plot.AddSource(xyPair1);
            plot.Show();
        }

        /// <summary>
        /// Test with datetime instead only date on the x axis
        /// </summary>
        [Test]
        public void DateTimeXPlot()
        {
            var xyPair1 = new XyPair<DateTime, long>("AAAAA");
            xyPair1.AddX(new DateTime(2018, 11, 20, 2, 0, 0));
            xyPair1.AddX(new DateTime(2018, 11, 20, 4, 0, 0));
            xyPair1.AddX(new DateTime(2018, 11, 20, 8, 0, 0));
            xyPair1.AddY(18);
            xyPair1.AddY(32);
            xyPair1.AddY(21);
            xyPair1.HasScatter = true;

            IPythonProcess pythonProcess = new PythonProcess(PythonResources.GetPythonPath());
            ITitle title = new Title("BBBBB", 32);
            IPlotColor colors = new PlotColor();
            colors.OutsideColor = "#979899";
            colors.InsideColor = "#d1d1d1";

            IDesign<DateTime, long> design = new Design<DateTime, long>(title, colors, true, 16m, "▬", "CCCCC", "DDDDD");
            ITickComposer<DateTime, long> tickComposer = new TickComposer<DateTime, long>(true, pythonProcess);
            IGeneralComposer<DateTime, long> composer = new GeneralComposer<DateTime, long>(pythonProcess, tickComposer);
            IPlotV3<DateTime, long> plot = new PlotV3<DateTime, long>(pythonProcess, design, composer);
            plot.AddSource(xyPair1);
            plot.Show();
        }


        [Test]
        public void DateXDLongYTest()
        {
            var xyPair1 = new XyPair<DateTime, long>("Some Legend A");
            xyPair1.AddX(new DateTime(2018, 11, 20));
            xyPair1.AddX(new DateTime(2018, 11, 21));
            xyPair1.AddX(new DateTime(2018, 11, 22));
            xyPair1.AddY(18);
            xyPair1.AddY(32);
            xyPair1.AddY(21);
            xyPair1.HasScatter = true;

            IPythonProcess pythonProcess = new PythonProcess(PythonResources.GetPythonPath());
            ITitle title = new Title("This is a title", 32);
            IPlotColor colors = new PlotColor();
            colors.OutsideColor = "#979899";
            colors.InsideColor = "#d1d1d1";

            IDesign<DateTime, long> design = new Design<DateTime, long>(title, colors, true, 16m, "▬", "aaa", "bbbb");
            ITickComposer<DateTime, long> tickComposer = new TickComposer<DateTime, long>(false, pythonProcess);
            IGeneralComposer<DateTime, long> composer = new GeneralComposer<DateTime, long>(pythonProcess, tickComposer);
            IPlotV3<DateTime, long> plot = new PlotV3<DateTime, long>(pythonProcess, design, composer);
            plot.AddSource(xyPair1);
            plot.Show();
        }

        [Test]
        public void DateXDecimalYTest()
        {
            var xyPair1 = new XyPair<DateTime, decimal>("Some Legend A");
            xyPair1.AddX(new DateTime(2018, 11, 20));
            xyPair1.AddX(new DateTime(2018, 11, 21));
            xyPair1.AddX(new DateTime(2018, 11, 22));
            xyPair1.AddY(0.18m);
            xyPair1.AddY(0.32m);
            xyPair1.AddY(0.21m);
            xyPair1.HasScatter = true;

            IPythonProcess pythonProcess = new PythonProcess(PythonResources.GetPythonPath());
            ITitle title = new Title("This is a title", 16);
            IPlotColor colors = new PlotColor();
            colors.OutsideColor = "#979899";
            colors.InsideColor = "#d1d1d1";

            IDesign<DateTime, decimal> design = new Design<DateTime, decimal>(title, colors, true, 0.5m, "&", "cccc", "dddd");
            ITickComposer<DateTime, decimal> tickComposer = new TickComposer<DateTime, decimal>(false, pythonProcess);
            IGeneralComposer<DateTime, decimal> composer = new GeneralComposer<DateTime, decimal>(pythonProcess, tickComposer);
            IPlotV3<DateTime, decimal> plot = new PlotV3<DateTime, decimal>(pythonProcess, design, composer);
            plot.AddSource(xyPair1);
            plot.Show();
        }

        [Test]
        public void Version3Test()
        {
            //IPythonProcess pythonProcess = new PythonProcess(PythonResources.GetPythonPath());

            //ITitle title = new Title("This is a title", 16);
            //IPlotColor colors = new PlotColor();
            //colors.OutsideColor = "#979899";
            //colors.InsideColor = "#d1d1d1";

            //IXTick<int> xTick = new XTick<int>(new List<Tuple<int, string>>
            //{
            //    new Tuple<int, string>(1,"11/13 \\n Tue"),
            //    new Tuple<int, string>(2,"11/14 \\n Wed"),
            //    new Tuple<int, string>(3,"11/15 \\n Thu"),
            //    new Tuple<int, string>(4,"11/16 \\n Fri"),
            //    new Tuple<int, string>(5,"11/17 \\n Sat")
            //});

            //IYTick<decimal> yTick = new YTick<decimal>(new List<Tuple<decimal, string>>
            //{
            //    new Tuple<decimal, string>(0.0m,"0 %"),
            //    new Tuple<decimal, string>(0.1m, "0.1 %"),
            //    new Tuple<decimal, string>(0.2m, "0.2 %"),
            //    new Tuple<decimal, string>(0.3m, "0.3 %"),
            //    new Tuple<decimal, string>(0.4m, "0.4 %"),
            //    new Tuple<decimal, string>(0.5m, "0.5 %")
            //});

            //IDesign<int, decimal> design = new Design<int, decimal>(title, colors, xTick, yTick, true);

            ////var xyPair1 = new XyPair<int, decimal>() { X = { 1, 2, 3, 4, 5 }, Y = { 0.31m, 0.22m, 0.22m, 0.22m, 0.21m }, HasScatter = true };
            ////var xyPair2 = new XyPair<int, decimal>() { X = { 1, 2, 3, 4, 5 }, Y = { 0.03m, 0.03m, 0.03m, 0.02m, 0.02m }, HasScatter = true };
            ////var xyPair3 = new XyPair<int, decimal>() { X = { 1, 2, 3, 4, 5 }, Y = { 0.11m, 0.12m, 0.10m, 0.09m, 0.09m }, HasScatter = true };

            ////IGeneralComposer<int, decimal> composer = new GeneralComposer<int, decimal>(pythonProcess);

            ////IPlotV3<int, decimal> plot = new PlotV3<int, decimal>(pythonProcess, design, composer);
            ////plot.AddSource(xyPair1);
            ////plot.AddSource(xyPair2);
            ////plot.AddSource(xyPair3);
            ////plot.Show();
        }
    }
}
