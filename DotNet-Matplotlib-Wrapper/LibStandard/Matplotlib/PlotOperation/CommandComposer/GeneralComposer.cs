using System;
using System.Collections.Generic;
using System.Text;
using LibStandard.Matplotlib.PlotDesign;
using LibStandard.Matplotlib.PlotDesign.TickDesign;
using LibStandard.Matplotlib.PlotOperation.Pairs;

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

        public void WriteImportModules()
        {
            Process.AddInstruction("import matplotlib.pyplot as plt");
            //Process.AddInstruction("import pandas as pd");
            Process.AddInstruction("import datetime");
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

        public void WriteGrid(bool grid)
        {
            Process.AddInstruction("plt.grid(" + (grid ? "True" : "False") + ")");
        }

        public void WriteTitle(ITitle title)
        {
            Process.AddInstruction("plt.title(\"" + title.Text + "\",fontsize=" + title.FontSize + ")");
        }

        public void WriteTicksLong(IXTick<DateTime> xTick, IYTick<long> yTick, List<XyPair<T, Q>> xyPair)
        {
            DateTime minX = DateTime.MaxValue;
            DateTime maxX = DateTime.MinValue;
            long minY = long.MaxValue;
            long maxY = 0;

            foreach (var item in xyPair)
            {
                #region minmax

                foreach (var xItem in item.X)
                {
                    DateTime date = Convert.ToDateTime(xItem);
                    if (date < minX)
                    {
                        minX = date;
                    }
                    if (date > maxX)
                    {
                        maxX = date;
                    }
                }

                foreach (var yItem in item.Y)
                {
                    if (Convert.ToDecimal(yItem) < minY)
                    {
                        minY = Convert.ToInt64(yItem);
                    }
                    if (Convert.ToDecimal(yItem) > maxY)
                    {
                        maxY = Convert.ToInt64(yItem);
                    }
                }
                #endregion
            }

            #region X
            string leftContent = "";
            string rightContent = "";

            leftContent += "plt.xticks([";
            DateTime aux = minX;
            while (aux <= maxX)
            {
                leftContent += "datetime.datetime.combine(datetime.date(" + aux.ToString("yyyy,M,d") + "), datetime.time(" + aux.ToString("H,m,s") + ")),";
                rightContent += "\"" + aux.ToString("M/d") + "\\n" + aux.ToString("H:m") + "\",";
                aux = aux.Add(new TimeSpan(0, 2, 0, 0));
            }
            leftContent = leftContent.TrimEnd(',') + "],[" + rightContent.TrimEnd(',') + "])";
            Process.AddInstruction(leftContent);
            #endregion

            if (minY > 0)
            {
                minY = 0;
            }

            leftContent = "";
            rightContent = "";

            leftContent += "plt.yticks([";
            while (minY <= maxY)
            {
                leftContent += minY + ",";
                rightContent += "\"" + minY + "\",";
                minY += 10000000;
            }

            //Again so it reaches the top
            minY += 10000000;
            rightContent += "\"" + minY + "\",";

            leftContent = leftContent.TrimEnd(',') + "],[" + rightContent.TrimEnd(',') + "])";
            Process.AddInstruction(leftContent);
        }

        public void WriteLabelXY(string xLabel, string yLabel)
        {
            Process.AddInstruction($"plt.xlabel(\"{xLabel}\")");
            Process.AddInstruction($"plt.ylabel(\"{yLabel}\")");
        }

        public void WriteTicks(IXTick<DateTime> xTick, IYTick<decimal> yTick, List<XyPair<T, Q>> xyPair, decimal increaseTickRate)
        {
            DateTime minX = DateTime.MaxValue;
            DateTime maxX = DateTime.MinValue;
            decimal minY = int.MaxValue;
            decimal maxY = 0;

            foreach (var item in xyPair)
            {
                #region minmax

                foreach (var xItem in item.X)
                {
                    DateTime date = Convert.ToDateTime(xItem);
                    if (date < minX)
                    {
                        minX = date;
                    }
                    if (date > maxX)
                    {
                        maxX = date;
                    }
                }

                foreach (var yItem in item.Y)
                {
                    if (Convert.ToDecimal(yItem) < minY)
                    {
                        minY = Convert.ToDecimal(yItem);
                    }
                    if (Convert.ToDecimal(yItem) > maxY)
                    {
                        maxY = Convert.ToDecimal(yItem);
                    }
                }
                #endregion
            }

            #region X
            string leftContent = "";
            string rightContent = "";

            leftContent += "plt.xticks([";
            DateTime aux = minX;
            while (aux <= maxX)
            {
                //leftContent += "datetime.date(" + aux.ToString("yyyy,MM,d,H,m,s") + "),";
                leftContent += "datetime.datetime.combine(datetime.date(" + aux.ToString("yyyy,M,d") + "), datetime.time(" + aux.ToString("H,m,s") + ")),";
                rightContent += "\"" + aux.ToString("M/d") + "\\n" + aux.ToString("H:m") + "\",";
                aux = aux.Add(new TimeSpan(0, 2, 0, 0));
            }
            leftContent = leftContent.TrimEnd(',') + "],[" + rightContent.TrimEnd(',') + "])";
            Process.AddInstruction(leftContent);
            #endregion

            if (minY > 0)
            {
                minY = 0m;
            }

            leftContent = "";
            rightContent = "";

            leftContent += "plt.yticks([";

            for (minY = 0m; minY < (maxY + increaseTickRate); minY += increaseTickRate)
            {
                leftContent += minY + ",";
                rightContent += "\"{:,}\".format(" + minY + "),";//add sufix
                //Process.AddInstruction("\tplt.text(xP, yP, \"{:,}\".format(item) + \"" + scatterSuffix + "\", fontsize=11)");
            }

            //while (minY <= maxY)
            //{
            //    leftContent += minY + ",";
            //    rightContent += "\"" + minY + "\",";
            //    minY += increaseTickRate;
            //}


            leftContent = leftContent.TrimEnd(',') + "],[" + rightContent.TrimEnd(',') + "])";
            Process.AddInstruction(leftContent);
        }

        public void WriteTicks_old(IXTick<DateTime> xTick, IYTick<decimal> yTick, List<XyPair<T, Q>> xyPair)
        {
            DateTime minX = DateTime.MaxValue;
            DateTime maxX = DateTime.MinValue;
            decimal minY = int.MaxValue;
            decimal maxY = 0;

            foreach (var item in xyPair)
            {
                #region minmax

                foreach (var xItem in item.X)
                {
                    DateTime date = Convert.ToDateTime(xItem);
                    if (date < minX)
                    {
                        minX = date;
                    }
                    if (date > maxX)
                    {
                        maxX = date;
                    }
                }

                foreach (var yItem in item.Y)
                {
                    if (Convert.ToDecimal(yItem) < minY)
                    {
                        minY = Convert.ToDecimal(yItem);
                    }
                    if (Convert.ToDecimal(yItem) > maxY)
                    {
                        maxY = Convert.ToDecimal(yItem);
                    }
                }
                #endregion
            }

            #region X
            string leftContent = "";
            string rightContent = "";

            leftContent += "plt.xticks([";
            DateTime aux = minX;
            while (aux <= maxX)
            {
                leftContent += "datetime.datetime.combine(datetime.date(" + aux.ToString("yyyy,M,d") + "), datetime.time(" + aux.ToString("H,m,s") + ")),";
                rightContent += "\"" + aux.ToString("M/d") + "\\n" + aux.ToString("H:m") + "\",";
                aux = aux.Add(new TimeSpan(0, 2, 0, 0));
            }
            leftContent = leftContent.TrimEnd(',') + "],[" + rightContent.TrimEnd(',') + "])";
            Process.AddInstruction(leftContent);
            #endregion

            if (minY > 0)
            {
                minY = 0m;
            }

            leftContent = "";
            rightContent = "";

            leftContent += "plt.yticks([";
            while (minY <= maxY)
            {
                leftContent += minY + ",";
                rightContent += "\"" + minY + "\",";
                minY += 0.1m;
            }
            leftContent = leftContent.TrimEnd(',') + "],[" + rightContent.TrimEnd(',') + "])";
            Process.AddInstruction(leftContent);
        }

        public void WriteTicks(IXTick<DateTime> xTick, IYTick<decimal> yTick)
        {
            string content = "";

            if (xTick != null)
            {
                content += "plt.xticks([";
                foreach (var item in xTick.Values)
                {
                    content += item.Item1 + ",";
                }

                content = content.TrimEnd(',') + "],[";

                foreach (var item in xTick.Values)
                {
                    content += "\"" + item.Item2 + "\",";
                }
                content = content.TrimEnd(',') + "])";
                Process.AddInstruction(content);
            }


            if (yTick != null)
            {
                content = "";
                content += "plt.yticks([";
                foreach (var item in yTick.Values)
                {
                    content += item.Item1 + ",";
                }

                content = content.TrimEnd(',') + "],[";

                foreach (var item in yTick.Values)
                {
                    content += "\"" + item.Item2 + "\",";
                }

                content = content.TrimEnd(',') + "])";

                Process.AddInstruction(content);
            }
        }

        public void WritePlotShow()
        {
            Process.AddInstruction("canvas = ax.figure.canvas");
            Process.AddInstruction("canvas.manager.window.move(-1920, 100)");
            Process.AddInstruction("plt.show()");
        }

        public void WriteXYPair(List<XyPair<T, Q>> xyPair, string scatterSuffix)
        {
            int index = 1;
            string content = "";

            foreach (var item in xyPair)
            {
                content = "x" + index + " = [";
                foreach (var x in item.X)
                {
                    //content += "datetime.date(" + Convert.ToDateTime(x).ToString("yyyy,MM,d,H,m,s") + "),";
                    content += "datetime.datetime.combine(datetime.date(" + Convert.ToDateTime(x).ToString("yyyy,M,d") + "), datetime.time(" + Convert.ToDateTime(x).ToString("H,m,s") + ")),";
                }
                content = content.TrimEnd(',') + "]";
                Process.AddInstruction(content);


                content = "y" + index + " = [";
                foreach (var y in item.Y)
                {
                    content += y + ",";
                }
                content = content.TrimEnd(',') + "]";
                Process.AddInstruction(content);

                //Process.AddInstruction("for i,item in enumerate(y" + index + "):");
                //Process.AddInstruction("\txP = x" + index + "[i]");
                //Process.AddInstruction("\tyP = y" + index + "[i]");
                //Process.AddInstruction("\tplt.text(xP, yP, \"{:,}\".format(item) + \"" + scatterSuffix + "\", fontsize=11)");

                Process.AddInstruction("plt.plot(x" + index + ",y" + index + $",label=\"{item.Legend}\")");
                if (item.HasScatter)
                {
                    Process.AddInstruction("plt.scatter(x" + index + ",y" + index + ")");
                }
                Process.AddInstruction("plt.legend()");
                index++;
            }
        }
    }

    public interface IGeneralComposer<T, Q>
    {
        IPythonProcess Process { get; }
        void WritePython();
        void WriteImportModules();
        void WritePlotColor(IPlotColor color);
        void WriteGrid(bool grid);
        void WriteTitle(ITitle title);
        void WriteTicks(IXTick<DateTime> xTick, IYTick<decimal> yTick);
        void WriteTicks(IXTick<DateTime> xTick, IYTick<decimal> yTick, List<XyPair<T, Q>> xyPair, decimal increaseTickRate);
        void WriteXYPair(List<XyPair<T, Q>> xyPair, string scatterSuffix);
        void WritePlotShow();
        void WriteTicksLong(IXTick<DateTime> xTick, IYTick<long> yTick, List<XyPair<T, Q>> xyPair);
        void WriteLabelXY(string xLabel, string yLabel);
    }
}
