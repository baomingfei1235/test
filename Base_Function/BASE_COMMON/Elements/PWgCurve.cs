using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Base_Function.MODEL;

namespace Base_Function.BASE_COMMON.Elements
{
    public class PWgCurve : PElement
    {
        private int wwidth = 28;
        private int wheight = 28;
        private int wwcount = 24;
        private int whcount = 10;
        private Dictionary<int, List<PPoint>> points = new Dictionary<int, List<PPoint>>();

        public PWgCurve()
        {
            points.Add(0, new List<PPoint>());
            points.Add(1, new List<PPoint>());
        }

        public PWgCurve(int x,int y,Document document)
        {
            points.Add(0, new List<PPoint>());
            points.Add(1, new List<PPoint>());
            this.X = x;
            this.Y = y;
            this.Document = document;
            RefreshSize();
        }


        public Dictionary<int, List<PPoint>> Points
        {
            get
            {
                return points;
            }
            set { points = value; }
        }

        public void RefreshSize()
        {
            this.Width = wwidth * wwcount;
            this.Height = wheight * whcount;
        }

        public void RefreshSizePoints()
        {
            this.points[0].Clear();
            this.points[1].Clear();
            DateTime time = this.Document.Userinfo.StartTime;
            DateTime firstTime = Convert.ToDateTime(time.ToString("yyyy-MM-dd HH:00"));
            foreach (PartogramCurve curve in this.Document.Userinfo.Pcurves)
            {
                DateTime sencondTime = Convert.ToDateTime(curve.Time.ToString("yyyy-MM-dd HH:00"));
                if (firstTime.AddHours(this.Document.Userinfo.LeftMoveTime + (this.Document.Userinfo.LeftMoveTime > 23 ? 1 : 0)) > sencondTime
                    || firstTime.AddHours(this.Document.Userinfo.LeftMoveTime + 23) < sencondTime
                    || (firstTime.AddHours(this.Document.Userinfo.LeftMoveTime) == sencondTime && firstTime.AddHours(this.Document.Userinfo.LeftMoveTime) != firstTime))
                {
                    continue;
                }

                if (curve.Gjkg >= 0)
                {
                    float p1 = curve.Gjkg;
                    int hour = (int)((sencondTime - firstTime).TotalHours) - this.Document.Userinfo.LeftMoveTime;
                    int minutes = curve.Time.Minute;
                    float valueX = hour * wwidth + minutes * ((float)wwidth / 60);
                    float valueY = (10 - curve.Gjkg) * (float)wheight;
                    this.AddPoint(0, valueX, valueY);
                }

                if (curve.Xlxj >= -5 && curve.Xlxj <= 5)
                {
                    float p1 = curve.Xlxj;
                    int hour = (int)((sencondTime - firstTime).TotalHours) - this.Document.Userinfo.LeftMoveTime;
                    int minutes = curve.Time.Minute;
                    float valueX = hour * wwidth + minutes * ((float)wwidth / 60);
                    float valueY = (curve.Xlxj + 5) * (float)wheight;
                    this.AddPoint(1, valueX, valueY);
                }
            }

            foreach (PartogramMccs pmcc in this.Document.Userinfo.Pmccs)
            {
                DateTime sencondTime = Convert.ToDateTime(pmcc.Time.ToString("yyyy-MM-dd HH:00"));
                if (firstTime.AddHours(this.Document.Userinfo.LeftMoveTime + (this.Document.Userinfo.LeftMoveTime > 23 ? 1 : 0)) > sencondTime
                    || firstTime.AddHours(this.Document.Userinfo.LeftMoveTime + 23) < sencondTime
                    || (firstTime.AddHours(this.Document.Userinfo.LeftMoveTime) == sencondTime && firstTime.AddHours(this.Document.Userinfo.LeftMoveTime) != firstTime))
                {
                    continue;
                }

                //float p1 = curve.Gjkg;
                int hour = (int)((sencondTime - firstTime).TotalHours) - this.Document.Userinfo.LeftMoveTime;
                int minutes = pmcc.Time.Minute;
                float valueX = hour * wwidth + minutes * ((float)wwidth / 60);
                float valueY = 0 * (float)wheight;
                this.AddPoint(0, valueX, valueY, pmcc.PrintStr);
            }
            base.Document.OwnerControl.Refresh();
        }

