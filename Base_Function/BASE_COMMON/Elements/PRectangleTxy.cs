using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Base_Function.BLL_PARTOGRAM.InputControl;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PRectangleTxy : PElement
    {
        private int txy = -1;

        public int Txy
        {
            get { return txy; }
            set { txy = value; }
        }

        private string content = string.Empty;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public PRectangleTxy()
        {
 
        }

        public PRectangleTxy(int x, int y, int width, int height, string name, Document document)
            : base
                (x, y, width, height, name, document)
        {

        }

        public override bool MouseMove(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            if (this.Bounds.Contains(x, y))
            {
                return true;
            }
            return false;
        }

        public override bool Draw()
        {
            if (this.Document.Userinfo.Xjtxy == 0)
                return true;
            if (this.txy>0)
            {
                using (Brush b = new SolidBrush(Color.Black))
                {
                    Font f = new Font("宋体", 8);
                    base.Document.View.Graph.DrawString(txy.ToString(), f, Brushes.Black, new Rectangle(this.X, this.Y, this.Width, this.Height), this.Document.Format);
                    f.Dispose();
                }
            }
            return false;
        }

        public override bool MouseClick(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            if (this.Contains(x, y))
            {
                using (frmTxy txy = new frmTxy(this.txy))
                {
                    if (txy.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (txy.GetTxy > 0)
                            this.txy = txy.GetTxy;
                        else
                            this.txy = -1;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
