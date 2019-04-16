using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PDrawHeader : PElement
    {
        private string content = string.Empty;

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public PDrawHeader()
        {
 
        }

        public PDrawHeader(int x, int y, int width, int height, string name, Document document)
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
            base.Document.View.Graph.DrawString(this.Name + content, new Font("宋体", 12), Brushes.Black, new Rectangle(this.X - 2, this.Y, this.Width + 4, this.Height));
            return false;
        }

        public override bool MouseClick(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            if (this.Contains(x, y))
            {
                return true;
            }
            return false;
        }
    }
}
