using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PTxy : PContaine
    {
        public override string XmlName()
        {
            return "ptxy";
        }


        public override void ToXml(XmlElement element)
        {
            foreach (PRectangleTxy txy in this.ChildElements)
            {
                XmlElement parentElement = element.OwnerDocument.CreateElement("txy");
                XmlElement xmlElement = element.OwnerDocument.CreateElement("content");
                xmlElement.InnerText = txy.Txy.ToString();
                parentElement.AppendChild(xmlElement);
                element.AppendChild(parentElement);
            }
        }

        public override void FromXml(XmlElement element)
        {
            for (int i = 0; i < element.ChildNodes.Count; i++)
            {
                XmlElement child = (XmlElement)element.ChildNodes[i];
                ((PRectangleTxy)this.ChildElements[i]).Txy = Convert.ToInt32(child["content"].InnerText);
            }
        }

        public PTxy(int x, int y, int width, int height,string name, Document document)
            : base(x, y, width, height,name, document)
        {
            for (int i = 0; i < this.Document.WCount; i++)
            {
                PRectangleTxy prt = new PRectangleTxy(this.X + i * document.celWidht, this.Y, document.celWidht, this.Height, "", this.Document);
                this.ChildElements.Add(prt);
            }
        }

        public override bool MouseClick(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            if (this.Document.Userinfo.Xjtxy == 0)
                return false;
            return base.MouseClick(x, y, button);
        }

        public override bool Draw()
        {
            if (this.Document.Userinfo.Xjtxy == 0)
            {
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    Font f = new Font("宋体", 8);
                    this.Document.View.Graph.DrawString("详见", f, brush, new Rectangle(this.X, this.Y, this.Document.celWidht, this.Height), this.Document.Format);
                    this.Document.View.Graph.DrawString("护理", f, brush, new Rectangle(this.X + this.Document.celWidht, this.Y, this.Document.celWidht, this.Height), this.Document.Format);
                    this.Document.View.Graph.DrawString("记录", f, brush, new Rectangle(this.X + this.Document.celWidht * 2, this.Y, this.Document.celWidht, this.Height), this.Document.Format);
                    this.Document.Format.Alignment = StringAlignment.Near;
                    this.Document.View.Graph.DrawString("单", f, brush, new Rectangle(this.X + this.Document.celWidht * 3, this.Y, this.Document.celWidht, this.Height), this.Document.Format);
                    this.Document.Format.Alignment = StringAlignment.Center;
                    f.Dispose();
                }
            }
            return base.Draw();
        }
    }
}
