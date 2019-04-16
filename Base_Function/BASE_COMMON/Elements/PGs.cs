using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Xml;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PGs : PContaine
    {
        public override string XmlName()
        {
            return "pgs";
        }

        public PGs(int x, int y, int width, int height, string name, Document document)
            : base(x, y, width, height, name, document)
        {
            for (int i = 0; i < this.Document.WCount; i++)
            {
                PRectangleGs prt = new PRectangleGs(this.X + i * document.celWidht, this.Y, document.celWidht, this.Height, "", this.Document);
                this.ChildElements.Add(prt);
            }
        }

        public override void ToXml(XmlElement element)
        {
            foreach (PRectangleGs gs in this.ChildElements)
            {
                XmlElement parentElement = element.OwnerDocument.CreateElement("gs");
                XmlElement m1 = element.OwnerDocument.CreateElement("m1");
                m1.InnerText = gs.M1.ToString();
                parentElement.AppendChild(m1);

                XmlElement m2 = element.OwnerDocument.CreateElement("m2");
                m2.InnerText = gs.M2.ToString();
                parentElement.AppendChild(m2);

                XmlElement s1 = element.OwnerDocument.CreateElement("s1");
                s1.InnerText = gs.S1.ToString();
                parentElement.AppendChild(s1);

                XmlElement s2 = element.OwnerDocument.CreateElement("s2");
                s2.InnerText = gs.S2.ToString();
                parentElement.AppendChild(s2);

                element.AppendChild(parentElement);
            }
        }

        public override void FromXml(XmlElement element)
        {
            for (int i = 0; i < element.ChildNodes.Count; i++)
            {
                XmlElement child = (XmlElement)element.ChildNodes[i];
                PRectangleGs gs = ((PRectangleGs)this.ChildElements[i]);
                string m1 = child["m1"].InnerText;
                if (!string.IsNullOrEmpty(m1))
                {
                    gs.M1 = Convert.ToInt32(m1);
                }

                string m2 = child["m2"].InnerText;
                if (!string.IsNullOrEmpty(m2))
                {
                    gs.M2 = Convert.ToInt32(m2);
                }

                string s1 = child["s1"].InnerText;
                if (!string.IsNullOrEmpty(s1))
                {
                    gs.S1 = Convert.ToInt32(s1);
                }

                string s2 = child["s2"].InnerText;
                if (!string.IsNullOrEmpty(s2))
                {
                    gs.S2 = Convert.ToInt32(s2);
                }
            }
        }


        public override bool Draw()
        {
            using (Brush b = new SolidBrush(Color.Black))
            {
                Font f = new Font("宋体", 7.5f);
                this.Document.View.Graph.DrawString("持续", f, b,this.X + this.Width, this.Y);
                using (Pen p = new Pen(Color.Black))
                {
                    this.Document.View.Graph.DrawLine(p, this.X + this.Width + 10, this.Y + 15, this.X + this.Width + 25, this.Y + 8);
                }
                this.Document.View.Graph.DrawString("间隔", f, b, this.X + this.Width + 10, this.Y + 14);
                f.Dispose();
                f.Dispose();
            }
            return base.Draw();
        }
    }
}
