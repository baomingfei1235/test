using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PPrintLog:PElement
    {
        private Image image = null;

        public PPrintLog()
        {
 
        }

        public PPrintLog(int x, int y, int width, int height, string name, Document document,Image img)
            : base
                (x, y, width, height, name, document)
        {
            this.image = img;
        }

        public override bool Draw()
        {
            if (image != null)
            {
                this.Document.View.Graph.DrawImage(image, this.X, this.Y, image.Width, image.Height);
                Font font = new Font("宋体", 18, FontStyle.Bold);
                using(Brush brush = new SolidBrush(Color.Black))
                {
                    this.Document.View.Graph.DrawString("产 程 进 展 图", font, brush,new Rectangle(this.X + this.Width,this.Y,this.Width,this.Height),this.Document.Format);
                }
                font.Dispose();
            }
            return true;
        }
    }
}
