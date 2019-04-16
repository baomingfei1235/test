using System;
using System.Collections.Generic;
using System.Text;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PPoint : PElement
    {
        private PWgCurve ownerPWg = null;
        private int type = 0;
        private float xvalue;
        private string printStr;

        public string PrintStr
        {
            get { return printStr; }
            set { printStr = value; }
        }

        public float Xvalue
        {
            get { return xvalue; }
            set { xvalue = value; }
        }
        private float yvalue;

        public float Yvalue
        {
            get { return yvalue; }
            set { yvalue = value; }
        }

        public PWgCurve Wg
        {
            get { return ownerPWg; }
            set { ownerPWg = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        public override bool Draw()
        {
            throw new NotImplementedException();
        }
    }
}
