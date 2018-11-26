using System;
using System.Collections.Generic;
using LibStandard.Matplotlib.PlotDesign;
using LibStandard.Matplotlib.PlotDesign.TickDesign;
using LibStandard.Matplotlib.PlotOperation.CommandComposer;
using LibStandard.Matplotlib.PlotOperation.Pairs;

namespace LibStandard.Matplotlib.PlotOperation.Plots
{
    public class PlotV3<T, Q> : IPlotV3<T, Q>
    {
        public List<XyPair<T, Q>> PairSource { get; }
        public IDesign<T, Q> Design1 { get; }
        public IPythonProcess Process { get; }
        public IGeneralComposer<T, Q> Composer { get; }

        public PlotV3(IPythonProcess pythonProcess, IDesign<T, Q> design, IGeneralComposer<T, Q> composer)
        {
            Design1 = design;
            Process = pythonProcess;
            PairSource = new List<XyPair<T, Q>>();
            Composer = composer;
        }

        public void AddSource(XyPair<T, Q> xyPair)
        {
            PairSource.Add(xyPair);
        }

        public void Show()
        {
            Composer.WritePython();
            Composer.WriteImportModules();
            Composer.WritePlotColor(Design1.PlotColor);
            Composer.WriteGrid(Design1.HasGrid);
            Composer.WriteTitle(Design1.Title);
            Composer.WriteLabelXY(Design1.XLabel, Design1.YLabel);

            //Composer.WriteTicks(Design1.XTick, Design1.YTick, PairSource);
            Composer.WriteTicks((IXTick<DateTime>)Design1.XTick, (IYTick<decimal>)Design1.YTick, PairSource, Design1.IncreaseTickRate);

            Composer.WriteXYPair(PairSource, Design1.ScatterSuffix);
            Composer.WritePlotShow();
            Process.CommitInstruction();
        }
    }

    public interface IPlotV3<T, Q>
    {
        void AddSource(XyPair<T, Q> xyPair);
        List<XyPair<T, Q>> PairSource { get; }
        IDesign<T, Q> Design1 { get; }
        IPythonProcess Process { get; }
        IGeneralComposer<T, Q> Composer { get; }
        void Show();
    }
}