        void AddPoint(int type, float abc, float cba)
        {
            float valueX = float.Parse(abc.ToString("F1"));
            float valueY = float.Parse(cba.ToString("F1"));
            //if (!IsHavePointToXValue(valueX))
            //    return;
            PPoint p = new PPoint();
            p.X = GetAbsoluteX(valueX);
            p.Y = GetAbsoluteY(valueY);
            p.Xvalue = valueX;
            p.Yvalue = valueY;
            Points[type].Add(p);
            Points[type].Sort(new SortXValue());
        }

        void AddPoint(int type, float abc, float cba, string content)
        {
            float valueX = float.Parse(abc.ToString("F1"));
            float valueY = float.Parse(cba.ToString("F1"));
            //if (!IsHavePointToXValue(valueX))
            //    return;
            PPoint p = new PPoint();
            p.X = GetAbsoluteX(valueX);
            p.Y = GetAbsoluteY(valueY);
            p.Xvalue = valueX;
            p.PrintStr = content;
            p.Yvalue = valueY;
            Points[type].Add(p);
            Points[type].Sort(new SortXValue());
        }

        private int GetAbsoluteY(float valueY)
        {
            return (int)(this.Y + valueY);
        }

        private int GetAbsoluteX(float valueX)
        {
            return (int)valueX + this.X;
        }

        private int GetInsertIndex(float xvalue)
        {
            return 0;
        }

        private bool IsHavePointToXValue(float value)
        {

            foreach (PPoint point in Points[0])
            {
                if (point.Xvalue == value)
                    return false;
            }
            return true;
        }

        int oldx = 0;
        void RefreshPoint()
        {
            oldx = 0;
            int x = GetAbsoluteX(0);
            int y = GetAbsoluteY(this.Height);
            int i = 0;
            using (Pen p = new Pen(Color.Red))
            {
                foreach (PPoint point in Points[0])
                {
                    base.Document.View.Graph.FillEllipse(Brushes.Red, point.X - 3, point.Y - 3, 6, 6);
                    if (i == 0 && this.Document.Userinfo.Fazuo==1)
                    {
                        p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    }
                    base.Document.View.Graph.DrawLine(p, x, y, point.X, point.Y);
                    if (i == 0)
                    {
                        p.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    }
                    if (!string.IsNullOrEmpty(point.PrintStr))
                    {
                        using (Pen p2 = new Pen(Color.Red))
                        {
                            System.Drawing.Drawing2D.AdjustableArrowCap aac = new System.Drawing.Drawing2D.AdjustableArrowCap(3, 3, true);
                            p2.CustomEndCap = aac;
                            base.Document.View.Graph.DrawLine(p2, point.X, point.Y, point.X, point.Y + this.wheight - 2);
                        }
                        Document.Format.LineAlignment = StringAlignment.Near;
                        int leftX = point.X - ((point.X - this.X) % this.wwidth);
                        if (oldx == leftX)
                        {
                            leftX += this.wwidth;
                        }
                        base.Document.View.Graph.DrawString(point.PrintStr, new Font("宋体", 9), Brushes.Red, new Rectangle(leftX, point.Y + this.wheight + 2, this.wwidth, this.Height), Document.Format);
                        oldx = leftX;
                        Document.Format.LineAlignment = StringAlignment.Center;
                    }
                    x = point.X;
                    y = point.Y;
                    i++;
                }
                p.Color = Color.Blue;     
                int x1 = -1;
                int y1 = -1;
                foreach (PPoint point in Points[1])
                {
                    base.Document.View.Graph.FillEllipse(Brushes.Blue, point.X - 3, point.Y - 3, 6, 6);
                    if (x1 >= 0)
                    {
                        base.Document.View.Graph.DrawLine(p, x1, y1, point.X, point.Y);
                    }
                    x1 = point.X;
                    y1 = point.Y;
                }
               
                foreach (PPoint point in points[0])
                {
                    foreach (PPoint point1 in points[1])
                    {
                        if (point1.X == point.X && point1.Y == point.Y)
                        {
                            Rectangle rect = new Rectangle(point.X - 4, point.Y - 4, 8, 8);
                            base.Document.View.Graph.FillEllipse(Brushes.White, rect);
                            base.Document.View.Graph.DrawEllipse(Pens.Red, rect);
                            base.Document.View.Graph.FillEllipse(Brushes.Blue, rect.X + 2, rect.Y + 2, 4, 4);
                        }
                    }
                }
            }
        }

