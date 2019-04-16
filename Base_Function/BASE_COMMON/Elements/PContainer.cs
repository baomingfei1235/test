using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Xml;

namespace Base_Function.BASE_COMMON.Elements
{
    public abstract class PContaine : PElement
    {

        public PContaine()
        {
        }

        public abstract string XmlName();
        public virtual void ToXml(XmlElement element){}
        public virtual void FromXml(XmlElement element){}

        public PContaine(int x, int y, int width, int height, string name, Document document)
            : base
                (x, y, width, height, name, document)
        {
 
        }

        public override bool Draw()
        {
            using (Pen p = new Pen(Color.Black, 1))
            {
                Rectangle rectangle = new Rectangle(this.X - 50, this.Y, 50, this.Height);
                base.Document.View.Graph.DrawString(Name, new Font("宋体", 9), Brushes.Black, rectangle, this.Document.Format);
                base.Document.View.Graph.DrawRectangle(p, rectangle);
                //base.Document.View.Graph.DrawLine(p, this.X, this.Y + this.Height, this.X + this.Width, this.Y + this.Height);
                foreach (PElement text in this.ChildElements)
                {
                    base.Document.View.Graph.DrawRectangle(p, text.X, text.Y, text.Width, text.Height);
                    text.Draw();
                }
            }
            return false;
        }

        public void RefreshSize()
        {
 
        }

        private List<PElement> childElements = new List<PElement>();

        public List<PElement> ChildElements
        {
            get { return childElements; }
            set { childElements = value; }
        }
        public override bool MouseClick(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            foreach (PElement ement in this.ChildElements)
            {
                if (ement.MouseClick(x, y, button))
                    return true;
            }
            return base.MouseClick(x, y, button);
        }

        public PElement this[int index]
        {
            get
            {
                return this.ChildElements[index];
            }
        }
    }
}
