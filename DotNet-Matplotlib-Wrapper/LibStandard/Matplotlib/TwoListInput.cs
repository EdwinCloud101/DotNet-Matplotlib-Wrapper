using System;
using System.Collections.Generic;
using System.Linq;

namespace LibStandard.Matplotlib
{
    public class TwoListInput : ITwoListInput
    {
        public string Input1Title { get; private set; }
        public List<string> Input1 { get; private set; }

        public string Input2Title { get; private set; }
        public List<string> Input2 { get; private set; }
        public void AddInput1(List<string> list, string title)
        {
            Input1.AddRange(list);
            Input1Title = title;
        }

        public void AddInput2(List<string> list, string title)
        {
            Input2.AddRange(list);
            Input2Title = title;
        }

        public TwoListInput()
        {
            Input1 = new List<string>();
            Input2 = new List<string>();
        }
    }

    public interface ITwoListInput
    {
        string Input1Title { get; }
        List<string> Input1 { get; }

        string Input2Title { get; }
        List<string> Input2 { get; }

        void AddInput1(List<string> list, string title);
        void AddInput2(List<string> list, string title);
    }
}
