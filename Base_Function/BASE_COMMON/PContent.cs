using System;
using System.Collections.Generic;
using System.Text;
using Base_Function.BASE_COMMON.Elements;

namespace Base_Function.BASE_COMMON
{  
    public class PContent
    {
        private List<PElement> element = new List<PElement>();

        internal List<PElement> Element
        {
            get { return element; }
            set { element = value; }
        }
    }
}
