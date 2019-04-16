using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Base_Function.BASE_COMMON.Elements
{
    public class SortXValue:IComparer<PPoint>
    {
        public int Compare(PPoint x, PPoint y)
        {
            return x.Xvalue.CompareTo(y.Xvalue);
        }
    }
}
