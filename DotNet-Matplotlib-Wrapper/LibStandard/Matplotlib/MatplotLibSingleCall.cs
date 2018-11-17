namespace LibStandard.Matplotlib
{
    public class MatplotLibSingleCall<T, Q> : IMatplotLibSingleCall<T, Q>
    {
        public IPythonProcess PythonProcess { get; private set; }

        public void Plot2Lists(ITwoListInput<T, Q> twoListInput)
        {
            var xAxis = twoListInput.Input1;
            var yAxis = twoListInput.Input2;

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

            PythonProcess.AddInstruction("plt.scatter(arr1,arr2)");
            PythonProcess.AddInstruction("plt.plot(arr1,arr2)");

            PythonProcess.AddInstruction("plt.title(\"" + twoListInput.Title + "\")");
            PythonProcess.AddInstruction("plt.xlabel(\"" + twoListInput.Input1Title + "\")");
            PythonProcess.AddInstruction("plt.ylabel(\"" + twoListInput.Input2Title + "\")");

            PythonProcess.AddInstruction("plt.show()");
            PythonProcess.CommitInstruction();
        }

        public MatplotLibSingleCall(IPythonProcess pythonProcess)
        {
            PythonProcess = pythonProcess;
        }
    }

    public interface IMatplotLibSingleCall<T, Q>
    {
        IPythonProcess PythonProcess { get; }
        void Plot2Lists(ITwoListInput<T, Q> twoListInput);
    }
}
