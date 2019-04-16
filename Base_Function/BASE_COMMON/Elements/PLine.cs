using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PLine : PElement
    {
        private int x1;

        public int X1
        {
            get { return x1; }
            set { x1 = value; }
        }
        private int y1;

        public int Y1
        {
            get { return y1; }
            set { y1 = value; }
        }

        public override bool Draw()
        {
            using (Pen p = new Pen(Color.Black, 1))
            {
                this.Document.View.Graph.DrawLine(p, this.X, this.Y, this.X1, this.Y1);
            }
            return false;
        }
    }
}
