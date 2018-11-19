namespace LibStandard.Matplotlib
{
    public class Plot<T, Q> : IPlot<T, Q>
    {
        public IPythonProcess PythonProcess { get; private set; }

        public void Plot2Lists(ITwoListInput<T, Q> twoListInput)
        {
            var xAxis = twoListInput.XValues;
            var yAxis = twoListInput.YValues;

            PythonProcess.AddInstruction("python");
            PythonProcess.AddInstruction("import matplotlib.pyplot as plt");

            string xContent = "arr1 = [";
            foreach (var item in xAxis)
            {
                xContent += item + ",";
            }
            xContent = xContent.TrimEnd(',');
            xContent += "]";
            PythonProcess.AddInstruction(xContent);

            string yContent = "arr2 = [";
            foreach (var item in yAxis)
            {
                yContent += item + ",";
            }
            yContent = yContent.TrimEnd(',');
            yContent += "]";
            PythonProcess.AddInstruction(yContent);



            //PythonProcess.AddInstruction("fig = plt.figure(facecolor=\"" + twoListInput.Design.OutsideColor + "\")");
            //PythonProcess.AddInstruction("ax = plt.gca()");
            //PythonProcess.AddInstruction("ax.set_facecolor(\"" + twoListInput.Design.InsideColor + "\")");

            //PythonProcess.AddInstruction("plt.title(\"" + twoListInput.Design.Title + "\",fontsize=" + twoListInput.Design.TitleFontSize + ")");
            //PythonProcess.AddInstruction("plt.xlabel(\"" + twoListInput.XLabel + "\")");
            //PythonProcess.AddInstruction("plt.ylabel(\"" + twoListInput.YLabel + "\")");

            //PythonProcess.AddInstruction("plt.scatter(arr1,arr2)");
            //PythonProcess.AddInstruction("plt.plot(arr1,arr2)");

            //PythonProcess.AddInstruction("plt.show()");
            //PythonProcess.CommitInstruction();
        }

        public Plot(IPythonProcess pythonProcess)
        {
            PythonProcess = pythonProcess;
        }
    }

    public interface IPlot<T, Q>
    {
        IPythonProcess PythonProcess { get; }
        void Plot2Lists(ITwoListInput<T, Q> twoListInput);
    }
}
