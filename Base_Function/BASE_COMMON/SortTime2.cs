using System;
using System.Collections.Generic;
using System.Text;
using Base_Function.MODEL;

namespace Base_Function.BASE_COMMON
{
    public class SortTime2:IComparer<PartogramMccs>
    {
        public int Compare(PartogramMccs x, PartogramMccs y)
        {
            return DateTime.Compare(x.Time, y.Time);
        }
    }
}
