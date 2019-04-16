using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Base_Function.BLL_PARTOGRAM.InputControl;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PRectangleOther : PRectangleTxy
    {
        public PRectangleOther(int x, int y, int width, int height, string name, Document document)
            : base
                (x, y, width, height, name, document)
        {

        }

        public override bool Draw()
        {
            if (!string.IsNullOrEmpty(this.Content))
            {
                base.Document.View.Graph.DrawString(Content, new Font("宋体", 8), Brushes.Black, new Rectangle(this.X, this.Y, this.Width, this.Height));
            }
            return false;
        }

        public override bool MouseClick(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            if (this.Contains(x, y))
            {
                using (frmOther tm = new frmOther(this.Content))
                {
                    if (tm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.Content = tm.GetStr;
                    }
                }
                return true;
            }
            return false;
        }
    }
}
