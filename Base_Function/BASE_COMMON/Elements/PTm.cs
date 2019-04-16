using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PTm : PContaine
    {
        public override string XmlName()
        {
            return "ptm";
        }


        public override void ToXml(XmlElement element)
        {
            foreach (PRectangleTm ys in this.ChildElements)
            {
                XmlElement parentElement = element.OwnerDocument.CreateElement("tm");
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
                ((PRectangleTm)this.ChildElements[i]).Content = child["content"].InnerText;
            }
        }

         public PTm(int x, int y, int width, int height, string name, Document document)
            : base(x, y, width, height,name, document)
        {
            int rectWidth = this.Width / this.Document.WCount;
            for (int i = 0; i < this.Document.WCount; i++)
            {
                PRectangleTxy prt = new PRectangleTm(this.X + i * document.celWidht, this.Y, document.celWidht, this.Height, "", this.Document);
                this.ChildElements.Add(prt);
            }
        }

        public override bool Draw()
        {
           return base.Draw();
        }
    }
}
