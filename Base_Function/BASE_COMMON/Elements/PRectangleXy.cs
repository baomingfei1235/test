using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Base_Function.BLL_PARTOGRAM.InputControl;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PRectangleXy : PElement
    {
        private int xy1 = -1;

        public int Xy1
        {
            get { return xy1; }
            set { xy1 = value; }
        }

        private int xy2 = -1;

        public int Xy2
        {
            get { return xy2; }
            set { xy2 = value; }
        }

        public PRectangleXy(int x, int y, int width, int height, string name, Document document)
            : base
                (x, y, width, height, name, document)
        {

        }

        public override bool MouseClick(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            if (this.Contains(x, y))
            {
                using (frmXy xy = new frmXy(xy1, xy2))
                {
                    if (xy.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (xy.GetXy1 > 0)
                        {
                            this.xy1 = xy.GetXy1;
                        }
                        else
                        {
                            this.xy1 = -1;
                        }
                        if (xy.GetXy2 > 0)
                        {
                            this.xy2 = xy.GetXy2;
                        }
                        else
                        {
                            this.xy2 = -1;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public override bool Draw()
        {
            if (xy1 > 0 || xy2 > 0)
            {
                Font font = new Font("宋体",8);
                using (Brush b = new SolidBrush(Color.Black))
                {
                    Document.Format.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                    Document.Format.Alignment = StringAlignment.Near;
                    this.Document.View.Graph.DrawString(this.xy1.ToString(), font, b, new Rectangle(this.X-5, this.Y, this.Width - 2, this.Height / 2), this.Document.Format);
                    Document.Format.Alignment = StringAlignment.Far;
                    this.Document.View.Graph.DrawString(this.xy2.ToString(), font, b, new Rectangle(this.X + this.Document.celWidht / 2 -5, this.Y + this.Height / 2, this.Width - 2, this.Height / 2), this.Document.Format);
                    Document.Format.Alignment = StringAlignment.Center;
                    Document.Format.FormatFlags = 0;
                    using (Pen p = new Pen(Color.Black))
                    {
                        this.Document.View.Graph.DrawLine(p, this.X + 5, this.Y + (int)(this.Height * 0.7), this.X + this.Width - 5, this.Y + (int)(this.Height * 0.3));
                    }
                }
                font.Dispose();
            }

            return false;
        }
    }
}
