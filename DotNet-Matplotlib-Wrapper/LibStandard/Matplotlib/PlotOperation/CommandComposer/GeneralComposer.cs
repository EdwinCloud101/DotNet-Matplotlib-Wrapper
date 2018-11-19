using System;
using System.Collections.Generic;
using System.Text;
using LibStandard.Matplotlib.PlotDesign;

namespace LibStandard.Matplotlib.PlotOperation.CommandComposer
{
    public class GeneralComposer<T, Q> : IGeneralComposer<T, Q>
    {
        public IPythonProcess Process { get; }

        public GeneralComposer(IPythonProcess process)
        {
            Process = process;
        }

        public void WritePython()
        {
            Process.AddInstruction("python");
        }

        public void WriteImportMatplotLib()
        {
            Process.AddInstruction("import matplotlib.pyplot as plt");
        }

        public void WritePlotColor(IPlotColor color)
        {
            if (color.OutsideColor != null)
            {
                Process.AddInstruction("fig = plt.figure(facecolor=\"" + color.OutsideColor + "\")");
            }

            if (color.InsideColor != null)
            {
                Process.AddInstruction("ax = plt.gca()");
                Process.AddInstruction("ax.set_facecolor(\"" + color.InsideColor + "\")");
            }
        }

        public void WritePlotShow()
        {
            Process.AddInstruction("plt.show()");
        }

        public void WriteXYPair(List<XyPair<T, Q>> xyPair)
        {
            int index = 1;
            string content = "";

            foreach (var item in xyPair)
            {
                Process.AddInstruction("x" + index + " = [");
                content = "";
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

                Process.AddInstruction("for i,item in enumerate(y" + index + "):");
                Process.AddInstruction("\txP = x" + index + "[i]");
                Process.AddInstruction("\tyP = y" + index + "[i]");
                Process.AddInstruction("\tplt.text(xP-0.1,yP+0,str(item)+\"%\",fontsize=11)");
                //Process.AddInstruction("\tplt.text(xP-0.1,yP+0.01,str(item),fontsize=11)");

                if (item.HasScatter)
                {
                    Process.AddInstruction("plt.scatter(x" + index + ",y" + index + ")");
                }
                Process.AddInstruction("plt.plot(x" + index + ",y" + index + ")");
                index++;
            }
        }
    }

    public interface IGeneralComposer<T, Q>
    {
        IPythonProcess Process { get; }
        void WritePython();
        void WriteImportMatplotLib();
        void WritePlotColor(IPlotColor color);
        void WritePlotShow();
        void WriteXYPair(List<XyPair<T, Q>> xyPair);
    }
}
