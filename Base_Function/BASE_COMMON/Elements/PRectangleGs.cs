using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Base_Function.BLL_PARTOGRAM.InputControl;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PRectangleGs : PElement
    {
        public PRectangleGs(int x, int y, int width, int height, string name, Document document)
            : base
                (x, y, width, height, name, document)
        {

        }

        private int m1 = -1;

        public int M1
        {
            get { return m1; }
            set { m1 = value; }
        }

        private int m2 = -1;

        public int M2
        {
            get { return m2; }
            set { m2 = value; }
        }

        private int s1 = -1;

        public int S1
        {
            get { return s1; }
            set { s1 = value; }
        }

        private int s2 = -1;

        public int S2
        {
            get { return s2; }
            set { s2 = value; }
        }

        public override bool MouseClick(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            if (this.Contains(x, y))
            {
                using (frmGs gs = new frmGs(s1, s2, m1, m2))
                {
                    if (gs.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (gs.S1 > 0)
                            this.s1 = gs.S1;
                        else
                            this.s1 = -1;

                        if (gs.S2 > 0)
                            this.s2 = gs.S2;
                        else
                            this.s2 = -1;

                        if (gs.M1 > 0)
                            this.m1 = gs.M1;
                        else
                            this.m1 = -1;

                        if (gs.S2 > 0)
                            this.m2 = gs.M2;
                        else
                            this.m2 = -1;
                    }
                }
                return true;
            }
            return false;
        }

        private string GetStrMinute
        {
            get
            {
                return this.m1.ToString() + "-" + this.m2.ToString() + "′";
            }
        }

        private string GetStrSecond
        {
            get
            {
                return this.s1.ToString() + "-" + this.s2.ToString() + "″";
            }
        }

        public override bool Draw()
        {
            using (Brush brush = new SolidBrush(Color.Black))
            {
                Font font = new Font("宋体",5);
                if (m1 > 0 && m2 > 0 && s1 > 0 && s2 > 0)
                {
                    string str = GetStrSecond;
                    string str2 = GetStrMinute;
                    this.Document.View.Graph.DrawString(str, font, brush, new Rectangle(this.X, this.Y, this.Width, this.Height / 2), this.Document.Format);
                    this.Document.View.Graph.DrawString(str2, font, brush, new Rectangle(this.X, this.Y + this.Height / 2, this.Width, this.Height / 2), this.Document.Format);
                    using (Pen p = new Pen(Color.Black))
                    {
                        int width = (int)this.Document.View.Graph.MeasureString(str, font, 1000, StringFormat.GenericDefault).Width;
                        int width2 = (int)this.Document.View.Graph.MeasureString(str2, font, 1000, StringFormat.GenericDefault).Width;
                        int maxWidth = (width > width2 ? width : width2);
                        this.Document.View.Graph.DrawLine(p, this.X + 2, this.Y + this.Height / 2, this.X + this.Width - 2, this.Y + this.Height / 2);
                    }
                }
            }
            return true;
        }
    }
}
