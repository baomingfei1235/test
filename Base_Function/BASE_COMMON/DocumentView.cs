using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Base_Function.BASE_COMMON
{
    public class DocumentView
    {
        Graphics graphice = null;
        public Graphics Graph
        {
            get
            {
                return graphice;
            }

            set
            {
                graphice = value;
            }
        }
    }
}
