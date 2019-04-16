using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PDrawTimeHours : PElement
    {
        public PDrawTimeHours(int x, int y, int width, int height, string name, Document document)
            : base
                (x, y, width, height, name, document)
        {

        }

        public override bool Draw()
        {
            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体", 10);
                using (Pen p = new Pen(Color.Black))
                {
                    base.Document.View.Graph.DrawLine(p, this.X - 50, this.Y, this.X - 50, this.RealBottom);
                    base.Document.View.Graph.DrawLine(p, this.X, this.Y, this.X, this.RealBottom);
                    base.Document.View.Graph.DrawLine(p, this.X - 50, this.Y, this.X - 13, this.Y);
                    base.Document.View.Graph.DrawLine(p, this.RealRight, this.Y + this.Height / 2, this.RealRight, this.RealBottom);
                    using (Font f = new Font("宋体", 8))
                    {
                        base.Document.View.Graph.DrawString("(小时)", f, brush, new Rectangle(this.RealRight, this.Y, this.Document.celWidht * 2, this.Document.celWidht), Document.Format);
                    }
                }
                for (int i = 0; i < this.Document.WCount + 1; i++)
                {
                    if (i == 0)
                        continue;
                    int left = this.X + (this.Document.celWidht / 2) + (i - 1) * this.Document.celWidht;
                    base.Document.View.Graph.DrawString((i).ToString(), font, brush, new Rectangle(left, this.Y + 2, this.Document.celWidht, this.Document.celWidht / 2), this.Document.Format);
                    //base.Document.View.Graph.DrawRectangle(Pens.Black, new Rectangle(this.X + (this.Document.celWidht / 2) + i * this.Document.celWidht, this.Y, this.Document.celWidht, this.Document.celWidht / 2));
                    if (this.Document.Userinfo.LeftMoveTime > 0 && i < 24)
                    {
                        base.Document.View.Graph.DrawString((i + this.Document.Userinfo.LeftMoveTime).ToString(), font, brush, new Rectangle(left, this.Y + this.Height / 2, this.Document.celWidht, this.Document.celWidht / 2), this.Document.Format);
                    }
                }
                font.Dispose();
            }
            return false;
        }
    }
}
