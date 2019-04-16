using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PYs : PContaine
    {
        public override string XmlName()
        {
            return "pys";
        }

        public override void ToXml(XmlElement element)
        {
            foreach (PRectangleYs ys in this.ChildElements)
            {
                XmlElement parentElement = element.OwnerDocument.CreateElement("ys");
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
                ((PRectangleYs)this.ChildElements[i]).Content = child["content"].InnerText;
            }
        }

        public PYs(int x, int y, int width, int height, string name, Document document)
            : base(x, y, width, height, name, document)
        {
            for (int i = 0; i < this.Document.WCount; i++)
            {
                PRectangleTxy prt = new PRectangleYs(this.X + i * document.celWidht, this.Y, document.celWidht, this.Height, "", this.Document);
                this.ChildElements.Add(prt);
            }
        }
    }
}
