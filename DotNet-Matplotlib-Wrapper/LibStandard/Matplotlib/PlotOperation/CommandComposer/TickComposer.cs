using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using LibStandard.Matplotlib.PlotDesign.TickDesign;
using LibStandard.Matplotlib.PlotOperation.Pairs;

namespace LibStandard.Matplotlib.PlotOperation.CommandComposer
{
    public class TickComposer<T, Q> : ITickComposer<T, Q>
    {
        public IPythonProcess PythonProcess { get; private set; }
        public bool XHasHour { get; private set; }

        public TickComposer(bool xHasHour, IPythonProcess pythonProcess)
        {
            XHasHour = xHasHour;
            PythonProcess = pythonProcess;
        }

        protected void XisDateYisDecimal(IXTick<DateTime> xAxis, IYTick<decimal> yAxis, List<XyPair<T, Q>> xyPair, decimal increaseTickRate)
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
                leftContent += "datetime.date(" + aux.ToString("yyyy,MM,d") + "),";
                rightContent += "\"" + aux.ToString("M/d") + "\\n" + aux.ToString("ddd") + "\",";
                aux = aux.Add(new TimeSpan(1, 0, 0, 0));//TODO:aaaa
            }
            leftContent = leftContent.TrimEnd(',') + "],[" + rightContent.TrimEnd(',') + "])";
            PythonProcess.AddInstruction(leftContent);
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
            PythonProcess.AddInstruction(leftContent);
        }

        protected void XisDateTimeYisDecimal(IXTick<DateTime> xAxis, IYTick<decimal> yAxis, List<XyPair<T, Q>> xyPair, decimal increaseTickRate)
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
            PythonProcess.AddInstruction(leftContent);
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
            PythonProcess.AddInstruction(leftContent);
        }

        public void WriteTick(IXTick<DateTime> xAxis, IYTick<decimal> yAxis, List<XyPair<T, Q>> xyPair, decimal increaseTickRate)
        {
            if (XHasHour)
            {
                XisDateTimeYisDecimal(xAxis, yAxis, xyPair, increaseTickRate);
            }
            else
            {
                XisDateYisDecimal(xAxis, yAxis, xyPair, increaseTickRate);
            }
        }
    }

    public interface ITickComposer<T, Q>
    {
        IPythonProcess PythonProcess { get; }
        void WriteTick(IXTick<DateTime> xAxis, IYTick<decimal> yAxis, List<XyPair<T, Q>> xyPair, decimal increaseTickRate);
        bool XHasHour { get; }
    }
}