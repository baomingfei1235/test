using System;
using System.Collections.Generic;
using System.Text;
using Base_Function.BLL_PARTOGRAM.InputControl;
using System.Drawing;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PRectangleTm : PRectangleTxy
    {
        public PRectangleTm(int x, int y, int width, int height, string name, Document document)
            : base
                (x, y, width, height, name, document)
        {

        }

        public override bool MouseClick(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            if (this.Contains(x, y))
            {
                using (frmTm tm = new frmTm(this.Content))
                {
                    if (tm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (tm.GetStr == "无")
                        {
                            this.Content = "";
                        }
                        else
                        {
                            this.Content = tm.GetStr;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public override bool Draw()
        {
            if (!string.IsNullOrEmpty(this.Content))
            {
                using (Brush b = new SolidBrush(Color.Black))
                {
                    Font f = new Font("宋体", 8);
                    base.Document.View.Graph.DrawString(this.Content, f, Brushes.Black, new Rectangle(this.X, this.Y, this.Width, this.Height), this.Document.Format);
                    f.Dispose();
                }
            }
            return true;
        }
    }
}
