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
        public ITickComposer<T, Q> TickComposer { get; private set; }
        public IPythonProcess PythonProcess { get; }

        public GeneralComposer(IPythonProcess process, ITickComposer<T, Q> tickComposer)
        {
            TickComposer = tickComposer;
            PythonProcess = process;
        }

        public void WritePython()
        {
            PythonProcess.AddInstruction("python");
        }

        public void WriteImportModules()
        {
            PythonProcess.AddInstruction("import matplotlib.pyplot as plt");
            //Process.AddInstruction("import pandas as pd");
            PythonProcess.AddInstruction("import datetime");
        }

        public void WritePlotColor(IPlotColor color)
        {
            if (color.OutsideColor != null)
            {
                PythonProcess.AddInstruction("fig = plt.figure(facecolor=\"" + color.OutsideColor + "\")");
            }

            if (color.InsideColor != null)
            {
                PythonProcess.AddInstruction("ax = plt.gca()");
                PythonProcess.AddInstruction("ax.set_facecolor(\"" + color.InsideColor + "\")");
            }
        }

        public void WriteGrid(bool grid)
        {
            PythonProcess.AddInstruction("plt.grid(" + (grid ? "True" : "False") + ")");
        }

        public void WriteTitle(ITitle title)
        {
            PythonProcess.AddInstruction("plt.title(\"" + title.Text + "\",fontsize=" + title.FontSize + ")");
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
            PythonProcess.AddInstruction(leftContent);
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
            PythonProcess.AddInstruction(leftContent);
        }

        public void WriteLabelXY(string xLabel, string yLabel)
        {
            PythonProcess.AddInstruction($"plt.xlabel(\"{xLabel}\")");
            PythonProcess.AddInstruction($"plt.ylabel(\"{yLabel}\")");
        }

        public void WriteTicks(IXTick<DateTime> xTick, IYTick<decimal> yTick, List<XyPair<T, Q>> xyPair, decimal increaseTickRate)
        {
            TickComposer.WriteTick(xTick, yTick, xyPair, increaseTickRate);
            //DateTime minX = DateTime.MaxValue;
            //DateTime maxX = DateTime.MinValue;
            //decimal minY = int.MaxValue;
            //decimal maxY = 0;

            //foreach (var item in xyPair)
            //{
            //    #region minmax

            //    foreach (var xItem in item.X)
            //    {
            //        DateTime date = Convert.ToDateTime(xItem);
            //        if (date < minX)
            //        {
            //            minX = date;
            //        }
            //        if (date > maxX)
            //        {
            //            maxX = date;
            //        }
            //    }

            //    foreach (var yItem in item.Y)
            //    {
            //        if (Convert.ToDecimal(yItem) < minY)
            //        {
            //            minY = Convert.ToDecimal(yItem);
            //        }
            //        if (Convert.ToDecimal(yItem) > maxY)
            //        {
            //            maxY = Convert.ToDecimal(yItem);
            //        }
            //    }
            //    #endregion
            //}

            //#region X
            //string leftContent = "";
            //string rightContent = "";

            //leftContent += "plt.xticks([";
            //DateTime aux = minX;
            //while (aux <= maxX)
            //{
            //    //leftContent += "datetime.date(" + aux.ToString("yyyy,MM,d,H,m,s") + "),";
            //    leftContent += "datetime.datetime.combine(datetime.date(" + aux.ToString("yyyy,M,d") + "), datetime.time(" + aux.ToString("H,m,s") + ")),";
            //    rightContent += "\"" + aux.ToString("M/d") + "\\n" + aux.ToString("H:m") + "\",";
            //    aux = aux.Add(new TimeSpan(0, 2, 0, 0));
            //}
            //leftContent = leftContent.TrimEnd(',') + "],[" + rightContent.TrimEnd(',') + "])";
            //PythonProcess.AddInstruction(leftContent);
            //#endregion

            //if (minY > 0)
            //{
            //    minY = 0m;
            //}

            //leftContent = "";
            //rightContent = "";

            //leftContent += "plt.yticks([";

            //for (minY = 0m; minY < (maxY + increaseTickRate); minY += increaseTickRate)
            //{
            //    leftContent += minY + ",";
            //    rightContent += "\"{:,}\".format(" + minY + "),";//add sufix
            //    //Process.AddInstruction("\tplt.text(xP, yP, \"{:,}\".format(item) + \"" + scatterSuffix + "\", fontsize=11)");
            //}

            ////while (minY <= maxY)
            ////{
            ////    leftContent += minY + ",";
            ////    rightContent += "\"" + minY + "\",";
            ////    minY += increaseTickRate;
            ////}


            //leftContent = leftContent.TrimEnd(',') + "],[" + rightContent.TrimEnd(',') + "])";
            //PythonProcess.AddInstruction(leftContent);
        }

        //public void WriteTicks_old(IXTick<DateTime> xTick, IYTick<decimal> yTick, List<XyPair<T, Q>> xyPair)
        //{
        //    DateTime minX = DateTime.MaxValue;
        //    DateTime maxX = DateTime.MinValue;
        //    decimal minY = int.MaxValue;
        //    decimal maxY = 0;

        //    foreach (var item in xyPair)
        //    {
        //        #region minmax

        //        foreach (var xItem in item.X)
        //        {
        //            DateTime date = Convert.ToDateTime(xItem);
        //            if (date < minX)
        //            {
        //                minX = date;
        //            }
        //            if (date > maxX)
        //            {
        //                maxX = date;
        //            }
        //        }

        //        foreach (var yItem in item.Y)
        //        {
        //            if (Convert.ToDecimal(yItem) < minY)
        //            {
        //                minY = Convert.ToDecimal(yItem);
        //            }
        //            if (Convert.ToDecimal(yItem) > maxY)
        //            {
        //                maxY = Convert.ToDecimal(yItem);
        //            }
        //        }
        //        #endregion
        //    }

        //    #region X
        //    string leftContent = "";
        //    string rightContent = "";

        //    leftContent += "plt.xticks([";
        //    DateTime aux = minX;
        //    while (aux <= maxX)
        //    {
        //        leftContent += "datetime.datetime.combine(datetime.date(" + aux.ToString("yyyy,M,d") + "), datetime.time(" + aux.ToString("H,m,s") + ")),";
        //        rightContent += "\"" + aux.ToString("M/d") + "\\n" + aux.ToString("H:m") + "\",";
        //        aux = aux.Add(new TimeSpan(0, 2, 0, 0));
        //    }
        //    leftContent = leftContent.TrimEnd(',') + "],[" + rightContent.TrimEnd(',') + "])";
        //    Process.AddInstruction(leftContent);
        //    #endregion

        //    if (minY > 0)
        //    {
        //        minY = 0m;
        //    }

        //    leftContent = "";
        //    rightContent = "";

        //    leftContent += "plt.yticks([";
        //    while (minY <= maxY)
        //    {
        //        leftContent += minY + ",";
        //        rightContent += "\"" + minY + "\",";
        //        minY += 0.1m;
        //    }
        //    leftContent = leftContent.TrimEnd(',') + "],[" + rightContent.TrimEnd(',') + "])";
        //    Process.AddInstruction(leftContent);
        //}


        //public void WriteTicks(IXTick<DateTime> xTick, IYTick<decimal> yTick)
        //{
        //    string content = "";

        //    if (xTick != null)
        //    {
        //        content += "plt.xticks([";
        //        foreach (var item in xTick.Values)
        //        {
        //            content += item.Item1 + ",";
        //        }

        //        content = content.TrimEnd(',') + "],[";

        //        foreach (var item in xTick.Values)
        //        {
        //            content += "\"" + item.Item2 + "\",";
        //        }
        //        content = content.TrimEnd(',') + "])";
        //        Process.AddInstruction(content);
        //    }


        //    if (yTick != null)
        //    {
        //        content = "";
        //        content += "plt.yticks([";
        //        foreach (var item in yTick.Values)
        //        {
        //            content += item.Item1 + ",";
        //        }

        //        content = content.TrimEnd(',') + "],[";

        //        foreach (var item in yTick.Values)
        //        {
        //            content += "\"" + item.Item2 + "\",";
        //        }

        //        content = content.TrimEnd(',') + "])";

        //        Process.AddInstruction(content);
        //    }
        //}

        public void WritePlotShow()
        {
            PythonProcess.AddInstruction("canvas = ax.figure.canvas");
            PythonProcess.AddInstruction("canvas.manager.window.move(-1920, 100)");
            PythonProcess.AddInstruction("plt.show()");
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
                    if (TickComposer.XHasHour)
                    {
                        content += "datetime.datetime.combine(datetime.date(" + Convert.ToDateTime(x).ToString("yyyy,M,d") + "), datetime.time(" + Convert.ToDateTime(x).ToString("H,m,s") + ")),";
                    }
                    else
                    {
                        content += "datetime.datetime.combine(datetime.date(" + Convert.ToDateTime(x).ToString("yyyy,M,d") + "), datetime.time(" + Convert.ToDateTime(x).ToString("H,m,s") + ")),";
                        //content += "datetime.date(" + Convert.ToDateTime(x).ToString("yyyy,MM,d") + "),";
                    }
                }
                content = content.TrimEnd(',') + "]";
                PythonProcess.AddInstruction(content);


                content = "y" + index + " = [";
                foreach (var y in item.Y)
                {
                    content += y + ",";
                }
                content = content.TrimEnd(',') + "]";
                PythonProcess.AddInstruction(content);

                //Process.AddInstruction("for i,item in enumerate(y" + index + "):");
                //Process.AddInstruction("\txP = x" + index + "[i]");
                //Process.AddInstruction("\tyP = y" + index + "[i]");
                //Process.AddInstruction("\tplt.text(xP, yP, \"{:,}\".format(item) + \"" + scatterSuffix + "\", fontsize=11)");

                PythonProcess.AddInstruction("plt.plot(x" + index + ",y" + index + $",label=\"{item.Legend}\")");
                if (item.HasScatter)
                {
                    PythonProcess.AddInstruction("plt.scatter(x" + index + ",y" + index + ")");
                }
                PythonProcess.AddInstruction("plt.legend()");
                index++;
            }
        }
    }

    public interface IGeneralComposer<T, Q>
    {
        IPythonProcess PythonProcess { get; }
        void WritePython();
        void WriteImportModules();
        void WritePlotColor(IPlotColor color);
        void WriteGrid(bool grid);
        void WriteTitle(ITitle title);

        void WriteTicks(IXTick<DateTime> xTick, IYTick<decimal> yTick, List<XyPair<T, Q>> xyPair, decimal increaseTickRate);

        void WriteXYPair(List<XyPair<T, Q>> xyPair, string scatterSuffix);
        void WritePlotShow();
        void WriteTicksLong(IXTick<DateTime> xTick, IYTick<long> yTick, List<XyPair<T, Q>> xyPair);
        void WriteLabelXY(string xLabel, string yLabel);
        ITickComposer<T, Q> TickComposer { get; }
    }
}
