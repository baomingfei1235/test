using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Base_Function.BLL_PARTOGRAM.InputControl;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PRectangleQm : PRectangleTm
    {
        public PRectangleQm(int x, int y, int width, int height, string name, Document document)
            : base
                (x, y, width, height, name, document)
        {

        }

        private string userId = string.Empty;

        public string UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public override bool MouseClick(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            if (this.Contains(x, y))
            {
                using (frmQm tm = new frmQm(this.Content, userId))
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

        public override bool Draw()
        {
            if (!string.IsNullOrEmpty(this.Content))
            {
                using (Brush b = new SolidBrush(Color.Black))
                {
                    Font f = new Font("宋体", 9);
                    base.Document.View.Graph.DrawString(this.Content, f, Brushes.Black, new Rectangle(this.X, this.Y, this.Width, this.Height), this.Document.Format);
                    f.Dispose();
                }
            }
            return true;
        }
    }
}
