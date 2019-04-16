using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Base_Function.MODEL;

namespace Base_Function.BASE_COMMON
{
    public class SortTime:IComparer<PartogramCurve>
    {
        public int Compare(PartogramCurve x, PartogramCurve y)
        {
            return DateTime.Compare(x.Time, y.Time);
        }
    }
}
