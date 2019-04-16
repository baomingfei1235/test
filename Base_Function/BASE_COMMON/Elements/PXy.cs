using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PXy:PContaine
    {
        public override string XmlName()
        {
            return "pxy";
        }


        public override void ToXml(XmlElement element)
        {
            foreach (PRectangleXy txy in this.ChildElements)
            {
                XmlElement parentElement = element.OwnerDocument.CreateElement("xy");
                XmlElement xmlElement = element.OwnerDocument.CreateElement("value1");
                xmlElement.InnerText = txy.Xy1.ToString();
                parentElement.AppendChild(xmlElement);
                
                XmlElement xy2 = element.OwnerDocument.CreateElement("value2");
                xy2.InnerText = txy.Xy2.ToString();
                parentElement.AppendChild(xy2);


                element.AppendChild(parentElement);
            }
        }

        public override void FromXml(XmlElement element)
        {
            for (int i = 0; i < element.ChildNodes.Count; i++)
            {
                XmlElement child = (XmlElement)element.ChildNodes[i];
                ((PRectangleXy)this.ChildElements[i]).Xy1 = Convert.ToInt32(child["value1"].InnerText);
                ((PRectangleXy)this.ChildElements[i]).Xy2 = Convert.ToInt32(child["value2"].InnerText);
            }
        }

        public PXy(int x, int y, int width, int height, string name, Document document)
            : base(x, y, width, height, name, document)
        {
            for (int i = 0; i < this.Document.WCount; i++)
            {
                PElement prt = new PRectangleXy(this.X + i * document.celWidht, this.Y, document.celWidht, this.Height, "", this.Document);
                this.ChildElements.Add(prt);
            }
        }

        public override bool Draw()
        {
            using (Brush b = new SolidBrush(Color.Black))
            {
                Font f = new Font("宋体", 9);
                this.Document.View.Graph.DrawString("mmHg", f, b, new Rectangle(this.X + this.Width, this.Y, this.Document.celWidht + 5, this.Height), this.Document.Format);
                f.Dispose();
            }
            return base.Draw();
        }
    }
}
