using System;
using System.Collections.Generic;
using System.Text;
using LibStandard.Matplotlib.PlotDesign;
using LibStandard.Matplotlib.PlotOperation.CommandComposer;

namespace LibStandard.Matplotlib.PlotOperation
{
    public class PlotV3<T, Q> : IPlotV3<T, Q>
    {
        public List<XyPair<T, Q>> PairSource { get; }
        public IDesign<int, decimal> Design1 { get; }
        public IPythonProcess Process { get; }
        public IGeneralComposer<T, Q> Composer { get; }

        public PlotV3(IPythonProcess pythonProcess, IDesign<int, decimal> design, IGeneralComposer<T, Q> composer)
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

            Composer.WriteImportMatplotLib();
            Composer.WritePlotColor(Design1.PlotColor);

            Composer.WriteXYPair(PairSource);
            Composer.WritePlotShow();
            Process.CommitInstruction();
        }
    }

    public interface IPlotV3<T, Q>
    {
        void AddSource(XyPair<T, Q> xyPair);
        List<XyPair<T, Q>> PairSource { get; }
        IDesign<int, decimal> Design1 { get; }
        IPythonProcess Process { get; }
        IGeneralComposer<T, Q> Composer { get; }
        void Show();
    }
}
