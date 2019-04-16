using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;

namespace Base_Function.BASE_COMMON.Elements
{
    public class POther : PContaine
    {
        public override string XmlName()
        {
            return "pother";
        }

        public override void ToXml(XmlElement element)
        {
            foreach (PRectangleOther ys in this.ChildElements)
            {
                XmlElement parentElement = element.OwnerDocument.CreateElement("other");
                XmlElement xmlElement = element.OwnerDocument.CreateElement("content");
                xmlElement.InnerText = ys.Content;
                parentElement.AppendChild(xmlElement);
                element.AppendChild(parentElement);
            }
        }

        public override void FromXml(XmlElement element)
        {
            for (int i = 0; i < element.ChildNodes.Count; i++)
            {
                XmlElement child = (XmlElement)element.ChildNodes[i];
                ((PRectangleOther)this.ChildElements[i]).Content = child["content"].InnerText;
            }
        }

        public POther(int x, int y, int width, int height, string name, Document document)
            : base(x, y, width, height, name, document)
        {
            for (int i = 0; i < this.Document.WCount; i++)
            {
                PRectangleTxy prt = new PRectangleOther(this.X + i * document.celWidht, this.Y, document.celWidht, this.Height, "", this.Document);
                this.ChildElements.Add(prt);
            }
        }

        public override bool Draw()
        {
            using (Pen p = new Pen(Color.Black))
            {
                Rectangle rectangle = new Rectangle(this.X - 50, this.Y, 50, this.Height);
                base.Document.View.Graph.DrawString(Name, new Font("宋体", 10), Brushes.Black, new Rectangle(rectangle.X + 15, rectangle.Y, 20, this.Height), this.Document.Format);
                base.Document.View.Graph.DrawRectangle(p, rectangle);
                //base.Document.View.Graph.DrawLine(p, this.X, this.Y + this.Height, this.X + this.Width, this.Y + this.Height);
                foreach (PElement text in this.ChildElements)
                {
                    base.Document.View.Graph.DrawRectangle(p, text.X, text.Y, text.Width, text.Height);
                    text.Draw();
                }
                return false;
            }
        }
    }
}
