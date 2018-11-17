using System;
using System.Collections.Generic;
using System.Linq;

namespace LibStandard.Matplotlib
{
    public class TwoListInput<T, Q> : ITwoListInput<T, Q>
    {
        public string Input1Title { get; set; }
        public List<T> Input1 { get; set; }

        public string Input2Title { get; set; }
        public List<Q> Input2 { get; set; }

        public void AddInput1(List<T> list, string title)
        {
            Input1.AddRange(list);
            Input1Title = title;
        }

        public void AddInput2(List<Q> list, string title)
        {
            Input2.AddRange(list);
            Input2Title = title;
        }

        public TwoListInput()
        {
            Input1 = new List<T>();
            Input2 = new List<Q>();
        }
    }

    public interface ITwoListInput<T, Q>
    {
        string Input1Title { get; set; }
        List<T> Input1 { get; set; }

        string Input2Title { get; set; }
        List<Q> Input2 { get; set; }

        void AddInput1(List<T> list, string title);
        void AddInput2(List<Q> list, string title);
    }
}