        public override bool Draw()
        {
            DrawFramer();
            RefreshPoint();
            return true;
        }

        public override bool MouseMove(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            if (base.Contains(x, y))
            {
                float abc = (float)(x - this.X) / (float)this.wwidth;
                float cba = (float)(-(y - this.Y - this.Height)) / (float)this.wheight;
                //base.Document.OwnerControl.setString(abc.ToString("F1") + "：" + cba.ToString("0.#"));
                return true;
            }
            return false;
        }

        public override bool MouseDown(int x, int y, System.Windows.Forms.MouseButtons button)
        {
            if (this.Contains(x, y))
            {
                float abc = (float)(x - this.X) / (float)this.wwidth;
                float cba = (float)(-(y - this.Y - this.Height)) / (float)this.wheight;
                this.AddPoint(0, abc, cba);
                return true;
            }
            return false;
        }

        private void DrawFramer()
        {
            using (Pen pen = new Pen(Color.Black, 1))
            {
                Font font = new Font("宋体", 10);
                using (Brush brush = new SolidBrush(Color.Black))
                {
                    base.Document.View.Graph.DrawLine(pen, this.X - 25, this.Y, this.X - 25, this.Y + this.Height);
                    base.Document.View.Graph.DrawLine(pen, this.X - 50, this.Y, this.X - 50, this.Y + this.Height);
                    //base.Document.View.Graph.DrawLine(pen, this.X - 50, this.Y + this.Height, this.X, this.Y + this.Height);
                    //base.Document.View.Graph.DrawLine(pen, this.X - 50, this.Y, this.X + this.Width, this.Y);
                    //base.Document.View.Graph.DrawLine(pen, this.X - 50, this.Y + this.Height, this.X, this.Y + this.Height);
                    this.Document.Format.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                    base.Document.View.Graph.DrawString("宫颈扩张红色  cm", font, brush, new Rectangle(this.X - 50, this.Y, 25, this.Height), this.Document.Format);
                    base.Document.View.Graph.FillEllipse(Brushes.Red, this.X - 40, this.Y + 175, 6, 6);
                    base.Document.View.Graph.DrawString("先露下降蓝色  cm", font, brush, new Rectangle(this.X + this.Width + 15, this.Y, 25, this.Height), this.Document.Format);
                    base.Document.View.Graph.FillEllipse(Brushes.Blue, this.X + this.Width + 25, this.Y + 175, 6, 6);
                    this.Document.Format.FormatFlags = 0;
                    int countWidth = wwcount + 1;
                    for (int i = 0; i < countWidth; i++)
                    {
                        int realLeft = this.wwidth * i + this.X;
                        base.Document.View.Graph.DrawLine(pen, realLeft, this.Y, realLeft, this.Y + this.Height);
                    }
                    int countHeight = whcount + 1; 
                    this.Document.Format.FormatFlags = StringFormatFlags.NoWrap;
                    for (int j = 0; j < countHeight; j++)
                    {
                        int realTop = this.wheight * j + this.Y;
                        base.Document.View.Graph.DrawLine(pen, this.X, realTop, this.X + this.Width, realTop);
                        if (j > 0)
                        {
                            if (j == countHeight - 1)
                            {
                                //base.Document.View.Graph.FillRectangle(Brushes.White, new Rectangle(this.X - this.wheight + 8, realTop - this.wheight / 2, wwidth, wheight));
                            }
                            base.Document.View.Graph.DrawString((whcount - j).ToString(), font, brush, new Rectangle(this.X - this.wheight + 8, realTop - this.wheight / 2, wwidth, wheight), this.Document.Format);
                        }
                        if (j > 0 && j < countHeight - 1)
                            base.Document.View.Graph.DrawString(((j > 5) ? "+" : "") + (-5 + j).ToString(), font, brush, new Rectangle(this.X + this.Width - 4, realTop - this.wheight / 2, wwidth, wheight), this.Document.Format);
                    }
                    this.Document.Format.FormatFlags = 0;// StringFormatFlags.DirectionRightToLeft;
                }
            }
        }
    }
}
