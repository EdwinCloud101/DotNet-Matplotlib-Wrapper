using System;
using System.Collections.Generic;
using System.Text;
using LibStandard.Matplotlib.PlotDesign;

namespace LibStandard.Matplotlib.PlotOperation
{
    public class PlotV2<T, Q> : IPlotV2<T, Q>
    {
        public void AddSource(XyPair<T, Q> xyPair)
        {
            PairSource.Add(xyPair);
        }

        public List<XyPair<T, Q>> PairSource { get; }
        public IDesign Design1 { get; }
        public IPythonProcess Process { get; }
        public void Show()
        {
            Process.AddInstruction("python");
            Process.AddInstruction("import matplotlib.pyplot as plt");

            if (Design1.OutsideColor != null)
            {
                Process.AddInstruction("fig = plt.figure(facecolor=\"" + Design1.OutsideColor + "\")");
            }
            if (Design1.InsideColor != null)
            {
                Process.AddInstruction("ax = plt.gca()");
                Process.AddInstruction("ax.set_facecolor(\"" + Design1.InsideColor + "\")");
            }

            int index = 1;
            foreach (var item in PairSource)
            {
                Process.AddInstruction("x" + index + " = [");
                string content = "";
                foreach (var x in item.X)
                {
                    content += x + ",";
                }
                content = content.TrimEnd(',') + "]";
                Process.AddInstruction(content);

                content = "";
                Process.AddInstruction("y" + index + " = [");
                foreach (var y in item.Y)
                {
                    content += y + ",";
                }
                content = content.TrimEnd(',') + "]";
                Process.AddInstruction(content);

                Process.AddInstruction("plt.plot(x" + index + ",y" + index + ")");
            }
            Process.AddInstruction("plt.show()");
            Process.CommitInstruction();
        }

        public PlotV2(IPythonProcess pythonProcess, IDesign design)
        {
            Design1 = design;
            Process = pythonProcess;
            PairSource = new List<XyPair<T, Q>>();
        }
    }

    public interface IPlotV2<T, Q>
    {
        void AddSource(XyPair<T, Q> xyPair);

        List<XyPair<T, Q>> PairSource { get; }
        IDesign Design1 { get; }
        IPythonProcess Process { get; }
        void Show();
    }
}
