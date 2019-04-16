using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Bifrost;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PDrawTime : PElement
    {
        public PDrawTime(int x, int y, int width, int height, string name, Document doc)
            : base(x, y, width, height, name, doc)
        {

        }

        public override bool Draw()
        {
            using (Pen p = new Pen(Color.Black))
            {
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    this.Document.View.Graph.DrawRectangle(p, this.X - 50, this.Y, 50, this.Height);
                    this.Document.View.Graph.DrawString(Name, new Font("宋体", 9), brush, new Rectangle(this.X - 50, this.Y, 50, this.Height), this.Document.Format);
                    this.Document.View.Graph.DrawRectangle(p, this.X, this.Y, this.Width, this.Height);
                    DateTime start = Convert.ToDateTime(this.Document.Userinfo.StartTime.ToString("yyyy-MM-dd HH:00"));
                    DateTime endTime = App.GetSystemTime();
                    Font font = new Font("宋体", 8);
                    bool haveEndTime = false;
                    if (this.Document.Userinfo.Pcurves.Count > 0)
                    {
                        endTime = Convert.ToDateTime(this.Document.Userinfo.Pcurves[this.Document.Userinfo.Pcurves.Count - 1].Time.ToString("yyyy-MM-dd HH:00"));
                        haveEndTime = true;
                    }

                    if (this.Document.Userinfo.Pmccs.Count > 0)
                    {
                        DateTime newEndTime = Convert.ToDateTime(this.Document.Userinfo.Pmccs[this.Document.Userinfo.Pmccs.Count - 1].Time.ToString("yyyy-MM-dd HH:00"));
                        if (newEndTime > endTime)
                            endTime = newEndTime;
                        haveEndTime = true;
                    }

                    //this.Document.View.Graph.DrawString(start.ToString("HH:00"), font, brush, this.X - 2, this.Y + 5);
                    this.Document.View.Graph.DrawString(start.ToString("HH:00"), font, brush, new Rectangle(this.X - 2, this.Y, this.Document.celWidht + 5, this.Height), this.Document.Format);

                    for (int i = 1; i < this.Document.WCount; i++)
                    {
                        this.Document.View.Graph.DrawLine(p, this.X + i * this.Document.celWidht, this.Y, this.X + i * this.Document.celWidht, this.Y + this.Height);
                        if (haveEndTime)
                        {
                            DateTime time = start.AddHours(i + this.Document.Userinfo.LeftMoveTime);
                            if (time <= endTime)
                            {
                                Rectangle rect = new Rectangle(this.X - 2 + i * this.Document.celWidht, this.Y, this.Document.celWidht + 5, this.Height);
                                this.Document.View.Graph.DrawString(time.ToString("HH:00"), font, brush, rect, this.Document.Format);
                            }
                        }
                    }
                    font.Dispose();
                }
            }
            return false;
        }
    }
}
