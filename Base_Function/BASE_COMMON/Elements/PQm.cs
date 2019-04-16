using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PQm : PContaine
    {
        public override string XmlName()
        {
            return "pqm";
        }

        public override void ToXml(XmlElement element)
        {
            foreach (PRectangleQm qm in this.ChildElements)
            {
                XmlElement parentElement = element.OwnerDocument.CreateElement("qm");
                XmlElement xmlElement = element.OwnerDocument.CreateElement("content");
                xmlElement.InnerText = qm.Content;
                parentElement.AppendChild(xmlElement); 
                
                XmlElement userid = element.OwnerDocument.CreateElement("userid");
                userid.InnerText = qm.UserId;
                parentElement.AppendChild(userid);

                element.AppendChild(parentElement);
            }
        }

        public override void FromXml(XmlElement element)
        {
            for (int i = 0; i < element.ChildNodes.Count; i++)
            {
                XmlElement child = (XmlElement)element.ChildNodes[i];
                PRectangleQm qm = ((PRectangleQm)this.ChildElements[i]);
                qm.Content = child["content"].InnerText;
                qm.UserId = child["userid"].InnerText;
            }
        }


        public PQm(int x, int y, int width, int height, string name, Document document)
            : base(x, y, width, height, name, document)
        {
            for (int i = 0; i < this.Document.WCount; i++)
            {
                PRectangleTxy prt = new PRectangleQm(this.X + i * document.celWidht, this.Y, document.celWidht, this.Height, "", this.Document);
                this.ChildElements.Add(prt);
            }
        }
    }
}
